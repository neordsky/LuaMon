Imports System.Data.Odbc
Public Class laporan

    Private Sub laporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub laporan_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Chart1.Series("Omset").Points.Clear()
        Dim Yi As String
        Dim Er As String
        Yi = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        Er = Format(DateTimePicker2.Value, "yyyy-MM-dd")
        Call Connecti()
        Cmd = New OdbcCommand("Select SUM(Total_Pembayaran) as Total,DATE(Tanggal_Transaksi) as Date from tbl_laporan where Tanggal_Transaksi Between'" & Yi & "' and '" & Er & "' Group by DATE(Tanggal_Transaksi) Order By Tanggal_Transaksi DESC", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Me.Chart1.Series("Omset").Points.AddXY(Rd.Item("Date").ToString, Rd.Item("Total"))
        End While
        If Not Rd.HasRows Then
            MsgBox("Data Not Found..!")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim yi As String
        Dim er As String
        yi = Format(DateTimePicker1.Value, "yyyy-MM-dd")
        er = Format(DateTimePicker2.Value, "yyyy-MM-dd")
        Call Connecti()
        Cmd = New OdbcCommand("Select * from tbl_laporan where Tanggal_Transaksi between '" & yi & "%' and '" & er & "' ", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call Connecti()
            Da = New OdbcDataAdapter("Select * from tbl_laporan where Tanggal_Transaksi between'" & yi & "' and '" & er & "'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "tbl_laporan")
            DataGridView1.DataSource = Ds.Tables("tbl_laporan")
            DataGridView1.ReadOnly = True
            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 300
            DataGridView1.Columns(2).Width = 200
            DataGridView1.Columns(3).Width = 200

        Else
            MsgBox("Data not found..!")
        End If

    End Sub

    Private Sub Panel5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class
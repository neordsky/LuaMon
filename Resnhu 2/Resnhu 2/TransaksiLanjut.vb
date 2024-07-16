Imports System.Data.Odbc
Imports System.Drawing.Printing
Public Class TransaksiLanjut
    Dim WithEvents Pri As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Public Property NamKasir As String
    Public Property Tot As Integer
    Sub saisho()
        Da = New OdbcDataAdapter("Select * from tbl_keranjang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_keranjang")
        DataGridView1.DataSource = Ds.Tables("tbl_keranjang")
        DataGridView1.ReadOnly = True
    End Sub
    Private Sub TransaksiLanjut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call saisho()
        total.Text = Tot
    End Sub

    Private Sub Pri_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Pri.BeginPrint
        Dim Pusiz As New PageSettings
        Pusiz.PaperSize = New PaperSize("Custom", 400, 300)
        Pri.DefaultPageSettings = Pusiz
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Pri.PrintPage
        Dim Ji1 As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim ji2 As New Font("Times New Roman", 7, FontStyle.Regular)
        Dim ji3 As New Font("Times New Roman", 8, FontStyle.Italic)
        Dim ji4 As New Font("Times New Roman", 4, FontStyle.Regular)

                            

        Dim Cen As New StringFormat
        Cen.Alignment = StringAlignment.Center

        e.Graphics.DrawString("Market YoTen", Ji1, Brushes.Black, 150, 10)
        e.Graphics.DrawString("Jln.TianDou 06", ji3, Brushes.Black, 150, 40)
        e.Graphics.DrawString("09347891239", ji2, Brushes.Black, 150, 70)

        e.Graphics.DrawString("Nama Barang", ji4, Brushes.Bisque, 5, 100)
        e.Graphics.DrawString("Harga Satuan", ji4, Brushes.Bisque, 80, 100)
        e.Graphics.DrawString("Jumlah Barang", ji4, Brushes.Bisque, 130, 100)
        e.Graphics.DrawString("Total Harga", ji4, Brushes.Bisque, 200, 100)
        e.Graphics.DrawString("Id Transaksi", ji4, Brushes.Bisque, 300, 100)
        Dim heig As Integer = 110
        For yu As Integer = 0 To DataGridView1.RowCount - 1
            e.Graphics.DrawString(DataGridView1.Rows(yu).Cells(1).Value, ji4, Brushes.Black, 5, heig)
            e.Graphics.DrawString(DataGridView1.Rows(yu).Cells(3).Value, ji4, Brushes.Black, 80, heig)
            e.Graphics.DrawString(DataGridView1.Rows(yu).Cells(4).Value, ji4, Brushes.Black, 130, heig)
            e.Graphics.DrawString(DataGridView1.Rows(yu).Cells(6).Value, ji4, Brushes.Black, 200, heig)
            e.Graphics.DrawString(DataGridView1.Rows(yu).Cells(0).Value, ji4, Brushes.Black, 300, heig)
            heig += 10

        Next


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim yoa As Integer = Kemba.Text
        Dim eas As Integer = total.Text
        If Kane.Text = "" Or yoa < eas Then
            MsgBox("Uang Anda Kurrang")
        Else
            Dim Tgl As String
            Tgl = Format(DateTimePicker1.Value, "yyyy-MM-dd")
            For yi As Integer = 0 To DataGridView1.RowCount - 1
                Dim yia As String
                Dim era As Long
                Call Connecti()
                Cmd = New OdbcCommand("Select * from tbl_laporan where IdTransaksi in(select max(IdTransaksi) from tbl_laporan)", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    yia = "T" + "001"
                Else

                    era = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
                    yia = "T" + Microsoft.VisualBasic.Right("000" & era, 3)
                End If
                Call Connecti()
                Cmd = New OdbcCommand("Insert into tbl_laporan set IdTransaksi='" & yia & "',Total_Pembayaran='" & DataGridView1.Rows(yi).Cells(6).Value & "',Nama_Kasir='" & NamKasir & "',Tanggal_Transaksi='" & Tgl & "'", Conn)
                Cmd.ExecuteReader()

                Call Connecti()
                Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang='" & DataGridView1.Rows(yi).Cells(2).Value & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Call Connecti()
                    Cmd = New OdbcCommand("Update tbl_barang set Jumlah_Barang='" & Rd.Item("Jumlah_Barang") - DataGridView1.Rows(yi).Cells(4).Value & "' where Kode_Barang='" & DataGridView1.Rows(yi).Cells(2).Value & "'", Conn)
                    Cmd.ExecuteNonQuery()
                End If

            Next
            Try
                Call Connecti()
                Cmd = New OdbcCommand("Delete from tbl_keranjang", Conn)
                Cmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            If MessageBox.Show("Apakah Anda Mau Mencetak Pembayarannya?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                PPD.Document = Pri
                PPD.ShowDialog()
                Me.Close()
            Else
                Me.Close()
            End If
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles total.Click

    End Sub

    Private Sub Panel3_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Kane_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Kane.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If Kane.Text = "" Then
        Else
            If Kane.TextLength = "9" Then
                MsgBox("Melebihi Jumlah")
                e.Handled = True
            Else

            End If
        End If
    End Sub

    Private Sub Kane_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kane.TextChanged

        Kemba.Text = Kane.Text - total.Text

    End Sub
End Class
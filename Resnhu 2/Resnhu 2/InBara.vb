Imports System.Data.Odbc
Public Class InBara
    Sub DataBarang()
        Call Connecti()
        Da = New OdbcDataAdapter("Select * from tbl_barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_barang")
        DataGridView1.DataSource = Ds.Tables("tbl_barang")
        DataGridView1.ReadOnly = True
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 150
        DataGridView1.Columns(2).Width = 150
        DataGridView1.Columns(3).Width = 150
        DataGridView1.Columns(0).Width = 100
    End Sub
    Sub saisho()
        Kb.Text = ""
        Naba.Text = ""
        Jeba.Text = ""
        Haba.Text = ""
        Quan.Text = ""
        toha.Text = ""
        TextBox1.Text = ""
    End Sub
    Private Sub InBara_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DataBarang()
    End Sub

    
   

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim an As Integer
        an = DataGridView1.CurrentRow.Index
        Kb.Text = DataGridView1.Item(0, an).Value
        Naba.Text = DataGridView1.Item(1, an).Value
        Haba.Text = DataGridView1.Item(2, an).Value
        Jeba.Text = DataGridView1.Item(4, an).Value

    End Sub

    Private Sub Quan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Quan.KeyPress
      
    End Sub

    Private Sub Quan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quan.TextChanged
        If Kb.Text = "" Or Naba.Text = "" Or Jeba.Text = "" Or Haba.Text = "" Or Quan.Text = "" Then
        Else
            toha.Text = Quan.Text * Haba.Text
        End If
    End Sub

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
        Else
            Call Connecti()
            Cmd = New OdbcCommand("Select * from tbl_barang where Nama_Barang='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Da = New OdbcDataAdapter("Select * from tbl_barang where Nama_Barang='" & TextBox1.Text & "'", Conn)
                Ds = New DataSet
                Da.Fill(Ds, "tbl_barang")
                DataGridView1.DataSource = Ds.Tables("tbl_barang")
                DataGridView1.ReadOnly = True
            Else
                MsgBox("Data not found..!")
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
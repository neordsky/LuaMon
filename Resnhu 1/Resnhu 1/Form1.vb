Imports System.Data.Odbc
Public Class Form1
    Sub gyaaru()
        Call connect()
        Da = New OdbcDataAdapter("select Nama_Barang from tbl_barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_barang")
        View1.DataSource = Ds.Tables("tbl_barang")
        View1.ReadOnly = True

    End Sub
    Sub MySub()
        Call connect()
        Da = New OdbcDataAdapter("Select * From tbl_barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_barang")
        View1.DataSource = Ds.Tables("tbl_barang")
        View1.ReadOnly = True

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call gyaaru()



    End Sub

    Private Sub View1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles View1.CellContentClick



    End Sub
End Class

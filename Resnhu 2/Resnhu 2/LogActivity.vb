Imports System.Data.Odbc
Public Class LogActivity
    Sub data()
        Da = New OdbcDataAdapter("Select * from log_acti where Waktu Like'%" & Format(DateTimePicker1.Value, "yyyy-MM-dd").ToString & "%'", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "log_acti")
        DataGridView1.DataSource = Ds.Tables("log_acti")
        DataGridView1.ReadOnly = True
        DataGridView1.Columns(0).Width = 150
        DataGridView1.Columns(1).Width = 300
        DataGridView1.Columns(2).Width = 300
        DataGridView1.Columns(3).Width = 200

    End Sub
    Private Sub LogActivity_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call data()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call data()
    End Sub
End Class
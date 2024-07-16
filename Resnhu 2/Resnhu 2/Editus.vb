Imports System.Data.Odbc
Public Class Editus
    Public Property User As String
    Private Sub Editus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = User
        TextBox1.Enabled = False
        Call Connecti()
        Cmd = New OdbcCommand("Select * from tbl_users where Username='" & User & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            ComboBox1.Text = Rd.Item("Level")
        End If
        ComboBox1.Items.Add("Pegawai")
        ComboBox1.Items.Add("Admin")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Connecti()

        Cmd = New OdbcCommand("Select * from tbl_users where Username='" & User & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            If MessageBox.Show("Apakah Anda Yakin ingin mengubah data users dengan username='" & User & "'", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Connecti()
                Cmd = New OdbcCommand("Update tbl_users set Level='" & ComboBox1.Text & "' where Username='" & User & "'", Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Edit Users Success")
                Me.Close()
            Else

            End If
           
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
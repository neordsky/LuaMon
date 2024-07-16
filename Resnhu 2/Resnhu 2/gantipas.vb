Imports System.Data.Odbc
Public Class gantipas

    Private Sub Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Create.Click
        If Usna.Text = "" Or Paw.Text = "" Or Almt.Text = "" Or Ntlp.Text = "" Then
            MsgBox("Lengkapi dulu data")
        Else
            If MessageBox.Show("apakah Anda Yakin ingin mengubah data?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                Call Connecti()
                Cmd = New OdbcCommand("Update into tbl_users set Username='" & Usna.Text & "',Password='" & Paw.Text & "',Alamat='" & Almt.Text & "',NoTelp='" & Ntlp.Text & "' where Id='" & HomePage.id & "'", Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Update Data Berhasil")
                Me.Close()
            Else

            End If
        End If
       

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub gantipas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Usna.Text = HomePage.nama
        Paw.Text = HomePage.pass
        Almt.Text = HomePage.Alamt
        Ntlp.Text = HomePage.notel
    End Sub
End Class
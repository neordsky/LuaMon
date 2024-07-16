Imports System.Data.Odbc
Public Class CreateAccount

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Create_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Create.Click
        If Usna.Text = "" Or Paw.Text = "" Or Almt.Text = "" Then
            MsgBox("Lengkapi dulu Data")
        Else
            Call Connecti()
            Cmd = New OdbcCommand("Select * From tbl_irreguler where Username='" & Usna.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                MsgBox("Username Telah Terpakai..!")
            Else
                Call Connecti()
                Cmd = New OdbcCommand("Select * from tbl_irreguler where Id in (select max(Id) from tbl_irreguler)", Conn)
                Dim nawa As String
                Dim nama As Long
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    nawa = "I" + "001"

                Else
                    nama = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
                    nawa = "I" + Microsoft.VisualBasic.Right("000" & nama, 3)

                End If
                Call Connecti()
                Cmd = New OdbcCommand("Insert into tbl_irreguler set Id='" & nawa & "',Username='" & Usna.Text & "',Password='" & Paw.Text & "',Alamat='" & Almt.Text & "',NoTelp='" & Ntlp.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Account Anda Telah Di Daftarkan Silahkan Tunggu Konfirmasi Dari Admin Dulu...")
                Usna.Text = ""
                Ntlp.Text = ""
                Almt.Text = ""
                Paw.Text = ""
                Me.Close()
                LoginPage.Visible = True
                LoginPage.Show()

            End If
        End If
    End Sub

  

    Private Sub Usna_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Usna.KeyPress
        If e.KeyChar = Chr(13) Then
            If Usna.Text = "" Then
                MsgBox(" Isi Dulu Username")
            Else
                Paw.Focus()
            End If
        End If
    End Sub

  

    Private Sub Paw_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Paw.KeyPress
        If e.KeyChar = Chr(13) Then
            If Paw.Text = "" Then
                MsgBox(" Isi Dulu Username")
            Else
                Almt.Focus()
            End If
        End If
    End Sub

  

    Private Sub Almt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Almt.KeyPress
        If e.KeyChar = Chr(13) Then
            If Almt.Text = "" Then
                MsgBox(" Isi Dulu Username")
            Else
                Ntlp.Focus()
            End If
        End If
    End Sub

   
    Private Sub CreateAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Usna.Text = ""
        Paw.Text = ""
        Almt.Text = ""
        Ntlp.Text = ""
    End Sub

    Private Sub Almt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Almt.TextChanged

    End Sub

    Private Sub Ntlp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Ntlp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            If Ntlp.Text = "" Then
            Else
                Create.Focus()
            End If
        End If
    End Sub

    Private Sub Ntlp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ntlp.TextChanged

    End Sub
End Class
Imports System.Data.Odbc
Public Class LoginPage

    Private Sub LoginPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Lengkapi Dulu Data")
        Else
            Dim tgl As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim tgli As String = DateTime.Now.ToString("yyyy-MM-dd")
            Call Connecti()
            Cmd = New OdbcCommand("Select * From tbl_users where Username='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                HomePage.nama = Rd.Item("Username")
                HomePage.Alamt = Rd.Item("Alamat")
                HomePage.id = Rd.Item("Id")
                HomePage.pass = Rd.Item("Password")
                HomePage.notel = Rd.Item("NoTelp")

                TransaksiLanjut.NamKasir = Rd.Item("Username")
                HomePage.lev = Rd.Item("Level")
                Call Connecti()
                Cmd = New OdbcCommand("Select * from log_acti where Id='" & Rd.Item("Id") & "' and Waktu Like'%" & tgli & "%'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Call Connecti()
                    Cmd = New OdbcCommand("Select * from log_acti where Id='" & Rd.Item("Id") & "' and Aktivitas='" & "Online" & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        Call Connecti()
                        Cmd = New OdbcCommand("Update log_acti set Waktu='" & tgl & "' where Username='" & TextBox1.Text & "' and Aktivitas='" & "Online" & "'", Conn)
                        Cmd.ExecuteNonQuery()

                  
                    End If

                Else
                    Call Connecti()
                    Cmd = New OdbcCommand("Select * From tbl_users where Username='" & TextBox1.Text & "' and Password='" & TextBox2.Text & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        Call Connecti()
                        Cmd = New OdbcCommand("Insert into log_acti set Id='" & Rd.Item("Id") & "',Username='" & TextBox1.Text & "',Waktu='" & tgl & "',Aktivitas='" & "Online" & "'", Conn)
                        Cmd.ExecuteNonQuery()
                        Call Connecti()
                        Dim Yi As String = "Update tbl_users set Riwayat='" & "Online" & "' where Username='" & TextBox1.Text & "'"
                        Cmd = New OdbcCommand(Yi, Conn)
                        Cmd.ExecuteReader()




                    End If

                End If


                TextBox1.Text = ""
                TextBox2.Text = ""

                Me.Visible = False
                HomePage.ShowDialog()

            Else
                MsgBox("Data Tidak DiKenali")
            End If
           

        End If
    End Sub




    

   

   

    Private Sub TextBox2_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox2.Text = "" Then
                MsgBox("Isi Dulu Password")
            Else
                Button2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If TextBox1.Text = "" Then
                MsgBox("Isi Dulu Username")
            Else
                TextBox2.Focus()
            End If
        End If
    End Sub

  
  
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Me.Visible = False
        CreateAccount.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = False Then

            TextBox2.PasswordChar = "*"
        Else
            TextBox2.PasswordChar = ""


        End If


    End Sub

  
End Class
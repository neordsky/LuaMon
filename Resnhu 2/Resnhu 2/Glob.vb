Imports System.Data.Odbc

Public Class Glob

    Sub UserData()

        Dim heigpa As Integer = 40

        Call Connecti()
        Cmd = New OdbcCommand("Select * from tbl_users", Conn)
        Rd = Cmd.ExecuteReader

        While Rd.Read
            Dim Pan As New Panel()
            Pan.BackColor = Color.Cyan
            Pan.Location = New Point(10, heigpa)
            Pan.Size = New Size(900, 60)
            Data.Controls.Add(Pan)

            Dim ed As New Button()
            Dim del As New Button()
            Dim l1 As New Label()

            Dim li As New Label()
            Dim l2 As New Label()
            Dim l3 As New Label()
            Dim l4 As New Label()
            l1.Text = Rd.Item("Username")
            l1.Location = New Point(10, 5)
            Pan.Controls.Add(l1)

           
            li.Text = Rd.Item("Id")
            li.Location = New Point(150, 10)
            Pan.Controls.Add(li)


            ed.Tag = Rd.Item("Username")
            ed.Location = New Point(700, 20)
            ed.Text = "Edit"
            ed.BackColor = Color.Yellow
            AddHandler ed.Click, AddressOf Edit_Click
            Pan.Controls.Add(ed)

            del.Tag = Rd.Item("Username")
            del.Location = New Point(800, 20)
            del.Text = "Delete"
            del.BackColor = Color.Red
            AddHandler del.Click, AddressOf Del_Click
            Pan.Controls.Add(del)



            l2.Text = Rd.Item("Level")
            l2.Location = New Point(270, 10)
            Pan.Controls.Add(l2)


            l3.Text = Rd.Item("Alamat")
            l3.Location = New Point(400, 10)
            Pan.Controls.Add(l3)


            l4.Text = Rd.Item("Riwayat")
            l4.Location = New Point(500, 10)
            Pan.Controls.Add(l4)

            heigpa += 70

        End While

    End Sub
    Private Sub Glob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call UserData()
        Dim la1 As New Label()
        Dim la2 As New Label()
        Dim la3 As New Label()
        Dim la4 As New Label()
        Dim la5 As New Label()
        la1.Location = New Point(20, 10)
        la1.Text = "Username"
        Panel6.Controls.Add(la1)
        la2.Location = New Point(160, 10)
        la2.Text = "Id"
        Panel6.Controls.Add(la2)
        la3.Location = New Point(280, 10)
        la3.Text = "Level"
        Panel6.Controls.Add(la3)
        la4.Location = New Point(410, 10)
        la4.Text = "Alamat"
        Panel6.Controls.Add(la4)
        la5.Location = New Point(510, 10)
        la5.Text = "Riwayat"
        Panel6.Controls.Add(la5)
    End Sub

    Private Sub Glob_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub

    Private Sub Fit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim click As Button = DirectCast(sender, Button)
        Dim tagval As String = click.Tag.ToString
        Editus.User = tagval
        Editus.ShowDialog()
        'Try
        '    If MessageBox.Show("Apakah Anda Yakin Ingin MengeditNya", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '        Call Connecti()
        '        Cmd = New OdbcCommand("Select * from tbl_users where Username='" & ed.Tag & "'", Conn)
        '        Rd = Cmd.ExecuteReader
        '        Rd.Read()
        '        If Rd.HasRows Then
        '            Call Connecti()
        '            Dim Up As String = "Update tbl_users set Level='" & ListView1.Items(indx).Text & "' where Username='" & ListView1.Items(indx).Text & "'"
        '            Cmd = New OdbcCommand(Up, Conn)
        '            Cmd.ExecuteReader()
        '            MsgBox("Edit Data Success")
        '            Call UserData()
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


    End Sub

    Private Sub Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim clik As Button = DirectCast(sender, Button)
        Dim tagval As String = clik.Tag.ToString
        Try
            If MessageBox.Show("Apakah Anda Yakin Ingin Menghapus Ingin menghapus Users dengan Username== '" & tagval & "' ini?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                Call Connecti()
                Cmd = New OdbcCommand("Select * from tbl_users where Username='" & tagval & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then

                    Call Connecti()
                    Dim Del As String = "Delete from tbl_users where Username='" & tagval & "'"
                    Cmd = New OdbcCommand(Del, Conn)
                    Cmd.ExecuteNonQuery()
                    MsgBox("delete Data Success")
                    Call UserData()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


End Class
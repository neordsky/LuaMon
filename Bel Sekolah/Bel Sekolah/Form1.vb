Imports System.Data.Odbc
Imports System.Media
Imports System.IO
Public Class Form1
    Dim Sound As New SoundPlayer()

    Dim yis As Integer = 0
    Sub jadwalbe()
        JadwalPa.Controls.Clear()

        Try
            Dim kyou As DateTime = DateTime.Today
            Dim engha As String() = {
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
            Dim indha As String() = {
                "Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu"}

            Dim Nichi As Integer = kyou.DayOfWeek
            Dim Nichii As String = indha(Nichi)
            Dim Heig As Integer = 10
            Call conne()
            Cmd = New OdbcCommand("Select* from tbl_jadwal WHERE Hari= ?", Conn)
            Cmd.Parameters.AddWithValue("?", Nichii)
            Rd = Cmd.ExecuteReader      
            While Rd.Read

                Dim Jadpa As New Panel()
                Jadpa.Size = New Size(947, 67)
                Jadpa.Location = New Point(10, Heig)
                Jadpa.BorderStyle = BorderStyle.Fixed3D
                If Rd.Item("Status") = "Sudah" Then
                    Jadpa.BackColor = Color.Green

                    Jadpa.Tag = Rd.Item("Kagi")
                    AddHandler Jadpa.Click, AddressOf JadCard_Click
                    JadwalPa.Controls.Add(Jadpa)

                    Dim las1 As New Label()
                    las1.Text = "Hari"
                    las1.Size = New Size(100, 20)
                    las1.Location = New Point(10, 10)
                    las1.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las1)

                    Dim La1 As New Label()
                    La1.Text = Rd.Item("Hari")
                    La1.Size = New Size(100, 20)
                    La1.Location = New Point(10, 25)
                    La1.Font = New Font("Arial", 13, FontStyle.Regular)
                    Jadpa.Controls.Add(La1)

                    Dim las2 As New Label()
                    las2.Text = "Jam"
                    las2.Size = New Size(100, 20)
                    las2.Location = New Point(120, 10)
                    las2.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las2)

                    Dim La2 As New Label()
                    La2.Text = Rd.Item("Jam").ToString()
                    La2.Size = New Size(100, 20)
                    La2.Location = New Point(120, 25)
                    La2.Font = New Font("Arial", 13, FontStyle.Bold)
                    Jadpa.Controls.Add(La2)

                    Dim las3 As New Label()
                    las3.Text = "Pelajaran Ke"
                    las3.Size = New Size(100, 20)
                    las3.Location = New Point(260, 10)
                    las3.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las3)

                    Dim La3 As New Label()
                    La3.Text = Rd.Item("Bagian")
                    La3.Size = New Size(100, 20)
                    La3.Location = New Point(260, 25)
                    La3.Font = New Font("Arial", 13, FontStyle.Bold)
                    Jadpa.Controls.Add(La3)

                    Dim las4 As New Label()
                    las4.Text = "Kegiatan"
                    las4.Size = New Size(100, 20)
                    las4.Location = New Point(440, 10)
                    las4.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las4)

                    Dim La4 As New Label()
                    La4.Text = Rd.Item("Kegiatan")
                    La4.Size = New Size(100, 20)
                    La4.Location = New Point(440, 25)
                    La4.Font = New Font("Arial", 13, FontStyle.Bold)
                    Jadpa.Controls.Add(La4)
                Else
                    yis = 0
                    If yis = 0 Then
                        Hari.Text = Rd.Item("Hari")
                        Jam.Text = Rd.Item("Jam").ToString
                        JamK.Text = Rd.Item("Bagian")
                        Audio.Text = Rd.Item("Audio")
                        Kegia.Text = Rd.Item("Kegiatan")
                        yis = 1
                    End If
                    Jadpa.Tag = Rd.Item("Kagi")
                    AddHandler Jadpa.Click, AddressOf JadCard_Click
                    JadwalPa.Controls.Add(Jadpa)

                    Dim las1 As New Label()
                    las1.Text = "Hari"
                    las1.Size = New Size(100, 20)
                    las1.Location = New Point(10, 10)
                    las1.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las1)

                    Dim La1 As New Label()
                    La1.Text = Rd.Item("Hari")
                    La1.Size = New Size(100, 20)
                    La1.Location = New Point(10, 25)
                    La1.Font = New Font("Arial", 13, FontStyle.Regular)
                    Jadpa.Controls.Add(La1)

                    Dim las2 As New Label()
                    las2.Text = "Jam"
                    las2.Size = New Size(100, 20)
                    las2.Location = New Point(120, 10)
                    las2.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las2)

                    Dim La2 As New Label()
                    La2.Text = Rd.Item("Jam").ToString()
                    La2.Size = New Size(100, 20)
                    La2.Location = New Point(120, 25)
                    La2.Font = New Font("Arial", 13, FontStyle.Bold)
                    Jadpa.Controls.Add(La2)

                    Dim las3 As New Label()
                    las3.Text = "Pelajaran Ke"
                    las3.Size = New Size(100, 20)
                    las3.Location = New Point(260, 10)
                    las3.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las3)

                    Dim La3 As New Label()
                    La3.Text = Rd.Item("Bagian")
                    La3.Size = New Size(100, 20)
                    La3.Location = New Point(260, 25)
                    La3.Font = New Font("Arial", 13, FontStyle.Bold)
                    Jadpa.Controls.Add(La3)

                    Dim las4 As New Label()
                    las4.Text = "Kegiatan"
                    las4.Size = New Size(100, 20)
                    las4.Location = New Point(440, 10)
                    las4.Font = New Font("Arial", 10, FontStyle.Regular)
                    Jadpa.Controls.Add(las4)

                    Dim La4 As New Label()
                    La4.Text = Rd.Item("Kegiatan")
                    La4.Size = New Size(100, 20)
                    La4.Location = New Point(440, 25)
                    La4.Font = New Font("Arial", 13, FontStyle.Bold)
                    Jadpa.Controls.Add(La4)

                   

                End If

               





                Heig += 70
            End While


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, Label3.Click, Label4.Click, JamK.Click, Jam.Click, Hari.Click, Audio.Click, Label5.Click, Label6.Click, Kagiss.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call jadwalbe()
        Call conne()
        Timer1.Interval = 1000
        Timer1.Start()
        Timer2.Interval = 10000
        Timer2.Start()
        Dim yi As String = Format(DateTime.Now, "hh:mm:ss")
        Dim er As String = DateTime.Now.Minute
        Dim kyou As DateTime = DateTime.Today
        Dim engha As String() = {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
        Dim indha As String() = {
            "Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu"}

        Dim Nichi As Integer = kyou.DayOfWeek
        Dim Nichii As String = indha(Nichi)

        Label5.Text = Nichii + "," + Format(DateTime.Now, "yyyy-MM-dd")

      

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("Apakah anda Yakin menghentikan Alarm?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Sound.Stop()
        Else

        End If

    End Sub

    Private Sub JadCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JadwalPa.Click
        Dim Tava As Panel = DirectCast(sender, Panel)
        Dim Val As String = Tava.Tag.ToString()

        Call conne()
        Cmd = New OdbcCommand("Select * from tbl_jadwal where Kagi='" & Val & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Hari.Text = Rd.Item("Hari")
            Jam.Text = Rd.Item("Jam").ToString
            JamK.Text = Rd.Item("Bagian")
            Audio.Text = Rd.Item("Audio")
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      
        Label4.Text = TimeString
        Dim kyou As DateTime = DateTime.Today
        Dim engha As String() = {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
        Dim indha As String() = {
            "Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu"}

        Dim Nichi As Integer = kyou.DayOfWeek
        Dim Nichii As String = indha(Nichi)

        Try

            Call conne()
            Cmd = New OdbcCommand("Select * From tbl_jadwal where Hari= ? and Jam= ? and Status='Belum'", Conn)
            Cmd.Parameters.AddWithValue("ha", Nichii)
            Cmd.Parameters.AddWithValue("ja", Label4.Text)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then

                Dim Se As String = Rd.Item("Audio")
                Sound.SoundLocation = Se
                Sound.Play()
                Call conne()
                Cmd = New OdbcCommand("Select * from tbl_jadwal where Hari='" & Hari.Text & "' and Jam ='" & Jam.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Call conne()
                    Cmd = New OdbcCommand("Update tbl_jadwal set Status='Sudah' where Hari='" & Hari.Text & "' and Jam ='" & Jam.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call jadwalbe()
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MessageBox.Show("Nyalakan Alarm?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Sound.SoundLocation = Audio.Text
                Sound.Play()
                Call conne()
                Cmd = New OdbcCommand("Select * from tbl_jadwal where Hari='" & Hari.Text & "' and Jam ='" & Jam.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Call conne()
                    Cmd = New OdbcCommand("Update tbl_jadwal set Status='Sudah' where Hari='" & Hari.Text & "' and Jam ='" & Jam.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call jadwalbe()
                    Dim yisa As New Form1
                    yisa.Refresh()
                End If
                Call jadwalbe()
            Catch ex As Exception
                MsgBox(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim engha As String() = {
        "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
        Dim indha As String() = {
            "Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu"}
        Dim kyou As DateTime = DateTime.Today
        Dim Nichi As Integer = kyou.DayOfWeek
        Dim Nichii As String = indha(Nichi)
        If MessageBox.Show("Akhiri semua jadwal?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call conne()
            Cmd = New OdbcCommand("Update tbl_jadwal set Status='Sudah' where Hari='" & Nichii & "' ", Conn)
            Cmd.ExecuteNonQuery()
            Call jadwalbe()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim engha As String() = {
          "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
        Dim indha As String() = {
            "Minggu", "Senin", "Selasa", "Rabu", "Kamis", "Jum'at", "Sabtu"}
        Dim kyou As DateTime = DateTime.Today
        Dim Nichi As Integer = kyou.DayOfWeek
        Dim Nichii As String = indha(Nichi)
        If yis = 0 Then

            Call conne()
            Cmd = New OdbcCommand("Update tbl_jadwal set Status='Belum' where Hari='" & Nichii & "' ", Conn)
            Cmd.ExecuteNonQuery()
            Call jadwalbe()

        End If
    End Sub
End Class

Imports System.Data.Odbc
Imports System.IO
Public Class Edit_Jadwa_l
    Dim nafia As String
    Sub saisho()
        Hate.Enabled = False
        BoxHo.Enabled = False
        BoxMin.Enabled = False
        BoxSe.Enabled = False
        JamLte.Enabled = False
        AudTe.Text = ""
        Hate.Text = ""
        BoxHo.Text = ""
        BoxMin.Text = ""
        BoxSe.Text = ""
        JamLte.Text = ""
        Upd.Text = "Update"
        InsB.Text = "Insert"
        Label4.Visible = False
        Label3.Visible = False
        TextBox1.Visible = False
        TextBox2.Enabled = False
        Hate.Items.Clear()
        Hate.Items.Add("Senin")
        Hate.Items.Add("Selasa")
        Hate.Items.Add("Rabu")
        Hate.Items.Add("Kamis")
        Hate.Items.Add("Jumat")
    End Sub

    Sub hira()
        Hate.Enabled = True
        BoxHo.Enabled = True
        BoxMin.Enabled = True
        BoxSe.Enabled = True
        JamLte.Enabled = True
        Label4.Visible = True
        Label3.Visible = True
        TextBox1.Visible = True
        TextBox2.Enabled = True
    End Sub


    Sub Datas()
        Dim he As Integer = 10
        Call conne()
        Cmd = New OdbcCommand("Select * From tbl_jadwal", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Jadpa As New Panel()
            Jadpa.Size = New Size(750, 70)
            Jadpa.Location = New Point(10, he)
            Jadpa.BorderStyle = BorderStyle.Fixed3D
            Jadpasa.Controls.Add(Jadpa)
            Jadpa.Tag = Rd.Item("Kagi")
            AddHandler Jadpa.Click, AddressOf CradPa_Click

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


            he += 80
        End While
    End Sub
    Sub dase()
        Dim he As Integer = 10
        Call conne()
        Cmd = New OdbcCommand("Select * From tbl_jadwal where Hari= 'Senin'", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Jadpa As New Panel()
            Jadpa.Size = New Size(750, 70)
            Jadpa.Location = New Point(10, he)
            Jadpa.BorderStyle = BorderStyle.Fixed3D
            Jadpasa.Controls.Add(Jadpa)
            Jadpa.Tag = Rd.Item("Kagi")
            AddHandler Jadpa.Click, AddressOf CradPa_Click

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
            he += 80
        End While
    End Sub
    Sub dasel()
        Dim he As Integer = 10
        Call conne()
        Cmd = New OdbcCommand("Select * From tbl_jadwal where Hari = 'Selasa'", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Jadpa As New Panel()
            Jadpa.Size = New Size(750, 70)
            Jadpa.Location = New Point(10, he)
            Jadpa.BorderStyle = BorderStyle.Fixed3D
            Jadpasa.Controls.Add(Jadpa)
            Jadpa.Tag = Rd.Item("Kagi")
            AddHandler Jadpa.Click, AddressOf CradPa_Click

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
            he += 80
        End While
    End Sub

    Sub Darab()
        Dim he As Integer = 10
        Call conne()
        Cmd = New OdbcCommand("Select * From tbl_jadwal where Hari = 'Rabu'", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Jadpa As New Panel()
            Jadpa.Size = New Size(750, 70)
            Jadpa.Location = New Point(10, he)
            Jadpa.BorderStyle = BorderStyle.Fixed3D
            Jadpasa.Controls.Add(Jadpa)
            Jadpa.Tag = Rd.Item("Kagi")
            AddHandler Jadpa.Click, AddressOf CradPa_Click

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
            he += 80
        End While

    End Sub
    Sub Dakam()
        Dim he As Integer = 10
        Call conne()
        Cmd = New OdbcCommand("Select * From tbl_jadwal where Hari= 'Kamis'", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Jadpa As New Panel()
            Jadpa.Size = New Size(750, 70)
            Jadpa.Location = New Point(10, he)
            Jadpa.BorderStyle = BorderStyle.Fixed3D
            Jadpasa.Controls.Add(Jadpa)
            Jadpa.Tag = Rd.Item("Kagi")
            AddHandler Jadpa.Click, AddressOf CradPa_Click

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
            he += 80
        End While
    End Sub
    Sub dajum()
        Dim he As Integer = 10
        Call conne()
        Cmd = New OdbcCommand("Select * From tbl_jadwal where Hari= 'Jumat'", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Jadpa As New Panel()
            Jadpa.Size = New Size(750, 70)
            Jadpa.Location = New Point(10, he)
            Jadpa.BorderStyle = BorderStyle.Fixed3D
            Jadpasa.Controls.Add(Jadpa)
            Jadpa.Tag = Rd.Item("Kagi")
            AddHandler Jadpa.Click, AddressOf CradPa_Click

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
            he += 80
        End While
    End Sub

    Sub saibut()
        Jadpasa.Controls.Clear()
        Senin.BackColor = Color.White
        Selasa.BackColor = Color.White
        Rabu.BackColor = Color.White
        Kamis.BackColor = Color.White
        Jumat.BackColor = Color.White
        Button1.BackColor = Color.White
    End Sub




    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Call saisho()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BoxSe.SelectedIndexChanged

    End Sub

    Private Sub Edit_Jadwa_l_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call saisho()
        Call Datas()
        Button1.BackColor = Color.Cyan
        For yi As Integer = 0 To 24
            Dim sr As String = yi
            If yi >= 10 Then
                BoxHo.Items.Add(yi)
            Else
                BoxHo.Items.Add("0" + sr)
            End If
        Next

        For yi As Integer = 0 To 60
            Dim st As String = yi
            If yi >= 10 Then
                BoxMin.Items.Add(yi)
                BoxSe.Items.Add(yi)
            Else
                BoxMin.Items.Add("0" + st)
                BoxSe.Items.Add("0" + st)
            End If

        Next







    End Sub

    Private Sub InsB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsB.Click

        If InsB.Text = "Insert" Then
            Call hira()
            InsB.Text = "Simpan"

        Else
            If Hate.Text = "" Or BoxHo.Text = "" Or BoxMin.Text = "" Or BoxSe.Text = "" Or AudTe.Text = "" Or JamLte.Text = "" Then
                MsgBox("Lengkapi Dulu Data")
            Else
                Dim na As String = AudTe.Text
                If Not String.IsNullOrEmpty(na) Then
                    Dim AudBy As Byte() = File.ReadAllBytes(na)
                    Dim locfi As String = "D:\Resnhu Neord\Bel Sekolah\" + nafia

                    File.WriteAllBytes(locfi, AudBy)
                    Dim hor As Integer = Integer.Parse(BoxHo.Text)
                    Dim minu As Integer = Integer.Parse(BoxMin.Text)
                    Dim sec As Integer = Integer.Parse(BoxSe.Text)
                    Dim ti As New DateTime(1, 1, 1, hor, minu, sec)
                    Dim tis As String = ti
                    Dim jamk As Integer = Integer.Parse(JamLte.Text)



                    Call conne()
                    Cmd = New OdbcCommand("Insert Into tbl_jadwal set Hari='" & Hate.Text & "',Jam='" & tis & "',Bagian='" & JamLte.Text & "',Audio='" & "D:\\Resnhu Neord\\Bel Sekolah\\" + nafia & "',Status='Belum',Kegiatan='" & TextBox2.Text & "' ", Conn)
                    Cmd.ExecuteNonQuery()
                    MsgBox("Data Berhasil Di simpan")
                    Call saisho()

                    If Button1.BackColor = Color.Cyan Then
                        Call Datas()
                    ElseIf Senin.BackColor = Color.Cyan Then
                        Call dase()
                    ElseIf Selasa.BackColor = Color.Cyan Then
                        Call dasel()
                    ElseIf Rabu.BackColor = Color.Cyan Then
                        Call Darab()
                    ElseIf Kamis.BackColor = Color.Cyan Then
                        Call Dakam()
                    ElseIf Jumat.BackColor = Color.Cyan Then
                        Call dajum()


                    End If
                End If
            End If


        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim opfil As New OpenFileDialog()
        opfil.Filter = "File Audio|*.wav|Semua File|*.*"


        If opfil.ShowDialog() = DialogResult.OK Then
            Dim flepat As String = opfil.FileName
            AudTe.Text = flepat
            nafia = opfil.SafeFileName


        End If
    End Sub

    Private Sub Senin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Senin.Click
        If Senin.BackColor = Color.Cyan Then
        Else

            Call saibut()
            Call dase()
            Senin.BackColor = Color.Cyan
        End If
    End Sub

    Private Sub Selasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Selasa.Click
        If Selasa.BackColor = Color.Cyan Then
        Else

            Call saibut()
            Call dasel()
            Selasa.BackColor = Color.Cyan
        End If
    End Sub

    Private Sub Rabu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rabu.Click
        If Rabu.BackColor = Color.Cyan Then
        Else

            Call saibut()
            Call Darab()
            Rabu.BackColor = Color.Cyan
        End If
    End Sub

    Private Sub Kamis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kamis.Click
        If Kamis.BackColor = Color.Cyan Then
        Else

            Call saibut()
            Call Dakam()
            Kamis.BackColor = Color.Cyan
        End If
    End Sub

    Private Sub Jumat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Jumat.Click
        If Jumat.BackColor = Color.Cyan Then
        Else

            Call saibut()
            Call dajum()
            Jumat.BackColor = Color.Cyan
        End If
    End Sub

    Private Sub DelB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelB.Click
        If Hate.Text = "" Or JamLte.Text = "" Or AudTe.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Masukan Data Yang mau di ubah")
        Else
            If MessageBox.Show("Apakah Anda Yakin ingin menghapus Data ini?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call conne()
                Cmd = New OdbcCommand("Delete from tbl_jadwal where Hari='" & Hate.Text & "' and Bagian='" & JamLte.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                Call saisho()

                If Button1.BackColor = Color.Cyan Then
                    Call Datas()
                ElseIf Senin.BackColor = Color.Cyan Then
                    Call dase()
                ElseIf Selasa.BackColor = Color.Cyan Then
                    Call dasel()
                ElseIf Rabu.BackColor = Color.Cyan Then
                    Call Darab()
                ElseIf Kamis.BackColor = Color.Cyan Then
                    Call Dakam()
                ElseIf Jumat.BackColor = Color.Cyan Then
                    Call dajum()


                End If
            Else
                Call saisho()
            End If
        End If

    End Sub

    Private Sub CradPa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Jadpasa.Click
        Dim sen As Panel = DirectCast(sender, Panel)
        Dim va As String = sen.Tag.ToString

        Call conne()
        Cmd = New OdbcCommand("Select * from tbl_jadwal where Kagi='" & va & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Hate.Text = Rd.Item("Hari")
            TextBox1.Text = Rd.Item("Jam").ToString
            JamLte.Text = Rd.Item("Bagian")
            AudTe.Text = Rd.Item("Audio")
            Label6.Text = Rd.Item("Kagi")
            TextBox2.Text = Rd.Item("Kegiatan")
        End If
    End Sub

    Private Sub Upd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Upd.Click
        If Upd.Text = "Update" Then
            Call hira()
            Upd.Text = "Simpan"
          
        Else
            If Hate.Text = "" Or JamLte.Text = "" Or AudTe.Text = "" Or BoxHo.Text = "" Or BoxMin.Text = "" Or BoxSe.Text = "" Then
                MsgBox("Masukan Data Yang mau di ubah")
            Else
                If MessageBox.Show("Apakah Anda Mau Mengubah Dengan Audio Nya juga?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Dim aub As Byte() = File.ReadAllBytes(AudTe.Text)
                    Dim locfi As String = "D:\Resnhu Neord\Bel Sekolah\" + nafia
                    File.WriteAllBytes(locfi, aub)
                    Dim hor As Integer = Integer.Parse(BoxHo.Text)
                    Dim minu As Integer = Integer.Parse(BoxMin.Text)
                    Dim sec As Integer = Integer.Parse(BoxSe.Text)
                    Dim ti As New DateTime(1, 1, 1, hor, minu, sec)
                    Dim tis As String = ti
                    Call conne()
                    Cmd = New OdbcCommand("Update  tbl_jadwal set Hari='" & Hate.Text & "',Jam='" & tis & "',Bagian='" & JamLte.Text & "',Audio='" & "D:\Resnhu Neord\Bel Sekolah\" + nafia & "',Kegiatan='" & TextBox2.Text & "' where Kagi='" & Label6.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call saisho()
                    If Button1.BackColor = Color.Cyan Then
                        Call Datas()
                    ElseIf Senin.BackColor = Color.Cyan Then
                        Call dase()
                    ElseIf Selasa.BackColor = Color.Cyan Then
                        Call dasel()
                    ElseIf Rabu.BackColor = Color.Cyan Then
                        Call Darab()
                    ElseIf Kamis.BackColor = Color.Cyan Then
                        Call Dakam()
                    ElseIf Jumat.BackColor = Color.Cyan Then
                        Call dajum()


                    End If
                   
                Else


                    Dim hor As Integer = Integer.Parse(BoxHo.Text)
                    Dim minu As Integer = Integer.Parse(BoxMin.Text)
                    Dim sec As Integer = Integer.Parse(BoxSe.Text)
                    Dim ti As New DateTime(1, 1, 1, hor, minu, sec)
                    Dim tis As String = ti
                    Call conne()
                    Cmd = New OdbcCommand("Update  tbl_jadwal set Hari='" & Hate.Text & "',Jam='" & tis & "',Bagian='" & JamLte.Text & "',Kegiatan='" & TextBox2.Text & "' where Kagi='" & Label6.Text & "' ", Conn)
                    Cmd.ExecuteNonQuery()
                    Call saisho()
                    If Button1.BackColor = Color.Cyan Then
                        Call Datas()
                    ElseIf Senin.BackColor = Color.Cyan Then
                        Call dase()
                    ElseIf Selasa.BackColor = Color.Cyan Then
                        Call dasel()
                    ElseIf Rabu.BackColor = Color.Cyan Then
                        Call Darab()
                    ElseIf Kamis.BackColor = Color.Cyan Then
                        Call Dakam()
                    ElseIf Jumat.BackColor = Color.Cyan Then
                        Call dajum()


                    End If
                End If
            End If

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.BackColor = Color.Cyan Then
        Else
            Call saibut()
            Call Datas()
            Button1.BackColor = Color.Cyan
        End If
    End Sub
End Class
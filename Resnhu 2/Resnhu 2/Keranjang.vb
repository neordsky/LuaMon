Imports System.IO
Imports System.Data.Odbc
Public Class Keranjang
    Sub saisho()
       
       
        Kerbutt.BackColor = Color.DarkGray
        barbut.BackColor = Color.DarkGray
    End Sub
  
    Sub tot()
        Call Connecti()
        Cmd = New OdbcCommand("Select * from tbl_keranjang", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call Connecti()
            Cmd = New OdbcCommand("Select SUM(Total_Harga) as Total from tbl_keranjang", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                kekka.Text = Rd.Item("Total")

            End If
        Else
            kekka.Text = "..."
        End If

    End Sub
    Sub saish()

        naba.Enabled = False
        jeba.Enabled = False
        haba.Enabled = False
        haba.Text = ""
        jeba.Text = ""
        Kb.Text = ""
        naba.Text = ""
        Quan.Text = ""
        toha.Text = ""
    End Sub
    Public Sub DataKrn()
        ListView1.Items.Clear()

        Dim Items As New List(Of ListViewItem)()
        Call Connecti()
        Cmd = New OdbcCommand("Select * From tbl_keranjang", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Naba As String = Rd.Item("Nama_Barang")
            Dim item As New ListViewItem(Naba)
            item.SubItems.Add(Rd.Item("Kode_Barang"))
            item.SubItems.Add(Rd.Item("Harga_Barang"))
            item.SubItems.Add(Rd.Item("Jumlah_Barang"))

            item.SubItems.Add(Rd.Item("Total_Harga"))
            item.SubItems.Add(Rd.Item("Jenis_Barang"))
            ListView1.Items.Add(item)

        End While

    End Sub
    Sub DataBarang()
        DataBarangPa.Controls.Clear()
        DataBarangPa.AutoScroll = True
        Dim Heip As Integer = 20
        Call Connecti()
        Cmd = New OdbcCommand("Select * from tbl_barang", Conn)
        Rd = Cmd.ExecuteReader
        While Rd.Read
            Dim Pan As New Panel()
            Pan.Size = New Size(900, 70)
            Pan.Location = New Point(0, Heip)
            Pan.BorderStyle = BorderStyle.Fixed3D
            Pan.BackColor = Color.WhiteSmoke
            Pan.Tag = Rd.Item("Kode_Barang")
            AddHandler Pan.Click, AddressOf CardPa_Click
            DataBarangPa.Controls.Add(Pan)

            Dim Pictboc As New PictureBox()
            Pictboc.SizeMode = PictureBoxSizeMode.Zoom
            Pictboc.Size = New Size(100, 60)
            Pictboc.Location = New Point(10, 10)
            Call Connecti()



            Try
                Dim buffersize As Integer = 1024 * 1024
                Dim buffer(buffersize - 1) As Byte
                Dim starind As Long = 0
                Dim ttolbyte As Long = 0
                Dim ms As New MemoryStream()
                Do
                    Dim byteread As Integer = Rd.GetBytes(5, starind, buffer, 0, buffersize)
                    If byteread = 0 Then Exit Do
                    ms.Write(buffer, 0, byteread)
                    ttolbyte += byteread
                    starind += byteread


                Loop While True
                Dim imgdata() As Byte = ms.ToArray()
                Pictboc.Image = Image.FromStream(New MemoryStream(imgdata))
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try






            Pan.Controls.Add(Pictboc)

            Dim Kb As New Label()
            Kb.Size = New Size(50, 50)
            Kb.Location = New Point(114, 30)
            Kb.Font = New Font("Arial", 10, FontStyle.Bold)
            Kb.Text = Rd.Item("Kode_Barang")
            Pan.Controls.Add(Kb)

            Dim Naba As New Label()
            Naba.Size = New Size(100, 50)
            Naba.Location = New Point(265, 30)
            Naba.Font = New Font("Arial", 10, FontStyle.Bold)
            Naba.Text = Rd.Item("Nama_Barang")
            Pan.Controls.Add(Naba)

            Dim Haba As New Label()
            Haba.Size = New Size(100, 50)
            Haba.Location = New Point(436, 30)
            Haba.Font = New Font("Arial", 10, FontStyle.Bold)
            Haba.Text = Rd.Item("Harga_Barang")
            Pan.Controls.Add(Haba)

            Dim Juba As New Label()
            Juba.Size = New Size(100, 50)
            Juba.Location = New Point(617, 30)
            Juba.Font = New Font("Arial", 10, FontStyle.Bold)
            Juba.Text = Rd.Item("Jumlah_Barang")
            Pan.Controls.Add(Juba)
            Dim Jebba As New Label()
            Jebba.Size = New Size(100, 50)
            Jebba.Location = New Point(786, 30)
            Jebba.Font = New Font("Arial", 10, FontStyle.Bold)
            Jebba.Text = Rd.Item("Jenis_Barang")
            Pan.Controls.Add(Jebba)
            Heip += 81


        End While
      
    End Sub

    Private Sub Keranjang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DataBarang()
        Call saisho()
        quanty2.Visible = False

        barbut.BackColor = Color.White
        Call DataKrn()
        Call saish()
        Call tot()
        ListView1.Columns.Add("Nama Barang")
        ListView1.Columns.Add("Kode_Barang")
        ListView1.Columns.Add("Harga Satuan")
        ListView1.Columns.Add("Jumlah")
        ListView1.Columns.Add("Total Harga")
        ListView1.Columns.Add("Jenis Barang")

    End Sub

    Private Sub Keranjang_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub Kerbutt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kerbutt.Click
        If Kerbutt.BackColor = Color.DarkGray Then
            Call saisho()
            Panel6.Visible = True
            Button1.Visible = True
            Button3.Visible = True
            Button4.Visible = True
            DataBarangPa.Visible = False
            Button6.Visible = False
            Button7.Visible = False
            Button8.Visible = False
            TextBox1.Visible = False
            Label2.Visible = False
            quanty2.Visible = True
            Quan.Visible = False

            Kerbutt.BackColor = Color.White
        Else

        End If
    End Sub

    Private Sub barbut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles barbut.Click
        If barbut.BackColor = Color.DarkGray Then
            Call saisho()
            DataBarangPa.Visible = True
            Button6.Visible = True
            Button7.Visible = True
            Button8.Visible = True
            TextBox1.Visible = True
            Label2.Visible = True
            Button1.Visible = False
            Button3.Visible = False
            Button4.Visible = False
            quanty2.Visible = False
            Quan.Visible = True
            barbut.BackColor = Color.White
        Else

        End If
    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TransaksiLanjut.Tot = kekka.Text
        TransaksiLanjut.ShowDialog()
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If MessageBox.Show("Apakah Anda Yakin Hapus Data Pesanan", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Try
                Call Connecti()
                Dim yi As String = "Delete from tbl_keranjang"
                Cmd = New OdbcCommand(yi, Conn)
                Cmd.ExecuteNonQuery()
                Call DataKrn()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            naba.Text = ListView1.SelectedItems(0).SubItems(0).Text
            haba.Text = ListView1.SelectedItems(0).SubItems(2).Text
            kb.Text = ListView1.SelectedItems(0).SubItems(1).Text
            quanty2.Text = ListView1.SelectedItems(0).SubItems(3).Text
            toha.Text = ListView1.SelectedItems(0).SubItems(4).Text
            Jeba.Text = ListView1.SelectedItems(0).SubItems(5).Text
            Call Connecti()
            Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang='" & ListView1.SelectedItems(0).SubItems(1).Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Try
                    Dim img As Byte()
                    img = Rd("Gambar")
                    Dim ms As New MemoryStream(img)
                    PictureBox1.Image = Image.FromStream(ms)
                    PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If


        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Haba.Text = "" Or
       Jeba.Text = "" Or
       Kb.Text = "" Or
       Naba.Text = "" Or
       Quan.Text = "" Then
            MsgBox("lengkapi dulu data")
        Else
            If MessageBox.Show("Apakah Anda Yakin ingin menghapus barang ini dari daftar keranjang?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                Try
                    Call Connecti()
                    Cmd = New OdbcCommand("Delete from tbl_keranjang where Kode_Barang='" & Kb.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call DataKrn()
                    MsgBox("Delete Data  success")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Kb.Text = "" Or Naba.Text = "" Or Jeba.Text = "" Or Haba.Text = "" Or Quan.Text = "" Or toha.Text = "" Then
            MsgBox("Lengkapi Data yang mau di masukan")
        Else
            Dim yi As String
            Dim er As Long
            Call Connecti()
            Cmd = New OdbcCommand("Select * from tbl_keranjang where IdTransaksi in(select max(IdTransaksi) from tbl_keranjang)", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                yi = "T" + "1"
            Else
                er = Microsoft.VisualBasic.Right(Rd.GetString(0), 1) + 1
                yi = "T" + Microsoft.VisualBasic.Right(er, 1)
            End If
            Call Connecti()
            Cmd = New OdbcCommand("Select * from tbl_keranjang where Kode_Barang='" & Kb.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call Connecti()
                Cmd = New OdbcCommand("Update tbl_keranjang set Jumlah_Barang='" & Rd.Item("Jumlah_Barang") + Quan.Text & "',Total_Harga='" & Rd.Item("Total_Harga") + toha.Text & "' where Kode_Barang='" & Kb.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                Call DataKrn()
            Else
                Call Connecti()
                Cmd = New OdbcCommand("Insert into tbl_keranjang set IdTransaksi='" & yi & "',Nama_Barang='" & Naba.Text & "',Harga_Barang='" & Haba.Text & "',Jenis_Barang='" & Jeba.Text & "',Total_Harga='" & Quan.Text * Haba.Text & "',Jumlah_Barang='" & Quan.Text & "',Kode_Barang='" & Kb.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                Call DataKrn()
            End If
           

            Call saisho()



        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
        Else
            Call Connecti()
            Cmd = New OdbcCommand("Select * from tbl_barang where Nama_Barang='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
              
            Else
                MsgBox("Data not found..!")
            End If
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If TextBox1.Text = "" Then
        Else
            Call Connecti()
            Cmd = New OdbcCommand("Select * from tbl_barang where Nama_Barang='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then

            Else
                MsgBox("Data not found..!")
            End If
        End If
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Haba.Text = "" Or
          Jeba.Text = "" Or
          Kb.Text = "" Or
          Naba.Text = "" Or
          Quan.Text = "" Then
            MsgBox("lengkapi dulu data")
        Else
            If MessageBox.Show("Apakah Anda Yakin ingin mengubah barang ini?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Call Connecti()
                    Cmd = New OdbcCommand("Update tbl_keranjang set Jumlah_Barang='" & quanty2.Text & "',Total_Harga='" & toha.Text & "' where Kode_Barang='" & Kb.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call DataKrn()
                    Call saish()
                    MsgBox("Edit Data Keranjang success")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub Quan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Quan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            If Kb.Text = "" Or Naba.Text = "" Or Jeba.Text = "" Or Haba.Text = "" Or Quan.Text = "" Or toha.Text = "" Then
                MsgBox("Lengkapi Data yang mau di masukan")
            Else
                Try
                    Dim yi As String
                    Dim er As Long
                    Call Connecti()
                    Cmd = New OdbcCommand("Select * from tbl_keranjang where IdTransaksi in(select max(IdTransaksi) from tbl_keranjang)", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Not Rd.HasRows Then
                        yi = "T" + "1"
                    Else
                        er = Microsoft.VisualBasic.Right(Rd.GetString(0), 1) + 1
                        yi = "T" + Microsoft.VisualBasic.Right(er, 1)
                    End If
                    Call Connecti()
                    Cmd = New OdbcCommand("Select * from tbl_keranjang where Kode_Barang='" & Kb.Text & "'", Conn)
                    Rd = Cmd.ExecuteReader
                    Rd.Read()
                    If Rd.HasRows Then
                        Call Connecti()
                        Cmd = New OdbcCommand("Update tbl_keranjang set Jumlah_Barang='" & Rd.Item("Jumlah_Barang") + Quan.Text & "',Total_Harga='" & Rd.Item("Total_Harga") + toha.Text & "' where Kode_Barang='" & Kb.Text & "'", Conn)
                        Cmd.ExecuteNonQuery()
                        Call DataKrn()
                    Else
                        Call Connecti()
                        Cmd = New OdbcCommand("Insert into tbl_keranjang set IdTransaksi='" & yi & "',Nama_Barang='" & Naba.Text & "',Harga_Barang='" & Haba.Text & "',Jenis_Barang='" & Jeba.Text & "',Total_Harga='" & Quan.Text * Haba.Text & "',Jumlah_Barang='" & Quan.Text & "',Kode_Barang='" & Kb.Text & "'", Conn)
                        Cmd.ExecuteNonQuery()
                        Call DataKrn()
                    End If


                    Call saisho()

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub Quan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quan.TextChanged
        If Kb.Text = "" Or Naba.Text = "" Or Jeba.Text = "" Or Haba.Text = "" Or Quan.Text = "" Then
        Else
            toha.Text = Quan.Text * Haba.Text
        End If
    End Sub

  

    Private Sub quanty2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles quanty2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            If Haba.Text = "" Or
      Jeba.Text = "" Or
      Kb.Text = "" Or
      Naba.Text = "" Or
      quanty2.Text = "" Then
                MsgBox("lengkapi dulu data")
            Else
                If MessageBox.Show("Apakah Anda Yakin ingin mengubah barang ini?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    Try
                        Call Connecti()
                        Cmd = New OdbcCommand("Update tbl_keranjang set Jumlah_Barang='" & quanty2.Text & "',Total_Harga='" & toha.Text & "' where Kode_Barang='" & Kb.Text & "'", Conn)
                        Cmd.ExecuteNonQuery()
                        Call DataKrn()
                        Call saish()
                        MsgBox("Edit Data Keranjang success")
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If
            End If
        End If
      
    End Sub

    Private Sub quanty2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quanty2.TextChanged
        If Kb.Text = "" Or Naba.Text = "" Or Jeba.Text = "" Or Haba.Text = "" Or quanty2.Text = "" Then
        Else
            toha.Text = quanty2.Text * Haba.Text
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub CardPa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataBarangPa.Click
        Dim cek As Panel = DirectCast(sender, Panel)
        Dim vals As String = cek.Tag.ToString
        Call Connecti()
        Cmd = New OdbcCommand("Select * from tbl_barang where Kode_barang='" & vals & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Kb.Text = Rd.Item("Kode_Barang")
            Naba.Text = Rd.Item("Nama_Barang")
            Haba.Text = Rd.Item("Harga_Barang")
            quanty2.Text = Rd.Item("Jumlah_Barang")
            Jeba.Text = Rd.Item("Jenis_Barang")
            PictureBox1.Image = Nothing
            Try
                Dim img As Byte()
                img = Rd("Gambar")
                Dim ms As New MemoryStream(img)
                PictureBox1.Image = Image.FromStream(ms)
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try
        End If
    End Sub

    Private Sub DataBarangPa_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataBarangPa.Paint

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
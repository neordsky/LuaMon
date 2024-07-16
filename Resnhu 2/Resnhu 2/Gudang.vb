Imports System.IO
Imports System.Data.Odbc

Public Class Gudanga

    Sub saisho()
        Kodb.Enabled = False
        Nabaa.Enabled = False
        Harba.Enabled = False
        Jubba.Enabled = False
        ComboBox1.Enabled = False
        Bat.Enabled = False
        Kodb.Text = ""
        Nabaa.Text = ""
        Harba.Text = ""
        Jubba.Text = ""
        ComboBox1.Text = ""
        Inser.Text = "Insert"
        Delt.Text = "Delete"
        update.Text = "Update"
        Jebba.Text = ""
        Inser.Enabled = True
        update.Enabled = True
        Delt.Enabled = True
        Jebba.Enabled = False
        PictureBox1.Image = Nothing
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Makanan")
        ComboBox1.Items.Add("Minuman")
        ComboBox1.Items.Add("Alat")
        ComboBox1.Items.Add("Barang")
    End Sub

    Sub Hiraku()

        Nabaa.Enabled = True
        Harba.Enabled = True
        Jubba.Enabled = True
        ComboBox1.Enabled = True
        Bat.Enabled = True

    End Sub

    Sub Makanan()
        Dim Yi As String
        Dim Er As Long
        Call Connecti()

        Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang in (select max(Kode_Barang) from tbl_barang where Jenis_Barang='" & "Makanan" & "')", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            Yi = "T" + "001"
        Else
            Er = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            Yi = "T" + Microsoft.VisualBasic.Right("000" + Er, 3)
        End If
        Kodb.Text = Yi
    End Sub
    Sub Minuman()
        Dim Yi As String
        Dim Er As Long
        Call Connecti()

        Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang in (select max(Kode_Barang) from tbl_barang where Jenis_Barang='" & "Minuman" & "')", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            Yi = "N" + "001"
        Else
            Er = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            Yi = "N" + Microsoft.VisualBasic.Right("000" & Er, 3)
        End If
        Kodb.Text = Yi
    End Sub

    Sub Alat()
        Dim Yi As String
        Dim Er As Long
        Call Connecti()

        Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang in (select max(Kode_Barang) from tbl_barang where Jenis_Barang='" & "Alat" & "')", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            Yi = "D" + "001"
        Else
            Er = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            Yi = "D" + Microsoft.VisualBasic.Right("000" & Er, 3)
        End If
        Kodb.Text = Yi
    End Sub
    Sub Baranglain()
        Dim Yi As String
        Dim Er As Long
        Call Connecti()

        Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang in (select max(Kode_Barang) from tbl_barang where Jenis_Barang='" & "Barang" & "')", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            Yi = "M" + "001"
        Else
            Er = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            Yi = "M" + Microsoft.VisualBasic.Right("000" & Er, 3)
        End If
        Kodb.Text = Yi
    End Sub

    Sub DataBara()
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
            Pan.BackColor = Color.WhiteSmoke
            Pan.BorderStyle = BorderStyle.Fixed3D
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
                Dim totalind As Long = 0
                Dim ms As New MemoryStream()
                Do
                    Dim Readbyts As Integer = Rd.GetBytes(5, starind, buffer, 0, buffersize)
                    If Readbyts = 0 Then Exit Do
                    ms.Write(buffer, 0, Readbyts)
                    totalind += Readbyts
                    starind += Readbyts

                Loop While True
                Dim imgdata() As Byte = ms.ToArray
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
            Jubba.Text = Rd.Item("Jumlah_Barang")
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
    Private Sub Gudanga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call DataBara()
        Call saisho()
        Call Connecti()

    End Sub

    Private Sub Gudanga_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TableLayoutPanel1.Size = Me.ClientSize
        TableLayoutPanel2.Size = TableLayoutPanel1.ClientSize

    End Sub

    Private Sub Bat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bat.Click
        Call saisho()
    End Sub

    Private Sub Inser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inser.Click

        If Inser.Text = "Insert" Then
            Call Hiraku()
            update.Enabled = False
            Delt.Enabled = False
            Inser.Text = "Simpan"
            ComboBox1.Visible = True
            Jebba.Visible = False
        Else
            Try
               

                Dim ms As New MemoryStream()
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim img As Byte() = ms.ToArray()
                Call Connecti()

                Dim Ins As String = "INSERT INTO tbl_barang set Kode_Barang='" & Kodb.Text & "',Nama_Barang='" & Nabaa.Text & "',Harga_Barang='" & Harba.Text & "',Gambar=?,Jumlah_Barang='" & Jubba.Text & "',Jenis_Barang='" & ComboBox1.Text & "'"
                Cmd = New OdbcCommand(Ins, Conn)
                Cmd.Parameters.AddWithValue("@gambar", img)
                Call Connecti()
                Cmd.ExecuteNonQuery()
                Call saisho()
                Call DataBara()
                ComboBox1.Visible = False
                Jebba.Visible = True
                MsgBox("Insert Data Succes")

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub

    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles update.Click
        If update.Text = "Update" Then
            Call Hiraku()
            Inser.Enabled = False
            Delt.Enabled = False
            update.Text = "Simpan"

        Else
            Try
                Dim ms As New MemoryStream()
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                Dim img As Byte() = ms.ToArray()
                Call Connecti()

                Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang='" & Kodb.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    If MessageBox.Show("Apakah Anda Yakin Menguba Data Ini?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Call Connecti()
                        Dim Up As String = "Update tbl_barang set Nama_Barang='" & Nabaa.Text & "',Gambar=?,Harga_Barang='" & Harba.Text & "',Jumlah_Barang='" & Jubba.Text & "' where Kode_Barang='" & Kodb.Text & "' "

                        Cmd = New OdbcCommand(Up, Conn)
                        Cmd.Parameters.AddWithValue("@gambar", img)
                        Cmd.ExecuteNonQuery()
                        MsgBox("Update Data Successs")
                        Call saisho()
                        Call DataBara()
                    End If

                End If



            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Delt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Delt.Click
        If Delt.Text = "Delete" Then
            Call Hiraku()
            update.Enabled = False
            Inser.Enabled = False
            Delt.Text = "Simpan"
        Else
            Try
                Call Connecti()

                Cmd = New OdbcCommand("Select * from tbl_barang where Kode_Barang='" & Kodb.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    If MessageBox.Show("Apakah Anda Yakin Menghapus Data Ini?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        Call Connecti()
                        Dim Del As String = "Delete from tbl_barang  where Kode_Barang='" & Kodb.Text & "' "
                        Cmd = New OdbcCommand(Del, Conn)
                        Cmd.ExecuteNonQuery()
                        MsgBox("Update Data Successs")
                        Call saisho()
                        Call DataBara()
                    End If

                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Makanan" Then
            Call Makanan()
        ElseIf ComboBox1.Text = "Minuman" Then
            Call Minuman()
        ElseIf ComboBox1.Text = "Alat" Then
            Call Alat()
        ElseIf ComboBox1.Text = "Barang" Then
            Call Baranglain()
        End If
    End Sub

   

    Private Sub Nabaa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Nabaa.KeyPress
        If e.KeyChar = Chr(13) Then
            If Nabaa.Text = "" Then
                MsgBox("Isi dulu Nama Barang")
            Else
                Harba.Focus()
            End If
        End If
    End Sub

   

   

    Private Sub Harba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Harba.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            If Harba.Text = "" Then
                MsgBox("Isi dulu Harga Barang")
            Else
                Jubba.Focus()
            End If
        End If
    End Sub

  
    Private Sub Jubba_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Jubba.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = Chr(13) Then
            If Jubba.Text = "" Then
                MsgBox("Isi dulu Jumlah Barang")
            Else
                ComboBox1.Focus()
            End If
        End If
    End Sub

  
    Private Sub Harba_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Harba.TextChanged

    End Sub

    Private Sub Jubba_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Jubba.KeyUp

    End Sub

    Private Sub Jubba_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Jubba.TextChanged

    End Sub

   

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

   
   
   
    Private Sub Jebba_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Jebba.TextChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class
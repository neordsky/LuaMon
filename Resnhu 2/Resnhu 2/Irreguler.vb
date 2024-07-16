Imports System.Data.Odbc
Public Class Irreguler
    Sub Datairre()
        Da = New OdbcDataAdapter("Select Id,Username,Alamat,NoTelp from tbl_irreguler", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_irreguler")
        DataGridView1.DataSource = Ds.Tables("tbl_irreguler")
        DataGridView1.ReadOnly = True
        DataGridView1.Columns(0).Width = 150
        DataGridView1.Columns(1).Width = 250
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 200

    End Sub

    Sub Saishojo()
        Almt.Enabled = False
        ComboBox1.Enabled = False
        Userna.Enabled = False
        Ntelp.Enabled = False
        Idu.Enabled = False
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Pegawai")
        ComboBox1.Items.Add("Kasir")
        ComboBox1.Items.Add("Admin")
    End Sub

    Private Sub Irreguler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Datairre()
        Call Saishojo()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ComboBox1.Enabled = False
        Idu.Text = ""
        Userna.Text = ""
        Almt.Text = ""
        ComboBox1.Text = ""
        Ntelp.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Idu.Text = "" Or
            Userna.Text = "" Or
            Almt.Text = "" Or
            ComboBox1.Text = "" Or
            Ntelp.Text = "" Then
            MsgBox("Lengkapi dulu data yang mau di edit")
        Else

            If MessageBox.Show("Apakah Anda Yakin Mendaftarkan Account  dengan Username='" & Userna.Text & "'Tersebut Sebagai Reguler?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim nawa As String
                Dim ne As Long
                Call Connecti()
                Cmd = New OdbcCommand("Select * from tbl_users where Id in(Select max(Id) from tbl_users)", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Not Rd.HasRows Then
                    nawa = "P" + "001"
                Else
                    ne = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
                    nawa = "P" + Microsoft.VisualBasic.Right("000" & ne, 3)
                End If
                Call Connecti()
                Cmd = New OdbcCommand("Select * from tbl_irreguler where Username='" & Userna.Text & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                If Rd.HasRows Then
                    Call Connecti()
                    Cmd = New OdbcCommand("Insert into tbl_users set Id='" & nawa & "',Username='" & Userna.Text & "',Password='" & Rd.Item("Password") & "',Alamat='" & Almt.Text & "',Level='" & ComboBox1.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call Connecti()
                    Cmd = New OdbcCommand("Delete from tbl_irreguler where Username='" & Userna.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call Datairre()
                    Call Saishojo()
                    MsgBox("Users Berhasil Terdaftarkan sebagai Reguler")
                Else

                End If

            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Idu.Text = "" Or
          Userna.Text = "" Or
          Almt.Text = "" Or
          Ntelp.Text = "" Then
            MsgBox("Lengkapi dulu data yang mau di edit")
        Else

            If MessageBox.Show("Apakah Anda Yakin ingin menghapus Users Irreguler dengan Username='" & Userna.Text & "' Ini?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Call Connecti()
                Cmd = New OdbcCommand("Delete from tbl_irreguler where Username='" & Userna.Text & "'", Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Hapus Data Success")
                Call Saishojo()
                Call Datairre()
            End If

        End If
    End Sub

    Private Sub DataGridView1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim an As Integer
        an = DataGridView1.CurrentRow.Index
        Idu.Text = DataGridView1.Item(0, an).Value
        Userna.Text = DataGridView1.Item(1, an).Value

        Almt.Text = DataGridView1.Item(2, an).Value
        Ntelp.Text = DataGridView1.Item(3, an).Value
        ComboBox1.Enabled = True
    End Sub

   
End Class
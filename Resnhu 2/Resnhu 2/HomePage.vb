Imports System.Data.Odbc
Public Class HomePage

    Dim Kai As Integer = 0
    Sub saisho()
        Dim Markt As New Market()
       
        Navi.Controls.Remove(Markt)
        Markt.Dispose()
        Dim Krn As New Keranjang()
        
        Navi.Controls.Remove(Krn)
        Krn.Dispose()
        Dim Bar As New Gudanga()
       
        Navi.Controls.Remove(Bar)
        Bar.Dispose()
        Dim lap As New laporan()


        Navi.Controls.Remove(lap)
        lap.Dispose()
        Dim Glo As New Glob()
        Navi.Controls.Remove(Glo)
    
        Glo.Dispose()
        Dim loac As New LogActivity()
        Navi.Controls.Remove(loac)
        loac.Dispose()
        Navi.Controls.Clear()
        Mark.BackColor = Color.DarkGray
        Krn.BackColor = Color.DarkGray

        Gudang.BackColor = Color.DarkGray
        Lapora.BackColor = Color.DarkGray
        Glob.BackColor = Color.DarkGray

    End Sub
    Sub Marke()
        Dim Markt As New Market()
        Markt.TopLevel = False
        Markt.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Markt.Dock = DockStyle.Fill
        Navi.Controls.Add(Markt)
        Markt.Show()

    End Sub

    Sub Keranjag()
        Dim Krn As New Keranjang()
        Krn.TopLevel = False
        Krn.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Krn.Dock = DockStyle.Fill
        Navi.Controls.Add(Krn)
        Krn.Show()
    End Sub
    Sub Globa()
        Dim Glo As New Adminis()
        Glo.TopLevel = False
        Glo.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Glo.Dock = DockStyle.Fill
        Navi.Controls.Add(Glo)
        Glo.Show()
    End Sub
    Sub Barag()
        Dim Bar As New Gudanga()
        Bar.TopLevel = False
        Bar.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Bar.Dock = DockStyle.Fill
        Navi.Controls.Add(Bar)
        Bar.Show()
    End Sub

    Sub Laporn()
        Dim lap As New laporan()
        lap.TopLevel = False
        lap.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        lap.Dock = DockStyle.Fill
        Navi.Controls.Add(lap)
        lap.Show()
    End Sub
   


    Public Property lev As String
    Public Property nama As String
    Public Property id As String
    Public Property Alamt As String
    Public Property notel As String
    Public Property pass As String

    Private Sub HomePage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lev = "Pegawai" Then
            Krn.Visible = False
            Glob.Visible = False
        ElseIf lev = "Admin" Then
            Krn.Visible = True
            Glob.Visible = True
            Gudang.Visible = True
            Mark.Visible = True
            Lapora.Visible = True

        ElseIf lev = "Kasir" Then
            Glob.Visible = False
            Gudang.Visible = False


        End If
        Call saisho()
        Call Marke()
        Mark.BackColor = Color.Wheat
        Krn.BackColor = Color.DarkGray
    End Sub

    
    

    Private Sub Mark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mark.Click
        If Mark.BackColor = Color.Wheat Then
        Else
            Call saisho()
            Call Marke()
            Mark.BackColor = Color.Wheat
            Krn.BackColor = Color.DarkGray
            Label1.Text = "HomePage"

        End If

    End Sub

    Private Sub HomePage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TableLayoutPanel1.Size = Me.ClientSize
        TableLayoutPanel2.Size = Panel2.ClientSize

    End Sub

    Private Sub Gudang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gudang.Click
        If Gudang.BackColor = Color.Wheat Then
        Else
            Call saisho()
            Call Barag()
            Gudang.BackColor = Color.Cyan
            Krn.BackColor = Color.DarkGray
            Label1.Text = "Gudang"
        End If

    End Sub

    Private Sub Lapora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lapora.Click
        If Lapora.BackColor = Color.Wheat Then
        Else
            Call saisho()
            Call Laporn()
            Lapora.BackColor = Color.PaleVioletRed
            Krn.BackColor = Color.DarkGray
            Label1.Text = "Laporan"

        End If
       

    End Sub

   

    Private Sub Glob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Glob.Click
        If Glob.BackColor = Color.Wheat Then
        Else
            Call saisho()
            Call Globa()
            Glob.BackColor = Color.Violet
            Krn.BackColor = Color.DarkGray
            Label1.Text = "Global"
        End If
    End Sub

    Private Sub Krn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Krn.Click
        If Krn.BackColor = Color.DarkGray Then
            Call saisho()
            Call Keranjag()
            Krn.BackColor = Color.LightYellow
            Label1.Text = "Kasir"
        Else

        End If
           
    End Sub

   
  
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MessageBox.Show("Apakah Anda Yakin ingin log out?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Call Connecti()
            Cmd = New OdbcCommand("Select * from tbl_users where Id='" & id & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call Connecti()
                Cmd = New OdbcCommand("Update tbl_users set Riwayat='" & "Offline" & "' where Id='" & id & "'", Conn)
                Cmd.ExecuteNonQuery()

            End If
            Dim tgl As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            Dim tgli As String = DateTime.Now.ToString("yyyy-MM-dd")
            Call Connecti()
            Cmd = New OdbcCommand("Select * from log_acti where Id='" & id & "' and Waktu Like'%" & tgli & "%'  ", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Call Connecti()
                Cmd = New OdbcCommand("Update log_acti set Waktu='" & tgl & "' where Id='" & id & "' and Aktivitas='" & "Offline" & "'", Conn)
                Cmd.ExecuteNonQuery()
                Me.Close()
                LoginPage.Visible = True
                LoginPage.Show()

            Else

                Call Connecti()
                Cmd = New OdbcCommand("Insert Into log_acti set Aktivitas='" & "Offline" & "',Waktu='" & tgl & "',Username='" & nama & "',Id='" & id & "'", Conn)
                Cmd.ExecuteNonQuery()
                Me.Close()
                LoginPage.Visible = True
                LoginPage.Show()
            End If
        Else

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        gantipas.ShowDialog()
    End Sub
End Class
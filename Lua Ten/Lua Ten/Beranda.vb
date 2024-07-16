Public Class Beranda


    Sub Data()
        Dim Xp As Integer = 12
        Dim Yp As Integer = 51


        Dim car As New Panel()
        car.Size = New Size(130, 136)
        car.Location = New Point(Xp, Yp)
        car.BorderStyle = BorderStyle.Fixed3D
        car.BackColor = Color.DarkBlue
        Panel4.Controls.Add(car)

        Dim pic As New PictureBox()
        pic.Size = New Size(124, 87)
        pic.Location = New Point(3, 3)
        pic.Image = Image.FromFile("D:\Resnhu Neord\Market\gam2.jpg")
        pic.SizeMode = PictureBoxSizeMode.Zoom
        car.Controls.Add(pic)

        Dim la1 As New Label()
        la1.Size = New Size(39, 17)
        la1.Location = New Point(14, 93)
        la1.ForeColor = Color.White
        la1.Text = "New Pro"
        car.Controls.Add(la1)

        Dim la2 As New Label()
        la2.Size = New Size(39, 17)
        la2.Location = New Point(74, 114)
        la2.ForeColor = Color.White
        la2.Text = "Lua Xin"
        car.Controls.Add(la2)

      

    End Sub

    Private Sub Beranda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Data()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
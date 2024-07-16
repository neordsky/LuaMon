Public Class Form1
    Dim heigp As Integer = 50
    Dim widp As Integer = 20
    Sub Cardas()
        For yi As Integer = 0 To 5
            Dim P1 As New Panel()
            P1.Size = New Size(100, 150)
            P1.Location = New Point(20, heigp)

            Panel1.Controls.Add(P1)
            Dim Im1 As New PictureBox()
            Im1.SizeMode = PictureBoxSizeMode.StretchImage
            Im1.Image = Image.FromFile("gam3.jpg")
            Im1.Size = New Size(100, 100)
            Im1.Location = New Point(0, 0)
            P1.Controls.Add(Im1)
            widp += 125
        Next


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Cardas()
    End Sub
End Class

Public Class Form1


    Sub Beranda()
        Dim Ber As New Beranda()
        Ber.TopLevel = False
        Ber.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Ber.Dock = DockStyle.Fill
        Ber.Show()
        Panel2.Controls.Add(Ber)

    End Sub


    Sub Favorite()
        Dim Fav As New Favorite()
        Fav.TopLevel = False
        Fav.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Fav.Dock = DockStyle.Fill
        Fav.Show()
        Panel2.Controls.Add(Fav)
    End Sub

    Sub saish()
        Dim Fav As New Favorite()
        Fav.Dispose()
        Panel2.Controls.Remove(Fav)
        Dim Ber As New Beranda()
        Ber.Dispose()
        Panel2.Controls.Remove(Ber)
        Panel2.Controls.Clear()
        Label1.ForeColor = Color.White
        Label2.ForeColor = Color.White
        For Each lb As Label In Me.Controls.OfType(Of Label)()
            lb.Size = New Size(77, 24)

        Next
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call saish()
        Call Beranda()
        Label1.ForeColor = Color.Yellow

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If Label1.ForeColor = Color.Yellow Then
        Else
            Call saish()
            Call Beranda()
            Label1.ForeColor = Color.Yellow
            Label1.Size = New Size(85, 30)
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        If Label2.ForeColor = Color.Yellow Then
        Else
            Call saish()
            Call Favorite()
            Label2.ForeColor = Color.Yellow
            Label2.Size = New Size(85, 30)
        End If
    End Sub
End Class

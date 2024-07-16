Public Class NavigasiFor
    Sub Jad()
        Panel1.Controls.Clear()
        Dim Jadfo As New Form1()
        Jadfo.TopLevel = False
        Jadfo.Dock = DockStyle.Fill
        Jadfo.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Jadfo.Show()
        Panel1.Controls.Add(Jadfo)
        Button1.BackColor = Color.White

    End Sub
    Sub Edjad()
        Panel1.Controls.Clear()
        Dim edja As New Edit_Jadwa_l()
        edja.Dock = DockStyle.Fill
        edja.TopLevel = False
        edja.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        edja.Show()
        Panel1.Controls.Add(edja)
        Button2.BackColor = Color.White

    End Sub
    Private Sub NavigasiFor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Jad()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.BackColor = Color.Azure Then
            Button1.BackColor = Color.Azure
            Button2.BackColor = Color.AliceBlue
            Call Edjad()
        Else

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.BackColor = Color.Azure Then
            Button1.BackColor = Color.AliceBlue
            Button2.BackColor = Color.Azure
            Call Jad()
        Else

        End If
    End Sub
End Class
Public Class Adminis


    Sub saihsojo()
        Dim kel As New Glob()
        Panel1.Controls.Remove(kel)
        kel.Dispose()
        Dim lot As New LogActivity()
        Panel1.Controls.Remove(lot)
        lot.Dispose()
        Dim rei As New Irreguler()
        Panel1.Controls.Remove(rei)
        rei.Dispose()
        Panel1.Controls.Clear()

        kelbut.BackColor = Color.DarkGray
        irrebut.BackColor = Color.DarkGray
        logbut.BackColor = Color.DarkGray

    End Sub

    Sub KelolaUser()
        Dim Kelu As New Glob()
        Kelu.TopLevel = False
        Kelu.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Kelu.Dock = DockStyle.Fill
        Panel1.Controls.Add(Kelu)
        Kelu.Show()
    End Sub
    Sub Logac()
        Dim loc As New LogActivity()
        loc.TopLevel = False
        loc.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        loc.Dock = DockStyle.Fill
        Panel1.Controls.Add(loc)
        loc.Show()
    End Sub

    Sub Irreg()
        Dim ir As New Irreguler()
        ir.TopLevel = False
        ir.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        ir.Dock = DockStyle.Fill
        Panel1.Controls.Add(ir)
        ir.Show()
    End Sub


    Private Sub Adminis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call saihsojo()
        Call Logac()
        logbut.BackColor = Color.White
    End Sub

    Private Sub irrebut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles irrebut.Click
        If irrebut.BackColor = Color.DarkGray Then
            Call saihsojo()
            Call Irreg()
            irrebut.BackColor = Color.White
        Else

        End If
    End Sub

    Private Sub kelbut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kelbut.Click
        If kelbut.BackColor = Color.DarkGray Then
            Call saihsojo()
            Call KelolaUser()
            kelbut.BackColor = Color.White
        Else

        End If
    End Sub

    Private Sub logbut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logbut.Click
        If logbut.BackColor = Color.DarkGray Then
            Call saihsojo()
            Call Logac()
            logbut.BackColor = Color.White
        Else

        End If
    End Sub
End Class
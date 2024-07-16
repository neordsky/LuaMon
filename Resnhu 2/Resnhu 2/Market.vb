Public Class Market
    Public Property Id As String
    Public Property User As String
    Public Property Lvl As String
    Public Almt As String
    Private Sub Market_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Userl.Text = HomePage.nama
        Idl.Text = HomePage.id
        Alml.Text = HomePage.Alamt
        Levl.Text = HomePage.lev
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub Market_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TableLayoutPanel1.Size = Me.ClientSize
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Levl.Click

    End Sub
End Class
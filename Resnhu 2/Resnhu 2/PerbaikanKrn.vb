Imports System.Data.Odbc
Public Class PerbaikanKrn
    Public Property Nab As String
    Public Property harb As String
    Public Property Jumb As Integer
  
    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kb.TextChanged

    End Sub

   
    

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If haba.Text = "" Or
         jeba.Text = "" Or
         kb.Text = "" Or
         naba.Text = "" Or
         quant.Text = "" Then
            MsgBox("lengkapi dulu data")
        Else
            If MessageBox.Show("Apakah Anda Yakin ingin menghapus barang ini dari daftar keranjang?", "info", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                Try
                    Call Connecti()
                    Cmd = New OdbcCommand("Delete from tbl_keranjang where Kode_Barang='" & kb.Text & "'", Conn)
                    Cmd.ExecuteNonQuery()
                    Call Keranjang.DataKrn()
                    Keranjang.Refresh()
                    MsgBox("Delete Data  success")
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class
Imports System.Data.Odbc
Module Module1
    Public Conn As New OdbcConnection("DSN=Shibai")
    Public Cmd As OdbcCommand
    Public Rd As OdbcDataReader
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public Mydb As String
    Public Sub Connecti()
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Module

Imports System.Data.Odbc
Module Module1
    Public Conn As New OdbcConnection("DSN=Bel")
    Public Rd As OdbcDataReader
    Public Ds As DataSet
    Public Da As OdbcDataAdapter
    Public Cmd As OdbcCommand
    Public Sub conne()
        Try
            If Conn.State = ConnectionState.Closed Then Conn.Open()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub


End Module

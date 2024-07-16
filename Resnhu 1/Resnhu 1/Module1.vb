Imports System.Data.Odbc
Module Module1
    Public Conn As New OdbcConnection
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public Rd As OdbcDataReader
    Public Cmd As OdbcCommand
    Public MYsub As String

    Public Sub connect()
        MYsub = "Driver={MySQL ODBC 3.51 Driver};database=db_mise;server=localhost;uid=root"
        Conn = New OdbcConnection(MYsub)
        If Conn.State = ConnectionState.Closed Then Conn.Open()





    End Sub

End Module

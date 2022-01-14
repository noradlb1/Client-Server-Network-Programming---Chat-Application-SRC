Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class TCPControl
    Public Event MessageReceived(sender As TCPControl, Data As String)

    ' SERVER CONFIG
    Public ServerIP As IPAddress = IPAddress.Parse("10.0.0.253")
    Public ServerPort As Integer = 64555
    Public Server As TcpListener

    Private CommThread As Thread
    Public IsListening As Boolean = True

    ' CLIENTS
    Private Client As TcpClient
    Private ClientData As StreamReader

    Public Sub New()
        Server = New TcpListener(ServerIP, ServerPort)
        Server.Start()

        CommThread = New Thread(New ThreadStart(AddressOf Listening))
        CommThread.Start()
    End Sub

    Private Sub Listening()
        ' CREATE LISTENER LOOP
        Do Until IsListening = False
            ' ACCEPT INCOMING CONNECTIONS
            If Server.Pending = True Then
                Client = Server.AcceptTcpClient
                ClientData = New StreamReader(Client.GetStream)

            End If

            ' RAISE EVENT FOR INCOMING MESSAGES
            Try
                RaiseEvent MessageReceived(Me, ClientData.ReadLine)
            Catch ex As Exception

            End Try

            ' REDUCE CPU USAGE
            'Thread.Sleep(100)
        Loop
    End Sub
End Class

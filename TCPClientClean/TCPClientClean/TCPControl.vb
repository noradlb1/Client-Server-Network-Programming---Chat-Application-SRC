Imports System.Net
Imports System.Net.Sockets
Imports System.IO

Public Class TCPControl
    Public Client As TcpClient
    Public DataStream As StreamWriter

    Public Sub New(Host As String, Port As Integer)
        ' CLIENT
        Client = New TcpClient(Host, Port)
        DataStream = New StreamWriter(Client.GetStream)
    End Sub

    Public Sub Send(Data As String)
        DataStream.Write(Data & vbCrLf)
        DataStream.Flush()
    End Sub
End Class

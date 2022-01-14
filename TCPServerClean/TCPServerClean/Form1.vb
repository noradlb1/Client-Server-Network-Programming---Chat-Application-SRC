Public Class Form1
    Private Server As TCPControl

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Server.IsListening = False
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Server = New TCPControl
        txtChat.Text = ":: SERVER STARTED ::" & vbCrLf

        AddHandler Server.MessageReceived, AddressOf OnLineReceived
    End Sub

    ' ALLOW THREAD TO COMMUNICATE WITH FORM CONTROL
    Private Delegate Sub UpdateTextDelegate(TB As TextBox, txt As String)

    ' UPDATE TEXTBOX
    Private Sub UpdateText(TB As TextBox, txt As String)
        If TB.InvokeRequired Then
            TB.Invoke(New UpdateTextDelegate(AddressOf UpdateText), New Object() {TB, txt})
        Else
            If txt IsNot Nothing Then TB.AppendText(txt & vbCrLf)
        End If
    End Sub

    ' UPDATE TEXT WHEN DATA IS RECEIVED
    Private Sub OnLineReceived(sender As TCPControl, Data As String)
        UpdateText(txtChat, Data)
    End Sub
End Class

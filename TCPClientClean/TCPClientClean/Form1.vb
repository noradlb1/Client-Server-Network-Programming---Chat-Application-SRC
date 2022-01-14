Public Class Form1
    Private Client As TCPControl

    Private Sub cmdSend_Click(sender As System.Object, e As System.EventArgs) Handles cmdSend.Click
        SendMessage()
        txtMessage.Clear()
        txtMessage.Focus()
    End Sub

    Private Sub cmdConnect_Click(sender As System.Object, e As System.EventArgs) Handles cmdConnect.Click
        Client = New TCPControl("10.0.0.253", 64555)
        If Client.Client.Connected Then cmdConnect.Text = "Connected"
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Client.Client.Connected = True Then
            Client.DataStream.Close()
            Client.Client.Close()
        End If
    End Sub

    Private Sub txtMessage_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtMessage.KeyDown
        If e.KeyCode = Keys.Enter Then SendMessage()
    End Sub

    Private Sub SendMessage()
        If Client.Client.Connected = True Then Client.Send(txtMessage.Text)
    End Sub
End Class

Public Class Form3

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        Application.Exit()
    End Sub

    Private Sub updater_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updater.Tick
        If Form1.winner = 1 Then
            lblPlayerWin.Text = "1"
        ElseIf Form1.winner = 2 Then
            lblPlayerWin.Text = "2"
        End If
    End Sub
End Class
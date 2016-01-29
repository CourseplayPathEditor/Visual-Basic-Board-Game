Public Class Form2
    Public done As Boolean = False
    Private Sub btnRoll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoll.Click
        If done = False Then
            Randomize()
            lblrolltotal.Text = Math.Floor(Rnd() * 11)

            If Form1.turn = 1 Then
                Form1.RedUnitHealth(Form1.attacktrack) -= Val(lblrolltotal.Text)
                For j = 0 To 49
                    If Form1.blueselect(j) = True Then
                        Form1.BlueUnitDone(j) = True
                    End If
                Next
            End If
            If Form1.turn = 2 Then
                Form1.BlueUnitHealth(Form1.attacktrack) -= Val(lblrolltotal.Text)
                For j = 0 To 49
                    If Form1.RedSelect(j) = True Then
                        Form1.RedUnitDone(j) = True
                    End If
                Next
            End If
            done = True
        End If
        If Form1.turn = 1 Then
            lblRedUnitHealth.Text = Form1.RedUnitHealth(Form1.attacktrack)
            lblBlueUnitHealth.Text = Form1.BlueUnitHealth(Form1.selecttrack)
        End If
        If Form1.turn = 2 Then
            lblBlueUnitHealth.Text = Form1.BlueUnitHealth(Form1.attacktrack)
            lblRedUnitHealth.Text = Form1.RedUnitHealth(Form1.selecttrack)
        End If
    End Sub
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        For j = 0 To 49
            Form1.blueattack(j) = False
            Form1.redattack(j) = False
        Next
        lblrolltotal.Text = "  "
        lblRedUnitHealth.Text = "  "
        lblBlueUnitHealth.Text = "  "
        Form1.good = True
        Me.Hide()
        Form1.Show()
    End Sub
End Class
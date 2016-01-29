Public Class hexpicbox
    Inherits PictureBox

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        SetRegion()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub SetRegion()
        Dim p(5) As Point
        Dim v As Integer = CInt(Me.Width / 2 * Math.Sin(30 * Math.PI / 180))
        p(0) = New Point(Me.Width \ 2, 0)
        p(1) = New Point(Me.Width, v)
        p(2) = New Point(Me.Width, Me.Height - v)
        p(3) = New Point(Me.Width \ 2, Me.Height)
        p(4) = New Point(0, Me.Height - v)
        p(5) = New Point(0, v)
        Using gp As New Drawing2D.GraphicsPath
            gp.AddPolygon(p)
            Me.Region = New Region(gp)
        End Using
    End Sub

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblPlayer = New System.Windows.Forms.Label()
        Me.lblPlayerWin = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.updater = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblPlayer
        '
        Me.lblPlayer.AutoSize = True
        Me.lblPlayer.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayer.Location = New System.Drawing.Point(56, 64)
        Me.lblPlayer.Name = "lblPlayer"
        Me.lblPlayer.Size = New System.Drawing.Size(160, 55)
        Me.lblPlayer.TabIndex = 0
        Me.lblPlayer.Text = "Player"
        '
        'lblPlayerWin
        '
        Me.lblPlayerWin.AutoSize = True
        Me.lblPlayerWin.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlayerWin.Location = New System.Drawing.Point(112, 190)
        Me.lblPlayerWin.Name = "lblPlayerWin"
        Me.lblPlayerWin.Size = New System.Drawing.Size(44, 39)
        Me.lblPlayerWin.TabIndex = 1
        Me.lblPlayerWin.Text = "   "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(62, 294)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 55)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Wins!"
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(99, 376)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 3
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'updater
        '
        Me.updater.Enabled = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.stratagyboardgame.My.Resources.Resources.winnerseen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(284, 424)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblPlayerWin)
        Me.Controls.Add(Me.lblPlayer)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trojan Wars-WinnerScreen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPlayer As System.Windows.Forms.Label
    Friend WithEvents lblPlayerWin As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnQuit As System.Windows.Forms.Button
    Friend WithEvents updater As System.Windows.Forms.Timer
End Class

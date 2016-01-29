<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnRoll = New System.Windows.Forms.Button()
        Me.lblrolltotal = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblRedUnitHealth = New System.Windows.Forms.Label()
        Me.lblBlueUnitHealth = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.stratagyboardgame.My.Resources.Resources.redSoldier_MS2M
        Me.PictureBox1.Location = New System.Drawing.Point(141, 284)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 50)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.stratagyboardgame.My.Resources.Resources.Soldier_MS2M
        Me.PictureBox2.Location = New System.Drawing.Point(561, 276)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(67, 58)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'btnRoll
        '
        Me.btnRoll.Location = New System.Drawing.Point(231, 44)
        Me.btnRoll.Name = "btnRoll"
        Me.btnRoll.Size = New System.Drawing.Size(300, 106)
        Me.btnRoll.TabIndex = 2
        Me.btnRoll.Text = "Roll"
        Me.btnRoll.UseVisualStyleBackColor = True
        '
        'lblrolltotal
        '
        Me.lblrolltotal.AutoSize = True
        Me.lblrolltotal.Font = New System.Drawing.Font("Modern No. 20", 71.99999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblrolltotal.Location = New System.Drawing.Point(322, 256)
        Me.lblrolltotal.Name = "lblrolltotal"
        Me.lblrolltotal.Size = New System.Drawing.Size(114, 98)
        Me.lblrolltotal.TabIndex = 3
        Me.lblrolltotal.Text = "   "
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(269, 517)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(229, 51)
        Me.btnBack.TabIndex = 4
        Me.btnBack.Text = "Return To Battle"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblRedUnitHealth
        '
        Me.lblRedUnitHealth.AutoSize = True
        Me.lblRedUnitHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRedUnitHealth.Location = New System.Drawing.Point(153, 244)
        Me.lblRedUnitHealth.Name = "lblRedUnitHealth"
        Me.lblRedUnitHealth.Size = New System.Drawing.Size(24, 25)
        Me.lblRedUnitHealth.TabIndex = 5
        Me.lblRedUnitHealth.Text = "  "
        '
        'lblBlueUnitHealth
        '
        Me.lblBlueUnitHealth.AutoSize = True
        Me.lblBlueUnitHealth.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlueUnitHealth.Location = New System.Drawing.Point(579, 235)
        Me.lblBlueUnitHealth.Name = "lblBlueUnitHealth"
        Me.lblBlueUnitHealth.Size = New System.Drawing.Size(24, 25)
        Me.lblBlueUnitHealth.TabIndex = 6
        Me.lblBlueUnitHealth.Text = "  "
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.stratagyboardgame.My.Resources.Resources.BattleScreenBackground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(785, 611)
        Me.Controls.Add(Me.lblBlueUnitHealth)
        Me.Controls.Add(Me.lblRedUnitHealth)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblrolltotal)
        Me.Controls.Add(Me.btnRoll)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.Name = "Form2"
        Me.Text = "Trojan Wars-BattleScreen"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnRoll As System.Windows.Forms.Button
    Friend WithEvents lblrolltotal As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblRedUnitHealth As System.Windows.Forms.Label
    Friend WithEvents lblBlueUnitHealth As System.Windows.Forms.Label
End Class

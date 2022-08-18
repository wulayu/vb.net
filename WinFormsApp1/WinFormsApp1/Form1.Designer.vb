<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Up = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Down = New System.Windows.Forms.Button()
        Me.Left = New System.Windows.Forms.Button()
        Me.Right = New System.Windows.Forms.Button()
        Me.Reset = New System.Windows.Forms.Button()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ZoomIn = New System.Windows.Forms.Button()
        Me.ZoomOut = New System.Windows.Forms.Button()
        Me.Label_Longitude = New System.Windows.Forms.Label()
        Me.Label_ContextLongitude = New System.Windows.Forms.Label()
        Me.Label_Latitude = New System.Windows.Forms.Label()
        Me.Label_ContextLatitude = New System.Windows.Forms.Label()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Up
        '
        Me.Up.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Up.Location = New System.Drawing.Point(950, 171)
        Me.Up.Name = "Up"
        Me.Up.Size = New System.Drawing.Size(80, 45)
        Me.Up.TabIndex = 1
        Me.Up.Text = "Up"
        Me.Up.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(956, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Move :"
        '
        'Down
        '
        Me.Down.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Down.Location = New System.Drawing.Point(1045, 171)
        Me.Down.Name = "Down"
        Me.Down.Size = New System.Drawing.Size(80, 45)
        Me.Down.TabIndex = 3
        Me.Down.Text = "Down"
        Me.Down.UseVisualStyleBackColor = True
        '
        'Left
        '
        Me.Left.Location = New System.Drawing.Point(950, 225)
        Me.Left.Name = "Left"
        Me.Left.Size = New System.Drawing.Size(80, 45)
        Me.Left.TabIndex = 4
        Me.Left.Text = "Left"
        Me.Left.UseVisualStyleBackColor = True
        '
        'Right
        '
        Me.Right.Location = New System.Drawing.Point(1045, 225)
        Me.Right.Name = "Right"
        Me.Right.Size = New System.Drawing.Size(80, 45)
        Me.Right.TabIndex = 5
        Me.Right.Text = "Right"
        Me.Right.UseVisualStyleBackColor = True
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(950, 275)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(175, 42)
        Me.Reset.TabIndex = 6
        Me.Reset.Text = "Reset"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'PictureBox
        '
        Me.PictureBox.Location = New System.Drawing.Point(34, 67)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(901, 450)
        Me.PictureBox.TabIndex = 7
        Me.PictureBox.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(34, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(197, 31)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "My World Map"
        '
        'ZoomIn
        '
        Me.ZoomIn.Location = New System.Drawing.Point(950, 399)
        Me.ZoomIn.Name = "ZoomIn"
        Me.ZoomIn.Size = New System.Drawing.Size(175, 42)
        Me.ZoomIn.TabIndex = 9
        Me.ZoomIn.Text = "ZoomIn"
        Me.ZoomIn.UseVisualStyleBackColor = True
        '
        'ZoomOut
        '
        Me.ZoomOut.Location = New System.Drawing.Point(950, 447)
        Me.ZoomOut.Name = "ZoomOut"
        Me.ZoomOut.Size = New System.Drawing.Size(175, 42)
        Me.ZoomOut.TabIndex = 10
        Me.ZoomOut.Text = "ZoomOut"
        Me.ZoomOut.UseVisualStyleBackColor = True
        '
        'Label_Longitude
        '
        Me.Label_Longitude.AutoSize = True
        Me.Label_Longitude.Location = New System.Drawing.Point(34, 570)
        Me.Label_Longitude.Name = "Label_Longitude"
        Me.Label_Longitude.Size = New System.Drawing.Size(107, 24)
        Me.Label_Longitude.TabIndex = 12
        Me.Label_Longitude.Text = "Longitude :"
        '
        'Label_ContextLongitude
        '
        Me.Label_ContextLongitude.AutoSize = True
        Me.Label_ContextLongitude.Location = New System.Drawing.Point(147, 570)
        Me.Label_ContextLongitude.Name = "Label_ContextLongitude"
        Me.Label_ContextLongitude.Size = New System.Drawing.Size(298, 24)
        Me.Label_ContextLongitude.TabIndex = 13
        Me.Label_ContextLongitude.Text = "请将鼠标悬浮于显示框中以查看经度"
        '
        'Label_Latitude
        '
        Me.Label_Latitude.AutoSize = True
        Me.Label_Latitude.Location = New System.Drawing.Point(492, 570)
        Me.Label_Latitude.Name = "Label_Latitude"
        Me.Label_Latitude.Size = New System.Drawing.Size(90, 24)
        Me.Label_Latitude.TabIndex = 14
        Me.Label_Latitude.Text = "Latitude :"
        '
        'Label_ContextLatitude
        '
        Me.Label_ContextLatitude.AutoSize = True
        Me.Label_ContextLatitude.Location = New System.Drawing.Point(597, 572)
        Me.Label_ContextLatitude.Name = "Label_ContextLatitude"
        Me.Label_ContextLatitude.Size = New System.Drawing.Size(298, 24)
        Me.Label_ContextLatitude.TabIndex = 15
        Me.Label_ContextLatitude.Text = "请将鼠标悬浮于显示框中以查看纬度"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1178, 644)
        Me.Controls.Add(Me.Label_ContextLatitude)
        Me.Controls.Add(Me.Label_Latitude)
        Me.Controls.Add(Me.Label_ContextLongitude)
        Me.Controls.Add(Me.Label_Longitude)
        Me.Controls.Add(Me.ZoomOut)
        Me.Controls.Add(Me.ZoomIn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.Right)
        Me.Controls.Add(Me.Left)
        Me.Controls.Add(Me.Down)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Up)
        Me.Name = "Form1"
        Me.Text = "Made By Chen fanyun"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Up As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Down As Button
    Friend WithEvents Left As Button
    Friend WithEvents Right As Button
    Friend WithEvents Reset As Button
    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ZoomIn As Button
    Friend WithEvents ZoomOut As Button
    Friend WithEvents Label_Longitude As Label
    Friend WithEvents Label_ContextLongitude As Label
    Friend WithEvents Label_Latitude As Label
    Friend WithEvents Label_ContextLatitude As Label
End Class

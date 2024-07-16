<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Adminis
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.kelbut = New System.Windows.Forms.Button()
        Me.logbut = New System.Windows.Forms.Button()
        Me.irrebut = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 447)
        Me.Panel1.TabIndex = 0
        '
        'kelbut
        '
        Me.kelbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.kelbut.Location = New System.Drawing.Point(654, 15)
        Me.kelbut.Name = "kelbut"
        Me.kelbut.Size = New System.Drawing.Size(132, 31)
        Me.kelbut.TabIndex = 1
        Me.kelbut.Text = "Kelola User"
        Me.kelbut.UseVisualStyleBackColor = True
        '
        'logbut
        '
        Me.logbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.logbut.Location = New System.Drawing.Point(807, 15)
        Me.logbut.Name = "logbut"
        Me.logbut.Size = New System.Drawing.Size(132, 31)
        Me.logbut.TabIndex = 1
        Me.logbut.Text = "Log Activity"
        Me.logbut.UseVisualStyleBackColor = True
        '
        'irrebut
        '
        Me.irrebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.irrebut.Location = New System.Drawing.Point(499, 15)
        Me.irrebut.Name = "irrebut"
        Me.irrebut.Size = New System.Drawing.Size(132, 31)
        Me.irrebut.TabIndex = 1
        Me.irrebut.Text = "Irreguler"
        Me.irrebut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(53, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "User Controlloler"
        '
        'Adminis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(953, 480)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.irrebut)
        Me.Controls.Add(Me.logbut)
        Me.Controls.Add(Me.kelbut)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Adminis"
        Me.Text = "Adminis"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents kelbut As System.Windows.Forms.Button
    Friend WithEvents logbut As System.Windows.Forms.Button
    Friend WithEvents irrebut As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

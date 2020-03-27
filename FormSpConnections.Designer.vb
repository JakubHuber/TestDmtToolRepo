<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSpConnections
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
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.cmbConnectionNames = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonOk
        '
        Me.ButtonOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.ButtonOk.Location = New System.Drawing.Point(216, 142)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(75, 29)
        Me.ButtonOk.TabIndex = 0
        Me.ButtonOk.Text = "OK"
        Me.ButtonOk.UseVisualStyleBackColor = False
        '
        'cmbConnectionNames
        '
        Me.cmbConnectionNames.BackColor = System.Drawing.Color.FromArgb(CType(CType(93, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.cmbConnectionNames.FormattingEnabled = True
        Me.cmbConnectionNames.Location = New System.Drawing.Point(91, 57)
        Me.cmbConnectionNames.Name = "cmbConnectionNames"
        Me.cmbConnectionNames.Size = New System.Drawing.Size(122, 28)
        Me.cmbConnectionNames.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select connection"
        '
        'FormSpConnections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(154, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(303, 183)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbConnectionNames)
        Me.Controls.Add(Me.ButtonOk)
        Me.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FormSpConnections"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SharePoint connections"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonOk As Windows.Forms.Button
    Friend WithEvents cmbConnectionNames As Windows.Forms.ComboBox
    Friend WithEvents Label1 As Windows.Forms.Label
End Class

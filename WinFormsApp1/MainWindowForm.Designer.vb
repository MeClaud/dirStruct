<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindowForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindowForm))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PathBox = New System.Windows.Forms.TextBox()
        Me.OutputBox = New System.Windows.Forms.CheckedListBox()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.OpenExports = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PathBox
        '
        resources.ApplyResources(Me.PathBox, "PathBox")
        Me.PathBox.Name = "PathBox"
        '
        'OutputBox
        '
        Me.OutputBox.FormattingEnabled = True
        resources.ApplyResources(Me.OutputBox, "OutputBox")
        Me.OutputBox.Name = "OutputBox"
        '
        'ExportButton
        '
        resources.ApplyResources(Me.ExportButton, "ExportButton")
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.UseVisualStyleBackColor = True
        '
        'OpenExports
        '
        resources.ApplyResources(Me.OpenExports, "OpenExports")
        Me.OpenExports.Name = "OpenExports"
        Me.OpenExports.UseVisualStyleBackColor = True
        '
        'MainWindowForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OpenExports)
        Me.Controls.Add(Me.ExportButton)
        Me.Controls.Add(Me.OutputBox)
        Me.Controls.Add(Me.PathBox)
        Me.Controls.Add(Me.Button2)
        Me.Name = "MainWindowForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents PathBox As TextBox
    Friend WithEvents OutputBox As CheckedListBox
    Friend WithEvents ExportButton As Button
    Friend WithEvents OpenExports As Button
End Class

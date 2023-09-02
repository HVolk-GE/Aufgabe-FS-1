<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BtnInkrement = New System.Windows.Forms.Button()
        Me.BtnDekrement = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnInkrement
        '
        Me.BtnInkrement.Location = New System.Drawing.Point(23, 139)
        Me.BtnInkrement.Name = "BtnInkrement"
        Me.BtnInkrement.Size = New System.Drawing.Size(75, 23)
        Me.BtnInkrement.TabIndex = 0
        Me.BtnInkrement.Text = "Inkrement"
        Me.BtnInkrement.UseVisualStyleBackColor = True
        '
        'BtnDekrement
        '
        Me.BtnDekrement.Location = New System.Drawing.Point(167, 139)
        Me.BtnDekrement.Name = "BtnDekrement"
        Me.BtnDekrement.Size = New System.Drawing.Size(80, 23)
        Me.BtnDekrement.TabIndex = 1
        Me.BtnDekrement.Text = "Dekrement"
        Me.BtnDekrement.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(23, 32)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(224, 23)
        Me.ProgressBar.TabIndex = 2
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Enabled = False
        Me.NumericUpDown1.Location = New System.Drawing.Point(79, 90)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 203)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.BtnDekrement)
        Me.Controls.Add(Me.BtnInkrement)
        Me.Name = "Form1"
        Me.Text = "FS Aufgabe 1"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnInkrement As Button
    Friend WithEvents BtnDekrement As Button
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents NumericUpDown1 As NumericUpDown
End Class

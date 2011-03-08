<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneracionReporte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.barraprogreso = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'barraprogreso
        '
        Me.barraprogreso.Location = New System.Drawing.Point(12, 50)
        Me.barraprogreso.Name = "barraprogreso"
        Me.barraprogreso.Size = New System.Drawing.Size(341, 23)
        Me.barraprogreso.TabIndex = 0
        Me.barraprogreso.Value = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Generando reporte..."
        '
        'frmGeneracionReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 104)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.barraprogreso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGeneracionReporte"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGeneracionReporte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents barraprogreso As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prueba
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
        Me.PanelAccion2 = New SICO.ctrla.PanelAccion
        Me.SuspendLayout()
        '
        'PanelAccion2
        '
        Me.PanelAccion2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion2.EstadoMensaje = ""
        
        Me.PanelAccion2.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion2.Name = "PanelAccion2"
        Me.PanelAccion2.Size = New System.Drawing.Size(702, 397)
        Me.PanelAccion2.TabIndex = 0
        Me.PanelAccion2.Titulo = "Título"
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 397)
        Me.Controls.Add(Me.PanelAccion2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelAccion1 As SiCo.ctrla.PanelAccion
    Friend WithEvents Pn As SICO.ctrla.ControlesPersonalizados.crtlPersonaNatural
    Friend WithEvents PanelAccion2 As SICO.ctrla.PanelAccion


End Class

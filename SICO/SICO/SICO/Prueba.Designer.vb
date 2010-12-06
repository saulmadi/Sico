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
        Me.components = New System.ComponentModel.Container
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Pn = New SICO.ctrla.ControlesPersonalizados.crtlPersonaNatural
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TextBox1.Location = New System.Drawing.Point(516, 121)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 2
        '
        'Pn
        '
        Me.Pn.Location = New System.Drawing.Point(12, 91)
        Me.Pn.Name = "Pn"
        Me.Pn.Size = New System.Drawing.Size(497, 264)
        Me.Pn.TabIndex = 1
        '
        'PanelAccion1
        '
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.HabilitarCancelar = True
        Me.PanelAccion1.habilitarEliminar = True
        Me.PanelAccion1.HabilitarGuardar = True
        Me.PanelAccion1.habilitarImprimir = True
        Me.PanelAccion1.HabilitarNuevo = True
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(621, 435)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "Proveedores"
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 435)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Pn)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelAccion1 As SiCo.ctrla.PanelAccion
    Friend WithEvents Pn As SICO.ctrla.ControlesPersonalizados.crtlPersonaNatural
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox


End Class

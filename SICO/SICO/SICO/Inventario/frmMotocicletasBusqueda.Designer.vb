<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotocicletasBusqueda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotocicletasBusqueda))
        Me.CrtPanelBusqueda1 = New SICO.ctrla2.crtPanelBusqueda
        Me.Label1 = New System.Windows.Forms.Label
        Me.CajaTexto1 = New SICO.ctrla.CajaTexto(Me.components)
        Me.SuspendLayout()
        '
        'CrtPanelBusqueda1
        '
        Me.CrtPanelBusqueda1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPanelBusqueda1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBusqueda1.Name = "CrtPanelBusqueda1"
        Me.CrtPanelBusqueda1.Size = New System.Drawing.Size(878, 262)
        Me.CrtPanelBusqueda1.TabIndex = 0
        Me.CrtPanelBusqueda1.Titulo = "Busqueda Motocicletas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Motor"
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.Location = New System.Drawing.Point(53, 133)
        Me.CajaTexto1.MaxLength = 255
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(332, 20)
        Me.CajaTexto1.TabIndex = 2
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'frmMotocicletasBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 262)
        Me.Controls.Add(Me.CajaTexto1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CrtPanelBusqueda1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(894, 300)
        Me.Name = "frmMotocicletasBusqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Motociletas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrtPanelBusqueda1 As SICO.ctrla2.crtPanelBusqueda
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto1 As SICO.ctrla.CajaTexto
End Class

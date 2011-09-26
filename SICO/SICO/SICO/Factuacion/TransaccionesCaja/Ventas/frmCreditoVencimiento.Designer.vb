<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreditoVencimiento
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
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.dteFechaVencimiento = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescripcion = New SICO.ctrla.CajaTexto(Me.components)
        Me.SuspendLayout()
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(525, 372)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "Crédito"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'dteFechaVencimiento
        '
        Me.dteFechaVencimiento.Location = New System.Drawing.Point(126, 106)
        Me.dteFechaVencimiento.Name = "dteFechaVencimiento"
        Me.dteFechaVencimiento.Size = New System.Drawing.Size(359, 20)
        Me.dteFechaVencimiento.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Vencimiento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescripcion.ColorError = System.Drawing.Color.Red
        Me.txtDescripcion.EnterPorTab = True
        Me.txtDescripcion.EsObligatorio = False
        Me.txtDescripcion.ExpresionValidacion = Nothing
        Me.txtDescripcion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDescripcion.Location = New System.Drawing.Point(126, 132)
        Me.txtDescripcion.MaxLength = 200
        Me.txtDescripcion.MensajeError = Nothing
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(359, 114)
        Me.txtDescripcion.TabIndex = 4
        Me.txtDescripcion.Texto = Nothing
        Me.txtDescripcion.TipoTexto = SICO.ctrla.TiposTexto.Parrafo
        Me.txtDescripcion.ValorDecimal = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtDescripcion.ValorInt = Nothing
        Me.txtDescripcion.ValorLong = Nothing
        '
        'frmCreditoVencimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 372)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dteFechaVencimiento)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCreditoVencimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crédito"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents dteFechaVencimiento As System.Windows.Forms.DateTimePicker
    Public WithEvents txtDescripcion As SICO.ctrla.CajaTexto
End Class

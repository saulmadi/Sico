<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTC

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTC))
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.cmbTarjetaCredito = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNumeroTarjeta = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtExpira = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtAprobacion = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMonto = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(439, 300)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "T/C"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'cmbTarjetaCredito
        '
        Me.cmbTarjetaCredito.CargarAutoCompletar = False
        Me.cmbTarjetaCredito.CargarComboBox = True
        Me.cmbTarjetaCredito.FormattingEnabled = True
        Me.cmbTarjetaCredito.Location = New System.Drawing.Point(89, 103)
        Me.cmbTarjetaCredito.Name = "cmbTarjetaCredito"
        Me.cmbTarjetaCredito.ParametroAutocompletar = Nothing
        Me.cmbTarjetaCredito.ParametroBusquedaPadre = Nothing
        Me.cmbTarjetaCredito.Size = New System.Drawing.Size(320, 21)
        Me.cmbTarjetaCredito.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tarjeta"
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumeroTarjeta.ColorError = System.Drawing.Color.Red
        Me.txtNumeroTarjeta.EnterPorTab = True
        Me.txtNumeroTarjeta.EsObligatorio = True
        Me.txtNumeroTarjeta.ExpresionValidacion = Nothing
        Me.txtNumeroTarjeta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(89, 157)
        Me.txtNumeroTarjeta.MensajeError = "Ingrese el número de aprobación"
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(320, 20)
        Me.txtNumeroTarjeta.TabIndex = 3
        Me.txtNumeroTarjeta.Texto = Nothing
        Me.txtNumeroTarjeta.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.txtNumeroTarjeta.ValorDecimal = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNumeroTarjeta.ValorInt = Nothing
        Me.txtNumeroTarjeta.ValorLong = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Número"
        '
        'txtExpira
        '
        Me.txtExpira.BackColor = System.Drawing.SystemColors.Window
        Me.txtExpira.ColorError = System.Drawing.Color.Red
        Me.txtExpira.EnterPorTab = True
        Me.txtExpira.EsObligatorio = True
        Me.txtExpira.ExpresionValidacion = Nothing
        Me.txtExpira.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtExpira.Location = New System.Drawing.Point(89, 183)
        Me.txtExpira.MaxLength = 4
        Me.txtExpira.MensajeError = "Ingrese la fecha de expiracion"
        Me.txtExpira.Name = "txtExpira"
        Me.txtExpira.Size = New System.Drawing.Size(320, 20)
        Me.txtExpira.TabIndex = 5
        Me.txtExpira.Texto = Nothing
        Me.txtExpira.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.txtExpira.ValorDecimal = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtExpira.ValorInt = Nothing
        Me.txtExpira.ValorLong = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 189)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Expira"
        '
        'txtAprobacion
        '
        Me.txtAprobacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtAprobacion.ColorError = System.Drawing.Color.Red
        Me.txtAprobacion.EnterPorTab = True
        Me.txtAprobacion.EsObligatorio = True
        Me.txtAprobacion.ExpresionValidacion = Nothing
        Me.txtAprobacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAprobacion.Location = New System.Drawing.Point(89, 209)
        Me.txtAprobacion.MensajeError = "Ingrese el código de aprobación"
        Me.txtAprobacion.Name = "txtAprobacion"
        Me.txtAprobacion.Size = New System.Drawing.Size(320, 20)
        Me.txtAprobacion.TabIndex = 7
        Me.txtAprobacion.Texto = Nothing
        Me.txtAprobacion.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.txtAprobacion.ValorDecimal = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtAprobacion.ValorInt = Nothing
        Me.txtAprobacion.ValorLong = Nothing
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Aprobación"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.Window
        Me.txtMonto.ColorError = System.Drawing.Color.Red
        Me.txtMonto.Enabled = False
        Me.txtMonto.EnterPorTab = True
        Me.txtMonto.EsObligatorio = False
        Me.txtMonto.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.txtMonto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMonto.Location = New System.Drawing.Point(89, 131)
        Me.txtMonto.MaxLength = 12
        Me.txtMonto.MensajeError = Nothing
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(320, 20)
        Me.txtMonto.TabIndex = 3
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMonto.Texto = Nothing
        Me.txtMonto.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.txtMonto.ValorDecimal = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMonto.ValorInt = Nothing
        Me.txtMonto.ValorLong = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Monto"
        '
        'frmTC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 300)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAprobacion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtExpira)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.txtNumeroTarjeta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTarjetaCredito)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobro"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents cmbTarjetaCredito As SICO.ctrla.ListaDesplegable
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroTarjeta As SICO.ctrla.CajaTexto
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtExpira As SICO.ctrla.CajaTexto
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAprobacion As SICO.ctrla.CajaTexto
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As SICO.ctrla.CajaTexto
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

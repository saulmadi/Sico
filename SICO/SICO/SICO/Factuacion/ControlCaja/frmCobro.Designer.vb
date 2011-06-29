<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCobro))
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotal = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtEfectivo = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtTC = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtCambio = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtBalance = New SICO.ctrla.CajaTexto(Me.components)
        Me.SuspendLayout()
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(503, 409)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "Cobro Factura"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Efectivo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 201)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 31)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "T/C"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 31)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cambio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 301)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 31)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Balance"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotal.ColorError = System.Drawing.Color.Red
        Me.txtTotal.Enabled = False
        Me.txtTotal.EnterPorTab = True
        Me.txtTotal.EsObligatorio = False
        Me.txtTotal.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTotal.Location = New System.Drawing.Point(156, 95)
        Me.txtTotal.MaxLength = 12
        Me.txtTotal.MensajeError = Nothing
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(325, 44)
        Me.txtTotal.TabIndex = 6
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotal.Texto = "0.00"
        Me.txtTotal.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.txtTotal.ValorInt = Nothing
        Me.txtTotal.ValorLong = Nothing
        '
        'txtEfectivo
        '
        Me.txtEfectivo.BackColor = System.Drawing.SystemColors.Window
        Me.txtEfectivo.ColorError = System.Drawing.Color.Red
        Me.txtEfectivo.EnterPorTab = True
        Me.txtEfectivo.EsObligatorio = False
        Me.txtEfectivo.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEfectivo.Location = New System.Drawing.Point(156, 145)
        Me.txtEfectivo.MaxLength = 12
        Me.txtEfectivo.MensajeError = Nothing
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(325, 44)
        Me.txtEfectivo.TabIndex = 7
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtEfectivo.Texto = "0.00"
        Me.txtEfectivo.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.txtEfectivo.ValorInt = Nothing
        Me.txtEfectivo.ValorLong = Nothing
        '
        'txtTC
        '
        Me.txtTC.BackColor = System.Drawing.SystemColors.Window
        Me.txtTC.ColorError = System.Drawing.Color.Red
        Me.txtTC.EnterPorTab = True
        Me.txtTC.EsObligatorio = False
        Me.txtTC.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.txtTC.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTC.Location = New System.Drawing.Point(156, 195)
        Me.txtTC.MaxLength = 12
        Me.txtTC.MensajeError = Nothing
        Me.txtTC.Name = "txtTC"
        Me.txtTC.Size = New System.Drawing.Size(325, 44)
        Me.txtTC.TabIndex = 8
        Me.txtTC.Text = "0.00"
        Me.txtTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTC.Texto = "0.00"
        Me.txtTC.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.txtTC.ValorInt = Nothing
        Me.txtTC.ValorLong = Nothing
        '
        'txtCambio
        '
        Me.txtCambio.BackColor = System.Drawing.SystemColors.Window
        Me.txtCambio.ColorError = System.Drawing.Color.Red
        Me.txtCambio.Enabled = False
        Me.txtCambio.EnterPorTab = True
        Me.txtCambio.EsObligatorio = False
        Me.txtCambio.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.txtCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCambio.Location = New System.Drawing.Point(156, 245)
        Me.txtCambio.MaxLength = 12
        Me.txtCambio.MensajeError = Nothing
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.Size = New System.Drawing.Size(325, 44)
        Me.txtCambio.TabIndex = 9
        Me.txtCambio.Text = "0.00"
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCambio.Texto = "0.00"
        Me.txtCambio.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.txtCambio.ValorInt = Nothing
        Me.txtCambio.ValorLong = Nothing
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.SystemColors.Window
        Me.txtBalance.ColorError = System.Drawing.Color.Red
        Me.txtBalance.Enabled = False
        Me.txtBalance.EnterPorTab = True
        Me.txtBalance.EsObligatorio = False
        Me.txtBalance.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBalance.Location = New System.Drawing.Point(156, 295)
        Me.txtBalance.MaxLength = 12
        Me.txtBalance.MensajeError = Nothing
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Size = New System.Drawing.Size(325, 44)
        Me.txtBalance.TabIndex = 10
        Me.txtBalance.Text = "0.00"
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBalance.Texto = "0.00"
        Me.txtBalance.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.txtBalance.ValorInt = Nothing
        Me.txtBalance.ValorLong = Nothing
        '
        'frmCobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 409)
        Me.Controls.Add(Me.txtBalance)
        Me.Controls.Add(Me.txtCambio)
        Me.Controls.Add(Me.txtTC)
        Me.Controls.Add(Me.txtEfectivo)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As SICO.ctrla.CajaTexto
    Friend WithEvents txtEfectivo As SICO.ctrla.CajaTexto
    Friend WithEvents txtTC As SICO.ctrla.CajaTexto
    Friend WithEvents txtCambio As SICO.ctrla.CajaTexto
    Friend WithEvents txtBalance As SICO.ctrla.CajaTexto
End Class

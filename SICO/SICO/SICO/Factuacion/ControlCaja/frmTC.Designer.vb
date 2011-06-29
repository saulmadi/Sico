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
        Me.ListaDesplegable1 = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.CajaTexto1 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.CajaTexto2 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.CajaTexto3 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.CajaTexto4 = New SICO.ctrla.CajaTexto(Me.components)
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
        'ListaDesplegable1
        '
        Me.ListaDesplegable1.CargarAutoCompletar = False
        Me.ListaDesplegable1.CargarComboBox = True
        Me.ListaDesplegable1.FormattingEnabled = True
        Me.ListaDesplegable1.Location = New System.Drawing.Point(89, 103)
        Me.ListaDesplegable1.Name = "ListaDesplegable1"
        Me.ListaDesplegable1.ParametroAutocompletar = Nothing
        Me.ListaDesplegable1.ParametroBusquedaPadre = Nothing
        Me.ListaDesplegable1.Size = New System.Drawing.Size(320, 21)
        Me.ListaDesplegable1.TabIndex = 1
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
        'CajaTexto1
        '
        Me.CajaTexto1.BackColor = System.Drawing.SystemColors.Window
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EnterPorTab = True
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CajaTexto1.Location = New System.Drawing.Point(89, 157)
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(320, 20)
        Me.CajaTexto1.TabIndex = 3
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.CajaTexto1.ValorInt = Nothing
        Me.CajaTexto1.ValorLong = Nothing
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
        'CajaTexto2
        '
        Me.CajaTexto2.BackColor = System.Drawing.SystemColors.Window
        Me.CajaTexto2.ColorError = System.Drawing.Color.Red
        Me.CajaTexto2.EnterPorTab = True
        Me.CajaTexto2.EsObligatorio = False
        Me.CajaTexto2.ExpresionValidacion = Nothing
        Me.CajaTexto2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CajaTexto2.Location = New System.Drawing.Point(89, 183)
        Me.CajaTexto2.MensajeError = Nothing
        Me.CajaTexto2.Name = "CajaTexto2"
        Me.CajaTexto2.Size = New System.Drawing.Size(320, 20)
        Me.CajaTexto2.TabIndex = 5
        Me.CajaTexto2.Texto = Nothing
        Me.CajaTexto2.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.CajaTexto2.ValorInt = Nothing
        Me.CajaTexto2.ValorLong = Nothing
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
        'CajaTexto3
        '
        Me.CajaTexto3.BackColor = System.Drawing.SystemColors.Window
        Me.CajaTexto3.ColorError = System.Drawing.Color.Red
        Me.CajaTexto3.EnterPorTab = True
        Me.CajaTexto3.EsObligatorio = False
        Me.CajaTexto3.ExpresionValidacion = Nothing
        Me.CajaTexto3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CajaTexto3.Location = New System.Drawing.Point(89, 209)
        Me.CajaTexto3.MensajeError = Nothing
        Me.CajaTexto3.Name = "CajaTexto3"
        Me.CajaTexto3.Size = New System.Drawing.Size(320, 20)
        Me.CajaTexto3.TabIndex = 7
        Me.CajaTexto3.Texto = Nothing
        Me.CajaTexto3.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.CajaTexto3.ValorInt = Nothing
        Me.CajaTexto3.ValorLong = Nothing
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
        'CajaTexto4
        '
        Me.CajaTexto4.BackColor = System.Drawing.SystemColors.Window
        Me.CajaTexto4.ColorError = System.Drawing.Color.Red
        Me.CajaTexto4.Enabled = False
        Me.CajaTexto4.EnterPorTab = True
        Me.CajaTexto4.EsObligatorio = False
        Me.CajaTexto4.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.CajaTexto4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CajaTexto4.Location = New System.Drawing.Point(89, 131)
        Me.CajaTexto4.MaxLength = 12
        Me.CajaTexto4.MensajeError = Nothing
        Me.CajaTexto4.Name = "CajaTexto4"
        Me.CajaTexto4.Size = New System.Drawing.Size(320, 20)
        Me.CajaTexto4.TabIndex = 3
        Me.CajaTexto4.Text = "0.00"
        Me.CajaTexto4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CajaTexto4.Texto = "0.00"
        Me.CajaTexto4.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.CajaTexto4.ValorInt = Nothing
        Me.CajaTexto4.ValorLong = Nothing
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
        Me.Controls.Add(Me.CajaTexto3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CajaTexto2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CajaTexto4)
        Me.Controls.Add(Me.CajaTexto1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListaDesplegable1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents ListaDesplegable1 As SICO.ctrla.ListaDesplegable
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto1 As SICO.ctrla.CajaTexto
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto2 As SICO.ctrla.CajaTexto
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto3 As SICO.ctrla.CajaTexto
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto4 As SICO.ctrla.CajaTexto
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

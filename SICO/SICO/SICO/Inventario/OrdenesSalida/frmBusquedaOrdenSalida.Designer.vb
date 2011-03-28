<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusquedaOrdenSalida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBusquedaOrdenSalida))
        Me.CrtPanelBusqueda1 = New SICO.ctrla2.crtPanelBusqueda
        Me.fechahasta = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbSucursalDestinatario = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.cmbSucursalSolicitante = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcodigo = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.fecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrtPanelBusqueda1
        '
        Me.CrtPanelBusqueda1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPanelBusqueda1.Entidad = Nothing
        Me.CrtPanelBusqueda1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBusqueda1.Name = "CrtPanelBusqueda1"
        Me.CrtPanelBusqueda1.Size = New System.Drawing.Size(949, 444)
        Me.CrtPanelBusqueda1.TabIndex = 0
        Me.CrtPanelBusqueda1.Titulo = "Orden de Salida"
        Me.CrtPanelBusqueda1.VisiblePanelPrincipal = True
        '
        'fechahasta
        '
        Me.fechahasta.Location = New System.Drawing.Point(322, 150)
        Me.fechahasta.Name = "fechahasta"
        Me.fechahasta.Size = New System.Drawing.Size(200, 20)
        Me.fechahasta.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(251, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Fecha hasta"
        '
        'cmbSucursalDestinatario
        '
        Me.cmbSucursalDestinatario.CargarAutoCompletar = False
        Me.cmbSucursalDestinatario.CargarComboBox = True
        Me.cmbSucursalDestinatario.FormattingEnabled = True
        Me.cmbSucursalDestinatario.Location = New System.Drawing.Point(633, 150)
        Me.cmbSucursalDestinatario.Name = "cmbSucursalDestinatario"
        Me.cmbSucursalDestinatario.ParametroAutocompletar = Nothing
        Me.cmbSucursalDestinatario.ParametroBusquedaPadre = Nothing
        Me.cmbSucursalDestinatario.SelectedItem = Nothing
        Me.cmbSucursalDestinatario.Size = New System.Drawing.Size(201, 21)
        Me.cmbSucursalDestinatario.TabIndex = 20
        '
        'cmbSucursalSolicitante
        '
        Me.cmbSucursalSolicitante.CargarAutoCompletar = False
        Me.cmbSucursalSolicitante.CargarComboBox = True
        Me.cmbSucursalSolicitante.FormattingEnabled = True
        Me.cmbSucursalSolicitante.Location = New System.Drawing.Point(633, 123)
        Me.cmbSucursalSolicitante.Name = "cmbSucursalSolicitante"
        Me.cmbSucursalSolicitante.ParametroAutocompletar = Nothing
        Me.cmbSucursalSolicitante.ParametroBusquedaPadre = Nothing
        Me.cmbSucursalSolicitante.SelectedItem = Nothing
        Me.cmbSucursalSolicitante.Size = New System.Drawing.Size(201, 21)
        Me.cmbSucursalSolicitante.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Código"
        '
        'txtcodigo
        '
        Me.txtcodigo.BackColor = System.Drawing.SystemColors.Window
        Me.txtcodigo.ColorError = System.Drawing.Color.Red
        Me.txtcodigo.EnterPorTab = True
        Me.txtcodigo.EsObligatorio = False
        Me.txtcodigo.ExpresionValidacion = Nothing
        Me.txtcodigo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcodigo.Location = New System.Drawing.Point(78, 126)
        Me.txtcodigo.MensajeError = Nothing
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(167, 20)
        Me.txtcodigo.TabIndex = 17
        Me.txtcodigo.Texto = Nothing
        Me.txtcodigo.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtcodigo.ValorInt = Nothing
        Me.txtcodigo.ValorLong = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(528, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Sucursal destinataria"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(528, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Sucursal solicitante"
        '
        'fecha
        '
        Me.fecha.Location = New System.Drawing.Point(322, 125)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(200, 20)
        Me.fecha.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Fecha desde"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(840, 123)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 23)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmBusquedaOrdenSalida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 444)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.fechahasta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbSucursalDestinatario)
        Me.Controls.Add(Me.cmbSucursalSolicitante)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CrtPanelBusqueda1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(907, 482)
        Me.Name = "frmBusquedaOrdenSalida"
        Me.Text = "Busqueda Ordens de Salida"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrtPanelBusqueda1 As SICO.ctrla2.crtPanelBusqueda
    Friend WithEvents fechahasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursalDestinatario As SICO.ctrla.ControlesBasicos.ListaSucursales
    Friend WithEvents cmbSucursalSolicitante As SICO.ctrla.ControlesBasicos.ListaSucursales
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As SICO.ctrla.CajaTexto
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompras))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.txttotal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtimpuesto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtsubtotal = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.grpCompra = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.dteFechaCompra = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.grdDetalle = New SICO.ctrla.Grid(Me.components)
        Me.txtFacturCompra = New SICO.ctrla.CajaTexto(Me.components)
        Me.cmbSucursales = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.cmbProveedor = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.CrtPanelBase1 = New SICO.ctrla.ControlesPersonalizados.crtPanelBase
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpCompra.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 225)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(919, 331)
        Me.Panel2.TabIndex = 8
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.grdDetalle)
        Me.GroupBox5.Controls.Add(Me.Panel7)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(855, 331)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Productos"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 241)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(849, 87)
        Me.Panel7.TabIndex = 9
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.txttotal)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.txtimpuesto)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.txtsubtotal)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(513, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(336, 87)
        Me.Panel8.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(104, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Subtotal"
        '
        'txttotal
        '
        Me.txttotal.Enabled = False
        Me.txttotal.Location = New System.Drawing.Point(168, 61)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(165, 20)
        Me.txttotal.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(104, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Impuesto"
        '
        'txtimpuesto
        '
        Me.txtimpuesto.Enabled = False
        Me.txtimpuesto.Location = New System.Drawing.Point(168, 35)
        Me.txtimpuesto.Name = "txtimpuesto"
        Me.txtimpuesto.Size = New System.Drawing.Size(165, 20)
        Me.txtimpuesto.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(104, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Total"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Enabled = False
        Me.txtsubtotal.Location = New System.Drawing.Point(168, 9)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(165, 20)
        Me.txtsubtotal.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(886, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(33, 331)
        Me.Panel4.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(31, 331)
        Me.Panel3.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 89)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(919, 136)
        Me.Panel1.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.grpCompra)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(855, 131)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(620, 8)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(223, 21)
        Me.lblEstado.TabIndex = 13
        Me.lblEstado.Text = "Label2"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpCompra
        '
        Me.grpCompra.Controls.Add(Me.txtFacturCompra)
        Me.grpCompra.Controls.Add(Me.cmbSucursales)
        Me.grpCompra.Controls.Add(Me.Label8)
        Me.grpCompra.Controls.Add(Me.Label7)
        Me.grpCompra.Controls.Add(Me.Label13)
        Me.grpCompra.Controls.Add(Me.dteFechaCompra)
        Me.grpCompra.Enabled = False
        Me.grpCompra.Location = New System.Drawing.Point(6, 25)
        Me.grpCompra.Name = "grpCompra"
        Me.grpCompra.Size = New System.Drawing.Size(423, 96)
        Me.grpCompra.TabIndex = 12
        Me.grpCompra.TabStop = False
        Me.grpCompra.Text = "Datos de compra"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Factura de compra"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fecha de compras"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Sucursal destino"
        '
        'dteFechaCompra
        '
        Me.dteFechaCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dteFechaCompra.Location = New System.Drawing.Point(112, 39)
        Me.dteFechaCompra.Name = "dteFechaCompra"
        Me.dteFechaCompra.Size = New System.Drawing.Size(300, 20)
        Me.dteFechaCompra.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbProveedor)
        Me.GroupBox2.Controls.Add(Me.txtTelefono)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(435, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(410, 75)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Proveedor"
        '
        'txtTelefono
        '
        Me.txtTelefono.Enabled = False
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(68, 46)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(333, 20)
        Me.txtTelefono.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Teléfono"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proveedor"
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(886, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(33, 136)
        Me.Panel5.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(31, 136)
        Me.Panel6.TabIndex = 0
        '
        'grdDetalle
        '
        Me.grdDetalle.AllowUserToAddRows = False
        Me.grdDetalle.AllowUserToDeleteRows = False
        Me.grdDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdDetalle.BotonBuscar = False
        Me.grdDetalle.BotonEditar = False
        Me.grdDetalle.BotonEliminar = False
        Me.grdDetalle.CampoId = "id"
        Me.grdDetalle.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.grdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDetalle.Location = New System.Drawing.Point(3, 16)
        Me.grdDetalle.MultiSelect = False
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.RowHeadersVisible = False
        Me.grdDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdDetalle.Size = New System.Drawing.Size(849, 225)
        Me.grdDetalle.TabIndex = 10
        '
        'txtFacturCompra
        '
        Me.txtFacturCompra.BackColor = System.Drawing.SystemColors.Window
        Me.txtFacturCompra.ColorError = System.Drawing.Color.Red
        Me.txtFacturCompra.EnterPorTab = True
        Me.txtFacturCompra.EsObligatorio = True
        Me.txtFacturCompra.ExpresionValidacion = Nothing
        Me.txtFacturCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFacturCompra.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFacturCompra.Location = New System.Drawing.Point(112, 13)
        Me.txtFacturCompra.MaxLength = 11
        Me.txtFacturCompra.MensajeError = Nothing
        Me.txtFacturCompra.Name = "txtFacturCompra"
        Me.txtFacturCompra.Size = New System.Drawing.Size(300, 20)
        Me.txtFacturCompra.TabIndex = 13
        Me.txtFacturCompra.Texto = Nothing
        Me.txtFacturCompra.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.txtFacturCompra.ValorInt = Nothing
        Me.txtFacturCompra.ValorLong = Nothing
        '
        'cmbSucursales
        '
        Me.cmbSucursales.CargarAutoCompletar = False
        Me.cmbSucursales.CargarComboBox = True
        Me.cmbSucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.Location = New System.Drawing.Point(112, 65)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.ParametroAutocompletar = Nothing
        Me.cmbSucursales.ParametroBusquedaPadre = Nothing
        Me.cmbSucursales.SelectedItem = Nothing
        Me.cmbSucursales.Size = New System.Drawing.Size(300, 21)
        Me.cmbSucursales.TabIndex = 12
        '
        'cmbProveedor
        '
        Me.cmbProveedor.CargarAutoCompletar = False
        Me.cmbProveedor.CargarComboBox = True
        Me.cmbProveedor.DisplayMember = "NombreMantenimiento"
        Me.cmbProveedor.Enabled = False
        Me.cmbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(69, 19)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.ParametroAutocompletar = Nothing
        Me.cmbProveedor.ParametroBusquedaPadre = Nothing
        Me.cmbProveedor.Size = New System.Drawing.Size(332, 21)
        Me.cmbProveedor.TabIndex = 6
        Me.cmbProveedor.ValueMember = "Id"
        '
        'CrtPanelBase1
        '
        Me.CrtPanelBase1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CrtPanelBase1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBase1.Name = "CrtPanelBase1"
        Me.CrtPanelBase1.Size = New System.Drawing.Size(919, 89)
        Me.CrtPanelBase1.TabIndex = 5
        Me.CrtPanelBase1.Titulo = "Compras"
        Me.CrtPanelBase1.VisiblePanelPrincipal = True
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 556)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(919, 56)
        Me.PanelAccion1.TabIndex = 6
        Me.PanelAccion1.Titulo = "Orden de Compra"
        Me.PanelAccion1.VisiblePanelPrincipal = False
        '
        'frmCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 612)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrtPanelBase1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(935, 650)
        Me.Name = "frmCompras"
        Me.Text = "Compras"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grpCompra.ResumeLayout(False)
        Me.grpCompra.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dteFechaCompra As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents CrtPanelBase1 As SICO.ctrla.ControlesPersonalizados.crtPanelBase
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents txtimpuesto As System.Windows.Forms.TextBox
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents grpCompra As System.Windows.Forms.GroupBox
    Friend WithEvents grdDetalle As SICO.ctrla.Grid
    Friend WithEvents cmbSucursales As SICO.ctrla.ControlesBasicos.ListaSucursales
    Friend WithEvents cmbProveedor As SICO.ctrla.ListaDesplegable
    Friend WithEvents txtFacturCompra As SICO.ctrla.CajaTexto
    Friend WithEvents lblEstado As System.Windows.Forms.Label
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentaMotocicleta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentaMotocicleta))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDescuento = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtImpuesto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSubtotal = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblNumeroFactura = New System.Windows.Forms.Label
        Me.chkVentaExcenta = New System.Windows.Forms.CheckBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.cmbTipoMotocicleta = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbModelo = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbMarca = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.txtPrecioVenta = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtAnio = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtCilindraje = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtChasis = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtMotor = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtDescuentoPor = New SICO.ctrla.CajaTexto(Me.components)
        Me.cmbTiposFacturas = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.CrtClientes1 = New SICO.ctrla2.crtClientes
        Me.CrtPanelBase1 = New SICO.ctrla.ControlesPersonalizados.crtPanelBase
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 322)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 236)
        Me.Panel2.TabIndex = 16
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cmbTipoMotocicleta)
        Me.GroupBox5.Controls.Add(Me.cmbModelo)
        Me.GroupBox5.Controls.Add(Me.cmbMarca)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.txtPrecioVenta)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.txtAnio)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.txtCilindraje)
        Me.GroupBox5.Controls.Add(Me.txtChasis)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.txtMotor)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Panel7)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(743, 236)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Motocicleta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Tipo de motocicleta"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Modelo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 124)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 56
        Me.Label11.Text = "Marca"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 207)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Precio Venta"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(475, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Año"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Cilindraje"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Chasis"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 34
        Me.Label15.Text = "Motor"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 64)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(737, 169)
        Me.Panel7.TabIndex = 9
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.txtDescuentoPor)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.txtDescuento)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.txtTotal)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.txtImpuesto)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.txtSubtotal)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(420, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(317, 169)
        Me.Panel8.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Desc"
        '
        'txtDescuento
        '
        Me.txtDescuento.Enabled = False
        Me.txtDescuento.Location = New System.Drawing.Point(149, 61)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(165, 20)
        Me.txtDescuento.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Desc (%)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(85, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Subtotal"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(149, 113)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(165, 20)
        Me.txtTotal.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(85, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Impuesto"
        '
        'txtImpuesto
        '
        Me.txtImpuesto.Enabled = False
        Me.txtImpuesto.Location = New System.Drawing.Point(149, 87)
        Me.txtImpuesto.Name = "txtImpuesto"
        Me.txtImpuesto.Size = New System.Drawing.Size(165, 20)
        Me.txtImpuesto.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(85, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Total"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Enabled = False
        Me.txtSubtotal.Location = New System.Drawing.Point(149, 9)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(165, 20)
        Me.txtSubtotal.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(774, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(33, 236)
        Me.Panel4.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(31, 236)
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
        Me.Panel1.Size = New System.Drawing.Size(807, 233)
        Me.Panel1.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblNumeroFactura)
        Me.GroupBox1.Controls.Add(Me.chkVentaExcenta)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbTiposFacturas)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(743, 227)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Venta"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(634, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Número Factura"
        '
        'lblNumeroFactura
        '
        Me.lblNumeroFactura.Location = New System.Drawing.Point(561, 30)
        Me.lblNumeroFactura.Name = "lblNumeroFactura"
        Me.lblNumeroFactura.Size = New System.Drawing.Size(164, 13)
        Me.lblNumeroFactura.TabIndex = 11
        Me.lblNumeroFactura.Text = "Label8"
        Me.lblNumeroFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkVentaExcenta
        '
        Me.chkVentaExcenta.AutoSize = True
        Me.chkVentaExcenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVentaExcenta.Location = New System.Drawing.Point(460, 25)
        Me.chkVentaExcenta.Name = "chkVentaExcenta"
        Me.chkVentaExcenta.Size = New System.Drawing.Size(95, 17)
        Me.chkVentaExcenta.TabIndex = 10
        Me.chkVentaExcenta.Text = "Venta excenta"
        Me.chkVentaExcenta.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(252, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 13)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Tipo factura"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(52, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(194, 20)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Fecha"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CrtClientes1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(731, 162)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(774, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(33, 233)
        Me.Panel5.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(31, 233)
        Me.Panel6.TabIndex = 0
        '
        'cmbTipoMotocicleta
        '
        Me.cmbTipoMotocicleta.CargarAutoCompletar = False
        Me.cmbTipoMotocicleta.CargarComboBox = True
        Me.cmbTipoMotocicleta.DisplayMember = "descripcion"
        Me.cmbTipoMotocicleta.Enabled = False
        Me.cmbTipoMotocicleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoMotocicleta.FormattingEnabled = True
        Me.cmbTipoMotocicleta.Location = New System.Drawing.Point(122, 175)
        Me.cmbTipoMotocicleta.Name = "cmbTipoMotocicleta"
        Me.cmbTipoMotocicleta.ParametroAutocompletar = Nothing
        Me.cmbTipoMotocicleta.ParametroBusquedaPadre = Nothing
        Me.cmbTipoMotocicleta.Size = New System.Drawing.Size(335, 21)
        Me.cmbTipoMotocicleta.TabIndex = 55
        Me.cmbTipoMotocicleta.ValueMember = "id"
        '
        'cmbModelo
        '
        Me.cmbModelo.CargarAutoCompletar = False
        Me.cmbModelo.CargarComboBox = True
        Me.cmbModelo.DisplayMember = "descripcion"
        Me.cmbModelo.Enabled = False
        Me.cmbModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModelo.FormattingEnabled = True
        Me.cmbModelo.Location = New System.Drawing.Point(122, 148)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.ParametroAutocompletar = Nothing
        Me.cmbModelo.ParametroBusquedaPadre = Nothing
        Me.cmbModelo.Size = New System.Drawing.Size(335, 21)
        Me.cmbModelo.TabIndex = 54
        Me.cmbModelo.ValueMember = "id"
        '
        'cmbMarca
        '
        Me.cmbMarca.CargarAutoCompletar = False
        Me.cmbMarca.CargarComboBox = True
        Me.cmbMarca.DisplayMember = "descripcion"
        Me.cmbMarca.Enabled = False
        Me.cmbMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(122, 122)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.ParametroAutocompletar = Nothing
        Me.cmbMarca.ParametroBusquedaPadre = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(335, 21)
        Me.cmbMarca.TabIndex = 53
        Me.cmbMarca.ValueMember = "id"
        '
        'txtPrecioVenta
        '
        Me.txtPrecioVenta.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecioVenta.ColorError = System.Drawing.Color.Red
        Me.txtPrecioVenta.Enabled = False
        Me.txtPrecioVenta.EnterPorTab = True
        Me.txtPrecioVenta.EsObligatorio = False
        Me.txtPrecioVenta.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.txtPrecioVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioVenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPrecioVenta.Location = New System.Drawing.Point(122, 204)
        Me.txtPrecioVenta.MaxLength = 12
        Me.txtPrecioVenta.MensajeError = Nothing
        Me.txtPrecioVenta.Name = "txtPrecioVenta"
        Me.txtPrecioVenta.Size = New System.Drawing.Size(335, 20)
        Me.txtPrecioVenta.TabIndex = 51
        Me.txtPrecioVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPrecioVenta.Texto = Nothing
        Me.txtPrecioVenta.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        Me.txtPrecioVenta.ValorInt = Nothing
        Me.txtPrecioVenta.ValorLong = Nothing
        '
        'txtAnio
        '
        Me.txtAnio.ColorError = System.Drawing.Color.Red
        Me.txtAnio.Enabled = False
        Me.txtAnio.EnterPorTab = True
        Me.txtAnio.EsObligatorio = False
        Me.txtAnio.ExpresionValidacion = Nothing
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.Location = New System.Drawing.Point(122, 97)
        Me.txtAnio.MaxLength = 255
        Me.txtAnio.MensajeError = Nothing
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(335, 20)
        Me.txtAnio.TabIndex = 46
        Me.txtAnio.Texto = Nothing
        Me.txtAnio.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtAnio.ValorInt = Nothing
        Me.txtAnio.ValorLong = Nothing
        '
        'txtCilindraje
        '
        Me.txtCilindraje.ColorError = System.Drawing.Color.Red
        Me.txtCilindraje.Enabled = False
        Me.txtCilindraje.EnterPorTab = True
        Me.txtCilindraje.EsObligatorio = False
        Me.txtCilindraje.ExpresionValidacion = Nothing
        Me.txtCilindraje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCilindraje.Location = New System.Drawing.Point(122, 71)
        Me.txtCilindraje.MaxLength = 255
        Me.txtCilindraje.MensajeError = Nothing
        Me.txtCilindraje.Name = "txtCilindraje"
        Me.txtCilindraje.Size = New System.Drawing.Size(335, 20)
        Me.txtCilindraje.TabIndex = 38
        Me.txtCilindraje.Texto = Nothing
        Me.txtCilindraje.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtCilindraje.ValorInt = Nothing
        Me.txtCilindraje.ValorLong = Nothing
        '
        'txtChasis
        '
        Me.txtChasis.ColorError = System.Drawing.Color.Red
        Me.txtChasis.Enabled = False
        Me.txtChasis.EnterPorTab = True
        Me.txtChasis.EsObligatorio = False
        Me.txtChasis.ExpresionValidacion = Nothing
        Me.txtChasis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChasis.Location = New System.Drawing.Point(122, 45)
        Me.txtChasis.MaxLength = 255
        Me.txtChasis.MensajeError = Nothing
        Me.txtChasis.Name = "txtChasis"
        Me.txtChasis.Size = New System.Drawing.Size(335, 20)
        Me.txtChasis.TabIndex = 37
        Me.txtChasis.Texto = Nothing
        Me.txtChasis.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtChasis.ValorInt = Nothing
        Me.txtChasis.ValorLong = Nothing
        '
        'txtMotor
        '
        Me.txtMotor.ColorError = System.Drawing.Color.Red
        Me.txtMotor.Enabled = False
        Me.txtMotor.EnterPorTab = True
        Me.txtMotor.EsObligatorio = False
        Me.txtMotor.ExpresionValidacion = Nothing
        Me.txtMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMotor.Location = New System.Drawing.Point(122, 19)
        Me.txtMotor.MaxLength = 255
        Me.txtMotor.MensajeError = Nothing
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.Size = New System.Drawing.Size(335, 20)
        Me.txtMotor.TabIndex = 35
        Me.txtMotor.Texto = Nothing
        Me.txtMotor.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtMotor.ValorInt = Nothing
        Me.txtMotor.ValorLong = Nothing
        '
        'txtDescuentoPor
        '
        Me.txtDescuentoPor.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescuentoPor.ColorError = System.Drawing.Color.Red
        Me.txtDescuentoPor.EnterPorTab = True
        Me.txtDescuentoPor.EsObligatorio = False
        Me.txtDescuentoPor.ExpresionValidacion = Nothing
        Me.txtDescuentoPor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDescuentoPor.Location = New System.Drawing.Point(149, 36)
        Me.txtDescuentoPor.MensajeError = Nothing
        Me.txtDescuentoPor.Name = "txtDescuentoPor"
        Me.txtDescuentoPor.Size = New System.Drawing.Size(165, 20)
        Me.txtDescuentoPor.TabIndex = 10
        Me.txtDescuentoPor.Texto = Nothing
        Me.txtDescuentoPor.TipoTexto = SICO.ctrla.TiposTexto.Entero
        Me.txtDescuentoPor.ValorInt = Nothing
        Me.txtDescuentoPor.ValorLong = Nothing
        '
        'cmbTiposFacturas
        '
        Me.cmbTiposFacturas.CargarAutoCompletar = False
        Me.cmbTiposFacturas.CargarComboBox = True
        Me.cmbTiposFacturas.DisplayMember = "descripcion"
        Me.cmbTiposFacturas.Enabled = False
        Me.cmbTiposFacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTiposFacturas.FormattingEnabled = True
        Me.cmbTiposFacturas.Location = New System.Drawing.Point(325, 22)
        Me.cmbTiposFacturas.Name = "cmbTiposFacturas"
        Me.cmbTiposFacturas.ParametroAutocompletar = Nothing
        Me.cmbTiposFacturas.ParametroBusquedaPadre = Nothing
        Me.cmbTiposFacturas.Size = New System.Drawing.Size(129, 21)
        Me.cmbTiposFacturas.TabIndex = 8
        Me.cmbTiposFacturas.ValueMember = "id"
        '
        'CrtClientes1
        '
        Me.CrtClientes1.CargarClientePorPersona = False
        Me.CrtClientes1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtClientes1.Location = New System.Drawing.Point(3, 16)
        Me.CrtClientes1.Name = "CrtClientes1"
        Me.CrtClientes1.Size = New System.Drawing.Size(725, 143)
        Me.CrtClientes1.TabIndex = 0
        Me.CrtClientes1.VisibleDatosSecundarios = False
        '
        'CrtPanelBase1
        '
        Me.CrtPanelBase1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CrtPanelBase1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBase1.Name = "CrtPanelBase1"
        Me.CrtPanelBase1.Size = New System.Drawing.Size(807, 89)
        Me.CrtPanelBase1.TabIndex = 13
        Me.CrtPanelBase1.Titulo = "Venta"
        Me.CrtPanelBase1.VisiblePanelPrincipal = True
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 558)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(807, 56)
        Me.PanelAccion1.TabIndex = 14
        Me.PanelAccion1.Titulo = "Orden de Compra"
        Me.PanelAccion1.VisiblePanelPrincipal = False
        '
        'frmVentaMotocicleta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(807, 614)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrtPanelBase1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(823, 500)
        Me.Name = "frmVentaMotocicleta"
        Me.Text = "Venta Motocicleta"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents CrtPanelBase1 As SICO.ctrla.ControlesPersonalizados.crtPanelBase
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAnio As SICO.ctrla.CajaTexto
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCilindraje As SICO.ctrla.CajaTexto
    Friend WithEvents txtChasis As SICO.ctrla.CajaTexto
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMotor As SICO.ctrla.CajaTexto
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtClientes1 As SICO.ctrla2.crtClientes
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrecioVenta As SICO.ctrla.CajaTexto
    Friend WithEvents cmbTipoMotocicleta As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbModelo As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbMarca As SICO.ctrla.ListaDesplegable
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblNumeroFactura As System.Windows.Forms.Label
    Friend WithEvents chkVentaExcenta As System.Windows.Forms.CheckBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbTiposFacturas As SICO.ctrla.ListaDesplegable
    Friend WithEvents txtDescuentoPor As SiCo.ctrla.CajaTexto
End Class

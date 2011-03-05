<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturacion
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacion))
        Dim TipoIdentidad3 As SICO.lgla.TipoIdentidad = New SICO.lgla.TipoIdentidad
        Dim TipoIdentidad4 As SICO.lgla.TipoIdentidad = New SICO.lgla.TipoIdentidad
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.inventario = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrecioVenta = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBox8 = New System.Windows.Forms.TextBox
        Me.TextBox7 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CrtPersonaNatural1 = New SICO.ctrla2.crtPersonaNatural
        Me.txtApellidos = New SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.txtNombre = New SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.txtrtn = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtCorreo = New SICO.ctrla.CorreoCajaTexto(Me.components)
        Me.txtdireccion = New SICO.ctrla.CajaTexto(Me.components)
        Me.txttelefono = New SICO.ctrla.CajaTexto(Me.components)
        Me.cmbTipoIdentidad = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.txtidentifiacion = New SICO.ctrla.IdentidadCajaTexto(Me.components)
        Me.AutoCompleteCajaTexto1 = New SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.AutoCompleteCajaTexto2 = New SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.CajaTexto1 = New SICO.ctrla.CajaTexto(Me.components)
        Me.CorreoCajaTexto1 = New SICO.ctrla.CorreoCajaTexto(Me.components)
        Me.CajaTexto2 = New SICO.ctrla.CajaTexto(Me.components)
        Me.CajaTexto3 = New SICO.ctrla.CajaTexto(Me.components)
        Me.ListaDesplegable1 = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.IdentidadCajaTexto1 = New SICO.ctrla.IdentidadCajaTexto(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.CrtPanelBase1 = New SICO.ctrla.ControlesPersonalizados.crtPanelBase
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.CrtPersonaNatural1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 272)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(980, 246)
        Me.Panel2.TabIndex = 16
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.DataGridView1)
        Me.GroupBox5.Controls.Add(Me.Panel7)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(916, 246)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Productos"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.codigo, Me.descripcion, Me.cantidad, Me.inventario, Me.PrecioVenta})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(910, 82)
        Me.DataGridView1.TabIndex = 0
        '
        'codigo
        '
        Me.codigo.HeaderText = "Código"
        Me.codigo.Name = "codigo"
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        '
        'inventario
        '
        Me.inventario.HeaderText = "Existencia"
        Me.inventario.Name = "inventario"
        '
        'PrecioVenta
        '
        Me.PrecioVenta.HeaderText = "Precio Venta"
        Me.PrecioVenta.Name = "PrecioVenta"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 98)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(910, 145)
        Me.Panel7.TabIndex = 9
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Controls.Add(Me.TextBox2)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.TextBox1)
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.TextBox5)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.TextBox4)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.TextBox3)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(574, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(336, 145)
        Me.Panel8.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Desc"
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(168, 61)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(165, 20)
        Me.TextBox2.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Desc (%)"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(168, 35)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(165, 20)
        Me.TextBox1.TabIndex = 7
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
        'TextBox5
        '
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(168, 113)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(165, 20)
        Me.TextBox5.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(104, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Impuesto"
        '
        'TextBox4
        '
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(168, 87)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(165, 20)
        Me.TextBox4.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(104, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Total"
        '
        'TextBox3
        '
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(168, 9)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(165, 20)
        Me.TextBox3.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(947, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(33, 246)
        Me.Panel4.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(31, 246)
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
        Me.Panel1.Size = New System.Drawing.Size(980, 183)
        Me.Panel1.TabIndex = 15
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(916, 177)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Venta"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TextBox8)
        Me.GroupBox3.Controls.Add(Me.TextBox7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(534, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 152)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Factura"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(105, 99)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(89, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Venta exenta"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(105, 71)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(233, 21)
        Me.ComboBox1.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Tipo factura"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Código"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(105, 45)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(233, 20)
        Me.TextBox8.TabIndex = 2
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(105, 19)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(233, 20)
        Me.TextBox7.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Número factura"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(52, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(257, 20)
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
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 51)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 120)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(6, 19)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(503, 91)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.CrtPersonaNatural1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(495, 65)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Persona Naturales"
        '
        'CrtPersonaNatural1
        '
        Me.CrtPersonaNatural1.Controls.Add(Me.txtApellidos)
        Me.CrtPersonaNatural1.Controls.Add(Me.txtNombre)
        Me.CrtPersonaNatural1.Controls.Add(Me.txtrtn)
        Me.CrtPersonaNatural1.Controls.Add(Me.txtCorreo)
        Me.CrtPersonaNatural1.Controls.Add(Me.txtdireccion)
        Me.CrtPersonaNatural1.Controls.Add(Me.txttelefono)
        Me.CrtPersonaNatural1.Controls.Add(Me.cmbTipoIdentidad)
        Me.CrtPersonaNatural1.Controls.Add(Me.txtidentifiacion)
        Me.CrtPersonaNatural1.Controls.Add(Me.AutoCompleteCajaTexto1)
        Me.CrtPersonaNatural1.Controls.Add(Me.AutoCompleteCajaTexto2)
        Me.CrtPersonaNatural1.Controls.Add(Me.CajaTexto1)
        Me.CrtPersonaNatural1.Controls.Add(Me.CorreoCajaTexto1)
        Me.CrtPersonaNatural1.Controls.Add(Me.CajaTexto2)
        Me.CrtPersonaNatural1.Controls.Add(Me.CajaTexto3)
        Me.CrtPersonaNatural1.Controls.Add(Me.ListaDesplegable1)
        Me.CrtPersonaNatural1.Controls.Add(Me.IdentidadCajaTexto1)
        Me.CrtPersonaNatural1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaNatural1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaNatural1.Location = New System.Drawing.Point(3, 3)
        Me.CrtPersonaNatural1.Name = "CrtPersonaNatural1"
        Me.CrtPersonaNatural1.Size = New System.Drawing.Size(487, 57)
        Me.CrtPersonaNatural1.TabIndex = 0
        '
        'txtApellidos
        '
        Me.txtApellidos.AutoCompletar = True
        Me.txtApellidos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtApellidos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtApellidos.CampoMostrar = "apellidos"
        Me.txtApellidos.CaracteresInicio = 3
        Me.txtApellidos.ColeccionParametros = CType(resources.GetObject("txtApellidos.ColeccionParametros"), System.Collections.Generic.List(Of SICO.lgla.Parametro))
        Me.txtApellidos.ColorError = System.Drawing.Color.Red
        Me.txtApellidos.EsObligatorio = False
        Me.txtApellidos.ExpresionValidacion = Nothing
        Me.txtApellidos.Location = New System.Drawing.Point(102, 33)
        Me.txtApellidos.MaxLength = 255
        Me.txtApellidos.MensajeError = Nothing
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.ParameteroBusqueda = "apellidos"
        Me.txtApellidos.Procedimiento = "PersonaNatural_Buscar"
        Me.txtApellidos.Size = New System.Drawing.Size(380, 20)
        Me.txtApellidos.TabIndex = 33
        Me.txtApellidos.Texto = Nothing
        Me.txtApellidos.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'txtNombre
        '
        Me.txtNombre.AutoCompletar = True
        Me.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNombre.CampoMostrar = "NombreCompleto"
        Me.txtNombre.CaracteresInicio = 3
        Me.txtNombre.ColeccionParametros = CType(resources.GetObject("txtNombre.ColeccionParametros"), System.Collections.Generic.List(Of SICO.lgla.Parametro))
        Me.txtNombre.ColorError = System.Drawing.Color.Red
        Me.txtNombre.EsObligatorio = False
        Me.txtNombre.ExpresionValidacion = Nothing
        Me.txtNombre.Location = New System.Drawing.Point(102, 7)
        Me.txtNombre.MaxLength = 255
        Me.txtNombre.MensajeError = Nothing
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ParameteroBusqueda = "NombreCompleto"
        Me.txtNombre.Procedimiento = "PersonaNatural_Buscar"
        Me.txtNombre.Size = New System.Drawing.Size(380, 20)
        Me.txtNombre.TabIndex = 32
        Me.txtNombre.Texto = Nothing
        Me.txtNombre.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'txtrtn
        '
        Me.txtrtn.ColorError = System.Drawing.Color.Red
        Me.txtrtn.EsObligatorio = False
        Me.txtrtn.ExpresionValidacion = Nothing
        Me.txtrtn.Location = New System.Drawing.Point(102, 236)
        Me.txtrtn.MaxLength = 255
        Me.txtrtn.MensajeError = Nothing
        Me.txtrtn.Name = "txtrtn"
        Me.txtrtn.Size = New System.Drawing.Size(380, 20)
        Me.txtrtn.TabIndex = 23
        Me.txtrtn.Texto = Nothing
        Me.txtrtn.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'txtCorreo
        '
        Me.txtCorreo.ColorError = System.Drawing.Color.Red
        Me.txtCorreo.EsObligatorio = False
        Me.txtCorreo.ExpresionValidacion = "^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" & _
            "-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" & _
            "9][0-9]|[1-9][0-9]|[0-9])\])$"
        Me.txtCorreo.Location = New System.Drawing.Point(102, 138)
        Me.txtCorreo.MaxLength = 255
        Me.txtCorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(380, 20)
        Me.txtCorreo.TabIndex = 22
        Me.txtCorreo.Texto = Nothing
        Me.txtCorreo.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'txtdireccion
        '
        Me.txtdireccion.ColorError = System.Drawing.Color.Red
        Me.txtdireccion.EsObligatorio = False
        Me.txtdireccion.ExpresionValidacion = Nothing
        Me.txtdireccion.Location = New System.Drawing.Point(102, 164)
        Me.txtdireccion.MensajeError = Nothing
        Me.txtdireccion.Multiline = True
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(380, 66)
        Me.txtdireccion.TabIndex = 21
        Me.txtdireccion.Texto = Nothing
        Me.txtdireccion.TipoTexto = SICO.ctrla.TiposTexto.Parrafo
        '
        'txttelefono
        '
        Me.txttelefono.ColorError = System.Drawing.Color.Red
        Me.txttelefono.EsObligatorio = False
        Me.txttelefono.ExpresionValidacion = Nothing
        Me.txttelefono.Location = New System.Drawing.Point(102, 112)
        Me.txttelefono.MaxLength = 255
        Me.txttelefono.MensajeError = Nothing
        Me.txttelefono.Multiline = True
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(380, 20)
        Me.txttelefono.TabIndex = 20
        Me.txttelefono.Texto = Nothing
        Me.txttelefono.TipoTexto = SICO.ctrla.TiposTexto.Parrafo
        '
        'cmbTipoIdentidad
        '
        Me.cmbTipoIdentidad.Comando = Nothing
        Me.cmbTipoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIdentidad.FormattingEnabled = True
        Me.cmbTipoIdentidad.ListaDesplegablePadre = Nothing
        Me.cmbTipoIdentidad.Location = New System.Drawing.Point(102, 85)
        Me.cmbTipoIdentidad.Name = "cmbTipoIdentidad"
        Me.cmbTipoIdentidad.Size = New System.Drawing.Size(380, 21)
        Me.cmbTipoIdentidad.TabIndex = 19
        '
        'txtidentifiacion
        '
        Me.txtidentifiacion.ColorError = System.Drawing.Color.Red
        Me.txtidentifiacion.EsObligatorio = False
        Me.txtidentifiacion.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]"
        Me.txtidentifiacion.Location = New System.Drawing.Point(102, 59)
        Me.txtidentifiacion.MaxLength = 255
        Me.txtidentifiacion.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232"
        Me.txtidentifiacion.Name = "txtidentifiacion"
        Me.txtidentifiacion.Size = New System.Drawing.Size(380, 20)
        Me.txtidentifiacion.TabIndex = 18
        Me.txtidentifiacion.Texto = Nothing
        TipoIdentidad3.Descripcion = "Identidad"
        TipoIdentidad3.Valor = "I"
        Me.txtidentifiacion.TipoIdentificacion = TipoIdentidad3
        Me.txtidentifiacion.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'AutoCompleteCajaTexto1
        '
        Me.AutoCompleteCajaTexto1.AutoCompletar = True
        Me.AutoCompleteCajaTexto1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.AutoCompleteCajaTexto1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.AutoCompleteCajaTexto1.CampoMostrar = "apellidos"
        Me.AutoCompleteCajaTexto1.CaracteresInicio = 3
        Me.AutoCompleteCajaTexto1.ColeccionParametros = CType(resources.GetObject("AutoCompleteCajaTexto1.ColeccionParametros"), System.Collections.Generic.List(Of SICO.lgla.Parametro))
        Me.AutoCompleteCajaTexto1.ColorError = System.Drawing.Color.Red
        Me.AutoCompleteCajaTexto1.EsObligatorio = False
        Me.AutoCompleteCajaTexto1.ExpresionValidacion = Nothing
        Me.AutoCompleteCajaTexto1.Location = New System.Drawing.Point(102, 33)
        Me.AutoCompleteCajaTexto1.MaxLength = 255
        Me.AutoCompleteCajaTexto1.MensajeError = Nothing
        Me.AutoCompleteCajaTexto1.Name = "AutoCompleteCajaTexto1"
        Me.AutoCompleteCajaTexto1.ParameteroBusqueda = "apellidos"
        Me.AutoCompleteCajaTexto1.Procedimiento = "PersonaNatural_Buscar"
        Me.AutoCompleteCajaTexto1.Size = New System.Drawing.Size(380, 20)
        Me.AutoCompleteCajaTexto1.TabIndex = 33
        Me.AutoCompleteCajaTexto1.Texto = Nothing
        Me.AutoCompleteCajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'AutoCompleteCajaTexto2
        '
        Me.AutoCompleteCajaTexto2.AutoCompletar = True
        Me.AutoCompleteCajaTexto2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.AutoCompleteCajaTexto2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.AutoCompleteCajaTexto2.CampoMostrar = "NombreCompleto"
        Me.AutoCompleteCajaTexto2.CaracteresInicio = 3
        Me.AutoCompleteCajaTexto2.ColeccionParametros = CType(resources.GetObject("AutoCompleteCajaTexto2.ColeccionParametros"), System.Collections.Generic.List(Of SICO.lgla.Parametro))
        Me.AutoCompleteCajaTexto2.ColorError = System.Drawing.Color.Red
        Me.AutoCompleteCajaTexto2.EsObligatorio = False
        Me.AutoCompleteCajaTexto2.ExpresionValidacion = Nothing
        Me.AutoCompleteCajaTexto2.Location = New System.Drawing.Point(102, 7)
        Me.AutoCompleteCajaTexto2.MaxLength = 255
        Me.AutoCompleteCajaTexto2.MensajeError = Nothing
        Me.AutoCompleteCajaTexto2.Name = "AutoCompleteCajaTexto2"
        Me.AutoCompleteCajaTexto2.ParameteroBusqueda = "NombreCompleto"
        Me.AutoCompleteCajaTexto2.Procedimiento = "PersonaNatural_Buscar"
        Me.AutoCompleteCajaTexto2.Size = New System.Drawing.Size(380, 20)
        Me.AutoCompleteCajaTexto2.TabIndex = 32
        Me.AutoCompleteCajaTexto2.Texto = Nothing
        Me.AutoCompleteCajaTexto2.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.Location = New System.Drawing.Point(102, 236)
        Me.CajaTexto1.MaxLength = 255
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(380, 20)
        Me.CajaTexto1.TabIndex = 23
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'CorreoCajaTexto1
        '
        Me.CorreoCajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CorreoCajaTexto1.EsObligatorio = False
        Me.CorreoCajaTexto1.ExpresionValidacion = "^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" & _
            "-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" & _
            "9][0-9]|[1-9][0-9]|[0-9])\])$"
        Me.CorreoCajaTexto1.Location = New System.Drawing.Point(102, 138)
        Me.CorreoCajaTexto1.MaxLength = 255
        Me.CorreoCajaTexto1.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.CorreoCajaTexto1.Name = "CorreoCajaTexto1"
        Me.CorreoCajaTexto1.Size = New System.Drawing.Size(380, 20)
        Me.CorreoCajaTexto1.TabIndex = 22
        Me.CorreoCajaTexto1.Texto = Nothing
        Me.CorreoCajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'CajaTexto2
        '
        Me.CajaTexto2.ColorError = System.Drawing.Color.Red
        Me.CajaTexto2.EsObligatorio = False
        Me.CajaTexto2.ExpresionValidacion = Nothing
        Me.CajaTexto2.Location = New System.Drawing.Point(102, 164)
        Me.CajaTexto2.MensajeError = Nothing
        Me.CajaTexto2.Multiline = True
        Me.CajaTexto2.Name = "CajaTexto2"
        Me.CajaTexto2.Size = New System.Drawing.Size(380, 66)
        Me.CajaTexto2.TabIndex = 21
        Me.CajaTexto2.Texto = Nothing
        Me.CajaTexto2.TipoTexto = SICO.ctrla.TiposTexto.Parrafo
        '
        'CajaTexto3
        '
        Me.CajaTexto3.ColorError = System.Drawing.Color.Red
        Me.CajaTexto3.EsObligatorio = False
        Me.CajaTexto3.ExpresionValidacion = Nothing
        Me.CajaTexto3.Location = New System.Drawing.Point(102, 112)
        Me.CajaTexto3.MaxLength = 255
        Me.CajaTexto3.MensajeError = Nothing
        Me.CajaTexto3.Multiline = True
        Me.CajaTexto3.Name = "CajaTexto3"
        Me.CajaTexto3.Size = New System.Drawing.Size(380, 20)
        Me.CajaTexto3.TabIndex = 20
        Me.CajaTexto3.Texto = Nothing
        Me.CajaTexto3.TipoTexto = SICO.ctrla.TiposTexto.Parrafo
        '
        'ListaDesplegable1
        '
        Me.ListaDesplegable1.Comando = Nothing
        Me.ListaDesplegable1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListaDesplegable1.FormattingEnabled = True
        Me.ListaDesplegable1.ListaDesplegablePadre = Nothing
        Me.ListaDesplegable1.Location = New System.Drawing.Point(102, 85)
        Me.ListaDesplegable1.Name = "ListaDesplegable1"
        Me.ListaDesplegable1.Size = New System.Drawing.Size(380, 21)
        Me.ListaDesplegable1.TabIndex = 19
        '
        'IdentidadCajaTexto1
        '
        Me.IdentidadCajaTexto1.ColorError = System.Drawing.Color.Red
        Me.IdentidadCajaTexto1.EsObligatorio = False
        Me.IdentidadCajaTexto1.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]"
        Me.IdentidadCajaTexto1.Location = New System.Drawing.Point(102, 59)
        Me.IdentidadCajaTexto1.MaxLength = 255
        Me.IdentidadCajaTexto1.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232"
        Me.IdentidadCajaTexto1.Name = "IdentidadCajaTexto1"
        Me.IdentidadCajaTexto1.Size = New System.Drawing.Size(380, 20)
        Me.IdentidadCajaTexto1.TabIndex = 18
        Me.IdentidadCajaTexto1.Texto = Nothing
        TipoIdentidad4.Descripcion = "Identidad"
        TipoIdentidad4.Valor = "I"
        Me.IdentidadCajaTexto1.TipoIdentificacion = TipoIdentidad4
        Me.IdentidadCajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.TextBox6)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(495, 65)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Personas Jurídicas"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(80, 11)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(407, 20)
        Me.TextBox6.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Razón social"
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(947, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(33, 183)
        Me.Panel5.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(31, 183)
        Me.Panel6.TabIndex = 0
        '
        'CrtPanelBase1
        '
        Me.CrtPanelBase1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CrtPanelBase1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBase1.Name = "CrtPanelBase1"
        Me.CrtPanelBase1.Size = New System.Drawing.Size(980, 89)
        Me.CrtPanelBase1.TabIndex = 13
        Me.CrtPanelBase1.Titulo = "Facturacion"
        Me.CrtPanelBase1.VisiblePanelPrincipal = True
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 518)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(980, 56)
        Me.PanelAccion1.TabIndex = 14
        Me.PanelAccion1.Titulo = "Orden de Compra"
        Me.PanelAccion1.VisiblePanelPrincipal = False
        '
        'frmFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 574)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrtPanelBase1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(996, 612)
        Me.Name = "frmFacturacion"
        Me.Text = "Facturación"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.CrtPersonaNatural1.ResumeLayout(False)
        Me.CrtPersonaNatural1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inventario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CrtPersonaNatural1 As SICO.ctrla2.crtPersonaNatural
    Friend WithEvents txtApellidos As SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Friend WithEvents txtNombre As SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Friend WithEvents txtrtn As SICO.ctrla.CajaTexto
    Friend WithEvents txtCorreo As SICO.ctrla.CorreoCajaTexto
    Friend WithEvents txtdireccion As SICO.ctrla.CajaTexto
    Friend WithEvents txttelefono As SICO.ctrla.CajaTexto
    Friend WithEvents cmbTipoIdentidad As SICO.ctrla.ListaDesplegable
    Friend WithEvents txtidentifiacion As SICO.ctrla.IdentidadCajaTexto
    Friend WithEvents AutoCompleteCajaTexto1 As SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Friend WithEvents AutoCompleteCajaTexto2 As SICO.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Friend WithEvents CajaTexto1 As SICO.ctrla.CajaTexto
    Friend WithEvents CorreoCajaTexto1 As SICO.ctrla.CorreoCajaTexto
    Friend WithEvents CajaTexto2 As SICO.ctrla.CajaTexto
    Friend WithEvents CajaTexto3 As SICO.ctrla.CajaTexto
    Friend WithEvents ListaDesplegable1 As SICO.ctrla.ListaDesplegable
    Friend WithEvents IdentidadCajaTexto1 As SICO.ctrla.IdentidadCajaTexto
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents CrtPanelBase1 As SICO.ctrla.ControlesPersonalizados.crtPanelBase
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class

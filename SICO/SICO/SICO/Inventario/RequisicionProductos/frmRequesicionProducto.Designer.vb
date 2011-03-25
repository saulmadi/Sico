<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequesicionProducto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRequesicionProducto))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.grid = New SICO.ctrla.Grid(Me.components)
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalProductos = New System.Windows.Forms.TextBox
        Me.txtTotalItems = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblestado = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.txtcorreorecibidopor = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmbSucursales = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.txtsucursalrecibe = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtsucuralenvia = New SICO.ctrla.CajaTexto(Me.components)
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.dteFechaemision = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtcorreoenviadopor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.CrtPanelBase1 = New SICO.ctrla.ControlesPersonalizados.crtPanelBase
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.txtrecibidopor = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtenviadopor = New SICO.ctrla.CajaTexto(Me.components)
        Me.Panel2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 284)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(869, 276)
        Me.Panel2.TabIndex = 12
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.grid)
        Me.GroupBox5.Controls.Add(Me.Panel7)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(805, 276)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Productos"
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid.BotonBuscar = False
        Me.grid.BotonEditar = False
        Me.grid.BotonEliminar = False
        Me.grid.CampoId = Nothing
        Me.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(3, 16)
        Me.grid.MultiSelect = False
        Me.grid.Name = "grid"
        Me.grid.RowHeadersVisible = False
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grid.Size = New System.Drawing.Size(799, 194)
        Me.grid.TabIndex = 10
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel8)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(3, 210)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(799, 63)
        Me.Panel7.TabIndex = 9
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.txtTotalProductos)
        Me.Panel8.Controls.Add(Me.txtTotalItems)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(463, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(336, 63)
        Me.Panel8.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(62, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total Items"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(62, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Total Productos"
        '
        'txtTotalProductos
        '
        Me.txtTotalProductos.Enabled = False
        Me.txtTotalProductos.Location = New System.Drawing.Point(165, 29)
        Me.txtTotalProductos.Name = "txtTotalProductos"
        Me.txtTotalProductos.Size = New System.Drawing.Size(165, 20)
        Me.txtTotalProductos.TabIndex = 4
        '
        'txtTotalItems
        '
        Me.txtTotalItems.Enabled = False
        Me.txtTotalItems.Location = New System.Drawing.Point(165, 3)
        Me.txtTotalItems.Name = "txtTotalItems"
        Me.txtTotalItems.Size = New System.Drawing.Size(165, 20)
        Me.txtTotalItems.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(836, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(33, 276)
        Me.Panel4.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(31, 276)
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
        Me.Panel1.Size = New System.Drawing.Size(869, 195)
        Me.Panel1.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblestado)
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(31, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(805, 195)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'lblestado
        '
        Me.lblestado.Location = New System.Drawing.Point(492, 16)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(310, 13)
        Me.lblestado.TabIndex = 13
        Me.lblestado.Text = "lblestado"
        Me.lblestado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtrecibidopor)
        Me.GroupBox6.Controls.Add(Me.txtcorreorecibidopor)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Location = New System.Drawing.Point(431, 97)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(373, 75)
        Me.GroupBox6.TabIndex = 6
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Recibido por"
        '
        'txtcorreorecibidopor
        '
        Me.txtcorreorecibidopor.Enabled = False
        Me.txtcorreorecibidopor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcorreorecibidopor.Location = New System.Drawing.Point(61, 45)
        Me.txtcorreorecibidopor.Name = "txtcorreorecibidopor"
        Me.txtcorreorecibidopor.Size = New System.Drawing.Size(300, 20)
        Me.txtcorreorecibidopor.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Correo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Usuario"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbSucursales)
        Me.GroupBox3.Controls.Add(Me.txtsucursalrecibe)
        Me.GroupBox3.Controls.Add(Me.txtsucuralenvia)
        Me.GroupBox3.Controls.Add(Me.TextBox6)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.dteFechaemision)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(423, 147)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de requisición"
        '
        'cmbSucursales
        '
        Me.cmbSucursales.CargarAutoCompletar = False
        Me.cmbSucursales.CargarComboBox = True
        Me.cmbSucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.Location = New System.Drawing.Point(110, 71)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.ParametroAutocompletar = Nothing
        Me.cmbSucursales.ParametroBusquedaPadre = Nothing
        Me.cmbSucursales.SelectedItem = Nothing
        Me.cmbSucursales.Size = New System.Drawing.Size(300, 21)
        Me.cmbSucursales.TabIndex = 16
        Me.cmbSucursales.Visible = False
        '
        'txtsucursalrecibe
        '
        Me.txtsucursalrecibe.BackColor = System.Drawing.SystemColors.Window
        Me.txtsucursalrecibe.ColorError = System.Drawing.Color.Red
        Me.txtsucursalrecibe.Enabled = False
        Me.txtsucursalrecibe.EnterPorTab = True
        Me.txtsucursalrecibe.EsObligatorio = False
        Me.txtsucursalrecibe.ExpresionValidacion = Nothing
        Me.txtsucursalrecibe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtsucursalrecibe.Location = New System.Drawing.Point(110, 72)
        Me.txtsucursalrecibe.MensajeError = Nothing
        Me.txtsucursalrecibe.Name = "txtsucursalrecibe"
        Me.txtsucursalrecibe.Size = New System.Drawing.Size(300, 20)
        Me.txtsucursalrecibe.TabIndex = 15
        Me.txtsucursalrecibe.Texto = Nothing
        Me.txtsucursalrecibe.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtsucursalrecibe.ValorInt = Nothing
        Me.txtsucursalrecibe.ValorLong = Nothing
        '
        'txtsucuralenvia
        '
        Me.txtsucuralenvia.BackColor = System.Drawing.SystemColors.Window
        Me.txtsucuralenvia.ColorError = System.Drawing.Color.Red
        Me.txtsucuralenvia.Enabled = False
        Me.txtsucuralenvia.EnterPorTab = True
        Me.txtsucuralenvia.EsObligatorio = False
        Me.txtsucuralenvia.ExpresionValidacion = Nothing
        Me.txtsucuralenvia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtsucuralenvia.Location = New System.Drawing.Point(110, 46)
        Me.txtsucuralenvia.MensajeError = Nothing
        Me.txtsucuralenvia.Name = "txtsucuralenvia"
        Me.txtsucuralenvia.Size = New System.Drawing.Size(300, 20)
        Me.txtsucuralenvia.TabIndex = 7
        Me.txtsucuralenvia.Texto = Nothing
        Me.txtsucuralenvia.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtsucuralenvia.ValorInt = Nothing
        Me.txtsucuralenvia.ValorLong = Nothing
        '
        'TextBox6
        '
        Me.TextBox6.Enabled = False
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(110, 20)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(300, 20)
        Me.TextBox6.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(97, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Número requisición"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Sucursal solicitante"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Fecha de emisión"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Sucursal destino"
        '
        'dteFechaemision
        '
        Me.dteFechaemision.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dteFechaemision.Location = New System.Drawing.Point(110, 98)
        Me.dteFechaemision.Name = "dteFechaemision"
        Me.dteFechaemision.Size = New System.Drawing.Size(300, 20)
        Me.dteFechaemision.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtenviadopor)
        Me.GroupBox2.Controls.Add(Me.txtcorreoenviadopor)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(431, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(373, 75)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Enviado por"
        '
        'txtcorreoenviadopor
        '
        Me.txtcorreoenviadopor.Enabled = False
        Me.txtcorreoenviadopor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcorreoenviadopor.Location = New System.Drawing.Point(61, 45)
        Me.txtcorreoenviadopor.Name = "txtcorreoenviadopor"
        Me.txtcorreoenviadopor.Size = New System.Drawing.Size(300, 20)
        Me.txtcorreoenviadopor.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Correo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario"
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(836, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(33, 195)
        Me.Panel5.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(31, 195)
        Me.Panel6.TabIndex = 0
        '
        'CrtPanelBase1
        '
        Me.CrtPanelBase1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CrtPanelBase1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBase1.Name = "CrtPanelBase1"
        Me.CrtPanelBase1.Size = New System.Drawing.Size(869, 89)
        Me.CrtPanelBase1.TabIndex = 9
        Me.CrtPanelBase1.Titulo = "Requisición Productos "
        Me.CrtPanelBase1.VisiblePanelPrincipal = True
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 560)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(869, 56)
        Me.PanelAccion1.TabIndex = 10
        Me.PanelAccion1.Titulo = "Orden de Compra"
        Me.PanelAccion1.VisiblePanelPrincipal = False
        '
        'txtrecibidopor
        '
        Me.txtrecibidopor.BackColor = System.Drawing.SystemColors.Window
        Me.txtrecibidopor.ColorError = System.Drawing.Color.Red
        Me.txtrecibidopor.Enabled = False
        Me.txtrecibidopor.EnterPorTab = True
        Me.txtrecibidopor.EsObligatorio = False
        Me.txtrecibidopor.ExpresionValidacion = Nothing
        Me.txtrecibidopor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtrecibidopor.Location = New System.Drawing.Point(61, 19)
        Me.txtrecibidopor.MensajeError = Nothing
        Me.txtrecibidopor.Name = "txtrecibidopor"
        Me.txtrecibidopor.Size = New System.Drawing.Size(300, 20)
        Me.txtrecibidopor.TabIndex = 7
        Me.txtrecibidopor.Texto = Nothing
        Me.txtrecibidopor.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtrecibidopor.ValorInt = Nothing
        Me.txtrecibidopor.ValorLong = Nothing
        '
        'txtenviadopor
        '
        Me.txtenviadopor.BackColor = System.Drawing.SystemColors.Window
        Me.txtenviadopor.ColorError = System.Drawing.Color.Red
        Me.txtenviadopor.Enabled = False
        Me.txtenviadopor.EnterPorTab = True
        Me.txtenviadopor.EsObligatorio = False
        Me.txtenviadopor.ExpresionValidacion = Nothing
        Me.txtenviadopor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtenviadopor.Location = New System.Drawing.Point(61, 19)
        Me.txtenviadopor.MensajeError = Nothing
        Me.txtenviadopor.Name = "txtenviadopor"
        Me.txtenviadopor.Size = New System.Drawing.Size(300, 20)
        Me.txtenviadopor.TabIndex = 6
        Me.txtenviadopor.Texto = Nothing
        Me.txtenviadopor.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtenviadopor.ValorInt = Nothing
        Me.txtenviadopor.ValorLong = Nothing
        '
        'frmRequesicionProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 616)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CrtPanelBase1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(885, 654)
        Me.Name = "frmRequesicionProducto"
        Me.Text = "Requisición Productos"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalProductos As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalItems As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dteFechaemision As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcorreoenviadopor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents CrtPanelBase1 As SICO.ctrla.ControlesPersonalizados.crtPanelBase
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcorreorecibidopor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtsucursalrecibe As SiCo.ctrla.CajaTexto
    Friend WithEvents txtsucuralenvia As SICO.ctrla.CajaTexto
    Friend WithEvents cmbSucursales As SICO.ctrla.ControlesBasicos.ListaSucursales
    Friend WithEvents grid As SICO.ctrla.Grid
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents txtrecibidopor As SICO.ctrla.CajaTexto
    Friend WithEvents txtenviadopor As SICO.ctrla.CajaTexto
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotociletas
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
        Dim Imagenes1 As SICO.lgla2.Imagenes = New SICO.lgla2.Imagenes
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotociletas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CrtImagen1 = New SICO.ctrla.ControlesPersonalizados.crtImagen
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label13 = New System.Windows.Forms.Label
        Me.CajaTexto9 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.CajaTexto5 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CajaTexto3 = New SICO.ctrla.CajaTexto(Me.components)
        Me.CajaTexto2 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.CajaTexto1 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.CajaTexto6 = New SICO.ctrla.CajaTexto(Me.components)
        Me.CajaTexto4 = New SICO.ctrla.CajaTexto(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.cmbMarca = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbModelo = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbTipoMotocicleta = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbSucursales = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.cmbProveedor = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CrtImagen1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(199, 201)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Imagen"
        '
        'CrtImagen1
        '
        Me.CrtImagen1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtImagen1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Imagenes1.Id = CType(0, Long)
        Imagenes1.IdImagenes = CType(0, Long)
        Imagenes1.ImagenBinaria = Nothing
        Imagenes1.TablaBusqueda = "ProductosImagenes"
        Me.CrtImagen1.Imagenes = Imagenes1
        Me.CrtImagen1.Location = New System.Drawing.Point(3, 16)
        Me.CrtImagen1.Name = "CrtImagen1"
        Me.CrtImagen1.Size = New System.Drawing.Size(193, 182)
        Me.CrtImagen1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(217, 90)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(473, 259)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.cmbTipoMotocicleta)
        Me.TabPage1.Controls.Add(Me.cmbModelo)
        Me.TabPage1.Controls.Add(Me.cmbMarca)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.CajaTexto9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.CajaTexto5)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.CajaTexto3)
        Me.TabPage1.Controls.Add(Me.CajaTexto2)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.CajaTexto1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(465, 233)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos Generales"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Horse Power"
        '
        'CajaTexto9
        '
        Me.CajaTexto9.ColorError = System.Drawing.Color.Red
        Me.CajaTexto9.EnterPorTab = True
        Me.CajaTexto9.EsObligatorio = False
        Me.CajaTexto9.ExpresionValidacion = Nothing
        Me.CajaTexto9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto9.Location = New System.Drawing.Point(112, 89)
        Me.CajaTexto9.MaxLength = 255
        Me.CajaTexto9.MensajeError = Nothing
        Me.CajaTexto9.Name = "CajaTexto9"
        Me.CajaTexto9.Size = New System.Drawing.Size(335, 20)
        Me.CajaTexto9.TabIndex = 32
        Me.CajaTexto9.Texto = Nothing
        Me.CajaTexto9.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto9.ValorInt = Nothing
        Me.CajaTexto9.ValorLong = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Año"
        '
        'CajaTexto5
        '
        Me.CajaTexto5.ColorError = System.Drawing.Color.Red
        Me.CajaTexto5.EnterPorTab = True
        Me.CajaTexto5.EsObligatorio = False
        Me.CajaTexto5.ExpresionValidacion = Nothing
        Me.CajaTexto5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto5.Location = New System.Drawing.Point(112, 115)
        Me.CajaTexto5.MaxLength = 255
        Me.CajaTexto5.MensajeError = Nothing
        Me.CajaTexto5.Name = "CajaTexto5"
        Me.CajaTexto5.Size = New System.Drawing.Size(335, 20)
        Me.CajaTexto5.TabIndex = 30
        Me.CajaTexto5.Texto = Nothing
        Me.CajaTexto5.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto5.ValorInt = Nothing
        Me.CajaTexto5.ValorLong = Nothing
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 198)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 13)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Tipo de motocicleta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Modelo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Marca"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Cilindraje"
        '
        'CajaTexto3
        '
        Me.CajaTexto3.ColorError = System.Drawing.Color.Red
        Me.CajaTexto3.EnterPorTab = True
        Me.CajaTexto3.EsObligatorio = False
        Me.CajaTexto3.ExpresionValidacion = Nothing
        Me.CajaTexto3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto3.Location = New System.Drawing.Point(112, 63)
        Me.CajaTexto3.MaxLength = 255
        Me.CajaTexto3.MensajeError = Nothing
        Me.CajaTexto3.Name = "CajaTexto3"
        Me.CajaTexto3.Size = New System.Drawing.Size(335, 20)
        Me.CajaTexto3.TabIndex = 20
        Me.CajaTexto3.Texto = Nothing
        Me.CajaTexto3.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto3.ValorInt = Nothing
        Me.CajaTexto3.ValorLong = Nothing
        '
        'CajaTexto2
        '
        Me.CajaTexto2.ColorError = System.Drawing.Color.Red
        Me.CajaTexto2.EnterPorTab = True
        Me.CajaTexto2.EsObligatorio = False
        Me.CajaTexto2.ExpresionValidacion = Nothing
        Me.CajaTexto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto2.Location = New System.Drawing.Point(112, 37)
        Me.CajaTexto2.MaxLength = 255
        Me.CajaTexto2.MensajeError = Nothing
        Me.CajaTexto2.Name = "CajaTexto2"
        Me.CajaTexto2.Size = New System.Drawing.Size(335, 20)
        Me.CajaTexto2.TabIndex = 19
        Me.CajaTexto2.Texto = Nothing
        Me.CajaTexto2.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto2.ValorInt = Nothing
        Me.CajaTexto2.ValorLong = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Chasis"
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EnterPorTab = True
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CajaTexto1.Location = New System.Drawing.Point(112, 11)
        Me.CajaTexto1.MaxLength = 255
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(335, 20)
        Me.CajaTexto1.TabIndex = 17
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto1.ValorInt = Nothing
        Me.CajaTexto1.ValorLong = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Motor"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.cmbProveedor)
        Me.TabPage2.Controls.Add(Me.cmbSucursales)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.DateTimePicker1)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.CajaTexto6)
        Me.TabPage2.Controls.Add(Me.CajaTexto4)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(465, 233)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Datos Adminístrativos"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Proveedor"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Sucursal"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(112, 69)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(335, 20)
        Me.DateTimePicker1.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Fecha de compra"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Precio de compra"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Precio de venta"
        '
        'CajaTexto6
        '
        Me.CajaTexto6.ColorError = System.Drawing.Color.Red
        Me.CajaTexto6.EnterPorTab = True
        Me.CajaTexto6.EsObligatorio = False
        Me.CajaTexto6.ExpresionValidacion = Nothing
        Me.CajaTexto6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto6.Location = New System.Drawing.Point(112, 43)
        Me.CajaTexto6.MaxLength = 255
        Me.CajaTexto6.MensajeError = Nothing
        Me.CajaTexto6.Name = "CajaTexto6"
        Me.CajaTexto6.Size = New System.Drawing.Size(335, 20)
        Me.CajaTexto6.TabIndex = 21
        Me.CajaTexto6.Texto = Nothing
        Me.CajaTexto6.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto6.ValorInt = Nothing
        Me.CajaTexto6.ValorLong = Nothing
        '
        'CajaTexto4
        '
        Me.CajaTexto4.ColorError = System.Drawing.Color.Red
        Me.CajaTexto4.EnterPorTab = True
        Me.CajaTexto4.EsObligatorio = False
        Me.CajaTexto4.ExpresionValidacion = Nothing
        Me.CajaTexto4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CajaTexto4.Location = New System.Drawing.Point(112, 17)
        Me.CajaTexto4.MaxLength = 255
        Me.CajaTexto4.MensajeError = Nothing
        Me.CajaTexto4.Name = "CajaTexto4"
        Me.CajaTexto4.Size = New System.Drawing.Size(335, 20)
        Me.CajaTexto4.TabIndex = 19
        Me.CajaTexto4.Texto = Nothing
        Me.CajaTexto4.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto4.ValorInt = Nothing
        Me.CajaTexto4.ValorLong = Nothing
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(503, 280)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Datos Generales"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(503, 280)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Datos Administrativos"
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(696, 432)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "Motocicletas"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'cmbMarca
        '
        Me.cmbMarca.CargarAutoCompletar = False
        Me.cmbMarca.CargarComboBox = True
        Me.cmbMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(112, 142)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.ParametroAutocompletar = Nothing
        Me.cmbMarca.ParametroBusquedaPadre = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(335, 21)
        Me.cmbMarca.TabIndex = 34
        '
        'cmbModelo
        '
        Me.cmbModelo.CargarAutoCompletar = False
        Me.cmbModelo.CargarComboBox = True
        Me.cmbModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModelo.FormattingEnabled = True
        Me.cmbModelo.Location = New System.Drawing.Point(112, 168)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.ParametroAutocompletar = Nothing
        Me.cmbModelo.ParametroBusquedaPadre = Nothing
        Me.cmbModelo.Size = New System.Drawing.Size(335, 21)
        Me.cmbModelo.TabIndex = 35
        '
        'cmbTipoMotocicleta
        '
        Me.cmbTipoMotocicleta.CargarAutoCompletar = False
        Me.cmbTipoMotocicleta.CargarComboBox = True
        Me.cmbTipoMotocicleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoMotocicleta.FormattingEnabled = True
        Me.cmbTipoMotocicleta.Location = New System.Drawing.Point(112, 195)
        Me.cmbTipoMotocicleta.Name = "cmbTipoMotocicleta"
        Me.cmbTipoMotocicleta.ParametroAutocompletar = Nothing
        Me.cmbTipoMotocicleta.ParametroBusquedaPadre = Nothing
        Me.cmbTipoMotocicleta.Size = New System.Drawing.Size(335, 21)
        Me.cmbTipoMotocicleta.TabIndex = 36
        '
        'cmbSucursales
        '
        Me.cmbSucursales.CargarAutoCompletar = False
        Me.cmbSucursales.CargarComboBox = True
        Me.cmbSucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.Location = New System.Drawing.Point(112, 95)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.ParametroAutocompletar = Nothing
        Me.cmbSucursales.ParametroBusquedaPadre = Nothing
        Me.cmbSucursales.SelectedItem = Nothing
        Me.cmbSucursales.Size = New System.Drawing.Size(335, 21)
        Me.cmbSucursales.TabIndex = 28
        '
        'cmbProveedor
        '
        Me.cmbProveedor.CargarAutoCompletar = False
        Me.cmbProveedor.CargarComboBox = True
        Me.cmbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(112, 124)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.ParametroAutocompletar = Nothing
        Me.cmbProveedor.ParametroBusquedaPadre = Nothing
        Me.cmbProveedor.Size = New System.Drawing.Size(335, 21)
        Me.cmbProveedor.TabIndex = 29
        '
        'frmMotociletas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 432)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMotociletas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motocicletas"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents CrtImagen1 As SICO.ctrla.ControlesPersonalizados.crtImagen
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto5 As SICO.ctrla.CajaTexto
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto3 As SICO.ctrla.CajaTexto
    Friend WithEvents CajaTexto2 As SICO.ctrla.CajaTexto
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto1 As SICO.ctrla.CajaTexto
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto6 As SICO.ctrla.CajaTexto
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto4 As SICO.ctrla.CajaTexto
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto9 As SICO.ctrla.CajaTexto
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMotocicleta As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbModelo As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbMarca As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbProveedor As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbSucursales As SICO.ctrla.ControlesBasicos.ListaSucursales
End Class

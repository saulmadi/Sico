<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuPrincipal))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuPrinci = New System.Windows.Forms.MenuStrip
        Me.FacturaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ControlCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AperturaDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IngresosDeEfectivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RetirosDeEfectivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CierreDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TransaccionesDeCajaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MotocicletasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FacturaciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DevolucionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.InventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComprasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OrdenesDeCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComprasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RequisicionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RequisicionesSalientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RequisicionesEntrantesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EstadoInventarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GlobalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SucursalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegistroDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CuentasPorCobrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AbonosACuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManejoDePagosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EstadosDeCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RegistroDeProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CuentasPorPagarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AbanosACuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ControlDePagosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EstadosDeCuentaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AdministrativoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SucursalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PersonasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PersonasNaturlaesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PersonasJurídicasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SICOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MunicipiosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DepartamentosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TiposDeFacturaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TipoDeMotocicletasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MarcasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModelosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SesiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CerrarSesesiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip.SuspendLayout()
        Me.MenuPrinci.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 711)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1041, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'MenuPrinci
        '
        Me.MenuPrinci.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuPrinci.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FacturaciónToolStripMenuItem, Me.InventarioToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.AdministrativoToolStripMenuItem, Me.SesiónToolStripMenuItem})
        Me.MenuPrinci.Location = New System.Drawing.Point(0, 0)
        Me.MenuPrinci.Name = "MenuPrinci"
        Me.MenuPrinci.ShowItemToolTips = True
        Me.MenuPrinci.Size = New System.Drawing.Size(1041, 24)
        Me.MenuPrinci.TabIndex = 9
        Me.MenuPrinci.Text = "MenuStrip1"
        '
        'FacturaciónToolStripMenuItem
        '
        Me.FacturaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ControlCajaToolStripMenuItem, Me.TransaccionesDeCajaToolStripMenuItem})
        Me.FacturaciónToolStripMenuItem.Name = "FacturaciónToolStripMenuItem"
        Me.FacturaciónToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.FacturaciónToolStripMenuItem.Text = "&Facturación"
        '
        'ControlCajaToolStripMenuItem
        '
        Me.ControlCajaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AperturaDeCajaToolStripMenuItem, Me.IngresosDeEfectivoToolStripMenuItem, Me.RetirosDeEfectivoToolStripMenuItem, Me.CierreDeCajaToolStripMenuItem})
        Me.ControlCajaToolStripMenuItem.Name = "ControlCajaToolStripMenuItem"
        Me.ControlCajaToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ControlCajaToolStripMenuItem.Text = "Control caja"
        '
        'AperturaDeCajaToolStripMenuItem
        '
        Me.AperturaDeCajaToolStripMenuItem.Name = "AperturaDeCajaToolStripMenuItem"
        Me.AperturaDeCajaToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.AperturaDeCajaToolStripMenuItem.Text = "Apertura de caja"
        '
        'IngresosDeEfectivoToolStripMenuItem
        '
        Me.IngresosDeEfectivoToolStripMenuItem.Name = "IngresosDeEfectivoToolStripMenuItem"
        Me.IngresosDeEfectivoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.IngresosDeEfectivoToolStripMenuItem.Text = "Ingresos de efectivo"
        '
        'RetirosDeEfectivoToolStripMenuItem
        '
        Me.RetirosDeEfectivoToolStripMenuItem.Name = "RetirosDeEfectivoToolStripMenuItem"
        Me.RetirosDeEfectivoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.RetirosDeEfectivoToolStripMenuItem.Text = "Retiros de efectivo"
        '
        'CierreDeCajaToolStripMenuItem
        '
        Me.CierreDeCajaToolStripMenuItem.Name = "CierreDeCajaToolStripMenuItem"
        Me.CierreDeCajaToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CierreDeCajaToolStripMenuItem.Text = "Cierre de caja"
        '
        'TransaccionesDeCajaToolStripMenuItem
        '
        Me.TransaccionesDeCajaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasToolStripMenuItem, Me.FacturaciónToolStripMenuItem1, Me.DevolucionesToolStripMenuItem1})
        Me.TransaccionesDeCajaToolStripMenuItem.Name = "TransaccionesDeCajaToolStripMenuItem"
        Me.TransaccionesDeCajaToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.TransaccionesDeCajaToolStripMenuItem.Text = "Transacciones de caja"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductosToolStripMenuItem1, Me.MotocicletasToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'ProductosToolStripMenuItem1
        '
        Me.ProductosToolStripMenuItem1.Name = "ProductosToolStripMenuItem1"
        Me.ProductosToolStripMenuItem1.Size = New System.Drawing.Size(142, 22)
        Me.ProductosToolStripMenuItem1.Text = "Productos"
        '
        'MotocicletasToolStripMenuItem
        '
        Me.MotocicletasToolStripMenuItem.Name = "MotocicletasToolStripMenuItem"
        Me.MotocicletasToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.MotocicletasToolStripMenuItem.Text = "Motocicletas"
        '
        'FacturaciónToolStripMenuItem1
        '
        Me.FacturaciónToolStripMenuItem1.Name = "FacturaciónToolStripMenuItem1"
        Me.FacturaciónToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.FacturaciónToolStripMenuItem1.Text = "Facturación"
        '
        'DevolucionesToolStripMenuItem1
        '
        Me.DevolucionesToolStripMenuItem1.Name = "DevolucionesToolStripMenuItem1"
        Me.DevolucionesToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.DevolucionesToolStripMenuItem1.Text = "Devoluciones"
        '
        'InventarioToolStripMenuItem
        '
        Me.InventarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductosToolStripMenuItem, Me.ComprasToolStripMenuItem, Me.RequisicionesToolStripMenuItem, Me.EstadoInventarioToolStripMenuItem})
        Me.InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        Me.InventarioToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.InventarioToolStripMenuItem.Text = "&Inventario"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'ComprasToolStripMenuItem
        '
        Me.ComprasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdenesDeCompraToolStripMenuItem, Me.ComprasToolStripMenuItem1})
        Me.ComprasToolStripMenuItem.Name = "ComprasToolStripMenuItem"
        Me.ComprasToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.ComprasToolStripMenuItem.Text = "Control de compras"
        '
        'OrdenesDeCompraToolStripMenuItem
        '
        Me.OrdenesDeCompraToolStripMenuItem.Name = "OrdenesDeCompraToolStripMenuItem"
        Me.OrdenesDeCompraToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.OrdenesDeCompraToolStripMenuItem.Text = "Ordenes de compra"
        '
        'ComprasToolStripMenuItem1
        '
        Me.ComprasToolStripMenuItem1.Name = "ComprasToolStripMenuItem1"
        Me.ComprasToolStripMenuItem1.Size = New System.Drawing.Size(178, 22)
        Me.ComprasToolStripMenuItem1.Text = "Compras"
        '
        'RequisicionesToolStripMenuItem
        '
        Me.RequisicionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequisicionesSalientesToolStripMenuItem, Me.RequisicionesEntrantesToolStripMenuItem})
        Me.RequisicionesToolStripMenuItem.Name = "RequisicionesToolStripMenuItem"
        Me.RequisicionesToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.RequisicionesToolStripMenuItem.Text = "Requisicion de productos"
        '
        'RequisicionesSalientesToolStripMenuItem
        '
        Me.RequisicionesSalientesToolStripMenuItem.Name = "RequisicionesSalientesToolStripMenuItem"
        Me.RequisicionesSalientesToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.RequisicionesSalientesToolStripMenuItem.Text = "Requisiciones salientes"
        '
        'RequisicionesEntrantesToolStripMenuItem
        '
        Me.RequisicionesEntrantesToolStripMenuItem.Name = "RequisicionesEntrantesToolStripMenuItem"
        Me.RequisicionesEntrantesToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.RequisicionesEntrantesToolStripMenuItem.Text = "Requisiciones entrantes"
        '
        'EstadoInventarioToolStripMenuItem
        '
        Me.EstadoInventarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GlobalToolStripMenuItem, Me.SucursalToolStripMenuItem})
        Me.EstadoInventarioToolStripMenuItem.Name = "EstadoInventarioToolStripMenuItem"
        Me.EstadoInventarioToolStripMenuItem.Size = New System.Drawing.Size(208, 22)
        Me.EstadoInventarioToolStripMenuItem.Text = "Estado de inventario"
        '
        'GlobalToolStripMenuItem
        '
        Me.GlobalToolStripMenuItem.Name = "GlobalToolStripMenuItem"
        Me.GlobalToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.GlobalToolStripMenuItem.Text = "Global"
        '
        'SucursalToolStripMenuItem
        '
        Me.SucursalToolStripMenuItem.Name = "SucursalToolStripMenuItem"
        Me.SucursalToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.SucursalToolStripMenuItem.Text = "Sucursal"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroDeClientesToolStripMenuItem, Me.CuentasPorCobrarToolStripMenuItem})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'RegistroDeClientesToolStripMenuItem
        '
        Me.RegistroDeClientesToolStripMenuItem.Name = "RegistroDeClientesToolStripMenuItem"
        Me.RegistroDeClientesToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.RegistroDeClientesToolStripMenuItem.Text = "Registro de clientes"
        '
        'CuentasPorCobrarToolStripMenuItem
        '
        Me.CuentasPorCobrarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbonosACuentaToolStripMenuItem, Me.ManejoDePagosToolStripMenuItem, Me.EstadosDeCuentaToolStripMenuItem})
        Me.CuentasPorCobrarToolStripMenuItem.Name = "CuentasPorCobrarToolStripMenuItem"
        Me.CuentasPorCobrarToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.CuentasPorCobrarToolStripMenuItem.Text = "Cuentas por cobrar"
        '
        'AbonosACuentaToolStripMenuItem
        '
        Me.AbonosACuentaToolStripMenuItem.Name = "AbonosACuentaToolStripMenuItem"
        Me.AbonosACuentaToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AbonosACuentaToolStripMenuItem.Text = "Abonos a cuenta"
        '
        'ManejoDePagosToolStripMenuItem
        '
        Me.ManejoDePagosToolStripMenuItem.Name = "ManejoDePagosToolStripMenuItem"
        Me.ManejoDePagosToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ManejoDePagosToolStripMenuItem.Text = "Control de pagos"
        '
        'EstadosDeCuentaToolStripMenuItem
        '
        Me.EstadosDeCuentaToolStripMenuItem.Name = "EstadosDeCuentaToolStripMenuItem"
        Me.EstadosDeCuentaToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.EstadosDeCuentaToolStripMenuItem.Text = "Estados de cuenta"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistroDeProveedoresToolStripMenuItem, Me.CuentasPorPagarToolStripMenuItem})
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'RegistroDeProveedoresToolStripMenuItem
        '
        Me.RegistroDeProveedoresToolStripMenuItem.Name = "RegistroDeProveedoresToolStripMenuItem"
        Me.RegistroDeProveedoresToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.RegistroDeProveedoresToolStripMenuItem.Text = "Registro de proveedores"
        '
        'CuentasPorPagarToolStripMenuItem
        '
        Me.CuentasPorPagarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbanosACuentaToolStripMenuItem, Me.ControlDePagosToolStripMenuItem, Me.EstadosDeCuentaToolStripMenuItem1})
        Me.CuentasPorPagarToolStripMenuItem.Name = "CuentasPorPagarToolStripMenuItem"
        Me.CuentasPorPagarToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.CuentasPorPagarToolStripMenuItem.Text = "Cuentas por pagar"
        '
        'AbanosACuentaToolStripMenuItem
        '
        Me.AbanosACuentaToolStripMenuItem.Name = "AbanosACuentaToolStripMenuItem"
        Me.AbanosACuentaToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.AbanosACuentaToolStripMenuItem.Text = "Abonos a cuenta"
        '
        'ControlDePagosToolStripMenuItem
        '
        Me.ControlDePagosToolStripMenuItem.Name = "ControlDePagosToolStripMenuItem"
        Me.ControlDePagosToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ControlDePagosToolStripMenuItem.Text = "Control de pagos"
        '
        'EstadosDeCuentaToolStripMenuItem1
        '
        Me.EstadosDeCuentaToolStripMenuItem1.Name = "EstadosDeCuentaToolStripMenuItem1"
        Me.EstadosDeCuentaToolStripMenuItem1.Size = New System.Drawing.Size(169, 22)
        Me.EstadosDeCuentaToolStripMenuItem1.Text = "Estados de cuenta"
        '
        'AdministrativoToolStripMenuItem
        '
        Me.AdministrativoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SucursalesToolStripMenuItem, Me.UsuariosToolStripMenuItem, Me.PersonasToolStripMenuItem, Me.SICOToolStripMenuItem})
        Me.AdministrativoToolStripMenuItem.Name = "AdministrativoToolStripMenuItem"
        Me.AdministrativoToolStripMenuItem.Size = New System.Drawing.Size(97, 20)
        Me.AdministrativoToolStripMenuItem.Text = "Administrativo"
        '
        'SucursalesToolStripMenuItem
        '
        Me.SucursalesToolStripMenuItem.Name = "SucursalesToolStripMenuItem"
        Me.SucursalesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SucursalesToolStripMenuItem.Text = "Sucursales"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'PersonasToolStripMenuItem
        '
        Me.PersonasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonasNaturlaesToolStripMenuItem, Me.PersonasJurídicasToolStripMenuItem})
        Me.PersonasToolStripMenuItem.Name = "PersonasToolStripMenuItem"
        Me.PersonasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PersonasToolStripMenuItem.Text = "Personas"
        '
        'PersonasNaturlaesToolStripMenuItem
        '
        Me.PersonasNaturlaesToolStripMenuItem.Name = "PersonasNaturlaesToolStripMenuItem"
        Me.PersonasNaturlaesToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.PersonasNaturlaesToolStripMenuItem.Text = "Personas naturlaes"
        '
        'PersonasJurídicasToolStripMenuItem
        '
        Me.PersonasJurídicasToolStripMenuItem.Name = "PersonasJurídicasToolStripMenuItem"
        Me.PersonasJurídicasToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.PersonasJurídicasToolStripMenuItem.Text = "Personas jurídicas"
        '
        'SICOToolStripMenuItem
        '
        Me.SICOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MunicipiosToolStripMenuItem, Me.DepartamentosToolStripMenuItem, Me.TiposDeFacturaToolStripMenuItem, Me.TipoDeMotocicletasToolStripMenuItem, Me.MarcasToolStripMenuItem, Me.ModelosToolStripMenuItem})
        Me.SICOToolStripMenuItem.Name = "SICOToolStripMenuItem"
        Me.SICOToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SICOToolStripMenuItem.Text = "SICO"
        '
        'MunicipiosToolStripMenuItem
        '
        Me.MunicipiosToolStripMenuItem.Name = "MunicipiosToolStripMenuItem"
        Me.MunicipiosToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.MunicipiosToolStripMenuItem.Text = "Municipios"
        '
        'DepartamentosToolStripMenuItem
        '
        Me.DepartamentosToolStripMenuItem.Name = "DepartamentosToolStripMenuItem"
        Me.DepartamentosToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.DepartamentosToolStripMenuItem.Text = "Departamentos"
        '
        'TiposDeFacturaToolStripMenuItem
        '
        Me.TiposDeFacturaToolStripMenuItem.Name = "TiposDeFacturaToolStripMenuItem"
        Me.TiposDeFacturaToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.TiposDeFacturaToolStripMenuItem.Text = "Tipos de factura"
        '
        'TipoDeMotocicletasToolStripMenuItem
        '
        Me.TipoDeMotocicletasToolStripMenuItem.Name = "TipoDeMotocicletasToolStripMenuItem"
        Me.TipoDeMotocicletasToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.TipoDeMotocicletasToolStripMenuItem.Text = "Tipo de motocicletas"
        '
        'MarcasToolStripMenuItem
        '
        Me.MarcasToolStripMenuItem.Name = "MarcasToolStripMenuItem"
        Me.MarcasToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.MarcasToolStripMenuItem.Text = "Marcas de motocicletas"
        '
        'ModelosToolStripMenuItem
        '
        Me.ModelosToolStripMenuItem.Name = "ModelosToolStripMenuItem"
        Me.ModelosToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ModelosToolStripMenuItem.Text = "Modelos de motocicletas"
        '
        'SesiónToolStripMenuItem
        '
        Me.SesiónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSesesiónToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.SesiónToolStripMenuItem.Name = "SesiónToolStripMenuItem"
        Me.SesiónToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.SesiónToolStripMenuItem.Text = "Sesión"
        '
        'CerrarSesesiónToolStripMenuItem
        '
        Me.CerrarSesesiónToolStripMenuItem.Name = "CerrarSesesiónToolStripMenuItem"
        Me.CerrarSesesiónToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.CerrarSesesiónToolStripMenuItem.Text = "Cerrar Sesesión"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'frmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1041, 733)
        Me.ControlBox = False
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuPrinci)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuPrinci
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMenuPrincipal"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuPrinci.ResumeLayout(False)
        Me.MenuPrinci.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuPrinci As System.Windows.Forms.MenuStrip
    Friend WithEvents FacturaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdministrativoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SucursalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComprasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RequisicionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SesiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CerrarSesesiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentasPorCobrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbonosACuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManejoDePagosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadosDeCuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdenesDeCompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComprasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RequisicionesSalientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RequisicionesEntrantesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AperturaDeCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresosDeEfectivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RetirosDeEfectivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CierreDeCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaccionesDeCajaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MotocicletasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacturaciónToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DevolucionesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadoInventarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GlobalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SucursalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentasPorPagarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbanosACuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ControlDePagosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadosDeCuentaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SICOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MunicipiosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TiposDeFacturaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoDeMotocicletasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarcasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModelosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepartamentosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonasNaturlaesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonasJurídicasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

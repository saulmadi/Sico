Imports System.Windows.Forms

Public Class frmMenuPrincipal
#Region "Eventos"

#Region "Administrativo"

#Region "SICO"
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub MarcasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcasToolStripMenuItem.Click
        Dim frm As New frmMarcas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub TipoDeMotocicletasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeMotocicletasToolStripMenuItem.Click
        Dim frm As New frmTiposMotocicletas
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MunicipiosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MunicipiosToolStripMenuItem.Click
        Dim frm As New frmMunicipios
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub DepartamentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartamentosToolStripMenuItem.Click
        Dim frm As New frmDepartamentos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub TiposDeFacturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDeFacturaToolStripMenuItem.Click
        Dim frm As New frmTiposFacturas
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub ModelosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModelosToolStripMenuItem.Click
        Dim frm As New frmModelos
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub TarjetasCreditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TarjetasCreditoToolStripMenuItem.Click
        Dim frm As New frmTarjetaCredito
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PropietarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropietarioToolStripMenuItem.Click
        Dim frm As New frmPropietario
        frm.MdiParent = Me
        frm.Show()
    End Sub

#End Region

#Region "Personas"
    Private Sub PersonasNaturlaesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonasNaturlaesToolStripMenuItem.Click
        Dim frm As New frmPersonaNatural
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PersonasJurídicasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonasJurídicasToolStripMenuItem.Click
        Dim frm As New frmPersonaJuridica
        frm.MdiParent = Me
        frm.Show()
    End Sub
#End Region

    Private Sub SucursalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SucursalesToolStripMenuItem.Click
        Dim frm As New frmSucursales
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub UsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsuariosToolStripMenuItem.Click
        Dim frm As New frmUsuario
        frm.MdiParent = Me
        frm.Show()
    End Sub

#End Region

#Region "Proveedores"
    Private Sub RegistroDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroDeProveedoresToolStripMenuItem.Click
        Dim frm As New frmRegistroProveedores
        frm.MdiParent = Me
        frm.Show()
    End Sub
#End Region

#Region "Clientes"
    Private Sub RegistroDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroDeClientesToolStripMenuItem.Click
        Dim frm As New frmRegistroClientes
        frm.MdiParent = Me
        frm.Show()
    End Sub
#End Region

#Region "Inventario"
#Region "ControlCompras"
    Private Sub OrdenesDeCompraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenesDeCompraToolStripMenuItem.Click
        Dim frm As New frmBusquedaOrdenesCompra
        frm.MdiParent = Me
        frm.Show()
    End Sub
    Private Sub ComprasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprasToolStripMenuItem1.Click
        Dim frm As New frmBusquedaCompras
        frm.MdiParent = Me
        frm.Show()
    End Sub
#End Region

#Region "Requisiciones"

    Private Sub RequisicionesSalientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequisicionesSalientesToolStripMenuItem.Click
        Dim frm As New frmBusquedaRequsicion
        frm.MdiParent = Me
        frm.Enviadas = True
        frm.Show()
    End Sub

    Private Sub RequisicionesEntrantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RequisicionesEntrantesToolStripMenuItem.Click
        Dim frm As New frmBusquedaRequsicion
        frm.MdiParent = Me
        frm.Enviadas = False
        frm.Show()
    End Sub

#End Region

#Region "Ordenes de salida"
    Private Sub OrdenesSalientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenesSalientesToolStripMenuItem.Click
        Dim frm As New frmBusquedaOrdenSalida
        frm.MdiParent = Me
        frm.Enviadas = True
        frm.Show()
    End Sub

    Private Sub OrdenesEntrantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenesEntrantesToolStripMenuItem.Click
        Dim frm As New frmBusquedaOrdenSalida
        frm.MdiParent = Me
        frm.Enviadas = False
        frm.Show()
    End Sub

#End Region

    Private Sub ProductosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim frm As New frmProductosBusqueda
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MotocicletasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotocicletasToolStripMenuItem1.Click
        Dim frm As New frmMotocicletasBusqueda
        frm.MdiParent = Me
        frm.Show()
    End Sub
#End Region

#Region "Manejo de la aplicacion"
    Private Sub frmMenuPrincipal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub
#End Region

#Region "Facturación"

#Region "Control de caja"

    Private Sub AperturaDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AperturaDeCajaToolStripMenuItem.Click
        Dim frm As New frmAperturaCaja
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub IngresosDeEfectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosDeEfectivoToolStripMenuItem.Click
        Dim frm As New frmIngresoEfectivo
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub RetirosDeEfectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetirosDeEfectivoToolStripMenuItem.Click
        Dim frm As New frmRetirosEfectivo
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CierreDeCajaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreDeCajaToolStripMenuItem.Click
        Dim frm As New frmCierreCaja
        frm.MdiParent = Me
        frm.Show()
    End Sub

#End Region

#Region "Transacciones de caja"

#Region "Ventas"

    Private Sub ProductosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductosToolStripMenuItem1.Click
        Dim frm As New frmVentas
        frm.MdiParent = Me
        frm.Show()
    End Sub


    Private Sub MotocicletasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MotocicletasToolStripMenuItem.Click
        Dim frm As New frmVentaMotocicleta
        frm.MdiParent = Me
        frm.Show()
    End Sub

#End Region

    Private Sub FacturaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónToolStripMenuItem1.Click
        Dim frm As New frmBusquedaFactura
        frm.MdiParent = Me
        frm.Show()
    End Sub

#End Region

#End Region

#Region "Sesion"
    Private Sub CerrarSesesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesesiónToolStripMenuItem.Click
        Dim frm As New frmIniciosesion
        frm.Show()
        Me.Close()
    End Sub

    Private Sub CambiarDeUsuarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarDeUsuarioToolStripMenuItem.Click
        Dim frm As New frmIniciosesion
        frm.ShowDialog()
    End Sub

#End Region


#End Region

    
    
    
End Class
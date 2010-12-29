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
        Me.MdiChildren.GetUpperBound(0)
        For f As Integer = 0 To Me.MdiChildren.GetUpperBound(0) - 1
            Me.MdiChildren(f).Close()
        Next
    End Sub
#End Region

#End Region
    
   
End Class
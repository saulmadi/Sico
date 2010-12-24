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

#End Region

#End Region
    
    
End Class
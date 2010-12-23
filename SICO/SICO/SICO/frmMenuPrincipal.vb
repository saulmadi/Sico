Imports System.Windows.Forms

Public Class frmMenuPrincipal

#Region "Eventos"
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub MarcasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarcasToolStripMenuItem.Click
        Dim frmMarcas As New frmMarcas
        frmMarcas.MdiParent = Me
        frmMarcas.Show()
    End Sub

    Private Sub TipoDeMotocicletasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDeMotocicletasToolStripMenuItem.Click
        Dim frmTiposMotocicletas As New frmTiposMotocicletas
        frmTiposMotocicletas.MdiParent = Me
        frmTiposMotocicletas.Show()
    End Sub
#End Region

    
   
End Class

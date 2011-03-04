Public Class frmBusquedaOrdenesCompra
    Public WithEvents frm As New frmOrdenesCompra
    Private Sub CrtPanelBusqueda1_Nuevo() Handles CrtPanelBusqueda1.Nuevo
        Me.Hide()
        frm = New frmOrdenesCompra
        frm.MdiParent = Me.MdiParent
        frm.Show()

    End Sub

    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub

    
End Class
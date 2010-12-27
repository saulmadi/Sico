Public Class frmMotocicletasBusqueda
    Dim WithEvents frm As New frmMotociletas
    Private Sub frmMotocicletasBusqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CrtPanelBusqueda1_Nuevo() Handles CrtPanelBusqueda1.Nuevo
        Me.Hide()
        frm = New frmMotociletas
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub
End Class
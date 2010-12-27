Imports System.Windows.Forms
Public Class frmProductosBusqueda
    Dim WithEvents frm As New frmProductos

    Private Sub frmProductosBusqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PanelBusqueda.GridResultados.Columns.Add("codigo", "Código")
        PanelBusqueda.GridResultados.Columns.Add("descripcion", "Descripción")
        PanelBusqueda.GridResultados.Columns.Add("cantidad", "Cántidad")
        PanelBusqueda.GridResultados.Columns.Add("precioventa", "Precio de Venta")
        PanelBusqueda.GridResultados.BotonEditar = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PanelBusqueda_Nuevo() Handles PanelBusqueda.Nuevo
        Me.Hide()
        frm = New frmProductos
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub
End Class
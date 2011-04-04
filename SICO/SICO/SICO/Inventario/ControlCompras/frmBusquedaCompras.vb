Imports SICO.lgla2
Imports SICO.lgla
Public Class frmBusquedaCompras
    Private WithEvents frm As New frmCompras
    Private Sub CrtPanelBusqueda1_Nuevo() Handles CrtPanelBusqueda1.Nuevo
        Me.Hide()
        frm = New frmCompras
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed

        Me.Show()
    End Sub

    Private Sub frmBusquedaCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cmbProveedor.DisplayMember = "NombreMantenimiento"
        cmbProveedor.ValueMember = "Id"
        CrtPanelBusqueda1.GridResultados.BotonEditar = True
        CrtPanelBusqueda1.Entidad = New Compras
        CrtPanelBusqueda1.GridResultados.DarFormato("DescripcionProveedor", "Proveedor", True)

        CrtPanelBusqueda1.GridResultados.DarFormato("facturacompra", "Factura de Compra", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("fechacompra", "Fecha de Compra", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("totalcompra", "Total", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("DescripcionEstado", "Estado", True)

        cmbProveedor.Entidad = New Proveedores

        cmbProveedor.CargarEntidad()
        CrtPanelBusqueda1.SeccionParametros.Size = New Size(CrtPanelBusqueda1.SeccionParametros.Size.Width, 80)

        fecha.Value = Now.AddDays(-30)


    End Sub

    Public Sub Cargar()
        Try
            Dim p As New List(Of SICO.lgla.Parametro)

            p.Add(New Parametro("fechacompra", " fechacompra >= '" + fecha.Value.ToString("yyyy-MM-dd") + "' and fechacompra <= '" + fechahasta.Value.ToString("yyyy-MM-dd") + "' "))

            If Not cmbProveedor.SelectedItem Is Nothing Then
                p.Add(New Parametro("idproveedor", cmbProveedor.SelectedValue))
            End If

            CrtPanelBusqueda1.Cargar(p)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cargar()

    End Sub

    Private Sub CrtPanelBusqueda1_Editar() Handles CrtPanelBusqueda1.Editar
        Me.Hide()
        frm = New frmCompras

        frm.MdiParent = Me.MdiParent

        frm.Show()
        frm.Compras = Me.CrtPanelBusqueda1.GridResultados.Item


    End Sub
End Class
Imports SICO.lgla
Imports SICO.lgla2
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

    Private Sub CrtPanelBusqueda1_Editar() Handles CrtPanelBusqueda1.Editar
        Me.Hide()
        frm = New frmOrdenesCompra

        frm.MdiParent = Me.MdiParent

        frm.Show()
        frm.OrdenCompar = Me.CrtPanelBusqueda1.GridResultados.Item

    End Sub

    Private Sub frmBusquedaOrdenesCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbProveedor.DisplayMember = "NombreMantenimiento"
        cmbProveedor.ValueMember = "Id"
        CrtPanelBusqueda1.GridResultados.BotonEditar = True
        CrtPanelBusqueda1.Entidad = New OrdenCompra

        CrtPanelBusqueda1.GridResultados.DarFormato("codigo", "Número de Orden", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("DescripcionProveedor", "Proveedor", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("fechaorden", "Fecha de Orden", True)


        cmbProveedor.Entidad = New Proveedores

        cmbProveedor.CargarEntidad()
        CrtPanelBusqueda1.SeccionParametros.Size = New Size(CrtPanelBusqueda1.SeccionParametros.Size.Width, 80)

        fecha.Value = Now.AddDays(-30)
    End Sub

    Public Sub Cargar()
        Try
            Dim p As New List(Of SICO.lgla.Parametro)

            p.Add(New Parametro("fechaorden", " fechaorden >= '" + fecha.Value.ToString("yyyy-MM-dd") + "' and fechaorden <= '" + fechahasta.Value.ToString("yyyy-MM-dd") + "' "))

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
End Class
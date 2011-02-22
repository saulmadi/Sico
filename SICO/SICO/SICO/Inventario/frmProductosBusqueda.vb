Imports System.Windows.Forms
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmProductosBusqueda
    Dim WithEvents frm As New frmProductos

    Private Sub frmProductosBusqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cboSucursales.Inicialiazar()
        PanelBusqueda.Entidad = New SICO.lgla2.TransaccionesProductos
        PanelBusqueda.GridResultados.BotonEditar = True
        PanelBusqueda.GridResultados.BotonBuscar = True
        PanelBusqueda.GridResultados.BotonEliminar = True
        PanelBusqueda.SeccionParametros.Size = New Size(PanelBusqueda.Size.Width, 60)

        PanelBusqueda.GridResultados.DarFormato("codigo", "Código")
        PanelBusqueda.GridResultados.DarFormato("descripcion", "Descripción")
        PanelBusqueda.GridResultados.DarFormato("cantidad", "Cantidad")
        PanelBusqueda.GridResultados.DarFormato("precioventa", "Precio de Venta")



        Me.WindowState = FormWindowState.Maximized
        Try
            PanelBusqueda.Sucursal.Cargar()
            cboSucursales.SelectedValue = PanelBusqueda.Sucursal.Id
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PanelBusqueda_Editar() Handles PanelBusqueda.Editar
        Me.Hide()
        Dim f As New Productos
        f.Id = CType(PanelBusqueda.GridResultados.Item, TransaccionesProductos).idproductos
        frm = New frmProductos
        frm.MdiParent = Me.MdiParent
        frm.Show()
        frm.Producto = f
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

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        If txtDescripcion.Text.Trim.Length = 2 Or txtDescripcion.Text.Trim.Length = 4 Then
            Try
                If cboSucursales.SelectedItem Is Nothing Then
                    Me.PanelBusqueda.Sucursal.Cargar()
                    Dim list As New List(Of SICO.lgla.Parametro)
                    list.Add(New Parametro("descripcion", txtDescripcion.Text))
                    list.Add(New Parametro("idsucursales", PanelBusqueda.Sucursal.Id))
                    Me.PanelBusqueda.Cargar(list)
                Else
                    Dim list As New List(Of SICO.lgla.Parametro)
                    list.Add(New Parametro("descripcion", txtDescripcion.Text))
                    list.Add(New Parametro("idsucursales", cboSucursales.SelectedItem.Id))
                    Me.PanelBusqueda.Cargar(list)
                End If


            Catch ex As Exception
                MessageBox.Show("La sucursal no se ha configurado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

   
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            If cboSucursales.SelectedItem Is Nothing Then
                Me.PanelBusqueda.Sucursal.Cargar()
                Dim list As New List(Of SICO.lgla.Parametro)
                list.Add(New Parametro("descripcion", txtDescripcion.Text))
                list.Add(New Parametro("idsucursales", PanelBusqueda.Sucursal.Id))
                Me.PanelBusqueda.Cargar(list)
            Else
                Dim list As New List(Of SICO.lgla.Parametro)
                list.Add(New Parametro("descripcion", txtDescripcion.Text))
                list.Add(New Parametro("idsucursales", cboSucursales.SelectedItem.Id))
                Me.PanelBusqueda.Cargar(list)
            End If


        Catch ex As Exception
            MessageBox.Show("La sucursal no se ha configurado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboSucursales_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSucursales.SelectedIndexChanged
        If txtDescripcion.Text.Trim.Length = 2 Or txtDescripcion.Text.Trim.Length = 4 Then
            Try
                If cboSucursales.SelectedItem Is Nothing Then
                    Me.PanelBusqueda.Sucursal.Cargar()
                    Dim list As New List(Of SICO.lgla.Parametro)
                    list.Add(New Parametro("descripcion", txtDescripcion.Text))
                    list.Add(New Parametro("idsucursales", PanelBusqueda.Sucursal.Id))
                    Me.PanelBusqueda.Cargar(list)
                Else
                    Dim list As New List(Of SICO.lgla.Parametro)
                    list.Add(New Parametro("descripcion", txtDescripcion.Text))
                    list.Add(New Parametro("idsucursales", cboSucursales.SelectedItem.Id))
                    Me.PanelBusqueda.Cargar(list)
                End If


            Catch ex As Exception
                MessageBox.Show("La sucursal no se ha configurado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
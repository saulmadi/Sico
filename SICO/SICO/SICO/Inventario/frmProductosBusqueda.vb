﻿Imports SiCo.lgla
Imports SiCo.lgla2

Public Class frmProductosBusqueda
    Dim WithEvents frm As New frmProductos

    Private Sub frmProductosBusqueda_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        cboSucursales.Inicialiazar()
        PanelBusqueda.Entidad = New TransaccionesProductos
        PanelBusqueda.GridResultados.BotonEditar = True


        PanelBusqueda.SeccionParametros.Size = New Size (PanelBusqueda.Size.Width, 70)

        PanelBusqueda.GridResultados.DarFormato ("codigo", "Código")
        PanelBusqueda.GridResultados.DarFormato ("descripcion", "Descripción")
        PanelBusqueda.GridResultados.DarFormato ("cantidad", "Cantidad")
        PanelBusqueda.GridResultados.DarFormato ("precioventa", "Precio de Venta")


        Me.WindowState = FormWindowState.Normal
        Try
            PanelBusqueda.Sucursal.Cargar()
            cboSucursales.SelectedValue = PanelBusqueda.Sucursal.Id
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PanelBusqueda_Editar() Handles PanelBusqueda.Editar
        Me.Hide()
        Dim f As New Productos
        f.Id = CType (PanelBusqueda.GridResultados.Item, TransaccionesProductos).idproductos
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

    Private Sub frm_FormClosed (ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub

    Private Sub Cargar()
        Try
            If cboSucursales.SelectedItem Is Nothing And cboSucursales.Enabled Then
                Me.PanelBusqueda.Sucursal.Cargar()
                Dim list As New List(Of Parametro)
                list.Add (New Parametro ("descripcion", txtDescripcion.Text))
                list.Add (New Parametro ("idsucursales", PanelBusqueda.Sucursal.Id))
                Me.PanelBusqueda.Cargar (list)
            ElseIf cboSucursales.Enabled Then
                Dim list As New List(Of Parametro)
                list.Add (New Parametro ("descripcion", txtDescripcion.Text))
                list.Add (New Parametro ("idsucursales", cboSucursales.SelectedItem.Id))
                Me.PanelBusqueda.Cargar (list)
            Else
                Dim list As New List(Of Parametro)
                list.Add (New Parametro ("descripcion", txtDescripcion.Text))
                list.Add (New Parametro ("inventarioTotal", "1"))
                Me.PanelBusqueda.Cargar (list)
            End If


        Catch ex As Exception
            MessageBox.Show ("La sucursal no se ha configurado correctamente", "Error", MessageBoxButtons.OK, _
                             MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDescripcion_TextChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles txtDescripcion.TextChanged
        If txtDescripcion.Text.Trim.Length = 2 Or txtDescripcion.Text.Trim.Length = 4 Then
            Cargar()
        End If
    End Sub


    Private Sub btnBuscar_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        'Try
        '    If cboSucursales.SelectedItem Is Nothing Then
        '        Me.PanelBusqueda.Sucursal.Cargar()
        '        Dim list As New List(Of SICO.lgla.Parametro)
        '        list.Add(New Parametro("descripcion", txtDescripcion.Text))
        '        list.Add(New Parametro("idsucursales", PanelBusqueda.Sucursal.Id))
        '        Me.PanelBusqueda.Cargar(list)
        '    Else
        '        Dim list As New List(Of SICO.lgla.Parametro)
        '        list.Add(New Parametro("descripcion", txtDescripcion.Text))
        '        list.Add(New Parametro("idsucursales", cboSucursales.SelectedItem.Id))
        '        Me.PanelBusqueda.Cargar(list)
        '    End If


        'Catch ex As Exception
        '    MessageBox.Show("La sucursal no se ha configurado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        Cargar()
    End Sub

    Private Sub cboSucursales_SelectedIndexChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles cboSucursales.SelectedIndexChanged
        If txtDescripcion.Text.Trim.Length = 2 Or txtDescripcion.Text.Trim.Length = 4 Then
            'Try
            '    If cboSucursales.SelectedItem Is Nothing Then
            '        Me.PanelBusqueda.Sucursal.Cargar()
            '        Dim list As New List(Of SICO.lgla.Parametro)
            '        list.Add(New Parametro("descripcion", txtDescripcion.Text))
            '        list.Add(New Parametro("idsucursales", PanelBusqueda.Sucursal.Id))
            '        Me.PanelBusqueda.Cargar(list)
            '    Else
            '        Dim list As New List(Of SICO.lgla.Parametro)
            '        list.Add(New Parametro("descripcion", txtDescripcion.Text))
            '        list.Add(New Parametro("idsucursales", cboSucursales.SelectedItem.Id))
            '        Me.PanelBusqueda.Cargar(list)
            '    End If


            'Catch ex As Exception
            '    MessageBox.Show("La sucursal no se ha configurado correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
            Cargar()
        End If
    End Sub

    Private Sub chkInventarioTotal_CheckedChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles chkInventarioTotal.CheckedChanged
        cboSucursales.Enabled = Not chkInventarioTotal.Checked
    End Sub
End Class
﻿Imports SiCo.lgla
Imports SiCo.lgla2
Public Class frmBusquedaProductos

    Private Sub CajaTexto1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdescripcion.TextChanged
        If txtdescripcion.Text.Length = 2 Or txtdescripcion.Text.Length = 4 Then
            Dim list As New List(Of SiCo.lgla.Parametro)
            list.Add(New Parametro("descripcion", txtdescripcion.Text.Trim))
            Me.cargar(list)
        End If
    End Sub

    Private Sub frmBusquedaProductos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Entidad = New SiCo.lgla2.Productos
        Grid.DarFormato("codigo", "Código", True, True)
        Grid.DarFormato("descripcion", "Descripción", True, True)
        Grid.DarFormato("precioventa", "Precio Venta", True, True)

    End Sub
End Class
Imports SICO.lgla2
Imports SICO.lgla

Public Class frmBusquedaFactura
    Dim WithEvents frm As frmVentas



    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub

    Private Sub frmBusquedaFactura_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSucursales.Inicialiazar()

        Grid.DarFormato("codigo", "Código", True)
        Grid.DarFormato("NumeroFacturaS", "Número Factura", True)
        Grid.DarFormato("NombreCliente", "Cliente", True)
        Grid.DarFormato("DescripcionEstado", "Estado", True)
        Grid.DarFormato("total", "Total", True)

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim fac As New FacturaEncabezado
            Dim l As New List(Of Parametro)

            If cmbRubro.SelectedIndex = 0 Then
                l.Add(New Parametro("motoproducto", "M"))
            ElseIf cmbRubro.SelectedIndex = 1 Then
                l.Add(New Parametro("motoproducto", "P"))
            End If
            l.Add(New Parametro("fecha", "fecha = '" + dteFecha.Value.ToString("yyyy-MM-dd") + "'"))
            If cmbSucursales.SelectedIndex <> -1 Then
                l.Add(New Parametro("idsucursales", cmbSucursales.SelectedItem.Id.ToString))
            Else
                l.Add(New Parametro("idsucursales", CrtPanelBase1.sucursal.Id.ToString))
            End If
            If txtCodigo.Text <> String.Empty Then
                l.Add(New Parametro("codigoparecido", txtCodigo.Text))
            End If

            fac.Buscar(l)

            Grid.DataSource = fac.TablaAColeccion

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grid_Editar(ByVal EditarArg As SICO.ctrla.GridEditarEventArg) Handles Grid.Editar
        Try
            Me.Hide()
            frm = New frmVentas

            frm.MdiParent = Me.MdiParent
            frm.Show()
            frm.Factura = Grid.Item()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Grid_Eliminar(ByVal EliminarArg As SICO.ctrla.GridEliminarEventArg) Handles Grid.Eliminar

    End Sub
End Class
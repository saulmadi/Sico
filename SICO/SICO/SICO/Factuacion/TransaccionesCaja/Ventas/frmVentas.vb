Imports SICO.lgla
Imports SICO.lgla2
Imports SICO.ctrla
Public Class frmVentas
#Region "Declaraciones"
    Private _factura As New FacturaEncabezado
#End Region
#Region "Propiedades"
    Public Property Factura() As FacturaEncabezado
        Get
            Return _factura
        End Get
        Set(ByVal value As FacturaEncabezado)
            _factura = value
            cargarentidad()
        End Set
    End Property
#End Region
#Region "Metodos"
    Private Sub cargarentidad()
        If Factura.Id = 0 Then
            CrtClientes.Nuevo()
            cmbTiposFacturas.SelectedIndex = -1
            chkVentaExcenta.Checked = False
            Factura.ListaDetalle.Clear()

            For i As Integer = 0 To 10
                Factura.ListaDetalle.Add(New FacturaDetalle(PanelAccion1.sucursal.Id))
            Next
            grdDetalle.DataSource = Factura.ListaDetalle
            grdDetalle.ReadOnly = False
        Else

        End If
    End Sub

    Private Sub calculartotales()
        txtTotalItems.Text = Me.Factura.TotalItems
        txtTotalProductos.Text = Me.Factura.CantidadTotalProductos
    End Sub
#End Region
#Region "Eventos"
    Private Sub frmVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbTiposFacturas.Entidad = New TiposFacturas
        cmbTiposFacturas.ColeccionParametros.Add(New ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        cmbTiposFacturas.CargarParametros()
        lblNumeroFactura.Text = ""
    End Sub
    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Factura = New FacturaEncabezado
    End Sub
    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub
    Private Sub grdDetalle_Buscar() Handles grdDetalle.Buscar
        Dim f As New SICO.ctrla2.frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Me.Factura.ListaDetalle(grdDetalle.CurrentRow.Index).Producto = New ProductosInventario(PanelAccion1.sucursal.Id)
            Me.Factura.ListaDetalle(grdDetalle.CurrentRow.Index).Producto.Producto = f.Entidad
            grdDetalle.Refresh()
        End If
        calculartotales()
    End Sub
#End Region
    
   
   
    
End Class
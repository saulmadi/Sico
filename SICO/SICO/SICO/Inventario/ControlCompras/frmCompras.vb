Imports SICO.lgla2
Public Class frmCompras

#Region "Declaraciones"
    Private _compras As New Compras
#End Region

#Region "Constructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().       

    End Sub
#End Region

#Region "Propiedades"
    Public Property Compras() As Compras
        Get
            Return _compras
        End Get
        Set(ByVal value As Compras)
            _compras = value
            txtimpuesto.Text = value.Impuesto
            txtsubtotal.Text = value.CalcularTotal
            txttotal.Text = value.CalcularTotal

            If value.Id = 0 Then
                value.ListaDetalle.Clear()
                For i As Integer = 0 To 50
                    value.ListaDetalle.Add(New DetalleCompras)
                Next
                grdDetalle.DataSource = _compras.ListaDetalle
            Else
                grdDetalle.DataSource = _compras.ListaDetalle
            End If
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        grdDetalle.BotonBuscar = True
        grdDetalle.RowHeadersVisible = True
        grdDetalle.DarFormato("codigo", "Código", False)
        grdDetalle.DarFormato("descripcion", "Descripción", True)
        grdDetalle.DarFormato("CantidadEditable", "Cantidad", False)
        grdDetalle.DarFormato("PrecioEditable", "Precio de Compra", False)
        grdDetalle.DarFormato("SubtotalString", "Subtotal", True)

        Me.WindowState = FormWindowState.Maximized

    End Sub
    Private Sub grdDetalle_Buscar() Handles grdDetalle.Buscar
        Dim f As New SICO.ctrla2.frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim d As New DetalleCompras
            d.Producto = f.Entidad

            Me.Compras.ListaDetalle(grdDetalle.CurrentRow.Index).Producto = f.Entidad
            grdDetalle.Refresh()
        End If

    End Sub
    Private Sub grdDetalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetalle.CellEndEdit
        txtimpuesto.Text = Me.Compras.Impuesto
        txtsubtotal.Text = Me.Compras.CalcularTotal
        txttotal.Text = Me.Compras.CalcularTotal
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Compras = New Compras
    End Sub
#End Region


End Class
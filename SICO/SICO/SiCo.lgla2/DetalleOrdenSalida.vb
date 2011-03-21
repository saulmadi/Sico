Imports SiCo.lgla
Public Class DetalleOrdenSalida
    Inherits SiCo.lgla.Entidad
#Region "Declaracioens"
    Private _idsalida As Long
    Private _idproducto As Long
    Private _ProductoInventario As New ProductosInventario
#End Region

#Region "constructor"
    Public Sub New()
        Me.ComandoSelect = "TransaccionesProductosComplejo_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproductos"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproductos"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tabla", " inner join detallesalida t on i.idproductos= t.idproducto"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("campos", " t.id,t.isalida,t.idproducto,t.cantidad,t.fmodif,t.usu,i.cantidad as existencia,p.codigo,p.descripcion,p.precioventa "))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("parametro"))

    End Sub

#End Region

#Region "Propiedades"
    Public Property idsalida() As Long
        Get
            Return _idsalida
        End Get
        Set(ByVal value As Long)
            _idsalida = value
        End Set
    End Property

    Public Property idProducto() As Long
        Get
            Return _idproducto
        End Get
        Set(ByVal value As Long)
            _idproducto = value
        End Set
    End Property

    Public Property Producto() As ProductosInventario
        Get
            Return _ProductoInventario
        End Get
        Set(ByVal value As ProductosInventario)
            _ProductoInventario = value
        End Set
    End Property
    Public ReadOnly Property ProductoDescripcion() As String
        Get
            Return Me.Producto.Producto.Descripcion
        End Get
    End Property
    Public Property Cantidad() As Long
        Get
            Return Me.Producto.Cantidad
        End Get
        Set(ByVal value As Long)
            Me.Producto.Cantidad = value
        End Set
    End Property
    Public Property CantidadEditable() As String
        Get
            Return Producto.CantidadEditable
        End Get
        Set(ByVal value As String)
            Producto.CantidadEditable = value
        End Set
    End Property
#End Region

#Region "metodos"

#End Region


End Class

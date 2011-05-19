Imports SiCo.lgla
Imports SiCo.lgla2
Public Class FacturaDetalle
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _idfacturaencabezado As Long
    Private _idproducto As Long
    Private _ProductoInventario As New ProductosInventario
#End Region

#Region "Constructor"
    Public Sub New()
        Me.ComandoSelect = "TransaccionesProductosComplejo_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproductos"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tabla", " inner join facturadetalle t on i.idproducto= t.idproductos  "))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("campos", " t.id,t.idfacturaencabezado,t.idproductos,t.cantidad,t.precioventa,t.fmodif,t.usu,i.idsucursales as idsucursal,i.cantidad as existencia,p.codigo,p.descripcion,p.precioventa "))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("parametro"))

        Me.ComandoMantenimiento = "Facturadetalle_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idfacturaencabezado"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idproductos"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("cantidad"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("precioventa"))
    End Sub

    Public Sub New(ByVal idsucursal As Long)
        Me.New()
        Producto = New ProductosInventario(idsucursal)
    End Sub

    Public Sub New(ByVal id As Long, ByVal idfacturaencabezado As Long, ByVal idproducto As Long, ByVal producto As ProductosInventario)
        Me.New()
        Me._Id = id
        Me._idfacturaencabezado = idfacturaencabezado
        Me.idProducto = idproducto
        Me._ProductoInventario = producto
    End Sub


#End Region

#Region "Propiedades"
    Public Property idFacturaEncabezado() As Long
        Get
            Return _idfacturaencabezado

        End Get
        Set(ByVal value As Long)
            _idfacturaencabezado = value
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

    Public Property Codigo() As String
        Get
            Return (Producto.Codigo)
        End Get
        Set(ByVal value As String)
            Producto.Codigo = value
        End Set
    End Property

    Public ReadOnly Property Existencia() As String
        Get
            If Me.Producto.Producto.Id = 0 Then
                Return String.Empty
            End If
            Return Producto.Existencia
        End Get
    End Property

    Public ReadOnly Property TotalLinea() As String
        Get
            Try
                Dim valor As Decimal = Cantidad * Producto.Producto.PrecioVenta
                If Me.Producto.Producto.Id = 0 Then
                    Return String.Empty
                End If
                Return IIf(valor > 0, valor.ToString("#############.##"), "0.00")
            Catch ex As Exception
                Return "0.00"
            End Try

        End Get
    End Property

    'Public ReadOnly Property Impuesto() As String
    '    Get
    '        Try
    '            Dim valor As Decimal = (Cantidad * Producto.Producto.PrecioVenta) * GeneralesConstantes.Impuesto
    '            If Me.Producto.Producto.Id = 0 Then
    '                Return String.Empty
    '            End If
    '            Return IIf(valor > 0, valor.ToString("#############.##"), "0.00")
    '        Catch ex As Exception
    '            Return "0.00"
    '        End Try

    '    End Get
    'End Property

    Public Property Precio() As String
        Get
            Try
                If Me.Producto.Producto.Id = 0 Then
                    Return String.Empty
                End If
                Return IIf(Producto.Producto.PrecioVenta > 0, Producto.Producto.PrecioVenta.ToString("#############.##"), "0.00")
            Catch ex As Exception
                Return String.Empty
            End Try

        End Get
        Set(ByVal value As String)
            Producto.Producto.PrecioVenta = value
        End Set
    End Property

#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idFacturaEncabezado = Registro(Indice, "idfacturaencabezado")
        Me.idProducto = Registro(Indice, "idproductos")
        Me.Producto = New ProductosInventario(New Productos(idProducto, Registro(Indice, "codigo"), Registro(Indice, "descripcion"), 0, Registro(Indice, "precioventa")), Registro(Indice, "idsucursal"), Registro(Indice, "existencia"))
        Me.Producto.Cantidad = Registro(Indice, "cantidad")
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()

        Me.ValorParametrosMantenimiento("idproductos", Me.Producto.Producto.Id)
        Me.ValorParametrosMantenimiento("idfacturaencabezado", Me.idFacturaEncabezado)
        Me.ValorParametrosMantenimiento("cantidad", Me.Cantidad)
        Me.ValorParametrosMantenimiento("precioventa", Me.Producto.Producto.PrecioVenta)

        MyBase.Guardar(True)
    End Sub

    Public Overloads Sub Buscar(ByVal idfacutraencabezado As Long, ByVal idproducto As String, ByVal idsucursales As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("idsucursales", idsucursales)
        Me.ValorParametrosBusqueda("parametro", " t.idfacutraencabezado = " + idfacutraencabezado.ToString() + " ")
        Me.ValorParametrosBusqueda("idproductos", idproducto.ToString)

        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of FacturaDetalle)

        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            Dim temp As New FacturaDetalle(Me.Id, Me.idFacturaEncabezado, Me.idProducto, Me.Producto)
            lista.Add(temp)
        Next

        Return lista
    End Function

    Public Sub setProducto(ByVal producto As Productos)
        Dim su As Integer = Me.Producto.idSucursal

        Me.Producto = New ProductosInventario(su)
        Me.Producto.Producto = producto


    End Sub
#End Region

End Class

Imports SiCo.lgla

Public Class DetalleOrdenSalida
    Inherits Entidad

#Region "Declaracioens"

    Private _idsalida As Long
    Private _idproducto As Long
    Private _ProductoInventario As New ProductosInventario

#End Region

#Region "constructor"

    Public Sub New()
        Me.ComandoSelect = "TransaccionesProductosComplejo_Buscar"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idproductos"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("tabla", _
                                                           " inner join detallesalida t on i.idproductos= t.idproducto  "))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("campos", _
                                                           " t.id,t.idsalida,t.idproducto,t.cantidad,t.fmodif,t.usu,i.idsucursales as idsucursal,i.cantidad as existencia,p.codigo,p.descripcion,p.precioventa "))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("parametro"))

        Me.ComandoMantenimiento = "DetalleSalida_Mant"
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idsucursal"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idsalida"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idproducto"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("cantidad"))


    End Sub

    Public Sub New (ByVal idsucursal As Long)
        Me.New()
        Producto = New ProductosInventario (idsucursal)
    End Sub

    Public Sub New (ByVal id As Long, ByVal idsalida As Long, ByVal idproducto As Long, _
                    ByVal producto As ProductosInventario)
        Me.New()
        Me._Id = id
        Me.idsalida = idsalida
        Me.idProducto = idproducto
        Me._ProductoInventario = producto
    End Sub

#End Region

#Region "Propiedades"

    Public Property idsalida() As Long
        Get
            Return _idsalida
        End Get
        Set (ByVal value As Long)
            _idsalida = value
        End Set
    End Property

    Public Property idProducto() As Long
        Get
            Return _idproducto
        End Get
        Set (ByVal value As Long)
            _idproducto = value
        End Set
    End Property

    Public Property Producto() As ProductosInventario
        Get
            Return _ProductoInventario
        End Get
        Set (ByVal value As ProductosInventario)
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
        Set (ByVal value As Long)
            Me.Producto.Cantidad = value
        End Set
    End Property

    Public Property CantidadEditable() As String
        Get
            Return Producto.CantidadEditable
        End Get
        Set (ByVal value As String)
            Producto.CantidadEditable = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return (Producto.Codigo)
        End Get
        Set (ByVal value As String)
            Producto.Codigo = value
        End Set
    End Property

    Public ReadOnly Property Existencia() As String
        Get
            If Producto.Existencia = 0 Then
                Return String.Empty
            End If
            Return Producto.Existencia
        End Get
    End Property

#End Region

#Region "metodos"

    Protected Overrides Sub CargadoPropiedades (ByVal Indice As Integer)
        Me.idsalida = Registro (Indice, "idsalida")
        Me.idProducto = Registro (Indice, "idproducto")
        Me.Producto = New ProductosInventario ( _
            New Productos (idProducto, Registro (Indice, "codigo"), Registro (Indice, "descripcion"), 0, _
                           Registro (Indice, "precioventa")), Registro (Indice, "idsucursal"), _
            Registro (Indice, "existencia"))
        Me.Producto.Cantidad = Registro (Indice, "cantidad")
        MyBase.CargadoPropiedades (Indice)
    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()

        Me.ValorParametrosMantenimiento ("idsucursal", Me.Producto.idSucursal)
        Me.ValorParametrosMantenimiento ("idproducto", Me.Producto.Producto.Id)
        Me.ValorParametrosMantenimiento ("idsalida", Me.idsalida)
        Me.ValorParametrosMantenimiento ("cantidad", Me.Cantidad)

        MyBase.Guardar (True)
    End Sub

    Public Overloads Sub Buscar (ByVal idsalida As Long, ByVal idproducto As String, ByVal idsucursales As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda ("idsucursales", idsucursales)
        Me.ValorParametrosBusqueda ("parametro", " t.idsalida = " + idsalida.ToString() + " ")
        Me.ValorParametrosBusqueda ("idproductos", idproducto.ToString)

        Me.LlenadoTabla (Me.ColeccionParametrosBusqueda)
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of DetalleOrdenSalida)

        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades (i)
            Dim temp As New DetalleOrdenSalida (Me.Id, Me.idsalida, Me.idProducto, Me.Producto)
            lista.Add (temp)
        Next

        Return lista
    End Function

#End Region
End Class

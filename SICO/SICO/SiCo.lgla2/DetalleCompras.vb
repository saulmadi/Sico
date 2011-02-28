Imports SiCo.lgla
Imports System.Text.RegularExpressions

Public Class DetalleCompras
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _idcompras As Long
    Private _idprodcutos As Long
    Private _cantidad As Long
    Private _preciocompra As Decimal
    Private _idsucursal As Long

    Private WithEvents _Producto As New Productos

#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "DetalleCompras_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idcompras"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproducto"))

        Me.ComandoMantenimiento = "DetalleCompras_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idcompras"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idproducto"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("cantidad"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("preciocompra"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursal"))

        Me.TablaEliminar = "DetalleCompras"

    End Sub
    Public Sub New(ByVal id As Long, ByVal idcompras As Long, ByVal idproductos As Long, ByVal cantidad As Long, ByVal preciocompra As Decimal, ByVal idsucursal As Long)
        Me.New()

        Me._Id = id
        Me.idproducto = idproductos
        Me.idcompras = idcompras
        Me.idproducto = idproducto
        Me.cantidad = cantidad
        Me.preciocompra = preciocompra
        Me.idsucursal = idsucursal


    End Sub

#End Region

#Region "Propiedades"
    Public Property idcompras() As Long
        Get
            Return _idcompras
        End Get

        Set(ByVal value As Long)
            _idcompras = value
        End Set
    End Property

    Public Property idproducto() As Long
        Get
            Return _idprodcutos
        End Get
        Set(ByVal value As Long)
            _idprodcutos = value
        End Set
    End Property

    Public Property cantidad() As Long
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Long)
            _cantidad = value
        End Set
    End Property

    Public Property preciocompra() As Decimal
        Get
            Return _preciocompra
        End Get
        Set(ByVal value As Decimal)
            _preciocompra = value
        End Set
    End Property

    Public Property idsucursal() As Long
        Get
            Return _idsucursal
        End Get
        Set(ByVal value As Long)
            _idsucursal = value
        End Set
    End Property

    Public Property Producto() As Productos
        Get
            If Me.idproducto > 0 And _Producto.Id <> Me.idproducto Then
                _Producto.Id = Me.idproducto
            End If
            Return _Producto
        End Get
        Set(ByVal value As Productos)
            _Producto = value

            Me.idproducto = value.Id
        End Set
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            If Me.Producto.Id = 0 Then
                Return String.Empty
            End If
            Return Producto.Descripcion
        End Get
    End Property

    Public Property Codigo() As String
        Get
            If Me.Producto.Id = 0 Then
                Return String.Empty
            End If
            Return Me.Producto.Codigo
        End Get
        Set(ByVal value As String)
            Me._Producto = New Productos
            Me._Producto.CodigoParaBusqueda = value
            If Me._Producto.TotalRegistros = 0 Then
                Me.Producto = New Productos
            End If
        End Set
    End Property

    Public Property CantidadEditable() As String

        Get
            If cantidad = 0 Then
                Return String.Empty
            End If
            Return cantidad.ToString
        End Get
        Set(ByVal value As String)
            Dim reg As New Regex("^(?!^0*$)(?!^0*\.0*$)^\d{1,9}")
            If reg.IsMatch(value) Then
                Dim s As Long = value
                If s < 0 Then
                    Throw New ApplicationException("La cantidad tiene que ser mayor a 0")
                    Me.cantidad = 1
                Else
                    Me.cantidad = s
                End If
            Else
                Throw New ApplicationException("El número no tiene el formato correcto")
            End If
        End Set

    End Property

    Public Property PrecioEditable() As String
        Get
            If Me.preciocompra = 0 Then
                Return String.Empty
            End If
            Return Me.preciocompra.ToString
        End Get
        Set(ByVal value As String)
            Dim reg As New Regex("^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,2})?$")
            If reg.IsMatch(value) Then
                Dim d As Decimal = value
                If d > 0 Then
                    Me.preciocompra = d
                Else
                    Throw New ApplicationException("El precio de compra tiene que ser mayor a 0")
                End If
            Else
                Throw New ApplicationException("El número no tiene el formato correcto")
            End If
        End Set
    End Property

    Public ReadOnly Property Subtotal() As Decimal
        Get
            Return Me.cantidad * Me.preciocompra
        End Get
    End Property

    Public ReadOnly Property SubtotalString() As String
        Get
            If Me.Subtotal = 0 Then
                Return String.Empty
            End If
            Return Me.Subtotal.ToString
        End Get
    End Property

#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idcompras = Registro(Indice, "idcompras")
        Me.idproducto = Registro(Indice, "idproducto")
        Me.cantidad = Registro(Indice, "cantidad")
        Me.preciocompra = Registro(Indice, "preciocompra")
        Me.idsucursal = Registro(Indice, "idsucursal")


        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idcompras", Me.idcompras)
        Me.ValorParametrosMantenimiento("idproducto", Me.idproducto)
        Me.ValorParametrosMantenimiento("cantidad", Me.cantidad)
        Me.ValorParametrosMantenimiento("preciocompra", Me.preciocompra)
        Me.ValorParametrosMantenimiento("idsucursal", Me.idsucursal)
        MyBase.Guardar(True)
    End Sub
    <Obsolete("El metodo no se puede utilizar", True)> _
    Public Overrides Sub Guardar(ByVal transaccion As Boolean)

    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of DetalleCompras)

        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            Dim tempd As New DetalleCompras(Me.Id, Me.idcompras, Me.idproducto, Me.cantidad, Me.preciocompra, Me.idsucursal)
            lista.Add(tempd)
        Next
        Return lista
    End Function

    Public Overloads Sub Buscar(ByVal idcompras As String, ByVal idproducto As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("idcompras", idcompras)
        Me.ValorParametrosBusqueda("idproducto", idproducto)

        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)

    End Sub
#End Region

#Region "Eventos"
    Private Sub _Producto_CambioCodigo() Handles _Producto.CambioCodigo
        If Me._Producto.TotalRegistros > 0 Then
            Me.idproducto = Me._Producto.Id
        End If
    End Sub
#End Region

End Class

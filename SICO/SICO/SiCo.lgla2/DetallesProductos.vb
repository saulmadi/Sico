Imports SiCo.lgla
Imports System.Text.RegularExpressions
Public MustInherit Class DetallesProductos
    Inherits SiCo.lgla.Entidad
#Region "Declaraciones"
    Protected _Producto As New Productos
    Protected _cantidad As Long
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal producto As Productos, ByVal cantidad As Long)
        MyBase.New()
        Me.Producto = producto
        Me.Cantidad = cantidad
    End Sub
#End Region

#Region "Propiedades"
    Public Property idproducto() As Long
        Get
            Return _Producto.Id
        End Get
        Set(ByVal value As Long)
            _Producto.Id = value
        End Set
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return _Producto.Descripcion
        End Get
    End Property

    Public Property Cantidad() As Long
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Long)
            _cantidad = value
        End Set
    End Property

    Public Property Producto() As Productos
        Get
            Return _Producto
        End Get
        Set(ByVal value As Productos)
            _Producto = value
        End Set
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

    Public Overridable Property CantidadEditable() As String

        Get
            If Cantidad = 0 Then
                Return String.Empty
            End If
            Return Cantidad.ToString
        End Get
        Set(ByVal value As String)
            Dim reg As New Regex("^(?!^0*$)(?!^0*\.0*$)^\d{1,9}")
            If reg.IsMatch(value) Then
                Dim s As Long = value
                If s < 0 Then
                    Throw New ApplicationException("La cantidad tiene que ser mayor a 0")
                    Me.Cantidad = 1
                Else
                    Me.Cantidad = s
                End If
            Else
                Throw New ApplicationException("El número no tiene el formato correcto")
            End If
        End Set

    End Property
#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me._Producto = New Productos(Me.idproducto, Registro(Indice, "codigo"), Registro(Indice, "descripcion"), 0, Registro(Indice, "precioventa"))
        MyBase.CargadoPropiedades(Indice)
    End Sub

#End Region
End Class

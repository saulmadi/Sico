Imports SiCo.lgla

Public Class Productos
    Inherits Entidad
    
#Region "Declaraciones"
    Private _Codigo As String
    Private _Descripcion As String
    Private _PrecioVenta As Decimal
    Private _PrecioCosto As Decimal
#End Region

#Region "Constructor"

#End Region

#Region "Propiedades"

    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property PrecioCosto() As Decimal
        Get
            Return _PrecioCosto
        End Get
        Set(ByVal value As Decimal)
            _PrecioCosto = value
        End Set
    End Property

    Public Property PrecioVenta() As Decimal
        Get
            Return _PrecioVenta
        End Get
        Set(ByVal value As Decimal)
            _PrecioVenta = value
        End Set
    End Property

#End Region

#Region "Metodos"

#End Region

#Region "Eventos"

#End Region


End Class

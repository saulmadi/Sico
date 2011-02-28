Imports SiCo.lgla

Public Class Productos
    Inherits Entidad
    
#Region "Declaraciones"
    Private _Codigo As String
    Private _Descripcion As String
    Private _PrecioVenta As Decimal
    Private _PrecioCosto As Decimal

    Public Event CambioCodigo()
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.TablaEliminar = "Productos"
        Me.ComandoMantenimiento = "Productos_Mant"
        Me.ComandoSelect = "Productos_Buscar"

        Me.ColeccionParametrosBusqueda.Add(New Parametro("descripcion", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigoigual", Nothing))

        Me.ColeccionParametrosMantenimiento.Add(New Parametro("codigo", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("descripcion", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("precioventa", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("preciocosto", Nothing))
        _Codigo = String.Empty
        _Descripcion = String.Empty
        _PrecioVenta = 0
        _PrecioCosto = 0


    End Sub

    Public Sub New(ByVal id As Long, ByVal codigo As String, ByVal descripcion As String, ByVal preciocosto As Decimal, ByVal precioventa As Decimal)
        Me.New()
        Me._Id = id
        Me.Codigo = codigo
        Me.Descripcion = descripcion
        Me.PrecioVenta = precioventa
        Me.PrecioCosto = preciocosto
    End Sub

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

    Public Property CodigoParaBusqueda()
        Get
            Return Me.Codigo
        End Get
        Set(ByVal value)
            Me.Codigo = value
            RaiseEvent CambioCodigo()
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
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        ValorParametrosMantenimiento("codigo", Me.Codigo.Trim)
        ValorParametrosMantenimiento("descripcion", Me.Descripcion.Trim)
        ValorParametrosMantenimiento("precioventa", Me.PrecioVenta)
        MyBase.Guardar()
    End Sub

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.Codigo = Me.Registro(Indice, "codigo")
        Me.Descripcion = Me.Registro(Indice, "descripcion")
        Me.PrecioCosto = Me.Registro(Indice, "preciocosto")
        Me.PrecioVenta = Me.Registro(Indice, "precioventa")
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of Productos)
        If Me.TotalRegistros > 0 Then
            For x As Integer = 0 To Me.TotalRegistros - 1
                Me.CargadoPropiedades(x)
                Dim temPro As New Productos(Me.Id, Me.Codigo, Me.Descripcion, Me.PrecioCosto, Me.PrecioVenta)
                lista.Add(temPro)
            Next
        End If

        Return lista
    End Function
#End Region

#Region "Eventos"
    Private Sub Productos_CambioCodigo() Handles Me.CambioCodigo
        Me.Buscar("codigoigual", Me.Codigo)
    End Sub
#End Region
 
End Class

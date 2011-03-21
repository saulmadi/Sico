Imports SiCo.lgla
Public Class TransaccionesProductos
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _descripcion As String
    Private _codigo As String
    Private _precioventa As Decimal = 0
    Private _idsucursales As Long = 0
    Private _idproductos As Long = 0
    Private _cantidad As Long = 0

    Public Event CambioCodigo()
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        Me.ComandoSelect = "TransaccionesProductos_Buscar"

        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproductos", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("descripcion", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("inventarioTotal", Nothing))

        Me.descripcion = String.Empty
        Me._codigo = String.Empty
    End Sub
    Public Sub New(ByVal descripcion As String, ByVal codigo As String, ByVal idsucursales As Long, ByVal idproductos As Long, ByVal cantidad As Long, ByVal precioventa As Decimal)
        Me.New()
        Me.descripcion = descripcion
        Me._codigo = codigo
        Me.idsucursales = idsucursales
        Me.idproductos = idproductos
        Me.cantidad = cantidad
        Me.precioventa = precioventa

    End Sub
#End Region

#Region "Propiedades"
    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
            RaiseEvent CambioCodigo()
        End Set
    End Property

    Public Property precioventa() As Decimal
        Get
            Return _precioventa
        End Get
        Set(ByVal value As Decimal)
            _precioventa = value
        End Set
    End Property

    Public Property idsucursales() As Long
        Get
            Return _idsucursales
        End Get
        Set(ByVal value As Long)
            _idsucursales = value
        End Set
    End Property

    Public Property idproductos() As Long
        Get
            Return _idproductos
        End Get
        Set(ByVal value As Long)
            _idproductos = value
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

#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idproductos = Registro(Indice, "idproducto")
        Me.idsucursales = Registro(Indice, "idSucursales")
        Me.descripcion = Registro(Indice, "descripcion")
        Me.precioventa = Registro(Indice, "precioventa")
        Me._codigo = Registro(Indice, "codigo")
        Me.cantidad = Registro(Indice, "cantidad")
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of TransaccionesProductos)
        If Me.TotalRegistros > 0 Then
            For a As Integer = 0 To Me.TotalRegistros - 1
                Me.CargadoPropiedades(a)
                Dim temp As New TransaccionesProductos(Me.descripcion, Me.codigo, Me.idsucursales, Me.idproductos, Me.cantidad, Me.precioventa)
                lista.Add(temp)
            Next
        End If
        Return lista
    End Function

    Public Overloads Sub Buscar(ByVal codigo As String, ByVal descripcion As String, ByVal idsucursal As Long, Optional ByVal InventarioTotal As Boolean = False, Optional ByVal usuandoSucursal As Boolean = True)
        Try
            Me.NullParametrosBusqueda()
            Me.ValorParametrosBusqueda("codigo", codigo)
            Me.ValorParametrosBusqueda("descripcion", descripcion)



            If usuandoSucursal Then
                Dim s As New Sucursales
                s.Cargar()
                If s.Id > 0 Then
                    Me.ValorParametrosBusqueda("idsucursales", s.Id)
                End If
            Else
                Me.ValorParametrosBusqueda("idsucursales", idsucursal)
            End If

            If InventarioTotal Then
                Me.ValorParametrosBusqueda("idsucursales", Nothing)
                Me.ValorParametrosBusqueda("inventarioTotal", "1")
            End If

            Me.LlenadoTabla(ColeccionParametrosBusqueda)
        Catch ex As Exception
            Throw New ApplicationException("La sucursal no es debidamente configurada. ")
        End Try
    End Sub


#End Region

#Region "Eventos"
    Private Sub TransaccionesProductos_CambioCodigo() Handles Me.CambioCodigo
        Me.Buscar(Me.codigo, Nothing, Nothing, False)
    End Sub
#End Region

    
End Class

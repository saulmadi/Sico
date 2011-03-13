Imports SiCo.lgla

Public Class OrdenCompra
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _codigo As String = String.Empty
    Private _elaboradopor As Long
    Private _idproveedor As Long
    Private _fechaorden As Date
    Private _idsucursal As Long
    Private _listaDetalle As New List(Of DetalleOrdenCompra)
    Private _DiccionarioDetalle As New Dictionary(Of Long, DetalleOrdenCompra)
    Private _proveedor As New Proveedores
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "OrdenCompra_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("elaboradopor"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproveedor"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fechaorden"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigoparecido"))

        Me.ComandoMantenimiento = "OrdenCompra_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("codigo", Nothing, ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursal"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idproveedor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fechaorden"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("elaboradopor"))
    End Sub
    Public Sub New(ByVal id As Long, ByVal codigo As String, ByVal elaboradopor As Long, ByVal idproveedor As Long, ByVal fechaorden As Date, ByVal idsucursal As Long, ByVal proveedore As Proveedores)
        Me.New()
        Me._Id = id
        Me.codigo = codigo
        Me.elaboradopor = elaboradopor
        Me.idproveedor = idproveedor
        Me.fechaorden = fechaorden
        Me.idsucursal = idsucursal
        _proveedor = proveedore
    End Sub
#End Region

#Region "Propiedades"
    Public Property codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property elaboradopor() As Long
        Get
            Return _elaboradopor
        End Get
        Set(ByVal value As Long)
            _elaboradopor = value
        End Set
    End Property

    Public Property idproveedor() As Long
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Long)
            _idproveedor = value
        End Set
    End Property

    Public Property fechaorden() As Date
        Get
            Return _fechaorden
        End Get
        Set(ByVal value As Date)
            _fechaorden = value
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

    Public Property ListaDetalle() As List(Of DetalleOrdenCompra)
        Get
            Return _listaDetalle
        End Get
        Set(ByVal value As List(Of DetalleOrdenCompra))
            _listaDetalle = value
        End Set
    End Property

    Public Property Proveedor() As Proveedores
        Get
            If Me._proveedor.Id <> Me.idproveedor And Me.idproveedor > 0 Then
                _proveedor.Id = Me.idproveedor
            End If
            Return _proveedor
        End Get
        Set(ByVal value As Proveedores)
            _proveedor = value
        End Set
    End Property

    Public ReadOnly Property DescripcionProveedor() As String
        Get
            Return Proveedor.NombreMantenimiento
        End Get
    End Property

#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idproveedor = Me.Registro(Indice, "idproveedor")
        Me.idsucursal = Me.Registro(Indice, "idsucursal")
        Me.codigo = Me.Registro(Indice, "codigo")
        Me.elaboradopor = Me.Registro(Indice, "elaboradopor")
        Me.fechaorden = Me.Registro(Indice, "fechaorden")
        _proveedor = New Proveedores(Registro(Indice, "idproveedor"), Registro(Indice, "identidades"), Registro(Indice, "estado"), Registro(Indice, "idcontacto"), Registro(Indice, "descripcion"))
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        Me.codigo = " "
        Me.ValorParametrosMantenimiento("codigo", Me.codigo)
        Me.ValorParametrosMantenimiento("elaboradopor", Me.elaboradopor)
        Me.ValorParametrosMantenimiento("idproveedor", Me.Proveedor.Id)
        Me.ValorParametrosMantenimiento("fechaorden", Me.fechaorden)
        Me.ValorParametrosMantenimiento("idsucursal", Me.idsucursal)

        MyBase.Guardar(True)
        Me.codigo = Me.ValorParametrosMantenimiento("codigo")
    End Sub

    Private Sub CalcularDetalle()
        Me._DiccionarioDetalle.Clear()

        For Each i In Me.ListaDetalle
            If i.idproducto > 0 Then
                If Me._DiccionarioDetalle.ContainsKey(i.idproducto) Then
                    Me._DiccionarioDetalle(i.idproducto).Cantidad += i.Cantidad
                Else
                    Me._DiccionarioDetalle.Add(i.idproducto, i)
                End If
            End If
        Next
        If Me._DiccionarioDetalle.Count = 0 Then
            Throw New ApplicationException("Debe de ingresar un producto, para realizar la orden de compra")
        End If
    End Sub

    Public Sub GuardarOrdenCompra()
        Try
            Me.IniciarTransaccion()
            Me.CalcularDetalle()
            Me.Guardar()
            Dim flag As Boolean = False
            For Each i In _DiccionarioDetalle
                If i.Value.idproducto > 0 Then
                    i.Value.idordencompra = Me.Id
                    If i.Value.Cantidad > 0 Then
                        i.Value.Guardar()
                    Else
                        Throw New ApplicationException("La cantidad del producto" + i.Value.Descripcion + " no puede ser 0")
                    End If
                End If

            Next

            Me.CommitTransaccion()

        Catch ex As Exception
            Me.RollBackTransaccion()
            Throw New ApplicationException(ex.Message)
        End Try
    End Sub

    Public Sub CargarDetalle()
        _listaDetalle.Clear()
        If Me.Id > 0 Then
            Dim d As New DetalleOrdenCompra
            d.Buscar(Me.Id.ToString)
            _listaDetalle = d.TablaAColeccion
        End If
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim list As New List(Of OrdenCompra)
        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            Dim tempC As New OrdenCompra(Me.Id, Me.codigo, Me.elaboradopor, Me.idproveedor, Me.fechaorden, Me.idsucursal, Me.Proveedor)
            list.Add(tempC)
        Next
        Return list
    End Function
#End Region

End Class

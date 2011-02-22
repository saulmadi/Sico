Imports SiCo.lgla
Public Class Compras
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _facturacompra As Long
    Private _idproveedor As Long
    Private _fechacompra As Date
    Private _idsucursal As Long
    Private _totalcompra As Decimal
    Private _listaDetalle As New List(Of DetalleCompras)
    Private _proveedor As New Proveedores
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "Compra_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("facturacompra"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproveedor"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fechacompra"))

        Me.ComandoMantenimiento = "Compras_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("facturacompra"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursal"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idproveedor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fechacompra"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("totalcompra"))

        Me.TablaEliminar = "compras"

    End Sub
    Public Sub New(ByVal id As Long, ByVal facturacompra As Long, ByVal idsucursal As Long, ByVal idproveedor As Long, ByVal fechacompra As Date, ByVal totalcompra As Decimal)
        Me.New()
        Me._Id = id
        Me.facturacompra = facturacompra
        Me.idsucursal = idsucursal
        Me.idproveedor = idproveedor
        Me.fechacompra = fechacompra
        Me.totalcompra = totalcompra
    End Sub
#End Region

#Region "Propiedades"
    Public Property facturacompra() As Long
        Get
            Return _facturacompra
        End Get
        Set(ByVal value As Long)
            _facturacompra = value
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

    Public Property fechacompra() As Date
        Get
            Return _fechacompra
        End Get
        Set(ByVal value As Date)
            _fechacompra = value
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

    Public Property ListaDetalle() As List(Of DetalleCompras)
        Get
            If Me.Id > 0 Then
                Dim d As New DetalleCompras
                d.Buscar(Me.Id, Nothing)
                _listaDetalle = d.TablaAColeccion
            End If

            Return _listaDetalle
        End Get
        Set(ByVal value As List(Of DetalleCompras))
            _listaDetalle = value
        End Set
    End Property

    Public Property totalcompra() As Decimal
        Get
            Return _totalcompra
        End Get
        Set(ByVal value As Decimal)
            _totalcompra = value
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
            Return Me.Proveedor.NombreMantenimiento
        End Get
    End Property

    Public ReadOnly Property Impuesto() As Decimal
        Get
            Return CalcularTotal() * GeneralesConstantes.Impuesto
        End Get
    End Property
#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.facturacompra = Registro(Indice, "facturacompra")
        Me.idproveedor = Registro(Indice, "idproveedor")
        Me.fechacompra = Registro(Indice, "fechacompra")
        Me.idsucursal = Registro(Indice, "idsucursal")
        Me.totalcompra = Registro(Indice, "totalcompra")

        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("facturacompra", Me.facturacompra)
        Me.ValorParametrosMantenimiento("idsucursal", Me.idsucursal)
        Me.ValorParametrosMantenimiento("idproveedor", Me.idproveedor)
        Me.ValorParametrosMantenimiento("fechacompra", Me.fechacompra)
        Me.ValorParametrosMantenimiento("totalcompra", Me.totalcompra)

        MyBase.Guardar(True)
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim list As New List(Of Compras)
        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            Dim tempC As New Compras(Me.Id, Me.facturacompra, Me.idsucursal, Me.idproveedor, Me.fechacompra, Me.totalcompra)
            list.Add(tempC)
        Next
        Return list
    End Function

    Public Overloads Sub Buscar(ByVal facturacompra As String, ByVal idproveedor As String, ByVal fecha As Date)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("facturacompra", facturacompra)
        Me.ValorParametrosMantenimiento("idproveedor", idproveedor)
        If Not fecha = Nothing Then
            Me.ValorParametrosMantenimiento("fechacompra", " fechacompra >= " + fecha.ToString("yyyy-MM-dd") + " ")
        End If
    End Sub

    Public Sub GuardarCompra()
        Try
            Me.IniciarTransaccion()

            Me.Guardar()
            Dim flag As Boolean = False
            For i As Integer = 0 To Me.ListaDetalle.Count - 1
                If Me.ListaDetalle(i).idproducto > 0 Then
                    Me.ListaDetalle(i).idcompras = Me.Id
                    Me.ListaDetalle(i).idsucursal = Me.idsucursal
                    If Me.ListaDetalle(i).cantidad > 0 And Me.ListaDetalle(i).preciocompra > 0 Then
                        Me.ListaDetalle(i).Guardar()
                    Else
                        Throw New ApplicationException("La cantidad o el precio de compra de un producto no puede ser 0")
                    End If
                End If
            Next

            Me.CommitTransaccion()
        Catch ex As Exception
            Me.RollBackTransaccion()
            Throw New ApplicationException(ex.Message)
        End Try
    End Sub

    Public Function CalcularTotal() As Decimal
        Dim d As Decimal = 0
        For Each i In Me.ListaDetalle
            d += i.Subtotal
        Next
        Return d
    End Function

#End Region

#Region "eventos"

#End Region
End Class

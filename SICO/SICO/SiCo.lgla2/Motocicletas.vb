Imports SiCo.lgla

Public Class Motocicletas
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _Motor As String
    Private _Chasis As String
    Private _Cilindraje As Integer
    Private _estado As String = String.Empty
    Private _anio As Integer
    Private _fechaingreso As Date
    Private _idmarcas As Long
    Private _idmodelo As Long
    Private _idSucursales As Long
    Private _idTiposMotocicletas As Long
    Private _PrecioCompra As Decimal

    Private _PrecionVenta As Decimal
    Private _descripcionMarcas As String
    Private _descripcionModelos As String
    Private _sucursal As New Sucursales
    Private _hp As Integer
    Private _idproveedor As Long


#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "Motocicletas_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idmarca"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idmodelo"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("motor"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("chasis"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("estado"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursal"))

        Me.ComandoMantenimiento = "Motocicletas_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("motor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("chasis"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idmarcas"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idmodelos"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idtiposmotocicletas"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("cilindraje"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("anio"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("precioventa"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("precioingreso"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fechaingreso"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("estado"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("hp"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idproveedor"))

    End Sub

    Public Sub New(ByVal id As Long, ByVal motor As String, ByVal chasis As String, ByVal idmarcas As Long, ByVal idmodelos As Long, ByVal idTiposMotocicletas As Long _
                   , ByVal idsucursales As Long, ByVal cilindraje As Long, ByVal anio As Integer, ByVal precioventa As Decimal, ByVal preciocompra As Decimal, _
                   ByVal fechaingreso As Date, ByVal estado As String)
        Me.New()
        Me._Id = id
        Me.Motor = motor
        Me.Chasis = chasis
        Me.idmarcas = idmarcas
        Me.idmodelos = idmodelos
        Me.idTiposMotocicletas = idTiposMotocicletas
        Me.idSucursales = idsucursales
        Me.cilindraje = cilindraje
        Me.anio = anio
        Me.precioventa = precioventa
        Me.preciocompra = preciocompra
        Me.fechaingreso = fechaingreso
        Me.estado = estado



    End Sub


#End Region

#Region "Propiedades"
    Public Property Motor() As String
        Get
            Return _Motor
        End Get
        Set(ByVal value As String)
            _Motor = value
        End Set
    End Property

    Public Property Chasis() As String
        Get
            Return _Chasis
        End Get
        Set(ByVal value As String)
            _Chasis = value
        End Set

    End Property

    Public Property idmarcas() As Long
        Get
            Return _idmarcas
        End Get
        Set(ByVal value As Long)
            _idmarcas = value
        End Set
    End Property

    Public Property idmodelos() As Long
        Get
            Return _idmodelo
        End Get
        Set(ByVal value As Long)
            _idmodelo = value
        End Set
    End Property

    Public Property idTiposMotocicletas() As Long
        Get
            Return _idTiposMotocicletas
        End Get
        Set(ByVal value As Long)
            _idTiposMotocicletas = value
        End Set
    End Property

    Public Property idSucursales() As Long
        Get
            Return _idSucursales
        End Get
        Set(ByVal value As Long)
            _idSucursales = value
        End Set
    End Property

    Public Property cilindraje() As Integer
        Get
            Return _Cilindraje
        End Get
        Set(ByVal value As Integer)
            _Cilindraje = value
        End Set
    End Property

    Public Property anio() As Integer
        Get
            Return _anio
        End Get
        Set(ByVal value As Integer)
            _anio = value
        End Set
    End Property

    Public Property precioventa() As Decimal
        Get
            Return _PrecionVenta
        End Get
        Set(ByVal value As Decimal)
            _PrecionVenta = value
        End Set
    End Property

    Public Property preciocompra() As Integer
        Get
            Return _PrecioCompra
        End Get
        Set(ByVal value As Integer)
            _PrecioCompra = value
        End Set
    End Property

    Public Property fechaingreso() As Date
        Get
            Return _fechaingreso

        End Get
        Set(ByVal value As Date)
            _fechaingreso = value
        End Set
    End Property

    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property

    Public Property DescripcionMarcas() As String
        Get
            Return _descripcionMarcas
        End Get
        Set(ByVal value As String)
            _descripcionMarcas = value
        End Set
    End Property

    Public Property DescripcionModelos() As String
        Get
            Return _descripcionModelos
        End Get
        Set(ByVal value As String)
            _descripcionModelos = value
        End Set
    End Property

    Public Property Sucursal() As Sucursales
        Get
            Return _sucursal
        End Get
        Set(ByVal value As Sucursales)
            _sucursal = value
        End Set
    End Property

    Public ReadOnly Property DescripcionSucursales() As String
        Get
            Return Me.Sucursal.NombreMantenimiento
        End Get
    End Property

    Public ReadOnly Property DescripcionEstado()
        Get
            If estado = "V" Then
                Return "Vendida"
            ElseIf estado = "I" Then
                Return "En Inventario"
            End If
            Return ""

        End Get
    End Property

    Public Property HP() As Integer
        Get
            Return _hp
        End Get
        Set(ByVal value As Integer)
            _hp = value
        End Set
    End Property

    Public Property idProveedor() As Long
        Get
            Return _idproveedor
        End Get
        Set(ByVal value As Long)
            _idproveedor = value
        End Set
    End Property
#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.Motor = Registro(Indice, "motor")
        Me.Chasis = Registro(Indice, "chasis")
        Me.idmarcas = Registro(Indice, "idmarcas")
        Me.idmodelos = Registro(Indice, "idmodelos")
        Me.idTiposMotocicletas = Registro(Indice, "idtiposmotocicletas")
        Me.idSucursales = Registro(Indice, "idsucursales")
        Me.cilindraje = Registro(Indice, "cilindraje")
        Me.estado = Registro(Indice, "estado")
        Me.anio = Registro(Indice, "anio")
        Me.precioventa = Registro(Indice, "precioventa")
        Me.preciocompra = Registro(Indice, "precioingreso")
        Me.fechaingreso = Registro(Indice, "fechaingreso")
        Me.DescripcionMarcas = Registro(Indice, "descripcionmarcas")
        Me.DescripcionModelos = Registro(Indice, "descripcionmodelos")
        Me.Sucursal = New Sucursales(Me.idSucursales, Convert.ToInt64(Registro(Indice, "identidades")), Registro(Indice, "descripcion"))
        Me.HP = Registro(Indice, "hp")
        Me.idProveedor = Registro(Indice, "idproveedor")

        MyBase.CargadoPropiedades(Indice)

    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("motor", Me.Motor)
        Me.ValorParametrosMantenimiento("chasis", Me.Chasis)
        Me.ValorParametrosMantenimiento("idmarcas", Me.idmarcas)
        Me.ValorParametrosMantenimiento("idmodelos", Me.idmodelos)
        Me.ValorParametrosMantenimiento("idtiposmotocicletas", Me.idTiposMotocicletas)
        Me.ValorParametrosMantenimiento("idSucursales", Me.idSucursales)
        Me.ValorParametrosMantenimiento("cilindraje", Me.cilindraje)
        Me.ValorParametrosMantenimiento("anio", Me.anio)
        Me.ValorParametrosMantenimiento("precioventa", Me.precioventa)
        Me.ValorParametrosMantenimiento("precioingreso", Me.preciocompra)
        Me.ValorParametrosMantenimiento("fechaingreso", Me.fechaingreso)

        Me.ValorParametrosMantenimiento("estado", Me.estado)
        Me.ValorParametrosMantenimiento("hp", Me.HP)
        Me.ValorParametrosMantenimiento("idproveedor", Me.idProveedor)

        MyBase.Guardar()
    End Sub

    Public Sub GuardarTransaccion()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("motor", Me.Motor)
        Me.ValorParametrosMantenimiento("chasis", Me.Chasis)
        Me.ValorParametrosMantenimiento("idmarcas", Me.idmarcas)
        Me.ValorParametrosMantenimiento("idmodelos", Me.idmodelos)
        Me.ValorParametrosMantenimiento("idTiposMotociletas", Me.idTiposMotocicletas)
        Me.ValorParametrosMantenimiento("idSucursales", Me.idSucursales)
        Me.ValorParametrosMantenimiento("cilindraje", Me.cilindraje)
        Me.ValorParametrosMantenimiento("anio", Me.anio)
        Me.ValorParametrosMantenimiento("precioventa", Me.precioventa)
        Me.ValorParametrosMantenimiento("precioingreso", Me.preciocompra)
        Me.ValorParametrosMantenimiento("estado", Me.estado)
        Me.ValorParametrosMantenimiento("hp", Me.HP)
        Me.ValorParametrosMantenimiento("idproveedor", Me.idProveedor)

        MyBase.Guardar(True)
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of Motocicletas)
        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            Dim tempMoto = New Motocicletas(Id, Motor, Chasis, idmarcas, idmodelos, idTiposMotocicletas, idSucursales, cilindraje, _
                                             Me.anio, Me.precioventa, Me.preciocompra, Me.fechaingreso, Me.estado)
            tempMoto.DescripcionModelos = Me.DescripcionModelos
            tempMoto.DescripcionMarcas = Me.DescripcionMarcas
            tempMoto.HP = Me.HP
            tempMoto.idProveedor = Me.idProveedor
            tempMoto.Sucursal = Me.Sucursal
            lista.Add(tempMoto)
        Next
        Return lista
    End Function

#End Region


End Class

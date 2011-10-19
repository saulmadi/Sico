Imports SiCo.lgla


Public Class Movimientoscuentacorriente
    Inherits Entidad

#Region "Declaraciones"

    Private _idtipomovimiento As Integer

    Private _monto As Decimal

    Private _descripcion As String

    Private _fechavencimiento As Nullable(Of Date)

    Private _fecha As Date

    Private _idrubro As Integer

    Private _debito As Decimal
    Private _credito As Decimal

#End Region

#Region "Constructor"

    Public Sub New()
        Me.ComandoSelect = "MoviemientosCuentaCorriente_Buscar"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("identidadbenficiaria"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("identidaddeudora"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("propietario"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idrubro"))


    End Sub

#End Region

#Region "Propiedades"

    ''' <summary>
    ''' There are no comments for idtipomovimiento in the schema.
    ''' </summary>
    Public Overridable Property idtipomovimiento() As Integer
        Get
            Return Me._idtipomovimiento
        End Get
        Set (ByVal value As Integer)

            Me._idtipomovimiento = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for monto in the schema.
    ''' </summary>
    Public Overridable Property monto() As Decimal
        Get
            Return Me._monto
        End Get
        Set (ByVal value As Decimal)

            Me._monto = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for descripcion in the schema.
    ''' </summary>
    Public Overridable Property descripcion() As String
        Get
            Return Me._descripcion
        End Get
        Set (ByVal value As String)

            Me._descripcion = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for fechavencimiento in the schema.
    ''' </summary>
    Public Overridable Property fechavencimiento() As Nullable(Of Date)
        Get
            Return Me._fechavencimiento
        End Get
        Set (ByVal value As Nullable(Of Date))

            Me._fechavencimiento = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for fecha in the schema.
    ''' </summary>
    Public Overridable Property fecha() As Date
        Get
            Return Me._fecha
        End Get
        Set (ByVal value As Date)

            Me._fecha = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for idrubro in the schema.
    ''' </summary>
    Public Overridable Property idrubro() As Integer
        Get
            Return Me._idrubro
        End Get
        Set (ByVal value As Integer)

            Me._idrubro = value
        End Set
    End Property

    Public Property debito() As Decimal
        Get
            Return _debito
        End Get
        Set (ByVal value As Decimal)
            _debito = value
        End Set
    End Property

    Public Property credito() As Decimal
        Get
            Return _credito
        End Get
        Set (ByVal value As Decimal)
            _credito = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades (ByVal Indice As Integer)
        CargarClase (Of Movimientoscuentacorriente) (Indice, Me)
    End Sub

    Public Overloads Function TablaAColeccion() As List(Of Movimientoscuentacorriente)
        Return Me.CaragarColeccion (Of Movimientoscuentacorriente)()
    End Function

    Public Overloads Sub Buscar (ByVal identidaddudora As Long, ByVal identidadbenecifiarias As Long, _
                                 ByVal propietario As Integer, ByVal idrubro As Integer)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda ("identidaddeudora", identidaddudora.ToString)
        Me.ValorParametrosBusqueda ("identidadbenficiaria", identidadbenecifiarias.ToString)
        Me.ValorParametrosBusqueda ("propietario", propietario)
        Me.ValorParametrosBusqueda ("idrubro", idrubro.ToString)
        Me.LlenadoTabla (Me.ColeccionParametrosBusqueda)

    End Sub

#End Region
End Class



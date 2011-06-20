Imports SiCo.lgla
Public Class ControlCaja
    Inherits SiCo.lgla.Entidad
#Region "Declaraciones"
    Private _idtransaccionescaja As Long
    Private _idsucursales As Long
    Private _monto As Decimal
    Private _fecha As DateTime
    Private _cajero As Long
    Private _descripcion As String

#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "ControlCaja_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idtransacciones"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fecha"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales"))

        Me.ComandoMantenimiento = "ControlCaja_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idtransaccionescaja"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("monto"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fecha"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("cajero"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("descripcion"))


    End Sub

    Public Sub New(ByVal id As Long, ByVal idtransccionescaja As Long, ByVal idsucursales As Long, ByVal monto As Decimal, ByVal fecha As DateTime, ByVal cajero As Long, ByVal descripcion As String)
        Me.New()
        Me._Id = id
        Me.idTransaccionesCaja = idtransccionescaja
        Me.idSucursales = idsucursales
        Me.Monto = monto
        Me.Fecha = fecha
        Me.Cajero = cajero
        Me.Descripcion = descripcion
    End Sub
#End Region

#Region "Propiedades"
    Public Property idTransaccionesCaja() As Long
        Get
            Return _idtransaccionescaja
        End Get
        Set(ByVal value As Long)
            _idtransaccionescaja = value
        End Set
    End Property

    Public Property idSucursales() As Long
        Get
            Return _idSucursales
        End Get
        Set(ByVal value As Long)
            _idsucursales = value
        End Set
    End Property

    Public Property Monto() As Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As Decimal)
            _monto = value
        End Set
    End Property

    Public Property Fecha() As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Public Property Cajero() As Long
        Get
            Return _cajero
        End Get
        Set(ByVal value As Long)
            _cajero = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idTransaccionesCaja = Registro(Indice, "idtransaccionescaja")
        Me.idSucursales = Registro(Indice, "idsucursales")
        Me.Monto = Registro(Indice, "monto")
        Me.Fecha = Registro(Indice, "fecha")
        Me.Cajero = Registro(Indice, "cajero")
        Me.Descripcion = Registro(Indice, "descripcion")
        MyBase.CargadoPropiedades(Indice)

    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idtransaccionescaja", idTransaccionesCaja)
        Me.ValorParametrosMantenimiento("idsucursales", idSucursales)
        Me.ValorParametrosMantenimiento("monto", Monto)
        Me.ValorParametrosMantenimiento("fecha", Fecha)
        Me.ValorParametrosMantenimiento("cajero", Cajero)
        Me.ValorParametrosMantenimiento("descripcion", Descripcion)


        MyBase.Guardar(True)
    End Sub

    Public Overrides Function TablaAColeccion() As Object

    End Function
#End Region
    

End Class

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

        Me.Fecha = Now
        Me.ComandoSelect = "ControlCaja_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idtransacciones"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fecha"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("cajero"))

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
        Dim lista As New List(Of ControlCaja)
        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            Dim tempControl = New ControlCaja(Me.Id, Me.idTransaccionesCaja, Me.idSucursales, Me.Monto, Me.Fecha, Me.Cajero, Me.Descripcion)
            lista.Add(tempControl)
        Next
        Return lista
    End Function

    Public Sub IngresarTransaccion(ByVal idtransaccion As Long, ByVal idsucursal As Long, ByVal monto As Decimal, ByVal fecha As DateTime, ByVal cajero As Long, ByVal descripcion As String)
        Try
            Me.idTransaccionesCaja = idtransaccion
            Me.idSucursales = idsucursal
            Me.Monto = monto
            Me.Fecha = fecha
            Me.Cajero = cajero
            Me.Descripcion = descripcion
            Me.Guardar()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Overloads Sub Buscar(ByVal idtransaccion As Long, ByVal cajero As Long, ByVal fecha As DateTime, ByVal sucursal As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("idtransacciones", idtransaccion.ToString)
        Me.ValorParametrosBusqueda("cajero", cajero.ToString)
        Me.ValorParametrosBusqueda("fecha", " fecha ='" + fecha.ToString("yyyy-MM-dd") + "'")
        Me.ValorParametrosBusqueda("idsucursales", sucursal)
        Me.LlenadoTabla(ColeccionParametrosBusqueda)
    End Sub

    Public Function AperturaCaja(ByVal cajero As Long, ByVal fecha As DateTime, ByVal sucursal As String)
        Me.Buscar(4, cajero, fecha, sucursal)
        If Me.TotalRegistros = 1 Then
            Return True
        End If
        Return False
    End Function

    

    Public Function RealizarApertura(ByVal cajero As Long, ByVal monto As Decimal, ByVal fecha As DateTime, ByVal sucursal As Long, ByVal usuario As Usuario)
        Try
            Me.IniciarTransaccion()
            Me.IngresarTransaccion(4, sucursal, monto, fecha, cajero, "Apertura de caja para el usuario " + usuario.NombreUsuario)
            Me.CommitTransaccion()
            Return True
        Catch ex As Exception
            Me.RollBackTransaccion()
            Throw ex
        End Try
    End Function

    Public Function RealizarIngresoEfectivo(ByVal cajero As Long, ByVal monto As Decimal, ByVal fecha As DateTime, ByVal sucursal As Long, ByVal usuario As Usuario)
        Try
            Me.IniciarTransaccion()
            Me.IngresarTransaccion(7, sucursal, monto, fecha, cajero, "Se ingreso efectivo para el usuario " + usuario.NombreUsuario)
            Me.CommitTransaccion()
            Return True
        Catch ex As Exception
            Me.RollBackTransaccion()
            Throw ex
        End Try
    End Function

    Public Function RealizarRetiroEfectivo(ByVal cajero As Long, ByVal monto As Decimal, ByVal fecha As DateTime, ByVal sucursal As Long, ByVal usuario As Usuario)
        Try
            Me.IniciarTransaccion()
            Me.IngresarTransaccion(6, sucursal, monto, fecha, cajero, "Se retiro efectivo para el usuario " + usuario.NombreUsuario)
            Me.CommitTransaccion()
            Return True
        Catch ex As Exception
            Me.RollBackTransaccion()
            Throw ex
        End Try
    End Function


#End Region


End Class

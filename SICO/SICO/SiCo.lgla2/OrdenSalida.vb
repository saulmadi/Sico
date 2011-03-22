Imports SiCo.lgla
Public Class OrdenSalida
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _codigo As String
    Private _enviadopor As Long
    Private _estado As String
    Private _fechaemision As Date
    Private _recibidopor As Long
    Private _sucursalenvia As Long
    Private _sucursalrecibe As Long

    Private _ListaDetalle As New List(Of DetalleOrdenSalida)
    Private _diccionariodetalle As New Dictionary(Of Long, DetalleOrdenSalida)

    Private _sucursalEn As New Sucursales
    Private _sucursalRe As New Sucursales
#End Region

#Region "constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "OrdenSalida_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigoparecido"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("sucursalenvia"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("sucursalrecibe"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("estado"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fechaemision"))


        Me.ComandoMantenimiento = "OrdenSalida_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("codigo", Nothing, ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("enviadopor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("recibidopor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fechaemision"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("sucursalenvia"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("sucursalrecibe"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("estado"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("requisicion"))


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

    Public Property fechaemision() As Date
        Get
            Return _fechaemision
        End Get
        Set(ByVal value As Date)
            _fechaemision = value
        End Set
    End Property

    Public Property enviadopor() As Long
        Get
            Return _enviadopor
        End Get
        Set(ByVal value As Long)
            _enviadopor = value
        End Set
    End Property

    Public Property recibidopor() As Long
        Get
            Return _recibidopor
        End Get
        Set(ByVal value As Long)
            _recibidopor = value
        End Set
    End Property

    Public Property sucursalenvia() As Long
        Get
            Return _sucursalenvia
        End Get
        Set(ByVal value As Long)
            _sucursalenvia = value
        End Set
    End Property

    Public Property sucursalrecibe() As Long
        Get
            Return _sucursalrecibe
        End Get
        Set(ByVal value As Long)
            _sucursalrecibe = value
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

    Public Property Listadetalle() As List(Of DetalleOrdenSalida)
        Get
            Return _ListaDetalle
        End Get
        Set(ByVal value As List(Of DetalleOrdenSalida))
            _ListaDetalle = value
        End Set
    End Property

    Public Property SucursalEn() As Sucursales
        Get
            If sucursalenvia = Nothing Then

                _sucursalEn = New Sucursales
                Return _sucursalEn
            End If

            If Me.sucursalenvia > 0 And _sucursalEn.Id <> Me.sucursalenvia Then
                _sucursalEn.Id = Me.sucursalenvia
            End If
            Return _sucursalEn
        End Get
        Set(ByVal value As Sucursales)
            _sucursalEn = value
        End Set
    End Property

    Public Property SucursalRec() As Sucursales
        Get
            If Me.sucursalrecibe = Nothing Then
                _sucursalRe = New Sucursales
                Return _sucursalRe
            End If
            If Me.sucursalrecibe > 0 And _sucursalRe.Id <> Me.sucursalrecibe Then
                _sucursalRe.Id = Me.sucursalrecibe
            End If
            Return _sucursalRe
        End Get
        Set(ByVal value As Sucursales)
            _sucursalRe = value
        End Set
    End Property

    Public ReadOnly Property DescripcionEstado() As String
        Get
            If Me.estado = "E" Then
                Return "Enviada"

            End If
            If Me.estado = "R" Then
                Return "Recibida"
            End If
            Return String.Empty
        End Get
    End Property

    Public ReadOnly Property DescripcionSucursalEnvia() As String
        Get
            Return SucursalEn.NombreMantenimiento
        End Get
    End Property

    Public ReadOnly Property DescripcionSucursalRecibe() As String
        Get
            Return SucursalRec.NombreMantenimiento
        End Get
    End Property

#End Region

#Region "Metodos"

#End Region
End Class

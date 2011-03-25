Imports SiCo.lgla
Public Class OrdenSalida
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _codigo As String
    Private _enviadopor As Long
    Private _estado As String
    Private _fechaemision As Date
    Private _recibidopor As Long?
    Private _sucursalenvia As Long
    Private _sucursalrecibe As Long
    Private _requisicion As Long?

    Private _ListaDetalle As New List(Of DetalleOrdenSalida)
    Private _diccionariodetalle As New Dictionary(Of Long, DetalleOrdenSalida)

    Private _sucursalEn As New Sucursales
    Private _sucursalRe As New Sucursales

    Private _OrdenRequisicion As New OrdenRequiscion()

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

    Public Property recibidopor() As Long?
        Get
            Return _recibidopor
        End Get
        Set(ByVal value As Long?)
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

    Public Property requisicion() As Long?
        Get
            Return _requisicion
        End Get
        Set(ByVal value As Long?)
            _requisicion = value
        End Set
    End Property

    Public Property OredenRequicion() As OrdenRequiscion
        Get
            Return _OrdenRequisicion
        End Get
        Set(ByVal value As OrdenRequiscion)
            _OrdenRequisicion = value
        End Set
    End Property

    Public ReadOnly Property TotalItems() As Long
        Get
            Try
                CalcularDetalle()
            Catch ex As Exception

            End Try

            Return _diccionariodetalle.Count
        End Get
    End Property

    Public ReadOnly Property CantidadTotalProductos() As Long
        Get
            Try
                Return CalcularDetalle()
            Catch ex As Exception
                Return 0
            End Try

        End Get
    End Property
#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.codigo = Registro(Indice, "codigo")
        Me.fechaemision = Registro(Indice, "fechaemision")
        Me.enviadopor = Registro(Indice, "enviadopor")
        Me.recibidopor = Registro(Indice, "recibidopor")
        Me.sucursalenvia = Registro(Indice, "sucursalenvia")
        Me.sucursalrecibe = Registro(Indice, "sucursalrecibe")
        Me.estado = Registro(Indice, "estado")
        Me.requisicion = Registro(Indice, "requisicion")

        If Not sucursalenvia = Nothing Then
            Me._sucursalEn = New Sucursales(sucursalenvia, Convert.ToInt64(Registro(Indice, "identidadesenvia")), Registro(Indice, "descripcionenvia").ToString)
        End If

        If Not sucursalrecibe = Nothing Then
            Me._sucursalRe = New Sucursales(sucursalrecibe, Convert.ToInt64(Registro(Indice, "identidadesrecibe")), Registro(Indice, "descripcionrecibe").ToString)
        End If

        MyBase.CargadoPropiedades(Indice)
    End Sub

    Private Function CalcularDetalle() As Long
        Me._diccionariodetalle.Clear()
        Dim cantot As Long = 0

        For g As Integer = 0 To Me.Listadetalle.Count - 1
            Dim i As DetalleOrdenSalida = Listadetalle(g)
            If i.idproducto > 0 Then
                If Me._diccionariodetalle.ContainsKey(i.idproducto) Then
                    'Me._diccionariodetalle(i.idproducto).Cantidad += i.Cantidad
                    cantot += i.Cantidad
                Else
                    Me._diccionariodetalle.Add(i.idproducto, i)
                    cantot += i.Cantidad
                End If
            End If
        Next
        If Me._diccionariodetalle.Count = 0 Then
            'Throw New ApplicationException("Debe de ingresar un producto, para realizar la orden de compra")
        End If
        Return cantot
    End Function

    Private Function CalcularDetalleGuardar() As Long
        Me._diccionariodetalle.Clear()
        Dim cantot As Long = 0

        For g As Integer = 0 To Me.Listadetalle.Count - 1
            Dim i As DetalleOrdenSalida = Listadetalle(g)
            If i.idproducto > 0 Then
                If Me._diccionariodetalle.ContainsKey(i.idproducto) Then
                    'Me._diccionariodetalle(i.idproducto).Cantidad += i.Cantidad
                    cantot += i.Cantidad
                Else
                    Me._diccionariodetalle.Add(i.idproducto, i)
                    cantot += i.Cantidad
                End If
            End If
        Next
        If Me._diccionariodetalle.Count = 0 Then
            Throw New ApplicationException("Debe de ingresar un producto, para realizar la orden de requisición")
        End If
        Return cantot
    End Function

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        ValorParametrosMantenimiento("codigo", "")
        ValorParametrosMantenimiento("enviadopor", Me.enviadopor)
        ValorParametrosMantenimiento("recibidopor", Me.recibidopor)
        ValorParametrosMantenimiento("fechaemision", Me.fechaemision)
        ValorParametrosMantenimiento("sucursalenvia", Me.sucursalenvia)
        ValorParametrosMantenimiento("sucursalrecibe", Me.sucursalrecibe)
        ValorParametrosMantenimiento("estado", Me.estado)
        ValorParametrosMantenimiento("requicicion", Me.requisicion)
        MyBase.Guardar(True)
        Me.codigo = Me.ValorParametrosMantenimiento("codigo")
    End Sub

    Public Sub GuardarOrdenSalida()
        Try
            Me.IniciarTransaccion()
            Me.CalcularDetalleGuardar()
            Me.Guardar()
            Dim flag As Boolean = False
            For Each i In _diccionariodetalle
                If i.Value.idProducto > 0 Then
                    i.Value.idsalida = Me.Id
                    If i.Value.Cantidad > 0 Then
                        i.Value.Guardar()
                    Else
                        Throw New ApplicationException("La cantidad del producto" + i.Value.ProductoDescripcion + " no puede ser 0")
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
            Dim d As New DetalleOrdenSalida
            d.Buscar(CType(Me.Id, Long), "")
            _listaDetalle = d.TablaAColeccion
        End If
    End Sub

#End Region

End Class

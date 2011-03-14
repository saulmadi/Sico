Imports SiCo.lgla
Public Class OrdenRequiscion
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _codigo As String
    Private _enviadopor As Long
    Private _estado As String
    Private _fechaemision As Date
    Private _recibidopor As Long
    Private _sucursalenvia As Long
    Private _sucursalrecibe As Long

    Private _ListaDetalle As New List(Of DetalleRequisicion)
    Private _diccionariodetalle As New Dictionary(Of Long, DetalleRequisicion)

    Private _sucursalEn As New Sucursales
    Private _sucursalRe As New Sucursales

#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "OrdenRequisicion_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigoparecido"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("sucursalenvia"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("sucursalrecibe"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("estado"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fechaemision"))


        Me.ComandoMantenimiento = "OrdenRequisicion_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("codigo", Nothing, ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("enviadopor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("recibidopor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fechaemision"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("sucursalenvia"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("sucursalrecibe"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("estado"))


    End Sub

    Public Sub New(ByVal id As Long, ByVal fechaemision As Date, ByVal enviadopor As Long, ByVal recibidopor As Long, ByVal sucursalenvia As Long, ByVal sucursalrecibe As Long, ByVal estado As String)
        Me.New()
        Me._Id = id
        Me.fechaemision = fechaemision
        Me.enviadopor = enviadopor
        Me.recibidopor = recibidopor
        Me.sucursalenvia = sucursalenvia
        Me.sucursalrecibe = sucursalrecibe
        Me.estado = estado
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

    Public Property Listadetalle() As List(Of DetalleRequisicion)
        Get
            Return _ListaDetalle
        End Get
        Set(ByVal value As List(Of DetalleRequisicion))
            _ListaDetalle = value
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

#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.codigo = Registro(Indice, "codigo")
        Me.fechaemision = Registro(Indice, "fechaemsion")
        Me.enviadopor = Registro(Indice, "enviadopor")
        Me.recibidopor = Registro(Indice, "recibidopor")
        Me.sucursalenvia = Registro(Indice, "sucursalenvia")
        Me.sucursalrecibe = Registro(Indice, "sucursalrecibe")

        If Not sucursalenvia = Nothing Then
            Me._sucursalEn = New Sucursales(sucursalenvia, Registro(Indice, "identidadesenvia"), Registro(Indice, "descripcionenvia"))
        End If

        If Not sucursalrecibe = Nothing Then
            Me._sucursalRe = New Sucursales(sucursalrecibe, Registro(Indice, "identidadesrecibe"), Registro(Indice, "descripcionrecibe"))
        End If

        MyBase.CargadoPropiedades(Indice)
    End Sub

    Private Function CalcularDetalle() As Long
        Me._diccionariodetalle.Clear()
        Dim cantot As Long = 0

        For g As Integer = 0 To Me.Listadetalle.Count - 1
            Dim i As DetalleRequisicion = Listadetalle(g)
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
            Dim i As DetalleRequisicion = Listadetalle(g)
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

    Public Sub CargarDetalle()
        _listaDetalle.Clear()
        If Me.Id > 0 Then
            Dim d As New DetalleRequisicion
            d.Buscar(Me.Id.ToString)
            _listaDetalle = d.TablaAColeccion
        End If
    End Sub

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        Me.codigo = " "
        Me.ValorParametrosMantenimiento("codigo", Me.codigo)
        Me.ValorParametrosMantenimiento("enviadopor", Me.enviadopor)
        If Me.estado = "R" Then
            Me.ValorParametrosMantenimiento("recibidopor", Me.recibidopor)
        Else
            Me.ValorParametrosMantenimiento("recibidopor", Nothing)
        End If

        Me.ValorParametrosMantenimiento("fechaemision", Me.fechaemision)
        Me.ValorParametrosMantenimiento("sucursalenvia", Me.sucursalenvia)
        Me.ValorParametrosMantenimiento("sucursalrecibe", Me.sucursalrecibe)
        Me.ValorParametrosMantenimiento("estado", Me.estado)


        MyBase.Guardar(True)
        Me.codigo = Me.ValorParametrosMantenimiento("codigo")
    End Sub

    Public Sub GuardarOrdenRequisicion()
        Try
            Me.IniciarTransaccion()
            Me.CalcularDetalleGuardar()
            Me.Guardar()
            Dim flag As Boolean = False
            For Each i In _diccionariodetalle
                If i.Value.idproducto > 0 Then
                    i.Value.idRequisicion = Me.Id
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

#End Region


End Class

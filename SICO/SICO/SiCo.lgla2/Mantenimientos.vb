Imports SiCo.lgla
Public MustInherit Class Mantenimientos
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _idEntidades As Integer
#End Region

#Region "Construtor"
    Public Sub New()
        MyBase.New()
        Me.ColeccionParametrosBusqueda.Add(New Parametro("identidades", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("identidades", Nothing))

        Me.ColeccionParametrosBusqueda.Add(New Parametro("entidadnombre", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("espersonnatural", Nothing))
    End Sub
#End Region

#Region "Propiedaes"

    Public Property idEntidades() As Integer
        Get
            Return _idEntidades
        End Get
        Set(ByVal value As Integer)
            _idEntidades = value
        End Set
    End Property

    Public ReadOnly Property PersonaNatural() As PersonaNatural
        Get
            Return CrearPersonaNatural()
        End Get
    End Property

    Public ReadOnly Property PersonaJuridica() As PersonaJuridica
        Get
            Return CrearPersonaJuridica()
        End Get
    End Property


#End Region

#Region "Metodos"

    Public Overrides Sub Guardar()
        Me.ValorParametrosMantenimiento("identidades", Me.idEntidades)
        MyBase.Guardar()
    End Sub

    Public Overloads Sub Buscar(ByVal identidades As Integer)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("identidades", identidades)
        Me.LlenadoTabla(ColeccionParametrosBusqueda)
    End Sub

    Public Overloads Sub buscar(ByVal EntidadNombre As String, ByVal EsPersonaNatural As Boolean)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("entidadnombre", EntidadNombre)
        Me.ValorParametrosBusqueda("espersonnatural", EsPersonaNatural)
        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)
    End Sub

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idEntidades = Me.Registro(Indice, "identidades")
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Private Function CrearPersonaNatural() As PersonaNatural
        Dim i As Integer = PrimerRegistro("identidades")
        If Not i = Nothing Then
            Return New PersonaNatural(i, PrimerRegistro("entidadnombre"), New TipoIdentidad(PrimerRegistro("tipoidentificacion").ToString()), PrimerRegistro("identificacion").ToString, PrimerRegistro("correo"), PrimerRegistro("direccion"), PrimerRegistro("rtn"), PrimerRegistro("telefono"))
        End If
        Return Nothing
    End Function

    Private Function CrearPersonaJuridica() As PersonaJuridica

        Dim i As Integer = PrimerRegistro("identidades")
        If Not i = Nothing Then
            Return New PersonaJuridica(i, PrimerRegistro("entidadnombre"), PrimerRegistro("correo"), PrimerRegistro("direccion"), PrimerRegistro("rtn"), PrimerRegistro("telefono"))
        End If
        Return Nothing
    End Function

#End Region

End Class

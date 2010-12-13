Imports SiCo.lgla
Public MustInherit Class TablasTipo
    Inherits SiCo.lgla.Entidad
#Region "Declaraciones"
    Private _Descripcion As String
    Private _habilitado As Boolean
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        Me.ColeccionParametrosBusqueda.Add(New Parametro("descripcion", Nothing))

        Me.ColeccionParametrosMantenimiento.Add(New Parametro("habilitado", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("descripcion", Nothing))
    End Sub
#End Region

#Region "Propiedades"
    Public Property descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property habilitado() As Boolean
        Get
            Return _habilitado
        End Get
        Set(ByVal value As Boolean)
            _habilitado = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Overloads Sub Buscar(ByVal Descripcion As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("descripcion", Descripcion)
        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)
    End Sub

    Protected Overrides Sub CargadoPropiedades()

        Me.descripcion = PrimerRegistro("descripcion")
        Me.habilitado = PrimerRegistro("habilitado")

        MyBase.CargadoPropiedades()
    End Sub

    Public Overrides Sub Guardar()
        Me.ValorParametrosMantenimiento("descripcion", Me.descripcion)
        Me.ValorParametrosMantenimiento("habilitado", Me.habilitado)
        MyBase.Guardar()
    End Sub

#End Region


End Class

Imports SiCo.lgla
Public Class Mantenimientos
    Inherits SiCo.lgla.Entidad
#Region "Declaraciones"
    Private _idEntidades As Integer
#End Region

#Region "Construtor"
    Public Sub New()
        MyBase.New()
        Me.ColeccionParametrosBusqueda.Add(New Parametro("identidades", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("identidades", Nothing))

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

    Protected Overrides Sub CargadoPropiedades()
        Me.idEntidades = Me.PrimerRegistro("identidades")
        MyBase.CargadoPropiedades()
    End Sub

#End Region

End Class

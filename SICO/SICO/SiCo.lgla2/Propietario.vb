Imports SiCo.lgla
Public Class Propietario
    Inherits SiCo.lgla.Entidad
#Region "Declaraciones"
    Private _idEntidades As Long
#End Region
#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "Propietario_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("identidades"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("entidadnombre"))



        Me.ComandoMantenimiento = "Propietario_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("identidades"))
    End Sub
#End Region

#Region "Propiedades"
    Public Property idEntidades() As Long
        Get
            Return _idEntidades
        End Get
        Set(ByVal value As Long)
            _idEntidades = value
        End Set
    End Property
#End Region
#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idEntidades = Registro(Indice, "identidades")
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("identidades", Me._idEntidades)
        MyBase.Guardar()
    End Sub


#End Region

End Class

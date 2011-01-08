Imports SiCo.lgla
Public Class Proveedores
    Inherits Mantenimientos

#Region "Declaraciones"
    Private _IdContacto As Integer
#End Region

#Region "Constructor"
    Sub New()
        MyBase.New()
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idcontacto", Nothing))

        Me.ComandoSelect = "Proveedores_Buscar"
        Me.ComandoMantenimiento = "Proveedores_Mant"

    End Sub
#End Region

#Region "Propiedadaes"

    Public Property IdContacto() As Integer
        Get
            Return _IdContacto
        End Get
        Set(ByVal value As Integer)
            _IdContacto = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.IdContacto = Me.Registro(Indice, "idContacto")
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idcontacto", Me.IdContacto)
        MyBase.Guardar()
    End Sub

#End Region


End Class

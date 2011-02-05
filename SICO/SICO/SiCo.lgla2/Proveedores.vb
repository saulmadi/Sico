Imports SiCo.lgla
Public Class Proveedores
    Inherits Mantenimientos

#Region "Declaraciones"
    Private _IdContacto As Long
#End Region

#Region "Constructor"
    Sub New()
        MyBase.New()
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idcontacto", Nothing))

        Me.TablaEliminar = "Proveedores"
        Me.TablaBusqueda = "Proveedores"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tabla", TablaBusqueda))
        Me.ComandoMantenimiento = "Proveedores_Mant"

    End Sub
    Sub New(ByVal id As Long, ByVal identidades As Long, ByVal estado As Integer, ByVal idContacto As Long)
        MyBase.New(id, identidades, estado)
        Me.IdContacto = idContacto


        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idcontacto", Nothing))

        Me.TablaEliminar = "Proveedores"
        Me.TablaBusqueda = "Proveedores"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tabla", TablaBusqueda))
        Me.ComandoMantenimiento = "Proveedores_Mant"

    End Sub
#End Region

#Region "Propiedadaes"

    Public Property IdContacto() As Long
        Get
            Return _IdContacto
        End Get
        Set(ByVal value As Long)
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

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of Proveedores)
        If Me.TotalRegistros > 0 Then
            For x As Integer = 0 To Me.TotalRegistros - 1
                Me.CargadoPropiedades(x)
                Dim tempProveedores As New Proveedores(Me.Id, Me.idEntidades, 1, Me.IdContacto)
                tempProveedores.PersonaJuridica = Me.PersonaJuridica
                tempProveedores.PersonaNatural = Me.PersonaNatural
                lista.Add(tempProveedores)
            Next
        End If
        Return lista
    End Function

#End Region

End Class

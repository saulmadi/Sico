Imports SiCo.lgla

Public Class Clientes
    Inherits Mantenimientos

#Region "Constructor"

    Sub New()
        MyBase.New()

        Me.TablaBusqueda = "Clientes"
        Me.TablaEliminar = "Clientes"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("tabla", TablaBusqueda))
        Me.ComandoMantenimiento = "Clientes_Mant"

    End Sub

    Sub New (ByVal id As Long, ByVal identidades As Long, ByVal estado As Integer)
        MyBase.New (id, identidades, estado)

        Me.TablaBusqueda = "Clientes"
        Me.TablaEliminar = "Clientes"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("tabla", TablaBusqueda))
        Me.ComandoMantenimiento = "Clientes_Mant"

    End Sub

#End Region

#Region "Metodos"

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of Clientes)

        If Me.TotalRegistros > 0 Then
            For x As Integer = 0 To Me.TotalRegistros - 1
                Me.CargadoPropiedades (x)
                Dim tempClientes As New Clientes (Me.Id, Me.idEntidades, 1)
                tempClientes.PersonaJuridica = Me.PersonaJuridica
                tempClientes.PersonaNatural = Me.PersonaNatural
                lista.Add (tempClientes)
            Next
        End If
        Return lista

    End Function

#End Region
End Class

Imports SiCo.lgla

Public Class TarjetaCredito
    Inherits TablasTipo

#Region "Constructor"

    Public Sub New()
        MyBase.New()


        Me.ComandoMantenimiento = "TarjetaCredito_Mant"

        Me.TablaBusqueda = "tarjetacredito"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("tabla", Me.TablaBusqueda))
        Me.TablaEliminar = Me.TablaBusqueda
    End Sub

#End Region

#Region "metodos"

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub

#End Region
End Class

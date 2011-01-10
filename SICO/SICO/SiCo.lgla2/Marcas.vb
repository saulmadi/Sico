Imports SiCo.lgla
Public Class Marcas
    Inherits TablasTipo
#Region "Constructor"
    Public Sub New()
        MyBase.New()


        Me.ComandoMantenimiento = "Marcas_Mant"

        Me.TablaBusqueda = "marcas"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tabla", Me.TablaBusqueda))

    End Sub
#End Region
#Region "metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class

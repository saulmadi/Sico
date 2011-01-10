Imports SiCo.lgla
Public Class Modelos
    Inherits TablasTipoDerivadas

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoMantenimiento = "Modelos_Mant"


        Me.TablaBusqueda = "modelos"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tabla", Me.TablaBusqueda))


    End Sub
#End Region

#Region "Metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class

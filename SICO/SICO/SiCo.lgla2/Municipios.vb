
Public Class Municipios
    Inherits TablasTipoDerivadas

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoMantenimiento = "Municipios_Mant"
        Me.ComandoSelect = "Municipios_Buscar"

    End Sub
#End Region
#Region "Metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class

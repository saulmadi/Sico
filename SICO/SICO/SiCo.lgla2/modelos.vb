
Public Class Modelos
    Inherits TablasTipoDerivadas

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "Modelos_Buscar"
        Me.ComandoMantenimiento = "Modelos_Mant"
    End Sub
#End Region

#Region "Metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class

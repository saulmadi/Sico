
Public Class Marcas
    Inherits TablasTipo
#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "Marcas_Buscar"
        Me.ComandoMantenimiento = "Marcas_Mant"

    End Sub
#End Region
#Region "metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class

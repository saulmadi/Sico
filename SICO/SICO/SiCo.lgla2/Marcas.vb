
Public Class Marcas
    Inherits TablasTipo
#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "Departamentos_Buscar"
        Me.ComandoMantenimiento = "Departamentos_Mant"

    End Sub
#End Region
#Region "metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class

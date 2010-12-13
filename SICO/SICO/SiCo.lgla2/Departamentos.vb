
Public Class Departamentos
    Inherits TablasTipo

#Region "Constructor"

    Sub New()
        MyBase.New()

        Me.ComandoSelect = "Departamentos_Buscar"
        Me.ComandoMantenimiento = "Departamentos_Mant"

    End Sub

#End Region

#Region "Metodos"

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub

#End Region

End Class

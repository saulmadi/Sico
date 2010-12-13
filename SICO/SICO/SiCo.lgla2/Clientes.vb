
Public Class Clientes
    Inherits Mantenimientos
#Region "Constructor"

    Sub New()
        MyBase.New()

        Me.ComandoSelect = "Clientes_Buscar"
        Me.ComandoMantenimiento = "Clientes_Mant"

    End Sub

#End Region
#Region "Metodos"
    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region
    
End Class

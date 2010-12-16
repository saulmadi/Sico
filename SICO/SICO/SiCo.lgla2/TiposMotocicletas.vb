
Public Class TiposMotocicletas
    Inherits TablasTipo

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        Me.ComandoMantenimiento = "TiposMotocicletas_Mant"
        Me.ComandoSelect = "TiposMotocicletas_Buscar"
    End Sub
#End Region

#Region "Metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class
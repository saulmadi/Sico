
Public Class TiposFacturas
    Inherits TablasTipo

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        Me.ComandoMantenimiento = "TiposFactura_Mant"
        Me.ComandoSelect = "TiposFactura_Buscar"
    End Sub
#End Region

#Region "Metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region



End Class

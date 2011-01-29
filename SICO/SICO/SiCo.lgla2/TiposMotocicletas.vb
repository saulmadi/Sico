Imports SiCo.lgla
Public Class TiposMotocicletas
    Inherits TablasTipo

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        Me.ComandoMantenimiento = "Tiposmotocicletas_Mant"

        Me.TablaBusqueda = "tiposmotocicletas"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tabla", Me.TablaBusqueda))
        Me.TablaEliminar = Me.TablaBusqueda
    End Sub
#End Region

#Region "Metodos"
    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        MyBase.Guardar()
    End Sub
#End Region

End Class
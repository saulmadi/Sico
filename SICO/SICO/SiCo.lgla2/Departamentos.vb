
Imports SiCo.lgla
Public Class Departamentos
    Inherits TablasTipo

#Region "Constructor"

    Sub New()
        MyBase.New()

        Me.ComandoMantenimiento = "Departamentos_Mant"
        Me.TablaBusqueda = "departamentos"
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

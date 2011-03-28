Imports SiCo.lgla
Public Class InventarioTrigger
    Inherits entidad

#Region "Constructor"
    Public Sub New()
        Me.ComandoMantenimiento = "Inventarios_Triggers"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idproductos"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("cantidad"))
    End Sub
    Public Sub ModificarInventario(ByVal idSucursal As Long, ByVal idproducto As Long, ByVal cantidad As Long)
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idsucursales", idSucursal)
        Me.ValorParametrosMantenimiento("idproductos", idproducto)
        Me.ValorParametrosMantenimiento("cantidad", cantidad)
        MyBase.Guardar(True)
    End Sub
#End Region

End Class

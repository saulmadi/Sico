Imports SiCo.lgla
Public Class GenerarNumeroFactura
    Inherits Entidad
    Public Sub New()
        Me.ComandoMantenimiento = "GenerarNumeroFactura"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idfactura"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursal"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("estado"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("numerofactura"))
    End Sub
    Public Sub GenerarNumero(ByVal idfactura As Long, ByVal idsucursal As Long, ByVal estado As String)
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idfactura", idfactura.ToString)
        Me.ValorParametrosMantenimiento("idsucursal", idsucursal.ToString)
        Me.ValorParametrosMantenimiento("estado", estado)
        Me.ValorParametrosMantenimiento("numerofactura", 0)
        MyBase.Guardar(True)
    End Sub
    Public Sub GenerarNumeroDiferido(ByVal idfactura As Long, ByVal idsucursal As Long, ByVal numerofactura As Long)
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idfactura", idfactura.ToString)
        Me.ValorParametrosMantenimiento("idsucursal", idsucursal.ToString)
        Me.ValorParametrosMantenimiento("estado", "")
        Me.ValorParametrosMantenimiento("numerofactura", numerofactura)
        MyBase.Guardar(True)
    End Sub
End Class

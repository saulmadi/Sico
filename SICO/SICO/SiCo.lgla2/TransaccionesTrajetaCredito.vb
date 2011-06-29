Imports SiCo.lgla
Public Class TransaccionesTrajetaCredito
    Inherits SiCo.lgla.Entidad
#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoMantenimiento = "TransaccionesTarjetaCredito_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idfacturaencabezado"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("numerotarjeta"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("codigoaprobacion"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("vencimiento"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idtarjetacredito"))

    End Sub
#End Region
End Class

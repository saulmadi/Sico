Imports SiCo.lgla
Public Class ControlCajaFactura
    Inherits Entidad

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoMantenimiento = "ControlCajaFactura_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idfacturaencabezado"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idcontrolcaja"))

    End Sub
#End Region

#Region "Metodos"
    Public Overloads Sub Guardar(ByVal idfacturaencabezado As Long, ByVal idcontrolcaja As Long)
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idfacturaencabezado", idfacturaencabezado)
        Me.ValorParametrosMantenimiento("idcontrolcaja", idcontrolcaja)
        MyBase.Guardar(True)
    End Sub
#End Region

End Class

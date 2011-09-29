Imports SiCo.lgla
Public Class AgregarCuentaPropietario
    Inherits Entidad
#Region "Construtor"
    Public Sub New()
        MyBase.New()
        Me.ComandoMantenimiento = "AgregarCuentaPropietario"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("identidad"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("monto"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idtipomonto"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fechavencimiento"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("descripcion"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idrubro"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursal"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idcuentacorriente", 0, ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("codigoCuentaCorriente", "", ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idmovimento", 0, ParameterDirection.InputOutput))


    End Sub
    Public Overloads Sub Guardar(ByVal identidad As Long, ByVal idtipomonto As Integer, ByVal fechavencimiento As Date, ByVal monto As Decimal, ByVal descripcion As String, ByVal idrubro As Integer, ByVal idsucursal As Integer)
        Me.ValorParametrosMantenimiento("identidad", identidad)
        Me.ValorParametrosMantenimiento("monto", monto)
        Me.ValorParametrosMantenimiento("descripcion", descripcion)
        Me.ValorParametrosMantenimiento("idrubro", idrubro)
        Me.ValorParametrosMantenimiento("idsucursal", idsucursal)
        Me.ValorParametrosMantenimiento("fechavencimiento", fechavencimiento)
        Me.ValorParametrosMantenimiento("idtipomonto", idtipomonto)

        MyBase.Guardar(True)
        If Me.ValorParametrosMantenimiento("idcuentacorriente") = 0 Then
            Throw New ApplicationException("Error al generar la cuenta corriente")
        End If
        If Me.ValorParametrosMantenimiento("idmovimento") = 0 Then
            Throw New ApplicationException("Error al generar el movimiento de la cuenta corriente")
        End If


    End Sub
#End Region
    



End Class

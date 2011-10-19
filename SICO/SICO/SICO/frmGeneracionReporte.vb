Public Class frmGeneracionReporte
    Private Sub frmGeneracionReporte_FormClosing (ByVal sender As Object, ByVal e As FormClosingEventArgs) _
        Handles MyBase.FormClosing
        barraprogreso.Value = 100
    End Sub
End Class
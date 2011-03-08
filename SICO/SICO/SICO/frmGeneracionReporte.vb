Public Class frmGeneracionReporte

    Private Sub frmGeneracionReporte_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        barraprogreso.Value = 100
    End Sub
End Class
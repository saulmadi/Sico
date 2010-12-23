Public Class crtListadoMantenimiento

#Region "Eventos"
    Private Sub txtBusqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBusqueda.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
        End If
    End Sub
    
#End Region

   
    
    
End Class

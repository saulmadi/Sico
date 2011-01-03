Public Class frmBusquedaFactura
    Dim WithEvents frm As New frmFacturacion
   
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 3 Then
            Me.Hide()
            frm = New frmFacturacion
            frm.MdiParent = Me.MdiParent
            frm.Show()

        End If
    End Sub

    
    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub
End Class
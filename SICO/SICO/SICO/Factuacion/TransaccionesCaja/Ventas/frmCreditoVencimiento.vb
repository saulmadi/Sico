Imports SiCo.ctrla.ControlesBasicos

Public Class frmCreditoVencimiento
    Private Sub frmCreditoVencimiento_Load (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        Me.PanelAccion1.BotonNuevo.Visible = False
        Me.PanelAccion1.BotonImprimir.Visible = False

        Me.PanelAccion1.BotonEliminar.Visible = False
        dteFechaVencimiento.MinDate = Now
        dteFechaVencimiento.Value = Now.AddMonths (1)
        Me.PanelAccion1.BotonGuardar.Text = "Aceptar"
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar

        If Mensaje.SioNo ("¿Esta seguro del plazo de pago de la deuda?") = DialogResult.Yes Then
            Me.Close()
            Me.DialogResult = DialogResult.OK
        End If
    End Sub
End Class
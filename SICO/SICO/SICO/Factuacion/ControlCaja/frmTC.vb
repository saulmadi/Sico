Imports SICO.lgla
Imports SICO.lgla2
Public Class frmTC
    Private _controlCaja As New ControlCaja

    Private Sub frmAperturaCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar

    End Sub
End Class
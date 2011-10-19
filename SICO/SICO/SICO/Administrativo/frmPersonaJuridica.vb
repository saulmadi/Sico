Imports SiCo.lgla

Public Class frmPersonaJuridica
    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            PanelAccion1.lblEstado.Text = "Guardando..."

            If CrtPersonaJuridica1.Guardar() > 0 Then
                CrtPersonaJuridica1.Nuevo()
                PanelAccion1.lblEstado.Text = "Persona jurídica guardada correctamente"
            End If

        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.lblEstado.Text = "Error al guardar la persona jurídica"
        End Try
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        CrtPersonaJuridica1.Nuevo()
    End Sub

    Private Sub CrtListadoMantenimiento1_Limpio() Handles CrtListadoMantenimiento1.Limpio
        CrtPersonaJuridica1.Persona = New PersonaJuridica
    End Sub

    Private Sub CrtListadoMantenimiento1_SeleccionItem (ByVal Item As Object) _
        Handles CrtListadoMantenimiento1.SeleccionItem
        CrtPersonaJuridica1.Persona = Item
    End Sub

    Private Sub frmPersonaJuridica_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CrtListadoMantenimiento1.Entidad = New PersonaJuridica
        CrtListadoMantenimiento1.lblDescripcion.Text = "Razón Social"
        CrtPersonaJuridica1.EtiquetaError = PanelAccion1.lblEstado
        PanelAccion1.BotonEliminar.Enabled = False
        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonImprimir.Visible = False
        PanelAccion1.BotonImprimir.Enabled = False
    End Sub
End Class
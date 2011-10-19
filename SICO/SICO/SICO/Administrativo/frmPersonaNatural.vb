Imports SiCo.lgla

Public Class frmPersonaNatural
    Private Sub frmPersonaNatural_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        crtBusqueda.Entidad = New PersonaNatural
        crtBusqueda.lblDescripcion.Text = "Nombre"
        CrtPersonaNatural.EtiquetaError = PanelAccion1.lblEstado
        PanelAccion1.BotonEliminar.Enabled = False
        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonImprimir.Visible = False
        PanelAccion1.BotonImprimir.Enabled = False

    End Sub

    Private Sub crtBusqueda_SeleccionItem (ByVal Item As Object) Handles crtBusqueda.SeleccionItem
        CrtPersonaNatural.Persona = Item
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            PanelAccion1.lblEstado.Text = "Guardando..."

            If CrtPersonaNatural.Guardar() > 0 Then
                CrtPersonaNatural.Nuevo()
                PanelAccion1.lblEstado.Text = "Persona natural guardada correctamente"
            End If

        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.lblEstado.Text = "Error al guardar la persona natural"
        End Try
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        CrtPersonaNatural.Nuevo()
    End Sub

    Private Sub crtBusqueda_Limpio() Handles crtBusqueda.Limpio
        If CrtPersonaNatural.Persona.Id > 0 Then
            CrtPersonaNatural.Persona = New PersonaNatural
        End If

    End Sub
End Class
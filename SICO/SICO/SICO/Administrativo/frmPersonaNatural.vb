Public Class frmPersonaNatural

    Private Sub frmPersonaNatural_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        crtBusqueda.Entidad = New SICO.lgla.PersonaNatural
        crtBusqueda.lblDescripcion.Text = "Nombre"
        CrtPersonaNatural.EtiquetaError = PanelAccion1.lblEstado
        PanelAccion1.BotonEliminar.Enabled = False
        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonImprimir.Visible = False
        PanelAccion1.BotonImprimir.Enabled = False

    End Sub
   
    Private Sub crtBusqueda_SeleccionItem(ByVal Item As System.Object) Handles crtBusqueda.SeleccionItem
        CrtPersonaNatural.Persona = Item
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            PanelAccion1.lblEstado.Text = "Guardando..."
            CrtPersonaNatural.Guardar()
            PanelAccion1.lblEstado.Text = "Persona natural guardada correctamente"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.lblEstado.Text = "Error al guardar persona natural"
        End Try
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        CrtPersonaNatural.Nuevo()
    End Sub

    Private Sub crtBusqueda_Limpio() Handles crtBusqueda.Limpio
        If CrtPersonaNatural.Persona.Id > 0 Then
            CrtPersonaNatural.Persona = New SICO.lgla.PersonaNatural
        End If

    End Sub

   
End Class
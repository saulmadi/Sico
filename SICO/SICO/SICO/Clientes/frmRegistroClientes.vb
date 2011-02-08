Imports SICO.lgla2
Imports SICO.lgla
Public Class frmRegistroClientes
    Public Property Cliente() As Clientes
        Get
            Return CrtClientes1.Cliente
        End Get
        Set(ByVal value As Clientes)
            CrtClientes1.Cliente = value
        End Set
    End Property

    Private Sub frmRegistroClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrtListadoMantenimiento1.Entidad = New Clientes
        CrtListadoMantenimiento1.lblDescripcion.Text = "Cliente"
        CrtClientes1.ControlPersonaNatural.EtiquetaError = PanelAccion1.lblEstado
        CrtClientes1.ControlPersonaJuridicas.EtiquetaError = PanelAccion1.lblEstado
    End Sub

   
    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            PanelAccion1.lblEstado.Text = "Guardando..."
            PanelAccion1.BarraProgreso.Value = 50
            CrtClientes1.Guardar()

        Catch ex As Exception
            PanelAccion1.lblEstado.Text = "Error al guardar el cliente"
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.BarraProgreso.Value = 0
        End Try

    End Sub
End Class
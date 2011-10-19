Imports SiCo.lgla2

Public Class frmRegistroClientes
    Public Property Cliente() As Clientes
        Get
            Return CrtClientes1.Cliente
        End Get
        Set (ByVal value As Clientes)
            CrtClientes1.Cliente = value
        End Set
    End Property

    Private Sub frmRegistroClientes_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CrtListadoMantenimiento1.Entidad = New Clientes
        CrtListadoMantenimiento1.lblDescripcion.Text = "Cliente"
        CrtClientes1.ControlPersonaNatural.EtiquetaError = PanelAccion1.lblEstado
        CrtClientes1.ControlPersonaJuridicas.EtiquetaError = PanelAccion1.lblEstado

        PanelAccion1.BotonImprimir.Visible = False
        PanelAccion1.BotonEliminar.Visible = False
    End Sub


    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            PanelAccion1.lblEstado.Text = "Guardando..."
            PanelAccion1.BarraProgreso.Value = 50
            CrtClientes1.Guardar()
            PanelAccion1.lblEstado.Text = "Cliente guardado correctamente."
            PanelAccion1.BarraProgreso.Value = 100


        Catch ex As Exception
            PanelAccion1.lblEstado.Text = "Error al guardar el cliente"
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.BarraProgreso.Value = 0
        End Try

    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        CrtClientes1.Nuevo()
        PanelAccion1.lblEstado.Text = ""
        PanelAccion1.BarraProgreso.Value = 0
    End Sub

    Private Sub PanelAccion1_Load (ByVal sender As Object, ByVal e As EventArgs) Handles PanelAccion1.Load

    End Sub

    Private Sub CrtListadoMantenimiento1_Limpio() Handles CrtListadoMantenimiento1.Limpio
        Me.Cliente = New Clientes

    End Sub

    Private Sub CrtListadoMantenimiento1_SeleccionItem (ByVal Item As Object) _
        Handles CrtListadoMantenimiento1.SeleccionItem
        Me.Cliente = Item
    End Sub
End Class
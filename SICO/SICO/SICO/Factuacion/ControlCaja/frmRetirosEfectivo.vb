Imports SICO.lgla2
Public Class frmRetirosEfectivo
    Private _controlCaja As New ControlCaja
    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim f As New frmIniciosesion
            f.Autorizar = True
            f.ShowDialog()
            If f.Autorizo Then
                If MessageBox.Show("¿Esta seguro de retirar este efectivo", "Advertencia", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    If txtEfectivo.Text <> String.Empty Then
                        If _controlCaja.AperturaCaja(PanelAccion1.Usuario.Id, dteFecha.Value, "") Then
                            _controlCaja = New ControlCaja
                            _controlCaja.RealizarRetiroEfectivo(Me.PanelAccion1.Usuario.Id, txtEfectivo.Text, dteFecha.Value, PanelAccion1.sucursal.Id, Me.PanelAccion1.Usuario)
                            MessageBox.Show("Se retiro correctamente el efectivo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtEfectivo.Enabled = False
                            PanelAccion1.BotonGuardar.Enabled = False
                            Me.Close()
                        End If

                    Else
                        Throw New ApplicationException("Ingrese el monto de efectivo")
                    End If
                End If
            Else
                Throw New ApplicationException("No ser realizo el retiro de efectivo")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmRetirosEfectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PanelAccion1.BotonEliminar.Visible = False
            PanelAccion1.BotonImprimir.Visible = False
            PanelAccion1.BotonNuevo.Visible = False
            PanelAccion1.BotonGuardar.Enabled = True
            txtCajero.Text = PanelAccion1.Usuario.NombreUsuario
            txtEfectivo.Enabled = True
            If Not _controlCaja.AperturaCaja(PanelAccion1.Usuario.Id, dteFecha.Value, "") Then
                MessageBox.Show("Este usuario no ha realizado la apertura de la caja", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PanelAccion1.BotonGuardar.Enabled = False
                txtEfectivo.Enabled = False
            End If
            Dim c As New ControlCaja
            c.Buscar(5, PanelAccion1.Usuario.Id, Now, PanelAccion1.sucursal.Id)
            If c.TotalRegistros > 0 Then
                MessageBox.Show("Este usuario ya realizo el cierre de caja", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtEfectivo.Enabled = False
                PanelAccion1.BotonGuardar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
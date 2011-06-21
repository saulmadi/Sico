Imports SICO.lgla
Imports SICO.lgla2
Public Class frmAperturaCaja
    Private _controlCaja As New ControlCaja
    Private Sub frmAperturaCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PanelAccion1.BotonEliminar.Visible = False
            PanelAccion1.BotonImprimir.Visible = False
            PanelAccion1.BotonNuevo.Visible = False
            PanelAccion1.BotonGuardar.Enabled = True
            txtCajero.Text = PanelAccion1.Usuario.NombreUsuario
            If _controlCaja.AperturaCaja(PanelAccion1.Usuario.Id, dteFecha.Value, "") Then
                txtEfectivo.Text = _controlCaja.Monto
                dteFecha.Value = _controlCaja.Fecha
                PanelAccion1.BotonGuardar.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim f As New frmIniciosesion
            f.Autorizar = True
            f.ShowDialog()
            If f.Autorizo Then
                If MessageBox.Show("¿Esta seguro de abrir la caja?", "Advertencia", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

                    If txtEfectivo.Text <> String.Empty Then
                        If Not _controlCaja.AperturaCaja(PanelAccion1.Usuario.Id, dteFecha.Value, "") Then
                            _controlCaja = New ControlCaja
                            _controlCaja.RealizarApertura(Me.PanelAccion1.Usuario.Id, txtEfectivo.Text, dteFecha.Value, PanelAccion1.sucursal.Id, Me.PanelAccion1.Usuario)
                            MessageBox.Show("Se aperturó correctamente la caja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Close()
                        End If

                    Else
                        Throw New ApplicationException("Ingrese el monto de apertura")
                    End If
                End If
            Else
                Throw New ApplicationException("No ser realizo la apertura")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
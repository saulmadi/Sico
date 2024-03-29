﻿Imports SiCo.ctrla.ControlesBasicos
Imports SiCo.ctrla
Imports SiCo.lgla2

Public Class frmRetirosEfectivo
    Private _controlCaja As New ControlCaja

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim valida As New Validador
            valida.ColecionCajasTexto.Add (txtDescripcion)
            If valida.PermitirIngresar Then
                Dim f As New frmIniciosesion
                f.Autorizar = True
                f.ShowDialog()
                If f.Autorizo Then
                    If _
                        MessageBox.Show ("¿Esta seguro de retirar este efectivo", "Advertencia", MessageBoxButtons.YesNo) = _
                        DialogResult.Yes Then

                        If txtEfectivo.Text <> String.Empty Then
                            If _controlCaja.AperturaCaja (PanelAccion1.Usuario.Id, dteFecha.Value, "") Then
                                _controlCaja = New ControlCaja
                                _controlCaja.RealizarRetiroEfectivo (Me.PanelAccion1.Usuario.Id, txtEfectivo.Text, _
                                                                     dteFecha.Value, PanelAccion1.sucursal.Id, _
                                                                     Me.PanelAccion1.Usuario, txtDescripcion.Text)
                                MessageBox.Show ("Se retiro correctamente el efectivo", "Información", _
                                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtEfectivo.Enabled = False
                                PanelAccion1.BotonGuardar.Enabled = False
                                Me.Close()
                            End If

                        Else
                            Throw New ApplicationException ("Ingrese el monto de efectivo")
                        End If
                    End If
                Else
                    Throw New ApplicationException ("No ser realizo el retiro de efectivo")
                End If
            Else
                Mensaje.MensajeError (valida.MensajesError)
            End If

        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmRetirosEfectivo_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            PanelAccion1.BotonEliminar.Visible = False
            PanelAccion1.BotonImprimir.Visible = False
            PanelAccion1.BotonNuevo.Visible = False
            PanelAccion1.BotonGuardar.Enabled = True
            txtCajero.Text = PanelAccion1.Usuario.NombreUsuario
            txtEfectivo.Enabled = True
            If Not _controlCaja.AperturaCaja (PanelAccion1.Usuario.Id, dteFecha.Value, "") Then
                MessageBox.Show ("Este usuario no ha realizado la apertura de la caja", "Informacion", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Information)
                PanelAccion1.BotonGuardar.Enabled = False
                txtEfectivo.Enabled = False
            End If
            Dim c As New ControlCaja
            c.Buscar (5, PanelAccion1.Usuario.Id, Now, PanelAccion1.sucursal.Id)
            If c.TotalRegistros > 0 Then
                MessageBox.Show ("Este usuario ya realizo el cierre de caja", "Informacion", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Information)
                txtEfectivo.Enabled = False
                PanelAccion1.BotonGuardar.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
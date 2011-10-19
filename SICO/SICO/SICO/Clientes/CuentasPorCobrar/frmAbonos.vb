Imports SiCo.ctrla
Imports SiCo.ctrla.ControlesBasicos
Imports SiCo.lgla2

Public Class frmAbonos
    Public rubro As Integer = 1

    Private Sub frmAbonos_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.PanelAccion1.BotonEliminar.Visible = False
        Me.PanelAccion1.BotonImprimir.Visible = False
        Me.PanelAccion1.BotonNuevo.Visible = False

        Me.PanelAccion1.BotonGuardar.Text = "Abonar"
        Me.PanelAccion1.BotonGuardar.Enabled = False

    End Sub

    Private Sub habilitarTxt (ByVal valor As Boolean)
        txtAbono.Enabled = valor
        PanelAccion1.BotonGuardar.Enabled = valor
    End Sub

    Private Sub Button1_Click (ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Dim cliente = CrtClientes1.Guardar()
            If cliente > 0 Then
                Dim cuenta = New Cuentacorriente()
                Dim saldo = cuenta.CalcularSaldo (rubro, CrtClientes1.Cliente.idEntidades)
                If saldo > 0 Then
                    habilitarTxt (True)
                    txtSaldo.Text = saldo
                    txtAbono.Text = "0.00"
                Else
                    habilitarTxt (False)
                    Mensaje.Informacion ("Este cliente no tiene un saldo pendiente")
                End If
            Else
                habilitarTxt (False)
            End If
        Catch ex As Exception
            Mensaje.MensajeError (ex.Message)
        End Try
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim valida As New Validador
            valida.ColecionCajasTexto.Add (txtAbono)
            If valida.PermitirIngresar And txtAbono.ValorDecimal > 0 Then                


                Dim formco As New frmCobro
                Dim cuenta = New Cuentacorriente
                formco.Total = txtAbono.Text
                cuenta.IniciarTransaccion()
                formco.Total = txtAbono.ValorDecimal
                If formco.ShowDialog = DialogResult.OK Then

                    For Each i In formco.ControlCaja
                        i.Cajero = PanelAccion1.Usuario.Id
                        i.idSucursales = PanelAccion1.sucursal.Id
                        i.Descripcion = "Abono a cuenta  a cliente " + CrtClientes1.Cliente.NombreMantenimiento

                        If i.idTransaccionesCaja = 2 Then
                            i.idTransaccionesCaja = 11
                            i.Guardar()
                        End If

                        If i.idTransaccionesCaja = 3 Then
                            i.idTransaccionesCaja = 12
                            i.Guardar()
                            formco.TransaccionTC.idControlCaja = i.Id
                            formco.TransaccionTC.idFacturaEnbezado = 0
                            formco.TransaccionTC.Guardar()

                        End If

                    Next
                    If rubro = 1 Then _
                        cuenta.AgragrarCreditoMovimientoProductos (CrtClientes1.Cliente.idEntidades, txtAbono.Text, _
                                                                   "Abono a cuenta  a cliente " + _
                                                                   CrtClientes1.Cliente.NombreMantenimiento, Now, _
                                                                   PanelAccion1.sucursal.Id)
                    If rubro = 2 Then _
                        cuenta.AgragrarDebitoMovimientoMotocicletas (CrtClientes1.Cliente.idEntidades, txtAbono.Text, _
                                                                     "Abono a cuenta  a cliente " + _
                                                                     CrtClientes1.Cliente.NombreMantenimiento, Now, _
                                                                     PanelAccion1.sucursal.Id)
                    cuenta.CommitTransaccion()
                    Mensaje.Informacion ("El abono se hizo correctamente")
                    habilitarTxt (False)

                Else
                    Mensaje.Informacion ("Canceló el cobro del abono")
                End If

            Else
                Mensaje.MensajeError (valida.MensajesError)
            End If

        Catch ex As Exception
            Mensaje.MensajeError (ex.Message)
        End Try
    End Sub
End Class
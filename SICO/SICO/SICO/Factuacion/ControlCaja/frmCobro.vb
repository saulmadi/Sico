Imports SICO.lgla
Imports SICO.lgla2
Public Class frmCobro
    Private _controlCaja As New List(Of ControlCaja)
    Private _transacionTC As New TransaccionesTrajetaCredito
    Public Total As Decimal
    Public Property TransaccionTC() As TransaccionesTrajetaCredito
        Get
            Return _transacionTC
        End Get
        Set(ByVal value As TransaccionesTrajetaCredito)
            _transacionTC = value
        End Set
    End Property
    Public Property ControlCaja() As List(Of ControlCaja)
        Get
            Return _controlCaja
        End Get
        Set(ByVal value As List(Of ControlCaja))
            _controlCaja = value
        End Set
    End Property

    Private Sub frmAperturaCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ''Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.PanelAccion1.BotonEliminar.Visible = False
            Me.PanelAccion1.BotonImprimir.Visible = False
            Me.PanelAccion1.BotonNuevo.Visible = False
            txtTotal.Text = Total
            txtBalance.Text = Total

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try

        
            _controlCaja.Clear()
            If txtBalance.Text = 0 Then
                If txtEfectivo.Text <> String.Empty Then
                    Dim control = New ControlCaja
                    With control
                        .idTransaccionesCaja = 2
                        .Monto = txtEfectivo.Text
                        .Descripcion = "Pago en efectivo en factura"
                    End With
                    ControlCaja.Add(control)
                End If

                If txtTC.Text <> String.Empty Then
                    Dim control = New ControlCaja
                    With control
                        .idTransaccionesCaja = 3
                        .Monto = txtTC.Text
                        .Descripcion = "Pago con tarjeta de crédito en factura"
                    End With
                    Dim forma As New frmTC
                    forma.total = txtTC.Text
                    If forma.ShowDialog = Windows.Forms.DialogResult.OK Then

                        ControlCaja.Add(control)
                        Me.TransaccionTC = forma.TransaccionTarjetaCredito

                    Else
                        Throw New ApplicationException("La transacción de tarjeta de crédito no se realizo")
                    End If
                End If
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MessageBox.Show("Revise los montos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEfectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEfectivo.TextChanged, txtTC.TextChanged
        txtBalance.Text = Total - txtEfectivo.ValorDecimal - txtTC.ValorDecimal
    End Sub
End Class
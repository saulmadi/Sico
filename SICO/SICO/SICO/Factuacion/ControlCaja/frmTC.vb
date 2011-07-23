Imports SICO.lgla
Imports SICO.lgla2
Imports SICO.ctrla2
Imports SICO.ctrla
Public Class frmTC
    Private _TransaccionTarjetaCredito As New TransaccionesTrajetaCredito

    Public total As Decimal

    Public Property TransaccionTarjetaCredito() As TransaccionesTrajetaCredito
        Get
            Return _TransaccionTarjetaCredito
        End Get
        Set(ByVal value As TransaccionesTrajetaCredito)
            _TransaccionTarjetaCredito = value
        End Set
    End Property

    Private Sub frmAperturaCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            Me.PanelAccion1.BotonEliminar.Visible = False
            Me.PanelAccion1.BotonImprimir.Visible = False
            Me.PanelAccion1.BotonNuevo.Visible = False

            cmbTarjetaCredito.Entidad = New TarjetaCredito
            txtMonto.Text = total

            cmbTarjetaCredito.DisplayMember = "descripcion"
            cmbTarjetaCredito.ValueMember = "id"
            cmbTarjetaCredito.ColeccionParametros.Add(New ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
            cmbTarjetaCredito.CargarParametros()


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar

        If cmbTarjetaCredito.SelectedIndex <> -1 Then
            Dim valida = New Validador
            valida.ColecionCajasTexto.Add(txtNumeroTarjeta)
            valida.ColecionCajasTexto.Add(txtExpira)
            valida.ColecionCajasTexto.Add(txtExpira)
            If valida.PermitirIngresar Then
                Me.TransaccionTarjetaCredito.idTarjetaCredito = cmbTarjetaCredito.SelectedValue
                Me.TransaccionTarjetaCredito.numeroTarjeta = txtNumeroTarjeta.Text
                Me.TransaccionTarjetaCredito.CodigoAprobacion = txtAprobacion.Text
                Me.TransaccionTarjetaCredito.Vencimiento = txtExpira.Text
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show(valida.MensajesError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("Selecione una tarjeta de crédito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub
End Class
Imports SiCo.ctrla2
Imports SiCo.ctrla
Imports SiCo.lgla2

Public Class frmVentaMotocicleta

#Region "Declaraciones"

    Private WithEvents _factura As New FacturaEncabezado

#End Region

#Region "Propiedades"

    Public Property Factura() As FacturaEncabezado
        Get
            Return _factura
        End Get
        Set (ByVal value As FacturaEncabezado)
            _factura = value
            cargarentidad()
        End Set
    End Property

#End Region

#Region "Metodos"

    Private Sub cargarentidad()
        If cmbTiposFacturas.Items.Count = 0 Then
            cmbTiposFacturas.Entidad = New TiposFacturas
            cmbTiposFacturas.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("habilitado", "1"))
            cmbTiposFacturas.IncializarCarga()

        End If
        CrtClientes.Enabled = True

        Me.PanelAccion1.BotonEliminar.Visible = False
        lblNumeroFactura.Text = ""
        If Factura.Id = 0 Then
            CrtClientes.Nuevo()

            cmbTiposFacturas.SelectedIndex = - 1
            chkVentaExcenta.Checked = False
            chkVentaExcenta.Enabled = True
            cmbTiposFacturas.Enabled = True
            CrtClientes.Enabled = True

            PanelAccion1.BotonGuardar.Enabled = True
            Factura.ListaDetalle = New List(Of FacturaDetalle)
            txtDescuentoPor.Enabled = True

            Factura.Motocicleta = New Motocicletas
        Else
            Me.txtDescuento.Text = Factura.descuento

            lblNumeroFactura.Text = Factura.NumeroFacturaS
            Dim cliente As New Clientes
            cliente.Buscar ("id", Factura.idclientes)
            If cliente.Id > 0 Then
                CrtClientes.Cliente = cliente
            Else
                CrtClientes.Nuevo()
            End If

            cmbTiposFacturas.SelectedValue = Factura.idtiposfacturas
            chkVentaExcenta.Checked = Factura.ventaexcenta
            Dim m = New Motocicletas
            m.Buscar ("id", Factura.idMotocicletas)
            Factura.Motocicleta = m
            txtPrecioVenta.Enabled = True
            If Factura.estado.ToUpper = "P" Then
                Me.PanelAccion1.BotonEliminar.Text = "Facturar"
                Me.PanelAccion1.BotonEliminar.Visible = True

                txtDescuentoPor.Enabled = True
                chkVentaExcenta.Enabled = True
                cmbTiposFacturas.Enabled = True
                CrtClientes.Enabled = True
                Me.PanelAccion1.BotonGuardar.Enabled = True

            ElseIf Factura.estado.ToUpper = "F" Then
                Me.PanelAccion1.BotonEliminar.Text = "Anular"
                Me.PanelAccion1.BotonEliminar.Visible = True

                txtDescuentoPor.Enabled = False
                chkVentaExcenta.Enabled = False
                cmbTiposFacturas.Enabled = False
                CrtClientes.Enabled = True
                Me.PanelAccion1.BotonGuardar.Enabled = False
                btnBuscar.Enabled = False
                txtPrecioVenta.Enabled = False

            ElseIf Factura.estado.ToUpper = "A" Then
                Me.PanelAccion1.BotonEliminar.Text = "Anular"
                Me.PanelAccion1.BotonEliminar.Visible = False

                txtDescuentoPor.Enabled = False
                chkVentaExcenta.Enabled = False
                cmbTiposFacturas.Enabled = False
                CrtClientes.Enabled = False
                Me.PanelAccion1.BotonGuardar.Enabled = False
                btnBuscar.Enabled = False
                txtPrecioVenta.Enabled = False
            Else

                Me.PanelAccion1.BotonEliminar.Visible = False
                txtDescuentoPor.Enabled = False
                chkVentaExcenta.Enabled = False
                cmbTiposFacturas.Enabled = False
                CrtClientes.Enabled = True
                Me.PanelAccion1.BotonGuardar.Enabled = False
            End If

            calculartotales()

        End If
    End Sub

    Private Sub calculartotales()
        Factura.CalcularValoreMotocicleta()
        txtSubtotal.Text = Factura.subtotal.ToString ("#######0.00")
        txtDescuento.Text = Factura.descuentovalor.ToString ("#########0.00")
        txtImpuesto.Text = Factura.isv.ToString ("########0.00")
        txtTotal.Text = Factura.total.ToString ("########0.00")
    End Sub

#End Region

#Region "Eventos"

    Private Sub Button1_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        Dim frm As New frmBusquedaMotocileta
        If frm.ShowDialog() = DialogResult.OK Then
            Factura.Motocicleta = frm.Entidad
            txtPrecioVenta.Enabled = True
        End If

    End Sub

    Private Sub frmVentaMotocicleta_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.cmbMarca.Entidad = New Marcas
        Me.cmbModelo.Entidad = New Modelos
        Me.cmbTipoMotocicleta.Entidad = New TiposMotocicletas

        Me.cmbMarca.IncializarCarga()
        Me.cmbModelo.IncializarCarga()
        Me.cmbTipoMotocicleta.IncializarCarga()

        Me.PanelAccion1.BotonGuardar.Enabled = False
        Me.PanelAccion1.BotonImprimir.Visible = False
        Me.PanelAccion1.BotonEliminar.Visible = False


    End Sub

    Private Sub _factura_CambioMotocicleta() Handles _factura.CambioMotocicleta
        If Factura.Motocicleta.Id > 0 Then
            txtMotor.Text = Factura.Motocicleta.Motor
            txtChasis.Text = Factura.Motocicleta.Chasis
            txtCilindraje.Text = Factura.Motocicleta.cilindraje
            txtAnio.Text = Factura.Motocicleta.anio
            cmbMarca.SelectedValue = Factura.Motocicleta.idmarcas
            cmbModelo.SelectedValue = Factura.Motocicleta.idmodelos
            cmbTipoMotocicleta.SelectedValue = Factura.Motocicleta.idTiposMotocicletas
            txtPrecioVenta.Text = Factura.Motocicleta.precioventa
            txtPrecioVenta.Enabled = True
        Else
            txtPrecioVenta.Enabled = False
            txtMotor.Clear()
            txtChasis.Clear()
            txtCilindraje.Clear()
            txtAnio.Clear()
            cmbMarca.SelectedIndex = - 1
            cmbModelo.SelectedIndex = - 1
            cmbTipoMotocicleta.SelectedIndex = - 1
            txtPrecioVenta.Text = "0.00"
        End If
    End Sub

    Private Sub chkVentaExcenta_CheckedChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles chkVentaExcenta.CheckedChanged
        If chkVentaExcenta.Checked Then
            Factura.ventaexcenta = 1
        Else
            Factura.ventaexcenta = 0
        End If
        calculartotales()
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Guardar
        Try
            Me.PanelAccion1.BarraProgreso.Value = 50
            Me.PanelAccion1.lblEstado.Text = "Guardando..."
            If cmbTiposFacturas.SelectedIndex > - 1 Then
                If Factura.Motocicleta.Id > 0 Then


                    Factura.idclientes = CrtClientes.Guardar()
                    If Factura.idclientes = 0 Then
                        CrtClientes.Nuevo()
                        Throw New ApplicationException ("Ingrese un cliente")
                    End If
                    Factura.fecha = DateTimePicker1.Value
                    Factura.estado = "P"
                    Factura.idMotocicletas = Factura.Motocicleta.Id
                    Factura.Elabora = PanelAccion1.Usuario.Id
                    Factura.idsucursales = PanelAccion1.sucursal.Id
                    Factura.idtiposfacturas = cmbTiposFacturas.SelectedValue
                    Factura.numerofactura = Guid.NewGuid.ToString
                    Factura.motoproducto = "M"
                    Factura.GuardarFacturaMotocicleta()
                    Factura.Id = _factura.Id
                    Factura = _factura
                    Me.PanelAccion1.BarraProgreso.Value = 100
                    Me.PanelAccion1.lblEstado.Text = "Factura guardada correctamente"
                Else
                    MessageBox.Show ("Selecione una motocicleta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show ("Selecione un tipo de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Eliminar
        Try
            Dim ct As New ControlCaja
            ct.Buscar (4, Me.PanelAccion1.Usuario.Id, Now, Me.PanelAccion1.sucursal.Id)
            If ct.TotalRegistros <> 0 Then

                ct.Buscar (5, Me.PanelAccion1.Usuario.Id, Now, PanelAccion1.sucursal.Id)
                If ct.TotalRegistros = 0 Then
                    If Factura.estado.ToUpper = "P" Then


                        Me.PanelAccion1.BarraProgreso.Value = 50
                        Me.PanelAccion1.lblEstado.Text = "Guardando..."
                        If cmbTiposFacturas.SelectedIndex > - 1 Then

                            If Factura.Motocicleta.Id > 0 Then


                                Factura.idclientes = CrtClientes.Guardar()


                                If Factura.idclientes = 0 Then
                                    CrtClientes.Nuevo()
                                    Throw New ApplicationException ("Ingrese un cliente")
                                End If
                                Factura.fecha = DateTimePicker1.Value
                                Factura.estado = "P"
                                Factura.idMotocicletas = Factura.Motocicleta.Id
                                Factura.Elabora = PanelAccion1.Usuario.Id
                                Factura.idsucursales = PanelAccion1.sucursal.Id
                                Factura.idtiposfacturas = cmbTiposFacturas.SelectedValue
                                Factura.numerofactura = Guid.NewGuid.ToString
                                Factura.motoproducto = "M"


                                ''hjgjh

                                'Factura.IniciarTransaccion()
                                'Factura.FacturarMotocicleta()
                                'Factura.CommitTransaccion()
                                If Factura.idtiposfacturas = 1 Then
                                    Dim formco As New frmCobro
                                    formco.Total = Factura.total
                                    If formco.ShowDialog = DialogResult.OK Then
                                        Factura.IniciarTransaccion()
                                        For Each i In formco.ControlCaja
                                            i.Cajero = PanelAccion1.Usuario.Id
                                            i.idSucursales = PanelAccion1.sucursal.Id
                                            i.Guardar()
                                            Dim c = New ControlCajaFactura
                                            c.Guardar (Factura.Id, i.Id)
                                            If i.idTransaccionesCaja = 3 Then
                                                formco.TransaccionTC.idControlCaja = i.Id
                                                formco.TransaccionTC.idFacturaEnbezado = Factura.Id
                                                formco.TransaccionTC.Guardar()

                                            End If
                                        Next
                                        Factura.FacturarMotocicleta()
                                        Factura.CommitTransaccion()
                                    Else
                                        Factura.IniciarTransaccion()
                                        Factura.estado = "P"
                                        Factura.Guardar()
                                        Factura.CommitTransaccion()
                                        MessageBox.Show ("El cancelo el cobro", "Error", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Error)
                                    End If
                                    ''kkkj
                                Else
                                    ''TODO: creacion de la cuenta corriente
                                End If


                                Factura = _factura
                                Me.PanelAccion1.BarraProgreso.Value = 100
                                Me.PanelAccion1.lblEstado.Text = "Factura guardada correctamente"
                            Else
                                MessageBox.Show ("Selecione una motocicleta", "Error", MessageBoxButtons.OK, _
                                                 MessageBoxIcon.Error)
                            End If
                        Else
                            MessageBox.Show ("Selecione un tipo de factura", "Error", MessageBoxButtons.OK, _
                                             MessageBoxIcon.Error)
                        End If
                    ElseIf Factura.estado.ToUpper = "F" Then
                        Dim f As New frmIniciosesion
                        f.Autorizar = True
                        f.ShowDialog()
                        If f.Autorizo Then
                            Factura.IniciarTransaccion()
                            Dim i As New ControlCaja
                            i.Cajero = PanelAccion1.Usuario.Id
                            i.Descripcion = "Anulación de factura para el usuario " + PanelAccion1.Usuario.NombreUsuario
                            i.Fecha = Now
                            i.idSucursales = PanelAccion1.sucursal.Id
                            i.idTransaccionesCaja = 10
                            i.Monto = Factura.total
                            i.Guardar()
                            Dim c As New ControlCajaFactura
                            c.Guardar (Factura.Id, i.Id)
                            Factura.AnularFacturaMotocicleta()
                            Factura.CommitTransaccion()
                            _factura.Id = Me.Factura.Id
                            Factura = _factura
                        Else
                            Throw New ApplicationException ("No se realizó la anulación de la factura")
                        End If

                    End If

                Else
                    MessageBox.Show ("Ya se realizo el cierre para este usuario", "Error", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show ("No se ha abierto la caja para este usuario", "Error", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            Factura.RollBackTransaccion()
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir

    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Factura = New FacturaEncabezado
    End Sub

    Private Sub txtDescuentoPor_TextChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles txtDescuentoPor.TextChanged
        If txtDescuentoPor.Text <> String.Empty Then
            Me.Factura.descuento = txtDescuentoPor.Text
        Else
            Me.Factura.descuento = 0
        End If
        calculartotales()
    End Sub

    Private Sub txtPrecioVenta_TextChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles txtPrecioVenta.TextChanged
        If txtPrecioVenta.Text <> String.Empty Then
            If Factura.Motocicleta.Id > 0 Then
                Factura.Motocicleta.precioventa = txtPrecioVenta.Text
            Else
                txtPrecioVenta.Text = "0.00"
            End If

        Else
            Factura.Motocicleta.precioventa = 0
        End If
        calculartotales()
    End Sub

#End Region
End Class
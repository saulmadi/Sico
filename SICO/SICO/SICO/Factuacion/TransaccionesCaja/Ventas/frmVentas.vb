Imports SiCo.ctrla.ControlesBasicos
Imports SiCo.ctrla2
Imports SiCo.ctrla
Imports SiCo.lgla2

Public Class frmVentas

#Region "Declaraciones"

    Private _factura As New FacturaEncabezado

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
        grdDetalle.ListaFormatos.Clear()
        grdDetalle.DataSource = Nothing
        Me.grdDetalle.Enabled = True
        If cmbTiposFacturas.Items.Count = 0 Then
            cmbTiposFacturas.Entidad = New TiposFacturas
            cmbTiposFacturas.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("habilitado", "1"))
            cmbTiposFacturas.IncializarCarga()

        End If


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
            txtDescPor.Enabled = True
            For i As Integer = 0 To 10
                Factura.ListaDetalle.Add (New FacturaDetalle (PanelAccion1.sucursal.Id))
            Next


            Me.grdDetalle.DarFormato ("Codigo", "Código", True)
            Me.grdDetalle.DarFormato ("ProductoDescripcion", "Descripción", True)
            Me.grdDetalle.DarFormato ("Existencia", "Existencia", True)
            Me.grdDetalle.DarFormato ("Precio", "Precio", True)
            Me.grdDetalle.DarFormato ("CantidadEditable", "Cantidad", True)

            Me.grdDetalle.DarFormato ("TotalLinea", "Total Linea")
            grdDetalle.DataSource = Factura.ListaDetalle
            grdDetalle.ReadOnly = False


        Else

            Me.grdDetalle.DarFormato ("Codigo", "Código", True)
            Me.grdDetalle.DarFormato ("ProductoDescripcion", "Descripción", True)
            Me.grdDetalle.DarFormato ("Existencia", "Existencia", True)
            Me.grdDetalle.DarFormato ("Precio", "Precio", True)
            Me.grdDetalle.DarFormato ("CantidadEditable", "Cantidad", True)


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

            Factura.CargarDetalle()
            If Factura.estado.ToUpper = "P" Then
                Me.PanelAccion1.BotonEliminar.Text = "Facturar"
                Me.PanelAccion1.BotonEliminar.Visible = True

                txtDescPor.Enabled = True
                chkVentaExcenta.Enabled = True
                cmbTiposFacturas.Enabled = True
                CrtClientes.Enabled = True
                Me.PanelAccion1.BotonGuardar.Enabled = True
                Me.grdDetalle.Enabled = True
                While Factura.ListaDetalle.Count < 12
                    Factura.ListaDetalle.Add (New FacturaDetalle (Factura.idsucursales))
                End While
            ElseIf Factura.estado.ToUpper = "F" Then
                Me.PanelAccion1.BotonEliminar.Text = "Anular"
                Me.PanelAccion1.BotonEliminar.Visible = True

                txtDescPor.Enabled = False
                chkVentaExcenta.Enabled = False
                cmbTiposFacturas.Enabled = False
                CrtClientes.Enabled = False
                Me.PanelAccion1.BotonGuardar.Enabled = False

                Me.grdDetalle.Enabled = True
                'While Factura.ListaDetalle.Count < 12
                '    Factura.ListaDetalle.Add(New FacturaDetalle(Factura.idsucursales))
                'End While
            ElseIf Factura.estado.ToUpper = "A" Then
                Me.PanelAccion1.BotonEliminar.Text = "Anular"
                Me.PanelAccion1.BotonEliminar.Visible = False

                txtDescPor.Enabled = False
                chkVentaExcenta.Enabled = False
                cmbTiposFacturas.Enabled = False
                CrtClientes.Enabled = False
                Me.PanelAccion1.BotonGuardar.Enabled = False

                Me.grdDetalle.Enabled = False
                'While Factura.ListaDetalle.Count < 12
                '    Factura.ListaDetalle.Add(New FacturaDetalle(Factura.idsucursales))
                'End While
            Else


                Me.PanelAccion1.BotonEliminar.Visible = False
                txtDescPor.Enabled = False
                chkVentaExcenta.Enabled = False
                cmbTiposFacturas.Enabled = False
                CrtClientes.Enabled = True
                Me.PanelAccion1.BotonGuardar.Enabled = False
            End If
            Me.txtDesc.Text = Factura.descuentovalor
            Me.txtDescPor.Text = Factura.descuento
            grdDetalle.DataSource = Factura.ListaDetalle
            calculartotales()

        End If
    End Sub

    Private Sub calculartotales()
        Factura.CalcularDetalle()
        txtSubtotal.Text = Factura.subtotal.ToString ("#######0.00")
        txtDesc.Text = Factura.descuentovalor.ToString ("#########0.00")
        txtImpto.Text = Factura.isv.ToString ("########0.00")
        txtTotal.Text = Factura.total.ToString ("########0.00")
        grdDetalle.Refresh()
    End Sub

#End Region

#Region "Eventos"

    Private Sub frmVentas_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'cmbTiposFacturas.Entidad = New TiposFacturas
        'cmbTiposFacturas.ColeccionParametros.Add(New ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        'cmbTiposFacturas.CargarParametros()
        lblNumeroFactura.Text = ""

        PanelAccion1.BotonImprimir.Text = "Facturar"
        PanelAccion1.BotonImprimir.Visible = False

        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonEliminar.Text = ""

        PanelAccion1.BotonGuardar.Enabled = False

        CrtClientes.ControlPersonaJuridicas.EtiquetaError = PanelAccion1.lblEstado
        CrtClientes.ControlPersonaNatural.EtiquetaError = PanelAccion1.lblEstado
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Factura = New FacturaEncabezado
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub grdDetalle_Buscar() Handles grdDetalle.Buscar

        Dim f As New frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = DialogResult.OK Then

            Factura.ListaDetalle (grdDetalle.CurrentRow.Index).setProducto (f.Entidad)

            grdDetalle.Refresh()


        End If
        calculartotales()
    End Sub

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Eliminar
        Try
            Dim ct As New ControlCaja
            ct.Buscar (4, Me.PanelAccion1.Usuario.Id, Now, Me.PanelAccion1.sucursal.Id)
            If ct.TotalRegistros <> 0 Then
                ct.Buscar (5, Me.PanelAccion1.Usuario.Id, Now, PanelAccion1.sucursal.Id)
                If ct.TotalRegistros = 0 Then
                    If Me.Factura.estado.ToUpper = "P" Then


                        Me.PanelAccion1.BarraProgreso.Value = 50
                        Me.PanelAccion1.lblEstado.Text = "Guardando..."
                        If cmbTiposFacturas.SelectedIndex > - 1 Then
                            Factura.idclientes = CrtClientes.Guardar()

                            If Factura.idclientes = 0 Then
                                CrtClientes.Nuevo()
                            End If
                            Factura.fecha = DateTimePicker1.Value
                            Factura.Elabora = PanelAccion1.Usuario.Id
                            Factura.idsucursales = PanelAccion1.sucursal.Id
                            Factura.Factura = PanelAccion1.Usuario.Id
                            Factura.idtiposfacturas = cmbTiposFacturas.SelectedValue

                            Factura.motoproducto = "P"
                            'Factura.IniciarTransaccion()
                            ''Factura.FacturarProducto()
                            'Factura.CommitTransaccion()
                            Select Case Factura.idtiposfacturas
                                Case 1
                                    Dim formco As New frmCobro
                                    formco.Total = Factura.total
                                    If formco.ShowDialog = DialogResult.OK Then
                                        Factura.IniciarTransaccion()
                                        For Each i In formco.ControlCaja
                                            i.Cajero = PanelAccion1.Usuario.Id
                                            i.idSucursales = PanelAccion1.sucursal.Id
                                            i.Guardar()
                                            Dim c = New ControlCajaFactura
                                            c.Guardar(Factura.Id, i.Id)
                                            If i.idTransaccionesCaja = 3 Then
                                                formco.TransaccionTC.idControlCaja = i.Id
                                                formco.TransaccionTC.idFacturaEnbezado = Factura.Id
                                                formco.TransaccionTC.Guardar()

                                            End If
                                        Next
                                        Factura.FacturarProducto()
                                        Factura.CommitTransaccion()
                                    Else
                                        Factura.IniciarTransaccion()
                                        Factura.estado = "P"
                                        Factura.Guardar()
                                        Factura.CommitTransaccion()
                                        MessageBox.Show("El cancelo el cobro", "Error", MessageBoxButtons.OK, _
                                                         MessageBoxIcon.Error)
                                    End If
                                Case 2

                                    If Factura.idclientes > 0 Then
                                        Factura.IniciarTransaccion()
                                        Dim c = New ControlCaja
                                        c.Cajero = Me.PanelAccion1.Usuario.Id
                                        c.Descripcion = "Pago de factura al crédito para el cliente " + _
                                                        CrtClientes.Cliente.NombreMantenimiento
                                        c.Fecha = Now
                                        c.idSucursales = Me.PanelAccion1.sucursal.Id
                                        c.idTransaccionesCaja = 1
                                        c.Monto = Factura.total
                                        c.Guardar()
                                        Dim cf = New ControlCajaFactura
                                        cf.Guardar(Factura.Id, c.Id)

                                        Dim frmCre As New frmCreditoVencimiento
                                        If frmCre.ShowDialog = DialogResult.OK Then
                                            Dim cuent = New Cuentacorriente
                                            Dim saldo = cuent.CalcularSaldo(1, CrtClientes.Cliente.idEntidades)
                                            If saldo > 0 Then
                                                Throw New ApplicationException("Este cliente tiene un saldo pendiente")
                                            End If
                                            cuent.AgragrarDebitoMovimientoProductos(CrtClientes.Cliente.idEntidades, _
                                                                                    Factura.total, _
                                                                                    frmCre.txtDescripcion.Text, _
                                                                                    frmCre.dteFechaVencimiento.Value, _
                                                                                    Me.PanelAccion1.sucursal.Id)
                                        Else
                                            Throw New ApplicationException("Canceló los terminos del plazo de la deuda")
                                        End If


                                        Factura.FacturarProducto()

                                        Factura.CommitTransaccion()
                                    Else
                                        Mensaje.MensajeError("Debe seleccionar cliente para agregar cuenta corriente")
                                    End If

                            End Select

                            _factura.Id = Me.Factura.Id
                            Me.Factura = _factura
                            Me.PanelAccion1.BarraProgreso.Value = 100
                            Me.PanelAccion1.lblEstado.Text = "Factura guardada correctamente"

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
                            Factura.AnularFactura()
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
            Try
                Factura.RollBackTransaccion()
            Catch ex2 As Exception
            End Try

            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Me.PanelAccion1.BarraProgreso.Value = 50
            Me.PanelAccion1.lblEstado.Text = "Guardando..."
            If cmbTiposFacturas.SelectedIndex > - 1 Then
                Factura.idclientes = CrtClientes.Guardar()
                Dim s = CrtClientes.Cliente.idEntidades
                If Factura.idclientes = 0 Then
                    CrtClientes.Nuevo()
                End If
                Factura.fecha = DateTimePicker1.Value
                Factura.estado = "P"
                Factura.Elabora = PanelAccion1.Usuario.Id
                Factura.idsucursales = PanelAccion1.sucursal.Id
                Factura.idtiposfacturas = cmbTiposFacturas.SelectedValue
                Factura.numerofactura = Guid.NewGuid.ToString


                Factura.motoproducto = "P"
                Factura.GuardarFacturaProducto()
                Factura = _factura
                Me.PanelAccion1.BarraProgreso.Value = 100
                Me.PanelAccion1.lblEstado.Text = "Factura guardada correctamente"

            Else
                MessageBox.Show ("Selecione un tipo de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir

    End Sub

    Private Sub grdDetalle_CellEndEdit (ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
        Handles grdDetalle.CellEndEdit
        Me.calculartotales()
    End Sub

    Private Sub grdDetalle_Eliminar (ByVal EliminarArg As GridEliminarEventArg) Handles grdDetalle.Eliminar
        Me.Factura.ListaDetalle (grdDetalle.CurrentRow.Index) = New FacturaDetalle (PanelAccion1.sucursal.Id)

        grdDetalle.Refresh()
        calculartotales()
    End Sub

    Private Sub txtDescPor_TextChanged (ByVal sender As Object, ByVal e As EventArgs) Handles txtDescPor.TextChanged
        If txtDescPor.Text <> String.Empty Then
            Me.Factura.descuento = txtDescPor.Text

        Else
            Me.Factura.descuento = 0
        End If
        calculartotales()
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

#End Region
End Class
Imports SICO.lgla
Imports SICO.lgla2
Imports SICO.ctrla
Public Class frmVentas

#Region "Declaraciones"
    Private _factura As New FacturaEncabezado

#End Region

#Region "Propiedades"
    Public Property Factura() As FacturaEncabezado
        Get
            Return _factura
        End Get
        Set(ByVal value As FacturaEncabezado)
            _factura = value
            cargarentidad()
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Sub cargarentidad()
        grdDetalle.ListaFormatos.Clear()
        grdDetalle.DataSource = Nothing
        If cmbTiposFacturas.Items.Count = 0 Then
            cmbTiposFacturas.Entidad = New TiposFacturas
            cmbTiposFacturas.ColeccionParametros.Add(New ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
            cmbTiposFacturas.IncializarCarga()

        End If
        

        Me.PanelAccion1.BotonEliminar.Visible = False
        If Factura.Id = 0 Then
            CrtClientes.Nuevo()
            cmbTiposFacturas.SelectedIndex = -1
            chkVentaExcenta.Checked = False
            chkVentaExcenta.Enabled = True
            cmbTiposFacturas.Enabled = True
            CrtClientes.Enabled = True

            PanelAccion1.BotonGuardar.Enabled = True
            Factura.ListaDetalle = New List(Of FacturaDetalle)
            txtDescPor.Enabled = True
            For i As Integer = 0 To 10
                Factura.ListaDetalle.Add(New FacturaDetalle(PanelAccion1.sucursal.Id))
            Next


            Me.grdDetalle.DarFormato("Codigo", "Código", True)
            Me.grdDetalle.DarFormato("ProductoDescripcion", "Descripción", True)
            Me.grdDetalle.DarFormato("Existencia", "Existencia", True)
            Me.grdDetalle.DarFormato("Precio", "Precio", True)
            Me.grdDetalle.DarFormato("CantidadEditable", "Cantidad", True)

            Me.grdDetalle.DarFormato("TotalLinea", "Total Linea")
            grdDetalle.DataSource = Factura.ListaDetalle
            grdDetalle.ReadOnly = False



        Else
            
            Me.grdDetalle.DarFormato("Codigo", "Código", True)
            Me.grdDetalle.DarFormato("ProductoDescripcion", "Descripción", True)
            Me.grdDetalle.DarFormato("Existencia", "Existencia", True)
            Me.grdDetalle.DarFormato("Precio", "Precio", True)
            Me.grdDetalle.DarFormato("CantidadEditable", "Cantidad", True)

            Me.txtDesc.Text = Factura.descuento

            lblNumeroFactura.Text = Factura.NumeroFacturaS
            Dim cliente As New Clientes
            cliente.Buscar("id", Factura.idclientes)
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
                While Factura.ListaDetalle.Count < 12
                    Factura.ListaDetalle.Add(New FacturaDetalle(Factura.idsucursales))
                End While
            Else

                Me.PanelAccion1.BotonEliminar.Visible = False
                txtDescPor.Enabled = False
                chkVentaExcenta.Enabled = False
                cmbTiposFacturas.Enabled = False
                CrtClientes.Enabled = True
                Me.PanelAccion1.BotonGuardar.Enabled = False
            End If

            grdDetalle.DataSource = Factura.ListaDetalle
            calculartotales()

        End If
    End Sub

    Private Sub calculartotales()
        Factura.CalcularDetalle()
        txtSubtotal.Text = Factura.subtotal.ToString("#######0.00")
        txtDesc.Text = Factura.descuentovalor.ToString("#########0.00")
        txtImpto.Text = Factura.isv.ToString("########0.00")
        txtTotal.Text = Factura.total.ToString("########0.00")
        grdDetalle.Refresh()
    End Sub
#End Region

#Region "Eventos"

    Private Sub frmVentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Dim f As New SICO.ctrla2.frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Factura.ListaDetalle(grdDetalle.CurrentRow.Index).setProducto(f.Entidad)

            grdDetalle.Refresh()


        End If
        calculartotales()
    End Sub

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Eliminar
        Try
            Me.PanelAccion1.BarraProgreso.Value = 50
            Me.PanelAccion1.lblEstado.Text = "Guardando..."
            If cmbTiposFacturas.SelectedIndex > -1 Then
                Factura.idclientes = CrtClientes.Guardar()
                If Factura.idclientes = 0 Then
                    CrtClientes.Nuevo()
                End If
                Factura.fecha = DateTimePicker1.Value
                Factura.Elabora = PanelAccion1.Usuario.Id
                Factura.idsucursales = PanelAccion1.sucursal.Id
                Factura.idtiposfacturas = cmbTiposFacturas.SelectedValue
                Factura.motoproducto = "P"
                Factura.FacturarProducto()
                _factura.Id = Me.Factura.Id
                Me.Factura = _factura
                Me.PanelAccion1.BarraProgreso.Value = 100
                Me.PanelAccion1.lblEstado.Text = "Factura guardada correctamente"

            Else
                MessageBox.Show("Selecione un tipo de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Me.PanelAccion1.BarraProgreso.Value = 50
            Me.PanelAccion1.lblEstado.Text = "Guardando..."
            If cmbTiposFacturas.SelectedIndex > -1 Then
                Factura.idclientes = CrtClientes.Guardar()
                If Factura.idclientes = 0 Then
                    CrtClientes.Nuevo()
                End If
                Factura.fecha = DateTimePicker1.Value
                Factura.estado = "P"
                Factura.Elabora = PanelAccion1.Usuario.Id
                Factura.idsucursales = PanelAccion1.sucursal.Id
                Factura.idtiposfacturas = cmbTiposFacturas.SelectedValue
                Factura.motoproducto = "P"
                Factura.GuardarFacturaProducto()
                Factura = _factura
                Me.PanelAccion1.BarraProgreso.Value = 100
                Me.PanelAccion1.lblEstado.Text = "Factura guardada correctamente"

            Else
                MessageBox.Show("Selecione un tipo de factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir

    End Sub

    Private Sub grdDetalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetalle.CellEndEdit
        Me.calculartotales()
    End Sub

    Private Sub grdDetalle_Eliminar(ByVal EliminarArg As SICO.ctrla.GridEliminarEventArg) Handles grdDetalle.Eliminar
        Me.Factura.ListaDetalle(grdDetalle.CurrentRow.Index) = New FacturaDetalle(PanelAccion1.sucursal.Id)

        grdDetalle.Refresh()
        calculartotales()
    End Sub

    Private Sub txtDescPor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescPor.TextChanged
        If txtDescPor.Text <> String.Empty Then
            Me.Factura.descuento = txtDescPor.Text
        Else
            Me.Factura.descuento = 0
        End If
        calculartotales()
    End Sub

    Private Sub chkVentaExcenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVentaExcenta.CheckedChanged
        If chkVentaExcenta.Checked Then
            Factura.ventaexcenta = 1
        Else
            Factura.ventaexcenta = 0
        End If
        calculartotales()

    End Sub

#End Region

End Class
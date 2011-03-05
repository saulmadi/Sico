Imports SICO.lgla2
Imports SICO.ctrla
Public Class frmCompras

#Region "Declaraciones"
    Private _compras As New Compras
#End Region

#Region "Constructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().       

    End Sub
#End Region

#Region "Propiedades"
    Public Property Compras() As Compras
        Get
            Return _compras
        End Get
        Set(ByVal value As Compras)
            _compras = value
            grpCompra.Enabled = True
            cmbProveedor.Enabled = True

            txtTelefono.Clear()
            

            txtFacturCompra.Text = ""
            

         

            If value.Id = 0 Then
                If cmbProveedor.Items.Count = 0 Then
                    cmbProveedor.Entidad = New Proveedores

                    cmbProveedor.CargarEntidad()
                    cmbProveedor.DisplayMember = "NombreMantenimiento"
                    cmbProveedor.ValueMember = "Id"
                End If

                If cmbSucursales.Items.Count = 0 Then
                    cmbSucursales.Inicialiazar()
                    cmbProveedor.DisplayMember = "NombreMantenimiento"
                    cmbProveedor.ValueMember = "Id"
                End If
                Me.grdDetalle.BotonEliminar = True
                Me.grdDetalle.BotonBuscar = True

                cmbProveedor.SelectedIndex = -1
                cmbSucursales.SelectedIndex = -1
                PanelAccion1.BotonGuardar.Enabled = True
                PanelAccion1.BotonImprimir.Enabled = False

                dteFechaCompra.Value = Now

                value.ListaDetalle.Clear()

                For i As Integer = 1 To 50
                    value.ListaDetalle.Add(New DetalleCompras)
                Next

                grdDetalle.DataSource = value.ListaDetalle
                PanelAccion1.BotonNuevo.Enabled = True

            Else
                If cmbProveedor.Items.Count = 0 Then
                    cmbProveedor.Entidad = New Proveedores

                    cmbProveedor.IncializarCarga()
                    cmbProveedor.DisplayMember = "NombreMantenimiento"
                    cmbProveedor.ValueMember = "Id"
                End If

                If cmbSucursales.Items.Count = 0 Then
                    cmbSucursales.Entidad = New SICO.lgla.Sucursales
                    cmbSucursales.IncializarCarga()
                    cmbSucursales.DisplayMember = "NombreMantenimiento"
                    cmbSucursales.ValueMember = "Id"
                End If
                PanelAccion1.BotonGuardar.Enabled = True
                PanelAccion1.BotonImprimir.Enabled = True
                dteFechaCompra.Value = value.fechacompra
                txtFacturCompra.Text = value.facturacompra
                cmbProveedor.SelectedIndex = 0
                cmbProveedor.SelectedValue = Compras.idproveedor
                cmbSucursales.SelectedValue = Compras.idsucursal

                Me.grdDetalle.BotonEliminar = False
                Me.grdDetalle.BotonBuscar = False
                value.CargarDetalle()
                grdDetalle.DataSource = _compras.ListaDetalle

            End If
            txtimpuesto.Text = value.Impuesto
            txtsubtotal.Text = value.CalcularTotal
            txttotal.Text = value.CalcularTotal
        End Set
    End Property
#End Region

#Region "Eventos"
    Private Sub frmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal

        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonImprimir.Enabled = False
        PanelAccion1.BotonGuardar.Enabled = False

        grdDetalle.BotonBuscar = True
        grdDetalle.BotonEliminar = True
        grdDetalle.RowHeadersVisible = True
        grdDetalle.DarFormato("codigo", "Código", False)
        grdDetalle.DarFormato("descripcion", "Descripción", True)
        grdDetalle.DarFormato("CantidadEditable", "Cantidad", False)
        grdDetalle.DarFormato("PrecioEditable", "Precio de Compra", False)
        grdDetalle.DarFormato("SubtotalString", "Subtotal", True)

       

    End Sub

    Private Sub grdDetalle_Buscar() Handles grdDetalle.Buscar
        Dim f As New SICO.ctrla2.frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim d As New DetalleCompras
            d.Producto = f.Entidad

            Me.Compras.ListaDetalle(grdDetalle.CurrentRow.Index).Producto = f.Entidad
            grdDetalle.Refresh()
        End If

    End Sub

    Private Sub grdDetalle_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetalle.CellEndEdit
        txtimpuesto.Text = Me.Compras.Impuesto
        txtsubtotal.Text = Me.Compras.CalcularTotal
        txttotal.Text = Me.Compras.CalcularTotal
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Compras = New Compras
    End Sub

    Private Sub cmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedor.SelectedIndexChanged
        Try
            If Not cmbProveedor.SelectedItem Is Nothing Then
                Dim en As SICO.lgla.PersonaJuridica = CType(cmbProveedor.SelectedItem, Proveedores).PersonaJuridica
                txtTelefono.Text = Convert.ToString(en.telefono)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedor.TextChanged
        txtTelefono.Clear()
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim vali As New Validador
            vali.ColecionCajasTexto.Add(txtFacturCompra)
            If vali.PermitirIngresar Then
                If Not cmbProveedor.SelectedItem Is Nothing Then
                    If Not cmbSucursales.SelectedItem Is Nothing Then
                        Me.PanelAccion1.BarraProgreso.Value = 50
                        Me.PanelAccion1.lblEstado.Text = "Guardando..."
                        Me.Compras.facturacompra = txtFacturCompra.ValorLong
                        Me.Compras.idproveedor = cmbProveedor.SelectedValue
                        Me.Compras.idsucursal = cmbSucursales.SelectedValue
                        Me.Compras.fechacompra = dteFechaCompra.Value

                        Me.Compras.GuardarCompra()
                        _compras.Id = Compras.Id
                        Me.Compras = _compras
                        Me.PanelAccion1.BarraProgreso.Value = 100
                        Me.PanelAccion1.lblEstado.Text = "Compra guardada exitosamente"

                    Else
                        PanelAccion1.lblEstado.Text = "Seleccione la sucursal destino del prodcuto"
                    End If
                Else
                    PanelAccion1.lblEstado.Text = "Seleccione un proveedor.."
                End If
            Else
                PanelAccion1.lblEstado.Text = vali.MensajesError
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.lblEstado.Text = "Error..."
            Me.PanelAccion1.BarraProgreso.Value = 0
        End Try
    End Sub

    Private Sub grdDetalle_Eliminar(ByVal EliminarArg As SICO.ctrla.GridEliminarEventArg) Handles grdDetalle.Eliminar
        Me.Compras.ListaDetalle(grdDetalle.CurrentRow.Index) = New DetalleCompras
    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir
        Dim re As New crCompras
        Dim f As New frmVistaPrevia

        _compras.Id = Me.Compras.Id
        cmbProveedor.SelectedValue = Me.Compras.idproveedor
        cmbSucursales.SelectedValue = Me.Compras.idsucursal
        re.Subreports("crProveedor.rpt").DataDefinition.FormulaFields("Proveedor").Text = "'" + Me.Compras.DescripcionProveedor + "'"
        re.Subreports("crProveedor.rpt").DataDefinition.FormulaFields("Telefono").Text = "'" + txtTelefono.Text + "'"

        re.DataDefinition.FormulaFields("Sucursal").Text = "'" + cmbSucursales.SelectedItem.NombreMantenimiento + "'"
        re.DataDefinition.FormulaFields("Fecha").Text = "'" + Me.Compras.fechacompra.ToString("dd/MM/yyyy") + "'"
        re.DataDefinition.FormulaFields("Factura").Text = "'" + Me.Compras.facturacompra.ToString + "'"

        Dim d As New DetalleCompras
        d.Buscar(Me.Compras.Id.ToString, Nothing)

        re.SetDataSource(d.Tabla)
        
        f.MdiParent = Me.MdiParent
        Me.WindowState = FormWindowState.Minimized
        f.Show(re, "Compras")

    End Sub
#End Region
  
   
End Class
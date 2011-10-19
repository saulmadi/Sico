Imports SiCo.ctrla2
Imports SiCo.lgla
Imports SiCo.ctrla
Imports SiCo.lgla2

Public Class frmOrdenesCompra

#Region "Declaraciones"

    Private _OrdenCompra As New OrdenCompra()
    Private _flagCarCombo As Boolean = False

    Private Event CambioOrdenCompra()

#End Region

#Region "Propiedades"

    Public Property OrdenCompar() As OrdenCompra
        Get
            Return _OrdenCompra
        End Get
        Set (ByVal value As OrdenCompra)
            If Not value Is Nothing Then
                _OrdenCompra = value
                RaiseEvent CambioOrdenCompra()
            End If
        End Set
    End Property

#End Region

#Region "Metodos"

    Private Sub limpiar (ByVal crt As Control)
        For Each i In crt.Controls
            Dim g As Control = CType (i, Control)
            limpiar (i)
            If TypeOf i Is TextBox Then
                i.clear()
            End If

        Next
    End Sub

#End Region

#Region "Eventos"

    Private Sub frmOrdenesCompra_CambioOrdenCompra() Handles Me.CambioOrdenCompra
        Try


            limpiar (Me)
            cmbProveedor.Enabled = True

            dteFechaEmision.Enabled = True

            If Me.OrdenCompar.Id = 0 Then
                Grid.BotonBuscar = True
                Grid.BotonEliminar = True

                txtSucursal.Text = CrtPanelBase1.sucursal.NombreSucursal

                txtElaboradoPor.Text = CrtPanelBase1.Usuario.NombreUsuario
                If cmbProveedor.Items.Count = 0 Then
                    cmbProveedor.Entidad = New Proveedores
                    cmbProveedor.CargarEntidad()
                Else
                    cmbProveedor.SelectedIndex = - 1
                End If

                For h As Integer = 0 To 49
                    Me.OrdenCompar.ListaDetalle.Add (New DetalleOrdenCompra())
                Next
                PanelAccion1.btnGuardar.Enabled = True
                Grid.DataSource = Me.OrdenCompar.ListaDetalle
            Else

                Grid.BotonBuscar = False
                Grid.BotonEliminar = False
                Me.dteFechaEmision.Value = Me.OrdenCompar.fechaorden
                If cmbProveedor.Items.Count = 0 Then
                    cmbProveedor.Entidad = New Proveedores
                    cmbProveedor.IncializarCarga()

                End If

                cmbProveedor.SelectedValue = Me.OrdenCompar.idproveedor

                Dim us As New Usuario
                us.Id = Me.OrdenCompar.elaboradopor

                Dim su As New Sucursales
                su.Id = Me.OrdenCompar.idsucursal

                txtElaboradoPor.Text = us.NombreMantenimiento
                txtSucursal.Text = su.NombreMantenimiento

                txtNumeroOrden.Text = Me.OrdenCompar.codigo

                Me.PanelAccion1.BtnImprimir.Enabled = True

                Me.OrdenCompar.CargarDetalle()
                Grid.DataSource = Me.OrdenCompar.ListaDetalle


            End If
        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmOrdenesCompra_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.PanelAccion1.BotonEliminar.Visible = False
        Me.PanelAccion1.BotonGuardar.Enabled = False
        Me.PanelAccion1.BotonImprimir.Enabled = False

        Me.Grid.DarFormato ("codigo", "Código", True)
        Me.Grid.DarFormato ("descripcion", "Descripción", True)
        Me.Grid.DarFormato ("CantidadEditable", "Cantidad", True)
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.OrdenCompar = New OrdenCompra
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir
        Try
            Dim d As New DetalleOrdenCompra
            Dim re As New crOrdenCompra
            Dim f As New frmVistaPrevia
            _OrdenCompra.Id = Me.OrdenCompar.Id
            If Me.cmbProveedor.SelectedValue <> Me.OrdenCompar.idproveedor Then
                cmbProveedor.SelectedValue = Me.OrdenCompar.idproveedor
            End If

            re.Subreports ("crProveedor.rpt").DataDefinition.FormulaFields ("Proveedor").Text = "'" + _
                                                                                                Me.OrdenCompar. _
                                                                                                    DescripcionProveedor + _
                                                                                                "'"
            re.Subreports ("crProveedor.rpt").DataDefinition.FormulaFields ("Telefono").Text = "'" + _
                                                                                               txtTelefonoProveedor.Text + _
                                                                                               "'"

            re.DataDefinition.FormulaFields ("elaboradoen").Text = "'" + txtSucursal.Text + "'"
            re.DataDefinition.FormulaFields ("Fecha").Text = "'" + Me.OrdenCompar.fechaorden.ToString ("dd/MM/yyyy") + _
                                                             "'"
            re.DataDefinition.FormulaFields ("numero").Text = "'" + Me.OrdenCompar.codigo.ToString + "'"
            re.DataDefinition.FormulaFields ("elaborado").Text = "'" + Me.txtElaboradoPor.Text + "'"
            re.DataDefinition.FormulaFields ("elaborado").Text = "'" + Me.txtElaboradoPor.Text + "'"
            re.DataDefinition.FormulaFields ("Contacto").Text = "'" + Me.txtContacto.Text + "'"
            re.DataDefinition.FormulaFields ("Telefono").Text = "'" + Me.txtTelefonoContacto.Text + "'"


            d.Buscar (Me.OrdenCompar.Id.ToString)

            re.SetDataSource (d.Tabla)
            f.Show (re, "Orden de Compra")
        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            If Not cmbProveedor.SelectedItem Is Nothing Then

                Me.PanelAccion1.BarraProgreso.Value = 50
                Me.PanelAccion1.lblEstado.Text = "Guardando..."

                Me.OrdenCompar.idproveedor = cmbProveedor.SelectedValue
                Me.OrdenCompar.fechaorden = dteFechaEmision.Value
                If Me.OrdenCompar.Id = 0 Then
                    Me.OrdenCompar.idsucursal = Me.PanelAccion1.sucursal.Id
                    Me.OrdenCompar.elaboradopor = Me.PanelAccion1.Usuario.Id
                End If

                Me.OrdenCompar.GuardarOrdenCompra()

                Me.txtNumeroOrden.Text = Me.OrdenCompar.codigo

                _OrdenCompra.Id = Me.OrdenCompar.Id
                Me.OrdenCompar = _OrdenCompra

                Me.PanelAccion1.BarraProgreso.Value = 100
                Me.PanelAccion1.lblEstado.Text = "Compra guardada exitosamente"


            Else
                PanelAccion1.lblEstado.Text = "Seleccione un proveedor.."
            End If

        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbProveedor_SelectedIndexChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles cmbProveedor.SelectedIndexChanged
        If Not cmbProveedor.SelectedItem Is Nothing Then
            If _flagCarCombo Then
                Dim p As Proveedores = cmbProveedor.SelectedItem
                Dim pn As New PersonaNatural
                pn.Id = p.IdContacto
                txtContacto.Text = pn.NombreCompletoMostrar
                txtCorreoContacto.Text = pn.correo
                txtTelefonoContacto.Text = pn.telefono.ToString
                txtTelefonoProveedor.Text = p.PersonaJuridica.telefono.ToString
                txtCorreoProveedor.Text = p.PersonaJuridica.correo
            Else
                _flagCarCombo = True
            End If
        Else
            limpiar (GroupBox3)
            limpiar (GroupBox2)
        End If
    End Sub

    Private Sub Grid_Buscar() Handles Grid.Buscar
        Dim f As New frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = DialogResult.OK Then
            Dim d As New DetalleCompras
            d.Producto = f.Entidad

            Me.OrdenCompar.ListaDetalle (Grid.CurrentRow.Index).Producto = f.Entidad
            Grid.Refresh()
        End If
    End Sub

    Private Sub Grid_Eliminar (ByVal EliminarArg As GridEliminarEventArg) Handles Grid.Eliminar
        Me.OrdenCompar.ListaDetalle (Grid.CurrentRow.Index) = New DetalleOrdenCompra
        Grid.Refresh()
    End Sub

#End Region
End Class
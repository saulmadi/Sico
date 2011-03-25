Imports SICO.lgla2
Imports SICO.lgla

Public Class frmRequesicionProducto

#Region "Declaraciones"
    Private _OrdenRequisicion As New OrdenRequiscion
#End Region

#Region "Propiedades"
    Public Property OrdenRequisicion() As OrdenRequiscion
        Get
            Return _OrdenRequisicion
        End Get
        Set(ByVal value As OrdenRequiscion)
            _OrdenRequisicion = value
            cargarentidad()
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Sub limpiar(ByVal crt As Control)
        For Each i In crt.Controls
            Dim g As Control = CType(i, Control)
            limpiar(i)
            If TypeOf i Is TextBox Then
                i.clear()
            End If
        Next
    End Sub

    Private Sub cargarentidad()
        limpiar(Me)

        If Me.OrdenRequisicion.Id = 0 Then


            PanelAccion1.BotonEliminar.Enabled = False
            PanelAccion1.BotonEliminar.Visible = False
            PanelAccion1.BotonImprimir.Visible = False

            PanelAccion1.BotonGuardar.Enabled = True

            lblestado.Text = ""
            grid.BotonBuscar = True
            grid.BotonEliminar = True
            txtsucursalrecibe.Visible = False
            cmbSucursales.Visible = True
            If cmbSucursales.Items.Count = 0 Then
                cmbSucursales.Inicialiazar()
            End If

            txtsucuralenvia.Text = PanelAccion1.sucursal.NombreSucursal
            txtenviadopor.Text = PanelAccion1.Usuario.NombreUsuario
            dteFechaemision.Value = Now
            OrdenRequisicion.Listadetalle.Clear()
            For i As Integer = 0 To 49
                OrdenRequisicion.Listadetalle.Add(New DetalleRequisicion)

            Next
            grid.DataSource = OrdenRequisicion.Listadetalle

        Else
            TextBox6.Text = Me.OrdenRequisicion.codigo

            PanelAccion1.BotonImprimir.Visible = True
            PanelAccion1.BotonGuardar.Enabled = False

            lblestado.Text = OrdenRequisicion.DescripcionEstado
            grid.BotonBuscar = False
            grid.BotonEliminar = False


            txtsucursalrecibe.Visible = True
            cmbSucursales.Visible = False

            dteFechaemision.Value = OrdenRequisicion.fechaemision

            txtsucuralenvia.Text = OrdenRequisicion.SucursalEn.NombreMantenimiento
            txtsucursalrecibe.Text = OrdenRequisicion.SucursalRec.NombreMantenimiento

            If PanelAccion1.sucursal.Id <> OrdenRequisicion.sucursalenvia And OrdenRequisicion.estado = "E" Then
                PanelAccion1.BotonEliminar.Enabled = True
                PanelAccion1.BotonEliminar.Visible = True
            Else
                PanelAccion1.BotonEliminar.Enabled = False
                PanelAccion1.BotonEliminar.Visible = False

            End If

            Dim usu As New Usuario()
            If Not Me.OrdenRequisicion.recibidopor = Nothing Then
                usu.Buscar("id", Me.OrdenRequisicion.enviadopor.ToString + " or c.id = " + Me.OrdenRequisicion.recibidopor.ToString)
            Else
                usu.Buscar(Me.OrdenRequisicion.enviadopor)
            End If
            Dim l As List(Of Usuario) = usu.TablaAColeccion

            If usu.TotalRegistros > 0 Then
                For i As Integer = 0 To usu.TotalRegistros - 1
                    If l(i).Id = OrdenRequisicion.recibidopor Then
                        txtrecibidopor.Text = l(i).NombreMantenimiento
                        txtcorreorecibidopor.Text = l(i).PersonaNatural.correo
                    End If
                    If l(i).Id = OrdenRequisicion.enviadopor Then
                        txtenviadopor.Text = l(i).NombreMantenimiento
                        txtcorreoenviadopor.Text = l(i).PersonaNatural.correo
                    End If
                Next
            End If
            grid.DataSource = Nothing
            Me.OrdenRequisicion.CargarDetalle()
            grid.DataSource = Me.OrdenRequisicion.Listadetalle
            calculartotales()

        End If
    End Sub

    Private Sub calculartotales()
        txtTotalItems.Text = Me.OrdenRequisicion.TotalItems
        txtTotalProductos.Text = Me.OrdenRequisicion.CantidadTotalProductos
    End Sub
#End Region

#Region "Eventos"
    Private Sub frmRequesicionProducto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grid.DarFormato("codigo", "Código", True)
        Me.grid.DarFormato("descripcion", "Descripción", True)
        Me.grid.DarFormato("CantidadEditable", "Cantidad", True)

        PanelAccion1.BotonEliminar.Text = "Recibir"
        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonEliminar.Enabled = False
        PanelAccion1.BotonImprimir.Visible = False

        PanelAccion1.BotonGuardar.Enabled = False

        lblestado.Text = ""

    End Sub

    Private Sub grid_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.CellEndEdit
        calculartotales()
    End Sub

    Private Sub grid_Buscar() Handles grid.Buscar
        Dim f As New SICO.ctrla2.frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim d As New DetalleCompras
            d.Producto = f.Entidad
            Me.OrdenRequisicion.Listadetalle(grid.CurrentRow.Index).Producto = New Productos
            Me.OrdenRequisicion.Listadetalle(grid.CurrentRow.Index).Producto = f.Entidad
            grid.Refresh()
        End If
        calculartotales()
    End Sub

    Private Sub grid_Eliminar(ByVal EliminarArg As SICO.ctrla.GridEliminarEventArg) Handles grid.Eliminar
        Me.OrdenRequisicion.Listadetalle(grid.CurrentRow.Index) = New DetalleRequisicion
        grid.Refresh()
        calculartotales()
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.OrdenRequisicion = New OrdenRequiscion
        calculartotales()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            If Not cmbSucursales.SelectedItem Is Nothing Then
                If Me.OrdenRequisicion.Id = 0 Then

                    PanelAccion1.lblEstado.Text = "Guardando..."
                    PanelAccion1.BarraProgreso.Value = 50

                    OrdenRequisicion.estado = "E"
                    OrdenRequisicion.fechaemision = dteFechaemision.Value
                    OrdenRequisicion.sucursalenvia = PanelAccion1.sucursal.Id
                    OrdenRequisicion.sucursalrecibe = cmbSucursales.SelectedValue

                    OrdenRequisicion.recibidopor = Nothing
                    OrdenRequisicion.enviadopor = PanelAccion1.Usuario.Id
                    OrdenRequisicion.GuardarOrdenRequisicion()
                    Me.OrdenRequisicion = _OrdenRequisicion

                    PanelAccion1.lblEstado.Text = "Orden de requisición guardada correctamente"
                    PanelAccion1.BarraProgreso.Value = 100


                Else
                    PanelAccion1.lblEstado.Text = "Guardando..."
                    PanelAccion1.BarraProgreso.Value = 50
                    OrdenRequisicion.fechaemision = dteFechaemision.Value
                    OrdenRequisicion.sucursalrecibe = cmbSucursales.SelectedValue

                    OrdenRequisicion.GuardarOrdenRequisicion()
                    Me.OrdenRequisicion = _OrdenRequisicion

                    PanelAccion1.lblEstado.Text = "Orden de requisición guardada correctamente"
                    PanelAccion1.BarraProgreso.Value = 100

                End If
            Else
                MessageBox.Show("Eliga una sucursal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                PanelAccion1.lblEstado.Text = "Eliga una sucursal"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.lblEstado.Text = "Error al guardar"
            PanelAccion1.BarraProgreso.Value = 0
        End Try
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Eliminar
        Try
            If OrdenRequisicion.sucursalenvia <> Me.PanelAccion1.sucursal.Id Then

                PanelAccion1.lblEstado.Text = "Guardando..."
                PanelAccion1.BarraProgreso.Value = 50

                OrdenRequisicion.estado = "R"

                OrdenRequisicion.recibidopor = Me.PanelAccion1.Usuario.Id

                OrdenRequisicion.GuardarOrdenRequisicion()
                Me.OrdenRequisicion = _OrdenRequisicion

                PanelAccion1.lblEstado.Text = "Orden de requisición guardada correctamente"
                PanelAccion1.BarraProgreso.Value = 100

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir
        Try
            Dim f As New frmVistaPrevia
            Dim d As New DetalleRequisicion
            Dim cr As New crOrdenRequisicion

            d.Buscar(Me.OrdenRequisicion.Id.ToString)



            cr.DataDefinition.FormulaFields("codigo").Text = "'" + Me.OrdenRequisicion.codigo + "'"
            cr.DataDefinition.FormulaFields("sucursalenvia").Text = "'" + Me.OrdenRequisicion.SucursalEn.NombreMantenimiento + "'"
            cr.DataDefinition.FormulaFields("sucursalrecibe").Text = "'" + Me.OrdenRequisicion.SucursalRec.NombreMantenimiento + "'"
            cr.DataDefinition.FormulaFields("fechaemision").Text = "'" + Me.OrdenRequisicion.fechaemision.ToString("dd/MM/yyyy") + "'"
            cr.DataDefinition.FormulaFields("usuarioenvia").Text = "'" + Me.txtenviadopor.Text + "'"
            cr.DataDefinition.FormulaFields("usuariorecibe").Text = "'" + Me.txtrecibidopor.Text + "'"

            cr.SetDataSource(d.Tabla)

            f.Show(cr, "Orden de Requisición")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region



End Class
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmOrdenSalida

#Region "Declaraciones"
    Private _OrdenSalida As New OrdenSalida
#End Region

#Region "Propiedades"
    Public Property OrdenSalidas() As OrdenSalida
        Get
            Return _OrdenSalida
        End Get
        Set(ByVal value As OrdenSalida)
            _OrdenSalida = value
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

    Private Sub calculartotales()
        txtTotalItems.Text = Me.OrdenSalidas.TotalItems
        txtTotalProductos.Text = Me.OrdenSalidas.CantidadTotalProductos
    End Sub

    Private Sub cargarentidad()
        limpiar(Me)

        If Me.OrdenSalidas.Id = 0 Then


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
            OrdenSalidas.Listadetalle.Clear()
            For i As Integer = 0 To 49
                OrdenSalidas.Listadetalle.Add(New DetalleOrdenSalida(PanelAccion1.sucursal.Id))

            Next
            Grid.DataSource = OrdenSalidas.Listadetalle

        Else
            TextBox6.Text = Me.OrdenSalidas.codigo

            PanelAccion1.BotonImprimir.Visible = True
            PanelAccion1.BotonGuardar.Enabled = False

            lblestado.Text = OrdenSalidas.DescripcionEstado
            grid.BotonBuscar = False
            grid.BotonEliminar = False


            txtsucursalrecibe.Visible = True
            cmbSucursales.Visible = False

            dteFechaEmision.Value = OrdenSalidas.fechaemision

            txtsucuralenvia.Text = OrdenSalidas.SucursalEn.NombreMantenimiento
            txtsucursalrecibe.Text = OrdenSalidas.SucursalRec.NombreMantenimiento

            If PanelAccion1.sucursal.Id <> OrdenSalidas.sucursalenvia And OrdenSalidas.estado = "E" Then
                PanelAccion1.BotonEliminar.Enabled = True
                PanelAccion1.BotonEliminar.Visible = True
            Else
                PanelAccion1.BotonEliminar.Enabled = False
                PanelAccion1.BotonEliminar.Visible = False

            End If

            Dim usu As New Usuario()
            If Not Me.OrdenSalidas.recibidopor = Nothing Then
                usu.Buscar("id", Me.OrdenSalidas.enviadopor.ToString + " or c.id = " + Me.OrdenSalidas.recibidopor.ToString)
            Else
                usu.Buscar(Me.OrdenSalidas.enviadopor)
            End If
            Dim l As List(Of Usuario) = usu.TablaAColeccion

            If usu.TotalRegistros > 0 Then
                For i As Integer = 0 To usu.TotalRegistros - 1
                    If l(i).Id = OrdenSalidas.recibidopor Then
                        txtrecibidopor.Text = l(i).NombreMantenimiento
                        txtcorreorecibidopor.Text = l(i).PersonaNatural.correo
                    End If
                    If l(i).Id = OrdenSalidas.enviadopor Then
                        txtenviadopor.Text = l(i).NombreMantenimiento
                        txtcorreoenviadopor.Text = l(i).PersonaNatural.correo
                    End If
                Next
            End If
            grid.DataSource = Nothing
            Me.OrdenSalidas.CargarDetalle()
            Grid.DataSource = Me.OrdenSalidas.Listadetalle
            calculartotales()

        End If
    End Sub
#End Region

#Region "Eventos"
    Private Sub frmOrdenSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Grid.DarFormato("codigo", "Código", True)
        Me.Grid.DarFormato("ProductoDescripcion", "Descripción", True)
        Me.Grid.DarFormato("Existencia", "Existencia", True)
        Me.Grid.DarFormato("CantidadEditable", "Cantidad", True)

        PanelAccion1.BotonEliminar.Text = "Recibir"
        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonEliminar.Enabled = False
        PanelAccion1.BotonImprimir.Visible = False

        PanelAccion1.BotonGuardar.Enabled = False

        lblestado.Text = ""
    End Sub
    Private Sub grid_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid.CellEndEdit
        calculartotales()
    End Sub
    Private Sub grid_Buscar() Handles Grid.Buscar
        Dim f As New SICO.ctrla2.frmBusquedaProductos
        f.Entidad = New Productos
        If f.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim d As New DetalleCompras
            d.Producto = f.Entidad
            Me.OrdenSalidas.Listadetalle(Grid.CurrentRow.Index).Producto = New ProductosInventario(PanelAccion1.sucursal.Id)
            Me.OrdenSalidas.Listadetalle(Grid.CurrentRow.Index).Producto.Producto = f.Entidad
            grid.Refresh()
        End If
        calculartotales()
    End Sub
    Private Sub grid_Eliminar(ByVal EliminarArg As SICO.ctrla.GridEliminarEventArg) Handles Grid.Eliminar
        Me.OrdenSalidas.Listadetalle(Grid.CurrentRow.Index) = New DetalleOrdenSalida
        grid.Refresh()
        calculartotales()
    End Sub
    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.OrdenSalidas = New OrdenSalida
        calculartotales()
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            If Not cmbSucursales.SelectedItem Is Nothing Then
                If Me.OrdenSalidas.Id = 0 Then

                    PanelAccion1.lblEstado.Text = "Guardando..."
                    PanelAccion1.BarraProgreso.Value = 50

                    OrdenSalidas.estado = "E"
                    OrdenSalidas.fechaemision = dteFechaEmision.Value
                    OrdenSalidas.sucursalenvia = PanelAccion1.sucursal.Id
                    OrdenSalidas.sucursalrecibe = cmbSucursales.SelectedValue

                    OrdenSalidas.recibidopor = Nothing
                    OrdenSalidas.enviadopor = PanelAccion1.Usuario.Id
                    OrdenSalidas.GuardarOrdenSalida()
                    Me.OrdenSalidas = OrdenSalidas

                    PanelAccion1.lblEstado.Text = "Orden de requisición guardada correctamente"
                    PanelAccion1.BarraProgreso.Value = 100


                Else
                    PanelAccion1.lblEstado.Text = "Guardando..."
                    PanelAccion1.BarraProgreso.Value = 50
                    OrdenSalidas.fechaemision = dteFechaEmision.Value
                    OrdenSalidas.sucursalrecibe = cmbSucursales.SelectedValue

                    OrdenSalidas.GuardarOrdenSalida()
                    Me.OrdenSalidas = _OrdenSalida

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

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Eliminar
        Try
            'If OrdenRequisicion.sucursalenvia <> Me.PanelAccion1.sucursal.Id Then

            '    PanelAccion1.lblEstado.Text = "Guardando..."
            '    PanelAccion1.BarraProgreso.Value = 50

            '    OrdenRequisicion.estado = "R"

            '    OrdenRequisicion.recibidopor = Me.PanelAccion1.Usuario.Id

            '    OrdenRequisicion.GuardarOrdenRequisicion()
            '    Me.OrdenRequisicion = _OrdenRequisicion

            '    PanelAccion1.lblEstado.Text = "Orden de requisición guardada correctamente"
            '    PanelAccion1.BarraProgreso.Value = 100

            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir
        Try
           
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region


 
End Class
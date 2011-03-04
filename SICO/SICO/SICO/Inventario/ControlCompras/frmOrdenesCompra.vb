Imports SICO.lgla
Imports SICO.lgla2
Public Class frmOrdenesCompra

#Region "Declaraciones"
    Private _OrdenCompra As New OrdenCompra()

    Private Event CambioOrdenCompra()
#End Region

#Region "Propiedades"
    Public Property OrdenCompar() As OrdenCompra
        Get
            Return _OrdenCompra
        End Get
        Set(ByVal value As OrdenCompra)
            If Not value Is Nothing Then
                _OrdenCompra = value
                RaiseEvent CambioOrdenCompra()
            End If
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
#End Region

#Region "Eventos"
    Private Sub frmOrdenesCompra_CambioOrdenCompra() Handles Me.CambioOrdenCompra
        limpiar(Me)

        If Me.OrdenCompar.Id = 0 Then
            Grid.BotonBuscar = True
            Grid.BotonEliminar = True

            txtSucursal.Text = CrtPanelBase1.Sucursal.NombreSucursal
            
            txtElaboradoPor.Text = CrtPanelBase1.Usuario.NombreUsuario
            If cmbProveedor.Items.Count = 0 Then
                cmbProveedor.Entidad = New Proveedores
                cmbProveedor.CargarEntidad()
            End If

            For h As Integer = 0 To 49
                Me.OrdenCompar.ListaDetalle.Add(New DetalleOrdenCompra())
            Next

            Grid.DataSource = Me.OrdenCompar.ListaDetalle
        Else

            Grid.BotonBuscar = False
            Grid.BotonEliminar = False

            If cmbProveedor.Items.Count Then
                cmbProveedor.Entidad = New Proveedores
                cmbProveedor.IncializarCarga()

            End If

            cmbProveedor.SelectedValue = Me.OrdenCompar.idproveedor

            cmbProveedor.SelectedValue = Me.OrdenCompar.idproveedor

            Me.OrdenCompar.CargarDetalle()
            Grid.DataSource = Me.OrdenCompar.ListaDetalle


        End If
    End Sub

    Private Sub frmOrdenesCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PanelAccion1.BotonEliminar.Visible = False
        Me.PanelAccion1.BotonGuardar.Enabled = False
        Me.PanelAccion1.BotonImprimir.Enabled = False

        Me.Grid.DarFormato("codigo", "Código", True)
        Me.Grid.DarFormato("descripcion", "Descripción", True)
        Me.Grid.DarFormato("CantidadEditable", "Cantidad", True)
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.OrdenCompar = New OrdenCompra
    End Sub
    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir

    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar

    End Sub
    Private Sub cmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedor.SelectedIndexChanged
        If Not cmbProveedor.SelectedItem Is Nothing Then
            Dim p As Proveedores = cmbProveedor.SelectedItem
            Dim pn As New PersonaNatural
            pn.Id = p.IdContacto
            txtContacto.Text = pn.NombreCompletoMostrar
            txtCorreoContacto.Text = pn.correo
            txtTelefonoContacto.Text = pn.telefono.ToString
            txtTelefonoProveedor.Text = p.PersonaJuridica.telefono.ToString
            txtCorreoProveedor.Text = p.PersonaJuridica.correo

        Else
            limpiar(GroupBox3)
            limpiar(GroupBox2)
        End If
    End Sub

#End Region






End Class
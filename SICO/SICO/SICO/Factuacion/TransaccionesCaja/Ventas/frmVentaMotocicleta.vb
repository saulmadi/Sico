Imports SICO.ctrla2
Imports SICO.ctrla
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmVentaMotocicleta
#Region "Declaraciones"
    Private WithEvents _factura As New FacturaEncabezado
#End Region

#Region "Propiedades"
    Public Property Factura() As FacturaEncabezado
        Get
            Return _factura
        End Get
        Set(ByVal value As FacturaEncabezado)
            _factura = value
            CargarEntidad()
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Sub CargarEntidad()
        If cmbTiposFacturas.Items.Count = 0 Then
            cmbTiposFacturas.Entidad = New TiposFacturas
            cmbTiposFacturas.ColeccionParametros.Add(New ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
            cmbTiposFacturas.IncializarCarga()

        End If
        If Factura.Id = 0 Then
            Factura.Motocicleta = New Motocicletas
        Else

        End If
    End Sub

    Private Sub calculartotales()
        Factura.CalcularValoreMotocicleta()
        txtSubtotal.Text = Factura.subtotal.ToString("#######0.00")
        txtDescuento.Text = Factura.descuentovalor.ToString("#########0.00")
        txtImpuesto.Text = Factura.isv.ToString("########0.00")
        txtTotal.Text = Factura.total.ToString("########0.00")
    End Sub
#End Region

#Region "Eventos"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New ctrla2.frmBusquedaMotocileta
        If frm.ShowDialog() = DialogResult.OK Then
            Factura.Motocicleta = frm.Entidad

        End If

    End Sub

    Private Sub frmVentaMotocicleta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbMarca.Entidad = New Marcas
        Me.cmbModelo.Entidad = New Modelos
        Me.cmbTipoMotocicleta.Entidad = New TiposMotocicletas

        Me.cmbMarca.IncializarCarga()
        Me.cmbModelo.IncializarCarga()
        Me.cmbTipoMotocicleta.IncializarCarga()

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
        Else
            txtMotor.Clear()
            txtChasis.Clear()
            txtCilindraje.Clear()
            txtAnio.Clear()
            cmbMarca.SelectedIndex = -1
            cmbModelo.SelectedIndex = -1
            cmbTipoMotocicleta.SelectedIndex = -1
            txtPrecioVenta.Text = "0.00"
        End If
    End Sub

    Private Sub chkVentaExcenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVentaExcenta.CheckedChanged
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

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Eliminar

    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar

    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir

    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Factura = New FacturaEncabezado
    End Sub

    Private Sub txtDescuentoPor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescuentoPor.TextChanged
        If txtDescuentoPor.Text <> String.Empty Then
            Me.Factura.descuento = txtDescuentoPor.Text
        Else
            Me.Factura.descuento = 0
        End If
        calculartotales()
    End Sub

    Private Sub txtPrecioVenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrecioVenta.TextChanged
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
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmMotociletas
#Region "Declaraciones"
    Private _mototicletas As Motocicletas
#End Region

#Region "Propidades"
    Public Property Motocicletas() As Motocicletas
        Get
            Return _mototicletas
        End Get
        Set(ByVal value As Motocicletas)
            _mototicletas = value
            CargarEntidad()
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Sub limpiar(ByVal crt As Control)
        Try
            For Each i In crt.Controls
                Dim g As Control = CType(i, Control)
                limpiar(i)
                If TypeOf i Is TextBox Then
                    i.clear()
                End If
                If TypeOf i Is ComboBox Then
                    i.selectedvalue = -1
                End If
            Next
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub CargarEntidad()
        

        If Me.Motocicletas.Id = 0 Then
            limpiar(Me)
            
        Else
            If Me.cmbMarca.Items.Count = 0 Then
                cmbMarca.IncializarCarga()
            End If

            If Me.cmbProveedor.Items.Count = 0 Then
                cmbProveedor.IncializarCarga()
            End If

            If Me.cmbSucursales.Items.Count = 0 Then
                cmbSucursales.Inicialiazar()
            End If

            If Me.cmbTipoMotocicleta.Items.Count = 0 Then
                cmbTipoMotocicleta.IncializarCarga()
            End If

            cmbMarca.SelectedValue = Motocicletas.idmarcas
            cmbProveedor.SelectedValue = Motocicletas.idProveedor
            cmbSucursales.SelectedValue = Motocicletas.idSucursales
            cmbTipoMotocicleta.SelectedValue = Motocicletas.idTiposMotocicletas
            cmbModelo.SelectedValue = Motocicletas.idmodelos


            txtMotor.Text = Motocicletas.Motor
            txtChasis.Text = Motocicletas.Chasis
            txtcilindraje.Text = Motocicletas.cilindraje
            txthp.Text = Motocicletas.HP
            txtanio.Text = Motocicletas.anio
            txtpreciocompra.Text = Motocicletas.preciocompra
            txtprecioventa.Text = Motocicletas.precioventa
            lblEstado.Text = Motocicletas.DescripcionEstado

        End If

    End Sub

#End Region

#Region "Eventos"
    Private Sub frmMotociletas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbMarca.Entidad = New Marcas
        Me.cmbModelo.Entidad = New Modelos
        Me.cmbProveedor.Entidad = New Proveedores
        Me.cmbTipoMotocicleta.Entidad = New TiposMotocicletas
        lblEstado.Text = ""

        cmbMarca.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))

        cmbModelo.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        cmbModelo.ListaDesplegablePadre = cmbMarca
        cmbModelo.ParametroBusquedaPadre = "idderivada"

        cmbTipoMotocicleta.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))

        If Me.cmbMarca.Items.Count = 0 Then
            cmbMarca.CargarParametros()
        End If

        If Me.cmbProveedor.Items.Count = 0 Then
            cmbProveedor.CargarParametros()
        End If

        If Me.cmbSucursales.Items.Count = 0 Then
            cmbSucursales.Inicialiazar()
        End If

        If Me.cmbTipoMotocicleta.Items.Count = 0 Then
            cmbTipoMotocicleta.CargarParametros()
        End If

        Me.PanelAccion1.BotonImprimir.Visible = False
        Me.PanelAccion1.BotonEliminar.Visible = False

    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar

    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Motocicletas = New Motocicletas
    End Sub
#End Region

    
End Class
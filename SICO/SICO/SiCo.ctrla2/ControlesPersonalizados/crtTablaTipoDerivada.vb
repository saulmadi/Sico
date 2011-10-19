Imports System.ComponentModel
Imports SiCo.lgla2

Public Class crtTablaTipoDerivada
    Inherits crtTablaTipo

#Region "Declaraciones"

    Private _tablatipoDerivada As TablasTipo
    Private _ModuloTipoDerivado As ModulosTablasTipo = ModulosTablasTipo.Departamentos
    Private _NombreModulo As NombresModuloTablasTipo = New NombresModuloTablasTipo (_ModuloTipoDerivado)

#End Region

#Region "Propiedades"

    Public Property TituloDerivado() As String
        Get
            Return lblDerivado.Text
        End Get
        Set (ByVal value As String)
            lblDerivado.Text = value
        End Set
    End Property

    <DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)> _
    Public Property TablaTipoDerivada() As TablasTipo
        Get
            Return _tablatipoDerivada
        End Get
        Set (ByVal value As TablasTipo)
            _tablatipoDerivada = value
            cmbDerivado.Entidad = value
        End Set
    End Property

    <DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)> _
    Public Property ModuloDerivado() As ModulosTablasTipo
        Get
            Return _ModuloTipoDerivado
        End Get
        Set (ByVal value As ModulosTablasTipo)
            _ModuloTipoDerivado = value
            _NombreModulo.ModuloTablaTipo = value
            cmbDerivado.Entidad = _NombreModulo.Instancias
        End Set
    End Property

#End Region

#Region "Metodos"

    Protected Overrides Sub Guardar()
        If Not cmbDerivado.SelectedItem Is Nothing Then
            Dim tpd As TablasTipoDerivadas = Me.TablaTipo
            tpd.idDerivada = CType (cmbDerivado.SelectedItem, TablasTipo).Id
            MyBase.Guardar()
            cmbDerivado.SelectedIndex = - 1
        Else
            PanelAccion.lblEstado.Text = "Debe seleccionar un/una " + _
                                         NombresModuloTablasTipo.NombreModuloTablasTipo (Me.ModuloDerivado).ToLower
        End If
    End Sub

#End Region

#Region "Eventos"

    Private Sub crtBusqueda_SeleccionItem (ByVal Item As Object) Handles crtBusqueda.SeleccionItem
        cmbDerivado.SelectedValue = CType (Item, TablasTipoDerivadas).idDerivada
    End Sub

    Private Sub crtTablaTipoDerivada_Load (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        cmbDerivado.DisplayMember = "descripcion"
        cmbDerivado.ValueMember = "id"
        cmbDerivado.CargarEntidad()
        Me.TipoControl = TipoControl.TablaTipoDerivada
    End Sub

    Private Sub crtBusqueda_Limpio() Handles crtBusqueda.Limpio
        cmbDerivado.SelectedIndex = - 1
    End Sub

    Private Sub PanelAccion_Nuevo() Handles PanelAccion.Nuevo
        cmbDerivado.SelectedIndex = - 1
    End Sub

#End Region
End Class

Imports SiCo.lgla
Imports SiCo.lgla2
Imports System.Diagnostics
Imports System.ComponentModel
Public Class crtTablaTipo

#Region "Declaraciones"
    Private WithEvents _TalaTipo As TablasTipo
    Protected _Modulo As ModulosTablasTipo = ModulosTablasTipo.Departamentos
    Protected _Nombre As New NombresModuloTablasTipo(_Modulo)
    Protected _TipoControl As TipoControl = TipoControl.TablaTipo
    Public Event CambioTablaTipo()
    Public Event GuardoCorrectamente()
#End Region

#Region "Constructores"
    

#End Region

#Region "Propiedades"

    Public Property Titulo() As String
        Get
            Return PanelAccion.Titulo
        End Get
        Set(ByVal value As String)
            PanelAccion.Titulo = value
        End Set
    End Property

    Public Property CaracterinicioBusqueda() As Integer
        Get
            Return crtBusqueda.CaracteresInicioBusqueda
        End Get
        Set(ByVal value As Integer)
            crtBusqueda.CaracteresInicioBusqueda = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property TablaTipo() As TablasTipo
        Get
            Return _TalaTipo
        End Get

        Set(ByVal value As TablasTipo)
            _TalaTipo = value

            RaiseEvent CambioTablaTipo()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Modulo() As ModulosTablasTipo

        Get
            Return _Modulo
        End Get

        Set(ByVal value As ModulosTablasTipo)
            _Modulo = value
            Try
                _Nombre.ModuloTablaTipo = value
                crtBusqueda.Entidad = _Nombre.Instancias
                TablaTipo = _Nombre.Instancias
            Catch ex As Exception

            End Try

        End Set

    End Property

    Protected Property TipoControl() As TipoControl
        Get
            Return _TipoControl
        End Get
        Set(ByVal value As TipoControl)
            _TipoControl = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Protected Overridable Sub Guardar()
        Try
            Dim val As New SiCo.ctrla.Validador()
            Dim flag As Boolean = True
            If Me.TablaTipo.Id > 0 Then
                Select Case MessageBox.Show("Es seguro de modificar el/la " + _Nombre.Nombre.ToLower + " " + Me.TablaTipo.descripcion + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.No
                        flag = False
                End Select
            End If
            val.ColecionCajasTexto.Add(txtDescripcion)
            If val.PermitirIngresar And flag Then
                PanelAccion.BarraProgreso.Value = 50
                PanelAccion.lblEstado.Text = "Guardando...."
                Me.Cursor = Cursors.WaitCursor
                Me.TablaTipo.descripcion = txtDescripcion.Texto
                Me.TablaTipo.habilitado = CType(cmbEstado.SelectedItem, Estado).valor

                Me.TablaTipo.Guardar()
                RaiseEvent GuardoCorrectamente()
                PanelAccion.lblEstado.Text = Me._Nombre.Nombre + " " + Me.TablaTipo.descripcion + " guardado(a) correctamente."
                Me.TablaTipo = _Nombre.Instancias
                txtDescripcion.Focus()
                PanelAccion.BarraProgreso.Value = 100
                Me.Cursor = Cursors.Default

            Else
                PanelAccion.lblEstado.Text = val.MensajesError
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion.lblEstado.Text = "Error guardando"
            PanelAccion.BarraProgreso.Value = 0
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Protected Overridable Sub Eliminar()
        Try
            Me.TablaTipo.Eliminar()
            Me.TablaTipo = _Nombre.Instancias
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Eventos"

    Private Sub crtBusqueda_Limpio() Handles crtBusqueda.Limpio
        If Me.TablaTipo.Id > 0 Then
            Me.TablaTipo = Me._Nombre.Instancias
        End If

    End Sub

    Private Sub crtBusqueda_SeleccionItem(ByVal Item As System.Object) Handles crtBusqueda.SeleccionItem
        Me.TablaTipo = Item
    End Sub

    Protected Overridable Sub PanelAccion_Guardar() Handles PanelAccion.Guardar
        Guardar()
    End Sub

    Private Sub PanelAccion_Nuevo() Handles PanelAccion.Nuevo
        Me.TablaTipo = _Nombre.Instancias
        txtDescripcion.Focus()
    End Sub

    Private Sub crtTablaTipo_CambioTablaTipo() Handles Me.CambioTablaTipo
        If Not Me.TablaTipo Is Nothing Then
            txtDescripcion.Text = Me.TablaTipo.descripcion
            cmbEstado.SelectedIndex = Me.TablaTipo.habilitado
        End If
        
    End Sub

    Private Sub crtTablaTipo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        crtBusqueda.NombreParametroBusqueda = "descripcion"
        _TalaTipo = TablaTipo
        crtBusqueda.CampoAMostrar = "descripcion"
        Me.PanelAccion.BotonImprimir.Enabled = False
        Me.PanelAccion.BotonImprimir.Visible = False

    End Sub

    Private Sub PanelAccion_Eliminar() Handles PanelAccion.Eliminar
        Eliminar()
    End Sub
#End Region
End Class
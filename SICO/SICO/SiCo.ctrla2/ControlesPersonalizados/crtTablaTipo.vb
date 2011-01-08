Imports SiCo.lgla
Imports SiCo.lgla2
Public Class crtTablaTipo

#Region "Declaraciones"
    Private WithEvents _TalaTipo As TablasTipo

    Public Event CambioTablaTipo()
#End Region

#Region "Constructores"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        crtBusqueda.NombreParametroBusqueda = "descripcion"
        _TalaTipo = TablaTipo
        crtBusqueda.CampoAMostrar = "descripcion"

        Dim list As New List(Of Estado)
        list.Add(New Estado("In Habilitado", 0))
        list.Add(New Estado("Habilitado", 1))

        cmbEstado.DataSource = list
        cmbEstado.DisplayMember = "Descripcion"
        cmbEstado.ValueMember = "Valor"
    End Sub

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

    Public Property TablaTipo() As TablasTipo
        Get
            Return _TalaTipo
        End Get
        Set(ByVal value As TablasTipo)
            _TalaTipo = value
            RaiseEvent CambioTablaTipo()
        End Set
    End Property

#End Region

#Region "Eventos"
    Private Sub crtBusqueda_SeleccionItem(ByVal Item As System.Object) Handles crtBusqueda.SeleccionItem
        Me.TablaTipo = Item
    End Sub

    Private Sub PanelAccion_Guardar() Handles PanelAccion.Guardar
        Dim val As New SiCo.ctrla.Validador()
        val.ColecionCajasTexto.Add(txtDescripcion)
        If val.PermitirIngresar Then
            PanelAccion.BarraProgreso.Value = 50
            PanelAccion.lblEstado.Text = "Guardando...."
            Me.Cursor = Cursors.WaitCursor
            Me.TablaTipo.descripcion = txtDescripcion.Texto
            Me.TablaTipo.habilitado = cmbEstado.SelectedValue
            Me.TablaTipo.Guardar()
            PanelAccion.lblEstado.Text = "Listo"
            PanelAccion.BarraProgreso.Value = 100
            Me.Cursor = Cursors.Default
        Else
            PanelAccion.lblEstado.Text = val.MensajesError
        End If


    End Sub

    Private Sub PanelAccion_Nuevo() Handles PanelAccion.Nuevo

        If TablaTipo.GetType.FullName = "SiCo.lgla2.Departamentos" Then
            Me.TablaTipo = New Departamentos
        ElseIf TablaTipo.GetType Is System.Type.GetType("Marcas") Then
            Me.TablaTipo = New Marcas
        Else
            Throw New ApplicationException("No se puedo incializar la Tabla")
        End If



    End Sub

    Private Sub crtTablaTipo_CambioTablaTipo() Handles Me.CambioTablaTipo
        txtDescripcion.Text = Me.TablaTipo.descripcion
        cmbEstado.SelectedValue = Me.TablaTipo.habilitado
    End Sub

    Private Sub crtTablaTipo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PanelAccion.BotonImprimir.Enabled = False
        Me.PanelAccion.BotonImprimir.Visible = False

    End Sub
#End Region
 
End Class

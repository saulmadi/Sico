Public Class frmMarcas

#Region "Contructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler Me.crtTablaTipo1.PanelAccion.Cancelar, AddressOf Me.Cancelar
        Me.AcceptButton = Me.crtTablaTipo1.PanelAccion.BotonGuardar
        Me.CancelButton = Me.crtTablaTipo1.PanelAccion.BotonCancelar
    End Sub
#End Region

#Region "Eventos"
    Private Sub Cancelar()
        Me.Close()
    End Sub

    Private Sub frmDepartamentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim marca As New SICO.lgla2.Marcas
        crtTablaTipo1.TablaTipo = marca
        crtTablaTipo1.Modulo = lgla2.ModulosTablasTipo.Marcas
        crtTablaTipo1.crtBusqueda.Entidad = marca
        crtTablaTipo1.crtBusqueda.CargarTodo()
    End Sub
#End Region

End Class
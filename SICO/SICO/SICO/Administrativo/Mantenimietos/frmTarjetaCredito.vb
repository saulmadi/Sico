Public Class frmTarjetaCredito


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
        Dim tarjeta As New SICO.lgla2.TarjetaCredito
        crtTablaTipo1.TablaTipo = tarjeta
        crtTablaTipo1.Modulo = lgla2.ModulosTablasTipo.TarjetaCredito
        crtTablaTipo1.crtBusqueda.Entidad = tarjeta
        crtTablaTipo1.crtBusqueda.CargarTodo()
    End Sub
#End Region

End Class
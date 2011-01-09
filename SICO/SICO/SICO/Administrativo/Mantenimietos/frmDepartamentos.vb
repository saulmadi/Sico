Imports SICO.ctrla
Imports SICO.ctrla2
Public Class frmDepartamentos
    Dim Departamento As New SICO.lgla2.Departamentos

#Region "Contructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler Me.CrtTablaTipo1.PanelAccion.Cancelar, AddressOf Me.Cancelar
        Me.AcceptButton = Me.CrtTablaTipo1.PanelAccion.BotonGuardar
        Me.CancelButton = Me.CrtTablaTipo1.PanelAccion.BotonCancelar
    End Sub
#End Region

#Region "Eventos"
    Private Sub Cancelar()
        Me.Close()
    End Sub
    Private Sub frmDepartamentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrtTablaTipo1.TablaTipo = Departamento
        CrtTablaTipo1.crtBusqueda.Entidad = (Departamento)
        CrtTablaTipo1.crtBusqueda.CargarTodo()
    End Sub
#End Region
    
End Class
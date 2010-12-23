Public Class frmMarcas
#Region "Constructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.TablaTipo.PanelAccion.Titulo = "Marcas"
        AddHandler Me.TablaTipo.PanelAccion.Cancelar, AddressOf Cancelar
    End Sub
#End Region

#Region "eventos"
    Private Sub Cancelar()
        Me.Close()
    End Sub
#End Region
    
End Class
Public Class frmTiposMotocicletas

#Region "Constructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        AddHandler Me.CrtTablaTipo.PanelAccion.Cancelar, AddressOf Me.Cancelar

    End Sub
#End Region

#Region "Eventos"
    Private Sub Cancelar()
        Me.Close()
    End Sub
#End Region


End Class
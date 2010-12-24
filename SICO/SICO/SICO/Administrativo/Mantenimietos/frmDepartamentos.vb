Public Class frmDepartamentos
#Region "Contructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        AddHandler Me.CrtTablaTipo1.PanelAccion.Cancelar, AddressOf Me.Cancelar

    End Sub
#End Region

#Region "Eventos"
    Private Sub Cancelar()
        Me.Close()
    End Sub
#End Region

End Class
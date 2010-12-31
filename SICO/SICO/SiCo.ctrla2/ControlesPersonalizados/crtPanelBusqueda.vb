Public Class crtPanelBusqueda

    Public Event Nuevo()
    Public ReadOnly Property GridResultados() As SiCo.ctrla.Grid
        Get
            Return _GridResultados
        End Get

    End Property
    Public ReadOnly Property BarraHerramientas() As ToolStrip
        Get
            Return _BarraHerramientas
        End Get
    End Property

    Public ReadOnly Property SeccionParametros() As GroupBox
        Get
            Return _seccionParametros
        End Get
    End Property

    Private Sub NuevoToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoToolStripButton.Click
        RaiseEvent Nuevo()
    End Sub
End Class

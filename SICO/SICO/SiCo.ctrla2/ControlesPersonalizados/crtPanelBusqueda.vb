Imports SiCo.lgla

Public Class crtPanelBusqueda
#Region "Declaraciones"
    Private WithEvents _Entidad As Entidad

    Public Event Nuevo()
    Public Event Imprimir()
    Public Event Buscar()
    Public Event Editar()
    Public Event Eliminar()
#End Region

#Region "Propiedades"
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

    Public Property Entidad() As Entidad
        Get
            Return _Entidad
        End Get
        Set(ByVal value As Entidad)
            _Entidad = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Public Sub Cargar(ByVal ColeccionParametros As List(Of SiCo.lgla.Parametro))
        Try
            Me.GridResultados.DataSource = Nothing

            Me.Entidad.Buscar(ColeccionParametros)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub cargar(ByVal Parametro As String, ByVal valorBusqueda As String)
        Try
            Me.GridResultados.DataSource = Nothing
            Me.Entidad.Buscar(Parametro, valorBusqueda)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Eventos"
    Private Sub NuevoToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NuevoToolStripButton.Click
        RaiseEvent Nuevo()
    End Sub

    Private Sub _Entidad_CargoTabla() Handles _Entidad.CargoTabla
        Me.GridResultados.DataSource = Nothing
        If Entidad.TotalRegistros > 0 Then
            Me.GridResultados.DataSource = Entidad.TablaAColeccion
        End If
    End Sub

    Private Sub ImprimirToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripButton.Click
        RaiseEvent Imprimir()
    End Sub


    Private Sub _GridResultados_Editar(ByVal EditarArg As ctrla.GridEditarEventArg) Handles _GridResultados.Editar
        RaiseEvent Editar()
    End Sub

    Private Sub _GridResultados_Buscar() Handles _GridResultados.Buscar
        RaiseEvent Buscar()
    End Sub

    Private Sub _GridResultados_Eliminar(ByVal EliminarArg As ctrla.GridEliminarEventArg) Handles _GridResultados.Eliminar
        RaiseEvent Eliminar()
    End Sub
#End Region

End Class

Imports SiCo.lgla
Public Class frmBusqueda
#Region "Declaraciones"
    Private WithEvents _entidad As SiCo.lgla.Entidad
#End Region

#Region "constructor"
    Public Sub New(ByVal Entdiad As Entidad)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.Entidad = Entdiad
    End Sub
#End Region

#Region "Propiedades"

    Public Property Entidad() As Entidad

        Get
            Return _entidad
        End Get

        Set(ByVal value As Entidad)
            _entidad = value
        End Set

    End Property

    Public Property Grid() As SiCo.ctrla.Grid
        Get
            Return grdbusqueda
        End Get

        Set(ByVal value As SiCo.ctrla.Grid)
            grdbusqueda = value
        End Set
    End Property

    Public Property VerParametros() As Boolean
        Get
            Return panelparametros.Visible
        End Get
        Set(ByVal value As Boolean)
            panelparametros.Visible = value
        End Set
    End Property

#End Region

#Region "Metodos"
    Public Sub cargar(ByVal Parametros As List(Of SiCo.lgla.Parametro))
        Try
            btnAceptar.Enabled = False
            Me.Entidad.Buscar(Parametros)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub cargar(ByVal Parametro As String, ByVal valorBusqueda As String)
        Try
            Me.Entidad.Buscar(Parametro, valorBusqueda)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Eventos"

    Private Sub _entidad_CargoTabla() Handles _entidad.CargoTabla
        Me.Grid.DataMember = Nothing
        If Entidad.TotalRegistros > 0 Then
            grdbusqueda.DataSource = Entidad.TablaAColeccion
            btnAceptar.Enabled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
        Me.Entidad = Grid.Item()
    End Sub

#End Region
End Class
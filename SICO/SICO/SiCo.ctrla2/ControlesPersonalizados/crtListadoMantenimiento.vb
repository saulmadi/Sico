Imports System.ComponentModel
Imports SiCo.lgla

Public Class crtListadoMantenimiento

#Region "Declaraciones"

    Private WithEvents _Entidad As Entidad
    Private _CaracteresInicioBusqueda As Integer = 3
    Private _NombreParametroBusqueda As String
    Private _CampoAMostrar As String
    Private _UltimoParametro As String
    Private _CaracteresSegundaBusqueda As Integer = 6
    Private _CargarInicio As Boolean = False

    Public Event SeleccionItem (ByVal Item As Object)
    Public Event Limpio()

#End Region

#Region "Constructor"

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#End Region

#Region "Propiedades"

    <Browsable (False), EditorBrowsable (EditorBrowsableState.Advanced), _
        DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)> _
    Public Property Entidad() As Entidad
        Get
            Return _Entidad
        End Get
        Set (ByVal value As Entidad)
            _Entidad = value
        End Set
    End Property

    Public Property CaracteresInicioBusqueda() As Integer
        Get
            Return _CaracteresInicioBusqueda
        End Get
        Set (ByVal value As Integer)
            _CaracteresInicioBusqueda = value
        End Set
    End Property

    Public Property NombreParametroBusqueda() As String
        Get
            Return _NombreParametroBusqueda
        End Get
        Set (ByVal value As String)
            _NombreParametroBusqueda = value
        End Set
    End Property

    Public Property CampoAMostrar() As String
        Get
            Return _CampoAMostrar
        End Get
        Set (ByVal value As String)
            _CampoAMostrar = value
            lstBusqueda.DisplayMember = value
        End Set
    End Property

    Public Property CaracteresSegundaBusqueda() As Integer
        Get
            Return _CaracteresSegundaBusqueda
        End Get
        Set (ByVal value As Integer)
            If value > Me.CaracteresInicioBusqueda Then
                _CaracteresSegundaBusqueda = value
            Else
                Throw _
                    New ApplicationException ("El valor de la sugunda busqueda no puede ser mayor que la de la inicio")
            End If
        End Set
    End Property

    Public Property CargarInicio() As Boolean
        Get
            Return _CargarInicio
        End Get
        Set (ByVal value As Boolean)
            _CargarInicio = value
        End Set
    End Property

#End Region

#Region "Eventos"

    Private Sub txtBusqueda_KeyPress (ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtBusqueda.KeyPress
        If Asc (e.KeyChar) = 13 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged (ByVal sender As Object, ByVal e As EventArgs) Handles txtBusqueda.TextChanged
        If _
            (Me.txtBusqueda.Text.Length = Me.CaracteresInicioBusqueda Or _
             Me.CaracteresSegundaBusqueda = txtBusqueda.Text.Length) And _UltimoParametro <> txtBusqueda.Text Then
            lanzarbusqueda (txtBusqueda.Text)
            _UltimoParametro = txtBusqueda.Text
        ElseIf txtBusqueda.Text.Length < Me.CaracteresInicioBusqueda Then
            _UltimoParametro = "12"
            lstBusqueda.DataSource = Nothing
        End If
    End Sub

    Private Sub subproceso_DoWork (ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles subproceso.DoWork
        Dim a As Argumento = CType (e.Argument, Argumento)
        a.entidad.Buscar (a.Parametro, a.texto)
    End Sub

    Private Sub subproceso_RunWorkerCompleted (ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
        Handles subproceso.RunWorkerCompleted
        Me.Cursor = Cursors.Default
        If e.Error Is Nothing Then
            Me.lstBusqueda.DataSource = _Entidad.TablaAColeccion
        Else
            MessageBox.Show (e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub _Entidad_Errores (ByVal Mensaje As String) Handles _Entidad.Errores
        MessageBox.Show (Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub lstBusqueda_DataSourceChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles lstBusqueda.DataSourceChanged
        If lstBusqueda.DataSource Is Nothing Then
            RaiseEvent Limpio()
        End If
    End Sub

    Private Sub lstBusqueda_DoubleClick (ByVal sender As Object, ByVal e As EventArgs) Handles lstBusqueda.DoubleClick
        RaiseEvent SeleccionItem (lstBusqueda.SelectedItem)
    End Sub

    Private Sub crtListadoMantenimiento_Load (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Entidad Is Nothing Then
            Entidad.Buscar()
            If Entidad.TotalRegistros > 0 Then
                lstBusqueda.DataSource = Nothing
                lstBusqueda.DataSource = Entidad.TablaAColeccion
                lstBusqueda.DisplayMember = Me.CampoAMostrar
            End If

        End If
    End Sub

    Private Sub lstBusqueda_SelectedIndexChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles lstBusqueda.SelectedIndexChanged

        If Not lstBusqueda.SelectedItem Is Nothing Then
            RaiseEvent SeleccionItem (lstBusqueda.SelectedItem)
        End If


    End Sub

#End Region

#Region "Metodos"

    Private Sub lanzarbusqueda (ByVal texto As String)
        If Not Entidad Is Nothing Then

            If Not Me.subproceso.IsBusy Then
                Dim c As New Argumento (Entidad)
                c.entidad = Me.Entidad
                c.Parametro = Me.NombreParametroBusqueda
                c.texto = texto
                Me.Cursor = Cursors.WaitCursor
                Me.lstBusqueda.DataSource = Nothing
                Me.lstBusqueda.DisplayMember = Me.CampoAMostrar
                Me.subproceso.RunWorkerAsync (c)

            End If
        End If

    End Sub

    Public Sub CargarTodo()
        lanzarbusqueda (Nothing)
    End Sub

#End Region

#Region "Clase del Argumento"

    Private Class Argumento
        Public Parametro As String
        Public entidad As Entidad
        Public texto As String

        Public Sub New (ByVal entida As Entidad)

        End Sub
    End Class

#End Region
End Class

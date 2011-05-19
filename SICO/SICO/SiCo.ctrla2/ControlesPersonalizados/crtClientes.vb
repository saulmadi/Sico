Imports SiCo.lgla
Imports SiCo.lgla2
Imports System.ComponentModel
Imports System.Diagnostics

Public Class crtClientes

#Region "Declaraciones"
    Private WithEvents _cliente As Clientes
   
    Private _CargarClientePorPersona As Boolean = False
    Private _premitebloquear As Boolean = True
    Private _size As Size
#End Region

#Region "Constructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.VisibleDatosSecundarios = True
        Me.Size = New Size(Me.Size)

    End Sub
#End Region

#Region "Propiedades"
    <Browsable(False), EditorBrowsableAttribute(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Cliente() As Clientes
        Get
            Return _cliente
        End Get

        Set(ByVal value As Clientes)
            _cliente = value
            Me._premitebloquear = False
            CrtPersonaJuridica1.Persona = New PersonaJuridica
            CrtPersonaNatural1.Persona = New PersonaNatural
            If Me.Cliente.Id > 0 Then
                If Not _cliente.PersonaJuridica Is Nothing Then
                    CrtPersonaJuridica1.Persona = value.PersonaJuridica
                    CrtPersonaNatural1.Persona = New PersonaNatural
                    TabControl1.SelectedIndex = 1
                ElseIf Not _cliente.PersonaNatural Is Nothing Then
                    CrtPersonaJuridica1.Persona = New PersonaJuridica
                    CrtPersonaNatural1.Persona = value.PersonaNatural
                    TabControl1.SelectedIndex = 0
                Else
                    CrtPersonaJuridica1.Nuevo()
                    CrtPersonaNatural1.Nuevo()
                    TabControl1.SelectedIndex = 0
                End If
            Else
                CrtPersonaJuridica1.Persona = New PersonaJuridica
                CrtPersonaNatural1.Persona = New PersonaNatural
                TabControl1.SelectedIndex = 0
            End If
            Me._premitebloquear = True
        End Set
    End Property

    Public Property CargarClientePorPersona() As Boolean
        Get
            Return _CargarClientePorPersona
        End Get
        Set(ByVal value As Boolean)
            _CargarClientePorPersona = value
        End Set
    End Property

    <Browsable(True), EditorBrowsableAttribute(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ControlPersonaNatural() As crtPersonaNatural
        Get
            Return CrtPersonaNatural1
        End Get
    End Property

    <Browsable(True), EditorBrowsableAttribute(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ControlPersonaJuridicas() As crtPersonaJuridica
        Get
            Return CrtPersonaJuridica1
        End Get
    End Property

    Public Property VisibleDatosSecundarios() As Boolean
        Get
            Return CrtPersonaNatural1.VisibleDatosSecundarios
        End Get
        Set(ByVal value As Boolean)
            CrtPersonaNatural1.VisibleDatosSecundarios = value
            CrtPersonaJuridica1.VisiblesDatosSecundarios = value
            Me.Size = New Size(Me.Width, CrtPersonaNatural1.Size.Height + 20)
            'If Not value Then
            '    If Me.CrtPersonaJuridica1.Size.Height > System.Drawing.Size.Subtract(Me.Size, CrtPersonaNatural1.Size).Height Then
            '        Me.Size = New Size(Me.Width, CrtPersonaNatural1.Size.Height + 20)
            '        Me.TabControl1.Size = New Size(Me.TabControl1.Width, System.Drawing.Size.Subtract(Me.TabControl1.Size, CrtPersonaNatural1.Size).Height)
            '    Else
            '        Me.Size = New Size(Me.Width, Me.CrtPersonaNatural1.Size.Height + 20)
            '        Me.TabControl1.Size = New Size(Me.Width, Me.CrtPersonaNatural1.Size.Height + 20)
            '    End If

            'Else
            '    If Me.CrtPersonaJuridica1.Size.Height < System.Drawing.Size.Subtract(Me.Size, CrtPersonaNatural1.Size).Height Then
            '        Me.Size = New Size(Me.Width, System.Drawing.Size.Add(Me.Size, CrtPersonaNatural1.Size).Height)
            '        Me.TabControl1.Size = New Size(Me.TabControl1.Width, System.Drawing.Size.Add(Me.TabControl1.Size, CrtPersonaNatural1.Size).Height)
            '    Else
            '        Me.Size = New Size(Me.Width, Me.CrtPersonaNatural1.Size.Height + 20)
            '        Me.TabControl1.Size = New Size(Me.Width, Me.CrtPersonaNatural1.Size.Height + 20)
            '    End If


            'End If
        End Set
    End Property
#End Region

#Region "Metodos"

    Public Function Guardar() As Long
        Try
            If TabControl1.SelectedIndex = 0 Then
                Me.Cliente.idEntidades = Me.CrtPersonaNatural1.Guardar()
            Else
                Me.Cliente.idEntidades = Me.CrtPersonaJuridica1.Guardar
            End If
            If Me.Cliente.idEntidades > 0 Then
                Dim ident As Integer = Me.Cliente.idEntidades
                Me.Cliente.Buscar("identidades", Me.Cliente.idEntidades.ToString)
                If Me.Cliente.TotalRegistros = 0 Then
                    _cliente = New Clientes
                End If

                Me.Cliente.idEntidades = ident
                Me.Cliente.Guardar()
            End If
            Return Cliente.Id
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
    End Function

    Public Sub Nuevo()
        Me.Cliente = New Clientes
        Me.CrtPersonaJuridica1.Nuevo()
        Me.CrtPersonaNatural1.Nuevo()
        Me.TabControl1.SelectedIndex = 0
    End Sub

#End Region

#Region "Eventos"
    Private Sub _cliente_CambioId() Handles _cliente.CambioId, CrtPersonaJuridica1.CambioPersona, CrtPersonaNatural1.CambioPersona
        If Me.CargarClientePorPersona Then
            If TabControl1.SelectedIndex = 0 Then
                If CrtPersonaNatural1.Persona.Id > 0 Then
                    _cliente = New Clientes
                    _cliente.Buscar("identidades", CrtPersonaNatural1.Persona.Id)
                    If _cliente.TotalRegistros = 0 Then
                        _cliente = New Clientes
                    End If
                End If
            Else
                If CrtPersonaJuridica1.Persona.Id > 0 Then
                    _cliente = New Clientes
                    _cliente.Buscar("identidades", CrtPersonaJuridica1.Persona.Id)
                    If _cliente.TotalRegistros = 0 Then
                        _cliente = New Clientes
                    End If
                End If
            End If
        Else
            If Me.Cliente.TotalRegistros > 0 Then
                Me.Cliente = _cliente
            End If
        End If
    End Sub

    Private Sub crtClientes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _cliente = New Clientes
            _size = Me.Size
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If Me._premitebloquear Then
            If Me.Cliente.Id > 0 Then
                e.Cancel = True
                Exit Sub
            End If

            Select Case MessageBox.Show("¿Realmente desea cambiar de ficha? si cambia de ficha perdera la información actual.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case DialogResult.Yes
                    CrtPersonaJuridica1.Persona = New PersonaJuridica
                    CrtPersonaNatural1.Persona = New PersonaNatural
                Case Else
                    e.Cancel = True
            End Select
        End If


    End Sub
#End Region

End Class

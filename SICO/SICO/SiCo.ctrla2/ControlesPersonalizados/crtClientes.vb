Imports SiCo.lgla
Imports SiCo.lgla2
Imports System.ComponentModel
Imports System.Diagnostics

Public Class crtClientes

#Region "Declaraciones"
    Private WithEvents _cliente As New Clientes
   
    Private _CargarClientePorPersona As Boolean = False
#End Region

#Region "Constructor"

#End Region

#Region "Propiedades"
    <Browsable(False), EditorBrowsableAttribute(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property Cliente() As Clientes
        Get
            Return _cliente
        End Get
        Set(ByVal value As Clientes)
            _cliente = value
            If Not _cliente.PersonaJuridica Is Nothing Then
                CrtPersonaJuridica1.Persona = value.PersonaJuridica
                CrtPersonaNatural1.Persona = New PersonaNatural
            Else
                CrtPersonaJuridica1.Persona = value.PersonaJuridica
                CrtPersonaNatural1.Persona = New PersonaNatural
            End If
            If value.Id > 0 And Not Me.CargarClientePorPersona Then
                TabControl1.Enabled = False
            Else
                TabControl1.Enabled = True
            End If
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

    <Browsable(False), EditorBrowsableAttribute(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ControlPersonaNatural() As crtPersonaNatural
        Get
            Return CrtPersonaNatural1
        End Get
    End Property

    <Browsable(False), EditorBrowsableAttribute(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property ControlPersonaJuridicas() As crtPersonaJuridica
        Get
            Return CrtPersonaJuridica1
        End Get
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
    
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
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

    End Sub
#End Region
    
End Class

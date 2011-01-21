Imports SiCo.lgla
Imports System.ComponentModel
Imports System.Diagnostics
Public Class crtPersonaJuridica

#Region "Declaraciones"
    Private _Persona As PersonaJuridica
    Private _etiquetaError As New ToolStripStatusLabel
    Private _RealizarBusquedaPor As BusquedaPor
    Private _SoloLectura As Boolean = False
    Private _RealizarBusquedaAutomatica As Boolean = True

    Public Event CambioPersona()
#End Region

#Region "Propiedades"
    Public Property TextoRazonSocial() As String
        Get
            Return lblRazonSocial.Text
        End Get
        Set(ByVal value As String)
            lblRazonSocial.Text = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False), EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Property Persona() As PersonaJuridica
        Get
            Return _Persona
        End Get
        Set(ByVal value As PersonaJuridica)
            _Persona = value
            RaiseEvent CambioPersona()
        End Set
    End Property

    Public Property SoloLectura() As Boolean
        Get
            Return _SoloLectura
        End Get

        Set(ByVal value As Boolean)
            Try
                _SoloLectura = value
                
                txtrtn.ReadOnly = value
                txtCorreo.ReadOnly = value
                txttelefono.ReadOnly = value
                txtdireccion.ReadOnly = value
            Catch ex As Exception

            End Try

        End Set
    End Property

    Public Property RealizarBusquedaAutomarita() As Boolean
        Get
            Return _RealizarBusquedaAutomatica
        End Get
        Set(ByVal value As Boolean)
            _RealizarBusquedaAutomatica = value
        End Set
    End Property

#End Region

#Region "Metodos"
    Public Function Guardar() As Long


    End Function
#End Region

#Region "Eventos"

    Private Sub crtPersonaJuridica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblEstado.Text = ""
        Try
            _Persona = New PersonaJuridica
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click

    End Sub

    Private Sub txtNombre_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrtn.Leave, txtNombre.Leave

    End Sub

    Private Sub SubProceso_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SubProceso.DoWork

    End Sub

#End Region

#Region "ClaseArgumento"
    Private Class Argumento
        Public persona As New PersonaJuridica
        Public nombre As String
        Public lista As New List(Of SiCo.lgla.Parametro)
        Public Sub New(ByRef persona As PersonaJuridica, ByVal nombre As String)
            Me.persona = persona
            Me.nombre = nombre
        End Sub
        Public Sub New(ByRef persona As PersonaJuridica, ByRef lista As List(Of Parametro))
            Me.persona = persona
            Me.lista = lista
        End Sub
    End Class
#End Region

#Region "Enumerador"
    Protected Enum BusquedaPor
        RazonSocial = 0
        rtn = 1
        Nada = 2
    End Enum
#End Region

    
End Class

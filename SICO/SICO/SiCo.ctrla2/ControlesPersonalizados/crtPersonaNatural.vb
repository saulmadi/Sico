Imports SiCo.lgla
Imports SiCo.lgla2
Imports System.ComponentModel
Imports System.Diagnostics
<Serializable()> _
Public Class crtPersonaNatural

#Region "Declaraciones"
    <NonSerialized()> _
    Private WithEvents _PersonaNatural As PersonaNatural
#End Region

#Region "Propiedades"

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False), EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Property Persona() As PersonaNatural
        Get
            Return _PersonaNatural
        End Get

        Set(ByVal value As PersonaNatural)
            _PersonaNatural = value
        End Set
    End Property

#End Region

#Region "Metodos"

#End Region

#Region "Eventos"

    Private Sub crtPersonaNatural_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _PersonaNatural = New PersonaNatural
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ListaTipoIdentidad1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoIdentidad.SelectedIndexChanged
        If Not cmbTipoIdentidad.SelectedItem Is Nothing Then
            txtidentifiacion.TipoIdentificacion = cmbTipoIdentidad.SelectedItem
        End If
    End Sub

#End Region

End Class

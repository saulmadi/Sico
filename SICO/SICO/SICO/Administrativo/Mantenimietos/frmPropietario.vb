Imports SiCo.lgla
Imports SiCo.lgla2

Public Class frmPropietario
    Private _propietario As New Propietario

    Public Property Propietario() As Propietario
        Get
            Return _propietario
        End Get
        Set (ByVal value As Propietario)
            _propietario = value
        End Set
    End Property

    Private Sub frmPropietario_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            PanelAccion1.BotonImprimir.Visible = False
            PanelAccion1.BotonNuevo.Visible = False
            PanelAccion1.BotonEliminar.Visible = False
            Propietario.Buscar()
            If Propietario.TotalRegistros = 1 Then
                Dim p = New PersonaNatural()
                p.Id = Propietario.idEntidades
                CrtPersonaNatural1.Persona = p
            End If
        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim id = CrtPersonaNatural1.Guardar()

            If id > 0 Then
                Propietario.idEntidades = id
                Propietario.Guardar()
            End If


        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
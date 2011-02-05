Imports SICO.lgla2
Imports SICO.lgla
Public Class frmRegistroClientes
    Private _Cliente As New Clientes
    Public Property Cliente() As Clientes
        Get
            Return _Cliente
        End Get
        Set(ByVal value As Clientes)
            _Cliente = value
        End Set
    End Property

    Private Sub frmRegistroClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If Me.Cliente.Id > 0 Then
            e.Cancel = True
            Exit Sub
        End If

        Select Case MessageBox.Show("¿Esta seguro de cambiar ficha? si cambia de ficha perdera toda la información.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case Windows.Forms.DialogResult.Yes
                CrtPersonaJuridica1.Persona = New PersonaJuridica
                CrtPersonaNatural1.Persona = New PersonaNatural
            Case Else
                e.Cancel = True
        End Select
    End Sub
End Class
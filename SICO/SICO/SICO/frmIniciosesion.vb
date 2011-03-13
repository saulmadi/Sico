Public Class frmIniciosesion

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            

            Dim forma As New frmMenuPrincipal
            Dim u As New SICO.lgla.Usuario

            If txtcontrasena.Text.Trim.Length = 0 Or txtusuario.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese toda la infromación para iniciar sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtcontrasena.Text = ""
                txtusuario.Text = ""
                txtusuario.Focus()
                Exit Sub

            End If
            If u.Autenticar(txtusuario.Text.Trim, txtcontrasena.Text.Trim) Then
                u.Serializar()
                forma.Show()
                Me.Close()
            Else
                MessageBox.Show("Error al autenticar en el sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtcontrasena.Text = ""
                txtusuario.Text = ""
                txtusuario.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub btnconfig_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles btnconfig.LinkClicked
        Dim frm As New frmConfiguracionBDD
        frm.ShowDialog()

    End Sub
End Class

Imports SICO.lgla
Public Class frmIniciosesion
    Private _Autorizar As Boolean = False
    Private _Autorizo As Boolean = False
    Private _lista As New List(Of Parametro)
    Public Property Autorizar() As Boolean
        Get
            Return _Autorizar
        End Get
        Set(ByVal value As Boolean)
            _Autorizar = value
        End Set
    End Property
    Public Property Autorizo() As Boolean
        Get
            Return _Autorizo
        End Get
        Set(ByVal value As Boolean)
            _Autorizo = value
        End Set
    End Property

    Public Property Lista() As List(Of Parametro)
        Get
            Return _lista
        End Get
        Set(ByVal value As List(Of Parametro))
            _lista = value
        End Set
    End Property
    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try

            _Autorizo = False
            Dim forma As New frmMenuPrincipal
            Dim u As New SICO.lgla.Usuario
            Dim pa As New Parametro("idrol")
            If Autorizar Then
                pa = New Parametro("idrol", " >=4")
            End If
            If txtcontrasena.Text.Trim.Length = 0 Or txtusuario.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingrese toda la infromación para iniciar sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtcontrasena.Text = ""
                txtusuario.Text = ""
                txtusuario.Focus()
                Exit Sub

            End If
            If u.Autenticar(txtusuario.Text.Trim, txtcontrasena.Text.Trim, pa) Then
                If Not Autorizar Then
                    u.Serializar()

                    forma.Show()

                End If
                Autorizo = True
                Me.Close()
            Else
                Autorizo = False
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

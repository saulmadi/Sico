Imports SICO.dtla
Imports SICO.lgla
Imports SICO.ctrla
Public Class Prueba

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim con As New ConexionMySql(False)
        con.Servidor = "Localhost"
        con.Puerto = 3306
        con.Usuario = "root"
        con.Contrasena = "root"
        con.BaseDatos = "Sico"
        con.Guardar()
    End Sub

   
    
    Private Sub PanelAccion1_Nuevo()

        Dim a As New PersonaNatural

    End Sub

    Private Sub Pn_Errores(ByVal Mensaje As System.String)
        MessageBox.Show(Mensaje)
    End Sub

    Private Sub PanelAccion1_Guardar()
        Me.Text = Pn.Id
    End Sub


End Class
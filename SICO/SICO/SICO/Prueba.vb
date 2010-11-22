Imports SICO.dtla
Imports SICO.lgla
Imports SICO.ctrla
Public Class Prueba

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim con As New ConexionMySql(False)
        con.Servidor = "Localhost"
        con.Puerto = 3306
        con.Usuario = "root"
        con.Contrasena = "root"
        con.BaseDatos = "Sico"
        con.Guardar()


    End Sub

   
End Class
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

   
    
    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Pn.Cargar(1)
    End Sub

    Private Sub Pn_Errores(ByVal Mensaje As System.String) Handles Pn.Errores
        MessageBox.Show(Mensaje)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length = 3 Then
            TextBox1.AutoCompleteCustomSource.Add("saul")
            TextBox1.AutoCompleteCustomSource.Add("saul antonio")
            TextBox1.AutoCompleteCustomSource.Add("saul antonio mayorquin")
        Else
            If TextBox1.Text.Length < 3 Then
                TextBox1.AutoCompleteCustomSource.Clear()
            End If

        End If
       
    End Sub
End Class
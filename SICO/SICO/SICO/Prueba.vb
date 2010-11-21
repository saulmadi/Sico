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
        con.BaseDatos = "Prueba"
        con.Guardar()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim con As New ConexionMySql(True)


        MessageBox.Show(con.ProbarConexion().ToString + con.CadenaConexion)


    End Sub
    Dim tablas As New DataTable()
    Private Sub Prueba_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New List(Of Parametro)
        t.Add(New Parametro("Saul Mayorquin", Guid.NewGuid()))
        t.Add(New Parametro("Sarlos Morazan", Guid.NewGuid()))
        t.Add(New Parametro("Enrrique Corea", Guid.NewGuid()))
        Cmb.DataSource = t
        Cmb.ValueMember = "Valor"
        Cmb.DisplayMember = "Nombre"

        Dim lista As New ListaDesplegable()
        Me.Controls.Add(lista)

        Grid1.DataSource = t




    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MessageBox.Show(Cmb.SelectedValue.ToString())
        Dim en As New Entidad()
    End Sub

    Private Sub Cmb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Grid1.BotonEditar = False
        Grid1.BotonEliminar = False

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Grid1.BotonEditar = Not False
        Grid1.BotonEliminar = Not False
    End Sub

    Private Sub Grid1_Editar(ByVal EditarArg As ctrla.GridEditarEventArg) Handles Grid1.Editar
        MessageBox.Show(EditarArg.Fila.ToString )
    End Sub

    Private Sub PanelAccion1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        MessageBox.Show("Saul Mayorquin")
    End Sub
End Class
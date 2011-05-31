Imports SiCo.lgla
Imports SiCo.lgla2

Public Class frmBusquedaMotocileta

    Private Sub frmBusquedaMotocileta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Entidad = New Motocicletas

        Me.Grid.DarFormato("Motor", "Motor", True)
        Me.Grid.DarFormato("Chasis", "Chasis", True)
        Me.Grid.DarFormato("DescripcionMarcas", "Marca", True)
        Me.Grid.DarFormato("DescripcionModelos", "Modelo", True)
        Me.Grid.DarFormato("DescripcionSucursales", "Sucursal", True)
        Me.Grid.DarFormato("DescripcionEstado", "Estado", True)

        cmbMarca.Entidad = New Marcas
        cmbMarca.DisplayMember = "descripcion"
        cmbMarca.ValueMember = "id"
        cmbMarca.ColeccionParametros.Add(New SiCo.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        cmbMarca.CargarParametros()


        cmbModelo.Entidad = New Modelos
        cmbModelo.DisplayMember = "descripcion"
        cmbModelo.ValueMember = "id"
        cmbModelo.ColeccionParametros.Add(New SiCo.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        cmbModelo.ListaDesplegablePadre = cmbMarca
        cmbModelo.ParametroBusquedaPadre = "idderivada"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim p As New List(Of Parametro)


        If txtMotor.Text.Length > 0 Then
            p.Add(New Parametro("motor", txtMotor.Text))
        End If

        If txtChasis.Text.Length > 0 Then
            p.Add(New Parametro("chasis", txtChasis.Text))
        End If

        If Not cmbMarca.SelectedIndex = -1 Then
            p.Add(New Parametro("idmarca", cmbMarca.SelectedValue))
        End If

        If Not cmbModelo.SelectedIndex = -1 Then
            p.Add(New Parametro("idmodelo", cmbModelo.SelectedValue))
        End If

        p.Add(New Parametro("estado", "I"))

        Me.cargar(p)
    End Sub
End Class
Imports SiCo.lgla
Imports SiCo.ctrla
Imports SiCo.lgla2

Public Class frmMotocicletasBusqueda
    Dim WithEvents frm As New frmMotociletas

    Private Sub frmMotocicletasBusqueda_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal

        Me.CrtPanelBusqueda1.Entidad = New Motocicletas

        Me.CrtPanelBusqueda1.GridResultados.DarFormato ("Motor", "Motor", True)
        Me.CrtPanelBusqueda1.GridResultados.DarFormato ("Chasis", "Chasis", True)
        Me.CrtPanelBusqueda1.GridResultados.DarFormato ("DescripcionMarcas", "Marca", True)
        Me.CrtPanelBusqueda1.GridResultados.DarFormato ("DescripcionModelos", "Modelo", True)
        Me.CrtPanelBusqueda1.GridResultados.DarFormato ("DescripcionSucursales", "Sucursal", True)
        Me.CrtPanelBusqueda1.GridResultados.DarFormato ("DescripcionEstado", "Estado", True)

        Me.CrtPanelBusqueda1.GridResultados.BotonEditar = True
        cmbSucursal.ValueMember = "id"
        cmbSucursal.Inicialiazar()
        cmbMarca.Entidad = New Marcas
        cmbMarca.DisplayMember = "descripcion"
        cmbMarca.ValueMember = "id"
        cmbMarca.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("habilitado", "1"))
        cmbMarca.CargarParametros()


        cmbModelo.Entidad = New Modelos
        cmbModelo.DisplayMember = "descripcion"
        cmbModelo.ValueMember = "id"
        cmbModelo.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("habilitado", "1"))
        cmbModelo.ListaDesplegablePadre = cmbMarca
        cmbModelo.ParametroBusquedaPadre = "idderivada"
    End Sub

    Private Sub CrtPanelBusqueda1_Nuevo() Handles CrtPanelBusqueda1.Nuevo
        Me.Hide()
        frm = New frmMotociletas
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub frm_FormClosed (ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub

    Public Sub cargar()
        Try
            Dim p As New List(Of Parametro)


            If txtMotor.Text.Length > 0 Then
                p.Add (New Parametro ("motor", txtMotor.Text))
            End If

            If txtChasis.Text.Length > 0 Then
                p.Add (New Parametro ("chasis", txtChasis.Text))
            End If

            If Not cmbMarca.SelectedIndex = - 1 Then
                p.Add (New Parametro ("idmarca", cmbMarca.SelectedValue))
            End If

            If Not cmbModelo.SelectedIndex = - 1 Then
                p.Add (New Parametro ("idmodelo", cmbModelo.SelectedValue))
            End If

            If Not cmbSucursal.SelectedIndex = - 1 Then
                p.Add (New Parametro ("idsucursal", cmbSucursal.SelectedItem.Id))
            Else
                p.Add (New Parametro ("idsucursal", CrtPanelBusqueda1.sucursal.Id))
            End If

            If cmbEstado.SelectedIndex = 0 Then
                p.Add (New Parametro ("estado", "I"))
            ElseIf cmbEstado.SelectedIndex = 1 Then
                p.Add (New Parametro ("estado", "F"))
            End If

            Me.CrtPanelBusqueda1.Cargar (p)


        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnBuscar_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnBuscar.Click
        cargar()
    End Sub

    Private Sub CrtPanelBusqueda1_Editar() Handles CrtPanelBusqueda1.Editar
        frm = New frmMotociletas
        frm.MdiParent = Me.MdiParent
        frm.Show()
        frm.Motocicletas = CrtPanelBusqueda1.GridResultados.Item
    End Sub
End Class
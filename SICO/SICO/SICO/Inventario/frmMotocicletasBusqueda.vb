Imports SICO.lgla
Imports SICO.lgla2
Public Class frmMotocicletasBusqueda
    Dim WithEvents frm As New frmMotociletas
    Private Sub frmMotocicletasBusqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Normal

        Me.CrtPanelBusqueda1.Entidad = New Motocicletas

        cmbSucursal.Inicialiazar()
        cmbMarca.Entidad = New Marcas
        cmbMarca.DisplayMember = "descripcion"
        cmbMarca.ValueMember = "id"
        cmbMarca.ColeccionParametros.Add(New Parametro("habilitado", "1"))
        cmbMarca.CargarParametros()


        cmbModelo.Entidad = New Modelos
        cmbModelo.DisplayMember = "descripcion"
        cmbModelo.ValueMember = "id"
        cmbModelo.ListaDesplegablePadre = cmbMarca
    End Sub

    Private Sub CrtPanelBusqueda1_Nuevo() Handles CrtPanelBusqueda1.Nuevo
        Me.Hide()
        frm = New frmMotociletas
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
    Public Sub cargar()
        Try
            Dim p As New List(Of Parametro)


            If t Then

                If Not cmbMarca.SelectedIndex = -1 Then
                    p.Add(New Parametro("idmarca", cmbMarca.SelectedValue))
                End If

                If Not cmbModelo.SelectedIndex = -1 Then
                    p.Add(New Parametro("idmodelo", cmbModelo.SelectedValue))
                End If

                If Not cmbSucursal.SelectedIndex = -1 Then
                    p.Add(New Parametro("idsucursal", cmbModelo.SelectedValue))
                End If

                Me.CrtPanelBusqueda1.Cargar(p)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
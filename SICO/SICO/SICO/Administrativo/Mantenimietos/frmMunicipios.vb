Public Class frmMunicipios

    Private Sub CrtTablaTipoDerivada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrtTablaTipoDerivada.Load
        CrtTablaTipoDerivada.Modulo = lgla2.ModulosTablasTipo.Municipios
        CrtTablaTipoDerivada.ModuloDerivado = lgla2.ModulosTablasTipo.Departamentos

        CrtTablaTipoDerivada.cmbDerivado.CargarEntidad()
    End Sub

    Private Sub frmMunicipios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.AcceptButton = CrtTablaTipoDerivada.PanelAccion.BotonGuardar
        Me.CancelButton = CrtTablaTipoDerivada.PanelAccion.BotonCancelar
        AddHandler Me.CrtTablaTipoDerivada.PanelAccion.Cancelar, AddressOf Me.cancelar
        CrtTablaTipoDerivada.crtBusqueda.CargarTodo()

    End Sub
    Private Sub cancelar()
        Me.Close()
    End Sub
End Class
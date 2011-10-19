Imports SiCo.lgla2

Public Class frmMunicipios
    Private Sub CrtTablaTipoDerivada_Load (ByVal sender As Object, ByVal e As EventArgs) _
        Handles CrtTablaTipoDerivada.Load
        CrtTablaTipoDerivada.Modulo = ModulosTablasTipo.Municipios
        CrtTablaTipoDerivada.ModuloDerivado = ModulosTablasTipo.Departamentos

        CrtTablaTipoDerivada.cmbDerivado.CargarEntidad()
    End Sub

    Private Sub frmMunicipios_Load (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.AcceptButton = CrtTablaTipoDerivada.PanelAccion.BotonGuardar
        Me.CancelButton = CrtTablaTipoDerivada.PanelAccion.BotonCancelar
        AddHandler Me.CrtTablaTipoDerivada.PanelAccion.Cancelar, AddressOf Me.cancelar
        CrtTablaTipoDerivada.crtBusqueda.CargarTodo()

    End Sub

    Private Sub cancelar()
        Me.Close()
    End Sub
End Class
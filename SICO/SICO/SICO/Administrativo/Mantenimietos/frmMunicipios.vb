Public Class frmMunicipios

    Private Sub CrtTablaTipoDerivada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrtTablaTipoDerivada.Load
        CrtTablaTipoDerivada.Modulo = lgla2.ModulosTablasTipo.Municipios
        CrtTablaTipoDerivada.ModuloDerivado = lgla2.ModulosTablasTipo.Departamentos

        CrtTablaTipoDerivada.cmbDerivado.CargarEntidad()
    End Sub

End Class
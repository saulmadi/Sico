Imports SiCo.ctrla
Imports SiCo.lgla2
Imports SiCo.ctrla.ControlesBasicos

Public Class frmModelos
    Private Sub CrtTablaTipoDerivada_CambioTablaTipo() Handles CrtTablaTipoDerivada.CambioTablaTipo
        If CrtTablaTipoDerivada.TablaTipo.Id <> 0 Then
            CrtImagen1.Descargar (CrtTablaTipoDerivada.TablaTipo.Id)
        Else
            CrtImagen1.limpiar()
        End If
    End Sub

    Private Sub CrtTablaTipoDerivada_GuardoCorrectamente() Handles CrtTablaTipoDerivada.GuardoCorrectamente
        Try
            CrtImagen1.Guardar (CrtTablaTipoDerivada.TablaTipo.Id)
        Catch ex As Exception
            Mensaje.MensajeError (ex.Message)
        End Try
    End Sub

    Private Sub CrtTablaTipoDerivada_Load (ByVal sender As Object, ByVal e As EventArgs) _
        Handles CrtTablaTipoDerivada.Load
        CrtTablaTipoDerivada.Modulo = ModulosTablasTipo.Modelos
        CrtTablaTipoDerivada.ModuloDerivado = ModulosTablasTipo.Marcas

        CrtTablaTipoDerivada.cmbDerivado.CargarEntidad()


    End Sub

    Private Sub frmMunicipios_Load (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.AcceptButton = CrtTablaTipoDerivada.PanelAccion.BotonGuardar
        Me.CancelButton = CrtTablaTipoDerivada.PanelAccion.BotonCancelar
        AddHandler Me.CrtTablaTipoDerivada.PanelAccion.Cancelar, AddressOf Me.cancelar
        Me.CrtTablaTipoDerivada.crtBusqueda.CargarTodo()
        CrtTablaTipoDerivada.txtDescripcion.TipoTexto = TiposTexto.Alfanumerico
        CrtTablaTipoDerivada.crtBusqueda.txtBusqueda.TipoTexto = TiposTexto.Alfanumerico
    End Sub

    Private Sub cancelar()
        Me.Close()
    End Sub
End Class
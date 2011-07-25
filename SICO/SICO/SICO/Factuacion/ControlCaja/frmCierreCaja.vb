Imports SICO.lgla
Imports SICO.lgla2
Public Class frmCierreCaja

    Private AcumuladoDebitados As New AcumuladosControlCaja
    Private AcumuladoAcreditados As New AcumuladosControlCaja

    Private Sub frmCierreCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AcumuladoAcreditados.Buscar(String.Empty, Me.PanelAccion1.Usuario.Id, Me.PanelAccion1.sucursal.Id, "C", Now)

            AcumuladoDebitados.Buscar(String.Empty, Me.PanelAccion1.Usuario.Id, Me.PanelAccion1.sucursal.Id, "D", Now)

            grdEntrantes.DarFormato("descripcion", "Descripción")
            grdEntrantes.DarFormato("monto", "Monto")

            grdEntrantes.DataSource = AcumuladoAcreditados.TablaAColeccion

            grdSalientes.DarFormato("descripcion", "Descripción")
            grdSalientes.DarFormato("monto", "Monto")
            grdSalientes.DataSource = AcumuladoDebitados.TablaAColeccion



        Catch ex As Exception

        End Try
    End Sub
End Class
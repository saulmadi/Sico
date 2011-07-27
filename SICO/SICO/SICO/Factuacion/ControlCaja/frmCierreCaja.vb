Imports SICO.lgla
Imports SICO.lgla2
Public Class frmCierreCaja

    Private AcumuladoDebitados As New AcumuladosControlCaja
    Private AcumuladoAcreditados As New AcumuladosControlCaja

    Private totalDebitado As Decimal
    Private totalAcreditado As Decimal

    Private Sub frmCierreCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.PanelAccion1.BotonNuevo.Visible = False
            Me.PanelAccion1.BotonEliminar.Text = "Resumen"
            Me.PanelAccion1.BotonImprimir.Text = "Detalle"
            AcumuladoAcreditados.Buscar(String.Empty, Me.PanelAccion1.Usuario.Id, Me.PanelAccion1.sucursal.Id, "C", Now)

            AcumuladoDebitados.Buscar(String.Empty, Me.PanelAccion1.Usuario.Id, Me.PanelAccion1.sucursal.Id, "D", Now)

            grdEntrantes.DarFormato("descripcion", "Descripción")
            grdEntrantes.DarFormato("monto", "Monto")

            grdEntrantes.DataSource = AcumuladoAcreditados.TablaAColeccion

            grdSalientes.DarFormato("descripcion", "Descripción")
            grdSalientes.DarFormato("monto", "Monto")
            grdSalientes.DataSource = AcumuladoDebitados.TablaAColeccion

            txtCajero.Text = PanelAccion1.Usuario.NombreUsuario

            CalcularTotales()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CalcularTotales()
        Try
            Dim listaAcre As List(Of AcumuladosControlCaja) = AcumuladoAcreditados.TablaAColeccion
            Dim listaDebi As List(Of AcumuladosControlCaja) = AcumuladoDebitados.TablaAColeccion

            Me.totalAcreditado = 0
            Me.totalDebitado = 0

            For Each i In listaAcre
                Me.totalAcreditado += i.Monto
            Next

            For Each i In listaDebi
                Me.totalDebitado += i.Monto
            Next

            If Not Me.txtEfectivoFaltante.Text = String.Empty Then Me.totalDebitado += txtEfectivoFaltante.Text
            If Not Me.txtEfectivoFinal.Text = String.Empty Then Me.totalDebitado += txtEfectivoFinal.Text

            txtEntrante.Text = totalAcreditado.ToString("##########.00")
            txtSalient.Text = totalDebitado.ToString("##########.00")
            txtBalance.Text = (totalAcreditado - totalDebitado).ToString("##########.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CajaTexto1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEfectivoFinal.TextChanged
        CalcularTotales()
    End Sub
    
    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar

    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar

    End Sub

    Private Sub PanelAccion1_Imprimir() Handles PanelAccion1.Imprimir
        Try
            Dim f = New frmVistaPrevia
            Dim rpt = New crDetalleCierre
            Dim con = New ControlCaja
            con.Buscar(String.Empty, Me.PanelAccion1.Usuario.Id, Now, Me.PanelAccion1.sucursal.Id)
            rpt.SetDataSource(con.Tabla)
            rpt.DataDefinition.FormulaFields("usuario").Text = "'" + txtCajero.Text + "'"
            
            f.Show(rpt, "Cierre Caja Detalle")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Eliminar
        Try
            Dim f = New frmVistaPrevia
            Dim rpt = New crResumenCierre
            rpt.Subreports("crListaDetalle.rpt").SetDataSource(AcumuladoAcreditados.Tabla)
            rpt.Subreports("crListaDetalle01.rpt").SetDataSource(AcumuladoDebitados.Tabla)
            rpt.DataDefinition.FormulaFields("balance").Text = "tonumber('" + txtBalance.Text + "')"
            rpt.DataDefinition.FormulaFields("usuario").Text = "'" + txtCajero.Text + "'"
            rpt.DataDefinition.FormulaFields("efectivofinal").Text = "tonumber('" + IIf(txtEfectivoFinal.Text = String.Empty, "0.00", txtEfectivoFinal.Text) + "')"
            rpt.DataDefinition.FormulaFields("efectivofaltante").Text = "tonumber('" + IIf(txtEfectivoFaltante.Text = String.Empty, "0.00", txtEfectivoFaltante.Text) + "')"
            f.Show(rpt,"Cierre Caja Resumen")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
End Class
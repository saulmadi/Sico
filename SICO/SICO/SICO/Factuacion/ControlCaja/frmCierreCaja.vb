Imports SICO.lgla
Imports SICO.lgla2
Public Class frmCierreCaja

    Private AcumuladoDebitados As New AcumuladosControlCaja
    Private AcumuladoAcreditados As New AcumuladosControlCaja

    Private totalDebitado As Decimal
    Private totalAcreditado As Decimal
    Private seHizoCierre As Boolean = False
    Private Sub frmCierreCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim c = New ControlCaja
            c.Buscar(4, PanelAccion1.Usuario.Id, Now, PanelAccion1.sucursal.Id)
            If c.TotalRegistros = 0 Then
                MessageBox.Show("No se abierto la caja para este usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PanelAccion1.BotonGuardar.Visible = False
                PanelAccion1.BotonGuardar.Enabled = False

            End If

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

            c.Buscar(5, PanelAccion1.Usuario.Id, Now, PanelAccion1.sucursal.Id)

            If c.TotalRegistros = 0 Then
                PanelAccion1.BotonGuardar.Visible = True
                seHizoCierre = False
            Else
                PanelAccion1.BotonGuardar.Visible = False
                txtEfectivoFinal.Text = c.Monto
                c.Buscar(8, PanelAccion1.Usuario.Id, Now, PanelAccion1.sucursal.Id)
                If c.TotalRegistros = 1 Then txtEfectivoFaltante.Text = c.Monto
                seHizoCierre = True
                txtEfectivoFaltante.Enabled = False
                txtEfectivoFinal.Enabled = False
            End If

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

            If Not Me.txtEfectivoFaltante.Text = String.Empty And Not seHizoCierre Then Me.totalDebitado += txtEfectivoFaltante.Text
            If Not Me.txtEfectivoFinal.Text = String.Empty And Not seHizoCierre Then Me.totalDebitado += txtEfectivoFinal.Text

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
        Try
            Dim f As New frmIniciosesion
            f.Autorizar = True
            f.ShowDialog()
            If f.Autorizo Then

                If txtBalance.Text = 0 Then

                    Dim c As New ControlCaja
                    c.IniciarTransaccion()
                    c.Cajero = Me.PanelAccion1.Usuario.Id
                    c.Descripcion = "Cierre de caja para el usuario " + PanelAccion1.Usuario.NombreUsuario
                    c.Fecha = Now
                    c.idSucursales = PanelAccion1.sucursal.Id
                    c.idTransaccionesCaja = 5
                    c.Monto = txtEfectivoFinal.Text
                    c.Guardar()
                    If txtEfectivoFaltante.Text <> String.Empty Then
                        Dim c2 As New ControlCaja
                        c2.Cajero = Me.PanelAccion1.Usuario.Id
                        c2.Descripcion = "Faltante de caja para el usuario  " + PanelAccion1.Usuario.NombreUsuario
                        c2.Fecha = Now
                        c2.idSucursales = PanelAccion1.sucursal.Id
                        c2.idTransaccionesCaja = 8
                        c2.Monto = txtEfectivoFaltante.Text
                        c2.Guardar()
                    End If
                    c.CommitTransaccion()
                    MessageBox.Show("Se cerro correctamente la caja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.frmCierreCaja_Load(Me, New System.EventArgs)
                Else
                    Throw New ApplicationException("El cierre de caja no se puede realizar si el balance no es cero")
                End If
            Else
                MessageBox.Show("No se realizo el cierre de caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub txtEfectivoFaltante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEfectivoFaltante.TextChanged
        CalcularTotales()
    End Sub
End Class
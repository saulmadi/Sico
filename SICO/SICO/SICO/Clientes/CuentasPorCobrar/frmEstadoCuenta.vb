Imports SiCo.ctrla.ControlesBasicos
Imports SiCo.lgla2

Public Class frmEstadoCuenta
    Public idrubro As Integer = 1

    Private Sub frmEstadoCuenta_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CrtPanelBusqueda1.GridResultados.BotonBuscar = False
        CrtPanelBusqueda1.GridResultados.BotonEditar = False
        CrtPanelBusqueda1.GridResultados.DarFormato ("descripcion", "Descripción")
        CrtPanelBusqueda1.GridResultados.DarFormato ("fecha", "Fecha")
        CrtPanelBusqueda1.GridResultados.DarFormato ("fechavencimiento", "Fecha Vencimiento")
        CrtPanelBusqueda1.GridResultados.DarFormato ("debito", "Debito")
        CrtPanelBusqueda1.GridResultados.DarFormato ("credito", "Credito")
        CrtPanelBusqueda1.SeccionParametros.Size = New Size (CrtPanelBusqueda1.SeccionParametros.Size.Width, 200)
    End Sub

    Private Sub Button1_Click (ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            Dim clie = CrtClientes1.Guardar
            If clie > 0 Then
                Dim entidad = CrtClientes1.Cliente.idEntidades
                Dim cuetenta = New Cuentacorriente
                Dim movimi = New Movimientoscuentacorriente

                If idrubro = 1 Then movimi = cuetenta.EstadoCuentaProductos (entidad)
                If idrubro = 2 Then movimi = cuetenta.EstadoCuentaMotocicleta (entidad)

                Dim lista = movimi.TablaAColeccion
                txtSaldo.Text = lista.Select (Function(c) c.debito).Sum - lista.Select (Function(c) c.credito).Sum

                CrtPanelBusqueda1.GridResultados.DataSource = lista
            Else
                txtSaldo.Text = ""
                CrtPanelBusqueda1.GridResultados.DataSource = Nothing
            End If
        Catch ex As Exception
            Mensaje.MensajeError (ex.Message)
        End Try
    End Sub

    Private Sub CrtPanelBusqueda1_Imprimir() Handles CrtPanelBusqueda1.Imprimir
       
        Try
            Dim clie = CrtClientes1.Guardar
            If clie > 0 Then
                Dim entidad = CrtClientes1.Cliente.idEntidades
                Dim cuetenta = New Cuentacorriente
                Dim movimi = New Movimientoscuentacorriente
                Dim dsrubro = ""
                If idrubro = 1 Then
                    movimi = cuetenta.EstadoCuentaProductos(entidad)
                    dsrubro = "Productos"
                End If
                If idrubro = 2 Then
                    movimi = cuetenta.EstadoCuentaMotocicleta(entidad)
                    dsrubro = "Motocicletas"
                End If
                Dim lista = movimi.TablaAColeccion
                txtSaldo.Text = lista.Select(Function(c) c.debito).Sum - lista.Select(Function(c) c.credito).Sum

                CrtPanelBusqueda1.GridResultados.DataSource = lista
                Dim cr As New crEstadoCuenta
                Dim frm As New frmVistaPrevia
                cr.SetDataSource(movimi.Tabla)
                cr.DataDefinition.FormulaFields("nombre").Text = "'" + CrtClientes1.Cliente.NombreMantenimiento + "'"
                cr.DataDefinition.FormulaFields("rubro").Text = "'" + dsrubro + "'"
                cr.DataDefinition.FormulaFields("saldo").Text = "'" + txtSaldo.Text + "'"
            
                frm.Show(cr, "Estado de Cuenta")

            Else
                txtSaldo.Text = ""
                CrtPanelBusqueda1.GridResultados.DataSource = Nothing
            End If
        Catch ex As Exception
            Mensaje.MensajeError(ex.Message)
        End Try
    End Sub
End Class
Imports SICO.lgla
Imports SICO.lgla2

Public Class frmBusquedaOrdenSalida
    Dim WithEvents frm As New frmOrdenSalida

    Dim _enviadas As Boolean = True
    Public Property Enviadas() As Boolean
        Get
            Return _enviadas
        End Get
        Set(ByVal value As Boolean)
            _enviadas = value
        End Set
    End Property

    Private Sub cargar()
        Try
            Dim p As New List(Of SICO.lgla.Parametro)

            p.Add(New Parametro("fechaemision", " fechaemision >= '" + fecha.Value.ToString("yyyy-MM-dd") + "' and fechaemision <= '" + fechahasta.Value.ToString("yyyy-MM-dd") + "' "))

            If txtcodigo.Text.Length > 0 Then
                p.Add(New Parametro("codigoparecido", txtcodigo.Text))
            End If


            If Enviadas Then
                If cmbSucursalSolicitante.SelectedItem Is Nothing Then
                    p.Add(New Parametro("sucursalenvia", Me.CrtPanelBusqueda1.sucursal.Id))
                Else
                    p.Add(New Parametro("sucursalenvia", cmbSucursalSolicitante.SelectedItem.Id))
                End If
                If Not cmbSucursalDestinatario.SelectedItem Is Nothing Then
                    p.Add(New Parametro("sucursalrecibe", cmbSucursalDestinatario.SelectedItem.Id))
                End If
            Else
                If Not cmbSucursalSolicitante.SelectedItem Is Nothing Then

                    p.Add(New Parametro("sucursalenvia", cmbSucursalSolicitante.SelectedItem.Id))
                End If
                If cmbSucursalDestinatario.SelectedItem Is Nothing Then
                    p.Add(New Parametro("sucursalrecibe", CrtPanelBusqueda1.sucursal.Id))
                Else
                    p.Add(New Parametro("sucursalrecibe", cmbSucursalDestinatario.SelectedItem.Id))
                End If
            End If

            CrtPanelBusqueda1.Cargar(p)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CrtPanelBusqueda1_Nuevo() Handles CrtPanelBusqueda1.Nuevo
        Me.Hide()
        frm = New frmOrdenSalida
        frm.MdiParent = Me.MdiParent
        frm.Show()
    End Sub

    Private Sub frm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles frm.FormClosed
        Me.Show()
    End Sub

    Private Sub frmBusquedaRequsicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CrtPanelBusqueda1.Entidad = New OrdenSalida


        Me.CrtPanelBusqueda1.SeccionParametros.Size = New Size(Me.CrtPanelBusqueda1.SeccionParametros.Size.Width, 80)

        CrtPanelBusqueda1.GridResultados.BotonEditar = True

        Dim s As New Sucursales
        s.Buscar()
        cmbSucursalDestinatario.DisplayMember = "NombreMantenimiento"
        cmbSucursalDestinatario.ValueMember = "id"
        cmbSucursalSolicitante.DisplayMember = "NombreMantenimiento"
        cmbSucursalSolicitante.ValueMember = "id"
        cmbSucursalDestinatario.DataSource = s.TablaAColeccion
        cmbSucursalSolicitante.DataSource = s.TablaAColeccion

        cmbSucursalDestinatario.SelectedIndex = -1
        cmbSucursalSolicitante.SelectedIndex = -1


        CrtPanelBusqueda1.GridResultados.DarFormato("codigo", "Número de Orden", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("DescripcionSucursalEnvia", "Sucursal Proveedora", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("DescripcionSucursalRecibe", "Sucursal Destinataria", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("fechaemision", "Fecha de Orden", True)
        CrtPanelBusqueda1.GridResultados.DarFormato("DescripcionEstado", "Estado", True)

        fecha.Value = Now.AddDays(-30)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cargar()
    End Sub


    Private Sub CrtPanelBusqueda1_Editar() Handles CrtPanelBusqueda1.Editar
        Me.Hide()
        frm = New frmOrdenSalida

        frm.MdiParent = Me.MdiParent
        frm.Show()
        frm.OrdenSalidas = CrtPanelBusqueda1.GridResultados.Item()
    End Sub

End Class
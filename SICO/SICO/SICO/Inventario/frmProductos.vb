Imports SICO.ctrla
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmProductos

#Region "Declaraciones"
    Private _Producto As New Productos
#End Region

#Region "Propiedades"

    Public Property Producto() As Productos
        Get
            Return _Producto
        End Get

        Set(ByVal value As Productos)
            _Producto = value
            txtcodigo.Text = Producto.Codigo
            txtdescripcion.Text = Producto.Descripcion
            txtprecioventa.Text = Producto.PrecioVenta
            If value.Id = 0 Then
                txtprecioventa.Text = ""
                CrtImagen1.limpiar()
            Else
                CrtImagen1.Descargar(value.Id)
            End If
        End Set
    End Property
#End Region

#Region "Eventos"

    Private Sub frmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrtImagen1.DialagoArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        CrtImagen1.Imagenes = New Imagenes
        CrtListadoMantenimiento1.Entidad = New Productos
        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonImprimir.Visible = False
    End Sub

    Private Sub CrtListadoMantenimiento1_Limpio() Handles CrtListadoMantenimiento1.Limpio
        Me.Producto = New Productos
        CrtImagen1.limpiar()
    End Sub

    Private Sub CrtListadoMantenimiento1_SeleccionItem(ByVal Item As System.Object) Handles CrtListadoMantenimiento1.SeleccionItem
        Me.Producto = Item
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim flag As Boolean = True
            If Me.Producto.Id > 0 Then
                Select Case MessageBox.Show("¿Desea modificar el producto " + Producto.Descripcion + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.No
                        flag = False
                End Select
            End If

            If flag Then
                Dim vali As New Validador
                vali.ColecionCajasTexto.Add(txtcodigo)
                vali.ColecionCajasTexto.Add(txtdescripcion)
                vali.ColecionCajasTexto.Add(txtprecioventa)
                If vali.PermitirIngresar Then
                    Me.PanelAccion1.lblEstado.Text = "Guardando..."
                    Me.PanelAccion1.BarraProgreso.Value = 50
                    Me.Producto.Codigo = txtcodigo.Texto
                    Me.Producto.Descripcion = txtdescripcion.Texto
                    Me.Producto.PrecioVenta = txtprecioventa.Texto
                    Me.Producto.Guardar()
                    Me.CrtImagen1.Guardar(Me.Producto.Id)

                    Me.PanelAccion1.lblEstado.Text = "Producto guardado correctamente"
                    Me.PanelAccion1.BarraProgreso.Value = 100

                Else
                    PanelAccion1.lblEstado.Text = vali.MensajesError
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.PanelAccion1.lblEstado.Text = "Error guardando..."
            Me.PanelAccion1.BarraProgreso.Value = 0
        End Try
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Producto = New Productos
    End Sub

#End Region

End Class
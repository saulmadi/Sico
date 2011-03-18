Imports SICO.ctrla
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmProductos

#Region "Declaraciones"
    Private _Producto As New Productos
    Private _Inventario As New Inventario
#End Region

#Region "Constructor"
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Try
            Me.CrtImagen1.Imagenes = New Imagenes
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "Propiedades"

    Public Property Inventario() As Inventario
        Get
            Return _Inventario
        End Get
        Set(ByVal value As Inventario)
            _Inventario = value
        End Set
    End Property

    Public Property Producto() As Productos
        Get
            Return _Producto
        End Get

        Set(ByVal value As Productos)
            txtcantidainventario.Clear()
            txtcantidainventario.Enabled = False
            CrtImagen1.limpiar()
            Me.Inventario = New Inventario
            _Producto = value
            txtcodigo.Text = Producto.Codigo
            txtdescripcion.Text = Producto.Descripcion
            txtprecioventa.Text = Producto.PrecioVenta
            txtpreciocompra.Text = Producto.PrecioCosto
            If value.Id = 0 Then
                txtprecioventa.Text = ""
                txtpreciocompra.Text = ""
               
            Else
                CrtImagen1.Descargar(value.Id)

                Try

                    Dim s As New Sucursales
                    s.Cargar()
                    Me.Inventario.Buscar(s.Id, value.Id)
                    If Me.Inventario.TotalRegistros = 1 Then
                        txtcantidainventario.Text = Me.Inventario.cantidad
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error en la configuración. Debe de configurar la sucursal en la que se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
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
        dteFecha.Value = Now.AddDays(-30)

        Grid1.DarFormato("proveedor", "Proveedor", True)
        Grid1.DarFormato("fechacompra", "Fecha de Compra", True)
        Grid1.DarFormato("facturacompra", "Factura de Compra", True)
        Grid1.DarFormato("cantidad", "Cantidad Comprada", True)
        Grid1.DarFormato("preciocompra", "Precio de Compra", True)



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
                    If txtcantidainventario.Enabled Then
                        Try
                            Me.PanelAccion1.Sucursal.Cargar()
                            Me.Inventario.Buscar(Me.PanelAccion1.Sucursal.Id, Me.Producto.Id)

                            If Me.Inventario.TotalRegistros = 0 Then
                                Me.Inventario = New Inventario
                            End If

                            Me.Inventario.idproducto = Producto.Id
                            Me.Inventario.idSucursal = Me.PanelAccion1.Sucursal.Id
                            Me.Inventario.cantidad = Val(Me.txtcantidainventario.Text)
                            Me.Inventario.Guardar()


                        Catch ex As Exception
                            MessageBox.Show("Error en la configuración. Debe de configurar la sucursal en la que se encuentra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try

                    End If
                    
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

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If MessageBox.Show("¿Desea cambiar la cántidad en inventario para la sucursal?, esta cántidad aumenta automaticamente con las compras.", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            txtcantidainventario.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim hist As New HistoricoCompras
            Dim lisata As New List(Of Parametro)

            lisata.Add(New Parametro("fechacompra", " fechacompra >= '" + dteFecha.Value.ToString("yyyy-MM-dd") + "' and fechacompra <= '" + dteFechahasta.Value.ToString("yyyy-MM-dd") + "' "))

            Grid1.DataSource = Nothing
            lisata.Add(New Parametro("idproducto", Me.Producto.Id))
            hist.Buscar(lisata)

            Grid1.DataSource = hist.Tabla

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

#End Region
    
    
End Class
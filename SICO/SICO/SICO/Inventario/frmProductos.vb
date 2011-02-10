Imports SICO.ctrla
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmProductos
    Private _Producto As New Productos
    Public Property Producto() As Productos
        Get
            Return _Producto
        End Get
        Set(ByVal value As Productos)
            _Producto = value
        End Set
    End Property
    Private Sub frmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrtImagen1.DialagoArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        Grid1.DarFormato("id", "Código", True)
        Grid1.DarFormato("nombre", "Nombre", True)
        Grid1.DarFormato("fecha", "Fecha de última compra", True)
    End Sub

    
    
End Class
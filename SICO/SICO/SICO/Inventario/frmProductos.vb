Imports SICO.ctrla
Public Class frmProductos

    Private Sub frmProductos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrtImagen1.DialagoArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        Grid1.DarFormato("id", "Código", True)
        Grid1.DarFormato("nombre", "Nombre", True)
        Grid1.DarFormato("fecha", "Fecha de última compra", True)
    End Sub

    
End Class
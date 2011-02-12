Imports System.Drawing
Imports System.IO


Public Class Imagenes
    Inherits SiCo.lgla.Entidad

#Region "Declaraciones"
    Private _ImagenBinaria As Byte()
#End Region

#Region "Constructor"
    Public Sub New()
        Me.ComandoMantenimiento = "ProductosImagenes_Mant"

        Me.ComandoSelect = "Imagenes_Buscar"
        Me.TablaEliminar = "ProductosImagenes"

        Me.ColeccionParametrosMantenimiento.Add(New SiCo.lgla.Parametro("imagen", Nothing))

        Me.ColeccionParametrosBusqueda.Add(New SiCo.lgla.Parametro("tabla", TablaEliminar))

    End Sub
#End Region

#Region "Propiedades"

    Public ReadOnly Property Imagen() As System.Drawing.Image
        Get
            If ImagenBinaria Is Nothing Then Return Nothing

            Return Image.FromStream(New MemoryStream(ImagenBinaria))
        End Get
    End Property

    Public Property ImagenBinaria() As Byte()
        Get
            Return _ImagenBinaria
        End Get
        Set(ByVal value As Byte())
            _ImagenBinaria = value
        End Set
    End Property

    Public Property TablaBusqueda() As String
        Get
            Return Me.TablaEliminar
        End Get
        Set(ByVal value As String)
            Me.TablaEliminar = value
            ValorParametrosBusqueda("tabla", value)
            Me.ComandoMantenimiento = value + "_Mant"
        End Set
    End Property

    Public Property IdImagenes() As Long
        Get
            Return _Id
        End Get
        Set(ByVal value As Long)
            _Id = Value
        End Set
    End Property
#End Region

#Region "Metodos"
    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("imagen", Me.ImagenBinaria)
        MyBase.Guardar()
    End Sub

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me._ImagenBinaria = Registro(Indice, "imagen")
        MyBase.CargadoPropiedades(Indice)

    End Sub
#End Region

End Class

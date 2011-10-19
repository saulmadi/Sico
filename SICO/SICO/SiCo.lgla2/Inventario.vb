Imports SiCo.lgla

Public Class Inventario
    Inherits Entidad

#Region "Declaraciones"

    Private _idProducto As Long
    Private _idSucursal As Long
    Private _cantidad As Long

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()
        Me.ComandoMantenimiento = "Inventario_Mant"
        Me.ComandoSelect = "Inventario_Buscar"

        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idsucursal", Nothing))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idproducto", Nothing))

        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idsucursales", Nothing))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idproductos", Nothing))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("cantidad", Nothing))

        Me.TablaEliminar = "Inventario"


    End Sub

#End Region

#Region "Propiedades"

    Public Property idproducto() As Long
        Get
            Return _idProducto
        End Get
        Set (ByVal value As Long)
            _idProducto = value
        End Set
    End Property

    Public Property idSucursal() As Long
        Get
            Return _idSucursal
        End Get
        Set (ByVal value As Long)
            _idSucursal = value
        End Set
    End Property

    Public Property cantidad() As ULong
        Get
            Return _cantidad
        End Get
        Set (ByVal value As ULong)
            _cantidad = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Overloads Sub Buscar (ByVal idsucursal As Long?, ByVal idproducto As Long?)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda ("idsucursal", idsucursal)
        Me.ValorParametrosBusqueda ("idproducto", idproducto)
        Me.LlenadoTabla (Me.ColeccionParametrosBusqueda)
    End Sub

    Public Overrides Sub Guardar()

        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento ("idSucursales", Me.idSucursal)
        Me.ValorParametrosMantenimiento ("idProductos", Me.idproducto)
        Me.ValorParametrosMantenimiento ("cantidad", Me.cantidad)
        MyBase.Guardar()
    End Sub

    Public Sub GuardarTransaccion()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento ("idsucursales", Me.idSucursal)
        Me.ValorParametrosMantenimiento ("idproductos", Me.idproducto)
        Me.ValorParametrosMantenimiento ("cantidad", Me.cantidad)
        MyBase.Guardar (True)
    End Sub

    Protected Overrides Sub CargadoPropiedades (ByVal Indice As Integer)
        Me.idproducto = Me.Registro (Indice, "idproductos")
        Me.idSucursal = Me.Registro (Indice, "idsucursales")
        Me.cantidad = Me.Registro (Indice, "cantidad")
        MyBase.CargadoPropiedades (Indice)
    End Sub

#End Region

#Region "Eventos"

#End Region
End Class

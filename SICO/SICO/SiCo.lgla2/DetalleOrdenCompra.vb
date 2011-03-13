Imports SiCo.lgla
Imports SiCo.lgla2

Public Class DetalleOrdenCompra
    Inherits DetallesProductos
#Region "Declaraciones"
    Private _idordencompra As Long
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "DetalleOrden_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idordencompra"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproducto"))

        Me.ComandoMantenimiento = "DetalleOrden_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idordencompra"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idproducto"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("cantidad"))



    End Sub
    Public Sub New(ByVal id As Long, ByVal idordencompra As Long, ByVal producto As Productos, ByVal cantidad As Long)
        Me.New()

        Me.Producto = producto
        Me.Cantidad = cantidad
        Me._Id = id
        Me.idordencompra = idordencompra
    End Sub
#End Region

#Region "Propiedades"
    Public Property idordencompra() As Long
        Get
            Return _idordencompra
        End Get
        Set(ByVal value As Long)
            _idordencompra = value
        End Set
    End Property
#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idordencompra = Registro(Indice, "idordencompra")
        Me.Cantidad = Registro(Indice, "cantidad")
        MyBase.CargadoPropiedades(Indice)

    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento("idordencompra", Me.idordencompra)
        Me.ValorParametrosMantenimiento("idproducto", Me.idproducto)
        Me.ValorParametrosMantenimiento("cantidad", Me.Cantidad)
        MyBase.Guardar(True)
    End Sub

    Protected Sub GuardarTransaccion(ByVal transaccion As Boolean)

        Me.ValorParametrosMantenimiento("idproducto", Me.idproducto)
        Me.ValorParametrosMantenimiento("cantidad", Me.Cantidad)
        MyBase.Guardar(True)
    End Sub

    Public Overloads Sub Buscar(ByVal idordencompra As String)
        NullParametrosBusqueda()

        ValorParametrosBusqueda("idordencompra", idordencompra)
        LlenadoTabla(ColeccionParametrosBusqueda)

    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of DetalleOrdenCompra)

        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            Dim tempd As New DetalleOrdenCompra(Me.Id, Me.idordencompra, Me.Producto, Me.Cantidad)
            lista.Add(tempd)
        Next
        Return lista
    End Function

#End Region
End Class

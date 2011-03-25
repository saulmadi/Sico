Imports SiCo.lgla
Imports System.Text.RegularExpressions
Public Class ProductosInventario
    Inherits Entidad

#Region "Declaraciones"
    Private _producto As New Productos
    Private _existencia As Long
    Private _idSucursal As Long
    Private _cantidad As Long
    Private _ValidarExistencia As Boolean = True
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "TransaccionesProductos_Buscar"

        Me.ColeccionParametrosBusqueda.Add(New Parametro("idproductos"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("descripcion"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("inventarioTotal"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo"))

    End Sub

    Public Sub New(ByVal idsucursal As Long)
        Me.New()
        Me.idSucursal = idsucursal
    End Sub

    Public Sub New(ByVal producto As Productos, ByVal idsucursal As Long, ByVal existencia As Long)
        Me.Producto = producto
        Me.idSucursal = idsucursal
        Me._existencia = existencia
    End Sub
#End Region

#Region "Propiedades"

    Public Property Producto() As Productos
        Get
            Return _producto
        End Get
        Set(ByVal value As Productos)
            If _producto.Id <> value.Id Then
                Me.Buscar(value.Id, Me.idSucursal, "")
            End If

        End Set
    End Property

    Public Property Codigo() As String
        Get
            If Me.Producto.Id = 0 Then
                Return String.Empty
            End If
            Return Me.Producto.Codigo
        End Get
        Set(ByVal value As String)
            Me._producto = New Productos

            Me.Buscar("", Me.idSucursal, value)
            If Me.Producto.Id = 0 Then
                Throw New ApplicationException("El producto no se encuentra registrado en la sucursal.")
            End If
        End Set
    End Property

    Public Property idSucursal() As Long
        Get
            Return _idSucursal
        End Get
        Set(ByVal value As Long)
            _idSucursal = value
        End Set
    End Property

    Public ReadOnly Property Existencia() As Long
        Get
            Return _existencia
        End Get
    End Property

    Public Property Cantidad() As Long
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Long)
            _cantidad = value
        End Set
    End Property

    Public Property ValidadrExistencia() As Boolean
        Get
            Return _ValidarExistencia
        End Get
        Set(ByVal value As Boolean)
            _ValidarExistencia = value
        End Set
    End Property

    Public Overridable Property CantidadEditable() As String

        Get
            If Cantidad = 0 Then
                Return String.Empty
            End If
            Return Cantidad.ToString
        End Get
        Set(ByVal value As String)
            Dim reg As New Regex("^(?!^0*$)(?!^0*\.0*$)^\d{1,9}")
            If reg.IsMatch(value) Then
                Dim s As Long = value
                If s < 0 Then
                    Throw New ApplicationException("La cantidad tiene que ser mayor a 0")
                    Me.Cantidad = 1
                ElseIf Me.Producto.Id > 0 Then
                    If ValidadrExistencia Then
                        If Me.Existencia >= s Then
                            Me.Cantidad = s
                        Else
                            Me.Cantidad = 0
                            Throw New ApplicationException("La cantidad ingresada execeda a la existencia")
                        End If
                    Else
                        Me.Cantidad = s
                    End If
                Else
                    Me.Cantidad = 0
                End If
            Else
                Throw New ApplicationException("El número no tiene el formato correcto")
            End If
        End Set

    End Property

#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.idSucursal = Registro(Indice, "idSucursales")
        Me._existencia = Registro(Indice, "cantidad")
        Me.Producto = New Productos(Registro(Indice, "idproductos"), Registro(Indice, "codigo"), Registro(Indice, "descripcion"), 0, Registro(Indice, "precioventa"))
        MyBase.CargadoPropiedades(Indice)
    End Sub
    Public Overloads Sub Buscar(ByVal idproducto As String, ByVal idSucursal As String, ByVal codigo As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("idproductos", idproducto)
        Me.ValorParametrosBusqueda("idsucursales", idSucursal)
        Me.ValorParametrosBusqueda("codigo", codigo)
        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)
    End Sub

#End Region

End Class

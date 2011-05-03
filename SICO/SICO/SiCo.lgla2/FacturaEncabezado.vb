﻿Imports SiCo.lgla

Public Class FacturaEncabezado
    Inherits SiCo.lgla.Entidad

    
#Region "Declaraciones"
    Private _codigo As String
    Private _idsucursales As Long
    Private _numerofactura As Long
    Private _idclientes As Long
    Private _fecha As Date
    Private _idtiposfacturas As Long
    Private _total As Decimal
    Private _isv As Decimal
    Private _subtotal As Decimal
    Private _descuentovalor As Decimal
    Private _descuento As Integer
    Private _ventaexecenta As Integer
    Private _estado As String
    Private _motoproducto As String
    Private _motocicleta As Motocicletas
    Private _listaDetalle As List(Of FacturaDetalle)
    Private _diccionario As Dictionary(Of String, FacturaDetalle)

#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "FacturaEncabezado_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigoparecido"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idtiposfacturas"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("estado"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fecha"))


        Me.ComandoMantenimiento = "FacturaEncabezado_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("codigo", Nothing, ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("numerofactura"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idclientes"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fecha"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("total"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("isv"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("subtotal"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("descuentovalor"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("descuento"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("ventaexcenta"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("motoproducto"))

    End Sub

    
#End Region

#Region "Propiedades"
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property idsucursales() As Long
        Get
            Return _idsucursales
        End Get
        Set(ByVal value As Long)
            _idsucursales = value
        End Set
    End Property

    Public Property numerofactura() As Long
        Get
            Return _numerofactura
        End Get
        Set(ByVal value As Long)
            _numerofactura = value
        End Set
    End Property

    Public Property idclientes() As Long
        Get
            Return _idclientes
        End Get
        Set(ByVal value As Long)
            _idclientes = value
        End Set
    End Property

    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set(ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Public Property idtiposfacturas() As Long
        Get
            Return _idtiposfacturas
        End Get
        Set(ByVal value As Long)
            _idtiposfacturas = value
        End Set
    End Property

    Public Property total() As Decimal
        Get
            Return _total
        End Get
        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property

    Public Property isv() As Decimal
        Get
            Return _isv
        End Get
        Set(ByVal value As Decimal)
            _isv = value
        End Set
    End Property

    Public Property subtotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property

    Public Property descuentovalor() As Decimal
        Get
            Return _descuentovalor
        End Get
        Set(ByVal value As Decimal)
            _descuentovalor = value
        End Set
    End Property

    Public Property descuento() As Integer
        Get
            Return _descuento
        End Get
        Set(ByVal value As Integer)
            _descuento = value
        End Set
    End Property

    Public Property ventaexcenta() As Integer
        Get
            Return _ventaexecenta
        End Get
        Set(ByVal value As Integer)
            _ventaexecenta = value
        End Set
    End Property

    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property

    Public Property motoproducto() As String
        Get
            Return _motoproducto
        End Get
        Set(ByVal value As String)
            _motoproducto = value
        End Set
    End Property

    Public Property Motocicleta() As Motocicletas
        Get
            Return _motocicleta
        End Get
        Set(ByVal value As Motocicletas)
            _motocicleta = value
        End Set
    End Property
    Public Property ListaDetalle() As List(Of FacturaDetalle)
        Get
            Return _listaDetalle
        End Get
        Set(ByVal value As List(Of FacturaDetalle))
            _listaDetalle = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.Codigo = Registro(Indice, "codigo")
        Me.idsucursales = Registro(Indice, "idsucursales")
        Me.numerofactura = Registro(Indice, "numerofactura")
        Me.fecha = Registro(Indice, "fecha")
        Me.idclientes = Registro(Indice, "idclientes")
        Me.idtiposfacturas = Registro(Indice, "idtiposfacturas")
        Me.total = Me.Registro(Indice, "total")
        Me.isv = Me.Registro(Indice, "isv")
        Me.subtotal = Me.Registro(Indice, "subtotal")
        Me.descuentovalor = Me.Registro(Indice, "descuentovalor")
        Me.descuento = Me.Registro(Indice, "descuento")
        Me.ventaexcenta = Me.Registro(Indice, "ventaexcenta")
        Me.estado = Me.Registro(Indice, "estado")
        Me.motoproducto = Me.Registro(Indice, "motoproducto")

        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        ValorParametrosMantenimiento("codigo", "")
        ValorParametrosMantenimiento("idsucursales", Me.idsucursales)
        ValorParametrosMantenimiento("numerofactura", Me.numerofactura)
        ValorParametrosMantenimiento("fecha", Me.fecha)
        ValorParametrosMantenimiento("idclientes", Me.idclientes)
        ValorParametrosMantenimiento("idtiposfacturas", Me.idtiposfacturas)
        ValorParametrosMantenimiento("total", Me.total)
        ValorParametrosMantenimiento("isv", Me.isv)
        ValorParametrosMantenimiento("subtotal", Me.subtotal)
        ValorParametrosMantenimiento("descuentovalor", Me.descuentovalor)
        ValorParametrosMantenimiento("descuento", Me.descuentovalor)
        ValorParametrosMantenimiento("idtiposfacturas", Me.idtiposfacturas)
        ValorParametrosMantenimiento("estado", Me.estado)
        ValorParametrosMantenimiento("motoproducto", Me.motoproducto)
        MyBase.Guardar(True)
        Me.codigo = Me.ValorParametrosMantenimiento("codigo")
    End Sub

#End Region

#Region "EnumeradorTipoFactura"
    Public Enum TipoFactura
        P
        M
    End Enum
#End Region

End Class

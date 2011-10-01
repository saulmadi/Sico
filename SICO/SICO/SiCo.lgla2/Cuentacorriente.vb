'------------------------------------------------------------------------------
' This is auto-generated code.
'------------------------------------------------------------------------------
' This code was generated by Entity Developer tool using NHibernate template.
' Code is generated on: 15/09/2011 08:15:59 p.m.
'
' Changes to this file may cause incorrect behavior and will be lost if
' the code is regenerated.
'------------------------------------------------------------------------------

Imports System
Imports System.Collections
Imports System.Linq
Imports System.Text
Imports SiCo.lgla
Imports System.ComponentModel


''' <summary>
''' There are no comments for Cuentacorriente in the schema.
''' </summary>
Partial Public Class Cuentacorriente
    Inherits Entidad

#Region "Declaraciones"
    Private _codigo As String

    Private _identidaddeudora As Integer

    Private _identidadbeneficiaria As Integer

    Private _estado As String

    Private _idsucursales As Integer

    Private _fecha As System.DateTime

    Private _habilitado As Long
#End Region

#Region "Constructor"
#Region "Extensibility Method Definitions"

    Partial Private Sub OnCreated()
    End Sub

#End Region
    Public Sub New()
        MyBase.New()
        OnCreated()

        Me.ComandoMantenimiento = "CuentaCorriente_Mant"
        Me.ColeccionParametrosMantenimiento.Add(New Parametro(codigo, Nothing, ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("identidaddeudora"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("identidadbeneficiaria"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("estado"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("fecha"))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("habilitado"))


        Me.ComandoSelect = "CuentaCorriente_Buscar"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigo"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("codigoparecido"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("entidaddeudora"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("entidadbeneficiaria"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("identidadbenficiaria"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("identidaddeudora"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fecha"))


    End Sub
#End Region

#Region "Propiedades"
    ''' <summary>
    ''' There are no comments for codigo in the schema.
    ''' </summary>
    Public Overridable Property codigo() As String
        Get
            Return Me._codigo
        End Get
        Set(ByVal value As String)

            Me._codigo = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for identidaddeudora in the schema.
    ''' </summary>
    Public Overridable Property identidaddeudora() As Integer
        Get
            Return Me._identidaddeudora
        End Get
        Set(ByVal value As Integer)

            Me._identidaddeudora = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for identidadbeneficiaria in the schema.
    ''' </summary>
    Public Overridable Property identidadbeneficiaria() As Integer
        Get
            Return Me._identidadbeneficiaria
        End Get
        Set(ByVal value As Integer)

            Me._identidadbeneficiaria = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for estado in the schema.
    ''' </summary>
    Public Overridable Property estado() As String
        Get
            Return Me._estado
        End Get
        Set(ByVal value As String)

            Me._estado = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for idsucursales in the schema.
    ''' </summary>
    Public Overridable Property idsucursales() As Integer
        Get
            Return Me._idsucursales
        End Get
        Set(ByVal value As Integer)

            Me._idsucursales = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for fecha in the schema.
    ''' </summary>
    Public Overridable Property fecha() As System.DateTime
        Get
            Return Me._fecha
        End Get
        Set(ByVal value As System.DateTime)

            Me._fecha = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for habilitado in the schema.
    ''' </summary>
    Public Overridable Property habilitado() As Long
        Get
            Return Me._habilitado
        End Get
        Set(ByVal value As Long)

            Me._habilitado = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        CargarClase(Of Cuentacorriente)(Indice, Me)
    End Sub

    Public Shadows Function TablaAColeccion() As List(Of Cuentacorriente)
        Return CaragarColeccion(Of Cuentacorriente)()
    End Function

    Public Overrides Sub Guardar()
        ValorParametrosMantenimiento("identidaddeudora", identidaddeudora)
        ValorParametrosMantenimiento("identidadbeneficiaria", identidadbeneficiaria)
        ValorParametrosMantenimiento("estado", estado)
        ValorParametrosMantenimiento("fecha", fecha)
        ValorParametrosMantenimiento("habilitado", fecha)

        MyBase.Guardar()
    End Sub

    Function CalcularSaldo(ByVal idrubro As Long, ByVal identidad As Long) As Decimal
        Return MyBase.EjecutaFuncion("select CalcularSaldo(" + idrubro.ToString + "," + identidad.ToString + ") ")
    End Function

    Public Sub AgragrarDebitoMovimientoProductos(ByVal identidad As Long, ByVal monto As Decimal, ByVal descripcion As String, ByVal fechavencimiento As Date, ByVal idsucursal As Long)
        Dim agragar = New AgregarCuentaPropietario
        agragar.Guardar(identidad, 1, fechavencimiento, monto, descripcion, 1, idsucursal)
    End Sub

    Public Sub AgragrarCreditoMovimientoProductos(ByVal identidad As Long, ByVal monto As Decimal, ByVal descripcion As String, ByVal fechavencimiento As Date, ByVal idsucursal As Long)
        Dim agragar = New AgregarCuentaPropietario
        agragar.Guardar(identidad, 2, fechavencimiento, monto, descripcion, 1, idsucursal)
    End Sub

    Public Sub AgragrarDebitoMovimientoMotocicletas(ByVal identidad As Long, ByVal monto As Decimal, ByVal descripcion As String, ByVal fechavencimiento As Date, ByVal idsucursal As Long)
        Dim agragar = New AgregarCuentaPropietario
        agragar.Guardar(identidad, 1, fechavencimiento, monto, descripcion, 2, idsucursal)
    End Sub

    Public Sub AgragrarCreditoMovimientoMotocicletas(ByVal identidad As Long, ByVal monto As Decimal, ByVal descripcion As String, ByVal fechavencimiento As Date, ByVal idsucursal As Long)
        Dim agragar = New AgregarCuentaPropietario
        agragar.Guardar(identidad, 2, fechavencimiento, monto, descripcion, 2, idsucursal)
    End Sub

    Public Function EstadoCuentaProductos(ByVal identidad As Long) As Movimientoscuentacorriente
        Dim movimientos As New Movimientoscuentacorriente
        movimientos.Buscar(identidad, 0, 1, 1)
        Return movimientos
    End Function
    Public Function EstadoCuentaMotocicleta(ByVal identidad As Long) As Movimientoscuentacorriente
        Dim movimientos As New Movimientoscuentacorriente
        movimientos.Buscar(identidad, 0, 1, 2)
        Return movimientos
    End Function

#End Region

End Class



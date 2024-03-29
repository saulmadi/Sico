﻿Imports SiCo.lgla

Public Class FacturaEncabezado
    Inherits Entidad


#Region "Declaraciones"

    Private _codigo As String
    Private _idsucursales As Long
    Private _numerofactura As String
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
    Private _motocicleta As New Motocicletas
    Private _listaDetalle As New List(Of FacturaDetalle)
    Private _diccionariodetalle As New Dictionary(Of String, FacturaDetalle)
    Private _elabora As Long
    Private _factura As Long
    Private _nombrecliente As String
    Private _idmotocicletas As Long

    Public Event CambioMotocicleta()

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "FacturaEncabezado_Buscar"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("codigo"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("codigoparecido"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idtiposfacturas"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("estado"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("fecha"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("motoproducto"))


        Me.ComandoMantenimiento = "FacturaEncabezado_Mant"
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("codigo", Nothing, ParameterDirection.InputOutput))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idsucursales"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idtiposfacturas"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("numerofactura"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idclientes"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("fecha"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("total"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("isv"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("subtotal"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("descuentovalor"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("descuento"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("ventaexcenta"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("motoproducto"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("estado"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("elabora"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("factura"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idmotocicletas"))
    End Sub

    Public Sub New (ByVal id As Long, ByVal codigo As String, ByVal idsucursales As Long, ByVal numerofactura As String, _
                    ByVal idclientes As Long, ByVal fecha As Date, ByVal idtiposfacturas As Long, _
                    ByVal total As Decimal, ByVal isv As Decimal, ByVal subtotal As Decimal, _
                    ByVal descuentovalor As Decimal, ByVal descuento As Integer, ByVal ventaexcenta As Integer, _
                    ByVal estado As String, ByVal motoproducto As String, ByVal elabora As Long, ByVal factura As Long, _
                    ByVal idMotocicletas As Long)
        Me.New()

        Me._Id = id
        Me.Codigo = codigo
        Me.idsucursales = idsucursales
        Me.numerofactura = numerofactura
        Me.idclientes = idclientes
        Me.fecha = fecha
        Me.idtiposfacturas = idtiposfacturas
        Me.total = total
        Me.isv = isv
        Me.subtotal = subtotal
        Me.descuentovalor = descuentovalor
        Me.descuento = descuento
        Me.ventaexcenta = ventaexcenta
        Me.estado = estado
        Me.motoproducto = motoproducto
        Me.Factura = factura
        Me.Elabora = elabora
        Me.idMotocicletas = idMotocicletas

    End Sub

#End Region

#Region "Propiedades"

    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set (ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property idsucursales() As Long
        Get
            Return _idsucursales
        End Get
        Set (ByVal value As Long)
            _idsucursales = value
        End Set
    End Property

    Public Property numerofactura() As String
        Get
            Return _numerofactura
        End Get
        Set (ByVal value As String)
            _numerofactura = value
        End Set
    End Property

    Public Property idclientes() As Long
        Get
            Return _idclientes
        End Get
        Set (ByVal value As Long)
            _idclientes = value
        End Set
    End Property

    Public Property fecha() As Date
        Get
            Return _fecha
        End Get
        Set (ByVal value As Date)
            _fecha = value
        End Set
    End Property

    Public Property idtiposfacturas() As Long
        Get
            Return _idtiposfacturas
        End Get
        Set (ByVal value As Long)
            _idtiposfacturas = value
        End Set
    End Property

    Public Property total() As Decimal
        Get
            Return _total
        End Get
        Set (ByVal value As Decimal)
            _total = value
        End Set
    End Property

    Public Property isv() As Decimal
        Get
            Return _isv
        End Get
        Set (ByVal value As Decimal)
            _isv = value
        End Set
    End Property

    Public Property subtotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set (ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property

    Public Property descuentovalor() As Decimal
        Get
            Return _descuentovalor
        End Get
        Set (ByVal value As Decimal)
            _descuentovalor = value
        End Set
    End Property

    Public Property descuento() As Integer
        Get
            Return _descuento
        End Get
        Set (ByVal value As Integer)
            _descuento = value
        End Set
    End Property

    Public Property ventaexcenta() As Integer
        Get
            Return _ventaexecenta
        End Get
        Set (ByVal value As Integer)
            _ventaexecenta = value
        End Set
    End Property

    Public Property estado() As String
        Get
            Return _estado
        End Get
        Set (ByVal value As String)
            _estado = value
        End Set
    End Property

    Public Property motoproducto() As String
        Get
            Return _motoproducto
        End Get
        Set (ByVal value As String)
            _motoproducto = value
        End Set
    End Property

    Public Property Motocicleta() As Motocicletas
        Get
            Return _motocicleta
        End Get
        Set (ByVal value As Motocicletas)
            _motocicleta = value
            RaiseEvent CambioMotocicleta()

        End Set
    End Property

    Public Property ListaDetalle() As List(Of FacturaDetalle)
        Get
            Return _listaDetalle
        End Get
        Set (ByVal value As List(Of FacturaDetalle))
            _listaDetalle = value
        End Set
    End Property

    Public Property Elabora() As Long
        Get
            Return _elabora
        End Get
        Set (ByVal value As Long)
            _elabora = value
        End Set
    End Property

    Public Property Factura() As Long
        Get
            Return _factura
        End Get
        Set (ByVal value As Long)
            _factura = value
        End Set
    End Property

    Public ReadOnly Property DescripcionEstado() As String
        Get
            If Me.estado.ToUpper = "P" Then
                Return "En Proceso"
            ElseIf Me.estado.ToUpper = "F" Then
                Return "Facturada"
            ElseIf Me.estado.ToUpper = "A" Then
                Return "Anulada"
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property NombreCliente() As String
        Get
            Return _nombrecliente
        End Get
    End Property

    Public ReadOnly Property NumeroFacturaS() As String
        Get
            Dim valor As Integer = 0
            If Integer.TryParse (Me.numerofactura, valor) Then
                Return numerofactura
            Else
                Return String.Empty
            End If

        End Get
    End Property

    Public Property idMotocicletas() As Long
        Get
            Return _idmotocicletas
        End Get
        Set (ByVal value As Long)
            _idmotocicletas = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades (ByVal Indice As Integer)
        Me.Codigo = Registro (Indice, "codigo")
        Me.idsucursales = Registro (Indice, "idsucursales")
        Me.numerofactura = Registro (Indice, "numerofactura")
        Me.fecha = Registro (Indice, "fecha")
        Me.idclientes = Registro (Indice, "idclientes")
        Me.idtiposfacturas = Registro (Indice, "idtiposfacturas")
        Me.total = Me.Registro (Indice, "total")
        Me.isv = Me.Registro (Indice, "isv")
        Me.subtotal = Me.Registro (Indice, "subtotal")
        Me.descuentovalor = Me.Registro (Indice, "descuentovalor")
        Me.descuento = Me.Registro (Indice, "descuento")
        Me.ventaexcenta = Me.Registro (Indice, "ventaexenta")
        Me.estado = Me.Registro (Indice, "estado")
        Me.motoproducto = Me.Registro (Indice, "motoproducto")
        Me.Factura = Registro (Indice, "factura")
        Me.Elabora = Me.Registro (Indice, "elabora")
        Me._nombrecliente = Me.Registro (Indice, "nombrecliente")
        Me._idmotocicletas = Me.Registro (Indice, "idmotocicletas")
        If Not String.IsNullOrEmpty (_nombrecliente) Then
            Select Case _nombrecliente.Substring (_nombrecliente.Length - 1)
                Case "@", "$", "%", "&"
                    _nombrecliente = _nombrecliente.Remove (_nombrecliente.Length - 1)
            End Select
        End If


        MyBase.CargadoPropiedades (Indice)
    End Sub

    Public Function CalcularDetalle() As Decimal
        Me._diccionariodetalle.Clear()
        Dim cantot As Decimal = 0

        For g As Integer = 0 To Me.ListaDetalle.Count - 1
            Dim i As FacturaDetalle = ListaDetalle (g)
            If i.Producto.Producto.Id > 0 Then
                If Me._diccionariodetalle.ContainsKey (i.Producto.Producto.Id) Then
                    'Me._diccionariodetalle(i.idproducto).Cantidad += i.Cantidad
                    cantot += i.Producto.Producto.PrecioVenta*i.Cantidad
                Else
                    Me._diccionariodetalle.Add (i.Producto.Producto.Id, i)
                    cantot += i.Producto.Producto.PrecioVenta*i.Cantidad
                End If
            End If
        Next
        If Me._diccionariodetalle.Count = 0 Then
            'Throw New ApplicationException("Debe de ingresar un producto, para realizar la orden de compra")
        End If
        subtotal = cantot
        descuentovalor = subtotal*(IIf (descuento <= 100 And descuento >= 0, descuento, 0)/100)
        Dim valor As Decimal = subtotal - descuentovalor

        isv = IIf (ventaexcenta = 0, (valor)*Impuesto, 0)

        total = valor - IIf (ventaexcenta = 1, valor*Impuesto, 0)
        Return cantot
    End Function

    Public Sub CalcularValoreMotocicleta()
        If Motocicleta.Id > 0 Then
            subtotal = Motocicleta.precioventa
            descuentovalor = subtotal*(IIf (descuento <= 100 And descuento >= 0, descuento, 0)/100)
            Dim valor As Decimal = subtotal - descuentovalor

            isv = IIf (ventaexcenta = 0, (valor)*Impuesto, 0)

            total = valor - IIf (ventaexcenta = 1, valor*Impuesto, 0)
        End If
    End Sub

    Private Function CalcularDetalleGuardar() As Long
        Me._diccionariodetalle.Clear()
        Dim cantot As Long = 0

        For g As Integer = 0 To Me.Listadetalle.Count - 1
            Dim i As FacturaDetalle = ListaDetalle (g)
            If i.Producto.Producto.Id > 0 Then
                If Me._diccionariodetalle.ContainsKey (i.Producto.Producto.Id) Then
                    'Me._diccionariodetalle(i.idproducto).Cantidad += i.Cantidad
                    cantot += i.Cantidad
                Else
                    Me._diccionariodetalle.Add (i.Producto.Producto.Id, i)
                    cantot += i.Cantidad
                End If
            End If
        Next
        If Me._diccionariodetalle.Count = 0 Then
            Throw New ApplicationException ("Debe de ingresar un producto, para realizar la venta")
        End If
        Return cantot
    End Function

    Public Overrides Sub Guardar()
        NullParametrosMantenimiento()
        ValorParametrosMantenimiento ("ventaexcenta", Me.ventaexcenta)
        ValorParametrosMantenimiento ("codigo", "")
        ValorParametrosMantenimiento ("idsucursales", Me.idsucursales)
        ValorParametrosMantenimiento ("numerofactura", Me.numerofactura)
        ValorParametrosMantenimiento ("fecha", Me.fecha)
        If Me.idclientes <= 0 Or Me.idclientes = Nothing Then
            ValorParametrosMantenimiento ("idclientes", Nothing)
        Else
            ValorParametrosMantenimiento ("idclientes", Me.idclientes)
        End If
        ValorParametrosMantenimiento ("idtiposfacturas", Me.idtiposfacturas)
        ValorParametrosMantenimiento ("total", Me.total)
        ValorParametrosMantenimiento ("isv", Me.isv)
        ValorParametrosMantenimiento ("subtotal", Me.subtotal)
        ValorParametrosMantenimiento ("descuentovalor", Me.descuentovalor)
        ValorParametrosMantenimiento ("descuento", Me.descuento)
        ValorParametrosMantenimiento ("idtiposfacturas", Me.idtiposfacturas)
        ValorParametrosMantenimiento ("estado", Me.estado)
        ValorParametrosMantenimiento ("motoproducto", Me.motoproducto)
        ValorParametrosMantenimiento ("elabora", Me.Elabora)
        If Me.idMotocicletas <= 0 Then
            ValorParametrosMantenimiento ("idmotocicletas", Nothing)
        Else
            ValorParametrosMantenimiento ("idmotocicletas", Me.idMotocicletas)
        End If

        If Me.Factura <= 0 Then
            ValorParametrosMantenimiento ("factura", Nothing)
        Else
            ValorParametrosMantenimiento ("factura", Me.Factura)
        End If

        MyBase.Guardar (True)
        Me.codigo = Me.ValorParametrosMantenimiento ("codigo")
    End Sub

    Public Sub GuardarFacturaProducto()
        Try
            Me.IniciarTransaccion()
            Me.CalcularDetalleGuardar()
            Me.Guardar()
            Dim flag As Boolean = False
            For Each i In _diccionariodetalle
                If i.Value.Producto.Producto.Id > 0 Then
                    If i.Value.Cantidad > i.Value.Existencia Then
                        Throw _
                            New ApplicationException ( _
                                "La cantidad del producto" + i.Value.ProductoDescripcion + _
                                " no puede ser mayor que la existencia")
                    End If
                    If i.Value.Cantidad > 0 Then
                        i.Value.idFacturaEncabezado = Me.Id
                        i.Value.Guardar()

                    Else
                        Throw _
                            New ApplicationException ( _
                                "La cantidad del producto" + i.Value.ProductoDescripcion + " no puede ser 0")
                    End If
                End If
            Next
            Me.CommitTransaccion()

        Catch ex As Exception
            Me.RollBackTransaccion()
            Throw New ApplicationException (ex.Message)
        End Try
    End Sub

    Public Sub GuardarFacturaMotocicleta()
        Try
            ''Me.IniciarTransaccion()
            Me.Guardar()

            If Me.Motocicleta.Id >= 0 Then

                Me.Motocicleta.GuardarTransaccion()
            Else
                Throw New ApplicationException ("Seleccione una motocicleta")
            End If

            Dim flag As Boolean = False

            ''Me.CommitTransaccion()

        Catch ex As Exception
            ''Me.RollBackTransaccion()
            Throw New ApplicationException (ex.Message)
        End Try
    End Sub

    Public Sub CargarDetalle()
        _listaDetalle.Clear()
        If Me.Id > 0 Then
            Dim d As New FacturaDetalle
            Dim a As Long = Me.Id
            d.Buscar (a, "", Me.idsucursales)
            _listaDetalle = d.TablaAColeccion
        End If
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of FacturaEncabezado)

        For x As Integer = 0 To TotalRegistros - 1
            Me.CargadoPropiedades (x)
            Dim _
                tempOs As _
                    New FacturaEncabezado (Me.Id, Me.Codigo, Me.idsucursales, Me.numerofactura, Me.idclientes, Me.fecha, _
                                           Me.idtiposfacturas, Me.total, Me.isv, Me.subtotal, Me.descuentovalor, _
                                           Me.descuento, Me.ventaexcenta, Me.estado, Me.motoproducto, Me.Elabora, _
                                           Me.Factura, Me.idMotocicletas)
            tempOs._nombrecliente = Me._nombrecliente
            lista.Add (tempOs)
        Next

        Return lista
    End Function

    Public Sub AnularFacturaMotocicleta()
        Try
            ''Me.IniciarTransaccion()
            Me.estado = "A"

            Me.Guardar()
            If Me.Motocicleta.Id >= 0 Then
                Me.Motocicleta.estado = "I"
                Me.Motocicleta.GuardarTransaccion()
            Else
                Throw New ApplicationException ("No hay motocicleta en la factura")
            End If


            ''Me.CommitTransaccion()
        Catch ex As Exception
            Me.estado = "F"
            ''Me.RollBackTransaccion()
            Throw New ApplicationException (ex.Message)
        End Try
    End Sub

    Public Sub AnularFactura()
        Try
            ''Me.IniciarTransaccion()
            Me.estado = "A"

            Me.Guardar()
            Dim lista As List(Of FacturaDetalle) = Me.ListaDetalle
            For Each i In lista

                If i.Cantidad > 0 Then

                    Dim inv As New InventarioTrigger()
                    inv.ModificarInventario (Me.idsucursales, i.Producto.Producto.Id, i.Cantidad*1)

                Else
                    Throw _
                        New ApplicationException ("La cantidad del producto" + i.ProductoDescripcion + " no puede ser 0")
                End If
            Next

            ''Me.CommitTransaccion()
        Catch ex As Exception
            Me.estado = "F"
            ''Me.RollBackTransaccion()
            Throw New ApplicationException (ex.Message)
        End Try
    End Sub


    Public Sub FacturarProducto()
        Try
            ''Me.IniciarTransaccion()
            Me.estado = "F"
            Me.CalcularDetalleGuardar()
            Me.Guardar()
            Dim faca As New GenerarNumeroFactura
            faca.GenerarNumero (Me.Id, Me.idsucursales, "F")
            Dim lista As List(Of FacturaDetalle) = Me.ListaDetalle
            For Each i In _diccionariodetalle
                If i.Value.Producto.Producto.Id > 0 Then
                    If i.Value.Cantidad > i.Value.Existencia Then
                        Throw _
                            New ApplicationException ( _
                                "La cantidad del producto" + i.Value.ProductoDescripcion + _
                                " no puede ser mayor que la existencia")
                    End If
                    If i.Value.Cantidad > 0 Then
                        i.Value.idFacturaEncabezado = Me.Id
                        i.Value.Guardar()
                        Dim inv As New InventarioTrigger()
                        inv.ModificarInventario (Me.idsucursales, i.Value.Producto.Producto.Id, i.Value.Cantidad*- 1)

                    Else
                        Throw _
                            New ApplicationException ( _
                                "La cantidad del producto" + i.Value.ProductoDescripcion + " no puede ser 0")
                    End If
                End If

            Next

            ''Me.CommitTransaccion()
        Catch ex As Exception
            Me.estado = "P"
            ''Me.RollBackTransaccion()
            Throw New ApplicationException (ex.Message)
        End Try
    End Sub

    Public Sub FacturarMotocicleta()
        Try
            ''Me.IniciarTransaccion()
            Me.estado = "F"
            Me.Guardar()
            Dim faca As New GenerarNumeroFactura
            faca.GenerarNumero (Me.Id, Me.idsucursales, "F")

            If Me.Motocicleta.Id >= 0 Then
                Me.Motocicleta.estado = "F"
                Me.Motocicleta.GuardarTransaccion()
            Else
                Throw New ApplicationException ("Seleccione una motocicleta")
            End If

            Dim flag As Boolean = False


            ''Me.CommitTransaccion()
        Catch ex As Exception
            Me.estado = "P"
            ''Me.RollBackTransaccion()
            Throw New ApplicationException (ex.Message)
        End Try
    End Sub

#End Region

#Region "EnumeradorTipoFactura"

    Public Enum TipoFactura
        P
        M
    End Enum

#End Region
End Class

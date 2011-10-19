Imports SiCo.lgla

Public Class TransaccionesTrajetaCredito
    Inherits Entidad
    Private _idFacturaEncabezado As Long
    Private _numeroTarjeta As String
    Private _codigoAprobacion As String
    Private _vencimiento As Integer
    Private _idtarjetacredito As Long
    Private _idcontrolcaja As Long

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        Me.ComandoMantenimiento = "TransaccionesTarjetaCredito_Mant"
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idfacturaencabezado"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("numerotarjeta"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("codigoaprobacion"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("vencimiento"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idtarjetacredito"))
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idcontrolcaja"))

    End Sub

#End Region

#Region "Propiedades"

    Public Property idFacturaEnbezado() As Long
        Get
            Return _idFacturaEncabezado
        End Get
        Set (ByVal value As Long)
            _idFacturaEncabezado = value
        End Set
    End Property

    Public Property numeroTarjeta() As String
        Get
            Return _numeroTarjeta
        End Get
        Set (ByVal value As String)
            _numeroTarjeta = value
        End Set
    End Property

    Public Property CodigoAprobacion() As String
        Get
            Return _codigoAprobacion
        End Get
        Set (ByVal value As String)
            _codigoAprobacion = value
        End Set
    End Property

    Public Property Vencimiento() As Integer
        Get
            Return _vencimiento
        End Get
        Set (ByVal value As Integer)
            _vencimiento = value
        End Set
    End Property

    Public Property idTarjetaCredito() As Long
        Get
            Return _idtarjetacredito
        End Get
        Set (ByVal value As Long)
            _idtarjetacredito = value
        End Set
    End Property

    Public Property idControlCaja()
        Get
            Return _idcontrolcaja
        End Get
        Set (ByVal value)
            _idcontrolcaja = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Overrides Sub Guardar()
        Me.ValorParametrosMantenimiento ("idfacturaencabezado", Me.idFacturaEnbezado)
        Me.ValorParametrosMantenimiento ("numerotarjeta", Me.numeroTarjeta)
        Me.ValorParametrosMantenimiento ("codigoaprobacion", Me.CodigoAprobacion)
        Me.ValorParametrosMantenimiento ("vencimiento", Me.Vencimiento)
        Me.ValorParametrosMantenimiento ("idtarjetacredito", Me.idTarjetaCredito)
        Me.ValorParametrosMantenimiento ("idcontrolcaja", Me.idControlCaja)

        MyBase.Guardar (True)
    End Sub

#End Region
End Class

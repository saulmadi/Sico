Imports SiCo.lgla
Public Class AcumuladosControlCaja
    Inherits Entidad

#Region "Declaraciones"
    Private _descripcion As String
    Private _monto As Decimal
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "AcumuladosControlCaja"
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idtransacciones"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("fecha"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("idsucursales"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("cajero"))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("tipo"))
    End Sub

    Public Sub New(ByVal id As Long, ByVal descripcion As String, ByVal monto As Decimal)
        Me.New()
        _Id = id
        Me.Descripcion = descripcion
        Me.Monto = monto
    End Sub
#End Region

#Region "Propiedades"
    Public Property Descripcion() As String
        Get
            Return _descripcion

        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Monto() As Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As Decimal)
            _monto = value
        End Set
    End Property
#End Region


#Region "Metodos"
    Public Overloads Sub Buscar(ByVal idtransaccioncaja As String, ByVal cajero As Long, ByVal sucursal As String, ByVal tipo As String, ByVal fecha As Date)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("idtransacciones", idtransaccioncaja)
        Me.ValorParametrosBusqueda("cajero", cajero.ToString)
        Me.ValorParametrosBusqueda("fecha", " fecha ='" + fecha.ToString("yyyy-MM-dd") + "'")
        Me.ValorParametrosBusqueda("idsucursales", sucursal)
        Me.ValorParametrosBusqueda("tipo", tipo)
        Me.LlenadoTabla(ColeccionParametrosBusqueda)

    End Sub

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        Me.Descripcion = Registro(Indice, "descripcion")
        Me.Monto = Registro(Indice, "monto")
        MyBase.CargadoPropiedades(Indice)
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        Dim lis As New List(Of AcumuladosControlCaja)
        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(i)
            lis.Add(New AcumuladosControlCaja(Me.Id, Me.Descripcion, Me.Monto))
        Next
        Return lis
    End Function
#End Region

End Class

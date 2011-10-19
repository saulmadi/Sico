Imports SiCo.lgla

Public Class DetalleRequisicion
    Inherits DetalleOrdenCompra

#Region "Declaraciones"

    Private _idrequisicion As Long

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        Me.ComandoSelect = "DetalleRequisicion_Buscar"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idrequisicion"))

        Me.ComandoMantenimiento = "DetalleRequisicion_Mant"
        Me.ColeccionParametrosMantenimiento.Add (New Parametro ("idrequisicion"))

    End Sub

    Public Sub New (ByVal id As Long, ByVal idrequisicion As Long, ByVal producto As Productos, ByVal cantidad As Long)
        Me.New()

        Me.Producto = producto
        Me.Cantidad = cantidad
        Me._Id = id
        Me.idRequisicion = idrequisicion


    End Sub


#End Region

#Region "Propiedades"

    Public Property idRequisicion() As Long
        Get
            Return _idrequisicion
        End Get
        Set (ByVal value As Long)
            _idrequisicion = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Protected Overrides Sub CargadoPropiedades (ByVal Indice As Integer)
        Me.idRequisicion = Registro (Indice, "idrequisicion")
        MyBase.CargadoPropiedades (Indice)
    End Sub

    Public Overrides Sub Guardar()
        Me.NullParametrosMantenimiento()
        Me.ValorParametrosMantenimiento ("idrequisicion", Me.idRequisicion)

        MyBase.GuardarTransaccion (True)
    End Sub

    Public Overloads Sub Buscar (ByVal idRequisicion As String)
        NullParametrosBusqueda()

        ValorParametrosBusqueda ("idrequisicion", idRequisicion)
        LlenadoTabla (ColeccionParametrosBusqueda)

    End Sub


    Public Overrides Function TablaAColeccion() As Object
        Dim lista As New List(Of DetalleRequisicion)

        For i As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades (i)
            Dim tempd As New DetalleRequisicion (Me.Id, Me.idRequisicion, Me.Producto, Me.Cantidad)
            lista.Add (tempd)
        Next
        Return lista
    End Function


#End Region
End Class

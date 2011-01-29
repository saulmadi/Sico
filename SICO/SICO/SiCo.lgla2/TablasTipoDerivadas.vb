Imports SiCo.lgla
Public Class TablasTipoDerivadas
    Inherits TablasTipo

#Region "Declaraciones"
    Private _idDerivada As Long
#End Region

#Region "Constructor"

    Sub New()
        MyBase.New()

        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idderivada", Nothing))
    End Sub

    Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal habilitado As Integer, ByVal idDeriva As Long)
        MyBase.New(id, descripcion, habilitado)

        Me.idDerivada = idDeriva

        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idderivada", Nothing))
    End Sub

#End Region

#Region "propiedades"
    Public Property idDerivada() As Long
        Get
            Return _idDerivada
        End Get
        Set(ByVal value As Long)
            _idDerivada = value
        End Set
    End Property
#End Region

#Region "Metodos"

    Public Overrides Sub Guardar()
        Me.ValorParametrosMantenimiento("idderivada", Me.idDerivada)
        MyBase.Guardar()
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        MyBase.TablaAColeccion()
        Dim Lista As New List(Of TablasTipoDerivadas)
        For x As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(x)
            Dim tem As New TablasTipoDerivadas(Me.Id, Me.descripcion, Me.habilitado, Me.idDerivada)
            tem.ComandoSelect = Me.ComandoSelect
            tem.ComandoMantenimiento = Me.ComandoMantenimiento
            tem.TablaBusqueda = Me.TablaBusqueda
            tem.TablaEliminar = Me.TablaBusqueda
            Lista.Add(tem)
        Next
        Me.CargadoPropiedades(0)
        Return Lista
    End Function

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        If Me.TotalRegistros > 0 Then
            Me.idDerivada = Me.Registro(Indice, "idderivada")
            MyBase.CargadoPropiedades(Indice)
        End If

    End Sub

#End Region

End Class

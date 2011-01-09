<Serializable()> _
Public Class Estado

#Region "Declaraciones"
    Private _descripcion As String
    Private _valor As Integer
#End Region

#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(ByVal Descripcion As String, ByVal valor As Integer)
        Me.Descripcion = Descripcion
        Me.valor = valor
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

    Public Property valor() As Integer
        Get
            Return _valor
        End Get
        Set(ByVal value As Integer)
            _valor = value
        End Set
    End Property

#End Region

End Class

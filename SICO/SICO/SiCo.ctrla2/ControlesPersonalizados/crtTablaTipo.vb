Public Class crtTablaTipo

    Private _Titulo As String
    Public Property Titulo() As String
        Get
            Return _Titulo
        End Get
        Set(ByVal value As String)
            _Titulo = value
            PanelAccion.Titulo = value
        End Set
    End Property

    

End Class

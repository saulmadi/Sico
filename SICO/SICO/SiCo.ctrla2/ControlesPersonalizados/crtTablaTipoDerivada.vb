Public Class crtTablaTipoDerivada
    Inherits crtTablaTipo



    Public Property TituloDerivado() As String
        Get
            Return lblDerivado.Text
        End Get
        Set(ByVal value As String)
            lblDerivado.Text = value
        End Set
    End Property


End Class

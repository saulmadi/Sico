Public Class crtPersonaJuridica


    Public Property TextoRazonSocial() As String
        Get
            Return lblRazonSocial.Text
        End Get
        Set(ByVal value As String)
            lblRazonSocial.Text = value
        End Set
    End Property

End Class

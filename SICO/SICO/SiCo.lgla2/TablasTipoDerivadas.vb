Imports SiCo.lgla
Public MustInherit Class TablasTipoDerivadas
    Inherits TablasTipo

#Region "Declaraciones"
    Private _idDerivada As Integer
#End Region

#Region "Constructor"
    Sub New()
        MyBase.New()

        Me.ColeccionParametrosMantenimiento.Add(New Parametro("idderivada", Nothing))
    End Sub
#End Region

#Region "propiedades"
    Public Property idDerivada() As Integer
        Get
            Return _idDerivada
        End Get
        Set(ByVal value As Integer)
            _idDerivada = value
        End Set
    End Property
#End Region

#Region "Metodos"

    Public Overrides Sub Guardar()
        Me.ValorParametrosBusqueda("idderivada", Me.idDerivada)
        MyBase.Guardar()
    End Sub

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        If Me.TotalRegistros > 0 Then
            Me.idDerivada = Me.Registro(Indice, "idderivada")
            MyBase.CargadoPropiedades(Indice)
        End If

    End Sub

#End Region

End Class

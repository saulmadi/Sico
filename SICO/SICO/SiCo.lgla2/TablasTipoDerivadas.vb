Imports SiCo.lgla
Public MustInherit Class TablasTipoDerivadas
    Inherits TablasTipo

#Region "Declaraciones"
    Private _idDerivada As Integer
#End Region

#Region "Constructor"
    Sub New()
        MyBase.New()

        Me.ColeccionParametrosMantenimiento.Add(new  Parametro("idderivada",Nothing)  
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

    Protected Overrides Sub CargadoPropiedades()
        Me.idDerivada = Me.PrimerRegistro("idderivada")
        MyBase.CargadoPropiedades()
    End Sub

#End Region

End Class

Imports SiCo.lgla
Public Class Departamentos
    Inherits SiCo.lgla.Entidad
#Region "Declaraciones"
    Private _departamento As String
    Private _habilitados As Boolean
#End Region

#Region "Constructor"
    Public Sub New()
        Me.ComandoSelect = "Departamentos_Buscar"
        Me.ComandoMantenimiento = "Departamentos_Mant"

        Me.ColeccionParametrosBusqueda.Add(New Parametro("departamento", Nothing))

        Me.ColeccionParametrosMantenimiento.Add(New Parametro("habilitados", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("Departamento", Nothing))
    End Sub
#End Region

#Region "Propiedades"
    Public Property departamento() As String
        Get
            Return _departamento
        End Get
        Set(ByVal value As String)
            _departamento = value
        End Set
    End Property

    Public Property habilitado() As Boolean
        Get
            Return _habilitados
        End Get
        Set(ByVal value As Boolean)
            _habilitados = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Public Overloads Sub Buscar(ByVal Departamento As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("departamentos", Departamento)
        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)
    End Sub

    Protected Overrides Sub CargadoPropiedades()

        Me.departamento = PrimerRegistro("departamento")
        Me.habilitado = PrimerRegistro("habilitados")

        MyBase.CargadoPropiedades()
    End Sub

#End Region
    
    
End Class

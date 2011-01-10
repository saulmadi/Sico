Imports SiCo.lgla
Public Class TablasTipo
    Inherits SiCo.lgla.Entidad
#Region "Declaraciones"
    Private _Descripcion As String
    Private _habilitado As Integer
    Private _tablaBusqueda As String
#End Region

#Region "Constructor"
    Public Sub New()
        MyBase.New()
        Me.ColeccionParametrosBusqueda.Add(New Parametro("descripcion", Nothing))
        Me.ColeccionParametrosBusqueda.Add(New Parametro("habilitado", Nothing))

        Me.ComandoSelect = "Mantenimientos_Buscar"

        Me.ColeccionParametrosMantenimiento.Add(New Parametro("habilitado", Nothing))
        Me.ColeccionParametrosMantenimiento.Add(New Parametro("descripcion", Nothing))
    End Sub

    Public Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal habilitado As Integer)
        Me.New()
        Me._Id = id
        Me.descripcion = descripcion
        Me.habilitado = habilitado
    End Sub

#End Region

#Region "Propiedades"
    Public Property descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property habilitado() As Integer
        Get
            Return _habilitado
        End Get
        Set(ByVal value As Integer)
            _habilitado = value
        End Set
    End Property
    Public Property TablaBusqueda() As String
        Get
            Return _tablaBusqueda
        End Get
        Set(ByVal value As String)
            _tablaBusqueda = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Overloads Sub Buscar(ByVal Descripcion As String)
        Me.NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("tabla", Me.TablaBusqueda)
        Me.ValorParametrosBusqueda("descripcion", Descripcion)
        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)
    End Sub

    Protected Overrides Sub CargadoPropiedades(ByVal Indice As Integer)
        If Me.TotalRegistros > 0 Then
            Me.descripcion = Registro(Indice, "descripcion")
            Me.habilitado = Registro(Indice, "habilitado")

            MyBase.CargadoPropiedades(Indice)
        End If

    End Sub

    Public Overrides Sub Guardar()
        Me.ValorParametrosMantenimiento("descripcion", Me.descripcion)
        Me.ValorParametrosMantenimiento("habilitado", Me.habilitado)
        MyBase.Guardar()
    End Sub

    Public Overrides Function TablaAColeccion() As Object
        MyBase.TablaAColeccion()
        Dim Lista As New List(Of TablasTipo)
        For x As Integer = 0 To Me.TotalRegistros - 1
            Me.CargadoPropiedades(x)
            Dim tem As New TablasTipo(Me.Id, Me.descripcion, Me.habilitado)
            tem.ComandoSelect = Me.ComandoSelect
            tem.ComandoMantenimiento = Me.ComandoMantenimiento
            Lista.Add(tem)
        Next
        Me.CargadoPropiedades(0)
        Return Lista
    End Function
    Public Overrides Sub Buscar()
        NullParametrosBusqueda()
        Me.ValorParametrosBusqueda("tabla", Me.TablaBusqueda)
        Me.LlenadoTabla(Me.ColeccionParametrosBusqueda)
    End Sub

#End Region

End Class

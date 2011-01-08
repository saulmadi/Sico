
Public Class NombresModuloTablasTipo

#Region "Declaraciones"
    Private _ModuloTablaTipo As ModulosTablasTipo = ModulosTablasTipo.TiposMotocicletas
#End Region

#Region "Constructor"
    Public Sub New(ByVal TipoTablaTipo As ModulosTablasTipo)
        _ModuloTablaTipo = TipoTablaTipo
    End Sub
#End Region

#Region "Propiedades"
    Public ReadOnly Property Nombre() As String
        Get
            Return NombreModuloTablasTipo(_ModuloTablaTipo)
        End Get
    End Property
    Public Property ModuloTablaTipo() As ModulosTablasTipo
        Get
            Return _ModuloTablaTipo
        End Get
        Set(ByVal value As ModulosTablasTipo)
            _ModuloTablaTipo = value
        End Set
    End Property
    Public ReadOnly Property Instancias() As Object
        Get
            Return InstanciaTablaTipo(Me.ModuloTablaTipo)
        End Get
    End Property

#End Region

#Region "Metodos"
    Public Shared Function NombreModuloTablasTipo(ByVal Tablastipo As ModulosTablasTipo) As String
        Select Case Tablastipo
            Case ModulosTablasTipo.Departamentos
                Return "Departamento"
            Case ModulosTablasTipo.Marcas
                Return "Marca"
            Case ModulosTablasTipo.TiposFacturas
                Return "Tipo de factura"
            Case ModulosTablasTipo.TiposMotocicletas
                Return "Tipo de motocicleta"

        End Select

        Return String.Empty
    End Function
    Public Shared Function InstanciaTablaTipo(ByVal Tablastipo As ModulosTablasTipo) As Object
        Select Case Tablastipo
            Case ModulosTablasTipo.Departamentos
                Return New Departamentos
            Case ModulosTablasTipo.Marcas
                Return New Marcas
            Case ModulosTablasTipo.TiposFacturas
                Return New TiposFacturas
            Case ModulosTablasTipo.TiposMotocicletas
                Return New TiposMotocicletas
        End Select
        Return Nothing
    End Function
#End Region

End Class

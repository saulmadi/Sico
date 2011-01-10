Imports SiCo.lgla
Imports SiCo.lgla2
Imports System.Diagnostics
Imports System.ComponentModel
Public Class crtTablaTipoDerivada
    Inherits crtTablaTipo

#Region "Declaraciones"
    Private _tablatipoDerivada As TablasTipo
    Private _ModuloTipoDerivado As ModulosTablasTipo = ModulosTablasTipo.Departamentos
    Private _NombreModulo As NombresModuloTablasTipo = New NombresModuloTablasTipo(_ModuloTipoDerivado)

#End Region

#Region "Propiedades"

    Public Property TituloDerivado() As String
        Get
            Return lblDerivado.Text
        End Get
        Set(ByVal value As String)
            lblDerivado.Text = value
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property TablaTipoDerivada() As TablasTipo
        Get
            Return _tablatipoDerivada
        End Get
        Set(ByVal value As TablasTipo)
            _tablatipoDerivada = value
            cmbDerivado.Entidad = value
        End Set
    End Property
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property ModuloDerivado() As ModulosTablasTipo
        Get
            Return _ModuloTipoDerivado
        End Get
        Set(ByVal value As ModulosTablasTipo)
            _ModuloTipoDerivado = value
            _NombreModulo.ModuloTablaTipo = value
            cmbDerivado.Entidad = _NombreModulo.Instancias
        End Set
    End Property

#End Region

#Region "Eventos"
    Private Sub crtTablaTipoDerivada_CambioTablaTipo() Handles MyBase.CambioTablaTipo

    End Sub
#End Region


  
End Class

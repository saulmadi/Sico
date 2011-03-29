Imports SICO.lgla
Imports SICO.lgla2
Public Class frmMotociletas
#Region "Declaraciones"
    Private _mototicletas As Motocicletas
#End Region

#Region "Propidades"
    Public Property Motocicletas() As Motocicletas
        Get
            Return _mototicletas
        End Get
        Set(ByVal value As Motocicletas)
            _mototicletas = value
            CargarEntidad()
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Sub CargarEntidad()

        If Me.Motocicletas.Id = 0 Then

        Else

        End If

    End Sub

#End Region

#Region "Eventos"
    Private Sub frmMotociletas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbMarca.Entidad = New Marcas
        Me.cmbModelo.Entidad = New Modelos
        Me.cmbProveedor.Entidad = New Proveedores
        Me.cmbTipoMotocicleta.Entidad = New TiposMotocicletas

        cmbMarca.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))

        cmbModelo.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        cmbModelo.ListaDesplegablePadre = cmbMarca
        cmbModelo.ParametroBusquedaPadre = "idderivada"

        cmbTipoMotocicleta.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))

    End Sub
#End Region
End Class
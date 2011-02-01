Imports SICO.lgla
Imports SICO.lgla2
Public Class frmSucursales

    Private Sub frmSucursales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbMunicipio.Entidad = New Municipios
        cmbMunicipio.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        cmbMunicipio.ParametroBusquedaPadre = "idderivada"
        cmbMunicipio.ListaDesplegablePadre = cmbDepartamento

        cmbAdmon.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("idrol", " > 3 "))
        cmbAdmon.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("estado", "1"))
        cmbAdmon.Entidad = New Usuario
        cmbAdmon.CargarParametros()

        cmbDepartamento.Entidad = New Departamentos
        cmbDepartamento.ColeccionParametros.Add(New SICO.ctrla.ListaDesplegable.ParametrosListaDesplegable("habilitado", "1"))
        cmbDepartamento.CargarParametros()

       
    End Sub



End Class
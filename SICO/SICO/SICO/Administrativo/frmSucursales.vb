﻿Imports SiCo.ctrla
Imports SiCo.lgla2
Imports SiCo.lgla

Public Class frmSucursales
    Private _Sucursal As New Sucursales

    Public Property Sucursal() As Sucursales

        Get
            Return _Sucursal
        End Get

        Set (ByVal value As Sucursales)
            _Sucursal = value
            If Not value.idUsuario Is Nothing Then cmbAdmon.SelectedValue = value.idUsuario Else _
                cmbAdmon.SelectedIndex = - 1

            Dim m As New Municipios
            txtnumerofactura.Text = value.NumeroFactura
            If value.Id > 0 Then
                txtnumerofactura.Enabled = False
            Else
                txtnumerofactura.Enabled = True
            End If
            cmbMunicipio.Limpiar()
            cmbDepartamento.SelectedIndex = - 1
            If value.idMunicipio > 0 Then
                m.Id = value.idMunicipio

                cmbDepartamento.SelectedValue = m.idDerivada
                cmbMunicipio.SelectedValue = m.Id

            End If


            cmbestado.SelectedIndex = value.Estado

            CrtPersonaJuridica1.Persona = value.PersonaJuridica

        End Set
    End Property

    Private Sub frmSucursales_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.CrtListadoMantenimiento1.lblDescripcion.Text = "Sucursal"
        Me.CrtListadoMantenimiento1.Entidad = New Sucursales

        Me.PanelAccion1.BotonEliminar.Enabled = False
        Me.PanelAccion1.BotonEliminar.Visible = False

        Me.PanelAccion1.BotonImprimir.Visible = False
        Me.PanelAccion1.BotonImprimir.Enabled = False

        cmbDepartamento.Entidad = New Departamentos
        cmbDepartamento.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("habilitado", "1"))
        cmbDepartamento.CargarParametros()

        cmbMunicipio.Entidad = New Municipios
        cmbMunicipio.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("habilitado", "1"))
        cmbMunicipio.ParametroBusquedaPadre = "idderivada"
        cmbMunicipio.ListaDesplegablePadre = cmbDepartamento

        cmbAdmon.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("idrol", " > 3 "))
        cmbAdmon.ColeccionParametros.Add (New ListaDesplegable.ParametrosListaDesplegable ("estado", "1"))
        cmbAdmon.Entidad = New Usuario
        cmbMunicipio.CargarComboBox = False
        cmbAdmon.CargarParametros()
        cmbMunicipio.CargarComboBox = True


        cmbMunicipio.Limpiar()


    End Sub

    Private Sub CrtListadoMantenimiento1_Limpio() Handles CrtListadoMantenimiento1.Limpio
        Me.Sucursal = New Sucursales
        CrtPersonaJuridica1.Persona = New PersonaJuridica
        Me.PanelAccion1.BarraProgreso.Value = 0
    End Sub

    Private Sub CrtListadoMantenimiento1_SeleccionItem (ByVal Item As Object) _
        Handles CrtListadoMantenimiento1.SeleccionItem
        Me.Sucursal = CType (Item, Sucursales)
        Me.PanelAccion1.BarraProgreso.Value = 0
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim flag As Boolean = True
            If Me.Sucursal.Id > 0 Then
                Select Case _
                    MessageBox.Show ("¿Esta seguro de modificar la sucursal " + Me.Sucursal.NombreMantenimiento + "?", _
                                     "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.No
                        flag = False

                End Select
            End If

            If flag And Not cmbAdmon.SelectedItem Is Nothing And Not cmbMunicipio.SelectedValue Is Nothing Then
                Dim v As New Validador
                v.ColecionCajasTexto.Add (txtnumerofactura)
                If v.PermitirIngresar Then


                    Me.PanelAccion1.lblEstado.Text = "Guardando..."
                    Me.PanelAccion1.BarraProgreso.Value = 50


                    Me.Sucursal.idEntidades = CrtPersonaJuridica1.Guardar()
                    If Me.Sucursal.idEntidades > 0 Then


                        Me.Sucursal.Estado = cmbestado.SelectedItem.valor
                        Me.Sucursal.idUsuario = CType (cmbAdmon.SelectedItem, Usuario).Id
                        Me.Sucursal.idMunicipio = cmbMunicipio.SelectedValue
                        Me.Sucursal.NumeroFactura = Me.txtnumerofactura.Text
                        Me.Sucursal.Guardar()
                        Me.PanelAccion1.BarraProgreso.Value = 100
                        Me.PanelAccion1.lblEstado.Text = "Se guardo correctamente la sucursal " + _
                                                         Me.Sucursal.NombreMantenimiento


                    End If
                Else
                    Me.PanelAccion1.lblEstado.Text = v.MensajesError
                    Me.PanelAccion1.BarraProgreso.Value = 0
                End If
            Else
                If flag Then
                    Me.PanelAccion1.lblEstado.Text = "Debe de ingresar toda la información. "
                    Me.PanelAccion1.BarraProgreso.Value = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show (ex.Message)
            Me.PanelAccion1.lblEstado.Text = ("Error al guardar la sucursal")
            Me.PanelAccion1.BarraProgreso.Value = 0
        End Try
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Sucursal = New Sucursales
        Me.CrtPersonaJuridica1.Nuevo()
    End Sub

    Private Sub btnModificar_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Select Case _
            MessageBox.Show ( _
                "Cambiar el número de factura puede provocar la perdida del correlativo de facturas." + vbCrLf + _
                "¿Realmente desea cambiar el número de factura actual?", "Confirmación", MessageBoxButtons.YesNo, _
                MessageBoxIcon.Question)
            Case DialogResult.Yes
                Me.txtnumerofactura.Enabled = True
                txtnumerofactura.Focus()
        End Select
    End Sub
End Class
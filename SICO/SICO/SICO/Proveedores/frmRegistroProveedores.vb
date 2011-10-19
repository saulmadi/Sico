Imports SiCo.lgla
Imports SiCo.lgla2

Public Class frmRegistroProveedores
    Private _Proveedor As New Proveedores

    Public Property Proveedores() As Proveedores
        Get
            Return _Proveedor
        End Get
        Set (ByVal value As Proveedores)

            _Proveedor = value
            If Not value.PersonaJuridica Is Nothing Then
                CrtPersonaJuridica1.Persona = value.PersonaJuridica
            End If

            If value.IdContacto > 0 Then
                CrtPersonaNatural1.Persona.Id = value.IdContacto
            End If

        End Set
    End Property


    Private Sub frmRegistroProveedores_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        CrtListadoMantenimiento1.Entidad = New Proveedores
        CrtListadoMantenimiento1.lblDescripcion.Text = "Proveedor"

        PanelAccion1.BotonImprimir.Visible = False
        PanelAccion1.BotonImprimir.Enabled = False


    End Sub

    Private Sub CrtListadoMantenimiento1_Limpio() Handles CrtListadoMantenimiento1.Limpio
        CrtPersonaJuridica1.Persona = New PersonaJuridica
        CrtPersonaNatural1.Persona = New PersonaNatural

        CrtPersonaJuridica1.EtiquetaError = PanelAccion1.lblEstado
        CrtPersonaNatural1.EtiquetaError = PanelAccion1.lblEstado
    End Sub

    Private Sub CrtListadoMantenimiento1_SeleccionItem (ByVal Item As Object) _
        Handles CrtListadoMantenimiento1.SeleccionItem
        Me.Proveedores = CType (Item, Proveedores)
    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Me.Proveedores = New Proveedores
        Me.CrtPersonaNatural1.Nuevo()
        Me.CrtPersonaJuridica1.Nuevo()
        PanelAccion1.BarraProgreso.Value = 0
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim flag As Boolean = True
            If Me.Proveedores.Id > 0 Then
                Select Case _
                    MessageBox.Show ( _
                        "¿Esta seguro de modificar el proveedor " + Me.Proveedores.NombreMantenimiento + "?", _
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.No
                        flag = False

                End Select
            End If
            If flag Then
                PanelAccion1.lblEstado.Text = "Guardando..."
                PanelAccion1.BarraProgreso.Value = 50
                Me.Proveedores.IdContacto = CrtPersonaNatural1.Guardar
                Me.Proveedores.idEntidades = CrtPersonaJuridica1.Guardar
                If Me.Proveedores.IdContacto > 0 And Me.Proveedores.idEntidades > 0 Then
                    Me.Proveedores.Guardar()
                    PanelAccion1.BarraProgreso.Value = 100
                    PanelAccion1.lblEstado.Text = "Proveedor guardado correctamente."
                End If

            End If


        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PanelAccion1.lblEstado.Text = "Error al guardar el proveedor."
            PanelAccion1.BarraProgreso.Value = 0
        End Try
    End Sub

    Private Sub PanelAccion1_Eliminar() Handles PanelAccion1.Eliminar
        Try
            If Me.Proveedores.Eliminar() Then
                Me.Proveedores = New Proveedores
                Me.CrtPersonaNatural1.Nuevo()
                Me.CrtPersonaJuridica1.Nuevo()
            End If
        Catch ex As Exception
            MessageBox.Show (ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
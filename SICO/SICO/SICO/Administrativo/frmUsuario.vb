Imports SICO.lgla

Public Class frmUsuario
    Private _Usuario As New Usuario

    Public Property Usuario() As Usuario
        Get
            Return _Usuario
        End Get
        Set(ByVal value As Usuario)
            _Usuario = value
            txtusuario.Text = value.usuario
            cmbrol.SelectedValue = value.rol
            cmbhabilitado.SelectedIndex = value.Estado
            If value.rol > 0 Then
                cmbrol.SelectedIndex = value.rol - 1
            Else
                cmbrol.SelectedIndex = 0
            End If

            txtConfirmar.Text = ""
            txtcontrasena.Text = ""
            txtConfirmar.EsObligatorio = False
            txtcontrasena.EsObligatorio = False

            If Not value.sucursal Is Nothing Then
                cmbsucursal.SelectedValue = value.sucursal
            End If
            If Not value.PersonaNatural Is Nothing Then
                CrtPersonaNatural1.Persona = value.PersonaNatural
            End If
        End Set
    End Property

    Private Sub CrtPersonaNatural1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrtPersonaNatural1.Leave
        Try
            If CrtPersonaNatural1.PrimerApellido.Length > 0 And CrtPersonaNatural1.PrimerNombre.Length > 0 And Me.Usuario.Id = 0 Then
                txtusuario.Text = Usuario.CrearUsuario(Char.ToLower(CrtPersonaNatural1.PrimerNombre.First) + CrtPersonaNatural1.PrimerApellido.ToLower)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CrtListadoMantenimiento1_Limpio() Handles CrtListadoMantenimiento1.Limpio
        Me.Usuario = New Usuario
        CrtPersonaNatural1.Persona = New PersonaNatural
        Me.PanelAccion1.BarraProgreso.Value = 0
    End Sub

    Private Sub CrtListadoMantenimiento1_SeleccionItem(ByVal Item As System.Object) Handles CrtListadoMantenimiento1.SeleccionItem
        Me.Usuario = CType(Item, Usuario)
        Me.PanelAccion1.BarraProgreso.Value = 0
    End Sub

    Private Sub frmUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrtListadoMantenimiento1.Entidad = _Usuario
        CrtPersonaNatural1.EtiquetaError = Me.PanelAccion1.lblEstado
        CrtListadoMantenimiento1.lblDescripcion.Text = "Usuario"
        PanelAccion1.BotonImprimir.Visible = False
        PanelAccion1.BotonImprimir.Enabled = False
        PanelAccion1.BotonEliminar.Visible = False
        PanelAccion1.BotonEliminar.Enabled = False
        cmbrol.ValueMember = "valor"

    End Sub

    Private Sub PanelAccion1_Cancelar() Handles PanelAccion1.Cancelar
        Me.Close()
    End Sub

    Private Sub PanelAccion1_Guardar() Handles PanelAccion1.Guardar
        Try
            Dim flag As Boolean = True
            If Me.Usuario.Id > 0 Then
                Select Case MessageBox.Show("¿Esta seguro de modificar el usuario " + Me.Usuario.NombreMantenimiento + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.No
                        flag = False

                End Select
            End If

            If flag Then
                Me.PanelAccion1.lblEstado.Text = "Guardando..."
                Me.PanelAccion1.BarraProgreso.Value = 50
                Dim validador As New SICO.ctrla.Validador()
                If Me.Usuario.Id = 0 Then
                    txtcontrasena.EsObligatorio = True
                    txtConfirmar.EsObligatorio = True
                End If
                Me.Usuario.idEntidades = CrtPersonaNatural1.Guardar()

                validador.ColecionCajasTexto.Add(txtusuario)
                validador.ColecionCajasTexto.Add(txtcontrasena)
                validador.ColecionCajasTexto.Add(txtConfirmar)


                If txtConfirmar.Text.Trim = txtcontrasena.Text.Trim Then
                    If txtcontrasena.Text.Length = 0 Or txtcontrasena.Text.Length > 7 Then

                        If Me.Usuario.idEntidades > 0 Then


                            If validador.PermitirIngresar Then
                                Me.Usuario.usuario = txtusuario.Texto
                                If Not txtcontrasena.Text.Trim = String.Empty Then
                                    Me.Usuario.contrasena = txtcontrasena.Texto
                                End If
                                Me.Usuario.rol = CType(cmbrol.SelectedItem, SICO.lgla.Tipo).Valor
                                Me.Usuario.Estado = cmbhabilitado.SelectedItem.valor
                                Me.Usuario.Guardar()
                                Me.PanelAccion1.BarraProgreso.Value = 100
                                Me.PanelAccion1.lblEstado.Text = "Se guardo correctamente el usuario " + Me.Usuario.NombreMantenimiento
                            Else
                                Me.PanelAccion1.lblEstado.Text = validador.MensajesError
                            End If
                        End If
                    Else
                        Me.PanelAccion1.lblEstado.Text = ("Las contraseñas no puede ser menor de 8 caracteres...")
                        txtcontrasena.BackColor = txtcontrasena.ColorError
                        txtConfirmar.BackColor = txtConfirmar.ColorError
                    End If
                Else
                    Me.PanelAccion1.lblEstado.Text = ("Las contraseñas no coinciden...")
                    txtcontrasena.BackColor = txtcontrasena.ColorError
                    txtConfirmar.BackColor = txtConfirmar.ColorError
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.PanelAccion1.lblEstado.Text = ("Error al guardar el Usuario")
            Me.PanelAccion1.BarraProgreso.Value = 0
        End Try
    End Sub

    Private Sub PanelAccion1_Nuevo() Handles PanelAccion1.Nuevo
        Usuario = New Usuario
        CrtPersonaNatural1.Nuevo()
        Me.PanelAccion1.BarraProgreso.Value = 0
    End Sub
   
End Class
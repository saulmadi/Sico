Imports SiCo.lgla
Imports SiCo.lgla2
Imports System.ComponentModel
Imports System.Diagnostics
<Serializable()> _
Public Class crtPersonaNatural

#Region "Declaraciones"
    <NonSerialized()> _
    Private WithEvents _PersonaNatural As PersonaNatural
    Private _etiquetaError As Label
    Private _PersonaNaturalBusqueda As PersonaNatural
   
#End Region

#Region "Propiedades"

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False), EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Property Persona() As PersonaNatural
        Get
            Return _PersonaNatural
        End Get

        Set(ByVal value As PersonaNatural)
            _PersonaNatural = value
        End Set
    End Property

    Public Property EtiquetaError() As Label
        Get
            Return _etiquetaError
        End Get
        Set(ByVal value As Label)
            _etiquetaError = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Function Guardar() As Long
        Try
            Dim flag As Boolean = True
            If Persona.Id > 0 Then
                Select Case MessageBox.Show("La persona natural " + Me.Persona.NombreCompletoMostrar + " ya está registrada en el sistema. " + vbCrLf _
                                           + "¿Desea realizar modificar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case DialogResult.No
                        flag = False
                End Select

            End If
            If flag Then
                Dim validador As New SiCo.ctrla.Validador
                validador.ColecionCajasTexto.Add(txtPrimerNombre)
                validador.ColecionCajasTexto.Add(txtSegundoNombre)
                validador.ColecionCajasTexto.Add(txtPrimerApellido)
                validador.ColecionCajasTexto.Add(txtSegundoApellido)
                validador.ColecionCajasTexto.Add(txtidentifiacion)
                validador.ColecionCajasTexto.Add(txtCorreo)
                If validador.PermitirIngresar Then
                    Me.Persona.NombreCompleto = PersonaNatural.CrearNombreCompleto("", txtPrimerApellido.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text)
                    Me.Persona.identificacion = txtidentifiacion.Text
                    Me.Persona.tipoidentidad = cmbTipoIdentidad.SelectedItem
                    Me.Persona.rtn = txtrtn.Text
                    Me.Persona.correo = txtCorreo.Text
                    Me.Persona.telefono = txttelefono.Text
                    Me.Persona.telefono2 = txtCelular.Text
                    Me.Persona.direccion = txtdireccion.Text
                    Me.Persona.Guardar()
                    Return Persona.Id
                Else

                    Me.EtiquetaError.Text = validador.MensajesError
                    Return 0
                End If
            Else
                Return Persona.Id
            End If





        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
    End Function

#End Region

#Region "Eventos"

    Private Sub crtPersonaNatural_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _PersonaNatural = New PersonaNatural
            _PersonaNatural = New PersonaNatural
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaTipoIdentidad1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoIdentidad.SelectedIndexChanged
        If Not cmbTipoIdentidad.SelectedItem Is Nothing Then
            txtidentifiacion.TipoIdentificacion = cmbTipoIdentidad.SelectedItem
        End If
    End Sub

    Private Sub SubProceso_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SubProceso.DoWork
        Dim argument As Argumento = CType(e.Argument, Argumento)
        If argument.lista Is Nothing Then
            argument.persona.Buscar("nombrecompletoigual", argument.nombre)
        Else
            argument.persona.Buscar(argument.lista)
        End If
    End Sub

    Private Sub crtPersonaNatural_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSegundoNombre.Leave, txtSegundoApellido.Leave, txtPrimerNombre.Leave, txtPrimerApellido.Leave
        If txtPrimerNombre.Text <> String.Empty And txtPrimerApellido.Text <> String.Empty Then
            If Not SubProceso.IsBusy Then
                _PersonaNaturalBusqueda = New PersonaNatural
                Dim ar As New Argumento(_PersonaNaturalBusqueda, PersonaNatural.CrearNombreCompleto("", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text))
                SubProceso.RunWorkerAsync(ar)
            End If
        End If
    End Sub

    Private Sub SubProceso_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SubProceso.RunWorkerCompleted
        If e.Error Is Nothing Then
            If _PersonaNaturalBusqueda.TotalRegistros > 0 Then
                Me.Persona = _PersonaNaturalBusqueda
            End If
        Else
            MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        
    End Sub


#End Region

#Region "Clase Argmentos"
    Private Class Argumento
        Public persona As New PersonaNatural
        Public nombre As String
        Public lista As New List(Of SiCo.lgla.Parametro)
        Public Sub New(ByRef persona As PersonaNatural, ByVal nombre As String)
            Me.persona = persona
            Me.nombre = nombre
        End Sub
        Public Sub New(ByRef persona As PersonaNatural, ByRef lista As List(Of Parametro))
            Me.persona = persona
            Me.lista = lista
        End Sub
    End Class
#End Region



End Class

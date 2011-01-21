Imports SiCo.lgla
Imports SiCo.lgla2
Imports System.ComponentModel
Imports System.Diagnostics
<Serializable()> _
Public Class crtPersonaNatural
#Region "Declaraciones"
    <NonSerialized()> _
    Private WithEvents _PersonaNatural As PersonaNatural
    Private _etiquetaError As New ToolStripStatusLabel
    Private _PersonaNaturalBusqueda As PersonaNatural
    Private _RealizarBusquedaPor As BusquedaPor
    Private _SoloLectura As Boolean = False
    Private _RealizarBusquedaAutomatica As Boolean = True

    Public Event CambioPersona()
#End Region

#Region "Propiedades"

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False), EditorBrowsable(EditorBrowsableState.Advanced)> _
    Public Property Persona() As PersonaNatural
        Get
            Return _PersonaNatural
        End Get

        Set(ByVal value As PersonaNatural)
            _PersonaNatural = value
            RaiseEvent CambioPersona()
        End Set
    End Property

    Public Property EtiquetaError() As ToolStripStatusLabel
        Get
            Return _etiquetaError
        End Get
        Set(ByVal value As ToolStripStatusLabel)
            _etiquetaError = value
        End Set
    End Property

    Public Property SoloLectura() As Boolean
        Get
            Return _SoloLectura
        End Get

        Set(ByVal value As Boolean)
            Try
                _SoloLectura = value
                txtPrimerNombre.ReadOnly = value
                txtPrimerApellido.ReadOnly = value
                txtSegundoApellido.ReadOnly = value
                txtSegundoNombre.ReadOnly = value
                'cmbTipoIdentidad.Enabled = Not value
                txtidentifiacion.ReadOnly = value
                txtrtn.ReadOnly = value
                txtCorreo.ReadOnly = value
                txttelefono.ReadOnly = value
                txtCelular.ReadOnly = value
                txtdireccion.ReadOnly = value
            Catch ex As Exception

            End Try
            
        End Set
    End Property

    Public Property RealizarBusquedaAutomarita() As Boolean
        Get
            Return _RealizarBusquedaAutomatica
        End Get
        Set(ByVal value As Boolean)
            _RealizarBusquedaAutomatica = value
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
                    Me.Persona.NombreCompleto = PersonaNatural.CrearNombreCompleto("", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text)
                    Me.Persona.identificacion = txtidentifiacion.Text
                    Me.Persona.tipoidentidad = cmbTipoIdentidad.SelectedItem
                    Me.Persona.rtn = txtrtn.Texto
                    Me.Persona.correo = txtCorreo.Texto
                    Me.Persona.telefono = txttelefono.ValorInt
                    Me.Persona.telefono2 = txtCelular.ValorInt
                    Me.Persona.direccion = txtdireccion.Texto
                    Me.Persona.Guardar()
                    Return Persona.Id
                Else
                    lblEstado.Text = validador.MensajesError
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

    Public Sub Nuevo()
        Me.Persona = New PersonaNatural()
        txtPrimerNombre.Focus()
    End Sub

#End Region

#Region "Eventos"

    Private Sub crtPersonaNatural_CambioPersona() Handles Me.CambioPersona
        If Persona.Id > 0 Then
            PersonaNatural.CrearNombreCompleto(Me.Persona.NombreCompleto, txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text)
        Else
            txtPrimerNombre.Text = ""
            txtPrimerApellido.Text = ""
            txtSegundoApellido.Text = ""
            txtSegundoNombre.Text = ""
        End If

        cmbTipoIdentidad.SelectedValue = Persona.tipoidentidad.Valor
        txtidentifiacion.Text = Persona.identificacion
        txtrtn.Text = Persona.rtn
        txtCorreo.Text = Persona.correo
        txttelefono.ValorInt = Persona.telefono
        txtCelular.ValorInt = Persona.telefono2
        txtdireccion.Text = Persona.direccion

    End Sub

    Private Sub crtPersonaNatural_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _PersonaNatural = New PersonaNatural
            _PersonaNatural = New PersonaNatural
            lblEstado.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListaTipoIdentidad1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoIdentidad.SelectedIndexChanged
        If Not cmbTipoIdentidad.SelectedItem Is Nothing Then
            txtidentifiacion.TipoIdentificacion = cmbTipoIdentidad.SelectedItem
            _RealizarBusquedaPor = BusquedaPor.Identidad
        End If
    End Sub

    Private Sub SubProceso_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SubProceso.DoWork
        Dim argument As Argumento = CType(e.Argument, Argumento)
        If argument.lista.Count = 0 Then
            argument.persona.Buscar("nombrecompletoigual", argument.nombre)
        Else
            argument.persona.Buscar(argument.lista)
        End If
    End Sub

    Private Sub crtPersonaNatural_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSegundoNombre.Leave, txtSegundoApellido.Leave, txtPrimerNombre.Leave, txtPrimerApellido.Leave
        If Me.RealizarBusquedaAutomarita Then
            If txtPrimerNombre.Text <> String.Empty And txtPrimerApellido.Text <> String.Empty And _RealizarBusquedaPor = BusquedaPor.Nombre Then
                If Not SubProceso.IsBusy Then
                    Me.Cursor = Cursors.WaitCursor
                    lblEstado.Text = "Buscando..."
                    Me.RealizarBusquedaAutomarita = False
                    Me.SoloLectura = True
                    _PersonaNaturalBusqueda = New PersonaNatural
                    Dim ar As New Argumento(_PersonaNaturalBusqueda, PersonaNatural.CrearNombreCompleto("", txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text))
                    Me.Cursor = Cursors.WaitCursor
                    If Not SubProceso.IsBusy Then SubProceso.RunWorkerAsync(ar)
                End If
            End If
        End If
    End Sub

    Private Sub txtidentifiacion_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtidentifiacion.Leave
        If RealizarBusquedaAutomarita Then
            If txtidentifiacion.Text <> String.Empty And _RealizarBusquedaPor = BusquedaPor.Identidad Then
                If Not SubProceso.IsBusy Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.SoloLectura = True
                    Me.RealizarBusquedaAutomarita = False
                    lblEstado.Text = "Buscando..."
                    _PersonaNaturalBusqueda = New PersonaNatural
                    Dim listemp As New List(Of Parametro)
                    listemp.Add(New Parametro("identificacion", txtidentifiacion.Text))
                    listemp.Add(New Parametro("tipoidentificacion", cmbTipoIdentidad.SelectedValue))
                    Dim ar As New Argumento(_PersonaNaturalBusqueda, listemp)
                    If Not SubProceso.IsBusy Then SubProceso.RunWorkerAsync(ar)
                End If
            End If
        End If
    End Sub

    Private Sub SubProceso_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SubProceso.RunWorkerCompleted
        Me.Cursor = Cursors.Default
        Me.SoloLectura = False
        lblEstado.Text = ""
        Me.RealizarBusquedaAutomarita = True
        If e.Error Is Nothing Then
            If _PersonaNaturalBusqueda.TotalRegistros > 0 And _PersonaNaturalBusqueda.Id <> Me.Persona.Id Then
                Me._RealizarBusquedaPor = BusquedaPor.Nada
                Me.Persona = _PersonaNaturalBusqueda
            End If
        Else
            MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub txtPrimerNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSegundoNombre.KeyPress, txtSegundoApellido.KeyPress, txtPrimerNombre.KeyPress, txtPrimerApellido.KeyPress
        _RealizarBusquedaPor = BusquedaPor.Nombre
    End Sub

    Private Sub txtidentifiacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtidentifiacion.KeyPress
        _RealizarBusquedaPor = BusquedaPor.Identidad
    End Sub

    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Dim f As New frmBusqueda(New PersonaNatural)
        f.Grid.AutoGenerateColumns = True
        f.Grid.DarFormato("NombreCompletoMostrar", "Nombre Completo", True)
        f.Grid.DarFormato("identificacion", "Identifación", True)
        f.Grid.DarFormato("telefono", "Télefono", True)
        f.Grid.DarFormato("telefono2", "Celular", True)
        f.Grid.DarFormato("correo", "Correo", True)
        f.VerParametros = False

        Dim p As String = String.Empty
        If txtPrimerNombre.Text <> String.Empty Then
            p = txtPrimerNombre.Text
        End If

        If txtSegundoNombre.Text <> String.Empty Then
            p += " " + txtSegundoNombre.Text
        End If
        If txtPrimerApellido.Text <> String.Empty Then
            p += " " + txtPrimerApellido.Text
        End If
        If txtSegundoApellido.Text <> String.Empty Then
            p = txtPrimerNombre.Text
        End If
        If p.Trim <> String.Empty Then
            f.cargar("nombrecompleto", p)
            If f.ShowDialog() = DialogResult.OK Then
                Me.Persona = f.Entidad
            End If
            Me.lblEstado.Text = ""
        Else
            Me.lblEstado.Text = "Ingrese un nombre para poder realizar la busqueda"
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

#Region "Enumerador"
    Protected Enum BusquedaPor
        Nombre = 0
        Identidad = 1
        Nada = 2
    End Enum
#End Region

End Class
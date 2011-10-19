Imports System.ComponentModel
Imports SiCo.ctrla
Imports SiCo.lgla

<Serializable()> _
Public Class crtPersonaNatural

#Region "Declaraciones"

    <NonSerialized()> Private WithEvents _PersonaNatural As PersonaNatural
    Private _etiquetaError As New ToolStripStatusLabel
    Private _PersonaNaturalBusqueda As PersonaNatural
    Private _RealizarBusquedaPor As BusquedaPor
    Private _SoloLectura As Boolean = False
    Private _RealizarBusquedaAutomatica As Boolean = True
    Private _size As Size

    Public Event CambioPersona()

#End Region

#Region "Constructor"

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        _size = New Size (Me.Size)

    End Sub

#End Region

#Region "Propiedades"

    <DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden), Browsable (False), _
        EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Property Persona() As PersonaNatural
        Get
            Return _PersonaNatural
        End Get

        Set (ByVal value As PersonaNatural)
            _PersonaNatural = value
            RaiseEvent CambioPersona()
        End Set
    End Property

    Public Property EtiquetaError() As ToolStripStatusLabel
        Get
            Return _etiquetaError
        End Get
        Set (ByVal value As ToolStripStatusLabel)
            _etiquetaError = value
        End Set
    End Property

    Public Property SoloLectura() As Boolean

        Get
            Return _SoloLectura
        End Get

        Set (ByVal value As Boolean)
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
        Set (ByVal value As Boolean)
            _RealizarBusquedaAutomatica = value
        End Set
    End Property

    Public ReadOnly Property PrimerNombre() As String
        Get
            Return txtPrimerNombre.Text
        End Get
    End Property

    Public ReadOnly Property SegundoNombre() As String
        Get
            Return txtSegundoNombre.Text
        End Get
    End Property

    Public ReadOnly Property PrimerApellido() As String
        Get
            Return txtPrimerApellido.Text
        End Get
    End Property

    Public ReadOnly Property SegundoApellido() As String
        Get
            Return txtSegundoApellido.Text
        End Get
    End Property

    Public Shadows Property Enabled() As Boolean
        Get
            Return txtPrimerApellido.Enabled
        End Get
        Set (ByVal value As Boolean)
            txtPrimerNombre.Enabled = value
            txtSegundoNombre.Enabled = value
            txtPrimerApellido.Enabled = value
            txtSegundoApellido.Enabled = value
            cmbTipoIdentidad.Enabled = value
            txtidentifiacion.Enabled = value
            txtCorreo.Enabled = value
            txtrtn.Enabled = value
            txttelefono.Enabled = value
            txtCelular.Enabled = value
            txtdireccion.Enabled = value
            btnbuscar.Enabled = value
        End Set
    End Property

    Public Property VisibleDatosSecundarios() As Boolean
        Get
            Return Panel3.Visible
        End Get
        Set (ByVal value As Boolean)
            Panel3.Visible = value
            If Not value Then
                If Me.Size.Height > (Me.Panel1.Size.Height + Me.Panel2.Size.Height) Then
                    Me.Size = New Size (Me.Width, Size.Subtract (Me.Size, Panel3.Size).Height)
                Else
                    Me.Size = New Size (_size)
                End If
            Else
                If Me.Size.Height < (Me.Panel3.Size.Height + Me.Panel2.Size.Height + Me.Panel1.Size.Height) Then
                    Me.Size = New Size (Me.Width, Size.Add (Me.Size, Panel3.Size).Height)
                Else
                    Me.Size = New Size (_size)
                End If
            End If
        End Set
    End Property

#End Region

#Region "Metodos"

    Public Function Guardar() As Long
        Try
            Dim flag As Boolean = True
            If Persona.Id > 0 Then
                Select Case _
                    MessageBox.Show ( _
                        "La persona natural " + Me.Persona.NombreCompletoMostrar + " ya está registrada en el sistema. " + _
                        vbCrLf _
                        + "¿Desea realizar modificar el registro?", "Confirmación", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question)
                    Case DialogResult.No
                        flag = False
                End Select
            End If
            If flag Then
                Dim validador As New Validador
                validador.ColecionCajasTexto.Add (txtPrimerNombre)
                validador.ColecionCajasTexto.Add (txtSegundoNombre)
                validador.ColecionCajasTexto.Add (txtPrimerApellido)
                validador.ColecionCajasTexto.Add (txtSegundoApellido)
                validador.ColecionCajasTexto.Add (txtidentifiacion)
                validador.ColecionCajasTexto.Add (txtCorreo)
                If txtidentifiacion.TipoIdentificacion.Valor = "N" Then
                    txtidentifiacion.EsObligatorio = False
                Else
                    txtidentifiacion.EsObligatorio = True
                End If

                If validador.PermitirIngresar Then
                    Me.Persona.NombreCompleto = PersonaNatural.CrearNombreCompleto ("", txtPrimerNombre.Text, _
                                                                                    txtSegundoNombre.Text, _
                                                                                    txtPrimerApellido.Text, _
                                                                                    txtSegundoApellido.Text)
                    Me.Persona.tipoidentidad = cmbTipoIdentidad.SelectedItem
                    Me.Persona.identificacion = txtidentifiacion.Text
                    If Me.Persona.tipoidentidad.Valor = "N" Then
                        Me.Persona.identificacion = Guid.NewGuid().ToString
                    End If
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
            Throw New ApplicationException (ex.Message)
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
            PersonaNatural.CrearNombreCompleto (Me.Persona.NombreCompleto, txtPrimerNombre.Text, txtSegundoNombre.Text, _
                                                txtPrimerApellido.Text, txtSegundoApellido.Text)
        Else
            txtPrimerNombre.Text = ""
            txtPrimerApellido.Text = ""
            txtSegundoApellido.Text = ""
            txtSegundoNombre.Text = ""
        End If
        Dim x As Integer = 0
        ''cmbTipoIdentidad.SelectedIndex = 0
        For Each i As Object In cmbTipoIdentidad.Items
            If CType (i, ListaTipoIdentidad.ListaTipoIdentidad).Valor = Persona.tipoidentidad.Valor Then
                cmbTipoIdentidad.SelectedIndex = x
                Exit For
            End If
            x += 1
        Next
        cmbTipoIdentidad.SelectedValue = Persona.tipoidentidad.Valor
        If Persona.tipoidentidad.Valor = "N" Then
            txtidentifiacion.Text = ""
        Else
            txtidentifiacion.Text = Persona.identificacion
        End If


        txtrtn.Text = Persona.rtn
        txtCorreo.Text = Persona.correo
        txttelefono.ValorInt = Persona.telefono
        txtCelular.ValorInt = Persona.telefono2
        txtdireccion.Text = Persona.direccion

        If Me.Persona.Id = 0 Then
            Me.Enabled = True
            Me.lblEstado.Text = ""
        Else
            Me.Enabled = False
            Me.lblEstado.Text = "Persona natural " + Me.txtPrimerNombre.Text + " " + Me.txtPrimerApellido.Text + _
                                " cargado(a)."
        End If
    End Sub

    Private Sub crtPersonaNatural_Load (ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            _PersonaNatural = New PersonaNatural
            _PersonaNaturalBusqueda = New PersonaNatural
            lblEstado.Text = ""
            Dim tool As New ToolTip (Me.components)
            tool.SetToolTip (btnModificar, "Modificar")
            tool.Active = True

            Dim tool2 As New ToolTip (Me.components)
            tool2.SetToolTip (btnNueva, "Nuevo")
            tool2.Active = True

            Dim tool3 As New ToolTip (Me.components)
            tool3.SetToolTip (btnbuscar, "Buscar")
            tool3.Active = True

        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListaTipoIdentidad1_SelectedIndexChanged (ByVal sender As Object, ByVal e As EventArgs) _
        Handles cmbTipoIdentidad.SelectedIndexChanged
        If Not cmbTipoIdentidad.SelectedItem Is Nothing Then
            txtidentifiacion.TipoIdentificacion = cmbTipoIdentidad.SelectedItem
            _RealizarBusquedaPor = BusquedaPor.Identidad
        End If
    End Sub

    Private Sub SubProceso_DoWork (ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles SubProceso.DoWork
        Dim argument As Argumento = CType (e.Argument, Argumento)
        If argument.lista.Count = 0 Then
            argument.persona.Buscar ("nombrecompletoigual", argument.nombre)
        Else
            argument.persona.Buscar (argument.lista)
        End If
    End Sub

    Private Sub crtPersonaNatural_Leave (ByVal sender As Object, ByVal e As EventArgs) _
        Handles txtSegundoNombre.Leave, txtSegundoApellido.Leave, txtPrimerNombre.Leave, txtPrimerApellido.Leave
        If Me.RealizarBusquedaAutomarita Then
            If _
                txtPrimerNombre.Text <> String.Empty And txtPrimerApellido.Text <> String.Empty And _
                _RealizarBusquedaPor = BusquedaPor.Nombre Then
                If Not SubProceso.IsBusy Then
                    Me.Cursor = Cursors.WaitCursor
                    lblEstado.Text = "Buscando..."
                    Me.RealizarBusquedaAutomarita = False
                    Me.SoloLectura = True
                    _PersonaNaturalBusqueda = New PersonaNatural
                    Dim _
                        ar As _
                            New Argumento (_PersonaNaturalBusqueda, _
                                           PersonaNatural.CrearNombreCompleto ("", txtPrimerNombre.Text, _
                                                                               txtSegundoNombre.Text, _
                                                                               txtPrimerApellido.Text, _
                                                                               txtSegundoApellido.Text))
                    Me.Cursor = Cursors.WaitCursor
                    If Not SubProceso.IsBusy Then SubProceso.RunWorkerAsync (ar)
                End If
            End If
        End If
    End Sub

    Private Sub txtidentifiacion_Leave (ByVal sender As Object, ByVal e As EventArgs) Handles txtidentifiacion.Leave
        If RealizarBusquedaAutomarita Then
            If txtidentifiacion.Text <> String.Empty And _RealizarBusquedaPor = BusquedaPor.Identidad Then
                If Not SubProceso.IsBusy Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.SoloLectura = True
                    Me.RealizarBusquedaAutomarita = False
                    lblEstado.Text = "Buscando..."
                    _PersonaNaturalBusqueda = New PersonaNatural
                    Dim listemp As New List(Of Parametro)
                    listemp.Add (New Parametro ("identificacion", txtidentifiacion.Text))
                    listemp.Add (New Parametro ("tipoidentificacion", cmbTipoIdentidad.SelectedValue))
                    Dim ar As New Argumento (_PersonaNaturalBusqueda, listemp)
                    If Not SubProceso.IsBusy Then SubProceso.RunWorkerAsync (ar)
                End If
            End If
        End If
    End Sub

    Private Sub SubProceso_RunWorkerCompleted (ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
        Handles SubProceso.RunWorkerCompleted
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
            MessageBox.Show (e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub txtPrimerNombre_KeyPress (ByVal sender As Object, ByVal e As KeyPressEventArgs) _
        Handles txtSegundoNombre.KeyPress, txtSegundoApellido.KeyPress, txtPrimerNombre.KeyPress, _
                txtPrimerApellido.KeyPress
        If Char.IsLetter (e.KeyChar) Then
            _RealizarBusquedaPor = BusquedaPor.Nombre
        End If

    End Sub

    Private Sub txtidentifiacion_KeyPress (ByVal sender As Object, ByVal e As KeyPressEventArgs) _
        Handles txtidentifiacion.KeyPress
        If Char.IsLetter (e.KeyChar) Or Char.IsNumber (e.KeyChar) Then
            _RealizarBusquedaPor = BusquedaPor.Identidad
        End If
    End Sub

    Private Sub btnbuscar_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnbuscar.Click
        Dim f As New frmBusqueda (New PersonaNatural)
        f.Grid.AutoGenerateColumns = True
        f.Grid.DarFormato ("NombreCompletoMostrar", "Nombre Completo", True)
        f.Grid.DarFormato ("IdentificacionMostrar", "Identificación", True)
        f.Grid.DarFormato ("telefono", "Télefono", True)
        f.Grid.DarFormato ("telefono2", "Celular", True)
        f.Grid.DarFormato ("correo", "Correo", True)
        f.VerParametros = False

        Dim p As String = String.Empty
        If txtPrimerNombre.Text <> String.Empty Then
            p = txtPrimerNombre.Text + " "
        End If

        If txtSegundoNombre.Text <> String.Empty Then
            p += IIf (p.Trim.Length = 0, "%", "").ToString + txtSegundoNombre.Text + " "
        End If
        If txtPrimerApellido.Text <> String.Empty Then
            p += IIf (p.Trim.Length = 0, "%", "").ToString + txtPrimerApellido.Text + " "
        End If
        If txtSegundoApellido.Text <> String.Empty Then
            p = IIf (p.Trim.Length = 0, "%", "").ToString + txtSegundoApellido.Text
        End If
        If p.Trim <> String.Empty Then
            f.cargar ("nombrecompleto", p.Trim)
            If f.ShowDialog() = DialogResult.OK Then
                Me.Persona = f.Entidad
            End If
            Me.lblEstado.Text = ""
        Else
            Me.lblEstado.Text = "Ingrese un nombre para poder realizar la busqueda"
        End If
    End Sub

    Private Sub btnNueva_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnNueva.Click
        Me.Nuevo()
    End Sub

    Private Sub btnModificar_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Me.Enabled = True
    End Sub

    Private Sub _PersonaNatural_CambioId() Handles _PersonaNatural.CambioId
        If _PersonaNatural.Id > 0 Then
            Me.Persona = _PersonaNatural
        End If

    End Sub

#End Region

#Region "Clase Argmentos"

    Private Class Argumento
        Public persona As New PersonaNatural
        Public nombre As String
        Public lista As New List(Of Parametro)

        Public Sub New (ByRef persona As PersonaNatural, ByVal nombre As String)
            Me.persona = persona
            Me.nombre = nombre
        End Sub

        Public Sub New (ByRef persona As PersonaNatural, ByRef lista As List(Of Parametro))
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
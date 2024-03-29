﻿Imports System.ComponentModel
Imports SiCo.ctrla
Imports SiCo.lgla

Public Class crtPersonaJuridica

#Region "Declaraciones"

    Private WithEvents _Persona As PersonaJuridica
    Private _PersonaBusqueda As PersonaJuridica
    Private _etiquetaError As New ToolStripStatusLabel
    Private _RealizarBusquedaPor As BusquedaPor
    Private _SoloLectura As Boolean = False
    Private _RealizarBusquedaAutomatica As Boolean = True
    Private _HabilitarRTN As Boolean = True
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

    Public Property TextoRazonSocial() As String
        Get
            Return lblRazonSocial.Text
        End Get
        Set (ByVal value As String)
            lblRazonSocial.Text = value
        End Set
    End Property

    <DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden), Browsable (False), _
        EditorBrowsable (EditorBrowsableState.Advanced)> _
    Public Property Persona() As PersonaJuridica
        Get
            Return _Persona
        End Get
        Set (ByVal value As PersonaJuridica)
            _Persona = value
            RaiseEvent CambioPersona()
        End Set
    End Property

    Public Property SoloLectura() As Boolean
        Get
            Return _SoloLectura
        End Get

        Set (ByVal value As Boolean)
            Try
                _SoloLectura = value
                txtrazonsocial.ReadOnly = value
                txtfax.ReadOnly = value
                txtrtn.ReadOnly = value
                txtcorreo.ReadOnly = value
                txttelefono.ReadOnly = value
                txtdireccion.ReadOnly = value
            Catch ex As Exception

            End Try

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

    Public Property RealizarBusquedaAutomarita() As Boolean
        Get
            Return _RealizarBusquedaAutomatica
        End Get
        Set (ByVal value As Boolean)
            _RealizarBusquedaAutomatica = value
        End Set
    End Property

    Public Property HabilitarRTN() As Boolean
        Get
            Return _HabilitarRTN
        End Get
        Set (ByVal value As Boolean)
            _HabilitarRTN = value
            txtrtn.Enabled = value
        End Set
    End Property

    Public Shadows Property Enabled() As Boolean
        Get
            Return txtrazonsocial.Enabled
        End Get
        Set (ByVal value As Boolean)
            txtrazonsocial.Enabled = value
            txttelefono.Enabled = value
            txtfax.Enabled = value
            If Me.HabilitarRTN Then
                Me.txtrtn.Enabled = value
            End If
            txtcorreo.Enabled = value
            txtdireccion.Enabled = value
            txtdireccion.BackColor = txtrazonsocial.BackColor
            btnbuscar.Enabled = value
        End Set
    End Property

    Public Property VisiblesDatosSecundarios() As Boolean
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
                        "La persona jurídica " + Me.Persona.RazonSocial + " ya está registrada en el sistema. " + vbCrLf _
                        + "¿Desea realizar modificar el registro?", "Confirmación", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question)
                    Case DialogResult.No
                        flag = False
                End Select
            End If
            If flag Then
                Dim validador As New Validador
                validador.ColecionCajasTexto.Add (txtrazonsocial)
                validador.ColecionCajasTexto.Add (txtrtn)
                validador.ColecionCajasTexto.Add (txtcorreo)
                If validador.PermitirIngresar Then
                    Me.Persona.RazonSocial = txtrazonsocial.Text
                    Me.Persona.rtn = txtrtn.Texto
                    Me.Persona.correo = txtcorreo.Texto
                    Me.Persona.telefono = txttelefono.ValorInt
                    Me.Persona.telefono2 = txtfax.ValorInt
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
        Me.Persona = New PersonaJuridica
        txtrazonsocial.Focus()
    End Sub

#End Region

#Region "Eventos"

    Private Sub crtPersonaJuridica_CambioPersona() Handles Me.CambioPersona
        If Not Me.Persona Is Nothing Then
            txtrazonsocial.Text = Persona.RazonSocial
            txtrtn.Text = Persona.rtn
            txtcorreo.Text = Persona.correo
            txttelefono.ValorInt = Persona.telefono
            txtfax.ValorInt = Persona.telefono2
            txtdireccion.Text = Persona.direccion

            If Persona.Id = 0 Then
                Me.Enabled = True
                Me.lblEstado.Text = ""
            Else
                Me.Enabled = False
                Me.lblEstado.Text = "Persona jurídica " + Me.txtrazonsocial.Text + " cargada."
            End If
        Else
            Me.Persona = New PersonaJuridica

        End If

    End Sub

    Private Sub crtPersonaJuridica_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        lblEstado.Text = ""
        Try
            _Persona = New PersonaJuridica
            txtrazonsocial.Entidad = New PersonaJuridica()

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

    Private Sub btnbuscar_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnbuscar.Click
        Dim f As New frmBusqueda (New PersonaJuridica)
        f.Grid.AutoGenerateColumns = True
        f.Grid.DarFormato ("razonsocial", "Razón Social", True)
        f.Grid.DarFormato ("rtn", "RTN", True)
        f.Grid.DarFormato ("telefono", "Télefono", True)
        f.Grid.DarFormato ("telefono2", "Fax", True)
        f.Grid.DarFormato ("correo", "Correo", True)
        f.VerParametros = False


        If txtrazonsocial.Text <> String.Empty Then
            f.cargar ("razonsocial", txtrazonsocial.Text)
            If f.ShowDialog() = DialogResult.OK Then
                Me.Persona = f.Entidad
            End If
            Me.lblEstado.Text = ""
        Else
            Me.lblEstado.Text = "Ingrese un nombre para poder realizar la busqueda"
        End If
    End Sub

    Private Sub txtNombre_Leave (ByVal sender As Object, ByVal e As EventArgs) Handles txtrazonsocial.Leave
        If Me.RealizarBusquedaAutomarita Then
            If txtrazonsocial.Text <> String.Empty And _RealizarBusquedaPor = BusquedaPor.RazonSocial Then
                If Not SubProceso.IsBusy Then
                    Me.Cursor = Cursors.WaitCursor
                    lblEstado.Text = "Buscando..."
                    Me.RealizarBusquedaAutomarita = False
                    Me.SoloLectura = True
                    _PersonaBusqueda = New PersonaJuridica
                    Dim ar As New Argumento (_PersonaBusqueda, txtrazonsocial.Text, "razonsocialigual")
                    Me.Cursor = Cursors.WaitCursor
                    If Not SubProceso.IsBusy Then SubProceso.RunWorkerAsync (ar)
                End If
            End If
        End If
    End Sub

    Private Sub SubProceso_DoWork (ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles SubProceso.DoWork
        Dim argument As Argumento = CType (e.Argument, Argumento)

        argument.persona.Buscar (argument.parametro, argument.nombre)

    End Sub

    Private Sub SubProceso_RunWorkerCompleted (ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
        Handles SubProceso.RunWorkerCompleted
        Me.Cursor = Cursors.Default
        Me.SoloLectura = False
        lblEstado.Text = ""
        Me.RealizarBusquedaAutomarita = True
        If e.Error Is Nothing Then
            If _PersonaBusqueda.TotalRegistros > 0 And _PersonaBusqueda.Id <> Me.Persona.Id Then
                Me._RealizarBusquedaPor = BusquedaPor.Nada
                Me.Persona = _PersonaBusqueda
            End If
        Else
            MessageBox.Show (e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub txtrazonsocial_KeyPress (ByVal sender As Object, ByVal e As KeyPressEventArgs) _
        Handles txtrazonsocial.KeyPress
        If Char.IsLetter (e.KeyChar) Then
            _RealizarBusquedaPor = BusquedaPor.RazonSocial
        End If
    End Sub

    Private Sub txtrtn_KeyPress (ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Char.IsLetter (e.KeyChar) Or Char.IsNumber (e.KeyChar) Then
            _RealizarBusquedaPor = BusquedaPor.rtn
        End If

    End Sub

    Private Sub txtrtn_Leave (ByVal sender As Object, ByVal e As EventArgs)
        If Me.RealizarBusquedaAutomarita Then
            If txtrtn.Text <> String.Empty And _RealizarBusquedaPor = BusquedaPor.rtn Then
                If Not SubProceso.IsBusy Then
                    Me.Cursor = Cursors.WaitCursor
                    lblEstado.Text = "Buscando..."
                    Me.RealizarBusquedaAutomarita = False
                    Me.SoloLectura = True
                    _PersonaBusqueda = New PersonaJuridica
                    Dim ar As New Argumento (_PersonaBusqueda, txtrtn.Text, "rtn")
                    Me.Cursor = Cursors.WaitCursor
                    If Not SubProceso.IsBusy Then SubProceso.RunWorkerAsync (ar)
                End If
            End If
        End If
    End Sub

    Private Sub btnNueva_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnNueva.Click
        Me.Nuevo()
    End Sub

    Private Sub btnModificar_Click (ByVal sender As Object, ByVal e As EventArgs) Handles btnModificar.Click
        Me.Enabled = True
    End Sub

    Private Sub _Persona_CambioId() Handles _Persona.CambioId
        If _Persona.Id > 0 Then
            Me.Persona = _Persona
        End If
    End Sub

#End Region

#Region "ClaseArgumento"

    Private Class Argumento
        Public persona As New PersonaJuridica
        Public nombre As String
        Public parametro As String

        Public Sub New (ByRef persona As PersonaJuridica, ByVal nombre As String, ByVal parametro As String)
            Me.persona = persona
            Me.nombre = nombre
            Me.parametro = parametro
        End Sub
    End Class

#End Region

#Region "Enumerador"

    Protected Enum BusquedaPor
        RazonSocial = 0
        rtn = 1
        Nada = 2
    End Enum

#End Region
End Class

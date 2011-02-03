<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuario))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CrtListadoMantenimiento1 = New SICO.ctrla2.crtListadoMantenimiento
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbSucursal = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.cmbrol = New SICO.ctrla2.ListaRoles(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtConfirmar = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbhabilitado = New SICO.ctrla2.ListaHabilitados(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtcontrasena = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtusuario = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CrtPersonaNatural1 = New SICO.ctrla2.crtPersonaNatural
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CrtListadoMantenimiento1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 415)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'CrtListadoMantenimiento1
        '
        Me.CrtListadoMantenimiento1.CampoAMostrar = "NombreMantenimiento"
        Me.CrtListadoMantenimiento1.CaracteresInicioBusqueda = 3
        Me.CrtListadoMantenimiento1.CaracteresSegundaBusqueda = 6
        Me.CrtListadoMantenimiento1.CargarInicio = False
        Me.CrtListadoMantenimiento1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtListadoMantenimiento1.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento1.Name = "CrtListadoMantenimiento1"
        Me.CrtListadoMantenimiento1.NombreParametroBusqueda = "entidadnombre"
        Me.CrtListadoMantenimiento1.Size = New System.Drawing.Size(251, 396)
        Me.CrtListadoMantenimiento1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSucursal)
        Me.GroupBox2.Controls.Add(Me.cmbrol)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtConfirmar)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbhabilitado)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtcontrasena)
        Me.GroupBox2.Controls.Add(Me.txtusuario)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(275, 340)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(500, 193)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.CargarAutoCompletar = False
        Me.cmbSucursal.CargarComboBox = True
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(109, 124)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.ParametroAutocompletar = Nothing
        Me.cmbSucursal.ParametroBusquedaPadre = Nothing
        Me.cmbSucursal.Size = New System.Drawing.Size(377, 21)
        Me.cmbSucursal.TabIndex = 12
        '
        'cmbrol
        '
        Me.cmbrol.DisplayMember = "Descripcion"
        Me.cmbrol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbrol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbrol.FormattingEnabled = True
        Me.cmbrol.Location = New System.Drawing.Point(109, 97)
        Me.cmbrol.Name = "cmbrol"
        Me.cmbrol.Size = New System.Drawing.Size(377, 21)
        Me.cmbrol.TabIndex = 4
        Me.cmbrol.ValueMember = "Valor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Rol de usuario"
        '
        'txtConfirmar
        '
        Me.txtConfirmar.ColorError = System.Drawing.Color.Red
        Me.txtConfirmar.EnterPorTab = True
        Me.txtConfirmar.EsObligatorio = False
        Me.txtConfirmar.ExpresionValidacion = ""
        Me.txtConfirmar.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.txtConfirmar.Location = New System.Drawing.Point(108, 70)
        Me.txtConfirmar.MaxLength = 255
        Me.txtConfirmar.MensajeError = "Debe confirmar la contraseña"
        Me.txtConfirmar.Name = "txtConfirmar"
        Me.txtConfirmar.Size = New System.Drawing.Size(378, 21)
        Me.txtConfirmar.TabIndex = 2
        Me.txtConfirmar.Texto = Nothing
        Me.txtConfirmar.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtConfirmar.UseSystemPasswordChar = True
        Me.txtConfirmar.ValorInt = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Confirmar"
        '
        'cmbhabilitado
        '
        Me.cmbhabilitado.DisplayMember = "Descripcion"
        Me.cmbhabilitado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbhabilitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbhabilitado.FormattingEnabled = True
        Me.cmbhabilitado.Location = New System.Drawing.Point(108, 151)
        Me.cmbhabilitado.Name = "cmbhabilitado"
        Me.cmbhabilitado.SelectedItem = CType(resources.GetObject("cmbhabilitado.SelectedItem"), SICO.lgla2.Estado)
        Me.cmbhabilitado.Size = New System.Drawing.Size(378, 21)
        Me.cmbhabilitado.TabIndex = 5
        Me.cmbhabilitado.ValueMember = "valor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Estado"
        '
        'txtcontrasena
        '
        Me.txtcontrasena.ColorError = System.Drawing.Color.Red
        Me.txtcontrasena.EnterPorTab = True
        Me.txtcontrasena.EsObligatorio = False
        Me.txtcontrasena.ExpresionValidacion = ""
        Me.txtcontrasena.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.txtcontrasena.Location = New System.Drawing.Point(109, 43)
        Me.txtcontrasena.MaxLength = 255
        Me.txtcontrasena.MensajeError = "La contraseña no puede ser vacía"
        Me.txtcontrasena.Name = "txtcontrasena"
        Me.txtcontrasena.Size = New System.Drawing.Size(378, 21)
        Me.txtcontrasena.TabIndex = 1
        Me.txtcontrasena.Texto = Nothing
        Me.txtcontrasena.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtcontrasena.UseSystemPasswordChar = True
        Me.txtcontrasena.ValorInt = Nothing
        '
        'txtusuario
        '
        Me.txtusuario.ColorError = System.Drawing.Color.Red
        Me.txtusuario.EnterPorTab = True
        Me.txtusuario.EsObligatorio = True
        Me.txtusuario.ExpresionValidacion = Nothing
        Me.txtusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(109, 17)
        Me.txtusuario.MaxLength = 255
        Me.txtusuario.MensajeError = "El usuario no puede ser vacío"
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(378, 20)
        Me.txtusuario.TabIndex = 0
        Me.txtusuario.Texto = Nothing
        Me.txtusuario.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtusuario.ValorInt = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Sucursal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Usuario"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CrtPersonaNatural1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(275, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(695, 240)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos Personales"
        '
        'CrtPersonaNatural1
        '
        Me.CrtPersonaNatural1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaNatural1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaNatural1.Location = New System.Drawing.Point(3, 16)
        Me.CrtPersonaNatural1.Name = "CrtPersonaNatural1"
        Me.CrtPersonaNatural1.RealizarBusquedaAutomarita = True
        Me.CrtPersonaNatural1.Size = New System.Drawing.Size(689, 221)
        Me.CrtPersonaNatural1.SoloLectura = False
        Me.CrtPersonaNatural1.TabIndex = 0
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(979, 625)
        Me.PanelAccion1.TabIndex = 3
        Me.PanelAccion1.Titulo = "Usuarios"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'frmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 625)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtListadoMantenimiento1 As SICO.ctrla2.crtListadoMantenimiento
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtPersonaNatural1 As SICO.ctrla2.crtPersonaNatural
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtusuario As SiCo.ctrla.CajaTexto
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcontrasena As SICO.ctrla.CajaTexto
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbhabilitado As SICO.ctrla2.ListaHabilitados
    Friend WithEvents txtConfirmar As SICO.ctrla.CajaTexto
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbrol As SICO.ctrla2.ListaRoles
    Friend WithEvents cmbSucursal As SiCo.ctrla.ControlesBasicos.ListaSucursales
End Class

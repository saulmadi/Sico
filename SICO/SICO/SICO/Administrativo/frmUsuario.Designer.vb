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
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CrtListadoMantenimiento1 = New SICO.ctrla2.crtListadoMantenimiento
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.CajaTexto2 = New SICO.ctrla.CajaTexto(Me.components)
        Me.CajaTexto1 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CrtPersonaNatural1 = New SICO.ctrla2.crtPersonaNatural
        Me.ListaHabilitados1 = New SICO.ctrla2.ListaHabilitados(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.CajaTexto3 = New SICO.ctrla.CajaTexto(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(979, 569)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "Usuarios"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CrtListadoMantenimiento1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 415)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'CrtListadoMantenimiento1
        '
        Me.CrtListadoMantenimiento1.CampoAMostrar = Nothing
        Me.CrtListadoMantenimiento1.CaracteresInicioBusqueda = 3
        Me.CrtListadoMantenimiento1.CaracteresSegundaBusqueda = 6
        Me.CrtListadoMantenimiento1.CargarInicio = False
        Me.CrtListadoMantenimiento1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtListadoMantenimiento1.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento1.Name = "CrtListadoMantenimiento1"
        Me.CrtListadoMantenimiento1.NombreParametroBusqueda = Nothing
        Me.CrtListadoMantenimiento1.Size = New System.Drawing.Size(251, 396)
        Me.CrtListadoMantenimiento1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CajaTexto3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.ListaHabilitados1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.CajaTexto2)
        Me.GroupBox2.Controls.Add(Me.CajaTexto1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(275, 350)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(500, 159)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de Usuario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Estado"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(108, 97)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(378, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'CajaTexto2
        '
        Me.CajaTexto2.ColorError = System.Drawing.Color.Red
        Me.CajaTexto2.EnterPorTab = True
        Me.CajaTexto2.EsObligatorio = False
        Me.CajaTexto2.ExpresionValidacion = Nothing
        Me.CajaTexto2.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.CajaTexto2.Location = New System.Drawing.Point(109, 43)
        Me.CajaTexto2.MaxLength = 255
        Me.CajaTexto2.MensajeError = Nothing
        Me.CajaTexto2.Name = "CajaTexto2"
        Me.CajaTexto2.Size = New System.Drawing.Size(378, 21)
        Me.CajaTexto2.TabIndex = 3
        Me.CajaTexto2.Texto = Nothing
        Me.CajaTexto2.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto2.ValorInt = Nothing
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EnterPorTab = True
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CajaTexto1.Location = New System.Drawing.Point(109, 17)
        Me.CajaTexto1.MaxLength = 255
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(378, 20)
        Me.CajaTexto1.TabIndex = 2
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto1.ValorInt = Nothing
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Sucursal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CrtPersonaNatural1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(275, 94)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(695, 250)
        Me.GroupBox3.TabIndex = 2
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
        Me.CrtPersonaNatural1.Size = New System.Drawing.Size(689, 231)
        Me.CrtPersonaNatural1.SoloLectura = False
        Me.CrtPersonaNatural1.TabIndex = 0
        '
        'ListaHabilitados1
        '
        Me.ListaHabilitados1.DisplayMember = "Descripcion"
        Me.ListaHabilitados1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ListaHabilitados1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListaHabilitados1.FormattingEnabled = True
        Me.ListaHabilitados1.Location = New System.Drawing.Point(108, 125)
        Me.ListaHabilitados1.Name = "ListaHabilitados1"
        Me.ListaHabilitados1.Size = New System.Drawing.Size(378, 21)
        Me.ListaHabilitados1.TabIndex = 7
        Me.ListaHabilitados1.ValueMember = "Valor"
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
        'CajaTexto3
        '
        Me.CajaTexto3.ColorError = System.Drawing.Color.Red
        Me.CajaTexto3.EnterPorTab = True
        Me.CajaTexto3.EsObligatorio = False
        Me.CajaTexto3.ExpresionValidacion = Nothing
        Me.CajaTexto3.Font = New System.Drawing.Font("Corbel", 8.25!)
        Me.CajaTexto3.Location = New System.Drawing.Point(108, 70)
        Me.CajaTexto3.MaxLength = 255
        Me.CajaTexto3.MensajeError = Nothing
        Me.CajaTexto3.Name = "CajaTexto3"
        Me.CajaTexto3.Size = New System.Drawing.Size(378, 21)
        Me.CajaTexto3.TabIndex = 9
        Me.CajaTexto3.Texto = Nothing
        Me.CajaTexto3.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto3.ValorInt = Nothing
        '
        'frmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 569)
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
    Friend WithEvents CajaTexto1 As SiCo.ctrla.CajaTexto
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto2 As SICO.ctrla.CajaTexto
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListaHabilitados1 As SICO.ctrla2.ListaHabilitados
    Friend WithEvents CajaTexto3 As SICO.ctrla.CajaTexto
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class

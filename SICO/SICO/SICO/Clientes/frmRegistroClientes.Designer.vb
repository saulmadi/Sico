<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroClientes))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPersonaNatural = New System.Windows.Forms.TabPage
        Me.CrtPersonaNatural1 = New SICO.ctrla2.crtPersonaNatural
        Me.TabPersonaJuridica = New System.Windows.Forms.TabPage
        Me.CrtPersonaJuridica1 = New SICO.ctrla2.crtPersonaJuridica
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CrtListadoMantenimiento2 = New SICO.ctrla2.crtListadoMantenimiento
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.CrtListadoMantenimiento1 = New SICO.ctrla2.crtListadoMantenimiento
        Me.TabControl1.SuspendLayout()
        Me.TabPersonaNatural.SuspendLayout()
        Me.TabPersonaJuridica.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPersonaNatural)
        Me.TabControl1.Controls.Add(Me.TabPersonaJuridica)
        Me.TabControl1.Location = New System.Drawing.Point(253, 83)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(711, 306)
        Me.TabControl1.TabIndex = 1
        '
        'TabPersonaNatural
        '
        Me.TabPersonaNatural.BackColor = System.Drawing.SystemColors.Control
        Me.TabPersonaNatural.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPersonaNatural.Controls.Add(Me.CrtPersonaNatural1)
        Me.TabPersonaNatural.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPersonaNatural.Location = New System.Drawing.Point(4, 22)
        Me.TabPersonaNatural.Name = "TabPersonaNatural"
        Me.TabPersonaNatural.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPersonaNatural.Size = New System.Drawing.Size(703, 280)
        Me.TabPersonaNatural.TabIndex = 0
        Me.TabPersonaNatural.Text = "Persona Naturales"
        '
        'CrtPersonaNatural1
        '
        Me.CrtPersonaNatural1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaNatural1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaNatural1.Location = New System.Drawing.Point(3, 3)
        Me.CrtPersonaNatural1.Name = "CrtPersonaNatural1"
        Me.CrtPersonaNatural1.RealizarBusquedaAutomarita = True
        Me.CrtPersonaNatural1.Size = New System.Drawing.Size(695, 272)
        Me.CrtPersonaNatural1.SoloLectura = False
        Me.CrtPersonaNatural1.TabIndex = 0
        '
        'TabPersonaJuridica
        '
        Me.TabPersonaJuridica.BackColor = System.Drawing.SystemColors.Control
        Me.TabPersonaJuridica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPersonaJuridica.Controls.Add(Me.CrtPersonaJuridica1)
        Me.TabPersonaJuridica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPersonaJuridica.Location = New System.Drawing.Point(4, 22)
        Me.TabPersonaJuridica.Name = "TabPersonaJuridica"
        Me.TabPersonaJuridica.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPersonaJuridica.Size = New System.Drawing.Size(703, 280)
        Me.TabPersonaJuridica.TabIndex = 1
        Me.TabPersonaJuridica.Text = "Personas Jurídicas"
        '
        'CrtPersonaJuridica1
        '
        Me.CrtPersonaJuridica1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaJuridica1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaJuridica1.HabilitarRTN = True
        Me.CrtPersonaJuridica1.Location = New System.Drawing.Point(3, 3)
        Me.CrtPersonaJuridica1.Name = "CrtPersonaJuridica1"
        Me.CrtPersonaJuridica1.RealizarBusquedaAutomarita = True
        Me.CrtPersonaJuridica1.Size = New System.Drawing.Size(695, 272)
        Me.CrtPersonaJuridica1.SoloLectura = False
        Me.CrtPersonaJuridica1.TabIndex = 0
        Me.CrtPersonaJuridica1.TextoRazonSocial = "Razón social"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CrtListadoMantenimiento2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 284)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'CrtListadoMantenimiento2
        '
        Me.CrtListadoMantenimiento2.CampoAMostrar = Nothing
        Me.CrtListadoMantenimiento2.CaracteresInicioBusqueda = 3
        Me.CrtListadoMantenimiento2.CaracteresSegundaBusqueda = 6
        Me.CrtListadoMantenimiento2.CargarInicio = False
        Me.CrtListadoMantenimiento2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtListadoMantenimiento2.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento2.Name = "CrtListadoMantenimiento2"
        Me.CrtListadoMantenimiento2.NombreParametroBusqueda = Nothing
        Me.CrtListadoMantenimiento2.Size = New System.Drawing.Size(229, 265)
        Me.CrtListadoMantenimiento2.TabIndex = 0
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(973, 457)
        Me.PanelAccion1.TabIndex = 2
        Me.PanelAccion1.Titulo = "Clientes"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'CrtListadoMantenimiento1
        '
        Me.CrtListadoMantenimiento1.CampoAMostrar = Nothing
        Me.CrtListadoMantenimiento1.CaracteresInicioBusqueda = 3
        Me.CrtListadoMantenimiento1.CaracteresSegundaBusqueda = 6
        Me.CrtListadoMantenimiento1.CargarInicio = False
        Me.CrtListadoMantenimiento1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento1.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento1.Name = "CrtListadoMantenimiento1"
        Me.CrtListadoMantenimiento1.NombreParametroBusqueda = Nothing
        Me.CrtListadoMantenimiento1.Size = New System.Drawing.Size(301, 254)
        Me.CrtListadoMantenimiento1.TabIndex = 0
        '
        'frmRegistroClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 457)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRegistroClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPersonaNatural.ResumeLayout(False)
        Me.TabPersonaJuridica.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPersonaNatural As System.Windows.Forms.TabPage
    Friend WithEvents TabPersonaJuridica As System.Windows.Forms.TabPage
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents CrtListadoMantenimiento1 As SICO.ctrla2.crtListadoMantenimiento
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtListadoMantenimiento2 As SICO.ctrla2.crtListadoMantenimiento
    Friend WithEvents CrtPersonaNatural1 As SICO.ctrla2.crtPersonaNatural
    Friend WithEvents CrtPersonaJuridica1 As SICO.ctrla2.crtPersonaJuridica
End Class

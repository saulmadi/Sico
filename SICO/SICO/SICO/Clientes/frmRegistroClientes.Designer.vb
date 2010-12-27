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
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.CrtPersonaNatural1 = New SICO.ctrla2.crtPersonaNatural
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.CrtPersonaJuridica1 = New SICO.ctrla2.crtPersonaJuridica
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CrtListadoMantenimiento2 = New SICO.ctrla2.crtListadoMantenimiento
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.CrtListadoMantenimiento1 = New SICO.ctrla2.crtListadoMantenimiento
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(346, 86)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(511, 306)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.CrtPersonaNatural1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(503, 280)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Persona Naturales"
        '
        'CrtPersonaNatural1
        '
        Me.CrtPersonaNatural1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaNatural1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaNatural1.Location = New System.Drawing.Point(3, 3)
        Me.CrtPersonaNatural1.Name = "CrtPersonaNatural1"
        Me.CrtPersonaNatural1.Size = New System.Drawing.Size(495, 272)
        Me.CrtPersonaNatural1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.CrtPersonaJuridica1)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(503, 280)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Personas Jurídicas"
        '
        'CrtPersonaJuridica1
        '
        Me.CrtPersonaJuridica1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaJuridica1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaJuridica1.Location = New System.Drawing.Point(3, 3)
        Me.CrtPersonaJuridica1.Name = "CrtPersonaJuridica1"
        Me.CrtPersonaJuridica1.Size = New System.Drawing.Size(495, 272)
        Me.CrtPersonaJuridica1.TabIndex = 0
        Me.CrtPersonaJuridica1.TextoRazonSocial = "Razón social"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CrtListadoMantenimiento2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 284)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'CrtListadoMantenimiento2
        '
        Me.CrtListadoMantenimiento2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtListadoMantenimiento2.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento2.Name = "CrtListadoMantenimiento2"
        Me.CrtListadoMantenimiento2.Size = New System.Drawing.Size(322, 265)
        Me.CrtListadoMantenimiento2.TabIndex = 0
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(867, 457)
        Me.PanelAccion1.TabIndex = 2
        Me.PanelAccion1.Titulo = "Clientes"
        '
        'CrtListadoMantenimiento1
        '
        Me.CrtListadoMantenimiento1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento1.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento1.Name = "CrtListadoMantenimiento1"
        Me.CrtListadoMantenimiento1.Size = New System.Drawing.Size(301, 254)
        Me.CrtListadoMantenimiento1.TabIndex = 0
        '
        'frmRegistroClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 457)
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
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents CrtListadoMantenimiento1 As SICO.ctrla2.crtListadoMantenimiento
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtListadoMantenimiento2 As SICO.ctrla2.crtListadoMantenimiento
    Friend WithEvents CrtPersonaNatural1 As SICO.ctrla2.crtPersonaNatural
    Friend WithEvents CrtPersonaJuridica1 As SICO.ctrla2.crtPersonaJuridica
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtClientes
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPersonaNatural = New System.Windows.Forms.TabPage
        Me.TabPersonaJuridica = New System.Windows.Forms.TabPage
        Me.CrtPersonaNatural1 = New SiCo.ctrla2.crtPersonaNatural
        Me.CrtPersonaJuridica1 = New SiCo.ctrla2.crtPersonaJuridica
        Me.TabControl1.SuspendLayout()
        Me.TabPersonaNatural.SuspendLayout()
        Me.TabPersonaJuridica.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPersonaNatural)
        Me.TabControl1.Controls.Add(Me.TabPersonaJuridica)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.MaximumSize = New System.Drawing.Size(705, 251)
        Me.TabControl1.MinimumSize = New System.Drawing.Size(705, 251)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(705, 251)
        Me.TabControl1.TabIndex = 2
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
        Me.TabPersonaNatural.Size = New System.Drawing.Size(697, 225)
        Me.TabPersonaNatural.TabIndex = 0
        Me.TabPersonaNatural.Text = "Persona Naturales"
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
        Me.TabPersonaJuridica.Size = New System.Drawing.Size(697, 225)
        Me.TabPersonaJuridica.TabIndex = 1
        Me.TabPersonaJuridica.Text = "Personas Jurídicas"
        '
        'CrtPersonaNatural1
        '
        Me.CrtPersonaNatural1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaNatural1.Location = New System.Drawing.Point(-1, 3)
        Me.CrtPersonaNatural1.Name = "CrtPersonaNatural1"
        Me.CrtPersonaNatural1.RealizarBusquedaAutomarita = True
        Me.CrtPersonaNatural1.Size = New System.Drawing.Size(692, 112)
        Me.CrtPersonaNatural1.SoloLectura = False
        Me.CrtPersonaNatural1.TabIndex = 0
        Me.CrtPersonaNatural1.VisibleDatosSecundarios = False
        '
        'CrtPersonaJuridica1
        '
        Me.CrtPersonaJuridica1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaJuridica1.HabilitarRTN = True
        Me.CrtPersonaJuridica1.Location = New System.Drawing.Point(6, 5)
        Me.CrtPersonaJuridica1.Name = "CrtPersonaJuridica1"
        Me.CrtPersonaJuridica1.RealizarBusquedaAutomarita = True
        Me.CrtPersonaJuridica1.Size = New System.Drawing.Size(583, 194)
        Me.CrtPersonaJuridica1.SoloLectura = False
        Me.CrtPersonaJuridica1.TabIndex = 0
        Me.CrtPersonaJuridica1.TextoRazonSocial = "Razón social"
        Me.CrtPersonaJuridica1.VisiblesDatosSecundarios = False
        '
        'crtClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "crtClientes"
        Me.Size = New System.Drawing.Size(713, 257)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPersonaNatural.ResumeLayout(False)
        Me.TabPersonaJuridica.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPersonaNatural As System.Windows.Forms.TabPage
    Friend WithEvents TabPersonaJuridica As System.Windows.Forms.TabPage
    Private WithEvents CrtPersonaNatural1 As SiCo.ctrla2.crtPersonaNatural
    Private WithEvents CrtPersonaJuridica1 As SiCo.ctrla2.crtPersonaJuridica

End Class

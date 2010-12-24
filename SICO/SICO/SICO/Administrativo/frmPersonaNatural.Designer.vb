<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonaNatural
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPersonaNatural))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CrtListadoMantenimiento1 = New SICO.ctrla2.crtListadoMantenimiento
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CrtPersonaNatural1 = New SICO.ctrla2.crtPersonaNatural
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CrtListadoMantenimiento1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(345, 291)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'CrtListadoMantenimiento1
        '
        Me.CrtListadoMantenimiento1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtListadoMantenimiento1.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento1.Name = "CrtListadoMantenimiento1"
        Me.CrtListadoMantenimiento1.Size = New System.Drawing.Size(339, 272)
        Me.CrtListadoMantenimiento1.TabIndex = 0
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(876, 476)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "Persona Natural"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CrtPersonaNatural1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(363, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(502, 291)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos"
        '
        'CrtPersonaNatural1
        '
        Me.CrtPersonaNatural1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaNatural1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaNatural1.Location = New System.Drawing.Point(3, 16)
        Me.CrtPersonaNatural1.Name = "CrtPersonaNatural1"
        Me.CrtPersonaNatural1.Size = New System.Drawing.Size(496, 272)
        Me.CrtPersonaNatural1.TabIndex = 0
        '
        'frmPersonaNatural
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 476)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPersonaNatural"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Persona Natural"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtListadoMantenimiento1 As SICO.ctrla2.crtListadoMantenimiento
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtPersonaNatural1 As SICO.ctrla2.crtPersonaNatural
End Class

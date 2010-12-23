<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiposMotocicletas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTiposMotocicletas))
        Me.CrtTablaTipo = New SICO.ctrla2.crtTablaTipo
        Me.SuspendLayout()
        '
        'CrtTablaTipo
        '
        Me.CrtTablaTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtTablaTipo.Location = New System.Drawing.Point(0, 0)
        Me.CrtTablaTipo.Name = "CrtTablaTipo"
        Me.CrtTablaTipo.Size = New System.Drawing.Size(771, 527)
        Me.CrtTablaTipo.TabIndex = 0
        '
        'frmTiposMotocicletas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 527)
        Me.Controls.Add(Me.CrtTablaTipo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTiposMotocicletas"
        Me.Text = "Tipo Motocicletas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrtTablaTipo As SICO.ctrla2.crtTablaTipo
End Class

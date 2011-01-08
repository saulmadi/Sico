<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartamentos))
        Me.CrtTablaTipo1 = New SICO.ctrla2.crtTablaTipo
        Me.SuspendLayout()
        '
        'CrtTablaTipo1
        '
        Me.CrtTablaTipo1.CaracterinicioBusqueda = 3
        Me.CrtTablaTipo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtTablaTipo1.Location = New System.Drawing.Point(0, 0)
        Me.CrtTablaTipo1.Name = "CrtTablaTipo1"
        Me.CrtTablaTipo1.Size = New System.Drawing.Size(783, 515)
        Me.CrtTablaTipo1.TabIndex = 0
        Me.CrtTablaTipo1.Titulo = "Departamentos"
        '
        'frmDepartamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 515)
        Me.Controls.Add(Me.CrtTablaTipo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDepartamentos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Departamentos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrtTablaTipo1 As SICO.ctrla2.crtTablaTipo
End Class

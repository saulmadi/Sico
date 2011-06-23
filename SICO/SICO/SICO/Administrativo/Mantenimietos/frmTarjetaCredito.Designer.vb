<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarjetaCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTarjetaCredito))
        Me.crtTablaTipo1 = New SICO.ctrla2.crtTablaTipo
        Me.SuspendLayout()
        '
        'crtTablaTipo1
        '
        Me.crtTablaTipo1.CaracterinicioBusqueda = 3
        Me.crtTablaTipo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crtTablaTipo1.Location = New System.Drawing.Point(0, 0)
        Me.crtTablaTipo1.Modulo = SICO.lgla2.ModulosTablasTipo.Departamentos
        Me.crtTablaTipo1.Name = "crtTablaTipo1"
        Me.crtTablaTipo1.Size = New System.Drawing.Size(792, 468)
        Me.crtTablaTipo1.TabIndex = 0
        Me.crtTablaTipo1.TablaTipo = Nothing
        Me.crtTablaTipo1.Titulo = "Marcas Motociletas"
        '
        'frmMarcas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 468)
        Me.Controls.Add(Me.crtTablaTipo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMarcas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcas "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crtTablaTipo1 As SICO.ctrla2.crtTablaTipo
End Class

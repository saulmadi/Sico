<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModelos
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
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModelos))
        Me.CrtTablaTipoDerivada = New SICO.ctrla2.crtTablaTipoDerivada
        Me.SuspendLayout()
        '
        'CrtTablaTipoDerivada
        '
        Me.CrtTablaTipoDerivada.CaracterinicioBusqueda = 3
        Me.CrtTablaTipoDerivada.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtTablaTipoDerivada.Location = New System.Drawing.Point(0, 0)
        Me.CrtTablaTipoDerivada.Name = "CrtTablaTipoDerivada"
        Me.CrtTablaTipoDerivada.Size = New System.Drawing.Size(782, 524)
        Me.CrtTablaTipoDerivada.TabIndex = 0
        Me.CrtTablaTipoDerivada.Titulo = "Modelos"
        Me.CrtTablaTipoDerivada.TituloDerivado = "Marca"
        '
        'frmModelos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 524)
        Me.Controls.Add(Me.CrtTablaTipoDerivada)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmModelos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modelos Motocicletas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrtTablaTipoDerivada As SICO.ctrla2.crtTablaTipoDerivada
End Class

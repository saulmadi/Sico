Imports SiCo.ctrla
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtPanelBusqueda
    Inherits SiCo.ctrla.ControlesPersonalizados.crtPanelBase

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(crtPanelBusqueda))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me._BarraHerramientas = New System.Windows.Forms.ToolStrip
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton
        Me._GridResultados = New SiCo.ctrla.Grid(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me._BarraHerramientas.SuspendLayout()
        CType(Me._GridResultados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel2
        '
        Me.panel2.Size = New System.Drawing.Size(878, 84)
        '
        'lblTitulo
        '
        Me.lblTitulo.Size = New System.Drawing.Size(790, 84)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me._BarraHerramientas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 84)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 80)
        Me.Panel1.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(878, 55)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parámetros de Busqueda"
        '
        '_BarraHerramientas
        '
        Me._BarraHerramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me._BarraHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripButton, Me.ImprimirToolStripButton})
        Me._BarraHerramientas.Location = New System.Drawing.Point(0, 0)
        Me._BarraHerramientas.Name = "_BarraHerramientas"
        Me._BarraHerramientas.Size = New System.Drawing.Size(878, 25)
        Me._BarraHerramientas.TabIndex = 0
        Me._BarraHerramientas.Text = "ToolStrip1"
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = CType(resources.GetObject("ImprimirToolStripButton.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton.Text = "&Imprimir"
        '
        '_GridResultados
        '
        Me._GridResultados.AllowUserToAddRows = False
        Me._GridResultados.AllowUserToDeleteRows = False
        Me._GridResultados.BotonEditar = False
        Me._GridResultados.BotonEliminar = False
        Me._GridResultados.CampoId = Nothing
        Me._GridResultados.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me._GridResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._GridResultados.Dock = System.Windows.Forms.DockStyle.Fill
        Me._GridResultados.Location = New System.Drawing.Point(3, 16)
        Me._GridResultados.MultiSelect = False
        Me._GridResultados.Name = "_GridResultados"
        Me._GridResultados.RowHeadersVisible = False
        Me._GridResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me._GridResultados.Size = New System.Drawing.Size(872, 250)
        Me._GridResultados.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me._GridResultados)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 164)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(878, 269)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resultados de Busqueda"
        '
        'crtPanelBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "crtPanelBusqueda"
        Me.Size = New System.Drawing.Size(878, 433)
        Me.Controls.SetChildIndex(Me.panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me._BarraHerramientas.ResumeLayout(False)
        Me._BarraHerramientas.PerformLayout()
        CType(Me._GridResultados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents _GridResultados As SiCo.ctrla.Grid
    Friend WithEvents _BarraHerramientas As System.Windows.Forms.ToolStrip

End Class

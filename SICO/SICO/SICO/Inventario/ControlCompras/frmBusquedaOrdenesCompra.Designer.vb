<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusquedaOrdenesCompra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBusquedaOrdenesCompra))
        Me.CrtPanelBusqueda1 = New SICO.ctrla2.crtPanelBusqueda
        Me.ListaDesplegable1 = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'CrtPanelBusqueda1
        '
        Me.CrtPanelBusqueda1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPanelBusqueda1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBusqueda1.Name = "CrtPanelBusqueda1"
        Me.CrtPanelBusqueda1.Size = New System.Drawing.Size(851, 418)
        Me.CrtPanelBusqueda1.TabIndex = 0
        Me.CrtPanelBusqueda1.Titulo = "Ordenes de Compra"
        Me.CrtPanelBusqueda1.VisiblePanelPrincipal = True
        '
        'ListaDesplegable1
        '
        Me.ListaDesplegable1.Comando = Nothing
        Me.ListaDesplegable1.FormattingEnabled = True
        Me.ListaDesplegable1.ListaDesplegablePadre = Nothing
        Me.ListaDesplegable1.Location = New System.Drawing.Point(106, 131)
        Me.ListaDesplegable1.Name = "ListaDesplegable1"
        Me.ListaDesplegable1.Size = New System.Drawing.Size(190, 21)
        Me.ListaDesplegable1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Proveedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(302, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fecha"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(345, 132)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(224, 20)
        Me.DateTimePicker1.TabIndex = 6
        '
        'frmBusquedaOrdenesCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 418)
        Me.Controls.Add(Me.ListaDesplegable1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CrtPanelBusqueda1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBusquedaOrdenesCompra"
        Me.Text = "Busqueda Oredenes de Compra"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrtPanelBusqueda1 As SICO.ctrla2.crtPanelBusqueda
    Friend WithEvents ListaDesplegable1 As SICO.ctrla.ListaDesplegable
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
End Class

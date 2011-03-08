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
        Me.fechahasta = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbProveedor = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.fecha = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'CrtPanelBusqueda1
        '
        Me.CrtPanelBusqueda1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPanelBusqueda1.Entidad = Nothing
        Me.CrtPanelBusqueda1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBusqueda1.Name = "CrtPanelBusqueda1"
        Me.CrtPanelBusqueda1.Size = New System.Drawing.Size(851, 528)
        Me.CrtPanelBusqueda1.TabIndex = 0
        Me.CrtPanelBusqueda1.Titulo = "Ordenes de Compra"
        Me.CrtPanelBusqueda1.VisiblePanelPrincipal = True
        '
        'fechahasta
        '
        Me.fechahasta.Location = New System.Drawing.Point(375, 156)
        Me.fechahasta.Name = "fechahasta"
        Me.fechahasta.Size = New System.Drawing.Size(224, 20)
        Me.fechahasta.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(300, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Fecha Hasta"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(605, 127)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbProveedor
        '
        Me.cmbProveedor.CargarAutoCompletar = False
        Me.cmbProveedor.CargarComboBox = True
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.ListaDesplegablePadre = Nothing
        Me.cmbProveedor.Location = New System.Drawing.Point(104, 126)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.ParametroAutocompletar = Nothing
        Me.cmbProveedor.ParametroBusquedaPadre = Nothing
        Me.cmbProveedor.Size = New System.Drawing.Size(190, 21)
        Me.cmbProveedor.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(42, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Proveedor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Fecha desde"
        '
        'fecha
        '
        Me.fecha.Location = New System.Drawing.Point(375, 127)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(224, 20)
        Me.fecha.TabIndex = 10
        '
        'frmBusquedaOrdenesCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 528)
        Me.Controls.Add(Me.fechahasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbProveedor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.CrtPanelBusqueda1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBusquedaOrdenesCompra"
        Me.Text = "Busqueda Oredenes de Compra"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrtPanelBusqueda1 As SICO.ctrla2.crtPanelBusqueda
    Friend WithEvents fechahasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbProveedor As SICO.ctrla.ListaDesplegable
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents fecha As System.Windows.Forms.DateTimePicker
End Class

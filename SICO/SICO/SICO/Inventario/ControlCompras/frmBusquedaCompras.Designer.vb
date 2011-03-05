<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusquedaCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBusquedaCompras))
        Me.CrtPanelBusqueda1 = New SICO.ctrla2.crtPanelBusqueda
        Me.fecha = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbProveedor = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.fechahasta = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'CrtPanelBusqueda1
        '
        Me.CrtPanelBusqueda1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPanelBusqueda1.Entidad = Nothing
        Me.CrtPanelBusqueda1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBusqueda1.Name = "CrtPanelBusqueda1"
        Me.CrtPanelBusqueda1.Size = New System.Drawing.Size(813, 336)
        Me.CrtPanelBusqueda1.TabIndex = 0
        Me.CrtPanelBusqueda1.Titulo = "Busqueda Compras"
        Me.CrtPanelBusqueda1.VisiblePanelPrincipal = True
        '
        'fecha
        '
        Me.fecha.Location = New System.Drawing.Point(377, 128)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(224, 20)
        Me.fecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(302, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha desde"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Proveedor"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.CargarAutoCompletar = False
        Me.cmbProveedor.CargarComboBox = True
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.ListaDesplegablePadre = Nothing
        Me.cmbProveedor.Location = New System.Drawing.Point(106, 127)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.ParametroAutocompletar = Nothing
        Me.cmbProveedor.ParametroBusquedaPadre = Nothing
        Me.cmbProveedor.Size = New System.Drawing.Size(190, 21)
        Me.cmbProveedor.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(607, 128)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(68, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(302, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha Hasta"
        '
        'fechahasta
        '
        Me.fechahasta.Location = New System.Drawing.Point(377, 157)
        Me.fechahasta.Name = "fechahasta"
        Me.fechahasta.Size = New System.Drawing.Size(224, 20)
        Me.fechahasta.TabIndex = 7
        '
        'frmBusquedaCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 336)
        Me.Controls.Add(Me.fechahasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbProveedor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.CrtPanelBusqueda1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(829, 374)
        Me.Name = "frmBusquedaCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Compras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrtPanelBusqueda1 As SICO.ctrla2.crtPanelBusqueda
    Friend WithEvents fecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbProveedor As SICO.ctrla.ListaDesplegable
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fechahasta As System.Windows.Forms.DateTimePicker
End Class

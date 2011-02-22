<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosBusqueda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosBusqueda))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboSucursales = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.txtDescripcion = New SICO.ctrla.CajaTexto(Me.components)
        Me.PanelBusqueda = New SICO.ctrla2.crtPanelBusqueda
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.chkInventarioTotal = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(402, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sucursal"
        '
        'cboSucursales
        '
        Me.cboSucursales.CargarAutoCompletar = False
        Me.cboSucursales.CargarComboBox = True
        Me.cboSucursales.FormattingEnabled = True
        Me.cboSucursales.Location = New System.Drawing.Point(456, 127)
        Me.cboSucursales.Name = "cboSucursales"
        Me.cboSucursales.ParametroAutocompletar = Nothing
        Me.cboSucursales.ParametroBusquedaPadre = Nothing
        Me.cboSucursales.SelectedItem = Nothing
        Me.cboSucursales.Size = New System.Drawing.Size(254, 21)
        Me.cboSucursales.TabIndex = 3
        '
        'txtDescripcion
        '
        Me.txtDescripcion.ColorError = System.Drawing.Color.Red
        Me.txtDescripcion.EnterPorTab = True
        Me.txtDescripcion.EsObligatorio = False
        Me.txtDescripcion.ExpresionValidacion = Nothing
        Me.txtDescripcion.Location = New System.Drawing.Point(114, 127)
        Me.txtDescripcion.MaxLength = 45
        Me.txtDescripcion.MensajeError = Nothing
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(283, 20)
        Me.txtDescripcion.TabIndex = 2
        Me.txtDescripcion.Texto = Nothing
        Me.txtDescripcion.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtDescripcion.ValorInt = Nothing
        Me.txtDescripcion.ValorLong = Nothing
        '
        'PanelBusqueda
        '
        Me.PanelBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBusqueda.Entidad = Nothing
        Me.PanelBusqueda.Location = New System.Drawing.Point(0, 0)
        Me.PanelBusqueda.Name = "PanelBusqueda"
        Me.PanelBusqueda.Size = New System.Drawing.Size(824, 462)
        Me.PanelBusqueda.TabIndex = 0
        Me.PanelBusqueda.Titulo = "Busqueda Productos"
        Me.PanelBusqueda.VisiblePanelPrincipal = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(716, 126)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(62, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chkInventarioTotal
        '
        Me.chkInventarioTotal.AutoSize = True
        Me.chkInventarioTotal.Location = New System.Drawing.Point(48, 153)
        Me.chkInventarioTotal.Name = "chkInventarioTotal"
        Me.chkInventarioTotal.Size = New System.Drawing.Size(100, 17)
        Me.chkInventarioTotal.TabIndex = 6
        Me.chkInventarioTotal.Text = "Inventario Total"
        Me.chkInventarioTotal.UseVisualStyleBackColor = True
        '
        'frmProductosBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 462)
        Me.Controls.Add(Me.chkInventarioTotal)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboSucursales)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PanelBusqueda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(840, 300)
        Me.Name = "frmProductosBusqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Productos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelBusqueda As SICO.ctrla2.crtPanelBusqueda
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As SICO.ctrla.CajaTexto
    Friend WithEvents cboSucursales As SiCo.ctrla.ControlesBasicos.ListaSucursales
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents chkInventarioTotal As System.Windows.Forms.CheckBox
End Class

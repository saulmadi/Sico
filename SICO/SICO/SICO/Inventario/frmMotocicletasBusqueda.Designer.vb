<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotocicletasBusqueda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMotocicletasBusqueda))
        Me.CrtPanelBusqueda1 = New SICO.ctrla2.crtPanelBusqueda
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMotor = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtChasis = New SICO.ctrla.CajaTexto(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbMarca = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbModelo = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbSucursal = New SICO.ctrla.ControlesBasicos.ListaSucursales(Me.components)
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'CrtPanelBusqueda1
        '
        Me.CrtPanelBusqueda1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPanelBusqueda1.Entidad = Nothing
        Me.CrtPanelBusqueda1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBusqueda1.Name = "CrtPanelBusqueda1"
        Me.CrtPanelBusqueda1.Size = New System.Drawing.Size(878, 366)
        Me.CrtPanelBusqueda1.TabIndex = 0
        Me.CrtPanelBusqueda1.Titulo = "Busqueda Motocicletas"
        Me.CrtPanelBusqueda1.VisiblePanelPrincipal = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Motor"
        '
        'txtMotor
        '
        Me.txtMotor.ColorError = System.Drawing.Color.Red
        Me.txtMotor.EnterPorTab = True
        Me.txtMotor.EsObligatorio = False
        Me.txtMotor.ExpresionValidacion = Nothing
        Me.txtMotor.Location = New System.Drawing.Point(98, 130)
        Me.txtMotor.MaxLength = 255
        Me.txtMotor.MensajeError = Nothing
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.Size = New System.Drawing.Size(190, 20)
        Me.txtMotor.TabIndex = 2
        Me.txtMotor.Texto = Nothing
        Me.txtMotor.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtMotor.ValorInt = Nothing
        Me.txtMotor.ValorLong = Nothing
        '
        'txtChasis
        '
        Me.txtChasis.ColorError = System.Drawing.Color.Red
        Me.txtChasis.EnterPorTab = True
        Me.txtChasis.EsObligatorio = False
        Me.txtChasis.ExpresionValidacion = Nothing
        Me.txtChasis.Location = New System.Drawing.Point(98, 156)
        Me.txtChasis.MaxLength = 255
        Me.txtChasis.MensajeError = Nothing
        Me.txtChasis.Name = "txtChasis"
        Me.txtChasis.Size = New System.Drawing.Size(190, 20)
        Me.txtChasis.TabIndex = 4
        Me.txtChasis.Texto = Nothing
        Me.txtChasis.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtChasis.ValorInt = Nothing
        Me.txtChasis.ValorLong = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Chasis"
        '
        'cmbMarca
        '
        Me.cmbMarca.CargarAutoCompletar = False
        Me.cmbMarca.CargarComboBox = True
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(342, 129)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.ParametroAutocompletar = Nothing
        Me.cmbMarca.ParametroBusquedaPadre = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(144, 21)
        Me.cmbMarca.TabIndex = 5
        '
        'cmbModelo
        '
        Me.cmbModelo.CargarAutoCompletar = False
        Me.cmbModelo.CargarComboBox = True
        Me.cmbModelo.FormattingEnabled = True
        Me.cmbModelo.Location = New System.Drawing.Point(342, 156)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.ParametroAutocompletar = Nothing
        Me.cmbModelo.ParametroBusquedaPadre = Nothing
        Me.cmbModelo.Size = New System.Drawing.Size(144, 21)
        Me.cmbModelo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(294, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Marca"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(294, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Modelo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(492, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Sucursal"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.CargarAutoCompletar = False
        Me.cmbSucursal.CargarComboBox = True
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(547, 133)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.ParametroAutocompletar = Nothing
        Me.cmbSucursal.ParametroBusquedaPadre = Nothing
        Me.cmbSucursal.SelectedItem = Nothing
        Me.cmbSucursal.Size = New System.Drawing.Size(121, 21)
        Me.cmbSucursal.TabIndex = 10
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(674, 133)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 11
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmMotocicletasBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 366)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.cmbSucursal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbModelo)
        Me.Controls.Add(Me.cmbMarca)
        Me.Controls.Add(Me.txtChasis)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMotor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CrtPanelBusqueda1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(894, 300)
        Me.Name = "frmMotocicletasBusqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda Motociletas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrtPanelBusqueda1 As SICO.ctrla2.crtPanelBusqueda
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMotor As SICO.ctrla.CajaTexto
    Friend WithEvents txtChasis As SICO.ctrla.CajaTexto
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbModelo As SICO.ctrla.ListaDesplegable
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As SICO.ctrla.ControlesBasicos.ListaSucursales
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class

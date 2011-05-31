<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusquedaMotocileta
    Inherits ctrla2.frmBusqueda


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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbModelo = New SiCo.ctrla.ListaDesplegable(Me.components)
        Me.cmbMarca = New SiCo.ctrla.ListaDesplegable(Me.components)
        Me.txtChasis = New SiCo.ctrla.CajaTexto(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMotor = New SiCo.ctrla.CajaTexto(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.panelparametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelparametros
        '
        Me.panelparametros.Controls.Add(Me.Button1)
        Me.panelparametros.Controls.Add(Me.Label4)
        Me.panelparametros.Controls.Add(Me.Label1)
        Me.panelparametros.Controls.Add(Me.Label3)
        Me.panelparametros.Controls.Add(Me.txtMotor)
        Me.panelparametros.Controls.Add(Me.cmbModelo)
        Me.panelparametros.Controls.Add(Me.Label2)
        Me.panelparametros.Controls.Add(Me.cmbMarca)
        Me.panelparametros.Controls.Add(Me.txtChasis)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(248, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Modelo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(248, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Marca"
        '
        'cmbModelo
        '
        Me.cmbModelo.CargarAutoCompletar = False
        Me.cmbModelo.CargarComboBox = True
        Me.cmbModelo.FormattingEnabled = True
        Me.cmbModelo.Location = New System.Drawing.Point(296, 41)
        Me.cmbModelo.Name = "cmbModelo"
        Me.cmbModelo.ParametroAutocompletar = Nothing
        Me.cmbModelo.ParametroBusquedaPadre = Nothing
        Me.cmbModelo.Size = New System.Drawing.Size(144, 21)
        Me.cmbModelo.TabIndex = 14
        '
        'cmbMarca
        '
        Me.cmbMarca.CargarAutoCompletar = False
        Me.cmbMarca.CargarComboBox = True
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(296, 14)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.ParametroAutocompletar = Nothing
        Me.cmbMarca.ParametroBusquedaPadre = Nothing
        Me.cmbMarca.Size = New System.Drawing.Size(144, 21)
        Me.cmbMarca.TabIndex = 13
        '
        'txtChasis
        '
        Me.txtChasis.ColorError = System.Drawing.Color.Red
        Me.txtChasis.EnterPorTab = True
        Me.txtChasis.EsObligatorio = False
        Me.txtChasis.ExpresionValidacion = Nothing
        Me.txtChasis.Location = New System.Drawing.Point(52, 41)
        Me.txtChasis.MaxLength = 255
        Me.txtChasis.MensajeError = Nothing
        Me.txtChasis.Name = "txtChasis"
        Me.txtChasis.Size = New System.Drawing.Size(190, 20)
        Me.txtChasis.TabIndex = 12
        Me.txtChasis.Texto = Nothing
        Me.txtChasis.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtChasis.ValorInt = Nothing
        Me.txtChasis.ValorLong = Nothing
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Chasis"
        '
        'txtMotor
        '
        Me.txtMotor.ColorError = System.Drawing.Color.Red
        Me.txtMotor.EnterPorTab = True
        Me.txtMotor.EsObligatorio = False
        Me.txtMotor.ExpresionValidacion = Nothing
        Me.txtMotor.Location = New System.Drawing.Point(52, 15)
        Me.txtMotor.MaxLength = 255
        Me.txtMotor.MensajeError = Nothing
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.Size = New System.Drawing.Size(190, 20)
        Me.txtMotor.TabIndex = 10
        Me.txtMotor.Texto = Nothing
        Me.txtMotor.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtMotor.ValorInt = Nothing
        Me.txtMotor.ValorLong = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Motor"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(446, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmBusquedaMotocileta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 429)
        Me.Name = "frmBusquedaMotocileta"
        Me.Text = "frmBusquedaMotocileta"
        Me.VerParametros = True
        Me.panelparametros.ResumeLayout(False)
        Me.panelparametros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbModelo As SiCo.ctrla.ListaDesplegable
    Friend WithEvents cmbMarca As SiCo.ctrla.ListaDesplegable
    Friend WithEvents txtChasis As SiCo.ctrla.CajaTexto
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMotor As SiCo.ctrla.CajaTexto
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtPersonaNatural
    Inherits System.Windows.Forms.UserControl

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
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.label2 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.SubProceso = New System.ComponentModel.BackgroundWorker
        Me.lblEstado = New System.Windows.Forms.Label
        Me.cmbTipoIdentidad = New SiCo.ctrla2.ListaTipoIdentidad(Me.components)
        Me.txtSegundoApellido = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtSegundoNombre = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtPrimerApellido = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtPrimerNombre = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtCelular = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtrtn = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtCorreo = New SiCo.ctrla.CorreoCajaTexto(Me.components)
        Me.txtdireccion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txttelefono = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtidentifiacion = New SiCo.ctrla.IdentidadCajaTexto(Me.components)
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(346, 62)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(70, 13)
        Me.label2.TabIndex = 19
        Me.label2.Text = "Identificación"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 88)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(30, 13)
        Me.label8.TabIndex = 14
        Me.label8.Text = "RTN"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(346, 89)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(38, 13)
        Me.label7.TabIndex = 20
        Me.label7.Text = "Correo"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 141)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 13)
        Me.label6.TabIndex = 16
        Me.label6.Text = "Dirección"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 114)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(49, 13)
        Me.label5.TabIndex = 15
        Me.label5.Text = "Teléfono"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(3, 36)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(75, 13)
        Me.label4.TabIndex = 12
        Me.label4.Text = "Primer apellido"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(3, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(74, 13)
        Me.label3.TabIndex = 11
        Me.label3.Text = "Primer nombre"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(3, 62)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(93, 13)
        Me.label1.TabIndex = 13
        Me.label1.Text = "Tipo identificación"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(346, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Segundo nombre"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(346, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Segundo apellido"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(346, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Celular"
        '
        'SubProceso
        '
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(257, 182)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(426, 23)
        Me.lblEstado.TabIndex = 22
        Me.lblEstado.Text = "Label12"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoIdentidad
        '
        Me.cmbTipoIdentidad.DisplayMember = "Descripcion"
        Me.cmbTipoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIdentidad.FormattingEnabled = True
        Me.cmbTipoIdentidad.Location = New System.Drawing.Point(102, 58)
        Me.cmbTipoIdentidad.Name = "cmbTipoIdentidad"
        Me.cmbTipoIdentidad.Size = New System.Drawing.Size(238, 21)
        Me.cmbTipoIdentidad.TabIndex = 4
        Me.cmbTipoIdentidad.ValueMember = "Valor"
        '
        'txtSegundoApellido
        '
        Me.txtSegundoApellido.BackColor = System.Drawing.SystemColors.Window
        Me.txtSegundoApellido.ColorError = System.Drawing.Color.Red
        Me.txtSegundoApellido.EnterPorTab = True
        Me.txtSegundoApellido.EsObligatorio = False
        Me.txtSegundoApellido.ExpresionValidacion = ""
        Me.txtSegundoApellido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSegundoApellido.Location = New System.Drawing.Point(445, 33)
        Me.txtSegundoApellido.MaxLength = 30
        Me.txtSegundoApellido.MensajeError = Nothing
        Me.txtSegundoApellido.Name = "txtSegundoApellido"
        Me.txtSegundoApellido.Size = New System.Drawing.Size(238, 20)
        Me.txtSegundoApellido.TabIndex = 3
        Me.txtSegundoApellido.Texto = Nothing
        Me.txtSegundoApellido.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtSegundoApellido.ValorInt = Nothing
        '
        'txtSegundoNombre
        '
        Me.txtSegundoNombre.BackColor = System.Drawing.SystemColors.Window
        Me.txtSegundoNombre.ColorError = System.Drawing.Color.Red
        Me.txtSegundoNombre.EnterPorTab = True
        Me.txtSegundoNombre.EsObligatorio = False
        Me.txtSegundoNombre.ExpresionValidacion = ""
        Me.txtSegundoNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSegundoNombre.Location = New System.Drawing.Point(445, 7)
        Me.txtSegundoNombre.MaxLength = 30
        Me.txtSegundoNombre.MensajeError = Nothing
        Me.txtSegundoNombre.Name = "txtSegundoNombre"
        Me.txtSegundoNombre.Size = New System.Drawing.Size(238, 20)
        Me.txtSegundoNombre.TabIndex = 1
        Me.txtSegundoNombre.Texto = Nothing
        Me.txtSegundoNombre.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtSegundoNombre.ValorInt = Nothing
        '
        'txtPrimerApellido
        '
        Me.txtPrimerApellido.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrimerApellido.ColorError = System.Drawing.Color.Red
        Me.txtPrimerApellido.EnterPorTab = True
        Me.txtPrimerApellido.EsObligatorio = True
        Me.txtPrimerApellido.ExpresionValidacion = ""
        Me.txtPrimerApellido.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPrimerApellido.Location = New System.Drawing.Point(102, 33)
        Me.txtPrimerApellido.MaxLength = 30
        Me.txtPrimerApellido.MensajeError = "El primer apellido no puede ser vacío"
        Me.txtPrimerApellido.Name = "txtPrimerApellido"
        Me.txtPrimerApellido.Size = New System.Drawing.Size(238, 20)
        Me.txtPrimerApellido.TabIndex = 2
        Me.txtPrimerApellido.Texto = Nothing
        Me.txtPrimerApellido.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtPrimerApellido.ValorInt = Nothing
        '
        'txtPrimerNombre
        '
        Me.txtPrimerNombre.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrimerNombre.ColorError = System.Drawing.Color.Red
        Me.txtPrimerNombre.EnterPorTab = True
        Me.txtPrimerNombre.EsObligatorio = True
        Me.txtPrimerNombre.ExpresionValidacion = ""
        Me.txtPrimerNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPrimerNombre.Location = New System.Drawing.Point(102, 7)
        Me.txtPrimerNombre.MaxLength = 30
        Me.txtPrimerNombre.MensajeError = "El primer nombre no puede ser vacío"
        Me.txtPrimerNombre.Name = "txtPrimerNombre"
        Me.txtPrimerNombre.Size = New System.Drawing.Size(238, 20)
        Me.txtPrimerNombre.TabIndex = 0
        Me.txtPrimerNombre.Texto = Nothing
        Me.txtPrimerNombre.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtPrimerNombre.ValorInt = Nothing
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.SystemColors.Window
        Me.txtCelular.ColorError = System.Drawing.Color.Red
        Me.txtCelular.EnterPorTab = True
        Me.txtCelular.EsObligatorio = False
        Me.txtCelular.ExpresionValidacion = Nothing
        Me.txtCelular.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCelular.Location = New System.Drawing.Point(445, 112)
        Me.txtCelular.MaxLength = 12
        Me.txtCelular.MensajeError = Nothing
        Me.txtCelular.Multiline = True
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(238, 20)
        Me.txtCelular.TabIndex = 9
        Me.txtCelular.Texto = Nothing
        Me.txtCelular.TipoTexto = SiCo.ctrla.TiposTexto.Entero
        Me.txtCelular.ValorInt = Nothing
        '
        'txtrtn
        '
        Me.txtrtn.BackColor = System.Drawing.SystemColors.Window
        Me.txtrtn.ColorError = System.Drawing.Color.Red
        Me.txtrtn.EnterPorTab = True
        Me.txtrtn.EsObligatorio = False
        Me.txtrtn.ExpresionValidacion = ""
        Me.txtrtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtrtn.Location = New System.Drawing.Point(102, 85)
        Me.txtrtn.MaxLength = 14
        Me.txtrtn.MensajeError = Nothing
        Me.txtrtn.Name = "txtrtn"
        Me.txtrtn.Size = New System.Drawing.Size(238, 20)
        Me.txtrtn.TabIndex = 6
        Me.txtrtn.Texto = Nothing
        Me.txtrtn.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtrtn.ValorInt = Nothing
        '
        'txtCorreo
        '
        Me.txtCorreo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCorreo.ColorError = System.Drawing.Color.Red
        Me.txtCorreo.EnterPorTab = True
        Me.txtCorreo.EsObligatorio = False
        Me.txtCorreo.ExpresionValidacion = "^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" & _
            "-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" & _
            "9][0-9]|[1-9][0-9]|[0-9])\])$"
        Me.txtCorreo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCorreo.Location = New System.Drawing.Point(445, 86)
        Me.txtCorreo.MaxLength = 255
        Me.txtCorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(238, 20)
        Me.txtCorreo.TabIndex = 7
        Me.txtCorreo.Texto = Nothing
        Me.txtCorreo.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtCorreo.ValorInt = Nothing
        '
        'txtdireccion
        '
        Me.txtdireccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtdireccion.ColorError = System.Drawing.Color.Red
        Me.txtdireccion.EnterPorTab = True
        Me.txtdireccion.EsObligatorio = False
        Me.txtdireccion.ExpresionValidacion = Nothing
        Me.txtdireccion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtdireccion.Location = New System.Drawing.Point(102, 138)
        Me.txtdireccion.MensajeError = Nothing
        Me.txtdireccion.Multiline = True
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(581, 41)
        Me.txtdireccion.TabIndex = 10
        Me.txtdireccion.Texto = Nothing
        Me.txtdireccion.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        Me.txtdireccion.ValorInt = Nothing
        '
        'txttelefono
        '
        Me.txttelefono.BackColor = System.Drawing.SystemColors.Window
        Me.txttelefono.ColorError = System.Drawing.Color.Red
        Me.txttelefono.EnterPorTab = True
        Me.txttelefono.EsObligatorio = False
        Me.txttelefono.ExpresionValidacion = Nothing
        Me.txttelefono.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txttelefono.Location = New System.Drawing.Point(102, 111)
        Me.txttelefono.MaxLength = 12
        Me.txttelefono.MensajeError = Nothing
        Me.txttelefono.Multiline = True
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(238, 20)
        Me.txttelefono.TabIndex = 8
        Me.txttelefono.Texto = Nothing
        Me.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Entero
        Me.txttelefono.ValorInt = Nothing
        '
        'txtidentifiacion
        '
        Me.txtidentifiacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtidentifiacion.ColorError = System.Drawing.Color.Red
        Me.txtidentifiacion.EnterPorTab = True
        Me.txtidentifiacion.EsObligatorio = True
        Me.txtidentifiacion.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]"
        Me.txtidentifiacion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtidentifiacion.Location = New System.Drawing.Point(445, 59)
        Me.txtidentifiacion.MaxLength = 13
        Me.txtidentifiacion.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232 o no puede ser vac" & _
            "ía"
        Me.txtidentifiacion.Name = "txtidentifiacion"
        Me.txtidentifiacion.Size = New System.Drawing.Size(238, 20)
        Me.txtidentifiacion.TabIndex = 5
        Me.txtidentifiacion.Texto = Nothing
        Me.txtidentifiacion.TipoTexto = SiCo.ctrla.TiposTexto.Entero
        Me.txtidentifiacion.ValorInt = Nothing
        '
        'crtPersonaNatural
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbTipoIdentidad)
        Me.Controls.Add(Me.txtSegundoApellido)
        Me.Controls.Add(Me.txtSegundoNombre)
        Me.Controls.Add(Me.txtPrimerApellido)
        Me.Controls.Add(Me.txtPrimerNombre)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtrtn)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.txtidentifiacion)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label1)
        Me.Name = "crtPersonaNatural"
        Me.Size = New System.Drawing.Size(692, 213)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents txtrtn As SiCo.ctrla.CajaTexto
    Private WithEvents txtCorreo As SiCo.ctrla.CorreoCajaTexto
    Private WithEvents txtdireccion As SiCo.ctrla.CajaTexto
    Private WithEvents txttelefono As SiCo.ctrla.CajaTexto
    Private WithEvents txtidentifiacion As SiCo.ctrla.IdentidadCajaTexto
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents Label10 As System.Windows.Forms.Label


    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents txtCelular As SiCo.ctrla.CajaTexto
    Private WithEvents txtPrimerNombre As SiCo.ctrla.CajaTexto
    Private WithEvents txtPrimerApellido As SiCo.ctrla.CajaTexto
    Private WithEvents txtSegundoNombre As SiCo.ctrla.CajaTexto
    Private WithEvents txtSegundoApellido As SiCo.ctrla.CajaTexto
    Friend WithEvents SubProceso As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbTipoIdentidad As SiCo.ctrla2.ListaTipoIdentidad
    Friend WithEvents lblEstado As System.Windows.Forms.Label

End Class

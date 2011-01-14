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
        Me.CajaTexto5 = New SiCo.ctrla.CajaTexto(Me.components)
        Me.CajaTexto4 = New SiCo.ctrla.CajaTexto(Me.components)
        Me.CajaTexto3 = New SiCo.ctrla.CajaTexto(Me.components)
        Me.CajaTexto2 = New SiCo.ctrla.CajaTexto(Me.components)
        Me.CajaTexto1 = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtrtn = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtCorreo = New SiCo.ctrla.CorreoCajaTexto(Me.components)
        Me.txtdireccion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txttelefono = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtidentifiacion = New SiCo.ctrla.IdentidadCajaTexto(Me.components)
        Me.cmbTipoIdentidad = New SiCo.ctrla2.ListaTipoIdentidad(Me.components)
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 62)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(70, 13)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Identificacion"
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
        Me.label1.Location = New System.Drawing.Point(346, 62)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(93, 13)
        Me.label1.TabIndex = 19
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
        'CajaTexto5
        '
        Me.CajaTexto5.ColorError = System.Drawing.Color.Red
        Me.CajaTexto5.EsObligatorio = False
        Me.CajaTexto5.ExpresionValidacion = ""
        Me.CajaTexto5.Location = New System.Drawing.Point(445, 33)
        Me.CajaTexto5.MaxLength = 30
        Me.CajaTexto5.MensajeError = Nothing
        Me.CajaTexto5.Name = "CajaTexto5"
        Me.CajaTexto5.Size = New System.Drawing.Size(238, 20)
        Me.CajaTexto5.TabIndex = 3
        Me.CajaTexto5.Texto = Nothing
        Me.CajaTexto5.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        '
        'CajaTexto4
        '
        Me.CajaTexto4.ColorError = System.Drawing.Color.Red
        Me.CajaTexto4.EsObligatorio = False
        Me.CajaTexto4.ExpresionValidacion = ""
        Me.CajaTexto4.Location = New System.Drawing.Point(445, 7)
        Me.CajaTexto4.MaxLength = 30
        Me.CajaTexto4.MensajeError = Nothing
        Me.CajaTexto4.Name = "CajaTexto4"
        Me.CajaTexto4.Size = New System.Drawing.Size(238, 20)
        Me.CajaTexto4.TabIndex = 1
        Me.CajaTexto4.Texto = Nothing
        Me.CajaTexto4.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        '
        'CajaTexto3
        '
        Me.CajaTexto3.ColorError = System.Drawing.Color.Red
        Me.CajaTexto3.EsObligatorio = True
        Me.CajaTexto3.ExpresionValidacion = ""
        Me.CajaTexto3.Location = New System.Drawing.Point(102, 33)
        Me.CajaTexto3.MaxLength = 30
        Me.CajaTexto3.MensajeError = Nothing
        Me.CajaTexto3.Name = "CajaTexto3"
        Me.CajaTexto3.Size = New System.Drawing.Size(238, 20)
        Me.CajaTexto3.TabIndex = 2
        Me.CajaTexto3.Texto = Nothing
        Me.CajaTexto3.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        '
        'CajaTexto2
        '
        Me.CajaTexto2.ColorError = System.Drawing.Color.Red
        Me.CajaTexto2.EsObligatorio = True
        Me.CajaTexto2.ExpresionValidacion = ""
        Me.CajaTexto2.Location = New System.Drawing.Point(102, 7)
        Me.CajaTexto2.MaxLength = 30
        Me.CajaTexto2.MensajeError = Nothing
        Me.CajaTexto2.Name = "CajaTexto2"
        Me.CajaTexto2.Size = New System.Drawing.Size(238, 20)
        Me.CajaTexto2.TabIndex = 0
        Me.CajaTexto2.Texto = Nothing
        Me.CajaTexto2.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.Location = New System.Drawing.Point(445, 112)
        Me.CajaTexto1.MaxLength = 255
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Multiline = True
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(238, 20)
        Me.CajaTexto1.TabIndex = 9
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        '
        'txtrtn
        '
        Me.txtrtn.ColorError = System.Drawing.Color.Red
        Me.txtrtn.EsObligatorio = False
        Me.txtrtn.ExpresionValidacion = Nothing
        Me.txtrtn.Location = New System.Drawing.Point(102, 85)
        Me.txtrtn.MaxLength = 255
        Me.txtrtn.MensajeError = Nothing
        Me.txtrtn.Name = "txtrtn"
        Me.txtrtn.Size = New System.Drawing.Size(238, 20)
        Me.txtrtn.TabIndex = 6
        Me.txtrtn.Texto = Nothing
        Me.txtrtn.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        '
        'txtCorreo
        '
        Me.txtCorreo.ColorError = System.Drawing.Color.Red
        Me.txtCorreo.EsObligatorio = False
        Me.txtCorreo.ExpresionValidacion = "^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" & _
            "-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" & _
            "9][0-9]|[1-9][0-9]|[0-9])\])$"
        Me.txtCorreo.Location = New System.Drawing.Point(445, 86)
        Me.txtCorreo.MaxLength = 255
        Me.txtCorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(238, 20)
        Me.txtCorreo.TabIndex = 7
        Me.txtCorreo.Texto = Nothing
        Me.txtCorreo.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        '
        'txtdireccion
        '
        Me.txtdireccion.ColorError = System.Drawing.Color.Red
        Me.txtdireccion.EsObligatorio = False
        Me.txtdireccion.ExpresionValidacion = Nothing
        Me.txtdireccion.Location = New System.Drawing.Point(102, 138)
        Me.txtdireccion.MensajeError = Nothing
        Me.txtdireccion.Multiline = True
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(581, 41)
        Me.txtdireccion.TabIndex = 10
        Me.txtdireccion.Texto = Nothing
        Me.txtdireccion.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        '
        'txttelefono
        '
        Me.txttelefono.ColorError = System.Drawing.Color.Red
        Me.txttelefono.EsObligatorio = False
        Me.txttelefono.ExpresionValidacion = Nothing
        Me.txttelefono.Location = New System.Drawing.Point(102, 111)
        Me.txttelefono.MaxLength = 255
        Me.txttelefono.MensajeError = Nothing
        Me.txttelefono.Multiline = True
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(238, 20)
        Me.txttelefono.TabIndex = 8
        Me.txttelefono.Texto = Nothing
        Me.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        '
        'txtidentifiacion
        '
        Me.txtidentifiacion.ColorError = System.Drawing.Color.Red
        Me.txtidentifiacion.EsObligatorio = True
        Me.txtidentifiacion.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]"
        Me.txtidentifiacion.Location = New System.Drawing.Point(102, 59)
        Me.txtidentifiacion.MaxLength = 15
        Me.txtidentifiacion.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232"
        Me.txtidentifiacion.Name = "txtidentifiacion"
        Me.txtidentifiacion.Size = New System.Drawing.Size(238, 20)
        Me.txtidentifiacion.TabIndex = 4
        Me.txtidentifiacion.Texto = Nothing
        Me.txtidentifiacion.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        '
        'cmbTipoIdentidad
        '
        Me.cmbTipoIdentidad.DisplayMember = "Descripcion"
        Me.cmbTipoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIdentidad.FormattingEnabled = True
        Me.cmbTipoIdentidad.Location = New System.Drawing.Point(445, 59)
        Me.cmbTipoIdentidad.Name = "cmbTipoIdentidad"
        Me.cmbTipoIdentidad.Size = New System.Drawing.Size(238, 21)
        Me.cmbTipoIdentidad.TabIndex = 5
        Me.cmbTipoIdentidad.ValueMember = "Valor"
        '
        'crtPersonaNatural
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbTipoIdentidad)
        Me.Controls.Add(Me.CajaTexto5)
        Me.Controls.Add(Me.CajaTexto4)
        Me.Controls.Add(Me.CajaTexto3)
        Me.Controls.Add(Me.CajaTexto2)
        Me.Controls.Add(Me.CajaTexto1)
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
        Me.Size = New System.Drawing.Size(692, 191)
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
    Private WithEvents CajaTexto1 As SiCo.ctrla.CajaTexto
    Private WithEvents CajaTexto2 As SiCo.ctrla.CajaTexto
    Private WithEvents CajaTexto3 As SiCo.ctrla.CajaTexto
    Private WithEvents CajaTexto4 As SiCo.ctrla.CajaTexto
    Private WithEvents CajaTexto5 As SiCo.ctrla.CajaTexto
    Friend WithEvents SubProceso As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbTipoIdentidad As SiCo.ctrla2.ListaTipoIdentidad

End Class

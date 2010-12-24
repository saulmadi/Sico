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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(crtPersonaNatural))
        Dim TipoIdentidad1 As SiCo.lgla.TipoIdentidad = New SiCo.lgla.TipoIdentidad
        Me.txtApellidos = New SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.txtNombre = New SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.txtrtn = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtCorreo = New SiCo.ctrla.CorreoCajaTexto(Me.components)
        Me.txtdireccion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txttelefono = New SiCo.ctrla.CajaTexto(Me.components)
        Me.cmbTipoIdentidad = New SiCo.ctrla.ListaDesplegable(Me.components)
        Me.txtidentifiacion = New SiCo.ctrla.IdentidadCajaTexto(Me.components)
        Me.label2 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtApellidos
        '
        Me.txtApellidos.AutoCompletar = True
        Me.txtApellidos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtApellidos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtApellidos.CampoMostrar = "apellidos"
        Me.txtApellidos.CaracteresInicio = 3
        Me.txtApellidos.ColeccionParametros = CType(resources.GetObject("txtApellidos.ColeccionParametros"), System.Collections.Generic.List(Of SiCo.lgla.Parametro))
        Me.txtApellidos.ColorError = System.Drawing.Color.Red
        Me.txtApellidos.EsObligatorio = False
        Me.txtApellidos.ExpresionValidacion = Nothing
        Me.txtApellidos.Location = New System.Drawing.Point(102, 33)
        Me.txtApellidos.MaxLength = 255
        Me.txtApellidos.MensajeError = Nothing
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.ParameteroBusqueda = "apellidos"
        Me.txtApellidos.Procedimiento = "PersonaNatural_Buscar"
        Me.txtApellidos.Size = New System.Drawing.Size(380, 20)
        Me.txtApellidos.TabIndex = 33
        Me.txtApellidos.Texto = Nothing
        Me.txtApellidos.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        '
        'txtNombre
        '
        Me.txtNombre.AutoCompletar = True
        Me.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNombre.CampoMostrar = "NombreCompleto"
        Me.txtNombre.CaracteresInicio = 3
        Me.txtNombre.ColeccionParametros = CType(resources.GetObject("txtNombre.ColeccionParametros"), System.Collections.Generic.List(Of SiCo.lgla.Parametro))
        Me.txtNombre.ColorError = System.Drawing.Color.Red
        Me.txtNombre.EsObligatorio = False
        Me.txtNombre.ExpresionValidacion = Nothing
        Me.txtNombre.Location = New System.Drawing.Point(102, 7)
        Me.txtNombre.MaxLength = 255
        Me.txtNombre.MensajeError = Nothing
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ParameteroBusqueda = "NombreCompleto"
        Me.txtNombre.Procedimiento = "PersonaNatural_Buscar"
        Me.txtNombre.Size = New System.Drawing.Size(380, 20)
        Me.txtNombre.TabIndex = 32
        Me.txtNombre.Texto = Nothing
        Me.txtNombre.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        '
        'txtrtn
        '
        Me.txtrtn.ColorError = System.Drawing.Color.Red
        Me.txtrtn.EsObligatorio = False
        Me.txtrtn.ExpresionValidacion = Nothing
        Me.txtrtn.Location = New System.Drawing.Point(102, 237)
        Me.txtrtn.MaxLength = 255
        Me.txtrtn.MensajeError = Nothing
        Me.txtrtn.Name = "txtrtn"
        Me.txtrtn.Size = New System.Drawing.Size(380, 20)
        Me.txtrtn.TabIndex = 23
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
        Me.txtCorreo.Location = New System.Drawing.Point(102, 210)
        Me.txtCorreo.MaxLength = 255
        Me.txtCorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(380, 20)
        Me.txtCorreo.TabIndex = 22
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
        Me.txtdireccion.Size = New System.Drawing.Size(380, 66)
        Me.txtdireccion.TabIndex = 21
        Me.txtdireccion.Texto = Nothing
        Me.txtdireccion.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        '
        'txttelefono
        '
        Me.txttelefono.ColorError = System.Drawing.Color.Red
        Me.txttelefono.EsObligatorio = False
        Me.txttelefono.ExpresionValidacion = Nothing
        Me.txttelefono.Location = New System.Drawing.Point(102, 112)
        Me.txttelefono.MaxLength = 255
        Me.txttelefono.MensajeError = Nothing
        Me.txttelefono.Multiline = True
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(380, 20)
        Me.txttelefono.TabIndex = 20
        Me.txttelefono.Texto = Nothing
        Me.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        '
        'cmbTipoIdentidad
        '
        Me.cmbTipoIdentidad.Comando = Nothing
        Me.cmbTipoIdentidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoIdentidad.FormattingEnabled = True
        Me.cmbTipoIdentidad.ListaDesplegablePadre = Nothing
        Me.cmbTipoIdentidad.Location = New System.Drawing.Point(102, 85)
        Me.cmbTipoIdentidad.Name = "cmbTipoIdentidad"
        Me.cmbTipoIdentidad.Size = New System.Drawing.Size(380, 21)
        Me.cmbTipoIdentidad.TabIndex = 19
        '
        'txtidentifiacion
        '
        Me.txtidentifiacion.ColorError = System.Drawing.Color.Red
        Me.txtidentifiacion.EsObligatorio = False
        Me.txtidentifiacion.ExpresionValidacion = "[0-1][0-8][0-9][0-9]-[1-2][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9]"
        Me.txtidentifiacion.Location = New System.Drawing.Point(102, 59)
        Me.txtidentifiacion.MaxLength = 255
        Me.txtidentifiacion.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232"
        Me.txtidentifiacion.Name = "txtidentifiacion"
        Me.txtidentifiacion.Size = New System.Drawing.Size(380, 20)
        Me.txtidentifiacion.TabIndex = 18
        Me.txtidentifiacion.Texto = Nothing
        TipoIdentidad1.Descripcion = "Identidad"
        TipoIdentidad1.Valor = "I"
        Me.txtidentifiacion.TipoIdentificacion = TipoIdentidad1
        Me.txtidentifiacion.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 62)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(70, 13)
        Me.label2.TabIndex = 26
        Me.label2.Text = "Identificacion"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 237)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(30, 13)
        Me.label8.TabIndex = 31
        Me.label8.Text = "RTN"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(3, 213)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(38, 13)
        Me.label7.TabIndex = 30
        Me.label7.Text = "Correo"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 141)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 13)
        Me.label6.TabIndex = 29
        Me.label6.Text = "Dirección"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 115)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(49, 13)
        Me.label5.TabIndex = 28
        Me.label5.Text = "Telefono"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(3, 36)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(49, 13)
        Me.label4.TabIndex = 25
        Me.label4.Text = "Apellidos"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(3, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(44, 13)
        Me.label3.TabIndex = 24
        Me.label3.Text = "Nombre"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(3, 88)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(93, 13)
        Me.label1.TabIndex = 27
        Me.label1.Text = "Tipo identificación"
        '
        'crtPersonaNatural
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtApellidos)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtrtn)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.cmbTipoIdentidad)
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
        Me.Size = New System.Drawing.Size(494, 264)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtApellidos As SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Private WithEvents txtNombre As SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Private WithEvents txtrtn As SiCo.ctrla.CajaTexto
    Private WithEvents txtCorreo As SiCo.ctrla.CorreoCajaTexto
    Private WithEvents txtdireccion As SiCo.ctrla.CajaTexto
    Private WithEvents txttelefono As SiCo.ctrla.CajaTexto
    Private WithEvents cmbTipoIdentidad As SiCo.ctrla.ListaDesplegable
    Private WithEvents txtidentifiacion As SiCo.ctrla.IdentidadCajaTexto
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label

End Class

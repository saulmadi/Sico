<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtPersonaJuridica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(crtPersonaJuridica))
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.lblRazonSocial = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnbuscar = New System.Windows.Forms.Button
        Me.lblEstado = New System.Windows.Forms.Label
        Me.SubProceso = New System.ComponentModel.BackgroundWorker
        Me.txtrazonsocial = New SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.txtdireccion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtcorreo = New SiCo.ctrla.CorreoCajaTexto(Me.components)
        Me.txtrtn = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtfax = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txttelefono = New SiCo.ctrla.CajaTexto(Me.components)
        Me.btnModificar = New System.Windows.Forms.Button
        Me.btnNueva = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 63)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(30, 13)
        Me.label8.TabIndex = 8
        Me.label8.Text = "RTN"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(303, 63)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(38, 13)
        Me.label7.TabIndex = 12
        Me.label7.Text = "Correo"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 89)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 13)
        Me.label6.TabIndex = 9
        Me.label6.Text = "Dirección"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 37)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(49, 13)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Telefono"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(3, 11)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(68, 13)
        Me.lblRazonSocial.TabIndex = 6
        Me.lblRazonSocial.Text = "Razón social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(303, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Fax"
        '
        'btnbuscar
        '
        Me.btnbuscar.BackgroundImage = CType(resources.GetObject("btnbuscar.BackgroundImage"), System.Drawing.Image)
        Me.btnbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbuscar.FlatAppearance.BorderSize = 0
        Me.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbuscar.Location = New System.Drawing.Point(478, 157)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(30, 27)
        Me.btnbuscar.TabIndex = 13
        Me.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(23, 159)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(449, 23)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Label12"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SubProceso
        '
        '
        'txtrazonsocial
        '
        Me.txtrazonsocial.AutoCompletar = True
        Me.txtrazonsocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtrazonsocial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtrazonsocial.BackColor = System.Drawing.SystemColors.Window
        Me.txtrazonsocial.CampoMostrar = "razonsocial"
        Me.txtrazonsocial.CaracteresInicio = 2
        Me.txtrazonsocial.ColorError = System.Drawing.Color.Red
        Me.txtrazonsocial.EnterPorTab = True
        Me.txtrazonsocial.EsObligatorio = True
        Me.txtrazonsocial.ExpresionValidacion = ""
        Me.txtrazonsocial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtrazonsocial.Location = New System.Drawing.Point(77, 8)
        Me.txtrazonsocial.MaxLength = 120
        Me.txtrazonsocial.MensajeError = "La razón social de la persona jurídica no puede ser vacía"
        Me.txtrazonsocial.Name = "txtrazonsocial"
        Me.txtrazonsocial.ParameteroBusqueda = "razonsocial"
        Me.txtrazonsocial.Procedimiento = Nothing
        Me.txtrazonsocial.Size = New System.Drawing.Size(503, 20)
        Me.txtrazonsocial.TabIndex = 0
        Me.txtrazonsocial.Texto = Nothing
        Me.txtrazonsocial.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtrazonsocial.ValorInt = Nothing
        '
        'txtdireccion
        '
        Me.txtdireccion.BackColor = System.Drawing.SystemColors.Window
        Me.txtdireccion.ColorError = System.Drawing.Color.Red
        Me.txtdireccion.EnterPorTab = True
        Me.txtdireccion.EsObligatorio = False
        Me.txtdireccion.ExpresionValidacion = Nothing
        Me.txtdireccion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtdireccion.Location = New System.Drawing.Point(77, 89)
        Me.txtdireccion.MaxLength = 150
        Me.txtdireccion.MensajeError = Nothing
        Me.txtdireccion.Multiline = True
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(503, 62)
        Me.txtdireccion.TabIndex = 5
        Me.txtdireccion.Texto = Nothing
        Me.txtdireccion.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        Me.txtdireccion.ValorInt = Nothing
        '
        'txtcorreo
        '
        Me.txtcorreo.BackColor = System.Drawing.SystemColors.Window
        Me.txtcorreo.ColorError = System.Drawing.Color.Red
        Me.txtcorreo.EnterPorTab = True
        Me.txtcorreo.EsObligatorio = False
        Me.txtcorreo.ExpresionValidacion = "^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" & _
            "-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" & _
            "9][0-9]|[1-9][0-9]|[0-9])\])$"
        Me.txtcorreo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcorreo.Location = New System.Drawing.Point(347, 60)
        Me.txtcorreo.MaxLength = 45
        Me.txtcorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.txtcorreo.Name = "txtcorreo"
        Me.txtcorreo.Size = New System.Drawing.Size(233, 20)
        Me.txtcorreo.TabIndex = 4
        Me.txtcorreo.Texto = Nothing
        Me.txtcorreo.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtcorreo.ValorInt = Nothing
        '
        'txtrtn
        '
        Me.txtrtn.BackColor = System.Drawing.SystemColors.Window
        Me.txtrtn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrtn.ColorError = System.Drawing.Color.Red
        Me.txtrtn.EnterPorTab = True
        Me.txtrtn.EsObligatorio = False
        Me.txtrtn.ExpresionValidacion = Nothing
        Me.txtrtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtrtn.Location = New System.Drawing.Point(77, 60)
        Me.txtrtn.MaxLength = 13
        Me.txtrtn.MensajeError = Nothing
        Me.txtrtn.Name = "txtrtn"
        Me.txtrtn.Size = New System.Drawing.Size(220, 20)
        Me.txtrtn.TabIndex = 3
        Me.txtrtn.Texto = Nothing
        Me.txtrtn.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtrtn.ValorInt = Nothing
        '
        'txtfax
        '
        Me.txtfax.BackColor = System.Drawing.SystemColors.Window
        Me.txtfax.ColorError = System.Drawing.Color.Red
        Me.txtfax.EnterPorTab = True
        Me.txtfax.EsObligatorio = False
        Me.txtfax.ExpresionValidacion = Nothing
        Me.txtfax.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfax.Location = New System.Drawing.Point(347, 34)
        Me.txtfax.MaxLength = 11
        Me.txtfax.MensajeError = Nothing
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(233, 20)
        Me.txtfax.TabIndex = 2
        Me.txtfax.Texto = Nothing
        Me.txtfax.TipoTexto = SiCo.ctrla.TiposTexto.Entero
        Me.txtfax.ValorInt = Nothing
        '
        'txttelefono
        '
        Me.txttelefono.BackColor = System.Drawing.SystemColors.Window
        Me.txttelefono.ColorError = System.Drawing.Color.Red
        Me.txttelefono.EnterPorTab = True
        Me.txttelefono.EsObligatorio = False
        Me.txttelefono.ExpresionValidacion = Nothing
        Me.txttelefono.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txttelefono.Location = New System.Drawing.Point(77, 34)
        Me.txttelefono.MaxLength = 11
        Me.txttelefono.MensajeError = Nothing
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(220, 20)
        Me.txttelefono.TabIndex = 1
        Me.txttelefono.Texto = Nothing
        Me.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Entero
        Me.txttelefono.ValorInt = Nothing
        '
        'btnModificar
        '
        Me.btnModificar.BackgroundImage = CType(resources.GetObject("btnModificar.BackgroundImage"), System.Drawing.Image)
        Me.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnModificar.FlatAppearance.BorderSize = 0
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificar.Location = New System.Drawing.Point(550, 157)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(30, 27)
        Me.btnModificar.TabIndex = 27
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNueva
        '
        Me.btnNueva.BackgroundImage = CType(resources.GetObject("btnNueva.BackgroundImage"), System.Drawing.Image)
        Me.btnNueva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNueva.FlatAppearance.BorderSize = 0
        Me.btnNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNueva.Location = New System.Drawing.Point(514, 157)
        Me.btnNueva.Name = "btnNueva"
        Me.btnNueva.Size = New System.Drawing.Size(30, 27)
        Me.btnNueva.TabIndex = 26
        Me.btnNueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNueva.UseVisualStyleBackColor = True
        '
        'crtPersonaJuridica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnNueva)
        Me.Controls.Add(Me.txtrazonsocial)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.txtcorreo)
        Me.Controls.Add(Me.txtrtn)
        Me.Controls.Add(Me.txtfax)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.btnbuscar)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.lblRazonSocial)
        Me.Name = "crtPersonaJuridica"
        Me.Size = New System.Drawing.Size(583, 194)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents lblRazonSocial As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents SubProceso As System.ComponentModel.BackgroundWorker
    Friend WithEvents txttelefono As SiCo.ctrla.CajaTexto
    Friend WithEvents txtfax As SiCo.ctrla.CajaTexto
    Friend WithEvents txtrtn As SiCo.ctrla.CajaTexto
    Friend WithEvents txtcorreo As SiCo.ctrla.CorreoCajaTexto
    Friend WithEvents txtdireccion As SiCo.ctrla.CajaTexto
    Friend WithEvents txtrazonsocial As SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnNueva As System.Windows.Forms.Button

End Class

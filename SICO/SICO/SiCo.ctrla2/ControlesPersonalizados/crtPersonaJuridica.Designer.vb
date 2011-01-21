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
        Me.txtNombre = New SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.txtrtn = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtCorreo = New SiCo.ctrla.CorreoCajaTexto(Me.components)
        Me.txtdireccion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txttelefono = New SiCo.ctrla.CajaTexto(Me.components)
        Me.CajaTexto1 = New SiCo.ctrla.CajaTexto(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnbuscar = New System.Windows.Forms.Button
        Me.lblEstado = New System.Windows.Forms.Label
        Me.SubProceso = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 63)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(30, 13)
        Me.label8.TabIndex = 31
        Me.label8.Text = "RTN"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(303, 63)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(38, 13)
        Me.label7.TabIndex = 30
        Me.label7.Text = "Correo"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 89)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 13)
        Me.label6.TabIndex = 29
        Me.label6.Text = "Dirección"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 37)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(49, 13)
        Me.label5.TabIndex = 28
        Me.label5.Text = "Telefono"
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.AutoSize = True
        Me.lblRazonSocial.Location = New System.Drawing.Point(3, 11)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.Size(68, 13)
        Me.lblRazonSocial.TabIndex = 24
        Me.lblRazonSocial.Text = "Razón social"
        '
        'txtNombre
        '
        Me.txtNombre.AutoCompletar = True
        Me.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtNombre.CampoMostrar = Nothing
        Me.txtNombre.CaracteresInicio = 3
        Me.txtNombre.ColeccionParametros = CType(resources.GetObject("txtNombre.ColeccionParametros"), System.Collections.Generic.List(Of SiCo.lgla.Parametro))
        Me.txtNombre.ColorError = System.Drawing.Color.Red
        Me.txtNombre.EnterPorTab = True
        Me.txtNombre.EsObligatorio = True
        Me.txtNombre.ExpresionValidacion = ""
        Me.txtNombre.Location = New System.Drawing.Point(77, 8)
        Me.txtNombre.MaxLength = 120
        Me.txtNombre.MensajeError = Nothing
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ParameteroBusqueda = ""
        Me.txtNombre.Procedimiento = Nothing
        Me.txtNombre.Size = New System.Drawing.Size(503, 20)
        Me.txtNombre.TabIndex = 32
        Me.txtNombre.Texto = Nothing
        Me.txtNombre.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtNombre.ValorInt = Nothing
        '
        'txtrtn
        '
        Me.txtrtn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrtn.ColorError = System.Drawing.Color.Red
        Me.txtrtn.EnterPorTab = True
        Me.txtrtn.EsObligatorio = False
        Me.txtrtn.ExpresionValidacion = Nothing
        Me.txtrtn.Location = New System.Drawing.Point(77, 60)
        Me.txtrtn.MaxLength = 255
        Me.txtrtn.MensajeError = Nothing
        Me.txtrtn.Name = "txtrtn"
        Me.txtrtn.Size = New System.Drawing.Size(220, 20)
        Me.txtrtn.TabIndex = 23
        Me.txtrtn.Texto = Nothing
        Me.txtrtn.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtrtn.ValorInt = Nothing
        '
        'txtCorreo
        '
        Me.txtCorreo.ColorError = System.Drawing.Color.Red
        Me.txtCorreo.EnterPorTab = True
        Me.txtCorreo.EsObligatorio = False
        Me.txtCorreo.ExpresionValidacion = "^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0" & _
            "-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-" & _
            "9][0-9]|[1-9][0-9]|[0-9])\])$"
        Me.txtCorreo.Location = New System.Drawing.Point(347, 60)
        Me.txtCorreo.MaxLength = 255
        Me.txtCorreo.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(233, 20)
        Me.txtCorreo.TabIndex = 22
        Me.txtCorreo.Texto = Nothing
        Me.txtCorreo.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtCorreo.ValorInt = Nothing
        '
        'txtdireccion
        '
        Me.txtdireccion.ColorError = System.Drawing.Color.Red
        Me.txtdireccion.EnterPorTab = True
        Me.txtdireccion.EsObligatorio = False
        Me.txtdireccion.ExpresionValidacion = Nothing
        Me.txtdireccion.Location = New System.Drawing.Point(77, 86)
        Me.txtdireccion.MensajeError = Nothing
        Me.txtdireccion.Multiline = True
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(503, 66)
        Me.txtdireccion.TabIndex = 21
        Me.txtdireccion.Texto = Nothing
        Me.txtdireccion.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        Me.txtdireccion.ValorInt = Nothing
        '
        'txttelefono
        '
        Me.txttelefono.ColorError = System.Drawing.Color.Red
        Me.txttelefono.EnterPorTab = True
        Me.txttelefono.EsObligatorio = False
        Me.txttelefono.ExpresionValidacion = Nothing
        Me.txttelefono.Location = New System.Drawing.Point(77, 34)
        Me.txttelefono.MaxLength = 255
        Me.txttelefono.MensajeError = Nothing
        Me.txttelefono.Multiline = True
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(220, 20)
        Me.txttelefono.TabIndex = 20
        Me.txttelefono.Texto = Nothing
        Me.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Entero
        Me.txttelefono.ValorInt = Nothing
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EnterPorTab = True
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.Location = New System.Drawing.Point(347, 34)
        Me.CajaTexto1.MaxLength = 255
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Multiline = True
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(233, 20)
        Me.CajaTexto1.TabIndex = 33
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SiCo.ctrla.TiposTexto.Entero
        Me.CajaTexto1.ValorInt = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(303, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Fax"
        '
        'btnbuscar
        '
        Me.btnbuscar.BackgroundImage = CType(resources.GetObject("btnbuscar.BackgroundImage"), System.Drawing.Image)
        Me.btnbuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnbuscar.FlatAppearance.BorderSize = 0
        Me.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnbuscar.Location = New System.Drawing.Point(545, 157)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(30, 27)
        Me.btnbuscar.TabIndex = 36
        Me.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(181, 158)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(357, 23)
        Me.lblEstado.TabIndex = 35
        Me.lblEstado.Text = "Label12"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SubProceso
        '
        '
        'crtPersonaJuridica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnbuscar)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CajaTexto1)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtrtn)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.txttelefono)
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
    Private WithEvents txtrtn As SiCo.ctrla.CajaTexto
    Private WithEvents txtCorreo As SiCo.ctrla.CorreoCajaTexto
    Private WithEvents txtdireccion As SiCo.ctrla.CajaTexto
    Private WithEvents txttelefono As SiCo.ctrla.CajaTexto
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents lblRazonSocial As System.Windows.Forms.Label
    Private WithEvents CajaTexto1 As SiCo.ctrla.CajaTexto
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtNombre As SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents SubProceso As System.ComponentModel.BackgroundWorker

End Class

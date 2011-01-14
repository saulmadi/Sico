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
        Me.txtNombre = New SiCo.ctrla.ControlesBasicos.AutoCompleteCajaTexto(Me.components)
        Me.txtrtn = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txtCorreo = New SiCo.ctrla.CorreoCajaTexto(Me.components)
        Me.txtdireccion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.txttelefono = New SiCo.ctrla.CajaTexto(Me.components)
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.lblRazonSocial = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtNombre
        '

        Me.txtNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        
        Me.txtNombre.ColorError = System.Drawing.Color.Red
        Me.txtNombre.EsObligatorio = False
        Me.txtNombre.ExpresionValidacion = Nothing
        Me.txtNombre.Location = New System.Drawing.Point(102, 8)
        Me.txtNombre.MaxLength = 255
        Me.txtNombre.MensajeError = Nothing
        Me.txtNombre.Name = "txtNombre"
        
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
        Me.txtrtn.Location = New System.Drawing.Point(102, 159)
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
        Me.txtCorreo.Location = New System.Drawing.Point(102, 132)
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
        Me.txtdireccion.Location = New System.Drawing.Point(102, 60)
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
        Me.txttelefono.Location = New System.Drawing.Point(102, 34)
        Me.txttelefono.MaxLength = 255
        Me.txttelefono.MensajeError = Nothing
        Me.txttelefono.Multiline = True
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(380, 20)
        Me.txttelefono.TabIndex = 20
        Me.txttelefono.Texto = Nothing
        Me.txttelefono.TipoTexto = SiCo.ctrla.TiposTexto.Parrafo
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 159)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(30, 13)
        Me.label8.TabIndex = 31
        Me.label8.Text = "RTN"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(3, 135)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(38, 13)
        Me.label7.TabIndex = 30
        Me.label7.Text = "Correo"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 63)
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
        'crtPersonaJuridica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
        Me.Size = New System.Drawing.Size(491, 193)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtNombre As SiCo.ctrla.CajaTexto
    Private WithEvents txtrtn As SiCo.ctrla.CajaTexto
    Private WithEvents txtCorreo As SiCo.ctrla.CorreoCajaTexto
    Private WithEvents txtdireccion As SiCo.ctrla.CajaTexto
    Private WithEvents txttelefono As SiCo.ctrla.CajaTexto
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents lblRazonSocial As System.Windows.Forms.Label

End Class

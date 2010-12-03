<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Prueba
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.CrtlPersonaNatural1 = New SICO.ctrla.ControlesPersonalizados.crtlPersonaNatural
        Me.CorreoCajaTexto1 = New SICO.ctrla.CorreoCajaTexto(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(625, 201)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CrtlPersonaNatural1
        '
        Me.CrtlPersonaNatural1.Location = New System.Drawing.Point(1, 40)
        Me.CrtlPersonaNatural1.Name = "CrtlPersonaNatural1"
        Me.CrtlPersonaNatural1.Size = New System.Drawing.Size(546, 290)
        Me.CrtlPersonaNatural1.TabIndex = 1
        '
        'CorreoCajaTexto1
        '
        Me.CorreoCajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CorreoCajaTexto1.EsObligatorio = False

        Me.CorreoCajaTexto1.Location = New System.Drawing.Point(422, 391)
        Me.CorreoCajaTexto1.MaxLength = 255
        Me.CorreoCajaTexto1.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.CorreoCajaTexto1.Name = "CorreoCajaTexto1"
        Me.CorreoCajaTexto1.Size = New System.Drawing.Size(100, 20)
        Me.CorreoCajaTexto1.TabIndex = 2
        Me.CorreoCajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 503)
        Me.Controls.Add(Me.CorreoCajaTexto1)
        Me.Controls.Add(Me.CrtlPersonaNatural1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CrtlPersonaNatural1 As SICO.ctrla.ControlesPersonalizados.crtlPersonaNatural
    Friend WithEvents CorreoCajaTexto1 As SICO.ctrla.CorreoCajaTexto
  

End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracionBDD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracionBDD))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbpuerto = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.txtbasedatos = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtcontrasena = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtusuario = New SICO.ctrla.CajaTexto(Me.components)
        Me.txtservidor = New SICO.ctrla.CajaTexto(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(293, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Puerto"
        '
        'cmbpuerto
        '
        Me.cmbpuerto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbpuerto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbpuerto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpuerto.FormattingEnabled = True
        Me.cmbpuerto.Items.AddRange(New Object() {"3306", "3307", "3308", "3309"})
        Me.cmbpuerto.Location = New System.Drawing.Point(337, 78)
        Me.cmbpuerto.Name = "cmbpuerto"
        Me.cmbpuerto.Size = New System.Drawing.Size(94, 21)
        Me.cmbpuerto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Usuario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Contraseña"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(25, 210)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Probar Conexión"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Base de Datos"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(217, 210)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Aceptar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(327, 210)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 23)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Cancelar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtbasedatos
        '
        Me.txtbasedatos.BackColor = System.Drawing.SystemColors.Window
        Me.txtbasedatos.ColorError = System.Drawing.Color.Red
        Me.txtbasedatos.EsObligatorio = True
        Me.txtbasedatos.ExpresionValidacion = Nothing
        Me.txtbasedatos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtbasedatos.Location = New System.Drawing.Point(105, 156)
        Me.txtbasedatos.MensajeError = Nothing
        Me.txtbasedatos.Name = "txtbasedatos"
        Me.txtbasedatos.Size = New System.Drawing.Size(182, 20)
        Me.txtbasedatos.TabIndex = 16
        Me.txtbasedatos.Texto = Nothing
        Me.txtbasedatos.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'txtcontrasena
        '
        Me.txtcontrasena.BackColor = System.Drawing.SystemColors.Window
        Me.txtcontrasena.ColorError = System.Drawing.Color.Red
        Me.txtcontrasena.EsObligatorio = True
        Me.txtcontrasena.ExpresionValidacion = Nothing
        Me.txtcontrasena.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcontrasena.Location = New System.Drawing.Point(105, 130)
        Me.txtcontrasena.MensajeError = Nothing
        Me.txtcontrasena.Name = "txtcontrasena"
        Me.txtcontrasena.Size = New System.Drawing.Size(182, 20)
        Me.txtcontrasena.TabIndex = 15
        Me.txtcontrasena.Texto = Nothing
        Me.txtcontrasena.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.txtcontrasena.UseSystemPasswordChar = True
        '
        'txtusuario
        '
        Me.txtusuario.BackColor = System.Drawing.SystemColors.Window
        Me.txtusuario.ColorError = System.Drawing.Color.Red
        Me.txtusuario.EsObligatorio = True
        Me.txtusuario.ExpresionValidacion = Nothing
        Me.txtusuario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtusuario.Location = New System.Drawing.Point(105, 104)
        Me.txtusuario.MensajeError = Nothing
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(182, 20)
        Me.txtusuario.TabIndex = 14
        Me.txtusuario.Texto = Nothing
        Me.txtusuario.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'txtservidor
        '
        Me.txtservidor.BackColor = System.Drawing.SystemColors.Window
        Me.txtservidor.ColorError = System.Drawing.Color.Red
        Me.txtservidor.EsObligatorio = True
        Me.txtservidor.ExpresionValidacion = Nothing
        Me.txtservidor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtservidor.Location = New System.Drawing.Point(105, 78)
        Me.txtservidor.MensajeError = Nothing
        Me.txtservidor.Name = "txtservidor"
        Me.txtservidor.Size = New System.Drawing.Size(182, 20)
        Me.txtservidor.TabIndex = 13
        Me.txtservidor.Texto = Nothing
        Me.txtservidor.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'frmConfiguracionBDD
        '
        Me.AcceptButton = Me.Button2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button3
        Me.ClientSize = New System.Drawing.Size(443, 263)
        Me.Controls.Add(Me.txtbasedatos)
        Me.Controls.Add(Me.txtcontrasena)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.txtservidor)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbpuerto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfiguracionBDD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbpuerto As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtservidor As SiCo.ctrla.CajaTexto
    Friend WithEvents txtusuario As SiCo.ctrla.CajaTexto
    Friend WithEvents txtcontrasena As SiCo.ctrla.CajaTexto
    Friend WithEvents txtbasedatos As SiCo.ctrla.CajaTexto
End Class

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
        Me.Button2 = New System.Windows.Forms.Button
        Me.Cmb = New System.Windows.Forms.ComboBox
        Me.ComboBox3 = New System.Windows.Forms.ComboBox
        Me.ComboBox4 = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.CajaTexto3 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Grid1 = New SICO.ctrla.Grid(Me.components)
        Me.ListaDesplegable3 = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.ListaDesplegable2 = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.IdentidadCajaTexto3 = New SICO.ctrla.IdentidadCajaTexto(Me.components)
        Me.ListaDesplegable1 = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.IdentidadCajaTexto2 = New SICO.ctrla.IdentidadCajaTexto(Me.components)
        Me.IdentidadCajaTexto1 = New SICO.ctrla.IdentidadCajaTexto(Me.components)
        Me.CorreoCajaTexto1 = New SICO.ctrla.CorreoCajaTexto(Me.components)
        Me.CajaTexto2 = New SICO.ctrla.CajaTexto(Me.components)
        Me.CajaTexto1 = New SICO.ctrla.CajaTexto(Me.components)
        Me.Grid2 = New SICO.ctrla.Grid(Me.components)
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(233, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(233, 31)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Cmb
        '
        Me.Cmb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Cmb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cmb.FormattingEnabled = True
        Me.Cmb.Location = New System.Drawing.Point(61, 182)
        Me.Cmb.Name = "Cmb"
        Me.Cmb.Size = New System.Drawing.Size(121, 21)
        Me.Cmb.TabIndex = 6
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(61, 209)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox3.TabIndex = 6
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(61, 236)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox4.TabIndex = 6
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(281, 271)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(695, 52)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(695, 102)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "Button4"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'CajaTexto3
        '
        Me.CajaTexto3.ColorError = System.Drawing.Color.Red
        Me.CajaTexto3.EsObligatorio = False
        Me.CajaTexto3.ExpresionValidacion = ""
        Me.CajaTexto3.Location = New System.Drawing.Point(102, 131)
        Me.CajaTexto3.MaxLength = 255
        Me.CajaTexto3.MensajeError = Nothing
        Me.CajaTexto3.Name = "CajaTexto3"
        Me.CajaTexto3.Size = New System.Drawing.Size(100, 20)
        Me.CajaTexto3.TabIndex = 17
        Me.CajaTexto3.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.BotonEditar = True
        Me.Grid1.BotonEliminar = True
        Me.Grid1.CampoId = Nothing
        Me.Grid1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid1.Location = New System.Drawing.Point(180, 310)
        Me.Grid1.MultiSelect = False
        Me.Grid1.Name = "Grid1"
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid1.Size = New System.Drawing.Size(638, 150)
        Me.Grid1.TabIndex = 14
        '
        'ListaDesplegable3
        '
        Me.ListaDesplegable3.Comando = Nothing
        Me.ListaDesplegable3.FormattingEnabled = True
        Me.ListaDesplegable3.ListaDesplegablePadre = Me.ListaDesplegable2
        Me.ListaDesplegable3.Location = New System.Drawing.Point(12, 380)
        Me.ListaDesplegable3.Name = "ListaDesplegable3"
        Me.ListaDesplegable3.ParametroBusqueda = Nothing
        Me.ListaDesplegable3.Size = New System.Drawing.Size(121, 21)
        Me.ListaDesplegable3.TabIndex = 13
        '
        'ListaDesplegable2
        '
        Me.ListaDesplegable2.Comando = Nothing
        Me.ListaDesplegable2.FormattingEnabled = True
        Me.ListaDesplegable2.ListaDesplegablePadre = Nothing
        Me.ListaDesplegable2.Location = New System.Drawing.Point(11, 353)
        Me.ListaDesplegable2.Name = "ListaDesplegable2"
        Me.ListaDesplegable2.ParametroBusqueda = Nothing
        Me.ListaDesplegable2.Size = New System.Drawing.Size(121, 21)
        Me.ListaDesplegable2.TabIndex = 11
        '
        'IdentidadCajaTexto3
        '
        Me.IdentidadCajaTexto3.ColorError = System.Drawing.Color.Red
        Me.IdentidadCajaTexto3.EsObligatorio = False
        Me.IdentidadCajaTexto3.ExpresionValidacion = ""
        Me.IdentidadCajaTexto3.Location = New System.Drawing.Point(61, 81)
        Me.IdentidadCajaTexto3.MaxLength = 255
        Me.IdentidadCajaTexto3.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232"
        Me.IdentidadCajaTexto3.Name = "IdentidadCajaTexto3"
        Me.IdentidadCajaTexto3.Size = New System.Drawing.Size(100, 20)
        Me.IdentidadCajaTexto3.TabIndex = 12
        Me.IdentidadCajaTexto3.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.IdentidadCajaTexto3.UseSystemPasswordChar = True
        '
        'ListaDesplegable1
        '
        Me.ListaDesplegable1.Comando = Nothing
        Me.ListaDesplegable1.FormattingEnabled = True
        Me.ListaDesplegable1.ListaDesplegablePadre = Nothing
        Me.ListaDesplegable1.Location = New System.Drawing.Point(12, 326)
        Me.ListaDesplegable1.Name = "ListaDesplegable1"
        Me.ListaDesplegable1.ParametroBusqueda = Nothing
        Me.ListaDesplegable1.Size = New System.Drawing.Size(121, 21)
        Me.ListaDesplegable1.TabIndex = 10
        '
        'IdentidadCajaTexto2
        '
        Me.IdentidadCajaTexto2.ColorError = System.Drawing.Color.Red
        Me.IdentidadCajaTexto2.EsObligatorio = False
        Me.IdentidadCajaTexto2.ExpresionValidacion = ""
        Me.IdentidadCajaTexto2.Location = New System.Drawing.Point(233, 81)
        Me.IdentidadCajaTexto2.MaxLength = 255
        Me.IdentidadCajaTexto2.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232"
        Me.IdentidadCajaTexto2.Name = "IdentidadCajaTexto2"
        Me.IdentidadCajaTexto2.Size = New System.Drawing.Size(100, 20)
        Me.IdentidadCajaTexto2.TabIndex = 9
        Me.IdentidadCajaTexto2.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'IdentidadCajaTexto1
        '
        Me.IdentidadCajaTexto1.ColorError = System.Drawing.Color.Red
        Me.IdentidadCajaTexto1.EsObligatorio = False
        Me.IdentidadCajaTexto1.ExpresionValidacion = ""
        Me.IdentidadCajaTexto1.Location = New System.Drawing.Point(391, 105)
        Me.IdentidadCajaTexto1.MaxLength = 255
        Me.IdentidadCajaTexto1.MensajeError = "El número de identida debe tener este formato: 0301-1933-00232"
        Me.IdentidadCajaTexto1.Name = "IdentidadCajaTexto1"
        Me.IdentidadCajaTexto1.Size = New System.Drawing.Size(100, 20)
        Me.IdentidadCajaTexto1.TabIndex = 5
        Me.IdentidadCajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'CorreoCajaTexto1
        '
        Me.CorreoCajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CorreoCajaTexto1.EsObligatorio = False
        Me.CorreoCajaTexto1.ExpresionValidacion = ""
        Me.CorreoCajaTexto1.Location = New System.Drawing.Point(391, 82)
        Me.CorreoCajaTexto1.MaxLength = 255
        Me.CorreoCajaTexto1.MensajeError = "El correo electrónico debe tener este formato: abc@dominio.com"
        Me.CorreoCajaTexto1.Name = "CorreoCajaTexto1"
        Me.CorreoCajaTexto1.Size = New System.Drawing.Size(100, 20)
        Me.CorreoCajaTexto1.TabIndex = 4
        Me.CorreoCajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        '
        'CajaTexto2
        '
        Me.CajaTexto2.ColorError = System.Drawing.Color.Red
        Me.CajaTexto2.EsObligatorio = False
        Me.CajaTexto2.ExpresionValidacion = ""
        Me.CajaTexto2.Location = New System.Drawing.Point(391, 56)
        Me.CajaTexto2.MaxLength = 12
        Me.CajaTexto2.MensajeError = Nothing
        Me.CajaTexto2.Multiline = True
        Me.CajaTexto2.Name = "CajaTexto2"
        Me.CajaTexto2.Size = New System.Drawing.Size(100, 20)
        Me.CajaTexto2.TabIndex = 3
        Me.CajaTexto2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CajaTexto2.TipoTexto = SICO.ctrla.TiposTexto.Parrafo
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = "^(?!^0*$)(?!^0*\.0*$)^\d{1,9}(\.\d{1,3})?$"
        Me.CajaTexto1.Location = New System.Drawing.Point(391, 131)
        Me.CajaTexto1.MaxLength = 12
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Multiline = True
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(100, 20)
        Me.CajaTexto1.TabIndex = 2
        Me.CajaTexto1.Text = "0.00"
        Me.CajaTexto1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.[Decimal]
        '
        'Grid2
        '
        Me.Grid2.AllowUserToAddRows = False
        Me.Grid2.AllowUserToDeleteRows = False
        Me.Grid2.BotonEditar = False
        Me.Grid2.BotonEliminar = False
        Me.Grid2.CampoId = Nothing
        Me.Grid2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid2.Location = New System.Drawing.Point(483, 144)
        Me.Grid2.MultiSelect = False
        Me.Grid2.Name = "Grid2"
        Me.Grid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid2.Size = New System.Drawing.Size(240, 150)
        Me.Grid2.TabIndex = 18
        '
        'PanelAccion1
        '
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.HabilitarCancelar = True
        Me.PanelAccion1.habilitarEliminar = True
        Me.PanelAccion1.HabilitarGuardar = True
        Me.PanelAccion1.habilitarImprimir = True
        Me.PanelAccion1.HabilitarNuevo = True
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(857, 503)
        Me.PanelAccion1.TabIndex = 19
        Me.PanelAccion1.Titulo = "Título"
        '
        'Prueba
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 503)
        Me.Controls.Add(Me.PanelAccion1)
        Me.Controls.Add(Me.Grid2)
        Me.Controls.Add(Me.CajaTexto3)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Grid1)
        Me.Controls.Add(Me.ListaDesplegable3)
        Me.Controls.Add(Me.IdentidadCajaTexto3)
        Me.Controls.Add(Me.ListaDesplegable2)
        Me.Controls.Add(Me.ListaDesplegable1)
        Me.Controls.Add(Me.IdentidadCajaTexto2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Cmb)
        Me.Controls.Add(Me.IdentidadCajaTexto1)
        Me.Controls.Add(Me.CorreoCajaTexto1)
        Me.Controls.Add(Me.CajaTexto2)
        Me.Controls.Add(Me.CajaTexto1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Prueba"
        Me.Text = "Prueba"
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CajaTexto1 As SICO.ctrla.CajaTexto
    Friend WithEvents CajaTexto2 As SICO.ctrla.CajaTexto
    Friend WithEvents CorreoCajaTexto1 As SICO.ctrla.CorreoCajaTexto
    Friend WithEvents IdentidadCajaTexto1 As SICO.ctrla.IdentidadCajaTexto
    Friend WithEvents Cmb As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents IdentidadCajaTexto2 As SICO.ctrla.IdentidadCajaTexto
    Friend WithEvents ListaDesplegable1 As SICO.ctrla.ListaDesplegable
    Friend WithEvents ListaDesplegable2 As SICO.ctrla.ListaDesplegable
    Friend WithEvents IdentidadCajaTexto3 As SICO.ctrla.IdentidadCajaTexto
    Friend WithEvents ListaDesplegable3 As SICO.ctrla.ListaDesplegable
    Friend WithEvents Grid1 As SICO.ctrla.Grid
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents CajaTexto3 As SICO.ctrla.CajaTexto
    Friend WithEvents Grid2 As SICO.ctrla.Grid
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion

End Class

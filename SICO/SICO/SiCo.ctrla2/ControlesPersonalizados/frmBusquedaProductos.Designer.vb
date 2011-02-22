<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBusquedaProductos
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
        Me.txtdescripcion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.panelparametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelparametros
        '
        Me.panelparametros.Controls.Add(Me.Label1)
        Me.panelparametros.Controls.Add(Me.txtdescripcion)
        Me.panelparametros.Size = New System.Drawing.Size(681, 48)
        '
        'txtdescripcion
        '
        Me.txtdescripcion.BackColor = System.Drawing.SystemColors.Window
        Me.txtdescripcion.ColorError = System.Drawing.Color.Red
        Me.txtdescripcion.EnterPorTab = True
        Me.txtdescripcion.EsObligatorio = False
        Me.txtdescripcion.ExpresionValidacion = Nothing
        Me.txtdescripcion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtdescripcion.Location = New System.Drawing.Point(81, 15)
        Me.txtdescripcion.MensajeError = Nothing
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(260, 20)
        Me.txtdescripcion.TabIndex = 0
        Me.txtdescripcion.Texto = Nothing
        Me.txtdescripcion.TipoTexto = SiCo.ctrla.TiposTexto.Alfanumerico
        Me.txtdescripcion.ValorInt = Nothing
        Me.txtdescripcion.ValorLong = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Descripción"
        '
        'frmBusquedaProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 506)
        Me.Name = "frmBusquedaProductos"
        Me.Text = "Busqueda de Productos"
        Me.VerParametros = True
        Me.panelparametros.ResumeLayout(False)
        Me.panelparametros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtdescripcion As SiCo.ctrla.CajaTexto
End Class

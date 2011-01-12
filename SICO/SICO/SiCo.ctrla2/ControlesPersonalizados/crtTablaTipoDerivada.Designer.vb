<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtTablaTipoDerivada

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
        Me.lblDerivado = New System.Windows.Forms.Label
        Me.cmbDerivado = New SiCo.ctrla.ListaDesplegable(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelAccion
        '
        '
        'crtBusqueda
        '
        Me.crtBusqueda.CampoAMostrar = "descripcion"
        Me.crtBusqueda.NombreParametroBusqueda = "descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(89, 19)
        Me.txtDescripcion.Size = New System.Drawing.Size(301, 20)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbDerivado)
        Me.GroupBox2.Controls.Add(Me.lblDerivado)
        Me.GroupBox2.Size = New System.Drawing.Size(396, 130)
        Me.GroupBox2.Controls.SetChildIndex(Me.Label2, 0)
        Me.GroupBox2.Controls.SetChildIndex(Me.cmbEstado, 0)
        Me.GroupBox2.Controls.SetChildIndex(Me.lblDerivado, 0)
        Me.GroupBox2.Controls.SetChildIndex(Me.cmbDerivado, 0)
        Me.GroupBox2.Controls.SetChildIndex(Me.txtDescripcion, 0)
        Me.GroupBox2.Controls.SetChildIndex(Me.Label1, 0)
        '
        'Label1
        '
        Me.Label1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 75)
        Me.Label2.TabIndex = 5
        '
        'cmbEstado
        '
        Me.cmbEstado.Location = New System.Drawing.Point(89, 72)
        Me.cmbEstado.Size = New System.Drawing.Size(301, 21)
        Me.cmbEstado.TabIndex = 2
        '
        'lblDerivado
        '
        Me.lblDerivado.AutoSize = True
        Me.lblDerivado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDerivado.Location = New System.Drawing.Point(6, 48)
        Me.lblDerivado.Name = "lblDerivado"
        Me.lblDerivado.Size = New System.Drawing.Size(60, 13)
        Me.lblDerivado.TabIndex = 4
        Me.lblDerivado.Text = "lblDerivado"
        '
        'cmbDerivado
        '
        Me.cmbDerivado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDerivado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDerivado.CargarAutoCompletar = False
        Me.cmbDerivado.DisplayMember = "descripcion"
        Me.cmbDerivado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDerivado.FormattingEnabled = True
        Me.cmbDerivado.Location = New System.Drawing.Point(89, 46)
        Me.cmbDerivado.Name = "cmbDerivado"
        Me.cmbDerivado.ParametroAutocompletar = Nothing
        Me.cmbDerivado.Size = New System.Drawing.Size(301, 21)
        Me.cmbDerivado.TabIndex = 1
        Me.cmbDerivado.ValueMember = "id"
        '
        'crtTablaTipoDerivada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "crtTablaTipoDerivada"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDerivado As System.Windows.Forms.Label
    Public WithEvents cmbDerivado As SiCo.ctrla.ListaDesplegable

End Class

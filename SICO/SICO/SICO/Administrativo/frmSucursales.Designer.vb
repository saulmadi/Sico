<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSucursales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSucursales))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbMunicipio = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbDepartamento = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbAdmon = New SICO.ctrla.ListaDesplegable(Me.components)
        Me.cmbestado = New SICO.ctrla2.ListaHabilitados(Me.components)
        Me.CajaTexto1 = New SICO.ctrla.CajaTexto(Me.components)
        Me.CrtPersonaJuridica1 = New SICO.ctrla2.crtPersonaJuridica
        Me.CrtListadoMantenimiento1 = New SICO.ctrla2.crtListadoMantenimiento
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CrtListadoMantenimiento1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 367)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CrtPersonaJuridica1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(288, 95)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(594, 209)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Generales"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbMunicipio)
        Me.GroupBox3.Controls.Add(Me.cmbDepartamento)
        Me.GroupBox3.Controls.Add(Me.cmbAdmon)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cmbestado)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.CajaTexto1)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(288, 307)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(495, 155)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Sucursal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Estado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Número de factura"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Municipio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Departamento"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Administrador"
        '
        'cmbMunicipio
        '
        Me.cmbMunicipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMunicipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMunicipio.CargarAutoCompletar = False
        Me.cmbMunicipio.CargarComboBox = True
        Me.cmbMunicipio.DisplayMember = "descripcion"
        Me.cmbMunicipio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMunicipio.FormattingEnabled = True
        Me.cmbMunicipio.Location = New System.Drawing.Point(106, 71)
        Me.cmbMunicipio.Name = "cmbMunicipio"
        Me.cmbMunicipio.ParametroAutocompletar = Nothing
        Me.cmbMunicipio.ParametroBusquedaPadre = Nothing
        Me.cmbMunicipio.Size = New System.Drawing.Size(378, 21)
        Me.cmbMunicipio.TabIndex = 2
        Me.cmbMunicipio.ValueMember = "id"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDepartamento.CargarAutoCompletar = False
        Me.cmbDepartamento.CargarComboBox = True
        Me.cmbDepartamento.DisplayMember = "descripcion"
        Me.cmbDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(106, 44)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.ParametroAutocompletar = Nothing
        Me.cmbDepartamento.ParametroBusquedaPadre = Nothing
        Me.cmbDepartamento.Size = New System.Drawing.Size(378, 21)
        Me.cmbDepartamento.TabIndex = 1
        Me.cmbDepartamento.ValueMember = "Id"
        '
        'cmbAdmon
        '
        Me.cmbAdmon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAdmon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAdmon.CargarAutoCompletar = False
        Me.cmbAdmon.CargarComboBox = True
        Me.cmbAdmon.DisplayMember = "NombreMantenimiento"
        Me.cmbAdmon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAdmon.FormattingEnabled = True
        Me.cmbAdmon.Location = New System.Drawing.Point(106, 17)
        Me.cmbAdmon.Name = "cmbAdmon"
        Me.cmbAdmon.ParametroAutocompletar = Nothing
        Me.cmbAdmon.ParametroBusquedaPadre = Nothing
        Me.cmbAdmon.Size = New System.Drawing.Size(378, 21)
        Me.cmbAdmon.TabIndex = 0
        Me.cmbAdmon.ValueMember = "id"
        '
        'cmbestado
        '
        Me.cmbestado.DisplayMember = "Descripcion"
        Me.cmbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbestado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbestado.FormattingEnabled = True
        Me.cmbestado.Location = New System.Drawing.Point(106, 126)
        Me.cmbestado.Name = "cmbestado"
        Me.cmbestado.SelectedItem = CType(resources.GetObject("cmbestado.SelectedItem"), SICO.lgla2.Estado)
        Me.cmbestado.Size = New System.Drawing.Size(378, 21)
        Me.cmbestado.TabIndex = 4
        Me.cmbestado.ValueMember = "valor"
        '
        'CajaTexto1
        '
        Me.CajaTexto1.ColorError = System.Drawing.Color.Red
        Me.CajaTexto1.EnterPorTab = True
        Me.CajaTexto1.EsObligatorio = False
        Me.CajaTexto1.ExpresionValidacion = Nothing
        Me.CajaTexto1.Location = New System.Drawing.Point(106, 100)
        Me.CajaTexto1.MaxLength = 255
        Me.CajaTexto1.MensajeError = Nothing
        Me.CajaTexto1.Name = "CajaTexto1"
        Me.CajaTexto1.Size = New System.Drawing.Size(378, 20)
        Me.CajaTexto1.TabIndex = 3
        Me.CajaTexto1.Texto = Nothing
        Me.CajaTexto1.TipoTexto = SICO.ctrla.TiposTexto.Alfanumerico
        Me.CajaTexto1.ValorInt = Nothing
        '
        'CrtPersonaJuridica1
        '
        Me.CrtPersonaJuridica1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtPersonaJuridica1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtPersonaJuridica1.HabilitarRTN = False
        Me.CrtPersonaJuridica1.Location = New System.Drawing.Point(3, 16)
        Me.CrtPersonaJuridica1.Name = "CrtPersonaJuridica1"
        Me.CrtPersonaJuridica1.RealizarBusquedaAutomarita = True
        Me.CrtPersonaJuridica1.Size = New System.Drawing.Size(588, 190)
        Me.CrtPersonaJuridica1.SoloLectura = False
        Me.CrtPersonaJuridica1.TabIndex = 0
        Me.CrtPersonaJuridica1.TextoRazonSocial = "Sucursal"
        '
        'CrtListadoMantenimiento1
        '
        Me.CrtListadoMantenimiento1.CampoAMostrar = "NombreMantenimiento"
        Me.CrtListadoMantenimiento1.CaracteresInicioBusqueda = 3
        Me.CrtListadoMantenimiento1.CaracteresSegundaBusqueda = 6
        Me.CrtListadoMantenimiento1.CargarInicio = False
        Me.CrtListadoMantenimiento1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrtListadoMantenimiento1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CrtListadoMantenimiento1.Location = New System.Drawing.Point(3, 16)
        Me.CrtListadoMantenimiento1.Name = "CrtListadoMantenimiento1"
        Me.CrtListadoMantenimiento1.NombreParametroBusqueda = "entidadnombre"
        Me.CrtListadoMantenimiento1.Size = New System.Drawing.Size(264, 348)
        Me.CrtListadoMantenimiento1.TabIndex = 0
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(895, 549)
        Me.PanelAccion1.TabIndex = 3
        Me.PanelAccion1.Titulo = "Sucursales"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'frmSucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 549)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelAccion1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSucursales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucursales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtListadoMantenimiento1 As SICO.ctrla2.crtListadoMantenimiento
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CrtPersonaJuridica1 As SICO.ctrla2.crtPersonaJuridica
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CajaTexto1 As SICO.ctrla.CajaTexto
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbestado As SICO.ctrla2.ListaHabilitados
    Friend WithEvents cmbAdmon As SICO.ctrla.ListaDesplegable
    Friend WithEvents cmbMunicipio As SiCo.ctrla.ListaDesplegable
    Friend WithEvents cmbDepartamento As SiCo.ctrla.ListaDesplegable
End Class

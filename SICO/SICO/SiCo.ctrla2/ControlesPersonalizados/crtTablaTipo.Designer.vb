﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class crtTablaTipo
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

    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(crtTablaTipo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.crtBusqueda = New SiCo.ctrla2.crtListadoMantenimiento
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbEstado = New SiCo.ctrla2.ListaHabilitados(Me.components)
        Me.txtDescripcion = New SiCo.ctrla.CajaTexto(Me.components)
        Me.PanelAccion = New SiCo.ctrla.PanelAccion
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.crtBusqueda)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(20, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 341)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Busqueda"
        '
        'crtBusqueda
        '
        Me.crtBusqueda.CampoAMostrar = ""
        Me.crtBusqueda.CaracteresInicioBusqueda = 3
        Me.crtBusqueda.CaracteresSegundaBusqueda = 6
        Me.crtBusqueda.CargarInicio = True
        Me.crtBusqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crtBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crtBusqueda.Location = New System.Drawing.Point(3, 16)
        Me.crtBusqueda.Name = "crtBusqueda"
        Me.crtBusqueda.NombreParametroBusqueda = Nothing
        Me.crtBusqueda.Size = New System.Drawing.Size(316, 322)
        Me.crtBusqueda.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Estado"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbEstado)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtDescripcion)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(366, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(396, 84)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos"
        '
        'cmbEstado
        '
        Me.cmbEstado.DisplayMember = "Descripcion"
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(75, 46)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.SelectedItem = CType(resources.GetObject("cmbEstado.SelectedItem"), SiCo.lgla2.Estado)
        Me.cmbEstado.Size = New System.Drawing.Size(298, 21)
        Me.cmbEstado.TabIndex = 4
        Me.cmbEstado.ValueMember = "Valor"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.ColorError = System.Drawing.Color.Red
        Me.txtDescripcion.EnterPorTab = True
        Me.txtDescripcion.EsObligatorio = True
        Me.txtDescripcion.ExpresionValidacion = ""
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(75, 20)
        Me.txtDescripcion.MaxLength = 45
        Me.txtDescripcion.MensajeError = "La descripción no puede ser vacía"
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(298, 20)
        Me.txtDescripcion.TabIndex = 0
        Me.txtDescripcion.Texto = Nothing
        Me.txtDescripcion.TipoTexto = SiCo.ctrla.TiposTexto.Alfabetico
        Me.txtDescripcion.ValorInt = Nothing
        '
        'PanelAccion
        '
        Me.PanelAccion.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion.EstadoMensaje = ""
        Me.PanelAccion.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion.Name = "PanelAccion"
        Me.PanelAccion.Size = New System.Drawing.Size(778, 510)
        Me.PanelAccion.TabIndex = 2
        Me.PanelAccion.Titulo = "Título"
        Me.PanelAccion.VisiblePanelPrincipal = True
        '
        'crtTablaTipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PanelAccion)
        Me.Name = "crtTablaTipo"
        Me.Size = New System.Drawing.Size(778, 510)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents PanelAccion As SiCo.ctrla.PanelAccion
    Public WithEvents crtBusqueda As SiCo.ctrla2.crtListadoMantenimiento
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtDescripcion As SiCo.ctrla.CajaTexto
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents cmbEstado As SiCo.ctrla2.ListaHabilitados

End Class

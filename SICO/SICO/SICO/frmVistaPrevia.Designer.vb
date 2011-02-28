<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaPrevia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaPrevia))
        Me.CrtPanelBase1 = New SICO.ctrla.ControlesPersonalizados.crtPanelBase
        Me.Reporteador = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me._CrReporte = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Me.SuspendLayout()
        '
        'CrtPanelBase1
        '
        Me.CrtPanelBase1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CrtPanelBase1.Location = New System.Drawing.Point(0, 0)
        Me.CrtPanelBase1.Name = "CrtPanelBase1"
        Me.CrtPanelBase1.Size = New System.Drawing.Size(830, 90)
        Me.CrtPanelBase1.TabIndex = 0
        Me.CrtPanelBase1.Titulo = "Vista Previa"
        Me.CrtPanelBase1.VisiblePanelPrincipal = True
        '
        'Reporteador
        '
        Me.Reporteador.ActiveViewIndex = -1
        Me.Reporteador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Reporteador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Reporteador.Location = New System.Drawing.Point(0, 90)
        Me.Reporteador.Name = "Reporteador"
        Me.Reporteador.SelectionFormula = ""
        Me.Reporteador.Size = New System.Drawing.Size(830, 353)
        Me.Reporteador.TabIndex = 1
        Me.Reporteador.ViewTimeSelectionFormula = ""
        '
        'frmVistaPrevia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 443)
        Me.Controls.Add(Me.Reporteador)
        Me.Controls.Add(Me.CrtPanelBase1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVistaPrevia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vista Previa"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrtPanelBase1 As SICO.ctrla.ControlesPersonalizados.crtPanelBase
    Friend WithEvents Reporteador As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents _CrReporte As CrystalDecisions.CrystalReports.Engine.ReportDocument
End Class

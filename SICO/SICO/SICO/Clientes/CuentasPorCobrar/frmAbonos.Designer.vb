﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbonos
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
        Me.PanelAccion1 = New SICO.ctrla.PanelAccion
        Me.SuspendLayout()
        '
        'PanelAccion1
        '
        Me.PanelAccion1.BackColor = System.Drawing.SystemColors.Control
        Me.PanelAccion1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAccion1.EstadoMensaje = ""
        Me.PanelAccion1.Location = New System.Drawing.Point(0, 0)
        Me.PanelAccion1.Name = "PanelAccion1"
        Me.PanelAccion1.Size = New System.Drawing.Size(663, 430)
        Me.PanelAccion1.TabIndex = 0
        Me.PanelAccion1.Titulo = "Abonos"
        Me.PanelAccion1.VisiblePanelPrincipal = True
        '
        'frmAbonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 430)
        Me.Controls.Add(Me.PanelAccion1)
        Me.Name = "frmAbonos"
        Me.Text = "Abonos a cuenta"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelAccion1 As SICO.ctrla.PanelAccion
End Class

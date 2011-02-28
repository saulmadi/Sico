Imports CrystalDecisions.CrystalReports.Engine
Public Class frmVistaPrevia
    
    Public Property Reporte() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Get
            Return _CrReporte
        End Get
        Set(ByVal value As CrystalDecisions.CrystalReports.Engine.ReportDocument)
            _CrReporte = value

        End Set
    End Property
    Public Overloads Function Show(ByVal Reporte As ReportDocument, Optional ByVal Titulo As String = "") As DialogResult
        Me._CrReporte = Reporte
        Try
            Dim s As New SICO.lgla.Sucursales
            s.Cargar()
            Me.Reporte.Subreports("crPie.rpt").DataDefinition.FormulaFields("PieReporte").Text = "'" + s.PieSucursal + "'"
            Me.Reporte.Subreports("crTitulo.rpt").DataDefinition.FormulaFields("Titulo").Text = "'" + Titulo.Trim + "'"
            Me.Reporteador.ReportSource = Me.Reporte
        Catch ex As Exception

        End Try

        MyBase.Show()
    End Function

    Private Sub frmVistaPrevia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Reporteador_DrillDownSubreport(ByVal source As System.Object, ByVal e As CrystalDecisions.Windows.Forms.DrillSubreportEventArgs) Handles Reporteador.DrillDownSubreport
        e.Handled = True
    End Sub
End Class
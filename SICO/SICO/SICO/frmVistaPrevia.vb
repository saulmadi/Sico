Imports CrystalDecisions.CrystalReports.Engine
Public Class frmVistaPrevia
    Private frmProgreso As New frmGeneracionReporte
    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        frmProgreso = New frmGeneracionReporte
        frmProgreso.TopMost = True

        frmProgreso.Show()
    End Sub

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
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Reporteador_DrillDownSubreport(ByVal source As System.Object, ByVal e As CrystalDecisions.Windows.Forms.DrillSubreportEventArgs) Handles Reporteador.DrillDownSubreport
        e.Handled = True
    End Sub

    Private Sub frmVistaPrevia_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        frmProgreso.Close()

    End Sub

    Private Sub Reporteador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reporteador.Load

    End Sub
End Class
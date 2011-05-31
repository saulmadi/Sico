Imports SICO.ctrla2
Imports SICO.lgla
Imports SICO.lgla2
Public Class frmVentaMotocicleta
#Region "Declaraciones"
    Private _factura As New FacturaEncabezado
#End Region

#Region "Propiedades"
    Public Property Factura() As FacturaEncabezado
        Get
            Return _factura
        End Get
        Set(ByVal value As FacturaEncabezado)
            _factura = value
            CargarEntidad()
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Sub CargarEntidad()

    End Sub
#End Region

#Region "Eventos"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New ctrla2.frmBusquedaMotocileta

        frm.Show()
    End Sub
#End Region
    
End Class
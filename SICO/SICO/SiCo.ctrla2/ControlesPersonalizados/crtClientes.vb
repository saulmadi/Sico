Imports SiCo.lgla
Imports SiCo.lgla2
Public Class crtClientes

#Region "Declaraciones"
    Private WithEvents _cliente As New Clientes
#End Region

#Region "Constructor"

#End Region

#Region "Propiedades"
    Public Property Cliente() As Clientes
        Get
            Return _cliente
        End Get
        Set(ByVal value As Clientes)
            _cliente = value
        End Set
    End Property
#End Region

#Region "Metodos"

#End Region

#Region "Eventos"
    Private Sub _cliente_CambioId() Handles _cliente.CambioId
        If Me.Cliente.TotalRegistros > 0 Then
            Me.Cliente = _cliente
        End If
    End Sub
#End Region


  
End Class

Imports SiCo.lgla

Public Class HistoricoCompras
    Inherits Entidad

#Region "Constructor"

    Public Sub New()
        MyBase.New()
        Me.ComandoSelect = "HistoricoCompras_buscar"
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("idproducto"))
        Me.ColeccionParametrosBusqueda.Add (New Parametro ("fechacompra"))

    End Sub

#End Region

#Region "Metodos"

#End Region
End Class

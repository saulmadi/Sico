Imports SICO.lgla2

Public Class frmRequesicionProducto
    Private _OrdenRequisicion As New OrdenRequiscion

    Public Property OrdenRequisicion() As OrdenRequiscion
        Get
            Return _OrdenRequisicion
        End Get
        Set(ByVal value As OrdenRequiscion)
            _OrdenRequisicion = value
            cargarentidad()
        End Set
    End Property

    Private Sub cargarentidad()

    End Sub




End Class
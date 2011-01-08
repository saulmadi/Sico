Imports SiCo.lgla2
Public Class ListaHabilitados

#Region "Declaraciones"
    Private _ListaHabilitados As New List(Of Estado)
#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        Me.DropDownStyle = ComboBoxStyle.DropDownList

        _ListaHabilitados.Add(New Estado("In Habilitado", 0))
        _ListaHabilitados.Add(New Estado("Habilitado", 1))
        Try
            Me.DataSource = _ListaHabilitados
            Me.DisplayMember = "Descripcion"
            Me.ValueMember = "Valor"
        Catch ex As Exception

        End Try

    End Sub
#End Region

End Class

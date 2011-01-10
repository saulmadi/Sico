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

       
        Try
            MyBase.Items.Add(New Estado("Inhabilitado", 0))
            MyBase.Items.Add(New Estado("Habilitado", 1))

            MyBase.DisplayMember = "Descripcion"
            MyBase.ValueMember = "Valor"
            MyBase.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub
    Public Shadows Property Items()
        Get
            Return MyBase.Items
        End Get
        Set(ByVal value)

        End Set
    End Property
#End Region

End Class

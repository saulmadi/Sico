Imports System.ComponentModel
Imports System.Diagnostics
<Serializable()> _
Public Class ListaTipoIdentidad

#Region "Declaraciones"

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        Me.DropDownStyle = ComboBoxStyle.DropDownList


        Try
            Dim list As New List(Of ListaTipoIdentidad)
            list.Add(New ListaTipoIdentidad("I"))
            list.Add(New ListaTipoIdentidad("R"))
            list.Add(New ListaTipoIdentidad("N"))

            MyBase.DataSource = list
            MyBase.DisplayMember = "Descripcion"
            MyBase.ValueMember = "Valor"
            MyBase.SelectedValue = "I"
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "ClaseListaTipoIdentidad"
    <Serializable()> _
    Public Class ListaTipoIdentidad
        Inherits SiCo.lgla.TipoIdentidad
        Public Sub New(ByVal valor As String)
            MyBase.New(valor)
        End Sub

    End Class
#End Region

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shadows Property Datasource() As Object
        Get
            Return MyBase.DataSource
        End Get
        Set(ByVal value)
            MyBase.DataSource = value
        End Set
    End Property
End Class


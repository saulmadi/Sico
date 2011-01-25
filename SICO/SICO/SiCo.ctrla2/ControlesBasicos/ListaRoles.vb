﻿Imports SiCo.lgla
Imports System.ComponentModel
Imports System.Diagnostics
Public Class ListaRoles
#Region "Declaraciones"

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        Me.DropDownStyle = ComboBoxStyle.DropDownList


        Try


            MyBase.Items.Add(New ListaTipo(1, "Cajero"))
            MyBase.Items.Add(New ListaTipo(2, "Vendedor Repuestos"))
            MyBase.Items.Add(New ListaTipo(3, "Vendedor Motocicletas"))
            MyBase.Items.Add(New ListaTipo(4, "Administrador Sucursal"))
            MyBase.Items.Add(New ListaTipo(5, "Administrador General"))


            MyBase.DisplayMember = "Descripcion"
            MyBase.ValueMember = "Valor"
            MyBase.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Shadows ReadOnly Property Items()
        Get
            Return MyBase.Items
        End Get
    End Property
#End Region

#Region "ClaseListaTipo"
    Private Class ListaTipo
        Inherits SiCo.lgla.Tipo
        Public Sub New(ByVal valor As String, ByVal descripcion As String)
            MyBase.New(descripcion, valor)
        End Sub

    End Class
#End Region

End Class

'------------------------------------------------------------------------------
' This is auto-generated code.
'------------------------------------------------------------------------------
' This code was generated by Entity Developer tool using NHibernate template.
' Code is generated on: 15/09/2011 08:15:59 p.m.
'
' Changes to this file may cause incorrect behavior and will be lost if
' the code is regenerated.
'------------------------------------------------------------------------------

Imports System
Imports System.Collections
Imports System.Linq
Imports System.Text

Imports System.ComponentModel


Imports SiCo.lgla
''' <summary>
''' There are no comments for Movimientoscuentacorriente in the schema.
''' </summary>
Partial Public Class Movimientoscuentacorriente
    Inherits Entidad

    Private _idtipomovimiento As Integer

    Private _monto As Decimal

    Private _descripcion As String

    Private _fechavencimiento As System.Nullable(Of System.DateTime)

    Private _fecha As System.DateTime

    Private _idrubro As Integer

#Region "Extensibility Method Definitions"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Public Sub New()
        OnCreated()
    End Sub



    ''' <summary>
    ''' There are no comments for idtipomovimiento in the schema.
    ''' </summary>
    Public Overridable Property idtipomovimiento() As Integer
        Get
            Return Me._idtipomovimiento
        End Get
        Set(ByVal value As Integer)

            Me._idtipomovimiento = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for monto in the schema.
    ''' </summary>
    Public Overridable Property monto() As Decimal
        Get
            Return Me._monto
        End Get
        Set(ByVal value As Decimal)

            Me._monto = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for descripcion in the schema.
    ''' </summary>
    Public Overridable Property descripcion() As String
        Get
            Return Me._descripcion
        End Get
        Set(ByVal value As String)

            Me._descripcion = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for fechavencimiento in the schema.
    ''' </summary>
    Public Overridable Property fechavencimiento() As System.Nullable(Of System.DateTime)
        Get
            Return Me._fechavencimiento
        End Get
        Set(ByVal value As System.Nullable(Of System.DateTime))

            Me._fechavencimiento = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for fecha in the schema.
    ''' </summary>
    Public Overridable Property fecha() As System.DateTime
        Get
            Return Me._fecha
        End Get
        Set(ByVal value As System.DateTime)

            Me._fecha = value
        End Set
    End Property

    ''' <summary>
    ''' There are no comments for idrubro in the schema.
    ''' </summary>
    Public Overridable Property idrubro() As Integer
        Get
            Return Me._idrubro
        End Get
        Set(ByVal value As Integer)

            Me._idrubro = value
        End Set
    End Property
End Class


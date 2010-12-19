Imports MySql.Data.MySqlClient
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
<Serializable()> Public Class ConexionMySQL

#Region "Declaraciones"

    <NonSerialized()> Private _MysqlConexion As New MySqlConnection()
    Private _Servidor As String
    Private _Puerto As Integer
    Private _Contrasena As String
    Private _Usuario As String
    Private _BaseDatos As String
    Public Event Errores(ByVal Mensaje As String)
#End Region

#Region "Constructores"
    Public Sub New()

    End Sub
#End Region

#Region "Propiedades"
    ''' <summary>
    ''' Servidor de la conexión de la base de datos
    ''' </summary>
    Public Property Servidor() As String
        Get
            Return _Servidor
        End Get
        Set(ByVal value As String)
            _Servidor = value

        End Set

    End Property

    ''' <summary>
    ''' Puerto en el que esta levantado el servidor de base de datos del servidor
    ''' </summary>
    Public Property Puerto() As Integer
        Get
            Return _Puerto
        End Get
        Set(ByVal value As Integer)
            _Puerto = value
        End Set
    End Property

    ''' <summary>
    ''' Usuario para loguearse a la base de datos
    ''' </summary>
    Public Property Usuario() As String
        Get
            Return _Usuario

        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property

    ''' <summary>
    ''' Contraseña de Seguridad para la conexión a la base de datos
    ''' </summary>
    Public Property Contrasena() As String
        Get
            Return _Contrasena
        End Get
        Set(ByVal value As String)
            _Contrasena = value
        End Set
    End Property

    ''' <summary>
    ''' Cadena utilizada para conectar a la base de datos
    ''' </summary>
    Public ReadOnly Property CadenaConexion() As String
        Get
            Return "Server=" + Servidor + ";Port=" + Puerto.ToString() + "; database=" + BaseDatos + ";Uid=" + Usuario + ";Pwd=" + Contrasena + ";"
        End Get
    End Property

    ''' <summary>
    ''' Objeto de conexión a la base de datos
    ''' </summary>
    Public ReadOnly Property Conexion() As MySqlConnection
        Get

            Return _MysqlConexion
        End Get
    End Property

    ''' <summary>
    ''' Nombre de la base de datos del servidor
    ''' </summary>
    Public Property BaseDatos() As String
        Get
            Return _BaseDatos
        End Get
        Set(ByVal value As String)
            _BaseDatos = value
        End Set
    End Property

    ''' <summary>
    ''' Dirección del Archivo de conexion
    ''' </summary>
    Public ReadOnly Property Archivo() As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory + "Cnx.sco"

        End Get

    End Property

#End Region

#Region "Metodos"

    ''' <summary>
    ''' Abre la conexion para la utilización de la base de datos
    ''' </summary>
    ''' 
    Public Function AbrirConexion()
        Dim Flag As Boolean = False
        Try

            If Conexion.State = ConnectionState.Closed Then
                Conexion.ConnectionString = CadenaConexion
                Conexion.Open()
            End If
            If Conexion.State = ConnectionState.Open Then
                Flag = True
            End If
        Catch ex As Exception
            RaiseEvent Errores(ex.Message)
        End Try
        Return Flag
    End Function

    ''' <summary>
    ''' Cierra la conexión al base de datos
    ''' </summary>
    Public Function CerrarConxion() As Boolean
        Try
            Dim Flag As Boolean = False
            Try

                If Conexion.State = ConnectionState.Open Then
                    Conexion.Close()
                End If
                If Conexion.State = ConnectionState.Closed Then
                    Flag = True
                End If
            Catch ex As Exception
                RaiseEvent Errores(ex.Message)
            End Try
            Return Flag

        Catch ex As Exception
            RaiseEvent Errores(ex.Message)
        End Try
    End Function

#End Region

    
End Class
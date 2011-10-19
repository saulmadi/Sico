Imports System.IO
Imports SiCo.ctrla
Imports SiCo.lgla

Public Class frmConfiguracionBDD
    Dim config As New Configuracion

    Private Sub Button1_Click (ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click

        Dim va As New Validador
        va.ColecionCajasTexto.Add (txtservidor)
        va.ColecionCajasTexto.Add (txtusuario)
        va.ColecionCajasTexto.Add (txtcontrasena)
        va.ColecionCajasTexto.Add (txtbasedatos)

        If va.PermitirIngresar Then
            Me.Cursor = Cursors.WaitCursor
            config.Config.Servidor = txtservidor.Text
            config.Config.Puerto = cmbpuerto.SelectedItem
            config.Config.Usuario = txtusuario.Text
            config.Config.Contrasena = txtcontrasena.Text
            config.Config.BaseDatos = txtbasedatos.Text
            Try
                If config.Config.ProbarConexion() Then
                    MessageBox.Show ("La conexión fue exitosa", "Atención", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)
                    config.Config.Guardar()
                    Me.ListaSucursales1.Enabled = True
                    Me.ListaSucursales1.Inicialiazar()
                Else
                    Me.ListaSucursales1.Enabled = False
                End If
            Catch ex As Exception
                Me.ListaSucursales1.Enabled = False
                MessageBox.Show ("Error en la conexión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If


    End Sub

    Private Sub Button3_Click (ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click (ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim va As New Validador
        va.ColecionCajasTexto.Add (txtservidor)
        va.ColecionCajasTexto.Add (txtusuario)
        va.ColecionCajasTexto.Add (txtcontrasena)
        va.ColecionCajasTexto.Add (txtbasedatos)

        If va.PermitirIngresar Then
            Me.Cursor = Cursors.WaitCursor
            config.Config.Servidor = txtservidor.Text
            config.Config.Puerto = cmbpuerto.SelectedItem
            config.Config.Usuario = txtusuario.Text
            config.Config.Contrasena = txtcontrasena.Text
            config.Config.BaseDatos = txtbasedatos.Text
            Try
                If config.Config.ProbarConexion() Then
                    config.Config.Guardar()

                    If Not Me.ListaSucursales1.SelectedItem Is Nothing Then

                        Me.ListaSucursales1.SelectedItem.Serializar()
                        Me.CrtPanelBase1.sucursal = New Sucursales
                        Me.CrtPanelBase1.sucursal.Cargar()
                    End If
                    MessageBox.Show ("Se guardado correctamente la configuración", "Atención", MessageBoxButtons.OK, _
                                     MessageBoxIcon.Exclamation)

                    Me.Close()
                End If
            Catch ex As Exception

                MessageBox.Show ("Error en la conexión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Finally
                Me.Cursor = Cursors.Default
            End Try


        End If
    End Sub

    Private Sub frmConfiguracionBDD_Load (ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        cmbpuerto.SelectedIndex = 0
        File.Delete ("Cnx.sco")
        File.Delete ("Usx.sco")
    End Sub
End Class
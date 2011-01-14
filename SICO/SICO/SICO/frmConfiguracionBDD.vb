﻿Imports SICO.lgla
Imports SICO.ctrla
Public Class frmConfiguracionBDD
    Dim config As New SICO.lgla.Configuracion

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim va As New Validador
        va.ColecionCajasTexto.Add(txtservidor)
        va.ColecionCajasTexto.Add(txtcontrasena)
        va.ColecionCajasTexto.Add(txtusuario)
        va.ColecionCajasTexto.Add(txtbasedatos)
       
        If va.PermitirIngresar Then
            config.Config.Servidor = txtservidor.Text
            config.Config.Puerto = cmbpuerto.SelectedItem
            config.Config.Usuario = txtusuario.Text
            config.Config.Contrasena = txtcontrasena.Text
            config.Config.BaseDatos = txtbasedatos.Text
            Try
                If config.Config.ProbarConexion() Then
                    MessageBox.Show("La conexión fue exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                
                End If
            Catch ex As Exception

                MessageBox.Show("Error en la conexión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
           


        End If



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim va As New Validador
        va.ColecionCajasTexto.Add(txtservidor)
        va.ColecionCajasTexto.Add(txtcontrasena)
        va.ColecionCajasTexto.Add(txtusuario)
        va.ColecionCajasTexto.Add(txtbasedatos)

        If va.PermitirIngresar Then
            config.Config.Servidor = txtservidor.Text
            config.Config.Puerto = cmbpuerto.SelectedItem
            config.Config.Usuario = txtusuario.Text
            config.Config.Contrasena = txtcontrasena.Text
            config.Config.BaseDatos = txtbasedatos.Text
            Try
                If config.Config.ProbarConexion() Then
                    config.Config.Guardar()
                    MessageBox.Show("Se guardado correctamente la configuración", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Close()
                End If
            Catch ex As Exception

                MessageBox.Show("Error en la conexión", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try



        End If
    End Sub

    Private Sub frmConfiguracionBDD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbpuerto.SelectedIndex = 0
    End Sub
End Class
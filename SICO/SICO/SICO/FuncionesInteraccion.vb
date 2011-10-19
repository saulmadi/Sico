
Module FuncionesInteraccion
    Public Sub BloquearDesbloquarControles (ByVal ctrl As Control, ByVal habilitar As Boolean, ByVal tipo As Type)

        For Each i As Control In ctrl.Controls
            Try

                If i.GetType.BaseType Is tipo Or i.GetType Is tipo Then
                    i.Enabled = habilitar
                Else
                    BloquearDesbloquarControles (i, habilitar, tipo)
                End If
            Catch ex As Exception

            End Try
        Next

    End Sub
End Module

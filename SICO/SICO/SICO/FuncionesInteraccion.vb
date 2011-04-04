Module FuncionesInteraccion
    Public Sub BloquearDesbloquarControles(ByVal ctrl As Control, ByVal habilitar As Boolean, ByVal tipo As Type)

        For Each i As Control In ctrl.Controls
            If i.GetType Is tipo Then
                i.Enabled = habilitar
            Else
                BloquearDesbloquarControles(i, habilitar, tipo)
            End If
        Next

    End Sub
End Module

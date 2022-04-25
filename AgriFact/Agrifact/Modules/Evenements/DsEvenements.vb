Partial Class DsEvenements
    Partial Class EvenementPersonneDisplayDataTable

        Public Sub InitAutoIncrementSeed()
            Using dta As New DsEvenementsTableAdapters.EvenementPersonneDisplayTA
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsEvenementsTableAdapters.EvenementPersonneDisplayTA)
            Me.nEvenementPersonneColumn.AutoIncrementSeed = CLng(dta.GetMaxId.GetValueOrDefault(0)) + 1
        End Sub
    End Class

End Class
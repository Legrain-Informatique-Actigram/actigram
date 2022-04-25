Partial Class DsAgrifact


    Partial Class EvenementDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.EvenementTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.EvenementTableAdapter)
            Me.nEvenementColumn.AutoIncrementSeed = GetNewId(dta)
        End Sub

        Public Function GetNewId(ByVal dta As DsAgrifactTableAdapters.EvenementTableAdapter) As Integer
            Return SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nEvenementColumn.ColumnName) + 1
        End Function
    End Class

End Class

Namespace DsAgrifactTableAdapters
    Partial Class ListeChoixTableAdapter
        Public Enum NomsChoix
            FormeJuridique
            ListeBanque
            ListeDepots
            ListeModeReglement
            ListeTypeFacturation
            ListeTypeMouvement
            ListeUnite
            ListeTypeEv
            ListeProduits
        End Enum

        Public Overloads Sub FillByNomChoix(ByVal dt As DsAgrifact.ListeChoixDataTable, ByVal nomChoix As NomsChoix)
            FillByNomChoix(dt, nomChoix.ToString)
        End Sub

        Public Overloads Function GetDataByNomChoix(ByVal nomChoix As NomsChoix) As DsAgrifact.ListeChoixDataTable
            Return GetDataByNomChoix(nomChoix.ToString)
        End Function
    End Class
End Namespace

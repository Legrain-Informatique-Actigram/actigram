Partial Class EtatsDataset
    Partial Class EtiqCodeBarreMouvDataTable

        Private Sub EtiqCodeBarreMouvDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DateMouvementColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class EtiqCodeBarreRow

        Public Sub ConstruireCodeBarre(ByVal type As CodeBarre.TypeCodeBarre, ByVal drProduit As AgrifactTracaDataSet.ProduitRow, ByVal drBR As AgrifactTracaDataSet.ABonReceptionRow)
            Dim cb As CodeBarre = ControleTracabilite.CodeBarre.ConstruireCodeBarre(type, drProduit, drBR)
            If cb Is Nothing Then
                Me.SetCodeBarreNull()
            Else
                Me.CodeBarre = cb.EAN.ToString
            End If
        End Sub

        Public Sub FormaterCodeBarre()
            If Me.IsCodeBarreNull OrElse Me.CodeBarre.Length = 0 OrElse Me.CodeBarre.Length > 12 Then
                Me.SetFormattedCodeBarreNull()
            Else
                Me.FormattedCodeBarre = FormatterCodeBarre(Me.CodeBarre)
            End If
        End Sub

    End Class


    Partial Class EtiqCodeBarreMouvRow

        Public Sub ConstruireCodeBarre(ByVal type As CodeBarre.TypeCodeBarre, ByVal drProduit As AgrifactTracaDataSet.ProduitRow, ByVal drMvt As AgrifactTracaDataSet.MouvementRow)
            Dim cb As CodeBarre = ControleTracabilite.CodeBarre.ConstruireCodeBarre(type, drProduit, drMvt)
            If cb Is Nothing Then
                Me.SetCodeBarreNull()
            Else
                Me.CodeBarre = cb.EAN.ToString
            End If
        End Sub

        Public Sub FormaterCodeBarre()
            If Me.IsCodeBarreNull OrElse Me.CodeBarre.Length = 0 OrElse Me.CodeBarre.Length > 12 Then
                Me.SetFormattedCodeBarreNull()
            Else
                Me.FormattedCodeBarre = FormatterCodeBarre(Me.CodeBarre)
            End If
        End Sub

    End Class

End Class

Namespace Controles
    Public Class GestionGrilleControle

#Region "Méthodes partagées"
        Public Shared Sub ClicBouton(ByVal owner As Form, ByVal sender As DataGridView, ByVal rowIndex As Integer, ByVal colIndex As Integer)
            Dim cell As DataGridViewDisableButtonCell = Cast(Of DataGridViewDisableButtonCell)(sender.Rows(rowIndex).Cells(colIndex))
            If Not cell.ButtonVisible Then Exit Sub
            Dim drv As DataRowView = Cast(Of DataRowView)(cell.OwningRow.DataBoundItem)
            If drv Is Nothing Then Exit Sub
            If IsDBNull(drv("CodeProduit")) OrElse Convert.ToString(drv("NLot")).Length = 0 Then Exit Sub
            Dim codeProduit As String = Convert.ToString(drv("CodeProduit"))
            Dim nLot As String = Convert.ToString(drv("NLot"))
            Cursor.Current = Cursors.WaitCursor
            Dim listcontroles As List(Of Controles.DefinitionControle) = ControleTracabilite.Controles.DefinitionControle.Charger(codeProduit)
            Dim resultats As List(Of Controles.ResultatControle) = Controles.ResultatControle.Charger(codeProduit, nLot, False)
            If resultats.Count = 0 Then
                'Récupérer les controles liés au code produit                
                If listcontroles.Count = 0 Then
                    If cell.ButtonVisible Then
                        MsgBox("Aucun contrôle n'est configuré pour ce produit", MsgBoxStyle.Information)
                        cell.ButtonVisible = False
                    End If
                Else
                    '=> lancer le contrôle et enregistrer les résultats pour ce lot
                    Using fr As New FrApercuControles(listcontroles, codeProduit, nLot)
                        If fr.ShowDialog(owner) = Windows.Forms.DialogResult.OK Then
                            'Changer l'icone du bouton
                            cell.Image = My.Resources.OK
                        End If
                    End Using
                End If
            Else
                'Faire le mix entre les controles et les resultats
                For Each res As ResultatControle In resultats
                    For Each ctl As DefinitionControle In listcontroles
                        If ctl.nControle = res.nControle Then
                            res.DefinitionControle = ctl
                            Exit For
                        End If
                    Next
                Next
                'Si les contrôles ont déjà été effectués, afficher les résultats
                Using fr As New FrApercuControles(listcontroles, resultats, codeProduit, nLot)
                    If fr.ShowDialog(owner) = DialogResult.OK Then
                        'Changer l'icone du bouton
                        cell.Image = My.Resources.OK
                    End If
                End Using
            End If
            Cursor.Current = Cursors.Default
        End Sub

        Public Shared Sub RafraichirIcones(ByVal sender As DataGridView, ByVal colIndex As Integer, ByVal listChangedType As System.ComponentModel.ListChangedType, Optional ByVal [readonly] As Boolean = False)
            Using dtaRes As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                Using dtaCont As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
                    If listChangedType = System.ComponentModel.ListChangedType.Reset Then
                        For Each r As DataGridViewRow In sender.Rows
                            DeterminerIcone(Cast(Of DataGridViewDisableButtonCell)(r.Cells(colIndex)), dtaRes, dtaCont, [readonly])
                        Next
                    ElseIf listChangedType = System.ComponentModel.ListChangedType.ItemChanged Then
                        If sender.CurrentRow IsNot Nothing Then
                            DeterminerIcone(Cast(Of DataGridViewDisableButtonCell)(sender.CurrentRow.Cells(colIndex)), dtaRes, dtaCont, [readonly])
                        End If
                    End If
                End Using
            End Using
        End Sub

        Private Shared Sub DeterminerIcone(ByVal cell As DataGridViewDisableButtonCell, ByVal dtaRes As AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter, ByVal dtaCont As AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter, Optional ByVal [readonly] As Boolean = False)
            If cell.OwningRow.DataBoundItem Is Nothing Then Exit Sub
            Dim drv As DataRowView = Cast(Of DataRowView)(cell.OwningRow.DataBoundItem)
            If IsDBNull(drv("CodeProduit")) OrElse Convert.ToString(drv("NLot")).Length = 0 Then
                cell.ButtonVisible = False
            ElseIf dtaRes.CountResultats(Convert.ToString(drv("CodeProduit")), Convert.ToString(drv("NLot"))).GetValueOrDefault > 0 Then
                cell.ButtonVisible = True
                cell.Image = My.Resources.OK
            ElseIf Not [readonly] AndAlso dtaCont.CountControles(Convert.ToString(drv("CodeProduit"))).GetValueOrDefault > 0 Then
                cell.ButtonVisible = True
                cell.Image = My.Resources.controles
            Else
                cell.ButtonVisible = False
            End If
        End Sub
#End Region

    End Class
End Namespace

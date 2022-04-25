Partial Class DsPieces
    Partial Class Pieces_DetailDataTable

    End Class

End Class

Namespace DsPiecesTableAdapters
    Partial Class PiecesTA
        Public Sub Fill(ByVal dt As DsPieces.PiecesDataTable, ByVal type As Pieces.TypePieces)
            Select Case type
                Case Pieces.TypePieces.ABonReception : Me.FillABonReception(dt)
                Case Pieces.TypePieces.AFacture : Me.FillAFacture(dt)
                Case Pieces.TypePieces.VDevis : Me.FillVDevis(dt)
                Case Pieces.TypePieces.VBonCommande : Me.FillVBonCommande(dt)
                Case Pieces.TypePieces.VBonLivraison : Me.FillVBonLivraison(dt)
                Case Pieces.TypePieces.VFacture : Me.FillVFacture(dt)
            End Select
        End Sub

        Public Sub FillByClient(ByVal dt As DsPieces.PiecesDataTable, ByVal type As Pieces.TypePieces, ByVal nClient As Integer)
            Select Case type
                Case Pieces.TypePieces.ABonReception : Me.FillABonReceptionByClient(dt, nClient)
                Case Pieces.TypePieces.AFacture : Me.FillAFactureByClient(dt, nClient)
                Case Pieces.TypePieces.VDevis : Me.FillVDevisByClient(dt, nClient)
                Case Pieces.TypePieces.VBonCommande : Me.FillVBonCommandeByClient(dt, nClient)
                Case Pieces.TypePieces.VBonLivraison : Me.FillVBonLivraisonByClient(dt, nClient)
                Case Pieces.TypePieces.VFacture : Me.FillVFactureByClient(dt, nClient)
            End Select
        End Sub

        Public Sub Delete(ByVal dt As DsPieces.PiecesDataTable, ByVal type As Pieces.TypePieces)
            Dim drDeleted() As DataRow = dt.Select("", "", DataViewRowState.Deleted)
            If drDeleted.Length = 0 Then Exit Sub
            For Each dr As DataRow In drDeleted
                Dim nDevis As Integer = CInt(dr.Item("nDevis", DataRowVersion.Original))
                If nDevis <= 0 Then Continue For
                Select Case type
                    Case Pieces.TypePieces.ABonReception : Me.DeleteABonReception(nDevis)
                    Case Pieces.TypePieces.AFacture : Me.DeleteAFacture(nDevis)
                    Case Pieces.TypePieces.VBonCommande : Me.DeleteVBonCommande(nDevis)
                    Case Pieces.TypePieces.VBonLivraison : Me.DeleteVBonLivraison(nDevis)
                    Case Pieces.TypePieces.VFacture
                        Dim nFact As Decimal = -1

                        If Not IsDBNull(dr.Item("nFacture", DataRowVersion.Original)) Then
                            nFact = CDec(dr.Item("nFacture", DataRowVersion.Original))
                        End If

                        Me.DeleteVFacture(nDevis)

                        'On décrémente la table NFacture si le nFacture de la facture = NFacture de la table NFacture 
                        Using NFactureTA As New DsAgrifactTableAdapters.NFactureTableAdapter
                            'Recherche du dernier numéro de facture
                            Dim NFactureDT As DsAgrifact.NFactureDataTable = NFactureTA.GetDataByTypePiece("VFActure")

                            If (NFactureDT.Rows.Count > 0) Then
                                Dim NFactureDR As DsAgrifact.NFactureRow = CType(NFactureDT.Rows(0), DsAgrifact.NFactureRow)

                                If (nFact > -1) Then
                                    If (nFact = NFactureDR.NFacture) Then
                                        NFactureTA.UpdateNFactureByTypePiece(NFactureDR.NFacture - 1, "VFacture")
                                    End If
                                End If
                            End If
                        End Using
                    Case Pieces.TypePieces.VDevis : Me.DeleteVDevis(nDevis)
                End Select
                dr.AcceptChanges()
            Next
        End Sub
    End Class
End Namespace
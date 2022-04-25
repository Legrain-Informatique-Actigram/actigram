Module DebugMethods

#Region "Pièces déséquilibrées"
    Public Sub VerifResultat()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim report As New System.Text.StringBuilder
            Dim codeDossier As String = My.User.Name
            Dim sql As String = "SELECT Sum(Mouvements.MMtDeb)-Sum(Mouvements.MMtCre) AS Solde, IIf(MCpt='48800000','Répartition',IIf(Left([MCpt],1)<'6','Bilan','Gestion')) AS TypeCompte " & _
                                "FROM Mouvements " & _
                                "WHERE (((Mouvements.MDossier)='{0}')) " & _
                                "GROUP BY IIf(MCpt='48800000','Répartition',IIf(Left([MCpt],1)<'6','Bilan','Gestion'));"
            Using conn As OleDb.OleDbConnection = UtilBase.ConnecterBase(My.Settings.CheminBase)
                Dim dtResultat As DataTable = ExecuteDataTable(String.Format(sql, codeDossier), conn)
                For Each drvRes As DataRowView In dtResultat.DefaultView
                    report.AppendFormat("Solde déb {0}:" & vbTab & "{1:C2}" & vbCrLf, drvRes("TypeCompte"), drvRes("Solde"))
                Next
            End Using
            If report.Length > 0 Then
                MsgBox(report.ToString.Trim, MsgBoxStyle.Information)
            Else
                MsgBox("Aucune écriture trouvée", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Pièces déséquilibrées"
    Public Sub VerifPiecesDesequilibrees()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim report As New System.Text.StringBuilder
            Dim codeDossier As String = My.User.Name
            Dim sql As String = "SELECT Mouvements.MPiece, Mouvements.MDate, Sum([MMtDeb])-Sum([MMtCre]) AS SoldeDeb " & _
                                "FROM Mouvements " & _
                                "WHERE (((Mouvements.MDossier)='{0}') AND ((Mouvements.MCpt)='48800000')) " & _
                                "GROUP BY Mouvements.MPiece, Mouvements.MDate " & _
                                "HAVING (((Sum([MMtDeb])-Sum([MMtCre]))<>0));"
            Using conn As OleDb.OleDbConnection = UtilBase.ConnecterBase(My.Settings.CheminBase)
                Dim dtPieces As DataTable = ExecuteDataTable(String.Format(sql, codeDossier), conn)
                dtPieces.DefaultView.Sort = "MPiece,MDate"
                For Each drvPiece As DataRowView In dtPieces.DefaultView
                    report.AppendFormat("Pièce n°{0:000} du {1:dd/MM/yy}. Solde déb: {2:C2}" & vbCrLf, drvPiece("MPiece"), drvPiece("MDate"), drvPiece("SoldeDeb"))
                Next
            End Using
            If report.Length > 0 Then
                LongMessageBox.ShowMessage("Les pièces déséquilibrées suivantes ont été trouvées : ", report.ToString, , MsgBoxStyle.Exclamation)
            Else
                MsgBox("Aucune pièce déséquilibrée", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Vérif TVA"
    Public Sub VerifierCoherenceTVA()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim report As New System.Text.StringBuilder
            Dim codeDossier As String = My.User.Name
            'Faire un bilan par pièce des lignes soumises à TVA
            Dim sqlSoumis As String = "SELECT MDossier, MPiece, MDate, LTva, Sum(MMtDeb)- Sum(MMtCre) AS MtSoumisTVADeb " & _
                                "FROM Lignes INNER JOIN Mouvements ON Lignes.LLig = Mouvements.MLig AND Lignes.LDate = Mouvements.MDate AND Lignes.LPiece = Mouvements.MPiece AND Lignes.LDossier = Mouvements.MDossier " & _
                                "WHERE MCpt<>'48800000' AND LTva<>'' AND MDossier='{0}' " & _
                                "GROUP BY MDossier, MPiece, MDate, LTva "
            Dim sqlTVA As String = "SELECT MDossier, MPiece, MDate, LMtTVA, (Sum(MMtCre)-Sum(MMtDeb)) AS MontantTVADeb, " & _
                                "(IIf(Sum(MMtCre)-Sum(MMtDeb)>=0, Sum(MMtDeb),0) - IIf(Sum(MMtCre)-Sum(MMtDeb)>=0, 0,Sum(MMtCre))) AS BaseHTDeb " & _
                                "FROM Lignes INNER JOIN Mouvements ON (Lignes.LLig = Mouvements.MLig) AND (Lignes.LDate = Mouvements.MDate) AND (Lignes.LPiece = Mouvements.MPiece) AND (Lignes.LDossier = Mouvements.MDossier) " & _
                                "WHERE MCpt='48800000' AND LMtTVA<>'' AND MDossier='{0}' " & _
                                "GROUP BY MDossier, MPiece, MDate, LMtTVA"
            Using conn As OleDb.OleDbConnection = UtilBase.ConnecterBase(My.Settings.CheminBase)
                Dim dtSoumis As DataTable = ExecuteDataTable(String.Format(sqlSoumis, codeDossier), conn)
                dtSoumis.PrimaryKey = New DataColumn() {dtSoumis.Columns("MDossier"), dtSoumis.Columns("MPiece"), dtSoumis.Columns("MDate"), dtSoumis.Columns("LTva")}
                dtSoumis.DefaultView.Sort = "MDossier,MPiece,MDate,LTva"
                Dim dtTVA As DataTable = ExecuteDataTable(String.Format(sqlTVA, codeDossier), conn)
                dtTVA.PrimaryKey = New DataColumn() {dtTVA.Columns("MDossier"), dtTVA.Columns("MPiece"), dtTVA.Columns("MDate"), dtTVA.Columns("LMtTVA")}
                dtTVA.DefaultView.Sort = "MDossier,MPiece,MDate,LMtTVA"
                For Each drvSoumis As DataRowView In dtSoumis.DefaultView
                    Dim drvsTVA() As DataRowView = dtTVA.DefaultView.FindRows(New Object() {drvSoumis("MDossier"), drvSoumis("MPiece"), drvSoumis("MDate"), drvSoumis("LTva")})
                    If drvsTVA.Length = 0 Then
                        'Pas normal, si il y a soumission à TVA, il faut qu'il y ait TVA
                        AddErrorTVA(report, drvSoumis, "Il n'y a pas de ligne de TVA correspondante")
                    Else
                        Dim baseHT As Decimal = 0
                        Dim montantTVA As Decimal = 0
                        Dim tauxTVA As Decimal = GetTauxTVA(Convert.ToString(drvSoumis("LTva")))
                        For Each drv As DataRowView In drvsTVA
                            baseHT += CDec(drv("BaseHTDeb"))
                            montantTVA += CDec(drv("MontantTVADeb"))
                        Next
                        If montantTVA = 0 AndAlso Math.Abs(baseHT) = Math.Abs(CDec(drvSoumis("MtSoumisTVADeb"))) Then
                            'Normal, la requête ne sait pas dire si la TVA était au Débit ou au Crédit
                        ElseIf baseHT <> CDec(drvSoumis("MtSoumisTVADeb")) Then
                            'Pas normal, il doit y avoir égalité
                            AddErrorTVA(report, drvSoumis, String.Format("La base HT de {0:C2} ne correspond pas au montant soumis à TVA", baseHT))
                        ElseIf tauxTVA <> 0 AndAlso Math.Abs(Decimal.Round(baseHT * tauxTVA, 2) - montantTVA) > 0.1 Then
                            'Pas normal, le taux n'est pas respecté
                            AddErrorTVA(report, drvSoumis, String.Format("Le taux de TVA n'est pas respecté : {0:F2} x {1:P2} != {2:C2} ({3:P2})", baseHT, tauxTVA, montantTVA, montantTVA / baseHT))
                        End If
                    End If
                Next
            End Using
            If report.Length > 0 Then
                LongMessageBox.ShowMessage("Les incohérences suivantes ont été trouvées : ", report.ToString, , MsgBoxStyle.Exclamation)
            Else
                MsgBox("Aucune incohérence de TVA", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub AddErrorTVA(ByVal report As System.Text.StringBuilder, ByVal drv As DataRowView, ByVal message As String)
        report.AppendFormat("Pièce n°{0:000} du {1:dd/MM/yy}. code {2} : {3:C2} => " & vbTab & "{4}" & vbCrLf, drv("MPiece"), drv("MDate"), drv("LTva"), drv("MtSoumisTVADeb"), message)
    End Sub

    Private Function GetTauxTVA(ByVal codeTVA As String) As Decimal
        Select Case codeTVA
            Case "N" : Return 0.196D
            Case "R" : Return 0.055D
            Case "V" : Return 0.055D
            Case "W" : Return 0.196D
            Case Else : Return 0D
        End Select
    End Function
#End Region

#Region "Suppression comptes non affectés au PLC"
    Public Sub SupprimerComptesHorsPLC()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim codeDossier As String = My.User.Name
            'Récupérer les comptes concernés
            Dim sqlCpt As String = "SELECT CDossier,CCpt " & _
                                "FROM Comptes LEFT JOIN PlanComptable ON Comptes.CDossier = PlanComptable.PlDossier AND Comptes.CCpt=PlanComptable.PlCpt " & _
                                "WHERE CDossier='{0}' AND PlCpt IS NULL"
            Using conn As OleDb.OleDbConnection = UtilBase.ConnecterBase(My.Settings.CheminBase)
                Dim dtCpt As DataTable = ExecuteDataTable(String.Format(sqlCpt, codeDossier), conn)
                If dtCpt.Rows.Count = 0 Then
                    MsgBox("Aucun compte à supprimer", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If MsgBox(String.Format("Vous allez supprimer {0} comptes, voulez-vous continuer ?", dtCpt.Rows.Count), MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
                Using t As OleDb.OleDbTransaction = conn.BeginTransaction
                    Try
                        For Each dr As DataRow In dtCpt.Rows
                            ExecuteNonQuery(String.Format("DELETE FROM Comptes WHERE CDossier='{0}' AND CCpt='{1}'", dr("CDossier"), dr("CCpt")), t)
                        Next
                        t.Commit()
                    Catch ex As Exception
                        t.Rollback()
                        Throw New Exception(ex.Message, ex)
                    End Try
                End Using
                MsgBox(String.Format("{0} comptes supprimés", dtCpt.Rows.Count), MsgBoxStyle.Information)
            End Using
        Catch ex As Exception
            MsgBox("Suppression annulée : " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Suppression comptes non mouvementés"
    Public Sub SupprimerComptesNonMouvementes()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim codeDossier As String = My.User.Name
            'Récupérer les comptes concernés
            Dim sqlPLC As String = "SELECT PlDossier,PlCpt,PlActi " & _
                                "FROM PlanComptable LEFT JOIN Mouvements ON PlanComptable.PlDossier=Mouvements.MDossier AND Mouvements.MCpt=PlanComptable.PlCpt AND Mouvements.MActi=PlanComptable.PlActi " & _
                                "WHERE PlDossier='{0}' AND MCpt IS NULL"
            Dim sqlCpt As String = "SELECT CDossier,CCpt " & _
                                "FROM Comptes LEFT JOIN PlanComptable ON Comptes.CDossier = PlanComptable.PlDossier AND Comptes.CCpt=PlanComptable.PlCpt " & _
                                "WHERE CDossier='{0}' AND PlCpt IS NULL"
            Using conn As OleDb.OleDbConnection = UtilBase.ConnecterBase(My.Settings.CheminBase)
                Dim dtPLC As DataTable = ExecuteDataTable(String.Format(sqlPLC, codeDossier), conn)
                If dtPLC.Rows.Count = 0 Then
                    MsgBox("Aucun compte à supprimer", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If MsgBox(String.Format("Vous allez supprimer {0} comptes, voulez-vous continuer ?", dtPLC.Rows.Count), MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
                Using t As OleDb.OleDbTransaction = conn.BeginTransaction
                    Try
                        For Each dr As DataRow In dtPLC.Rows
                            ExecuteNonQuery(String.Format("DELETE FROM PlanComptable WHERE PlDossier='{0}' AND PlCpt='{1}' AND PlActi='{2}'", dr("PlDossier"), dr("PlCpt"), dr("PlActi")), t)
                        Next
                        'Ensuite on supprime les comptes qui se retrouvent sans entrée dans le PLC
                        Dim dtCpt As DataTable = ExecuteDataTable(String.Format(sqlCpt, codeDossier), t)
                        For Each dr As DataRow In dtCpt.Rows
                            ExecuteNonQuery(String.Format("DELETE FROM Comptes WHERE CDossier='{0}' AND CCpt='{1}'", dr("CDossier"), dr("CCpt")), t)
                        Next
                        t.Commit()
                    Catch ex As Exception
                        t.Rollback()
                        Throw New Exception(ex.Message, ex)
                    End Try
                End Using
                MsgBox(String.Format("{0} comptes supprimés", dtPLC.Rows.Count), MsgBoxStyle.Information)
            End Using
        Catch ex As Exception
            MsgBox("Suppression annulée : " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub MettreAJourLibellePLC()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim sqlPLC As String = "UPDATE Comptes INNER JOIN PlanComptable ON " & _
            "(Comptes.CCpt = PlanComptable.PlCpt) AND " & _
            "(Comptes.CDossier = PlanComptable.PlDossier) " & _
            "SET PlanComptable.PlLib = [Comptes].CLib " & _
            "WHERE (((PlanComptable.PlLib) Is Null))"

            Using oleDbConnection As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                Dim oleDbCommand As New OleDb.OleDbCommand(sqlPLC, oleDbConnection)

                oleDbConnection.Open()

                oleDbCommand.ExecuteNonQuery()

                MsgBox("Traitement terminé.", MsgBoxStyle.Information, "Mise à jour")
            End Using
        Catch ex As Exception
            MsgBox("Mise à jour annulée : " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region


    'Public Sub test()
    '    Dim z As New ICSharpCode.SharpZipLib.Zip.FastZip
    '    z.Password = "toto"
    '    z.CreateZip("D:\temp\azipper.zip", "D:\temp\azipper", True, Nothing)
    'End Sub

End Module

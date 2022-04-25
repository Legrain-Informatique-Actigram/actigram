
Namespace Immobilisations
    Public Class Immobilisation

        Private Const LIMITE_PV_LT As Integer = 720
        Private Const TOLERANCE_ANNUITE_LIN As Integer = 1

        Public DtDebEx As Date
        Public DtFinEx As Date
        Public Mode As ModeImmo

        Public Enum ModeImmo
            None = -1
            Acquisition = 0
            SaisieDonneesAvecAmortAnt = 1
            SaisieDonneesSansAmortAnt = 2
            PassageAuReel = 3
            Cloture = 4
            Consult = 5
            Calcul = 6
            Cession = 7
        End Enum

#Region "Constructeurs"
        Public Sub New(ByVal mode As ModeImmo)
            Me.DtDebEx = My.Dossier.Principal.DateDebutEx
            Me.DtFinEx = My.Dossier.Principal.DateFinEx
            Me.Mode = mode
        End Sub
#End Region

#Region "Public Shared"
        Public Shared Function FindNewOrdre(ByVal cpt As String, ByVal acti As String) As Integer
            Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
                If (immobilisationsTA.MAXIOrdre(My.User.Name, cpt, acti).HasValue) Then
                    Return CShort(immobilisationsTA.MAXIOrdre(My.User.Name, cpt, acti)) + 1
                End If
            End Using

            Return 1
        End Function

        Public Shared Function VerifOrdreLibre(ByVal cpt As String, ByVal acti As String, ByVal ordre As Integer) As Boolean
            Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
                Dim immobilisationsDT As ImmobilisationsDataSet.ImmobilisationsDataTable = immobilisationsTA.GetDataByIDossier_ICpt_IActi_IOrdre(My.User.Name, cpt, acti, CShort(ordre))

                If (immobilisationsDT.Rows.Count = 0) Then
                    Return True
                End If
            End Using

            Return False
        End Function

        Public Sub VerifSaisie(ByVal drv As DataRowView, ByVal mode As ModeImmo, ByVal e As System.ComponentModel.CancelEventArgs)
            Try
                'Dans tous les cas : 
                '   identification renseignée
                If IsDBNull(drv("ICpt")) Then Throw New ApplicationException("Vous devez sélectionner un compte.")
                If IsDBNull(drv("IActi")) Then Throw New ApplicationException("Vous devez sélectionner une activité.")
                If IsDBNull(drv("IOrdre")) Then Throw New ApplicationException("Vous devez saisir un n° d'ordre.")
                '   SI CREATION => Verifier que l'ordre n'est pas déjà pris
                If IsModeCreation(mode) AndAlso drv.IsNew AndAlso Not Immobilisations.Immobilisation.VerifOrdreLibre(CStr(drv("ICpt")), CStr(drv("IActi")), CInt(drv("IOrdre"))) Then Throw New ApplicationException("Ce n° d'ordre est déjà utilisé.")
                '   Date, Val et TVA acquis renseignés
                If IsDBNull(drv("IDtAcquis")) Then Throw New ApplicationException("Vous devez saisir une date d'acquisition.")
                If IsDBNull(drv("IValAcquis")) Then
                    'Throw New ApplicationException("Vous devez saisir une valeur d'acquisition.")
                    drv("IValAcquis") = 0
                End If
                '   Si type=D alors Coef renseigné et compris entre 1 et 3
                If CStr(drv("ITypAmt")) = "D" Then
                    If IsDBNull(drv("ICoeff")) Then Throw New ApplicationException("Vous devez saisir un coefficient dégressif.")
                    If CDec(drv("ICoeff")) < 1 Or CDec(drv("ICoeff")) > 3 Then Throw New ApplicationException("Le coefficient dégressif doit être compris entre 1 et 3.")
                End If
                If mode = Immobilisation.ModeImmo.SaisieDonneesAvecAmortAnt Then
                    'Cumul amort renseigné
                    If Not IsDBNull(drv("IAmtCumTot")) Then
                        If CDec(drv("IAmtCumTot")) > CDec(drv("IValAcquis")) Then Throw New ApplicationException("Le montant de l'amortissement doit être inférieur à la valeur d'acquisition.")
                    End If
                ElseIf mode = Immobilisation.ModeImmo.PassageAuReel Then
                    'Date passage + amort pratiquées au forfait renseignés
                    If IsDBNull(drv("IDtForf")) Then Throw New ApplicationException("Vous devez saisir la date de passage au réel.")
                    If IsDBNull(drv("IValForf")) Then
                        'Throw New ApplicationException("Vous devez saisir le montant de l'amortissement pratiqué au forfait.")
                        drv("IValForf") = 0
                    End If
                    If IsDBNull(drv("IDureeRest")) Then
                        'Throw New ApplicationException("Vous devez saisir la durée restante d'utilisation.")
                        drv("IDureeRest") = 0
                    End If
                ElseIf mode = ModeImmo.Cession Then
                    'Date et val de cession renseignés
                    If IsDBNull(drv("IDtCess")) Then Throw New ApplicationException("Vous devez saisir la date de cession.")
                    If IsDBNull(drv("IValCess")) Then Throw New ApplicationException("Vous devez saisir le montant de la cession.")
                End If
                If mode <> ModeImmo.PassageAuReel Then
                    Dim duree As Integer = 0

                    If Not (IsDBNull(drv("IDuree"))) Then
                        duree = CInt(drv("IDuree"))
                    End If

                    'If IsDBNull(CInt(drv("IDuree"))) OrElse CInt(drv("IDuree")) = 0 Then
                    If duree = 0 Then
                        If CStr(drv("ITypAmt")) = "D" Then
                            Throw New ApplicationException("Un amortissement de durée 0 ne peut être que linéaire.")
                        Else
                            If MsgBox("Vous avez saisi une durée de 0 mois, voulez-vous continuer ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                                drv("IDuree") = 0
                            Else
                                Throw New UserCancelledException("")
                            End If
                        End If
                    End If
                End If
            Catch ex As UserCancelledException
                e.Cancel = True
            Catch ex As ApplicationException
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                e.Cancel = True
            End Try
        End Sub

        Public Shared Sub FixOldImmos(ByVal dtImmos As DataTable, ByVal dta As OleDb.OleDbDataAdapter, ByVal DtFinEx As Date)
            Dim dv As New DataView(dtImmos, "ITauxL IS NULL OR (ITauxL=0 AND IDuree IS NOT NULL AND IDuree>0)", "", DataViewRowState.CurrentRows)
            If dv.Count > 0 Then
                For i As Integer = dv.Count - 1 To 0 Step -1
                    Dim drv As DataRowView = dv(i)
                    drv("IMode") = CInt(Immobilisation.ModeImmo.Calcul)
                    drv("INCompo") = 0
                    drv("IValNetFisc") = System.Math.Max(CDec(drv("IValAcquis")), CDec(drv("IValVenale"))) - (CDec(drv("IAmtCumTot")) + CDec(drv("IAmtExTot")))
                    Dim tauxL As Decimal
                    If Not IsDBNull(drv("IDuree")) AndAlso CInt(drv("IDuree")) > 0 Then
                        tauxL = CDec(12.0 / CInt(drv("IDuree")))
                        If Not IsDBNull(drv("ICoeff")) Then
                            drv("ITauxD") = tauxL * CDec(drv("ICoeff"))
                        Else
                            drv("ITauxD") = DBNull.Value
                        End If
                        Dim nbTotAnn As Integer = CInt(System.Math.Ceiling(CInt(drv("IDuree")) / 12))
                        'drv("IAnnDDeb") = System.Math.Max(0, nbTotAnn - (FrMDI.DossierEnCours.DtFinEx.Subtract(CDate(drv("IDtAcquis"))).Days \ 365))

                        drv("IAnnDDeb") = System.Math.Max(0, nbTotAnn - Days360(CDate(drv("IDtAcquis")), DtFinEx) \ 360)
                    Else
                        tauxL = 0
                        drv("ITauxD") = 0
                        drv("IAnnDDeb") = 0
                    End If
                    drv("ITauxL") = tauxL
                    drv.EndEdit()
                Next
                dta.Update(dtImmos)
            End If
        End Sub
#End Region

#Region "Private Shared"
        Private Shared Function IsModeCreation(ByVal mode As ModeImmo) As Boolean
            Return mode < ModeImmo.Cloture
        End Function

        Private Function IsModeCession(ByVal mode As ModeImmo) As Boolean
            Return mode > ModeImmo.Consult
        End Function
#End Region

#Region "Calcul des amort"
        Public Sub CalculerDonneesAmort(ByVal drv As DataRowView)
            CalculerDonneesAmort(drv, Me.Mode)
        End Sub

        Public Sub CalculerDonneesAmort(ByVal drv As DataRowView, ByVal mode As ModeImmo)

            If IsModeCreation(mode) Then
                'EN CAS DE CREATION DE L'IMMO
                'CALCUL DE LA DUREE D'AMORTISSEMENT!
                If mode = ModeImmo.PassageAuReel Then
                    'Calculer la durée en fonction de date deb ex,date acqu,durée restante d'util
                    If CInt(drv("IDureeRest")) = 0 AndAlso CDec(drv("IValForf")) = 0 Then
                        drv("IDuree") = 0
                    Else
                        drv("IDuree") = Microsoft.VisualBasic.DateDiff(DateInterval.Month, CDate(drv("IDtAcquis")), CDate(drv("IDtForf"))) + CInt(drv("IDureeRest"))
                    End If
                End If

                'CALCUL DES TAUX D'AMORTISSEMENT
                drv("ITauxL") = 0
                drv("ITauxD") = 0

                If Not IsDBNull(drv("IDuree")) AndAlso CInt(drv("IDuree")) > 0 Then
                    drv("ITauxL") = 12.0 / CInt(drv("IDuree"))
                    If Not IsDBNull(drv("ICoeff")) Then
                        drv("ITauxD") = CDec(drv("ITauxL")) * CDec(drv("ICoeff"))
                    Else
                        drv("ITauxD") = DBNull.Value
                    End If
                Else
                    drv("ITauxL") = 0
                    drv("ITauxD") = 0
                End If

                'CALCUL DE L'AMORTISSEMENT CUMULE POUR LES CREATIONS D'AMORT
                Select Case mode
                    Case ModeImmo.PassageAuReel
                        CalculerAmortCumPAR(drv, mode)
                        If IsDBNull(drv("IValForf")) Then drv("IValForf") = drv("IAmtCumTot")
                    Case ModeImmo.SaisieDonneesSansAmortAnt
                        drv("IAmtCumTot") = CalculerAmortCumSAA(drv, mode)
                    Case ModeImmo.SaisieDonneesAvecAmortAnt
                        'Affiche par défaut le résultat du calcul SAA pour comparaison
                        'Le vrai IAmtCumTot doit être saisi
                        If IsDBNull(drv("IAmtCumTot")) Then
                            drv("IAmtCumTot") = CalculerAmortCumSAA(drv, mode)
                        End If
                    Case ModeImmo.Acquisition
                        drv("IAmtCumTot") = 0
                        drv("IAmtCumLin") = 0
                        drv("IAnnDDeb") = System.Math.Ceiling(CInt(drv("IDuree")) / 12)
                End Select
                'Arrondis
                drv("IAmtCumTot") = Decimal.Round(CDec(drv("IAmtCumTot")), 2)
                drv("IAmtCumLin") = Decimal.Round(CDec(drv("IAmtCumLin")), 2)
            ElseIf mode = ModeImmo.Cloture Then
                'TRAITEMENTS SPECIFIQUE CLOTURE 
                If Not ChangementExercice(drv, mode) Then
                    drv.EndEdit()
                    Exit Sub
                End If
            End If

            'CALCUL DE L'AMORTISSEMENT DE L'EXERCICE
            CalculerAmortEx(drv, mode)

            'CALCUL DES VALEURS RESIDUELLES
            CalculValeursResiduelles(drv)
            CalculDureeResiduelle(drv, mode)

            'CALCUL DES PLUS VALUE POUR LES IMMO CEDEES
            CalculPlusValueCession(drv, mode)

            If mode <> ModeImmo.Calcul Then drv("IMode") = CInt(mode)
            drv.EndEdit()
        End Sub

        Private Function CalculerAmortCumSAA(ByVal drv As DataRowView, ByVal mode As ModeImmo) As Decimal
            Dim res As Decimal
            Dim nbTotAnn As Integer = CInt(System.Math.Ceiling(CInt(drv("IDuree")) / 12))
            'drv("IAnnDDeb") = System.Math.Max(0, nbTotAnn - (DtFinEx.Subtract(CDate(drv("IDtAcquis"))).Days \ 365))
            drv("IAnnDDeb") = System.Math.Max(0, nbTotAnn - System.Math.Ceiling(Days360(CDate(drv("IDtAcquis")), DtDebEx) / 360))

            If CInt(drv("IDuree")) = 0 Then
                drv("IAmtCumLin") = 0
                res = 0
            Else
                'Dim proRataTemporis As Decimal = System.Math.Min(1, (DtDebEx.Subtract(CDate(drv("IDtAcquis"))).Days + 1) / CDate(drv("IDtAcquis")).AddMonths(drv("IDuree")).Subtract(CDate(drv("IDtAcquis"))).Days)
                Dim proRataTemporis As Decimal = CDec(System.Math.Min(1, _
                    Days360(CDate(drv("IDtAcquis")), DtDebEx) / _
                    Days360(CDate(drv("IDtAcquis")), CDate(drv("IDtAcquis")).AddMonths(CInt(drv("IDuree"))))))
                Debug.WriteLine("DtAcquis->DtDebEx=" & Days360(CDate(drv("IDtAcquis")), DtDebEx))

                drv("IAmtCumLin") = CDec(drv("IValAcquis")) * proRataTemporis
                If CStr(drv("ITypAmt")) = "L" Then
                    res = CDec(drv("IAmtCumLin"))
                Else
                    If CInt(drv("IAnnDDeb")) = 0 Then
                        res = CDec(drv("IValAcquis"))
                    Else
                        proRataTemporis = CDec((DtDebEx.Month - CDate(drv("IDtAcquis")).Month) / 12)
                        If DtDebEx.DayOfYear < CDate(drv("IDtAcquis")).DayOfYear Then
                            proRataTemporis += 1
                        End If
                        Dim valCum As Decimal = 0
                        Dim valRes As Decimal = CDec(drv("IValAcquis"))
                        For i As Integer = 1 To nbTotAnn - CInt(drv("IAnnDDeb")) '- 1
                            Dim valAnn As Decimal
                            Dim valD As Decimal = valRes * CDec(drv("ITauxD"))
                            Dim valL As Decimal = valRes / (nbTotAnn - i + 1)
                            If i = 1 Then
                                valD = valD * proRataTemporis
                                valL = valL * proRataTemporis
                            End If
                            valAnn = System.Math.Min(valRes, System.Math.Max(valD, valL))
                            valCum += valAnn
                            valRes -= valAnn
                            If valRes = 0 Then Exit For
                        Next
                        res = valCum
                    End If
                End If
            End If
            Return res
        End Function

        Private Sub CalculerAmortCumPAR(ByVal drv As DataRowView, ByVal mode As ModeImmo)
            'Dim dureeForf As Integer = CDate(drv("IDtForf")).Subtract(CDate(drv("IDtAcquis"))).Days + 1
            'Dim dureeRest As Integer = CDate(drv("IDtForf")).AddMonths(CInt(drv("IDureeRest"))).Subtract(CDate(drv("IDtForf"))).Days
            If CInt(drv("IDuree")) > 0 Then
                Dim dureeForf As Integer = Days360(CDate(drv("IDtAcquis")), CDate(drv("IDtForf")))
                Dim dureeRest As Integer = Days360(CDate(drv("IDtForf")), CDate(drv("IDtForf")).AddMonths(CInt(drv("IDureeRest"))))
                If dureeForf > 0 Or dureeRest > 0 Then
                    drv("IAmtCumTot") = CDec(drv("IValAcquis")) * dureeForf / (dureeForf + dureeRest)
                Else
                    drv("IAmtCumTot") = DBNull.Value
                End If
            Else
                drv("IAmtCumTot") = 0
            End If
            drv("IAmtCumLin") = drv("IAmtCumTot")
            'Annuités restantes
            drv("IAnnDDeb") = System.Math.Ceiling(CInt(drv("IDureeRest")) / 12)
        End Sub

        Private Sub CalculerAmortEx(ByVal drv As DataRowView, ByVal mode As ModeImmo)
            Dim valRestante As Decimal = CDec(drv("IValAcquis")) - CDec(drv("IAmtCumTot"))
            'On doit forcément calculer l'annuité linéaire
            Dim proRataTemporis As Decimal
            If CDate(drv("IDtAcquis")) > DtDebEx AndAlso mode <> ModeImmo.Cession Then
                proRataTemporis = CalculerProRataTemporis(drv, ModeImmo.Acquisition, "L")
            Else
                proRataTemporis = CalculerProRataTemporis(drv, mode, "L")
            End If
            'drv("IAmtExLin") = System.Math.Min(valRestante, drv("IValAcquis") * drv("ITauxL") * CalculerProRataTemporis(drv, mode, "L"))
            drv("IAmtExLin") = System.Math.Min(valRestante, CDec(drv("IValAcquis")) * CDec(drv("ITauxL")) * proRataTemporis)
            'Test pour la derniere année (pour eviter les erreurs de centime), 
            'sauf si on a calculé une annuité à 0 (cas des amortissements de 0 mois sur des sommes <1€)        
            If CDec(drv("IAmtExLin")) <> 0D AndAlso System.Math.Abs(valRestante - CDec(drv("IAmtExLin"))) <= TOLERANCE_ANNUITE_LIN Then drv("IAmtExLin") = valRestante
            If CStr(drv("ITypAmt")) = "L" Then '/////////////// LINEAIRE
                drv("IAmtExTot") = drv("IAmtExLin")
                drv("IAmtExMin") = drv("IAmtExLin")
                drv("IAmtExMax") = drv("IAmtExLin")
            Else '////////////////////////////////////// DEGRESSIF
                If IsDBNull(drv("IAnnDDeb")) OrElse CInt(drv("IAnnDDeb")) = 0 Then 'La dernière annuité
                    drv("IAmtExTot") = valRestante
                    drv("IAmtExMin") = drv("IAmtExTot")
                    drv("IAmtExMax") = drv("IAmtExTot")
                Else
                    proRataTemporis = 0
                    If CDate(drv("IDtAcquis")) > DtDebEx AndAlso mode <> ModeImmo.Cession Then
                        proRataTemporis = CalculerProRataTemporis(drv, ModeImmo.Acquisition, "D")
                    Else
                        proRataTemporis = CalculerProRataTemporis(drv, mode, "D")
                    End If

                    Dim val1 As Decimal = System.Math.Min(valRestante, valRestante / CInt(drv("IAnnDDeb")) * proRataTemporis)
                    Dim val2 As Decimal = System.Math.Min(valRestante, valRestante * CDec(drv("ITauxD")) * proRataTemporis)
                    Dim ann As Decimal = System.Math.Max(val1, val2)
                    'Calcul du MIN
                    Dim ra As Decimal = (CDec(drv("IAmtCumTot")) + ann) - (CDec(drv("IAmtExLin")) + CDec(drv("IAmtCumLin")))
                    drv("IAmtExMin") = System.Math.Max(0, ann - ra)
                    'Calcul du MAX
                    If mode = ModeImmo.PassageAuReel Then
                        val1 = System.Math.Min(valRestante, valRestante / CInt(drv("IAnnDDeb")))
                        val2 = System.Math.Min(valRestante, valRestante * CDec(drv("ITauxD")))
                        drv("IAmtExMax") = System.Math.Max(val1, val2)
                    Else
                        drv("IAmtExMax") = ann
                    End If

                    If IsDBNull(drv("IAmtExTot")) _
                    OrElse CDec(drv("IAmtExTot")) < Decimal.Round(CDec(drv("IAmtExMin")), 2) _
                    OrElse CDec(drv("IAmtExTot")) > Decimal.Round(CDec(drv("IAmtExMax")), 2) _
                    OrElse mode = ModeImmo.Cloture Then
                        'Sinon on garde la valeur déjà saisie
                        drv("IAmtExTot") = ann
                    End If
                End If
            End If
            'Arrondis
            drv("IAmtExLin") = Decimal.Round(CDec(drv("IAmtExLin")), 2)
            drv("IAmtExTot") = Decimal.Round(CDec(drv("IAmtExTot")), 2)
            drv("IAmtExMin") = Decimal.Round(CDec(drv("IAmtExMin")), 2)
            drv("IAmtExMax") = Decimal.Round(CDec(drv("IAmtExMax")), 2)
        End Sub

        Private Function CalculerProRataTemporis(ByVal drv As DataRowView, ByVal mode As ModeImmo, ByVal type As String) As Decimal
            Dim res As Decimal
            Dim nbJAn As Integer = 360
            Select Case mode
                Case ModeImmo.Acquisition
                    If type = "L" Then
                        'res = (DtFinEx.Subtract(drv("IDtAcquis")).Days + 1) / nbJEx
                        res = CDec((Days360(CDate(drv("IDtAcquis")), DtFinEx) + 1) / nbJAn)
                    Else
                        Dim dtDebMoisAcquis As Date = New Date(CDate(drv("IDtAcquis")).Year, CDate(drv("IDtAcquis")).Month, 1)
                        'res = (DtFinEx.Subtract(dtDebMoisAcquis).Days + 1) / nbJEx
                        res = CDec((Days360(dtDebMoisAcquis, DtFinEx) + 1) / nbJAn)
                    End If
                Case ModeImmo.Cession
                    If type = "L" Then
                        'res = (CDate(drv("IDtCess")).Subtract(DtDebEx).Days + 1) / nbJEx
                        If DtDebEx > CDate(drv("IDtAcquis")) Then
                            res = CDec(Days360(DtDebEx, CDate(drv("IDtCess"))) / nbJAn)
                        Else
                            res = CDec(Days360(CDate(drv("IDtAcquis")), CDate(drv("IDtCess"))) / nbJAn)
                        End If
                    Else
                        Dim dtDebMoisCession As Date = New Date(CDate(drv("IDtCess")).Year, CDate(drv("IDtCess")).Month, 1)
                        Dim dtDebMoisAcquis As Date = New Date(CDate(drv("IDtAcquis")).Year, CDate(drv("IDtAcquis")).Month, 1).AddDays(-1)

                        'res = (dtDebMoisCession.Subtract(DtDebEx).Days + 1) / nbJEx
                        If DtDebEx > dtDebMoisAcquis Then
                            res = CDec(Days360(DtDebEx, dtDebMoisCession) / nbJAn)
                        Else
                            res = CDec(Days360(dtDebMoisAcquis, dtDebMoisCession) / nbJAn)
                        End If
                    End If
                Case Else
                    res = CDec(NbJEx() / nbJAn)
            End Select

            Return res
        End Function

        Public Sub CalculValeursResiduelles(ByVal drv As DataRowView)
            drv("IValResid") = CDec(drv("IValAcquis")) - (CDec(drv("IAmtCumTot")) + CDec(drv("IAmtExTot")))
            If IsDBNull(drv("IValVenale")) Then drv("IValVenale") = drv("IValAcquis")
            drv("IValNetFisc") = System.Math.Max(CDec(drv("IValAcquis")), CDec(drv("IValVenale"))) - (CDec(drv("IAmtCumTot")) + CDec(drv("IAmtExTot")))
        End Sub

        Private Sub CalculDureeResiduelle(ByVal drv As DataRowView, ByVal mode As ModeImmo)
            If mode = ModeImmo.Cession Then
                drv("IDureeResid") = DBNull.Value
            ElseIf mode = ModeImmo.Cloture Then
                If Not IsDBNull(drv("IDureeResid")) Then
                    drv("IDureeResid") = CInt(drv("IDureeResid")) - (NbJEx() \ 30)
                    If CInt(drv("IDureeResid")) < 0 Then drv("IDureeResid") = 0
                End If
            ElseIf IsModeCreation(mode) Or mode = ModeImmo.Calcul Then
                If CStr(drv("ITypAmt")) = "L" Then
                    drv("IDureeResid") = System.Math.Max(0, CInt(drv("IDuree")) - Days360(CDate(drv("IDtAcquis")), DtFinEx) \ 30)
                ElseIf Not IsDBNull(drv("IAnnDDeb")) Then
                    drv("IDureeResid") = System.Math.Max(0, CInt(drv("IAnnDDeb")) * 12 - System.Math.Ceiling(NbJEx() / 30))
                Else
                    If Not IsDBNull(drv("IAnnDDeb")) Then 'Modif HG 23/09/09
                        drv("IDureeResid") = System.Math.Max(0, CInt(drv("IAnnDDeb")) * 12 - System.Math.Ceiling(NbJEx() / 30))
                    Else
                        drv("IDureeResid") = 0
                    End If
                End If
            End If
        End Sub

        Private Function NbJEx() As Integer
            Return Days360(DtDebEx, DtFinEx) + 1
        End Function

        Private Sub CalculPlusValueCession(ByVal drv As DataRowView, ByVal mode As ModeImmo)
            If Not IsModeCession(mode) Then Exit Sub
            If IsDBNull(drv("IDtCess")) OrElse IsDBNull(drv("IValCess")) Then Exit Sub

            'Dim dureeDet As Integer = CDate(drv("IDtCess")).Subtract(CDate(drv("IDtAcquis"))).Days
            Dim dureeDet As Integer = Days360(CDate(drv("IDtAcquis")), CDate(drv("IDtCess")))
            Dim pvb As Decimal = CDec(drv("IValCess")) - CDec(drv("IValNetFisc"))
            If dureeDet < LIMITE_PV_LT Then
                drv("IPlusValCt") = pvb
                drv("IPlusValLg") = 0
            Else
                drv("IPlusValCt") = System.Math.Min(CDec(drv("IAmtCumTot")) + CDec(drv("IAmtExTot")), pvb)
                drv("IPlusValLg") = pvb - CDec(drv("IPlusValCt"))
            End If
        End Sub

        Private Function ChangementExercice(ByVal drv As DataRowView, ByVal mode As ModeImmo) As Boolean
            If Me.Mode <> ModeImmo.Cloture Then Return True

            If Not IsDBNull(drv("IAnnDDeb")) AndAlso CInt(drv("IAnnDDeb")) > 0 Then
                drv("IAnnDDeb") = CInt(drv("IAnnDDeb")) - 1
            End If

            drv("IAmtCumLin") = CDec(drv("IAmtCumLin")) + CDec(drv("IAmtExLin"))
            drv("IAmtCumTot") = CDec(drv("IAmtCumTot")) + CDec(drv("IAmtExTot"))
            drv("IAmtExLin") = 0
            drv("IAmtExTot") = 0
            Return True
        End Function
#End Region

        Public Function CessionPartielle(ByVal drv As DataRowView, Optional ByVal DtCession As Date = #1/1/1900#, Optional ByVal ValCession As Decimal = 0) As DataRowView
            'Saisir les infos de la nouvelle immo
            Dim fr As New FrCessionPartielle(drv, DtCession, ValCession)
            If fr.ShowDialog <> DialogResult.OK Then Throw New UserCancelledException("")

            Dim drvNew As DataRowView = drv.DataView.AddNew
            Dim newValAcquis As Decimal = fr.NewValAcquis
            Dim quot As Decimal = newValAcquis / CDec(drv("IValAcquis"))

            '/////////////////////////////////////////////////////////////
            '// COPIER LES INFOS DE L'IMMO PRINCIPALE DANS L'IMMO COPIÉE
            With drvNew
                .BeginEdit()
                'Identification
                .Item("IDossier") = drv("IDossier")
                .Item("ICpt") = drv("ICpt")
                .Item("ICpt") = drv("ICpt")
                .Item("IActi") = drv("IActi")
                .Item("IOrdre") = Immobilisation.FindNewOrdre(CStr(drv("ICpt")), CStr(drv("IActi")))
                .Item("ILib") = fr.NewLib
                Dim tx As String = fr.NewObs.Replace(vbCrLf, " ").Replace("  ", " ")
                .Item("ILib2") = Microsoft.VisualBasic.Mid(tx, 1, 15)
                .Item("ILib3") = Microsoft.VisualBasic.Mid(tx, 16, 20)
                .Item("ILib4") = Microsoft.VisualBasic.Mid(tx, 36, 20)
                'Acquisition
                .Item("IDtAcquis") = drv("IDtAcquis")
                .Item("IValAcquis") = newValAcquis
                If Not IsDBNull(drv("ITva")) Then .Item("ITva") = Decimal.Round(CDec(drv("ITva")) * quot, 2)
                If Not IsDBNull(drv("IValVenale")) Then .Item("IValVenale") = Decimal.Round(CDec(drv("IValVenale")) * quot, 2)
                .Item("IValLeasing") = 0
                'Cession
                .Item("IDtCess") = fr.DtCess
                .Item("IValCess") = fr.ValCess
                'Passage au réel
                .Item("IDtForf") = drv("IDtForf")
                .Item("IDureeRest") = drv("IDureeRest")
                If Not IsDBNull(drv("IValForf")) Then .Item("IValForf") = Decimal.Round(CDec(drv("IValForf")) * quot, 2)
                'Amortissement
                .Item("ITypAmt") = drv("ITypAmt")
                .Item("IAnnDDeb") = drv("IAnnDDeb")
                .Item("ICoeff") = drv("ICoeff")
                .Item("IDerogatoire") = drv("IDerogatoire")
                .Item("IDuree") = drv("IDuree")
                .Item("ITauxL") = drv("ITauxL")
                .Item("ITauxD") = drv("ITauxD")
                .Item("IAmtCumTot") = Decimal.Round(CDec(drv("IAmtCumTot")) * quot, 2)
                .Item("IAmtCumLin") = Decimal.Round(CDec(drv("IAmtCumLin")) * quot, 2)
                'Cession partielle
                .Item("IOrdreImmoPrinc") = drv("IOrdre")
                'Calculer les amorts de cession de la part cédée
                CalculerDonneesAmort(drvNew, ModeImmo.Cession)
            End With

            '/////////////////////////////////////////////////////////////
            '// MAJ L'IMMO INITIALE
            With drv
                .BeginEdit()
                .Item("IValAcquis") = CDec(drv.Item("IValAcquis")) - newValAcquis
                If Not IsDBNull(.Item("ITva")) Then .Item("ITva") = Decimal.Round(CDec(drv.Item("ITva")) * (1 - quot), 2)
                If Not IsDBNull(.Item("IValVenale")) Then .Item("IValVenale") = Decimal.Round(CDec(drv.Item("IValVenale")) * (1 - quot), 2)
                If Not IsDBNull(.Item("IValForf")) Then .Item("IValForf") = Decimal.Round(CDec(drv.Item("IValForf")) * (1 - quot), 2)
                .Item("IAmtCumTot") = Decimal.Round(CDec(drv.Item("IAmtCumTot")) * (1 - quot), 2)
                .Item("IAmtCumLin") = Decimal.Round(CDec(drv.Item("IAmtCumLin")) * (1 - quot), 2)
                'Recalculer les amortissements de l'exercice
                CalculerDonneesAmort(drv, ModeImmo.Calcul)
            End With

            Return drvNew
        End Function

    End Class
End Namespace

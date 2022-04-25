Namespace AnnexesTiers.ClassesMetier
    Public Class ImpressionAnnexesTiers

        Private _CodeDossier As String
        Private _DateDeb As Date
        Private _DateFin As Date
        Private _BaremesDS As DataSetBaremes
        Private _AgrigestConnString As String
        Private _BaremesConnString As String
        Private _Actif_PassifTA As DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter
        Private _Type_Plan_ComptableTA As DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter
        Private _Fourchette_ComptesTA As DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter
        Private _ImpAnnexesTiersTA As DataSetImpressionTableAdapters.ImpAnnexesTiersTableAdapter
        Private _SoldesTA As DataSetImpressionTableAdapters.SOLDESTableAdapter

#Region "Constructeurs"
        Public Sub New(ByVal codeDossier As String, ByVal dateDeb As Date, ByVal dateFin As Date, _
                        ByVal agrigestConnString As String, ByVal baremesConnString As String)

            Me._CodeDossier = codeDossier
            Me._DateDeb = dateDeb
            Me._DateFin = dateFin
            Me._BaremesDS = New DataSetBaremes
            Me._AgrigestConnString = agrigestConnString
            Me._BaremesConnString = baremesConnString

            Me._Actif_PassifTA = New DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter
            Me._Actif_PassifTA.Connection.ConnectionString = Me._BaremesConnString

            Me._Type_Plan_ComptableTA = New DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter
            Me._Type_Plan_ComptableTA.Connection.ConnectionString = Me._BaremesConnString

            Me._Fourchette_ComptesTA = New DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter
            Me._Fourchette_ComptesTA.Connection.ConnectionString = Me._BaremesConnString

            Me._ImpAnnexesTiersTA = New DataSetImpressionTableAdapters.ImpAnnexesTiersTableAdapter
            Me._ImpAnnexesTiersTA.Connection.ConnectionString = Me._AgrigestConnString

            Me._SoldesTA = New DataSetImpressionTableAdapters.SOLDESTableAdapter
            Me._SoldesTA.Connection.ConnectionString = Me._AgrigestConnString

            Me.RemplirDataSetBaremes()
        End Sub
#End Region

#Region "Méthodes internes"
        Private Sub RemplirDataSetBaremes()
            Me._Actif_PassifTA.Fill(Me._BaremesDS.ACTIF_PASSIF)
            Me._Type_Plan_ComptableTA.Fill(Me._BaremesDS.TYPE_PLAN_COMPTABLE)
            Me._Fourchette_ComptesTA.Fill(Me._BaremesDS.FOURCHETTE_COMPTES)
        End Sub

        Private Function GetType_Plan_ComptableDeExploitation() As AnnexesTiers.ClassesMetier.Type_Plan_Comptable
            Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(Me._AgrigestConnString)
            Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(Me._CodeDossier)
            Dim gestExpl As New Dossiers.ClassesControleur.GestionnaireExploitations(Me._AgrigestConnString)
            Dim expl As Dossiers.ClassesMetier.Exploitations = gestExpl.GetExploitation(dossier.DExpl)
            Dim gestTypePlanComptable As New AnnexesTiers.ClassesControleur.GestionnaireType_Plan_Comptable(Me._BaremesConnString)
            Dim type_Pl_Cpt As AnnexesTiers.ClassesMetier.Type_Plan_Comptable = gestTypePlanComptable.GetType_Plan_Comptable(expl.EType)

            Return type_Pl_Cpt
        End Function

        Private Sub CopierImpAnnexesTiersDR(ByVal impAnnexesTiersDR As DataSetImpression.ImpAnnexesTiersRow, ByVal impressionDS As DataSetImpression)
            Dim nouveau_impAnnexesTiersDR As DataSetImpression.ImpAnnexesTiersRow = CType(impressionDS.ImpAnnexesTiers.NewRow(), DataSetImpression.ImpAnnexesTiersRow)

            nouveau_impAnnexesTiersDR.MDossier = impAnnexesTiersDR.MDossier
            nouveau_impAnnexesTiersDR.MPiece = impAnnexesTiersDR.MPiece
            nouveau_impAnnexesTiersDR.MDate = impAnnexesTiersDR.MDate
            nouveau_impAnnexesTiersDR.MCpt = impAnnexesTiersDR.MCpt
            nouveau_impAnnexesTiersDR.CLib = impAnnexesTiersDR.CLib
            nouveau_impAnnexesTiersDR.LLib = impAnnexesTiersDR.LLib
            nouveau_impAnnexesTiersDR.MMtDeb = impAnnexesTiersDR.MMtDeb
            nouveau_impAnnexesTiersDR.MMtCre = impAnnexesTiersDR.MMtCre
            nouveau_impAnnexesTiersDR.EType = impAnnexesTiersDR.EType
            nouveau_impAnnexesTiersDR.COMPTE_DEB = impAnnexesTiersDR.COMPTE_DEB
            nouveau_impAnnexesTiersDR.COMPTE_FIN = impAnnexesTiersDR.COMPTE_FIN
            nouveau_impAnnexesTiersDR.CODE_ACTIF_PASSIF = impAnnexesTiersDR.CODE_ACTIF_PASSIF
            nouveau_impAnnexesTiersDR.POSITION = impAnnexesTiersDR.POSITION
            nouveau_impAnnexesTiersDR.EST_DETAILLE = impAnnexesTiersDR.EST_DETAILLE
            nouveau_impAnnexesTiersDR.SOLDE_CPT = impAnnexesTiersDR.SOLDE_CPT

            impressionDS.ImpAnnexesTiers.Rows.Add(nouveau_impAnnexesTiersDR)
        End Sub

        Private Sub ReportProgress(ByVal progBar As System.Windows.Forms.ProgressBar, ByVal percent As Integer)
            progBar.Value = percent
            Application.DoEvents()
        End Sub

        Private Sub SetInfosFourchette_Comptes(ByVal fourchette_Comptes_Actif_PassifDR As DataSetBaremes.FOURCHETTE_COMPTESRow, _
                                                ByVal impAnnexesTiersDR As DataSetImpression.ImpAnnexesTiersRow)
            'Remplisssage COMPTE_DEB
            If Not (fourchette_Comptes_Actif_PassifDR.IsCOMPTE_DEBNull) Then
                impAnnexesTiersDR.COMPTE_DEB = fourchette_Comptes_Actif_PassifDR.COMPTE_DEB
            Else
                impAnnexesTiersDR.COMPTE_DEB = String.Empty
            End If

            'Remplissage COMPTE_FIN
            If Not (fourchette_Comptes_Actif_PassifDR.IsCOMPTE_FINNull) Then
                impAnnexesTiersDR.COMPTE_FIN = fourchette_Comptes_Actif_PassifDR.COMPTE_FIN
            Else
                impAnnexesTiersDR.COMPTE_FIN = String.Empty
            End If

            'Remplissage POSITION
            If Not (fourchette_Comptes_Actif_PassifDR.IsPOSITIONNull) Then
                impAnnexesTiersDR.POSITION = fourchette_Comptes_Actif_PassifDR.POSITION
            Else
                impAnnexesTiersDR.POSITION = 0
            End If

            'Remplissage EST_DETAILLE
            If Not (fourchette_Comptes_Actif_PassifDR.IsEST_DETAILLENull) Then
                impAnnexesTiersDR.EST_DETAILLE = fourchette_Comptes_Actif_PassifDR.EST_DETAILLE
            Else
                impAnnexesTiersDR.EST_DETAILLE = False
            End If
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetData() As DataSetImpression
            Dim impressionDS As New DataSetImpression
            Dim i As Integer = 0


            'Recherche l'identifiant du type de plan comptable de l'exploitation
            Dim type_PC_Exploitation As AnnexesTiers.ClassesMetier.Type_Plan_Comptable = Me.GetType_Plan_ComptableDeExploitation()

            'Recherche des identifiants ACTIF et PASSIF
            Dim gestActif_Passif As New AnnexesTiers.ClassesControleur.GestionnaireActif_Passif(Me._BaremesConnString)
            Dim infosActif As AnnexesTiers.ClassesMetier.Actif_Passif = gestActif_Passif.GetActif_Passif("A")
            Dim infosPassif As AnnexesTiers.ClassesMetier.Actif_Passif = gestActif_Passif.GetActif_Passif("P")

            'Rempli une DataTable avec les soldes des comptes
            Dim soldesDT As DataSetImpression.SOLDESDataTable = Nothing

            Using soldesTA As New DataSetImpressionTableAdapters.SOLDESTableAdapter
                soldesDT = soldesTA.GetDataByMDossier(Me._CodeDossier)
            End Using

            'Rempli une DataTable avec les infos des mouvements en fonction du dossier, 
            'des dates de début et de fin
            Dim impAnnexesDT As DataSetImpression.ImpAnnexesTiersDataTable = Me._ImpAnnexesTiersTA.GetDataByMDossierEtMDate(Me._CodeDossier, Me._DateDeb, Me._DateFin)

            For Each impAnnexesTiersDR As DataSetImpression.ImpAnnexesTiersRow In impAnnexesDT.Rows
                'Recherche des infos dans la BDD des Barèmes
                Dim filtre As String = String.Empty

                filtre = String.Format("(COMPTE_DEB <= '{0}') AND (COMPTE_FIN >= '{0}') AND (ID_TYPE_PLAN_COMPTABLE = {1})", impAnnexesTiersDR.MCpt, type_PC_Exploitation.ID_TYPE_PLAN_COMPTABLE)

                Dim listeFourchette_ComptesDR() As DataSetBaremes.FOURCHETTE_COMPTESRow = CType(Me._BaremesDS.FOURCHETTE_COMPTES.Select(filtre, ""), DataSetBaremes.FOURCHETTE_COMPTESRow())

                If Not (listeFourchette_ComptesDR Is Nothing) Then
                    If ((listeFourchette_ComptesDR.Length > 0) And Not (impAnnexesTiersDR.IsMCptNull)) Then
                        Dim fourchette_ComptesDR As DataSetBaremes.FOURCHETTE_COMPTESRow = listeFourchette_ComptesDR(0)

                        'Récupération des infos liées dans la table ACTIF_PASSIF
                        Dim actif_PassifDR As DataSetBaremes.ACTIF_PASSIFRow = CType(fourchette_ComptesDR.GetParentRow("ACTIF_PASSIFFOURCHETTE_COMPTE"), DataSetBaremes.ACTIF_PASSIFRow)

                        If Not (actif_PassifDR.IsCODE_ACTIF_PASSIFNull) Then
                            'Recherche des infos concernant le solde du compte
                            Dim solde As Decimal = 0
                            Dim listeSoldesDR() As DataSetImpression.SOLDESRow = CType(soldesDT.Select(String.Format("MCpt='{0}'", impAnnexesTiersDR.MCpt), ""), DataSetImpression.SOLDESRow())

                            'Calcul du solde du compte : SOLDE_D - SOLDE_C
                            If Not (listeSoldesDR Is Nothing) Then
                                If (listeSoldesDR.Length > 0) Then
                                    Dim soldeDR As DataSetImpression.SOLDESRow = listeSoldesDR(0)

                                    If Not (soldeDR.IsSOLDE_DNull) Then
                                        solde = soldeDR.SOLDE_D
                                    End If

                                    If Not (soldeDR.IsSOLDE_CNull) Then
                                        solde = solde - soldeDR.SOLDE_C
                                    End If

                                    impAnnexesTiersDR.SOLDE_CPT = solde
                                End If
                            End If

                            'S'il y a plusieurs lignes dans FOURCHETTE_COMPTES comprenant ce compte, 
                            'c'est un compte mixte ACTIF/PASSIF.
                            'Si son solde est > 0 alors il est à l'ACTIF sinon au PASSIF
                            If (listeFourchette_ComptesDR.Length > 1) Then
                                If (solde >= 0) Then
                                    impAnnexesTiersDR.CODE_ACTIF_PASSIF = "A"

                                    'On récupère les infos de la ligne ACTIF 
                                    For Each fourchette_Comptes_Actif_PassifDR As DataSetBaremes.FOURCHETTE_COMPTESRow In listeFourchette_ComptesDR
                                        If Not (fourchette_Comptes_Actif_PassifDR.IsID_ACTIF_PASSIFNull) Then
                                            If (fourchette_Comptes_Actif_PassifDR.ID_ACTIF_PASSIF = infosActif.ID_ACTIF_PASSIF) Then
                                                Me.SetInfosFourchette_Comptes(fourchette_Comptes_Actif_PassifDR, impAnnexesTiersDR)
                                            End If
                                        End If
                                    Next
                                Else
                                    impAnnexesTiersDR.CODE_ACTIF_PASSIF = "P"

                                    'On récupère les infos de la ligne PASSIF
                                    For Each fourchette_Comptes_Actif_PassifDR As DataSetBaremes.FOURCHETTE_COMPTESRow In listeFourchette_ComptesDR
                                        If Not (fourchette_Comptes_Actif_PassifDR.IsID_ACTIF_PASSIFNull) Then
                                            If (fourchette_Comptes_Actif_PassifDR.ID_ACTIF_PASSIF = infosPassif.ID_ACTIF_PASSIF) Then
                                                Me.SetInfosFourchette_Comptes(fourchette_Comptes_Actif_PassifDR, impAnnexesTiersDR)
                                            End If
                                        End If
                                    Next
                                End If
                            Else 'sinon on prend la valeur de la ligne FOURCHETTE_COMPTES
                                impAnnexesTiersDR.CODE_ACTIF_PASSIF = actif_PassifDR.CODE_ACTIF_PASSIF

                                Me.SetInfosFourchette_Comptes(fourchette_ComptesDR, impAnnexesTiersDR)
                            End If

                            'Contrôle sur les valeurs nulles
                            If (impAnnexesTiersDR.IsCOMPTE_DEBNull) Then
                                impAnnexesTiersDR.COMPTE_DEB = String.Empty
                            End If

                            If (impAnnexesTiersDR.IsCOMPTE_FINNull) Then
                                impAnnexesTiersDR.COMPTE_FIN = String.Empty
                            End If

                            If (impAnnexesTiersDR.IsPOSITIONNull) Then
                                impAnnexesTiersDR.POSITION = 0
                            End If

                            If (impAnnexesTiersDR.IsEST_DETAILLENull) Then
                                impAnnexesTiersDR.EST_DETAILLE = False
                            End If

                            If (impAnnexesTiersDR.IsSOLDE_CPTNull) Then
                                impAnnexesTiersDR.SOLDE_CPT = 0
                            End If

                            'Copie la ligne dans dsImpression
                            Me.CopierImpAnnexesTiersDR(impAnnexesTiersDR, impressionDS)
                        End If
                    End If
                End If
            Next

            Return impressionDS
        End Function
#End Region

#Region "Méthodes partagées"
        Public Shared Function GetDataImpAnnexesTiers(ByVal codeDossier As String, ByVal dateDeb As Date, _
                                                    ByVal dateFin As Date) As DataSetImpression

            Dim impAnnexesTiers As New AnnexesTiers.ClassesMetier.ImpressionAnnexesTiers(codeDossier, dateDeb, dateFin, My.Settings.dbDonneesConnectionString, My.Settings.BaremesConnectionString)

            Return impAnnexesTiers.GetData()
        End Function
#End Region

    End Class
End Namespace

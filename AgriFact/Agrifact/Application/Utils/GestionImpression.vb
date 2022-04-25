Public Class GestionImpression
    Public Shared Function TrouverRapport(ByVal nomRapport As String, Optional ByVal secteur As String = "") As GRC.FrFusion
        Return New GRC.FrFusion(TrouverRapport(nomRapport, True, secteur))
    End Function

    Public Shared Function TrouverRapport(ByVal datasource As DataSet, ByVal nomRapport As String, Optional ByVal secteur As String = "") As GRC.FrFusion
        Return New GRC.FrFusion(datasource, TrouverRapport(nomRapport, datasource Is Nothing, secteur))
    End Function

    Public Shared Function TrouverRapport(ByVal datasource As DataView, ByVal nomRapport As String, Optional ByVal secteur As String = "") As GRC.FrFusion
        Return New GRC.FrFusion(datasource, TrouverRapport(nomRapport, datasource Is Nothing, secteur))
    End Function

    Private Shared Function TrouverRapport(ByVal nomRapport As String, ByVal etatServer As Boolean, Optional ByVal secteur As String = "") As String
        If IO.Path.IsPathRooted(nomRapport) Then
            Return nomRapport
        Else
            Dim dir As String
            Dim STR_EtatsEtatsServer As String = "Etats\EtatsServer"
            Dim STR_EtatsRptStandard As String = "Etats\RptStandard"
            Dim ds As New DataSet
            Dim repSecteur As String = String.Empty

            Using s As New SqlProxy
                DefinitionDonnees.Instance.Fill(ds, "Parametres", s)
            End Using

            If CBool((ParametresBase.GetValeur(ds, "UtiliserModelesImpServices", Nothing, "False"))) Then
                If Not (String.IsNullOrEmpty(secteur)) Then
                    repSecteur = "\" & secteur
                End If
            End If

            If FrApplication.Parametres.RepEtatsSpecifiques <> "" _
            AndAlso IO.File.Exists(IO.Path.Combine(CheminComplet(FrApplication.Parametres.RepEtatsSpecifiques & repSecteur), nomRapport)) Then
                dir = CheminComplet(FrApplication.Parametres.RepEtatsSpecifiques & repSecteur)
            ElseIf etatServer _
            AndAlso IO.File.Exists(IO.Path.Combine(CheminComplet(STR_EtatsEtatsServer), nomRapport)) Then
                dir = CheminComplet(STR_EtatsEtatsServer)
            Else
                dir = CheminComplet(STR_EtatsRptStandard)
            End If
            Return IO.Path.Combine(dir, nomRapport)
            End If
    End Function

    Public Shared Sub AppliquerParametres(ByVal fr As GRC.FrFusion, Optional ByVal nomTable As String = "")
        Dim dsParams As New DataSet
        DefinitionDonnees.Instance.Fill(dsParams, "Parametres")
        AppliquerParametres(fr, dsParams, nomTable)
    End Sub

    Public Shared Sub AppliquerParametres(ByVal fr As GRC.FrFusion, ByVal dsParams As DataSet, Optional ByVal nomTable As String = "")
        If Not fr Is Nothing Then
            Dim dtParams As DataTable
            If Not dsParams Is Nothing AndAlso dsParams.Tables.Contains("Parametres") Then
                dtParams = dsParams.Tables("Parametres")
            End If
            With fr.Parametres
                .EnTete = ValeurParamImpression(dtParams, "EnTete", nomTable, "")
                .EnTeteDetail = ValeurParamImpression(dtParams, "EnTeteDetail", nomTable, "")
                .PiedPageDetail = ValeurParamImpression(dtParams, "PiedPageDetail", nomTable, "")
                .InfoLegale = ValeurParamImpression(dtParams, "InfoLegale", nomTable, "")
                .InfoLegale2 = ValeurParamImpression(dtParams, "InfoLegale2", nomTable, "")
                If Boolean.Parse(ParametresBase.GetValeur(dtParams, "ImprimerRIB", nomTable, "True")) Then
                    .CodePaysIBAN = ValeurParamImpression(dtParams, "CodePaysIBAN", nomTable, "")
                    .CodeEtablissement = ValeurParamImpression(dtParams, "CodeEtablissement", nomTable, "")
                    .CodeGuichet = ValeurParamImpression(dtParams, "CodeGuichet", nomTable, "")
                    .NCompte = ValeurParamImpression(dtParams, "NCompte", nomTable, "")
                    .CleRIB = ValeurParamImpression(dtParams, "CleRIB", nomTable, "")
                    .Domiciliation = ValeurParamImpression(dtParams, "Domiciliation", nomTable, "")
                    .IBANSWIFT = ValeurParamImpression(dtParams, "SWIFT_BIC", nomTable, "")
                Else
                    .CodePaysIBAN = ""
                    .CodeEtablissement = ""
                    .CodeGuichet = ""
                    .NCompte = ""
                    .CleRIB = ""
                    .Domiciliation = ""
                    .IBANSWIFT = ""
                End If
                .SetValue("AdresseLeft", ValeurParamImpression(dtParams, "AdresseLeft", nomTable, "110"))
                .SetValue("AdresseTop", ValeurParamImpression(dtParams, "AdresseTop", nomTable, "50"))
                .ModeRgtParDef = ValeurParamImpression(dtParams, "ModeRgtParDef", nomTable, "")
                .NomAbregeEntite = ValeurParamImpression(dtParams, "NomAbregeEntite", nomTable, "")
                .EcheanceVisible = ValeurParamImpression(dtParams, "EcheanceVisible", nomTable, "")
                '.EcheanceVisible = "True"

                Dim txEscompte As String = String.Empty

                txEscompte = ValeurParamImpression(dtParams, "TauxEscompte", nomTable, "")

                If Not (txEscompte = String.Empty) Then
                    txEscompte = Convert.ToString(CDec(txEscompte) / 100)
                Else
                    txEscompte = "0"
                End If

                .SetValue("TauxEscompte", txEscompte)

                Dim delaiValiditeEscompte As String = String.Empty

                delaiValiditeEscompte = ValeurParamImpression(dtParams, "DelaiValiditeEscompte", nomTable, "")

                If (delaiValiditeEscompte = String.Empty) Then
                    delaiValiditeEscompte = "0"
                End If

                .SetValue("DelaiValiditeEscompte", delaiValiditeEscompte)
            End With
        End If
    End Sub

    Private Shared Function ValeurParamImpression(ByVal dtParams As DataTable, ByVal nomParam As String, ByVal nomTable As String, ByVal valeurDefaut As String) As String
        Dim res As String = valeurDefaut
        If Not dtParams Is Nothing Then
            Dim rws() As DataRow = dtParams.Select(String.Format("Cle='{0}' And (TypePiece is null Or TypePiece='{1}')", nomParam, nomTable), "TypePiece desc")
            If rws.Length > 0 Then
                res = Convert.ToString(rws(0).Item("Valeur"))
            End If
        End If
        Return res
    End Function

    Public Shared Sub GestionLogo(ByVal fr As GRC.FrFusion)
        If fr.Datasource Is Nothing Then Exit Sub
        If Not TypeOf fr.Datasource Is DataSet Then Exit Sub
        Dim ds As DataSet = CType(fr.Datasource, DataSet)
        If ds.Tables.Contains("Parametres") Then
            If ds.Tables("Parametres").Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables("Parametres").Rows(0).Item("Logo")) Then
                    fr.LeftEnTete = 240 * 10
                    fr.LogoVisible = True
                Else
                    fr.LogoVisible = False
                End If
            End If
        End If
    End Sub

End Class

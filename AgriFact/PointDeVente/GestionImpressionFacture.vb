Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module GestionImpressionFacture
    Public Sub ImprimerFacture(ByVal nDevis As Integer, ByVal apercu As Boolean)
        'Charger les données
        Dim ds As New DsAgrifact
        Using dta As New DsAgrifactTableAdapters.EntrepriseTA
            dta.FillByNDevis(ds.Entreprise, nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.VFactureTA
            dta.FillBynDevis(ds.VFacture, nDevis)
        End Using
        If ds.VFacture.Rows.Count = 0 Then Exit Sub
        Using dta As New DsAgrifactTableAdapters.VFacture_DetailTA
            dta.FillBynDevis(ds.VFacture_Detail, nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.ReglementTA
            dta.FillBynDevis(ds.Reglement, nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.Reglement_DetailTA
            dta.FillBynDevis(ds.Reglement_Detail, nDevis)
        End Using
        Using dta As New DsAgrifactTableAdapters.TVA_TA
            dta.Fill(ds.TVA)
        End Using
        Dim dtParams As DsAgrifact.ParametresDataTable
        Using dta As New DsAgrifactTableAdapters.ParametresTA
            dta.FillByCle(ds.Parametres, DsAgrifact.ParametresDataTable.Cles.Logo.ToString)
            dtParams = dta.GetData
        End Using
        RemplisDetailTVA(ds)
        'Lancer l'impression sur drFacture
        ImprimerFacture(ds, dtParams, apercu)
    End Sub

    Private Sub RemplisDetailTVA(ByVal myDs As DataSet)
        Dim dt As DataTable = myDs.Tables.Add("TVA_DETAIL")
        With dt.Columns
            .Add("nTVA", GetType(Long))
            .Add("TTVA", GetType(String))
            .Add("TTaux", GetType(Decimal))
            .Add("TCoef", GetType(Decimal))
        End With

        For Each rwTVA As DataRow In myDs.Tables("TVA").Rows
            Select Case Convert.ToString(rwTVA.Item("TTVA"))
                Case "RPCH"
                    Dim rwTVADetail As DataRow = dt.NewRow
                    With rwTVADetail
                        .Item("nTVA") = rwTVA.Item("nTVA")
                        .Item("TTVA") = 5.5
                        .Item("TTaux") = 5.5
                        .Item("TCoef") = 0.75D '75% du TTC est taxé à 5.5%
                    End With
                    dt.Rows.Add(rwTVADetail)

                    rwTVADetail = dt.NewRow
                    With rwTVADetail
                        .Item("nTVA") = rwTVA.Item("nTVA")
                        .Item("TTVA") = 19.6
                        .Item("TTaux") = 19.6
                        .Item("TCoef") = 0.25D '25% du TTC est taxé à 19.6%
                    End With
                    dt.Rows.Add(rwTVADetail)
                Case Else
                    Dim rwTVADetail As DataRow = dt.NewRow
                    With rwTVADetail
                        .Item("nTVA") = rwTVA.Item("nTVA")
                        .Item("TTVA") = Convert.ToString(rwTVA.Item("TTVA"))
                        .Item("TTaux") = rwTVA.Item("TTaux")
                        .Item("TCoef") = 1
                    End With
                    dt.Rows.Add(rwTVADetail)
            End Select
        Next
    End Sub

    Public Sub ImprimerFacture(ByVal ds As DsAgrifact, ByVal dtParams As DsAgrifact.ParametresDataTable, ByVal apercu As Boolean)
        Dim oRpt As ReportDocument = EcranCrystal.ChargerReport("RptFactureVenteTTC.rpt", ds)
        AppliquerParametres(oRpt, dtParams)
        If apercu Then
            Using fr As New EcranCrystal(oRpt)
                fr.ShowDialog()
            End Using
        Else
            EcranCrystal.Imprimer(oRpt)
        End If
    End Sub

    Private Sub AppliquerParametres(ByVal oRpt As ReportDocument, ByVal dtParams As DsAgrifact.ParametresDataTable, Optional ByVal nomTable As String = "")
        If Not oRpt Is Nothing Then
            AppliquerParametres(oRpt, GetParams(dtParams, nomTable))
        End If
    End Sub

    Private Function GetParams(ByVal dtParams As DsAgrifact.ParametresDataTable, Optional ByVal nomTable As String = "") As Collections.Specialized.StringDictionary
        Dim dicParams As New Collections.Specialized.StringDictionary
        With dicParams
            .Add("TypePiece", "Facture")
            If GestionLogo(dtParams) Then
                .Add("LeftEnTete", "2400")
            Else
                .Add("LeftEnTete", "-1")
            End If
            .Add("EnTete", ValeurParamImpression(dtParams, "EnTete", nomTable, ""))
            .Add("EnTeteDetail", ValeurParamImpression(dtParams, "EnTeteDetail", nomTable, ""))
            .Add("PiedPageDetail", ValeurParamImpression(dtParams, "PiedPageDetail", nomTable, ""))
            .Add("InfoLegale", ValeurParamImpression(dtParams, "InfoLegale", nomTable, ""))
            .Add("InfoLegale2", ValeurParamImpression(dtParams, "InfoLegale2", nomTable, ""))
            If Boolean.Parse(ValeurParamImpression(dtParams, "ImprimerRIB", nomTable, "True")) Then
                .Add("CodeEtablissement", ValeurParamImpression(dtParams, "CodeEtablissement", nomTable, ""))
                .Add("CodeGuichet", ValeurParamImpression(dtParams, "CodeGuichet", nomTable, ""))
                .Add("NCompte", ValeurParamImpression(dtParams, "NCompte", nomTable, ""))
                .Add("CleRIB", ValeurParamImpression(dtParams, "CleRIB", nomTable, ""))
                .Add("Domiciliation", ValeurParamImpression(dtParams, "Domiciliation", nomTable, ""))
            Else
                .Add("CodeEtablissement", "")
                .Add("CodeGuichet", "")
                .Add("NCompte", "")
                .Add("CleRIB", "")
                .Add("Domiciliation", "")
            End If
            .Add("AdresseLeft", ValeurParamImpression(dtParams, "AdresseLeft", nomTable, "110"))
            .Add("AdresseTop", ValeurParamImpression(dtParams, "AdresseTop", nomTable, "50"))
        End With
        'For Each k As String In dicParams.Keys
        '    Debug.Print("{0}={1}", k, dicParams(k))
        'Next
        Return dicParams
    End Function

    Private Function GestionLogo(ByVal dtParams As DataTable) As Boolean
        If Not dtParams Is Nothing Then
            Dim rws() As DataRow = dtParams.Select("Cle='Logo'")
            If rws.Length > 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub AppliquerParametres(ByVal oRpt As ReportDocument, ByVal dicParams As Collections.Specialized.StringDictionary)
        'Gestion de la position de l'entete
        Dim LeftEnTete As Integer = CInt(dicParams("LeftEnTete"))
        If LeftEnTete <> -1 Then
            Try
                CType(oRpt.ReportDefinition.ReportObjects.Item("TxEnTete"), FieldObject).Left = LeftEnTete
                CType(oRpt.ReportDefinition.ReportObjects.Item("TxEnTeteDetail"), FieldObject).Left = LeftEnTete
            Catch
            End Try
        End If

        'Gestion de la position de l'adresse
        Dim posAdresse As New Point
        With posAdresse
            .X = CInt(dicParams("AdresseLeft"))
            .Y = CInt(dicParams("AdresseTop"))
        End With
        posAdresse = MillimetersToTwips(posAdresse)
        Try
            posAdresse.Y -= oRpt.ReportDefinition.Sections("Section2").Height
        Catch
        End Try

        Try
            With CType(oRpt.ReportDefinition.ReportObjects.Item("Text14"), TextObject)
                .Left = posAdresse.X
                .Top = posAdresse.Y
            End With
        Catch
        End Try


        ''Get the collection of parameters from the report
        For Each crParDef As ParameterFieldDefinition In oRpt.DataDefinition.ParameterFields
            Dim crParValue As ParameterDiscreteValue = New ParameterDiscreteValue
            Dim crValues As ParameterValues = crParDef.CurrentValues

            Select Case crParDef.Name
                Case Else
                    If dicParams.ContainsKey(crParDef.Name) Then
                        crParValue.Value = dicParams(crParDef.Name)
                    End If
            End Select

            Try
                ''Add the first current value for the parameter field
                If Not crParValue.Value Is Nothing Then
                    If crValues.Count = 0 Then
                        crValues.Add(crParValue)
                    End If
                    ''All current parameter values must be applied for the parameter field.
                    crParDef.ApplyCurrentValues(crValues)
                End If
            Catch
            End Try
        Next
    End Sub

    Private Function ValeurParamImpression(ByVal dtParams As DataTable, ByVal nomParam As String, ByVal nomTable As String, ByVal valeurDefaut As String) As String
        Dim res As String = valeurDefaut
        If Not dtParams Is Nothing Then
            Dim rws() As DataRow = dtParams.Select(String.Format("Cle='{0}' And (TypePiece is null Or TypePiece='{1}')", nomParam, nomTable), "TypePiece desc")
            If rws.Length > 0 Then
                res = Convert.ToString(rws(0).Item("Valeur"))
            End If
        End If
        Return res
    End Function
End Module

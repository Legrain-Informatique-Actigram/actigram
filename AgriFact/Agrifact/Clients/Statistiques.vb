Public Enum StatistiquesType
    Jour
    Semaine
    Mois
    Annee
    Tous
End Enum

Public Enum StatistiquesTypeMontant
    HT
    TTC
End Enum

Public Class Statistiques
    Public ds As DataSet
    Public nClient As String = ""
    Public CodeProduit As String = ""

    Public Overloads Function GetMontant(ByVal nomTable As String, ByVal Type As StatistiquesType, ByRef TypeMontant As StatistiquesTypeMontant) As Decimal
        Return GetMontant(nomTable, Type, TypeMontant, Now)
    End Function

    Public Overloads Function GetMontant(ByVal nomTable As String, ByVal Type As StatistiquesType, ByRef TypeMontant As StatistiquesTypeMontant, ByVal dt As Date) As Decimal
        Dim obj As Object
        Dim strComputeExpression As String = "Sum(MontantHT)"
        Select Case TypeMontant
            Case StatistiquesTypeMontant.HT
                strComputeExpression = "Sum(MontantHT)"
            Case StatistiquesTypeMontant.TTC
                strComputeExpression = "Sum(MontantTTC)"
        End Select

        Dim strSelectnClient As String = ""
        Dim strSelectExpression As String = ""
        Dim strChampsDate As String

        If dt > Date.MinValue And Type <> StatistiquesType.Tous Then
            Dim dateDebut, dateFin As Date

            If nomTable.IndexOf("_Detail") >= 0 Then
                strChampsDate = "Parent(" & nomTable.Replace("_Detail", "") & nomTable & ").DateFacture"
            Else
                strChampsDate = "DateFacture"
            End If

            Select Case Type
                Case StatistiquesType.Jour
                    dateDebut = dt
                    dateFin = dateDebut.AddDays(1)
                Case StatistiquesType.Semaine
                    dateDebut = dt
                    dateFin = dateDebut.AddDays(7)
                Case StatistiquesType.Mois
                    dateDebut = New Date(dt.Year, dt.Month, 1)
                    dateFin = dateDebut.AddMonths(1)
                Case StatistiquesType.Annee
                    dateDebut = New Date(dt.Year, 1, 1)
                    dateFin = dateDebut.AddYears(1)
            End Select
            strSelectExpression = String.Format("{0}>=#{1:MM/dd/yyyy}# And {0}<#{2:MM/dd/yyyy}#", strChampsDate, dateDebut, dateFin)
        End If

        Dim strSelectCodeProduit As String = ""
        If nClient.Length > 0 Then
            strSelectnClient = "nClient=" & nClient
            If strSelectExpression.Length > 0 Then
                strSelectExpression = "(" & strSelectExpression & ") And "
            End If
            strSelectExpression += strSelectnClient
        End If

        If CodeProduit.Length > 0 Then
            strSelectCodeProduit = "CodeProduit='" & CodeProduit.Replace("'", "''") & "'"
            If strSelectExpression.Length > 0 Then
                strSelectExpression = "(" & strSelectExpression & ") And "
            End If
            strSelectExpression += strSelectCodeProduit
        End If

        obj = ds.Tables(nomTable).Compute(strComputeExpression, strSelectExpression)

        Dim resultat As Decimal = 0
        If Not obj Is DBNull.Value Then
            resultat = Convert.ToDecimal(obj)
        End If

        If nClient = "" And CodeProduit = "" Then
            If nomTable = "VFacture" Then
                strComputeExpression = "Sum(MontantTotal)"
                strSelectExpression = strSelectExpression.Replace(strChampsDate, "dtTicket")
            End If

            obj = ds.Tables("Trame").Compute(strComputeExpression, strSelectExpression)
            If Not obj Is DBNull.Value Then
                resultat += Convert.ToDecimal(obj)
                obj = resultat
            End If
        End If

        If Not obj Is DBNull.Value Then
            Return Convert.ToDecimal(obj)
        Else
            Return 0
        End If
    End Function


    Public Overloads Function GetMontantPaye(ByVal nomTable As String, ByVal Type As StatistiquesType, ByVal TypeMontant As StatistiquesTypeMontant) As Decimal
        Return GetMontantPaye(nomTable, Type, TypeMontant, Now)
    End Function

    Public Overloads Function GetMontantPaye(ByVal nomTable As String, ByVal Type As StatistiquesType, ByVal TypeMontant As StatistiquesTypeMontant, ByVal dt As Date) As Decimal
        Dim obj As Object
        Dim strComputeExpression As String = "Sum(MontantHT)"
        Dim strSelectExpression As String = "Paye=True"

        Select Case TypeMontant
            Case StatistiquesTypeMontant.HT
                strComputeExpression = "Sum(MontantHT)"
            Case StatistiquesTypeMontant.TTC
                strComputeExpression = "Sum(MontantTTC)"
        End Select

        Dim strSelectnClient As String = ""

        If dt > Date.MinValue And Type <> StatistiquesType.Tous Then
            Dim strChampsDate As String
            Dim dateDebut, dateFin As Date

            If nomTable.IndexOf("_Detail") >= 0 Then
                strChampsDate = "Parent(" & nomTable.Replace("_Detail", "") & nomTable & ").DateFacture"
            Else
                strChampsDate = "DateFacture"
            End If

            Select Case Type
                Case StatistiquesType.Jour
                    dateDebut = dt
                    dateFin = dateDebut.AddDays(1)
                Case StatistiquesType.Semaine
                    dateDebut = dt
                    dateFin = dateDebut.AddDays(7)
                Case StatistiquesType.Mois
                    dateDebut = New Date(dt.Year, dt.Month, 1)
                    dateFin = dateDebut.AddMonths(1)
                Case StatistiquesType.Annee
                    dateDebut = New Date(dt.Year, 1, 1)
                    dateFin = dateDebut.AddYears(1)
            End Select
            strSelectExpression &= String.Format(" And {0}>=#{1:MM/dd/yyyy}# And {0}<#{2:MM/dd/yyyy}#", strChampsDate, dateDebut, dateFin)
        End If

        Dim strSelectCodeProduit As String = ""
        If nClient.Length > 0 Then
            strSelectnClient = "nClient=" & nClient
            If strSelectExpression.Length > 0 Then
                strSelectExpression = "(" & strSelectExpression & ") And "
            End If
            strSelectExpression += strSelectnClient
        End If

        If CodeProduit.Length > 0 Then
            strSelectCodeProduit = "CodeProduit='" & CodeProduit.Replace("'", "''") & "'"
            If strSelectExpression.Length > 0 Then
                strSelectExpression = "(" & strSelectExpression & ") And "
            End If
            strSelectExpression += strSelectCodeProduit
        End If

        obj = ds.Tables(nomTable).Compute(strComputeExpression, strSelectExpression)
        If Not obj Is DBNull.Value Then
            Return Convert.ToDecimal(obj)
        Else
            Return 0
        End If
    End Function

    Public Function GetMontantEcheanceHT(ByVal nomTable As String, ByVal Type As StatistiquesType, ByVal dt As Date) As Decimal
        Dim obj As Object
        Dim strComputeExpression As String = "Sum(MontantHT)"
        Dim strSelectExpression As String = ""
        Select Case Type
            Case StatistiquesType.Jour
                strSelectExpression = "DateEcheance=#" & dt.ToString("MM/dd/yyyy") & "#"
            Case StatistiquesType.Semaine
                strSelectExpression = "DateEcheance>=#" & dt.ToString("MM/dd/yyyy") & "# And DateEcheance<#" & dt.AddDays(7).ToString("MM/dd/yyyy") & "#"
            Case StatistiquesType.Mois
                strSelectExpression = "DateEcheance>=#" & dt.Month & "/01/" & dt.Year & "# And DateEcheance<#" & dt.AddMonths(1).Month & "/01/" & dt.AddMonths(1).Year & "#"
        End Select
        obj = ds.Tables(nomTable).Compute(strComputeExpression, strSelectExpression)
        If Not obj Is DBNull.Value Then
            Return Convert.ToDecimal(obj)
        Else
            Return 0
        End If
    End Function

    Public Function GetMontantEcheancePayeHT(ByVal nomTable As String, ByVal Type As StatistiquesType, ByVal dt As Date) As Decimal
        Dim obj As Object
        Dim strComputeExpression As String = "Sum(MontantHT)"
        Dim strSelectExpression As String = ""
        Select Case Type
            Case StatistiquesType.Jour
                strSelectExpression = "Paye=True And DateEcheance=#" & dt.ToString("MM/dd/yyyy") & "#"
            Case StatistiquesType.Semaine
                strSelectExpression = "Paye=True And DateEcheance>=#" & dt.ToString("MM/dd/yyyy") & "# And DateEcheance<#" & dt.AddDays(7).ToString("MM/dd/yyyy") & "#"
            Case StatistiquesType.Mois
                strSelectExpression = "Paye=True And DateEcheance>=#" & dt.Month & "/01/" & dt.Year & "# And DateEcheance<#" & dt.AddMonths(1).Month & "/01/" & dt.AddMonths(1).Year & "#"
        End Select
        obj = ds.Tables(nomTable).Compute(strComputeExpression, strSelectExpression)
        If Not obj Is DBNull.Value Then
            Return Convert.ToDecimal(obj)
        Else
            Return 0
        End If
    End Function

    Public Function GetNbClient(ByVal nomTable As String, ByVal Type As StatistiquesType, ByVal dt As Date) As Decimal
        Dim obj As Object
        Dim strComputeExpression As String = "Sum(MontantHT)"
        Dim strSelectExpression As String = ""
        Select Case Type
            Case StatistiquesType.Jour
                Dim Resultat As Decimal = 0
                obj = ds.Tables(nomTable).Compute("Count(nDevis)", "DateFacture=#" & dt.ToString("MM/dd/yyyy") & "#")
                If Not obj Is DBNull.Value Then
                    Resultat = Convert.ToDecimal(obj)
                End If
                If nomTable = "VFacture" Then
                    obj = ds.Tables("Trame").Compute("Count(nTicket)", "(TotalMontant Not Is Null) And  dtTicket=#" & dt.ToString("MM/dd/yyyy") & "# And BookingCancel=0")
                    If Not obj Is DBNull.Value Then
                        Resultat += Convert.ToDecimal(obj)
                    End If
                    obj = resultat
                End If
            Case StatistiquesType.Semaine
                Dim Resultat As Decimal = 0
                obj = ds.Tables(nomTable).Compute("Count(nDevis)", "DateFacture>=#" & dt.ToString("MM/dd/yyyy") & "# And DateFacture<#" & dt.AddDays(7).ToString("MM/dd/yyyy") & "#")
                If nomTable = "VFacture" Then
                    obj = ds.Tables("Trame").Compute("Count(nTicket)", "(TotalMontant Not Is Null) And  dtTicket>=#" & dt.ToString("MM/dd/yyyy") & "# And dtTicket<#" & dt.AddDays(7).ToString("MM/dd/yyyy") & "# And BookingCancel=0")
                    If Not obj Is DBNull.Value Then
                        Resultat += Convert.ToDecimal(obj)
                    End If
                    obj = resultat
                End If
            Case StatistiquesType.Mois
                Dim Resultat As Decimal = 0
                obj = ds.Tables(nomTable).Compute("Count(nDevis)", "DateFacture>=#" & dt.Month & "/01/" & dt.Year & "# And DateFacture<#" & dt.AddMonths(1).Month & "/01/" & dt.AddMonths(1).Year & "#")
                If nomTable = "VFacture" Then
                    obj = ds.Tables("Trame").Compute("Count(nTicket)", "(TotalMontant Not Is Null) And  dtTicket>=#" & dt.Month & "/01/" & dt.Year & "# And dtTicket<#" & dt.AddMonths(1).Month & "/01/" & dt.AddMonths(1).Year & "# And BookingCancel=0")
                    If Not obj Is DBNull.Value Then
                        Resultat += Convert.ToDecimal(obj)
                    End If
                    obj = resultat
                End If
        End Select
        If Not obj Is DBNull.Value Then
            Return Convert.ToDecimal(obj)
        Else
            Return 0
        End If
    End Function

End Class

Imports System.IO

Namespace Importations.CFONB
    Public Enum TypeLigne
        AncienSolde
        Mouvement
        NouveauSolde
    End Enum

    Public Class Releve

        Public CodeBanque As String
        Public CodeGuichet As String
        Public NoCompte As String

        Public MontantAncienSolde As Montant
        Public MontantNouveauSolde As Montant

        Public Lignes As New ArrayList

#Region "Méthodes partagées"
        Public Shared Function Parse(ByVal ligne As String) As Releve
            Dim res As New Releve
            With res
                .CodeBanque = Integer.Parse(ligne.Substring(2, 5)).ToString
                .CodeGuichet = Integer.Parse(ligne.Substring(11, 5)).ToString
                .NoCompte = ligne.Substring(21, 11).Trim
            End With
            Return res
        End Function
#End Region

    End Class

    Public Class Complement
        Public Qualifiant As String
        Public Informations As String

#Region "Méthodes partagées"
        Public Shared Function Parse(ByVal ligne As String) As Complement
            Dim res As New Complement
            With res
                .Qualifiant = ligne.Substring(45, 3).Trim
                .Informations = ligne.Substring(48, 70)
            End With
            Return res
        End Function
#End Region

    End Class

    Public Class Montant
        Public [Date] As Date
        Public Montant As Decimal
        Public CodeDevise As String
        Public NbDecimales As Integer

#Region "Méthodes partagées"
        Public Shared Function Parse(ByVal ligne As String) As Montant
            Dim res As New Montant
            With res
                .CodeDevise = ligne.Substring(16, 3).Trim
                If .CodeDevise <> "EUR" Then Throw New Exception(My.Resources.Strings.Etebac_VerifMonnaie)
                .NbDecimales = Integer.Parse(ligne.Substring(19, 1))
                .Date = Date.ParseExact(ligne.Substring(34, 6), Importateur.DATE_FORMAT, Nothing)
                .Montant = CDec(CalculMontant(ligne.Substring(90, 14), .NbDecimales))
            End With
            Return res
        End Function

        Private Shared Function CalculMontant(ByVal strMontant As String, ByVal NbDecimales As Integer) As Decimal
            Dim res As Decimal
            Dim signe As Integer = 1
            Dim dern As Char = strMontant.Chars(strMontant.Length - 1)
            Select Case Asc(dern)
                Case &H7B '{
                    signe = 1
                    dern = "0"c
                Case &H7D '}
                    signe = -1
                    dern = "0"c
                Case &H41 To &H49 'A-I
                    signe = 1
                    dern = Chr(Asc(dern) - &H10)
                Case &H4A To &H52 'J-R
                    signe = -1
                    dern = Chr(Asc(dern) - &H19)
            End Select
            strMontant = strMontant.Substring(0, strMontant.Length - 1) & dern
            res = CDec(signe * Integer.Parse(strMontant) / 10 ^ NbDecimales)
            Return res
        End Function
#End Region

    End Class

    Public Class LigneReleve

        Public CodeOperationInterne As String
        Public CodeOperationInterbancaire As String
        Public CodeMotifRejet As String

        Public DateValeur As Date
        Public Libelle As String

        Public NoEcriture As String
        Public Exonere As Boolean
        Public Indisponible As Boolean

        Public MontantMouvement As Montant

        Public Reference As String

        Public Complements As New ArrayList

#Region "Méthodes partagées"
        Public Shared Function Parse(ByVal ligne As String) As LigneReleve
            Dim res As New LigneReleve
            With res
                .MontantMouvement = Montant.Parse(ligne)
                .CodeOperationInterne = ligne.Substring(7, 4).Trim
                .CodeOperationInterbancaire = ligne.Substring(32, 2).Trim
                .CodeMotifRejet = Integer.Parse(ligne.Substring(40, 2)).ToString
                .DateValeur = Date.ParseExact(ligne.Substring(42, 6), Importateur.DATE_FORMAT, Nothing)
                .Libelle = ligne.Substring(48, 31).Trim
                .NoEcriture = Integer.Parse(ligne.Substring(31, 7)).ToString
                .Exonere = (ligne.Substring(88, 1) = "1")
                .Indisponible = (ligne.Substring(89, 1) = "1")
                .Reference = ligne.Substring(104, 16).Trim
            End With
            Return res
        End Function
#End Region

    End Class

    Public Class Importateur
        Public Const DATE_FORMAT As String = "ddMMyy"

#Region "Méthodes partagées"
        Public Shared Function Importer(ByVal NomFichier As String) As List(Of Releve)

            If Not File.Exists(NomFichier) Then Throw New FileNotFoundException(String.Format(My.Resources.Strings.FichierInexistant, NomFichier))

            Dim res As New List(Of Releve)

            Dim releve As Releve
            Dim comptLigne As Integer = 0
            Dim rapportErreur As New System.Text.StringBuilder

            Dim sr As New StreamReader(NomFichier)
            Try

                Dim ligne As String = sr.ReadLine
                While Not ligne Is Nothing
                    comptLigne += 1
                    If ligne.Trim.Length > 0 Then 'Ignorer les lignes vides
                        Try
                            'Vérifier la longueur de la ligne
                            If ligne.Length < 120 Then Throw New Exception(String.Format("Ligne de longueur incorrecte : '{0}'", ligne))
                            'Suivant l'entete de la ligne
                            Select Case ligne.Substring(0, 2)
                                Case "01" 'Ancien solde
                                    If releve Is Nothing Then
                                        releve = releve.Parse(ligne)
                                        releve.MontantAncienSolde = Montant.Parse(ligne)
                                        res.Add(releve)
                                    Else
                                        Throw New Exception("Ligne ""Nouveau Solde"" manquante")
                                    End If
                                Case "04" 'Mouvement
                                    If Not releve Is Nothing Then
                                        releve.Lignes.Add(LigneReleve.Parse(ligne))
                                    Else
                                        Throw New Exception("Ligne ""Ancien Solde"" manquante")
                                    End If
                                Case "05" 'Complément
                                    If Not releve Is Nothing Then
                                        If releve.Lignes.Count > 0 Then
                                            Dim dernLigne As LigneReleve = DirectCast(releve.Lignes(releve.Lignes.Count - 1), LigneReleve)
                                            dernLigne.Complements.Add(Complement.Parse(ligne))
                                        Else
                                            Throw New Exception("Ligne ""Mouvement"" manquante")
                                        End If
                                    Else
                                        Throw New Exception("Ligne ""Ancien Solde"" manquante")
                                    End If
                                Case "07" 'Nouveau solde
                                    If Not releve Is Nothing Then
                                        releve.MontantNouveauSolde = Montant.Parse(ligne)
                                        If Not VerifBalanceReleve(releve, rapportErreur) Then
                                            rapportErreur.AppendFormat("Les montants  inscrits dans le relevé ne correspondent pas." & vbCrLf & "Il est possible que le relevé soit incomplet." & vbCrLf & String.Format("Fichier '{0}', ligne {1}.", NomFichier, comptLigne) & vbCrLf)
                                        End If
                                        releve = Nothing
                                    Else
                                        Throw New Exception("Ligne ""Ancien Solde"" manquante")
                                    End If
                            End Select
                        Catch ex As FormatException
                            Throw New Exception(String.Format("Erreur de format dans la ligne : '{0}'", ligne), ex)
                        End Try
                    End If
                    ligne = sr.ReadLine
                End While
                If rapportErreur.ToString <> "" Then
                    MsgBox(rapportErreur.ToString, MsgBoxStyle.Critical, "Importation")
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message & vbCrLf & String.Format("Fichier '{0}', ligne {1}.", NomFichier, comptLigne), ex.InnerException)
            Finally
                sr.Close()
            End Try

            Return res
        End Function

        Private Shared Function VerifBalanceReleve(ByVal releve As Releve, ByVal rapportErreur As System.Text.StringBuilder) As Boolean
            Dim balance As Decimal
            balance = releve.MontantAncienSolde.Montant
            For Each l As LigneReleve In releve.Lignes
                balance += l.MontantMouvement.Montant
            Next
            If balance <> releve.MontantNouveauSolde.Montant Then
                Return False
                'Throw New Exception("Les montants  inscrits dans le relevé ne correspondent pas." & vbCrLf & "Il est possible que le relevé soit incomplet.")
            End If
            Return True
        End Function
#End Region

    End Class
End Namespace
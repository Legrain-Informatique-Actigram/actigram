Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class FrSupprDossier

    Public Dossier As DossierPrincipal

#Region "Page"
    Private Sub FrSupprDossier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetChildFormIcon(Me)
        If Me.Dossier IsNot Nothing Then
            Me.btSelectedEx.Text = String.Format(Me.btSelectedEx.Text, Dossier.Identity.Name)
            Me.btTousExercices.Text = String.Format(Me.btTousExercices.Text, Dossier.CodeExpl)
        Else
            Me.btTousExercices.Visible = False
            Me.btSelectedEx.Visible = False
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub cmdSupprAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTousExercices.Click
        With Dossier
            If MsgBox(String.Format(My.Resources.Strings.Expl_AskSuppression, Dossier.CodeExpl), MsgBoxStyle.YesNo, My.Resources.Strings.SuppressionDeDossier) = MsgBoxResult.Yes Then
                If SuppressionExploitation(Dossier.CodeExpl) Then MsgBox(My.Resources.Strings.Expl_ExploitationSupprimee, MsgBoxStyle.Information, My.Resources.Strings.SuppressionDExploitation)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End With
    End Sub

    Private Sub cmdSupprOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSelectedEx.Click
        With Dossier
            If MsgBox(String.Format(My.Resources.Strings.Dossier_AskSuppression, Dossier.Identity.Name), MsgBoxStyle.YesNo, My.Resources.Strings.SuppressionDeDossier) = MsgBoxResult.Yes Then
                SuppressionDossier(Dossier.Identity.Name)
                Using dtaDossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                    If CInt(dtaDossier.ExistsDossierByExpl(Dossier.CodeExpl)) = 0 Then
                        SuppressionExploitation(Dossier.CodeExpl)
                    End If
                End Using
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End With
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function SuppressionExploitation(ByVal sExploitation As String) As Boolean
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim t As OleDb.OleDbTransaction
            Try
                conn.Open()
                t = conn.BeginTransaction
                Using dtaExploitation As New dbDonneesDataSetTableAdapters.ExploitationsTableAdapter
                    dtaExploitation.SetTransaction(t)
                    If dtaExploitation.ExistExploitation(sExploitation).GetValueOrDefault > 0 Then
                        Using dtadossier As New dbDonneesDataSetTableAdapters.DossiersTableAdapter
                            Dim ds As New dbDonneesDataSet
                            dtadossier.FillByExpl(ds.Dossiers, sExploitation)
                            For Each xrow As dbDonneesDataSet.DossiersRow In ds.Dossiers.Rows
                                SuppressionDossier(xrow.DDossier, t)
                            Next
                        End Using
                        SupprimerLignes("EmpruntLignes", "EMPLExpl", sExploitation, t)
                        SupprimerLignes("EmpruntGroupes", "EMPGExpl", sExploitation, t)
                        SupprimerLignes("ModMouvements", "ModMExpl", sExploitation, t)
                        SupprimerLignes("ModLignes", "ModLExpl", sExploitation, t)
                        SupprimerLignes("Exploitations", "EExpl", sExploitation, t)
                        t.Commit()
                        t = Nothing
                        Exploitation.Enlever(sExploitation)
                    Else
                        If t IsNot Nothing Then t.Rollback()
                        conn.Close()
                        Dim msg As String = String.Format(My.Resources.Strings.Expl_ExplIntrouvable, sExploitation)
                        MsgBox(msg, MsgBoxStyle.Exclamation, My.Resources.Strings.SuppressionDeDossier)
                        Throw New ApplicationException(msg)
                    End If
                End Using
            Catch ex As Exception
                If Not t Is Nothing Then t.Rollback()
                LogException(ex)
                Throw ex
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Using
    End Function

    Private Sub SuppressionDossier(ByVal sDossier As String, ByVal t As OleDb.OleDbTransaction)
        SupprimerLignes("InventaireLignes", "INVLDossier", sDossier, t)
        SupprimerLignes("InventaireGroupes", "INVGDossier", sDossier, t)
        SupprimerLignes("Immobilisations", "IDossier", sDossier, t)
        SupprimerLignes("Immobilisations", "IDossier", sDossier, t)
        SupprimerLignes("Mouvements", "MDossier", sDossier, t)
        SupprimerLignes("Lignes", "LDossier", sDossier, t)
        SupprimerLignes("Pieces", "PDossier", sDossier, t)
        SupprimerLignes("PlanComptable", "PlDossier", sDossier, t)
        SupprimerLignes("Activites", "ADossier", sDossier, t)
        SupprimerLignes("Comptes", "CDossier", sDossier, t)
        SupprimerLignes("Dossiers", "DDossier", sDossier, t)

        'Suppression des informations liées à la clôture
        'Suppression de la date d'arrêté du dossier precedent
        Dim dossierPrecedent As String = Me.CodeDossierPrecedent(sDossier)
        Dim queryString As String = String.Empty

        queryString = "UPDATE Dossiers SET DDtArrete = NULL " & _
                        "WHERE DDossier='" & Replace(dossierPrecedent, "'", "''") & "'"

        Dim oleDbComm As New OleDbCommand(queryString, t.Connection)

        oleDbComm.Transaction = t

        oleDbComm.ExecuteNonQuery()

        'Suppression des MIdANouveauSuivant de la table Mouvements du dossier précédent
        queryString = "UPDATE Mouvements SET MIdANouveauSuiv = NULL " & _
                        "WHERE Mouvements.MDossier='" & Replace(dossierPrecedent, "'", "''") & "'"

        oleDbComm.CommandText = queryString

        oleDbComm.ExecuteNonQuery()
    End Sub

    Private Function CodeDossierPrecedent(ByVal codeDossier As String) As String
        Dim oleDbSelect As String = String.Empty
        Dim codeDossierPrec As String = String.Empty

        oleDbSelect = "SELECT TOP 1 DDossier " & _
                        "FROM Dossiers " & _
                        "WHERE DDtFinEx = " & _
                        "(SELECT Max(Dossiers.DDtFinEx) AS MAXDATEFIN " & _
                        "FROM Dossiers " & _
                        "WHERE Dossiers.DDtFinEx <= " & _
                        "(SELECT Dossiers.DDtDebEx " & _
                        "FROM Dossiers " & _
                        "WHERE Dossiers.DDossier='" & Replace(codeDossier, "'", "''") & "'))"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(oleDbSelect, oleDbConnection)

            oleDbConnection.Open()

            If Not (IsDBNull(oleDbCommand.ExecuteScalar())) Then
                codeDossierPrec = Convert.ToString(oleDbCommand.ExecuteScalar())
            End If
        End Using

        Return codeDossierPrec
    End Function

    Private Sub SuppressionDossier(ByVal sDossier As String)
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim t As OleDb.OleDbTransaction
            Cursor.Current = Cursors.WaitCursor
            Try
                conn.Open()
                t = conn.BeginTransaction
                SuppressionDossier(sDossier, t)
                t.Commit()
                t = Nothing
            Catch ex As Exception
                If t IsNot Nothing Then t.Rollback()
                LogException(ex)
                Throw ex
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Using
    End Sub
#End Region

End Class

Public Class FrImportModeles

    Private Enum ModeleAction
        ToutEffacer
        MajExistant
        AjouterEtEcraser
        AjouterNouveau
        Script
    End Enum

#Region "Page"
    Private Sub FrImportModeles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        With CbAction.Items
            .Clear()
            .Add(New ListboxItem("Effacer l'existant avant d'importer", ModeleAction.ToutEffacer))
            .Add(New ListboxItem("Ne mettre à jour que les contrôles existants", ModeleAction.MajExistant))
            .Add(New ListboxItem("Mettre à jour les contrôles existants et ajouter les nouveaux", ModeleAction.AjouterEtEcraser))
            .Add(New ListboxItem("Seulement ajouter les nouveaux contrôles", ModeleAction.AjouterNouveau))
            .Add(New ListboxItem("Générer un script", ModeleAction.Script))
        End With
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try
            Dim action As ModeleAction = Cast(Of ModeleAction)(Cast(Of ListboxItem)(Me.CbAction.SelectedItem).Value)
            If action = ModeleAction.Script Then
                Dim cheminScript As String
                Using dlg As New SaveFileDialog()
                    With dlg
                        .DefaultExt = ".sql"
                        .Title = "Veuillez sélectionner l'emplacement du script"
                        .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                        .FileName = "ImportModelesControles.sql"
                        If .ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                        cheminScript = .FileName
                    End With
                End Using
                ImporterScript(Me.CheminFichierTextBox.Text.Trim, cheminScript, CInt(nudSkip.Value))
            Else
                ImporterBase(Me.CheminFichierTextBox.Text.Trim, action, CInt(nudSkip.Value))
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtBrowseFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowseFile.Click
        Using dlg As New OpenFileDialog
            dlg.Title = "Sélectionnez le fichier à importer"
            dlg.Filter = "Fichier texte (*.txt;*.csv)|*.txt;*.csv|Tous les fichiers|*.*"
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.CheminFichierTextBox.Text = dlg.FileName
            End If
        End Using
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function LireFichier(ByVal chemin As String, Optional ByVal nbSkip As Integer = 0) As List(Of LigneImportModele)
        If Not IO.File.Exists(chemin) Then Throw New IO.FileNotFoundException("Fichier introuvable", chemin)
        Dim lines As New List(Of LigneImportModele)
        Using tfp As New FileIO.TextFieldParser(chemin, System.Text.Encoding.Default, True)
            tfp.Delimiters = New String() {";"}
            tfp.HasFieldsEnclosedInQuotes = True
            tfp.TrimWhiteSpace = True
            For i As Integer = 0 To nbSkip - 1
                tfp.ReadLine()
            Next
            While Not tfp.EndOfData
                lines.Add(New LigneImportModele(tfp.ReadFields))
            End While
        End Using
        Return lines
    End Function

    Private Sub ImporterScript(ByVal chemin As String, ByVal cheminScript As String, Optional ByVal nbSkip As Integer = 0)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim lines As List(Of LigneImportModele) = LireFichier(chemin, nbSkip)

            Dim sb As New System.Text.StringBuilder
            For Each line As LigneImportModele In lines
                sb.AppendLine(line.GetInsertSql)
                sb.AppendLine("GO")
            Next
            My.Computer.FileSystem.WriteAllText(cheminScript, sb.ToString, False)
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ImporterBase(ByVal chemin As String, ByVal action As ModeleAction, Optional ByVal nbSkip As Integer = 0)
        Dim i As Integer = 1 + nbSkip

        Cursor.Current = Cursors.WaitCursor

        Try
            Dim lines As List(Of LigneImportModele) = LireFichier(chemin, nbSkip)

            Using proxy As New SqlProxy()
                proxy.ExecuteNonQuery("BEGIN TRANSACTION")

                Try
                    Using dtaD As New AgrifactTracaDataSetTableAdapters.ModeleDefinitionControleTableAdapter
                        dtaD.Connection = proxy.Connection

                        Using dtaB As New AgrifactTracaDataSetTableAdapters.ModeleBaremeTableAdapter
                            dtaB.Connection = proxy.Connection

                            If action = ModeleAction.ToutEffacer Then
                                dtaB.DeleteAll()
                                dtaD.DeleteAll()
                            End If

                            For Each line As LigneImportModele In lines
                                If (Me.LigneEstValide(line)) Then
                                    Dim nModele As Nullable(Of Integer) = dtaD.GetIdByCritereAndIdControle(line.Critere, line.ValeurCritere, line.IdControle)

                                    If Not nModele.HasValue Then
                                        If action <> ModeleAction.MajExistant Then
                                            dtaD.Insert(line.Critere, line.ValeurCritere, line.Groupe, line.Libelle, line.Type, line.ValeursPossibles, line.ValeursDefaut, line.Ordre, line.MatPrem, line.IdControle)
                                            nModele = proxy.ExecuteScalarInt("SELECT @@Identity as ID")

                                            If (line.Expression.Length > 0) Then
                                                dtaB.Insert(nModele.Value, line.Expression, False, line.pdf, line.ActionCo)
                                            End If
                                        End If
                                    Else
                                        If action <> ModeleAction.AjouterNouveau Then
                                            dtaB.DeleteByNModeleControle(nModele.Value)
                                            dtaD.Update(line.Critere, line.ValeurCritere, line.Groupe, line.Libelle, line.Type, line.ValeursPossibles, line.ValeursDefaut, line.Ordre, line.MatPrem, line.IdControle, nModele.Value, nModele.Value)

                                            If line.Expression.Length > 0 Then
                                                dtaB.Insert(nModele.Value, line.Expression, False, line.pdf, line.ActionCo)
                                            End If
                                        End If
                                    End If
                                Else
                                    Throw New Exception("Import annulé. Le format de la ligne " & i & " du fichier est incorrect.")
                                End If

                                i += 1
                            Next
                        End Using
                    End Using

                    proxy.ExecuteNonQuery("COMMIT TRANSACTION")
                Catch ex As Exception
                    proxy.ExecuteNonQuery("ROLLBACK TRANSACTION")

                    Throw ex
                End Try
            End Using
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function LigneEstValide(ByVal line As LigneImportModele) As Boolean
        If (line.Critere Is Nothing) Or (line.ValeurCritere Is Nothing) Or (line.Expression Is Nothing) Then
            Return False
        End If

        If Not (IsNumeric(line.IdControle)) Then
            Return False
        End If

        Return True
    End Function
#End Region

    Private Class LigneImportModele

        Public MatPrem As Boolean
        Public Critere As String
        Public ValeurCritere As String
        Public IdControle As Integer
        Public Ordre As Integer
        Public Groupe As String
        Public Libelle As String
        Public Type As String
        Public ValeursPossibles As String
        Public ValeursDefaut As String
        Public Expression As String
        Public ActionCo As String
        Public pdf As String

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal fields() As String)
            Me.New()
            Me.MatPrem = (fields(0) = "1")
            Me.Critere = fields(1)
            Me.ValeurCritere = fields(2)
            Me.IdControle = CInt(fields(3))
            Me.Ordre = CInt(fields(4))
            Me.Groupe = fields(5)
            Me.Libelle = fields(6)
            Me.Type = fields(7)
            Me.ValeursPossibles = fields(8)
            If fields.Length > 9 Then Me.ValeursDefaut = fields(9)
            If fields.Length > 10 Then Me.Expression = fields(10)
            If fields.Length > 11 Then Me.ActionCo = fields(11)
            If fields.Length > 12 Then Me.pdf = fields(12)
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetInsertSql() As String
            Dim sql As String
            sql = SqlProxy.FormatSql("INSERT INTO [ModeleDefinitionControle]([MatPrem], [TypeCritere], [Critere], [IdControle], [Ordre], [Groupe], [Libelle], [Type], [ValeursPossibles], [ValeursDefaut]) " & _
                                    "VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8},{9});", Me.MatPrem, Me.Critere, Me.ValeurCritere, Me.IdControle, Me.Ordre, Me.Groupe, Me.Libelle, Me.Type, Me.ValeursPossibles, Me.ValeursDefaut)
            If Me.Expression.Length > 0 Then
                sql &= SqlProxy.FormatSql(vbCrLf & "INSERT INTO [ModeleBareme]([nModeleControle], [Expression], [ActionCorrective], [CheminDoc], [ResultatConformite]) " & _
                                        "VALUES (@@IDENTITY,{0},{1},{2},{3});", Me.Expression, Me.ActionCo, Me.pdf, False)
            End If
            Return sql
        End Function
#End Region

    End Class

End Class
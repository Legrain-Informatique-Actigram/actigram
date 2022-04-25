Public Class FrGererBaremeForfaitaire

#Region "Form"
    Private Sub FrGererBaremeForfaitaire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ConstruireTitre()

        Me.FACON_CULTURALETableAdapter.Fill(Me.DataSetBaremes.FACON_CULTURALE)

        Me.FACON_CULTURALEBindingSource.Sort = "LIBELLE_FACON_CULTURALE ASC"
    End Sub

    Private Sub FrGererBaremeForfaitaire_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.Defiltrer()
    End Sub

    Private Sub FrGererBaremeForfaitaire_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "BAREME_FORFAITAIREBindingNavigator"
    Private Sub AjouterToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterToolStripButton.Click
        If Not (String.IsNullOrEmpty(Me.ANNEE_BAREME_FORFAITAIRETextBox.Text)) Then
            Dim bareme_ForfaitaireDR As DataSetBaremes.BAREME_FORFAITAIRERow = CType(Me.DataSetBaremes.BAREME_FORFAITAIRE.NewRow, AgrigestEDI.DataSetBaremes.BAREME_FORFAITAIRERow)

            bareme_ForfaitaireDR.ANNEE_BAREME_FORFAITAIRE = Me.ANNEE_BAREME_FORFAITAIRETextBox.Text

            Me.DataSetBaremes.BAREME_FORFAITAIRE.AddBAREME_FORFAITAIRERow(bareme_ForfaitaireDR)

            Me.BAREME_FORFAITAIREBindingSource.MoveLast()
        Else
            MsgBox("Ajout impossible. Aucune année n'est définie dans la zone de texte.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub EnregistrerToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerToolStripButton.Click
        Me.Enregistrer()
    End Sub

    Private Sub SupprimerToolStripButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        Dim listeLignesSelectionnees As List(Of DataSetBaremes.BAREME_FORFAITAIRERow) = Me.RecupererLignesSelectionnees()

        If (listeLignesSelectionnees.Count > 0) Then
            If (MsgBox("Confirmez-vous la suppression ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                Me.SupprimerListeBaremesForfaitaires(listeLignesSelectionnees)
            End If
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub FiltrerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltrerButton.Click
        Me.Enregistrer()

        Me.ChargerDonnees()
    End Sub

    Private Sub ImporterBaremeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImporterBaremeButton.Click
        Me.ImporterBaremeForfaitaire()
    End Sub
#End Region

#Region "BAREME_FORFAITAIREDataGridView"
    Private Sub BAREME_FORFAITAIREDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles BAREME_FORFAITAIREDataGridView.DataError

    End Sub

    Private Sub BAREME_FORFAITAIREDataGridView_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles BAREME_FORFAITAIREDataGridView.CellValidating
        If Not (Me.BAREME_FORFAITAIREDataGridView.Rows(e.RowIndex).IsNewRow) Then
            'Contrôles sur les colonnes ayant un type Nullable(Of Decimal) ou Nullable(Of Integer)
            If (Me.BAREME_FORFAITAIREDataGridView.Columns(e.ColumnIndex).ValueType Is GetType(Nullable(Of Decimal))) Or _
            (Me.BAREME_FORFAITAIREDataGridView.Columns(e.ColumnIndex).ValueType Is GetType(Nullable(Of Integer))) Then
                If String.IsNullOrEmpty(CStr(e.FormattedValue)) Then
                    Me.BAREME_FORFAITAIREDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub BAREME_FORFAITAIREDataGridView_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles BAREME_FORFAITAIREDataGridView.EditingControlShowing
        Dim voControl As DataGridViewTextBoxEditingControl = Nothing

        If (TypeOf (e.Control) Is DataGridViewTextBoxEditingControl) Then
            'On récupère le control TextBox de la cellule qui est édité        
            voControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'Contrôle sur les colonnes de type Nullable(Of Decimal)
            If (Me.BAREME_FORFAITAIREDataGridView.Columns(BAREME_FORFAITAIREDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Decimal)) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            End If

            'Contrôle sur les colonnes de type Nullable(Of Integer)
            If (Me.BAREME_FORFAITAIREDataGridView.Columns(BAREME_FORFAITAIREDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Integer)) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            End If
        End If
    End Sub
#End Region

#Region "ANNEE_BAREME_FORFAITAIRETextBox"
    Private Sub ANNEE_BAREME_FORFAITAIRETextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ANNEE_BAREME_FORFAITAIRETextBox.KeyPress
        'On accepte que les caractères numériques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ConstruireTitre()
        Me.Text = "Gérer les barèmes forfaitaires - " & GetDataSource(My.Settings.BaremesConnectionString)
    End Sub

    Private Sub Defiltrer()
        Me.ANNEE_BAREME_FORFAITAIRETextBox.Text = Now.Year.ToString()

        Me.ChargerDonnees()
    End Sub

    Private Sub ChargerDonnees()
        If Not (String.IsNullOrEmpty(Me.ANNEE_BAREME_FORFAITAIRETextBox.Text)) Then
            Me.BAREME_FORFAITAIRETableAdapter.FillByANNEE_BAREME_FORFAITAIRE(Me.DataSetBaremes.BAREME_FORFAITAIRE, Me.ANNEE_BAREME_FORFAITAIRETextBox.Text)
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        Me.BAREME_FORFAITAIREBindingSource.EndEdit()

        Me.BAREME_FORFAITAIRETableAdapter.Update(Me.DataSetBaremes.BAREME_FORFAITAIRE)

        Return True
    End Function

    Private Function RecupererLignesSelectionnees() As List(Of DataSetBaremes.BAREME_FORFAITAIRERow)
        Dim listeLignesSelectionnees As New List(Of DataSetBaremes.BAREME_FORFAITAIRERow)

        For Each dgvr As DataGridViewRow In Me.BAREME_FORFAITAIREDataGridView.SelectedRows
            If dgvr.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf dgvr.DataBoundItem Is DataRowView Then Continue For

            Dim bareme_ForfaitaireDR As DataSetBaremes.BAREME_FORFAITAIRERow = DirectCast(DirectCast(dgvr.DataBoundItem, DataRowView).Row, DataSetBaremes.BAREME_FORFAITAIRERow)

            listeLignesSelectionnees.Add(bareme_ForfaitaireDR)
        Next

        Return listeLignesSelectionnees
    End Function

    Private Sub SupprimerListeBaremesForfaitaires(ByVal listeLignesSelectionnees As List(Of DataSetBaremes.BAREME_FORFAITAIRERow))
        For Each bareme_ForfaitaireDR As DataSetBaremes.BAREME_FORFAITAIRERow In listeLignesSelectionnees
            bareme_ForfaitaireDR.Delete()
        Next

        'Mise à jour de la base de données
        Me.Enregistrer()
    End Sub

    Private Sub ImporterBaremeForfaitaire()
        Dim fr As New FrChoixAnneeBaremeAImporter()
        Dim annee As String = String.Empty

        With fr
            .ShowDialog()

            If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                annee = fr.TextBoxAnneeBaremeAImporter.Text

                If Not (String.IsNullOrEmpty(annee)) Then
                    Dim gestBareme_Forfaitaire As New Baremes.ClassesControleur.GestionnaireBareme_Forfaitaire(My.Settings.BaremesConnectionString)
                    Dim nbEnreg As Integer = 0

                    nbEnreg = gestBareme_Forfaitaire.CopierListeBaremes_Forfaitaire(annee, Me.ANNEE_BAREME_FORFAITAIRETextBox.Text, Me.DataSetBaremes)

                    Me.Enregistrer()

                    Me.ChargerDonnees()

                    MsgBox("Traitement terminé. " & nbEnreg.ToString() & " lignes importées.", MsgBoxStyle.Information, "")
                End If
            End If
        End With
    End Sub

    Private Sub EditingControlDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caractères numériques, le point, ou la virgule        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ",")

        'On récupère le texte du TextBox 
        Dim txt As String = CType(sender, DataGridViewTextBoxEditingControl).Text

        'On s'assure que le point ou la virgule n'a été tapé qu'une fois 
        If (InStr(txt, ".") > 0 Or InStr(txt, ",") > 0) And (e.KeyChar = "." Or e.KeyChar = ",") Then
            e.KeyChar = Nothing
        Else
            'On remplace le point par une virgule ou la virgule par un point en fonction du séparateur décimal utilisé dans la culture en cours 
            Dim vsDecimalSeparator As Char

            vsDecimalSeparator = CChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)

            If vsDecimalSeparator <> "." And e.KeyChar = "." Then
                e.KeyChar = vsDecimalSeparator
            End If
        End If
    End Sub

    Private Sub EditingControlInteger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caractères numériques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub
#End Region

End Class
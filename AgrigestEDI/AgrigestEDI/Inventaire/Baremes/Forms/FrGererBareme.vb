Public Class FrGererBareme

#Region "Form"
    Private Sub FrGererBaremes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ConstruireTitre()

        Me.MATERIELTableAdapter.Fill(Me.DataSetBaremes.MATERIEL)

        Me.MATERIELBindingSource.Sort = "LIBELLE_MATERIEL ASC"
    End Sub

    Private Sub FrGererBaremes_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.Defiltrer()
    End Sub

    Private Sub FrGererBaremes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "BAREMEBindingNavigator"
    Private Sub AjouterToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterToolStripButton.Click
        If Not (String.IsNullOrEmpty(Me.ANNEE_BAREMETextBox.Text)) Then
            Dim baremeDR As DataSetBaremes.BAREMERow = CType(Me.DataSetBaremes.BAREME.NewRow, AgrigestEDI.DataSetBaremes.BAREMERow)

            baremeDR.ANNEE_BAREME = Me.ANNEE_BAREMETextBox.Text

            Me.DataSetBaremes.BAREME.AddBAREMERow(baremeDR)

            Me.BAREMEBindingSource.MoveLast()
        Else
            MsgBox("Ajout impossible. Aucune année n'est définie dans la zone de texte.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub EnregistrerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerToolStripButton.Click
        Me.Enregistrer()
    End Sub

    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        Dim listeLignesSelectionnees As List(Of DataSetBaremes.BAREMERow) = Me.RecupererLignesSelectionnees()

        If (listeLignesSelectionnees.Count > 0) Then
            If (MsgBox("Confirmez-vous la suppression ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                Me.SupprimerListeBaremes(listeLignesSelectionnees)
            End If
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub FiltrerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltrerButton.Click
        Me.ChargerDonnees()
    End Sub

    Private Sub ImporterBaremesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImporterBaremeButton.Click
        Me.ImporterBareme()
    End Sub
#End Region

#Region "BAREMEDataGridView"
    Private Sub BAREMEDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles BAREMEDataGridView.DataError

    End Sub

    Private Sub BAREMEDataGridView_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles BAREMEDataGridView.CellValidating
        If Not (Me.BAREMEDataGridView.Rows(e.RowIndex).IsNewRow) Then
            'Contrôles sur les colonnes ayant un type Nullable(Of Decimal) ou Nullable(Of Integer)
            If (Me.BAREMEDataGridView.Columns(e.ColumnIndex).ValueType Is GetType(Nullable(Of Decimal))) Or _
            (Me.BAREMEDataGridView.Columns(e.ColumnIndex).ValueType Is GetType(Nullable(Of Integer))) Then
                If String.IsNullOrEmpty(CStr(e.FormattedValue)) Then
                    Me.BAREMEDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub BAREMEDataGridView_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles BAREMEDataGridView.EditingControlShowing
        Dim voControl As DataGridViewTextBoxEditingControl = Nothing

        If (TypeOf (e.Control) Is DataGridViewTextBoxEditingControl) Then
            'On récupère le control TextBox de la cellule qui est édité        
            voControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'Contrôle sur les colonnes de type Nullable(Of Decimal)
            If (Me.BAREMEDataGridView.Columns(BAREMEDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Decimal)) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            End If

            'Contrôle sur les colonnes de type Nullable(Of Integer)
            If (Me.BAREMEDataGridView.Columns(BAREMEDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Integer)) Then
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

#Region "ANNEE_BAREMETextBox"
    Private Sub ANNEE_BAREMETextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ANNEE_BAREMETextBox.KeyPress
        'On accepte que les caractères numériques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub Defiltrer()
        Me.ANNEE_BAREMETextBox.Text = Now.Year.ToString()

        Me.ChargerDonnees()
    End Sub

    Private Sub ChargerDonnees()
        If Not (String.IsNullOrEmpty(Me.ANNEE_BAREMETextBox.Text)) Then
            Me.BAREMETableAdapter.FillByANNEE_BAREME(Me.DataSetBaremes.BAREME, Me.ANNEE_BAREMETextBox.Text)
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        Me.BAREMEBindingSource.EndEdit()

        Me.BAREMETableAdapter.Update(Me.DataSetBaremes.BAREME)

        Return True
    End Function

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

    Private Sub ImporterBareme()
        Dim fr As New FrChoixAnneeBaremeAImporter()
        Dim annee As String = String.Empty

        With fr
            .ShowDialog()

            If (.DialogResult = Windows.Forms.DialogResult.OK) Then
                annee = fr.TextBoxAnneeBaremeAImporter.Text

                If Not (String.IsNullOrEmpty(annee)) Then
                    Dim gestBareme As New Baremes.ClassesControleur.GestionnaireBareme(My.Settings.BaremesConnectionString)
                    Dim nbEnreg As Integer = 0

                    nbEnreg = gestBareme.CopierListeBaremes(annee, Me.ANNEE_BAREMETextBox.Text, Me.DataSetBaremes)

                    Me.Enregistrer()

                    Me.ChargerDonnees()

                    MsgBox("Traitement terminé. " & nbEnreg.ToString() & " lignes importées.", MsgBoxStyle.Information, "")
                End If
            End If
        End With
    End Sub

    Private Function RecupererLignesSelectionnees() As List(Of DataSetBaremes.BAREMERow)
        Dim listeLignesSelectionnees As New List(Of DataSetBaremes.BAREMERow)

        For Each dgvr As DataGridViewRow In Me.BAREMEDataGridView.SelectedRows
            If dgvr.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf dgvr.DataBoundItem Is DataRowView Then Continue For

            Dim baremeDR As DataSetBaremes.BAREMERow = DirectCast(DirectCast(dgvr.DataBoundItem, DataRowView).Row, DataSetBaremes.BAREMERow)

            listeLignesSelectionnees.Add(baremeDR)
        Next

        Return listeLignesSelectionnees
    End Function

    Private Sub SupprimerListeBaremes(ByVal listeLignesSelectionnees As List(Of DataSetBaremes.BAREMERow))
        For Each baremeDR As DataSetBaremes.BAREMERow In listeLignesSelectionnees
            baremeDR.Delete()
        Next

        'Mise à jour de la base de données
        Me.Enregistrer()
    End Sub

    Private Sub ConstruireTitre()
        Me.Text = "Gérer les barèmes - " & GetDataSource(My.Settings.BaremesConnectionString)
    End Sub
#End Region

End Class
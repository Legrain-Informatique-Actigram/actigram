Public Class RappBancaireRechAv

    Private _filtre As String
    Private _listeCriteresFiltre As RapprochementBancaire.ListeCriteresFiltre

#Region "Constructeurs"
    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._filtre = String.Empty
        Me._listeCriteresFiltre = New RapprochementBancaire.ListeCriteresFiltre()
    End Sub
#End Region

#Region "Propriété"
    Public ReadOnly Property Filtre() As String
        Get
            Return Me._filtre
        End Get
    End Property

    Public ReadOnly Property ListeCritereFiltre() As RapprochementBancaire.ListeCriteresFiltre
        Get
            Return Me._listeCriteresFiltre
        End Get
    End Property
#End Region

#Region "Form"
    Private Sub RappBancaireRechAv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.InitialiserForm()
    End Sub
#End Region

#Region "CheckBox"
    Private Sub checkBoxDateEcr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxDateEcr.CheckedChanged
        If (Me.checkBoxDateEcr.Checked) Then
            Me.dateTimePickerDateDebEcr.Enabled = True
            Me.dateTimePickerDateFinEcr.Enabled = True
        Else
            Me.dateTimePickerDateDebEcr.Enabled = False
            Me.dateTimePickerDateFinEcr.Enabled = False
        End If
    End Sub

    Private Sub checkBoxMontant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxMontant.CheckedChanged
        If (Me.checkBoxMontant.Checked) Then
            Me.checkBoxMontantD.Enabled = True
            Me.checkBoxMontantC.Enabled = True
        Else
            Me.checkBoxMontantD.Checked = False
            Me.checkBoxMontantD.Enabled = False
            Me.checkBoxMontantC.Checked = False
            Me.checkBoxMontantC.Enabled = False
            DesactiverTextBoxMontants()
            Me.textBoxMontantDeb.Text = ""
            Me.textBoxMontantFin.Text = ""
        End If
    End Sub

    Private Sub checkBoxMontantD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxMontantD.CheckedChanged
        If (Me.checkBoxMontantD.Checked) Then
            Me.checkBoxMontantC.Checked = False
            ActiverTextBoxMontants()
        Else
            DesactiverTextBoxMontants()

            If Not (Me.checkBoxMontantC.Checked) Then
                Me.textBoxMontantDeb.Text = ""
                Me.textBoxMontantFin.Text = ""
            End If
        End If
    End Sub

    Private Sub checkBoxMontantC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxMontantC.CheckedChanged
        If (Me.checkBoxMontantC.Checked) Then
            Me.checkBoxMontantD.Checked = False
            ActiverTextBoxMontants()
        Else
            DesactiverTextBoxMontants()

            If Not (Me.checkBoxMontantD.Checked) Then
                Me.textBoxMontantDeb.Text = ""
                Me.textBoxMontantFin.Text = ""
            End If
        End If
    End Sub

    Private Sub checkBoxNumPiece_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxNumPiece.CheckedChanged
        If (Me.checkBoxNumPiece.Checked) Then
            Me.textBoxNumPiece.Enabled = True
        Else
            Me.textBoxNumPiece.Enabled = False
        End If
    End Sub

    Private Sub checkBoxLibelle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkBoxLibelle.CheckedChanged
        If (Me.checkBoxLibelle.Checked) Then
            Me.textBoxLibelle.Enabled = True
        Else
            Me.textBoxLibelle.Enabled = False
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub buttonRechercher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonRechercher.Click
        Dim filtre As String = String.Empty

        'Vérifie que les dates d'écritures soient cohérentes
        If (Me.checkBoxDateEcr.Checked And (CDate(Me.dateTimePickerDateDebEcr.Value.ToString("yyyy/MM/dd")) > CDate(Me.dateTimePickerDateFinEcr.Value.ToString("yyyy/MM/dd")))) Then
            MsgBox("Veuillez saisir une date d'écriture de début inférieure à la date de fin.", MsgBoxStyle.Exclamation, "")
            Me.dateTimePickerDateDebEcr.Focus()

            Exit Sub
        End If

        'Les champs des montants doivent être au format numérique
        If (Me.checkBoxMontantD.Checked Or Me.checkBoxMontantC.Checked) Then
            If (Not (IsNumeric(Replace(Me.textBoxMontantDeb.Text.ToString(), ".", ","))) And Me.textBoxMontantDeb.Text <> String.Empty) Then
                MsgBox("Veuillez saisir un montant.", MsgBoxStyle.Exclamation, "")
                Me.textBoxMontantDeb.Focus()
                Me.textBoxMontantDeb.Select(0, Me.textBoxMontantDeb.Text.Length)

                Exit Sub
            End If
        End If

        If (Me.checkBoxMontantD.Checked Or Me.checkBoxMontantC.Checked) Then
            If (Not (IsNumeric(Replace(Me.textBoxMontantFin.Text, ".", ","))) And Me.textBoxMontantFin.Text <> String.Empty) Then
                MsgBox("Veuillez saisir un montant.", MsgBoxStyle.Exclamation, "")
                Me.textBoxMontantFin.Focus()
                Me.textBoxMontantFin.Select(0, Me.textBoxMontantFin.Text.Length)

                Exit Sub
            End If
        End If

        'Le numéro de pièce doit être au format numérique
        If (Me.checkBoxNumPiece.Checked) Then
            If (Not (IsNumeric(Me.textBoxNumPiece.Text)) And Me.textBoxNumPiece.Text <> String.Empty) Then
                MsgBox("Veuillez saisir un numéro.", MsgBoxStyle.Exclamation, "")
                Me.textBoxNumPiece.Focus()
                Me.textBoxNumPiece.Select(0, Me.textBoxNumPiece.Text.Length)

                Exit Sub
            End If
        End If

        'Construction du filtre
        Me._filtre = Me.ConstruireFiltre()

        'fermeture de la fenêtre
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub buttonAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonAnnuler.Click
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub InitialiserForm()
        Me.checkBoxDateEcr.Checked = False
        Me.dateTimePickerDateDebEcr.Enabled = False
        Me.dateTimePickerDateFinEcr.Enabled = False
        Me.checkBoxMontant.Checked = False
        Me.checkBoxMontantD.Checked = False
        Me.checkBoxMontantD.Enabled = False
        Me.checkBoxMontantC.Checked = False
        Me.checkBoxMontantC.Enabled = False
        DesactiverTextBoxMontants()
        Me.checkBoxNumPiece.Checked = False
        Me.textBoxNumPiece.Enabled = False
        Me.checkBoxLibelle.Checked = False
        Me.textBoxLibelle.Enabled = False
        Me.radioButtonNonPt.Checked = True
        Me.radioButtonPt.Checked = False
        Me.radioButtonToutes.Checked = False
    End Sub

    Private Sub DesactiverTextBoxMontants()
        Me.textBoxMontantDeb.Enabled = False
        Me.textBoxMontantFin.Enabled = False
    End Sub

    Private Sub ActiverTextBoxMontants()
        Me.textBoxMontantDeb.Enabled = True
        Me.textBoxMontantFin.Enabled = True
    End Sub

    Private Function ConstruireFiltre() As String
        Dim filtre As String = String.Empty
        Dim listeCriteres As New List(Of String)
        Dim i As Integer = 0

        If (Me.checkBoxDateEcr.Checked) Then
            listeCriteres.Add(" MDate >= #" & Me.dateTimePickerDateDebEcr.Value.ToString("yyyy/MM/dd") & "# AND MDate <= #" & Me.dateTimePickerDateFinEcr.Value.ToString("yyyy/MM/dd") & "# ")

            Me._listeCriteresFiltre.DateEcrDeb = Me.dateTimePickerDateDebEcr.Value.ToString("dd/MM/yyyy")
            Me._listeCriteresFiltre.DateEcrFin = Me.dateTimePickerDateFinEcr.Value.ToString("dd/MM/yyyy")
        End If

        If (Me.checkBoxMontant.Checked) Then
            If (Me.checkBoxMontantD.Checked) Then
                If (Me.textBoxMontantDeb.Text <> String.Empty And Me.textBoxMontantFin.Text <> String.Empty) Then
                    listeCriteres.Add(" MMtDeb >= " & Replace(Me.textBoxMontantDeb.Text, ",", ".") & " ")
                    listeCriteres.Add(" MMtDeb <= " & Replace(Me.textBoxMontantFin.Text, ",", ".") & " ")
                ElseIf (Me.textBoxMontantDeb.Text <> String.Empty And Me.textBoxMontantFin.Text = String.Empty) Then
                    listeCriteres.Add(" MMtDeb = " & Replace(Me.textBoxMontantDeb.Text, ",", ".") & " ")
                ElseIf (Me.textBoxMontantFin.Text <> String.Empty And Me.textBoxMontantDeb.Text = String.Empty) Then
                    listeCriteres.Add(" MMtDeb = " & Replace(Me.textBoxMontantFin.Text, ",", ".") & " ")
                End If

                Me._listeCriteresFiltre.SensMontant = Me._listeCriteresFiltre.TexteDebit
                Me._listeCriteresFiltre.MontantDeb = Me.textBoxMontantDeb.Text
                Me._listeCriteresFiltre.MontantFin = Me.textBoxMontantFin.Text
            End If

            If (Me.checkBoxMontantC.Checked) Then
                If (Me.textBoxMontantDeb.Text <> String.Empty And Me.textBoxMontantFin.Text <> String.Empty) Then
                    listeCriteres.Add(" MMtCre >= " & Replace(Me.textBoxMontantDeb.Text, ",", ".") & " ")
                    listeCriteres.Add(" MMtCre <= " & Replace(Me.textBoxMontantFin.Text, ",", ".") & " ")
                ElseIf (Me.textBoxMontantDeb.Text <> String.Empty And Me.textBoxMontantFin.Text = String.Empty) Then
                    listeCriteres.Add(" MMtCre = " & Replace(Me.textBoxMontantDeb.Text, ",", ".") & " ")
                ElseIf (Me.textBoxMontantFin.Text <> String.Empty And Me.textBoxMontantDeb.Text = String.Empty) Then
                    listeCriteres.Add(" MMtCre = " & Replace(Me.textBoxMontantFin.Text, ",", ".") & " ")
                End If

                Me._listeCriteresFiltre.SensMontant = Me._listeCriteresFiltre.TexteCrebit
                Me._listeCriteresFiltre.MontantDeb = Me.textBoxMontantDeb.Text
                Me._listeCriteresFiltre.MontantFin = Me.textBoxMontantFin.Text
            End If
        End If

        If (Me.checkBoxNumPiece.Checked And Me.textBoxNumPiece.Text <> String.Empty) Then
            listeCriteres.Add(" MPiece = " & Replace(Me.textBoxNumPiece.Text, ",", ".") & " ")

            Me._listeCriteresFiltre.NumPiece = Me.textBoxNumPiece.Text
        End If

        If (Me.checkBoxLibelle.Checked And Me.textBoxLibelle.Text <> String.Empty) Then
            listeCriteres.Add(" LibelleLigne LIKE '*" & Replace(Me.textBoxLibelle.Text, "'", "''") & "*' ")

            Me._listeCriteresFiltre.Libelle = Me.textBoxLibelle.Text
        End If

        If (Me.radioButtonNonPt.Checked) Then
            listeCriteres.Add(" MPointage IS NULL ")

            Me._listeCriteresFiltre.TypeEcr = Me._listeCriteresFiltre.TexteNonPt
        End If

        If (Me.radioButtonPt.Checked) Then
            listeCriteres.Add(" MPointage IS NOT NULL ")

            Me._listeCriteresFiltre.TypeEcr = Me._listeCriteresFiltre.TextePt
        End If

        If (Me.radioButtonToutes.Checked) Then
            Me._listeCriteresFiltre.TypeEcr = Me._listeCriteresFiltre.TexteToutes
        End If

        'Construction du filtre
        If (listeCriteres.Count > 0) Then
            filtre = listeCriteres.Item(0)

            For i = 1 To listeCriteres.Count - 1
                filtre = filtre & "AND" & listeCriteres.Item(i)
            Next
        End If

        Return filtre
    End Function
#End Region

End Class
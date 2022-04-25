Public Class FrOrdreInsertion

    Private _nEvenement As Decimal = -1
    Private modif As Boolean
    Private _IndexSelected As Integer = 0

    Private Const TYPEPERSONNECOMMERCIAL As String = "Commercial"
    Public Const TYPEEVORDREINSERTION As String = "OrdreInsertion"
    Private Const TYPEORDRE As String = "Ordre Insertion"
    Private Const PRIORITE As String = "Normal"

    Public Enum NomChoixOrdreInsertion
        ListeTypeEv
        ListeFormat
        ListeCouleur
        ListeContenu
        ListeEmplacement
        ListeRubrique
        ListeModeReglement
    End Enum

#Region "Propriétés"
    Public Property nEvenement() As Decimal
        Get
            Return Me._nEvenement
        End Get
        Set(ByVal value As Decimal)
            Me._nEvenement = value
        End Set
    End Property

    Private ReadOnly Property CurrentEvenementRow() As PubDataSet.EvenementRow
        Get
            If (Me.EvenementBindingSource.Current Is Nothing) Then
                Return Nothing
            End If

            Return DirectCast(DirectCast(Me.EvenementBindingSource.Current, DataRowView).Row, PubDataSet.EvenementRow)
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal nEvenement As Decimal)
        Me.New()

        Me._nEvenement = nEvenement
    End Sub
#End Region

#Region "Form"
    Private Sub FrOrdreInsertion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        'Active l'auto-incrément sur la colonne nEvenement
        Me.PubDataSet.Evenement.InitAutoIncrementSeed()

        'Charge les données
        Me.LoadData()

        'Positionne le EvenementBindingSource sur l'enregistrement correspondant au nEvenement 
        'passé au constructeur
        If (Me._IndexSelected > -1) Then
            Me.EvenementBindingSource.Position = Me._IndexSelected
        End If
    End Sub

    Private Sub FrOrdreInsertion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If modif Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub AjouterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjouterTypeEvButton.Click, _
                                        AjouterContenuButton.Click, AjouterCouleurButton.Click, AjouterEmplacementButton.Click, _
                                        AjouterFormatButton.Click, AjouterRubriqueButton.Click
        If (TypeOf sender Is Button) Then
            Dim button As Button = CType(sender, Button)

            If Not (button.Tag Is Nothing) Then
                Using fr As New FrListeChoix(CStr(button.Tag))
                    If (fr.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                        'Recharge les données des combobox
                        Me.LoadDataComboListeChoix()
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub ChercherClientButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChercherClientButton.Click
        Me.OpenFormChercherClient()
    End Sub
#End Region

#Region "EvenementDataGridView"
    Private Sub EvenementDataGridView_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles EvenementDataGridView.DataBindingComplete
        'formattage des cellules : en italique si nOrigine est renseigné pour la ligne
        If e.ListChangedType = System.ComponentModel.ListChangedType.Reset Then
            Dim indexSelected As Integer = 0

            For Each dr As DataGridViewRow In Me.EvenementDataGridView.Rows
                If Not IsDBNull(CType(dr.DataBoundItem, DataRowView)("nOrigine")) Then
                    dr.DefaultCellStyle.Font = New Font(EvenementDataGridView.Font, FontStyle.Italic)
                    dr.DefaultCellStyle.ForeColor = Color.Gray
                Else
                    dr.DefaultCellStyle.Font = EvenementDataGridView.DefaultCellStyle.Font
                    dr.DefaultCellStyle.ForeColor = EvenementDataGridView.DefaultCellStyle.ForeColor
                End If

                'Récupére l'index du DataGridViewRow correspondant au nEvenement passé au constructeur
                'afin de pouvoir positionner le EvenementBindingSource sur lui et afficher 
                'le bon ordre d'insertion de la liste
                If (Me.nEvenement > -1) Then
                    If (CDec(CType(dr.DataBoundItem, DataRowView)("nEvenement")) = Me.nEvenement) Then
                        Me._IndexSelected = dr.Index
                    End If
                End If
            Next
        End If
    End Sub
#End Region

#Region "ToolStrip1"
    Private Sub FermerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FermerToolStripButton.Click
        Me.Close()
    End Sub

    Private Sub EnregistrerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnregistrerToolStripButton.Click
        Me.Enregistrer()
    End Sub

    Private Sub SupprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripButton.Click
        Me.Supprimer()
    End Sub

    Private Sub DupliquerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DupliquerToolStripButton.Click
        Me.Dupliquer()
    End Sub

    Private Sub ImprimerToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimerToolStripButton.Click
        Me.ImprimerOrdreInsertion()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        'charge les données des combobox liste choix
        Me.LoadDataComboListeChoix()

        'Chargement des entreprises
        Me.EntrepriseTableAdapter.FillClient(Me.PubDataSet.Entreprise)

        'Chargement des commerciaux
        Me.PersonneTableAdapter.FillByTypePersonne(Me.PubDataSet.Personne, TYPEPERSONNECOMMERCIAL)

        'Chargement des évènements
        If (Me.nEvenement > -1) Then
            'Chargement de l'évènement + évènements liés par l'origine
            Me.EvenementTableAdapter.FillByOrigine(Me.PubDataSet.Evenement, Me.nEvenement)

            Me.CurrentEvenementRow.AcceptChanges()
        Else
            Me.EvenementBindingSource.AddNew()

            'Valeurs par défaut du nouvel évènement
            With Me.CurrentEvenementRow
                .TypeEv = TYPEEVORDREINSERTION
                .Type = TYPEORDRE
                .DateCreation = Now
                .Priorite = PRIORITE
                .DateEv = Date.Today
                .Realise = False
                .nPersonneAuteur = FrApplication.nUtilisateur
                .nPersonneDestinataire = FrApplication.nUtilisateur
                .AContacter = False
                .FaxerBAT = False
                .FacturationM = False
                .AutreSupport = False
                .Facture = False
                .Libelle = "Ordre d'insertion du " & CStr(.DateCreation)
            End With

            Me.EvenementBindingSource.ResetCurrentItem()
        End If
    End Sub

    Private Sub LoadDataComboListeChoix()
        ''Chargement des types d'évènement
        'Me.ListeTypeEvBindingSource.DataSource = Me.ListeChoixTableAdapter.GetDataByNomChoix(FrOrdreInsertion.NomChoixOrdreInsertion.ListeTypeEv.ToString())

        ''Chargement des formats
        'Me.ListeFormatBindingSource.DataSource = Me.ListeChoixTableAdapter.GetDataByNomChoix(FrOrdreInsertion.NomChoixOrdreInsertion.ListeFormat.ToString())

        ''Chargement des couleurs
        'Me.ListeCouleurBindingSource.DataSource = Me.ListeChoixTableAdapter.GetDataByNomChoix(FrOrdreInsertion.NomChoixOrdreInsertion.ListeCouleur.ToString())

        ''Chargement des contenus
        'Me.ListeContenuBindingSource.DataSource = Me.ListeChoixTableAdapter.GetDataByNomChoix(FrOrdreInsertion.NomChoixOrdreInsertion.ListeContenu.ToString())

        ''Chargement des emplacements
        'Me.ListeEmplacementBindingSource.DataSource = Me.ListeChoixTableAdapter.GetDataByNomChoix(FrOrdreInsertion.NomChoixOrdreInsertion.ListeEmplacement.ToString())

        ''Chargement des rubriques
        'Me.ListeRubriqueBindingSource.DataSource = Me.ListeChoixTableAdapter.GetDataByNomChoix(FrOrdreInsertion.NomChoixOrdreInsertion.ListeRubrique.ToString())

        'Me.EvenementBindingSource.ResetBindings(False)
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.EvenementBindingSource.EndEdit()

        If Me.PubDataSet.HasChanges Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function

    Private Sub Enregistrer()
        Me.Validate()
        Me.EvenementBindingSource.EndEdit()

        If Me.PubDataSet.HasChanges Then
            Me.EvenementTableAdapter.Update(Me.PubDataSet.Evenement)

            modif = True
        End If
    End Sub

    Private Sub Supprimer()
        If Me.EvenementBindingSource.Position < 0 Then Exit Sub

        If (MsgBox("Confirmez-vous la suppression de l'ordre d'insertion actuel ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then Exit Sub

        Me.EvenementBindingSource.EndEdit()

        'Suppression uniquement si l'ordre d'insertion n'est ni réalisé ni facturé
        If Not (Me.CurrentEvenementRow.Realise) And Not (Me.CurrentEvenementRow.Facture) Then
            Me.EvenementBindingSource.RemoveCurrent()

            If (Me.EvenementBindingSource.List.Count = 0) Then
                Me.Enregistrer()

                Me.Close()
            End If
        Else
            MsgBox("Suppression impossible : l'ordre d'insertion est soit réalisé soit facturé.", MsgBoxStyle.Exclamation, "")

            Exit Sub
        End If
    End Sub

    Private Sub OpenFormChercherClient()
        Dim fr As New FrChercherClient()

        With fr
            .ShowDialog()

            If Not (fr.EntrepriseDR Is Nothing) Then
                Me.CurrentEvenementRow.nClient = fr.EntrepriseDR.nEntreprise
                Me.EvenementBindingSource.ResetBindings(False)
            End If
        End With
    End Sub

    Private Sub Dupliquer()
        Me.EvenementBindingSource.EndEdit()

        Dim NewEvenementDR As PubDataSet.EvenementRow = Me.PubDataSet.Evenement.NewEvenementRow()

        'Pour chaque colonne, on affecte la valeur de l'ordre à dupliquer au nouvel ordre 
        For Each column As DataColumn In Me.PubDataSet.Evenement.Columns
            If Not (column.ColumnName = "nEvenement") And Not (column.ColumnName = "nPreFacturation") And Not (column.ColumnName = "DatePreFacturation") Then
                If Not (Me.CurrentEvenementRow.IsNull(column.ColumnName)) Then
                    NewEvenementDR.Item(column.ColumnName) = Me.CurrentEvenementRow.Item(column.ColumnName)
                End If
            End If
        Next

        'Met à jour les valeurs spécifiques du nouvel ordre
        With NewEvenementDR
            .Type = "Ordre Insertion"
            .DateCreation = Now
            .DateEv = Date.Today
            .Realise = False
            .nPersonneAuteur = FrApplication.nUtilisateur
            .nPersonneDestinataire = FrApplication.nUtilisateur
            .Facture = False
        End With

        'Si le nouvel ordre ne possède pas de nOrigine, c'est que l'ordre dupliqué est l'ordre parent.
        'Le nOrigine du nouvel ordre prend alors la valeur du nEvenement de l'ordre dupliqué.
        If (NewEvenementDR.IsnOrigineNull) Then
            NewEvenementDR.nOrigine = Me.CurrentEvenementRow.nEvenement
        End If

        Me.PubDataSet.Evenement.AddEvenementRow(NewEvenementDR)

        Me.EvenementBindingSource.ResetBindings(False)

        'Se positionne sur le premier ordre de la liste car liste classée par nEvenement DESC
        Me.EvenementBindingSource.MoveFirst()
    End Sub

    Private Sub ImprimerOrdreInsertion()
        If (Me.nEvenement > -1) Then
            Dim myDS As DataSet = Me.PubDataSet.Clone()

            myDS.Merge(Me.PubDataSet.Evenement.Select("nEvenement=" & Me.nEvenement))
            myDS.Merge(Me.PubDataSet.Personne.Select())
            myDS.Merge(Me.PubDataSet.Entreprise.Select())

            Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDS, "RptOrdreInsertion.rpt")

            fr.Show()
        Else
            MsgBox("Rien à imprimer.", MsgBoxStyle.Exclamation, "")
        End If
    End Sub
#End Region

End Class
Imports System.ComponentModel

''' <summary>
''' Class gérant la saisie et la consultation de ligne pour une pièce
''' </summary>
''' <remarks></remarks>
Public Class UcGrilleSaisieLignes

    ''' <summary>
    ''' indique si le chargement du controle est effectué
    ''' </summary>
    ''' <remarks></remarks>
    Private bIsLoaded As Boolean = False

    Public Event CurrentCompteChanged(ByVal CurLigne As Ligne)
    Public Event CurrentActiviteChanged(ByVal CurLigne As Ligne)
    Public Event CalculContrePartieChanged()
    Public Event ActiveSaveButton(ByVal ActiveButton As Boolean)
    Public Event ActiveCloseButton(ByVal ActiveButton As Boolean)
    Public Event ReloadTable()
    Public Event ReloadTableCompte()

#Region "Property"

    Private bMontantTTC As Boolean = False
    ''' <summary>
    ''' Indique si la saisie des mouvements est en TTC ou HT
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MontantTTC() As Boolean
        Get
            Return bMontantTTC
        End Get
        Set(ByVal value As Boolean)
            bMontantTTC = value
        End Set
    End Property

    Private _bValidationLigne As Boolean
    ''' <summary>
    ''' Permet de savoir si les lignes sont valide pour l'enregistrement
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ValidationLigne() As Boolean
        Get
            Return _bValidationLigne
        End Get
    End Property

    Private _datasource As Object
    ''' <summary>
    ''' datasource de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Bindable(True), _
     Category("Data"), _
     Description("Datasource de la piece à afficher")> _
     Public Property PieceDatasource() As Object
        Get
            Return _datasource
        End Get
        Set(ByVal value As Object)
            _datasource = value
            If value IsNot Nothing Then
                Me.PieceBindingSource.SuspendBinding()
                Me.PieceBindingSource.DataSource = value
                Me.PieceBindingSource.ResumeBinding()
                Me.LignesBindingSource.DataMember = "Lignes"
            End If
        End Set
    End Property

    Private _datamember As String
    ''' <summary>
    ''' Datamember de la pièce
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PieceDataMember() As String
        Get
            Return _datamember
        End Get
        Set(ByVal value As String)
            _datamember = value
            Me.PieceBindingSource.DataMember = value
            Me.LignesBindingSource.DataMember = "Lignes"
        End Set
    End Property

    Private _ds As dbDonneesDataSet
    ''' <summary>
    ''' Dataset contenant toutes les tables pour traiter les lignes
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Bindable(True), _
       Category("Data"), _
       Description("Dataset en cours")> _
       Public Property Dataset() As dbDonneesDataSet
        Get
            Return _ds
        End Get
        Set(ByVal value As dbDonneesDataSet)
            _ds = value
            If value IsNot Nothing Then
                Me.CompteBindingSource.DataSource = value
                Me.TVABindingSource.DataSource = value
            End If
        End Set
    End Property

    Private sJournalCptContre As String = ""
    ''' <summary>
    ''' compte du journal de contre partie
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Bindable(True), _
     Category("Data"), _
     Description("Journal en cours de saisie")> _
     Public Property JournalCptContre() As String
        Get
            Return sJournalCptContre
        End Get
        Set(ByVal value As String)
            sJournalCptContre = value
        End Set

    End Property

    Private sJournalCptContreLib As String = ""
    ''' <summary>
    ''' Libellé du compte de contre partie
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Bindable(True), _
       Category("Data"), _
       Description("Libelle du journal en cours de saisie")> _
       Public Property JournalCptContreLib() As String
        Get
            Return sJournalCptContreLib
        End Get
        Set(ByVal value As String)
            sJournalCptContreLib = value
        End Set
    End Property

    Private bReadOnlyData As Boolean
    ''' <summary>
    ''' Permet de gérer la grille de saisie en modele readonly ainsi que tous les contrôles attenant
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Bindable(True), _
         Category("Data"), _
         DefaultValue(False), _
         Description("Indique si la grille de saisie est en lecture seule ou non")> _
        Public Property ReadOnlyData() As Boolean
        Get
            Return bReadOnlyData
        End Get
        Set(ByVal value As Boolean)
            bReadOnlyData = value
            If bReadOnlyData Then
                With LignesDgv
                    .Enabled = True
                    .ReadOnly = True
                    .AllowUserToAddRows = False
                End With
                Me.ToolStripSeparator3.Visible = False
                Me.ToolStripSeparator4.Visible = False
                Me.cmsCopieLigne.Visible = False
                Me.cmsAjoutLigne.Visible = False
                Me.cmsSupprLigne.Visible = False
            End If
        End Set
    End Property

#End Region

#Region "Page"
    ''' <summary>
    ''' Chargement du controle
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UcGrilleSaisieLignes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        With LignesDgv
            AddHandler .CellParsing, AddressOf dg_CellParsing
            AddHandler .DataError, AddressOf dg_DataError
            AddHandler .MouseDown, AddressOf dg_GestionClicDroit
            .AutocompletColsMode1.Add(Compte)
            .AutocompletColsMode2.Add(Activite)
            .AutocompletColsMode2.Add(CodeTVA)
            .ConfigAutocompleteCombobox()
            .Enabled = False
        End With

        AddHandler LignesDgv.EditingControlShowing, AddressOf ConfigEditControl

        'bloque le controle en lecture seule
        If bReadOnlyData Then
            With LignesDgv
                .Enabled = True
                .ReadOnly = True
                .AllowUserToAddRows = False
            End With
            Me.ToolStripSeparator3.Visible = False
            Me.ToolStripSeparator4.Visible = False
            Me.cmsCopieLigne.Visible = False
            Me.cmsAjoutLigne.Visible = False
            Me.cmsSupprLigne.Visible = False
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ConfigEditControl(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
        If LignesDgv.CurrentCell.OwningColumn IsNot Libelle Then Exit Sub
        Dim tx As TextBox = CType(e.Control, TextBox)
        Dim coll As New AutoCompleteStringCollection
        For Each l As Ligne In Me.LignesBindingSource
            coll.Add(l.Libelle)
        Next
        With tx
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            .AutoCompleteCustomSource = coll
        End With
    End Sub

    ''' <summary>
    ''' Permet de gérer les évènements du clavier
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="keyData"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Control + Keys.F AndAlso Me.LignesDgv.CurrentCell.OwningColumn.Index = Compte.Index Then
            'Permet la recherche de compte 
            Using fr As New FrRechercheCompte
                If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    If fr.Compte <> "" Then
                        Dim xLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
                        xLigne.Compte = fr.Compte

                        Me.LignesDgv.ProcessRightKey(Keys.Enter)
                        Me.LignesDgv.Rows(LignesDgv.SelectedCells(0).RowIndex).Cells(Compte.Index).Selected = True
                        Me.LignesDgv.ProcessRightKey(Keys.Enter)
                    End If
                End If
            End Using
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
        Return True
    End Function
#End Region

#Region "Refresh/Paint de la grille, mise à jour des totaux, autorisation sur les cases de saisie"
    ''' <summary>
    ''' permet de sélectionner la première ligne lorsque la grille est chargé
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles LignesDgv.DataBindingComplete
        Try
            bIsLoaded = False
            If Me.PieceBindingSource.Current Is Nothing Then Exit Sub
            If Not bReadOnlyData Then LignesDgv.AllowUserToAddRows = True
            'permet de bloquer l'ajout de ligne automatique lorsqu'un compte vide existe
            Dim lignes As List(Of Ligne)
            If TypeOf Me.PieceBindingSource.Current Is Piece Then
                lignes = CType(Me.PieceBindingSource.Current, Piece).Lignes
            ElseIf TypeOf Me.PieceBindingSource.Current Is Modele Then
                lignes = CType(Me.PieceBindingSource.Current, Modele).Lignes
            End If
            For Each l As Ligne In lignes
                If (l.Compte = "00000000" Or l.Compte = "") And (Me.LignesBindingSource.IndexOf(l) <> Me.LignesDgv.NewRowIndex) And lignes.Count > 1 Then
                    LignesDgv.AllowUserToAddRows = False
                End If
                'met les autorisation de readonly en fonction de l'objet
                ActionsLigne(l)
                bIsLoaded = True
            Next

            'Rend non modifiable les lignes ayant un code pointage
            Me.RendreNonModifLignesAvecPointage()
        Catch ex As Exception
            LogException(ex)
        End Try
    End Sub

    ''' <summary>
    ''' alimente le boolean qui permet de savoir s'il est possible de changer le libellé du mouvement automatiquement ou pas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesDgv_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LignesDgv.KeyUp
        Try
            If Me.LignesDgv.CurrentCell IsNot Nothing AndAlso Me.LignesDgv.CurrentCell.OwningColumn.Index = Libelle.Index Then
                Dim xLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
                xLigne.LibelleAuto = False
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Permet lors de l'ajout d'un ligne dans le tableau de bloquer les colonnes en lecture seule
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesDgv_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles LignesDgv.RowsAdded
        If Me.LignesBindingSource.Position < 0 Then Exit Sub
        Dim curLigne As Ligne
        Try
            curLigne = CType(Me.LignesBindingSource.Current, Ligne)
        Catch
        End Try
        If curLigne Is Nothing Then Exit Sub
        ActionsLigne(curLigne)
    End Sub

    ''' <summary>
    ''' Permet lors de l'ajout d'un ligne dans le tableau de bloquer les colonnes en lecture seule
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesBindingSource_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles LignesBindingSource.AddingNew
        If LignesBindingSource.Count > 0 Then
            ActionsLigne()
        Else
            ActionsLigneNewAdd()
        End If
    End Sub

    ''' <summary>
    ''' permet de charger les paramètres adapter à la ligne qui vient de changer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LignesBindingSource.CurrentChanged
        Try
            'Supprime tous les évènements existants
            For Each l As Ligne In LignesBindingSource
                Try
                    RemoveHandler l.CompteChanged, AddressOf LigneCompteChanged
                    RemoveHandler l.ActiviteChanged, AddressOf LigneActiviteChanged
                Catch
                End Try
            Next
            'Ajoute un évènement sur le changement de compte et d'activité pour la ligne en cours
            If LignesBindingSource.Current IsNot Nothing Then
                AddHandler CType(LignesBindingSource.Current, Ligne).CompteChanged, AddressOf LigneCompteChanged
                AddHandler CType(LignesBindingSource.Current, Ligne).ActiviteChanged, AddressOf LigneActiviteChanged
            End If
            'redéfini les code TVA autorisé pour la ligne
            Dim xLigne As Ligne = CType(LignesBindingSource.Current, Ligne)
            If xLigne IsNot Nothing Then
                Ligne.DefineCodeTVA(_ds, TVABindingSource, xLigne.Compte)
                Me.CompteBindingSource.Position = Me.CompteBindingSource.Find("CCPT", xLigne.Compte)
            End If
            'Met à jour les totaux pour la pièce
            UpdateSommes(CType(Me.LignesBindingSource.Current, Ligne))
        Catch ex As Exception
            LogException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Permet de recharger les donénes de la ligne en fonction du compte saisie
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LigneCompteChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If sender Is LignesBindingSource.Current Then
                Dim l As Ligne = CType(sender, Ligne)
                'Vérification de l'existance du compte sinon mise à Zéro et blocage
                Dim drCpt As dbDonneesDataSet.ComptesRow = _ds.Comptes.FindByCDossierCCpt(My.User.Name, l.Compte)
                If drCpt Is Nothing Then
                    l.Compte = "00000000"
                End If
                If l.Compte = "00000000" Or l.Compte = "" Then
                    LignesDgv.AllowUserToAddRows = False
                    LockCMS(False)
                Else
                    If Not bReadOnlyData Then LignesDgv.AllowUserToAddRows = True
                    LockCMS(True)
                End If
                'Chargement des donnée en fonction du compte
                l.ChangementLigne(_ds, TVABindingSource)
                ActionsLigneLock(l)
                LignesDgv.JumpToMontant = False
                ActionsLigne()
                RaiseEvent CurrentCompteChanged(l)
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Permet de recharger le libellé de la ligne en fonction de l'activité saisie
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LigneActiviteChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If sender Is LignesBindingSource.Current Then
                Dim l As Ligne = CType(sender, Ligne)
                'Chargement des donnée en fonction de l'activité
                l.ChangementLigneA(_ds)
                ActionsLigneLock(l)
                LignesDgv.JumpToMontant = False
                ActionsLigne()
                RaiseEvent CurrentCompteChanged(l)
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Bloque les contextes menu
    ''' </summary>
    ''' <param name="bLockMenu"></param>
    ''' <remarks></remarks>
    Private Sub LockCMS(ByVal bLockMenu As Boolean)
        Me.cmsVisuCompte.Enabled = bLockMenu
        Me.cmsModifCompte.Enabled = bLockMenu
    End Sub

    ''' <summary>
    ''' permet de charger les paramètres adapter à la ligne apres le changement de la cellule
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesBindingSource_CurrentItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LignesBindingSource.CurrentItemChanged
        UpdateSommes(CType(Me.LignesBindingSource.Current, Ligne))
    End Sub

    ''' <summary>
    ''' permet d'appeller la fonction qui va paramétrer la ligne
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ActionsLigne()
        If Me.LignesBindingSource.Position < 0 Then Exit Sub
        Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
        If curLigne Is Nothing Then Exit Sub
        ActionsLigne(curLigne)
    End Sub

    ''' <summary>
    ''' permet de paramétrer la ligne au niveau des droits
    ''' </summary>
    ''' <param name="curLigne">ligne en cours de traitement</param>
    ''' <remarks></remarks>
    Private Sub ActionsLigneLock(ByVal curLigne As Ligne)
        Try
            Dim curRow As DataGridViewRow = Nothing
            For Each r As DataGridViewRow In LignesDgv.Rows
                If r.DataBoundItem Is curLigne Then
                    curRow = r
                    Exit For
                End If
            Next

            If curRow Is Nothing Then Exit Sub
            If curLigne.Compte Is Nothing OrElse curLigne.Compte = "00000000" OrElse curLigne.Compte = "" Then
                'Réinitialise les champs
                With curRow
                    .Cells(Activite.Name).Value = "0000"
                    .Cells(Libelle.Name).Value = ""
                    .Cells(CodeTVA.Name).Value = ""
                    .Cells(MontantCre.Name).Value = ""
                    .Cells(MontantDeb.Name).Value = ""
                    .Cells(Unite1.Name).Value = ""
                    .Cells(Quantite1.Name).Value = ""
                    .Cells(Unite2.Name).Value = ""
                    .Cells(Quantite2.Name).Value = ""
                    .Cells(MontantBaseHT.Name).Value = ""
                    .Cells(Activite.Name).Tag = "True"
                    .Cells(Libelle.Name).Tag = "True"
                    .Cells(CodeTVA.Name).Tag = "True"
                    .Cells(MontantCre.Name).Tag = "True"
                    .Cells(MontantDeb.Name).Tag = "True"
                    .Cells(Unite1.Name).Tag = "True"
                    .Cells(Quantite1.Name).Tag = "True"
                    .Cells(Unite2.Name).Tag = "True"
                    .Cells(Quantite2.Name).Tag = "True"
                    .Cells(MontantBaseHT.Name).Tag = "True"
                End With
            Else
                With curRow
                    'Activité activé que s'il y a des activités pour le compte
                    If PlanComptableBindingSource.Count = 0 Then
                        .Cells(Activite.Name).Tag = "True"
                        'CType(.Cells(Activite.Name), DataGridViewComboBoxCell).ReadOnly = False
                    Else
                        .Cells(Activite.Name).Tag = "False"
                        'CType(.Cells(Activite.Name), DataGridViewComboBoxCell).ReadOnly = True
                    End If
                    .Cells(Libelle.Name).Tag = "False"
                    'TVA => Editable seulement sur comptes 6 et 7
                    .Cells(CodeTVA.Name).Tag = (Not (curLigne.Compte.StartsWith("2") Or curLigne.Compte.StartsWith("6") Or curLigne.Compte.StartsWith("7"))).ToString
                    'Crédit renseigné => Débit ReadOnly
                    .Cells(MontantCre.Name).Tag = curLigne.MontantDeb.HasValue.ToString
                    'Débit renseigné => Crédit ReadOnly
                    .Cells(MontantDeb.Name).Tag = curLigne.MontantCre.HasValue.ToString
                    'Compte sans unité => Qté ReadOnly
                    .Cells(Unite1.Name).Tag = "True"
                    .Cells(Unite2.Name).Tag = "True"
                    .Cells(Quantite1.Name).Tag = (curLigne.Unite1 Is Nothing OrElse curLigne.Unite1.Length = 0).ToString
                    .Cells(Quantite2.Name).Tag = (curLigne.Unite2 Is Nothing OrElse curLigne.Unite2.Length = 0).ToString
                    'Compte n'appartenant pas à la TVA => montant TVA ReadOnly
                    Dim xRowTemp As Integer = _ds.TVA.Select("TCpt='" + curLigne.Compte + "'").Length
                    If xRowTemp > 0 Then
                        .Cells(MontantBaseHT.Name).Tag = "False"
                    Else
                        .Cells(MontantBaseHT.Name).Tag = "True"
                    End If
                End With
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    ''' <summary>
    ''' permet de paramétrer la ligne au niveau des droits
    ''' </summary>
    ''' <param name="curLigne">ligne en cours de traitement</param>
    ''' <remarks></remarks>
    Private Sub ActionsLigne(ByVal curLigne As Ligne)
        Try
            Dim curRow As DataGridViewRow = Nothing
            For Each r As DataGridViewRow In LignesDgv.Rows
                If r.DataBoundItem Is curLigne Then
                    curRow = r
                    Exit For
                End If
            Next

            If curRow Is Nothing Then Exit Sub

            If curLigne.Compte Is Nothing OrElse curLigne.Compte = "00000000" OrElse curLigne.Compte = "" Then
                'Réinitialise les champs
                With curRow
                    .Cells(Activite.Name).Tag = "True"
                    .Cells(Libelle.Name).Tag = "True"
                    .Cells(CodeTVA.Name).Tag = "True"
                    .Cells(MontantCre.Name).Tag = "True"
                    .Cells(MontantDeb.Name).Tag = "True"
                    .Cells(Unite1.Name).Tag = "True"
                    .Cells(Quantite1.Name).Tag = "True"
                    .Cells(Unite2.Name).Tag = "True"
                    .Cells(Quantite2.Name).Tag = "True"
                    .Cells(MontantBaseHT.Name).Tag = "True"
                End With
            Else
                With curRow
                    'Activité activé que s'il y a des activités pour le compte
                    If PlanComptableBindingSource.Count = 0 Then
                        .Cells(Activite.Name).Tag = "True"
                        'CType(.Cells(Activite.Name), DataGridViewComboBoxCell).ReadOnly = False
                    Else
                        .Cells(Activite.Name).Tag = "False"
                        'CType(.Cells(Activite.Name), DataGridViewComboBoxCell).ReadOnly = True
                    End If
                    .Cells(Libelle.Name).Tag = "False"
                    'TVA => Editable seulement sur comptes 6 et 7
                    .Cells(CodeTVA.Name).Tag = (Not (curLigne.Compte.StartsWith("2") Or curLigne.Compte.StartsWith("6") Or curLigne.Compte.StartsWith("7"))).ToString
                    'Crédit renseigné => Débit ReadOnly
                    .Cells(MontantCre.Name).Tag = curLigne.MontantDeb.HasValue.ToString
                    'Débit renseigné => Crédit ReadOnly
                    .Cells(MontantDeb.Name).Tag = curLigne.MontantCre.HasValue.ToString
                    'Compte sans unité => Qté ReadOnly
                    .Cells(Unite1.Name).Tag = "True"
                    .Cells(Unite2.Name).Tag = "True"
                    .Cells(Quantite1.Name).Tag = (curLigne.Unite1 Is Nothing OrElse curLigne.Unite1.Length = 0).ToString
                    .Cells(Quantite2.Name).Tag = (curLigne.Unite2 Is Nothing OrElse curLigne.Unite2.Length = 0).ToString
                    'Compte n'appartenant pas à la TVA => montant TVA ReadOnly
                    Dim xRowTemp As Integer = _ds.TVA.Select("TCpt='" + curLigne.Compte + "'").Length
                    If xRowTemp > 0 Then
                        .Cells(MontantBaseHT.Name).Tag = "False"
                    Else
                        .Cells(MontantBaseHT.Name).Tag = "True"
                    End If
                End With
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

    End Sub

    ''' <summary>
    ''' permet de paramétrer la ligne au niveau des droits
    ''' </summary>
    ''' <param name="curLigne">ligne en cours de traitement</param>
    ''' <remarks></remarks>
    Private Sub ActionsLigneNew(ByVal curLigne As Ligne)
        Try
            Dim curRow As DataGridViewRow = Nothing
            For Each r As DataGridViewRow In LignesDgv.Rows
                If r.DataBoundItem Is curLigne Then
                    curRow = r
                    Exit For
                End If
            Next

            If curRow Is Nothing Then Exit Sub

            If curLigne.Compte Is Nothing OrElse curLigne.Compte = "00000000" OrElse curLigne.Compte = "" Then
                'Réinitialise les champs
                With curRow
                    .Cells(Activite.Name).Value = "0000"
                    .Cells(Libelle.Name).Value = ""
                    .Cells(CodeTVA.Name).Value = ""
                    .Cells(MontantCre.Name).Value = ""
                    .Cells(MontantDeb.Name).Value = ""
                    .Cells(Quantite1.Name).Value = ""
                    .Cells(Quantite2.Name).Value = ""
                    .Cells(MontantBaseHT.Name).Value = ""
                    .Cells(Activite.Name).Tag = "True"
                    .Cells(Libelle.Name).Tag = "True"
                    .Cells(CodeTVA.Name).Tag = "True"
                    .Cells(MontantCre.Name).Tag = "True"
                    .Cells(MontantDeb.Name).Tag = "True"
                    .Cells(Unite1.Name).Tag = "True"
                    .Cells(Quantite1.Name).Tag = "True"
                    .Cells(Unite2.Name).Tag = "True"
                    .Cells(Quantite2.Name).Tag = "True"
                    .Cells(MontantBaseHT.Name).Tag = "True"
                End With
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' permet de paramétrer la ligne au niveau des droits
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ActionsLigneNewAdd()
        Try
            If LignesDgv.Rows.Count <> 1 Then Exit Sub

            Dim curRow As DataGridViewRow = LignesDgv.Rows(0)

            LockCMS(False)

            'Réinitialise les champs
            With curRow
                .Cells(Activite.Name).Value = "0000"
                .Cells(Libelle.Name).Value = ""
                .Cells(CodeTVA.Name).Value = ""
                .Cells(MontantCre.Name).Value = ""
                .Cells(MontantDeb.Name).Value = ""
                .Cells(Quantite1.Name).Value = ""
                .Cells(Quantite2.Name).Value = ""
                .Cells(MontantBaseHT.Name).Value = ""
                .Cells(Activite.Name).Tag = "True"
                .Cells(Libelle.Name).Tag = "True"
                .Cells(CodeTVA.Name).Tag = "True"
                .Cells(MontantCre.Name).Tag = "True"
                .Cells(MontantDeb.Name).Tag = "True"
                .Cells(Unite1.Name).Tag = "True"
                .Cells(Quantite1.Name).Tag = "True"
                .Cells(Unite2.Name).Tag = "True"
                .Cells(Quantite2.Name).Tag = "True"
                .Cells(MontantBaseHT.Name).Tag = "True"
            End With

        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' permet de faire la somme des lignes et le met dans la barre de tâche et aligne les colonnes
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateSommes(Optional ByVal CurLigne As Ligne = Nothing)
        Dim nbLignes As Integer
        Dim nDebit As Decimal
        Dim nCredit As Decimal

        If TypeOf Me.PieceBindingSource.Current Is Piece Then
            'Calcul des débits et crédits pour une piece
            Dim curPiece As Piece = CType(Me.PieceBindingSource.Current, Piece)
            If curPiece Is Nothing Then Exit Sub
            With curPiece
                nbLignes = .Lignes.Count
                nDebit = .CalcSommeDeb
                nCredit = .CalcSommeCre
            End With
        Else
            'Calcul des débits et crédits pour un modèle
            Dim curModele As Modele = CType(Me.PieceBindingSource.Current, Modele)
            If curModele Is Nothing Then Exit Sub
            With curModele
                nbLignes = .Lignes.Count
                nDebit = .CalcSommeDeb
                nCredit = .CalcSommeCre
            End With
        End If

        lbFiller.Width = Me.LignesDgv.RowHeadersWidth
        For Each col As DataGridViewColumn In Me.LignesDgv.Columns
            If col Is Me.MontantDeb Then Exit For
            lbFiller.Width += col.Width
        Next

        'Mise en forme des labels
        lbSommeDeb.Width = Me.MontantDeb.Width
        lbSommeCre.Width = Me.MontantCre.Width
        lbSommeDeb.Text = String.Format("{0:C2}", nDebit)
        lbSommeCre.Text = String.Format("{0:C2}", nCredit)
        lbSoldePiece.Text = String.Format("{0:C2}", nDebit - nCredit)

        'Activation des boutons
        If nbLignes = 0 Then 'If nDebit = 0 And nCredit = 0 Then
            'Aucune ligne: on ne peut ni sauvegarder ni cloturer
            RaiseEvent ActiveSaveButton(False)
            RaiseEvent ActiveCloseButton(False)
        ElseIf nDebit - nCredit <> 0 Then
            'Piece non equilibrée, on ne peut pas sauvegarder mais on peut cloturer
            lbSoldePiece.ForeColor = Color.Red
            RaiseEvent ActiveSaveButton(False)
            RaiseEvent ActiveCloseButton(True)
        Else
            'Piece equilibrée : on ne peut pas cloturer mais on peut sauvegarder
            lbSoldePiece.ForeColor = SystemColors.ControlText
            RaiseEvent ActiveSaveButton(True)
            RaiseEvent ActiveCloseButton(False)
        End If
        RaiseEvent CurrentCompteChanged(CurLigne)
        RaiseEvent CalculContrePartieChanged()
    End Sub
#End Region

#Region "Validation de la ligne"

    ''' <summary>
    ''' Appel la fonction de vérification de ligne lors de la saisie
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LignesDgv_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles LignesDgv.RowValidating
        If bIsLoaded Then
            ValidateDataLine(e)
        End If
    End Sub

    ''' <summary>
    ''' Vérifie la validité de la ligne
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ValidateDataLine(ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) As Boolean
        Try
            Dim bError As Boolean = False
            _bValidationLigne = True
            Dim dgRow As DataGridViewRow = LignesDgv.Rows(e.RowIndex)
            Dim curLigne As Ligne
            Try
                curLigne = CType(dgRow.DataBoundItem, Ligne)
            Catch
            End Try

            If curLigne IsNot Nothing Then
                'Détermine si la ligne est valide sur les ratio du compte
                Dim xDonneeValide As Ligne.DataValidationDetail = curLigne.IsDonneeValide(Me.Dataset.ReglesValidation)
                If Not xDonneeValide.IsValide Then
                    bError = True
                    _bValidationLigne = False

                    'Message d'erreur sur la quantité 1
                    If xDonneeValide.CellQte1Oblig And Not curLigne.Quantite1.HasValue Then
                        dgRow.Cells(Quantite1.Name).ErrorText = xDonneeValide.CellErrorQte1ObligText
                    Else
                        If (curLigne.MontantDeb.HasValue Or curLigne.MontantCre.HasValue) And Not xDonneeValide.CellErrorRatioHT.GetValueOrDefault(False) Then
                            dgRow.Cells(Quantite1.Name).ErrorText = xDonneeValide.CellErrorRatioHTText
                            If curLigne.MontantDeb.HasValue Then dgRow.Cells(MontantDeb.Name).ErrorText = xDonneeValide.CellErrorRatioHTText
                            If curLigne.MontantCre.HasValue Then dgRow.Cells(MontantCre.Name).ErrorText = xDonneeValide.CellErrorRatioHTText
                        End If
                    End If

                    'Message d'erreur sur la quantité 2
                    If xDonneeValide.CellQte2Oblig And Not curLigne.Quantite2.HasValue Then
                        dgRow.Cells(Quantite2.Name).ErrorText = xDonneeValide.CellErrorQte2ObligText
                    Else
                        If curLigne.Quantite1.HasValue And curLigne.Quantite2.HasValue And Not xDonneeValide.CellErrorRatioQT.GetValueOrDefault(False) Then
                            dgRow.Cells(Quantite1.Name).ErrorText = xDonneeValide.CellErrorRatioQTText
                            dgRow.Cells(Quantite2.Name).ErrorText = xDonneeValide.CellErrorRatioQTText
                        End If
                    End If
                Else
                    'Supprime tous les messages d'erreur
                    With dgRow
                        .Cells(Quantite1.Name).ErrorText = ""
                        .Cells(Quantite2.Name).ErrorText = ""
                        .Cells(MontantDeb.Name).ErrorText = ""
                        .Cells(MontantCre.Name).ErrorText = ""
                    End With
                End If
            End If

            If Not bError Then
                RaiseEvent ActiveSaveButton(True)
            Else
                RaiseEvent ActiveSaveButton(False)
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Function

#End Region

#Region "Gestion du contextmenu Ligne"

    ''' <summary>
    ''' Ajoute une ligne à la position indiqué
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmsAjoutLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAjoutLigne.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim curLigne As New Ligne()
            Dim curPiece As Piece
            Dim curModele As Modele
            If TypeOf Me.PieceBindingSource.Current Is Piece Then
                curPiece = CType(Me.PieceBindingSource.Current, Piece)
                curPiece.Lignes.Insert(LignesBindingSource.Position, curLigne)
            Else
                curModele = CType(Me.PieceBindingSource.Current, Modele)
                curModele.Lignes.Insert(LignesBindingSource.Position, curLigne)
            End If
            ReloadGridLigne()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' supprime la ligne sélectionné
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmsSupprLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsSupprLigne.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            'Pas de suppression possible si ligne comporte un pointage
            Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)

            If Not (curLigne.CodePointageMvt Is Nothing) Then
                MsgBox("Suppression de la ligne impossible car elle est pointée dans le rapprochement bancaire.", MsgBoxStyle.Exclamation, "Suppression impossible")

                Exit Sub
            End If

            Dim curPiece As Piece
            Dim curModele As Modele
            If LignesBindingSource.Position < 0 Then Exit Sub
            Dim nPosition As Integer = Me.PieceBindingSource.Position
            If TypeOf Me.PieceBindingSource.Current Is Piece Then
                curPiece = CType(Me.PieceBindingSource.Current, Piece)
                Me.PieceBindingSource.SuspendBinding()
                curPiece.Lignes.RemoveAt(LignesBindingSource.Position)
            Else
                curModele = CType(Me.PieceBindingSource.Current, Modele)
                Me.PieceBindingSource.SuspendBinding()
                curModele.Lignes.RemoveAt(LignesBindingSource.Position)
            End If
            Me.PieceBindingSource.ResumeBinding()
            Me.PieceBindingSource.Position = nPosition
            'ReloadGridLigne()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Permet de visualiser le compte dans la fenetre de visu comtpe
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmsVisuCompte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsVisuCompte.Click

        If Me.LignesBindingSource.Current Is Nothing Then Exit Sub
        Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
        Using fr As New FrVisuCompte()
            With fr
                .nCompte = curLigne.Compte
                .ShowDialog()
            End With
        End Using

    End Sub

    ''' <summary>
    ''' Permet de modifier le compte dans la l'assistant de création de compte
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmsModifCompte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsModifCompte.Click
        If Me.LignesBindingSource.Current Is Nothing Then Exit Sub
        Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
        Using fr As New FrAssistantCreationCompte()
            With fr
                .Mode = FrAssistantCreationCompte.ModeAssistant.Modification
                .nCompte = curLigne.Compte
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    RaiseEvent ReloadTable()
                End If
            End With
        End Using
    End Sub

    ''' <summary>
    ''' Copie la ligne sélectionnée
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmsCopieLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsCopieLigne.Click
        CopieLigne()
    End Sub

#End Region

#Region "Fonction communes"
    ''' <summary>
    ''' Permet de désactiver le mode modification du tableau
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub EndEdit()
        With Me.LignesBindingSource
            If .Position < 0 OrElse CType(.Current, Ligne).Compte Is Nothing OrElse CType(.Current, Ligne).Compte = "00000000" Then
                .CancelEdit()
            Else
                .EndEdit()
            End If
        End With
    End Sub

    ''' <summary>
    ''' Suppression des lignes contenant des comptes vides, null ou 000000000
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CleanLigne()
        Dim curPiece As Piece
        Dim curModele As Modele
        If TypeOf Me.PieceBindingSource.Current Is Piece Then
            curPiece = CType(Me.PieceBindingSource.Current, Piece)
            If curPiece Is Nothing Then Exit Sub
            Me.LignesBindingSource.SuspendBinding()
            For i As Integer = curPiece.Lignes.Count - 1 To 0 Step -1
                If curPiece.Lignes(i).Compte = "" Or (curPiece.Lignes(i).Libelle = "" And curPiece.Lignes(i).MontantDeb.HasValue = False And curPiece.Lignes(i).MontantCre.HasValue = False) Then
                    curPiece.Lignes.RemoveAt(i)
                End If
            Next
            Me.LignesBindingSource.ResumeBinding()
        Else
            curModele = CType(Me.PieceBindingSource.Current, Modele)
            If curModele Is Nothing Then Exit Sub
            Me.LignesBindingSource.SuspendBinding()
            For i As Integer = curModele.Lignes.Count - 1 To 0 Step -1
                If curModele.Lignes(i).Compte = "" Or (curModele.Lignes(i).Libelle = "" And curModele.Lignes(i).MontantDeb.HasValue = False And curModele.Lignes(i).MontantCre.HasValue = False) Then
                    curModele.Lignes.RemoveAt(i)
                End If
            Next
            Me.LignesBindingSource.ResumeBinding()
        End If
        ReloadGridLigne(True)
    End Sub

    ''' <summary>
    ''' Suppression des lignes contenant des comptes vides, null ou 000000000
    ''' </summary>
    ''' <param name="curPiece"></param>
    ''' <remarks></remarks>
    Public Sub CleanLigne(ByRef curPiece As Piece)
        If curPiece Is Nothing Then Exit Sub
        Me.LignesDgv.DataSource = Nothing
        Me.LignesBindingSource.SuspendBinding()
        For i As Integer = curPiece.Lignes.Count - 1 To 0 Step -1
            If curPiece.Lignes(i).Compte = "" Or (curPiece.Lignes(i).Libelle = "" And curPiece.Lignes(i).MontantDeb.HasValue = False And curPiece.Lignes(i).MontantCre.HasValue = False) Then
                curPiece.Lignes.RemoveAt(i)
            End If
        Next
        Me.LignesBindingSource.ResumeBinding()
        Me.LignesDgv.DataSource = Me.LignesBindingSource
        'ReloadGridLigne(True)
    End Sub

    ''' <summary>
    ''' Suppression des lignes contenant des comptes vides, null ou 000000000
    ''' </summary>
    ''' <param name="curModele"></param>
    ''' <remarks></remarks>
    Public Sub CleanLigne(ByRef curModele As Modele)
        If curModele Is Nothing Then Exit Sub
        Me.LignesBindingSource.SuspendBinding()
        For i As Integer = curModele.Lignes.Count - 1 To 0 Step -1
            If curModele.Lignes(i).Compte = "" Or (curModele.Lignes(i).Libelle = "" And curModele.Lignes(i).MontantDeb.HasValue = False And curModele.Lignes(i).MontantCre.HasValue = False) Then
                curModele.Lignes.RemoveAt(i)
            End If
        Next
        Me.LignesBindingSource.ResumeBinding()
        ReloadGridLigne(True)
    End Sub

    ''' <summary>
    ''' Permet de lancer la cloture de la pièce après vérification
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CloturePiece()
        Try
            Dim sCompte As String = ""
            Dim sCompteLib As String = ""

            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()

            EndEdit()
            Dim curPiece As Piece = CType(Me.PieceBindingSource.Current, Piece)


            'TODO BUG SI CONTREPARTIE = VIDE AU LIEU DE NULL
            'Nettoyage
            CleanLigne(curPiece)
            If Not curPiece.IsTVAClosed(_ds.TVA) Then
                Me.LignesBindingSource.ResetBindings(True)
                MsgBox(My.Resources.Strings.Saisie_VeuillezSaisirMontantTVA, MsgBoxStyle.Exclamation, My.Resources.Strings.ErreurDEnregistrement)
                Exit Sub
            End If

            'Détermine le compte de contre partie
            sCompte = JournalCptContre
            sCompteLib = JournalCptContreLib
            If JournalCptContre = "51200000" OrElse JournalCptContre = "" Then
                sCompte = ""
                sCompteLib = ""
                For Each xLine As Ligne In Me.LignesBindingSource
                    If JournalCptContre <> "51200000" OrElse xLine.ContrePartie <> "" Then
                        sCompte = Convert.ToString(xLine.ContrePartie)
                        sCompteLib = Convert.ToString(xLine.ContrePartieLib)
                        Exit For
                    End If
                Next
            End If
            'ouvre une fenetre de saisie de compte de contre partie s'il n'a pas trouvé
            'If sCompte = "" Then
            '    RaiseEvent ReloadTableCompte()
            '    ReloadGridLigne()
            '    Using fr As New FrChoixCompte
            '        If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '            sCompte = fr.Compte
            '        End If
            '    End Using
            'End If

            Using fr As New FrRechercheCompte
                If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    'If Me.grille.ReadOnlyData = False AndAlso Me.grille.LignesDgv.CurrentCell IsNot Nothing AndAlso Me.grille.LignesDgv.CurrentCell.OwningColumn.Index = Me.grille.Compte.Index Then
                    If fr.Compte <> "" Then
                        'Dim xLigne As Ligne = CType(Me.grille.LignesBindingSource.Current, Ligne)
                        'xLigne.Compte = fr.Compte
                        'Me.grille.LignesDgv.ProcessRightKey(Keys.Enter)
                        sCompte = fr.Compte
                    End If
                    'End If
                End If
            End Using

            'Cloture de la pièce
            If sCompte <> "" Then
                If curPiece.ClosePiece(sCompte, sCompteLib, Me._ds.CompteTotal) Then
                    Me.LignesDgv.JumpToMontant = True
                    RaiseEvent ReloadTableCompte()
                    ReloadGridLigne()
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Permet de lancer le calcul de la TVA pour la pièce après vérification
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClotureTVA()
        Dim sPosition As String = ""

        Try
            EndEdit()
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            Dim curPiece As Piece = CType(Me.PieceBindingSource.Current, Piece)
            'nettoyage de la pièce
            CleanLigne(curPiece)
            If curPiece.Lignes.Count = 0 Then
                Me.LignesBindingSource.ResetBindings(True)
                MsgBox(My.Resources.Strings.Saisie_AppelTVASansLignes, MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
            'Appel du calcul de TVA en fonction du TTC ou HT
            If MontantTTC Then
                sPosition = curPiece.CloseTVATTC(False, _ds.TVA)
            Else
                sPosition = curPiece.CloseTVAHT(False, _ds.TVA)
            End If
            Me.LignesDgv.JumpToMontant = True
            RaiseEvent ReloadTableCompte()

            ReloadGridLigne()

            'Permet de positionner le curseur sur le compte de TVA dont la somme n'a pas été implémenté ou bien par défaut le der compte TVA si tous sont renseigné
            If sPosition <> "" Then
                For Each xRow As DataGridViewRow In LignesDgv.Rows
                    If xRow.Cells(Compte.Index).Value IsNot Nothing AndAlso xRow.Cells(Compte.Index).Value.ToString = sPosition Then
                        xRow.Cells(Libelle.Index).Selected = True
                        Me.LignesDgv.ProcessRightKey(Keys.Enter)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    ''' <summary>
    ''' Permet de copier la ligne
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CopieLigne()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim curPiece As Piece
            Dim curModele As Modele
            Dim nPosition As Integer = Me.PieceBindingSource.Position
            Dim curLigne As Ligne = CType(Me.LignesBindingSource.Current, Ligne)
            If TypeOf Me.PieceBindingSource.Current Is Piece Then
                curPiece = CType(Me.PieceBindingSource.Current, Piece)
                Me.PieceBindingSource.SuspendBinding()
                curPiece.Lignes.Insert(LignesBindingSource.Position, curLigne.Clone)
            Else
                curModele = CType(Me.PieceBindingSource.Current, Modele)
            End If
            Me.PieceBindingSource.ResumeBinding()
            Me.PieceBindingSource.Position = nPosition
            'ReloadGridLigne()
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub CopierLibelleLigneSup()
        Try
            Cursor.Current = Cursors.WaitCursor

            If LignesDgv.RowCount > 0 Then
                If Not (LignesDgv.CurrentRow Is Nothing) Then
                    Dim indexLigneCourante As Integer = LignesDgv.CurrentRow.Index
                    Dim libelleLigneSup As String = String.Empty

                    If (indexLigneCourante > 0) Then
                        If Not (LignesDgv.Rows(indexLigneCourante - 1).Cells(Libelle.Index).Value Is Nothing) Then
                            libelleLigneSup = LignesDgv.Rows(indexLigneCourante - 1).Cells(Libelle.Index).Value.ToString()

                            LignesDgv.Rows(indexLigneCourante).Cells(Libelle.Index).Value = libelleLigneSup
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' Permet de recharger le tableau et met le curseur sur la dernière ligne
    ''' </summary>
    ''' <param name="ModifDataLigne"></param>
    ''' <remarks></remarks>
    Public Sub ReloadGridLigne(Optional ByVal ModifDataLigne As Boolean = False)
        Try
            EndEdit()
            Me.LignesBindingSource.ResetBindings(ModifDataLigne)
            If LignesDgv.RowCount > 0 Then
                If LignesDgv.Rows(LignesDgv.RowCount - 1).Cells(Compte.Index).Value Is Nothing AndAlso LignesDgv.RowCount > 1 Then
                    LignesDgv.Rows(LignesDgv.RowCount - 2).Cells(Libelle.Index).Selected = True
                    Me.LignesDgv.ProcessRightKey(Keys.Enter)
                Else
                    LignesDgv.Rows(LignesDgv.RowCount - 1).Cells(Libelle.Index).Selected = True
                End If
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub
#End Region

#Region "Gestion pointage"
    Private Sub RendreNonModifLignesAvecPointage()
        For Each dr As DataGridViewRow In Me.LignesDgv.Rows
            If Not (CType(dr.DataBoundItem, Ligne).CodePointageMvt Is Nothing) Then
                dr.ReadOnly = True
                dr.DefaultCellStyle.Font = New Font(LignesDgv.Font, FontStyle.Italic)
                dr.DefaultCellStyle.ForeColor = Color.Gray
            End If
        Next
    End Sub
#End Region

End Class

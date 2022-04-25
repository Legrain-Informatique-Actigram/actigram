<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSaisiePiece
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DatePieceLabel As System.Windows.Forms.Label
        Dim LibelleLabel As System.Windows.Forms.Label
        Dim NPieceLabel As System.Windows.Forms.Label
        Dim JournalLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrSaisiePiece))
        Me.ListOfPiecesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.PiecesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.progressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.CMenuAction = New System.Windows.Forms.ToolStripDropDownButton
        Me.CMenuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuReinitialiser = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuTVA = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuSolde = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuEnregistrer = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuCompte = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuModifierCompte = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuInsertModele = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuEnregistrerModele = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuRecherche = New System.Windows.Forms.ToolStripMenuItem
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ListOfPiecesBindingNavigatorCleanItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorCloseTVAItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorCloseItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.AjouterCompteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ModifierUnCompteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorModeleItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorAddModeleItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorFindCompteItem = New System.Windows.Forms.ToolStripButton
        Me.DatePieceDtp = New System.Windows.Forms.DateTimePicker
        Me.LibelleTextBox = New System.Windows.Forms.TextBox
        Me.NPieceTextBox = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblActivite = New System.Windows.Forms.Label
        Me.lblCompte = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblDebitBalance = New System.Windows.Forms.Label
        Me.lblCreditBalance = New System.Windows.Forms.Label
        Me.lblDebit = New System.Windows.Forms.Label
        Me.lblCredit = New System.Windows.Forms.Label
        Me.lblDebitLib = New System.Windows.Forms.Label
        Me.lblCreditLib = New System.Windows.Forms.Label
        Me.chkMontantTTC = New System.Windows.Forms.CheckBox
        Me.JournalComboBox = New System.Windows.Forms.ComboBox
        Me.JournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsAgrigest = New AgrigestEDI.dbDonneesDataSet
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.grille = New AgrigestEDI.UcGrilleSaisieLignes
        Me.PanelLock = New Ascend.Windows.Forms.GradientPanel
        Me.lblJournalError = New System.Windows.Forms.Label
        Me.bgWorker = New System.ComponentModel.BackgroundWorker
        Me.TvaTa = New AgrigestEDI.dbDonneesDataSetTableAdapters.TVATableAdapter
        Me.PlcTa = New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
        Me.ActivitesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
        Me.PlanTypeTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
        Me.JournalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
        Me.CompteTotalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
        Me.ReglesValidationTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ReglesValidationTableAdapter
        DatePieceLabel = New System.Windows.Forms.Label
        LibelleLabel = New System.Windows.Forms.Label
        NPieceLabel = New System.Windows.Forms.Label
        JournalLabel = New System.Windows.Forms.Label
        CType(Me.ListOfPiecesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ListOfPiecesBindingNavigator.SuspendLayout()
        CType(Me.PiecesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelLock.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatePieceLabel
        '
        DatePieceLabel.AutoSize = True
        DatePieceLabel.Location = New System.Drawing.Point(368, 22)
        DatePieceLabel.Name = "DatePieceLabel"
        DatePieceLabel.Size = New System.Drawing.Size(33, 13)
        DatePieceLabel.TabIndex = 4
        DatePieceLabel.Text = "Date:"
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(6, 69)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(95, 13)
        LibelleLabel.TabIndex = 7
        LibelleLabel.Text = "Libellé de la pièce:"
        '
        'NPieceLabel
        '
        NPieceLabel.AutoSize = True
        NPieceLabel.Location = New System.Drawing.Point(250, 22)
        NPieceLabel.Name = "NPieceLabel"
        NPieceLabel.Size = New System.Drawing.Size(50, 13)
        NPieceLabel.TabIndex = 2
        NPieceLabel.Text = "Pièce n°:"
        '
        'JournalLabel
        '
        JournalLabel.AutoSize = True
        JournalLabel.Location = New System.Drawing.Point(8, 23)
        JournalLabel.Name = "JournalLabel"
        JournalLabel.Size = New System.Drawing.Size(44, 13)
        JournalLabel.TabIndex = 0
        JournalLabel.Text = "Journal:"
        '
        'ListOfPiecesBindingNavigator
        '
        Me.ListOfPiecesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ListOfPiecesBindingNavigator.BindingSource = Me.PiecesBindingSource
        Me.ListOfPiecesBindingNavigator.CountItem = Nothing
        Me.ListOfPiecesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ListOfPiecesBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ListOfPiecesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar, Me.CMenuAction, Me.BindingNavigatorSeparator, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TbClose, Me.ToolStripSeparator2, Me.ListOfPiecesBindingNavigatorCleanItem, Me.ListOfPiecesBindingNavigatorCloseTVAItem, Me.ListOfPiecesBindingNavigatorCloseItem, Me.ListOfPiecesBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.AjouterCompteToolStripButton, Me.ModifierUnCompteToolStripButton, Me.ListOfPiecesBindingNavigatorModeleItem, Me.ListOfPiecesBindingNavigatorAddModeleItem, Me.ListOfPiecesBindingNavigatorFindCompteItem})
        Me.ListOfPiecesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ListOfPiecesBindingNavigator.MoveFirstItem = Nothing
        Me.ListOfPiecesBindingNavigator.MoveLastItem = Nothing
        Me.ListOfPiecesBindingNavigator.MoveNextItem = Nothing
        Me.ListOfPiecesBindingNavigator.MovePreviousItem = Nothing
        Me.ListOfPiecesBindingNavigator.Name = "ListOfPiecesBindingNavigator"
        Me.ListOfPiecesBindingNavigator.PositionItem = Nothing
        Me.ListOfPiecesBindingNavigator.Size = New System.Drawing.Size(1016, 25)
        Me.ListOfPiecesBindingNavigator.TabIndex = 0
        Me.ListOfPiecesBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter une nouvelle pièce"
        Me.BindingNavigatorAddNewItem.Visible = False
        '
        'PiecesBindingSource
        '
        Me.PiecesBindingSource.DataSource = GetType(AgrigestEDI.Piece)
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer la pièce"
        Me.BindingNavigatorDeleteItem.Visible = False
        '
        'progressBar
        '
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(100, 22)
        '
        'CMenuAction
        '
        Me.CMenuAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CMenuAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuNew, Me.CMenuDelete, Me.ToolStripSeparator5, Me.CMenuReinitialiser, Me.CMenuTVA, Me.CMenuSolde, Me.CMenuEnregistrer, Me.ToolStripSeparator6, Me.CMenuCompte, Me.CMenuModifierCompte, Me.ToolStripSeparator8, Me.CMenuInsertModele, Me.CMenuEnregistrerModele, Me.CMenuRecherche})
        Me.CMenuAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CMenuAction.Name = "CMenuAction"
        Me.CMenuAction.Size = New System.Drawing.Size(55, 22)
        Me.CMenuAction.Text = "Action"
        '
        'CMenuNew
        '
        Me.CMenuNew.Image = CType(resources.GetObject("CMenuNew.Image"), System.Drawing.Image)
        Me.CMenuNew.Name = "CMenuNew"
        Me.CMenuNew.Size = New System.Drawing.Size(260, 22)
        Me.CMenuNew.Text = "Nouvelle pièce"
        Me.CMenuNew.Visible = False
        '
        'CMenuDelete
        '
        Me.CMenuDelete.Image = CType(resources.GetObject("CMenuDelete.Image"), System.Drawing.Image)
        Me.CMenuDelete.Name = "CMenuDelete"
        Me.CMenuDelete.Size = New System.Drawing.Size(260, 22)
        Me.CMenuDelete.Text = "Supprimer la pièce"
        Me.CMenuDelete.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(257, 6)
        Me.ToolStripSeparator5.Visible = False
        '
        'CMenuReinitialiser
        '
        Me.CMenuReinitialiser.Image = CType(resources.GetObject("CMenuReinitialiser.Image"), System.Drawing.Image)
        Me.CMenuReinitialiser.Name = "CMenuReinitialiser"
        Me.CMenuReinitialiser.Size = New System.Drawing.Size(260, 22)
        Me.CMenuReinitialiser.Text = "Ré-initialiser"
        '
        'CMenuTVA
        '
        Me.CMenuTVA.Image = CType(resources.GetObject("CMenuTVA.Image"), System.Drawing.Image)
        Me.CMenuTVA.Name = "CMenuTVA"
        Me.CMenuTVA.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.CMenuTVA.Size = New System.Drawing.Size(260, 22)
        Me.CMenuTVA.Text = "Calcul de la TVA"
        '
        'CMenuSolde
        '
        Me.CMenuSolde.Image = CType(resources.GetObject("CMenuSolde.Image"), System.Drawing.Image)
        Me.CMenuSolde.Name = "CMenuSolde"
        Me.CMenuSolde.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.CMenuSolde.Size = New System.Drawing.Size(260, 22)
        Me.CMenuSolde.Text = "Solde de la pièce"
        '
        'CMenuEnregistrer
        '
        Me.CMenuEnregistrer.Image = CType(resources.GetObject("CMenuEnregistrer.Image"), System.Drawing.Image)
        Me.CMenuEnregistrer.Name = "CMenuEnregistrer"
        Me.CMenuEnregistrer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.CMenuEnregistrer.Size = New System.Drawing.Size(260, 22)
        Me.CMenuEnregistrer.Text = "Enregistrement de la pièce"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(257, 6)
        '
        'CMenuCompte
        '
        Me.CMenuCompte.Image = CType(resources.GetObject("CMenuCompte.Image"), System.Drawing.Image)
        Me.CMenuCompte.Name = "CMenuCompte"
        Me.CMenuCompte.Size = New System.Drawing.Size(260, 22)
        Me.CMenuCompte.Text = "Ajouter un compte..."
        '
        'CMenuModifierCompte
        '
        Me.CMenuModifierCompte.Image = CType(resources.GetObject("CMenuModifierCompte.Image"), System.Drawing.Image)
        Me.CMenuModifierCompte.Name = "CMenuModifierCompte"
        Me.CMenuModifierCompte.Size = New System.Drawing.Size(260, 22)
        Me.CMenuModifierCompte.Text = "Modifier un compte..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(257, 6)
        '
        'CMenuInsertModele
        '
        Me.CMenuInsertModele.Image = CType(resources.GetObject("CMenuInsertModele.Image"), System.Drawing.Image)
        Me.CMenuInsertModele.Name = "CMenuInsertModele"
        Me.CMenuInsertModele.Size = New System.Drawing.Size(260, 22)
        Me.CMenuInsertModele.Text = "Insérer un modèle..."
        '
        'CMenuEnregistrerModele
        '
        Me.CMenuEnregistrerModele.Image = CType(resources.GetObject("CMenuEnregistrerModele.Image"), System.Drawing.Image)
        Me.CMenuEnregistrerModele.Name = "CMenuEnregistrerModele"
        Me.CMenuEnregistrerModele.Size = New System.Drawing.Size(260, 22)
        Me.CMenuEnregistrerModele.Text = "Enregistrer la pièce comme modèle"
        '
        'CMenuRecherche
        '
        Me.CMenuRecherche.Image = CType(resources.GetObject("CMenuRecherche.Image"), System.Drawing.Image)
        Me.CMenuRecherche.Name = "CMenuRecherche"
        Me.CMenuRecherche.Size = New System.Drawing.Size(260, 22)
        Me.CMenuRecherche.Text = "Recherche d'un compte"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        Me.BindingNavigatorSeparator.Visible = False
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = CType(resources.GetObject("TbClose.Image"), System.Drawing.Image)
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 22)
        Me.TbClose.Text = "Fermer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator2.Visible = False
        '
        'ListOfPiecesBindingNavigatorCleanItem
        '
        Me.ListOfPiecesBindingNavigatorCleanItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorCleanItem.Image = CType(resources.GetObject("ListOfPiecesBindingNavigatorCleanItem.Image"), System.Drawing.Image)
        Me.ListOfPiecesBindingNavigatorCleanItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorCleanItem.Name = "ListOfPiecesBindingNavigatorCleanItem"
        Me.ListOfPiecesBindingNavigatorCleanItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorCleanItem.Text = "Réinitialiser la pièce"
        Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
        '
        'ListOfPiecesBindingNavigatorCloseTVAItem
        '
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Image = CType(resources.GetObject("ListOfPiecesBindingNavigatorCloseTVAItem.Image"), System.Drawing.Image)
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Name = "ListOfPiecesBindingNavigatorCloseTVAItem"
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Text = "Calculer la TVA (Ctrl+T)"
        '
        'ListOfPiecesBindingNavigatorCloseItem
        '
        Me.ListOfPiecesBindingNavigatorCloseItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorCloseItem.Enabled = False
        Me.ListOfPiecesBindingNavigatorCloseItem.Image = CType(resources.GetObject("ListOfPiecesBindingNavigatorCloseItem.Image"), System.Drawing.Image)
        Me.ListOfPiecesBindingNavigatorCloseItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorCloseItem.Name = "ListOfPiecesBindingNavigatorCloseItem"
        Me.ListOfPiecesBindingNavigatorCloseItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorCloseItem.Text = "Solder la pièce (Ctrl+E)"
        '
        'ListOfPiecesBindingNavigatorSaveItem
        '
        Me.ListOfPiecesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorSaveItem.Enabled = False
        Me.ListOfPiecesBindingNavigatorSaveItem.Image = CType(resources.GetObject("ListOfPiecesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ListOfPiecesBindingNavigatorSaveItem.Name = "ListOfPiecesBindingNavigatorSaveItem"
        Me.ListOfPiecesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorSaveItem.Text = "Enregistrement de la pièce (Ctrl+N)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'AjouterCompteToolStripButton
        '
        Me.AjouterCompteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AjouterCompteToolStripButton.Image = CType(resources.GetObject("AjouterCompteToolStripButton.Image"), System.Drawing.Image)
        Me.AjouterCompteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AjouterCompteToolStripButton.Name = "AjouterCompteToolStripButton"
        Me.AjouterCompteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AjouterCompteToolStripButton.Text = "Ajouter un compte"
        '
        'ModifierUnCompteToolStripButton
        '
        Me.ModifierUnCompteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ModifierUnCompteToolStripButton.Image = CType(resources.GetObject("ModifierUnCompteToolStripButton.Image"), System.Drawing.Image)
        Me.ModifierUnCompteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ModifierUnCompteToolStripButton.Name = "ModifierUnCompteToolStripButton"
        Me.ModifierUnCompteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ModifierUnCompteToolStripButton.Text = "Modifier un compte"
        '
        'ListOfPiecesBindingNavigatorModeleItem
        '
        Me.ListOfPiecesBindingNavigatorModeleItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorModeleItem.Enabled = False
        Me.ListOfPiecesBindingNavigatorModeleItem.Image = CType(resources.GetObject("ListOfPiecesBindingNavigatorModeleItem.Image"), System.Drawing.Image)
        Me.ListOfPiecesBindingNavigatorModeleItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorModeleItem.Name = "ListOfPiecesBindingNavigatorModeleItem"
        Me.ListOfPiecesBindingNavigatorModeleItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorModeleItem.Text = "Insérer un modèle"
        '
        'ListOfPiecesBindingNavigatorAddModeleItem
        '
        Me.ListOfPiecesBindingNavigatorAddModeleItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Image = CType(resources.GetObject("ListOfPiecesBindingNavigatorAddModeleItem.Image"), System.Drawing.Image)
        Me.ListOfPiecesBindingNavigatorAddModeleItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Name = "ListOfPiecesBindingNavigatorAddModeleItem"
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Text = "Enregistrer la pièce comme modèle"
        '
        'ListOfPiecesBindingNavigatorFindCompteItem
        '
        Me.ListOfPiecesBindingNavigatorFindCompteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Image = CType(resources.GetObject("ListOfPiecesBindingNavigatorFindCompteItem.Image"), System.Drawing.Image)
        Me.ListOfPiecesBindingNavigatorFindCompteItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Name = "ListOfPiecesBindingNavigatorFindCompteItem"
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Text = "Recherche d'un compte"
        Me.ListOfPiecesBindingNavigatorFindCompteItem.ToolTipText = "Recherche d'un compte (Ctrl+F)"
        '
        'DatePieceDtp
        '
        Me.DatePieceDtp.CustomFormat = ""
        Me.DatePieceDtp.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.PiecesBindingSource, "DatePiece", True))
        Me.DatePieceDtp.Enabled = False
        Me.DatePieceDtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePieceDtp.Location = New System.Drawing.Point(407, 18)
        Me.DatePieceDtp.Name = "DatePieceDtp"
        Me.DatePieceDtp.Size = New System.Drawing.Size(85, 20)
        Me.DatePieceDtp.TabIndex = 5
        Me.DatePieceDtp.Value = New Date(2010, 7, 20, 15, 46, 56, 0)
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.AcceptsReturn = True
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PiecesBindingSource, "Libelle", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(104, 66)
        Me.LibelleTextBox.MaxLength = 50
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.Size = New System.Drawing.Size(388, 20)
        Me.LibelleTextBox.TabIndex = 8
        '
        'NPieceTextBox
        '
        Me.NPieceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PiecesBindingSource, "NPiece", True))
        Me.NPieceTextBox.Enabled = False
        Me.NPieceTextBox.Location = New System.Drawing.Point(306, 18)
        Me.NPieceTextBox.MaxLength = 8
        Me.NPieceTextBox.Name = "NPieceTextBox"
        Me.NPieceTextBox.Size = New System.Drawing.Size(56, 20)
        Me.NPieceTextBox.TabIndex = 3
        Me.NPieceTextBox.Text = "00000000"
        Me.NPieceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblActivite)
        Me.GroupBox1.Controls.Add(Me.lblCompte)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Controls.Add(Me.chkMontantTTC)
        Me.GroupBox1.Controls.Add(JournalLabel)
        Me.GroupBox1.Controls.Add(Me.JournalComboBox)
        Me.GroupBox1.Controls.Add(Me.NPieceTextBox)
        Me.GroupBox1.Controls.Add(NPieceLabel)
        Me.GroupBox1.Controls.Add(DatePieceLabel)
        Me.GroupBox1.Controls.Add(Me.LibelleTextBox)
        Me.GroupBox1.Controls.Add(Me.DatePieceDtp)
        Me.GroupBox1.Controls.Add(LibelleLabel)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1016, 93)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Infos Pièces"
        '
        'lblActivite
        '
        Me.lblActivite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivite.AutoEllipsis = True
        Me.lblActivite.Location = New System.Drawing.Point(640, 52)
        Me.lblActivite.Name = "lblActivite"
        Me.lblActivite.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblActivite.Size = New System.Drawing.Size(180, 13)
        Me.lblActivite.TabIndex = 10
        Me.lblActivite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCompte
        '
        Me.lblCompte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompte.AutoEllipsis = True
        Me.lblCompte.Location = New System.Drawing.Point(640, 32)
        Me.lblCompte.Name = "lblCompte"
        Me.lblCompte.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCompte.Size = New System.Drawing.Size(180, 13)
        Me.lblCompte.TabIndex = 9
        Me.lblCompte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblDebitBalance, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCreditBalance, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDebit, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCredit, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDebitLib, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblCreditLib, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(826, 10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(178, 64)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'lblDebitBalance
        '
        Me.lblDebitBalance.AutoSize = True
        Me.lblDebitBalance.Location = New System.Drawing.Point(4, 43)
        Me.lblDebitBalance.Name = "lblDebitBalance"
        Me.lblDebitBalance.Size = New System.Drawing.Size(13, 13)
        Me.lblDebitBalance.TabIndex = 0
        Me.lblDebitBalance.Text = "0"
        '
        'lblCreditBalance
        '
        Me.lblCreditBalance.AutoSize = True
        Me.lblCreditBalance.Location = New System.Drawing.Point(92, 43)
        Me.lblCreditBalance.Name = "lblCreditBalance"
        Me.lblCreditBalance.Size = New System.Drawing.Size(13, 13)
        Me.lblCreditBalance.TabIndex = 1
        Me.lblCreditBalance.Text = "0"
        '
        'lblDebit
        '
        Me.lblDebit.AutoSize = True
        Me.lblDebit.Location = New System.Drawing.Point(4, 22)
        Me.lblDebit.Name = "lblDebit"
        Me.lblDebit.Size = New System.Drawing.Size(13, 13)
        Me.lblDebit.TabIndex = 2
        Me.lblDebit.Text = "0"
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Location = New System.Drawing.Point(92, 22)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(13, 13)
        Me.lblCredit.TabIndex = 3
        Me.lblCredit.Text = "0"
        '
        'lblDebitLib
        '
        Me.lblDebitLib.AutoSize = True
        Me.lblDebitLib.Location = New System.Drawing.Point(4, 1)
        Me.lblDebitLib.Name = "lblDebitLib"
        Me.lblDebitLib.Size = New System.Drawing.Size(32, 13)
        Me.lblDebitLib.TabIndex = 4
        Me.lblDebitLib.Text = "Débit"
        '
        'lblCreditLib
        '
        Me.lblCreditLib.AutoSize = True
        Me.lblCreditLib.Location = New System.Drawing.Point(92, 1)
        Me.lblCreditLib.Name = "lblCreditLib"
        Me.lblCreditLib.Size = New System.Drawing.Size(34, 13)
        Me.lblCreditLib.TabIndex = 5
        Me.lblCreditLib.Text = "Crédit"
        '
        'chkMontantTTC
        '
        Me.chkMontantTTC.AutoSize = True
        Me.chkMontantTTC.Location = New System.Drawing.Point(9, 44)
        Me.chkMontantTTC.Name = "chkMontantTTC"
        Me.chkMontantTTC.Size = New System.Drawing.Size(159, 17)
        Me.chkMontantTTC.TabIndex = 6
        Me.chkMontantTTC.TabStop = False
        Me.chkMontantTTC.Text = "Saisie des montants en TTC"
        Me.chkMontantTTC.UseVisualStyleBackColor = True
        '
        'JournalComboBox
        '
        Me.JournalComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.JournalComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.JournalComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PiecesBindingSource, "Journal", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.JournalComboBox.DataSource = Me.JournalBindingSource
        Me.JournalComboBox.DisplayMember = "JournalDisplay"
        Me.JournalComboBox.FormattingEnabled = True
        Me.JournalComboBox.Location = New System.Drawing.Point(58, 19)
        Me.JournalComboBox.Name = "JournalComboBox"
        Me.JournalComboBox.Size = New System.Drawing.Size(186, 21)
        Me.JournalComboBox.TabIndex = 1
        Me.JournalComboBox.ValueMember = "JCodeJournal"
        '
        'JournalBindingSource
        '
        Me.JournalBindingSource.DataMember = "Journal"
        Me.JournalBindingSource.DataSource = Me.dsAgrigest
        Me.JournalBindingSource.Sort = "JCodeJournal"
        '
        'dsAgrigest
        '
        Me.dsAgrigest.DataSetName = "dbDonneesDataSet"
        Me.dsAgrigest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LignesBindingSource
        '
        Me.LignesBindingSource.DataMember = "Lignes"
        Me.LignesBindingSource.DataSource = Me.PiecesBindingSource
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grille)
        Me.Panel1.Controls.Add(Me.PanelLock)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 118)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(1016, 346)
        Me.Panel1.TabIndex = 2
        '
        'grille
        '
        Me.grille.Dataset = Nothing
        Me.grille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grille.JournalCptContre = ""
        Me.grille.JournalCptContreLib = ""
        Me.grille.Location = New System.Drawing.Point(5, 5)
        Me.grille.MontantTTC = False
        Me.grille.Name = "grille"
        Me.grille.PieceDataMember = Nothing
        Me.grille.PieceDatasource = Nothing
        Me.grille.Size = New System.Drawing.Size(1006, 336)
        Me.grille.TabIndex = 0
        '
        'PanelLock
        '
        Me.PanelLock.AntiAlias = True
        Me.PanelLock.Border = New Ascend.Border(1)
        Me.PanelLock.BorderColor = New Ascend.BorderColor(System.Drawing.Color.YellowGreen)
        Me.PanelLock.Controls.Add(Me.lblJournalError)
        Me.PanelLock.CornerRadius = New Ascend.CornerRadius(10)
        Me.PanelLock.GradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelLock.GradientLowColor = System.Drawing.Color.YellowGreen
        Me.PanelLock.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.PanelLock.Location = New System.Drawing.Point(276, 66)
        Me.PanelLock.Name = "PanelLock"
        Me.PanelLock.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.PanelLock.Size = New System.Drawing.Size(304, 38)
        Me.PanelLock.TabIndex = 3
        '
        'lblJournalError
        '
        Me.lblJournalError.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblJournalError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJournalError.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblJournalError.Location = New System.Drawing.Point(0, 0)
        Me.lblJournalError.Name = "lblJournalError"
        Me.lblJournalError.Size = New System.Drawing.Size(304, 38)
        Me.lblJournalError.TabIndex = 0
        Me.lblJournalError.Text = "Veuillez sélectionner un journal"
        Me.lblJournalError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        '
        'TvaTa
        '
        Me.TvaTa.ClearBeforeFill = True
        '
        'PlcTa
        '
        Me.PlcTa.ClearBeforeFill = True
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
        '
        'JournalTableAdapter
        '
        Me.JournalTableAdapter.ClearBeforeFill = True
        '
        'CompteTotalTableAdapter
        '
        Me.CompteTotalTableAdapter.ClearBeforeFill = True
        '
        'ReglesValidationTableAdapter
        '
        Me.ReglesValidationTableAdapter.ClearBeforeFill = True
        '
        'FrSaisiePiece
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListOfPiecesBindingNavigator)
        Me.Name = "FrSaisiePiece"
        Me.Text = "Saisir des écritures"
        CType(Me.ListOfPiecesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ListOfPiecesBindingNavigator.ResumeLayout(False)
        Me.ListOfPiecesBindingNavigator.PerformLayout()
        CType(Me.PiecesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.PanelLock.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PiecesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListOfPiecesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListOfPiecesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents DatePieceDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NPieceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LignesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents progressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents dsAgrigest As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents TvaTa As AgrigestEDI.dbDonneesDataSetTableAdapters.TVATableAdapter
    Friend WithEvents JournalComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PlcTa As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
    Friend WithEvents ListOfPiecesBindingNavigatorCloseItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
    Friend WithEvents ListOfPiecesBindingNavigatorCloseTVAItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelLock As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents lblJournalError As System.Windows.Forms.Label
    Friend WithEvents ListOfPiecesBindingNavigatorCleanItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AjouterCompteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkMontantTTC As System.Windows.Forms.CheckBox
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
    Friend WithEvents JournalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents JournalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
    Friend WithEvents lblActivite As System.Windows.Forms.Label
    Friend WithEvents lblCompte As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDebitBalance As System.Windows.Forms.Label
    Friend WithEvents lblCreditBalance As System.Windows.Forms.Label
    Friend WithEvents lblDebit As System.Windows.Forms.Label
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents lblDebitLib As System.Windows.Forms.Label
    Friend WithEvents lblCreditLib As System.Windows.Forms.Label
    Friend WithEvents ListOfPiecesBindingNavigatorModeleItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListOfPiecesBindingNavigatorAddModeleItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CompteTotalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
    Friend WithEvents CMenuAction As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CMenuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMenuReinitialiser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuTVA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuSolde As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuEnregistrer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMenuCompte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuInsertModele As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuEnregistrerModele As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModifierUnCompteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMenuModifierCompte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grille As AgrigestEDI.UcGrilleSaisieLignes
    Friend WithEvents ReglesValidationTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ReglesValidationTableAdapter
    Friend WithEvents ListOfPiecesBindingNavigatorFindCompteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMenuRecherche As System.Windows.Forms.ToolStripMenuItem

End Class

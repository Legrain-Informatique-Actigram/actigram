<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrBordereau
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.bgWorker = New System.ComponentModel.BackgroundWorker
        Me.ListOfPiecesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.progressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuAction = New System.Windows.Forms.ToolStripDropDownButton
        Me.CMenuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuModif = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuReinitialiser = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuTVA = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuSolde = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuEnregistrer = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuCompte = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuModifierUnCompte = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuInsertModele = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuEnregistrerModele = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuRecherche = New System.Windows.Forms.ToolStripMenuItem
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ListOfPiecesBindingNavigatorAddItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorModifPiece = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ListOfPiecesBindingNavigatorCleanItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorCloseTVAItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorCloseItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.AjouterCompteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ModifierCompteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorModeleItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorAddModeleItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorFindCompteItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.gpbPiece = New System.Windows.Forms.GroupBox
        Me.PiecesDgv = New AgrigestEDI.DataGridViewEnter
        Me.PdgvPiece = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.PdgvDatePiece = New AgrigestEDI.DatagridViewDatePickerColumn
        Me.PdgvLibelle = New AgrigestEDI.DatagridViewTextBoxAutoCompleteColumn
        Me.PdgvDebit = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.PdgvCredit = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.PdgvTotalContrePartie = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.CMSPieceGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuAddPiece = New System.Windows.Forms.ToolStripMenuItem
        Me.CMSMenuModifConsultPiece = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuDeletePiece = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuCopyPiece = New System.Windows.Forms.ToolStripMenuItem
        Me.PiecesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gpbTotalCompte = New System.Windows.Forms.GroupBox
        Me.lblActivite = New System.Windows.Forms.Label
        Me.lblCompte = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblDebitBalance = New System.Windows.Forms.Label
        Me.lblCreditBalance = New System.Windows.Forms.Label
        Me.lblDebit = New System.Windows.Forms.Label
        Me.lblCredit = New System.Windows.Forms.Label
        Me.lblDebitLib = New System.Windows.Forms.Label
        Me.lblCreditLib = New System.Windows.Forms.Label
        Me.PieceLibBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsAgrigest = New AgrigestEDI.dbDonneesDataSet
        Me.gpbLigne = New System.Windows.Forms.GroupBox
        Me.UcGrilleSaisieLignes1 = New AgrigestEDI.UcGrilleSaisieLignes
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PiecesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
        Me.LignesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.LignesTableAdapter
        Me.TvaTa = New AgrigestEDI.dbDonneesDataSetTableAdapters.TVATableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
        Me.PlcTa = New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
        Me.ActivitesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
        Me.PlanTypeTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
        Me.CompteTotalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
        Me.ReglesValidationTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ReglesValidationTableAdapter
        Me.CMSPieceConsultation = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMenuModifConsultPiece = New System.Windows.Forms.ToolStripMenuItem
        Me.CMSMenuSupprConsultPiece = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.ListOfPiecesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ListOfPiecesBindingNavigator.SuspendLayout()
        Me.gpbPiece.SuspendLayout()
        CType(Me.PiecesDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSPieceGrid.SuspendLayout()
        CType(Me.PiecesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbTotalCompte.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PieceLibBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsAgrigest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbLigne.SuspendLayout()
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSPieceConsultation.SuspendLayout()
        Me.SuspendLayout()
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        '
        'ListOfPiecesBindingNavigator
        '
        Me.ListOfPiecesBindingNavigator.AddNewItem = Nothing
        Me.ListOfPiecesBindingNavigator.CountItem = Nothing
        Me.ListOfPiecesBindingNavigator.DeleteItem = Nothing
        Me.ListOfPiecesBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ListOfPiecesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar, Me.ToolStripSeparator7, Me.CMenuAction, Me.BindingNavigatorSeparator, Me.ListOfPiecesBindingNavigatorAddItem, Me.ListOfPiecesBindingNavigatorModifPiece, Me.ListOfPiecesBindingNavigatorDeleteItem, Me.TbClose, Me.ToolStripSeparator2, Me.ListOfPiecesBindingNavigatorCleanItem, Me.ListOfPiecesBindingNavigatorCloseTVAItem, Me.ListOfPiecesBindingNavigatorCloseItem, Me.ListOfPiecesBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.AjouterCompteToolStripButton, Me.ModifierCompteToolStripButton, Me.ListOfPiecesBindingNavigatorModeleItem, Me.ListOfPiecesBindingNavigatorAddModeleItem, Me.ListOfPiecesBindingNavigatorFindCompteItem})
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
        'progressBar
        '
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(100, 22)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'CMenuAction
        '
        Me.CMenuAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CMenuAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuNew, Me.CMenuModif, Me.CMenuDelete, Me.ToolStripSeparator5, Me.CMenuReinitialiser, Me.CMenuTVA, Me.CMenuSolde, Me.CMenuEnregistrer, Me.CMenuCompte, Me.CMenuModifierUnCompte, Me.ToolStripSeparator8, Me.CMenuInsertModele, Me.CMenuEnregistrerModele, Me.CMenuRecherche})
        Me.CMenuAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CMenuAction.Name = "CMenuAction"
        Me.CMenuAction.Size = New System.Drawing.Size(50, 22)
        Me.CMenuAction.Text = "Action"
        '
        'CMenuNew
        '
        Me.CMenuNew.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.CMenuNew.Name = "CMenuNew"
        Me.CMenuNew.Size = New System.Drawing.Size(251, 22)
        Me.CMenuNew.Text = "Nouvelle pièce"
        '
        'CMenuModif
        '
        Me.CMenuModif.Image = Global.AgrigestEDI.My.Resources.Resources.modif
        Me.CMenuModif.Name = "CMenuModif"
        Me.CMenuModif.Size = New System.Drawing.Size(251, 22)
        Me.CMenuModif.Text = "Modifiier la pièce"
        Me.CMenuModif.Visible = False
        '
        'CMenuDelete
        '
        Me.CMenuDelete.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.CMenuDelete.Name = "CMenuDelete"
        Me.CMenuDelete.Size = New System.Drawing.Size(251, 22)
        Me.CMenuDelete.Text = "Supprimer la pièce"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(248, 6)
        '
        'CMenuReinitialiser
        '
        Me.CMenuReinitialiser.Image = Global.AgrigestEDI.My.Resources.Resources.undo
        Me.CMenuReinitialiser.Name = "CMenuReinitialiser"
        Me.CMenuReinitialiser.Size = New System.Drawing.Size(251, 22)
        Me.CMenuReinitialiser.Text = "Ré-initialiser"
        '
        'CMenuTVA
        '
        Me.CMenuTVA.Image = Global.AgrigestEDI.My.Resources.Resources.calc
        Me.CMenuTVA.Name = "CMenuTVA"
        Me.CMenuTVA.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.CMenuTVA.Size = New System.Drawing.Size(251, 22)
        Me.CMenuTVA.Text = "Calcul de la TVA"
        '
        'CMenuSolde
        '
        Me.CMenuSolde.Image = Global.AgrigestEDI.My.Resources.Resources.check
        Me.CMenuSolde.Name = "CMenuSolde"
        Me.CMenuSolde.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.CMenuSolde.Size = New System.Drawing.Size(251, 22)
        Me.CMenuSolde.Text = "Solde de la pièce"
        '
        'CMenuEnregistrer
        '
        Me.CMenuEnregistrer.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.CMenuEnregistrer.Name = "CMenuEnregistrer"
        Me.CMenuEnregistrer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.CMenuEnregistrer.Size = New System.Drawing.Size(251, 22)
        Me.CMenuEnregistrer.Text = "Enregistrement de la pièce"
        '
        'CMenuCompte
        '
        Me.CMenuCompte.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.CMenuCompte.Name = "CMenuCompte"
        Me.CMenuCompte.Size = New System.Drawing.Size(251, 22)
        Me.CMenuCompte.Text = "Ajouter un compte..."
        '
        'CMenuModifierUnCompte
        '
        Me.CMenuModifierUnCompte.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.CMenuModifierUnCompte.Name = "CMenuModifierUnCompte"
        Me.CMenuModifierUnCompte.Size = New System.Drawing.Size(251, 22)
        Me.CMenuModifierUnCompte.Text = "Modifier un compte..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(248, 6)
        '
        'CMenuInsertModele
        '
        Me.CMenuInsertModele.Image = Global.AgrigestEDI.My.Resources.Resources.liste
        Me.CMenuInsertModele.Name = "CMenuInsertModele"
        Me.CMenuInsertModele.Size = New System.Drawing.Size(251, 22)
        Me.CMenuInsertModele.Text = "Insérer un modèle..."
        '
        'CMenuEnregistrerModele
        '
        Me.CMenuEnregistrerModele.Image = Global.AgrigestEDI.My.Resources.Resources.export
        Me.CMenuEnregistrerModele.Name = "CMenuEnregistrerModele"
        Me.CMenuEnregistrerModele.Size = New System.Drawing.Size(251, 22)
        Me.CMenuEnregistrerModele.Text = "Enregistrer la pièce comme modèle"
        '
        'CMenuRecherche
        '
        Me.CMenuRecherche.Image = Global.AgrigestEDI.My.Resources.Resources.find
        Me.CMenuRecherche.Name = "CMenuRecherche"
        Me.CMenuRecherche.Size = New System.Drawing.Size(251, 22)
        Me.CMenuRecherche.Text = "Recherche d'un compte"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ListOfPiecesBindingNavigatorAddItem
        '
        Me.ListOfPiecesBindingNavigatorAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorAddItem.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.ListOfPiecesBindingNavigatorAddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorAddItem.Name = "ListOfPiecesBindingNavigatorAddItem"
        Me.ListOfPiecesBindingNavigatorAddItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorAddItem.Text = "Ajouter une pièce"
        '
        'ListOfPiecesBindingNavigatorModifPiece
        '
        Me.ListOfPiecesBindingNavigatorModifPiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorModifPiece.Image = Global.AgrigestEDI.My.Resources.Resources.modif
        Me.ListOfPiecesBindingNavigatorModifPiece.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorModifPiece.Name = "ListOfPiecesBindingNavigatorModifPiece"
        Me.ListOfPiecesBindingNavigatorModifPiece.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorModifPiece.Text = "Modification de la pièce"
        Me.ListOfPiecesBindingNavigatorModifPiece.Visible = False
        '
        'ListOfPiecesBindingNavigatorDeleteItem
        '
        Me.ListOfPiecesBindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorDeleteItem.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.ListOfPiecesBindingNavigatorDeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorDeleteItem.Name = "ListOfPiecesBindingNavigatorDeleteItem"
        Me.ListOfPiecesBindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorDeleteItem.Text = "Supprimer une pièce"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgrigestEDI.My.Resources.Resources.close
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 22)
        Me.TbClose.Text = "Fermer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ListOfPiecesBindingNavigatorCleanItem
        '
        Me.ListOfPiecesBindingNavigatorCleanItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorCleanItem.Image = Global.AgrigestEDI.My.Resources.Resources.undo
        Me.ListOfPiecesBindingNavigatorCleanItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorCleanItem.Name = "ListOfPiecesBindingNavigatorCleanItem"
        Me.ListOfPiecesBindingNavigatorCleanItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorCleanItem.Text = "Réinitialiser la pièce"
        '
        'ListOfPiecesBindingNavigatorCloseTVAItem
        '
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Image = Global.AgrigestEDI.My.Resources.Resources.calc
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Name = "ListOfPiecesBindingNavigatorCloseTVAItem"
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorCloseTVAItem.Text = "Calculer la TVA (Ctrl+T)"
        '
        'ListOfPiecesBindingNavigatorCloseItem
        '
        Me.ListOfPiecesBindingNavigatorCloseItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorCloseItem.Enabled = False
        Me.ListOfPiecesBindingNavigatorCloseItem.Image = Global.AgrigestEDI.My.Resources.Resources.check
        Me.ListOfPiecesBindingNavigatorCloseItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorCloseItem.Name = "ListOfPiecesBindingNavigatorCloseItem"
        Me.ListOfPiecesBindingNavigatorCloseItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorCloseItem.Text = "Solder la pièce (Ctrl+E)"
        '
        'ListOfPiecesBindingNavigatorSaveItem
        '
        Me.ListOfPiecesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorSaveItem.Enabled = False
        Me.ListOfPiecesBindingNavigatorSaveItem.Image = Global.AgrigestEDI.My.Resources.Resources.save
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
        Me.AjouterCompteToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.AjouterCompteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AjouterCompteToolStripButton.Name = "AjouterCompteToolStripButton"
        Me.AjouterCompteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AjouterCompteToolStripButton.Text = "Ajouter un compte"
        '
        'ModifierCompteToolStripButton
        '
        Me.ModifierCompteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ModifierCompteToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.ModifierCompteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ModifierCompteToolStripButton.Name = "ModifierCompteToolStripButton"
        Me.ModifierCompteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ModifierCompteToolStripButton.Text = "Modifier un compte"
        '
        'ListOfPiecesBindingNavigatorModeleItem
        '
        Me.ListOfPiecesBindingNavigatorModeleItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorModeleItem.Enabled = False
        Me.ListOfPiecesBindingNavigatorModeleItem.Image = Global.AgrigestEDI.My.Resources.Resources.liste
        Me.ListOfPiecesBindingNavigatorModeleItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorModeleItem.Name = "ListOfPiecesBindingNavigatorModeleItem"
        Me.ListOfPiecesBindingNavigatorModeleItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorModeleItem.Text = "Liste des modèles"
        '
        'ListOfPiecesBindingNavigatorAddModeleItem
        '
        Me.ListOfPiecesBindingNavigatorAddModeleItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Image = Global.AgrigestEDI.My.Resources.Resources.export
        Me.ListOfPiecesBindingNavigatorAddModeleItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Name = "ListOfPiecesBindingNavigatorAddModeleItem"
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorAddModeleItem.Text = "Enregistrer le modèle"
        '
        'ListOfPiecesBindingNavigatorFindCompteItem
        '
        Me.ListOfPiecesBindingNavigatorFindCompteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Image = Global.AgrigestEDI.My.Resources.Resources.find
        Me.ListOfPiecesBindingNavigatorFindCompteItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Name = "ListOfPiecesBindingNavigatorFindCompteItem"
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Text = "Recherche d'un compte"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(179, 6)
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(248, 6)
        '
        'gpbPiece
        '
        Me.gpbPiece.Controls.Add(Me.PiecesDgv)
        Me.gpbPiece.Controls.Add(Me.gpbTotalCompte)
        Me.gpbPiece.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbPiece.Location = New System.Drawing.Point(0, 25)
        Me.gpbPiece.Name = "gpbPiece"
        Me.gpbPiece.Size = New System.Drawing.Size(1016, 265)
        Me.gpbPiece.TabIndex = 1
        Me.gpbPiece.TabStop = False
        '
        'PiecesDgv
        '
        Me.PiecesDgv.AllowUserToAddRows = False
        Me.PiecesDgv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PiecesDgv.AutoGenerateColumns = False
        Me.PiecesDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PiecesDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PiecesDgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.PiecesDgv.ColumnHeadersHeight = 35
        Me.PiecesDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PdgvPiece, Me.PdgvDatePiece, Me.PdgvLibelle, Me.PdgvDebit, Me.PdgvCredit, Me.PdgvTotalContrePartie})
        Me.PiecesDgv.ContextMenuStrip = Me.CMSPieceGrid
        Me.PiecesDgv.DataSource = Me.PiecesBindingSource
        Me.PiecesDgv.GridColor = System.Drawing.Color.LimeGreen
        Me.PiecesDgv.JumpToMontant = False
        Me.PiecesDgv.Location = New System.Drawing.Point(3, 16)
        Me.PiecesDgv.MultiSelect = False
        Me.PiecesDgv.Name = "PiecesDgv"
        Me.PiecesDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PiecesDgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.PiecesDgv.RowHeadersWidth = 25
        Me.PiecesDgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.PiecesDgv.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.PiecesDgv.RowTemplate.ContextMenuStrip = Me.CMSPieceGrid
        Me.PiecesDgv.Size = New System.Drawing.Size(806, 246)
        Me.PiecesDgv.TabIndex = 0
        '
        'PdgvPiece
        '
        Me.PdgvPiece.DataPropertyName = "NPiece"
        Me.PdgvPiece.HeaderText = "Numéro de la pièce"
        Me.PdgvPiece.MaxInputLength = 5
        Me.PdgvPiece.Name = "PdgvPiece"
        Me.PdgvPiece.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PdgvPiece.Width = 80
        '
        'PdgvDatePiece
        '
        Me.PdgvDatePiece.DataPropertyName = "DatePiece"
        Me.PdgvDatePiece.HeaderText = "Date de la pièce"
        Me.PdgvDatePiece.MaxDate = New Date(CType(0, Long))
        Me.PdgvDatePiece.MinDate = New Date(CType(0, Long))
        Me.PdgvDatePiece.Name = "PdgvDatePiece"
        Me.PdgvDatePiece.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PdgvDatePiece.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PdgvDatePiece.Width = 80
        '
        'PdgvLibelle
        '
        Me.PdgvLibelle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None
        Me.PdgvLibelle.AutocompleteString = Nothing
        Me.PdgvLibelle.DataPropertyName = "Libelle"
        Me.PdgvLibelle.HeaderText = "Libellé de la pièce"
        Me.PdgvLibelle.MaxLenght = 0
        Me.PdgvLibelle.Name = "PdgvLibelle"
        Me.PdgvLibelle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PdgvLibelle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PdgvLibelle.Width = 200
        '
        'PdgvDebit
        '
        Me.PdgvDebit.DataPropertyName = "MontantDebContrePartie"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        Me.PdgvDebit.DefaultCellStyle = DataGridViewCellStyle8
        Me.PdgvDebit.HeaderText = "Débit"
        Me.PdgvDebit.Name = "PdgvDebit"
        Me.PdgvDebit.Width = 80
        '
        'PdgvCredit
        '
        Me.PdgvCredit.DataPropertyName = "MontantCreContrePartie"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C2"
        Me.PdgvCredit.DefaultCellStyle = DataGridViewCellStyle9
        Me.PdgvCredit.HeaderText = "Crédit"
        Me.PdgvCredit.Name = "PdgvCredit"
        Me.PdgvCredit.Width = 80
        '
        'PdgvTotalContrePartie
        '
        Me.PdgvTotalContrePartie.DataPropertyName = "SoldeContrePartie"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C2"
        Me.PdgvTotalContrePartie.DefaultCellStyle = DataGridViewCellStyle10
        Me.PdgvTotalContrePartie.HeaderText = "Solde de la contre partie"
        Me.PdgvTotalContrePartie.Name = "PdgvTotalContrePartie"
        Me.PdgvTotalContrePartie.Width = 80
        '
        'CMSPieceGrid
        '
        Me.CMSPieceGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuAddPiece, Me.CMSMenuModifConsultPiece, Me.ToolStripMenuDeletePiece, Me.ToolStripSeparator6, Me.ToolStripMenuCopyPiece})
        Me.CMSPieceGrid.Name = "CMSLigneGrid"
        Me.CMSPieceGrid.Size = New System.Drawing.Size(183, 98)
        '
        'ToolStripMenuAddPiece
        '
        Me.ToolStripMenuAddPiece.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.ToolStripMenuAddPiece.Name = "ToolStripMenuAddPiece"
        Me.ToolStripMenuAddPiece.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuAddPiece.Text = "Ajouter une piece..."
        '
        'CMSMenuModifConsultPiece
        '
        Me.CMSMenuModifConsultPiece.Image = Global.AgrigestEDI.My.Resources.Resources.modif
        Me.CMSMenuModifConsultPiece.Name = "CMSMenuModifConsultPiece"
        Me.CMSMenuModifConsultPiece.Size = New System.Drawing.Size(182, 22)
        Me.CMSMenuModifConsultPiece.Text = "Modifier la pièce"
        '
        'ToolStripMenuDeletePiece
        '
        Me.ToolStripMenuDeletePiece.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.ToolStripMenuDeletePiece.Name = "ToolStripMenuDeletePiece"
        Me.ToolStripMenuDeletePiece.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuDeletePiece.Text = "Supprimer la pièce"
        '
        'ToolStripMenuCopyPiece
        '
        Me.ToolStripMenuCopyPiece.Image = Global.AgrigestEDI.My.Resources.Resources.copy
        Me.ToolStripMenuCopyPiece.Name = "ToolStripMenuCopyPiece"
        Me.ToolStripMenuCopyPiece.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuCopyPiece.Text = "Copier la pièce"
        '
        'PiecesBindingSource
        '
        Me.PiecesBindingSource.DataSource = GetType(AgrigestEDI.Piece)
        '
        'gpbTotalCompte
        '
        Me.gpbTotalCompte.Controls.Add(Me.lblActivite)
        Me.gpbTotalCompte.Controls.Add(Me.lblCompte)
        Me.gpbTotalCompte.Controls.Add(Me.TableLayoutPanel1)
        Me.gpbTotalCompte.Dock = System.Windows.Forms.DockStyle.Right
        Me.gpbTotalCompte.Location = New System.Drawing.Point(813, 16)
        Me.gpbTotalCompte.Name = "gpbTotalCompte"
        Me.gpbTotalCompte.Size = New System.Drawing.Size(200, 246)
        Me.gpbTotalCompte.TabIndex = 1
        Me.gpbTotalCompte.TabStop = False
        '
        'lblActivite
        '
        Me.lblActivite.AutoSize = True
        Me.lblActivite.Location = New System.Drawing.Point(16, 155)
        Me.lblActivite.Name = "lblActivite"
        Me.lblActivite.Size = New System.Drawing.Size(0, 13)
        Me.lblActivite.TabIndex = 1
        '
        'lblCompte
        '
        Me.lblCompte.AutoSize = True
        Me.lblCompte.Location = New System.Drawing.Point(16, 135)
        Me.lblCompte.Name = "lblCompte"
        Me.lblCompte.Size = New System.Drawing.Size(0, 13)
        Me.lblCompte.TabIndex = 0
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(13, 175)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(178, 65)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'lblDebitBalance
        '
        Me.lblDebitBalance.AutoSize = True
        Me.lblDebitBalance.Location = New System.Drawing.Point(4, 43)
        Me.lblDebitBalance.Name = "lblDebitBalance"
        Me.lblDebitBalance.Size = New System.Drawing.Size(13, 13)
        Me.lblDebitBalance.TabIndex = 4
        Me.lblDebitBalance.Text = "0"
        '
        'lblCreditBalance
        '
        Me.lblCreditBalance.AutoSize = True
        Me.lblCreditBalance.Location = New System.Drawing.Point(92, 43)
        Me.lblCreditBalance.Name = "lblCreditBalance"
        Me.lblCreditBalance.Size = New System.Drawing.Size(13, 13)
        Me.lblCreditBalance.TabIndex = 5
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
        Me.lblDebitLib.TabIndex = 0
        Me.lblDebitLib.Text = "Débit"
        '
        'lblCreditLib
        '
        Me.lblCreditLib.AutoSize = True
        Me.lblCreditLib.Location = New System.Drawing.Point(92, 1)
        Me.lblCreditLib.Name = "lblCreditLib"
        Me.lblCreditLib.Size = New System.Drawing.Size(34, 13)
        Me.lblCreditLib.TabIndex = 1
        Me.lblCreditLib.Text = "Crédit"
        '
        'PieceLibBindingSource
        '
        Me.PieceLibBindingSource.DataMember = "Pieces"
        Me.PieceLibBindingSource.DataSource = Me.dsAgrigest
        Me.PieceLibBindingSource.Filter = "Libelle<>''"
        '
        'dsAgrigest
        '
        Me.dsAgrigest.DataSetName = "dbDonneesDataSet"
        Me.dsAgrigest.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gpbLigne
        '
        Me.gpbLigne.Controls.Add(Me.UcGrilleSaisieLignes1)
        Me.gpbLigne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpbLigne.Location = New System.Drawing.Point(0, 290)
        Me.gpbLigne.Name = "gpbLigne"
        Me.gpbLigne.Size = New System.Drawing.Size(1016, 323)
        Me.gpbLigne.TabIndex = 2
        Me.gpbLigne.TabStop = False
        '
        'UcGrilleSaisieLignes1
        '
        Me.UcGrilleSaisieLignes1.Dataset = Nothing
        Me.UcGrilleSaisieLignes1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcGrilleSaisieLignes1.JournalCptContre = ""
        Me.UcGrilleSaisieLignes1.JournalCptContreLib = ""
        Me.UcGrilleSaisieLignes1.Location = New System.Drawing.Point(3, 16)
        Me.UcGrilleSaisieLignes1.MontantTTC = False
        Me.UcGrilleSaisieLignes1.Name = "UcGrilleSaisieLignes1"
        Me.UcGrilleSaisieLignes1.PieceDataMember = Nothing
        Me.UcGrilleSaisieLignes1.PieceDatasource = Nothing
        Me.UcGrilleSaisieLignes1.Size = New System.Drawing.Size(1010, 304)
        Me.UcGrilleSaisieLignes1.TabIndex = 0
        '
        'LignesBindingSource
        '
        Me.LignesBindingSource.DataMember = "Lignes"
        Me.LignesBindingSource.DataSource = Me.PiecesBindingSource
        '
        'PiecesTableAdapter
        '
        Me.PiecesTableAdapter.ClearBeforeFill = True
        '
        'LignesTableAdapter
        '
        Me.LignesTableAdapter.ClearBeforeFill = True
        '
        'TvaTa
        '
        Me.TvaTa.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'PlcTa
        '
        Me.PlcTa.ClearBeforeFill = True
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
        '
        'CompteTotalTableAdapter
        '
        Me.CompteTotalTableAdapter.ClearBeforeFill = True
        '
        'ReglesValidationTableAdapter
        '
        Me.ReglesValidationTableAdapter.ClearBeforeFill = True
        '
        'CMSPieceConsultation
        '
        Me.CMSPieceConsultation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuModifConsultPiece, Me.CMSMenuSupprConsultPiece})
        Me.CMSPieceConsultation.Name = "CMSLigneGrid"
        Me.CMSPieceConsultation.Size = New System.Drawing.Size(173, 48)
        '
        'CMenuModifConsultPiece
        '
        Me.CMenuModifConsultPiece.Image = Global.AgrigestEDI.My.Resources.Resources.modif
        Me.CMenuModifConsultPiece.Name = "CMenuModifConsultPiece"
        Me.CMenuModifConsultPiece.Size = New System.Drawing.Size(172, 22)
        Me.CMenuModifConsultPiece.Text = "Modifier la pièce"
        '
        'CMSMenuSupprConsultPiece
        '
        Me.CMSMenuSupprConsultPiece.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.CMSMenuSupprConsultPiece.Name = "CMSMenuSupprConsultPiece"
        Me.CMSMenuSupprConsultPiece.Size = New System.Drawing.Size(172, 22)
        Me.CMSMenuSupprConsultPiece.Text = "Supprimer la pièce"
        '
        'FrBordereau
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 613)
        Me.ControlBox = False
        Me.Controls.Add(Me.gpbLigne)
        Me.Controls.Add(Me.gpbPiece)
        Me.Controls.Add(Me.ListOfPiecesBindingNavigator)
        Me.Name = "FrBordereau"
        Me.Text = "Bordereau"
        CType(Me.ListOfPiecesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ListOfPiecesBindingNavigator.ResumeLayout(False)
        Me.ListOfPiecesBindingNavigator.PerformLayout()
        Me.gpbPiece.ResumeLayout(False)
        CType(Me.PiecesDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSPieceGrid.ResumeLayout(False)
        CType(Me.PiecesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbTotalCompte.ResumeLayout(False)
        Me.gpbTotalCompte.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PieceLibBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsAgrigest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbLigne.ResumeLayout(False)
        CType(Me.LignesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSPieceConsultation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ListOfPiecesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents progressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListOfPiecesBindingNavigatorCleanItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListOfPiecesBindingNavigatorCloseTVAItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListOfPiecesBindingNavigatorCloseItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListOfPiecesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AjouterCompteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents gpbPiece As System.Windows.Forms.GroupBox
    Friend WithEvents gpbLigne As System.Windows.Forms.GroupBox
    Friend WithEvents PiecesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PiecesTableAdapter
    Friend WithEvents LignesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.LignesTableAdapter
    Friend WithEvents PiecesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LignesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TvaTa As AgrigestEDI.dbDonneesDataSetTableAdapters.TVATableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
    Friend WithEvents PlcTa As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
    Friend WithEvents dsAgrigest As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents PiecesDgv As AgrigestEDI.DataGridViewEnter
    Friend WithEvents PieceLibBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CMSPieceGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuAddPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuDeletePiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuCopyPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListOfPiecesBindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListOfPiecesBindingNavigatorAddItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents gpbTotalCompte As System.Windows.Forms.GroupBox
    Friend WithEvents lblActivite As System.Windows.Forms.Label
    Friend WithEvents lblCompte As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDebitBalance As System.Windows.Forms.Label
    Friend WithEvents lblCreditBalance As System.Windows.Forms.Label
    Friend WithEvents lblDebit As System.Windows.Forms.Label
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents lblDebitLib As System.Windows.Forms.Label
    Friend WithEvents lblCreditLib As System.Windows.Forms.Label
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
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
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMenuCompte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuInsertModele As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuEnregistrerModele As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MontantTVA As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents ModifierCompteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMenuModifierUnCompte As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UcGrilleSaisieLignes1 As AgrigestEDI.UcGrilleSaisieLignes
    Friend WithEvents ReglesValidationTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ReglesValidationTableAdapter
    Friend WithEvents CMSPieceConsultation As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CMSMenuModifConsultPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMSMenuSupprConsultPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListOfPiecesBindingNavigatorModifPiece As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMenuModif As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListOfPiecesBindingNavigatorFindCompteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMenuModifConsultPiece As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuRecherche As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PdgvPiece As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents PdgvDatePiece As AgrigestEDI.DatagridViewDatePickerColumn
    Friend WithEvents PdgvLibelle As AgrigestEDI.DatagridViewTextBoxAutoCompleteColumn
    Friend WithEvents PdgvDebit As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents PdgvCredit As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents PdgvTotalContrePartie As AgrigestEDI.DatagridViewNumericTextBoxColumn
End Class

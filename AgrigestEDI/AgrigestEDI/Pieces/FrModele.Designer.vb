<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrModele
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
        Dim LibelleLabel As System.Windows.Forms.Label
        Me.ListOfPiecesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.PiecesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.progressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuAction = New System.Windows.Forms.ToolStripDropDownButton
        Me.CMenuReinitialiser = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuEnregistrer = New System.Windows.Forms.ToolStripMenuItem
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorCleanItem = New System.Windows.Forms.ToolStripButton
        Me.ListOfPiecesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.LibelleTextBox = New System.Windows.Forms.TextBox
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
        Me.JournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsAgrigest = New AgrigestEDI.dbDonneesDataSet
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.UcGrilleSaisieLignes1 = New AgrigestEDI.UcGrilleSaisieLignes
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
        Me.ListOfPiecesBindingNavigatorFindCompteItem = New System.Windows.Forms.ToolStripButton
        LibelleLabel = New System.Windows.Forms.Label
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
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(6, 69)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(95, 13)
        LibelleLabel.TabIndex = 0
        LibelleLabel.Text = "Libellé du modèle :"
        '
        'ListOfPiecesBindingNavigator
        '
        Me.ListOfPiecesBindingNavigator.AddNewItem = Nothing
        Me.ListOfPiecesBindingNavigator.BindingSource = Me.PiecesBindingSource
        Me.ListOfPiecesBindingNavigator.CountItem = Nothing
        Me.ListOfPiecesBindingNavigator.DeleteItem = Nothing
        Me.ListOfPiecesBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ListOfPiecesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar, Me.ToolStripSeparator7, Me.CMenuAction, Me.BindingNavigatorSeparator, Me.TbClose, Me.ListOfPiecesBindingNavigatorCleanItem, Me.ListOfPiecesBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.ListOfPiecesBindingNavigatorFindCompteItem})
        Me.ListOfPiecesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ListOfPiecesBindingNavigator.MoveFirstItem = Nothing
        Me.ListOfPiecesBindingNavigator.MoveLastItem = Nothing
        Me.ListOfPiecesBindingNavigator.MoveNextItem = Nothing
        Me.ListOfPiecesBindingNavigator.MovePreviousItem = Nothing
        Me.ListOfPiecesBindingNavigator.Name = "ListOfPiecesBindingNavigator"
        Me.ListOfPiecesBindingNavigator.PositionItem = Nothing
        Me.ListOfPiecesBindingNavigator.Size = New System.Drawing.Size(799, 25)
        Me.ListOfPiecesBindingNavigator.TabIndex = 0
        Me.ListOfPiecesBindingNavigator.Text = "BindingNavigator1"
        '
        'PiecesBindingSource
        '
        Me.PiecesBindingSource.DataSource = GetType(AgrigestEDI.Modele)
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
        Me.CMenuAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuReinitialiser, Me.CMenuEnregistrer})
        Me.CMenuAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CMenuAction.Name = "CMenuAction"
        Me.CMenuAction.Size = New System.Drawing.Size(50, 22)
        Me.CMenuAction.Text = "Action"
        '
        'CMenuReinitialiser
        '
        Me.CMenuReinitialiser.Image = Global.AgrigestEDI.My.Resources.Resources.undo
        Me.CMenuReinitialiser.Name = "CMenuReinitialiser"
        Me.CMenuReinitialiser.Size = New System.Drawing.Size(248, 22)
        Me.CMenuReinitialiser.Text = "Ré-initialiser"
        '
        'CMenuEnregistrer
        '
        Me.CMenuEnregistrer.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.CMenuEnregistrer.Name = "CMenuEnregistrer"
        Me.CMenuEnregistrer.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.CMenuEnregistrer.Size = New System.Drawing.Size(248, 22)
        Me.CMenuEnregistrer.Text = "Enregistrement du modèle"
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
        Me.TbClose.Image = Global.AgrigestEDI.My.Resources.Resources.close
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 22)
        Me.TbClose.Text = "Fermer"
        '
        'ListOfPiecesBindingNavigatorCleanItem
        '
        Me.ListOfPiecesBindingNavigatorCleanItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorCleanItem.Image = Global.AgrigestEDI.My.Resources.Resources.undo
        Me.ListOfPiecesBindingNavigatorCleanItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorCleanItem.Name = "ListOfPiecesBindingNavigatorCleanItem"
        Me.ListOfPiecesBindingNavigatorCleanItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorCleanItem.Text = "Réinitialiser la pièce"
        Me.ListOfPiecesBindingNavigatorCleanItem.Visible = False
        '
        'ListOfPiecesBindingNavigatorSaveItem
        '
        Me.ListOfPiecesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorSaveItem.Image = Global.AgrigestEDI.My.Resources.Resources.save
        Me.ListOfPiecesBindingNavigatorSaveItem.Name = "ListOfPiecesBindingNavigatorSaveItem"
        Me.ListOfPiecesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorSaveItem.Text = "Enregistrement de la pièce (Ctrl+S)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.AcceptsReturn = True
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PiecesBindingSource, "Modele", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(104, 66)
        Me.LibelleTextBox.MaxLength = 50
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.Size = New System.Drawing.Size(303, 20)
        Me.LibelleTextBox.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblActivite)
        Me.GroupBox1.Controls.Add(Me.lblCompte)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Controls.Add(Me.LibelleTextBox)
        Me.GroupBox1.Controls.Add(LibelleLabel)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(799, 93)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Infos modèle"
        '
        'lblActivite
        '
        Me.lblActivite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblActivite.AutoEllipsis = True
        Me.lblActivite.Location = New System.Drawing.Point(423, 52)
        Me.lblActivite.Name = "lblActivite"
        Me.lblActivite.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblActivite.Size = New System.Drawing.Size(180, 13)
        Me.lblActivite.TabIndex = 3
        Me.lblActivite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCompte
        '
        Me.lblCompte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompte.AutoEllipsis = True
        Me.lblCompte.Location = New System.Drawing.Point(423, 32)
        Me.lblCompte.Name = "lblCompte"
        Me.lblCompte.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblCompte.Size = New System.Drawing.Size(180, 13)
        Me.lblCompte.TabIndex = 2
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(609, 10)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(178, 79)
        Me.TableLayoutPanel1.TabIndex = 4
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
        'JournalBindingSource
        '
        Me.JournalBindingSource.DataMember = "Journal"
        Me.JournalBindingSource.DataSource = Me.dsAgrigest
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
        Me.Panel1.Controls.Add(Me.UcGrilleSaisieLignes1)
        Me.Panel1.Controls.Add(Me.PanelLock)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 118)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(799, 346)
        Me.Panel1.TabIndex = 2
        '
        'UcGrilleSaisieLignes1
        '
        Me.UcGrilleSaisieLignes1.Dataset = Nothing
        Me.UcGrilleSaisieLignes1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UcGrilleSaisieLignes1.JournalCptContre = ""
        Me.UcGrilleSaisieLignes1.JournalCptContreLib = ""
        Me.UcGrilleSaisieLignes1.Location = New System.Drawing.Point(5, 5)
        Me.UcGrilleSaisieLignes1.MontantTTC = False
        Me.UcGrilleSaisieLignes1.Name = "UcGrilleSaisieLignes1"
        Me.UcGrilleSaisieLignes1.PieceDataMember = Nothing
        Me.UcGrilleSaisieLignes1.PieceDatasource = Nothing
        Me.UcGrilleSaisieLignes1.Size = New System.Drawing.Size(789, 336)
        Me.UcGrilleSaisieLignes1.TabIndex = 0
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
        'ListOfPiecesBindingNavigatorFindCompteItem
        '
        Me.ListOfPiecesBindingNavigatorFindCompteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Image = Global.AgrigestEDI.My.Resources.Resources.find
        Me.ListOfPiecesBindingNavigatorFindCompteItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Name = "ListOfPiecesBindingNavigatorFindCompteItem"
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Size = New System.Drawing.Size(23, 22)
        Me.ListOfPiecesBindingNavigatorFindCompteItem.Text = "Recherche d'un compte"
        '
        'FrModele
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(799, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListOfPiecesBindingNavigator)
        Me.Name = "FrModele"
        Me.Text = "Saisir des modèles"
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
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ListOfPiecesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LignesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents progressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents dsAgrigest As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents TvaTa As AgrigestEDI.dbDonneesDataSetTableAdapters.TVATableAdapter
    Friend WithEvents PlcTa As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
    Friend WithEvents PanelLock As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents lblJournalError As System.Windows.Forms.Label
    Friend WithEvents ListOfPiecesBindingNavigatorCleanItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents CompteTotalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CMenuAction As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CMenuReinitialiser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuEnregistrer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UcGrilleSaisieLignes1 As AgrigestEDI.UcGrilleSaisieLignes
    Friend WithEvents ListOfPiecesBindingNavigatorFindCompteItem As System.Windows.Forms.ToolStripButton

End Class

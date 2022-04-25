<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrVisuPiece
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ListOfPiecesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.PiecesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.progressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.CMenuAction = New System.Windows.Forms.ToolStripDropDownButton
        Me.CMenuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuModif = New System.Windows.Forms.ToolStripMenuItem
        Me.CMenuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorModifItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ImprimerToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.lbStatut = New System.Windows.Forms.ToolStripLabel
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
        Me.JournalComboBox = New System.Windows.Forms.ComboBox
        Me.JournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsAgrigest = New AgrigestEDI.dbDonneesDataSet
        Me.LignesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LignesDgv = New AgrigestEDI.DataGridViewEnter
        Me.Compte = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.Activite = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.Libelle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeTva = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantDeb = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.MontantCre = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.Quantite1 = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.Unite1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantite2 = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.Unite2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantTVA = New AgrigestEDI.DatagridViewNumericTextBoxColumn
        Me.CMSLigneGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VisualiserLeCompteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.lbFiller = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbSommeDeb = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbSommeCre = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbSoldePiece = New System.Windows.Forms.ToolStripStatusLabel
        Me.bgWorker = New System.ComponentModel.BackgroundWorker
        Me.ComptesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
        Me.ActivitesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
        Me.JournalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
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
        CType(Me.LignesDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSLigneGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'DatePieceLabel
        '
        DatePieceLabel.AutoSize = True
        DatePieceLabel.Location = New System.Drawing.Point(109, 22)
        DatePieceLabel.Name = "DatePieceLabel"
        DatePieceLabel.Size = New System.Drawing.Size(33, 13)
        DatePieceLabel.TabIndex = 2
        DatePieceLabel.Text = "Date:"
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(3, 48)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(40, 13)
        LibelleLabel.TabIndex = 6
        LibelleLabel.Text = "Libelle:"
        '
        'NPieceLabel
        '
        NPieceLabel.AutoSize = True
        NPieceLabel.Location = New System.Drawing.Point(6, 22)
        NPieceLabel.Name = "NPieceLabel"
        NPieceLabel.Size = New System.Drawing.Size(37, 13)
        NPieceLabel.TabIndex = 0
        NPieceLabel.Text = "Piece:"
        '
        'JournalLabel
        '
        JournalLabel.AutoSize = True
        JournalLabel.Location = New System.Drawing.Point(243, 22)
        JournalLabel.Name = "JournalLabel"
        JournalLabel.Size = New System.Drawing.Size(44, 13)
        JournalLabel.TabIndex = 4
        JournalLabel.Text = "Journal:"
        '
        'ListOfPiecesBindingNavigator
        '
        Me.ListOfPiecesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ListOfPiecesBindingNavigator.BindingSource = Me.PiecesBindingSource
        Me.ListOfPiecesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ListOfPiecesBindingNavigator.DeleteItem = Nothing
        Me.ListOfPiecesBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ListOfPiecesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.progressBar, Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.CMenuAction, Me.ToolStripSeparator1, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorModifItem, Me.BindingNavigatorDeleteItem, Me.ToolStripButton1, Me.ImprimerToolStripButton, Me.lbStatut})
        Me.ListOfPiecesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ListOfPiecesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ListOfPiecesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ListOfPiecesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ListOfPiecesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ListOfPiecesBindingNavigator.Name = "ListOfPiecesBindingNavigator"
        Me.ListOfPiecesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ListOfPiecesBindingNavigator.Size = New System.Drawing.Size(791, 25)
        Me.ListOfPiecesBindingNavigator.TabIndex = 0
        Me.ListOfPiecesBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter une nouvelle pièce"
        '
        'PiecesBindingSource
        '
        Me.PiecesBindingSource.DataSource = GetType(AgrigestEDI.Piece)
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        '
        'progressBar
        '
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(100, 22)
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = Global.AgrigestEDI.My.Resources.Resources.first
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = Global.AgrigestEDI.My.Resources.Resources.previous
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = Global.AgrigestEDI.My.Resources.Resources._next
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = Global.AgrigestEDI.My.Resources.Resources.last
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'CMenuAction
        '
        Me.CMenuAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CMenuAction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMenuNew, Me.CMenuModif, Me.CMenuDelete})
        Me.CMenuAction.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CMenuAction.Name = "CMenuAction"
        Me.CMenuAction.Size = New System.Drawing.Size(55, 22)
        Me.CMenuAction.Text = "Action"
        '
        'CMenuNew
        '
        Me.CMenuNew.Image = Global.AgrigestEDI.My.Resources.Resources._new
        Me.CMenuNew.Name = "CMenuNew"
        Me.CMenuNew.Size = New System.Drawing.Size(207, 22)
        Me.CMenuNew.Text = "Ajouter une pièce"
        '
        'CMenuModif
        '
        Me.CMenuModif.Enabled = False
        Me.CMenuModif.Image = Global.AgrigestEDI.My.Resources.Resources.modif
        Me.CMenuModif.Name = "CMenuModif"
        Me.CMenuModif.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.CMenuModif.Size = New System.Drawing.Size(207, 22)
        Me.CMenuModif.Text = "Modifier la pièce"
        '
        'CMenuDelete
        '
        Me.CMenuDelete.Enabled = False
        Me.CMenuDelete.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.CMenuDelete.Name = "CMenuDelete"
        Me.CMenuDelete.Size = New System.Drawing.Size(207, 22)
        Me.CMenuDelete.Text = "Supprimer la pièce"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorModifItem
        '
        Me.BindingNavigatorModifItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorModifItem.Enabled = False
        Me.BindingNavigatorModifItem.Image = Global.AgrigestEDI.My.Resources.Resources.modif
        Me.BindingNavigatorModifItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BindingNavigatorModifItem.Name = "BindingNavigatorModifItem"
        Me.BindingNavigatorModifItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorModifItem.Text = "Modifier la pièce"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Enabled = False
        Me.BindingNavigatorDeleteItem.Image = Global.AgrigestEDI.My.Resources.Resources.suppr
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer la pièce"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.AgrigestEDI.My.Resources.Resources.close
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Fermer"
        '
        'ImprimerToolStripButton
        '
        Me.ImprimerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimerToolStripButton.Image = Global.AgrigestEDI.My.Resources.Resources.impr
        Me.ImprimerToolStripButton.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ImprimerToolStripButton.Name = "ImprimerToolStripButton"
        Me.ImprimerToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimerToolStripButton.Text = "Imprimer une pièce"
        '
        'lbStatut
        '
        Me.lbStatut.Name = "lbStatut"
        Me.lbStatut.Size = New System.Drawing.Size(0, 22)
        '
        'DatePieceDtp
        '
        Me.DatePieceDtp.CustomFormat = ""
        Me.DatePieceDtp.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.PiecesBindingSource, "DatePiece", True))
        Me.DatePieceDtp.Enabled = False
        Me.DatePieceDtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePieceDtp.Location = New System.Drawing.Point(152, 18)
        Me.DatePieceDtp.Name = "DatePieceDtp"
        Me.DatePieceDtp.Size = New System.Drawing.Size(85, 20)
        Me.DatePieceDtp.TabIndex = 3
        '
        'LibelleTextBox
        '
        Me.LibelleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PiecesBindingSource, "Libelle", True))
        Me.LibelleTextBox.Location = New System.Drawing.Point(49, 45)
        Me.LibelleTextBox.Name = "LibelleTextBox"
        Me.LibelleTextBox.ReadOnly = True
        Me.LibelleTextBox.Size = New System.Drawing.Size(385, 20)
        Me.LibelleTextBox.TabIndex = 7
        '
        'NPieceTextBox
        '
        Me.NPieceTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PiecesBindingSource, "NPiece", True))
        Me.NPieceTextBox.Location = New System.Drawing.Point(49, 18)
        Me.NPieceTextBox.Name = "NPieceTextBox"
        Me.NPieceTextBox.ReadOnly = True
        Me.NPieceTextBox.Size = New System.Drawing.Size(54, 20)
        Me.NPieceTextBox.TabIndex = 1
        Me.NPieceTextBox.Text = "00000000"
        Me.NPieceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblActivite)
        Me.GroupBox1.Controls.Add(Me.lblCompte)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
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
        Me.GroupBox1.Size = New System.Drawing.Size(791, 79)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Infos Pièces"
        '
        'lblActivite
        '
        Me.lblActivite.Location = New System.Drawing.Point(461, 48)
        Me.lblActivite.Name = "lblActivite"
        Me.lblActivite.Size = New System.Drawing.Size(134, 13)
        Me.lblActivite.TabIndex = 14
        Me.lblActivite.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCompte
        '
        Me.lblCompte.Location = New System.Drawing.Point(461, 28)
        Me.lblCompte.Name = "lblCompte"
        Me.lblCompte.Size = New System.Drawing.Size(134, 13)
        Me.lblCompte.TabIndex = 13
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(601, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(178, 65)
        Me.TableLayoutPanel1.TabIndex = 12
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
        'JournalComboBox
        '
        Me.JournalComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PiecesBindingSource, "Journal", True))
        Me.JournalComboBox.DataSource = Me.JournalBindingSource
        Me.JournalComboBox.DisplayMember = "JournalDisplay"
        Me.JournalComboBox.Enabled = False
        Me.JournalComboBox.FormattingEnabled = True
        Me.JournalComboBox.Location = New System.Drawing.Point(293, 18)
        Me.JournalComboBox.Name = "JournalComboBox"
        Me.JournalComboBox.Size = New System.Drawing.Size(141, 21)
        Me.JournalComboBox.TabIndex = 5
        Me.JournalComboBox.ValueMember = "JCodeJournal"
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
        Me.LignesBindingSource.Sort = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LignesDgv)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(791, 360)
        Me.Panel1.TabIndex = 2
        '
        'LignesDgv
        '
        Me.LignesDgv.AllowUserToAddRows = False
        Me.LignesDgv.AllowUserToDeleteRows = False
        Me.LignesDgv.AllowUserToResizeRows = False
        Me.LignesDgv.AutoGenerateColumns = False
        Me.LignesDgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LignesDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Coral
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LignesDgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.LignesDgv.ColumnHeadersHeight = 35
        Me.LignesDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Compte, Me.Activite, Me.Libelle, Me.CodeTva, Me.MontantDeb, Me.MontantCre, Me.Quantite1, Me.Unite1, Me.Quantite2, Me.Unite2, Me.MontantTVA})
        Me.LignesDgv.ContextMenuStrip = Me.CMSLigneGrid
        Me.LignesDgv.DataSource = Me.LignesBindingSource
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.LignesDgv.DefaultCellStyle = DataGridViewCellStyle12
        Me.LignesDgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LignesDgv.GridColor = System.Drawing.Color.LimeGreen
        Me.LignesDgv.JumpToMontant = False
        Me.LignesDgv.Location = New System.Drawing.Point(5, 5)
        Me.LignesDgv.MultiSelect = False
        Me.LignesDgv.Name = "LignesDgv"
        Me.LignesDgv.ReadOnly = True
        Me.LignesDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LignesDgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.LignesDgv.RowHeadersWidth = 25
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        Me.LignesDgv.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.LignesDgv.RowTemplate.ContextMenuStrip = Me.CMSLigneGrid
        Me.LignesDgv.Size = New System.Drawing.Size(781, 325)
        Me.LignesDgv.TabIndex = 0
        '
        'Compte
        '
        Me.Compte.DataPropertyName = "Compte"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Honeydew
        Me.Compte.DefaultCellStyle = DataGridViewCellStyle2
        Me.Compte.HeaderText = "N° de Compte"
        Me.Compte.Name = "Compte"
        Me.Compte.ReadOnly = True
        Me.Compte.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Compte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Compte.Width = 200
        '
        'Activite
        '
        Me.Activite.DataPropertyName = "Activite"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Honeydew
        Me.Activite.DefaultCellStyle = DataGridViewCellStyle3
        Me.Activite.HeaderText = "Activité"
        Me.Activite.Name = "Activite"
        Me.Activite.ReadOnly = True
        Me.Activite.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Activite.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Activite.Width = 80
        '
        'Libelle
        '
        Me.Libelle.DataPropertyName = "Libelle"
        Me.Libelle.HeaderText = "Libellé de la ligne"
        Me.Libelle.MaxInputLength = 35
        Me.Libelle.Name = "Libelle"
        Me.Libelle.ReadOnly = True
        Me.Libelle.Width = 200
        '
        'CodeTva
        '
        Me.CodeTva.DataPropertyName = "CodeTva"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Honeydew
        Me.CodeTva.DefaultCellStyle = DataGridViewCellStyle4
        Me.CodeTva.HeaderText = "Code TVA"
        Me.CodeTva.Name = "CodeTva"
        Me.CodeTva.ReadOnly = True
        Me.CodeTva.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodeTva.Width = 80
        '
        'MontantDeb
        '
        Me.MontantDeb.DataPropertyName = "MontantDeb"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        Me.MontantDeb.DefaultCellStyle = DataGridViewCellStyle5
        Me.MontantDeb.HeaderText = "Montant Débit"
        Me.MontantDeb.Name = "MontantDeb"
        Me.MontantDeb.ReadOnly = True
        Me.MontantDeb.Width = 75
        '
        'MontantCre
        '
        Me.MontantCre.DataPropertyName = "MontantCre"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        Me.MontantCre.DefaultCellStyle = DataGridViewCellStyle6
        Me.MontantCre.HeaderText = "Montant Crédit"
        Me.MontantCre.Name = "MontantCre"
        Me.MontantCre.ReadOnly = True
        Me.MontantCre.Width = 75
        '
        'Quantite1
        '
        Me.Quantite1.DataPropertyName = "Quantite1"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "# ##0.000;-# ##0.000;"""""
        Me.Quantite1.DefaultCellStyle = DataGridViewCellStyle7
        Me.Quantite1.HeaderText = "Quantité 1"
        Me.Quantite1.Name = "Quantite1"
        Me.Quantite1.ReadOnly = True
        Me.Quantite1.Width = 75
        '
        'Unite1
        '
        Me.Unite1.DataPropertyName = "Unite1"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Honeydew
        Me.Unite1.DefaultCellStyle = DataGridViewCellStyle8
        Me.Unite1.HeaderText = ""
        Me.Unite1.Name = "Unite1"
        Me.Unite1.ReadOnly = True
        Me.Unite1.Width = 30
        '
        'Quantite2
        '
        Me.Quantite2.DataPropertyName = "Quantite2"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "# ##0.000;-# ##0.000;"""""
        Me.Quantite2.DefaultCellStyle = DataGridViewCellStyle9
        Me.Quantite2.HeaderText = "Quantité 2"
        Me.Quantite2.Name = "Quantite2"
        Me.Quantite2.ReadOnly = True
        Me.Quantite2.Width = 75
        '
        'Unite2
        '
        Me.Unite2.DataPropertyName = "Unite2"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Honeydew
        Me.Unite2.DefaultCellStyle = DataGridViewCellStyle10
        Me.Unite2.HeaderText = ""
        Me.Unite2.Name = "Unite2"
        Me.Unite2.ReadOnly = True
        Me.Unite2.Width = 30
        '
        'MontantTVA
        '
        Me.MontantTVA.DataPropertyName = "MontantBaseHT"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C2"
        Me.MontantTVA.DefaultCellStyle = DataGridViewCellStyle11
        Me.MontantTVA.HeaderText = "Base TVA HT"
        Me.MontantTVA.Name = "MontantTVA"
        Me.MontantTVA.ReadOnly = True
        Me.MontantTVA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MontantTVA.Width = 60
        '
        'CMSLigneGrid
        '
        Me.CMSLigneGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VisualiserLeCompteToolStripMenuItem})
        Me.CMSLigneGrid.Name = "CMSLigneGrid"
        Me.CMSLigneGrid.Size = New System.Drawing.Size(189, 26)
        '
        'VisualiserLeCompteToolStripMenuItem
        '
        Me.VisualiserLeCompteToolStripMenuItem.Image = Global.AgrigestEDI.My.Resources.Resources.book
        Me.VisualiserLeCompteToolStripMenuItem.Name = "VisualiserLeCompteToolStripMenuItem"
        Me.VisualiserLeCompteToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.VisualiserLeCompteToolStripMenuItem.Text = "Visualiser le compte..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(5, 330)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(781, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lbFiller
        '
        Me.lbFiller.AutoSize = False
        Me.lbFiller.Name = "lbFiller"
        Me.lbFiller.Size = New System.Drawing.Size(111, 17)
        '
        'lbSommeDeb
        '
        Me.lbSommeDeb.AutoSize = False
        Me.lbSommeDeb.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbSommeDeb.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSommeDeb.Name = "lbSommeDeb"
        Me.lbSommeDeb.Size = New System.Drawing.Size(82, 17)
        Me.lbSommeDeb.Text = "lbSommeDeb"
        Me.lbSommeDeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbSommeCre
        '
        Me.lbSommeCre.AutoSize = False
        Me.lbSommeCre.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbSommeCre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSommeCre.Name = "lbSommeCre"
        Me.lbSommeCre.Size = New System.Drawing.Size(79, 17)
        Me.lbSommeCre.Text = "lbSommeCre"
        Me.lbSommeCre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbSoldePiece
        '
        Me.lbSoldePiece.AutoSize = False
        Me.lbSoldePiece.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lbSoldePiece.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSoldePiece.Name = "lbSoldePiece"
        Me.lbSoldePiece.Size = New System.Drawing.Size(78, 17)
        Me.lbSoldePiece.Text = "lbSoldePiece"
        Me.lbSoldePiece.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bgWorker
        '
        Me.bgWorker.WorkerReportsProgress = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'ActivitesTableAdapter
        '
        Me.ActivitesTableAdapter.ClearBeforeFill = True
        '
        'JournalTableAdapter
        '
        Me.JournalTableAdapter.ClearBeforeFill = True
        '
        'FrVisuPiece
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListOfPiecesBindingNavigator)
        Me.Name = "FrVisuPiece"
        Me.Text = "Consulter les écritures"
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
        Me.Panel1.PerformLayout()
        CType(Me.LignesDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSLigneGrid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PiecesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListOfPiecesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DatePieceDtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents LibelleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NPieceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LignesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LignesDgv As DataGridViewEnter
    Friend WithEvents progressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents bgWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dsAgrigest As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents JournalComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents lbFiller As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbSommeDeb As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbSommeCre As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbSoldePiece As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BindingNavigatorModifItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMSLigneGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VisualiserLeCompteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JournalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents lblActivite As System.Windows.Forms.Label
    Friend WithEvents lblCompte As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblDebitBalance As System.Windows.Forms.Label
    Friend WithEvents lblCreditBalance As System.Windows.Forms.Label
    Friend WithEvents lblDebit As System.Windows.Forms.Label
    Friend WithEvents lblCredit As System.Windows.Forms.Label
    Friend WithEvents lblDebitLib As System.Windows.Forms.Label
    Friend WithEvents lblCreditLib As System.Windows.Forms.Label
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
    Friend WithEvents ActivitesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ActivitesTableAdapter
    Friend WithEvents JournalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
    Friend WithEvents Compte As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents Activite As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents Libelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeTva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantDeb As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents MontantCre As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents Quantite1 As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents Unite1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantite2 As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents Unite2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantTVA As AgrigestEDI.DatagridViewNumericTextBoxColumn
    Friend WithEvents CMenuAction As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CMenuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuModif As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImprimerToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbStatut As System.Windows.Forms.ToolStripLabel

End Class

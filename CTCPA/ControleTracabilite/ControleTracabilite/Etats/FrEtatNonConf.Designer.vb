Namespace Etats
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrEtatNonConf
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
            Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.BtImpr = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.EtatConfDataGridView = New System.Windows.Forms.DataGridView
            Me.dtLot = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.nLot = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.CodeProduit = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.groupe = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.libelle = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.Resultat = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.actioncorrective = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.ActionCorrectiveEffectuee = New System.Windows.Forms.DataGridViewCheckBoxColumn
            Me.NresultatbaremeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.EtatNonConfBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.EtatsDataset = New ControleTracabilite.EtatsDataset
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.BtGo = New System.Windows.Forms.Button
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.dtpFin = New System.Windows.Forms.DateTimePicker
            Me.dtpDeb = New System.Windows.Forms.DateTimePicker
            Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
            Me.EtatNonConfTableAdapter = New ControleTracabilite.EtatsDatasetTableAdapters.EtatNonConfTableAdapter
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
            Me.DataGridViewDisableButtonColumn1 = New ControleTracabilite.DataGridViewDisableButtonColumn
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.BindingNavigator1.SuspendLayout()
            CType(Me.EtatConfDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EtatNonConfBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EtatsDataset, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'BindingNavigator1
            '
            Me.BindingNavigator1.AddNewItem = Nothing
            Me.BindingNavigator1.CountItem = Nothing
            Me.BindingNavigator1.DeleteItem = Nothing
            Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtImpr, Me.TbFermer})
            Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
            Me.BindingNavigator1.MoveFirstItem = Nothing
            Me.BindingNavigator1.MoveLastItem = Nothing
            Me.BindingNavigator1.MoveNextItem = Nothing
            Me.BindingNavigator1.MovePreviousItem = Nothing
            Me.BindingNavigator1.Name = "BindingNavigator1"
            Me.BindingNavigator1.PositionItem = Nothing
            Me.BindingNavigator1.Size = New System.Drawing.Size(682, 25)
            Me.BindingNavigator1.TabIndex = 3
            Me.BindingNavigator1.Text = "BindingNavigator1"
            '
            'BtImpr
            '
            Me.BtImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.BtImpr.Image = Global.ControleTracabilite.My.Resources.Resources.impr
            Me.BtImpr.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.BtImpr.Name = "BtImpr"
            Me.BtImpr.Size = New System.Drawing.Size(23, 22)
            Me.BtImpr.Text = "Imprimer"
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbFermer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'EtatConfDataGridView
            '
            Me.EtatConfDataGridView.AllowUserToAddRows = False
            Me.EtatConfDataGridView.AllowUserToDeleteRows = False
            Me.EtatConfDataGridView.AutoGenerateColumns = False
            Me.EtatConfDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtLot, Me.nLot, Me.CodeProduit, Me.groupe, Me.libelle, Me.Resultat, Me.actioncorrective, Me.ActionCorrectiveEffectuee, Me.NresultatbaremeDataGridViewTextBoxColumn})
            Me.EtatConfDataGridView.DataSource = Me.EtatNonConfBindingSource
            Me.EtatConfDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.EtatConfDataGridView.Location = New System.Drawing.Point(0, 64)
            Me.EtatConfDataGridView.Name = "EtatConfDataGridView"
            Me.EtatConfDataGridView.ReadOnly = True
            Me.EtatConfDataGridView.Size = New System.Drawing.Size(682, 355)
            Me.EtatConfDataGridView.TabIndex = 4
            '
            'dtLot
            '
            Me.dtLot.DataPropertyName = "dtLot"
            Me.dtLot.HeaderText = "Date"
            Me.dtLot.Name = "dtLot"
            Me.dtLot.ReadOnly = True
            Me.dtLot.Width = 75
            '
            'nLot
            '
            Me.nLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.nLot.DataPropertyName = "nLot"
            Me.nLot.HeaderText = "N° du Lot"
            Me.nLot.Name = "nLot"
            Me.nLot.ReadOnly = True
            Me.nLot.Width = 77
            '
            'CodeProduit
            '
            Me.CodeProduit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.CodeProduit.DataPropertyName = "CodeProduit"
            Me.CodeProduit.HeaderText = "Produit"
            Me.CodeProduit.Name = "CodeProduit"
            Me.CodeProduit.ReadOnly = True
            Me.CodeProduit.Width = 65
            '
            'groupe
            '
            Me.groupe.DataPropertyName = "groupe"
            Me.groupe.HeaderText = "Groupe"
            Me.groupe.Name = "groupe"
            Me.groupe.ReadOnly = True
            Me.groupe.Width = 68
            '
            'libelle
            '
            Me.libelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.libelle.DataPropertyName = "libelle"
            Me.libelle.HeaderText = "Contrôle"
            Me.libelle.Name = "libelle"
            Me.libelle.ReadOnly = True
            '
            'Resultat
            '
            Me.Resultat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.Resultat.DataPropertyName = "Resultat"
            Me.Resultat.HeaderText = "Résultat"
            Me.Resultat.Name = "Resultat"
            Me.Resultat.ReadOnly = True
            Me.Resultat.Width = 71
            '
            'actioncorrective
            '
            Me.actioncorrective.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.actioncorrective.DataPropertyName = "actioncorrective"
            Me.actioncorrective.HeaderText = "Action Co."
            Me.actioncorrective.Name = "actioncorrective"
            Me.actioncorrective.ReadOnly = True
            '
            'ActionCorrectiveEffectuee
            '
            Me.ActionCorrectiveEffectuee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
            Me.ActionCorrectiveEffectuee.DataPropertyName = "ActionCorrectiveEffectuee"
            Me.ActionCorrectiveEffectuee.HeaderText = "Effectuée"
            Me.ActionCorrectiveEffectuee.Name = "ActionCorrectiveEffectuee"
            Me.ActionCorrectiveEffectuee.ReadOnly = True
            Me.ActionCorrectiveEffectuee.Width = 59
            '
            'NresultatbaremeDataGridViewTextBoxColumn
            '
            Me.NresultatbaremeDataGridViewTextBoxColumn.DataPropertyName = "nresultatbareme"
            Me.NresultatbaremeDataGridViewTextBoxColumn.HeaderText = "nresultatbareme"
            Me.NresultatbaremeDataGridViewTextBoxColumn.Name = "NresultatbaremeDataGridViewTextBoxColumn"
            Me.NresultatbaremeDataGridViewTextBoxColumn.ReadOnly = True
            Me.NresultatbaremeDataGridViewTextBoxColumn.Visible = False
            '
            'EtatNonConfBindingSource
            '
            Me.EtatNonConfBindingSource.DataMember = "EtatNonConf"
            Me.EtatNonConfBindingSource.DataSource = Me.EtatsDataset
            '
            'EtatsDataset
            '
            Me.EtatsDataset.DataSetName = "EtatsDataset"
            Me.EtatsDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(Me.BtGo)
            Me.GradientPanel1.Controls.Add(Me.Label2)
            Me.GradientPanel1.Controls.Add(Me.Label1)
            Me.GradientPanel1.Controls.Add(Me.dtpFin)
            Me.GradientPanel1.Controls.Add(Me.dtpDeb)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
            Me.GradientPanel1.Size = New System.Drawing.Size(682, 39)
            Me.GradientPanel1.TabIndex = 79
            '
            'BtGo
            '
            Me.BtGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
            Me.BtGo.Image = Global.ControleTracabilite.My.Resources.Resources.Retry
            Me.BtGo.Location = New System.Drawing.Point(401, 7)
            Me.BtGo.Name = "BtGo"
            Me.BtGo.Size = New System.Drawing.Size(30, 23)
            Me.BtGo.TabIndex = 4
            Me.BtGo.UseVisualStyleBackColor = False
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(282, 12)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(19, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "au"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(8, 12)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(172, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Rechercher les non-conformités du"
            '
            'dtpFin
            '
            Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpFin.Location = New System.Drawing.Point(307, 8)
            Me.dtpFin.Name = "dtpFin"
            Me.dtpFin.Size = New System.Drawing.Size(88, 20)
            Me.dtpFin.TabIndex = 1
            '
            'dtpDeb
            '
            Me.dtpDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDeb.Location = New System.Drawing.Point(186, 8)
            Me.dtpDeb.Name = "dtpDeb"
            Me.dtpDeb.Size = New System.Drawing.Size(90, 20)
            Me.dtpDeb.TabIndex = 0
            '
            'ImageList1
            '
            Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
            Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
            Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
            '
            'EtatNonConfTableAdapter
            '
            Me.EtatNonConfTableAdapter.ClearBeforeFill = True
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "NomFamille"
            Me.DataGridViewTextBoxColumn1.HeaderText = "Famille"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "nLot"
            Me.DataGridViewTextBoxColumn2.HeaderText = "N° du Lot"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "CodeProduit"
            Me.DataGridViewTextBoxColumn3.HeaderText = "Produit"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "Unite1"
            Me.DataGridViewTextBoxColumn4.HeaderText = "U1"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "Unite2"
            Me.DataGridViewTextBoxColumn5.HeaderText = "U2"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.ReadOnly = True
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "Resultat"
            Me.DataGridViewTextBoxColumn6.HeaderText = "Résultat"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "actioncorrective"
            Me.DataGridViewTextBoxColumn7.HeaderText = "Action Co."
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "nresultatbareme"
            Me.DataGridViewTextBoxColumn8.HeaderText = "nresultatbareme"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.Visible = False
            '
            'DataGridViewDisableButtonColumn1
            '
            Me.DataGridViewDisableButtonColumn1.HeaderText = "Contrôle"
            Me.DataGridViewDisableButtonColumn1.Image = Global.ControleTracabilite.My.Resources.Resources.controles
            Me.DataGridViewDisableButtonColumn1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.DataGridViewDisableButtonColumn1.Name = "DataGridViewDisableButtonColumn1"
            Me.DataGridViewDisableButtonColumn1.UseColumnTextForButtonValue = True
            '
            'FrEtatNonConf
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(682, 419)
            Me.ControlBox = False
            Me.Controls.Add(Me.EtatConfDataGridView)
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.BindingNavigator1)
            Me.Name = "FrEtatNonConf"
            Me.Text = "Etat des non-conformités"
            CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.BindingNavigator1.ResumeLayout(False)
            Me.BindingNavigator1.PerformLayout()
            CType(Me.EtatConfDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EtatNonConfBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EtatsDataset, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EtatConfDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents BtImpr As System.Windows.Forms.ToolStripButton
        Friend WithEvents DataGridViewDisableButtonColumn1 As ControleTracabilite.DataGridViewDisableButtonColumn
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDeb As System.Windows.Forms.DateTimePicker
        Friend WithEvents BtGo As System.Windows.Forms.Button
        Friend WithEvents LotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ProduitDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
        Friend WithEvents EtatNonConfBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents EtatsDataset As ControleTracabilite.EtatsDataset
        Friend WithEvents EtatNonConfTableAdapter As ControleTracabilite.EtatsDatasetTableAdapters.EtatNonConfTableAdapter
        Friend WithEvents dtLot As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents nLot As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CodeProduit As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents groupe As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents libelle As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Resultat As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents actioncorrective As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ActionCorrectiveEffectuee As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents NresultatbaremeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace

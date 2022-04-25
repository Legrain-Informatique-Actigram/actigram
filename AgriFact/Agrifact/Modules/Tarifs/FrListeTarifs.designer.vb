<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeTarifs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeTarifs))
        Me.DsAgrifact = New AgriFact.DsAgrifact
        Me.TarifBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TarifDataGridView = New System.Windows.Forms.DataGridView
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TarifBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.TbSaisieTarifs = New System.Windows.Forms.ToolStripButton
        Me.TarifTA = New AgriFact.DsAgrifactTableAdapters.TarifTableAdapter
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TarifDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TarifBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TarifBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "AgrifactTracaDataSet"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TarifBindingSource
        '
        Me.TarifBindingSource.DataMember = "Tarif"
        Me.TarifBindingSource.DataSource = Me.DsAgrifact
        Me.TarifBindingSource.Sort = "Libelle"
        '
        'TarifDataGridView
        '
        Me.TarifDataGridView.AllowUserToAddRows = False
        Me.TarifDataGridView.AutoGenerateColumns = False
        Me.TarifDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.TarifDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LibelleDataGridViewTextBoxColumn})
        Me.TarifDataGridView.DataSource = Me.TarifBindingSource
        Me.TarifDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TarifDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.TarifDataGridView.MultiSelect = False
        Me.TarifDataGridView.Name = "TarifDataGridView"
        Me.TarifDataGridView.Size = New System.Drawing.Size(682, 363)
        Me.TarifDataGridView.TabIndex = 1
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        '
        'TarifBindingNavigator
        '
        Me.TarifBindingNavigator.AddNewItem = Nothing
        Me.TarifBindingNavigator.BindingSource = Me.TarifBindingSource
        Me.TarifBindingNavigator.CountItem = Nothing
        Me.TarifBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.TarifBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TarifBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.TbFermer, Me.ToolStripSeparator1, Me.TbSaisieTarifs})
        Me.TarifBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.TarifBindingNavigator.MoveFirstItem = Nothing
        Me.TarifBindingNavigator.MoveLastItem = Nothing
        Me.TarifBindingNavigator.MoveNextItem = Nothing
        Me.TarifBindingNavigator.MovePreviousItem = Nothing
        Me.TarifBindingNavigator.Name = "TarifBindingNavigator"
        Me.TarifBindingNavigator.PositionItem = Nothing
        Me.TarifBindingNavigator.Size = New System.Drawing.Size(682, 25)
        Me.TarifBindingNavigator.TabIndex = 3
        Me.TarifBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save16
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(23, 22)
        Me.TbSave.Text = "Enregistrer"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = Global.AgriFact.My.Resources.Resources.new16
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFermer.Name = "TbFermer"
        Me.TbFermer.Size = New System.Drawing.Size(23, 22)
        Me.TbFermer.Text = "Fermer"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TbSaisieTarifs
        '
        Me.TbSaisieTarifs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSaisieTarifs.Image = Global.AgriFact.My.Resources.Resources.Finance
        Me.TbSaisieTarifs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSaisieTarifs.Name = "TbSaisieTarifs"
        Me.TbSaisieTarifs.Size = New System.Drawing.Size(23, 22)
        Me.TbSaisieTarifs.Text = "Saisir tarifs"
        '
        'TarifTA
        '
        Me.TarifTA.ClearBeforeFill = True
        '
        'FrListeTarifs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.TarifDataGridView)
        Me.Controls.Add(Me.TarifBindingNavigator)
        Me.Name = "FrListeTarifs"
        Me.Text = "Liste des Tarifs"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TarifDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TarifBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TarifBindingNavigator.ResumeLayout(False)
        Me.TarifBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsAgrifact As DsAgrifact
    Friend WithEvents TarifBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TarifDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TarifBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TarifTA As AgriFact.DsAgrifactTableAdapters.TarifTableAdapter
    Friend WithEvents TbSaisieTarifs As System.Windows.Forms.ToolStripButton
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

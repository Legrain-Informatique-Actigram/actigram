<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrAssistantConfigurationProduit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAssistantConfigurationProduit))
        Me.wizard = New GNWizardFrameWork.WizardTemplate
        Me.wpResultat = New GNWizardFrameWork.WizardPage
        Me.DefinitionControleDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DefinitionControleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
        Me.Label4 = New System.Windows.Forms.Label
        Me.WizardPage1 = New GNWizardFrameWork.WizardPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.wpChoixFormat = New GNWizardFrameWork.WizardPage
        Me.lsbFormat = New System.Windows.Forms.ListBox
        Me.FormatBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.wpProcess = New GNWizardFrameWork.WizardPage
        Me.lsbProcess = New System.Windows.Forms.ListBox
        Me.ProcessBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CritereModeleTA = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.CritereModeleTableAdapter
        Me.DefinitionControleTA = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
        Me.ModeleDefinitionControleTA = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ModeleDefinitionControleTableAdapter
        Me.ModeleBaremeTA = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ModeleBaremeTableAdapter
        Me.BaremeTA = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
        Me.wizard.SuspendLayout()
        Me.wpResultat.SuspendLayout()
        CType(Me.DefinitionControleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DefinitionControleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WizardPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wpChoixFormat.SuspendLayout()
        CType(Me.FormatBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wpProcess.SuspendLayout()
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'wizard
        '
        Me.wizard.BannerImage = Nothing
        Me.wizard.CancelButtonText = "Annuler"
        Me.wizard.Controls.Add(Me.wpResultat)
        Me.wizard.Controls.Add(Me.WizardPage1)
        Me.wizard.Controls.Add(Me.wpChoixFormat)
        Me.wizard.Controls.Add(Me.wpProcess)
        Me.wizard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wizard.FinishButtonText = "Terminer"
        Me.wizard.Location = New System.Drawing.Point(0, 0)
        Me.wizard.Name = "wizard"
        Me.wizard.NextButtonText = "Suivant > "
        Me.wizard.Pages.Add(Me.WizardPage1)
        Me.wizard.Pages.Add(Me.wpChoixFormat)
        Me.wizard.Pages.Add(Me.wpProcess)
        Me.wizard.Pages.Add(Me.wpResultat)
        Me.wizard.PreviousButtonText = "< Précédent"
        Me.wizard.Size = New System.Drawing.Size(498, 346)
        Me.wizard.StartItemIndex = 0
        Me.wizard.TabIndex = 0
        '
        'wpResultat
        '
        Me.wpResultat.Controls.Add(Me.DefinitionControleDataGridView)
        Me.wpResultat.Controls.Add(Me.Label4)
        Me.wpResultat.HasCancelButton = True
        Me.wpResultat.HasFinishButton = True
        Me.wpResultat.HasNextButton = False
        Me.wpResultat.HasPreviousButton = False
        Me.wpResultat.HeaderCaption = "Wizard Item"
        Me.wpResultat.Location = New System.Drawing.Point(0, 0)
        Me.wpResultat.Name = "wpResultat"
        Me.wpResultat.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Exterior
        Me.wpResultat.Size = New System.Drawing.Size(498, 306)
        Me.wpResultat.SubHeaderCaption = "Panel Item"
        Me.wpResultat.TabIndex = 7
        Me.wpResultat.Text = "New Tab Item 4"
        '
        'DefinitionControleDataGridView
        '
        Me.DefinitionControleDataGridView.AllowUserToAddRows = False
        Me.DefinitionControleDataGridView.AllowUserToDeleteRows = False
        Me.DefinitionControleDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DefinitionControleDataGridView.AutoGenerateColumns = False
        Me.DefinitionControleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.DefinitionControleDataGridView.DataSource = Me.DefinitionControleBindingSource
        Me.DefinitionControleDataGridView.Location = New System.Drawing.Point(12, 25)
        Me.DefinitionControleDataGridView.Name = "DefinitionControleDataGridView"
        Me.DefinitionControleDataGridView.ReadOnly = True
        Me.DefinitionControleDataGridView.Size = New System.Drawing.Size(474, 267)
        Me.DefinitionControleDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "nControle"
        Me.DataGridViewTextBoxColumn1.HeaderText = "nControle"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Groupe"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Groupe"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 67
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Libelle"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Libelle"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DefinitionControleBindingSource
        '
        Me.DefinitionControleBindingSource.DataMember = "DefinitionControle"
        Me.DefinitionControleBindingSource.DataSource = Me.AgrifactTracaDataSet
        '
        'AgrifactTracaDataSet
        '
        Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
        Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(421, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Lorsque vous cliquerez sur Terminer, les contrôles suivants seront créés pour le " & _
            "produit :"
        '
        'WizardPage1
        '
        Me.WizardPage1.Controls.Add(Me.Panel2)
        Me.WizardPage1.HasCancelButton = True
        Me.WizardPage1.HasFinishButton = False
        Me.WizardPage1.HasNextButton = True
        Me.WizardPage1.HasPreviousButton = False
        Me.WizardPage1.HeaderCaption = "Wizard Item"
        Me.WizardPage1.Location = New System.Drawing.Point(0, 0)
        Me.WizardPage1.Name = "WizardPage1"
        Me.WizardPage1.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Exterior
        Me.WizardPage1.Size = New System.Drawing.Size(498, 306)
        Me.WizardPage1.SubHeaderCaption = "Panel Item"
        Me.WizardPage1.TabIndex = 4
        Me.WizardPage1.Text = "New Tab Item 1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(498, 306)
        Me.Panel2.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(165, 306)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(172, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(171, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cliquez sur Suivant pour continuer."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(172, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 39)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cet assistant vous aide à définir les contrôles de qualité à mener sur le produit" & _
            " en fonction de son type."
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(171, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 44)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bienvenue dans l'assistant de configuration des contrôles du produit."
        '
        'wpChoixFormat
        '
        Me.wpChoixFormat.Controls.Add(Me.lsbFormat)
        Me.wpChoixFormat.HasCancelButton = True
        Me.wpChoixFormat.HasFinishButton = False
        Me.wpChoixFormat.HasNextButton = True
        Me.wpChoixFormat.HasPreviousButton = True
        Me.wpChoixFormat.HeaderCaption = "Format du produit"
        Me.wpChoixFormat.Location = New System.Drawing.Point(0, 56)
        Me.wpChoixFormat.Name = "wpChoixFormat"
        Me.wpChoixFormat.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpChoixFormat.Size = New System.Drawing.Size(498, 250)
        Me.wpChoixFormat.SubHeaderCaption = "Quel est le format du produit ?"
        Me.wpChoixFormat.TabIndex = 5
        Me.wpChoixFormat.Text = "New Tab Item 2"
        '
        'lsbFormat
        '
        Me.lsbFormat.DataSource = Me.FormatBindingSource
        Me.lsbFormat.DisplayMember = "Critere"
        Me.lsbFormat.FormattingEnabled = True
        Me.lsbFormat.Location = New System.Drawing.Point(12, 13)
        Me.lsbFormat.Name = "lsbFormat"
        Me.lsbFormat.Size = New System.Drawing.Size(474, 225)
        Me.lsbFormat.TabIndex = 0
        Me.lsbFormat.ValueMember = "Critere"
        '
        'FormatBindingSource
        '
        Me.FormatBindingSource.DataMember = "CritereModele"
        Me.FormatBindingSource.DataSource = Me.AgrifactTracaDataSet
        '
        'wpProcess
        '
        Me.wpProcess.Controls.Add(Me.lsbProcess)
        Me.wpProcess.HasCancelButton = True
        Me.wpProcess.HasFinishButton = False
        Me.wpProcess.HasNextButton = True
        Me.wpProcess.HasPreviousButton = True
        Me.wpProcess.HeaderCaption = "Process de fabrication"
        Me.wpProcess.Location = New System.Drawing.Point(0, 56)
        Me.wpProcess.Name = "wpProcess"
        Me.wpProcess.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpProcess.Size = New System.Drawing.Size(498, 250)
        Me.wpProcess.SubHeaderCaption = "Quel est le process de fabrication du produit ?"
        Me.wpProcess.TabIndex = 6
        Me.wpProcess.Text = "New Tab Item 3"
        '
        'lsbProcess
        '
        Me.lsbProcess.DataSource = Me.ProcessBindingSource
        Me.lsbProcess.DisplayMember = "Critere"
        Me.lsbProcess.FormattingEnabled = True
        Me.lsbProcess.Location = New System.Drawing.Point(12, 13)
        Me.lsbProcess.Name = "lsbProcess"
        Me.lsbProcess.Size = New System.Drawing.Size(474, 225)
        Me.lsbProcess.TabIndex = 0
        Me.lsbProcess.ValueMember = "Critere"
        '
        'ProcessBindingSource
        '
        Me.ProcessBindingSource.DataMember = "CritereModele"
        Me.ProcessBindingSource.DataSource = Me.AgrifactTracaDataSet
        '
        'CritereModeleTA
        '
        Me.CritereModeleTA.ClearBeforeFill = True
        '
        'DefinitionControleTA
        '
        Me.DefinitionControleTA.ClearBeforeFill = True
        '
        'ModeleDefinitionControleTA
        '
        Me.ModeleDefinitionControleTA.ClearBeforeFill = True
        '
        'ModeleBaremeTA
        '
        Me.ModeleBaremeTA.ClearBeforeFill = True
        '
        'BaremeTA
        '
        Me.BaremeTA.ClearBeforeFill = True
        '
        'FrAssistantConfigurationProduit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 346)
        Me.Controls.Add(Me.wizard)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrAssistantConfigurationProduit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant de configuration des contrôles produit"
        Me.wizard.ResumeLayout(False)
        Me.wpResultat.ResumeLayout(False)
        Me.wpResultat.PerformLayout()
        CType(Me.DefinitionControleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DefinitionControleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WizardPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wpChoixFormat.ResumeLayout(False)
        CType(Me.FormatBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wpProcess.ResumeLayout(False)
        CType(Me.ProcessBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wizard As GNWizardFrameWork.WizardTemplate
    Friend WithEvents WizardPage1 As GNWizardFrameWork.WizardPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents wpChoixFormat As GNWizardFrameWork.WizardPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lsbFormat As System.Windows.Forms.ListBox
    Friend WithEvents wpProcess As GNWizardFrameWork.WizardPage
    Friend WithEvents lsbProcess As System.Windows.Forms.ListBox
    Friend WithEvents wpResultat As GNWizardFrameWork.WizardPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CritereModeleTA As ControleTracabilite.AgrifactTracaDataSetTableAdapters.CritereModeleTableAdapter
    Friend WithEvents FormatBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
    Friend WithEvents ProcessBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DefinitionControleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DefinitionControleTA As ControleTracabilite.AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
    Friend WithEvents DefinitionControleDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModeleDefinitionControleTA As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ModeleDefinitionControleTableAdapter
    Friend WithEvents ModeleBaremeTA As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ModeleBaremeTableAdapter
    Friend WithEvents BaremeTA As ControleTracabilite.AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
End Class

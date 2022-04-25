Namespace Lots
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrSaisieLot
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
            Dim NLotLabel As System.Windows.Forms.Label
            Dim DateCreationLabel As System.Windows.Forms.Label
            Dim Famille1Label As System.Windows.Forms.Label
            Dim ObservationLabel As System.Windows.Forms.Label
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.LotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.LotBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
            Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
            Me.TbFermer = New System.Windows.Forms.ToolStripButton
            Me.FamilleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
            Me.NLotTextBox = New System.Windows.Forms.TextBox
            Me.DateCreationDateTimePicker = New System.Windows.Forms.DateTimePicker
            Me.Famille1ComboBox = New System.Windows.Forms.ComboBox
            Me.TermineCheckBox = New System.Windows.Forms.CheckBox
            Me.ObservationTextBox = New System.Windows.Forms.TextBox
            Me.FamilleTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
            Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.LotTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.LotTableAdapter
            NLotLabel = New System.Windows.Forms.Label
            DateCreationLabel = New System.Windows.Forms.Label
            Famille1Label = New System.Windows.Forms.Label
            ObservationLabel = New System.Windows.Forms.Label
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LotBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.LotBindingNavigator.SuspendLayout()
            CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GradientPanel1.SuspendLayout()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'NLotLabel
            '
            NLotLabel.AutoSize = True
            NLotLabel.Location = New System.Drawing.Point(12, 13)
            NLotLabel.Name = "NLotLabel"
            NLotLabel.Size = New System.Drawing.Size(55, 13)
            NLotLabel.TabIndex = 0
            NLotLabel.Text = "N° de Lot:"
            '
            'DateCreationLabel
            '
            DateCreationLabel.AutoSize = True
            DateCreationLabel.Location = New System.Drawing.Point(12, 40)
            DateCreationLabel.Name = "DateCreationLabel"
            DateCreationLabel.Size = New System.Drawing.Size(33, 13)
            DateCreationLabel.TabIndex = 3
            DateCreationLabel.Text = "Date:"
            '
            'Famille1Label
            '
            Famille1Label.AutoSize = True
            Famille1Label.Location = New System.Drawing.Point(12, 65)
            Famille1Label.Name = "Famille1Label"
            Famille1Label.Size = New System.Drawing.Size(42, 13)
            Famille1Label.TabIndex = 5
            Famille1Label.Text = "Famille:"
            '
            'ObservationLabel
            '
            ObservationLabel.AutoSize = True
            ObservationLabel.Location = New System.Drawing.Point(12, 92)
            ObservationLabel.Name = "ObservationLabel"
            ObservationLabel.Size = New System.Drawing.Size(72, 13)
            ObservationLabel.TabIndex = 7
            ObservationLabel.Text = "Observations:"
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'LotBindingSource
            '
            Me.LotBindingSource.DataMember = "Lot"
            Me.LotBindingSource.DataSource = Me.AgrifactTracaDataSet
            '
            'LotBindingNavigator
            '
            Me.LotBindingNavigator.AddNewItem = Nothing
            Me.LotBindingNavigator.BindingSource = Me.LotBindingSource
            Me.LotBindingNavigator.CountItem = Nothing
            Me.LotBindingNavigator.DeleteItem = Nothing
            Me.LotBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.LotBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem, Me.TbFermer})
            Me.LotBindingNavigator.Location = New System.Drawing.Point(0, 0)
            Me.LotBindingNavigator.MoveFirstItem = Nothing
            Me.LotBindingNavigator.MoveLastItem = Nothing
            Me.LotBindingNavigator.MoveNextItem = Nothing
            Me.LotBindingNavigator.MovePreviousItem = Nothing
            Me.LotBindingNavigator.Name = "LotBindingNavigator"
            Me.LotBindingNavigator.PositionItem = Nothing
            Me.LotBindingNavigator.Size = New System.Drawing.Size(307, 25)
            Me.LotBindingNavigator.TabIndex = 0
            Me.LotBindingNavigator.Text = "BindingNavigator1"
            '
            'ProduitBindingNavigatorSaveItem
            '
            Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.ProduitBindingNavigatorSaveItem.Image = Global.ControleTracabilite.My.Resources.Resources.save
            Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
            Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
            Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
            '
            'TbFermer
            '
            Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
            Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.TbFermer.Image = Global.ControleTracabilite.My.Resources.Resources.close
            Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.TbFermer.Name = "TbFermer"
            Me.TbFermer.Size = New System.Drawing.Size(23, 22)
            Me.TbFermer.Text = "Fermer"
            '
            'FamilleBindingSource
            '
            Me.FamilleBindingSource.DataMember = "Famille"
            Me.FamilleBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.FamilleBindingSource.Sort = "Famille"
            '
            'GradientPanel1
            '
            Me.GradientPanel1.Controls.Add(NLotLabel)
            Me.GradientPanel1.Controls.Add(Me.NLotTextBox)
            Me.GradientPanel1.Controls.Add(DateCreationLabel)
            Me.GradientPanel1.Controls.Add(Me.DateCreationDateTimePicker)
            Me.GradientPanel1.Controls.Add(Famille1Label)
            Me.GradientPanel1.Controls.Add(Me.Famille1ComboBox)
            Me.GradientPanel1.Controls.Add(Me.TermineCheckBox)
            Me.GradientPanel1.Controls.Add(ObservationLabel)
            Me.GradientPanel1.Controls.Add(Me.ObservationTextBox)
            Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.GradientPanel1.Location = New System.Drawing.Point(0, 25)
            Me.GradientPanel1.Name = "GradientPanel1"
            Me.GradientPanel1.Size = New System.Drawing.Size(307, 209)
            Me.GradientPanel1.TabIndex = 1
            '
            'NLotTextBox
            '
            Me.NLotTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LotBindingSource, "nLot", True))
            Me.ErrorProvider.SetIconAlignment(Me.NLotTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.NLotTextBox.Location = New System.Drawing.Point(93, 10)
            Me.NLotTextBox.Name = "NLotTextBox"
            Me.NLotTextBox.Size = New System.Drawing.Size(87, 20)
            Me.NLotTextBox.TabIndex = 1
            '
            'DateCreationDateTimePicker
            '
            Me.DateCreationDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.LotBindingSource, "DateCreation", True))
            Me.DateCreationDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.DateCreationDateTimePicker.Location = New System.Drawing.Point(93, 36)
            Me.DateCreationDateTimePicker.Name = "DateCreationDateTimePicker"
            Me.DateCreationDateTimePicker.Size = New System.Drawing.Size(87, 20)
            Me.DateCreationDateTimePicker.TabIndex = 4
            '
            'Famille1ComboBox
            '
            Me.Famille1ComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.LotBindingSource, "Famille1", True))
            Me.Famille1ComboBox.DataSource = Me.FamilleBindingSource
            Me.Famille1ComboBox.DisplayMember = "Famille"
            Me.Famille1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.Famille1ComboBox.FormattingEnabled = True
            Me.Famille1ComboBox.Location = New System.Drawing.Point(93, 62)
            Me.Famille1ComboBox.Name = "Famille1ComboBox"
            Me.Famille1ComboBox.Size = New System.Drawing.Size(200, 21)
            Me.Famille1ComboBox.TabIndex = 6
            Me.Famille1ComboBox.ValueMember = "nFamille"
            '
            'TermineCheckBox
            '
            Me.TermineCheckBox.AutoSize = True
            Me.TermineCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.LotBindingSource, "Termine", True))
            Me.TermineCheckBox.Location = New System.Drawing.Point(186, 12)
            Me.TermineCheckBox.Name = "TermineCheckBox"
            Me.TermineCheckBox.Size = New System.Drawing.Size(64, 17)
            Me.TermineCheckBox.TabIndex = 2
            Me.TermineCheckBox.Text = "Terminé"
            '
            'ObservationTextBox
            '
            Me.ObservationTextBox.AcceptsReturn = True
            Me.ObservationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LotBindingSource, "Observation", True))
            Me.ObservationTextBox.Location = New System.Drawing.Point(93, 89)
            Me.ObservationTextBox.Multiline = True
            Me.ObservationTextBox.Name = "ObservationTextBox"
            Me.ObservationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ObservationTextBox.Size = New System.Drawing.Size(200, 105)
            Me.ObservationTextBox.TabIndex = 8
            '
            'FamilleTableAdapter
            '
            Me.FamilleTableAdapter.ClearBeforeFill = True
            '
            'ErrorProvider
            '
            Me.ErrorProvider.ContainerControl = Me
            '
            'LotTableAdapter
            '
            Me.LotTableAdapter.ClearBeforeFill = True
            '
            'FrSaisieLot
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoScroll = True
            Me.ClientSize = New System.Drawing.Size(307, 234)
            Me.ControlBox = False
            Me.Controls.Add(Me.GradientPanel1)
            Me.Controls.Add(Me.LotBindingNavigator)
            Me.Name = "FrSaisieLot"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Fiche Lot"
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LotBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
            Me.LotBindingNavigator.ResumeLayout(False)
            Me.LotBindingNavigator.PerformLayout()
            CType(Me.FamilleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GradientPanel1.ResumeLayout(False)
            Me.GradientPanel1.PerformLayout()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents LotBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LotBindingNavigator As System.Windows.Forms.BindingNavigator
        Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
        Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents FamilleBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents FamilleTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
        Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
        Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
        Friend WithEvents LotTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.LotTableAdapter
        Friend WithEvents NLotTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DateCreationDateTimePicker As System.Windows.Forms.DateTimePicker
        Friend WithEvents Famille1ComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents TermineCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents ObservationTextBox As System.Windows.Forms.TextBox
    End Class
End Namespace
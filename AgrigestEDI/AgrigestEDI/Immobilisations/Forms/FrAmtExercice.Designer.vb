<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrAmtExercice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAmtExercice))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ICptTextBox = New System.Windows.Forms.TextBox
        Me.ImmobilisationsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ImmobilisationsDataSet = New AgrigestEDI.ImmobilisationsDataSet
        Me.IActiTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.IOrdreTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.IAmtExMaxATextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.IAmtExMinTextBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.IAmtExTotTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ImmobilisationsTableAdapter = New AgrigestEDI.ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.ValiderButton = New System.Windows.Forms.Button
        CType(Me.ImmobilisationsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImmobilisationsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compte :"
        '
        'ICptTextBox
        '
        Me.ICptTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImmobilisationsBindingSource, "ICpt", True))
        Me.ICptTextBox.Enabled = False
        Me.ICptTextBox.Location = New System.Drawing.Point(146, 35)
        Me.ICptTextBox.Name = "ICptTextBox"
        Me.ICptTextBox.Size = New System.Drawing.Size(75, 20)
        Me.ICptTextBox.TabIndex = 1
        Me.ICptTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ImmobilisationsBindingSource
        '
        Me.ImmobilisationsBindingSource.DataMember = "Immobilisations"
        Me.ImmobilisationsBindingSource.DataSource = Me.ImmobilisationsDataSet
        '
        'ImmobilisationsDataSet
        '
        Me.ImmobilisationsDataSet.DataSetName = "ImmobilisationsDataSet"
        Me.ImmobilisationsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'IActiTextBox
        '
        Me.IActiTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImmobilisationsBindingSource, "IActi", True))
        Me.IActiTextBox.Enabled = False
        Me.IActiTextBox.Location = New System.Drawing.Point(146, 61)
        Me.IActiTextBox.Name = "IActiTextBox"
        Me.IActiTextBox.Size = New System.Drawing.Size(75, 20)
        Me.IActiTextBox.TabIndex = 3
        Me.IActiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Activité :"
        '
        'IOrdreTextBox
        '
        Me.IOrdreTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImmobilisationsBindingSource, "IOrdre", True))
        Me.IOrdreTextBox.Enabled = False
        Me.IOrdreTextBox.Location = New System.Drawing.Point(146, 87)
        Me.IOrdreTextBox.Name = "IOrdreTextBox"
        Me.IOrdreTextBox.Size = New System.Drawing.Size(75, 20)
        Me.IOrdreTextBox.TabIndex = 5
        Me.IOrdreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ordre :"
        '
        'IAmtExMaxATextBox
        '
        Me.IAmtExMaxATextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImmobilisationsBindingSource, "IAmtExMax", True))
        Me.IAmtExMaxATextBox.Enabled = False
        Me.IAmtExMaxATextBox.Location = New System.Drawing.Point(146, 113)
        Me.IAmtExMaxATextBox.Name = "IAmtExMaxATextBox"
        Me.IAmtExMaxATextBox.Size = New System.Drawing.Size(75, 20)
        Me.IAmtExMaxATextBox.TabIndex = 7
        Me.IAmtExMaxATextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Amortissement maximum :"
        '
        'IAmtExMinTextBox
        '
        Me.IAmtExMinTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImmobilisationsBindingSource, "IAmtExMin", True))
        Me.IAmtExMinTextBox.Enabled = False
        Me.IAmtExMinTextBox.Location = New System.Drawing.Point(146, 139)
        Me.IAmtExMinTextBox.Name = "IAmtExMinTextBox"
        Me.IAmtExMinTextBox.Size = New System.Drawing.Size(75, 20)
        Me.IAmtExMinTextBox.TabIndex = 9
        Me.IAmtExMinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Amortissement minimum :"
        '
        'IAmtExTotTextBox
        '
        Me.IAmtExTotTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ImmobilisationsBindingSource, "IAmtExTot", True))
        Me.IAmtExTotTextBox.Location = New System.Drawing.Point(146, 165)
        Me.IAmtExTotTextBox.Name = "IAmtExTotTextBox"
        Me.IAmtExTotTextBox.Size = New System.Drawing.Size(75, 20)
        Me.IAmtExTotTextBox.TabIndex = 11
        Me.IAmtExTotTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Amortissement retenu :"
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.BindingSource = Me.ImmobilisationsBindingSource
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(244, 25)
        Me.BindingNavigator1.TabIndex = 12
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Nombre total d'éléments"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Placer en premier"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Déplacer vers le haut"
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
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Position actuelle"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Déplacer vers le bas"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Placer en dernier"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ImmobilisationsTableAdapter
        '
        Me.ImmobilisationsTableAdapter.ClearBeforeFill = True
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(146, 205)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 13
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'ValiderButton
        '
        Me.ValiderButton.Location = New System.Drawing.Point(65, 205)
        Me.ValiderButton.Name = "ValiderButton"
        Me.ValiderButton.Size = New System.Drawing.Size(75, 23)
        Me.ValiderButton.TabIndex = 14
        Me.ValiderButton.Text = "Valider"
        Me.ValiderButton.UseVisualStyleBackColor = True
        '
        'FrAmtExercice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(244, 240)
        Me.Controls.Add(Me.ValiderButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(Me.IAmtExTotTextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.IAmtExMinTextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.IAmtExMaxATextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.IOrdreTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.IActiTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ICptTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "FrAmtExercice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choix de l'amortissement"
        CType(Me.ImmobilisationsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImmobilisationsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ICptTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IActiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents IOrdreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IAmtExMaxATextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents IAmtExMinTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents IAmtExTotTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImmobilisationsDataSet As AgrigestEDI.ImmobilisationsDataSet
    Friend WithEvents ImmobilisationsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImmobilisationsTableAdapter As AgrigestEDI.ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents ValiderButton As System.Windows.Forms.Button
End Class

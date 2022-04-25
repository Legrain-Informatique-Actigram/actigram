<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrListeChoix
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeChoix))
        Me.ds = New System.Data.DataSet
        Me.ListeChoixDataGridView = New System.Windows.Forms.DataGridView
        Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.TbOrdrePlus = New System.Windows.Forms.ToolStripButton
        Me.TbOrdreMoins = New System.Windows.Forms.ToolStripButton
        Me.ColVal = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ds
        '
        Me.ds.DataSetName = "AgrifactTracaDataSet"
        '
        'ListeChoixDataGridView
        '
        Me.ListeChoixDataGridView.AutoGenerateColumns = False
        Me.ListeChoixDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ListeChoixDataGridView.ColumnHeadersVisible = False
        Me.ListeChoixDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColVal})
        Me.ListeChoixDataGridView.DataSource = Me.ListeChoixBindingSource
        Me.ListeChoixDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListeChoixDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.ListeChoixDataGridView.MultiSelect = False
        Me.ListeChoixDataGridView.Name = "ListeChoixDataGridView"
        Me.ListeChoixDataGridView.Size = New System.Drawing.Size(492, 227)
        Me.ListeChoixDataGridView.StandardTab = True
        Me.ListeChoixDataGridView.TabIndex = 1
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BindingNavigator1.BindingSource = Me.ListeChoixBindingSource
        Me.BindingNavigator1.CountItem = Nothing
        Me.BindingNavigator1.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ToolStripSeparator2, Me.TbOrdrePlus, Me.TbOrdreMoins})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Nothing
        Me.BindingNavigator1.MoveLastItem = Nothing
        Me.BindingNavigator1.MoveNextItem = Nothing
        Me.BindingNavigator1.MovePreviousItem = Nothing
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Nothing
        Me.BindingNavigator1.Size = New System.Drawing.Size(492, 25)
        Me.BindingNavigator1.TabIndex = 2
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Ajouter nouveau"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Supprimer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TbOrdrePlus
        '
        Me.TbOrdrePlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TbOrdrePlus.Font = New System.Drawing.Font("Wingdings 3", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.TbOrdrePlus.Image = CType(resources.GetObject("TbOrdrePlus.Image"), System.Drawing.Image)
        Me.TbOrdrePlus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbOrdrePlus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbOrdrePlus.Name = "TbOrdrePlus"
        Me.TbOrdrePlus.Size = New System.Drawing.Size(23, 22)
        Me.TbOrdrePlus.Text = "€"
        '
        'TbOrdreMoins
        '
        Me.TbOrdreMoins.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TbOrdreMoins.Font = New System.Drawing.Font("Wingdings 3", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.TbOrdreMoins.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbOrdreMoins.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbOrdreMoins.Name = "TbOrdreMoins"
        Me.TbOrdreMoins.Size = New System.Drawing.Size(23, 22)
        Me.TbOrdreMoins.Text = "~"
        '
        'ColVal
        '
        Me.ColVal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColVal.DataPropertyName = "Valeur"
        Me.ColVal.HeaderText = "Valeur"
        Me.ColVal.Name = "ColVal"
        '
        'FrListeChoix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 252)
        Me.Controls.Add(Me.ListeChoixDataGridView)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "FrListeChoix"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liste de choix"
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ds As DataSet
    Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TbOrdrePlus As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbOrdreMoins As System.Windows.Forms.ToolStripButton
    Friend WithEvents ValeurDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

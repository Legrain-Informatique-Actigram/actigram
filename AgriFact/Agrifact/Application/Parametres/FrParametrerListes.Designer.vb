<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrParametrerListes
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
        Me.ColonneListeDataSet = New AgriFact.ColonneListeDataSet
        Me.ColonneListeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColonneListeTableAdapter = New AgriFact.ColonneListeDataSetTableAdapters.ColonneListeTableAdapter
        Me.ColonneListeDataGridView = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListeDataPropertyNameListBox = New System.Windows.Forms.ListBox
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeListe = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.TypePiece = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.DataPropertyName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Visible = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Width = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.ColonneListeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColonneListeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColonneListeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ColonneListeDataSet
        '
        Me.ColonneListeDataSet.DataSetName = "ColonneListeDataSet"
        Me.ColonneListeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ColonneListeBindingSource
        '
        Me.ColonneListeBindingSource.DataMember = "ColonneListe"
        Me.ColonneListeBindingSource.DataSource = Me.ColonneListeDataSet
        '
        'ColonneListeTableAdapter
        '
        Me.ColonneListeTableAdapter.ClearBeforeFill = True
        '
        'ColonneListeDataGridView
        '
        Me.ColonneListeDataGridView.AutoGenerateColumns = False
        Me.ColonneListeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ColonneListeDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TypeListe, Me.TypePiece, Me.DataPropertyName, Me.Visible, Me.Width})
        Me.ColonneListeDataGridView.DataSource = Me.ColonneListeBindingSource
        Me.ColonneListeDataGridView.Location = New System.Drawing.Point(0, 0)
        Me.ColonneListeDataGridView.Name = "ColonneListeDataGridView"
        Me.ColonneListeDataGridView.Size = New System.Drawing.Size(521, 430)
        Me.ColonneListeDataGridView.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 458)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Liste des DataPropertyName disponibles (TypeListe=Pièces) :"
        '
        'ListeDataPropertyNameListBox
        '
        Me.ListeDataPropertyNameListBox.FormattingEnabled = True
        Me.ListeDataPropertyNameListBox.Location = New System.Drawing.Point(15, 474)
        Me.ListeDataPropertyNameListBox.MultiColumn = True
        Me.ListeDataPropertyNameListBox.Name = "ListeDataPropertyNameListBox"
        Me.ListeDataPropertyNameListBox.Size = New System.Drawing.Size(494, 82)
        Me.ListeDataPropertyNameListBox.TabIndex = 2
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DataPropertyName = "TypeListe"
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.HeaderText = "TypeListe"
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"Pièces"})
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewComboBoxColumn2
        '
        Me.DataGridViewComboBoxColumn2.DataPropertyName = "TypePiece"
        Me.DataGridViewComboBoxColumn2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn2.HeaderText = "TypePiece"
        Me.DataGridViewComboBoxColumn2.Items.AddRange(New Object() {"ABonReception", "AFacture", "AReglement", "VDevis", "VBonCommande", "VBonLivraison", "VFacture", "Reglement", "Mouvement"})
        Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
        Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID_ColonneListe"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID_ColonneListe"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TypeListe"
        Me.DataGridViewTextBoxColumn2.HeaderText = "TypeListe"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "TypePiece"
        Me.DataGridViewTextBoxColumn3.HeaderText = "TypePiece"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DataPropertyName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "DataPropertyName"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Width"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Width"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'TypeListe
        '
        Me.TypeListe.DataPropertyName = "TypeListe"
        Me.TypeListe.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.TypeListe.HeaderText = "TypeListe"
        Me.TypeListe.Items.AddRange(New Object() {"Pièces"})
        Me.TypeListe.Name = "TypeListe"
        Me.TypeListe.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TypeListe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'TypePiece
        '
        Me.TypePiece.DataPropertyName = "TypePiece"
        Me.TypePiece.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.TypePiece.HeaderText = "TypePiece"
        Me.TypePiece.Items.AddRange(New Object() {"ABonReception", "AFacture", "AReglement", "VDevis", "VBonCommande", "VBonLivraison", "VFacture", "Reglement", "Mouvement"})
        Me.TypePiece.Name = "TypePiece"
        Me.TypePiece.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TypePiece.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataPropertyName
        '
        Me.DataPropertyName.DataPropertyName = "DataPropertyName"
        Me.DataPropertyName.HeaderText = "DataPropertyName"
        Me.DataPropertyName.Name = "DataPropertyName"
        Me.DataPropertyName.Width = 150
        '
        'Visible
        '
        Me.Visible.DataPropertyName = "Visible"
        Me.Visible.HeaderText = "Visible"
        Me.Visible.Name = "Visible"
        Me.Visible.Width = 60
        '
        'Width
        '
        Me.Width.DataPropertyName = "Width"
        Me.Width.HeaderText = "Width"
        Me.Width.Name = "Width"
        Me.Width.Width = 60
        '
        'FrParametrerListes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 566)
        Me.Controls.Add(Me.ListeDataPropertyNameListBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ColonneListeDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrParametrerListes"
        Me.Text = "Paramétrer les colonnes des listes"
        CType(Me.ColonneListeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColonneListeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColonneListeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ColonneListeDataSet As AgriFact.ColonneListeDataSet
    Friend WithEvents ColonneListeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColonneListeTableAdapter As AgriFact.ColonneListeDataSetTableAdapters.ColonneListeTableAdapter
    Friend WithEvents ColonneListeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListeDataPropertyNameListBox As System.Windows.Forms.ListBox
    Friend WithEvents TypeListe As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents TypePiece As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataPropertyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Visible As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Width As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

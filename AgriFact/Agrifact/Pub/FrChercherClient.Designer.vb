<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChercherClient
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.NomTextBox = New System.Windows.Forms.TextBox
        Me.ChercherButton = New System.Windows.Forms.Button
        Me.EntrepriseDataGridView = New System.Windows.Forms.DataGridView
        Me.NEntrepriseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CiviliteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdresseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodePostalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PaysDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeClientDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntrepriseBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New AgriFact.DsAgrifact
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PubDataSet = New AgriFact.PubDataSet
        Me.EntrepriseTableAdapter = New AgriFact.PubDataSetTableAdapters.EntrepriseTableAdapter
        CType(Me.EntrepriseDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom client contient :"
        '
        'NomTextBox
        '
        Me.NomTextBox.Location = New System.Drawing.Point(122, 19)
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.Size = New System.Drawing.Size(253, 20)
        Me.NomTextBox.TabIndex = 1
        '
        'ChercherButton
        '
        Me.ChercherButton.Image = Global.AgriFact.My.Resources.Resources.search
        Me.ChercherButton.Location = New System.Drawing.Point(381, 17)
        Me.ChercherButton.Name = "ChercherButton"
        Me.ChercherButton.Size = New System.Drawing.Size(30, 23)
        Me.ChercherButton.TabIndex = 3
        Me.ChercherButton.UseVisualStyleBackColor = True
        '
        'EntrepriseDataGridView
        '
        Me.EntrepriseDataGridView.AllowUserToAddRows = False
        Me.EntrepriseDataGridView.AllowUserToDeleteRows = False
        Me.EntrepriseDataGridView.AutoGenerateColumns = False
        Me.EntrepriseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.EntrepriseDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NEntrepriseDataGridViewTextBoxColumn, Me.CiviliteDataGridViewTextBoxColumn, Me.NomDataGridViewTextBoxColumn, Me.AdresseDataGridViewTextBoxColumn, Me.CodePostalDataGridViewTextBoxColumn, Me.VilleDataGridViewTextBoxColumn, Me.PaysDataGridViewTextBoxColumn, Me.TypeClientDataGridViewTextBoxColumn})
        Me.EntrepriseDataGridView.DataSource = Me.EntrepriseBindingSource
        Me.EntrepriseDataGridView.Location = New System.Drawing.Point(12, 45)
        Me.EntrepriseDataGridView.Name = "EntrepriseDataGridView"
        Me.EntrepriseDataGridView.ReadOnly = True
        Me.EntrepriseDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EntrepriseDataGridView.Size = New System.Drawing.Size(758, 458)
        Me.EntrepriseDataGridView.TabIndex = 4
        '
        'NEntrepriseDataGridViewTextBoxColumn
        '
        Me.NEntrepriseDataGridViewTextBoxColumn.DataPropertyName = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.HeaderText = "nEntreprise"
        Me.NEntrepriseDataGridViewTextBoxColumn.Name = "NEntrepriseDataGridViewTextBoxColumn"
        Me.NEntrepriseDataGridViewTextBoxColumn.ReadOnly = True
        Me.NEntrepriseDataGridViewTextBoxColumn.Visible = False
        '
        'CiviliteDataGridViewTextBoxColumn
        '
        Me.CiviliteDataGridViewTextBoxColumn.DataPropertyName = "Civilite"
        Me.CiviliteDataGridViewTextBoxColumn.HeaderText = "Civilite"
        Me.CiviliteDataGridViewTextBoxColumn.Name = "CiviliteDataGridViewTextBoxColumn"
        Me.CiviliteDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NomDataGridViewTextBoxColumn
        '
        Me.NomDataGridViewTextBoxColumn.DataPropertyName = "Nom"
        Me.NomDataGridViewTextBoxColumn.HeaderText = "Nom"
        Me.NomDataGridViewTextBoxColumn.Name = "NomDataGridViewTextBoxColumn"
        Me.NomDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AdresseDataGridViewTextBoxColumn
        '
        Me.AdresseDataGridViewTextBoxColumn.DataPropertyName = "Adresse"
        Me.AdresseDataGridViewTextBoxColumn.HeaderText = "Adresse"
        Me.AdresseDataGridViewTextBoxColumn.Name = "AdresseDataGridViewTextBoxColumn"
        Me.AdresseDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CodePostalDataGridViewTextBoxColumn
        '
        Me.CodePostalDataGridViewTextBoxColumn.DataPropertyName = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn.HeaderText = "CodePostal"
        Me.CodePostalDataGridViewTextBoxColumn.Name = "CodePostalDataGridViewTextBoxColumn"
        Me.CodePostalDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VilleDataGridViewTextBoxColumn
        '
        Me.VilleDataGridViewTextBoxColumn.DataPropertyName = "Ville"
        Me.VilleDataGridViewTextBoxColumn.HeaderText = "Ville"
        Me.VilleDataGridViewTextBoxColumn.Name = "VilleDataGridViewTextBoxColumn"
        Me.VilleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PaysDataGridViewTextBoxColumn
        '
        Me.PaysDataGridViewTextBoxColumn.DataPropertyName = "Pays"
        Me.PaysDataGridViewTextBoxColumn.HeaderText = "Pays"
        Me.PaysDataGridViewTextBoxColumn.Name = "PaysDataGridViewTextBoxColumn"
        Me.PaysDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TypeClientDataGridViewTextBoxColumn
        '
        Me.TypeClientDataGridViewTextBoxColumn.DataPropertyName = "TypeClient"
        Me.TypeClientDataGridViewTextBoxColumn.HeaderText = "TypeClient"
        Me.TypeClientDataGridViewTextBoxColumn.Name = "TypeClientDataGridViewTextBoxColumn"
        Me.TypeClientDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EntrepriseBindingSource
        '
        Me.EntrepriseBindingSource.DataMember = "Entreprise"
        Me.EntrepriseBindingSource.DataSource = Me.PubDataSet
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "nEntreprise"
        Me.DataGridViewTextBoxColumn1.HeaderText = "nEntreprise"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Civilite"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Civilite"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Adresse"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Adresse"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CodePostal"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CodePostal"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Ville"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Pays"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Pays"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "TypeClient"
        Me.DataGridViewTextBoxColumn8.HeaderText = "TypeClient"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'PubDataSet
        '
        Me.PubDataSet.DataSetName = "PubDataSet"
        Me.PubDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EntrepriseTableAdapter
        '
        Me.EntrepriseTableAdapter.ClearBeforeFill = True
        '
        'FrChercherClient
        '
        Me.AcceptButton = Me.ChercherButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 515)
        Me.Controls.Add(Me.EntrepriseDataGridView)
        Me.Controls.Add(Me.ChercherButton)
        Me.Controls.Add(Me.NomTextBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrChercherClient"
        Me.Text = "Chercher un client"
        CType(Me.EntrepriseDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EntrepriseBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PubDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ChercherButton As System.Windows.Forms.Button
    Friend WithEvents DsAgrifact As AgriFact.DsAgrifact
    Friend WithEvents EntrepriseBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EntrepriseDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents NEntrepriseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CiviliteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdresseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodePostalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaysDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeClientDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PubDataSet As AgriFact.PubDataSet
    Friend WithEvents EntrepriseTableAdapter As AgriFact.PubDataSetTableAdapters.EntrepriseTableAdapter
End Class

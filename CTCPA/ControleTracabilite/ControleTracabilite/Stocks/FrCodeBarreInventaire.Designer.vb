<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrCodeBarreInventaire
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
        Dim NLotLabel As System.Windows.Forms.Label
        Dim Unite1Label As System.Windows.Forms.Label
        Dim Unite2Label As System.Windows.Forms.Label
        Me.BtFermer = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxCodeBarre = New System.Windows.Forms.TextBox
        Me.InventaireBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StocksDataSet = New ControleTracabilite.StocksDataSet
        Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
        Me.LibelleLabel1 = New System.Windows.Forms.Label
        Me.NLotLabel1 = New System.Windows.Forms.Label
        Me.Unite1TextBox = New System.Windows.Forms.TextBox
        Me.LibUnite1Label1 = New System.Windows.Forms.Label
        Me.Unite2TextBox = New System.Windows.Forms.TextBox
        Me.LibUnite2Label1 = New System.Windows.Forms.Label
        Me.BtValider = New System.Windows.Forms.Button
        Me.gbProduit = New System.Windows.Forms.GroupBox
        LibelleLabel = New System.Windows.Forms.Label
        NLotLabel = New System.Windows.Forms.Label
        Unite1Label = New System.Windows.Forms.Label
        Unite2Label = New System.Windows.Forms.Label
        CType(Me.InventaireBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProduit.SuspendLayout()
        Me.SuspendLayout()
        '
        'LibelleLabel
        '
        LibelleLabel.AutoSize = True
        LibelleLabel.Location = New System.Drawing.Point(6, 25)
        LibelleLabel.Name = "LibelleLabel"
        LibelleLabel.Size = New System.Drawing.Size(43, 13)
        LibelleLabel.TabIndex = 0
        LibelleLabel.Text = "Produit:"
        '
        'NLotLabel
        '
        NLotLabel.AutoSize = True
        NLotLabel.Location = New System.Drawing.Point(6, 48)
        NLotLabel.Name = "NLotLabel"
        NLotLabel.Size = New System.Drawing.Size(40, 13)
        NLotLabel.TabIndex = 2
        NLotLabel.Text = "N° Lot:"
        '
        'Unite1Label
        '
        Unite1Label.AutoSize = True
        Unite1Label.Location = New System.Drawing.Point(6, 77)
        Unite1Label.Name = "Unite1Label"
        Unite1Label.Size = New System.Drawing.Size(59, 13)
        Unite1Label.TabIndex = 4
        Unite1Label.Text = "Quantité 1:"
        '
        'Unite2Label
        '
        Unite2Label.AutoSize = True
        Unite2Label.Location = New System.Drawing.Point(6, 101)
        Unite2Label.Name = "Unite2Label"
        Unite2Label.Size = New System.Drawing.Size(59, 13)
        Unite2Label.TabIndex = 7
        Unite2Label.Text = "Quantité 2:"
        '
        'BtFermer
        '
        Me.BtFermer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtFermer.Location = New System.Drawing.Point(187, 178)
        Me.BtFermer.Name = "BtFermer"
        Me.BtFermer.Size = New System.Drawing.Size(75, 23)
        Me.BtFermer.TabIndex = 3
        Me.BtFermer.Text = "Fermer"
        Me.BtFermer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code Barre:"
        '
        'TxCodeBarre
        '
        Me.TxCodeBarre.Location = New System.Drawing.Point(81, 12)
        Me.TxCodeBarre.Name = "TxCodeBarre"
        Me.TxCodeBarre.Size = New System.Drawing.Size(89, 20)
        Me.TxCodeBarre.TabIndex = 1
        Me.TxCodeBarre.Text = "9999999999999"
        '
        'InventaireBindingSource
        '
        Me.InventaireBindingSource.DataMember = "Inventaire"
        Me.InventaireBindingSource.DataSource = Me.StocksDataSet
        Me.InventaireBindingSource.Filter = ""
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "StocksDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AgrifactTracaDataSet
        '
        Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
        Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LibelleLabel1
        '
        Me.LibelleLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InventaireBindingSource, "Libelle", True))
        Me.LibelleLabel1.Location = New System.Drawing.Point(68, 25)
        Me.LibelleLabel1.Name = "LibelleLabel1"
        Me.LibelleLabel1.Size = New System.Drawing.Size(100, 23)
        Me.LibelleLabel1.TabIndex = 1
        Me.LibelleLabel1.Text = "LibelleProduit"
        '
        'NLotLabel1
        '
        Me.NLotLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InventaireBindingSource, "nLot", True))
        Me.NLotLabel1.Location = New System.Drawing.Point(68, 48)
        Me.NLotLabel1.Name = "NLotLabel1"
        Me.NLotLabel1.Size = New System.Drawing.Size(100, 23)
        Me.NLotLabel1.TabIndex = 3
        Me.NLotLabel1.Text = "nLot"
        '
        'Unite1TextBox
        '
        Me.Unite1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InventaireBindingSource, "QteU1", True))
        Me.Unite1TextBox.Location = New System.Drawing.Point(71, 74)
        Me.Unite1TextBox.Name = "Unite1TextBox"
        Me.Unite1TextBox.Size = New System.Drawing.Size(71, 20)
        Me.Unite1TextBox.TabIndex = 5
        Me.Unite1TextBox.Text = "9 999.99"
        Me.Unite1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LibUnite1Label1
        '
        Me.LibUnite1Label1.AutoSize = True
        Me.LibUnite1Label1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InventaireBindingSource, "LibUnite1", True))
        Me.LibUnite1Label1.Location = New System.Drawing.Point(142, 77)
        Me.LibUnite1Label1.Name = "LibUnite1Label1"
        Me.LibUnite1Label1.Size = New System.Drawing.Size(29, 13)
        Me.LibUnite1Label1.TabIndex = 6
        Me.LibUnite1Label1.Text = "WW"
        '
        'Unite2TextBox
        '
        Me.Unite2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InventaireBindingSource, "QteU2", True))
        Me.Unite2TextBox.Location = New System.Drawing.Point(71, 98)
        Me.Unite2TextBox.Name = "Unite2TextBox"
        Me.Unite2TextBox.Size = New System.Drawing.Size(71, 20)
        Me.Unite2TextBox.TabIndex = 8
        Me.Unite2TextBox.Text = "9 999.99"
        Me.Unite2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LibUnite2Label1
        '
        Me.LibUnite2Label1.AutoSize = True
        Me.LibUnite2Label1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InventaireBindingSource, "LibUnite2", True))
        Me.LibUnite2Label1.Location = New System.Drawing.Point(142, 101)
        Me.LibUnite2Label1.Name = "LibUnite2Label1"
        Me.LibUnite2Label1.Size = New System.Drawing.Size(29, 13)
        Me.LibUnite2Label1.TabIndex = 9
        Me.LibUnite2Label1.Text = "WW"
        '
        'BtValider
        '
        Me.BtValider.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtValider.Location = New System.Drawing.Point(175, 96)
        Me.BtValider.Name = "BtValider"
        Me.BtValider.Size = New System.Drawing.Size(75, 23)
        Me.BtValider.TabIndex = 10
        Me.BtValider.Text = "Valider"
        Me.BtValider.UseVisualStyleBackColor = True
        '
        'gbProduit
        '
        Me.gbProduit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbProduit.Controls.Add(LibelleLabel)
        Me.gbProduit.Controls.Add(Me.BtValider)
        Me.gbProduit.Controls.Add(Me.LibelleLabel1)
        Me.gbProduit.Controls.Add(Me.LibUnite2Label1)
        Me.gbProduit.Controls.Add(Me.NLotLabel1)
        Me.gbProduit.Controls.Add(Unite2Label)
        Me.gbProduit.Controls.Add(NLotLabel)
        Me.gbProduit.Controls.Add(Me.Unite2TextBox)
        Me.gbProduit.Controls.Add(Me.Unite1TextBox)
        Me.gbProduit.Controls.Add(Me.LibUnite1Label1)
        Me.gbProduit.Controls.Add(Unite1Label)
        Me.gbProduit.Location = New System.Drawing.Point(12, 38)
        Me.gbProduit.Name = "gbProduit"
        Me.gbProduit.Size = New System.Drawing.Size(256, 132)
        Me.gbProduit.TabIndex = 2
        Me.gbProduit.TabStop = False
        Me.gbProduit.Text = "Informations"
        '
        'FrCodeBarreInventaire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 213)
        Me.Controls.Add(Me.gbProduit)
        Me.Controls.Add(Me.TxCodeBarre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtFermer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrCodeBarreInventaire"
        Me.Text = "Saisie Code Barre"
        CType(Me.InventaireBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProduit.ResumeLayout(False)
        Me.gbProduit.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtFermer As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxCodeBarre As System.Windows.Forms.TextBox
    Friend WithEvents InventaireBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LibelleLabel1 As System.Windows.Forms.Label
    Friend WithEvents NLotLabel1 As System.Windows.Forms.Label
    Friend WithEvents Unite1TextBox As System.Windows.Forms.TextBox
    Friend WithEvents LibUnite1Label1 As System.Windows.Forms.Label
    Friend WithEvents Unite2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents LibUnite2Label1 As System.Windows.Forms.Label
    Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
    Friend WithEvents BtValider As System.Windows.Forms.Button
    Friend WithEvents gbProduit As System.Windows.Forms.GroupBox
    Friend WithEvents StocksDataSet As ControleTracabilite.StocksDataSet
End Class

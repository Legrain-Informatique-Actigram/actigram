<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrRemplacerCodeProduitPiece
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.ValiderButton = New System.Windows.Forms.Button
        Me.ProduitARemplacerComboBox = New System.Windows.Forms.ComboBox
        Me.ProduitARemplacerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProduitDeRemplacementComboBox = New System.Windows.Forms.ComboBox
        Me.ProduitDeRemplacementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.ProduitTableAdapter = New AgriFact.DsPiecesTableAdapters.ProduitTableAdapter
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.ProduitARemplacerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduitDeRemplacementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Remplacer le code produit :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "par le code produit :"
        '
        'AnnulerButton
        '
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(298, 77)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 9
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'ValiderButton
        '
        Me.ValiderButton.Location = New System.Drawing.Point(379, 77)
        Me.ValiderButton.Name = "ValiderButton"
        Me.ValiderButton.Size = New System.Drawing.Size(75, 23)
        Me.ValiderButton.TabIndex = 8
        Me.ValiderButton.Text = "Valider"
        Me.ValiderButton.UseVisualStyleBackColor = True
        '
        'ProduitARemplacerComboBox
        '
        Me.ProduitARemplacerComboBox.DataSource = Me.ProduitARemplacerBindingSource
        Me.ProduitARemplacerComboBox.DisplayMember = "CodeProduit_Libelle"
        Me.ProduitARemplacerComboBox.FormattingEnabled = True
        Me.ProduitARemplacerComboBox.Location = New System.Drawing.Point(155, 23)
        Me.ProduitARemplacerComboBox.Name = "ProduitARemplacerComboBox"
        Me.ProduitARemplacerComboBox.Size = New System.Drawing.Size(299, 21)
        Me.ProduitARemplacerComboBox.TabIndex = 10
        Me.ProduitARemplacerComboBox.ValueMember = "CodeProduit"
        '
        'ProduitARemplacerBindingSource
        '
        Me.ProduitARemplacerBindingSource.Sort = "CodeProduit"
        '
        'ProduitDeRemplacementComboBox
        '
        Me.ProduitDeRemplacementComboBox.DataSource = Me.ProduitDeRemplacementBindingSource
        Me.ProduitDeRemplacementComboBox.DisplayMember = "CodeProduit_Libelle"
        Me.ProduitDeRemplacementComboBox.FormattingEnabled = True
        Me.ProduitDeRemplacementComboBox.Location = New System.Drawing.Point(155, 50)
        Me.ProduitDeRemplacementComboBox.Name = "ProduitDeRemplacementComboBox"
        Me.ProduitDeRemplacementComboBox.Size = New System.Drawing.Size(299, 21)
        Me.ProduitDeRemplacementComboBox.TabIndex = 11
        Me.ProduitDeRemplacementComboBox.ValueMember = "CodeProduit"
        '
        'ProduitDeRemplacementBindingSource
        '
        Me.ProduitDeRemplacementBindingSource.DataMember = "Produit"
        Me.ProduitDeRemplacementBindingSource.DataSource = Me.DsPieces
        Me.ProduitDeRemplacementBindingSource.Sort = "CodeProduit"
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(44, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(329, 21)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "ATTENTION !!! Cette action est irréversible."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AgriFact.My.Resources.Resources.warning16
        Me.PictureBox1.Location = New System.Drawing.Point(15, 120)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(23, 21)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'FrRemplacerCodeProduitPiece
        '
        Me.AcceptButton = Me.ValiderButton
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(466, 152)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ProduitDeRemplacementComboBox)
        Me.Controls.Add(Me.ProduitARemplacerComboBox)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.ValiderButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrRemplacerCodeProduitPiece"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Remplacer un code produit"
        CType(Me.ProduitARemplacerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduitDeRemplacementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents ValiderButton As System.Windows.Forms.Button
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents ProduitARemplacerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitTableAdapter As AgriFact.DsPiecesTableAdapters.ProduitTableAdapter
    Friend WithEvents ProduitARemplacerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProduitDeRemplacementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProduitDeRemplacementComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class

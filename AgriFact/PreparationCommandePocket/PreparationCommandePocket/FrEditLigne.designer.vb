<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrEditLigne
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrEditLigne))
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.TbFermer = New System.Windows.Forms.ToolBarButton
        Me.TbSave = New System.Windows.Forms.ToolBarButton
        Me.il = New System.Windows.Forms.ImageList
        Me.ip = New Microsoft.WindowsCE.Forms.InputPanel
        Me.DetailCommandeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxQte = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxNLot = New System.Windows.Forms.TextBox
        Me.lbUnit = New System.Windows.Forms.Label
        Me.TxCodeProduit = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.Add(Me.TbFermer)
        Me.ToolBar1.Buttons.Add(Me.TbSave)
        Me.ToolBar1.ImageList = Me.il
        Me.ToolBar1.Name = "ToolBar1"
        '
        'TbFermer
        '
        Me.TbFermer.ImageIndex = 1
        Me.TbFermer.ToolTipText = "Fermer"
        '
        'TbSave
        '
        Me.TbSave.ImageIndex = 0
        Me.TbSave.ToolTipText = "Enregistrer"
        Me.il.Images.Clear()
        Me.il.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
        Me.il.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
        '
        'DetailCommandeBindingSource
        '
        Me.DetailCommandeBindingSource.DataMember = "BL_Detail"
        Me.DetailCommandeBindingSource.DataSource = GetType(PreparationCommandePocket.SvcAgrifact.DsPrepaCommande)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.Text = "Qté"
        '
        'TxQte
        '
        Me.TxQte.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DetailCommandeBindingSource, "Unite1", True))
        Me.TxQte.Location = New System.Drawing.Point(53, 89)
        Me.TxQte.Name = "TxQte"
        Me.TxQte.Size = New System.Drawing.Size(148, 21)
        Me.TxQte.TabIndex = 3
        Me.TxQte.Text = "TxQte"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.Text = "Produit"
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DetailCommandeBindingSource, "Libelle", True))
        Me.TextBox2.Location = New System.Drawing.Point(53, 34)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(184, 21)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "TxProduit"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(3, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 20)
        Me.Label3.Text = "N°Lot"
        '
        'TxNLot
        '
        Me.TxNLot.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DetailCommandeBindingSource, "NLot", True))
        Me.TxNLot.Location = New System.Drawing.Point(53, 62)
        Me.TxNLot.Name = "TxNLot"
        Me.TxNLot.Size = New System.Drawing.Size(184, 21)
        Me.TxNLot.TabIndex = 2
        Me.TxNLot.Text = "TxNLot"
        '
        'lbUnit
        '
        Me.lbUnit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DetailCommandeBindingSource, "LibUnite1", True))
        Me.lbUnit.Location = New System.Drawing.Point(207, 89)
        Me.lbUnit.Name = "lbUnit"
        Me.lbUnit.Size = New System.Drawing.Size(30, 20)
        Me.lbUnit.Text = "WW"
        '
        'TxCodeProduit
        '
        Me.TxCodeProduit.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DetailCommandeBindingSource, "CodeProduit", True))
        Me.TxCodeProduit.Location = New System.Drawing.Point(53, 7)
        Me.TxCodeProduit.Name = "TxCodeProduit"
        Me.TxCodeProduit.ReadOnly = True
        Me.TxCodeProduit.Size = New System.Drawing.Size(184, 21)
        Me.TxCodeProduit.TabIndex = 0
        Me.TxCodeProduit.Text = "TxCodeProduit"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 20)
        Me.Label4.Text = "Code"
        '
        'FrEditLigne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxCodeProduit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbUnit)
        Me.Controls.Add(Me.TxNLot)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxQte)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Name = "FrEditLigne"
        Me.Text = "Saisie manuelle"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents TbFermer As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents il As System.Windows.Forms.ImageList
    Friend WithEvents ip As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents DetailCommandeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxQte As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxNLot As System.Windows.Forms.TextBox
    Friend WithEvents lbUnit As System.Windows.Forms.Label
    Friend WithEvents TxCodeProduit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

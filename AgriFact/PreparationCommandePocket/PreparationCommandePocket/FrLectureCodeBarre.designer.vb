<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrLectureCodeBarre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrLectureCodeBarre))
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.TbExit = New System.Windows.Forms.ToolBarButton
        Me.TbActualiser = New System.Windows.Forms.ToolBarButton
        Me.TbEdit = New System.Windows.Forms.ToolBarButton
        Me.TbFilter = New System.Windows.Forms.ToolBarButton
        Me.TbSoustraction = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton
        Me.TbEnregistrer = New System.Windows.Forms.ToolBarButton
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton
        Me.TbAnnuler = New System.Windows.Forms.ToolBarButton
        Me.il = New System.Windows.Forms.ImageList
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.BLBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BL_DetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgCommande = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.TxCB = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbNbCartons = New System.Windows.Forms.Label
        Me.LbNBL = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LbNom = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.Add(Me.TbExit)
        Me.ToolBar1.Buttons.Add(Me.TbActualiser)
        Me.ToolBar1.Buttons.Add(Me.TbEdit)
        Me.ToolBar1.Buttons.Add(Me.TbFilter)
        Me.ToolBar1.Buttons.Add(Me.TbSoustraction)
        Me.ToolBar1.Buttons.Add(Me.ToolBarButton1)
        Me.ToolBar1.Buttons.Add(Me.TbEnregistrer)
        Me.ToolBar1.Buttons.Add(Me.ToolBarButton2)
        Me.ToolBar1.Buttons.Add(Me.TbAnnuler)
        Me.ToolBar1.ImageList = Me.il
        Me.ToolBar1.Name = "ToolBar1"
        '
        'TbExit
        '
        Me.TbExit.ImageIndex = 3
        Me.TbExit.ToolTipText = "Fermer"
        '
        'TbActualiser
        '
        Me.TbActualiser.ImageIndex = 2
        Me.TbActualiser.ToolTipText = "Actualiser"
        '
        'TbEdit
        '
        Me.TbEdit.ImageIndex = 4
        Me.TbEdit.ToolTipText = "Saisir manuellement"
        '
        'TbFilter
        '
        Me.TbFilter.ImageIndex = 5
        Me.TbFilter.Pushed = True
        Me.TbFilter.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.TbFilter.ToolTipText = "Masquer les articles déjà pesés"
        '
        'TbSoustraction
        '
        Me.TbSoustraction.ImageIndex = 6
        Me.TbSoustraction.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.TbSoustraction.ToolTipText = "Mode soustraction"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Enabled = False
        '
        'TbEnregistrer
        '
        Me.TbEnregistrer.ImageIndex = 1
        Me.TbEnregistrer.ToolTipText = "Enregistrer"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Enabled = False
        '
        'TbAnnuler
        '
        Me.TbAnnuler.ImageIndex = 0
        Me.TbAnnuler.ToolTipText = "Annuler"
        Me.il.Images.Clear()
        Me.il.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
        Me.il.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
        Me.il.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Image))
        Me.il.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Image))
        Me.il.Images.Add(CType(resources.GetObject("resource4"), System.Drawing.Image))
        Me.il.Images.Add(CType(resources.GetObject("resource5"), System.Drawing.Image))
        Me.il.Images.Add(CType(resources.GetObject("resource6"), System.Drawing.Image))
        '
        'BLBindingSource
        '
        Me.BLBindingSource.DataMember = "BL"
        Me.BLBindingSource.DataSource = GetType(PreparationCommandePocket.SvcAgrifact.DsPrepaCommande)
        '
        'BL_DetailBindingSource
        '
        Me.BL_DetailBindingSource.AllowNew = False
        Me.BL_DetailBindingSource.DataMember = "BL_Detail"
        Me.BL_DetailBindingSource.DataSource = GetType(PreparationCommandePocket.SvcAgrifact.DsPrepaCommande)
        Me.BL_DetailBindingSource.Sort = "nDetailDevis"
        '
        'dgCommande
        '
        Me.dgCommande.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgCommande.DataSource = Me.BL_DetailBindingSource
        Me.dgCommande.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCommande.Location = New System.Drawing.Point(0, 62)
        Me.dgCommande.Name = "dgCommande"
        Me.dgCommande.Size = New System.Drawing.Size(240, 206)
        Me.dgCommande.TabIndex = 1
        Me.dgCommande.TableStyles.Add(Me.DataGridTableStyle1)
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn1)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn5)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn2)
        Me.DataGridTableStyle1.GridColumnStyles.Add(Me.DataGridTextBoxColumn3)
        Me.DataGridTableStyle1.MappingName = "BL_Detail"
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Produit"
        Me.DataGridTextBoxColumn1.MappingName = "Libelle"
        Me.DataGridTextBoxColumn1.Width = 100
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Lot"
        Me.DataGridTextBoxColumn5.MappingName = "NLot"
        Me.DataGridTextBoxColumn5.Width = 40
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Qt"
        Me.DataGridTextBoxColumn2.MappingName = "Unite1"
        Me.DataGridTextBoxColumn2.Width = 40
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.MappingName = "LibUnite1"
        Me.DataGridTextBoxColumn3.Width = 20
        '
        'TxCB
        '
        Me.TxCB.Location = New System.Drawing.Point(43, 39)
        Me.TxCB.Name = "TxCB"
        Me.TxCB.Size = New System.Drawing.Size(197, 21)
        Me.TxCB.TabIndex = 2
        Me.TxCB.Text = "0000000000000"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 20)
        Me.Label1.Text = "Scan:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.lbNbCartons)
        Me.Panel1.Controls.Add(Me.TxCB)
        Me.Panel1.Controls.Add(Me.LbNBL)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LbNom)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 62)
        '
        'lbNbCartons
        '
        Me.lbNbCartons.Location = New System.Drawing.Point(140, 20)
        Me.lbNbCartons.Name = "lbNbCartons"
        Me.lbNbCartons.Size = New System.Drawing.Size(100, 16)
        Me.lbNbCartons.Text = "Cartons : 10"
        Me.lbNbCartons.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LbNBL
        '
        Me.LbNBL.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BLBindingSource, "nFacture", True))
        Me.LbNBL.Location = New System.Drawing.Point(37, 20)
        Me.LbNBL.Name = "LbNBL"
        Me.LbNBL.Size = New System.Drawing.Size(50, 20)
        Me.LbNBL.Text = "LbNBL"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(3, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 20)
        Me.Label2.Text = "n°Liv"
        '
        'LbNom
        '
        Me.LbNom.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BLBindingSource, "Nom", True))
        Me.LbNom.Location = New System.Drawing.Point(3, 0)
        Me.LbNom.Name = "LbNom"
        Me.LbNom.Size = New System.Drawing.Size(234, 20)
        Me.LbNom.Text = "LbNom"
        '
        'FrLectureCodeBarre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgCommande)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBar1)
        Me.KeyPreview = True
        Me.Name = "FrLectureCodeBarre"
        Me.Text = "Commande"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents TbActualiser As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbAnnuler As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbEnregistrer As System.Windows.Forms.ToolBarButton
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents dgCommande As System.Windows.Forms.DataGrid
    Friend WithEvents il As System.Windows.Forms.ImageList
    Friend WithEvents TxCB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BL_DetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents TbExit As System.Windows.Forms.ToolBarButton
    Friend WithEvents BLBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LbNom As System.Windows.Forms.Label
    Friend WithEvents LbNBL As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TbEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbFilter As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbSoustraction As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents lbNbCartons As System.Windows.Forms.Label

End Class

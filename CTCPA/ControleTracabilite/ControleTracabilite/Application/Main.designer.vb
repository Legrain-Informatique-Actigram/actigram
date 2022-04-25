<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.NavPane = New Ascend.Windows.Forms.NavigationPane
        Me.nppCA = New Ascend.Windows.Forms.NavigationPanePage
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.lnkCASaisie = New System.Windows.Forms.LinkLabel
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.GénéralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SauvegardeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestaurerUneSauvegardeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParamétrageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParamètresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuMaintenance = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuLancerInter = New System.Windows.Forms.ToolStripMenuItem
        Me.MMenuLog = New System.Windows.Forms.ToolStripMenuItem
        Me.DonnéesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ImporterDesModèlesDeContrôleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SessionNetviewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActivationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.NavPane.SuspendLayout()
        Me.nppCA.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'NavPane
        '
        Me.NavPane.AllowAddOrRemove = False
        Me.NavPane.AllowOptions = False
        Me.NavPane.ButtonActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.NavPane.ButtonActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavPane.ButtonBorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.NavPane.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.NavPane.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.NavPane.ButtonGradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavPane.ButtonGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavPane.ButtonHighlightGradientHighColor = System.Drawing.Color.White
        Me.NavPane.ButtonHighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavPane.CaptionBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.NavPane.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavPane.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.NavPane.CaptionGradientHighColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavPane.CaptionGradientLowColor = System.Drawing.SystemColors.ActiveCaption
        Me.NavPane.CaptionImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavPane.Controls.Add(Me.nppCA)
        Me.NavPane.Cursor = System.Windows.Forms.Cursors.Default
        Me.NavPane.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavPane.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavPane.FooterGradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.NavPane.FooterGradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.NavPane.FooterHeight = 30
        Me.NavPane.FooterHighlightGradientHighColor = System.Drawing.Color.White
        Me.NavPane.FooterHighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.NavPane.ImageInCaption = True
        Me.NavPane.Location = New System.Drawing.Point(0, 24)
        Me.NavPane.Name = "NavPane"
        Me.NavPane.NavigationPages.AddRange(New Ascend.Windows.Forms.NavigationPanePage() {Me.nppCA})
        Me.NavPane.Size = New System.Drawing.Size(163, 504)
        Me.NavPane.TabIndex = 3
        Me.NavPane.VisibleButtonCount = 1
        '
        'nppCA
        '
        Me.nppCA.ActiveGradientHighColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.nppCA.ActiveGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.nppCA.AutoScroll = True
        Me.nppCA.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.nppCA.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.nppCA.Controls.Add(Me.GradientCaption1)
        Me.nppCA.Controls.Add(Me.lnkCASaisie)
        Me.nppCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.nppCA.GradientHighColor = System.Drawing.SystemColors.ButtonHighlight
        Me.nppCA.GradientLowColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.nppCA.HighlightGradientHighColor = System.Drawing.Color.White
        Me.nppCA.HighlightGradientLowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.nppCA.Image = Nothing
        Me.nppCA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.nppCA.ImageFooter = Nothing
        Me.nppCA.ImageIndex = -1
        Me.nppCA.ImageIndexFooter = -1
        Me.nppCA.ImageKey = ""
        Me.nppCA.ImageKeyFooter = ""
        Me.nppCA.ImageList = Nothing
        Me.nppCA.ImageListFooter = Nothing
        Me.nppCA.Key = "KEY"
        Me.nppCA.Location = New System.Drawing.Point(1, 27)
        Me.nppCA.Name = "nppCA"
        Me.nppCA.Size = New System.Drawing.Size(161, 407)
        Me.nppCA.TabIndex = 0
        Me.nppCA.Text = "Menu"
        Me.nppCA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.nppCA.ToolTipText = Nothing
        '
        'GradientCaption1
        '
        Me.GradientCaption1.Border = New Ascend.Border(0, 1, 0, 2)
        Me.GradientCaption1.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.InactiveCaption)
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.InactiveCaption
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.GradientCaption1.Location = New System.Drawing.Point(2, 4)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.Size = New System.Drawing.Size(155, 20)
        Me.GradientCaption1.TabIndex = 3
        Me.GradientCaption1.Text = "Separator"
        '
        'lnkCASaisie
        '
        Me.lnkCASaisie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lnkCASaisie.Location = New System.Drawing.Point(3, 27)
        Me.lnkCASaisie.Name = "lnkCASaisie"
        Me.lnkCASaisie.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lnkCASaisie.Size = New System.Drawing.Size(118, 24)
        Me.lnkCASaisie.TabIndex = 0
        Me.lnkCASaisie.TabStop = True
        Me.lnkCASaisie.Text = "MenuItem"
        Me.lnkCASaisie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip2
        '
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GénéralToolStripMenuItem, Me.ParamétrageToolStripMenuItem, Me.MMenuMaintenance, Me.ToolStripMenuItem1})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(736, 24)
        Me.MenuStrip2.TabIndex = 9
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'GénéralToolStripMenuItem
        '
        Me.GénéralToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SauvegardeToolStripMenuItem, Me.RestaurerUneSauvegardeToolStripMenuItem, Me.ToolStripSeparator1, Me.QuitterToolStripMenuItem})
        Me.GénéralToolStripMenuItem.Name = "GénéralToolStripMenuItem"
        Me.GénéralToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.GénéralToolStripMenuItem.Text = "Général"
        '
        'SauvegardeToolStripMenuItem
        '
        Me.SauvegardeToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.save
        Me.SauvegardeToolStripMenuItem.Name = "SauvegardeToolStripMenuItem"
        Me.SauvegardeToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.SauvegardeToolStripMenuItem.Text = "Sauvegarde..."
        '
        'RestaurerUneSauvegardeToolStripMenuItem
        '
        Me.RestaurerUneSauvegardeToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.restore
        Me.RestaurerUneSauvegardeToolStripMenuItem.Name = "RestaurerUneSauvegardeToolStripMenuItem"
        Me.RestaurerUneSauvegardeToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.RestaurerUneSauvegardeToolStripMenuItem.Text = "Restaurer une sauvegarde..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(215, 6)
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'ParamétrageToolStripMenuItem
        '
        Me.ParamétrageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParamètresToolStripMenuItem})
        Me.ParamétrageToolStripMenuItem.Name = "ParamétrageToolStripMenuItem"
        Me.ParamétrageToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.ParamétrageToolStripMenuItem.Text = "Paramétrage"
        '
        'ParamètresToolStripMenuItem
        '
        Me.ParamètresToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.outils
        Me.ParamètresToolStripMenuItem.Name = "ParamètresToolStripMenuItem"
        Me.ParamètresToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ParamètresToolStripMenuItem.Text = "Paramètres..."
        '
        'MMenuMaintenance
        '
        Me.MMenuMaintenance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MMenuLancerInter, Me.SessionNetviewerToolStripMenuItem, Me.MMenuLog, Me.DonnéesToolStripMenuItem})
        Me.MMenuMaintenance.Name = "MMenuMaintenance"
        Me.MMenuMaintenance.Size = New System.Drawing.Size(88, 20)
        Me.MMenuMaintenance.Text = "Maintenance"
        '
        'MMenuLancerInter
        '
        Me.MMenuLancerInter.Image = Global.ControleTracabilite.My.Resources.Resources.ultravnc
        Me.MMenuLancerInter.Name = "MMenuLancerInter"
        Me.MMenuLancerInter.Size = New System.Drawing.Size(216, 22)
        Me.MMenuLancerInter.Text = "Lancer la téléintervention..."
        '
        'MMenuLog
        '
        Me.MMenuLog.Image = Global.ControleTracabilite.My.Resources.Resources.log
        Me.MMenuLog.Name = "MMenuLog"
        Me.MMenuLog.Size = New System.Drawing.Size(216, 22)
        Me.MMenuLog.Text = "Afficher le fichier log..."
        '
        'DonnéesToolStripMenuItem
        '
        Me.DonnéesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirLeRépertoireDapplicationToolStripMenuItem, Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem, Me.ImporterDesModèlesDeContrôleToolStripMenuItem})
        Me.DonnéesToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.database
        Me.DonnéesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.DonnéesToolStripMenuItem.Name = "DonnéesToolStripMenuItem"
        Me.DonnéesToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.DonnéesToolStripMenuItem.Text = "Données"
        '
        'OuvrirLeRépertoireDapplicationToolStripMenuItem
        '
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.open
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Name = "OuvrirLeRépertoireDapplicationToolStripMenuItem"
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem.Text = "Ouvrir le répertoire d'application..."
        '
        'OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem
        '
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.database
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Name = "OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem"
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem.Text = "Ouvrir la base de données en cours..."
        '
        'ImporterDesModèlesDeContrôleToolStripMenuItem
        '
        Me.ImporterDesModèlesDeContrôleToolStripMenuItem.Name = "ImporterDesModèlesDeContrôleToolStripMenuItem"
        Me.ImporterDesModèlesDeContrôleToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ImporterDesModèlesDeContrôleToolStripMenuItem.Text = "Importer des modèles de contrôle..."
        '
        'SessionNetviewerToolStripMenuItem
        '
        Me.SessionNetviewerToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.netviewer16
        Me.SessionNetviewerToolStripMenuItem.Name = "SessionNetviewerToolStripMenuItem"
        Me.SessionNetviewerToolStripMenuItem.Size = New System.Drawing.Size(216, 22)
        Me.SessionNetviewerToolStripMenuItem.Text = "Session Netviewer..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AProposToolStripMenuItem, Me.ActivationToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem1.Text = "?"
        '
        'AProposToolStripMenuItem
        '
        Me.AProposToolStripMenuItem.Enabled = False
        Me.AProposToolStripMenuItem.Image = Global.ControleTracabilite.My.Resources.Resources.aide
        Me.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem"
        Me.AProposToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.AProposToolStripMenuItem.Text = "A propos..."
        '
        'ActivationToolStripMenuItem
        '
        Me.ActivationToolStripMenuItem.Image = CType(resources.GetObject("ActivationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ActivationToolStripMenuItem.Name = "ActivationToolStripMenuItem"
        Me.ActivationToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ActivationToolStripMenuItem.Text = "Activation..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 6)
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 528)
        Me.Controls.Add(Me.NavPane)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Icon = Global.ControleTracabilite.My.Resources.Resources.icone
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip2
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text"
        Me.NavPane.ResumeLayout(False)
        Me.nppCA.ResumeLayout(False)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NavPane As Ascend.Windows.Forms.NavigationPane
    Friend WithEvents nppCA As Ascend.Windows.Forms.NavigationPanePage
    Friend WithEvents lnkCASaisie As System.Windows.Forms.LinkLabel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents GénéralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SauvegardeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestaurerUneSauvegardeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParamétrageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParamètresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuMaintenance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuLancerInter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMenuLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DonnéesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLeRépertoireDapplicationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLaBaseDeDonnéesEnCoursToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImporterDesModèlesDeContrôleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SessionNetviewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

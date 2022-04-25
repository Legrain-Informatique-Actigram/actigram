Imports Actigram.Donnees
Imports Actigram.Securite.SecuriteConverter
Imports Actigram
Imports GRC

Public Class FrApplication
    Inherits System.Windows.Forms.Form

    'DONE Intégrer la gestion des stocks de Solstyce
    'DONE MICOULEAU Revoir la gestion des Lots
    'DONE MICOULEAU Gestion du tiers facturé option pour facturer la maison mère au lieu du client livré 
    'DONE MICOULEAU Gérer les clients à l’export  
    'DONE MICOULEAU info compta à ajouter par produit pour l’exportation 
    'DONE Améliorer le filtrage des produits pour la saisie de pièces
    'DONE Ne pas redémarrer après une restauration de base

    'TODO Modifier GestionControles pour qu'il analyse la config et demande à charger les bonnes tables
    'TODO Maintenir certaines tables en cache ? (Niveau1,Niveau2,ListeChoix,TVA)
    'TODO Permettre d'éditer/réorganiser les parametres depuis l'écran de choix de dossier
    'TODO Déplacer le Parametres.xml ailleurs que dans le dossier Program Files
    'TODO Trouver un système pour différencier les factures relancées
    'TODO Revoir les impression de remise de chèques qui n'affiche pas les montants qui se répètents
    'TODO Trouver un système pour afficher les « a déposer le » quand la date est passée

    'TODO MDA Synchro de la liste des entreprises et personnes avec le web service

    'Public WithEvents fr As FrDonnees

    Public Shared Modules As Actigram.Securite.Modules

    Public Shared Utilisateur As String
    Public Shared Pwd As String
    Public Shared nUtilisateur As Integer = -1
    Public Shared Parametres As ParametresApplication
    Public Shared ValeurDefault As ValeurDefaultApplication

    Private frProgressionSauvegarde As FrProgressBar
    Friend WithEvents DebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowFontPanelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimernAdherent As System.Windows.Forms.Timer
    Private versionDemo As Boolean

    Private Const FICHIERXMLGESTIONMODULES As String = "GestionModulesSansActivation.xml"
    Friend WithEvents ParametrerListesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private Const CHEMIN_ACTIGRAM_AGRIFACT As String = "Actigram\AgriFact\"

#Region " Enums "
    Private Enum ListeMenu
        Clients
        Evenements
        Produits
        Lots
        Stocks
        Achats
        Ventes
        Stats
        Balance
        GestionSite
        Compta
    End Enum

    Private Enum ListeSsMenuProduit
        Familles
        Produits
        Tarifs
        ImportPhytoData
    End Enum

    Private Enum ListeSsMenuAchat
        BonReception
        Facture
        Reglement
    End Enum

    Private Enum ListeSsMenuVente
        Devis
        BonCommande
        BonLivraison
        Facture
        Reglement
        Remise
        Banque
        BilanVentePhyto
    End Enum

    Private Enum ListeSsCompta
        Parametres
        Agrigest
        ExportCompta
        ExportComptaFichier
    End Enum
#End Region

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()        
    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer
    Friend WithEvents SauvegarderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestaurerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ParamètresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AssistantDémarrageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents npMenu As Ascend.Windows.Forms.NavigationPane
    Friend WithEvents NavigationPanePage1 As Ascend.Windows.Forms.NavigationPanePage
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents ChangerDeDossierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MisesÀJourToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenanceToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvrirLeRépertoireDapplicationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraVNCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NetViewerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UtilitaireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AfficherLeFichierLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DonneesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbEval As System.Windows.Forms.Label
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableauDeBordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.SauvegarderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestaurerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ChangerDeDossierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParamètresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AssistantDémarrageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MisesÀJourToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ActivationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.MaintenanceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.UltraVNCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NetViewerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UtilitaireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AfficherLeFichierLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.npMenu = New Ascend.Windows.Forms.NavigationPane
        Me.NavigationPanePage1 = New Ascend.Windows.Forms.NavigationPanePage
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DonneesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TableauDeBordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ParametrerListesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowFontPanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbEval = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TimernAdherent = New System.Windows.Forms.Timer(Me.components)
        Me.npMenu.SuspendLayout()
        Me.NavigationPanePage1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SauvegarderToolStripMenuItem
        '
        Me.SauvegarderToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.save16
        Me.SauvegarderToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SauvegarderToolStripMenuItem.Name = "SauvegarderToolStripMenuItem"
        Me.SauvegarderToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.SauvegarderToolStripMenuItem.Text = "Sauvegarder..."
        '
        'RestaurerToolStripMenuItem
        '
        Me.RestaurerToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.restore
        Me.RestaurerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RestaurerToolStripMenuItem.Name = "RestaurerToolStripMenuItem"
        Me.RestaurerToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RestaurerToolStripMenuItem.Text = "Restaurer..."
        '
        'ChangerDeDossierToolStripMenuItem
        '
        Me.ChangerDeDossierToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.openfolderHS
        Me.ChangerDeDossierToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ChangerDeDossierToolStripMenuItem.Name = "ChangerDeDossierToolStripMenuItem"
        Me.ChangerDeDossierToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ChangerDeDossierToolStripMenuItem.Text = "Changer de dossier..."
        '
        'ParamètresToolStripMenuItem
        '
        Me.ParamètresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ParamètresToolStripMenuItem.Name = "ParamètresToolStripMenuItem"
        Me.ParamètresToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ParamètresToolStripMenuItem.Text = "Paramètres..."
        '
        'AssistantDémarrageToolStripMenuItem
        '
        Me.AssistantDémarrageToolStripMenuItem.Name = "AssistantDémarrageToolStripMenuItem"
        Me.AssistantDémarrageToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.AssistantDémarrageToolStripMenuItem.Text = "Assistant démarrage..."
        '
        'AProposToolStripMenuItem
        '
        Me.AProposToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.aide16
        Me.AProposToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem"
        Me.AProposToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.AProposToolStripMenuItem.Text = "A propos..."
        '
        'MisesÀJourToolStripMenuItem1
        '
        Me.MisesÀJourToolStripMenuItem1.Image = Global.AgriFact.My.Resources.Resources.icone_update_appli16
        Me.MisesÀJourToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MisesÀJourToolStripMenuItem1.Name = "MisesÀJourToolStripMenuItem1"
        Me.MisesÀJourToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
        Me.MisesÀJourToolStripMenuItem1.Text = "Mises à jour..."
        '
        'ActivationToolStripMenuItem1
        '
        Me.ActivationToolStripMenuItem1.Image = Global.AgriFact.My.Resources.Resources.PrimaryKeyHS
        Me.ActivationToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ActivationToolStripMenuItem1.Name = "ActivationToolStripMenuItem1"
        Me.ActivationToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
        Me.ActivationToolStripMenuItem1.Text = "Activation..."
        '
        'MaintenanceToolStripMenuItem1
        '
        Me.MaintenanceToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirLeRépertoireDapplicationToolStripMenuItem1, Me.UltraVNCToolStripMenuItem, Me.NetViewerToolStripMenuItem, Me.UtilitaireToolStripMenuItem, Me.AdminToolStripMenuItem, Me.AfficherLeFichierLogToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem1.Image = Global.AgriFact.My.Resources.Resources.outils
        Me.MaintenanceToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MaintenanceToolStripMenuItem1.Name = "MaintenanceToolStripMenuItem1"
        Me.MaintenanceToolStripMenuItem1.Size = New System.Drawing.Size(146, 22)
        Me.MaintenanceToolStripMenuItem1.Text = "Maintenance"
        '
        'OuvrirLeRépertoireDapplicationToolStripMenuItem1
        '
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem1.Image = Global.AgriFact.My.Resources.Resources.openfolderHS
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem1.Name = "OuvrirLeRépertoireDapplicationToolStripMenuItem1"
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem1.Size = New System.Drawing.Size(245, 22)
        Me.OuvrirLeRépertoireDapplicationToolStripMenuItem1.Text = "Ouvrir le répertoire d'application"
        '
        'UltraVNCToolStripMenuItem
        '
        Me.UltraVNCToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.ultravnc
        Me.UltraVNCToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.UltraVNCToolStripMenuItem.Name = "UltraVNCToolStripMenuItem"
        Me.UltraVNCToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.UltraVNCToolStripMenuItem.Text = "Ultra VNC..."
        '
        'NetViewerToolStripMenuItem
        '
        Me.NetViewerToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.netviewer16
        Me.NetViewerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NetViewerToolStripMenuItem.Name = "NetViewerToolStripMenuItem"
        Me.NetViewerToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.NetViewerToolStripMenuItem.Text = "NetViewer..."
        '
        'UtilitaireToolStripMenuItem
        '
        Me.UtilitaireToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.icone_util16
        Me.UtilitaireToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.UtilitaireToolStripMenuItem.Name = "UtilitaireToolStripMenuItem"
        Me.UtilitaireToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.UtilitaireToolStripMenuItem.Text = "Utilitaire..."
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.icone_admin16
        Me.AdminToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AdminToolStripMenuItem.Text = "Admin..."
        '
        'AfficherLeFichierLogToolStripMenuItem
        '
        Me.AfficherLeFichierLogToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.log
        Me.AfficherLeFichierLogToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AfficherLeFichierLogToolStripMenuItem.Name = "AfficherLeFichierLogToolStripMenuItem"
        Me.AfficherLeFichierLogToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.AfficherLeFichierLogToolStripMenuItem.Text = "Afficher le fichier log..."
        '
        'npMenu
        '
        Me.npMenu.AllowAddOrRemove = False
        Me.npMenu.AllowOptions = False
        Me.npMenu.ButtonActiveGradientHighColor = System.Drawing.Color.White
        Me.npMenu.ButtonActiveGradientLowColor = System.Drawing.Color.Orange
        Me.npMenu.ButtonBorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.npMenu.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.npMenu.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.npMenu.ButtonGradientHighColor = System.Drawing.Color.White
        Me.npMenu.ButtonGradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.npMenu.ButtonHighlightGradientHighColor = System.Drawing.Color.White
        Me.npMenu.ButtonHighlightGradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.npMenu.CaptionBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.npMenu.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.npMenu.CaptionForeColor = System.Drawing.Color.Navy
        Me.npMenu.CaptionGradientHighColor = System.Drawing.SystemColors.Menu
        Me.npMenu.CaptionGradientLowColor = System.Drawing.SystemColors.MenuBar
        Me.npMenu.CaptionHeight = 55
        Me.npMenu.CaptionImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.npMenu.Controls.Add(Me.NavigationPanePage1)
        Me.npMenu.Cursor = System.Windows.Forms.Cursors.Default
        Me.npMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.npMenu.FooterGradientHighColor = System.Drawing.Color.White
        Me.npMenu.FooterGradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.npMenu.FooterHeight = 0
        Me.npMenu.FooterHighlightGradientHighColor = System.Drawing.Color.White
        Me.npMenu.FooterHighlightGradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.npMenu.ForeColor = System.Drawing.Color.DarkBlue
        Me.npMenu.ImageInCaption = True
        Me.npMenu.Location = New System.Drawing.Point(0, 0)
        Me.npMenu.Name = "npMenu"
        Me.npMenu.NavigationPages.AddRange(New Ascend.Windows.Forms.NavigationPanePage() {Me.NavigationPanePage1})
        Me.npMenu.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.npMenu.Size = New System.Drawing.Size(202, 455)
        Me.npMenu.SplitBarGradientHighColor = System.Drawing.Color.White
        Me.npMenu.SplitBarGradientLowColor = System.Drawing.Color.SteelBlue
        Me.npMenu.TabIndex = 16
        Me.npMenu.VisibleButtonCount = 1
        '
        'NavigationPanePage1
        '
        Me.NavigationPanePage1.ActiveGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage1.ActiveGradientLowColor = System.Drawing.Color.Orange
        Me.NavigationPanePage1.AutoScroll = True
        Me.NavigationPanePage1.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.NavigationPanePage1.ButtonForeColor = System.Drawing.Color.DarkBlue
        Me.NavigationPanePage1.Controls.Add(Me.FlowLayoutPanel1)
        Me.NavigationPanePage1.GradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage1.GradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.NavigationPanePage1.HighlightGradientHighColor = System.Drawing.Color.White
        Me.NavigationPanePage1.HighlightGradientLowColor = System.Drawing.Color.LightSteelBlue
        Me.NavigationPanePage1.Image = Global.AgriFact.My.Resources.Resources.Clients
        Me.NavigationPanePage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage1.ImageFooter = Nothing
        Me.NavigationPanePage1.ImageIndex = -1
        Me.NavigationPanePage1.ImageIndexFooter = -1
        Me.NavigationPanePage1.ImageKey = ""
        Me.NavigationPanePage1.ImageKeyFooter = ""
        Me.NavigationPanePage1.ImageList = Nothing
        Me.NavigationPanePage1.ImageListFooter = Nothing
        Me.NavigationPanePage1.Key = "Partenaires"
        Me.NavigationPanePage1.Location = New System.Drawing.Point(1, 56)
        Me.NavigationPanePage1.Name = "NavigationPanePage1"
        Me.NavigationPanePage1.Size = New System.Drawing.Size(200, 359)
        Me.NavigationPanePage1.TabIndex = 0
        Me.NavigationPanePage1.Text = "Partenaires"
        Me.NavigationPanePage1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NavigationPanePage1.ToolTipText = Nothing
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.LinkLabel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.LinkLabel2)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(200, 359)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(3, 3)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(59, 13)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LinkLabel1"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(3, 19)
        Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(59, 13)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "LinkLabel2"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DonneesToolStripMenuItem, Me.TableauDeBordToolStripMenuItem, Me.ConfigurationToolStripMenuItem, Me.AideToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(202, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(698, 55)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DonneesToolStripMenuItem
        '
        Me.DonneesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SauvegarderToolStripMenuItem, Me.RestaurerToolStripMenuItem, Me.ChangerDeDossierToolStripMenuItem})
        Me.DonneesToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.Save
        Me.DonneesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DonneesToolStripMenuItem.Name = "DonneesToolStripMenuItem"
        Me.DonneesToolStripMenuItem.Size = New System.Drawing.Size(65, 51)
        Me.DonneesToolStripMenuItem.Text = "Données"
        Me.DonneesToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TableauDeBordToolStripMenuItem
        '
        Me.TableauDeBordToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.Web
        Me.TableauDeBordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TableauDeBordToolStripMenuItem.Name = "TableauDeBordToolStripMenuItem"
        Me.TableauDeBordToolStripMenuItem.Size = New System.Drawing.Size(105, 51)
        Me.TableauDeBordToolStripMenuItem.Text = "Tableau de Bord"
        Me.TableauDeBordToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParamètresToolStripMenuItem, Me.AssistantDémarrageToolStripMenuItem, Me.ParametrerListesToolStripMenuItem})
        Me.ConfigurationToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.Find
        Me.ConfigurationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(93, 51)
        Me.ConfigurationToolStripMenuItem.Text = "Configuration"
        Me.ConfigurationToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ParametrerListesToolStripMenuItem
        '
        Me.ParametrerListesToolStripMenuItem.Name = "ParametrerListesToolStripMenuItem"
        Me.ParametrerListesToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.ParametrerListesToolStripMenuItem.Text = "Paramétrer les listes..."
        '
        'AideToolStripMenuItem
        '
        Me.AideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AProposToolStripMenuItem, Me.MisesÀJourToolStripMenuItem1, Me.ActivationToolStripMenuItem1, Me.MaintenanceToolStripMenuItem1, Me.DebugToolStripMenuItem})
        Me.AideToolStripMenuItem.Image = Global.AgriFact.My.Resources.Resources.Aide
        Me.AideToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AideToolStripMenuItem.Name = "AideToolStripMenuItem"
        Me.AideToolStripMenuItem.Size = New System.Drawing.Size(44, 51)
        Me.AideToolStripMenuItem.Text = "Aide"
        Me.AideToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DebugToolStripMenuItem
        '
        Me.DebugToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowFontPanelToolStripMenuItem})
        Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
        Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.DebugToolStripMenuItem.Text = "Debug"
        '
        'ShowFontPanelToolStripMenuItem
        '
        Me.ShowFontPanelToolStripMenuItem.CheckOnClick = True
        Me.ShowFontPanelToolStripMenuItem.Name = "ShowFontPanelToolStripMenuItem"
        Me.ShowFontPanelToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ShowFontPanelToolStripMenuItem.Text = "Show font panel"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.npMenu)
        Me.Panel1.Controls.Add(Me.lbEval)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(202, 476)
        Me.Panel1.TabIndex = 19
        '
        'lbEval
        '
        Me.lbEval.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbEval.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbEval.ForeColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbEval.Location = New System.Drawing.Point(0, 455)
        Me.lbEval.Name = "lbEval"
        Me.lbEval.Size = New System.Drawing.Size(202, 21)
        Me.lbEval.TabIndex = 18
        Me.lbEval.Text = "Version d'évaluation"
        Me.lbEval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbEval.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PictureBox1.Image = Global.AgriFact.My.Resources.LogoApplication.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(686, 293)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(202, 55)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label8)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(202, 354)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(698, 122)
        Me.FlowLayoutPanel2.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MenuFont"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CaptionFont"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "DefaultFont"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "DialogFont"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "IconTitleFont"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "MessageBoxFont"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "SmallCaptionFont"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "StatusFont"
        '
        'TimernAdherent
        '
        '
        'FrApplication
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(900, 476)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Icon = Global.AgriFact.My.Resources.Resources.Logo_Agrifact
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrApplication"
        Me.Text = "agriFact"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.npMenu.ResumeLayout(False)
        Me.NavigationPanePage1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Form Events"
    Private Sub FrApplication_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each lb As Label In Me.FlowLayoutPanel2.Controls
            lb.Font = SystemFonts.GetFontByName(lb.Text)
            lb.Text &= " " & lb.Font.ToString
        Next
        ShowFontPanelToolStripMenuItem_CheckedChanged(Nothing, Nothing)

        With Me.npMenu
            .Font = Me.MenuStrip1.Font
            .CaptionFont = New Font(.Font.FontFamily, 12.0!, FontStyle.Bold)
            .ButtonFont = New Font(.Font.FontFamily, 9.5!, FontStyle.Bold)
            .NavigationPages.Clear()
        End With

        Me.PictureBox1.Image = My.Resources.LogoApplication.Logo
        SetWindowText()

        'MODIF TV 09/01/2012 -------------------------------------------
        If Not (System.IO.File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIERXMLGESTIONMODULES))) Then
            If Not Actigram.Securite.GetLicence.VerifCle Then
                'Saisie de la clé d'activation
                Call New Securite.Activation.FrActivation().ShowDialog()
                versionDemo = Not Actigram.Securite.GetLicence.VerifCle
            Else
                versionDemo = False
            End If

            FrApplication.Modules = ChargementModules()
        Else
            versionDemo = False

            Dim m As New Actigram.Securite.Modules

            m.GetModuleFromXML(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIERXMLGESTIONMODULES))

            FrApplication.Modules = m
        End If

        If versionDemo Then
            Me.DonneesToolStripMenuItem.Visible = False
            Me.lbEval.Visible = True
            AssistantDémarrageToolStripMenuItem.Visible = False
        End If

        GestionMenu.Menu.ChargerMenus(Me.npMenu, AddressOf mnuClick)
        AffichageModules()
        ChargementDossier(True)

        'affichage menu Publicité
        Me.AfficherMenuPub()

        'gestion du timer
        If Not (My.Settings.IntervalleTimerAdherents Is Nothing) Then
            Me.TimernAdherent.Interval = CInt(My.Settings.IntervalleTimerAdherents)
        Else
            Me.TimernAdherent.Interval = 1000
        End If

        If (My.Settings.UtiliserTimerAdherents = "1") Then
            Me.TimernAdherent.Start()
        Else
            Me.TimernAdherent.Stop()
        End If
    End Sub

    Private Sub FrApplication_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        End
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function VerifAssistantPasse() As Boolean
        Dim AssistantPasse As Boolean = False
        Try
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(FrAssistantDemarrage.CleRegistre)
            If Not key Is Nothing Then
                Dim AssistantOK As String = Convert.ToString(key.GetValue("AssistantDemarrage"))
                If AssistantOK <> "" Then
                    AssistantPasse = True
                End If
            Else
                AssistantPasse = False
            End If
        Catch
            AssistantPasse = False
        End Try
        Return AssistantPasse
    End Function

    Private Function ChargementModules() As Actigram.Securite.Modules
        Dim m As Actigram.Securite.Modules
        If versionDemo Then
            m = New Actigram.Securite.Modules
            With m
                .ModuleGestionRelance = True
                .ModuleReglement = True
                .ModuleVente = True
            End With
        Else
            m = Actigram.Securite.GetLicence.ModuleActifs
            'm.ModuleAchat = False
            versionDemo = m.VersionDemo
        End If
        m.ModuleContact = True
        Return m
    End Function

    Private Sub ChargementDossier(Optional ByVal firstLoad As Boolean = False)
        ServiceNormal()
        'fr = Nothing

        Dim StartupDossier As String
        Dim StartupEntreprise As String
        Dim StartupProduit As String
        Dim StartupFactureId As String
        Dim StartupNFacture As String
        If firstLoad Then
            Dim args() As String = Environment.GetCommandLineArgs
            If args.Length > 1 Then
                For Each arg As String In args
                    Dim param As CommandParam = CommandParam.Parse(arg)
                    Select Case param.Name
                        Case "-dos" : StartupDossier = param.Value
                        Case "-ent" : StartupEntreprise = param.Value
                        Case "-prod" : StartupProduit = param.Value
                        Case "-factid" : StartupFactureId = param.Value
                        Case "-nfact" : StartupNFacture = param.Value
                    End Select
                Next
            End If
        End If

        If Not ChargementParametres(StartupDossier) Then
            ServiceMinimum()
            Exit Sub
        End If

        'Recherche des mises à jour
        If Parametres.VerifautoMAJ Then
            FrUpdates.VerifUpdates()
        End If

        'Préparation de la fenetre de connexion
        Dim frCn As FrConnexion
        If FrApplication.Parametres.LastLogin <> "" And FrApplication.Parametres.LastLogin <> "demo" Then
            frCn = New FrConnexion(Me, FrApplication.Parametres.LastLogin, "")
        Else
            frCn = New FrConnexion(Me, "demo", "demo")
        End If

        'Si le test de connexion est OK
        If frCn.ShowDialog() <> DialogResult.OK Then
            ServiceMinimum()
            Exit Sub
        End If
        ParametresApplication.EnregistrerParametre("LastLogin", Utilisateur)

        'Mettre en place la ConnectionString
        SqlProxy.SetDefaultConnection(DefinitionDonnees.GetstrConnexion(Utilisateur, Pwd))

        Try
            DefinitionDonnees.VerifierVersionBase()
        Catch ex As ApplicationException
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            ServiceMinimum()
            Exit Sub
        End Try

        Application.DoEvents()

        'Lecture des infos utilisateur
        Dim dtUtil As DataTable
        Using s As New SqlProxy
            dtUtil = s.ExecuteDataTable(SqlProxy.FormatSql("SELECT * FROM Utilisateurs WHERE Utilisateur={0}", Utilisateur))
        End Using
        Dim dv As New DataView(dtUtil)
        If dv.Count = 0 Then
            MsgBox("L'accès à cette base de données ne vous est pas autorisé.", MsgBoxStyle.Exclamation, "Autorisation")
            ServiceMinimum()
            Exit Sub
        Else
            dv(0)("Password") = Pwd
            GRC.FrBase.Autorisation = Convert.ToString(dv(0)("Departement"))
            If Not IsDBNull(dv(0)("nPersonne")) Then
                FrApplication.nUtilisateur = CInt(dv(0)("nPersonne"))
            End If
            'Initialisation des compteurs du Dataset !
            'ConfigDivers.ActuCompteur(fr.ds, FrApplication.nUtilisateur)
        End If

        'Lecture des infos Compta
        If FrApplication.Modules.ModuleCompta Then
            Compta.ChargerDonnees()
            SetLinkVisible("Compta", "Agrigest", Compta.ModeCompta <> Compta.ModesCompta.Deconnecte)
            SetLinkVisible("Compta", "Compta.Export", Compta.ModeExport <> Compta.ModesExport.Infovia)
            SetLinkVisible("Compta", "Compta.ExportFichier", Compta.ModeExport = Compta.ModesExport.Infovia)
        End If

        FrApplication.ValeurDefault = New ValeurDefaultApplication
        FrApplication.ValeurDefault.Charger()
        'FrMail.nUtilisateur = FrApplication.nUtilisateur

        'Eventuellement, assistant de démarrage
        If Not Parametres.VersionDemo AndAlso Not VerifAssistantPasse() Then
            Dim frA As New FrAssistantDemarrage() 'fr.ds
            frA.Owner = Me
            frA.ShowDialog()
        End If

        'Eventuellement ouverture automatique d'un écran
        Dim StartupForm As Form
        If Not StartupEntreprise Is Nothing Then
            StartupForm = New FrEntreprise(CInt(StartupEntreprise))
        ElseIf Not StartupProduit Is Nothing Then
            StartupForm = New FrProduit(CInt(StartupProduit))
        ElseIf Not StartupFactureId Is Nothing Then
            StartupForm = New FrBonCommande(CInt(StartupFactureId))
            With CType(StartupForm, FrBonCommande)
                .TypePiece = Pieces.TypePieces.VFacture
            End With
        ElseIf Not StartupNFacture Is Nothing Then
            StartupForm = New FrBonCommande()
            With CType(StartupForm, FrBonCommande)
                .TypePiece = Pieces.TypePieces.VFacture
                .FiltreType = "NFacture=" & StartupNFacture
            End With
        End If
        If Not StartupForm Is Nothing Then
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            StartupForm.MdiParent = Me
            StartupForm.Show()
            Cursor.Current = Cursors.Default
            Application.DoEvents()
        End If
    End Sub

    Private Function ChargementParametres(Optional ByVal StartupDossier As String = Nothing) As Boolean
        Try
            If ParametresApplication.ChargerParametres(StartupDossier) = DialogResult.Cancel Then Return False
            FrApplication.Parametres = New ParametresApplication
            FrApplication.Parametres.VersionDemo = versionDemo
            FrApplication.Parametres.Charger()
            Compta.ChargerParametres()
            SetWindowText()
            LogMessage(String.Format("Chargement du dossier '{0}' : Base '{1}' sur  '{2}'", FrApplication.Parametres.NomDossier, ParametresApplication.ValeurParametre("BaseSQL"), ParametresApplication.ValeurParametre("ServeurSQL")))
            Return True
        Catch ex As Exception
            Throw New Exception("Erreur de lecture du fichier paramétres", ex)
        End Try
    End Function

    Private Sub SetWindowText()
        Dim res As String = String.Format("{0} {1}", Application.ProductName, Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2))
        If Not FrApplication.Parametres Is Nothing Then
            res &= " - " & FrApplication.Parametres.NomDossier
            If FrApplication.Parametres.VersionDemo Then
                res &= " - " & lbEval.Text
            End If
        End If
        Me.Text = res
    End Sub

    Private Sub AfficherEcran(ByVal className As String, Optional ByVal asDialog As Boolean = False)
        Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
        If asm.GetType(asm.GetName.Name & "." & className, False) Is Nothing Then
            Throw New ApplicationException("Le nom de classe est incorrect")
        End If
        Dim f As Object = asm.CreateInstance(asm.GetName.Name & "." & className)
        If Not TypeOf f Is Form Then
            Throw New ApplicationException("La classe définie n'est pas un écran")
        End If
        ShowForm(CType(f, Form), asDialog)
    End Sub

    Private Sub ShowForm(ByVal newFr As Form, Optional ByVal asDialog As Boolean = False)
        If newFr Is Nothing Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        'If TypeOf newFr Is FrBase Then
        '    CType(newFr, FrBase).ds = fr.ds
        'End If
        Try
            For Each fr As Form In Me.MdiChildren
                If fr.OwnedForms.Length = 0 Then
                    fr.Close()
                End If
            Next
            If asDialog Then
                Me.Cursor = Cursors.Default
                newFr.ShowDialog(Me)
            Else
                newFr.MdiParent = Me
                newFr.Show()
            End If
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ServiceNormal()
        npMenu.Enabled = True
        For Each bt As ToolStripItem In Me.MenuStrip1.Items
            bt.Enabled = True
        Next
        Me.AdminToolStripMenuItem.Enabled = True
        Me.SauvegarderToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ServiceMinimum()
        'Desactiver la barre latérale
        npMenu.Enabled = False
        'Désactiver la barre d'outil sauf "Donnees", "Aide" et "Fermer"
        For Each bt As ToolStripItem In Me.MenuStrip1.Items
            bt.Enabled = (bt Is Me.DonneesToolStripMenuItem OrElse bt Is Me.AideToolStripMenuItem)
        Next
        'Désactiver le menu "Admin"
        Me.AdminToolStripMenuItem.Enabled = False
        'Désactiver le menu "Sauvegarde"
        Me.SauvegarderToolStripMenuItem.Enabled = False
    End Sub

    Private Sub SetPageVisible(ByVal pageKey As String, ByVal visible As Boolean)
        For Each npp As Ascend.Windows.Forms.NavigationPanePage In npMenu.NavigationPages
            If npp.Key = pageKey Then
                If Not visible Then
                    npMenu.NavigationPages.Remove(npp)
                End If
                'npp.Visible = visible
                Exit For
            End If
        Next
    End Sub

    Private Sub SetLinkVisible(ByVal pageKey As String, ByVal linkName As String, ByVal visible As Boolean)
        For Each npp As Ascend.Windows.Forms.NavigationPanePage In npMenu.NavigationPages
            If npp.Key = pageKey Then
                Dim layout As FlowLayoutPanel = CType(npp.Controls(0), FlowLayoutPanel)
                For Each ctl As Control In layout.Controls
                    If TypeOf ctl Is LinkLabel Then
                        If ctl.Name = linkName Then
                            ctl.Visible = visible
                            Exit For
                        End If
                    End If
                Next
                Exit For
            End If
        Next
    End Sub

    Private Sub AffichageModules()

        'SetPageVisible("Lots", Modules.ModuleLot)
        SetPageVisible("Stocks", Modules.ModuleStock)
        SetLinkVisible("Produits", "Tarifs", Modules.ModuleTarif)
        SetLinkVisible("Produits", "Approfact.ImportPhytoData", Modules.ModuleApproFact)
        SetPageVisible("Achats", Modules.ModuleAchat)
        SetLinkVisible("Partenaires", "Fournisseurs", Modules.ModuleTarif)
        SetPageVisible("Balance", Modules.ModuleBalance)
        SetPageVisible("Agenda", Modules.ModuleEvenement)
        SetLinkVisible("Achats", "Achats.Reglements", Modules.ModuleReglement)
        SetLinkVisible("Ventes", "Ventes.Reglements", Modules.ModuleReglement)
        SetLinkVisible("Ventes", "Remises", Modules.ModuleReglement)
        SetLinkVisible("Ventes", "Approfact.BilanPhyto", Modules.ModuleApproFact)
        SetPageVisible("Web", Modules.ModuleGestionWeb)
        SetPageVisible("Statistiques", Modules.ModuleGestionRelance)
        Me.TableauDeBordToolStripMenuItem.Visible = Modules.ModuleTableauBord

        If Modules.ModuleVente Then
            SetPageVisible("Ventes", True)
        Else
            If Modules.ModuleGestionWeb Then
                SetPageVisible("Ventes", True)
                SetLinkVisible("Ventes", "Devis", False)
                SetLinkVisible("Ventes", "BL", False)
                SetLinkVisible("Ventes", "Ventes.Factures", False)
            Else
                SetPageVisible("Ventes", False)
            End If
        End If
        SetPageVisible("Compta", Modules.ModuleCompta)
    End Sub

    Private Sub AfficherMenuPub()
        Dim ds As New DataSet

        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(ds, "Parametres", s)
        End Using

        For Each npp As Ascend.Windows.Forms.NavigationPanePage In npMenu.NavigationPages
            If npp.Key = "Pub" Then
                npp.Visible = CBool(ParametresBase.GetValeur(ds, "ActiverMenuPub", Nothing, "False"))

                Exit For
            End If
        Next

        npMenu.Refresh()
    End Sub
#End Region

#Region "Gestion Menus"
    Private Sub AideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IO.File.Exists("Aide\Guide AgriFact V2.0.pdf") Then
            Help.ShowHelp(Me, "Aide\Guide AgriFact V2.0.pdf")
        End If
    End Sub

    Private Sub TableauBordButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableauDeBordToolStripMenuItem.Click
        With New FrTableauBord()
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub QuitterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub SauvegarderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SauvegarderToolStripMenuItem.Click
        If FrApplication.Parametres.VersionDemo Then
            MessageBox.Show("La sauvegarde n'est pas disponible en version de démonstration", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Sauvegarde()
        End If
    End Sub

    Private Sub ActivationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivationToolStripMenuItem1.Click
        With New Securite.Activation.FrActivation
            .ShowDialog(Me)
        End With
        Actigram.Securite.GetLicence.VerifCle()
        Modules = Actigram.Securite.GetLicence.ModuleActifs
        AffichageModules()
    End Sub

    Private Sub MenuRestaure_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RestaurerToolStripMenuItem.Click
        Restaurer()
    End Sub

    Private Sub MenuMAJAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MisesÀJourToolStripMenuItem1.Click
        With New FrUpdates
            .ShowDialog(Me)
        End With
    End Sub

    'Private Sub MenuParametres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamètresToolStripMenuItem.Click
    '    With New FrParametres
    '        .ShowDialog(Me)
    '    End With
    'End Sub

    Private Sub MenuInfosGenerales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamètresToolStripMenuItem.Click
        With New FrInfosGenerales()
            .Owner = Me
            .Show()
        End With
    End Sub

    Private Sub MenuAssistantDemarrage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssistantDémarrageToolStripMenuItem.Click
        With New FrAssistantDemarrage()
            .Show(Me)
        End With
    End Sub

    Private Sub ParametrerListesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParametrerListesToolStripMenuItem.Click
        With New FrParametrerListes()
            .ShowDialog()
        End With
    End Sub

    Private Sub MenuUltraVNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraVNCToolStripMenuItem.Click
        With Me.UltraVNCToolStripMenuItem
            If .Checked Then
                StopVNC()
                .Checked = False
                .Text = "Ultra VNC"
            Else
                .Checked = True
                .Text = "Ultra VNC : Téléintervention en cours"
                StartVNC()
            End If
        End With
    End Sub

    Private Sub MenuNetViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NetViewerToolStripMenuItem.Click
        StartNetViewer()
    End Sub

    Private Sub mnuClick(ByVal sender As Object, ByVal e As EventArgs)
        If Not TypeOf CType(sender, LinkLabel).Tag Is GestionMenu.Item Then Exit Sub
        Dim i As GestionMenu.Item = CType(CType(sender, LinkLabel).Tag, GestionMenu.Item)
        If i.Form IsNot Nothing AndAlso i.Form.Length > 0 Then
            AfficherEcran(i.Form, i.Dialog)
        Else
            Select Case i.Nom
                Case "Clients", "Fournisseurs"
                    Dim frLstEntreprise As New FrListeClient()
                    frLstEntreprise.Text = "Liste " & i.Text
                    Select Case i.Nom
                        Case "Clients"
                            frLstEntreprise.TypeEntreprise = FrListeClient.TypesEntreprise.Client
                        Case "Fournisseurs"
                            frLstEntreprise.TypeEntreprise = FrListeClient.TypesEntreprise.Fournisseur
                    End Select
                    'Dim frLstEntreprise As FrBase = New FrListeClient_old(fr.ds)
                    'Select Case i.Nom
                    '    Case "Clients"
                    '        frLstEntreprise.FiltreType = "Client=True"
                    '    Case "Fournisseurs"
                    '        frLstEntreprise.FiltreType = "Fournisseur=True"
                    'End Select
                    'If FrBase.Autorisation <> "Tous" Then frLstEntreprise.FiltrePlus = "Dep='" & FrBase.Autorisation & "'"
                    ShowForm(frLstEntreprise)

                Case "BR", "Achats.Factures"
                    Dim frLstF As New FrListePieces2()
                    If i.Nom = "Achats.Factures" Then
                        frLstF.TypePiece = Pieces.TypePieces.AFacture
                    Else
                        frLstF.TypePiece = Pieces.TypePieces.ABonReception
                    End If
                    ShowForm(frLstF)
                Case "Achats.Reglements"
                    Dim FrLstRA As New FrListeReglement(FrListeReglement.TypeReglement.Achat)
                    ShowForm(FrLstRA)

                Case "Devis", "BC", "BL", "Ventes.Factures"
                    Dim frLstF1 As New FrListePieces2()
                    Select Case i.Nom
                        Case "Devis" : frLstF1.TypePiece = Pieces.TypePieces.VDevis
                        Case "BC" : frLstF1.TypePiece = Pieces.TypePieces.VBonCommande
                        Case "BL" : frLstF1.TypePiece = Pieces.TypePieces.VBonLivraison
                        Case "Ventes.Factures" : frLstF1.TypePiece = Pieces.TypePieces.VFacture
                    End Select
                    ShowForm(frLstF1)
                Case "Ventes.Reglements"
                    Dim frLstR As New FrListeReglement(FrListeReglement.TypeReglement.Vente)
                    ShowForm(frLstR)

                Case "Statistiques.Clients"
                    Dim newFr As New FrStatistiques()
                    newFr.Text = "Statistiques Clients"
                    ShowForm(newFr)

                Case "Statistiques.Produits"
                    Dim newFr As New FrStatistiques("Etats\RptStatsProduits")
                    newFr.Text = "Statistiques Produits"
                    ShowForm(newFr)

                Case "Statistiques.Perso"
                    Dim fichier As String
                    Using dlg As New OpenFileDialog
                        With dlg
                            .Filter = "Définition de requête (*.qml)|*.qml"
                            .InitialDirectory = IO.Path.Combine(My.Application.Info.DirectoryPath, "Requetes")
                            .Multiselect = False
                            If .ShowDialog = System.Windows.Forms.DialogResult.Cancel Then Exit Sub
                            fichier = .FileName
                        End With
                    End Using
                    Dim newfr As New RequetesPerso.FrRequetePerso(fichier)
                    newfr.ConnectionString = My.Settings.AgrifactConnString
                    newfr.WindowState = FormWindowState.Maximized
                    newfr.ControlBox = False
                    ShowForm(newfr)
                Case "Statistiques.Perso.Maquette"
                    Dim newfr As New RequetesPerso.FrMaquette()
                    newfr.ConnectionString = My.Settings.AgrifactConnString
                    newfr.WindowState = FormWindowState.Maximized
                    ShowForm(newfr)
                Case "Balance.RecupVentes"
                    Dim b As New GestionBalance()
                    If b.RecupVentes() Then ShowForm(New FrTableauBord())
                Case "Balance.RecupProduits"
                    Call (New GestionBalance()).RecupProduit()
                Case "Balance.Maj"
                    Call (New GestionBalance()).MajProduit()

                Case "Web.Maj"
                    With New GestionSite
                        '.dsSource = fr.ds
                        .login = ParametresApplication.ValeurParametre("IdMaj", "admin").ToString
                        .password = ParametresApplication.ValeurParametre("PwdMaj", "admin").ToString
                        .MajInfosSite()
                    End With

                Case "Web.Recup"
                    With New GestionSite
                        '.dsSource = fr.ds
                        .login = ParametresApplication.ValeurParametre("IdMaj", "admin").ToString
                        .password = ParametresApplication.ValeurParametre("PwdMaj", "admin").ToString
                        .RecupInfosSite()
                    End With

                Case "Agrigest"
                    Compta.OuvrirAgrigest()

                Case "Compta.Param"
                    Dim frPC As New FrParametreCompta()
                    If frPC.ShowDialog(Me) = DialogResult.OK Then
                        SetLinkVisible("Compta", "Agrigest", Compta.ModeCompta <> Compta.ModesCompta.Deconnecte)
                        SetLinkVisible("Compta", "Compta.Export", Compta.ModeExport <> Compta.ModesExport.Infovia)
                        SetLinkVisible("Compta", "Compta.ExportFichier", Compta.ModeExport = Compta.ModesExport.Infovia)
                    End If

                Case "Statistiques.Cubes"
                    Dim newFr As New FrCubes()
                    newFr.Text = "Cubes"
                    ShowForm(newFr)
            End Select
        End If
    End Sub

    Private Sub ShowFontPanelToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowFontPanelToolStripMenuItem.CheckedChanged
        Me.FlowLayoutPanel2.Visible = ShowFontPanelToolStripMenuItem.Checked
    End Sub
#End Region

#Region "Gestion Sauvegarde"
    Private Sub Sauvegarde()
        Dim opD As New SaveFileDialog
        With opD
            .FileName = String.Format("Sauvegarde {0} {1:dd-MM-yyyy}", Replace(FrApplication.Parametres.NomDossier, ".", ""), Now)
            .Filter = "Sauvegarde complète (*.afz)|*.afz;*.zip|Export données (*.xml)|*.xml"
            .FilterIndex = 0
            .AddExtension = True
            If .ShowDialog = DialogResult.OK Then
                If .FileName <> "" Then
                    Me.Cursor = Cursors.WaitCursor
                    Try
                        Select Case IO.Path.GetExtension(.FileName).ToLower
                            Case ".afz", ".zip"
                                frProgressionSauvegarde = New FrProgressBar
                                With frProgressionSauvegarde
                                    '.ShowInTaskbar = False
                                    .Maximum = 100
                                    '.Text = ""
                                    .Show()
                                End With
                                Try
                                    Dim gs As New GestionSauvegarde

                                    AddHandler gs.ReportsProgress, AddressOf ProgressionSauvegarde
                                    gs.Sauvegarder(.FileName)
                                Catch ex As Exception
                                    LogException(ex)
                                    MsgBox("La sauvegarde à échoué pour les raisons suivantes :" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Sauvegarde")
                                    Exit Sub
                                Finally
                                    frProgressionSauvegarde.Close()
                                End Try
                            Case ".xml"
                                MsgBox("Les sauvegardes au format XML ne sont plus supportées, veuillez nous contacter.", MsgBoxStyle.Exclamation)
                        End Select
                        MsgBox("Sauvegarde Terminée", MsgBoxStyle.Information, "Sauvegarde")
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try
                End If
            End If
        End With

    End Sub

    Private Sub Restaurer()
        Dim opD As New OpenFileDialog
        With opD
            .Filter = "Sauvegarde complète (*.afz)|*.afz;*.zip|Export données (*.xml)|*.xml"
            .FilterIndex = 0
            If .ShowDialog = DialogResult.OK Then
                If MsgBox("Cette opération va écraser les données actuelles de l'application." & vbCrLf & "Voulez-vous continuer ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
                Me.Cursor = Cursors.WaitCursor
                Try
                    Select Case IO.Path.GetExtension(.FileName).ToLower
                        Case ".afz", ".zip"
                            frProgressionSauvegarde = New FrProgressBar
                            With frProgressionSauvegarde
                                .Maximum = 100
                                .Text = ""
                            End With
                            Dim gs As New GestionSauvegarde

                            AddHandler gs.ReportsProgress, AddressOf ProgressionSauvegarde
                            gs.Restaurer(.FileName, Application.StartupPath)

                            frProgressionSauvegarde.Close()
                        Case ".xml"
                            MsgBox("Les sauvegardes au format XML ne sont plus supportées, veuillez nous contacter.", MsgBoxStyle.Exclamation)
                    End Select
                    MessageBox.Show("Restauration Terminé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    LogException(ex)
                    MsgBox(ex.Message)
                    frProgressionSauvegarde.Close()
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        End With
    End Sub

    Private Sub ProgressionSauvegarde(ByVal sender As Object, ByVal e As GestionSauvegarde.ProgressEventArgs)
        If Not frProgressionSauvegarde Is Nothing Then
            frProgressionSauvegarde.UpdateProgress(e.Progress, e.Status)
        End If
    End Sub
#End Region

#Region "Menu Debug"
    Private Sub RepertoireDAppli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirLeRépertoireDapplicationToolStripMenuItem1.Click
        OpenDir(Application.StartupPath)
    End Sub

    Private Sub LancerUtilitaire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilitaireToolStripMenuItem.Click
        Dim CurDos As String = Convert.ToString(ParametresApplication.ValeurParametre("NomDossier"))
        If CurDos.Length = 0 Then
            LaunchFile("utilitaire.exe")
        Else
            LaunchFile("utilitaire.exe", String.Format("-dos=""{0}""", CurDos))
        End If
    End Sub

    Private Sub LancerAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdminToolStripMenuItem.Click
        Dim CurDos As String = Convert.ToString(ParametresApplication.ValeurParametre("NomDossier"))
        If CurDos.Length = 0 Then
            LaunchFile("agrifactadmin.exe")
        Else
            LaunchFile("agrifactadmin.exe", String.Format("-dos=""{0}""", CurDos))
        End If
    End Sub

    Private Sub OuvrirLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AfficherLeFichierLogToolStripMenuItem.Click
        My.Application.Log.DefaultFileLogWriter.Flush()
        LaunchFile(My.Application.Log.DefaultFileLogWriter.FullLogFileName)
    End Sub

    Private Sub ChangerDossier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangerDeDossierToolStripMenuItem.Click
        For Each fr As Form In Me.MdiChildren
            If fr.OwnedForms.Length = 0 Then
                fr.Close()
            End If
        Next
        ChargementDossier()

        Me.AfficherMenuPub()
    End Sub
#End Region

#Region "IO.Utils"
    Private Sub OpenDir(ByVal path As String)
        Try
            If Not IO.Path.IsPathRooted(path) Then
                path = IO.Path.Combine(Application.StartupPath, path)
            End If
            If IO.Directory.Exists(path) Then
                Process.Start(path)
            Else
                MsgBox(String.Format("Le répertoire '{0}' est introuvable.", path), MsgBoxStyle.Exclamation, "Erreur")
            End If
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Erreur")
        End Try
    End Sub

    Private Sub LaunchFile(ByVal path As String, Optional ByVal arguments As String = Nothing)
        Try
            If Not IO.Path.IsPathRooted(path) Then
                path = IO.Path.Combine(Application.StartupPath, path)
            End If
            If IO.File.Exists(path) Then
                If arguments Is Nothing Then
                    Process.Start(path)
                Else
                    Process.Start(path, arguments)
                End If
            Else
                MsgBox(String.Format("Le fichier '{0}' est introuvable.", IO.Path.GetFileName(path)), MsgBoxStyle.Exclamation, "Erreur")
            End If
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Erreur")
        End Try
    End Sub
#End Region

#Region "Téléintervention"
    Private Sub StartVNC()
        Dim fr As New FrParamVNC
        With fr
            .ShowDialog()
        End With
    End Sub

    Private Sub StopVNC()
        UltraVnc.Instance.StopVNC()
    End Sub

    Private Sub StartNetViewer()
        Process.Start("http://www.netviewer.fr/joinsession")
        'Dim fr As New FrParamNV
        'With fr
        '    .ShowDialog()
        'End With
    End Sub
#End Region

#Region "Boutons"
    Private Sub AProposToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AProposToolStripMenuItem.Click
        Using fr As New AboutBox
            fr.ShowDialog()
        End Using
    End Sub
#End Region

#Region "Timer"
    Private Sub TimernAdherent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimernAdherent.Tick
        Dim cheminTemp As String = "\\" & My.Computer.Name & "\TempAgrifact\nAdherent.txt"
        Dim nEntreprise As Integer = 0

        If (System.IO.File.Exists(cheminTemp)) Then
            Using fs As New IO.FileStream(cheminTemp, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                fs.Close()

                'Ouverture du fichier
                Using sw As New IO.StreamReader(cheminTemp, System.Text.Encoding.UTF8)
                    Dim ligne As String = sw.ReadLine()

                    If (ligne <> String.Empty) Then
                        If IsNumeric(ligne) Then
                            Dim nAdh As Integer = Convert.ToInt32(ligne)

                            'Recherche de nEntreprise correspondant au nAdherent
                            If (nAdh > 0) Then
                                Using entTableAdapter As New DsAgrifactTableAdapters.EntrepriseTA
                                    Dim entDataTable As DsAgrifact.EntrepriseDataTable = entTableAdapter.GetDataBynAdherent(nAdh)

                                    For Each entDataRow As DsAgrifact.EntrepriseRow In entDataTable.Rows
                                        nEntreprise = CInt(entDataRow.nEntreprise)
                                    Next
                                End Using
                            End If
                        End If
                    End If
                End Using
            End Using

            'Suppression du fichier
            IO.File.Delete(cheminTemp)

            'Fermeture des formulaires enfants
            For Each fr As Form In Me.MdiChildren
                If fr.OwnedForms.Length = 0 Then
                    fr.Close()
                End If
            Next

            'Ouverture de la fiche Entreprise
            Dim frEnt As New FrEntreprise(nEntreprise)

            frEnt.MdiParent = Me
            frEnt.Show()
        End If
    End Sub
#End Region

End Class



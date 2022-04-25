<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrAssistantDemarrage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAssistantDemarrage))
        Me.wt = New GNWizardFrameWork.WizardTemplate
        Me.wpStart = New GNWizardFrameWork.WizardPage
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.wpInfos = New GNWizardFrameWork.WizardPage
        Me.TxEMail = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxFax = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxTel = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxAdresseSociete = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxNomSociete = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.wpClients = New GNWizardFrameWork.WizardPage
        Me.PnlComptaClient = New System.Windows.Forms.Panel
        Me.OptNCompteClientAutoOui = New System.Windows.Forms.RadioButton
        Me.OptNCompteClientAutoNon = New System.Windows.Forms.RadioButton
        Me.Label29 = New System.Windows.Forms.Label
        Me.TxNActiviteClient = New System.Windows.Forms.TextBox
        Me.TxNCompteClient = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.OptFacturationClientTTC = New System.Windows.Forms.RadioButton
        Me.OptFacturationClientHT = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.wpFourn = New GNWizardFrameWork.WizardPage
        Me.PnlComptaFournisseur = New System.Windows.Forms.Panel
        Me.OptNCompteFournisseurAutoOui = New System.Windows.Forms.RadioButton
        Me.OptNCompteFournisseurAutoNon = New System.Windows.Forms.RadioButton
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxNActiviteFournisseur = New System.Windows.Forms.TextBox
        Me.TxNCompteFournisseur = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.OptFacturationAchatTTC = New System.Windows.Forms.RadioButton
        Me.OptFacturationAchatHT = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.wpProds = New GNWizardFrameWork.WizardPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.OptNCompteProduitVAutoOui = New System.Windows.Forms.RadioButton
        Me.OptNCompteProduitVAutoNon = New System.Windows.Forms.RadioButton
        Me.Label34 = New System.Windows.Forms.Label
        Me.TxNActiviteProduitV = New System.Windows.Forms.TextBox
        Me.TxNCompteProduitV = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.OptDecompteAutoNon = New System.Windows.Forms.RadioButton
        Me.OptDecompteAutoOui = New System.Windows.Forms.RadioButton
        Me.Label21 = New System.Windows.Forms.Label
        Me.OptGestionStockNon = New System.Windows.Forms.RadioButton
        Me.OptGestionStockOui = New System.Windows.Forms.RadioButton
        Me.Label13 = New System.Windows.Forms.Label
        Me.CbTypeFacturation = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CbTxTVA = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.wpProdsAchats = New GNWizardFrameWork.WizardPage
        Me.PnlComptaProduitAchat = New System.Windows.Forms.Panel
        Me.OptNCompteProduitAAutoOui = New System.Windows.Forms.RadioButton
        Me.OptNCompteProduitAAutoNon = New System.Windows.Forms.RadioButton
        Me.Label38 = New System.Windows.Forms.Label
        Me.TxNActiviteProduitAchat = New System.Windows.Forms.TextBox
        Me.TxNCompteProduitAchat = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.PnlProduitAchat = New System.Windows.Forms.Panel
        Me.Label15 = New System.Windows.Forms.Label
        Me.OptProduitAchatOui = New System.Windows.Forms.RadioButton
        Me.OptProduitAchatNon = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.wpFact = New GNWizardFrameWork.WizardPage
        Me.pnlFactAchat = New System.Windows.Forms.Panel
        Me.Tx1NFactureAchat = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Tx1NFactureVente = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.wpAvance = New GNWizardFrameWork.WizardPage
        Me.TxPwd = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.TxLogin = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.TxPrenom = New System.Windows.Forms.TextBox
        Me.Label43 = New System.Windows.Forms.Label
        Me.TxNom = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.TxStandardModem = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxNPortModem = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.wt.SuspendLayout()
        Me.wpStart.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wpInfos.SuspendLayout()
        Me.wpClients.SuspendLayout()
        Me.PnlComptaClient.SuspendLayout()
        Me.wpFourn.SuspendLayout()
        Me.PnlComptaFournisseur.SuspendLayout()
        Me.wpProds.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.wpProdsAchats.SuspendLayout()
        Me.PnlComptaProduitAchat.SuspendLayout()
        Me.PnlProduitAchat.SuspendLayout()
        Me.wpFact.SuspendLayout()
        Me.pnlFactAchat.SuspendLayout()
        Me.wpAvance.SuspendLayout()
        Me.SuspendLayout()
        '
        'wt
        '
        Me.wt.BannerImage = Nothing
        Me.wt.CancelButtonText = "&Annuler"
        Me.wt.Controls.Add(Me.wpStart)
        Me.wt.Controls.Add(Me.wpInfos)
        Me.wt.Controls.Add(Me.wpClients)
        Me.wt.Controls.Add(Me.wpFourn)
        Me.wt.Controls.Add(Me.wpProds)
        Me.wt.Controls.Add(Me.wpProdsAchats)
        Me.wt.Controls.Add(Me.wpFact)
        Me.wt.Controls.Add(Me.wpAvance)
        Me.wt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wt.FinishButtonText = "&Terminer"
        Me.wt.Location = New System.Drawing.Point(0, 0)
        Me.wt.Name = "wt"
        Me.wt.NextButtonText = "&Suivant"
        Me.wt.Pages.Add(Me.wpStart)
        Me.wt.Pages.Add(Me.wpInfos)
        Me.wt.Pages.Add(Me.wpClients)
        Me.wt.Pages.Add(Me.wpFourn)
        Me.wt.Pages.Add(Me.wpProds)
        Me.wt.Pages.Add(Me.wpProdsAchats)
        Me.wt.Pages.Add(Me.wpFact)
        Me.wt.Pages.Add(Me.wpAvance)
        Me.wt.PreviousButtonText = "&Précédent"
        Me.wt.Size = New System.Drawing.Size(528, 353)
        Me.wt.StartItemIndex = 0
        Me.wt.TabIndex = 0
        '
        'wpStart
        '
        Me.wpStart.BackColor = System.Drawing.Color.White
        Me.wpStart.Controls.Add(Me.Label20)
        Me.wpStart.Controls.Add(Me.Label28)
        Me.wpStart.Controls.Add(Me.PictureBox1)
        Me.wpStart.Controls.Add(Me.Label1)
        Me.wpStart.HasCancelButton = True
        Me.wpStart.HasFinishButton = False
        Me.wpStart.HasNextButton = True
        Me.wpStart.HasPreviousButton = False
        Me.wpStart.HeaderCaption = "Wizard Item"
        Me.wpStart.Location = New System.Drawing.Point(0, 0)
        Me.wpStart.Name = "wpStart"
        Me.wpStart.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Exterior
        Me.wpStart.Size = New System.Drawing.Size(528, 313)
        Me.wpStart.SubHeaderCaption = "Panel Item"
        Me.wpStart.TabIndex = 4
        Me.wpStart.Text = "New Tab Item 1"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(188, 157)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(336, 40)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Cet Assistant vous guide tout au long des étapes de ce paramètrage."
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(188, 117)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(336, 40)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "L'assistant de démarrage vous permet paramètrer les valeurs par défaut de votre n" & _
            "ouvelle application."
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 313)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(186, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Assistant Démarrage"
        '
        'wpInfos
        '
        Me.wpInfos.Controls.Add(Me.TxEMail)
        Me.wpInfos.Controls.Add(Me.Label7)
        Me.wpInfos.Controls.Add(Me.TxFax)
        Me.wpInfos.Controls.Add(Me.Label6)
        Me.wpInfos.Controls.Add(Me.TxTel)
        Me.wpInfos.Controls.Add(Me.Label5)
        Me.wpInfos.Controls.Add(Me.TxAdresseSociete)
        Me.wpInfos.Controls.Add(Me.Label4)
        Me.wpInfos.Controls.Add(Me.TxNomSociete)
        Me.wpInfos.Controls.Add(Me.Label3)
        Me.wpInfos.HasCancelButton = True
        Me.wpInfos.HasFinishButton = False
        Me.wpInfos.HasNextButton = True
        Me.wpInfos.HasPreviousButton = True
        Me.wpInfos.HeaderCaption = "Informations générales"
        Me.wpInfos.Location = New System.Drawing.Point(0, 56)
        Me.wpInfos.Name = "wpInfos"
        Me.wpInfos.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpInfos.Size = New System.Drawing.Size(528, 257)
        Me.wpInfos.SubHeaderCaption = "Veuillez renseigner les informations suivantes"
        Me.wpInfos.TabIndex = 5
        Me.wpInfos.Text = "New Tab Item 2"
        '
        'TxEMail
        '
        Me.TxEMail.Location = New System.Drawing.Point(183, 177)
        Me.TxEMail.Name = "TxEMail"
        Me.TxEMail.Size = New System.Drawing.Size(304, 20)
        Me.TxEMail.TabIndex = 21
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(79, 179)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 16)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "E Mail :"
        '
        'TxFax
        '
        Me.TxFax.Location = New System.Drawing.Point(183, 145)
        Me.TxFax.Name = "TxFax"
        Me.TxFax.Size = New System.Drawing.Size(304, 20)
        Me.TxFax.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(79, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Fax :"
        '
        'TxTel
        '
        Me.TxTel.Location = New System.Drawing.Point(183, 113)
        Me.TxTel.Name = "TxTel"
        Me.TxTel.Size = New System.Drawing.Size(304, 20)
        Me.TxTel.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(79, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Téléphone :"
        '
        'TxAdresseSociete
        '
        Me.TxAdresseSociete.Location = New System.Drawing.Point(183, 47)
        Me.TxAdresseSociete.Multiline = True
        Me.TxAdresseSociete.Name = "TxAdresseSociete"
        Me.TxAdresseSociete.Size = New System.Drawing.Size(304, 58)
        Me.TxAdresseSociete.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(79, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Adresse :"
        '
        'TxNomSociete
        '
        Me.TxNomSociete.Location = New System.Drawing.Point(183, 17)
        Me.TxNomSociete.Name = "TxNomSociete"
        Me.TxNomSociete.Size = New System.Drawing.Size(304, 20)
        Me.TxNomSociete.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(79, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nom de la Société :"
        '
        'wpClients
        '
        Me.wpClients.Controls.Add(Me.PnlComptaClient)
        Me.wpClients.Controls.Add(Me.OptFacturationClientTTC)
        Me.wpClients.Controls.Add(Me.OptFacturationClientHT)
        Me.wpClients.Controls.Add(Me.Label8)
        Me.wpClients.HasCancelButton = True
        Me.wpClients.HasFinishButton = False
        Me.wpClients.HasNextButton = True
        Me.wpClients.HasPreviousButton = True
        Me.wpClients.HeaderCaption = "Clients"
        Me.wpClients.Location = New System.Drawing.Point(0, 56)
        Me.wpClients.Name = "wpClients"
        Me.wpClients.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpClients.Size = New System.Drawing.Size(528, 257)
        Me.wpClients.SubHeaderCaption = "Paramètres par défaut des nouveaux clients"
        Me.wpClients.TabIndex = 6
        Me.wpClients.Text = "New Tab Item 3"
        '
        'PnlComptaClient
        '
        Me.PnlComptaClient.Controls.Add(Me.OptNCompteClientAutoOui)
        Me.PnlComptaClient.Controls.Add(Me.OptNCompteClientAutoNon)
        Me.PnlComptaClient.Controls.Add(Me.Label29)
        Me.PnlComptaClient.Controls.Add(Me.TxNActiviteClient)
        Me.PnlComptaClient.Controls.Add(Me.TxNCompteClient)
        Me.PnlComptaClient.Controls.Add(Me.Label27)
        Me.PnlComptaClient.Controls.Add(Me.Label26)
        Me.PnlComptaClient.Controls.Add(Me.Label25)
        Me.PnlComptaClient.Location = New System.Drawing.Point(82, 82)
        Me.PnlComptaClient.Name = "PnlComptaClient"
        Me.PnlComptaClient.Size = New System.Drawing.Size(408, 112)
        Me.PnlComptaClient.TabIndex = 8
        '
        'OptNCompteClientAutoOui
        '
        Me.OptNCompteClientAutoOui.Location = New System.Drawing.Point(192, 88)
        Me.OptNCompteClientAutoOui.Name = "OptNCompteClientAutoOui"
        Me.OptNCompteClientAutoOui.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteClientAutoOui.TabIndex = 16
        Me.OptNCompteClientAutoOui.Text = "Oui"
        '
        'OptNCompteClientAutoNon
        '
        Me.OptNCompteClientAutoNon.Location = New System.Drawing.Point(280, 88)
        Me.OptNCompteClientAutoNon.Name = "OptNCompteClientAutoNon"
        Me.OptNCompteClientAutoNon.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteClientAutoNon.TabIndex = 17
        Me.OptNCompteClientAutoNon.Text = "Non"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(8, 90)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(184, 16)
        Me.Label29.TabIndex = 7
        Me.Label29.Text = "N° de Compte Automatique :"
        '
        'TxNActiviteClient
        '
        Me.TxNActiviteClient.Location = New System.Drawing.Point(176, 56)
        Me.TxNActiviteClient.MaxLength = 4
        Me.TxNActiviteClient.Name = "TxNActiviteClient"
        Me.TxNActiviteClient.Size = New System.Drawing.Size(100, 20)
        Me.TxNActiviteClient.TabIndex = 6
        '
        'TxNCompteClient
        '
        Me.TxNCompteClient.Location = New System.Drawing.Point(176, 30)
        Me.TxNCompteClient.MaxLength = 8
        Me.TxNCompteClient.Name = "TxNCompteClient"
        Me.TxNCompteClient.Size = New System.Drawing.Size(100, 20)
        Me.TxNCompteClient.TabIndex = 5
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(104, 58)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 16)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "N° Activité :"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(104, 32)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 16)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "N° Compte :"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(8, 8)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(352, 16)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "N° de Compte Client :"
        '
        'OptFacturationClientTTC
        '
        Me.OptFacturationClientTTC.Checked = True
        Me.OptFacturationClientTTC.Location = New System.Drawing.Point(189, 60)
        Me.OptFacturationClientTTC.Name = "OptFacturationClientTTC"
        Me.OptFacturationClientTTC.Size = New System.Drawing.Size(152, 16)
        Me.OptFacturationClientTTC.TabIndex = 7
        Me.OptFacturationClientTTC.TabStop = True
        Me.OptFacturationClientTTC.Text = "TTC"
        '
        'OptFacturationClientHT
        '
        Me.OptFacturationClientHT.Location = New System.Drawing.Point(189, 38)
        Me.OptFacturationClientHT.Name = "OptFacturationClientHT"
        Me.OptFacturationClientHT.Size = New System.Drawing.Size(152, 16)
        Me.OptFacturationClientHT.TabIndex = 6
        Me.OptFacturationClientHT.Text = "HT"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(79, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(352, 16)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "La facturation de vos clients doit-elle se faire par rapport à un prix  :"
        '
        'wpFourn
        '
        Me.wpFourn.Controls.Add(Me.PnlComptaFournisseur)
        Me.wpFourn.Controls.Add(Me.OptFacturationAchatTTC)
        Me.wpFourn.Controls.Add(Me.OptFacturationAchatHT)
        Me.wpFourn.Controls.Add(Me.Label9)
        Me.wpFourn.HasCancelButton = True
        Me.wpFourn.HasFinishButton = False
        Me.wpFourn.HasNextButton = True
        Me.wpFourn.HasPreviousButton = True
        Me.wpFourn.HeaderCaption = "Fournisseurs"
        Me.wpFourn.Location = New System.Drawing.Point(0, 56)
        Me.wpFourn.Name = "wpFourn"
        Me.wpFourn.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpFourn.Size = New System.Drawing.Size(528, 257)
        Me.wpFourn.SubHeaderCaption = "Paramétres par défaut des nouveaux fournisseurs"
        Me.wpFourn.TabIndex = 7
        Me.wpFourn.Text = "New Tab Item 4"
        '
        'PnlComptaFournisseur
        '
        Me.PnlComptaFournisseur.Controls.Add(Me.OptNCompteFournisseurAutoOui)
        Me.PnlComptaFournisseur.Controls.Add(Me.OptNCompteFournisseurAutoNon)
        Me.PnlComptaFournisseur.Controls.Add(Me.Label30)
        Me.PnlComptaFournisseur.Controls.Add(Me.TxNActiviteFournisseur)
        Me.PnlComptaFournisseur.Controls.Add(Me.TxNCompteFournisseur)
        Me.PnlComptaFournisseur.Controls.Add(Me.Label31)
        Me.PnlComptaFournisseur.Controls.Add(Me.Label32)
        Me.PnlComptaFournisseur.Controls.Add(Me.Label33)
        Me.PnlComptaFournisseur.Location = New System.Drawing.Point(82, 82)
        Me.PnlComptaFournisseur.Name = "PnlComptaFournisseur"
        Me.PnlComptaFournisseur.Size = New System.Drawing.Size(408, 112)
        Me.PnlComptaFournisseur.TabIndex = 11
        '
        'OptNCompteFournisseurAutoOui
        '
        Me.OptNCompteFournisseurAutoOui.Location = New System.Drawing.Point(192, 88)
        Me.OptNCompteFournisseurAutoOui.Name = "OptNCompteFournisseurAutoOui"
        Me.OptNCompteFournisseurAutoOui.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteFournisseurAutoOui.TabIndex = 16
        Me.OptNCompteFournisseurAutoOui.Text = "Oui"
        '
        'OptNCompteFournisseurAutoNon
        '
        Me.OptNCompteFournisseurAutoNon.Location = New System.Drawing.Point(280, 88)
        Me.OptNCompteFournisseurAutoNon.Name = "OptNCompteFournisseurAutoNon"
        Me.OptNCompteFournisseurAutoNon.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteFournisseurAutoNon.TabIndex = 17
        Me.OptNCompteFournisseurAutoNon.Text = "Non"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(8, 84)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(184, 24)
        Me.Label30.TabIndex = 7
        Me.Label30.Text = "N° de Compte Automatique :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxNActiviteFournisseur
        '
        Me.TxNActiviteFournisseur.Location = New System.Drawing.Point(176, 56)
        Me.TxNActiviteFournisseur.MaxLength = 4
        Me.TxNActiviteFournisseur.Name = "TxNActiviteFournisseur"
        Me.TxNActiviteFournisseur.Size = New System.Drawing.Size(100, 20)
        Me.TxNActiviteFournisseur.TabIndex = 6
        '
        'TxNCompteFournisseur
        '
        Me.TxNCompteFournisseur.Location = New System.Drawing.Point(176, 30)
        Me.TxNCompteFournisseur.MaxLength = 8
        Me.TxNCompteFournisseur.Name = "TxNCompteFournisseur"
        Me.TxNCompteFournisseur.Size = New System.Drawing.Size(100, 20)
        Me.TxNCompteFournisseur.TabIndex = 5
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(104, 58)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 16)
        Me.Label31.TabIndex = 4
        Me.Label31.Text = "N° Activité :"
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(104, 32)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(72, 16)
        Me.Label32.TabIndex = 3
        Me.Label32.Text = "N° Compte :"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 8)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(352, 16)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "N° de Compte Fournisseur :"
        '
        'OptFacturationAchatTTC
        '
        Me.OptFacturationAchatTTC.Location = New System.Drawing.Point(189, 60)
        Me.OptFacturationAchatTTC.Name = "OptFacturationAchatTTC"
        Me.OptFacturationAchatTTC.Size = New System.Drawing.Size(152, 16)
        Me.OptFacturationAchatTTC.TabIndex = 10
        Me.OptFacturationAchatTTC.Text = "TTC"
        '
        'OptFacturationAchatHT
        '
        Me.OptFacturationAchatHT.Checked = True
        Me.OptFacturationAchatHT.Location = New System.Drawing.Point(189, 38)
        Me.OptFacturationAchatHT.Name = "OptFacturationAchatHT"
        Me.OptFacturationAchatHT.Size = New System.Drawing.Size(152, 16)
        Me.OptFacturationAchatHT.TabIndex = 9
        Me.OptFacturationAchatHT.TabStop = True
        Me.OptFacturationAchatHT.Text = "HT"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(79, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(352, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "La facturation de vos achats doit-elle se faire par rapport à un prix  :"
        '
        'wpProds
        '
        Me.wpProds.Controls.Add(Me.Panel4)
        Me.wpProds.Controls.Add(Me.Panel2)
        Me.wpProds.Controls.Add(Me.OptGestionStockNon)
        Me.wpProds.Controls.Add(Me.OptGestionStockOui)
        Me.wpProds.Controls.Add(Me.Label13)
        Me.wpProds.Controls.Add(Me.CbTypeFacturation)
        Me.wpProds.Controls.Add(Me.Label12)
        Me.wpProds.Controls.Add(Me.CbTxTVA)
        Me.wpProds.Controls.Add(Me.Label11)
        Me.wpProds.HasCancelButton = True
        Me.wpProds.HasFinishButton = False
        Me.wpProds.HasNextButton = True
        Me.wpProds.HasPreviousButton = True
        Me.wpProds.HeaderCaption = "Produits"
        Me.wpProds.Location = New System.Drawing.Point(0, 56)
        Me.wpProds.Name = "wpProds"
        Me.wpProds.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpProds.Size = New System.Drawing.Size(528, 257)
        Me.wpProds.SubHeaderCaption = "Paramétres par défaut des nouveaux produits"
        Me.wpProds.TabIndex = 8
        Me.wpProds.Text = "New Tab Item 5"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.OptNCompteProduitVAutoOui)
        Me.Panel4.Controls.Add(Me.OptNCompteProduitVAutoNon)
        Me.Panel4.Controls.Add(Me.Label34)
        Me.Panel4.Controls.Add(Me.TxNActiviteProduitV)
        Me.Panel4.Controls.Add(Me.TxNCompteProduitV)
        Me.Panel4.Controls.Add(Me.Label35)
        Me.Panel4.Controls.Add(Me.Label36)
        Me.Panel4.Controls.Add(Me.Label37)
        Me.Panel4.Location = New System.Drawing.Point(82, 123)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(408, 112)
        Me.Panel4.TabIndex = 32
        '
        'OptNCompteProduitVAutoOui
        '
        Me.OptNCompteProduitVAutoOui.Location = New System.Drawing.Point(192, 88)
        Me.OptNCompteProduitVAutoOui.Name = "OptNCompteProduitVAutoOui"
        Me.OptNCompteProduitVAutoOui.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteProduitVAutoOui.TabIndex = 16
        Me.OptNCompteProduitVAutoOui.Text = "Oui"
        '
        'OptNCompteProduitVAutoNon
        '
        Me.OptNCompteProduitVAutoNon.Location = New System.Drawing.Point(270, 88)
        Me.OptNCompteProduitVAutoNon.Name = "OptNCompteProduitVAutoNon"
        Me.OptNCompteProduitVAutoNon.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteProduitVAutoNon.TabIndex = 17
        Me.OptNCompteProduitVAutoNon.Text = "Non"
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(8, 90)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(184, 16)
        Me.Label34.TabIndex = 7
        Me.Label34.Text = "N° de Compte Automatique :"
        '
        'TxNActiviteProduitV
        '
        Me.TxNActiviteProduitV.Location = New System.Drawing.Point(176, 56)
        Me.TxNActiviteProduitV.MaxLength = 4
        Me.TxNActiviteProduitV.Name = "TxNActiviteProduitV"
        Me.TxNActiviteProduitV.Size = New System.Drawing.Size(100, 20)
        Me.TxNActiviteProduitV.TabIndex = 6
        '
        'TxNCompteProduitV
        '
        Me.TxNCompteProduitV.Location = New System.Drawing.Point(176, 30)
        Me.TxNCompteProduitV.MaxLength = 8
        Me.TxNCompteProduitV.Name = "TxNCompteProduitV"
        Me.TxNCompteProduitV.Size = New System.Drawing.Size(100, 20)
        Me.TxNCompteProduitV.TabIndex = 5
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(104, 58)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(72, 16)
        Me.Label35.TabIndex = 4
        Me.Label35.Text = "N° Activité :"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(104, 32)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(72, 16)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "N° Compte :"
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(8, 8)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(352, 16)
        Me.Label37.TabIndex = 2
        Me.Label37.Text = "N° de Compte Produit Vente :"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.OptDecompteAutoNon)
        Me.Panel2.Controls.Add(Me.OptDecompteAutoOui)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Location = New System.Drawing.Point(82, 91)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(376, 24)
        Me.Panel2.TabIndex = 31
        '
        'OptDecompteAutoNon
        '
        Me.OptDecompteAutoNon.Location = New System.Drawing.Point(237, 8)
        Me.OptDecompteAutoNon.Name = "OptDecompteAutoNon"
        Me.OptDecompteAutoNon.Size = New System.Drawing.Size(72, 16)
        Me.OptDecompteAutoNon.TabIndex = 20
        Me.OptDecompteAutoNon.Text = "Non"
        '
        'OptDecompteAutoOui
        '
        Me.OptDecompteAutoOui.Location = New System.Drawing.Point(149, 8)
        Me.OptDecompteAutoOui.Name = "OptDecompteAutoOui"
        Me.OptDecompteAutoOui.Size = New System.Drawing.Size(72, 16)
        Me.OptDecompteAutoOui.TabIndex = 19
        Me.OptDecompteAutoOui.Text = "Oui"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(-3, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(152, 16)
        Me.Label21.TabIndex = 18
        Me.Label21.Text = "Décompte Automatique"
        '
        'OptGestionStockNon
        '
        Me.OptGestionStockNon.Location = New System.Drawing.Point(319, 72)
        Me.OptGestionStockNon.Name = "OptGestionStockNon"
        Me.OptGestionStockNon.Size = New System.Drawing.Size(72, 16)
        Me.OptGestionStockNon.TabIndex = 30
        Me.OptGestionStockNon.Text = "Non"
        '
        'OptGestionStockOui
        '
        Me.OptGestionStockOui.Location = New System.Drawing.Point(231, 72)
        Me.OptGestionStockOui.Name = "OptGestionStockOui"
        Me.OptGestionStockOui.Size = New System.Drawing.Size(72, 16)
        Me.OptGestionStockOui.TabIndex = 29
        Me.OptGestionStockOui.Text = "Oui"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(79, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(152, 16)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Gestion des Stocks"
        '
        'CbTypeFacturation
        '
        Me.CbTypeFacturation.Location = New System.Drawing.Point(231, 44)
        Me.CbTypeFacturation.Name = "CbTypeFacturation"
        Me.CbTypeFacturation.Size = New System.Drawing.Size(200, 21)
        Me.CbTypeFacturation.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(79, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(152, 23)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Unité de Facturation"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbTxTVA
        '
        Me.CbTxTVA.Location = New System.Drawing.Point(231, 20)
        Me.CbTxTVA.Name = "CbTxTVA"
        Me.CbTxTVA.Size = New System.Drawing.Size(200, 21)
        Me.CbTxTVA.TabIndex = 25
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(79, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(152, 23)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Taux de TVA le plus utilisé"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'wpProdsAchats
        '
        Me.wpProdsAchats.Controls.Add(Me.PnlComptaProduitAchat)
        Me.wpProdsAchats.Controls.Add(Me.PnlProduitAchat)
        Me.wpProdsAchats.HasCancelButton = True
        Me.wpProdsAchats.HasFinishButton = False
        Me.wpProdsAchats.HasNextButton = True
        Me.wpProdsAchats.HasPreviousButton = True
        Me.wpProdsAchats.HeaderCaption = "Produits achetés"
        Me.wpProdsAchats.Location = New System.Drawing.Point(0, 56)
        Me.wpProdsAchats.Name = "wpProdsAchats"
        Me.wpProdsAchats.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpProdsAchats.Size = New System.Drawing.Size(528, 257)
        Me.wpProdsAchats.SubHeaderCaption = "Paramétres par défaut pour les nouvelles fournitures"
        Me.wpProdsAchats.TabIndex = 9
        Me.wpProdsAchats.Text = "New Tab Item 6"
        '
        'PnlComptaProduitAchat
        '
        Me.PnlComptaProduitAchat.Controls.Add(Me.OptNCompteProduitAAutoOui)
        Me.PnlComptaProduitAchat.Controls.Add(Me.OptNCompteProduitAAutoNon)
        Me.PnlComptaProduitAchat.Controls.Add(Me.Label38)
        Me.PnlComptaProduitAchat.Controls.Add(Me.TxNActiviteProduitAchat)
        Me.PnlComptaProduitAchat.Controls.Add(Me.TxNCompteProduitAchat)
        Me.PnlComptaProduitAchat.Controls.Add(Me.Label39)
        Me.PnlComptaProduitAchat.Controls.Add(Me.Label40)
        Me.PnlComptaProduitAchat.Controls.Add(Me.Label41)
        Me.PnlComptaProduitAchat.Location = New System.Drawing.Point(79, 81)
        Me.PnlComptaProduitAchat.Name = "PnlComptaProduitAchat"
        Me.PnlComptaProduitAchat.Size = New System.Drawing.Size(408, 112)
        Me.PnlComptaProduitAchat.TabIndex = 25
        '
        'OptNCompteProduitAAutoOui
        '
        Me.OptNCompteProduitAAutoOui.Location = New System.Drawing.Point(192, 88)
        Me.OptNCompteProduitAAutoOui.Name = "OptNCompteProduitAAutoOui"
        Me.OptNCompteProduitAAutoOui.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteProduitAAutoOui.TabIndex = 16
        Me.OptNCompteProduitAAutoOui.Text = "Oui"
        '
        'OptNCompteProduitAAutoNon
        '
        Me.OptNCompteProduitAAutoNon.Location = New System.Drawing.Point(280, 88)
        Me.OptNCompteProduitAAutoNon.Name = "OptNCompteProduitAAutoNon"
        Me.OptNCompteProduitAAutoNon.Size = New System.Drawing.Size(72, 16)
        Me.OptNCompteProduitAAutoNon.TabIndex = 17
        Me.OptNCompteProduitAAutoNon.Text = "Non"
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(8, 88)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(184, 16)
        Me.Label38.TabIndex = 7
        Me.Label38.Text = "N° de Compte Automatique :"
        '
        'TxNActiviteProduitAchat
        '
        Me.TxNActiviteProduitAchat.Location = New System.Drawing.Point(176, 56)
        Me.TxNActiviteProduitAchat.MaxLength = 4
        Me.TxNActiviteProduitAchat.Name = "TxNActiviteProduitAchat"
        Me.TxNActiviteProduitAchat.Size = New System.Drawing.Size(100, 20)
        Me.TxNActiviteProduitAchat.TabIndex = 6
        '
        'TxNCompteProduitAchat
        '
        Me.TxNCompteProduitAchat.Location = New System.Drawing.Point(176, 30)
        Me.TxNCompteProduitAchat.MaxLength = 8
        Me.TxNCompteProduitAchat.Name = "TxNCompteProduitAchat"
        Me.TxNCompteProduitAchat.Size = New System.Drawing.Size(100, 20)
        Me.TxNCompteProduitAchat.TabIndex = 5
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(104, 58)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(72, 16)
        Me.Label39.TabIndex = 4
        Me.Label39.Text = "N° Activité :"
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(104, 32)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(72, 16)
        Me.Label40.TabIndex = 3
        Me.Label40.Text = "N° Compte :"
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(8, 8)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(352, 16)
        Me.Label41.TabIndex = 2
        Me.Label41.Text = "N° de Compte Produit Achat :"
        '
        'PnlProduitAchat
        '
        Me.PnlProduitAchat.Controls.Add(Me.Label15)
        Me.PnlProduitAchat.Controls.Add(Me.OptProduitAchatOui)
        Me.PnlProduitAchat.Controls.Add(Me.OptProduitAchatNon)
        Me.PnlProduitAchat.Controls.Add(Me.Label14)
        Me.PnlProduitAchat.Location = New System.Drawing.Point(79, 19)
        Me.PnlProduitAchat.Name = "PnlProduitAchat"
        Me.PnlProduitAchat.Size = New System.Drawing.Size(376, 56)
        Me.PnlProduitAchat.TabIndex = 24
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(352, 16)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Produits d'Achats  :"
        '
        'OptProduitAchatOui
        '
        Me.OptProduitAchatOui.Location = New System.Drawing.Point(184, 32)
        Me.OptProduitAchatOui.Name = "OptProduitAchatOui"
        Me.OptProduitAchatOui.Size = New System.Drawing.Size(72, 16)
        Me.OptProduitAchatOui.TabIndex = 14
        Me.OptProduitAchatOui.Text = "Oui"
        '
        'OptProduitAchatNon
        '
        Me.OptProduitAchatNon.Location = New System.Drawing.Point(272, 32)
        Me.OptProduitAchatNon.Name = "OptProduitAchatNon"
        Me.OptProduitAchatNon.Size = New System.Drawing.Size(72, 16)
        Me.OptProduitAchatNon.TabIndex = 15
        Me.OptProduitAchatNon.Text = "Non"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(32, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 16)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Produit d'Achat"
        '
        'wpFact
        '
        Me.wpFact.Controls.Add(Me.pnlFactAchat)
        Me.wpFact.Controls.Add(Me.Tx1NFactureVente)
        Me.wpFact.Controls.Add(Me.Label17)
        Me.wpFact.Controls.Add(Me.Label16)
        Me.wpFact.HasCancelButton = True
        Me.wpFact.HasFinishButton = False
        Me.wpFact.HasNextButton = True
        Me.wpFact.HasPreviousButton = True
        Me.wpFact.HeaderCaption = "Facturation"
        Me.wpFact.Location = New System.Drawing.Point(0, 56)
        Me.wpFact.Name = "wpFact"
        Me.wpFact.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpFact.Size = New System.Drawing.Size(528, 257)
        Me.wpFact.SubHeaderCaption = "Initialisation de la numérotation des factures"
        Me.wpFact.TabIndex = 10
        Me.wpFact.Text = "New Tab Item 7"
        '
        'pnlFactAchat
        '
        Me.pnlFactAchat.Controls.Add(Me.Tx1NFactureAchat)
        Me.pnlFactAchat.Controls.Add(Me.Label18)
        Me.pnlFactAchat.Controls.Add(Me.Label19)
        Me.pnlFactAchat.Location = New System.Drawing.Point(79, 99)
        Me.pnlFactAchat.Name = "pnlFactAchat"
        Me.pnlFactAchat.Size = New System.Drawing.Size(368, 64)
        Me.pnlFactAchat.TabIndex = 13
        '
        'Tx1NFactureAchat
        '
        Me.Tx1NFactureAchat.Location = New System.Drawing.Point(160, 32)
        Me.Tx1NFactureAchat.Name = "Tx1NFactureAchat"
        Me.Tx1NFactureAchat.Size = New System.Drawing.Size(200, 20)
        Me.Tx1NFactureAchat.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(24, 31)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(136, 23)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Premier n° de Facture"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(352, 16)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Factures d' Achats  :"
        '
        'Tx1NFactureVente
        '
        Me.Tx1NFactureVente.Location = New System.Drawing.Point(243, 46)
        Me.Tx1NFactureVente.Name = "Tx1NFactureVente"
        Me.Tx1NFactureVente.Size = New System.Drawing.Size(200, 20)
        Me.Tx1NFactureVente.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(103, 42)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Premier n° de Facture"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(87, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(352, 16)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Factures de Ventes  :"
        '
        'wpAvance
        '
        Me.wpAvance.Controls.Add(Me.TxPwd)
        Me.wpAvance.Controls.Add(Me.Label46)
        Me.wpAvance.Controls.Add(Me.TxLogin)
        Me.wpAvance.Controls.Add(Me.Label45)
        Me.wpAvance.Controls.Add(Me.TxPrenom)
        Me.wpAvance.Controls.Add(Me.Label43)
        Me.wpAvance.Controls.Add(Me.TxNom)
        Me.wpAvance.Controls.Add(Me.Label44)
        Me.wpAvance.Controls.Add(Me.Label42)
        Me.wpAvance.Controls.Add(Me.TxStandardModem)
        Me.wpAvance.Controls.Add(Me.Label24)
        Me.wpAvance.Controls.Add(Me.TxNPortModem)
        Me.wpAvance.Controls.Add(Me.Label22)
        Me.wpAvance.Controls.Add(Me.Label23)
        Me.wpAvance.HasCancelButton = True
        Me.wpAvance.HasFinishButton = True
        Me.wpAvance.HasNextButton = False
        Me.wpAvance.HasPreviousButton = True
        Me.wpAvance.HeaderCaption = "Options avancées"
        Me.wpAvance.Location = New System.Drawing.Point(0, 56)
        Me.wpAvance.Name = "wpAvance"
        Me.wpAvance.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpAvance.Size = New System.Drawing.Size(528, 257)
        Me.wpAvance.SubHeaderCaption = "Identifiant de connexion et options de téléphonie"
        Me.wpAvance.TabIndex = 11
        Me.wpAvance.Text = "New Tab Item 8"
        '
        'TxPwd
        '
        Me.TxPwd.Location = New System.Drawing.Point(175, 91)
        Me.TxPwd.Name = "TxPwd"
        Me.TxPwd.Size = New System.Drawing.Size(256, 20)
        Me.TxPwd.TabIndex = 34
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(95, 93)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(72, 16)
        Me.Label46.TabIndex = 33
        Me.Label46.Text = "Mot de passe"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxLogin
        '
        Me.TxLogin.Location = New System.Drawing.Point(175, 67)
        Me.TxLogin.Name = "TxLogin"
        Me.TxLogin.Size = New System.Drawing.Size(256, 20)
        Me.TxLogin.TabIndex = 32
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(95, 69)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(64, 16)
        Me.Label45.TabIndex = 31
        Me.Label45.Text = "Identifiant"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxPrenom
        '
        Me.TxPrenom.Location = New System.Drawing.Point(311, 43)
        Me.TxPrenom.Name = "TxPrenom"
        Me.TxPrenom.Size = New System.Drawing.Size(120, 20)
        Me.TxPrenom.TabIndex = 30
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(263, 42)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(48, 23)
        Me.Label43.TabIndex = 29
        Me.Label43.Text = "Prénom"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxNom
        '
        Me.TxNom.Location = New System.Drawing.Point(135, 43)
        Me.TxNom.Name = "TxNom"
        Me.TxNom.Size = New System.Drawing.Size(120, 20)
        Me.TxNom.TabIndex = 28
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(95, 45)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(40, 16)
        Me.Label44.TabIndex = 27
        Me.Label44.Text = "Nom"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(79, 19)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(352, 16)
        Me.Label42.TabIndex = 26
        Me.Label42.Text = "Identification :"
        '
        'TxStandardModem
        '
        Me.TxStandardModem.Location = New System.Drawing.Point(231, 187)
        Me.TxStandardModem.Name = "TxStandardModem"
        Me.TxStandardModem.Size = New System.Drawing.Size(200, 20)
        Me.TxStandardModem.TabIndex = 25
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(95, 187)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(136, 23)
        Me.Label24.TabIndex = 24
        Me.Label24.Text = "Préfixe pour le Standard"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxNPortModem
        '
        Me.TxNPortModem.Location = New System.Drawing.Point(231, 155)
        Me.TxNPortModem.Name = "TxNPortModem"
        Me.TxNPortModem.Size = New System.Drawing.Size(200, 20)
        Me.TxNPortModem.TabIndex = 23
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(95, 155)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(136, 23)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "N° de port de votre Modem"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(79, 131)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(352, 16)
        Me.Label23.TabIndex = 21
        Me.Label23.Text = "Communication :"
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(0, 75)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(73, 313)
        Me.Panel3.TabIndex = 22
        '
        'FrAssistantDemarrage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 353)
        Me.ControlBox = False
        Me.Controls.Add(Me.wt)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrAssistantDemarrage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assistant Démarrage"
        Me.wt.ResumeLayout(False)
        Me.wpStart.ResumeLayout(False)
        Me.wpStart.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wpInfos.ResumeLayout(False)
        Me.wpInfos.PerformLayout()
        Me.wpClients.ResumeLayout(False)
        Me.PnlComptaClient.ResumeLayout(False)
        Me.PnlComptaClient.PerformLayout()
        Me.wpFourn.ResumeLayout(False)
        Me.PnlComptaFournisseur.ResumeLayout(False)
        Me.PnlComptaFournisseur.PerformLayout()
        Me.wpProds.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.wpProdsAchats.ResumeLayout(False)
        Me.PnlComptaProduitAchat.ResumeLayout(False)
        Me.PnlComptaProduitAchat.PerformLayout()
        Me.PnlProduitAchat.ResumeLayout(False)
        Me.wpFact.ResumeLayout(False)
        Me.wpFact.PerformLayout()
        Me.pnlFactAchat.ResumeLayout(False)
        Me.pnlFactAchat.PerformLayout()
        Me.wpAvance.ResumeLayout(False)
        Me.wpAvance.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wt As GNWizardFrameWork.WizardTemplate
    Friend WithEvents wpStart As GNWizardFrameWork.WizardPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents wpInfos As GNWizardFrameWork.WizardPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxEMail As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxFax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxTel As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxAdresseSociete As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxNomSociete As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents wpClients As GNWizardFrameWork.WizardPage
    Friend WithEvents PnlComptaClient As System.Windows.Forms.Panel
    Friend WithEvents OptNCompteClientAutoOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptNCompteClientAutoNon As System.Windows.Forms.RadioButton
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxNActiviteClient As System.Windows.Forms.TextBox
    Friend WithEvents TxNCompteClient As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents OptFacturationClientTTC As System.Windows.Forms.RadioButton
    Friend WithEvents OptFacturationClientHT As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents wpFourn As GNWizardFrameWork.WizardPage
    Friend WithEvents PnlComptaFournisseur As System.Windows.Forms.Panel
    Friend WithEvents OptNCompteFournisseurAutoOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptNCompteFournisseurAutoNon As System.Windows.Forms.RadioButton
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxNActiviteFournisseur As System.Windows.Forms.TextBox
    Friend WithEvents TxNCompteFournisseur As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents OptFacturationAchatTTC As System.Windows.Forms.RadioButton
    Friend WithEvents OptFacturationAchatHT As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents wpProds As GNWizardFrameWork.WizardPage
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents OptNCompteProduitVAutoOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptNCompteProduitVAutoNon As System.Windows.Forms.RadioButton
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxNActiviteProduitV As System.Windows.Forms.TextBox
    Friend WithEvents TxNCompteProduitV As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents OptDecompteAutoNon As System.Windows.Forms.RadioButton
    Friend WithEvents OptDecompteAutoOui As System.Windows.Forms.RadioButton
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents OptGestionStockNon As System.Windows.Forms.RadioButton
    Friend WithEvents OptGestionStockOui As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CbTypeFacturation As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CbTxTVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents wpProdsAchats As GNWizardFrameWork.WizardPage
    Friend WithEvents PnlComptaProduitAchat As System.Windows.Forms.Panel
    Friend WithEvents OptNCompteProduitAAutoOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptNCompteProduitAAutoNon As System.Windows.Forms.RadioButton
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TxNActiviteProduitAchat As System.Windows.Forms.TextBox
    Friend WithEvents TxNCompteProduitAchat As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents PnlProduitAchat As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents OptProduitAchatOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptProduitAchatNon As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents wpFact As GNWizardFrameWork.WizardPage
    Friend WithEvents pnlFactAchat As System.Windows.Forms.Panel
    Friend WithEvents Tx1NFactureAchat As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Tx1NFactureVente As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents wpAvance As GNWizardFrameWork.WizardPage
    Friend WithEvents TxPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TxLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TxPrenom As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TxNom As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TxStandardModem As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxNPortModem As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel

End Class

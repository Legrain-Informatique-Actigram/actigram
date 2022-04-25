Imports GRC

Public Class FrListeParam
    Inherits GRC.FrBase

    Dim myDs As DataSet
    Dim strLibelleSelection As String = ""
    Friend WithEvents ColFJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAdresse As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVille As System.Windows.Forms.DataGridViewTextBoxColumn
    Dim repEtats As String = CheminComplet("Etats\RptStats")

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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbCLose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbMail As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbCreerEv As System.Windows.Forms.ToolStripButton
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents pbCarteFrance As System.Windows.Forms.PictureBox
    Friend WithEvents dgvEntreprises As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents BtSuivant As System.Windows.Forms.Button
    Friend WithEvents BtPrecedent As System.Windows.Forms.Button
    Friend WithEvents BtTermine As System.Windows.Forms.Button
    Friend WithEvents OptParticipantOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptParticipantNon As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OptDepartement As System.Windows.Forms.RadioButton
    Friend WithEvents OptCodePostal As System.Windows.Forms.RadioButton
    Friend WithEvents OptVille As System.Windows.Forms.RadioButton
    Friend WithEvents LstGeo As System.Windows.Forms.CheckedListBox
    Friend WithEvents OptZoneGeographiqueOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptZoneGeographiqueNon As System.Windows.Forms.RadioButton
    Friend WithEvents OptEntrepriseOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptEntrepriseNon As System.Windows.Forms.RadioButton
    Friend WithEvents TbEntreprise As System.Windows.Forms.TabPage
    Friend WithEvents TbZoneGeo As System.Windows.Forms.TabPage
    Friend WithEvents TbEvenement As System.Windows.Forms.TabPage
    Friend WithEvents TbResultat As System.Windows.Forms.TabPage
    Friend WithEvents TbFacture As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OptFactureOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptFactureNon As System.Windows.Forms.RadioButton
    Friend WithEvents TbProduit As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OptProduitOui As System.Windows.Forms.RadioButton
    Friend WithEvents OptProduitNon As System.Windows.Forms.RadioButton
    Friend WithEvents TbModele As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LstModele As System.Windows.Forms.ListBox
    Friend WithEvents saveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PnGeo As System.Windows.Forms.Panel
    Friend WithEvents gcEntreprises As AgriFact.GestionControles
    Friend WithEvents gcParticipant As AgriFact.GestionControles
    Friend WithEvents gcFacture As AgriFact.GestionControles
    Friend WithEvents gcProduit As AgriFact.GestionControles
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrListeParam))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TbModele = New System.Windows.Forms.TabPage
        Me.LstModele = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TbZoneGeo = New System.Windows.Forms.TabPage
        Me.pbCarteFrance = New System.Windows.Forms.PictureBox
        Me.PnGeo = New System.Windows.Forms.Panel
        Me.LstGeo = New System.Windows.Forms.CheckedListBox
        Me.OptVille = New System.Windows.Forms.RadioButton
        Me.OptCodePostal = New System.Windows.Forms.RadioButton
        Me.OptDepartement = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.OptZoneGeographiqueOui = New System.Windows.Forms.RadioButton
        Me.OptZoneGeographiqueNon = New System.Windows.Forms.RadioButton
        Me.TbEntreprise = New System.Windows.Forms.TabPage
        Me.Label1 = New System.Windows.Forms.Label
        Me.OptEntrepriseOui = New System.Windows.Forms.RadioButton
        Me.OptEntrepriseNon = New System.Windows.Forms.RadioButton
        Me.gcEntreprises = New AgriFact.GestionControles
        Me.TbEvenement = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.OptParticipantOui = New System.Windows.Forms.RadioButton
        Me.OptParticipantNon = New System.Windows.Forms.RadioButton
        Me.gcParticipant = New AgriFact.GestionControles
        Me.TbFacture = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.OptFactureOui = New System.Windows.Forms.RadioButton
        Me.OptFactureNon = New System.Windows.Forms.RadioButton
        Me.gcFacture = New AgriFact.GestionControles
        Me.TbProduit = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.OptProduitOui = New System.Windows.Forms.RadioButton
        Me.OptProduitNon = New System.Windows.Forms.RadioButton
        Me.gcProduit = New AgriFact.GestionControles
        Me.TbResultat = New System.Windows.Forms.TabPage
        Me.dgvEntreprises = New System.Windows.Forms.DataGridView
        Me.BtSuivant = New System.Windows.Forms.Button
        Me.BtPrecedent = New System.Windows.Forms.Button
        Me.BtTermine = New System.Windows.Forms.Button
        Me.saveDialog = New System.Windows.Forms.SaveFileDialog
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbExport = New System.Windows.Forms.ToolStripButton
        Me.TbCLose = New System.Windows.Forms.ToolStripButton
        Me.TbMail = New System.Windows.Forms.ToolStripButton
        Me.TbCreerEv = New System.Windows.Forms.ToolStripButton
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.ColFJ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColNom = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColAdresse = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColCP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColVille = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.TbModele.SuspendLayout()
        Me.TbZoneGeo.SuspendLayout()
        CType(Me.pbCarteFrance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnGeo.SuspendLayout()
        Me.TbEntreprise.SuspendLayout()
        Me.TbEvenement.SuspendLayout()
        Me.TbFacture.SuspendLayout()
        Me.TbProduit.SuspendLayout()
        Me.TbResultat.SuspendLayout()
        CType(Me.dgvEntreprises, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList16.Images.SetKeyName(0, "")
        '
        'ImageList32
        '
        Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList32.Images.SetKeyName(0, "")
        Me.ImageList32.Images.SetKeyName(1, "")
        Me.ImageList32.Images.SetKeyName(2, "")
        Me.ImageList32.Images.SetKeyName(3, "")
        Me.ImageList32.Images.SetKeyName(4, "")
        Me.ImageList32.Images.SetKeyName(5, "")
        Me.ImageList32.Images.SetKeyName(6, "")
        Me.ImageList32.Images.SetKeyName(7, "")
        Me.ImageList32.Images.SetKeyName(8, "")
        Me.ImageList32.Images.SetKeyName(9, "")
        Me.ImageList32.Images.SetKeyName(10, "")
        Me.ImageList32.Images.SetKeyName(11, "")
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList24.Images.SetKeyName(0, "")
        Me.ImageList24.Images.SetKeyName(1, "")
        Me.ImageList24.Images.SetKeyName(2, "")
        Me.ImageList24.Images.SetKeyName(3, "")
        Me.ImageList24.Images.SetKeyName(4, "")
        Me.ImageList24.Images.SetKeyName(5, "")
        Me.ImageList24.Images.SetKeyName(6, "")
        Me.ImageList24.Images.SetKeyName(7, "")
        Me.ImageList24.Images.SetKeyName(8, "")
        Me.ImageList24.Images.SetKeyName(9, "")
        Me.ImageList24.Images.SetKeyName(10, "")
        Me.ImageList24.Images.SetKeyName(11, "")
        Me.ImageList24.Images.SetKeyName(12, "")
        Me.ImageList24.Images.SetKeyName(13, "")
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TbModele)
        Me.TabControl1.Controls.Add(Me.TbZoneGeo)
        Me.TabControl1.Controls.Add(Me.TbEntreprise)
        Me.TabControl1.Controls.Add(Me.TbEvenement)
        Me.TabControl1.Controls.Add(Me.TbFacture)
        Me.TabControl1.Controls.Add(Me.TbProduit)
        Me.TabControl1.Controls.Add(Me.TbResultat)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 407)
        Me.TabControl1.TabIndex = 0
        '
        'TbModele
        '
        Me.TbModele.BackColor = System.Drawing.Color.White
        Me.TbModele.Controls.Add(Me.LstModele)
        Me.TbModele.Controls.Add(Me.Label6)
        Me.TbModele.Location = New System.Drawing.Point(4, 22)
        Me.TbModele.Name = "TbModele"
        Me.TbModele.Size = New System.Drawing.Size(784, 381)
        Me.TbModele.TabIndex = 8
        Me.TbModele.Text = "Modèle"
        Me.TbModele.UseVisualStyleBackColor = True
        '
        'LstModele
        '
        Me.LstModele.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstModele.Location = New System.Drawing.Point(11, 29)
        Me.LstModele.Name = "LstModele"
        Me.LstModele.Size = New System.Drawing.Size(765, 342)
        Me.LstModele.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Choissez votre modèle :"
        '
        'TbZoneGeo
        '
        Me.TbZoneGeo.BackColor = System.Drawing.Color.White
        Me.TbZoneGeo.Controls.Add(Me.pbCarteFrance)
        Me.TbZoneGeo.Controls.Add(Me.PnGeo)
        Me.TbZoneGeo.Controls.Add(Me.Label4)
        Me.TbZoneGeo.Controls.Add(Me.OptZoneGeographiqueOui)
        Me.TbZoneGeo.Controls.Add(Me.OptZoneGeographiqueNon)
        Me.TbZoneGeo.Location = New System.Drawing.Point(4, 22)
        Me.TbZoneGeo.Name = "TbZoneGeo"
        Me.TbZoneGeo.Size = New System.Drawing.Size(784, 381)
        Me.TbZoneGeo.TabIndex = 5
        Me.TbZoneGeo.Text = "Zone Géographique"
        Me.TbZoneGeo.UseVisualStyleBackColor = True
        '
        'pbCarteFrance
        '
        Me.pbCarteFrance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbCarteFrance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbCarteFrance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbCarteFrance.Image = Global.AgriFact.My.Resources.Resources.FranceR3
        Me.pbCarteFrance.Location = New System.Drawing.Point(732, 3)
        Me.pbCarteFrance.Name = "pbCarteFrance"
        Me.pbCarteFrance.Size = New System.Drawing.Size(44, 42)
        Me.pbCarteFrance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCarteFrance.TabIndex = 14
        Me.pbCarteFrance.TabStop = False
        '
        'PnGeo
        '
        Me.PnGeo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnGeo.AutoScroll = True
        Me.PnGeo.Controls.Add(Me.LstGeo)
        Me.PnGeo.Controls.Add(Me.OptVille)
        Me.PnGeo.Controls.Add(Me.OptCodePostal)
        Me.PnGeo.Controls.Add(Me.OptDepartement)
        Me.PnGeo.Enabled = False
        Me.PnGeo.Location = New System.Drawing.Point(0, 48)
        Me.PnGeo.Name = "PnGeo"
        Me.PnGeo.Size = New System.Drawing.Size(784, 330)
        Me.PnGeo.TabIndex = 11
        '
        'LstGeo
        '
        Me.LstGeo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstGeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstGeo.CheckOnClick = True
        Me.LstGeo.Location = New System.Drawing.Point(134, 8)
        Me.LstGeo.Name = "LstGeo"
        Me.LstGeo.Size = New System.Drawing.Size(642, 317)
        Me.LstGeo.TabIndex = 3
        '
        'OptVille
        '
        Me.OptVille.Location = New System.Drawing.Point(8, 56)
        Me.OptVille.Name = "OptVille"
        Me.OptVille.Size = New System.Drawing.Size(120, 16)
        Me.OptVille.TabIndex = 2
        Me.OptVille.Text = "Par Ville"
        '
        'OptCodePostal
        '
        Me.OptCodePostal.Location = New System.Drawing.Point(8, 32)
        Me.OptCodePostal.Name = "OptCodePostal"
        Me.OptCodePostal.Size = New System.Drawing.Size(120, 16)
        Me.OptCodePostal.TabIndex = 1
        Me.OptCodePostal.Text = "Par Code Postal"
        '
        'OptDepartement
        '
        Me.OptDepartement.Location = New System.Drawing.Point(8, 8)
        Me.OptDepartement.Name = "OptDepartement"
        Me.OptDepartement.Size = New System.Drawing.Size(120, 16)
        Me.OptDepartement.TabIndex = 0
        Me.OptDepartement.Text = "Par département"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(264, 32)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Souhaitez-vous effectuer un Tri en fonction de leurs zone géographique ?"
        '
        'OptZoneGeographiqueOui
        '
        Me.OptZoneGeographiqueOui.Location = New System.Drawing.Point(278, 24)
        Me.OptZoneGeographiqueOui.Name = "OptZoneGeographiqueOui"
        Me.OptZoneGeographiqueOui.Size = New System.Drawing.Size(136, 16)
        Me.OptZoneGeographiqueOui.TabIndex = 9
        Me.OptZoneGeographiqueOui.Text = "Oui"
        '
        'OptZoneGeographiqueNon
        '
        Me.OptZoneGeographiqueNon.Location = New System.Drawing.Point(278, 8)
        Me.OptZoneGeographiqueNon.Name = "OptZoneGeographiqueNon"
        Me.OptZoneGeographiqueNon.Size = New System.Drawing.Size(136, 16)
        Me.OptZoneGeographiqueNon.TabIndex = 8
        Me.OptZoneGeographiqueNon.Text = "Non"
        '
        'TbEntreprise
        '
        Me.TbEntreprise.BackColor = System.Drawing.Color.White
        Me.TbEntreprise.Controls.Add(Me.Label1)
        Me.TbEntreprise.Controls.Add(Me.OptEntrepriseOui)
        Me.TbEntreprise.Controls.Add(Me.OptEntrepriseNon)
        Me.TbEntreprise.Controls.Add(Me.gcEntreprises)
        Me.TbEntreprise.Location = New System.Drawing.Point(4, 22)
        Me.TbEntreprise.Name = "TbEntreprise"
        Me.TbEntreprise.Size = New System.Drawing.Size(784, 381)
        Me.TbEntreprise.TabIndex = 0
        Me.TbEntreprise.Text = "Entreprises"
        Me.TbEntreprise.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Souhaitez-vous effectuer un Tri les Entreprises ?"
        '
        'OptEntrepriseOui
        '
        Me.OptEntrepriseOui.Location = New System.Drawing.Point(278, 24)
        Me.OptEntrepriseOui.Name = "OptEntrepriseOui"
        Me.OptEntrepriseOui.Size = New System.Drawing.Size(136, 16)
        Me.OptEntrepriseOui.TabIndex = 6
        Me.OptEntrepriseOui.Text = "Oui"
        '
        'OptEntrepriseNon
        '
        Me.OptEntrepriseNon.Location = New System.Drawing.Point(278, 8)
        Me.OptEntrepriseNon.Name = "OptEntrepriseNon"
        Me.OptEntrepriseNon.Size = New System.Drawing.Size(136, 16)
        Me.OptEntrepriseNon.TabIndex = 5
        Me.OptEntrepriseNon.Text = "Non"
        '
        'gcEntreprises
        '
        Me.gcEntreprises.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcEntreprises.AutorisationListe = Nothing
        Me.gcEntreprises.Autorisations = ""
        Me.gcEntreprises.AutoriseAjt = True
        Me.gcEntreprises.AutoriseModif = True
        Me.gcEntreprises.AutoriseSuppr = True
        Me.gcEntreprises.AutoSize = True
        Me.gcEntreprises.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcEntreprises.DataSource = Nothing
        Me.gcEntreprises.DsBase = Nothing
        Me.gcEntreprises.Enabled = False
        Me.gcEntreprises.FiltreAffichage = ""
        Me.gcEntreprises.Label1Top = 10
        Me.gcEntreprises.LabelLeft = 10
        Me.gcEntreprises.LargeurText = 250
        Me.gcEntreprises.LiaisonDonnees = False
        Me.gcEntreprises.Lien = Nothing
        Me.gcEntreprises.LigneHauteur = 20
        Me.gcEntreprises.LigneIntervale = 5
        Me.gcEntreprises.Location = New System.Drawing.Point(16, 48)
        Me.gcEntreprises.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcEntreprises.Name = "gcEntreprises"
        Me.gcEntreprises.NomTableConfig = Nothing
        Me.gcEntreprises.NuméroNiveau1 = 0
        Me.gcEntreprises.Size = New System.Drawing.Size(760, 322)
        Me.gcEntreprises.TabIndex = 1
        Me.gcEntreprises.Table = "Entreprise"
        Me.gcEntreprises.TableListeChoix = "ListeChoix"
        Me.gcEntreprises.TableParam = "Niveau2"
        Me.gcEntreprises.TexteLeft = 250
        Me.gcEntreprises.TypeRecherche = True
        '
        'TbEvenement
        '
        Me.TbEvenement.BackColor = System.Drawing.Color.White
        Me.TbEvenement.Controls.Add(Me.Label3)
        Me.TbEvenement.Controls.Add(Me.OptParticipantOui)
        Me.TbEvenement.Controls.Add(Me.OptParticipantNon)
        Me.TbEvenement.Controls.Add(Me.gcParticipant)
        Me.TbEvenement.Location = New System.Drawing.Point(4, 22)
        Me.TbEvenement.Name = "TbEvenement"
        Me.TbEvenement.Size = New System.Drawing.Size(784, 381)
        Me.TbEvenement.TabIndex = 2
        Me.TbEvenement.Text = "Participant Evénement"
        Me.TbEvenement.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(260, 37)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Souhaitez-vous effectuer un Tri sur les Evenements aux quels ont participés ces I" & _
            "ndividus ?"
        '
        'OptParticipantOui
        '
        Me.OptParticipantOui.Location = New System.Drawing.Point(274, 22)
        Me.OptParticipantOui.Name = "OptParticipantOui"
        Me.OptParticipantOui.Size = New System.Drawing.Size(136, 16)
        Me.OptParticipantOui.TabIndex = 7
        Me.OptParticipantOui.Text = "Oui"
        '
        'OptParticipantNon
        '
        Me.OptParticipantNon.Location = New System.Drawing.Point(274, 6)
        Me.OptParticipantNon.Name = "OptParticipantNon"
        Me.OptParticipantNon.Size = New System.Drawing.Size(136, 16)
        Me.OptParticipantNon.TabIndex = 6
        Me.OptParticipantNon.Text = "Non"
        '
        'gcParticipant
        '
        Me.gcParticipant.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcParticipant.AutorisationListe = Nothing
        Me.gcParticipant.Autorisations = ""
        Me.gcParticipant.AutoriseAjt = True
        Me.gcParticipant.AutoriseModif = True
        Me.gcParticipant.AutoriseSuppr = True
        Me.gcParticipant.AutoSize = True
        Me.gcParticipant.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcParticipant.DataSource = Nothing
        Me.gcParticipant.DsBase = Nothing
        Me.gcParticipant.Enabled = False
        Me.gcParticipant.FiltreAffichage = ""
        Me.gcParticipant.Label1Top = 10
        Me.gcParticipant.LabelLeft = 10
        Me.gcParticipant.LargeurText = 250
        Me.gcParticipant.LiaisonDonnees = False
        Me.gcParticipant.Lien = Nothing
        Me.gcParticipant.LigneHauteur = 20
        Me.gcParticipant.LigneIntervale = 5
        Me.gcParticipant.Location = New System.Drawing.Point(16, 48)
        Me.gcParticipant.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcParticipant.Name = "gcParticipant"
        Me.gcParticipant.NomTableConfig = Nothing
        Me.gcParticipant.NuméroNiveau1 = 0
        Me.gcParticipant.Size = New System.Drawing.Size(760, 314)
        Me.gcParticipant.TabIndex = 5
        Me.gcParticipant.Table = "Evenement"
        Me.gcParticipant.TableListeChoix = "ListeChoix"
        Me.gcParticipant.TableParam = "Niveau2"
        Me.gcParticipant.TexteLeft = 200
        Me.gcParticipant.TypeRecherche = True
        '
        'TbFacture
        '
        Me.TbFacture.BackColor = System.Drawing.Color.White
        Me.TbFacture.Controls.Add(Me.Label2)
        Me.TbFacture.Controls.Add(Me.OptFactureOui)
        Me.TbFacture.Controls.Add(Me.OptFactureNon)
        Me.TbFacture.Controls.Add(Me.gcFacture)
        Me.TbFacture.Location = New System.Drawing.Point(4, 22)
        Me.TbFacture.Name = "TbFacture"
        Me.TbFacture.Size = New System.Drawing.Size(784, 381)
        Me.TbFacture.TabIndex = 6
        Me.TbFacture.Text = "Factures"
        Me.TbFacture.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Souhaitez-vous effectuer un Tri les Factures ?"
        '
        'OptFactureOui
        '
        Me.OptFactureOui.Location = New System.Drawing.Point(278, 23)
        Me.OptFactureOui.Name = "OptFactureOui"
        Me.OptFactureOui.Size = New System.Drawing.Size(136, 16)
        Me.OptFactureOui.TabIndex = 10
        Me.OptFactureOui.Text = "Oui"
        '
        'OptFactureNon
        '
        Me.OptFactureNon.Location = New System.Drawing.Point(278, 7)
        Me.OptFactureNon.Name = "OptFactureNon"
        Me.OptFactureNon.Size = New System.Drawing.Size(136, 16)
        Me.OptFactureNon.TabIndex = 9
        Me.OptFactureNon.Text = "Non"
        '
        'gcFacture
        '
        Me.gcFacture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcFacture.AutorisationListe = Nothing
        Me.gcFacture.Autorisations = ""
        Me.gcFacture.AutoriseAjt = True
        Me.gcFacture.AutoriseModif = True
        Me.gcFacture.AutoriseSuppr = True
        Me.gcFacture.AutoSize = True
        Me.gcFacture.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcFacture.DataSource = Nothing
        Me.gcFacture.DsBase = Nothing
        Me.gcFacture.Enabled = False
        Me.gcFacture.FiltreAffichage = ""
        Me.gcFacture.Label1Top = 10
        Me.gcFacture.LabelLeft = 10
        Me.gcFacture.LargeurText = 250
        Me.gcFacture.LiaisonDonnees = False
        Me.gcFacture.Lien = Nothing
        Me.gcFacture.LigneHauteur = 20
        Me.gcFacture.LigneIntervale = 5
        Me.gcFacture.Location = New System.Drawing.Point(16, 49)
        Me.gcFacture.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcFacture.Name = "gcFacture"
        Me.gcFacture.NomTableConfig = Nothing
        Me.gcFacture.NuméroNiveau1 = 0
        Me.gcFacture.Size = New System.Drawing.Size(760, 322)
        Me.gcFacture.TabIndex = 8
        Me.gcFacture.Table = "VFacture"
        Me.gcFacture.TableListeChoix = "ListeChoix"
        Me.gcFacture.TableParam = "Niveau2"
        Me.gcFacture.TexteLeft = 250
        Me.gcFacture.TypeRecherche = True
        '
        'TbProduit
        '
        Me.TbProduit.BackColor = System.Drawing.Color.White
        Me.TbProduit.Controls.Add(Me.Label5)
        Me.TbProduit.Controls.Add(Me.OptProduitOui)
        Me.TbProduit.Controls.Add(Me.OptProduitNon)
        Me.TbProduit.Controls.Add(Me.gcProduit)
        Me.TbProduit.Location = New System.Drawing.Point(4, 22)
        Me.TbProduit.Name = "TbProduit"
        Me.TbProduit.Size = New System.Drawing.Size(784, 381)
        Me.TbProduit.TabIndex = 7
        Me.TbProduit.Text = "Produits"
        Me.TbProduit.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(264, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Souhaitez-vous effectuer un Tri les Produits ?"
        '
        'OptProduitOui
        '
        Me.OptProduitOui.Location = New System.Drawing.Point(278, 23)
        Me.OptProduitOui.Name = "OptProduitOui"
        Me.OptProduitOui.Size = New System.Drawing.Size(136, 16)
        Me.OptProduitOui.TabIndex = 14
        Me.OptProduitOui.Text = "Oui"
        '
        'OptProduitNon
        '
        Me.OptProduitNon.Location = New System.Drawing.Point(278, 7)
        Me.OptProduitNon.Name = "OptProduitNon"
        Me.OptProduitNon.Size = New System.Drawing.Size(136, 16)
        Me.OptProduitNon.TabIndex = 13
        Me.OptProduitNon.Text = "Non"
        '
        'gcProduit
        '
        Me.gcProduit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gcProduit.AutorisationListe = Nothing
        Me.gcProduit.Autorisations = ""
        Me.gcProduit.AutoriseAjt = True
        Me.gcProduit.AutoriseModif = True
        Me.gcProduit.AutoriseSuppr = True
        Me.gcProduit.AutoSize = True
        Me.gcProduit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gcProduit.DataSource = Nothing
        Me.gcProduit.DsBase = Nothing
        Me.gcProduit.Enabled = False
        Me.gcProduit.FiltreAffichage = ""
        Me.gcProduit.Label1Top = 10
        Me.gcProduit.LabelLeft = 10
        Me.gcProduit.LargeurText = 250
        Me.gcProduit.LiaisonDonnees = False
        Me.gcProduit.Lien = Nothing
        Me.gcProduit.LigneHauteur = 20
        Me.gcProduit.LigneIntervale = 5
        Me.gcProduit.Location = New System.Drawing.Point(16, 49)
        Me.gcProduit.MinimumSize = New System.Drawing.Size(150, 150)
        Me.gcProduit.Name = "gcProduit"
        Me.gcProduit.NomTableConfig = Nothing
        Me.gcProduit.NuméroNiveau1 = 0
        Me.gcProduit.Size = New System.Drawing.Size(760, 322)
        Me.gcProduit.TabIndex = 12
        Me.gcProduit.Table = "Produit"
        Me.gcProduit.TableListeChoix = "ListeChoix"
        Me.gcProduit.TableParam = "Niveau2"
        Me.gcProduit.TexteLeft = 250
        Me.gcProduit.TypeRecherche = True
        '
        'TbResultat
        '
        Me.TbResultat.Controls.Add(Me.dgvEntreprises)
        Me.TbResultat.Location = New System.Drawing.Point(4, 22)
        Me.TbResultat.Name = "TbResultat"
        Me.TbResultat.Size = New System.Drawing.Size(784, 381)
        Me.TbResultat.TabIndex = 4
        Me.TbResultat.Text = "Résultat"
        Me.TbResultat.UseVisualStyleBackColor = True
        '
        'dgvEntreprises
        '
        Me.dgvEntreprises.AllowUserToAddRows = False
        Me.dgvEntreprises.AllowUserToDeleteRows = False
        Me.dgvEntreprises.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntreprises.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColFJ, Me.ColNom, Me.ColAdresse, Me.ColCP, Me.ColVille})
        Me.dgvEntreprises.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEntreprises.Location = New System.Drawing.Point(0, 0)
        Me.dgvEntreprises.Name = "dgvEntreprises"
        Me.dgvEntreprises.ReadOnly = True
        Me.dgvEntreprises.Size = New System.Drawing.Size(784, 381)
        Me.dgvEntreprises.TabIndex = 0
        '
        'BtSuivant
        '
        Me.BtSuivant.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtSuivant.Location = New System.Drawing.Point(628, 9)
        Me.BtSuivant.Name = "BtSuivant"
        Me.BtSuivant.Size = New System.Drawing.Size(74, 24)
        Me.BtSuivant.TabIndex = 1
        Me.BtSuivant.Text = "Suivant >"
        '
        'BtPrecedent
        '
        Me.BtPrecedent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtPrecedent.Location = New System.Drawing.Point(548, 9)
        Me.BtPrecedent.Name = "BtPrecedent"
        Me.BtPrecedent.Size = New System.Drawing.Size(74, 24)
        Me.BtPrecedent.TabIndex = 2
        Me.BtPrecedent.Text = "< Précédent"
        '
        'BtTermine
        '
        Me.BtTermine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtTermine.Location = New System.Drawing.Point(708, 9)
        Me.BtTermine.Name = "BtTermine"
        Me.BtTermine.Size = New System.Drawing.Size(72, 24)
        Me.BtTermine.TabIndex = 3
        Me.BtTermine.Text = "Terminer"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbExport, Me.TbCLose, Me.TbMail, Me.TbCreerEv})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(792, 25)
        Me.ToolStrip1.TabIndex = 10
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbExport
        '
        Me.TbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbExport.Image = Global.AgriFact.My.Resources.Resources.export
        Me.TbExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbExport.Name = "TbExport"
        Me.TbExport.Size = New System.Drawing.Size(23, 22)
        Me.TbExport.Text = "Export"
        '
        'TbCLose
        '
        Me.TbCLose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbCLose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbCLose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbCLose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbCLose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbCLose.Name = "TbCLose"
        Me.TbCLose.Size = New System.Drawing.Size(23, 22)
        Me.TbCLose.Text = "Fermer"
        '
        'TbMail
        '
        Me.TbMail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbMail.Image = Global.AgriFact.My.Resources.Resources.eps_openHS
        Me.TbMail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbMail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbMail.Name = "TbMail"
        Me.TbMail.Size = New System.Drawing.Size(23, 22)
        Me.TbMail.Text = "Envoi Mail"
        '
        'TbCreerEv
        '
        Me.TbCreerEv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbCreerEv.Image = Global.AgriFact.My.Resources.Resources.Agenda
        Me.TbCreerEv.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbCreerEv.Name = "TbCreerEv"
        Me.TbCreerEv.Size = New System.Drawing.Size(23, 22)
        Me.TbCreerEv.Text = "Créer Evenement"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtTermine)
        Me.GradientPanel2.Controls.Add(Me.BtSuivant)
        Me.GradientPanel2.Controls.Add(Me.BtPrecedent)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 432)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(792, 45)
        Me.GradientPanel2.TabIndex = 21
        '
        'ColFJ
        '
        Me.ColFJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColFJ.DataPropertyName = "Civilite"
        Me.ColFJ.HeaderText = ""
        Me.ColFJ.Name = "ColFJ"
        Me.ColFJ.ReadOnly = True
        Me.ColFJ.Width = 19
        '
        'ColNom
        '
        Me.ColNom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNom.DataPropertyName = "Nom"
        Me.ColNom.HeaderText = "Nom"
        Me.ColNom.Name = "ColNom"
        Me.ColNom.ReadOnly = True
        '
        'ColAdresse
        '
        Me.ColAdresse.DataPropertyName = "Adresse"
        Me.ColAdresse.HeaderText = "Adresse"
        Me.ColAdresse.Name = "ColAdresse"
        Me.ColAdresse.ReadOnly = True
        Me.ColAdresse.Width = 300
        '
        'ColCP
        '
        Me.ColCP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColCP.DataPropertyName = "CodePostal"
        Me.ColCP.HeaderText = "Code Postal"
        Me.ColCP.Name = "ColCP"
        Me.ColCP.ReadOnly = True
        Me.ColCP.Width = 89
        '
        'ColVille
        '
        Me.ColVille.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColVille.DataPropertyName = "Ville"
        Me.ColVille.HeaderText = "Ville"
        Me.ColVille.Name = "ColVille"
        Me.ColVille.ReadOnly = True
        Me.ColVille.Width = 51
        '
        'FrListeParam
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 477)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrListeParam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assistant Requête"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TbModele.ResumeLayout(False)
        Me.TbZoneGeo.ResumeLayout(False)
        CType(Me.pbCarteFrance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnGeo.ResumeLayout(False)
        Me.TbEntreprise.ResumeLayout(False)
        Me.TbEntreprise.PerformLayout()
        Me.TbEvenement.ResumeLayout(False)
        Me.TbEvenement.PerformLayout()
        Me.TbFacture.ResumeLayout(False)
        Me.TbFacture.PerformLayout()
        Me.TbProduit.ResumeLayout(False)
        Me.TbProduit.PerformLayout()
        Me.TbResultat.ResumeLayout(False)
        CType(Me.dgvEntreprises, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub ChargerDonnees()
        ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            DefinitionDonnees.Instance.Fill(ds, "Entreprise", s)
            DefinitionDonnees.Instance.Fill(ds, "TelephoneEntreprise", s)
            DefinitionDonnees.Instance.Fill(ds, "Personne", s)
            DefinitionDonnees.Instance.Fill(ds, "Telephone", s)
            DefinitionDonnees.Instance.Fill(ds, "Tarif", s)
        End Using

        Databinding()
    End Sub

    Private Sub Databinding()
        Me.gcEntreprises.SetDataSource(New DataView(ds.Tables("Entreprise")))
        Me.gcParticipant.SetDataSource(New DataView(ds.Tables("Personne")))
        Me.gcEntreprises.LoadControl(Me, EventArgs.Empty)
        Me.gcParticipant.LoadControl(Me, EventArgs.Empty)
    End Sub

    Private Sub FrAssistantRequete_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.dgvEntreprises)
        Me.dgvEntreprises.AutoGenerateColumns = False
        If IO.Directory.Exists(repEtats) Then
            For Each fl As String In IO.Directory.GetFiles(repEtats)
                Me.LstModele.Items.Add(IO.Path.GetFileName(fl))
            Next
        End If

        Me.TabControl1.TabPages.Remove(Me.TbFacture)
        Me.TabControl1.TabPages.Remove(Me.TbProduit)
        Me.TabControl1.SelectedIndex = 0

        OptZoneGeographiqueNon.Checked = True
        OptDepartement.Checked = True
        OptEntrepriseNon.Checked = True
        OptParticipantNon.Checked = True
        OptFactureNon.Checked = True
        OptProduitNon.Checked = True

        Me.TbCreerEv.Visible = False
        Me.TbMail.Visible = False

        ChargerDonnees()
    End Sub


#Region " Boutons "
    Private Sub TbCLose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCLose.Click
        Me.Close()
    End Sub

    Private Sub TbExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbExport.Click
        If myDs Is Nothing Then AfficheResultat()
        Exporter()
    End Sub

    Private Sub BtPrecedent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrecedent.Click
        If Me.TabControl1.SelectedIndex > 0 Then Me.TabControl1.SelectedIndex -= 1
    End Sub

    Private Sub BtSuivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSuivant.Click
        With Me.TabControl1
            If .SelectedIndex <= .TabPages.Count - 1 Then
                .SelectedIndex += 1
                'If .SelectedIndex = .TabPages.Count - 1 Then
                '    AfficheResultat()
                '    Me.TbCreerEv.Visible = True
                'End If
            End If
        End With
    End Sub

    Private Sub BtTermine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtTermine.Click
        Me.TabControl1.SelectedTab = Me.TbResultat
    End Sub

    Private Sub BtCreerEvenement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCreerEv.Click
        Dim nbLigne As Integer
        Dim n As Integer
        If TypeOf Me.dgvEntreprises.DataSource Is DataView Then
            Dim dv As DataView = CType(Me.dgvEntreprises.DataSource, DataView)
            nbLigne = dv.Count
            If nbLigne > 0 Then
                Dim lst As New List(Of Integer)
                For n = 0 To nbLigne - 1
                    lst.Add(CInt(dv.Item(n).Item("nEntreprise")))
                Next
                Dim frEv As New FrEvenement(lst, "Entreprise", "nEntreprise")
                frEv.MdiParent = Me.MdiParent
                frEv.Show()
            End If
        End If
    End Sub

    'Private Sub BtFusion_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    With New FrLettreType(CType(Me.dgResultat.DataSource, DataView))
    '        .ShowDialog()
    '    End With
    'End Sub

    Private Sub BtCarteFrance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbCarteFrance.Click
        Dim lstDep As ArrayList
        If Me.OptDepartement.Checked Then
            lstDep = New ArrayList
            lstDep.AddRange(LstGeo.CheckedItems)
        End If

        Dim fr As FrCarteFrance
        If lstDep Is Nothing Then : fr = New FrCarteFrance
        Else : fr = New FrCarteFrance(lstDep)
        End If

        With fr
            AddHandler .Selection, AddressOf SelectDep
            .Owner = Me.FindForm
            .Show()
        End With
    End Sub

    Private Sub SelectDep(ByVal lstDep As ArrayList)
        Me.OptDepartement.Checked = True
        For Each dep As Integer In lstDep
            Me.LstGeo.SetItemChecked(dep - 1, True)
        Next
    End Sub

    Private Sub BtEnvoiMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbMail.Click
        If myDs Is Nothing Then Exit Sub
        If Not myDs.Tables.Contains("Entreprise") Then Exit Sub
        Dim mailto As New System.Text.StringBuilder()
        For Each dr As DataRow In myDs.Tables("Entreprise").Rows
            If Convert.ToString(dr("EMail")).Length > 0 Then
                mailto.AppendFormat("{0};", dr("eMail"))
            End If
        Next
        If mailto.Length > 0 Then
            mailto.Remove(mailto.Length - 1, 1)
            Process.Start("mailto:" & mailto.ToString)
        Else
            MsgBox("Aucune adresse renseignée pour ces clients", MsgBoxStyle.Information)
        End If
    End Sub

#End Region

#Region " Options "
    Private Sub OptEntrepriseOui_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptEntrepriseOui.CheckedChanged
        Me.gcEntreprises.Enabled = OptEntrepriseOui.Checked
    End Sub

    Private Sub OptParticipantOui_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptParticipantOui.CheckedChanged
        Me.gcParticipant.Enabled = OptParticipantOui.Checked
    End Sub

    Private Sub OptZoneGeographiqueOui_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptZoneGeographiqueOui.CheckedChanged
        Me.PnGeo.Enabled = OptZoneGeographiqueOui.Checked
        Me.pbCarteFrance.Enabled = OptZoneGeographiqueOui.Checked
    End Sub

    Private Sub OptFactureOui_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptFactureOui.CheckedChanged
        Me.gcFacture.Enabled = OptFactureOui.Checked
    End Sub

    Private Sub OptProduitOui_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptProduitOui.CheckedChanged
        Me.gcProduit.Enabled = OptProduitOui.Checked
    End Sub

    Private Sub OptGeo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles OptDepartement.CheckedChanged, OptCodePostal.CheckedChanged, OptVille.CheckedChanged
        Dim values As ArrayList
        If OptDepartement.Checked Then
            values = New ArrayList
            For nDep As Integer = 1 To 99
                values.Add(nDep.ToString("00"))
            Next
        ElseIf OptCodePostal.Checked Then
            values = GetDistinctValues(ds.Tables("Entreprise"), "CodePostal")
        ElseIf OptVille.Checked Then
            values = GetDistinctValues(ds.Tables("Entreprise"), "Ville")
        End If
        Me.LstGeo.Items.Clear()
        Me.LstGeo.Items.AddRange(values.ToArray)
    End Sub
#End Region

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is Me.TbResultat Then
            AfficheResultat()
        End If
    End Sub

    Private Sub dgvEntreprises_DoubleClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles dgvEntreprises.CellContentDoubleClick
        If Not Me.BindingContext(Me.dgvEntreprises.DataSource).Current Is Nothing Then
            With New FrEntreprise(CInt(CType(Me.BindingContext(Me.dgvEntreprises.DataSource).Current, DataRowView).Item("nEntreprise")))
                .TypeEntreprise = FrListeClient.TypesEntreprise.Client
                .Show()
            End With
        End If
    End Sub

#Region " Fonctionnel "
    Private Sub AfficheResultat()

        Me.Cursor = Cursors.AppStarting
        Me.Refresh()

        myDs = ds.Clone
        myDs.Tables("Entreprise").Columns("nEntreprise").Unique = True
        myDs.EnforceConstraints = False

        Me.strLibelleSelection = ""
        Dim sbLib As New System.Text.StringBuilder

        '***********************************************
        '*                  Entreprise
        '***********************************************

        If Me.OptEntrepriseOui.Checked = True Then
            Dim strSelection As String = ""
            strSelection = Me.gcEntreprises.GetCritereRecherche
            sbLib.Append(strSelection)

            For Each r As DataRow In ds.Tables("Entreprise").Select(strSelection)
                myDs.Tables("Entreprise").LoadDataRow(r.ItemArray, True)
            Next
        Else
            myDs.Merge(ds.Tables("Entreprise").Select())
        End If

        '***********************************************
        '*                  Personne
        '***********************************************
        'myDs.Merge(ds.Tables("Personne").Select())


        '*************************************************
        '*              Zone Géographique
        '*************************************************
        If OptZoneGeographiqueOui.Checked = True Then
            Dim dv As New DataView(myDs.Tables("Entreprise"))
            dv.Sort = "nEntreprise"
            Dim strCritere As New System.Text.StringBuilder

            If sbLib.Length > 0 Then sbLib.Append(" Et (")

            For Each obj As Object In Me.LstGeo.CheckedItems
                If strCritere.Length = 0 Then
                    strCritere.Append("(")
                Else
                    strCritere.Append(" Or ")
                    sbLib.Append(" Ou ")
                End If
                If OptDepartement.Checked Then
                    strCritere.AppendFormat("iif(len(CodePostal)>=2,SubString(CodePostal,1,2)='{0}',Null)", obj)
                    sbLib.AppendFormat("Dep={0}", obj)
                ElseIf OptCodePostal.Checked Then
                    strCritere.AppendFormat("CodePostal='{0}'", obj)
                    sbLib.AppendFormat("CodePostal={0}", obj)
                ElseIf OptVille.Checked Then
                    strCritere.AppendFormat("Ville='{0}'", obj)
                    sbLib.AppendFormat("Ville={0}", obj)
                End If
            Next
            If strCritere.Length > 0 Then
                strCritere.Append(")")
                sbLib.Append(")")
            End If

            dv.RowFilter = strCritere.ToString

            Dim rASuppr As New ArrayList
            For Each rw As DataRow In myDs.Tables("Entreprise").Rows
                If dv.FindRows(rw.Item("nEntreprise")).Length = 0 Then
                    rASuppr.Add(rw)
                End If
            Next

            For Each rw As DataRow In rASuppr
                Try
                    myDs.Tables("Entreprise").Rows.Remove(rw)
                Catch ex As Exception
                End Try
            Next
        End If

        '*************************************************
        '*              Participant Evenement
        '*************************************************


        If Me.OptParticipantOui.Checked = True Then

            Dim strSelection As String = Me.gcParticipant.GetCritereRecherche
            If sbLib.Length > 0 Then sbLib.Append(" Et ")
            sbLib.Append(strSelection)

            Dim listParticipant As New Hashtable
            For Each r As DataRow In ds.Tables("Evenement").Select(strSelection)
                Try
                    For Each lstRw As DataRow In r.GetChildRows("EvenementEvenementPersonne")
                        If Not listParticipant.Contains(lstRw.Item("nEntreprise")) Then
                            listParticipant.Add(lstRw.Item("nEntreprise"), lstRw.Item("nEntreprise"))
                        End If
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

            Dim rASuppr As New ArrayList
            For Each r As DataRow In myDs.Tables("Entreprise").Rows
                If Not listParticipant.Contains(r.Item("nEntreprise")) Then
                    rASuppr.Add(r)
                End If
            Next

            For Each r As DataRow In rASuppr
                Try
                    myDs.Tables("Entreprise").Rows.Remove(r)
                Catch ex As Exception
                End Try
            Next
        End If

        For Each rwTmpTel As DataRow In myDs.Tables("Entreprise").Rows
            myDs.Merge(ds.Tables("TelephoneEntreprise").Select(String.Format("nEntreprise={0}", rwTmpTel("nEntreprise"))))
        Next

        'For Each rwTmpTel As DataRow In myDs.Tables("Personne").Rows
        '    myDs.Merge(ds.Tables("Telephone").Select(String.Format("nPersonne={0}", rwTmpTel("nPersonne"))))
        'Next

        For Each r As DataRow In myDs.Tables("Entreprise").Rows
            'Remplissage des infos du Tarif
            If Not (r.IsNull("nTarif")) Then
                myDs.Merge(ds.Tables("Tarif").Select(String.Format("nTarif={0}", r.Item("nTarif"))))
            End If

            'Remplissage des infos du commercial
            If Not (r.IsNull("nCommercial")) Then
                myDs.Merge(ds.Tables("Personne").Select(String.Format("nPersonne={0}", r.Item("nCommercial"))))
            End If
        Next

        '**************************************************************
        '* Produits
        '**************************************************************
        'If Me.OptProduitOui.Checked Then
        '    Dim strSelection As String = Me.gcProduit.GetCritereRecherche
        '    If sbLib.Length > 0 Then sbLib.Append(" Et ")
        '    sbLib.Append(strSelection)
        '    myDs.Merge(ds.Tables("Produit").Select(strSelection))
        'Else
        '    myDs.Merge(ds.Tables("Produit").Select)
        'End If

        'myDs.Merge(ds.Tables("TVA").Select)
        'myDs.Merge(ds.Tables("Famille").Select)

        '**************************************************************
        '* Factures
        '**************************************************************
        'If Me.OptFactureOui.Checked = True Then
        '    Dim strSelection As String = Me.gcFacture.GetCritereRecherche
        '    If sbLib.Length > 0 Then sbLib.Append(" Et ")
        '    sbLib.Append(strSelection)

        '    myDs.Merge(ds.Tables("VFacture").Select(strSelection))

        '    For Each rwF As DataRow In myDs.Tables("VFacture").Rows
        '        'TODO Le filtrage par produit ne marche pas ici, il faudrait refaire un tour sur les lignes pour virer celles
        '        'dont le produit n'est pas présent dans le DS...
        '        'If Me.OptProduitOui.Checked Then
        '        'myDs.Merge(ds.Tables("VFacture_Detail").Select("nDevis=" & Convert.ToString(rwF.Item("nDevis")) & " And " & Me.gcProduit.GetCritereRecherche))
        '        'Else
        '        myDs.Merge(ds.Tables("VFacture_Detail").Select("nDevis=" & Convert.ToString(rwF.Item("nDevis"))))
        '        'End If
        '    Next
        'Else
        '    myDs.Merge(ds.Tables("VFacture").Select())
        '    myDs.Merge(ds.Tables("VFacture_Detail").Select)
        'End If

        Me.Cursor = Cursors.Default
        Me.Refresh()

        Me.dgvEntreprises.DataSource = New DataView(myDs.Tables("Entreprise"))
        'Me.dgFactures.DataSource = New DataView(myDs.Tables("VFacture"))
        'Me.dgProduits.DataSource = New DataView(myDs.Tables("Produit"))

        If Convert.ToString(Me.LstModele.SelectedItem) <> "" Then
            With New FrFusion(myDs, repEtats & "\" & Convert.ToString(Me.LstModele.SelectedItem))
                .LibelleSelection = sbLib.ToString
                .Show()
            End With
        Else
            MessageBox.Show("Vous devez choisir un modèle", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.strLibelleSelection = sbLib.ToString
        Me.TbCreerEv.Visible = True
        'Me.BtFusion.Visible = True
        Me.TbMail.Visible = True
    End Sub

    Private Sub Exporter()
        Dim dt As DataTable = myDs.Tables("Entreprise")
        If Not dt.Columns.Contains("NomContact") Then
            dt.Columns.Add("NomContact", GetType(String))
        End If

        'Pour chaque ligne du DS de résultat
        For Each rw As DataRow In dt.Rows
            'Construire le NomContact à partir de Nom et Prénom
            Dim rwC() As DataRow = ds.Tables("Personne").Select("nEntreprise=" & Convert.ToString(rw.Item("nEntreprise")))
            If rwC.Length > 0 Then
                Dim rwEnt As DataRow = rwC(0)
                rw.Item("NomContact") = String.Format("{0} {1}", rwEnt("Nom"), rwEnt("Prenom")).Trim
            End If
        Next

        With saveDialog
            .Filter = "Fichiers CSV (*.csv)|*.csv|Base Access (*.mdb)|*.mdb"
            .FilterIndex = 0
            .AddExtension = True
            .FileName = "export.csv"
            .Title = "Exporter les données"
            If .ShowDialog <> DialogResult.OK Then Exit Sub
        End With
        Dim fichier As String = saveDialog.FileName
        Cursor.Current = Cursors.WaitCursor
        Try
            Select Case IO.Path.GetExtension(fichier).ToUpper
                Case ".CSV"
                    ExporterCSV(dt, fichier)
                Case ".MDB"
                    ExporterAccess(dt, fichier)
            End Select
            Process.Start(fichier)
        Catch ex As Exception
            MessageBox.Show("Export impossible : " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ExporterCSV(ByVal dt As DataTable, ByVal fichier As String)
        Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
        Dim ligne(dt.Columns.Count - 1) As String
        For i As Integer = 0 To dt.Columns.Count - 1
            ligne(i) = String.Format("""{0}""", dt.Columns(i).ColumnName)
        Next
        sw.WriteLine(String.Join(";", ligne))

        ligne.Initialize()
        For Each dr As DataRow In dt.Rows
            For i As Integer = 0 To dt.Columns.Count - 1
                ligne(i) = String.Format("""{0}""", dr(i))
            Next
            sw.WriteLine(String.Join(";", ligne))
        Next
        sw.Close()
    End Sub

    Private Sub ExporterAccess(ByVal dt As DataTable, ByVal fichier As String)
        'TODO Et si la table Export n'existe pas ?
        'Se connecter à la base
        Dim cn As New OleDb.OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", fichier))
        Try
            cn.Open()

            'Créer un dta sur la table Export
            Dim dtA As New OleDb.OleDbDataAdapter("Select * From Export", cn)
            Dim cmdBuilder As New OleDb.OleDbCommandBuilder(dtA)
            dtA.InsertCommand = cmdBuilder.GetInsertCommand

            'Vider la table Export
            Dim cmdTmp As New OleDb.OleDbCommand("Delete From Export", cn)
            cmdTmp.ExecuteNonQuery()

            'Initialiser un dataset sur la table Export
            Dim dsExport As New DataSet
            dtA.Fill(dsExport)


            'Pour chaque ligne du DS de résultat
            For Each rw As DataRow In dt.Rows
                'Créer une nouvelle ligne export avec les colonnes voulues
                Dim rwN As DataRow = dsExport.Tables(0).NewRow
                For Each dc As DataColumn In dsExport.Tables(0).Columns
                    If dt.Columns.Contains(dc.ColumnName) Then
                        rwN.Item(dc) = rw.Item(dc.ColumnName)
                    End If
                Next

                'Ajouter la ligne export dans le dataset export
                dsExport.Tables(0).Rows.Add(rwN)
            Next

            'MAJ la base Access
            dtA.Update(dsExport)

        Catch ex As Exception
            Throw ex
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Sub

    Private Shared Function GetDistinctValues(ByVal dt As DataTable, ByVal col As String) As ArrayList
        If Not dt.Columns.Contains(col) Then Return Nothing
        Dim res As New ArrayList
        For Each rw As DataRowView In New DataView(dt, "", col, DataViewRowState.CurrentRows)
            If Not IsDBNull(rw.Item(col)) Then
                Dim value As Object = rw.Item(col)
                If Not res.Contains(value) Then res.Add(value)
            End If
        Next
        Return res
    End Function
#End Region

End Class

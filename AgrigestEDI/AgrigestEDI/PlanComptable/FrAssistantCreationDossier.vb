Option Strict Off
Public Class FrAssistantCreationDossier
    Inherits System.Windows.Forms.Form

    'TODO !! Initialiser la colonne D_C

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
    Friend WithEvents wizard As GNWizardFrameWork.WizardTemplate
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents wpFinish As GNWizardFrameWork.WizardPage
    Friend WithEvents txRecap As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents wpIntro As GNWizardFrameWork.WizardPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents wpProd As GNWizardFrameWork.WizardPage
    Friend WithEvents lstProd As System.Windows.Forms.ListBox
    Friend WithEvents wpStatut As GNWizardFrameWork.WizardPage
    Friend WithEvents rbIndividuel As System.Windows.Forms.RadioButton
    Friend WithEvents rbSociete As System.Windows.Forms.RadioButton
    Friend WithEvents wpActivites As GNWizardFrameWork.WizardPage
    Friend WithEvents chkLstActivites As System.Windows.Forms.CheckedListBox
    Friend WithEvents wpModeles As GNWizardFrameWork.WizardPage
    Friend WithEvents chkLstModeles As System.Windows.Forms.CheckedListBox
    Friend WithEvents LbDesc As System.Windows.Forms.Label
    Friend WithEvents wpBalance As GNWizardFrameWork.WizardPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAucun As System.Windows.Forms.RadioButton
    Friend WithEvents rbtFichier As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSaisie As System.Windows.Forms.RadioButton
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.wizard = New GNWizardFrameWork.WizardTemplate
        Me.wpFinish = New GNWizardFrameWork.WizardPage
        Me.LbDesc = New System.Windows.Forms.Label
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.txRecap = New System.Windows.Forms.TextBox
        Me.wpIntro = New GNWizardFrameWork.WizardPage
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.wpBalance = New GNWizardFrameWork.WizardPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbtAucun = New System.Windows.Forms.RadioButton
        Me.rbtFichier = New System.Windows.Forms.RadioButton
        Me.rbtSaisie = New System.Windows.Forms.RadioButton
        Me.wpProd = New GNWizardFrameWork.WizardPage
        Me.lstProd = New System.Windows.Forms.ListBox
        Me.wpActivites = New GNWizardFrameWork.WizardPage
        Me.chkLstActivites = New System.Windows.Forms.CheckedListBox
        Me.wpModeles = New GNWizardFrameWork.WizardPage
        Me.chkLstModeles = New System.Windows.Forms.CheckedListBox
        Me.wpStatut = New GNWizardFrameWork.WizardPage
        Me.rbSociete = New System.Windows.Forms.RadioButton
        Me.rbIndividuel = New System.Windows.Forms.RadioButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.wizard.SuspendLayout()
        Me.wpFinish.SuspendLayout()
        Me.wpIntro.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wpBalance.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.wpProd.SuspendLayout()
        Me.wpActivites.SuspendLayout()
        Me.wpModeles.SuspendLayout()
        Me.wpStatut.SuspendLayout()
        Me.SuspendLayout()
        '
        'wizard
        '
        Me.wizard.BannerImage = Nothing
        Me.wizard.CancelButtonText = "&Annuler"
        Me.wizard.Controls.Add(Me.wpFinish)
        Me.wizard.Controls.Add(Me.wpIntro)
        Me.wizard.Controls.Add(Me.wpBalance)
        Me.wizard.Controls.Add(Me.wpProd)
        Me.wizard.Controls.Add(Me.wpActivites)
        Me.wizard.Controls.Add(Me.wpModeles)
        Me.wizard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wizard.FinishButtonText = "&Terminer"
        Me.wizard.Location = New System.Drawing.Point(0, 0)
        Me.wizard.Name = "wizard"
        Me.wizard.NextButtonText = "&Suivant"
        Me.wizard.Pages.Add(Me.wpIntro)
        Me.wizard.Pages.Add(Me.wpBalance)
        Me.wizard.Pages.Add(Me.wpProd)
        Me.wizard.Pages.Add(Me.wpActivites)
        Me.wizard.Pages.Add(Me.wpModeles)
        Me.wizard.Pages.Add(Me.wpFinish)
        Me.wizard.PreviousButtonText = "&Précédent"
        Me.wizard.Size = New System.Drawing.Size(522, 355)
        Me.wizard.StartItemIndex = 0
        Me.wizard.TabIndex = 0
        '
        'wpFinish
        '
        Me.wpFinish.BackColor = System.Drawing.Color.White
        Me.wpFinish.Controls.Add(Me.LbDesc)
        Me.wpFinish.Controls.Add(Me.pgBar)
        Me.wpFinish.Controls.Add(Me.Label3)
        Me.wpFinish.Controls.Add(Me.txRecap)
        Me.wpFinish.HasCancelButton = True
        Me.wpFinish.HasFinishButton = True
        Me.wpFinish.HasNextButton = False
        Me.wpFinish.HasPreviousButton = True
        Me.wpFinish.HeaderCaption = "Résumé"
        Me.wpFinish.Location = New System.Drawing.Point(0, 0)
        Me.wpFinish.Name = "wpFinish"
        Me.wpFinish.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Exterior
        Me.wpFinish.Size = New System.Drawing.Size(522, 315)
        Me.wpFinish.SubHeaderCaption = "Les comptes suivants vont être créés"
        Me.wpFinish.TabIndex = 6
        Me.wpFinish.Text = "New Tab Item 3"
        '
        'LbDesc
        '
        Me.LbDesc.AutoSize = True
        Me.LbDesc.Location = New System.Drawing.Point(16, 300)
        Me.LbDesc.Name = "LbDesc"
        Me.LbDesc.Size = New System.Drawing.Size(44, 13)
        Me.LbDesc.TabIndex = 3
        Me.LbDesc.Text = "LbDesc"
        '
        'pgBar
        '
        Me.pgBar.Location = New System.Drawing.Point(16, 274)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(496, 23)
        Me.pgBar.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(292, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "En cliquant sur Terminer, les comptes suivants seront créés :"
        '
        'txRecap
        '
        Me.txRecap.Location = New System.Drawing.Point(16, 32)
        Me.txRecap.Multiline = True
        Me.txRecap.Name = "txRecap"
        Me.txRecap.ReadOnly = True
        Me.txRecap.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txRecap.Size = New System.Drawing.Size(496, 236)
        Me.txRecap.TabIndex = 0
        Me.txRecap.Text = "txRecap"
        '
        'wpIntro
        '
        Me.wpIntro.BackColor = System.Drawing.Color.White
        Me.wpIntro.Controls.Add(Me.Label6)
        Me.wpIntro.Controls.Add(Me.Label5)
        Me.wpIntro.Controls.Add(Me.PictureBox1)
        Me.wpIntro.Controls.Add(Me.Label4)
        Me.wpIntro.HasCancelButton = True
        Me.wpIntro.HasFinishButton = False
        Me.wpIntro.HasNextButton = True
        Me.wpIntro.HasPreviousButton = False
        Me.wpIntro.HeaderCaption = "Bienvenue dans l'assistant de création de dossier"
        Me.wpIntro.Location = New System.Drawing.Point(0, 0)
        Me.wpIntro.Name = "wpIntro"
        Me.wpIntro.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Exterior
        Me.wpIntro.Size = New System.Drawing.Size(522, 315)
        Me.wpIntro.SubHeaderCaption = "Panel Item"
        Me.wpIntro.TabIndex = 7
        Me.wpIntro.Text = "New Tab Item 4"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(176, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(336, 80)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Cet assistant vous aide à initialiser votre plan comptable en fonction de vos bes" & _
            "oins."
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(176, 259)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Cliquez sur suivant pour continuer."
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.AgrigestEDI.My.Resources.Logos.wizard_grand
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(168, 315)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(176, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(328, 48)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Bienvenue dans l'assistant de création de dossier."
        '
        'wpBalance
        '
        Me.wpBalance.Controls.Add(Me.GroupBox1)
        Me.wpBalance.HasCancelButton = True
        Me.wpBalance.HasFinishButton = False
        Me.wpBalance.HasNextButton = True
        Me.wpBalance.HasPreviousButton = False
        Me.wpBalance.HeaderCaption = "Implémentation de la balance"
        Me.wpBalance.Location = New System.Drawing.Point(0, 56)
        Me.wpBalance.Name = "wpBalance"
        Me.wpBalance.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpBalance.Size = New System.Drawing.Size(522, 259)
        Me.wpBalance.SubHeaderCaption = ""
        Me.wpBalance.TabIndex = 11
        Me.wpBalance.Text = "New Tab Item 1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtAucun)
        Me.GroupBox1.Controls.Add(Me.rbtFichier)
        Me.GroupBox1.Controls.Add(Me.rbtSaisie)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 259)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Type de Balance"
        '
        'rbtAucun
        '
        Me.rbtAucun.AutoSize = True
        Me.rbtAucun.Checked = True
        Me.rbtAucun.Location = New System.Drawing.Point(6, 19)
        Me.rbtAucun.Name = "rbtAucun"
        Me.rbtAucun.Size = New System.Drawing.Size(62, 17)
        Me.rbtAucun.TabIndex = 3
        Me.rbtAucun.TabStop = True
        Me.rbtAucun.Text = "Aucune"
        Me.rbtAucun.UseVisualStyleBackColor = True
        '
        'rbtFichier
        '
        Me.rbtFichier.AutoSize = True
        Me.rbtFichier.Location = New System.Drawing.Point(6, 42)
        Me.rbtFichier.Name = "rbtFichier"
        Me.rbtFichier.Size = New System.Drawing.Size(212, 17)
        Me.rbtFichier.TabIndex = 2
        Me.rbtFichier.Text = "Chargement de la balance via un fichier"
        Me.rbtFichier.UseVisualStyleBackColor = True
        '
        'rbtSaisie
        '
        Me.rbtSaisie.AutoSize = True
        Me.rbtSaisie.Location = New System.Drawing.Point(6, 65)
        Me.rbtSaisie.Name = "rbtSaisie"
        Me.rbtSaisie.Size = New System.Drawing.Size(188, 17)
        Me.rbtSaisie.TabIndex = 0
        Me.rbtSaisie.Text = "Saisie de la balance manuellement"
        Me.rbtSaisie.UseVisualStyleBackColor = True
        '
        'wpProd
        '
        Me.wpProd.Controls.Add(Me.lstProd)
        Me.wpProd.HasCancelButton = True
        Me.wpProd.HasFinishButton = False
        Me.wpProd.HasNextButton = False
        Me.wpProd.HasPreviousButton = True
        Me.wpProd.HeaderCaption = "Production"
        Me.wpProd.Location = New System.Drawing.Point(0, 56)
        Me.wpProd.Name = "wpProd"
        Me.wpProd.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpProd.Size = New System.Drawing.Size(522, 259)
        Me.wpProd.SubHeaderCaption = "Choisissez votre production dans la liste suivante."
        Me.wpProd.TabIndex = 8
        '
        'lstProd
        '
        Me.lstProd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProd.Location = New System.Drawing.Point(8, 8)
        Me.lstProd.Name = "lstProd"
        Me.lstProd.Size = New System.Drawing.Size(504, 225)
        Me.lstProd.TabIndex = 4
        '
        'wpActivites
        '
        Me.wpActivites.Controls.Add(Me.chkLstActivites)
        Me.wpActivites.HasCancelButton = True
        Me.wpActivites.HasFinishButton = False
        Me.wpActivites.HasNextButton = True
        Me.wpActivites.HasPreviousButton = True
        Me.wpActivites.HeaderCaption = "Activités"
        Me.wpActivites.Location = New System.Drawing.Point(0, 56)
        Me.wpActivites.Name = "wpActivites"
        Me.wpActivites.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpActivites.Size = New System.Drawing.Size(522, 259)
        Me.wpActivites.SubHeaderCaption = "Choisissez les activités à inclure dans le plan comptable"
        Me.wpActivites.TabIndex = 10
        '
        'chkLstActivites
        '
        Me.chkLstActivites.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkLstActivites.CheckOnClick = True
        Me.chkLstActivites.Location = New System.Drawing.Point(24, 8)
        Me.chkLstActivites.Name = "chkLstActivites"
        Me.chkLstActivites.Size = New System.Drawing.Size(336, 214)
        Me.chkLstActivites.TabIndex = 0
        '
        'wpModeles
        '
        Me.wpModeles.Controls.Add(Me.chkLstModeles)
        Me.wpModeles.HasCancelButton = True
        Me.wpModeles.HasFinishButton = False
        Me.wpModeles.HasNextButton = True
        Me.wpModeles.HasPreviousButton = True
        Me.wpModeles.HeaderCaption = "Modèles"
        Me.wpModeles.Location = New System.Drawing.Point(0, 56)
        Me.wpModeles.Name = "wpModeles"
        Me.wpModeles.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpModeles.Size = New System.Drawing.Size(522, 259)
        Me.wpModeles.SubHeaderCaption = "Choisissez les modèles à inclure dans l'exploitation"
        Me.wpModeles.TabIndex = 10
        '
        'chkLstModeles
        '
        Me.chkLstModeles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkLstModeles.CheckOnClick = True
        Me.chkLstModeles.Location = New System.Drawing.Point(24, 8)
        Me.chkLstModeles.Name = "chkLstModeles"
        Me.chkLstModeles.Size = New System.Drawing.Size(336, 214)
        Me.chkLstModeles.TabIndex = 0
        '
        'wpStatut
        '
        Me.wpStatut.Controls.Add(Me.rbSociete)
        Me.wpStatut.Controls.Add(Me.rbIndividuel)
        Me.wpStatut.HasCancelButton = True
        Me.wpStatut.HasFinishButton = False
        Me.wpStatut.HasNextButton = True
        Me.wpStatut.HasPreviousButton = True
        Me.wpStatut.HeaderCaption = "Statut"
        Me.wpStatut.Location = New System.Drawing.Point(0, 56)
        Me.wpStatut.Name = "wpStatut"
        Me.wpStatut.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpStatut.Size = New System.Drawing.Size(522, 256)
        Me.wpStatut.SubHeaderCaption = "Indiquez votre statut : individuel ou société"
        Me.wpStatut.TabIndex = 9
        Me.wpStatut.Text = "New Tab Item 1"
        '
        'rbSociete
        '
        Me.rbSociete.Location = New System.Drawing.Point(48, 40)
        Me.rbSociete.Name = "rbSociete"
        Me.rbSociete.Size = New System.Drawing.Size(104, 24)
        Me.rbSociete.TabIndex = 1
        Me.rbSociete.Text = "Société"
        '
        'rbIndividuel
        '
        Me.rbIndividuel.Checked = True
        Me.rbIndividuel.Location = New System.Drawing.Point(48, 16)
        Me.rbIndividuel.Name = "rbIndividuel"
        Me.rbIndividuel.Size = New System.Drawing.Size(104, 24)
        Me.rbIndividuel.TabIndex = 0
        Me.rbIndividuel.TabStop = True
        Me.rbIndividuel.Text = "Individuel"
        '
        'FrAssistantCreationDossier
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(522, 355)
        Me.ControlBox = False
        Me.Controls.Add(Me.wizard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrAssistantCreationDossier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Assistant création de dossier"
        Me.wizard.ResumeLayout(False)
        Me.wpFinish.ResumeLayout(False)
        Me.wpFinish.PerformLayout()
        Me.wpIntro.ResumeLayout(False)
        Me.wpIntro.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wpBalance.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.wpProd.ResumeLayout(False)
        Me.wpActivites.ResumeLayout(False)
        Me.wpModeles.ResumeLayout(False)
        Me.wpStatut.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Enum ModeAssistant
        PlanCModele
        ModeleSeul
        PlanCSeul
    End Enum

    Public Enum Pages
        Demarrage
        ModeBalance
        Productions
        Activites
        Modeles
        Recap
    End Enum

    Private dsSelect As dsPLC
    Public Mode As ModeAssistant = ModeAssistant.PlanCModele

#Region "Page"
    Private Sub FrAssistantCreationCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Cursor.Current = Cursors.WaitCursor

        dsSelect = New dsPLC
        Using dta As New dsPLCTableAdapters.ActivitesTableAdapter
            dta.FillByDossier(dsSelect.Activites, My.User.Name)
        End Using
        Using dta As New dsPLCTableAdapters.ComptesTableAdapter
            dta.FillByDossier(dsSelect.Comptes, My.User.Name)
        End Using
        Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
            dta.FillByDossier(dsSelect.PlanComptable, My.User.Name)
        End Using
        Using dta As New dsPLCTableAdapters.RicaTableAdapter
            dta.Fill(dsSelect.Rica)
        End Using
        Using dta As New dsPLCTableAdapters.PlanTypeTableAdapter
            dta.Fill(dsSelect.PlanType)
        End Using

        If Mode = ModeAssistant.ModeleSeul Then
            Me.wizard.Pages.RemoveAt(Pages.Activites)
        ElseIf Mode = ModeAssistant.PlanCSeul Then
            Me.wizard.Pages.RemoveAt(Pages.Modeles)
        End If
        Me.wizard.Pages.RemoveAt(Pages.ModeBalance)

        'Chargement des pages
        wpStatut_Load()
        wpProd_Load()
        Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region "Gestion du Wizard"
    Private Sub wizard_OnMoveNext(ByVal NextWizPanel As GNWizardFrameWork.WizardPage) Handles wizard.OnMoveNext
        If NextWizPanel Is wpActivites Then
            wpBalance_OnMoveNext()
            wpProd_OnMoveNext()
            wpActivites_Load()
        ElseIf NextWizPanel Is wpModeles Then
            wpActivites_OnMoveNext()
            wpModeles_Load()
        ElseIf NextWizPanel Is wpFinish Then
            wpModeles_OnMoveNext()
            wpFinish_Load()
        End If
    End Sub

    Private Sub wizard_CancelClick() Handles wizard.CancelClick
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub wizard_FinishClick() Handles wizard.FinishClick
        'Mise à jour du dataset original
        Cursor.Current = Cursors.WaitCursor
        LbDesc.Text = My.Resources.Strings.PLC_CreationDesComptes
        With pgBar
            .Value = 0
            .Maximum = 5
            .Visible = True
        End With
        Application.DoEvents()

        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim t As OleDb.OleDbTransaction
            Try
                conn.Open()
                t = conn.BeginTransaction
                Using dta As New dsPLCTableAdapters.ActivitesTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.Activites)
                End Using
                pgBar.Value += 1
                Using dta As New dsPLCTableAdapters.ComptesTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.Comptes)
                End Using
                pgBar.Value += 1
                Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.PlanComptable)
                End Using
                pgBar.Value += 1
                Using dta As New dsPLCTableAdapters.ModLignesTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.ModLignes)
                End Using
                pgBar.Value += 1
                Using dta As New dsPLCTableAdapters.ModMouvementsTableAdapter
                    dta.SetTransaction(t)
                    dta.Update(dsSelect.ModMouvements)
                End Using
                pgBar.Value += 1
                t.Commit()
            Catch ex As Exception
                If t IsNot Nothing Then t.Rollback()
                Throw ex
            End Try
        End Using
        Cursor.Current = Cursors.Default
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
#End Region

#Region " Page Sélection du statut "
    Private Sub wpStatut_Load()
        Me.rbIndividuel.Checked = True
    End Sub
#End Region

#Region " Page séléction de la balance "
    Private Sub wpBalance_OnMoveNext()
        If rbtFichier.Checked Then
        ElseIf rbtSaisie.Checked Then
        End If
    End Sub
#End Region

#Region " Page séléction de la production "
    Private Sub wpProd_Load()
        lstProd.BeginUpdate()
        With lstProd.Items
            .Clear()
            .Add(New ListboxItem("PRODUCTION LAITIERE ET / OU VIANDE BOVINE", "BOVIN"))
            .Add(New ListboxItem("CEREALES", "CEREALES"))
            .Add(New ListboxItem("PRODUCTION PORCINE", "PORCIN"))
            .Add(New ListboxItem("AUTRES PRODUCTIONS", "AUTRE"))
        End With
        lstProd.EndUpdate()
    End Sub

    Private Sub wpProd_OnMoveNext()
        ChargerParametrage()
    End Sub

    Private Sub lstProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstProd.SelectedIndexChanged
        wpProd.HasNextButton = (lstProd.SelectedItems.Count > 0)
    End Sub
#End Region

#Region " Page séléction des activités "
    Private Sub wpActivites_Load()
        chkLstActivites.BeginUpdate()
        With chkLstActivites.Items
            .Clear()
            .Add(New ListboxItem(String.Format("{0} - {1}", "0000", My.Resources.Strings.ACTIVITEGENERALE), "0000"), True)
            Dim curAct As String = ""
            For Each drv As DataRowView In New DataView(dsSelect.Tables("Parametrage"), "", "AActi", DataViewRowState.CurrentRows)
                If Convert.ToString(drv("AActi")) <> curAct And Convert.ToString(drv("AActi")) <> "0000" Then
                    curAct = Convert.ToString(drv("AActi"))
                    .Add(New ListboxItem(String.Format("{0} - {1}", drv("AActi"), drv("ALib")), curAct), True)
                End If
            Next

        End With
        chkLstActivites.EndUpdate()
    End Sub

    Private Sub wpActivites_OnMoveNext()

    End Sub

    Private Sub chkLstActivites_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkLstActivites.ItemCheck
        Dim li As ListboxItem = chkLstActivites.Items(e.Index)
        If (CStr(li.Value) = "0000" OrElse CStr(li.Value) = "9999") Then e.NewValue = CheckState.Checked
        wpActivites.HasNextButton = (chkLstActivites.CheckedItems.Count > 0)
    End Sub
#End Region

#Region " Page séléction des modèles "
    Private Sub wpModeles_Load()
        If lstProd.SelectedItems.Count = 0 Then Exit Sub
        Dim li As ListboxItem = lstProd.SelectedItems(0)
        'Trouver le parametrage de la production sélectionnée
        FillModele(CStr(li.Value), IIf(rbIndividuel.Checked, "I", "S"))

        chkLstModeles.BeginUpdate()
        Dim hsTable As Hashtable = New Hashtable
        With chkLstModeles.Items
            .Clear()
            For Each drv As DataRow In AgriTools.SelectDistinct(dsSelect.ModLignes, "ModLPiece").Rows
                hsTable.Add(UCase(drv("ModLPiece").ToString), drv("ModLPiece").ToString)
            Next
            For Each drv As DataRow In AgriTools.SelectDistinct(dsSelect.ModLignesPara, "ModLPiece").Rows
                If Not hsTable.ContainsKey(UCase(drv("ModLPiece").ToString)) Then
                    .Add(New ListboxItem(drv("ModLPiece").ToString), True)
                End If
            Next
        End With
        chkLstModeles.EndUpdate()

    End Sub

    Private Sub wpModeles_OnMoveNext()

    End Sub

    Private Sub EffectuerModele()
        With pgBar
            .Maximum = dsSelect.ModLignesPara.Rows.Count
            .Value = 0
            Application.DoEvents()
        End With

        'Lister les modèles à insérer
        Dim Modeles As New Collections.Specialized.StringCollection
        For Each li As ListboxItem In chkLstModeles.CheckedItems
            Modeles.Add(li.Value)
        Next

        'Créer les modèles
        For Each dr As dsPLC.ModLignesParaRow In dsSelect.ModLignesPara.Rows
            'Seulement pour les Modèles sélectionnées
            If Modeles.Contains(dr.ModLPiece) Then
                Try
                    Dim xRowLigne As dsPLC.ModLignesRow = dsSelect.ModLignes.NewModLignesRow
                    With xRowLigne
                        .ModLExpl = CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl
                        .ModLPiece = dr.ModLPiece
                        .ModLLig = dr.ModLLig
                        If Not dr.IsModLTvaNull Then .ModLTva = dr.ModLTva
                        If Not dr.IsModLLibNull Then .ModLLib = dr.ModLLib
                        If Not dr.IsModLGeneNull Then .ModLGene = dr.ModLGene
                        If Not dr.IsModLAnaNull Then .ModLAna = dr.ModLAna
                        If Not dr.IsModLJournalNull Then .ModLJournal = dr.ModLJournal
                        If Not dr.IsModLMtTVANull Then .ModLMtTVA = dr.ModLMtTVA
                    End With
                    dsSelect.ModLignes.AddModLignesRow(xRowLigne)
                Catch ex As ApplicationException
                    Debug.WriteLine(ex.Message)
                End Try
            End If
            pgBar.Value += 1
        Next
        For Each dr As dsPLC.ModMouvementsParaRow In dsSelect.ModMouvementsPara.Rows
            'Seulement pour les Modèles sélectionnées
            If Modeles.Contains(dr.ModMPiece) Then
                Try
                    Dim xRowLigne As dsPLC.ModMouvementsRow = dsSelect.ModMouvements.NewModMouvementsRow
                    With xRowLigne
                        .ModMExpl = CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl
                        .ModMPiece = dr.ModMPiece
                        .ModMLig = dr.ModMLig
                        .ModMOrdre = dr.ModMOrdre
                        If Not dr.IsModMCptNull Then .ModMCpt = dr.ModMCpt
                        If Not dr.IsModMActiNull Then .ModMActi = dr.ModMActi
                        If Not dr.IsModMMtDebNull Then .ModMMtDeb = dr.ModMMtDeb
                        If Not dr.IsModMMtCreNull Then .ModMMtCre = dr.ModMMtCre
                        If Not dr.IsModMD_CNull Then .ModMD_C = dr.ModMD_C
                        If Not dr.IsModMQte1Null Then .ModMQte1 = dr.ModMQte1
                        If Not dr.IsModMQte2Null Then .ModMQte2 = dr.ModMQte2
                        If Not dr.IsModMLettrageNull Then .ModMLettrage = dr.ModMLettrage
                        If Not dr.IsModMCptCtrNull Then .ModMCptCtr = dr.ModMCptCtr
                        If Not dr.IsModMActCtrNull Then .ModMActCtr = dr.ModMActCtr
                    End With
                    dsSelect.ModMouvements.AddModMouvementsRow(xRowLigne)
                Catch ex As ApplicationException
                    Debug.WriteLine(ex.Message)
                End Try
            End If
        Next
    End Sub

    Private Sub FillModele(ByVal CodeProd As String, ByVal Statut As String)
        'Nettoyage
        With dsSelect
            .EnforceConstraints = False
            Using dta As New dsPLCTableAdapters.ModLignesTableAdapter
                dta.FillByExpl(dsSelect.ModLignes, CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl)
            End Using
            Using dta As New dsPLCTableAdapters.ModLignesParaTableAdapter
                dta.FillByCodeProdAndStatut(dsSelect.ModLignesPara, CodeProd, Statut)
            End Using
            Using dta As New dsPLCTableAdapters.ModLignesParaTableAdapter
                dta.FillByCodeProdAndStatut(dsSelect.ModLignesPara, CodeProd, Statut)
            End Using
            Using dta As New dsPLCTableAdapters.ModMouvementsParaTableAdapter
                dta.FillByCodeProdAndStatut(dsSelect.ModMouvementsPara, CodeProd, Statut)
            End Using
            .EnforceConstraints = True
        End With
    End Sub

    Private Sub chkLstModeles_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkLstModeles.ItemCheck
        Dim li As ListboxItem = chkLstModeles.Items(e.Index)
        If CStr(li.Value) = "0000" Then e.NewValue = CheckState.Checked
        wpModeles.HasNextButton = (chkLstModeles.CheckedItems.Count > 0)
    End Sub
#End Region

#Region " Page Récap "
    Private Sub wpFinish_Load()
        Me.Cursor = Cursors.WaitCursor
        txRecap.Text = ""
        LbDesc.Text = My.Resources.Strings.RecupInfos
        pgBar.Visible = True
        EffectuerParametrage()
        EffectuerModele()
        pgBar.Value = 0
        Dim Modeles As New Collections.Specialized.StringCollection
        For Each drLigne As dsPLC.ModLignesRow In dsSelect.ModLignes.Select("", "ModLPiece", DataViewRowState.Added)
            If Not Modeles.Contains(drLigne.ModLPiece) Then Modeles.Add(drLigne.ModLPiece)
        Next
        pgBar.Maximum = dsSelect.PlanComptable.Rows.Count + Modeles.Count
        Application.DoEvents()
        Dim sb As New System.Text.StringBuilder
        For Each drC As dsPLC.PlanComptableRow In dsSelect.PlanComptable.Select("", "PlActi,PlCpt", DataViewRowState.Added)
            Dim drCpt As dsPLC.ComptesRow = drC.ComptesRowParent
            Dim drActi As dsPLC.ActivitesRow = drC.ActivitesRowParent
            sb.AppendFormat("{1} - {2} {0}", drCpt.CLib, drActi("ALib"), drCpt.CCpt)
            sb.Append(vbCrLf)
            pgBar.Value += 1 : Application.DoEvents()
        Next
        If Modeles.Count > 0 Then
            sb.AppendLine(vbCrLf & vbCrLf & "Modèles :" & vbCrLf)
            For i As Integer = 0 To Modeles.Count - 1
                sb.AppendFormat("{0}", Modeles(i))
                sb.Append(vbCrLf)
                pgBar.Value += 1 : Application.DoEvents()
            Next
        End If
        txRecap.Text = sb.ToString
        Me.Cursor = Cursors.Default
        LbDesc.Text = ""
        pgBar.Visible = False
    End Sub
#End Region

#Region " Fonctions d'ajout des comptes "
    Private Sub ChargerParametrage()
        If lstProd.SelectedItems.Count = 0 Then Exit Sub
        Dim li As ListboxItem = lstProd.SelectedItems(0)
        'Trouver le parametrage de la production sélectionnée
        FillParametrage(CStr(li.Value), IIf(rbIndividuel.Checked, "I", "S"))
    End Sub

    Private Sub EffectuerParametrage()
        With pgBar
            .Maximum = dsSelect.Parametrage.Rows.Count
            .Value = 0
            Application.DoEvents()
        End With

        'Défaire ce qui a eventuellement été fait
        dsSelect.RejectChanges()

        'Lister les activités à insérer
        Dim activites As New Collections.Specialized.StringCollection
        For Each li As ListboxItem In chkLstActivites.CheckedItems
            activites.Add(li.Value)
        Next

        'Créer les comptes
        For Each dr As dsPLC.ParametrageRow In dsSelect.Parametrage.Rows
            'Seulement pour les activités sélectionnées
            If activites.Contains(dr.AActi) Then
                Try
                    AjouterCompteActivite(dr.CCpt, Convert.ToString(dr("CLib")), Convert.ToString(dr("CU1")), Convert.ToString(dr("CU2")), Convert.ToString(dr("C_DC")), dr.AActi, Convert.ToString(dr("ALib")), Convert.ToString(dr("AUnit")))
                Catch ex As ApplicationException
                    Debug.WriteLine(ex.Message)
                End Try
            End If
            pgBar.Value += 1
        Next
    End Sub

    Private Sub FillParametrage(ByVal CodeProd As String, ByVal Statut As String)
        'Nettoyage
        With dsSelect
            .EnforceConstraints = False
            Using dta As New dsPLCTableAdapters.ParametrageTableAdapter
                dta.FillByCodeProdAndStatut(dsSelect.Parametrage, CodeProd, Statut)
            End Using
            .EnforceConstraints = True
        End With
    End Sub

    Private Sub AjouterCompte(ByVal ccpt As String, ByVal clib As String, ByVal cu1 As String, ByVal cu2 As String, ByVal dc As String)
        AjouterCompteActivite(ccpt, clib, cu1, cu2, dc, "0000", My.Resources.Strings.ACTIVITEGENERALE, "")
    End Sub

    Private Sub AjouterCompteActivite(ByVal ccpt As String, ByVal clib As String, ByVal cu1 As String, ByVal cu2 As String, ByVal dc As String, ByVal aacti As String, ByVal alib As String, ByVal aunit As String)
        AjouterCompteActivite(dsSelect, ccpt, clib, cu1, cu2, dc, aacti, alib, aunit)
    End Sub

    Private Sub AjouterCompteActivite(ByVal myDs As dsPLC, ByVal ccpt As String, ByVal clib As String, ByVal cu1 As String, ByVal cu2 As String, ByVal dc As String, ByVal aacti As String, ByVal alib As String, ByVal aunit As String)
        'Vérifs à faire: 
        '- L'activité existe
        If aacti = "0000" Then alib = My.Resources.Strings.ACTIVITEGENERALE
        VerifActivite(myDs, aacti, alib, aunit)

        '- Le compte n'est pas dans le plan comptable
        If PLCExiste(myDs, ccpt, aacti) Then
            'si le compte existe vérifie que les champs du libéllé sont alimentés sinon met celui plus plan type et répercute
            Dim drPlACpt() As dsPLC.PlanTypeRow = myDs.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", ccpt))
            If drPlACpt IsNot Nothing AndAlso drPlACpt.Length > 0 Then
                Dim drCpt As dsPLC.ComptesRow = myDs.Comptes.FindByCDossierCCpt(My.User.Name, ccpt)
                If drCpt.IsCLibNull OrElse drCpt.CLib = "" Then
                    drCpt.CLib = Convert.ToString(drPlACpt(0).Item("PlLib"))
                    drCpt.C_DC = Convert.ToString(drPlACpt(0).Item("PlD_C"))
                End If
                Dim drPCCpt() As dsPLC.PlanComptableRow = myDs.PlanComptable.Select(String.Format("PlDossier='{0}' and PlCpt='{1}'", My.User.Name, ccpt))
                For Each xRow As dsPLC.PlanComptableRow In drPCCpt
                    Dim drAct As dsPLC.ActivitesRow = myDs.Activites.FindByADossierAActi(My.User.Name, Convert.ToString(xRow.Item("PlActi")))
                    xRow.PlLib = Convert.ToString(drPlACpt(0).Item("PlLib")) + " - " + Convert.ToString(drAct.Item("ALib"))
                Next
            End If
            Throw New ApplicationException(String.Format(My.Resources.Strings.PLC_CoupleExiste, ccpt, aacti))
        Else
            'AJOUT DANS LA TABLE COMPTES
            '- Le compte n'existe pas déjà => il faut alors juste l'ajouter au PLC
            If Not CompteExiste(myDs, ccpt) Then
                '- Le compte est acceptable au niveau racine comptable
                If Not VerifRacineComptable(myDs, ccpt) Then Throw New ApplicationException(String.Format(My.Resources.Strings.PLC_PasDansPlanType, ccpt))

                With myDs.Comptes
                    Dim drCpt As dsPLC.ComptesRow = .NewComptesRow
                    With drCpt
                        .CDossier = My.User.Name
                        .CCpt = ccpt
                        .CLib = Microsoft.VisualBasic.Left(clib, 30)
                        If cu1.Length > 0 Then .CU1 = cu1
                        If cu2.Length > 0 Then .CU2 = cu2
                        If dc.Length > 0 Then .C_DC = dc
                    End With
                    .Rows.Add(drCpt)
                End With
            Else
                'si le compte existe vérifie que les champs du libéllé sont alimentés sinon met celui plus plan type et répercute
                Dim drPlACpt() As dsPLC.PlanTypeRow = myDs.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", ccpt))
                If drPlACpt IsNot Nothing AndAlso drPlACpt.Length > 0 Then
                    Dim drCpt As dsPLC.ComptesRow = myDs.Comptes.FindByCDossierCCpt(My.User.Name, ccpt)
                    If drCpt.IsCLibNull OrElse drCpt.CLib = "" Then
                        drCpt.CLib = Convert.ToString(drPlACpt(0).Item("PlLib"))
                        drCpt.C_DC = Convert.ToString(drPlACpt(0).Item("PlD_C"))
                    End If
                    Dim drPCCpt() As dsPLC.PlanComptableRow = myDs.PlanComptable.Select(String.Format("PlDossier='{0}' and PlCpt='{1}'", My.User.Name, ccpt))
                    For Each xRow As dsPLC.PlanComptableRow In drPCCpt
                        Dim drAct As dsPLC.ActivitesRow = myDs.Activites.FindByADossierAActi(My.User.Name, Convert.ToString(xRow.Item("PlActi")))
                        xRow.PlLib = Convert.ToString(drPlACpt(0).Item("PlLib")) + " - " + Convert.ToString(drAct.Item("ALib"))
                    Next
                End If
            End If
            'AJOUT DANS LE PLAN COMPTABLE AVEC L'ACTIVITE PAR DEFAUT
            myDs.PlanComptable.AddPlanComptableRow(My.User.Name, ccpt, aacti, Microsoft.VisualBasic.Left(clib + " - " + alib, 55), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", 0, "", "")
        End If

    End Sub

    Private Sub VerifActivite(ByVal myDs As dsPLC, ByVal aacti As String, ByVal alib As String, ByVal aunit As String)
        With myDs.Activites
            If .FindByADossierAActi(My.User.Name, aacti) Is Nothing Then
                Dim dr As dsPLC.ActivitesRow = .NewActivitesRow
                With dr
                    .ADossier = My.User.Name
                    .AActi = aacti
                    If alib.Length > 0 Then .ALib = alib
                    .AQte = 0
                    If aunit.Length > 0 Then .AUnit = aunit
                End With
                .Rows.Add(dr)
            End If
        End With
    End Sub

    Private Shared Function CompteExiste(ByVal myDs As dsPLC, ByVal ccpt As String) As Boolean
        Return myDs.Comptes.FindByCDossierCCpt(My.User.Name, ccpt) IsNot Nothing
    End Function

    Private Shared Function PLCExiste(ByVal myDs As dsPLC, ByVal ccpt As String, ByVal aacti As String) As Boolean
        Return myDs.PlanComptable.FindByPlDossierPlCptPlActi(My.User.Name, ccpt, aacti) IsNot Nothing
    End Function

    Private Function VerifRacineComptable(ByVal myDs As dsPLC, ByVal ccpt As String) As Boolean
        Return myDs.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", ccpt)).Length > 0
    End Function
#End Region

End Class

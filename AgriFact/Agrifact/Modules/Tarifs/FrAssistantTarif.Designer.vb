<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrAssistantTarif
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrAssistantTarif))
        Me.wt = New GNWizardFrameWork.WizardTemplate
        Me.wpStart = New GNWizardFrameWork.WizardPage
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.wpNom = New GNWizardFrameWork.WizardPage
        Me.OptAucun = New System.Windows.Forms.RadioButton
        Me.OptDupliquer = New System.Windows.Forms.RadioButton
        Me.OptAppliquerCoef = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxTarif = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.wpDupliquerTarif = New GNWizardFrameWork.WizardPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbDupliTarifExistant = New System.Windows.Forms.RadioButton
        Me.rbDupliPrixStandard = New System.Windows.Forms.RadioButton
        Me.CbTarifDupliquer = New System.Windows.Forms.ComboBox
        Me.wpAppliquerCoef = New GNWizardFrameWork.WizardPage
        Me.Label7 = New System.Windows.Forms.Label
        Me.nudCoef = New System.Windows.Forms.NumericUpDown
        Me.GbChoixTarifCoef = New System.Windows.Forms.GroupBox
        Me.rbCoefTarifExistant = New System.Windows.Forms.RadioButton
        Me.CbTarifCoef = New System.Windows.Forms.ComboBox
        Me.rbCoefPrixStandard = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.wt.SuspendLayout()
        Me.wpStart.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.wpNom.SuspendLayout()
        Me.wpDupliquerTarif.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.wpAppliquerCoef.SuspendLayout()
        CType(Me.nudCoef, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbChoixTarifCoef.SuspendLayout()
        Me.SuspendLayout()
        '
        'wt
        '
        Me.wt.BannerImage = Nothing
        Me.wt.CancelButtonText = "&Annuler"
        Me.wt.Controls.Add(Me.wpStart)
        Me.wt.Controls.Add(Me.wpNom)
        Me.wt.Controls.Add(Me.wpDupliquerTarif)
        Me.wt.Controls.Add(Me.wpAppliquerCoef)
        Me.wt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wt.FinishButtonText = "&Terminer"
        Me.wt.Location = New System.Drawing.Point(0, 0)
        Me.wt.Name = "wt"
        Me.wt.NextButtonText = "&Suivant"
        Me.wt.Pages.Add(Me.wpStart)
        Me.wt.Pages.Add(Me.wpNom)
        Me.wt.Pages.Add(Me.wpDupliquerTarif)
        Me.wt.Pages.Add(Me.wpAppliquerCoef)
        Me.wt.PreviousButtonText = "&Précédent"
        Me.wt.Size = New System.Drawing.Size(491, 352)
        Me.wt.StartItemIndex = 0
        Me.wt.TabIndex = 0
        '
        'wpStart
        '
        Me.wpStart.BackColor = System.Drawing.Color.White
        Me.wpStart.Controls.Add(Me.Label10)
        Me.wpStart.Controls.Add(Me.Label1)
        Me.wpStart.Controls.Add(Me.Label2)
        Me.wpStart.Controls.Add(Me.PictureBox1)
        Me.wpStart.HasCancelButton = True
        Me.wpStart.HasFinishButton = False
        Me.wpStart.HasNextButton = True
        Me.wpStart.HasPreviousButton = False
        Me.wpStart.HeaderCaption = "Wizard Item"
        Me.wpStart.Location = New System.Drawing.Point(0, 0)
        Me.wpStart.Name = "wpStart"
        Me.wpStart.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Exterior
        Me.wpStart.Size = New System.Drawing.Size(491, 312)
        Me.wpStart.SubHeaderCaption = "Panel Item"
        Me.wpStart.TabIndex = 4
        Me.wpStart.Text = "New Tab Item 1"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(178, 157)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(301, 35)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Cet Assistant vous guide tout au long des étapes de création du Tarif"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(178, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(301, 37)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "L'assistant création de tarif vous permet de céer de nouveau tarifs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(176, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(303, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Assistant Création de Tarifs"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 312)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'wpNom
        '
        Me.wpNom.Controls.Add(Me.OptAucun)
        Me.wpNom.Controls.Add(Me.OptDupliquer)
        Me.wpNom.Controls.Add(Me.OptAppliquerCoef)
        Me.wpNom.Controls.Add(Me.Label5)
        Me.wpNom.Controls.Add(Me.TxTarif)
        Me.wpNom.Controls.Add(Me.Label4)
        Me.wpNom.HasCancelButton = True
        Me.wpNom.HasFinishButton = False
        Me.wpNom.HasNextButton = True
        Me.wpNom.HasPreviousButton = True
        Me.wpNom.HeaderCaption = "Informations générales"
        Me.wpNom.Location = New System.Drawing.Point(0, 56)
        Me.wpNom.Name = "wpNom"
        Me.wpNom.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpNom.Size = New System.Drawing.Size(491, 256)
        Me.wpNom.SubHeaderCaption = "Choisissez le nom et le mode de calcul du tarif"
        Me.wpNom.TabIndex = 5
        Me.wpNom.Text = "New Tab Item 2"
        '
        'OptAucun
        '
        Me.OptAucun.Location = New System.Drawing.Point(183, 127)
        Me.OptAucun.Name = "OptAucun"
        Me.OptAucun.Size = New System.Drawing.Size(216, 24)
        Me.OptAucun.TabIndex = 11
        Me.OptAucun.Text = "Aucun (Tarif vide)"
        '
        'OptDupliquer
        '
        Me.OptDupliquer.Location = New System.Drawing.Point(183, 103)
        Me.OptDupliquer.Name = "OptDupliquer"
        Me.OptDupliquer.Size = New System.Drawing.Size(216, 24)
        Me.OptDupliquer.TabIndex = 10
        Me.OptDupliquer.Text = "Dupliquer un Tarif existant"
        '
        'OptAppliquerCoef
        '
        Me.OptAppliquerCoef.Location = New System.Drawing.Point(183, 79)
        Me.OptAppliquerCoef.Name = "OptAppliquerCoef"
        Me.OptAppliquerCoef.Size = New System.Drawing.Size(232, 24)
        Me.OptAppliquerCoef.TabIndex = 9
        Me.OptAppliquerCoef.Text = "Appliquer un coefficient à un tarif existant"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(79, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Mode de Calcul"
        '
        'TxTarif
        '
        Me.TxTarif.Location = New System.Drawing.Point(183, 47)
        Me.TxTarif.Name = "TxTarif"
        Me.TxTarif.Size = New System.Drawing.Size(224, 20)
        Me.TxTarif.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(79, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Nom du Tarif"
        '
        'wpDupliquerTarif
        '
        Me.wpDupliquerTarif.Controls.Add(Me.GroupBox1)
        Me.wpDupliquerTarif.HasCancelButton = True
        Me.wpDupliquerTarif.HasFinishButton = True
        Me.wpDupliquerTarif.HasNextButton = False
        Me.wpDupliquerTarif.HasPreviousButton = True
        Me.wpDupliquerTarif.HeaderCaption = "Dupliquer un tarif existant"
        Me.wpDupliquerTarif.Location = New System.Drawing.Point(0, 56)
        Me.wpDupliquerTarif.Name = "wpDupliquerTarif"
        Me.wpDupliquerTarif.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpDupliquerTarif.Size = New System.Drawing.Size(491, 256)
        Me.wpDupliquerTarif.SubHeaderCaption = "Choisissez le tarif à dupliquer"
        Me.wpDupliquerTarif.TabIndex = 6
        Me.wpDupliquerTarif.Text = "New Tab Item 3"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDupliTarifExistant)
        Me.GroupBox1.Controls.Add(Me.rbDupliPrixStandard)
        Me.GroupBox1.Controls.Add(Me.CbTarifDupliquer)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(79, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 80)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Créer le tarif en dupliquant"
        '
        'rbDupliTarifExistant
        '
        Me.rbDupliTarifExistant.Location = New System.Drawing.Point(8, 48)
        Me.rbDupliTarifExistant.Name = "rbDupliTarifExistant"
        Me.rbDupliTarifExistant.Size = New System.Drawing.Size(64, 24)
        Me.rbDupliTarifExistant.TabIndex = 11
        Me.rbDupliTarifExistant.Text = "le tarif"
        '
        'rbDupliPrixStandard
        '
        Me.rbDupliPrixStandard.Location = New System.Drawing.Point(8, 16)
        Me.rbDupliPrixStandard.Name = "rbDupliPrixStandard"
        Me.rbDupliPrixStandard.Size = New System.Drawing.Size(200, 24)
        Me.rbDupliPrixStandard.TabIndex = 9
        Me.rbDupliPrixStandard.Text = "les prix standards"
        '
        'CbTarifDupliquer
        '
        Me.CbTarifDupliquer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTarifDupliquer.Location = New System.Drawing.Point(72, 48)
        Me.CbTarifDupliquer.Name = "CbTarifDupliquer"
        Me.CbTarifDupliquer.Size = New System.Drawing.Size(248, 21)
        Me.CbTarifDupliquer.TabIndex = 6
        '
        'wpAppliquerCoef
        '
        Me.wpAppliquerCoef.Controls.Add(Me.Label7)
        Me.wpAppliquerCoef.Controls.Add(Me.nudCoef)
        Me.wpAppliquerCoef.Controls.Add(Me.GbChoixTarifCoef)
        Me.wpAppliquerCoef.Controls.Add(Me.Label8)
        Me.wpAppliquerCoef.HasCancelButton = True
        Me.wpAppliquerCoef.HasFinishButton = True
        Me.wpAppliquerCoef.HasNextButton = False
        Me.wpAppliquerCoef.HasPreviousButton = True
        Me.wpAppliquerCoef.HeaderCaption = "Appliquer un coefficient à un tarif existant"
        Me.wpAppliquerCoef.Location = New System.Drawing.Point(0, 56)
        Me.wpAppliquerCoef.Name = "wpAppliquerCoef"
        Me.wpAppliquerCoef.PageStyle = GNWizardFrameWork.PageStyle.eWPS_Interior
        Me.wpAppliquerCoef.Size = New System.Drawing.Size(491, 256)
        Me.wpAppliquerCoef.SubHeaderCaption = "Choisissez le tarif de base ainsi que le coefficient à appliqer"
        Me.wpAppliquerCoef.TabIndex = 7
        Me.wpAppliquerCoef.Text = "New Tab Item 4"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(219, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "%"
        '
        'nudCoef
        '
        Me.nudCoef.DecimalPlaces = 2
        Me.nudCoef.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.nudCoef.Location = New System.Drawing.Point(151, 147)
        Me.nudCoef.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudCoef.Name = "nudCoef"
        Me.nudCoef.Size = New System.Drawing.Size(64, 20)
        Me.nudCoef.TabIndex = 15
        Me.nudCoef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudCoef.Value = New Decimal(New Integer() {1995, 0, 0, 65536})
        '
        'GbChoixTarifCoef
        '
        Me.GbChoixTarifCoef.Controls.Add(Me.rbCoefTarifExistant)
        Me.GbChoixTarifCoef.Controls.Add(Me.CbTarifCoef)
        Me.GbChoixTarifCoef.Controls.Add(Me.rbCoefPrixStandard)
        Me.GbChoixTarifCoef.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GbChoixTarifCoef.Location = New System.Drawing.Point(79, 49)
        Me.GbChoixTarifCoef.Name = "GbChoixTarifCoef"
        Me.GbChoixTarifCoef.Size = New System.Drawing.Size(328, 80)
        Me.GbChoixTarifCoef.TabIndex = 14
        Me.GbChoixTarifCoef.TabStop = False
        Me.GbChoixTarifCoef.Text = "Appliquer le coefficient"
        '
        'rbCoefTarifExistant
        '
        Me.rbCoefTarifExistant.Location = New System.Drawing.Point(8, 48)
        Me.rbCoefTarifExistant.Name = "rbCoefTarifExistant"
        Me.rbCoefTarifExistant.Size = New System.Drawing.Size(64, 24)
        Me.rbCoefTarifExistant.TabIndex = 11
        Me.rbCoefTarifExistant.Text = "au tarif"
        '
        'CbTarifCoef
        '
        Me.CbTarifCoef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbTarifCoef.Location = New System.Drawing.Point(72, 48)
        Me.CbTarifCoef.Name = "CbTarifCoef"
        Me.CbTarifCoef.Size = New System.Drawing.Size(248, 21)
        Me.CbTarifCoef.TabIndex = 6
        '
        'rbCoefPrixStandard
        '
        Me.rbCoefPrixStandard.Location = New System.Drawing.Point(8, 16)
        Me.rbCoefPrixStandard.Name = "rbCoefPrixStandard"
        Me.rbCoefPrixStandard.Size = New System.Drawing.Size(200, 24)
        Me.rbCoefPrixStandard.TabIndex = 9
        Me.rbCoefPrixStandard.Text = "aux prix standards"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(87, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Coefficient"
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(0, 105)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(73, 283)
        Me.Panel3.TabIndex = 22
        '
        'FrAssistantTarif
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 352)
        Me.ControlBox = False
        Me.Controls.Add(Me.wt)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrAssistantTarif"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assistant Tarif"
        Me.wt.ResumeLayout(False)
        Me.wpStart.ResumeLayout(False)
        Me.wpStart.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.wpNom.ResumeLayout(False)
        Me.wpNom.PerformLayout()
        Me.wpDupliquerTarif.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.wpAppliquerCoef.ResumeLayout(False)
        Me.wpAppliquerCoef.PerformLayout()
        CType(Me.nudCoef, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbChoixTarifCoef.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wt As GNWizardFrameWork.WizardTemplate
    Friend WithEvents wpStart As GNWizardFrameWork.WizardPage
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents wpNom As GNWizardFrameWork.WizardPage
    Friend WithEvents OptAucun As System.Windows.Forms.RadioButton
    Friend WithEvents OptDupliquer As System.Windows.Forms.RadioButton
    Friend WithEvents OptAppliquerCoef As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxTarif As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents wpDupliquerTarif As GNWizardFrameWork.WizardPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDupliTarifExistant As System.Windows.Forms.RadioButton
    Friend WithEvents rbDupliPrixStandard As System.Windows.Forms.RadioButton
    Friend WithEvents CbTarifDupliquer As System.Windows.Forms.ComboBox
    Friend WithEvents wpAppliquerCoef As GNWizardFrameWork.WizardPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudCoef As System.Windows.Forms.NumericUpDown
    Friend WithEvents GbChoixTarifCoef As System.Windows.Forms.GroupBox
    Friend WithEvents rbCoefTarifExistant As System.Windows.Forms.RadioButton
    Friend WithEvents CbTarifCoef As System.Windows.Forms.ComboBox
    Friend WithEvents rbCoefPrixStandard As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class

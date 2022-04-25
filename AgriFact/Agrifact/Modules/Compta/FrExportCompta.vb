Public Class FrExportCompta
    Inherits GRC.FrBase

    Private frp As FrProgressBar

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GbVentes As System.Windows.Forms.GroupBox
    Friend WithEvents CkVFacture As System.Windows.Forms.CheckBox
    Friend WithEvents dtVFactureDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtVFactureFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtVReglementFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CkVReglement As System.Windows.Forms.CheckBox
    Friend WithEvents dtVReglementDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents GbAchats As System.Windows.Forms.GroupBox
    Friend WithEvents dtAReglementFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CkAReglement As System.Windows.Forms.CheckBox
    Friend WithEvents dtAReglementDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtAFactureFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CkAFacture As System.Windows.Forms.CheckBox
    Friend WithEvents dtAFactureDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtAnnuler As Actigram.Windows.Forms.BoutonImage
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents BtOk As Actigram.Windows.Forms.BoutonImage
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrExportCompta))
        Me.GbVentes = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtVReglementFin = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.CkVReglement = New System.Windows.Forms.CheckBox
        Me.dtVReglementDebut = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtVFactureFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.CkVFacture = New System.Windows.Forms.CheckBox
        Me.dtVFactureDebut = New System.Windows.Forms.DateTimePicker
        Me.GbAchats = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtAReglementFin = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.CkAReglement = New System.Windows.Forms.CheckBox
        Me.dtAReglementDebut = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtAFactureFin = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.CkAFacture = New System.Windows.Forms.CheckBox
        Me.dtAFactureDebut = New System.Windows.Forms.DateTimePicker
        Me.BtAnnuler = New Actigram.Windows.Forms.BoutonImage
        Me.BtOk = New Actigram.Windows.Forms.BoutonImage
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GbVentes.SuspendLayout()
        Me.GbAchats.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
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
        'GbVentes
        '
        Me.GbVentes.Controls.Add(Me.Label3)
        Me.GbVentes.Controls.Add(Me.dtVReglementFin)
        Me.GbVentes.Controls.Add(Me.Label4)
        Me.GbVentes.Controls.Add(Me.CkVReglement)
        Me.GbVentes.Controls.Add(Me.dtVReglementDebut)
        Me.GbVentes.Controls.Add(Me.Label2)
        Me.GbVentes.Controls.Add(Me.dtVFactureFin)
        Me.GbVentes.Controls.Add(Me.Label1)
        Me.GbVentes.Controls.Add(Me.CkVFacture)
        Me.GbVentes.Controls.Add(Me.dtVFactureDebut)
        Me.GbVentes.Location = New System.Drawing.Point(8, 8)
        Me.GbVentes.Name = "GbVentes"
        Me.GbVentes.Size = New System.Drawing.Size(346, 76)
        Me.GbVentes.TabIndex = 0
        Me.GbVentes.TabStop = False
        Me.GbVentes.Text = "Ventes"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(224, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Au"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtVReglementFin
        '
        Me.dtVReglementFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtVReglementFin.Location = New System.Drawing.Point(248, 40)
        Me.dtVReglementFin.Name = "dtVReglementFin"
        Me.dtVReglementFin.Size = New System.Drawing.Size(88, 20)
        Me.dtVReglementFin.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(104, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Du"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CkVReglement
        '
        Me.CkVReglement.Checked = True
        Me.CkVReglement.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkVReglement.Location = New System.Drawing.Point(8, 40)
        Me.CkVReglement.Name = "CkVReglement"
        Me.CkVReglement.Size = New System.Drawing.Size(104, 24)
        Me.CkVReglement.TabIndex = 5
        Me.CkVReglement.Text = "Règlements"
        '
        'dtVReglementDebut
        '
        Me.dtVReglementDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtVReglementDebut.Location = New System.Drawing.Point(136, 40)
        Me.dtVReglementDebut.Name = "dtVReglementDebut"
        Me.dtVReglementDebut.Size = New System.Drawing.Size(88, 20)
        Me.dtVReglementDebut.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(224, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Au"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtVFactureFin
        '
        Me.dtVFactureFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtVFactureFin.Location = New System.Drawing.Point(248, 17)
        Me.dtVFactureFin.Name = "dtVFactureFin"
        Me.dtVFactureFin.Size = New System.Drawing.Size(88, 20)
        Me.dtVFactureFin.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(104, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Du"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CkVFacture
        '
        Me.CkVFacture.Checked = True
        Me.CkVFacture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkVFacture.Location = New System.Drawing.Point(8, 15)
        Me.CkVFacture.Name = "CkVFacture"
        Me.CkVFacture.Size = New System.Drawing.Size(72, 24)
        Me.CkVFacture.TabIndex = 0
        Me.CkVFacture.Text = "Factures"
        '
        'dtVFactureDebut
        '
        Me.dtVFactureDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtVFactureDebut.Location = New System.Drawing.Point(136, 17)
        Me.dtVFactureDebut.Name = "dtVFactureDebut"
        Me.dtVFactureDebut.Size = New System.Drawing.Size(88, 20)
        Me.dtVFactureDebut.TabIndex = 2
        '
        'GbAchats
        '
        Me.GbAchats.Controls.Add(Me.Label5)
        Me.GbAchats.Controls.Add(Me.dtAReglementFin)
        Me.GbAchats.Controls.Add(Me.Label6)
        Me.GbAchats.Controls.Add(Me.CkAReglement)
        Me.GbAchats.Controls.Add(Me.dtAReglementDebut)
        Me.GbAchats.Controls.Add(Me.Label7)
        Me.GbAchats.Controls.Add(Me.dtAFactureFin)
        Me.GbAchats.Controls.Add(Me.Label8)
        Me.GbAchats.Controls.Add(Me.CkAFacture)
        Me.GbAchats.Controls.Add(Me.dtAFactureDebut)
        Me.GbAchats.Location = New System.Drawing.Point(8, 90)
        Me.GbAchats.Name = "GbAchats"
        Me.GbAchats.Size = New System.Drawing.Size(346, 72)
        Me.GbAchats.TabIndex = 1
        Me.GbAchats.TabStop = False
        Me.GbAchats.Text = "Achats"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(224, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Au"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtAReglementFin
        '
        Me.dtAReglementFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtAReglementFin.Location = New System.Drawing.Point(248, 42)
        Me.dtAReglementFin.Name = "dtAReglementFin"
        Me.dtAReglementFin.Size = New System.Drawing.Size(88, 20)
        Me.dtAReglementFin.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(104, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 23)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Du"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CkAReglement
        '
        Me.CkAReglement.Checked = True
        Me.CkAReglement.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkAReglement.Location = New System.Drawing.Point(8, 40)
        Me.CkAReglement.Name = "CkAReglement"
        Me.CkAReglement.Size = New System.Drawing.Size(104, 24)
        Me.CkAReglement.TabIndex = 5
        Me.CkAReglement.Text = "Règlements"
        '
        'dtAReglementDebut
        '
        Me.dtAReglementDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtAReglementDebut.Location = New System.Drawing.Point(136, 42)
        Me.dtAReglementDebut.Name = "dtAReglementDebut"
        Me.dtAReglementDebut.Size = New System.Drawing.Size(88, 20)
        Me.dtAReglementDebut.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(224, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 23)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Au"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtAFactureFin
        '
        Me.dtAFactureFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtAFactureFin.Location = New System.Drawing.Point(248, 16)
        Me.dtAFactureFin.Name = "dtAFactureFin"
        Me.dtAFactureFin.Size = New System.Drawing.Size(88, 20)
        Me.dtAFactureFin.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(104, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 23)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Du"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CkAFacture
        '
        Me.CkAFacture.Checked = True
        Me.CkAFacture.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkAFacture.Location = New System.Drawing.Point(8, 16)
        Me.CkAFacture.Name = "CkAFacture"
        Me.CkAFacture.Size = New System.Drawing.Size(80, 24)
        Me.CkAFacture.TabIndex = 0
        Me.CkAFacture.Text = "Factures"
        '
        'dtAFactureDebut
        '
        Me.dtAFactureDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtAFactureDebut.Location = New System.Drawing.Point(136, 16)
        Me.dtAFactureDebut.Name = "dtAFactureDebut"
        Me.dtAFactureDebut.Size = New System.Drawing.Size(88, 20)
        Me.dtAFactureDebut.TabIndex = 2
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.BtAnnuler.CausesValidation = False
        Me.BtAnnuler.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtAnnuler.ForeColor = System.Drawing.Color.White
        Me.BtAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtAnnuler.Location = New System.Drawing.Point(290, 9)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(64, 24)
        Me.BtAnnuler.TabIndex = 1
        Me.BtAnnuler.Text = "Annuler"
        Me.BtAnnuler.UseVisualStyleBackColor = False
        '
        'BtOk
        '
        Me.BtOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.BtOk.CausesValidation = False
        Me.BtOk.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtOk.ForeColor = System.Drawing.Color.White
        Me.BtOk.Location = New System.Drawing.Point(204, 9)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(80, 24)
        Me.BtOk.TabIndex = 0
        Me.BtOk.Text = "Exporter"
        Me.BtOk.UseVisualStyleBackColor = False
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtOk)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 173)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(362, 45)
        Me.GradientPanel2.TabIndex = 1
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.GbVentes)
        Me.GradientPanel1.Controls.Add(Me.GbAchats)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(362, 173)
        Me.GradientPanel1.TabIndex = 0
        '
        'FrExportCompta
        '
        Me.AcceptButton = Me.BtOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(362, 218)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrExportCompta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Compta"
        Me.GbVentes.ResumeLayout(False)
        Me.GbAchats.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Boutons"
    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        If FrApplication.Parametres.VersionDemo = True Then
            MsgBox("L'export vers la compta n'est pas disponible en version de démonstration", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        Dim type As Compta.ModesExport = Compta.ModeExport

        If (type = Compta.ModesExport.Agrigest2 Or type = Compta.ModesExport.AgrigestEDI) And Compta.ModeCompta = Compta.ModesCompta.Deconnecte Then
            MsgBox("Aucune version d'Agrigest n'est disponible.", MsgBoxStyle.Exclamation, "Erreur")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        frp = New FrProgressBar
        With frp
            '.TopMost = True
            .Maximum = 100
            .Value = 0
        End With

        Dim export As ExportCompta.ExportComptaBase

        Select Case type
            Case Compta.ModesExport.Agrigest2 : export = New ExportCompta.Agrigest.ExportAgrigest
            Case Compta.ModesExport.AgrigestEDI : export = New ExportCompta.Agrigest.ExportAgrigestEDI
            Case Compta.ModesExport.Isacompta : export = New ExportCompta.Isagri.ExportIsagri
            Case Compta.ModesExport.ISTEA : export = New ExportCompta.ISTEA.ExportISTEA
            Case Compta.ModesExport.Epicea : export = New ExportCompta.Epicea.ExportEpicea
            Case Compta.ModesExport.Infovia : Throw New NotImplementedException
            Case Compta.ModesExport.Pomo : export = New ExportCompta.Pomo.ExportPomo
        End Select

        Try
            With export
                AddHandler .ExportProgressed, AddressOf ExportProgressed
                'Parametrage de l'export
                'Options
                .TVASurEncaissement = Compta.TVAEncaissement
                .AReglement = Me.CkAReglement.Checked
                .AFacture = Me.CkAFacture.Checked
                .VFacture = Me.CkVFacture.Checked
                .VReglement = Me.CkVReglement.Checked
                'Fourchettes
                .BlocnPieceDebutAFacture = Compta.BlocNPieceDebutAFacture
                .BlocnPieceDebutVFacture = Compta.BlocNPieceDebutVFacture
                .BlocnPieceFinAFacture = Compta.BlocNPieceFinAFacture
                .BlocnPieceFinVFacture = Compta.BlocNPieceFinVFacture
                .BlocnPieceDebutAReglement = Compta.BlocNPieceDebutAReglement
                .BlocnPieceDebutVReglement = Compta.BlocNPieceDebutVReglement
                .BlocnPieceFinAReglement = Compta.BlocNPieceFinAReglement
                .BlocnPieceFinVReglement = Compta.BlocNPieceFinVReglement
                'Dates
                .DateDebAFacture = Me.dtAFactureDebut.Value
                .DateFinAFacture = Me.dtAFactureFin.Value
                .DateDebAReglement = Me.dtAReglementDebut.Value
                .DateFinAReglement = Me.dtAReglementFin.Value
                .DateDebVFacture = Me.dtVFactureDebut.Value
                .DateFinVFacture = Me.dtVFactureFin.Value
                .DateDebVReglement = Me.dtVReglementDebut.Value
                .DateFinVReglement = Me.dtVReglementFin.Value

                .RgpCptsPdtsExportVtes = Compta.RgpCptsPdtsExportVtes
                .ChkFourchVFact = Compta.ChkFourchVFact
                .VFactureNumFactureAgrifact = Compta.VFactureNumFactureAgrifact
                .VFactureComposerNumPiece = Compta.VFactureComposerNumPiece
                .VFactureRacineNumPiece = Compta.VFactureRacineNumPiece

                If TypeOf export Is ExportCompta.ExportComptaFichierBase Then
                    Dim fr As New SaveFileDialog
                    With fr
                        .AddExtension = True
                        .Filter = CType(export, ExportCompta.ExportComptaFichierBase).Filter & "Tous les fichiers|*.*"
                        .FilterIndex = 0
                        .AddExtension = True
                        .OverwritePrompt = True
                        .Title = "Indiquez l'emplacement du fichier d'export"
                        .FileName = CType(export, ExportCompta.ExportComptaFichierBase).DefaultFileName(Compta.NDossierCompta)
                        If .ShowDialog <> DialogResult.OK Then Exit Sub
                        CType(export, ExportCompta.ExportComptaFichierBase).fichier = .FileName
                    End With
                    fr.Dispose()
                End If

                frp.Show()
                Application.DoEvents()

                If TypeOf export Is ExportCompta.Agrigest.ExportAgrigest Then 'Marche aussi pour AgrigestEDI qui est une sousclasse
                    CType(export, ExportCompta.Agrigest.ExportAgrigest).ChargerDonnees(My.Settings.AgrifactConnString, Compta.CheminBaseAgrigest, Compta.CheminBasePlanTypeAgrigest, Compta.NDossierCompta.Substring(0, 6))
                Else
                    .nDossierCompta = Microsoft.VisualBasic.Left(Compta.NDossierCompta, 6)
                    .NomDossier = ""
                    .ChargerDonnees(My.Settings.AgrifactConnString)
                End If

                Dim res As Boolean = .EnvoiCompta()
                frp.Hide()
                If Not res Then
                    LogMessage(.RapportExport.ToString)
                    GRC.FrTextMessageBox.Show(.RapportExport.ToString, "Rapport d'erreur", "L'exportation en comptabilité a échoué.")
                Else
                    If .RapportExport.Length > 0 Then
                        LogMessage(.RapportExport.ToString)
                        GRC.FrTextMessageBox.Show(.RapportExport.ToString, "Rapport d'exportation", "L'exportation en comptabilité a été réalisée avec des avertissements.")
                    Else
                        Dim message As String = String.Empty

                        message = "L'exportation en comptabilité a été réalisée avec succès."

                        If (export.GetNbFacturesExportees() > 0) Then
                            message = message & Microsoft.VisualBasic.vbCrLf & " Nombre de factures exportées : " & CStr(export.GetNbFacturesExportees()) & "."
                        End If

                        If (export.GetNbRemisesExportees() > 0) Then
                            message = message & Microsoft.VisualBasic.vbCrLf & " Nombre de remises exportées : " & CStr(export.GetNbRemisesExportees()) & "."
                        End If

                        MsgBox(message, MsgBoxStyle.Information, "Information")

                        'MsgBox("L'exportation en comptabilité a été réalisée avec succès.", MsgBoxStyle.Information, "Information")
                    End If
                End If
                Me.Close()
            End With
        Catch ex As Exception
            LogException(ex)
            Debug.WriteLine(ex.ToString)

            Dim msg As String = ex.Message

            If Not ex.InnerException Is Nothing Then
                msg &= vbCrLf & ex.InnerException.Message
            End If

            MessageBox.Show("Erreur lors de l'exportation: " & vbCrLf & msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            export.Close()
            frp.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub
#End Region

#Region "CheckBox"
    Private Sub CkVFacture_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkVFacture.CheckedChanged
        Dim ck As CheckBox = CType(sender, CheckBox)
        Me.dtVFactureDebut.Enabled = ck.Checked
        Me.dtVFactureFin.Enabled = ck.Checked
    End Sub

    Private Sub CkVReglement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkVReglement.CheckedChanged
        Dim ck As CheckBox = CType(sender, CheckBox)
        Me.dtVReglementDebut.Enabled = ck.Checked
        Me.dtVReglementFin.Enabled = ck.Checked
    End Sub

    Private Sub CkAFacture_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkAFacture.CheckedChanged
        Dim ck As CheckBox = CType(sender, CheckBox)
        Me.dtAFactureDebut.Enabled = ck.Checked
        Me.dtAFactureFin.Enabled = ck.Checked
    End Sub

    Private Sub CkAReglement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkAReglement.CheckedChanged
        Dim ck As CheckBox = CType(sender, CheckBox)
        Me.dtAReglementDebut.Enabled = ck.Checked
        Me.dtAReglementFin.Enabled = ck.Checked
    End Sub
#End Region

#Region "Form"
    Private Sub FrExportAgrigest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        If Not FrApplication.Modules.ModuleAchat Then
            Me.GbAchats.Visible = False
            Me.ClientSize = New Size(Me.ClientSize.Width, Me.GbVentes.Bottom + Me.GradientPanel2.Height + 10)
        End If

        Dim dtDebExport As Date = Compta.DebutExCompta 'Date de début de l'exercice par défaut
        'Dim dtFinExport As Date = New Date(Now.Year, Now.Month, 1).AddDays(-1) 'Fin du mois dernier par défaut
        Dim dtFinExport As Date = Compta.FinExCompta

        Me.dtVFactureDebut.Value = dtDebExport
        Me.dtVReglementDebut.Value = dtDebExport
        Me.dtAFactureDebut.Value = dtDebExport
        Me.dtAReglementDebut.Value = dtDebExport

        Me.dtVFactureFin.Value = dtFinExport
        Me.dtVReglementFin.Value = dtFinExport
        Me.dtAFactureFin.Value = dtFinExport
        Me.dtAReglementFin.Value = dtFinExport
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ExportProgressed(ByVal sender As Object, ByVal e As ExportCompta.ProgressEventArgs)
        frp.UpdateProgress(e.Percent, e.Status)
    End Sub
#End Region

End Class

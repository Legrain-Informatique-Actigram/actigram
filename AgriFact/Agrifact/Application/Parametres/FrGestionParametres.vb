Public Class FrGestionParametres
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents lvDossiers As System.Windows.Forms.ListView
    Friend WithEvents colDossier As System.Windows.Forms.ColumnHeader
    Friend WithEvents ilLv As System.Windows.Forms.ImageList
    Friend WithEvents btCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Premier Dossier", "graou", "grrr"}, 0)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Deuxieme dossier", 0)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrGestionParametres))
        Me.btOK = New System.Windows.Forms.Button
        Me.btCancel = New System.Windows.Forms.Button
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.lvDossiers = New System.Windows.Forms.ListView
        Me.colDossier = New System.Windows.Forms.ColumnHeader
        Me.ilLv = New System.Windows.Forms.ImageList(Me.components)
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btOK
        '
        Me.btOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btOK.Location = New System.Drawing.Point(207, 10)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(75, 23)
        Me.btOK.TabIndex = 1
        Me.btOK.Text = "OK"
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(288, 10)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 3
        Me.btCancel.Text = "Annuler"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.btCancel)
        Me.GradientPanel2.Controls.Add(Me.btOK)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 181)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(375, 45)
        Me.GradientPanel2.TabIndex = 18
        '
        'lvDossiers
        '
        Me.lvDossiers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDossier})
        Me.lvDossiers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDossiers.FullRowSelect = True
        Me.lvDossiers.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3, ListViewItem4})
        Me.lvDossiers.Location = New System.Drawing.Point(0, 0)
        Me.lvDossiers.MultiSelect = False
        Me.lvDossiers.Name = "lvDossiers"
        Me.lvDossiers.Size = New System.Drawing.Size(375, 181)
        Me.lvDossiers.SmallImageList = Me.ilLv
        Me.lvDossiers.TabIndex = 4
        Me.lvDossiers.UseCompatibleStateImageBehavior = False
        Me.lvDossiers.View = System.Windows.Forms.View.Details
        '
        'colDossier
        '
        Me.colDossier.Text = "Dossier"
        Me.colDossier.Width = 350
        '
        'ilLv
        '
        Me.ilLv.ImageStream = CType(resources.GetObject("ilLv.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilLv.TransparentColor = System.Drawing.Color.Magenta
        Me.ilLv.Images.SetKeyName(0, "VSFolder_open.bmp")
        '
        'FrGestionParametres
        '
        Me.AcceptButton = Me.btOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(375, 226)
        Me.ControlBox = False
        Me.Controls.Add(Me.lvDossiers)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrGestionParametres"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choix du dossier"
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public datasource As DataTable
    Public result As Integer = -1
    Private sortOrder As SortOrder = Windows.Forms.SortOrder.None
    Private dv As DataView

#Region "Page"
    Private Sub FrGestionParametres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ChargerDonnees()
        Me.lvDossiers.Select()
    End Sub
#End Region

#Region "ListView dossiers"
    Private Sub lvDossiers_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDossiers.ItemActivate
        If lvDossiers.SelectedIndices.Count > 0 Then
            btOK.PerformClick()
        End If
    End Sub

    Private Sub lvDossiers_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDossiers.ColumnClick
        If e.Column = 0 Then
            Select Case sortOrder
                Case Windows.Forms.SortOrder.None
                    sortOrder = Windows.Forms.SortOrder.Ascending
                Case Windows.Forms.SortOrder.Ascending
                    sortOrder = Windows.Forms.SortOrder.Descending
                Case Windows.Forms.SortOrder.Descending
                    sortOrder = Windows.Forms.SortOrder.None
            End Select
            ChargerDonnees()
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub btOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        Dim drv As DataRowView = Me.dv(Me.lvDossiers.SelectedIndices(0))
        result = Me.datasource.Rows.IndexOf(drv.Row)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        dv = New DataView(datasource)
        Dim sort As String = ""
        If Me.sortOrder <> Windows.Forms.SortOrder.None Then
            sort = "NomDossier"
            If Me.sortOrder = Windows.Forms.SortOrder.Descending Then sort &= " DESC"
        End If
        dv.Sort = sort
        With lvDossiers
            .BeginUpdate()
            .Items.Clear()
            For Each drv As DataRowView In dv
                .Items.Add(Convert.ToString(drv("NomDossier")), 0)
            Next
            .Items(0).Selected = True
            .EndUpdate()
        End With
    End Sub
#End Region

End Class

Public Class ParametresApplication

    Public NomDossier As String = "Agrifact"
    Public ObjectifMarge As Decimal = 50
    Public CodeBarreGroupe As Boolean = True
    Public ModeCalculCoefRestoBio As Boolean = False
    Public ImpressionSQLServer As Boolean = False

    Public VersionDemo As Boolean = True
    Private DemoLimitePieces As Integer = 40
    Private DemoLimiteClients As Integer = 50

    Public CheminVNC As String = "C:\Program Files\Actigram\UltraVNC"
    Public AdresseVNC As String = "193.251.24.103:5500"
    Public AdresseVNCID As String = "1"

    Public AdresseSite As String
    Public ServiceGestionSite As String

    Public ServerSmtp As String

    Public NPortModem As Short = 3
    Public StandardModem As String = ""

    Public LastLogin As String
    Public VerifautoMAJ As Boolean = False
    Public RepEtatsSpecifiques As String = ""

    Private Shared dsParamLocaux As DataSet
    Private Shared ligneParametre As Integer
    Private Const FICHIER_PARAMETRE As String = "Parametres.xml"
    Private Const CHEMIN_ACTIGRAM_AGRIFACT As String = "Actigram\AgriFact\"

#Region "Propriétés"
    Public Shared ReadOnly Property CheminFichierParam() As String
        Get
            Dim chemin As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIER_PARAMETRE)

            If IO.File.Exists(chemin) Then
                Return chemin
            Else
                Dim ancienChemin As String = IO.Path.Combine(Application.StartupPath, FICHIER_PARAMETRE)

                If IO.File.Exists(ancienChemin) Then
                    LogMessage("Déplacement du Parametres.xml au nouvel emplacement")

                    'création du répertoire Actigram dans le répertoire ApplicationData si nécessaire
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(chemin))

                    IO.File.Move(ancienChemin, chemin)

                    Return ancienChemin
                End If
            End If

            Return String.Empty
        End Get
    End Property
#End Region

#Region "Méthodes partagées"
    Public Shared Function ChargerParametres(Optional ByVal defaultDossier As String = Nothing, Optional ByVal startposition As FormStartPosition = FormStartPosition.CenterParent) As DialogResult
        Dim chemin As String = CheminFichierParam()

        If IO.File.Exists(chemin) Then
            dsParamLocaux = New DataSet
            dsParamLocaux.ReadXml(chemin)
            If dsParamLocaux.Tables.Contains("Parametres") Then
                With dsParamLocaux.Tables("Parametres")
                    Select Case .Rows.Count
                        Case 0
                            'Impossible normalement, de toute façon ca buggerait parce qu'on n'aurait pas les bonnes colonnes
                            .Rows.Add(.NewRow)
                            ligneParametre = 0
                            Return DialogResult.OK
                        Case 1
                            ligneParametre = 0
                            Return DialogResult.OK
                        Case Else
                            If Not defaultDossier Is Nothing AndAlso defaultDossier.Length > 0 Then
                                For i As Integer = 0 To .Rows.Count - 1
                                    If String.Compare(GetNomDossier(.Rows(i)), defaultDossier, True) = 0 Then
                                        ligneParametre = i
                                        Return DialogResult.OK
                                    End If
                                Next
                            End If

                            Dim fr As New FrGestionParametres
                            With fr
                                .StartPosition = startposition
                                .datasource = dsParamLocaux.Tables("Parametres")
                                If .ShowDialog() = DialogResult.OK Then
                                    ligneParametre = .result
                                    Return DialogResult.OK
                                Else
                                    Return DialogResult.Cancel
                                End If
                            End With
                    End Select
                End With
            Else
                Throw New Exception("Le fichier Parametres.xml est endommagé")
            End If
        Else
            Throw New Exception("Le fichier Parametres.xml est introuvable")
        End If
    End Function

    Private Shared Function GetNomDossier(ByVal dr As DataRow) As String
        If dr.Table.Columns.Contains("NomDossier") AndAlso Not IsDBNull(dr("NomDossier")) Then
            Return CStr(dr("NomDossier"))
        Else
            Return String.Format("Base '{0}' sur '{1}'", dr("BASESQL"), dr("ServeurSQL"))
        End If
    End Function

    Public Shared Function ValeurParametre(ByVal nomParametre As String, Optional ByVal valeurDefaut As Object = Nothing, Optional ByVal ReplaceEmpty As Boolean = False) As Object
        Dim result As Object
        If dsParamLocaux.Tables("Parametres").Columns.Contains(nomParametre) _
        AndAlso Not IsDBNull(dsParamLocaux.Tables("Parametres").Rows(ligneParametre).Item(nomParametre)) Then
            result = dsParamLocaux.Tables("Parametres").Rows(ligneParametre).Item(nomParametre)
            If ReplaceEmpty AndAlso Convert.ToString(result) = "" Then
                result = valeurDefaut
            End If
        Else
            result = valeurDefaut
        End If
        Return result
    End Function

    Public Shared Sub EnregistrerParametre(ByVal nomParametre As String, ByVal valeurParametre As Object, Optional ByVal SauverFichier As Boolean = True)
        With dsParamLocaux.Tables("Parametres").Columns
            If Not .Contains(nomParametre) Then
                If IsDBNull(valeurParametre) Then : .Add(nomParametre, GetType(Object))
                Else : .Add(nomParametre, valeurParametre.GetType)
                End If
            End If
        End With

        dsParamLocaux.Tables("Parametres").Rows(ligneParametre).Item(nomParametre) = valeurParametre
        If SauverFichier Then EnregistrerParametres()
    End Sub

    Public Shared Sub EnregistrerParametres()
        dsParamLocaux.WriteXml(CheminFichierParam)
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Sub Charger()
        With Me
            .NomDossier = CStr(ValeurParametre("NomDossier", .NomDossier))
            .LastLogin = CStr(ValeurParametre("LastLogin", .LastLogin))
            .RepEtatsSpecifiques = CStr(ValeurParametre("RepEtatsSpecifiques", ""))
            .VerifautoMAJ = CBool(ParametresApplication.ValeurParametre("VerifAutoMAJ", True))

            .ObjectifMarge = CDec(ValeurParametre("ObjectifMarge", 0))
            .CodeBarreGroupe = CBool(ValeurParametre("CodeBarreGroupe", False))
            .ImpressionSQLServer = CBool(ValeurParametre("ImpressionSQLServer", False))
            .ModeCalculCoefRestoBio = CBool(ValeurParametre("ModeCalculCoefRestoBio", False))

            .NPortModem = CShort(ValeurParametre("NPortModem", Me.NPortModem))
            .StandardModem = CStr(ValeurParametre("StandardModem", Me.StandardModem))
            .AdresseVNC = CStr(ValeurParametre("AdresseVNC", Me.AdresseVNC))
            .AdresseVNCID = CStr(ValeurParametre("AdresseVNCID", Me.AdresseVNCID))
            .CheminVNC = CStr(ValeurParametre("CheminVNC", Me.CheminVNC))

            .ServiceGestionSite = CStr(ValeurParametre("ServiceGestionSite", ""))
            .AdresseSite = CStr(ValeurParametre("AdresseSite", ""))
            .ServerSmtp = CStr(ValeurParametre("ServerSMTP", ""))
        End With
    End Sub

    Public Sub Enregistrer(Optional ByVal saveFile As Boolean = True)
        With Me
            'EnregistrerParametre("EnTete", EnTeteFacture, False)
            'EnregistrerParametre("EnTeteDetail", EnTeteDetail, False)
            'EnregistrerParametre("PiedPageDetail", PiedPageDetail, False)
            'EnregistrerParametre("InfoLegale", InfoLegale, False)
            'EnregistrerParametre("InfoLegale2", InfoLegale2, False)
            'EnregistrerParametre("EMail", .EMail, False)
            'EnregistrerParametre("NFax", .NFax, False)
            'EnregistrerParametre("NTel", .NTel, False)

            'EnregistrerParametre("CodeEtablissement", CodeEtablissement, False)
            'EnregistrerParametre("NCompte", NCompte, False)
            'EnregistrerParametre("CleRIB", CleRIB, False)
            'EnregistrerParametre("Domiciliation", Domiciliation, False)

            EnregistrerParametre("NomDossier", NomDossier, False)
            EnregistrerParametre("LastLogin", LastLogin, False)
            EnregistrerParametre("RepEtatsSpecifiques", RepEtatsSpecifiques, False)
            EnregistrerParametre("VerifAutoMAJ", VerifautoMAJ, False)

            EnregistrerParametre("NPortModem", .NPortModem, False)
            EnregistrerParametre("StandardModem", .StandardModem, False)

            EnregistrerParametre("ServiceGestionSite", .ServiceGestionSite, False)
            EnregistrerParametre("AdresseSite", .AdresseSite, False)
            EnregistrerParametre("ServerSMTP", .ServerSmtp, False)
        End With
        If saveFile Then ParametresApplication.EnregistrerParametres()
    End Sub

    Public Function TesterLimiteDemoClient() As Boolean
        Dim cntEnt As Integer
        Using s As New SqlProxy
            cntEnt = s.ExecuteScalarInt("SELECT COUNT(*) AS NB FROM [Entreprise]")
        End Using
        Return TesterLimiteDemoClient(cntEnt)
    End Function

    Public Function TesterLimiteDemoClient(ByVal cntClient As Integer) As Boolean
        Return TesterLimiteDemo(cntClient, DemoLimiteClients, "Partenaires")
    End Function

    Public Function TesterLimiteDemoPieces(ByVal cntPieces As Integer) As Boolean
        Return TesterLimiteDemo(cntPieces, DemoLimitePieces, "pièces")
    End Function

    Public Function TesterLimiteDemoPieces(ByVal type As String) As Boolean
        Dim cntPieces As Integer
        Using s As New SqlProxy
            cntPieces = s.ExecuteScalarInt(String.Format("SELECT COUNT(*) AS NB FROM [{0}]", type))
        End Using
        Return TesterLimiteDemoPieces(cntPieces)
    End Function

    Private Function TesterLimiteDemo(ByVal cnt As Integer, ByVal limite As Integer, ByVal desc As String) As Boolean
        If VersionDemo Then
            If cnt >= limite Then
                MessageBox.Show(String.Format("Vous ne pouvez pas créer plus de {0} {1} en version d'évaluation", limite, desc), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If
        Return True
    End Function
#End Region

End Class

Public Class ValeurDefaultApplication
    Public ClientFacturationTTC As Boolean = True
    Public ClientNCompte As String = "41100000"
    Public ClientNActivite As String = "0000"
    Public ClientNCompteAuto As Boolean = False

    Public FournisseurFacturationTTC As Boolean = True
    Public FournisseurNCompte As String = "40100000"
    Public FournisseurNActivite As String = "0000"
    Public FournisseurNCompteAuto As Boolean = False

    Public ProduitVente As Boolean = True
    Public ProduitNCompteA As String = "60100000"
    Public ProduitNActiviteA As String = "0000"
    Public ProduitNCompteAAuto As Boolean = False
    Public ProduitNCompteV As String = "70100000"
    Public ProduitNActiviteV As String = "0000"
    Public ProduitNCompteVAuto As Boolean = False
    Public ProduitAchat As Boolean = True
    Public ProduitTypeFacturation As String = "U1"
    Public ProduitTxTVAVente As String = "5.5"
    Public ProduitGestionStock As Boolean = True
    Public ProduitDecompteStockAuto As Boolean = False

    Public FacturationClient1 As Integer = 1
    Public FacturationFournisseur1 As Integer = 1

    Public EcartReglement As Decimal = 5
    Public nBanqueEntreprise As Object = DBNull.Value

#Region "Méthodes diverses"
    Public Sub Charger()
        Me.ClientFacturationTTC = CBool(ParametresApplication.ValeurParametre("ClientFacturationTTC", Me.ClientFacturationTTC))
        Me.ClientNActivite = CStr(ParametresApplication.ValeurParametre("ClientNActivite", Me.ClientNActivite))
        Me.ClientNCompte = CStr(ParametresApplication.ValeurParametre("ClientNCompte", Me.ClientNCompte))
        Me.ClientNCompteAuto = CBool(ParametresApplication.ValeurParametre("ClientNCompteAuto", Me.ClientNCompteAuto))

        Me.FacturationClient1 = CInt(ParametresApplication.ValeurParametre("FacturationClient1", Me.FacturationClient1))
        Me.FacturationFournisseur1 = CInt(ParametresApplication.ValeurParametre("FacturationFournisseur1", Me.FacturationFournisseur1))

        Me.FournisseurFacturationTTC = CBool(ParametresApplication.ValeurParametre("FournisseurFacturationTTC", Me.FournisseurFacturationTTC))
        Me.FournisseurNActivite = CStr(ParametresApplication.ValeurParametre("FournisseurNActivite", Me.FournisseurNActivite))
        Me.FournisseurNCompte = CStr(ParametresApplication.ValeurParametre("FournisseurNCompte", Me.FournisseurNCompte))
        Me.FournisseurNCompteAuto = CBool(ParametresApplication.ValeurParametre("FournisseurNCompteAuto", Me.FournisseurNCompteAuto))

        Me.ProduitAchat = CBool(ParametresApplication.ValeurParametre("ProduitAchat", Me.ProduitAchat))
        Me.ProduitDecompteStockAuto = CBool(ParametresApplication.ValeurParametre("ProduitDecompteStockAuto", Me.ProduitDecompteStockAuto))
        Me.ProduitGestionStock = CBool(ParametresApplication.ValeurParametre("ProduitGestionStock", Me.ProduitGestionStock))
        Me.ProduitNActiviteA = CStr(ParametresApplication.ValeurParametre("ProduitNActiviteA", Me.ProduitNActiviteA))
        Me.ProduitNActiviteV = CStr(ParametresApplication.ValeurParametre("ProduitNActiviteV", Me.ProduitNActiviteV))
        Me.ProduitNCompteA = CStr(ParametresApplication.ValeurParametre("ProduitNCompteA", Me.ProduitNCompteA))
        Me.ProduitNCompteAAuto = CBool(ParametresApplication.ValeurParametre("ProduitNCompteAAuto", Me.ProduitNCompteAAuto))
        Me.ProduitNCompteV = CStr(ParametresApplication.ValeurParametre("ProduitNCompteV", Me.ProduitNCompteV))
        Me.ProduitNCompteVAuto = CBool(ParametresApplication.ValeurParametre("ProduitNCompteVAuto", Me.ProduitNCompteVAuto))
        Me.ProduitTxTVAVente = CStr(ParametresApplication.ValeurParametre("ProduitTxTVAVente", Me.ProduitTxTVAVente))
        Me.ProduitTypeFacturation = CStr(ParametresApplication.ValeurParametre("ProduitTypeFacturation", Me.ProduitTypeFacturation))
        Me.ProduitVente = CBool(ParametresApplication.ValeurParametre("ProduitVente", Me.ProduitVente))

        Me.nBanqueEntreprise = ParametresApplication.ValeurParametre("nBanqueEntreprise", Me.nBanqueEntreprise)
        Me.EcartReglement = CDec(ParametresApplication.ValeurParametre("EcartReglement", Me.EcartReglement))
    End Sub

    Public Sub Enregistrer(Optional ByVal saveFile As Boolean = True)
        ParametresApplication.EnregistrerParametre("ClientFacturationTTC", Me.ClientFacturationTTC, False)
        ParametresApplication.EnregistrerParametre("ClientNActivite", Me.ClientNActivite, False)
        ParametresApplication.EnregistrerParametre("ClientNCompte", Me.ClientNCompte, False)
        ParametresApplication.EnregistrerParametre("ClientNCompteAuto", Me.ClientNCompteAuto, False)
        ParametresApplication.EnregistrerParametre("FacturationClient1", Me.FacturationClient1, False)
        ParametresApplication.EnregistrerParametre("FacturationFournisseur1", Me.FacturationFournisseur1, False)
        ParametresApplication.EnregistrerParametre("FournisseurFacturationTTC", Me.FournisseurFacturationTTC, False)
        ParametresApplication.EnregistrerParametre("FournisseurNActivite", Me.FournisseurNActivite, False)
        ParametresApplication.EnregistrerParametre("FournisseurNCompte", Me.FournisseurNCompte, False)
        ParametresApplication.EnregistrerParametre("FournisseurNCompteAuto", Me.FournisseurNCompteAuto, False)

        ParametresApplication.EnregistrerParametre("ProduitAchat", Me.ProduitAchat, False)
        ParametresApplication.EnregistrerParametre("ProduitDecompteStockAuto", Me.ProduitDecompteStockAuto, False)
        ParametresApplication.EnregistrerParametre("ProduitGestionStock", Me.ProduitGestionStock, False)
        ParametresApplication.EnregistrerParametre("ProduitNActiviteA", Me.ProduitNActiviteA, False)
        ParametresApplication.EnregistrerParametre("ProduitNActiviteV", Me.ProduitNActiviteV, False)
        ParametresApplication.EnregistrerParametre("ProduitNCompteA", Me.ProduitNCompteA, False)
        ParametresApplication.EnregistrerParametre("ProduitNCompteAAuto", Me.ProduitNCompteAAuto, False)
        ParametresApplication.EnregistrerParametre("ProduitNCompteV", Me.ProduitNCompteV, False)
        ParametresApplication.EnregistrerParametre("ProduitNCompteVAuto", Me.ProduitNCompteVAuto, False)
        ParametresApplication.EnregistrerParametre("ProduitTxTVAVente", Me.ProduitTxTVAVente, False)
        ParametresApplication.EnregistrerParametre("ProduitTypeFacturation", Me.ProduitTypeFacturation, False)
        ParametresApplication.EnregistrerParametre("ProduitVente", Me.ProduitVente, False)

        ParametresApplication.EnregistrerParametre("nBanqueEntreprise", Me.nBanqueEntreprise, False)
        ParametresApplication.EnregistrerParametre("EcartReglement", Me.EcartReglement, False)

        If saveFile Then ParametresApplication.EnregistrerParametres()
    End Sub
#End Region

End Class

Public Class ParametresBase
    Private Const MAX_LOGO_WIDTH As Integer = 140
    Private Const MAX_LOGO_HEIGHT As Integer = 150
    Private Const BUFFER_SIZE As Integer = 84054 '= 140px * 150px * 4 bytes + header 54 bytes (on enregistre en 32bit BMP)

#Region "Méthodes partagées"
    Public Shared Function GetValeur(ByVal dsParams As DataSet, ByVal nomParam As String, ByVal nomTable As String, ByVal valeurDefaut As String) As String
        If dsParams.Tables.Contains("Parametres") Then
            Return GetValeur(dsParams.Tables("Parametres"), nomParam, nomTable, valeurDefaut)
        Else
            Return valeurDefaut
        End If
    End Function

    Public Shared Function GetValeur(ByVal dtParams As DataTable, ByVal nomParam As String, ByVal nomTable As String, ByVal valeurDefaut As String) As String
        Dim res As String = valeurDefaut
        If Not dtParams Is Nothing Then
            Dim rws() As DataRow = dtParams.Select(String.Format("Cle='{0}' And (TypePiece is null Or TypePiece='{1}')", nomParam, nomTable), "TypePiece desc")
            If rws.Length > 0 Then
                res = Convert.ToString(rws(0).Item("Valeur"))
            End If
        End If
        Return res
    End Function

    Public Shared Sub SetValeur(ByVal dsParams As DataSet, ByVal nomParam As String, ByVal nomTable As String, ByVal valeur As String)
        If dsParams.Tables.Contains("Parametres") Then
            SetValeur(dsParams.Tables("Parametres"), nomParam, nomTable, valeur)
        End If
    End Sub

    Public Shared Sub SetValeur(ByVal dtParams As DataTable, ByVal nomParam As String, ByVal nomTable As String, ByVal valeur As String)
        If Not dtParams Is Nothing Then
            Dim testType As String = CStr(IIf(nomTable Is Nothing, "is null", String.Format("='{0}'", nomTable)))
            Dim rws() As DataRow = dtParams.Select(String.Format("Cle='{0}' And TypePiece {1}", nomParam, testType))
            If rws.Length > 0 Then
                rws(0).Item("Valeur") = valeur
            Else
                Dim rw As DataRow = dtParams.NewRow
                With rw
                    .Item("Cle") = nomParam
                    .Item("TypePiece") = IIf(nomTable Is Nothing, DBNull.Value, nomTable)
                    .Item("Valeur") = valeur
                End With
                dtParams.Rows.Add(rw)
            End If
        End If
    End Sub

    Public Shared Sub DeleteValeur(ByVal dsParams As DataSet, ByVal nomParam As String, ByVal nomTable As String)
        If dsParams.Tables.Contains("Parametres") Then
            DeleteValeur(dsParams.Tables("Parametres"), nomParam, nomTable)
        End If
    End Sub

    Public Shared Sub DeleteValeur(ByVal dtParams As DataTable, ByVal nomParam As String, ByVal nomTable As String)
        If Not dtParams Is Nothing Then
            Dim testType As String = CStr(IIf(nomTable Is Nothing, "is null", String.Format("='{0}'", nomTable)))
            Dim rws() As DataRow = dtParams.Select(String.Format("Cle='{0}' And TypePiece {1}", nomParam, testType))
            If rws.Length > 0 Then
                rws(0).Delete()
            End If
        End If
    End Sub

    Public Shared Function SetLogo(ByVal dtParams As DataTable, ByVal cheminImage As String) As Image
        With dtParams
            If IO.File.Exists(cheminImage) Then
                Dim im As Image = GetImageReduite(cheminImage)
                SetLogo(dtParams, GetImageBytes(im, Imaging.ImageFormat.Bmp))
                Return im
            Else
                SetLogo(dtParams, CType(Nothing, Byte()))
                Return Nothing
            End If
        End With
    End Function

    Public Shared Sub SetLogo(ByVal dtParams As DataTable, ByVal bytes() As Byte)
        With dtParams
            If .Rows.Count = 0 Then .Rows.Add(.NewRow)
            With .Rows(0)
                .Item("Cle") = "Logo"
                .Item("TypePiece") = DBNull.Value
                .Item("Logo") = IIf(bytes Is Nothing, DBNull.Value, bytes)
            End With
        End With
    End Sub

    Public Shared Function GetLogo(ByVal dtParams As DataTable) As Image
        If Not dtParams Is Nothing Then
            Dim rws() As DataRow = dtParams.Select("Cle='Logo'")
            If rws.Length > 0 Then
                If Not IsDBNull(rws(0).Item("Logo")) Then
                    Return GetImageFromBytes(CType(rws(0).Item("Logo"), Byte()))
                End If
            End If
        End If
        Return Nothing
    End Function

    Public Shared Sub DeleteLogo(ByVal dtParams As DataTable)
        If Not dtParams Is Nothing Then
            Dim rws() As DataRow = dtParams.Select("Cle='Logo'")
            If rws.Length > 0 Then
                rws(0).Item("Logo") = DBNull.Value
            End If
        End If
    End Sub

    Private Shared Function GetImageFromBytes(ByVal buffer() As Byte) As Image
        Dim i1 As Image
        Dim m As New IO.MemoryStream(buffer)
        Try
            i1 = Image.FromStream(m)
            'Recopier i1 dans i2 pour couper la dépendance sur le memorystream
            'Sinon on peut se prendre des GDI+ Generic Error, notamment en essayant d'enregistrer l'image.
            Dim i2 As New Bitmap(i1.Width, i1.Height, Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(i2)
            g.DrawImage(i1, 0, 0)
            g.Dispose()
            Return i2
        Finally
            m.Close()
            i1.Dispose()
        End Try
    End Function

    Private Shared Function GetImageBytes(ByVal im As Image, ByVal format As Imaging.ImageFormat) As Byte()
        Dim buffer(BUFFER_SIZE) As Byte 'il y a une erreur qui remonte si le buffer n'est pas assez grand.
        Dim m As New IO.MemoryStream(buffer, True)
        Try
            im.Save(m, format)
            'Retailler le buffer pour s'adapter à la taille réelle de l'image enregistrée
            If m.Position <= buffer.Length Then ReDim Preserve buffer(CInt(m.Position) - 1) 'Apparemment ca pourrait marcher aussi sans retailler le buffer, mais bon
            Return buffer
        Finally
            m.Close()
        End Try
    End Function

    Private Shared Function GetImageReduite(ByVal imDep As Image, Optional ByVal CreateLocal As Boolean = False, Optional ByVal maxWidth As Integer = MAX_LOGO_WIDTH, Optional ByVal maxHeight As Integer = MAX_LOGO_HEIGHT) As Image
        Dim Coef As Double = System.Math.Min(maxWidth / imDep.Width, maxHeight / imDep.Height) 'On prend le plus petit des coef pour etre sur de ne pas dépasser la taille max
        Coef = System.Math.Min(1, Coef) ' On n'agrandit pas l'image : au max, C=100%

        Dim imRes As New Bitmap(Convert.ToInt32(imDep.Width * Coef), Convert.ToInt32(imDep.Height * Coef))
        With Graphics.FromImage(imRes)
            .Clear(Color.White)
            .CompositingMode = Drawing2D.CompositingMode.SourceCopy
            .CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            .SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            .PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            .DrawImage(imDep, 0, 0, imRes.Width, imRes.Height)
            .Dispose()
        End With

        If CreateLocal = True Then
            Dim flS As New IO.FileStream(Application.StartupPath & "\Logo.bmp", IO.FileMode.Create)
            imRes.Save(flS, Imaging.ImageFormat.Bmp)
            flS.Close()
        End If

        Return imRes
    End Function

    Private Shared Function GetImageReduite(ByVal strChemin As String, Optional ByVal CreateLocal As Boolean = False) As Image
        Dim fl As New IO.FileStream(strChemin, IO.FileMode.Open)
        Dim ImDep As Image = Image.FromStream(fl)
        fl.Close()

        Return GetImageReduite(ImDep, CreateLocal)
    End Function

    'Public Shared Sub Migration(ByVal dtParams As DataTable)
    '    Dim params() As String = {"EnTete", "EnTeteDetail", "PiedPageDetail", "InfoLegale", "InfoLegale2", "CodeEtablissement", "CodeGuichet", "NCompte", "CleRIB", "Domiciliation", "EMail", "NTel", "NFax"}
    '    For Each param As String In params
    '        ParametresBase.SetValeur(dtParams, param, Nothing, CStr(ParametresApplication.ValeurParametre(param, "")))
    '        Debug.WriteLine(String.Format("Migration {0} = '{1}'", param, ParametresBase.GetValeur(dtParams, param, Nothing, "")))
    '    Next
    'FrDonnees.ConfigSqlServer.UpdateAdapters(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Insert)
    'MsgBox("Migration des paramètres OK", MsgBoxStyle.Information)
    'End Sub
#End Region

End Class
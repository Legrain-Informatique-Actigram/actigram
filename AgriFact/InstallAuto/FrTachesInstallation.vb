Public Class FrTachesInstallation
    Inherits System.Windows.Forms.Form

    Private paramDossier As ParametresDossier
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbVersionSql As System.Windows.Forms.ComboBox
    Private param As ParametresInstallation
    Public Property Parametres() As ParametresInstallation
        Get
            Return param
        End Get
        Set(ByVal Value As ParametresInstallation)
            param = Value
            InitControles()
        End Set
    End Property

    Public Sub New(ByVal Parametres As ParametresInstallation)
        Me.New()
        Me.Parametres = Parametres
    End Sub

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
    Friend WithEvents txInstance As System.Windows.Forms.TextBox
    Friend WithEvents txBase As System.Windows.Forms.TextBox
    Friend WithEvents openDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents foldDlg As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TxSaPwd As System.Windows.Forms.TextBox
    Friend WithEvents TxFichierBaseSource As System.Windows.Forms.TextBox
    Friend WithEvents TxRepBaseDest As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btInstallMsde As System.Windows.Forms.Button
    Friend WithEvents btNewBase As System.Windows.Forms.Button
    Friend WithEvents btRecreerUtilisateurs As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents btOpenMdfFile As System.Windows.Forms.Button
    Friend WithEvents btBrowseFold As System.Windows.Forms.Button
    Friend WithEvents cbNomDossier As System.Windows.Forms.ComboBox
    Friend WithEvents btSaveParam As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrTachesInstallation))
        Me.txInstance = New System.Windows.Forms.TextBox
        Me.txBase = New System.Windows.Forms.TextBox
        Me.TxSaPwd = New System.Windows.Forms.TextBox
        Me.btOpenMdfFile = New System.Windows.Forms.Button
        Me.openDlg = New System.Windows.Forms.OpenFileDialog
        Me.foldDlg = New System.Windows.Forms.FolderBrowserDialog
        Me.TxFichierBaseSource = New System.Windows.Forms.TextBox
        Me.TxRepBaseDest = New System.Windows.Forms.TextBox
        Me.btBrowseFold = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cbVersionSql = New System.Windows.Forms.ComboBox
        Me.cbNomDossier = New System.Windows.Forms.ComboBox
        Me.btInstallMsde = New System.Windows.Forms.Button
        Me.btNewBase = New System.Windows.Forms.Button
        Me.btRecreerUtilisateurs = New System.Windows.Forms.Button
        Me.btClose = New System.Windows.Forms.Button
        Me.btSaveParam = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txInstance
        '
        Me.txInstance.Location = New System.Drawing.Point(152, 72)
        Me.txInstance.Name = "txInstance"
        Me.txInstance.Size = New System.Drawing.Size(192, 20)
        Me.txInstance.TabIndex = 0
        Me.txInstance.Text = "Instance"
        '
        'txBase
        '
        Me.txBase.Location = New System.Drawing.Point(152, 96)
        Me.txBase.Name = "txBase"
        Me.txBase.Size = New System.Drawing.Size(192, 20)
        Me.txBase.TabIndex = 1
        Me.txBase.Text = "Base"
        '
        'TxSaPwd
        '
        Me.TxSaPwd.Location = New System.Drawing.Point(152, 120)
        Me.TxSaPwd.Name = "TxSaPwd"
        Me.TxSaPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxSaPwd.Size = New System.Drawing.Size(192, 20)
        Me.TxSaPwd.TabIndex = 2
        Me.TxSaPwd.Text = "SaPwd"
        '
        'btOpenMdfFile
        '
        Me.btOpenMdfFile.Location = New System.Drawing.Point(320, 160)
        Me.btOpenMdfFile.Name = "btOpenMdfFile"
        Me.btOpenMdfFile.Size = New System.Drawing.Size(24, 20)
        Me.btOpenMdfFile.TabIndex = 3
        Me.btOpenMdfFile.Text = "..."
        '
        'TxFichierBaseSource
        '
        Me.TxFichierBaseSource.Location = New System.Drawing.Point(8, 160)
        Me.TxFichierBaseSource.Name = "TxFichierBaseSource"
        Me.TxFichierBaseSource.Size = New System.Drawing.Size(304, 20)
        Me.TxFichierBaseSource.TabIndex = 6
        Me.TxFichierBaseSource.Text = "Fichier MDF"
        '
        'TxRepBaseDest
        '
        Me.TxRepBaseDest.Location = New System.Drawing.Point(8, 208)
        Me.TxRepBaseDest.Name = "TxRepBaseDest"
        Me.TxRepBaseDest.Size = New System.Drawing.Size(304, 20)
        Me.TxRepBaseDest.TabIndex = 7
        Me.TxRepBaseDest.Text = "Rep données"
        '
        'btBrowseFold
        '
        Me.btBrowseFold.Location = New System.Drawing.Point(320, 208)
        Me.btBrowseFold.Name = "btBrowseFold"
        Me.btBrowseFold.Size = New System.Drawing.Size(24, 20)
        Me.btBrowseFold.TabIndex = 9
        Me.btBrowseFold.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Nom du Dossier Agrifact"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Nom de l'instance SQL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nom de la base à créer"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Mot de passe 'sa'"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(173, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Fichier de base de données source"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 192)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Répertoire de données"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbVersionSql)
        Me.GroupBox1.Controls.Add(Me.cbNomDossier)
        Me.GroupBox1.Controls.Add(Me.txInstance)
        Me.GroupBox1.Controls.Add(Me.btBrowseFold)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btOpenMdfFile)
        Me.GroupBox1.Controls.Add(Me.TxRepBaseDest)
        Me.GroupBox1.Controls.Add(Me.TxFichierBaseSource)
        Me.GroupBox1.Controls.Add(Me.txBase)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxSaPwd)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 234)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paramètres"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Version SQL"
        '
        'cbVersionSql
        '
        Me.cbVersionSql.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVersionSql.FormattingEnabled = True
        Me.cbVersionSql.Items.AddRange(New Object() {"MSDE", "SqlExpress"})
        Me.cbVersionSql.Location = New System.Drawing.Point(152, 45)
        Me.cbVersionSql.Name = "cbVersionSql"
        Me.cbVersionSql.Size = New System.Drawing.Size(192, 21)
        Me.cbVersionSql.TabIndex = 17
        '
        'cbNomDossier
        '
        Me.cbNomDossier.Location = New System.Drawing.Point(152, 16)
        Me.cbNomDossier.Name = "cbNomDossier"
        Me.cbNomDossier.Size = New System.Drawing.Size(192, 21)
        Me.cbNomDossier.TabIndex = 16
        Me.cbNomDossier.Text = "Nom Dossier"
        '
        'btInstallMsde
        '
        Me.btInstallMsde.Location = New System.Drawing.Point(368, 16)
        Me.btInstallMsde.Name = "btInstallMsde"
        Me.btInstallMsde.Size = New System.Drawing.Size(160, 23)
        Me.btInstallMsde.TabIndex = 17
        Me.btInstallMsde.Text = "Créer une instance SQL"
        '
        'btNewBase
        '
        Me.btNewBase.Location = New System.Drawing.Point(368, 48)
        Me.btNewBase.Name = "btNewBase"
        Me.btNewBase.Size = New System.Drawing.Size(160, 23)
        Me.btNewBase.TabIndex = 18
        Me.btNewBase.Text = "Créer une nouvelle base"
        '
        'btRecreerUtilisateurs
        '
        Me.btRecreerUtilisateurs.Location = New System.Drawing.Point(368, 80)
        Me.btRecreerUtilisateurs.Name = "btRecreerUtilisateurs"
        Me.btRecreerUtilisateurs.Size = New System.Drawing.Size(160, 23)
        Me.btRecreerUtilisateurs.TabIndex = 19
        Me.btRecreerUtilisateurs.Text = "Recréer les utilisateurs"
        '
        'btClose
        '
        Me.btClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClose.Location = New System.Drawing.Point(368, 219)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(160, 23)
        Me.btClose.TabIndex = 20
        Me.btClose.Text = "Fermer"
        '
        'btSaveParam
        '
        Me.btSaveParam.Location = New System.Drawing.Point(368, 112)
        Me.btSaveParam.Name = "btSaveParam"
        Me.btSaveParam.Size = New System.Drawing.Size(160, 23)
        Me.btSaveParam.TabIndex = 21
        Me.btSaveParam.Text = "Enregistrer les paramètres"
        '
        'FrTachesInstallation
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 254)
        Me.Controls.Add(Me.btSaveParam)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btRecreerUtilisateurs)
        Me.Controls.Add(Me.btNewBase)
        Me.Controls.Add(Me.btInstallMsde)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrTachesInstallation"
        Me.Text = "Administration de la base de données"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrTachesInstallation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Parametres Is Nothing Then
            Me.Parametres = New ParametresInstallation

            Me.Parametres.Dossiers.Add(New ParametresDossier())
        End If

        ChargerNomsDossiers()
        InitControles()
    End Sub

    Private Sub ChargerNomsDossiers()
        Try
            cbNomDossier.Items.Clear()
            If Not param Is Nothing Then
                'Dim fichier As String = param.ExpandVars(param.FichierParametresAppli)
                'If IO.File.Exists(fichier) Then
                '    Dim ds As New DataSet
                '    ds.ReadXml(fichier)
                '    If ds.Tables.Contains("Parametres") Then
                '        If ds.Tables("Parametres").Columns.Contains("NomDossier") Then
                '            For Each rw As DataRow In ds.Tables("Parametres").Rows
                '                cbNomDossier.Items.Add(rw("NomDossier"))
                '            Next
                '        End If
                '    End If
                'End If
                For Each pDossier As ParametresDossier In param.Dossiers
                    cbNomDossier.Items.Add(pDossier.NomDossier)
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub InitControles()
        If Not param Is Nothing Then
            txInstance.Text = param.InstanceSql
            TxSaPwd.Text = param.SaPwd
            cbVersionSql.SelectedItem = param.VersionSql
            If paramDossier Is Nothing Then
                If param.Dossiers.Count = 0 Then Exit Sub
                paramDossier = param.Dossiers(0)
            End If
            cbNomDossier.Text = paramDossier.NomDossier
            txBase.Text = paramDossier.BaseSql
            TxFichierBaseSource.Text = param.ExpandVars(paramDossier.FichierBaseSource) & ".mdf"
            TxRepBaseDest.Text = param.ExpandVars(paramDossier.RepBaseDest)
        End If
    End Sub

#Region "Controles de mise à jour"
    Private Sub btOpenMdfFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOpenMdfFile.Click
        With openDlg
            .Title = "Fichier source de la base de données"
            .Filter = "Fichiers de données (*.mdf)|*.mdf"
            .FilterIndex = 0
            If IO.File.Exists(TxFichierBaseSource.Text) Then
                .InitialDirectory = IO.Path.GetDirectoryName(TxFichierBaseSource.Text)
                .FileName = TxFichierBaseSource.Text
            Else
                .InitialDirectory = Application.StartupPath
                '.FileName = param.BaseSql & ".mdf"
                .FileName = ""
            End If
            If .ShowDialog = DialogResult.OK Then
                TxFichierBaseSource.Text = .FileName.Replace(".mdf", "").Replace(".MDF", "")
                tx_Validated(TxFichierBaseSource, Nothing)
            End If
        End With
    End Sub

    Private Sub btBrowseFold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btBrowseFold.Click
        With foldDlg
            .Description = "Choisissez l'emplacement de stockage des données de la base."
            If IO.Directory.Exists(TxRepBaseDest.Text) Then
                .SelectedPath = TxRepBaseDest.Text
            Else
                .SelectedPath = Application.StartupPath
            End If
            If .ShowDialog = DialogResult.OK Then
                TxRepBaseDest.Text = .SelectedPath
                tx_Validated(TxRepBaseDest, Nothing)
            End If
        End With
    End Sub

    Private Sub btClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub tx_Validated(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txBase.Validated, txInstance.Validated, TxSaPwd.Validated, TxFichierBaseSource.Validated, TxRepBaseDest.Validated, cbNomDossier.Validated, cbVersionSql.SelectedIndexChanged
        If sender Is cbNomDossier Then
            'Trouver si ce nom de dossier est existant
            Dim pDossier As ParametresDossier = param.GetDossier(cbNomDossier.Text)
            If pDossier Is Nothing Then
                'Si non, on l'affecte comme nom de dossier au dossier en cours
                paramDossier.NomDossier = cbNomDossier.Text
            Else
                'Si oui, on passe à ce dossier
                paramDossier = pDossier
                InitControles()
            End If
        ElseIf sender Is cbVersionSql Then
            param.VersionSql = cbVersionSql.Text
        ElseIf sender Is txBase Then
            paramDossier.BaseSql = txBase.Text
        ElseIf sender Is TxFichierBaseSource Then
            paramDossier.FichierBaseSource = TxFichierBaseSource.Text
        ElseIf sender Is TxRepBaseDest Then
            paramDossier.RepBaseDest = TxRepBaseDest.Text
        ElseIf sender Is txInstance Then
            param.InstanceSql = txInstance.Text
        ElseIf sender Is TxSaPwd Then
            param.SaPwd = TxSaPwd.Text
        End If
    End Sub

    Private Sub cbNomDossier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNomDossier.SelectedIndexChanged
        If cbNomDossier.SelectedIndex >= 0 Then
            'Dim fichier As String = param.ExpandVars(param.FichierParametresAppli)
            'If IO.File.Exists(fichier) Then
            '    Dim ds As New DataSet
            '    ds.ReadXml(fichier)
            '    If ds.Tables.Contains("Parametres") Then
            '        If ds.Tables("Parametres").Columns.Contains("NomDossier") Then
            '            Dim rows() As DataRow = ds.Tables("Parametres").Select("NomDossier='" & cbNomDossier.Text & "'")
            '            If rows.Length > 0 Then
            '                With param
            '                    .NomDossier = cbNomDossier.Text
            '                    .InstanceSql = CStr(rows(0)("ServeurSQL"))
            '                    .InstanceSql = .InstanceSql.Substring(.InstanceSql.IndexOf("\") + 1)
            '                    .BaseSql = rows(0)("BaseSQL")
            '                    .SaPwd = rows(0)("saPwd")
            '                End With
            '                InitControles()
            '            End If
            '        End If
            '    End If
            'End If
            Dim pDossier As ParametresDossier = param.GetDossier(cbNomDossier.Text)
            If Not pDossier Is Nothing Then
                'on passe à ce dossier
                paramDossier = pDossier
                InitControles()
            End If
        End If
    End Sub

#End Region

#Region "Controles d'actions"

    Private Sub btInstallMsde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInstallMsde.Click
        Try
            Dim t As New TachesInstallation(param)
            t.InstallSql()
            MsgBox("Installation réussie")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btNewBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btNewBase.Click
        Try
            Dim t As New TachesInstallation(param)
            t.DemarrerServiceSql()
            t.AttacheBase(paramDossier)
            MsgBox("Création réussie")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btRecreerUtilisateurs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRecreerUtilisateurs.Click
        Try
            Dim t As New TachesInstallation(param)
            t.RecreerUtilisateurs(paramDossier)
            MsgBox("Utilisateurs recréés")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btSaveParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSaveParam.Click
        Try
            Dim t As New TachesInstallation(param)

            t.InitialiserParametres()

            MsgBox("Paramètres enregistrés")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
#End Region

End Class

Public Class FrBanque
    Inherits GRC.FrBase
   

#Region "Ctor"
    Public Sub New()
        MyBase.New()
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.id = -1
        Me.AjouterEnregistrement = True
    End Sub

    Public Sub New(ByVal nPersonne As Integer)
        Me.New()
        Me.id = nPersonne
        Me.AjouterEnregistrement = False
    End Sub
#End Region

#Region "Props"
    Private GestCompta As Compta

    Public ReadOnly Property CurrentDrv() As DataRowView
        Get
            If Me.BanqueBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DataRowView)(Me.BanqueBindingSource.Current)
        End Get
    End Property

    Private ReadOnly Property nBanque() As Integer
        Get
            Return CInt(Me.CurrentDrv("nBanque"))
        End Get
    End Property
#End Region

#Region " Code généré par le Concepteur Windows Form "
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
    Friend WithEvents TbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientCaption1 As Ascend.Windows.Forms.GradientCaption
    Friend WithEvents BanqueBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents GestionControles1 As AgriFact.GestionControles
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrBanque))
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn
        Me.GestionControles1 = New AgriFact.GestionControles
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbSave = New System.Windows.Forms.ToolStripButton
        Me.TbDelete = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientCaption1 = New Ascend.Windows.Forms.GradientCaption
        Me.BanqueBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Code"
        Me.DataGridTextBoxColumn2.MappingName = "CodeProduitComposition"
        Me.DataGridTextBoxColumn2.Width = 50
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Libellé"
        Me.DataGridTextBoxColumn1.MappingName = "LibelleProduitComposition"
        Me.DataGridTextBoxColumn1.ReadOnly = True
        Me.DataGridTextBoxColumn1.Width = 150
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Quantité"
        Me.DataGridTextBoxColumn3.MappingName = "Qt"
        Me.DataGridTextBoxColumn3.Width = 50
        '
        'GestionControles1
        '
        Me.GestionControles1.AutorisationListe = Nothing
        Me.GestionControles1.Autorisations = ""
        Me.GestionControles1.AutoriseAjt = True
        Me.GestionControles1.AutoriseModif = True
        Me.GestionControles1.AutoriseSuppr = True
        Me.GestionControles1.AutoSize = True
        Me.GestionControles1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GestionControles1.DataSource = Nothing
        Me.GestionControles1.DsBase = Nothing
        Me.GestionControles1.FiltreAffichage = ""
        Me.GestionControles1.Label1Top = 10
        Me.GestionControles1.LabelLeft = 10
        Me.GestionControles1.LargeurText = 250
        Me.GestionControles1.LiaisonDonnees = True
        Me.GestionControles1.Lien = Nothing
        Me.GestionControles1.LigneHauteur = 20
        Me.GestionControles1.LigneIntervale = 5
        Me.GestionControles1.Location = New System.Drawing.Point(3, 30)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Size = New System.Drawing.Size(457, 386)
        Me.GestionControles1.TabIndex = 8
        Me.GestionControles1.Table = "Banque"
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 115
        Me.GestionControles1.TypeRecherche = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbSave, Me.TbDelete, Me.TbClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(509, 31)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbSave
        '
        Me.TbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbSave.Image = Global.AgriFact.My.Resources.Resources.save24
        Me.TbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbSave.Name = "TbSave"
        Me.TbSave.Size = New System.Drawing.Size(28, 28)
        Me.TbSave.Text = "Enregistrer"
        '
        'TbDelete
        '
        Me.TbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbDelete.Image = Global.AgriFact.My.Resources.Resources.Suppr24
        Me.TbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbDelete.Name = "TbDelete"
        Me.TbDelete.Size = New System.Drawing.Size(27, 28)
        Me.TbDelete.Text = "Supprimer"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 28)
        Me.TbClose.Text = "Fermer"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 416)
        Me.Panel1.TabIndex = 10
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.Controls.Add(Me.GradientCaption1)
        Me.GradientPanel2.Controls.Add(Me.GestionControles1)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(463, 416)
        Me.GradientPanel2.TabIndex = 0
        '
        'GradientCaption1
        '
        Me.GradientCaption1.CornerRadius = New Ascend.CornerRadius(0, 0, 7, 7)
        Me.GradientCaption1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientCaption1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientCaption1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.GradientCaption1.GradientHighColor = System.Drawing.SystemColors.Window
        Me.GradientCaption1.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientCaption1.Location = New System.Drawing.Point(0, 0)
        Me.GradientCaption1.Name = "GradientCaption1"
        Me.GradientCaption1.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientCaption1.Size = New System.Drawing.Size(463, 24)
        Me.GradientCaption1.TabIndex = 0
        Me.GradientCaption1.Text = "Informations générales"
        '
        'FrBanque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(509, 462)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrBanque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Banques"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.BanqueBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Me.ds = New DataSet

        Using s As New SqlProxy
            GestionControles.FillTablesConfig(Me.ds, s)
            Compta.ChargerDonneesCompta(Me.ds, s)
            If CInt(Me.id) >= 0 Then
                DefinitionDonnees.Instance.Fill(ds, "Banque", s, String.Format("nBanque={0}", Me.id))
                With Me.BanqueBindingSource
                    .DataSource = ds
                    .DataMember = "Banque"
                End With
            ElseIf AjouterEnregistrement Then
                DefinitionDonnees.Instance.FillSchema(ds, "Banque", s)
                'Databinding
                With Me.BanqueBindingSource
                    .DataSource = ds
                    .DataMember = "Banque"
                End With
                'Création de la nouvelle ligne
                Me.BanqueBindingSource.AddNew()
            End If
        End Using

        ConfigDataTableEvents(Me.ds.Tables("Banque"), AddressOf Datarowchanged, True)
        Databinding()
    End Sub

    Private Sub Datarowchanged(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        Select Case e.Action
            Case DataRowAction.Add, DataRowAction.Change, DataRowAction.Rollback
                MajBoutons()
        End Select
    End Sub

    Private Sub Databinding()
        'Databinding
        Me.GestionControles1.SetDataSource(CType(Me.BanqueBindingSource.List, DataView))
        
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Dim c As New System.ComponentModel.CancelEventArgs
        DemanderEnregistrement(c)
        Return Not c.Cancel
    End Function

    Private Shadows Function Validate() As Boolean
        Dim res As Boolean
        res = Me.GestionControles1.VerifContraintes
        If res Then
            res = MyBase.Validate()
        End If
        Return res
    End Function


    Private Sub DemanderEnregistrement(ByVal e As System.ComponentModel.CancelEventArgs)
        e.Cancel = Not Me.Validate()
        If e.Cancel Then
            If Not Me.ds.HasChanges Then
                e.Cancel = False  'Pour sortir sans enregistrer
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        Me.BanqueBindingSource.EndEdit()
        If Me.ds.HasChanges Then
            Select Case MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Cancel
                    e.Cancel = True
                Case MsgBoxResult.No
                    'On continue sans enregistrer
                Case MsgBoxResult.Yes
                    If Not Enregistrer() Then
                        e.Cancel = True
                    End If
            End Select
        End If
    End Sub

    Private Function Enregistrer() As Boolean
        'Enregistrer
        If Not Me.Validate() Then Return False
        Me.BanqueBindingSource.EndEdit()
        Return UpdateBase()
    End Function

    Private Function UpdateBase() As Boolean
        Try
            Dim strNomTable() As String = {"Banque"}
            Using s As New SqlProxy
                s.UpdateTables(ds, strNomTable)
            End Using
            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub gc_MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustRefreshTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                ds.EnforceConstraints = False
                Using s As New SqlProxy
                    s.Fill(ds, t)
                End Using
                ds.EnforceConstraints = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub gc_MustUpdateTabled(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs) Handles GestionControles1.MustUpdateTable
        Try
            Dim t As String = Convert.ToString(e.ComponentChanged)
            If ds.Tables.Contains(t) Then
                Using s As New SqlProxy
                    s.UpdateTable(ds, t)
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Form Events"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case e.CloseReason
            Case CloseReason.TaskManagerClosing
                Exit Sub
            Case Else
                DemanderEnregistrement(e)
                If e.Cancel Then Exit Sub
                If Me.BanqueBindingSource.Position >= 0 Then
                    Me.OnSelectObject(Me.nBanque)
                End If
        End Select
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.GradientPanel2.Height = Math.Max(Me.Panel1.Height, Me.GestionControles1.Height + Me.GradientCaption1.Height)
    End Sub

    Private Sub CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
        Me.BanqueBindingSource.EndEdit()
    End Sub

    Private Sub FrBanque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaption1)
        AddHandler Me.GestionControles1.CtlValidated, AddressOf CtlValidated
        ChargerDonnees()
        If FrApplication.Modules.ModuleCompta Then
            GestCompta = New Compta(ds, Me.BanqueBindingSource.CurrencyManager, "Libelle")
            AddHandler Me.GestionControles1.CtlValidating, AddressOf GestCompta.VerifValidating
            AddHandler Me.GestionControles1.AfficheNewPerso, AddressOf GestCompta.AfficheNewPerso
        End If
        MajBoutons()
    End Sub
#End Region

#Region "Toolbar"
    Private Sub MajBoutons()
        Me.TbSave.Enabled = Me.ds.HasChanges
        Dim rowExists As Boolean = (Me.BanqueBindingSource.Position >= 0 AndAlso Not Me.CurrentDrv.IsNew)
        Me.TbDelete.Enabled = rowExists
    End Sub

    Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
        Enregistrer()
        MajBoutons()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        If Me.BanqueBindingSource.Position < 0 Then Exit Sub
        Try
            Dim nBanqueDelete As Integer = Me.nBanque
            Me.BanqueBindingSource.RemoveCurrent()
            If UpdateBase() Then
                If Not IsDBNull(FrApplication.ValeurDefault.nBanqueEntreprise) AndAlso nBanqueDelete = CInt(FrApplication.ValeurDefault.nBanqueEntreprise) Then
                    FrApplication.ValeurDefault.nBanqueEntreprise = DBNull.Value
                End If
                Me.Close()
            End If
        Catch ex As UserCancelledException
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub
#End Region

End Class

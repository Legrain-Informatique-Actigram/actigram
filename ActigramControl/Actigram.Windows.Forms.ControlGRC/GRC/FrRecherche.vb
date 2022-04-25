Public Class FrRecherche
    Inherits System.Windows.Forms.Form
    'Inherits FrBase
    Dim myTable As String
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Dim ds As DataSet
    Public Event AffectuerRecherche(ByVal CritereRecherche As String)

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
    Friend WithEvents GestionControles1 As GestionControlesBase
    Friend WithEvents BtRecherche As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.BtRecherche = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GestionControles1 = New GRC.GestionControlesBase
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtRecherche
        '
        Me.BtRecherche.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtRecherche.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtRecherche.Location = New System.Drawing.Point(0, 374)
        Me.BtRecherche.Name = "BtRecherche"
        Me.BtRecherche.Size = New System.Drawing.Size(456, 32)
        Me.BtRecherche.TabIndex = 2
        Me.BtRecherche.Text = "Rechercher"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(1)
        Me.GradientPanel2.Controls.Add(Me.GestionControles1)
        Me.GradientPanel2.CornerRadius = New Ascend.CornerRadius(7)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(456, 374)
        Me.GradientPanel2.TabIndex = 24
        '
        'GestionControles1
        '
        Me.GestionControles1.AutorisationListe = Nothing
        Me.GestionControles1.Autorisations = ""
        Me.GestionControles1.AutoriseAjt = True
        Me.GestionControles1.AutoriseModif = True
        Me.GestionControles1.AutoriseSuppr = True
        Me.GestionControles1.AutoScroll = True
        Me.GestionControles1.AutoSize = True
        Me.GestionControles1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GestionControles1.DataSource = Nothing
        Me.GestionControles1.DsBase = Nothing
        Me.GestionControles1.FiltreAffichage = ""
        Me.GestionControles1.Label1Top = 10
        Me.GestionControles1.LabelLeft = 10
        Me.GestionControles1.LargeurText = 170
        Me.GestionControles1.LiaisonDonnees = False
        Me.GestionControles1.Lien = Nothing
        Me.GestionControles1.LigneHauteur = 20
        Me.GestionControles1.LigneIntervale = 5
        Me.GestionControles1.Location = New System.Drawing.Point(0, 0)
        Me.GestionControles1.MinimumSize = New System.Drawing.Size(150, 150)
        Me.GestionControles1.Name = "GestionControles1"
        Me.GestionControles1.NuméroNiveau1 = 0
        Me.GestionControles1.Padding = New System.Windows.Forms.Padding(10)
        Me.GestionControles1.Size = New System.Drawing.Size(456, 374)
        Me.GestionControles1.TabIndex = 0
        Me.GestionControles1.Table = Nothing
        Me.GestionControles1.TableListeChoix = "ListeChoix"
        Me.GestionControles1.TableParam = "Niveau2"
        Me.GestionControles1.TexteLeft = 200
        Me.GestionControles1.TypeRecherche = True
        '
        'FrRecherche
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 406)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.BtRecherche)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recherche"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructeurs"
    Public Sub New(ByVal momDataSet As DataSet, ByVal maTable As String, Optional ByVal nomTableConfig As String = Nothing)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        ds = momDataSet
        myTable = maTable
        Me.GestionControles1.Table = myTable
        If nomTableConfig Is Nothing Then
            Me.GestionControles1.NomTableConfig = myTable
        Else
            Me.GestionControles1.NomTableConfig = nomTableConfig
        End If

        Me.GestionControles1.SetDataSource(New DataView(ds.Tables(myTable)))
    End Sub
#End Region

#Region "Form"
    Private Sub FrRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrRecherche_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.ClientSize = New Size(Me.GradientPanel2.Width, Me.GestionControles1.Height + Me.BtRecherche.Height + 20)

        'Met le focus sur le premier textbox (-> Nom)
        For Each ctrl As Control In Me.GestionControles1.Controls(0).Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Focus()

                Exit For
            End If
        Next
    End Sub

    Private Sub FrRecherche_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.GestionControles1.Height = Me.ClientSize.Height - Me.BtRecherche.Height
    End Sub
#End Region

#Region "Button"
    Private Sub BtRecherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRecherche.Click
        RaiseEvent AffectuerRecherche(Me.GestionControles1.GetCritereRecherche)
    End Sub
#End Region

#Region "GestionControles1"
    Private Sub GestionControles1_LancerRecherche(ByVal sender As Object, ByVal e As System.EventArgs) Handles GestionControles1.LancerRecherche
        RaiseEvent AffectuerRecherche(Me.GestionControles1.GetCritereRecherche)
    End Sub
#End Region

End Class

Public Class Form1
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
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CkAchat As System.Windows.Forms.CheckBox
    Friend WithEvents CkVente As System.Windows.Forms.CheckBox
    Friend WithEvents CkStock As System.Windows.Forms.CheckBox
    Friend WithEvents CkReglement As System.Windows.Forms.CheckBox
    Friend WithEvents CkBalance As System.Windows.Forms.CheckBox
    Friend WithEvents CkEvenement As System.Windows.Forms.CheckBox
    Friend WithEvents CkLot As System.Windows.Forms.CheckBox
    Friend WithEvents CkTableaudeBord As System.Windows.Forms.CheckBox
    Friend WithEvents TxNSerie As System.Windows.Forms.TextBox
    Friend WithEvents TxResultat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CkRelance As System.Windows.Forms.CheckBox
    Friend WithEvents CkGestionSite As System.Windows.Forms.CheckBox
    Friend WithEvents CkGestionMarge As System.Windows.Forms.CheckBox
    Friend WithEvents CkCompta As System.Windows.Forms.CheckBox
    Friend WithEvents CkTarif As System.Windows.Forms.CheckBox
    Friend WithEvents CkContact As System.Windows.Forms.CheckBox
    Friend WithEvents CkDemo As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.TxNSerie = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CkDemo = New System.Windows.Forms.CheckBox
        Me.CkContact = New System.Windows.Forms.CheckBox
        Me.CkTarif = New System.Windows.Forms.CheckBox
        Me.CkCompta = New System.Windows.Forms.CheckBox
        Me.CkGestionMarge = New System.Windows.Forms.CheckBox
        Me.CkGestionSite = New System.Windows.Forms.CheckBox
        Me.CkRelance = New System.Windows.Forms.CheckBox
        Me.CkTableaudeBord = New System.Windows.Forms.CheckBox
        Me.CkLot = New System.Windows.Forms.CheckBox
        Me.CkEvenement = New System.Windows.Forms.CheckBox
        Me.CkBalance = New System.Windows.Forms.CheckBox
        Me.CkReglement = New System.Windows.Forms.CheckBox
        Me.CkStock = New System.Windows.Forms.CheckBox
        Me.CkVente = New System.Windows.Forms.CheckBox
        Me.CkAchat = New System.Windows.Forms.CheckBox
        Me.TxResultat = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxNSerie
        '
        Me.TxNSerie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxNSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxNSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxNSerie.Location = New System.Drawing.Point(152, 16)
        Me.TxNSerie.Name = "TxNSerie"
        Me.TxNSerie.Size = New System.Drawing.Size(250, 20)
        Me.TxNSerie.TabIndex = 0
        Me.TxNSerie.Text = ""
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Location = New System.Drawing.Point(152, 48)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(250, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = ""
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(48, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "N° de série"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(48, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 23)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Clé"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.CkDemo)
        Me.GroupBox1.Controls.Add(Me.CkContact)
        Me.GroupBox1.Controls.Add(Me.CkTarif)
        Me.GroupBox1.Controls.Add(Me.CkCompta)
        Me.GroupBox1.Controls.Add(Me.CkGestionMarge)
        Me.GroupBox1.Controls.Add(Me.CkGestionSite)
        Me.GroupBox1.Controls.Add(Me.CkRelance)
        Me.GroupBox1.Controls.Add(Me.CkTableaudeBord)
        Me.GroupBox1.Controls.Add(Me.CkLot)
        Me.GroupBox1.Controls.Add(Me.CkEvenement)
        Me.GroupBox1.Controls.Add(Me.CkBalance)
        Me.GroupBox1.Controls.Add(Me.CkReglement)
        Me.GroupBox1.Controls.Add(Me.CkStock)
        Me.GroupBox1.Controls.Add(Me.CkVente)
        Me.GroupBox1.Controls.Add(Me.CkAchat)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(386, 224)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Modules"
        '
        'CkDemo
        '
        Me.CkDemo.Location = New System.Drawing.Point(16, 24)
        Me.CkDemo.Name = "CkDemo"
        Me.CkDemo.Size = New System.Drawing.Size(184, 16)
        Me.CkDemo.TabIndex = 14
        Me.CkDemo.Text = "Version Demo"
        '
        'CkContact
        '
        Me.CkContact.Location = New System.Drawing.Point(200, 48)
        Me.CkContact.Name = "CkContact"
        Me.CkContact.Size = New System.Drawing.Size(184, 16)
        Me.CkContact.TabIndex = 13
        Me.CkContact.Text = "Gestion des Contacts"
        '
        'CkTarif
        '
        Me.CkTarif.Location = New System.Drawing.Point(16, 192)
        Me.CkTarif.Name = "CkTarif"
        Me.CkTarif.Size = New System.Drawing.Size(184, 16)
        Me.CkTarif.TabIndex = 12
        Me.CkTarif.Text = "Gestion des Tarifs"
        '
        'CkCompta
        '
        Me.CkCompta.Location = New System.Drawing.Point(200, 144)
        Me.CkCompta.Name = "CkCompta"
        Me.CkCompta.Size = New System.Drawing.Size(184, 16)
        Me.CkCompta.TabIndex = 11
        Me.CkCompta.Text = "Connexion Compta"
        '
        'CkGestionMarge
        '
        Me.CkGestionMarge.Location = New System.Drawing.Point(16, 144)
        Me.CkGestionMarge.Name = "CkGestionMarge"
        Me.CkGestionMarge.Size = New System.Drawing.Size(184, 16)
        Me.CkGestionMarge.TabIndex = 10
        Me.CkGestionMarge.Text = "Gestion Marge"
        '
        'CkGestionSite
        '
        Me.CkGestionSite.Location = New System.Drawing.Point(200, 96)
        Me.CkGestionSite.Name = "CkGestionSite"
        Me.CkGestionSite.Size = New System.Drawing.Size(184, 16)
        Me.CkGestionSite.TabIndex = 9
        Me.CkGestionSite.Text = "Gestion Site"
        '
        'CkRelance
        '
        Me.CkRelance.Location = New System.Drawing.Point(16, 168)
        Me.CkRelance.Name = "CkRelance"
        Me.CkRelance.Size = New System.Drawing.Size(184, 16)
        Me.CkRelance.TabIndex = 8
        Me.CkRelance.Text = "Gestion Relance"
        '
        'CkTableaudeBord
        '
        Me.CkTableaudeBord.Location = New System.Drawing.Point(16, 120)
        Me.CkTableaudeBord.Name = "CkTableaudeBord"
        Me.CkTableaudeBord.Size = New System.Drawing.Size(184, 16)
        Me.CkTableaudeBord.TabIndex = 7
        Me.CkTableaudeBord.Text = "Tableau de Bord"
        '
        'CkLot
        '
        Me.CkLot.Location = New System.Drawing.Point(200, 192)
        Me.CkLot.Name = "CkLot"
        Me.CkLot.Size = New System.Drawing.Size(96, 16)
        Me.CkLot.TabIndex = 6
        Me.CkLot.Text = "Lot"
        '
        'CkEvenement
        '
        Me.CkEvenement.Location = New System.Drawing.Point(200, 72)
        Me.CkEvenement.Name = "CkEvenement"
        Me.CkEvenement.Size = New System.Drawing.Size(96, 16)
        Me.CkEvenement.TabIndex = 5
        Me.CkEvenement.Text = "Evenement"
        '
        'CkBalance
        '
        Me.CkBalance.Location = New System.Drawing.Point(200, 120)
        Me.CkBalance.Name = "CkBalance"
        Me.CkBalance.Size = New System.Drawing.Size(96, 16)
        Me.CkBalance.TabIndex = 4
        Me.CkBalance.Text = "Balance"
        '
        'CkReglement
        '
        Me.CkReglement.Location = New System.Drawing.Point(16, 96)
        Me.CkReglement.Name = "CkReglement"
        Me.CkReglement.Size = New System.Drawing.Size(96, 16)
        Me.CkReglement.TabIndex = 3
        Me.CkReglement.Text = "Reglement"
        '
        'CkStock
        '
        Me.CkStock.Location = New System.Drawing.Point(200, 168)
        Me.CkStock.Name = "CkStock"
        Me.CkStock.Size = New System.Drawing.Size(96, 16)
        Me.CkStock.TabIndex = 2
        Me.CkStock.Text = "Stock"
        '
        'CkVente
        '
        Me.CkVente.Location = New System.Drawing.Point(16, 72)
        Me.CkVente.Name = "CkVente"
        Me.CkVente.Size = New System.Drawing.Size(96, 16)
        Me.CkVente.TabIndex = 1
        Me.CkVente.Text = "Vente"
        '
        'CkAchat
        '
        Me.CkAchat.Location = New System.Drawing.Point(16, 48)
        Me.CkAchat.Name = "CkAchat"
        Me.CkAchat.Size = New System.Drawing.Size(96, 16)
        Me.CkAchat.TabIndex = 0
        Me.CkAchat.Text = "Achat"
        '
        'TxResultat
        '
        Me.TxResultat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxResultat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxResultat.Location = New System.Drawing.Point(160, 330)
        Me.TxResultat.Name = "TxResultat"
        Me.TxResultat.ReadOnly = True
        Me.TxResultat.Size = New System.Drawing.Size(250, 20)
        Me.TxResultat.TabIndex = 5
        Me.TxResultat.Text = ""
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(56, 330)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Clé"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(458, 360)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxResultat)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TxNSerie)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Gestion de licences Agrifact"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TxNSerie.TextChanged, CkAchat.CheckedChanged, CkBalance.CheckedChanged, CkEvenement.CheckedChanged, _
    CkLot.CheckedChanged, CkReglement.CheckedChanged, CkTableaudeBord.CheckedChanged, CkVente.CheckedChanged, _
    CkStock.CheckedChanged, CkGestionSite.CheckedChanged, CkRelance.CheckedChanged, CkGestionMarge.CheckedChanged, _
    CkCompta.CheckedChanged, CkTarif.CheckedChanged, CkContact.CheckedChanged, CkDemo.CheckedChanged
        Dim sn As String = Me.TxNSerie.Text
        If sn <> "" Then
            Dim X As Integer
            Dim Y As Double
            Dim chckSomme As Long
            Dim HexY As String

            For X = 1 To Len(sn)
                chckSomme += Asc(Mid(sn, X, 1))
            Next X

            Y = ((chckSomme ^ 2 * 2 + chckSomme ^ 0.5 * 3) / chckSomme ^ 1.5 * 4) * chckSomme ^ 2 * 5
            HexY = Hex(Y)

            chckSomme = 0
            For X = 1 To HexY.Length
                chckSomme += Asc(Mid(HexY, X, 1))
            Next

            Dim md As New Actigram.Securite.Modules
            md.ModuleAchat = Me.CkAchat.Checked
            md.ModuleBalance = Me.CkBalance.Checked
            md.ModuleEvenement = Me.CkEvenement.Checked
            md.ModuleLot = Me.CkLot.Checked
            md.ModuleReglement = Me.CkReglement.Checked
            md.ModuleStock = Me.CkStock.Checked
            md.ModuleTableauBord = Me.CkTableaudeBord.Checked
            md.ModuleVente = Me.CkVente.Checked
            md.ModuleGestionWeb = Me.CkGestionSite.Checked
            md.ModuleGestionRelance = Me.CkRelance.Checked
            md.ModuleGestionMarge = Me.CkGestionMarge.Checked
            md.ModuleCompta = Me.CkCompta.Checked
            md.ModuleTarif = Me.CkTarif.Checked
            md.ModuleContact = Me.CkContact.Checked
            md.VersionDemo = Me.CkDemo.Checked
            Dim strCle As String = HexY & Convert.ToChar(Hex(chckSomme Mod 16)).ToString & Hex(Actigram.Binaire.Binaire.CBinDec(md.GetStringFromModule) + Actigram.Binaire.Binaire.CHexDec(HexY))

            chckSomme = 0
            For X = 1 To strCle.Length
                chckSomme += Asc(Mid(strCle, X, 1)) * 2
            Next

            Me.TxResultat.Text = strCle & Convert.ToChar(Hex(chckSomme Mod 16)).ToString
        Else
            Me.TxResultat.Text = ""
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Licence par défaut
        CkVente.Checked = True
        CkReglement.Checked = True
        CkRelance.Checked = True
        CkCompta.Checked = True
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If Me.TxNSerie.Text.Trim.Length = 0 _
        Or Me.TextBox2.Text.Trim.Length = 0 Then Exit Sub

        Dim md As Actigram.Securite.Modules = Actigram.Securite.GetLicence.GetModuleFromCle(TxNSerie.Text, TextBox2.Text)
        If Not md Is Nothing Then
            Me.CkAchat.Checked = md.ModuleAchat
            Me.CkBalance.Checked = md.ModuleBalance
            Me.CkEvenement.Checked = md.ModuleEvenement
            Me.CkLot.Checked = md.ModuleLot
            Me.CkReglement.Checked = md.ModuleReglement
            Me.CkStock.Checked = md.ModuleStock
            Me.CkTableaudeBord.Checked = md.ModuleTableauBord
            Me.CkVente.Checked = md.ModuleVente
            Me.CkGestionSite.Checked = md.ModuleGestionWeb
            Me.CkRelance.Checked = md.ModuleGestionRelance
            Me.CkGestionMarge.Checked = md.ModuleGestionMarge
            Me.CkCompta.Checked = md.ModuleCompta
            Me.CkTarif.Checked = md.ModuleTarif
            Me.CkContact.Checked = md.ModuleContact
            Me.CkDemo.Checked = md.VersionDemo
        End If
    End Sub
End Class

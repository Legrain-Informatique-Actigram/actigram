Public Class FrChamps
    Inherits System.Windows.Forms.Form
    Private cn As SqlClient.SqlConnection
    Private Champs As ParamNiveau2
    Private Table As String

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal connection As SqlClient.SqlConnection)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        cn = connection
    End Sub

    Public Sub New(ByVal connection As SqlClient.SqlConnection, ByVal MyChamps As ParamNiveau2)
        Me.New(connection)
        Champs = MyChamps
    End Sub

    Public Sub New(ByVal connection As SqlClient.SqlConnection, ByVal MyTable As String)
        Me.New(connection)
        Table = MyTable
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
    Friend WithEvents TxLibelle As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabListeChoix As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxTableListeChoixType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CkAfficherFormulaireRecherche As System.Windows.Forms.CheckBox
    Friend WithEvents CkAfficherRecherche As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CkStopSaisi As System.Windows.Forms.CheckBox
    Friend WithEvents CkIsObligatoire As System.Windows.Forms.CheckBox
    Friend WithEvents CkIsAdresseWeb As System.Windows.Forms.CheckBox
    Friend WithEvents CkIsMail As System.Windows.Forms.CheckBox
    Friend WithEvents CkIsChemin As System.Windows.Forms.CheckBox
    Friend WithEvents CkIsRTF As System.Windows.Forms.CheckBox
    Friend WithEvents CkMultiLine As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxHauteurMultiline As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxnNiveau1 As System.Windows.Forms.TextBox
    Friend WithEvents TxnNiveau2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BtCreer As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents CkNpAfficherFormulaire As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxTaille As System.Windows.Forms.TextBox
    Friend WithEvents TxPrecision As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxNiveauAutorisation As System.Windows.Forms.ComboBox
    Friend WithEvents TxListeChoixMultipleTable As System.Windows.Forms.ComboBox
    Friend WithEvents TxListeChoixMultipleChamps As System.Windows.Forms.ComboBox
    Friend WithEvents TxTableListeChoix As System.Windows.Forms.ComboBox
    Friend WithEvents TxTableListeChoixSelectChamps As System.Windows.Forms.ComboBox
    Friend WithEvents TxChamps As System.Windows.Forms.ComboBox
    Friend WithEvents TxTable As System.Windows.Forms.ComboBox
    Friend WithEvents TxTableListeChoixAfficheChamps As System.Windows.Forms.ComboBox
    Friend WithEvents TxListeChoix As System.Windows.Forms.ComboBox
    Friend WithEvents TxListeChoixMultiple As System.Windows.Forms.ComboBox
    Friend WithEvents TxListeChoixChampsFiltre As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TxLX As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxLY As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxLW As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TxLH As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxTW As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxTH As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxTY As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TxTX As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxNbLigne As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TxValDefaut As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxTableListeChoixTri As System.Windows.Forms.ComboBox
    Friend WithEvents TxMaxLength As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxFiltreType As System.Windows.Forms.TextBox
    Friend WithEvents TxFiltrePlus As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxLibelle = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxFiltreType = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.TabListeChoix = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TxListeChoixChampsFiltre = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxListeChoix = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TxListeChoixMultipleChamps = New System.Windows.Forms.ComboBox
        Me.TxListeChoixMultipleTable = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TxListeChoixMultiple = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.TxTableListeChoixTri = New System.Windows.Forms.ComboBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxTableListeChoixAfficheChamps = New System.Windows.Forms.ComboBox
        Me.TxTableListeChoixSelectChamps = New System.Windows.Forms.ComboBox
        Me.TxTableListeChoix = New System.Windows.Forms.ComboBox
        Me.TxTableListeChoixType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxHauteurMultiline = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CkMultiLine = New System.Windows.Forms.CheckBox
        Me.CkAfficherRecherche = New System.Windows.Forms.CheckBox
        Me.CkAfficherFormulaireRecherche = New System.Windows.Forms.CheckBox
        Me.CkNpAfficherFormulaire = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TxMaxLength = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.CkIsRTF = New System.Windows.Forms.CheckBox
        Me.CkIsChemin = New System.Windows.Forms.CheckBox
        Me.CkIsMail = New System.Windows.Forms.CheckBox
        Me.CkIsAdresseWeb = New System.Windows.Forms.CheckBox
        Me.CkIsObligatoire = New System.Windows.Forms.CheckBox
        Me.CkStopSaisi = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxNiveauAutorisation = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxnNiveau2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxnNiveau1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.BtCreer = New System.Windows.Forms.Button
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TxValDefaut = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.TxPrecision = New System.Windows.Forms.TextBox
        Me.TxTaille = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxType = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxChamps = New System.Windows.Forms.ComboBox
        Me.TxTable = New System.Windows.Forms.ComboBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.TxNbLigne = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxTW = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxTH = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxTY = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.TxTX = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxLW = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxLH = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TxLY = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxLX = New System.Windows.Forms.TextBox
        Me.TxFiltrePlus = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.TabListeChoix.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Champs"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxLibelle
        '
        Me.TxLibelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLibelle.Location = New System.Drawing.Point(72, 72)
        Me.TxLibelle.Name = "TxLibelle"
        Me.TxLibelle.Size = New System.Drawing.Size(216, 20)
        Me.TxLibelle.TabIndex = 3
        Me.TxLibelle.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libelle"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxFiltreType)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.TabListeChoix)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 232)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choix parmi une liste"
        '
        'TxFiltreType
        '
        Me.TxFiltreType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxFiltreType.Location = New System.Drawing.Point(112, 200)
        Me.TxFiltreType.Name = "TxFiltreType"
        Me.TxFiltreType.Size = New System.Drawing.Size(144, 20)
        Me.TxFiltreType.TabIndex = 14
        Me.TxFiltreType.Text = ""
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(16, 200)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(88, 16)
        Me.Label34.TabIndex = 10
        Me.Label34.Text = "Filtre"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabListeChoix
        '
        Me.TabListeChoix.Controls.Add(Me.TabPage1)
        Me.TabListeChoix.Controls.Add(Me.TabPage3)
        Me.TabListeChoix.Controls.Add(Me.TabPage2)
        Me.TabListeChoix.Controls.Add(Me.TabPage4)
        Me.TabListeChoix.Location = New System.Drawing.Point(8, 16)
        Me.TabListeChoix.Name = "TabListeChoix"
        Me.TabListeChoix.SelectedIndex = 0
        Me.TabListeChoix.Size = New System.Drawing.Size(264, 176)
        Me.TabListeChoix.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.TxListeChoixChampsFiltre)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.TxListeChoix)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(256, 150)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Simple"
        '
        'TxListeChoixChampsFiltre
        '
        Me.TxListeChoixChampsFiltre.Location = New System.Drawing.Point(104, 48)
        Me.TxListeChoixChampsFiltre.Name = "TxListeChoixChampsFiltre"
        Me.TxListeChoixChampsFiltre.Size = New System.Drawing.Size(136, 21)
        Me.TxListeChoixChampsFiltre.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 16)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Champs Filtre"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxListeChoix
        '
        Me.TxListeChoix.Location = New System.Drawing.Point(104, 14)
        Me.TxListeChoix.Name = "TxListeChoix"
        Me.TxListeChoix.Size = New System.Drawing.Size(136, 21)
        Me.TxListeChoix.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Liste Choix"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.White
        Me.TabPage3.Controls.Add(Me.TxListeChoixMultipleChamps)
        Me.TabPage3.Controls.Add(Me.TxListeChoixMultipleTable)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(256, 150)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Multiple (Table)"
        '
        'TxListeChoixMultipleChamps
        '
        Me.TxListeChoixMultipleChamps.Location = New System.Drawing.Point(104, 48)
        Me.TxListeChoixMultipleChamps.Name = "TxListeChoixMultipleChamps"
        Me.TxListeChoixMultipleChamps.Size = New System.Drawing.Size(136, 21)
        Me.TxListeChoixMultipleChamps.TabIndex = 13
        '
        'TxListeChoixMultipleTable
        '
        Me.TxListeChoixMultipleTable.Location = New System.Drawing.Point(104, 14)
        Me.TxListeChoixMultipleTable.Name = "TxListeChoixMultipleTable"
        Me.TxListeChoixMultipleTable.Size = New System.Drawing.Size(136, 21)
        Me.TxListeChoixMultipleTable.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Champs"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Table"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.TxListeChoixMultiple)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(256, 150)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Multiple (Liste)"
        '
        'TxListeChoixMultiple
        '
        Me.TxListeChoixMultiple.Location = New System.Drawing.Point(104, 14)
        Me.TxListeChoixMultiple.Name = "TxListeChoixMultiple"
        Me.TxListeChoixMultiple.Size = New System.Drawing.Size(136, 21)
        Me.TxListeChoixMultiple.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Liste Choix"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.White
        Me.TabPage4.Controls.Add(Me.TxTableListeChoixTri)
        Me.TabPage4.Controls.Add(Me.Label32)
        Me.TabPage4.Controls.Add(Me.TxTableListeChoixAfficheChamps)
        Me.TabPage4.Controls.Add(Me.TxTableListeChoixSelectChamps)
        Me.TabPage4.Controls.Add(Me.TxTableListeChoix)
        Me.TabPage4.Controls.Add(Me.TxTableListeChoixType)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Label10)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(256, 150)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Cle"
        '
        'TxTableListeChoixTri
        '
        Me.TxTableListeChoixTri.Location = New System.Drawing.Point(112, 120)
        Me.TxTableListeChoixTri.Name = "TxTableListeChoixTri"
        Me.TxTableListeChoixTri.Size = New System.Drawing.Size(136, 21)
        Me.TxTableListeChoixTri.TabIndex = 20
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(8, 122)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(104, 16)
        Me.Label32.TabIndex = 19
        Me.Label32.Text = "Tri"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxTableListeChoixAfficheChamps
        '
        Me.TxTableListeChoixAfficheChamps.Location = New System.Drawing.Point(112, 92)
        Me.TxTableListeChoixAfficheChamps.Name = "TxTableListeChoixAfficheChamps"
        Me.TxTableListeChoixAfficheChamps.Size = New System.Drawing.Size(136, 21)
        Me.TxTableListeChoixAfficheChamps.TabIndex = 18
        '
        'TxTableListeChoixSelectChamps
        '
        Me.TxTableListeChoixSelectChamps.Location = New System.Drawing.Point(112, 64)
        Me.TxTableListeChoixSelectChamps.Name = "TxTableListeChoixSelectChamps"
        Me.TxTableListeChoixSelectChamps.Size = New System.Drawing.Size(136, 21)
        Me.TxTableListeChoixSelectChamps.TabIndex = 17
        '
        'TxTableListeChoix
        '
        Me.TxTableListeChoix.Location = New System.Drawing.Point(112, 36)
        Me.TxTableListeChoix.Name = "TxTableListeChoix"
        Me.TxTableListeChoix.Size = New System.Drawing.Size(136, 21)
        Me.TxTableListeChoix.TabIndex = 16
        '
        'TxTableListeChoixType
        '
        Me.TxTableListeChoixType.Items.AddRange(New Object() {"", "n", "cb", "cbn", "cbp"})
        Me.TxTableListeChoixType.Location = New System.Drawing.Point(112, 8)
        Me.TxTableListeChoixType.Name = "TxTableListeChoixType"
        Me.TxTableListeChoixType.Size = New System.Drawing.Size(136, 21)
        Me.TxTableListeChoixType.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Champs à Afficher"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 66)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Clé"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 16)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Table"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Type"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxHauteurMultiline)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.CkMultiLine)
        Me.GroupBox2.Controls.Add(Me.CkAfficherRecherche)
        Me.GroupBox2.Controls.Add(Me.CkAfficherFormulaireRecherche)
        Me.GroupBox2.Controls.Add(Me.CkNpAfficherFormulaire)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 128)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 176)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Affichage"
        '
        'TxHauteurMultiline
        '
        Me.TxHauteurMultiline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxHauteurMultiline.Location = New System.Drawing.Point(80, 152)
        Me.TxHauteurMultiline.Name = "TxHauteurMultiline"
        Me.TxHauteurMultiline.Size = New System.Drawing.Size(104, 20)
        Me.TxHauteurMultiline.TabIndex = 13
        Me.TxHauteurMultiline.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Nb Lignes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CkMultiLine
        '
        Me.CkMultiLine.Location = New System.Drawing.Point(8, 128)
        Me.CkMultiLine.Name = "CkMultiLine"
        Me.CkMultiLine.Size = New System.Drawing.Size(176, 24)
        Me.CkMultiLine.TabIndex = 11
        Me.CkMultiLine.Text = "Affichage Multi Lignes"
        '
        'CkAfficherRecherche
        '
        Me.CkAfficherRecherche.Location = New System.Drawing.Point(8, 88)
        Me.CkAfficherRecherche.Name = "CkAfficherRecherche"
        Me.CkAfficherRecherche.Size = New System.Drawing.Size(176, 32)
        Me.CkAfficherRecherche.TabIndex = 10
        Me.CkAfficherRecherche.Text = "Afficher dans le RESULTAT de la recherche"
        '
        'CkAfficherFormulaireRecherche
        '
        Me.CkAfficherFormulaireRecherche.Location = New System.Drawing.Point(8, 48)
        Me.CkAfficherFormulaireRecherche.Name = "CkAfficherFormulaireRecherche"
        Me.CkAfficherFormulaireRecherche.Size = New System.Drawing.Size(176, 32)
        Me.CkAfficherFormulaireRecherche.TabIndex = 9
        Me.CkAfficherFormulaireRecherche.Text = "Afficher dans le FORMULAIRE de recherche"
        '
        'CkNpAfficherFormulaire
        '
        Me.CkNpAfficherFormulaire.Location = New System.Drawing.Point(8, 16)
        Me.CkNpAfficherFormulaire.Name = "CkNpAfficherFormulaire"
        Me.CkNpAfficherFormulaire.Size = New System.Drawing.Size(176, 32)
        Me.CkNpAfficherFormulaire.TabIndex = 8
        Me.CkNpAfficherFormulaire.Text = "Afficher dans le Formulaire"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TxMaxLength)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.CkIsRTF)
        Me.GroupBox3.Controls.Add(Me.CkIsChemin)
        Me.GroupBox3.Controls.Add(Me.CkIsMail)
        Me.GroupBox3.Controls.Add(Me.CkIsAdresseWeb)
        Me.GroupBox3.Controls.Add(Me.CkIsObligatoire)
        Me.GroupBox3.Controls.Add(Me.CkStopSaisi)
        Me.GroupBox3.Location = New System.Drawing.Point(496, 128)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(160, 176)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Divers"
        '
        'TxMaxLength
        '
        Me.TxMaxLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxMaxLength.Location = New System.Drawing.Point(40, 152)
        Me.TxMaxLength.Name = "TxMaxLength"
        Me.TxMaxLength.Size = New System.Drawing.Size(104, 20)
        Me.TxMaxLength.TabIndex = 15
        Me.TxMaxLength.Text = ""
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(8, 152)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(32, 16)
        Me.Label33.TabIndex = 14
        Me.Label33.Text = "Max"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CkIsRTF
        '
        Me.CkIsRTF.Location = New System.Drawing.Point(8, 126)
        Me.CkIsRTF.Name = "CkIsRTF"
        Me.CkIsRTF.Size = New System.Drawing.Size(136, 16)
        Me.CkIsRTF.TabIndex = 5
        Me.CkIsRTF.Text = "Format RTF"
        '
        'CkIsChemin
        '
        Me.CkIsChemin.Location = New System.Drawing.Point(8, 104)
        Me.CkIsChemin.Name = "CkIsChemin"
        Me.CkIsChemin.Size = New System.Drawing.Size(136, 16)
        Me.CkIsChemin.TabIndex = 4
        Me.CkIsChemin.Text = "Chemin d'acces"
        '
        'CkIsMail
        '
        Me.CkIsMail.Location = New System.Drawing.Point(8, 82)
        Me.CkIsMail.Name = "CkIsMail"
        Me.CkIsMail.Size = New System.Drawing.Size(136, 16)
        Me.CkIsMail.TabIndex = 3
        Me.CkIsMail.Text = "Mail"
        '
        'CkIsAdresseWeb
        '
        Me.CkIsAdresseWeb.Location = New System.Drawing.Point(8, 60)
        Me.CkIsAdresseWeb.Name = "CkIsAdresseWeb"
        Me.CkIsAdresseWeb.Size = New System.Drawing.Size(136, 16)
        Me.CkIsAdresseWeb.TabIndex = 2
        Me.CkIsAdresseWeb.Text = "Adresse Web"
        '
        'CkIsObligatoire
        '
        Me.CkIsObligatoire.Location = New System.Drawing.Point(8, 38)
        Me.CkIsObligatoire.Name = "CkIsObligatoire"
        Me.CkIsObligatoire.Size = New System.Drawing.Size(136, 16)
        Me.CkIsObligatoire.TabIndex = 1
        Me.CkIsObligatoire.Text = "Obligatoire"
        '
        'CkStopSaisi
        '
        Me.CkStopSaisi.Location = New System.Drawing.Point(8, 16)
        Me.CkStopSaisi.Name = "CkStopSaisi"
        Me.CkStopSaisi.Size = New System.Drawing.Size(136, 16)
        Me.CkStopSaisi.TabIndex = 0
        Me.CkStopSaisi.Text = "Interdire la Saisi"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TxFiltrePlus)
        Me.GroupBox4.Controls.Add(Me.Label35)
        Me.GroupBox4.Controls.Add(Me.TxNiveauAutorisation)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.TxnNiveau2)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.TxnNiveau1)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(496, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(160, 112)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Niveau"
        '
        'TxNiveauAutorisation
        '
        Me.TxNiveauAutorisation.Items.AddRange(New Object() {"", "1", "2"})
        Me.TxNiveauAutorisation.Location = New System.Drawing.Point(72, 62)
        Me.TxNiveauAutorisation.Name = "TxNiveauAutorisation"
        Me.TxNiveauAutorisation.Size = New System.Drawing.Size(80, 21)
        Me.TxNiveauAutorisation.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 16)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Autorisation"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxnNiveau2
        '
        Me.TxnNiveau2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxnNiveau2.Location = New System.Drawing.Point(72, 39)
        Me.TxnNiveau2.Name = "TxnNiveau2"
        Me.TxnNiveau2.Size = New System.Drawing.Size(80, 20)
        Me.TxnNiveau2.TabIndex = 3
        Me.TxnNiveau2.Text = ""
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(6, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "nNiveau2"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxnNiveau1
        '
        Me.TxnNiveau1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxnNiveau1.Location = New System.Drawing.Point(72, 16)
        Me.TxnNiveau1.Name = "TxnNiveau1"
        Me.TxnNiveau1.Size = New System.Drawing.Size(80, 20)
        Me.TxnNiveau1.TabIndex = 1
        Me.TxnNiveau1.Text = ""
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "nNiveau1"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtCreer
        '
        Me.BtCreer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtCreer.Location = New System.Drawing.Point(792, 312)
        Me.BtCreer.Name = "BtCreer"
        Me.BtCreer.TabIndex = 10
        Me.BtCreer.Text = "Créer"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAnnuler.Location = New System.Drawing.Point(712, 312)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.TabIndex = 11
        Me.BtAnnuler.Text = "Annuler"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 16)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Table"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TxValDefaut)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.TxPrecision)
        Me.GroupBox5.Controls.Add(Me.TxTaille)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.TxType)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Location = New System.Drawing.Point(296, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(192, 112)
        Me.GroupBox5.TabIndex = 14
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Propriétés"
        '
        'TxValDefaut
        '
        Me.TxValDefaut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxValDefaut.Location = New System.Drawing.Point(64, 88)
        Me.TxValDefaut.Name = "TxValDefaut"
        Me.TxValDefaut.Size = New System.Drawing.Size(120, 20)
        Me.TxValDefaut.TabIndex = 7
        Me.TxValDefaut.Text = ""
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(8, 88)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 16)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "V. Defaut"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxPrecision
        '
        Me.TxPrecision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxPrecision.Location = New System.Drawing.Point(64, 63)
        Me.TxPrecision.Name = "TxPrecision"
        Me.TxPrecision.Size = New System.Drawing.Size(120, 20)
        Me.TxPrecision.TabIndex = 5
        Me.TxPrecision.Text = ""
        '
        'TxTaille
        '
        Me.TxTaille.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTaille.Location = New System.Drawing.Point(64, 40)
        Me.TxTaille.Name = "TxTaille"
        Me.TxTaille.Size = New System.Drawing.Size(120, 20)
        Me.TxTaille.TabIndex = 4
        Me.TxTaille.Text = ""
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(8, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 16)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Précision"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 42)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 16)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Taille"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxType
        '
        Me.TxType.Location = New System.Drawing.Point(64, 16)
        Me.TxType.Name = "TxType"
        Me.TxType.Size = New System.Drawing.Size(120, 21)
        Me.TxType.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Type"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxChamps
        '
        Me.TxChamps.Location = New System.Drawing.Point(72, 40)
        Me.TxChamps.Name = "TxChamps"
        Me.TxChamps.Size = New System.Drawing.Size(216, 21)
        Me.TxChamps.TabIndex = 15
        '
        'TxTable
        '
        Me.TxTable.Location = New System.Drawing.Point(72, 14)
        Me.TxTable.Name = "TxTable"
        Me.TxTable.Size = New System.Drawing.Size(216, 21)
        Me.TxTable.TabIndex = 16
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TxNbLigne)
        Me.GroupBox6.Controls.Add(Me.Label30)
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.TxTW)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.TxTH)
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Controls.Add(Me.TxTY)
        Me.GroupBox6.Controls.Add(Me.Label28)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.TxTX)
        Me.GroupBox6.Controls.Add(Me.Label23)
        Me.GroupBox6.Controls.Add(Me.TxLW)
        Me.GroupBox6.Controls.Add(Me.Label24)
        Me.GroupBox6.Controls.Add(Me.TxLH)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Controls.Add(Me.TxLY)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.TxLX)
        Me.GroupBox6.Location = New System.Drawing.Point(664, 8)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(208, 296)
        Me.GroupBox6.TabIndex = 17
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Disposition"
        '
        'TxNbLigne
        '
        Me.TxNbLigne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxNbLigne.Location = New System.Drawing.Point(80, 200)
        Me.TxNbLigne.Name = "TxNbLigne"
        Me.TxNbLigne.Size = New System.Drawing.Size(72, 20)
        Me.TxNbLigne.TabIndex = 23
        Me.TxNbLigne.Text = ""
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(16, 200)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(64, 16)
        Me.Label30.TabIndex = 22
        Me.Label30.Text = "Nb Ligne"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(108, 166)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(16, 16)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "L"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxTW
        '
        Me.TxTW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTW.Location = New System.Drawing.Point(124, 166)
        Me.TxTW.Name = "TxTW"
        Me.TxTW.Size = New System.Drawing.Size(72, 20)
        Me.TxTW.TabIndex = 20
        Me.TxTW.Text = ""
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(12, 166)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(16, 16)
        Me.Label26.TabIndex = 19
        Me.Label26.Text = "H"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxTH
        '
        Me.TxTH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTH.Location = New System.Drawing.Point(28, 166)
        Me.TxTH.Name = "TxTH"
        Me.TxTH.Size = New System.Drawing.Size(72, 20)
        Me.TxTH.TabIndex = 18
        Me.TxTH.Text = ""
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(108, 134)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(16, 16)
        Me.Label27.TabIndex = 17
        Me.Label27.Text = "Y"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxTY
        '
        Me.TxTY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTY.Location = New System.Drawing.Point(124, 134)
        Me.TxTY.Name = "TxTY"
        Me.TxTY.Size = New System.Drawing.Size(72, 20)
        Me.TxTY.TabIndex = 16
        Me.TxTY.Text = ""
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(12, 134)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(16, 16)
        Me.Label28.TabIndex = 15
        Me.Label28.Text = "X"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(12, 110)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(64, 16)
        Me.Label29.TabIndex = 14
        Me.Label29.Text = "TextBox"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxTX
        '
        Me.TxTX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTX.Location = New System.Drawing.Point(28, 134)
        Me.TxTX.Name = "TxTX"
        Me.TxTX.Size = New System.Drawing.Size(72, 20)
        Me.TxTX.TabIndex = 13
        Me.TxTX.Text = ""
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(104, 80)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 16)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "L"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxLW
        '
        Me.TxLW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLW.Location = New System.Drawing.Point(120, 80)
        Me.TxLW.Name = "TxLW"
        Me.TxLW.Size = New System.Drawing.Size(72, 20)
        Me.TxLW.TabIndex = 11
        Me.TxLW.Text = ""
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(8, 80)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(16, 16)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "H"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxLH
        '
        Me.TxLH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLH.Location = New System.Drawing.Point(24, 80)
        Me.TxLH.Name = "TxLH"
        Me.TxLH.Size = New System.Drawing.Size(72, 20)
        Me.TxLH.TabIndex = 9
        Me.TxLH.Text = ""
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(104, 48)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(16, 16)
        Me.Label22.TabIndex = 8
        Me.Label22.Text = "Y"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxLY
        '
        Me.TxLY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLY.Location = New System.Drawing.Point(120, 48)
        Me.TxLY.Name = "TxLY"
        Me.TxLY.Size = New System.Drawing.Size(72, 20)
        Me.TxLY.TabIndex = 7
        Me.TxLY.Text = ""
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(8, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 16)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "X"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 16)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Libelle"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxLX
        '
        Me.TxLX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLX.Location = New System.Drawing.Point(24, 48)
        Me.TxLX.Name = "TxLX"
        Me.TxLX.Size = New System.Drawing.Size(72, 20)
        Me.TxLX.TabIndex = 4
        Me.TxLX.Text = ""
        '
        'TxFiltrePlus
        '
        Me.TxFiltrePlus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxFiltrePlus.Location = New System.Drawing.Point(72, 88)
        Me.TxFiltrePlus.Name = "TxFiltrePlus"
        Me.TxFiltrePlus.Size = New System.Drawing.Size(80, 20)
        Me.TxFiltrePlus.TabIndex = 7
        Me.TxFiltrePlus.Text = ""
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(8, 90)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(56, 16)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Filtre"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrChamps
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(874, 342)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.TxTable)
        Me.Controls.Add(Me.TxChamps)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtCreer)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxLibelle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrChamps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Champs"
        Me.GroupBox1.ResumeLayout(False)
        Me.TabListeChoix.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Page"
    Private Sub FrChamps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ar As New ArrayList
        Dim ie As IEnumerator
        ie = SqlDbType.GetValues(GetType(SqlDbType)).GetEnumerator

        Do Until ie.MoveNext = False
            Me.TxType.Items.Add(CType(ie.Current, SqlDbType))
        Loop

        If Not Champs Is Nothing Then
            Me.TxTable.Enabled = False
            Me.TxChamps.Enabled = False
            AfficheChamps()
        Else
            Me.TxTable.Text = Table
        End If

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim dta As New SqlClient.SqlDataAdapter("Select * From dbo.sysobjects Where Type='U'", cn)
            Dim ds As New DataSet
            dta.Fill(ds)
            Dim rw As DataRow
            Me.TxTable.Sorted = True
            Me.TxTableListeChoix.Sorted = True
            Me.TxListeChoixMultipleTable.Sorted = True
            Me.TxTable.Items.Clear()
            Me.TxListeChoixMultipleTable.Items.Clear()
            Me.TxTableListeChoix.Items.Clear()
            For Each rw In ds.Tables(0).Rows
                Me.TxTable.Items.Add(rw.Item("name"))
                Me.TxTableListeChoix.Items.Add(rw.Item("name"))
                Me.TxListeChoixMultipleTable.Items.Add(rw.Item("name"))
            Next

            dta = New SqlClient.SqlDataAdapter("Select Distinct NomChoix From ListeChoix", cn)
            ds = New DataSet
            dta.Fill(ds)
            Me.TxListeChoix.Items.Clear()
            Me.TxListeChoixMultiple.Items.Clear()
            Me.TxListeChoix.Sorted = True
            Me.TxListeChoixMultiple.Sorted = True
            For Each rw In ds.Tables(0).Rows
                Me.TxListeChoix.Items.Add(rw.Item("NomChoix"))
                Me.TxListeChoixMultiple.Items.Add(rw.Item("NomChoix"))
            Next
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "Bouton"
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub

    Private Sub BtCreer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCreer.Click
        If Me.BtCreer.Text = "Modifier" Then
            ModifChamps()
        Else
            CreerChamps()
        End If
    End Sub
#End Region

#Region "CbTable"
    Private Sub CbTable_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxListeChoixMultipleTable.TextChanged, TxListeChoixMultipleTable.Click, TxTable.TextChanged, TxTable.Click, TxTableListeChoix.TextChanged, TxTableListeChoix.Click
        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim dta As New SqlClient.SqlDataAdapter("Select Top 1 * From " & CType(sender, Control).Text, cn)
            Dim ds As New DataSet
            dta.Fill(ds)
            Dim cl As DataColumn
            Select Case CType(sender, Control).Name
                Case "TxTable"
                    Me.TxChamps.Text = ""
                    Me.TxListeChoixChampsFiltre.Text = ""
                Case "TxListeChoixMultipleTable"
                    Me.TxListeChoixMultipleChamps.Text = ""
                Case "TxTableListeChoix"
                    Me.TxTableListeChoixSelectChamps.Text = ""
                    Me.TxTableListeChoixAfficheChamps.Text = ""
            End Select
            Me.TxChamps.Items.Clear()
            Me.TxListeChoixMultipleChamps.Items.Clear()
            Me.TxListeChoixChampsFiltre.Items.Clear()
            Me.TxTableListeChoixSelectChamps.Items.Clear()
            Me.TxTableListeChoixAfficheChamps.Items.Clear()
            Me.TxTableListeChoixTri.Items.Clear()
            For Each cl In ds.Tables(0).Columns
                Select Case CType(sender, Control).Name
                    Case "TxTable"
                        Me.TxChamps.Items.Add(cl.ColumnName)
                        Me.TxListeChoixChampsFiltre.Items.Add(cl.ColumnName)
                    Case "TxListeChoixMultipleTable"
                        Me.TxListeChoixMultipleChamps.Items.Add(cl.ColumnName)
                    Case "TxTableListeChoix"
                        Me.TxTableListeChoixSelectChamps.Items.Add(cl.ColumnName)
                        Me.TxTableListeChoixAfficheChamps.Items.Add(cl.ColumnName)
                        Me.TxTableListeChoixTri.Items.Add(cl.ColumnName)
                End Select
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub CheckCtl(ByVal ctl As Control, ByVal cl As DataColumn)
        Dim ctlTmp As Control
        For Each ctlTmp In ctl.Controls
            If cl.DataType Is GetType(Boolean) Then
                If ctlTmp.Name = "Ck" & cl.ColumnName Then
                    If cl.ColumnName = "NpAfficherFormulaire" Then
                        If Convert.ToBoolean(Champs.Data.Item(cl)) = True Then
                            CType(ctlTmp, CheckBox).Checked = False
                        Else
                            CType(ctlTmp, CheckBox).Checked = True
                        End If
                    Else
                        CType(ctlTmp, CheckBox).Checked = Convert.ToBoolean(Champs.Data.Item(cl))
                    End If
                End If
            Else
                If ctlTmp.Name = "Tx" & cl.ColumnName Then
                    If Convert.ToString(Champs.Data.Item(cl)) <> "" Then
                        If TypeOf ctlTmp.Parent Is TabPage Then
                            Me.TabListeChoix.SelectedTab = CType(ctlTmp.Parent, TabPage)
                        End If
                    End If
                    ctlTmp.Text = Convert.ToString(Champs.Data.Item(cl))
                End If
            End If
            CheckCtl(ctlTmp, cl)
        Next
    End Sub

    Private Sub AfficheChamps()
        If Not Champs Is Nothing Then
            Dim cl As DataColumn
            For Each cl In Champs.Data.Table.Columns
                CheckCtl(Me, cl)
            Next
            Me.BtCreer.Text = "Modifier"
        End If
    End Sub

    Private Sub ModifChamps()
        Try
            Dim cl As DataColumn
            For Each cl In Champs.Data.Table.Columns
                UpdatedCtl(Me, cl, Champs.Data)
            Next
            Dim DtA As New SqlClient.SqlDataAdapter("Select * From Niveau2 Where nNiveau1=" & Champs.nNiveau1 & " And nNiveau2=" & Champs.nNiveau2, cn)
            Dim CmdBuilder As New SqlClient.SqlCommandBuilder(DtA)
            CmdBuilder.QuotePrefix = "["
            CmdBuilder.QuoteSuffix = "]"
            DtA.UpdateCommand = CmdBuilder.GetUpdateCommand
            DtA.InsertCommand = CmdBuilder.GetInsertCommand
            DtA.DeleteCommand = CmdBuilder.GetDeleteCommand
            Dim rws(0) As DataRow
            rws.SetValue(Champs.Data, 0)
            DtA.Update(rws)

            VerifExistListeChoix()

            MessageBox.Show("Modification Réussi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub VerifExistListeChoix()
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If
        Dim strNomChoix As String = ""
        strNomChoix = Me.TxListeChoix.Text
        If strNomChoix.Length = 0 Then
            strNomChoix = Me.TxListeChoixMultiple.Text
        End If
        If strNomChoix.Length > 0 Then
            Dim Cmd As New SqlClient.SqlCommand("Select NomChoix From ListeChoix Where NomChoix='" & strNomChoix & "'", cn)
            If Cmd.ExecuteScalar Is Nothing Then
                Cmd.CommandText = "Insert Into ListeChoix (NomChoix,nOrdreValeur,Valeur) Values ('" & strNomChoix & "',1,'" & strNomChoix & "')"
                Cmd.ExecuteNonQuery()
            End If
        End If
    End Sub

    Private Sub CreerChamps()
        Try
            Dim nCle As String = "n" & Me.TxTable.Text
            If Me.TxTable.Text = "ABonReception" Or Me.TxTable.Text = "AFacture" Or Me.TxTable.Text = "VDevis" Or Me.TxTable.Text = "VBonCommande" Or Me.TxTable.Text = "VBonLivraison" Or Me.TxTable.Text = "VFacture" Then
                nCle = "nDevis"
            End If
            If Me.TxTable.Text = "Produit" Then
                nCle = "CodeProduit"
            End If

            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            If Me.TxnNiveau1.Text = "" Then Me.TxnNiveau1.Text = "0"

            'Dim cmd As New SqlClient.SqlCommand("Select Max(nNiveau2) From Niveau2 Where [Table]='" & Me.TxTable.Text & "'", cn)
            Dim cmd As New SqlClient.SqlCommand("Select Max(nNiveau2) From Niveau2", cn)
            Dim oResult As Object
            oResult = cmd.ExecuteScalar
            If oResult Is DBNull.Value Then
                cmd.CommandText = "Select Max(nNiveau2) From Niveau2"
                oResult = cmd.ExecuteScalar
            End If
            If oResult Is DBNull.Value Then oResult = 1
            Me.TxnNiveau2.Text = (Convert.ToInt32(oResult) + 1).ToString

            Dim strSqlTmp As String
            strSqlTmp = "Select * From " & Me.TxTable.Text & " Where " & nCle & " Is Null"
            'If Me.TxTable.Text = "Produit" Then
            '    strSqlTmp = "Select * From " & Me.TxTable.Text & " Where CodeProduit Is Null"
            'End If

            Dim DtA As New SqlClient.SqlDataAdapter(strSqlTmp, cn)

            Dim dsTmp As New DataSet
            DtA.Fill(dsTmp)
            If dsTmp.Tables(0).Columns.Contains(Me.TxChamps.Text) = False Then
                Dim strSql As String
                strSql = "Alter Table " & Me.TxTable.Text & vbCrLf
                strSql += "Add " & Me.TxChamps.Text & " "
                If Me.TxType.Text.Length > 0 Then
                    strSql += Me.TxType.Text
                End If
                If Me.TxTaille.Text.Length > 0 Then
                    strSql += " (" & Me.TxTaille.Text
                    If Me.TxPrecision.Text.Length > 0 Then
                        strSql += "," & Me.TxPrecision.Text
                    End If
                    strSql += ")"
                End If
                If Me.TxValDefaut.Text.Length > 0 Then
                    If IsNumeric(Me.TxValDefaut.Text) = True Then
                        strSql += " DEFAULT " & Me.TxValDefaut.Text & " "
                    Else
                        strSql += " DEFAULT '" & Me.TxValDefaut.Text & "' "
                    End If
                End If
                Dim cmdTmp As New SqlClient.SqlCommand(strSql, cn)
                cmdTmp.ExecuteNonQuery()
                If Me.TxValDefaut.Text.Length > 0 Then
                    If IsNumeric(Me.TxValDefaut.Text) = True Then
                        cmdTmp.CommandText = "Update " & Me.TxTable.Text & " Set " & Me.TxChamps.Text & "=" & Me.TxValDefaut.Text & ""
                    Else
                        cmdTmp.CommandText = "Update " & Me.TxTable.Text & " Set " & Me.TxChamps.Text & "='" & Me.TxValDefaut.Text & "'"
                    End If
                    cmdTmp.ExecuteScalar()
                End If
            End If

            DtA = New SqlClient.SqlDataAdapter("Select * From Niveau2 Where nNiveau1=" & Me.TxnNiveau1.Text & " And nNiveau2=" & Me.TxnNiveau2.Text, cn)

            Dim ds As New DataSet
            DtA.Fill(ds)

            Dim rw As DataRow
            rw = ds.Tables(0).NewRow
            ds.Tables(0).Rows.Add(rw)

            Dim cl As DataColumn
            For Each cl In ds.Tables(0).Columns
                UpdatedCtl(Me, cl, rw)
            Next

            Dim CmdBuilder As New SqlClient.SqlCommandBuilder(DtA)
            CmdBuilder.QuotePrefix = "["
            CmdBuilder.QuoteSuffix = "]"
            DtA.UpdateCommand = CmdBuilder.GetUpdateCommand
            DtA.InsertCommand = CmdBuilder.GetInsertCommand
            DtA.DeleteCommand = CmdBuilder.GetDeleteCommand
            'Dim rws(0) As DataRow
            'rws.SetValue(rw, 0)
            DtA.Update(ds.Tables(0))

            VerifExistListeChoix()

            MessageBox.Show("Création Réussi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub UpdatedCtl(ByVal ctl As Control, ByVal cl As DataColumn, ByRef rw As DataRow)
        Dim ctlTmp As Control
        For Each ctlTmp In ctl.Controls
            If cl.DataType Is GetType(Boolean) Then
                If ctlTmp.Name = "Ck" & cl.ColumnName Then
                    If cl.ColumnName = "NpAfficherFormulaire" Then
                        If Me.CkNpAfficherFormulaire.Checked = True Then
                            rw.Item(cl) = False
                        Else
                            rw.Item(cl) = True
                        End If
                    Else
                        rw.Item(cl) = CType(ctlTmp, CheckBox).Checked
                    End If
                End If
            Else
                If ctlTmp.Name = "Tx" & cl.ColumnName Then
                    If ctlTmp.Text <> "" Then
                        rw.Item(cl) = ctlTmp.Text
                    Else
                        rw.Item(cl) = DBNull.Value
                    End If
                End If
            End If
            UpdatedCtl(ctlTmp, cl, rw)
        Next
    End Sub
#End Region

End Class

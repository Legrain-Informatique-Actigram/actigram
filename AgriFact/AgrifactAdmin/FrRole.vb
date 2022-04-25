Public Class FrRole
    Inherits System.Windows.Forms.Form
    Private cn As SqlClient.SqlConnection
    Private Role As Role

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal connection As SqlClient.SqlConnection)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        cn = connection
    End Sub

    Public Sub New(ByVal connection As SqlClient.SqlConnection, ByVal MyRole As Role)
        Me.New(connection)
        Role = MyRole
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
    Friend WithEvents TxGroupe As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CkGAjt As System.Windows.Forms.CheckBox
    Friend WithEvents CkGModif As System.Windows.Forms.CheckBox
    Friend WithEvents CkGSuppr As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CkESuppr As System.Windows.Forms.CheckBox
    Friend WithEvents CkEModif As System.Windows.Forms.CheckBox
    Friend WithEvents CkEAjt As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CkPSuppr As System.Windows.Forms.CheckBox
    Friend WithEvents CkPModif As System.Windows.Forms.CheckBox
    Friend WithEvents CkPAjt As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CkDSuppr As System.Windows.Forms.CheckBox
    Friend WithEvents CkDModif As System.Windows.Forms.CheckBox
    Friend WithEvents CkDAjt As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CkLSuppr As System.Windows.Forms.CheckBox
    Friend WithEvents CkLModif As System.Windows.Forms.CheckBox
    Friend WithEvents CkLAjt As System.Windows.Forms.CheckBox
    Friend WithEvents BtCreer As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents nudNGroupe As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxGroupe = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CkGSuppr = New System.Windows.Forms.CheckBox
        Me.CkGModif = New System.Windows.Forms.CheckBox
        Me.CkGAjt = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CkESuppr = New System.Windows.Forms.CheckBox
        Me.CkEModif = New System.Windows.Forms.CheckBox
        Me.CkEAjt = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CkPSuppr = New System.Windows.Forms.CheckBox
        Me.CkPModif = New System.Windows.Forms.CheckBox
        Me.CkPAjt = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CkDSuppr = New System.Windows.Forms.CheckBox
        Me.CkDModif = New System.Windows.Forms.CheckBox
        Me.CkDAjt = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.CkLSuppr = New System.Windows.Forms.CheckBox
        Me.CkLModif = New System.Windows.Forms.CheckBox
        Me.CkLAjt = New System.Windows.Forms.CheckBox
        Me.BtCreer = New System.Windows.Forms.Button
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.nudNGroupe = New System.Windows.Forms.NumericUpDown
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nudNGroupe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "n Groupe"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxGroupe
        '
        Me.TxGroupe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxGroupe.Location = New System.Drawing.Point(72, 32)
        Me.TxGroupe.Name = "TxGroupe"
        Me.TxGroupe.Size = New System.Drawing.Size(168, 20)
        Me.TxGroupe.TabIndex = 3
        Me.TxGroupe.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Groupe"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CkGSuppr)
        Me.GroupBox1.Controls.Add(Me.CkGModif)
        Me.GroupBox1.Controls.Add(Me.CkGAjt)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 120)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fichier Client"
        '
        'CkGSuppr
        '
        Me.CkGSuppr.Location = New System.Drawing.Point(16, 88)
        Me.CkGSuppr.Name = "CkGSuppr"
        Me.CkGSuppr.TabIndex = 2
        Me.CkGSuppr.Text = "Suppression"
        '
        'CkGModif
        '
        Me.CkGModif.Location = New System.Drawing.Point(16, 56)
        Me.CkGModif.Name = "CkGModif"
        Me.CkGModif.TabIndex = 1
        Me.CkGModif.Text = "Modif"
        '
        'CkGAjt
        '
        Me.CkGAjt.Location = New System.Drawing.Point(16, 24)
        Me.CkGAjt.Name = "CkGAjt"
        Me.CkGAjt.TabIndex = 0
        Me.CkGAjt.Text = "Ajout"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CkESuppr)
        Me.GroupBox2.Controls.Add(Me.CkEModif)
        Me.GroupBox2.Controls.Add(Me.CkEAjt)
        Me.GroupBox2.Location = New System.Drawing.Point(144, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(128, 120)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Evenements"
        '
        'CkESuppr
        '
        Me.CkESuppr.Location = New System.Drawing.Point(16, 88)
        Me.CkESuppr.Name = "CkESuppr"
        Me.CkESuppr.TabIndex = 2
        Me.CkESuppr.Text = "Suppression"
        '
        'CkEModif
        '
        Me.CkEModif.Location = New System.Drawing.Point(16, 56)
        Me.CkEModif.Name = "CkEModif"
        Me.CkEModif.TabIndex = 1
        Me.CkEModif.Text = "Modif"
        '
        'CkEAjt
        '
        Me.CkEAjt.Location = New System.Drawing.Point(16, 24)
        Me.CkEAjt.Name = "CkEAjt"
        Me.CkEAjt.TabIndex = 0
        Me.CkEAjt.Text = "Ajout"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CkPSuppr)
        Me.GroupBox3.Controls.Add(Me.CkPModif)
        Me.GroupBox3.Controls.Add(Me.CkPAjt)
        Me.GroupBox3.Location = New System.Drawing.Point(280, 72)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(128, 120)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Produits"
        '
        'CkPSuppr
        '
        Me.CkPSuppr.Location = New System.Drawing.Point(16, 88)
        Me.CkPSuppr.Name = "CkPSuppr"
        Me.CkPSuppr.TabIndex = 2
        Me.CkPSuppr.Text = "Suppression"
        '
        'CkPModif
        '
        Me.CkPModif.Location = New System.Drawing.Point(16, 56)
        Me.CkPModif.Name = "CkPModif"
        Me.CkPModif.TabIndex = 1
        Me.CkPModif.Text = "Modif"
        '
        'CkPAjt
        '
        Me.CkPAjt.Location = New System.Drawing.Point(16, 24)
        Me.CkPAjt.Name = "CkPAjt"
        Me.CkPAjt.TabIndex = 0
        Me.CkPAjt.Text = "Ajout"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CkDSuppr)
        Me.GroupBox4.Controls.Add(Me.CkDModif)
        Me.GroupBox4.Controls.Add(Me.CkDAjt)
        Me.GroupBox4.Location = New System.Drawing.Point(416, 72)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(128, 120)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Devis"
        '
        'CkDSuppr
        '
        Me.CkDSuppr.Location = New System.Drawing.Point(16, 88)
        Me.CkDSuppr.Name = "CkDSuppr"
        Me.CkDSuppr.TabIndex = 2
        Me.CkDSuppr.Text = "Suppression"
        '
        'CkDModif
        '
        Me.CkDModif.Location = New System.Drawing.Point(16, 56)
        Me.CkDModif.Name = "CkDModif"
        Me.CkDModif.TabIndex = 1
        Me.CkDModif.Text = "Modif"
        '
        'CkDAjt
        '
        Me.CkDAjt.Location = New System.Drawing.Point(16, 24)
        Me.CkDAjt.Name = "CkDAjt"
        Me.CkDAjt.TabIndex = 0
        Me.CkDAjt.Text = "Ajout"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CkLSuppr)
        Me.GroupBox5.Controls.Add(Me.CkLModif)
        Me.GroupBox5.Controls.Add(Me.CkLAjt)
        Me.GroupBox5.Location = New System.Drawing.Point(552, 72)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(128, 120)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Listes"
        '
        'CkLSuppr
        '
        Me.CkLSuppr.Location = New System.Drawing.Point(16, 88)
        Me.CkLSuppr.Name = "CkLSuppr"
        Me.CkLSuppr.TabIndex = 2
        Me.CkLSuppr.Text = "Suppression"
        '
        'CkLModif
        '
        Me.CkLModif.Location = New System.Drawing.Point(16, 56)
        Me.CkLModif.Name = "CkLModif"
        Me.CkLModif.TabIndex = 1
        Me.CkLModif.Text = "Modif"
        '
        'CkLAjt
        '
        Me.CkLAjt.Location = New System.Drawing.Point(16, 24)
        Me.CkLAjt.Name = "CkLAjt"
        Me.CkLAjt.TabIndex = 0
        Me.CkLAjt.Text = "Ajout"
        '
        'BtCreer
        '
        Me.BtCreer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtCreer.Location = New System.Drawing.Point(592, 200)
        Me.BtCreer.Name = "BtCreer"
        Me.BtCreer.Size = New System.Drawing.Size(88, 24)
        Me.BtCreer.TabIndex = 9
        Me.BtCreer.Text = "Créer"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAnnuler.Location = New System.Drawing.Point(496, 200)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(88, 24)
        Me.BtAnnuler.TabIndex = 10
        Me.BtAnnuler.Text = "Annuler"
        '
        'nudNGroupe
        '
        Me.nudNGroupe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudNGroupe.Location = New System.Drawing.Point(72, 7)
        Me.nudNGroupe.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNGroupe.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNGroupe.Name = "nudNGroupe"
        Me.nudNGroupe.Size = New System.Drawing.Size(64, 20)
        Me.nudNGroupe.TabIndex = 11
        Me.nudNGroupe.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'FrRole
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 230)
        Me.Controls.Add(Me.nudNGroupe)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtCreer)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxGroupe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrRole"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorisations"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.nudNGroupe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub

    Private Sub BtCreer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtCreer.Click
        If Not Role Is Nothing Then
            ModifRole()
        Else
            CreerRole()
        End If
    End Sub

    Private Sub ModifRole()
        Try

            Role.ModifRole(cn, RemplirAutorisations)

            MessageBox.Show("Modification Terminée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub CreerRole()
        Try

            Dim newRole As New Role(Me.nudNGroupe.Value, Me.TxGroupe.Text)
            newRole.CreerRole(cn, RemplirAutorisations)

            MessageBox.Show("Nouveau Groupe Créé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Function RemplirAutorisations() As Hashtable
        Dim autorisations As New Hashtable
        For Each ctl1 As Control In Me.Controls
            For Each ctl As Control In ctl1.Controls
                If TypeOf ctl Is CheckBox Then
                    autorisations.Add(ctl.Name.Replace("Ck", ""), CType(ctl, CheckBox).Checked)
                End If
            Next
        Next
        Return autorisations
    End Function

    Private Sub FrRole_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nudNGroupe.Maximum = Decimal.MaxValue
        If Not Role Is Nothing Then
            Try
                Me.nudNGroupe.Enabled = False
                Me.nudNGroupe.Value = CDec(Role.nGroupe)
                Me.TxGroupe.Text = Role.Groupe
                Dim ctl1 As Control
                For Each ctl1 In Me.Controls
                    Dim ctl As Control
                    For Each ctl In ctl1.Controls
                        If TypeOf ctl Is CheckBox Then
                            CType(ctl, CheckBox).Checked = Convert.ToBoolean(Role.Data.Item(ctl.Name.Replace("Ck", "")))
                        End If
                    Next
                Next
                Me.BtCreer.Text = "Modifier"
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End If
    End Sub
End Class

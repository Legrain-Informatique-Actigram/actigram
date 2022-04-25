Public Class FrUtilisateur
    Inherits System.Windows.Forms.Form
    Private cn As SqlClient.SqlConnection
    Private User As Utilisateur

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
    Friend WithEvents TxNom As System.Windows.Forms.TextBox
    Friend WithEvents TxPrenom As System.Windows.Forms.TextBox
    Friend WithEvents TxLogin As System.Windows.Forms.TextBox
    Friend WithEvents TxPwd As System.Windows.Forms.TextBox
    Friend WithEvents BtCreer As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents CbGroupe As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxNom = New System.Windows.Forms.TextBox
        Me.TxPrenom = New System.Windows.Forms.TextBox
        Me.TxLogin = New System.Windows.Forms.TextBox
        Me.TxPwd = New System.Windows.Forms.TextBox
        Me.BtCreer = New System.Windows.Forms.Button
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.CbGroupe = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nom"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Prénom"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Identifiant"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Mot de Passe"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Groupe"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxNom
        '
        Me.TxNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxNom.Location = New System.Drawing.Point(120, 8)
        Me.TxNom.Name = "TxNom"
        Me.TxNom.Size = New System.Drawing.Size(144, 20)
        Me.TxNom.TabIndex = 5
        Me.TxNom.Text = ""
        '
        'TxPrenom
        '
        Me.TxPrenom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxPrenom.Location = New System.Drawing.Point(120, 34)
        Me.TxPrenom.Name = "TxPrenom"
        Me.TxPrenom.Size = New System.Drawing.Size(144, 20)
        Me.TxPrenom.TabIndex = 6
        Me.TxPrenom.Text = ""
        '
        'TxLogin
        '
        Me.TxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLogin.Location = New System.Drawing.Point(120, 60)
        Me.TxLogin.Name = "TxLogin"
        Me.TxLogin.Size = New System.Drawing.Size(144, 20)
        Me.TxLogin.TabIndex = 7
        Me.TxLogin.Text = ""
        '
        'TxPwd
        '
        Me.TxPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxPwd.Location = New System.Drawing.Point(120, 86)
        Me.TxPwd.Name = "TxPwd"
        Me.TxPwd.Size = New System.Drawing.Size(144, 20)
        Me.TxPwd.TabIndex = 8
        Me.TxPwd.Text = ""
        '
        'BtCreer
        '
        Me.BtCreer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtCreer.Location = New System.Drawing.Point(192, 168)
        Me.BtCreer.Name = "BtCreer"
        Me.BtCreer.TabIndex = 12
        Me.BtCreer.Text = "Créer"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAnnuler.Location = New System.Drawing.Point(104, 168)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.TabIndex = 13
        Me.BtAnnuler.Text = "Annuler"
        '
        'CbGroupe
        '
        Me.CbGroupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbGroupe.Location = New System.Drawing.Point(120, 114)
        Me.CbGroupe.Name = "CbGroupe"
        Me.CbGroupe.Size = New System.Drawing.Size(144, 21)
        Me.CbGroupe.TabIndex = 14
        '
        'FrUtilisateur
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(272, 198)
        Me.Controls.Add(Me.CbGroupe)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtCreer)
        Me.Controls.Add(Me.TxPwd)
        Me.Controls.Add(Me.TxLogin)
        Me.Controls.Add(Me.TxPrenom)
        Me.Controls.Add(Me.TxNom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrUtilisateur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Utilisateur"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal connection As SqlClient.SqlConnection)
        Me.new()
        cn = connection
        User = Nothing
    End Sub

    Public Sub New(ByVal connection As SqlClient.SqlConnection, ByVal MyUser As Utilisateur)
        Me.New(connection)
        User = MyUser
    End Sub

    Private Sub FrUtilisateur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Chargement de CbGroupe
            Dim conn As New SqlProxy(cn)
            Dim dr As SqlClient.SqlDataReader = conn.ExecuteReader("SELECT nGroupeAutorisation FROM Autorisations")
            With CbGroupe.Items
                .Clear()
                While dr.Read
                    .Add(dr("nGroupeAutorisation"))
                End While
                If .Count > 0 Then
                    CbGroupe.SelectedIndex = 0
                Else
                    MsgBox("Vous devez créer un groupe avant de créer un utilisateur.", MsgBoxStyle.Exclamation, "Attention")
                End If
            End With
            dr.Close()

            'Chargement de l'utilisateur
            If Not User Is Nothing Then
                Me.TxLogin.Enabled = False
                Me.TxNom.Enabled = False
                Me.TxPrenom.Enabled = False
                Me.TxPwd.Enabled = True

                Me.TxNom.Text = User.Nom
                Me.TxPrenom.Text = User.Prenom
                Me.TxLogin.Text = User.Login
                Me.TxPwd.Text = User.Pwd
                Me.CbGroupe.Text = User.nGroupe
                'Me.TxDepartement.Text = User.Departement

                Me.BtCreer.Text = "Modifier"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub CreerUtilisateur()
        Try
            User = New Utilisateur
            MajValeursObjet
            User.CreerUtilisateur(cn)
            MessageBox.Show("Creation réussie...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub ModifierUtilisateur()
        Try
            Dim oldPwd As String = User.Pwd
            MajValeursObjet()
            User.ModifierUtilisateur(cn, oldPwd)
            MessageBox.Show("Modification réussie...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub MajValeursObjet()
        With User
            .Nom = TxNom.Text
            .Prenom = TxPrenom.Text
            .Login = TxLogin.Text
            .Pwd = TxPwd.Text
            '.Departement = TxDepartement.Text
            .nGroupe = CStr(CbGroupe.SelectedItem)
        End With
    End Sub

    Private Sub BtCreer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCreer.Click
        If Not User Is Nothing Then
            ModifierUtilisateur()
        Else
            CreerUtilisateur()
        End If
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub
End Class

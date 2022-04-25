Public Class FrMain
    Inherits System.Windows.Forms.Form

    Private par As ExecParam

    Public Sub New(ByVal par As ExecParam)
        Me.New()
        Me.par = par
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxServeur As System.Windows.Forms.TextBox
    Friend WithEvents TxLogin As System.Windows.Forms.TextBox
    Friend WithEvents TxPwd As System.Windows.Forms.TextBox
    Friend WithEvents btUpdate As System.Windows.Forms.Button
    Friend WithEvents btSimulate As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cbBase As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrMain))
        Me.btUpdate = New System.Windows.Forms.Button
        Me.TxServeur = New System.Windows.Forms.TextBox
        Me.TxLogin = New System.Windows.Forms.TextBox
        Me.TxPwd = New System.Windows.Forms.TextBox
        Me.btSimulate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btClose = New System.Windows.Forms.Button
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.cbBase = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btUpdate
        '
        Me.btUpdate.Location = New System.Drawing.Point(96, 112)
        Me.btUpdate.Name = "btUpdate"
        Me.btUpdate.Size = New System.Drawing.Size(80, 23)
        Me.btUpdate.TabIndex = 0
        Me.btUpdate.Text = "Mettre à jour"
        '
        'TxServeur
        '
        Me.TxServeur.Location = New System.Drawing.Point(104, 8)
        Me.TxServeur.Name = "TxServeur"
        Me.TxServeur.Size = New System.Drawing.Size(160, 20)
        Me.TxServeur.TabIndex = 1
        Me.TxServeur.Text = "Serveur"
        '
        'TxLogin
        '
        Me.TxLogin.Location = New System.Drawing.Point(104, 56)
        Me.TxLogin.Name = "TxLogin"
        Me.TxLogin.Size = New System.Drawing.Size(160, 20)
        Me.TxLogin.TabIndex = 3
        Me.TxLogin.Text = "sa"
        '
        'TxPwd
        '
        Me.TxPwd.Location = New System.Drawing.Point(104, 80)
        Me.TxPwd.Name = "TxPwd"
        Me.TxPwd.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TxPwd.Size = New System.Drawing.Size(160, 20)
        Me.TxPwd.TabIndex = 4
        Me.TxPwd.Text = "Pwd"
        '
        'btSimulate
        '
        Me.btSimulate.Location = New System.Drawing.Point(8, 112)
        Me.btSimulate.Name = "btSimulate"
        Me.btSimulate.Size = New System.Drawing.Size(80, 23)
        Me.btSimulate.TabIndex = 5
        Me.btSimulate.Text = "Informations"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Serveur"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Base"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Identifiant"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Mot de passe"
        '
        'btClose
        '
        Me.btClose.Location = New System.Drawing.Point(184, 112)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(80, 23)
        Me.btClose.TabIndex = 10
        Me.btClose.Text = "Quitter"
        '
        'pgBar
        '
        Me.pgBar.Location = New System.Drawing.Point(8, 144)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(256, 16)
        Me.pgBar.TabIndex = 11
        '
        'cbBase
        '
        Me.cbBase.Location = New System.Drawing.Point(104, 32)
        Me.cbBase.Name = "cbBase"
        Me.cbBase.Size = New System.Drawing.Size(160, 21)
        Me.cbBase.TabIndex = 12
        Me.cbBase.Text = "Base"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(8, 168)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(48, 16)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Text = "lblStatus"
        '
        'FrMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(274, 192)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxPwd)
        Me.Controls.Add(Me.TxLogin)
        Me.Controls.Add(Me.TxServeur)
        Me.Controls.Add(Me.cbBase)
        Me.Controls.Add(Me.pgBar)
        Me.Controls.Add(Me.btClose)
        Me.Controls.Add(Me.btSimulate)
        Me.Controls.Add(Me.btUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DatabaseUpdate"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            VerifChamps()
            ActiverForm(False)
            Dim du As New DatabaseUpdate(TxServeur.Text, cbBase.Text, TxLogin.Text, TxPwd.Text)
            AddHandler du.ReportsProgress, AddressOf UpdateProgress
            du.Update()
            MsgBox("Mise à jour effectuée")
        Catch ex As Exception
            MsgBox("La mise à jour a echoué : " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            pgBar.Visible = False
            ActiverForm(True)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btSimulate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSimulate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            VerifChamps()
            Dim du As New DatabaseUpdate(TxServeur.Text, cbBase.Text, TxLogin.Text, TxPwd.Text)
            MsgBox(du.Simulate)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pgBar.Visible = False
        lblStatus.Visible = False
        ActiverForm(True)

        Me.TxServeur.Text = par.Serveur
        Me.cbBase.Text = par.Base
        Me.TxLogin.Text = par.Login
        Me.TxPwd.Text = ""

    End Sub

    Private Sub ActiverForm(ByVal activer As Boolean)
        Me.btClose.Enabled = activer
        Me.btSimulate.Enabled = activer
        Me.btUpdate.Enabled = activer
        Me.TxServeur.Enabled = activer
        Me.cbBase.Enabled = activer
        Me.TxLogin.Enabled = activer
        Me.TxPwd.Enabled = activer
        Application.DoEvents()
    End Sub

    Private Sub UpdateProgress(ByVal sender As Object, ByVal e As ProgressEventArgs)
        With lblStatus
            If Not .Visible Then .Visible = True
            .Text = e.status
        End With
        With pgBar
            If Not .Visible Then .Visible = True
            .Maximum = e.max
            .Value = e.progress
        End With
        Application.DoEvents()
    End Sub

    Private Sub cbBase_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBase.DropDown
        If cbBase.Items.Count = 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim cn As New SqlProxy(SqlProxy.GetConnectionString(TxServeur.Text, "master", TxLogin.Text, TxPwd.Text))
                Dim dr As SqlClient.SqlDataReader = cn.ExecuteReader("select name from sysdatabases where dbid>4 order by name")
                While dr.Read
                    cbBase.Items.Add(dr("name"))
                End While
                dr.Close()
                cn.Close()
            Catch ex As SqlClient.SqlException
                MsgBox(ex.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub TxServeur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxServeur.TextChanged
        cbBase.Items.Clear()
    End Sub

    Private Sub VerifChamps()
        If TxServeur.Text = "" Then Throw New Exception("Le serveur n'est pas renseigné.")
        If cbBase.Text = "" Then Throw New Exception("La base n'est pas renseignée.")
        'If TxLogin.Text = "" Then Throw New Exception("L'identifiant n'est pas renseigné.")
    End Sub
End Class

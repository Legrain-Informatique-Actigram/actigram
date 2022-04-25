Public Class FrMain
    Inherits System.Windows.Forms.Form

    Private par As ExecParam

#Region "Constructeurs"
    Public Sub New(ByVal par As ExecParam)
        Me.New()
        Me.par = par
    End Sub
#End Region

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
    Friend WithEvents btUpdate As System.Windows.Forms.Button
    Friend WithEvents btSimulate As System.Windows.Forms.Button
    Friend WithEvents btClose As System.Windows.Forms.Button
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents TxCheminBase As System.Windows.Forms.TextBox
    Friend WithEvents BtRunScript As System.Windows.Forms.Button
    Friend WithEvents BtBrowse As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrMain))
        Me.btUpdate = New System.Windows.Forms.Button
        Me.TxCheminBase = New System.Windows.Forms.TextBox
        Me.btSimulate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btClose = New System.Windows.Forms.Button
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.lblStatus = New System.Windows.Forms.Label
        Me.BtBrowse = New System.Windows.Forms.Button
        Me.BtRunScript = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btUpdate
        '
        Me.btUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btUpdate.Location = New System.Drawing.Point(136, 40)
        Me.btUpdate.Name = "btUpdate"
        Me.btUpdate.Size = New System.Drawing.Size(80, 23)
        Me.btUpdate.TabIndex = 0
        Me.btUpdate.Text = "Mettre à jour"
        '
        'TxCheminBase
        '
        Me.TxCheminBase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxCheminBase.Location = New System.Drawing.Point(48, 8)
        Me.TxCheminBase.Name = "TxCheminBase"
        Me.TxCheminBase.Size = New System.Drawing.Size(256, 20)
        Me.TxCheminBase.TabIndex = 1
        Me.TxCheminBase.Text = "CheminBase"
        '
        'btSimulate
        '
        Me.btSimulate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btSimulate.Location = New System.Drawing.Point(48, 40)
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
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Base"
        '
        'btClose
        '
        Me.btClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btClose.Location = New System.Drawing.Point(224, 40)
        Me.btClose.Name = "btClose"
        Me.btClose.Size = New System.Drawing.Size(80, 23)
        Me.btClose.TabIndex = 10
        Me.btClose.Text = "Quitter"
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.Location = New System.Drawing.Point(8, 72)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(328, 16)
        Me.pgBar.TabIndex = 11
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(8, 96)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(47, 13)
        Me.lblStatus.TabIndex = 13
        Me.lblStatus.Text = "lblStatus"
        '
        'BtBrowse
        '
        Me.BtBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtBrowse.Location = New System.Drawing.Point(312, 8)
        Me.BtBrowse.Name = "BtBrowse"
        Me.BtBrowse.Size = New System.Drawing.Size(24, 20)
        Me.BtBrowse.TabIndex = 14
        Me.BtBrowse.Text = "..."
        '
        'BtRunScript
        '
        Me.BtRunScript.Location = New System.Drawing.Point(312, 40)
        Me.BtRunScript.Name = "BtRunScript"
        Me.BtRunScript.Size = New System.Drawing.Size(24, 23)
        Me.BtRunScript.TabIndex = 15
        Me.BtRunScript.Text = "..."
        Me.BtRunScript.UseVisualStyleBackColor = True
        '
        'FrMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(346, 120)
        Me.Controls.Add(Me.BtRunScript)
        Me.Controls.Add(Me.BtBrowse)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxCheminBase)
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
        Me.PerformLayout()

    End Sub

#End Region

#Region "Form"
    Private Sub FrMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pgBar.Visible = False
        lblStatus.Visible = False
        ActiverForm(True)

        If par IsNot Nothing Then
            Me.TxCheminBase.Text = par.CheminBase
        Else
            Me.TxCheminBase.Text = ""
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub btClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClose.Click
        Me.Close()
    End Sub

    Private Sub btUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btUpdate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            VerifChamps()
            ActiverForm(False)
            Dim du As New DatabaseUpdate(TxCheminBase.Text)
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
            Dim du As New DatabaseUpdate(TxCheminBase.Text)
            MsgBox(du.Simulate)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click
        With New OpenFileDialog
            .Filter = "*.mdb|*.mdb"
            If .ShowDialog = DialogResult.OK Then
                TxCheminBase.Text = .FileName
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtRunScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRunScript.Click
        Dim fichier As String
        Using dlg As New OpenFileDialog
            dlg.Filter = "*.sql|*.sql"
            If dlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            fichier = dlg.FileName
        End Using
        If MsgBox(String.Format("Voulez-vous executer le script '{0}' sur la base sélectionnée ?", fichier), MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        RunScript(fichier)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub RunScript(ByVal fichier As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            VerifChamps()
            ActiverForm(False)
            Dim du As New DatabaseUpdate(TxCheminBase.Text)
            AddHandler du.ReportsProgress, AddressOf UpdateProgress
            du.RunScript(fichier)
            MsgBox("Execution effectuée")
        Catch ex As Exception
            MsgBox("Execution  echouée : " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            pgBar.Visible = False
            ActiverForm(True)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ActiverForm(ByVal activer As Boolean)
        Me.btClose.Enabled = activer
        Me.btSimulate.Enabled = activer
        Me.btUpdate.Enabled = activer
        Me.TxCheminBase.Enabled = activer
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

    Private Sub VerifChamps()
        If TxCheminBase.Text = "" Then Throw New Exception("La base n'est pas renseigné.")
    End Sub
#End Region
    
End Class

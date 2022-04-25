Imports LicenceTraca.Securite
Imports LicenceTraca.Securite.Activation

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
    Friend WithEvents btToString As System.Windows.Forms.Button
    Friend WithEvents TxCodeUtil As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDateValid As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtParse As System.Windows.Forms.Button
    Friend WithEvents lbValid As System.Windows.Forms.Label
    Friend WithEvents lbHash As System.Windows.Forms.Label
    Friend WithEvents BtEncryptedKey As System.Windows.Forms.Button
    Friend WithEvents SaisieCle1 As LicenceTraca.Securite.Activation.SaisieCle
    Friend WithEvents BtCopier As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkOptionIdentWindows As System.Windows.Forms.CheckBox
    Friend WithEvents lbNbMois As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btToString = New System.Windows.Forms.Button
        Me.TxCodeUtil = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpDateValid = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkOptionIdentWindows = New System.Windows.Forms.CheckBox
        Me.BtParse = New System.Windows.Forms.Button
        Me.lbValid = New System.Windows.Forms.Label
        Me.lbHash = New System.Windows.Forms.Label
        Me.BtEncryptedKey = New System.Windows.Forms.Button
        Me.BtCopier = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbNbMois = New System.Windows.Forms.Label
        Me.SaisieCle1 = New LicenceTraca.Securite.Activation.SaisieCle
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btToString
        '
        Me.btToString.Location = New System.Drawing.Point(16, 224)
        Me.btToString.Name = "btToString"
        Me.btToString.Size = New System.Drawing.Size(96, 23)
        Me.btToString.TabIndex = 0
        Me.btToString.Text = "Générer"
        '
        'TxCodeUtil
        '
        Me.TxCodeUtil.Location = New System.Drawing.Point(112, 8)
        Me.TxCodeUtil.Name = "TxCodeUtil"
        Me.TxCodeUtil.Size = New System.Drawing.Size(100, 20)
        Me.TxCodeUtil.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Code util"
        '
        'dtpDateValid
        '
        Me.dtpDateValid.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateValid.Location = New System.Drawing.Point(112, 32)
        Me.dtpDateValid.Name = "dtpDateValid"
        Me.dtpDateValid.Size = New System.Drawing.Size(104, 20)
        Me.dtpDateValid.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 23)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date Validité"
        '
        'chkOptionIdentWindows
        '
        Me.chkOptionIdentWindows.Location = New System.Drawing.Point(8, 16)
        Me.chkOptionIdentWindows.Name = "chkOptionIdentWindows"
        Me.chkOptionIdentWindows.Size = New System.Drawing.Size(136, 24)
        Me.chkOptionIdentWindows.TabIndex = 6
        Me.chkOptionIdentWindows.Text = "Identification Windows"
        '
        'BtParse
        '
        Me.BtParse.Location = New System.Drawing.Point(16, 256)
        Me.BtParse.Name = "BtParse"
        Me.BtParse.Size = New System.Drawing.Size(96, 23)
        Me.BtParse.TabIndex = 10
        Me.BtParse.Text = "Analyser"
        '
        'lbValid
        '
        Me.lbValid.AutoSize = True
        Me.lbValid.Location = New System.Drawing.Point(120, 256)
        Me.lbValid.Name = "lbValid"
        Me.lbValid.Size = New System.Drawing.Size(38, 13)
        Me.lbValid.TabIndex = 11
        Me.lbValid.Text = "lbValid"
        '
        'lbHash
        '
        Me.lbHash.Location = New System.Drawing.Point(216, 8)
        Me.lbHash.Name = "lbHash"
        Me.lbHash.Size = New System.Drawing.Size(100, 16)
        Me.lbHash.TabIndex = 13
        Me.lbHash.Text = "lbHash"
        '
        'BtEncryptedKey
        '
        Me.BtEncryptedKey.Location = New System.Drawing.Point(368, 8)
        Me.BtEncryptedKey.Name = "BtEncryptedKey"
        Me.BtEncryptedKey.Size = New System.Drawing.Size(96, 23)
        Me.BtEncryptedKey.TabIndex = 14
        Me.BtEncryptedKey.Text = "Generate Keys"
        '
        'BtCopier
        '
        Me.BtCopier.Location = New System.Drawing.Point(312, 224)
        Me.BtCopier.Name = "BtCopier"
        Me.BtCopier.Size = New System.Drawing.Size(56, 23)
        Me.BtCopier.TabIndex = 16
        Me.BtCopier.Text = "Copier"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkOptionIdentWindows)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 152)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'lbNbMois
        '
        Me.lbNbMois.Location = New System.Drawing.Point(224, 32)
        Me.lbNbMois.Name = "lbNbMois"
        Me.lbNbMois.Size = New System.Drawing.Size(100, 16)
        Me.lbNbMois.TabIndex = 19
        Me.lbNbMois.Text = "lbNbMois"
        '
        'SaisieCle1
        '
        Me.SaisieCle1.Cle = CType(0, Long)
        Me.SaisieCle1.CleText = ""
        Me.SaisieCle1.Location = New System.Drawing.Point(112, 216)
        Me.SaisieCle1.Name = "SaisieCle1"
        Me.SaisieCle1.Size = New System.Drawing.Size(200, 40)
        Me.SaisieCle1.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(475, 294)
        Me.Controls.Add(Me.lbNbMois)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtCopier)
        Me.Controls.Add(Me.BtEncryptedKey)
        Me.Controls.Add(Me.lbHash)
        Me.Controls.Add(Me.lbValid)
        Me.Controls.Add(Me.TxCodeUtil)
        Me.Controls.Add(Me.BtParse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpDateValid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btToString)
        Me.Controls.Add(Me.SaisieCle1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LicenceTraca"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btToString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btToString.Click
        Dim cl As New Cle
        With cl
            .CodeUtilisateur = TxCodeUtil.Text.ToUpper
            .DateValidite = dtpDateValid.Value
            .SetOption(Cle.OptionsModules.IdentWindowsLogin, chkOptionIdentWindows.Checked)
            Me.SaisieCle1.Cle = XorEncryption.EnCrypt(.ToLong)
            Me.lbHash.Text = .CodeUtilisateurHash.ToString("X8")
            Me.lbNbMois.Text = DateToInt(.DateValidite).ToString("X4")
        End With
    End Sub

    Private Sub BtParse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtParse.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim cl As Cle = Cle.Parse(XorEncryption.EnCrypt(Me.SaisieCle1.Cle))
            With cl
                Me.lbHash.Text = .CodeUtilisateurHash.ToString("X8")
                dtpDateValid.Value = .DateValidite
                Me.lbNbMois.Text = DateToInt(.DateValidite).ToString("X4")
                chkOptionIdentWindows.Checked = .HasOption(Cle.OptionsModules.IdentWindowsLogin)
                If .IsValid(Me.TxCodeUtil.Text.Trim) Then
                    Me.lbValid.Text = "Cette clé est valide"
                    Me.lbValid.ForeColor = Color.Black
                Else
                    Me.lbValid.ForeColor = Color.Red
                    If Not .IsCodeValid(Me.TxCodeUtil.Text.Trim) Then
                        Me.lbValid.Text = "Code Utilisateur invalide"
                    ElseIf .DateValidite.Date < Now.Date Then
                        Me.lbValid.Text = "Clé expirée"
                    Else
                        Me.lbValid.Text = "Cette clé est invalide"
                    End If
                End If
            End With
        Catch ex As Exception
            Debug.WriteLine(ex.ToString)
            Me.lbValid.ForeColor = Color.Red
            Me.lbValid.Text = "Cette clé est invalide"
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    'Private Sub BtEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEncrypt.Click
    '    Dim cle As Long = Long.Parse(TxCle.Text, Globalization.NumberStyles.HexNumber)
    '    Dim cipher As Long = XorEncryption.EnCrypt(cle)
    '    TxCle.Text = cipher.ToString("X")
    '    Debug.WriteLine("Test : " & (cle = XorEncryption.EnCrypt(cipher)))
    'End Sub

    'Private Sub BtEncryptedKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEncryptedKey.Click
    '    Dim s As String = XorEncryption.GetEncryptedKey
    '    Debug.WriteLine(s)
    '    Me.TxCle.Text = s
    'End Sub

    Private Sub BtGenerateKeys_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEncryptedKey.Click
        Dim msg As String = "Attention, vous allez générer des nouvelles clés de cryptage." & vbCrLf & _
                "Cela va casser la compatibilité avec l'application et les licences existantes." & vbCrLf & _
                "Continuer ?"
        If MsgBox(msg, MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Ok Then
            Dim dlg As New SaveFileDialog
            dlg.DefaultExt = "priv"
            'dlg.FileName = txtCheminPrivKey.Text
            If dlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            Dim filename As String = dlg.FileName
            Dim privateFile As String = filename
            Dim pubFile As String = IO.Path.GetFileNameWithoutExtension(filename) & ".pub"

            Me.Cursor = Cursors.WaitCursor
            Try
                RsaEncryption.GenerateKeyFiles(pubFile, privateFile)
                MsgBox("Clés générées", MsgBoxStyle.Information)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim k As String = "1794857639824765"
        Debug.Print(Securite.RsaEncryption.RsaEncrypt(k))

        lbHash.Text = ""
        lbNbMois.Text = ""
        lbValid.Text = ""
        BtCopier.Enabled = False
        Me.dtpDateValid.Value = Now.AddYears(5)
    End Sub

    Private Sub BtCopier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCopier.Click
        Clipboard.SetDataObject(Me.SaisieCle1.CleTextDecorated)
    End Sub

    Private Sub SaisieCle1_CleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaisieCle1.CleChanged
        BtCopier.Enabled = (SaisieCle1.CleText.Length = 16)
    End Sub
End Class

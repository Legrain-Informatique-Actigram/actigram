Public Class FrCompte
    Inherits GRC.FrBase
    Dim Param As ParametresCompte
    Dim Filtre As String = ""
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Dim BdM As BindingManagerBase

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByRef mesParam As ParametresCompte, ByRef monBdM As BindingManagerBase, ByVal monFiltre As String)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Param = mesParam
        Filtre = monFiltre
        BdM = monBdM
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
    Friend WithEvents TxNCompte As System.Windows.Forms.TextBox
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents TxLibCompte As System.Windows.Forms.TextBox
    Friend WithEvents TxnActivite As System.Windows.Forms.TextBox
    Friend WithEvents TxUnite1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxUnite2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrCompte))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxNCompte = New System.Windows.Forms.TextBox
        Me.TxLibCompte = New System.Windows.Forms.TextBox
        Me.TxnActivite = New System.Windows.Forms.TextBox
        Me.BtOk = New System.Windows.Forms.Button
        Me.TxUnite1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxUnite2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° Compte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libelle"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Activité Associée"
        '
        'TxNCompte
        '
        Me.TxNCompte.Location = New System.Drawing.Point(107, 13)
        Me.TxNCompte.MaxLength = 8
        Me.TxNCompte.Name = "TxNCompte"
        Me.TxNCompte.Size = New System.Drawing.Size(188, 20)
        Me.TxNCompte.TabIndex = 1
        '
        'TxLibCompte
        '
        Me.TxLibCompte.Location = New System.Drawing.Point(107, 39)
        Me.TxLibCompte.Name = "TxLibCompte"
        Me.TxLibCompte.Size = New System.Drawing.Size(188, 20)
        Me.TxLibCompte.TabIndex = 3
        '
        'TxnActivite
        '
        Me.TxnActivite.Location = New System.Drawing.Point(107, 117)
        Me.TxnActivite.MaxLength = 4
        Me.TxnActivite.Name = "TxnActivite"
        Me.TxnActivite.Size = New System.Drawing.Size(188, 20)
        Me.TxnActivite.TabIndex = 9
        '
        'BtOk
        '
        Me.BtOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOk.Location = New System.Drawing.Point(140, 10)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(75, 23)
        Me.BtOk.TabIndex = 0
        Me.BtOk.Text = "OK"
        '
        'TxUnite1
        '
        Me.TxUnite1.Location = New System.Drawing.Point(107, 65)
        Me.TxUnite1.Name = "TxUnite1"
        Me.TxUnite1.Size = New System.Drawing.Size(188, 20)
        Me.TxUnite1.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Unité 1"
        '
        'TxUnite2
        '
        Me.TxUnite2.Location = New System.Drawing.Point(107, 91)
        Me.TxUnite2.Name = "TxUnite2"
        Me.TxUnite2.Size = New System.Drawing.Size(188, 20)
        Me.TxUnite2.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Unité 2"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(220, 10)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 1
        Me.BtAnnuler.Text = "Annuler"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.TxUnite2)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.TxNCompte)
        Me.GradientPanel1.Controls.Add(Me.TxUnite1)
        Me.GradientPanel1.Controls.Add(Me.TxLibCompte)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.TxnActivite)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(307, 149)
        Me.GradientPanel1.TabIndex = 0
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtOk)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 149)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(307, 45)
        Me.GradientPanel2.TabIndex = 1
        '
        'FrCompte
        '
        Me.AcceptButton = Me.BtOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(307, 194)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrCompte"
        Me.Text = "Nouveau Compte"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        With Param
            Me.TxNCompte.Text = .nCompte
            Me.TxLibCompte.Text = .LibCompte
            Me.TxnActivite.Text = .NActivite
            Me.TxUnite1.Text = .U1
            Me.TxUnite2.Text = .U2
        End With
    End Sub

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        With Param
            .nCompte = Me.TxNCompte.Text
            .LibCompte = Me.TxLibCompte.Text
            .NActivite = Me.TxnActivite.Text
            .U1 = Me.TxUnite1.Text
            .U2 = Me.TxUnite2.Text
        End With

        If Me.BdM.Position <> -1 Then
            Dim rwv As DataRowView = CType(BdM.Current, DataRowView)

            Dim dsTmp As DataSet = rwv.Row.Table.DataSet.Clone
            Try
                'Test de validité du compte : on essaie d'insérer dans un dataset et on voie ce que ca donne...
            Dim rw As DataRow = dsTmp.Tables("Comptes").NewRow
            With rw
                .Item("CDossier") = Compta.NDossierCompta
                .Item("CCpt") = Param.nCompte
                .Item("CLib") = Param.LibCompte
                .Item("CU1") = Param.U1
                .Item("CU2") = Param.U2
            End With
            dsTmp.Tables("Comptes").Rows.Add(rw)
            Catch ex As Exception
            End Try

            Dim strFiltre As String = "CDossier='" & Compta.NDossierCompta & "'"
            If Filtre.Length > 0 Then strFiltre &= " And " & Filtre

            If dsTmp.Tables("Comptes").Select(strFiltre).Length = 0 Then
                MessageBox.Show("Ce N° de Compte n'est pas autorisé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class

Public Class ParametresCompte
    Public nCompte As String = ""
    Public LibCompte As String = ""
    Public U1 As String = ""
    Public U2 As String = ""
    Public NActivite As String = ""
End Class
Public Class FrActivite
    Inherits GRC.FrBase
    Dim Param As ParametresActivite
    Dim Filtre As String = ""
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Dim BdM As BindingManagerBase

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByRef mesParam As ParametresActivite, ByRef monBdM As BindingManagerBase, ByVal monFiltre As String)
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
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxNActivite As System.Windows.Forms.TextBox
    Friend WithEvents TxLibActivite As System.Windows.Forms.TextBox
    Friend WithEvents TxQuantite As System.Windows.Forms.TextBox
    Friend WithEvents TxUnite As System.Windows.Forms.TextBox
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrActivite))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxNActivite = New System.Windows.Forms.TextBox
        Me.TxLibActivite = New System.Windows.Forms.TextBox
        Me.BtOk = New System.Windows.Forms.Button
        Me.TxQuantite = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxUnite = New System.Windows.Forms.TextBox
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
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° Activité"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Libelle"
        '
        'TxNActivite
        '
        Me.TxNActivite.Location = New System.Drawing.Point(75, 12)
        Me.TxNActivite.MaxLength = 8
        Me.TxNActivite.Name = "TxNActivite"
        Me.TxNActivite.Size = New System.Drawing.Size(185, 20)
        Me.TxNActivite.TabIndex = 1
        '
        'TxLibActivite
        '
        Me.TxLibActivite.Location = New System.Drawing.Point(75, 38)
        Me.TxLibActivite.Name = "TxLibActivite"
        Me.TxLibActivite.Size = New System.Drawing.Size(185, 20)
        Me.TxLibActivite.TabIndex = 3
        '
        'BtOk
        '
        Me.BtOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOk.Location = New System.Drawing.Point(105, 10)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(75, 23)
        Me.BtOk.TabIndex = 0
        Me.BtOk.Text = "OK"
        '
        'TxQuantite
        '
        Me.TxQuantite.Location = New System.Drawing.Point(75, 64)
        Me.TxQuantite.Name = "TxQuantite"
        Me.TxQuantite.Size = New System.Drawing.Size(185, 20)
        Me.TxQuantite.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Quantité"
        '
        'TxUnite
        '
        Me.TxUnite.Location = New System.Drawing.Point(75, 90)
        Me.TxUnite.Name = "TxUnite"
        Me.TxUnite.Size = New System.Drawing.Size(185, 20)
        Me.TxUnite.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Unité"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(185, 10)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 1
        Me.BtAnnuler.Text = "Annuler"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.TxUnite)
        Me.GradientPanel1.Controls.Add(Me.TxNActivite)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.TxLibActivite)
        Me.GradientPanel1.Controls.Add(Me.TxQuantite)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(272, 123)
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
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 123)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(272, 45)
        Me.GradientPanel2.TabIndex = 1
        '
        'FrActivite
        '
        Me.AcceptButton = Me.BtOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(272, 168)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrActivite"
        Me.Text = "Nouvelle Activité"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.TxNActivite.Text = Param.nActivite
        Me.TxLibActivite.Text = Param.LibActivite
        Me.TxQuantite.Text = Param.Qte1
        Me.TxUnite.Text = Param.U1
    End Sub

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        Param.nActivite = Me.TxNActivite.Text
        Param.LibActivite = Me.TxLibActivite.Text
        Param.Qte1 = Me.TxQuantite.Text
        Param.U1 = Me.TxUnite.Text

        If Me.BdM.Position <> -1 Then
            Dim dsTmp As New DataSet
            Dim rwv As DataRowView = CType(BdM.Current, DataRowView)
            dsTmp = rwv.Row.Table.DataSet.Clone
            Dim rw As DataRow = dsTmp.Tables("Activites").NewRow
            rw.Item("ADossier") = Compta.NDossierCompta
            rw.Item("AActi") = Param.nActivite
            rw.Item("ALib") = Param.LibActivite
            If Param.Qte1 <> "" Then
                rw.Item("AQte") = Param.Qte1
            End If
            If Param.U1 <> "" Then
                rw.Item("AUnit") = Param.U1
            End If
            dsTmp.Tables("Activites").Rows.Add(rw)

            Dim strFiltre As String = "ADossier='" & Compta.NDossierCompta & "'"
            If Filtre.Length > 0 Then
                strFiltre += " And " & Filtre
            End If
            Dim rws() As DataRow = dsTmp.Tables("Activites").Select(strFiltre)
            If rws.GetUpperBound(0) < 0 Then
                MessageBox.Show("Ce N° d'Activité n'est pas autorisé", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
        Me.Dispose()
    End Sub
End Class

Public Class ParametresActivite
    Public nActivite As String = ""
    Public LibActivite As String = ""
    Public U1 As String = ""
    Public Qte1 As String = ""
End Class
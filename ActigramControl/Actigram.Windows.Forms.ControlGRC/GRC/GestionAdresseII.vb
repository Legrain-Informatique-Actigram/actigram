Imports Actigram.Windows.Forms

Public Class GestionAdresseII
    Inherits System.Windows.Forms.UserControl
    Friend WithEvents TxAdresse As System.Windows.Forms.TextBox
    Friend WithEvents TxCodePostal As System.Windows.Forms.TextBox
    Friend WithEvents TxVille As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Private _db As CurrencyManager
    Friend WithEvents BtVille As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtImprimer As Ascend.Windows.Forms.GradientNavigationButton
    Public ConnectionString As String

#Region "Init"
    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du UserControl1 pour nettoyer la liste des composants.
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
    Friend WithEvents TxSuffixe As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbPays As System.Windows.Forms.ComboBox
    Private _Livraison As Boolean = False
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GestionAdresseII))
        Me.TxAdresse = New System.Windows.Forms.TextBox
        Me.TxCodePostal = New System.Windows.Forms.TextBox
        Me.TxVille = New System.Windows.Forms.TextBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TxSuffixe = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CbPays = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtImprimer = New Ascend.Windows.Forms.GradientNavigationButton
        Me.BtVille = New Ascend.Windows.Forms.GradientNavigationButton
        Me.SuspendLayout()
        '
        'TxAdresse
        '
        Me.TxAdresse.AcceptsReturn = True
        Me.TxAdresse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxAdresse.Location = New System.Drawing.Point(0, 0)
        Me.TxAdresse.Multiline = True
        Me.TxAdresse.Name = "TxAdresse"
        Me.TxAdresse.Size = New System.Drawing.Size(258, 72)
        Me.TxAdresse.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.TxAdresse, "Adresse")
        '
        'TxCodePostal
        '
        Me.TxCodePostal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxCodePostal.Location = New System.Drawing.Point(0, 72)
        Me.TxCodePostal.Name = "TxCodePostal"
        Me.TxCodePostal.Size = New System.Drawing.Size(64, 20)
        Me.TxCodePostal.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.TxCodePostal, "Code Postal")
        '
        'TxVille
        '
        Me.TxVille.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxVille.Location = New System.Drawing.Point(64, 72)
        Me.TxVille.Name = "TxVille"
        Me.TxVille.Size = New System.Drawing.Size(98, 20)
        Me.TxVille.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.TxVille, "Ville")
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'TxSuffixe
        '
        Me.TxSuffixe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxSuffixe.Location = New System.Drawing.Point(185, 72)
        Me.TxSuffixe.Name = "TxSuffixe"
        Me.TxSuffixe.Size = New System.Drawing.Size(73, 20)
        Me.TxSuffixe.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TxSuffixe, "Suffixe (cedex,...)")
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Pays"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CbPays
        '
        Me.CbPays.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbPays.Location = New System.Drawing.Point(43, 92)
        Me.CbPays.Name = "CbPays"
        Me.CbPays.Size = New System.Drawing.Size(215, 21)
        Me.CbPays.TabIndex = 6
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "")
        '
        'BtImprimer
        '
        Me.BtImprimer.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtImprimer.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.BtImprimer.ActiveOnClick = False
        Me.BtImprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtImprimer.AntiAlias = True
        Me.BtImprimer.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtImprimer.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtImprimer.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtImprimer.HighColorLuminance = 1.3!
        Me.BtImprimer.Image = My.Resources.impr
        Me.BtImprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtImprimer.Location = New System.Drawing.Point(236, 0)
        Me.BtImprimer.LowColorLuminance = 1.3!
        Me.BtImprimer.Name = "BtImprimer"
        Me.BtImprimer.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtImprimer.Size = New System.Drawing.Size(22, 21)
        Me.BtImprimer.StayActiveAfterClick = False
        Me.BtImprimer.TabIndex = 8
        Me.BtImprimer.TabStop = True
        '
        'BtVille
        '
        Me.BtVille.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtVille.ActiveGradientLowColor = System.Drawing.Color.Moccasin
        Me.BtVille.ActiveOnClick = False
        Me.BtVille.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtVille.AntiAlias = True
        Me.BtVille.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtVille.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtVille.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtVille.HighColorLuminance = 1.3!
        Me.BtVille.Image = My.Resources.search
        Me.BtVille.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtVille.Location = New System.Drawing.Point(162, 72)
        Me.BtVille.LowColorLuminance = 1.3!
        Me.BtVille.Name = "BtVille"
        Me.BtVille.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtVille.Size = New System.Drawing.Size(22, 20)
        Me.BtVille.StayActiveAfterClick = False
        Me.BtVille.TabIndex = 3
        Me.BtVille.TabStop = True
        '
        'GestionAdresseII
        '
        Me.Controls.Add(Me.BtImprimer)
        Me.Controls.Add(Me.BtVille)
        Me.Controls.Add(Me.CbPays)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxSuffixe)
        Me.Controls.Add(Me.TxVille)
        Me.Controls.Add(Me.TxCodePostal)
        Me.Controls.Add(Me.TxAdresse)
        Me.Name = "GestionAdresseII"
        Me.Size = New System.Drawing.Size(261, 115)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Public Property Livraison() As Boolean
        Get
            Return _Livraison
        End Get
        Set(ByVal Value As Boolean)
            _Livraison = Value
        End Set
    End Property

    Public Property db() As CurrencyManager
        Get
            Return _db
        End Get
        Set(ByVal Value As CurrencyManager)
            _db = Value
            If Not _db Is Nothing Then
                Dim Liv As String = ""
                If _Livraison = True Then
                    Liv = "Liv"
                End If
                Dim dv As DataView
                If TypeOf _db.List Is BindingSource Then
                    dv = CType(CType(_db.List, BindingSource).List, DataView)
                Else
                    dv = CType(_db.List, DataView)
                End If

                Me.TxAdresse.DataBindings.Add("Text", dv, "Adresse" & Liv)
                Me.TxCodePostal.DataBindings.Add("Text", dv, "CodePostal" & Liv)
                Me.TxVille.DataBindings.Add("Text", dv, "Ville" & Liv)
                If dv.Table.Columns.Contains("SuffixePostal" & Liv) Then
                    Me.TxSuffixe.DataBindings.Add("Text", dv, "SuffixePostal" & Liv)
                End If
                If dv.Table.Columns.Contains("Pays" & Liv) Then
                    Me.CbPays.DataBindings.Add("Text", dv, "Pays" & Liv)
                End If
            End If
        End Set
    End Property


    Private Sub BtImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImprimer.Click
        _db.EndCurrentEdit()
        Try
            Dim lab As New Dymo.LabelEngine
            Dim txPrintNom As New Dymo.TextObj
            Dim txPrintAdresse As New Dymo.TextObj

            If _db.Position <> -1 Then
                lab.OpenFile(Application.StartupPath & "\Adresse.lwl")
                txPrintNom = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("Nom")), Dymo.TextObj)
                txPrintAdresse = CType(lab.PrintObject.LabelObject(lab.PrintObject.FindObj("Adresse")), Dymo.TextObj)
                txPrintNom.TextAttributes.Text = Convert.ToString(CType(_db.Current, DataRowView).Item("Nom"))
                txPrintAdresse.TextAttributes.Text = Convert.ToString(CType(_db.Current, DataRowView).Item("Adresse")) & vbCrLf & Convert.ToString(CType(db.Current, DataRowView).Item("CodePostal")) & " " & Convert.ToString(CType(db.Current, DataRowView).Item("Ville"))
                Dim q As Boolean, DeviceName As String, PortName As String, Copies As Integer
                DeviceName = "DYMO LabelWriter 320"
                'PortName = "USB001"
                PortName = ""
                Copies = 1
                q = lab.PrintLabel(DeviceName, PortName, Copies, True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtVille_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtVille.Click
        Dim frS As New FrRechercheVille(CType(_db.Current, DataRowView).DataView.Table.DataSet, Me.TxCodePostal, Me.TxVille)
        frS.ConnectionString = ConnectionString
        frS.Owner = Me.FindForm
        frS.ShowDialog()
    End Sub

    Private Sub GestionAdresseII_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(Me.BtVille.Image, Bitmap).MakeTransparent(Color.Magenta)
        Try
            Dim lab As New Dymo.LabelEngine
        Catch ex As Exception
            Me.BtImprimer.Visible = False
        End Try
    End Sub
End Class

Option Strict Off
Public Class FrAssistantCreationActivite
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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CbAActi As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxALib As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxUnite As System.Windows.Forms.TextBox
    Friend WithEvents RicaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ds As AgrigestEDI.dsPLC
    Friend WithEvents ActivitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents nudQte As System.Windows.Forms.NumericUpDown
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CbAActi = New System.Windows.Forms.ComboBox
        Me.ActivitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds = New AgrigestEDI.dsPLC
        Me.RicaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxALib = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.nudQte = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxUnite = New System.Windows.Forms.TextBox
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.Panel1.SuspendLayout()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RicaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudQte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(308, 8)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 5
        Me.BtAnnuler.Text = "Annuler"
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(227, 8)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 4
        Me.BtOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(394, 56)
        Me.Panel1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(217, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Saisissez les informations de l'activité à créer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Création d'une activité"
        '
        'CbAActi
        '
        Me.CbAActi.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.ActivitesBindingSource, "AActi", True))
        Me.CbAActi.DataSource = Me.RicaBindingSource
        Me.CbAActi.DisplayMember = "RDisplay"
        Me.CbAActi.Location = New System.Drawing.Point(121, 17)
        Me.CbAActi.Name = "CbAActi"
        Me.CbAActi.Size = New System.Drawing.Size(232, 21)
        Me.CbAActi.TabIndex = 0
        Me.CbAActi.ValueMember = "RiCode"
        '
        'ActivitesBindingSource
        '
        Me.ActivitesBindingSource.DataMember = "Activites"
        Me.ActivitesBindingSource.DataSource = Me.ds
        '
        'ds
        '
        Me.ds.DataSetName = "dsPLC"
        Me.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RicaBindingSource
        '
        Me.RicaBindingSource.DataMember = "Rica"
        Me.RicaBindingSource.DataSource = Me.ds
        Me.RicaBindingSource.Sort = "RiCode"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Code Activité"
        '
        'TxALib
        '
        Me.TxALib.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ActivitesBindingSource, "ALib", True))
        Me.TxALib.Location = New System.Drawing.Point(121, 49)
        Me.TxALib.MaxLength = 20
        Me.TxALib.Name = "TxALib"
        Me.TxALib.Size = New System.Drawing.Size(232, 20)
        Me.TxALib.TabIndex = 1
        Me.TxALib.Text = "WWWWWWWWWWWWWWWWWWWW"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Description"
        '
        'nudQte
        '
        Me.nudQte.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ActivitesBindingSource, "AQte", True))
        Me.nudQte.DecimalPlaces = 2
        Me.nudQte.Location = New System.Drawing.Point(121, 81)
        Me.nudQte.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nudQte.Name = "nudQte"
        Me.nudQte.Size = New System.Drawing.Size(80, 20)
        Me.nudQte.TabIndex = 2
        Me.nudQte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudQte.ThousandsSeparator = True
        Me.nudQte.Value = New Decimal(New Integer() {25053025, 0, 0, 131072})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Quantité - Unité"
        '
        'TxUnite
        '
        Me.TxUnite.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ActivitesBindingSource, "AUnit", True))
        Me.TxUnite.Location = New System.Drawing.Point(209, 81)
        Me.TxUnite.MaxLength = 2
        Me.TxUnite.Name = "TxUnite"
        Me.TxUnite.Size = New System.Drawing.Size(32, 20)
        Me.TxUnite.TabIndex = 3
        Me.TxUnite.Text = "WW"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.CbAActi)
        Me.GradientPanel1.Controls.Add(Me.TxUnite)
        Me.GradientPanel1.Controls.Add(Me.TxALib)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.nudQte)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 56)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(394, 136)
        Me.GradientPanel1.TabIndex = 20
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtOK)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 192)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(394, 42)
        Me.GradientPanel2.TabIndex = 21
        '
        'FrAssistantCreationActivite
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(394, 234)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrAssistantCreationActivite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Création d'activité"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ActivitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RicaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudQte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Enum ModeAssistant
        Creation
        Modification
    End Enum

    Public Mode As ModeAssistant = ModeAssistant.Creation
    Public NouveauActivite As dsPLC.PlanComptableRow

    Public Filter As String = ""
    Private dsSource As dsPLC

#Region "Constructeurs"
    Public Sub New(ByVal dsSource As dsPLC)
        Me.New()
        Me.dsSource = dsSource
        Me.RicaBindingSource.DataSource = Me.ds
        Me.ActivitesBindingSource.DataSource = Me.ds
    End Sub
#End Region

#Region "Page"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If dsSource Is Nothing Then Throw New ApplicationException
        SetChildFormIcon(Me)
        TxALib.Text = ""
        TxUnite.Text = ""
        nudQte.Value = 0

        Using dta As New dsPLCTableAdapters.RicaTableAdapter
            dta.Fill(ds.Rica)
        End Using

        Me.RicaBindingSource.Filter = Filter
        CbAActi.DropDownStyle = ComboBoxStyle.DropDownList

        Me.ActivitesBindingSource.AddNew()
        CType(Me.ActivitesBindingSource.Current, DataRowView).Item("ADossier") = My.User.Name
        Me.TxALib.Focus()
    End Sub
#End Region

#Region "CbAActi"
    Private Sub CbAActi_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CbAActi.Validating
        If CbAActi.SelectedItem Is Nothing Then
            CbAActi.Text = CbAActi.Text.Trim.PadRight(4, "0"c)
            If Not CbAActi.Text Like "####" Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub CbAActi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbAActi.SelectedIndexChanged
        If Not CbAActi.SelectedItem Is Nothing Then
            With CType(Me.ActivitesBindingSource.Current, DataRowView)
                .Item("AActi") = Convert.ToString(CType(CbAActi.SelectedItem, DataRowView)("RiCode"))
                .Item("ALib") = Convert.ToString(CType(CbAActi.SelectedItem, DataRowView)("RiLib1"))
                .Item("AUnit") = Convert.ToString(CType(CbAActi.SelectedItem, DataRowView)("RiUnite"))
                .Item("AQte") = 0
            End With
            Me.ActivitesBindingSource.ResetCurrentItem()
        End If
    End Sub

    Private Sub CbAActi_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbAActi.Validated
        With CType(Me.ActivitesBindingSource.Current, DataRowView)
            .Item("AQte") = 0
            If Not CbAActi.SelectedItem Is Nothing Then
                .Item("AActi") = Convert.ToString(CType(CbAActi.SelectedItem, DataRowView)("RiCode"))
                .Item("ALib") = Convert.ToString(CType(CbAActi.SelectedItem, DataRowView)("RiLib1"))
                .Item("AUnit") = Convert.ToString(CType(CbAActi.SelectedItem, DataRowView)("RiUnite"))
            Else
                .Item("AActi") = ""
                .Item("ALib") = ""
                .Item("AUnit") = ""
            End If
        End With
        Me.ActivitesBindingSource.ResetCurrentItem()
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        'Dim aacti As String
        'If Not CbAActi.SelectedItem Is Nothing Then
        '    aacti = CType(CbAActi.SelectedItem, DataRowView)("RiCode")
        'Else
        '    aacti = CbAActi.Text.Trim.PadRight(4, "0"c)
        'End If
        'Dim alib As String = TxALib.Text
        'Dim aqte As Decimal = nudQte.Value
        'Dim aunit As String = TxUnite.Text

        'With Me.ds.Tables("Activites")
        '    If .Select(String.Format("AActi='{0}'", aacti)).Length > 0 Then
        '        MsgBox("Cette activité existe déjà pour ce dossier.", MsgBoxStyle.Exclamation)
        '        Exit Sub
        '    Else
        '        Dim drActi As DataRow = .NewRow
        '        With drActi
        '            .Item("ADossier") = My.User.Name
        '            .Item("AActi") = aacti
        '            .Item("ALib") = alib
        '            .Item("AQte") = aqte
        '            .Item("AUnit") = aunit
        '        End With
        '        .Rows.Add(drActi)
        '    End If
        'End With
        Me.ActivitesBindingSource.EndEdit()
        Me.dsSource.Activites.Merge(Me.ds.Activites)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region " Ergonomie "
    Private Sub TxALib_Enter(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles TxALib.Enter, TxUnite.Enter, nudQte.Enter
        If TypeOf sender Is TextBox Then
            CType(sender, TextBox).SelectAll()
        ElseIf TypeOf sender Is NumericUpDown Then
            CType(sender, NumericUpDown).Select(0, CType(sender, NumericUpDown).Text.Length)
        End If
    End Sub

    Private Sub CbAActi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbAActi.KeyPress
        e.Handled = Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub

    Private Sub nudQte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudQte.KeyPress
        If e.KeyChar = "."c Then
            Windows.Forms.SendKeys.Send(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            e.Handled = True
        End If
    End Sub
#End Region

End Class

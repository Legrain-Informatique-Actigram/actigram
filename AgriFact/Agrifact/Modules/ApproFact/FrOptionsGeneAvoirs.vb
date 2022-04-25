Public Class FrOptionsGeneAvoirs
    Inherits System.Windows.Forms.Form

    Public DtDeb As Date = Date.MinValue
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Public DtFin As Date = Date.MinValue

    Public Sub New(ByVal dtDeb As Date, ByVal dtFin As Date)
        Me.New()
        Me.DtDeb = dtDeb
        Me.DtFin = dtFin
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
    Friend WithEvents btOk As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents openDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDtDeb As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDtFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btOk = New System.Windows.Forms.Button
        Me.btCancel = New System.Windows.Forms.Button
        Me.openDlg = New System.Windows.Forms.OpenFileDialog
        Me.dtpDtDeb = New System.Windows.Forms.DateTimePicker
        Me.dtpDtFin = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btOk
        '
        Me.btOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOk.Location = New System.Drawing.Point(121, 10)
        Me.btOk.Name = "btOk"
        Me.btOk.Size = New System.Drawing.Size(75, 23)
        Me.btOk.TabIndex = 0
        Me.btOk.Text = "OK"
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(201, 10)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 1
        Me.btCancel.Text = "Annuler"
        '
        'openDlg
        '
        Me.openDlg.Filter = "Classeur Excel (*.xls)|*.xls"
        Me.openDlg.Title = "Sélectionnez le fichier Phyto Data à importer"
        '
        'dtpDtDeb
        '
        Me.dtpDtDeb.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDtDeb.Location = New System.Drawing.Point(36, 31)
        Me.dtpDtDeb.Name = "dtpDtDeb"
        Me.dtpDtDeb.Size = New System.Drawing.Size(103, 20)
        Me.dtpDtDeb.TabIndex = 2
        '
        'dtpDtFin
        '
        Me.dtpDtFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDtFin.Location = New System.Drawing.Point(170, 31)
        Me.dtpDtFin.Name = "dtpDtFin"
        Me.dtpDtFin.Size = New System.Drawing.Size(104, 20)
        Me.dtpDtFin.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Du"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "au"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Générer les avoirs pour la période"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.btCancel)
        Me.GradientPanel2.Controls.Add(Me.btOk)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 65)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(288, 45)
        Me.GradientPanel2.TabIndex = 19
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.dtpDtDeb)
        Me.GradientPanel1.Controls.Add(Me.dtpDtFin)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(288, 65)
        Me.GradientPanel1.TabIndex = 20
        '
        'FrOptionsGeneAvoirs
        '
        Me.AcceptButton = Me.btOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(288, 110)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrOptionsGeneAvoirs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options de génération des avoirs"
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub FrChoixRestauration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.DtDeb > Date.MinValue Then dtpDtDeb.Value = Me.DtDeb
        If Me.DtFin > Date.MinValue Then dtpDtFin.Value = Me.DtFin
    End Sub

    Private Sub btOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOk.Click
        Try
            Me.DtDeb = dtpDtDeb.Value
            Me.DtFin = dtpDtFin.Value
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            LogException(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class

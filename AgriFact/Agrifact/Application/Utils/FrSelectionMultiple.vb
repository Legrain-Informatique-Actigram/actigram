Public Class FrSelectionMultiple
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
    Friend WithEvents lstContents As System.Windows.Forms.ListBox
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button
    Friend WithEvents btSelectAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstContents = New System.Windows.Forms.ListBox
        Me.btOK = New System.Windows.Forms.Button
        Me.btCancel = New System.Windows.Forms.Button
        Me.btSelectAll = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lstContents
        '
        Me.lstContents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstContents.Location = New System.Drawing.Point(8, 8)
        Me.lstContents.Name = "lstContents"
        Me.lstContents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstContents.Size = New System.Drawing.Size(344, 290)
        Me.lstContents.TabIndex = 0
        '
        'btOK
        '
        Me.btOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOK.Location = New System.Drawing.Point(192, 304)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(75, 23)
        Me.btOK.TabIndex = 1
        Me.btOK.Text = "OK"
        '
        'btCancel
        '
        Me.btCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(277, 304)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(75, 23)
        Me.btCancel.TabIndex = 2
        Me.btCancel.Text = "Annuler"
        '
        'btSelectAll
        '
        Me.btSelectAll.Location = New System.Drawing.Point(72, 304)
        Me.btSelectAll.Name = "btSelectAll"
        Me.btSelectAll.Size = New System.Drawing.Size(112, 23)
        Me.btSelectAll.TabIndex = 3
        Me.btSelectAll.Text = "Tout Sélectionner"
        '
        'FrSelectionMultiple
        '
        Me.AcceptButton = Me.btOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(360, 333)
        Me.ControlBox = False
        Me.Controls.Add(Me.btSelectAll)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btOK)
        Me.Controls.Add(Me.lstContents)
        Me.KeyPreview = True
        Me.Name = "FrSelectionMultiple"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrSelectionMultiple"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSelectAll.Click
        For i As Integer = 0 To lstContents.Items.Count - 1
            lstContents.SetSelected(i, True)
        Next
    End Sub

    Private Sub FrSelectionMultiple_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control And e.KeyCode = Keys.A Then
            btSelectAll_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Public Class ListItem
        Public Value As Object
        Public Text As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal Text As String, ByVal Value As Object)
            Me.Text = Text
            Me.Value = Value
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Private Sub FrSelectionMultiple_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
    End Sub
End Class

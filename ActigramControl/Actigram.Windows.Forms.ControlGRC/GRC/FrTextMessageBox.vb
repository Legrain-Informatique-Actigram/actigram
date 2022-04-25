Public Class FrTextMessageBox
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
    Friend WithEvents btOk As System.Windows.Forms.Button
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents lbDescription As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btOk = New System.Windows.Forms.Button
        Me.txtMessage = New System.Windows.Forms.TextBox
        Me.lbDescription = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btOk
        '
        Me.btOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btOk.Location = New System.Drawing.Point(301, 168)
        Me.btOk.Name = "btOk"
        Me.btOk.TabIndex = 0
        Me.btOk.Text = "OK"
        '
        'txtMessage
        '
        Me.txtMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMessage.BackColor = System.Drawing.Color.White
        Me.txtMessage.Location = New System.Drawing.Point(8, 40)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMessage.Size = New System.Drawing.Size(368, 120)
        Me.txtMessage.TabIndex = 1
        Me.txtMessage.Text = "Message"
        '
        'lbDescription
        '
        Me.lbDescription.AutoSize = True
        Me.lbDescription.Location = New System.Drawing.Point(8, 8)
        Me.lbDescription.Name = "lbDescription"
        Me.lbDescription.Size = New System.Drawing.Size(61, 16)
        Me.lbDescription.TabIndex = 2
        Me.lbDescription.Text = "Description"
        '
        'FrTextMessageBox
        '
        Me.AcceptButton = Me.btOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btOk
        Me.ClientSize = New System.Drawing.Size(384, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbDescription)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.btOk)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrTextMessageBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Title"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property Message() As String
        Get
            Return txtMessage.Text
        End Get
        Set(ByVal Value As String)
            txtMessage.Text = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return lbDescription.Text
        End Get
        Set(ByVal Value As String)
            lbDescription.Text = Value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal Value As String)
            Me.Text = Value
        End Set
    End Property

    Private Sub txtMessage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMessage.KeyPress
        If Asc(e.KeyChar) = 1 And Form.ModifierKeys = Keys.Control Then
            txtMessage.SelectAll()
            e.Handled = True
        End If
    End Sub

    Public Sub New(ByVal Message As String, Optional ByVal Title As String = "", Optional ByVal Description As String = "")
        Me.Message = Message
        Me.Title = Title
        Me.Description = Description
        Me.ShowDialog()
    End Sub

    Public Overloads Shared Sub Show(ByVal Message As String, Optional ByVal Title As String = "", Optional ByVal Description As String = "")
        Dim fr As New FrTextMessageBox
        With fr
            .Message = Message
            .Title = Title
            .Description = Description
            .ShowDialog()
        End With
    End Sub

    Private Sub FrTextMessageBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.Text = "" Or Me.Text = "Title" Then
            Me.Text = Application.ProductName
        End If
    End Sub
End Class

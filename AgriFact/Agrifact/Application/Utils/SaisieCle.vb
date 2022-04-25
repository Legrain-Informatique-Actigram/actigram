Namespace Securite.Activation
    Public Class SaisieCle
        Inherits System.Windows.Forms.UserControl

#Region " Code généré par le Concepteur Windows Form "

        Public Sub New()
            MyBase.New()

            'Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent()

            'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

        End Sub

        'La méthode substituée Dispose du UserControl pour nettoyer la liste des composants.
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
        Friend WithEvents TxCle1 As System.Windows.Forms.TextBox
        Friend WithEvents TxCle2 As System.Windows.Forms.TextBox
        Friend WithEvents TxCle3 As System.Windows.Forms.TextBox
        Friend WithEvents TxCle4 As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.TxCle1 = New System.Windows.Forms.TextBox
            Me.TxCle2 = New System.Windows.Forms.TextBox
            Me.TxCle3 = New System.Windows.Forms.TextBox
            Me.TxCle4 = New System.Windows.Forms.TextBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.SuspendLayout()
            '
            'TxCle1
            '
            Me.TxCle1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.TxCle1.Location = New System.Drawing.Point(8, 8)
            Me.TxCle1.Name = "TxCle1"
            Me.TxCle1.Size = New System.Drawing.Size(40, 20)
            Me.TxCle1.TabIndex = 0
            Me.TxCle1.Text = "BBBB"
            '
            'TxCle2
            '
            Me.TxCle2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.TxCle2.Location = New System.Drawing.Point(56, 8)
            Me.TxCle2.Name = "TxCle2"
            Me.TxCle2.Size = New System.Drawing.Size(40, 20)
            Me.TxCle2.TabIndex = 1
            Me.TxCle2.Text = "BBBB"
            '
            'TxCle3
            '
            Me.TxCle3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.TxCle3.Location = New System.Drawing.Point(104, 8)
            Me.TxCle3.Name = "TxCle3"
            Me.TxCle3.Size = New System.Drawing.Size(40, 20)
            Me.TxCle3.TabIndex = 2
            Me.TxCle3.Text = "BBBB"
            '
            'TxCle4
            '
            Me.TxCle4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.TxCle4.Location = New System.Drawing.Point(152, 8)
            Me.TxCle4.MaxLength = 4
            Me.TxCle4.Name = "TxCle4"
            Me.TxCle4.Size = New System.Drawing.Size(40, 20)
            Me.TxCle4.TabIndex = 3
            Me.TxCle4.Text = "BBBB"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(48, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(10, 13)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "-"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(96, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(10, 13)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "-"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(144, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(10, 13)
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "-"
            '
            'SaisieCle
            '
            Me.Controls.Add(Me.TxCle4)
            Me.Controls.Add(Me.TxCle3)
            Me.Controls.Add(Me.TxCle2)
            Me.Controls.Add(Me.TxCle1)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Name = "SaisieCle"
            Me.Size = New System.Drawing.Size(200, 40)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Public Event SaisieCleCompleted(ByVal sender As Object, ByVal e As EventArgs)
        Public Event CleChanged(ByVal sender As Object, ByVal e As EventArgs)

        Public Property Cle() As Long
            Get
                Dim l As Long = 0
                Try
                    l = Long.Parse(Me.CleText, Globalization.NumberStyles.HexNumber)
                Catch
                End Try
                Return l
            End Get
            Set(ByVal Value As Long)
                Me.CleText = Value.ToString("X16")
            End Set
        End Property

        Public Property CleText() As String
            Get
                Return String.Format("{0}{1}{2}{3}", Me.TxCle1.Text.Trim, Me.TxCle2.Text.Trim, Me.TxCle3.Text.Trim, Me.TxCle4.Text.Trim)
            End Get
            Set(ByVal Value As String)
                Value = Value.Replace("-", "")
                Value = Value.Replace(" ", "")
                If Value.Length > 16 Then Value = Value.Substring(0, 16)
                If Value.Length < 16 Then Value = Value.PadRight(16)
                Me.TxCle1.Text = Value.Substring(0, 4).Trim
                Me.TxCle2.Text = Value.Substring(4, 4).Trim
                Me.TxCle3.Text = Value.Substring(8, 4).Trim
                Me.TxCle4.Text = Value.Substring(12, 4).Trim
            End Set
        End Property

        Public ReadOnly Property CleTextDecorated(Optional ByVal sep As String = "-") As String
            Get
                Return String.Format("{0}{4}{1}{4}{2}{4}{3}", Me.TxCle1.Text, Me.TxCle2.Text, Me.TxCle3.Text, Me.TxCle4.Text, sep)
            End Get
        End Property


        Private Sub SaisieCle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.CleText = ""
        End Sub

        Private Sub TxCle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TxCle1.TextChanged, TxCle2.TextChanged, TxCle3.TextChanged, TxCle4.TextChanged
            Dim tx As TextBox = CType(sender, TextBox)
            If tx.Text.IndexOf("-"c) >= 0 Then
                tx.Text = tx.Text.Replace("-", "")
            ElseIf tx.Text.IndexOf(" "c) >= 0 Then
                tx.Text = tx.Text.Replace(" ", "")
            ElseIf tx.Text.Length > 4 Then
                Dim nextTx As TextBox = NextCtl(tx)
                If Not nextTx Is Nothing Then
                    With tx
                        nextTx.Select()
                        nextTx.Text = .Text.Substring(4)
                        .Text = .Text.Substring(0, 4)
                        nextTx.SelectionLength = 0
                        nextTx.SelectionStart = .Text.Length
                    End With
                End If
            ElseIf Me.CleText.Length = 16 Then
                RaiseEvent CleChanged(Me, New EventArgs)
                RaiseEvent SaisieCleCompleted(Me, New EventArgs)
                Exit Sub
            End If
            RaiseEvent CleChanged(Me, New EventArgs)
        End Sub

        Private Sub TxCle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles TxCle1.KeyUp, TxCle2.KeyUp, TxCle3.KeyUp, TxCle4.KeyUp
            Dim tx As TextBox = CType(sender, TextBox)
            If (e.KeyCode = Keys.Back AndAlso tx.Text.Length = 0) _
            OrElse (e.KeyCode = Keys.Left AndAlso tx.SelectionStart = 0) Then
                Dim prev As TextBox = PrevCtl(tx)
                If Not prev Is Nothing Then
                    With prev
                        .Select()
                        If .Text.Length > 0 Then
                            .SelectionLength = 0
                            .SelectionStart = .Text.Length
                        End If
                    End With
                End If
            ElseIf e.KeyCode = Keys.Right AndAlso tx.SelectionStart = tx.Text.Length Then
                Dim nex As TextBox = NextCtl(tx)
                If Not nex Is Nothing Then
                    With nex
                        .Select()
                        .SelectionLength = 0
                        .SelectionStart = 0
                    End With
                End If
            End If
        End Sub

        Private Sub TxCle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles TxCle1.KeyPress, TxCle2.KeyPress, TxCle3.KeyPress, TxCle4.KeyPress
            If Not (CharIsHexDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End Sub


        Private Function NextCtl(ByVal ctl As TextBox) As TextBox
            If ctl Is Me.TxCle1 Then : Return Me.TxCle2
            ElseIf ctl Is Me.TxCle2 Then : Return Me.TxCle3
            ElseIf ctl Is Me.TxCle3 Then : Return Me.TxCle4
            Else : Return Nothing
            End If
        End Function

        Private Function PrevCtl(ByVal ctl As TextBox) As TextBox
            If ctl Is Me.TxCle2 Then : Return Me.TxCle1
            ElseIf ctl Is Me.TxCle3 Then : Return Me.TxCle2
            ElseIf ctl Is Me.TxCle4 Then : Return Me.TxCle3
            Else : Return Nothing
            End If
        End Function

    End Class
End Namespace
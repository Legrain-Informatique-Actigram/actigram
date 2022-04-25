Public Class FrChoixMultiple
    Inherits System.Windows.Forms.Form
    Dim mysender As TextBox
    Dim Table As DataTable
    Dim Champs As String = ""
    Dim Filtre As String = ""
    Dim Entrer As Boolean = False
    Dim Recherche As Boolean = False
    Dim strDepart As String
    Dim _ModeAjout As Boolean = False

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim parameters As CreateParams = MyBase.CreateParams
            parameters.ClassStyle = (parameters.ClassStyle Or &H20000)
            Return parameters
        End Get
    End Property

    Public Property ModeAjout() As Boolean
        Get
            Return _ModeAjout
        End Get
        Set(ByVal Value As Boolean)
            _ModeAjout = Value
        End Set
    End Property

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal momTextBox As TextBox, ByVal malocation As Point, ByVal TbTable As DataTable, ByVal strChamps As String, ByVal strFiltre As String)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        Me.Location = malocation
        Me.Width = momTextBox.Width
        mysender = momTextBox
        Table = TbTable
        Champs = strChamps
        Filtre = strFiltre
    End Sub

    Public Sub New(ByVal momTextBox As TextBox, ByVal malocation As Point, ByVal TbTable As DataTable, ByVal strChamps As String, ByVal strFiltre As String, ByVal bRecherche As Boolean)
        Me.New(momTextBox, malocation, TbTable, strChamps, strFiltre)

        Recherche = bRecherche
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
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBox1.Size = New System.Drawing.Size(176, 147)
        Me.ListBox1.TabIndex = 0
        '
        'FrChoixMultiple
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(176, 147)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrChoixMultiple"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrCalendrier"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ListBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.MouseLeave
        If Entrer = True Then
            mysender.Select()
            Me.Close()
            'Me.Dispose()
        End If
    End Sub

    Private Sub SelectionChanged()
        Dim it As Object
        Dim str As String = ""
        For Each it In ListBox1.SelectedItems
            If str.Length > 0 Then
                If Recherche = True Then
                    str += "* ou *"
                Else
                    If mysender.Multiline = True Then
                        str += Chr(13) & Chr(10)
                    Else
                        str += " , "
                    End If
                End If
            Else
                If Recherche = True Then
                    str += "*"
                End If
            End If
            str += Convert.ToString(CType(it, DataRowView).Item(Champs))
        Next
        If str.Length > 0 And Recherche = True Then
            str += "*"
        End If
        'If _ModeAjout = True Then
        Dim strAjt As String = ""
        If mysender.Multiline Then
            If strDepart.Length > 0 Then strAjt += vbCrLf
        Else
            If strDepart.Length > 0 Then strAjt += " , "
        End If

        If Recherche = True Then
            strDepart = ""
        End If
        If _ModeAjout = True Then
            str = strDepart + strAjt + str
        End If
        'End If
        mysender.Text = str
    End Sub

    Private Sub ListBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        SelectionChanged()
    End Sub

    Private Sub FrChoixMultiple_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strDepart = mysender.Text
        Dim dv As New DataView(Table)
        dv.RowFilter = Filtre
        dv.Sort = Champs
        Me.ListBox1.DataSource = dv
        Me.ListBox1.DisplayMember = Champs
        If Me.ListBox1.Items.Count > 0 Then
            Me.ListBox1.SetSelected(0, False)
        End If
        If mysender.Text.Length > 0 Then
            Dim a() As String = Nothing
            Dim b As String
            If Recherche Then
                'a = mysender.Text.Split(New Char() {"*"c, " "c, "o"c, "u"c, " "c, "*"c})
            Else
                If mysender.Multiline = True Then
                    a = mysender.Text.Split(New Char() {Chr(13), Chr(10)})
                Else
                    a = mysender.Text.Split(New Char() {","c})
                End If
            End If
            If Not a Is Nothing Then
                For Each b In a
                    If mysender.Multiline = False Then
                        b = b.Trim
                    End If
                    If b <> "" Then
                        Dim i As Integer
                        For i = 0 To Me.ListBox1.Items.Count - 1
                            If Me.ListBox1.GetItemText(Me.ListBox1.Items(i)) = b Then
                                'If Me.ListBox1.GetItemText(Me.ListBox1.Items(i)).IndexOf(b) >= 0 Then
                                Me.ListBox1.SetSelected(i, True)
                            End If
                        Next
                    End If
                Next
            End If
        End If
        Me.ListBox1.Select()
        'SelectionChanged()
        'Me.ListBox1.ValueMember = Convert.ToString(mysender.Tag)
    End Sub

    Private Sub ListBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.MouseEnter
        Entrer = True
    End Sub

    Private Sub ListBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            mysender.Select()
            Me.Close()
            'Me.Dispose()
        End If
    End Sub

    Private Sub ListBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox1.KeyPress
        SelectionChanged()
    End Sub

    Private Sub ListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.LostFocus
        Me.Close()
    End Sub
End Class

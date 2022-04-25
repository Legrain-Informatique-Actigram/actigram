Public Class FrResultatRecherche
    Inherits System.Windows.Forms.Form
    Public dv As DataView
    Dim strColKey As String = ""
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public Event SelectLigne(ByVal nKey As Object)
    Dim myFrRecherche As FrRecherche = Nothing
    Private cols As List(Of DataGridViewColumn)

    Public Sub New(ByVal maDataView As DataView, ByVal ColKey As String)
        Me.New()
        strColKey = ColKey
        dv = maDataView
    End Sub

    Public Sub New(ByVal maDataView As DataView, ByVal ColKey As String, ByVal cols As List(Of DataGridViewColumn))
        Me.New(maDataView, ColKey)
        Me.cols = cols
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(743, 430)
        Me.DataGridView1.TabIndex = 1
        '
        'FrResultatRecherche
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(743, 430)
        Me.Controls.Add(Me.DataGridView1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrResultatRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property momFrRecherche() As FrRecherche
        Get
            Return myFrRecherche
        End Get
        Set(ByVal Value As FrRecherche)
            myFrRecherche = Value
        End Set
    End Property

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        ActivateLigne(Me.DataGridView1.Rows(e.RowIndex))
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ActivateLigne(Me.DataGridView1.CurrentRow)
        End If
    End Sub

    'Private Sub DataGridView1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DataGridView1.KeyPress
    '    If e.KeyChar = vbCr Then
    '        ActivateLigne(Me.DataGridView1.CurrentRow)
    '    End If
    'End Sub

    Private Sub ActivateLigne(ByVal r As DataGridViewRow)
        If r.DataBoundItem Is Nothing Then Exit Sub
        If strColKey <> "" Then
            RaiseEvent SelectLigne(CType(r.DataBoundItem, DataRowView)(strColKey))
        Else
            RaiseEvent SelectLigne(r)
        End If
        If Not myFrRecherche Is Nothing Then myFrRecherche.Close()
        Me.Close()
    End Sub

    Private Sub FrResultatRecherche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.DataGridView1)
        If cols Is Nothing OrElse cols.Count = 0 Then
            Me.DataGridView1.AutoGenerateColumns = True
        Else
            Me.DataGridView1.AutoGenerateColumns = False
            Me.DataGridView1.Columns.AddRange(cols.ToArray)
        End If
        Me.DataGridView1.DataSource = dv
        Me.Width = Me.DataGridView1.Columns.Count * 150
    End Sub

End Class

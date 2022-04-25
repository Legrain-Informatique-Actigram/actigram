Public Class FrSearch

    Private _Cell As DataGridViewCell
    Private _SelectedColIndex As Integer = 0
    Private _dv As DataView
    Private _DefaultFilter As String = String.Empty
    Private _FilterTemplate As String = String.Empty
    Private _Isclosing As Boolean = False
    Private _HasBeenActivated As Boolean = False

    Public FiltreBase As String = String.Empty
    Public Resultat As Object = Nothing

#Region "Constructeurs"
    Public Sub New(ByRef cell As DataGridViewCell, ByVal selectedColIndex As Integer)
        Me.New()
        Me._Cell = cell
        Me._SelectedColIndex = selectedColIndex
    End Sub

    Public Sub New()
        MyBase.New()

        InitializeComponent()

        Dim m As New MoveControl(Me)

        m.AllowMoving = False
        m.AllowResizeFlags = MoveControl.ResizeDirection.Bottom Or MoveControl.ResizeDirection.BottomRight Or MoveControl.ResizeDirection.Right

        Me.ResultsDataGridView.AutoGenerateColumns = False
    End Sub
#End Region

#Region "Propriétés"
    Public ReadOnly Property ListOfResults() As DataGridView
        Get
            Return Me.ResultsDataGridView
        End Get
    End Property

    'Pour afficher une ombre sous la form
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim parameters As CreateParams = MyBase.CreateParams

            parameters.ClassStyle = (parameters.ClassStyle Or &H20000)

            Return parameters
        End Get
    End Property

    Public Property DataSource() As DataView
        Get
            Return Me._dv
        End Get
        Set(ByVal Value As DataView)
            Me._dv = Value
            Me._DefaultFilter = Me._dv.RowFilter

            Dim filters As New List(Of String)

            'Traitement spécial pour la table produit
            If (Me._dv.Table.TableName = "Produit") Then
                filters.Add(String.Format("({0} like {{0}})", "CodeProduit"))
                filters.Add(String.Format("({0} like {{0}})", "Libelle"))
                filters.Add(String.Format("({0} like {{0}})", "LibelleLong"))
            Else
                For Each cl As DataColumn In Me._dv.Table.Columns
                    If cl.DataType Is GetType(String) Then
                        filters.Add(String.Format("({0} like {{0}})", cl.ColumnName))
                    End If
                Next
            End If

            Me._FilterTemplate = String.Join(" OR ", filters.ToArray)
        End Set
    End Property
#End Region

#Region "Form"
    Private Sub FrSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.ResultsDataGridView)

        Me.ResultsDataGridView.AutoGenerateColumns = False

        LoadData()

        If Me._DefaultFilter.Length > 0 Then
            Me.FilterToolStripButton.Checked = True
        End If
    End Sub

    Private Sub FrSearch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            If (Me._Isclosing) Then Exit Sub

            Me.Close()
        End If
    End Sub

    Private Sub FrSearch_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.ListOfResults.Select()

        If Me.ListOfResults.Rows.Count > 0 Then
            Me.ListOfResults.Rows(0).Selected = True
        End If

        Me._HasBeenActivated = True
    End Sub

    Private Sub FrSearch_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If Not Me._HasBeenActivated Then Exit Sub

        If Me._Isclosing Then Exit Sub

        Me.Close()
    End Sub

    Private Sub FrSearch_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me._Isclosing = True
    End Sub
#End Region

#Region "ToolStrip1"
    Private Sub FilterToolStripButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterToolStripButton.CheckedChanged
        If Me.FilterToolStripButton.Checked Then
            FilterList(Me.SearchToolStripTextBox.Text.Trim)
        Else
            Me._dv.RowFilter = Me.FiltreBase
        End If
    End Sub
#End Region

#Region "ResultsDataGridView"
    Private Sub ResultsDataGridView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ResultsDataGridView.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SelectRow(Me.ResultsDataGridView.CurrentRow)

            e.Handled = True
        End If
    End Sub

    Private Sub ResultsDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ResultsDataGridView.CellDoubleClick
        If (e.RowIndex < 0) Then Exit Sub

        SelectRow(Me.ResultsDataGridView.Rows(e.RowIndex))
    End Sub
#End Region

#Region "SearchToolStripTextBox"
    Private Sub SearchToolStripTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripTextBox.TextChanged
        Me.FilterList(Me.SearchToolStripTextBox.Text.Trim)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        If Not Me._dv Is Nothing Then
            Me.ResultsDataGridView.DataSource = Me._dv
        End If
    End Sub

    Private Sub FilterList(ByVal q As String)
        Dim filter As String = Me.FiltreBase

        If q.Length = 0 Then
            filter = Me._DefaultFilter
        Else
            If (String.IsNullOrEmpty(Me.FiltreBase)) Then
                filter = FormatExpression(Me._FilterTemplate, "*" & q & "*")
            Else
                filter = Me.FiltreBase & " AND (" & FormatExpression(Me._FilterTemplate, "*" & q & "*") & ")"
            End If
        End If

        If (filter = Me._dv.RowFilter) Then Exit Sub

        Me._dv.RowFilter = filter

        If ((Me._dv.RowFilter.Length > 0) And Not (Me.FilterToolStripButton.Checked)) Then Me.FilterToolStripButton.Checked = True
    End Sub

    Private Sub SelectRow(ByVal r As DataGridViewRow)
        If r.DataBoundItem Is Nothing Then Exit Sub

        Dim drv As DataRowView = CType(r.DataBoundItem, DataRowView)

        If Not Me._Cell Is Nothing Then
            Me._Cell.Value = drv(Me.ResultsDataGridView.Columns(Me._SelectedColIndex).DataPropertyName)
        End If

        Me.Resultat = drv(Me._SelectedColIndex)

        Me.Close()
    End Sub

    Public Sub AddColumn(ByVal Libelle As String, ByVal Champs As String, ByVal Largeur As Integer, _
                        Optional ByVal Alignement As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft, _
                        Optional ByVal Format As String = "", Optional ByVal autosizemode As DataGridViewAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.AllCells)

        Dim col As New DataGridViewTextBoxColumn

        With col
            .Name = Champs
            .HeaderText = Libelle
            .DataPropertyName = Champs
            .Width = Largeur
            .DefaultCellStyle.Alignment = Alignement

            If Format.Length > 0 Then
                .DefaultCellStyle.Format = Format
            End If

            .AutoSizeMode = autosizemode
        End With

        Me.ResultsDataGridView.Columns.Add(col)
    End Sub
#End Region

End Class
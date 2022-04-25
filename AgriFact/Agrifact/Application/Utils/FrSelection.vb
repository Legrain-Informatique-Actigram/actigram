Imports System.Runtime.InteropServices

Public Class FrSelection
    Inherits System.Windows.Forms.Form

    Dim Cell As DataGridViewCell
    Dim nColSelected As Integer = 0

    Private _defaultFilter As String = String.Empty
    Private _filterTemplate As String = String.Empty
    Private dv As DataView
    Private _isclosing As Boolean = False
    Private _hasBeenActivated As Boolean = False
 
    Public Resultat As Object = Nothing
    Public FiltreBase As String = String.Empty

#Region "Constructeurs"
    Public Sub New(ByRef Cell As DataGridViewCell, ByVal ColSelection As Integer)
        Me.New()
        Me.Cell = Cell
        nColSelected = ColSelection
    End Sub

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Dim m As New MoveControl(Me)
        m.AllowMoving = False
        m.AllowResizeFlags = MoveControl.ResizeDirection.Bottom Or MoveControl.ResizeDirection.BottomRight Or MoveControl.ResizeDirection.Right
        Me.dgvListe.AutoGenerateColumns = False
    End Sub
#End Region

#Region " Code généré par le Concepteur Windows Form "

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
    Friend WithEvents dgvListe As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents TxRech As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents WatermarkProvider1 As Windark.Windows.Controls.WatermarkProvider
    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.dgvListe = New System.Windows.Forms.DataGridView
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.TbFilter = New System.Windows.Forms.ToolStripButton
        Me.TxRech = New System.Windows.Forms.ToolStripTextBox
        Me.WatermarkProvider1 = New Windark.Windows.Controls.WatermarkProvider(Me.components)
        CType(Me.dgvListe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvListe
        '
        Me.dgvListe.AllowUserToAddRows = False
        Me.dgvListe.AllowUserToDeleteRows = False
        Me.dgvListe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvListe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListe.Location = New System.Drawing.Point(1, 1)
        Me.dgvListe.MultiSelect = False
        Me.dgvListe.Name = "dgvListe"
        Me.dgvListe.ReadOnly = True
        Me.dgvListe.Size = New System.Drawing.Size(525, 124)
        Me.dgvListe.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TbFilter, Me.TxRech})
        Me.ToolStrip1.Location = New System.Drawing.Point(1, 125)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 1, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(525, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'TbFilter
        '
        Me.TbFilter.CheckOnClick = True
        Me.TbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFilter.Image = Global.AgriFact.My.Resources.Resources.filter
        Me.TbFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFilter.Name = "TbFilter"
        Me.TbFilter.Size = New System.Drawing.Size(23, 22)
        Me.TbFilter.Text = "Filtrer"
        '
        'TxRech
        '
        Me.TxRech.Name = "TxRech"
        Me.TxRech.Size = New System.Drawing.Size(200, 25)
        Me.WatermarkProvider1.SetWatermark(Me.TxRech, "Rechercher")
        '
        'FrSelection
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ClientSize = New System.Drawing.Size(528, 152)
        Me.Controls.Add(Me.dgvListe)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "FrSelection"
        Me.Padding = New System.Windows.Forms.Padding(1, 1, 2, 2)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "FrSelection"
        CType(Me.dgvListe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Propriétés"
    Public ReadOnly Property Liste() As DataGridView
        Get
            Return Me.dgvListe
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
            Return Me.dv
        End Get
        Set(ByVal Value As DataView)
            Me.dv = Value
            Me._defaultFilter = Me.dv.RowFilter

            Dim filters As New List(Of String)

            'Traitement spécial pour la table produit
            If (dv.Table.TableName = "Produit") Then
                filters.Add(String.Format("({0} like {{0}})", "CodeProduit"))
                filters.Add(String.Format("({0} like {{0}})", "Libelle"))
                filters.Add(String.Format("({0} like {{0}})", "LibelleLong"))
            Else
                For Each cl As DataColumn In dv.Table.Columns
                    If cl.DataType Is GetType(String) Then
                        filters.Add(String.Format("({0} like {{0}})", cl.ColumnName))
                    End If
                Next
            End If

            _filterTemplate = String.Join(" OR ", filters.ToArray)
        End Set
    End Property
#End Region

#Region " Form Events "
    Private Sub FrSelection_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ApplyStyle(Me.dgvListe)
        Me.dgvListe.AutoGenerateColumns = False
        ChargerDonnees()
        If _defaultFilter.Length > 0 Then
            TbFilter.Checked = True
        End If
    End Sub

    Private Sub FrSelection_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            If _isclosing Then Exit Sub
            Me.Close()
        End If
    End Sub

    Private Sub FrSelection_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.Liste.Select()
        If Me.Liste.Rows.Count > 0 Then
            Me.Liste.Rows(0).Selected = True
        End If
        _hasBeenActivated = True
    End Sub

    Private Sub FrSelection_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If Not _hasBeenActivated Then Exit Sub
        If _isclosing Then Exit Sub
        Me.Close()
    End Sub

    Private Sub FrSelection_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        _isclosing = True
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
        If TbFilter.Checked Then
            Filtrer(TxRech.Text.Trim)
        Else
            Me.dv.RowFilter = Me.FiltreBase
        End If
    End Sub
#End Region

#Region "dgvListe"
    Private Sub dgvListe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvListe.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectLigne(Me.dgvListe.CurrentRow)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvListe_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListe.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        SelectLigne(Me.dgvListe.Rows(e.RowIndex))
    End Sub
#End Region

#Region "TxRech"
    Private Sub TxRech_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRech.TextChanged
        Filtrer(TxRech.Text.Trim)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub Filtrer(ByVal q As String)
        Dim filter As String = Me.FiltreBase

        If q.Length = 0 Then
            filter = _defaultFilter
        Else
            If ((Me.FiltreBase Is Nothing) Or (Me.FiltreBase = String.Empty)) Then
                filter = FormatExpression(_filterTemplate, "*" & q & "*")
            Else
                filter = Me.FiltreBase & " AND (" & FormatExpression(_filterTemplate, "*" & q & "*") & ")"
            End If
        End If

        If filter = Me.dv.RowFilter Then Exit Sub

        Me.dv.RowFilter = filter

        If Me.dv.RowFilter.Length > 0 And Not Me.TbFilter.Checked Then Me.TbFilter.Checked = True
    End Sub

    Private Sub ChargerDonnees()
        If Not dv Is Nothing Then
            Me.dgvListe.DataSource = dv
        End If
    End Sub

    Public Sub AddColumn(ByVal Libelle As String, ByVal Champs As String, ByVal Largeur As Integer, Optional ByVal Alignement As DataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft, Optional ByVal Format As String = "", Optional ByVal autosizemode As DataGridViewAutoSizeColumnMode = DataGridViewAutoSizeColumnMode.AllCells)
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

        Me.dgvListe.Columns.Add(col)
    End Sub

    Private Sub SelectLigne(ByVal r As DataGridViewRow)
        If r.DataBoundItem Is Nothing Then Exit Sub
        Dim drv As DataRowView = CType(r.DataBoundItem, DataRowView)
        If Not Cell Is Nothing Then
            Cell.Value = drv(Me.dgvListe.Columns(Me.nColSelected).DataPropertyName)
        End If
        Me.Resultat = drv(Me.nColSelected)
        Me.Close()
    End Sub
#End Region

End Class

Public Class ListViewColumnSorter
    Implements IComparer

    Private ObjectCompare As CaseInsensitiveComparer
    Private columnToSort As Integer
    Private orderOfSort As SortOrder

#Region "Propriétés"
    Public Property SortColumn() As Integer
        Get
            Return columnToSort
        End Get
        Set(ByVal value As Integer)
            columnToSort = value
        End Set
    End Property

    Public Property Order() As SortOrder
        Get
            Return orderOfSort
        End Get
        Set(ByVal value As SortOrder)
            orderOfSort = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        columnToSort = 0
        orderOfSort = SortOrder.None
        ObjectCompare = New CaseInsensitiveComparer
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX As ListViewItem = CType(x, ListViewItem)
        Dim listviewY As ListViewItem = CType(y, ListViewItem)
        ' Compare les deux éléments
        compareResult = ObjectCompare.Compare(listviewX.SubItems(columnToSort).Text, listviewY.SubItems(columnToSort).Text)

        ' Calcule la valeur correcte d'après la comparaison d'objets
        If orderOfSort = SortOrder.Ascending Then
            'Le tri croissant est sélectionné, renvoie des résultats normaux de comparaison
            Return compareResult
        ElseIf orderOfSort = SortOrder.Descending Then
            'Le tri décroissant est sélectionné, renvoie des résultats négatifs de comparaison
            Return -compareResult
        Else
            'Renvoie '0' pour indiquer qu'ils sont égaux
            Return 0
        End If
    End Function
#End Region

End Class




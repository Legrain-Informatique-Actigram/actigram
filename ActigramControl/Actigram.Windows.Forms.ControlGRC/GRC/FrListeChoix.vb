Public Class FrListeChoix

#Region "Props"

    Private _auto As Autorisations
    Public Property Autorisations() As Autorisations
        Get
            Return _auto
        End Get
        Set(ByVal value As Autorisations)
            _auto = value
        End Set
    End Property

    Private _nomChoix As String
    Public Property NomChoix() As String
        Get
            Return _nomChoix
        End Get
        Set(ByVal value As String)
            _nomChoix = value
        End Set
    End Property


    Private _datasource As DataTable
    Public Property Datasource() As DataTable
        Get
            Return _datasource
        End Get
        Set(ByVal value As DataTable)
            _datasource = value
        End Set
    End Property

    Private ReadOnly Property CurrentChoixRow() As DataRow
        Get
            If Me.ListeChoixBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(Me.ListeChoixBindingSource.Current, DataRowView).Row
            End If
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal type As String)
        Me.New()
        Me.NomChoix = type
    End Sub
#End Region

#Region "Donnnées"
    Private modif As Boolean
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()
            With Me.Datasource
                .Columns("NomChoix").DefaultValue = Me.NomChoix
                Dim maxOrdre As Object = .Compute("max(nOrdreValeur)", "")
                If IsDBNull(maxOrdre) Then maxOrdre = 0
                With .Columns("nOrdreValeur")
                    .AutoIncrement = True
                    .AutoIncrementSeed = CInt(maxOrdre) + 1
                    .AutoIncrementStep = 1
                End With
            End With
            Databinding()
            modif = False
        Finally
            Cursor.Current = Cursors.Default
            Application.DoEvents()
        End Try
    End Sub

    Public Sub Databinding()
        Me.ds = Me.Datasource.DataSet
        Me.ListeChoixBindingSource.DataSource = ds
        Me.ListeChoixBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixBindingSource.Filter = "NomChoix='" & Me.NomChoix & "'"
        Me.ListeChoixBindingSource.Sort = "nOrdreValeur"
        If Me.Autorisations IsNot Nothing Then
            Me.ListeChoixDataGridView.AllowUserToAddRows = Me.Autorisations.Ajt
            Me.ListeChoixDataGridView.AllowUserToDeleteRows = Me.Autorisations.Suppr
            Me.ListeChoixDataGridView.ReadOnly = Not Me.Autorisations.Modif
            Me.BindingNavigator1.AddNewItem.Visible = Me.Autorisations.Ajt
            Me.TbOrdreMoins.Visible = Me.Autorisations.Modif
            Me.TbOrdrePlus.Visible = Me.Autorisations.Modif
        End If
    End Sub


    Private Sub Enregistrer()
        Me.Validate()
        Me.ListeChoixBindingSource.EndEdit()
        If Me.Datasource.GetChanges IsNot Nothing Then
            modif = True
        End If
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.ListeChoixBindingSource.EndEdit()
        If Me.Datasource.GetChanges IsNot Nothing Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function
#End Region

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If modif Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim fr As New Form
        If fr.Icon.Handle.Equals(Me.Icon.Handle) Then
            Dim frParent As Form = Me.MdiParent
            If frParent Is Nothing Then
                frParent = Me.Owner
            End If
            If Not frParent Is Nothing Then
                Me.Icon = CType(frParent.Icon.Clone, Icon)
            End If
        End If
        ApplyStyle(Me.ListeChoixDataGridView, False)
        ChargerDonnees()
    End Sub


    Private Sub ChangeOrdre(ByVal incr As Integer)
        'Test aux limites
        If Me.ListeChoixBindingSource.Position = 0 AndAlso incr < 0 Then Exit Sub
        If Me.ListeChoixBindingSource.Position = Me.ListeChoixBindingSource.Count - 1 AndAlso incr > 0 Then Exit Sub

        Dim switchRow As DataRow = (CType(Me.ListeChoixBindingSource.Item(Me.ListeChoixBindingSource.Position + incr), DataRowView).Row)
        Dim oldValeur As Object = Me.CurrentChoixRow("Valeur")
        Me.CurrentChoixRow("Valeur") = switchRow("Valeur")
        switchRow("Valeur") = oldValeur
        Me.ListeChoixBindingSource.Position += incr
        Me.ListeChoixDataGridView.Refresh()
    End Sub

    Private Sub TbOrdrePlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbOrdrePlus.Click
        ChangeOrdre(1)
    End Sub

    Private Sub TbOrdreMoins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbOrdreMoins.Click
        ChangeOrdre(-1)
    End Sub
End Class
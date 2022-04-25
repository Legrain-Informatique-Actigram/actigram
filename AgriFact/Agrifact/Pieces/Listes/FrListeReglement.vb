Public Class FrListeReglement

    Public Enum TypeReglement
        Vente
        Achat
    End Enum

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal type As TypeReglement)
        Me.New()
        Me.TypeRegl = type
    End Sub
#End Region

#Region "Props"
    Private _filtre As String
    Public Property FiltrePlus() As String
        Get
            Return _filtre
        End Get
        Set(ByVal value As String)
            _filtre = value
        End Set
    End Property

    Private _type As TypeReglement = TypeReglement.Vente
    Public Property TypeRegl() As TypeReglement
        Get
            Return _type
        End Get
        Set(ByVal value As TypeReglement)
            _type = value
        End Set
    End Property

    Public ReadOnly Property CurrentReglRow() As DsPieces.ReglementRow
        Get
            If Me.ReglementBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DsPieces.ReglementRow)(Cast(Of DataRowView)(Me.ReglementBindingSource.Current).Row)
        End Get
    End Property
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Application.DoEvents()

            Dim curId As Decimal = -1
            If Me.ReglementBindingSource.Position >= 0 Then
                curId = Me.CurrentReglRow.nReglement
            End If

            With Me.DsPieces
                .EnforceConstraints = False
                If Me.TypeRegl = TypeReglement.Achat Then
                    Me.ReglementTA.FillAchat(.Reglement)
                Else
                    Me.ReglementTA.FillVente(.Reglement)
                End If
                .EnforceConstraints = True
            End With

            If curId > -1 Then
                Me.ReglementBindingSource.Position = Me.ReglementBindingSource.Find("nReglement", curId)
            End If
            CalculerTotal()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    'Private Sub Enregistrer()
    '    Me.Validate()
    '    Me.ReglementBindingSource.EndEdit()
    '    If Me.DsPieces.HasChanges Then
    '        Try
    '            Me.ReglementTA.Update(Me.DsPieces.Remise)
    '        Catch ex As SqlClient.SqlException
    '            SqlProxy.GererSqlException(ex)
    '        End Try
    '    End If
    '    MajBoutons()
    'End Sub

    'Private Function DemanderEnregistrement() As Boolean
    '    Me.Validate()
    '    Me.ReglementBindingSource.EndEdit()
    '    If Me.DsPieces.HasChanges Then
    '        Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
    '            Case MsgBoxResult.Yes
    '                Enregistrer()
    '            Case MsgBoxResult.No
    '            Case MsgBoxResult.Cancel
    '                Return False
    '        End Select
    '    End If
    '    Return True
    'End Function
#End Region

#Region "Toolbar"
    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    'Private Sub RemisBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemiseBindingNavigatorSaveItem.Click
    '    Enregistrer()
    'End Sub

    Private _customFilter As Boolean = False
    Private Sub TbFiltrer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFiltrer.CheckedChanged
        If Not TbFiltrer.Checked Then
            _customFilter = False
            Me.ReglementBindingSource.Filter = ""
        Else
            If Not _customFilter Then Me.ReglementBindingSource.Filter = "Depose=False"
        End If
        CalculerTotal()
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.ReglementBindingSource.Position >= 0 Then
            Me.ReglementBindingSource.EndEdit()
        End If
        GestionControles.FillTablesConfig(Me.DsPieces)
        Dim myFrRecherche As New GRC.FrRecherche(Me.DsPieces, "Reglement")
        AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        _customFilter = True
        Me.ReglementBindingSource.Filter = strCritere
        CalculerTotal()
        TbFiltrer.Checked = True
    End Sub

    Private Sub TbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        CreateNewReglement()
    End Sub

    Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImprimer.Click
        ImprimerListe()
    End Sub

    Private Sub TbDeposer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDeposer.Click
        Deposer()
    End Sub
#End Region

    'Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If e.CloseReason = CloseReason.UserClosing Then
    '        If DemanderEnregistrement() Then
    '        Else
    '            e.Cancel = True
    '        End If
    '    End If
    'End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.ReglDataGridView)
        ConfigColSel(Me.ReglDataGridView, Me.ColSel)
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsPieces.Reglement, Nothing)
        If Not String.IsNullOrEmpty(Me.FiltrePlus) Then
            Me.ReglementBindingSource.Filter = Me.FiltrePlus
            CalculerTotal()
        End If
        If Me.TypeRegl = TypeReglement.Achat Then
            Me.Payeur.HeaderText = "Fournisseur"
            Me.Text = "Liste des règlements - Fournisseurs"
            Me.TbDeposer.Visible = False
        Else
            Me.Text = "Liste des règlements - Clients"
            Me.TbDeposer.Visible = True
        End If
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.RemiseBindingNavigatorSaveItem.Enabled = Me.DsPieces.HasChanges
    End Sub

#Region " Control events "
    Private Sub RemiseDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ReglDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenCurrentReglement()
            e.Handled = True
        End If
    End Sub

    Private Sub RemiseDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ReglDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        OpenCurrentReglement()
    End Sub

    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then ChargerDonnees()
        End Select
    End Sub
#End Region

    Private Sub CreateNewReglement()
        Dim fr As New FrReglement()
        fr.TypeRegl = Me.TypeRegl
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        fr.ShowDialog()
    End Sub

    Private Sub OpenCurrentReglement()
        If Me.ReglementBindingSource.Position < 0 Then Exit Sub
        Dim fr As New FrReglement(CInt(Me.CurrentReglRow.nReglement))
        fr.TypeRegl = Me.TypeRegl
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        If Me.MdiParent IsNot Nothing Then
            fr.MdiParent = Me.MdiParent
            fr.WindowState = Me.WindowState
        End If
        fr.Show()
    End Sub

    Private Function ReglNotDepose(ByVal dr As DataRow) As Boolean
        Return dr.IsNull("Depose") OrElse CBool(dr("Depose")) = False
    End Function

    Private Sub Deposer()
        Dim lstFacture As List(Of DataRow) = GetSelectedRows(Me.ReglDataGridView)
        Dim ok As Boolean = True
        If Not lstFacture.TrueForAll(AddressOf ReglNotDepose) Then
            MsgBox("Vous ne devez sélectionner que des réglements non déposés", MsgBoxStyle.Exclamation)
        Else
            With New FrRemise(lstFacture)
                AddHandler .FormClosed, AddressOf ChildForm_Closed
                .ShowDialog(Me)
            End With
        End If        
    End Sub

    Private Sub ImprimerListe()
        Dim nomTable As String = CStr(IIf(Me.TypeRegl = TypeReglement.Achat, "AReglement", "Reglement"))
        Dim nomTableF As String = CStr(IIf(Me.TypeRegl = TypeReglement.Achat, "AFacture", "VFacture"))
        Dim myDs As DataSet = DsPieces.Clone
        With myDs
            .EnforceConstraints = False
            Dim drs As List(Of DataRow) = GetSelectedRows(Me.ReglDataGridView)
            If drs.Count = 0 Then
                .Merge(Me.DsPieces.Reglement.Select(Me.ReglementBindingSource.Filter))
            Else
                .Merge(drs.ToArray)
            End If
            .Tables("Reglement").TableName = nomTable
            Dim nRegls As New List(Of String)
            For Each dr As DataRow In myDs.Tables(nomTable).Rows
                nRegls.Add(Convert.ToString(dr("nReglement")))
            Next
            If nRegls.Count = 0 Then Exit Sub
            Dim where As String = " nReglement IN (" & String.Join(",", nRegls.ToArray) & ")"
            Using s As New SqlProxy
                DefinitionDonnees.Instance.Fill(myDs, nomTable & "_Detail", s, where)
                DefinitionDonnees.Instance.Fill(myDs, "Entreprise", s, String.Format("nEntreprise IN (SELECT nEntreprise FROM {0} WHERE {1})", nomTable, where))
                DefinitionDonnees.Instance.Fill(myDs, nomTableF, s, String.Format("nDevis IN (SELECT nDevis FROM {0}_Detail WHERE {1})", nomTable, where))
            End Using
        End With
        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListe" & nomTable & ".rpt")
        fr.Show()
    End Sub

    Private Sub CalculerTotal()
        Dim res As Object = Me.DsPieces.Reglement.Compute("Sum(Montant)", ReglementBindingSource.Filter)
        If Not IsDBNull(res) Then
            Me.lbTotal.Text = String.Format("Total : {0:C2}", res)
        Else
            Me.lbTotal.Text = ""
        End If
    End Sub

End Class
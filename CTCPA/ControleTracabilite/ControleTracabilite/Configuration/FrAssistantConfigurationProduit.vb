Public Class FrAssistantConfigurationProduit

#Region "Propriétés"
    Private _codeProduit As String
    Public Property CodeProduit() As String
        Get
            Return _codeProduit
        End Get
        Set(ByVal value As String)
            _codeProduit = value
        End Set
    End Property

    Private _matPrem As Boolean
    Public Property MatierePremiere() As Boolean
        Get
            Return _matPrem
        End Get
        Set(ByVal value As Boolean)
            _matPrem = value
        End Set
    End Property

    Private _prodFini As Boolean
    Public Property ProduitFini() As Boolean
        Get
            Return _prodFini
        End Get
        Set(ByVal value As Boolean)
            _prodFini = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal codeProduit As String, ByVal matPrem As Boolean, ByVal prodFini As Boolean)
        Me.New()
        Me.CodeProduit = codeProduit
        Me.MatierePremiere = matPrem
        Me.ProduitFini = prodFini
    End Sub
#End Region

#Region "Page"
    Private Sub FrAssistantConfigurationProduit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.DefinitionControleDataGridView)
        'Chargement de la liste des format
        Dim dtFormat As AgrifactTracaDataSet.CritereModeleDataTable = Nothing

        If (Me.MatierePremiere) And (Me.ProduitFini) Then
            dtFormat = CritereModeleTA.GetData()
        Else
            dtFormat = CritereModeleTA.GetFormatData(Me.MatierePremiere)
        End If

        dtFormat.AddCritereModeleRow("AUTRE FORMAT")
        dtFormat.AcceptChanges()
        Me.FormatBindingSource.DataSource = dtFormat
        'Chargement de la liste des process
        Dim dtProcess As AgrifactTracaDataSet.CritereModeleDataTable = Nothing

        If (Me.MatierePremiere) And (Me.ProduitFini) Then
            dtProcess = CritereModeleTA.GetData()
        Else
            dtProcess = CritereModeleTA.GetProcessData(Me.MatierePremiere)
        End If

        dtProcess.AddCritereModeleRow("AUTRE PROCESS")
        dtProcess.AcceptChanges()
        Me.ProcessBindingSource.DataSource = dtProcess
    End Sub
#End Region

#Region "Boutons"
    Private Sub wizard_CancelClick() Handles wizard.CancelClick
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub wizard_FinishClick() Handles wizard.FinishClick
        Cursor.Current = Cursors.WaitCursor
        Me.DefinitionControleTA.Update(Me.AgrifactTracaDataSet.DefinitionControle)
        Me.BaremeTA.Update(Me.AgrifactTracaDataSet.Bareme)
        Cursor.Current = Cursors.Default

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub wpResultat_Load()
        Dim process As String = ""
        Dim format As String = ""
        If lsbProcess.SelectedItem IsNot Nothing Then process = Convert.ToString(lsbProcess.SelectedValue)
        If lsbFormat.SelectedItem IsNot Nothing Then format = Convert.ToString(lsbFormat.SelectedValue)
        Me.ModeleDefinitionControleTA.FillByProcessAndFormat(Me.AgrifactTracaDataSet.ModeleDefinitionControle, Me.MatierePremiere, process, format)
        Me.ModeleBaremeTA.FillByProcessAndFormat(Me.AgrifactTracaDataSet.ModeleBareme, Me.MatierePremiere, process, format)

        Me.DefinitionControleBindingSource.SuspendBinding()
        Me.AgrifactTracaDataSet.DefinitionControle.Clear()
        Me.AgrifactTracaDataSet.Bareme.Clear()
        Dim nOrdre As Integer = 0
        For Each drC As AgrifactTracaDataSet.ModeleDefinitionControleRow In Me.AgrifactTracaDataSet.ModeleDefinitionControle.Select("", "Ordre")
            nOrdre += 1
            Dim newDrC As AgrifactTracaDataSet.DefinitionControleRow = Me.AgrifactTracaDataSet.DefinitionControle.NewDefinitionControleRow
            With newDrC
                .CodeProduit = Me.CodeProduit
                .IdControle = drC.IdControle
                .Ordre = nOrdre
                If Not drC.IsGroupeNull Then .Groupe = drC.Groupe
                If Not drC.IsLibelleNull Then .Libelle = drC.Libelle
                If Not drC.IsTypeNull Then .Type = drC.Type
                If Not drC.IsValeursDefautNull Then .ValeursDefaut = drC.ValeursDefaut
                If Not drC.IsValeursPossiblesNull Then .ValeursPossibles = drC.ValeursPossibles
            End With
            Me.AgrifactTracaDataSet.DefinitionControle.Rows.Add(newDrC)
            For Each drB As AgrifactTracaDataSet.ModeleBaremeRow In drC.GetModeleBaremeRows
                Dim newDrB As AgrifactTracaDataSet.BaremeRow = Me.AgrifactTracaDataSet.Bareme.NewBaremeRow
                With newDrB
                    .nControle = newDrC.nControle
                    .ResultatConformite = drB.ResultatConformite
                    If Not drB.IsExpressionNull Then .Expression = drB.Expression
                    If Not drB.IsCheminDocNull Then .CheminDoc = drB.CheminDoc
                    If Not drB.IsActionCorrectiveNull Then .ActionCorrective = drB.ActionCorrective
                End With
                Me.AgrifactTracaDataSet.Bareme.Rows.Add(newDrB)
            Next
        Next
        Me.DefinitionControleBindingSource.ResumeBinding()
    End Sub
#End Region

    Private Sub wizard_OnMoveNext(ByVal NextWizPanel As GNWizardFrameWork.WizardPage) Handles wizard.OnMoveNext
        If NextWizPanel Is wpChoixFormat Then
        ElseIf NextWizPanel Is wpProcess Then
        ElseIf NextWizPanel Is wpResultat Then
            wpResultat_Load()
        End If
    End Sub

End Class
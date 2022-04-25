Public Class FrDupliquerLot

    Private _nLotADupliquer As String

#Region "Propri�t�s"
    Public Property nLotADupliquer() As String
        Get
            Return Me._nLotADupliquer
        End Get
        Set(ByVal value As String)
            Me._nLotADupliquer = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal nLotADupliquer As String)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent().
        Me._nLotADupliquer = nLotADupliquer
    End Sub
#End Region

#Region "Form"
    Private Sub FrDupliquerLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (String.IsNullOrEmpty(Me.nLotADupliquer)) Then
            Me.Text = Me.Text & " - " & "Lot n� " & Me.nLotADupliquer
        End If

        Me.DateCreationDateTimePicker.Value = Now
    End Sub
#End Region

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (Me.DupliquerLot()) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
#End Region

#Region "M�thodes diverses"
    Private Function DupliquerLot() As Boolean
        'V�rifie que le num�ro de lot est renseign�
        If String.IsNullOrEmpty(Me.nLotTextBox.Text) Then
            MsgBox("Veuillez saisir un num�ro de lot.", MsgBoxStyle.Exclamation, "")

            Return False
        End If

        Using LotTA As New StocksDataSetTableAdapters.LotTA
            Using LotProduitTA As New StocksDataSetTableAdapters.LotProduitTableAdapter
                'V�rifie que le num�ro de lot n'existe pas d�j�
                If (Me.nLotExiste(Me.nLotTextBox.Text, LotTA)) Then
                    MsgBox("Duplication impossible : le num�ro de lot saisi existe d�j�. ", MsgBoxStyle.Exclamation, "")

                    Me.nLotTextBox.Focus()

                    Return False
                End If

                Dim StocksDS As New StocksDataSet

                'Cr�ation du nouveau lot
                Dim LotDR As StocksDataSet.LotRow = StocksDS.Lot.NewLotRow

                LotDR.nLot = Me.nLotTextBox.Text
                LotDR.DateCreation = Me.DateCreationDateTimePicker.Value

                If Not (String.IsNullOrEmpty(Me.ObservationTextBox.Text)) Then
                    LotDR.Observation = Me.ObservationTextBox.Text
                End If

                StocksDS.Lot.AddLotRow(LotDR)

                'Duplication des produits associ�s au lot � dupliquer
                Me.DupliquerProduits(Me.nLotADupliquer, Me.nLotTextBox.Text, LotProduitTA, StocksDS)

                'Mise � jour dans la base de donn�es
                LotTA.Update(StocksDS.Lot)
                LotProduitTA.Update(StocksDS.LotProduit)
            End Using
        End Using

        MsgBox("Duplication du lot termin�e.", MsgBoxStyle.Information, "")

        Return True
    End Function

    Private Function nLotExiste(ByVal nLot As String, ByVal LotTA As StocksDataSetTableAdapters.LotTA) As Boolean
        Dim lotDT As StocksDataSet.LotDataTable = LotTA.GetDataBynLot(nLot)

        If (lotDT.Rows.Count > 0) Then
            Return True
        End If

        Return False
    End Function

    Private Sub DupliquerProduits(ByVal nLotADupliquer As String, ByVal nLotACreer As String, _
                                ByVal LotProduitTA As StocksDataSetTableAdapters.LotProduitTableAdapter, _
                                ByVal StocksDS As StocksDataSet)

        'R�cup�ration des infos des produits associ� au lot � dupliquer
        Dim LotProduitDT As StocksDataSet.LotProduitDataTable = LotProduitTA.GetDataBynLot(nLotADupliquer)

        For Each LotProduitADupliquerDR As StocksDataSet.LotProduitRow In LotProduitDT.Rows
            Dim LotProduitACreerDR As StocksDataSet.LotProduitRow = StocksDS.LotProduit.NewLotProduitRow

            LotProduitACreerDR.nLot = nLotACreer
            LotProduitACreerDR.CodeProduit = LotProduitADupliquerDR.CodeProduit
            LotProduitACreerDR.DateCreation = Now

            StocksDS.LotProduit.AddLotProduitRow(LotProduitACreerDR)
        Next
    End Sub
#End Region

End Class
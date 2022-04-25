Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class FrSearchPiece

#Region "Page"
    Private Sub FrSearchPiece_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer = 0

        SetChildFormIcon(Me)
        ConfigNumericControl(txtPieceStart)
        ConfigNumericControl(txtPieceEnd)

        With My.Dossier.Principal
            txtPieceStart.Text = "1"
            txtPieceEnd.Text = ""

            Using dta As New dbDonneesDataSetTableAdapters.PiecesTableAdapter
                txtPieceEnd.Text = dta.GetNumMaxPiecePeriodeByDossier(My.User.Name, .DateDebutEx, .DateFinEx).ToString

                If txtPieceEnd.Text = "" Then
                    txtPieceStart.Text = "0"
                    txtPieceEnd.Text = "0"
                End If
            End Using

            dtpDateStart.Value = .DateDebutEx
            dtpDateStart.MinDate = .DateDebutEx
            dtpDateStart.MaxDate = .DateFinEx
            dtpDateEnd.Value = .DateFinEx
            dtpDateEnd.MinDate = .DateDebutEx
            dtpDateEnd.MaxDate = .DateFinEx
        End With

        txtPieceStart.SelectAll()

        'Remplissage de la liste des journaux
        Me.ListBoxJournaux.DataSource = Me.ListeCodesLibellesJournaux()

        'Sélection de tous les journaux de la liste
        For i = 0 To Me.ListBoxJournaux.Items.Count - 1
            Me.ListBoxJournaux.SetSelected(i, True)
        Next
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim xTempParentForm As FrVisuPiece = CType(Me.Owner, FrVisuPiece)
        Dim hstData As New Hashtable

        hstData.Add("DateDebut", dtpDateStart.Value.Date)
        hstData.Add("DateFin", dtpDateEnd.Value.Date)
        hstData.Add("PieceDebut", txtPieceStart.Text)
        hstData.Add("PieceFin", txtPieceEnd.Text)

        If rbtDate.Checked = True Then
            hstData.Add("Ordre", "DATE")
        Else
            hstData.Add("Ordre", "PIECE")
        End If

        'Récupération de la liste des Codes Journaux sélectionnés
        Dim listeCodesJournaux As List(Of String) = Me.ListeCodesJournauxSelectionnes()

        'Ajout des simples cotes au début et à la fin du code journal
        Dim journaux As New List(Of String)

        For Each codeJournal As String In listeCodesJournaux
            journaux.Add("'" & codeJournal & "'")
        Next

        hstData.Add("Journal", String.Join(",", journaux.ToArray))
        xTempParentForm.SearchData = hstData
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function ListeCodesLibellesJournaux() As List(Of String)
        Dim journaux As New List(Of String)

        'Récupération de la liste des journaux utilisés dans les Pieces
        Dim sqlSelect As String = String.Empty

        sqlSelect = "SELECT Journal FROM Pieces GROUP BY Journal"

        Using oleDbConnection As New OleDbConnection(My.Settings.dbDonneesConnectionString)
            Dim oleDbCommand As New OleDbCommand(sqlSelect, oleDbConnection)

            oleDbConnection.Open()

            Dim oleDbDataReader As OleDbDataReader = oleDbCommand.ExecuteReader()

            Try
                Using dtaJournal As New dbDonneesDataSetTableAdapters.JournalTableAdapter
                    While oleDbDataReader.Read()
                        If Not (IsDBNull(oleDbDataReader("Journal"))) Then
                            Dim dataTableJournal As dbDonneesDataSet.JournalDataTable = dtaJournal.GetDataByCodeJournal(oleDbDataReader("Journal").ToString())

                            For Each dataRowJournal As dbDonneesDataSet.JournalRow In dataTableJournal.Rows
                                If Not (dataRowJournal.IsJCodeLibelleNull) Then
                                    journaux.Add(String.Format("{0}", dataRowJournal.JCodeLibelle))
                                End If
                            Next
                        End If
                    End While
                End Using
            Finally
                oleDbDataReader.Close()
            End Try
        End Using

        Return journaux
    End Function

    Private Function ListeCodesJournauxSelectionnes() As List(Of String)
        Dim listeCodesJournaux As New List(Of String)
        Dim listeCodesLibellesJournaux As ListBox.SelectedObjectCollection = Me.ListBoxJournaux.SelectedItems

        For Each codeLibelleJournal As String In listeCodesLibellesJournaux
            Using dtaJournal As New dbDonneesDataSetTableAdapters.JournalTableAdapter
                Dim dataTableJournal As dbDonneesDataSet.JournalDataTable = dtaJournal.GetDataByCodeLibelle(codeLibelleJournal)

                For Each dataRowJournal As dbDonneesDataSet.JournalRow In dataTableJournal.Rows
                    listeCodesJournaux.Add(dataRowJournal.JCodeJournal)
                Next
            End Using
        Next

        Return listeCodesJournaux
    End Function
#End Region

    Private Sub txtPieceStart_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPieceStart.Validated, txtPieceEnd.Validated
        rbtPiece.Checked = True
    End Sub

    Private Sub dtpDateStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateStart.ValueChanged, dtpDateEnd.ValueChanged
        rbtDate.Checked = True
    End Sub

End Class

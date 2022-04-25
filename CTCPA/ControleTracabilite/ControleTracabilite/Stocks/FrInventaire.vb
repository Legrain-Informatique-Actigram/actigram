Namespace Stocks
    Public Class FrInventaire

        Private dtRecap As Date
        Private dtInv As Date
        Private depot As String
        Private gestionLot As Boolean

        Private modif As Boolean

#Region "Données"
        Private Sub ChargerInventaire()
            Using fr As New FrOptionsInventaire
                If fr.ShowDialog(Me) = Windows.Forms.DialogResult.Cancel Then Exit Sub
                dtInv = fr.DateInventaire
                depot = fr.Depot
                gestionLot = fr.GestionLot
            End Using
            dtRecap = dtInv

            Try
                Cursor.Current = Cursors.WaitCursor
                Me.InventaireBindingSource.SuspendBinding()
                ChargerInventaire(StocksDataSet, AgrifactTracaDataSet, dtInv, dtRecap, depot, gestionLot)
                Me.StocksDataSet.Inventaire.AcceptChanges()
                Me.InventaireBindingSource.ResumeBinding()
                Me.Text = String.Format("Inventaire du {0:dd/MM/yyyy} pour le dépot {1}", Me.dtInv, Me.depot)
            Finally
                Cursor.Current = Cursors.Default
            End Try
            modif = False
        End Sub

        Private Shared Sub ChargerInventaire(ByVal StocksDataSet As StocksDataSet, ByVal AgrifactTracaDataSet As AgrifactTracaDataSet, ByVal dtInv As Date, ByVal dtRecap As Date, ByVal depot As String, ByVal gestionLot As Boolean)
            If AgrifactTracaDataSet Is Nothing Then
                AgrifactTracaDataSet = New AgrifactTracaDataSet
            End If
            Using dta As New StocksDataSetTableAdapters.InventaireTA
                dta.FillInv(StocksDataSet.Inventaire, dtRecap, dtInv, depot, gestionLot)
            End Using
            'Chercher si un Inventaire existe déjà
            Using dta As New AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
                dta.FillByTypeDateDepot(AgrifactTracaDataSet.Mouvement, GestionStock.TypeMouvement.Inventaire.ToString, dtInv, depot)
            End Using
            Dim drMvt As AgrifactTracaDataSet.MouvementRow
            If AgrifactTracaDataSet.Mouvement.Count > 0 Then
                drMvt = AgrifactTracaDataSet.Mouvement(0)
                Using dta As New AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
                    dta.FillBynMouvement(AgrifactTracaDataSet.Mouvement_Detail, drMvt.nMouvement)
                End Using
            End If
            If AgrifactTracaDataSet.Mouvement_Detail.Count > 0 Then
                For Each drMD As AgrifactTracaDataSet.Mouvement_DetailRow In AgrifactTracaDataSet.Mouvement_Detail
                    Dim testNull As String
                    If drMD.IsnLotNull Then testNull = "(nLot is null or nLot='')" Else testNull = String.Format("nLot='{0}'", drMD.nLot.Replace("'", "''"))
                    Dim q As String = String.Format("CodeProduit='{0}' And {1}", drMD.CodeProduit.Replace("'", "''"), testNull)
                    Dim drInv As StocksDataSet.InventaireRow = SelectSingleRow(Of StocksDataSet.InventaireRow)(StocksDataSet.Inventaire, q, "")
                    If drInv IsNot Nothing Then
                        drInv.QteU1Depart -= drMD.Unite1
                        drInv.QteU2Depart -= drMD.Unite2
                        If dtRecap.Date = dtInv.Date Then
                            drInv.DepartU1 -= drMD.Unite1
                            drInv.DepartU2 -= drMD.Unite2
                        End If
                        If drMD.Unite1 > 0 Then
                            drInv.EntréeU1 -= drMD.Unite1
                            drInv.EntréeU2 -= drMD.Unite2
                        Else
                            drInv.SortieU1 -= drMD.Unite1
                            drInv.SortieU2 -= drMD.Unite2
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub Enregistrer()
            Me.Validate()
            Me.InventaireBindingSource.EndEdit()
            If Me.StocksDataSet.HasChanges Then
                Try
                    Cursor.Current = Cursors.WaitCursor

                    Me.AgrifactTracaDataSet.Mouvement.InitAutoIncrementSeed()
                    Me.AgrifactTracaDataSet.Mouvement_Detail.InitAutoIncrementSeed()

                    'Il faut remettre tout ca dans le mouvement
                    Dim drMvt As AgrifactTracaDataSet.MouvementRow
                    If Me.AgrifactTracaDataSet.Mouvement.Count > 0 Then
                        drMvt = Me.AgrifactTracaDataSet.Mouvement(0)
                        drMvt.DateModif = Now.Date
                        'On supprime tout pour réécrire
                        For Each dr As AgrifactTracaDataSet.Mouvement_DetailRow In drMvt.GetMouvement_DetailRows
                            dr.Delete()
                        Next
                    Else
                        drMvt = AgrifactTracaDataSet.Mouvement.NewMouvementRow
                        With drMvt
                            .nPiece = .nMouvement.ToString
                            .DateMouvement = Me.dtInv
                            .DateModif = Now.Date
                            .TypeMouvement = GestionStock.TypeMouvement.Inventaire.ToString
                            .DepotDest = Me.depot
                            .DepotDepart = ""
                            .Description = Me.Text
                        End With
                        AgrifactTracaDataSet.Mouvement.AddMouvementRow(drMvt)
                    End If

                    Dim n As Integer = 0
                    For Each drInv As StocksDataSet.InventaireRow In Me.StocksDataSet.Inventaire
                        If drInv.EcartU1 <> 0 Then
                            n += 1
                            Dim drMvtD As AgrifactTracaDataSet.Mouvement_DetailRow = AgrifactTracaDataSet.Mouvement_Detail.NewMouvement_DetailRow
                            With drMvtD
                                .nMouvement = drMvt.nMouvement
                                .nLigne = n
                                If Not drInv.IsnLotNull Then .nLot = drInv.nLot
                                .CodeProduit = drInv.CodeProduit
                                .Libelle = drInv.Libelle
                                .Unite1 = drInv.EcartU1
                                .Unite2 = drInv.EcartU2
                                If Not drInv.IsLibUnite1Null Then .LibUnite1 = drInv.LibUnite1
                                If Not drInv.IsLibUnite2Null Then .LibUnite2 = drInv.LibUnite2
                            End With
                            AgrifactTracaDataSet.Mouvement_Detail.AddMouvement_DetailRow(drMvtD)
                        End If
                    Next

                    'Enregistrement en base
                    Me.MouvementTableAdapter.Update(AgrifactTracaDataSet.Mouvement)
                    Me.Mouvement_DetailTableAdapter.Update(AgrifactTracaDataSet.Mouvement_Detail)

                    Me.StocksDataSet.Inventaire.AcceptChanges()
                    modif = True
                Finally
                    Cursor.Current = Cursors.Default
                End Try
            End If
            MajBoutons()
        End Sub

        Private Function DemanderEnregistrement() As Boolean
            Me.Validate()
            Me.InventaireBindingSource.EndEdit()
            If Me.StocksDataSet.HasChanges Then
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

#Region "Page"
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
            SetChildFormIcon(Me)
            ApplyStyle(Me.InventaireDataGridView, False)
            ChargerInventaire()
            ConfigDataTableEvents(Me.StocksDataSet.Inventaire, AddressOf MajBoutons)
            TxRecherche_TextChanged(Nothing, Nothing)
            MajBoutons()
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
            MajBoutons()
        End Sub

        Private Sub MajBoutons()
            TbSave.Enabled = Me.StocksDataSet.HasChanges
        End Sub
#End Region

#Region "Toolbar"
        Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
            Me.Close()
        End Sub

        Private Sub TbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSave.Click
            Enregistrer()
        End Sub

        Private Sub TbImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
            EcranCrystal.Apercu("RptInventaire", Me.StocksDataSet, Me.Text)
        End Sub

        Private Sub TbCancelFiltre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCancelFiltre.Click
            TxRecherche.Text = ""
            TxRecherche.Focus()
        End Sub

        Private Sub TxRecherche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRecherche.TextChanged
            Dim q As String = TxRecherche.Text.Trim
            Dim flt As String = ""
            If q.Length > 0 Then
                flt = String.Format("CodeProduit like '{0}' OR Famille like '{0}' OR Libelle like '{0}' OR nLot like '{0}'", "%" & q.Replace("'", "''") & "%")
            End If
            Me.InventaireBindingSource.Filter = flt
            Me.TbCancelFiltre.Visible = flt.Length > 0
        End Sub

        Private Sub TbCodeBarre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbCodeBarre.Click
            'Inventaire par CB
            If TbCodeBarre.Checked Then
                For Each f As Form In Me.OwnedForms
                    If TypeOf f Is FrCodeBarreInventaire Then
                        f.Close()
                    End If
                Next
                TbCodeBarre.Checked = False
            Else
                'Ouvrir une petite fenetre qui permet de bipper le code barre et de saisir la quantité
                Dim fr As New FrCodeBarreInventaire(Me.StocksDataSet)
                With fr
                    .GestionLots = Me.gestionLot
                    .TopMost = True
                    .Show(Me)
                    AddHandler .CurrentChanged, AddressOf CodeBarreCurrentChanged
                    AddHandler .FormClosed, AddressOf CodeBarreFormClosed
                End With
                TbCodeBarre.Checked = True
            End If
        End Sub

        Private Sub CodeBarreCurrentChanged(ByVal sender As Object, ByVal current As Object)
            If current Is Nothing Then Exit Sub
            If Not TypeOf current Is DataRowView Then Exit Sub
            Dim i As Integer
            For i = 0 To Me.InventaireBindingSource.Count - 1
                If Cast(Of DataRowView)(Me.InventaireBindingSource.Item(i)).Row Is Cast(Of DataRowView)(current).Row Then
                    Me.InventaireBindingSource.Position = i
                    Exit Sub
                End If
            Next
        End Sub

        Private Sub CodeBarreFormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
            TbCodeBarre.Checked = False
        End Sub
#End Region

#Region "Méthodes partagées"
        Public Shared Sub ImprimerInventaire(ByVal dtInv As Date, ByVal depot As String, Optional ByVal gestionLot As Boolean = False)
            Dim ds As New StocksDataSet
            ChargerInventaire(ds, Nothing, dtInv, dtInv, depot, gestionLot)
            Dim titre As String = String.Format("Inventaire du {0:dd/MM/yyyy} pour le dépot {1}", dtInv, depot)
            EcranCrystal.Apercu("RptInventaire", ds, titre)
        End Sub
#End Region

    End Class
End Namespace
Imports PreparationCommandePocket.SvcAgrifact
Public Class FrLectureCodeBarre

#Region " Props "
    Private nbCartons As Integer = 0

    Private ReadOnly Property SelectedDetailRow() As DsPrepaCommande.BL_DetailRow
        Get
            Dim selectedRow As Integer = SelectedRowIndex()
            If selectedRow < 0 Then Return Nothing
            If selectedRow >= Me.BL_DetailBindingSource.Count Then Return Nothing
            Return CType(CType(Me.BL_DetailBindingSource.Item(selectedRow), Data.DataRowView).Row, DsPrepaCommande.BL_DetailRow)
        End Get
    End Property
#End Region

#Region " Form Events"
    Private Sub FrLectureCodeBarre_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If CheckModif() Then
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub FrLectureCodeBarre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TbAnnuler.Enabled = False
        Me.TbActualiser.Enabled = False
        Me.TbEnregistrer.Enabled = False
        Me.TbEdit.Enabled = True
        ToggleFiltre(Me.TbFilter.Pushed)
        ds = New DsPrepaCommande
        Me.BLBindingSource.DataSource = ds.BL
        Me.BL_DetailBindingSource.DataSource = ds.BL_Detail
        TxCB.Text = ""
        TxCB.Focus()
        FormatNbCartons()
    End Sub

    Private Sub FormatNbCartons()
        If Me.BLBindingSource.Count = 0 Then
            Me.lbNbCartons.Text = ""
        Else
            Me.lbNbCartons.Text = String.Format("Cartons : {0}", nbCartons)
        End If
    End Sub
#End Region

#Region " Control Events "
    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        If e.Button Is Me.TbActualiser Then
            If curNDevisBL <> -1 Then ChargerBL(curNDevisBL)
        ElseIf e.Button Is Me.TbEnregistrer Then
            UpdateData()
        ElseIf e.Button Is Me.TbAnnuler Then
            UndoHisto()
        ElseIf e.Button Is Me.TbEdit Then
            EditLigne()
        ElseIf e.Button Is Me.TbFilter Then
            ToggleFiltre(Me.TbFilter.Pushed)
        ElseIf e.Button Is Me.TbSoustraction Then
            ToggleModeSoustraction(Me.TbSoustraction.Pushed)
        ElseIf e.Button Is Me.TbExit Then
            Me.Close()
        End If
    End Sub

    Private Sub FrLectureCodeBarre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        With TxCB
            If Not .Focused Then
                .Focus()
                .Text &= Chr(e.KeyCode)
                .SelectionStart = .Text.Length
            End If
        End With
    End Sub

    Private Sub TxCB_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxCB.KeyUp
        If e.KeyCode = Keys.Return OrElse e.KeyCode = Keys.S Then
            Dim str As String = String.Empty

            If (TxCB.Text.Length > 0) Then
                If e.KeyCode = Keys.Return Then
                    str = TxCB.Text
                Else
                    str = TxCB.Text.Substring(0, TxCB.Text.Length - 1)
                End If

                TxCB.Text = ""

                'If CodeBarre.IsCodeBarre(str) Then TraiterCodeBarre(str)
                TraiterCodeBarre(str)
            End If
        End If
    End Sub

    Private Sub TxCB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxCB.TextChanged
        If TxCB.Text.Length = 0 Then Exit Sub

        If TxCB.Text.EndsWith(My.Resources.EOCodeChar) Then
            Dim str As String = TxCB.Text.Substring(0, TxCB.Text.Length - 1)

            TxCB.Text = ""

            'If CodeBarre.IsCodeBarre(str) Then TraiterCodeBarre(str)
            TraiterCodeBarre(str)
        End If
    End Sub

    Private Sub ToggleFiltre(ByVal filterOn As Boolean)
        If filterOn Then
            Dim codes As New List(Of String)
            Dim dic As Dictionary(Of String, Decimal) = GetQteRestantes()
            If dic Is Nothing Then Exit Sub
            For Each code As String In dic.Keys
                codes.Add(code.Replace("'", "''"))
            Next
            Me.BL_DetailBindingSource.Filter = String.Format("CodeProduit IN ('{0}')", String.Join("','", codes.ToArray))
        Else
            Me.BL_DetailBindingSource.Filter = ""
        End If
    End Sub

    Private _modeSoustraction As Boolean = False
    Private Sub ToggleModeSoustraction(ByVal soustOn As Boolean)
        _modeSoustraction = soustOn
        Panel1.BackColor = CType(IIf(soustOn, Color.Red, SystemColors.Control), Color)
    End Sub

    Private Sub TraiterCodeBarre(ByVal strValeur As String)
        Try
            Dim myCb As CodeBarre = CodeBarre.Parse(strValeur)

            If TypeOf myCb Is CodeBarreBonCommande Then
                ChargerBL(CType(myCb, CodeBarreBonCommande).nBC, CType(myCb, CodeBarreBonCommande).DateBC)
            ElseIf TypeOf myCb Is CodeBarreProduit Then
                AffecterLot(CType(myCb, CodeBarreProduit))
            Else
                MsgBox("Code Barre malformé")
            End If
        Catch ex As ApplicationException
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function SelectedRowIndex() As Integer
        Dim selectedRow As Integer = -1
        For i As Integer = 0 To Me.BL_DetailBindingSource.Count - 1
            If Me.dgCommande.IsSelected(i) Then
                selectedRow = i
            End If
        Next
        Return selectedRow
    End Function
#End Region

#Region " Communication données  "

    Private curNDevisBL As Integer = -1
    Private ds As DsPrepaCommande

    Private Sub ChargerBL(ByVal nDevisBL As Integer)
        If Not CheckModif() Then Exit Sub
        'On charge le nouveau BC
        Cursor.Current = Cursors.WaitCursor
        Try
            ResetHisto()
            Me.TbActualiser.Enabled = False
            Me.TbEnregistrer.Enabled = False
            ds = My.WebServices.ServiceAgrifact.GetBLByNDevisBL(nDevisBL)
            Me.TbActualiser.Enabled = True
            If ds.BL.Rows.Count = 0 Then
                MsgBox("Bon de livraison introuvable", MsgBoxStyle.Exclamation, "Erreur")
            Else
                RefreshData()
            End If
        Catch ex As Exception
            MsgBox("L'appel à echoué : " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ChargerBL(ByVal nbc As Integer, ByVal datebc As Date)
        If Not CheckModif() Then Exit Sub
        'On charge le nouveau BC
        Cursor.Current = Cursors.WaitCursor
        Try
            ResetHisto()
            Me.TbActualiser.Enabled = False
            Me.TbEnregistrer.Enabled = False
            ds = My.WebServices.ServiceAgrifact.GetBL(nbc, datebc)
            Me.TbActualiser.Enabled = True
            If ds.BL.Rows.Count = 0 Then
                MsgBox(String.Format("Aucun bon de commande ne porte le n°{0} pour la date du {1:dd/MM/yy}", nbc, datebc), MsgBoxStyle.Exclamation, "Erreur")
            Else
                RefreshData()
            End If
        Catch ex As Exception
            MsgBox("L'appel a echoué : " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub RefreshData()
        Me.BLBindingSource.DataSource = ds.BL
        Me.BL_DetailBindingSource.DataSource = ds.BL_Detail
        If Me.ds.BL.Count > 0 Then
            With Me.ds.BL(0)
                curNDevisBL = CInt(.nDevis)
                nbCartons = .nbCartons
            End With
            'Faire le récap des quantités attendues par produit
            InitQtes()
            FormatNbCartons()
        End If
    End Sub

    Private Function CheckModif() As Boolean
        If Not ds Is Nothing Then
            If ds.HasChanges Then
                Select Case MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        UpdateData()
                    Case MsgBoxResult.Cancel
                        Return False
                End Select
            End If
        End If
        Return True
    End Function

    Private Sub UpdateData()
        If ds Is Nothing Then Exit Sub
        If Not ds.HasChanges Then Exit Sub
        'Faire une vérif de complétude de la commande
        If Not CheckCmdeComplete() Then
            If MsgBox("La commande n'est pas complète, continuer l'enregistrement ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                Exit Sub
            End If
        End If
        'Si pas complète, avertissement et permettre de continuer la saisie
        Cursor.Current = Cursors.WaitCursor
        Try
            My.WebServices.ServiceAgrifact.UpdateBL(CType(ds.GetChanges, DsPrepaCommande))
            ds.AcceptChanges()
            Me.TbEnregistrer.Enabled = ds.HasChanges
        Catch ex As Exception
            MsgBox("L'enregistrement à echoué : " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region

#Region " Edition manuelle de la ligne "
    Private Sub EditLigne()
        Dim rwDetail As DsPrepaCommande.BL_DetailRow = SelectedDetailRow
        If rwDetail IsNot Nothing Then EditLigne(rwDetail)
    End Sub

    Private Sub EditLigne(ByVal rwDetail As DsPrepaCommande.BL_DetailRow)
        Dim histo As New LectureProduit
        With histo
            .nDetailCommande = rwDetail.nDetailDevis
            .CodeProduit = rwDetail.CodeProduit
            If Not rwDetail.IsUnite1Null Then .Unite1AvantPesee = rwDetail.Unite1
            If Not rwDetail.IsNLotNull Then .NLotAvantPesee = rwDetail.NLot
        End With

        Using fr As New FrEditLigne(rwDetail)
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'Vérifier la cohérence de quantité affectée sur la commande
                Dim cancel As Boolean = False
                If QteRestante(rwDetail.CodeProduit) < 0 Then
                    cancel = (MsgBox("Vous avez affecté plus de produit que commandé. Voulez-vous continuer ?", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel)
                End If
                If cancel Then
                    rwDetail.Unite1 = histo.Unite1AvantPesee
                    rwDetail.NLot = histo.NLotAvantPesee
                Else
                    histo.Unite1 = rwDetail.Unite1
                    histo.NLot = rwDetail.NLot
                    HistoPesee.Push(histo)
                End If
                AfterAffectation()
            End If
        End Using
    End Sub
#End Region

#Region " Gestion des lignes "
    Private Sub AffecterLot(ByVal myCbProduit As CodeBarreProduit)
        Dim drBC As DsPrepaCommande.BLRow = CType(ds.BL.Rows(0), DsPrepaCommande.BLRow)
        'Utiliser la séléction de ligne dans le datagrid
        Dim rwDetail As DsPrepaCommande.BL_DetailRow = SelectedDetailRow
        If rwDetail IsNot Nothing Then
            Dim reste As Decimal = QteRestante(rwDetail.CodeProduit)
            If reste < myCbProduit.Qte Then
                If MsgBox(String.Format("La quantité commandée sera dépassée, il ne manque que {0}{1}. Voulez-vous continuer ?", reste, rwDetail.LibUnite1), MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                    Exit Sub
                End If
            End If
            AddHisto(myCbProduit, rwDetail)
            AddLot(rwDetail, myCbProduit.Lot, myCbProduit.Qte)
        Else
            Dim rw() As DsPrepaCommande.BL_DetailRow = CType(ds.BL_Detail.Select(String.Format("nDevis={0} AND  CodeBarre='{1}'", drBC.nDevis, myCbProduit.CodeProduit)), DsPrepaCommande.BL_DetailRow())
            If rw.Length = 0 Then
                MsgBox("Ce produit ne correspond à aucune ligne. Sélectionnez la ligne souhaitée pour l'affecter", MsgBoxStyle.Exclamation)
            Else
                Dim codeProduit As String = rw(0).CodeProduit
                'Vérifier qu'on a besoin de cette quantité de ce produit
                If Not _modeSoustraction Then
                    Dim reste As Decimal = QteRestante(codeProduit)
                    If reste < myCbProduit.Qte Then
                        'Sinon avertissement (non bloquant)
                        If MsgBox(String.Format("La quantité commandée sera dépassée, il ne manque que {0}{1}. Voulez-vous continuer ?", reste, rw(0).LibUnite1), MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then
                            Exit Sub
                        End If
                    End If
                End If
                'On cherche si une ligne correspond au niveau lot
                Dim traite As Boolean = False
                For Each r As DsPrepaCommande.BL_DetailRow In rw
                    If r.IsNLotNull OrElse r.NLot.Length = 0 OrElse r.NLot = myCbProduit.Lot Then
                        'On affecte le lot et/ou on ajoute la quantité à cette ligne
                        AddHisto(myCbProduit, r)
                        AddLot(r, myCbProduit.Lot, myCbProduit.Qte)
                        traite = True
                        Exit For
                    End If
                Next
                If Not _modeSoustraction AndAlso Not traite Then
                    'Cela ajoutera une ligne pour ce nouveau lot
                    AddLigneLot(rw(0), myCbProduit.Lot, myCbProduit.Qte)
                End If
            End If
        End If
    End Sub

    Private Sub AddLigneLot(ByVal rwDetail As DsPrepaCommande.BL_DetailRow, ByVal nlot As String, ByVal qte As Decimal)
        With rwDetail
            'On crée une nouvelle ligne pour stocker le nouveau lot
            Dim drN As DsPrepaCommande.BL_DetailRow = ds.BL_Detail.NewBL_DetailRow
            CopyRow(rwDetail, drN)
            drN.SetNLotNull()
            drN.Unite1 = 0
            drN.Unite2 = 0
            ds.BL_Detail.AddBL_DetailRow(drN)
            AddHisto(drN, qte, nlot)
            drN.NLot = nlot
            drN.Unite1 = qte
            CalculerU2(drN)
        End With
        nbCartons += 1
        AfterAffectation()
    End Sub

    Private Sub AddLot(ByVal rwDetail As DsPrepaCommande.BL_DetailRow, ByVal nlot As String, ByVal qte As Decimal)
        If _modeSoustraction Then
            qte = -qte
            nbCartons -= 1
        Else
            nbCartons += 1
        End If
        With rwDetail
            If .IsNLotNull OrElse .NLot.Length = 0 Then
                .Unite1 = qte
            ElseIf .NLot = nlot Then
                If .IsUnite1Null Then
                    .Unite1 = qte
                Else
                    .Unite1 += qte
                End If
            End If

            If (.IsUnite2Null) Then
                .Unite2 = 0
            Else
                CalculerU2(rwDetail)
            End If

            If _modeSoustraction AndAlso .Unite1 <= 0 Then
                .Unite1 = 0
                .Unite2 = 0
                .SetNLotNull()
            End If
            .NLot = nlot
        End With
        AfterAffectation()
    End Sub

    Private Sub CalculerU2(ByVal rwDetail As DsPrepaCommande.BL_DetailRow)
        With rwDetail
            If Not .IsU1U2IndependantNull AndAlso Not .U1U2Independant AndAlso Not .IsCoefU2Null Then
                .Unite2 = .Unite1 * .CoefU2
            End If
        End With
    End Sub

    Private Sub AfterAffectation()
        Me.BL_DetailBindingSource.ResetBindings(False)
        Me.TbEnregistrer.Enabled = ds.HasChanges
        ToggleFiltre(Me.TbFilter.Pushed)
        FormatNbCartons()
        If CheckCmdeComplete() Then
            MsgBox("La commande est complète.", MsgBoxStyle.Information)
        End If
    End Sub
#End Region

#Region " Gestion de l'historique "

    'Pour stocker l'historique des scan
    Private Structure LectureProduit
        Public nDetailCommande As Decimal
        Public CodeProduit As String
        Public Unite1 As Decimal
        Public Unite1AvantPesee As Decimal
        Public NLot As String
        Public NLotAvantPesee As String
    End Structure

    Private HistoPesee As Stack(Of LectureProduit)

    Private Sub AddHisto(ByVal rwDetail As DsPrepaCommande.BL_DetailRow, ByVal qte As Decimal, ByVal lot As String)
        If _modeSoustraction Then
            qte = -qte
        End If
        Dim maLecture As New LectureProduit
        With maLecture
            .nDetailCommande = rwDetail.nDetailDevis
            .CodeProduit = rwDetail.CodeProduit
            .Unite1 = qte
            If Not rwDetail.IsUnite1Null Then .Unite1AvantPesee = rwDetail.Unite1
            If Not rwDetail.IsNLotNull Then .NLotAvantPesee = rwDetail.NLot
            .NLot = lot
        End With
        HistoPesee.Push(maLecture)
        Me.TbAnnuler.Enabled = (HistoPesee.Count > 0)
    End Sub

    Private Sub AddHisto(ByVal myCbProduit As CodeBarreProduit, ByVal rwDetail As DsPrepaCommande.BL_DetailRow)
        AddHisto(rwDetail, myCbProduit.Qte, myCbProduit.Lot)
    End Sub

    Private Sub UndoHisto()
        If HistoPesee.Count = 0 Then Exit Sub
        Dim maLecture As LectureProduit = HistoPesee.Pop
        'Trouver la ligne qui va bien
        Dim rw As DsPrepaCommande.BL_DetailRow = ds.BL_Detail.FindBynDetailDevis(maLecture.nDetailCommande)
        If rw IsNot Nothing Then
            rw.Unite1 = maLecture.Unite1AvantPesee
            rw.NLot = maLecture.NLotAvantPesee
        End If
        Me.TbAnnuler.Enabled = (HistoPesee.Count > 0)
        nbCartons -= 1
    End Sub

    Private Sub ResetHisto()
        HistoPesee = New Stack(Of LectureProduit)
        Me.TbAnnuler.Enabled = False
    End Sub
#End Region

#Region " Gestion des quantités attendues "
    Private QteProduits As Dictionary(Of String, Decimal)

    Private Sub InitQtes()
        QteProduits = New Dictionary(Of String, Decimal)
        For Each dr As DsPrepaCommande.BL_DetailRow In Me.ds.BL_Detail
            If Not dr.IsUnite1Null Then
                If QteProduits.ContainsKey(dr.CodeProduit) Then
                    QteProduits(dr.CodeProduit) = QteProduits(dr.CodeProduit) + dr.Unite1
                Else
                    QteProduits.Add(dr.CodeProduit, dr.Unite1)
                End If
            End If
        Next
    End Sub

    Private Function GetQteRestantes(Optional ByVal includeZeros As Boolean = False) As Dictionary(Of String, Decimal)
        If QteProduits Is Nothing Then Return Nothing
        Dim res As New Dictionary(Of String, Decimal)
        For Each code As String In QteProduits.Keys
            Dim qte As Decimal = QteRestante(code)
            If qte <> 0 OrElse includeZeros Then
                res.Add(code, qte)
            End If
        Next
        Return res
    End Function

    Private Function QteRestante(ByVal codeProduit As String) As Decimal
        If QteProduits Is Nothing Then Exit Function
        Dim qteAttendue As Decimal = 0
        Dim qteAffectee As Decimal = 0
        If QteProduits.ContainsKey(codeProduit) Then qteAttendue = QteProduits(codeProduit)
        Dim o As Object = ds.BL_Detail.Compute("Sum(Unite1)", String.Format("CodeProduit='{0}' AND (NLot is not null) AND Nlot<>''", codeProduit.Replace("'", "''")))
        If Not IsDBNull(o) Then qteAffectee = CDec(o)
        Return qteAttendue - qteAffectee
    End Function

    Private Function CheckCmdeComplete() As Boolean
        For Each codeProduit As String In QteProduits.Keys
            Dim q As Decimal = QteRestante(codeProduit)
            If q > 0 Then
                Return False
            End If
        Next
        Return True
    End Function

#End Region

End Class

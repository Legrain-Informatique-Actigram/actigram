''' <summary>
''' permet de faire les réaffectation de compte
''' </summary>
''' <remarks></remarks>
Public Class FrManagerCompte
    'TODO EXTERNALISATION ET CORRECTION MESSAGES

    Private _DataFile As DataTable
    ''' <summary>
    ''' datatable de données brute rentrante
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataFile() As DataTable
        Get
            Return _DataFile
        End Get
        Set(ByVal value As DataTable)
            _DataFile = value
        End Set
    End Property

    Private _DataCompte As DataTable
    ''' <summary>
    ''' datatable de sortie avec les données nettoyé
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataCompte() As DataTable
        Get
            Return _DataCompte
        End Get
        Set(ByVal value As DataTable)
            _DataCompte = value
        End Set
    End Property

    Private bCharger As Boolean = False
    ''' <summary>
    ''' lancement
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrSaisieBalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.PlanTypeTableAdapter.Fill(Me.DsPLC.PlanType)
            With dgvSaisie
                AddHandler .DataError, AddressOf dg_DataError
            End With

            bCharger = True
            Dim dtTableExplorationCompte As New DataTable
            If _DataFile Is Nothing Then
                'Chargement de la fenetre pour une saisie de balance
                dtTableExplorationCompte = New DataTable
                dtTableExplorationCompte.Columns.Add("Compte", GetType(String))
                dtTableExplorationCompte.Columns.Add("LibelleCompte", GetType(String))
                dtTableExplorationCompte.Columns.Add("Debit", GetType(Decimal))
                dtTableExplorationCompte.Columns.Add("Credit", GetType(Decimal))
                dgvSaisie.Columns.Remove(dgvAvant.Name)
            Else
                'chargement de la fenetre pour une saisie pré établi par un fichier
                dtTableExplorationCompte.Columns.Add("Avant", GetType(String))
                dtTableExplorationCompte.Columns.Add("Compte", GetType(String))
                dtTableExplorationCompte.Columns.Add("LibelleCompte", GetType(String))
                dgvSaisie.Columns.Remove(dgvDebit.Name)
                dgvSaisie.Columns.Remove(dgvCredit.Name)
                dgvSaisie.AllowUserToAddRows = False
                dgvSaisie.AllowUserToDeleteRows = False

                'alimentation du tableau
                For Each xCompte As DataRow In AgriTools.SelectDistinct(_DataFile, "Compte").Rows
                    If xCompte("Compte").ToString <> "" Then
                        Dim xRow As DataRow = dtTableExplorationCompte.NewRow
                        xRow("Avant") = xCompte("Compte").ToString
                        If Me.DsPLC.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", xCompte("Compte").ToString)).Length > 0 Then
                            xRow("Compte") = xCompte("Compte").ToString
                            xRow("LibelleCompte") = Convert.ToString(Me.DsPLC.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", xCompte("Compte").ToString))(0)("PlLib"))
                        End If
                        If _DataFile.Columns.IndexOf("LibelleCompte") <> -1 Then
                            xRow("LibelleCompte") = xCompte("LibelleCompte").ToString
                        End If
                        dtTableExplorationCompte.Rows.Add(xRow)
                    End If
                Next
            End If
            dgvSaisie.DataSource = dtTableExplorationCompte
            bCharger = False
        Catch ex As Exception
            Throw New ApplicationException("Problème de chargement de l'affectation des comptes", ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' chargement du combo dans le grid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvSaisie_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvSaisie.EditingControlShowing
        If TypeOf e.Control Is ComboBox AndAlso dgvSaisie.CurrentCell.ColumnIndex = 1 Then
            Dim cbo As ComboBox
            cbo = CType(e.Control, ComboBox)
            cbo.DropDownWidth = 300
            cbo.DropDownStyle = ComboBoxStyle.DropDown
            AddHandler cbo.PreviewKeyDown, AddressOf ComboPreviewKeyDown
            AddHandler cbo.Validating, AddressOf ValidatingCombo
            cbo.SelectedIndex = cbo.FindString(dgvSaisie.SelectedCells(0).Value.ToString.Trim)
            cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End If
    End Sub

    ''' <summary>
    ''' permet de mettre le compte apres validation de la cellule
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValidatingCombo(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Try
            If TypeOf sender Is ComboBox Then
                Dim cb As ComboBox = CType(sender, ComboBox)
                If cb Is Nothing OrElse cb.SelectedText = cb.Text Then Exit Sub
                If cb.SelectedText <> cb.Text Then
                    Dim xTempTable As DataTable = CType(dgvSaisie.DataSource, DataTable)
                    Dim sCompte As String = CType(sender, DataGridViewComboBoxEditingControl).Text
                    Dim s8Compte As String = Microsoft.VisualBasic.Left(CType(sender, DataGridViewComboBoxEditingControl).Text, 8)
                    If sCompte.Length > 8 AndAlso dgvSaisie.SelectedCells(0).Value.ToString.Trim() <> "" AndAlso dgvSaisie.SelectedCells(0).Value.ToString.Trim.Length = 8 Then
                        s8Compte = dgvSaisie.SelectedCells(0).Value.ToString()
                        sCompte = s8Compte
                    End If
                    If xTempTable IsNot Nothing AndAlso dgvSaisie.SelectedCells(0).Value.ToString <> sCompte Then
                        If Me.DsPLC.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", s8Compte)).Length = 0 AndAlso _
                        Me.DsPLC.PlanType.Select(String.Format("PlCpt='{0}'", s8Compte)).Length = 0 Then
                            MsgBox(String.Format("Vous ne pouvez pas met le compte {0} car celui-ci n'exite pas dans le plan type", sCompte), MsgBoxStyle.Critical, "Réaffectation")
                            dgvSaisie.SelectedCells(0).Value = ""
                            CType(sender, DataGridViewComboBoxEditingControl).Text = ""
                            cb.SelectedText = ""
                        Else
                            dgvSaisie.SelectedCells(0).Value = Microsoft.VisualBasic.Left(cb.Text, 8)
                            'cb.SelectedIndex = cb.FindStringExact(sCompte)
                            'xTempTable.Rows(dgvSaisie.SelectedCells(0).RowIndex)("Compte") = sCompte
                            cb.SelectedText = Microsoft.VisualBasic.Left(cb.Text, 8)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            LogMessage("erreur du l'affectation de compte : " + ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' permet de mettre le compte apres validation par enter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ComboPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)

        Try
            If TypeOf sender Is ComboBox Then
                Dim cb As ComboBox = CType(sender, ComboBox)
                If cb Is Nothing Then Exit Sub
                If e.KeyCode = Keys.Enter OrElse e.KeyCode = Keys.LButton Then
                    Dim xTempTable As DataTable = CType(dgvSaisie.DataSource, DataTable)
                    Dim sCompte As String = CType(sender, DataGridViewComboBoxEditingControl).Text
                    If sCompte.Length > 8 AndAlso dgvSaisie.SelectedCells(0).Value.ToString.Trim() <> "" AndAlso dgvSaisie.SelectedCells(0).Value.ToString.Trim.Length = 8 Then
                        sCompte = dgvSaisie.SelectedCells(0).Value.ToString()
                    End If
                    If xTempTable IsNot Nothing AndAlso dgvSaisie.SelectedCells(0).Value.ToString <> sCompte Then
                        If Me.DsPLC.PlanType.Select(String.Format("'{0}' like PlRacine+'*'", sCompte)).Length = 0 AndAlso _
                        Me.DsPLC.PlanType.Select(String.Format("PlCpt='{0}'", sCompte)).Length = 0 Then
                            MsgBox(String.Format("Vous ne pouvez pas met le compte {0} car celui-ci n'exite pas dans le plan type", sCompte), MsgBoxStyle.Critical, "Réaffectation")
                            dgvSaisie.SelectedCells(0).Value = ""
                            CType(sender, DataGridViewComboBoxEditingControl).Text = ""
                            cb.SelectedText = ""
                        Else
                            dgvSaisie.SelectedCells(0).Value = Microsoft.VisualBasic.Left(cb.Text, 8)
                            ''cb.SelectedIndex = cb.FindStringExact(sCompte)
                            'cb.SelectedText = sCompte
                            'xTempTable.Rows(dgvSaisie.SelectedCells(0).RowIndex)("Compte") = sCompte
                            'dgvSaisie.EndEdit()
                            cb.SelectedText = Microsoft.VisualBasic.Left(cb.Text, 8)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            LogMessage("erreur du l'affectation de compte : " + ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' bouton d'annulation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' bouton de validation pour retourner la liste nettoyé apres vérification 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValider.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            'Vérifie que tous les champs sont saisie
            Dim xTemp As DataTable = CType(dgvSaisie.DataSource, DataTable)
            For Each xCompte As DataRow In xTemp.Rows
                If xCompte("Compte").ToString = "" Then
                    MsgBox("Veuillez remplir tous les champs de correspondance pour les comptes", MsgBoxStyle.Critical, "Réaffectation")
                    Exit Sub
                End If
            Next
            'vérifie qu'il n'y ai pas deux fois le meme
            If AgriTools.SelectDistinct(DataFile, "Compte").Rows.Count <> AgriTools.SelectDistinct(xTemp, "Avant").Rows.Count Then
                MsgBox("Veuillez ne pas regrouper vos lignes de compte", MsgBoxStyle.Critical, "Réaffectation")
                Exit Sub
            End If
        Catch ex As Exception
            Throw New ApplicationException("Vérification de la saisie de l'affectation des champs", ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try

        _DataCompte = CType(dgvSaisie.DataSource, DataTable)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class
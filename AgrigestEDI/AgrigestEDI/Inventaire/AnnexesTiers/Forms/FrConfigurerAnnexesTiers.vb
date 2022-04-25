Public Class FrConfigurerAnnexesTiers

#Region "Form"
    Private Sub FrConfigurerAnnexesTiers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.ChargerDonnees()
    End Sub

    Private Sub FrConfigurerAnnexesTiers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "FOURCHETTE_COMPTESDataGridView"
    Private Sub FOURCHETTE_COMPTESDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles FOURCHETTE_COMPTESDataGridView.DataError

    End Sub

    Private Sub FOURCHETTE_COMPTESDataGridView_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles FOURCHETTE_COMPTESDataGridView.CellValidating
        If Not (FOURCHETTE_COMPTESDataGridView.Rows(e.RowIndex).IsNewRow) Then
            'Contrôles sur les colonnes ayant un type Nullable(Of Decimal) ou Nullable(Of Integer)
            Dim column As DataGridViewColumn = Me.FOURCHETTE_COMPTESDataGridView.Columns(e.ColumnIndex)
            Dim cell As DataGridViewCell = Me.FOURCHETTE_COMPTESDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)

            Me.ControlerColonnes(e, column, cell)

            'Formattage des comptes sur 8 positions
            If Not (String.IsNullOrEmpty(CStr(e.FormattedValue))) Then
                If (column.DataPropertyName = "COMPTE_DEB" Or column.DataPropertyName = "COMPTE_FIN") Then
                    If (e.FormattedValue.ToString().Length < 8) Then
                        Dim fourchette_ComptesDR As DataSetBaremes.FOURCHETTE_COMPTESRow = CType(CType(Me.FOURCHETTE_COMPTESBindingSource.Current, DataRowView).Row, DataSetBaremes.FOURCHETTE_COMPTESRow)
                        Dim numCompte As String = e.FormattedValue.ToString()

                        numCompte = Microsoft.VisualBasic.Left(numCompte & "00000000", 8)

                        Select Case column.DataPropertyName
                            Case "COMPTE_DEB"
                                fourchette_ComptesDR.COMPTE_DEB = numCompte
                            Case "COMPTE_FIN"
                                fourchette_ComptesDR.COMPTE_FIN = numCompte
                        End Select

                        Me.FOURCHETTE_COMPTESBindingSource.ResetBindings(False)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FOURCHETTE_COMPTESDataGridView_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles FOURCHETTE_COMPTESDataGridView.EditingControlShowing
        Dim voControl As DataGridViewTextBoxEditingControl = Nothing

        If (TypeOf (e.Control) Is DataGridViewTextBoxEditingControl) Then
            'On récupère le control TextBox de la cellule qui est édité        
            voControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'Contrôle sur les colonnes de type Nullable(Of Decimal)
            If (Me.FOURCHETTE_COMPTESDataGridView.Columns(FOURCHETTE_COMPTESDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Decimal)) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            End If

            'Contrôle sur les colonnes de type Nullable(Of Integer)
            If (Me.FOURCHETTE_COMPTESDataGridView.Columns(FOURCHETTE_COMPTESDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Integer)) Then
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
                'Débuter la gestion de l'événement KeyPress sur le contrôle
                AddHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            Else
                'Arrêter la gestion de l'événement KeyPress sur le contrôle
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            End If
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        Me.TYPE_PLAN_COMPTABLETableAdapter.Fill(Me.DataSetBaremes.TYPE_PLAN_COMPTABLE)
        Me.ACTIF_PASSIFTableAdapter.Fill(Me.DataSetBaremes.ACTIF_PASSIF)
        Me.FOURCHETTE_COMPTESTableAdapter.Fill(Me.DataSetBaremes.FOURCHETTE_COMPTES)

        Me.FOURCHETTE_COMPTESBindingSource.Sort = "COMPTE_DEB ASC"
    End Sub

    Private Function Enregistrer() As Boolean
        Me.FOURCHETTE_COMPTESBindingSource.EndEdit()

        Me.FOURCHETTE_COMPTESTableAdapter.Update(Me.DataSetBaremes.FOURCHETTE_COMPTES)

        Return True
    End Function

    Private Sub EditingControlDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caractères numériques, le point, ou la virgule        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ",")

        'On récupère le texte du TextBox 
        Dim txt As String = CType(sender, DataGridViewTextBoxEditingControl).Text

        'On s'assure que le point ou la virgule n'a été tapé qu'une fois 
        If (InStr(txt, ".") > 0 Or InStr(txt, ",") > 0) And (e.KeyChar = "." Or e.KeyChar = ",") Then
            e.KeyChar = Nothing
        Else
            'On remplace le point par une virgule ou la virgule par un point en fonction du séparateur décimal utilisé dans la culture en cours 
            Dim vsDecimalSeparator As Char

            vsDecimalSeparator = CChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)

            If vsDecimalSeparator <> "." And e.KeyChar = "." Then
                e.KeyChar = vsDecimalSeparator
            End If
        End If
    End Sub

    Private Sub EditingControlInteger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caractères numériques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub

    Private Sub ControlerColonnes(ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs, _
                                ByVal column As DataGridViewColumn, ByVal cell As DataGridViewCell)

        If (column.ValueType Is GetType(Nullable(Of Decimal))) Or _
        (column.ValueType Is GetType(Nullable(Of Integer))) Then
            If String.IsNullOrEmpty(CStr(e.FormattedValue)) Then
                cell.Value = Nothing
            End If
        End If
    End Sub
#End Region

End Class
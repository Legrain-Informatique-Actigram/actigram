Public Class FrParametrerListes

#Region "Form"
    Private Sub FrParametrerListes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.RemplirListeDataPropertyName()
        Me.ChargerDonnees()
    End Sub

    Private Sub FrParametrerListes_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (e.Cancel = True) Then
            Exit Sub
        End If

        If Not (Me.Enregistrer()) Then
            e.Cancel = True
        End If
    End Sub
#End Region

#Region "ColonneListeDataGridView"
    Private Sub ColonneListeDataGridView_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles ColonneListeDataGridView.EditingControlShowing
        Dim voControl As DataGridViewTextBoxEditingControl = Nothing

        If (TypeOf (e.Control) Is DataGridViewTextBoxEditingControl) Then
            'On r�cup�re le control TextBox de la cellule qui est �dit� 
            voControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'Contr�le sur les colonnes de type Nullable(Of Decimal)
            If (Me.ColonneListeDataGridView.Columns(ColonneListeDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Decimal)) Then
                'Arr�ter la gestion de l'�v�nement KeyPress sur le contr�le 
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
                'D�buter la gestion de l'�v�nement KeyPress sur le contr�le
                AddHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            Else
                'Arr�ter la gestion de l'�v�nement KeyPress sur le contr�le
                RemoveHandler voControl.KeyPress, AddressOf EditingControlDecimal_KeyPress
            End If

            'Contr�le sur les colonnes de type Nullable(Of Integer)
            If (Me.ColonneListeDataGridView.Columns(ColonneListeDataGridView.CurrentCell.ColumnIndex).ValueType Is GetType(Integer)) Then
                'Arr�ter la gestion de l'�v�nement KeyPress sur le contr�le
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
                'D�buter la gestion de l'�v�nement KeyPress sur le contr�le
                AddHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            Else
                'Arr�ter la gestion de l'�v�nement KeyPress sur le contr�le
                RemoveHandler voControl.KeyPress, AddressOf EditingControlInteger_KeyPress
            End If
        End If
    End Sub
#End Region

#Region "M�thodes diverses"
    Private Sub ChargerDonnees()
        Me.ColonneListeTableAdapter.Fill(Me.ColonneListeDataSet.ColonneListe)
    End Sub

    Private Function Enregistrer() As Boolean
        'Me.ColonneListeBindingSource.EndEdit()

        Me.ColonneListeTableAdapter.Update(Me.ColonneListeDataSet.ColonneListe)

        Return True
    End Function

    Private Sub EditingControlDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caract�res num�riques, le point, ou la virgule        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ",")

        'On r�cup�re le texte du TextBox 
        Dim txt As String = CType(sender, DataGridViewTextBoxEditingControl).Text

        'On s'assure que le point ou la virgule n'a �t� tap� qu'une fois 
        If (InStr(txt, ".") > 0 Or InStr(txt, ",") > 0) And (e.KeyChar = "." Or e.KeyChar = ",") Then
            e.KeyChar = Nothing
        Else
            'On remplace le point par une virgule ou la virgule par un point en fonction du s�parateur d�cimal utilis� dans la culture en cours 
            Dim vsDecimalSeparator As Char

            vsDecimalSeparator = CChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)

            If vsDecimalSeparator <> "." And e.KeyChar = "." Then
                e.KeyChar = vsDecimalSeparator
            End If
        End If
    End Sub

    Private Sub EditingControlInteger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'On accepte que les caract�res num�riques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub

    Private Sub RemplirListeDataPropertyName()
        Dim listeDataPropertyName As String = String.Empty
        Dim PiecesDT As New DsPieces.PiecesDataTable

        For Each column As DataColumn In PiecesDT.Columns
            If (column.ColumnName <> "nClient") Then
                Me.ListeDataPropertyNameListBox.Items.Add(column.ColumnName)
            End If
        Next
    End Sub
#End Region

End Class
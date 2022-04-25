Public Class FrAmtExercice

#Region "Constructeurs"
    Public Sub New(ByVal immobilisationsDS As ImmobilisationsDataSet)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me.ImmobilisationsDataSet = immobilisationsDS
    End Sub
#End Region

#Region "Form"
    Private Sub FrAmtExercice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ImmobilisationsBindingSource.DataSource = Me.ImmobilisationsDataSet
        Me.ImmobilisationsBindingSource.Filter = "(IAmtExMax <> IAmtExMin) and (ITypAmt='D')"

        If Not (Me.ImmobilisationsBindingSource.List.Count > 0) Then
            Me.IAmtExTotTextBox.Enabled = False
            Me.ValiderButton.Enabled = False
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub AnnulerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnulerButton.Click
        Me.ImmobilisationsDataSet.RejectChanges()
        Me.ImmobilisationsBindingSource.CancelEdit()
        Me.Close()
    End Sub

    Private Sub ValiderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValiderButton.Click
        Me.ImmobilisationsBindingSource.EndEdit()

        Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
            immobilisationsTA.Update(Me.ImmobilisationsDataSet)
        End Using

        MsgBox("Enregistrement effectué.", MsgBoxStyle.Information, "")

        Me.Close()
    End Sub
#End Region

#Region "IAmtExTotTextBox"
    Private Sub IAmtExTotTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles IAmtExTotTextBox.KeyPress
        'On accepte que les caractères numériques, le point, ou la virgule        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ",")

        'On récupère le texte du TextBox 
        Dim txt As String = Me.IAmtExTotTextBox.Text

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

    Private Sub IAmtExTotTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles IAmtExTotTextBox.Validating
        Dim immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow = CType(CType(Me.ImmobilisationsBindingSource.Current, DataRowView).Row, ImmobilisationsDataSet.ImmobilisationsRow)
        Dim montantAmort As Decimal = 0

        If (Microsoft.VisualBasic.IsNumeric(Me.IAmtExTotTextBox.Text)) Then
            montantAmort = CDec(Me.IAmtExTotTextBox.Text)
        Else
            Me.IAmtExTotTextBox.Text = "0"
        End If

        If Not (immobilisationsDR.IsIAmtExMinNull) Then
            If (montantAmort < immobilisationsDR.IAmtExMin) Then
                MsgBox("Veuillez saisir un montant d'amortissement supérieur ou égal au montant minimum.", MsgBoxStyle.Exclamation, "")

                e.Cancel = True

                Exit Sub
            End If
        End If

        If Not (immobilisationsDR.IsIAmtExMaxNull) Then
            If (montantAmort > immobilisationsDR.IAmtExMax) Then
                MsgBox("Veuillez saisir un montant d'amortissement inférieur ou égal au montant maximum.", MsgBoxStyle.Exclamation, "")

                e.Cancel = True

                Exit Sub
            End If
        End If
    End Sub
#End Region

End Class
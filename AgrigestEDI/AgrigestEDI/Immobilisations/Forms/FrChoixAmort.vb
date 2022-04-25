Public Class FrChoixAmort

    Private _ImmobilisationsDS As ImmobilisationsDataSet

#Region "Constructeurs"
    Public Sub New(ByVal immobilisationsDS As ImmobilisationsDataSet)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._ImmobilisationsDS = immobilisationsDS
    End Sub
#End Region

#Region "Form"
    Private Sub FrChoixAmort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AmortMaxRadioButton.Checked = True
    End Sub

    Private Sub FrChoixAmort_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Enregistrement des changements
        Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
            immobilisationsTA.Update(Me._ImmobilisationsDS)
        End Using
    End Sub
#End Region

#Region "Button"
    Private Sub ValiderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValiderButton.Click
        Dim listeImmobilisationsDR() As ImmobilisationsDataSet.ImmobilisationsRow = CType(Me._ImmobilisationsDS.Immobilisations.Select("(IAmtExMax <> IAmtExMin) AND (ITypAmt='D')", "Icpt,IActi,IOrdre"), ImmobilisationsDataSet.ImmobilisationsRow())

        If Not (listeImmobilisationsDR Is Nothing) Then
            If (listeImmobilisationsDR.Length = 0) Then
                MsgBox("Aucune immobilisation ne peut être utilisée pour cette fonction", MsgBoxStyle.Information, "")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Else
                If (Me.AmortMaxRadioButton.Checked) Then
                    'La colonne amortissement prend la valeur de l'amortissement max
                    For Each immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow In Me._ImmobilisationsDS.Immobilisations.Rows
                        If Not (immobilisationsDR.IsIAmtExMaxNull) Then
                            immobilisationsDR.IAmtExTot = immobilisationsDR.IAmtExMax
                        End If
                    Next
                End If

                If (Me.AmortMinRadioButton.Checked) Then
                    'La colonne amortissement prend la valeur de l'amortissement min
                    For Each immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow In Me._ImmobilisationsDS.Immobilisations.Rows
                        If Not (immobilisationsDR.IsIAmtExMinNull) Then
                            immobilisationsDR.IAmtExTot = immobilisationsDR.IAmtExMin
                        End If
                    Next
                End If

                If (Me.ChxAmortRadioButton.Checked) Then
                    Dim fr As New FrAmtExercice(Me._ImmobilisationsDS)

                    fr.ShowDialog(Me)
                End If

                Me.DialogResult = DialogResult.OK
            End If
        End If
    End Sub
#End Region

End Class
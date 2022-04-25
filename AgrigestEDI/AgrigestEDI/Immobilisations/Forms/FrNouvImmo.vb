Public Class FrNouvImmo

    Private _mode As Immobilisations.Immobilisation.ModeImmo

#Region "Propriétés"
    Public ReadOnly Property Mode() As Immobilisations.Immobilisation.ModeImmo
        Get
            Return _mode
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
    End Sub
#End Region

#Region "Form"
    Private Sub FrNouvImmo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AcquisExeRadioButton.Checked = True
    End Sub
#End Region

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If (My.Dossier.Principal.DateClotureCompta >= My.Dossier.Principal.DateDebutEx) And Not Me.AcquisExeRadioButton.Checked Then
            MessageBox.Show("Ce type d'immobilisation ne peut pas être créée." & vbCrLf & "La date est antérieure à la date d'arrêté.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.DialogResult = DialogResult.Cancel
            Exit Sub
        End If

        If Me.AcquisExeRadioButton.Checked Then : _mode = Immobilisations.Immobilisation.ModeImmo.Acquisition
        ElseIf Me.AAARadioButton.Checked Then : _mode = Immobilisations.Immobilisation.ModeImmo.SaisieDonneesAvecAmortAnt
        ElseIf Me.SAARadioButton.Checked Then : _mode = Immobilisations.Immobilisation.ModeImmo.SaisieDonneesSansAmortAnt
        ElseIf Me.ReelRadioButton.Checked Then : _mode = Immobilisations.Immobilisation.ModeImmo.PassageAuReel
        End If

        Me.DialogResult = DialogResult.OK
    End Sub
#End Region

End Class
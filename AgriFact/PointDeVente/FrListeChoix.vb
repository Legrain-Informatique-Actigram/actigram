Public Class FrListeChoix

    Private _NomChoix As DsAgrifactTableAdapters.ListeChoixTA.NomsChoix

#Region "Propriétés"
    Public Property NomChoix() As DsAgrifactTableAdapters.ListeChoixTA.NomsChoix
        Get
            Return Me._NomChoix
        End Get
        Set(ByVal value As DsAgrifactTableAdapters.ListeChoixTA.NomsChoix)
            Me._NomChoix = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal nomChoix As DsAgrifactTableAdapters.ListeChoixTA.NomsChoix)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._NomChoix = nomChoix
    End Sub
#End Region

#Region "Form"
    Private Sub FrListeChoix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.DsAgrifact.ListeChoix.NomChoixColumn.DefaultValue = Me.NomChoix.ToString()

            Me.DsAgrifact.ListeChoix.nOrdreValeurColumn.AutoIncrement = True

            Dim query As String = "NomChoix='" & Me.NomChoix.ToString() & "'"

            If (Me.DsAgrifact.ListeChoix.Compute("MAX(nOrdreValeur)", "NomChoix='" & Me.NomChoix.ToString() & "'") Is DBNull.Value) Then
                Me.DsAgrifact.ListeChoix.nOrdreValeurColumn.AutoIncrementSeed = 1
            Else
                Me.DsAgrifact.ListeChoix.nOrdreValeurColumn.AutoIncrementSeed = Convert.ToInt64(Me.DsAgrifact.ListeChoix.Compute("Max(nOrdreValeur)", "NomChoix='" & Me.NomChoix.ToString() & "'")) + 10
            End If

            Me.DsAgrifact.ListeChoix.nOrdreValeurColumn.AutoIncrementStep = 10

            Me.ChargerDonnees()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FrListeChoix_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.EnregistrerDonnees()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerDonnees()
        Try
            Me.ListeChoixTA.FillByNomChoix(Me.DsAgrifact.ListeChoix, Me.NomChoix)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnregistrerDonnees()
        Try
            Me.ListeChoixTA.Update(Me.DsAgrifact.ListeChoix)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
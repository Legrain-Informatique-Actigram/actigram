Imports System.Data.SqlClient

Public Class FrListeChoix

    Private _NomChoix As String

#Region "Propriétés"
    Public Property NomChoix() As String
        Get
            Return Me._NomChoix
        End Get
        Set(ByVal value As String)
            Me._NomChoix = value
        End Set
    End Property

    Private ReadOnly Property CurrentListeChoixRow() As PubDataSet.ListeChoixRow
        Get
            If (Me.ListeChoixBindingSource.Current Is Nothing) Then
                Return Nothing
            End If

            Return DirectCast(DirectCast(Me.ListeChoixBindingSource.Current, DataRowView).Row, PubDataSet.ListeChoixRow)
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal nomChoix As String)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._NomChoix = nomChoix
    End Sub
#End Region

#Region "Form"
    Private Sub FrListeChoix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Par défaut, la colonne NomChoix prend la valeur du NomChoix passé au constructeur
            Me.PubDataSet.ListeChoix.NomChoixColumn.DefaultValue = Me.NomChoix.ToString()

            'Déclaration de la colonne nOrdreValeur en tant qu'auto-incrément
            Me.PubDataSet.ListeChoix.nOrdreValeurColumn.AutoIncrement = True

            If (Me.PubDataSet.ListeChoix.Compute("MAX(nOrdreValeur)", String.Format("NomChoix='{0}'", Me.NomChoix)) Is DBNull.Value) Then
                Me.PubDataSet.ListeChoix.nOrdreValeurColumn.AutoIncrementSeed = 1
            Else
                Me.PubDataSet.ListeChoix.nOrdreValeurColumn.AutoIncrementSeed = Convert.ToInt64(Me.PubDataSet.ListeChoix.Compute("Max(nOrdreValeur)", "NomChoix='" & Me.NomChoix.ToString() & "'")) + 10
            End If

            Me.PubDataSet.ListeChoix.nOrdreValeurColumn.AutoIncrementStep = 10

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
            'Chargement en fonction du NomChoix 
            Me.ListeChoixTableAdapter.FillByNomChoix(Me.PubDataSet.ListeChoix, Me.NomChoix)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EnregistrerDonnees()
        Try
            Me.ListeChoixTableAdapter.Update(Me.PubDataSet.ListeChoix)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
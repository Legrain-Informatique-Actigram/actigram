Imports System.Windows.Forms

Public Class FrModeleChoix

#Region "Propriétés"
    Private _lignes As New List(Of Ligne)
    Public Property Resultat() As List(Of Ligne)
        Get
            Return _lignes
        End Get
        Set(ByVal value As List(Of Ligne))
            _lignes = value
        End Set
    End Property

    Private _LibellePiece As String = ""
    Public Property LibellePiece() As String
        Get
            Return _LibellePiece
        End Get
        Set(ByVal value As String)
            _LibellePiece = value
        End Set
    End Property
#End Region

#Region "Page"
    Private Sub FrModeleChoix_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetChildFormIcon(Me)

        Dim l As New ListOfModeles
        l.Charger()
        Me.ModeleBindingSource.DataSource = l
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click, ModeleComboBox.DoubleClick
        For Each xRow As Ligne In CType(Me.ModeleBindingSource.Current, Modele).Lignes
            Me.Resultat.Add(xRow.GetLigneModele(chkMontant.Checked))
        Next
        LibellePiece = CType(Me.ModeleBindingSource.Current, Modele).Modele
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
#End Region

End Class

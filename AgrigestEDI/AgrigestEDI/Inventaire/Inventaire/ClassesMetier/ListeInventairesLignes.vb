Imports System.Data.OleDb

Namespace Inventaire.ClassesMetier
    Public Class ListeInventairesLignes
        Inherits List(Of InventaireLignes)

#Region "Méthodes partagées"
        Public Shared Sub Trier(ByVal listeInvLignes As Inventaire.ClassesMetier.ListeInventairesLignes, _
                                ByVal codeTri As String, ByVal odreTri As System.Windows.Forms.SortOrder)

            Select Case codeTri
                Case "INVLOrdre"
                    Dim triListeInvLignesParINVLOrdre As New Inventaire.ClassesMetier.ListeInventairesLignes.TriListeInventairesLignesParINVLOrdre(odreTri)

                    listeInvLignes.Sort(triListeInvLignesParINVLOrdre)
            End Select
        End Sub
#End Region

#Region "Classes internes"
        Public Class TriListeInventairesLignesParINVLOrdre
            Implements IComparer(Of Inventaire.ClassesMetier.InventaireLignes)

            Private sortOrderModifier As Integer = 1

#Region "Constructeurs"
            Public Sub New(ByVal ordreTri As System.Windows.Forms.SortOrder)
                If ordreTri = System.Windows.Forms.SortOrder.Descending Then
                    sortOrderModifier = -1
                ElseIf ordreTri = System.Windows.Forms.SortOrder.Ascending Then

                    sortOrderModifier = 1
                End If
            End Sub
#End Region

#Region "Méthodes diverses"
            Public Function Compare(ByVal x As Inventaire.ClassesMetier.InventaireLignes, ByVal y As Inventaire.ClassesMetier.InventaireLignes) As Integer Implements System.Collections.Generic.IComparer(Of Inventaire.ClassesMetier.InventaireLignes).Compare
                Dim Resultat As Integer = 0

                If (x.INVLOrdre.GetValueOrDefault() < y.INVLOrdre.GetValueOrDefault) Then
                    Resultat = -1
                ElseIf (x.INVLOrdre.GetValueOrDefault() = y.INVLOrdre.GetValueOrDefault()) Then
                    Resultat = 0
                Else
                    Resultat = 1
                End If

                Return Resultat * Me.sortOrderModifier
            End Function
#End Region

        End Class
#End Region

    End Class
End Namespace

Imports System.Data.OleDb
Imports System.ComponentModel

Namespace Inventaire.ClassesMetier
    Public Class ListeInventairesGroupes
        Inherits List(Of InventaireGroupes)

#Region "Méthodes partagées"
        Public Shared Sub Trier(ByVal listeInvGpes As Inventaire.ClassesMetier.ListeInventairesGroupes, _
                                ByVal codeTri As String, ByVal odreTri As System.Windows.Forms.SortOrder)

            Select Case codeTri
                Case "INVGCpt,INVGLib"
                    Dim triListeInvGpesParINVGCpt As New Inventaire.ClassesMetier.ListeInventairesGroupes.TriListeInventairesGroupesParINVGCptEtParINVGLib(odreTri)

                    listeInvGpes.Sort(triListeInvGpesParINVGCpt)
                Case "INVGOrdre"
                    Dim triListeInvGpesParINVGOrdre As New Inventaire.ClassesMetier.ListeInventairesGroupes.TriListeInventairesGroupesParINVGOrdre(odreTri)

                    listeInvGpes.Sort(triListeInvGpesParINVGOrdre)
            End Select
        End Sub
#End Region

#Region "Classes internes"
        Public Class TriListeInventairesGroupesParINVGCptEtParINVGLib
            Implements IComparer(Of Inventaire.ClassesMetier.InventaireGroupes)

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
            Public Function Compare(ByVal x As InventaireGroupes, ByVal y As InventaireGroupes) As Integer Implements System.Collections.Generic.IComparer(Of InventaireGroupes).Compare
                If (x.INVGCpt < y.INVGCpt) Then
                    Return -1
                ElseIf (x.INVGCpt = y.INVGCpt) Then
                    If (x.INVGLib < y.INVGLib) Then
                        Return -1
                    ElseIf (x.INVGLib = y.INVGLib) Then
                        Return 0
                    Else
                        Return 1
                    End If
                Else
                    Return 1
                End If
            End Function
#End Region

        End Class

        Public Class TriListeInventairesGroupesParINVGOrdre
            Implements IComparer(Of Inventaire.ClassesMetier.InventaireGroupes)

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
            Public Function Compare(ByVal x As Inventaire.ClassesMetier.InventaireGroupes, ByVal y As Inventaire.ClassesMetier.InventaireGroupes) As Integer Implements System.Collections.Generic.IComparer(Of Inventaire.ClassesMetier.InventaireGroupes).Compare
                Dim Resultat As Integer = 0

                If (CInt(x.INVGOrdre) < CInt(y.INVGOrdre)) Then
                    Resultat = -1
                ElseIf (CInt(x.INVGOrdre) = CInt(y.INVGOrdre)) Then
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

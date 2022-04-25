Imports System.Data.OleDb

Namespace Inventaire.ClassesTechniques
    Public Class DAOInventaireMateriel

        Private _ConnString As String = Nothing
        Private _InventaireMaterielTA As DataSetAgrigestTableAdapters.InventaireMaterielTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property InventaireMaterielTA() As DataSetAgrigestTableAdapters.InventaireMaterielTableAdapter
            Get
                Return Me._InventaireMaterielTA
            End Get
            Set(ByVal value As DataSetAgrigestTableAdapters.InventaireMaterielTableAdapter)
                Me._InventaireMaterielTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._InventaireMaterielTA = New DataSetAgrigestTableAdapters.InventaireMaterielTableAdapter

            Me.InventaireMaterielTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetInventaireMateriel(ByVal ID_InventaireMateriel As Integer) As Inventaire.ClassesMetier.InventaireMateriel
            Dim invMat As Inventaire.ClassesMetier.InventaireMateriel = Nothing

            Dim inventaireMaterielDT As DataSetAgrigest.InventaireMaterielDataTable = Me.InventaireMaterielTA.GetDataByID_InventaireMateriel(ID_InventaireMateriel)

            If (inventaireMaterielDT.Rows.Count > 0) Then
                Dim inventaireMaterielDR As DataSetAgrigest.InventaireMaterielRow = CType(inventaireMaterielDT.Rows(0), DataSetAgrigest.InventaireMaterielRow)

                invMat = Me.ValoriserInventaireMateriel(inventaireMaterielDR)
            End If

            Return invMat
        End Function

        Public Function GetInventaireMateriel(ByVal invMatDR As DataSetAgrigest.InventaireMaterielRow) As Inventaire.ClassesMetier.InventaireMateriel
            Return Me.ValoriserInventaireMateriel(invMatDR)
        End Function

        Public Sub InsertInventaireMateriel(ByVal invMat As Inventaire.ClassesMetier.InventaireMateriel, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireMaterielTA.SetTransaction(oleDbTrans)
            End If

            If Not (invMat.LibelleMateriel Is Nothing) Then
                invMat.LibelleMateriel = Left(invMat.LibelleMateriel, 255)
            End If

            Me.InventaireMaterielTA.Insert(invMat.LibelleMateriel, invMat.DDossier, invMat.ID_MATERIEL)
        End Sub

        Public Function ImporterInventaireMateriel(ByVal DDossier_EnCours As String, ByVal DDossierAImporter As String) As Integer
            Dim nbEnreg As Integer = 0

            Dim inventaireMatDT As DataSetAgrigest.InventaireMaterielDataTable = Me.InventaireMaterielTA.GetDataByDDossier(DDossierAImporter)

            For Each inventaireMatDR As DataSetAgrigest.InventaireMaterielRow In inventaireMatDT.Rows
                Dim inventaireMat As New Inventaire.ClassesMetier.InventaireMateriel

                If Not (inventaireMatDR.IsLibelleMaterielNull) Then
                    inventaireMat.LibelleMateriel = inventaireMatDR.LibelleMateriel
                Else
                    inventaireMat.LibelleMateriel = String.Empty
                End If

                inventaireMat.DDossier = DDossier_EnCours

                If Not (inventaireMatDR.IsID_MATERIELNull) Then
                    inventaireMat.ID_MATERIEL = inventaireMatDR.ID_MATERIEL
                Else
                    inventaireMat.ID_MATERIEL = New Nullable(Of Integer)
                End If

                Me.InsertInventaireMateriel(inventaireMat)

                nbEnreg += 1
            Next

            Return nbEnreg
        End Function

        Public Function GetListeInventairesMateriel(ByVal DDossier As String, _
                                                Optional ByVal oleDbTrans As OleDbTransaction = Nothing) _
                                                As Inventaire.ClassesMetier.ListeInventairesMateriel

            Dim listeInvMat As New Inventaire.ClassesMetier.ListeInventairesMateriel

            If Not (oleDbTrans Is Nothing) Then
                Me.InventaireMaterielTA.SetTransaction(oleDbTrans)
            End If

            Dim invMatDT As DataSetAgrigest.InventaireMaterielDataTable = Me.InventaireMaterielTA.GetDataByDDossier(DDossier)

            For Each invMatDR As DataSetAgrigest.InventaireMaterielRow In invMatDT.Rows
                Dim invMat As Inventaire.ClassesMetier.InventaireMateriel = Me.GetInventaireMateriel(invMatDR)

                listeInvMat.Add(invMat)
            Next

            Return listeInvMat
        End Function
#End Region

#Region "Méthodes internes"
        Private Function ValoriserInventaireMateriel(ByVal invMatDR As DataSetAgrigest.InventaireMaterielRow) As Inventaire.ClassesMetier.InventaireMateriel
            Dim invMat As Inventaire.ClassesMetier.InventaireMateriel = Nothing

            If Not (invMatDR Is Nothing) Then
                invMat = New Inventaire.ClassesMetier.InventaireMateriel

                invMat.ID_InventaireMateriel = invMatDR.ID_InventaireMateriel

                If Not (invMatDR.IsLibelleMaterielNull) Then
                    invMat.LibelleMateriel = invMatDR.LibelleMateriel
                Else
                    invMat.LibelleMateriel = String.Empty
                End If

                If Not (invMatDR.IsDDossierNull) Then
                    invMat.DDossier = invMatDR.DDossier
                Else
                    invMat.DDossier = String.Empty
                End If

                If Not (invMatDR.IsID_MATERIELNull) Then
                    invMat.ID_MATERIEL = invMatDR.ID_MATERIEL
                Else
                    invMat.ID_MATERIEL = New Nullable(Of Integer)
                End If
            End If

            Return invMat
        End Function
#End Region

    End Class
End Namespace

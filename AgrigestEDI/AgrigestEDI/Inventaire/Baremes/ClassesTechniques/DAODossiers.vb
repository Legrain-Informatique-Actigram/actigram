Imports System.Data.OleDb

Namespace Baremes.ClassesTechniques
    Public Class DAODossiers

        Private _ConnString As String = Nothing
        Private _DossiersTA As DataSetAgrigestTableAdapters.DossiersTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property DossiersTA() As DataSetAgrigestTableAdapters.DossiersTableAdapter
            Get
                Return Me._DossiersTA
            End Get
            Set(ByVal value As DataSetAgrigestTableAdapters.DossiersTableAdapter)
                Me._DossiersTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._DossiersTA = New DataSetAgrigestTableAdapters.DossiersTableAdapter

            Me.DossiersTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetDossier(ByVal DDossier As String) As Baremes.ClassesMetier.Dossiers
            Dim doss As Baremes.ClassesMetier.Dossiers = Nothing

            Dim dossiersDT As DataSetAgrigest.DossiersDataTable = Me.DossiersTA.GetDataByDDossier(DDossier)

            If (dossiersDT.Rows.Count > 0) Then
                doss = New Baremes.ClassesMetier.Dossiers

                Dim dossiersDR As DataSetAgrigest.DossiersRow = CType(dossiersDT.Rows(0), DataSetAgrigest.DossiersRow)

                doss.DDossier = dossiersDR.DDossier

                If Not (dossiersDR.IsDExplNull) Then
                    doss.DExpl = dossiersDR.DExpl
                Else
                    doss.DExpl = String.Empty
                End If

                If Not (dossiersDR.IsDDtDebExNull) Then
                    doss.DDtDebEx = dossiersDR.DDtDebEx
                Else
                    doss.DDtDebEx = New Nullable(Of Date)()
                End If

                If Not (dossiersDR.IsDDtFinExNull) Then
                    doss.DDtFinEx = dossiersDR.DDtFinEx
                Else
                    doss.DDtFinEx = New Nullable(Of Date)()
                End If

                If Not (dossiersDR.IsDDtArreteNull) Then
                    doss.DDtArrete = dossiersDR.DDtArrete
                Else
                    doss.DDtArrete = New Nullable(Of Date)()
                End If

                If Not (dossiersDR.IsDBqCptNull) Then
                    doss.DBqCpt = dossiersDR.DBqCpt
                Else
                    doss.DBqCpt = String.Empty
                End If

                If Not (dossiersDR.IsDBqValNull) Then
                    doss.DBqVal = dossiersDR.DBqVal
                Else
                    doss.DBqVal = New Nullable(Of Decimal)()
                End If

                If Not (dossiersDR.IsDMethodeInventaireNull) Then
                    doss.DMethodeInventaire = dossiersDR.DMethodeInventaire
                Else
                    doss.DMethodeInventaire = String.Empty
                End If

                If Not (dossiersDR.IsDDtClotureTVANull) Then
                    doss.DDtClotureTVA = dossiersDR.DDtClotureTVA
                Else
                    doss.DDtClotureTVA = New Nullable(Of Date)()
                End If
            End If

            Return doss
        End Function

        Public Function GetListeDossiers(ByVal DExpl As String) As Baremes.ClassesMetier.ListeDossiers
            Dim listeDoss As New Baremes.ClassesMetier.ListeDossiers
            Dim dossiersDT As DataSetAgrigest.DossiersDataTable = Me.DossiersTA.GetDataByDExpl(DExpl)

            For Each dossiersDR As DataSetAgrigest.DossiersRow In dossiersDT.Rows
                Dim dossier As Baremes.ClassesMetier.Dossiers = Me.GetDossier(dossiersDR.DDossier)

                listeDoss.Add(dossier)
            Next

            Return listeDoss
        End Function

        Public Function GetDDossierPrecedent(ByVal dossier_EnCours As Baremes.ClassesMetier.Dossiers) As String
            Dim DDossierPrec As String = String.Empty

            If (dossier_EnCours.DDtDebEx.HasValue) Then
                DDossierPrec = CStr(Me.DossiersTA.DDossierPrecedent(dossier_EnCours.DDtDebEx))

                If (DDossierPrec Is Nothing) Then
                    DDossierPrec = String.Empty
                End If
            End If

            Return DDossierPrec
        End Function

        Public Sub UpdateDMethodeInventaire(ByVal DMethodeInventaire As String, _
                                            ByVal DDossier As String, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            If Not (oleDbTrans Is Nothing) Then
                Me.DossiersTA.SetTransaction(oleDbTrans)
            End If

            Me.DossiersTA.UpdateDMethodeInventaire(DMethodeInventaire, DDossier)
        End Sub

        Public Sub UpdateDDtClotureTVA(ByVal DDtClotureTVA As Date, _
                                            ByVal DDossier As String, _
                                            Optional ByVal oleDbTrans As OleDbTransaction = Nothing)

            If Not (oleDbTrans Is Nothing) Then
                Me.DossiersTA.SetTransaction(oleDbTrans)
            End If

            Me.DossiersTA.UpdateDDtClotureTVA(DDtClotureTVA, DDossier)
        End Sub
#End Region

    End Class
End Namespace

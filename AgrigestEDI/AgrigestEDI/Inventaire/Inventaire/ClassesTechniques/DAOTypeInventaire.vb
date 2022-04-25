Namespace Inventaire.ClassesTechniques
    Public Class DAOTypeInventaire

        Private _ConnString As String = Nothing
        Private _TypeInventaireTA As DataSetAgrigestTableAdapters.TypeInventaireTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property TypeInventaireTA() As DataSetAgrigestTableAdapters.TypeInventaireTableAdapter
            Get
                Return Me._TypeInventaireTA
            End Get
            Set(ByVal value As DataSetAgrigestTableAdapters.TypeInventaireTableAdapter)
                Me._TypeInventaireTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._TypeInventaireTA = New DataSetAgrigestTableAdapters.TypeInventaireTableAdapter

            Me.TypeInventaireTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetTypeInventaire(ByVal codeTypeInventaire As String) As Inventaire.ClassesMetier.TypeInventaire
            Dim typeInv As Inventaire.ClassesMetier.TypeInventaire = Nothing

            Dim typeInventaireDT As DataSetAgrigest.TypeInventaireDataTable = Me.TypeInventaireTA.GetDataByCodeTypeInventaire(codeTypeInventaire)

            If (typeInventaireDT.Rows.Count > 0) Then
                typeInv = New Inventaire.ClassesMetier.TypeInventaire

                Dim typeInventaireDR As DataSetAgrigest.TypeInventaireRow = CType(typeInventaireDT.Rows(0), DataSetAgrigest.TypeInventaireRow)

                typeInv.ID_TypeInventaire = typeInventaireDR.ID_TypeInventaire

                If Not (typeInventaireDR.IsCodeTypeInventaireNull) Then
                    typeInv.CodeTypeInventaire = typeInventaireDR.CodeTypeInventaire
                Else
                    typeInv.CodeTypeInventaire = String.Empty
                End If

                If Not (typeInventaireDR.IsLibelleTypeInventaireNull) Then
                    typeInv.LibelleTypeInventaire = typeInventaireDR.LibelleTypeInventaire
                Else
                    typeInv.LibelleTypeInventaire = String.Empty
                End If

                If Not (typeInventaireDR.IsOrdreTypeInventaireNull) Then
                    typeInv.OrdreTypeInventaire = typeInventaireDR.OrdreTypeInventaire
                Else
                    typeInv.OrdreTypeInventaire = New Nullable(Of Integer)
                End If
            End If

            Return typeInv
        End Function
#End Region

    End Class
End Namespace

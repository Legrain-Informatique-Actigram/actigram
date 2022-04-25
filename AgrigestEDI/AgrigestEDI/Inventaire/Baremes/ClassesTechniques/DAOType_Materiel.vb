Namespace Baremes.ClassesTechniques
    Public Class DAOType_Materiel

        Private _ConnString As String = Nothing
        Private _TypeMaterielTA As DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property TypeMaterielTA() As DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter
            Get
                Return Me._TypeMaterielTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter)
                Me._TypeMaterielTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._TypeMaterielTA = New DataSetBaremesTableAdapters.TYPE_MATERIELTableAdapter

            Me.TypeMaterielTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetType_Materiel(ByVal codeTypeMateriel As String) As Baremes.ClassesMetier.Type_Materiel
            Dim type_Mat As Baremes.ClassesMetier.Type_Materiel = Nothing

            type_Mat = New Baremes.ClassesMetier.Type_Materiel

            Dim typeMaterielDT As DataSetBaremes.TYPE_MATERIELDataTable = Me.TypeMaterielTA.GetDataByCODE_TYPE_MATERIEL(codeTypeMateriel)

            If (typeMaterielDT.Rows.Count > 0) Then
                Dim typeMaterielDR As DataSetBaremes.TYPE_MATERIELRow = CType(typeMaterielDT.Rows(0), DataSetBaremes.TYPE_MATERIELRow)

                type_Mat.ID_TYPE_MATERIEL = typeMaterielDR.ID_TYPE_MATERIEL

                If Not (typeMaterielDR.IsCODE_TYPE_MATERIELNull) Then
                    type_Mat.CODE_TYPE_MATERIEL = typeMaterielDR.CODE_TYPE_MATERIEL
                Else
                    type_Mat.CODE_TYPE_MATERIEL = String.Empty
                End If

                If Not (typeMaterielDR.IsLIBELLE_TYPE_MATERIELNull) Then
                    type_Mat.LIBELLE_TYPE_MATERIEL = typeMaterielDR.LIBELLE_TYPE_MATERIEL
                Else
                    type_Mat.LIBELLE_TYPE_MATERIEL = String.Empty
                End If
            End If

            Return type_Mat
        End Function
#End Region

    End Class
End Namespace

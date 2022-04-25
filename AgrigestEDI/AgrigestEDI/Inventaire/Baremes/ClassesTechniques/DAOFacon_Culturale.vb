Namespace Baremes.ClassesTechniques
    Public Class DAOFacon_Culturale

        Private _ConnString As String = Nothing
        Private _Facon_CulturaleTA As DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property Facon_CulturaleTA() As DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter
            Get
                Return Me._Facon_CulturaleTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter)
                Me._Facon_CulturaleTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._Facon_CulturaleTA = New DataSetBaremesTableAdapters.FACON_CULTURALETableAdapter

            Me.Facon_CulturaleTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetFacon_Culturale(ByVal ID_FACON_CULTURALE As Integer) As Baremes.ClassesMetier.Facon_Culturale
            Dim facCult As Baremes.ClassesMetier.Facon_Culturale = Nothing

            Dim facon_CulturaleDT As DataSetBaremes.FACON_CULTURALEDataTable = Me.Facon_CulturaleTA.GetDataByID_FACON_CULTURALE(ID_FACON_CULTURALE)

            If (facon_CulturaleDT.Rows.Count > 0) Then
                facCult = New Baremes.ClassesMetier.Facon_Culturale

                Dim facon_CulturaleDR As DataSetBaremes.FACON_CULTURALERow = CType(facon_CulturaleDT.Rows(0), DataSetBaremes.FACON_CULTURALERow)

                facCult.ID_FACON_CULTURALE = facon_CulturaleDR.ID_FACON_CULTURALE

                If Not (facon_CulturaleDR.IsLIBELLE_FACON_CULTURALENull) Then
                    facCult.LIBELLE_FACON_CULTURALE = facon_CulturaleDR.LIBELLE_FACON_CULTURALE
                Else
                    facCult.LIBELLE_FACON_CULTURALE = String.Empty
                End If
            End If

            Return facCult
        End Function
#End Region

    End Class
End Namespace

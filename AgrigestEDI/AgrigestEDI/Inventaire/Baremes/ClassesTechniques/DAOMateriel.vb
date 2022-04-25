Namespace Baremes.ClassesTechniques
    Public Class DAOMateriel

        Private _ConnString As String = Nothing
        Private _MaterielTA As DataSetBaremesTableAdapters.MATERIELTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property MaterielTA() As DataSetBaremesTableAdapters.MATERIELTableAdapter
            Get
                Return Me._MaterielTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.MATERIELTableAdapter)
                Me._MaterielTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._MaterielTA = New DataSetBaremesTableAdapters.MATERIELTableAdapter

            Me.MaterielTA.Connection.ConnectionString = Me._ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetMateriel(ByVal ID_MATERIEL As Integer) As Baremes.ClassesMetier.Materiel
            Dim mat As Baremes.ClassesMetier.Materiel = Nothing

            Dim materielDT As DataSetBaremes.MATERIELDataTable = Me.MaterielTA.GetDataByID_MATERIEL(ID_MATERIEL)

            If (materielDT.Rows.Count > 0) Then
                mat = New Baremes.ClassesMetier.Materiel

                Dim materielDR As DataSetBaremes.MATERIELRow = CType(materielDT.Rows(0), DataSetBaremes.MATERIELRow)

                mat.ID_MATERIEL = materielDR.ID_MATERIEL

                If Not (materielDR.IsLIBELLE_MATERIELNull) Then
                    mat.LIBELLE_MATERIEL = materielDR.LIBELLE_MATERIEL
                Else
                    mat.LIBELLE_MATERIEL = String.Empty
                End If

                If Not (materielDR.IsID_TYPE_MATERIELNull) Then
                    mat.ID_TYPE_MATERIEL = materielDR.ID_TYPE_MATERIEL
                Else
                    mat.ID_TYPE_MATERIEL = New Nullable(Of Integer)
                End If
            End If

            Return mat
        End Function

        Public Function TypeEstAffecteAMateriel(ByVal ID_TYPE_MATERIEL As Integer) As Boolean
            Dim materielDT As DataSetBaremes.MATERIELDataTable = Me.MaterielTA.GetDataByID_TYPE_MATERIEL(ID_TYPE_MATERIEL)

            If (materielDT.Rows.Count > 0) Then
                Return True
            End If

            Return False
        End Function
#End Region

    End Class
End Namespace

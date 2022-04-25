Namespace Baremes.ClassesTechniques
    Public Class DAOBareme

        Private _ConnString As String = Nothing
        Private _BaremeTA As DataSetBaremesTableAdapters.BAREMETableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property BaremeTA() As DataSetBaremesTableAdapters.BAREMETableAdapter
            Get
                Return Me._BaremeTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.BAREMETableAdapter)
                Me._BaremeTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._BaremeTA = New DataSetBaremesTableAdapters.BAREMETableAdapter

            Me.BaremeTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetBareme(ByVal ID_BAREME As Integer) As Baremes.ClassesMetier.Bareme
            Dim brme As Baremes.ClassesMetier.Bareme = Nothing

            Dim baremeDT As DataSetBaremes.BAREMEDataTable = Me.BaremeTA.GetDataByID_BAREME(ID_BAREME)

            If (baremeDT.Rows.Count > 0) Then
                brme = New Baremes.ClassesMetier.Bareme

                Dim baremeDR As DataSetBaremes.BAREMERow = CType(baremeDT.Rows(0), DataSetBaremes.BAREMERow)

                brme.ID_BAREME = baremeDR.ID_BAREME

                If Not (baremeDR.IsANNEE_BAREMENull) Then
                    brme.ANNEE_BAREME = baremeDR.ANNEE_BAREME
                Else
                    brme.ANNEE_BAREME = String.Empty
                End If

                If Not (baremeDR.IsCOUT_TOTAL_PAR_HEURENull) Then
                    brme.COUT_TOTAL_PAR_HEURE = baremeDR.COUT_TOTAL_PAR_HEURE
                Else
                    brme.COUT_TOTAL_PAR_HEURE = New Nullable(Of Decimal)
                End If

                If Not (baremeDR.IsID_MATERIELNull) Then
                    brme.ID_MATERIEL = baremeDR.ID_MATERIEL
                Else
                    brme.ID_MATERIEL = New Nullable(Of Integer)
                End If

                If Not (baremeDR.IsINFO_COMPLNull) Then
                    brme.INFO_COMPL = baremeDR.INFO_COMPL
                Else
                    brme.INFO_COMPL = String.Empty
                End If
            End If

            Return brme
        End Function

        Public Function MaterielEstAffecteABareme(ByVal ID_MATERIEL As Integer) As Boolean
            Dim baremeDT As DataSetBaremes.BAREMEDataTable = Me.BaremeTA.GetDataByID_MATERIEL(ID_MATERIEL)

            If (baremeDT.Rows.Count > 0) Then
                Return True
            End If

            Return False
        End Function

        Public Function CopierListeBaremes(ByVal anneeAImporter As String, ByVal anneeImport As String, _
                                        ByVal baremesDS As DataSetBaremes) As Integer

            Dim nbEnreg As Integer = 0
            Dim baremeDT As DataSetBaremes.BAREMEDataTable = Me.BaremeTA.GetDataByANNEE_BAREME(anneeAImporter)

            For Each baremeDR As DataSetBaremes.BAREMERow In baremeDT.Rows
                Dim baremeImportDR As DataSetBaremes.BAREMERow = CType(baremesDS.BAREME.NewRow, DataSetBaremes.BAREMERow)

                baremeImportDR.ANNEE_BAREME = anneeImport

                If Not (baremeDR.IsCOUT_TOTAL_PAR_HEURENull) Then
                    baremeImportDR.COUT_TOTAL_PAR_HEURE = baremeDR.COUT_TOTAL_PAR_HEURE
                End If

                If Not (baremeDR.IsID_MATERIELNull) Then
                    baremeImportDR.ID_MATERIEL = baremeDR.ID_MATERIEL
                End If

                If Not (baremeDR.IsINFO_COMPLNull) Then
                    baremeImportDR.INFO_COMPL = baremeDR.INFO_COMPL
                End If

                baremesDS.BAREME.AddBAREMERow(baremeImportDR)

                nbEnreg += 1
            Next

            Return nbEnreg
        End Function
#End Region

    End Class
End Namespace

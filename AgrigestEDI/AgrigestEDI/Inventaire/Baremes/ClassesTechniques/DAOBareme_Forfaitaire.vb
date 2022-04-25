Namespace Baremes.ClassesTechniques
    Public Class DAOBareme_Forfaitaire

        Private _ConnString As String = Nothing
        Private _Bareme_ForfaitaireTA As DataSetBaremesTableAdapters.BAREME_FORFAITAIRETableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property Bareme_ForfaitaireTA() As DataSetBaremesTableAdapters.BAREME_FORFAITAIRETableAdapter
            Get
                Return Me._Bareme_ForfaitaireTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.BAREME_FORFAITAIRETableAdapter)
                Me._Bareme_ForfaitaireTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._Bareme_ForfaitaireTA = New DataSetBaremesTableAdapters.BAREME_FORFAITAIRETableAdapter

            Me.Bareme_ForfaitaireTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetBareme_Forfaitaire(ByVal ID_BAREME_FORFAITAIRE As Integer) As Baremes.ClassesMetier.Bareme_Forfaitaire
            Dim brme_Forf As Baremes.ClassesMetier.Bareme_Forfaitaire = Nothing

            Dim bareme_ForfaitaireDT As DataSetBaremes.BAREME_FORFAITAIREDataTable = Me.Bareme_ForfaitaireTA.GetDataByID_BAREME_FORFAITAIRE(ID_BAREME_FORFAITAIRE)

            If (bareme_ForfaitaireDT.Rows.Count > 0) Then
                brme_Forf = New Baremes.ClassesMetier.Bareme_Forfaitaire

                Dim bareme_ForfaitaireDR As DataSetBaremes.BAREME_FORFAITAIRERow = CType(bareme_ForfaitaireDT.Rows(0), DataSetBaremes.BAREME_FORFAITAIRERow)

                brme_Forf.ID_BAREME_FORFAITAIRE = bareme_ForfaitaireDR.ID_BAREME_FORFAITAIRE

                If Not (bareme_ForfaitaireDR.IsANNEE_BAREME_FORFAITAIRENull) Then
                    brme_Forf.ANNEE_BAREME_FORFAITAIRE = bareme_ForfaitaireDR.ANNEE_BAREME_FORFAITAIRE
                Else
                    brme_Forf.ANNEE_BAREME_FORFAITAIRE = String.Empty
                End If

                If Not (bareme_ForfaitaireDR.IsVALEUR_FORFAITAIRENull) Then
                    brme_Forf.VALEUR_FORFAITAIRE = bareme_ForfaitaireDR.VALEUR_FORFAITAIRE
                Else
                    brme_Forf.VALEUR_FORFAITAIRE = New Nullable(Of Decimal)
                End If

                If Not (bareme_ForfaitaireDR.IsID_FACON_CULTURALENull) Then
                    brme_Forf.ID_FACON_CULTURALE = bareme_ForfaitaireDR.ID_FACON_CULTURALE
                Else
                    brme_Forf.ID_FACON_CULTURALE = New Nullable(Of Integer)
                End If
            End If

            Return brme_Forf
        End Function

        Public Function Facon_CulturaleEstAffecteABareme_Forfaitaire(ByVal ID_FACON_CULTURALE As Integer) As Boolean
            Dim bareme_ForfaitaireDT As DataSetBaremes.BAREME_FORFAITAIREDataTable = Me.Bareme_ForfaitaireTA.GetDataByID_FACON_CULTURALE(ID_FACON_CULTURALE)

            If (bareme_ForfaitaireDT.Rows.Count > 0) Then
                Return True
            End If

            Return False
        End Function

        Public Function CopierListeBaremes_Forfaitaire(ByVal anneeAImporter As String, ByVal anneeImport As String, _
                                        ByVal baremesDS As DataSetBaremes) As Integer

            Dim nbEnreg As Integer = 0
            Dim baremeForfaitaireDT As DataSetBaremes.BAREME_FORFAITAIREDataTable = Me._Bareme_ForfaitaireTA.GetDataByANNEE_BAREME_FORFAITAIRE(anneeAImporter)

            For Each baremeForfaitaireDR As DataSetBaremes.BAREME_FORFAITAIRERow In baremeForfaitaireDT.Rows
                Dim baremeForfaitaireImportDR As DataSetBaremes.BAREME_FORFAITAIRERow = CType(baremesDS.BAREME_FORFAITAIRE.NewRow, DataSetBaremes.BAREME_FORFAITAIRERow)

                baremeForfaitaireImportDR.ANNEE_BAREME_FORFAITAIRE = anneeImport

                If Not (baremeForfaitaireDR.IsVALEUR_FORFAITAIRENull) Then
                    baremeForfaitaireImportDR.VALEUR_FORFAITAIRE = baremeForfaitaireDR.VALEUR_FORFAITAIRE
                End If

                If Not (baremeForfaitaireDR.IsID_FACON_CULTURALENull) Then
                    baremeForfaitaireImportDR.ID_FACON_CULTURALE = baremeForfaitaireDR.ID_FACON_CULTURALE
                End If

                baremesDS.BAREME_FORFAITAIRE.AddBAREME_FORFAITAIRERow(baremeForfaitaireImportDR)

                nbEnreg += 1
            Next

            Return nbEnreg
        End Function
#End Region

    End Class
End Namespace

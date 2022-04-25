Namespace Immobilisations
    Public Class IdImmo
        Public nDossier As String
        Public nCpt As String
        Public Acti As String = "0000"
        Public Ordre As Integer = 0
        Public nCompo As Integer = 0
        Public libelle As String = ""

        Public dtAcquis As Date
        Public valAcquis As Decimal

        Public dtCession As Date = #1/1/1900#
        Public valCession As Decimal = 0

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal drv As DataRowView)
            Me.New()
            Me.nDossier = CStr(drv("IDossier"))
            Me.nCpt = CStr(drv("ICpt"))
            Me.Acti = CStr(drv("IActi"))
            Me.Ordre = CInt(drv("IOrdre"))

            If Not (IsDBNull(drv("INCompo"))) Then
                Me.nCompo = CInt(drv("INCompo"))
            Else
                Me.nCompo = 0
            End If
        End Sub

        Public Sub New(ByVal nDossier As String, ByVal nCpt As String, ByVal Ordre As Integer, _
                        Optional ByVal Acti As String = "0000", Optional ByVal nCompo As Integer = 0)
            Me.New()
            Me.nDossier = nDossier
            Me.nCpt = nCpt
            Me.Acti = Acti
            Me.Ordre = Ordre
            Me.nCompo = nCompo
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetFilter() As String
            If nCompo = 0 Then
                Return String.Format("IDossier='{0}' AND ICpt='{1}' AND IActi='{2}' AND IOrdre={3} AND (INCompo={4} OR INCompo is null)", nDossier, nCpt, Acti, Ordre, nCompo)
            Else
                Return String.Format("IDossier='{0}' AND ICpt='{1}' AND IActi='{2}' AND IOrdre={3} AND INCompo={4}", nDossier, nCpt, Acti, Ordre, nCompo)
            End If
        End Function

        Public Function Find(ByVal ds As DataSet) As DataRow
            If ds Is Nothing Then Return Nothing
            If Not ds.Tables.Contains("Immobilisations") Then Return Nothing
            Return Find(ds.Tables("Immobilisations"))
        End Function

        Public Function Find(ByVal dt As DataTable) As DataRow
            If dt Is Nothing Then Return Nothing
            Dim rws() As DataRow = dt.Select(GetFilter)
            If rws.Length > 0 Then
                Return rws(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function Find() As ImmobilisationsDataSet.ImmobilisationsRow
            Dim immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow = Nothing

            Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
                Dim IOrdre As Nullable(Of Short)

                If Not (IsDBNull(Ordre)) Then
                    IOrdre = CShort(Ordre)
                Else
                    IOrdre = New Nullable(Of Short)
                End If

                Dim immobilisationsDT As ImmobilisationsDataSet.ImmobilisationsDataTable = immobilisationsTA.GetDataByIDossier_ICpt_IActi_IOrdre(Me.nDossier, Me.nCpt, Me.Acti, CShort(IOrdre))

                If (immobilisationsDT.Rows.Count > 0) Then
                    immobilisationsDR = CType(immobilisationsDT.Rows(0), ImmobilisationsDataSet.ImmobilisationsRow)
                End If
            End Using

            Return immobilisationsDR
        End Function

        Public Function Create(ByVal ds As DataSet) As DataRow
            If ds Is Nothing Then Return Nothing
            If Not ds.Tables.Contains("Immobilisations") Then Return Nothing
            Return Create(ds.Tables("Immobilisations"))
        End Function

        Public Function Create(ByVal dt As DataTable) As DataRow
            If dt Is Nothing Then Return Nothing
            Dim dr As DataRow = dt.NewRow
            dr("IDossier") = Me.nDossier
            dr("ICpt") = Me.nCpt
            dr("IActi") = Me.Acti
            dr("IOrdre") = Me.Ordre
            dr("INCompo") = Me.nCompo
            Return dr
        End Function
#End Region

    End Class
End Namespace

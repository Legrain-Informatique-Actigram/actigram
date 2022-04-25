Namespace AnnexesTiers.ClassesTechniques
    Public Class DAOType_Plan_Comptable

        Private _ConnString As String = Nothing
        Private _Type_Plan_ComptableTA As DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property Type_Plan_ComptableTA() As DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter
            Get
                Return Me._Type_Plan_ComptableTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter)
                Me._Type_Plan_ComptableTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._Type_Plan_ComptableTA = New DataSetBaremesTableAdapters.TYPE_PLAN_COMPTABLETableAdapter

            Me.Type_Plan_ComptableTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetType_Plan_Comptable(ByVal ID_TYPE_PLAN_COMPTABLE As Integer) As AnnexesTiers.ClassesMetier.Type_Plan_Comptable
            Dim type_PC As AnnexesTiers.ClassesMetier.Type_Plan_Comptable = Nothing

            Dim type_Plan_ComptableDT As DataSetBaremes.TYPE_PLAN_COMPTABLEDataTable = Me.Type_Plan_ComptableTA.GetDataByID_TYPE_PLAN_COMPTABLE(ID_TYPE_PLAN_COMPTABLE)

            If (type_Plan_ComptableDT.Rows.Count > 0) Then
                type_PC = New AnnexesTiers.ClassesMetier.Type_Plan_Comptable

                Dim type_Plan_ComptableDR As DataSetBaremes.TYPE_PLAN_COMPTABLERow = CType(type_Plan_ComptableDT.Rows(0), DataSetBaremes.TYPE_PLAN_COMPTABLERow)

                type_PC = Me.ValoriserType_Plan_Comptable(type_Plan_ComptableDR)
            End If

            Return type_PC
        End Function

        Public Function GetType_Plan_Comptable(ByVal CODE_TYPE_PLAN_COMPTABLE As String) As AnnexesTiers.ClassesMetier.Type_Plan_Comptable
            Dim type_PC As AnnexesTiers.ClassesMetier.Type_Plan_Comptable = Nothing

            Dim type_Plan_ComptableDT As DataSetBaremes.TYPE_PLAN_COMPTABLEDataTable = Me.Type_Plan_ComptableTA.GetDataByCODE_TYPE_PLAN_COMPTABLE(CODE_TYPE_PLAN_COMPTABLE)

            If (type_Plan_ComptableDT.Rows.Count > 0) Then
                type_PC = New AnnexesTiers.ClassesMetier.Type_Plan_Comptable

                Dim type_Plan_ComptableDR As DataSetBaremes.TYPE_PLAN_COMPTABLERow = CType(type_Plan_ComptableDT.Rows(0), DataSetBaremes.TYPE_PLAN_COMPTABLERow)

                type_PC = Me.ValoriserType_Plan_Comptable(type_Plan_ComptableDR)
            End If

            Return type_PC
        End Function
#End Region

#Region "Méthodes internes"
        Private Function ValoriserType_Plan_Comptable(ByVal type_Plan_ComptableDR As DataSetBaremes.TYPE_PLAN_COMPTABLERow) As AnnexesTiers.ClassesMetier.Type_Plan_Comptable
            Dim type_PC As AnnexesTiers.ClassesMetier.Type_Plan_Comptable = Nothing

            If Not (type_Plan_ComptableDR Is Nothing) Then
                type_PC = New AnnexesTiers.ClassesMetier.Type_Plan_Comptable()

                type_PC.ID_TYPE_PLAN_COMPTABLE = type_Plan_ComptableDR.ID_TYPE_PLAN_COMPTABLE

                If Not (type_Plan_ComptableDR.IsCODE_TYPE_PLAN_COMPTABLENull) Then
                    type_PC.CODE_TYPE_PLAN_COMPTABLE = type_Plan_ComptableDR.CODE_TYPE_PLAN_COMPTABLE
                Else
                    type_PC.CODE_TYPE_PLAN_COMPTABLE = String.Empty
                End If

                If Not (type_Plan_ComptableDR.IsLIBELLE_TYPE_PLAN_COMPTABLENull) Then
                    type_PC.LIBELLE_TYPE_PLAN_COMPTABLE = type_Plan_ComptableDR.LIBELLE_TYPE_PLAN_COMPTABLE
                Else
                    type_PC.LIBELLE_TYPE_PLAN_COMPTABLE = String.Empty
                End If
            End If

            Return type_PC
        End Function
#End Region

    End Class
End Namespace

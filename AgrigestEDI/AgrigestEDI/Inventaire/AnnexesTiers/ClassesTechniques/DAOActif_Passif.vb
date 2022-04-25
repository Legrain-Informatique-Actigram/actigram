Namespace AnnexesTiers.ClassesTechniques
    Public Class DAOActif_Passif

        Private _ConnString As String = Nothing
        Private _Actif_PassifTA As DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property Actif_PassifTA() As DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter
            Get
                Return Me._Actif_PassifTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter)
                Me._Actif_PassifTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._Actif_PassifTA = New DataSetBaremesTableAdapters.ACTIF_PASSIFTableAdapter

            Me.Actif_PassifTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetActif_Passif(ByVal ID_ACTIF_PASSIF As Integer) As AnnexesTiers.ClassesMetier.Actif_Passif
            Dim act_Pass As AnnexesTiers.ClassesMetier.Actif_Passif = Nothing

            Dim actif_PassifDT As DataSetBaremes.ACTIF_PASSIFDataTable = Me.Actif_PassifTA.GetDataByID_ACTIF_PASSIF(ID_ACTIF_PASSIF)

            If (actif_PassifDT.Rows.Count > 0) Then
                act_Pass = New AnnexesTiers.ClassesMetier.Actif_Passif

                Dim act_PassDR As DataSetBaremes.ACTIF_PASSIFRow = CType(actif_PassifDT.Rows(0), DataSetBaremes.ACTIF_PASSIFRow)

                act_Pass = Me.ValoriserActif_Passif(act_PassDR)
            End If

            Return act_Pass
        End Function

        Public Function GetActif_Passif(ByVal CODE_ACTIF_PASSIF As String) As AnnexesTiers.ClassesMetier.Actif_Passif
            Dim act_Pass As AnnexesTiers.ClassesMetier.Actif_Passif = Nothing

            Dim actif_PassifDT As DataSetBaremes.ACTIF_PASSIFDataTable = Me.Actif_PassifTA.GetDataByCODE_ACTIF_PASSIF(CODE_ACTIF_PASSIF)

            If (actif_PassifDT.Rows.Count > 0) Then
                act_Pass = New AnnexesTiers.ClassesMetier.Actif_Passif

                Dim act_PassDR As DataSetBaremes.ACTIF_PASSIFRow = CType(actif_PassifDT.Rows(0), DataSetBaremes.ACTIF_PASSIFRow)

                act_Pass = Me.ValoriserActif_Passif(act_PassDR)
            End If

            Return act_Pass
        End Function
#End Region

#Region "Méthodes internes"
        Private Function ValoriserActif_Passif(ByVal actif_PassifDR As DataSetBaremes.ACTIF_PASSIFRow) As AnnexesTiers.ClassesMetier.Actif_Passif
            Dim act_Pass As AnnexesTiers.ClassesMetier.Actif_Passif = Nothing

            If Not (actif_PassifDR Is Nothing) Then
                act_Pass = New AnnexesTiers.ClassesMetier.Actif_Passif

                act_Pass.ID_ACTIF_PASSIF = actif_PassifDR.ID_ACTIF_PASSIF

                If Not (actif_PassifDR.IsCODE_ACTIF_PASSIFNull) Then
                    act_Pass.CODE_ACTIF_PASSIF = actif_PassifDR.CODE_ACTIF_PASSIF
                Else
                    act_Pass.CODE_ACTIF_PASSIF = String.Empty
                End If

                If Not (actif_PassifDR.IsLIBELLE_ACTIF_PASSIFNull) Then
                    act_Pass.LIBELLE_ACTIF_PASSIF = actif_PassifDR.LIBELLE_ACTIF_PASSIF
                Else
                    act_Pass.LIBELLE_ACTIF_PASSIF = String.Empty
                End If
            End If

            Return act_Pass
        End Function
#End Region

    End Class
End Namespace

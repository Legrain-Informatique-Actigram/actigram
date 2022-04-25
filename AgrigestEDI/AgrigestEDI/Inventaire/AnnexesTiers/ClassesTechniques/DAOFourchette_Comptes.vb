Imports System.Data.OleDb

Namespace AnnexesTiers.ClassesTechniques
    Public Class DAOFourchette_Comptes

        Private _ConnString As String = Nothing
        Private _Fourchette_ComptesTA As DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter

#Region "Propriétés"
        Public Property ConnString() As String
            Get
                Return Me._ConnString
            End Get
            Set(ByVal value As String)
                Me._ConnString = value
            End Set
        End Property

        Public Property Fourchette_ComptesTA() As DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter
            Get
                Return Me._Fourchette_ComptesTA
            End Get
            Set(ByVal value As DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter)
                Me._Fourchette_ComptesTA = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New(ByVal connString As String)
            Me._ConnString = connString
            Me._Fourchette_ComptesTA = New DataSetBaremesTableAdapters.FOURCHETTE_COMPTESTableAdapter

            Me.Fourchette_ComptesTA.Connection.ConnectionString = Me.ConnString
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetFourchette_Comptes(ByVal ID_FOURCHETTE_COMPTES As Integer) As AnnexesTiers.ClassesMetier.Fourchette_Comptes
            Dim fourch_cpts As AnnexesTiers.ClassesMetier.Fourchette_Comptes = Nothing

            Dim fourchette_ComptesDT As DataSetBaremes.FOURCHETTE_COMPTESDataTable = Me.Fourchette_ComptesTA.GetDataByID_FOURCHETTE_COMPTE(ID_FOURCHETTE_COMPTES)

            If (fourchette_ComptesDT.Rows.Count > 0) Then
                fourch_cpts = New AnnexesTiers.ClassesMetier.Fourchette_Comptes

                Dim fourchette_ComptesDR As DataSetBaremes.FOURCHETTE_COMPTESRow = CType(fourchette_ComptesDT.Rows(0), DataSetBaremes.FOURCHETTE_COMPTESRow)

                fourch_cpts.ID_FOURCHETTE_COMPTE = fourchette_ComptesDR.ID_FOURCHETTE_COMPTE

                If Not (fourchette_ComptesDR.IsCOMPTE_DEBNull) Then
                    fourch_cpts.COMPTE_DEB = fourchette_ComptesDR.COMPTE_DEB
                Else
                    fourch_cpts.COMPTE_DEB = String.Empty
                End If

                If Not (fourchette_ComptesDR.IsCOMPTE_FINNull) Then
                    fourch_cpts.COMPTE_FIN = fourchette_ComptesDR.COMPTE_FIN
                Else
                    fourch_cpts.COMPTE_FIN = String.Empty
                End If

                If Not (fourchette_ComptesDR.IsID_ACTIF_PASSIFNull) Then
                    fourch_cpts.ID_ACTIF_PASSIF = fourchette_ComptesDR.ID_ACTIF_PASSIF
                Else
                    fourch_cpts.ID_ACTIF_PASSIF = New Nullable(Of Long)
                End If

                If Not (fourchette_ComptesDR.IsPOSITIONNull) Then
                    fourch_cpts.POSITION = fourchette_ComptesDR.POSITION
                Else
                    fourch_cpts.POSITION = New Nullable(Of Long)
                End If

                If Not (fourchette_ComptesDR.IsEST_DETAILLENull) Then
                    fourch_cpts.EST_DETAILLE = fourchette_ComptesDR.EST_DETAILLE
                Else
                    fourch_cpts.EST_DETAILLE = New Nullable(Of Boolean)
                End If

                If Not (fourchette_ComptesDR.IsID_TYPE_PLAN_COMPTABLENull) Then
                    fourch_cpts.ID_TYPE_PLAN_COMPTABLE = fourchette_ComptesDR.ID_TYPE_PLAN_COMPTABLE
                Else
                    fourch_cpts.ID_TYPE_PLAN_COMPTABLE = New Nullable(Of Long)
                End If

                'Infos ACTIF_PASSIF
                If Not (fourchette_ComptesDR.IsID_ACTIF_PASSIFNull) Then
                    Dim gestAct_Pass As New AnnexesTiers.ClassesControleur.GestionnaireActif_Passif(Me.ConnString)

                    fourch_cpts.Actif_Passif = gestAct_Pass.GetActif_Passif(fourchette_ComptesDR.ID_ACTIF_PASSIF)
                End If

                'Infos TYPE_PLAN_COMPTABLE
                If Not (fourchette_ComptesDR.IsID_TYPE_PLAN_COMPTABLENull) Then
                    Dim gestType_PC As New AnnexesTiers.ClassesControleur.GestionnaireType_Plan_Comptable(Me.ConnString)

                    fourch_cpts.Type_Plan_Comptable = gestType_PC.GetType_Plan_Comptable(fourchette_ComptesDR.ID_TYPE_PLAN_COMPTABLE)
                End If
            End If

            Return fourch_cpts
        End Function

        Public Function GetListeInventairesLignesParCompte(ByVal compte As String, ByVal id_Type_Plan_Comptable As Integer) _
                                                As AnnexesTiers.ClassesMetier.ListeFourchettes_Comptes

            Dim listeFourch_Cpts As New AnnexesTiers.ClassesMetier.ListeFourchettes_Comptes

            Dim fourchette_ComptesDT As DataSetBaremes.FOURCHETTE_COMPTESDataTable = Me.Fourchette_ComptesTA.GetDataByCOMPTE_DEBEtCOMPTE_FINEtID_TYPE_PLAN_COMPTABLE(compte, compte, id_Type_Plan_Comptable)

            For Each fourchette_ComptesDR As DataSetBaremes.FOURCHETTE_COMPTESRow In fourchette_ComptesDT.Rows
                Dim fourch_Cpts As AnnexesTiers.ClassesMetier.Fourchette_Comptes = Me.GetFourchette_Comptes(fourchette_ComptesDR.ID_FOURCHETTE_COMPTE)

                listeFourch_Cpts.Add(fourch_Cpts)
            Next

            Return listeFourch_Cpts
        End Function
#End Region

    End Class
End Namespace

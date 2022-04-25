Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class GestionCube

    Private _Cube As sg_cube

    Public Enum TypeProvider
        SqlServer = 1
        Access = 2
    End Enum


#Region "Propriétés"
    Public Property Cube() As sg_cube
        Get
            Return Me._Cube
        End Get
        Set(ByVal Value As sg_cube)
            Me._Cube = Value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal cubeRow As DataSetCubes.CubeRow, ByVal connString As String, Optional ByVal typeProvider As TypeProvider = TypeProvider.SqlServer)
        Try
            Me._Cube = New sg_cube

            If Not (cubeRow.IsSqlNull) Then
                Me._Cube.p_DataTable = Me.CreerDataTableCube(connString, cubeRow.Sql, typeProvider)
            End If

            Me.ValoriserParametresCube(cubeRow)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ValoriserParametresCube(ByVal cubeRow As DataSetCubes.CubeRow)
        If Not (cubeRow.Isle_titreNull) Then
            Me._Cube.le_titre = cubeRow.le_titre
        End If

        If Not (cubeRow.Isformat_defautNull) Then
            Me._Cube.format_defaut = cubeRow.format_defaut
        End If

        If Not (cubeRow.Isle_champ_dateNull) Then
            Me._Cube.le_champ_date = cubeRow.le_champ_date
        End If

        If Not (cubeRow.Isle_type_dateNull) Then
            Me._Cube.le_type_date = cubeRow.le_type_date
        End If

        If Not (cubeRow.Isles_champs_formulesNull) Then
            Me._Cube.les_champs_formules = cubeRow.les_champs_formules
        End If

        If Not (cubeRow.Isles_dimensionsNull) Then
            Me._Cube.les_dimensions = cubeRow.les_dimensions
        End If

        If Not (cubeRow.Isles_dimensions_invNull) Then
            Me._Cube.les_dimensions_inv = cubeRow.les_dimensions_inv
        End If

        If Not (cubeRow.Isles_formulesNull) Then
            Me._Cube.les_formules = cubeRow.les_formules
        End If

        If Not (cubeRow.Isles_mesuresNull) Then
            Me._Cube.les_mesures = cubeRow.les_mesures
        End If

        If Not (cubeRow.Isles_titres_dimNull) Then
            Me._Cube.les_titres_dim = cubeRow.les_titres_dim
        End If

        If Not (cubeRow.Isles_titres_dim_invNull) Then
            Me._Cube.les_titres_dim_inv = cubeRow.les_titres_dim_inv
        End If

        If Not (cubeRow.Isles_titres_mesNull) Then
            Me._Cube.les_titres_mes = cubeRow.les_titres_mes
        End If

        If Not (cubeRow.Isles_types_mesuresNull) Then
            Me._Cube.les_types_mesures = cubeRow.les_types_mesures
        End If

        If Not (cubeRow.Isouvert_hNull) Then
            Me._Cube.ouvert_h = cubeRow.ouvert_h
        End If

        If Not (cubeRow.Isouvert_vNull) Then
            Me._Cube.ouvert_v = cubeRow.ouvert_v
        End If

        If Not (cubeRow.Isp_froozeNull) Then
            Me._Cube.p_frooze = cubeRow.p_frooze
        End If

        If Not (cubeRow.Isp_lookNull) Then
            If Not (System.IO.File.Exists(cubeRow.p_look)) Then
                Dim cheminLook As String = Utilitaires.CheminComplet(cubeRow.p_look)

                If (System.IO.File.Exists(cheminLook)) Then
                    Me._Cube.p_look = cheminLook
                End If
            Else
                Me._Cube.p_look = cubeRow.p_look
            End If
        End If

        If Not (cubeRow.Isp_modaleNull) Then
            Me._Cube.p_modale = cubeRow.p_modale
        End If

        If Not (cubeRow.Isp_nom_fichierNull) Then
            Me._Cube.p_nom_fichier = cubeRow.p_nom_fichier
        End If

        If Not (cubeRow.Isp_paramNull) Then
            Me._Cube.p_param = cubeRow.p_param
        End If

        If Not (cubeRow.Isp_on_exporteNull) Then
            Me._Cube.p_on_exporte = cubeRow.p_on_exporte
        End If

        If Not (cubeRow.Isp_superutilisateurNull) Then
            Me._Cube.p_superutilisateur = cubeRow.p_superutilisateur
        End If

        If Not (cubeRow.Isp_texte_enteteNull) Then
            Me._Cube.p_texte_entete = cubeRow.p_texte_entete
        End If
    End Sub

    Private Function CreerDataTableCube(ByVal connString As String, ByVal sql As String, Optional ByVal typeProvider As TypeProvider = GestionCube.TypeProvider.SqlServer) As DataTable
        Dim sqlQuery As String = String.Empty
        Dim ds As New DataSet

        Select Case typeProvider
            Case GestionCube.TypeProvider.SqlServer
                Using sqlConn As New SqlConnection(connString)
                    sqlConn.Open()

                    sqlQuery = sql

                    Dim sqlComm As New SqlCommand

                    sqlComm.CommandText = sqlQuery

                    sqlComm.Connection = sqlConn

                    Dim sqlDA As New SqlDataAdapter(sqlComm)

                    sqlDA.Fill(ds, "TableCube")
                End Using
            Case GestionCube.TypeProvider.Access
                Using oleDbConn As New OleDbConnection(connString)
                    oleDbConn.Open()

                    sqlQuery = sql

                    Dim oleDbComm As New OleDbCommand

                    oleDbComm.CommandText = sqlQuery

                    oleDbComm.Connection = oleDbConn

                    Dim oleDbDA As New OleDbDataAdapter(oleDbComm)

                    oleDbDA.Fill(ds, "TableCube")
                End Using
        End Select

        Return ds.Tables("TableCube")
    End Function

    Public Sub ChargerCube()
        If Not (Me._Cube.p_DataTable Is Nothing) Then
            Me._Cube.charge()
        End If
    End Sub
#End Region

End Class

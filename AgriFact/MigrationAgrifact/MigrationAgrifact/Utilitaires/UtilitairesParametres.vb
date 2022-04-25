Namespace Utilitaires
    Public Class UtilitairesParametres

#Region "Méthodes partagées"
        Public Shared Sub InitialiserParametres(ByVal parametres As ArrayList, ByVal instanceSQL As String)
            Dim chemin As String = String.Empty
            Dim ancienChemin As String = String.Empty

            chemin = ExecParam.CheminFichierParam("Nouvelle")

            If Not (IO.File.Exists(chemin)) Then
                ancienChemin = ExecParam.CheminFichierParam("Ancienne")

                If IO.File.Exists(ancienChemin) Then
                    'création du répertoire Actigram dans le répertoire ApplicationData si nécessaire
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(chemin))

                    IO.File.Copy(ancienChemin, chemin)
                End If
            End If

            Dim fichierParametre As String = chemin

            If IO.File.Exists(fichierParametre) Then
                Dim dsParamLocaux As New DataSet

                dsParamLocaux.ReadXml(fichierParametre)

                If dsParamLocaux.Tables.Contains("Parametres") Then
                    Dim tb As DataTable = dsParamLocaux.Tables("Parametres")

                    CreateColumn(tb, "NomDossier", GetType(String))
                    CreateColumn(tb, "ServeurSQL", GetType(String))
                    CreateColumn(tb, "BaseSQL", GetType(String))
                    CreateColumn(tb, "saPwd", GetType(String))

                    'Enregistrer tous les dossiers
                    For Each par As ExecParam In parametres
                        EcrireParametres(tb, par)
                    Next

                    'Virer toutes les lignes parametres non initialisées (ServeurSQL vide)
                    Dim rwTodelete As New ArrayList

                    For Each rw As DataRow In tb.Rows
                        If Convert.ToString(rw("ServeurSQL")).Length = 0 _
                        Or String.Compare(Convert.ToString(rw("ServeurSQL")), "localhost\agrifact", True) = 0 Then
                            rwTodelete.Add(rw)
                        End If
                    Next

                    For Each rw As DataRow In rwTodelete
                        rw.Delete()
                    Next
                End If

                dsParamLocaux.WriteXml(fichierParametre)
            End If
        End Sub

        Public Shared Sub CreateColumn(ByVal tb As DataTable, ByVal nomCol As String, ByVal type As Type)
            If Not tb.Columns.Contains(nomCol) Then
                tb.Columns.Add(nomCol, type)
            End If
        End Sub

        Public Shared Sub EcrireParametres(ByVal tb As DataTable, ByVal par As ExecParam)
            Dim rw As DataRow

            Select Case tb.Rows.Count
                Case 0 'Cas impossible à priori
                    Exit Sub
                Case Else
                    Dim rows() As DataRow = tb.Select("NomDossier='" & par.NomDossier & "'")

                    If rows.Length = 0 Then
                        'Le dossier n'existe pas, on va le créer en dupliquant la premiere ligne
                        rw = tb.LoadDataRow(tb.Rows(0).ItemArray, True)
                    Else
                        rw = rows(0)
                    End If
            End Select

            rw.Item("NomDossier") = par.NomDossier
            rw.Item("ServeurSQL") = par.ServeurSQL
            rw.Item("BaseSQL") = par.BaseSQL
            rw.Item("saPwd") = par.saPWd
        End Sub
#End Region

    End Class
End Namespace

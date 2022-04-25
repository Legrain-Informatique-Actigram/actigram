Public Module Main
    Public Sub Main()
        Dim doInstall As Boolean
        Dim pars As New ArrayList
        Dim args() As String = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            For Each arg As String In args
                Dim param As CommandParam = CommandParam.Parse(arg)

                Select Case param.Name
                    Case "-help"
                        MsgBox(Usage)
                        Exit Sub
                    Case "-dossier"
                        Try
                            If param.Value = "tous" Then
                                pars = ExecParam.ReadAllParams
                            Else
                                pars.Add(ExecParam.ReadParam(param.Value))
                            End If
                        Catch ex As Exception
                            MsgBox("Erreur dans la lecture des dossiers : " & vbCrLf & ex.Message)
                            Exit Sub
                        End Try
                    Case "-conn"
                        Try
                            pars.Add(ExecParam.ParseConnString(param.Value))
                        Catch ex As Exception
                            MsgBox("Erreur dans la lecture des paramètres : " & vbCrLf & ex.Message)
                            Exit Sub
                        End Try
                    Case "-auto"
                        doInstall = True
                End Select
            Next
        End If

        If pars.Count = 0 Then pars.Add(ExecParam.DefaultParam)

        If doInstall Then
            Try
                Cursor.Current = Cursors.WaitCursor
                'Si plantage sur un dossier, passer au suivant
                For Each par As ExecParam In pars
                    Try
                        Dim upd As New DatabaseUpdate(par.Serveur, par.Base, par.Login, par.SaPWd)

                        upd.Update()

                        MsgBox(String.Format("La base '{0}' à été mise à jour correctement.", par.Base), MsgBoxStyle.Information, "Mise à jour")
                    Catch ex As ArgumentException
                        'On ne fait rien : ce sont les messages qui doivent être silencieux
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                Cursor.Current = Cursors.Default
            End Try
            Application.Exit()
        Else
            Application.EnableVisualStyles()
            Application.Run(New FrMain(pars(0)))
        End If
    End Sub

    Public Sub LogException(ByVal ex As Exception)
        MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
    End Sub

    Private Function Usage() As String
        Return "Parametres : " & vbCrLf & _
                vbTab & "-help : Instructions" & vbCrLf & _
                vbTab & "-dossier=[<NomDossier>|tous] : Nom du dossier dont la base doit être mise à jour " & vbCrLf & _
                        "ou 'tous' pour mettre à jour toutes les bases paramétrées." & vbCrLf & _
                vbTab & "-conn=[<ConnectionString>] : chaine de connexion à la base qui doit être mise à jour." & vbCrLf & _
                vbTab & "-auto : Mise à jour automatique"
    End Function

    Private Class CommandParam
        Public Name As String
        Public Value As String
        Public Sub New()
        End Sub
        Public Sub New(ByVal arg As String)
            Dim c As CommandParam = Parse(arg)
            Me.Name = c.Name
            Me.Value = c.Value
        End Sub
        Public Shared Function Parse(ByVal arg As String) As CommandParam
            Dim c As New CommandParam
            If arg.IndexOf("=") >= 0 Then
                c.Name = arg.Substring(0, arg.IndexOf("=")).ToLower
                c.Value = arg.Substring(arg.IndexOf("=") + 1).Replace(Chr(34), "")
            Else
                c.Name = arg.ToLower
                c.Value = ""
            End If

            Return c
        End Function
    End Class

    Public Class ExecParam
        Public Serveur As String
        Public Base As String
        Public Login As String
        Public SaPWd As String

        Private Const FICHIER_PARAMETRE As String = "Parametres.xml"
        Private Const CHEMIN_ACTIGRAM_AGRIFACT As String = "Actigram\AgriFact\"

        Public Sub New()

        End Sub

        Public Shared Function ParseConnString(ByVal connString As String) As ExecParam
            Dim cb As New SqlClient.SqlConnectionStringBuilder(connString)
            Dim res As New ExecParam
            res.Serveur = cb.DataSource
            res.Base = cb.InitialCatalog
            If Not cb.IntegratedSecurity Then
                res.Login = cb.UserID
                res.SaPWd = cb.Password
            End If
            Return res
        End Function

        Public Shared Function ReadParam(ByVal NomDossier As String) As ExecParam
            Dim tb As DataTable = LoadParams()
            For Each rw As DataRow In tb.Rows
                If String.Compare(rw("NomDossier"), NomDossier, True) = 0 Then
                    Return ReadParam(rw)
                End If
            Next
            Throw New Exception(String.Format("Aucun dossier nommé '{0}' n'a été trouvé.", NomDossier))
        End Function

        Public Shared Function ReadParam(ByVal index As Integer) As ExecParam
            Dim tb As DataTable = LoadParams()
            If index < tb.Rows.Count Then
                Return ReadParam(tb.Rows(index))
            Else
                Throw New IndexOutOfRangeException(String.Format("Le fichier paramètre ne contient que {0} dossiers", tb.Rows.Count))
            End If
        End Function

        Public Shared Function ReadAllParams() As ArrayList
            Dim tb As DataTable = LoadParams()
            Dim res As New ArrayList
            For Each rw As DataRow In tb.Rows
                res.Add(ReadParam(rw))
            Next
            Return res
        End Function

        Private Shared Function LoadParams() As DataTable
            Dim fichierParametre As String = String.Empty

            fichierParametre = CheminFichierParam()

            If IO.File.Exists(fichierParametre) Then
                Dim dsParamLocaux As New DataSet

                dsParamLocaux.ReadXml(fichierParametre)

                If dsParamLocaux.Tables.Contains("Parametres") Then
                    Return dsParamLocaux.Tables("Parametres")
                Else
                    Throw New Exception("Fichier paramètre malformé")
                End If
            Else
                Throw New Exception("Fichier paramètre introuvable")
            End If
        End Function

        Public Shared Function CheminFichierParam() As String
            Dim chemin As String = String.Empty
            Dim ancienChemin As String = String.Empty

            chemin = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIER_PARAMETRE)

            If Not (IO.File.Exists(chemin)) Then
                ancienChemin = IO.Path.Combine(Application.StartupPath, FICHIER_PARAMETRE)

                If IO.File.Exists(ancienChemin) Then
                    'création du répertoire Actigram dans le répertoire ApplicationData si nécessaire
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(chemin))

                    'Déplacement du Parametres.xml au nouvel emplacement
                    IO.File.Move(ancienChemin, chemin)

                    chemin = ancienChemin
                End If
            End If

            Return chemin
        End Function


        Public Shared Function ReadParam(ByVal rw As DataRow) As ExecParam
            Dim par As New ExecParam

            With par
                If Not (IsDBNull(rw.Item("ServeurSQL"))) Then
                    .Serveur = rw.Item("ServeurSQL")
                End If

                If Not (IsDBNull(rw.Item("BaseSQL"))) Then
                    .Base = rw.Item("BaseSQL")
                End If

                .Login = "sa"

                If Not (IsDBNull(rw.Item("saPwd"))) Then
                    .SaPWd = rw.Item("saPwd")
                End If
            End With

            Return par
        End Function

        Public Shared Function DefaultParam() As ExecParam
            Dim par As New ExecParam
            With par
                .Serveur = ".\Agrifact"
                .Base = "Agrifact"
                .Login = "sa"
                .SaPWd = "ludo"
            End With
            Return par
        End Function
    End Class
End Module
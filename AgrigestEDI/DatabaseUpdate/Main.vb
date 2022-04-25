Public Module Main

    Public Sub Main()
        Dim doInstall As Boolean
        Dim pars As New List(Of ExecParam)
        Dim args() As String = Environment.GetCommandLineArgs

        If args.Length > 1 Then
            For Each arg As String In args
                Dim param As CommandParam = CommandParam.Parse(arg)

                Select Case param.Name
                    Case "-help"
                        MsgBox(Usage)
                        Exit Sub
                    Case "-base"
                        If param.Value.ToLower = "auto" Then
                            'Lire le fichier paramètre pour déterminer les bases à mettre à jour
                            Try
                                pars.AddRange(ExecParam.ReadAllParams)
                            Catch ex As ApplicationException
                                Debug.WriteLine("Erreur :" & ex.Message)
                            End Try
                        Else
                            'Faire un paramètre avec le chemin indiqué
                            If Not IO.File.Exists(param.Value) Then
                                Debug.WriteLine("Fichier introuvable : " & param.Value)
                            Else
                                pars.Add(New ExecParam(param.Value))
                            End If
                        End If
                    Case "-expl"
                        Try
                            pars.Add(ExecParam.ReadParam(param.Value))
                        Catch ex As ApplicationException
                            Debug.WriteLine("Erreur :" & ex.Message)
                        End Try
                    Case "-auto"
                        doInstall = True
                End Select
            Next
        End If

        If doInstall Then
            'Si pas de fichier paramètre : on sort
            If pars.Count = 0 Then Application.Exit() : Exit Sub

            Try
                Cursor.Current = Cursors.WaitCursor
                'Si plantage sur un dossier, passer au suivant
                For Each par As ExecParam In pars
                    Debug.WriteLine("Update : " & par.CheminBase)

                    Try
                        Dim upd As New DatabaseUpdate(par.CheminBase)
                        upd.Update()
                        MessageBox.Show(String.Format("La base '{0}' à été mise à jour correctement.", par.CheminBase), "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If pars.Count = 0 Then
                Application.Run(New FrMain())
            Else
                Application.Run(New FrMain(pars(0)))
            End If
        End If
    End Sub

    Private Function Usage() As String
        Return "Parametres : " & vbCrLf & _
                vbTab & "-help : Instructions" & vbCrLf & _
                vbTab & "-base=[<CheminBase>|auto] : Chemin de la base qui doit être mise à jour " & vbCrLf & _
                        "ou 'auto' pour déterminer le chemin en fonction du paramètrage." & vbCrLf & _
                vbTab & "-expl=<codeExpl> : Code de l'exploitation qui doit être mise à jour." & vbCrLf & _
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

End Module
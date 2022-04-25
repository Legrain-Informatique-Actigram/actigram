Module Accueil

    Sub Main()
        Dim migrationAgrifact As New Migration

        Try
            migrationAgrifact.MigrerAgrifact()
        Catch ex As Exception
            Migration.log.AppendFormat("{0}" & vbCrLf, ex.Message)

            Console.WriteLine(ex.Message)
            Console.WriteLine("Problème lors de la migration d'Agrifact.")
            Console.WriteLine("Appuyez sur Entrée pour quitter...")
            Console.ReadLine()
        Finally
            'Ecriture dans le fichier log
            Dim nomFichierLog As String = String.Format("log_MigrationAgrifact_{0:ddMMyyyyhhmmss}.log", Now)

            Using sw As IO.StreamWriter = New IO.StreamWriter(Environment.CurrentDirectory & "\" & nomFichierLog, False)
                sw.Write(Migration.log)
                sw.Close()
            End Using
        End Try
    End Sub

End Module

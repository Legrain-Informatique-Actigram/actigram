Public Class ParametresInstallation

    <Xml.Serialization.XmlArray(), Xml.Serialization.XmlArrayItem("Dossier", GetType(ParametresDossier))> Public Dossiers As New List(Of ParametresDossier)
    <Xml.Serialization.XmlElement()> Public InstanceSql As String = "AGRIFACT"
    <Xml.Serialization.XmlElement()> Public VersionSql As String = "MSDE"
    <Xml.Serialization.XmlElement()> Public Account As String = Nothing
    <Xml.Serialization.XmlElement()> Public SaPwd As String = Nothing
    <Xml.Serialization.XmlElement()> Public AgrifactKey As String = Nothing
    <Xml.Serialization.XmlElement()> Public FichierParametresAppli As String = Nothing
    <Xml.Serialization.XmlElement()> Private Const FICHIER_PARAMETRE As String = "Parametres.xml"
    <Xml.Serialization.XmlElement()> Private Const CHEMIN_ACTIGRAM_AGRIFACT As String = "Actigram\AgriFact\"

#Region "Constructeur"
#End Region

#Region "Méthodes partagées"
    Public Shared Function ParametresDefaut() As ParametresInstallation
        'S'il y a un dossier présent dans le fichier Parametres.xml
        'et qu'il n'est pas vierge, on le charge
        Dim chemin As String = String.Empty

        chemin = CheminFichierParam()

        If IO.File.Exists(chemin) Then
            Dim p As New ParametresInstallation
            Dim d As New ParametresDossier
            Dim dsParamLocaux As New DataSet

            With dsParamLocaux
                .ReadXml(chemin)

                If .Tables.Contains("Parametres") _
                    AndAlso .Tables("Parametres").Columns.Contains("ServeurSQL") _
                    AndAlso Convert.ToString(.Tables("Parametres").Rows(0)("ServeurSQL")) <> "localhost\AGRIFACT" Then

                    With .Tables("Parametres")
                        d.BaseSql = Convert.ToString(.Rows(0)("BaseSQL"))
                        If .Columns.Contains("NomDossier") Then
                            d.NomDossier = Convert.ToString(.Rows(0)("NomDossier"))
                        End If
                    End With
                End If
            End With

            p.Dossiers.Add(d)

            p.FichierParametresAppli = chemin

            Return p
        Else : Return Nothing
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

                IO.File.Move(ancienChemin, chemin)
            End If
        End If

        Return chemin
    End Function

    Public Shared Function LoadXml(ByVal fichier As String) As ParametresInstallation
        If Not IO.File.Exists(fichier) Then Return Nothing

        Dim xser As New Xml.Serialization.XmlSerializer(GetType(ParametresInstallation))
        Dim sr As New IO.StreamReader(fichier)
        Dim par As ParametresInstallation = CType(xser.Deserialize(sr), ParametresInstallation)

        sr.Close()

        Return par
    End Function

    Public Shared Function ExpandVars(ByVal s As String, ByVal instanceName As String) As String
        Dim SqlData As String = String.Empty

        Try
            SqlData = Convert.ToString(Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Microsoft SQL Server\" & instanceName & "\Setup").GetValue("SQLDataRoot")) & "\Data"
        Catch ex As Exception
        End Try

        s = s.Replace("{App}", "{0}").Replace("{SqlData}", "{1}").Replace("{Wrk}", "{2}")

        Return String.Format(s, Application.StartupPath, SqlData, Environment.CurrentDirectory)
    End Function
#End Region
    
#Region "Méthodes diverses"
    Public Function GetDossier(ByVal NomDossier As String) As ParametresDossier
        Dim res As ParametresDossier = Nothing
        For Each p As ParametresDossier In Me.Dossiers
            If p.NomDossier = NomDossier Then
                res = p
                Exit For
            End If
        Next
        Return res
    End Function

    Public Sub WriteXml(ByVal fichier As String)
        Dim xser As New Xml.Serialization.XmlSerializer(GetType(ParametresInstallation))
        Dim sw As New IO.StreamWriter(fichier)
        xser.Serialize(sw, Me)
        sw.Close()
    End Sub

    Public Function ExpandVars(ByVal s As String) As String
        Return ExpandVars(s, Me.InstanceSql)
    End Function
#End Region

End Class

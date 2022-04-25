Namespace Controles
    Public Class GroupeControle

        <Xml.Serialization.XmlAttribute()> Public TitreGroupe As String
        <Xml.Serialization.XmlAttribute()> Public CodeProduit As String

        Public ListeDefinitionsControles As New List(Of DefinitionControle)

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal definitionControle As DefinitionControle)
            Me.New()
            Me.TitreGroupe = definitionControle.Groupe
            Me.CodeProduit = definitionControle.CodeProduit
            Me.ListeDefinitionsControles.Add(definitionControle)
        End Sub
#End Region

#Region "Méthodes partagées"
        Public Shared Function TriControles(ByVal listeDefinitionsControles As List(Of DefinitionControle)) As List(Of GroupeControle)
            Dim hashControles As New Dictionary(Of String, GroupeControle)

            For Each definitionControle As DefinitionControle In listeDefinitionsControles
                Dim key As String = definitionControle.CodeProduit & "|" & definitionControle.Groupe

                If Not hashControles.ContainsKey(key) Then
                    hashControles.Add(key, New GroupeControle(definitionControle))
                Else
                    hashControles(key).ListeDefinitionsControles.Add(definitionControle)
                End If
            Next

            Dim listeGroupesControles As New List(Of GroupeControle)

            For Each groupeControle As GroupeControle In hashControles.Values
                listeGroupesControles.Add(groupeControle)
            Next

            Return listeGroupesControles
        End Function

        Public Shared Sub Imprimer(ByVal listeDefinitionsControles As List(Of DefinitionControle))
            Try
                Cursor.Current = Cursors.WaitCursor

                Dim listeGroupesControles As List(Of GroupeControle) = GroupeControle.TriControles(listeDefinitionsControles)
                Dim xslFile As String = IO.Path.Combine(Application.StartupPath, "Etats\ImpressionControles.xsl")
                Dim htmlFile As String = GetTempFileName(".htm")
                My.Computer.FileSystem.WriteAllText(htmlFile, GetTransformXSLTFile(GroupeControle.GetXmlString(listeGroupesControles), xslFile), False)
                OuvrirFichier(htmlFile)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub
#End Region

#Region "XML"
        Public Shared Function GetXmlString(ByVal listeGroupesControles As List(Of GroupeControle)) As String
            Dim sb As New System.Text.StringBuilder

            Using sw As New IO.StringWriter(sb)
                EcrireXml(sw, listeGroupesControles)
            End Using

            Return sb.ToString
        End Function

        Private Shared Sub EcrireXml(ByVal sw As IO.TextWriter, ByVal listeGroupesControles As List(Of GroupeControle))
            Dim ser As New Xml.Serialization.XmlSerializer(GetType(List(Of GroupeControle)))
            ser.Serialize(sw, listeGroupesControles)
        End Sub
#End Region

    End Class
End Namespace

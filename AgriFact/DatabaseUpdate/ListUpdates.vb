Imports System.Xml.Serialization

Public Class Update
    <XmlAttributeAttribute()> Public VersionAvant As String
    <XmlAttributeAttribute()> Public VersionApres As String
    <XmlAttributeAttribute()> Public NomScript As String
End Class

Public Class ListUpdates

    <XmlArray(), XmlArrayItem("Update", GetType(Update))> Public Updates As New List(Of Update)

    Public Shared Function LoadFromFile(ByVal fichier As String) As ListUpdates
        Using sr As New IO.StreamReader(fichier, IO.FileMode.Open)
            Return LoadXml(sr)
        End Using
    End Function

    Public Shared Function LoadXml(ByVal xml As String) As ListUpdates
        Using sr As New IO.StringReader(xml)
            Return LoadXml(sr)
        End Using
    End Function

    Public Shared Function LoadXml(ByVal tr As IO.TextReader) As ListUpdates
        Dim xser As New Xml.Serialization.XmlSerializer(GetType(ListUpdates))
        Dim lst As ListUpdates = CType(xser.Deserialize(tr), ListUpdates)
        Return lst
    End Function

    Public Sub WriteXml(ByVal fichier As String)
        Dim xser As New XmlSerializer(GetType(ListUpdates))
        Dim sw As New IO.StreamWriter(fichier)
        xser.Serialize(sw, Me)
        sw.Close()
    End Sub

    Public Function GetNextUpdate(ByVal version As String) As Update
        For Each upd As Update In Updates
            If upd.VersionAvant >= version Then
                Return upd
            End If
        Next
        Return Nothing
    End Function

    Public Function GetNbUpdates(Optional ByVal version As String = "0") As Integer
        For Each upd As Update In Updates
            If upd.VersionAvant >= version Then
                Return 1 + GetNbUpdates(upd.VersionApres)
            End If
        Next
        Return 0
    End Function

End Class

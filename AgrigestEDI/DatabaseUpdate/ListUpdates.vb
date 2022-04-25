Imports System.Xml.Serialization

Public Class Update

    <XmlAttributeAttribute()> Public VersionAvant As String
    <XmlAttributeAttribute()> Public VersionApres As String
    <XmlAttributeAttribute()> Public NomScript As String

End Class

Public Class ListUpdates

    <XmlArray(), XmlArrayItem("Update", GetType(Update))> Public Updates As New ArrayList

#Region "Méthodes partagées"
    Public Shared Function LoadXml(ByVal fichier As String) As ListUpdates
        Dim fs As New IO.FileStream(fichier, IO.FileMode.Open)
        Return LoadXml(fs)
    End Function

    Public Shared Function LoadXml(ByVal s As IO.Stream) As ListUpdates
        Dim xser As New Xml.Serialization.XmlSerializer(GetType(ListUpdates))
        Dim lst As ListUpdates = CType(xser.Deserialize(s), ListUpdates)
        s.Close()
        Return lst
    End Function
#End Region

#Region "Méthodes diverses"
    Public Sub WriteXml(ByVal fichier As String)
        Dim xser As New XmlSerializer(GetType(ListUpdates))
        Dim sw As New IO.StreamWriter(fichier)
        xser.Serialize(sw, Me)
        sw.Close()
    End Sub

    'Public Function GetNextUpdate(ByVal version As String) As Update
    '    For Each upd As Update In Updates
    '        If upd.VersionAvant >= version Then
    '            Return upd
    '        End If
    '    Next
    '    Return Nothing
    'End Function

    Public Function GetNextUpdate(ByVal version As String) As Update
        If (IsNumeric(Replace(version, ".", ","))) Then
            For Each upd As Update In Updates
                If CDec(Replace(upd.VersionAvant, ".", ",")) >= CDec(Replace(version, ".", ",")) Then
                    Return upd
                End If
            Next
        End If

        Return Nothing
    End Function

    'Public Function GetNbUpdates(Optional ByVal version As String = "0") As Integer
    '    For Each upd As Update In Updates
    '        If upd.VersionAvant >= version Then
    '            Return 1 + GetNbUpdates(upd.VersionApres)
    '        End If
    '    Next
    '    Return 0
    'End Function

    Public Function GetNbUpdates(Optional ByVal version As String = "0") As Integer
        Dim nbUpdates As Integer = 0

        If (IsNumeric(Replace(version, ".", ","))) Then
            For Each upd As Update In Updates
                If (IsNumeric(Replace(upd.VersionAvant, ".", ","))) Then
                    If CDec(Replace(upd.VersionAvant, ".", ",")) >= CDec(Replace(version, ".", ",")) Then
                        nbUpdates += 1
                    End If
                End If
            Next
        End If

        Return nbUpdates
    End Function
#End Region

End Class

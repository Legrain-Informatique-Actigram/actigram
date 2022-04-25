Public Class ParametresDossier
    <Xml.Serialization.XmlElement()> Public NomDossier As String = "Agrifact"
    <Xml.Serialization.XmlElement()> Public BaseSql As String = "AGRIFACT"
    <Xml.Serialization.XmlElement()> Public FichierBaseSource As String = "{App}\MSDE\BaseDepart\AgriFactVide"
    <Xml.Serialization.XmlElement()> Public RepBaseDest As String = "{App}\Data"
    <Xml.Serialization.XmlElement()> Public RecreerUtils As Boolean = True

#Region "Méthodes partagées"
    Public Shared Function GetConnexionString(ByVal param As ParametresInstallation, ByVal dossier As ParametresDossier, Optional ByVal base As String = Nothing) As String
        Dim sa As String = String.Empty

        If param.SaPwd Is Nothing Then
            sa = "integrated security=true"
        Else
            sa = String.Format("user id=sa;password={0}", param.SaPwd)
        End If

        If base Is Nothing Then
            base = dossier.BaseSql
        End If

        Return String.Format("initial catalog={2};data source=.\{0};{1};persist security info=True", param.InstanceSql, sa, base)
    End Function
#End Region
    
End Class

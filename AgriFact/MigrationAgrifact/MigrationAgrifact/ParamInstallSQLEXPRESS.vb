Public Class ParamInstallSQLEXPRESS

    <Xml.Serialization.XmlElement()> Public InstanceSql As String = "SQLEXPRESS"
    <Xml.Serialization.XmlElement()> Public VersionSql As String = "SqlExpress"
    <Xml.Serialization.XmlElement()> Public Account As String = Nothing
    <Xml.Serialization.XmlElement()> Public SaPwd As String = Nothing
    <Xml.Serialization.XmlElement()> Public CheminAccesFichierInstallSQLEXPRESS As String = Nothing

#Region "Constructeur"
    Public Sub New(ByVal cheminFichierParam As String)
        If IO.File.Exists(cheminFichierParam) Then
            Dim dsParamLocaux As New DataSet

            With dsParamLocaux
                .ReadXml(cheminFichierParam)

                If .Tables.Contains("ParamInstallSQLEXPRESS") Then
                    With .Tables("ParamInstallSQLEXPRESS")
                        Me.InstanceSql = Convert.ToString(.Rows(0)("InstanceSql"))
                        Me.VersionSql = Convert.ToString(.Rows(0)("VersionSQL"))
                        Me.Account = Convert.ToString(.Rows(0)("Account"))
                        Me.SaPwd = Convert.ToString(.Rows(0)("SaPwd"))
                        Me.CheminAccesFichierInstallSQLEXPRESS = Convert.ToString(.Rows(0)("CheminAccesFichierInstallSQLEXPRESS"))
                    End With
                End If
            End With
        End If
    End Sub
#End Region

End Class

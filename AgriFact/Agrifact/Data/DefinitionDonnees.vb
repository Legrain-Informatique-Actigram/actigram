Public Class DefinitionDonnees
    <Xml.Serialization.XmlArray("Tables"), Xml.Serialization.XmlArrayItem("Table", GetType(Table))> Public Tables As List(Of Table)
    <Xml.Serialization.XmlArray("Relations"), Xml.Serialization.XmlArrayItem("Relation", GetType(Relation))> Public Relations As List(Of Relation)

    Public Shared Function Load() As DefinitionDonnees
        Return XmlSerializationUtils.DeSerializeFromString(Of DefinitionDonnees)(My.Resources.DefinitionDonnees)
    End Function

    Public Class Table
        <Xml.Serialization.XmlAttribute()> Public nom As String = ""
        <Xml.Serialization.XmlAttribute()> Public cle As String = ""
        <Xml.Serialization.XmlAttribute()> Public tri As String = ""
        <Xml.Serialization.XmlAttribute()> Public autonum As String = ""
        <Xml.Serialization.XmlAttribute()> Public filtre As String = ""
        <Xml.Serialization.XmlAttribute()> Public param As Boolean = False
        <Xml.Serialization.XmlAttribute()> Public ignoreErr As Boolean = False
    End Class

    Public Class Relation
        <Xml.Serialization.XmlAttribute()> Public nom As String = ""
        <Xml.Serialization.XmlAttribute()> Public parentTable As String = ""
        <Xml.Serialization.XmlAttribute()> Public parentCol As String = ""
        <Xml.Serialization.XmlAttribute()> Public childTable As String = ""
        <Xml.Serialization.XmlAttribute()> Public childCol As String = ""
        <Xml.Serialization.XmlAttribute()> Public creerContraintes As Boolean = False
        <Xml.Serialization.XmlAttribute()> Public childDeleteRule As String = ""
    End Class


    Private Shared _instance As DefinitionDonnees
    Public Shared ReadOnly Property Instance() As DefinitionDonnees
        Get
            If _instance Is Nothing Then
                _instance = Load()
            End If
            Return _instance
        End Get
    End Property


    Private _clearBeforeFill As Boolean=true
    Public Property ClearBeforeFill() As Boolean
        Get
            Return _clearBeforeFill
        End Get
        Set(ByVal value As Boolean)
            _clearBeforeFill = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub CreateRelations(ByVal ds As DataSet)
        For Each r As Relation In Me.Relations
            If ds.Tables.Contains(r.parentTable) _
            AndAlso ds.Tables.Contains(r.childTable) _
            AndAlso ds.Tables(r.parentTable).Columns.Contains(r.parentCol) _
            AndAlso ds.Tables(r.childTable).Columns.Contains(r.childCol) Then
                If ds.Relations.Contains(r.nom) Then
                    ds.Relations.Remove(r.nom)
                End If
                CreateRelation(ds, r)
            End If
        Next
    End Sub

    Private Sub CreateRelation(ByVal ds As DataSet, ByVal r As Relation)
        Dim dr As New DataRelation(r.nom, ds.Tables(r.parentTable).Columns(r.parentCol), ds.Tables(r.childTable).Columns(r.childCol), r.creerContraintes)
        ds.Relations.Add(dr)
        If dr.ChildKeyConstraint IsNot Nothing Then
            Select Case r.childDeleteRule
                Case "None"
                    dr.ChildKeyConstraint.UpdateRule = Rule.None
                    dr.ChildKeyConstraint.DeleteRule = Rule.None
                Case "Cascade"
                    dr.ChildKeyConstraint.UpdateRule = Rule.Cascade
                    dr.ChildKeyConstraint.DeleteRule = Rule.Cascade
            End Select
        End If
    End Sub

    Public Sub FillSchema(ByVal ds As DataSet, ByVal tablename As String)
        Using s As New SqlProxy
            FillSchema(ds, tablename, s)
        End Using
    End Sub

    Public Sub FillSchema(ByVal ds As DataSet, ByVal tablename As String, ByVal s As SqlProxy)
        Fill(ds, tablename, s, "1=0")
    End Sub

    Public Sub Fill(ByVal ds As DataSet, ByVal tablename As String, Optional ByVal where As String = Nothing)
        Using s As New SqlProxy
            Fill(ds, tablename, s, where)
        End Using
    End Sub

    Public Sub Fill(ByVal ds As DataSet, ByVal tablename As String, ByVal s As SqlProxy, Optional ByVal where As String = Nothing)
        For Each t As Table In Me.Tables
            If String.Equals(t.nom, tablename, StringComparison.InvariantCultureIgnoreCase) Then
                Fill(ds, t, s, where)
                Exit For
            End If
        Next
    End Sub

    Private Sub Fill(ByVal ds As DataSet, ByVal t As Table, ByVal s As SqlProxy, Optional ByVal where As String = Nothing)
        ChargerDonnees(s, ds, t.nom, t.cle, t.autonum, where)
    End Sub

    Private Sub ChargerDonnees(ByVal s As SqlProxy, ByVal ds As DataSet, ByVal strTable As String, ByVal strCle As String, Optional ByVal lstColAutoNum As String = "", Optional ByVal strWhere As String = "")
        Dim alreadyExisted As Boolean = ds.Tables.Contains(strTable)

        If String.IsNullOrEmpty(strWhere) Then
            s.Fill(ds, strTable, Me.ClearBeforeFill)
        Else
            s.FillBy(ds, strTable, strWhere, Me.ClearBeforeFill)
        End If

        If alreadyExisted Then Exit Sub

        If strCle <> "" Then
            Dim cols As New List(Of DataColumn)
            For Each colName As String In strCle.Split(","c)
                cols.Add(ds.Tables(strTable).Columns(colName.Trim))
            Next
            If cols.Count > 0 Then
                ds.Tables(strTable).PrimaryKey = cols.ToArray
            End If
        End If

        For Each cl As DataColumn In ds.Tables(strTable).Columns
            If cl.DataType Is GetType(Boolean) Then
                cl.DefaultValue = False
            End If
        Next

        For Each colName As String In Split(lstColAutoNum, ",")
            If ds.Tables(strTable).Columns.Contains(colName.Trim) Then
                With ds.Tables(strTable).Columns(colName.Trim)
                    .AutoIncrement = True
                    .AutoIncrementSeed = s.GetMaxValue(strTable, colName.Trim) + 1
                    .AutoIncrementStep = 1
                End With
            End If
        Next

        ds.Tables(strTable).DefaultView.Sort = strCle
    End Sub


    Public Shared Sub VerifierVersionBase()
        Using s As New SqlProxy
            VerifierVersionBase(s)
        End Using
    End Sub

    Public Shared Sub VerifierVersionBase(ByVal s As SqlProxy)
        Dim versionappli As Version = Reflection.Assembly.GetExecutingAssembly.GetName.Version
        Dim versionbase As Version = Nothing
        Try
            versionbase = New Version(CStr(s.ExecuteScalar("select valeur from ParamApplication where cle='VersionBase'")))
        Catch ex As Exception
            'On ne fait rien en cas d'exception, on remonte juste une version "0.0"
        End Try
        If versionbase Is Nothing Then versionbase = New Version("0.0")
        If CompareVersions(versionbase, versionappli, 2) > 0 Then
            Throw New ApplicationException(String.Format("L'application n'est pas à jour, vous devez utiliser la version {0}.", versionbase.ToString(2)))
        ElseIf CompareVersions(versionbase, versionappli, 2) < 0 Then
            Dim databaseUpdate As String = IO.Path.Combine(Application.StartupPath, "DatabaseUpdate.exe")
            If IO.File.Exists(databaseUpdate) Then
                Dim fv As FileVersionInfo = FileVersionInfo.GetVersionInfo(databaseUpdate)
                If versionappli.ToString(2) = fv.FileMajorPart & "." & fv.FileMinorPart _
                AndAlso MsgBox(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}." & vbCrLf & "Voulez-vous effectuer la mise à jour maintenant ?", versionappli.ToString(2)), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim pi As New ProcessStartInfo
                    With pi
                        .FileName = databaseUpdate
                        .Arguments = String.Format("-dossier=""{0}"" -auto", FrApplication.Parametres.NomDossier)
                        .UseShellExecute = True
                    End With
                    Dim p As Process = Process.Start(pi)
                    p.WaitForExit()
                    'Refaire la vérif
                    VerifierVersionBase(s)
                Else
                    Throw New ApplicationException(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}.", versionappli.ToString(2)))
                End If
            Else
                Throw New ApplicationException(String.Format("La base de données n'est pas à jour, elle doit être passée en version {0}.", versionappli.ToString(2)))
            End If
        End If
    End Sub

    Public Shared Function VerifIdentiteServeur(ByVal login As String, ByVal password As String) As DialogResult
        Dim res As DialogResult
        Dim cn As New SqlClient.SqlConnection(DefinitionDonnees.GetstrConnexion(login, password))
        Try
            cn.Open()
            'Requete sur la table Entreprise pour valider les droits de l'utilisateur 
            'et vérifier que la base est bien Agrifac
            Dim cmd As New SqlClient.SqlCommand("select count(*) as cnt from Entreprise", cn)
            cmd.ExecuteScalar()
            'Vérifier la version de la base
            'TODO FrDonnees.VerifierVersionBase(cn)
            cn.Close()
            res = System.Windows.Forms.DialogResult.OK
        Catch ex As SqlClient.SqlException
            Dim msg As String
            Select Case ex.Number
                Case 17 'Serveur introuvable
                    'Essayer de démarrer le serveur, on sait jamais.
                    If Not TryRestartServer(cn.DataSource) Then
                        msg = String.Format("Le serveur de base de données '{0}' est introuvable.", cn.DataSource)
                    Else
                        res = VerifIdentiteServeur(login, password)
                    End If
                Case 208 'Objet introuvable'
                    msg = String.Format("La base de données '{0}' n'est pas une base {1}.", cn.Database, Application.ProductName)
                    res = System.Windows.Forms.DialogResult.Abort
                Case 229 'Autorisation refusée
                    msg = String.Format("Vous n'avez pas les droits pour accéder à la base de données '{0}'.", cn.Database)
                    res = System.Windows.Forms.DialogResult.Abort
                Case 4060 'Base inexistante ou hors ligne
                    msg = String.Format("La base de données '{0}' n'existe pas ou vous n'avez pas les droits pour y accéder.", cn.Database)
                    res = System.Windows.Forms.DialogResult.Abort
                Case 18456 'Erreur de login password
                    res = System.Windows.Forms.DialogResult.Retry
                Case Else
                    msg = "Erreur : " & ex.Message
                    res = System.Windows.Forms.DialogResult.Abort
            End Select
            If res = System.Windows.Forms.DialogResult.Abort Then
                MsgBox(msg & vbCrLf & "L'application va se terminer.", MsgBoxStyle.Critical, "Attention")
            End If
        Catch ex As ApplicationException 'Retour de VerifierVersionBase
            MsgBox(ex.Message & vbCrLf & "L'application va se terminer.", MsgBoxStyle.Exclamation, "Attention")
            res = System.Windows.Forms.DialogResult.Abort
        Finally
            If Not cn Is Nothing AndAlso cn.State <> ConnectionState.Closed Then cn.Close()
        End Try
        Return res
    End Function

    Private Shared Function TryRestartServer(ByVal server As String) As Boolean
        server = server.ToUpper.Replace(Environment.MachineName.ToUpper, ".")
        If server.StartsWith(".") Then
            Dim cmd As String = "NET START MSSQL"
            If server.Length > 1 Then
                cmd &= "$" & server.Replace(".\", "")
            End If
            Dim pi As New ProcessStartInfo
            With pi
                .FileName = "cmd.exe"
                .Arguments = "/C """ & cmd & """"
                .CreateNoWindow = True
                .WindowStyle = ProcessWindowStyle.Hidden
            End With
            Dim p As Process = Process.Start(pi)
            p.WaitForExit(10000)
            Return p.ExitCode = 0
        Else
            Return False
        End If
    End Function

    Public Shared Function GetstrConnexion(ByVal Utilisateur As String, ByVal MotPasse As String) As String
        Dim strConnexion As String = "data source={0};initial catalog={1};user id={2};password={3};persist security info=True;Connect Timeout=10"
        Dim strBaseSQL As String = CStr(ParametresApplication.ValeurParametre("BASESQL", "Agrifact"))
        Dim strServerSQL As String = CStr(ParametresApplication.ValeurParametre("ServeurSQL", "DEV1\Agrifact"))
        If Utilisateur = "sa" Then MotPasse = CStr(ParametresApplication.ValeurParametre("saPwd", "ludo"))

        GRC.FrFusion.Base = strBaseSQL
        GRC.FrFusion.Server = strServerSQL
        GRC.FrFusion.sa = "sa"
        GRC.FrFusion.pwd = CStr(ParametresApplication.ValeurParametre("saPwd", "ludo"))

        Return String.Format(strConnexion, strServerSQL, strBaseSQL, Utilisateur, MotPasse)
    End Function
End Class

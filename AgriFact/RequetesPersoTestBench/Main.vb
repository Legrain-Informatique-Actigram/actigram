Public Class Main
    Private _connString As String
    Public Property ConnectionString() As String
        Get
            Return _connString
        End Get
        Set(ByVal value As String)
            _connString = value
            For Each fr As Form In Me.MdiChildren
                If TypeOf fr Is RequetesPerso.FrRequetePerso Then
                    CType(fr, RequetesPerso.FrRequetePerso).ConnectionString = value
                End If
            Next
            If value.Length > 0 Then
                My.Settings.LastConnString = value
            End If
            UpdateWindowText()
        End Set
    End Property


    Private Sub SplitOpen_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitOpen.ButtonClick
        Using dlg As New OpenFileDialog
            dlg.Filter = "Déifnitions de requêtes(*.qml)|*.qml"
            If dlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            Open(dlg.FileName)
        End Using
    End Sub

    Private Sub Open(ByVal filename As String)
        Try
            Dim fr As New RequetesPerso.FrRequetePerso(filename)
            With fr
                .ConnectionString = Me.ConnectionString
                .MdiParent = Me
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
            AddToMru(filename)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim fichier As String
        Using dlg As New SaveFileDialog
            dlg.Filter = "*.xml|*.xml"
            dlg.FileName = "requete.xml"
            If dlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
            fichier = dlg.FileName
        End Using
        Dim req As New RequetesPerso.Requete
        With req
            .Titre = "Requête test"
            .CommandText = "select * from Entreprise where codepostal like '%'+@cp+'%'"
            Dim p As New RequetesPerso.Parametre
            With p
                .Nom = "@cp"
                .Type = "String"
                .Libelle = "Code Postal"
                .ValeurDefaut = "31"
            End With
            .Parametres.Add(p)
            p = New RequetesPerso.Parametre
            With p
                .Nom = "@nom"
                .Type = "String"
                .Libelle = "Nom"
                .ValeurDefaut = ""
                Dim source As New RequetesPerso.SimpleComboDatasource
                With source.Values
                    .Add("Nom1")
                    .Add("Nom2")
                End With
                .Datasource = source
            End With
            .Parametres.Add(p)
            Dim c As New RequetesPerso.Colonne
            With c
                .Entete = "Nom"
                .Field = "Nom"
            End With
            .Colonnes.Add(c)
            c = New RequetesPerso.Colonne
            With c
                .Entete = "CP"
                .Field = "CodePostal"
            End With
            .Colonnes.Add(c)
            c = New RequetesPerso.Colonne
            With c
                .Entete = "Ville"
                .Field = "Ville"
            End With
            .Colonnes.Add(c)
            c = New RequetesPerso.Colonne
            With c
                .Entete = "Créé le"
                .Field = "DateCreation"
                .Format = "dd/MM/yy"
            End With
            .Colonnes.Add(c)
        End With
        req.Save(fichier)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With My.Settings
            If .MustUpgrade Then
                .Upgrade()
                .MustUpgrade = False
                .Save()
            End If
        End With
        If My.Settings.LastConnString.Length > 0 Then
            Me.ConnectionString = My.Settings.LastConnString
        End If
        For Each par As CommandParam In CommandParam.Parse(My.Application.CommandLineArgs)
            Select Case par.Name
                Case "-conn" : Me.ConnectionString = par.Value
                Case "-query" : Open(par.Value)
            End Select
        Next
        MajBoutons()
        UpdateWindowText()
    End Sub

    Private Sub TbConnexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbConnexion.Click
        Using fr As New FrParametres(Me.ConnectionString)
            If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.ConnectionString = fr.ConnectionString
                majboutons()
            End If
        End Using
    End Sub

    Private Sub MajBoutons()
        Me.SplitOpen.Enabled = Not String.IsNullOrEmpty(Me.ConnectionString)
    End Sub

    Private Sub SplitOpen_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitOpen.DropDownOpening
        SplitOpen.DropDownItems.Clear()
        If My.Settings.MruQueries Is Nothing Then Exit Sub
        For Each path As String In My.Settings.MruQueries
            If IO.File.Exists(path) Then
                SplitOpen.DropDownItems.Add(CreatePathMenu(path))
            End If
        Next
    End Sub

    Private Function CreatePathMenu(ByVal path As String) As ToolStripMenuItem
        Dim m As New ToolStripMenuItem
        With m
            .Text = IO.Path.GetFileNameWithoutExtension(path)
            .Tag = path
            AddHandler .Click, AddressOf PathMenuClick
        End With
        Return m
    End Function

    Private Sub PathMenuClick(ByVal sender As Object, ByVal e As EventArgs)
        If Not TypeOf sender Is ToolStripItem Then Exit Sub
        Open(Convert.ToString(CType(sender, ToolStripItem).Tag))
    End Sub

    Private Sub AddToMru(ByVal path As String)
        If My.Settings.MruQueries Is Nothing Then My.Settings.MruQueries = New Collections.Specialized.StringCollection
        With My.Settings.MruQueries
            If .Contains(path) Then .Remove(path)
            If .Count = My.Settings.MruLength Then .RemoveAt(.Count - 1)
            .Insert(0, path)
        End With
    End Sub

    Private Sub UpdateWindowText()
        Dim str As String = "Statistiques"
        If Me.ConnectionString IsNot Nothing AndAlso Me.ConnectionString.Length > 0 Then
            If SqlProxy.TestConnection(Me.ConnectionString) Then
                Dim sb As New SqlClient.SqlConnectionStringBuilder(Me.ConnectionString)
                str &= String.Format(" - connecté sur {1}\{0}", sb.InitialCatalog, sb.DataSource)
            End If
        End If
        Me.Text = str
    End Sub
End Class

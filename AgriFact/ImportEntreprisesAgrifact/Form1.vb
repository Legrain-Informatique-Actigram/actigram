Public Class Form1
    Private Function ConnectionString() As String
        Return Me.SqlConnectionConfig1.ConnectionStringBuilder.ConnectionString
    End Function

    Private Sub btImporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImporter.Click
        If Not IO.File.Exists(txtFic.Text) Then
            MsgBox("Fichier introuvable")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Me.pgBar.Visible = True

        Dim imp As New Importateur
        AddHandler imp.ReportProgress, AddressOf ImpReportsProgress

        Dim items As List(Of IDataItem) = ChargerFichier(imp)

        If items IsNot Nothing AndAlso items.Count > 0 Then
            Using conn As New SqlClient.SqlConnection(Me.SqlConnectionConfig1.ConnectionStringBuilder.ConnectionString)
                imp.Connection = conn
                imp.InsererItems(items)
            End Using
        Else
            MsgBox("Aucune entreprise trouvée dans le fichier")
        End If

        Me.lbStatus.Text = "Import terminé"
        Me.pgBar.Visible = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Function ChargerFichier(ByVal imp As Importateur) As List(Of IDataItem)
        Dim paramValues As New Dictionary(Of String, Object)
        paramValues.Add("nomFic", txtFic.Text)
        paramValues.Add("nbLinesIgnored", CInt(nudIgnoreLines.Value))
        paramValues.Add("NomAvecCivilite", False)
        paramValues.Add("nCompte", "41100000")

        Dim items As List(Of IDataItem) = Nothing
        items = InvokeMethod(imp, Cast(Of ListboxItem)(cbType.SelectedItem).Value, paramValues)
        Return items
    End Function

    Private Sub ImpReportsProgress(ByVal sender As Object, ByVal e As Importateur.ProgressEventArgs)
        If e.Status <> "" Then Me.lbStatus.Text = e.Status
        If e.Maximum >= 0 Then Me.pgBar.Maximum = e.Maximum
        Me.pgBar.Value = e.Value
        Application.DoEvents()
    End Sub

    Private Sub btParcourir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btParcourir.Click
        With OpenFileDialog1
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            .Filter = "Fichiers texte (*.txt;*.xls;*.csv)|*.txt;*.xls;*.csv|Tous les fichiers|*.*"
            .FilterIndex = 0
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                txtFic.Text = .FileName
            End If
        End With
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbStatus.Text = "Prêt..."
        Me.pgBar.Visible = False
        With SqlConnectionConfig1.ConnectionStringBuilder
            .Server = My.Settings.serveur
            .Database = My.Settings.base
            .Login = My.Settings.login
            .Password = My.Settings.pwd
        End With

        TrouverMethodesImport()
    End Sub

    Private Sub TrouverMethodesImport()
        Me.cbType.Items.Clear()

        Dim methods() As Reflection.MethodInfo = Array.FindAll(GetType(Importateur).GetMethods, AddressOf ImportEntrepriseAttribute.HasAttribute)
        For Each mi As Reflection.MemberInfo In methods
            Me.cbType.Items.Add(New ListboxItem(ImportEntrepriseAttribute.GetAttribute(mi).Description, mi))
        Next

        methods = Array.FindAll(GetType(Importateur).GetMethods, AddressOf ImportProduitAttribute.HasAttribute)
        For Each mi As Reflection.MemberInfo In methods
            Me.cbType.Items.Add(New ListboxItem(ImportProduitAttribute.GetAttribute(mi).Description, mi))
        Next

        Me.cbType.SelectedIndex = 0
    End Sub

    Private Sub BtPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPreview.Click
        If Not IO.File.Exists(txtFic.Text) Then
            MsgBox("Fichier introuvable")
            Exit Sub
        End If
        PreviewText.PreviewFile(txtFic.Text.Trim)
    End Sub

    Private Sub BtTestData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtTestData.Click
        If Not IO.File.Exists(txtFic.Text) Then
            MsgBox("Fichier introuvable")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Me.pgBar.Visible = True

        Dim imp As New Importateur
        AddHandler imp.ReportProgress, AddressOf ImpReportsProgress
        Dim items As List(Of IDataItem) = ChargerFichier(imp)
        If items IsNot Nothing Then PreviewTable.PreviewItems(items)

        Me.lbStatus.Text = ""
        Me.pgBar.Visible = False
        Me.Cursor = Cursors.Default
    End Sub
End Class

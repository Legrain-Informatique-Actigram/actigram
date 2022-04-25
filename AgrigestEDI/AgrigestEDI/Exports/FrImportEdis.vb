Imports ICSharpCode.SharpZipLib.Zip

Public Class FrImportEdis

    Public Files As List(Of String)

    Private Const SIMPLE_HEIGHT As Integer = 117
    Private Const FULL_HEIGHT As Integer = 330
    Private loadingImage As Image

#Region "Méthodes partagées"
    Public Shared Function GetEdiDirectory(Optional ByVal pattern As String = Nothing) As String
        Dim res As String = IO.Path.Combine(My.Application.GetAppDataPath, "EDI")
        If pattern IsNot Nothing Then
            If My.Settings.Exploitation Is Nothing Then Return ""
            res = IO.Path.Combine(res, String.Format(pattern, GetTrimmedCodeExpl))
        End If
        Return res
    End Function

    Public Shared Function GetEdiFileNamePattern(Optional ByVal pattern As String = Nothing) As String
        If My.Settings.Exploitation Is Nothing Then Return ""
        If pattern Is Nothing Then pattern = "{0}-*.ecr"
        Return String.Format(pattern, GetTrimmedCodeExpl)
    End Function

    Public Shared Function GetTrimmedCodeExpl() As String
        If My.Settings.Exploitation Is Nothing Then Return ""
        Return My.Settings.Exploitation.CodeExpl.TrimStart(New Char() {"C"c, "0"c})
    End Function

    Private Shared Function GetCle() As String
        'Dim a As UInteger = &H5CAE980E
        'Dim b As UShort = &HF009
        'Dim c As UShort = &H43EC
        'Dim d() As Byte = {&H88, &H84, &H58, &H1D, &H38, &HFC, &H0, &HD}
        Dim assy As System.Reflection.Assembly = System.Reflection.[Assembly].GetExecutingAssembly
        Dim Attributes As Object() = assy.GetCustomAttributes(GetType(System.Runtime.InteropServices.GuidAttribute), False)
        If Attributes.Length = 0 Then
            Return ""
        Else
            Dim g As New Guid(DirectCast(Attributes(0), System.Runtime.InteropServices.GuidAttribute).Value)
            Dim b() As Byte = g.ToByteArray
            Return String.Format("{0:X2}{1:X2}{2:X2}{3:X2}", b(7), b(6), b(5), b(4))
        End If
    End Function

    Private Shared Function GetPassword(ByVal codeDossier As String) As String
        Return String.Format("{0}-{1}", codeDossier, GetCle)
    End Function

    Public Shared Function GetZipPassword() As String
        If My.Settings.Exploitation Is Nothing Then Return ""
        Return GetPassword(GetTrimmedCodeExpl)
    End Function

    Public Shared Sub VerifEdis(Optional ByVal msgIfNone As Boolean = False)
        If My.Settings.Exploitation Is Nothing Then Exit Sub
        'Trouver les fichiers présents
        Dim allfiles As New List(Of String)
        Dim params As FtpCogedis.ParamsFtp = FtpCogedis.ParamsFtp.Load
        If params Is Nothing Then
            MsgBox("Vérification des EDI impossible : le paramétrage est introuvable.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        For Each p As FtpCogedis.EdiFileDescription In params.FileDescriptions
            'MsgBox("recherche pour " & p.LocalDirPattern)
            Dim repEdi As String = GetEdiDirectory(p.LocalDirPattern)
            'MsgBox("repEDI=" & repEdi)
            If Not IO.Directory.Exists(repEdi) Then Continue For
            'MsgBox("recherche des fichiers " & GetEdiFileNamePattern(p.FilenamePattern))
            allfiles.AddRange(My.Computer.FileSystem.GetFiles(repEdi, FileIO.SearchOption.SearchAllSubDirectories, GetEdiFileNamePattern(p.FilenamePattern)))
            'MsgBox(allfiles.Count & " fichiers trouvés")
        Next
        If allfiles.Count = 0 Then
            If msgIfNone Then MsgBox("Aucun EDI n'est disponible", MsgBoxStyle.Information)
            Exit Sub
        End If
        Using fr As New FrImportEdis
            fr.Files = allfiles
            fr.ShowDialog()
        End Using
    End Sub
#End Region

#Region "Form Events"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadingImage = Me.pbLoading.Image
        Me.pgBar.Visible = False
        SetChildFormIcon(Me)
        Me.Height = SIMPLE_HEIGHT
        Me.BtImport.Visible = False
    End Sub

    Private Sub Me_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.Files Is Nothing Then Exit Sub
        If Me.Files.Count = 0 Then
            lbStatus.Text = "Aucun EDI n'est disponible."
            pbLoading.Image = SystemIcons.Information.ToBitmap
            Exit Sub
        End If
        pbLoading.Image = SystemIcons.Information.ToBitmap
        pbLoading.Visible = True
        lbStatus.Text = "Les EDI suivants sont disponibles :"
        FillList()
        Me.Height = FULL_HEIGHT
        Me.BtImport.Visible = True
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub FillList()
        With lvFiles
            .Items.Clear()
            .BeginUpdate()
            For Each f As String In Me.Files
                .Items.Add(CreateLvi(f, True))
            Next
            .EndUpdate()
        End With
    End Sub

    Private Function CreateLvi(ByVal f As String, Optional ByVal checked As Boolean = False) As ListViewItem
        Dim res As New ListViewItem
        With res
            Dim fi As New IO.FileInfo(f)
            .Text = fi.Name
            .Checked = checked
            .SubItems.Add(FormatFileSize(fi.Length))
            .SubItems.Add(fi.LastWriteTime.ToString("d"))
            .Tag = f
        End With
        Return res
    End Function

    Private Sub SetError(ByVal ex As Exception)
        Me.pbLoading.Image = SystemIcons.Exclamation.ToBitmap
        Me.lbStatus.Text = "Erreur : " & ex.Message
        LogException(ex)
    End Sub

    Private Sub SetError(ByVal msg As String)
        Me.pbLoading.Image = SystemIcons.Exclamation.ToBitmap
        Me.lbStatus.Text = msg
    End Sub

    Private Function ImporterEcr(ByVal fichier As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing) As Boolean
        Using fr As New FrImportationIsagri
            Try
                fr.Importer(fichier, worker)
                If fr.DialogResult <> Windows.Forms.DialogResult.Cancel Then
                    Try
                        IO.File.Move(fichier, String.Format("{0}.{1:yyMMdd}.{1:HHmmss}.imported", fichier, Now))
                    Catch
                    End Try
                    Return True
                End If
            Catch ex As Exception
                LogException(ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End Using
        Try
            IO.File.Move(fichier, String.Format("{0}.{1:yyMMdd}.{1:HHmmss}.failed", fichier, Now))
        Catch
        End Try
        Return False
    End Function

    Private Function ImporterRib(ByVal fichier As String, Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing) As Boolean
        Using fr As New FrImportETEBAC
            Try
                fr.Fichier = fichier
                If fr.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                    Try
                        IO.File.Move(fichier, String.Format("{0}.{1:yyMMdd}.{1:HHmmss}.imported", fichier, Now))
                    Catch
                    End Try
                    Return True
                End If
            Catch ex As Exception
                LogException(ex)
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try
        End Using
        Try
            IO.File.Move(fichier, String.Format("{0}.{1:yyMMdd}.{1:HHmmss}.failed", fichier, Now))
        Catch
        End Try
        Return False
    End Function

    Private Function ExtractZippedFiles(ByVal files As List(Of String), Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing) As List(Of String)
        Dim res As New List(Of String)
        For Each f As String In files
            If IO.Path.GetExtension(f) = ".zip" Then
                Try
                    Dim tempDir As String = String.Format("{0}AgrigestDezip{1:yyMMddHHmmss}", IO.Path.GetTempPath, Now)
                    IO.Directory.CreateDirectory(tempDir)
                    Dim fz As New ICSharpCode.SharpZipLib.Zip.FastZip
                    fz.Password = GetZipPassword()
                    fz.ExtractZip(f, tempDir, "")
                    Dim destDir As String = IO.Path.GetDirectoryName(f)
                    For Each zf As String In My.Computer.FileSystem.GetFiles(tempDir, FileIO.SearchOption.SearchAllSubDirectories, "*")
                        Dim destFile As String = IO.Path.Combine(destDir, IO.Path.GetFileName(zf))
                        IO.File.Move(zf, destFile)
                        res.Add(destFile)
                    Next
                    IO.Directory.Delete(tempDir, True)
                    Try
                        IO.File.Move(f, String.Format("{0}.{1:yyMMdd}.{1:HHmmss}.extracted", f, Now))
                    Catch
                    End Try
                Catch ex As Exception
                    Try
                        IO.File.Move(f, String.Format("{0}.{1:yyMMdd}.{1:HHmmss}.distracted", f, Now))
                    Catch
                    End Try
                End Try
            End If
        Next
        Return res
    End Function
#End Region

#Region "Boutons"
    Private Sub BtImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImport.Click
        Dim selectedFiles As New List(Of String)
        For Each lvi As ListViewItem In Me.lvFiles.CheckedItems
            If lvi.Tag IsNot Nothing AndAlso TypeOf lvi.Tag Is String Then
                selectedFiles.Add(CStr(lvi.Tag))
            End If
        Next
        If selectedFiles.Count = 0 Then Exit Sub

        Dim msg As String = "Voulez-vous importer les EDI séléctionnés ?"
        If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'Mode importation
        Me.pbLoading.Visible = True
        Me.pbLoading.Image = Me.loadingImage
        Me.pgBar.Visible = True
        Me.lbStatus.Text = "Importation des EDI..."
        Me.Height = SIMPLE_HEIGHT
        Me.BtImport.Visible = False
        Application.DoEvents()

        'Balancer l'import en Async
        'Dim worker As New System.ComponentModel.BackgroundWorker()
        'With worker
        '    .WorkerReportsProgress = True
        '    .WorkerSupportsCancellation = True
        '    AddHandler .ProgressChanged, AddressOf ImportProgressed
        '    AddHandler .RunWorkerCompleted, AddressOf ImportCompleted
        '    AddHandler .DoWork, AddressOf RunImport
        '    .RunWorkerAsync(selectedFiles)
        'End With


        'Balancer l'import sur le thread en cours
        Try
            Dim cpt As Integer = RunImport(selectedFiles)
            If cpt = 0 Then
                SetError("Aucun EDI importé.")
                Exit Sub
            End If

            MsgBox(String.Format("{0} EDI ont été importés.", cpt), MsgBoxStyle.Information)
            'Sortir
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            SetError(ex)
        End Try
    End Sub
#End Region

#Region "Worker Events"
    Private Sub RunImport(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        If e.Argument Is Nothing OrElse Not TypeOf e.Argument Is List(Of String) Then
            e.Cancel = True
            e.Result = 0
            Exit Sub
        End If
        e.Result = RunImport(CType(e.Argument, List(Of String)), CType(sender, System.ComponentModel.BackgroundWorker))
    End Sub

    Private Function RunImport(ByVal selectedFiles As List(Of String), Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing) As Integer
        selectedFiles.AddRange(ExtractZippedFiles(selectedFiles, worker))
        Dim cpt As Integer
        For Each f As String In selectedFiles
            Select Case IO.Path.GetExtension(f).ToLower
                Case ".ecr", ".isa"
                    If ImporterEcr(f, worker) Then
                        cpt += 1
                    End If
                Case ".rib", ".afb"
                    If ImporterRib(f, worker) Then
                        cpt += 1
                    End If
            End Select
        Next
        Return cpt
    End Function

    Private Sub ImportCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Me.pgBar.Visible = False
        If e.Cancelled Then
            SetError("Import annulé.")
        ElseIf e.Error IsNot Nothing Then
            SetError(e.Error)
        Else
            Dim cpt As Integer = CInt(e.Result)
            If cpt = 0 Then
                SetError("Aucun EDI importé.")
                Exit Sub
            End If

            MsgBox(String.Format("{0} EDI ont été importés.", cpt), MsgBoxStyle.Information)
            'Sortir
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub ImportProgressed(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        Me.pgBar.Value = e.ProgressPercentage
        If e.UserState IsNot Nothing AndAlso TypeOf e.UserState Is String Then
            Me.lbStatus.Text = CStr(e.UserState)
        End If
    End Sub
#End Region

End Class
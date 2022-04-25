Public Class FrParametres

    Private tx As TextBox

    'TODO Voir le déclenchement de la disquette

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
        Me.MySettingsBindingSource.DataSource = GetType(My.MySettings)
    End Sub
#End Region

#Region "Page"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        lbExempleLotBR.Text = ""
        lbExempleLotFab.Text = ""
        ChargerDonnees()
        AddHandler My.Settings.PropertyChanged, AddressOf MySettings_PropertyChanged
        Addhandlers(ctxAideFormat.Items, AddressOf mnuFormatClicked)
    End Sub
#End Region

#Region "Données"
    Private modif As Boolean = False

    Private Sub ChargerDonnees()
        MySettingsBindingSource.DataSource = My.Settings
        Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString = My.Settings.ConnString
        modif = False
        MajBoutons()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        If modif Then
            SqlProxy.SetDefaultConnection(Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString)
            My.Settings.Save()
            modif = False
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        If modif Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                    My.Settings.Reload()
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function
#End Region

#Region "Toolbar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub
#End Region

#Region " Gestion PDF "
    Private Sub RepPDFTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RepPDFTextBox.Validating
        Dim rep As String = RepPDFTextBox.Text
        If Not IO.Path.IsPathRooted(rep) Then
            rep = IO.Path.Combine(My.Application.Info.DirectoryPath, rep)
        End If
        If Not IO.Directory.Exists(rep) Then
            ErrorProvider.SetError(RepPDFTextBox, "Le répertoire est introuvable.")
            e.Cancel = True
        Else
            ErrorProvider.SetError(RepPDFTextBox, "")
        End If
    End Sub

    Private Sub btBrowsePdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowsePdf.Click
        Using folderDialog As New FolderBrowserDialog
            With folderDialog
                .SelectedPath = My.Settings.AbsoluteRepPdf
                .Description = "Indiquez le répertoire contenant les fichiers PDF."
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    My.Settings.AbsoluteRepPdf = .SelectedPath
                    Me.MySettingsBindingSource.ResetCurrentItem()
                End If
            End With
        End Using
    End Sub

    Private Sub lnkAddPdf_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAddPdf.LinkClicked
        Dim f() As String = Nothing
        Using fileDialog As New OpenFileDialog
            With fileDialog
                .DefaultExt = "pdf"
                .Multiselect = True
                .Filter = "Document PDF (*.pdf)|*.pdf"
                .Title = "Sélectionnez le document à copier dans l'application."
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    f = .FileNames
                    Me.MySettingsBindingSource.ResetCurrentItem()
                End If
            End With
        End Using
        If f IsNot Nothing Then
            Try
                Cursor.Current = Cursors.WaitCursor
                Application.DoEvents()
                Dim i As Integer = 0
                For Each fi As String In f
                    Dim dest As String = IO.Path.Combine(My.Settings.AbsoluteRepPdf, IO.Path.GetFileName(fi))
                    If IO.File.Exists(dest) Then
                        Select Case MsgBox(String.Format("Le fichier '{0}' existe déjà, remplacer le fichier existant ?", IO.Path.GetFileName(dest)), MsgBoxStyle.YesNoCancel)
                            Case MsgBoxResult.Cancel
                                Throw New UserCancelledException("Copie annulée.")
                            Case MsgBoxResult.No
                                Continue For
                        End Select
                    End If
                    IO.File.Copy(fi, dest, True)
                    i += 1
                Next
                MsgBox(String.Format("Ajout terminé : {0} fichiers copiés.", i), MsgBoxStyle.Information)
            Catch ex As Exception
                Throw New ApplicationException("La copie à echoué", ex)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End If
    End Sub
#End Region

    Private Sub MySettings_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
        modif = True
        MajBoutons()
    End Sub

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SqlConnectionConfig.Validated
        modif = True
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        ProduitBindingNavigatorSaveItem.Enabled = modif
    End Sub

    Private Sub lnkAideFormatLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAideFormatLotBR.Click, lnkAideFormatLotFab.Click
        'Lancer l'aide à saisie des formats
        If sender Is lnkAideFormatLotBR Then
            tx = TxFormatLotBR
        ElseIf sender Is lnkAideFormatLotFab Then
            tx = TxFormatLotFab
        End If
        mnuNom.Visible = sender Is lnkAideFormatLotBR
        ctxAideFormat.Show(CType(sender, Control), CType(sender, Control).Width \ 2, CType(sender, Control).Height \ 2)
    End Sub

    Private Sub Addhandlers(ByVal items As ToolStripItemCollection, ByVal e As EventHandler)
        For Each i As ToolStripItem In items
            AddHandler i.Click, e
            If TypeOf i Is ToolStripMenuItem Then
                Addhandlers(Cast(Of ToolStripMenuItem)(i).DropDownItems, e)
            End If
        Next
    End Sub

    Private Sub mnuFormatClicked(ByVal sender As Object, ByVal e As EventArgs)
        If tx Is Nothing Then Exit Sub
        If Convert.ToString(CType(sender, ToolStripMenuItem).Tag).Length = 0 Then Exit Sub
        Dim selStart As Integer = tx.SelectionStart
        Dim insert As String = Convert.ToString(CType(sender, ToolStripMenuItem).Tag)
        tx.Text = tx.Text.Insert(selStart, insert)
        tx.SelectionStart = selStart + insert.Length
        tx.SelectionLength = 0
        tx = Nothing
    End Sub

    Private Sub TxFormatLotBR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxFormatLotBR.TextChanged
        Try
            lbExempleLotBR.ForeColor = SystemColors.WindowText
            lbExempleLotBR.Text = "Exemple : " & Lots.GetNLotBR(TxFormatLotBR.Text, 1, Now, "Fournisseur")
        Catch ex As Exception
            lbExempleLotBR.ForeColor = Color.Red
            lbExempleLotBR.Text = ex.Message
        End Try
    End Sub

    Private Sub TxFormatLotFab_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxFormatLotFab.TextChanged
        Try
            lbExempleLotFab.ForeColor = SystemColors.WindowText
            lbExempleLotFab.Text = "Exemple : " & Lots.GetNLotFab(TxFormatLotFab.Text, 1, Now, "Description")
        Catch ex As Exception
            lbExempleLotFab.ForeColor = Color.Red
            lbExempleLotFab.Text = ex.Message
        End Try
    End Sub
End Class

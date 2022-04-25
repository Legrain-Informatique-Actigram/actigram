Imports System.Windows.Forms
Public Class FrRequetePerso

#Region "Props"
    Private exclamationIcon As System.Drawing.Image = System.Drawing.SystemIcons.Exclamation.ToBitmap.GetThumbnailImage(16, 16, Nothing, System.IntPtr.Zero)
    Private infoIcon As System.Drawing.Image = System.Drawing.SystemIcons.Information.ToBitmap.GetThumbnailImage(16, 16, Nothing, System.IntPtr.Zero)

    Private _requete As Requete
    Public Property Requete() As Requete
        Get
            Return _requete
        End Get
        Set(ByVal value As Requete)
            _requete = value
        End Set
    End Property


    Private _conn As SqlClient.SqlConnection
    Public Property Connection() As SqlClient.SqlConnection
        Get
            Return _conn
        End Get
        Set(ByVal value As SqlClient.SqlConnection)
            _conn = value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            If Me.Connection Is Nothing Then
                Return ""
            Else
                Return Me.Connection.ConnectionString
            End If
        End Get
        Set(ByVal value As String)
            If Me.Connection IsNot Nothing AndAlso Me.Connection.State <> ConnectionState.Closed Then
                Me.Connection.Close()
            End If
            If Me.Connection Is Nothing Then
                Me.Connection = New SqlClient.SqlConnection
            End If
            Me.Connection.ConnectionString = value
            Me.lbStatusQuery.Text = "Connection établie"
        End Set
    End Property
#End Region

#Region "Ctor"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal requete As Requete)
        Me.New()
        Me.Requete = requete
    End Sub

    Public Sub New(ByVal fichier As String)
        Me.New(Requete.Load(fichier))
    End Sub
#End Region

    Private Sub FrRequetePerso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lbTitre.Text = ""
        Me.lbStatusQuery.Text = ""
        If Me.ConnectionString.Length = 0 Then
            Me.lbStatusQuery.Image = exclamationIcon
            Me.lbStatusQuery.Text = "Connection non établie"
        End If
        ChargerRequete()
    End Sub

    Private Sub FrRequetePerso_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            TbExecute_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub

    Private Sub UpdateWindowText()
        If Me.lbTitre.Text.Length = 0 Then
            Me.Text = "Requête"
        Else
            Me.Text = "Requête - " & lbTitre.Text
        End If
    End Sub

    Private Sub MajBoutons()
        Me.TbImprimer.Enabled = Not (Me.dgResult.DataSource Is Nothing OrElse Me.dgResult.RowCount = 0)
        Me.TbExporter.Enabled = Not (Me.dgResult.DataSource Is Nothing OrElse Me.dgResult.RowCount = 0)        
    End Sub

#Region "Toolbar"
    Private Sub UcOptions_ParametersValidated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UcOptions.ParametersValidated
        TbExecute_Click(Nothing, Nothing)
    End Sub

    Private Sub UcOptions_CloseClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UcOptions.CloseClicked
        ParamètresVisiblesToolStripMenuItem.Checked = False
    End Sub

    Private Sub ParamètresVisiblesToolStripMenuItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParamètresVisiblesToolStripMenuItem.CheckedChanged
        Me.split.Panel1Collapsed = Not Me.ParamètresVisiblesToolStripMenuItem.Checked
    End Sub

    Private Sub Fractionnement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles FractionnementHorizontalToolStripMenuItem.Click, FractionnementVerticalToolStripMenuItem.Click
        If sender Is FractionnementHorizontalToolStripMenuItem Then
            Me.split.Orientation = Orientation.Horizontal
            Me.split.SplitterDistance = Me.UcOptions.MinimumSize.Height
        Else
            Me.split.Orientation = Orientation.Vertical
            Me.split.SplitterDistance = Me.UcOptions.MinimumSize.Width
        End If
        FractionnementHorizontalToolStripMenuItem.Checked = (sender Is FractionnementHorizontalToolStripMenuItem)
        FractionnementVerticalToolStripMenuItem.Checked = (sender Is FractionnementVerticalToolStripMenuItem)
    End Sub

    Private Sub TbExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TbExporter.ButtonClick, ExporterLesDonnéesBrutesToolStripMenuItem.Click
        Exporter(".csv", sender Is ExporterLesDonnéesBrutesToolStripMenuItem)
    End Sub

    Private Sub TbImprimer_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles TbImprimer.ButtonClick, ImprimerLesDonnéesBrutesToolStripMenuItem.Click
        Exporter(".htm", sender Is ImprimerLesDonnéesBrutesToolStripMenuItem)
    End Sub
#End Region

    Private Sub ChargerRequete()
        If Me.Requete Is Nothing Then Exit Sub
        Me.lbTitre.Text = Me.Requete.Titre
        Me.UcOptions.Connection = Me.Connection
        Me.UcOptions.Parametres = Me.Requete.Parametres
        If Me.split.Orientation = Orientation.Horizontal Then
            Me.split.SplitterDistance = Me.UcOptions.MinimumSize.Height
        Else
            Me.split.SplitterDistance = Me.UcOptions.MinimumSize.Width
        End If
        If Me.Requete.Parametres.Count = 0 Then
            Me.ParamètresVisiblesToolStripMenuItem.Checked = False
        End If

        If Me.Requete.Colonnes.Count = 0 Then
            Me.dgResult.AutoGenerateColumns = True
        Else
            Me.dgResult.AutoGenerateColumns = False
            For Each c As Colonne In Me.Requete.Colonnes
                Dim col As New DataGridViewTextBoxColumn
                col.HeaderText = c.Entete
                col.DataPropertyName = c.Field
                If c.Format.Length > 0 Then
                    col.DefaultCellStyle.Format = c.Format
                End If
                If c.Align.Length > 0 Then
                    Select Case c.Align.ToLower
                        Case "left" : col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        Case "right" : col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        Case "center" : col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End Select
                End If
                Me.dgResult.Columns.Add(col)
            Next
        End If
        Me.lbStatusQuery.Image = infoIcon
        Me.lbStatusQuery.Text = "Requête prête"
        MajBoutons()
        UpdateWindowText()
    End Sub

    Private Sub TbExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbExecute.Click
        If Me.ConnectionString.Length = 0 Then Exit Sub
        Dim paramValues As Dictionary(Of String, Object) = UcOptions.GetParamValues
        worker.RunWorkerAsync(paramValues)
        Application.DoEvents()
        While worker.IsBusy
            If sw IsNot Nothing Then
                Me.lbStatusQuery.Text = String.Format("Execution en cours : {0:0}s", sw.Elapsed.TotalSeconds)
            End If
            Application.DoEvents()
        End While
    End Sub

    Dim sw As Stopwatch

    Private Sub worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles worker.DoWork
        Me.lbStatusQuery.Image = infoIcon
        Me.lbStatusQuery.Text = "Execution en cours"
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        sw = Stopwatch.StartNew
        Dim paramValues As Dictionary(Of String, Object) = CType(e.Argument, Dictionary(Of String, Object))
        e.Result = Me.Requete.ExecuteDatatable(Me.Connection, paramValues)
    End Sub

    Private Sub worker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles worker.RunWorkerCompleted
        If e.Cancelled Then
            Me.lbStatusQuery.Image = exclamationIcon
            Me.lbStatusQuery.Text = "Execution annulée"
        ElseIf e.Error IsNot Nothing Then
            MsgBox(e.Error.Message, MsgBoxStyle.Exclamation)
            Me.lbStatusQuery.Image = exclamationIcon
            Me.lbStatusQuery.Text = "Erreur : " & e.Error.Message
        Else
            Dim dt As DataTable = CType(e.Result, DataTable)
            sw.Stop()
            Me.dgResult.DataSource = dt
            Me.lbStatusQuery.Image = infoIcon
            Me.lbStatusQuery.Text = String.Format("{0} ligne(s) en {1} ms", dt.Rows.Count, sw.ElapsedMilliseconds)
            sw = Nothing
        End If
        Cursor.Current = Cursors.Default
        MajBoutons()
    End Sub


#Region "Exportation"
    Private Sub Exporter(ByVal ext As String, Optional ByVal exportRawData As Boolean = False)
        'TODO Implémenter d'autres exports : XMl...
        Dim fichier As String
        Using dlg As New SaveFileDialog
            With dlg
                .Filter = "(*" & ext & ")|*" & ext
                .FilterIndex = 0
                If Me.Requete.Titre.Length > 0 Then
                    .FileName = Me.Requete.Titre & ext
                Else
                    .FileName = "export" & ext
                End If
                .Title = "Exporter les données"
                If .ShowDialog <> DialogResult.OK Then Exit Sub
                fichier = .FileName
            End With
        End Using
        Cursor.Current = Cursors.WaitCursor
        Select Case ext
            Case ".csv"
                If exportRawData Then
                    ExporterCSV(Me.Requete, CType(Me.dgResult.DataSource, DataTable), fichier, Me.UcOptions.GetParamPrintValues)
                Else
                    ExporterCSV(Me.Requete, dgResult, fichier, Me.UcOptions.GetParamPrintValues)
                End If
            Case ".htm"
                If exportRawData Then
                    ExporterHTML(Me.Requete, CType(Me.dgResult.DataSource, DataTable), fichier, Me.UcOptions.GetParamPrintValues)
                Else
                    ExporterHTML(Me.Requete, dgResult, fichier, Me.UcOptions.GetParamPrintValues)
                End If
        End Select
        Cursor.Current = Cursors.Default
        Process.Start(fichier)
    End Sub

#End Region

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub
End Class
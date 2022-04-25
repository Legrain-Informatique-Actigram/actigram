Public Class FrIntervention

    Private sw As Stopwatch
    Private bmpCollapsed As Bitmap
    Private bmpExpanded As Bitmap

    'Public Overloads Shared Sub Show(ByVal nEntreprise As Integer, Optional ByVal owner As Form = Nothing)
    '    Using fr As New FrIntervention
    '        fr.nEntreprise = nEntreprise
    '        fr.Show(owner)
    '    End Using
    'End Sub

#Region " Props "
    Dim Modif As Boolean

    Private ReadOnly Property CurrentEvRow() As DsAgrifact.EvenementRow
        Get
            If Me.EvenementBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return Cast(Of DsAgrifact.EvenementRow)(Cast(Of DataRowView)(Me.EvenementBindingSource.Current).Row)
            End If
        End Get
    End Property


    Private _nEv As Integer=-1
    Public Property nEvenement() As Integer
        Get
            Return _nEv
        End Get
        Set(ByVal value As Integer)
            _nEv = value
        End Set
    End Property


    Private _nEnt As Integer=-1
    Public Property nEntreprise() As Integer
        Get
            Return _nEnt
        End Get
        Set(ByVal value As Integer)
            _nEnt = value
        End Set
    End Property


    Private _nAuteur As Integer=-1
    Public Property nAuteur() As Integer
        Get
            Return _nAuteur
        End Get
        Set(ByVal value As Integer)
            _nAuteur = value
        End Set
    End Property
#End Region

#Region " Données "

    Private Sub ChargerDonnees()
        'If nEntreprise < 0 Then Exit Sub
        ChargerChoix()
        Me.PersonneTableAdapter.FillUtilisateurs(Me.DsAgrifact.Personne)
        Me.EntrepriseTableAdapter.Fill(Me.DsAgrifact.Entreprise)
        If Me.nEvenement >= 0 Then
            Me.EvenementTableAdapter.FillByNEvenement(Me.DsAgrifact.Evenement, Me.nEvenement)
            BtPauseResume.Enabled = False
            BtStop.Enabled = False
            TxElapsed.Text = Me.CurrentEvRow.Duree.ToString
        Else
            Me.EvenementBindingSource.AddNew()
            With Me.CurrentEvRow
                If Me.nEntreprise >= 0 Then
                    .nClient = Me.nEntreprise
                End If
                If Me.nAuteur >= 0 Then
                    .nPersonneAuteur = Me.nAuteur
                ElseIf My.Settings.nPersonne >= 0 Then
                    .nPersonneAuteur = My.Settings.nPersonne
                End If
                .DateEv = Today
                .DateCreation = Now
                .Type = "Téléphoner"
                .TypeEv = "True"
                .Priorite = "Normal"
                .UniteDuree = "Minutes"
            End With
            Me.EvenementBindingSource.ResetCurrentItem()
            sw = Stopwatch.StartNew
            Me.TxElapsed.Enabled = False
            BtPauseResume.Image = My.Resources.PauseHS
            Me.Timer.Start()
        End If
    End Sub

    Private Sub ChargerChoix()
        Me.DsAgrifact.ListeChoix.Clear()
        Me.ListeChoixTableAdapter.FillByNomChoix(Me.DsAgrifact.ListeChoix, DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeProduits)
        Me.ListeChoixTableAdapter.FillByNomChoix(Me.DsAgrifact.ListeChoix, DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeTypeEv)
    End Sub

    Private Sub Enregistrer()
        If Me.Validate() Then
            If Not sw Is Nothing Then
                BtStop_Click(Nothing, Nothing)
            End If
            With Me.CurrentEvRow
                Dim Duree As Integer = CInt(Me.TxElapsed.Text)
                If .IsDureeNull OrElse .Duree <> Duree Then .Duree = Duree
                If .IsRealiseNull OrElse Not .Realise Then .Realise = True
                If Not .IsnPersonneAuteurNull Then
                    My.Settings.nPersonne = CInt(.nPersonneAuteur)
                End If
                If .nEvenement = 0 Then
                    .nEvenement = Me.DsAgrifact.Evenement.GetNewId(Me.EvenementTableAdapter)
                End If
            End With
            Me.EvenementBindingSource.EndEdit()
            Dim passed As Boolean = False
            While Not passed
                Try
                    Dim cpt As Integer = Me.EvenementTableAdapter.Update(Me.DsAgrifact.Evenement)
                    Me.Modif = cpt > 0
                    passed = True
                Catch ex As Exception
                    Select Case MsgBox("une erreur est survenue : " & ex.Message, MsgBoxStyle.RetryCancel)
                        Case MsgBoxResult.Retry
                            'Pour forcer la connexion à se recréer.
                            Me.EvenementTableAdapter.Connection = Nothing
                        Case MsgBoxResult.Cancel
                            Throw New Exception(ex.Message, ex)
                    End Select
                End Try
            End While
        End If
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        If Me.Validate() Then
            Me.EvenementBindingSource.EndEdit()
            If Me.DsAgrifact.HasChanges Then
                Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        Enregistrer()
                    Case MsgBoxResult.No
                    Case MsgBoxResult.Cancel
                        Return False
                End Select
            End If
            Return True
        Else : Return False
        End If
    End Function
#End Region

    Private Sub FrIntervention_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If Modif Then Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListeChoixTableAdapter.ClearBeforeFill = False
        CType(Me.BtFicheDest.Image, Bitmap).MakeTransparent(Color.Magenta)
        CType(Me.BtFicheInter.Image, Bitmap).MakeTransparent(Color.Magenta)
        Me.bmpCollapsed = My.Resources.Collapsed
        Me.bmpCollapsed.MakeTransparent(Color.Magenta)
        Me.bmpExpanded = My.Resources.Expanded
        Me.bmpExpanded.MakeTransparent(Color.Magenta)
        SetChildFormIcon(Me)

        ChargerDonnees()

        'Si c'est une nouvelle intervention
        If Me.nEvenement < 0 Then
            ExpandInfo(False)
            'Se placer en bas du bureau courant
            Dim bounds As Rectangle = Screen.GetWorkingArea(Me.Location)
            Me.Top = bounds.Bottom - Me.Height
            Me.Left = bounds.Right - Me.Width
        Else
            ExpandInfo(True)
        End If

    End Sub

    Private Sub ExpandInfo(ByVal expanded As Boolean)
        If expanded Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
            Me.Opacity = 1
            With Me.lnkShow
                .Image = Me.bmpExpanded
                .Text = "Masquer les infos"
            End With
            Me.Size = New Size(419, 317)
            Me.TabControl1.Visible = True
            Dim bounds As Rectangle = Screen.GetWorkingArea(Me.Location)
            If Me.Bottom > bounds.Bottom Then
                Me.Top -= (Me.Bottom - bounds.Bottom)
            End If
            If Me.Right > bounds.Right Then
                Me.Left -= (Me.Right - bounds.Right)
            End If

        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            With Me.lnkShow
                .Image = Me.bmpCollapsed
                .Text = "Afficher plus d'infos"
            End With
            Me.Size = New Size(189, 97)
            Me.TabControl1.Visible = False
        End If
        lnkShow.Tag = expanded
    End Sub

    Private Sub EntrepriseBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Enregistrer()
    End Sub


    Private Sub TxElapsed_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxElapsed.Validated
        If sw IsNot Nothing Then Exit Sub
        If Me.CurrentEvRow Is Nothing Then Exit Sub
        If Not Me.CurrentEvRow.IsDureeNull AndAlso Me.CurrentEvRow.Duree <> CInt(TxElapsed.Text) Then
            Me.CurrentEvRow.Duree = CInt(TxElapsed.Text)
        End If
        Me.EvenementBindingSource.ResetCurrentItem()
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        If sw Is Nothing Then
            Timer.Stop()
            Exit Sub
        End If
        Me.TxElapsed.Text = FormatTimeSpan(sw.Elapsed)
    End Sub

    Public Function FormatTimeSpan(ByVal t As TimeSpan) As String
        Return String.Format("{0:#0}:{1:00}:{2:00}", Math.Floor(t.TotalHours), t.Minutes, t.Seconds)
    End Function

    Private Sub BtPauseResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPauseResume.Click
        If sw Is Nothing Then
            sw = Stopwatch.StartNew
        ElseIf sw.IsRunning Then
            sw.Stop()
        Else
            sw.Start()
        End If
        If sw.IsRunning Then
            BtPauseResume.Image = My.Resources.PauseHS
        Else
            BtPauseResume.Image = My.Resources.PlayHS
        End If
        If Not Timer.Enabled Then Timer.Start()
    End Sub

    Private Sub BtStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtStop.Click
        If sw Is Nothing Then Exit Sub
        sw.Stop()
        Timer.Stop()
        Me.TxElapsed.Enabled = True
        Me.TxElapsed.Text = sw.Elapsed.TotalMinutes.ToString("N0")
        sw = Nothing
        BtPauseResume.Enabled = False
        BtStop.Enabled = False
        ExpandInfo(True)
    End Sub

    Private Sub lnkShow_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkShow.LinkClicked
        ExpandInfo(Not CBool(lnkShow.Tag))
    End Sub

    Private Sub NPersonneAuteurComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NPersonneAuteurComboBox.SelectedIndexChanged
        BtFicheInter.Enabled = (NPersonneAuteurComboBox.SelectedIndex >= 0)
    End Sub

    Private Sub NPersonneDestinataireComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NPersonneDestinataireComboBox.SelectedIndexChanged
        BtFicheDest.Enabled = (NPersonneDestinataireComboBox.SelectedIndex >= 0)
    End Sub

    Private Sub BtFicheInter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFicheInter.Click
        If NPersonneAuteurComboBox.SelectedIndex < 0 Then Exit Sub
        FrPersonne.Show(CInt(Me.NPersonneAuteurComboBox.SelectedValue), Me)
    End Sub

    Private Sub BtFicheDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFicheDest.Click
        If NPersonneDestinataireComboBox.SelectedIndex < 0 Then Exit Sub
        FrPersonne.Show(CInt(Me.NPersonneDestinataireComboBox.SelectedValue), Me)
    End Sub

    Private mustFade As Boolean = False
    Private Sub FrIntervention_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        If Not Me.Timer.Enabled OrElse Me.Width > 189 Then Exit Sub
        mustFade = True
        WaitFor(500)
        If mustFade Then Me.Opacity = 0.25
    End Sub

    Private Sub WaitFor(ByVal interval As Integer)
        Using t As New System.Timers.Timer(interval)
            AddHandler t.Elapsed, AddressOf StopTimer
            t.Start()
            While t.Enabled
                Application.DoEvents()
            End While
        End Using
    End Sub

    Private Sub StopTimer(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        CType(sender, System.Timers.Timer).Stop()
    End Sub

    Private Sub FrIntervention_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        mustFade = False
        WaitFor(500)
        If Not mustFade Then Me.Opacity = 1
    End Sub

    Private Sub BtListeChoixType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtListeChoixType.Click
        ModifListeChoix(DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeTypeEv)
    End Sub

    Private Sub BtListeChoixProduit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtListeChoixProduit.Click
        ModifListeChoix(DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix.ListeProduits)
    End Sub

    Private Sub ModifListeChoix(ByVal type As DsAgrifactTableAdapters.ListeChoixTableAdapter.NomsChoix)
        Using fr As New FrListeChoix(type)
            fr.StartPosition = FormStartPosition.CenterScreen
            fr.TopMost = Me.TopMost
            If fr.ShowDialog() = Windows.Forms.DialogResult.OK Then
                ChargerChoix()
            End If
        End Using
    End Sub
End Class
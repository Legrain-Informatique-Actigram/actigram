Public Class FrParametres

    Private connecte As Boolean = False
    Private modif As Boolean = False

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
        Me.MySettingsBindingSource.DataSource = GetType(My.MySettings)
    End Sub
#End Region

#Region "Form"
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
        connecte = SqlProxy.TestDefaultConnection
        ChargerDonnees()
        AddHandler My.Settings.PropertyChanged, AddressOf MySettings_PropertyChanged
        If Not connecte Then
            Me.TabControl1.TabPages.Remove(Me.tpOptions)
            Me.TabControl1.SelectedTab = Me.tpConnexion
        End If
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        If connecte Then
            Me.EntrepriseTA.FillByTypeClient(Me.DsAgrifact.Entreprise, DsAgrifactTableAdapters.EntrepriseTA.TypeClient.Particulier)
            Dim drEnt As DsAgrifact.EntrepriseRow = Me.DsAgrifact.Entreprise.NewEntrepriseRow
            drEnt.Nom = ""
            Me.DsAgrifact.Entreprise.AddEntrepriseRow(drEnt)
            Me.DsAgrifact.Entreprise.AcceptChanges()

            'Rempli la liste des comptes de type client par defaut
            Me.ComptesTableAdapter.FillByCompteClient(Me.DsAgrifact.Comptes)
            Dim drCpt As DsAgrifact.ComptesRow = Me.DsAgrifact.Comptes.NewComptesRow
            drCpt.CLib = ""
            drCpt.CDossier = ""
            drCpt.CCpt = ""
            Me.DsAgrifact.Comptes.AddComptesRow(drCpt)
            Me.DsAgrifact.Comptes.AcceptChanges()

            'Rempli la liste des tarifs par défaut
            Me.TarifTA.Fill(Me.DsAgrifact.Tarif)
            Dim drTarif As DsAgrifact.TarifRow = Me.DsAgrifact.Tarif.NewTarifRow
            drTarif.Libelle = ""
            Me.DsAgrifact.Tarif.AddTarifRow(drTarif)
            Me.DsAgrifact.Tarif.AcceptChanges()

            ChargerNFacture()
        End If
        MySettingsBindingSource.DataSource = My.Settings
        Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString = My.Settings.ConnString
        modif = False
        MajBoutons()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        If modif Then
            SqlProxy.SetDefaultConnection(Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString)
            If Me.EntrepriseBindingSource.Position = 0 Then
                My.Settings.nClientDefaut = -1
            End If
            If Me.TarifBindingSource.Position = -1 Then
                My.Settings.nTarifDefaut = -1
            End If
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

#Region "PosPrinterEnabledCheckBox"
    Private Sub PosPrinterEnabledCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PosPrinterEnabledCheckBox.CheckedChanged
        Me.PrinterNameTextBox.Enabled = PosPrinterEnabledCheckBox.Checked
        Me.BtChoixImpr.Enabled = PosPrinterEnabledCheckBox.Checked
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub
#End Region

#Region "LnkLog"
    Private Sub LnkLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkLog.LinkClicked
        OuvrirFichier(My.Application.Log.DefaultFileLogWriter.FullLogFileName)
    End Sub
#End Region

#Region " Gestion des n° facture "
    Private Sub ChargerNFacture()
        Me.lbNFacture.Text = String.Format("La prochaine facture aura le n°{0}", Main.GetNFacture(True))
    End Sub

    Private Sub LnkReclaimNFacture_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReclaimNFacture.LinkClicked
        Cursor.Current = Cursors.WaitCursor
        Main.ReclaimNFacture()
        ChargerNFacture()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lnkResetNFacture_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkResetNFacture.LinkClicked
        Cursor.Current = Cursors.WaitCursor
        Dim res As String = InputBox("Entrez le nouveau n° de facture.", , Main.GetNFacture(True).ToString)
        Dim newN As Long = -1
        If Long.TryParse(res, newN) Then
            Main.SetNextNFacture(newN)
            ChargerNFacture()
        Else
            MsgBox("Le numéro saisi n'est pas correct.", MsgBoxStyle.Exclamation)
        End If
        Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region "Button"
    Private Sub BtChoixImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtChoixImpr.Click
        Using dlg As New PrintDialog
            With dlg
                .AllowCurrentPage = False
                .AllowPrintToFile = False
                .AllowSelection = False
                .AllowSomePages = False
                .ShowHelp = False
                .UseEXDialog = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    My.Settings.PrinterName = .PrinterSettings.PrinterName
                    Me.MySettingsBindingSource.ResetCurrentItem()
                End If
            End With
        End Using
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MySettings_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
        modif = True
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        ProduitBindingNavigatorSaveItem.Enabled = modif
    End Sub
#End Region

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles SqlConnectionConfig.Validated, ComboBox1.SelectedIndexChanged, _
                        PosPrinterEnabledCheckBox.CheckedChanged
        MySettingsBindingSource.EndEdit()
        modif = True
        MajBoutons()
        If sender Is SqlConnectionConfig Then
            'La liste des clients n'est plus valide
            Me.DsAgrifact.Clear()
            'On ne peut plus modifier les options de factures
            Me.GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub ComboBoxDefautTarif_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBoxDefautCompte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MySettingsBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MySettingsBindingSource.CurrentChanged

    End Sub

End Class

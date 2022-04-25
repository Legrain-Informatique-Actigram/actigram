Imports AgrigestEDI.Impressions
Imports CrystalDecisions.CrystalReports.Engine
Imports AgrigestEDI.GestionMenuEtats

Public Class FrEtats

    'Private ImpJTreso As ImpJTreso
    Private ImpJAchat As ImpJAchat
    'Private ImpRecapTVA As ImpRecapTVA
    'Private ImpBLG1 As ImpBalanceG1
    'Private ImpBLA As ImpBalanceA
    'Private ImpDM As ImpDossierMarge
    'Private ImpBC As ImpBalanceC
    Private ImpGlG As ImpGL
    'Private ImpGlA As ImpGlA
    'Private ImpJCrSaisie As ImpJCrSaisie
    'Private ImpMvt As ImpMvtP
    'Private ImpCptNSodle As ImpCptNSolde
    'Private ImpCRPresBal As ImpCRPresBal
    'Private ImpBilanPresBal As ImpBilanPresBal

#Region "Form"
    Private Sub Accueil_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lvMenus.BeginUpdate()
    End Sub

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pgbar.Visible = False
        SetChildFormIcon(Me)
        With ilIcons
            .Images.Add("_new", My.Resources._new)
            .Images.Add("create", My.Resources.create)
            .Images.Add("export", My.Resources.export)
            .Images.Add("book", My.Resources.book)
            .Images.Add("liste", My.Resources.liste)
            .Images.Add("restore", My.Resources.restore)
            .Images.Add("utils", My.Resources.utils)
        End With

        GestionMenuEtats.Menu.ChargerMenus(Me.lvMenus)
    End Sub
#End Region

#Region "lvMenus"
    Private Sub lvMenus_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvMenus.ItemActivate
        Dim i As Item
        If TypeOf sender Is ListView And CType(sender, ListView).SelectedItems.Count = 1 Then
            i = CType(CType(sender, ListView).SelectedItems(0).Tag, Item)
        ElseIf TypeOf sender Is ListViewItem Then
            i = CType(CType(sender, ListViewItem).Tag, Item)
        Else
            Exit Sub
        End If

        If i Is Nothing Then Exit Sub

        Select Case i.Nom
            Case "JournalAchats"

                Me.TableLayoutPanel1.Controls.Clear()
                Dim libDtPeriodeDeb As New Label
                Dim DtPeriodeDeb As New DateTimePicker
                Dim libDtPeriodeFin As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim BtImpr As New Button

                MEFLabel(libDtPeriodeDeb, My.Resources.Strings.Etats_DateDeb)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)

                With DtPeriodeDeb
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateDebutEx
                    .Name = "DtDeb"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "Journaux"

                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

            Case "GrandLivreGen"
                Me.TableLayoutPanel1.Controls.Clear()
                Dim ds As New AgrigestEDI.dbDonneesDataSet
                Dim libFourchDeb As New Label
                Dim libFourchFin As New Label
                Dim libDtPeriodeFin As New Label
                Dim libCkLettrage As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim cboFourchDeb As New ComboBox
                Dim cboFourchFin As New ComboBox
                Dim ckLettrage As New CheckBox

                Dim BtImpr As New Button
                Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
                    dta.FillByDossier(ds.Comptes, My.User.Name)
                End Using


                MEFLabel(libFourchDeb, My.Resources.Strings.Etats_CptDeb)
                MEFLabel(libFourchFin, My.Resources.Strings.Etats_CptFin)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)
                MEFLabel(libCkLettrage, "Inclure les écritures lettrées ?")

                With cboFourchDeb
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FDeb"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With cboFourchFin
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FFin"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                With ckLettrage
                    .Name = "ckLettrage"
                    .Checked = True
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "GrandLivreGen"

                Me.TableLayoutPanel1.Controls.Add(libFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(cboFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(libFourchFin)
                Me.TableLayoutPanel1.Controls.Add(cboFourchFin)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(libCkLettrage)
                Me.TableLayoutPanel1.Controls.Add(ckLettrage)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

                With cboFourchFin
                    .SelectedIndex = .Items.Count - 1
                End With

            Case "GrandLivrePort"
                Me.TableLayoutPanel1.Controls.Clear()
                Dim ds As New AgrigestEDI.dbDonneesDataSet
                Dim libFourchDeb As New Label
                Dim libFourchFin As New Label
                Dim libDtPeriodeFin As New Label
                Dim libCkLettrage As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim cboFourchDeb As New ComboBox
                Dim cboFourchFin As New ComboBox
                Dim ckLettrage As New CheckBox

                Dim BtImpr As New Button
                Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
                    dta.FillByDossier(ds.Comptes, My.User.Name)
                End Using


                MEFLabel(libFourchDeb, My.Resources.Strings.Etats_CptDeb)
                MEFLabel(libFourchFin, My.Resources.Strings.Etats_CptFin)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)
                MEFLabel(libCkLettrage, "Inclure les écritures lettrées ?")

                With cboFourchDeb
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FDeb"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With cboFourchFin
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FFin"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                With ckLettrage
                    .Name = "ckLettrage"
                    .Checked = True
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "GrandLivrePort"

                Me.TableLayoutPanel1.Controls.Add(libFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(cboFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(libFourchFin)
                Me.TableLayoutPanel1.Controls.Add(cboFourchFin)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(libCkLettrage)
                Me.TableLayoutPanel1.Controls.Add(ckLettrage)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

                With cboFourchFin
                    .SelectedIndex = .Items.Count - 1
                End With

            Case "GrandLivreAnaPort"
                Me.TableLayoutPanel1.Controls.Clear()
                Dim ds As New AgrigestEDI.dbDonneesDataSet
                Dim libFourchDeb As New Label
                Dim libFourchFin As New Label
                Dim libFourchActDeb As New Label
                Dim txtFourchActDeb As New TextBox
                Dim libFourchActFin As New Label
                Dim txtFourchActFin As New TextBox
                Dim libDtPeriodeFin As New Label
                Dim libCkLettrage As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim cboFourchDeb As New ComboBox
                Dim cboFourchFin As New ComboBox
                Dim cboFourchActDeb As New ComboBox
                Dim cboFourchActFin As New ComboBox
                Dim ckLettrage As New CheckBox

                Dim BtImpr As New Button
                Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
                    dta.FillByDossier(ds.Comptes, My.User.Name)
                End Using
                Using dta As New dbDonneesDataSetTableAdapters.ActivitesTableAdapter
                    dta.FillByDossier(ds.Activites, My.User.Name)
                End Using

                MEFLabel(libFourchDeb, My.Resources.Strings.Etats_CptDeb)
                MEFLabel(libFourchFin, My.Resources.Strings.Etats_CptFin)
                MEFLabel(libFourchActDeb, My.Resources.Strings.Etats_ActDeb)
                MEFLabel(libFourchActFin, My.Resources.Strings.Etats_ActFin)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)
                MEFLabel(libCkLettrage, "Inclure les écritures lettrées ?")

                With cboFourchDeb
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FDeb"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With cboFourchFin
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FFin"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With cboFourchActDeb
                    .DataSource = New DataView(ds.Activites, "", "AActi", DataViewRowState.CurrentRows)
                    .DisplayMember = "AActi"
                    .FormattingEnabled = True
                    .Name = "FActDeb"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "AActi"
                End With

                With cboFourchActFin
                    .DataSource = New DataView(ds.Activites, "", "AActi", DataViewRowState.CurrentRows)
                    .DisplayMember = "AActi"
                    .FormattingEnabled = True
                    .Name = "FActFin"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "AActi"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                With ckLettrage
                    .Name = "ckLettrage"
                    .Checked = True
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "GrandLivreAnaPort"

                Me.TableLayoutPanel1.Controls.Add(libFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(cboFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(libFourchFin)
                Me.TableLayoutPanel1.Controls.Add(cboFourchFin)
                Me.TableLayoutPanel1.Controls.Add(libFourchActDeb)
                Me.TableLayoutPanel1.Controls.Add(cboFourchActDeb)
                Me.TableLayoutPanel1.Controls.Add(libFourchActFin)
                Me.TableLayoutPanel1.Controls.Add(cboFourchActFin)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(libCkLettrage)
                Me.TableLayoutPanel1.Controls.Add(ckLettrage)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

                With cboFourchFin
                    .SelectedIndex = .Items.Count - 1
                End With

                With cboFourchActFin
                    .SelectedIndex = .Items.Count - 1
                End With

                'Case "GrandLivreAna" : ImpGlA.AfficherChoix()
                'Case "CompteRendu"
                'Case "Mouv"
                'Case "Detail"
                'Case "GrandLivreAna" : ImpGlA.AfficherChoix()
                'Case "CompteRendu"
                'Case "Mouv"
                'Case "Detail"



            Case "BalanceGen"
                Me.TableLayoutPanel1.Controls.Clear()
                Dim ds As New AgrigestEDI.dbDonneesDataSet
                'Dim PlanComptableTableAdapter As New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
                Dim libFourchDeb As New Label
                Dim txtFourchDeb As New TextBox
                Dim libFourchFin As New Label
                Dim txtFourchFin As New TextBox
                Dim libDtPeriodeFin As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim cboFourchDeb As New ComboBox
                Dim cboFourchFin As New ComboBox
                Dim BtImpr As New Button

                Me.TableLayoutPanel1.Controls.Clear()
                Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
                    dta.FillByDossier(ds.Comptes, My.User.Name)
                End Using
                MEFLabel(libFourchDeb, My.Resources.Strings.Etats_CptDeb)
                MEFLabel(libFourchFin, My.Resources.Strings.Etats_CptFin)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)

                With cboFourchDeb
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FDeb"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With cboFourchFin
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FFin"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "BalanceGen"

                Me.TableLayoutPanel1.Controls.Add(libFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(cboFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(libFourchFin)
                Me.TableLayoutPanel1.Controls.Add(cboFourchFin)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer


                With cboFourchFin
                    .SelectedIndex = .Items.Count - 1
                End With

            Case "BalanceAna"
                Me.TableLayoutPanel1.Controls.Clear()
                Dim ds As New AgrigestEDI.dbDonneesDataSet
                'Dim PlanComptableTableAdapter As New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
                Dim libFourchDeb As New Label
                Dim txtFourchDeb As New TextBox
                Dim libFourchFin As New Label
                Dim txtFourchFin As New TextBox
                Dim libFourchActDeb As New Label
                Dim txtFourchActDeb As New TextBox
                Dim libFourchActFin As New Label
                Dim txtFourchActFin As New TextBox
                Dim libDtPeriodeFin As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim cboFourchDeb As New ComboBox
                Dim cboFourchFin As New ComboBox
                Dim cboFourchActDeb As New ComboBox
                Dim cboFourchActFin As New ComboBox
                Dim BtImpr As New Button

                Me.TableLayoutPanel1.Controls.Clear()
                Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
                    dta.FillByDossier(ds.Comptes, My.User.Name)
                End Using
                Using dta As New dbDonneesDataSetTableAdapters.ActivitesTableAdapter
                    dta.FillByDossier(ds.Activites, My.User.Name)
                End Using
                MEFLabel(libFourchDeb, My.Resources.Strings.Etats_CptDeb)
                MEFLabel(libFourchFin, My.Resources.Strings.Etats_CptFin)
                MEFLabel(libFourchActDeb, My.Resources.Strings.Etats_ActDeb)
                MEFLabel(libFourchActFin, My.Resources.Strings.Etats_ActFin)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)

                With cboFourchDeb
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FDeb"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With cboFourchFin
                    .DataSource = New DataView(ds.Comptes, "", "CCpt", DataViewRowState.CurrentRows)
                    .DisplayMember = "CCpt"
                    .FormattingEnabled = True
                    .Name = "FFin"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "CCpt"
                End With

                With cboFourchActDeb
                    .DataSource = New DataView(ds.Activites, "", "AActi", DataViewRowState.CurrentRows)
                    .DisplayMember = "AActi"
                    .FormattingEnabled = True
                    .Name = "FActDeb"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "AActi"
                End With

                With cboFourchActFin
                    .DataSource = New DataView(ds.Activites, "", "AActi", DataViewRowState.CurrentRows)
                    .DisplayMember = "AActi"
                    .FormattingEnabled = True
                    .Name = "FActFin"
                    .Size = New System.Drawing.Size(121, 21)
                    .ValueMember = "AActi"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "BalanceAna"

                Me.TableLayoutPanel1.Controls.Add(libFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(cboFourchDeb)
                Me.TableLayoutPanel1.Controls.Add(libFourchFin)
                Me.TableLayoutPanel1.Controls.Add(cboFourchFin)
                Me.TableLayoutPanel1.Controls.Add(libFourchActDeb)
                Me.TableLayoutPanel1.Controls.Add(cboFourchActDeb)
                Me.TableLayoutPanel1.Controls.Add(libFourchActFin)
                Me.TableLayoutPanel1.Controls.Add(cboFourchActFin)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer


                With cboFourchFin
                    .SelectedIndex = .Items.Count - 1
                End With

                With cboFourchActFin
                    .SelectedIndex = .Items.Count - 1
                End With

            Case "RecapTVA"

                Me.TableLayoutPanel1.Controls.Clear()
                Dim libDtPeriodeDeb As New Label
                Dim DtPeriodeDeb As New DateTimePicker
                Dim libDtPeriodeFin As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim BtImpr As New Button

                MEFLabel(libDtPeriodeDeb, My.Resources.Strings.Etats_DateDeb)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)

                With DtPeriodeDeb
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateDebutEx
                    .Name = "DtDeb"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "RecapTVA"

                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

            Case "TVAVente"

                Me.TableLayoutPanel1.Controls.Clear()
                Dim libDtPeriodeDeb As New Label
                Dim DtPeriodeDeb As New DateTimePicker
                Dim libDtPeriodeFin As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim BtImpr As New Button

                MEFLabel(libDtPeriodeDeb, My.Resources.Strings.Etats_DateDeb)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)

                With DtPeriodeDeb
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateDebutEx
                    .Name = "DtDeb"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "TVAVente"

                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer


            Case "TVAAchat"

                Me.TableLayoutPanel1.Controls.Clear()
                Dim libDtPeriodeDeb As New Label
                Dim DtPeriodeDeb As New DateTimePicker
                Dim libDtPeriodeFin As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim BtImpr As New Button

                MEFLabel(libDtPeriodeDeb, My.Resources.Strings.Etats_DateDeb)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)

                With DtPeriodeDeb
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateDebutEx
                    .Name = "DtDeb"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "TVAAchat"

                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

            Case "InvComplet"
                Dim BtImpr As New Button

                Me.TableLayoutPanel1.Controls.Clear()

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "InvComplet"

                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

            Case "InvRecap"
                Dim BtImpr As New Button

                Me.TableLayoutPanel1.Controls.Clear()

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "InvRecap"

                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer

            Case "AnnexesTiers"
                Me.TableLayoutPanel1.Controls.Clear()
                Dim libDtPeriodeDeb As New Label
                Dim DtPeriodeDeb As New DateTimePicker
                Dim libDtPeriodeFin As New Label
                Dim DtPeriodeFin As New DateTimePicker
                Dim BtImpr As New Button

                MEFLabel(libDtPeriodeDeb, My.Resources.Strings.Etats_DateDeb)
                MEFLabel(libDtPeriodeFin, My.Resources.Strings.Etats_DateFin)

                With DtPeriodeDeb
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateDebutEx
                    .Name = "DtDeb"
                End With

                With DtPeriodeFin
                    .Width = 100
                    .Format = DateTimePickerFormat.Short
                    .Value = My.Dossier.Principal.DateFinEx
                    .Name = "DtFin"
                End With

                BtImpr.Text = My.Resources.Strings.Etats_BtImprimer
                BtImpr.Tag = "AnnexesTiers"

                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeDeb)
                Me.TableLayoutPanel1.Controls.Add(libDtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(DtPeriodeFin)
                Me.TableLayoutPanel1.Controls.Add(BtImpr)

                AddHandler BtImpr.Click, AddressOf Imprimer
        End Select
    End Sub
#End Region

#Region "toolbar"
    Private Sub CloseToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripButton.Click
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MEFLabel(ByVal MonLab As Label, ByVal Titre As String)
        With MonLab
            .Margin = New Padding(3, 6, 3, 0)
            .AutoSize = True
            .Text = Titre
        End With
    End Sub

    Private Sub ResetProgress()
        Me.pgbar.Visible = False
        Me.LbTitre.Text = "Gestion des Etats"
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As String = Nothing)
        Me.pgbar.Visible = True
        Me.pgbar.Value = percent
        If status IsNot Nothing Then
            Me.LbTitre.Text = status
            Application.DoEvents()
        End If
    End Sub

    Private Sub Imprimer(ByVal sender As Object, ByVal e As EventArgs)
        ReportProgress(0, My.Resources.Strings.Initialisation)
        Cursor.Current = Cursors.WaitCursor
        Try
            ReportProgress(50, My.Resources.Strings.ChargementDesDonnees)
            Impressions.PrepaTable.RecopierTVA()
            Dim report As ReportDocument
            Select Case CType(sender, Button).Tag.ToString
                Case "BalanceGen"
                    Dim FDeb As String = CStr(lectureParam("FDeb"))
                    Dim FFin As String = CStr(lectureParam("FFin"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim ds As DataSet = Impressions.ImpBalGen.GetDataRptBalanceG(FDeb, FFin, DtFin)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpBalGen.PrepareRptRptBBalanceG(ds, DtFin, FDeb, FFin)
                    UtilImp.AffichDonneesGen(report)

                Case "BalanceAna"
                    Dim FDeb As String = CStr(lectureParam("FDeb"))
                    Dim FFin As String = CStr(lectureParam("FFin"))
                    Dim FActDeb As String = CStr(lectureParam("FActDeb"))
                    Dim FActFin As String = CStr(lectureParam("FActFin"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim ds As DataSet = Impressions.ImpBalAna.GetDataRptBalanceA(FDeb, FFin, FActDeb, FActFin, DtFin)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpBalAna.PrepareRptRptBBalanceA(ds, DtFin, FDeb, FFin)
                    UtilImp.AffichDonneesGen(report)

                Case "GrandLivreGen"
                    Dim FDeb As String = CStr(lectureParam("FDeb"))
                    Dim FFin As String = CStr(lectureParam("FFin"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim Lettr As Boolean = CBool(lectureParam("CkLettrage"))
                    Dim ds As DataSet = Impressions.ImpGL.GetDataRptGL(FDeb, FFin, DtFin, Lettr)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpGL.PrepareRptRptGL(ds, DtFin, FDeb, FFin)
                    UtilImp.AffichDonneesGen(report)

                    '25/08/10 : Ajout HG
                Case "GrandLivrePort"
                    Dim FDeb As String = CStr(lectureParam("FDeb"))
                    Dim FFin As String = CStr(lectureParam("FFin"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim Lettr As Boolean = CBool(lectureParam("CkLettrage"))
                    Dim ds As DataSet = Impressions.ImpGL.GetDataRptGL(FDeb, FFin, DtFin, Lettr)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpGL.PrepareRptRptGLPort(ds, DtFin, FDeb, FFin)
                    UtilImp.AffichDonneesGen(report)

                    '05/10/11 : Ajout HG
                Case "GrandLivreAnaPort"
                    Dim FDeb As String = CStr(lectureParam("FDeb"))
                    Dim FFin As String = CStr(lectureParam("FFin"))
                    Dim FActDeb As String = CStr(lectureParam("FActDeb"))
                    Dim FActFin As String = CStr(lectureParam("FActFin"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim Lettr As Boolean = CBool(lectureParam("CkLettrage"))
                    Dim ds As DataSet = Impressions.ImpGLAna.GetDataRptGLAna(FDeb, FFin, FActDeb, FActFin, DtFin, Lettr)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpGLAna.PrepareRptRptGLAnaPort(ds, DtFin, FDeb, FFin)
                    UtilImp.AffichDonneesGen(report)

                Case "Journaux"
                    Dim DtDeb As String = CStr(lectureParam("DtDeb"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim ds As DataSet = Impressions.ImpJAchat.GetDataRptJournalAchat(DtDeb, DtFin)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpJAchat.PrepareRptJournalAchat(ds, DtDeb, DtFin)
                    UtilImp.AffichDonneesGen(report)

                Case "RecapTVA"
                    Dim DtDeb As String = CStr(lectureParam("DtDeb"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim ds As DataSet = Impressions.ImpRecapTVA.GetDataRptRecapTVA(DtDeb, DtFin)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpRecapTVA.PrepareRptRecapTVA(ds, DtDeb, DtFin)
                    UtilImp.AffichDonneesGen(report)

                Case "TVAVente"
                    Dim DtDeb As String = CStr(lectureParam("DtDeb"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim ds As DataSet = Impressions.ImpTVAVente.GetDataRptTVAVente(DtDeb, DtFin)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpTVAVente.PrepareRptTVAVente(ds, DtDeb, DtFin)
                    UtilImp.AffichDonneesGen(report)

                Case "TVAAchat"
                    Dim DtDeb As String = CStr(lectureParam("DtDeb"))
                    Dim DtFin As String = CStr(lectureParam("DtFin"))
                    Dim ds As DataSet = Impressions.ImpTVAAchat.GetDataRptTVAAchat(DtDeb, DtFin)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Impressions.ImpTVAAchat.PrepareRptTVAAchat(ds, DtDeb, DtFin)
                    UtilImp.AffichDonneesGen(report)

                Case "InvComplet"
                    Dim dsImpression As DataSetImpression = Nothing
                    Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                    Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(My.User.Name)
                    Dim methodeForf As Boolean

                    dsImpression = Inventaire.ClassesMetier.ImprInventaire.GetDataTtTypeInvEtINVGDossier(My.User.Name)

                    'Recherche de la méthode d'inventaire
                    Select Case dossier.DMethodeInventaire
                        Case My.Resources.M1 'Detaillée
                            methodeForf = False
                        Case My.Resources.M2 'Forfaitaire
                            methodeForf = True
                    End Select

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Inventaire.ClassesMetier.ImprInventaire.PrepareRpt(dsImpression, "EtTtListeInv.rpt", My.User.Name, True, methodeForf)
                    UtilImp.AffichDonneesGen(report)

                Case "InvRecap"
                    Dim dsImpression As DataSetImpression = Nothing
                    Dim gestDossiers As New Dossiers.ClassesControleur.GestionnaireDossiers(My.Settings.dbDonneesConnectionString)
                    Dim dossier As Dossiers.ClassesMetier.Dossiers = gestDossiers.GetDossier(My.User.Name)
                    Dim methodeForf As Boolean

                    Cursor.Current = Cursors.WaitCursor

                    dsImpression = Inventaire.ClassesMetier.ImprInventaire.GetDataTtTypeInvEtINVGDossier(My.User.Name)

                    'Recherche de la méthode d'inventaire
                    Select Case dossier.DMethodeInventaire
                        Case My.Resources.M1 'Detaillée
                            methodeForf = False
                        Case My.Resources.M2 'Forfaitaire
                            methodeForf = True
                    End Select

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Inventaire.ClassesMetier.ImprInventaire.PrepareRpt(dsImpression, "EtTtListeInv.rpt", My.User.Name, False, methodeForf)
                    UtilImp.AffichDonneesGen(report)

                Case "AnnexesTiers"
                    Dim dsImpression As DataSetImpression = Nothing
                    Dim dateDeb As Date = CDate(lectureParam("DtDeb"))
                    Dim dateFin As Date = CDate(lectureParam("DtFin"))

                    Cursor.Current = Cursors.WaitCursor

                    dsImpression = AnnexesTiers.ClassesMetier.ImpressionAnnexesTiers.GetDataImpAnnexesTiers(My.User.Name, dateDeb, dateFin)

                    ReportProgress(60, My.Resources.Strings.OuvertureEtat)
                    report = Inventaire.ClassesMetier.ImprInventaire.PrepareRpt(dsImpression, "EtListeInvTiers.rpt", My.User.Name, , , dateDeb, dateFin)
                    UtilImp.AffichDonneesGen(report)
            End Select

            If report IsNot Nothing Then
                ReportProgress(80)
                Using fr As New EcranCrystal(report)
                    fr.TopMost = False
                    fr.ShowDialog()
                    ReportProgress(100)
                End Using
            End If
        Finally
            ResetProgress()
        End Try
    End Sub

    Private Function lectureParam(ByVal nomCtrl As String) As Object
        Dim ctrls() As Control = Me.TableLayoutPanel1.Controls.Find(nomCtrl, False)
        If ctrls.Length = 0 Then
            Return ""
        Else
            If TypeOf ctrls(0) Is CheckBox Then
                Return CType(ctrls(0), CheckBox).Checked
            Else
                Return ctrls(0).Text
            End If
        End If
    End Function
#End Region

    Private Sub Me_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        Me.LbTitre.Text = Me.Text
    End Sub
End Class
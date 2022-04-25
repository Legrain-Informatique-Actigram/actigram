Public Class FrSaisieImmo

    Private dsLocal As ImmobilisationsDataSet
    Private idImmo As Immobilisations.IdImmo
    Private action As Actions
    Private loaded As Boolean
    Private dv As DataView
    Private dvCpt As DataView
    Private dvActi As DataView
    Private mode As Immobilisations.Immobilisation.ModeImmo = Immobilisations.Immobilisation.ModeImmo.None

    Public Enum Actions
        Creation
        Modif
        Consult
        Cession
    End Enum

#Region "Constructeurs"
    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
    End Sub

    Public Sub New(ByVal action As Actions, ByVal nDossier As String, ByVal nCpt As String, ByVal ordre As Integer, Optional ByVal acti As String = "0000", Optional ByVal ncompo As Integer = 0)
        Me.New(action, New Immobilisations.IdImmo(nDossier, nCpt, ordre, acti, ncompo))
    End Sub

    Public Sub New(ByVal action As Actions, ByVal id As Immobilisations.IdImmo)
        Me.New()
        Me.action = action
        Me.idImmo = id
    End Sub
#End Region

#Region "Form"
    Private Sub FrSaisieImmo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ComptesTableAdapter.FillByCDossier(Me.ImmobilisationsDataSet.Comptes, My.User.Name)
        Me.ActivitesTableAdapter.FillByADossier(Me.ImmobilisationsDataSet.Activites, My.User.Name)
        Me.PlanComptableTableAdapter.FillByPlDossier(Me.ImmobilisationsDataSet.PlanComptable, My.User.Name)
        Me.ImmobilisationsTableAdapter.FillByIDossier(Me.ImmobilisationsDataSet.Immobilisations, My.User.Name)

        If Me.action = Actions.Creation Then
            Me.NewButton.Visible = True
            Me.OKButton.Text = "Fermer"
        Else
            Me.NewButton.Visible = False
            Me.OKButton.Text = "OK"
        End If

        Me.DtForfDateTimePicker.Enabled = False
        Me.CessionGroupBox.Left = Me.ForfGroupBox.Left

        For Each ctl As Control In Me.Controls
            RegisterKeyPress(ctl)
        Next

        Try
            LoadData()

            loaded = True
        Catch ex As UserCancelledException
            Me.DialogResult = DialogResult.Cancel
        End Try
    End Sub
#End Region

#Region "Navigation par return"
    Private Sub RegisterKeyPress(ByVal ctl As Control)
        If ctl.TabStop _
        AndAlso Not TypeOf ctl Is TabControl _
        AndAlso Not (TypeOf ctl Is TextBox AndAlso CType(ctl, TextBox).AcceptsReturn) Then
            AddHandler ctl.KeyPress, AddressOf GestionReturn
        End If
        If TypeOf ctl Is TabControl Then
            For Each tp As TabPage In CType(ctl, TabControl).TabPages
                RegisterKeyPress(tp)
            Next
        ElseIf Not TypeOf ctl Is NumericUpDown Then
            For Each c As Control In ctl.Controls
                RegisterKeyPress(c)
            Next
        End If
    End Sub

    Private Sub GestionReturn(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            Me.SelectNextControl(CType(sender, System.Windows.Forms.Control), True, True, True, True)

            e.Handled = True
        End If
    End Sub

    Private Sub DureeNumericUpDown_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DureeNumericUpDown.KeyPress
        If e.KeyChar = vbCr Then
            Me.TabControl1.SelectedTab = Me.ResultTabPage
            Me.SelectNextControl(Me.ResultTabPage, True, True, True, True)

            e.Handled = True
        End If
    End Sub
#End Region

#Region "Util controls databinding"
    Private Sub ConfigDec(ByVal ctl As Control, ByVal dataMember As String, Optional ByVal prop As String = "Value")
        ctl.DataBindings.Clear()
        Dim b As New FormatBinding(prop, dv, dataMember)
        ctl.DataBindings.Add(b)
    End Sub

    Private Sub ConfigNullableInt(ByVal ctl As Control, ByVal dataMember As String, Optional ByVal prop As String = "Value")
        ctl.DataBindings.Clear()
        Dim b As New FormatBinding(prop, dv, dataMember, , 0)
        ctl.DataBindings.Add(b)
    End Sub

    Private Sub ConfigNullableDec(ByVal ctl As Control, ByVal dataMember As String, Optional ByVal prop As String = "Value")
        ctl.DataBindings.Clear()
        Dim b As New FormatBinding(prop, dv, dataMember, "N2", 0)
        AddHandler b.Parse, AddressOf DecimalParse
        ctl.DataBindings.Add(b)
    End Sub

    Private Sub ConfigNullableDate(ByVal ctl As Control, ByVal dataMember As String)
        ctl.DataBindings.Clear()
        Dim b As New FormatBinding("Value", dv, dataMember, , New Date(1900, 1, 1))
        ctl.DataBindings.Add(b)
    End Sub

    Private Sub ConfigCurrency(ByVal ctl As Control, ByVal dataMember As String)
        ctl.DataBindings.Clear()
        Dim b As New FormatBinding("Text", Me.dv, dataMember, "C2", 0)
        AddHandler b.Parse, AddressOf CurrencyParse
        ctl.DataBindings.Add(b)
    End Sub
#End Region

#Region "Données"
    Private Sub LoadData()
        Me.dsLocal = CType(Me.ImmobilisationsDataSet.Clone(), ImmobilisationsDataSet)

        If Me.action = Actions.Creation Then
            dv = New DataView(Me.dsLocal.Immobilisations)
            Me.BindingContext(dv).AddNew()

            If Not Me.idImmo Is Nothing Then
                With CType(Me.BindingContext(dv).Current, DataRowView)
                    .Item("ICpt") = Me.idImmo.nCpt
                    .Item("IActi") = Me.idImmo.Acti
                    If Me.idImmo.valAcquis <> 0 Then .Item("IValAcquis") = Me.idImmo.valAcquis
                    If Me.idImmo.dtAcquis > Date.MinValue Then .Item("IDtAcquis") = Me.idImmo.dtAcquis
                    If Me.idImmo.libelle <> "" Then .Item("ILib") = Me.idImmo.libelle
                End With
            End If
        Else
            Dim immobilisationsDR As ImmobilisationsDataSet.ImmobilisationsRow = Me.idImmo.Find()
            Dim immoDR As ImmobilisationsDataSet.ImmobilisationsRow = Me.dsLocal.Immobilisations.NewImmobilisationsRow()

            For i As Integer = 0 To Me.dsLocal.Immobilisations.Columns.Count - 1
                immoDR.Item(i) = immobilisationsDR.Item(i)
            Next i

            Me.dsLocal.Immobilisations.Rows.Add(immoDR)
            Me.dsLocal.Immobilisations.AcceptChanges()
            immoDR.SetModified()

            dv = New DataView(Me.dsLocal.Immobilisations)

            Me.BindingContext(dv).Position = 0
        End If

        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)

        DeterminerMode(drv)

        InitGUI(drv)

        Databinding()
    End Sub

    Private Sub SetDefaultValues()
        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)

        If drv.IsNew Then
            If Me.mode = Immobilisations.Immobilisation.ModeImmo.PassageAuReel Then
                drv("IDtForf") = FindDtForf()
            End If

            drv("IDossier") = My.User.Name

            If IsDBNull(drv("ICpt")) Then
                drv("IOrdre") = 0
            Else
                Dim acti As String = Convert.ToString(drv("IActi"))

                If acti = "" Then acti = "0000"

                drv("IOrdre") = Immobilisations.Immobilisation.FindNewOrdre(CStr(drv("ICpt")), acti)
            End If

            If IsDBNull(drv("IDtAcquis")) Then
                If Me.mode = Immobilisations.Immobilisation.ModeImmo.Acquisition Then
                    If My.Dossier.Principal.DateFinEx < Today Then
                        drv("IDtAcquis") = My.Dossier.Principal.DateFinEx
                    ElseIf My.Dossier.Principal.DateDebutEx > Today Then
                        drv("IDtAcquis") = My.Dossier.Principal.DateDebutEx
                    Else
                        drv("IDtAcquis") = Today
                    End If
                Else
                    drv("IDtAcquis") = My.Dossier.Principal.DateDebutEx.AddDays(-1)
                End If
            End If

            drv("ITypAmt") = "L"
            drv("ICoeff") = 1
            drv("IValLeasing") = 0
            drv("INCompo") = 0
        End If
    End Sub

    Private Function FindDtForf() As Date
        Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
            If (immobilisationsTA.MaxIDtForfByIDossier(My.User.Name).HasValue()) Then
                Return immobilisationsTA.MaxIDtForfByIDossier(My.User.Name).GetValueOrDefault()
            Else
                Return My.Dossier.Principal.DateDebutEx
            End If
        End Using

        'Dim o As Object = FrMDI.DossierEnCours.ds.Immobilisations.Compute("Max(IDtForf)", "")
        'If IsDBNull(o) Then
        '    Return FrMDI.DossierEnCours.DtDebEx
        'Else
        '    Return CDate(o)
        'End If
    End Function

    Private Sub DeterminerMode(ByRef drv As DataRowView)
        'Déterminer le mode
        Select Case Me.action
            Case Actions.Creation
                If Me.mode = Immobilisations.Immobilisation.ModeImmo.None Then
                    Dim fr As New FrNouvImmo()
                    If fr.ShowDialog = DialogResult.Cancel Then
                        Throw New UserCancelledException("")
                    Else
                        Me.mode = fr.Mode
                    End If
                End If
                'Determiner les valeurs par défaut
                SetDefaultValues()
            Case Actions.Cession
                Dim immo As New Immobilisations.Immobilisation(Immobilisations.Immobilisation.ModeImmo.Cession)

                'Demander si cession partielle ou totale
                Dim fr As New FrChoixCession

                If fr.ShowDialog(Me) = DialogResult.Cancel Then
                    Throw New UserCancelledException("")
                End If

                Me.mode = Immobilisations.Immobilisation.ModeImmo.Cession

                If fr.IsPartielle Then
                    Dim newdrv As DataRowView = immo.CessionPartielle(drv, Me.idImmo.dtCession, Me.idImmo.valCession)

                    'Enregistrer les deux immo
                    EnregistrerDonnees(drv)
                    EnregistrerDonnees(newdrv)

                    'A Partir de maintenant on bosse sur la partie cédée
                    Me.BindingContext(dv).Position = 1
                    drv = CType(Me.BindingContext(dv).Current, DataRowView)
                    Me.idImmo = New Immobilisations.IdImmo(drv)
                Else
                    If immo.DtFinEx < Today Then
                        drv("IDtCess") = immo.DtFinEx
                    ElseIf immo.DtDebEx > Today Then
                        drv("IDtCess") = immo.DtDebEx
                    Else
                        drv("IDtCess") = Today
                    End If

                    drv("IValCess") = drv("IValVenale")

                    If Me.idImmo.dtCession > #1/1/1900# Then drv("IDtCess") = Me.idImmo.dtCession
                    If Me.idImmo.valCession <> 0 Then drv("IValCess") = Me.idImmo.valCession
                End If
            Case Actions.Modif
                'Mode a determiner en fonction de l'immo
                If IsDBNull(drv("IMode")) Then
                    Me.mode = Immobilisations.Immobilisation.ModeImmo.Acquisition
                Else
                    Me.mode = CType(drv("IMode"), Immobilisations.Immobilisation.ModeImmo)
                End If
                If Not (Me.mode = Immobilisations.Immobilisation.ModeImmo.Acquisition _
                        AndAlso CDate(drv("IDtAcquis")) >= My.Dossier.Principal.DateDebutEx _
                        AndAlso CDate(drv("IDtAcquis")) <= My.Dossier.Principal.DateFinEx) Then
                    If Me.mode = Immobilisations.Immobilisation.ModeImmo.Cession _
                            AndAlso CDate(drv("IDtCess")) >= My.Dossier.Principal.DateDebutEx _
                            AndAlso CDate(drv("IDtCess")) <= My.Dossier.Principal.DateFinEx Then
                        Me.action = Actions.Cession
                        Me.mode = Immobilisations.Immobilisation.ModeImmo.Cession
                    Else
                        Me.action = Actions.Consult
                        Me.mode = Immobilisations.Immobilisation.ModeImmo.Calcul
                    End If
                End If
            Case Actions.Consult
                Me.mode = Immobilisations.Immobilisation.ModeImmo.Calcul
        End Select
    End Sub

    Private Sub InitGUI(ByVal drv As DataRowView)
        Me.TabControl1.SelectedTab = Me.DonneesTabPage

        'Onglet cession
        If Not (Me.action = Actions.Cession OrElse Not IsDBNull(drv("IDtCess"))) Then
            Me.CessionGroupBox.Visible = False
            Me.PlusValueGroupBox.Visible = False
        End If

        'Cadre forfait
        Me.ForfGroupBox.Visible = (Me.mode = Immobilisations.Immobilisation.ModeImmo.PassageAuReel OrElse Not IsDBNull(drv("IDtForf"))) And Not Me.CessionGroupBox.Visible
        Me.DureeNumericUpDown.Enabled = Not Me.ForfGroupBox.Visible

        'Cadre limites
        If Convert.ToString(drv("ITypAmt")) = "D" Then
            Me.LimAmtGroupBox.Visible = True
            Me.AmtExTotTextBox.ReadOnly = False
        Else
            Me.LimAmtGroupBox.Visible = False
            Me.AmtExTotTextBox.ReadOnly = True
        End If
        'S'il y a eu cession
        If (Me.action = Actions.Modif Or Me.action = Actions.Consult) And IsDBNull(drv("IDureeResid")) Then
            Me.AmtExTotTextBox.ReadOnly = True
        End If

        Me.SitDebExGroupBox.Enabled = (Me.mode = Immobilisations.Immobilisation.ModeImmo.SaisieDonneesAvecAmortAnt)

        If Me.action = Actions.Consult Then
            Me.Text = "Consultation d'une immobilisation"
            Me.IdentificationGroupBox.Enabled = False
            Me.AcqGroupBox.Enabled = False
            Me.AmortGroupBox.Enabled = False
            Me.ForfGroupBox.Enabled = False
            Me.SitDebExGroupBox.Enabled = False
            Me.SitFinExGroupBox.Enabled = False
            Me.CessionGroupBox.Enabled = False
        ElseIf Me.action = Actions.Modif Then
            Me.Text = "Modification d'une immobilisation"
        ElseIf Me.action = Actions.Cession Then
            Me.Text = "Cession d'une immobilisation"
            Me.IdentificationGroupBox.Enabled = False
            Me.AcqGroupBox.Enabled = False
            Me.AmortGroupBox.Enabled = False
            Me.ForfGroupBox.Enabled = False
            Me.SitDebExGroupBox.Enabled = False
            Me.SitFinExGroupBox.Enabled = False
            Me.CessionGroupBox.Enabled = True
        Else
            Select Case Me.mode
                Case Immobilisations.Immobilisation.ModeImmo.Acquisition : Me.Text = "Acquisition d'une nouvelle immobilisation dans l'exercice"
                Case Immobilisations.Immobilisation.ModeImmo.SaisieDonneesSansAmortAnt : Me.Text = "Saisie d'une immobilisation sans connaître les amortissements antérieurs"
                Case Immobilisations.Immobilisation.ModeImmo.SaisieDonneesAvecAmortAnt : Me.Text = "Saisie d'une immobilisation en connaissant les amortissements antérieurs"
                Case Immobilisations.Immobilisation.ModeImmo.PassageAuReel : Me.Text = "Saisie d'une immobilisation lors du passage au réel de l'exploitation"
            End Select
        End If

        'Limitation des dates
        If Me.action = Actions.Creation Or Me.action = Actions.Modif Then
            Select Case Me.mode
                Case Immobilisations.Immobilisation.ModeImmo.Acquisition
                    With Me.DateAcquisDateTimePicker
                        .MinDate = My.Dossier.Principal.DateDebutEx
                        .MaxDate = My.Dossier.Principal.DateFinEx
                    End With
                Case Immobilisations.Immobilisation.ModeImmo.PassageAuReel, Immobilisations.Immobilisation.ModeImmo.SaisieDonneesAvecAmortAnt, Immobilisations.Immobilisation.ModeImmo.SaisieDonneesSansAmortAnt
                    With Me.DateAcquisDateTimePicker
                        .MinDate = New Date(1900, 1, 1)
                        .MaxDate = My.Dossier.Principal.DateDebutEx
                    End With
            End Select
        ElseIf Me.action = Actions.Cession Then
            With Me.DtCessDateTimePicker
                '.MinDate = Me._Dossiers.DDtDebEx.GetValueOrDefault()
                '.MaxDate = Me._Dossiers.DDtFinEx.GetValueOrDefault()
            End With
        End If

        Me.SelectNextControl(Me, True, True, True, True)
    End Sub

    Private Function CalculerDonnees() As Boolean
        If Not loaded Then Return False
        If Me.BindingContext(dv).Position < 0 Then Return False

        EnregistrerLigne()

        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
        Dim ev As New System.ComponentModel.CancelEventArgs
        Dim immo As New Immobilisations.Immobilisation(Me.mode)

        immo.VerifSaisie(drv, Me.mode, ev)

        If ev.Cancel Then Return False

        immo.CalculerDonneesAmort(drv)

        CType(Me.BindingContext(dv), CurrencyManager).Refresh()

        Return True
    End Function

    Private Sub EnregistrerDonnees()
        EnregistrerDonnees(CType(Me.BindingContext(dv).Current, DataRowView))
    End Sub

    Private Sub EnregistrerDonnees(ByVal drv As DataRowView)
        'Merge les données
        Dim dr As DataRow = drv.Row

        If dr.RowState = DataRowState.Added Then
            Me.ImmobilisationsDataSet.Immobilisations.ImportRow(dr)
        ElseIf dr.RowState = DataRowState.Modified Then
            Dim drDest As DataRow = Me.idImmo.Find(Me.ImmobilisationsDataSet)
            CopyRow(dr, drDest)
        End If

        'MAJ la BDD
        Try
            Using immobilisationsTA As New ImmobilisationsDataSetTableAdapters.ImmobilisationsTableAdapter
                immobilisationsTA.Update(Me.ImmobilisationsDataSet)
            End Using

            'With CType(FrMDI.DossierEnCours.LstDtA("Immobilisations"), OleDb.OleDbDataAdapter)
            '    .Update(FrMDI.DossierEnCours.ds)
            'End With
        Catch ex As DBConcurrencyException
        End Try

        Me.ImmobilisationsDataSet.Immobilisations.AcceptChanges()
        'FrMDI.DossierEnCours.ds.Tables("Immobilisations").AcceptChanges()

        dr.AcceptChanges()
    End Sub
#End Region

#Region "Databinding"
    Private Sub Databinding()
        If Me.CompteComboBox.DataSource Is Nothing Then
            'CONFIGURATION DES COMBO COMPTE ET ACTI
            dvCpt = New DataView(Me.ImmobilisationsDataSet.Comptes, "(CCpt>='20' AND CCpt<'30') OR (CCpt LIKE '13*')", "CCpt", DataViewRowState.CurrentRows)
            With Me.CompteComboBox
                .DropDownWidth = 300
                .DataSource = dvCpt
                .DisplayMember = "CDisplay"
                .ValueMember = "CCpt"
            End With
        End If

        If Me.ActiviteComboBox.DataSource Is Nothing Then
            dvActi = New DataView(Me.ImmobilisationsDataSet.PlanComptable, "1=0", "PlCpt,PlActi", DataViewRowState.CurrentRows)
            With Me.ActiviteComboBox
                .DataSource = dvActi
                .DisplayMember = "PlActi"
                .ValueMember = "PlActi"
            End With
            AddHandler Me.BindingContext(dvCpt).PositionChanged, AddressOf ComptesPositionChanged
        End If

        'DATABINDING ET CONFIG DES CONTROLES
        'Identification
        Me.CompteComboBox.DataBindings.Clear()
        Me.CompteComboBox.DataBindings.Add("SelectedValue", dv, "ICpt")
        Me.ActiviteComboBox.DataBindings.Clear()
        Me.ActiviteComboBox.DataBindings.Add("SelectedValue", dv, "IActi")
        ConfigDec(Me.OrdreNumericUpDown, "IOrdre")
        ConfigNullableInt(Me.CompoNumericUpDown, "INCompo")
        Me.LibTextBox.DataBindings.Clear()
        Me.LibTextBox.DataBindings.Add("Text", dv, "ILib")
        'Acquisition
        ConfigNullableDate(Me.DateAcquisDateTimePicker, "IDtAcquis")
        ConfigCurrency(Me.ValAcquisTextBox, "IValAcquis")
        ConfigCurrency(Me.ValVenaleTextBox, "IValVenale")
        ConfigCurrency(Me.MtTVATextBox, "ITva")
        'Passage au réeel
        ConfigNullableDate(Me.DtForfDateTimePicker, "IDtForf")
        ConfigCurrency(Me.ValForfTextBox, "IValForf")
        ConfigNullableInt(Me.DureeRestNumericUpDown, "IDureeRest")
        'Cession
        ConfigNullableDate(Me.DtCessDateTimePicker, "IDtCess")
        ConfigCurrency(Me.ValCessTextBox, "IValCess")
        'Amortissement
        ConfigNullableInt(Me.DureeNumericUpDown, "IDuree")
        ConfigNullableDec(Me.CoefDTextBox, "ICoeff", "Text")
        'Résultats
        ConfigCurrency(Me.AmtCumTotTextBox, "IAmtCumTot")
        ConfigNullableInt(Me.AnnDDebTextBox, "IAnnDDeb", "Text")
        ConfigCurrency(Me.AmtExTotTextBox, "IAmtExTot")
        ConfigCurrency(Me.AmtExMaxTextBox, "IAmtExMax")
        ConfigCurrency(Me.AmtExMinTextBox, "IAmtExMin")
        ConfigCurrency(Me.ValNetFiscTextBox, "IValNetFisc")
        ConfigCurrency(Me.ValResidTextBox, "IValResid")
        ConfigNullableInt(Me.DureeResidTextBox, "IDureeResid", "Text")
        ConfigCurrency(Me.PlusValCtTextBox, "IPlusValCt")
        ConfigCurrency(Me.PlusValLtTextBox, "IPlusValLg")

        RemoveHandler Me.BindingContext(dv).PositionChanged, AddressOf DatasourcePositionChanged
        AddHandler Me.BindingContext(dv).PositionChanged, AddressOf DatasourcePositionChanged

        DatasourcePositionChanged(Nothing, Nothing)
        ComptesPositionChanged(Nothing, Nothing)
    End Sub

    Private Sub EnregistrerLigne()
        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
        'Libs
        Dim tx As String = Me.ObsTextBox.Text.Replace(vbCrLf, " ").Replace("  ", " ")
        drv("ILib2") = Microsoft.VisualBasic.Mid(tx, 1, 15)
        drv("ILib3") = Microsoft.VisualBasic.Mid(tx, 16, 20)
        drv("ILib4") = Microsoft.VisualBasic.Mid(tx, 36, 20)
        'Amort
        drv("ITypAmt") = IIf(Me.AmortDRadioButton.Checked, "D", "L")
        If Me.AmortDRadioButton.Checked Then
            drv("IDerogatoire") = IIf(Me.DerogCheckBox.Checked, "O", "N")
        Else
            drv("IDerogatoire") = ""
        End If
    End Sub

    Private Sub ComptesPositionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Me.BindingContext(dvCpt).Position >= 0 Then
            dvActi = CType(Me.BindingContext(dvCpt).Current, DataRowView).CreateChildView("ComptesPlanComptable")
            Me.ActiviteComboBox.DataSource = dvActi

            If dvActi.Count > 0 Then
                If Me.BindingContext(dv).Position >= 0 Then
                    Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
                    If IsDBNull(drv("IActi")) Then
                        Me.ActiviteComboBox.SelectedIndex = 0
                        drv("IActi") = Me.ActiviteComboBox.SelectedValue
                    Else
                        Me.ActiviteComboBox.SelectedValue = drv("IActi")
                    End If
                Else
                    Me.ActiviteComboBox.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub DatasourcePositionChanged(ByVal sender As Object, ByVal e As EventArgs)
        If Me.BindingContext(dv).Position < 0 Then
        Else
            ChargerLigne()
        End If
    End Sub

    Private Sub ChargerLigne()
        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)

        'Libs
        Me.ObsTextBox.Text = String.Format("{0}" & vbCrLf & "{1}" & vbCrLf & "{2}", drv("ILib2"), drv("ILib3"), drv("ILib4")).Trim
        Me.ObsTextBox.SelectionStart = 0

        'Amort
        Me.AmortDRadioButton.Checked = Convert.ToString(drv("ITypAmt")) = "D"
        Me.AmortLRadioButton.Checked = Convert.ToString(drv("ITypAmt")) = "L"
        Me.CoefDTextBox.Enabled = Me.AmortDRadioButton.Checked
        Me.DerogCheckBox.Enabled = Me.AmortDRadioButton.Checked
        Me.DerogCheckBox.Checked = Convert.ToString(drv("IDerogatoire")) = "O"
    End Sub
#End Region

#Region "Automatismes"
    Private Sub CompteComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                                    Handles CompteComboBox.SelectedIndexChanged, ActiviteComboBox.SelectedIndexChanged
        If CompteComboBox.SelectedIndex < 0 OrElse ActiviteComboBox.SelectedIndex < 0 Then Exit Sub
        If Me.BindingContext(dv).Position < 0 Then Exit Sub

        'Recalculer le nouvel ordre
        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)

        If IsDBNull(drv("ICpt")) OrElse IsDBNull(drv("IActi")) _
        OrElse CStr(drv("ICpt")) <> CStr(CompteComboBox.SelectedValue) OrElse CStr(drv("IActi")) <> CStr(ActiviteComboBox.SelectedValue) Then
            drv("ICpt") = CompteComboBox.SelectedValue
            drv("IActi") = ActiviteComboBox.SelectedValue
            If IsDBNull(drv("ICpt")) OrElse IsDBNull(drv("IActi")) Then Exit Sub

            drv("IOrdre") = Immobilisations.Immobilisation.FindNewOrdre(CStr(drv("ICpt")), CStr(drv("IActi")))

            CType(Me.BindingContext(dv), CurrencyManager).Refresh()
        End If
    End Sub

    Private Sub AmortDRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                            Handles AmortDRadioButton.CheckedChanged, AmortLRadioButton.CheckedChanged
        Me.CoefDTextBox.Enabled = Me.AmortDRadioButton.Checked
        Me.DerogCheckBox.Enabled = Me.AmortDRadioButton.Checked
        Me.LimAmtGroupBox.Visible = Me.AmortDRadioButton.Checked
        Me.AmtExTotTextBox.ReadOnly = Not Me.AmortDRadioButton.Checked
        If Not Me.AmortDRadioButton.Checked Then
            Me.DerogCheckBox.Checked = False
            Me.CoefDTextBox.Text = ""
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is Me.ResultTabPage AndAlso (Me.action <> Actions.Consult) Then
            'Recalculer les résultats
            CalculerDonnees()
            CType(Me.BindingContext(dv), CurrencyManager).Refresh()
        End If
    End Sub

    'Pour le cas de la saisie manuelle du cumul des amortissements
    Private Sub AmtCumTotTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) _
                                Handles AmtCumTotTextBox.Validated
        If Not loaded Then Exit Sub
        If Me.BindingContext(dv).Position < 0 Then Exit Sub

        Dim immo As New Immobilisations.Immobilisation(Immobilisations.Immobilisation.ModeImmo.SaisieDonneesAvecAmortAnt)

        immo.CalculerDonneesAmort(CType(Me.BindingContext(dv).Current, DataRowView))
        CType(Me.BindingContext(dv), CurrencyManager).Refresh()
    End Sub

    Private Sub AmtExTotTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles AmtExTotTextBox.Validated
        If Not loaded Then Exit Sub
        If Me.BindingContext(dv).Position < 0 Then Exit Sub

        Dim immo As New Immobilisations.Immobilisation(Immobilisations.Immobilisation.ModeImmo.Calcul)

        immo.CalculValeursResiduelles(CType(Me.BindingContext(dv).Current, DataRowView))
        CType(Me.BindingContext(dv), CurrencyManager).Refresh()
    End Sub

    Private Sub AmtExTotTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
                                    Handles AmtExTotTextBox.Validating
        If Not loaded Then Exit Sub
        If Me.BindingContext(dv).Position < 0 Then Exit Sub
        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
        Dim d As Decimal = CurrencyParse(Me.AmtExTotTextBox.Text.Trim)
        If d = Decimal.MinValue _
        OrElse d < CDec(Me.ReplaceDbNull(drv("IAmtExMin"), 0)) _
        OrElse d > CDec(Me.ReplaceDbNull(drv("IAmtExMax"), 0)) Then
            Me.AmtExTotTextBox.Text = CDec(Me.ReplaceDbNull(drv("IAmtExTot"), 0)).ToString("C2")
            e.Cancel = True
        End If
    End Sub

    Private Sub ValAcquisTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValAcquisTextBox.Validated
        If Not loaded Then Exit Sub
        If Me.BindingContext(dv).Position < 0 Then Exit Sub
        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
        drv("IValVenale") = drv("IValAcquis")
        CType(Me.BindingContext(dv), CurrencyManager).Refresh()
    End Sub

    'Contournement d'un bug sur le databinding à un NumericUpDown
    Private Sub NumericUpDown_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
                    Handles DureeNumericUpDown.Validating, CompoNumericUpDown.Validating, _
                    DureeRestNumericUpDown.Validating, OrdreNumericUpDown.Validating
        Dim d As Decimal = CType(sender, NumericUpDown).Value
    End Sub
#End Region

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If Me.BindingContext(dv).Position < 0 Then Exit Sub
        If Not CalculerDonnees() Then Exit Sub
        If MsgBox("Voulez-vous enregistrer cette immobilisation ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        EnregistrerDonnees()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub AideCoeffButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AideCoeffButton.Click
        Dim str As String = "Coefficients communéments admis : " & vbCrLf & _
                            "    - pour une durée de 3 à 4 ans : 1,25" & vbCrLf & _
                            "    - pour une durée de 5 à 6 ans : 1,75" & vbCrLf & _
                            "    - au délà : 2,25"
        MsgBox(str, MsgBoxStyle.Information)
    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        'Enregistrer l'immo en cours
        If Me.BindingContext(dv).Position < 0 Then Exit Sub
        If Not CalculerDonnees() Then Exit Sub
        If MsgBox("Voulez-vous enregistrer cette immobilisation ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        EnregistrerDonnees()
        'Charger une nouvelle immo
        loaded = False
        LoadData()
        loaded = True
    End Sub
#End Region

#Region "Link"
    Private Sub lnkMin_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles MinLinkLabel.LinkClicked
        If Me.BindingContext(dv).Position < 0 Then Exit Sub
        If Me.AmtExTotTextBox.Enabled AndAlso Not Me.AmtExTotTextBox.ReadOnly Then
            Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
            drv("IAmtExTot") = drv("IAmtExMin")
            CType(Me.BindingContext(dv), CurrencyManager).Refresh()
        End If
    End Sub

    Private Sub lnkMax_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles MaxLinkLabel.LinkClicked
        If Me.BindingContext(dv).Position < 0 Then Exit Sub
        If Me.AmtExTotTextBox.Enabled AndAlso Not Me.AmtExTotTextBox.ReadOnly Then
            Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
            drv("IAmtExTot") = drv("IAmtExMax")
            CType(Me.BindingContext(dv), CurrencyManager).Refresh()
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub CalculIValForf(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                        Handles ValAcquisTextBox.Validated, DureeRestNumericUpDown.Validated, _
                        DtForfDateTimePicker.Validated, DateAcquisDateTimePicker.Validated
        If Me.mode <> Immobilisations.Immobilisation.ModeImmo.PassageAuReel Then Exit Sub
        If Not loaded Then Exit Sub
        If Me.BindingContext(dv).Position < 0 Then Exit Sub
        Dim drv As DataRowView = CType(Me.BindingContext(dv).Current, DataRowView)
        If Not IsDBNull(drv("IValForf")) Then Exit Sub
        If IsDBNull(drv("IValAcquis")) OrElse IsDBNull(drv("IDtForf")) OrElse IsDBNull(drv("IDureeRest")) Then Exit Sub

        Dim dureeForf As Integer = Days360(CDate(drv("IDtAcquis")), CDate(drv("IDtForf")))
        Dim dureeRest As Integer = Days360(CDate(drv("IDtForf")), CDate(drv("IDtForf")).AddMonths(CInt(drv("IDureeRest"))))
        If dureeForf > 0 Or dureeRest > 0 Then
            drv("IValForf") = CDec(drv("IValAcquis")) * dureeForf / (dureeForf + dureeRest)
        Else
            drv("IValForf") = DBNull.Value
        End If
        drv("IDuree") = Microsoft.VisualBasic.DateDiff(DateInterval.Month, CDate(drv("IDtAcquis")), CDate(drv("IDtForf"))) + CInt(drv("IDureeRest"))
        CType(Me.BindingContext(dv), CurrencyManager).Refresh()
    End Sub

    Public Sub CopyRow(ByVal drSource As DataRow, ByVal drDest As DataRow)
        For Each cl As DataColumn In drSource.Table.Columns
            If Not cl.ReadOnly AndAlso Not cl.AutoIncrement Then
                If drDest.Table.Columns.Contains(cl.ColumnName) Then
                    drDest(cl.ColumnName) = drSource(cl.ColumnName)
                End If
            End If
        Next
    End Sub

    Public Function ReplaceDbNull(ByVal value As Object, ByVal replace As Object) As Object
        Return IIf(IsDBNull(value), replace, value)
    End Function
#End Region

End Class
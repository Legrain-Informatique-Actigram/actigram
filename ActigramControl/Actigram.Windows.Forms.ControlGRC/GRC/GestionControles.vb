Imports Actigram

Public Class GestionControlesBase
    Inherits System.Windows.Forms.UserControl

    Dim dv As DataView
    Dim _Table As String
    Dim _Lien As String
    Dim nNiveau1 As Integer
    'Dim offsetTop As Integer
    'Dim lbLeft As Integer
    Dim interval As Integer
    Dim lbHauteur As Integer
    Dim offsetLeft As Integer
    Dim _LiaisonDonnees As Boolean = True
    Dim WithEvents frParent As System.Windows.Forms.Form
    Dim WithEvents curMgr As CurrencyManager
    Dim _TableParam As String
    Dim _TableListeChoix As String
    Dim DefaultTxWidth As Integer
    Dim WithEvents frSelection As FrResultatRecherche
    Dim strChampsSelection As String
    Dim listChampConditionDispo As New Dictionary(Of CheckBox, String)
    Dim TypeSearch As Boolean = False
    Dim WithEvents myFrRecherche As FrRecherche
    Dim WithEvents frE As FrBase
    Dim WithEvents frP As FrBase
    Dim mySender As Object
    Dim bM As BindingManagerBase
    Dim AligneIn As Boolean = False
    Friend WithEvents flowLayout As System.Windows.Forms.FlowLayoutPanel
    Dim btWidth As Integer = 24

    Public Event ChargementFini()
    Public Event CtlTextchanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event CtlValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    Public Event CtlValidated(ByVal sender As Object, ByVal e As EventArgs)
    Public Event CtlCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event CtlClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event CtlnCleChanging(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    Public Event CtlnCleChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Event AffichenEnregistrement(ByVal strType As String, ByRef momDataset As DataSet, ByVal nEnregistrement As Object, ByRef fr As FrBase)
    Public Event AfficheNew(ByVal strType As String, ByRef momDataset As DataSet, ByVal nouveau As Boolean, ByRef fr As FrBase)
    Public Event AfficheNewPerso(ByVal sender As Object, ByVal strType As String)

    Public Event LancerRecherche(ByVal sender As Object, ByVal e As EventArgs)

    Public Event MustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs)
    Public Event MustUpdateTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs)

    Protected Sub OnMustRefreshTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs)
        RaiseEvent MustRefreshTable(sender, e)
    End Sub

    Protected Sub OnMustUpdateTable(ByVal sender As Object, ByVal e As System.ComponentModel.RefreshEventArgs)
        RaiseEvent MustUpdateTable(sender, e)
    End Sub


#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du UserControl pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.flowLayout = New System.Windows.Forms.FlowLayoutPanel
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'flowLayout
        '
        Me.flowLayout.AutoSize = True
        Me.flowLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayout.Location = New System.Drawing.Point(0, 0)
        Me.flowLayout.Name = "flowLayout"
        Me.flowLayout.Size = New System.Drawing.Size(150, 150)
        Me.flowLayout.TabIndex = 0
        '
        'GestionControlesBase
        '
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.flowLayout)
        Me.MinimumSize = New System.Drawing.Size(150, 150)
        Me.Name = "GestionControlesBase"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Propriétés"

    Public Overrides Property AutoSize() As Boolean
        Get
            Return Me.flowLayout.AutoSize
        End Get
        Set(ByVal value As Boolean)
            Me.flowLayout.AutoSize = value
            MyBase.AutoSize = value
        End Set
    End Property

    Public Overloads Property AutoSizeMode() As AutoSizeMode
        Get
            Return Me.flowLayout.AutoSizeMode
        End Get
        Set(ByVal value As AutoSizeMode)
            Me.flowLayout.AutoSizeMode = value
            MyBase.AutoSizeMode = value
        End Set
    End Property

    Public Overrides Property AutoScroll() As Boolean
        Get
            Return Me.flowLayout.AutoScroll
        End Get
        Set(ByVal value As Boolean)
            Me.flowLayout.AutoScroll = value
            MyBase.AutoScroll = value
        End Set
    End Property

    Dim _dsBase As DataSet
    Public Property DsBase() As DataSet
        Get
            Return _dsBase
        End Get
        Set(ByVal value As DataSet)
            _dsBase = value
        End Set
    End Property

    Dim _FiltreAffichage As String = ""
    Public Property FiltreAffichage() As String
        Get
            Return _FiltreAffichage
        End Get
        Set(ByVal Value As String)
            _FiltreAffichage = Value
        End Set
    End Property

    Private _DroitsListe As Autorisations
    Public Property AutorisationListe() As Autorisations
        Get
            Return _DroitsListe
        End Get
        Set(ByVal Value As Autorisations)
            _DroitsListe = Value
        End Set
    End Property

    Private _AutoriseAjt As Boolean = True
    Public Property AutoriseAjt() As Boolean
        Get
            Return _AutoriseAjt
        End Get
        Set(ByVal Value As Boolean)
            _AutoriseAjt = Value
            Dim ctl As Control
            For Each ctl In Me.flowLayout.Controls
                If TypeOf ctl Is Ctl Then
                    If CType(ctl, Ctl).IsAjt = True Then
                        ctl.Enabled = _AutoriseAjt
                    End If
                End If
            Next
        End Set
    End Property

    Private _AutoriseSuppr As Boolean = True
    Public Property AutoriseSuppr() As Boolean
        Get
            Return _AutoriseSuppr
        End Get
        Set(ByVal Value As Boolean)
            _AutoriseSuppr = Value
            Dim ctl As Control
            For Each ctl In Me.flowLayout.Controls
                If TypeOf ctl Is Ctl Then
                    If CType(ctl, Ctl).IsSuppr = True Then
                        ctl.Enabled = _AutoriseSuppr
                    End If
                End If
            Next
        End Set
    End Property

    Private _AutoriseModif As Boolean = True
    Public Property AutoriseModif() As Boolean
        Get
            Return _AutoriseModif
        End Get
        Set(ByVal Value As Boolean)
            _AutoriseModif = Value
            'Me.Enabled = _AutoriseModif
            Dim ctl As Control
            For Each ctl In Me.flowLayout.Controls
                If TypeOf ctl Is Ctl Then
                    If CType(ctl, Ctl).IsModif = True Then
                        If TypeOf ctl Is TxCtl Then
                            If CType(ctl, TxCtl).Multiline = True Then
                                If _AutoriseModif = False Then
                                    CType(ctl, Ctl).StopSaisiAutorisation = True
                                Else
                                    CType(ctl, Ctl).StopSaisiAutorisation = False
                                End If
                            Else
                                ctl.Enabled = _AutoriseModif
                            End If
                        Else
                            ctl.Enabled = _AutoriseModif
                        End If
                    End If
                End If
            Next
        End Set
    End Property

    Dim _Autorisations As String = ""
    Public Property Autorisations() As String
        Get
            Return _Autorisations
        End Get
        Set(ByVal Value As String)
            _Autorisations = Value
        End Set
    End Property

    Public Property TypeRecherche() As Boolean
        Get
            Return TypeSearch
        End Get
        Set(ByVal Value As Boolean)
            TypeSearch = Value
        End Set
    End Property

    Public Property LiaisonDonnees() As Boolean
        Get
            Return _LiaisonDonnees
        End Get
        Set(ByVal Value As Boolean)
            _LiaisonDonnees = Value
        End Set
    End Property

    Public Property NuméroNiveau1() As Integer
        Get
            Return nNiveau1
        End Get
        Set(ByVal Value As Integer)
            nNiveau1 = Value
        End Set
    End Property

    Public Property TableParam() As String
        Get
            Return _TableParam
        End Get
        Set(ByVal Value As String)
            _TableParam = Value
        End Set
    End Property

    Public Property TableListeChoix() As String
        Get
            Return _TableListeChoix
        End Get
        Set(ByVal Value As String)
            _TableListeChoix = Value
        End Set
    End Property

    Public Property DataSource() As DataView
        Get
            Return dv
        End Get
        Set(ByVal Value As DataView)
            dv = Value
            If Value IsNot Nothing Then
                DsBase = Value.Table.DataSet
            End If
        End Set
    End Property

    Public Property LargeurText() As Integer
        Get
            Return DefaultTxWidth
        End Get
        Set(ByVal Value As Integer)
            DefaultTxWidth = Value
        End Set
    End Property

    Public Property Table() As String
        Get
            Return _Table
        End Get
        Set(ByVal Value As String)
            _Table = Value
        End Set
    End Property

    Private _nomTableConfig As String
    Public Property NomTableConfig() As String
        Get
            Return _nomTableConfig
        End Get
        Set(ByVal value As String)
            _nomTableConfig = value
        End Set
    End Property

    Public Property Lien() As String
        Get
            Return _Lien
        End Get
        Set(ByVal Value As String)
            _Lien = Value
        End Set
    End Property

    Public Property Label1Top() As Integer
        Get
            Return Me.flowLayout.Padding.Top
        End Get
        Set(ByVal Value As Integer)
            With Me.flowLayout.Padding
                Me.flowLayout.Padding = New Padding(.Left, Value, .Right, .Bottom)
            End With
        End Set
    End Property

    Public Property LabelLeft() As Integer
        Get
            Return Me.flowLayout.Padding.Left
        End Get
        Set(ByVal Value As Integer)
            With Me.flowLayout.Padding
                Me.flowLayout.Padding = New Padding(Value, .Top, .Right, .Bottom)
            End With
        End Set
    End Property

    Public Property LigneIntervale() As Integer
        Get
            Return interval
        End Get
        Set(ByVal Value As Integer)
            interval = Value
        End Set
    End Property

    Public Property LigneHauteur() As Integer
        Get
            Return lbHauteur
        End Get
        Set(ByVal Value As Integer)
            lbHauteur = Value
        End Set
    End Property

    Public Property TexteLeft() As Integer
        Get
            Return offsetLeft
        End Get
        Set(ByVal Value As Integer)
            offsetLeft = Value
        End Set
    End Property

#End Region

#Region " Event Raisers "
    Private Sub OnCtlEvValidating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        RaiseEvent CtlValidating(sender, e)
    End Sub

    Private Sub OnCtlEvValidated(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf sender Is ComboBox Then
            'Quand on supprime à la main la valeur d'un combo, le SelectedValueChanged ne se déclenche pas
            'donc il faut forcer la MAJ du binding
            Dim cb As ComboBox = CType(sender, ComboBox)
            If cb.SelectedIndex < 0 AndAlso cb.DataBindings("SelectedValue") IsNot Nothing Then
                cb.DataBindings("SelectedValue").WriteValue()
            End If
        End If
        RaiseEvent CtlValidated(sender, e)
    End Sub

    Private Sub OnCtlEvTextchanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent CtlTextchanged(sender, e)
    End Sub

    Private Sub OnCtlEvCheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent CtlCheckedChanged(sender, e)
    End Sub

    Private Sub OnCtlEvClick(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent CtlClick(sender, e)
    End Sub

    Private Sub OnCtlEvnCleChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent CtlnCleChanged(sender, e)
    End Sub
#End Region

    Private Sub PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.ResetErreur()
    End Sub

    Private Sub DataNavMove(ByVal sender As Object, ByVal e As EventArgs) Handles curMgr.CurrentChanged
        Me.BindingContext(dv).Position = curMgr.Position
        'If _Table.IndexOf(strTable) <> 0 Then
        '    With Me.BindingContext(ds, strTable)
        '        .EndCurrentEdit()
        '        .Position = intPosition
        '    End With
        'End If
        Me.ResetErreur()
    End Sub

    'Public Sub SetDataSource(ByRef DataSource As DataSet)
    '    ds = DataSource
    '    DsBase = DataSource
    'End Sub

    Public Sub SetDataSource(ByRef DataSource As DataView)
        dv = DataSource
        DsBase = DataSource.Table.DataSet
    End Sub

    Public Sub SetCurrencyManager(ByRef cm As CurrencyManager)
        curMgr = cm
    End Sub

    Private Sub GestionControles_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frParent = Me.ParentForm
    End Sub

#Region "Converters"
    Private Sub StringToNumeric(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs)
        If Convert.ToString(e.Value) = "" Then
            e.Value = DBNull.Value
        End If
    End Sub

    Private Sub StringToDt(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs)
        If Not e.DesiredType Is GetType(Date) Then
            Exit Sub
        End If
        If Convert.ToString(e.Value) = "" Then
            e.Value = DBNull.Value
        Else
            e.Value = Date.Parse(Convert.ToString(e.Value))
        End If
    End Sub

    Private Sub DtToString(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs)
        If Not e.DesiredType Is GetType(String) Then
            Exit Sub
        End If
        If IsDBNull(e.Value) = True Then
            e.Value = ""
        Else
            e.Value = CType(e.Value, Date).ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub DtTimeToString(ByVal sender As Object, ByVal e As System.Windows.Forms.ConvertEventArgs)
        If Not e.DesiredType Is GetType(String) Then
            Exit Sub
        End If
        If IsDBNull(e.Value) = True Then
            e.Value = ""
        Else
            e.Value = CType(e.Value, Date).ToString("hh:mm")
        End If
    End Sub
#End Region

#Region "Event Handlers"
    Private Sub Ctl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Right Then
            If TypeOf sender Is TextBox Then
                Dim nNewPosition As Integer = CType(sender, TextBox).Text.IndexOf("...", CType(sender, TextBox).SelectionStart)
                If nNewPosition >= 0 Then
                    e.Handled = True
                    CType(sender, TextBox).SelectionStart = nNewPosition
                    CType(sender, TextBox).SelectionLength = 3
                End If
            ElseIf TypeOf sender Is ComboBox Then
                Dim nNewPosition As Integer = CType(sender, ComboBox).Text.IndexOf("...", CType(sender, ComboBox).SelectionStart)
                If nNewPosition >= 0 Then
                    e.Handled = True
                    CType(sender, ComboBox).SelectionStart = nNewPosition
                    CType(sender, ComboBox).SelectionLength = 3
                End If
            End If
        End If
    End Sub

    Private Sub Ctl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Me.TypeRecherche = False Then
            If Not TypeOf sender Is TxLiaison Then
                '* Databindings 0 = Text sauf pour les combobox
                Dim datasource As Object = CType(sender, Control).DataBindings(0).DataSource
                Dim dataview As DataView
                If TypeOf datasource Is BindingSource Then
                    dataview = CType(CType(datasource, BindingSource).List, DataView)
                ElseIf TypeOf datasource Is DataView Then
                    dataview = CType(datasource, DataView)
                Else : Exit Sub
                End If
                If dataview.Table.Columns(CType(sender, Control).DataBindings(0).BindingMemberInfo.BindingField).DataType.IsValueType = True Then
                    If e.KeyChar = ","c Or e.KeyChar = "."c Then
                        CType(sender, TextBox).SelectedText = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
                        e.Handled = True
                    End If
                End If
            End If
        End If

        If e.KeyChar = "€" Then
            If TypeOf sender Is TextBox Then
                CType(sender, TextBox).SelectedText = "E"
                e.Handled = True
            End If
            If TypeOf sender Is ComboBox Then
                CType(sender, ComboBox).SelectedText = "E"
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Cb_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            AfficheSelection(sender, New EventArgs)
        End If
    End Sub

    Dim ptMouse As Point
    Private Sub CtlCbDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        If ptMouse.X = e.X And ptMouse.Y = e.Y Then
            AfficheSelection(sender, New EventArgs)
        Else
            ptMouse = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub BtListeChoix_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Dim dvLstDeroulante As New DataView(Me.DsBase.Tables(Me._TableListeChoix), "NomChoix='" & CType(sender, BtCtl).LstNomChoix & "'", "nOrdreValeur", DataViewRowState.CurrentRows)
        'Dim frLst As FrGestionLstChoix
        'If Not _DroitsListe Is Nothing Then
        '    frLst = New FrGestionLstChoix(dvLstDeroulante, CType(sender, BtCtl), _DroitsListe)
        'Else
        '    frLst = New FrGestionLstChoix(dvLstDeroulante, CType(sender, BtCtl))
        'End If
        'frLst.Owner = Me.FindForm
        'frLst.Show()
        Dim fr As New FrListeChoix
        fr.Datasource = Me.DsBase.Tables(Me._TableListeChoix)
        fr.NomChoix = CType(sender, BtCtl).LstNomChoix
        If _DroitsListe IsNot Nothing Then fr.Autorisations = _DroitsListe
        fr.Owner = Me.FindForm
        fr.Tag = sender
        AddHandler fr.FormClosed, AddressOf FrListeChoix_Closed
        fr.Show()
    End Sub

    Private Sub FrListeChoix_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If e.CloseReason = CloseReason.UserClosing Or e.CloseReason = CloseReason.None Then
            If CType(sender, Form).DialogResult = DialogResult.OK Then
                Dim bt As BtCtl = CType(CType(sender, Form).Tag, BtCtl)
                If bt.CbLie IsNot Nothing Then
                    With CType(bt.CbLie, CbCtl)
                        .BeginUpdate()
                        .Items.Clear()
                        Dim strFiltreTmp As String = String.Format("NomChoix='{0}'", .NomListeChoix)
                        If .ChampsFiltre.Length > 0 Then
                            If Me.BindingContext(dv).Current.GetType.Name <> "DataViewManagerListItemTypeDescriptor" Then
                                strFiltreTmp &= String.Format(" And ValeurParent='{0}'", CType(Me.BindingContext(dv).Current, DataRowView).Item(.ChampsFiltre))
                            End If
                        End If
                        For Each rwILstChoix As DataRow In DsBase.Tables(_TableListeChoix).Select(strFiltreTmp)
                            If Not rwILstChoix.IsNull("Valeur") Then
                                .Items.Add(Convert.ToString(rwILstChoix("Valeur")))
                            End If
                        Next
                        .EndUpdate()
                    End With
                End If
                RaiseEvent MustUpdateTable(Me, New System.ComponentModel.RefreshEventArgs("ListeChoix"))
            End If
        End If
    End Sub

    Private Sub BtWeb_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim uri As New Uri(CType(CType(sender, Control).Tag, Control).Text)
            Process.Start(uri.ToString)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub Ctl_ClickRecherche(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent LancerRecherche(sender, e)
    End Sub

    Private Sub BtChemin_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpBox As New OpenFileDialog
        If OpBox.ShowDialog = DialogResult.OK Then
            CType(CType(sender, Control).Tag, Control).Text = OpBox.FileName
        End If
    End Sub

    Private Sub BtMail_Click(ByVal sender As Object, ByVal e As EventArgs)
        Process.Start(String.Format("mailto://{0}", CType(CType(sender, Control).Tag, Control).Text))
        'Dim FreMail As New FrMail(CType(CType(sender, Control).Tag, Control).Text, "lcaffe@actigram.com", CType(CType(CType(CType(CType(CType(sender, Control).Tag, GRC.TxCtl).DataBindings(0), System.Windows.Forms.Binding).BindingManagerBase, System.Windows.Forms.BindingManagerBase).Current, Object), System.Data.DataRowView))
        'FreMail.Show()
    End Sub

    Private Sub CbCtl_DropDown(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf sender Is CbCtl Then
            Dim cb As CbCtl
            cb = CType(sender, CbCtl)

            Dim rwLstChoix() As DataRow
            Dim rwILstChoix As DataRow
            Dim strFiltreTmp As String = ""
            strFiltreTmp = "NomChoix='" & cb.NomListeChoix & "'"
            If cb.ChampsFiltre.Length > 0 Then
                If Me.BindingContext(dv).Current.GetType.Name <> "DataViewManagerListItemTypeDescriptor" Then
                    strFiltreTmp += " And ValeurParent='" & Convert.ToString(CType(Me.BindingContext(dv).Current, DataRowView).Item(cb.ChampsFiltre)) & "'"
                End If
            End If

            rwLstChoix = DsBase.Tables(_TableListeChoix).Select(strFiltreTmp)
            cb.Items.Clear()

            For Each rwILstChoix In rwLstChoix
                If Not rwILstChoix.Item("Valeur") Is DBNull.Value Then
                    cb.Items.Add(CType(rwILstChoix.Item("Valeur"), String))
                End If
            Next
        End If

    End Sub

    Private Sub CbRecherche_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim cb As ComboBox = CType(sender, ComboBox)
        If cb.Text = "Période" Or cb.Text = "Fourchette" Then
            If TypeOf cb.Tag Is Control Then
                Dim frS As New FrPeriode(CType(cb.Tag, Control))
                frS.StartPosition = FormStartPosition.CenterParent
                If cb.Text = "Période" Then
                    frS.Type = "Date"
                End If
                If cb.Text = "Fourchette" Then
                    frS.Type = "Nombre"
                End If
                frS.ShowDialog()
            End If
        End If
    End Sub

    Private Sub StopSaisie_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If (Not Me._AutoriseModif) OrElse CType(sender, Ctl).StopSaisiAutorisation OrElse CType(sender, Ctl).StopSaisi Then
            e.Handled = True
        End If
    End Sub

    Private Sub StopSaisie_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If Not Me._AutoriseModif OrElse CType(sender, Ctl).StopSaisiAutorisation OrElse CType(sender, Ctl).StopSaisi Then
            'On permet juste le haut et le bas sur les combos pour passer d'une valeur à l'autre
            If TypeOf sender Is CbCtl Then
                If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                    Exit Sub
                End If
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub SupprimerAffectation(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Back Or e.KeyCode = Keys.Delete Then
            If Me.AutoriseModif = True Then
                If TypeOf sender Is TxLiaison Then
                    Dim tx As TxLiaison
                    tx = CType(sender, TxLiaison)
                    If Me.LiaisonDonnees = True Then
                        tx.DataBindings("champs").BindingManagerBase.EndCurrentEdit()
                        CType(tx.DataBindings("Champs").BindingManagerBase.Current, DataRowView).Item(tx.DataBindings("Champs").BindingMemberInfo.BindingField) = DBNull.Value
                        tx.DataBindings("champs").BindingManagerBase.EndCurrentEdit()
                    Else
                        tx.Champs = ""
                    End If
                    e.Handled = True
                End If
            End If
        End If
    End Sub
#End Region

#Region "Utils pour création des contrôles"
    Private Sub PositionControl(ByVal ctl As Control, ByVal drChamp As DataRow, ByVal lb As Label, ByVal absolutePosition As Boolean, ByVal offsetTopAdjust As Integer)
        With ctl
            .Left = offsetLeft
            .Top = lb.Top
            If TypeOf ctl Is ComboBox Then
                lb.Height = .Height + 2
            Else
                .Height = lb.Height
            End If
            If absolutePosition Then
                If Not IsDBNull(drChamp("TX")) Then .Left = CInt(drChamp("TX"))
                If Not IsDBNull(drChamp("TY")) Then .Top = offsetTopAdjust + CInt(drChamp("TY"))
                If Not IsDBNull(drChamp("TW")) Then .Width = CInt(drChamp("TW"))
                If Not IsDBNull(drChamp("TH")) Then .Height = CInt(drChamp("TH"))
            End If
        End With
    End Sub

    Private Function CreateLabel(ByVal posAbsolute As Boolean, ByVal drChamp As DataRow, ByVal offsetTopAdjust As Integer) As Label
        Dim lb As New Label
        With lb
            .Text = Convert.ToString(drChamp("Libelle"))
            '.AutoSize = True
            '.Left = lbLeft
            '.Top = offsetTop
            .Width = offsetLeft - Me.LabelLeft - interval
            If CBool(drChamp("MultiLine")) Then
                .Height = lbHauteur * CInt(IIf(IsDBNull(drChamp("HauteurMultiline")), 3, drChamp("HauteurMultiline")))
            Else
                .Height = lbHauteur
            End If
            .TextAlign = ContentAlignment.MiddleLeft

            If posAbsolute Then
                If Not IsDBNull(drChamp("LX")) Then
                    '.Left = CInt(drChamp("LX"))
                    If IsDBNull(drChamp("GroupeDispo")) Then
                        With Me.flowLayout
                            If .Controls.Count > 0 Then
                                .SetFlowBreak(.Controls(.Controls.Count - 1), False)
                            End If
                        End With
                    Else
                        Dim gb As GroupBox = TrouverGroupBox(Convert.ToString(drChamp("GroupeDispo")))
                        Dim pos As Integer = Me.flowLayout.Controls.GetChildIndex(gb)
                        If pos > 0 Then
                            With Me.flowLayout
                                .SetFlowBreak(.Controls(pos - 1), False)
                            End With
                        End If
                    End If
                End If
                If Not IsDBNull(drChamp("LY")) Then .Top = offsetTopAdjust + CInt(drChamp("LY"))
                If Not IsDBNull(drChamp("LW")) Then .Width = CInt(drChamp("LW"))
                If Not IsDBNull(drChamp("LH")) Then .Height = CInt(drChamp("LH"))
            End If
        End With
        Return lb
    End Function

    Private Sub ConfigDatabinding(ByVal ctl As Control, ByVal prop As String, ByVal drChamp As DataRow, ByVal configMaxLength As Boolean, ByVal configFormatDateTime As Boolean)
        With ctl
            If LiaisonDonnees Then
                Dim bLien As Binding
                Dim datasource As Object
                If Me.curMgr IsNot Nothing Then
                    datasource = Me.curMgr.List
                Else
                    datasource = dv
                End If
                If _Lien <> "" Then
                    bLien = New Binding(prop, datasource, String.Format("{0}.{1}", _Lien, drChamp("Champs")))
                Else
                    bLien = New Binding(prop, datasource, Convert.ToString(drChamp("Champs")))
                End If
                .DataBindings.Add(bLien)

                Dim cl As DataColumn = DsBase.Tables(CStr(drChamp("Table"))).Columns(CStr(drChamp("Champs")))
                If configFormatDateTime Then
                    Select Case cl.DataType.ToString
                        Case "System.DateTime"
                            If Not CBool(drChamp("IsTime")) Then
                                AddHandler bLien.Format, AddressOf DtToString
                                AddHandler bLien.Parse, AddressOf StringToDt
                            Else
                                AddHandler bLien.Format, AddressOf DtTimeToString
                            End If
                        Case "System.Decimal", "System.Single", "System.Double", "System.Int16", "System.Int32", "System.Int64", "System.Byte"
                            AddHandler bLien.Parse, AddressOf StringToNumeric
                    End Select
                End If

                If configMaxLength Then
                    Dim MaxLength As Integer = 0
                    If DsBase.Tables(_TableParam).Columns.Contains("MaxLength") AndAlso Not IsDBNull(drChamp("MaxLength")) Then
                        MaxLength = CInt(drChamp("MaxLength"))
                    End If
                    If cl.MaxLength > 0 Then
                        MaxLength = Math.Min(MaxLength, cl.MaxLength)
                    End If
                    If MaxLength > 0 Then
                        If TypeOf ctl Is TextBox Then
                            CType(ctl, TextBox).MaxLength = MaxLength
                        ElseIf TypeOf ctl Is ComboBox Then
                            CType(ctl, ComboBox).MaxLength = MaxLength
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Function CreateCbRecherche(ByVal lb As Label, ByVal rwI As DataRow) As ComboBox
        Dim cbRecherche As New ComboBox
        With cbRecherche
            .TabStop = False
            .Width = 100
            lb.Width -= .Width
            .Left = lb.Left + lb.Width
            .Top = lb.Top
            .Height = lb.Height
            .Visible = True
            .DropDownStyle = ComboBoxStyle.DropDownList
            Select Case DsBase.Tables(_Table).Columns(Convert.ToString(rwI.Item("Champs"))).DataType.ToString
                Case GetType(String).ToString
                    .Items.AddRange(New String() {"Contient", "Commence par", "Fini par", "Egale à"})
                Case GetType(Date).ToString
                    .Items.AddRange(New String() {"=", ">", ">=", "<", "<=", "<>", "Période"})
                Case Else
                    .Items.AddRange(New String() {"=", ">", ">=", "<", "<=", "<>", "Fourchette"})
            End Select
            .SelectedIndex = 0
            AddHandler .SelectedIndexChanged, AddressOf CbRecherche_Click
        End With
        Return cbRecherche
    End Function

    Private Function CreateBtCtl(ByVal EcartBouton As Integer, ByVal drChamp As DataRow, ByVal ctl As Control, ByVal im As Image, ByVal onclick As EventHandler) As BtCtl
        Dim bt As New BtCtl
        With bt
            .UseVisualStyleBackColor = True
            .FlatStyle = FlatStyle.Standard
            .ImageAlign = ContentAlignment.MiddleCenter
            .TextImageRelation = TextImageRelation.Overlay
            .Image = im
            If .Image.PixelFormat = Imaging.PixelFormat.Format24bppRgb Then
                CType(.Image, Bitmap).MakeTransparent(Color.Magenta)
            End If
            .Text = ""
            '.Height = ctl.Height
            .Width = ctl.Height
            If btWidth <> -1 Then .Width = btWidth
            .Left = ctl.Left + ctl.Width + EcartBouton
            .Top = ctl.Top
            .Visible = True
            .Tag = ctl
            AddHandler .Click, onclick
        End With
        Return bt
    End Function

#End Region

#Region "Création des contrôles"
    Private Function CreateCheckBox(ByVal ctls As List(Of Control), ByVal XY As Boolean, ByVal rwI As DataRow) As CkCtl
        '* Checkbox pour les boolean
        Dim ck As New CkCtl
        With ck
            '.AutoSize = True
            .Libelle = Convert.ToString(rwI("Libelle"))
            .Tag = Convert.ToString(rwI("Champs"))
            .FlatStyle = FlatStyle.Standard
            .CheckAlign = ContentAlignment.MiddleRight
            .TextAlign = ContentAlignment.MiddleLeft
            .Height = lbHauteur
            .Width = offsetLeft - Me.LabelLeft - interval + 20
            .Text = CType(rwI.Item("Libelle"), String)
            If Not IsDBNull(rwI("TW")) Then .Width = CInt(rwI("TW"))
            If Not IsDBNull(rwI("TH")) Then .Height = CInt(rwI("TH"))
            If Not IsDBNull(rwI("TX")) AndAlso IsDBNull(rwI("GroupeDispo")) Then
                With Me.flowLayout
                    If .Controls.Count > 0 Then
                        .SetFlowBreak(.Controls(.Controls.Count - 1), False)
                    End If
                End With
            End If
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
            If Not IsDBNull(rwI("IsObligatoire")) Then .IsObligatoire = CBool(rwI("IsObligatoire"))

            If Not IsDBNull(rwI("StopSaisi")) AndAlso CBool(rwI.Item("StopSaisi")) Then
                .StopSaisi = True
                .Enabled = False
            End If

            'ck.DataBindings.Add("Checked", ds, CType(rwI.Item("Table"), String) & "." & CType(rwI.Item("Champs"), String))
            ConfigDatabinding(ck, "Checked", rwI, False, False)

            If Me.TypeRecherche Then
                .ThreeState = True
                .CheckState = CheckState.Indeterminate
            End If

        End With

        AddHandler ck.Leave, AddressOf GestionErreur
        AddHandler ck.CheckedChanged, AddressOf OnCtlEvCheckedChanged
        AddHandler ck.Click, AddressOf OnCtlEvClick

        ctls.Add(ck)

        If Not IsDBNull(rwI("ChampsConditionDispo")) AndAlso CType(rwI("ChampsConditionDispo"), String) <> "" Then
            listChampConditionDispo.Add(ck, Convert.ToString(rwI("ChampsConditionDispo")))
            AddHandler ck.CheckedChanged, AddressOf RendreDispoLstControl
        End If
        Return ck
    End Function

    Private Function TrouverGroupBox(ByVal groupeDispo As String) As GroupBox
        For Each ctl As Control In Me.flowLayout.Controls
            If TypeOf ctl Is GroupBox AndAlso CStr(ctl.Tag) = groupeDispo Then
                Return CType(ctl, GroupBox)
            End If
        Next
        'Si on a rien trouvé
        Return CreateGroupBox(groupeDispo)
    End Function

    Private Function CreateGroupBox(ByVal groupeDispo As String) As GroupBox
        Dim gb As New GroupBox
        With gb
            '.Left = ck.Left - CInt(interval / 2)
            '.Top = ck.Top - CInt(interval / 2) - 6
            '.Height = ck.Height + interval + 6
            '.Width = Me.LargeurText + (Me.TexteLeft - Me.LabelLeft) + interval
            'If XY = True Then
            '    If Not IsDBNull(rwI("TW")) AndAlso Not IsDBNull(rwI("TX")) AndAlso Not IsDBNull(rwI("LX")) Then
            '        .Width = System.Math.Abs(CInt(rwI("TW")) + CInt(rwI("TX"))) - CInt(rwI("LX")) + interval
            '    End If
            'End If
            .AutoSize = True
            .AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            .Visible = True
            .FlatStyle = FlatStyle.Standard
            .Tag = groupeDispo
        End With
        Dim flow As New FlowLayoutPanel
        With flow
            .Top = gb.Padding.Top + .Margin.Top
            .Left = gb.Padding.Left + .Margin.Left
            .AutoSize = True
            .AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            .Visible = True
            '.Dock = DockStyle.Fill
        End With
        gb.Controls.Add(flow)
        Me.flowLayout.Controls.Add(gb)
        Me.flowLayout.SetFlowBreak(gb, True)
        Return gb
        'If Not IsDBNull(rwI("GroupeDispo")) Then
        'If CType(pl.Tag, String) = groupeDispo Then
        'pl.Height = ck.Top + ck.Height - pl.Top + interval
        'pl.SendToBack()
        'End If
        'End If
    End Function

    Private Function CreateCbListeChoix(ByVal ctls As List(Of Control), ByVal lb As Label, ByVal EcartBouton As Integer, ByVal XY As Boolean, ByVal drChamp As DataRow, ByVal offsetTopAdjust As Integer, ByVal cbRecherche As ComboBox) As CbCtl
        Dim strFiltreTmp As String = String.Format("NomChoix='{0}'", drChamp("ListeChoix"))
        Dim cb As New CbCtl
        With cb
            .Text = ""
            .Libelle = Convert.ToString(drChamp("Libelle"))
            .Tag = CType(drChamp("Champs"), String)

            If AligneIn Then
                .Width = DefaultTxWidth - .Height
            Else
                .Width = DefaultTxWidth
            End If

            PositionControl(cb, drChamp, lb, XY, offsetTopAdjust)

            If Not IsDBNull(drChamp("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(drChamp("NiveauAutorisation"))
            If Not IsDBNull(drChamp("IsObligatoire")) Then .IsObligatoire = CBool(drChamp("IsObligatoire"))

            If drChamp.Table.Columns.Contains("ListeChoixChampsFiltre") Then
                If Not IsDBNull(drChamp("ListeChoixChampsFiltre")) Then
                    .ChampsFiltre = Convert.ToString(drChamp("ListeChoixChampsFiltre"))
                End If
            End If

            .NomListeChoix = Convert.ToString(drChamp("ListeChoix"))

            If .ChampsFiltre.Length > 0 Then
                If Me.BindingContext(dv).Current.GetType.Name <> "DataViewManagerListItemTypeDescriptor" Then
                    strFiltreTmp &= String.Format(" And ValeurParent='{0}'", CType(Me.BindingContext(dv).Current, DataRowView).Item(.ChampsFiltre))
                End If
            End If

            For Each rwILstChoix As DataRow In DsBase.Tables(_TableListeChoix).Select(strFiltreTmp)
                If Not IsDBNull(rwILstChoix("Valeur")) Then
                    .Items.Add(Convert.ToString(rwILstChoix("Valeur")))
                End If
            Next

            ConfigDatabinding(cb, "Text", drChamp, True, False)

            AddHandler .TextChanged, AddressOf OnCtlEvTextchanged
            AddHandler .Validating, AddressOf OnCtlEvValidating
            AddHandler .Validated, AddressOf OnCtlEvValidated
            AddHandler .KeyPress, AddressOf Ctl_KeyPress
            AddHandler .KeyDown, AddressOf Ctl_KeyDown
            If .ChampsFiltre.Length > 0 Then AddHandler .DropDown, AddressOf CbCtl_DropDown
            AddHandler .ClickRecherche, AddressOf Ctl_ClickRecherche
            AddHandler .Leave, AddressOf GestionErreur
            If Not IsDBNull(drChamp("StopSaisi")) AndAlso CBool(drChamp("StopSaisi")) Then
                .StopSaisi = True
                .DropDownStyle = ComboBoxStyle.DropDownList
                'AddHandler cb.KeyDown, AddressOf StopSaisie
                'AddHandler cb.KeyPress, AddressOf StopSaisie
            End If
        End With

        ctls.Add(cb)

        'Bt Plus
        If Not Me.TypeRecherche Then
            Dim bt As BtCtl = CreateBtCtl(EcartBouton, drChamp, cb, My.Resources.plus, AddressOf BtListeChoix_Click)
            With bt
                .LstNomChoix = Convert.ToString(drChamp("ListeChoix"))
                .CbLie = cb
                .nNiveauAutorisation = cb.nNiveauAutorisation
            End With
            Me.ToolTip1.SetToolTip(bt, "Ajouter un élément dans la liste")
            ctls.Add(bt)
        End If
        Return cb
    End Function

    Private Function CreateTxRtf(ByVal ctls As List(Of Control), ByVal drChamp As DataRow, ByVal lb As Label, ByVal positionAbsolute As Boolean, ByVal offsetTop As Integer, ByVal cbRecherche As ComboBox) As TxRtf
        Dim txR As New TxRtf
        With txR
            .Libelle = Convert.ToString(drChamp("Libelle"))
            .Tag = CType(drChamp("Champs"), String)
            .AutoSize = False
            .BorderStyle = BorderStyle.Fixed3D
            .Width = DefaultTxWidth
            PositionControl(txR, drChamp, lb, positionAbsolute, offsetTop)

            If CBool(drChamp("MultiLine")) Then
                .Multiline = True
                .ScrollBars = RichTextBoxScrollBars.Vertical
                AddHandler .DoubleClick, AddressOf AfficheZoom
            End If
            If Not IsDBNull(drChamp("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(drChamp("NiveauAutorisation"))
            If Not IsDBNull(drChamp("IsObligatoire")) Then .IsObligatoire = CBool(drChamp("IsObligatoire"))

            AddHandler .KeyDown, AddressOf Ctl_KeyDown
            AddHandler .TextChanged, AddressOf OnCtlEvTextchanged
            AddHandler .Validating, AddressOf OnCtlEvValidating
            AddHandler .Validated, AddressOf OnCtlEvValidated
            AddHandler .KeyPress, AddressOf Ctl_KeyPress
            AddHandler .ClickRecherche, AddressOf Ctl_ClickRecherche
            AddHandler .Leave, AddressOf GestionErreur

            If Not IsDBNull(drChamp("StopSaisi")) AndAlso CBool(drChamp("StopSaisi")) Then
                AddHandler .KeyDown, AddressOf StopSaisie_KeyDown
                AddHandler .KeyPress, AddressOf StopSaisie_KeyPress
                .StopSaisi = True
            End If
        End With

        ConfigDatabinding(txR, "Rtf", drChamp, True, True)

        ctls.Add(txR)
        Return txR
    End Function

    Private Function CreateTextbox(ByVal lb As Label, ByVal absolutePosition As Boolean, ByVal drChamp As DataRow, ByVal offsetTop As Integer) As TxCtl
        Dim tx As New TxCtl
        With tx
            .Text = ""
            .AutoSize = False
            .BorderStyle = BorderStyle.Fixed3D
            PositionControl(tx, drChamp, lb, absolutePosition, offsetTop)
            If CBool(drChamp("MultiLine")) Then
                .Multiline = True
                .ScrollBars = ScrollBars.Vertical
                AddHandler .DoubleClick, AddressOf AfficheZoom
            End If
            If Not IsDBNull(drChamp("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(drChamp("NiveauAutorisation"))
            If Not IsDBNull(drChamp("IsObligatoire")) Then .IsObligatoire = CBool(drChamp("IsObligatoire"))
        End With
        Return tx
    End Function

    Private Function CreateCb(ByVal ctls As List(Of Control), ByVal lb As Label, ByVal posAbsolute As Boolean, ByVal drChamp As DataRow, ByVal offsetTopAdjust As Integer, ByVal strType As String) As CbCtl
        Dim cb As New CbCtl
        With cb
            .Libelle = Convert.ToString(drChamp("Libelle"))
            .DropDownStyle = ComboBoxStyle.DropDownList

            'PositionControl(cb, drChamp, lb, posAbsolute, offsetTopAdjust)
            If strType.ToLower <> "n" Then
                If posAbsolute AndAlso Not IsDBNull(drChamp("TW")) Then
                    .Width = CInt(drChamp("TW"))
                ElseIf AligneIn Then
                    .Width = DefaultTxWidth - 2 * lb.Height + 2
                Else
                    .Width = DefaultTxWidth
                End If
            End If
            If Not IsDBNull(drChamp("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(drChamp("NiveauAutorisation"))
            If Not IsDBNull(drChamp("IsObligatoire")) Then .IsObligatoire = CBool(drChamp("IsObligatoire"))

            .ChampsFiltre = Convert.ToString(drChamp("FiltreType"))
            If drChamp.Table.Columns.Contains("TableListeChoixTri") Then .ChampsTri = Convert.ToString(drChamp("TableListeChoixTri"))

            If drChamp.Table.DataSet.Tables.Contains(Convert.ToString(drChamp("TableListeChoix"))) Then
                Dim rws() As DataRow = drChamp.Table.DataSet.Tables(Convert.ToString(drChamp("TableListeChoix"))).Select(.ChampsFiltre, .ChampsTri)
                Dim cl As DataColumn = DsBase.Tables(CStr(drChamp("Table"))).Columns(CStr(drChamp("Champs")))
                If Not Me.TypeRecherche Then
                    FillCb(rws, cb, Convert.ToString(drChamp("TableListeChoixAfficheChamps")), Convert.ToString(drChamp("TableListeChoixSelectChamps")), Nothing, True, Not .IsObligatoire, , cl.DataType)
                Else
                    FillCb(rws, cb, Convert.ToString(drChamp("TableListeChoixAfficheChamps")), Convert.ToString(drChamp("TableListeChoixSelectChamps")), Nothing, True, True, "<tous>")
                End If
                '.DataSource = New DataView(drChamp.Table.DataSet.Tables(Convert.ToString(drChamp("TableListeChoix"))), strFiltre, strTri, DataViewRowState.CurrentRows)
                '.DisplayMember = Convert.ToString(drChamp("TableListeChoixAfficheChamps"))
                '.ValueMember = Convert.ToString(drChamp("TableListeChoixSelectChamps"))
            End If
            .Tag = CType(drChamp("Champs"), String)

            AddHandler .TextChanged, AddressOf OnCtlEvTextchanged
            AddHandler .Validating, AddressOf OnCtlEvValidating
            AddHandler .Validated, AddressOf OnCtlEvValidated
            AddHandler .SelectedValueChanged, AddressOf OnCtlEvnCleChanged
            AddHandler .MouseDown, AddressOf Cb_MouseDown
            AddHandler .MouseDown, AddressOf CtlCbDoubleClick
            AddHandler .KeyPress, AddressOf Ctl_KeyPress

            If Not IsDBNull(drChamp("StopSaisi")) AndAlso CBool(drChamp("StopSaisi")) Then
                .StopSaisi = True
                .DropDownStyle = ComboBoxStyle.DropDownList
                'AddHandler cb.KeyDown, AddressOf StopSaisie
                'AddHandler cb.KeyPress, AddressOf StopSaisie
            End If
        End With

        If Not Me.TypeRecherche Then ConfigDatabinding(cb, "SelectedValue", drChamp, True, False)

        ctls.Add(cb)

        'cb.BringToFront()
        If Me.TypeRecherche Then
            cb.SelectedIndex = -1
            cb.Text = ""
        End If

        Return cb
    End Function

    Private Function CreateTxLiaison(ByVal ctls As List(Of Control), ByVal lb As Label, ByVal posAbsolute As Boolean, ByVal drChamp As DataRow, ByVal offsetTop As Integer, ByRef strType As String) As TxLiaison
        If strType = "" Then strType = "txL"
        Dim txL As New TxLiaison
        With txL
            .Libelle = Convert.ToString(drChamp("Libelle"))
            .Tag = Convert.ToString(drChamp("Champs"))
            .AutoSize = False
            .Text = ""
            '.BackColor = Color.Red
            .ReadOnly = True
            .BorderStyle = BorderStyle.Fixed3D

            If AligneIn AndAlso strType.ToLower <> "n" Then
                .Width = DefaultTxWidth - 2 * lb.Height + 2
            Else
                .Width = DefaultTxWidth
            End If
            PositionControl(txL, drChamp, lb, posAbsolute, offsetTop)

            If Not IsDBNull(drChamp("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(drChamp("NiveauAutorisation"))
            If Not IsDBNull(drChamp("IsObligatoire")) Then .IsObligatoire = CBool(drChamp("IsObligatoire"))

            .TableSelection = Convert.ToString(drChamp.Item("TableListeChoix"))
            .CleSelection = Convert.ToString(drChamp.Item("TableListeChoixSelectChamps"))
            .ChampsSelection = Convert.ToString(drChamp.Item("TableListeChoixAfficheChamps"))

            ConfigDatabinding(txL, "Champs", drChamp, True, False)
            .Donnees = DsBase
            .StopSaisi = True

            AddHandler .DoubleClick, AddressOf AfficheSelection
            If strType.ToLower = "n" Then
                AddHandler .KeyDown, AddressOf StopSaisie_KeyDown
            Else
                AddHandler .KeyUp, AddressOf SupprimerAffectation
            End If
            AddHandler .TextChanged, AddressOf OnCtlEvTextchanged
            AddHandler .Validating, AddressOf OnCtlEvValidating
            AddHandler .Validated, AddressOf OnCtlEvValidated
            AddHandler .KeyPress, AddressOf Ctl_KeyPress
            AddHandler .KeyPress, AddressOf StopSaisie_KeyPress
            AddHandler .Leave, AddressOf GestionErreur
            AddHandler .ClickRecherche, AddressOf Ctl_ClickRecherche
        End With

        ctls.Add(txL)
        Return txL
    End Function
#End Region

#Region "Ajout des boutons"
    Private Sub AddBtListeChoixMultiple(ByVal ctls As List(Of Control), ByVal lb As Label, ByVal tx As TxCtl, ByVal EcartBouton As Integer, ByVal XY As Boolean, ByVal rwI As DataRow)
        Dim AfficheBtPlus As Boolean = Not (Me.TypeRecherche OrElse IsDBNull(rwI("ListeChoixMultiple")))
        Dim nbBt As Integer = CInt(IIf(AfficheBtPlus, 2, 1))

        Dim iBTH As Integer = Math.Min(lb.Height, 24)

        If XY AndAlso Not IsDBNull(rwI("TW")) Then
            tx.Width = CInt(rwI("TW"))
        ElseIf AligneIn = True Then
            tx.Width = DefaultTxWidth - iBTH * nbBt + 1
        Else
            tx.Width = DefaultTxWidth
        End If

        'Dim MaListe As New Hashtable
        Dim hashInfo As New Hashtable
        With hashInfo
            .Add("Tx", tx)
            .Add("ListeChoixMultiple", rwI("ListeChoixMultiple"))
            .Add("ListeChoixMultipleTable", rwI("ListeChoixMultipleTable"))
            .Add("ListeChoixMultipleChamps", rwI("ListeChoixMultipleChamps"))
        End With

        Dim bt As BtCtl = CreateBtCtl(EcartBouton, rwI, tx, My.Resources.Expand_large, AddressOf AfficheListeChoix)
        With bt
            .Width = iBTH
            If btWidth <> -1 Then .Width = btWidth
            '.Height = iBTH
            .Tag = hashInfo
            .IsModif = True
            .Enabled = AutoriseModif
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
        End With
        ctls.Add(bt)

        If AfficheBtPlus = True Then
            Dim btPlus As BtCtl = CreateBtCtl(EcartBouton, rwI, bt, My.Resources.plus, AddressOf BtListeChoix_Click)
            With btPlus
                '.Height = iBTH
                .Width = iBTH + 1
                If btWidth <> -1 Then .Width = btWidth
                If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
                .LstNomChoix = Convert.ToString(rwI("ListeChoixMultiple"))
            End With

            Me.ToolTip1.SetToolTip(btPlus, "Ajouter un élément dans la liste")
            ctls.Add(btPlus)
        End If
    End Sub

    Private Sub AddBtPlusListeChoix(ByVal ctls As List(Of Control), ByVal cb As CbCtl, ByVal EcartBouton As Integer, ByVal drChamp As DataRow)
        Dim MaListe As New Hashtable
        With MaListe
            .Add("TableListeChoix", drChamp("TableListeChoix"))
            .Add("TableListeChoixSelectChamps", drChamp("TableListeChoixSelectChamps"))
            .Add("Champs", drChamp("Champs"))
            .Add("ListeChoix", drChamp("ListeChoix"))
            .Add("FiltreType", drChamp("FiltreType"))
            .Add("FiltrePlus", drChamp("FiltrePlus"))
            .Add("Control", cb)
        End With

        Dim bt As BtCtl = CreateBtCtl(EcartBouton, drChamp, cb, My.Resources.plus, AddressOf AfficheNouveau)
        With bt
            .IsAjt = True
            .Enabled = AutoriseAjt
            .Tag = MaListe
            If Not IsDBNull(drChamp("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(drChamp("NiveauAutorisation"))
        End With

        Me.ToolTip1.SetToolTip(bt, "Ajouter un élément dans la liste")
        ctls.Add(bt)
    End Sub

    Private Sub AddBtCalendar(ByVal ctls As List(Of Control), ByVal tx As TxCtl, ByVal EcartBouton As Integer, ByVal rwI As DataRow)
        '* Bouton pour afficher calendrier si Date
        Dim bt As BtCtl = CreateBtCtl(EcartBouton, rwI, tx, My.Resources.calendar, AddressOf AfficheCalendrier)
        With bt
            .IsModif = True
            .Enabled = AutoriseModif
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
        End With

        Me.ToolTip1.SetToolTip(bt, "Afficher le calendrier")
        ctls.Add(bt)
    End Sub

    Private Sub AddBtWeb(ByVal ctls As List(Of Control), ByVal tx As TxCtl, ByVal EcartBouton As Integer, ByVal rwI As DataRow)
        Dim bt As BtCtl = CreateBtCtl(EcartBouton, rwI, tx, My.Resources.web, AddressOf BtWeb_Click)
        With bt
            .IsModif = True
            .Enabled = AutoriseModif
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
        End With
        Me.ToolTip1.SetToolTip(bt, "Naviguer vers")
        ctls.Add(bt)
    End Sub

    Private Sub AddBtRechEtNew(ByVal ctls As List(Of Control), ByVal tx As Control, ByVal EcartBouton As Integer, ByVal rwI As DataRow)
        Dim MaListe As New Hashtable
        With MaListe
            .Add("TableListeChoix", rwI("TableListeChoix"))
            .Add("TableListeChoixSelectChamps", rwI("TableListeChoixSelectChamps"))
            .Add("Champs", rwI("Champs"))
            .Add("ListeChoix", rwI("ListeChoix"))
            .Add("FiltreType", rwI("FiltreType"))
            .Add("FiltrePlus", rwI("FiltrePlus"))
            .Add("Control", tx)
        End With

        Dim bt As BtCtl = CreateBtCtl(EcartBouton, rwI, tx, My.Resources.search, AddressOf AfficheFormRecherche)
        With bt
            .Tag = MaListe
            .IsModif = True
            .Enabled = AutoriseModif
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
        End With

        Dim btNew As BtCtl = CreateBtCtl(EcartBouton, rwI, bt, My.Resources.new16, AddressOf AfficheNouveau)
        With btNew
            .Tag = MaListe
            .IsAjt = True
            .Enabled = AutoriseAjt
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
        End With

        With tx
            AddHandler .DoubleClick, AddressOf AfficheSelection
            AddHandler .KeyDown, AddressOf StopSaisie_KeyDown
            AddHandler .KeyPress, AddressOf StopSaisie_KeyPress
        End With
        If TypeOf tx Is Ctl Then CType(tx, Ctl).StopSaisi = True

        ctls.Add(bt)
        ctls.Add(btNew)
    End Sub

    Private Sub AddBtMail(ByVal ctls As List(Of Control), ByVal tx As TxCtl, ByVal rwI As DataRow, ByVal EcartBouton As Integer)
        Dim bt As BtCtl = CreateBtCtl(EcartBouton, rwI, tx, My.Resources.mail, AddressOf BtMail_Click)
        With bt
            .Tag = tx
            .IsModif = True
            .Enabled = AutoriseModif
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
        End With
        Me.ToolTip1.SetToolTip(bt, "Envoyer un E-mail à cette adresse")
        ctls.Add(bt)
    End Sub

    Private Sub AddBtChemin(ByVal ctls As List(Of Control), ByVal tx As TxCtl, ByVal EcartBouton As Integer, ByVal rwI As DataRow)
        Dim bt As BtCtl = CreateBtCtl(EcartBouton, rwI, tx, My.Resources.calendar, AddressOf BtChemin_Click)
        With bt
            .IsModif = True
            .Enabled = AutoriseModif
            If Not IsDBNull(rwI("NiveauAutorisation")) Then .nNiveauAutorisation = CInt(rwI("NiveauAutorisation"))
        End With
        Me.ToolTip1.SetToolTip(bt, "Ouvrir le document")
        ctls.Add(bt)
    End Sub
#End Region

    Private Sub AdaptCtlWidthForBt(ByVal ctl As Control, ByVal drChamp As DataRow, ByVal posAbsolute As Boolean, ByVal lb As Label)
        If posAbsolute AndAlso Not IsDBNull(drChamp("TW")) Then
            ctl.Width = CInt(drChamp("TW"))
        ElseIf AligneIn Then
            ctl.Width = DefaultTxWidth - lb.Height + 2
        Else
            ctl.Width = DefaultTxWidth
        End If
    End Sub

    Public Sub LoadControl(ByVal sender As Object, ByVal e As System.EventArgs) Handles frParent.Load
        'Dim gbPl As GroupBox = Nothing

        Me.flowLayout.SuspendLayout()
        'Valeurs par défaut
        'Dim EcartBouton As Integer = 1
        If lbHauteur = 0 Then lbHauteur = 20
        If _TableParam = "" Then _TableParam = "Niveau2"
        If _TableListeChoix = "" Then _TableListeChoix = "ListeChoix"
        If Me.NomTableConfig Is Nothing Then Me.NomTableConfig = Me.Table
        If DefaultTxWidth = 0 Then DefaultTxWidth = 100

        Dim posAbsolute As Boolean = (Not Me.TypeRecherche AndAlso DsBase.Tables(_TableParam).Columns.Contains("LX"))


        If Me.LiaisonDonnees Then
            'If TypeOf ds Is DataSet AndAlso _Lien = "" Then
            '    _Lien = _Table
            'End If
            If curMgr IsNot Nothing Then bM = curMgr
            If bM Is Nothing Then
                If _Lien = "" Then
                    bM = frParent.BindingContext(dv)
                Else
                    bM = frParent.BindingContext(dv, _Lien)
                End If
            End If
            If bM IsNot Nothing Then
                AddHandler bM.PositionChanged, AddressOf PositionChanged
            End If
        End If

        Dim strFiltreAffichage As String = ""
        If Me._FiltreAffichage.Length > 0 Then
            strFiltreAffichage = " And (" & Me._FiltreAffichage & ")"
        End If

        Dim rwsChamps() As DataRow
        If nNiveau1 = 0 Then
            rwsChamps = DsBase.Tables(_TableParam).Select("[Table]='" & Me.NomTableConfig & "' And nNiveau1=0 And (NpAfficherPrLien<>'" & _Lien & "' or NpAfficherPrLien Is Null)", "nNiveau2")
        Else
            rwsChamps = DsBase.Tables(_TableParam).Select("nNiveau1=" & nNiveau1, "nNiveau2")
        End If

        'Il n'y a rien à afficher
        If rwsChamps.Length = 0 Then Exit Sub

        'Dim offsetTopAdjust As Integer = 0
        For Each drChamp As DataRow In rwsChamps
            Dim Afficher As Boolean = drChamp.Table.Select(String.Format("nNiveau1={0} And nNiveau2={1} {2}", drChamp("nNiveau1"), drChamp("nNiveau2"), strFiltreAffichage)).Length > 0
            Try
                Dim strType As String = ""
                If Not Afficher Then
                    'On calcule la place en Y à rattrapper
                    'Dim nbLigne As Integer = 1
                    'If posAbsolute AndAlso Not IsDBNull(drChamp("NbLigne")) Then
                    '    nbLigne = CInt(drChamp("NbLigne"))
                    'End If
                    'offsetTopAdjust -= nbLigne * (lbHauteur + interval)
                Else
                    'Logique d'affichage
                    If (Not Me.TypeRecherche AndAlso Not CBool(drChamp("NpAfficherFormulaire"))) _
                    OrElse (Me.TypeRecherche AndAlso CBool(drChamp("AfficherFormulaireRecherche"))) Then
                        'If TypeOf ds Is DataSet Then
                        '    If _Lien = "" Then _Lien = CType(drChamp("Table"), String)
                        'End If
                        If nNiveau1 > 0 Then
                            drChamp("Table") = _Table
                            drChamp.AcceptChanges()
                        ElseIf Me.NomTableConfig <> Me.Table Then
                            drChamp("Table") = _Table
                            drChamp.AcceptChanges()
                        End If

                        If Not DsBase.Tables.Contains(CStr(drChamp("Table"))) Then Continue For
                        If Not DsBase.Tables(CStr(drChamp("Table"))).Columns.Contains(CStr(drChamp("Champs"))) Then Continue For
                        Dim dataCol As DataColumn = DsBase.Tables(CStr(drChamp("Table"))).Columns(CStr(drChamp("Champs")))
                        Dim ctls As New List(Of Control)
                        If dataCol.DataType.ToString = "System.Boolean" Then
                            'Boolean => Checkbox
                            CreateCheckBox(ctls, posAbsolute, drChamp)
                        Else
                            '* Label d'entête pour tous les contrôles sauf les checkbox (poour les boolean)
                            Dim lb As Label = CreateLabel(posAbsolute, drChamp, 0)
                            ctls.Add(lb)

                            'Eventuellement la combo avec les opérateurs de recherche
                            Dim cbRecherche As ComboBox = Nothing
                            If TypeRecherche Then
                                cbRecherche = CreateCbRecherche(lb, drChamp)
                                ctls.Add(cbRecherche)
                            End If

                            If Not IsDBNull(drChamp.Item("ListeChoix")) And IsDBNull(drChamp.Item("TableListeChoix")) Then
                                '* Combobox pour les choix multi défini dans la table ListeChoix
                                Dim cb As CbCtl = CreateCbListeChoix(ctls, lb, 0, posAbsolute, drChamp, 0, cbRecherche)
                                If Me.TypeRecherche Then cb.CbRecherche = cbRecherche
                            ElseIf Convert.ToBoolean(drChamp.Item("IsRtf")) = True Then
                                Dim txR As TxRtf = CreateTxRtf(ctls, drChamp, lb, posAbsolute, 0, cbRecherche)
                                If Me.TypeRecherche Then txR.CbRecherche = cbRecherche
                            ElseIf Not IsDBNull(drChamp("TableListeChoix")) Then
                                strType = Convert.ToString(drChamp("TableListeChoixType"))
                                Select Case strType.ToLower
                                    Case "", "n"
                                        Dim txL As TxLiaison = CreateTxLiaison(ctls, lb, posAbsolute, drChamp, 0, strType)
                                        If Me.TypeRecherche Then
                                            ctls.Remove(cbRecherche)
                                        End If
                                    Case "cb", "cbn", "cbp"
                                        Dim cb As CbCtl = CreateCb(ctls, lb, posAbsolute, drChamp, 0, strType)
                                        If Me.TypeRecherche Then
                                            ctls.Remove(cbRecherche)
                                        Else
                                            If strType.ToLower = "cbp" Then
                                                If AligneIn = True Then
                                                    cb.Width = Me.Width - lb.Height - lb.Height + 2
                                                End If
                                                AddBtPlusListeChoix(ctls, cb, 0, drChamp)
                                            ElseIf strType.ToLower = "cb" Then
                                                AddBtRechEtNew(ctls, cb, 0, drChamp)
                                            End If
                                        End If
                                End Select
                            Else
                                '* Textbox pour tous les autres contrôles
                                Dim tx As TxCtl = CreateTextbox(lb, posAbsolute, drChamp, 0)
                                ctls.Add(tx)
                                'IMPOSSIBLE ?
                                'If Not IsDBNull(drChamp("TableListeChoix")) Then
                                '    If Convert.ToString(drChamp("TableListeChoix")).Length > 0 Then
                                '        AdaptCtlWidthForBt(tx, drChamp, posAbsolute, lb)
                                '        AddBtRechEtNew(tx, EcartBouton, drChamp)
                                '    Else
                                '        If posAbsolute AndAlso Not IsDBNull(drChamp("TW")) Then
                                '            tx.Width = CInt(drChamp("TW"))
                                '        Else
                                '            tx.Width = DefaultTxWidth
                                '        End If
                                '    End If
                                'End If

                                If strType = "" Then
                                    ConfigDatabinding(tx, "Text", drChamp, True, True)
                                    With tx
                                        .Libelle = Convert.ToString(drChamp("Libelle"))
                                        .Tag = Convert.ToString(drChamp("Champs"))

                                        'Lecture seule
                                        If Not IsDBNull(drChamp("StopSaisi")) AndAlso CBool(drChamp.Item("StopSaisi")) Then
                                            AddHandler .KeyDown, AddressOf StopSaisie_KeyDown
                                            AddHandler .KeyPress, AddressOf StopSaisie_KeyPress
                                            .StopSaisi = True
                                        End If

                                        'Pas sur à quoi ca sert ?
                                        If .Multiline And Not .StopSaisi Then
                                            AddHandler .KeyDown, AddressOf StopSaisie_KeyDown
                                            AddHandler .KeyPress, AddressOf StopSaisie_KeyPress
                                        End If

                                        'Handlers
                                        AddHandler .TextChanged, AddressOf OnCtlEvTextchanged
                                        AddHandler .Validating, AddressOf OnCtlEvValidating
                                        AddHandler .Validated, AddressOf OnCtlEvValidated
                                        AddHandler .KeyDown, AddressOf Ctl_KeyDown
                                        AddHandler .KeyPress, AddressOf Ctl_KeyPress
                                        AddHandler .ClickRecherche, AddressOf Ctl_ClickRecherche
                                        AddHandler .Leave, AddressOf GestionErreur
                                    End With

                                    If Me.TypeRecherche Then
                                        'Référence croisée des contrôles
                                        cbRecherche.Tag = tx
                                        tx.CbRecherche = cbRecherche
                                    End If
                                End If
                                ctls.Add(tx)

                                If dataCol.DataType.ToString = "System.DateTime" And Convert.ToBoolean(drChamp.Item("IsTime")) = False Then
                                    'Eventuellement Retailler le tx pour avoir la place 
                                    AdaptCtlWidthForBt(tx, drChamp, posAbsolute, lb)
                                    AddBtCalendar(ctls, tx, 0, drChamp)
                                ElseIf Not IsDBNull(drChamp.Item("ListeChoixMultiple")) Or Not IsDBNull(drChamp.Item("ListeChoixMultipleTable")) Then
                                    '* Bouton pour afficher une liste de choix Multiple
                                    AddBtListeChoixMultiple(ctls, lb, tx, 0, posAbsolute, drChamp)
                                    If Not IsDBNull(drChamp("StopSaisi")) AndAlso CBool(drChamp("StopSaisi")) Then
                                        AddHandler tx.KeyDown, AddressOf StopSaisie_KeyDown
                                        AddHandler tx.KeyPress, AddressOf StopSaisie_KeyPress
                                        tx.StopSaisi = True
                                    End If
                                    If tx.Multiline And tx.StopSaisi Then
                                        AddHandler tx.KeyDown, AddressOf StopSaisie_KeyDown
                                        AddHandler tx.KeyPress, AddressOf StopSaisie_KeyPress
                                    End If
                                Else
                                    If Not Me.TypeRecherche Then
                                        'Taille du Textbox
                                        AdaptCtlWidthForBt(tx, drChamp, posAbsolute, lb)
                                        'Les boutons additionnels eventuels
                                        If Not IsDBNull(drChamp("IsAdresseWeb")) AndAlso CBool(drChamp("IsAdresseWeb")) Then
                                            AddBtWeb(ctls, tx, 0, drChamp)
                                        ElseIf Not IsDBNull(drChamp("IsMail")) AndAlso CBool(drChamp.Item("IsMail")) Then
                                            AddBtMail(ctls, tx, drChamp, 0)
                                        ElseIf drChamp.Table.Columns.Contains("IsChemin") AndAlso Not IsDBNull(drChamp("IsChemin")) AndAlso CBool(drChamp("IsChemin")) Then
                                            AddBtChemin(ctls, tx, 0, drChamp)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                        If Not IsDBNull(drChamp("GroupeDispo")) Then
                            Dim gbPl As GroupBox = TrouverGroupBox(Convert.ToString(drChamp("GroupeDispo")))
                            With CType(gbPl.Controls(0), FlowLayoutPanel)
                                .Controls.AddRange(ctls.ToArray)
                                .SetFlowBreak(ctls(ctls.Count - 1), True)
                            End With

                            'If Not gbPl Is Nothing Then
                            '    If Not IsDBNull(drChamp("GroupeDispo")) Then
                            '        If Convert.ToString(gbPl.Tag) = CType(drChamp("GroupeDispo"), String) Then
                            '            gbPl.Height = tx.Top + tx.Height - gbPl.Top + interval
                            '            gbPl.SendToBack()
                            '        End If
                            '    End If
                            'End If
                        Else
                            With Me.flowLayout
                                .Controls.AddRange(ctls.ToArray)
                                .SetFlowBreak(ctls(ctls.Count - 1), True)
                            End With
                        End If
                    End If
                End If

            Catch ex As Exception
                Dim strValeur As String = ""
                Dim cl As DataColumn
                For Each cl In drChamp.Table.Columns
                    strValeur += cl.ColumnName & ":" & Convert.ToString(drChamp.Item(cl)) & vbCrLf
                Next
                MsgBox("Pb paramétrage : " & vbCrLf & "Message : " & ex.Message & vbCrLf & strValeur & vbCrLf & ex.StackTrace)
            End Try
        Next

        'Activer les champs dispos
        Dim dic As IDictionaryEnumerator = listChampConditionDispo.GetEnumerator()
        While dic.MoveNext
            Me.RendreDispoLstControl(dic.Key, New EventArgs)
        End While
        Me.flowLayout.ResumeLayout()
        Me.flowLayout.AutoSize = False
        For Each ctl As Control In Me.flowLayout.Controls
            If TypeOf ctl Is GroupBox Then
                Dim f As FlowLayoutPanel = CType(CType(ctl, GroupBox).Controls(0), FlowLayoutPanel)
                Dim maxRight As Integer = 0
                Dim maxBottom As Integer = 0
                For Each childCtl As Control In f.Controls
                    maxRight = Math.Max(childCtl.Right + childCtl.Margin.Right, maxRight)
                    maxBottom = Math.Max(childCtl.Bottom + childCtl.Margin.Bottom, maxBottom)
                Next
                f.AutoSize = False
                f.Width = maxRight + f.Padding.Right
                f.Height = maxBottom + f.Padding.Bottom
            End If
        Next
        Me.flowLayout.AutoSize = True
        If Me.flowLayout.Controls.Count > 0 Then
            Me.Height = Me.flowLayout.Controls(Me.flowLayout.Controls.Count - 1).Bottom
        End If
        RaiseEvent ChargementFini()
    End Sub

    Private Sub AfficheSelection(ByVal sender As Object, ByVal e As EventArgs)
        Dim dvTmp As New DataView(DsBase.Tables(Me.TableParam))
        dvTmp.RowFilter = "nNiveau1=" & Me.nNiveau1 & " And Table='" & Me.Table & "' And Champs='" & Convert.ToString(CType(sender, Control).Tag) & "'"
        Dim strFormulaire As String
        Dim strFormulaireChamps As String
        If dvTmp.Count = 1 Then
            strFormulaire = Convert.ToString(dvTmp.Item(0).Item("TableListeChoix"))
            'strFormulaireChamps = Convert.ToString(dvTmp.Item(0).Item("TableListeChoixSelectChamps"))
            strFormulaireChamps = Convert.ToString(dvTmp.Item(0).Item("Champs"))


            Dim fr As FrBase = Nothing
            If CType(Me.BindingContext(dv, Lien).Current, DataRowView).Item(strFormulaireChamps) Is DBNull.Value Then Exit Sub
            RaiseEvent AffichenEnregistrement(strFormulaire, DsBase, CType(Me.BindingContext(dv, Lien).Current, DataRowView).Item(strFormulaireChamps), fr)

            If fr Is Nothing Then Exit Sub
            fr.FiltrePlus = Convert.ToString(dvTmp.Item(0).Item("FiltrePlus"))
            fr.FiltreType = Convert.ToString(dvTmp.Item(0).Item("FiltreType"))
            fr.Owner = Me.ParentForm
            fr.Show()


            'If TypeOf FrBase.lstFormAffichable(strFormulaire) Is FrBase Then
            '    CType(FrBase.lstFormAffichable(strFormulaire), FrBase).SetDataMove(dsBase, CType(Me.BindingContext(ds, Lien).Current, DataRowView).Item(strFormulaireChamps))
            '    CType(FrBase.lstFormAffichable(strFormulaire), FrBase).Owner = Me.ParentForm
            '    CType(FrBase.lstFormAffichable(strFormulaire), FrBase).Show()
            'End If

            'Select Case strFormulaire
            '    Case "Personne"
            '        Dim frP As New FrPersonne(dsBase, CType(Me.BindingContext(ds, Lien).Current, DataRowView).Item(strFormulaireChamps))
            '        frP.Owner = Me.ParentForm
            '        frP.Show()
            '    Case "Entreprise"
            '        Dim rw() As DataRow
            '        'rw = Me.dsBase.Tables("Exploitation").Select("nEntreprise=" & Convert.ToString(CType(Me.BindingContext(ds, Lien).Current, DataRowView).Item(strFormulaireChamps)))
            '        'If rw.GetUpperBound(0) >= 0 Then
            '        '    Dim frE As New FrExploitation(dsBase, CType(Me.BindingContext(ds, Lien).Current, DataRowView).Item(strFormulaireChamps))
            '        '    frE.Show()
            '        'Else
            '        Dim frE As New FrEntreprise(dsBase, CType(Me.BindingContext(ds, Lien).Current, DataRowView).Item(strFormulaireChamps))
            '        frE.Owner = Me.ParentForm
            '        frE.Show()
            '        'End If
            'End Select
        End If

    End Sub

    Private Sub AfficheNouveau(ByVal sender As Object, ByVal e As EventArgs)
        mySender = sender

        If TypeOf (sender) Is Button Then
            Dim bt As Button = CType(sender, Button)
            If TypeOf (bt.Tag) Is Hashtable Then
                Dim maListe As Hashtable
                maListe = CType(bt.Tag, Hashtable)
                If maListe.ContainsKey("TableListeChoix") = True Then
                    Select Case Convert.ToString(maListe.Item("TableListeChoix"))
                        Case "Personne"
                            If IsDBNull(maListe("TableListeChoixSelectChamps")) Then
                                strChampsSelection = "nPersonne"
                            Else
                                strChampsSelection = CType(maListe("Champs"), String)
                            End If
                            RaiseEvent AfficheNew("Personne", DsBase, True, frP)
                            If frP Is Nothing Then Exit Sub
                            If TypeOf frParent Is FrBase Then
                                frP.FiltreType = CType(frParent, FrBase).FiltreType
                                If Convert.ToString(maListe.Item("FiltreType")) <> "" Then
                                    frE.FiltreType = Convert.ToString(maListe.Item("FiltreType"))
                                End If
                            End If
                            If FrBase.Autorisation <> "Tous" Then
                                frP.FiltrePlus = "Dep='" & FrBase.Autorisation & "'"
                            End If
                            frP.Owner = Me.ParentForm
                            frP.Show()
                            AddHandler frP.SelectObject, AddressOf nPersonneChanged
                        Case "Entreprise"
                            If IsDBNull(maListe("TableListeChoixSelectChamps")) Then
                                strChampsSelection = "nEntreprise"
                            Else
                                strChampsSelection = CType(maListe("Champs"), String)
                            End If
                            If Me.BindingContext(dv, _Lien).Position = -1 Then
                                Me.BindingContext(dv, _Lien).AddNew()
                                Me.BindingContext(dv, _Lien).EndCurrentEdit()
                            End If
                            RaiseEvent AfficheNew(Convert.ToString(maListe.Item("TableListeChoix")), DsBase, True, frE)
                            If frE Is Nothing Then Exit Sub
                            If TypeOf frParent Is FrBase Then
                                frE.FiltreType = CType(frParent, FrBase).FiltreType
                                If Convert.ToString(maListe.Item("FiltreType")) <> "" Then
                                    frE.FiltreType = Convert.ToString(maListe.Item("FiltreType"))
                                End If
                            End If
                            If FrBase.Autorisation <> "Tous" Then
                                frE.FiltrePlus = "Dep='" & FrBase.Autorisation & "'"
                            End If
                            frE.Owner = Me.ParentForm
                            frE.Show()
                            AddHandler frE.SelectObject, AddressOf nEntrepriseChanged
                        Case "Comptes"
                            RaiseEvent AfficheNewPerso(sender, Convert.ToString(maListe.Item("TableListeChoix")))

                            If TypeOf (sender) Is BtCtl Then
                                Dim cb As CbCtl = CType(CType(CType(sender, BtCtl).Tag, Hashtable).Item("Control"), CbCtl)
                                Dim rws() As DataRow = DsBase.Tables("Comptes").Select(cb.ChampsFiltre, cb.ChampsTri)
                                FillCb(rws, cb, "CCpt", "CCpt", Nothing, False, Not cb.IsObligatoire)
                            End If

                            RaiseEvent MustUpdateTable(Me, New System.ComponentModel.RefreshEventArgs("Comptes"))
                            RaiseEvent MustUpdateTable(Me, New System.ComponentModel.RefreshEventArgs("PlanComptable"))
                        Case Else
                            RaiseEvent AfficheNewPerso(sender, Convert.ToString(maListe.Item("TableListeChoix")))
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub AfficheZoom(ByVal sender As Object, ByVal e As EventArgs)
        Dim frZoom As New FrZone(CType(sender, Control))
        frZoom.Owner = Me.FindForm
        'frZoom.ShowDialog()
        frZoom.Show()

        'Dim frI As New FrInfoBulle(Me.dsBase, CType(sender, Control))
        'frI.Owner = Me.FindForm
        'frI.Show()
    End Sub

    Private Sub ListeChoixDataGridShow(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is Button Then
            Dim bt As Button
            Dim strCle As String
            bt = CType(sender, Button)
            If TypeOf (bt.Tag) Is Hashtable Then
                Dim maListe As Hashtable = CType(bt.Tag, Hashtable)
                strCle = DsBase.Tables(CType(maListe("TableListeChoix"), String)).DefaultView.Sort
                strChampsSelection = CType(maListe("Champs"), String)

                Dim dv As New DataView(DsBase.Tables(CType(maListe("TableListeChoix"), String)))

                Dim dvListeChoix As New DataView(DsBase.Tables("ListeChoix"))
                dvListeChoix.RowFilter = "NomChoix='" & CType(maListe("ListeChoix"), String) & "'"
                dvListeChoix.Sort = "nOrdreValeur"
                Dim cols As New List(Of DataGridViewColumn)
                For Each drvLC As DataRowView In dvListeChoix
                    Dim dct As New DataGridViewTextBoxColumn
                    dct.HeaderText = CType(drvLC("Valeur"), String)
                    dct.DataPropertyName = CType(drvLC("NomChamps"), String)
                    If Not IsDBNull(drvLC("LargeurChamps")) Then
                        If CType(drvLC("LargeurChamps"), Integer) > 0 Then
                            dct.Width = CType(drvLC("LargeurChamps"), Integer)
                        End If
                    End If
                    cols.Add(dct)
                Next

                Me.frSelection = New FrResultatRecherche(dv, strCle, cols)
                frSelection.Owner = Me.ParentForm
                frSelection.Show()
                'End If
            End If
        End If
    End Sub

    Private Sub ListeChoixDataGridShowCritere(ByVal strCritere As String) Handles myFrRecherche.AffectuerRecherche
        Dim sender As Object
        sender = mySender
        If TypeOf (sender) Is Button Then
            Dim bt As Button
            Dim strCle As String
            bt = CType(sender, Button)
            If TypeOf (bt.Tag) Is Hashtable Then
                Dim maListe As Hashtable
                maListe = CType(bt.Tag, Hashtable)
                strCle = DsBase.Tables(CType(maListe("TableListeChoix"), String)).DefaultView.Sort
                If IsDBNull(maListe("TableListeChoixSelectChamps")) Then
                    strChampsSelection = CType(maListe("Champs"), String)
                Else
                    strChampsSelection = CType(maListe("Champs"), String)
                End If

                Dim dv As New DataView(DsBase.Tables(CType(maListe("TableListeChoix"), String)))
                dv.Sort = strCle
                dv.RowFilter = strCritere
                '* Modif Filtre Type
                If dv.RowFilter.Length = 0 Then
                    If Not maListe("FiltreType") Is Nothing Then
                        dv.RowFilter = Convert.ToString(maListe("FiltreType"))
                    End If
                Else
                    If Not maListe("FiltreType") Is DBNull.Value Then
                        dv.RowFilter = "(" & dv.RowFilter & ") And (" & Convert.ToString(maListe("FiltreType")) & ")"
                    End If
                End If

                Select Case dv.Count
                    Case 0
                        MsgBox("Pas de résultat disponible")
                    Case 1
                        frSelection_SelectLigne(dv.Item(0).Item(dv.Sort))
                        myFrRecherche.Close()
                        myFrRecherche.Dispose()
                    Case Else
                        Dim cols As New List(Of DataGridViewColumn)
                        Dim dvListeChoix As New DataView(DsBase.Tables("ListeChoix"), "NomChoix='" & Convert.ToString(maListe("ListeChoix")) & "'", "nOrdreValeur", DataViewRowState.CurrentRows)
                        For n As Integer = 0 To dvListeChoix.Count - 1
                            If CType(dvListeChoix.Item(n).Item("NomChamps"), String) = "nEntreprise" Then
                                Dim col As New DataGridViewTextBoxColumn
                                With col
                                    .HeaderText = CType(dvListeChoix.Item(n).Item("Valeur"), String)
                                    .DataPropertyName = CType(dvListeChoix.Item(n).Item("NomChamps"), String)
                                    '.Liaison = "EntrepriseContact"
                                    '.Champs = "Nom"
                                    '.ExpressionCleEnfant = "nEntreprise"
                                    '.ExpressionCleParent = "nEntreprise"
                                    If Not IsDBNull(dvListeChoix.Item(n).Item("LargeurChamps")) Then
                                        If CType(dvListeChoix.Item(n).Item("LargeurChamps"), Integer) > 0 Then
                                            .Width = CType(dvListeChoix.Item(n).Item("LargeurChamps"), Integer)
                                        End If
                                    End If
                                    .DefaultCellStyle.NullValue = ""
                                End With
                                cols.Add(col)
                            Else
                                Dim col As New DataGridViewTextBoxColumn
                                With col
                                    .HeaderText = CType(dvListeChoix.Item(n).Item("Valeur"), String)
                                    .DataPropertyName = CType(dvListeChoix.Item(n).Item("NomChamps"), String)
                                    If Not IsDBNull(dvListeChoix.Item(n).Item("LargeurChamps")) Then
                                        If CType(dvListeChoix.Item(n).Item("LargeurChamps"), Integer) > 0 Then
                                            .Width = CType(dvListeChoix.Item(n).Item("LargeurChamps"), Integer)
                                        End If
                                    End If
                                    .DefaultCellStyle.NullValue = ""
                                End With
                                cols.Add(col)
                            End If
                        Next

                        Me.frSelection = New FrResultatRecherche(dv, strCle, cols)
                        frSelection.momFrRecherche = myFrRecherche
                        frSelection.Owner = myFrRecherche
                        frSelection.Show()
                        'End If
                End Select
            End If
        End If
    End Sub

    Private Sub AfficheFormRecherche(ByVal sender As System.Object, ByVal e As System.EventArgs)

        mySender = sender

        If TypeOf (sender) Is Button Then
            Dim bt As Button
            Dim strCle As String
            'Dim tx As TextBox
            bt = CType(sender, Button)
            If TypeOf (bt.Tag) Is Hashtable Then
                Dim maListe As Hashtable
                maListe = CType(bt.Tag, Hashtable)
                'If TypeOf (maListe("TxSelection")) Is TextBox Then
                'Me.txSelectionEnCours = CType(maListe("TxSelection"), TextBox)
                strCle = DsBase.Tables(CType(maListe("TableListeChoix"), String)).DefaultView.Sort
                If IsDBNull(maListe("TableListeChoixSelectChamps")) Then
                    strChampsSelection = CType(maListe("Champs"), String)
                Else
                    'strChampsSelection = CType(maListe("TableListeChoixSelectChamps"), String)
                    strChampsSelection = CType(maListe("Champs"), String)
                End If

                If Me.BindingContext(dv, _Lien).Position = -1 Then
                    Me.BindingContext(dv, _Lien).AddNew()
                    Me.BindingContext(dv, _Lien).EndCurrentEdit()
                End If

                myFrRecherche = New FrRecherche(DsBase, CType(maListe("TableListeChoix"), String))
                myFrRecherche.Owner = Me.ParentForm
                myFrRecherche.Show()
            End If
        End If
    End Sub

    Private Sub RendreDispoLstControl(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf sender Is CheckBox Then
            Dim ck As CheckBox = CType(sender, CheckBox)
            If listChampConditionDispo.ContainsKey(ck) Then
                For Each champ As String In CType(listChampConditionDispo(ck), String).Split("|"c)
                    RendreDispo(Me.flowLayout.Controls, champ, ck.CheckState = CheckState.Checked)
                Next
            End If
        End If
    End Sub

    Private Sub RendreDispo(ByVal controls As ControlCollection, ByVal champ As String, ByVal value As Boolean)
        For Each ctl As Control In controls
            If TypeOf ctl.Tag Is String AndAlso CType(ctl.Tag, String) = champ Then
                If ctl.Enabled <> value Then
                    ctl.Enabled = value
                End If
            End If
            RendreDispo(ctl.Controls, champ, value)
        Next
    End Sub

    Private Sub nEntrepriseChanged(ByVal nKey As Object)
        Dim e As New System.ComponentModel.CancelEventArgs
        RaiseEvent MustRefreshTable(Me, New System.ComponentModel.RefreshEventArgs("Entreprise"))
        RaiseEvent CtlnCleChanging(strChampsSelection, e)
        If e.Cancel Then Exit Sub
        For Each ctl As Control In Me.flowLayout.Controls
            Dim champ As String = Convert.ToString(ctl.Tag)
            If champ = "nEntreprise" Or champ = "nClient" Then
                If TypeOf ctl Is TxLiaison Then
                    CType(ctl, TxLiaison).Champs = Convert.ToString(nKey)
                    RaiseEvent CtlnCleChanged(ctl, New EventArgs)
                ElseIf TypeOf ctl Is CbCtl Then
                    Dim cb As CbCtl = CType(ctl, CbCtl)
                    Dim rws() As DataRow = DsBase.Tables("Entreprise").Select(cb.ChampsFiltre, cb.ChampsTri)
                    Dim cl As DataColumn = DsBase.Tables(Me.Table).Columns(champ)
                    FillCb(rws, cb, "Nom", "nEntreprise", nKey, True, Not cb.IsObligatoire, , cl.DataType)
                End If
            End If
        Next
    End Sub

    Private Sub nPersonneChanged(ByVal nKey As Object)
        Dim e As New System.ComponentModel.CancelEventArgs
        RaiseEvent MustRefreshTable(Me, New System.ComponentModel.RefreshEventArgs("Personne"))
        RaiseEvent CtlnCleChanging(strChampsSelection, e)
        If e.Cancel Then Exit Sub
        For Each ctl As Control In Me.flowLayout.Controls
            Dim champ As String = Convert.ToString(ctl.Tag)
            If champ = "nPersonne" Or champ = "nCommercial" Then
                If TypeOf ctl Is TxLiaison Then
                    CType(ctl, TxLiaison).Champs = Convert.ToString(nKey)
                    RaiseEvent CtlnCleChanged(ctl, New EventArgs)
                ElseIf TypeOf ctl Is CbCtl Then
                    Dim cb As CbCtl = CType(ctl, CbCtl)
                    Dim rws() As DataRow = DsBase.Tables("Personne").Select(cb.ChampsFiltre, cb.ChampsTri)
                    Dim cl As DataColumn = DsBase.Tables(Me.Table).Columns(champ)
                    FillCb(rws, cb, "Nom", "nPersonne", nKey, True, Not cb.IsObligatoire, , cl.DataType)
                End If
            End If
        Next
    End Sub

    Private Sub frSelection_SelectLigne(ByVal nKey As Object) Handles frSelection.SelectLigne
        Dim e As New System.ComponentModel.CancelEventArgs
        If frSelection IsNot Nothing Then
            RaiseEvent MustRefreshTable(Me, New System.ComponentModel.RefreshEventArgs(frSelection.dv.Table.TableName))
        End If
        RaiseEvent CtlnCleChanging(strChampsSelection, e)
        If e.Cancel Then Exit Sub
        If Me.LiaisonDonnees Then
            Me.BindingContext(dv, _Lien).EndCurrentEdit()
            CType(Me.BindingContext(dv, _Lien).Current, DataRowView).Row.Item(strChampsSelection) = nKey
            RaiseEvent CtlnCleChanged(strChampsSelection, New EventArgs)
            Me.BindingContext(dv, _Lien).EndCurrentEdit()
        Else
            For Each ctl As Control In Me.flowLayout.Controls
                If Convert.ToString(ctl.Tag) = strChampsSelection Then
                    If TypeOf ctl Is TxLiaison Then
                        CType(ctl, TxLiaison).Champs = Convert.ToString(nKey)
                        RaiseEvent CtlnCleChanged(ctl, New EventArgs)
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub AfficheCalendrier(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is Button Then
            If TypeOf (CType(sender, Button).Tag) Is TextBox Then
                Dim myTx As TextBox
                Dim myPt As Point
                myTx = CType(CType(sender, Button).Tag, TextBox)
                myPt = myTx.Parent.PointToScreen(myTx.Location)
                myPt.Y += myTx.Height
                Dim frCal As New FrCalendrier(myTx, myPt)
                frCal.Owner = Me.ParentForm
                frCal.Show()
            End If
        End If
    End Sub

    Private Sub AfficheListeChoix(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is Button Then
            If TypeOf (CType(sender, Button).Tag) Is Hashtable Then
                Dim btInfo As Hashtable
                Dim strTable As String = _TableListeChoix
                Dim strChamps As String = "Valeur"
                Dim strFiltre As String = ""
                btInfo = CType(CType(sender, Button).Tag, Hashtable)
                Dim myTx As TxCtl
                myTx = CType(btInfo.Item("Tx"), TxCtl)
                Dim myPt As Point
                myPt = myTx.Parent.PointToScreen(myTx.Location)
                myPt.Y += myTx.Height
                If Not btInfo.Item("ListeChoixMultipleTable") Is Nothing Then
                    If Not btInfo.Item("ListeChoixMultipleTable") Is System.DBNull.Value Then
                        strTable = Convert.ToString(btInfo.Item("ListeChoixMultipleTable"))
                    End If
                End If
                If Not btInfo.Item("ListeChoixMultipleTable") Is Nothing Then
                    If Not btInfo.Item("ListeChoixMultipleTable") Is System.DBNull.Value Then
                        strChamps = Convert.ToString(btInfo.Item("ListeChoixMultipleChamps"))
                    End If
                End If
                If Not btInfo.Item("ListeChoixMultipleTable") Is Nothing Then
                    If Not btInfo.Item("ListeChoixMultiple") Is System.DBNull.Value Then
                        If strTable <> _TableListeChoix Then
                            strFiltre = Convert.ToString(btInfo.Item("ListeChoixMultiple"))
                        Else
                            strFiltre = "NomChoix='" & Convert.ToString(btInfo.Item("ListeChoixMultiple")) & "'"
                        End If
                    End If
                End If

                Dim frChoix As New FrChoixMultiple(myTx, myPt, DsBase.Tables(strTable), strChamps, strFiltre, TypeSearch)

                frChoix.Owner = Me.ParentForm
                If myTx.StopSaisi = False Then
                    frChoix.ModeAjout = True
                Else
                    frChoix.ModeAjout = False
                End If
                frChoix.Show()
            End If
        End If
    End Sub

    Private Function GetCritereRechercheText(ByVal ctl As Control) As String
        If DsBase.Tables(_Table).Columns(CType(ctl.Tag, String)).DataType Is GetType(String) Then
            Dim monCtl As Ctl = CType(ctl, Ctl)
            Dim strCDeb As String = ""
            Dim strCFin As String = ""
            If Not monCtl.CbRecherche Is Nothing Then
                Select Case monCtl.CbRecherche.Text
                    Case "Commence par"
                        strCFin = "*"
                    Case "Fini par"
                        strCDeb = "*"
                    Case "Contient"
                        strCDeb = "*"
                        strCFin = "*"
                End Select
            End If

            Dim strVal As String = ctl.Text.Replace("'", "''")
            strVal = strVal.Replace(" et ", "{2}' AND {0} like '{1}")
            strVal = strVal.Replace(" ou ", "{2}' OR {0} like '{1}")
            strVal = String.Format("({{0}} like '{{1}}{0}{{2}}')", strVal)
            Return String.Format(strVal, ctl.Tag, strCDeb, strCFin)

            'strCritere &= " (" & CType(tx.Tag, String) & " like '" & strCDeb & tx.Text.Replace("'", "''").Replace(" et ", strCFin & "' And " & CType(tx.Tag, String) & " like '" & strCDeb).Replace(" ou ", strCFin & "' or " & CType(tx.Tag, String) & " like '" & strCDeb) & strCFin & "') And "
        ElseIf DsBase.Tables(_Table).Columns(CType(ctl.Tag, String)).DataType Is GetType(Integer) _
        OrElse DsBase.Tables(_Table).Columns(CType(ctl.Tag, String)).DataType Is GetType(Decimal) _
        OrElse DsBase.Tables(_Table).Columns(CType(ctl.Tag, String)).DataType Is GetType(Single) Then
            Dim monCtl As Ctl = CType(ctl, Ctl)
            Dim strOp As String = ""
            If Not monCtl.CbRecherche Is Nothing Then
                If monCtl.CbRecherche.Text <> "Fourchette" Then
                    strOp = monCtl.CbRecherche.Text
                End If
            End If

            Dim strVal As String = ctl.Text.Replace(","c, "."c)
            strVal = strVal.Replace(" et ", " AND {0}{1}")
            strVal = strVal.Replace(" ou ", " OR {0}{1}")
            strVal = String.Format("({{0}}{{1}}{0})", strVal)
            Return String.Format(strVal, ctl.Tag, strOp)
            'strCritere &= String.Format(" ({0}{1}{2}) And ", tx.Tag, strOp, tx.Text.Replace(" et ", " And " & CType(tx.Tag, String) & "").Replace(" ou ", " or " & CType(tx.Tag, String) & "").Replace(","c, "."c))
        ElseIf DsBase.Tables(_Table).Columns(CType(ctl.Tag, String)).DataType Is GetType(DateTime) Then
            'strCritere &= " (" & CType(tx.Tag, String) & " like '" & tx.Text.Replace(" et ", "' And " & CType(tx.Tag, String) & " like '").Replace(" ou ", "' or " & CType(tx.Tag, String) & " like '") & "') And "
            Dim strText As String = ctl.Text
            Dim monCtl As Ctl = CType(ctl, Ctl)
            If Not monCtl.CbRecherche Is Nothing Then
                If monCtl.CbRecherche.Text <> "Période" Then
                    strText = monCtl.CbRecherche.Text + strText
                End If
            End If

            Dim strLstDt() As String
            Dim strDt As String
            strLstDt = strText.Split(New Char() {"e"c, "t"c})
            Dim strCritereDt As String = ""
            For Each strDt In strLstDt
                If strDt.Trim.Length > 0 Then
                    Dim strOp As String = ""
                    If strDt.Trim.IndexOf("<") >= 0 Then
                        strOp += "<"
                    End If
                    If strDt.Trim.IndexOf(">") >= 0 Then
                        strOp += ">"
                    End If
                    If strDt.Trim.IndexOf("=") >= 0 Then
                        strOp += "="
                    End If
                    If strOp = "" Then
                        strOp = "=#"
                    Else
                        strOp += "#"
                    End If
                    If strCritereDt.Length > 0 Then
                        strCritereDt += " And "
                    End If
                    Try
                        If strDt.Trim.Split("/"c).GetUpperBound(0) = 1 Then
                            strCritereDt &= "(" & CType(ctl.Tag, String) & ">=#" & strDt.Trim.Split("/"c)(0) & "-01-" & strDt.Trim.Split("/"c)(1) & "# And " & CType(ctl.Tag, String) & "<#" & Convert.ToDateTime("01/" & strDt.Trim).AddMonths(1).Month & "-01-" & Convert.ToDateTime("01/" & strDt.Trim).AddMonths(1).Year & "#)"
                        Else
                            Dim dateCritere As String = strDt.Trim

                            dateCritere = dateCritere.Replace("=", "")
                            dateCritere = dateCritere.Replace(">", "")
                            dateCritere = dateCritere.Replace("<", "")

                            'strCritereDt &= CType(ctl.Tag, String) & strOp & Convert.ToDateTime(strDt.Trim).Month & "-" & Convert.ToDateTime(strDt.Trim).Day & "-" & Convert.ToDateTime(strDt.Trim).Year & "#"
                            strCritereDt &= CType(ctl.Tag, String) & strOp & Convert.ToDateTime(dateCritere).Month & "-" & Convert.ToDateTime(dateCritere).Day & "-" & Convert.ToDateTime(dateCritere).Year & "#"
                        End If
                    Catch
                        'Me.ErrorProvider1.SetError(tx, "Un format de Date n'est pas valide")
                    End Try
                End If
            Next
            If strCritereDt.Length > 0 Then
                Return String.Format("({0})", strCritereDt)
            End If
        End If
    End Function

    Public Function GetCritereRecherche() As String
        Dim ctl As Control

        For Each ctl In Me.flowLayout.Controls
            If ErrorProvider1.GetError(ctl) <> "" Then
                MessageBox.Show("Vérifiez votre saisie", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return ""
            End If
        Next

        Dim criteres As New List(Of String)

        For Each ctl In Me.flowLayout.Controls
            If TypeOf ctl Is TxLiaison Then
                Dim tx As TxLiaison = CType(ctl, TxLiaison)
                If tx.Champs <> "" Then criteres.Add(String.Format("({0}={1})", tx.Tag, tx.Champs))
            ElseIf TypeOf ctl Is System.Windows.Forms.TextBox _
            OrElse (TypeOf ctl Is GRC.CbCtl AndAlso CType(ctl, ComboBox).DropDownStyle = ComboBoxStyle.DropDown) Then
                'Dim tx As TextBox = CType(ctl, TextBox)
                If ctl.Text <> "" Then
                    Dim crit As String = GetCritereRechercheText(ctl)
                    If crit IsNot Nothing Then criteres.Add(crit)
                    'strCritere &= CType(tx.Tag, String) & strOp & Convert.ToDateTime(tx.Text).Month & "-" & Convert.ToDateTime(tx.Text).Day & "-" & Convert.ToDateTime(tx.Text).Year & "# And "
                End If
            ElseIf TypeOf ctl Is GRC.CbCtl Then
                Dim cbo As ComboBox = CType(ctl, ComboBox)
                If cbo.SelectedValue IsNot Nothing Then
                    'If cbo.ValueMember <> "" Then
                    criteres.Add(String.Format("({0}='{1}')", cbo.Tag, cbo.SelectedValue))
                    'Else
                    '    If DsBase.Tables(_Table).Columns(CType(cbo.Tag, String)).DataType Is GetType(String) Then
                    '        Dim strVal As String = cbo.Text.Replace("'", "''")
                    '        strVal = strVal.Replace(" et ", "' AND {0} like '")
                    '        strVal = strVal.Replace(" ou ", "' OR {0} like '")
                    '        strVal = String.Format("({{0}} like '{0}')", strVal)
                    '        criteres.Add(String.Format(strVal, cbo.Tag))
                    '    ElseIf DsBase.Tables(_Table).Columns(CType(cbo.Tag, String)).DataType Is GetType(Integer) _
                    '    OrElse DsBase.Tables(_Table).Columns(CType(cbo.Tag, String)).DataType Is GetType(Decimal) _
                    '    OrElse DsBase.Tables(_Table).Columns(CType(cbo.Tag, String)).DataType Is GetType(Single) Then
                    '        Dim strVal As String = cbo.Text.Replace(","c, "."c)
                    '        strVal = strVal.Replace(" et ", " AND {0}{1}")
                    '        strVal = strVal.Replace(" ou ", " OR {0}{1}")
                    '        strVal = String.Format("({{0}}{{1}}{0})", strVal)
                    '        criteres.Add(String.Format(strVal, cbo.Tag, "="))
                    '    End If
                    'End If
                End If
            ElseIf TypeOf ctl Is System.Windows.Forms.CheckBox Then
                Dim chk As CheckBox = CType(ctl, CheckBox)
                If chk.Text <> "" Then
                    If DsBase.Tables(_Table).Columns(CType(chk.Tag, String)).DataType Is GetType(Boolean) Then
                        If Not IsDBNull(chk.Checked) _
                            AndAlso chk.CheckState <> CheckState.Indeterminate Then
                            criteres.Add(String.Format("({0}={1})", chk.Tag, chk.Checked))
                        End If
                    End If
                End If
            End If
        Next

        If criteres.Count = 0 Then
            Return ""
        Else
            Dim strCritere As String = String.Join(" AND ", criteres.ToArray)
            'Debug.WriteLine(strCritere)
            Return strCritere
        End If
    End Function

    Private Sub GestionErreur(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.TypeRecherche = True Then
            If TypeOf (sender) Is Ctl Then
                Dim tx As Control
                tx = CType(sender, Control)
                If DsBase.Tables(_Table).Columns(CType(tx.Tag, String)).DataType.ToString = GetType(Integer).ToString Or DsBase.Tables(_Table).Columns(CType(tx.Tag, String)).DataType.ToString = GetType(Decimal).ToString Then
                    Dim Ok As Boolean = False

                    If Not CType(tx, Ctl).CbRecherche Is Nothing Then
                        If CType(tx, Ctl).CbRecherche.Text <> "" Then
                            Ok = True
                        End If
                    End If

                    If ((Ok = True Or tx.Text.StartsWith("=") Or tx.Text.StartsWith("<") Or tx.Text.StartsWith(">") Or tx.Text.StartsWith(">=") Or tx.Text.StartsWith("<=")) And IsNumeric(tx.Text.Replace("=", "").Replace("<", "").Replace(">", "").Replace(" et ", "").Replace(" ou ", "").Replace("."c, System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace("."c, System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(","c, System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace("."c, System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)) = True) Or tx.Text.Length = 0 Then
                        ErrorProvider1.SetError(tx, "")
                    Else
                        ErrorProvider1.SetError(tx, "Pour les valeurs numérique, vous devez saisir un opérateur de comparaison (=,<,>,<=,>=)")
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub AutoriseNiveau(ByVal nNiveau As Integer)
        Dim ctl As Control
        For Each ctl In Me.flowLayout.Controls
            If TypeOf ctl Is Ctl Then
                If nNiveau >= CType(ctl, Ctl).nNiveauAutorisation Then
                    If TypeOf ctl Is TxCtl Then
                        If CType(ctl, TxCtl).Multiline = True Then
                            CType(ctl, Ctl).StopSaisiAutorisation = False
                        Else
                            If ctl.Enabled = False Then
                                ctl.Enabled = True
                            End If
                        End If
                    ElseIf TypeOf ctl Is CheckBox Then
                        If CType(ctl, Ctl).StopSaisi = False Then
                            If ctl.Enabled = False Then
                                ctl.Enabled = True
                            End If
                        End If
                    Else
                        If ctl.Enabled = False Then
                            ctl.Enabled = True
                        End If
                    End If
                Else
                    If TypeOf ctl Is TxCtl Then
                        If CType(ctl, TxCtl).Multiline = True Then
                            CType(ctl, Ctl).StopSaisiAutorisation = True
                        Else
                            If ctl.Enabled = True Then
                                ctl.Enabled = False
                            End If
                        End If
                    ElseIf TypeOf ctl Is CheckBox Then
                        If CType(ctl, Ctl).StopSaisi = False Then
                            If ctl.Enabled = True Then
                                ctl.Enabled = False
                            End If
                        End If
                    Else
                        If ctl.Enabled = True Then
                            ctl.Enabled = False
                        End If
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub ResetErreur()
        Dim ctl As Control
        For Each ctl In Me.flowLayout.Controls
            Me.ErrorProvider1.SetError(ctl, "")
        Next
    End Sub

    Public Sub SetErreur(ByRef ctl As Control, ByVal message As String)
        Me.ErrorProvider1.SetError(ctl, message)
    End Sub

    Public Function GetErreur(ByRef ctl As Control) As String
        Return Me.ErrorProvider1.GetError(ctl)
    End Function

    Public Function VerifContraintes() As Boolean
        ResetErreur()
        Dim ok As Boolean = True
        Dim ctl As Control
        For Each ctl In Me.flowLayout.Controls
            If TypeOf ctl Is Ctl Then
                If CType(ctl, Ctl).IsObligatoire = True Then
                    If ctl.Text = "" And ctl.Enabled = True Then
                        Me.ErrorProvider1.SetIconAlignment(ctl, ErrorIconAlignment.MiddleLeft)
                        Me.ErrorProvider1.SetError(ctl, "Cette valeur ne peut pas être vide")
                        ok = False
                    End If
                End If
            End If
        Next
        Return ok
    End Function

    Private Sub flowLayout_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles flowLayout.Paint

    End Sub
End Class

#Region "Définition des classes et interfaces"
Public Interface Ctl

    Property nNiveauAutorisation() As Integer
    Property IsAjt() As Boolean
    Property IsAjtLst() As Boolean
    Property IsSuppr() As Boolean
    Property IsModif() As Boolean
    Property IsObligatoire() As Boolean
    Property StopSaisi() As Boolean
    Property StopSaisiAutorisation() As Boolean
    Property CbRecherche() As Control
    Property Libelle() As String

End Interface

Public Class BtCtl
    Inherits Button
    Implements Ctl
    Private _nNiveauAutorisation As Integer = -1
    Private _IsAjt As Boolean = False
    Private _IsAjtLst As Boolean = False
    Private _IsSuppr As Boolean = False
    Private _IsModif As Boolean = False
    Private _LstNomChoix As String = ""
    Private _CbLie As ComboBox
    Private _IsObligatoire As Boolean = False
    Private _StopSaisi As Boolean = False
    Private _StopSaisiAutorisation As Boolean = False
    Private _CbRecherche As Control
    Private _Libelle As String = ""

#Region "Propriétés"

    Public Property Libelle() As String Implements Ctl.Libelle
        Get
            Return _Libelle
        End Get
        Set(ByVal Value As String)
            _Libelle = Value
        End Set
    End Property

    Public Property CbRecherche() As Control Implements Ctl.CbRecherche
        Get
            Return _CbRecherche
        End Get
        Set(ByVal Value As Control)
            _CbRecherche = Value
        End Set
    End Property

    Public Property StopSaisi() As Boolean Implements Ctl.StopSaisi
        Get
            Return _StopSaisi
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisi = Value
        End Set
    End Property

    Public Property StopSaisiAutorisation() As Boolean Implements Ctl.StopSaisiAutorisation
        Get
            Return _StopSaisiAutorisation
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisiAutorisation = Value
        End Set
    End Property


    Public Property IsObligatoire() As Boolean Implements Ctl.IsObligatoire
        Get
            Return _IsObligatoire
        End Get
        Set(ByVal Value As Boolean)
            _IsObligatoire = Value
        End Set
    End Property

    Public Property CbLie() As ComboBox
        Get
            Return _CbLie
        End Get
        Set(ByVal Value As ComboBox)
            _CbLie = Value
        End Set
    End Property

    Public Property LstNomChoix() As String
        Get
            Return _LstNomChoix
        End Get
        Set(ByVal Value As String)
            _LstNomChoix = Value
        End Set
    End Property

    Public Property IsAjtLst() As Boolean Implements Ctl.IsAjtLst
        Get
            Return _IsAjtLst
        End Get
        Set(ByVal Value As Boolean)
            _IsAjtLst = Value
        End Set
    End Property

    Public Property IsAjt() As Boolean Implements Ctl.IsAjt
        Get
            Return _IsAjt
        End Get
        Set(ByVal Value As Boolean)
            _IsAjt = Value
        End Set
    End Property

    Public Property IsModif() As Boolean Implements Ctl.IsModif
        Get
            Return _IsModif
        End Get
        Set(ByVal Value As Boolean)
            _IsModif = Value
        End Set
    End Property

    Public Property IsSuppr() As Boolean Implements Ctl.IsSuppr
        Get
            Return _IsSuppr
        End Get
        Set(ByVal Value As Boolean)
            _IsSuppr = Value
        End Set
    End Property

    Public Property nNiveauAutorisation() As Integer Implements Ctl.nNiveauAutorisation
        Get
            Return _nNiveauAutorisation
        End Get
        Set(ByVal Value As Integer)
            _nNiveauAutorisation = Value
        End Set
    End Property

#End Region

End Class

Public Class TxCtl
    Inherits TextBox
    Implements Ctl
    Private _nNiveauAutorisation As Integer = -1
    Private _IsAjt As Boolean = False
    Private _IsAjtLst As Boolean = False
    Private _IsSuppr As Boolean = False
    Private _IsModif As Boolean = False
    Private _IsObligatoire As Boolean = False
    Public Event ClickRecherche(ByVal sender As Object, ByVal e As EventArgs)
    Private _StopSaisi As Boolean = False
    Private _StopSaisiAutorisation As Boolean = False
    Private _CbRecherche As Control
    Private _Libelle As String = ""


#Region "Propriétés"

    Public Property Libelle() As String Implements Ctl.Libelle
        Get
            Return _Libelle
        End Get
        Set(ByVal Value As String)
            _Libelle = Value
        End Set
    End Property

    Public Property CbRecherche() As Control Implements Ctl.CbRecherche
        Get
            Return _CbRecherche
        End Get
        Set(ByVal Value As Control)
            _CbRecherche = Value
        End Set
    End Property

    Public Property StopSaisiAutorisation() As Boolean Implements Ctl.StopSaisiAutorisation
        Get
            Return _StopSaisiAutorisation
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisiAutorisation = Value
        End Set
    End Property

    Public Property StopSaisi() As Boolean Implements Ctl.StopSaisi
        Get
            Return _StopSaisi
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisi = Value
        End Set
    End Property

    Public Property IsObligatoire() As Boolean Implements Ctl.IsObligatoire
        Get
            Return _IsObligatoire
        End Get
        Set(ByVal Value As Boolean)
            _IsObligatoire = Value
        End Set
    End Property

    Public Property IsAjtLst() As Boolean Implements Ctl.IsAjtLst
        Get
            Return _IsAjtLst
        End Get
        Set(ByVal Value As Boolean)
            _IsAjtLst = Value
        End Set
    End Property

    Public Property IsAjt() As Boolean Implements Ctl.IsAjt
        Get
            Return _IsAjt
        End Get
        Set(ByVal Value As Boolean)
            _IsAjt = Value
        End Set
    End Property

    Public Property IsModif() As Boolean Implements Ctl.IsModif
        Get
            Return _IsModif
        End Get
        Set(ByVal Value As Boolean)
            _IsModif = Value
        End Set
    End Property

    Public Property IsSuppr() As Boolean Implements Ctl.IsSuppr
        Get
            Return _IsSuppr
        End Get
        Set(ByVal Value As Boolean)
            _IsSuppr = Value
        End Set
    End Property

    Public Property nNiveauAutorisation() As Integer Implements Ctl.nNiveauAutorisation
        Get
            Return _nNiveauAutorisation
        End Get
        Set(ByVal Value As Integer)
            _nNiveauAutorisation = Value
        End Set
    End Property

#End Region

    Friend Sub SendClickRecherche(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent ClickRecherche(sender, e)
    End Sub

    Private Sub TxCtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not Me.Parent Is Nothing Then
                If TypeOf Me.Parent Is GestionControlesBase Then
                    If CType(Me.Parent, GestionControlesBase).TypeRecherche = True Then
                        e.Handled = True
                    End If
                End If
                If Not Me.Parent.Parent Is Nothing Then
                    If TypeOf Me.Parent.Parent Is GestionControlesBase Then
                        If CType(Me.Parent.Parent, GestionControlesBase).TypeRecherche = True Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
            RaiseEvent ClickRecherche(sender, New EventArgs)
        End If
    End Sub

End Class

Public Class CkCtl
    Inherits CheckBox
    Implements Ctl
    Private _nNiveauAutorisation As Integer = -1
    Private _IsAjt As Boolean = False
    Private _IsAjtLst As Boolean = False
    Private _IsSuppr As Boolean = False
    Private _IsModif As Boolean = False
    Private _IsObligatoire As Boolean = False
    Private _StopSaisi As Boolean = False
    Private _StopSaisiAutorisation As Boolean = False
    Private _CbRecherche As Control
    Private _Libelle As String = ""

#Region "Propriétés"

    Public Property Libelle() As String Implements Ctl.Libelle
        Get
            Return _Libelle
        End Get
        Set(ByVal Value As String)
            _Libelle = Value
        End Set
    End Property

    Public Property CbRecherche() As Control Implements Ctl.CbRecherche
        Get
            Return _CbRecherche
        End Get
        Set(ByVal Value As Control)
            _CbRecherche = Value
        End Set
    End Property

    Public Property StopSaisiAutorisation() As Boolean Implements Ctl.StopSaisiAutorisation
        Get
            Return _StopSaisiAutorisation
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisiAutorisation = Value
        End Set
    End Property

    Public Property StopSaisi() As Boolean Implements Ctl.StopSaisi
        Get
            Return _StopSaisi
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisi = Value
        End Set
    End Property

    Public Property IsObligatoire() As Boolean Implements Ctl.IsObligatoire
        Get
            Return _IsObligatoire
        End Get
        Set(ByVal Value As Boolean)
            _IsObligatoire = Value
        End Set
    End Property

    Public Property IsAjtLst() As Boolean Implements Ctl.IsAjtLst
        Get
            Return _IsAjtLst
        End Get
        Set(ByVal Value As Boolean)
            _IsAjtLst = Value
        End Set
    End Property

    Public Property IsAjt() As Boolean Implements Ctl.IsAjt
        Get
            Return _IsAjt
        End Get
        Set(ByVal Value As Boolean)
            _IsAjt = Value
        End Set
    End Property

    Public Property IsModif() As Boolean Implements Ctl.IsModif
        Get
            Return _IsModif
        End Get
        Set(ByVal Value As Boolean)
            _IsModif = Value
        End Set
    End Property

    Public Property IsSuppr() As Boolean Implements Ctl.IsSuppr
        Get
            Return _IsSuppr
        End Get
        Set(ByVal Value As Boolean)
            _IsSuppr = Value
        End Set
    End Property

    Public Property nNiveauAutorisation() As Integer Implements Ctl.nNiveauAutorisation
        Get
            Return _nNiveauAutorisation
        End Get
        Set(ByVal Value As Integer)
            _nNiveauAutorisation = Value
        End Set
    End Property
#End Region

End Class

Public Class CbCtl
    Inherits ComboBox
    Implements Ctl
    Private _nNiveauAutorisation As Integer = -1
    Private _IsAjt As Boolean = False
    Private _IsAjtLst As Boolean = False
    Private _IsSuppr As Boolean = False
    Private _IsModif As Boolean = False
    Private _IsObligatoire As Boolean = False
    Private _NomListeChoix As String = ""
    Private _ChampsFiltre As String = ""
    Public Event ClickRecherche(ByVal sender As Object, ByVal e As EventArgs)
    Private _StopSaisi As Boolean = False
    Private _StopSaisiAutorisation As Boolean = False
    Private _CbRecherche As Control
    Private _Libelle As String = ""

#Region "Propriétés"

    Public Property Libelle() As String Implements Ctl.Libelle
        Get
            Return _Libelle
        End Get
        Set(ByVal Value As String)
            _Libelle = Value
        End Set
    End Property

    Public Property CbRecherche() As Control Implements Ctl.CbRecherche
        Get
            Return _CbRecherche
        End Get
        Set(ByVal Value As Control)
            _CbRecherche = Value
        End Set
    End Property

    Public Property StopSaisiAutorisation() As Boolean Implements Ctl.StopSaisiAutorisation
        Get
            Return _StopSaisiAutorisation
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisiAutorisation = Value
        End Set
    End Property

    Public Property StopSaisi() As Boolean Implements Ctl.StopSaisi
        Get
            Return _StopSaisi
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisi = Value
        End Set
    End Property

    Public Property NomListeChoix() As String
        Get
            Return _NomListeChoix
        End Get
        Set(ByVal Value As String)
            _NomListeChoix = Value
        End Set
    End Property

    Public Property ChampsFiltre() As String
        Get
            Return _ChampsFiltre
        End Get
        Set(ByVal Value As String)
            _ChampsFiltre = Value
        End Set
    End Property

    Private _champsTri As String = ""
    Public Property ChampsTri() As String
        Get
            Return _champsTri
        End Get
        Set(ByVal value As String)
            _champsTri = value
        End Set
    End Property

    Public Property IsObligatoire() As Boolean Implements Ctl.IsObligatoire
        Get
            Return _IsObligatoire
        End Get
        Set(ByVal Value As Boolean)
            _IsObligatoire = Value
        End Set
    End Property

    Public Property IsAjtLst() As Boolean Implements Ctl.IsAjtLst
        Get
            Return _IsAjtLst
        End Get
        Set(ByVal Value As Boolean)
            _IsAjtLst = Value
        End Set
    End Property

    Public Property IsAjt() As Boolean Implements Ctl.IsAjt
        Get
            Return _IsAjt
        End Get
        Set(ByVal Value As Boolean)
            _IsAjt = Value
        End Set
    End Property

    Public Property IsModif() As Boolean Implements Ctl.IsModif
        Get
            Return _IsModif
        End Get
        Set(ByVal Value As Boolean)
            _IsModif = Value
        End Set
    End Property

    Public Property IsSuppr() As Boolean Implements Ctl.IsSuppr
        Get
            Return _IsSuppr
        End Get
        Set(ByVal Value As Boolean)
            _IsSuppr = Value
        End Set
    End Property

    Public Property nNiveauAutorisation() As Integer Implements Ctl.nNiveauAutorisation
        Get
            Return _nNiveauAutorisation
        End Get
        Set(ByVal Value As Integer)
            _nNiveauAutorisation = Value
        End Set
    End Property

#End Region

    Private Sub CbCtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not Me.Parent Is Nothing Then
                If TypeOf Me.Parent Is GestionControlesBase Then
                    If CType(Me.Parent, GestionControlesBase).TypeRecherche = True Then
                        e.Handled = True
                    End If
                End If
                If Not Me.Parent.Parent Is Nothing Then
                    If TypeOf Me.Parent.Parent Is GestionControlesBase Then
                        If CType(Me.Parent.Parent, GestionControlesBase).TypeRecherche = True Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
            RaiseEvent ClickRecherche(sender, New EventArgs)
        End If
    End Sub

    Private Sub CbCtl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        'legrain 10/02/2016
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up _
        Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Tab Or e.KeyCode = Keys.ShiftKey Then
            Exit Sub
        End If

        If e.KeyCode = Keys.Back Then
            If Me.SelectionStart > 0 Then
                If Me.SelectionLength <> 0 Then
                    Me.Text = Me.Text.Substring(0, Me.SelectionStart - 1)
                End If
                Me.SelectionStart = Me.Text.Length
            End If
        End If

        Dim selstart As Integer = Me.SelectionStart

        If selstart > 0 Then
            Dim strch As String = Me.Text.Substring(0, selstart)
            For Each it As Object In Me.Items
                If Me.GetItemText(it).ToUpper.StartsWith(strch.ToUpper) Then
                    If Me.ValueMember <> "" AndAlso Me.DataBindings.Count > 0 Then
                        Dim rwv As DataRowView = CType(Me.DataBindings(0).BindingManagerBase.Current, DataRowView)
                        'rwv.item(ctype(me.tag, string)) = ctype(it, datarowview).item(me.valuemember)
                        rwv.Item(CType(Me.Tag, String)) = CType(it, ListboxItem).Value
                        Me.OnSelectedValueChanged(New EventArgs)
                    Else
                        Me.SelectedIndex = Me.Items.IndexOf(it)
                    End If
                    Me.SelectionStart = selstart
                    Me.SelectionLength = Me.Text.Length - Me.SelectionStart
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub CbCtl_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectionChangeCommitted
        If Me.ValueMember <> "" Then
            If Not Me.SelectedItem Is Nothing Then
                If Me.DataBindings.Count > 0 Then
                    Dim rwv As DataRowView = CType(Me.DataBindings(0).BindingManagerBase.Current, DataRowView)
                    'rwv.Item(CType(Me.Tag, String)) = CType(Me.SelectedItem, DataRowView).Item(Me.ValueMember)
                    If Me.SelectedValue Is Nothing Then
                        rwv.Item(CType(Me.Tag, String)) = DBNull.Value
                    Else
                        rwv.Item(CType(Me.Tag, String)) = Me.SelectedValue
                    End If
                End If
            End If
        End If
    End Sub

End Class

Public Class TxLiaison
    Inherits TxCtl

#Region "Propriétés"

    Private _ds As DataSet
    Public Property Donnees() As DataSet
        Get
            Return _ds
        End Get
        Set(ByVal Value As DataSet)
            _ds = Value
        End Set
    End Property

    Private _champs As String
    Public Property Champs() As String
        Get
            Return _champs
        End Get
        Set(ByVal Value As String)
            _champs = Value
            PositionChanged(Me, New EventArgs)
        End Set
    End Property

    Private _tableSelection As String
    Public Property TableSelection() As String
        Get
            Return _tableSelection
        End Get
        Set(ByVal Value As String)
            _tableSelection = Value
        End Set
    End Property

    Private _cleSelection As String
    Public Property CleSelection() As String
        Get
            Return _cleSelection
        End Get
        Set(ByVal Value As String)
            _cleSelection = Value
        End Set
    End Property

    Private _champsSelection As String
    Public Property ChampsSelection() As String
        Get
            Return _champsSelection
        End Get
        Set(ByVal Value As String)
            _champsSelection = Value
        End Set
    End Property

#End Region

    Private Sub PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim txt As String = ""
        If Me.Champs <> "" Then
            Dim rw() As DataRow = _ds.Tables(TableSelection).Select(CleSelection & "=" & Me.Champs)
            If rw.Length > 0 Then
                txt = Convert.ToString(rw(0).Item(ChampsSelection))
            End If
        End If
        Me.Text = txt
    End Sub
End Class

Public Class TxRtf
    Inherits RichTextBox
    Implements Ctl
    Private _nNiveauAutorisation As Integer = -1
    Private _IsAjt As Boolean = False
    Private _IsAjtLst As Boolean = False
    Private _IsSuppr As Boolean = False
    Private _IsModif As Boolean = False
    Private _IsObligatoire As Boolean = False
    Public Event ClickRecherche(ByVal sender As Object, ByVal e As EventArgs)
    Private _StopSaisi As Boolean = False
    Private _StopSaisiAutorisation As Boolean = False
    Private _CbRecherche As Control
    Private _Libelle As String = ""

#Region "Propriétés"

    Public Property Libelle() As String Implements Ctl.Libelle
        Get
            Return _Libelle
        End Get
        Set(ByVal Value As String)
            _Libelle = Value
        End Set
    End Property

    Public Property CbRecherche() As Control Implements Ctl.CbRecherche
        Get
            Return _CbRecherche
        End Get
        Set(ByVal Value As Control)
            _CbRecherche = Value
        End Set
    End Property


    Public Property StopSaisiAutorisation() As Boolean Implements Ctl.StopSaisiAutorisation
        Get
            Return _StopSaisiAutorisation
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisiAutorisation = Value
        End Set
    End Property

    Public Property StopSaisi() As Boolean Implements Ctl.StopSaisi
        Get
            Return _StopSaisi
        End Get
        Set(ByVal Value As Boolean)
            _StopSaisi = Value
        End Set
    End Property

    Public Property IsObligatoire() As Boolean Implements Ctl.IsObligatoire
        Get
            Return _IsObligatoire
        End Get
        Set(ByVal Value As Boolean)
            _IsObligatoire = Value
        End Set
    End Property


    Public Property IsAjtLst() As Boolean Implements Ctl.IsAjtLst
        Get
            Return _IsAjtLst
        End Get
        Set(ByVal Value As Boolean)
            _IsAjtLst = Value
        End Set
    End Property

    Public Property IsAjt() As Boolean Implements Ctl.IsAjt
        Get
            Return _IsAjt
        End Get
        Set(ByVal Value As Boolean)
            _IsAjt = Value
        End Set
    End Property

    Public Property IsModif() As Boolean Implements Ctl.IsModif
        Get
            Return _IsModif
        End Get
        Set(ByVal Value As Boolean)
            _IsModif = Value
        End Set
    End Property

    Public Property IsSuppr() As Boolean Implements Ctl.IsSuppr
        Get
            Return _IsSuppr
        End Get
        Set(ByVal Value As Boolean)
            _IsSuppr = Value
        End Set
    End Property

    Public Property nNiveauAutorisation() As Integer Implements Ctl.nNiveauAutorisation
        Get
            Return _nNiveauAutorisation
        End Get
        Set(ByVal Value As Integer)
            _nNiveauAutorisation = Value
        End Set
    End Property

#End Region

    Private Sub TxCtl_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            If Not Me.Parent Is Nothing Then
                If TypeOf Me.Parent Is GestionControlesBase Then
                    If CType(Me.Parent, GestionControlesBase).TypeRecherche = True Then
                        e.Handled = True
                    End If
                End If
                If Not Me.Parent.Parent Is Nothing Then
                    If TypeOf Me.Parent.Parent Is GestionControlesBase Then
                        If CType(Me.Parent.Parent, GestionControlesBase).TypeRecherche = True Then
                            e.Handled = True
                        End If
                    End If
                End If
            End If
            RaiseEvent ClickRecherche(sender, New EventArgs)
        End If
    End Sub

End Class

#End Region
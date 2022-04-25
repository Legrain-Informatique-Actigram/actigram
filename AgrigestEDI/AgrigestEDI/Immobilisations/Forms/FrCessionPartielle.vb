Public Class FrCessionPartielle

    Private drvPrinc As DataRowView
    Private defValCession As Decimal = 0
    Private defDtCession As Date = #1/1/1900#

#Region "Propriétés"
    Public ReadOnly Property NewLib() As String
        Get
            Return Me.NewLibTextBox.Text.Trim
        End Get
    End Property

    Public ReadOnly Property NewObs() As String
        Get
            Return Me.NewObsTextBox.Text.Trim
        End Get
    End Property

    Public ReadOnly Property NewValAcquis() As Decimal
        Get
            Dim d As Decimal = Utils.CurrencyParse(Me.NewValAcquisTextBox.Text.Trim)
            If d = Decimal.MinValue Then
                Return 0
            Else
                Return d
            End If
        End Get
    End Property

    Public ReadOnly Property ValCess() As Decimal
        Get
            Dim d As Decimal = CurrencyParse(Me.ValCessTextBox.Text.Trim)
            If d = Decimal.MinValue Then
                Return 0
            Else
                Return d
            End If
        End Get
    End Property

    Public ReadOnly Property DtCess() As Date
        Get
            Return Me.DtCessDateTimePicker.Value
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal drv As DataRowView, Optional ByVal DtCession As Date = #1/1/1900#, Optional ByVal ValCession As Decimal = 0)

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me.drvPrinc = drv
        Me.defValCession = ValCession
        Me.defDtCession = DtCession
    End Sub
#End Region

#Region "Form"
    Private Sub FrCessionPartielle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With Me.DtCessDateTimePicker
            .Value = My.Dossier.Principal.DateDebutEx
            .MinDate = My.Dossier.Principal.DateDebutEx
            .MaxDate = My.Dossier.Principal.DateFinEx
        End With

        LoadData()
    End Sub
#End Region

#Region "NewValAcquisTextBox"
    Private Sub NewValAcquisTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewValAcquisTextBox.Validated
        Dim s As String = NewValAcquisTextBox.Text.Trim
        If s.Length = 0 Then Exit Sub
        Dim d As Decimal = CurrencyParse(s)
        ValCessTextBox.Text = d.ToString("C2")
        ValRestanteTextBox.Text = CDec(CDec(drvPrinc("IValAcquis")) - d).ToString("C2")
    End Sub
#End Region

#Region "Util controls databinding"
    Private Sub ConfigNullableDec(ByVal ctl As Control, ByVal datasource As Object, ByVal dataMember As String, Optional ByVal prop As String = "Value")
        Dim b As New FormatBinding(prop, datasource, dataMember, , 0)
        ctl.DataBindings.Add(b)
    End Sub

    Private Sub ConfigNullableDate(ByVal ctl As Control, ByVal datasource As Object, ByVal dataMember As String)
        Dim b As New FormatBinding("Value", datasource, dataMember, , New Date(1900, 1, 1))
        ctl.DataBindings.Add(b)
    End Sub

    Private Sub ConfigCurrency(ByVal ctl As Control, ByVal datasource As Object, ByVal dataMember As String)
        Dim b As New FormatBinding("Text", datasource, dataMember, "C2", 0)
        AddHandler b.Parse, AddressOf CurrencyParse
        ctl.DataBindings.Add(b)
    End Sub
#End Region

#Region "Button"
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        If Not Me.VerifDonnees() Then Exit Sub
        Me.DialogResult = DialogResult.OK
    End Sub
#End Region

#Region "NewValAcquisTextBox"
    'Vérifier qu'on ne peut pas céder plus que la valeur d'acquisition originale
    Private Sub NewValAcquisTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NewValAcquisTextBox.Validating
        Dim s As String = NewValAcquisTextBox.Text.Trim
        If s.Length = 0 Then Exit Sub
        e.Cancel = CurrencyParse(s) > CDec(drvPrinc("IValAcquis"))
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        Me.Databinding()
    End Sub

    Private Sub Databinding()
        'EXISTANT
        'Identification
        Me.CptTextBox.DataBindings.Add("Text", drvPrinc, "ICpt")
        Me.ActiTextBox.DataBindings.Add("Text", drvPrinc, "IActi")
        Me.OrdreTextBox.DataBindings.Add("Text", drvPrinc, "IOrdre")
        Me.NCompoTextBox.DataBindings.Add("Text", drvPrinc, "INCompo")
        Me.LibTextBox.DataBindings.Add("Text", drvPrinc, "ILib")
        Me.ObsTextBox.Text = String.Format("{0}" & vbCrLf & "{1}" & vbCrLf & "{2}", drvPrinc("ILib2"), drvPrinc("ILib3"), drvPrinc("ILib4")).Trim
        Me.ObsTextBox.SelectionStart = 0

        'Acquisition
        Me.ConfigCurrency(Me.ValAcquisTextBox, drvPrinc, "IValAcquis")

        'NOUVEAU READONLY
        Me.NewCptTextBox.DataBindings.Add("Text", drvPrinc, "ICpt")
        Me.NewActiTextBox.DataBindings.Add("Text", drvPrinc, "IActi")
        Me.NewNCompoTextBox.DataBindings.Add("Text", drvPrinc, "INCompo")

        'INIT DES CHAMPS MODIFIABLES
        Me.NewLibTextBox.Text = Convert.ToString(drvPrinc("ILib")).Trim
        Me.NewLibTextBox.SelectionStart = 0
        Me.NewObsTextBox.Text = String.Format("{0}" & vbCrLf & "{1}" & vbCrLf & "{2}", drvPrinc("ILib2"), drvPrinc("ILib3"), drvPrinc("ILib4")).Trim
        Me.NewObsTextBox.SelectionStart = 0

        Me.OrdreNumericUpDown.Value = Immobilisations.Immobilisation.FindNewOrdre(CStr(drvPrinc("ICpt")), CStr(drvPrinc("IActi")))
        If Me.defDtCession > #1/1/1900# Then
            Me.DtCessDateTimePicker.Value = Me.defDtCession
        Else
            If My.Dossier.Principal.DateFinEx < Today Then
                Me.DtCessDateTimePicker.Value = My.Dossier.Principal.DateFinEx
            ElseIf My.Dossier.Principal.DateDebutEx > Today Then
                Me.DtCessDateTimePicker.Value = My.Dossier.Principal.DateDebutEx
            Else
                Me.DtCessDateTimePicker.Value = Today
            End If
        End If

        ConfigUnboundCurrencyControl(Me.NewValAcquisTextBox, 2)
        ConfigUnboundCurrencyControl(Me.ValCessTextBox, 2)
        Me.NewValAcquisTextBox.Text = String.Format("{0:C2}", Me.defValCession)
        NewValAcquisTextBox_Validated(Nothing, Nothing)
    End Sub

    Private Function VerifDonnees() As Boolean
        'Ordre pas déjà pris
        If Not Immobilisations.Immobilisation.VerifOrdreLibre(CStr(drvPrinc("ICpt")), CStr(drvPrinc("IActi")), CInt(Me.OrdreNumericUpDown.Value)) Then
            MsgBox("Ce n° d'ordre est déjà utilisé.", MsgBoxStyle.Exclamation)

            Return False
        End If
        Return True
    End Function
#End Region

End Class
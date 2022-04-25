Namespace Controles
    'TODO X Max et Min value
    'TODO X Obligatoire/Facultatif
    '
    Public Class DefinitionControle
        Implements ICloneable

        Private _nControle As Integer
        Private _IdControle As Integer
        Private _CodeProduit As String
        Private _Ordre As Integer
        Private _Groupe As String
        Private _Libelle As String
        Private _Type As String
        Private _ValeursPossibles As String
        Private _ValeursDefaut As String

        Private _ListeBaremes As New List(Of Bareme)

#Region "Propriétés"
        Public Property nControle() As Integer
            Get
                Return Me._nControle
            End Get
            Set(ByVal value As Integer)
                Me._nControle = value
            End Set
        End Property

        Public Property IdControle() As Integer
            Get
                Return Me._IdControle
            End Get
            Set(ByVal value As Integer)
                Me._IdControle = value
            End Set
        End Property

        Public Property CodeProduit() As String
            Get
                Return Me._CodeProduit
            End Get
            Set(ByVal value As String)
                Me._CodeProduit = value
            End Set
        End Property

        Public Property Ordre() As Integer
            Get
                Return Me._Ordre
            End Get
            Set(ByVal value As Integer)
                Me._Ordre = value
            End Set
        End Property

        Public Property Groupe() As String
            Get
                Return Me._Groupe
            End Get
            Set(ByVal value As String)
                Me._Groupe = value
            End Set
        End Property

        Public Property Libelle() As String
            Get
                Return Me._Libelle
            End Get
            Set(ByVal value As String)
                Me._Libelle = value
            End Set
        End Property

        Public Property Type() As String
            Get
                Return Me._Type
            End Get
            Set(ByVal value As String)
                Me._Type = value
            End Set
        End Property

        Public Property ValeursPossibles() As String
            Get
                Return Me._ValeursPossibles
            End Get
            Set(ByVal value As String)
                Me._ValeursPossibles = value
            End Set
        End Property

        Public Property ValeursDefaut() As String
            Get
                Return Me._ValeursDefaut
            End Get
            Set(ByVal value As String)
                Me._ValeursDefaut = value
            End Set
        End Property

        Public Property ListeBaremes() As List(Of Bareme)
            Get
                Return Me._ListeBaremes
            End Get
            Set(ByVal value As List(Of Bareme))
                Me._ListeBaremes = value
            End Set
        End Property

        Private ReadOnly Property ValDefauts() As String()
            Get
                Dim defaults() As String
                If Me.ValeursDefaut IsNot Nothing Then
                    defaults = Me.ValeursDefaut.Split(";"c)
                Else
                    defaults = New String() {}
                End If
                Return defaults
            End Get
        End Property

        Private ReadOnly Property ValPossibles() As String()
            Get
                Dim vals() As String
                If Me.ValeursPossibles IsNot Nothing Then
                    vals = Me.ValeursPossibles.Split(";"c)
                Else
                    vals = New String() {}
                End If
                Return vals
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal dr As AgrifactTracaDataSet.DefinitionControleRow)
            Me.New()
            Me.nControle = dr.nControle
            Me.IdControle = dr.IdControle
            Me.Type = dr.Type
            Me.Ordre = dr.Ordre
            Me.CodeProduit = dr.CodeProduit
            If Not dr.IsGroupeNull Then Me.Groupe = dr.Groupe
            If Not dr.IsLibelleNull Then Me.Libelle = dr.Libelle
            If Not dr.IsValeursPossiblesNull Then Me.ValeursPossibles = dr.ValeursPossibles
            If Not dr.IsValeursDefautNull Then Me.ValeursDefaut = dr.ValeursDefaut
            For Each drB As AgrifactTracaDataSet.BaremeRow In dr.GetBaremeRows
                Me.ListeBaremes.Add(New Bareme(drB))
            Next
        End Sub

        Public Sub New(ByVal idControle As Integer, ByVal codeProduit As String)
            Using definitionControleTA As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
                Dim definitionControleDT As AgrifactTracaDataSet.DefinitionControleDataTable = definitionControleTA.GetDataByIDControleEtCodeProduit(idControle, codeProduit)

                For Each definitionControleDR As AgrifactTracaDataSet.DefinitionControleRow In definitionControleDT
                    Me.nControle = definitionControleDR.nControle
                    Me.IdControle = definitionControleDR.IdControle
                    Me.CodeProduit = definitionControleDR.CodeProduit
                    Me.Ordre = definitionControleDR.Ordre

                    If Not (definitionControleDR.IsGroupeNull) Then
                        Me.Groupe = definitionControleDR.Groupe
                    Else
                        Me.Groupe = String.Empty
                    End If

                    If Not (definitionControleDR.IsLibelleNull) Then
                        Me.Libelle = definitionControleDR.Libelle
                    Else
                        Me.Libelle = String.Empty
                    End If

                    If Not (definitionControleDR.IsTypeNull) Then
                        Me.Type = definitionControleDR.Type
                    Else
                        Me.Type = String.Empty
                    End If

                    If Not (definitionControleDR.IsValeursPossiblesNull) Then
                        Me.ValeursPossibles = definitionControleDR.ValeursPossibles
                    Else
                        Me.ValeursPossibles = String.Empty
                    End If

                    If Not (definitionControleDR.IsValeursDefautNull) Then
                        Me.ValeursDefaut = definitionControleDR.ValeursDefaut
                    Else
                        Me.ValeursDefaut = String.Empty
                    End If

                    'Récupération des infos dans la table Bareme
                    Me.ListeBaremes.Clear()

                    Using baremeTA As New AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
                        Dim baremeDT As AgrifactTracaDataSet.BaremeDataTable = baremeTA.GetDataByNControle(Me.nControle)

                        For Each baremeDR As AgrifactTracaDataSet.BaremeRow In baremeDT
                            Me.ListeBaremes.Add(New Bareme(baremeDR.nBareme))
                        Next
                    End Using
                Next
            End Using
        End Sub
#End Region

#Region "XML"
        Public Shared Function ChargerFichierXml(ByVal filename As String) As List(Of DefinitionControle)
            Using s As New IO.StreamReader(filename)
                Return ChargerXml(s)
            End Using
        End Function

        Public Shared Function ChargerXml(ByVal xml As String) As List(Of DefinitionControle)
            Using s As New IO.StringReader(xml)
                Return ChargerXml(s)
            End Using
        End Function

        Public Shared Function ChargerXml(ByVal s As IO.TextReader) As List(Of DefinitionControle)
            Dim ser As New Xml.Serialization.XmlSerializer(GetType(List(Of DefinitionControle)))
            Dim res As List(Of DefinitionControle) = CType(ser.Deserialize(s), List(Of DefinitionControle))
            Return res
        End Function

        Public Shared Sub EcrireXml(ByVal filename As String, ByVal list As List(Of DefinitionControle))
            Using sw As New IO.StreamWriter(filename)
                EcrireXml(sw, list)
            End Using
        End Sub

        Public Shared Sub EcrireXml(ByVal sw As IO.TextWriter, ByVal list As List(Of DefinitionControle))
            Dim ser As New Xml.Serialization.XmlSerializer(GetType(List(Of DefinitionControle)))
            ser.Serialize(sw, list)
        End Sub
#End Region

#Region " Données "
        Public Shared Function Charger(ByVal codeProduit As String, Optional ByVal chargerbaremes As Boolean = True) As List(Of DefinitionControle)
            Dim ds As New AgrifactTracaDataSet
            Using dta As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
                dta.FillByCodeProduit(ds.DefinitionControle, codeProduit)
            End Using
            If chargerbaremes Then
                Using dta As New AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
                    dta.FillByCodeProduit(ds.Bareme, codeProduit)
                End Using
            End If
            Return Charger(ds)
        End Function

        Public Shared Function Charger(ByVal ds As AgrifactTracaDataSet) As List(Of DefinitionControle)
            Dim res As New List(Of DefinitionControle)
            For Each dr As AgrifactTracaDataSet.DefinitionControleRow In ds.DefinitionControle.Select("", "Ordre")
                res.Add(New DefinitionControle(dr))
            Next
            Return res
        End Function

        Public Shared Sub Delete(ByVal id As Integer)
            Using dta As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
                dta.Delete(id)
            End Using
        End Sub

        Public Shared Sub EchangeOrdre(ByVal ctl1 As DefinitionControle, ByVal ctl2 As DefinitionControle)
            Dim curOrdre As Integer = ctl1.Ordre
            ctl1.Ordre = ctl2.Ordre
            ctl2.Ordre = curOrdre
            Using dta As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
                ctl1.Update(dta)
                ctl2.Update(dta)
            End Using
        End Sub

        Public Sub Update()
            Using dta As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
                Me.Update(dta)
            End Using
        End Sub

        Public Sub Update(ByVal dta As AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter)
            dta.Update(Me.CodeProduit, Me.Groupe, Me.Libelle, Me.Type, Me.ValeursPossibles, Me.ValeursDefaut, Me.Ordre, Me.IdControle, Me.nControle, Me.nControle)
        End Sub
#End Region

#Region " Delegates "
        Public Shared Function CompareByOrdre(ByVal def1 As DefinitionControle, ByVal def2 As DefinitionControle) As Integer
            Return def1.Ordre - def2.Ordre
        End Function

        Public Shared Function HasEvenId(ByVal dc As DefinitionControle) As Boolean
            Return dc.IdControle Mod 2 = 0
        End Function

        Public Shared Function HasOddId(ByVal dc As DefinitionControle) As Boolean
            Return dc.IdControle Mod 2 = 1
        End Function
#End Region

#Region "Test init de controles dans la BDD"
        'Public Shared Sub Test()
        '    Test("CAR")
        'End Sub

        'Public Shared Sub Test(ByVal codeProduit As String)
        '    Dim l As List(Of DefinitionControle) = ChargerXml(My.Resources.XmlControles)
        '    Test(codeProduit, l)
        'End Sub

        'Public Shared Sub Test(ByVal codeProduit As String, ByVal l As List(Of DefinitionControle))
        '    Dim ds As New AgrifactTracaDataSet
        '    For Each dc As DefinitionControle In l
        '        Dim drC As AgrifactTracaDataSet.DefinitionControleRow = ds.DefinitionControle.NewDefinitionControleRow
        '        With drC
        '            .CodeProduit = codeProduit
        '            .Groupe = dc.GroupeControle
        '            .Libelle = dc.Libelle
        '            .Type = dc.Type
        '            .ValeursDefaut = dc.ValeursDefaut
        '            .ValeursPossibles = dc.ValeursPossibles
        '        End With
        '        ds.DefinitionControle.Rows.Add(drC)
        '        For Each b As Bareme In dc.Baremes
        '            Dim drb As AgrifactTracaDataSet.BaremeRow = ds.Bareme.NewBaremeRow
        '            With drb
        '                .nControle = drC.nControle
        '                .ResultatConformite = b.ResultatConformite
        '                .Expression = b.Expression
        '                .CheminDoc = b.CheminDoc
        '                .ActionCorrective = b.ActionCorrective
        '            End With
        '            ds.Bareme.Rows.Add(drb)
        '        Next
        '    Next
        '    Using dta As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
        '        dta.Update(ds.DefinitionControle)
        '    End Using
        '    Using dta As New AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
        '        dta.Update(ds.Bareme)
        '    End Using
        'End Sub

        ''Public Shared Sub TestProcess()
        ''    TestProcess("PROCESS 1")
        ''End Sub

        ''Public Shared Sub TestProcess(ByVal process As String)
        ''    Dim l As List(Of DefinitionControle) = ChargerXml(My.Resources.XmlControles)
        ''    l.RemoveAll(AddressOf DefinitionControle.HasEvenId)
        ''    TestModele("PROCESS", process, l)
        ''End Sub

        ''Public Shared Sub TestFormat()
        ''    TestProcess("FORMAT 1")
        ''End Sub

        ''Public Shared Sub TestFormat(ByVal format As String)
        ''    Dim l As List(Of DefinitionControle) = ChargerXml(My.Resources.XmlControles)
        ''    l.RemoveAll(AddressOf DefinitionControle.HasOddId)
        ''    TestModele("FORMAT", format, l)
        ''End Sub

        'Public Shared Sub TestModeles()
        '    Dim l As List(Of DefinitionControle) = ChargerXml(My.Resources.XmlControles)
        '    TestModele("PROCESS", "PROCESS 1", l.FindAll(AddressOf DefinitionControle.HasEvenId))
        '    TestModele("FORMAT", "FORMAT 1", l.FindAll(AddressOf DefinitionControle.HasOddId))
        'End Sub

        'Public Shared Sub TestModele(ByVal typecritere As String, ByVal critere As String, ByVal l As List(Of DefinitionControle))
        '    Dim ds As New AgrifactTracaDataSet
        '    For Each dc As DefinitionControle In l
        '        Dim drC As AgrifactTracaDataSet.ModeleDefinitionControleRow = ds.ModeleDefinitionControle.NewModeleDefinitionControleRow
        '        With drC
        '            .TypeCritere = typecritere
        '            .Critere = critere
        '            .Groupe = dc.GroupeControle
        '            .Libelle = dc.Libelle
        '            .Type = dc.Type
        '            .ValeursDefaut = dc.ValeursDefaut
        '            .ValeursPossibles = dc.ValeursPossibles
        '        End With
        '        ds.ModeleDefinitionControle.Rows.Add(drC)
        '        For Each b As Bareme In dc.Baremes
        '            Dim drb As AgrifactTracaDataSet.ModeleBaremeRow = ds.ModeleBareme.NewModeleBaremeRow
        '            With drb
        '                .nModeleControle = drC.nModeleControle
        '                .ResultatConformite = b.ResultatConformite
        '                .Expression = b.Expression
        '                .CheminDoc = b.CheminDoc
        '                .ActionCorrective = b.ActionCorrective
        '            End With
        '            ds.ModeleBareme.Rows.Add(drb)
        '        Next
        '    Next
        '    Using dta As New AgrifactTracaDataSetTableAdapters.ModeleDefinitionControleTableAdapter
        '        dta.Update(ds.ModeleDefinitionControle)
        '    End Using
        '    Using dta As New AgrifactTracaDataSetTableAdapters.ModeleBaremeTableAdapter
        '        dta.Update(ds.ModeleBareme)
        '    End Using
        'End Sub
#End Region

#Region "Méthodes diverses"
        Public Function TrouverResultat(ByVal list As List(Of ResultatControle)) As ResultatControle
            For Each res As ResultatControle In list
                If res.nControle = Me.nControle Then
                    Return res
                End If
            Next
            Return Nothing
        End Function

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim res As New DefinitionControle
            Copy(Me, res)
            Return res
        End Function

        Public Sub CopyTo(ByVal d As DefinitionControle)
            Copy(Me, d)
        End Sub
#End Region

#Region "Affectation des résultats"
        Public Sub SetResultat(ByVal ctl As Control, ByVal value As String)
            Select Case Me.Type
                Case "TextBox" : Me.SetResultatTextBox(CType(ctl, TextBox), value)
                Case "ComboBox" : Me.SetResultatComboBox(CType(ctl, ComboBox), value)
                Case "CheckBox" : Me.SetResultatCheckBoxes(CType(ctl, FlowLayoutPanel), value)
                Case "RadioButton" : Me.SetResultatRadioButtons(CType(ctl, FlowLayoutPanel), value)
                Case "DatePicker" : Me.SetResultatDatePicker(CType(ctl, DateTimePicker), value)
                Case "TimePicker" : Me.SetResultatTimePicker(CType(ctl, TimePicker), value)
                Case "NumericUpDown" : Me.SetResultatNumericUpDown(CType(ctl, NumericUpDown), value)
                Case "Expression" 'Rien
                Case "Separator" 'Rien
                Case Else : ctl.Text = value
            End Select
        End Sub

        Private Sub SetResultatTextBox(ByVal ctl As TextBox, ByVal value As String)
            ctl.Text = value
        End Sub

        Private Sub SetResultatComboBox(ByVal ctl As ComboBox, ByVal value As String)
            ctl.SelectedIndex = ctl.FindStringExact(value)
        End Sub

        Private Sub SetResultatCheckBoxes(ByVal layout As FlowLayoutPanel, ByVal value As String)
            Dim res() As String = value.Split(";"c)
            For Each ctl As Control In layout.Controls
                If TypeOf ctl Is CheckBox Then
                    If Array.IndexOf(res, ctl.Text) >= 0 Then
                        Cast(Of CheckBox)(ctl).Checked = True
                    End If
                End If
            Next
        End Sub

        Private Sub SetResultatRadioButtons(ByVal layout As FlowLayoutPanel, ByVal value As String)
            For Each ctl As Control In layout.Controls
                If TypeOf ctl Is RadioButton Then
                    If value = ctl.Text Then
                        Cast(Of RadioButton)(ctl).Checked = True
                        Exit For
                    End If
                End If
            Next
        End Sub

        Private Sub SetResultatDatePicker(ByVal ctl As DateTimePicker, ByVal value As String)
            Dim d As Date
            If Date.TryParse(value, d) Then
                ctl.Value = d
            End If
        End Sub

        Private Sub SetResultatTimePicker(ByVal ctl As TimePicker, ByVal value As String)
            Dim d As Date
            If Date.TryParse(value, d) Then
                ctl.Value = d
            End If
        End Sub

        Private Sub SetResultatNumericUpDown(ByVal ctl As NumericUpDown, ByVal value As String)
            Dim d As Nullable(Of Decimal) = DecimalParse(value)
            If d.HasValue Then
                ctl.Value = d.Value
            End If
        End Sub
#End Region

#Region "Récup des résultats"
        Public Function GetResultat(ByVal ctl As Control) As Object
            Select Case Me.Type
                Case "TextBox" : Return Me.GetResultatTextBox(CType(ctl, TextBox))
                Case "ComboBox" : Return Me.GetResultatComboBox(CType(ctl, ComboBox))
                Case "CheckBox" : Return Me.GetResultatCheckBoxes(CType(ctl, FlowLayoutPanel))
                Case "RadioButton" : Return Me.GetResultatRadioButtons(CType(ctl, FlowLayoutPanel))
                Case "DatePicker" : Return Me.GetResultatDatePicker(CType(ctl, DateTimePicker))
                Case "TimePicker" : Return Me.GetResultatTimePicker(CType(ctl, TimePicker))
                Case "NumericUpDown" : Return Me.GetResultatNumericUpDown(CType(ctl, NumericUpDown))
                Case "Expression" : Return Me.GetResultatExpression(CType(ctl, Ascend.Windows.Forms.GradientCaption))
                Case "Separator" : Return ""
                Case Else : Return ""
            End Select
        End Function

        Private Function GetResultatTextBox(ByVal txt As TextBox) As String
            If txt.Text.Trim.Length = 0 Then
                Return Nothing
            Else
                Return txt.Text.Trim
            End If
        End Function

        Private Function GetResultatComboBox(ByVal cb As ComboBox) As String
            If cb.SelectedItem Is Nothing Then
                Return Nothing
            Else
                Return cb.SelectedText
            End If
        End Function

        Private Function GetResultatDatePicker(ByVal dtp As DateTimePicker) As DateTime
            Return dtp.Value.Date
        End Function

        Private Function GetResultatTimePicker(ByVal dtp As TimePicker) As DateTime
            Return dtp.Value
        End Function

        Private Function GetResultatNumericUpDown(ByVal nud As NumericUpDown) As Decimal
            Return nud.Value
        End Function

        Private Function GetResultatCheckBoxes(ByVal layout As FlowLayoutPanel) As String
            Dim res As New List(Of String)
            For Each ctl As Control In layout.Controls
                If TypeOf ctl Is CheckBox Then
                    If CType(ctl, CheckBox).Checked Then
                        res.Add(ctl.Text)
                    End If
                End If
            Next
            Return String.Join(";", res.ToArray)
        End Function

        Private Function GetResultatRadioButtons(ByVal layout As FlowLayoutPanel) As String
            Dim res As String = ""
            For Each ctl As Control In layout.Controls
                If TypeOf ctl Is RadioButton Then
                    If CType(ctl, RadioButton).Checked Then
                        res = ctl.Text
                        Exit For
                    End If
                End If
            Next
            Return res
        End Function

        Private Function GetResultatExpression(ByVal l As Ascend.Windows.Forms.GradientCaption) As String
            If l.Text.Trim.Length = 0 Then
                Return Nothing
            Else
                Return l.Text.Trim
            End If
        End Function

#End Region

#Region "Instanciation des contrôles"
        Public Function CreerLabel() As Label
            Select Case Me.Type
                Case "Separator"
                    Return Nothing
                Case Else
                    Return UtilsControles.CreerLabel(Me.Libelle)
            End Select
        End Function

        Public Function CreerControl(ByVal e As EventHandler) As Control
            Select Case Me.Type
                Case "TextBox" : Return Me.CreerTextBox(e)
                Case "ComboBox" : Return Me.CreerComboBox(e)
                Case "CheckBox" : Return Me.CreerCheckBoxes(e)
                Case "RadioButton" : Return Me.CreerRadioButtons(e)
                Case "DatePicker" : Return Me.CreerDatePicker(e)
                Case "TimePicker" : Return Me.CreerTimePicker(e)
                Case "NumericUpDown" : Return Me.CreerNumericUpDown(e)
                Case "Separator" : Return Me.CreerSeparator
                Case "Expression" : Return Me.CreerExpression(e)
                Case Else : Return New Label
            End Select
        End Function

        Private Function CreerTextBox(ByVal e As EventHandler) As TextBox
            Dim tx As TextBox = UtilsControles.CreerTextBox(Me.ValeursDefaut)
            AddHandler tx.Validated, e
            tx.Tag = Me
            Return tx
        End Function

        Private Function CreerComboBox(ByVal e As EventHandler) As ComboBox
            Dim cb As New ComboBox
            With cb
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Dock = DockStyle.Fill
                For Each s As String In Me.ValPossibles
                    .Items.Add(s)
                Next
                .SelectedValue = Me.ValeursDefaut
                AddHandler .SelectedIndexChanged, e
                .Tag = Me
            End With
            Return cb
        End Function

        Private Function CreerCheckBoxes(ByVal e As EventHandler) As FlowLayoutPanel
            Dim layout As FlowLayoutPanel = UtilsControles.CreerCheckBoxes(Me.ValPossibles, Me.ValDefauts, e)
            layout.AutoSize = True
            layout.AutoSizeMode = AutoSizeMode.GrowOnly
            layout.Tag = Me
            Return layout
        End Function

        Private Function CreerRadioButtons(ByVal e As EventHandler) As FlowLayoutPanel
            Dim layout As FlowLayoutPanel = UtilsControles.CreerRadioButtons(Me.ValPossibles, Me.ValDefauts, e)
            layout.AutoSize = True
            layout.AutoSizeMode = AutoSizeMode.GrowOnly
            layout.Tag = Me
            Return layout
        End Function

        Private Function CreerNumericUpDown(ByVal e As EventHandler) As NumericUpDown
            Dim nud As New NumericUpDown
            With nud
                .DecimalPlaces = IntegerParse(Me.ValeursPossibles).GetValueOrDefault(0)
                .Minimum = -10000
                .Maximum = 10000
                .Value = DecimalParse(Me.ValeursDefaut).GetValueOrDefault(0)
                .Increment = CDec(1 / 10 ^ .DecimalPlaces)
                .Width = 88
                .TextAlign = HorizontalAlignment.Right
                .Tag = Me
                AddHandler .KeyPress, AddressOf Nud_Keypress
                AddHandler .Validated, e
            End With
            Return nud
        End Function

        Private Shared Sub Nud_Keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
            If (e.KeyChar = "."c OrElse e.KeyChar = ","c) AndAlso (e.KeyChar.ToString <> My.Application.Culture.NumberFormat.NumberDecimalSeparator) Then
                SendKeys.Send(My.Application.Culture.NumberFormat.NumberDecimalSeparator)
                e.Handled = True
            End If
        End Sub

        Private Function CreerTimePicker(ByVal e As EventHandler) As TimePicker
            Dim tp As New TimePicker
            With tp
                Dim dt As Date = Date.MinValue
                Date.TryParse(Me.ValeursDefaut, dt)
                If dt > Date.MinValue Then
                    .Value = dt
                Else
                    .Value = Now
                End If
                .Tag = Me
                AddHandler .ValueChanged, e
            End With
            Return tp
        End Function

        Private Function CreerDatePicker(ByVal e As EventHandler) As DateTimePicker
            Return CreerDateTimePicker(DateTimePickerFormat.Short, e)
        End Function

        Private Function CreerDateTimePicker(ByVal format As DateTimePickerFormat, ByVal e As EventHandler) As DateTimePicker
            Dim dtp As New DateTimePicker
            With dtp
                .Format = format
                .ShowUpDown = (format = DateTimePickerFormat.Time)
                .Width = 88
                Dim dt As Date = Date.MinValue
                Date.TryParse(Me.ValeursDefaut, dt)
                If dt > Date.MinValue Then
                    .Value = dt
                Else
                    .Value = Now
                End If
                AddHandler .ValueChanged, e
                .Tag = Me
            End With
            Return dtp
        End Function

        Private Function CreerSeparator() As Ascend.Windows.Forms.GradientCaption
            Dim gc As Ascend.Windows.Forms.GradientCaption = UtilsControles.CreerSeparator(Me.Libelle)
            gc.Tag = Me
            Return gc
        End Function

        Private Function CreerExpression(ByVal e As EventHandler) As Ascend.Windows.Forms.GradientCaption
            'TODO X Peut-être créer un contrôle spécifique avec un bouton de recalcul de la valeur ?
            Dim l As Ascend.Windows.Forms.GradientCaption = UtilsControles.CreerCaption("Expression")
            l.Tag = Me
            AddHandler l.TextChanged, e
            Return l
        End Function

        Public Shared Sub AddValidationHandler(ByVal ctl As Control, ByVal e As EventHandler)
            If TypeOf ctl Is ComboBox Then : AddHandler Cast(Of ComboBox)(ctl).SelectedIndexChanged, e
            ElseIf TypeOf ctl Is CheckBox Then : AddHandler Cast(Of CheckBox)(ctl).CheckedChanged, e
            ElseIf TypeOf ctl Is RadioButton Then : AddHandler Cast(Of RadioButton)(ctl).CheckedChanged, e
            ElseIf TypeOf ctl Is DateTimePicker Then : AddHandler Cast(Of DateTimePicker)(ctl).ValueChanged, e
            ElseIf TypeOf ctl Is TimePicker Then : AddHandler Cast(Of TimePicker)(ctl).ValueChanged, e
            ElseIf TypeOf ctl Is Ascend.Windows.Forms.GradientCaption Then : AddHandler Cast(Of Ascend.Windows.Forms.GradientCaption)(ctl).TextChanged, e
            ElseIf TypeOf ctl Is FlowLayoutPanel Then
                For Each c As Control In Cast(Of FlowLayoutPanel)(ctl).Controls
                    AddValidationHandler(c, e)
                Next
            Else : AddHandler ctl.Validated, e
            End If
        End Sub
#End Region

#Region "Méthodes partagées"
        Public Shared Sub Copy(ByVal source As DefinitionControle, ByVal dest As DefinitionControle)
            With dest
                .nControle = source.nControle
                .IdControle = source.IdControle
                .CodeProduit = source.CodeProduit
                .Ordre = source.Ordre
                .Libelle = source.Libelle
                .Groupe = source.Groupe
                .Type = source.Type
                .ValeursDefaut = source.ValeursDefaut
                .ValeursPossibles = source.ValeursPossibles
                .ListeBaremes.Clear()
                For Each b As Bareme In source.ListeBaremes
                    .ListeBaremes.Add(Cast(Of Bareme)(b.Clone))
                Next
            End With
        End Sub
#End Region

    End Class
End Namespace
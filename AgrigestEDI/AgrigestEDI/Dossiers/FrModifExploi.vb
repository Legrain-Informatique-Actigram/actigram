Public Class FrModifExploi

    Private workExpl As Exploitation
    Private _expl As Exploitation

    Private collapsedBmp As Bitmap
    Private expandedBmp As Bitmap

    Private Const OPTIONS_ON_HEIGHT As Integer = 263
    Private Const OPTIONS_OFF_HEIGHT As Integer = 193
    Private optionsVisibles As Boolean = True

#Region "Propriétés"
    Public Property Exploitation() As Exploitation
        Get
            Return _expl
        End Get
        Set(ByVal value As Exploitation)
            _expl = value
            workExpl = DirectCast(_expl.Clone, Exploitation)
        End Set
    End Property
#End Region

#Region "Page"
    Private Sub FrModifExploi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        collapsedBmp = My.Resources.Collapsed
        collapsedBmp.MakeTransparent(Color.Magenta)
        expandedBmp = My.Resources.Expanded
        expandedBmp.MakeTransparent(Color.Magenta)

        With Me.CbCheminBase
            .BeginUpdate()
            With .Items
                .Clear()
                .Add(New ListboxItem("(Nouveau)", "NEW"))
                .Add(New ListboxItem("(Parcourir...)", Nothing))
            End With
            .EndUpdate()
        End With
        ChargerPlanTypes()
        ConfigNumericControl(Me.CodeExploitationTextBox)

        If Me.Exploitation Is Nothing Then
            Me.Exploitation = New Exploitation
            workExpl.CodeExpl = "C00000"
            Me.CbCheminBase.SelectedIndex = 0
        Else
            Me.CbCheminBase.Text = workExpl.CheminBase
            TrouverPlanType(CheminComplet(workExpl.CheminBasePlanType))
        End If
        Me.ExploitationBindingSource.DataSource = workExpl

        If Me.Exploitation.CodeExpl Is Nothing Then
            CbCheminBase.SelectedIndex = 0
        End If
        If My.Settings.CG = "CO" Then
            'Me.CodeExploitationLettreTextBox.Text = "C"
            Me.CodeExploitationLettreTextBox.Enabled = False
            'Me.CbCheminBasePlanType.SelectedIndex = 0
        End If

        lnkOptions_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "Boutons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Validate()
        Dim codeExpl_Original As String = Me.Exploitation.CodeExpl

        workExpl.CheminBasePlanType = RecupererPlanType()
        workExpl.CheminBase = RecupererCheminBase()

        If codeExpl_Original Is Nothing Then
            'Créer eventuellement la base
            If workExpl.CheminBase = "NEW" Then workExpl.CreerBase()
            'Créer l'exploitation en base
            workExpl.InsertBase()
        Else
            'Maj la base
            workExpl.UpdateBase(codeExpl_Original)
        End If
        Exploitation.Copy(workExpl, Me.Exploitation)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btBrowseBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btBrowseBase.Click, BtBrowseBasePlanType.Click
        Dim title As String = ""
        If sender Is btBrowseBase Then
            title = My.Resources.Strings.Expl_BrowseBDD
        ElseIf sender Is BtBrowseBasePlanType Then
            title = My.Resources.Strings.Expl_BrowseBDDPlanType
        End If
        Dim f As String = BrowseForMdbFile(title)
        If f IsNot Nothing Then
            If sender Is btBrowseBase Then
                CbCheminBase.SelectedIndex = -1
                CbCheminBase.Text = f
            ElseIf sender Is BtBrowseBasePlanType Then
                CbCheminBasePlanType.SelectedIndex = -1
                CbCheminBasePlanType.Text = f
            End If
        End If
    End Sub

    Private Sub lnkOptions_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles lnkOptions.Click
        optionsVisibles = Not optionsVisibles
        If Not optionsVisibles Then
            Me.Height = OPTIONS_OFF_HEIGHT
            lnkOptions.Text = "Afficher les options..."
            lnkOptions.Image = collapsedBmp
        Else
            Me.Height = OPTIONS_ON_HEIGHT
            lnkOptions.Text = "Masquer les options..."
            lnkOptions.Image = expandedBmp
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerPlanTypes()
        With Me.CbCheminBasePlanType
            .BeginUpdate()
            With .Items
                .Clear()
                For Each pt As PlanType In PlanType.Trouver
                    .Add(New ListboxItem(pt.Nom, pt.Chemin))
                Next
                .Add(New ListboxItem("(Parcourir...)", Nothing))
            End With
            .EndUpdate()
        End With
    End Sub

    Private Sub TrouverPlanType(ByVal cheminBase As String)
        Dim trouve As Boolean
        For i As Integer = 0 To Me.CbCheminBasePlanType.Items.Count - 1
            If String.Equals(CStr(CType(Me.CbCheminBasePlanType.Items(i), ListboxItem).Value), cheminBase, StringComparison.InvariantCultureIgnoreCase) Then
                Me.CbCheminBasePlanType.SelectedIndex = i
                trouve = True
            End If
        Next
        If Not trouve Then Me.CbCheminBasePlanType.Text = cheminBase
    End Sub

    Private Function RecupererCheminBase() As String
        If CbCheminBase.SelectedIndex >= 0 Then
            If CType(CbCheminBase.SelectedItem, ListboxItem).Value IsNot Nothing Then
                Return CStr(CType(CbCheminBase.SelectedItem, ListboxItem).Value)
            Else
                btBrowseBase_Click(btBrowseBase, Nothing)
                Return CbCheminBase.Text
            End If
        Else
            Return CbCheminBase.Text
        End If
    End Function

    Private Function RecupererPlanType() As String
        If CbCheminBasePlanType.SelectedIndex >= 0 Then
            If CType(CbCheminBasePlanType.SelectedItem, ListboxItem).Value IsNot Nothing Then
                Return CStr(CType(CbCheminBasePlanType.SelectedItem, ListboxItem).Value)
            Else
                btBrowseBase_Click(BtBrowseBasePlanType, Nothing)
                Return CbCheminBasePlanType.Text
            End If
        Else
            Return CbCheminBasePlanType.Text
        End If
    End Function

    Private Function BrowseForMdbFile(ByVal title As String) As String
        Dim f As String = Nothing
        With OpenFileDialog
            .DefaultExt = "mdb"
            .Filter = "Base de données Access (*.mdb)|*.mdb"
            .FileName = My.Settings.CheminBase.Replace("|DataDirectory|", My.Application.Info.DirectoryPath)
            .Title = title
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                f = .FileName
            End If
        End With
        Return f
    End Function
#End Region

#Region "TextBox Code exploitation"
    Private Sub CodeExploitationLettreTextBox_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles CodeExploitationLettreTextBox.Validated, CodeExploitationTextBox.Validated
        Me.workExpl.CodeExpl = CodeExploitationLettreTextBox.Text & CodeExploitationTextBox.Text
    End Sub

    Private Sub CodeExploitationTextBox_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CodeExploitationTextBox.Validating
        If Me.CodeExploitationTextBox.Text.Length < 5 Then
            Me.CodeExploitationTextBox.Text = Me.CodeExploitationTextBox.Text.PadLeft(5, "0"c)
        End If
    End Sub
#End Region

#Region "ComboBox"
    Private Sub CbCheminBasePlanType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbCheminBasePlanType.TextChanged
        Debug.Print(CbCheminBasePlanType.Text)
    End Sub

    Private Sub CbCheminBasePlanType_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbCheminBasePlanType.Validated
        If CbCheminBasePlanType.SelectedIndex >= 0 Then
            If CType(CbCheminBasePlanType.SelectedItem, ListboxItem).Value IsNot Nothing Then
                workExpl.CheminBasePlanType = CStr(CType(CbCheminBasePlanType.SelectedItem, ListboxItem).Value)
            End If
        End If
    End Sub

    Private Sub CbCheminBase_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbCheminBase.Validated
        If CbCheminBase.SelectedIndex >= 0 Then
            If CType(CbCheminBase.SelectedItem, ListboxItem).Value IsNot Nothing Then
                workExpl.CheminBase = CStr(CType(CbCheminBase.SelectedItem, ListboxItem).Value)
            End If
        End If
    End Sub

    Private Sub CbCheminBasePlanType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbCheminBasePlanType.SelectedIndexChanged
        BtBrowseBasePlanType.Select()
    End Sub

    Private Sub CbCheminBase_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbCheminBase.SelectedIndexChanged
        btBrowseBase.Select()
    End Sub
#End Region

#Region "ExploitationBindingSource"
    Private Sub ExploitationBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExploitationBindingSource.CurrentChanged
        Me.CodeExploitationLettreTextBox.Text = Microsoft.VisualBasic.Left(workExpl.CodeExpl, 1)
        Me.CodeExploitationTextBox.Text = Microsoft.VisualBasic.Mid(workExpl.CodeExpl, 2)
    End Sub

    Private Sub ExploitationBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExploitationBindingSource.CurrentItemChanged
        Me.CodeExploitationLettreTextBox.Text = Microsoft.VisualBasic.Left(workExpl.CodeExpl, 1)
        Me.CodeExploitationTextBox.Text = Microsoft.VisualBasic.Mid(workExpl.CodeExpl, 2)
    End Sub
#End Region

End Class
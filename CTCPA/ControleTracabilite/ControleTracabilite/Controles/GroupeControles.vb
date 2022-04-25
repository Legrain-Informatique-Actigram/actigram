Namespace Controles
    Public Class GroupeControles

        Private _hasChanges As Boolean
        Private _ListeDefinitionsControles As List(Of DefinitionControle)
        Private _ListeResultatsControles As List(Of ResultatControle)

        Private _dicresultats As New Dictionary(Of Integer, ResultatControle)
        Private _expressions As New List(Of Control)

#Region "Propriétés"
        Public Property HasChanges() As Boolean
            Get
                Return _hasChanges
            End Get
            Set(ByVal value As Boolean)
                _hasChanges = value
            End Set
        End Property

        Public Property ListeDefinitionsControles() As List(Of DefinitionControle)
            Get
                Return Me._ListeDefinitionsControles
            End Get
            Set(ByVal value As List(Of DefinitionControle))
                Me._ListeDefinitionsControles = value
            End Set
        End Property

        Public WriteOnly Property ListeResultatsControles() As List(Of ResultatControle)
            Set(ByVal value As List(Of ResultatControle))
                Me._ListeResultatsControles = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal listeDefinitionsControles As List(Of DefinitionControle))
            Me.New()
            Me.ListeDefinitionsControles = listeDefinitionsControles
        End Sub
#End Region

#Region "Méthodes Public"
        Public Function GetResultats() As List(Of ResultatControle)
            Dim res As New List(Of ResultatControle)
            res.AddRange(_dicresultats.Values)
            Return res
        End Function
#End Region

#Region "Page"
        Private Sub GroupeControles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.ListeDefinitionsControles Is Nothing Then Exit Sub
            If Me.ListeDefinitionsControles.Count = 0 Then Exit Sub

            'Construction des contrôles
            Me.Content.Controls.Clear()
            Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.LbTitreGroupe.Text = Me.ListeDefinitionsControles(0).Groupe
            Me.Content.SuspendLayout()
            Me.ListeDefinitionsControles.Sort(AddressOf DefinitionControle.CompareByOrdre)
            For Each def As DefinitionControle In Me.ListeDefinitionsControles
                'Ajouter un label de question
                Dim l As Label = def.CreerLabel
                If l IsNot Nothing Then Me.Content.Controls.Add(l)

                'Ajouter le contrôle qui va bien
                Dim c As Control = def.CreerControl(AddressOf ControlValidated)
                If def.Type = "Expression" Then RegisterExpression(c)
                c.Visible = True

                Me.Content.Controls.Add(c)

                'Pour les Separators
                If l Is Nothing Then
                    Me.Content.SetColumnSpan(c, 3)
                Else
                    'Ajouter le label d'action co
                    Me.Content.Controls.Add(CreerLnkActionCo(def))
                End If

                'Mettre la réponse
                If Me._ListeResultatsControles IsNot Nothing Then
                    Dim res As ResultatControle = def.TrouverResultat(Me._ListeResultatsControles)
                    If res IsNot Nothing Then
                        def.SetResultat(c, res.Resultat)
                        AddResultat(def, res)
                    End If
                End If

                'Filler
                For i As Integer = 3 To Me.Content.ColumnCount - 1
                    Me.Content.Controls.Add(New Label)
                Next
            Next
            AddExpresssionsHandlers()
            Me.Content.Controls.Add(New Label)
            Me.Content.ResumeLayout()
            Me.ValidateChildren()
            Me.HasChanges = False
            Me.Height = Me.LbTitreGroupe.Height + Me.ListeDefinitionsControles.Count * 40
        End Sub
#End Region

#Region "Méthodes diverses"
        Private Function CreerLnkActionCo(ByVal def As DefinitionControle) As LinkLabel
            Dim lnk As New LinkLabel
            With lnk
                .Name = String.Format("ActionCo{0}", def.IdControle)
                .ImageAlign = ContentAlignment.MiddleLeft
                .TextAlign = ContentAlignment.MiddleLeft
                .Padding = New Padding(18, 0, 0, 0)
                .LinkColor = Color.Firebrick
                .Width = 200
                .Visible = True
                .Enabled = False
                AddHandler .Click, AddressOf lnkActionCoClicked
            End With
            Return lnk
        End Function

        Private Sub AddResultat(ByVal def As DefinitionControle, ByVal res As ResultatControle)
            If _dicresultats.ContainsKey(def.IdControle) Then
                _dicresultats.Remove(def.IdControle)
            End If
            If res IsNot Nothing Then _dicresultats.Add(def.IdControle, res)
        End Sub

        Private Function AddResultat(ByVal def As DefinitionControle, ByRef ctl As Control) As ResultatControle
            Dim res As ResultatControle
            If _dicresultats.ContainsKey(def.IdControle) Then
                res = _dicresultats(def.IdControle)
                Dim val As String = CType(def.GetResultat(ctl), String)
                If val <> res.Resultat Then
                    res.Resultat = val
                    res.TraiteResultat()
                    Me.HasChanges = True
                End If
            Else
                res = ResultatControle.GetResultat(ctl)
                If res IsNot Nothing Then _dicresultats.Add(def.IdControle, res)
                Me.HasChanges = True
            End If
            Return res
        End Function

        Private Sub ControlValidated(ByVal sender As Object, ByVal e As EventArgs)
            If Not TypeOf sender Is Control Then Exit Sub
            Dim ctl As Control = DirectCast(sender, Control)
            If ctl.Tag Is Nothing Then
                If ctl.Parent IsNot Nothing AndAlso ctl.Parent.Tag IsNot Nothing Then
                    ctl = ctl.Parent
                Else
                    Exit Sub
                End If
            End If
            If Not TypeOf ctl.Tag Is DefinitionControle Then Exit Sub

            Dim def As DefinitionControle = DirectCast(ctl.Tag, DefinitionControle)
            Dim res As ResultatControle = AddResultat(def, ctl)
            'Debug.Print("{0} : {1} baremes", def.Libelle, def.Baremes.Count)

            If res Is Nothing Then Exit Sub

            ConfigActionCo(def, res)
            MyBase.OnValidated(EventArgs.Empty)
        End Sub
#End Region

#Region " Gestion des actions correctives "
        Private Sub ConfigActionCo(ByVal def As DefinitionControle, ByVal res As ResultatControle)
            Dim cntls() As Control = Me.Content.Controls.Find(String.Format("ActionCo{0}", def.IdControle), True)
            If cntls.Length > 0 Then
                Dim lnk As LinkLabel = CType(cntls(0), LinkLabel)
                With lnk
                    If res.TestEffectue And res.ResultatsBaremesCount > 0 Then
                        .Tag = res
                        If res.ResultatConformite Then
                            .Text = ""
                            .Image = My.Resources.OK
                            .Enabled = False
                        ElseIf res.ToutesActionsCoEffectuees Then
                            .Text = "Actions correctives effectuées"
                            .LinkColor = Color.Blue
                            .Image = My.Resources.OK
                            .Enabled = True
                        Else
                            .Text = "Actions correctives"
                            .LinkColor = Color.Firebrick
                            .Image = My.Resources.Warning
                            'lnkActionCoClicked(lnk, Nothing)
                            .Enabled = True
                        End If
                    Else
                        .Text = ""
                        .Image = Nothing
                        .Tag = Nothing
                    End If
                End With
            End If
        End Sub

        Private Sub lnkActionCoClicked(ByVal sender As Object, ByVal e As EventArgs)
            If Not TypeOf sender Is Control Then Exit Sub
            If DirectCast(sender, Control).Tag Is Nothing Then Exit Sub
            If DirectCast(sender, Control).Text.Length = 0 Then Exit Sub
            If Not TypeOf DirectCast(sender, Control).Tag Is ResultatControle Then Exit Sub

            Dim res As ResultatControle = DirectCast(DirectCast(sender, Control).Tag, ResultatControle)

            Using fr As New FrResultatBareme(res.ListeResultatsBaremes)
                If fr.ShowDialog(Me) = DialogResult.OK Then
                    Me.HasChanges = True
                End If
            End Using

            If res.ToutesActionsCoEffectuees Then
                With DirectCast(sender, LinkLabel)
                    .LinkColor = Color.Blue
                    .Text = "Actions correctives effectuées"
                    .Image = My.Resources.OK
                    .Enabled = True
                End With
            End If
        End Sub
#End Region

#Region "Gestion des expressions"
        Private Sub RegisterExpression(ByVal c As Control)
            _expressions.Add(c)
        End Sub

        Private Sub AddExpresssionsHandlers()
            For Each ctl As Control In _expressions
                Dim ev As New Eval.Evaluator
                AddHandler ev.GetVariable, AddressOf EvAddHandler
                Try
                    ev.Eval(CType(ctl.Tag, DefinitionControle).ValeursPossibles)
                Catch ex As ControleTracabilite.Eval.Evaluator.parserexception
                End Try
            Next
        End Sub

        Private Sub UpdateExpressions(ByVal sender As Object, ByVal e As EventArgs)
            For Each ctl As Control In _expressions
                If TypeOf ctl.Tag Is DefinitionControle Then
                    Dim def As DefinitionControle = CType(ctl.Tag, DefinitionControle)
                    If def.Type = "Expression" Then
                        Dim ev As New Eval.Evaluator
                        AddHandler ev.GetVariable, AddressOf EvGetVariable
                        Try
                            Dim value As Object = ev.Eval(def.ValeursPossibles)
                            If TypeOf value Is Double Then
                                value = Math.Round(CDbl(value), 2, MidpointRounding.AwayFromZero)
                            End If
                            ctl.Text = value.ToString
                            ControlValidated(ctl, Nothing)
                            ctl.ForeColor = SystemColors.WindowText
                        Catch ex As Eval.Evaluator.parserexception
                            LogException(ex)
                            ctl.Text = ex.Message
                            ctl.ForeColor = Color.Red
                        End Try
                    End If
                End If
            Next
        End Sub

        Private Sub EvAddHandler(ByVal name As String, ByRef value As Object)
            Dim ctl As Control = FindControl(name)
            If ctl IsNot Nothing Then
                DefinitionControle.AddValidationHandler(ctl, AddressOf UpdateExpressions)
            End If
            value = 0
        End Sub

        Private Sub EvGetVariable(ByVal name As String, ByRef value As Object)
            Dim ctl As Control = FindControl(name)
            If ctl IsNot Nothing Then
                value = Cast(Of DefinitionControle)(ctl.Tag).GetResultat(ctl)
            Else
                value = Nothing
            End If
        End Sub

        Private Function FindControl(ByVal name As String) As Control
            If name.StartsWith("c") Then
                Dim id As Integer
                If Integer.TryParse(name.Substring(1), id) Then
                    For Each ctl As Control In Me.Content.Controls
                        If TypeOf ctl.Tag Is DefinitionControle Then
                            If CType(ctl.Tag, DefinitionControle).IdControle = id Then
                                Return ctl
                            End If
                        End If
                    Next
                End If
            End If
            Return Nothing
        End Function
#End Region

    End Class
End Namespace
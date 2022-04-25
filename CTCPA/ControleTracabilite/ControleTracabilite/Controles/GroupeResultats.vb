Namespace Controles
    Public Class GroupeResultats

#Region "Propriétés"
        Private _resultats As List(Of ResultatControle)
        Public Property Resultats() As List(Of ResultatControle)
            Get
                Return _resultats
            End Get
            Set(ByVal value As List(Of ResultatControle))
                _resultats = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal list As List(Of ResultatControle))
            Me.New()
            Me.Resultats = list
        End Sub
#End Region

#Region "Page"
        Private Sub GroupeControles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Me.Resultats Is Nothing Then Exit Sub
            If Me.Resultats.Count = 0 Then Exit Sub
            Me.Content.Controls.Clear()
            Me.AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.LbTitreGroupe.Text = Me.Resultats(0).DefinitionControle.Groupe
            Me.Content.SuspendLayout()

            Dim cntRes As Integer = 0
            Dim cntResB As Integer = 0
            Dim list As List(Of ResultatControle) = Me.Resultats.FindAll(AddressOf ResultatControle.IsNonConforme)
            Dim g As Graphics = Me.CreateGraphics
            For Each res As ResultatControle In list
                cntRes += 1
                'QUESTION
                Dim l As Label = res.DefinitionControle.CreerLabel
                Me.Content.Controls.Add(l)

                Me.Content.Controls.Add(UtilsControles.CreerCaption(res.Resultat))

                'CONFORMITE
                l = New Label
                l.TextAlign = ContentAlignment.MiddleLeft
                l.Text = "Conformité:"
                Me.Content.Controls.Add(l)

                Dim gc As Ascend.Windows.Forms.GradientCaption = UtilsControles.CreerCaption(CStr(IIf(res.ResultatConformite, "Conforme", "Non conforme")))
                gc.ForeColor = CType(IIf(res.ResultatConformite, Color.Black, Color.Red), Color)
                Me.Content.Controls.Add(gc)


                For Each rb As ResultatBareme In res.ListeResultatsBaremes
                    If Not rb.ResultatExpression Then
                        gc = UtilsControles.CreerSeparator(String.Format("BAREME : {0}", rb.BaremeExpression))
                        Me.Content.Controls.Add(gc)
                        Me.Content.SetColumnSpan(gc, 2)

                        l = New Label
                        l.Text = "Action corrective:"
                        l.TextAlign = ContentAlignment.MiddleLeft
                        Me.Content.Controls.Add(l)
                        'Me.Content.SetColumnSpan(l, 2)

                        Dim chk As New CheckBox
                        With chk
                            .Text = "Effectuée"
                            .Dock = DockStyle.Fill
                            .Checked = rb.ActionCorrectiveEffectuee
                            .CheckAlign = ContentAlignment.MiddleRight
                            .TextAlign = ContentAlignment.MiddleRight
                            .AutoSize = True
                            .Name = "ChkEffectue"
                            .Tag = rb
                        End With
                        Me.Content.Controls.Add(chk)

                        'l = New Label
                        'l.Text = rb.ResultatExpression.ToString
                        'Me.Content.Controls.Add(l)

                        gc = UtilsControles.CreerCaption(rb.ActionCorrective)
                        With gc
                            .TextAlign = ContentAlignment.TopLeft
                            .Width = Me.Content.ClientSize.Width
                            .Height = CInt(Math.Ceiling(g.MeasureString(.Text, .Font, .Width).Height)) + .Padding.Top + .Padding.Bottom + 15
                            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                        End With
                        Me.Content.Controls.Add(gc)
                        Me.Content.SetColumnSpan(gc, 2)

                        cntResB += gc.Height

                        l = New Label
                        l.Text = "Observations:"
                        l.TextAlign = ContentAlignment.MiddleLeft
                        Me.Content.Controls.Add(l)
                        Me.Content.SetColumnSpan(l, 2)

                        Dim tx As New TextBox
                        With tx
                            .Multiline = True
                            .Width = Me.Content.ClientRectangle.Width
                            .Width = Me.Content.ClientSize.Width
                            .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                            .Height = 100
                            .ScrollBars = ScrollBars.Both
                            .Visible = True
                        End With
                        Me.Content.Controls.Add(tx)
                        Me.Content.SetColumnSpan(tx, 2)

                        cntResB += 175
                    End If
                Next
            Next
            Me.Content.Controls.Add(New Label)
            Me.Content.ResumeLayout()
            Me.Height = Me.LbTitreGroupe.Height + cntRes * 60 + cntResB + 20
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetResultats() As List(Of ResultatControle)
            Dim res As New List(Of ResultatControle)
            For Each ctl As Control In Me.Content.Controls
                If TypeOf ctl.Tag Is DefinitionControle Then
                    Dim r As ResultatControle = ResultatControle.GetResultat(ctl)
                    If r IsNot Nothing Then res.Add(r)
                End If
            Next
            Return res
        End Function
#End Region

    End Class
End Namespace
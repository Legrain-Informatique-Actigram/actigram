'TODO Une fois terminé => Enregistrement pour consultation ultérieure
Imports ControleTracabilite.Controles

Public Class FrApercuActionCo

    Private _resultats As List(Of ResultatControle)
    Public Property Resultats() As List(Of ResultatControle)
        Get
            Return _resultats
        End Get
        Set(ByVal value As List(Of ResultatControle))
            _resultats = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal resultats As List(Of ResultatControle))
        Me.New()
        Me.Resultats = resultats
    End Sub

    Private Sub BtFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFermer.Click
        Me.Close()
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Content.Controls.Clear()
        If Me.Resultats Is Nothing Then Exit Sub
        If Me.Resultats.Count = 0 Then Exit Sub

        Dim hash As New Dictionary(Of String, List(Of ResultatControle))
        For Each res As ResultatControle In Me.Resultats
            If Not hash.ContainsKey(res.Controle.GroupeControle) Then
                Dim list As New List(Of ResultatControle)
                list.Add(res)
                hash.Add(res.Controle.GroupeControle, list)
            Else
                Dim list As List(Of ResultatControle) = CType(hash(res.Controle.GroupeControle), List(Of ResultatControle))
                list.Add(res)
            End If
        Next

        Me.Content.SuspendLayout()
        For Each groupe As String In hash.Keys
            Dim gr As New GroupeResultats(hash(groupe))
            With gr
                .Margin = New Padding(3, 3, 3, 10)
                .Dock = DockStyle.Fill
            End With
            Me.Content.Controls.Add(gr)
        Next
        'Dernière ligne filler
        Me.Content.Controls.Add(New Label)
        Me.Content.ResumeLayout()
    End Sub
End Class
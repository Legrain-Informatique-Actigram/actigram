Imports ControleTracabilite.Controles
Public Class FrApercuControles

    'TODO_TOP Problème d'affichage des radiobuttons si trop large
    'TODO 9 Sans doute des choses à revoir sur l'organisation des contrôles et le déplacement de l'ordre des contrôles

    Private modif As Boolean
    Private hasSavedResultats As Boolean

    Private _ListeDefinitionsControles As List(Of DefinitionControle)
    Private _ListeResultatsControles As List(Of ResultatControle)
    Private _CodeProduit As String
    Private _nLot As String

#Region "Propriétés "
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

    Public Property CodeProduit() As String
        Get
            Return Me._CodeProduit
        End Get
        Set(ByVal value As String)
            Me._CodeProduit = value
        End Set
    End Property

    Public Property nLot() As String
        Get
            Return Me._nLot
        End Get
        Set(ByVal value As String)
            Me._nLot = value
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

    Public Sub New(ByVal listeDefinitionsControles As List(Of DefinitionControle), ByVal listeResultatsControles As List(Of ResultatControle))
        Me.New()
        Me.ListeDefinitionsControles = listeDefinitionsControles
        Me.ListeResultatsControles = listeResultatsControles
    End Sub

    Public Sub New(ByVal listeDefinitionsControles As List(Of DefinitionControle), ByVal codeProduit As String, ByVal nLot As String)
        Me.New(listeDefinitionsControles)
        Me.CodeProduit = codeProduit
        Me.nLot = nLot
    End Sub

    Public Sub New(ByVal listeDefinitionsControles As List(Of DefinitionControle), ByVal listeResultatsControles As List(Of ResultatControle), ByVal codeProduit As String, ByVal nLot As String)
        Me.New()
        Me.ListeDefinitionsControles = listeDefinitionsControles
        Me.ListeResultatsControles = listeResultatsControles
        Me.CodeProduit = codeProduit
        Me.nLot = nLot
    End Sub
#End Region

#Region "Form"
    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        'legrain le 4/9/2013, modification pour fenêtre plus haute
        Me.WindowState = FormWindowState.Maximized

        Me.Content.Controls.Clear()

        If Me.ListeDefinitionsControles Is Nothing Then Exit Sub
        If Me.ListeDefinitionsControles.Count = 0 Then Exit Sub

        Dim hashControles As New Dictionary(Of String, List(Of DefinitionControle))
        For Each def As DefinitionControle In Me.ListeDefinitionsControles
            TriControle(hashControles, def)
        Next

        Dim hashRes As Dictionary(Of String, List(Of ResultatControle)) = Nothing
        If Me._ListeResultatsControles IsNot Nothing Then
            hashRes = New Dictionary(Of String, List(Of ResultatControle))
            For Each res As ResultatControle In Me._ListeResultatsControles
                TriResultat(hashRes, res)
            Next
        End If

        Me.Content.SuspendLayout()
        For Each groupe As String In hashControles.Keys
            Dim gr As New GroupeControles(hashControles(groupe))
            With gr
                If hashRes IsNot Nothing AndAlso hashRes.ContainsKey(groupe) Then
                    gr.ListeResultatsControles = hashRes(groupe)
                End If
                .Margin = New Padding(3, 3, 3, 10)
                .Dock = DockStyle.Fill
                'AddHandler .Validated, AddressOf ControleValidated
            End With
            Me.Content.Controls.Add(gr)
        Next
        'Dernière ligne filler
        Me.Content.Controls.Add(New Label)
        Me.Content.ResumeLayout()
        modif = True
        MajBoutons()
        modif = False
        If Me.NLot Is Nothing Then
            Me.BtOK.Visible = False
        End If
    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If BtOK.Visible AndAlso e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If hasSavedResultats Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
        Me.Close()
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        If Enregistrer() Then
            MajBoutons()
        End If
    End Sub

    Private Sub BtImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImprimer.Click
        GroupeControle.Imprimer(Me.ListeDefinitionsControles)
    End Sub
#End Region

#Region "Données"
    Private Function GetResultats() As List(Of ResultatControle)
        Dim listeResultatsControles As New List(Of ResultatControle)

        For Each ctl As Control In Me.Content.Controls
            If TypeOf ctl Is GroupeControles Then
                listeResultatsControles.AddRange(CType(ctl, GroupeControles).GetResultats)
            End If
        Next

        If Me.NLot IsNot Nothing Then
            For Each r As ResultatControle In listeResultatsControles
                r.nLot = NLot
            Next
        End If

        Return listeResultatsControles
    End Function

    Private Function Enregistrer() As Boolean
        Try
            Dim listeResultatsControles As List(Of ResultatControle) = Me.GetResultats

            'Enregistrer le resultat en base 
            Using resultatControleTA As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                Using resultatBaremeTA As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                    ResultatControle.Effacer(Me.CodeProduit, Me.NLot, resultatControleTA, resultatBaremeTA)
                    ResultatControle.Enregistrer(listeResultatsControles, resultatControleTA, resultatBaremeTA)
                    hasSavedResultats = listeResultatsControles.Count > 0
                End Using
            End Using

            modif = False

            Return True
        Catch ex As Exception
            LogException(ex)
            MsgBox("Erreur d'enregistrement :" & ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try
    End Function

    Private Function DemanderEnregistrement() As Boolean
        If Me.Validate() Then
            If modif Then
                Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        Return Enregistrer()
                    Case MsgBoxResult.No
                    Case MsgBoxResult.Cancel
                        Return False
                End Select
            End If
            Return True
        Else
            Return MsgBox("Impossible d'enregistrer les données." & vbCrLf & "Voulez-vous abandonner les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes
        End If
    End Function
#End Region

#Region "Méthodes diverses"
    Private Sub TriControle(ByVal hashControles As Dictionary(Of String, List(Of DefinitionControle)), ByVal def As DefinitionControle)
        If Not hashControles.ContainsKey(def.Groupe) Then
            Dim list As New List(Of DefinitionControle)
            list.Add(def)
            hashControles.Add(def.Groupe, list)
        Else
            hashControles(def.Groupe).Add(def)
        End If
    End Sub

    Private Sub TriResultat(ByVal hashRes As Dictionary(Of String, List(Of ResultatControle)), ByVal res As ResultatControle)
        If Not hashRes.ContainsKey(res.DefinitionControle.Groupe) Then
            Dim list As New List(Of ResultatControle)
            list.Add(res)
            hashRes.Add(res.DefinitionControle.Groupe, list)
        Else
            hashRes(res.DefinitionControle.Groupe).Add(res)
        End If
    End Sub

    Private Sub ControleValidated(ByVal sender As Object, ByVal e As EventArgs)
        modif = CType(sender, GroupeControles).HasChanges
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        BtOK.Enabled = modif
    End Sub
#End Region

End Class
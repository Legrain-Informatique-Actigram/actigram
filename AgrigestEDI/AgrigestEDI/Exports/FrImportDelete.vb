Imports System.Windows.Forms

''' <summary>
''' permet de gérer l'écrasement, l'ajout d'exercice a partir d'un import isa ou ecr
''' </summary>
''' <remarks></remarks>
Public Class FrImportDelete

    Public Enum ActionDossier
        AddEcritures
        ResetDossier
        Skip
    End Enum

    Private _nouveauDossier As Boolean
    Public Property NouveauDossier() As Boolean
        Get
            Return _nouveauDossier
        End Get
        Set(ByVal value As Boolean)
            _nouveauDossier = value
        End Set
    End Property

    Private _Action As ActionDossier
    ''' <summary>
    ''' défini le type d'action à effectuer
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Action() As ActionDossier
        Get
            Return _Action
        End Get
        Set(ByVal value As ActionDossier)
            _Action = value
        End Set
    End Property

    Private _sDossier As String
    ''' <summary>
    ''' nom du dossier
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property sDossier() As String
        Get
            Return _sDossier
        End Get
        Set(ByVal value As String)
            _sDossier = value
        End Set
    End Property

    ''' <summary>
    ''' retourne le type d'action à effectuer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If rbtAdd.Checked Then
            Action = ActionDossier.AddEcritures
        ElseIf rbtDelete.Checked Then
            Action = ActionDossier.ResetDossier
            If MsgBox(My.Resources.Strings.Import_ConfirmationEcraseDossier, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        Else
            Action = ActionDossier.Skip
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    ''' <summary>
    ''' bouton d'annulation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' lancement
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrImportDelete_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetChildFormIcon(Me)
        Select Case Action
            Case ActionDossier.AddEcritures : rbtAdd.Checked = True
            Case ActionDossier.ResetDossier : rbtDelete.Checked = True
            Case ActionDossier.Skip : rbtNothing.Checked = True
        End Select
        If NouveauDossier Then
            rbtDelete.Visible = False
            rbtAdd.Text = "Importer le dossier"
        End If
        lblMessage.Text = String.Format(lblMessage.Text, sDossier)
    End Sub

End Class

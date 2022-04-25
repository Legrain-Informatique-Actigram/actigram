Imports System.Windows.Forms

Public Class LongMessageBox

#Region "Form"
    Private Sub LongMessageBox_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.TxDetails.DeselectAll()
    End Sub
#End Region

#Region "Méthodes partagées"
    Public Shared Function ShowMessage(ByVal message As String, Optional ByVal details As String = "", Optional ByVal title As String = "", Optional ByVal options As Microsoft.VisualBasic.MsgBoxStyle = MsgBoxStyle.OkOnly) As DialogResult
        Dim fr As New LongMessageBox
        With fr
            If title = "" Then
                .Text = My.Application.Info.Title
            Else
                .Text = title
            End If
            .lbMessage.Text = message
            .TxDetails.Text = details

            'Gestion de l'image
            If HasOption(options, MsgBoxStyle.Information) Then : .pcIcon.Image = SystemIcons.Information.ToBitmap
            ElseIf HasOption(options, MsgBoxStyle.Exclamation) Then : .pcIcon.Image = SystemIcons.Exclamation.ToBitmap
            ElseIf HasOption(options, MsgBoxStyle.Critical) Then : .pcIcon.Image = SystemIcons.Error.ToBitmap
            ElseIf HasOption(options, MsgBoxStyle.Question) Then : .pcIcon.Image = SystemIcons.Question.ToBitmap
            Else : .pcIcon.Visible = False : .lbMessage.Left = .pcIcon.Left
            End If

            'Gestion des boutons
            If HasOption(options, MsgBoxStyle.AbortRetryIgnore) Then : .SetButtonsResult(DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore)
            ElseIf HasOption(options, MsgBoxStyle.OkCancel) Then : .SetButtonsResult(DialogResult.OK, DialogResult.Cancel)
            ElseIf HasOption(options, MsgBoxStyle.RetryCancel) Then : .SetButtonsResult(DialogResult.Retry, DialogResult.Cancel)
            ElseIf HasOption(options, MsgBoxStyle.YesNo) Then : .SetButtonsResult(DialogResult.Yes, DialogResult.No)
            ElseIf HasOption(options, MsgBoxStyle.YesNoCancel) Then : .SetButtonsResult(DialogResult.Yes, DialogResult.No, DialogResult.Cancel)
            Else : .SetButtonsResult(DialogResult.OK)
            End If
            If HasOption(options, MsgBoxStyle.DefaultButton2) Then : .AcceptButton = .Button2
            ElseIf HasOption(options, MsgBoxStyle.DefaultButton3) Then : .AcceptButton = .Button3
            Else : .AcceptButton = .Button1
            End If
            Return .ShowDialog()
        End With
    End Function

    Private Shared Function HasOption(ByVal options As MsgBoxStyle, ByVal style As MsgBoxStyle) As Boolean
        Return (options And style) = style
    End Function
#End Region

#Region "Boutons"
    Private Sub Bt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles Button1.Click, Button2.Click, Button3.Click
        Me.DialogResult = CType(CType(sender, Button).Tag, DialogResult)
        Me.Close()
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub SetButtonsResult(ByVal result1 As DialogResult)
        ConfigButton(Button1, result1)
        Button2.Visible = False
        Button3.Visible = False
    End Sub

    Private Sub SetButtonsResult(ByVal result1 As DialogResult, ByVal result2 As DialogResult)
        ConfigButton(Button1, result1)
        ConfigButton(Button2, result2)
        Button3.Visible = False
    End Sub

    Private Sub SetButtonsResult(ByVal result1 As DialogResult, ByVal result2 As DialogResult, ByVal result3 As DialogResult)
        ConfigButton(Button1, result1)
        ConfigButton(Button2, result2)
        ConfigButton(Button3, result3)
    End Sub

    Private Sub ConfigButton(ByVal bt As Button, ByVal res As DialogResult)
        bt.Visible = True
        bt.Text = GetText(res)
        bt.Tag = res
    End Sub

    Private Function GetText(ByVal res As DialogResult) As String
        Select Case res
            Case DialogResult.Abort : Return "&Abandonner"
            Case DialogResult.Cancel : Return "Annuler"
            Case DialogResult.Ignore : Return "&Ignorer"
            Case DialogResult.No : Return "&Non"
            Case DialogResult.OK : Return "&OK"
            Case DialogResult.Retry : Return "&Réessayer"
            Case DialogResult.Yes : Return "&Oui"
            Case Else : Return res.ToString
        End Select
    End Function
#End Region

End Class

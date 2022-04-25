Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class FrParamVNC

#Region "Propriétés"
    Public Property AdresseVNC() As String
        Get
            Return TxtAdresse.Text
        End Get
        Set(ByVal value As String)
            TxtAdresse.Text = value
        End Set
    End Property

    Public Property AdresseVNCID() As Integer
        Get
            Return CInt(nudID.Value)
        End Get
        Set(ByVal value As Integer)
            nudID.Value = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
        Me.AdresseVNC = My.Settings.AdresseVNC
        Me.AdresseVNCID = My.Settings.AdresseVNCID
    End Sub

    Public Sub New(ByVal AdresseVNC As String, ByVal ID As Integer)
        Me.New()
        Me.AdresseVNC = AdresseVNC
        Me.AdresseVNCID = ID
    End Sub
#End Region

#Region "Form"
    Private Sub FrParamVNC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetChildFormIcon(Me)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Function ValideAdresse(ByVal adresse As String) As Boolean
        Dim re As New Regex("^\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(:?[0-9]{1,4})?\b$")
        Return re.IsMatch(adresse)
    End Function
#End Region

    Private Sub TxtAdresse_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAdresse.Validated
        If Me.AdresseVNC.Length = 0 Then
            Me.OK_Button.Enabled = False
        Else
            If ValideAdresse(Me.AdresseVNC) Then
                Me.OK_Button.Enabled = True
            Else
                MsgBox("L'adresse entrée est incorrecte.", MsgBoxStyle.Exclamation)
                Me.OK_Button.Enabled = False
            End If
        End If
    End Sub

End Class
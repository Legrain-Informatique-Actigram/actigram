Public Class FrOptionsRestauration


#Region " Props "
    Private conn As SqlProxy
    Public Property Connection() As SqlProxy
        Get
            Return conn
        End Get
        Set(ByVal value As SqlProxy)
            conn = value
        End Set
    End Property


    Private _nomBase As String
    Public Property NomBase() As String
        Get
            Return _nomBase
        End Get
        Set(ByVal value As String)
            _nomBase = value
        End Set
    End Property


    Private _repData As String
    Public Property RepData() As String
        Get
            Return _repData
        End Get
        Set(ByVal value As String)
            _repData = value
        End Set
    End Property
#End Region


#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal conn As SqlProxy, ByVal nombase As String, ByVal repdata As String)
        Me.New()
        Me.Connection = conn
        Me.NomBase = nombase
        Me.RepData = repdata
    End Sub
#End Region

#Region "Données"
    Private modif As Boolean = False
    Private hasChange As Boolean = False

    Private Sub ChargerDonnees()
        Using reader As SqlClient.SqlDataReader = conn.ExecuteReader("SELECT name FROM sysdatabases WHERE dbid>4 ORDER BY name")
            Me.cbNomBase.Items.Clear()
            While reader.Read
                Me.cbNomBase.Items.Add(CStr(reader("name")))
            End While
        End Using

        Dim pos As Integer = Me.cbNomBase.FindStringExact(Me.NomBase)
        If pos >= 0 Then
            Me.cbNomBase.SelectedIndex = pos
        Else
            Me.cbNomBase.Text = Me.NomBase
        End If
        If Me.RepData.Length = 0 Then
            Me.TxRepData.Text = IO.Path.Combine(Application.StartupPath, "Data")
        Else
            Me.TxRepData.Text = Me.RepData
        End If
        'modif = False
        MajBoutons()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        If modif Then
            Me.NomBase = Me.cbNomBase.Text
            Me.RepData = Me.TxRepData.Text
            modif = False
            hasChange = True
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        If modif Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                    My.Settings.Reload()
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function
#End Region

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If hasChange Then Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ChargerDonnees()
    End Sub

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNomBase.TextChanged, TxRepData.TextChanged
        TxRepData.ReadOnly = (cbNomBase.SelectedIndex >= 0)
        modif = True
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        BtOK.Enabled = modif
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Try
            Enregistrer()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

End Class

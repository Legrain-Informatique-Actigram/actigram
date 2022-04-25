Public Class FrParametres

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
        Me.MySettingsBindingSource.DataSource = GetType(My.MySettings)
    End Sub
#End Region

#Region "Données"
    Private modif As Boolean = False

    Private Sub ChargerDonnees()
        MySettingsBindingSource.DataSource = My.Settings
        Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString = My.Settings.ConnString
        modif = False
        MajBoutons()
        AddHandler My.Settings.PropertyChanged, AddressOf MySettings_PropertyChanged
    End Sub

    Private Sub MySettings_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
        modif = True
        MajBoutons()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        If modif Then
            SqlProxy.SetDefaultConnection(Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString)
            My.Settings.Save()
            modif = False
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

#Region "Form Events"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ChargerDonnees()
    End Sub
#End Region

#Region "Controls events"
    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SqlConnectionConfig.Validated
        modif = True
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        ProduitBindingNavigatorSaveItem.Enabled = modif
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFermer.Click
        Me.Close()
    End Sub

    Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub
#End Region

End Class

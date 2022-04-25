Public Class FrParametres

 
#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
        Me.MySettingsBindingSource.DataSource = GetType(My.MySettings)
    End Sub
#End Region

#Region "Données"
    Private modif As Boolean = False
    Private hasChange As Boolean = False

    Private Sub ChargerDonnees()
        Me.FamilleTableAdapter.Fill(Me.DsAgrifact.Famille)
        Me.TVATableAdapter.Fill(Me.DsAgrifact.TVA)
        Me.ProduitTableAdapter.Fill(Me.DsAgrifact.Produit)
        DossierBindingSource.DataSource = Dossier.ChargerDossiersAgrifact
        MySettingsBindingSource.DataSource = My.Settings
        Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString = My.Settings.ConnAgrifact
        Me.cbDossiers.SelectedValue = My.Settings.LastDossier
        modif = False
        MajBoutons()
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        If modif Then
            SqlProxy.SetDefaultConnection(Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString)
            My.Settings.LastDossier = Me.cbDossiers.SelectedValue
            My.Settings.Save()
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
        AddHandler My.Settings.PropertyChanged, AddressOf MySettings_PropertyChanged
    End Sub

    Private Sub MySettings_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs)
        modif = True
        MajBoutons()
    End Sub

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles SqlConnectionConfig.Validated, cbDossiers.SelectedIndexChanged
        modif = True
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        ProduitBindingNavigatorSaveItem.Enabled = modif
    End Sub

#Region "Toolbar"
    Private Sub TbFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub ProduitBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduitBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub
#End Region

    Private Sub lnkLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start(My.Application.Log.DefaultFileLogWriter.FullLogFileName)
    End Sub

    Private Sub cbDossiers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDossiers.SelectedIndexChanged
        If cbDossiers.SelectedIndex < 0 Then Exit Sub
        Dim d As Dossier = cbDossiers.SelectedItem
        Me.SqlConnectionConfig.ConnectionStringBuilder.ConnectionString = d.ConnString
    End Sub

    Private Sub CompteTextBox_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompteClientDefautTextBox.Validated, CompteProduitDefautTextBox.Validated
        If CType(sender, TextBox).Text.Length < 8 Then
            CType(sender, TextBox).Text = CType(sender, TextBox).Text.PadRight(8, "0"c)
        End If
    End Sub
End Class

Imports GRC

Public Class GestionControles
    Inherits GestionControlesBase

#Region " Shared "
    Public Shared Sub FillTablesConfig(ByVal ds As DataSet)
        'Il faut charger Niveau1,Niveau2 et ListeChoix
        Using s As New SqlProxy()
            FillTablesConfig(ds, s)
        End Using
    End Sub

    Public Shared Sub FillTablesConfig(ByVal ds As DataSet, ByVal s As SqlProxy)
        s.Fill(ds, "Niveau1")
        s.Fill(ds, "Niveau2")
        s.Fill(ds, "ListeChoix")
    End Sub

    Public Shared Function GetFiltreAffichage() As String
        Dim strFiltreAffichage As String = ""
        If FrApplication.Modules.ModuleAchat Then
            strFiltreAffichage = "FiltrePlus='Achat'"
        End If
        If FrApplication.Modules.ModuleReglement Then
            If strFiltreAffichage.Length > 0 Then
                strFiltreAffichage += " or "
            End If
            strFiltreAffichage += "FiltrePlus='Reglement'"
        End If
        If FrApplication.Modules.ModuleGestionWeb Then
            If strFiltreAffichage.Length > 0 Then
                strFiltreAffichage += " or "
            End If
            strFiltreAffichage += "FiltrePlus='GestionWeb'"
        End If
        If FrApplication.Modules.ModuleStock Then
            If strFiltreAffichage.Length > 0 Then
                strFiltreAffichage += " or "
            End If
            strFiltreAffichage += "FiltrePlus='Stock'"
        End If
        If FrApplication.Modules.ModuleTarif Then
            If strFiltreAffichage.Length > 0 Then
                strFiltreAffichage += " or "
            End If
            strFiltreAffichage += "FiltrePlus='Tarif'"
        End If
        If strFiltreAffichage.Length > 0 Then
            strFiltreAffichage += " or "
        End If
        strFiltreAffichage += "FiltrePlus Is Null"

        Return strFiltreAffichage
    End Function
#End Region

    Private Sub GestionControles_AffichenEnregistrement(ByVal strType As String, ByRef momDataset As System.Data.DataSet, ByVal nEnregistrement As Object, ByRef fr As GRC.FrBase) Handles MyBase.AffichenEnregistrement
        Select Case strType
            Case "Personne"
                fr = New FrPersonne(CInt(nEnregistrement))
            Case "Entreprise"
                fr = New FrEntreprise(CInt(nEnregistrement))
            Case "Evenement"
                fr = New FrEvenement(CInt(nEnregistrement))
                'Case Else
                '    RaiseEvent AfficheEnregistrement(strType, momDataset, nEnregistrement)
        End Select
    End Sub

    Private Sub GestionControles_AfficheNew(ByVal strType As String, ByRef momDataset As System.Data.DataSet, ByVal nouveau As Boolean, ByRef fr As GRC.FrBase) Handles MyBase.AfficheNew
        Select Case strType
            Case "Personne"
                fr = New FrPersonne()
            Case "Entreprise"
                fr = New FrEntreprise()
            Case "Evenement"
                fr = New FrEvenement()
                'Case Else
                '    RaiseEvent AfficheNouveau(strType, momDataset)
        End Select
    End Sub

    Private Sub GestionControles_AfficheNewPerso(ByVal sender As Object, ByVal strType As String) Handles MyBase.AfficheNewPerso
        Select Case strType
            Case "Banque"
                If TypeOf Me.ParentForm Is GRC.FrBase Then
                    Dim FrB As New FrBanque()
                    FrB.Tag = sender
                    AddHandler FrB.FormClosed, AddressOf FormNewPersoClosed
                    FrB.Owner = Me.ParentForm
                    FrB.Show()
                End If
            Case "Tarif"
                If TypeOf Me.ParentForm Is GRC.FrBase Then
                    Dim FrT As New FrAssistantTarif()
                    FrT.Tag = sender
                    AddHandler FrT.FormClosed, AddressOf FormNewPersoClosed
                    FrT.Owner = Me.ParentForm
                    FrT.Show()
                End If
        End Select
    End Sub

    Private Sub FormNewPersoClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        If e.CloseReason = CloseReason.UserClosing Or e.CloseReason = CloseReason.None Then
            If TypeOf sender Is FrBanque Then
                'Recharger les banques
                MyBase.OnMustRefreshTable(Me, New System.ComponentModel.RefreshEventArgs("Banque"))
                'Recharger le contenu de la combo
                If CType(sender, FrBanque).Tag IsNot Nothing Then
                    If TypeOf CType(sender, FrBanque).Tag Is BtCtl Then
                        Dim cb As CbCtl = CType(CType(CType(CType(sender, FrBanque).Tag, BtCtl).Tag, Hashtable).Item("Control"), CbCtl)
                        Dim rws() As DataRow = DsBase.Tables("Banque").Select
                        FillCb(rws, cb, "Libelle", "nBanque", Nothing, False, Not cb.IsObligatoire)
                        'Ca ne suffit pas vraiment....
                    End If
                End If
            ElseIf TypeOf sender Is FrAssistantTarif Then
                If CType(sender, FrAssistantTarif).DialogResult = DialogResult.OK Then
                    'Recharger les tarifs
                    MyBase.OnMustRefreshTable(Me, New System.ComponentModel.RefreshEventArgs("Tarif"))
                    'Recharger le contenu de la combo
                    If CType(sender, FrAssistantTarif).Tag IsNot Nothing Then
                        If TypeOf CType(sender, FrAssistantTarif).Tag Is BtCtl Then
                            Dim cb As CbCtl = CType(CType(CType(CType(sender, FrAssistantTarif).Tag, BtCtl).Tag, Hashtable).Item("Control"), CbCtl)
                            Dim rws() As DataRow = DsBase.Tables("Tarif").Select
                            FillCb(rws, cb, "Libelle", "nTarif", Nothing, False, Not cb.IsObligatoire)
                            'Ca ne suffit pas vraiment....
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Class

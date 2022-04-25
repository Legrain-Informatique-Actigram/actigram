''' <summary>
''' classe des listes de Modèle
''' </summary>
''' <remarks></remarks>
Public Class ListOfModeles
    Inherits List(Of Modele)

    Private Shared xListModele As ArrayList

#Region "Propriétés"
    Private _IsNewModele As Boolean = False
    Public Property IsNewModele() As Boolean
        Get
            Return _IsNewModele
        End Get
        Set(ByVal value As Boolean)
            _IsNewModele = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()

    End Sub
#End Region

#Region "Méthodes diverses"
    ''' <summary>
    ''' Permet de charger la liste des modèles au complet
    ''' </summary>
    ''' <param name="worker"></param>
    ''' <remarks></remarks>
    Public Sub Charger(Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing)
        Try
            Me.AddRange(ChargerList(worker))
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Permet de charger la liste des modèles au complet
    ''' </summary>
    ''' <param name="worker"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChargerList(Optional ByVal worker As System.ComponentModel.BackgroundWorker = Nothing) As List(Of Modele)

        ReportProgress(worker, 0)
        Dim Dossier As DossierPrincipal = CType(My.User.CurrentPrincipal, DossierPrincipal)
        Dim ds As New dbDonneesDataSet
        Dim dtListModele As New DataTable
        'Chargement depuis la base
        ReportProgress(worker, 20)
        Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
            dta.FillByDossier(ds.Comptes, Dossier.Identity.Name)
        End Using
        ReportProgress(worker, 40)
        Using dta As New dbDonneesDataSetTableAdapters.CompteTotalTableAdapter
            dta.FillByDossier(ds.CompteTotal, Dossier.Identity.Name)
        End Using
        ReportProgress(worker, 60)
        Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
            dta.FillByExpl(ds.ModLignes, Dossier.CodeExpl)
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                dtListModele = ExecuteDataTable(String.Format("SELECT DISTINCT ModLPiece FROM ModLignes WHERE (ModLExpl = '{0}')", Dossier.CodeExpl), conn)
                conn.Close()
            End Using
        End Using
        ReportProgress(worker, 80)
        Using dta As New dbDonneesDataSetTableAdapters.ModMouvementsTableAdapter
            dta.FillByExpl(ds.ModMouvements, Dossier.CodeExpl)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.TVATableAdapter
            dta.Fill(ds.TVA)
        End Using

        ReportProgress(worker, 100)
        Dim j As Integer = 0
        xListModele = New ArrayList
        If dtListModele.Rows.Count > 0 Then
            Dim res As New List(Of Modele)(dtListModele.Rows.Count)
            For i As Integer = 0 To dtListModele.Rows.Count - 1
                Dim p As New Modele(ds, Convert.ToString(dtListModele.Rows(i).Item("ModLPiece")))
                xListModele.Add(Convert.ToString(dtListModele.Rows(i).Item("ModLPiece")))
                res.Add(p)
                j += 1 : ReportProgress(worker, j, dtListModele.Rows.Count)
            Next
            Return res
        Else
            Dim res As New List(Of Modele)
            Return res
        End If
        Return Nothing

    End Function

    ''' <summary>
    ''' Permet d'ajouter un modèle à la liste
    ''' </summary>
    ''' <param name="xModele"></param>
    ''' <remarks></remarks>
    Public Sub AddModele(ByRef xModele As Modele)
        Me.Add(xModele)
    End Sub

    Private Sub SuppressionModeles(ByRef t As OleDb.OleDbTransaction, ByVal nExpl As String, ByVal sModele As String)
        Try
            Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
                dta.SetTransaction(t)
                If CType(dta.ExistsModele(nExpl, sModele), Integer) > 0 Then
                    SuppressionDataLigne(t, nExpl, sModele)
                Else
                    Throw New ApplicationException(My.Resources.Strings.Modele_ModeleIntrouvable)
                End If
            End Using
        Catch ex As Exception
            t.Rollback()
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Permet de supprimer un modèle précis
    ''' </summary>
    ''' <param name="t"></param>
    ''' <param name="nExpl"></param>
    ''' <param name="sModele"></param>
    ''' <remarks></remarks>
    Private Shared Sub SuppressionDataLigne(ByRef t As OleDb.OleDbTransaction, ByVal nExpl As String, ByVal sModele As String)
        Using dta As New dbDonneesDataSetTableAdapters.ModMouvementsTableAdapter
            dta.SetTransaction(t)
            dta.DeleteFull(nExpl, sModele)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
            dta.SetTransaction(t)
            dta.DeleteFull(nExpl, sModele)
        End Using
    End Sub
#End Region

#Region "Méthodes partagées"
    ''' <summary>
    ''' Permet d'implémenter la barre de progression du chargement des données
    ''' </summary>
    ''' <param name="worker">barre de progression de la tâche</param>
    ''' <param name="value">valeur en cours de progression</param>
    ''' <param name="max">valeur max de la barre de progression</param>
    ''' <remarks></remarks>
    Private Shared Sub ReportProgress(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal value As Integer, Optional ByVal max As Integer = 100)
        If worker Is Nothing Then Exit Sub
        worker.ReportProgress(value * 100 \ max)
        Application.DoEvents()
    End Sub
#End Region

End Class

''' <summary>
''' Classe du Modele
''' </summary>
''' <remarks></remarks>
Public Class Modele

#Region "Property"
    ''' <summary>
    ''' Permet de retourner le modèle en cours
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GetModele() As Modele
        Get
            Return Me
        End Get
    End Property

    Private _lignes As New List(Of Ligne)
    ''' <summary>
    ''' Lignes associé au modèle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Lignes() As List(Of Ligne)
        Get
            Return _lignes
        End Get
        Set(ByVal value As List(Of Ligne))
            _lignes = value
        End Set
    End Property

    Private _Modele As String
    ''' <summary>
    ''' nom du modèle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Modele() As String
        Get
            Return _Modele
        End Get
        Set(ByVal value As String)
            _Modele = value
        End Set
    End Property

    Private _PrevModele As String
    ''' <summary>
    ''' nom du modèle pour permettre des MAJ
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PrevModele() As String
        Get
            Return _PrevModele
        End Get
        Set(ByVal value As String)
            _PrevModele = value
        End Set
    End Property

    Private _ExistsInBase As Boolean
    ''' <summary>
    ''' permet de savoir si le modèle existe en base
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ExistsInBase() As Boolean
        Get
            Return _ExistsInBase
        End Get
        Set(ByVal value As Boolean)
            _ExistsInBase = value
        End Set
    End Property
#End Region

#Region "Constructeurs"
    ''' <summary>
    ''' cosntructeur
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ExistsInBase = False
    End Sub

    ''' <summary>
    ''' chargement d'un modèle à partir du dataset et de son nom
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <param name="sNameMod"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal ds As dbDonneesDataSet, ByVal sNameMod As String)

        'implémente les proprétées de la pièce
        Me.New()
        Dim i As Integer = 0
        Me.Modele = sNameMod
        Me.PrevModele = sNameMod
        Me.ExistsInBase = True
        Dim dtaListModLigne() As dbDonneesDataSet.ModLignesRow = CType(ds.ModLignes.Select(String.Format("ModLPiece='{0}'", sNameMod)), dbDonneesDataSet.ModLignesRow())

        'chargement des lignes de la pièce
        For Each drl As dbDonneesDataSet.ModLignesRow In dtaListModLigne
            'ajoute les lignes de la pièce
            Me.Lignes.AddRange(Ligne.ChargerLignes(drl, i))
            i += 1
        Next
    End Sub

    ''' <summary>
    ''' constructeur d'un modèle dont le nom est passé en parametre
    ''' </summary>
    ''' <param name="sModele"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal sModele As String)
        'implémente les proprétées de la pièce
        Me.New()
        Dim TempNew As Modele = ChargerModele(sModele)
        With TempNew
            Me.Modele = .PrevModele
            Me.PrevModele = .PrevModele
            Me.ExistsInBase = .ExistsInBase
            Me.Lignes = .Lignes
        End With
    End Sub
#End Region

#Region "Méthodes partagées"
    ''' <summary>
    ''' Permet de charger un modèle
    ''' </summary>
    ''' <param name="sModele"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ChargerModele(ByVal sModele As String) As Modele

        Dim ds As New dbDonneesDataSet
        'Chargement depuis la base
        Using dta As New dbDonneesDataSetTableAdapters.ComptesTableAdapter
            dta.FillByDossier(ds.Comptes, My.User.Name)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
            dta.FillByExplByPiece(ds.ModLignes, CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl, sModele)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.ModMouvementsTableAdapter
            dta.FillByExplByPiece(ds.ModMouvements, CType(My.User.CurrentPrincipal, DossierPrincipal).CodeExpl, sModele)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.TVATableAdapter
            dta.Fill(ds.TVA)
        End Using

        'Initialise des objets
        If ds.ModLignes.Count > 0 Then
            Return New Modele(ds, sModele)
        Else
            Throw New ApplicationException("Modèle introuvable")
        End If
    End Function

    Public Shared Function SuppressionModele(ByVal sModele As String) As Boolean
        Try
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                Dim Dossier As DossierPrincipal = CType(My.User.CurrentPrincipal, DossierPrincipal)
                Using t As OleDb.OleDbTransaction = conn.BeginTransaction
                    Try
                        Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
                            dta.SetTransaction(t)
                            If CType(dta.ExistsModele(Dossier.CodeExpl, sModele), Integer) > 0 Then
                                SuppressionDataLigne(t, sModele)
                            Else
                                MsgBox(My.Resources.Strings.Modele_ModeleIntrouvable, MsgBoxStyle.Information, My.Resources.Strings.Modele_Suppression)
                            End If
                        End Using
                        t.Commit()
                    Catch ex As Exception
                        t.Rollback()
                        Throw New ApplicationException(ex.Message, ex)
                    End Try
                End Using
            End Using
            Return True
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try

        Return True
    End Function

    Private Shared Sub SuppressionDataLigne(ByRef t As OleDb.OleDbTransaction, ByVal sModele As String)
        Dim xDossier As DossierPrincipal = CType(My.User.CurrentPrincipal, DossierPrincipal)
        Using dta As New dbDonneesDataSetTableAdapters.ModMouvementsTableAdapter
            dta.SetTransaction(t)
            dta.DeleteFull(xDossier.CodeExpl, sModele)
        End Using
        Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
            dta.SetTransaction(t)
            dta.DeleteFull(xDossier.CodeExpl, sModele)
        End Using
    End Sub
#End Region

#Region "Méthodes diverses"
    ''' <summary>
    ''' Ajoute la pièce indiqué pour un exercice d'un exploitation
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AjoutMAJModele(ByVal bNewModele As Boolean) As Boolean
        Dim Dossier As DossierPrincipal = CType(My.User.CurrentPrincipal, DossierPrincipal)
        Dim sModuleEnCours As String = ""
        If bNewModele Then
            sModuleEnCours = Me.Modele
        Else
            sModuleEnCours = Me.PrevModele
        End If
        Try
            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
                conn.Open()
                Using t As OleDb.OleDbTransaction = conn.BeginTransaction
                    Using dta As New dbDonneesDataSetTableAdapters.ModLignesTableAdapter
                        dta.SetTransaction(t)
                        If CType(dta.ExistsModele(Dossier.CodeExpl, sModuleEnCours), Integer) = 0 Then
                            AjoutDataLigne(t)
                            t.Commit()
                        Else
                            If sModuleEnCours = "" Then
                                MsgBox(My.Resources.Strings.Modele_Collision, MsgBoxStyle.Information, My.Resources.Strings.Modele_Enregistrement)
                            Else
                                SuppressionDataLigne(t, sModuleEnCours)
                                AjoutDataLigne(t)
                                t.Commit()
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
        Return True

    End Function

    ''' <summary>
    ''' Supprime la pièce et ses enregistrements de la base de donnée
    ''' </summary>
    ''' <remarks></remarks>
    Public Function SuppressionModele() As Boolean
        Return SuppressionModele(Me.Modele)
    End Function

    ''' <summary>
    ''' Ajoute les lignes et les mouvements dans la base de donnée via transaction
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AjoutDataLigne(ByRef t As OleDb.OleDbTransaction)
        Try
            Dim xDossier As DossierPrincipal = CType(My.User.CurrentPrincipal, DossierPrincipal)
            Dim i As Integer = 0
            For Each xline As Ligne In Me.Lignes
                If xline.Compte <> Nothing Then
                    xline.AjouteLigneModeleMouvBase(xDossier.CodeExpl, Me.Modele, "", i, t)
                    i += 1
                End If
            Next
        Catch ex As Exception
            Throw New ApplicationException(ex.Message, ex)
        End Try
    End Sub

    ''' <summary>
    ''' Suppression des lignes et des mouvements dans la base de donnée via transaction
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SuppressionDataLigne(ByRef t As OleDb.OleDbTransaction)
        SuppressionDataLigne(t, Me.PrevModele)
    End Sub

    ''' <summary>
    ''' calcule la somme en débit en temps réel 
    ''' </summary>
    ''' <returns>retour le débit</returns>
    ''' <remarks>pour le moment seulement utiliser dans la barre des tâches</remarks>
    Public Function CalcSommeDeb() As Decimal
        Dim res As Decimal
        For Each l As Ligne In Me.Lignes
            If l.MontantDeb.HasValue Then res += l.MontantDeb.Value
        Next
        Return res
    End Function

    ''' <summary>
    ''' calcule la somme en crédit en temps réel 
    ''' </summary>
    ''' <returns>retour le crédit</returns>
    ''' <remarks>pour le moment seulement utiliser dans la barre des tâches</remarks>
    Public Function CalcSommeCre() As Decimal
        Dim res As Decimal
        For Each l As Ligne In Me.Lignes
            If l.MontantCre.HasValue Then res += l.MontantCre.Value
        Next
        Return res
    End Function

    ''' <summary>
    ''' Permet de rafraichir les champs du modèle en cours
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RafraichirBase()
        Dim xTemp As Modele = ChargerModele(Me.PrevModele)
        Dim i As Integer = 0
        Me.PrevModele = xTemp.PrevModele
        Me.Modele = xTemp.Modele
        Me.ExistsInBase = xTemp.ExistsInBase
        Me.Lignes = xTemp.Lignes

    End Sub
#End Region

End Class

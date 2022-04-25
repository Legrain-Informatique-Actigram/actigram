Imports System.Diagnostics
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ServiceAgrifact
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Overrides Function ToString() As String
        Return My.Global.Application.Product & " " & My.Global.Application.Version.ToString
    End Function

    <WebMethod()> _
    Public Sub TestEcriture()
        Try
            Using dta As New DsAgrifactTableAdapters.EntrepriseTA
                dta.TestUpdate()
            End Using
        Catch ex As Exception
            My.Log.WriteException(ex, TraceEventType.Error, "Erreur d'écriture dans la base")
            Throw ex
        End Try
    End Sub

    <WebMethod()> _
    Public Function Version() As String
        Return My.Global.Application.Version.ToString
    End Function

    <WebMethod()> _
    Public Function GetListeBC() As DsPrepaCommande.BCDataTable
        Using dta As New DsPrepaCommandeTableAdapters.BCTA
            Return dta.GetDataNonTraite
        End Using
    End Function

    <WebMethod()> _
    Public Function GetBL(ByVal nbc As Integer, ByVal dateBc As Date) As DsPrepaCommande
        'Trouver le BC qui correspond
        Dim dtBC As DsAgrifact.VBonCommandeDataTable
        Using dta As New DsAgrifactTableAdapters.VBonCommandeTA
            dtBC = dta.GetDataByNumAndDate(nbc, dateBc)
        End Using
        If dtBC.Count = 0 Then
            Throw New ApplicationException("Le bon de commande est introuvable")
        End If
        'S'il existe regarder le contenu des champs Origine et nOrigine
        Dim drBC As DsAgrifact.VBonCommandeRow = dtBC(0)
        Dim nBL As Integer
        If drBC.Paye AndAlso Not drBC.IsOrigineNull AndAlso drBC.Origine = "VBonLivraison" Then
            nBL = drBC.nOrigine
        Else
            'Créer le BL à partir du BC : 
            nBL = Pieces.CreerBL(drBC.nDevis)
        End If
        'Charger les infos à envoyer au pocket
        Return GetBLByNDevisBL(nBL)
    End Function

    <WebMethod()> _
    Public Function GetBLByNDevisBL(ByVal nDevisBL As Integer) As DsPrepaCommande
        'Charger les infos à envoyer au pocket
        Dim ds As New DsPrepaCommande
        Using dta As New DsPrepaCommandeTableAdapters.BLTA
            dta.FillById(ds.BL, nDevisBL)
        End Using
        Using dta As New DsPrepaCommandeTableAdapters.BL_DetailTA
            dta.FillByBL(ds.BL_Detail, nDevisBL)
        End Using
        'Initialiser nb cartons
        If ds.BL.Count > 0 Then
            Dim drCartons As DsPrepaCommande.BL_DetailRow = TrouverLigneCartons(ds.BL_Detail)
            If drCartons Is Nothing OrElse drCartons.IsUnite1Null Then
                ds.BL(0).nbCartons = 0
            Else
                ds.BL(0).nbCartons = CInt(drCartons.Unite1)
            End If
        End If
        Return ds
    End Function

    Private Function TrouverLigneCartons(ByVal dt As Data.DataTable) As Data.DataRow
        For Each dr As Data.DataRow In dt.Rows
            If Not dr.IsNull("NbParution") AndAlso CInt(dr("NbParution")) = -1 Then
                Return dr
            End If
        Next
        Return Nothing
    End Function

    <WebMethod()> _
    Public Sub UpdateBL(ByVal ds As DsPrepaCommande)
        Try
            Dim dsAgrifact As New DsAgrifact
            dsAgrifact.EnforceConstraints = False
            Using dtaT As New DsAgrifactTableAdapters.TVATA
                dtaT.Fill(dsAgrifact.TVA)
            End Using
            Using dtaP As New DsAgrifactTableAdapters.ProduitTA
                Using dtaBL As New DsAgrifactTableAdapters.VBonLivraisonTA
                    dtaBL.ClearBeforeFill = False
                    Using dtaBLD As New DsAgrifactTableAdapters.VBonLivraison_DetailTA
                        dtaBLD.ClearBeforeFill = False

                        'MODIF TV 11/09/2012
                        'dtaBLD.InitAutoIncrementSeed(dsAgrifact.VBonLivraison_Detail)
                        'FIN MODIF TV 11/09/2012

                        For Each drBL As DsPrepaCommande.BLRow In ds.BL
                            dtaP.FillByBL(dsAgrifact.Produit, drBL.nDevis)
                            dtaBL.FillById(dsAgrifact.VBonLivraison, drBL.nDevis)
                            dtaBLD.FillByBL(dsAgrifact.VBonLivraison_Detail, drBL.nDevis)
                            For Each drBLD As DsPrepaCommande.BL_DetailRow In ds.BL_Detail
                                Dim drd As DsAgrifact.VBonLivraison_DetailRow
                                If drBLD.nDetailDevis > 0 Then
                                    'La ligne existait déjà : on la mets à jour
                                    drd = dsAgrifact.VBonLivraison_Detail.FindBynDetailDevis(drBLD.nDetailDevis)
                                    With drd
                                        If Not (drBLD.IsNLotNull) Then
                                            .NLot = drBLD.NLot
                                        End If
                                        If Not (drBLD.IsUnite1Null) Then
                                            .Unite1 = drBLD.Unite1
                                        End If
                                        If Not (drBLD.IsUnite2Null) Then
                                            .Unite2 = drBLD.Unite2
                                        End If
                                    End With
                                Else
                                    'La ligne est nouvelle : on la crée et on recopie toutes les infos depuis drBLD
                                    drd = dsAgrifact.VBonLivraison_Detail.NewVBonLivraison_DetailRow
                                    CopyRow(drBLD, drd)

                                    'MODIF TV 11/09/2012
                                    drd.nDetailDevis = Pieces.GetNDetailDevis("VBonLivraison_Detail")
                                    'FIN MODIF TV 11/09/2012

                                    dsAgrifact.VBonLivraison_Detail.AddVBonLivraison_DetailRow(drd)
                                End If
                            Next
                            ''Créer ou mettre à jour la ligne pour les cartons
                            'Dim drCartons As DsAgrifact.VBonLivraison_DetailRow = TrouverLigneCartons(dsAgrifact.VBonLivraison_Detail)
                            'If drCartons Is Nothing Then
                            '    Dim drd As DsAgrifact.VBonLivraison_DetailRow = dsAgrifact.VBonLivraison_Detail.NewVBonLivraison_DetailRow
                            '    With drd
                            '        .nDevis = drBL.nDevis
                            '        .NbParution = -1
                            '        .Libelle = "Nombre de cartons livrés :"
                            '        .Unite1 = drBL.nbCartons
                            '    End With
                            '    dsAgrifact.VBonLivraison_Detail.AddVBonLivraison_DetailRow(drd)
                            'Else
                            '    drCartons.Unite1 = drBL.nbCartons
                            'End If
                        Next
                        'Recalculer les BL
                        Pieces.RecalculerBLs(dsAgrifact)
                        'MAJ Base
                        dtaBL.Update(dsAgrifact.VBonLivraison)
                        dtaBLD.Update(dsAgrifact.VBonLivraison_Detail)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            My.Log.WriteException(ex, TraceEventType.Error, "Erreur d'écriture dans la base")
            Throw ex
        End Try
    End Sub

End Class

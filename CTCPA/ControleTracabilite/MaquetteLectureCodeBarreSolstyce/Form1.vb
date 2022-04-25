Public Class Form1

#Region "Form Events"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Vider la zone de code barre et lui donner le focus
        TxCodeBarre.Text = ""
        TxCodeBarre.Select()
    End Sub
#End Region

#Region "Controls Events"
    Private Sub BtParams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtParams.Click
        Using fr As New FrParametres
            fr.ShowDialog()
        End Using
    End Sub

    Private Sub BtAnalyseSimple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnalyseSimple.Click
        AnalyserCodeBarre(Me.TxCodeBarre.Text.Trim)
    End Sub

    Private Sub BtAnalyseComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnalyseComplete.Click
        AnalyserCodeBarreComplete(Me.TxCodeBarre.Text.Trim)
    End Sub

    Private Sub BtClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtClose.Click
        Me.Close()
    End Sub

    Private Sub TxCodeBarre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxCodeBarre.KeyPress
        'Le code barre est valid� par un retour chariot (normalement envoy� automatiquement par la douchette)
        If e.KeyChar = vbCr Then
            AnalyserCodeBarre(TxCodeBarre.Text.Trim)
            e.Handled = True
            'Mettre toute la zone de code barre en surbrillance pour faciliter la saisie du code suivant
            TxCodeBarre.SelectAll()
            TxCodeBarre.Select()
        End If
    End Sub
#End Region

    ''' <summary>
    ''' L'analyse simple ne r�cup�re que le code produit est le n� de lot, elle est tr�s l�g�re en terme d'acc�s � la base de donn�es
    ''' </summary>
    Private Sub AnalyserCodeBarre(ByVal code As String)
        If code.Length = 0 Then Exit Sub
        'Nettoyer la zone de r�sultat
        TxResultat.Clear()
        'Analyse le code et r�cup�rer le r�sultat
        Dim cb As CodeBarre = CodeBarre.Parse(code)
        If cb Is Nothing Then
            'L'analyse simple n'�choue que sur une erreur de format.
            TxResultat.AppendText(String.Format("Le code '{0}' est incorrect.", code))
        Else
            ' Composants du code barre, toujours renseign�s si le format du code barre est correct
            TxResultat.AppendText(String.Format("Type de code : {0}" & vbCrLf, cb.Type))
            TxResultat.AppendText(String.Format("EAN : {0}" & vbCrLf, cb.EAN))
            TxResultat.AppendText(String.Format("N� Piece : {0}" & vbCrLf, cb.nPiece))
            'Si le format est correct mais que les informations ne peuvent pas �tre retrouv�es dans la base de donn�es
            'les champs suivants seront � Nothing
            If cb.CodeProduit Is Nothing Then
                TxResultat.AppendText(String.Format("Code Produit introuvable pour l'EAN '{0}'" & vbCrLf, cb.EAN))
            Else
                TxResultat.AppendText(String.Format("Code Produit : {0}" & vbCrLf, cb.CodeProduit))
                If cb.NLot Is Nothing Then
                    TxResultat.AppendText(String.Format("Lot introuvable pour le produit '{0}' et la pi�ce n�{1}" & vbCrLf, cb.CodeProduit, cb.nPiece))
                Else
                    TxResultat.AppendText(String.Format("N� Lot : {0}" & vbCrLf, cb.NLot))
                End If
            End If
        End If
        TxResultat.DeselectAll()
    End Sub

    ''' <summary>
    ''' L'analyse compl�te retrouve les lignes concern�es par le code barre dans un dataset, 
    ''' donnant ainsi acc�s � toutes les informations disponibles
    ''' </summary>
    Private Sub AnalyserCodeBarreComplete(ByVal code As String)
        If code.Length = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()
        Try
            'Nettoyer la zone de r�sultat
            TxResultat.Clear()
            'Remplir le Dataset
            Dim ds As AgrifactTracaDataSet = ChargerDonnees()
            'Analyse le code et r�cup�rer le r�sultat
            Dim cb As CodeBarre = CodeBarre.Parse(code, ds)
            If cb Is Nothing Then
                'L'analyse compl�te �choue sur une erreur de format ou si toutes les informations n'ont pas pu �tre trouv�es dans le Dataset
                TxResultat.AppendText(String.Format("Le code '{0}' est incorrect ou bien des informations sont introuvables.", code))
            Else
                ' Composants du code barre
                TxResultat.AppendText(String.Format("Type de code : {0}" & vbCrLf, cb.Type))
                TxResultat.AppendText(String.Format("EAN : {0}" & vbCrLf, cb.EAN))
                TxResultat.AppendText(String.Format("N� Piece : {0}" & vbCrLf, cb.nPiece))
                'L'analyse compl�te retourne les r�f�rences des Datarow concern�s dans le Dataset, 
                'ce qui permet d'avoir acc�s � toutes les informations disponibles
                TxResultat.AppendText(String.Format("Code Produit : {0}" & vbCrLf, cb.CodeProduit))
                'Donner les informations du produit et de sa famille
                Dim drP As AgrifactTracaDataSet.ProduitRow = cb.ProduitDatarow
                TxResultat.AppendText(String.Format("{0} : {1} (u1={2}/u2={3})" & vbCrLf, drP.FamilleRow.Famille, drP("Libelle"), drP("Unite1"), drP("Unite2")))

                'Les tables impact�es sont diff�rentes suivant qu'il s'agisse d'une fabrication ou d'une r�ception
                If cb.Type = CodeBarre.TypeCodeBarre.Fabrication Then
                    'R�cup�rer les lignes de la fabrication
                    Dim drMVTD As AgrifactTracaDataSet.Mouvement_DetailRow = cb.Datarow
                    Dim drMVT As AgrifactTracaDataSet.MouvementRow = drMVTD.MouvementRow
                    'Donner les informations sur la fabrication
                    TxResultat.AppendText(String.Format("Fabrication n�{0} du {1:dd/MM/yyyy}" & vbCrLf, drMVT.nMouvement, drMVT.DateMouvement))
                    If Convert.ToString(drMVT("Description")).Length > 0 Then
                        TxResultat.AppendText(String.Format("Description : {0}" & vbCrLf, drMVT("Description")))
                    End If
                    'Donner les informations sur le lot de produit fabriqu�
                    TxResultat.AppendText(String.Format("Fabrication de {0:F3}{1}/{2:F3}{3} du produit {4} (lot n�{5})" & vbCrLf, _
                                                        drMVTD("Unite1"), drMVTD("LibUnite1"), drMVTD("Unite2"), drMVTD("LibUnite2"), drMVTD.Libelle, drMVTD.nLot))
                ElseIf cb.Type = CodeBarre.TypeCodeBarre.Reception Then
                    'R�cup�rer les lignes de la r�ception
                    Dim drBRD As AgrifactTracaDataSet.ABonReception_DetailRow = cb.Datarow
                    Dim drBR As AgrifactTracaDataSet.ABonReceptionRow = drBRD.ABonReceptionRow
                    Dim drF As AgrifactTracaDataSet.EntrepriseRow = drBR.EntrepriseRow
                    'Donner les informations sur la r�ception
                    TxResultat.AppendText(String.Format("R�ception du {0:dd/MM/yyyy}" & vbCrLf, drBR.DateFacture))
                    'Donner les informations sur le fournisseur
                    TxResultat.AppendText(String.Format("Fournisseur : {0} ({1} {2})" & vbCrLf, drF.Nom, drF.CodePostal, drF.Ville))
                    If Convert.ToString(drBR("Observation")).Length > 0 Then
                        TxResultat.AppendText(String.Format("Description : {0}" & vbCrLf, drBR("Observation")))
                    End If
                    'Donner les informations sur le lot de produit re�u
                    TxResultat.AppendText(String.Format("Re�u: {0:F3}{1}/{2:F3}{3} de {4} (lot {5})" & vbCrLf, _
                                                        drBRD("Unite1"), drBRD("LibUnite1"), drBRD("Unite2"), drBRD("LibUnite2"), drBRD.Libelle, drBRD.NLot))
                End If
            End If
            TxResultat.DeselectAll()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    ''' <summary>
    ''' Ce chargement peut s'av�rer long sur des bases de donn�es volumineuses, il est donc conseill�
    ''' d'adapter cet exemple en limitant les donn�es charg�es au minimum n�cessaire.
    ''' Il est aussi int�ressant de ne pas recharger les donn�es � chaque analyse si a priori de nouvelles saisies n'ont pas eu lieu
    ''' </summary>
    Private Function ChargerDonnees() As AgrifactTracaDataSet
        Dim ds As New AgrifactTracaDataSet
        'Les informations sur les familles de produit
        Using dtaF As New AgrifactTracaDataSetTableAdapters.FamilleTableAdapter
            dtaF.Fill(ds.Famille)
        End Using
        'Les informations sur les produits
        Using dtaP As New AgrifactTracaDataSetTableAdapters.ProduitTableAdapter
            dtaP.Fill(ds.Produit)
        End Using
        'Les informations sur les fournisseurs
        Using dtaE As New AgrifactTracaDataSetTableAdapters.EntrepriseTableAdapter
            dtaE.FillFournisseurs(ds.Entreprise, False)
        End Using
        'Les bons de r�ception
        Using dtaBR As New AgrifactTracaDataSetTableAdapters.ABonReceptionTableAdapter
            dtaBR.Fill(ds.ABonReception)
        End Using
        'Le d�tail des bons de r�ception
        Using dtaBRD As New AgrifactTracaDataSetTableAdapters.ABonReception_DetailTableAdapter
            dtaBRD.Fill(ds.ABonReception_Detail)
        End Using
        'Les fabrications
        Using dtaM As New AgrifactTracaDataSetTableAdapters.MouvementTableAdapter
            dtaM.FillByType(ds.Mouvement, "Conditionnement")
        End Using
        'Le d�tail des fabrications
        Using dtaMD As New AgrifactTracaDataSetTableAdapters.Mouvement_DetailTableAdapter
            dtaMD.Fill(ds.Mouvement_Detail)
        End Using
        Return ds
    End Function

End Class

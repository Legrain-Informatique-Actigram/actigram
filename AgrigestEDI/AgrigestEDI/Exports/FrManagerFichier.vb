Imports System.Windows.Forms
Imports System.IO
Imports System.Xml.Serialization
Imports AgrigestEDI.GestionParametrageImportFichier
''' <summary>
''' class principale de l'import de fichier de balance ou de GL
''' </summary>
''' <remarks></remarks>
Public Class FrManagerFichier
    'TODO EXTERNALISATION ET CORRECTION MESSAGES
    Implements IPrechargement

    Private xcboCompte As ListboxItem
    Private xcboActivite As ListboxItem
    Private xcboLibCompte As ListboxItem
    Private xcboDebit As ListboxItem
    Private xcboCredit As ListboxItem
    Private nColonneFull As Integer
    Private dtTableFull As DataTable
    Private xDatasetAffectation As New DataSet
    Private bChargement As Boolean = False

    ''' <summary>
    ''' lancement de l'importation de fichier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrManagerFichier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        bChargement = True
        lbStatus.Text = ""
        With PanProgress
            .Location = New Point(0, 0)
            .Width = Me.ClientSize.Width
            .Height = Me.ClientSize.Height - Me.GradientPanel2.Height
            .BringToFront()
            .Visible = False
        End With
        TxNomFichier.Text = My.Settings.LireParametre("CheSauvegarde", Application.StartupPath & "\Sauvegarde")

        With dgvAffectation
            AddHandler .DataError, AddressOf dg_DataError
        End With

        ChargementListModele()
        ChargementCodePage()
        ChargementDelimiter()
        ChargementTypeFile()
        bChargement = False

    End Sub

    ''' <summary>
    ''' charge la liste des modèles et alimente la liste déroulante
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargementListModele()
        Dim ListModele As List(Of ParametrageImportFichier) = ParametrageImportFichier.ChargerParametrageImportFichier
        Dim xNew As New GestionParametrageImportFichier.ItemParametrageImport
        xNew.Nom = "<Nouveau paramétrage>"
        Dim xVide As New GestionParametrageImportFichier.ItemParametrageImport
        xVide.Nom = ""
        If ListModele(0).Type = ParametrageImportFichier.ItemType.Balance Then
            Dim xModele As ParametrageImportFichier
            xModele = ListModele(0)
            xModele.Items.Add(xNew)
            xModele.Items.Insert(0, xVide)
            ModeleBindingSource.DataSource = xModele.Items
        Else
            Dim xModele As ParametrageImportFichier
            xModele = ListModele(1)
            xModele.Items.Add(xNew)
            xModele.Items.Insert(0, xVide)
            ModeleBindingSource.DataSource = xModele.Items
        End If
    End Sub

    ''' <summary>
    ''' vérifie qu'il n'existe pas de pièce pour l'exercice
    ''' </summary>
    ''' <param name="AvancedOption"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Precharger(ByVal AvancedOption As Boolean) As Boolean Implements IPrechargement.Precharger
        Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
            conn.Open()
            If ExecuteScalarInt("SELECT COUNT(*) FROM Pieces WHERE PDossier='" + My.User.Name + "'", conn) > 0 Then
                MsgBox("Vous ne pouvez pas charger de balance ou de grand livre en ayant pièces pour cet exercices." + vbCrLf + "Veuillez supprimer toutes les pièces ou créer un nouvel exercice.", MsgBoxStyle.Information, "Importation de fichier")
                Return False
            Else
                If Not FrPassCloture.VerifAdmin Then Exit Function
                Return True
            End If
        End Using
    End Function

#Region "Chargement des combo"

    ''' <summary>
    ''' charge la liste des séparateur
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargementDelimiter()

        cboDelimiter.Items.Clear()
        cboDelimiter.DisplayMember = "Display"
        cboDelimiter.ValueMember = "Value"

        cboDelimiter.Items.Add(New ListboxItem("{CR}{LF}", "CRLF"))
        cboDelimiter.Items.Add(New ListboxItem("{CR}", "CR"))
        cboDelimiter.Items.Add(New ListboxItem("{LF}", "LF"))
        cboDelimiter.Items.Add(New ListboxItem("Semicolon {;}", ";"))
        cboDelimiter.Items.Add(New ListboxItem("Colon {:}", ":"))
        cboDelimiter.Items.Add(New ListboxItem("Comma {,}", ","))
        cboDelimiter.Items.Add(New ListboxItem("Tab {t}", "t"))
        cboDelimiter.Items.Add(New ListboxItem("Vertical Bar {|}", "|"))

    End Sub

    ''' <summary>
    ''' charge les type de découpage
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargementTypeFile()

        cboTypeFile.Items.Clear()
        cboTypeFile.DisplayMember = "Display"
        cboTypeFile.ValueMember = "Value"

        cboTypeFile.Items.Add(New ListboxItem("Delimité", 1))
        cboTypeFile.Items.Add(New ListboxItem("Taille fixe", 2))

        cboTypeFile.SelectedIndex = 0

    End Sub

    ''' <summary>
    ''' charge la liste des affectations
    ''' </summary>
    ''' <param name="cboListItem"></param>
    ''' <param name="nColonne"></param>
    ''' <remarks></remarks>
    Private Sub ChargementCombo(ByRef cboListItem As ComboBox, ByVal nColonne As Integer)

        cboListItem.Items.Clear()

        cboListItem.Items.Add(New ListboxItem("", nColonne))

        For i As Integer = 0 To nColonne - 1
            Dim bFind As Boolean = False
            For Each xRow As DataRow In xDatasetAffectation.Tables(0).Rows
                If xRow("Affectation").ToString = String.Format("Colonne {0}", i.ToString) Then
                    bFind = True
                    Exit For
                End If
            Next
            If Not bFind Then cboListItem.Items.Add(New ListboxItem(String.Format("Colonne {0}", i.ToString), i))
        Next

    End Sub

    ''' <summary>
    ''' charge la liste de codepage
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargementCodePage()

        cboCodePage.Items.Clear()

        cboCodePage.Items.Add(New ListboxItem("10000 (MAC - Romain)", 10000))
        cboCodePage.Items.Add(New ListboxItem("10006 (MAC - Grec I)", 10006))
        cboCodePage.Items.Add(New ListboxItem("10007 (MAC - Cyrillique)", 10007))
        cboCodePage.Items.Add(New ListboxItem("10010 (MAC - Roumanie)", 10010))
        cboCodePage.Items.Add(New ListboxItem("10017 (MAC - Ukraine)", 10017))
        cboCodePage.Items.Add(New ListboxItem("10029 (MAC - Latin II)", 10029))
        cboCodePage.Items.Add(New ListboxItem("10079 (MAC - Islandais)", 10079))
        cboCodePage.Items.Add(New ListboxItem("10081 (MAC - Turc)", 10081))
        cboCodePage.Items.Add(New ListboxItem("10082 (MAC - Croate)", 10082))
        cboCodePage.Items.Add(New ListboxItem("1026 (IBM EBCDIC - Turque (Latin-5))", 1026))
        cboCodePage.Items.Add(New ListboxItem("1250 (ANSI - Europe centrale)", 1250))
        cboCodePage.Items.Add(New ListboxItem("1251 (ANSI - Cyrillique)", 1251))
        cboCodePage.Items.Add(New ListboxItem("1252 (ANSI - Latin I)", 1252))
        cboCodePage.Items.Add(New ListboxItem("1253 (ANSI - Grec)", 1253))
        cboCodePage.Items.Add(New ListboxItem("1254 (ANSI - Turc)", 1254))
        cboCodePage.Items.Add(New ListboxItem("1255 (ANSI - Hébreu)", 1255))
        cboCodePage.Items.Add(New ListboxItem("1256 (ANSI - Arabe)", 1256))
        cboCodePage.Items.Add(New ListboxItem("1257 (ANSI - Baltique)", 1257))
        cboCodePage.Items.Add(New ListboxItem("1258 (ANSI/OEM - Vietnam)", 1258))
        cboCodePage.Items.Add(New ListboxItem("20127 (ASCII - Etat unis)", 20127))
        cboCodePage.Items.Add(New ListboxItem("20261 (T.61)", 20261))
        cboCodePage.Items.Add(New ListboxItem("20866 (Russe - KOI8)", 20866))
        cboCodePage.Items.Add(New ListboxItem("21866 (Ukrainien - KOI8-U)", 21866))
        cboCodePage.Items.Add(New ListboxItem("28591 (ISO 8859-1 Latin I)", 28591))
        cboCodePage.Items.Add(New ListboxItem("28592 (ISO 8859-2 Europe centrale)", 28592))
        cboCodePage.Items.Add(New ListboxItem("28594 (ISO 8859-4 Baltique)", 28594))
        cboCodePage.Items.Add(New ListboxItem("28595 (ISO 8859-5 - Cyrillique)", 28595))
        cboCodePage.Items.Add(New ListboxItem("28595 (ISO 8859-7 - Grec)", 28595))
        cboCodePage.Items.Add(New ListboxItem("28599 (ISO 8859-9 - Latin 5)", 28599))
        cboCodePage.Items.Add(New ListboxItem("28605 (ISO 8859-15 - Latin 9)", 28605))
        cboCodePage.Items.Add(New ListboxItem("37 (IBM EBCDIC - Etat Unis/Canada)", 37))
        cboCodePage.Items.Add(New ListboxItem("437 (OEM - Etat Unis)", 437))
        cboCodePage.Items.Add(New ListboxItem("500 (IBM EBCDIC - International)", 500))
        cboCodePage.Items.Add(New ListboxItem("737 (OEM - Grec 437G)", 737))
        cboCodePage.Items.Add(New ListboxItem("775 (OEM - Baltique)", 775))
        cboCodePage.Items.Add(New ListboxItem("850 (OEM - Latin Multilingue I)", 850))
        cboCodePage.Items.Add(New ListboxItem("852 (OEM - Latin II)", 852))
        cboCodePage.Items.Add(New ListboxItem("855 (OEM - Cyrillique)", 855))
        cboCodePage.Items.Add(New ListboxItem("857 (OEM - Turc)", 857))
        cboCodePage.Items.Add(New ListboxItem("860 (OEM - Portugais)", 860))
        cboCodePage.Items.Add(New ListboxItem("861 (OEM - Islandais)", 861))
        cboCodePage.Items.Add(New ListboxItem("863 (OEM - Canadien français)", 863))
        cboCodePage.Items.Add(New ListboxItem("865 (OEM - Nordique)", 865))
        cboCodePage.Items.Add(New ListboxItem("866 (OEM - Russe)", 866))
        cboCodePage.Items.Add(New ListboxItem("869 (OEM - Grec moderne)", 869))
        cboCodePage.Items.Add(New ListboxItem("874 (ANSI/OEM - thaï)", 874))
        cboCodePage.Items.Add(New ListboxItem("875 (IBM EBCDIC - Grec moderne)", 875))
        cboCodePage.Items.Add(New ListboxItem("932 (ANSI/OEM - Japonais décalage JIS)", 932))
        cboCodePage.Items.Add(New ListboxItem("936 (ANSI/OEM - Chinois simplifié GBK)", 936))
        cboCodePage.Items.Add(New ListboxItem("949 (ANSI/OEM - Coréen)", 949))
        cboCodePage.Items.Add(New ListboxItem("950 (ANSI/OEM - Chinois simplifié Big5)", 950))
        cboCodePage.Items.Add(New ListboxItem("65000 (UTF-7)", 65000))
        cboCodePage.Items.Add(New ListboxItem("65001 (UTF-8)", 65001))

        cboCodePage.SelectedIndex = cboCodePage.FindString("1252")

    End Sub

#End Region

#Region "Gestion du parametrage dans la liste déroulante"

    ''' <summary>
    ''' permet de supprimer un paramétrage de fichier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdSupprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSupprimer.Click

        Dim xRow As GestionParametrageImportFichier.ItemParametrageImport = DirectCast(cboModele.SelectedItem, GestionParametrageImportFichier.ItemParametrageImport)
        If xRow Is Nothing Then Exit Sub
        If xRow.Nom = "" OrElse xRow.Nom = "<Nouveau paramétrage>" Then Exit Sub
        Dim ListModele As List(Of ParametrageImportFichier) = ParametrageImportFichier.ChargerParametrageImportFichier
        Dim xModele As ParametrageImportFichier
        If rbtBalance.Checked AndAlso ListModele(0).Type = ParametrageImportFichier.ItemType.Balance Then
            xModele = ListModele(0)
        Else
            xModele = ListModele(1)
        End If

        If MsgBox(String.Format("Etes vous sur de vouloir supprimer le paramétrage {0}", xRow.Nom), MsgBoxStyle.OkCancel, "Suppresion de paramétrage") = MsgBoxResult.Ok Then
            For i As Integer = xModele.Items.Count - 1 To 0 Step -1
                If xModele.Items(i).Nom = xRow.Nom Then
                    xModele.Items.RemoveAt(i)
                End If
            Next
            ParametrageImportFichier.EnregistrerParametrageImportFichier(ListModele)
            ChargementListModele()
        End If

    End Sub

    ''' <summary>
    ''' permet d'enregistrer un découpage de fichier 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdEnregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnregistrer.Click

        Dim xRow As GestionParametrageImportFichier.ItemParametrageImport = DirectCast(cboModele.SelectedItem, GestionParametrageImportFichier.ItemParametrageImport)
        If xRow Is Nothing Then Exit Sub
        Dim ListModele As List(Of ParametrageImportFichier) = ParametrageImportFichier.ChargerParametrageImportFichier
        Dim xModele As ParametrageImportFichier
        'récupère la liste des modèle
        If rbtBalance.Checked AndAlso ListModele(0).Type = ParametrageImportFichier.ItemType.Balance Then
            xModele = ListModele(0)
        Else
            xModele = ListModele(1)
        End If
        'vérifie s'il s'agit d'un nouveau paramétrage ou d'un modification avant d'enregistrer
        If xRow.Nom = "<Nouveau paramétrage>" Then
            Dim xNew As New ItemParametrageImport
            Dim sName As String = "<Nouveau paramétrage>"
            Dim bExist As Boolean = True
            While bExist
                'saisi du nom du paramétrage
                sName = InputBox("Veuillez saisir le nom du paramétrage", "paramétrage de fichier", sName)
                For Each xRowExist As GestionParametrageImportFichier.ItemParametrageImport In xModele.Items
                    If xRowExist.Nom = sName Then
                        bExist = True
                        Exit For
                    End If
                Next
                bExist = False
            End While

            xNew.Nom = sName
            RecuperationInformationModele(xNew)
            xModele.Items.Add(xNew)

            ParametrageImportFichier.EnregistrerParametrageImportFichier(ListModele)
            ChargementListModele()
        ElseIf xRow.Nom <> "" Then
            If MsgBox("Etes vous sur de vouloir modifier ce paramétrage?", MsgBoxStyle.YesNo, "Importation") = MsgBoxResult.No Then Exit Sub
            Dim xTempModele As ItemParametrageImport
            xTempModele = xModele.Items(xModele.Items.IndexOf(xRow))
            RecuperationInformationModele(xTempModele)
            ParametrageImportFichier.EnregistrerParametrageImportFichier(ListModele)
            ChargementListModele()
        End If

    End Sub

    ''' <summary>
    ''' permet de changer les controles en fonction du modèle
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboModele_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModele.SelectedIndexChanged

        Dim xRow As GestionParametrageImportFichier.ItemParametrageImport = DirectCast(cboModele.SelectedItem, GestionParametrageImportFichier.ItemParametrageImport)
        If xRow.bModifiable AndAlso xRow.Nom <> "" Then
            cmdEnregistrer.Enabled = True
            cmdSupprimer.Enabled = True
        Else
            cmdEnregistrer.Enabled = False
            cmdSupprimer.Enabled = False
        End If
        If xRow Is Nothing OrElse xRow.Nom = "" OrElse xRow.Nom = "<Nouveau paramétrage>" Then Exit Sub
        If xRow.Codage = "1200" Then
            chkUnicode.Checked = True
            cboCodePage.SelectedIndex = cboCodePage.FindString("1252")
        Else
            chkUnicode.Checked = False
            cboCodePage.SelectedIndex = cboCodePage.FindString(xRow.Codage)
        End If
        cboTypeFile.SelectedIndex = cboTypeFile.FindString(Microsoft.VisualBasic.Left(xRow.TypeDelimiter, 6))

        If cboTypeFile.SelectedIndex = 0 Then
            txtDelimiter.Clear()
            cboDelimiter.SelectedIndex = cboDelimiter.FindString(xRow.Delimiter)
        Else
            cboDelimiter.SelectedIndex = 0
            txtDelimiter.Text = xRow.Delimiter
        End If
        chkHearder.Checked = CType(xRow.Header, Boolean)


    End Sub

    ''' <summary>
    ''' permet de récupérer les informations relativent au paramétrage pour qu'il soit mis dans le fichier de paramétrage
    ''' </summary>
    ''' <param name="xTempModele"></param>
    ''' <remarks></remarks>
    Private Sub RecuperationInformationModele(ByRef xTempModele As ItemParametrageImport)

        Dim xListElement As New SerializableDictionary(Of String, String)
        If xDatasetAffectation.Tables.Count > 0 AndAlso xDatasetAffectation.Tables(0).Rows.Count > 0 Then
            For Each xRowAffect As DataRow In xDatasetAffectation.Tables(0).Rows
                xListElement.Add(xRowAffect("Champ").ToString, xRowAffect("Affectation").ToString)
            Next
        End If
        xTempModele.Affectation = xListElement
        xTempModele.Codage = CType(cboCodePage.SelectedItem, ListboxItem).Text
        If cboTypeFile.SelectedIndex = 0 Then
            xTempModele.TypeDelimiter = CType(cboTypeFile.SelectedItem, ListboxItem).Text
        Else
            xTempModele.TypeDelimiter = txtDelimiter.Text
        End If
        xTempModele.Delimiter = CType(cboDelimiter.SelectedItem, ListboxItem).Text
        xTempModele.Header = chkHearder.Checked.ToString

    End Sub

#End Region

#Region "Gestion du parametre"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkUnicode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnicode.CheckedChanged
        cboCodePage.Enabled = Not chkUnicode.Checked
    End Sub

    ''' <summary>
    ''' permet de charger le système de découpage par taille ou par séparateur
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboTypeFile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTypeFile.SelectedIndexChanged
        If cboTypeFile.SelectedItem IsNot Nothing AndAlso CInt(CType(cboTypeFile.SelectedItem, ListboxItem).Value) = 1 Then
            lblDelimiter.Visible = True
            cboDelimiter.Visible = True
            cboDelimiter.SelectedIndex = 0
            lblTextDelimiter.Visible = False
            txtDelimiter.Visible = False
        Else
            lblDelimiter.Visible = False
            cboDelimiter.Visible = False
            txtDelimiter.Clear()
            lblTextDelimiter.Visible = True
            txtDelimiter.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' permet de charger le contenu du fichier dans les tables et tableau apres vérification de l'existance du fichier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboDelimiter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDelimiter.SelectedIndexChanged
        Dim FichierAvant As String = TxNomFichier.Text
        If Not IO.File.Exists(FichierAvant) Then
            Exit Sub
        End If
        ChargementGrid()
    End Sub

    ''' <summary>
    ''' permet de charger le contenu du fichier dans les tables et tableau apres vérification de l'existance du fichier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtDelimiter_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDelimiter.Validated
        Dim FichierAvant As String = TxNomFichier.Text
        If Not IO.File.Exists(FichierAvant) Then
            Exit Sub
        End If
        ChargementGrid()
    End Sub

#End Region

#Region "Chargement du grid"

    ''' <summary>
    ''' permet de rafraichir le contenu du fichier dans les tables et tableau
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lklRefresh_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lklRefresh.LinkClicked
        If cboDelimiter.SelectedIndex < 0 Then
            MsgBox("Veuillez sélectionner un élément dans la liste.", MsgBoxStyle.Critical, "Importation")
        ElseIf txtDelimiter.Text <> "" AndAlso IsNumeric(txtDelimiter.Text.Replace(";", "0")) Then
            MsgBox("Veuillez ne saisir que des entiers séparés par des point-virgules ex :10;12;6;45;2", MsgBoxStyle.Critical, "Importation")
        Else
            ChargementGrid()
        End If
    End Sub

    ''' <summary>
    ''' chargement du fichier dans le tableau de visu et aussi dans le datatable
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChargementGrid()

        Try
            If TxNomFichier.Text.Trim.Length = 0 Then Exit Sub
            Dim nComptLigne As Integer = 0
            Dim nColonne As Integer = 0
            Dim bDecoupageDelimiter As Boolean = True
            Dim nSeparation() As Integer
            Dim cSplitChar As String

            If bChargement Then Exit Sub

            'Vérifie l'existance du fichier
            Dim FichierAvant As String = TxNomFichier.Text
            If Not IO.File.Exists(FichierAvant) Then
                If MsgBox(String.Format("Le fichier {0} n'existe pas", IO.Path.GetFileName(FichierAvant)), MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor
            PanProgress.Visible = True
            Application.DoEvents()
            Try
                Try
                    ReportProgress(0, My.Resources.Strings.Initialisation)
                    Dim rapportErreur As New System.Text.StringBuilder

                    'détermine le type de découpage du fichier
                    ReportProgress(20, "Récupération des données...")
                    If CInt(CType(cboTypeFile.SelectedItem, ListboxItem).Value) = 1 Then
                        bDecoupageDelimiter = True
                        cSplitChar = CType(cboDelimiter.SelectedItem, ListboxItem).Value.ToString
                    Else
                        bDecoupageDelimiter = False
                        Dim ints() As String = txtDelimiter.Text.Split(";"c)
                        ReDim nSeparation(ints.Length - 1)
                        For i As Integer = 0 To ints.Length - 1
                            nSeparation(i) = CInt(ints(i).ToString)
                        Next
                    End If

                    ReportProgress(30, "Analyse des données...")
                    Dim sr As StreamReader = OuvertureFichier(FichierAvant)
                    Try
                        dtTableFull = New DataTable
                        Dim dtTableExploration As New DataTable
                        Dim ligne As String = sr.ReadLine
                        'fait ou pas sauter la première ligne d'entete
                        If chkHearder.Checked Then
                            ligne = sr.ReadLine
                        End If
                        'parcours le fichier
                        While Not ligne Is Nothing
                            nComptLigne += 1
                            If ligne.Trim.Length > 0 Then 'Ignorer les lignes vides
                                Try
                                    'coupe la ligne avec le découpage
                                    Dim sLigneDecoupe() As String
                                    If bDecoupageDelimiter Then
                                        sLigneDecoupe = ligne.Split(cSplitChar.ToCharArray)
                                    Else
                                        sLigneDecoupe = Split(ligne, nSeparation)
                                    End If

                                    'détermine le nombre de colonne à créer dans les tables et les réalisent ensuite
                                    If nColonne = 0 Then
                                        If sLigneDecoupe.Length > 0 Then
                                            nColonne = sLigneDecoupe.Length
                                            For i As Integer = 0 To sLigneDecoupe.Length - 1
                                                dtTableFull.Columns.Add(String.Format("Colonne {0}", i.ToString), GetType(String))
                                                dtTableExploration.Columns.Add(String.Format("Colonne {0}", i.ToString), GetType(String))
                                            Next
                                        End If
                                    End If

                                    'Alimente les tables
                                    Dim xRowFull As DataRow = dtTableFull.NewRow
                                    Dim xRow As DataRow = dtTableExploration.NewRow
                                    For i As Integer = 0 To nColonne - 1
                                        xRowFull(i) = sLigneDecoupe(i).ToString
                                        xRow(i) = sLigneDecoupe(i).ToString
                                    Next
                                    If nComptLigne < 21 Then
                                        dtTableExploration.Rows.Add(xRow)
                                    End If
                                    dtTableFull.Rows.Add(xRowFull)

                                Catch ex As FormatException
                                    Throw New Exception(String.Format("Erreur de format dans la ligne : '{0}'", ligne), ex)
                                End Try
                            End If
                            ligne = sr.ReadLine
                        End While
                        'Affecte la table au tableau
                        ReportProgress(50, "Chargement du tableau...")
                        dgvFile.DataSource = dtTableExploration

                        'Récupère le dataset pour la balance ou le grand livre afin de permettre de faire les affectation
                        xDatasetAffectation = New DataSet
                        WriteToTextFile(String.Format("{0}\Data\Temp.xml", My.Application.Info.DirectoryPath), My.Resources.ListeChampBalance)
                        xDatasetAffectation.ReadXml(String.Format("{0}\Data\Temp.xml", My.Application.Info.DirectoryPath))
                        IO.File.Delete(String.Format("{0}\Data\Temp.xml", My.Application.Info.DirectoryPath))

                        'met les affectations dans le tableau
                        dgvAffectation.DataSource = xDatasetAffectation.Tables(0)

                        'près charge les champs d'affectation avec le modèle s'il existe
                        Dim xRowSelected As GestionParametrageImportFichier.ItemParametrageImport = DirectCast(cboModele.SelectedItem, GestionParametrageImportFichier.ItemParametrageImport)
                        If xRowSelected IsNot Nothing AndAlso xRowSelected.Nom <> "" AndAlso xRowSelected.Nom <> "<Nouveau paramétrage>" Then
                            For Each xRowAffect As DataRow In xDatasetAffectation.Tables(0).Rows
                                If xRowSelected.Affectation.ContainsKey(xRowAffect("Champ").ToString) Then
                                    xRowAffect("Affectation") = xRowSelected.Affectation.Item(xRowAffect("Champ").ToString).ToString
                                End If
                            Next
                        End If

                        ReportProgress(70, "initialisation des listes déroulantes...")
                        nColonneFull = nColonne
                        xcboCompte = Nothing
                        xcboActivite = Nothing
                        xcboLibCompte = Nothing
                        xcboDebit = Nothing
                        xcboCredit = Nothing

                        ReportProgress(100, "Chargement terminé...")

                        If rapportErreur.ToString <> "" Then
                            MsgBox(rapportErreur.ToString, MsgBoxStyle.Critical, "Importation")
                        End If
                    Catch ex As Exception
                        Throw New Exception(ex.Message & vbCrLf & String.Format("Fichier '{0}', ligne {1}.", FichierAvant, nComptLigne), ex.InnerException)
                    Finally
                        sr.Close()
                    End Try

                    ReportProgress(100)

                Catch ex As ApplicationException
                    If MsgBox("L'Importation n'a pas pu être réalisée à cause des problèmes suivants :" & vbCrLf & _
                    ex.Message & vbCrLf & "Souhaitez-vous enregistrer ce rapport ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Attention") = MsgBoxResult.Yes Then
                        With ErrorDlg
                            .DefaultExt = "txt"
                            .Filter = "Fichiers texte (*.txt)|*.txt"
                            .FileName = "Rapport d'erreur exportation compta.txt"
                            If .ShowDialog = DialogResult.OK Then
                                WriteToTextFile(.FileName, ex.Message)
                                Process.Start(.FileName)
                            End If
                        End With
                    End If
                    Me.DialogResult = DialogResult.Cancel
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "test")
                End Try
            Finally
                PanProgress.Visible = False
                Cursor.Current = Cursors.Default
            End Try
        Catch ex As Exception
            Throw New ApplicationException("Problème de sauvegarde", ex)
        End Try

    End Sub

    ''' <summary>
    ''' charge le combo dans le grid des affectation (colonne 1, colonne 2, colonne3, etc)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvAffectation_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvAffectation.EditingControlShowing

        Try
            If TypeOf e.Control Is ComboBox AndAlso dgvAffectation.CurrentCell.ColumnIndex = 1 Then
                Dim cbo As ComboBox
                cbo = CType(e.Control, ComboBox)
                ChargementCombo(cbo, nColonneFull)
                cbo.DropDownWidth = 250
                cbo.DropDownStyle = ComboBoxStyle.DropDownList
            End If

        Catch ex As Exception
            Dim test As String = ex.Message
        End Try

    End Sub

    ''' <summary>
    ''' permet de supprimer un élément du combo
    ''' </summary>
    ''' <param name="cboCombo"></param>
    ''' <param name="nSuppr"></param>
    ''' <remarks></remarks>
    Private Sub SuppressionItemCombo(ByVal cboCombo As ComboBox, ByVal nSuppr As Integer)

        For i As Integer = cboCombo.Items.Count - 1 To 0 Step -1
            If CInt(CType(cboCombo.Items(i), ListboxItem).Value) = nSuppr Then
                cboCombo.Items.RemoveAt(i)
            End If
        Next

    End Sub

#End Region

#Region "Gestion du chargement de l'Avant"

    ''' <summary>
    ''' Lance la restauration du fichier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtRestaurer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRestaurer.Click
        Dim TempTable As DataTable = dtTableFull.Copy
        Try
            'Vérifie qu'il existe des enregistrements
            If dtTableFull.Rows.Count = 0 Then
                MsgBox("Vous n'avez aucune ligne à charger", MsgBoxStyle.Critical, "Importation")
                Exit Sub
            End If

            'Chargement de la liste des colonnes à traiter
            Dim xListElement As New SortedList
            For Each xRow As DataRow In xDatasetAffectation.Tables(0).Rows
                xListElement.Add(xRow("Champ").ToString, xRow("Affectation").ToString)
            Next

            'Vérifie de type d'Avant (Balance ou GL)
            If rbtBalance.Checked Then
                If Not ImportationFichierSaisie.ChargementBalance(dtTableFull, xListElement) Then
                    dtTableFull = TempTable.Copy
                Else
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
            End If
        Catch ex As Exception
            dtTableFull = TempTable.Clone
            Throw New ApplicationException("Problème d'Importation", ex)
        End Try

    End Sub

#End Region

#Region "Divers"

    ''' <summary>
    ''' permet de recharger la liste de paramétrage de fichier
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbtGL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtGL.CheckedChanged
        ChargementListModele()
    End Sub

    ''' <summary>
    ''' bouton d'annulation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ''' <summary>
    ''' bouton pour aller chercher le fichier a importer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBrowse.Click

        With RestDlg
            .Multiselect = False
            If .ShowDialog = DialogResult.OK Then
                TxNomFichier.Text = .FileName
            End If
        End With

    End Sub

    ''' <summary>
    ''' permet d'ouvrir un fichier
    ''' </summary>
    ''' <param name="sFichierAvant"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function OuvertureFichier(ByVal sFichierAvant As String) As StreamReader
        Try
            Dim xEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding(1200)
            If cboCodePage.Enabled Then
                xEncoding = System.Text.Encoding.GetEncoding(CInt(CType(cboCodePage.SelectedItem, ListboxItem).Value))
            End If
            Dim StreamAvant As New StreamReader(sFichierAvant, xEncoding)
            Return StreamAvant
        Catch ex As Exception
            Throw New ApplicationException("Problème d'ouverture du fichier d'avant", ex)
        End Try
    End Function

    ''' <summary>
    ''' permet d'écrire dans un fichier
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Private Sub WriteToTextFile(ByVal filename As String, ByVal text As String)
        Dim sw As New IO.StreamWriter(filename)
        Try
            sw.WriteLine(text)
        Finally
            sw.Close()
        End Try
    End Sub

    ''' <summary>
    ''' permet de spliter un liste de chiffre et de retourner une liste de caractère
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="fieldsWidth"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Split(ByVal str As String, ByVal fieldsWidth() As Integer) As String()
        Dim res(fieldsWidth.Length - 1) As String
        Dim pos As Integer = 0
        For i As Integer = 0 To fieldsWidth.Length - 1
            If str.Length >= pos + fieldsWidth(i) Then
                res(i) = str.Substring(pos, fieldsWidth(i))
                pos += fieldsWidth(i)
            Else : Exit For
            End If
        Next
        Return res
    End Function

    ''' <summary>
    ''' barre de progression
    ''' </summary>
    ''' <param name="percent"></param>
    ''' <param name="status"></param>
    ''' <param name="max"></param>
    ''' <remarks></remarks>
    Private Sub ReportProgress(ByVal percent As Integer, Optional ByVal status As Object = Nothing, Optional ByVal max As Integer = 100)
        If Not status Is Nothing AndAlso TypeOf status Is String Then
            Me.lbStatus.Text = Convert.ToString(status)
            Application.DoEvents()
        End If
        Me.pgBar.Value = (percent * 100 \ max)
    End Sub

#End Region

    ''' <summary>
    ''' recharge la grille lorsque la case est coché
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkHearder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHearder.CheckedChanged
        ChargementGrid()
    End Sub

End Class

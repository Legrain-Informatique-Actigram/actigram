Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Xml.Serialization

Namespace GestionParametrageImportFichier
    Public Class ParametrageImportFichier

        Private Const NOMFICHIER As String = "ParametrageImportFichier.xml"
        Private Const NOMFICHIERUSER As String = "ParametrageImportFichierUser.xml"

        Public Enum ItemType
            Balance
            GrandLivre
        End Enum

        <XmlAttribute()> Public Type As ItemType
        <XmlArray(), XmlArrayItem("Item", GetType(ItemParametrageImport))> _
          Public Items As New List(Of ItemParametrageImport)

#Region "Gestion XML"
        Public Shared Function LoadFromString(ByVal s As String) As List(Of ParametrageImportFichier)
            Using st As New IO.StringReader(s)
                Return LoadFromTextReader(st)
            End Using
        End Function

        Private Shared Function LoadFromTextReader(ByVal s As IO.TextReader) As List(Of ParametrageImportFichier)
            Dim res As List(Of ParametrageImportFichier)
            Dim xser As New XmlSerializer(GetType(List(Of ParametrageImportFichier)))
            res = DirectCast(xser.Deserialize(s), List(Of ParametrageImportFichier))
            Return res
        End Function

        Private Shared Sub SaveToTextReader(ByVal s As IO.TextWriter, ByVal list As List(Of ParametrageImportFichier))
            Dim xser As New XmlSerializer(GetType(List(Of ParametrageImportFichier)))
            xser.Serialize(s, list)
        End Sub

        Public Shared Function LoadFromFile(ByVal path As String) As List(Of ParametrageImportFichier)
            Using sr As New IO.StreamReader(path)
                Return LoadFromTextReader(sr)
            End Using
        End Function

        Public Shared Sub SaveToFile(ByVal path As String, ByVal list As List(Of ParametrageImportFichier))
            Using sw As New IO.StreamWriter(path)
                SaveToTextReader(sw, list)
            End Using
        End Sub
#End Region

#Region "Propriétés"
        Public Shared ReadOnly Property CheminFichierMaster() As String
            Get
                Return IO.Path.Combine(String.Format("{0}\Data\", My.Application.Info.DirectoryPath), NOMFICHIER)
            End Get
        End Property

        Public Shared ReadOnly Property CheminFichierUser() As String
            Get
                Return IO.Path.Combine(My.Application.GetAppDataPath, NOMFICHIERUSER)
            End Get
        End Property
#End Region

#Region "Méthodes partagées"
        ''' <summary>
        ''' permet de charge la liste de paramétrage en chargeant la liste utilisateur et par défaut
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ChargerParametrageImportFichier() As List(Of ParametrageImportFichier)
            Dim pathMaster As String = CheminFichierMaster
            Dim path As String = CheminFichierUser
            If Not IO.File.Exists(pathMaster) Then
                SaveToFile(pathMaster, New List(Of ParametrageImportFichier))
            End If
            If Not IO.File.Exists(path) Then
                SaveToFile(path, New List(Of ParametrageImportFichier))
            End If
            Dim xFusion As List(Of ParametrageImportFichier)
            Dim xFusion2 As List(Of ParametrageImportFichier)
            xFusion = LoadFromFile(pathMaster)
            For k As Integer = 0 To xFusion.Count - 1
                For i As Integer = 0 To xFusion(k).Items.Count - 1
                    xFusion(k).Items(i).bModifiable = False
                Next
            Next
            xFusion2 = LoadFromFile(path)
            If xFusion2.Count > 0 Then
                If xFusion(0).Type = ItemType.Balance AndAlso xFusion2(0).Type = ItemType.Balance Then
                    xFusion(0).Items.AddRange(xFusion2(0).Items)
                Else
                    xFusion(1).Items.AddRange(xFusion2(1).Items)
                End If
            End If
            Return xFusion

        End Function

        ''' <summary>
        ''' permet de filtrer de la liste les éléments par defaut avant de sauvegarder
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks></remarks>
        Public Shared Sub EnregistrerParametrageImportFichier(ByVal list As List(Of ParametrageImportFichier))

            For k As Integer = 0 To list.Count - 1
                For i As Integer = list(k).Items.Count - 1 To 0 Step -1
                    If Not list(k).Items(i).bModifiable Then
                        list(k).Items.RemoveAt(i)
                    End If
                Next
            Next
            SaveToFile(CheminFichierUser, list)
        End Sub
#End Region

    End Class

    Public Class ItemParametrageImport

        Private _nom As String
        <XmlAttribute()> _
              Public Property Nom() As String
            Get
                Return _nom
            End Get
            Set(ByVal value As String)
                _nom = value
            End Set
        End Property
        Public bModifiable As Boolean = True
        <XmlAttribute()> Public Codage As String
        <XmlAttribute()> Public TypeDelimiter As String
        <XmlAttribute()> Public Delimiter As String
        <XmlAttribute()> Public Header As String
        Public Affectation As SerializableDictionary(Of String, String)
    End Class
End Namespace

Namespace GestionFormatFichierIsagri
    Public Class FormatFichierIsagri
        <XmlAttribute()> Public Version As String
        Public FormatsLigne As SerializableDictionary(Of String, String)

#Region "Gestion XML"
        Public Shared Function LoadFromString(ByVal s As String) As List(Of FormatFichierIsagri)
            Dim xser As New XmlSerializer(GetType(List(Of FormatFichierIsagri)))
            Dim st As New IO.StringReader(s)
            Dim res As List(Of FormatFichierIsagri) = DirectCast(xser.Deserialize(st), List(Of FormatFichierIsagri))
            st.Close()
            Return res
        End Function
#End Region

        Public Shared Function ChargerFormatFichierIsagri(ByVal sVersion As String) As FormatFichierIsagri

            Dim ListFormat As List(Of FormatFichierIsagri) = GestionFormatFichierIsagri.FormatFichierIsagri.LoadFromString(My.Resources.FormatFichierIsagri)

            For Each xFormat As FormatFichierIsagri In ListFormat
                If xFormat.Version = sVersion Then Return xFormat
            Next
            Return Nothing

        End Function
    End Class
End Namespace

''' <summary>
''' permet la sérialisation d'une liste
''' </summary>
''' <typeparam name="TKey"></typeparam>
''' <typeparam name="TValue"></typeparam>
''' <remarks></remarks>
<XmlRoot("dictionary")> _
Public Class SerializableDictionary(Of TKey, TValue)
    Inherits Dictionary(Of TKey, TValue)
    Implements IXmlSerializable

#Region "IXmlSerializable Members"
    Public Function GetSchema() As System.Xml.Schema.XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function

    Public Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
        Dim keySerializer As New XmlSerializer(GetType(TKey))
        Dim valueSerializer As New XmlSerializer(GetType(TValue))
        Dim wasEmpty As Boolean = reader.IsEmptyElement
        reader.Read()

        If wasEmpty Then
            Return
        End If

        While reader.NodeType <> System.Xml.XmlNodeType.EndElement
            reader.ReadStartElement("item")
            reader.ReadStartElement("key")
            Dim key As TKey = DirectCast(keySerializer.Deserialize(reader), TKey)
            reader.ReadEndElement()
            reader.ReadStartElement("value")
            Dim value As TValue = DirectCast(valueSerializer.Deserialize(reader), TValue)
            reader.ReadEndElement()
            Me.Add(key, value)
            reader.ReadEndElement()
            reader.MoveToContent()
        End While
        reader.ReadEndElement()
    End Sub

    Public Sub WriteXml(ByVal writer As System.Xml.XmlWriter) Implements IXmlSerializable.WriteXml
        Dim keySerializer As New XmlSerializer(GetType(TKey))
        Dim valueSerializer As New XmlSerializer(GetType(TValue))
        For Each key As TKey In Me.Keys
            writer.WriteStartElement("item")
            writer.WriteStartElement("key")
            keySerializer.Serialize(writer, key)
            writer.WriteEndElement()
            writer.WriteStartElement("value")
            Dim value As TValue = Me(key)
            valueSerializer.Serialize(writer, value)
            writer.WriteEndElement()
            writer.WriteEndElement()
        Next
    End Sub
#End Region

End Class


'Public Class ImportationFichierSaisie
'    'TODO EXTERNALISATION ET CORRECTION MESSAGES

'    ''' <summary>
'    ''' permet le chargement de la balance a partir d'un fichier 
'    ''' </summary>
'    ''' <param name="dtTableFull"></param>
'    ''' <param name="xListElement"></param>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Shared Function ChargementBalance(ByVal dtTableFull As DataTable, ByVal xListElement As SortedList) As Boolean
'        Try
'            'Vérifie qu'il existe une colonne compte et de montant
'            If xListElement.Item("Compte").ToString = "" Then
'                MsgBox("Veuillez sélectionner une colonne pour le numéro du compte", MsgBoxStyle.Critical, "Importation")
'                Return False
'            End If
'        Catch ex As Exception
'            Throw New ApplicationException("Vérifie qu'il existe une colonne compte et de montant", ex)
'        End Try

'        'Recherche le type de montant soit sur une colonne ou deux
'        Dim bDeuxMontant As Boolean = True
'        If xListElement.Item("Debit").ToString = "" Or xListElement.Item("Credit").ToString = "" Then bDeuxMontant = False

'        Try
'            'Réinitialise le tableau de données
'            If dtTableFull.Columns.Contains("NewActivite") Then dtTableFull.Columns.Remove("NewActivite")
'            If dtTableFull.Columns.Contains("NewCompte") Then dtTableFull.Columns.Remove("NewCompte")
'            For i As Integer = 0 To dtTableFull.Columns.Count - 1
'                dtTableFull.Columns(i).ColumnName = String.Format("Colonne {0}", i.ToString)
'            Next
'        Catch ex As Exception
'            Throw New ApplicationException("Ré-initialise le tableau de données", ex)
'        End Try

'        Try
'            'Affecte les noms de colonne au tableau de donnée en fonction de la liste des colonnes à traiter
'            For i As Integer = dtTableFull.Columns.Count - 1 To 0 Step -1
'                If xListElement.ContainsKey(dtTableFull.Columns(i).ColumnName) Then
'                ElseIf Not xListElement.ContainsValue(dtTableFull.Columns(i).ColumnName) Then
'                    dtTableFull.Columns.RemoveAt(i)
'                Else
'                    dtTableFull.Columns(i).ColumnName = xListElement.GetKey(xListElement.IndexOfValue(dtTableFull.Columns(i).ColumnName)).ToString()
'                End If
'            Next
'            Dim nb As Integer = 0
'            For Each xItem As String In xListElement.Values
'                If xItem <> "" Then
'                    nb += 1
'                End If
'            Next
'            If dtTableFull.Columns.Count <> nb Then
'                MsgBox("Vous n'avez pas le même nombre de colonnes dans l'affectation et dans la visu des données", MsgBoxStyle.Critical, "Importation")
'                Return False
'            End If
'        Catch ex As Exception
'            Throw New ApplicationException("Affecte les noms de colonne au tableau de données en fonction de la liste des colonnes à traiter", ex)
'        End Try

'        Try
'            'Vérifie les données (longueur et type de chaine)
'            For Each xRow As DataRow In dtTableFull.Rows
'                If Len(xRow("Compte").ToString.Trim) > 8 Then
'                    MsgBox("Vous ne pouvez pas avoir de compte supérieur à 8 caractères" + vbCrLf + "Veuillez modifier le découpage du fichier ou modifiez le fichier", MsgBoxStyle.Critical, "Importation")
'                    Return False
'                ElseIf xListElement.Item("Activite").ToString <> "" AndAlso Len(xRow("Activite").ToString.Trim) > 4 Then
'                    MsgBox("Vous ne pouvez pas avoir une activité supérieur à 4 caractères" + vbCrLf + "Veuillez modifier le découpage du fichier ou modifiez le fichier", MsgBoxStyle.Critical, "Importation")
'                    Return False
'                ElseIf xListElement.Item("Activite").ToString <> "" AndAlso Not IsNumeric(xRow("Activite").ToString.Trim.Replace(".", ",")) Then
'                    MsgBox("Votre activité doit être composé uniquement de chiffres et sur une longueur de 4 caractères", MsgBoxStyle.Critical, "Importation")
'                    Return False
'                ElseIf bDeuxMontant Then
'                    If xListElement.Item("Debit").ToString.Trim <> "" AndAlso Not IsNumeric(xRow("Debit").ToString.Trim.Replace(".", ",")) Then
'                        If Not IsNumeric(xRow("Debit").ToString.Trim.Replace(".", ",")) Or Not IsNumeric(xRow("Credit").ToString.Trim.Replace(".", ",")) Then
'                            MsgBox("Votre débit et crédit doit être composé uniquement de chiffres", MsgBoxStyle.Critical, "Importation")
'                            Return False
'                        End If
'                    End If
'                Else
'                    If xListElement.Item("Debit").ToString.Trim <> "" AndAlso Not IsNumeric(xRow("Debit").ToString.Trim.Replace(".", ",")) Then
'                        MsgBox("Votre débit doit être composé uniquement de chiffres", MsgBoxStyle.Critical, "Importation")
'                        Return False
'                    End If
'                    If xListElement.Item("Credit").ToString.Trim <> "" AndAlso Not IsNumeric(xRow("Credit").ToString.Trim.Replace(".", ",")) Then
'                        MsgBox("Votre crédit doit être composé uniquement de chiffres", MsgBoxStyle.Critical, "Importation")
'                        Return False
'                    End If
'                End If
'            Next
'        Catch ex As Exception
'            Throw New ApplicationException("Vérifiez les données (longueurs et type de chaîne)", ex)
'        End Try

'        Dim xDatasetNewData As New dbSauvRest
'        Dim dtActivite As New DataTable
'        Dim dtCompte As New DataTable

'        Dim dtPlanType As New dsPLC.PlanTypeDataTable
'        Dim dtRica As New dsPLC.RicaDataTable

'        Try
'            'charge le dataset
'            Using dt As New dsPLCTableAdapters.PlanTypeTableAdapter
'                dt.Fill(dtPlanType)
'            End Using
'            Using dt As New dsPLCTableAdapters.RicaTableAdapter
'                dt.Fill(dtRica)
'            End Using
'            Using dt As New dbSauvRestTableAdapters.ComptesTableAdapter
'                dt.FillByDossier(xDatasetNewData.Comptes, My.User.Name)
'            End Using
'            Using dt As New dbSauvRestTableAdapters.ActivitesTableAdapter
'                dt.FillByDossier(xDatasetNewData.Activites, My.User.Name)
'            End Using
'            Using dt As New dbSauvRestTableAdapters.PlanComptableTableAdapter
'                dt.FillByDossier(xDatasetNewData.PlanComptable, My.User.Name)
'            End Using

'            'Chargement de la fenetre pour réaffecter les comptes 
'            Using fr As New FrManagerCompte
'                fr.DataFile = dtTableFull
'                If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
'                    dtCompte = fr.DataCompte
'                Else
'                    Return False
'                End If
'            End Using
'            If dtTableFull.Columns.IndexOf("Activite") <> -1 Then
'                'Chargement de la fenetre pour réaffecter les activités 
'                Using fr As New FrManagerActivite
'                    fr.DataFile = dtTableFull
'                    If fr.ShowDialog = Windows.Forms.DialogResult.OK Then
'                        dtActivite = fr.DataActivite
'                    Else
'                        Return False
'                    End If
'                End Using
'            End If

'            Cursor.Current = Cursors.WaitCursor

'            'Chargement des nouvelles données
'            dtTableFull.Columns.Add("NewActivite", GetType(String))
'            dtTableFull.Columns.Add("NewCompte", GetType(String))
'            dtTableFull.Columns.Add("NewLibelleCompte", GetType(String))

'            If dtActivite.Rows.Count > 0 Then
'                For Each xRowActivite As DataRow In dtActivite.Rows
'                    For Each xData As DataRow In dtTableFull.Rows
'                        If xData("Activite").ToString = xRowActivite("Avant").ToString Then
'                            xData("NewActivite") = xRowActivite("Apres").ToString.Trim
'                        End If
'                    Next
'                Next
'            Else
'                For Each xData As DataRow In dtTableFull.Rows
'                    xData("NewActivite") = "0000"
'                Next
'            End If
'            For Each xRowCompte As DataRow In dtCompte.Rows
'                For Each xData As DataRow In dtTableFull.Rows
'                    If xData("Compte").ToString.Trim = xRowCompte("Avant").ToString.Trim Then
'                        xData("NewCompte") = xRowCompte("Compte").ToString.Trim
'                        If dtTableFull.Columns.IndexOf("NewLibelleCompte") <> -1 Then
'                            xData("NewLibelleCompte") = xRowCompte("LibelleCompte").ToString
'                        End If
'                        Exit For
'                    End If
'                Next
'            Next

'            'Implémentation des activités
'            If xDatasetNewData.Activites.Select(String.Format("AActi='{0}'", "0000")).Length = 0 Then
'                Dim xRowActiVide As dbSauvRest.ActivitesRow = xDatasetNewData.Activites.NewActivitesRow
'                xRowActiVide.ADossier = My.User.Name
'                xRowActiVide.AActi = "0000"
'                xRowActiVide.ALib = "Activité générale"
'                xRowActiVide.AUnit = ""
'                xDatasetNewData.Activites.AddActivitesRow(xRowActiVide)
'            End If
'            If dtActivite IsNot Nothing Then
'                If xDatasetNewData.Activites.Rows.Count > 0 OrElse dtTableFull.Rows.Count > 0 Then
'                    For Each xRow As DataRow In AgriTools.SelectDistinct(dtTableFull, "NewActivite").Rows
'                        If xDatasetNewData.Activites.Select(String.Format("AActi='{0}'", Convert.ToString(xRow("NewActivite")).Trim)).Length = 0 Then
'                            Dim xActiviteTypeRow As DataRow = dtRica.Select(String.Format("RiCode='{0}'", Convert.ToString(xRow("NewActivite")).Trim))(0)
'                            If xActiviteTypeRow Is Nothing Then Return False
'                            Dim xRowActi As dbSauvRest.ActivitesRow = xDatasetNewData.Activites.NewActivitesRow
'                            xRowActi.ADossier = My.User.Name
'                            xRowActi.AActi = Convert.ToString(xRow("NewActivite")).Trim
'                            xRowActi.ALib = Microsoft.VisualBasic.Left(xActiviteTypeRow("RiLib1").ToString, 25)
'                            xRowActi.AUnit = Microsoft.VisualBasic.Left(xActiviteTypeRow("RiUnite").ToString, 25)
'                            xDatasetNewData.Activites.AddActivitesRow(xRowActi)
'                        End If
'                    Next
'                End If
'            End If

'            'Implémentation des Comptes
'            If xDatasetNewData.Comptes.Select(String.Format("CCpt='{0}'", "48800000")).Length = 0 Then
'                Dim xRowCompte As dbSauvRest.ComptesRow = xDatasetNewData.Comptes.NewComptesRow
'                xRowCompte.CDossier = My.User.Name
'                xRowCompte.CCpt = "48800000"
'                xDatasetNewData.Comptes.AddComptesRow(xRowCompte)
'            End If
'            For Each xRow As DataRow In AgriTools.SelectDistinct(dtTableFull, "NewCompte").Rows
'                If xDatasetNewData.Comptes.Select(String.Format("CCpt='{0}'", Convert.ToString(xRow("NewCompte")).Trim)).Length = 0 Then
'                    Dim xCompteTypeRow As DataRow
'                    If dtPlanType.Select(String.Format("PlCpt='{0}'", Microsoft.VisualBasic.Left(Convert.ToString(xRow("NewCompte")), 8))).Length = 0 Then
'                        xCompteTypeRow = dtPlanType.Select(String.Format("'{0}' like PlRacine+'*'", Microsoft.VisualBasic.Left(Convert.ToString(xRow("NewCompte")).Trim, 8)))(0)
'                    Else
'                        xCompteTypeRow = dtPlanType.Select(String.Format("PlCpt='{0}'", Microsoft.VisualBasic.Left(Convert.ToString(xRow("NewCompte")).Trim, 8)))(0)
'                    End If
'                    If xCompteTypeRow Is Nothing Then Return False
'                    Dim xRowCompte As dbSauvRest.ComptesRow = xDatasetNewData.Comptes.NewComptesRow
'                    xRowCompte.CDossier = My.User.Name
'                    xRowCompte.CCpt = Convert.ToString(xRow("NewCompte")).Trim
'                    xRowCompte.CLib = Microsoft.VisualBasic.Left(dtTableFull.Select(String.Format("NewCompte='{0}'", Microsoft.VisualBasic.Left(Convert.ToString(xRow("NewCompte")).Trim, 8)))(0).Item("NewLibelleCompte").ToString, 30)
'                    'xRowCompte.CLib = Microsoft.VisualBasic.Left(xCompteTypeRow("PlLib").ToString, 30)
'                    xRowCompte.CU1 = CStr(IIf(xCompteTypeRow("PlU1").ToString = "", Nothing, xCompteTypeRow("PlU1").ToString))
'                    xRowCompte.CU2 = CStr(IIf(xCompteTypeRow("PlU2").ToString = "", Nothing, xCompteTypeRow("PlU2").ToString))
'                    xRowCompte.C_DC = Convert.ToString(xCompteTypeRow("PlD_C"))
'                    xDatasetNewData.Comptes.AddComptesRow(xRowCompte)
'                End If
'            Next

'            'Implémentation du plan comptable
'            If xDatasetNewData.PlanComptable.Select(String.Format("PlCpt='{0}' and PlActi='{1}'", "48800000", "0000")).Length = 0 Then
'                Dim xRowPlanComptable As dbSauvRest.PlanComptableRow = xDatasetNewData.PlanComptable.NewPlanComptableRow
'                xRowPlanComptable.PlDossier = My.User.Name
'                xRowPlanComptable.PlCpt = "48800000"
'                xRowPlanComptable.PlActi = "0000"
'                xDatasetNewData.PlanComptable.AddPlanComptableRow(xRowPlanComptable)
'            End If
'            For Each xRow As DataRow In AgriTools.SelectDistinct(dtTableFull, "NewActivite", "NewCompte").Rows
'                If xDatasetNewData.PlanComptable.Select(String.Format("PlCpt='{0}' and PlActi='{1}'", Convert.ToString(xRow("NewCompte")), Convert.ToString(xRow("NewActivite")))).Length = 0 Then
'                    Dim xRowPlanComptable As dbSauvRest.PlanComptableRow = xDatasetNewData.PlanComptable.NewPlanComptableRow
'                    xRowPlanComptable.PlDossier = My.User.Name
'                    xRowPlanComptable.PlCpt = Convert.ToString(xRow("NewCompte").ToString)
'                    xRowPlanComptable.PlActi = Convert.ToString(xRow("NewActivite").ToString.Trim)
'                    Dim drCpt As dbSauvRest.ComptesRow = xDatasetNewData.Comptes.FindByCDossierCCpt(My.User.Name, Convert.ToString(xRow("NewCompte").ToString.Trim))
'                    Dim drAct As dbSauvRest.ActivitesRow = xDatasetNewData.Activites.FindByADossierAActi(My.User.Name, Convert.ToString(xRow("NewActivite").ToString.Trim))
'                    xRowPlanComptable.PlLib = Convert.ToString(drCpt.Item("CLib")) + " - " + Convert.ToString(drAct.Item("ALib"))
'                    xDatasetNewData.PlanComptable.AddPlanComptableRow(xRowPlanComptable)
'                End If
'            Next

'            If xListElement.Item("Debit").ToString <> "" OrElse xListElement.Item("Credit").ToString <> "" Then
'                'intégration des données
'                Dim nOrdreD As Byte = 1
'                Dim nOrdreC As Byte = 3

'                Dim j As Integer = 0
'                Dim xRowPiece As dbSauvRest.PiecesRow = xDatasetNewData.Pieces.NewPiecesRow
'                xRowPiece.PDossier = My.User.Name
'                xRowPiece.PPiece = 1
'                xRowPiece.PDate = (CType(My.User.CurrentPrincipal, DossierPrincipal).DateDebutEx)
'                xRowPiece.Libelle = "A Nouveau"
'                xRowPiece.Journal = CType(My.User.CurrentPrincipal, DossierPrincipal).sJournal
'                xDatasetNewData.Pieces.AddPiecesRow(xRowPiece)

'                For Each xRow As DataRow In dtTableFull.Rows
'                    'todo : mettre la barre de progression en référence
'                    'ReportProgress(j, "Mise à jour des données", dtTableFull.Rows.Count)
'                    'Détermination du crédit et débit en fonction des colonnes indiqué
'                    Dim nDebit As Decimal = 0
'                    Dim nCredit As Decimal = 0
'                    If xRow("Debit").ToString.Trim = "" Then xRow("Debit") = "0"
'                    If xRow("Credit").ToString.Trim = "" Then xRow("Credit") = "0"

'                    If bDeuxMontant Then
'                        nDebit = CDec(xRow("Debit").ToString.Trim.Replace(".", ","))
'                        nCredit = CDec(xRow("Credit").ToString.Trim.Replace(".", ","))
'                    Else
'                        If dtTableFull.Columns.IndexOf("Debit") <> -1 Then
'                            If CDec(xRow("Debit").ToString.Replace(".", ",")) > 0 Then
'                                nDebit = CDec(xRow("Debit").ToString.Replace(".", ","))
'                            Else
'                                nCredit = CDec(xRow("Debit").ToString.Replace(".", ","))
'                            End If
'                        Else
'                            If CDec(xRow("Credit")) > 0 Then
'                                nCredit = CDec(xRow("Credit").ToString.Replace(".", ","))
'                            Else
'                                nDebit = CDec(xRow("Credit").ToString.Replace(".", ","))
'                            End If
'                        End If
'                    End If
'                    If nCredit > 0 Then

'                    End If
'                    'passe au compte suivant si celui ci est vide en débit et crédit
'                    If nDebit = 0 AndAlso nCredit = 0 Then Continue For

'                    Try
'                        'créer la ligne
'                        Dim xRowLigne As dbSauvRest.LignesRow = xDatasetNewData.Lignes.NewLignesRow
'                        xRowLigne.LDossier = My.User.Name
'                        xRowLigne.LPiece = 1
'                        xRowLigne.LDate = (CType(My.User.CurrentPrincipal, DossierPrincipal).DateDebutEx)
'                        xRowLigne.LLig = j
'                        xRowLigne.LLib = Convert.ToString(xRow("NewLibelleCompte"))
'                        xRowLigne.LGene = "O"
'                        xRowLigne.LAna = "O"
'                        xRowLigne.LJournal = CType(My.User.CurrentPrincipal, DossierPrincipal).sJournal
'                        xDatasetNewData.Lignes.AddLignesRow(xRowLigne)

'                        'créer le mouvement 1
'                        Dim xRowMouvt1 As dbSauvRest.MouvementsRow = xDatasetNewData.Mouvements.NewMouvementsRow
'                        xRowMouvt1.MDossier = My.User.Name
'                        xRowMouvt1.MPiece = 1
'                        xRowMouvt1.MDate = (CType(My.User.CurrentPrincipal, DossierPrincipal).DateDebutEx)
'                        xRowMouvt1.MLig = j
'                        xRowMouvt1.MOrdre = CByte(IIf(nDebit = 0, nOrdreD, nOrdreC))
'                        xRowMouvt1.MCpt = xRow("NewCompte").ToString
'                        xRowMouvt1.MActi = CStr(IIf(xRow("NewActivite") Is Nothing, "0000", xRow("NewActivite").ToString))
'                        xRowMouvt1.MMtDeb = nDebit
'                        xRowMouvt1.MMtCre = nCredit
'                        xRowMouvt1.MQte1 = 0
'                        xRowMouvt1.MQte2 = 0
'                        xRowMouvt1.MD_C = CStr(IIf(nDebit = 0, "C", "D"))
'                        xRowMouvt1.MCptCtr = "48800000"
'                        xRowMouvt1.MActCtr = "0000"
'                        xDatasetNewData.Mouvements.AddMouvementsRow(xRowMouvt1)

'                        'créer le mouvement 3
'                        Dim xRowMouvt2 As dbSauvRest.MouvementsRow = xDatasetNewData.Mouvements.NewMouvementsRow
'                        xRowMouvt2.MDossier = My.User.Name
'                        xRowMouvt2.MPiece = 1
'                        xRowMouvt2.MDate = (CType(My.User.CurrentPrincipal, DossierPrincipal).DateDebutEx)
'                        xRowMouvt2.MLig = j
'                        xRowMouvt2.MOrdre = CByte(IIf(nCredit = 0, nOrdreD, nOrdreC))
'                        xRowMouvt2.MCpt = "48800000"
'                        xRowMouvt2.MActi = "0000"
'                        xRowMouvt2.MMtDeb = nCredit
'                        xRowMouvt2.MMtCre = nDebit
'                        xRowMouvt2.MQte1 = 0
'                        xRowMouvt2.MQte2 = 0
'                        xRowMouvt2.MD_C = CStr(IIf(nCredit = 0, "C", "D"))
'                        xRowMouvt2.MCptCtr = xRow("NewCompte").ToString
'                        xRowMouvt2.MActCtr = CStr(IIf(xRow("NewActivite") Is Nothing, "0000", xRow("NewActivite").ToString))
'                        xDatasetNewData.Mouvements.AddMouvementsRow(xRowMouvt2)

'                    Catch ex As Exception
'                        Throw New ApplicationException("Problème sur l'ajout de mouvements pour l'Avant de fichier", ex)
'                    End Try
'                    j += 1
'                Next
'            End If

'            'commit l'ensemble de l'exercice avec la pièce d'a nouveau si l'on a indiqué des colonnes de débit ou de crédit
'            Using conn As New OleDb.OleDbConnection(My.Settings.dbDonneesConnectionString)
'                Dim t As OleDb.OleDbTransaction
'                Try
'                    conn.Open()
'                    t = conn.BeginTransaction
'                    Using dta As New dbSauvRestTableAdapters.ActivitesTableAdapter
'                        dta.SetTransaction(t)
'                        dta.Update(xDatasetNewData.Activites)
'                    End Using
'                    Using dta As New dbSauvRestTableAdapters.ComptesTableAdapter
'                        dta.SetTransaction(t)
'                        dta.Update(xDatasetNewData.Comptes)
'                    End Using
'                    Using dta As New dbSauvRestTableAdapters.PlanComptableTableAdapter
'                        dta.SetTransaction(t)
'                        dta.Update(xDatasetNewData.PlanComptable)
'                    End Using
'                    'met les la pièce d'a nouveau si alimenté
'                    If xListElement.Item("Debit").ToString <> "" OrElse xListElement.Item("Credit").ToString <> "" Then
'                        Using dta As New dbSauvRestTableAdapters.PiecesTableAdapter
'                            dta.SetTransaction(t)
'                            dta.Update(xDatasetNewData.Pieces)
'                        End Using
'                        Using dta As New dbSauvRestTableAdapters.LignesTableAdapter
'                            dta.SetTransaction(t)
'                            dta.Update(xDatasetNewData.Lignes)
'                        End Using
'                        Using dta As New dbSauvRestTableAdapters.MouvementsTableAdapter
'                            dta.SetTransaction(t)
'                            dta.Update(xDatasetNewData.Mouvements)
'                        End Using
'                    End If
'                    t.Commit()
'                    MsgBox("L'importation c'est terminé correctement", MsgBoxStyle.Information, "Importation")
'                    Return True
'                Catch ex As Exception
'                    If t IsNot Nothing Then t.Rollback()
'                    Throw New ApplicationException("Problème de mise à jour des données dans la base de données", ex)
'                End Try
'            End Using
'        Catch ex As Exception
'            Throw New ApplicationException("Erreur d'intégration des données en base.", ex)
'        Finally
'            Cursor.Current = Cursors.Default
'        End Try
'    End Function

'End Class
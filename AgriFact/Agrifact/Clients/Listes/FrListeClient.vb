
Imports System.Data.SqlClient
Imports System.Data
Imports System.IO.Directory
Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms


Public Class FrListeClient

#Region "Constructeurs"

#End Region

#Region "Constantes"
    Public Enum TypesEntreprise
        Client
        Fournisseur
    End Enum
#End Region

#Region "Props"
    Public ReadOnly Property CurrentEntRow() As DsAgrifact.EntrepriseRow
        Get
            If Me.EntrepriseBindingSource.Position < 0 Then Return Nothing
            Return Cast(Of DsAgrifact.EntrepriseRow)(Cast(Of DataRowView)(Me.EntrepriseBindingSource.Current).Row)
        End Get
    End Property

    Private _typeEnt As TypesEntreprise = TypesEntreprise.Client
    Public Property TypeEntreprise() As TypesEntreprise
        Get
            Return _typeEnt
        End Get
        Set(ByVal value As TypesEntreprise)
            _typeEnt = value
        End Set
    End Property

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.EntrepriseDataGridView.UseWaitCursor = True
            System.Windows.Forms.Application.DoEvents()

            Dim curId As Decimal = -1
            If Me.EntrepriseBindingSource.Position >= 0 Then
                curId = Me.CurrentEntRow.nEntreprise
            End If

            If Me.TypeEntreprise = TypesEntreprise.Client Then
                Me.EntrepriseTA.FillClient(Me.DsAgrifact.Entreprise)
            Else
                Me.EntrepriseTA.FillFourn(Me.DsAgrifact.Entreprise)
            End If
            Filtrer()

            If curId > -1 Then
                Me.EntrepriseBindingSource.Position = Me.EntrepriseBindingSource.Find("nEntreprise", curId)
            End If
        Finally
            Cursor.Current = Cursors.Default
            Me.EntrepriseDataGridView.UseWaitCursor = False
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.EntrepriseBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Try
                Me.EntrepriseTA.Update(Me.DsAgrifact.Entreprise)
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.EntrepriseBindingSource.EndEdit()
        If Me.DsAgrifact.HasChanges Then
            Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                Case MsgBoxResult.Yes
                    Enregistrer()
                Case MsgBoxResult.No
                Case MsgBoxResult.Cancel
                    Return False
            End Select
        End If
        Return True
    End Function

    Private _customFilter As Boolean
    Private _isFiltering As Boolean
    Private Sub Filtrer()
        If _customFilter Then Exit Sub
        If _isFiltering Then Exit Sub
        Dim filter As String = ""
        If Me.TbFilter.Checked Then
            filter = "Inactif=False"
            If Me.TxRecherche.Text.Trim.Length > 0 Then
                filter &= FormatExpression(" AND (Nom like {0} OR CodePostal like {0} OR Ville like {0})", "%" & Me.TxRecherche.Text.Trim & "%")
            End If
        End If
        _isFiltering = True
        If Me.EntrepriseBindingSource.Filter <> filter Then
            Cursor.Current = Cursors.WaitCursor
            Me.EntrepriseBindingSource.Filter = filter
            Cursor.Current = Cursors.Default
        End If
        _isFiltering = False
    End Sub
#End Region

#Region "Toolbar"
    Private Sub TbFusionner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFusionner.Click
        Me.FusionnerTiers()

        Me.ChargerDonnees()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub EntrepriseBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EntrepriseBindingNavigatorSaveItem.Click
        Enregistrer()
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbNew.Click
        CreateNewEntreprise()
    End Sub

    Private Sub TbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDelete.Click
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub

        Try
            If FrListeClient.CheckForChildObjectsSansPersonne(Me.CurrentEntRow.nEntreprise) Then
                Dim EntrepriseDR As DsAgrifact.EntrepriseRow = CType(CType(Me.EntrepriseBindingSource.Current, DataRowView).Row, DsAgrifact.EntrepriseRow)
                Dim nEntreprise As Decimal = EntrepriseDR.nEntreprise

                Me.EntrepriseBindingSource.RemoveCurrent()

                'Suppression des contacts et de leurs téléphones
                FrListeClient.SupprimerContactsDeEntreprise(nEntreprise)
            End If
        Catch ex As UserCancelledException
        End Try

        MajBoutons()
    End Sub

    Private Sub TbTous_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbFilter.CheckedChanged
        If Not TbFilter.Checked Then _customFilter = False
        Filtrer()
    End Sub

    Private Sub TxRecherche_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxRecherche.Leave
        Filtrer()
    End Sub

    Private Sub TxRecherche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxRecherche.TextChanged
        If Me.DsAgrifact.Entreprise.Count > 3000 Then Exit Sub
        Filtrer()
    End Sub

    Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        ImprimerListeClient()
    End Sub

    Private Sub TbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbSearch.Click
        If Me.EntrepriseBindingSource.Position >= 0 Then
            Me.EntrepriseBindingSource.EndEdit()
        End If

        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(Me.DsAgrifact, "TVA")
            DefinitionDonnees.Instance.Fill(Me.DsAgrifact, "Tarif")
            GestionControles.FillTablesConfig(Me.DsAgrifact, s)
        End Using

        Dim myFrRecherche As New GRC.FrRecherche(Me.DsAgrifact, "Entreprise")

        AddHandler myFrRecherche.AffectuerRecherche, AddressOf LancerLaRecherche
        myFrRecherche.Show(Me)
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String)
        _customFilter = True
        Me.EntrepriseBindingSource.Filter = strCritere
    End Sub
#End Region

#Region "Page"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.EntrepriseDataGridView)
        ConfigColSel(Me.EntrepriseDataGridView, Me.ColSel)
        ChargerDonnees()
        ConfigDataTableEvents(Me.DsAgrifact.Entreprise, Nothing)
        MajBoutons()
    End Sub
#End Region

#Region " Control events "
    Private Sub EntrepriseDataGridView_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EntrepriseDataGridView.KeyDown
        If e.KeyCode = Keys.Enter Then
            OpenCurrentEntreprise()
            e.Handled = True
        End If
    End Sub

    Private Sub EntrepriseDataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles EntrepriseDataGridView.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        OpenCurrentEntreprise()
    End Sub

    Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        Select Case e.CloseReason
            Case CloseReason.None, CloseReason.UserClosing
                If Not Me.IsDisposed Then
                    ChargerDonnees()
                End If
        End Select
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons()
        Me.EntrepriseBindingNavigatorSaveItem.Enabled = Me.DsAgrifact.HasChanges
    End Sub

    Private Sub ImprimerListeClient()
        Dim myDs As DataSet
        myDs = Me.DsAgrifact.Clone
        myDs.EnforceConstraints = False

        Using s As New SqlProxy
            DefinitionDonnees.Instance.Fill(myDs, "TelephoneEntreprise", s)
        End Using

        Dim drs As List(Of DataRow) = GetSelectedRows(Me.EntrepriseDataGridView)
        If drs.Count > 0 Then
            myDs.Merge(drs.ToArray)
        Else
            For Each drv As DataRowView In Me.EntrepriseBindingSource
                myDs.Merge(New DataRow() {drv.Row})
            Next
        End If

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListeClient.rpt")
        If Me.TypeEntreprise = TypesEntreprise.Fournisseur Then
            fr.LibelleSelection = "Liste Fournisseurs"
        Else
            fr.LibelleSelection = "Liste Clients"
        End If
        fr.Show()
    End Sub

    Private Sub CreateNewEntreprise()
        Dim fr As New FrEntreprise()
        fr.TypeEntreprise = Me.TypeEntreprise
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        fr.ShowDialog()
    End Sub

    Private Sub OpenCurrentEntreprise()
        If Me.EntrepriseBindingSource.Position < 0 Then Exit Sub
        Dim fr As New FrEntreprise(CInt(Me.CurrentEntRow.nEntreprise))
        fr.TypeEntreprise = Me.TypeEntreprise
        AddHandler fr.FormClosed, AddressOf ChildForm_Closed
        If Me.MdiParent IsNot Nothing Then
            fr.MdiParent = Me.MdiParent
            Me.WindowState = FormWindowState.Minimized
            'fr.WindowState = FormWindowState.Maximized
        End If
        fr.Show()
    End Sub

    Private Sub FusionnerTiers()
        Dim drs As List(Of DataRow) = GetSelectedRows(Me.EntrepriseDataGridView)

        If (drs.Count <= 1) Then
            MsgBox("Veuillez sélectionner au moins deux tiers.", MsgBoxStyle.Exclamation, "Sélection")

            Exit Sub
        End If

        Dim frFusionnerTiers As New FrFusionnerTiers(drs)

        If (frFusionnerTiers.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            frFusionnerTiers.Close()
        End If
    End Sub
#End Region

#Region "Méthodes partagées"
    Public Shared Function CheckForChildObjects(ByVal nEntreprise As Decimal) As Boolean
        Dim dtChildObjects As DsAgrifact.ChildObjectsDataTable
        Using dta As New DsAgrifactTableAdapters.ChildObjectsTA
            dtChildObjects = dta.GetDataByNEntreprie(nEntreprise)
        End Using
        If dtChildObjects.Count > 0 Then
            Dim msg As New System.Text.StringBuilder("Cette entreprise est liée à :" & vbCrLf)
            For Each dr As DsAgrifact.ChildObjectsRow In dtChildObjects
                msg.AppendFormat("  {0} {1}" & vbCrLf, dr.nb, dr._lib)
            Next
            msg.AppendLine("Ils devront être supprimés avant de pouvoir supprimer l'entreprise.")
            MsgBox(msg.ToString, MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function CheckForChildObjectsSansPersonne(ByVal nEntreprise As Decimal) As Boolean
        Dim dtChildObjects As DsAgrifact.ChildObjectsDataTable
        Using dta As New DsAgrifactTableAdapters.ChildObjectsTA
            dtChildObjects = dta.GetDataBynEntrepriseSansPersonne(nEntreprise)
        End Using
        If dtChildObjects.Count > 0 Then
            Dim msg As New System.Text.StringBuilder("Cette entreprise est liée à :" & vbCrLf)
            For Each dr As DsAgrifact.ChildObjectsRow In dtChildObjects
                msg.AppendFormat("  {0} {1}" & vbCrLf, dr.nb, dr._lib)
            Next
            msg.AppendLine("Ils devront être supprimés avant de pouvoir supprimer l'entreprise.")
            MsgBox(msg.ToString, MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Sub SupprimerContactsDeEntreprise(ByVal nEntreprise As Decimal)
        Try
            Using PersonneTA As New DsAgrifactTableAdapters.PersonneTA
                Using TelephoneTA As New DsAgrifactTableAdapters.TelephoneTA
                    Dim PersonneDT As DsAgrifact.PersonneDataTable = PersonneTA.GetDataBynEntreprise(nEntreprise)

                    For Each PersonneDR As DsAgrifact.PersonneRow In PersonneDT.Rows
                        'Suppression des téléphones liés
                        TelephoneTA.DeleteBynPersonne(PersonneDR.nPersonne)

                        'Suppression des contacts
                        PersonneTA.Delete(PersonneDR.nPersonne)
                    Next
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    Private Sub export_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles export_excel.Click

        'objets de connexion partagés



        Dim connection As New SqlClient.SqlConnection

        'objets Entreprise
        Dim command1 As New SqlClient.SqlCommand
        Dim dataAdapterEntreprise As New SqlClient.SqlDataAdapter()
        Dim dataSetEntreprise As New DataSet
        Dim datatableEntreprise As New System.Data.DataTable()
        
        'objets Telephone
        Dim command2 As New SqlClient.SqlCommand
        Dim dataAdapterTelephone As New SqlClient.SqlDataAdapter()
        Dim dataSetTelephone As New DataSet
        Dim datatableTelephone As New System.Data.DataTable()

        'objets Contact
        Dim command3 As New SqlClient.SqlCommand
        Dim dataAdapterContact As New SqlClient.SqlDataAdapter()
        Dim dataSetContact As New DataSet
        Dim datatableContact As New System.Data.DataTable()

        'Assign your connection string to connection object
        connection.ConnectionString = My.Settings.AgrifactConnString

        command1.Connection = connection
        command1.CommandType = CommandType.Text
        command1.CommandText = "SELECT nEntreprise, CodeClient, Nom, AdresseLiv, CodePostalLiv, VilleLiv, Observations, PaysLiv FROM Entreprise WHERE Client = '1' AND Inactif = 'false' ORDER BY Nom"

        connection.Open()
        dataAdapterEntreprise.SelectCommand = command1
        dataAdapterEntreprise.Fill(datatableEntreprise)
        connection.Close()

        command2.Connection = connection
        command2.CommandType = CommandType.Text
        command2.CommandText = "SELECT nEntreprise, Type, Numero FROM TelephoneEntreprise WHERE Type NOT LIKE '%mail%' AND Type NOT LIKE '%fax%' ORDER BY nEntreprise"

        connection.Open()
        dataAdapterTelephone.SelectCommand = command2
        dataAdapterTelephone.Fill(datatableTelephone)
        connection.Close()

        command3.Connection = connection
        command3.CommandType = CommandType.Text
        command3.CommandText = "SELECT nEntreprise, Nom, Prenom FROM Personne ORDER BY nEntreprise"

        connection.Open()
        dataAdapterContact.SelectCommand = command3
        dataAdapterContact.Fill(datatableContact)
        connection.Close()

        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            ' If f.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

            Dim oExcel As Microsoft.Office.Interop.Excel.Application
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook
            Dim oSheet As Microsoft.Office.Interop.Excel.Worksheet
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add(Type.Missing)
            oSheet = oBook.Worksheets(1)
            oSheet.Columns("D:D").Cells.NumberFormat = "@"


            Dim dr As System.Data.DataRow
            Dim drcontact As System.Data.DataRow
            Dim drtelephone As System.Data.DataRow

            Dim colIndex As Integer = 1
            Dim rowIndex As Integer = 1
            oSheet.Columns("A:Z").AutoFit()
            'Export the Columns to excel file
            oSheet.Cells(1, colIndex) = "CODE"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "SOCIETE"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "ADRESSE LIVRAISON"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "CP LIVRAISON"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "VILLE LIVRAISON"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "NOM CONTACT"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "TEL"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "OBSERVATIONS"
            colIndex = colIndex + 1
            oSheet.Cells(1, colIndex) = "PAYS"
            'Export the rows to excel file

            For Each dr In datatableEntreprise.Rows

                colIndex = 1
                oSheet.Cells(rowIndex + 1, colIndex) = dr("CodeClient")
                colIndex = colIndex + 1
                oSheet.Cells(rowIndex + 1, colIndex) = dr("Nom")
                colIndex = colIndex + 1
                oSheet.Cells(rowIndex + 1, colIndex) = dr("AdresseLiv")
                colIndex = colIndex + 1
                oSheet.Cells(rowIndex + 1, colIndex) = dr("CodePostalLiv")
                colIndex = colIndex + 1
                oSheet.Cells(rowIndex + 1, colIndex) = dr("VilleLiv")

                Dim count As Integer = 0
                'info contact
                For Each drcontact In datatableContact.Rows
                    If drcontact("nEntreprise").ToString().Equals(dr("nEntreprise").ToString()) Then
                        colIndex = colIndex + 1
                        oSheet.Cells(rowIndex + 1, colIndex) = drcontact("Nom") & " " & drcontact("Prenom")
                        Exit For
                    Else
                        count = count + 1
                    End If
                Next
                If count.Equals(datatableContact.Rows.Count) Then
                    colIndex = colIndex + 1

                End If
                'info telephone
                Dim str As String
                colIndex = colIndex + 1
                For Each drtelephone In datatableTelephone.Rows
                    If drtelephone("nEntreprise").ToString().Equals(dr("nEntreprise").ToString()) Then

                        If str <> "" Then

                        End If

                        str = str & (drtelephone("Type").ToString())
                        str = str & " : "


                        str = str & drtelephone("Numero")

                        str = str & " " & Chr(10)
                    End If
                Next
                str = str & " "
                If str.Length >= 3 Then
                    str = str.Substring(0, str.Length - 3)
                End If
                oSheet.Cells(rowIndex + 1, colIndex) = str
                str = ""
                colIndex = colIndex + 1
                oSheet.Cells(rowIndex + 1, colIndex) = dr("Observations")
                colIndex = colIndex + 1
                oSheet.Cells(rowIndex + 1, colIndex) = dr("PaysLiv")
                rowIndex = rowIndex + 1
            Next
            oExcel.Visible = True


            MessageBox.Show("Exportation réussie")


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

End Class


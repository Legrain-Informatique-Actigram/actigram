Imports GRC
Imports ExportCompta

Public Class FrExportComptaFichier
    Inherits FrBase

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByRef momDataset As DataSet)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        ds = momDataset
        Dim myDBnull As DBNull
        id = myDBnull
    End Sub


    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtExporter As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtFinReglement As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtDebutReglement As System.Windows.Forms.DateTimePicker
    Friend WithEvents CkFactures As System.Windows.Forms.CheckBox
    Friend WithEvents GbFactures As System.Windows.Forms.GroupBox
    Friend WithEvents GbReglements As System.Windows.Forms.GroupBox
    Friend WithEvents CkReglements As System.Windows.Forms.CheckBox
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents TbParametres As System.Windows.Forms.ToolBarButton
    Friend WithEvents TbFermer As System.Windows.Forms.ToolBarButton
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents BtValiderParam As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TbAnnulerExport As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrExportComptaFichier))
        Me.Label1 = New System.Windows.Forms.Label
        Me.DtDebut = New System.Windows.Forms.DateTimePicker
        Me.BtExporter = New System.Windows.Forms.Button
        Me.GbFactures = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DtFin = New System.Windows.Forms.DateTimePicker
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.GbReglements = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtFinReglement = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtDebutReglement = New System.Windows.Forms.DateTimePicker
        Me.CkFactures = New System.Windows.Forms.CheckBox
        Me.CkReglements = New System.Windows.Forms.CheckBox
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.TbParametres = New System.Windows.Forms.ToolBarButton
        Me.TbAnnulerExport = New System.Windows.Forms.ToolBarButton
        Me.TbFermer = New System.Windows.Forms.ToolBarButton
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.BtValiderParam = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.GbFactures.SuspendLayout()
        Me.GbReglements.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList24
        '
        Me.ImageList24.ImageStream = CType(resources.GetObject("ImageList24.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'ImageList16
        '
        Me.ImageList16.ImageStream = CType(resources.GetObject("ImageList16.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'ImageList32
        '
        Me.ImageList32.ImageStream = CType(resources.GetObject("ImageList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date Début"
        '
        'DtDebut
        '
        Me.DtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DtDebut.Location = New System.Drawing.Point(80, 24)
        Me.DtDebut.Name = "DtDebut"
        Me.DtDebut.Size = New System.Drawing.Size(176, 20)
        Me.DtDebut.TabIndex = 1
        '
        'BtExporter
        '
        Me.BtExporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtExporter.Location = New System.Drawing.Point(200, 264)
        Me.BtExporter.Name = "BtExporter"
        Me.BtExporter.TabIndex = 2
        Me.BtExporter.Text = "Exporter"
        '
        'GbFactures
        '
        Me.GbFactures.Controls.Add(Me.Label2)
        Me.GbFactures.Controls.Add(Me.DtFin)
        Me.GbFactures.Controls.Add(Me.Label1)
        Me.GbFactures.Controls.Add(Me.DtDebut)
        Me.GbFactures.Location = New System.Drawing.Point(8, 72)
        Me.GbFactures.Name = "GbFactures"
        Me.GbFactures.Size = New System.Drawing.Size(264, 80)
        Me.GbFactures.TabIndex = 3
        Me.GbFactures.TabStop = False
        Me.GbFactures.Text = "Factures"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date Fin"
        '
        'DtFin
        '
        Me.DtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DtFin.Location = New System.Drawing.Point(80, 48)
        Me.DtFin.Name = "DtFin"
        Me.DtFin.Size = New System.Drawing.Size(176, 20)
        Me.DtFin.TabIndex = 3
        '
        'BtAnnuler
        '
        Me.BtAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAnnuler.Location = New System.Drawing.Point(120, 264)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.TabIndex = 4
        Me.BtAnnuler.Text = "Annuler"
        '
        'GbReglements
        '
        Me.GbReglements.Controls.Add(Me.Label3)
        Me.GbReglements.Controls.Add(Me.dtFinReglement)
        Me.GbReglements.Controls.Add(Me.Label4)
        Me.GbReglements.Controls.Add(Me.dtDebutReglement)
        Me.GbReglements.Location = New System.Drawing.Point(8, 176)
        Me.GbReglements.Name = "GbReglements"
        Me.GbReglements.Size = New System.Drawing.Size(264, 80)
        Me.GbReglements.TabIndex = 5
        Me.GbReglements.TabStop = False
        Me.GbReglements.Text = "Règlements"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Date Fin"
        '
        'dtFinReglement
        '
        Me.dtFinReglement.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtFinReglement.Location = New System.Drawing.Point(80, 48)
        Me.dtFinReglement.Name = "dtFinReglement"
        Me.dtFinReglement.Size = New System.Drawing.Size(176, 20)
        Me.dtFinReglement.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Date Début"
        '
        'dtDebutReglement
        '
        Me.dtDebutReglement.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtDebutReglement.Location = New System.Drawing.Point(80, 24)
        Me.dtDebutReglement.Name = "dtDebutReglement"
        Me.dtDebutReglement.Size = New System.Drawing.Size(176, 20)
        Me.dtDebutReglement.TabIndex = 1
        '
        'CkFactures
        '
        Me.CkFactures.Checked = True
        Me.CkFactures.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkFactures.Location = New System.Drawing.Point(8, 48)
        Me.CkFactures.Name = "CkFactures"
        Me.CkFactures.Size = New System.Drawing.Size(176, 24)
        Me.CkFactures.TabIndex = 6
        Me.CkFactures.Text = "Exporter les Factures"
        '
        'CkReglements
        '
        Me.CkReglements.Checked = True
        Me.CkReglements.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkReglements.Location = New System.Drawing.Point(8, 152)
        Me.CkReglements.Name = "CkReglements"
        Me.CkReglements.Size = New System.Drawing.Size(176, 24)
        Me.CkReglements.TabIndex = 7
        Me.CkReglements.Text = "Exporter les Règlements"
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.TbParametres, Me.TbAnnulerExport, Me.TbFermer})
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList24
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(280, 50)
        Me.ToolBar1.TabIndex = 8
        '
        'TbParametres
        '
        Me.TbParametres.ImageIndex = 11
        Me.TbParametres.Text = "Paramètres"
        '
        'TbAnnulerExport
        '
        Me.TbAnnulerExport.ImageIndex = 11
        Me.TbAnnulerExport.Text = "Annuler Export"
        Me.TbAnnulerExport.Visible = False
        '
        'TbFermer
        '
        Me.TbFermer.ImageIndex = 5
        Me.TbFermer.Text = "Fermer"
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 48)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(264, 208)
        Me.DataGrid1.TabIndex = 9
        Me.DataGrid1.Visible = False
        '
        'BtValiderParam
        '
        Me.BtValiderParam.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtValiderParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtValiderParam.Location = New System.Drawing.Point(8, 264)
        Me.BtValiderParam.Name = "BtValiderParam"
        Me.BtValiderParam.TabIndex = 10
        Me.BtValiderParam.Text = "Valider"
        Me.BtValiderParam.Visible = False
        '
        'FrExportCompta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 294)
        Me.Controls.Add(Me.BtValiderParam)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.CkReglements)
        Me.Controls.Add(Me.CkFactures)
        Me.Controls.Add(Me.GbReglements)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.GbFactures)
        Me.Controls.Add(Me.BtExporter)
        Me.Name = "FrExportCompta"
        Me.Text = "Export Compta"
        Me.GbFactures.ResumeLayout(False)
        Me.GbReglements.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub

    Private Function Export(Optional ByVal Verification As Boolean = False) As Boolean

        FrDonnees.UpdateSQLServer(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Insert)

        'If System.IO.File.Exists(Application.StartupPath & "\XmlEnCode.xml") = True Then
        '    'System.IO.File.Copy(Application.StartupPath & "\XmlEnCode.xml", Application.StartupPath & "\BksS" & Date.Now.ToString("MMddhhmmss") & "XmlEnCode.xml", True)
        '    System.IO.File.Copy(Application.StartupPath & "\XmlEnCode.xml", Application.StartupPath & "\BksSXmlEnCode.xml", True)
        'End If

        'If System.IO.File.Exists(Application.StartupPath & "\XmlEnCodeSchema.xml") = True Then
        '    'System.IO.File.Copy(Application.StartupPath & "\XmlEnCodeSchema.xml", Application.StartupPath & "\BksS" & Date.Now.ToString("MMddhhmmss") & "XmlEnCodeSchema.xml", True)
        '    System.IO.File.Copy(Application.StartupPath & "\XmlEnCodeSchema.xml", Application.StartupPath & "\BksSXmlEnCodeSchema.xml", True)
        'End If

        Dim LstExport As New CollectionLigneExportAgrigest
        'Dim DsParam As New DataSet
        'If System.IO.File.Exists(Application.StartupPath & "\ParamExportCompta.xml") Then
        '    DsParam.ReadXml(Application.StartupPath & "\ParamExportCompta.xml")
        'Else
        '    MessageBox.Show("Vous devez saisir les paramètres d'export...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return False
        '    Exit Function
        'End If

        Dim dtExport As Date = Now

        'FrBonCommande.VerifChampsBase(ds)

        '* Facture De Ventes

        If Me.CkFactures.Checked = True Then
            If ds.Tables("VFacture").Columns.Contains("DateExportCompta") = False Then
                ds.Tables("VFacture").Columns.Add("DateExportCompta", GetType(Date))
            End If

            Dim RwToExport() As DataRow = ds.Tables("VFacture").Select("DateFacture Not Is Null And (ExportCompta<>True Or ExportCompta Is Null) And DateFacture>=#" & Me.DtDebut.Value.ToString("MM/dd/yy") & "# And DateFacture<=#" & Me.DtFin.Value.ToString("MM/dd/yy") & "#", "nFacture")
            Dim rw As DataRow
            For Each rw In RwToExport
                If Verification = False Then
                    rw.Item("ExportCompta") = True
                    rw.Item("DateExportCompta") = dtExport
                End If
                Dim RwChildToExport() As DataRow = rw.GetChildRows("VFactureVFacture_Detail")
                Dim RwChild As DataRow
                For Each RwChild In RwChildToExport
                    If Not RwChild.Item("MontantLigneHT") Is DBNull.Value And Not RwChild.Item("MontantLigneTVA") Is DBNull.Value Then
                        Dim Ligne As New LigneExportAgrigest
                        Ligne.NumeroPiece = Convert.ToString(rw.Item("nFacture"))
                        Ligne.DatePiece = Convert.ToDateTime(rw.Item("DateFacture"))
                        Dim CptProduit As String = ""
                        If Not RwChild.Item("CodeProduit") Is DBNull.Value Then
                            Dim lstCptProd() As DataRow = rw.Table.DataSet.Tables("Produit").Select("CodeProduit='" & Convert.ToString(RwChild.Item("CodeProduit")).Replace("'", "''") & "'")
                            If lstCptProd.GetUpperBound(0) >= 0 Then
                                If RwChild.Table.DataSet.Tables("Produit").Columns.Contains("NCompteV") Then
                                    Ligne.CptProduit = Convert.ToString(lstCptProd(0).Item("NCompteV"))
                                End If
                                Ligne.LibProduit = Convert.ToString(RwChild.Item("Libelle")).Replace(Chr(13), "").Replace(Chr(10), "")
                                If RwChild.Table.DataSet.Tables("Produit").Columns.Contains("NActiviteV") Then
                                    Ligne.ActProduit = Convert.ToString(lstCptProd(0).Item("NActiviteV"))
                                End If
                            End If
                        End If
                        If Not rw.Item("nClient") Is DBNull.Value Then
                            Dim rwParent As DataRow = rw.GetParentRow("ClientVFacture")
                            If Not rwParent Is DBNull.Value Then
                                If Not rwParent.Item("NCompteC") Is DBNull.Value Then
                                    Ligne.CptTiers = Convert.ToString(rwParent.Item("NCompteC"))
                                    Ligne.NomTiers = Convert.ToString(rwParent.Item("Nom")).Replace(Chr(13), "").Replace(Chr(10), "")
                                End If
                            End If
                        End If
                        Ligne.CodeTva = Convert.ToString(RwChild.Item("TTVA"))

                        Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs((Convert.ToDecimal(RwChild.Item("MontantLigneHT")) + Convert.ToDecimal(RwChild.Item("MontantLigneTVA"))) * 100)))
                        Ligne.MontantTVA = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("MontantLigneTVA")) * 100)))
                        If Convert.ToDecimal(RwChild.Item("MontantLigneHT")) < 0 Then
                            Ligne.Avoir = "A"
                        Else
                            Ligne.Avoir = " "
                        End If
                        LstExport.Add(Ligne)
                    End If
                Next
            Next
        End If

        'Dim dtDebutAchat As Date = Me.DtDebut.Value
        'Dim dtFinAchat As Date = Me.DtFin.Value

        ''* Gestion des achats
        'If Me.CkFactures.Checked = True Then
        '    If ds.Tables("AFacture").Columns.Contains("DateExportCompta") = False Then
        '        ds.Tables("AFacture").Columns.Add("DateExportCompta", GetType(Date))
        '    End If

        '    Dim RwToExport() As DataRow = ds.Tables("AFacture").Select("DateFacture Not Is Null And (ExportCompta<>True Or ExportCompta Is Null) And DateFacture>=#" & dtDebutAchat.ToString("MM/dd/yy") & "# And DateFacture<=#" & dtFinAchat.ToString("MM/dd/yy") & "#", "nFacture")
        '    Dim rw As DataRow
        '    For Each rw In RwToExport
        '        If Verification = False Then
        '            rw.Item("ExportCompta") = True
        '            rw.Item("DateExportCompta") = dtExport
        '        End If
        '        Dim RwChildToExport() As DataRow = rw.GetChildRows("AFactureAFacture_Detail")
        '        Dim RwChild As DataRow
        '        For Each RwChild In RwChildToExport
        '            If Not RwChild.Item("MontantLigneHT") Is DBNull.Value And Not RwChild.Item("MontantLigneTVA") Is DBNull.Value Then

        '                Dim Ligne As New LigneExportAgrigest
        '                Ligne.NumeroPiece = Convert.ToString(rw.Item("nFacture"))
        '                Ligne.DatePiece = Convert.ToDateTime(rw.Item("DateFacture"))
        '                Dim CptProduit As String = ""
        '                If Not rwChild.Item("CodeProduit") Is DBNull.Value Then
        '                    Dim lstCptProd() As DataRow = rw.Table.DataSet.Tables("Produit").Select("CodeProduit='" & Convert.ToString(rwChild.Item("CodeProduit")) & "'")
        '                    If lstCptProd.GetUpperBound(0) >= 0 Then
        '                        If rwChild.Table.DataSet.Tables("Produit").Columns.Contains("NCompteA") Then
        '                            ligne.CptProduit = Convert.ToString(lstCptProd(0).Item("NCompteA"))
        '                        End If
        '                        ligne.LibProduit = Convert.ToString(rwChild.Item("Libelle"))
        '                        If rwChild.Table.DataSet.Tables("Produit").Columns.Contains("NActiviteA") Then
        '                            ligne.ActProduit = Convert.ToString(lstCptProd(0).Item("NActiviteA"))
        '                        End If
        '                    End If
        '                End If
        '                If Not rw.Item("nClient") Is DBNull.Value Then
        '                    Dim rwParent As DataRow = rw.GetParentRow("ClientAFacture")
        '                    If Not rwParent Is DBNull.Value Then
        '                        If Not rwParent.Item("NCompteF") Is DBNull.Value Then
        '                            ligne.CptTiers = Convert.ToString(rwParent.Item("NCompteF"))
        '                            ligne.NomTiers = Convert.ToString(rwParent.Item("Nom"))
        '                        End If
        '                    End If
        '                End If
        '                If Convert.ToString(rwchild.Item("TTVA")) <> "" Then
        '                    If ligne.CptProduit.StartsWith("2") Then
        '                        ligne.CodeTva = "02"
        '                    Else
        '                        ligne.CodeTva = "01"
        '                    End If
        '                Else
        '                    ligne.CodeTva = "03"
        '                End If
        '                'Ligne.CodeTva = Convert.ToString(rwChild.Item("TTVA"))

        '                Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs((Convert.ToDecimal(RwChild.Item("MontantLigneHT")) + Convert.ToDecimal(RwChild.Item("MontantLigneTVA"))) * 100)))
        '                Ligne.MontantTVA = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("MontantLigneTVA")) * 100)))
        '                If Convert.ToDecimal(RwChild.Item("MontantLigneHT")) < 0 Then
        '                    Ligne.Avoir = "A"
        '                Else
        '                    Ligne.Avoir = " "
        '                End If

        '                LstExport.Add(Ligne)

        '            End If

        '        Next

        '    Next

        'End If

        '* Reglements Clients

        If Me.CkReglements.Checked = True Then
            If ds.Tables("Remise").Columns.Contains("NExportRemise") = False Then
                ds.Tables("Remise").Columns.Add("NExportRemise", GetType(Integer))
            End If
            If ds.Tables("Remise").Columns.Contains("ExportCompta") = False Then
                ds.Tables("Remise").Columns.Add("ExportCompta", GetType(Boolean))
            End If
            If ds.Tables("Remise").Columns.Contains("DateExportCompta") = False Then
                ds.Tables("Remise").Columns.Add("DateExportCompta", GetType(Date))
            End If

            'Dim dr As New DataRelation("Remise_DetailReglement", ds.Tables("Remise_Detail").Columns("nReglement"), ds.Tables("Reglement").Columns("nReglement"), False)
            'ds.Relations.Add(dr)
            Dim nRemiseMax As Integer
            If Not ds.Tables("Remise").Compute("Count(nRemise)", "NExportRemise Is Null") Is DBNull.Value Then
                nRemiseMax = Convert.ToInt32(ds.Tables("Remise").Compute("Count(nRemise)", "NExportRemise Is Null"))
            Else
                nRemiseMax = 1
            End If

            Dim RwRemise() As DataRow
            'RwRemise = ds.Tables("Remise").Select("ExportCompta<>True And DateReglement>=#" & Me.dtDebutReglement.Value.ToString("MM/dd/yy") & "# And DateReglement<=#" & Me.dtFinReglement.Value.ToString("MM/dd/yy") & "#", "DateReglement")
            RwRemise = ds.Tables("Remise").Select("(ExportCompta<>True Or ExportCompta Is Null) And Montant<>0 And DateRemise>=#" & Me.dtDebutReglement.Value.ToString("MM/dd/yy") & "# And DateRemise<=#" & Me.dtFinReglement.Value.ToString("MM/dd/yy") & "#", "DateRemise")
            Dim RwRem As DataRow
            For Each RwRem In RwRemise
                RwRem.Item("NExportRemise") = nRemiseMax
                nRemiseMax += 1
                If Verification = False Then
                    RwRem.Item("ExportCompta") = True
                    RwRem.Item("DateExportCompta") = dtExport
                End If
                Dim LstRegl() As DataRow = RwRem.GetChildRows("RemiseRemise_Detail")
                Dim RwR As DataRow
                For Each RwR In LstRegl
                    Dim RwToExport() As DataRow = ds.Tables("Reglement").Select("nReglement=" & Convert.ToString(RwR.Item("nReglement")))
                    Dim rw As DataRow
                    For Each rw In RwToExport
                        If Not rw.Item("Montant") Is DBNull.Value Then
                            Dim RwChildToExport() As DataRow = rw.GetChildRows("ReglementReglement_Detail")
                            Dim RwChild As DataRow

                            For Each RwChild In RwChildToExport
                                Dim Ligne As New LigneExportAgrigest
                                Ligne.NumeroPiece = "RE " & Convert.ToString(RwRem.Item("TypeRemise")).ToUpper
                                Ligne.DatePiece = Convert.ToDateTime(RwRem.Item("DateRemise"))
                                Dim RwFacture() As DataRow
                                RwFacture = ds.Tables("VFacture").Select("nDevis=" & Convert.ToString(RwChild.Item("nFacture")))
                                If RwFacture.GetUpperBound(0) >= 0 Then
                                    Dim rwBanque() As DataRow = ds.Tables("Banque").Select("nBanque=" & Convert.ToString(RwRem.Item("nBanque")))
                                    If rwBanque.GetUpperBound(0) >= 0 Then
                                        If Convert.ToString(rwBanque(0).Item("NCompte")) <> "" Then
                                            Ligne.CptTiers = Convert.ToString(rwBanque(0).Item("NCompte"))
                                        Else
                                            MessageBox.Show("NReglement : " & Convert.ToString(rw.Item("nReglement")) & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateReglement")).ToString("dd/MM/yy") & vbCrLf & "Le Compte Banque n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            Return False
                                            Exit Function
                                        End If
                                    End If

                                    '* Compte Produit => Compte Client
                                    Dim rwClient As DataRow = RwFacture(0).GetParentRow("ClientVFacture")
                                    If Not rwClient Is Nothing Then
                                        If rwClient.Table.Columns.Contains("NCompteC") Then
                                            Ligne.CptProduit = Convert.ToString(rwClient.Item("NCompteC"))
                                            Ligne.LibProduit = Convert.ToString(rwClient.Item("Nom"))
                                        End If
                                    End If

                                    Dim strF As String = ""
                                    If Convert.ToString(RwChild.GetParentRow("VFactureReglement_Detail").Item("nFacture")) <> "" Then
                                        strF += "F:" & Convert.ToString(RwChild.GetParentRow("VFactureReglement_Detail").Item("nFacture"))
                                    End If
                                    If Convert.ToString(RwChild.GetParentRow("VFactureReglement_Detail").Item("Observation")) <> "" Then
                                        If strF.Length > 0 Then
                                            strF += " "
                                        End If
                                        strF += Convert.ToString(RwChild.GetParentRow("VFactureReglement_Detail").Item("Observation"))
                                    End If
                                    If Convert.ToString(rw.Item("nCheque")) <> "" Then
                                        If strF.Length > 0 Then
                                            strF += " "
                                        End If
                                        strF += "CH:" & Convert.ToString(rw.Item("nCheque"))
                                    End If

                                    Ligne.NomTiers = strF
                                    'Ligne.LibProduit = Convert.ToString(RwFacture(0).Item("Secteur")) & " " & Convert.ToDateTime(RwFacture(0).Item("DateFacture")).Year
                                    Ligne.ActProduit = "0000"

                                    Ligne.Quantite1 = Convert.ToString(Convert.ToInt32(RwRem.Item("NExportRemise")) + 5000)

                                    Ligne.CodeTva = ""

                                    Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("Montant")) * 100)))
                                    Ligne.MontantTVA = "       "
                                    Ligne.Avoir = " "

                                    LstExport.Add(Ligne)

                                    If Not RwChild.Item("Perte") Is DBNull.Value Or Not RwChild.Item("Profit") Is DBNull.Value Then
                                        Ligne = New LigneExportAgrigest
                                        Ligne.NumeroPiece = "RE " & Convert.ToString(RwRem.Item("TypeRemise")).ToUpper
                                        Ligne.DatePiece = Convert.ToDateTime(RwRem.Item("DateRemise"))
                                        Dim strCompte As String = ""
                                        If Not RwChild.Item("Perte") Is DBNull.Value Then
                                            strCompte = "CptPerte"
                                            Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("Perte")) * 100)))
                                        End If
                                        If Not RwChild.Item("Profit") Is DBNull.Value Then
                                            strCompte = "CptProfit"
                                            Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("Profit")) * 100)))
                                        End If
                                        Select Case strCompte
                                            Case "CptPerte"
                                                Ligne.CptTiers = "65800000"
                                                Dim rwClient1 As DataRow = RwFacture(0).GetParentRow("ClientVFacture")
                                                If Not rwClient1 Is Nothing Then
                                                    If rwClient1.Table.Columns.Contains("NCompteC") Then
                                                        Ligne.CptProduit = Convert.ToString(rwClient1.Item("NCompteC"))
                                                        Ligne.LibProduit = Convert.ToString(rwClient1.Item("Nom"))
                                                    End If
                                                End If
                                            Case "CptProfit"
                                                Ligne.CptProduit = "75800000"
                                                Dim rwClient1 As DataRow = RwFacture(0).GetParentRow("ClientVFacture")
                                                If Not rwClient1 Is Nothing Then
                                                    If rwClient1.Table.Columns.Contains("NCompteC") Then
                                                        Ligne.CptProduit = Convert.ToString(rwClient1.Item("NCompteC"))
                                                        Ligne.LibProduit = Convert.ToString(rwClient1.Item("Nom"))
                                                    End If
                                                End If
                                        End Select
                                        Ligne.NomTiers = "P&P&"
                                        Ligne.ActProduit = "0000"

                                        Ligne.Quantite1 = Convert.ToString(Convert.ToInt32(RwRem.Item("NExportRemise")) + 5000)

                                        Ligne.CodeTva = ""

                                        Ligne.MontantTVA = "       "
                                        Ligne.Avoir = " "

                                        LstExport.Add(Ligne)

                                    End If
                                End If
                            Next
                        End If
                    Next
                Next
            Next
        End If

        ''* Reglements Fournisseurs

        'Dim dtDebutReglementAchat As Date = Me.dtDebutReglement.Value
        'Dim dtFinReglementAchat As Date = Me.dtFinReglement.Value

        'If Me.CkReglements.Checked = True Then
        '    Dim RwToExport() As DataRow = ds.Tables("AReglement").Select("(ExportCompta<>True Or ExportCompta Is Null) And Montant<>0 And DateReglement>=#" & dtDebutReglementAchat.ToString("MM/dd/yy") & "# And DateReglement<=#" & dtFinReglementAchat.ToString("MM/dd/yy") & "#", "DateReglement")
        '    Dim rw As DataRow
        '    For Each rw In RwToExport
        '        If Not Rw.Item("Montant") Is DBNull.Value Then
        '            Dim RwChildToExport() As DataRow = rw.GetChildRows("AReglementAReglement_Detail")
        '            Dim RwChild As DataRow

        '            If Verification = False Then
        '                rw.Item("ExportCompta") = True
        '                rw.Item("DateExportCompta") = dtExport
        '            End If

        '            For Each rwchild In rwchildtoexport
        '                Dim Ligne As New LigneExportAgrigest
        '                Ligne.NumeroPiece = "RE " & Convert.ToString(Rw.Item("nMode")).ToUpper
        '                Ligne.DatePiece = Convert.ToDateTime(Rw.Item("DateReglement"))
        '                Dim RwFacture() As DataRow
        '                RwFacture = ds.Tables("AFacture").Select("nDevis=" & Convert.ToString(rwchild.Item("nFacture")))
        '                If RwFacture.GetUpperBound(0) >= 0 Then
        '                    Dim rwBanque() As DataRow = ds.Tables("Banque").Select("nBanque=" & Convert.ToString(Rw.Item("nBanque")))
        '                    If rwBanque.GetUpperBound(0) >= 0 Then
        '                        If Convert.ToString(rwBanque(0).Item("NCompte")) <> "" Then
        '                            ligne.CptTiers = Convert.ToString(rwBanque(0).Item("NCompte"))
        '                        Else
        '                            MessageBox.Show("NReglement : " & Convert.ToString(rw.Item("nReglement")) & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateReglement")).ToString("dd/MM/yy") & vbCrLf & "Le Compte Banque n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            Return False
        '                            Exit Function
        '                        End If
        '                    End If
        '                    '* Compte Produit => Compte Client
        '                    Dim rwClient As DataRow = RwFacture(0).GetParentRow("ClientAFacture")
        '                    If Not rwClient Is Nothing Then
        '                        If rwClient.Table.Columns.Contains("NCompteF") Then
        '                            ligne.CptProduit = Convert.ToString(rwClient.Item("NCompteF"))
        '                            ligne.LibProduit = Convert.ToString(rwClient.Item("Nom"))
        '                        End If
        '                    End If

        '                    Dim strF As String = ""
        '                    If Convert.ToString(rwchild.GetParentRow("AFactureAReglement_Detail").Item("nFacture")) <> "" Then
        '                        strF += "F:" & Convert.ToString(rwchild.GetParentRow("AFactureAReglement_Detail").Item("nFacture"))
        '                    End If
        '                    If Convert.ToString(rwchild.GetParentRow("AFactureAReglement_Detail").Item("Observation")) <> "" Then
        '                        If strF.Length > 0 Then
        '                            strF += " "
        '                        End If
        '                        strF += Convert.ToString(rwchild.GetParentRow("AFactureAReglement_Detail").Item("Observation"))
        '                    End If
        '                    If Convert.ToString(rw.Item("nCheque")) <> "" Then
        '                        If strF.Length > 0 Then
        '                            strF += " "
        '                        End If
        '                        strF += "CH:" & Convert.ToString(rw.Item("nCheque"))
        '                    End If

        '                    Ligne.NomTiers = strF
        '                    'Ligne.LibProduit = Convert.ToString(RwFacture(0).Item("Secteur")) & " " & Convert.ToDateTime(RwFacture(0).Item("DateFacture")).Year
        '                    Ligne.ActProduit = "0000"

        '                    'ligne.Quantite1 = Convert.ToString(Convert.ToInt32(Rw.Item("NExportRemise")) + 5000)
        '                    ligne.Quantite1 = "9999"

        '                    Ligne.CodeTva = ""

        '                    Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("Montant")) * 100)))
        '                    Ligne.MontantTVA = "       "
        '                    Ligne.Avoir = " "

        '                    LstExport.Add(Ligne)

        '                    If Not RwChild.Item("Perte") Is DBNull.Value Or Not RwChild.Item("Profit") Is DBNull.Value Then
        '                        Ligne = New LigneExportAgrigest
        '                        Ligne.NumeroPiece = "RE " & Convert.ToString(Rw.Item("nMode")).ToUpper
        '                        Ligne.DatePiece = Convert.ToDateTime(Rw.Item("DateReglement"))
        '                        Dim strCompte As String = ""
        '                        If Not RwChild.Item("Perte") Is DBNull.Value Then
        '                            strCompte = "CptPerte"
        '                            Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("Perte")) * 100)))
        '                        End If
        '                        If Not RwChild.Item("Profit") Is DBNull.Value Then
        '                            strCompte = "CptProfit"
        '                            Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("Profit")) * 100)))
        '                        End If
        '                        Select Case strCompte
        '                            Case "CptPerte"
        '                                Ligne.CptTiers = "65800000"
        '                                Dim rwClient1 As DataRow = RwFacture(0).GetParentRow("EntrepriseAFacture")
        '                                If Not rwClient1 Is Nothing Then
        '                                    If rwClient1.Table.Columns.Contains("NCompteF") Then
        '                                        ligne.CptProduit = Convert.ToString(rwClient1.Item("NCompteF"))
        '                                        ligne.LibProduit = Convert.ToString(rwClient1.Item("Nom"))
        '                                    End If
        '                                End If
        '                            Case "CptProfit"
        '                                Ligne.CptProduit = "75800000"
        '                                Dim rwClient1 As DataRow = RwFacture(0).GetParentRow("EntrepriseAFacture")
        '                                If Not rwClient1 Is Nothing Then
        '                                    If rwClient1.Table.Columns.Contains("NCompteF") Then
        '                                        ligne.CptProduit = Convert.ToString(rwClient1.Item("NCompteF"))
        '                                        ligne.LibProduit = Convert.ToString(rwClient1.Item("Nom"))
        '                                    End If
        '                                End If
        '                        End Select
        '                        ligne.NomTiers = "P&P&"
        '                        ligne.ActProduit = "0000"

        '                        ligne.Quantite1 = Convert.ToString(Convert.ToInt32(Rw.Item("NExportRemise")) + 5000)

        '                        Ligne.CodeTva = ""

        '                        Ligne.MontantTVA = "       "
        '                        Ligne.Avoir = " "

        '                        LstExport.Add(Ligne)

        '                    End If
        '                End If
        '            Next
        '        End If
        '    Next
        '    'Next
        '    'Next
        'End If


        If Verification = False Then
            Me.SaveFileDialog1.FileName = "ExportBo"
            If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then
                LstExport.ExportVersFichier(Me.SaveFileDialog1.FileName)
                LstExport.ExportVersFichier(String.Format("{0}\{1}\{2}{3:yyMMddhhmmss}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName, "SAVExportBo", Now))
                MessageBox.Show("Export Compta terminé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                FrDonnees.UpdateSQLServer(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Insert)

            End If
        End If

        Return True
    End Function


    Private Sub BtExporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExporter.Click
        If Export(True) = True Then
            Export(False)
        End If
        'Dim LstExport As New CollectionLigneExportAgrigest
        'Dim DsParam As New DataSet
        'If System.IO.File.Exists(Application.StartupPath & "\ParamExportCompta.xml") Then
        '    DsParam.ReadXml(Application.StartupPath & "\ParamExportCompta.xml")
        'Else
        '    MessageBox.Show("Vous devez saisir les paramètres d'export...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If

        'If Me.CkFactures.Checked = True Then
        '    Dim RwToExport() As DataRow = ds.Tables("Devis").Select("DateFacture Not Is Null And ExportCompta<>True And DateFacture>=#" & Me.DtDebut.Value.ToString("MM/dd/yy") & "# And DateFacture<=#" & Me.DtFin.Value.ToString("MM/dd/yy") & "#", "nFacture")
        '    Dim rw As DataRow
        '    For Each rw In RwToExport
        '        Dim RwChildToExport() As DataRow = rw.GetChildRows("DevisDetailDevis")
        '        Dim RwChild As DataRow
        '        For Each RwChild In RwChildToExport
        '            If Not RwChild.Item("MontantLigneHT") Is DBNull.Value And Not RwChild.Item("MontantLigneTVA") Is DBNull.Value Then

        '                Dim Ligne As New LigneExportAgrigest
        '                Ligne.NumeroPiece = Convert.ToString(rw.Item("nFacture"))
        '                Ligne.DatePiece = Convert.ToDateTime(rw.Item("DateFacture"))
        '                If DsParam.Tables("ParamExportCompta").Select("Type='Service' And Libelle='" & Convert.ToString(rw.Item("Secteur")) & "'").GetUpperBound(0) >= 0 Then
        '                    Ligne.CptTiers = Convert.ToString(DsParam.Tables("ParamExportCompta").Select("Type='Service' And Libelle='" & Convert.ToString(rw.Item("Secteur")) & "'")(0).Item("CptClient"))
        '                    Ligne.CptProduit = Convert.ToString(DsParam.Tables("ParamExportCompta").Select("Type='Service' And Libelle='" & Convert.ToString(rw.Item("Secteur")) & "'")(0).Item("CptProduit"))
        '                Else
        '                    MessageBox.Show("NFacture : " & Convert.ToString(rw.Item("nFacture")) & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateFacture")).ToString("dd/MM/yy") & vbCrLf & "Le Compte Client n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    Exit Sub
        '                End If

        '                'Select Case Convert.ToString(rw.Item("Secteur"))
        '                '    Case "Annonces Légales"
        '                '        'Ligne.CptTiers = "411" & Ligne.DatePiece.Year & "2"
        '                '        'Ligne.CptProduit = "700" & Ligne.DatePiece.Year & "2"
        '                '    Case "Publicités"
        '                '        Ligne.CptTiers = "411" & Ligne.DatePiece.Year & "1"
        '                '        Ligne.CptProduit = "700" & Ligne.DatePiece.Year & "1"
        '                '    Case "Petites Annonces"
        '                '        Ligne.CptTiers = "411" & Ligne.DatePiece.Year & "3"
        '                '        Ligne.CptProduit = "700" & Ligne.DatePiece.Year & "3"
        '                '    Case Else
        '                '        MessageBox.Show("NFacture : " & Convert.ToString("nFacture") & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateFacture")).ToString("dd/MM/yy") & vbCrLf & "Le Compte Client n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                '        Exit Sub
        '                'End Select

        '                Ligne.NomTiers = Convert.ToString(rw.Item("Secteur"))
        '                Ligne.LibProduit = Convert.ToString(rw.Item("Secteur"))
        '                Ligne.ActProduit = "0000"

        '                If DsParam.Tables("ParamExportCompta").Select("Type='TVA' And Libelle='" & Convert.ToDecimal(RwChild.Item("TxTVA")).ToString("#.#") & "'").GetUpperBound(0) >= 0 Then
        '                    Ligne.codetva = Convert.ToString(DsParam.Tables("ParamExportCompta").Select("Type='TVA' And Libelle='" & Convert.ToDecimal(RwChild.Item("TxTVA")).ToString("#.#") & "'")(0).Item("CptTVA"))
        '                Else
        '                    MessageBox.Show("NFacture : " & Convert.ToString(rw.Item("nFacture")) & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateFacture")).ToString("dd/MM/yy") & vbCrLf & "Le Compte TVA n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    Exit Sub
        '                End If

        '                'Select Case Convert.ToDouble(RwChild.Item("TxTVA"))
        '                '    Case 19.6
        '                '        Ligne.CodeTva = "19.6"
        '                '    Case Else
        '                '        MessageBox.Show("NFacture : " & Convert.ToString("nFacture") & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateFacture")).ToString("dd/MM/yy") & vbCrLf & "Le Compte TVA n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                '        Exit Sub
        '                'End Select

        '                Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs((Convert.ToDecimal(RwChild.Item("MontantLigneHT")) + Convert.ToDecimal(RwChild.Item("MontantLigneTVA"))) * 100)))
        '                Ligne.MontantTVA = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("MontantLigneTVA")) * 100)))
        '                If Convert.ToDecimal(RwChild.Item("MontantLigneHT")) < 0 Then
        '                    Ligne.Avoir = "A"
        '                Else
        '                    Ligne.Avoir = " "
        '                End If

        '                LstExport.Add(Ligne)

        '            End If


        '        Next

        '    Next
        'End If
        'If Me.CkReglements.Checked = True Then
        '    If ds.Tables("Remise").Columns.Contains("NExportRemise") = False Then
        '        ds.Tables("Remise").Columns.Add("NExportRemise", GetType(Integer))
        '    End If

        '    'Dim dr As New DataRelation("Remise_DetailReglement", ds.Tables("Remise_Detail").Columns("nReglement"), ds.Tables("Reglement").Columns("nReglement"), False)
        '    'ds.Relations.Add(dr)
        '    Dim nRemiseMax As Integer
        '    If Not ds.Tables("Remise").Compute("Count(nRemise)", "NExportRemise Is Null") Is DBNull.Value Then
        '        nRemiseMax = Convert.ToInt32(ds.Tables("Remise").Compute("Count(nRemise)", "NExportRemise Is Null"))
        '    Else
        '        nRemiseMax = 1
        '    End If

        '    Dim RwRemise() As DataRow
        '    'RwRemise = ds.Tables("Remise").Select("ExportCompta<>True And DateReglement>=#" & Me.dtDebutReglement.Value.ToString("MM/dd/yy") & "# And DateReglement<=#" & Me.dtFinReglement.Value.ToString("MM/dd/yy") & "#", "DateReglement")
        '    RwRemise = ds.Tables("Remise").Select("DateRemise>=#" & Me.dtDebutReglement.Value.ToString("MM/dd/yy") & "# And DateRemise<=#" & Me.dtFinReglement.Value.ToString("MM/dd/yy") & "#", "DateRemise")
        '    Dim RwRem As DataRow
        '    For Each RwRem In RwRemise
        '        RwRem.Item("NExportRemise") = nRemiseMax
        '        nRemiseMax += 1
        '        Dim LstRegl() As DataRow = RwRem.GetChildRows("RemiseRemise_Detail")
        '        Dim RwR As DataRow
        '        For Each RwR In LstRegl
        '            Dim RwToExport() As DataRow = ds.Tables("Reglement").Select("nReglement=" & Convert.ToString(RwR.Item("nReglement")))
        '            'Dim RwToExport() As DataRow = ds.Tables("Reglement").Select("ExportCompta<>True And DateReglement>=#" & Me.dtDebutReglement.Value.ToString("MM/dd/yy") & "# And DateReglement<=#" & Me.dtFinReglement.Value.ToString("MM/dd/yy") & "#", "DateReglement")
        '            Dim rw As DataRow
        '            For Each rw In RwToExport
        '                'Dim RwChildToExport() As DataRow = rw.GetChildRows("DevisDetailDevis")
        '                'Dim RwChild As DataRow
        '                'For Each RwChild In RwChildToExport
        '                If Not Rw.Item("Montant") Is DBNull.Value Then
        '                    Dim RwChildToExport() As DataRow = rw.GetChildRows("ReglementReglement_Detail")
        '                    Dim RwChild As DataRow

        '                    For Each rwchild In rwchildtoexport
        '                        Dim Ligne As New LigneExportAgrigest
        '                        Ligne.NumeroPiece = "RE " & Convert.ToString(rw.Item("nMode")).ToUpper
        '                        'Ligne.NumeroPiece = Convert.ToString(rw.Item("nFacture"))
        '                        Dim RwFacture() As DataRow
        '                        RwFacture = ds.Tables("Devis").Select("nDevis=" & Convert.ToString(rwchild.Item("nFacture")))
        '                        If RwFacture.GetUpperBound(0) >= 0 Then
        '                            Ligne.DatePiece = Convert.ToDateTime(rw.Item("DateReglement"))

        '                            If DsParam.Tables("ParamExportCompta").Select("Type='ModeReglement' And Libelle='" & Convert.ToString(rw.Item("nMode")) & "'").GetUpperBound(0) >= 0 Then
        '                                Ligne.CptTiers = Convert.ToString(DsParam.Tables("ParamExportCompta").Select("Type='ModeReglement' And Libelle='" & Convert.ToString(rw.Item("nMode")) & "'")(0).Item("CptBanque"))
        '                            Else
        '                                MessageBox.Show("NFacture : " & Convert.ToString(rw.Item("nFacture")) & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateFacture")).ToString("dd/MM/yy") & vbCrLf & "Le Compte Banque n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                                Exit Sub
        '                            End If

        '                            'Select Case Convert.ToString(rw.Item("nMode"))
        '                            '    Case "Traite"
        '                            '        ligne.CptTiers = "5113"
        '                            '    Case "Chèque"
        '                            '        ligne.CptTiers = "5112"
        '                            '    Case "Virement"
        '                            '        ligne.CptTiers = "58"
        '                            'End Select

        '                            If DsParam.Tables("ParamExportCompta").Select("Type='Service' And Libelle='" & Convert.ToString(RwFacture(0).Item("Secteur")) & "'").GetUpperBound(0) >= 0 Then
        '                                Ligne.CptTiers = Convert.ToString(DsParam.Tables("ParamExportCompta").Select("Type='Service' And Libelle='" & Convert.ToString(RwFacture(0).Item("Secteur")) & "'")(0).Item("CptClient"))
        '                            Else
        '                                MessageBox.Show("NFacture : " & Convert.ToString(rw.Item("nFacture")) & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateFacture")).ToString("dd/MM/yy") & vbCrLf & "Le Compte Client n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                                Exit Sub
        '                            End If

        '                            'Select Case Convert.ToString(RwFacture(0).Item("Secteur"))
        '                            '    Case "Annonces Légales"
        '                            '        Ligne.CptProduit = "411" & Ligne.DatePiece.Year & "2"
        '                            '        'Ligne.CptProduit = "700" & Ligne.DatePiece.Year & "2"
        '                            '    Case "Publicités"
        '                            '        Ligne.CptProduit = "411" & Ligne.DatePiece.Year & "1"
        '                            '        'Ligne.CptProduit = "700" & Ligne.DatePiece.Year & "1"
        '                            '    Case "Petites Annonces"
        '                            '        Ligne.CptProduit = "411" & Ligne.DatePiece.Year & "3"
        '                            '        'Ligne.CptProduit = "700" & Ligne.DatePiece.Year & "3"
        '                            '    Case Else
        '                            '        MessageBox.Show("NFacture : " & Convert.ToString("nFacture") & vbCrLf & "Date : " & Convert.ToDateTime(rw.Item("DateFacture")).ToString("dd/MM/yy") & vbCrLf & "Le Compte Client n'a pas été reconnu...", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            '        Exit Sub
        '                            'End Select

        '                            Ligne.NomTiers = Convert.ToString(Rw.Item("nCheque"))
        '                            Ligne.LibProduit = Convert.ToString(RwFacture(0).Item("Secteur")) & " " & Convert.ToDateTime(RwFacture(0).Item("DateFacture")).Year
        '                            Ligne.ActProduit = "0000"

        '                            ligne.Quantite1 = Convert.ToString(Convert.ToInt32(RwRem.Item("NExportRemise")) + 5000)

        '                            Ligne.CodeTva = ""

        '                            Ligne.MontantHT = Convert.ToString(Math.Round(Math.Abs(Convert.ToDecimal(RwChild.Item("Montant")) * 100)))
        '                            Ligne.MontantTVA = "       "
        '                            Ligne.Avoir = " "

        '                            LstExport.Add(Ligne)
        '                        End If
        '                    Next
        '                End If
        '            Next
        '        Next
        '    Next

        'End If

        'LstExport.ExportVersFichier(Application.StartupPath & "\ExportBo")

        'MessageBox.Show("Export Compta terminé", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FrDonnees.UpdateSQLServer(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Insert)

    End Sub

    Private Sub FrExportCompta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DtDebut.Value = Convert.ToDateTime("01/01/" & Now.Year.ToString)
        Me.DtFin.Value = Now.AddDays(-Now.Day)
        Me.dtDebutReglement.Value = Convert.ToDateTime("01/01/" & Now.Year.ToString)
        Me.dtFinReglement.Value = Now.AddDays(-Now.Day)
    End Sub

    Private Sub CkFactures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkFactures.CheckedChanged
        Me.GbFactures.Enabled = CkFactures.Checked
    End Sub

    Private Sub CkReglements_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CkReglements.CheckedChanged
        Me.GbReglements.Enabled = CkReglements.Checked
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        If e.Button Is Me.TbFermer Then
            Me.Close()
        End If
        If e.Button Is Me.TbParametres Then
            Dim ds As New DataSet
            If System.IO.File.Exists(Application.StartupPath & "\ParamExportCompta.xml") = False Then
                Dim Tb As New DataTable("ParamExportCompta")
                Tb.Columns.Add("Type", GetType(String))
                Tb.Columns.Add("Libelle", GetType(String))
                Tb.Columns.Add("CptClient", GetType(String))
                Tb.Columns.Add("CptProduit", GetType(String))
                Tb.Columns.Add("CptBanque", GetType(String))
                Tb.Columns.Add("CptTVA", GetType(String))
                Tb.Columns.Add("CptProfit", GetType(String))
                Tb.Columns.Add("CptPerte", GetType(String))

                Dim RwN As DataRow
                RwN = Tb.NewRow
                RwN.Item("Type") = "Service"
                RwN.Item("Libelle") = "Publicités"
                RwN.Item("CptClient") = "41120051"
                RwN.Item("CptProduit") = "70612000"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "Service"
                RwN.Item("Libelle") = "Petites Annonces"
                RwN.Item("CptClient") = "41120053"
                RwN.Item("CptProduit") = "70614000"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "Service"
                RwN.Item("Libelle") = "Annonces Légales"
                RwN.Item("CptClient") = "41120052"
                RwN.Item("CptProduit") = "70615000"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "Service"
                RwN.Item("Libelle") = "Publicités National"
                RwN.Item("CptClient") = "41101000"
                RwN.Item("CptProduit") = "70611000"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "ModeReglement"
                RwN.Item("Libelle") = "Chèque"
                RwN.Item("CptBanque") = "51120000"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "ModeReglement"
                RwN.Item("Libelle") = "Traite"
                RwN.Item("CptBanque") = "51130000"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "ModeReglement"
                RwN.Item("Libelle") = "Virement"
                RwN.Item("CptBanque") = "58000000"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "TVA"
                RwN.Item("Libelle") = "19" & System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator & "6"
                RwN.Item("CptTVA") = "19.6"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "TVA"
                RwN.Item("Libelle") = "2" & System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator & "1"
                RwN.Item("CptTVA") = "2.1"
                Tb.Rows.Add(RwN)

                RwN = Tb.NewRow
                RwN.Item("Type") = "PerteProfit"
                RwN.Item("Libelle") = "Perte et Profit"
                RwN.Item("CptPerte") = "65800000"
                RwN.Item("CptProfit") = "75800000"
                Tb.Rows.Add(RwN)

                ds.Tables.Add(Tb)

                ds.WriteXml(Application.StartupPath & "\ParamExportCompta.xml")

            End If
            ds.ReadXml(Application.StartupPath & "\ParamExportCompta.xml")

            Me.DataGrid1.DataSource = ds
            Me.DataGrid1.DataMember = "ParamExportCompta"

            Me.DataGrid1.Visible = True
            Me.BtValiderParam.Visible = True
            Me.BtAnnuler.Visible = False
            Me.BtExporter.Visible = False
            Me.TbAnnulerExport.Visible = True

        End If
        If e.Button Is Me.TbAnnulerExport Then
            Dim result As Object
            Dim dtExportCompta As Date
            result = ds.Tables("Devis").Compute("Max(DateExportCompta)", "")
            If Not result Is DBNull.Value Then
                dtExportCompta = Convert.ToDateTime(result)
            End If
            result = ds.Tables("Remise").Compute("Max(DateExportCompta)", "")
            If Not result Is DBNull.Value Then
                If Convert.ToDateTime(result).Ticks > dtExportCompta.Ticks Then
                    dtExportCompta = Convert.ToDateTime(result)
                End If
            End If

            If MessageBox.Show("Vous allez annuler l'export compta du " & dtExportCompta.ToString("dddd dd MMMM yyyy à hh:mm:ss"), "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Dim rwTmp As DataRow
                Dim rwsTmp() As DataRow

                rwsTmp = ds.Tables("Devis").Select("DateExportCompta>=#" & dtExportCompta.ToString("MM/dd/yy hh:mm:ss") & "#", "", DataViewRowState.CurrentRows)

                For Each rwTmp In rwsTmp
                    If Convert.ToDateTime(rwTmp.Item("DateExportCompta")).Ticks = dtExportCompta.Ticks Then
                        rwTmp.Item("ExportCompta") = False
                        rwTmp.Item("DateExportCompta") = DBNull.Value
                    End If
                Next

                rwsTmp = ds.Tables("Remise").Select("DateExportCompta>=#" & dtExportCompta.ToString("MM/dd/yy hh:mm:ss") & "#", "", DataViewRowState.CurrentRows)
                For Each rwTmp In rwsTmp
                    If Convert.ToDateTime(rwTmp.Item("DateExportCompta")).Ticks = dtExportCompta.Ticks Then
                        rwTmp.Item("ExportCompta") = False
                        rwTmp.Item("DateExportCompta") = DBNull.Value
                    End If
                Next


                FrDonnees.UpdateSQLServer(Actigram.Donnees.ConfigurationSqlServer.MethodeUpdate.Insert)

                MessageBox.Show("Opération Terminée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Opération Annulée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.DataGrid1.Visible = False
            Me.TbAnnulerExport.Visible = False
            Me.BtValiderParam.Visible = False
            Me.BtAnnuler.Visible = True
            Me.BtExporter.Visible = True
        End If
    End Sub

    Private Sub BtValiderParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValiderParam.Click
        CType(Me.DataGrid1.DataSource, DataSet).WriteXml(Application.StartupPath & "\ParamExportCompta.xml")
        Me.DataGrid1.Visible = False
        Me.TbAnnulerExport.Visible = False
        Me.BtValiderParam.Visible = False
        Me.BtAnnuler.Visible = True
        Me.BtExporter.Visible = True
    End Sub
End Class

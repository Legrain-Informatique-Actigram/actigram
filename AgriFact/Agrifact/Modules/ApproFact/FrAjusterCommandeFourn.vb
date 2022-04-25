Public Class FrAjusterCommandeFourn
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

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
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents ColTxtCodeProduit As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtLib As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtU1 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtLibU1 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtU2 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtLibU2 As ReadOnlyTextBoxColumn
    Friend WithEvents dgProduits As System.Windows.Forms.DataGrid
    Friend WithEvents ColTxtNom As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtNBC As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtDateBC As ReadOnlyTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbUnite1 As System.Windows.Forms.Label
    Friend WithEvents lbFournisseur As System.Windows.Forms.Label
    Friend WithEvents lbProduit As System.Windows.Forms.Label
    Friend WithEvents ColTxtAFU1 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtAFLibU1 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtAFU2 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtAFLibU2 As ReadOnlyTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.dgProduits = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.ColTxtNom = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtNBC = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtDateBC = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtCodeProduit = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtLib = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtU1 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtLibU1 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtU2 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtLibU2 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtAFU1 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtAFLibU1 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtAFU2 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtAFLibU2 = New AgriFact.ReadOnlyTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbProduit = New System.Windows.Forms.Label
        Me.lbFournisseur = New System.Windows.Forms.Label
        Me.lbUnite1 = New System.Windows.Forms.Label
        CType(Me.dgProduits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(408, 344)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.TabIndex = 0
        Me.BtOK.Text = "OK"
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(488, 344)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.TabIndex = 1
        Me.BtCancel.Text = "Annuler"
        '
        'dgProduits
        '
        Me.dgProduits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProduits.CaptionVisible = False
        Me.dgProduits.DataMember = ""
        Me.dgProduits.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgProduits.Location = New System.Drawing.Point(8, 160)
        Me.dgProduits.Name = "dgProduits"
        Me.dgProduits.RowHeadersVisible = False
        Me.dgProduits.Size = New System.Drawing.Size(560, 176)
        Me.dgProduits.TabIndex = 2
        Me.dgProduits.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgProduits
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.ColTxtNom, Me.ColTxtNBC, Me.ColTxtDateBC, Me.ColTxtCodeProduit, Me.ColTxtLib, Me.ColTxtU1, Me.ColTxtLibU1, Me.ColTxtU2, Me.ColTxtLibU2, Me.ColTxtAFU1, Me.ColTxtAFLibU1, Me.ColTxtAFU2, Me.ColTxtAFLibU2})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "RecapCommande"
        Me.DataGridTableStyle1.RowHeadersVisible = False
        '
        'ColTxtNom
        '
        Me.ColTxtNom.Column = 0
        Me.ColTxtNom.Format = ""
        Me.ColTxtNom.FormatInfo = Nothing
        Me.ColTxtNom.HeaderText = "Client"
        Me.ColTxtNom.MappingName = "Nom"
        Me.ColTxtNom.NullText = ""
        Me.ColTxtNom.ReadOnly = True
        Me.ColTxtNom.Width = 150
        '
        'ColTxtNBC
        '
        Me.ColTxtNBC.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColTxtNBC.Column = 0
        Me.ColTxtNBC.Format = ""
        Me.ColTxtNBC.FormatInfo = Nothing
        Me.ColTxtNBC.HeaderText = "N° BC"
        Me.ColTxtNBC.MappingName = "nfacture"
        Me.ColTxtNBC.NullText = ""
        Me.ColTxtNBC.ReadOnly = True
        Me.ColTxtNBC.Width = 60
        '
        'ColTxtDateBC
        '
        Me.ColTxtDateBC.Column = 0
        Me.ColTxtDateBC.Format = "dd/MM/yy"
        Me.ColTxtDateBC.FormatInfo = Nothing
        Me.ColTxtDateBC.HeaderText = "Date"
        Me.ColTxtDateBC.MappingName = "datefacture"
        Me.ColTxtDateBC.NullText = ""
        Me.ColTxtDateBC.ReadOnly = True
        Me.ColTxtDateBC.Width = 60
        '
        'ColTxtCodeProduit
        '
        Me.ColTxtCodeProduit.Column = 0
        Me.ColTxtCodeProduit.Format = ""
        Me.ColTxtCodeProduit.FormatInfo = Nothing
        Me.ColTxtCodeProduit.HeaderText = "Code"
        Me.ColTxtCodeProduit.MappingName = "CodeProduit"
        Me.ColTxtCodeProduit.NullText = ""
        Me.ColTxtCodeProduit.ReadOnly = True
        Me.ColTxtCodeProduit.Width = 75
        '
        'ColTxtLib
        '
        Me.ColTxtLib.Column = 0
        Me.ColTxtLib.Format = ""
        Me.ColTxtLib.FormatInfo = Nothing
        Me.ColTxtLib.HeaderText = "Produit"
        Me.ColTxtLib.MappingName = "Libelle"
        Me.ColTxtLib.NullText = ""
        Me.ColTxtLib.ReadOnly = True
        Me.ColTxtLib.Width = 150
        '
        'ColTxtU1
        '
        Me.ColTxtU1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColTxtU1.Column = 0
        Me.ColTxtU1.Format = "N3"
        Me.ColTxtU1.FormatInfo = Nothing
        Me.ColTxtU1.HeaderText = "BC - Qté 1 "
        Me.ColTxtU1.MappingName = "BC_Unite1"
        Me.ColTxtU1.NullText = ""
        Me.ColTxtU1.Width = 75
        '
        'ColTxtLibU1
        '
        Me.ColTxtLibU1.Column = 0
        Me.ColTxtLibU1.Format = ""
        Me.ColTxtLibU1.FormatInfo = Nothing
        Me.ColTxtLibU1.MappingName = "BC_LibUnite1"
        Me.ColTxtLibU1.NullText = ""
        Me.ColTxtLibU1.ReadOnly = True
        Me.ColTxtLibU1.Width = 30
        '
        'ColTxtU2
        '
        Me.ColTxtU2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColTxtU2.Column = 0
        Me.ColTxtU2.Format = "N3"
        Me.ColTxtU2.FormatInfo = Nothing
        Me.ColTxtU2.HeaderText = "BC - Qté 2"
        Me.ColTxtU2.MappingName = "BC_Unite2"
        Me.ColTxtU2.NullText = ""
        Me.ColTxtU2.Width = 75
        '
        'ColTxtLibU2
        '
        Me.ColTxtLibU2.Column = 0
        Me.ColTxtLibU2.Format = ""
        Me.ColTxtLibU2.FormatInfo = Nothing
        Me.ColTxtLibU2.MappingName = "BC_LibUnite2"
        Me.ColTxtLibU2.NullText = ""
        Me.ColTxtLibU2.ReadOnly = True
        Me.ColTxtLibU2.Width = 30
        '
        'ColTxtAFU1
        '
        Me.ColTxtAFU1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColTxtAFU1.Column = 0
        Me.ColTxtAFU1.Format = "N3"
        Me.ColTxtAFU1.FormatInfo = Nothing
        Me.ColTxtAFU1.HeaderText = "Fact - Qté 1"
        Me.ColTxtAFU1.MappingName = "AF_Unite1"
        Me.ColTxtAFU1.NullText = ""
        Me.ColTxtAFU1.Width = 75
        '
        'ColTxtAFLibU1
        '
        Me.ColTxtAFLibU1.Column = 0
        Me.ColTxtAFLibU1.Format = ""
        Me.ColTxtAFLibU1.FormatInfo = Nothing
        Me.ColTxtAFLibU1.MappingName = "AF_LibUnite1"
        Me.ColTxtAFLibU1.NullText = ""
        Me.ColTxtAFLibU1.ReadOnly = True
        Me.ColTxtAFLibU1.Width = 30
        '
        'ColTxtAFU2
        '
        Me.ColTxtAFU2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColTxtAFU2.Column = 0
        Me.ColTxtAFU2.Format = "N3"
        Me.ColTxtAFU2.FormatInfo = Nothing
        Me.ColTxtAFU2.HeaderText = "Fact - Qté 2"
        Me.ColTxtAFU2.MappingName = "AF_Unite2"
        Me.ColTxtAFU2.NullText = ""
        Me.ColTxtAFU2.Width = 75
        '
        'ColTxtAFLibU2
        '
        Me.ColTxtAFLibU2.Column = 0
        Me.ColTxtAFLibU2.Format = ""
        Me.ColTxtAFLibU2.FormatInfo = Nothing
        Me.ColTxtAFLibU2.MappingName = "AF_LibUnite2"
        Me.ColTxtAFLibU2.NullText = ""
        Me.ColTxtAFLibU2.ReadOnly = True
        Me.ColTxtAFLibU2.Width = 30
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Produits et quantités affectées aux clients :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(560, 30)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "La quantité de produit commandée au fournisseur ne correspond pas à la quantité c" & _
        "ommandée par les clients. Veuillez adapter la quantité affectée à chaque client." & _
        ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fournisseur : "
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(392, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Quantité (U1) :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Produit :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbProduit)
        Me.GroupBox1.Controls.Add(Me.lbFournisseur)
        Me.GroupBox1.Controls.Add(Me.lbUnite1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 72)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Commande fournisseur"
        '
        'lbProduit
        '
        Me.lbProduit.AutoSize = True
        Me.lbProduit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbProduit.Location = New System.Drawing.Point(88, 48)
        Me.lbProduit.Name = "lbProduit"
        Me.lbProduit.Size = New System.Drawing.Size(118, 16)
        Me.lbProduit.TabIndex = 11
        Me.lbProduit.Text = "Code Produit - Libelle"
        '
        'lbFournisseur
        '
        Me.lbFournisseur.AutoSize = True
        Me.lbFournisseur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFournisseur.Location = New System.Drawing.Point(88, 24)
        Me.lbFournisseur.Name = "lbFournisseur"
        Me.lbFournisseur.Size = New System.Drawing.Size(66, 16)
        Me.lbFournisseur.TabIndex = 10
        Me.lbFournisseur.Text = "Fournisseur"
        '
        'lbUnite1
        '
        Me.lbUnite1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbUnite1.AutoSize = True
        Me.lbUnite1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUnite1.Location = New System.Drawing.Point(472, 48)
        Me.lbUnite1.Name = "lbUnite1"
        Me.lbUnite1.Size = New System.Drawing.Size(75, 16)
        Me.lbUnite1.TabIndex = 9
        Me.lbUnite1.Text = "00 000.00 XX"
        Me.lbUnite1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'FrAjusterCommandeFourn
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(576, 374)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgProduits)
        Me.Controls.Add(Me.BtCancel)
        Me.Controls.Add(Me.BtOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrAjusterCommandeFourn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ajuster une commande fournisseur"
        CType(Me.dgProduits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ds As DataSet
    Private dsLocal As DataSet
    Public AF_nDevisDetail As Integer
    Private drAFD As DataRow

    Private Sub ChargerDonnees()
        dsLocal = New DataSet
        Dim sql As String = "select e.Nom, BC.nfacture, BC.datefacture, " & _
                            "appro.BCD_nDevisDetail,BCD.CodeProduit,BCD.Libelle, appro.BC_Unite1,BCD.LibUnite1 as BC_LibUnite1, appro.BC_Unite2,BCD.LibUnite2 as BC_LibUnite2, " & _
                            "appro.AF_Unite1,AFD.LibUnite1 as AF_LibUnite1, appro.AF_Unite2,AFD.LibUnite2 as AF_LibUnite2 " & _
                            "from Appro_BCD_AFD appro " & _
                            "inner join AFacture_Detail AFD ON appro.AFD_nDevisDetail = AFD.nDetailDevis " & _
                            "inner join VBonCommande_Detail BCD ON appro.BCD_nDevisDetail = BCD.nDetailDevis " & _
                            "inner join VBonCommande BC on BCD.nDevis=BC.nDevis " & _
                            "inner join Entreprise e on BC.nClient=e.nEntreprise " & _
                            "WHERE AFD.nDetailDevis=" & Me.AF_nDevisDetail

        'Charger la liste des produits en cours de commande
        Using s As New SqlProxy
            s.Fill(dsLocal, sql, "RecapCommande")
        End Using
    End Sub

    Private Sub Databinding()
        'Afficher les infos du nDevisDetail
        drAFD = SelectSingleRow(ds.Tables("AFacture_Detail"), "nDetailDevis=" & Me.AF_nDevisDetail, "")
        If drAFD Is Nothing Then Exit Sub
        Dim drFourn As DataRow = drAFD.GetParentRow("AFactureAFacture_Detail").GetParentRow("ClientAFacture")
        Me.lbFournisseur.Text = Convert.ToString(drFourn("Nom"))
        Me.lbProduit.Text = String.Format("{0} - {1}", drAFD("CodeProduit"), drAFD("Libelle"))
        Me.lbUnite1.Text = String.Format("{0:N3} {1}", drAFD("Unite1"), drAFD("LibUnite1"))

        With dsLocal.Tables("RecapCommande").DefaultView
            .AllowNew = False
            .AllowDelete = False
        End With
        dgProduits.DataSource = dsLocal.Tables("RecapCommande")
    End Sub

    Private Sub FrCreerCommandeFourn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChargerDonnees()
        Me.Show()
        Databinding()
        If dsLocal.Tables("RecapCommande").Rows.Count = 0 Then
            MsgBox("Aucune commande client n'est associée à cette commande fournisseur.", MsgBoxStyle.Information)
            Me.BtOK.Enabled = False
        End If
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Me.BindingContext(dsLocal, "RecapCommande").EndCurrentEdit()
        Dim prod_fact As String = Convert.ToString(Me.drAFD("CodeProduit"))
        Dim lib_fact As String = Convert.ToString(Me.drAFD("Libelle"))
        Dim qte1_fact As Decimal = CDec(Me.drAFD("Unite1"))
        Dim u1_fact As String = Convert.ToString(Me.drAFD("LibUnite1"))

        Dim o As Object = Me.dsLocal.Tables("RecapCommande").Compute("Sum(AF_Unite1)", "")
        If IsDBNull(o) Then Exit Sub
        If CDec(o) <> qte1_fact Then
            'Le compte n'y est pas
            MsgBox("La quantité affectée aux clients ne correspond toujours pas à la quantité commandée au fournisseur.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        For Each dr As DataRow In Me.dsLocal.Tables("RecapCommande").Rows
            'Vérifier la cohérence des codes produit et des unités
            'Si pas cohérence, demander confirmation
            If Convert.ToString(dr("CodeProduit")) <> prod_fact Then
                'Incohérence code produit
                Dim msg As String = String.Format("Le code produit est différent pour le client {6}, confirmez-vous que {0}{1} de {2} équivalent à {3}{4} de {5} ?", _
                                                dr("BC_Unite1"), dr("BC_LibUnite1"), dr("Libelle"), dr("AF_Unite1"), dr("AF_LibUnite1"), lib_fact, dr("Nom"))
                If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            ElseIf Convert.ToString(dr("BC_LibUnite1")) <> u1_fact Then
                'Incohérence unité
                Dim msg As String = String.Format("L'unité de produit est différente pour le client {4}, confirmez-vous que {0}{1} de produit équivalent à {2}{3} ?", _
                                                dr("BC_Unite1"), dr("BC_LibUnite1"), dr("AF_Unite1"), dr("AF_LibUnite1"), dr("Nom"))
                If MsgBox(msg, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            ElseIf CDec(dr("BC_Unite1")) <> CDec(dr("AF_Unite1")) Then
                Dim msg As String = String.Format("Les quantités commandées et facturées pour le client {0} ne correspondent pas.", dr("Nom"))
                MsgBox(msg, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            'Si on a tout confirmé, on mets à jour la table Appro_BCD_AFD
            Dim drAppro As DataRow = SelectSingleRow(ds.Tables("Appro_BCD_AFD"), String.Format("AFD_nDevisDetail={0} AND BCD_nDevisDetail={1}", Me.AF_nDevisDetail, dr("BCD_nDevisDetail")), "")
            If Not drAppro Is Nothing Then
                drAppro.BeginEdit()
                drAppro("BC_Unite1") = dr("BC_Unite1")
                drAppro("BC_Unite2") = dr("BC_Unite2")
                drAppro("AF_Unite1") = dr("AF_Unite1")
                drAppro("AF_Unite2") = dr("AF_Unite2")
                drAppro.EndEdit()
            End If
        Next

        'MAJ de la base
        Using s As New SqlProxy
            s.UpdateTable(ds, "Appro_BCD_AFD")
        End Using
        Me.DialogResult = DialogResult.OK
    End Sub

End Class

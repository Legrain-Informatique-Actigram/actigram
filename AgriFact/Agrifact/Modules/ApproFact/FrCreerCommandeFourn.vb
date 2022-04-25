Public Class FrCreerCommandeFourn
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
    Friend WithEvents ChkSel As System.Windows.Forms.DataGridBoolColumn
    Friend WithEvents ColTxtCodeProduit As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtLib As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtU1 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtLibU1 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtU2 As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtLibU2 As ReadOnlyTextBoxColumn
    Friend WithEvents BtFindFourn As System.Windows.Forms.Button
    Friend WithEvents dgProduits As System.Windows.Forms.DataGrid
    Friend WithEvents CbFourn As System.Windows.Forms.ComboBox
    Friend WithEvents ColTxtNom As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtNBC As ReadOnlyTextBoxColumn
    Friend WithEvents ColTxtDateBC As ReadOnlyTextBoxColumn
    Friend WithEvents BtImprimer As System.Windows.Forms.Button
    Friend WithEvents BtSelectAll As System.Windows.Forms.Button
    Friend WithEvents BtDeselectAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrCreerCommandeFourn))
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.dgProduits = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.ChkSel = New System.Windows.Forms.DataGridBoolColumn
        Me.ColTxtNom = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtNBC = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtDateBC = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtCodeProduit = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtLib = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtU1 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtLibU1 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtU2 = New AgriFact.ReadOnlyTextBoxColumn
        Me.ColTxtLibU2 = New AgriFact.ReadOnlyTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtFindFourn = New System.Windows.Forms.Button
        Me.CbFourn = New System.Windows.Forms.ComboBox
        Me.BtImprimer = New System.Windows.Forms.Button
        Me.BtSelectAll = New System.Windows.Forms.Button
        Me.BtDeselectAll = New System.Windows.Forms.Button
        CType(Me.dgProduits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(480, 296)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.TabIndex = 0
        Me.BtOK.Text = "OK"
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(560, 296)
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
        Me.dgProduits.Location = New System.Drawing.Point(8, 56)
        Me.dgProduits.Name = "dgProduits"
        Me.dgProduits.RowHeadersVisible = False
        Me.dgProduits.Size = New System.Drawing.Size(632, 232)
        Me.dgProduits.TabIndex = 2
        Me.dgProduits.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.dgProduits
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.ChkSel, Me.ColTxtNom, Me.ColTxtNBC, Me.ColTxtDateBC, Me.ColTxtCodeProduit, Me.ColTxtLib, Me.ColTxtU1, Me.ColTxtLibU1, Me.ColTxtU2, Me.ColTxtLibU2})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ProdsEnCommande"
        Me.DataGridTableStyle1.RowHeadersVisible = False
        '
        'ChkSel
        '
        Me.ChkSel.FalseValue = False
        Me.ChkSel.MappingName = "Sel"
        Me.ChkSel.NullText = ""
        Me.ChkSel.NullValue = CType(resources.GetObject("ChkSel.NullValue"), Object)
        Me.ChkSel.TrueValue = True
        Me.ChkSel.Width = 20
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
        Me.ColTxtU1.HeaderText = "Quantité 1"
        Me.ColTxtU1.MappingName = "Unite1"
        Me.ColTxtU1.NullText = ""
        Me.ColTxtU1.Width = 75
        '
        'ColTxtLibU1
        '
        Me.ColTxtLibU1.Column = 0
        Me.ColTxtLibU1.Format = ""
        Me.ColTxtLibU1.FormatInfo = Nothing
        Me.ColTxtLibU1.MappingName = "LibUnite1"
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
        Me.ColTxtU2.HeaderText = "Quantité 2"
        Me.ColTxtU2.MappingName = "Unite2"
        Me.ColTxtU2.NullText = ""
        Me.ColTxtU2.Width = 75
        '
        'ColTxtLibU2
        '
        Me.ColTxtLibU2.Column = 0
        Me.ColTxtLibU2.Format = ""
        Me.ColTxtLibU2.FormatInfo = Nothing
        Me.ColTxtLibU2.MappingName = "LibUnite2"
        Me.ColTxtLibU2.NullText = ""
        Me.ColTxtLibU2.ReadOnly = True
        Me.ColTxtLibU2.Width = 30
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Produits et quantités à commander :"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fournisseur :"
        '
        'BtFindFourn
        '
        Me.BtFindFourn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtFindFourn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtFindFourn.Image = CType(resources.GetObject("BtFindFourn.Image"), System.Drawing.Image)
        Me.BtFindFourn.Location = New System.Drawing.Point(616, 8)
        Me.BtFindFourn.Name = "BtFindFourn"
        Me.BtFindFourn.Size = New System.Drawing.Size(24, 21)
        Me.BtFindFourn.TabIndex = 6
        Me.BtFindFourn.Visible = False
        '
        'CbFourn
        '
        Me.CbFourn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbFourn.Location = New System.Drawing.Point(80, 8)
        Me.CbFourn.Name = "CbFourn"
        Me.CbFourn.Size = New System.Drawing.Size(528, 21)
        Me.CbFourn.TabIndex = 8
        '
        'BtImprimer
        '
        Me.BtImprimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtImprimer.Location = New System.Drawing.Point(400, 296)
        Me.BtImprimer.Name = "BtImprimer"
        Me.BtImprimer.TabIndex = 9
        Me.BtImprimer.Text = "Imprimer..."
        '
        'BtSelectAll
        '
        Me.BtSelectAll.Location = New System.Drawing.Point(8, 296)
        Me.BtSelectAll.Name = "BtSelectAll"
        Me.BtSelectAll.Size = New System.Drawing.Size(104, 23)
        Me.BtSelectAll.TabIndex = 10
        Me.BtSelectAll.Text = "Tout sélectionner"
        '
        'BtDeselectAll
        '
        Me.BtDeselectAll.Location = New System.Drawing.Point(120, 296)
        Me.BtDeselectAll.Name = "BtDeselectAll"
        Me.BtDeselectAll.Size = New System.Drawing.Size(112, 23)
        Me.BtDeselectAll.TabIndex = 11
        Me.BtDeselectAll.Text = "Tout déselectionner"
        '
        'FrCreerCommandeFourn
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(648, 326)
        Me.Controls.Add(Me.BtDeselectAll)
        Me.Controls.Add(Me.BtSelectAll)
        Me.Controls.Add(Me.BtImprimer)
        Me.Controls.Add(Me.CbFourn)
        Me.Controls.Add(Me.BtFindFourn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgProduits)
        Me.Controls.Add(Me.BtCancel)
        Me.Controls.Add(Me.BtOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrCreerCommandeFourn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Composer une commande fournisseur"
        CType(Me.dgProduits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private ds As DataSet
    Public Result As DataTable
    Public nFourn As Integer

    Private Sub ChargerDonnees()
        ds = New DataSet
        Using s As New SqlProxy
            'Charger la liste des fournisseurs
            s.Fill(ds, "select * from Entreprise Where Fournisseur=1 and (Inactif is null or inactif=0)", "Fournisseurs")
            'Charger la liste des produits en cours de commande
            s.Fill(ds, "select * from Appro_ProdsEnCommande", "ProdsEnCommande")
        End Using
        'Ajout de la colonne de sélection
        With ds.Tables("ProdsEnCommande").Columns
            If Not .Contains("Sel") Then .Add("Sel", GetType(Boolean))
        End With
        For Each dr As DataRow In ds.Tables("ProdsEnCommande").Rows
            dr("Sel") = True
        Next
    End Sub

    Private Sub Databinding()
        Dim dv As New DataView(ds.Tables("Fournisseurs"))
        With Me.CbFourn
            .DisplayMember = "Nom"
            .ValueMember = "nEntreprise"
            .DataSource = dv
        End With
        With ds.Tables("ProdsEnCommande").DefaultView
            .AllowNew = False
            .AllowDelete = False
        End With
        dgProduits.DataSource = ds.Tables("ProdsEnCommande")
    End Sub

    Private Sub FrCreerCommandeFourn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each col As DataGridColumnStyle In Me.dgProduits.TableStyles(0).GridColumnStyles
            If TypeOf col Is ReadOnlyTextBoxColumn Then
                AddHandler CType(col, ReadOnlyTextBoxColumn).CheckTXTEnabled, AddressOf Col_CheckEnabled
            End If
        Next
        ChargerDonnees()
        Me.Show()
        Databinding()
        If ds.Tables("ProdsEnCommande").Rows.Count = 0 Then
            MsgBox("Aucun produit n'est en attente de commande.", MsgBoxStyle.Information)
            Me.BtOK.Enabled = False
        End If
    End Sub

    Private Sub Col_CheckEnabled(ByVal sender As Object, ByVal e As DataGridEnableEventArgs)
        If Not CBool(CType(dgProduits.DataSource, DataTable).Rows(e.RowNumber).Item("Sel")) Then
            e.EnableValue = False
        End If
    End Sub

    Private Sub BtFindFourn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFindFourn.Click
        'TODO Lancer la recherche de fournisseur
        Dim nFourn As Integer
        Me.CbFourn.SelectedValue = nFourn
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Me.BindingContext(ds, "ProdsEnCommande").EndCurrentEdit()
        If Me.CbFourn.SelectedIndex < 0 Then
            MsgBox("Vous devez choisir un fournisseur.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Me.ds.Tables("ProdsEnCommande").Select("Sel=True").Length = 0 Then
            MsgBox("Vous devez sélectionner au moins un produit.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim dt As New DataTable
        With dt.Columns
            .Add("BCD_nDetailDevis")
            .Add("CodeProduit")
            .Add("Libelle")
            .Add("Unite1", GetType(Decimal))
            .Add("LibUnite1")
            .Add("Unite2", GetType(Decimal))
            .Add("LibUnite2")
        End With
        For Each dr As DataRow In Me.ds.Tables("ProdsEnCommande").Select("Sel=True")
            Dim drn As DataRow = dt.NewRow
            With drn
                .Item("BCD_nDetailDevis") = dr("nDetailDevis")
                .Item("CodeProduit") = dr("CodeProduit")
                .Item("Libelle") = dr("Libelle")
                .Item("Unite1") = dr("Unite1")
                .Item("LibUnite1") = dr("LibUnite1")
                .Item("Unite2") = dr("Unite2")
                .Item("LibUnite2") = dr("LibUnite2")
            End With
            dt.Rows.Add(drn)
        Next
        Me.nFourn = CInt(Me.CbFourn.SelectedValue)
        Me.Result = dt
        Me.DialogResult = DialogResult.OK
    End Sub

    'Gestion de la sélection
    Private Sub dgProduits_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles dgProduits.MouseUp
        Dim hti As DataGrid.HitTestInfo = Me.dgProduits.HitTest(e.X, e.Y)
        Try
            If hti.Type = DataGrid.HitTestType.Cell _
            AndAlso TypeOf dgProduits.TableStyles(0).GridColumnStyles(hti.Column) Is DataGridBoolColumn Then
                Me.dgProduits(hti.Row, hti.Column) = Not CBool(Me.dgProduits(hti.Row, hti.Column))
                Me.dgProduits.Refresh()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub BtImprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtImprimer.Click
        Dim afficherDetail As Boolean = (MsgBox("Voulez-vous imprimer le détail des commandes client ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes)
        ImprimerRecap(afficherDetail)
    End Sub

    Private Sub ImprimerRecap(ByVal afficherDetail As Boolean)
        Dim dsImp As New DataSet
        'Charger la liste des produits en cours de commande
        Using s As New SqlProxy
            s.Fill(dsImp, "Appro_ProdsEnCommande")
        End Using

        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(dsImp, "RptRecapCommandeApprofact.rpt")
        fr.Parametres.SetValue("AfficherDetail", afficherDetail)
        fr.ShowDialog()
    End Sub

    Private Sub BtSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtSelectAll.Click, BtDeselectAll.Click
        For Each dr As DataRow In CType(dgProduits.DataSource, DataTable).Rows
            dr("Sel") = sender Is BtSelectAll
        Next
        Me.dgProduits.Refresh()
    End Sub

End Class

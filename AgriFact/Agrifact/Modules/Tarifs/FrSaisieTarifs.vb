Public Class FrSaisieTarifs
    Inherits System.Windows.Forms.Form

    Public ColTarifVisible As Boolean = True
    Public ColProdVisible As Boolean = True
    Public CodeProduit As String = Nothing
    Friend WithEvents TbImpr As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColTarif As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FamilleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTTC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFiller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MajTTCButton As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProduitTableAdapter As AgriFact.DsProduitsTableAdapters.ProduitTableAdapter
    Friend WithEvents MAJTarifButton As System.Windows.Forms.Button
    Public nTarif As Integer = -1

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
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents TbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents TarifBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dgvTarif As System.Windows.Forms.DataGridView
    Friend WithEvents DsProduits As AgriFact.DsProduits
    Friend WithEvents SaisieTarifsTA As AgriFact.DsProduitsTableAdapters.SaisieTarifsTA

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tbSave = New System.Windows.Forms.ToolStripButton
        Me.TbClose = New System.Windows.Forms.ToolStripButton
        Me.TbImpr = New System.Windows.Forms.ToolStripButton
        Me.dgvTarif = New System.Windows.Forms.DataGridView
        Me.TarifBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProduits = New AgriFact.DsProduits
        Me.MajTTCButton = New System.Windows.Forms.Button
        Me.SaisieTarifsTA = New AgriFact.DsProduitsTableAdapters.SaisieTarifsTA
        Me.ProduitTableAdapter = New AgriFact.DsProduitsTableAdapters.ProduitTableAdapter
        Me.MAJTarifButton = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTarif = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FamilleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColProd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColHT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColTTC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColFiller = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvTarif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbSave, Me.TbClose, Me.TbImpr})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(858, 39)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbSave
        '
        Me.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSave.Image = Global.AgriFact.My.Resources.Resources.save24
        Me.tbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSave.Name = "tbSave"
        Me.tbSave.Size = New System.Drawing.Size(28, 36)
        Me.tbSave.Text = "Enregistrer"
        '
        'TbClose
        '
        Me.TbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbClose.Image = Global.AgriFact.My.Resources.Resources.close16
        Me.TbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbClose.Name = "TbClose"
        Me.TbClose.Size = New System.Drawing.Size(23, 36)
        Me.TbClose.Text = "Fermer"
        '
        'TbImpr
        '
        Me.TbImpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbImpr.Image = Global.AgriFact.My.Resources.Resources.impr32
        Me.TbImpr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TbImpr.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbImpr.Name = "TbImpr"
        Me.TbImpr.Size = New System.Drawing.Size(36, 36)
        Me.TbImpr.Text = "Imprimer"
        '
        'dgvTarif
        '
        Me.dgvTarif.AllowUserToAddRows = False
        Me.dgvTarif.AllowUserToDeleteRows = False
        Me.dgvTarif.AutoGenerateColumns = False
        Me.dgvTarif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTarif.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTarif, Me.FamilleDataGridViewTextBoxColumn, Me.ColProd, Me.ColHT, Me.ColTTC, Me.ColFiller})
        Me.dgvTarif.DataSource = Me.TarifBindingSource
        Me.dgvTarif.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTarif.Location = New System.Drawing.Point(0, 39)
        Me.dgvTarif.Name = "dgvTarif"
        Me.dgvTarif.Size = New System.Drawing.Size(858, 459)
        Me.dgvTarif.TabIndex = 4
        '
        'TarifBindingSource
        '
        Me.TarifBindingSource.DataMember = "SaisieTarifs"
        Me.TarifBindingSource.DataSource = Me.DsProduits
        '
        'DsProduits
        '
        Me.DsProduits.DataSetName = "DsProduits"
        Me.DsProduits.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MajTTCButton
        '
        Me.MajTTCButton.Location = New System.Drawing.Point(708, 8)
        Me.MajTTCButton.Name = "MajTTCButton"
        Me.MajTTCButton.Size = New System.Drawing.Size(118, 23)
        Me.MajTTCButton.TabIndex = 5
        Me.MajTTCButton.Text = "Mise à jour du TTC"
        Me.MajTTCButton.UseVisualStyleBackColor = True
        '
        'SaisieTarifsTA
        '
        Me.SaisieTarifsTA.ClearBeforeFill = True
        '
        'ProduitTableAdapter
        '
        Me.ProduitTableAdapter.ClearBeforeFill = True
        '
        'MAJTarifButton
        '
        Me.MAJTarifButton.Location = New System.Drawing.Point(507, 8)
        Me.MAJTarifButton.Name = "MAJTarifButton"
        Me.MAJTarifButton.Size = New System.Drawing.Size(195, 23)
        Me.MAJTarifButton.TabIndex = 6
        Me.MAJTarifButton.Text = "Mise à jour depuis tarif standard"
        Me.MAJTarifButton.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TLib"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tarif"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 53
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Famille"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Famille"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 64
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PLib"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Produit"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 65
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PrixVHT"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C3"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn4.HeaderText = "Prix V HT"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 77
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PrixVTTC"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C3"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn5.HeaderText = "Prix V TTC"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 83
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'ColTarif
        '
        Me.ColTarif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColTarif.DataPropertyName = "TLib"
        Me.ColTarif.HeaderText = "Tarif"
        Me.ColTarif.Name = "ColTarif"
        Me.ColTarif.ReadOnly = True
        Me.ColTarif.Width = 53
        '
        'FamilleDataGridViewTextBoxColumn
        '
        Me.FamilleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FamilleDataGridViewTextBoxColumn.DataPropertyName = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.HeaderText = "Famille"
        Me.FamilleDataGridViewTextBoxColumn.Name = "FamilleDataGridViewTextBoxColumn"
        Me.FamilleDataGridViewTextBoxColumn.ReadOnly = True
        Me.FamilleDataGridViewTextBoxColumn.Width = 64
        '
        'ColProd
        '
        Me.ColProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColProd.DataPropertyName = "PLib"
        Me.ColProd.HeaderText = "Produit"
        Me.ColProd.Name = "ColProd"
        Me.ColProd.ReadOnly = True
        Me.ColProd.Width = 65
        '
        'ColHT
        '
        Me.ColHT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColHT.DataPropertyName = "PrixVHT"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C3"
        Me.ColHT.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColHT.HeaderText = "Prix V HT"
        Me.ColHT.Name = "ColHT"
        Me.ColHT.Width = 77
        '
        'ColTTC
        '
        Me.ColTTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ColTTC.DataPropertyName = "PrixVTTC"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C3"
        Me.ColTTC.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColTTC.HeaderText = "Prix V TTC"
        Me.ColTTC.Name = "ColTTC"
        Me.ColTTC.Width = 83
        '
        'ColFiller
        '
        Me.ColFiller.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColFiller.HeaderText = ""
        Me.ColFiller.Name = "ColFiller"
        Me.ColFiller.ReadOnly = True
        '
        'FrSaisieTarifs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(858, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.MAJTarifButton)
        Me.Controls.Add(Me.MajTTCButton)
        Me.Controls.Add(Me.dgvTarif)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrSaisieTarifs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saisie des tarifs"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvTarif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TarifBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim txt As String = "Saisie des prix"
            If nTarif >= 0 Then
                Me.SaisieTarifsTA.FillByTarif(Me.DsProduits.SaisieTarifs, nTarif)
                If Me.DsProduits.SaisieTarifs.Count > 0 Then
                    Dim dr As DsProduits.SaisieTarifsRow = Me.DsProduits.SaisieTarifs(0)
                    txt = String.Format("{0} pour le tarif {1}", txt, dr.TLib)
                End If
            ElseIf CodeProduit IsNot Nothing Then
                Me.SaisieTarifsTA.FillByProduit(Me.DsProduits.SaisieTarifs, CodeProduit)
                If Me.DsProduits.SaisieTarifs.Count > 0 Then
                    Dim dr As DsProduits.SaisieTarifsRow = Me.DsProduits.SaisieTarifs(0)
                    txt = String.Format("{0} pour le produit {1}", txt, dr.PLib)
                End If
            Else
                Me.SaisieTarifsTA.FillPrixStandard(Me.DsProduits.SaisieTarifs)
                txt = String.Format("{0} pour le tarif standard", txt)
            End If
            Me.Text = txt
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Enregistrer()
        Me.Validate()
        Me.TarifBindingSource.EndEdit()
        If Me.DsProduits.HasChanges Then
            Try
                Dim dt As DsProduits.SaisieTarifsDataTable = Cast(Of DsProduits.SaisieTarifsDataTable)(Me.DsProduits.SaisieTarifs.GetChanges(DataRowState.Modified))
                If dt IsNot Nothing Then
                    For Each dr As DataRow In dt.Rows
                        If Me.nTarif < 0 AndAlso Me.CodeProduit Is Nothing Then
                            'Mise à jour des prix dans la table PRODUIT
                            Me.SaisieTarifsTA.UpdatePrixStandard(dt)
                        Else
                            'Mise à jour des prix dans la table TARIF_DETAIL
                            Me.SaisieTarifsTA.UpdateTarifs(dt)
                        End If
                    Next
                End If
                Me.DsProduits.SaisieTarifs.AcceptChanges()
            Catch ex As SqlClient.SqlException
                SqlProxy.GererSqlException(ex)
            End Try
        End If
        MajBoutons()
    End Sub

    Private Function DemanderEnregistrement() As Boolean
        Me.Validate()
        Me.TarifBindingSource.EndEdit()
        If Me.DsProduits.HasChanges Then
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
#End Region

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        ApplyStyle(Me.dgvTarif, False)
        If Not ColTarifVisible Then Me.ColTarif.Visible = False
        If Not ColProdVisible Then Me.ColProd.Visible = False
        If Not ColProdVisible Then Me.FamilleDataGridViewTextBoxColumn.Visible = False
        ChargerDonnees()
        AddHandler Me.DsProduits.SaisieTarifs.RowChanged, AddressOf MajBoutons
        MajBoutons()
    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        Me.tbSave.Enabled = Me.DsProduits.HasChanges
    End Sub

    Private Sub tbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSave.Click
        Enregistrer()
    End Sub

    Private Sub TbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbClose.Click
        Me.Close()
    End Sub

    Private Sub TbImpr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbImpr.Click
        ImprimerTarif()
    End Sub

    Private Sub ImprimerTarif()
        Dim myDs As New DataSet
        myDs.Merge(Me.DsProduits.SaisieTarifs)
        myDs.Tables("SaisieTarifs").TableName = "Produit"
        With myDs.Tables("Produit").Columns
            .Item("Famille").ColumnName = "NomFamille"
            If Me.nTarif > 0 Then
                .Item("PLib").ColumnName = "Libelle"
            Else
                .Item("TLib").ColumnName = "Libelle"
            End If
        End With
        Dim fr As GRC.FrFusion = GestionImpression.TrouverRapport(myDs, "RptListeProduit.rpt")
        fr.TitreRapport = Me.Text
        fr.Show()
    End Sub

    Private Sub MajTTCButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MajTTCButton.Click
        'legrain 04/11/2013
        Dim dt As DsProduits.SaisieTarifsDataTable = Cast(Of DsProduits.SaisieTarifsDataTable)(Me.DsProduits.SaisieTarifs)
        Dim dtProduit As DsProduits.ProduitDataTable = Cast(Of DsProduits.ProduitDataTable)(Me.DsProduits.Produit)

        Dim ciClone As System.Globalization.CultureInfo = CType(System.Globalization.CultureInfo.InvariantCulture.Clone(), System.Globalization.CultureInfo)
        ciClone.NumberFormat.NumberDecimalSeparator = "."

        For Each row As DataRow In dt.Rows
            Me.ProduitTableAdapter.Fill(dtProduit)

            Dim codeProduitSQL As String = CStr(row("CodeProduit")).Replace("'", "''")
            Dim foundRows() As DataRow = dtProduit.Select("CodeProduit = '" & codeProduitSQL & "'")

            If foundRows.Length > 0 Then
                Dim r As DataRow = foundRows(0)

                If Not IsDBNull(r("TTaux")) And Not IsDBNull(row("PrixVHT")) Then
                    Dim tx As Double = Convert.ToDouble(r("TTaux"), ciClone)
                    row("PrixVTTC") = Math.Round(Convert.ToDouble(row("PrixVHT"), ciClone) * (1 + tx / 100), 2)
                End If

            End If

        Next

    End Sub

    Private Sub MAJTarifButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MAJTarifButton.Click
        'legrain 04/11/2013
        Dim s As SqlProxy = New SqlProxy
        'MessageBox.Show("Type tarif" & Me.nTarif)
        If Me.nTarif <> -1 Then
            s.ExecuteScalar("update tarif_detail set coef = (SELECT AVG (coef) FROM [Tarif_Detail] where ntarif=" & Me.nTarif & " and coef is not null) where ntarif=" & Me.nTarif & " and coef is null")
            s.ExecuteScalar("update Tarif_Detail set PrixVHT = ROUND((select p.PrixVHT from Produit p where Tarif_Detail.CodeProduit=p.CodeProduit)*Coef,2) where Coef is not null and nTarif=" & Me.nTarif)
            ChargerDonnees() 'refresh
            MajTTCButton.PerformClick()
        End If
    End Sub
End Class

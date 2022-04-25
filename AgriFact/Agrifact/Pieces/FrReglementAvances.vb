Imports System.Data.SqlClient

Public Class FrReglementAvances
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbTotalSel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents dgvAvances As System.Windows.Forms.DataGridView
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents AvancesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsPieces As AgriFact.DsPieces
    Friend WithEvents AvancesTA As AgriFact.DsPiecesTableAdapters.AvancesTA
    Friend WithEvents ColSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LibelleDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontantDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ResteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lbTotalFact As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbTotalSel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbTotalFact = New System.Windows.Forms.Label
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.dgvAvances = New System.Windows.Forms.DataGridView
        Me.AvancesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPieces = New AgriFact.DsPieces
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.AvancesTA = New AgriFact.DsPiecesTableAdapters.AvancesTA
        Me.ColSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.LibelleDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MontantDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ResteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GradientPanel1.SuspendLayout()
        CType(Me.dgvAvances, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AvancesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(249, 10)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 0
        Me.BtOK.Text = "OK"
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(329, 10)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 1
        Me.BtCancel.Text = "Annuler"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Acomptes et avoirs disponibles :"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(396, 30)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ce client dispose d'acomptes ou d'avoirs. Si vous voulez les utiliser pour régler" & _
            " ce(s) facture(s), sélectionnez-les ci-dessous :"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(236, 276)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Total sélectionné :"
        '
        'lbTotalSel
        '
        Me.lbTotalSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTotalSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalSel.Location = New System.Drawing.Point(332, 276)
        Me.lbTotalSel.Name = "lbTotalSel"
        Me.lbTotalSel.Size = New System.Drawing.Size(72, 16)
        Me.lbTotalSel.TabIndex = 7
        Me.lbTotalSel.Text = "9 999,99 €"
        Me.lbTotalSel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(204, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Montant total à régler :"
        '
        'lbTotalFact
        '
        Me.lbTotalFact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTotalFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalFact.Location = New System.Drawing.Point(324, 35)
        Me.lbTotalFact.Name = "lbTotalFact"
        Me.lbTotalFact.Size = New System.Drawing.Size(80, 16)
        Me.lbTotalFact.TabIndex = 9
        Me.lbTotalFact.Text = "9 999,99 €"
        Me.lbTotalFact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.dgvAvances)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.lbTotalSel)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.lbTotalFact)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(416, 297)
        Me.GradientPanel1.TabIndex = 22
        '
        'dgvAvances
        '
        Me.dgvAvances.AllowUserToAddRows = False
        Me.dgvAvances.AllowUserToDeleteRows = False
        Me.dgvAvances.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAvances.AutoGenerateColumns = False
        Me.dgvAvances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAvances.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSel, Me.LibelleDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.MontantDataGridViewTextBoxColumn, Me.ResteDataGridViewTextBoxColumn})
        Me.dgvAvances.DataSource = Me.AvancesBindingSource
        Me.dgvAvances.Location = New System.Drawing.Point(11, 70)
        Me.dgvAvances.Name = "dgvAvances"
        Me.dgvAvances.ReadOnly = True
        Me.dgvAvances.Size = New System.Drawing.Size(397, 203)
        Me.dgvAvances.TabIndex = 10
        '
        'AvancesBindingSource
        '
        Me.AvancesBindingSource.DataMember = "Avances"
        Me.AvancesBindingSource.DataSource = Me.DsPieces
        '
        'DsPieces
        '
        Me.DsPieces.DataSetName = "DsPieces"
        Me.DsPieces.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtCancel)
        Me.GradientPanel2.Controls.Add(Me.BtOK)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 297)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(416, 45)
        Me.GradientPanel2.TabIndex = 23
        '
        'AvancesTA
        '
        Me.AvancesTA.ClearBeforeFill = True
        '
        'ColSel
        '
        Me.ColSel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColSel.HeaderText = ""
        Me.ColSel.Name = "ColSel"
        Me.ColSel.ReadOnly = True
        Me.ColSel.Width = 20
        '
        'LibelleDataGridViewTextBoxColumn
        '
        Me.LibelleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LibelleDataGridViewTextBoxColumn.DataPropertyName = "Libelle"
        Me.LibelleDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.LibelleDataGridViewTextBoxColumn.Name = "LibelleDataGridViewTextBoxColumn"
        Me.LibelleDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "date"
        DataGridViewCellStyle1.Format = "g"
        Me.DateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 55
        '
        'MontantDataGridViewTextBoxColumn
        '
        Me.MontantDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MontantDataGridViewTextBoxColumn.DataPropertyName = "montant"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        Me.MontantDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.MontantDataGridViewTextBoxColumn.HeaderText = "Montant"
        Me.MontantDataGridViewTextBoxColumn.Name = "MontantDataGridViewTextBoxColumn"
        Me.MontantDataGridViewTextBoxColumn.ReadOnly = True
        Me.MontantDataGridViewTextBoxColumn.Width = 71
        '
        'ResteDataGridViewTextBoxColumn
        '
        Me.ResteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ResteDataGridViewTextBoxColumn.DataPropertyName = "Reste"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        Me.ResteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ResteDataGridViewTextBoxColumn.HeaderText = "Reste"
        Me.ResteDataGridViewTextBoxColumn.Name = "ResteDataGridViewTextBoxColumn"
        Me.ResteDataGridViewTextBoxColumn.ReadOnly = True
        Me.ResteDataGridViewTextBoxColumn.Width = 60
        '
        'FrReglementAvances
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(416, 342)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrReglementAvances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Affecter des acomptes et avoirs"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.dgvAvances, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AvancesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPieces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private ds As DataSet
    Public nClient As Integer
    Public lstFactures As List(Of DataRow)

    Private montantFactures As Decimal

    Private Sub ChargerDonnees()
        ds = lstFactures(0).Table.DataSet
        Me.AvancesTA.FillByNClient(Me.DsPieces.Avances, nClient)
        If Not ds.Tables.Contains("Reglement_Detail") Then
            DefinitionDonnees.Instance.FillSchema(ds, "Reglement_Detail")
        End If
        RecalculerTotal()
    End Sub

    Private Sub Databinding()
        Dim totalFact As Decimal = 0
        For Each dr As DataRow In Me.lstFactures
            totalFact += AvancesTA.GetResteAPayer(CDec(dr("nDevis"))).GetValueOrDefault
        Next
        montantFactures = totalFact
        Me.lbTotalFact.Text = montantFactures.ToString("C2")
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ApplyStyle(Me.dgvAvances)
        ConfigColSel(Me.dgvAvances, Me.ColSel, AddressOf SelectionChanged)
        ChargerDonnees()
        Me.Show()
        Databinding()
        If DsPieces.Avances.Count = 0 Then
            MsgBox("Aucun acompte ou avoir n'est disponible pour ce client.", MsgBoxStyle.Information)
            Me.BtOK.Enabled = False
        End If
    End Sub

    Private Sub SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
        RecalculerTotal()
    End Sub

    Private Sub RecalculerTotal()
        Dim total As Decimal = 0
        For Each dr As DataRow In GetSelectedRows(Me.dgvAvances)
            total += CDec(dr("Reste"))
        Next
        total = Math.Min(total, montantFactures)
        Me.lbTotalSel.Text = total.ToString("C2")
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        Me.AvancesBindingSource.EndEdit()
        Dim selRws As List(Of DataRow) = GetSelectedRows(Me.dgvAvances)
        If selRws.Count = 0 Then
            'Si aucune ligne de sélectionnée, on zappe
            Me.DialogResult = DialogResult.Cancel
            Exit Sub
        Else
            'On ajoute les avoirs sélectionnés à la liste des factures
            'On fait un double Reverse pour se retrouver avec les Avoirs en premier
            lstFactures.Reverse()
            For Each drAvance As DataRow In selRws.FindAll(AddressOf AvanceIsAvoir)
                AjouterFacture(CInt(drAvance("id")))
            Next
            lstFactures.Reverse()
            Dim selRegls As List(Of DataRow) = selRws.FindAll(AddressOf AvanceIsReglement)
            If selRegls.Count = 0 Then
                'Si aucun réglement de sélectionné, on trace
                Me.DialogResult = DialogResult.OK
                Exit Sub
            Else 'Sinon, c'est parti pour le réglement
                'Pour chaque réglement sélectionné
                For Each drAvanceRegl As DataRow In selRegls
                    Dim resteR As Decimal = CDec(drAvanceRegl("Reste"))
                    If resteR > 0 Then
                        Dim nRegl As Integer = CInt(drAvanceRegl("id"))
                        'On affecte toutes les factures restantes à ce réglement
                        For Each drFact As DataRow In lstFactures
                            Affecter(nRegl, drFact, resteR)

                            'MAJ indicateur paye
                            Me.TraiterIndicateurPaye(drFact)

                            If resteR = 0 Then Exit For
                        Next
                        If resteR > 0 Then Exit For 'Il y a du reste à affecter => Toutes les factures ont été réglées à 100%
                    End If
                Next
                'Purger la liste des factures
                Dim offSet As Integer = 0
                lstFactures.RemoveAll(AddressOf FactureIsPaye)
                'MAJ de la base
                Using s As New SqlProxy
                    s.UpdateTable(ds, "Reglement_Detail")
                End Using
            End If
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub TraiterIndicateurPaye(ByVal drFact As DataRow)
        Using sqlConn As New SqlConnection(My.Settings.AgrifactConnString)
            sqlConn.Open()

            Using sqlComm As New SqlCommand
                sqlComm.Connection = sqlConn

                Dim queryString As String = String.Empty

                If Not (drFact.IsNull("Paye")) Then
                    Dim estPaye As Integer = 0

                    If (CBool(drFact("Paye")) = True) Then
                        estPaye = 1
                    Else
                        estPaye = 0
                    End If

                    queryString = "UPDATE VFacture SET Paye = " & estPaye & _
                                    " WHERE VFacture.nDevis = " & CInt(drFact("nDevis"))

                    sqlComm.CommandText = queryString

                    sqlComm.ExecuteNonQuery()
                End If
            End Using
        End Using
    End Sub

    Private Function AvanceIsAvoir(ByVal dr As DataRow) As Boolean
        Return Convert.ToString(dr("Type")) = "A"
    End Function

    Private Function AvanceIsReglement(ByVal dr As DataRow) As Boolean
        Return Convert.ToString(dr("Type")) = "R"
    End Function

    Private Function FactureIsPaye(ByVal dr As DataRow) As Boolean
        Return Not dr.IsNull("Paye") AndAlso CBool(dr("Paye"))
    End Function

    Private Sub Affecter(ByVal nRegl As Integer, ByVal drFact As DataRow, ByRef resteR As Decimal)
        If FactureIsPaye(drFact) Then Exit Sub
        Dim resteF As Decimal = AvancesTA.GetResteAPayer(CDec(drFact("nDevis"))).GetValueOrDefault(0)
        If resteF <= resteR Then
            AffecterMontant(nRegl, drFact, resteF)
            'Pour chaque facture entiérement réglée (ou avoir entièrement affecté) : marquer payé
            drFact("Paye") = True
            resteR -= resteF
        Else
            AffecterMontant(nRegl, drFact, resteR)
            resteR = 0
        End If
    End Sub

    Private Sub AffecterMontant(ByVal nRegl As Integer, ByVal drFact As DataRow, ByRef montant As Decimal)
        Dim rwDetail As DataRow = ds.Tables("Reglement_Detail").NewRow
        With rwDetail
            .Item("nReglement") = nRegl
            .Item("nFacture") = drFact("nDevis")
            .Item("Montant") = montant
        End With
        ds.Tables("Reglement_Detail").Rows.Add(rwDetail)
    End Sub

    Private Sub AjouterFacture(ByVal nDevis As Integer)
        Dim dt As DataTable = ds.Tables("VFacture")
        Dim drFact As DataRow = SelectSingleRow(dt, "nDevis=" & nDevis, "")
        If drFact Is Nothing Then
            Using s As New SqlProxy
                s.FillBy(ds, "VFacture", "nDevis=" & nDevis, False)
            End Using
            drFact = SelectSingleRow(ds.Tables("VFacture"), "nDevis=" & nDevis, "")
        End If
        If drFact IsNot Nothing Then lstFactures.Add(drFact)
    End Sub

End Class

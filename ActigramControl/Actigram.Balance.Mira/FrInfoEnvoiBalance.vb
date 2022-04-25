Public Class FrInfoEnvoiBalance
    Inherits System.Windows.Forms.Form
    Public dv As DataView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvPrix As System.Windows.Forms.DataGridView
    Friend WithEvents nPLU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Libelle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelPrixOrdi As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PrixOrdi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SelPrixBal As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PrixBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Private _BmpSelect As Bitmap

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
    Friend WithEvents TxText As System.Windows.Forms.TextBox
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtDetail As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TxText = New System.Windows.Forms.TextBox
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtDetail = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvPrix = New System.Windows.Forms.DataGridView
        Me.nPLU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Libelle = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelPrixOrdi = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PrixOrdi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SelPrixBal = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.PrixBalance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxText
        '
        Me.TxText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxText.Location = New System.Drawing.Point(8, 240)
        Me.TxText.Multiline = True
        Me.TxText.Name = "TxText"
        Me.TxText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxText.Size = New System.Drawing.Size(544, 88)
        Me.TxText.TabIndex = 0
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtOK.Location = New System.Drawing.Point(402, 7)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(72, 24)
        Me.BtOK.TabIndex = 1
        Me.BtOK.Text = "OK"
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(480, 7)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(72, 24)
        Me.BtCancel.TabIndex = 2
        Me.BtCancel.Text = "Annuler"
        '
        'BtDetail
        '
        Me.BtDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtDetail.Location = New System.Drawing.Point(324, 7)
        Me.BtDetail.Name = "BtDetail"
        Me.BtDetail.Size = New System.Drawing.Size(72, 24)
        Me.BtDetail.TabIndex = 5
        Me.BtDetail.Text = ">> Detail"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.BtOK)
        Me.Panel1.Controls.Add(Me.BtDetail)
        Me.Panel1.Controls.Add(Me.BtCancel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 335)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 40)
        Me.Panel1.TabIndex = 6
        '
        'dgvPrix
        '
        Me.dgvPrix.AllowUserToAddRows = False
        Me.dgvPrix.AllowUserToDeleteRows = False
        Me.dgvPrix.AllowUserToResizeRows = False
        Me.dgvPrix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrix.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nPLU, Me.Libelle, Me.SelPrixOrdi, Me.PrixOrdi, Me.SelPrixBal, Me.PrixBalance})
        Me.dgvPrix.Location = New System.Drawing.Point(8, 12)
        Me.dgvPrix.Name = "dgvPrix"
        Me.dgvPrix.RowHeadersVisible = False
        Me.dgvPrix.Size = New System.Drawing.Size(544, 222)
        Me.dgvPrix.TabIndex = 7
        '
        'nPLU
        '
        Me.nPLU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.nPLU.DataPropertyName = "nPLU"
        Me.nPLU.HeaderText = "nPLU"
        Me.nPLU.Name = "nPLU"
        Me.nPLU.Width = 59
        '
        'Libelle
        '
        Me.Libelle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Libelle.DataPropertyName = "Libelle"
        Me.Libelle.HeaderText = "Libelle"
        Me.Libelle.Name = "Libelle"
        '
        'SelPrixOrdi
        '
        Me.SelPrixOrdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SelPrixOrdi.DataPropertyName = "EnvoiBalance"
        Me.SelPrixOrdi.HeaderText = ""
        Me.SelPrixOrdi.Name = "SelPrixOrdi"
        Me.SelPrixOrdi.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SelPrixOrdi.Width = 20
        '
        'PrixOrdi
        '
        Me.PrixOrdi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PrixOrdi.DataPropertyName = "PrixOrdi"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        Me.PrixOrdi.DefaultCellStyle = DataGridViewCellStyle5
        Me.PrixOrdi.HeaderText = "Prix Ordi"
        Me.PrixOrdi.Name = "PrixOrdi"
        Me.PrixOrdi.Width = 71
        '
        'SelPrixBal
        '
        Me.SelPrixBal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SelPrixBal.DataPropertyName = "RecupBalance"
        Me.SelPrixBal.HeaderText = ""
        Me.SelPrixBal.Name = "SelPrixBal"
        Me.SelPrixBal.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.SelPrixBal.Width = 20
        '
        'PrixBalance
        '
        Me.PrixBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PrixBalance.DataPropertyName = "PrixBalance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        Me.PrixBalance.DefaultCellStyle = DataGridViewCellStyle6
        Me.PrixBalance.HeaderText = "Prix Balance"
        Me.PrixBalance.Name = "PrixBalance"
        Me.PrixBalance.Width = 91
        '
        'FrInfoEnvoiBalance
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(560, 375)
        Me.Controls.Add(Me.dgvPrix)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrInfoEnvoiBalance"
        Me.Text = "Info Envoi Balance"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvPrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrInfoEnvoiBalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BtDetail_Click(Nothing, Nothing)
        Me.dgvPrix.AutoGenerateColumns = False
        If Not dv Is Nothing Then
            Me.dgvPrix.DataSource = dv
            'Me.Grille1.DataSource = dv
            'Me.Grille1.Refresh()
        End If
    End Sub

    'Private Sub BtBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBalance.Click
    '    If Convert.ToBoolean(dv(Me.Grille1.SelectedGroupe).Item("EnvoiBalance")) = False Then
    '        dv(Me.Grille1.SelectedGroupe).Item("EnvoiBalance") = True
    '        dv(Me.Grille1.SelectedGroupe).EndEdit()
    '        'Me.BtSelect.BackColor = Color.Red
    '        If _BmpSelect Is Nothing Then
    '            _BmpSelect = New Bitmap(Me.Grille1.SelectImage)
    '            _BmpSelect.MakeTransparent(Color.White)
    '            Me.BtBalance.ImageAlign = ContentAlignment.MiddleLeft
    '        End If
    '        Me.BtBalance.Image = _BmpSelect
    '        dv(Me.Grille1.SelectedGroupe).Item("RecupBalance") = False
    '        dv(Me.Grille1.SelectedGroupe).EndEdit()
    '        Me.BtOrdinateur.Image = Nothing
    '    Else
    '        dv(Me.Grille1.SelectedGroupe).Item("EnvoiBalance") = False
    '        dv(Me.Grille1.SelectedGroupe).EndEdit()
    '        Me.BtBalance.BackColor = Me.Grille1.GroupeBackColorSelected
    '        Me.BtBalance.Image = Nothing
    '    End If
    'End Sub

    'Private Sub BtOrdinateur_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtOrdinateur.Click
    '    If Convert.ToBoolean(dv(Me.Grille1.SelectedGroupe).Item("RecupBalance")) = False Then
    '        If Not dv(Me.Grille1.SelectedGroupe).Item("PrixBalance") Is DBNull.Value Then
    '            dv(Me.Grille1.SelectedGroupe).Item("RecupBalance") = True
    '            dv(Me.Grille1.SelectedGroupe).EndEdit()
    '            'Me.BtSelect.BackColor = Color.Red
    '            If _BmpSelect Is Nothing Then
    '                _BmpSelect = New Bitmap(Me.Grille1.SelectImage)
    '                _BmpSelect.MakeTransparent(Color.White)
    '                Me.BtOrdinateur.ImageAlign = ContentAlignment.MiddleLeft
    '            End If
    '            Me.BtOrdinateur.Image = _BmpSelect

    '            dv(Me.Grille1.SelectedGroupe).Item("EnvoiBalance") = False
    '            dv(Me.Grille1.SelectedGroupe).EndEdit()
    '            Me.BtBalance.Image = Nothing
    '        End If
    '    Else
    '        dv(Me.Grille1.SelectedGroupe).Item("RecupBalance") = False
    '        dv(Me.Grille1.SelectedGroupe).EndEdit()
    '        Me.BtOrdinateur.BackColor = Me.Grille1.GroupeBackColorSelected
    '        Me.BtOrdinateur.Image = Nothing
    '    End If
    'End Sub

    'Private Sub Grille1_EntreGroupe(ByVal Groupe As System.Data.DataRowView) Handles Grille1.EntreGroupe
    '    If Convert.ToBoolean(Groupe.Item("EnvoiBalance")) = True Then
    '        'Me.BtSelect.BackColor = Color.Red
    '        If _BmpSelect Is Nothing Then
    '            _BmpSelect = New Bitmap(Me.Grille1.SelectImage)
    '            _BmpSelect.MakeTransparent(Color.White)
    '            Me.BtBalance.ImageAlign = ContentAlignment.MiddleLeft
    '        End If
    '        Me.BtBalance.Image = _BmpSelect
    '    Else
    '        Me.BtBalance.BackColor = Me.Grille1.GroupeBackColorSelected
    '        Me.BtBalance.Image = Nothing
    '    End If
    '    If Convert.ToBoolean(Groupe.Item("RecupBalance")) = True Then
    '        If _BmpSelect Is Nothing Then
    '            _BmpSelect = New Bitmap(Me.Grille1.SelectImage)
    '            _BmpSelect.MakeTransparent(Color.White)
    '            Me.BtOrdinateur.ImageAlign = ContentAlignment.MiddleLeft
    '        End If
    '        Me.BtOrdinateur.Image = _BmpSelect
    '    Else
    '        Me.BtOrdinateur.BackColor = Me.Grille1.GroupeBackColorSelected
    '        Me.BtOrdinateur.Image = Nothing
    '    End If
    'End Sub

    Private Sub BtDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDetail.Click
        If Me.TxText.Visible Then
            Me.TxText.Visible = False
            Me.Height = 317
            Me.BtDetail.Text = ">>Detail"
        Else
            Me.TxText.Visible = True
            Me.Height = 413
            Me.BtDetail.Text = "<<Detail"
        End If
    End Sub

    Private Sub dgvPrix_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrix.CellContentClick
        If e.RowIndex < 0 Then Exit Sub
        If TypeOf CType(sender, DataGridView).Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn Then
            Dim c As DataGridViewCheckBoxCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)
            c.Value = Not CBool(c.Value)
            If CBool(c.Value) Then
                If e.ColumnIndex = Me.SelPrixBal.Index Then
                    CType(sender, DataGridView).Rows(e.RowIndex).Cells(Me.SelPrixOrdi.Index).Value = False
                ElseIf e.ColumnIndex = Me.SelPrixOrdi.Index Then
                    CType(sender, DataGridView).Rows(e.RowIndex).Cells(Me.SelPrixBal.Index).Value = False
                End If
            End If
        End If
    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrUpdates
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim VersionLabel As System.Windows.Forms.Label
        Dim DateFichierLabel As System.Windows.Forms.Label
        Dim TailleFichierLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrUpdates))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TailleFichierLabel1 = New System.Windows.Forms.Label
        Me.UpdatesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsUpdates = New AgrigestEDI.ActiUpdates.dsUpdates
        Me.DateFichierLabel1 = New System.Windows.Forms.Label
        Me.NiveauLabel1 = New System.Windows.Forms.Label
        Me.VersionLabel1 = New System.Windows.Forms.Label
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.UpdatesDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NiveauDisplay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pbLoading = New System.Windows.Forms.PictureBox
        Me.lbStatus = New System.Windows.Forms.Label
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.BtInstall = New System.Windows.Forms.Button
        Me.CloseButton = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        VersionLabel = New System.Windows.Forms.Label
        DateFichierLabel = New System.Windows.Forms.Label
        TailleFichierLabel = New System.Windows.Forms.Label
        Me.GradientPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UpdatesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUpdates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpdatesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'VersionLabel
        '
        VersionLabel.AutoSize = True
        VersionLabel.Location = New System.Drawing.Point(6, 21)
        VersionLabel.Name = "VersionLabel"
        VersionLabel.Size = New System.Drawing.Size(45, 13)
        VersionLabel.TabIndex = 2
        VersionLabel.Text = "Version:"
        '
        'DateFichierLabel
        '
        DateFichierLabel.AutoSize = True
        DateFichierLabel.Location = New System.Drawing.Point(6, 42)
        DateFichierLabel.Name = "DateFichierLabel"
        DateFichierLabel.Size = New System.Drawing.Size(36, 13)
        DateFichierLabel.TabIndex = 5
        DateFichierLabel.Text = "Date :"
        '
        'TailleFichierLabel
        '
        TailleFichierLabel.AutoSize = True
        TailleFichierLabel.Location = New System.Drawing.Point(168, 40)
        TailleFichierLabel.Name = "TailleFichierLabel"
        TailleFichierLabel.Size = New System.Drawing.Size(38, 13)
        TailleFichierLabel.TabIndex = 7
        TailleFichierLabel.Text = "Taille :"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.GroupBox1)
        Me.GradientPanel1.Controls.Add(Me.UpdatesDataGridView)
        Me.GradientPanel1.Controls.Add(Me.pbLoading)
        Me.GradientPanel1.Controls.Add(Me.lbStatus)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(353, 310)
        Me.GradientPanel1.TabIndex = 16
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(TailleFichierLabel)
        Me.GroupBox1.Controls.Add(Me.TailleFichierLabel1)
        Me.GroupBox1.Controls.Add(DateFichierLabel)
        Me.GroupBox1.Controls.Add(Me.DateFichierLabel1)
        Me.GroupBox1.Controls.Add(Me.NiveauLabel1)
        Me.GroupBox1.Controls.Add(VersionLabel)
        Me.GroupBox1.Controls.Add(Me.VersionLabel1)
        Me.GroupBox1.Controls.Add(Me.DescriptionTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 176)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Description de la version"
        '
        'TailleFichierLabel1
        '
        Me.TailleFichierLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "TailleFichier", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.TailleFichierLabel1.Location = New System.Drawing.Point(212, 40)
        Me.TailleFichierLabel1.Name = "TailleFichierLabel1"
        Me.TailleFichierLabel1.Size = New System.Drawing.Size(112, 15)
        Me.TailleFichierLabel1.TabIndex = 8
        Me.TailleFichierLabel1.Text = "99 999,99"
        '
        'UpdatesBindingSource
        '
        Me.UpdatesBindingSource.DataMember = "Updates"
        Me.UpdatesBindingSource.DataSource = Me.DsUpdates
        Me.UpdatesBindingSource.Sort = "version desc"
        '
        'DsUpdates
        '
        Me.DsUpdates.DataSetName = "dsUpdates"
        Me.DsUpdates.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DateFichierLabel1
        '
        Me.DateFichierLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "DateFichier", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "d"))
        Me.DateFichierLabel1.Location = New System.Drawing.Point(57, 40)
        Me.DateFichierLabel1.Name = "DateFichierLabel1"
        Me.DateFichierLabel1.Size = New System.Drawing.Size(71, 15)
        Me.DateFichierLabel1.TabIndex = 6
        Me.DateFichierLabel1.Text = "99/99/9999"
        '
        'NiveauLabel1
        '
        Me.NiveauLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NiveauLabel1.ForeColor = System.Drawing.Color.Tomato
        Me.NiveauLabel1.Location = New System.Drawing.Point(168, 21)
        Me.NiveauLabel1.Name = "NiveauLabel1"
        Me.NiveauLabel1.Size = New System.Drawing.Size(100, 13)
        Me.NiveauLabel1.TabIndex = 5
        Me.NiveauLabel1.Text = "Niveau"
        '
        'VersionLabel1
        '
        Me.VersionLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "Version", True))
        Me.VersionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel1.Location = New System.Drawing.Point(57, 21)
        Me.VersionLabel1.Name = "VersionLabel1"
        Me.VersionLabel1.Size = New System.Drawing.Size(105, 19)
        Me.VersionLabel1.TabIndex = 3
        Me.VersionLabel1.Text = "00.00.0000.0000"
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.AcceptsReturn = True
        Me.DescriptionTextBox.AcceptsTab = True
        Me.DescriptionTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UpdatesBindingSource, "Description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(9, 58)
        Me.DescriptionTextBox.Multiline = True
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.ReadOnly = True
        Me.DescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.DescriptionTextBox.Size = New System.Drawing.Size(315, 112)
        Me.DescriptionTextBox.TabIndex = 1
        '
        'UpdatesDataGridView
        '
        Me.UpdatesDataGridView.AllowUserToAddRows = False
        Me.UpdatesDataGridView.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.UpdatesDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.UpdatesDataGridView.AutoGenerateColumns = False
        Me.UpdatesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.UpdatesDataGridView.BackgroundColor = System.Drawing.Color.White
        Me.UpdatesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UpdatesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.UpdatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.UpdatesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.NiveauDisplay, Me.DataGridViewTextBoxColumn8})
        Me.UpdatesDataGridView.DataSource = Me.UpdatesBindingSource
        Me.UpdatesDataGridView.Location = New System.Drawing.Point(12, 46)
        Me.UpdatesDataGridView.Name = "UpdatesDataGridView"
        Me.UpdatesDataGridView.ReadOnly = True
        Me.UpdatesDataGridView.RowHeadersVisible = False
        Me.UpdatesDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue
        Me.UpdatesDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.UpdatesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.UpdatesDataGridView.Size = New System.Drawing.Size(330, 76)
        Me.UpdatesDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Version"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn3.HeaderText = "Version"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'NiveauDisplay
        '
        Me.NiveauDisplay.DataPropertyName = "NiveauDisplay"
        Me.NiveauDisplay.HeaderText = "Niveau"
        Me.NiveauDisplay.Name = "NiveauDisplay"
        Me.NiveauDisplay.ReadOnly = True
        Me.NiveauDisplay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "DateFichier"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.HeaderText = "DateFichier"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'pbLoading
        '
        Me.pbLoading.Image = CType(resources.GetObject("pbLoading.Image"), System.Drawing.Image)
        Me.pbLoading.Location = New System.Drawing.Point(12, 8)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(32, 32)
        Me.pbLoading.TabIndex = 1
        Me.pbLoading.TabStop = False
        '
        'lbStatus
        '
        Me.lbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbStatus.Location = New System.Drawing.Point(50, 9)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(295, 32)
        Me.lbStatus.TabIndex = 0
        Me.lbStatus.Text = "lbStatus"
        Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtInstall)
        Me.GradientPanel2.Controls.Add(Me.CloseButton)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 310)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(353, 45)
        Me.GradientPanel2.TabIndex = 17
        '
        'BtInstall
        '
        Me.BtInstall.Location = New System.Drawing.Point(191, 10)
        Me.BtInstall.Name = "BtInstall"
        Me.BtInstall.Size = New System.Drawing.Size(75, 23)
        Me.BtInstall.TabIndex = 3
        Me.BtInstall.Text = "Installer"
        Me.BtInstall.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(272, 10)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(69, 23)
        Me.CloseButton.TabIndex = 2
        Me.CloseButton.Text = "Fermer"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Version"
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "Version"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 109
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Niveau"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Niveau"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 110
        '
        'FrUpdates
        '
        Me.AcceptButton = Me.CloseButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 355)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrUpdates"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Mises à jour logicielles"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.UpdatesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUpdates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpdatesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents lbStatus As System.Windows.Forms.Label
    Friend WithEvents pbLoading As System.Windows.Forms.PictureBox
    Friend WithEvents UpdatesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents UpdatesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsUpdates As AgrigestEDI.ActiUpdates.dsUpdates
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DateFichierLabel1 As System.Windows.Forms.Label
    Friend WithEvents NiveauLabel1 As System.Windows.Forms.Label
    Friend WithEvents VersionLabel1 As System.Windows.Forms.Label
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TailleFichierLabel1 As System.Windows.Forms.Label
    Friend WithEvents BtInstall As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NiveauDisplay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

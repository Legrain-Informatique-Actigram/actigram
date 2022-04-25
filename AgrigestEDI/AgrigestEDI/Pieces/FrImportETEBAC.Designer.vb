<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrImportETEBAC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.RestDlg = New System.Windows.Forms.OpenFileDialog
        Me.ErrorDlg = New System.Windows.Forms.SaveFileDialog
        Me.JournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dbJournal = New AgrigestEDI.dbDonneesDataSet
        Me.JournalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
        Me.ComptesTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
        Me.TVATableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.TVATableAdapter
        Me.PlanTypeTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
        Me.dsImport = New AgrigestEDI.dbDonneesDataSet
        Me.PlanComptableTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.cboJournal = New System.Windows.Forms.ListBox
        Me.PanProgress = New System.Windows.Forms.Panel
        Me.lbStatus = New System.Windows.Forms.TextBox
        Me.pgBar = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtBrowse = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxNomFichier = New System.Windows.Forms.TextBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtImporter = New System.Windows.Forms.Button
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsImport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.PanProgress.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RestDlg
        '
        Me.RestDlg.DefaultExt = "afb"
        Me.RestDlg.Filter = "Fichiers AFB ou RIB (*.afb;*.rib)| *.afb;*.rib|Tous les fichiers (*.*)|*.*"
        '
        'ErrorDlg
        '
        Me.ErrorDlg.DefaultExt = "xml"
        Me.ErrorDlg.Filter = "Fichiers XML (*.xml)|*.xml"
        '
        'JournalBindingSource
        '
        Me.JournalBindingSource.DataMember = "Journal"
        Me.JournalBindingSource.DataSource = Me.dbJournal
        '
        'dbJournal
        '
        Me.dbJournal.DataSetName = "dbJournal"
        Me.dbJournal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'JournalTableAdapter
        '
        Me.JournalTableAdapter.ClearBeforeFill = True
        '
        'ComptesTableAdapter
        '
        Me.ComptesTableAdapter.ClearBeforeFill = True
        '
        'TVATableAdapter
        '
        Me.TVATableAdapter.ClearBeforeFill = True
        '
        'PlanTypeTableAdapter
        '
        Me.PlanTypeTableAdapter.ClearBeforeFill = True
        '
        'dsImport
        '
        Me.dsImport.DataSetName = "dsImport"
        Me.dsImport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PlanComptableTableAdapter
        '
        Me.PlanComptableTableAdapter.ClearBeforeFill = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.cboJournal)
        Me.GradientPanel1.Controls.Add(Me.PanProgress)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.BtBrowse)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.TxNomFichier)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(320, 235)
        Me.GradientPanel1.TabIndex = 29
        '
        'cboJournal
        '
        Me.cboJournal.DataSource = Me.JournalBindingSource
        Me.cboJournal.DisplayMember = "JournalDisplay"
        Me.cboJournal.FormattingEnabled = True
        Me.cboJournal.Location = New System.Drawing.Point(17, 90)
        Me.cboJournal.Name = "cboJournal"
        Me.cboJournal.Size = New System.Drawing.Size(289, 134)
        Me.cboJournal.TabIndex = 35
        Me.cboJournal.ValueMember = "JCodeJournal"
        '
        'PanProgress
        '
        Me.PanProgress.Controls.Add(Me.lbStatus)
        Me.PanProgress.Controls.Add(Me.pgBar)
        Me.PanProgress.Location = New System.Drawing.Point(58, 129)
        Me.PanProgress.Name = "PanProgress"
        Me.PanProgress.Size = New System.Drawing.Size(128, 56)
        Me.PanProgress.TabIndex = 29
        Me.PanProgress.Visible = False
        '
        'lbStatus
        '
        Me.lbStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbStatus.BackColor = System.Drawing.Color.White
        Me.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbStatus.Enabled = False
        Me.lbStatus.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lbStatus.Location = New System.Drawing.Point(5, 40)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(104, 13)
        Me.lbStatus.TabIndex = 6
        Me.lbStatus.Text = "lbStatus"
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.Location = New System.Drawing.Point(5, 12)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(112, 22)
        Me.pgBar.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Veuillez sélectionner un journal dans la liste :"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Emplacement du fichier à importer :"
        '
        'BtBrowse
        '
        Me.BtBrowse.Image = Global.AgrigestEDI.My.Resources.Resources.open
        Me.BtBrowse.Location = New System.Drawing.Point(275, 35)
        Me.BtBrowse.Name = "BtBrowse"
        Me.BtBrowse.Size = New System.Drawing.Size(31, 23)
        Me.BtBrowse.TabIndex = 30
        Me.BtBrowse.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Fichier :"
        '
        'TxNomFichier
        '
        Me.TxNomFichier.Location = New System.Drawing.Point(58, 38)
        Me.TxNomFichier.Name = "TxNomFichier"
        Me.TxNomFichier.Size = New System.Drawing.Size(211, 20)
        Me.TxNomFichier.TabIndex = 32
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtAnnuler)
        Me.GradientPanel2.Controls.Add(Me.BtImporter)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 235)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(320, 42)
        Me.GradientPanel2.TabIndex = 4
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(233, 7)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 3
        Me.BtAnnuler.Text = "Annuler"
        '
        'BtImporter
        '
        Me.BtImporter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtImporter.Location = New System.Drawing.Point(153, 7)
        Me.BtImporter.Name = "BtImporter"
        Me.BtImporter.Size = New System.Drawing.Size(75, 23)
        Me.BtImporter.TabIndex = 0
        Me.BtImporter.Text = "Importer"
        '
        'FrImportETEBAC
        '
        Me.AcceptButton = Me.BtImporter
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(320, 277)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrImportETEBAC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importation des relevés bancaires"
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbJournal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsImport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.PanProgress.ResumeLayout(False)
        Me.PanProgress.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RestDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ErrorDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents JournalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dbJournal As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents JournalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
    Friend WithEvents ComptesTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.ComptesTableAdapter
    Friend WithEvents TVATableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.TVATableAdapter
    Friend WithEvents PlanTypeTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanTypeTableAdapter
    Friend WithEvents dsImport As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents PlanComptableTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.PlanComptableTableAdapter
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents cboJournal As System.Windows.Forms.ListBox
    Friend WithEvents PanProgress As System.Windows.Forms.Panel
    Friend WithEvents lbStatus As System.Windows.Forms.TextBox
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtBrowse As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxNomFichier As System.Windows.Forms.TextBox
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtImporter As System.Windows.Forms.Button

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrSearchJournal
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
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.JournalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dbJournal = New AgrigestEDI.dbDonneesDataSet
        Me.JournalTableAdapter = New AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
        Me.Label2 = New System.Windows.Forms.Label
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.cboJournal = New System.Windows.Forms.ListBox
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.gpbDate = New System.Windows.Forms.GroupBox
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker
        Me.lblDate2 = New System.Windows.Forms.Label
        Me.lblDate1 = New System.Windows.Forms.Label
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        Me.gpbDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(148, 10)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(221, 10)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
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
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Veuillez sélectionner un journal dans la liste :"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.gpbDate)
        Me.GradientPanel1.Controls.Add(Me.cboJournal)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(300, 226)
        Me.GradientPanel1.TabIndex = 14
        '
        'cboJournal
        '
        Me.cboJournal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cboJournal.DataSource = Me.JournalBindingSource
        Me.cboJournal.DisplayMember = "JournalDisplay"
        Me.cboJournal.FormattingEnabled = True
        Me.cboJournal.Location = New System.Drawing.Point(10, 78)
        Me.cboJournal.Name = "cboJournal"
        Me.cboJournal.Size = New System.Drawing.Size(282, 134)
        Me.cboJournal.TabIndex = 4
        Me.cboJournal.ValueMember = "JCodeJournal"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.Cancel_Button)
        Me.GradientPanel2.Controls.Add(Me.OK_Button)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 226)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(300, 45)
        Me.GradientPanel2.TabIndex = 15
        '
        'gpbDate
        '
        Me.gpbDate.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.gpbDate.Controls.Add(Me.dtpDateEnd)
        Me.gpbDate.Controls.Add(Me.lblDate2)
        Me.gpbDate.Controls.Add(Me.lblDate1)
        Me.gpbDate.Controls.Add(Me.dtpDateStart)
        Me.gpbDate.Location = New System.Drawing.Point(9, 6)
        Me.gpbDate.Name = "gpbDate"
        Me.gpbDate.Size = New System.Drawing.Size(283, 51)
        Me.gpbDate.TabIndex = 5
        Me.gpbDate.TabStop = False
        Me.gpbDate.Text = "Pièces dont la date est comprise"
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateEnd.Location = New System.Drawing.Point(191, 19)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(85, 20)
        Me.dtpDateEnd.TabIndex = 3
        '
        'lblDate2
        '
        Me.lblDate2.AutoSize = True
        Me.lblDate2.Location = New System.Drawing.Point(152, 23)
        Me.lblDate2.Name = "lblDate2"
        Me.lblDate2.Size = New System.Drawing.Size(33, 13)
        Me.lblDate2.TabIndex = 2
        Me.lblDate2.Text = "et le :"
        '
        'lblDate1
        '
        Me.lblDate1.AutoSize = True
        Me.lblDate1.Location = New System.Drawing.Point(6, 23)
        Me.lblDate1.Name = "lblDate1"
        Me.lblDate1.Size = New System.Drawing.Size(48, 13)
        Me.lblDate1.TabIndex = 0
        Me.lblDate1.Text = "entre le :"
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStart.Location = New System.Drawing.Point(61, 19)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(85, 20)
        Me.dtpDateStart.TabIndex = 1
        '
        'FrSearchJournal
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(300, 271)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrSearchJournal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choix des dates et du journal"
        CType(Me.JournalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbJournal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        Me.gpbDate.ResumeLayout(False)
        Me.gpbDate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents dbJournal As AgrigestEDI.dbDonneesDataSet
    Friend WithEvents JournalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents JournalTableAdapter As AgrigestEDI.dbDonneesDataSetTableAdapters.JournalTableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents cboJournal As System.Windows.Forms.ListBox
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents gpbDate As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate2 As System.Windows.Forms.Label
    Friend WithEvents lblDate1 As System.Windows.Forms.Label
    Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker

End Class

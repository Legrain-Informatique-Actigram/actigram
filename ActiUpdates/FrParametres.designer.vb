<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrParametres
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
        Dim ConnectionStringBuilderWrapper3 As ActiUpdates.ConnectionStringBuilderWrapper = New ActiUpdates.ConnectionStringBuilderWrapper
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SqlConnectionConfig = New ActiUpdates.SqlConnectionConfig
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TxRepFiles = New System.Windows.Forms.TextBox
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SqlConnectionConfig)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 165)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paramètres de connexion"
        '
        'SqlConnectionConfig
        '
        ConnectionStringBuilderWrapper3.ConnectionString = "Integrated Security=True"
        ConnectionStringBuilderWrapper3.Database = ""
        ConnectionStringBuilderWrapper3.Login = ""
        ConnectionStringBuilderWrapper3.Password = ""
        ConnectionStringBuilderWrapper3.Server = ""
        Me.SqlConnectionConfig.ConnectionStringBuilder = ConnectionStringBuilderWrapper3
        Me.SqlConnectionConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SqlConnectionConfig.Location = New System.Drawing.Point(3, 16)
        Me.SqlConnectionConfig.Name = "SqlConnectionConfig"
        Me.SqlConnectionConfig.Size = New System.Drawing.Size(383, 146)
        Me.SqlConnectionConfig.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(417, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProduitBindingNavigatorSaveItem
        '
        Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProduitBindingNavigatorSaveItem.Image = Global.ActiUpdates.My.Resources.Resources.save
        Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
        Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Emplacement des mises à jour :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Adresse du site de mise à jour:"
        '
        'TextBox2
        '
        Me.TextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ActiUpdates.My.MySettings.Default, "URL_Update", True))
        Me.TextBox2.Location = New System.Drawing.Point(174, 229)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(231, 20)
        Me.TextBox2.TabIndex = 4
        Me.TextBox2.Text = Global.ActiUpdates.My.MySettings.Default.URL_Update
        '
        'TxRepFiles
        '
        Me.TxRepFiles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TxRepFiles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.TxRepFiles.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.ActiUpdates.My.MySettings.Default, "RepFiles", True))
        Me.TxRepFiles.Location = New System.Drawing.Point(174, 203)
        Me.TxRepFiles.Name = "TxRepFiles"
        Me.TxRepFiles.Size = New System.Drawing.Size(231, 20)
        Me.TxRepFiles.TabIndex = 2
        Me.TxRepFiles.Text = Global.ActiUpdates.My.MySettings.Default.RepFiles
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(Global.ActiUpdates.My.MySettings)
        '
        'FrParametres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(417, 261)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxRepFiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrParametres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paramètres"
        Me.GroupBox1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProduitBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SqlConnectionConfig As SqlConnectionConfig
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxRepFiles As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
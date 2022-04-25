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
        Dim ConnectionStringBuilderWrapper2 As ContactsAgrifact.ConnectionStringBuilderWrapper = New ContactsAgrifact.ConnectionStringBuilderWrapper
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SqlConnectionConfig = New ContactsAgrifact.SqlConnectionConfig
        Me.TbFermer = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ProduitBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
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
        ConnectionStringBuilderWrapper2.ConnectionString = "Integrated Security=True"
        ConnectionStringBuilderWrapper2.Database = ""
        ConnectionStringBuilderWrapper2.Login = ""
        ConnectionStringBuilderWrapper2.Password = ""
        ConnectionStringBuilderWrapper2.Server = ""
        Me.SqlConnectionConfig.ConnectionStringBuilder = ConnectionStringBuilderWrapper2
        Me.SqlConnectionConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SqlConnectionConfig.Location = New System.Drawing.Point(3, 16)
        Me.SqlConnectionConfig.Name = "SqlConnectionConfig"
        Me.SqlConnectionConfig.Size = New System.Drawing.Size(383, 146)
        Me.SqlConnectionConfig.TabIndex = 0
        '
        'TbFermer
        '
        Me.TbFermer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TbFermer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TbFermer.Image = Global.ContactsAgrifact.My.Resources.Resources.close
        Me.TbFermer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TbFermer.Name = "TbFermer"
        Me.TbFermer.Size = New System.Drawing.Size(23, 22)
        Me.TbFermer.Text = "Fermer"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProduitBindingNavigatorSaveItem, Me.TbFermer})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(417, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ProduitBindingNavigatorSaveItem
        '
        Me.ProduitBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProduitBindingNavigatorSaveItem.Image = Global.ContactsAgrifact.My.Resources.Resources.save
        Me.ProduitBindingNavigatorSaveItem.Name = "ProduitBindingNavigatorSaveItem"
        Me.ProduitBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProduitBindingNavigatorSaveItem.Text = "Enregistrer les données"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'FrParametres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(417, 211)
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
    Friend WithEvents TbFermer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SqlConnectionConfig As ContactsAgrifact.SqlConnectionConfig
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
End Class
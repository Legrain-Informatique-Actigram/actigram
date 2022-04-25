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
        Dim ConnectionStringBuilderWrapper1 As Utilitaire.ConnectionStringBuilderWrapper = New Utilitaire.ConnectionStringBuilderWrapper
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SqlConnectionConfig = New Utilitaire.SqlConnectionConfig
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.SqlConnectionConfig)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(285, 165)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paramètres de connexion"
        '
        'SqlConnectionConfig
        '
        ConnectionStringBuilderWrapper1.ConnectionString = "Integrated Security=True"
        ConnectionStringBuilderWrapper1.Database = ""
        ConnectionStringBuilderWrapper1.Login = ""
        ConnectionStringBuilderWrapper1.Password = ""
        ConnectionStringBuilderWrapper1.Server = ""
        Me.SqlConnectionConfig.ConnectionStringBuilder = ConnectionStringBuilderWrapper1
        Me.SqlConnectionConfig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SqlConnectionConfig.Location = New System.Drawing.Point(3, 16)
        Me.SqlConnectionConfig.Name = "SqlConnectionConfig"
        Me.SqlConnectionConfig.Size = New System.Drawing.Size(279, 146)
        Me.SqlConnectionConfig.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(139, 188)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 1
        Me.BtOK.Text = "OK"
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(220, 188)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 2
        Me.BtCancel.Text = "Annuler"
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'FrParametres
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(307, 223)
        Me.Controls.Add(Me.BtCancel)
        Me.Controls.Add(Me.BtOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrParametres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paramètres"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SqlConnectionConfig As Utilitaire.SqlConnectionConfig
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SqlConnectionConfig
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
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
        Dim ServerLabel As System.Windows.Forms.Label
        Dim DatabaseLabel As System.Windows.Forms.Label
        Dim LoginLabel As System.Windows.Forms.Label
        Dim PasswordLabel As System.Windows.Forms.Label
        Me.ConnectionStringBuilderWrapperBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ServerComboBox = New System.Windows.Forms.ComboBox
        Me.DatabaseComboBox = New System.Windows.Forms.ComboBox
        Me.LoginTextBox = New System.Windows.Forms.TextBox
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.BtTest = New System.Windows.Forms.Button
        ServerLabel = New System.Windows.Forms.Label
        DatabaseLabel = New System.Windows.Forms.Label
        LoginLabel = New System.Windows.Forms.Label
        PasswordLabel = New System.Windows.Forms.Label
        CType(Me.ConnectionStringBuilderWrapperBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ServerLabel
        '
        ServerLabel.AutoSize = True
        ServerLabel.Location = New System.Drawing.Point(3, 9)
        ServerLabel.Name = "ServerLabel"
        ServerLabel.Size = New System.Drawing.Size(47, 13)
        ServerLabel.TabIndex = 0
        ServerLabel.Text = "Serveur:"
        '
        'DatabaseLabel
        '
        DatabaseLabel.AutoSize = True
        DatabaseLabel.Location = New System.Drawing.Point(3, 88)
        DatabaseLabel.Name = "DatabaseLabel"
        DatabaseLabel.Size = New System.Drawing.Size(34, 13)
        DatabaseLabel.TabIndex = 6
        DatabaseLabel.Text = "Base:"
        '
        'LoginLabel
        '
        LoginLabel.AutoSize = True
        LoginLabel.Location = New System.Drawing.Point(3, 36)
        LoginLabel.Name = "LoginLabel"
        LoginLabel.Size = New System.Drawing.Size(56, 13)
        LoginLabel.TabIndex = 2
        LoginLabel.Text = "Identifiant:"
        '
        'PasswordLabel
        '
        PasswordLabel.AutoSize = True
        PasswordLabel.Location = New System.Drawing.Point(3, 62)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New System.Drawing.Size(74, 13)
        PasswordLabel.TabIndex = 4
        PasswordLabel.Text = "Mot de passe:"
        '
        'ConnectionStringBuilderWrapperBindingSource
        '
        Me.ConnectionStringBuilderWrapperBindingSource.DataSource = GetType(Utilitaires.ConnectionStringBuilderWrapper)
        '
        'ServerComboBox
        '
        Me.ServerComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ServerComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ConnectionStringBuilderWrapperBindingSource, "Server", True))
        Me.ServerComboBox.FormattingEnabled = True
        Me.ServerComboBox.Location = New System.Drawing.Point(83, 6)
        Me.ServerComboBox.MaxLength = 50
        Me.ServerComboBox.Name = "ServerComboBox"
        Me.ServerComboBox.Size = New System.Drawing.Size(162, 21)
        Me.ServerComboBox.TabIndex = 1
        Me.ServerComboBox.Text = "serveur"
        '
        'DatabaseComboBox
        '
        Me.DatabaseComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DatabaseComboBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ConnectionStringBuilderWrapperBindingSource, "Database", True))
        Me.DatabaseComboBox.FormattingEnabled = True
        Me.DatabaseComboBox.Location = New System.Drawing.Point(83, 85)
        Me.DatabaseComboBox.MaxLength = 50
        Me.DatabaseComboBox.Name = "DatabaseComboBox"
        Me.DatabaseComboBox.Size = New System.Drawing.Size(162, 21)
        Me.DatabaseComboBox.TabIndex = 7
        Me.DatabaseComboBox.Text = "base"
        '
        'LoginTextBox
        '
        Me.LoginTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoginTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ConnectionStringBuilderWrapperBindingSource, "Login", True))
        Me.LoginTextBox.Location = New System.Drawing.Point(83, 33)
        Me.LoginTextBox.MaxLength = 50
        Me.LoginTextBox.Name = "LoginTextBox"
        Me.LoginTextBox.Size = New System.Drawing.Size(162, 20)
        Me.LoginTextBox.TabIndex = 3
        Me.LoginTextBox.Text = "login"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ConnectionStringBuilderWrapperBindingSource, "Password", True))
        Me.PasswordTextBox.Location = New System.Drawing.Point(83, 59)
        Me.PasswordTextBox.MaxLength = 50
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.Size = New System.Drawing.Size(162, 20)
        Me.PasswordTextBox.TabIndex = 5
        Me.PasswordTextBox.Text = "password"
        Me.PasswordTextBox.UseSystemPasswordChar = True
        '
        'BtTest
        '
        Me.BtTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtTest.Location = New System.Drawing.Point(170, 112)
        Me.BtTest.Name = "BtTest"
        Me.BtTest.Size = New System.Drawing.Size(75, 23)
        Me.BtTest.TabIndex = 8
        Me.BtTest.Text = "Tester"
        Me.BtTest.UseVisualStyleBackColor = True
        '
        'SqlConnectionConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtTest)
        Me.Controls.Add(PasswordLabel)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(LoginLabel)
        Me.Controls.Add(Me.LoginTextBox)
        Me.Controls.Add(DatabaseLabel)
        Me.Controls.Add(Me.DatabaseComboBox)
        Me.Controls.Add(ServerLabel)
        Me.Controls.Add(Me.ServerComboBox)
        Me.Name = "SqlConnectionConfig"
        Me.Size = New System.Drawing.Size(254, 144)
        CType(Me.ConnectionStringBuilderWrapperBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ConnectionStringBuilderWrapperBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents DatabaseComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LoginTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BtTest As System.Windows.Forms.Button

End Class

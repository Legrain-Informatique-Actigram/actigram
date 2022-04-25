<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FrSplash
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer
    Private mainMenu1 As System.Windows.Forms.MainMenu

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.LbTitle = New System.Windows.Forms.Label
        Me.LbDescription = New System.Windows.Forms.Label
        Me.LbCopyright = New System.Windows.Forms.Label
        Me.LbVersion = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LbServeur = New System.Windows.Forms.Label
        Me.BtAction = New System.Windows.Forms.Button
        Me.BtQuitter = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.BtDebug = New System.Windows.Forms.Button
        Me.TxLog = New System.Windows.Forms.TextBox
        Me.LnkShowDetails = New System.Windows.Forms.LinkLabel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbTitle
        '
        Me.LbTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LbTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LbTitle.ForeColor = System.Drawing.Color.Brown
        Me.LbTitle.Location = New System.Drawing.Point(0, 0)
        Me.LbTitle.Name = "LbTitle"
        Me.LbTitle.Size = New System.Drawing.Size(240, 20)
        Me.LbTitle.Text = "LbTitle"
        Me.LbTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LbDescription
        '
        Me.LbDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.LbDescription.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LbDescription.Location = New System.Drawing.Point(0, 20)
        Me.LbDescription.Name = "LbDescription"
        Me.LbDescription.Size = New System.Drawing.Size(240, 20)
        Me.LbDescription.Text = "LbDescription"
        Me.LbDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LbCopyright
        '
        Me.LbCopyright.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Italic)
        Me.LbCopyright.Location = New System.Drawing.Point(3, 53)
        Me.LbCopyright.Name = "LbCopyright"
        Me.LbCopyright.Size = New System.Drawing.Size(230, 17)
        Me.LbCopyright.Text = "LbCopyright"
        Me.LbCopyright.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LbVersion
        '
        Me.LbVersion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.LbVersion.Location = New System.Drawing.Point(4, 69)
        Me.LbVersion.Name = "LbVersion"
        Me.LbVersion.Size = New System.Drawing.Size(230, 20)
        Me.LbVersion.Text = "LbVersion"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.LbDescription)
        Me.Panel1.Controls.Add(Me.LbTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 50)
        '
        'LbServeur
        '
        Me.LbServeur.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.LbServeur.Location = New System.Drawing.Point(4, 89)
        Me.LbServeur.Name = "LbServeur"
        Me.LbServeur.Size = New System.Drawing.Size(230, 21)
        Me.LbServeur.Text = "LbServeur"
        '
        'BtAction
        '
        Me.BtAction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAction.Location = New System.Drawing.Point(4, 10)
        Me.BtAction.Name = "BtAction"
        Me.BtAction.Size = New System.Drawing.Size(88, 19)
        Me.BtAction.TabIndex = 7
        Me.BtAction.Text = "..."
        '
        'BtQuitter
        '
        Me.BtQuitter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtQuitter.Location = New System.Drawing.Point(98, 10)
        Me.BtQuitter.Name = "BtQuitter"
        Me.BtQuitter.Size = New System.Drawing.Size(86, 19)
        Me.BtQuitter.TabIndex = 13
        Me.BtQuitter.Text = "Quitter"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.BtDebug)
        Me.Panel2.Controls.Add(Me.BtAction)
        Me.Panel2.Controls.Add(Me.BtQuitter)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(240, 38)
        '
        'BtDebug
        '
        Me.BtDebug.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtDebug.Location = New System.Drawing.Point(190, 10)
        Me.BtDebug.Name = "BtDebug"
        Me.BtDebug.Size = New System.Drawing.Size(44, 19)
        Me.BtDebug.TabIndex = 14
        Me.BtDebug.Text = "dbg"
        Me.BtDebug.Visible = False
        '
        'TxLog
        '
        Me.TxLog.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.TxLog.Location = New System.Drawing.Point(3, 134)
        Me.TxLog.Multiline = True
        Me.TxLog.Name = "TxLog"
        Me.TxLog.ReadOnly = True
        Me.TxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxLog.Size = New System.Drawing.Size(234, 116)
        Me.TxLog.TabIndex = 19
        Me.TxLog.Text = "TxLog"
        Me.TxLog.WordWrap = False
        '
        'LnkShowDetails
        '
        Me.LnkShowDetails.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Underline)
        Me.LnkShowDetails.Location = New System.Drawing.Point(4, 110)
        Me.LnkShowDetails.Name = "LnkShowDetails"
        Me.LnkShowDetails.Size = New System.Drawing.Size(100, 21)
        Me.LnkShowDetails.TabIndex = 20
        Me.LnkShowDetails.Text = "Afficher les détails"
        '
        'FrSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.LnkShowDetails)
        Me.Controls.Add(Me.TxLog)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LbServeur)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LbVersion)
        Me.Controls.Add(Me.LbCopyright)
        Me.Name = "FrSplash"
        Me.Text = "Agrifact"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LbTitle As System.Windows.Forms.Label
    Friend WithEvents LbDescription As System.Windows.Forms.Label
    Friend WithEvents LbCopyright As System.Windows.Forms.Label
    Friend WithEvents LbVersion As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LbServeur As System.Windows.Forms.Label
    Friend WithEvents BtAction As System.Windows.Forms.Button
    Friend WithEvents BtQuitter As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxLog As System.Windows.Forms.TextBox
    Friend WithEvents LnkShowDetails As System.Windows.Forms.LinkLabel
    Friend WithEvents BtDebug As System.Windows.Forms.Button
End Class

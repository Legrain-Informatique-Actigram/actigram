<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrMain
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxDir = New System.Windows.Forms.TextBox()
        Me.BtZipFile = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxCle = New System.Windows.Forms.TextBox()
        Me.BtAideCle = New System.Windows.Forms.Button()
        Me.BtZipDir = New System.Windows.Forms.Button()
        Me.BtBrowseDir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dossier :"
        '
        'TxDir
        '
        Me.TxDir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxDir.Location = New System.Drawing.Point(66, 12)
        Me.TxDir.Name = "TxDir"
        Me.TxDir.Size = New System.Drawing.Size(244, 20)
        Me.TxDir.TabIndex = 1
        '
        'BtZipFile
        '
        Me.BtZipFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtZipFile.Location = New System.Drawing.Point(66, 65)
        Me.BtZipFile.Name = "BtZipFile"
        Me.BtZipFile.Size = New System.Drawing.Size(107, 23)
        Me.BtZipFile.TabIndex = 4
        Me.BtZipFile.Text = "Zipper un fichier..."
        Me.BtZipFile.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Clé :"
        '
        'TxCle
        '
        Me.TxCle.Location = New System.Drawing.Point(66, 38)
        Me.TxCle.Name = "TxCle"
        Me.TxCle.ReadOnly = True
        Me.TxCle.Size = New System.Drawing.Size(244, 20)
        Me.TxCle.TabIndex = 6
        '
        'BtAideCle
        '
        Me.BtAideCle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAideCle.FlatAppearance.BorderSize = 0
        Me.BtAideCle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAideCle.Image = Global.EDIZipper.My.Resources.Resources.aide
        Me.BtAideCle.Location = New System.Drawing.Point(316, 39)
        Me.BtAideCle.Name = "BtAideCle"
        Me.BtAideCle.Size = New System.Drawing.Size(25, 19)
        Me.BtAideCle.TabIndex = 7
        Me.BtAideCle.UseVisualStyleBackColor = True
        '
        'BtZipDir
        '
        Me.BtZipDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtZipDir.Image = Global.EDIZipper.My.Resources.Resources.cloture
        Me.BtZipDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtZipDir.Location = New System.Drawing.Point(276, 65)
        Me.BtZipDir.Name = "BtZipDir"
        Me.BtZipDir.Size = New System.Drawing.Size(75, 23)
        Me.BtZipDir.TabIndex = 3
        Me.BtZipDir.Text = "Zipper"
        Me.BtZipDir.UseVisualStyleBackColor = True
        '
        'BtBrowseDir
        '
        Me.BtBrowseDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtBrowseDir.Image = Global.EDIZipper.My.Resources.Resources.openfolderHS
        Me.BtBrowseDir.Location = New System.Drawing.Point(316, 10)
        Me.BtBrowseDir.Name = "BtBrowseDir"
        Me.BtBrowseDir.Size = New System.Drawing.Size(35, 23)
        Me.BtBrowseDir.TabIndex = 2
        Me.BtBrowseDir.UseVisualStyleBackColor = True
        '
        'FrMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 100)
        Me.Controls.Add(Me.BtAideCle)
        Me.Controls.Add(Me.TxCle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtZipFile)
        Me.Controls.Add(Me.BtZipDir)
        Me.Controls.Add(Me.BtBrowseDir)
        Me.Controls.Add(Me.TxDir)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrMain"
        Me.Text = "EDIZipper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxDir As System.Windows.Forms.TextBox
    Friend WithEvents BtBrowseDir As System.Windows.Forms.Button
    Friend WithEvents BtZipDir As System.Windows.Forms.Button
    Friend WithEvents BtZipFile As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxCle As System.Windows.Forms.TextBox
    Friend WithEvents BtAideCle As System.Windows.Forms.Button

End Class

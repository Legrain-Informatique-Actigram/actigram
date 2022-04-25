<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixColonnes
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
        Me.ChampsPersosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAgrifact = New ContactsAgrifact.DsAgrifact
        Me.chkChamps = New System.Windows.Forms.CheckedListBox
        Me.BtOK = New System.Windows.Forms.Button
        Me.BtAnnuler = New System.Windows.Forms.Button
        CType(Me.ChampsPersosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChampsPersosBindingSource
        '
        Me.ChampsPersosBindingSource.DataMember = "ChampsPersos"
        Me.ChampsPersosBindingSource.DataSource = Me.DsAgrifact
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "DsAgrifact"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkChamps
        '
        Me.chkChamps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkChamps.CheckOnClick = True
        Me.chkChamps.FormattingEnabled = True
        Me.chkChamps.Location = New System.Drawing.Point(12, 12)
        Me.chkChamps.Name = "chkChamps"
        Me.chkChamps.Size = New System.Drawing.Size(268, 214)
        Me.chkChamps.TabIndex = 0
        '
        'BtOK
        '
        Me.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtOK.Location = New System.Drawing.Point(124, 231)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 1
        Me.BtOK.Text = "OK"
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'BtAnnuler
        '
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(205, 231)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 2
        Me.BtAnnuler.Text = "Annuler"
        Me.BtAnnuler.UseVisualStyleBackColor = True
        '
        'FrChoixColonnes
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtOK)
        Me.Controls.Add(Me.chkChamps)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrChoixColonnes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choisir les champs à afficher"
        CType(Me.ChampsPersosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChampsPersosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsAgrifact As ContactsAgrifact.DsAgrifact
    Friend WithEvents chkChamps As System.Windows.Forms.CheckedListBox
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
End Class

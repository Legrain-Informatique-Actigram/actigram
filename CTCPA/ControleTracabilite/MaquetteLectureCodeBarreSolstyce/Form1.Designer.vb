<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxCodeBarre = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxResultat = New System.Windows.Forms.TextBox
        Me.BtParams = New System.Windows.Forms.Button
        Me.BtClose = New System.Windows.Forms.Button
        Me.BtAnalyseSimple = New System.Windows.Forms.Button
        Me.BtAnalyseComplete = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code barre : "
        '
        'TxCodeBarre
        '
        Me.TxCodeBarre.Location = New System.Drawing.Point(83, 12)
        Me.TxCodeBarre.MaxLength = 12
        Me.TxCodeBarre.Name = "TxCodeBarre"
        Me.TxCodeBarre.Size = New System.Drawing.Size(81, 20)
        Me.TxCodeBarre.TabIndex = 1
        Me.TxCodeBarre.Text = "000000000000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Résultat :"
        '
        'TxResultat
        '
        Me.TxResultat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxResultat.Location = New System.Drawing.Point(12, 56)
        Me.TxResultat.Multiline = True
        Me.TxResultat.Name = "TxResultat"
        Me.TxResultat.ReadOnly = True
        Me.TxResultat.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxResultat.Size = New System.Drawing.Size(412, 193)
        Me.TxResultat.TabIndex = 5
        Me.TxResultat.WordWrap = False
        '
        'BtParams
        '
        Me.BtParams.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtParams.Location = New System.Drawing.Point(12, 255)
        Me.BtParams.Name = "BtParams"
        Me.BtParams.Size = New System.Drawing.Size(75, 23)
        Me.BtParams.TabIndex = 6
        Me.BtParams.Text = "Paramètres..."
        Me.BtParams.UseVisualStyleBackColor = True
        '
        'BtClose
        '
        Me.BtClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtClose.Location = New System.Drawing.Point(349, 255)
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(75, 23)
        Me.BtClose.TabIndex = 7
        Me.BtClose.Text = "Fermer"
        Me.BtClose.UseVisualStyleBackColor = True
        '
        'BtAnalyseSimple
        '
        Me.BtAnalyseSimple.Location = New System.Drawing.Point(170, 10)
        Me.BtAnalyseSimple.Name = "BtAnalyseSimple"
        Me.BtAnalyseSimple.Size = New System.Drawing.Size(108, 23)
        Me.BtAnalyseSimple.TabIndex = 2
        Me.BtAnalyseSimple.Text = "Analyse simple"
        Me.BtAnalyseSimple.UseVisualStyleBackColor = True
        '
        'BtAnalyseComplete
        '
        Me.BtAnalyseComplete.Location = New System.Drawing.Point(284, 10)
        Me.BtAnalyseComplete.Name = "BtAnalyseComplete"
        Me.BtAnalyseComplete.Size = New System.Drawing.Size(102, 23)
        Me.BtAnalyseComplete.TabIndex = 3
        Me.BtAnalyseComplete.Text = "Analyse complète"
        Me.BtAnalyseComplete.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 290)
        Me.Controls.Add(Me.BtAnalyseComplete)
        Me.Controls.Add(Me.BtAnalyseSimple)
        Me.Controls.Add(Me.BtClose)
        Me.Controls.Add(Me.BtParams)
        Me.Controls.Add(Me.TxResultat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxCodeBarre)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maquette lecture code barre Solstyce"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxCodeBarre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxResultat As System.Windows.Forms.TextBox
    Friend WithEvents BtParams As System.Windows.Forms.Button
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents BtAnalyseSimple As System.Windows.Forms.Button
    Friend WithEvents BtAnalyseComplete As System.Windows.Forms.Button

End Class

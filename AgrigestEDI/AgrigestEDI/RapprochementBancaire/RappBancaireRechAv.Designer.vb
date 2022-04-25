<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RappBancaireRechAv
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.dateTimePickerDateDebEcr = New System.Windows.Forms.DateTimePicker
        Me.dateTimePickerDateFinEcr = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.textBoxMontantFin = New System.Windows.Forms.TextBox
        Me.textBoxMontantDeb = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.textBoxNumPiece = New System.Windows.Forms.TextBox
        Me.textBoxLibelle = New System.Windows.Forms.TextBox
        Me.buttonRechercher = New System.Windows.Forms.Button
        Me.checkBoxDateEcr = New System.Windows.Forms.CheckBox
        Me.checkBoxMontant = New System.Windows.Forms.CheckBox
        Me.checkBoxNumPiece = New System.Windows.Forms.CheckBox
        Me.checkBoxLibelle = New System.Windows.Forms.CheckBox
        Me.checkBoxMontantD = New System.Windows.Forms.CheckBox
        Me.checkBoxMontantC = New System.Windows.Forms.CheckBox
        Me.buttonAnnuler = New System.Windows.Forms.Button
        Me.radioButtonNonPt = New System.Windows.Forms.RadioButton
        Me.radioButtonPt = New System.Windows.Forms.RadioButton
        Me.radioButtonToutes = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(172, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Du :"
        '
        'dateTimePickerDateDebEcr
        '
        Me.dateTimePickerDateDebEcr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimePickerDateDebEcr.Location = New System.Drawing.Point(205, 7)
        Me.dateTimePickerDateDebEcr.Name = "dateTimePickerDateDebEcr"
        Me.dateTimePickerDateDebEcr.Size = New System.Drawing.Size(98, 20)
        Me.dateTimePickerDateDebEcr.TabIndex = 1
        '
        'dateTimePickerDateFinEcr
        '
        Me.dateTimePickerDateFinEcr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateTimePickerDateFinEcr.Location = New System.Drawing.Point(205, 33)
        Me.dateTimePickerDateFinEcr.Name = "dateTimePickerDateFinEcr"
        Me.dateTimePickerDateFinEcr.Size = New System.Drawing.Size(98, 20)
        Me.dateTimePickerDateFinEcr.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(172, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "au :"
        '
        'textBoxMontantFin
        '
        Me.textBoxMontantFin.Location = New System.Drawing.Point(203, 100)
        Me.textBoxMontantFin.Name = "textBoxMontantFin"
        Me.textBoxMontantFin.Size = New System.Drawing.Size(100, 20)
        Me.textBoxMontantFin.TabIndex = 2
        Me.textBoxMontantFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textBoxMontantDeb
        '
        Me.textBoxMontantDeb.Location = New System.Drawing.Point(203, 74)
        Me.textBoxMontantDeb.Name = "textBoxMontantDeb"
        Me.textBoxMontantDeb.Size = New System.Drawing.Size(100, 20)
        Me.textBoxMontantDeb.TabIndex = 1
        Me.textBoxMontantDeb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(170, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "à :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(170, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "De :"
        '
        'textBoxNumPiece
        '
        Me.textBoxNumPiece.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxNumPiece.Location = New System.Drawing.Point(113, 153)
        Me.textBoxNumPiece.Name = "textBoxNumPiece"
        Me.textBoxNumPiece.Size = New System.Drawing.Size(193, 20)
        Me.textBoxNumPiece.TabIndex = 2
        '
        'textBoxLibelle
        '
        Me.textBoxLibelle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textBoxLibelle.Location = New System.Drawing.Point(113, 179)
        Me.textBoxLibelle.Name = "textBoxLibelle"
        Me.textBoxLibelle.Size = New System.Drawing.Size(193, 20)
        Me.textBoxLibelle.TabIndex = 4
        '
        'buttonRechercher
        '
        Me.buttonRechercher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonRechercher.Location = New System.Drawing.Point(150, 242)
        Me.buttonRechercher.Name = "buttonRechercher"
        Me.buttonRechercher.Size = New System.Drawing.Size(75, 23)
        Me.buttonRechercher.TabIndex = 0
        Me.buttonRechercher.Text = "Rechercher"
        Me.buttonRechercher.UseVisualStyleBackColor = True
        '
        'checkBoxDateEcr
        '
        Me.checkBoxDateEcr.AutoSize = True
        Me.checkBoxDateEcr.Location = New System.Drawing.Point(24, 12)
        Me.checkBoxDateEcr.Name = "checkBoxDateEcr"
        Me.checkBoxDateEcr.Size = New System.Drawing.Size(106, 17)
        Me.checkBoxDateEcr.TabIndex = 11
        Me.checkBoxDateEcr.Text = "Date de l'écriture"
        Me.checkBoxDateEcr.UseVisualStyleBackColor = True
        '
        'checkBoxMontant
        '
        Me.checkBoxMontant.AutoSize = True
        Me.checkBoxMontant.Location = New System.Drawing.Point(24, 61)
        Me.checkBoxMontant.Name = "checkBoxMontant"
        Me.checkBoxMontant.Size = New System.Drawing.Size(65, 17)
        Me.checkBoxMontant.TabIndex = 12
        Me.checkBoxMontant.Text = "Montant"
        Me.checkBoxMontant.UseVisualStyleBackColor = True
        '
        'checkBoxNumPiece
        '
        Me.checkBoxNumPiece.AutoSize = True
        Me.checkBoxNumPiece.Location = New System.Drawing.Point(24, 156)
        Me.checkBoxNumPiece.Name = "checkBoxNumPiece"
        Me.checkBoxNumPiece.Size = New System.Drawing.Size(88, 17)
        Me.checkBoxNumPiece.TabIndex = 13
        Me.checkBoxNumPiece.Text = "N° de pièce :"
        Me.checkBoxNumPiece.UseVisualStyleBackColor = True
        '
        'checkBoxLibelle
        '
        Me.checkBoxLibelle.AutoSize = True
        Me.checkBoxLibelle.Location = New System.Drawing.Point(24, 182)
        Me.checkBoxLibelle.Name = "checkBoxLibelle"
        Me.checkBoxLibelle.Size = New System.Drawing.Size(62, 17)
        Me.checkBoxLibelle.TabIndex = 14
        Me.checkBoxLibelle.Text = "Libellé :"
        Me.checkBoxLibelle.UseVisualStyleBackColor = True
        '
        'checkBoxMontantD
        '
        Me.checkBoxMontantD.AutoSize = True
        Me.checkBoxMontantD.Location = New System.Drawing.Point(85, 76)
        Me.checkBoxMontantD.Name = "checkBoxMontantD"
        Me.checkBoxMontantD.Size = New System.Drawing.Size(51, 17)
        Me.checkBoxMontantD.TabIndex = 15
        Me.checkBoxMontantD.Text = "Débit"
        Me.checkBoxMontantD.UseVisualStyleBackColor = True
        '
        'checkBoxMontantC
        '
        Me.checkBoxMontantC.AutoSize = True
        Me.checkBoxMontantC.Location = New System.Drawing.Point(85, 102)
        Me.checkBoxMontantC.Name = "checkBoxMontantC"
        Me.checkBoxMontantC.Size = New System.Drawing.Size(53, 17)
        Me.checkBoxMontantC.TabIndex = 16
        Me.checkBoxMontantC.Text = "Crédit"
        Me.checkBoxMontantC.UseVisualStyleBackColor = True
        '
        'buttonAnnuler
        '
        Me.buttonAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonAnnuler.Location = New System.Drawing.Point(231, 242)
        Me.buttonAnnuler.Name = "buttonAnnuler"
        Me.buttonAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.buttonAnnuler.TabIndex = 17
        Me.buttonAnnuler.Text = "Annuler"
        Me.buttonAnnuler.UseVisualStyleBackColor = True
        '
        'radioButtonNonPt
        '
        Me.radioButtonNonPt.AutoSize = True
        Me.radioButtonNonPt.Checked = True
        Me.radioButtonNonPt.Location = New System.Drawing.Point(3, 7)
        Me.radioButtonNonPt.Name = "radioButtonNonPt"
        Me.radioButtonNonPt.Size = New System.Drawing.Size(88, 17)
        Me.radioButtonNonPt.TabIndex = 21
        Me.radioButtonNonPt.TabStop = True
        Me.radioButtonNonPt.Text = "Non pointées"
        Me.radioButtonNonPt.UseVisualStyleBackColor = True
        '
        'radioButtonPt
        '
        Me.radioButtonPt.AutoSize = True
        Me.radioButtonPt.Location = New System.Drawing.Point(110, 7)
        Me.radioButtonPt.Name = "radioButtonPt"
        Me.radioButtonPt.Size = New System.Drawing.Size(66, 17)
        Me.radioButtonPt.TabIndex = 22
        Me.radioButtonPt.Text = "Pointées"
        Me.radioButtonPt.UseVisualStyleBackColor = True
        '
        'radioButtonToutes
        '
        Me.radioButtonToutes.AutoSize = True
        Me.radioButtonToutes.Location = New System.Drawing.Point(209, 7)
        Me.radioButtonToutes.Name = "radioButtonToutes"
        Me.radioButtonToutes.Size = New System.Drawing.Size(58, 17)
        Me.radioButtonToutes.TabIndex = 23
        Me.radioButtonToutes.Text = "Toutes"
        Me.radioButtonToutes.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radioButtonNonPt)
        Me.Panel1.Controls.Add(Me.radioButtonToutes)
        Me.Panel1.Controls.Add(Me.radioButtonPt)
        Me.Panel1.Location = New System.Drawing.Point(24, 205)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(282, 27)
        Me.Panel1.TabIndex = 24
        '
        'RappBancaireRechAv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.buttonAnnuler
        Me.ClientSize = New System.Drawing.Size(318, 277)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.buttonAnnuler)
        Me.Controls.Add(Me.checkBoxMontantC)
        Me.Controls.Add(Me.checkBoxMontantD)
        Me.Controls.Add(Me.checkBoxLibelle)
        Me.Controls.Add(Me.checkBoxNumPiece)
        Me.Controls.Add(Me.checkBoxMontant)
        Me.Controls.Add(Me.checkBoxDateEcr)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textBoxMontantFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.textBoxMontantDeb)
        Me.Controls.Add(Me.buttonRechercher)
        Me.Controls.Add(Me.dateTimePickerDateFinEcr)
        Me.Controls.Add(Me.dateTimePickerDateDebEcr)
        Me.Controls.Add(Me.textBoxLibelle)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textBoxNumPiece)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RappBancaireRechAv"
        Me.Text = "Recherche avancée rapprochement bancaire"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dateTimePickerDateDebEcr As System.Windows.Forms.DateTimePicker
    Friend WithEvents dateTimePickerDateFinEcr As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents textBoxMontantDeb As System.Windows.Forms.TextBox
    Friend WithEvents textBoxMontantFin As System.Windows.Forms.TextBox
    Friend WithEvents textBoxNumPiece As System.Windows.Forms.TextBox
    Friend WithEvents textBoxLibelle As System.Windows.Forms.TextBox
    Friend WithEvents buttonRechercher As System.Windows.Forms.Button
    Friend WithEvents checkBoxDateEcr As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxMontant As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxNumPiece As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxLibelle As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxMontantD As System.Windows.Forms.CheckBox
    Friend WithEvents checkBoxMontantC As System.Windows.Forms.CheckBox
    Friend WithEvents buttonAnnuler As System.Windows.Forms.Button
    Friend WithEvents radioButtonNonPt As System.Windows.Forms.RadioButton
    Friend WithEvents radioButtonPt As System.Windows.Forms.RadioButton
    Friend WithEvents radioButtonToutes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class

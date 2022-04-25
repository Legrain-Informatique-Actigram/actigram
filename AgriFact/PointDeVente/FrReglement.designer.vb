<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrReglement
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
        Dim DateReglementLabel As System.Windows.Forms.Label
        Dim NChequeLabel As System.Windows.Forms.Label
        Dim MontantLabel As System.Windows.Forms.Label
        Dim PerteLabel As System.Windows.Forms.Label
        Dim ProfitLabel As System.Windows.Forms.Label
        Dim BanqueClientLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrReglement))
        Me.DsAgrifact = New PointDeVente.DsAgrifact
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.gbCB = New System.Windows.Forms.GroupBox
        Me.BanqueClientComboBoxCb = New System.Windows.Forms.ComboBox
        Me.ReglementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxReste = New System.Windows.Forms.TextBox
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.gbEspece = New System.Windows.Forms.GroupBox
        Me.TxEspecePaye = New System.Windows.Forms.TextBox
        Me.TxEspeceRendu = New System.Windows.Forms.TextBox
        Me.BtModeCB = New Ascend.Windows.Forms.GradientNavigationButton
        Me.PerteTextBox = New System.Windows.Forms.TextBox
        Me.ProfitTextBox = New System.Windows.Forms.TextBox
        Me.BtModeCheque = New Ascend.Windows.Forms.GradientNavigationButton
        Me.BtModeEspece = New Ascend.Windows.Forms.GradientNavigationButton
        Me.gbCheque = New System.Windows.Forms.GroupBox
        Me.BanqueClientComboBoxChq = New System.Windows.Forms.ComboBox
        Me.NChequeTextBox = New System.Windows.Forms.TextBox
        Me.MontantTextBox = New System.Windows.Forms.TextBox
        Me.DateReglementDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ReglementTA = New PointDeVente.DsAgrifactTableAdapters.ReglementTA
        Me.ListeChoixTA = New PointDeVente.DsAgrifactTableAdapters.ListeChoixTA
        Me.Reglement_DetailTA = New PointDeVente.DsAgrifactTableAdapters.Reglement_DetailTA
        Me.VFactureTA = New PointDeVente.DsAgrifactTableAdapters.VFactureTA
        Me.BtSuppr = New System.Windows.Forms.Button
        DateReglementLabel = New System.Windows.Forms.Label
        NChequeLabel = New System.Windows.Forms.Label
        MontantLabel = New System.Windows.Forms.Label
        PerteLabel = New System.Windows.Forms.Label
        ProfitLabel = New System.Windows.Forms.Label
        BanqueClientLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        Label4 = New System.Windows.Forms.Label
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.gbCB.SuspendLayout()
        CType(Me.ReglementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEspece.SuspendLayout()
        Me.gbCheque.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateReglementLabel
        '
        DateReglementLabel.AutoSize = True
        DateReglementLabel.Location = New System.Drawing.Point(112, 12)
        DateReglementLabel.Name = "DateReglementLabel"
        DateReglementLabel.Size = New System.Drawing.Size(100, 13)
        DateReglementLabel.TabIndex = 0
        DateReglementLabel.Text = "Date de réglement :"
        '
        'NChequeLabel
        '
        NChequeLabel.AutoSize = True
        NChequeLabel.Location = New System.Drawing.Point(21, 49)
        NChequeLabel.Name = "NChequeLabel"
        NChequeLabel.Size = New System.Drawing.Size(62, 13)
        NChequeLabel.TabIndex = 2
        NChequeLabel.Text = "N° Chèque:"
        '
        'MontantLabel
        '
        MontantLabel.AutoSize = True
        MontantLabel.Location = New System.Drawing.Point(9, 185)
        MontantLabel.Name = "MontantLabel"
        MontantLabel.Size = New System.Drawing.Size(49, 13)
        MontantLabel.TabIndex = 8
        MontantLabel.Text = "Montant:"
        '
        'PerteLabel
        '
        PerteLabel.AutoSize = True
        PerteLabel.Location = New System.Drawing.Point(216, 185)
        PerteLabel.Name = "PerteLabel"
        PerteLabel.Size = New System.Drawing.Size(35, 13)
        PerteLabel.TabIndex = 12
        PerteLabel.Text = "Perte:"
        '
        'ProfitLabel
        '
        ProfitLabel.AutoSize = True
        ProfitLabel.Location = New System.Drawing.Point(217, 211)
        ProfitLabel.Name = "ProfitLabel"
        ProfitLabel.Size = New System.Drawing.Size(34, 13)
        ProfitLabel.TabIndex = 14
        ProfitLabel.Text = "Profit:"
        '
        'BanqueClientLabel
        '
        BanqueClientLabel.AutoSize = True
        BanqueClientLabel.Location = New System.Drawing.Point(23, 22)
        BanqueClientLabel.Name = "BanqueClientLabel"
        BanqueClientLabel.Size = New System.Drawing.Size(47, 13)
        BanqueClientLabel.TabIndex = 0
        BanqueClientLabel.Text = "Banque:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(23, 51)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(45, 13)
        Label1.TabIndex = 2
        Label1.Text = "Rendu :"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(21, 25)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(34, 13)
        Label2.TabIndex = 0
        Label2.Text = "Payé:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(9, 211)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(76, 13)
        Label3.TabIndex = 10
        Label3.Text = "Reste à payer:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(23, 22)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(47, 13)
        Label4.TabIndex = 0
        Label4.Text = "Banque:"
        '
        'DsAgrifact
        '
        Me.DsAgrifact.DataSetName = "AgrifactTracaDataSet"
        Me.DsAgrifact.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.BtSuppr)
        Me.GradientPanel1.Controls.Add(Me.gbCB)
        Me.GradientPanel1.Controls.Add(Label3)
        Me.GradientPanel1.Controls.Add(Me.TxReste)
        Me.GradientPanel1.Controls.Add(Me.BtCancel)
        Me.GradientPanel1.Controls.Add(Me.BtOK)
        Me.GradientPanel1.Controls.Add(Me.gbEspece)
        Me.GradientPanel1.Controls.Add(Me.BtModeCB)
        Me.GradientPanel1.Controls.Add(Me.PerteTextBox)
        Me.GradientPanel1.Controls.Add(Me.ProfitTextBox)
        Me.GradientPanel1.Controls.Add(Me.BtModeCheque)
        Me.GradientPanel1.Controls.Add(Me.BtModeEspece)
        Me.GradientPanel1.Controls.Add(Me.gbCheque)
        Me.GradientPanel1.Controls.Add(ProfitLabel)
        Me.GradientPanel1.Controls.Add(PerteLabel)
        Me.GradientPanel1.Controls.Add(MontantLabel)
        Me.GradientPanel1.Controls.Add(Me.MontantTextBox)
        Me.GradientPanel1.Controls.Add(DateReglementLabel)
        Me.GradientPanel1.Controls.Add(Me.DateReglementDateTimePicker)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(329, 270)
        Me.GradientPanel1.TabIndex = 0
        '
        'gbCB
        '
        Me.gbCB.Controls.Add(Label4)
        Me.gbCB.Controls.Add(Me.BanqueClientComboBoxCb)
        Me.gbCB.Location = New System.Drawing.Point(139, 92)
        Me.gbCB.Name = "gbCB"
        Me.gbCB.Size = New System.Drawing.Size(106, 84)
        Me.gbCB.TabIndex = 6
        Me.gbCB.TabStop = False
        Me.gbCB.Text = "Infos CB"
        '
        'BanqueClientComboBoxCb
        '
        Me.BanqueClientComboBoxCb.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReglementBindingSource, "BanqueClient", True))
        Me.BanqueClientComboBoxCb.DataSource = Me.ListeChoixBindingSource
        Me.BanqueClientComboBoxCb.DisplayMember = "Valeur"
        Me.BanqueClientComboBoxCb.FormattingEnabled = True
        Me.BanqueClientComboBoxCb.Location = New System.Drawing.Point(83, 19)
        Me.BanqueClientComboBoxCb.Name = "BanqueClientComboBoxCb"
        Me.BanqueClientComboBoxCb.Size = New System.Drawing.Size(187, 21)
        Me.BanqueClientComboBoxCb.TabIndex = 1
        Me.BanqueClientComboBoxCb.ValueMember = "Valeur"
        '
        'ReglementBindingSource
        '
        Me.ReglementBindingSource.DataMember = "Reglement"
        Me.ReglementBindingSource.DataSource = Me.DsAgrifact
        '
        'ListeChoixBindingSource
        '
        Me.ListeChoixBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixBindingSource.DataSource = Me.DsAgrifact
        Me.ListeChoixBindingSource.Sort = "nOrdreValeur"
        '
        'TxReste
        '
        Me.TxReste.Location = New System.Drawing.Point(91, 208)
        Me.TxReste.Name = "TxReste"
        Me.TxReste.ReadOnly = True
        Me.TxReste.Size = New System.Drawing.Size(71, 20)
        Me.TxReste.TabIndex = 11
        Me.TxReste.Text = "9 999,99 €"
        Me.TxReste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(246, 239)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 17
        Me.BtCancel.Text = "Annuler"
        Me.BtCancel.UseVisualStyleBackColor = True
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(165, 239)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 16
        Me.BtOK.Text = "OK"
        Me.BtOK.UseVisualStyleBackColor = True
        '
        'gbEspece
        '
        Me.gbEspece.Controls.Add(Me.TxEspecePaye)
        Me.gbEspece.Controls.Add(Me.TxEspeceRendu)
        Me.gbEspece.Controls.Add(Label1)
        Me.gbEspece.Controls.Add(Label2)
        Me.gbEspece.Location = New System.Drawing.Point(251, 92)
        Me.gbEspece.Name = "gbEspece"
        Me.gbEspece.Size = New System.Drawing.Size(158, 84)
        Me.gbEspece.TabIndex = 7
        Me.gbEspece.TabStop = False
        Me.gbEspece.Text = "Paiement espèce"
        '
        'TxEspecePaye
        '
        Me.TxEspecePaye.Location = New System.Drawing.Point(74, 22)
        Me.TxEspecePaye.Name = "TxEspecePaye"
        Me.TxEspecePaye.Size = New System.Drawing.Size(62, 20)
        Me.TxEspecePaye.TabIndex = 1
        Me.TxEspecePaye.Text = "9 999,99 €"
        Me.TxEspecePaye.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxEspeceRendu
        '
        Me.TxEspeceRendu.Location = New System.Drawing.Point(74, 48)
        Me.TxEspeceRendu.Name = "TxEspeceRendu"
        Me.TxEspeceRendu.Size = New System.Drawing.Size(62, 20)
        Me.TxEspeceRendu.TabIndex = 3
        Me.TxEspeceRendu.Text = "9 999,99 €"
        Me.TxEspeceRendu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtModeCB
        '
        Me.BtModeCB.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtModeCB.ActiveGradientLowColor = System.Drawing.Color.Orange
        Me.BtModeCB.AntiAlias = True
        Me.BtModeCB.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtModeCB.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtModeCB.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtModeCB.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtModeCB.HighColorLuminance = 1.3!
        Me.BtModeCB.Image = Global.PointDeVente.My.Resources.Resources.cb
        Me.BtModeCB.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtModeCB.Location = New System.Drawing.Point(218, 34)
        Me.BtModeCB.LowColorLuminance = 1.3!
        Me.BtModeCB.Name = "BtModeCB"
        Me.BtModeCB.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtModeCB.Size = New System.Drawing.Size(95, 52)
        Me.BtModeCB.TabIndex = 4
        Me.BtModeCB.TabStop = True
        Me.BtModeCB.Text = "Carte Bancaire"
        Me.BtModeCB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PerteTextBox
        '
        Me.PerteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReglementBindingSource, "Perte", True))
        Me.PerteTextBox.Location = New System.Drawing.Point(257, 182)
        Me.PerteTextBox.Name = "PerteTextBox"
        Me.PerteTextBox.Size = New System.Drawing.Size(62, 20)
        Me.PerteTextBox.TabIndex = 13
        Me.PerteTextBox.Text = "9 999,99 €"
        Me.PerteTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ProfitTextBox
        '
        Me.ProfitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReglementBindingSource, "Profit", True))
        Me.ProfitTextBox.Location = New System.Drawing.Point(257, 208)
        Me.ProfitTextBox.Name = "ProfitTextBox"
        Me.ProfitTextBox.Size = New System.Drawing.Size(62, 20)
        Me.ProfitTextBox.TabIndex = 15
        Me.ProfitTextBox.Text = "9 999,99 €"
        Me.ProfitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtModeCheque
        '
        Me.BtModeCheque.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtModeCheque.ActiveGradientLowColor = System.Drawing.Color.Orange
        Me.BtModeCheque.AntiAlias = True
        Me.BtModeCheque.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtModeCheque.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtModeCheque.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtModeCheque.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtModeCheque.HighColorLuminance = 1.3!
        Me.BtModeCheque.Image = CType(resources.GetObject("BtModeCheque.Image"), System.Drawing.Image)
        Me.BtModeCheque.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtModeCheque.Location = New System.Drawing.Point(115, 34)
        Me.BtModeCheque.LowColorLuminance = 1.3!
        Me.BtModeCheque.Name = "BtModeCheque"
        Me.BtModeCheque.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtModeCheque.Size = New System.Drawing.Size(95, 52)
        Me.BtModeCheque.TabIndex = 3
        Me.BtModeCheque.TabStop = True
        Me.BtModeCheque.Text = "Chèque"
        Me.BtModeCheque.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'BtModeEspece
        '
        Me.BtModeEspece.ActiveGradientHighColor = System.Drawing.Color.White
        Me.BtModeEspece.ActiveGradientLowColor = System.Drawing.Color.Orange
        Me.BtModeEspece.AntiAlias = True
        Me.BtModeEspece.BorderColor = New Ascend.BorderColor(System.Drawing.SystemColors.ControlDarkDark)
        Me.BtModeEspece.CornerRadius = New Ascend.CornerRadius(3)
        Me.BtModeEspece.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtModeEspece.GradientLowColor = System.Drawing.SystemColors.ButtonShadow
        Me.BtModeEspece.HighColorLuminance = 1.3!
        Me.BtModeEspece.Image = Global.PointDeVente.My.Resources.Resources.especes
        Me.BtModeEspece.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtModeEspece.Location = New System.Drawing.Point(12, 34)
        Me.BtModeEspece.LowColorLuminance = 1.3!
        Me.BtModeEspece.Name = "BtModeEspece"
        Me.BtModeEspece.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.BtModeEspece.Size = New System.Drawing.Size(95, 52)
        Me.BtModeEspece.TabIndex = 2
        Me.BtModeEspece.TabStop = True
        Me.BtModeEspece.Text = "Espèces"
        Me.BtModeEspece.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'gbCheque
        '
        Me.gbCheque.Controls.Add(BanqueClientLabel)
        Me.gbCheque.Controls.Add(Me.BanqueClientComboBoxChq)
        Me.gbCheque.Controls.Add(Me.NChequeTextBox)
        Me.gbCheque.Controls.Add(NChequeLabel)
        Me.gbCheque.Location = New System.Drawing.Point(12, 92)
        Me.gbCheque.Name = "gbCheque"
        Me.gbCheque.Size = New System.Drawing.Size(121, 84)
        Me.gbCheque.TabIndex = 5
        Me.gbCheque.TabStop = False
        Me.gbCheque.Text = "Infos Chèque"
        '
        'BanqueClientComboBoxChq
        '
        Me.BanqueClientComboBoxChq.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReglementBindingSource, "BanqueClient", True))
        Me.BanqueClientComboBoxChq.DataSource = Me.ListeChoixBindingSource
        Me.BanqueClientComboBoxChq.DisplayMember = "Valeur"
        Me.BanqueClientComboBoxChq.FormattingEnabled = True
        Me.BanqueClientComboBoxChq.Location = New System.Drawing.Point(83, 19)
        Me.BanqueClientComboBoxChq.Name = "BanqueClientComboBoxChq"
        Me.BanqueClientComboBoxChq.Size = New System.Drawing.Size(187, 21)
        Me.BanqueClientComboBoxChq.TabIndex = 1
        Me.BanqueClientComboBoxChq.ValueMember = "Valeur"
        '
        'NChequeTextBox
        '
        Me.NChequeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReglementBindingSource, "nCheque", True))
        Me.NChequeTextBox.Location = New System.Drawing.Point(83, 46)
        Me.NChequeTextBox.Name = "NChequeTextBox"
        Me.NChequeTextBox.Size = New System.Drawing.Size(187, 20)
        Me.NChequeTextBox.TabIndex = 3
        '
        'MontantTextBox
        '
        Me.MontantTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ReglementBindingSource, "Montant", True))
        Me.MontantTextBox.Location = New System.Drawing.Point(91, 182)
        Me.MontantTextBox.Name = "MontantTextBox"
        Me.MontantTextBox.Size = New System.Drawing.Size(71, 20)
        Me.MontantTextBox.TabIndex = 9
        Me.MontantTextBox.Text = "9 999,99 €"
        Me.MontantTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DateReglementDateTimePicker
        '
        Me.DateReglementDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.ReglementBindingSource, "DateReglement", True))
        Me.DateReglementDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateReglementDateTimePicker.Location = New System.Drawing.Point(218, 8)
        Me.DateReglementDateTimePicker.Name = "DateReglementDateTimePicker"
        Me.DateReglementDateTimePicker.Size = New System.Drawing.Size(95, 20)
        Me.DateReglementDateTimePicker.TabIndex = 1
        '
        'ReglementTA
        '
        Me.ReglementTA.ClearBeforeFill = True
        '
        'ListeChoixTA
        '
        Me.ListeChoixTA.ClearBeforeFill = True
        '
        'Reglement_DetailTA
        '
        Me.Reglement_DetailTA.ClearBeforeFill = True
        '
        'VFactureTA
        '
        Me.VFactureTA.ClearBeforeFill = True
        '
        'BtSuppr
        '
        Me.BtSuppr.Image = Global.PointDeVente.My.Resources.Resources.suppr
        Me.BtSuppr.Location = New System.Drawing.Point(12, 239)
        Me.BtSuppr.Name = "BtSuppr"
        Me.BtSuppr.Size = New System.Drawing.Size(135, 23)
        Me.BtSuppr.TabIndex = 18
        Me.BtSuppr.Text = "Annuler le réglement"
        Me.BtSuppr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtSuppr.UseVisualStyleBackColor = True
        '
        'FrReglement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(329, 270)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrReglement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Réglement"
        CType(Me.DsAgrifact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.gbCB.ResumeLayout(False)
        Me.gbCB.PerformLayout()
        CType(Me.ReglementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEspece.ResumeLayout(False)
        Me.gbEspece.PerformLayout()
        Me.gbCheque.ResumeLayout(False)
        Me.gbCheque.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DsAgrifact As PointDeVente.DsAgrifact
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents ReglementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReglementTA As PointDeVente.DsAgrifactTableAdapters.ReglementTA
    Friend WithEvents ProfitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PerteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MontantTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NChequeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DateReglementDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbCheque As System.Windows.Forms.GroupBox
    Friend WithEvents BanqueClientComboBoxChq As System.Windows.Forms.ComboBox
    Friend WithEvents BtModeEspece As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtModeCB As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents BtModeCheque As Ascend.Windows.Forms.GradientNavigationButton
    Friend WithEvents gbEspece As System.Windows.Forms.GroupBox
    Friend WithEvents TxEspecePaye As System.Windows.Forms.TextBox
    Friend WithEvents TxEspeceRendu As System.Windows.Forms.TextBox
    Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTA As PointDeVente.DsAgrifactTableAdapters.ListeChoixTA
    Friend WithEvents TxReste As System.Windows.Forms.TextBox
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents gbCB As System.Windows.Forms.GroupBox
    Friend WithEvents BanqueClientComboBoxCb As System.Windows.Forms.ComboBox
    Friend WithEvents Reglement_DetailTA As PointDeVente.DsAgrifactTableAdapters.Reglement_DetailTA
    Friend WithEvents VFactureTA As PointDeVente.DsAgrifactTableAdapters.VFactureTA
    Friend WithEvents BtSuppr As System.Windows.Forms.Button
End Class
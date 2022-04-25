<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrCessionPartielle
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.ImmoPrincTabPage = New System.Windows.Forms.TabPage
        Me.ObsTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.LibTextBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.NCompoTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.OrdreTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ActiTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CptTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ImmoCedTabPage = New System.Windows.Forms.TabPage
        Me.OrdreNumericUpDown = New System.Windows.Forms.NumericUpDown
        Me.NewObsTextBox = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.NewLibTextBox = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.NewNCompoTextBox = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.NewActiTextBox = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.NewCptTextBox = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CessionTabPage = New System.Windows.Forms.TabPage
        Me.DtCessDateTimePicker = New System.Windows.Forms.DateTimePicker
        Me.ValRestanteTextBox = New System.Windows.Forms.TextBox
        Me.ValAcquisTextBox = New System.Windows.Forms.TextBox
        Me.ValCessTextBox = New System.Windows.Forms.TextBox
        Me.NewValAcquisTextBox = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.AnnulerButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.ImmoPrincTabPage.SuspendLayout()
        Me.ImmoCedTabPage.SuspendLayout()
        CType(Me.OrdreNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CessionTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.ImmoPrincTabPage)
        Me.TabControl1.Controls.Add(Me.ImmoCedTabPage)
        Me.TabControl1.Controls.Add(Me.CessionTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(613, 197)
        Me.TabControl1.TabIndex = 0
        '
        'ImmoPrincTabPage
        '
        Me.ImmoPrincTabPage.Controls.Add(Me.ObsTextBox)
        Me.ImmoPrincTabPage.Controls.Add(Me.Label6)
        Me.ImmoPrincTabPage.Controls.Add(Me.LibTextBox)
        Me.ImmoPrincTabPage.Controls.Add(Me.Label5)
        Me.ImmoPrincTabPage.Controls.Add(Me.NCompoTextBox)
        Me.ImmoPrincTabPage.Controls.Add(Me.Label4)
        Me.ImmoPrincTabPage.Controls.Add(Me.OrdreTextBox)
        Me.ImmoPrincTabPage.Controls.Add(Me.Label3)
        Me.ImmoPrincTabPage.Controls.Add(Me.ActiTextBox)
        Me.ImmoPrincTabPage.Controls.Add(Me.Label2)
        Me.ImmoPrincTabPage.Controls.Add(Me.CptTextBox)
        Me.ImmoPrincTabPage.Controls.Add(Me.Label1)
        Me.ImmoPrincTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ImmoPrincTabPage.Name = "ImmoPrincTabPage"
        Me.ImmoPrincTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ImmoPrincTabPage.Size = New System.Drawing.Size(605, 171)
        Me.ImmoPrincTabPage.TabIndex = 0
        Me.ImmoPrincTabPage.Text = "Immobilisation principale"
        Me.ImmoPrincTabPage.UseVisualStyleBackColor = True
        '
        'ObsTextBox
        '
        Me.ObsTextBox.AcceptsReturn = True
        Me.ObsTextBox.Location = New System.Drawing.Point(87, 96)
        Me.ObsTextBox.MaxLength = 35
        Me.ObsTextBox.Multiline = True
        Me.ObsTextBox.Name = "ObsTextBox"
        Me.ObsTextBox.ReadOnly = True
        Me.ObsTextBox.Size = New System.Drawing.Size(274, 64)
        Me.ObsTextBox.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Observations :"
        '
        'LibTextBox
        '
        Me.LibTextBox.Location = New System.Drawing.Point(87, 67)
        Me.LibTextBox.MaxLength = 35
        Me.LibTextBox.Name = "LibTextBox"
        Me.LibTextBox.ReadOnly = True
        Me.LibTextBox.Size = New System.Drawing.Size(274, 20)
        Me.LibTextBox.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Description :"
        '
        'NCompoTextBox
        '
        Me.NCompoTextBox.Location = New System.Drawing.Point(241, 41)
        Me.NCompoTextBox.Name = "NCompoTextBox"
        Me.NCompoTextBox.ReadOnly = True
        Me.NCompoTextBox.Size = New System.Drawing.Size(34, 20)
        Me.NCompoTextBox.TabIndex = 7
        Me.NCompoTextBox.Text = "9999"
        Me.NCompoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NCompoTextBox.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(155, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "N° composant :"
        '
        'OrdreTextBox
        '
        Me.OrdreTextBox.Location = New System.Drawing.Point(241, 15)
        Me.OrdreTextBox.Name = "OrdreTextBox"
        Me.OrdreTextBox.ReadOnly = True
        Me.OrdreTextBox.Size = New System.Drawing.Size(34, 20)
        Me.OrdreTextBox.TabIndex = 5
        Me.OrdreTextBox.Text = "9999"
        Me.OrdreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "N° ordre :"
        '
        'ActiTextBox
        '
        Me.ActiTextBox.Location = New System.Drawing.Point(110, 41)
        Me.ActiTextBox.Name = "ActiTextBox"
        Me.ActiTextBox.ReadOnly = True
        Me.ActiTextBox.Size = New System.Drawing.Size(34, 20)
        Me.ActiTextBox.TabIndex = 3
        Me.ActiTextBox.Text = "9999"
        Me.ActiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "N° activité :"
        '
        'CptTextBox
        '
        Me.CptTextBox.Location = New System.Drawing.Point(87, 15)
        Me.CptTextBox.Name = "CptTextBox"
        Me.CptTextBox.ReadOnly = True
        Me.CptTextBox.Size = New System.Drawing.Size(57, 20)
        Me.CptTextBox.TabIndex = 1
        Me.CptTextBox.Text = "99999999"
        Me.CptTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "N° compte :"
        '
        'ImmoCedTabPage
        '
        Me.ImmoCedTabPage.Controls.Add(Me.OrdreNumericUpDown)
        Me.ImmoCedTabPage.Controls.Add(Me.NewObsTextBox)
        Me.ImmoCedTabPage.Controls.Add(Me.Label7)
        Me.ImmoCedTabPage.Controls.Add(Me.NewLibTextBox)
        Me.ImmoCedTabPage.Controls.Add(Me.Label8)
        Me.ImmoCedTabPage.Controls.Add(Me.NewNCompoTextBox)
        Me.ImmoCedTabPage.Controls.Add(Me.Label9)
        Me.ImmoCedTabPage.Controls.Add(Me.Label10)
        Me.ImmoCedTabPage.Controls.Add(Me.NewActiTextBox)
        Me.ImmoCedTabPage.Controls.Add(Me.Label11)
        Me.ImmoCedTabPage.Controls.Add(Me.NewCptTextBox)
        Me.ImmoCedTabPage.Controls.Add(Me.Label12)
        Me.ImmoCedTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ImmoCedTabPage.Name = "ImmoCedTabPage"
        Me.ImmoCedTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ImmoCedTabPage.Size = New System.Drawing.Size(605, 171)
        Me.ImmoCedTabPage.TabIndex = 1
        Me.ImmoCedTabPage.Text = "Immobilisation cédée"
        Me.ImmoCedTabPage.UseVisualStyleBackColor = True
        '
        'OrdreNumericUpDown
        '
        Me.OrdreNumericUpDown.Location = New System.Drawing.Point(241, 17)
        Me.OrdreNumericUpDown.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.OrdreNumericUpDown.Name = "OrdreNumericUpDown"
        Me.OrdreNumericUpDown.Size = New System.Drawing.Size(48, 20)
        Me.OrdreNumericUpDown.TabIndex = 24
        Me.OrdreNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.OrdreNumericUpDown.Value = New Decimal(New Integer() {999, 0, 0, 0})
        '
        'NewObsTextBox
        '
        Me.NewObsTextBox.AcceptsReturn = True
        Me.NewObsTextBox.Location = New System.Drawing.Point(87, 97)
        Me.NewObsTextBox.MaxLength = 35
        Me.NewObsTextBox.Multiline = True
        Me.NewObsTextBox.Name = "NewObsTextBox"
        Me.NewObsTextBox.Size = New System.Drawing.Size(274, 64)
        Me.NewObsTextBox.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Observations :"
        '
        'NewLibTextBox
        '
        Me.NewLibTextBox.Location = New System.Drawing.Point(87, 68)
        Me.NewLibTextBox.MaxLength = 35
        Me.NewLibTextBox.Name = "NewLibTextBox"
        Me.NewLibTextBox.Size = New System.Drawing.Size(274, 20)
        Me.NewLibTextBox.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Description :"
        '
        'NewNCompoTextBox
        '
        Me.NewNCompoTextBox.Location = New System.Drawing.Point(255, 42)
        Me.NewNCompoTextBox.Name = "NewNCompoTextBox"
        Me.NewNCompoTextBox.ReadOnly = True
        Me.NewNCompoTextBox.Size = New System.Drawing.Size(34, 20)
        Me.NewNCompoTextBox.TabIndex = 19
        Me.NewNCompoTextBox.Text = "9999"
        Me.NewNCompoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NewNCompoTextBox.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(155, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "N° composant :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(155, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "N° ordre :"
        '
        'NewActiTextBox
        '
        Me.NewActiTextBox.Location = New System.Drawing.Point(110, 42)
        Me.NewActiTextBox.Name = "NewActiTextBox"
        Me.NewActiTextBox.ReadOnly = True
        Me.NewActiTextBox.Size = New System.Drawing.Size(34, 20)
        Me.NewActiTextBox.TabIndex = 15
        Me.NewActiTextBox.Text = "9999"
        Me.NewActiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "N° activité :"
        '
        'NewCptTextBox
        '
        Me.NewCptTextBox.Location = New System.Drawing.Point(87, 16)
        Me.NewCptTextBox.Name = "NewCptTextBox"
        Me.NewCptTextBox.ReadOnly = True
        Me.NewCptTextBox.Size = New System.Drawing.Size(57, 20)
        Me.NewCptTextBox.TabIndex = 13
        Me.NewCptTextBox.Text = "99999999"
        Me.NewCptTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "N° compte :"
        '
        'CessionTabPage
        '
        Me.CessionTabPage.Controls.Add(Me.DtCessDateTimePicker)
        Me.CessionTabPage.Controls.Add(Me.ValRestanteTextBox)
        Me.CessionTabPage.Controls.Add(Me.ValAcquisTextBox)
        Me.CessionTabPage.Controls.Add(Me.ValCessTextBox)
        Me.CessionTabPage.Controls.Add(Me.NewValAcquisTextBox)
        Me.CessionTabPage.Controls.Add(Me.Label17)
        Me.CessionTabPage.Controls.Add(Me.Label16)
        Me.CessionTabPage.Controls.Add(Me.Label15)
        Me.CessionTabPage.Controls.Add(Me.Label14)
        Me.CessionTabPage.Controls.Add(Me.Label13)
        Me.CessionTabPage.Location = New System.Drawing.Point(4, 22)
        Me.CessionTabPage.Name = "CessionTabPage"
        Me.CessionTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.CessionTabPage.Size = New System.Drawing.Size(605, 171)
        Me.CessionTabPage.TabIndex = 2
        Me.CessionTabPage.Text = "Valeur de la cession"
        Me.CessionTabPage.UseVisualStyleBackColor = True
        '
        'DtCessDateTimePicker
        '
        Me.DtCessDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtCessDateTimePicker.Location = New System.Drawing.Point(196, 123)
        Me.DtCessDateTimePicker.Name = "DtCessDateTimePicker"
        Me.DtCessDateTimePicker.Size = New System.Drawing.Size(97, 20)
        Me.DtCessDateTimePicker.TabIndex = 9
        '
        'ValRestanteTextBox
        '
        Me.ValRestanteTextBox.Location = New System.Drawing.Point(196, 45)
        Me.ValRestanteTextBox.Name = "ValRestanteTextBox"
        Me.ValRestanteTextBox.ReadOnly = True
        Me.ValRestanteTextBox.Size = New System.Drawing.Size(94, 20)
        Me.ValRestanteTextBox.TabIndex = 8
        Me.ValRestanteTextBox.Text = "9 999 999,99 €"
        Me.ValRestanteTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ValAcquisTextBox
        '
        Me.ValAcquisTextBox.Location = New System.Drawing.Point(196, 19)
        Me.ValAcquisTextBox.Name = "ValAcquisTextBox"
        Me.ValAcquisTextBox.ReadOnly = True
        Me.ValAcquisTextBox.Size = New System.Drawing.Size(94, 20)
        Me.ValAcquisTextBox.TabIndex = 7
        Me.ValAcquisTextBox.Text = "9 999 999,99 €"
        Me.ValAcquisTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ValCessTextBox
        '
        Me.ValCessTextBox.Location = New System.Drawing.Point(196, 97)
        Me.ValCessTextBox.Name = "ValCessTextBox"
        Me.ValCessTextBox.Size = New System.Drawing.Size(94, 20)
        Me.ValCessTextBox.TabIndex = 6
        Me.ValCessTextBox.Text = "9 999 999,99 €"
        Me.ValCessTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NewValAcquisTextBox
        '
        Me.NewValAcquisTextBox.Location = New System.Drawing.Point(196, 71)
        Me.NewValAcquisTextBox.Name = "NewValAcquisTextBox"
        Me.NewValAcquisTextBox.Size = New System.Drawing.Size(94, 20)
        Me.NewValAcquisTextBox.TabIndex = 5
        Me.NewValAcquisTextBox.Text = "9 999 999,99 €"
        Me.NewValAcquisTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 129)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Date de la cession :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Valeur de la cession :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(184, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Part cédée de la valeur d'acquisition :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Valeur restante après cession :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Valeur acquisition initiale :"
        '
        'AnnulerButton
        '
        Me.AnnulerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AnnulerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnulerButton.Location = New System.Drawing.Point(550, 215)
        Me.AnnulerButton.Name = "AnnulerButton"
        Me.AnnulerButton.Size = New System.Drawing.Size(75, 23)
        Me.AnnulerButton.TabIndex = 1
        Me.AnnulerButton.Text = "Annuler"
        Me.AnnulerButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Location = New System.Drawing.Point(469, 215)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'FrCessionPartielle
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.AnnulerButton
        Me.ClientSize = New System.Drawing.Size(637, 248)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.AnnulerButton)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrCessionPartielle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cession partielle d'une immobilisation"
        Me.TabControl1.ResumeLayout(False)
        Me.ImmoPrincTabPage.ResumeLayout(False)
        Me.ImmoPrincTabPage.PerformLayout()
        Me.ImmoCedTabPage.ResumeLayout(False)
        Me.ImmoCedTabPage.PerformLayout()
        CType(Me.OrdreNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CessionTabPage.ResumeLayout(False)
        Me.CessionTabPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents ImmoPrincTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImmoCedTabPage As System.Windows.Forms.TabPage
    Friend WithEvents NCompoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OrdreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ActiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CptTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LibTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ObsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OrdreNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents NewObsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents NewLibTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NewNCompoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents NewActiTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents NewCptTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CessionTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DtCessDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ValRestanteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValAcquisTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValCessTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NewValAcquisTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents AnnulerButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class

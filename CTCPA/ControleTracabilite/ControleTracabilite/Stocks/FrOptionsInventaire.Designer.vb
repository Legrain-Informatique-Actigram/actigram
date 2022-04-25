Namespace Stocks
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrOptionsInventaire
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
            Dim Label1 As System.Windows.Forms.Label
            Dim Label2 As System.Windows.Forms.Label
            Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
            Me.BtCancel = New System.Windows.Forms.Button
            Me.BtOK = New System.Windows.Forms.Button
            Me.CbDepot = New System.Windows.Forms.ComboBox
            Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AgrifactTracaDataSet = New ControleTracabilite.AgrifactTracaDataSet
            Me.ListeChoixTableAdapter = New ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
            Me.ChkGestionLots = New System.Windows.Forms.CheckBox
            Me.DtpDateInv = New System.Windows.Forms.DateTimePicker
            Label1 = New System.Windows.Forms.Label
            Label2 = New System.Windows.Forms.Label
            Me.GradientPanel2.SuspendLayout()
            CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Label1.AutoSize = True
            Label1.Location = New System.Drawing.Point(12, 41)
            Label1.Name = "Label1"
            Label1.Size = New System.Drawing.Size(42, 13)
            Label1.TabIndex = 82
            Label1.Text = "Dépôt :"
            '
            'Label2
            '
            Label2.AutoSize = True
            Label2.Location = New System.Drawing.Point(18, 18)
            Label2.Name = "Label2"
            Label2.Size = New System.Drawing.Size(36, 13)
            Label2.TabIndex = 84
            Label2.Text = "Date :"
            '
            'GradientPanel2
            '
            Me.GradientPanel2.Controls.Add(Me.BtCancel)
            Me.GradientPanel2.Controls.Add(Me.BtOK)
            Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.GradientPanel2.Location = New System.Drawing.Point(0, 92)
            Me.GradientPanel2.Name = "GradientPanel2"
            Me.GradientPanel2.Size = New System.Drawing.Size(245, 45)
            Me.GradientPanel2.TabIndex = 80
            '
            'BtCancel
            '
            Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.BtCancel.Location = New System.Drawing.Point(158, 10)
            Me.BtCancel.Name = "BtCancel"
            Me.BtCancel.Size = New System.Drawing.Size(75, 23)
            Me.BtCancel.TabIndex = 1
            Me.BtCancel.Text = "Annuler"
            Me.BtCancel.UseVisualStyleBackColor = True
            '
            'BtOK
            '
            Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BtOK.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.BtOK.Location = New System.Drawing.Point(77, 10)
            Me.BtOK.Name = "BtOK"
            Me.BtOK.Size = New System.Drawing.Size(75, 23)
            Me.BtOK.TabIndex = 0
            Me.BtOK.Text = "OK"
            Me.BtOK.UseVisualStyleBackColor = True
            '
            'CbDepot
            '
            Me.CbDepot.DataSource = Me.ListeChoixBindingSource
            Me.CbDepot.DisplayMember = "Valeur"
            Me.CbDepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CbDepot.FormattingEnabled = True
            Me.CbDepot.Location = New System.Drawing.Point(60, 38)
            Me.CbDepot.Name = "CbDepot"
            Me.CbDepot.Size = New System.Drawing.Size(173, 21)
            Me.CbDepot.TabIndex = 81
            Me.CbDepot.ValueMember = "Valeur"
            '
            'ListeChoixBindingSource
            '
            Me.ListeChoixBindingSource.DataMember = "ListeChoix"
            Me.ListeChoixBindingSource.DataSource = Me.AgrifactTracaDataSet
            Me.ListeChoixBindingSource.Filter = "Valeur is not null"
            Me.ListeChoixBindingSource.Sort = "nOrdreValeur"
            '
            'AgrifactTracaDataSet
            '
            Me.AgrifactTracaDataSet.DataSetName = "AgrifactTracaDataSet"
            Me.AgrifactTracaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'ListeChoixTableAdapter
            '
            Me.ListeChoixTableAdapter.ClearBeforeFill = True
            '
            'ChkGestionLots
            '
            Me.ChkGestionLots.AutoSize = True
            Me.ChkGestionLots.Location = New System.Drawing.Point(60, 65)
            Me.ChkGestionLots.Name = "ChkGestionLots"
            Me.ChkGestionLots.Size = New System.Drawing.Size(87, 17)
            Me.ChkGestionLots.TabIndex = 83
            Me.ChkGestionLots.Text = "Gérer les lots"
            Me.ChkGestionLots.UseVisualStyleBackColor = True
            '
            'DtpDateInv
            '
            Me.DtpDateInv.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.DtpDateInv.Location = New System.Drawing.Point(60, 12)
            Me.DtpDateInv.Name = "DtpDateInv"
            Me.DtpDateInv.Size = New System.Drawing.Size(98, 20)
            Me.DtpDateInv.TabIndex = 85
            '
            'FrOptionsInventaire
            '
            Me.AcceptButton = Me.BtOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me.BtCancel
            Me.ClientSize = New System.Drawing.Size(245, 137)
            Me.Controls.Add(Me.DtpDateInv)
            Me.Controls.Add(Label2)
            Me.Controls.Add(Me.ChkGestionLots)
            Me.Controls.Add(Label1)
            Me.Controls.Add(Me.CbDepot)
            Me.Controls.Add(Me.GradientPanel2)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
            Me.Name = "FrOptionsInventaire"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Options d'inventaire"
            Me.GradientPanel2.ResumeLayout(False)
            CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AgrifactTracaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
        Friend WithEvents BtCancel As System.Windows.Forms.Button
        Friend WithEvents BtOK As System.Windows.Forms.Button
        Friend WithEvents CbDepot As System.Windows.Forms.ComboBox
        Friend WithEvents AgrifactTracaDataSet As ControleTracabilite.AgrifactTracaDataSet
        Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ListeChoixTableAdapter As ControleTracabilite.AgrifactTracaDataSetTableAdapters.ListeChoixTableAdapter
        Friend WithEvents ChkGestionLots As System.Windows.Forms.CheckBox
        Friend WithEvents DtpDateInv As System.Windows.Forms.DateTimePicker
    End Class
End Namespace
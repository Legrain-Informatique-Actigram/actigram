<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ParamsEtat
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
        Me.fond = New Ascend.Windows.Forms.GradientPanel
        Me.BtClose = New System.Windows.Forms.Button
        Me.BtImprimer = New System.Windows.Forms.Button
        Me.BtApercu = New System.Windows.Forms.Button
        Me.CbEtats = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpDateFin = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDateDebut = New System.Windows.Forms.DateTimePicker
        Me.fond.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fond
        '
        Me.fond.Controls.Add(Me.BtClose)
        Me.fond.Controls.Add(Me.BtImprimer)
        Me.fond.Controls.Add(Me.BtApercu)
        Me.fond.Controls.Add(Me.CbEtats)
        Me.fond.Controls.Add(Me.Label1)
        Me.fond.Controls.Add(Me.GroupBox1)
        Me.fond.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fond.GradientLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.fond.Location = New System.Drawing.Point(0, 0)
        Me.fond.Name = "fond"
        Me.fond.Size = New System.Drawing.Size(293, 153)
        Me.fond.TabIndex = 2
        '
        'BtClose
        '
        Me.BtClose.Location = New System.Drawing.Point(199, 120)
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(79, 23)
        Me.BtClose.TabIndex = 14
        Me.BtClose.Text = "Fermer"
        Me.BtClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtClose.UseVisualStyleBackColor = True
        '
        'BtImprimer
        '
        Me.BtImprimer.Image = Global.PointDeVente.My.Resources.Resources.impr
        Me.BtImprimer.Location = New System.Drawing.Point(107, 120)
        Me.BtImprimer.Name = "BtImprimer"
        Me.BtImprimer.Size = New System.Drawing.Size(86, 23)
        Me.BtImprimer.TabIndex = 13
        Me.BtImprimer.Text = "Imprimer..."
        Me.BtImprimer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtImprimer.UseVisualStyleBackColor = True
        '
        'BtApercu
        '
        Me.BtApercu.Image = Global.PointDeVente.My.Resources.Resources.preview
        Me.BtApercu.Location = New System.Drawing.Point(15, 120)
        Me.BtApercu.Name = "BtApercu"
        Me.BtApercu.Size = New System.Drawing.Size(86, 23)
        Me.BtApercu.TabIndex = 12
        Me.BtApercu.Text = "Aperçu..."
        Me.BtApercu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtApercu.UseVisualStyleBackColor = True
        '
        'CbEtats
        '
        Me.CbEtats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbEtats.FormattingEnabled = True
        Me.CbEtats.Location = New System.Drawing.Point(50, 12)
        Me.CbEtats.Name = "CbEtats"
        Me.CbEtats.Size = New System.Drawing.Size(228, 21)
        Me.CbEtats.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Etat :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpDateFin)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpDateDebut)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 75)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paramétres de l'etat"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fin de la période :"
        '
        'dtpDateFin
        '
        Me.dtpDateFin.CustomFormat = ""
        Me.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFin.Location = New System.Drawing.Point(167, 45)
        Me.dtpDateFin.Name = "dtpDateFin"
        Me.dtpDateFin.Size = New System.Drawing.Size(90, 20)
        Me.dtpDateFin.TabIndex = 7
        Me.dtpDateFin.Value = New Date(2007, 12, 1, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Début de la période :"
        '
        'dtpDateDebut
        '
        Me.dtpDateDebut.CustomFormat = ""
        Me.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateDebut.Location = New System.Drawing.Point(167, 19)
        Me.dtpDateDebut.Name = "dtpDateDebut"
        Me.dtpDateDebut.Size = New System.Drawing.Size(90, 20)
        Me.dtpDateDebut.TabIndex = 3
        Me.dtpDateDebut.Value = New Date(2007, 12, 1, 0, 0, 0, 0)
        '
        'ParamsEtat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 153)
        Me.Controls.Add(Me.fond)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ParamsEtat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Impression des états"
        Me.fond.ResumeLayout(False)
        Me.fond.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents fond As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents dtpDateDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpDateFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents CbEtats As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtClose As System.Windows.Forms.Button
    Friend WithEvents BtImprimer As System.Windows.Forms.Button
    Friend WithEvents BtApercu As System.Windows.Forms.Button
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrChoixValeurAvAuxCult
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrChoixValeurAvAuxCult))
        Me.DataGridViewInventaireGroupe = New System.Windows.Forms.DataGridView
        Me.INVGDossier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGLib = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGCpt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INVGActi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LibelleTypeInventaire = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalValeurHTLignes = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InventaireGroupeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        CType(Me.DataGridViewInventaireGroupe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventaireGroupeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewInventaireGroupe
        '
        Me.DataGridViewInventaireGroupe.AllowUserToAddRows = False
        Me.DataGridViewInventaireGroupe.AllowUserToDeleteRows = False
        Me.DataGridViewInventaireGroupe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewInventaireGroupe.AutoGenerateColumns = False
        Me.DataGridViewInventaireGroupe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewInventaireGroupe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.INVGDossier, Me.INVGLib, Me.INVGCpt, Me.INVGActi, Me.LibelleTypeInventaire, Me.TotalValeurHTLignes})
        Me.DataGridViewInventaireGroupe.DataSource = Me.InventaireGroupeBindingSource
        Me.DataGridViewInventaireGroupe.Location = New System.Drawing.Point(12, 28)
        Me.DataGridViewInventaireGroupe.MultiSelect = False
        Me.DataGridViewInventaireGroupe.Name = "DataGridViewInventaireGroupe"
        Me.DataGridViewInventaireGroupe.ReadOnly = True
        Me.DataGridViewInventaireGroupe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewInventaireGroupe.Size = New System.Drawing.Size(785, 517)
        Me.DataGridViewInventaireGroupe.TabIndex = 0
        '
        'INVGDossier
        '
        Me.INVGDossier.DataPropertyName = "INVGDossier"
        Me.INVGDossier.HeaderText = "Dossier"
        Me.INVGDossier.Name = "INVGDossier"
        Me.INVGDossier.ReadOnly = True
        Me.INVGDossier.Width = 80
        '
        'INVGLib
        '
        Me.INVGLib.DataPropertyName = "INVGLib"
        Me.INVGLib.HeaderText = "Groupe"
        Me.INVGLib.Name = "INVGLib"
        Me.INVGLib.ReadOnly = True
        Me.INVGLib.Width = 200
        '
        'INVGCpt
        '
        Me.INVGCpt.DataPropertyName = "INVGCpt"
        Me.INVGCpt.HeaderText = "Compte"
        Me.INVGCpt.Name = "INVGCpt"
        Me.INVGCpt.ReadOnly = True
        Me.INVGCpt.Width = 90
        '
        'INVGActi
        '
        Me.INVGActi.DataPropertyName = "INVGActi"
        Me.INVGActi.HeaderText = "Activité"
        Me.INVGActi.Name = "INVGActi"
        Me.INVGActi.ReadOnly = True
        Me.INVGActi.Width = 60
        '
        'LibelleTypeInventaire
        '
        Me.LibelleTypeInventaire.DataPropertyName = "LibelleTypeInventaire"
        Me.LibelleTypeInventaire.HeaderText = "Type d'inventaire"
        Me.LibelleTypeInventaire.Name = "LibelleTypeInventaire"
        Me.LibelleTypeInventaire.ReadOnly = True
        '
        'TotalValeurHTLignes
        '
        Me.TotalValeurHTLignes.DataPropertyName = "TotalValeurHTLignes"
        DataGridViewCellStyle1.Format = "C2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.TotalValeurHTLignes.DefaultCellStyle = DataGridViewCellStyle1
        Me.TotalValeurHTLignes.HeaderText = "Total ValeurHT"
        Me.TotalValeurHTLignes.Name = "TotalValeurHTLignes"
        Me.TotalValeurHTLignes.ReadOnly = True
        '
        'InventaireGroupeBindingSource
        '
        Me.InventaireGroupeBindingSource.DataSource = GetType(AgrigestEDI.Inventaire.ClassesMetier.InventaireGroupes)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(785, 10)
        Me.ProgressBar1.TabIndex = 1
        '
        'FrChoixValeurAvAuxCult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(809, 557)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.DataGridViewInventaireGroupe)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrChoixValeurAvAuxCult"
        Me.Text = "Choix valeur avances aux cultures"
        CType(Me.DataGridViewInventaireGroupe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventaireGroupeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InventaireGroupeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewInventaireGroupe As System.Windows.Forms.DataGridView
    Friend WithEvents INVGDossier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGLib As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGCpt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVGActi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LibelleTypeInventaire As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalValeurHTLignes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalCoutTotalFaconsCulturalesLignes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class

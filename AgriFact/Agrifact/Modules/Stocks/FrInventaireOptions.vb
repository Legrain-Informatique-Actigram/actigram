Public Class FrInventaireOptions
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents BtCancel As System.Windows.Forms.Button
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents dtpInv As System.Windows.Forms.DateTimePicker
    Friend WithEvents CbDepot As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkGestionLot As System.Windows.Forms.CheckBox
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents StocksDataSet As AgriFact.StocksDataSet
    Friend WithEvents ListeChoixBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListeChoixTA As AgriFact.StocksDataSetTableAdapters.ListeChoixTA
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.BtCancel = New System.Windows.Forms.Button
        Me.BtOk = New System.Windows.Forms.Button
        Me.dtpInv = New System.Windows.Forms.DateTimePicker
        Me.CbDepot = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.chkGestionLot = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.StocksDataSet = New AgriFact.StocksDataSet
        Me.ListeChoixBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListeChoixTA = New AgriFact.StocksDataSetTableAdapters.ListeChoixTA
        Me.GradientPanel1.SuspendLayout()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtCancel
        '
        Me.BtCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtCancel.Location = New System.Drawing.Point(166, 10)
        Me.BtCancel.Name = "BtCancel"
        Me.BtCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtCancel.TabIndex = 0
        Me.BtCancel.Text = "Annuler"
        '
        'BtOk
        '
        Me.BtOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtOk.Location = New System.Drawing.Point(86, 10)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(75, 23)
        Me.BtOk.TabIndex = 1
        Me.BtOk.Text = "OK"
        '
        'dtpInv
        '
        Me.dtpInv.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInv.Location = New System.Drawing.Point(113, 12)
        Me.dtpInv.Name = "dtpInv"
        Me.dtpInv.Size = New System.Drawing.Size(99, 20)
        Me.dtpInv.TabIndex = 2
        '
        'CbDepot
        '
        Me.CbDepot.DataSource = Me.ListeChoixBindingSource
        Me.CbDepot.DisplayMember = "Valeur"
        Me.CbDepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDepot.Location = New System.Drawing.Point(113, 36)
        Me.CbDepot.Name = "CbDepot"
        Me.CbDepot.Size = New System.Drawing.Size(127, 21)
        Me.CbDepot.TabIndex = 3
        Me.CbDepot.ValueMember = "Valeur"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Date de l'inventaire"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Dépôt"
        '
        'chkGestionLot
        '
        Me.chkGestionLot.Location = New System.Drawing.Point(113, 60)
        Me.chkGestionLot.Name = "chkGestionLot"
        Me.chkGestionLot.Size = New System.Drawing.Size(55, 24)
        Me.chkGestionLot.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Gérer les lots"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.dtpInv)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.CbDepot)
        Me.GradientPanel1.Controls.Add(Me.chkGestionLot)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(253, 90)
        Me.GradientPanel1.TabIndex = 20
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.BtCancel)
        Me.GradientPanel2.Controls.Add(Me.BtOk)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 90)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(253, 45)
        Me.GradientPanel2.TabIndex = 21
        '
        'StocksDataSet
        '
        Me.StocksDataSet.DataSetName = "StocksDataSet"
        Me.StocksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ListeChoixBindingSource
        '
        Me.ListeChoixBindingSource.DataMember = "ListeChoix"
        Me.ListeChoixBindingSource.DataSource = Me.StocksDataSet
        '
        'ListeChoixTA
        '
        Me.ListeChoixTA.ClearBeforeFill = True
        '
        'FrInventaireOptions
        '
        Me.AcceptButton = Me.BtOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtCancel
        Me.ClientSize = New System.Drawing.Size(253, 135)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrInventaireOptions"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options inventaire"
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.StocksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListeChoixBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Props"
    Public Property DateInventaire() As Date
        Get
            Return dtpInv.Value
        End Get
        Set(ByVal Value As Date)
            dtpInv.Value = Value
        End Set
    End Property

    Public Property NomDepot() As String
        Get
            Return CbDepot.Text
        End Get
        Set(ByVal Value As String)
            Me.CbDepot.SelectedValue = Value
        End Set
    End Property

    Public Property GestionLots() As Boolean
        Get
            Return chkGestionLot.Checked
        End Get
        Set(ByVal Value As Boolean)
            chkGestionLot.Checked = Value
        End Set
    End Property
#End Region

    Private Sub FrInventaireOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpInv.Value = Now.Date
        Me.ListeChoixTA.FillByNomChoix(Me.StocksDataSet.ListeChoix, StocksDataSetTableAdapters.ListeChoixTA.NomsChoix.ListeDepots)
    End Sub
End Class

Public Class FrRechercheVille
    Inherits System.Windows.Forms.Form
    Dim dt As DataTable = Nothing
    Dim txCodePostalForm As TextBox
    Dim txVilleForm As TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents CodePostal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NomVille As System.Windows.Forms.DataGridViewTextBoxColumn

    Public ConnectionString As String

    Public Sub New(ByRef monDs As DataSet, ByRef monTxCodePostal As TextBox, ByRef monTxVille As TextBox)
        Me.New()
        If monDs.Tables.Contains("Communes") Then
            dt = monDs.Tables("Communes")
        End If
        txCodePostalForm = monTxCodePostal
        txVilleForm = monTxVille
    End Sub

    Public Sub New(ByRef dtCommunes As DataTable, ByRef monTxCodePostal As TextBox, ByRef monTxVille As TextBox)
        Me.New()
        If Not dtCommunes Is Nothing Then
            dt = dtCommunes
        End If
        txCodePostalForm = monTxCodePostal
        txVilleForm = monTxVille
    End Sub

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxCodePostal As System.Windows.Forms.TextBox
    Friend WithEvents TxVille As System.Windows.Forms.TextBox
    Friend WithEvents BtRecherche As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxCodePostal = New System.Windows.Forms.TextBox
        Me.TxVille = New System.Windows.Forms.TextBox
        Me.BtRecherche = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.CodePostal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NomVille = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code Postal"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(69, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ville"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxCodePostal
        '
        Me.TxCodePostal.AcceptsReturn = True
        Me.TxCodePostal.Location = New System.Drawing.Point(8, 28)
        Me.TxCodePostal.Name = "TxCodePostal"
        Me.TxCodePostal.Size = New System.Drawing.Size(64, 20)
        Me.TxCodePostal.TabIndex = 2
        '
        'TxVille
        '
        Me.TxVille.AcceptsReturn = True
        Me.TxVille.Location = New System.Drawing.Point(72, 28)
        Me.TxVille.Name = "TxVille"
        Me.TxVille.Size = New System.Drawing.Size(191, 20)
        Me.TxVille.TabIndex = 3
        '
        'BtRecherche
        '
        Me.BtRecherche.Image = Global.GRC.My.Resources.Resources.search
        Me.BtRecherche.Location = New System.Drawing.Point(263, 23)
        Me.BtRecherche.Name = "BtRecherche"
        Me.BtRecherche.Size = New System.Drawing.Size(25, 25)
        Me.BtRecherche.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodePostal, Me.NomVille})
        Me.DataGridView1.Location = New System.Drawing.Point(8, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(280, 200)
        Me.DataGridView1.TabIndex = 6
        '
        'CodePostal
        '
        Me.CodePostal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CodePostal.DataPropertyName = "CodePostal"
        Me.CodePostal.HeaderText = "Code Postal"
        Me.CodePostal.Name = "CodePostal"
        Me.CodePostal.ReadOnly = True
        Me.CodePostal.Width = 89
        '
        'NomVille
        '
        Me.NomVille.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NomVille.DataPropertyName = "NomVille"
        Me.NomVille.HeaderText = "Ville"
        Me.NomVille.Name = "NomVille"
        Me.NomVille.ReadOnly = True
        '
        'FrRechercheVille
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BtRecherche)
        Me.Controls.Add(Me.TxVille)
        Me.Controls.Add(Me.TxCodePostal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrRechercheVille"
        Me.Text = "Recherche Ville"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Function FillCommunes() As DataTable
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim conn As New SqlClient.SqlConnection(ConnectionString)
            Try
                Dim dta As New SqlClient.SqlDataAdapter("Select * from Communes", conn)
                Try
                    Dim dt As New DataTable
                    dta.Fill(dt)
                    Return dt
                Finally
                    dta.Dispose()
                End Try
            Finally
                If conn.State <> ConnectionState.Closed Then conn.Close()
                Me.Cursor = Cursors.Default
            End Try
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub BtRecherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRecherche.Click
        If dt Is Nothing Then
            'Charger les communes depuis la base
            dt = FillCommunes()
            If dt Is Nothing Then Exit Sub
        End If

        Dim strFiltre As String = ""
        If Me.TxCodePostal.Text.Length > 0 Then
            strFiltre += "CodePostal like '" & Me.TxCodePostal.Text & "*'"
        End If
        If Me.TxVille.Text.Length > 0 Then
            If strFiltre.Length > 0 Then
                strFiltre += " And "
            End If
            strFiltre += "NomVille like '*" & Me.TxVille.Text.Replace("'", "''") & "*'"
        End If
        Dim dv As New DataView(dt, strFiltre, "CodePostal,NomVille", DataViewRowState.CurrentRows)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.DataSource = dv
    End Sub

    Private Sub FrRechercheVille_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CType(Me.BtRecherche.Image, Bitmap).MakeTransparent(Color.Magenta)
        ApplyStyle(Me.DataGridView1)
        Me.TxCodePostal.Text = Me.txCodePostalForm.Text
        Me.TxVille.Text = Me.txVilleForm.Text
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim rw As DataRow = CType(Me.DataGridView1.Rows(e.RowIndex).DataBoundItem, DataRowView).Row
        Me.txCodePostalForm.Text = Convert.ToString(rw.Item("CodePostal"))
        Me.txVilleForm.Text = Convert.ToString(rw.Item("NomVille"))
        Me.Close()
    End Sub

    Private Sub TxCodePostal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles TxCodePostal.KeyPress, TxVille.KeyPress
        If e.KeyChar = vbCr Then
            BtRecherche_Click(Nothing, Nothing)
            e.Handled = True
        End If
    End Sub
End Class

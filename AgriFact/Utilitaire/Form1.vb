Imports Actigram.Securite.SecuriteConverter

Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim ds As New DataSet

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
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxFiltre As System.Windows.Forms.TextBox
    Friend WithEvents TxTable As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxFiltre = New System.Windows.Forms.TextBox
        Me.TxTable = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(0, 40)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(880, 320)
        Me.DataGrid1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(8, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Mettre A Jour"
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(680, 368)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 24)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Charger"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Table"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(288, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Filtre"
        '
        'TxFiltre
        '
        Me.TxFiltre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxFiltre.Location = New System.Drawing.Point(320, 8)
        Me.TxFiltre.Name = "TxFiltre"
        Me.TxFiltre.Size = New System.Drawing.Size(280, 20)
        Me.TxFiltre.TabIndex = 6
        Me.TxFiltre.Text = ""
        '
        'TxTable
        '
        Me.TxTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTable.Location = New System.Drawing.Point(48, 8)
        Me.TxTable.Name = "TxTable"
        Me.TxTable.Size = New System.Drawing.Size(232, 20)
        Me.TxTable.TabIndex = 7
        Me.TxTable.Text = ""
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(616, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 24)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Appliquer le Filtre"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(784, 368)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 24)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Mettre A Jour"
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(112, 368)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(96, 24)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Maj Groupe"
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(216, 368)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(96, 24)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Maj Ev"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(888, 398)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TxTable)
        Me.Controls.Add(Me.TxFiltre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Name = "Form1"
        Me.Text = "Utilitaire"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Const strConnexion As String = "workstation id=Machine;packet size=4096;initial catalog=TOURRAINE;data source=Machine;user id=Utilisateur;password=Pwd;persist security info=True"

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim cn As New SqlClient.SqlConnection
        'cn.ConnectionString = strConnexion.Replace("Utilisateur", "sa").Replace("Pwd", "tdt")
        'cn.Open()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
        Actigram.Securite.SecuriteConverter.DeCrypeDatasetDonneesFromFile(ds, Application.StartupPath & "\XmlEnCode.xml")
        Me.DataGrid1.DataSource = ds

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dsPlus As New DataSet

        dsPlus.Merge(ds.Tables("Entreprise"))

        dsPlus.Tables("Entreprise").Clear()
        dsPlus.Tables("Entreprise").Columns.Add("nOrganisme", GetType(Decimal))
        dsPlus.Tables("Entreprise").Columns.Add("Cedex", GetType(String))
        dsPlus.Tables("Entreprise").Columns.Add("Activites", GetType(String))
        Dim rw As DataRow
        Dim cl As DataColumn
        For Each rw In ds.Tables("Entreprise").Rows
            Dim rwA As DataRow
            rwA = dsPlus.Tables("Entreprise").NewRow
            For Each cl In rw.Table.Columns
                rwA.Item(cl.ColumnName) = rw.Item(cl.ColumnName)
            Next
            dsPlus.Tables("Entreprise").Rows.Add(rwA)
        Next


        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = strConnexion.Replace("Utilisateur", "sa").Replace("Pwd", "ludo").Replace("Machine", "Internet").Replace("TOURRAINE", "ACTIGRAM")
        Dim dtEntreprise As New SqlClient.SqlDataAdapter("Select * From Entreprise", cn)
        'cn.Open()
        Dim cmdB As New SqlClient.SqlCommandBuilder(dtEntreprise)
        dtEntreprise.UpdateCommand = cmdB.GetUpdateCommand
        dtEntreprise.Update(dsPlus.Tables("Entreprise"))
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Actigram.Securite.SecuriteConverter.CrypteDataSetSchemaToFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
        Actigram.Securite.SecuriteConverter.CrypteDatasetDonneesToFile(ds, Application.StartupPath & "\XmlEnCode.xml", XmlWriteMode.DiffGram)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = strConnexion.Replace("Utilisateur", "sa").Replace("Pwd", "").Replace("Machine", "nestor2").Replace("TOURRAINE", "LEAV2")

        Try
            cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim cmd As New SqlClient.SqlCommand("Select * From Entreprise", cn)

        Dim rw As DataRow
        For Each rw In ds.Tables("Entreprise").Select("nMaisonMere is not null")
            cmd.CommandText = "Update Entreprise Set nMaisonMere=" & Convert.ToString(rw.Item("nMaisonMere")) & " Where nEntreprise=" & Convert.ToString(rw.Item("nEntreprise"))
            cmd.ExecuteNonQuery()
        Next

        Try
            cn.Close()
        Catch ex As Exception

        End Try

        MessageBox.Show("Mise à jour terminée")

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = strConnexion.Replace("Utilisateur", "sa").Replace("Pwd", "ludo").Replace("Machine", "LACHEZE").Replace("TOURRAINE", "ACTIGRAM")

        Try
            cn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim cmd As New SqlClient.SqlCommand("Update Evenement Set Type=@P1,DateEv=@P2 Where nEvenement=@P3", cn)
        cmd.Parameters.Add("@P1", SqlDbType.NVarChar)
        cmd.Parameters.Add("@P2", SqlDbType.DateTime)
        cmd.Parameters.Add("@P3", SqlDbType.Decimal)

        Dim rw As DataRow
        For Each rw In ds.Tables("Evenement").Select()
            cmd.Parameters("@P1").Value = rw.Item("Type")
            cmd.Parameters("@P2").Value = rw.Item("DateEv")
            cmd.Parameters("@P3").Value = rw.Item("nEvenement")
            'cmd.CommandText = "Update Evenement Set Type='" & Convert.ToString(rw.Item("Type")) & "', DateEv='" & Convert.ToDateTime(rw.Item("DateEv")).ToString("dd-MM-yy") & "' Where nEvenement=" & Convert.ToString(rw.Item("nEvenement"))
            cmd.ExecuteNonQuery()
        Next

        Try
            cn.Close()
        Catch ex As Exception

        End Try

        MessageBox.Show("Mise à jour terminée")
    End Sub
End Class

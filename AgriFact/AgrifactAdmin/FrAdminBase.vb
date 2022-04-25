Public Class FrAdminBase
    Inherits System.Windows.Forms.Form
    Private cn As SqlClient.SqlConnection
    Private User As Utilisateur

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal connection As SqlClient.SqlConnection)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        cn = connection
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
    Friend WithEvents TxNomBase As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtFichiermdf As System.Windows.Forms.Button
    Friend WithEvents TxFichiermdf As System.Windows.Forms.TextBox
    Friend WithEvents BtFichierLDF As System.Windows.Forms.Button
    Friend WithEvents TxFichierldf As System.Windows.Forms.TextBox
    Friend WithEvents BtAttacher As System.Windows.Forms.Button
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxNomBase = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtFichiermdf = New System.Windows.Forms.Button
        Me.TxFichiermdf = New System.Windows.Forms.TextBox
        Me.BtFichierLDF = New System.Windows.Forms.Button
        Me.TxFichierldf = New System.Windows.Forms.TextBox
        Me.BtAttacher = New System.Windows.Forms.Button
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Chemin Fichier mdf"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Chemin Fichier ldf"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxNomBase
        '
        Me.TxNomBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxNomBase.Location = New System.Drawing.Point(136, 24)
        Me.TxNomBase.Name = "TxNomBase"
        Me.TxNomBase.Size = New System.Drawing.Size(272, 20)
        Me.TxNomBase.TabIndex = 2
        Me.TxNomBase.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nom de la base"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtFichiermdf
        '
        Me.BtFichiermdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtFichiermdf.Location = New System.Drawing.Point(408, 48)
        Me.BtFichiermdf.Name = "BtFichiermdf"
        Me.BtFichiermdf.Size = New System.Drawing.Size(20, 20)
        Me.BtFichiermdf.TabIndex = 6
        Me.BtFichiermdf.Tag = ".mdf"
        Me.BtFichiermdf.Text = "..."
        '
        'TxFichiermdf
        '
        Me.TxFichiermdf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxFichiermdf.Location = New System.Drawing.Point(136, 48)
        Me.TxFichiermdf.Name = "TxFichiermdf"
        Me.TxFichiermdf.Size = New System.Drawing.Size(272, 20)
        Me.TxFichiermdf.TabIndex = 5
        Me.TxFichiermdf.Text = ""
        '
        'BtFichierLDF
        '
        Me.BtFichierLDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtFichierLDF.Location = New System.Drawing.Point(408, 72)
        Me.BtFichierLDF.Name = "BtFichierLDF"
        Me.BtFichierLDF.Size = New System.Drawing.Size(20, 20)
        Me.BtFichierLDF.TabIndex = 8
        Me.BtFichierLDF.Tag = ".ldf"
        Me.BtFichierLDF.Text = "..."
        '
        'TxFichierldf
        '
        Me.TxFichierldf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxFichierldf.Location = New System.Drawing.Point(136, 72)
        Me.TxFichierldf.Name = "TxFichierldf"
        Me.TxFichierldf.Size = New System.Drawing.Size(272, 20)
        Me.TxFichierldf.TabIndex = 7
        Me.TxFichierldf.Text = ""
        '
        'BtAttacher
        '
        Me.BtAttacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAttacher.Location = New System.Drawing.Point(352, 104)
        Me.BtAttacher.Name = "BtAttacher"
        Me.BtAttacher.TabIndex = 9
        Me.BtAttacher.Text = "Attacher"
        '
        'BtAnnuler
        '
        Me.BtAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtAnnuler.Location = New System.Drawing.Point(272, 104)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.TabIndex = 10
        Me.BtAnnuler.Text = "Annuler"
        '
        'FrAdminBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(440, 142)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtAttacher)
        Me.Controls.Add(Me.BtFichierLDF)
        Me.Controls.Add(Me.TxFichierldf)
        Me.Controls.Add(Me.TxFichiermdf)
        Me.Controls.Add(Me.TxNomBase)
        Me.Controls.Add(Me.BtFichiermdf)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrAdminBase"
        Me.Text = "FrAdminBase"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal connection As SqlClient.SqlConnection, ByVal MyUser As Utilisateur)
        Me.New(connection)
        User = MyUser
    End Sub

    Private Sub BtAttacher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAttacher.Click
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If

        Dim strSql As String = ""

        Try
            '* Attacher la base de données
            strSql = "EXECUTE sp_attach_db @dbname = N'" & Me.TxNomBase.Text & "', " & _
              "@filename1 = N'" & Me.TxFichiermdf.Text & "', " & _
              "@filename2 = N'" & Me.TxFichierldf.Text & "'"

            Dim cmd As New SqlClient.SqlCommand(strSql, cn)
            'cmd.CommandText = strSql
            cmd.ExecuteNonQuery()

            MessageBox.Show("Opération Terminée")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtFichiermdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFichiermdf.Click, BtFichierLDF.Click
        Me.OpenFileDialog1.Filter = "Fichier Base de Données|*" & Convert.ToString(CType(sender, Control).Tag)
        Me.OpenFileDialog1.ShowDialog()
        Select Case Convert.ToString(CType(sender, Control).Tag)
            Case ".mdf"
                Me.TxFichiermdf.Text = Me.OpenFileDialog1.FileName
            Case ".ldf"
                Me.TxFichierldf.Text = Me.OpenFileDialog1.FileName
        End Select
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub
End Class

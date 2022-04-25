Public Class FrGestionParametres
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
    Friend WithEvents cbConfigs As System.Windows.Forms.ComboBox
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cbConfigs = New System.Windows.Forms.ComboBox
        Me.btOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cbConfigs
        '
        Me.cbConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConfigs.Location = New System.Drawing.Point(16, 32)
        Me.cbConfigs.Name = "cbConfigs"
        Me.cbConfigs.Size = New System.Drawing.Size(304, 21)
        Me.cbConfigs.TabIndex = 0
        '
        'btOK
        '
        Me.btOK.Location = New System.Drawing.Point(248, 64)
        Me.btOK.Name = "btOK"
        Me.btOK.TabIndex = 1
        Me.btOK.Text = "OK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Choisissez le dossier à charger :"
        '
        'FrGestionParametres
        '
        Me.AcceptButton = Me.btOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(336, 93)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btOK)
        Me.Controls.Add(Me.cbConfigs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrGestionParametres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choix du dossier"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared dsParamLocaux As DataSet
    Private Shared ligneParametre As Integer

    Private Const FICHIER_PARAMETRE As String = "Parametres.xml"
    Private Const CHEMIN_ACTIGRAM_AGRIFACT As String = "Actigram\AgriFact\"

    Public Shared Sub ChargerParametres()
        Dim chemin As String = String.Empty

        chemin = FrGestionParametres.CheminFichierParam()

        If IO.File.Exists(chemin) Then
            dsParamLocaux = New DataSet
            dsParamLocaux.ReadXml(chemin)
            If dsParamLocaux.Tables.Contains("Parametres") Then
                Select Case dsParamLocaux.Tables("Parametres").Rows.Count
                    Case 0
                        dsParamLocaux.Tables("Parametres").Rows.Add(dsParamLocaux.Tables("Parametres").NewRow)
                        ligneParametre = 0
                    Case 1
                        ligneParametre = 0
                    Case Else
                        Dim fr As New FrGestionParametres
                        With fr
                            .cbConfigs.Items.Clear()
                            For i As Integer = 0 To dsParamLocaux.Tables("Parametres").Rows.Count - 1
                                Dim dr As DataRow = dsParamLocaux.Tables("Parametres").Rows(i)
                                .cbConfigs.Items.Add(NomDossier(dr))
                            Next
                            .cbConfigs.SelectedIndex = 0
                            .ShowDialog()
                            ligneParametre = .cbConfigs.SelectedIndex
                        End With
                End Select
            Else
                Throw New Exception("Le fichier Parametres.xml est endommagé")
            End If
        Else
            Throw New Exception("Le fichier Parametres.xml est inéxistant.")
        End If
    End Sub

    Private Shared Function NomDossier(ByVal dr As DataRow) As String
        If dr.Table.Columns.Contains("NomDossier") AndAlso Not IsDBNull(dr("NomDossier")) Then
            Return CStr(dr("NomDossier"))
        Else
            Return String.Format("Base '{0}' sur '{1}'", dr("BASESQL"), dr("ServeurSQL"))
        End If
    End Function


    Public Shared Function ValeurParametre(ByVal nomParametre As String, Optional ByVal valeurDefaut As Object = Nothing) As Object
        Dim result As Object
        If dsParamLocaux.Tables("Parametres").Columns.Contains(nomParametre) _
        AndAlso Not IsDBNull(dsParamLocaux.Tables("Parametres").Rows(ligneParametre).Item(nomParametre)) Then
            result = dsParamLocaux.Tables("Parametres").Rows(ligneParametre).Item(nomParametre)
        Else
            result = valeurDefaut
        End If
        Return result
    End Function

    Public Shared Sub EnregistrerParametre(ByVal nomParametre As String, ByVal valeurParametre As Object, Optional ByVal SauverFichier As Boolean = True)
        If Not dsParamLocaux.Tables("Parametres").Columns.Contains(nomParametre) Then
            dsParamLocaux.Tables("Parametres").Columns.Add(nomParametre, valeurParametre.GetType)
        End If
        dsParamLocaux.Tables("Parametres").Rows(ligneParametre).Item(nomParametre) = valeurParametre
        If SauverFichier Then EnregistrerParametres()
    End Sub

    Public Shared Sub EnregistrerParametres()
        Dim chemin As String = String.Empty

        chemin = FrGestionParametres.CheminFichierParam()

        If IO.File.Exists(chemin) Then
            dsParamLocaux.WriteXml(chemin)
        End If
    End Sub

    Private Sub btOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btOK.Click
        Me.Close()
    End Sub

    'Public Shared Function CheminFichierParam() As String
    '    Dim chemin As String = String.Empty
    '    Dim ancienChemin As String = String.Empty

    '    chemin = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIER_PARAMETRE)

    '    If Not (IO.File.Exists(chemin)) Then
    '        ancienChemin = IO.Path.Combine(Application.StartupPath, FICHIER_PARAMETRE)

    '        If IO.File.Exists(ancienChemin) Then
    '            'création du répertoire Actigram dans le répertoire ApplicationData si nécessaire
    '            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(chemin))

    '            'Déplacement du Parametres.xml au nouvel emplacement
    '            IO.File.Move(ancienChemin, chemin)

    '            chemin = ancienChemin
    '        End If
    '    End If

    '    Return chemin
    'End Function

    Public Shared ReadOnly Property CheminFichierParam() As String
        Get
            Dim chemin As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CHEMIN_ACTIGRAM_AGRIFACT & FICHIER_PARAMETRE)

            If IO.File.Exists(chemin) Then
                Return chemin
            Else
                Dim ancienChemin As String = IO.Path.Combine(Application.StartupPath, FICHIER_PARAMETRE)

                If IO.File.Exists(ancienChemin) Then
                    'création du répertoire Actigram dans le répertoire ApplicationData si nécessaire
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(chemin))

                    IO.File.Move(ancienChemin, chemin)

                    Return ancienChemin
                End If
            End If

            Return String.Empty
        End Get
    End Property
End Class

Imports Actigram

Public Class FrDonnees
    Inherits System.Windows.Forms.Form

    Public ds As New DataSet

    Public Shared mDtA As Donnees.ConfigurationSqlServer
    Public Shared Connexion As SqlClient.SqlConnection

    'Public Shared ReadOnly Property ConfigSqlServer() As Donnees.ConfigurationSqlServer
    '    Get
    '        Return mDtA
    '    End Get
    'End Property

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
    Friend WithEvents BtPersonne As System.Windows.Forms.Button
    Friend WithEvents BtExploitation As System.Windows.Forms.Button
    Friend WithEvents BtMaj As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents LbProgression As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BtPersonne = New System.Windows.Forms.Button
        Me.BtExploitation = New System.Windows.Forms.Button
        Me.BtMaj = New System.Windows.Forms.Button
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.LbProgression = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'BtPersonne
        '
        Me.BtPersonne.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtPersonne.Location = New System.Drawing.Point(0, 184)
        Me.BtPersonne.Name = "BtPersonne"
        Me.BtPersonne.Size = New System.Drawing.Size(96, 32)
        Me.BtPersonne.TabIndex = 0
        Me.BtPersonne.Text = "Personne"
        Me.BtPersonne.Visible = False
        '
        'BtExploitation
        '
        Me.BtExploitation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtExploitation.Location = New System.Drawing.Point(104, 184)
        Me.BtExploitation.Name = "BtExploitation"
        Me.BtExploitation.Size = New System.Drawing.Size(112, 32)
        Me.BtExploitation.TabIndex = 1
        Me.BtExploitation.Text = "Exploitation"
        Me.BtExploitation.Visible = False
        '
        'BtMaj
        '
        Me.BtMaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtMaj.Location = New System.Drawing.Point(52, 14)
        Me.BtMaj.Name = "BtMaj"
        Me.BtMaj.Size = New System.Drawing.Size(224, 24)
        Me.BtMaj.TabIndex = 2
        Me.BtMaj.Text = "Mise A Jour des données"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(52, 14)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(224, 24)
        Me.ProgressBar1.TabIndex = 3
        '
        'LbProgression
        '
        Me.LbProgression.Location = New System.Drawing.Point(52, 14)
        Me.LbProgression.Name = "LbProgression"
        Me.LbProgression.Size = New System.Drawing.Size(224, 24)
        Me.LbProgression.TabIndex = 4
        Me.LbProgression.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrDonnees
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 53)
        Me.Controls.Add(Me.LbProgression)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.BtMaj)
        Me.Controls.Add(Me.BtExploitation)
        Me.Controls.Add(Me.BtPersonne)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrDonnees"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Données"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared Sub UpdateSQLServer(ByVal methode As Donnees.ConfigurationSqlServer.MethodeUpdate, Optional ByVal ignoreErr As Boolean = False)
        Dim err As String = mDtA.UpdateAdapters(methode)
        If Not ignoreErr AndAlso err.Length > 0 Then
            GRC.FrTextMessageBox.Show(err, "Erreur", "Des erreurs se sont produites : ")
        End If
        'Réparer les champs custom et expression qui auraient sautés
        'FrBonCommande.VerifChampsBase(mDtA.Dataset)
        If mDtA.Dataset.Tables("Personne").Columns.Contains("NomPrenom") = False Then
            mDtA.Dataset.Tables("Personne").Columns.Add("NomPrenom", GetType(String), "Nom + iif(Prenom not is null,' ' + Prenom,'')")
        End If
    End Sub

    'Private Sub ProgessValueChanged(ByVal nValue As Integer)
    '    Me.ProgressBar1.Value = nValue
    '    Progression()
    'End Sub

#Region "Affichage"
    'Private Sub FrDonnees_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
    '    If e.ClipRectangle.Height <> 0 And e.ClipRectangle.Width <> 0 Then
    '        Dim br As New Drawing2D.LinearGradientBrush(e.ClipRectangle, Color.White, Color.Blue, Drawing2D.LinearGradientMode.BackwardDiagonal)
    '        e.Graphics.FillRectangle(br, e.ClipRectangle)
    '    End If
    'End Sub

    'Private Sub Progression()
    '    Dim pt1 As PointF
    '    Dim ft As New Font("Arial", 8)
    '    Dim strText As String
    '    Dim g As Graphics
    '    g = Me.LbProgression.CreateGraphics
    '    strText = "Chargement des données"
    '    pt1.X = Convert.ToInt32((Me.LbProgression.Width / 2) - (g.MeasureString(strText, ft).Width / 2))
    '    pt1.Y = Convert.ToInt32((Me.LbProgression.Height / 2) - (g.MeasureString(strText, ft).Height / 2))

    '    Dim rc As Rectangle
    '    Dim pt As Point
    '    g.Clear(Me.LbProgression.BackColor)
    '    pt.X = 0
    '    pt.Y = 0
    '    rc.Location = pt
    '    rc.Height = Me.LbProgression.Height
    '    rc.Width = Convert.ToInt32((Me.ProgressBar1.Value * Me.LbProgression.Width) / Me.ProgressBar1.Maximum)
    '    If rc.Width > 0 Then
    '        Dim br As New Drawing2D.LinearGradientBrush(rc, Color.White, Color.Yellow, Drawing2D.LinearGradientMode.Vertical)
    '        g.FillRectangle(br, rc)
    '        g.DrawString(strText, ft, Brushes.Black, pt1)
    '    End If
    'End Sub

    'Private Sub FrDonnees_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    '    Me.Refresh()
    'End Sub
#End Region

#Region "Gestion en mode serveur"
    'Public Function ChargerFromSQL() As DataSet
    '    Dim d As DataSet
    '    'Charger les données dans le dataset
    '    d = ChargerDataset(FrApplication.Utilisateur, FrApplication.Pwd)
    '    'Configurer les dataadapters du ConfigSqlServer
    '    FrDonnees.ConfigSqlServer.ChargeDonneesFromSchema(False, False, FrApplication.Utilisateur, FrApplication.Pwd)
    '    Return d
    'End Function

    Public Shared Function GetstrConnexion(ByVal Utilisateur As String, ByVal MotPasse As String) As String
        Dim strConnexion As String = "data source={0};initial catalog={1};user id={2};password={3};persist security info=True;Connect Timeout=10"
        Dim strBaseSQL As String = CStr(ParametresApplication.ValeurParametre("BASESQL", "Agrifact"))
        Dim strServerSQL As String = CStr(ParametresApplication.ValeurParametre("ServeurSQL", "DEV1\Agrifact"))
        If Utilisateur = "sa" Then MotPasse = CStr(ParametresApplication.ValeurParametre("saPwd", "ludo"))

        GRC.FrFusion.Base = strBaseSQL
        GRC.FrFusion.Server = strServerSQL
        GRC.FrFusion.sa = "sa"
        GRC.FrFusion.pwd = CStr(ParametresApplication.ValeurParametre("saPwd", "ludo"))

        Return String.Format(strConnexion, strServerSQL, strBaseSQL, Utilisateur, MotPasse)
    End Function

    Private Function ChargerDataset(ByVal Utilisateur As String, ByVal MotPasse As String) As DataSet
        Dim data As New DataSet

        Dim strMessagePerso As String = ""
        Dim Fill As Boolean = True
        Dim FillParam As Boolean = True
        Dim Synchro As Boolean = False

        Dim cn As SqlClient.SqlConnection

        Dim ConnexionOk As Boolean = False

        data.EnforceConstraints = False

        Try
            Dim User As String = FrApplication.Utilisateur
            Dim Pwd As String = FrApplication.Pwd

            cn = New SqlClient.SqlConnection(GetstrConnexion(Utilisateur, MotPasse))
            FrDonnees.Connexion = cn
            cn.Open()
            ConnexionOk = True

            mDtA = New Donnees.ConfigurationSqlServer
            mDtA.Connexion = cn
            mDtA.Dataset = data


            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim def As DefinitionDonnees = DefinitionDonnees.LoadXml(asm.GetManifestResourceStream("AgriFact.DefinitionDonnees.xml"))

            Dim frP As New FrProgressBar
            With frP
                '.StartPosition = FormStartPosition.CenterParent
                '.ShowInTaskbar = False
                .Maximum = def.Tables.Count + def.Relations.Count
                .Show()
            End With
            Application.DoEvents()

            Dim dt As SqlClient.SqlDataAdapter
            For Each t As Table In def.Tables
                Try
                    frP.Text = t.nom
                    frP.Value += 1
                    mDtA.ChargeDonnees(dt, t.nom, t.cle, t.tri, CBool(IIf(t.param, FillParam, Fill)), t.autonum, Synchro, String.Format(t.filtre, Utilisateur, MotPasse))
                    strMessagePerso = dt.SelectCommand.CommandText
                Catch ex As Exception
                    If Not t.ignoreErr Then
                        Throw ex
                    End If
                End Try
            Next

            frP.Text = "Définition des Relations"

            Dim dr As DataRelation
            For Each r As Relation In def.Relations
                'frP.Text = r.nom
                frP.Value += 1
                dr = New DataRelation(r.nom, data.Tables(r.parentTable).Columns(r.parentCol), data.Tables(r.childTable).Columns(r.childCol), r.creerContraintes)
                strMessagePerso = dr.ParentTable.TableName & dr.ChildTable.TableName
                data.Relations.Add(dr)
                If dr.ChildKeyConstraint IsNot Nothing Then
                    Select Case r.childDeleteRule
                        Case "None"
                            dr.ChildKeyConstraint.UpdateRule = Rule.None
                            dr.ChildKeyConstraint.DeleteRule = Rule.None
                        Case "Cascade"
                            dr.ChildKeyConstraint.UpdateRule = Rule.Cascade
                            dr.ChildKeyConstraint.DeleteRule = Rule.Cascade
                    End Select
                End If
            Next


            'Ajout de regles spécifiques
            data.Tables("Personne").Columns("DateCreation").ExtendedProperties.Add("DefaultValue", "Now")
            data.Tables("Personne").Columns("DateCreation").DefaultValue = Now.ToShortDateString

            strMessagePerso = dr.ParentTable.TableName & dr.ChildTable.TableName

            data.Tables("Personne").Columns.Add("NomPrenom", GetType(String), "Nom + iif(Prenom not is null,' ' + Prenom,'')")

            If data.Tables("Produit").Columns.Contains("nFournisseur") Then
                dr = New DataRelation("FournisseurProduit", data.Tables("Entreprise").Columns("nEntreprise"), data.Tables("Produit").Columns("nFournisseur"))
                data.Relations.Add(dr)
                dr.ChildKeyConstraint.DeleteRule = Rule.None
            End If

            With data.Tables("TVA").Columns("nTVA")
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With

            'Correction des libellés TVA
            Dim rws() As DataRow = data.Tables("TVA").Select("TTVA Is Null")
            If rws.Length > 0 Then
                rws(0).Item("TTVA") = ""
                rws(0).Item("TLibelle") = DBNull.Value
                data.Tables("TVA").AcceptChanges()
            End If

            'Fin
            frP.Close()

            data.EnforceConstraints = True

            Return data

        Catch ex As Exception
            If ConnexionOk = False Then
                MessageBox.Show("Problème de connexion au serveur :" & vbCrLf & ex.Message)
                Environment.Exit(0)
                Return Nothing
            ElseIf data.HasErrors = True Then
                strMessagePerso = ""
                Dim tb As DataTable
                For Each tb In data.Tables
                    If tb.HasErrors = True Then
                        Dim rw As DataRow
                        For Each rw In tb.GetErrors
                            strMessagePerso += rw.RowError & vbCrLf
                        Next
                    End If
                Next
                MessageBox.Show(strMessagePerso & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
                Return Nothing
            Else
                Throw New Exception(ex.Message, ex)
            End If
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
            End If
        End Try
    End Function
#End Region

End Class


#Region "Classes pour chargement DefinitionDonnees.xml"
Public Class Table
    <Xml.Serialization.XmlAttribute()> Public nom As String = ""
    <Xml.Serialization.XmlAttribute()> Public cle As String = ""
    <Xml.Serialization.XmlAttribute()> Public tri As String = ""
    <Xml.Serialization.XmlAttribute()> Public autonum As String = ""
    <Xml.Serialization.XmlAttribute()> Public filtre As String = ""
    <Xml.Serialization.XmlAttribute()> Public param As Boolean = False
    <Xml.Serialization.XmlAttribute()> Public ignoreErr As Boolean = False
End Class

Public Class Relation
    <Xml.Serialization.XmlAttribute()> Public nom As String = ""
    <Xml.Serialization.XmlAttribute()> Public parentTable As String = ""
    <Xml.Serialization.XmlAttribute()> Public parentCol As String = ""
    <Xml.Serialization.XmlAttribute()> Public childTable As String = ""
    <Xml.Serialization.XmlAttribute()> Public childCol As String = ""
    <Xml.Serialization.XmlAttribute()> Public creerContraintes As Boolean = False
    <Xml.Serialization.XmlAttribute()> Public childDeleteRule As String = ""
End Class

Public Class DefinitionDonnees
    <Xml.Serialization.XmlArray("Tables"), Xml.Serialization.XmlArrayItem("Table", GetType(Table))> Public Tables As ArrayList
    <Xml.Serialization.XmlArray("Relations"), Xml.Serialization.XmlArrayItem("Relation", GetType(Relation))> Public Relations As ArrayList

    Public Shared Function LoadXml(ByVal fichier As String) As DefinitionDonnees
        Dim fs As New IO.FileStream(fichier, IO.FileMode.Open)
        Return LoadXml(fs)
    End Function

    Public Shared Function LoadXml(ByVal s As IO.Stream) As DefinitionDonnees
        Dim xser As New Xml.Serialization.XmlSerializer(GetType(DefinitionDonnees))
        Dim df As DefinitionDonnees = CType(xser.Deserialize(s), DefinitionDonnees)
        s.Close()
        Return df
    End Function

    Public Sub WriteXml(ByVal fichier As String)
        Dim xser As New Xml.Serialization.XmlSerializer(GetType(DefinitionDonnees))
        Dim sw As New IO.StreamWriter(fichier)
        xser.Serialize(sw, Me)
        sw.Close()
    End Sub

End Class
#End Region


Public Class FrSituationEvenement
    Inherits FrBase
    Dim dv As DataView
    Public Event OuvrirDevis(ByVal nDevis As Object)
    Public Event OuvrirEvenement(ByVal nEvenement As Object)
    Private nEvenementDepart As Integer

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    Public Sub New(ByRef momDataview As DataView)
        Me.New()
        dv = momDataview
        ds = dv.Table.DataSet
    End Sub

    Public Sub New(ByRef momDataset As DataSet)
        Me.New()
        ds = momDataset
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
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrSituationEvenement))
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(328, 134)
        Me.TreeView1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'FrSituationEvenement
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(328, 134)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrSituationEvenement"
        Me.Text = "Organigramme"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Situation(ByVal nEvenement As Object, ByVal strTypeDepart As String)
        Dim nOrigine As Integer
        Dim strType As String = ""
        nOrigine = GetOrigine(ds, nEvenement, "Evenement", nOrigine, strType)
        Dim nEDepart As Integer = Convert.ToInt32(nEvenement)
        nEvenementDepart = nEDepart
        Me.TreeView1.Nodes.Clear()
        Me.TreeView1.BeginUpdate()
        Dim rw() As DataRow
        If strType = "" Then strType = strTypeDepart
        rw = ds.Tables(strType).Select("n" & strType & "=" & nOrigine)
        If rw.GetUpperBound(0) >= 0 Then
            Dim strLibelle As String = ""
            Select Case strType
                Case "Evenement"
                    strLibelle = Convert.ToString(rw(0).Item("Libelle"))
                Case "Devis"
                    strLibelle = "Devis n°" & Convert.ToString(rw(0).Item("nDevis")) & " du " & Convert.ToDateTime(rw(0).Item("DtValiditerDebut")).ToString("dd/MM/yy") & " Au " & Convert.ToDateTime(rw(0).Item("DtValiditerFin")).ToString("dd/MM/yy")
            End Select
            Dim ndNew As New TreeNode(strLibelle)

            If nEDepart = nOrigine And strType = strTypeDepart Then
                ndNew.NodeFont = New Font(Me.TreeView1.Font, FontStyle.Underline)
            End If
            ndNew.Tag = nOrigine
            'RemplirTreeviewDevis(nOrigine, ndNew)
            Select Case strType
                Case "Evenement"
                    ndNew.ImageIndex = 0
                    ndNew.ImageIndex = 0
                Case "Devis"
                    ndNew.ImageIndex = 1
                    ndNew.ImageIndex = 1
            End Select
            Me.TreeView1.Nodes.Add(RemplirTreeView(nOrigine, strType, nEDepart, strTypeDepart, ndNew))
        End If
        Me.TreeView1.EndUpdate()
        Me.TreeView1.ExpandAll()
    End Sub

    Public Function RemplirTreeView(ByVal nOrigine As Object, ByVal strTable As String, ByVal nEDepart As Integer, ByVal strTableDepart As String, ByRef nd As TreeNode) As TreeNode
        Dim rw() As DataRow
        Dim rwi As DataRow

        rw = ds.Tables("Evenement").Select("nOrigine=" & Convert.ToString(nOrigine) & " And Origine Like '*Fr" & strTable & "*'")

        For Each rwi In rw
            Dim strTmpTable As String = ""
            Dim strLibelle As String = ""
            strLibelle = Convert.ToString(rwi.Item("Libelle"))

            Dim ndNew As New TreeNode(strLibelle)
            If nEDepart = Convert.ToInt32(rwi.Item("nEvenement")) Then
                ndNew.NodeFont = New Font(Me.TreeView1.Font, FontStyle.Underline)
            End If
            ndnew.Tag = rwi.Item("nEvenement")
            ndNew.ImageIndex = 0
            ndNew.ImageIndex = 0

            nd.Nodes.Add(ndNew)

            RemplirTreeView(rwi.Item("nEvenement"), "Evenement", nEDepart, strTableDepart, ndNew)
        Next

        If ds.Tables.Contains("Devis") Then
            rw = ds.Tables("Devis").Select("nOrigine=" & Convert.ToString(nOrigine) & " And Origine Like '*Fr" & strTable & "*'")

            For Each rwi In rw
                Dim strTmpTable As String = ""
                Dim strLibelle As String = ""
                If Not rwi.Item("nDevis") Is DBNull.Value And Not rwi.Item("DtValiditerDebut") Is DBNull.Value And Not rwi.Item("DtValiditerFin") Is DBNull.Value Then
                    strLibelle = "Devis n°" & Convert.ToString(rwi.Item("nDevis")) & " du " & Convert.ToDateTime(rwi.Item("DtValiditerDebut")).ToString("dd/MM/yy") & " Au " & Convert.ToDateTime(rwi.Item("DtValiditerFin")).ToString("dd/MM/yy")
                Else
                    strLibelle = "Devis"
                End If

                Dim ndNew As New TreeNode(strLibelle)
                ndnew.Tag = rwi.Item("nDevis")
                ndNew.ImageIndex = 1
                ndNew.ImageIndex = 1
                nd.Nodes.Add(ndNew)

                RemplirTreeView(rwi.Item("nDevis"), "Devis", nEDepart, strTableDepart, ndNew)
            Next
        End If

        Return nd

    End Function

    Public Sub Situation(ByVal nEvenement As Object, ByRef nd As TreeNode)
        Dim rw() As DataRow
        rw = ds.Tables("Entreprise").Select("nEntreprise=" & Convert.ToString(nEvenement))
        If rw.GetUpperBound(0) >= 0 Then
            nd.Nodes.Add(Convert.ToString(rw(0).Item("Libelle")))
        End If
    End Sub

    Public Shared Function GetOrigine(ByRef ds As DataSet, ByVal nEvenement As Object, ByVal strTable As String, Optional ByRef nOrigine As Integer = 0, Optional ByRef TableOrigine As String = "") As Integer
        Dim rw() As DataRow
        rw = ds.Tables(strTable).Select("n" & strTable & "=" & Convert.ToString(nEvenement))
        If rw.GetUpperBound(0) >= 0 Then
            nOrigine = Convert.ToInt32(nEvenement)
            TableOrigine = strTable
            If Not rw(0).Item("nOrigine") Is DBNull.Value Then
                Dim strTb As String = ""
                If Convert.ToString(rw(0).Item("Origine")).IndexOf("FrEvenement") >= 0 Then
                    strTb = "Evenement"
                End If
                If Convert.ToString(rw(0).Item("Origine")).IndexOf("FrDevis") >= 0 Then
                    strTb = "Devis"
                End If
                GetOrigine(ds, rw(0).Item("nOrigine"), strTb, nOrigine, TableOrigine)
            End If
        End If
        Return nOrigine
    End Function

    Private Sub TreeView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.DoubleClick
        If Not Me.Owner Is Nothing And Not dv Is Nothing Then
            If Me.TreeView1.SelectedNode.ImageIndex <> 1 Then
                'Me.Owner.BindingContext(dv).Position = dv.Find(Me.TreeView1.SelectedNode.Tag)
                If Convert.ToInt32(Me.TreeView1.SelectedNode.Tag) = Me.nEvenementDepart Then Exit Sub
                RaiseEvent OuvrirEvenement(Me.TreeView1.SelectedNode.Tag)
                Exit Sub
            Else
                RaiseEvent OuvrirDevis(Me.TreeView1.SelectedNode.Tag)
                Exit Sub
            End If
        End If
    End Sub
End Class

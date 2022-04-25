Imports System.Data.SqlClient

Public Class FrCubes

    Private Const CHEMINFICHIERXML As String = "Cubes\Cubes.xml"

    Private _DataSetCubes As ClassLibraryCubes.DataSetCubes
    Private _CodeCubeEnCours As String

#Region "Constructeurs"
    Public Sub New()

        ' Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        Me._DataSetCubes = New ClassLibraryCubes.DataSetCubes
    End Sub
#End Region

#Region "Page"
    Private Sub FrCubes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        'Application du style au GradientCaption
        GestionMenu.Menu.ApplyFrameHeaderStyle(Me.GradientCaptionModelesXML)

        With Me.ImageListTreeView.Images
            .Add("rpt", My.Resources.report)
        End With
    End Sub

    Private Sub FrCubes_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.ChargerModeles()
    End Sub
#End Region

#Region "TreeView"
    Private Sub TreeViewModelesXML_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewModelesXML.AfterSelect
        Me._CodeCubeEnCours = CType(e.Node.Tag, String)
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerModeles()
        Cursor.Current = Cursors.WaitCursor
        Application.DoEvents()

        Me.TreeViewModelesXML.BeginUpdate()

        Try
            Dim cheminFichier As String = CheminComplet(CHEMINFICHIERXML)

            If System.IO.File.Exists(cheminFichier) Then
                Me._DataSetCubes.ReadXml(cheminFichier)

                If (Me._DataSetCubes.Tables("Cube").Rows.Count > 0) Then
                    'Récupération des lignes triées
                    Dim drCube() As ClassLibraryCubes.DataSetCubes.CubeRow = CType(Me._DataSetCubes.Tables("Cube").Select("", "CodeParent,le_titre"), ClassLibraryCubes.DataSetCubes.CubeRow())

                    For Each dr As ClassLibraryCubes.DataSetCubes.CubeRow In drCube
                        AjouterNoeud(dr)
                    Next
                Else
                    MsgBox("Le fichier " & cheminFichier & " est vide.", MsgBoxStyle.Exclamation, "")
                End If
            Else
                MsgBox("Le fichier " & cheminFichier & " est inexistant.", MsgBoxStyle.Exclamation, "")
            End If
        Finally
            Me.TreeViewModelesXML.EndUpdate()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub AjouterNoeud(ByVal dr As ClassLibraryCubes.DataSetCubes.CubeRow)
        Dim n As New TreeNode

        With n
            If Not (dr.Isle_titreNull) Then
                .Text = dr.le_titre
            Else
                .Text = dr.CodeCube
            End If

            .ImageKey = "rpt"
            .Tag = dr.CodeCube
        End With

        If (dr.IsCodeParentNull) Then
            Me.TreeViewModelesXML.Nodes.Add(n)
        Else
            Dim i As Integer = 0

            For Each node As System.Windows.Forms.TreeNode In Me.TreeViewModelesXML.Nodes
                If (dr.CodeParent = Convert.ToString(node.Tag)) Then
                    Me.TreeViewModelesXML.Nodes(i).Nodes.Add(n)
                End If

                i = i + 1
            Next
        End If
    End Sub

    Private Sub AfficherCube()
        Dim drCube() As ClassLibraryCubes.DataSetCubes.CubeRow = CType(Me._DataSetCubes.Tables("Cube").Select("CodeCube='" & Replace(Me._CodeCubeEnCours, "'", "''") & "'"), ClassLibraryCubes.DataSetCubes.CubeRow())

        For Each dr As ClassLibraryCubes.DataSetCubes.CubeRow In drCube
            Dim gestCube As New ClassLibraryCubes.GestionCube(dr, My.Settings.AgrifactConnString)

            gestCube.ChargerCube()
        Next
    End Sub
#End Region

#Region "ToolStripMenu"
    Private Sub LancerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LancerToolStripMenuItem.Click
        Me.AfficherCube()
    End Sub
#End Region

End Class
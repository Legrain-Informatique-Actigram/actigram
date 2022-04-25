Public Class FrAccueil

    Private _cheminFichierXML As String

#Region "Form"
    Private Sub FrAccueil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AfficherTitre()

        Me.OuvrirFichierXML()
    End Sub
#End Region

#Region "ToolStripMenu"
    Private Sub DupliquerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DupliquerToolStripMenuItem.Click
        Me.DupliquerLigne()
    End Sub

    Private Sub ToolStripButtonEnregistrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonEnregistrer.Click
        Me.EnregistrerXML(Me._cheminFichierXML)
    End Sub

    Private Sub ToolStripButtonOuvrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonOuvrir.Click
        Me.OuvrirFichierXML()
    End Sub

    Private Sub MAJEnFonctionDuParentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MAJEnFonctionDuParentToolStripMenuItem.Click
        Me.MettreAJourEnFonctionDeParent(GetSelectedRows())
    End Sub
#End Region

#Region "DataGridViewCube"
    Private Sub DataGridViewCube_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridViewCube.SelectionChanged
        Dim listeCubeRow As List(Of ClassLibraryCubes.DataSetCubes.CubeRow) = Me.GetSelectedRows()

        For Each cubeRow As ClassLibraryCubes.DataSetCubes.CubeRow In listeCubeRow
            If Not (cubeRow.IsCodeParentNull) Then
                Me.MAJEnFonctionDuParentToolStripMenuItem.Enabled = True
            Else
                Me.MAJEnFonctionDuParentToolStripMenuItem.Enabled = False
            End If
        Next
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub ChargerFichierXML(ByVal cheminFichier As String)
        If (System.IO.File.Exists(cheminFichier)) Then
            Me._cheminFichierXML = cheminFichier
            Me._DSCubes.Clear()
            Me._DSCubes.ReadXml(cheminFichier)
        End If
    End Sub

    Public Sub CopyRow(ByVal drSource As DataRow, ByVal drDest As DataRow, Optional ByVal colKey As String = "")
        For Each dc As DataColumn In drSource.Table.Columns
            If Not dc.ReadOnly AndAlso Not dc.AutoIncrement And drDest.Table.Columns.Contains(dc.ColumnName) Then
                If (colKey <> String.Empty And Not (dc.ColumnName = colKey)) Then
                    drDest(dc.ColumnName) = drSource(dc.ColumnName)
                Else
                    drDest(dc.ColumnName) = drSource(dc.ColumnName) & " - Copie"
                End If
            End If
        Next
    End Sub

    Private Sub EnregistrerXML(ByVal cheminFichier As String)
        If Me.DataGridViewCube.CurrentRow.IsNewRow Then Exit Sub
        If Me.BindingSourceCube.Position < 0 Then Exit Sub

        If (System.IO.File.Exists(cheminFichier)) Then
            Me.BindingSourceCube.EndEdit()

            Dim stream As New System.IO.FileStream(cheminFichier, System.IO.FileMode.Create)

            Me.DSCubes.WriteXml(stream)

            MsgBox("Enregistrement terminé.", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub OuvrirFichierXML()
        With Me.OpenFileDialogChoixFichier
            .Filter = "Fichiers texte (*.xml)|*.xml"
            .Multiselect = False

            If .ShowDialog = DialogResult.OK Then
                Me.ChargerFichierXML(.FileName)
            End If

            Me.AfficherTitre()
        End With
    End Sub

    Private Sub DupliquerLigne()
        If Me.DataGridViewCube.CurrentRow.IsNewRow Then Exit Sub
        If Me.BindingSourceCube.Position < 0 Then Exit Sub

        Dim curDrv As DataRowView = CType(Me.BindingSourceCube.Current, DataRowView)
        Dim newDrv As DataRowView = CType(Me.BindingSourceCube.AddNew, DataRowView)

        If Not newDrv Is Nothing Then
            newDrv.BeginEdit()
            CopyRow(curDrv.Row, newDrv.Row, "CodeCube")
            newDrv.EndEdit()
            Me.BindingSourceCube.ResetBindings(False)
        End If
    End Sub

    Private Function GetSelectedRows() As List(Of ClassLibraryCubes.DataSetCubes.CubeRow)
        Dim listeCubeRow As New List(Of ClassLibraryCubes.DataSetCubes.CubeRow)

        For Each row As DataGridViewRow In Me.DataGridViewCube.SelectedRows
            If row.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf row.DataBoundItem Is DataRowView Then Continue For

            Dim cubeRow As ClassLibraryCubes.DataSetCubes.CubeRow = DirectCast(DirectCast(row.DataBoundItem, DataRowView).Row, ClassLibraryCubes.DataSetCubes.CubeRow)

            listeCubeRow.Add(cubeRow)
        Next

        Return listeCubeRow
    End Function

    Private Sub MettreAJourEnFonctionDeParent(ByVal listeCubeRow As List(Of ClassLibraryCubes.DataSetCubes.CubeRow))
        For Each cubeRow As ClassLibraryCubes.DataSetCubes.CubeRow In listeCubeRow
            'Recherche de la ligne parente
            Dim cubeRowParente As ClassLibraryCubes.DataSetCubes.CubeRow = Me.RecupererLigneParente(cubeRow)

            If Not (cubeRowParente.IsSqlNull) Then
                cubeRow.Sql = cubeRowParente.Sql
            Else
                cubeRow.Sql = String.Empty
            End If

            If Not (cubeRowParente.Isformat_defautNull) Then
                cubeRow.format_defaut = cubeRowParente.format_defaut
            Else
                cubeRow.format_defaut = String.Empty
            End If

            If Not (cubeRowParente.Isle_champ_dateNull) Then
                cubeRow.le_champ_date = cubeRowParente.le_champ_date
            Else
                cubeRow.le_champ_date = String.Empty
            End If

            If Not (cubeRowParente.Isle_type_dateNull) Then
                cubeRow.le_type_date = cubeRowParente.le_type_date
            Else
                cubeRow.le_type_date = String.Empty
            End If

            If Not (cubeRowParente.Isles_champs_formulesNull) Then
                cubeRow.les_champs_formules = cubeRowParente.les_champs_formules
            Else
                cubeRow.les_champs_formules = String.Empty
            End If

            If Not (cubeRowParente.Isles_dimensionsNull) Then
                cubeRow.les_dimensions = cubeRowParente.les_dimensions
            Else
                cubeRow.les_dimensions = String.Empty
            End If

            If Not (cubeRowParente.Isles_dimensions_invNull) Then
                cubeRow.les_dimensions_inv = cubeRowParente.les_dimensions_inv
            Else
                cubeRow.les_dimensions_inv = String.Empty
            End If

            If Not (cubeRowParente.Isles_formulesNull) Then
                cubeRow.les_formules = cubeRowParente.les_formules
            Else
                cubeRow.les_formules = String.Empty
            End If

            If Not (cubeRowParente.Isles_mesuresNull) Then
                cubeRow.les_mesures = cubeRowParente.les_mesures
            Else
                cubeRow.les_mesures = String.Empty
            End If

            If Not (cubeRowParente.Isles_titres_dimNull) Then
                cubeRow.les_titres_dim = cubeRowParente.les_titres_dim
            Else
                cubeRow.les_titres_dim = String.Empty
            End If

            If Not (cubeRowParente.Isles_titres_dim_invNull) Then
                cubeRow.les_titres_dim_inv = cubeRowParente.les_titres_dim_inv
            Else
                cubeRow.les_titres_dim_inv = String.Empty
            End If

            If Not (cubeRowParente.Isles_titres_mesNull) Then
                cubeRow.les_titres_mes = cubeRowParente.les_titres_mes
            Else
                cubeRow.les_titres_mes = String.Empty
            End If

            If Not (cubeRowParente.Isles_types_mesuresNull) Then
                cubeRow.les_types_mesures = cubeRowParente.les_types_mesures
            Else
                cubeRow.les_types_mesures = String.Empty
            End If

            If Not (cubeRowParente.Isp_froozeNull) Then
                cubeRow.p_frooze = cubeRowParente.p_frooze
            Else
                cubeRow.p_frooze = String.Empty
            End If

            If Not (cubeRowParente.Isp_modaleNull) Then
                cubeRow.p_modale = cubeRowParente.p_modale
            Else
                cubeRow.p_modale = String.Empty
            End If
        Next

        MsgBox("Mise à jour terminée.", MsgBoxStyle.Information, "")
    End Sub

    Private Function RecupererLigneParente(ByVal cubeRowEnfant As ClassLibraryCubes.DataSetCubes.CubeRow) As ClassLibraryCubes.DataSetCubes.CubeRow
        Dim cubeRowParente As ClassLibraryCubes.DataSetCubes.CubeRow = Nothing

        For Each row As DataGridViewRow In Me.DataGridViewCube.Rows
            If row.DataBoundItem Is Nothing Then Continue For

            If Not TypeOf row.DataBoundItem Is DataRowView Then Continue For

            Dim cubeRow As ClassLibraryCubes.DataSetCubes.CubeRow = DirectCast(DirectCast(row.DataBoundItem, DataRowView).Row, ClassLibraryCubes.DataSetCubes.CubeRow)

            If (cubeRowEnfant.CodeParent = cubeRow.CodeCube) Then
                cubeRowParente = cubeRow
            End If
        Next

        Return cubeRowParente
    End Function

    Private Sub AfficherTitre()
        Me.Text = My.Application.Info.Title & " (v" & My.Application.Info.Version.ToString() & ") par " & _
                My.Application.Info.CompanyName & " " & Me._cheminFichierXML
    End Sub
#End Region

End Class

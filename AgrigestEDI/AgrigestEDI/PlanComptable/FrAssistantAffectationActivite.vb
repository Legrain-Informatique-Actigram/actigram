Option Strict Off

'TODO FONCTIONNEMENT A REVOIR SUR LES SUPPRESSIONS

Public Class FrAssistantAffectationActivite
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
    Friend WithEvents lstDispo As System.Windows.Forms.ListBox
    Friend WithEvents lstSelect As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtOK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtSupprimerActivite As System.Windows.Forms.Button
    Friend WithEvents BtAjouterActivite As System.Windows.Forms.Button
    Friend WithEvents ds As AgrigestEDI.dsPLC
    Friend WithEvents ActivitesDispoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ActivitesSelectBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSelect As AgrigestEDI.dsPLC
    Friend WithEvents BtCreerActi As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.BtSupprimerActivite = New System.Windows.Forms.Button
        Me.BtAjouterActivite = New System.Windows.Forms.Button
        Me.lstSelect = New System.Windows.Forms.ListBox
        Me.ActivitesSelectBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSelect = New AgrigestEDI.dsPLC
        Me.lstDispo = New System.Windows.Forms.ListBox
        Me.ActivitesDispoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ds = New AgrigestEDI.dsPLC
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtOK = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtCreerActi = New System.Windows.Forms.Button
        CType(Me.ActivitesSelectBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActivitesDispoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtSupprimerActivite
        '
        Me.BtSupprimerActivite.Location = New System.Drawing.Point(248, 184)
        Me.BtSupprimerActivite.Name = "BtSupprimerActivite"
        Me.BtSupprimerActivite.Size = New System.Drawing.Size(40, 23)
        Me.BtSupprimerActivite.TabIndex = 3
        Me.BtSupprimerActivite.Text = "<<"
        Me.ToolTip1.SetToolTip(Me.BtSupprimerActivite, My.Resources.Strings.PLC_EnleverActi)
        '
        'BtAjouterActivite
        '
        Me.BtAjouterActivite.Location = New System.Drawing.Point(248, 152)
        Me.BtAjouterActivite.Name = "BtAjouterActivite"
        Me.BtAjouterActivite.Size = New System.Drawing.Size(40, 23)
        Me.BtAjouterActivite.TabIndex = 2
        Me.BtAjouterActivite.Text = ">>"
        Me.ToolTip1.SetToolTip(Me.BtAjouterActivite, My.Resources.Strings.PLC_AjouterActi)
        '
        'lstSelect
        '
        Me.lstSelect.DataSource = Me.ActivitesSelectBindingSource
        Me.lstSelect.DisplayMember = "ADisplay"
        Me.lstSelect.Location = New System.Drawing.Point(296, 96)
        Me.lstSelect.Name = "lstSelect"
        Me.lstSelect.Size = New System.Drawing.Size(224, 199)
        Me.lstSelect.TabIndex = 4
        Me.lstSelect.ValueMember = "AActi"
        '
        'ActivitesSelectBindingSource
        '
        Me.ActivitesSelectBindingSource.DataMember = "Activites"
        Me.ActivitesSelectBindingSource.DataSource = Me.DsSelect
        Me.ActivitesSelectBindingSource.Sort = "AActi"
        '
        'DsSelect
        '
        Me.DsSelect.DataSetName = "dsPLC"
        Me.DsSelect.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lstDispo
        '
        Me.lstDispo.DataSource = Me.ActivitesDispoBindingSource
        Me.lstDispo.DisplayMember = "ADisplay"
        Me.lstDispo.Location = New System.Drawing.Point(16, 96)
        Me.lstDispo.Name = "lstDispo"
        Me.lstDispo.Size = New System.Drawing.Size(224, 199)
        Me.lstDispo.TabIndex = 1
        Me.lstDispo.ValueMember = "AActi"
        '
        'ActivitesDispoBindingSource
        '
        Me.ActivitesDispoBindingSource.DataMember = "Activites"
        Me.ActivitesDispoBindingSource.DataSource = Me.ds
        Me.ActivitesDispoBindingSource.Sort = "AActi"
        '
        'DsDispo
        '
        Me.ds.DataSetName = "dsPLC"
        Me.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtAnnuler.Location = New System.Drawing.Point(445, 307)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.BtAnnuler.TabIndex = 6
        Me.BtAnnuler.Text = "Annuler"
        '
        'BtOK
        '
        Me.BtOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtOK.Location = New System.Drawing.Point(365, 307)
        Me.BtOK.Name = "BtOK"
        Me.BtOK.Size = New System.Drawing.Size(75, 23)
        Me.BtOK.TabIndex = 5
        Me.BtOK.Text = "OK"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(540, 56)
        Me.Panel1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(296, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = My.Resources.Strings.PLC_SelectActi
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = My.Resources.Strings.PLC_SelectActi2
        '
        'BtCreerActi
        '
        Me.BtCreerActi.Location = New System.Drawing.Point(16, 64)
        Me.BtCreerActi.Name = "BtCreerActi"
        Me.BtCreerActi.Size = New System.Drawing.Size(128, 23)
        Me.BtCreerActi.TabIndex = 0
        Me.BtCreerActi.Text = My.Resources.Strings.PLC_CreerActi
        '
        'FrAssistantAffectationActivite
        '
        Me.AcceptButton = Me.BtOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.BtAnnuler
        Me.ClientSize = New System.Drawing.Size(540, 342)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtCreerActi)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.BtOK)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtSupprimerActivite)
        Me.Controls.Add(Me.BtAjouterActivite)
        Me.Controls.Add(Me.lstSelect)
        Me.Controls.Add(Me.lstDispo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrAssistantAffectationActivite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = My.Resources.Strings.PLC_AffectionActi
        CType(Me.ActivitesSelectBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActivitesDispoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private lstComptes As List(Of dsPLC.ComptesRow)

#Region "Constructeurs"
    Public Sub New(ByVal ds As dsPLC, ByVal lstComptes As List(Of dsPLC.ComptesRow))
        Me.New()
        Me.ds = ds
        Me.lstComptes = lstComptes
    End Sub
#End Region

#Region "Page"
    Private Sub FrAssistantCreationCompte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If ds Is Nothing Then Throw New ApplicationException
        SetChildFormIcon(Me)
        'dsSelect = New dsPLC
        'Using dta As New dsPLCTableAdapters.ActivitesTableAdapter
        '    dta.FillByDossier(DsSelect.Activites, My.User.Name)
        'End Using

        'Init avec les activités existantes
        For Each dr As dsPLC.ComptesRow In lstComptes
            For Each drPlc As dsPLC.PlanComptableRow In dr.GetPlanComptableRows
                DsSelect.Merge(New DataRow() {drPlc.ActivitesRowParent})
            Next
        Next

        'Ne proposer que les activités permises par le PlanType
        With ActivitesDispoBindingSource
            .DataSource = ds
            .Filter = GetFiltreActiPlanType(lstComptes)
        End With
    End Sub
#End Region

#Region "lstDispo"
    Private Sub lstDispo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDispo.SelectedIndexChanged
        BtAjouterActivite.Enabled = lstDispo.SelectedItems.Count > 0
    End Sub

    Private Sub lstDispo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDispo.DoubleClick
        BtAjouterActivite.PerformClick()
    End Sub
#End Region

#Region "lstSelect"
    Private Sub lstSelect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSelect.SelectedIndexChanged
        BtSupprimerActivite.Enabled = lstSelect.SelectedItems.Count > 0
    End Sub

    Private Sub lstSelect_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSelect.DoubleClick
        BtSupprimerActivite.PerformClick()
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtSupprimerActivite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtSupprimerActivite.Click
        'TODO Verif
        ' - L'activité à supprimer n'a pas de reports (sur toutes ses lignes de PLC sur les comptes sélectionnés)
        ' - L'activité à supprimer n'a pas de pièces  (sur tous les comptes sélectionnés)

        lstSelect.BeginUpdate()
        Dim drToDel As New ArrayList
        For Each drv As DataRowView In lstSelect.SelectedItems
            drToDel.Add(drv.Row)
        Next
        For Each dr As DataRow In drToDel
            dr.Delete()
        Next
        lstSelect.EndUpdate()
        BtOK.Enabled = lstSelect.Items.Count > 0
    End Sub

    Private Sub BtAjouterActivite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAjouterActivite.Click
        For Each drv As DataRowView In lstDispo.SelectedItems
            Try
                AjouterActivite(drv)
            Catch ex As ApplicationException
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Attention")
            End Try
        Next
    End Sub

    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        'Ajout des activités eventuellement créées (pas les supprimées)
        Dim dt As DataTable = DsSelect.Activites.GetChanges(DataRowState.Added)
        If dt IsNot Nothing Then
            ds.Activites.Merge(dt)
        End If

        'Construction du filtre sur les activités
        Dim filtActi As String = FiltreActivitesSelectionnees()

        Using dta As New dsPLCTableAdapters.PlanComptableTableAdapter
            'POUR CHAQUE COMPTE SELECTIONNE
            For Each drCpt As dsPLC.ComptesRow In lstComptes
                'AJOUT DANS LE PLAN COMPTABLE DES ACTIVITES SELECTIONNEES
                Dim drsActiPermises() As DataRow = DsSelect.Activites.Select(GetFiltreActiPlanType(drCpt))
                For Each drActi As dsPLC.ActivitesRow In DsSelect.Activites.Rows
                    If drActi.RowState <> DataRowState.Deleted Then
                        'Vérif que le compte accepte cette activité
                        If Array.IndexOf(drsActiPermises, drActi) < 0 Then
                            MsgBox(String.Format(My.Resources.Strings.PLC_ActiInterdite, drActi.AActi, drCpt.CCpt), MsgBoxStyle.Exclamation, "Erreur")
                        Else
                            With ds.PlanComptable
                                If .FindByPlDossierPlCptPlActi(My.User.Name, drCpt.CCpt, drActi.AActi) Is Nothing Then
                                    Dim sLibelle As String = ""
                                    If Not drCpt.IsCLibNull And Not drActi.IsALibNull Then
                                        sLibelle = drCpt.CLib + " - " + drActi.ALib
                                    ElseIf drCpt.IsCLibNull And Not drActi.IsALibNull Then
                                        sLibelle = drActi.ALib
                                    ElseIf Not drCpt.IsCLibNull And drActi.IsALibNull Then
                                        sLibelle = drCpt.CLib
                                    End If
                                    .AddPlanComptableRow(My.User.Name, drCpt.CCpt, drActi.AActi, Microsoft.VisualBasic.Left(sLibelle, 55), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", 0, "", "")
                                End If
                            End With
                        End If
                    End If
                Next

                'SUPPRESSION DES ACTIVITES NON SELECTIONNEES (s'il n'y a pas de pièces)
                For Each dr As dsPLC.PlanComptableRow In ds.PlanComptable.Select(String.Format("PlCpt='{0}' and PlActi not in {1}", drCpt.CCpt, filtActi))
                    Dim i As Nullable(Of Integer) = dta.CompteUtilise(My.User.Name, dr.PlCpt, dr.PlActi)
                    If Not i.HasValue OrElse i.Value = 0 Then
                        dr.Delete()
                    Else
                        MsgBox(String.Format(My.Resources.Strings.PLC_SuppressionImpossible, dr.ItemArray), MsgBoxStyle.Exclamation)
                    End If
                Next
            Next
        End Using

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtCreerActi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCreerActi.Click
        With New FrAssistantCreationActivite(Me.ds)
            .Filter = GetFiltreActiPlanType(lstComptes, "RiCode")
            If .ShowDialog() = DialogResult.OK Then
                'Pour forcer le rafraichissement de la liste
                'lstDispo.DataSource = New DataView(ds.Activites, GetFiltreActiPlanType(lstComptes), "AActi", DataViewRowState.CurrentRows)
            End If
        End With
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub AjouterActivite(ByVal drActi As DataRow)
        'AjouterActivite(drActi("AActi"), drActi("ALib"), drActi("AQte"), drActi("AUnit"))
        If DsSelect.Activites.FindByADossierAActi(Convert.ToString(drActi("ADossier")), Convert.ToString(drActi("aacti"))) Is Nothing Then
            DsSelect.Activites.ImportRow(drActi)
        End If
        lstSelect.SelectedIndex = lstSelect.Items.Count - 1
        BtOK.Enabled = lstSelect.Items.Count > 0
    End Sub

    Private Sub AjouterActivite(ByVal drvActi As DataRowView)
        AjouterActivite(drvActi.Row)
        'AjouterActivite(drvActi("AActi"), drvActi("ALib"), drvActi("AQte"), drvActi("AUnit"))
    End Sub

    Private Sub AjouterActivite(ByVal aacti As String, ByVal alib As String, ByVal aqte As Double, ByVal aunit As String)
        'TODO Vérifs à faire ?

        'Ajout dans la table des activités selectionnées

        With DsSelect.Activites
            If .FindByADossierAActi(My.User.Name, aacti) Is Nothing Then
                Dim drActi As dsPLC.ActivitesRow = .NewActivitesRow
                With drActi
                    .ADossier = My.User.Name
                    .AActi = aacti
                    .ALib = alib
                    .AQte = aqte
                    .AUnit = aunit
                End With
                .Rows.Add(drActi)
            End If
        End With

        'lstSelect.DataSource = New DataView(dsSelect.Tables("Activites"))
        lstSelect.SelectedIndex = lstSelect.Items.Count - 1
        BtOK.Enabled = lstSelect.Items.Count > 0
    End Sub

    Private Function FiltreActivitesSelectionnees() As String
        Dim filtActi As String
        With DsSelect.Activites.Rows
            Dim actis(.Count - 1) As String
            For i As Integer = 0 To .Count - 1
                If .Item(i).RowState <> DataRowState.Deleted Then
                    actis(i) = .Item(i).Item("AActi")
                End If
            Next
            filtActi = String.Format("('{0}')", String.Join("','", actis))
        End With
        Return filtActi
    End Function
#End Region

#Region "Gestion des activités interdites ou permises"
    Private Function GetFiltreActiPlanType(ByVal drCompte As dsPLC.ComptesRow) As String
        Dim a As New List(Of dsPLC.ComptesRow)
        a.Add(drCompte)
        Return GetFiltreActiPlanType(a)
    End Function

    Private Function GetFiltreActiPlanType(ByVal listeComptes As List(Of dsPLC.ComptesRow), Optional ByVal NomCol As String = "AActi") As String
        Dim filtActi As String
        Dim actisInterdit As New List(Of String)
        Dim actisPermis As New List(Of String)

        For Each drCpt As dsPLC.ComptesRow In listeComptes
            Dim rws() As dsPLC.PlanTypeRow = ds.PlanType.Select(String.Format("PlCpt='{0}'", drCpt("CCpt")))
            If rws.Length > 0 Then
                If Not rws(0).IsPlActiNull Then AppendActis(actisInterdit, rws(0).PlActi)
                If Not rws(0).IsPlActiPermisNull Then AppendActis(actisPermis, rws(0).PlActiPermis)
            End If
        Next

        filtActi = String.Format("NOT {0} OR {1}", BuildCriteria(actisInterdit), BuildCriteria(actisPermis))
        filtActi = String.Format(filtActi, NomCol)
        Return filtActi
    End Function

    Private Sub AppendActis(ByVal list As List(Of String), ByVal actis As String)
        Dim actisCpt() As String = Split(actis, ";")
        For Each s As String In actisCpt
            If Not list.Contains(s) Then
                list.Add(s)
            End If
        Next
    End Sub

    Private Function BuildCriteria(ByVal list As List(Of String)) As String
        If list.Count > 0 Then
            Return String.Format("({{0}} LIKE '{0}*')", String.Join("*' OR {0} LIKE '", list.ToArray))
        Else
            Return "(1=0)"
        End If
    End Function
#End Region

End Class

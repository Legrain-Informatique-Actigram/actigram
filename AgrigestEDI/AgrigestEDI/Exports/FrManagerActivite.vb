Imports System.Windows.Forms

''' <summary>
''' permet de faire les réaffectation d'activité
''' </summary>
''' <remarks></remarks>
Public Class FrManagerActivite
    'TODO EXTERNALISATION ET CORRECTION MESSAGES

    Private _DataFile As DataTable
    ''' <summary>
    ''' datatable de données brute rentrante
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataFile() As DataTable
        Get
            Return _DataFile
        End Get
        Set(ByVal value As DataTable)
            _DataFile = value
        End Set
    End Property

    Private _DataActivite As DataTable
    ''' <summary>
    ''' datatable de sortie avec les données nettoyé
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataActivite() As DataTable
        Get
            Return _DataActivite
        End Get

    End Property

    Private bCharger As Boolean = False
    ''' <summary>
    ''' lancement
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FrManagerFichierAnalyse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.PlanTypeTableAdapter.Fill(Me.DsPLC.PlanType)
            Me.RicaTableAdapter.Fill(Me.DsPLC.Rica)

            bCharger = True
            With dgvAffectationActivite
                AddHandler .DataError, AddressOf dg_DataError
            End With
            'chargement du tableau Activité
            Dim dtTableExplorationActivite As New DataTable
            For Each xActi As DataRow In AgriTools.SelectDistinct(_DataFile, "Activite").Rows
                If xActi("Activite").ToString <> "" Then
                    Dim xRow As DataRow = dtTableExplorationActivite.NewRow
                    xRow(dgvAvantActivite.Name) = xActi("Activite").ToString
                    If Me.DsPLC.Rica.Select(String.Format("'{0}' like RiCode+'*'", xActi("Activite").ToString)).Length > 0 OrElse xActi("Activite").ToString = "0000" Then
                        xRow(dgvApresActivite.Name) = xActi("Activite").ToString
                    End If
                    dtTableExplorationActivite.Rows.Add(xRow)
                End If
            Next
            dgvAffectationActivite.DataSource = dtTableExplorationActivite
            bCharger = False
        Catch ex As Exception
            Throw New ApplicationException("Problème de chargement de l'affectation des activités", ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    ''' <summary>
    ''' vérifie que tous les champs saisi ne sont pas en double et qu'ils soit tous remplis
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValider.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            'Vérifie que tous les champs sont saisie
            Dim xTemp As DataTable = CType(dgvAffectationActivite.DataSource, DataTable)
            If xTemp Is Nothing Then Exit Sub
            For Each xActi As DataRow In xTemp.Rows
                If xActi(dgvApresActivite.Name).ToString = "" Then
                    MsgBox("Veuillez remplir tous les champs de correspondance pour les activités", MsgBoxStyle.Critical, "Réaffectation")
                    Exit Sub
                End If
            Next
            'vérifie qu'il n'y ai pas deux fois le meme
            If AgriTools.SelectDistinct(xTemp, dgvAvantActivite.Name).Rows.Count <> AgriTools.SelectDistinct(xTemp, dgvApresActivite.Name).Rows.Count Then
                MsgBox("Veuillez ne pas regrouper vos lignes d'activité", MsgBoxStyle.Critical, "Importation")
                Exit Sub
            End If
        Catch ex As Exception
            Throw New ApplicationException("Vérification de la saisie de l'affectation des champs", ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try

        _DataActivite = CType(dgvAffectationActivite.DataSource, DataTable)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    ''' <summary>
    ''' bouton d'annulation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class

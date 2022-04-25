Public Class FrOpeCaisse

    Private modif As Boolean
    Private _nCaisse As Integer = -1
    Private _id As Integer = -1
    Private _type As DsAgrifact.JournalCaisseDataTable.TypeCaisse

#Region "Props"
    Public Property nCaisse() As Integer
        Get
            Return _nCaisse
        End Get
        Set(ByVal value As Integer)
            _nCaisse = value
        End Set
    End Property

    Public Property IdMvtCaisse() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Type() As DsAgrifact.JournalCaisseDataTable.TypeCaisse
        Get
            Return _type
        End Get
        Set(ByVal value As DsAgrifact.JournalCaisseDataTable.TypeCaisse)
            _type = value
        End Set
    End Property

    Private ReadOnly Property CurrentJournalRow() As DsAgrifact.JournalCaisseRow
        Get
            If Me.JournalCaisseBindingSource.Current Is Nothing Then
                Return Nothing
            Else
                Return DirectCast(DirectCast(Me.JournalCaisseBindingSource.Current, DataRowView).Row, DsAgrifact.JournalCaisseRow)
            End If
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal nCaisse As Integer, Optional ByVal type As DsAgrifact.JournalCaisseDataTable.TypeCaisse = PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond)
        Me.New()
        Me.nCaisse = nCaisse
        Me.Type = type
    End Sub

    Public Sub New(ByVal nCaisse As Integer, ByVal idMvt As Integer)
        Me.New()
        Me.nCaisse = nCaisse
        Me.IdMvtCaisse = idMvt
    End Sub
#End Region

#Region "Form"
    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If DemanderEnregistrement() Then
                If modif Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        'Remplir le combo
        FillCb(GetType(DsAgrifact.JournalCaisseDataTable.TypeCaisse), TypeComboBox, Me.Type, True)

        ConfigCurrencyControl(MontantTextBox)
        ConfigDataTableEvents(Me.DsAgrifact.JournalCaisse, AddressOf MajBoutons)
        ChargerDonnees()
    End Sub
#End Region

#Region "Données"
    Private Sub ChargerDonnees()
        If Me.IdMvtCaisse >= 0 Then
            Me.JournalCaisseTA.FillById(Me.DsAgrifact.JournalCaisse, Me.IdMvtCaisse)

            If Me.DsAgrifact.JournalCaisse.Rows.Count > 0 Then
                With Cast(Of DsAgrifact.JournalCaisseRow)(Me.DsAgrifact.JournalCaisse.Rows(0))
                    Me.nCaisse = CInt(.NCaisse)
                    Me.Type = Cast(Of DsAgrifact.JournalCaisseDataTable.TypeCaisse)(.Type)
                End With
            End If
        Else
            If Me.nCaisse < 0 Then
                Me.Type = PointDeVente.DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond
            End If

            Me.JournalCaisseBindingSource.AddNew()

            With Me.CurrentJournalRow
                .Type = CInt(Me.Type)
                .NCaisse = Me.nCaisse
                .DateCaisse = Now
            End With

            'Me.JournalCaisseBindingSource.EndEdit()
            Me.JournalCaisseBindingSource.ResetCurrentItem()
        End If

        MajBoutons()
    End Sub

    Private Function Enregistrer() As Boolean
        If Me.Validate() Then
            Me.JournalCaisseBindingSource.EndEdit()

            'Faire les vérifs pour la saisie d'un mouvement dans le passé
            If Not CheckDateOpeCaisse() Then Return False

            If Me.DsAgrifact.HasChanges Then
                'Mise à jour de la base
                Me.JournalCaisseTA.Update(Me.DsAgrifact.JournalCaisse)
                Me.IdMvtCaisse = Me.CurrentJournalRow.IdMvtCaisse

                If Me.CurrentJournalRow.Type = DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond Then
                    Me.CurrentJournalRow.NCaisse = Me.IdMvtCaisse
                    Me.JournalCaisseTA.Update(Me.DsAgrifact.JournalCaisse)
                    Me.nCaisse = Me.CurrentJournalRow.NCaisse
                End If

                modif = True
            End If

            MajBoutons()

            Return True
        End If
    End Function

    Private Function CheckDateOpeCaisse() As Boolean
        If Me.CurrentJournalRow.RowState = DataRowState.Added Then
            If Me.CurrentJournalRow.Type <> DsAgrifact.JournalCaisseDataTable.TypeCaisse.Fond Then
                Dim dtFondCaisse As DsAgrifact.JournalCaisseDataTable
                Dim mustChangeNCaisse As Boolean = False

                If Me.nCaisse < 0 Then 'Si on n'a pas encore choisi de fond de caisse
                    mustChangeNCaisse = True
                Else
                    dtFondCaisse = Me.JournalCaisseTA.GetDataById(Me.nCaisse)
                    'Si le fond de caisse est introuvable ou bien la date du fond de caisse en cours n'est pas cohérente
                    mustChangeNCaisse = ((dtFondCaisse.Count = 0) OrElse (Me.CurrentJournalRow.DateCaisse < dtFondCaisse(0).DateCaisse))
                End If

                If mustChangeNCaisse Then
                    dtFondCaisse = Me.JournalCaisseTA.GetDataFondCaisseByDate(Me.CurrentJournalRow.DateCaisse)

                    If dtFondCaisse.Count = 0 Then
                        MsgBox("Aucun fond de caisse ne correspond à cette date. Vous devez commencer par saisir un fond de caisse", MsgBoxStyle.Exclamation)
                        'On annule l'enregistrement
                        Return False
                    Else
                        If MsgBox(String.Format("Cette opération ne se situe pas dans la caisse en cours." & vbCrLf & _
                                  "Voulez-vous l'enregistrer pour la caisse démarrée le {0:dd/MM/yy} à {0:HH:mm} ?", dtFondCaisse(0).DateCaisse), MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            'On se greffe sur l'ancienne caisse
                            Me.CurrentJournalRow.NCaisse = dtFondCaisse(0).NCaisse
                            Return True
                        Else
                            'On annule l'enregistrement
                            Return False
                        End If
                    End If
                End If
            End If
        End If
        Return True
    End Function

    Public Shadows Function Validate() As Boolean
        If Not MyBase.Validate Then
            Return False
        Else
            If Me.CurrentJournalRow.IsMontantNull Then
                MsgBox("Vous devez saisir un montant.")
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Private Function DemanderEnregistrement() As Boolean
        If Me.Validate() Then
            Me.JournalCaisseBindingSource.EndEdit()

            If Me.DsAgrifact.HasChanges Then
                Select Case MsgBox("Enregistrer les modifications ?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        If Not Enregistrer() Then
                            Return False
                        End If
                    Case MsgBoxResult.No
                    Case MsgBoxResult.Cancel
                        Return False
                End Select
            End If

            Return True
        Else : Return False
        End If        
    End Function
#End Region

#Region "Button"
    Private Sub BtOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOK.Click
        If Enregistrer() Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub MajBoutons(ByVal sender As Object, ByVal e As DataRowChangeEventArgs)
        MajBoutons()
    End Sub

    Private Sub MajBoutons()
        BtOK.Enabled = Me.DsAgrifact.HasChanges
    End Sub
#End Region

    Private Sub Controls_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles DateCaisseDateTimePicker.ValueChanged, DateCaisseDateTimePicker1.ValueChanged, _
                            TypeComboBox.SelectedIndexChanged, MontantTextBox.Validated, LibelleTextBox.Validated
        JournalCaisseBindingSource.EndEdit()
    End Sub

    Private Sub ctl_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                        Handles DateCaisseDateTimePicker.KeyPress, DateCaisseDateTimePicker1.KeyPress, _
                        TypeComboBox.KeyPress, MontantTextBox.KeyPress, LibelleTextBox.KeyPress
        If e.KeyChar = vbCr Then
            Me.SelectNextControl(Cast(Of Control)(sender), True, True, True, True)
            e.Handled = True
        End If
    End Sub

End Class

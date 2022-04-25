Public Class FrPlanTypeTVA

#Region "Form"
    Private Sub FrPlanTypeTVA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)

        Me.LoadData()
    End Sub

    Private Sub FrPlanTypeTVA_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (Me.DataSetdbPlanType.HasChanges()) Then
            If (MsgBox("Voulez-vous enregistrer les modifications ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes) Then
                Me.SaveData()
            End If
        End If
    End Sub
#End Region

#Region "Button"
    Private Sub SupprimerTypeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerTypeButton.Click
        Me.TypTVAComboBox.SelectedIndex = -1
    End Sub

    Private Sub SupprimerCompteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerCompteButton.Click
        Me.TCptComboBox.SelectedIndex = -1
    End Sub

    Private Sub SupprimerTCtrlCl_DCButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerTCtrlCl_DCButton.Click
        Me.TCtrlCl_DCComboBox.SelectedIndex = -1
    End Sub
#End Region

#Region "TVAAvecErreurBindingNavigator"
    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        Try
            Me.TVAAvecErreurBindingSource.AddNew()

            Me.TTVATextBox.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        Me.DeleteData()
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        If (Me.SaveData()) Then
            MsgBox("Données enregistrées.", MsgBoxStyle.Information, "")
        End If
    End Sub
#End Region

#Region "TVAAvecErreurDataGridView"
    Private Sub TVAAvecErreurDataGridView_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles TVAAvecErreurDataGridView.DataError
        MsgBox(e.Exception.Message, MsgBoxStyle.Exclamation, "")

        e.Cancel = True
    End Sub
#End Region

#Region "TTauxTextBox"
    Private Sub TTauxTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TTauxTextBox.KeyPress
        'On n'accepte que les caractères numériques, le point, ou la virgule        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ",")

        'On récupère le texte du TextBox 
        Dim txt As String = Me.TTauxTextBox.Text

        'On s'assure que le point ou la virgule n'a été tapé qu'une fois 
        If (InStr(txt, ".") > 0 Or InStr(txt, ",") > 0) And (e.KeyChar = "." Or e.KeyChar = ",") Then
            e.KeyChar = Nothing
        Else
            'On remplace le point par une virgule ou la virgule par un point en fonction du séparateur décimal utilisé dans la culture en cours 
            Dim vsDecimalSeparator As Char

            vsDecimalSeparator = CChar(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)

            If vsDecimalSeparator <> "." And e.KeyChar = "." Then
                e.KeyChar = vsDecimalSeparator
            End If
        End If
    End Sub
#End Region

#Region "TColonneTextBox"
    Private Sub TColonneTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TColonneTextBox.KeyPress
        'On n'accepte que les caractères numériques        
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub
#End Region

#Region "TLigneTextBox"
    Private Sub TLigneTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TLigneTextBox.KeyPress
        'On n'accepte que les caractères numériques       
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub
#End Region

#Region "TCtrlCl_NumTextBox"
    Private Sub TCtrlCl_NumTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TCtrlCl_NumTextBox.KeyPress
        'On n'accepte que les caractères numériques
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar))
    End Sub
#End Region

#Region "Méthodes diverses"
    Private Sub LoadData()
        'Chargement des données présentes dans le fichier DataPlanType.xml
        Me.LoadXMLData()

        Me.PlanComptableTableAdapter.FillByPlDossier(Me.DataSetAgrigest.PlanComptable, My.User.Name)
        Me.TVAAvecErreurTableAdapter.Fill(Me.DataSetdbPlanType.TVAAvecErreur)

        'Remplissage de la colonne Erreur
        Me.RemplirColonneErreur()

        Me.DataSetdbPlanType.AcceptChanges()

        Me.PlanComptableBindingSource.Filter = "PlCpt LIKE '445*'"
        Me.TVAAvecErreurBindingSource.Sort = "TTVA"
    End Sub

    Private Sub RemplirColonneErreur()
        Using planComptableTA As New DataSetAgrigestTableAdapters.PlanComptableTableAdapter
            For Each TVAAvecErreurDR As DataSetdbPlanType.TVAAvecErreurRow In Me.DataSetdbPlanType.TVAAvecErreur.Rows
                If Not (TVAAvecErreurDR.IsTCptNull) Then
                    If Not (String.IsNullOrEmpty(TVAAvecErreurDR.TCpt)) Then
                        Dim planComptableDT As DataSetAgrigest.PlanComptableDataTable = planComptableTA.GetDataByPlDossierEtPlCpt(My.User.Name, TVAAvecErreurDR.TCpt)

                        If Not (planComptableDT.Rows.Count > 0) Then
                            TVAAvecErreurDR.Erreur = "Le compte " & TVAAvecErreurDR.TCpt & " est inexistant dans le plan comptable d'AgrigestEDI pour ce dossier."
                            TVAAvecErreurDR.TCpt = String.Empty
                        End If
                    End If
                End If
            Next
        End Using
    End Sub

    Private Function SaveData() As Boolean
        Try
            Me.TVAAvecErreurBindingSource.EndEdit()

            If (Me.ListeTVAEnErreur()) Then
                If (MsgBox("La liste comporte des erreurs. Voulez-vous quand même continuer ?", MsgBoxStyle.YesNo, "") = MsgBoxResult.No) Then
                    Return False
                End If
            End If

            Me.TVAAvecErreurTableAdapter.Update(Me.DataSetdbPlanType.TVAAvecErreur)

            Me.RemplirColonneErreur()

            MsgBox("Afin de prendre en compte vos modifications, veuillez recharger le dossier.", MsgBoxStyle.Exclamation, "")

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")

            Return False
        End Try
    End Function

    Private Sub DeleteData()
        Try
            If (Me.TVAAvecErreurDataGridView.SelectedRows.Count > 0) Then
                Dim TVAAvecErreurDR As DataSetdbPlanType.TVAAvecErreurRow = CType(CType(Me.TVAAvecErreurBindingSource.Current, DataRowView).Row, AgrigestEDI.DataSetdbPlanType.TVAAvecErreurRow)

                If Not (Me.TVAEstUtilisee(TVAAvecErreurDR.TTVA)) Then
                    Me.TVAAvecErreurBindingSource.RemoveCurrent()
                Else
                    MsgBox("Suppression impossible, cette TVA est utilisée.", MsgBoxStyle.Exclamation, "")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "")
        End Try
    End Sub

    Private Function TVAEstUtilisee(ByVal codeTVA As String) As Boolean
        Using TVATA As New DataSetAgrigestTableAdapters.TVATableAdapter
            Dim TVADT As DataSetAgrigest.TVADataTable = TVATA.GetDataByTTVA(codeTVA)

            If (TVADT.Rows.Count > 0) Then
                Return True
            End If
        End Using

        Return False
    End Function

    Private Function ListeTVAEnErreur() As Boolean
        For Each drv As DataRowView In Me.TVAAvecErreurBindingSource.List
            Dim TVAAvecErreurDR As DataSetdbPlanType.TVAAvecErreurRow = CType(CType(drv, DataRowView).Row, AgrigestEDI.DataSetdbPlanType.TVAAvecErreurRow)

            If Not (TVAAvecErreurDR.IsErreurNull) Then
                If Not (String.IsNullOrEmpty(TVAAvecErreurDR.Erreur)) Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Sub LoadXMLData()
        Dim fichierDataXML As String = System.IO.Path.Combine(Application.StartupPath, My.Settings.FichierDataPlanTypeXML)

        Me.DataSetdbPlanType.ReadXml(fichierDataXML)
    End Sub
#End Region

End Class
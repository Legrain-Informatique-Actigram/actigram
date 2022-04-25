Public Class FrCodeBarre

#Region " Props "
    Private _ds As AgrifactTracaDataSet
    Public Property Datasource() As AgrifactTracaDataSet
        Get
            Return _ds
        End Get
        Set(ByVal value As AgrifactTracaDataSet)
            _ds = value
            With Me.MouvementBindingSource
                .DataSource = _ds
                .DataMember = "Mouvement"
            End With
        End Set
    End Property

    Private _nMouv As Decimal
    Public Property nMouvement() As Decimal
        Get
            Return _nMouv
        End Get
        Set(ByVal value As Decimal)
            _nMouv = value
            If Me.Datasource IsNot Nothing Then
                With Me.MouvementBindingSource
                    .Position = .Find("nMouvement", value)
                End With
            End If
        End Set
    End Property

    Private _searchInCurrentDs As Boolean = True
    Public Property SearchInCurrentDs() As Boolean
        Get
            Return _searchInCurrentDs
        End Get
        Set(ByVal value As Boolean)
            _searchInCurrentDs = value
        End Set
    End Property

    Private _filterMatPrem As Boolean
    Public Property FiltrerMP() As Boolean
        Get
            Return _filterMatPrem
        End Get
        Set(ByVal value As Boolean)
            _filterMatPrem = value
        End Set
    End Property
#End Region

#Region " Ctor "
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal ds As AgrifactTracaDataSet)
        Me.New()
        Me.Datasource = ds
    End Sub

    Public Sub New(ByVal ds As AgrifactTracaDataSet, ByVal nMouvement As Integer)
        Me.New()
        Me.Datasource = ds
        Me.nMouvement = nMouvement
    End Sub

    Public Sub New(ByVal dr As AgrifactTracaDataSet.MouvementRow)
        Me.New()
        Me.Datasource = Cast(Of AgrifactTracaDataSet)(dr.Table.DataSet)
        Me.nMouvement = dr.nMouvement
    End Sub
#End Region

#Region "Page"
    Private Sub FrCodeBarre_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            With Me.Mouvement_DetailBindingSource
                If .Position >= 0 Then
                    If Cast(Of DataRowView)(.Current).IsEdit Or Cast(Of DataRowView)(.Current).IsNew Then
                        If MsgBox("Valider le produit en cours ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            .EndEdit()
                        Else
                            .CancelEdit()
                        End If
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub FrCodeBarre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConfigNumericControl(Me.TxCodeBarre)
        ConfigDecimalControl(Me.Unite1TextBox, 3)
        ConfigDecimalControl(Me.Unite2TextBox, 3)
        Me.TxCodeBarre.Text = ""
        Me.Mouvement_DetailBindingSource.Filter = "false" '.Position = -1
        Me.TxCodeBarre.Focus()
    End Sub
#End Region

#Region "Boutons"
    Private Sub BtValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValider.Click
        With Me.Mouvement_DetailBindingSource
            If .Position >= 0 Then
                If Cast(Of DataRowView)(.Current).IsEdit Or Cast(Of DataRowView)(.Current).IsNew Then
                    .EndEdit()
                End If
                .Filter = "false"
                Me.TxCodeBarre.Focus()
            End If
        End With
    End Sub

    Private Sub BtFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFermer.Click
        Me.Close()
    End Sub
#End Region

    Private Sub Mouvement_DetailBindingSource_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mouvement_DetailBindingSource.PositionChanged
        If Me.Mouvement_DetailBindingSource.Position < 0 Then
            Me.gbProduit.Enabled = False
        Else
            Me.gbProduit.Enabled = True
            Me.Unite1TextBox.Enabled = Me.LibUnite1Label1.Text.Length > 0
            Me.Unite2TextBox.Enabled = Me.LibUnite2Label1.Text.Length > 0
        End If
    End Sub

    Private Sub Tx_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles TxCodeBarre.KeyPress, Unite1TextBox.KeyPress, Unite2TextBox.KeyPress
        If e.KeyChar = vbCr Then
            Me.SelectNextControl(Cast(Of Control)(sender), True, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub TxCodeBarre_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxCodeBarre.Validating
        If TxCodeBarre.Text.Length > 0 And TxCodeBarre.Text.Length < 12 Then
            e.Cancel = False
        End If
    End Sub

    Private Sub TxCodeBarre_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxCodeBarre.Validated
        If TxCodeBarre.Text.Length > 0 Then
            Dim cb As CodeBarre

            If Me.SearchInCurrentDs Then
                cb = CodeBarre.Parse(TxCodeBarre.Text, Me.Datasource)
            Else
                cb = CodeBarre.Parse(TxCodeBarre.Text)
            End If

            If cb Is Nothing Then
                Me.Mouvement_DetailBindingSource.Filter = "false"
            Else
                If Me.FiltrerMP Then
                    Me.Mouvement_DetailBindingSource.Filter = "MatPrem=True"
                Else
                    Me.Mouvement_DetailBindingSource.Filter = ""
                End If

                Dim drMouvDet As AgrifactTracaDataSet.Mouvement_DetailRow = _
                                SelectSingleRow(Of AgrifactTracaDataSet.Mouvement_DetailRow) _
                                (Me.Datasource.Mouvement_Detail, String.Format("nMouvement={0} AND CodeProduit='{1}' AND (nLot='{2}' OR nLot is null)", Me.nMouvement, cb.CodeProduit, cb.NLot), "nLot, Unite1 desc,nMouvementDetail")

                If drMouvDet Is Nothing Then
                    With Me.Mouvement_DetailBindingSource
                        .AddNew()
                        With Cast(Of DataRowView)(.Current)
                            If cb.Datarow IsNot Nothing Then
                                .Item("nLot") = cb.Datarow("NLot")
                                .Item("CodeProduit") = cb.Datarow("CodeProduit")
                                .Item("Libelle") = cb.Datarow("Libelle")
                                .Item("LibUnite1") = cb.Datarow("LibUnite1")
                                .Item("LibUnite2") = cb.Datarow("LibUnite2")
                            Else
                                .Item("nLot") = cb.NLot
                                .Item("CodeProduit") = cb.CodeProduit
                                Dim drProd As AgrifactTracaDataSet.ProduitRow = SelectSingleRow(Of AgrifactTracaDataSet.ProduitRow)(Me.Datasource.Produit, String.Format("CodeProduit='{0}'", cb.CodeProduit.Replace("'", "''")), "")
                                If drProd IsNot Nothing Then
                                    .Item("Libelle") = drProd("Libelle")
                                    .Item("LibUnite1") = drProd("Unite1")
                                    .Item("LibUnite2") = drProd("Unite2")
                                End If
                            End If
                            If Me.FiltrerMP Then
                                .Item("MatPrem") = True
                            End If
                        End With
                        .ResetCurrentItem()
                        Me.Unite1TextBox.Enabled = Me.LibUnite1Label1.Text.Length > 0
                        Me.Unite2TextBox.Enabled = Me.LibUnite2Label1.Text.Length > 0
                    End With
                Else
                    With Me.Mouvement_DetailBindingSource
                        .Position = .Find("nMouvementDetail", drMouvDet.nMouvementDetail)
                        With Cast(Of DataRowView)(.Current)
                            .Item("nLot") = cb.NLot
                        End With
                        .ResetCurrentItem()
                        Me.Unite1TextBox.Enabled = Me.LibUnite1Label1.Text.Length > 0
                        Me.Unite2TextBox.Enabled = Me.LibUnite2Label1.Text.Length > 0
                    End With
                End If
                Me.SelectNextControl(Cast(Of Control)(sender), True, True, True, True)
                Me.TxCodeBarre.Text = ""
            End If
        End If
    End Sub
End Class
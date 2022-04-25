Namespace Controles
    Public Class FrResultatBareme

#Region " Props "
        Private _resultats As List(Of ResultatBareme)
        Public Property Resultats() As List(Of ResultatBareme)
            Get
                Return _resultats
            End Get
            Set(ByVal value As List(Of ResultatBareme))
                _resultats = value
            End Set
        End Property


        Private _nResultat As Integer
        Public Property nResultatBareme() As Integer
            Get
                Return _nResultat
            End Get
            Set(ByVal value As Integer)
                _nResultat = value
            End Set
        End Property


        Private _readonly As Boolean = False
        Public Property [ReadOnly]() As Boolean
            Get
                Return _readonly
            End Get
            Set(ByVal value As Boolean)
                _readonly = value
            End Set
        End Property
#End Region

#Region " Ctor "
        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(ByVal resultats As List(Of ResultatBareme))
            Me.New()
            Me.Resultats = resultats
        End Sub

        Public Sub New(ByVal nResultatBareme As Integer)
            Me.New()
            Me.nResultatBareme = nResultatBareme
        End Sub
#End Region

#Region " Données "
        Private Sub ChargerDonnees()
            If Me.Resultats IsNot Nothing Then
                Me.ResultatBaremeBindingSource.DataSource = Me.Resultats
            Else
                Dim ds As New AgrifactTracaDataSet
                ds.EnforceConstraints = False
                'Charger resultatbareme
                Using dta As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                    dta.FillBynResultatBareme(ds.ResultatBareme, Me.nResultatBareme)
                End Using
                If ds.ResultatBareme.Rows.Count = 0 Then Exit Sub
                Dim dr As AgrifactTracaDataSet.ResultatBaremeRow = ds.ResultatBareme(0)
                'Charger bareme
                Using dta As New AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
                    dta.FillByNBareme(ds.Bareme, dr.nBareme)
                End Using
                Dim res As New ResultatBareme(dr)
                Me.ResultatBaremeBindingSource.DataSource = res
            End If
            If Me.ResultatBaremeBindingSource.Count = 1 Then Me.BtPrevious.Visible = False
        End Sub
#End Region

        Private Sub FrResultatBareme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            SetChildFormIcon(Me)
            ChargerDonnees()
            If Me.ReadOnly Then
                Me.ObservationsTextBox.ReadOnly = True
                Me.ActionCorrectiveEffectueeCheckBox.Enabled = False
                Me.BtNext.Visible = False
                Me.BtCancel.Text = "Fermer"
            End If
        End Sub

        Private Sub ResultatBaremeBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultatBaremeBindingSource.CurrentChanged
            If ResultatBaremeBindingSource.Current Is Nothing Then Exit Sub
            Dim res As ResultatBareme = CType(ResultatBaremeBindingSource.Current, ResultatBareme)
            If IO.File.Exists(res.Bareme.CheminDoc) Then
                With Me.lnkDoc
                    Dim bmp As Image = Icon.ExtractAssociatedIcon(res.Bareme.CheminDoc).ToBitmap
                    bmp = bmp.GetThumbnailImage(16, 16, Nothing, Nothing)
                    .Image = bmp
                    .Visible = True
                End With
            Else
                Me.lnkDoc.Visible = False
            End If
            If ResultatBaremeBindingSource.Position = ResultatBaremeBindingSource.Count - 1 Then
                Me.BtNext.Text = "Terminer"
            Else
                Me.BtNext.Text = "Suivant >"
            End If
            Me.BtPrevious.Enabled = ResultatBaremeBindingSource.Position > 0
            ActivationBoutons()
        End Sub

        Private Sub BtPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrevious.Click
            If ResultatBaremeBindingSource.Position > 0 Then
                ResultatBaremeBindingSource.Position -= 1
            End If
        End Sub

        Private Sub BtNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtNext.Click
            If ResultatBaremeBindingSource.Position < ResultatBaremeBindingSource.Count - 1 Then
                ResultatBaremeBindingSource.Position += 1
            Else
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End Sub

        Private Sub BtCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancel.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub ActivationBoutons()
            If ResultatBaremeBindingSource.Current Is Nothing Then Exit Sub
            Dim res As ResultatBareme = CType(ResultatBaremeBindingSource.Current, ResultatBareme)
            If Not res.ActionCorrectiveEffectuee AndAlso (res.Observations Is Nothing OrElse res.Observations.Length = 0) Then
                Me.BtNext.Enabled = False
            Else
                Me.BtNext.Enabled = True
            End If
        End Sub

        Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDoc.LinkClicked
            If ResultatBaremeBindingSource.Current Is Nothing Then Exit Sub
            Dim res As ResultatBareme = CType(ResultatBaremeBindingSource.Current, ResultatBareme)
            If IO.File.Exists(res.Bareme.CheminDoc) Then
                Cursor.Current = Cursors.WaitCursor
                Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(res.Bareme.CheminDoc)
                p.WaitForInputIdle(3000)
                Cursor.Current = Cursors.Default
            End If
        End Sub

        Private Sub ResultatBaremeBindingSource_CurrentItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResultatBaremeBindingSource.CurrentItemChanged
            ActivationBoutons()
        End Sub
    End Class
End Namespace
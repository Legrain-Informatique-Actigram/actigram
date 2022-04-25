Imports System.ComponentModel
Imports Actigram.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class NavigationDataBindings
    Inherits System.Windows.Forms.UserControl
    Dim ds As Object
    Dim dsBase As DataSet
    Dim dv As DataView
    Dim maTable As String
    Dim maTableSearch As String
    Dim maVue As DataView
    Dim cm As CurrencyManager
    'Dim momFiltre As String = ""
    'Dim strCle As String = ""
    Dim WithEvents fr As Form
    Dim WithEvents myFrResultat As FrResultatRecherche
    Dim WithEvents myFrRecherche As FrRecherche
    Public Event VerifBeforeDataMove(ByVal e As CancelEventArgs)
    Public Event BeforeDataMove(ByVal strTable As String, ByVal intPosition As Integer)
    Public Event DataMove(ByVal strTable As String, ByVal intPosition As Integer)
    Public Event BeforeDeleteRow(ByVal strTable As String, ByVal intPosition As Integer)
    Public Event AddNew()
    Public Event AddNewPlus(ByVal rwv As DataRowView)
    Public Event BeforeAddNew(ByVal e As CancelEventArgs)
    Public Event RemoveAt(ByVal intPosition As Integer)
    Public Event RechercheOk()
    Private _strStartFilter As String
    Private _AutoriseAjt As Boolean = True
    Private _AutoriseSuppr As Boolean = True
    Private _InfoAvantSuppr As Boolean = True
    Private _DepartColor As Color = Color.LightGreen
    Private _FinColor As Color = Color.DarkGreen
    Private _Orientationdegrade As LinearGradientMode = LinearGradientMode.ForwardDiagonal
    Private _AfficheBtAjtPersonne As Boolean = True
    Private _AfficheBtSupprPersonne As Boolean = True
    Private _AfficherBtRecherche As Boolean = True
    Private _EngrDep As New Hashtable
    Private _EnregistrerOuiNon As Boolean = False
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents FirstToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PreviousToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PositionToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents NextToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LastToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents DeleteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FindToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents EditToolStripButton As System.Windows.Forms.ToolStripButton
    Private _AjouterEnregistrementAddNew As Boolean = True
    'Private frOwner As Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
    End Sub

    'La méthode substituée Dispose du UserControl pour nettoyer la liste des composants.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NavigationDataBindings))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.DeleteToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.FirstToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PreviousToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PositionToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.FindToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.NextToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.LastToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.EditToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripButton, Me.FirstToolStripButton, Me.PreviousToolStripButton, Me.PositionToolStripLabel, Me.FindToolStripButton, Me.NextToolStripButton, Me.LastToolStripButton, Me.NewToolStripButton, Me.EditToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(464, 27)
        Me.ToolStrip1.TabIndex = 20
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'DeleteToolStripButton
        '
        Me.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteToolStripButton.Image = CType(resources.GetObject("DeleteToolStripButton.Image"), System.Drawing.Image)
        Me.DeleteToolStripButton.Name = "DeleteToolStripButton"
        Me.DeleteToolStripButton.RightToLeftAutoMirrorImage = True
        Me.DeleteToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.DeleteToolStripButton.Text = "Supprimer"
        '
        'FirstToolStripButton
        '
        Me.FirstToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FirstToolStripButton.Image = CType(resources.GetObject("FirstToolStripButton.Image"), System.Drawing.Image)
        Me.FirstToolStripButton.Name = "FirstToolStripButton"
        Me.FirstToolStripButton.RightToLeftAutoMirrorImage = True
        Me.FirstToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.FirstToolStripButton.Text = "Placer en premier"
        '
        'PreviousToolStripButton
        '
        Me.PreviousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PreviousToolStripButton.Image = CType(resources.GetObject("PreviousToolStripButton.Image"), System.Drawing.Image)
        Me.PreviousToolStripButton.Name = "PreviousToolStripButton"
        Me.PreviousToolStripButton.RightToLeftAutoMirrorImage = True
        Me.PreviousToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.PreviousToolStripButton.Text = "Déplacer vers le haut"
        '
        'PositionToolStripLabel
        '
        Me.PositionToolStripLabel.BackColor = System.Drawing.Color.White
        Me.PositionToolStripLabel.Name = "PositionToolStripLabel"
        Me.PositionToolStripLabel.Size = New System.Drawing.Size(54, 24)
        Me.PositionToolStripLabel.Text = "{0} de {1}"
        '
        'FindToolStripButton
        '
        Me.FindToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FindToolStripButton.Image = CType(resources.GetObject("FindToolStripButton.Image"), System.Drawing.Image)
        Me.FindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FindToolStripButton.Name = "FindToolStripButton"
        Me.FindToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.FindToolStripButton.Text = "ToolStripButton7"
        '
        'NextToolStripButton
        '
        Me.NextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NextToolStripButton.Image = CType(resources.GetObject("NextToolStripButton.Image"), System.Drawing.Image)
        Me.NextToolStripButton.Name = "NextToolStripButton"
        Me.NextToolStripButton.RightToLeftAutoMirrorImage = True
        Me.NextToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.NextToolStripButton.Text = "Déplacer vers le bas"
        '
        'LastToolStripButton
        '
        Me.LastToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.LastToolStripButton.Image = CType(resources.GetObject("LastToolStripButton.Image"), System.Drawing.Image)
        Me.LastToolStripButton.Name = "LastToolStripButton"
        Me.LastToolStripButton.RightToLeftAutoMirrorImage = True
        Me.LastToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.LastToolStripButton.Text = "Placer en dernier"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.RightToLeftAutoMirrorImage = True
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.NewToolStripButton.Text = "Ajouter nouveau"
        '
        'EditToolStripButton
        '
        Me.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditToolStripButton.Image = CType(resources.GetObject("EditToolStripButton.Image"), System.Drawing.Image)
        Me.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditToolStripButton.Name = "EditToolStripButton"
        Me.EditToolStripButton.Size = New System.Drawing.Size(23, 24)
        Me.EditToolStripButton.Text = "Edit"
        '
        'NavigationDataBindings
        '
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "NavigationDataBindings"
        Me.Size = New System.Drawing.Size(464, 27)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Propriétés"
    <DefaultValue(True)> _
    Public Property AjouterEnregistrementAddNew() As Boolean
        Get
            Return _AjouterEnregistrementAddNew
        End Get
        Set(ByVal Value As Boolean)
            _AjouterEnregistrementAddNew = Value
        End Set
    End Property


    <DefaultValue(False)> _
    Public Property EnregistrerOuiNon() As Boolean
        Get
            Return _EnregistrerOuiNon
        End Get
        Set(ByVal Value As Boolean)
            '* Pour Bloquer la demande d'enregistrement
            '_EnregistrerOuiNon = Value
            _EnregistrerOuiNon = False
        End Set
    End Property

    <DefaultValue(LinearGradientMode.ForwardDiagonal)> _
    Public Property OrientationDegrade() As LinearGradientMode
        Get
            Return _Orientationdegrade
        End Get
        Set(ByVal Value As LinearGradientMode)
            _Orientationdegrade = Value
        End Set
    End Property

    Public Property DepartColor() As Color
        Get
            Return _DepartColor
        End Get
        Set(ByVal Value As Color)
            _DepartColor = Value
        End Set
    End Property

    Public Property FinColor() As Color
        Get
            Return _FinColor
        End Get
        Set(ByVal Value As Color)
            _FinColor = Value
        End Set
    End Property

    <Description("Affiche un message avant la suppression"), DefaultValue(True)> _
    Public Property InfoAvantSuppr() As Boolean
        Get
            Return _InfoAvantSuppr
        End Get
        Set(ByVal Value As Boolean)
            _InfoAvantSuppr = Value
        End Set
    End Property

    <Description("Autorise l'ajout de nouveaux enregistrement"), DefaultValue(True)> _
    Public Property AutoriseAjt() As Boolean
        Get
            Return _AutoriseAjt
        End Get
        Set(ByVal Value As Boolean)
            _AutoriseAjt = Value
            NewToolStripButton.Enabled = Value
        End Set
    End Property

    <Description("Autorise la suppression d'un enregistrement"), DefaultValue(True)> _
    Public Property AutoriseSuppr() As Boolean
        Get
            Return _AutoriseSuppr
        End Get
        Set(ByVal Value As Boolean)
            _AutoriseSuppr = Value
            DeleteToolStripButton.Enabled = Value
        End Set
    End Property

    'Public Property Filtre() As String
    '    Get
    '        Return momFiltre
    '    End Get
    '    Set(ByVal Value As String)
    '        momFiltre = Value
    '    End Set
    'End Property

    'Public Property Cle() As String
    '    Get
    '        Return strCle
    '    End Get
    '    Set(ByVal Value As String)
    '        strCle = Value
    '    End Set
    'End Property
    <DefaultValue(True)> _
    Public Property AfficherRecherche() As Boolean
        Get
            Return Me.FindToolStripButton.Visible
        End Get
        Set(ByVal Value As Boolean)
            _AfficherBtRecherche = Value
            Me.FindToolStripButton.Visible = _AfficherBtRecherche
        End Set
    End Property

    Public Property DataSource() As DataSet
        Get
            If TypeOf ds Is DataSet Then
                Return CType(ds, DataSet)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As DataSet)
            ds = Value
        End Set
    End Property

    Public Property Table() As String
        Get
            Return maTable
        End Get
        Set(ByVal Value As String)
            maTable = Value
            maTableSearch = Value
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property MajVisible() As Boolean
        Get
            Return Me.EditToolStripButton.Visible
        End Get
        Set(ByVal Value As Boolean)
            Me.EditToolStripButton.Visible = Value
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property AjoutVisible() As Boolean
        Get
            Return _AfficheBtAjtPersonne
        End Get
        Set(ByVal Value As Boolean)
            _AfficheBtAjtPersonne = Value
            Me.NewToolStripButton.Visible = Value
        End Set
    End Property

    <DefaultValue(True)> _
    Public Property SuppressionVisible() As Boolean
        Get
            Return _AfficheBtSupprPersonne
        End Get
        Set(ByVal Value As Boolean)
            _AfficheBtSupprPersonne = Value
            Me.DeleteToolStripButton.Visible = Value
        End Set
    End Property

    <DefaultValue(True)> _
    Public ReadOnly Property AjoutSuppressionVisible() As Boolean
        Get
            If Me.NewToolStripButton.Visible = Me.DeleteToolStripButton.Visible Then
                Return Me.NewToolStripButton.Visible
            Else
                Return False
            End If
        End Get
    End Property

    <DefaultValue(True)> _
    Public Property InfosPositionVisible() As Boolean
        Get
            Return PositionToolStripLabel.Visible
        End Get
        Set(ByVal Value As Boolean)
            PositionToolStripLabel.Visible = Value
        End Set
    End Property

    Public Property StartFilter() As String
        Get
            Return _strStartFilter
        End Get
        Set(ByVal Value As String)
            _strStartFilter = Value
        End Set
    End Property
#End Region

    Private Sub ParentFormLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles fr.Load
        If ds Is Nothing Then Exit Sub
        If cm Is Nothing Then Exit Sub
        'Dim db As BindingManagerBase = Me.ParentForm.BindingContext(ds, maTable)
        AddHandler cm.PositionChanged, AddressOf PositionChanged
        PositionChanged()
    End Sub

    Private Sub NavigationDataBindings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fr = Me.ParentForm
        Me.PositionToolStripLabel.Tag = Me.PositionToolStripLabel.Text
    End Sub

#Region " Public "
    Public Sub SetDataSource(ByRef DataSource As DataSet)
        ds = DataSource
        dsBase = DataSource
        cm = CType(Me.ParentForm.BindingContext(ds, maTable), CurrencyManager)
    End Sub

    Public Sub SetDataSource(ByRef DataSource As DataView)
        ds = DataSource
        dsBase = DataSource.Table.DataSet
        maTableSearch = DataSource.Table.TableName
        cm = CType(Me.ParentForm.BindingContext(ds, maTable), CurrencyManager)
        'Ajout pour gérer le cas ou on change le datasource plusieurs fois dans le form
        'exemple : FrListeProduit avec la gestion des tarifs
        ParentFormLoad(Nothing, Nothing)
    End Sub

    Public Sub SetDataSource(ByRef cm As CurrencyManager)
        If TypeOf cm.List Is BindingSource Then
            ds = CType(CType(cm.List, BindingSource).List, DataView)
        Else
            ds = CType(cm.List, DataView)
        End If
        dsBase = CType(ds, DataView).Table.DataSet
        maTableSearch = CType(ds, DataView).Table.TableName
        Me.cm = cm
        'Ajout pour gérer le cas ou on change le datasource plusieurs fois dans le form
        'exemple : FrListeProduit avec la gestion des tarifs
        ParentFormLoad(Nothing, Nothing)
    End Sub

    Public Sub AjouterNouvelEnregistrement()
        Me.NewToolStripButton_Click(Me.NewToolStripButton, New EventArgs)
    End Sub

    Public Sub PositionChanged()
        If Me.ParentForm Is Nothing Then Exit Sub
        If Me.PositionToolStripLabel.Tag Is Nothing Then Me.PositionToolStripLabel.Tag = "{0} de {1}"
        If ds Is Nothing Then
            PositionToolStripLabel.Text = String.Format(CStr(Me.PositionToolStripLabel.Tag), 0, 0)
            Exit Sub
        End If
        PositionToolStripLabel.Text = String.Format(CStr(Me.PositionToolStripLabel.Tag), cm.Position + 1, cm.Count)
        DataMoveExec(maTable, cm.Position)
    End Sub
#End Region


    Private Sub OnBeforeDataMove(ByVal strTable As String, ByVal IntPosition As Integer, ByVal e As CancelEventArgs)
        VerifEngrAvMove()
        RaiseEvent VerifBeforeDataMove(e)
        RaiseEvent BeforeDataMove(strTable, IntPosition)
    End Sub

    Private Sub PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
        PositionChanged()
    End Sub

    Private Sub DataMoveExec(ByVal maTable As String, ByVal Position As Integer)
        RaiseEvent DataMove(maTable, Position)
        If _EnregistrerOuiNon = True Then
            _EngrDep = New Hashtable
            If cm.Position <> -1 Then
                Dim cl As DataColumn
                For Each cl In CType(cm.Current, DataRowView).Row.Table.Columns
                    _EngrDep.Add(cl, CType(cm.Current, DataRowView).Row.Item(cl))
                Next
            End If
        End If
    End Sub


#Region " Boutons "
    Private Sub DeleteToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripButton.Click
        Dim ok As Boolean = True

        If MessageBox.Show("Attention, vous-allez supprimer l'enregistrement en cours..." & vbCrLf & "Voulez-vous continuer ?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <> DialogResult.OK Then
            ok = False
        End If

        If ok = True Then
            Dim intPosition As Integer

            intPosition = cm.Position
            If intPosition = -1 Then Exit Sub
            RaiseEvent BeforeDeleteRow(maTable, intPosition)
            If TypeOf ds Is DataSet Then
                CType(ds, DataSet).Tables(maTable).DefaultView.AllowDelete = True
            End If
            If TypeOf ds Is DataView Then
                CType(ds, DataView).AllowDelete = True
            End If

            Dim rt As DataRelation
            Dim rwv As DataRowView = CType(cm.Current, DataRowView)
            Dim SupprOk As Boolean = True
            Dim strMessage As String = ""
            For Each rt In rwv.Row.Table.ChildRelations
                If Not rt.ChildKeyConstraint Is Nothing AndAlso rt.ChildKeyConstraint.DeleteRule <> Rule.Cascade Then
                    If rwv.CreateChildView(rt.RelationName).Count > 0 Then
                        strMessage += "La relation :'" & rt.RelationName & "' contient des enregistrements" & vbCrLf
                        SupprOk = False
                    End If
                End If
            Next

            If SupprOk = True Then
                CType(cm.Current, DataRowView).Delete()
                RaiseEvent RemoveAt(intPosition)
            Else
                strMessage += "La suppression est donc impossible"
                MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If Me._AutoriseSuppr = False Then
                Me.DeleteToolStripButton.Enabled = Me._AutoriseSuppr
            End If
            Me.PositionChanged()
        End If
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        Dim MyE As New CancelEventArgs
        OnBeforeDataMove(maTable, cm.Position, MyE)
        If MyE.Cancel = True Then Exit Sub

        If TypeOf ds Is DataSet Then
            CType(ds, DataSet).Tables(maTable).DefaultView.AllowNew = True
        ElseIf TypeOf ds Is DataView Then
            CType(ds, DataView).AllowNew = True
        End If

        Dim eN As New CancelEventArgs
        RaiseEvent BeforeAddNew(eN)
        If eN.Cancel = True Then Exit Sub

        If Me.AjouterEnregistrementAddNew = True Then
            cm.AddNew()
            cm.EndCurrentEdit()
        End If

        RaiseEvent AddNew()

        Me.DeleteToolStripButton.Enabled = True
    End Sub

    Private Sub NextToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextToolStripButton.Click
        Dim MyE As New CancelEventArgs
        OnBeforeDataMove(maTable, cm.Position, MyE)
        If MyE.Cancel = True Then Exit Sub
        cm.Position += 1
    End Sub

    Private Sub PreviousToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousToolStripButton.Click
        Dim MyE As New CancelEventArgs
        OnBeforeDataMove(maTable, cm.Position, MyE)
        If MyE.Cancel = True Then Exit Sub
        cm.Position -= 1
    End Sub

    Private Sub FindToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripButton.Click
        If Not Me.ParentForm Is Nothing Then
            If cm.Position <> -1 Then
                cm.EndCurrentEdit()
                Dim MyE As New CancelEventArgs
                OnBeforeDataMove(maTable, cm.Position, MyE)
                If MyE.Cancel = True Then Exit Sub
            End If
        End If
        myFrRecherche = New FrRecherche(dsBase, maTableSearch)
        myFrRecherche.Owner = Me.ParentForm
        myFrRecherche.Show()
    End Sub

    Private Sub LastToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LastToolStripButton.Click
        Dim MyE As New CancelEventArgs
        OnBeforeDataMove(maTable, cm.Position, MyE)
        If MyE.Cancel = True Then Exit Sub
        If Me.ParentForm.BindingContext(ds, maTable).Count > 0 Then
            cm.Position = cm.Count - 1
            PositionChanged()
        End If
    End Sub

    Private Sub FirstToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstToolStripButton.Click
        Dim MyE As New CancelEventArgs
        OnBeforeDataMove(maTable, cm.Position, MyE)
        If MyE.Cancel = True Then Exit Sub
        If cm.Count > 0 Then
            cm.Position = 0
            PositionChanged()
        End If
    End Sub
#End Region

    Private Sub NaviguerVersResultatRecherche(ByVal ValeurKey As Object) Handles myFrResultat.SelectLigne
        cm.EndCurrentEdit()
        cm.Position = Convert.ToInt32(ValeurKey)
        RaiseEvent RechercheOk()
        PositionChanged()
    End Sub

    Private Sub LancerLaRecherche(ByVal strCritere As String) Handles myFrRecherche.AffectuerRecherche
        Dim strColKey As String
        Dim maTableLocal As String
        Dim dvTmp As DataView
        If TypeOf ds Is DataView Then
            maTableLocal = CType(ds, DataView).Table.TableName
            dvTmp = CType(ds, DataView)
            If _strStartFilter Is Nothing Then
                _strStartFilter = dvTmp.RowFilter
            End If
            Dim strFiltre As String = ""
            If _strStartFilter <> "" Then
                If strCritere <> "" Then
                    strFiltre = "(" & _strStartFilter & ") And (" & strCritere & ")"
                Else
                    strFiltre = _strStartFilter
                End If
            Else
                strFiltre = strCritere
            End If
            dvTmp.RowFilter = strFiltre
        Else
            maTableLocal = maTable
            dvTmp = New DataView(dsBase.Tables(maTableLocal))
            dvTmp.RowFilter = strCritere
        End If
        strColKey = ""
        Select Case dvTmp.Count
            Case 0
                MsgBox("Pas de résultat disponible")
            Case 1
                'NaviguerVersResultatRecherche(dvTmp.Item(0).Item(strColKey))
                NaviguerVersResultatRecherche(0)
                myFrRecherche.Close()
                myFrRecherche.Dispose()
            Case Else
                Dim cols As New List(Of DataGridViewColumn)
                Dim rw() As DataRow = dsBase.Tables("Niveau2").Select("Table='" & maTableLocal & "' And nNiveau1=0 And AfficherRecherche=1")
                For Each rwI As DataRow In rw
                    'If Not cols.GridColumnStyles.Contains(CStr(rwI("Champs"))) Then
                    If Not rwI.IsNull("TableListeChoix") Then
                        Dim dct As New DataGridViewTextBoxColumn
                        With dct
                            .HeaderText = CType(rwI("Libelle"), String)
                            .DataPropertyName = CType(rwI("Champs"), String)
                            '.DisplayStyleForCurrentCellOnly = True
                            'For Each dr As DataRelation In rwI.Table.DataSet.Relations
                            '    If dr.ParentTable.TableName = CType(rwI("TableListeChoix"), String) And dr.ChildTable.TableName = CType(rwI("Table"), String) Then
                            '    .DataSource = rwi.Table.DataSet.Tables("").DefaultView dr.RelationName
                            '        Exit For
                            '    End If
                            'Next
                            '.DisplayMember = CType(rwI("TableListeChoixAfficheChamps"), String)
                            '.ValueMember = CType(rwI("TableListeChoixSelectChamps"), String)
                        End With
                        cols.Add(dct)
                    Else
                        Dim dct As New DataGridViewTextBoxColumn
                        With dct
                            .HeaderText = CType(rwI("Libelle"), String)
                            .DataPropertyName = CType(rwI("Champs"), String)
                            .ReadOnly = True
                        End With
                        cols.Add(dct)
                    End If
                    'End If
                Next

                myFrResultat = New FrResultatRecherche(dvTmp, strColKey, cols)
                With myFrResultat
                    .momFrRecherche = myFrRecherche
                    .Owner = myFrRecherche
                    .Show()
                End With
        End Select
    End Sub

    'Private Sub NavigationDataBindings_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    '    Redessine()
    'End Sub

    'Private Sub Redessine()
    '    BtSupprimePersonne.Width = Me.Height
    '    BtReculeFin.Left = BtSupprimePersonne.Left + BtSupprimePersonne.Width + 5
    '    BtReculeFin.Width = Me.Height
    '    BtRetourPersonne.Left = BtReculeFin.Left + BtReculeFin.Width + 5
    '    BtRetourPersonne.Width = Me.Height
    '    BtAjoutePersonne.Width = Me.Height
    '    BtAjoutePersonne.Left = Me.Width - BtAjoutePersonne.Width
    '    BtAvanceFin.Width = Me.Height
    '    BtAvanceFin.Left = BtAjoutePersonne.Left - 5 - BtAvanceFin.Width
    '    BtAvancePersonne.Width = Me.Height
    '    BtAvancePersonne.Left = BtAvanceFin.Left - 5 - BtAvancePersonne.Width
    '    BtRecherche.Visible = _AfficherBtRecherche
    '    If _AfficherBtRecherche = True Then
    '        BtRecherche.Width = Me.Height
    '    Else
    '        BtRecherche.Width = 0
    '    End If
    '    BtRecherche.Left = BtAvancePersonne.Left - 5 - BtRecherche.Width
    '    LbPosition.Left = BtRetourPersonne.Left + BtRetourPersonne.Width + 5
    '    LbPosition.Width = BtRecherche.Left - 5 - LbPosition.Left
    'End Sub

    'Private Sub LbPosition_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
    '    'Dim path As New System.Drawing.Drawing2D.GraphicsPath
    '    'Dim pts(3) As PointF
    '    'pts(0) = New PointF(0, Me.LbPosition.Height)
    '    'pts(1) = New PointF(Me.LbPosition.Width, Me.LbPosition.Height)
    '    'pts(2) = New PointF(Me.LbPosition.Width, 0)
    '    'pts(3) = New PointF(0, 0)
    '    'path.AddLines(pts)
    '    'path.CloseAllFigures()
    '    'e.Graphics.DrawPath(New Pen(Color.FromArgb(150, 0, 100, 0), 2), path)

    '    Dim rtDepart As New Rectangle
    '    rtDepart.X = Me.Left
    '    rtDepart.Y = Me.Top
    '    rtDepart.Width = Me.Width
    '    rtDepart.Height = Me.Height
    '    Dim rtButton As New Rectangle
    '    rtButton.X = 0
    '    rtButton.Y = 0
    '    rtButton.Height = Me.Height
    '    rtButton.Width = Me.Width

    '    Dim g As Graphics
    '    g = e.Graphics
    '    If Not Me.Parent.BackgroundImage Is Nothing Then
    '        g.DrawImage(Me.Parent.BackgroundImage, rtButton, rtDepart, GraphicsUnit.Pixel)
    '    Else
    '        g.Clear(Me.BackColor)
    '    End If


    '    Dim rt As RectangleF
    '    rt.X = 0
    '    rt.Y = 0
    '    rt.Height = Me.LbPosition.Height - 3
    '    rt.Width = Me.LbPosition.Width - 3
    '    Dim brsh As New Drawing2D.LinearGradientBrush(rt, Color.FromArgb(255, _DepartColor.R, _DepartColor.G, _DepartColor.B), Color.FromArgb(80, _FinColor.R, _FinColor.G, _FinColor.B), _Orientationdegrade)

    '    Dim ph As New GraphicsPath
    '    Dim nAngle As Integer = Convert.ToInt32(rt.Height / 2)
    '    Dim intervalbordure As Integer = 0
    '    Dim heightbuttongroup As Integer = Convert.ToInt32(rt.Height)
    '    ph.AddLine(intervalbordure + CInt(nAngle / 2), rt.Y, intervalbordure + rt.Width - CInt(nAngle / 2) - 1, rt.Y)
    '    ph.AddArc(intervalbordure + rt.Width - nAngle - 1, rt.Y, nAngle, nAngle, -90, 90)
    '    ph.AddLine(intervalbordure + rt.Width - 1, rt.Y + CInt(nAngle / 2), intervalbordure + rt.Width - 1, rt.Y + heightbuttongroup - 1 - CInt(nAngle / 2))

    '    ph.AddArc(intervalbordure + rt.Width - 1 - nAngle, rt.Y + heightbuttongroup - 1 - nAngle, nAngle, nAngle, 0, 90)

    '    ph.AddLine(intervalbordure + rt.Width - 1 - CInt(nAngle / 2), rt.Y + heightbuttongroup - 1, CInt(nAngle / 2), rt.Y + heightbuttongroup - 1)

    '    ph.AddArc(0, rt.Y + heightbuttongroup - 1 - nAngle, nAngle, nAngle, 90, 90)

    '    ph.AddLine(intervalbordure + 0, rt.Y + heightbuttongroup - 1 - CInt(nAngle / 2), intervalbordure + 0, rt.Y + CInt(nAngle / 2))
    '    ph.AddArc(intervalbordure + 0, rt.Y + 0, nAngle, nAngle, -180, 90)

    '    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
    '    'e.Graphics.TranslateTransform(2, 2)
    '    e.Graphics.TranslateTransform(1, 1)
    '    'e.Graphics.FillPath(New SolidBrush(Color.FromArgb(150, 0, 0, 0)), ph)
    '    e.Graphics.DrawPath(New Pen(Color.FromArgb(150, 0, 0, 0)), ph)
    '    e.Graphics.ResetTransform()
    '    'e.Graphics.FillPath(brsh, ph)
    '    e.Graphics.DrawPath(New Pen(Color.FromArgb(255, 0, 80, 0)), ph)
    '    e.Graphics.SmoothingMode = SmoothingMode.None
    '    Dim frm As New StringFormat
    '    frm.Alignment = StringAlignment.Center
    '    frm.LineAlignment = StringAlignment.Center
    '    e.Graphics.DrawString(LbPosition.Text, Me.LbPosition.Font, New SolidBrush(Me.LbPosition.ForeColor), rt, frm)
    'End Sub

    Private Sub fr_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles fr.Closing
        VerifEngrAvMove()
    End Sub

    Private Sub VerifEngrAvMove()
        If _EnregistrerOuiNon = True Then
            If fr.BindingContext(ds, maTable).Position <> -1 Then
                If _EngrDep.Count > 0 Then
                    Dim cl As DataColumn
                    Dim Ok As Boolean = False
                    For Each cl In CType(cm.Current, DataRowView).Row.Table.Columns
                        If Convert.ToString(_EngrDep.Item(cl)) <> Convert.ToString(CType(cm.Current, DataRowView).Row.Item(cl)) Then
                            Ok = True
                        End If
                    Next
                    If Ok = True Then
                        If MessageBox.Show("Voulez-vous enregistrer les modifications ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                            Dim Origine As Boolean = True
                            For Each cl In CType(cm.Current, DataRowView).Row.Table.Columns
                                If cl.ReadOnly = False Then
                                    CType(cm.Current, DataRowView).Row.Item(cl) = _EngrDep.Item(cl)
                                    If CType(cm.Current, DataRowView).Row.HasVersion(DataRowVersion.Original) = True Then
                                        If Convert.ToString(CType(cm.Current, DataRowView).Row.Item(cl, DataRowVersion.Original)) <> Convert.ToString(_EngrDep.Item(cl)) Then
                                            Origine = False
                                        End If
                                    End If
                                End If
                            Next
                            If Origine = True Then
                                CType(cm.Current, DataRowView).Row.AcceptChanges()
                            End If
                        End If
                    End If
                End If
            End If
        End If
        If Me._AutoriseSuppr = False Then
            If Me.DeleteToolStripButton.Enabled <> Me._AutoriseSuppr Then
                Me.DeleteToolStripButton.Enabled = Me._AutoriseSuppr
            End If
        End If
    End Sub

    Private Sub myFrRecherche_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles myFrRecherche.Closing
        RaiseEvent DataMove(maTable, cm.Position)
    End Sub

End Class

Public Class FrInterface
    Inherits System.Windows.Forms.Form
    Private cn As SqlClient.SqlConnection
    Private Champs As ParamNiveau2
    Private Table As String
    Dim ds As DataSet
    Dim dv As DataView
    Dim dta As SqlClient.SqlDataAdapter
    Dim LstSelected As New Collections.ArrayList
    Dim ColorLb As Color = Color.LightBlue
    Dim ColorTx As Color = Color.Blue
    Dim ColorSelected As Color = Color.Purple
    Dim ColorTxFore As Color = Color.Yellow


#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    Public Sub New(ByRef monCn As SqlClient.SqlConnection, ByVal strTable As String)
        Me.New()
        cn = monCn
        Table = strTable
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Pnl As System.Windows.Forms.Panel
    Friend WithEvents TxLeft As System.Windows.Forms.TextBox
    Friend WithEvents TxTop1 As System.Windows.Forms.TextBox
    Friend WithEvents TxHauteurLigne As System.Windows.Forms.TextBox
    Friend WithEvents TxIntervaleLigne As System.Windows.Forms.TextBox
    Friend WithEvents TxTextLeft As System.Windows.Forms.TextBox
    Friend WithEvents TxLargeurText As System.Windows.Forms.TextBox
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents BtMaj As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Pnl = New System.Windows.Forms.Panel
        Me.TxLeft = New System.Windows.Forms.TextBox
        Me.TxTop1 = New System.Windows.Forms.TextBox
        Me.TxHauteurLigne = New System.Windows.Forms.TextBox
        Me.TxIntervaleLigne = New System.Windows.Forms.TextBox
        Me.TxTextLeft = New System.Windows.Forms.TextBox
        Me.TxLargeurText = New System.Windows.Forms.TextBox
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.BtMaj = New System.Windows.Forms.Button
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(504, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Afficher"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(504, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(88, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "0"
        '
        'Pnl
        '
        Me.Pnl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pnl.AutoScroll = True
        Me.Pnl.Location = New System.Drawing.Point(8, 8)
        Me.Pnl.Name = "Pnl"
        Me.Pnl.Size = New System.Drawing.Size(488, 456)
        Me.Pnl.TabIndex = 2
        '
        'TxLeft
        '
        Me.TxLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLeft.Location = New System.Drawing.Point(504, 120)
        Me.TxLeft.Name = "TxLeft"
        Me.TxLeft.Size = New System.Drawing.Size(88, 20)
        Me.TxLeft.TabIndex = 3
        Me.TxLeft.Text = "10"
        '
        'TxTop1
        '
        Me.TxTop1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTop1.Location = New System.Drawing.Point(504, 144)
        Me.TxTop1.Name = "TxTop1"
        Me.TxTop1.Size = New System.Drawing.Size(88, 20)
        Me.TxTop1.TabIndex = 4
        Me.TxTop1.Text = "10"
        '
        'TxHauteurLigne
        '
        Me.TxHauteurLigne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxHauteurLigne.Location = New System.Drawing.Point(504, 168)
        Me.TxHauteurLigne.Name = "TxHauteurLigne"
        Me.TxHauteurLigne.Size = New System.Drawing.Size(88, 20)
        Me.TxHauteurLigne.TabIndex = 5
        Me.TxHauteurLigne.Text = "20"
        '
        'TxIntervaleLigne
        '
        Me.TxIntervaleLigne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxIntervaleLigne.Location = New System.Drawing.Point(504, 192)
        Me.TxIntervaleLigne.Name = "TxIntervaleLigne"
        Me.TxIntervaleLigne.Size = New System.Drawing.Size(88, 20)
        Me.TxIntervaleLigne.TabIndex = 6
        Me.TxIntervaleLigne.Text = "5"
        '
        'TxTextLeft
        '
        Me.TxTextLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxTextLeft.Location = New System.Drawing.Point(504, 216)
        Me.TxTextLeft.Name = "TxTextLeft"
        Me.TxTextLeft.Size = New System.Drawing.Size(88, 20)
        Me.TxTextLeft.TabIndex = 7
        Me.TxTextLeft.Text = "115"
        '
        'TxLargeurText
        '
        Me.TxLargeurText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxLargeurText.Location = New System.Drawing.Point(504, 240)
        Me.TxLargeurText.Name = "TxLargeurText"
        Me.TxLargeurText.Size = New System.Drawing.Size(88, 20)
        Me.TxLargeurText.TabIndex = 8
        Me.TxLargeurText.Text = "250"
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PropertyGrid1.CommandsBackColor = System.Drawing.Color.White
        Me.PropertyGrid1.CommandsVisibleIfAvailable = True
        Me.PropertyGrid1.HelpVisible = False
        Me.PropertyGrid1.LargeButtons = False
        Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.PropertyGrid1.Location = New System.Drawing.Point(600, 8)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(192, 456)
        Me.PropertyGrid1.TabIndex = 0
        Me.PropertyGrid1.Text = "PropertyGrid1"
        Me.PropertyGrid1.ToolbarVisible = False
        Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
        Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
        '
        'BtMaj
        '
        Me.BtMaj.Location = New System.Drawing.Point(504, 80)
        Me.BtMaj.Name = "BtMaj"
        Me.BtMaj.Size = New System.Drawing.Size(88, 32)
        Me.BtMaj.TabIndex = 9
        Me.BtMaj.Text = "Mettre à Jour"
        '
        'ComboBox1
        '
        Me.ComboBox1.Location = New System.Drawing.Point(504, 264)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(88, 21)
        Me.ComboBox1.TabIndex = 10
        Me.ComboBox1.Text = "ComboBox1"
        Me.ComboBox1.Visible = False
        '
        'FrInterface
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 470)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.BtMaj)
        Me.Controls.Add(Me.TxLargeurText)
        Me.Controls.Add(Me.TxTextLeft)
        Me.Controls.Add(Me.TxIntervaleLigne)
        Me.Controls.Add(Me.TxHauteurLigne)
        Me.Controls.Add(Me.TxTop1)
        Me.Controls.Add(Me.TxLeft)
        Me.Controls.Add(Me.Pnl)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PropertyGrid1)
        Me.KeyPreview = True
        Me.Name = "FrInterface"
        Me.Text = "FrInterface"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Try
        If cn.State <> ConnectionState.Open Then
            cn.Open()
        End If
        ds = New DataSet

        dta = New SqlClient.SqlDataAdapter("Select * From Niveau2", cn)
        Dim CmdBuilder As New SqlClient.SqlCommandBuilder(DtA)
        CmdBuilder.QuotePrefix = "["
        CmdBuilder.QuoteSuffix = "]"
        DtA.UpdateCommand = CmdBuilder.GetUpdateCommand
        DtA.InsertCommand = CmdBuilder.GetInsertCommand
        DtA.DeleteCommand = CmdBuilder.GetDeleteCommand
        DtA.Fill(ds, "Niveau2")
        dv = New DataView(ds.Tables("Niveau2"))
        dv.RowFilter = "[Table]='" & Table & "' And nNiveau1=" & Me.TextBox1.Text

        Select Case Table
            Case "Entreprise"
                Me.TxLargeurText.Text = "280"
                Me.TxTextLeft.Text = "115"
            Case "Personne"
                Me.TxLargeurText.Text = "280"
                Me.TxTextLeft.Text = "115"
            Case "Evenement"
                Me.TxLargeurText.Text = "260"
                Me.TxTextLeft.Text = "170"
            Case "Reglement"
                Me.TxLargeurText.Text = "250"
                Me.TxTextLeft.Text = "150"
            Case "Remise"
                Me.TxLargeurText.Text = "250"
                Me.TxTextLeft.Text = "150"

        End Select

        AfficheChamps()

        'Dim rws(0) As DataRow
        'rws.SetValue(Champs.Data, 0)
        'DtA.Update(rws)

        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try

    End Sub

    Private Sub AfficheChamps()
        Dim rw As DataRowView
        Dim lb As LbInterface
        Dim strTop As Integer = Convert.ToInt32(Me.TxTop1.Text)
        Dim Hauteur As Integer = Convert.ToInt32(Me.TxHauteurLigne.Text)
        Dim Interval As Integer = Convert.ToInt32(Me.TxIntervaleLigne.Text)
        Dim Left1 As Integer = Convert.ToInt32(Me.TxLeft.Text)
        Dim StartText As Integer = Convert.ToInt32(Me.TxTextLeft.Text)
        Dim LargeurText As Integer = Convert.ToInt32(Me.TxLargeurText.Text)
        Dim HauteurCb As Integer = Me.ComboBox1.Height + 1
        Me.Pnl.Controls.Clear()
        'strTop = 10
        For Each rw In dv
            If Convert.ToBoolean(rw.Item("NpAfficherFormulaire")) = False Then
                Dim strType As String = ""
                If Not rw.Item("TableListeChoixType") Is DBNull.Value Then
                    strType = Convert.ToString(rw.Item("TableListeChoixType"))
                End If

                lb = New LbInterface
                lb.Left = Left1
                lb.Top = strTop
                lb.Height = Hauteur
                lb.Width = StartText - Left1
                If Not IsDBNull(rw.Item("ListeChoix")) And IsDBNull(rw.Item("TableListeChoix")) Then
                    lb.Height = HauteurCb
                End If
                If Not rw.Item("TableListeChoix") Is DBNull.Value And (strType.ToLower = "cb" Or strType.ToLower = "cbn") Then
                    lb.Height = HauteurCb
                End If
                lb.Text = Convert.ToString(rw.Item("Libelle"))
                If Not rw.Item("LX") Is DBNull.Value Then
                    lb.Left = Convert.ToInt32(rw.Item("LX"))
                    lb.LX = Convert.ToString(rw.Item("LX"))
                End If
                If Not rw.Item("LY") Is DBNull.Value Then
                    lb.Top = Convert.ToInt32(rw.Item("LY"))
                    lb.LY = Convert.ToString(rw.Item("LY"))
                End If
                If Not rw.Item("LH") Is DBNull.Value Then
                    lb.Height = Convert.ToInt32(rw.Item("LH"))
                    lb.LH = Convert.ToString(rw.Item("LH"))
                End If
                If Not rw.Item("LW") Is DBNull.Value Then
                    lb.Width = Convert.ToInt32(rw.Item("LW"))
                    lb.LW = Convert.ToString(rw.Item("LW"))
                End If
                lb.BackColor = ColorLb
                lb.Visible = True
                lb.LType = "Lb"
                lb.LnNiveau1 = Convert.ToInt32(rw.Item("nNiveau1"))
                lb.LnNiveau2 = Convert.ToInt32(rw.Item("nNiveau2"))
                Pnl.Controls.Add(lb)
                AddHandler lb.MouseDown, AddressOf LbMouseDown
                lb = New LbInterface
                lb.Left = StartText
                lb.Top = strTop
                lb.Height = Hauteur
                lb.Width = LargeurText
                If Not IsDBNull(rw.Item("ListeChoix")) And IsDBNull(rw.Item("TableListeChoix")) Then
                    lb.Height = HauteurCb
                End If
                If Not rw.Item("TableListeChoix") Is DBNull.Value And (strType.ToLower = "cb" Or strType.ToLower = "cbn") Then
                    lb.Height = HauteurCb
                End If
                If Convert.ToBoolean(rw.Item("MultiLine")) = True Then
                    If Not rw.Item("HauteurMultiLine") Is DBNull.Value Then
                        lb.Height = Hauteur * Convert.ToInt32(rw.Item("HauteurMultiLine"))
                    End If
                End If

                If Not rw.Item("TX") Is DBNull.Value Then
                    lb.Left = Convert.ToInt32(rw.Item("TX"))
                    lb.LX = Convert.ToString(rw.Item("TX"))
                End If
                If Not rw.Item("TY") Is DBNull.Value Then
                    lb.Top = Convert.ToInt32(rw.Item("TY"))
                    lb.LY = Convert.ToString(rw.Item("TY"))
                End If
                If Not rw.Item("TH") Is DBNull.Value Then
                    lb.Height = Convert.ToInt32(rw.Item("TH"))
                    lb.LH = Convert.ToString(rw.Item("TH"))
                End If
                If Not rw.Item("TW") Is DBNull.Value Then
                    lb.Width = Convert.ToInt32(rw.Item("TW"))
                    lb.LW = Convert.ToString(rw.Item("TW"))
                End If
                lb.BackColor = ColorTx
                lb.Visible = True
                lb.LType = "Tx"
                lb.LnNiveau1 = Convert.ToInt32(rw.Item("nNiveau1"))
                lb.LnNiveau2 = Convert.ToInt32(rw.Item("nNiveau2"))
                lb.LNbLigne = Convert.ToString(rw.Item("NbLigne"))
                lb.LGroupe = Convert.ToString(rw.Item("GroupeDispo"))
                lb.LChampsConditionDispo = Convert.ToString(rw.Item("ChampsConditionDispo"))
                lb.Text = Convert.ToString(rw.Item("Champs"))
                lb.ForeColor = ColorTxFore
                Pnl.Controls.Add(lb)
                AddHandler lb.MouseDown, AddressOf LbMouseDown
                If Not rw.Item("NbLigne") Is DBNull.Value Then
                    strTop += (lb.Height + Interval) * Convert.ToInt32(rw.Item("NbLigne"))
                Else
                    strTop += lb.Height + Interval
                End If
            End If
        Next
    End Sub

    Public Sub LbMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        'Me.PropertyGrid1.SelectedObject = sender
        Dim ctl As LbInterface
        For Each ctl In LstSelected.ToArray
            If ctl.LType = "Lb" Then
                ctl.BackColor = ColorLb
            Else
                ctl.BackColor = ColorTx
            End If
        Next
        If Form.ModifierKeys = Keys.Control Then
            LstSelected.Add(sender)
        Else
            LstSelected.Clear()
            LstSelected.Add(sender)
        End If
        For Each ctl In LstSelected.ToArray
            ctl.BackColor = ColorSelected
        Next
        Me.PropertyGrid1.SelectedObjects = LstSelected.ToArray
    End Sub

    Private Sub Pnl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Pnl.MouseDown
        Dim ctl As LbInterface
        For Each ctl In LstSelected.ToArray
            If ctl.LType = "Lb" Then
                ctl.BackColor = ColorLb
            Else
                ctl.BackColor = ColorTx
            End If
        Next
        LstSelected.Clear()
        Me.PropertyGrid1.SelectedObjects = LstSelected.ToArray
    End Sub

    Private Sub BtMaj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtMaj.Click
        Dim lb As LbInterface
        For Each lb In Me.Pnl.Controls
            Dim rw() As DataRow = dv.Table.Select("nNiveau1=" & lb.LnNiveau1 & " And nNiveau2=" & lb.LnNiveau2)
            If rw.GetUpperBound(0) = 0 Then
                If lb.LType = "Lb" Then
                    If lb.LX = "" Then
                        rw(0).Item("LX") = DBNull.Value
                    Else
                        rw(0).Item("LX") = lb.LX
                    End If
                    If lb.LY = "" Then
                        rw(0).Item("LY") = DBNull.Value
                    Else
                        rw(0).Item("LY") = lb.LY
                    End If
                    If lb.LH = "" Then
                        rw(0).Item("LH") = DBNull.Value
                    Else
                        rw(0).Item("LH") = lb.LH
                    End If
                    If lb.LW = "" Then
                        rw(0).Item("LW") = DBNull.Value
                    Else
                        rw(0).Item("LW") = lb.LW
                    End If
                ElseIf lb.LType = "Tx" Then
                    If lb.LX = "" Then
                        rw(0).Item("TX") = DBNull.Value
                    Else
                        rw(0).Item("TX") = lb.LX
                    End If
                    If lb.LY = "" Then
                        rw(0).Item("TY") = DBNull.Value
                    Else
                        rw(0).Item("TY") = lb.LY
                    End If
                    If lb.LH = "" Then
                        rw(0).Item("TH") = DBNull.Value
                    Else
                        rw(0).Item("TH") = lb.LH
                    End If
                    If lb.LW = "" Then
                        rw(0).Item("TW") = DBNull.Value
                    Else
                        rw(0).Item("TW") = lb.LW
                    End If
                    If lb.LNbLigne = "" Then
                        rw(0).Item("NbLigne") = DBNull.Value
                    Else
                        rw(0).Item("NbLigne") = lb.LNbLigne
                    End If
                    If lb.LChampsConditionDispo = "" Then
                        rw(0).Item("ChampsConditionDispo") = DBNull.Value
                    Else
                        rw(0).Item("ChampsConditionDispo") = lb.LChampsConditionDispo
                    End If
                    If lb.LGroupe = "" Then
                        rw(0).Item("GroupeDispo") = DBNull.Value
                    Else
                        rw(0).Item("GroupeDispo") = lb.LGroupe
                    End If
                End If
            End If
        Next
        dta.Update(ds, "Niveau2")
        Me.AfficheChamps()
        'MessageBox.Show("Mise à Jour Terminée")
    End Sub

    Private Sub FrInterface_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim ctl As LbInterface
        Dim PasUnitaire As Integer = 5
        If e.Shift = True Then
            PasUnitaire = 1
        End If
        If Not Me.PropertyGrid1.SelectedObject Is Nothing Then
            ctl = CType(Me.PropertyGrid1.SelectedObject, LbInterface)
            For Each ctl In Me.PropertyGrid1.SelectedObjects
                If e.Control = False Then
                    Select Case e.KeyCode
                        Case Keys.Down
                            ctl.Top += PasUnitaire
                            ctl.LY = Convert.ToString(ctl.Top - Me.Pnl.AutoScrollPosition.Y)
                            e.Handled = True
                        Case Keys.Up
                            ctl.Top -= PasUnitaire
                            ctl.LY = Convert.ToString(ctl.Top - Me.Pnl.AutoScrollPosition.Y)
                            e.Handled = True
                        Case Keys.Left
                            ctl.Left -= PasUnitaire
                            ctl.LX = Convert.ToString(ctl.Left)
                        Case Keys.Right
                            ctl.Left += PasUnitaire
                            ctl.LX = Convert.ToString(ctl.Left)
                    End Select
                Else
                    Select Case e.KeyCode
                        Case Keys.Left
                            ctl.Width -= PasUnitaire
                            ctl.LW = Convert.ToString(ctl.Width)
                            e.Handled = True
                        Case Keys.Right
                            ctl.Width += PasUnitaire
                            ctl.LW = Convert.ToString(ctl.Width)
                            e.Handled = True
                        Case Keys.Up
                            ctl.Height -= PasUnitaire
                            ctl.LH = Convert.ToString(ctl.Height)
                        Case Keys.Down
                            ctl.Height += PasUnitaire
                            ctl.LH = Convert.ToString(ctl.Height)
                    End Select
                End If
            Next
        End If
    End Sub

End Class

Public Class LbInterface
    Inherits Label

    Public LType As String = ""
    Public LnNiveau1 As Integer
    Public LnNiveau2 As Integer
    Private _LX As String = ""
    Private _LY As String = ""
    Private _LH As String = ""
    Private _LW As String = ""
    Private _LNbLigne As String = ""
    Private _LGroupe As String = ""
    Private _LChampsConditionDispo As String = ""

    Public Property LChampsConditionDispo() As String
        Get
            Return _LChampsConditionDispo
        End Get
        Set(ByVal Value As String)
            _LChampsConditionDispo = Value
        End Set
    End Property

    Public Property LX() As String
        Get
            Return _LX
        End Get
        Set(ByVal Value As String)
            _LX = Value
        End Set
    End Property

    Public Property LY() As String
        Get
            Return _LY
        End Get
        Set(ByVal Value As String)
            _LY = Value
        End Set
    End Property

    Public Property LW() As String
        Get
            Return _LW
        End Get
        Set(ByVal Value As String)
            _LW = Value
        End Set
    End Property

    Public Property LH() As String
        Get
            Return _LH
        End Get
        Set(ByVal Value As String)
            _LH = Value
        End Set
    End Property

    Public Property LNbLigne() As String
        Get
            Return _LNbLigne
        End Get
        Set(ByVal Value As String)
            _LNbLigne = Value
        End Set
    End Property

    Public Property LGroupe() As String
        Get
            Return _LGroupe
        End Get
        Set(ByVal Value As String)
            _LGroupe = Value
        End Set
    End Property


    Public Sub New()
        MyBase.New()
    End Sub
End Class

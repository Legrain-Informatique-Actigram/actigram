Public Class FrPeriode
    Inherits System.Windows.Forms.Form
    Private ctl As Control
    Private _Type As String = "Date"

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New(ByVal monCtl As Control, Optional ByVal monType As String = "Date")
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        ctl = monCtl
        Type = monType
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtOk As System.Windows.Forms.Button
    Friend WithEvents TxDebut As System.Windows.Forms.TextBox
    Friend WithEvents TxFin As System.Windows.Forms.TextBox
    Friend WithEvents DtDebut As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFin As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxDebut = New System.Windows.Forms.TextBox
        Me.TxFin = New System.Windows.Forms.TextBox
        Me.BtOk = New System.Windows.Forms.Button
        Me.DtDebut = New System.Windows.Forms.DateTimePicker
        Me.dtFin = New System.Windows.Forms.DateTimePicker
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Du"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Au"
        '
        'TxDebut
        '
        Me.TxDebut.Location = New System.Drawing.Point(33, 8)
        Me.TxDebut.Name = "TxDebut"
        Me.TxDebut.Size = New System.Drawing.Size(168, 20)
        Me.TxDebut.TabIndex = 2
        '
        'TxFin
        '
        Me.TxFin.Location = New System.Drawing.Point(33, 34)
        Me.TxFin.Name = "TxFin"
        Me.TxFin.Size = New System.Drawing.Size(168, 20)
        Me.TxFin.TabIndex = 3
        '
        'BtOk
        '
        Me.BtOk.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtOk.Location = New System.Drawing.Point(148, 60)
        Me.BtOk.Name = "BtOk"
        Me.BtOk.Size = New System.Drawing.Size(75, 23)
        Me.BtOk.TabIndex = 4
        Me.BtOk.Text = "OK"
        '
        'DtDebut
        '
        Me.DtDebut.Location = New System.Drawing.Point(201, 8)
        Me.DtDebut.Name = "DtDebut"
        Me.DtDebut.Size = New System.Drawing.Size(22, 20)
        Me.DtDebut.TabIndex = 5
        '
        'dtFin
        '
        Me.dtFin.Location = New System.Drawing.Point(201, 34)
        Me.dtFin.Name = "dtFin"
        Me.dtFin.Size = New System.Drawing.Size(22, 20)
        Me.dtFin.TabIndex = 6
        '
        'FrPeriode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(233, 89)
        Me.Controls.Add(Me.dtFin)
        Me.Controls.Add(Me.DtDebut)
        Me.Controls.Add(Me.BtOk)
        Me.Controls.Add(Me.TxFin)
        Me.Controls.Add(Me.TxDebut)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrPeriode"
        Me.Text = "Sélection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Propriétés"
    Public WriteOnly Property Type() As String
        Set(ByVal Value As String)
            _Type = Value
            Select Case _Type
                Case "Date"
                    Me.Label1.Text = "Du"
                    Me.Label2.Text = "Au"
                    Me.DtDebut.Visible = True
                    Me.dtFin.Visible = True
                Case "Nombre"
                    Me.Label1.Text = "De"
                    Me.Label2.Text = "A"
                    Me.DtDebut.Visible = False
                    Me.dtFin.Visible = False
            End Select
        End Set
    End Property
#End Region

    Private Sub BtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtOk.Click
        If Not ctl Is Nothing Then
            Dim strFiltre As String = ""
            If Me.TxDebut.Text.Length > 0 Then
                strFiltre = ">=" & Me.TxDebut.Text
            End If
            If Me.TxFin.Text.Length > 0 Then
                If strFiltre.Length > 0 Then
                    strFiltre += " et "
                End If
                strFiltre += "<=" & Me.TxFin.Text
            End If
            ctl.Text = strFiltre
        End If
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub DtDebut_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtDebut.ValueChanged
        Me.TxDebut.Text = DtDebut.Value.ToString("dd/MM/yy")
    End Sub

    Private Sub dtFin_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFin.ValueChanged
        Me.TxFin.Text = dtFin.Value.ToString("dd/MM/yy")
    End Sub

    Private Sub FrPeriode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

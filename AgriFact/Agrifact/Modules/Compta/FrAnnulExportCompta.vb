Imports System
Imports System.Data.SqlClient
Imports System.IO

Public Class FrAnnulExportCompta
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBoxExport As System.Windows.Forms.ListBox
    Friend WithEvents ComboBoxType As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnuler As System.Windows.Forms.Button
    Friend WithEvents ListBoxDevis As System.Windows.Forms.ListBox
    Friend WithEvents GradientPanel2 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents GradientPanel1 As Ascend.Windows.Forms.GradientPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ComboBoxType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListBoxExport = New System.Windows.Forms.ListBox
        Me.ButtonOk = New System.Windows.Forms.Button
        Me.ButtonAnnuler = New System.Windows.Forms.Button
        Me.ListBoxDevis = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GradientPanel2 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel1 = New Ascend.Windows.Forms.GradientPanel
        Me.GradientPanel2.SuspendLayout()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBoxType
        '
        Me.ComboBoxType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxType.Items.AddRange(New Object() {"Factures de Ventes", "Règlements de Ventes", "Factures d'Achats", "Règlements d'Achats"})
        Me.ComboBoxType.Location = New System.Drawing.Point(12, 25)
        Me.ComboBoxType.Name = "ComboBoxType"
        Me.ComboBoxType.Size = New System.Drawing.Size(321, 21)
        Me.ComboBoxType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Type de pièce :"
        '
        'ListBoxExport
        '
        Me.ListBoxExport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxExport.Location = New System.Drawing.Point(12, 73)
        Me.ListBoxExport.Name = "ListBoxExport"
        Me.ListBoxExport.Size = New System.Drawing.Size(321, 173)
        Me.ListBoxExport.TabIndex = 2
        '
        'ButtonOk
        '
        Me.ButtonOk.Location = New System.Drawing.Point(179, 10)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(80, 23)
        Me.ButtonOk.TabIndex = 3
        Me.ButtonOk.Text = "OK"
        '
        'ButtonAnnuler
        '
        Me.ButtonAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonAnnuler.Location = New System.Drawing.Point(265, 10)
        Me.ButtonAnnuler.Name = "ButtonAnnuler"
        Me.ButtonAnnuler.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAnnuler.TabIndex = 4
        Me.ButtonAnnuler.Text = "Fermer"
        '
        'ListBoxDevis
        '
        Me.ListBoxDevis.Location = New System.Drawing.Point(13, 181)
        Me.ListBoxDevis.Name = "ListBoxDevis"
        Me.ListBoxDevis.Size = New System.Drawing.Size(80, 30)
        Me.ListBoxDevis.TabIndex = 5
        Me.ListBoxDevis.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Date de l'export :"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Border = New Ascend.Border(0, 1, 0, 0)
        Me.GradientPanel2.Controls.Add(Me.ButtonAnnuler)
        Me.GradientPanel2.Controls.Add(Me.ButtonOk)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.GradientHighColor = System.Drawing.SystemColors.ControlLight
        Me.GradientPanel2.GradientLowColor = System.Drawing.SystemColors.Control
        Me.GradientPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 265)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.RenderMode = Ascend.Windows.Forms.RenderMode.Glass
        Me.GradientPanel2.Size = New System.Drawing.Size(345, 45)
        Me.GradientPanel2.TabIndex = 7
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.ComboBoxType)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.ListBoxExport)
        Me.GradientPanel1.Controls.Add(Me.ListBoxDevis)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.GradientHighColor = System.Drawing.Color.White
        Me.GradientPanel1.GradientLowColor = System.Drawing.Color.Lavender
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Padding = New System.Windows.Forms.Padding(5)
        Me.GradientPanel1.Size = New System.Drawing.Size(345, 265)
        Me.GradientPanel1.TabIndex = 8
        '
        'FrAnnulExportCompta
        '
        Me.AcceptButton = Me.ButtonOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.ButtonAnnuler
        Me.ClientSize = New System.Drawing.Size(345, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrAnnulExportCompta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Annuler un Export Compta"
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim isUpdate As Boolean = False
    Dim strConnexion As String = My.Settings.AgrifactConnString
    Dim ds As New DataSet
    Dim strType As String = String.Empty

    Private Sub ComboBoxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxType.SelectedIndexChanged

        Me.isUpdate = True

        Me.ButtonOk.Enabled = False

        Select Case (Me.ComboBoxType.SelectedIndex)
            Case 0 : strType = "VFacture"
            Case 1 : strType = "Remise"
            Case 2 : strType = "AFacture"
            Case 3 : strType = "AReglement"
        End Select


        Dim strRequete As String = "select distinct( CONVERT(VARCHAR(16), DateExportCompta, 121) ) as DateExportCompta from " & strType & " where ExportCompta = 1  "


        Try
            Dim oConnection As New SqlConnection(strConnexion)
            Dim oCommand As New SqlCommand(strRequete, oConnection)
            Dim dta As New SqlClient.SqlDataAdapter(strRequete, oConnection)

            If (ds.Tables.Contains("DateExport")) Then
                ds.Tables("DateExport").Clear()
            End If


            If (ds.Tables.Contains("devis")) Then
                ds.Tables("Devis").Clear()
            End If

            dta.Fill(ds, "DateExport")
            ds.Tables("DateExport").DefaultView.Sort = "DateExportCompta Desc"

            Me.ListBoxExport.DataSource = ds.Tables("DateExport")
            Me.ListBoxExport.DisplayMember = "DateExportCompta"
            Me.ListBoxExport.ValueMember = "DateExportCompta"

        Catch err As Exception
            MsgBox("L'erreur suivante a été rencontrée :" + err.Message, MsgBoxStyle.OKOnly, "Erreur")
        End Try

        Me.isUpdate = False

        If (Me.ListBoxExport.Items.Count > 0) Then
            Me.ButtonOk.Enabled = True
            Me.ListBoxExport_SelectedIndexChanged(Nothing, Nothing)
        End If


    End Sub


    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "Etes-vous sur de vouloir annuler les Exports Compta effectués à cette date ?"
        style = MsgBoxStyle.DefaultButton2 Or _
           MsgBoxStyle.Information Or MsgBoxStyle.YesNo
        title = "Confirmation"
        response = MsgBox(msg, style, title)

        If response = MsgBoxResult.Yes Then

            Try
                Using s As New SqlProxy
                    For Each nKey As DataRowView In Me.ListBoxDevis.Items
                        Dim strRequete As String

                        If Me.strType = "VFacture" Or Me.strType = "AFacture" Then 'Facture Vente ou Achat
                            strRequete = "Update " & Me.strType & " set DateExportCompta = NULL, exportCompta = 0 where nDevis = " & CType(nKey.Row.ItemArray(0), String)
                            s.ExecuteNonQuery(strRequete)
                        ElseIf Me.strType = "Remise" Then 'Remise vente
                            'Dans le cas d'une remise de vente on annule en premier la remise
                            strRequete = "Update " & Me.strType & " set DateExportCompta = NULL, exportCompta = 0 where nRemise = " & CType(nKey.Row.ItemArray(0), String)
                            s.ExecuteNonQuery(strRequete)
                            'On annule ensuite les réglements associés
                            strRequete = "Update Reglement  set reglement.DateExportCompta = NULL, reglement.exportCompta = 0 from reglement INNER JOIN remise_detail ON (reglement.nReglement = remise_detail.nreglement and remise_detail.nremise =  " & CType(nKey.Row.ItemArray(0), String) & ")"
                            s.ExecuteNonQuery(strRequete)
                        Else 'remise achat
                            strRequete = "Update AReglement set AReglement.DateExportCompta = NULL, AReglement.exportCompta = 0 from AReglement WHERE (nReglement =  " & CType(nKey.Row.ItemArray(0), String) & ")"
                            s.ExecuteNonQuery(strRequete)
                        End If
                    Next
                End Using
            Catch err As Exception
                LogException(err)
                MsgBox("L'erreur suivante a été rencontrée :" + err.Message, MsgBoxStyle.OkOnly, "Erreur")
            End Try

            ComboBoxType_SelectedIndexChanged(Nothing, Nothing)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ListBoxExport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBoxExport.SelectedIndexChanged


        If Not isUpdate And Not Me.ListBoxExport.SelectedItem Is Nothing Then

            Dim dateDebut As String = CType(CType(Me.ListBoxExport.SelectedItem, DataRowView).Row.ItemArray(0), String)
            Dim dateFin As String = dateDebut & ":59.999"
            Dim strRequete As String = String.Empty

            If Me.strType = "VFacture" Or Me.strType = "AFacture" Then
                strRequete = "select nDevis as nKey, DateExportcompta from " & Me.strType & " where DateExportcompta between CONVERT(datetime,'" & dateDebut & "', 121) and CONVERT(datetime, '" & dateFin & "', 121)"
            ElseIf Me.strType = "Remise" Then
                strRequete = "select nRemise as nKey, DateExportcompta from " & Me.strType & " where DateExportcompta between CONVERT(datetime,'" & dateDebut & "', 121) and CONVERT(datetime, '" & dateFin & "', 121)"
            Else
                strRequete = "select nReglement as nKey, DateExportcompta from " & Me.strType & " where DateExportcompta between CONVERT(datetime,'" & dateDebut & "', 121) and CONVERT(datetime, '" & dateFin & "', 121)"
            End If

            Try
                Dim oConnection As New SqlConnection(strConnexion)
                Dim oCommand As New SqlCommand(strRequete, oConnection)
                Dim dta As New SqlClient.SqlDataAdapter(strRequete, oConnection)

                If (ds.Tables.Contains("devis")) Then
                    ds.Tables("Devis").Clear()
                End If

                dta.Fill(ds, "Devis")
                ds.Tables("Devis").DefaultView.Sort = "DateExportcompta Desc"

                Me.ListBoxDevis.DataSource = ds.Tables("Devis")
                Me.ListBoxDevis.DisplayMember = "nKey"
                Me.ListBoxDevis.ValueMember = "nKey"

            Catch err As Exception
                LogException(err)
                MsgBox("L'erreur suivante a été rencontrée :" + err.Message, MsgBoxStyle.OKOnly, "Erreur")
            End Try
        End If
    End Sub

    Private Sub FrAnnulExportCompta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetChildFormIcon(Me)
        Me.ButtonOk.Enabled = False
    End Sub

    Private Sub ButtonAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAnnuler.Click
        Me.Close()
    End Sub
End Class

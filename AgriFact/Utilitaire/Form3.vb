Public Class Form3
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TxOrdi As System.Windows.Forms.TextBox
    Friend WithEvents TxBase As System.Windows.Forms.TextBox
    Friend WithEvents TxUtilisateur As System.Windows.Forms.TextBox
    Friend WithEvents TxMotPasse As System.Windows.Forms.TextBox
    Friend WithEvents TxSql As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents DtACreance As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents OleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbConnection2 As System.Data.OleDb.OleDbConnection
    Friend WithEvents DtAClient As System.Data.OleDb.OleDbDataAdapter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form3))
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxSql = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.TxOrdi = New System.Windows.Forms.TextBox
        Me.TxBase = New System.Windows.Forms.TextBox
        Me.TxUtilisateur = New System.Windows.Forms.TextBox
        Me.TxMotPasse = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
        Me.DtACreance = New System.Data.OleDb.OleDbDataAdapter
        Me.Button5 = New System.Windows.Forms.Button
        Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand
        Me.OleDbConnection2 = New System.Data.OleDb.OleDbConnection
        Me.OleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand
        Me.DtAClient = New System.Data.OleDb.OleDbDataAdapter
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(8, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(160, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Vérif Base Locale"
        Me.Button1.Visible = False
        '
        'TxSql
        '
        Me.TxSql.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxSql.Location = New System.Drawing.Point(176, 8)
        Me.TxSql.Multiline = True
        Me.TxSql.Name = "TxSql"
        Me.TxSql.Size = New System.Drawing.Size(440, 160)
        Me.TxSql.TabIndex = 3
        Me.TxSql.Text = ""
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(176, 176)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 32)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Exécuter la Requete"
        '
        'TxOrdi
        '
        Me.TxOrdi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxOrdi.Location = New System.Drawing.Point(64, 8)
        Me.TxOrdi.Name = "TxOrdi"
        Me.TxOrdi.Size = New System.Drawing.Size(104, 20)
        Me.TxOrdi.TabIndex = 5
        Me.TxOrdi.Text = ""
        '
        'TxBase
        '
        Me.TxBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxBase.Location = New System.Drawing.Point(64, 40)
        Me.TxBase.Name = "TxBase"
        Me.TxBase.Size = New System.Drawing.Size(104, 20)
        Me.TxBase.TabIndex = 6
        Me.TxBase.Text = ""
        '
        'TxUtilisateur
        '
        Me.TxUtilisateur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxUtilisateur.Location = New System.Drawing.Point(64, 72)
        Me.TxUtilisateur.Name = "TxUtilisateur"
        Me.TxUtilisateur.Size = New System.Drawing.Size(104, 20)
        Me.TxUtilisateur.TabIndex = 7
        Me.TxUtilisateur.Text = "sa"
        '
        'TxMotPasse
        '
        Me.TxMotPasse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxMotPasse.Location = New System.Drawing.Point(64, 104)
        Me.TxMotPasse.Name = "TxMotPasse"
        Me.TxMotPasse.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.TxMotPasse.Size = New System.Drawing.Size(104, 20)
        Me.TxMotPasse.TabIndex = 8
        Me.TxMotPasse.Text = ""
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(488, 176)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 32)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Afficher la Requete"
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(176, 216)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(440, 0)
        Me.DataGrid1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Serveur"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Base"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Utilisateur"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Pwd"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(8, 176)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 32)
        Me.Button3.TabIndex = 15
        Me.Button3.Text = "Import Facture Anterieures"
        Me.Button3.Visible = False
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" & _
        "ocking Mode=1;Jet OLEDB:Database Password=;Data Source=""C:\Actigram\TDT\TDT.mdb""" & _
        ";Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider" & _
        "=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extend" & _
        "ed Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:C" & _
        "reate System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLE" & _
        "DB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database" & _
        "=False"
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT [Date], IdLibelle, Libelle, Montant, NCompte, Npiece, Service FROM CREANCE" & _
        "S"
        Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = "INSERT INTO CREANCES([Date], Libelle, Montant, NCompte, Npiece, Service) VALUES (" & _
        "?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.DBDate, 0, "Date"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Libelle", System.Data.OleDb.OleDbType.VarWChar, 255, "Libelle"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Montant", System.Data.OleDb.OleDbType.Currency, 0, "Montant"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("NCompte", System.Data.OleDb.OleDbType.Integer, 0, "NCompte"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Npiece", System.Data.OleDb.OleDbType.Integer, 0, "Npiece"))
        Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Service", System.Data.OleDb.OleDbType.VarWChar, 50, "Service"))
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = "UPDATE CREANCES SET [Date] = ?, Libelle = ?, Montant = ?, NCompte = ?, Npiece = ?" & _
        ", Service = ? WHERE (IdLibelle = ?) AND ([Date] = ? OR ? IS NULL AND [Date] IS N" & _
        "ULL) AND (Libelle = ? OR ? IS NULL AND Libelle IS NULL) AND (Montant = ? OR ? IS" & _
        " NULL AND Montant IS NULL) AND (NCompte = ? OR ? IS NULL AND NCompte IS NULL) AN" & _
        "D (Npiece = ? OR ? IS NULL AND Npiece IS NULL) AND (Service = ? OR ? IS NULL AND" & _
        " Service IS NULL)"
        Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.DBDate, 0, "Date"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Libelle", System.Data.OleDb.OleDbType.VarWChar, 255, "Libelle"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Montant", System.Data.OleDb.OleDbType.Currency, 0, "Montant"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("NCompte", System.Data.OleDb.OleDbType.Integer, 0, "NCompte"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Npiece", System.Data.OleDb.OleDbType.Integer, 0, "Npiece"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Service", System.Data.OleDb.OleDbType.VarWChar, 50, "Service"))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IdLibelle", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IdLibelle", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Date", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Date", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Libelle", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Libelle", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Libelle1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Libelle", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Montant", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Montant", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Montant1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Montant", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_NCompte", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NCompte", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_NCompte1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NCompte", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Npiece", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Npiece", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Npiece1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Npiece", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Service", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Service", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Service1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Service", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM CREANCES WHERE (IdLibelle = ?) AND ([Date] = ? OR ? IS NULL AND [Date" & _
        "] IS NULL) AND (Libelle = ? OR ? IS NULL AND Libelle IS NULL) AND (Montant = ? O" & _
        "R ? IS NULL AND Montant IS NULL) AND (NCompte = ? OR ? IS NULL AND NCompte IS NU" & _
        "LL) AND (Npiece = ? OR ? IS NULL AND Npiece IS NULL) AND (Service = ? OR ? IS NU" & _
        "LL AND Service IS NULL)"
        Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IdLibelle", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IdLibelle", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Date", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Date", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Libelle", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Libelle", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Libelle1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Libelle", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Montant", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Montant", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Montant1", System.Data.OleDb.OleDbType.Currency, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Montant", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_NCompte", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NCompte", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_NCompte1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "NCompte", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Npiece", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Npiece", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Npiece1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Npiece", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Service", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Service", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Service1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Service", System.Data.DataRowVersion.Original, Nothing))
        '
        'DtACreance
        '
        Me.DtACreance.DeleteCommand = Me.OleDbDeleteCommand1
        Me.DtACreance.InsertCommand = Me.OleDbInsertCommand1
        Me.DtACreance.SelectCommand = Me.OleDbSelectCommand1
        Me.DtACreance.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "CREANCES", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Date", "Date"), New System.Data.Common.DataColumnMapping("IdLibelle", "IdLibelle"), New System.Data.Common.DataColumnMapping("Libelle", "Libelle"), New System.Data.Common.DataColumnMapping("Montant", "Montant"), New System.Data.Common.DataColumnMapping("NCompte", "NCompte"), New System.Data.Common.DataColumnMapping("Npiece", "Npiece"), New System.Data.Common.DataColumnMapping("Service", "Service")})})
        Me.DtACreance.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(96, 176)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(72, 32)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "Import Clients"
        Me.Button5.Visible = False
        '
        'OleDbSelectCommand2
        '
        Me.OleDbSelectCommand2.CommandText = "SELECT Adresse, Cible, Code, CP, [Date], Email, Fax, Fonction, Groupe, NOM, Porta" & _
        "ble, Prénom, SOCIETE, Tél, Titre, VILLE FROM CLIENT"
        Me.OleDbSelectCommand2.Connection = Me.OleDbConnection2
        '
        'OleDbConnection2
        '
        Me.OleDbConnection2.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" & _
        "ocking Mode=0;Jet OLEDB:Database Password=;Data Source=""C:\Actigram\Donnees\LEA\" & _
        "Clients.mdb"";Password=;Jet OLEDB:Engine Type=4;Jet OLEDB:Global Bulk Transaction" & _
        "s=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=" & _
        "False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=" & _
        ";Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=F" & _
        "alse;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encr" & _
        "ypt Database=False"
        '
        'OleDbInsertCommand2
        '
        Me.OleDbInsertCommand2.CommandText = "INSERT INTO CLIENT(Adresse, Cible, Code, CP, [Date], Email, Fax, Fonction, Groupe" & _
        ", NOM, Portable, Prénom, SOCIETE, Tél, Titre, VILLE) VALUES (?, ?, ?, ?, ?, ?, ?" & _
        ", ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand2.Connection = Me.OleDbConnection2
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Adresse", System.Data.OleDb.OleDbType.VarWChar, 100, "Adresse"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Cible", System.Data.OleDb.OleDbType.VarWChar, 50, "Cible"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Code", System.Data.OleDb.OleDbType.VarWChar, 50, "Code"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("CP", System.Data.OleDb.OleDbType.VarWChar, 10, "CP"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Date", System.Data.OleDb.OleDbType.VarWChar, 50, "Date"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Email", System.Data.OleDb.OleDbType.VarWChar, 50, "Email"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 20, "Fax"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Fonction", System.Data.OleDb.OleDbType.VarWChar, 50, "Fonction"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Groupe", System.Data.OleDb.OleDbType.VarWChar, 100, "Groupe"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("NOM", System.Data.OleDb.OleDbType.VarWChar, 100, "NOM"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Portable", System.Data.OleDb.OleDbType.VarWChar, 10, "Portable"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Prénom", System.Data.OleDb.OleDbType.VarWChar, 100, "Prénom"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("SOCIETE", System.Data.OleDb.OleDbType.VarWChar, 100, "SOCIETE"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Tél", System.Data.OleDb.OleDbType.VarWChar, 20, "Tél"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Titre", System.Data.OleDb.OleDbType.VarWChar, 50, "Titre"))
        Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("VILLE", System.Data.OleDb.OleDbType.VarWChar, 50, "VILLE"))
        '
        'DtAClient
        '
        Me.DtAClient.InsertCommand = Me.OleDbInsertCommand2
        Me.DtAClient.SelectCommand = Me.OleDbSelectCommand2
        Me.DtAClient.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "CLIENT", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Adresse", "Adresse"), New System.Data.Common.DataColumnMapping("Cible", "Cible"), New System.Data.Common.DataColumnMapping("Code", "Code"), New System.Data.Common.DataColumnMapping("CP", "CP"), New System.Data.Common.DataColumnMapping("Date", "Date"), New System.Data.Common.DataColumnMapping("Email", "Email"), New System.Data.Common.DataColumnMapping("Fax", "Fax"), New System.Data.Common.DataColumnMapping("Fonction", "Fonction"), New System.Data.Common.DataColumnMapping("Groupe", "Groupe"), New System.Data.Common.DataColumnMapping("NOM", "NOM"), New System.Data.Common.DataColumnMapping("Portable", "Portable"), New System.Data.Common.DataColumnMapping("Prénom", "Prénom"), New System.Data.Common.DataColumnMapping("SOCIETE", "SOCIETE"), New System.Data.Common.DataColumnMapping("Tél", "Tél"), New System.Data.Common.DataColumnMapping("Titre", "Titre"), New System.Data.Common.DataColumnMapping("VILLE", "VILLE")})})
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 214)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TxMotPasse)
        Me.Controls.Add(Me.TxUtilisateur)
        Me.Controls.Add(Me.TxBase)
        Me.Controls.Add(Me.TxOrdi)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TxSql)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Text = "Requete"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const strConnexion As String = "workstation id=Machine;packet size=4096;initial catalog=TOURRAINE;data source=Machine;user id=Utilisateur;password=Pwd;persist security info=True"

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsParamLocaux as DataSet
        If IO.File.Exists(Application.StartupPath & "\Parametres.xml") Then
            dsParamLocaux = New DataSet
            dsParamLocaux.ReadXml(Application.StartupPath & "\Parametres.xml")
            If dsParamLocaux.Tables.Contains("Parametres") Then
                Dim Tb As DataTable = dsParamLocaux.Tables("Parametres")
                If Tb.Rows.Count > 0 Then
                    If Tb.Columns.Contains("ServeurSQL") Then
                        If Not Tb.Rows(0).Item("ServeurSQL") Is DBNull.Value Then
                            Me.TxOrdi.Text = Convert.ToString(Tb.Rows(0).Item("ServeurSQL"))
                        End If
                    End If
                    If Tb.Columns.Contains("BaseSQL") Then
                        If Not Tb.Rows(0).Item("BaseSQL") Is DBNull.Value Then
                            Me.TxBase.Text = Convert.ToString(Tb.Rows(0).Item("BaseSQL"))
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = strConnexion.Replace("Utilisateur", Me.TxUtilisateur.Text).Replace("Pwd", Me.TxMotPasse.Text).Replace("Machine", Me.TxOrdi.Text).Replace("TOURRAINE", Me.TxBase.Text)

        Try
            cn.Open()
            Dim cmd As New SqlClient.SqlCommand(TxSql.Text, cn)
            cmd.ExecuteNonQuery()
            MsgBox("Ok")
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = strConnexion.Replace("Utilisateur", Me.TxUtilisateur.Text).Replace("Pwd", Me.TxMotPasse.Text).Replace("Machine", Me.TxOrdi.Text).Replace("TOURRAINE", Me.TxBase.Text)

        Try
            cn.Open()
            Dim ds As New DataSet

            Dim dtBase As New SqlClient.SqlDataAdapter(Me.TxSql.Text, cn)
            dtBase.Fill(ds)
            Me.DataGrid1.DataSource = ds
            Me.Height = 488
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fr As New Form1
        fr.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim ds As New DataSet
        Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
        Actigram.Securite.SecuriteConverter.DeCrypeDatasetDonneesFromFile(ds, Application.StartupPath & "\XmlEnCode.xml")
        Me.DataGrid1.DataSource = ds


        Dim strConnectionString As String
        strConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""" & Application.StartupPath & "\Tdt.mdb" & """;Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False"
        Me.OleDbConnection1.ConnectionString = strConnectionString

        Dim dsTmp As New DataSet
        Me.DtACreance.Fill(dsTmp)
        Dim nbClient As Integer = 0
        Dim nbDevis As Integer = 0
        Dim ObsOk As Boolean = False

        If MessageBox.Show("Importation avec Observation ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ObsOk = True
        End If

        Dim rw As DataRow
        For Each rw In dsTmp.Tables(0).Rows
            Dim nClient As Integer
            Dim rws() As DataRow
            rws = ds.Tables("Entreprise").Select("Nom='" & Convert.ToString(rw.Item("NCompte")) & "'")
            If rws.GetUpperBound(0) >= 0 Then
                nClient = Convert.ToInt32(rws(0).Item("nEntreprise"))
            Else
                Dim rwN As DataRow
                rwN = ds.Tables("Entreprise").NewRow
                rwN.Item("TypeEntreprise") = "Siège"
                rwN.Item("Nom") = rw.Item("NCompte")
                rwN.Item("CibleCommercial") = "Compta"
                ds.Tables("Entreprise").Rows.Add(rwN)
                nClient = Convert.ToInt32(rwN.Item("nEntreprise"))
                nbClient += 1
            End If

            Dim rwnD As DataRow
            rwnD = ds.Tables("Devis").NewRow
            rwnD.Item("nClient") = nClient
            rwnD.Item("nCommercial") = 1
            rwnD.Item("Secteur") = rw.Item("Service")
            rwnD.Item("DateFacture") = rw.Item("Date")
            rwnD.Item("DateEcheance") = rw.Item("Date")
            If ObsOk = True Then
                rwnD.Item("Observation") = Convert.ToString(rw.Item("Libelle")) & " " & Convert.ToString(rw.Item("NPiece"))
            End If
            rwnD.Item("ExportCompta") = True
            ds.Tables("Devis").Rows.Add(rwnD)
            Dim nDevis As Integer = Convert.ToInt32(rwnD.Item("nDevis"))

            Dim rwnDt As DataRow
            rwnDt = ds.Tables("DetailDevis").NewRow
            rwnDt.Item("nDevis") = nDevis
            rwnDt.Item("Libelle") = Convert.ToString(rw.Item("Libelle")) & " " & Convert.ToString(rw.Item("NPiece"))
            rwnDt.Item("Qt") = 1
            rwnDt.Item("PrixUHT") = rw.Item("Montant")
            rwnDt.Item("TxTVA") = 0
            ds.Tables("DetailDevis").Rows.Add(rwnDt)

            nbDevis += 1
        Next

        MsgBox("Terminé:" & vbCrLf & "Clients : " & nbClient.ToString & vbCrLf & "Devis : " & nbDevis.ToString)

        If MessageBox.Show("Voulez-vous enregistrer les modifications apportées ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Actigram.Securite.SecuriteConverter.CrypteDataSetSchemaToFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
            Actigram.Securite.SecuriteConverter.CrypteDatasetDonneesToFile(ds, Application.StartupPath & "\XmlEnCode.xml", XmlWriteMode.DiffGram)
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ds As New DataSet
        Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
        Actigram.Securite.SecuriteConverter.DeCrypeDatasetDonneesFromFile(ds, Application.StartupPath & "\XmlEnCode.xml")
        Me.DataGrid1.DataSource = ds


        Dim strConnectionString As String
        strConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Database Password=;Data Source=""" & Application.StartupPath & "\Clients.mdb" & """;Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False"
        Me.OleDbConnection1.ConnectionString = strConnectionString

        Dim dsTmp As New DataSet
        Me.DtAClient.Fill(dsTmp)
        Dim nbEntreprise As Integer = 0
        Dim nbGroupe As Integer = 0
        Dim nbContact As Integer = 0
        Dim ObsOk As Boolean = False
        Dim nbCpt As Integer = 0

        'If MessageBox.Show("Importation avec Observation ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        '    ObsOk = True
        'End If

        Dim rw As DataRow
        For Each rw In dsTmp.Tables(0).Rows
            Dim nClient As Integer
            Dim rws() As DataRow
            Dim nGroupe As Integer = -1
            Dim nEntreprise As Integer = -1
            Dim nPersonne As Integer = -1

            Dim rwN As DataRow
            If Not rw.Item("Groupe") Is DBNull.Value Then
                rws = ds.Tables("Entreprise").Select("Nom='" & Convert.ToString(rw.Item("Groupe")).Replace("'", "''") & "'")
                If rws.GetUpperBound(0) >= 0 Then
                    nGroupe = Convert.ToInt32(rws(0).Item("nEntreprise"))
                Else
                    rwN = ds.Tables("Entreprise").NewRow
                    rwN.Item("TypeEntreprise") = "Siège"
                    rwN.Item("Nom") = rw.Item("Groupe")
                    rwN.Item("Code") = rw.Item("Code")
                    rwN.Item("Cible") = rw.Item("Cible")
                    'rwN.Item("CibleCommercial") = "Compta"
                    ds.Tables("Entreprise").Rows.Add(rwN)
                    nGroupe = Convert.ToInt32(rwN.Item("nEntreprise"))
                    nbGroupe += 1
                End If

            End If

            Dim rwNE As DataRow
            rwNE = ds.Tables("Entreprise").NewRow
            rwNE.Item("TypeEntreprise") = "Siège"
            rwNE.Item("Nom") = rw.Item("Societe")
            rwNE.Item("Code") = rw.Item("Code")
            If nGroupe <> -1 Then
                rwNE.Item("nMaisonMere") = nGroupe
            End If
            rwNE.Item("Cible") = rw.Item("Cible")
            rwNE.Item("Adresse") = rw.Item("Adresse")
            rwNE.Item("CodePostal") = rw.Item("CP")
            rwNE.Item("Ville") = rw.Item("Ville")
            ds.Tables("Entreprise").Rows.Add(rwNE)
            nEntreprise = Convert.ToInt32(rwNE.Item("nEntreprise"))
            nbEntreprise += 1

            If Not rw.Item("Tél") Is DBNull.Value Then
                If IsNumeric(rw.Item("Tél")) = True Then
                    Dim rwNEC As DataRow
                    rwNEC = ds.Tables("TelephoneEntreprise").NewRow
                    rwNEC.Item("nEntreprise") = nEntreprise
                    rwnec.Item("Type") = "Standard"
                    rwnec.Item("Numero") = Convert.ToInt32(Convert.ToString(rw.Item("Tél")).Replace(" ", "")).ToString("##.##.##.##.##")
                    ds.Tables("TelephoneEntreprise").Rows.Add(rwNEC)
                End If
            End If

            If Not rw.Item("Fax") Is DBNull.Value Then
                If IsNumeric(rw.Item("Fax")) = True Then
                    Dim rwNEC As DataRow
                    rwNEC = ds.Tables("TelephoneEntreprise").NewRow
                    rwNEC.Item("nEntreprise") = nEntreprise
                    rwnec.Item("Type") = "Fax"
                    rwnec.Item("Numero") = Convert.ToInt32(Convert.ToString(rw.Item("Fax")).Replace(" ", "")).ToString("##.##.##.##.##")
                    ds.Tables("TelephoneEntreprise").Rows.Add(rwNEC)
                End If
            End If

            If Not rw.Item("Nom") Is DBNull.Value Then
                Dim rwNEC As DataRow
                rwNEC = ds.Tables("Personne").NewRow
                rwNEC.Item("Titre") = rw.Item("Titre")
                rwNEC.Item("Nom") = rw.Item("Nom")
                rwNEC.Item("Prenom") = rw.Item("Prénom")
                rwNEC.Item("nEntreprise") = nEntreprise
                rwNEC.Item("Fonction") = rw.Item("Fonction")
                ds.Tables("Personne").Rows.Add(rwNEC)
                nPersonne = Convert.ToInt32(rwNEC.Item("nPersonne"))
                nbContact += 1

                If Not rw.Item("Portable") Is DBNull.Value Then
                    If IsNumeric(rw.Item("Portable")) = True Then
                        Dim rwNECP As DataRow
                        rwNECP = ds.Tables("Telephone").NewRow
                        rwNECP.Item("nPersonne") = nPersonne
                        rwNECP.Item("Type") = "Portable"
                        rwNECP.Item("Numero") = Convert.ToInt32(Convert.ToString(rw.Item("Portable")).Replace(" ", "")).ToString("##.##.##.##.##")
                        ds.Tables("Telephone").Rows.Add(rwNECP)
                    End If
                End If

            End If
            nbCpt += 1

            If nbCpt >= 1000 Then
                nbCpt = 0
                If MessageBox.Show("Voulez-vous enregistrer les modifications apportées ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Actigram.Securite.SecuriteConverter.CrypteDataSetSchemaToFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
                    Actigram.Securite.SecuriteConverter.CrypteDatasetDonneesToFile(ds, Application.StartupPath & "\XmlEnCode.xml", XmlWriteMode.DiffGram)
                    MsgBox("ok")
                    Actigram.Securite.SecuriteConverter.DeCrypeDatasetSchemaFromFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
                    Actigram.Securite.SecuriteConverter.DeCrypeDatasetDonneesFromFile(ds, Application.StartupPath & "\XmlEnCode.xml")
                End If
            End If

        Next

        MsgBox("Terminé:" & vbCrLf & "Groupe : " & nbGroupe.ToString & vbCrLf & "Entreprise : " & nbEntreprise.ToString & vbCrLf & "Contact : " & nbContact.ToString)

        If MessageBox.Show("Voulez-vous enregistrer les modifications apportées ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Actigram.Securite.SecuriteConverter.CrypteDataSetSchemaToFile(ds, Application.StartupPath & "\XmlEnCodeSchema.xml")
            Actigram.Securite.SecuriteConverter.CrypteDatasetDonneesToFile(ds, Application.StartupPath & "\XmlEnCode.xml", XmlWriteMode.DiffGram)
        End If

    End Sub
End Class

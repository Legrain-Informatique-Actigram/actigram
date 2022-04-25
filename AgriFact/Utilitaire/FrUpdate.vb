Imports Actigram.Securite.SecuriteConverter
Imports Actigram

Public Class FrUpdate
    Inherits System.Windows.Forms.Form
    Dim saPwd As String = ""
    Dim ServiceURL As String = "http://nestor2/servicelea/service1.asmx"

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
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button2 = New System.Windows.Forms.Button
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection
        Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(8, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Charger"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(32, 56)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT IdProduit, Secteur, Categorie, SousCategorie, CodeProduit, Libelle, Method" & _
        "e, Prix, TarifOrganisme, AutreMethode, Observations, PrixUHT FROM Résultats"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "workstation id=DELL;packet size=4096;user id=sa;data source=LACHEZE;persist secur" & _
        "ity info=True;initial catalog=LEAV2;password=ludo"
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = "INSERT INTO Résultats(IdProduit, Secteur, Categorie, SousCategorie, CodeProduit, " & _
        "Libelle, Methode, Prix, TarifOrganisme, AutreMethode, Observations, PrixUHT) VAL" & _
        "UES (@IdProduit, @Secteur, @Categorie, @SousCategorie, @CodeProduit, @Libelle, @" & _
        "Methode, @Prix, @TarifOrganisme, @AutreMethode, @Observations, @PrixUHT); SELECT" & _
        " IdProduit, Secteur, Categorie, SousCategorie, CodeProduit, Libelle, Methode, Pr" & _
        "ix, TarifOrganisme, AutreMethode, Observations, PrixUHT FROM Résultats WHERE (Id" & _
        "Produit = @IdProduit)"
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdProduit", System.Data.SqlDbType.Int, 4, "IdProduit"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Secteur", System.Data.SqlDbType.NVarChar, 255, "Secteur"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Categorie", System.Data.SqlDbType.NVarChar, 255, "Categorie"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SousCategorie", System.Data.SqlDbType.NVarChar, 255, "SousCategorie"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodeProduit", System.Data.SqlDbType.NVarChar, 50, "CodeProduit"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Libelle", System.Data.SqlDbType.NVarChar, 1073741823, "Libelle"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Methode", System.Data.SqlDbType.NVarChar, 255, "Methode"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Prix", System.Data.SqlDbType.NVarChar, 50, "Prix"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TarifOrganisme", System.Data.SqlDbType.NVarChar, 50, "TarifOrganisme"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AutreMethode", System.Data.SqlDbType.NVarChar, 255, "AutreMethode"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observations", System.Data.SqlDbType.NVarChar, 255, "Observations"))
        Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrixUHT", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "PrixUHT", System.Data.DataRowVersion.Current, Nothing))
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = "UPDATE Résultats SET IdProduit = @IdProduit, Secteur = @Secteur, Categorie = @Cat" & _
        "egorie, SousCategorie = @SousCategorie, CodeProduit = @CodeProduit, Libelle = @L" & _
        "ibelle, Methode = @Methode, Prix = @Prix, TarifOrganisme = @TarifOrganisme, Autr" & _
        "eMethode = @AutreMethode, Observations = @Observations, PrixUHT = @PrixUHT WHERE" & _
        " (IdProduit = @Original_IdProduit) AND (AutreMethode = @Original_AutreMethode OR" & _
        " @Original_AutreMethode IS NULL AND AutreMethode IS NULL) AND (Categorie = @Orig" & _
        "inal_Categorie OR @Original_Categorie IS NULL AND Categorie IS NULL) AND (CodePr" & _
        "oduit = @Original_CodeProduit OR @Original_CodeProduit IS NULL AND CodeProduit I" & _
        "S NULL) AND (Methode = @Original_Methode OR @Original_Methode IS NULL AND Method" & _
        "e IS NULL) AND (Observations = @Original_Observations OR @Original_Observations " & _
        "IS NULL AND Observations IS NULL) AND (Prix = @Original_Prix OR @Original_Prix I" & _
        "S NULL AND Prix IS NULL) AND (PrixUHT = @Original_PrixUHT OR @Original_PrixUHT I" & _
        "S NULL AND PrixUHT IS NULL) AND (Secteur = @Original_Secteur OR @Original_Secteu" & _
        "r IS NULL AND Secteur IS NULL) AND (SousCategorie = @Original_SousCategorie OR @" & _
        "Original_SousCategorie IS NULL AND SousCategorie IS NULL) AND (TarifOrganisme = " & _
        "@Original_TarifOrganisme OR @Original_TarifOrganisme IS NULL AND TarifOrganisme " & _
        "IS NULL); SELECT IdProduit, Secteur, Categorie, SousCategorie, CodeProduit, Libe" & _
        "lle, Methode, Prix, TarifOrganisme, AutreMethode, Observations, PrixUHT FROM Rés" & _
        "ultats WHERE (IdProduit = @IdProduit)"
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IdProduit", System.Data.SqlDbType.Int, 4, "IdProduit"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Secteur", System.Data.SqlDbType.NVarChar, 255, "Secteur"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Categorie", System.Data.SqlDbType.NVarChar, 255, "Categorie"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SousCategorie", System.Data.SqlDbType.NVarChar, 255, "SousCategorie"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CodeProduit", System.Data.SqlDbType.NVarChar, 50, "CodeProduit"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Libelle", System.Data.SqlDbType.NVarChar, 1073741823, "Libelle"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Methode", System.Data.SqlDbType.NVarChar, 255, "Methode"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Prix", System.Data.SqlDbType.NVarChar, 50, "Prix"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TarifOrganisme", System.Data.SqlDbType.NVarChar, 50, "TarifOrganisme"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@AutreMethode", System.Data.SqlDbType.NVarChar, 255, "AutreMethode"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Observations", System.Data.SqlDbType.NVarChar, 255, "Observations"))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PrixUHT", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "PrixUHT", System.Data.DataRowVersion.Current, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_IdProduit", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IdProduit", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_AutreMethode", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AutreMethode", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Categorie", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Categorie", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CodeProduit", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodeProduit", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Methode", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Methode", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Observations", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Observations", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Prix", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Prix", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PrixUHT", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "PrixUHT", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Secteur", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Secteur", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SousCategorie", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SousCategorie", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TarifOrganisme", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TarifOrganisme", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = "DELETE FROM Résultats WHERE (IdProduit = @Original_IdProduit) AND (AutreMethode =" & _
        " @Original_AutreMethode OR @Original_AutreMethode IS NULL AND AutreMethode IS NU" & _
        "LL) AND (Categorie = @Original_Categorie OR @Original_Categorie IS NULL AND Cate" & _
        "gorie IS NULL) AND (CodeProduit = @Original_CodeProduit OR @Original_CodeProduit" & _
        " IS NULL AND CodeProduit IS NULL) AND (Methode = @Original_Methode OR @Original_" & _
        "Methode IS NULL AND Methode IS NULL) AND (Observations = @Original_Observations " & _
        "OR @Original_Observations IS NULL AND Observations IS NULL) AND (Prix = @Origina" & _
        "l_Prix OR @Original_Prix IS NULL AND Prix IS NULL) AND (PrixUHT = @Original_Prix" & _
        "UHT OR @Original_PrixUHT IS NULL AND PrixUHT IS NULL) AND (Secteur = @Original_S" & _
        "ecteur OR @Original_Secteur IS NULL AND Secteur IS NULL) AND (SousCategorie = @O" & _
        "riginal_SousCategorie OR @Original_SousCategorie IS NULL AND SousCategorie IS NU" & _
        "LL) AND (TarifOrganisme = @Original_TarifOrganisme OR @Original_TarifOrganisme I" & _
        "S NULL AND TarifOrganisme IS NULL)"
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_IdProduit", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IdProduit", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_AutreMethode", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "AutreMethode", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Categorie", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Categorie", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CodeProduit", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CodeProduit", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Methode", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Methode", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Observations", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Observations", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Prix", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Prix", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PrixUHT", System.Data.SqlDbType.Decimal, 9, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(2, Byte), "PrixUHT", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Secteur", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Secteur", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SousCategorie", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "SousCategorie", System.Data.DataRowVersion.Original, Nothing))
        Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TarifOrganisme", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TarifOrganisme", System.Data.DataRowVersion.Original, Nothing))
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Résultats", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IdProduit", "IdProduit"), New System.Data.Common.DataColumnMapping("Secteur", "Secteur"), New System.Data.Common.DataColumnMapping("Categorie", "Categorie"), New System.Data.Common.DataColumnMapping("SousCategorie", "SousCategorie"), New System.Data.Common.DataColumnMapping("CodeProduit", "CodeProduit"), New System.Data.Common.DataColumnMapping("Libelle", "Libelle"), New System.Data.Common.DataColumnMapping("Methode", "Methode"), New System.Data.Common.DataColumnMapping("Prix", "Prix"), New System.Data.Common.DataColumnMapping("TarifOrganisme", "TarifOrganisme"), New System.Data.Common.DataColumnMapping("AutreMethode", "AutreMethode"), New System.Data.Common.DataColumnMapping("Observations", "Observations"), New System.Data.Common.DataColumnMapping("PrixUHT", "PrixUHT")})})
        Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
        '
        'FrUpdate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(136, 46)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrUpdate"
        Me.Text = "FrUpdate"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim swActigramUpDate As New internet.Service1
        'swActigramUpDate.Url = "http://dell/servicelea/service1.asmx"
        'swActigramUpDate.Url = "http://nestor2/servicelea/service1.asmx"

        If IO.File.Exists(Application.StartupPath & "\Parametres.xml") Then
            Dim dsParamLocaux As New DataSet
            dsParamLocaux.ReadXml(Application.StartupPath & "\Parametres.xml")
            If dsParamLocaux.Tables.Contains("Parametres") Then
                If dsParamLocaux.Tables("Parametres").Rows.Count > 0 Then
                    If dsParamLocaux.Tables("Parametres").Columns.Contains("ServiceURL") Then
                        If Not dsParamLocaux.Tables("Parametres").Rows(0).Item("ServiceURL") Is DBNull.Value Then
                            ServiceURL = Convert.ToString(dsParamLocaux.Tables("Parametres").Rows(0).Item("ServiceURL"))
                        End If
                    End If
                    If dsParamLocaux.Tables("Parametres").Columns.Contains("saPwd") Then
                        If Not dsParamLocaux.Tables("Parametres").Rows(0).Item("saPwd") Is DBNull.Value Then
                            saPwd = Convert.ToString(dsParamLocaux.Tables("Parametres").Rows(0).Item("saPwd"))
                        End If
                    End If
                End If
            End If
        End If

        swActigramUpDate.Url = ServiceURL
        swActigramUpDate.Discover()

        Dim frP As New Actigram.Windows.Forms.FrProgressBar

        Try
            Dim strchemin As String
            Me.OpenFileDialog1.Multiselect = True
            Me.OpenFileDialog1.ShowDialog()

            frP.Minimum = 0
            frP.Maximum = Me.OpenFileDialog1.FileNames.GetUpperBound(0) + 1
            frP.Value = 0
            frP.Show()

            For Each strchemin In Me.OpenFileDialog1.FileNames


                Dim fl As New IO.FileInfo(strchemin)

                Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(strchemin)

                frP.Text = myFileVersionInfo.FileName
                frP.Value += 1

                Dim strFichier As String
                Dim strResult As String = ""
                strResult = swActigramUpDate.UpLoadNouvelleVersionFichier(CrypteString("sa"), CrypteString(saPwd), myFileVersionInfo.FileVersion, fl.Name, Fichiers.ManipulationFichier.FichierToBase64(strchemin))
                If strResult <> "" Then
                    MsgBox(strResult)
                End If
            Next

            frP.Close()
            frP.Dispose()

            MsgBox("Chargement Nouvelle Version Terminée")
        Catch ex As Exception

            If Not frP Is Nothing Then
                frP.Close()
                frP.Dispose()
            End If

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ds As New DataSet
        Me.SqlDataAdapter1.Fill(ds)

        Dim rw As DataRow
        For Each rw In ds.Tables(0).Rows
            If Not rw.Item("Prix") Is DBNull.Value Then
                If IsNumeric(rw.Item("Prix")) = False Then
                    rw.Item("PrixUHT") = Val(rw.Item("Prix"))
                Else
                    rw.Item("PrixUHT") = rw.Item("Prix")
                End If
            Else
                rw.Item("PrixUHT") = DBNull.Value
            End If
        Next
        Me.SqlDataAdapter1.Update(ds)
        MessageBox.Show("Terminée", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class

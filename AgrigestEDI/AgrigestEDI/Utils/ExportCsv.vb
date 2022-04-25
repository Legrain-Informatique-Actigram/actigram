Public Class ExportCsv
    Private _ExportDT As DataTable
    Private _ExporterEnTete As Boolean
    Private _Separateur As String
    Private _NomFichier As String

#Region "Public Enum"
    Public Enum SeparateurEnum
        TAB = 1
        COMMA = 2
        POINTVIRGULE = 3
    End Enum
#End Region

#Region "Constructeurs"
    Public Sub New(ByVal exportDT As DataTable, ByVal separateur As SeparateurEnum, ByVal exporterEnTete As Boolean, ByVal nomFichier As String)
        Me._ExportDT = exportDT
        Me._ExporterEnTete = exporterEnTete

        Select Case separateur
            Case SeparateurEnum.TAB
                Me._Separateur = vbTab
            Case SeparateurEnum.COMMA
                Me._Separateur = ","
            Case SeparateurEnum.POINTVIRGULE
                Me._Separateur = ";"
        End Select

        Me._NomFichier = nomFichier
    End Sub
#End Region

#Region "Méthodes diverses"
    Public Sub Exporter(Optional ByVal progressBar As System.Windows.Forms.ProgressBar = Nothing)
        Dim n As Integer = 0

        If Not (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(Me._NomFichier))) Then
            Throw New Exception("Le répertoire de destination n'existe pas.")
        End If

        'Me.FormaterValeurCellules()

        Using sw As New IO.StreamWriter(Me._NomFichier, False, System.Text.Encoding.Default)
            'Entetes
            Dim ligne(Me._ExportDT.Columns.Count - 1) As String

            If (Me._ExporterEnTete) Then
                For i As Integer = 0 To Me._ExportDT.Columns.Count - 1
                    ligne(i) = String.Format("{0}", Me._ExportDT.Columns.Item(i).ColumnName)
                Next
            End If

            sw.WriteLine(String.Join(";", ligne) & ";")

            'valeurs
            If Not (progressBar Is Nothing) Then
                progressBar.Value = 0
                Application.DoEvents()
            End If

            For Each row As DataRow In Me._ExportDT.Rows
                For i As Integer = 0 To Me._ExportDT.Columns.Count - 1
                    ligne(i) = String.Format("{0}", ReplaceVBCRLFStr(row.Item(i).ToString))
                Next

                sw.WriteLine(String.Join(";", ligne) & ";")

                n += 1

                If Not (progressBar Is Nothing) Then
                    progressBar.Value = CInt(n * 100 / Me._ExportDT.Rows.Count)
                    Application.DoEvents()
                End If
            Next
        End Using
    End Sub

    Private Sub FormaterValeurCellules()
        Dim j As Integer = 0
        Dim v As Integer = 0

        For j = 0 To Me._ExportDT.Rows.Count - 1
            For v = 0 To Me._ExportDT.Columns.Count - 1
                If IsDBNull(Me._ExportDT.Rows(j).Item(v)) = True Then
                    If Me._ExportDT.Columns(v).DataType Is System.Type.GetType("System.String") Then
                        Me._ExportDT.Rows(j).Item(v) = ""
                    ElseIf Me._ExportDT.Columns(v).DataType Is System.Type.GetType("System.Integer") Then
                        Me._ExportDT.Rows(j).Item(v) = 0
                    ElseIf Me._ExportDT.Columns(v).DataType Is System.Type.GetType("system.Boolean") Then
                        Me._ExportDT.Rows(j).Item(v) = False
                    ElseIf Me._ExportDT.Columns(v).DataType Is System.Type.GetType("system.Single") Then
                        Me._ExportDT.Rows(j).Item(v) = 0.0
                    End If
                End If
            Next
        Next
    End Sub

    Private Function ReplaceVBCRLFStr(ByVal strValue As String) As String
        Dim temp As String = String.Empty

        temp = Replace(strValue, vbCrLf, vbLf, , , CompareMethod.Text)
        temp = Replace(strValue, Chr(13), " ", , , CompareMethod.Text)
        temp = Replace(strValue, Chr(10), " ", , , CompareMethod.Text)

        ReplaceVBCRLFStr = temp

        Return ReplaceVBCRLFStr
    End Function
#End Region

End Class

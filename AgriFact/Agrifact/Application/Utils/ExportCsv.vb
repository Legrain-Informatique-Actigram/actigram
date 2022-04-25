Imports System.Text
Imports System.IO
Imports System.Data

Namespace Utilitaires
    Public Class ExportCsv

        Private _ExportDT As DataTable
        Private _ExporterEnTete As Boolean
        Private _Separateur As String
        Private _NomFichier As String
        Private _ExportDataGridView As DataGridView

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

        Public Sub New(ByVal exportDataGridView As DataGridView, ByVal separateur As SeparateurEnum, ByVal exporterEnTete As Boolean, ByVal nomFichier As String)
            Me._ExportDataGridView = exportDataGridView
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

            Me._ExportDT = Me.CreerDataTableAPartirDeDataGridView()
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Sub Exporter()
            If Not (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(Me._NomFichier))) Then
                Throw New Exception("Le répertoire de destination n'existe pas.")
            End If

            Using sw As New IO.StreamWriter(Me._NomFichier, False, System.Text.Encoding.Default)
                If Not (Me._ExportDT Is Nothing) Then
                    'Me.FormaterValeurCellules()


                    'Entetes
                    Dim ligne(Me._ExportDT.Columns.Count - 1) As String

                    If (Me._ExporterEnTete) Then
                        For i As Integer = 0 To Me._ExportDT.Columns.Count - 1
                            ligne(i) = String.Format("{0}", Me._ExportDT.Columns.Item(i).ColumnName)
                        Next
                    End If

                    sw.WriteLine(String.Join(";", ligne) & ";")

                    'valeurs
                    For Each row As DataRow In Me._ExportDT.Rows
                        For i As Integer = 0 To Me._ExportDT.Columns.Count - 1
                            ligne(i) = String.Format("{0}", ReplaceVBCRLFStr(row.Item(i).ToString))
                        Next

                        sw.WriteLine(String.Join(";", ligne) & ";")
                    Next
                Else
                    sw.WriteLine()
                End If
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

            'temp = Replace(strValue, vbCrLf, " ", , , CompareMethod.Text)
            'temp = Replace(strValue, vbCr, " ", , , CompareMethod.Text)
            'temp = Replace(strValue, vbLf, " ", , , CompareMethod.Text)
            'temp = Replace(strValue, Chr(13), " ", , , CompareMethod.Text)
            'temp = Replace(strValue, Chr(10), " ", , , CompareMethod.Text)

            temp = Replace(strValue, vbCrLf, " ", , , CompareMethod.Text)
            temp = Replace(temp, vbCr, " ", , , CompareMethod.Text)
            temp = Replace(temp, vbLf, " ", , , CompareMethod.Text)
            temp = Replace(temp, Chr(13), " ", , , CompareMethod.Text)
            temp = Replace(temp, Chr(10), " ", , , CompareMethod.Text)

            ReplaceVBCRLFStr = temp

            Return ReplaceVBCRLFStr
        End Function

        Private Function CreerDataTableAPartirDeDataGridView() As DataTable
            Dim table As New DataTable

            If Not (Me._ExportDataGridView Is Nothing) Then
                'Création des colonnes
                For Each dgvc As DataGridViewColumn In Me._ExportDataGridView.Columns
                    If (dgvc.Visible) Then
                        Dim column As DataColumn = New DataColumn

                        With column
                            .DataType = dgvc.ValueType
                            .AllowDBNull = True
                            .Caption = dgvc.DataPropertyName
                            .ColumnName = dgvc.DataPropertyName
                        End With

                        table.Columns.Add(column)
                    End If
                Next

                'Ajout des lignes
                For Each dgvr As DataGridViewRow In Me._ExportDataGridView.Rows
                    Dim row As DataRow = table.NewRow()
                    Dim n As Integer = 0

                    For i As Integer = 0 To Me._ExportDataGridView.Columns.Count - 1
                        If (Me._ExportDataGridView.Columns(i).Visible) Then
                            row.Item(n) = dgvr.Cells(i).Value

                            n += 1
                        End If
                    Next

                    table.Rows.Add(row)
                Next
            End If

            Return table
        End Function
#End Region

    End Class
End Namespace

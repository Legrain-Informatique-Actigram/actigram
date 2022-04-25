Imports System.Windows.Forms
Module Exports
    Public Sub ExporterCSV(ByVal r As Requete, ByVal dt As DataTable, ByVal fichier As String, ByVal paramValues As Dictionary(Of String, String))
        Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
        'Titre
        sw.WriteLine(r.Titre)
        'Parametres
        For Each p As Parametre In r.Parametres
            sw.WriteLine(String.Format(";{0};{1}", p.Libelle, paramValues(p.Nom)))
        Next
        'En tetes
        Dim ligne(dt.Columns.Count - 1) As String
        For i As Integer = 0 To dt.Columns.Count - 1
            ligne(i) = String.Format("""{0}""", dt.Columns(i).ColumnName)
        Next
        sw.WriteLine(String.Join(";", ligne))
        'Valeurs
        ligne.Initialize()
        For Each dr As DataRow In dt.Rows
            For i As Integer = 0 To dt.Columns.Count - 1
                ligne(i) = String.Format("""{0}""", dr(i))
            Next
            sw.WriteLine(String.Join(";", ligne))
        Next
        sw.Close()
    End Sub

    Public Sub ExporterCSV(ByVal req As Requete, ByVal dg As DataGridView, ByVal fichier As String, ByVal paramValues As Dictionary(Of String, String))
        Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
        'Titre
        sw.WriteLine(req.Titre)
        'Parametres
        For Each p As Parametre In req.Parametres
            sw.WriteLine(String.Format(";{0};{1}", p.Libelle, paramValues(p.Nom)))
        Next
        'Entetes
        Dim ligne(dg.Columns.Count - 1) As String
        For i As Integer = 0 To dg.Columns.Count - 1
            ligne(i) = String.Format("""{0}""", dg.Columns(i).HeaderText)
        Next
        sw.WriteLine(String.Join(";", ligne))
        'Valeurs
        ligne.Initialize()
        For Each r As DataGridViewRow In dg.Rows
            For i As Integer = 0 To r.Cells.Count - 1
                ligne(i) = String.Format("""{0}""", r.Cells(i).FormattedValue)
            Next
            sw.WriteLine(String.Join(";", ligne))
        Next
        sw.Close()
    End Sub

    Public Sub ExporterHTML(ByVal r As Requete, ByVal dt As DataTable, ByVal fichier As String, ByVal paramValues As Dictionary(Of String, String))
        Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
        sw.WriteLine(HtmlHeader(r.Titre))
        sw.WriteLine(ParamsTable(r.Parametres, paramValues))
        sw.WriteLine("<table cellspacing=""0"">")
        Dim ligne(dt.Columns.Count - 1) As String
        For i As Integer = 0 To dt.Columns.Count - 1
            ligne(i) = String.Format("{0}", dt.Columns(i).ColumnName)
        Next
        sw.WriteLine("<thead><tr><th>" & String.Join("</th><th>", ligne) & "</th></tr></thead>")
        sw.WriteLine("<tbody>")
        ligne.Initialize()
        Dim even As Boolean = True
        For Each dr As DataRow In dt.Rows
            even = Not even
            For i As Integer = 0 To dt.Columns.Count - 1
                ligne(i) = String.Format("{0}", dr(i))
            Next
            Dim parity As String = ""
            If even Then parity = " class=""even"""
            sw.WriteLine("<tr" & parity & "><td>" & String.Join("</td><td>", ligne) & "</td></tr>")
        Next
        sw.WriteLine("</tbody></table>")
        sw.WriteLine(HtmlFooter)
        sw.Close()
    End Sub

    Public Sub ExporterHTML(ByVal req As Requete, ByVal dg As DataGridView, ByVal fichier As String, ByVal paramValues As Dictionary(Of String, String))
        Dim sw As New IO.StreamWriter(fichier, False, System.Text.Encoding.Default)
        sw.WriteLine(HtmlHeader(req.Titre))
        sw.WriteLine(ParamsTable(req.Parametres, paramValues))
        sw.WriteLine("<table cellspacing=""0"">")
        Dim ligne(dg.Columns.Count - 1) As String
        For i As Integer = 0 To dg.Columns.Count - 1
            ligne(i) = String.Format("<th>{0}</th>", dg.Columns(i).HeaderText)
        Next
        sw.WriteLine("<thead><tr>" & String.Join("", ligne) & "</tr></thead>")
        sw.WriteLine("<tbody>")
        ligne.Initialize()
        For Each r As DataGridViewRow In dg.Rows
            For i As Integer = 0 To r.Cells.Count - 1
                Dim classStr As String = ""
                Select Case r.Cells(i).OwningColumn.DefaultCellStyle.Alignment
                    Case DataGridViewContentAlignment.MiddleLeft : classStr = " class=""left"""
                    Case DataGridViewContentAlignment.MiddleRight : classStr = " class=""right"""
                    Case DataGridViewContentAlignment.MiddleCenter : classStr = " class=""center"""
                End Select
                Dim str As String = Convert.ToString(r.Cells(i).FormattedValue)
                If str.Length = 0 Then str = "&nbsp;"
                ligne(i) = String.Format("<td{1}>{0}</td>", str, classStr)
            Next
            Dim parity As String = ""
            If r.Index Mod 2 = 0 Then parity = " class=""even"""
            sw.WriteLine("<tr" & parity & ">" & String.Join("", ligne) & "</tr>")
        Next
        sw.WriteLine("</tbody></table>")
        sw.WriteLine(HtmlFooter)
        sw.Close()
    End Sub

    Private Function HtmlHeader(ByVal titre As String) As String
        Dim res As New System.Text.StringBuilder
        res.AppendLine("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">")
        res.AppendLine("<html xmlns=""http://www.w3.org/1999/xhtml"" >")
        res.AppendFormat("<head><title>{0}</title></head>", titre)
        res.AppendLine()
        res.AppendLine("<style type=""text/css"">" & CssStyleSheet() & "</style>")
        res.AppendFormat("<body><h1>{0}</h1>", titre)
        res.AppendFormat("<div class=""date"">Imprimé le {0:dd/MM/yyyy}</div>", Now)
        res.AppendLine()
        Return res.ToString
    End Function

    Private Function ParamsTable(ByVal params As List(Of Parametre), ByVal values As Dictionary(Of String, String)) As String
        If params.Count = 0 Then Return ""
        Dim res As New System.Text.StringBuilder
        res.AppendLine("<h2>Paramètres : </h2>")
        res.AppendLine("<ul>")
        For Each p As Parametre In params
            res.AppendFormat("<li>{0} : {1}</li>" & vbCrLf, p.Libelle, values(p.Nom))
        Next
        res.AppendLine("</ul>")
        Return res.ToString
    End Function

    Private Function HtmlFooter() As String
        Return "</body></html>"
    End Function

    Private Function CssStyleSheet() As String
        Dim cssPath As String = IO.Path.Combine(My.Application.Info.DirectoryPath, "print.css")
        If IO.File.Exists(cssPath) Then
            Return My.Computer.FileSystem.ReadAllText(cssPath)
        Else
            Return My.Resources.defaultCss
        End If
    End Function
End Module

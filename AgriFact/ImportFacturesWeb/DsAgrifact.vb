Partial Class DsAgrifact
    Partial Class TVADataTable
        Public Function FindByTTVA(ByVal ttva As String) As TVARow
            Dim rws() As DataRow = Me.Select("TTVA='" & ttva.Replace("'", "''") & "'")
            If rws.Length > 0 Then
                Return Cast(Of TVARow)(rws(0))
            Else
                Return Nothing
            End If
        End Function
    End Class

    Partial Class ProduitDataTable
        Public Function FindByCodeProduit(ByVal codeProduit As String) As ProduitRow
            Dim rws() As DataRow = Me.Select("CodeProduit='" & codeProduit.Replace("'", "''") & "'")
            If rws.Length > 0 Then
                Return Cast(Of ProduitRow)(rws(0))
            Else
                Return Nothing
            End If
        End Function

        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.ProduitTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.ProduitTableAdapter)
            Me.nProduitColumn.AutoIncrementSeed = GetNewId(dta)
        End Sub

        Public Function GetNewId(ByVal dta As DsAgrifactTableAdapters.ProduitTableAdapter) As Integer
            Return SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nProduitColumn.ColumnName) + 1
        End Function
    End Class

    Partial Class EntrepriseDataTable
        Public Function FindByNom(ByVal nom As String) As EntrepriseRow
            Dim rws() As DataRow = Me.Select("Nom='" & nom.Replace("'", "''") & "'")
            If rws.Length > 0 Then
                Return Cast(Of EntrepriseRow)(rws(0))
            Else
                Return Nothing
            End If
        End Function

        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.EntrepriseTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.EntrepriseTableAdapter)
            Me.nEntrepriseColumn.AutoIncrementSeed = GetNewId(dta)
        End Sub

        Public Function GetNewId(ByVal dta As DsAgrifactTableAdapters.EntrepriseTableAdapter) As Integer
            Return SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nEntrepriseColumn.ColumnName) + 1
        End Function
    End Class

    Partial Class VFactureDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.VFactureTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.VFactureTableAdapter)
            Me.nDevisColumn.AutoIncrementSeed = GetNewId(dta)
        End Sub

        Public Function GetNewId(ByVal dta As DsAgrifactTableAdapters.VFactureTableAdapter) As Integer
            Return SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nDevisColumn.ColumnName) + 1
        End Function
    End Class

    Partial Class VFacture_DetailDataTable
        Public Sub InitAutoIncrementSeed()
            Using dta As New DsAgrifactTableAdapters.VFacture_DetailTableAdapter
                InitAutoIncrementSeed(dta)
            End Using
        End Sub

        Public Sub InitAutoIncrementSeed(ByVal dta As DsAgrifactTableAdapters.VFacture_DetailTableAdapter)
            Me.nDetailDevisColumn.AutoIncrementSeed = GetNewId(dta)
        End Sub

        Public Function GetNewId(ByVal dta As DsAgrifactTableAdapters.VFacture_DetailTableAdapter) As Integer
            Return SqlProxy.GetMaxValue(dta.Connection, Me.TableName, Me.nDetailDevisColumn.ColumnName) + 1
        End Function
    End Class

    Partial Class EntrepriseRow
        Public Function CreerCodeTiers(ByVal s As SqlProxy) As String
            If Me.IsNomNull Then Return ""
            Dim res As String = Me.Nom.Trim.ToUpper
            If res.IndexOf(" ") >= 0 Then
                res = res.Substring(res.IndexOf(" ") + 1)
            End If
            res = "+" & Left(res, 7)
            res = DedoublonnerCodeTiers(res, s)
            Return res
        End Function

        Private Function DedoublonnerCodeTiers(ByVal codetiers As String, ByVal s As SqlProxy) As String
            Dim sql As String = "SELECT COUNT(*) FROM Entreprise WHERE CodeTiers={0}"
            Dim nb As Integer
            Dim i As Integer = 0
            Do
                nb = s.ExecuteScalarInt(SqlProxy.FormatSql(sql, codetiers))
                If nb > 0 Then
                    i += 1
                    codetiers = Left(codetiers, 7) & i
                End If
            Loop Until nb = 0
            Return codetiers
        End Function
    End Class
End Class

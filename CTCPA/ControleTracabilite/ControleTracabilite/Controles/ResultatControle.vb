Namespace Controles
    Public Class ResultatControle

        Private _nResultatControle As Integer
        Private _nControle As Integer = -1
        Private _CodeProduit As String
        Private _nLot As String
        Private _TestEffectue As Boolean
        Private _Resultat As String
        Private _ResultatConformite As Boolean

        Private _DefinitionControle As Controles.DefinitionControle
        Private _ListeResultatsBaremes As New List(Of Controles.ResultatBareme)

#Region "Propriétés"
        Public Property nResultatControle() As Integer
            Get
                Return Me._nResultatControle
            End Get
            Set(ByVal value As Integer)
                Me._nResultatControle = value
            End Set
        End Property

        Public Property nControle() As Integer
            Get
                If Me.DefinitionControle IsNot Nothing Then
                    _nControle = Me.DefinitionControle.nControle
                End If
                Return Me._nControle
            End Get
            Set(ByVal value As Integer)
                Me._nControle = value
            End Set
        End Property

        Public Property CodeProduit() As String
            Get
                Return Me._CodeProduit
            End Get
            Set(ByVal value As String)
                Me._CodeProduit = value
            End Set
        End Property

        Public Property nLot() As String
            Get
                Return _nLot
            End Get
            Set(ByVal value As String)
                _nLot = value
            End Set
        End Property

        Public Property TestEffectue() As Boolean
            Get
                Return Me._TestEffectue
            End Get
            Set(ByVal value As Boolean)
                Me._TestEffectue = value
            End Set
        End Property

        Public Property Resultat() As String
            Get
                Return Me._Resultat
            End Get
            Set(ByVal value As String)
                Me._Resultat = value
            End Set
        End Property

        Public Property ResultatConformite() As Boolean
            Get
                Dim conforme As Boolean = True
                For Each rb As ResultatBareme In Me.ListeResultatsBaremes
                    conforme = conforme And rb.ResultatConformite
                    If Not conforme Then Exit For
                Next
                Return conforme
            End Get
            Set(ByVal value As Boolean)
                Me._ResultatConformite = value
            End Set
        End Property

        Public Property DefinitionControle() As Controles.DefinitionControle
            Get
                Return Me._DefinitionControle
            End Get
            Set(ByVal value As DefinitionControle)
                Me._DefinitionControle = value
            End Set
        End Property

        Public ReadOnly Property LibControle() As String
            Get
                If Me._DefinitionControle Is Nothing Then
                    Return ""
                Else
                    Return Me._DefinitionControle.Libelle
                End If
            End Get
        End Property

        Public Property ListeResultatsBaremes() As List(Of ControleTracabilite.Controles.ResultatBareme)
            Get
                Return Me._ListeResultatsBaremes
            End Get
            Set(ByVal value As List(Of ControleTracabilite.Controles.ResultatBareme))
                Me._ListeResultatsBaremes = value
            End Set
        End Property

        Public ReadOnly Property ResultatsBaremesCount() As Integer
            Get
                Return Me.ListeResultatsBaremes.Count
            End Get
        End Property

        Public ReadOnly Property ToutesActionsCoEffectuees() As Boolean
            Get
                Dim eff As Boolean = True
                For Each rb As ResultatBareme In Me.ListeResultatsBaremes
                    eff = eff And (rb.ResultatExpression OrElse rb.ActionCorrectiveEffectuee OrElse (rb.Observations IsNot Nothing AndAlso rb.Observations.Length > 0))
                    If Not eff Then Exit For
                Next
                Return eff
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal ctl As Control)
            Me.new()

            With Me
                .DefinitionControle = CType(ctl.Tag, DefinitionControle)
                .CodeProduit = .DefinitionControle.CodeProduit
                .Resultat = CType(.DefinitionControle.GetResultat(ctl), String)
                .TraiteResultat()
            End With
        End Sub

        Public Sub New(ByVal dr As AgrifactTracaDataSet.ResultatControleRow)
            Me.New()

            With Me
                .CodeProduit = dr.CodeProduit
                .nLot = dr.nLot
                .TestEffectue = dr.TestEffectue
                If dr.DefinitionControleRow IsNot Nothing Then
                    .DefinitionControle = New DefinitionControle(dr.DefinitionControleRow)
                Else
                    .nControle = dr.nControle
                End If
                If Not dr.IsResultatNull Then .Resultat = dr.Resultat
                .ListeResultatsBaremes.Clear()
                For Each drB As AgrifactTracaDataSet.ResultatBaremeRow In dr.GetResultatBaremeRows
                    .ListeResultatsBaremes.Add(New ResultatBareme(drB))
                Next
            End With
        End Sub

        Public Sub New(ByVal nControle As Integer, ByVal nLot As String, ByVal codeProduit As String)
            Using resultatControleTA As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                Dim resultatControleDT As AgrifactTracaDataSet.ResultatControleDataTable = resultatControleTA.GetDataBynControleEtnLotEtCodeProduit(nControle, nLot, codeProduit)

                For Each resultatControleDR As AgrifactTracaDataSet.ResultatControleRow In resultatControleDT.Rows
                    Me.nResultatControle = resultatControleDR.nResultatControle
                    Me.nControle = resultatControleDR.nControle
                    Me.CodeProduit = resultatControleDR.CodeProduit
                    Me.nLot = resultatControleDR.nLot
                    Me.TestEffectue = resultatControleDR.TestEffectue

                    If Not (resultatControleDR.IsResultatNull) Then
                        Me.Resultat = resultatControleDR.Resultat
                    Else
                        Me.Resultat = String.Empty
                    End If

                    'récupération des infos de la table ResultatBareme
                    Me.ListeResultatsBaremes.Clear()

                    Using resultatBaremeTA As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                        Dim resultatBaremeDT As AgrifactTracaDataSet.ResultatBaremeDataTable = resultatBaremeTA.GetDataBynResultatControle(Me._nResultatControle)

                        For Each resultatBaremeDR As AgrifactTracaDataSet.ResultatBaremeRow In resultatBaremeDT.Rows
                            Me.ListeResultatsBaremes.Add(New ResultatBareme(resultatBaremeDR.nResultatBareme))
                        Next
                    End Using
                Next
            End Using
        End Sub
#End Region

#Region "Méthodes partagées"
        Public Shared Function Charger(ByVal codeProduit As String, ByVal nLot As String, Optional ByVal chargerControles As Boolean = False) As List(Of ResultatControle)
            Dim ds As New AgrifactTracaDataSet
            Using dta As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                dta.FillByProduitAndLot(ds.ResultatControle, CodeProduit, nLot)
            End Using
            Using dta As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                dta.FillByProduitAndLot(ds.ResultatBareme, CodeProduit, nLot)
            End Using
            If chargerControles Then
                Using dta As New AgrifactTracaDataSetTableAdapters.DefinitionControleTableAdapter
                    dta.FillByCodeProduit(ds.DefinitionControle, CodeProduit)
                End Using
                Using dta As New AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
                    dta.FillByCodeProduit(ds.Bareme, CodeProduit)
                End Using
            End If
            Return Charger(ds.ResultatControle)
        End Function

        Public Shared Function Charger(ByVal ds As AgrifactTracaDataSet) As List(Of ResultatControle)
            Return Charger(ds.ResultatControle)
        End Function

        Public Shared Function Charger(ByVal dt As AgrifactTracaDataSet.ResultatControleDataTable) As List(Of ResultatControle)
            Dim res As New List(Of ResultatControle)
            For Each dr As AgrifactTracaDataSet.ResultatControleRow In dt.Rows
                res.Add(New ResultatControle(dr))
            Next
            Return res
        End Function

        Public Shared Sub Enregistrer(ByVal list As List(Of ResultatControle))
            Using dtaC As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                Using dtaB As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                    Enregistrer(list, dtaC, dtaB)
                End Using
            End Using
        End Sub

        Public Shared Sub Enregistrer(ByVal list As List(Of ResultatControle), ByVal dtaC As AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter, ByVal dtaB As AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter)
            Dim ds As New AgrifactTracaDataSet
            For Each rc As ResultatControle In list
                Dim drC As AgrifactTracaDataSet.ResultatControleRow = ds.ResultatControle.NewResultatControleRow
                With drC
                    .CodeProduit = rc.CodeProduit
                    .nLot = rc.nLot
                    .nControle = rc.nControle
                    .TestEffectue = rc.TestEffectue
                    .Resultat = rc.Resultat
                    .ResultatConformite = rc.ResultatConformite
                End With
                ds.ResultatControle.Rows.Add(drC)
                For Each rb As ResultatBareme In rc.ListeResultatsBaremes
                    If rb.Bareme IsNot Nothing Then
                        Dim drB As AgrifactTracaDataSet.ResultatBaremeRow = ds.ResultatBareme.NewResultatBaremeRow
                        With drB
                            .nResultatControle = drC.nResultatControle
                            .nBareme = rb.Bareme.nBareme
                            .ActionCorrectiveEffectuee = rb.ActionCorrectiveEffectuee
                            .ResultatExpression = rb.ResultatExpression
                            .ResultatConformite = rb.ResultatConformite
                            .Observations = rb.Observations
                        End With
                        ds.ResultatBareme.Rows.Add(drB)
                    End If
                Next
            Next
            dtaC.Update(ds.ResultatControle)
            dtaB.Update(ds.ResultatBareme)
        End Sub

        Public Shared Sub Effacer(ByVal codeProduit As String, ByVal nLot As String)
            Using dtaC As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                Using dtaB As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                    Effacer(codeProduit, nLot, dtaC, dtaB)
                End Using
            End Using
        End Sub

        Public Shared Sub Effacer(ByVal codeProduit As String, ByVal nLot As String, ByVal dtaC As AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter, ByVal dtaB As AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter)
            'Effacer les RésultatsBareme
            dtaB.DeleteByProduitAndLot(codeProduit, nLot)
            'Effacer les RésultatsControle
            dtaC.DeleteByProduitAndLot(codeProduit, nLot)
        End Sub

        Public Shared Function GetResultat(ByVal ctl As Control) As ResultatControle
            Dim c As DefinitionControle = CType(ctl.Tag, DefinitionControle)
            Select Case c.Type
                Case "Separator"
                    Return Nothing
                Case Else
                    Return New ResultatControle(ctl)
            End Select
        End Function

        Public Shared Function IsEffectue(ByVal r As ResultatControle) As Boolean
            Return r.TestEffectue
        End Function

        Public Shared Function IsNonConforme(ByVal r As ResultatControle) As Boolean
            Return Not r.ResultatConformite
        End Function

        Public Shared Sub Update(ByVal nResultatControle As Integer, ByVal testEffectue As Boolean, _
                                ByVal resultat As String, ByVal resultatConformite As Boolean)
            Using resultatControleTA As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                resultatControleTA.UpdateInfosResultat(testEffectue, resultat, resultatConformite, _
                                                        nResultatControle)
            End Using
        End Sub

        Public Shared Function Insert(ByVal resultatControle As Controles.ResultatControle) As Integer
            Using resultatControleTA As New AgrifactTracaDataSetTableAdapters.ResultatControleTableAdapter
                Return CInt(resultatControleTA.InsertComplet(resultatControle.nControle, resultatControle.CodeProduit, _
                        resultatControle.nLot, resultatControle.TestEffectue, resultatControle.Resultat, _
                        resultatControle.ResultatConformite))
            End Using
        End Function
#End Region

#Region "Méthodes diverses" '
        Public Sub TraiteResultat()
            With Me
                .TestEffectue = .Resultat IsNot Nothing
                If .TestEffectue Then
                    .ListeResultatsBaremes.Clear()
                    For Each b As Bareme In .DefinitionControle.ListeBaremes
                        .ListeResultatsBaremes.Add(b.GetResultat(.Resultat))
                    Next
                End If
            End With
        End Sub

        Public Overrides Function ToString() As String
            If Me._DefinitionControle Is Nothing Then
                Return MyBase.ToString
            Else
                If Not Me.TestEffectue Then
                    Return String.Format("{{Question {0} :'{1}' non renseigné}}", Me._DefinitionControle.IdControle, Me._DefinitionControle.Libelle)
                Else
                    Dim sb As New System.Text.StringBuilder
                    sb.AppendLine(String.Format("{{Question {0} :'{1}' = {2}}}", Me._DefinitionControle.IdControle, Me._DefinitionControle.Libelle, Me.Resultat))
                    For Each rb As ResultatBareme In Me.ListeResultatsBaremes
                        sb.AppendLine(rb.ToString)
                    Next
                    Return sb.ToString
                End If
            End If
        End Function
#End Region

    End Class
End Namespace

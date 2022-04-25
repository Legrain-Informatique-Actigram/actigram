Namespace Controles
    Public Class ResultatBareme

        Private _nResultatBareme As Integer
        Private _nResultatControle As Integer
        Private _nBareme As Integer
        Private _ResultatExpression As Boolean = False
        Private _ResultatConformite As Boolean = False
        Private _ActionCorrectiveEffectuee As Boolean = False
        Private _Observations As String

        Private _Bareme As Controles.Bareme

#Region "Propriétés"
        Public Property nResultatBareme() As Integer
            Get
                Return Me._nResultatBareme
            End Get
            Set(ByVal value As Integer)
                Me._nResultatBareme = value
            End Set
        End Property

        Public Property nResultatControle() As Integer
            Get
                Return Me._nResultatControle
            End Get
            Set(ByVal value As Integer)
                Me._nResultatControle = value
            End Set
        End Property

        Public Property nBareme() As Integer
            Get
                Return Me._nBareme
            End Get
            Set(ByVal value As Integer)
                Me._nBareme = value
            End Set
        End Property

        Public Property ResultatExpression() As Boolean
            Get
                Return Me._ResultatExpression
            End Get
            Set(ByVal value As Boolean)
                Me._ResultatExpression = value
            End Set
        End Property

        Public Property ResultatConformite() As Boolean
            Get
                Return Me._ResultatConformite
            End Get
            Set(ByVal value As Boolean)
                Me._ResultatConformite = value
            End Set
        End Property

        Public Property ActionCorrectiveEffectuee() As Boolean
            Get
                Return Me._ActionCorrectiveEffectuee
            End Get
            Set(ByVal value As Boolean)
                Me._ActionCorrectiveEffectuee = value
            End Set
        End Property

        Public Property Observations() As String
            Get
                Return Me._Observations
            End Get
            Set(ByVal value As String)
                Me._Observations = value
            End Set
        End Property

        Public Property Bareme() As Bareme
            Get
                Return Me._Bareme
            End Get
            Set(ByVal value As Bareme)
                Me._Bareme = value
            End Set
        End Property

        Public ReadOnly Property BaremeExpression() As String
            Get
                If Me._Bareme Is Nothing Then
                    Return ""
                Else
                    Return Me._Bareme.Expression
                End If
            End Get
        End Property

        Public ReadOnly Property ActionCorrective() As String
            Get
                If Me._Bareme Is Nothing Or Me._ResultatExpression Then
                    Return ""
                Else
                    Return Me._Bareme.ActionCorrective
                End If
            End Get
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal dr As AgrifactTracaDataSet.ResultatBaremeRow)
            Me.New()
            With Me
                .ResultatExpression = dr.ResultatExpression
                .ResultatConformite = dr.ResultatConformite
                .ActionCorrectiveEffectuee = dr.ActionCorrectiveEffectuee
                If Not dr.IsObservationsNull Then .Observations = dr.Observations
                If dr.BaremeRow IsNot Nothing Then
                    .Bareme = New Bareme(dr.BaremeRow)
                End If
            End With
        End Sub

        Public Sub New(ByVal nResultatBareme As Integer)
            Using resultatBaremeTA As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                Dim resultatBaremeDT As AgrifactTracaDataSet.ResultatBaremeDataTable = resultatBaremeTA.GetDataBynResultatBareme(nResultatBareme)

                For Each resultatBaremeDR As AgrifactTracaDataSet.ResultatBaremeRow In resultatBaremeDT.Rows
                    Me.nResultatBareme = resultatBaremeDR.nResultatBareme
                    Me.nResultatControle = resultatBaremeDR.nResultatControle
                    Me.nBareme = resultatBaremeDR.nBareme
                    Me.ResultatExpression = resultatBaremeDR.ResultatExpression
                    Me.ResultatConformite = resultatBaremeDR.ResultatConformite

                    If Not (resultatBaremeDR.IsObservationsNull) Then
                        Me.Observations = resultatBaremeDR.Observations
                    Else
                        Me.Observations = String.Empty
                    End If

                    'Récupération des infos de la table Bareme
                    Me.Bareme = New Bareme(Me.nBareme)
                Next
            End Using
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Overrides Function ToString() As String
            Dim sb As New System.Text.StringBuilder

            sb.AppendLine(String.Format(" Evaluation de '{0}' = {1} => Conforme={2} ", Me.Bareme.Expression, Me.ResultatExpression, Me.ResultatConformite))

            If Not Me.ResultatExpression Then
                sb.AppendLine(String.Format(" => Action corrective : '{0}'", Me.Bareme.ActionCorrective))
            End If

            Return sb.ToString
        End Function
#End Region

#Region "Méthodes partagées"
        Public Shared Sub Update(ByVal resultatBareme As Controles.ResultatBareme)
            Using resultatBaremeTA As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                resultatBaremeTA.Update(resultatBareme.nResultatControle, resultatBareme.nBareme, _
                                    resultatBareme.ResultatExpression, resultatBareme.ResultatConformite, _
                                    resultatBareme.ActionCorrectiveEffectuee, resultatBareme.Observations, _
                                    resultatBareme._nResultatBareme)
            End Using
        End Sub

        Public Shared Sub Insert(ByVal resultatBareme As Controles.ResultatBareme)
            Using resultatBaremeTA As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                resultatBaremeTA.Insert(resultatBareme.nResultatControle, resultatBareme.nBareme, _
                                    resultatBareme.ResultatExpression, resultatBareme.ResultatConformite, _
                                    resultatBareme.ActionCorrectiveEffectuee, resultatBareme.Observations)
            End Using
        End Sub

        Public Shared Sub DeleteBynResultatControle(ByVal nResultatControle As Integer)
            Using resultatBaremeTA As New AgrifactTracaDataSetTableAdapters.ResultatBaremeTableAdapter
                resultatBaremeTA.DeleteBynResultatControle(nResultatControle)
            End Using
        End Sub
#End Region

    End Class
End Namespace

Namespace Controles
    Public Class Bareme
        Implements ICloneable

        Private _nBareme As Integer
        Private _nControle As Integer
        Private _Expression As String
        Private _ResultatConformite As Boolean
        Private _CheminDoc As String
        Private _ActionCorrective As String

        Private _resControle As String

#Region "Propriétés"
        Public Property nBareme() As Integer
            Get
                Return Me._nBareme
            End Get
            Set(ByVal value As Integer)
                Me._nBareme = value
            End Set
        End Property

        Public Property nControle() As Integer
            Get
                Return Me._nControle
            End Get
            Set(ByVal value As Integer)
                Me._nControle = value
            End Set
        End Property

        Public Property Expression() As String
            Get
                Return Me._Expression
            End Get
            Set(ByVal value As String)
                Me._Expression = value
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

        Public Property CheminDoc() As String
            Get
                Return Me._CheminDoc
            End Get
            Set(ByVal value As String)
                Me._CheminDoc = value
            End Set
        End Property

        Public Property ActionCorrective() As String
            Get
                Return Me._ActionCorrective
            End Get
            Set(ByVal value As String)
                Me._ActionCorrective = value
            End Set
        End Property
#End Region

#Region "Constructeurs"
        Public Sub New()

        End Sub

        Public Sub New(ByVal dr As AgrifactTracaDataSet.BaremeRow)
            Me.New()
            Me.nBareme = dr.nBareme
            Me.Expression = dr.Expression
            Me.ResultatConformite = dr.ResultatConformite
            If Not dr.IsCheminDocNull Then Me.CheminDoc = CheminPDF(dr.CheminDoc)
            If Not dr.IsActionCorrectiveNull Then Me.ActionCorrective = dr.ActionCorrective
        End Sub

        Public Sub New(ByVal expression As String, ByVal action As String, ByVal resultatconformite As Boolean)
            Me.New()
            Me.Expression = expression
            Me.ActionCorrective = action
            Me.ResultatConformite = resultatconformite
        End Sub

        Public Sub New(ByVal nBareme As Integer)
            Using baremeTA As New AgrifactTracaDataSetTableAdapters.BaremeTableAdapter
                Dim baremeDT As AgrifactTracaDataSet.BaremeDataTable = baremeTA.GetDataByNBareme(nBareme)

                For Each baremeDR As AgrifactTracaDataSet.BaremeRow In baremeDT.Rows
                    Me.nBareme = baremeDR.nBareme
                    Me.nControle = baremeDR.nControle

                    If Not (baremeDR.IsExpressionNull) Then
                        Me.Expression = baremeDR.Expression
                    Else
                        Me.Expression = String.Empty
                    End If

                    Me.ResultatConformite = baremeDR.ResultatConformite

                    If Not (baremeDR.IsCheminDocNull) Then
                        Me.CheminDoc = baremeDR.CheminDoc
                    Else
                        Me.CheminDoc = String.Empty
                    End If

                    If Not (baremeDR.IsActionCorrectiveNull) Then
                        Me.ActionCorrective = baremeDR.ActionCorrective
                    Else
                        Me.ActionCorrective = String.Empty
                    End If
                Next
            End Using
        End Sub
#End Region

#Region "Méthodes diverses"
        Public Function GetResultat(ByVal resControle As String) As ResultatBareme
            Dim r As New ResultatBareme
            With r
                .Bareme = Me
                Try
                    .ResultatExpression = Me.EvaluerResultat(resControle)
                    .ResultatConformite = (.ResultatExpression Or Me.ResultatConformite)
                Catch ex As Exception
                    .ResultatExpression = False
                End Try
            End With
            Return r
        End Function

        Private Function EvaluerResultat(ByVal resControle As String) As Boolean
            Return EvaluerResultat(Me.Expression, resControle)
        End Function

        Public Function EvaluerResultat(ByVal expression As String, ByVal resControle As String) As Boolean
            _resControle = resControle
            Dim ev As New Eval.Evaluator
            AddHandler ev.GetVariable, AddressOf EvGetVariable
            Dim res As Boolean = False
            Boolean.TryParse(ev.Eval(expression).ToString, res)
            Return res
        End Function

        Private Sub EvGetVariable(ByVal name As String, ByRef value As Object)
            Select Case name
                Case "val"
                    Dim v As String = _resControle.Replace(".", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
                    v = v.Replace(",", My.Application.Culture.NumberFormat.NumberDecimalSeparator)
                    If IsNumeric(v) Then
                        value = Double.Parse(v)
                    Else
                        Dim d As Date
                        If Date.TryParseExact(_resControle, "dd/MM/yyyy HH:mm:ss", My.Application.Culture.DateTimeFormat, Globalization.DateTimeStyles.None, d) Then
                            value = d
                        Else
                            value = _resControle
                        End If
                    End If
                Case Else
                    value = Nothing
            End Select
            LogMessage(String.Format("Variable '{0}'='{1}'", name, value))
        End Sub

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Dim b As New Bareme
            With b
                .Expression = Me.Expression
                .ResultatConformite = Me.ResultatConformite
                .ActionCorrective = Me.ActionCorrective
                .CheminDoc = Me.CheminDoc
            End With
            Return b
        End Function

        Private Shared Function CheminPDF(ByVal value As String) As String
            If Not IO.Path.IsPathRooted(value) Then
                Return IO.Path.Combine(My.Settings.AbsoluteRepPdf, value)
            Else
                Return value
            End If
        End Function
#End Region

    End Class
End Namespace

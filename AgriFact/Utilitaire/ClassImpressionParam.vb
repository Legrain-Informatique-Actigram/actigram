Namespace Impression.Perso

    Public Class Doc
        Private _LstPages As Pages

#Region "Propriétés"

        Public Property LstPages() As Pages
            Get
                Return _LstPages
            End Get
            Set(ByVal Value As Pages)
                _LstPages = Value
            End Set
        End Property

#End Region

    End Class

    Public Class Pages
        Inherits CollectionBase

        Public Sub New()
            MyBase.New()
        End Sub

#Region "Propriétés"

#End Region

        Public Function Add(ByVal Page As Page) As Pages
            Me.List.Add(Page)
        End Function

        Public Sub Remove(ByVal Page As Page)
            Me.List.Remove(Page)
        End Sub

    End Class

    Public Class Page
        Private _LstObjetImpression As ObjetsImp

#Region "Propriétés"

        Public Property LstObjetImpression() As ObjetsImp
            Get
                Return _LstObjetImpression
            End Get
            Set(ByVal Value As ObjetsImp)
                _LstObjetImpression = Value
            End Set
        End Property

#End Region

    End Class


    Public Class ObjetsImp
        Inherits Label
        Private _Expression As String
        Private _Format As String
        Private _Valeur As String

#Region "Propriétés"

        Public ReadOnly Property Valeur() As String
            Get
                If Me.Expression <> "" Then
                    Me.Calcul()
                End If
                Return Me.Text
            End Get
        End Property


        Public Property Nom() As String
            Get
                Return Me.Name
            End Get
            Set(ByVal Value As String)
                Me.Name = Value
            End Set
        End Property

        Public Property X() As Integer
            Get
                Return Me.Left
            End Get
            Set(ByVal Value As Integer)
                Me.Left = Value
            End Set
        End Property

        Public Property Y() As Integer
            Get
                Return Me.Top
            End Get
            Set(ByVal Value As Integer)
                Me.Top = Value
            End Set
        End Property

        Public Property Expression() As String
            Get
                Return _Expression
            End Get
            Set(ByVal Value As String)
                _Expression = Value
            End Set
        End Property

        Public Property Format() As String
            Get
                Return _Format
            End Get
            Set(ByVal Value As String)
                _Format = Value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
            MyBase.BorderStyle = BorderStyle.FixedSingle
        End Sub

        Public Sub Calcul()
            If Me.Expression <> "" Then
                Me.Text = Utilitaire.Math.Expressions.CalculExpression(Utilitaire.Impression.EtatsSynthese.ClassSynthese.AnalyseFourchette(AnalyseValeurControl(Me.Expression))).ToString(Me.Format)
            End If
        End Sub

        Public Function AnalyseValeurControl(ByVal Expression As String) As String
            Dim str() As String
            str = Expression.Split("["c, "]"c)

            Dim i As Integer
            For i = 0 To str.GetUpperBound(0)
                If Expression.IndexOf("[" & str(i) & "]") >= 0 Then
                    Dim strF() As String
                    strF = str(i).Split(";"c)
                    If strF.GetUpperBound(0) = 0 Then
                        Dim ctl As Control
                        For Each ctl In Me.Parent.Controls
                            If ctl.Name = strF(0) Then
                                If TypeOf ctl Is ObjetsImp Then
                                    str(i) = CType(ctl, ObjetsImp).Valeur
                                Else
                                    str(i) = ctl.Text
                                End If
                                Exit For
                            End If
                        Next
                    End If
                End If
            Next
            Expression = String.Join("", str)
            Return Expression

        End Function


    End Class

End Namespace



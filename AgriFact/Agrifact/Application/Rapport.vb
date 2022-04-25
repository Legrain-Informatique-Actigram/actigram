Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Rapport

    Public FileName As String
    Public Name As String
    Public Description As String
    Public Parameters As New List(Of Parameter)
    Private rpt As ReportDocument

#Region "Propriétés"
    Public ReadOnly Property IsLoaded() As Boolean
        Get
            Return rpt IsNot Nothing
        End Get
    End Property
#End Region

#Region "Constructeurs"
    Public Sub New()

    End Sub

    Public Sub New(ByVal filename As String)
        Me.New()
        Me.FileName = filename
    End Sub
#End Region

    Public Sub LoadReport()
        If Not IO.File.Exists(FileName) Then Throw New ApplicationException("La propriété Filename doit être renseignée")
        Try
            rpt = New ReportDocument
            With rpt
                .Load(FileName)
                Me.Name = .SummaryInfo.ReportTitle
                If Me.Name = "" Then
                    Me.Name = IO.Path.GetFileNameWithoutExtension(FileName)
                End If
                Me.Description = .SummaryInfo.ReportSubject
                Me.Parameters.Clear()
                For Each p As ParameterField In .ParameterFields
                    If Not p.Name.StartsWith("Pm-") Then
                        Me.Parameters.Add(New Parameter(p))
                    End If
                Next
            End With
        Catch ex As Exception
            Me.Name = "Erreur"
            Me.Description = ex.Message
            rpt = Nothing
        End Try
    End Sub

    Public Sub PrepareReport()
        FillData()
        SetParams()
    End Sub

    Public Sub FillData()
        If rpt Is Nothing Then Throw New ApplicationException("Rapport non chargé")

        Dim ds As New DataSet
        Using s As New SqlProxy
            For Each t As Table In rpt.Database.Tables
                DefinitionDonnees.Instance.Fill(ds, t.Location, s)
            Next
        End Using
        rpt.SetDataSource(ds)
    End Sub

    Public Sub SetParams()
        If rpt Is Nothing Then Throw New ApplicationException("Rapport non chargé")

        For Each p As Parameter In Me.Parameters
            Dim v As Object
            If Not IsDBNull(p.Value) OrElse p.EnableNullValue Then
                v = p.Value
            Else
                v = p.DefaultValue
            End If
            If p.ReportName = "" Then
                rpt.SetParameterValue(p.Name, v)
            Else
                rpt.SetParameterValue(p.Name, v, p.ReportName)
            End If
            Debug.Print("{2}.{0} = {1}", p.Name, p.Value, p.ReportName)
        Next
    End Sub

    Public Sub ShowReport(ByVal ownerForm As Form)
        PrepareReport()
        Call New EcranCrystal(rpt).Show(ownerForm)
    End Sub

End Class

Public Class Parameter
    Public Name As String
    Public Description As String
    Public Type As Type
    Public Format As String
    Public EnableNullValue As Boolean
    Public DefaultValue As Object
    Public ReportName As String

    Private _value As Object = DBNull.Value
    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal value As Object)
            _value = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal p As ParameterField)
        Me.New()
        With Me
            .Name = p.Name
            .Description = p.PromptText
            If .Description = "" Then .Description = .Name
            .ReportName = p.ReportName
            .EnableNullValue = p.EnableNullValue
            If .EnableNullValue Then
                .DefaultValue = DBNull.Value
            Else
                If p.DefaultValues.Count = 0 Then
                    Select Case p.ParameterValueType
                        Case ParameterValueKind.BooleanParameter
                            .DefaultValue = False
                        Case ParameterValueKind.CurrencyParameter, ParameterValueKind.NumberParameter
                            .DefaultValue = 0D
                        Case ParameterValueKind.DateParameter, ParameterValueKind.DateTimeParameter, ParameterValueKind.TimeParameter
                            .DefaultValue = Date.MinValue
                        Case ParameterValueKind.StringParameter
                            .DefaultValue = ""
                    End Select
                Else
                    .DefaultValue = CType(p.DefaultValues(0), ParameterDiscreteValue).Value
                End If
            End If
            .Value = .DefaultValue
            Select Case p.ParameterValueType
                Case ParameterValueKind.BooleanParameter
                    .Type = GetType(Boolean)
                Case ParameterValueKind.CurrencyParameter
                    .Type = GetType(Decimal)
                    .Format = "C2"
                Case ParameterValueKind.DateParameter
                    .Type = GetType(Date)
                    .Format = "d"
                Case ParameterValueKind.TimeParameter
                    .Type = GetType(Date)
                    .Format = "T"
                Case ParameterValueKind.DateTimeParameter
                    .Type = GetType(Date)
                    .Format = "G"
                Case ParameterValueKind.NumberParameter
                    .Type = GetType(Decimal)
                    .Format = "N2"
                Case ParameterValueKind.StringParameter
                    .Type = GetType(String)
                    .Format = ""
            End Select
        End With
    End Sub
End Class

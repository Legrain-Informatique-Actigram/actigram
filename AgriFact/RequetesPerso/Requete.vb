Public Class Requete

#Region "Props"
    Private _sql As String = ""
    Public Property CommandText() As String
        Get
            Return _sql
        End Get
        Set(ByVal value As String)
            _sql = value
        End Set
    End Property

    Private _parametres As New List(Of Parametre)
    Public Property Parametres() As List(Of Parametre)
        Get
            Return _parametres
        End Get
        Set(ByVal value As List(Of Parametre))
            _parametres = value
        End Set
    End Property

    Private _titre As String = ""
    Public Property Titre() As String
        Get
            Return _titre
        End Get
        Set(ByVal value As String)
            _titre = value
        End Set
    End Property

    Private _cols As New List(Of Colonne)
    Public Property Colonnes() As List(Of Colonne)
        Get
            Return _cols
        End Get
        Set(ByVal value As List(Of Colonne))
            _cols = value
        End Set
    End Property
#End Region

#Region "XML"
    Public Shared Function Load(ByVal filename As String) As Requete
        Return XmlUtils.DeSerializeFromFile(Of Requete)(filename)
    End Function

    Public Shared Function LoadXml(ByVal xml As String) As Requete
        Return XmlUtils.DeSerializeFromString(Of Requete)(xml)
    End Function

    Public Sub Save(ByVal filename As String)
        XmlUtils.SerializeToFile(Of Requete)(Me, filename)
    End Sub

    Public Function GetXml() As String
        Return XmlUtils.SerializeToString(Of Requete)(Me)
    End Function
#End Region

    Public Function ExecuteDatatable(ByVal conn As SqlClient.SqlConnection, ByVal paramValues As Dictionary(Of String, Object)) As DataTable
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
        Using cmd As New SqlClient.SqlCommand(Me.CommandText, conn)
            For Each p As Parametre In Me.Parametres
                p.AddParameter(cmd, paramValues)
            Next
            Dim res As New DataTable
            Using dta As New SqlClient.SqlDataAdapter(cmd)
                dta.Fill(res)
            End Using
            Return res
        End Using
        Return Nothing
    End Function
End Class

Public Class Parametre

#Region "Props"
    Private _nom As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property Nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property

    Private _type As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Private _lib As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property Libelle() As String
        Get
            Return _lib
        End Get
        Set(ByVal value As String)
            _lib = value
        End Set
    End Property


    Private _valDef As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property ValeurDefaut() As String
        Get
            Return _valDef
        End Get
        Set(ByVal value As String)
            _valDef = value
        End Set
    End Property

    Private _width As Integer = -1
    <Xml.Serialization.XmlAttribute()> _
    Public Property Width() As Integer
        Get
            Return _width
        End Get
        Set(ByVal value As Integer)
            _width = value
        End Set
    End Property

    Private _datasource As ComboDatasource
    Public Property Datasource() As ComboDatasource
        Get
            Return _datasource
        End Get
        Set(ByVal value As ComboDatasource)
            _datasource = value
        End Set
    End Property
#End Region

    Public Sub AddParameter(ByVal cmd As SqlClient.SqlCommand, ByVal paramValues As Dictionary(Of String, Object))
        Dim sp As SqlClient.SqlParameter = cmd.CreateParameter()
        With sp
            .ParameterName = Nom
            .DbType = GetDbType()
            .Direction = ParameterDirection.Input
            If paramValues.ContainsKey(Nom) Then
                .Value = paramValues(Nom)
            Else
                .Value = ValeurDefaut
            End If
        End With
        cmd.Parameters.Add(sp)
    End Sub

    Private Function GetDbType() As DbType
        Select Case Me.Type
            Case "String" : Return DbType.String
            Case "DateTime" : Return DbType.DateTime
            Case "Boolean" : Return DbType.Boolean
            Case "Integer" : Return DbType.Int32
            Case "Long" : Return DbType.Int64
            Case "Decimal" : Return DbType.Decimal
            Case Else : Return DbType.String
        End Select
    End Function
End Class

<Xml.Serialization.XmlInclude(GetType(SqlComboDatasource)), _
Xml.Serialization.XmlInclude(GetType(SimpleComboDatasource))> _
Public Class ComboDatasource

End Class

Public Class SqlComboDatasource
    Inherits ComboDatasource

    Private sql As String
    Public Property SelectQuery() As String
        Get
            Return sql
        End Get
        Set(ByVal value As String)
            sql = value
        End Set
    End Property


    Private _display As String
    Public Property DisplayMember() As String
        Get
            Return _display
        End Get
        Set(ByVal value As String)
            _display = value
        End Set
    End Property


    Private _value As String
    Public Property ValueMember() As String
        Get
            Return _value
        End Get
        Set(ByVal value As String)
            _value = value
        End Set
    End Property

End Class

Public Class SimpleComboDatasource
    Inherits ComboDatasource

    Private _values As New List(Of String)
    Public Property Values() As List(Of String)
        Get
            Return _values
        End Get
        Set(ByVal value As List(Of String))
            _values = value
        End Set
    End Property
End Class

Public Class Colonne

#Region "Props"
    Private _field As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property Field() As String
        Get
            Return _field
        End Get
        Set(ByVal value As String)
            _field = value
        End Set
    End Property


    Private _entete As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property Entete() As String
        Get
            Return _entete
        End Get
        Set(ByVal value As String)
            _entete = value
        End Set
    End Property


    Private _format As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property Format() As String
        Get
            Return _format
        End Get
        Set(ByVal value As String)
            _format = value
        End Set
    End Property

    Private _align As String = ""
    <Xml.Serialization.XmlAttribute()> _
    Public Property Align() As String
        Get
            Return _align
        End Get
        Set(ByVal value As String)
            _align = value
        End Set
    End Property
#End Region

End Class
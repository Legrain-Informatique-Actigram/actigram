Public Class Dossier

    Private _nom As String
    Public Property Nom() As String
        Get
            Return _nom
        End Get
        Set(ByVal value As String)
            _nom = value
        End Set
    End Property


    Private _connstring As String
    Public Property ConnString() As String
        Get
            Return _connstring
        End Get
        Set(ByVal value As String)
            _connstring = value
        End Set
    End Property


    Public Shared Function ChargerDossiersAgrifact() As List(Of Dossier)
        Dim res As New List(Of Dossier)
        Dim dt As DataTable = ChargerParametresAgrifact()
        If dt IsNot Nothing Then
            For Each dr As DataRow In dt.Rows
                Dim dos As New Dossier()
                dos.Nom = Convert.ToString(dr("NomDossier"))
                dos.ConnString = SqlProxy.GetConnectionString(Convert.ToString(dr("ServeurSQL")), Convert.ToString(dr("BaseSQL")), "sa", Convert.ToString(dr("saPwd")))
                res.Add(dos)
            Next
        End If
        Return res
    End Function

    Private Shared Function ChargerParametresAgrifact() As DataTable
        Try
            Const FichierParametres As String = "Parametres.xml"
            Dim cheminPar As String = IO.Path.Combine(My.Application.Info.DirectoryPath, FichierParametres)
            If Not IO.File.Exists(cheminPar) Then
                cheminPar = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.ProgramFiles, "Actigram\Agrifact")
                cheminPar = IO.Path.Combine(cheminPar, FichierParametres)
                If Not IO.File.Exists(cheminPar) Then
                    Return Nothing
                End If
            End If
            Dim ds As New DataSet
            ds.ReadXml(cheminPar)
            If ds.Tables.Count > 0 Then
                Return ds.Tables(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class

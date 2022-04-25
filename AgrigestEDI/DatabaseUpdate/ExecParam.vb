Public Class ExecParam

    Public CheminBase As String

#Region "Constructeurs"
    Public Sub New()

    End Sub

    Public Sub New(ByVal cheminBase As String)
        Me.New()
        Me.CheminBase = cheminBase
    End Sub
#End Region

#Region "Méthodes partagées"
    Public Shared Function ReadParam(ByVal NomDossier As String) As ExecParam
        Dim ex As Exploitation = Exploitation.Trouver(NomDossier)
        If ex Is Nothing Then Throw New ApplicationException(String.Format("Aucun dossier nommé '{0}' n'a été trouvé.", NomDossier))
        Return New ExecParam(ex.CheminBase)
    End Function

    Public Shared Function ReadParam(ByVal index As Integer) As ExecParam
        Dim list As List(Of Exploitation) = Exploitation.ChargerExploitations
        If list Is Nothing Then Throw New Exception("Fichier de configuration des exploitations introuvable")
        If index < list.Count Then
            Return New ExecParam(list(index).CheminBase)
        Else
            Throw New IndexOutOfRangeException(String.Format("Le fichier paramètre ne contient que {0} dossiers", list.Count))
        End If
    End Function

    Public Shared Function ReadAllParams() As List(Of ExecParam)
        Dim list As List(Of Exploitation) = Exploitation.ChargerExploitations
        If list Is Nothing Then Throw New ApplicationException("Fichier de configuration des exploitations introuvable")
        Dim res As New List(Of ExecParam)
        For Each ex As Exploitation In list
            res.Add(New ExecParam(ex.CheminBase))
        Next
        Return res
    End Function

    'Public Shared Function DefaultParam() As ExecParam
    '    Dim chemin As String = Application.StartupPath & "\dbDonnees.mdb"
    '    If Not IO.File.Exists(chemin) Then chemin = "C:\AGRIGEST²\dbDonnees.mdb"
    '    If Not IO.File.Exists(chemin) Then chemin = "" 'Throw New ApplicationException("Base de données introuvable")
    '    Return New ExecParam(chemin)
    'End Function
#End Region
End Class
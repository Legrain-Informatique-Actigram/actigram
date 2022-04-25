Namespace Securite.Activation
    Public Class Cle

        <Flags()> Public Enum OptionsModules As Short
            IdentWindowsLogin = &H1
            AmortEmprunts = &H2
            Inventaires = &H4
            Lettrage = &H8
            SuiviAna = &H10
            ImportExport = &H20
            SaisieSimple = &H40
            Isagri = &H80
            Reseau = &H100
            Option10On = &H200
            Option11On = &H400
            Option12On = &H800
            Option13On = &H1000
            Option14On = &H2000
            Option15On = &H4000
        End Enum

        Public CodeUtilisateurHash As Integer
        Public DateValidite As Date
        Private Options As OptionsModules

        Public WriteOnly Property CodeUtilisateur() As String
            Set(ByVal Value As String)
                Me.CodeUtilisateurHash = GetStringHashCode(Value)
            End Set
        End Property

        Public Function HasOption(ByVal testOption As OptionsModules) As Boolean
            Return (Options And testOption) = testOption
        End Function

        Public Sub SetOption(ByVal opt As OptionsModules, ByVal enabled As Boolean)
            If enabled Then
                Me.Options = Me.Options Or opt
            Else
                Me.Options = Me.Options And Not opt
            End If
        End Sub

        Public Function IsCodeValid(ByVal codeUtilisateur As String) As Boolean
            Return CodeUtilisateurHash = GetStringHashCode(codeUtilisateur)
        End Function

        Public Function IsCodeValid() As Boolean
            If Me.HasOption(OptionsModules.IdentWindowsLogin) Then
                Return IsCodeValid(GetStringHashCode(Environment.UserName.ToUpper).ToString)
            Else
                Return IsCodeValid(GetStringHashCode(GetNSerie()).ToString)
            End If
        End Function

        Public Function IsValid(Optional ByVal codeUtilisateur As String = "") As Boolean
            Dim testCodeUtil As Boolean
            If codeUtilisateur = "" Then
                testCodeUtil = IsCodeValid()
            Else
                testCodeUtil = IsCodeValid(codeUtilisateur)
            End If
            Return testCodeUtil AndAlso Me.DateValidite.Date >= Now.Date
        End Function

        Public Function ToLong() As Long
            Return CombineInt32(CodeUtilisateurHash, CombineInt16(Options, CShort(DateToInt(Me.DateValidite))) Xor CodeUtilisateurHash)
        End Function

        Public Overrides Function ToString() As String
            Return Me.ToLong.ToString("X16")
        End Function
        
        Public Shared Function Parse(ByVal l As Long) As Cle
            Dim cle As New Cle
            With cle
                .CodeUtilisateurHash = UpperInt32(l)
                Dim i As Integer = LowerInt32(l) Xor .CodeUtilisateurHash
                .DateValidite = IntToDate(CUShort(LowerInt16(i)))
                .Options = CType(UpperInt16(i), OptionsModules)
            End With
            Return cle
        End Function

		Public Shared Function GetStringHashCode(ByVal s As String) As Integer
            Return Md5Encryption.GetHash(s)
        End Function

        Public Shared Function Parse(ByVal s As String) As Cle
            s = s.Trim
            Dim re As New System.Text.RegularExpressions.Regex("\A[0-9a-fA-F]{16}\z")
            Dim m As System.Text.RegularExpressions.Match = re.Match(s)
            If Not m.Success Then
                Throw New ArgumentException("format de clé incorrect")
            Else
                Return Parse(Long.Parse(s, Globalization.NumberStyles.HexNumber))
            End If
        End Function
    End Class
End Namespace
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Namespace Securite
    Friend Class XorEncryption
        'Cette clé représente un Long au format X16 encrypté via RSA
        Private Const ENKEY As String = "ABF694774D2DA056B286272C4CCA46040BC4460E441DC638169C4931A243CBFDC9EB83F70BB6155944778" & _
                                        "2DBCCEB20E07B587F2706B97165E24C3EFD0AD5D0B54CD75A0ED15E9880E3B8F7535B2F4CEDC0624BD8BC" & _
                                        "29A552D46E518E0096245EC4763304D44DA3DE539F444369362CF330E2DF2B3FAFFE7DC93DD1F506CC3543"

        Friend Shared Function EnCrypt(ByVal l As Long) As Long
            Return EnCrypt(l, GetDecryptedKey)
        End Function

        Friend Shared Function EnCrypt(ByVal l As Long, ByVal key As Long) As Long
            Return l Xor key
        End Function

        Private Shared Function GetDecryptedKey() As Long
            Return Long.Parse(RsaEncryption.RsaDecrypt(ENKEY), Globalization.NumberStyles.HexNumber)
        End Function
    End Class

#Region " DES "
    Friend Class DesEncryption
        Private Const KEY As String = "BJ1Sh75TT4k="
        Private Const IV As String = "MLFNxSUZoQw="

        ' NB that the keys sit in the code, so this is NOT bullet-proof!!!
        Public Shared Function DesEncrypt(ByVal pToEncrypt As String) As String
            Return DesEncrypt(pToEncrypt, KEY, IV)
        End Function

        Public Shared Function DesDecrypt(ByVal pToDecrypt As String) As String
            Return DesDecrypt(pToDecrypt, KEY, IV)
        End Function

        Public Shared Function DesEncrypt(ByVal pToEncrypt As String, ByVal sKey As String, ByVal sIv As String) As String
            Dim des As New DESCryptoServiceProvider

            'Put the string into a byte array
            Dim inputByteArray As Byte() = Encoding.UTF8.GetBytes(pToEncrypt)

            'Create the crypto objects, with the key, as passed in
            des.Key = Convert.FromBase64String(sKey)
            des.IV = Convert.FromBase64String(sIv)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write)
            'Write the byte array into the crypto stream
            '(It will end up in the memory stream)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()

            'Get the data back from the memory stream, and into a string
            Dim ret As New StringBuilder
            For Each b As Byte In ms.ToArray()
                'Format as hex
                ret.AppendFormat("{0:X2}", b)
            Next
            Return ret.ToString()
        End Function

        Public Shared Function DesDecrypt(ByVal pToDecrypt As String, ByVal sKey As String, ByVal sIv As String) As String
            Dim des As New DESCryptoServiceProvider

            'Put the input string into the byte array
            Dim inputByteArray As Byte() = New Byte(pToDecrypt.Length \ 2 - 1) {}
            For x As Integer = 0 To pToDecrypt.Length \ 2 - 1
                Dim i As Integer = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16))
                inputByteArray(x) = CByte(i)
            Next

            'Create the crypto objects
            des.Key = Convert.FromBase64String(sKey)
            des.IV = Convert.FromBase64String(sIv)
            Dim ms As New MemoryStream
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write)
            'Flush the data through the crypto stream into the memory stream
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()

            'Get the decrypted data back from the memory stream
            Dim ret As New StringBuilder
            For Each b As Byte In ms.ToArray()
                ret.Append(Chr(b))
            Next
            Return ret.ToString()
        End Function
    End Class
#End Region

#Region " MD5 "
    Friend Class Md5Encryption
        Public Shared Function GetHash(ByVal s As String) As Integer
            Dim md5 As New MD5CryptoServiceProvider
            Dim data As Byte() = md5.ComputeHash(Encoding.Default.GetBytes(s))
            Dim res As Integer = 0
            For i As Integer = 0 To 5
                res = res * &H10 + data(i)
            Next
            Return res
        End Function
    End Class
#End Region

#Region " RSA "
    Friend Class RsaEncryption
        Public Shared Sub GenerateKeyFiles(ByVal pubFile As String, ByVal privateFile As String)
            Dim key As RSA = RSA.Create()
            WriteTextToFile(pubFile, key.ToXmlString(False), False)
            WriteTextToFile(privateFile, key.ToXmlString(True), False)
        End Sub

        Public Shared Function LoadRSAFromResource(ByVal resName As String) As RSACryptoServiceProvider
            Dim key As New RSACryptoServiceProvider
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
            Dim sr As New IO.StreamReader(asm.GetManifestResourceStream(GetType(Main).Namespace & "." & resName))
            key.FromXmlString(sr.ReadToEnd)
            sr.Close()
            Return key
        End Function

        Public Shared Function LoadRSAFromFile(ByVal filename As String) As RSACryptoServiceProvider
            Dim key As New RSACryptoServiceProvider
            key.FromXmlString(ReadAllText(filename))
            Return key
        End Function

        Public Shared Function RsaEncrypt(ByVal pToEncrypt As String) As String
            Dim rsa As RSACryptoServiceProvider = LoadRSAFromResource("KeysTraca.pub")
            Return RsaEncrypt(rsa, pToEncrypt)
        End Function

        Public Shared Function RsaDecrypt(ByVal pToDecrypt As String) As String
            Dim rsa As RSACryptoServiceProvider = LoadRSAFromResource("KeysTraca.priv")
            Return RsaDecrypt(rsa, pToDecrypt)
        End Function

        Public Shared Function RsaEncrypt(ByVal rsa As RSACryptoServiceProvider, ByVal pToEncrypt As String) As String
            Dim inputByteArray As Byte() = Encoding.UTF8.GetBytes(pToEncrypt)
            Dim encrypted() As Byte = rsa.Encrypt(inputByteArray, False)
            Return Hex(encrypted)
        End Function

        Public Shared Function RsaDecrypt(ByVal rsa As RSACryptoServiceProvider, ByVal pToDecrypt As String) As String
            Dim inputByteArray As Byte() = FromHex(pToDecrypt)
            Dim decrypted() As Byte = rsa.Decrypt(inputByteArray, False)
            Return Encoding.UTF8.GetString(decrypted)
        End Function
    End Class
#End Region
End Namespace
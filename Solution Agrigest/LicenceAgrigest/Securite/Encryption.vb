Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Namespace Securite
    Friend Class XorEncryption
        'Cette clé représente un Long au format X16 encrypté via RSA
        Private Const ENKEY As String = "1C43D0B99841B47BB6DFF25AB8DDBF59A8CF2E649B11F205BE371750D799A9B1" & _
                                        "893F23C3605F2040D1A4BF2950A49C91F45F1B4720764268171B7A1243F32C15" & _
                                        "B9A87F4014C7A403E56D7C96BCB52525A55E1C997CA6108D04FBD2AB52244BFC" & _
                                        "2E1FE33B565CB47CB0959BCA5DC385B032D595274CA8D9842BE2D62917DF5431"

        Friend Shared Function EnCrypt(ByVal l As Long) As Long
            Return EnCrypt(l, GetDecryptedKey)
        End Function

        Friend Shared Function EnCrypt(ByVal l As Long, ByVal key As Long) As Long
            Return l Xor key
        End Function

        Private Shared Function GetDecryptedKey() As Long
            Return Long.Parse(RsaEncryption.RsaDecrypt(ENKEY), Globalization.NumberStyles.HexNumber)
        End Function

        Friend Shared Function EnCryptToX(ByVal s As String) As String
            Dim inputByteArray As Byte() = Encoding.UTF8.GetBytes(s)
            Dim res As New System.Text.StringBuilder
            Dim pos As Integer = 0
            Dim key As Long = GetDecryptedKey()
            Do
                Dim l As Integer = Math.Min(8, inputByteArray.Length - pos)
                Dim lo As Long
                Select Case l
                    Case 8 : lo = BitConverter.ToInt64(inputByteArray, pos)
                    Case 4 : lo = BitConverter.ToInt32(inputByteArray, pos)
                    Case 2 : lo = BitConverter.ToInt16(inputByteArray, pos)
                End Select
                Dim encLo As Long = EnCrypt(lo, key)
                Dim bytes() As Byte = BitConverter.GetBytes(encLo)
                res.Append(Hex(bytes))
                pos += l
            Loop Until pos >= inputByteArray.Length
            Return res.ToString
        End Function

        Friend Shared Function EnCryptFromX(ByVal s As String) As String
            Dim inputByteArray As Byte() = FromHex(s)
            Dim res As New System.Text.StringBuilder
            Dim pos As Integer = 0
            Dim key As Long = GetDecryptedKey()
            Do
                Dim l As Integer = Math.Min(8, inputByteArray.Length - pos)
                Dim lo As Long
                Select Case l
                    Case 8 : lo = BitConverter.ToInt64(inputByteArray, pos)
                    Case 4 : lo = BitConverter.ToUInt32(inputByteArray, pos)
                    Case 2 : lo = BitConverter.ToUInt16(inputByteArray, pos)
                End Select
                Dim encLo As Long = EnCrypt(lo, key)
                Dim bytes() As Byte = BitConverter.GetBytes(encLo)
                res.Append(Encoding.UTF8.GetString(bytes))
                pos += l
            Loop Until pos >= inputByteArray.Length
            Return res.ToString.Replace(Chr(0), "")
        End Function

        Friend Shared Function EnCryptToX2(ByVal s As String) As String
            Dim inputByteArray As Byte() = Encoding.UTF8.GetBytes(s)
            Dim res As New System.Text.StringBuilder
            Dim pos As Integer = 0
            Dim key As Long = GetDecryptedKey()
            Do
                Dim l As Integer = inputByteArray.Length - pos
                Dim lo As Long
                Select Case l
                    Case 1 Or 2 Or 3 : lo = BitConverter.ToInt16(inputByteArray, pos)
                    Case 4 Or 5 Or 6 Or 7 : lo = BitConverter.ToInt32(inputByteArray, pos)
                    Case Else : lo = BitConverter.ToInt64(inputByteArray, pos)
                End Select
                Dim encLo As Long = EnCrypt(lo, key)
                Dim bytes() As Byte = BitConverter.GetBytes(encLo)
                res.Append(Hex(bytes))
                pos += l
            Loop Until pos >= inputByteArray.Length
            Return res.ToString
        End Function

        Friend Shared Function EnCryptFromX2(ByVal s As String) As String
            Dim inputByteArray As Byte() = FromHex(s)
            Dim res As New System.Text.StringBuilder
            Dim pos As Integer = 0
            Dim key As Long = GetDecryptedKey()
            Do
                Dim l As Integer = inputByteArray.Length - pos
                Dim lo As Long
                Select Case l
                    Case 1 Or 2 Or 3 : lo = BitConverter.ToInt16(inputByteArray, pos)
                    Case 4 Or 5 Or 6 Or 7 : lo = BitConverter.ToInt32(inputByteArray, pos)
                    Case Else : lo = BitConverter.ToInt64(inputByteArray, pos)
                End Select
                Dim encLo As Long = EnCrypt(lo, key)
                Dim bytes() As Byte = BitConverter.GetBytes(encLo)
                res.Append(Encoding.UTF8.GetString(bytes))
                pos += l
            Loop Until pos >= inputByteArray.Length
            Return res.ToString.Replace(Chr(0), "")
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

        Public Shared Function RsaEncrypt(ByVal pToEncrypt As String, ByVal publicKeysFile As String) As String
            Dim rsa As RSACryptoServiceProvider = LoadRSAFromFile(publicKeysFile)
            Return RsaEncrypt(rsa, pToEncrypt)
        End Function

        Public Shared Function RsaEncrypt(ByVal pToEncrypt As String) As String
            Dim rsa As RSACryptoServiceProvider = LoadRSAFromResource("Keys.pub")
            Return RsaEncrypt(rsa, pToEncrypt)
        End Function

        Public Shared Function RsaDecrypt(ByVal pToDecrypt As String) As String
            Dim rsa As RSACryptoServiceProvider = LoadRSAFromResource("Keys.priv")
            Return RsaDecrypt(rsa, pToDecrypt)
        End Function

        'Public Shared Function RsaEncrypt(ByVal rsa As RSACryptoServiceProvider, ByVal pToEncrypt As String) As String
        '    Dim inputByteArray As Byte() = Encoding.UTF8.GetBytes(pToEncrypt)
        '    Dim res As String
        '    Dim pos As Integer = 0
        '    Do
        '        Dim l As Integer = Math.Min(256, inputByteArray.Length - pos)
        '        Dim t(l - 1) As Byte
        '        Array.ConstrainedCopy(inputByteArray, pos, t, 0, l)
        '        Dim encrypted() As Byte = rsa.Encrypt(t, False)
        '        res &= Hex(encrypted)
        '        pos += l
        '    Loop Until pos >= inputByteArray.Length
        '    Return res
        'End Function

        'Public Shared Function RsaDecrypt(ByVal rsa As RSACryptoServiceProvider, ByVal pToDecrypt As String) As String
        '    Dim inputByteArray As Byte() = FromHex(pToDecrypt)
        '    Dim res As String
        '    Dim pos As Integer = 0
        '    Do
        '        Dim l As Integer = Math.Min(256, inputByteArray.Length - pos)
        '        Dim t(l - 1) As Byte
        '        Array.ConstrainedCopy(inputByteArray, pos, t, 0, l)
        '        Dim decrypted() As Byte = rsa.Decrypt(t, False)
        '        res &= Encoding.UTF8.GetString(decrypted)
        '        pos += l
        '    Loop Until pos >= inputByteArray.Length
        '    Return res
        'End Function

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
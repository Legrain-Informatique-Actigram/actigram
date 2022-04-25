Namespace Securite
    Module Utils
        Friend Function CharIsHexDigit(ByVal c As Char) As Boolean
            Dim chars() As Char = {"A"c, "B"c, "C"c, "D"c, "E"c, "F"c}
            Return Char.IsDigit(c) OrElse Array.IndexOf(chars, Char.ToUpper(c)) >= 0
        End Function

        Friend Function GetNSerie() As String
            Dim hds As New System.Management.ManagementObject("win32_logicaldisk='c:'")
            hds.Get()
            Dim sn As String = Convert.ToString(hds.Properties("volumeserialnumber").Value)
            Return sn
        End Function

        Friend Function DateToInt(ByVal d As Date, Optional ByVal [step] As UShort = 2) As UShort
            Return CUShort(Math.Min(d.Subtract(#1/1/2000#).Days \ [step], UShort.MaxValue))
        End Function

        Friend Function IntToDate(ByVal i As UShort, Optional ByVal [step] As UShort = 2) As Date
            Return #1/1/2000#.AddDays(i * [step])
        End Function

        Friend Function ReadAllText(ByVal fileName As String) As String
            Dim sr As New IO.StreamReader(fileName, True)
            Try
                Return sr.ReadToEnd
            Finally
                sr.Close()
            End Try
        End Function

        Friend Sub WriteTextToFile(ByVal fileName As String, ByVal text As String, ByVal append As Boolean)
            Dim sw As New IO.StreamWriter(fileName, append)
            Try
                sw.Write(text)
            Finally
                sw.Close()
            End Try
        End Sub

        Friend Function Hex(ByVal byteArray() As Byte) As String
            Dim ret As New System.Text.StringBuilder
            For Each b As Byte In byteArray
                'Format as hex
                ret.AppendFormat("{0:X2}", b)
            Next
            Return ret.ToString()
        End Function

        Friend Function FromHex(ByVal s As String) As Byte()
            'Put the input string into the byte array
            Dim inputByteArray As Byte() = New Byte(s.Length \ 2 - 1) {}
            For x As Integer = 0 To s.Length \ 2 - 1
                Dim i As Integer = (Convert.ToInt32(s.Substring(x * 2, 2), 16))
                inputByteArray(x) = CByte(i)
            Next
            Return inputByteArray
        End Function

#Region " Binary "
        Friend Function ShiftLeft16(ByVal val As Int16) As Int32
            Return CInt(val) * CInt(2 ^ 16)
        End Function

        Friend Function ShiftLeft32(ByVal val As Int32) As Int64
            Return CLng(val) * CLng(2 ^ 32)
        End Function

        Friend Function UpperInt16(ByVal val As Int32) As Int16
            Return CShort(val \ CInt(2 ^ 16))
        End Function

        Friend Function UpperInt32(ByVal val As Int64) As Int32
            Return CInt(val \ CLng(2 ^ 32))
        End Function

        Friend Function LowerInt16(ByVal val As Int32) As Int16
            Return CShort(val Mod 2 ^ 16)
        End Function

        Friend Function LowerInt32(ByVal val As Int64) As Int32
            Return CInt(val - ShiftLeft32(UpperInt32(val)))
        End Function

        Friend Function CombineInt16(ByVal upper As Int16, ByVal lower As Int16) As Int32
            Return ShiftLeft16(upper) + lower
        End Function

        Friend Function CombineInt32(ByVal upper As Int32, ByVal lower As Int32) As Int64
            'Debug.WriteLine(lower.ToString("X16"))
            'Debug.WriteLine(upper.ToString("X16"))
            'Debug.WriteLine(ShiftLeft32(upper).ToString("X16"))
            'Debug.WriteLine((ShiftLeft32(upper) + lower).ToString("X16"))
            Return ShiftLeft32(upper) + lower
        End Function

        Friend Function CombineInt32(ByVal upper As Int32, ByVal lower1 As Int16, ByVal lower2 As Int16) As Int64
            Return ShiftLeft32(upper) + CombineInt16(lower1, lower2)
        End Function
#End Region
    End Module
End Namespace
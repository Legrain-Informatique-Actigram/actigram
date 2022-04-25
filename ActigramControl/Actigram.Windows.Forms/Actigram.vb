Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Namespace Securite
    Friend Enum ModulePosition
        ModuleStock
        ModuleEvenement
        ModuleAchat
        ModuleVente
        ModuleReglement
        ModuleBalance
        OLD_ModuleLot
        ModuleTableauBord
        ModuleGestionWeb
        ModuleGestionRelance
        ModuleGestionMarge
        ModuleCompta
        ModuleTarif
        ModuleContact
        VersionDemo
        ModuleApproFact
    End Enum


    Public Class Modules

        Public ModuleStock As Boolean = False
        Public ModuleEvenement As Boolean = False
        Public ModuleAchat As Boolean = False
        Public ModuleVente As Boolean = False
        Public ModuleReglement As Boolean = False
        Public ModuleBalance As Boolean = False
        'Public ModuleLot As Boolean = False
        Public ModuleTableauBord As Boolean = False
        Public ModuleGestionWeb As Boolean = False
        Public ModuleGestionRelance As Boolean = False
        Public ModuleGestionMarge As Boolean = False
        Public ModuleCompta As Boolean = False
        Public ModuleTarif As Boolean = False
        Public ModuleContact As Boolean = True
        Public VersionDemo As Boolean = False
        Public ModuleApproFact As Boolean = False

        Public Const NB_MODULES As Integer = 20

        Public Function GetStringFromModule() As String
            Dim str(NB_MODULES - 1) As String
            Dim i As Integer
            For i = 0 To str.Length - 1
                str(i) = "0"
            Next
            str(ModulePosition.ModuleAchat) = Convert.ToInt32(Me.ModuleAchat).ToString
            str(ModulePosition.ModuleBalance) = Convert.ToInt32(Me.ModuleBalance).ToString
            str(ModulePosition.ModuleEvenement) = Convert.ToInt32(Me.ModuleEvenement).ToString
            'str(ModulePosition.ModuleLot) = Convert.ToInt32(Me.ModuleLot).ToString
            str(ModulePosition.ModuleReglement) = Convert.ToInt32(Me.ModuleReglement).ToString
            str(ModulePosition.ModuleStock) = Convert.ToInt32(Me.ModuleStock).ToString
            str(ModulePosition.ModuleTableauBord) = Convert.ToInt32(Me.ModuleTableauBord).ToString
            str(ModulePosition.ModuleVente) = Convert.ToInt32(Me.ModuleVente).ToString
            str(ModulePosition.ModuleGestionWeb) = Convert.ToInt32(Me.ModuleGestionWeb).ToString
            str(ModulePosition.ModuleGestionRelance) = Convert.ToInt32(Me.ModuleGestionRelance).ToString
            str(ModulePosition.ModuleGestionMarge) = Convert.ToInt32(Me.ModuleGestionMarge).ToString
            str(ModulePosition.ModuleCompta) = Convert.ToInt32(Me.ModuleCompta).ToString
            str(ModulePosition.ModuleTarif) = Convert.ToInt32(Me.ModuleTarif).ToString
            str(ModulePosition.ModuleContact) = Convert.ToInt32(Me.ModuleContact).ToString
            str(ModulePosition.VersionDemo) = Convert.ToInt32(Me.VersionDemo).ToString
            str(ModulePosition.ModuleApproFact) = Convert.ToInt32(Me.ModuleApproFact).ToString
            Dim strBin As String = String.Join("", str)
            Return strBin
        End Function

        Public Sub GetModuleFromString(ByVal strBin As String)
            Me.ModuleAchat = ValeurBit(strBin.Chars(ModulePosition.ModuleAchat))
            Me.ModuleBalance = ValeurBit(strBin.Chars(ModulePosition.ModuleBalance))
            Me.ModuleEvenement = ValeurBit(strBin.Chars(ModulePosition.ModuleEvenement))
            'Me.ModuleLot = ValeurBit(strBin.Chars(ModulePosition.ModuleLot))
            Me.ModuleReglement = ValeurBit(strBin.Chars(ModulePosition.ModuleReglement))
            Me.ModuleStock = ValeurBit(strBin.Chars(ModulePosition.ModuleStock))
            Me.ModuleTableauBord = ValeurBit(strBin.Chars(ModulePosition.ModuleTableauBord))
            Me.ModuleVente = ValeurBit(strBin.Chars(ModulePosition.ModuleVente))
            Me.ModuleGestionWeb = ValeurBit(strBin.Chars(ModulePosition.ModuleGestionWeb))
            Me.ModuleGestionRelance = ValeurBit(strBin.Chars(ModulePosition.ModuleGestionRelance))
            Me.ModuleGestionMarge = ValeurBit(strBin.Chars(ModulePosition.ModuleGestionMarge))
            Me.ModuleCompta = ValeurBit(strBin.Chars(ModulePosition.ModuleCompta))
            Me.ModuleTarif = ValeurBit(strBin.Chars(ModulePosition.ModuleTarif))
            Me.ModuleContact = ValeurBit(strBin.Chars(ModulePosition.ModuleContact))
            Me.VersionDemo = ValeurBit(strBin.Chars(ModulePosition.VersionDemo))
            Me.ModuleApproFact = ValeurBit(strBin.Chars(ModulePosition.ModuleApproFact))
        End Sub

        Private Function ValeurBit(ByVal str As String) As Boolean
            Return CBool(IIf(str = "0", False, True))
        End Function

        Public Sub GetModuleFromXML(ByVal path As String)
            Dim dsModules As New DataSet

            If (System.IO.File.Exists(path)) Then
                dsModules.ReadXml(path)

                If (dsModules.Tables.Contains("Modules")) Then
                    For Each ModulesDR As DataRow In dsModules.Tables("Modules").Rows
                        Me.ModuleAchat = ValeurBit(CStr(ModulesDR.Item("ModuleAchat")))
                        Me.ModuleBalance = ValeurBit(CStr(ModulesDR.Item("ModuleBalance")))
                        Me.ModuleEvenement = ValeurBit(CStr(ModulesDR.Item("ModuleEvenement")))
                        Me.ModuleReglement = ValeurBit(CStr(ModulesDR.Item("ModuleReglement")))
                        Me.ModuleStock = ValeurBit(CStr(ModulesDR.Item("ModuleStock")))
                        Me.ModuleTableauBord = ValeurBit(CStr(ModulesDR.Item("ModuleTableauBord")))
                        Me.ModuleVente = ValeurBit(CStr(ModulesDR.Item("ModuleVente")))
                        Me.ModuleGestionWeb = ValeurBit(CStr(ModulesDR.Item("ModuleGestionWeb")))
                        Me.ModuleGestionRelance = ValeurBit(CStr(ModulesDR.Item("ModuleGestionRelance")))
                        Me.ModuleGestionMarge = ValeurBit(CStr(ModulesDR.Item("ModuleGestionMarge")))
                        Me.ModuleCompta = ValeurBit(CStr(ModulesDR.Item("ModuleCompta")))
                        Me.ModuleTarif = ValeurBit(CStr(ModulesDR.Item("ModuleTarif")))
                        Me.ModuleContact = ValeurBit(CStr(ModulesDR.Item("ModuleContact")))
                        Me.VersionDemo = ValeurBit(CStr(ModulesDR.Item("VersionDemo")))
                        Me.ModuleApproFact = ValeurBit(CStr(ModulesDR.Item("ModuleApproFact")))
                    Next
                End If
            End If
        End Sub

    End Class

    Public Class GetLicence
        Public Const FICHIER_CLE As String = "c:\IntLpAg"
        Public Shared ModuleActifs As New Modules

        Shared Function IsValideCle(ByVal strCle As String) As Boolean
            Dim chckSomme As Long
            Dim x As Integer
            Dim HexY As String = ""
            Dim sn As String = GetNSerie()
            Dim y As Double

            For x = 1 To Len(sn)
                chckSomme = chckSomme + Asc(Mid(sn, x, 1))
            Next x

            y = ((chckSomme ^ 2 * 2 + chckSomme ^ 0.5 * 3) / chckSomme ^ 1.5 * 4) * chckSomme ^ 2 * 5

            HexY = Hex(y)

            chckSomme = 0
            For x = 1 To HexY.Length
                chckSomme = chckSomme + Asc(Mid(HexY, x, 1))
            Next
            Dim strCkI1 As String = Convert.ToChar(Hex(chckSomme Mod 16)).ToString

            chckSomme = 0
            For x = 1 To strCle.Length - 1
                chckSomme = chckSomme + Asc(Mid(strCle, x, 1)) * 2
            Next

            Dim strCkI2 As String = Convert.ToChar(Hex(chckSomme Mod 16)).ToString

            If strCle.StartsWith(HexY) Then
                If strCle.Length >= HexY.Length + 1 Then
                    If strCle.Substring(HexY.Length, 1) = strCkI1 Then
                        If strCle.EndsWith(strCkI2) Then
                            Return True
                        End If
                    End If
                End If
            End If

            Return False
        End Function

        Shared Function GetCle() As String
            Dim cle As String = GetCleReg()
            If cle Is Nothing OrElse cle.Length = 0 Then cle = GetCleFichier()
            Return cle
        End Function

        Private Shared Function GetCleReg() As String
            Dim cle As String
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Actigram\AgriFact")
            If Not key Is Nothing Then
                cle = Actigram.Securite.SecuriteConverter.DeCrypteString(Convert.ToString(key.GetValue("IntLpAg")))
                key.Close()
            End If
            Return cle
        End Function

        Shared Sub SetCleReg(ByVal cle As String)
            Dim key As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\Actigram\AgriFact", True)
            If key Is Nothing Then
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\Actigram\AgriFact")
            End If
            key.SetValue("IntLpAg", SecuriteConverter.CrypteString(cle))
            key.Close()
        End Sub

        Private Shared Function GetCleFichier() As String
            Dim cle As String
            If File.Exists(FICHIER_CLE) = True Then
                Dim flR As New StreamReader(FICHIER_CLE)
                cle = Actigram.Securite.SecuriteConverter.DeCrypteString(flR.ReadToEnd)
                flR.Close()
            End If
            Return cle
        End Function

        Shared Sub SetCleFichier(ByVal cle As String)
            If File.Exists(FICHIER_CLE) = True Then
                Dim flW As New IO.StreamWriter(FICHIER_CLE, False)
                flW.Write(SecuriteConverter.CrypteString(cle))
                flW.Close()
            End If
        End Sub

        Shared Function GetNSerie() As String
            Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly
            Dim drive As String = IO.Path.GetPathRoot(asm.Location)
            Dim hds As New System.Management.ManagementObject("win32_logicaldisk='" & drive.Substring(0, 1) & ":'")
            hds.Get()
            Return Convert.ToString(hds.Properties("volumeserialnumber").Value)
        End Function

        Shared Function GetModuleFromCle(ByVal NSerie As String, ByVal strCle As String) As Modules
            Dim X As Integer
            Dim Y As Double
            Dim chckSomme As Long
            Dim HexY As String = ""
            Dim md As Modules

            For X = 1 To Len(NSerie)
                chckSomme = chckSomme + Asc(Mid(NSerie, X, 1))
            Next X

            Y = ((chckSomme ^ 2 * 2 + chckSomme ^ 0.5 * 3) / chckSomme ^ 1.5 * 4) * chckSomme ^ 2 * 5

            HexY = Hex(Y)

            chckSomme = 0
            For X = 1 To HexY.Length
                chckSomme = chckSomme + Asc(Mid(HexY, X, 1))
            Next
            Dim strCkI1 As String = Convert.ToChar(Hex(chckSomme Mod 16)).ToString

            chckSomme = 0
            For X = 1 To strCle.Length - 1
                chckSomme = chckSomme + Asc(Mid(strCle, X, 1)) * 2
            Next

            Dim strCkI2 As String = Convert.ToChar(Hex(chckSomme Mod 16)).ToString

            If strCle.StartsWith(HexY) Then
                If strCle.Length > HexY.Length + 1 Then
                    If strCle.Substring(HexY.Length, 1) = strCkI1 Then
                        If strCle.EndsWith(strCkI2) Then
                            Dim strCle2 As String = strCle.Substring(HexY.Length + 1, strCle.Length - HexY.Length - 1 - 1)
                            Dim strBin As String = Binaire.Binaire.CBin(Binaire.Binaire.CHexDec(strCle2) - Binaire.Binaire.CHexDec(HexY)).PadLeft(Modules.NB_MODULES, "0"c)
                            md = New Modules
                            md.GetModuleFromString(strBin)
                        End If
                    End If
                End If
            End If
            Return md
        End Function

        Shared Function VerifCle() As Boolean
            Try
                ModuleActifs = GetModuleFromCle(GetNSerie(), GetCle())

                Return (Not ModuleActifs Is Nothing)
            Catch
                Return False
            End Try
        End Function
    End Class

    Public Class SecuriteConverter
        Private Shared key As Byte() = {11, 2, 7, 24, 16, 22, 4, 38, 27, 3, 11, 10, 17, 15, 6, 23}
        Private Shared iv As Byte() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16}

        Public Shared Function DeCrypteString(ByVal strValeurDepart As String) As String
            Dim cryptoProvider As New RijndaelManaged
            Dim uEncode As New UnicodeEncoding

            Dim strCipherText As String
            strCipherText = strValeurDepart
            Dim bytCipherText As Byte() = Convert.FromBase64String(strCipherText)

            Dim stmPlainText As New MemoryStream
            Dim stmCipherText1 As New MemoryStream(bytCipherText)
            Dim cryptoReader1 As New CryptoStream(stmCipherText1, cryptoProvider.CreateDecryptor(key, iv), CryptoStreamMode.Read)
            Dim sw As New StreamWriter(stmPlainText)
            Dim sr As New StreamReader(cryptoReader1)

            sw.Write(sr.ReadToEnd)

            sw.Flush()

            Dim strTmp As String
            strTmp = uEncode.GetString(stmPlainText.ToArray())

            cryptoReader1.Clear()
            cryptoProvider.Clear()

            sw.Close()
            sr.Close()

            Return System.Web.HttpUtility.HtmlDecode(strTmp)

        End Function

        Public Shared Function CrypteString(ByVal strValeurDepart As String) As String
            Dim cryptoProvider As New RijndaelManaged
            Dim uEnCode As New UnicodeEncoding
            Dim strDep As String
            Dim bDep() As Byte
            'strDep = strValeurDepart
            strDep = System.Web.HttpUtility.HtmlEncode(strValeurDepart)

            bDep = uEnCode.GetBytes(strDep)
            Dim stmCipherText As New MemoryStream
            Dim cryptoWriter As New CryptoStream(stmCipherText, cryptoProvider.CreateEncryptor(key, iv), CryptoStreamMode.Write)
            cryptoWriter.Write(bDep, 0, bDep.Length)
            cryptoWriter.FlushFinalBlock()

            Dim strTmp As String

            strTmp = Convert.ToBase64String(stmCipherText.ToArray())

            cryptoWriter.Clear()
            cryptoProvider.Clear()

            Return strTmp

        End Function

        Public Shared Sub CrypteDataSetSchemaToFile(ByRef ds As DataSet, ByVal strPath As String)
            Dim cryptoProvider As New RijndaelManaged
            Dim FileWriter As New FileStream(strPath, IO.FileMode.Create, IO.FileAccess.Write)
            Dim cryptoWriter As New CryptoStream(FileWriter, cryptoProvider.CreateEncryptor(key, iv), CryptoStreamMode.Write)
            ds.WriteXmlSchema(cryptoWriter)
            cryptoWriter.Close()
            FileWriter.Close()
        End Sub

        Public Shared Sub CrypteDatasetDonneesToFile(ByRef ds As DataSet, ByVal strPath As String, ByVal mode As System.Data.XmlWriteMode)
            Dim cryptoProvider As New RijndaelManaged
            Dim FileWriter As New FileStream(strPath, IO.FileMode.Create, IO.FileAccess.Write)
            Dim cryptoWriter As New CryptoStream(FileWriter, cryptoProvider.CreateEncryptor(key, iv), CryptoStreamMode.Write)
            ds.WriteXml(cryptoWriter, mode)
            cryptoWriter.Close()
            FileWriter.Close()
        End Sub

        Public Shared Sub DeCrypeDatasetSchemaFromFile(ByRef ds As DataSet, ByVal strPath As String)
            Dim cryptoProvider As New System.Security.Cryptography.RijndaelManaged
            Dim FileReader As New System.IO.FileStream(strPath, IO.FileMode.Open)
            Dim cryptoReader As New System.Security.Cryptography.CryptoStream(FileReader, cryptoProvider.CreateDecryptor(key, iv), Security.Cryptography.CryptoStreamMode.Read)
            ds.ReadXmlSchema(cryptoReader)
            cryptoReader.Close()
            FileReader.Close()
        End Sub

        Public Shared Sub DeCrypeDatasetDonneesFromFile(ByRef ds As DataSet, ByVal strPath As String)
            Dim cryptoProvider As New System.Security.Cryptography.RijndaelManaged
            Dim FileReader As New System.IO.FileStream(strPath, IO.FileMode.Open)
            Dim cryptoReader As New System.Security.Cryptography.CryptoStream(FileReader, cryptoProvider.CreateDecryptor(key, iv), Security.Cryptography.CryptoStreamMode.Read)
            ds.ReadXml(cryptoReader)
            cryptoReader.Close()
            FileReader.Close()
        End Sub

        Public Shared Function DeCrypteFromFileToString(ByVal strPath As String) As String
            Dim uEncode As New System.Text.UnicodeEncoding
            Dim cryptoProvider As New System.Security.Cryptography.RijndaelManaged
            Dim bytResultat As New System.IO.MemoryStream
            Dim FileReader As New System.IO.FileStream(strPath, IO.FileMode.Open)
            Dim cryptoReader As New System.Security.Cryptography.CryptoStream(FileReader, cryptoProvider.CreateDecryptor(key, iv), System.Security.Cryptography.CryptoStreamMode.Read)
            Dim strReader As New System.IO.StreamReader(cryptoReader)
            Dim strWriter As New System.IO.StreamWriter(bytResultat)
            strWriter.Write(strReader.ReadToEnd)
            strWriter.Flush()
            cryptoReader.Close()
            FileReader.Close()
            Return strWriter.Encoding.GetString(bytResultat.ToArray())
        End Function

        Public Shared Sub DeCrypteFromStringToFile(ByVal strPath As String, ByVal strString As String)
            Dim cryptoProvider As New RijndaelManaged
            Dim uEncode As New UnicodeEncoding

            Dim strCipherText As String
            strCipherText = strString
            Dim bytCipherText As Byte() = Convert.FromBase64String(strCipherText)

            Dim stmPlainText As New MemoryStream
            Dim stmCipherText1 As New MemoryStream(bytCipherText)
            Dim cryptoReader1 As New CryptoStream(stmCipherText1, cryptoProvider.CreateDecryptor(key, iv), CryptoStreamMode.Read)
            Dim sw As New StreamWriter(stmPlainText)
            Dim sr As New StreamReader(cryptoReader1)

            sw.Write(sr.ReadToEnd)

            sw.Flush()

            Dim strTmp As String
            strTmp = uEncode.GetString(stmPlainText.ToArray())

            cryptoReader1.Clear()
            cryptoProvider.Clear()

            sw.Close()
            sr.Close()

        End Sub

    End Class
End Namespace

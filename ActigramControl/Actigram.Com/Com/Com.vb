
Namespace Com

    Class CommException
        Inherits ApplicationException
        Sub New(ByVal Reason As String)
            MyBase.New(Reason)
        End Sub
    End Class


    Public Class Com
        Public Structure DCB
            Public DCBlength As Int32
            Public BaudRate As Int32
            Public fBitFields As Int32
            Public wReserved As Int16
            Public XonLim As Int16
            Public XoffLim As Int16
            Public ByteSize As Byte
            Public Parity As Byte
            Public StopBits As Byte
            Public XonChar As Byte
            Public XoffChar As Byte
            Public ErrorChar As Byte
            Public EofChar As Byte
            Public EvtChar As Byte
            Public wReserved1 As Int16 'Reserved; Do Not Use
        End Structure

        Public Structure COMMTIMEOUTS
            Public ReadIntervalTimeout As Int32
            Public ReadTotalTimeoutMultiplier As Int32
            Public ReadTotalTimeoutConstant As Int32
            Public WriteTotalTimeoutMultiplier As Int32
            Public WriteTotalTimeoutConstant As Int32
        End Structure

        Public Const GENERIC_READ As Int32 = &H80000000
        Public Const GENERIC_WRITE As Int32 = &H40000000
        Public Const OPEN_EXISTING As Int32 = 3
        Public Const FILE_ATTRIBUTE_NORMAL As Int32 = &H80
        Public Const NOPARITY As Int32 = 0
        Public Const ONESTOPBIT As Int32 = 0

        Public Declare Auto Function CreateFile Lib "kernel32.dll" _
           (ByVal lpFileName As String, ByVal dwDesiredAccess As Int32, _
              ByVal dwShareMode As Int32, ByVal lpSecurityAttributes As IntPtr, _
                 ByVal dwCreationDisposition As Int32, ByVal dwFlagsAndAttributes As Int32, _
                    ByVal hTemplateFile As IntPtr) As IntPtr

        Public Declare Auto Function GetCommState Lib "kernel32.dll" (ByVal nCid As IntPtr, _
           ByRef lpDCB As DCB) As Boolean

        Public Declare Auto Function SetCommState Lib "kernel32.dll" (ByVal nCid As IntPtr, _
           ByRef lpDCB As DCB) As Boolean

        Public Declare Auto Function GetCommTimeouts Lib "kernel32.dll" (ByVal hFile As IntPtr, _
           ByRef lpCommTimeouts As COMMTIMEOUTS) As Boolean

        Public Declare Auto Function SetCommTimeouts Lib "kernel32.dll" (ByVal hFile As IntPtr, _
           ByRef lpCommTimeouts As COMMTIMEOUTS) As Boolean

        Public Declare Auto Function WriteFile Lib "kernel32.dll" (ByVal hFile As IntPtr, _
           ByVal lpBuffer As Byte(), ByVal nNumberOfBytesToWrite As Int32, _
              ByRef lpNumberOfBytesWritten As Int32, ByVal lpOverlapped As IntPtr) As Boolean

        Public Declare Auto Function ReadFile Lib "kernel32.dll" (ByVal hFile As IntPtr, _
           ByVal lpBuffer As Byte(), ByVal nNumberOfBytesToRead As Int32, _
              ByRef lpNumberOfBytesRead As Int32, ByVal lpOverlapped As IntPtr) As Boolean

        Public Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal hObject As IntPtr) As Boolean

        Private _nPort As Short = 3
        Private _Standard As String = ""

        Public Property NPort() As Short
            Get
                Return _nPort
            End Get
            Set(ByVal Value As Short)
                _nPort = Value
            End Set
        End Property

        Public Property Standard() As String
            Get
                Return _Standard
            End Get
            Set(ByVal Value As String)
                _Standard = Value
            End Set
        End Property

        Public Function Dial(ByVal TelNumber As String, Optional ByVal AfficheDialog As Boolean = True) As String
            Dim Success As Boolean
            Dim hSerialPort As IntPtr
            Dim oEnc As System.Text.Encoding = System.Text.ASCIIEncoding.GetEncoding(1252)
            Dim Buffer As Byte()

            Dim Port As Short = _nPort

            Buffer = oEnc.GetBytes(("ATDT" & _Standard & TelNumber & ";" & vbCr).ToString)

            Try
                hSerialPort = CreateFile("COM" & Port.ToString, GENERIC_READ Or GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero)
                If hSerialPort.ToInt32 = -1 Then
                    MsgBox(hSerialPort.ToString & vbCrLf & "COM" & Port.ToString)
                End If
            Catch
                MsgBox("Pb Ouverture Port COM" & Port.ToString)
                Return ""
            End Try
            Try
                SettingPort(hSerialPort)
            Catch
                MsgBox("Pb SettingPort")
                Return ""
            End Try
            Try
                SettingTimeout(hSerialPort)
            Catch
                MsgBox("Pb SettingTimeout")
                Return ""
            End Try

            Dim BytesWritten As Integer

            Success = WriteFile(hSerialPort, Buffer, Buffer.Length, BytesWritten, IntPtr.Zero)

            Dim strTampon As String = ""

            If Success Then
                Dim BytesRead As Integer, BytesToRead As Integer
                BytesToRead = 1
                Dim BufferRead(0) As Byte

                Do
                    Success = ReadFile(hSerialPort, BufferRead, BytesToRead, BytesRead, IntPtr.Zero)
                    If Success Then
                        strTampon = oEnc.GetString(BufferRead)
                    End If

                    Do While BytesRead <> 0
                        Success = ReadFile(hSerialPort, BufferRead, BytesToRead, BytesRead, IntPtr.Zero)
                        If Success Then
                            strTampon += oEnc.GetString(BufferRead)
                        End If
                    Loop
                    If strTampon = vbLf Then
                        strTampon = "Décrocher le combiné"
                        Exit Do
                    End If
                    If strTampon = "OK" Then
                        strTampon = "Décrocher le combiné"
                        Exit Do
                    End If
                    If strTampon.IndexOf("NO DIALTONE") >= 0 Then
                        strTampon = "Pas de tonalité"
                        Exit Do
                    End If
                Loop
            End If
            If AfficheDialog = True Then
                MsgBox(strTampon)
            End If
            Buffer = oEnc.GetBytes("ATH" & vbCr)
            Success = WriteFile(hSerialPort, Buffer, Buffer.Length, BytesWritten, IntPtr.Zero)
            Success = CloseHandle(hSerialPort)
            Return strTampon
        End Function

        Sub SettingPort(ByVal hSerialPort As IntPtr)
            Dim success As Boolean
            Dim MyDCB As DCB
            ' Retrieve the current control settings.
            success = GetCommState(hSerialPort, MyDCB)
            If success = False Then
                Throw New CommException("Unable to retrieve the current control settings")
            End If
            ' Modify the properties of MyDCB as appropriate.
            ' WARNING: Make sure to modify the properties in accordance with their supported values.
            MyDCB.BaudRate = 9600
            MyDCB.ByteSize = 8
            MyDCB.Parity = NOPARITY
            MyDCB.StopBits = ONESTOPBIT
            ' Reconfigure COM1 based on the properties of MyDCB.
            success = SetCommState(hSerialPort, MyDCB)
            If success = False Then
                Throw New CommException("Unable to reconfigure COM1")
            End If
        End Sub

        Sub SettingTimeout(ByVal hSerialPort As IntPtr)
            Dim Success As Boolean
            Dim MyCommTimeouts As COMMTIMEOUTS
            ' Retrieve the current time-out settings.
            Success = GetCommTimeouts(hSerialPort, MyCommTimeouts)
            If Success = False Then
                Throw New CommException("Unable to retrieve current time-out settings")
            End If
            ' Modify the properties of MyCommTimeouts as appropriate.
            ' WARNING: Make sure to modify the properties in accordance with their supported values.
            MyCommTimeouts.ReadIntervalTimeout = 100
            MyCommTimeouts.ReadTotalTimeoutConstant = 100
            MyCommTimeouts.ReadTotalTimeoutMultiplier = 1
            MyCommTimeouts.WriteTotalTimeoutConstant = 0
            MyCommTimeouts.WriteTotalTimeoutMultiplier = 0
            ' Reconfigure the time-out settings, based on the properties of MyCommTimeouts.
            Success = SetCommTimeouts(hSerialPort, MyCommTimeouts)
            If Success = False Then
                Throw New CommException("Unable to reconfigure the time-out settings")
            End If
        End Sub

    End Class

End Namespace
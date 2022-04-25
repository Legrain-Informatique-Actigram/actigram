Imports Microsoft.Win32
Imports System.Runtime.InteropServices

Public Module Reg

    Public Function GetFileDescription(ByVal filename As String) As String
        Dim applicationType As String
        Dim contentType As String

        If filename.LastIndexOf(".") < 0 Then Throw New ArgumentException("Le nom de fichier doit contenir une extension")

        Dim extension As String = filename.Substring(filename.LastIndexOf(".")).ToLower
        'get the application class the extension is associated to
        Using rgk As RegistryKey = Registry.ClassesRoot.OpenSubKey(extension)
            If rgk Is Nothing Then
                Return "fichiers " & extension.Substring(1).ToUpper
            Else
                applicationType = rgk.GetValue("", String.Empty).ToString()
            End If
        End Using

        'get the file type description for the application associated to
        Using rgk As RegistryKey = Registry.ClassesRoot.OpenSubKey(applicationType)
            contentType = rgk.GetValue("", String.Empty).ToString()
        End Using

        Return contentType
    End Function

#Region "Déclarations API"
    Private Structure SHFILEINFO
        Public hIcon As IntPtr ' : icon
        Public iIcon As Integer ' : icondex
        Public dwAttributes As Integer ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Private Declare Ansi Function SHGetFileInfo Lib "shell32.dll" (ByVal pszPath As String, _
    ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Integer, _
    ByVal uFlags As Integer) As IntPtr

    <Flags()> _
   Public Enum SHGetFileInfoConstants As Integer
        ''' <summary>
        ''' Get icon.  Combine with SHGFI_LARGEICON, SHGFI_SMALLICON,
        ''' SHGFI_OPENICON, SHGFI_SHELLICONSIZE, SHGFI_LINKOVERLAY,
        ''' SHGFI_SELECTED, SHGFI_ADDOVERLAYS to specify icon
        ''' size.
        ''' </summary>
        SHGFI_ICON = &H100
        ''' <summary>
        ''' Get the Display name of the file.
        ''' </summary>
        SHGFI_DISPLAYNAME = &H200
        ''' <summary>
        ''' Get the TypeName of the file.
        ''' </summary>
        SHGFI_TYPENAME = &H400
        ''' <summary>
        ''' Get the attributes of the file.
        ''' </summary>
        SHGFI_ATTRIBUTES = &H800
        ''' <summary>
        ''' Get the icon location (not used in this class)
        ''' </summary>
        SHGFI_ICONLOCATION = &H1000
        ''' <summary>
        ''' Get the exe type (not used in this class)
        ''' </summary>
        SHGFI_EXETYPE = &H2000
        ''' <summary>
        ''' Get the index of the icon in the System Image List (use
        ''' vbAccelerator SystemImageList class instead)
        ''' </summary>
        SHGFI_SYSICONINDEX = &H4000
        ''' <summary>
        ''' Put a link overlay on icon 
        ''' </summary>
        SHGFI_LINKOVERLAY = &H8000
        ''' <summary>
        ''' Show icon in selected state 
        ''' </summary>
        SHGFI_SELECTED = &H10000
        ''' <summary>
        ''' Get only specified attributes (not supported in this class)
        ''' </summary>
        SHGFI_ATTR_SPECIFIED = &H20000
        ''' <summary>
        ''' get large icon 
        ''' </summary>
        SHGFI_LARGEICON = &H0
        ''' <summary>
        ''' get small icon 
        ''' </summary>
        SHGFI_SMALLICON = &H1
        ''' <summary>
        ''' get open icon 
        ''' </summary>
        SHGFI_OPENICON = &H2
        ''' <summary>
        ''' get shell size icon 
        ''' </summary>
        SHGFI_SHELLICONSIZE = &H4
        'SHGFI_PIDL = &H8,                  'pszPath is a pidl 
        ''' <summary>
        ''' Use passed dwFileAttribute
        ''' </summary>
        SHGFI_USEFILEATTRIBUTES = &H10
        ''' <summary>
        ''' Apply the appropriate overlays
        ''' </summary>
        SHGFI_ADDOVERLAYS = &H20
        ''' <summary>
        ''' Get the index of the overlay (not used in this class)
        ''' </summary>
        SHGFI_OVERLAYINDEX = &H40
    End Enum
#End Region

    Public Function GetFileIcon(ByVal filename As String, Optional ByVal options As SHGetFileInfoConstants = SHGetFileInfoConstants.SHGFI_SMALLICON) As System.Drawing.Icon
        Dim hImg As IntPtr  'The handle to the system image list.
        Dim shinfo As New SHFILEINFO()
        With shinfo
            .szDisplayName = New String(Chr(0), 260)
            .szTypeName = New String(Chr(0), 80)
        End With

        'Use this to get the small icon.
        hImg = SHGetFileInfo(filename, 0, shinfo, Marshal.SizeOf(shinfo), SHGetFileInfoConstants.SHGFI_ICON Or options)

        'The icon is returned in the hIcon member of the shinfo struct.
        If shinfo.hIcon.ToInt32 <> 0 Then
            Return System.Drawing.Icon.FromHandle(shinfo.hIcon)
        Else
            Return Nothing
        End If
    End Function
End Module

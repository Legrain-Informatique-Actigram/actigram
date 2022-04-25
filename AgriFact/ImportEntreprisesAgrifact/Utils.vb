#Region " Classes "
Public Class ListboxItem

    Private _value As Object
    Public Property Value() As Object
        Get
            Return _value
        End Get
        Set(ByVal value As Object)
            _value = value
        End Set
    End Property


    Private _text As String
    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            _text = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal value As Object)
        Me.Value = value
        Me.Text = value.ToString
    End Sub

    Public Sub New(ByVal text As String, ByVal value As Object)
        Me.Text = text
        Me.Value = value
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class

Public Class UserCancelledException
    Inherits ApplicationException

    Public Sub New(ByVal s As String)
        MyBase.New(s)
    End Sub

End Class
#End Region

#Region " Modules "
Module IOUtils
    Public Sub LogMessage(ByVal message As String)
        My.Application.Log.WriteEntry(message)
    End Sub

    Public Sub LogException(ByVal e As Exception, Optional ByVal severity As TraceEventType = TraceEventType.Critical)
        My.Application.Log.WriteException(e, severity, e.StackTrace)
        If e.InnerException IsNot Nothing Then
            LogException(e.InnerException, severity)
        End If
    End Sub

    Public Function CheminComplet(ByVal fichier As String) As String
        If IO.Path.IsPathRooted(fichier) Then
            Return fichier
        Else
            Return IO.Path.Combine(My.Application.Info.DirectoryPath, fichier)
        End If
    End Function

    Public Sub OuvrirFichier(ByVal chemin As String, Optional ByVal verb As String = Nothing, Optional ByVal arguments As String = "")
        If Not IO.File.Exists(chemin) AndAlso Not IO.Directory.Exists(chemin) Then
            MsgBox("Fichier ou répertoire introuvable", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            If verb Is Nothing Then
                Process.Start(chemin, arguments)
            Else
                Dim pi As New ProcessStartInfo(chemin)
                pi.Arguments = arguments 'Peut poser problème ??
                pi.Verb = verb
                pi.UseShellExecute = True
                Process.Start(pi)
            End If
        Catch ex As Exception
            LogException(ex)
            MsgBox("Erreur : " & ex.Message)
        End Try
    End Sub
End Module

Module GenericsUtils
    Public Function Cast(Of T)(ByVal o As Object) As T
        Return DirectCast(o, T)
    End Function

    Public Function EnumParse(Of T)(ByVal name As String) As T
        Return CType([Enum].Parse(GetType(T), name), T)
    End Function
End Module

Module FormsUtils
    Private defaultIconHandle As IntPtr = IntPtr.Zero

    Public Sub SetChildFormIcon(ByVal fr As Form)
        If defaultIconHandle = IntPtr.Zero Then
            Using f As New Form
                defaultIconHandle = f.Icon.Handle
            End Using
        End If
        If fr.Icon.Handle = defaultIconHandle Then
            Dim parentForm As Form = Nothing
            If fr.MdiParent IsNot Nothing Then
                parentForm = fr.MdiParent
            ElseIf fr.Owner IsNot Nothing Then
                parentForm = fr.Owner
            End If
            If parentForm IsNot Nothing Then
                fr.Icon = parentForm.Icon
            End If
        End If
    End Sub
End Module

Module ReflectionUtils
    Public Function InvokeMethod(ByVal obj As Object, ByVal mi As Reflection.MethodInfo, ByVal paramValues As Dictionary(Of String, Object)) As Object
        Dim params As New ArrayList
        For Each pi As Reflection.ParameterInfo In mi.GetParameters
            If paramValues.ContainsKey(pi.Name) Then
                params.Add(paramValues(pi.Name))
            End If
        Next
        Return mi.Invoke(obj, Reflection.BindingFlags.InvokeMethod, Nothing, params.ToArray, Nothing)
    End Function
End Module
#End Region
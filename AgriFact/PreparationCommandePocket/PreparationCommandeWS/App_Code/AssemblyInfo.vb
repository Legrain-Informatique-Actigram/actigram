Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' Les informations générales relatives à un assembly dépendent de 
' l'ensemble d'attributs suivant. Changez les valeurs de ces attributs pour modifier les informations
' associées à un assembly.

' Vérifiez les valeurs des attributs de l'assembly
<Assembly: AssemblyTitle("PreparationCommandeWS")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("Actigram")> 
<Assembly: AssemblyProduct("PreparationCommandeWS")> 
<Assembly: AssemblyCopyright("Copyright ©  2010")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'Le GUID suivant est pour l'ID de la typelib si ce projet est exposé à COM
<Assembly: Guid("c6151c93-7c37-4a69-bdeb-a0ece453b879")> 

' Les informations de version pour un assembly se composent des quatre valeurs suivantes :
'
'      Version principale
'      Version secondaire 
'      Numéro de build
'      Révision
'
' Vous pouvez spécifier toutes les valeurs ou indiquer les numéros de build et de révision par défaut 
' en utilisant '*', comme indiqué ci-dessous :
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.0.*")> 

Namespace My

    Public Class [Global]
        Private Shared _app As MyApplication
        Public Shared ReadOnly Property Application() As MyApplication
            Get
                If _app Is Nothing Then
                    _app = New MyApplication
                End If
                Return _app
            End Get
        End Property
    End Class

    Public Class MyApplication
        Public Version As Version
        Public Product As String
        Public Copyright As String
        Public Company As String
        Public Title As String
        Public Description As String
        Public Guid As Guid
        Public DefaultConnectionString As String
        Public Culture As Globalization.CultureInfo

        Public Sub New()
            Dim asm As Assembly = Assembly.GetExecutingAssembly
            Me.Version = asm.GetName.Version
            Me.DefaultConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
            Me.Culture = Globalization.CultureInfo.CurrentCulture
            Dim attributes() As Object = asm.GetCustomAttributes(True)
            For Each a As Object In attributes
                If TypeOf a Is AssemblyCompanyAttribute Then : Me.Company = CType(a, AssemblyCompanyAttribute).Company
                ElseIf TypeOf a Is AssemblyProductAttribute Then : Me.Product = CType(a, AssemblyProductAttribute).Product
                ElseIf TypeOf a Is AssemblyTitleAttribute Then : Me.Title = CType(a, AssemblyTitleAttribute).Title
                ElseIf TypeOf a Is AssemblyCopyrightAttribute Then : Me.Copyright = CType(a, AssemblyCopyrightAttribute).Copyright
                ElseIf TypeOf a Is AssemblyDescriptionAttribute Then : Me.Description = CType(a, AssemblyDescriptionAttribute).Description
                ElseIf TypeOf a Is GuidAttribute Then : Me.Guid = New Guid(CType(a, GuidAttribute).Value)
                End If
            Next
        End Sub

    End Class
End Namespace

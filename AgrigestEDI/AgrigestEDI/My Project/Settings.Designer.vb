﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :2.0.50727.5456
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings),MySettings)
        
#Region "Fonctionnalité Enregistrement automatique My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property DebugSql() As Boolean
            Get
                Return CType(Me("DebugSql"),Boolean)
            End Get
            Set
                Me("DebugSql") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Etats")>  _
        Public Property RepEtats() As String
            Get
                Return CType(Me("RepEtats"),String)
            End Get
            Set
                Me("RepEtats") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Program Files\UltraVNC")>  _
        Public Property CheminVNC() As String
            Get
                Return CType(Me("CheminVNC"),String)
            End Get
            Set
                Me("CheminVNC") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("193.251.24.103:5500")>  _
        Public Property AdresseVNC() As String
            Get
                Return CType(Me("AdresseVNC"),String)
            End Get
            Set
                Me("AdresseVNC") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("CO")>  _
        Public Property CG() As String
            Get
                Return CType(Me("CG"),String)
            End Get
            Set
                Me("CG") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SuggestLibPiece() As Boolean
            Get
                Return CType(Me("SuggestLibPiece"),Boolean)
            End Get
            Set
                Me("SuggestLibPiece") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property DernierExploit() As String
            Get
                Return CType(Me("DernierExploit"),String)
            End Get
            Set
                Me("DernierExploit") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property AdresseVNCID() As Integer
            Get
                Return CType(Me("AdresseVNCID"),Integer)
            End Get
            Set
                Me("AdresseVNCID") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("05.62.72.78.37")>  _
        Public ReadOnly Property SupportTel() As String
            Get
                Return CType(Me("SupportTel"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("info@actigram.com")>  _
        Public ReadOnly Property SupportMail() As String
            Get
                Return CType(Me("SupportMail"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Data\dbPlantypeCO.md"& _ 
            "b")>  _
        Public ReadOnly Property dbPlantypeCOConnectionString() As String
            Get
                Return CType(Me("dbPlantypeCOConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\ProgramData\Actigram\Agrigest ED"& _ 
            "I\Data\dbDonneesM00001_100712180119.mdb""")>  _
        Public ReadOnly Property dbDonneesConnectionString() As String
            Get
                Return CType(Me("dbDonneesConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("admin")>  _
        Public ReadOnly Property AdminPassw() As String
            Get
                Return CType(Me("AdminPassw"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property BloqueExporte() As Boolean
            Get
                Return CType(Me("BloqueExporte"),Boolean)
            End Get
            Set
                Me("BloqueExporte") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property MustUpgrade() As Boolean
            Get
                Return CType(Me("MustUpgrade"),Boolean)
            End Get
            Set
                Me("MustUpgrade") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("4;512;58")>  _
        Public Property FiltreCptesAReporterNonLettres() As String
            Get
                Return CType(Me("FiltreCptesAReporterNonLettres"),String)
            End Get
            Set
                Me("FiltreCptesAReporterNonLettres") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property AutoUpdate() As Boolean
            Get
                Return CType(Me("AutoUpdate"),Boolean)
            End Get
            Set
                Me("AutoUpdate") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public Property NiveauUpdate() As Integer
            Get
                Return CType(Me("NiveauUpdate"),Integer)
            End Get
            Set
                Me("NiveauUpdate") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("http://193.251.24.103/ActiUpdates/Updates.asmx")>  _
        Public Property AgrigestEDI_ActiUpdates_Updates() As String
            Get
                Return CType(Me("AgrigestEDI_ActiUpdates_Updates"),String)
            End Get
            Set
                Me("AgrigestEDI_ActiUpdates_Updates") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10.2")>  _
        Public ReadOnly Property VersionBase() As String
            Get
                Return CType(Me("VersionBase"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property AutoCheckFTP() As Boolean
            Get
                Return CType(Me("AutoCheckFTP"),Boolean)
            End Get
            Set
                Me("AutoCheckFTP") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property AutoImportEDI() As Boolean
            Get
                Return CType(Me("AutoImportEDI"),Boolean)
            End Get
            Set
                Me("AutoImportEDI") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=""C:\Program Files\Actigram\AgrigestE"& _ 
            "DI\Data\Baremes.mdb""")>  _
        Public ReadOnly Property BaremesConnectionString() As String
            Get
                Return CType(Me("BaremesConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BaremesConnectionStringUserOverride() As String
            Get
                Return CType(Me("BaremesConnectionStringUserOverride"),String)
            End Get
            Set
                Me("BaremesConnectionStringUserOverride") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Plantype\DataPlanType.xml")>  _
        Public Property FichierDataPlanTypeXML() As String
            Get
                Return CType(Me("FichierDataPlanTypeXML"),String)
            End Get
            Set
                Me("FichierDataPlanTypeXML") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.AgrigestEDI.My.MySettings
            Get
                Return Global.AgrigestEDI.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace

﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :2.0.50727.4952
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Cette classe a été générée automatiquement par la classe StronglyTypedResourceBuilder
    'à l'aide d'un outil, tel que ResGen ou Visual Studio.
    'Pour ajouter ou supprimer un membre, modifiez votre fichier .ResX, puis réexécutez ResGen
    'avec l'option /str ou régénérez votre projet VS.
    '''<summary>
    '''  Une classe de ressource fortement typée destinée, entre autres, à la consultation des chaînes localisées.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Retourne l'instance ResourceManager mise en cache utilisée par cette classe.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("DatabaseUpdate.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Remplace la propriété CurrentUICulture du thread actuel pour toutes
        '''  les recherches de ressources à l'aide de cette classe de ressource fortement typée.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Recherche une chaîne localisée semblable à &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt; 
        '''&lt;ListUpdates&gt;
        '''	&lt;Updates&gt;
        '''		&lt;Update VersionAvant=&quot;0.0&quot;   VersionApres=&quot;1.2&quot;   NomScript=&quot;ScriptMigration1.2.sql&quot;   /&gt;
        '''		&lt;Update VersionAvant=&quot;1.2&quot;   VersionApres=&quot;1.2.1&quot; NomScript=&quot;ScriptMigration1.2.1.sql&quot; /&gt;
        '''		&lt;Update VersionAvant=&quot;1.2.1&quot; VersionApres=&quot;1.2.2&quot; NomScript=&quot;ScriptMigration1.2.2.sql&quot; /&gt;
        '''		&lt;Update VersionAvant=&quot;1.2.2&quot; VersionApres=&quot;1.3&quot;   NomScript=&quot;ScriptMigration1.3.sql&quot;   /&gt;
        '''		&lt;Update VersionAvant=&quot;1.3&quot;   VersionApres=&quot;1.3.1&quot; NomScript=&quot;ScriptMi [le reste de la chaîne a été tronqué]&quot;;.
        '''</summary>
        Friend ReadOnly Property ListUpdates() As String
            Get
                Return ResourceManager.GetString("ListUpdates", resourceCulture)
            End Get
        End Property
    End Module
End Namespace

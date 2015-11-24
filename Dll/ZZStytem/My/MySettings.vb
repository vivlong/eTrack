Imports Microsoft.VisualBasic.CompilerServices
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Configuration
Imports System.Runtime.CompilerServices

Namespace ZZSystem.My
    Friend NotInheritable Class MySettings
        Inherits ApplicationSettingsBase
        ' Properties
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                Return MySettings.defaultInstance
            End Get
        End Property
        ' Fields
        Private Shared defaultInstance As MySettings = DirectCast(SettingsBase.Synchronized(New MySettings), MySettings)
    End Class
End Namespace


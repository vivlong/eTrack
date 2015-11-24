Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Configuration
Imports System.Drawing

Namespace ZZSystem
    <OptionText()> _
    Public Class ConColor
        ' Methods
        Private Shared Function GetColor(ByVal strNode As String) As Color
            Dim name As String = ConfigurationManager.AppSettings.Item(strNode)
            Return Color.FromName(name)
        End Function


        ' Properties
        Public Shared ReadOnly Property Deleted As Color
            Get
                If (ConColor._Deleted = Color.Empty) Then
                    ConColor._Deleted = ConColor.GetColor("Deleted")
                End If
                Return ConColor._Deleted
            End Get
        End Property

        Public Shared ReadOnly Property High As Color
            Get
                If (ConColor._High = Color.Empty) Then
                    ConColor._High = ConColor.GetColor("High")
                End If
                Return ConColor._High
            End Get
        End Property

        Public Shared ReadOnly Property Low As Color
            Get
                If (ConColor._Low = Color.Empty) Then
                    ConColor._Low = ConColor.GetColor("Low")
                End If
                Return ConColor._Low
            End Get
        End Property

        Public Shared ReadOnly Property Normal As Color
            Get
                If (ConColor._Normal = Color.Empty) Then
                    ConColor._Normal = ConColor.GetColor("Normal")
                End If
                Return ConColor._Normal
            End Get
        End Property


        ' Fields
        Private Shared _Deleted As Color
        Private Shared _High As Color
        Private Shared _Low As Color
        Private Shared _Normal As Color
    End Class
End Namespace


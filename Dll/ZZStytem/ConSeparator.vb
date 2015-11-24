Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Web.Configuration

Namespace ZZSystem
    <OptionText()> _
    Public Class ConSeparator
        ' Properties
        Public Shared ReadOnly Property Col As String
            Get
                If (IIf(((ConSeparator._Col Is Nothing) OrElse (Operators.CompareString(ConSeparator._Col, String.Empty, True) = 0)), 1, 0) <> 0) Then
                    ConSeparator._Col = WebConfigurationManager.AppSettings.Item("ColSeparator")
                End If
                Return ConSeparator._Col
            End Get
        End Property

        Public Shared ReadOnly Property Par As String
            Get
                If (IIf(((ConSeparator._Par Is Nothing) OrElse (Operators.CompareString(ConSeparator._Par, String.Empty, True) = 0)), 1, 0) <> 0) Then
                    ConSeparator._Par = WebConfigurationManager.AppSettings.Item("ParSeparator")
                End If
                Return ConSeparator._Par
            End Get
        End Property

        Public Shared ReadOnly Property Row As String
            Get
                If (IIf(((ConSeparator._Row Is Nothing) OrElse (Operators.CompareString(ConSeparator._Row, String.Empty, True) = 0)), 1, 0) <> 0) Then
                    ConSeparator._Row = WebConfigurationManager.AppSettings.Item("RowSeparator")
                End If
                Return ConSeparator._Row
            End Get
        End Property


        ' Fields
        Private Shared _Col As String
        Private Shared _Par As String
        Private Shared _Row As String
    End Class
End Namespace


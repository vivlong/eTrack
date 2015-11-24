Imports System
Imports System.Runtime.CompilerServices

Namespace ZZMessage
    Public Class clsMessage
        ' Methods
        Public Shared Function GetErrorMessage(ByVal ex As Exception) As String
            Return ex.Message
        End Function

        Public Shared Function GetFormatMessage(ByVal strFormat As String, ByVal arg0 As Object) As String
            Return String.Format(strFormat, RuntimeHelpers.GetObjectValue(arg0))
        End Function

        Public Shared Function GetFormatMessage(ByVal strFormat As String, ByVal arg As Object()) As String
            Return String.Format(strFormat, arg)
        End Function

        Public Shared Function GetFormatMessage(ByVal strFormat As String, ByVal arg0 As Object, ByVal arg1 As Object) As String
            Return String.Format(strFormat, RuntimeHelpers.GetObjectValue(arg0), RuntimeHelpers.GetObjectValue(arg1))
        End Function

        Public Shared Function GetFormatMessage(ByVal strFormat As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) As String
            Return String.Format(strFormat, RuntimeHelpers.GetObjectValue(arg0), RuntimeHelpers.GetObjectValue(arg1), RuntimeHelpers.GetObjectValue(arg2))
        End Function

    End Class
End Namespace

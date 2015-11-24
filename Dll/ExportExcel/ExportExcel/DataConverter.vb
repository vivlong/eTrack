Imports System

Namespace ExportExcel
    Public Class DataConverter
        ' Methods
        Public Function FormatDateTime(ByVal strValue As String, ByVal strFormat As String) As String
            Dim time As DateTime
            If DateTime.TryParse(strValue, time) Then
                Return time.ToString(strFormat)
            End If
            Return ""
        End Function

        Public Function FormatNumber(ByVal strValue As String, ByVal strFormat As String) As String
            Dim num As Decimal
            If Decimal.TryParse(strValue, num) Then
                Return num.ToString(strFormat)
            End If
            Return ""
        End Function

    End Class
End Namespace


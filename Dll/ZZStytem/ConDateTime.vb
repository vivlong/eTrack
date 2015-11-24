Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Globalization

Namespace ZZSystem
    <OptionText()> _
    Public Class ConDateTime
        ' Methods
        Public Shared Function GetLastDay(ByVal intYear As Integer, ByVal intMonth As Integer) As DateTime
            Dim today As DateTime = DateTime.Today
            today = today.AddYears((intYear - today.Year))
            today = today.AddMonths(((intMonth - today.Month) + 1))
            Return today.AddDays(CDbl((0 - today.Day)))
        End Function

        Public Function Parse(ByVal strDateTime As String, ByVal strDateFormat As String) As DateTime
            Dim provider As New CultureInfo("zh-cn", True)
            If (Operators.CompareString(strDateFormat, "", True) <> 0) Then
                provider.DateTimeFormat.ShortDatePattern = strDateFormat
            Else
                provider.DateTimeFormat.ShortDatePattern = ConDateTime.DateFormat
            End If
            Return DateTime.Parse(strDateTime, provider)
        End Function


        ' Fields
        Public Shared CurrentDateFirstDay As DateTime = DateTime.Now.AddDays(CDbl((1 - DateTime.Now.Day)))
        Public Shared DateFormat As String = "dd/MM/yyyy"
        Public Shared DateTimeFormat As String = "dd/MM/yyyy HH:mm"
        Public Shared DayFormat As String = "dd"
        Public Shared LocalDateFormat As String = "dd/MM/yyyy"
        Public Shared MinDate As DateTime = DateTime.MinValue.AddYears(&H7BC)
        Public Shared MonthFormat As String = "MM"
        Public Shared Now As DateTime = DateTime.Now
        Public Shared Separator As String = "-"
        Public Shared SqlDateFormat As String = "MM/dd/yyyy"
        Public Shared SqlDateTimeFormat As String = "MM/dd/yyyy HH:mm"
        Public Shared TimeFormat As String = "HH:mm:ss"
        Public Shared Today As DateTime = DateTime.Today
        Public Shared YearFormat As String = "yyyy"
    End Class
End Namespace


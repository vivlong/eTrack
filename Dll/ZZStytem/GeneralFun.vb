Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data
Imports System.Globalization
Imports System.Text.RegularExpressions

Namespace ZZSystem
    <OptionText()> _
    Public Class GeneralFun
        ' Methods
        Public Shared Function BoolAsInt(ByVal blValue As Boolean) As Integer
            If blValue Then
                Return 1
            End If
            Return 0
        End Function

        Public Shared Function BoolAsIntString(ByVal blValue As Boolean) As String
            If blValue Then
                Return "1"
            End If
            Return "0"
        End Function

        Public Shared Function BoolStringAsYNString(ByVal strValue As String) As String
            If Boolean.Parse(strValue) Then
                Return "Y"
            End If
            Return "N"
        End Function

        Public Shared Function CheckNull(ByVal objValue As Object, ByVal intType As DbType) As Object
            Select Case CInt(intType)
                Case 3
                    Return ((Not objValue Is DBNull.Value) AndAlso Conversions.ToBoolean(objValue))
                Case 7
                    If (Not objValue Is DBNull.Value) Then
                        Return Conversions.ToDecimal(objValue)
                    End If
                    Return 0
                Case 8
                    If (Not objValue Is DBNull.Value) Then
                        Return Conversions.ToDouble(objValue)
                    End If
                    Return 0
                Case 10, 11
                    If (Not objValue Is DBNull.Value) Then
                        Return Integer.Parse(objValue.ToString)
                    End If
                    Return 0
                Case 12
                    If (Not objValue Is DBNull.Value) Then
                        Return Conversions.ToLong(objValue)
                    End If
                    Return 0
                Case &H10
                    If (Not objValue Is DBNull.Value) Then
                        Return objValue.ToString
                    End If
                    Return ""
            End Select
            If (objValue Is DBNull.Value) Then
                Return Nothing
            End If
            Return objValue
        End Function

        Public Shared Function DateToString(ByVal dtmDate As DateTime, ByVal strFormat As String) As String
            If (DateTime.Compare(dtmDate, ConDateTime.MinDate) <= 0) Then
                Return ""
            End If
            If (IIf((String.IsNullOrEmpty(strFormat) OrElse (Operators.CompareString(strFormat, "", True) = 0)), 1, 0) <> 0) Then
                Return dtmDate.ToString(ConDateTime.DateFormat)
            End If
            Return dtmDate.ToString(strFormat)
        End Function

        Public Shared Function DeleteMoneyZero(ByVal strValue As String) As String
            strValue = strValue.Trim
            strValue = GeneralFun.DeleteTailZero(strValue)
            Dim index As Integer = strValue.IndexOf("."c)
            If ((Operators.CompareString(strValue, "0", True) = 0) Or (Operators.CompareString(strValue, "", True) = 0)) Then
                Return Nothing
            End If
            If (index < 0) Then
                Return (strValue & ".00")
            End If
            If (strValue.Length < (index + 3)) Then
                Return (strValue & "0")
            End If
            Return strValue
        End Function

        Public Shared Function DeleteQuantityZero(ByVal strValue As String) As String
            strValue = strValue.Trim
            strValue = GeneralFun.DeleteTailZero(strValue)
            If ((Operators.CompareString(strValue, "0", True) = 0) Or (Operators.CompareString(strValue, "", True) = 0)) Then
                Return Nothing
            End If
            Return strValue
        End Function

        Public Shared Function DeleteTailZero(ByVal strValue As String) As String
            Dim num2 As Integer
            strValue = strValue.Trim
            Dim flag As Boolean = False
            If (Operators.CompareString(strValue, "", True) = 0) Then
                Return strValue
            End If
            If (strValue.IndexOf("."c) < 0) Then
                Return strValue
            End If
            Dim startIndex As Integer = (strValue.Length - 1)
Label_0095:
            num2 = 0
            If (startIndex >= num2) Then
                If (Operators.CompareString(strValue.Substring(startIndex, 1), ".", True) = 0) Then
                    flag = True
                ElseIf (Operators.CompareString(strValue.Substring(startIndex, 1), "0", True) = 0) Then
                    startIndex = (startIndex + -1)
                    GoTo Label_0095
                End If
            End If
            If flag Then
                Return strValue.Substring(0, startIndex)
            End If
            Return strValue.Substring(0, (startIndex + 1))
        End Function

        Public Shared Function GetCol(ByVal strCol As String) As String()
            Return Regex.Split(strCol, ConSeparator.Col)
        End Function

        Public Shared Function GetPar(ByVal strPar As String) As String()
            Return Regex.Split(strPar, ConSeparator.Par)
        End Function

        Public Shared Function GetRow(ByVal strRow As String) As String()
            Return Regex.Split(strRow, ConSeparator.Row)
        End Function

        Public Shared Function GetSplit(ByVal strValue As String, ByVal strSplit As String) As String()
            Return Regex.Split(strValue, strSplit)
        End Function

        Public Shared Function IntStringAsBool(ByVal strValue As String) As Boolean
            Return (Operators.CompareString(strValue, "1", True) = 0)
        End Function

        Private Shared Function IsZeroString(ByVal strValue As String) As Boolean
            Return (Decimal.Compare(Decimal.Parse(strValue), Decimal.Zero) = 0)
        End Function

        Public Shared Sub JoinString(ByRef strMsg As String, ByVal strAdd As String, ByVal strSeparator As String)
            If (Operators.CompareString(strMsg, "", True) = 0) Then
                strMsg = strAdd
            Else
                strMsg = (strMsg & strSeparator & strAdd)
            End If
        End Sub

        Public Shared Function StringToDate(ByVal strDate As String) As DateTime
            Return GeneralFun.StringToDate(strDate, ConDateTime.DateFormat)
        End Function

        Public Shared Function StringToDate(ByVal strDate As String, ByVal strFormat As String) As DateTime
            Dim minDate As DateTime
            Dim provider As New CultureInfo("zh-cn", True)
            If (Operators.CompareString(strFormat, "", True) <> 0) Then
                provider.DateTimeFormat.ShortDatePattern = strFormat
            Else
                provider.DateTimeFormat.ShortDatePattern = ConDateTime.DateFormat
            End If
            If Not DateTime.TryParse(strDate, provider, DateTimeStyles.NoCurrentDateDefault, minDate) Then
                minDate = ConDateTime.MinDate
            End If
            Return minDate
        End Function

        Public Shared Function StringToDateTime(ByVal strDate As String) As DateTime
            Return GeneralFun.StringToDate(strDate, ConDateTime.DateTimeFormat)
        End Function

        Public Shared Function StringToDateTime(ByVal strDate As String, ByVal strFormat As String) As DateTime
            If (IIf((String.IsNullOrEmpty(strFormat) OrElse (Operators.CompareString(strFormat, "", True) = 0)), 1, 0) <> 0) Then
                Return GeneralFun.StringToDate(strDate, ConDateTime.DateTimeFormat)
            End If
            Return GeneralFun.StringToDate(strDate, strFormat)
        End Function

        Public Shared Function StringToDecimal(ByVal strValue As String) As Decimal
            Dim num As Decimal
            If Not Decimal.TryParse(strValue, num) Then
                num = New Decimal
            End If
            Return num
        End Function

        Public Shared Function StringToInt(ByVal strValue As String) As Integer
            Dim num As Integer
            If Not Integer.TryParse(strValue, num) Then
                num = 0
            End If
            Return num
        End Function

        Public Shared Function ZeroStringToNull(ByVal strValue As String) As String
            If GeneralFun.IsZeroString(strValue) Then
                Return ""
            End If
            Return strValue
        End Function

    End Class
End Namespace


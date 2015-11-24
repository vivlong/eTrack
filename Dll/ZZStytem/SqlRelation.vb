Imports Microsoft.VisualBasic.CompilerServices
Imports System

Namespace ZZSystem
    <OptionText()> _
    Public Class SqlRelation
        ' Methods
        Public Shared Sub AddToWhereString(ByRef strOld As String, ByVal strAdd As String)
            If (Operators.CompareString(strAdd, "", True) <> 0) Then
                If (Operators.CompareString(strOld, "", True) = 0) Then
                    strOld = strAdd
                Else
                    strOld = (strOld & " and " & strAdd)
                End If
            End If
        End Sub

        Public Shared Function GetDateFieldAsYearMonthString(ByVal strField As String) As String
            Return ("convert(nvarchar(7)," & strField & ",120)")
        End Function

        Public Shared Function GetDateTimeWhere(ByVal strFieldName As String, ByVal strValue As String, ByVal intType As Integer) As String
            Select Case intType
                Case 0
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " = '" & strValue & "'")
                    End If
                    Return ""
                Case 1
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " <= '" & strValue & "'")
                    End If
                    Return ""
                Case 2
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " >= '" & strValue & "'")
                    End If
                    Return ""
            End Select
            If (Operators.CompareString(strValue, "", True) = 0) Then
                Return ""
            End If
            Return (strFieldName & " = '" & strValue & "'")
        End Function

        Public Shared Function GetIntegerWhere(ByVal strFieldName As String, ByVal strValue As String, ByVal intType As Integer) As String
            Select Case intType
                Case 0
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " = " & strValue)
                    End If
                    Return ""
                Case 1
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " <= " & strValue)
                    End If
                    Return ""
                Case 2
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " >= " & strValue)
                    End If
                    Return ""
            End Select
            If (Operators.CompareString(strValue, "", True) = 0) Then
                Return ""
            End If
            Return (strFieldName & " = " & strValue)
        End Function

        Public Shared Function GetIntFieldsWhere(ByVal strFieldName As String, ByVal strIds As String, ByVal strNames As String) As String
            If (Operators.CompareString(strIds, "", True) = 0) Then
                Return ""
            End If
            Dim strArray As String() = strIds.Split(New Char() {","c})
            Dim left As String = ""
            Dim num2 As Integer = (strArray.Length - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                If (Operators.CompareString(left, "", True) = 0) Then
                    left = (strFieldName & "=" & strArray(i))
                Else
                    left = String.Concat(New String() {left, " or ", strFieldName, "=", strArray(i)})
                End If
                i += 1
            Loop
            If (left.IndexOf(" or ") > 0) Then
                left = ("(" & left & ")")
            End If
            Return left
        End Function

        Public Shared Function GetOrderString(ByVal strFieldName As String, ByVal blnSortDesc As Boolean) As String
            If (Operators.CompareString(strFieldName, "", True) = 0) Then
                Return ""
            End If
            If blnSortDesc Then
                Return (strFieldName & " Desc")
            End If
            Return strFieldName
        End Function

        Public Function GetStringFieldsWhere(ByVal strFieldName As String, ByVal strNames As String) As String
            If (Operators.CompareString(strNames, "", True) = 0) Then
                Return ""
            End If
            Dim strArray As String() = strNames.Split(New Char() {","c})
            Dim left As String = ""
            Dim num2 As Integer = (strArray.Length - 1)
            Dim i As Integer = 0
            Do While (i <= num2)
                If (Operators.CompareString(left, "", True) = 0) Then
                    left = (strFieldName & "='" & SqlRelation.SqlSafe(strArray(i)) & "'")
                Else
                    left = String.Concat(New String() {left, " or ", strFieldName, "='", SqlRelation.SqlSafe(strArray(i)), "'"})
                End If
                i += 1
            Loop
            If (left.IndexOf(" or ") > 0) Then
                left = ("(" & left & ")")
            End If
            Return left
        End Function

        Public Shared Function GetStringWhere(ByVal strFieldName As String, ByVal strValue As String, ByVal intType As Integer) As String
            Select Case intType
                Case 0
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " like '%" & SqlRelation.SqlSafe(strValue) & "%'")
                    End If
                    Return ""
                Case 1
                    If (Operators.CompareString(strValue, "", True) <> 0) Then
                        Return (strFieldName & " = '" & SqlRelation.SqlSafe(strValue) & "'")
                    End If
                    Return ""
            End Select
            If (Operators.CompareString(strValue, "", True) = 0) Then
                Return ""
            End If
            Return (strFieldName & " like '%" & SqlRelation.SqlSafe(strValue) & "%'")
        End Function

        Public Shared Function GetSubFieldString(ByVal strField As String, ByVal intBegin As Integer, ByVal intEnd As Integer) As String
            If (intEnd = 0) Then
                Return strField
            End If
            Return String.Concat(New String() {"substring(", strField, ",", intBegin.ToString, ",", intEnd.ToString, ") "})
        End Function

        Public Shared Function SqlSafe(ByVal strSql As String) As String
            Return strSql.Replace("'", "''")
        End Function

    End Class
End Namespace


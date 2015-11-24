Imports System
Imports System.Configuration

Namespace ExportExcel
    Public Class ConExportExcel
        ' Methods
        Public Shared Function ExcelButtonOnClick(ByVal intPageSize As Integer, ByVal blnQuery As Boolean) As String
            If blnQuery Then
                Return String.Concat(New String() {"javacript:if(intCount*", intPageSize.ToString, ">=", ConExportExcel.MaxLimit.ToString, "){window.alert(""", ConExportExcel.Information, """);return false;}else{ExportExcel(); return false;}"})
            End If
            Return String.Concat(New String() {"javacript:if(intCount*", intPageSize.ToString, ">=", ConExportExcel.MaxLimit.ToString, "){window.alert(""", ConExportExcel.Information, """);return false;}else{ListExportExcel(); return false;}"})
        End Function

        ' Methods
        Public Shared Function ExcelMulti(ByVal intPageSize As Integer, ByVal blnQuery As Boolean) As String
            If blnQuery Then
                Return String.Concat(New String() {"javacript:if(intCount*", intPageSize.ToString, ">=", ConExportExcel.MaxLimit.ToString, "){window.alert(""", ConExportExcel.Information, """);return false;}else{ExportExcelMul(); return false;}"})
            End If
            Return String.Concat(New String() {"javacript:if(intCount*", intPageSize.ToString, ">=", ConExportExcel.MaxLimit.ToString, "){window.alert(""", ConExportExcel.Information, """);return false;}else{ListExportMul(); return false;}"})
        End Function

        ' Properties
        Public Shared ReadOnly Property MaxLimit As Integer
            Get
                If (ConExportExcel._MaxLimit = 0) Then
                    ConExportExcel._MaxLimit = Integer.Parse(ConfigurationManager.AppSettings.Item("MaxLimit"))
                End If
                Return ConExportExcel._MaxLimit
            End Get
        End Property


        ' Fields
        Private Shared _MaxLimit As Integer = 0
        Public Shared Information As String = "Too many data to be exported!"
    End Class
End Namespace


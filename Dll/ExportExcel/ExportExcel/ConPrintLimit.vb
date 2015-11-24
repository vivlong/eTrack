Imports System
Imports System.Configuration

Namespace ExportExcel
    Public Class ConPrintLimit
        ' Methods
        Public Shared Function PrintButtonOnClick(ByVal intPageSize As Integer, ByVal strClassName As String, ByVal strTableName As String, ByVal intFlag As Integer, ByVal blnQuery As Boolean) As String
            If blnQuery Then
                Return String.Concat(New String() {"javacript:if(intCount*", intPageSize.ToString, ">=", ConPrintLimit.MaxPrintLimit.ToString, "){window.alert(""", ConPrintLimit.Information, """);return false;}else{PrintWeb('", strClassName, "','", strTableName, "',", intFlag.ToString, "); return false;}"})
            End If
            Return String.Concat(New String() {"javacript:if(intCount*", intPageSize.ToString, ">=", ConPrintLimit.MaxPrintLimit.ToString, "){window.alert(""", ConPrintLimit.Information, """);return false;}else{ListPrintWeb('", strClassName, "','", strTableName, "',", intFlag.ToString, "); return false;}"})
        End Function


        ' Properties
        Public Shared ReadOnly Property MaxPrintLimit As Integer
            Get
                If (ConPrintLimit._MaxPrintLimit = 0) Then
                    ConPrintLimit._MaxPrintLimit = Integer.Parse(ConfigurationManager.AppSettings.Item("MaxPrintLimit"))
                End If
                Return ConPrintLimit._MaxPrintLimit
            End Get
        End Property


        ' Fields
        Private Shared _MaxPrintLimit As Integer = 0
        Public Shared Information As String = "Too many data to be printed!"
    End Class
End Namespace


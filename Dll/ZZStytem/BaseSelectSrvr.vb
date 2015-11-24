Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data

Namespace ZZSystem

    Public Class BaseSelectSrvr
        ' Methods
        Public Shared Function GetData(ByVal strSql As String, ByVal strTableName As String) As DataTable
            Try
                Dim [set] As DataSet = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSql)
                If (Operators.CompareString(strTableName, "", True) <> 0) Then
                    [set].Tables.Item(0).TableName = strTableName
                End If
                Return [set].Tables.Item(0)
            Catch exception1 As Exception
                Return Nothing
            End Try
        End Function
    End Class

End Namespace


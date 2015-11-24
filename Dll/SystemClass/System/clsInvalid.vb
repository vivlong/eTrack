Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage
Imports System.Security
Imports System.Text

Namespace SystemClass

#Region " Class of User "
    <Serializable()> _
    Public Class clsInvalid
        Public Shared _instance As clsInvalid
        Public Shared ReadOnly Property Instance() As clsInvalid
            Get
                If _instance Is Nothing Then
                    _instance = New clsInvalid()
                End If
                Return _instance
            End Get
        End Property
        Public Shared Function IsShowByUserFlag(ByVal sFunno As String) As Boolean
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim strSql As String = ""
                strSql = String.Format("select 1 from FunctionInfo where sFunno= '{0}' and UserFlag='Y'", sFunno)
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.Text, strSql)
                'Return DataSet
                dt = ds.Tables(0)
                If dt IsNot Nothing And dt.Rows.Count > 0 Then
                    Return True
                End If
            Catch
                Return False
            End Try
        End Function
    End Class

#End Region
End Namespace


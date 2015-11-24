Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage

Namespace SystemClass

#Region " Class of Util Rate Report  "
    <Serializable()> _
    Public Class clsCID
        Inherits clsQuery

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub

        Public Overrides Function DecodeQueryCondition(ByVal strValue As String, ByRef strMsg As String) As Boolean
            Dim arrValue As String() = strValue.Split("@")
            If arrValue.Length Then
                Where = arrValue(0)
                Query = arrValue(1)
            End If
            strMsg = ""
            Return True
        End Function

        Protected Overrides Function GetList() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = -1

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1500)
                param(1).Value = Where

                param(2) = New SqlParameter("@strQuery", SqlDbType.NVarChar, 1500)
                param(2).Value = Query

                param(3) = New SqlParameter("@strOrderBy", SqlDbType.NVarChar, 100)
                param(3).Value = OrderBy

                param(4) = New SqlParameter("@PageIndex", SqlDbType.Int)
                param(4).Value = PageIndex

                param(5) = New SqlParameter("@PageSize", SqlDbType.Int)
                param(5).Value = PageSize

                param(6) = New SqlParameter("@PageCount", SqlDbType.Int)
                param(6).Direction = ParameterDirection.Output

                param(7) = New SqlParameter("@RecordCount", SqlDbType.Int)
                param(7).Direction = ParameterDirection.Output

                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_CID", param)
                If PageSize = 0 Then
                    'Total Page Count
                    PageCount = 1
                    'Total Record Count
                    RecordCount = ds.Tables(0).Rows.Count
                    dt = ds.Tables(0)
                Else
                    'Total Page Count
                    PageCount = Integer.Parse(param(6).Value.ToString())
                    'Total Record Count
                    RecordCount = Integer.Parse(param(7).Value.ToString())
                    dt = ds.Tables(1)
                End If
                If dt.Rows.Count = 0 Then
                    dt.Rows.Add()
                    IsEmpty = True
                Else
                    IsEmpty = False
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function
    End Class

#End Region
End Namespace

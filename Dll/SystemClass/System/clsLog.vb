Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Imports SysMagic.ZZSystem
Imports SysMagic.ZZMessage

Namespace SystemClass

#Region " Class Log "

    Public Class clsLog

        Public Overloads Shared Function InsertLog(ByVal intUserNo As String, ByVal dtmOperateDate As DateTime, ByVal strRemark As String) As Boolean
            Try
                Dim strUserName As String = ""
                Dim strIpAddress As String = ""
                If System.Web.HttpContext.Current.Session(ConSessionName.UserInfo) IsNot Nothing Then
                    Dim objUser As clsUser = CType(HttpContext.Current.Session(ConSessionName.UserInfo), clsUser)
                    strUserName = objUser.UserName
                    strIpAddress = objUser.IpAddress
                End If
                Return InsertLog(intUserNo, strUserName, strIpAddress, dtmOperateDate, strRemark)
            Catch
                Return False
            End Try
        End Function

        Public Overloads Shared Function InsertLog(ByVal intUserId As String, ByVal strUserName As String, ByVal strIpAddress As String, ByVal dtmOperateDate As DateTime, ByVal strRemark As String) As Boolean
            Try
                Dim param(4) As SqlParameter
                param(0) = New SqlParameter("@lUserId", SqlDbType.NVarChar, 20)
                param(0).Value = intUserId

                param(1) = New SqlParameter("@sUserName", SqlDbType.NVarChar, 20)
                param(1).Value = strUserName

                param(2) = New SqlParameter("@sIpAddress", SqlDbType.NVarChar, 50)
                param(2).Value = strIpAddress

                param(3) = New SqlParameter("@dOperateDate", SqlDbType.DateTime)
                param(3).Value = dtmOperateDate

                param(4) = New SqlParameter("@sRemark", SqlDbType.NVarChar, 1000)
                param(4).Value = strRemark

                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_OperateRecord", param)
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Shared Function DeleteLog(ByVal strDate As String, ByVal strUser As String, ByVal strRemark As String) As String
            Try
                Dim param(2) As SqlParameter
                'DateTime
                param(0) = New SqlParameter("@strDate", SqlDbType.NVarChar, 1000)
                param(0).Value = strDate

                param(1) = New SqlParameter("@strUser", SqlDbType.NVarChar, 1000)
                param(1).Value = strUser

                param(2) = New SqlParameter("@strRemark", SqlDbType.NVarChar, 1000)
                param(2).Value = strRemark

                'Execute 
                Dim intCount As Integer = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_OperateRecord", param)
                Return clsMessage.GetFormatMessage(ConMsgInfo.OperateRecordClearSuccess, intCount.ToString)
            Catch ex As Exception
                Return clsMessage.GetFormatMessage(ConMsgInfo.OperateRecordClearFailure, ex.Message)
            End Try
        End Function

    End Class

#End Region

#Region " Class Log Query "

    <Serializable()> _
    Public Class clsLogQuery
        Inherits clsQuery

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
        End Sub

        Public Overloads Function DecodeQueryCondition(ByVal strValue As String) As Boolean
            Dim strWhere As String = ""
            Dim arrValue As String() = GeneralFun.GetRow(strValue)
            If arrValue.Length <> 3 Then
                Return False
            End If
            'Date
            Dim arrDate As String() = GeneralFun.GetCol(arrValue(0))
            If arrDate.Length <> 3 Then
                Return False
            End If
            If Boolean.Parse(arrDate(0)) Then
                Dim dtmBegin As DateTime
                Dim dtmEnd As DateTime
                If Not DateTime.TryParse(arrDate(1), dtmBegin) Then
                    dtmBegin = ConDateTime.MinDate
                End If
                If Not DateTime.TryParse(arrDate(2), dtmEnd) Then
                    dtmEnd = ConDateTime.Today
                End If
                GetDateWhere(dtmBegin, dtmEnd, strWhere)
            End If
            'User
            Dim arrUser As String() = GeneralFun.GetCol(arrValue(1))
            If arrUser.Length <> 2 Then
                Return False
            End If
            If Boolean.Parse(arrUser(0)) Then
                If arrUser(1) <> "" Then
                    GetUserWhere(arrUser(1), strWhere)
                End If
            End If
            'Content
            Dim arrContent As String() = GeneralFun.GetCol(arrValue(2))
            If arrContent.Length <> 2 Then
                Return False
            End If
            If Boolean.Parse(arrContent(0)) Then
                If arrContent(1) <> "" Then
                    GetRemarkWhere(arrContent(1), strWhere)
                End If
            End If
            'Set Where Property
            Where = strWhere
            Return True
        End Function

        Public Function GetDateWhere(ByVal dtmBegin As DateTime, ByVal dtmEnd As DateTime, ByRef strWhere As String) As Boolean
            Dim strField As String = "a.dOperateDate"
            If dtmBegin <> ConDateTime.MinDate AndAlso dtmEnd <> ConDateTime.MinDate Then
                SqlRelation.AddToWhereString(strWhere, "(" + strField + " between '" + dtmBegin.ToString(ConDateTime.SqlDateFormat) + "' and  '" + dtmEnd.AddSeconds(86399).ToString(ConDateTime.SqlDateTimeFormat) + "')")
            Else
                If dtmBegin <> ConDateTime.MinDate Then
                    SqlRelation.AddToWhereString(strWhere, strField + " >= '" + dtmBegin.ToString(ConDateTime.SqlDateFormat) + "'")
                Else
                    If dtmEnd <> ConDateTime.MinDate Then
                        SqlRelation.AddToWhereString(strWhere, strField + " <= '" + dtmEnd.ToString(ConDateTime.SqlDateFormat) + "'")
                    End If
                End If
            End If
            Return True
        End Function

        Public Function GetUserWhere(ByVal strUser As String, ByRef strWhere As String) As Boolean
            If strUser = "" Then
                Return False
            Else
                SqlRelation.AddToWhereString(strWhere, " (a.sUserName like '%" + strUser + "%' or a.sUserNo like '%" + strUser + "%') ")
                Return True
            End If
        End Function

        Public Function GetRemarkWhere(ByVal strRemark As String, ByRef strWhere As String) As Boolean
            If strRemark = "" Then
                Return False
            Else
                SqlRelation.AddToWhereString(strWhere, " a.sRemark like '%" + strRemark + "%'")
                Return True
            End If
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


                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_OperateRecord", param)
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
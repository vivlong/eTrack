Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports SysMagic.ZZMessage
Imports System.IO
Imports System.Globalization
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Class of Property JobStatus "

    <Serializable()> _
    Public Class clsPropJobStatus
        Inherits clsProp
        'From Jmjm3
        Private _JobNo As String
        Private _LineItemNo As Integer
        Private _DateTime As DateTime
        Private _Description As String
        Private _RefNo As String
        Private _UpdateBy As String
        Private _UpdateDateTime As DateTime
        Private _StatusCode As String
        Private _ShowETrackFlag As String

        Property JobNo() As String
            Get
                Return _JobNo
            End Get
            Set(ByVal value As String)
                _JobNo = value
            End Set
        End Property

        Property LineItemNo() As Integer
            Get
                Return _LineItemNo
            End Get
            Set(ByVal value As Integer)
                _LineItemNo = value
            End Set
        End Property

        Property DateTime() As DateTime
            Get
                Return _DateTime
            End Get
            Set(ByVal value As DateTime)
                _DateTime = value
            End Set
        End Property

        Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        Property RefNo() As String
            Get
                Return _RefNo
            End Get
            Set(ByVal value As String)
                _RefNo = value
            End Set
        End Property

        Property UpdateBy() As String
            Get
                Return _UpdateBy
            End Get
            Set(ByVal value As String)
                _UpdateBy = value
            End Set
        End Property

        Property UpdateDateTime() As DateTime
            Get
                Return _UpdateDateTime
            End Get
            Set(ByVal value As DateTime)
                _UpdateDateTime = value
            End Set
        End Property

        Property StatusCode() As String
            Get
                Return _StatusCode
            End Get
            Set(ByVal value As String)
                _StatusCode = value
            End Set
        End Property
        Property ShowETrackFlag() As String
            Get
                Return _ShowETrackFlag
            End Get
            Set(ByVal value As String)
                _ShowETrackFlag = value
            End Set
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _JobNo = ""
            _LineItemNo = 1
            _DateTime = ConDateTime.MinDate
            _Description = ""
            _RefNo = ""
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _StatusCode = ""
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property JobStatus "

    <Serializable()> _
    Public Class colJobStatus
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropJobStatus(ConClass.NewIdValue)
        End Function

    End Class

#End Region

#Region " Class of JobStatus Server "

    <Serializable()> _
    Public Class clsJobStatus
        Inherits clsBaseSrv



        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colJobStatus()
            Title = "Job Status"
            colProp.AddOneSpaceRecord(0, intUserId)
        End Sub

        ''' <summary>
        ''' 100315 ZhiWei for judge by Role
        ''' </summary>
        ''' <param name="strUserId"></param>
        ''' <param name="RoleName"></param>
        ''' <param name="strFunNo"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal strUserId As String, ByVal RoleName As String, ByVal strFunNo As String)
            MyBase.New(strUserId, RoleName, strFunNo)
            colProp = New colJobStatus()
            Title = "Job Status"
        End Sub


        Public Function IsCanUpdate() As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@ETrackAllowUpdate", SqlDbType.Bit)
                param(0).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_AllowUpdateStatus", param)
                Return Boolean.Parse(param(0).Value.ToString())
            Catch
                Return False
            End Try
        End Function

        Private Function InsertJobStatus(ByVal propJobStatus As clsPropJobStatus, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 20)
                param(0).Value = propJobStatus.JobNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
                param(1).Value = propJobStatus.LineItemNo

                param(2) = New SqlParameter("@DateTime", SqlDbType.DateTime)
                If propJobStatus.DateTime > ConDateTime.MinDate Then
                    param(2).Value = propJobStatus.DateTime
                Else
                    param(2).Value = System.DBNull.Value
                End If

                param(3) = New SqlParameter("@Description", SqlDbType.NVarChar, 255)
                param(3).Value = propJobStatus.Description

                param(4) = New SqlParameter("@RefNo", SqlDbType.NVarChar, 50)
                param(4).Value = propJobStatus.RefNo

                param(5) = New SqlParameter("@UpdateBy", SqlDbType.NVarChar, 50)
                param(5).Value = propJobStatus.UpdateBy

                param(6) = New SqlParameter("@UpdateDateTime", SqlDbType.DateTime)
                param(6).Value = propJobStatus.UpdateDateTime

                param(7) = New SqlParameter("@StatusCode", SqlDbType.NVarChar, 3)
                param(7).Value = propJobStatus.StatusCode

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Jmjm3", param)
                If intResult > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function UpdateJobStatus(ByVal propJobStatus As clsPropJobStatus, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(7) As SqlParameter

                param(0) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 20)
                param(0).Value = propJobStatus.JobNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
                param(1).Value = propJobStatus.LineItemNo

                param(2) = New SqlParameter("@DateTime", SqlDbType.DateTime)
                If propJobStatus.DateTime > ConDateTime.MinDate Then
                    param(2).Value = propJobStatus.DateTime
                Else
                    param(2).Value = System.DBNull.Value
                End If

                param(3) = New SqlParameter("@Description", SqlDbType.NVarChar, 255)
                param(3).Value = propJobStatus.Description

                param(4) = New SqlParameter("@RefNo", SqlDbType.NVarChar, 50)
                param(4).Value = propJobStatus.RefNo

                param(5) = New SqlParameter("@UpdateBy", SqlDbType.NVarChar, 50)
                param(5).Value = propJobStatus.UpdateBy

                param(6) = New SqlParameter("@UpdateDateTime", SqlDbType.DateTime)
                param(6).Value = propJobStatus.UpdateDateTime

                param(7) = New SqlParameter("@StatusCode", SqlDbType.NVarChar, 3)
                param(7).Value = propJobStatus.StatusCode

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_Jmjm3", param)
                If intResult > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function

        Private Function DeleteJobStatus(ByVal propJobStatus As clsPropJobStatus, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 20)
                param(0).Value = propJobStatus.JobNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
                param(1).Value = propJobStatus.LineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Jmjm3", param)
                If intResult > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm3_List", param)
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
                Else
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm3_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal strKey As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@JobNo", SqlDbType.BigInt)
                param(0).Value = strKey

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm3_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overloads Function GetDetail(ByVal strKey As String, ByVal intId As Integer) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 20)
                param(0).Value = strKey
                param(1) = New SqlParameter("@LineItemNo", SqlDbType.Int)
                param(1).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmjm3_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 7 And strRow.Length <> 8 Then
                Return False
            Else
                Dim strJobNo As String = strRow(0)
                Dim intLineItemNo As Integer = Integer.Parse(strRow(1))
                Dim tmpProp As clsPropJobStatus
                If intLineItemNo < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CType(CurrentProp, clsPropJobStatus)
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(strJobNo, intLineItemNo)
                    State = EditState.Edit
                End If
                tmpProp.JobNo = strRow(0)
                tmpProp.LineItemNo = intLineItemNo
                tmpProp.DateTime = GeneralFun.StringToDate(strRow(2))
                tmpProp.Description = strRow(3)
                tmpProp.RefNo = strRow(4)
                tmpProp.UpdateBy = strRow(5)
                tmpProp.UpdateDateTime = ConDateTime.Now
                tmpProp.StatusCode = strRow(6)
                If strRow.Length > 8 Then
                    tmpProp.ShowETrackFlag = strRow(7)
                End If

                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            blnReturn = InsertJobStatus(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            blnReturn = UpdateJobStatus(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            blnReturn = DeleteJobStatus(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            blnReturn = DeleteJobStatus(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.JobNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.JobNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            '        Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            '    clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            '   clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            '  clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropJobStatus = CType(CurrentProp, clsPropJobStatus)
            ' clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.S_No))
        End Sub

    End Class

#End Region

#Region " Class of Status List "

    <Serializable()> _
    Public Class clsJobStatusList

        Public Function ListData() As DataTable
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_Track_Status_List")
                'Return DataSet
                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

    End Class

#End Region
End Namespace

Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Net.Mail
Imports System.Web.UI

Namespace SystemClass

#Region " Class Collection of WMS Info "

    <Serializable()> _
    Public Class colWMS
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropWMS(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of WMS Info "

    <Serializable()> _
    Public Class clsWMS
        Inherits clsBaseSrv
        Private _ConfirmExternal As Boolean
        Public Property ConfirmExternal() As Boolean
            Get
                Return _ConfirmExternal
            End Get
            Set(ByVal value As Boolean)
                _ConfirmExternal = value
            End Set
        End Property

        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            _ConfirmExternal = False
            colProp = New colWMS()
            Title = "WMS"
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
            _ConfirmExternal = False
            colProp = New colWMS()
            Title = "WMS"
        End Sub
        Private Function InsertWMS(ByRef propWMS As clsPropWMS, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(51) As SqlParameter
                param(0) = New SqlParameter("@OrderDate", SqlDbType.NVarChar, 50)

                param(51).Value = propWMS.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_omtx1", param)
                If intResult > 0 Then
                    propWMS.TrxNo = intResult
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateWMS(ByVal propWMS As clsPropWMS, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(50) As SqlParameter
                param(0) = New SqlParameter("@OrderDate", SqlDbType.NVarChar, 50)
                param(0) = New SqlParameter("@OrderDate", SqlDbType.NVarChar, 50)

                param(51).Value = propWMS.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_WMS", param)
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
        Private Function DeleteWMS(ByVal propWMS As clsPropWMS, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propWMS.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Omtx1", param)
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
            Dim IntCondition As String = ""
            Try
                Dim param(8) As SqlParameter
                Dim param1(10) As SqlParameter

                param(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param(0).Value = -1
                param1(0) = New SqlParameter("@intUserId", SqlDbType.Int)
                param1(0).Value = -1

                param(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1500)
                param1(1) = New SqlParameter("@strWhere", SqlDbType.NVarChar, 1500)
                If Condition = "impm1_Balance" Then
                    If Where.Trim = "" Then
                        param(1).Value = " and 1!=1 "
                    Else
                        param(1).Value = Where
                    End If
                Else
                    param(1).Value = Where

                End If
                param(2) = New SqlParameter("@strQuery", SqlDbType.NVarChar, 1500)
                param(2).Value = Query
                param1(2) = New SqlParameter("@strQuery", SqlDbType.NVarChar, 1500)
                param1(2).Value = Query

                param(3) = New SqlParameter("@strOrderBy", SqlDbType.NVarChar, 100)
                param(3).Value = OrderBy
                param1(3) = New SqlParameter("@strOrderBy", SqlDbType.NVarChar, 100)
                param1(3).Value = OrderBy

                param(4) = New SqlParameter("@PageIndex", SqlDbType.Int)
                param(4).Value = PageIndex
                param1(4) = New SqlParameter("@PageIndex", SqlDbType.Int)
                param1(4).Value = PageIndex

                param(5) = New SqlParameter("@PageSize", SqlDbType.Int)
                param(5).Value = PageSize
                param1(5) = New SqlParameter("@PageSize", SqlDbType.Int)
                param1(5).Value = PageSize

                param(6) = New SqlParameter("@PageCount", SqlDbType.Int)
                param(6).Direction = ParameterDirection.Output
                param1(6) = New SqlParameter("@PageCount", SqlDbType.Int)
                param1(6).Direction = ParameterDirection.Output

                param(7) = New SqlParameter("@RecordCount", SqlDbType.Int)
                param(7).Direction = ParameterDirection.Output
                param1(7) = New SqlParameter("@RecordCount", SqlDbType.Int)
                param1(7).Direction = ParameterDirection.Output
                Select Case Condition
                    Case "", "impm1_Balance"
                        IntCondition = "1"
                    Case "Impm1_Movement"
                        IntCondition = "2"
                    Case "Impm1_Inventory1"
                        IntCondition = "3"
                    Case "Impm1_Detail"
                        IntCondition = "1"
                    Case Else
                        IntCondition = "1"
                End Select

                param(8) = New SqlParameter("@Condition", SqlDbType.NVarChar, 2)
                param(8).Value = IntCondition
                param1(8) = New SqlParameter("@Condition", SqlDbType.NVarChar, 2)
                param1(8).Value = IntCondition

                If Condition = "Impm1_Inventory1" Then
                    If Where.IndexOf(">=") > 0 Then
                        Condition1 = Where.Substring(Where.IndexOf(">=") + 3, 10)
                        Where = Where.Remove(Where.IndexOf(">=") - 45, 59)
                    End If

                    If Where.IndexOf("<=") > 0 Then
                        Condition2 = Where.Substring(Where.IndexOf("<=") + 3, 10)
                        'Where = Where.Remove(Where.IndexOf("<=") - 45, 59)
                    End If
                    param1(9) = New SqlParameter("@Condition1", SqlDbType.NVarChar, 50)
                    param1(9).Value = Condition1

                    param1(10) = New SqlParameter("@Condition2", SqlDbType.NVarChar, 50)
                    param1(10).Value = Condition2

                    param1(1).Value = Where
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Impm1_Inventory1_List", param1)
                ElseIf Condition = "Impm1_Movement" Then
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Impm1_Movement_List", param)
                ElseIf Condition = "Impm1_Detail" Then
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Impm1_Detail_List", param)
                Else
                    ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Impm1_List", param)
                End If
                If PageSize = 0 Then
                    'Total Page Count
                    PageCount = 1
                    'Total Record Count
                    RecordCount = ds.Tables(0).Rows.Count
                    dt = ds.Tables(0)
                Else
                    If Condition = "Impm1_Inventory1" Then
                        'Total Page Count
                        PageCount = Integer.Parse(param1(6).Value.ToString())
                        'Total Record Count
                        RecordCount = Integer.Parse(param1(7).Value.ToString())
                        dt = ds.Tables(1)
                    Else
                        'Total Page Count
                        PageCount = Integer.Parse(param(6).Value.ToString())
                        'Total Record Count
                        RecordCount = Integer.Parse(param(7).Value.ToString())
                        dt = ds.Tables(1)
                    End If
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As Long) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 52 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropWMS
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                    'External Flag 
                    'WR Flag
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                'tmpProp.WMSDate = GeneralFun.StringToDate(strRow(1))

                tmpProp.TrxNo = strRow(51)

                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropWMS = CType(CurrentProp, clsPropWMS)
            blnReturn = InsertWMS(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.TrxNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.TrxNo)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropWMS = CType(CurrentProp, clsPropWMS)
            blnReturn = UpdateWMS(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.TrxNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.TrxNo)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropWMS = CType(CurrentProp, clsPropWMS)
            blnReturn = DeleteWMS(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.TrxNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.TrxNo)
                End If
                Return False
            End If
        End Function
        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function

    End Class

#End Region
End Namespace
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

#Region " Class of Issue Server "

    <Serializable()> _
    Public Class clsIssue
        Inherits clsBaseSrv
        Private _MasterId As String

        Public Property MasterId() As String
            Get
                Return _MasterId
            End Get
            Set(ByVal value As String)
                _MasterId = value
            End Set
        End Property
        Public Sub New(ByVal intUserId As String)
            MyBase.New(intUserId)
            colProp = New colIssue()
            Title = "Issue"
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
            colProp = New colIssue()
            Title = "Issue"
        End Sub

        Public Function IsCanUpdate() As Boolean
            Return True
        End Function
        Public Function DeleteIssue(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.NVarChar, 4)
                param(0).Value = strTrxNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.BigInt)
                param(1).Value = strLineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_Track_Omtx2_Issue", param)
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
        Private Function InsertIssue(ByVal propIssue As clsPropIssue, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(6) As SqlParameter

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Omtx2_Issue", param)
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
        Private Function UpdateIssue(ByVal propIssue As clsPropIssue, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(6) As SqlParameter


                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_Omtx2_Issue", param)
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

        Private Function DeleteIssue(ByVal propIssue As clsPropIssue, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.NVarChar, 20)
                param(0).Value = propIssue.TrxNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
                param(1).Value = propIssue.LineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Omtx2_Issue", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Omtx2_Issue_List", param)

                dt = ds.Tables(0)
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function

        Public Overrides Function GetDetail(ByVal intId As Int64) As clsProp
            Return colProp.NewOneProp()

        End Function

        Public Overrides Function GetDetail(ByVal strKey As String) As clsProp
            Return colProp.NewOneProp()
        End Function

        Public Overloads Function GetDetail(ByVal strKey As String, ByVal intId As Integer) As clsProp
            Return colProp.NewOneProp()
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean

            Dim strRow As String() = GeneralFun.GetCol(strValue)
            Dim intLineItemNo As Integer
            Dim dtRec As DataTable
            Dim strsql As String
            If strRow.Length <> 6 Then
                Return False
            Else
                Dim tmpProp As clsPropIssue
                CurrentProp = colProp.NewOneProp()
                tmpProp = CType(CurrentProp, clsPropIssue)
                tmpProp.TrxNo = _MasterId
                State = EditState.Insert
                If strRow(0) = "New" Then
                    strsql = "select max(LineItemNo) from Issue where TrxNo='" & _MasterId & "'"
                    dtRec = BaseSelectSrvr.GetData(strsql, "")
                    If IsDBNull(dtRec.Rows(0)(0)) Then
                        intLineItemNo = 1
                    Else
                        If CInt(dtRec.Rows(0)(0)) >= 1 Then
                            intLineItemNo = CInt(dtRec.Rows(0)(0)) + 1
                        End If
                    End If
                    tmpProp.LineItemNo = intLineItemNo
                Else
                    tmpProp.LineItemNo = GeneralFun.StringToInt(strRow(0))
                End If

                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            blnReturn = InsertIssue(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            blnReturn = UpdateIssue(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            blnReturn = DeleteIssue(tmpProp, conn, trans, 1, strMsg)
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

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            blnReturn = DeleteIssue(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.TrxNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.TrxNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            '        Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            '    clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            '   clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            '  clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropIssue = CType(CurrentProp, clsPropIssue)
            ' clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.S_No))
        End Sub

    End Class

#End Region

#Region " Class of Property Issue "

    <Serializable()> _
    Public Class clsPropIssue
        Inherits clsProp
        'From Issue
        Private _TrxNo As String = ""
        Private _LineItemNo As String = ""
        Private _Date As DateTime
        Private _PackingQty As Integer
        Private _Remark As String = ""
        ' 
        Public Property TrxNo() As String
            Set(ByVal value As String)
                If _TrxNo <> value Then
                    _TrxNo = value
                End If
            End Set
            Get
                Return _TrxNo
            End Get
        End Property
        ' 
        Public Property LineItemNo() As String
            Set(ByVal value As String)
                If _LineItemNo <> value Then
                    _LineItemNo = value
                End If
            End Set
            Get
                Return _LineItemNo
            End Get
        End Property
        ' 
        Public Property [Date]() As DateTime
            Set(ByVal value As DateTime)
                If _Date <> value Then
                    _Date = value
                End If
            End Set
            Get
                Return _Date
            End Get
        End Property
        ' 
        Public Property PackingQty() As Integer
            Set(ByVal value As Integer)
                If _PackingQty <> value Then
                    _PackingQty = value
                End If
            End Set
            Get
                Return _PackingQty
            End Get
        End Property
        ' 
        Public Property Remark() As String
            Set(ByVal value As String)
                If _Remark <> value Then
                    _Remark = value
                End If
            End Set
            Get
                Return _Remark
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _LineItemNo = 0
            _Date = ConDateTime.MinDate
            _PackingQty = 0
            _Remark = ""
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property Issue "

    <Serializable()> _
    Public Class colIssue
        Inherits colclsProp
        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropIssue(ConClass.NewIdValue)
        End Function

    End Class

#End Region
End Namespace
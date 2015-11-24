Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports System.Net.Mail
Imports System.Web.UI
Imports SysMagic.ZZSystem

Namespace SystemClass

#Region " Class of Scan Server "

    <Serializable()> _
    Public Class clsScan
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
            colProp = New colScan()
            Title = "Scan"
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
            colProp = New colScan()
            Title = "Scan"
        End Sub

        Public Function IsCanUpdate() As Boolean
            Return True
        End Function
        Public Function DeleteScan(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.NVarChar, 4)
                param(0).Value = strTrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_Track_Omtx4_Scan", param)
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
        Private Function InsertScan(ByVal propScan As clsPropScan, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(6) As SqlParameter

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Omtx4_Scan", param)
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
        Private Function UpdateScan(ByVal propScan As clsPropScan, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(6) As SqlParameter


                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_Omtx4_Scan", param)
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
        Private Function DeleteScan(ByVal propScan As clsPropScan, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.NVarChar, 20)
                param(0).Value = propScan.OrderId

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Omtx4_Scan", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Omtx4_Scan_List", param)

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
                Dim tmpProp As clsPropScan
                CurrentProp = colProp.NewOneProp()
                tmpProp = CType(CurrentProp, clsPropScan)
                tmpProp.OrderId = _MasterId
                State = EditState.Insert
                If strRow(0) = "New" Then
                    strsql = "select max(LineItemNo) from Scan where TrxNo='" & _MasterId & "'"
                    dtRec = BaseSelectSrvr.GetData(strsql, "")
                    If IsDBNull(dtRec.Rows(0)(0)) Then
                        intLineItemNo = 1
                    Else
                        If CInt(dtRec.Rows(0)(0)) >= 1 Then
                            intLineItemNo = CInt(dtRec.Rows(0)(0)) + 1
                        End If
                    End If
                    tmpProp.OrderId = intLineItemNo
                Else
                    tmpProp.OrderId = GeneralFun.StringToInt(strRow(0))
                End If

                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            blnReturn = InsertScan(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.OrderId)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.OrderId)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            blnReturn = UpdateScan(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.OrderId)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.OrderId)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            blnReturn = DeleteScan(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.OrderId)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.OrderId)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function RestoreData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            blnReturn = DeleteScan(tmpProp, conn, trans, 0, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreSuccess, Title, tmpProp.OrderId)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyRestoreFailure, Title, tmpProp.OrderId)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            '        Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            '    clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            '   clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            '  clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropScan = CType(CurrentProp, clsPropScan)
            ' clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.S_No))
        End Sub

    End Class

#End Region

#Region " Class of Property Scan "

    <Serializable()> _
    Public Class clsPropScan
        Inherits clsProp
        'From Scan
        Private _OrderId As String = ""
        Private _ContainerNo As String = ""
        Private _SortNo As Integer
        Private _Type As String = ""
        Private _OrderNoBarCode As String = ""
        Private _OrderNo As String = ""
        Private _Qty As Integer
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        ' 
        Public Property OrderId() As String
            Set(ByVal value As String)
                If _OrderId <> value Then
                    _OrderId = value
                End If
            End Set
            Get
                Return _OrderId
            End Get
        End Property
        ' 
        Public Property ContainerNo() As String
            Set(ByVal value As String)
                If _ContainerNo <> value Then
                    _ContainerNo = value
                End If
            End Set
            Get
                Return _ContainerNo
            End Get
        End Property
        ' 
        Public Property SortNo() As Integer
            Set(ByVal value As Integer)
                If _SortNo <> value Then
                    _SortNo = value
                End If
            End Set
            Get
                Return _SortNo
            End Get
        End Property
        ' 
        Public Property Type() As String
            Set(ByVal value As String)
                If _Type <> value Then
                    _Type = value
                End If
            End Set
            Get
                Return _Type
            End Get
        End Property
        ' 
        Public Property OrderNoBarCode() As String
            Set(ByVal value As String)
                If _OrderNoBarCode <> value Then
                    _OrderNoBarCode = value
                End If
            End Set
            Get
                Return _OrderNoBarCode
            End Get
        End Property
        ' 
        Public Property OrderNo() As String
            Set(ByVal value As String)
                If _OrderNo <> value Then
                    _OrderNo = value
                End If
            End Set
            Get
                Return _OrderNo
            End Get
        End Property

        Public Property Qty() As Integer
            Set(ByVal value As Integer)
                If _Qty <> value Then
                    _Qty = value
                End If
            End Set
            Get
                Return _Qty
            End Get
        End Property

        Public Property CreateBy() As String
            Set(ByVal value As String)
                If _CreateBy <> value Then
                    _CreateBy = value
                End If
            End Set
            Get
                Return _CreateBy
            End Get
        End Property

        Public Property CreateDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _CreateDateTime <> value Then
                    _CreateDateTime = value
                End If
            End Set
            Get
                Return _CreateDateTime
            End Get
        End Property


        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _OrderId = strId
            _ContainerNo = ""
            _SortNo = -1
            _Type = ""
            _OrderNoBarCode = ""
            _OrderNo = ""
            _Qty = -1
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
        End Sub

    End Class

#End Region

#Region " Class of Collection of Property Scan "

    <Serializable()> _
    Public Class colScan
        Inherits colclsProp
        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropScan(ConClass.NewIdValue)
        End Function

    End Class

#End Region
End Namespace
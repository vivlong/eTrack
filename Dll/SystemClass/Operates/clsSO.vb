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
#Region " Class Collection of SO Info "

    <Serializable()> _
    Public Class colSO
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropSO(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of SO Info "

    <Serializable()> _
    Public Class clsSO
        Inherits clsBaseSrv
        Private _ConfirmExternal As Boolean
        Private _masterId As String
        Public Property masterId() As String
            Get
                Return _masterId
            End Get
            Set(ByVal value As String)
                _masterId = value
            End Set
        End Property
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
            colProp = New colSO()
            Title = "SO"
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
            colProp = New colSO()
            Title = "SO"
        End Sub

        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Private Function InsertSO(ByRef propSO As clsPropSO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(31) As SqlParameter
                param(0) = New SqlParameter("@OrganisationCode", SqlDbType.NVarChar, 20)
                param(1) = New SqlParameter("@DemurrageCode", SqlDbType.NVarChar, 20)
                param(2) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 40)
                param(3) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
                param(4) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@ReturnType", SqlDbType.NVarChar, 4)
                param(6) = New SqlParameter("@ConsigneeCode", SqlDbType.NVarChar, 20)
                param(7) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar, 100)
                param(8) = New SqlParameter("@ConsigneeAddress1", SqlDbType.NVarChar, 90)
                param(9) = New SqlParameter("@ConsigneeContactPerson", SqlDbType.NVarChar, 100)
                param(10) = New SqlParameter("@ConsigneeContactNo", SqlDbType.NVarChar, 100)
                param(11) = New SqlParameter("@DepotCode", SqlDbType.NVarChar, 20)
                param(12) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar, 10)
                param(13) = New SqlParameter("@DetentionCode", SqlDbType.NVarChar, 20)
                param(14) = New SqlParameter("@DetentionFreeDay", SqlDbType.Int)
                param(15) = New SqlParameter("@DetentionStartDate", SqlDbType.DateTime)
                param(16) = New SqlParameter("@InstructionToDepot", SqlDbType.NVarChar, 2000)
                param(17) = New SqlParameter("@TruckerCode", SqlDbType.NVarChar, 20)
                param(18) = New SqlParameter("@TruckerName", SqlDbType.NVarChar, 100)
                param(19) = New SqlParameter("@CompleteDate", SqlDbType.DateTime)
                param(20) = New SqlParameter("@TruckerRefNo", SqlDbType.NVarChar, 100)
                param(21) = New SqlParameter("@StoringOrderNo", SqlDbType.NVarChar, 20)
                param(22) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(22).Direction = ParameterDirection.Output
                param(23) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 100)
                param(24) = New SqlParameter("@ConsigneeAddress2", SqlDbType.NVarChar, 90)
                param(25) = New SqlParameter("@ConsigneeAddress3", SqlDbType.NVarChar, 90)
                param(26) = New SqlParameter("@ConsigneeAddress4", SqlDbType.NVarChar, 90)
                param(27) = New SqlParameter("@DemurrageFreeDay", SqlDbType.Int)
                param(28) = New SqlParameter("@DemurrageStartDate", SqlDbType.DateTime)
                param(29) = New SqlParameter("@SiteCode", SqlDbType.NVarChar, 10)
                param(30) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)
                param(31) = New SqlParameter("@RefNo", SqlDbType.NVarChar, 50)

                param(0).Value = propSO.OrganisationCode
                param(1).Value = propSO.DemurrageCode
                param(2).Value = propSO.JobNo
                param(3).Value = propSO.VoyageNo
                param(4).Value = propSO.EtaDate
                param(5).Value = propSO.ReturnType
                param(6).Value = propSO.ConsigneeCode
                param(7).Value = propSO.ConsigneeName
                param(8).Value = propSO.ConsigneeAddress1
                param(9).Value = propSO.ConsigneeContactPerson
                param(10).Value = propSO.ConsigneeContactNo
                param(11).Value = propSO.DepotCode
                param(12).Value = propSO.PortOfLoadingCode
                param(13).Value = propSO.DetentionCode
                param(14).Value = propSO.DetentionFreeDay
                param(15).Value = propSO.DetentionStartDate
                param(16).Value = propSO.InstructionToDepot
                param(17).Value = propSO.TruckerCode
                param(18).Value = propSO.TruckerName
                param(19).Value = propSO.CompleteDate
                param(20).Value = propSO.TruckerRefNo
                param(21).Value = propSO.StoringOrderNo
                param(22).Value = propSO.TrxNo
                param(23).Value = propSO.VesselName
                param(24).Value = propSO.ConsigneeAddress2
                param(25).Value = propSO.ConsigneeAddress3
                param(26).Value = propSO.ConsigneeAddress4
                param(27).Value = propSO.DemurrageFreeDay
                param(28).Value = propSO.DemurrageStartDate
                param(29).Value = propSO.SiteCode
                param(30).Value = propSO.UserNo
                param(31).Value = propSO.RefNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_ctso1", param)
                If intResult > 0 Then
                    propSO.TrxNo = Int64.Parse(param(22).Value.ToString())
                    masterId = Int64.Parse(param(22).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateSO(ByVal propSO As clsPropSO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(29) As SqlParameter
                param(0) = New SqlParameter("@OrganisationCode", SqlDbType.NVarChar, 20)
                param(1) = New SqlParameter("@DemurrageCode", SqlDbType.NVarChar, 20)
                param(2) = New SqlParameter("@JobNo", SqlDbType.NVarChar, 40)
                param(3) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 24)
                param(4) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@ReturnType", SqlDbType.NVarChar, 2)
                param(6) = New SqlParameter("@ConsigneeCode", SqlDbType.NVarChar, 20)
                param(7) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar, 100)
                param(8) = New SqlParameter("@ConsigneeAddress1", SqlDbType.NVarChar, 90)
                param(9) = New SqlParameter("@ConsigneeContactPerson", SqlDbType.NVarChar, 100)
                param(10) = New SqlParameter("@ConsigneeContactNo", SqlDbType.NVarChar, 100)
                param(11) = New SqlParameter("@DepotCode", SqlDbType.NVarChar, 20)
                param(12) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar, 10)
                param(13) = New SqlParameter("@DetentionCode", SqlDbType.NVarChar, 10)
                param(14) = New SqlParameter("@DetentionFreeDay", SqlDbType.Int)
                param(15) = New SqlParameter("@DetentionStartDate", SqlDbType.DateTime)
                param(16) = New SqlParameter("@InstructionToDepot", SqlDbType.NVarChar, 2000)
                param(17) = New SqlParameter("@TruckerCode", SqlDbType.NVarChar, 20)
                param(18) = New SqlParameter("@TruckerName", SqlDbType.NVarChar, 100)
                param(19) = New SqlParameter("@CompleteDate", SqlDbType.DateTime)
                param(20) = New SqlParameter("@TruckerRefNo", SqlDbType.NVarChar, 100)
                param(21) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(22) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 100)
                param(23) = New SqlParameter("@ConsigneeAddress2", SqlDbType.NVarChar, 90)
                param(24) = New SqlParameter("@ConsigneeAddress3", SqlDbType.NVarChar, 90)
                param(25) = New SqlParameter("@ConsigneeAddress4", SqlDbType.NVarChar, 90)
                param(26) = New SqlParameter("@DemurrageFreeDay", SqlDbType.Int)
                param(27) = New SqlParameter("@DemurrageStartDate", SqlDbType.DateTime)
                param(28) = New SqlParameter("@UserNo", SqlDbType.NVarChar, 50)
                param(29) = New SqlParameter("@RefNo", SqlDbType.NVarChar, 50)

                param(0).Value = propSO.OrganisationCode
                param(1).Value = propSO.DemurrageCode
                param(2).Value = propSO.JobNo
                param(3).Value = propSO.VoyageNo
                param(4).Value = propSO.EtaDate
                param(5).Value = propSO.ReturnType
                param(6).Value = propSO.ConsigneeCode
                param(7).Value = propSO.ConsigneeName
                param(8).Value = propSO.ConsigneeAddress1
                param(9).Value = propSO.ConsigneeContactPerson
                param(10).Value = propSO.ConsigneeContactNo
                param(11).Value = propSO.DepotCode
                param(12).Value = propSO.PortOfLoadingCode
                param(13).Value = propSO.DetentionCode
                param(14).Value = propSO.DetentionFreeDay
                param(15).Value = propSO.DetentionStartDate
                param(16).Value = propSO.InstructionToDepot
                param(17).Value = propSO.TruckerCode
                param(18).Value = propSO.TruckerName
                param(19).Value = propSO.CompleteDate
                param(20).Value = propSO.TruckerRefNo
                param(21).Value = propSO.TrxNo
                param(22).Value = propSO.VesselName
                param(23).Value = propSO.ConsigneeAddress2
                param(24).Value = propSO.ConsigneeAddress3
                param(25).Value = propSO.ConsigneeAddress4
                param(26).Value = propSO.DemurrageFreeDay
                param(27).Value = propSO.DemurrageStartDate
                param(28).Value = propSO.UserNo
                param(29).Value = propSO.RefNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_ctso1", param)
                If intResult > 0 Then
                    masterId = propSO.TrxNo
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function DeleteRI(ByVal propSO As clsPropSO, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propSO.TrxNo
                param(1) = New SqlParameter("@msg", SqlDbType.NVarChar, 400)
                param(1).Direction = ParameterDirection.Output

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_ctso1", param)
                If intResult > 0 Then
                    Return True
                Else
                    strMsg = param(1).Value.ToString
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctso1_List", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctso1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 33 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropSO
                If tmpId < 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.TrxNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.OrganisationCode = strRow(1)
                tmpProp.DemurrageCode = strRow(2)
                tmpProp.JobNo = strRow(3)
                tmpProp.VesselName = strRow(4)
                tmpProp.VoyageNo = strRow(5)
                tmpProp.EtaDate = GeneralFun.StringToDate(strRow(6))
                tmpProp.ReturnType = strRow(7)
                tmpProp.ReturnOriginCode = strRow(8)
                tmpProp.ConsigneeCode = strRow(9)
                tmpProp.ConsigneeName = strRow(10)
                tmpProp.ConsigneeAddress1 = strRow(11)
                tmpProp.ConsigneeContactPerson = strRow(12)
                tmpProp.ConsigneeContactNo = strRow(13)
                tmpProp.DepotCode = strRow(14)
                tmpProp.PortOfLoadingCode = strRow(15)
                tmpProp.DetentionCode = strRow(16)
                tmpProp.DetentionStartDate = GeneralFun.StringToDate(strRow(17))
                tmpProp.DetentionFreeDay = GeneralFun.StringToInt(strRow(18))
                tmpProp.DemurrageStartDate = GeneralFun.StringToDate(strRow(19))
                tmpProp.DemurrageFreeDay = GeneralFun.StringToInt(strRow(20))
                tmpProp.InstructionToDepot = strRow(21)
                tmpProp.TruckerCode = strRow(22)
                tmpProp.TruckerName = strRow(23)
                tmpProp.CompleteDate = GeneralFun.StringToDate(strRow(24))
                tmpProp.TruckerRefNo = strRow(25)
                tmpProp.StoringOrderNo = strRow(26)
                tmpProp.ConsigneeAddress2 = strRow(27)
                tmpProp.ConsigneeAddress3 = strRow(28)
                tmpProp.ConsigneeAddress4 = strRow(29)
                tmpProp.SiteCode = strRow(30)
                tmpProp.UserNo = strRow(31)
                tmpProp.RefNo = strRow(32)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropSO = CType(CurrentProp, clsPropSO)
            blnReturn = InsertSO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropSO = CType(CurrentProp, clsPropSO)
            blnReturn = UpdateSO(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropSO = CType(CurrentProp, clsPropSO)
            blnReturn = DeleteRI(tmpProp, conn, trans, 1, strMsg)
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

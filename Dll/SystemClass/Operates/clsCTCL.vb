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

#Region " Class Collection of ctcl Info "

    <Serializable()> _
    Public Class colctcl
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropctcl(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of ctcl Info "

    <Serializable()> _
    Public Class clsctcl
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
            colProp = New colctcl()
            Title = "Releasing Instruction"
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
            colProp = New colctcl()
            Title = "Releasing Instruction"
        End Sub
        Private Function Insertctcl(ByRef propctcl As clsPropctcl, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(27) As SqlParameter
                param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@EquipmentType", SqlDbType.NVarChar)
                param(2) = New SqlParameter("@SiteCode", SqlDbType.NVarChar)
                param(3) = New SqlParameter("@EventPortCode", SqlDbType.NVarChar)
                param(4) = New SqlParameter("@EventDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@State", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@EventCode", SqlDbType.NVarChar)
                param(7) = New SqlParameter("@JobNo", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@ShipperCode", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ShipperName", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar)
                param(11) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar)
                param(12) = New SqlParameter("@VesselName", SqlDbType.NVarChar)
                param(13) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@ConsigneeCode", SqlDbType.NVarChar)
                param(15) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@DepotCode", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@TruckerName", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@VehicleNo", SqlDbType.NVarChar)
                param(19) = New SqlParameter("@SealNo", SqlDbType.NVarChar)
                param(20) = New SqlParameter("@DGFlag", SqlDbType.NVarChar)
                param(21) = New SqlParameter("@DriverPassNo", SqlDbType.NVarChar)
                param(22) = New SqlParameter("@ActualDetentionCharge", SqlDbType.Decimal)
                param(23) = New SqlParameter("@ComputedDetentionCharge", SqlDbType.Decimal)
                param(24) = New SqlParameter("@SurveyRemarks", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@TrxNO", SqlDbType.Int)
                param(26).Direction = ParameterDirection.Output
                param(27) = New SqlParameter("@CreateBy", SqlDbType.NVarChar)

                param(0).Value = propctcl.ContainerNo
                param(1).Value = propctcl.EquipmentType
                param(2).Value = propctcl.SiteCode
                param(3).Value = propctcl.EventPortCode
                param(4).Value = propctcl.EventDate
                param(5).Value = propctcl.State
                param(6).Value = propctcl.EventCode
                param(7).Value = propctcl.JobNo
                param(8).Value = propctcl.ShipperCode
                param(9).Value = propctcl.ShipperName
                param(10).Value = propctcl.PortOfLoadingCode
                param(11).Value = propctcl.PortOfDischargeCode
                param(12).Value = propctcl.VesselName
                param(13).Value = propctcl.VoyageNo
                param(14).Value = propctcl.ConsigneeCode
                param(15).Value = propctcl.ConsigneeName
                param(16).Value = propctcl.DepotCode
                param(17).Value = propctcl.TruckerName
                param(18).Value = propctcl.VehicleNo
                param(19).Value = propctcl.SealNo
                param(20).Value = propctcl.DGFlag
                param(21).Value = propctcl.DriverPassNo
                param(22).Value = propctcl.ActualDetentionCharge
                param(23).Value = propctcl.ComputedDetentionCharge
                param(24).Value = propctcl.SurveyRemarks
                param(25).Value = propctcl.Remarks
                'param(26).Value = propctcl.TrxNo
                param(27).Value = propctcl.CreateBy

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_ctcl1", param)
                If intResult > 0 Then
                    propctcl.TrxNo = Int64.Parse(param(26).Value.ToString())
                    masterId = Int64.Parse(param(26).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function Updatectcl(ByVal propctcl As clsPropctcl, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(27) As SqlParameter
                param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@EquipmentType", SqlDbType.NVarChar)
                param(2) = New SqlParameter("@SiteCode", SqlDbType.NVarChar)
                param(3) = New SqlParameter("@EventPortCode", SqlDbType.NVarChar)
                param(4) = New SqlParameter("@EventDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@State", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@EventCode", SqlDbType.NVarChar)
                param(7) = New SqlParameter("@JobNo", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@ShipperCode", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ShipperName", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar)
                param(11) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar)
                param(12) = New SqlParameter("@VesselName", SqlDbType.NVarChar)
                param(13) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@ConsigneeCode", SqlDbType.NVarChar)
                param(15) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@DepotCode", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@TruckerName", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@VehicleNo", SqlDbType.NVarChar)
                param(19) = New SqlParameter("@SealNo", SqlDbType.NVarChar)
                param(20) = New SqlParameter("@DGFlag", SqlDbType.NVarChar)
                param(21) = New SqlParameter("@DriverPassNo", SqlDbType.NVarChar)
                param(22) = New SqlParameter("@ActualDetentionCharge", SqlDbType.Decimal)
                param(23) = New SqlParameter("@ComputedDetentionCharge", SqlDbType.Decimal)
                param(24) = New SqlParameter("@SurveyRemarks", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@TrxNO", SqlDbType.Int)
                param(27) = New SqlParameter("@UpdateBy", SqlDbType.NVarChar)

                param(0).Value = propctcl.ContainerNo
                param(1).Value = propctcl.EquipmentType
                param(2).Value = propctcl.SiteCode
                param(3).Value = propctcl.EventPortCode
                param(4).Value = propctcl.EventDate
                param(5).Value = propctcl.State
                param(6).Value = propctcl.EventCode
                param(7).Value = propctcl.JobNo
                param(8).Value = propctcl.ShipperCode
                param(9).Value = propctcl.ShipperName
                param(10).Value = propctcl.PortOfLoadingCode
                param(11).Value = propctcl.PortOfDischargeCode
                param(12).Value = propctcl.VesselName
                param(13).Value = propctcl.VoyageNo
                param(14).Value = propctcl.ConsigneeCode
                param(15).Value = propctcl.ConsigneeName
                param(16).Value = propctcl.DepotCode
                param(17).Value = propctcl.TruckerName
                param(18).Value = propctcl.VehicleNo
                param(19).Value = propctcl.SealNo
                param(20).Value = propctcl.DGFlag
                param(21).Value = propctcl.DriverPassNo
                param(22).Value = propctcl.ActualDetentionCharge
                param(23).Value = propctcl.ComputedDetentionCharge
                param(24).Value = propctcl.SurveyRemarks
                param(25).Value = propctcl.Remarks
                param(26).Value = propctcl.TrxNo
                param(27).Value = propctcl.UpdateBy

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_ctcl1", param)
                If intResult > 0 Then
                    masterId = propctcl.TrxNo
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Private Function Deletectcl(ByVal propctcl As clsPropctcl, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propctcl.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_ctcl1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_List", param)
                If PageSize = 0 Then
                    'Total Page Count
                    PageCount = 1
                    'Total Record Count
                    RecordCount = ds.Tables(0).Rows.Count
                    dt = VaildataTable(ds.Tables(0))
                Else
                    'Total Page Count
                    PageCount = Integer.Parse(param(6).Value.ToString())
                    'Total Record Count
                    RecordCount = Integer.Parse(param(7).Value.ToString())
                    dt = VaildataTable(ds.Tables(1))
                End If
                Return dt
            Catch
                Return New DataTable()
            End Try
        End Function
        Private Function VaildataTable(ByRef dt As DataTable) As DataTable
            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    Dim ContainerNo As String = ""
                    Dim State As String = ""
                    Dim NewState As String = ""
                    'Dim ds As DataSet
                    'For i As Integer = 0 To dt.Rows.Count - 1
                    '    ContainerNo = dt.Rows(i)("ContainerNo")
                    '    State = dt.Rows(i)("State")
                    '    Dim param(1) As SqlParameter
                    '    Try
                    '        param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar, 13)
                    '        param(1) = New SqlParameter("@State", SqlDbType.NVarChar, 3)
                    '        param(1).Direction = ParameterDirection.Output
                    '        param(0).Value = ContainerNo
                    '        param(1).Value = NewState
                    '        ds = SqlHelper.ExecuteDataset(ConDbConn.ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_check", param)
                    '    Catch ex As Exception
                    '    End Try
                    '    NewState = param(1).Value.ToString
                    '    Select Case State
                    '        Case "GTO" 'Depot In
                    '            If NewState <> "GTO" Then
                    '                dt.Rows.RemoveAt(i)
                    '            End If
                    '        Case "BXD" 'GateOut
                    '            If NewState <> "BXD" Then
                    '                dt.Rows.RemoveAt(i)
                    '            End If
                    '        Case "BXL" 'Box Discharge
                    '            If NewState <> "BXL" Then
                    '                dt.Rows.RemoveAt(i)
                    '            End If
                    '        Case "GTI" 'Box Load
                    '            If NewState <> "GTI" Then
                    '                dt.Rows.RemoveAt(i)
                    '            End If
                    '        Case "DPO" 'Box Load
                    '            If NewState <> "DPO" Then
                    '                dt.Rows.RemoveAt(i)
                    '            End If
                    '    End Select
                    'Next
                End If
            End If
            Return dt
        End Function
        Public Overrides Function GetDetail(ByVal intId As Long) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(0).Value = intId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_Detail", param)
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
                Dim tmpProp As clsPropctcl
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
                tmpProp.ContainerNo = strRow(1)
                tmpProp.EquipmentType = strRow(2)
                tmpProp.SiteCode = strRow(3)
                tmpProp.EventPortCode = strRow(4)
                tmpProp.EventCode = strRow(5)
                tmpProp.State = strRow(6)
                tmpProp.EventDate = GeneralFun.StringToDate(strRow(7))
                tmpProp.JobNo = strRow(8)
                tmpProp.ShipperCode = strRow(9)
                tmpProp.ShipperName = strRow(10)
                tmpProp.PortOfLoadingCode = strRow(11)
                tmpProp.PortOfDischargeCode = strRow(12)
                tmpProp.VesselName = strRow(13)
                tmpProp.VoyageNo = strRow(14)
                tmpProp.ConsigneeCode = strRow(15)
                tmpProp.ConsigneeName = strRow(16)
                tmpProp.DepotCode = strRow(17)
                tmpProp.TruckerName = strRow(18)
                tmpProp.VehicleNo = strRow(19)
                tmpProp.SealNo = strRow(20)
                tmpProp.DGFlag = strRow(21)
                tmpProp.DriverPassNo = strRow(22)
                tmpProp.ActualDetentionCharge = GeneralFun.StringToDecimal(strRow(23))
                tmpProp.ComputedDetentionCharge = GeneralFun.StringToDecimal(strRow(24))
                tmpProp.SurveyRemarks = strRow(25)
                tmpProp.Remarks = strRow(26)
                tmpProp.UpdateBy = strRow(27)
                tmpProp.CreateBy = strRow(27)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropctcl = CType(CurrentProp, clsPropctcl)
            blnReturn = Insertctcl(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropctcl = CType(CurrentProp, clsPropctcl)
            blnReturn = Updatectcl(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropctcl = CType(CurrentProp, clsPropctcl)
            blnReturn = Deletectcl(tmpProp, conn, trans, 1, strMsg)
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
#Region " Class Server of ctcl Info "

    <Serializable()> _
    Public Class clsCtcl_Rccf
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
            colProp = New colctcl()
            Title = "Container Event Log"
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
            colProp = New colctcl()
            Title = "Container Event Log"
        End Sub

        Private Function Insertctcl(ByRef propctcl As clsPropctcl, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(27) As SqlParameter
                param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@EquipmentType", SqlDbType.NVarChar)
                param(2) = New SqlParameter("@SiteCode", SqlDbType.NVarChar)
                param(3) = New SqlParameter("@EventPortCode", SqlDbType.NVarChar)
                param(4) = New SqlParameter("@EventDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@State", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@EventCode", SqlDbType.NVarChar)
                param(7) = New SqlParameter("@JobNo", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@ShipperCode", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ShipperName", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar)
                param(11) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar)
                param(12) = New SqlParameter("@VesselName", SqlDbType.NVarChar)
                param(13) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@ConsigneeCode", SqlDbType.NVarChar)
                param(15) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@DepotCode", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@TruckerName", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@VehicleNo", SqlDbType.NVarChar)
                param(19) = New SqlParameter("@SealNo", SqlDbType.NVarChar)
                param(20) = New SqlParameter("@DGFlag", SqlDbType.NVarChar)
                param(21) = New SqlParameter("@DriverPassNo", SqlDbType.NVarChar)
                param(22) = New SqlParameter("@ActualDetentionCharge", SqlDbType.Decimal)
                param(23) = New SqlParameter("@ComputedDetentionCharge", SqlDbType.Decimal)
                param(24) = New SqlParameter("@SurveyRemarks", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@TrxNO", SqlDbType.Int)
                param(26).Direction = ParameterDirection.Output
                param(27) = New SqlParameter("@CreateBy", SqlDbType.NVarChar)

                param(0).Value = propctcl.ContainerNo
                param(1).Value = propctcl.EquipmentType
                param(2).Value = propctcl.SiteCode
                param(3).Value = propctcl.EventPortCode
                param(4).Value = propctcl.EventDate
                param(5).Value = propctcl.State
                param(6).Value = propctcl.EventCode
                param(7).Value = propctcl.JobNo
                param(8).Value = propctcl.ShipperCode
                param(9).Value = propctcl.ShipperName
                param(10).Value = propctcl.PortOfLoadingCode
                param(11).Value = propctcl.PortOfDischargeCode
                param(12).Value = propctcl.VesselName
                param(13).Value = propctcl.VoyageNo
                param(14).Value = propctcl.ConsigneeCode
                param(15).Value = propctcl.ConsigneeName
                param(16).Value = propctcl.DepotCode
                param(17).Value = propctcl.TruckerName
                param(18).Value = propctcl.VehicleNo
                param(19).Value = propctcl.SealNo
                param(20).Value = propctcl.DGFlag
                param(21).Value = propctcl.DriverPassNo
                param(22).Value = propctcl.ActualDetentionCharge
                param(23).Value = propctcl.ComputedDetentionCharge
                param(24).Value = propctcl.SurveyRemarks
                param(25).Value = propctcl.Remarks
                'param(26).Value = propctcl.TrxNo
                param(27).Value = propctcl.CreateBy

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_ctcl1", param)
                If intResult > 0 Then
                    propctcl.TrxNo = Int64.Parse(param(26).Value.ToString())
                    masterId = Int64.Parse(param(26).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function Updatectcl(ByVal propctcl As clsPropctcl, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(27) As SqlParameter
                param(0) = New SqlParameter("@ContainerNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@EquipmentType", SqlDbType.NVarChar)
                param(2) = New SqlParameter("@SiteCode", SqlDbType.NVarChar)
                param(3) = New SqlParameter("@EventPortCode", SqlDbType.NVarChar)
                param(4) = New SqlParameter("@EventDate", SqlDbType.DateTime)
                param(5) = New SqlParameter("@State", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@EventCode", SqlDbType.NVarChar)
                param(7) = New SqlParameter("@JobNo", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@ShipperCode", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ShipperName", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar)
                param(11) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar)
                param(12) = New SqlParameter("@VesselName", SqlDbType.NVarChar)
                param(13) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@ConsigneeCode", SqlDbType.NVarChar)
                param(15) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@DepotCode", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@TruckerName", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@VehicleNo", SqlDbType.NVarChar)
                param(19) = New SqlParameter("@SealNo", SqlDbType.NVarChar)
                param(20) = New SqlParameter("@DGFlag", SqlDbType.NVarChar)
                param(21) = New SqlParameter("@DriverPassNo", SqlDbType.NVarChar)
                param(22) = New SqlParameter("@ActualDetentionCharge", SqlDbType.Decimal)
                param(23) = New SqlParameter("@ComputedDetentionCharge", SqlDbType.Decimal)
                param(24) = New SqlParameter("@SurveyRemarks", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@Remarks", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@TrxNO", SqlDbType.Int)
                param(27) = New SqlParameter("@UpdateBy", SqlDbType.NVarChar)

                param(0).Value = propctcl.ContainerNo
                param(1).Value = propctcl.EquipmentType
                param(2).Value = propctcl.SiteCode
                param(3).Value = propctcl.EventPortCode
                param(4).Value = propctcl.EventDate
                param(5).Value = propctcl.State
                param(6).Value = propctcl.EventCode
                param(7).Value = propctcl.JobNo
                param(8).Value = propctcl.ShipperCode
                param(9).Value = propctcl.ShipperName
                param(10).Value = propctcl.PortOfLoadingCode
                param(11).Value = propctcl.PortOfDischargeCode
                param(12).Value = propctcl.VesselName
                param(13).Value = propctcl.VoyageNo
                param(14).Value = propctcl.ConsigneeCode
                param(15).Value = propctcl.ConsigneeName
                param(16).Value = propctcl.DepotCode
                param(17).Value = propctcl.TruckerName
                param(18).Value = propctcl.VehicleNo
                param(19).Value = propctcl.SealNo
                param(20).Value = propctcl.DGFlag
                param(21).Value = propctcl.DriverPassNo
                param(22).Value = propctcl.ActualDetentionCharge
                param(23).Value = propctcl.ComputedDetentionCharge
                param(24).Value = propctcl.SurveyRemarks
                param(25).Value = propctcl.Remarks
                param(26).Value = propctcl.TrxNo
                param(27).Value = propctcl.UpdateBy

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_ctcl1", param)
                If intResult > 0 Then
                    masterId = propctcl.TrxNo
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Private Function Deletectcl(ByVal propctcl As clsPropctcl, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propctcl.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_ctcl1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_ContainerEventLog_List", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_ctcl1_Detail", param)
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
                Dim tmpProp As clsPropctcl
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
                tmpProp.ContainerNo = strRow(1)
                tmpProp.EquipmentType = strRow(2)
                tmpProp.SiteCode = strRow(3)
                tmpProp.EventPortCode = strRow(4)
                tmpProp.EventCode = strRow(5)
                tmpProp.State = strRow(6)
                tmpProp.EventDate = GeneralFun.StringToDate(strRow(7))
                tmpProp.JobNo = strRow(8)
                tmpProp.ShipperCode = strRow(9)
                tmpProp.ShipperName = strRow(10)
                tmpProp.PortOfLoadingCode = strRow(11)
                tmpProp.PortOfDischargeCode = strRow(12)
                tmpProp.VesselName = strRow(13)
                tmpProp.VoyageNo = strRow(14)
                tmpProp.ConsigneeCode = strRow(15)
                tmpProp.ConsigneeName = strRow(16)
                tmpProp.DepotCode = strRow(17)
                tmpProp.TruckerName = strRow(18)
                tmpProp.VehicleNo = strRow(19)
                tmpProp.SealNo = strRow(20)
                tmpProp.DGFlag = strRow(21)
                tmpProp.DriverPassNo = strRow(22)
                tmpProp.ActualDetentionCharge = GeneralFun.StringToDecimal(strRow(23))
                tmpProp.ComputedDetentionCharge = GeneralFun.StringToDecimal(strRow(24))
                tmpProp.SurveyRemarks = strRow(25)
                tmpProp.Remarks = strRow(26)
                tmpProp.UpdateBy = strRow(27)
                tmpProp.CreateBy = strRow(27)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropctcl = CType(CurrentProp, clsPropctcl)
            blnReturn = Insertctcl(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropctcl = CType(CurrentProp, clsPropctcl)
            blnReturn = Updatectcl(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropctcl = CType(CurrentProp, clsPropctcl)
            blnReturn = Deletectcl(tmpProp, conn, trans, 1, strMsg)
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
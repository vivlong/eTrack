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

#Region " Class Collection of Matra Info "

    <Serializable()> _
    Public Class colMatra
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            'Return New clsPropMatra(ConClass.NewIdValue.ToString)
            Return New clsPropMatra("")
        End Function
    End Class
#End Region

#Region " Class Server of Matra Info "

    <Serializable()> _
    Public Class clsMatra
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
            colProp = New colMatra()
            Title = "Matra"
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
            colProp = New colMatra()
            Title = "Matra"
        End Sub


        Private Function InsertMatra(ByRef propMatra As clsPropMatra, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(39) As SqlParameter
                param(0) = New SqlParameter("@ChargeWeight", SqlDbType.Decimal, 9)
                param(0).Value = propMatra.ChargeWeight
                param(1) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 100)
                param(1).Value = propMatra.CommodityDescription
                param(2) = New SqlParameter("@ConsignNoteRefNo", SqlDbType.NVarChar, 50)
                param(2).Value = propMatra.ConsignNoteRefNo
                param(3) = New SqlParameter("@DestName", SqlDbType.NVarChar, 50)
                param(3).Value = propMatra.DestName
                param(4) = New SqlParameter("@Eta", SqlDbType.DateTime)
                param(4).Value = propMatra.Eta
                param(5) = New SqlParameter("@Etd", SqlDbType.DateTime)
                param(5).Value = propMatra.Etd
                param(6) = New SqlParameter("@FlightOrVoyageNo", SqlDbType.NVarChar, 20)
                param(6).Value = propMatra.FlightOrVoyageNo
                param(7) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 9)
                param(7).Value = propMatra.GrossWeight
                param(8) = New SqlParameter("@HawbHblNo", SqlDbType.NVarChar, 20)
                param(8).Value = propMatra.HawbHblNo
                param(9) = New SqlParameter("@LocalMtoCode", SqlDbType.NVarChar, 10)
                param(9).Value = propMatra.LocalMtoCode
                param(10) = New SqlParameter("@MawbOblNo", SqlDbType.NVarChar, 20)
                param(10).Value = propMatra.MawbOblNo
                param(11) = New SqlParameter("@Mro", SqlDbType.NVarChar, 10)
                param(11).Value = propMatra.Mro
                param(12) = New SqlParameter("@MtoNotificationDate", SqlDbType.DateTime)
                param(12).Value = propMatra.MtoNotificationDate
                param(13) = New SqlParameter("@MtoRep", SqlDbType.NVarChar, 10)
                param(13).Value = propMatra.MtoRep
                param(14) = New SqlParameter("@OriginName", SqlDbType.NVarChar, 50)
                param(14).Value = propMatra.OriginName
                param(15) = New SqlParameter("@PartNo", SqlDbType.NVarChar, 50)
                param(15).Value = propMatra.PartNo
                param(16) = New SqlParameter("@PickupDate", SqlDbType.DateTime)
                param(16).Value = propMatra.PickupDate
                param(17) = New SqlParameter("@PickupFrom", SqlDbType.NVarChar, 50)
                param(17).Value = propMatra.PickupFrom
                param(18) = New SqlParameter("@PlaceOfDelivery", SqlDbType.NVarChar, 50)
                param(18).Value = propMatra.PlaceOfDelivery
                param(19) = New SqlParameter("@PlaceOfDeliveryEta", SqlDbType.DateTime)
                param(19).Value = propMatra.PlaceOfDeliveryEta
                param(20) = New SqlParameter("@Qty", SqlDbType.Int)
                param(20).Value = propMatra.Qty
                param(21) = New SqlParameter("@RfqNo", SqlDbType.NVarChar, 50)
                param(21).Value = propMatra.RfqNo
                param(22) = New SqlParameter("@SerialNo", SqlDbType.NVarChar, 50)
                param(22).Value = propMatra.SerialNo
                param(23) = New SqlParameter("@ShipDate", SqlDbType.DateTime)
                param(23).Value = propMatra.ShipDate
                param(24) = New SqlParameter("@ShipTo", SqlDbType.NVarChar, 50)
                param(24).Value = propMatra.ShipTo
                param(25) = New SqlParameter("@Status", SqlDbType.NVarChar, 15)
                param(25).Value = propMatra.Status
                param(26) = New SqlParameter("@UomCode", SqlDbType.NVarChar, 3)
                param(26).Value = propMatra.UomCode

                param(27) = New SqlParameter("@ConsignmentDate", SqlDbType.DateTime)
                param(27).Value = propMatra.ConsignmentDate
                param(28) = New SqlParameter("@DateDeliveredToMro", SqlDbType.DateTime)
                param(28).Value = propMatra.DateDeliveredToMro
                param(29) = New SqlParameter("@DateDeliveredToMtoRep", SqlDbType.DateTime)
                param(29).Value = propMatra.DateDeliveredToMtoRep
                param(30) = New SqlParameter("@DateReceivedFromMto", SqlDbType.DateTime)
                param(30).Value = propMatra.DateReceivedFromMto
                param(31) = New SqlParameter("@DateReceivedFromMtoRep", SqlDbType.DateTime)
                param(31).Value = propMatra.DateReceivedFromMtoRep
                param(32) = New SqlParameter("@Driveric1", SqlDbType.NVarChar, 50)
                param(32).Value = propMatra.Driveric1
                param(33) = New SqlParameter("@Driveric2", SqlDbType.NVarChar, 50)
                param(33).Value = propMatra.Driveric2
                param(34) = New SqlParameter("@Driveric3", SqlDbType.NVarChar, 50)
                param(34).Value = propMatra.Driveric3
                param(35) = New SqlParameter("@DriverName1", SqlDbType.NVarChar, 50)
                param(35).Value = propMatra.DriverName1
                param(36) = New SqlParameter("@DriverName2", SqlDbType.NVarChar, 50)
                param(36).Value = propMatra.DriverName2
                param(37) = New SqlParameter("@DriverName3", SqlDbType.NVarChar, 50)
                param(37).Value = propMatra.DriverName3
                param(38) = New SqlParameter("@QuotationRefNo", SqlDbType.NVarChar, 50)
                param(38).Value = propMatra.QuotationRefNo
                param(39) = New SqlParameter("@TearDownInspectionDate", SqlDbType.DateTime)
                param(39).Value = propMatra.TearDownInspectionDate

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Jmar1", param)
                If intResult > 0 Then
                    propMatra.RfqNo = propMatra.RfqNo.ToString()
                    masterId = propMatra.RfqNo.ToString()
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateMatra(ByVal propMatra As clsPropMatra, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(39) As SqlParameter
                param(0) = New SqlParameter("@ChargeWeight", SqlDbType.Decimal, 9)
                param(0).Value = propMatra.ChargeWeight
                param(1) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 100)
                param(1).Value = propMatra.CommodityDescription
                param(2) = New SqlParameter("@ConsignNoteRefNo", SqlDbType.NVarChar, 50)
                param(2).Value = propMatra.ConsignNoteRefNo
                param(3) = New SqlParameter("@DestName", SqlDbType.NVarChar, 50)
                param(3).Value = propMatra.DestName
                param(4) = New SqlParameter("@Eta", SqlDbType.DateTime)
                param(4).Value = propMatra.Eta
                param(5) = New SqlParameter("@Etd", SqlDbType.DateTime)
                param(5).Value = propMatra.Etd
                param(6) = New SqlParameter("@FlightOrVoyageNo", SqlDbType.NVarChar, 20)
                param(6).Value = propMatra.FlightOrVoyageNo
                param(7) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 9)
                param(7).Value = propMatra.GrossWeight
                param(8) = New SqlParameter("@HawbHblNo", SqlDbType.NVarChar, 20)
                param(8).Value = propMatra.HawbHblNo
                param(9) = New SqlParameter("@LocalMtoCode", SqlDbType.NVarChar, 10)
                param(9).Value = propMatra.LocalMtoCode
                param(10) = New SqlParameter("@MawbOblNo", SqlDbType.NVarChar, 20)
                param(10).Value = propMatra.MawbOblNo
                param(11) = New SqlParameter("@Mro", SqlDbType.NVarChar, 10)
                param(11).Value = propMatra.Mro
                param(12) = New SqlParameter("@MtoNotificationDate", SqlDbType.DateTime)
                param(12).Value = propMatra.MtoNotificationDate
                param(13) = New SqlParameter("@MtoRep", SqlDbType.NVarChar, 10)
                param(13).Value = propMatra.MtoRep
                param(14) = New SqlParameter("@OriginName", SqlDbType.NVarChar, 50)
                param(14).Value = propMatra.OriginName
                param(15) = New SqlParameter("@PartNo", SqlDbType.NVarChar, 50)
                param(15).Value = propMatra.PartNo
                param(16) = New SqlParameter("@PickupDate", SqlDbType.DateTime)
                param(16).Value = propMatra.PickupDate
                param(17) = New SqlParameter("@PickupFrom", SqlDbType.NVarChar, 50)
                param(17).Value = propMatra.PickupFrom
                param(18) = New SqlParameter("@PlaceOfDelivery", SqlDbType.NVarChar, 50)
                param(18).Value = propMatra.PlaceOfDelivery
                param(19) = New SqlParameter("@PlaceOfDeliveryEta", SqlDbType.DateTime)
                param(19).Value = propMatra.PlaceOfDeliveryEta
                param(20) = New SqlParameter("@Qty", SqlDbType.Int)
                param(20).Value = propMatra.Qty
                param(21) = New SqlParameter("@RfqNo", SqlDbType.NVarChar, 50)
                param(21).Value = propMatra.RfqNo
                param(22) = New SqlParameter("@SerialNo", SqlDbType.NVarChar, 50)
                param(22).Value = propMatra.SerialNo
                param(23) = New SqlParameter("@ShipDate", SqlDbType.DateTime)
                param(23).Value = propMatra.ShipDate
                param(24) = New SqlParameter("@ShipTo", SqlDbType.NVarChar, 50)
                param(24).Value = propMatra.ShipTo
                param(25) = New SqlParameter("@Status", SqlDbType.NVarChar, 15)
                param(25).Value = propMatra.Status
                param(26) = New SqlParameter("@UomCode", SqlDbType.NVarChar, 3)
                param(26).Value = propMatra.UomCode

                param(27) = New SqlParameter("@ConsignmentDate", SqlDbType.DateTime)
                param(27).Value = propMatra.ConsignmentDate
                param(28) = New SqlParameter("@DateDeliveredToMro", SqlDbType.DateTime)
                param(28).Value = propMatra.DateDeliveredToMro
                param(29) = New SqlParameter("@DateDeliveredToMtoRep", SqlDbType.DateTime)
                param(29).Value = propMatra.DateDeliveredToMtoRep
                param(30) = New SqlParameter("@DateReceivedFromMto", SqlDbType.DateTime)
                param(30).Value = propMatra.DateReceivedFromMto
                param(31) = New SqlParameter("@DateReceivedFromMtoRep", SqlDbType.DateTime)
                param(31).Value = propMatra.DateReceivedFromMtoRep
                param(32) = New SqlParameter("@Driveric1", SqlDbType.NVarChar, 50)
                param(32).Value = propMatra.Driveric1
                param(33) = New SqlParameter("@Driveric2", SqlDbType.NVarChar, 50)
                param(33).Value = propMatra.Driveric2
                param(34) = New SqlParameter("@Driveric3", SqlDbType.NVarChar, 50)
                param(34).Value = propMatra.Driveric3
                param(35) = New SqlParameter("@DriverName1", SqlDbType.NVarChar, 50)
                param(35).Value = propMatra.DriverName1
                param(36) = New SqlParameter("@DriverName2", SqlDbType.NVarChar, 50)
                param(36).Value = propMatra.DriverName2
                param(37) = New SqlParameter("@DriverName3", SqlDbType.NVarChar, 50)
                param(37).Value = propMatra.DriverName3
                param(38) = New SqlParameter("@QuotationRefNo", SqlDbType.NVarChar, 50)
                param(38).Value = propMatra.QuotationRefNo
                param(39) = New SqlParameter("@TearDownInspectionDate", SqlDbType.DateTime)
                param(39).Value = propMatra.TearDownInspectionDate

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Jmar1", param)
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
        Private Function DeleteMatra(ByVal propMatra As clsPropMatra, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@RfqNo", SqlDbType.NVarChar, 50)
                param(0).Value = propMatra.RfqNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Jmar1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Jmar1_List", param)
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
            Return Nothing
        End Function

        Public Overrides Function GetDetail(ByVal strId As String) As clsProp
            Dim ds As DataSet
            Dim dt As DataTable
            Try
                Dim param(0) As SqlParameter
                param(0) = New SqlParameter("@RfqNo", SqlDbType.NVarChar, 50)
                param(0).Value = strId

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Jmar1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function

        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 41 Then
                Return False
            Else
                Dim tmpId As String = strRow(0).ToString()
                Dim tmpProp As clsPropMatra
                If Len(tmpId) = 0 Then
                    CurrentProp = colProp.NewOneProp()
                    tmpProp = CurrentProp
                    tmpProp.RfqNo = tmpId
                    State = EditState.Insert
                Else
                    tmpProp = GetDetail(tmpId)
                    State = EditState.Edit
                End If
                tmpProp.ChargeWeight = GeneralFun.StringToDecimal(strRow(1))
                tmpProp.CommodityDescription = strRow(2)
                tmpProp.ConsignNoteRefNo = strRow(3)
                tmpProp.DestName = strRow(4)
                tmpProp.Eta = GeneralFun.StringToDate(strRow(5))
                tmpProp.Etd = GeneralFun.StringToDate(strRow(6))
                tmpProp.FlightOrVoyageNo = strRow(7)
                tmpProp.GrossWeight = GeneralFun.StringToDecimal(strRow(8))
                tmpProp.HawbHblNo = strRow(9)
                tmpProp.LocalMtoCode = strRow(10)
                tmpProp.MawbOblNo = strRow(11)
                tmpProp.Mro = strRow(12)
                tmpProp.MtoNotificationDate = GeneralFun.StringToDate(strRow(13))
                tmpProp.MtoRep = strRow(14)
                tmpProp.OriginName = strRow(15)
                tmpProp.PartNo = strRow(16)
                tmpProp.PickupDate = GeneralFun.StringToDate(strRow(17))
                tmpProp.PickupFrom = strRow(18)
                tmpProp.PlaceOfDelivery = strRow(19)
                tmpProp.PlaceOfDeliveryEta = GeneralFun.StringToDate(strRow(20))
                tmpProp.Qty = GeneralFun.StringToInt(strRow(21))
                tmpProp.RfqNo = strRow(22)
                tmpProp.SerialNo = strRow(23)
                tmpProp.ShipDate = GeneralFun.StringToDate(strRow(24))
                tmpProp.ShipTo = strRow(25)
                tmpProp.Status = strRow(26)
                tmpProp.UomCode = strRow(27)
                tmpProp.ConsignmentDate = GeneralFun.StringToDate(strRow(28))
                tmpProp.DateDeliveredToMro = GeneralFun.StringToDate(strRow(29))
                tmpProp.DateDeliveredToMtoRep = GeneralFun.StringToDate(strRow(30))
                tmpProp.DateReceivedFromMto = GeneralFun.StringToDate(strRow(31))
                tmpProp.DateReceivedFromMtoRep = GeneralFun.StringToDate(strRow(32))
                tmpProp.Driveric1 = strRow(33)
                tmpProp.Driveric2 = strRow(34)
                tmpProp.Driveric3 = strRow(35)
                tmpProp.DriverName1 = strRow(36)
                tmpProp.DriverName2 = strRow(37)
                tmpProp.DriverName3 = strRow(38)
                tmpProp.QuotationRefNo = strRow(39)
                tmpProp.TearDownInspectionDate = GeneralFun.StringToDate(strRow(40))
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropMatra = CType(CurrentProp, clsPropMatra)
            blnReturn = InsertMatra(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveSuccess, Title, tmpProp.RfqNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeySaveFailure, Title, tmpProp.RfqNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function UpdateData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropMatra = CType(CurrentProp, clsPropMatra)
            blnReturn = UpdateMatra(tmpProp, conn, trans, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateSuccess, Title, tmpProp.RfqNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyUpdateFailure, Title, tmpProp.RfqNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function DeleteData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropMatra = CType(CurrentProp, clsPropMatra)
            blnReturn = DeleteMatra(tmpProp, conn, trans, 1, strMsg)
            If blnReturn Then
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteSuccess, Title, tmpProp.RfqNo)
                End If
                Return True
            Else
                If strMsg = "" Then
                    strMsg = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.KeyDeleteFailure, Title, tmpProp.RfqNo)
                End If
                Return False
            End If
        End Function

        Protected Overrides Function IsCanSave(ByRef strMsg As String) As Boolean
            Return True
        End Function

        ' ''Public Function DoUpdate(ByVal propMatra As clsPropMatra) As Boolean
        ' ''    Dim param(26) As SqlParameter
        ' ''    param(0) = New SqlParameter("@ChargeWeight", SqlDbType.Decimal, 9)
        ' ''    param(0).Value = propMatra.ChargeWeight
        ' ''    param(1) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 100)
        ' ''    param(1).Value = propMatra.CommodityDescription
        ' ''    param(2) = New SqlParameter("@ConsignNoteRefNo", SqlDbType.NVarChar, 50)
        ' ''    param(2).Value = propMatra.ConsignNoteRefNo
        ' ''    param(3) = New SqlParameter("@DestName", SqlDbType.NVarChar, 50)
        ' ''    param(3).Value = propMatra.DestName
        ' ''    param(4) = New SqlParameter("@Eta", SqlDbType.DateTime)
        ' ''    param(4).Value = propMatra.Eta
        ' ''    param(5) = New SqlParameter("@Etd", SqlDbType.DateTime)
        ' ''    param(5).Value = propMatra.Etd
        ' ''    param(6) = New SqlParameter("@FlightOrVoyageNo", SqlDbType.NVarChar, 20)
        ' ''    param(6).Value = propMatra.FlightOrVoyageNo
        ' ''    param(7) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 9)
        ' ''    param(7).Value = propMatra.GrossWeight
        ' ''    param(8) = New SqlParameter("@HawbHblNo", SqlDbType.NVarChar, 20)
        ' ''    param(8).Value = propMatra.HawbHblNo
        ' ''    param(9) = New SqlParameter("@LocalMtoCode", SqlDbType.NVarChar, 10)
        ' ''    param(9).Value = propMatra.LocalMtoCode
        ' ''    param(10) = New SqlParameter("@MawbOblNo", SqlDbType.NVarChar, 20)
        ' ''    param(10).Value = propMatra.MawbOblNo
        ' ''    param(11) = New SqlParameter("@Mro", SqlDbType.NVarChar, 10)
        ' ''    param(11).Value = propMatra.Mro
        ' ''    param(12) = New SqlParameter("@MtoNotificationDate", SqlDbType.DateTime)
        ' ''    param(12).Value = propMatra.MtoNotificationDate
        ' ''    param(13) = New SqlParameter("@MtoRep", SqlDbType.NVarChar, 10)
        ' ''    param(13).Value = propMatra.MtoRep
        ' ''    param(14) = New SqlParameter("@OriginName", SqlDbType.NVarChar, 50)
        ' ''    param(14).Value = propMatra.OriginName
        ' ''    param(15) = New SqlParameter("@PartNo", SqlDbType.NVarChar, 50)
        ' ''    param(15).Value = propMatra.PartNo
        ' ''    param(16) = New SqlParameter("@PickupDate", SqlDbType.DateTime)
        ' ''    param(16).Value = propMatra.PickupDate
        ' ''    param(17) = New SqlParameter("@PickupFrom", SqlDbType.NVarChar, 50)
        ' ''    param(17).Value = propMatra.PickupFrom
        ' ''    param(18) = New SqlParameter("@PlaceOfDelivery", SqlDbType.NVarChar, 50)
        ' ''    param(18).Value = propMatra.PlaceOfDelivery
        ' ''    param(19) = New SqlParameter("@PlaceOfDeliveryEta", SqlDbType.DateTime)
        ' ''    param(19).Value = propMatra.PlaceOfDeliveryEta
        ' ''    param(20) = New SqlParameter("@Qty", SqlDbType.Int)
        ' ''    param(20).Value = propMatra.Qty
        ' ''    param(21) = New SqlParameter("@RfqNo", SqlDbType.NVarChar, 50)
        ' ''    param(21).Value = propMatra.RfqNo
        ' ''    param(22) = New SqlParameter("@SerialNo", SqlDbType.NVarChar, 50)
        ' ''    param(22).Value = propMatra.SerialNo
        ' ''    param(23) = New SqlParameter("@ShipDate", SqlDbType.DateTime)
        ' ''    param(23).Value = propMatra.ShipDate
        ' ''    param(24) = New SqlParameter("@ShipTo", SqlDbType.NVarChar, 50)
        ' ''    param(24).Value = propMatra.ShipTo
        ' ''    param(25) = New SqlParameter("@Status", SqlDbType.NVarChar, 15)
        ' ''    param(25).Value = propMatra.Status
        ' ''    param(26) = New SqlParameter("@UomCode", SqlDbType.NVarChar, 3)
        ' ''    param(26).Value = propMatra.UomCode

        ' ''    Try
        ' ''        Dim intResult As Integer
        ' ''        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spu_Jmar1", param)
        ' ''        param = Nothing
        ' ''        If intResult > 0 Then
        ' ''            Return True
        ' ''        Else
        ' ''            Return False
        ' ''        End If
        ' ''    Catch ex As Exception
        ' ''        Return False
        ' ''    End Try
        ' ''End Function

        ' ''Public Function DoInsert(ByRef propMatra As clsPropMatra) As Boolean
        ' ''    Try
        ' ''        Dim param(26) As SqlParameter
        ' ''        param(0) = New SqlParameter("@ChargeWeight", SqlDbType.Decimal, 9)
        ' ''        param(0).Value = propMatra.ChargeWeight
        ' ''        param(1) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 100)
        ' ''        param(1).Value = propMatra.CommodityDescription
        ' ''        param(2) = New SqlParameter("@ConsignNoteRefNo", SqlDbType.NVarChar, 50)
        ' ''        param(2).Value = propMatra.ConsignNoteRefNo
        ' ''        param(3) = New SqlParameter("@DestName", SqlDbType.NVarChar, 50)
        ' ''        param(3).Value = propMatra.DestName
        ' ''        param(4) = New SqlParameter("@Eta", SqlDbType.DateTime)
        ' ''        param(4).Value = propMatra.Eta
        ' ''        param(5) = New SqlParameter("@Etd", SqlDbType.DateTime)
        ' ''        param(5).Value = propMatra.Etd
        ' ''        param(6) = New SqlParameter("@FlightOrVoyageNo", SqlDbType.NVarChar, 20)
        ' ''        param(6).Value = propMatra.FlightOrVoyageNo
        ' ''        param(7) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 9)
        ' ''        param(7).Value = propMatra.GrossWeight
        ' ''        param(8) = New SqlParameter("@HawbHblNo", SqlDbType.NVarChar, 20)
        ' ''        param(8).Value = propMatra.HawbHblNo
        ' ''        param(9) = New SqlParameter("@LocalMtoCode", SqlDbType.NVarChar, 10)
        ' ''        param(9).Value = propMatra.LocalMtoCode
        ' ''        param(10) = New SqlParameter("@MawbOblNo", SqlDbType.NVarChar, 20)
        ' ''        param(10).Value = propMatra.MawbOblNo
        ' ''        param(11) = New SqlParameter("@Mro", SqlDbType.NVarChar, 10)
        ' ''        param(11).Value = propMatra.Mro
        ' ''        param(12) = New SqlParameter("@MtoNotificationDate", SqlDbType.DateTime)
        ' ''        param(12).Value = propMatra.MtoNotificationDate
        ' ''        param(13) = New SqlParameter("@MtoRep", SqlDbType.NVarChar, 10)
        ' ''        param(13).Value = propMatra.MtoRep
        ' ''        param(14) = New SqlParameter("@OriginName", SqlDbType.NVarChar, 50)
        ' ''        param(14).Value = propMatra.OriginName
        ' ''        param(15) = New SqlParameter("@PartNo", SqlDbType.NVarChar, 50)
        ' ''        param(15).Value = propMatra.PartNo
        ' ''        param(16) = New SqlParameter("@PickupDate", SqlDbType.DateTime)
        ' ''        param(16).Value = propMatra.PickupDate
        ' ''        param(17) = New SqlParameter("@PickupFrom", SqlDbType.NVarChar, 50)
        ' ''        param(17).Value = propMatra.PickupFrom
        ' ''        param(18) = New SqlParameter("@PlaceOfDelivery", SqlDbType.NVarChar, 50)
        ' ''        param(18).Value = propMatra.PlaceOfDelivery
        ' ''        param(19) = New SqlParameter("@PlaceOfDeliveryEta", SqlDbType.DateTime)
        ' ''        param(19).Value = propMatra.PlaceOfDeliveryEta
        ' ''        param(20) = New SqlParameter("@Qty", SqlDbType.Int)
        ' ''        param(20).Value = propMatra.Qty
        ' ''        param(21) = New SqlParameter("@RfqNo", SqlDbType.NVarChar, 50)
        ' ''        param(21).Value = propMatra.RfqNo
        ' ''        param(22) = New SqlParameter("@SerialNo", SqlDbType.NVarChar, 50)
        ' ''        param(22).Value = propMatra.SerialNo
        ' ''        param(23) = New SqlParameter("@ShipDate", SqlDbType.DateTime)
        ' ''        param(23).Value = propMatra.ShipDate
        ' ''        param(24) = New SqlParameter("@ShipTo", SqlDbType.NVarChar, 50)
        ' ''        param(24).Value = propMatra.ShipTo
        ' ''        param(25) = New SqlParameter("@Status", SqlDbType.NVarChar, 15)
        ' ''        param(25).Value = propMatra.Status
        ' ''        param(26) = New SqlParameter("@UomCode", SqlDbType.NVarChar, 3)
        ' ''        param(26).Value = propMatra.UomCode

        ' ''        Dim intResult As Integer
        ' ''        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spi_Jmar1", param)
        ' ''        If intResult > 0 Then
        ' ''            propMatra.RfqNo = propMatra.RfqNo.ToString()
        ' ''            masterId = propMatra.RfqNo.ToString()
        ' ''            Return True
        ' ''        Else
        ' ''            Return False
        ' ''        End If
        ' ''    Catch ex As Exception
        ' ''        Return False
        ' ''    End Try
        ' ''End Function

        ' ''Public Function DoDelete(ByVal propMatra As clsPropMatra) As Boolean
        ' ''    Try
        ' ''        Dim param(0) As SqlParameter

        ' ''        param(0) = New SqlParameter("@RfqNo", SqlDbType.NVarChar, 50)
        ' ''        param(0).Value = propMatra.RfqNo

        ' ''        Dim intResult As Integer
        ' ''        intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_Jmar1", param)
        ' ''        If intResult > 0 Then
        ' ''            Return True
        ' ''        Else
        ' ''            Return False
        ' ''        End If
        ' ''    Catch ex As Exception
        ' ''        Return False
        ' ''    End Try
        ' ''End Function

    End Class

#End Region
End Namespace
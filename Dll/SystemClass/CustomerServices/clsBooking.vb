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

#Region " Class Collection of Booking Info "

    <Serializable()> _
    Public Class colBooking
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropBooking(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of Booking Info "

    <Serializable()> _
    Public Class clsBooking
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
            colProp = New colBooking()
            Title = "Booking"
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
            colProp = New colBooking()
            Title = "Booking"
        End Sub

        Private Function InsertBooking(ByRef prop As clsPropBooking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(70) As SqlParameter
                param(0) = New SqlParameter("@OrderDate", SqlDbType.NVarChar, 50)
                param(1) = New SqlParameter("@CustomerName", SqlDbType.NVarChar, 50)
                param(2) = New SqlParameter("@ContactName", SqlDbType.NVarChar, 50)
                param(3) = New SqlParameter("@ShipperName", SqlDbType.NVarChar, 50)
                param(4) = New SqlParameter("@ShipperAddress1", SqlDbType.NVarChar, 50)
                param(5) = New SqlParameter("@ShipperAddress2", SqlDbType.NVarChar, 50)
                param(6) = New SqlParameter("@ShipperAddress3", SqlDbType.NVarChar, 50)
                param(7) = New SqlParameter("@ShipperAddress4", SqlDbType.NVarChar, 50)
                param(8) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar, 50)
                param(9) = New SqlParameter("@ConsigneeAddress1", SqlDbType.NVarChar, 50)

                param(10) = New SqlParameter("@ConsigneeAddress2", SqlDbType.NVarChar, 50)
                param(11) = New SqlParameter("@ConsigneeAddress3", SqlDbType.NVarChar, 50)
                param(12) = New SqlParameter("@ConsigneeAddress4", SqlDbType.NVarChar, 50)
                param(13) = New SqlParameter("@OriginCode", SqlDbType.NVarChar, 50)
                param(14) = New SqlParameter("@DestCode", SqlDbType.NVarChar, 50)
                param(15) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar, 50)
                param(16) = New SqlParameter("@EtdDate", SqlDbType.DateTime)
                param(17) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 50)
                param(18) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(19) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 50)

                param(20) = New SqlParameter("@CargoType", SqlDbType.NVarChar, 50)
                param(21) = New SqlParameter("@DgFlag", SqlDbType.NVarChar, 50)
                param(22) = New SqlParameter("@DeliveryType", SqlDbType.NVarChar, 50)
                param(23) = New SqlParameter("@CommodityCode", SqlDbType.NVarChar, 50)
                param(24) = New SqlParameter("@UomCode", SqlDbType.NVarChar, 50)
                param(25) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 9)
                param(26) = New SqlParameter("@Volume", SqlDbType.Decimal, 9)
                param(27) = New SqlParameter("@PickupDateTime", SqlDbType.DateTime)
                param(28) = New SqlParameter("@CollectFromAddress1", SqlDbType.NVarChar, 50)
                param(29) = New SqlParameter("@CollectFromAddress2", SqlDbType.NVarChar, 50)

                param(30) = New SqlParameter("@CollectFromAddress3", SqlDbType.NVarChar, 50)
                param(31) = New SqlParameter("@CollectFromAddress4", SqlDbType.NVarChar, 50)
                param(32) = New SqlParameter("@SpecialInstruction", SqlDbType.NVarChar, 3000)
                param(33) = New SqlParameter("@OrderNo", SqlDbType.NVarChar, 50)
                param(34) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(34).Direction = ParameterDirection.Output
                'add
                param(35) = New SqlParameter("@CustomerCode", SqlDbType.NVarChar, 10)
                param(36) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 50)
                param(37) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 50)
                param(38) = New SqlParameter("@Pcs", SqlDbType.BigInt)

                param(39) = New SqlParameter("@NoOfContainer1", SqlDbType.BigInt)
                param(40) = New SqlParameter("@NoOfContainer2", SqlDbType.BigInt)
                param(41) = New SqlParameter("@NoOfContainer3", SqlDbType.BigInt)
                param(42) = New SqlParameter("@ContainerType1", SqlDbType.NVarChar, 10)
                param(43) = New SqlParameter("@ContainerType2", SqlDbType.NVarChar, 10)
                param(44) = New SqlParameter("@ContainerType3", SqlDbType.NVarChar, 10)
                param(45) = New SqlParameter("@MarkNo", SqlDbType.NVarChar, 50)
                param(46) = New SqlParameter("@CollectFromName", SqlDbType.NVarChar, 50)
                '090313
                param(47) = New SqlParameter("@AirportDeptCode", SqlDbType.NVarChar, 3)

                param(48) = New SqlParameter("@AirportDestCode", SqlDbType.NVarChar, 3)
                param(49) = New SqlParameter("@AirlineId", SqlDbType.NVarChar, 2)
                param(50) = New SqlParameter("@FlightNo", SqlDbType.NVarChar, 10)
                param(51) = New SqlParameter("@ModuleCode", SqlDbType.NVarChar, 2)
                '090325 for .net836
                param(52) = New SqlParameter("@DeliverToName", SqlDbType.NVarChar, 50)
                param(53) = New SqlParameter("@DeliverToAddress1", SqlDbType.NVarChar, 45)
                param(54) = New SqlParameter("@DeliverToAddress2", SqlDbType.NVarChar, 45)
                param(55) = New SqlParameter("@DeliverToAddress3", SqlDbType.NVarChar, 45)
                param(56) = New SqlParameter("@DeliverToAddress4", SqlDbType.NVarChar, 45)
                param(57) = New SqlParameter("@DeliverToDateTime", SqlDbType.DateTime)

                param(58) = New SqlParameter("@DescriptionOfGoods1", SqlDbType.NVarChar, 50)
                param(59) = New SqlParameter("@DescriptionOfGoods2", SqlDbType.NVarChar, 50)
                param(60) = New SqlParameter("@DescriptionOfGoods3", SqlDbType.NVarChar, 50)
                param(61) = New SqlParameter("@DescriptionOfGoods4", SqlDbType.NVarChar, 50)
                param(62) = New SqlParameter("@OrderType", SqlDbType.NVarChar)
                param(63) = New SqlParameter("@CreateBy", SqlDbType.NVarChar)

                param(64) = New SqlParameter("@PackingQty1", SqlDbType.NVarChar)
                param(65) = New SqlParameter("@PackingQty2", SqlDbType.NVarChar)
                param(66) = New SqlParameter("@PackingQty3", SqlDbType.NVarChar)
                param(67) = New SqlParameter("@PackingQty4", SqlDbType.NVarChar)
                param(68) = New SqlParameter("@PackingQty5", SqlDbType.NVarChar)
                param(69) = New SqlParameter("@Telephone", SqlDbType.NVarChar)
                param(70) = New SqlParameter("@OrderNoBarCode", SqlDbType.NVarChar)

                param(0).Value = prop.OrderDate
                param(1).Value = prop.CustomerName
                param(2).Value = prop.ContactName
                param(3).Value = prop.ShipperName
                param(4).Value = prop.ShipperAddress1
                param(5).Value = prop.ShipperAddress2
                param(6).Value = prop.ShipperAddress3
                param(7).Value = prop.ShipperAddress4
                param(8).Value = prop.ConsigneeName
                param(9).Value = prop.ConsigneeAddress1
                param(10).Value = prop.ConsigneeAddress2
                param(11).Value = prop.ConsigneeAddress3
                param(12).Value = prop.ConsigneeAddress4
                param(13).Value = prop.OriginCode
                param(14).Value = prop.DestCode
                param(15).Value = prop.PortOfLoadingCode
                param(16).Value = prop.EtdDate
                param(17).Value = prop.PortOfDischargeCode
                param(18).Value = prop.EtaDate
                param(19).Value = prop.VesselName
                param(20).Value = prop.CargoType
                param(21).Value = prop.DgFlag
                param(22).Value = prop.DeliveryType
                param(23).Value = prop.CommodityCode
                param(24).Value = prop.UomCode
                param(25).Value = prop.GrossWeight
                param(26).Value = prop.Volume
                param(27).Value = prop.PickupDateTime
                param(28).Value = prop.CollectFromAddress1
                param(29).Value = prop.CollectFromAddress2
                param(30).Value = prop.CollectFromAddress3
                param(31).Value = prop.CollectFromAddress4
                param(32).Value = prop.SpecialInstruction
                param(33).Value = prop.OrderNo
                param(34).Value = prop.TrxNo
                'add
                param(35).Value = prop.CustomerCode
                param(36).Value = prop.VoyageNo
                param(37).Value = prop.CommodityDescription
                param(38).Value = prop.Pcs
                param(39).Value = prop.NoOfContainer1
                param(40).Value = prop.NoOfContainer2
                param(41).Value = prop.NoOfContainer3
                param(42).Value = prop.ContainerType1
                param(43).Value = prop.ContainerType2
                param(44).Value = prop.ContainerType3
                param(45).Value = prop.MarkNo
                param(46).Value = prop.CollectFromName

                '090913
                param(47).Value = prop.AirportDeptCode
                param(48).Value = prop.AirportDestCode
                param(49).Value = prop.AirlineId
                param(50).Value = prop.FlightNo
                param(51).Value = prop.ModuleCode
                '090325
                param(52).Value = prop.DeliverToName
                param(53).Value = prop.DeliverToAddress1
                param(54).Value = prop.DeliverToAddress2
                param(55).Value = prop.DeliverToAddress3
                param(56).Value = prop.DeliverToAddress4
                param(57).Value = prop.DeliverToDateTime
                param(58).Value = prop.DescriptionOfGoods1
                param(59).Value = prop.DescriptionOfGoods2
                param(60).Value = prop.DescriptionOfGoods3
                param(61).Value = prop.DescriptionOfGoods4
                param(62).Value = prop.OrderType
                param(63).Value = UserId

                param(64).Value = prop.PackingQty1
                param(65).Value = prop.PackingQty2
                param(66).Value = prop.PackingQty3
                param(67).Value = prop.PackingQty4
                param(68).Value = prop.PackingQty5
                param(69).Value = prop.Telephone
                param(70).Value = prop.OrderNoBarCode

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_omtx1", param)
                If intResult > 0 Then
                    prop.TrxNo = Int64.Parse(param(34).Value.ToString())
                    masterId = Int64.Parse(param(34).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateBooking(ByVal prop As clsPropBooking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(70) As SqlParameter
                param(0) = New SqlParameter("@OrderDate", SqlDbType.NVarChar, 50)
                param(1) = New SqlParameter("@CustomerName", SqlDbType.NVarChar, 50)
                param(2) = New SqlParameter("@ContactName", SqlDbType.NVarChar, 50)
                param(3) = New SqlParameter("@ShipperName", SqlDbType.NVarChar, 50)
                param(4) = New SqlParameter("@ShipperAddress1", SqlDbType.NVarChar, 50)
                param(5) = New SqlParameter("@ShipperAddress2", SqlDbType.NVarChar, 50)
                param(6) = New SqlParameter("@ShipperAddress3", SqlDbType.NVarChar, 50)
                param(7) = New SqlParameter("@ShipperAddress4", SqlDbType.NVarChar, 50)
                param(8) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar, 50)
                param(9) = New SqlParameter("@ConsigneeAddress1", SqlDbType.NVarChar, 50)
                param(10) = New SqlParameter("@ConsigneeAddress2", SqlDbType.NVarChar, 50)
                param(11) = New SqlParameter("@ConsigneeAddress3", SqlDbType.NVarChar, 50)
                param(12) = New SqlParameter("@ConsigneeAddress4", SqlDbType.NVarChar, 50)
                param(13) = New SqlParameter("@OriginCode", SqlDbType.NVarChar, 50)
                param(14) = New SqlParameter("@DestCode", SqlDbType.NVarChar, 50)
                param(15) = New SqlParameter("@PortOfLoadingCode", SqlDbType.NVarChar, 50)
                param(16) = New SqlParameter("@EtdDate", SqlDbType.DateTime)
                param(17) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar, 50)
                param(18) = New SqlParameter("@EtaDate", SqlDbType.DateTime)
                param(19) = New SqlParameter("@VesselName", SqlDbType.NVarChar, 50)
                param(20) = New SqlParameter("@CargoType", SqlDbType.NVarChar, 50)
                param(21) = New SqlParameter("@DgFlag", SqlDbType.NVarChar, 50)
                param(22) = New SqlParameter("@DeliveryType", SqlDbType.NVarChar, 50)
                param(23) = New SqlParameter("@CommodityCode", SqlDbType.NVarChar, 50)
                param(24) = New SqlParameter("@UomCode", SqlDbType.NVarChar, 50)
                param(25) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 9)
                param(26) = New SqlParameter("@Volume", SqlDbType.Decimal, 9)
                param(27) = New SqlParameter("@PickupDateTime", SqlDbType.DateTime)
                param(28) = New SqlParameter("@CollectFromAddress1", SqlDbType.NVarChar, 50)
                param(29) = New SqlParameter("@CollectFromAddress2", SqlDbType.NVarChar, 50)
                param(30) = New SqlParameter("@CollectFromAddress3", SqlDbType.NVarChar, 50)
                param(31) = New SqlParameter("@CollectFromAddress4", SqlDbType.NVarChar, 50)
                param(32) = New SqlParameter("@SpecialInstruction", SqlDbType.NVarChar, 3000)
                param(33) = New SqlParameter("@OrderNo", SqlDbType.NVarChar, 50)
                param(34) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                'add
                param(35) = New SqlParameter("@CustomerCode", SqlDbType.NVarChar, 10)
                param(36) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar, 50)
                param(37) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar, 50)
                param(38) = New SqlParameter("@Pcs", SqlDbType.BigInt)
                param(39) = New SqlParameter("@NoOfContainer1", SqlDbType.BigInt)
                param(40) = New SqlParameter("@NoOfContainer2", SqlDbType.BigInt)
                param(41) = New SqlParameter("@NoOfContainer3", SqlDbType.BigInt)
                param(42) = New SqlParameter("@ContainerType1", SqlDbType.NVarChar, 10)
                param(43) = New SqlParameter("@ContainerType2", SqlDbType.NVarChar, 10)
                param(44) = New SqlParameter("@ContainerType3", SqlDbType.NVarChar, 10)
                param(45) = New SqlParameter("@MarkNo", SqlDbType.NVarChar, 50)
                param(46) = New SqlParameter("@CollectFromName", SqlDbType.NVarChar, 50)

                '090313
                param(47) = New SqlParameter("@AirportDeptCode", SqlDbType.NVarChar, 3)
                param(48) = New SqlParameter("@AirportDestCode", SqlDbType.NVarChar, 3)
                param(49) = New SqlParameter("@AirlineId", SqlDbType.NVarChar, 2)
                param(50) = New SqlParameter("@FlightNo", SqlDbType.NVarChar, 10)
                '090325 for .net836
                param(51) = New SqlParameter("@DeliverToName", SqlDbType.NVarChar, 50)
                param(52) = New SqlParameter("@DeliverToAddress1", SqlDbType.NVarChar, 45)
                param(53) = New SqlParameter("@DeliverToAddress2", SqlDbType.NVarChar, 45)
                param(54) = New SqlParameter("@DeliverToAddress3", SqlDbType.NVarChar, 45)
                param(55) = New SqlParameter("@DeliverToAddress4", SqlDbType.NVarChar, 45)
                param(56) = New SqlParameter("@DeliverToDateTime", SqlDbType.DateTime)
                param(57) = New SqlParameter("@DescriptionOfGoods1", SqlDbType.NVarChar, 50)
                param(58) = New SqlParameter("@DescriptionOfGoods2", SqlDbType.NVarChar, 50)
                param(59) = New SqlParameter("@DescriptionOfGoods3", SqlDbType.NVarChar, 50)
                param(60) = New SqlParameter("@DescriptionOfGoods4", SqlDbType.NVarChar, 50)
                param(61) = New SqlParameter("@OrderType", SqlDbType.NVarChar)
                param(62) = New SqlParameter("@UpdateBy", SqlDbType.NVarChar)

                param(63) = New SqlParameter("@PackingQty1", SqlDbType.NVarChar)
                param(64) = New SqlParameter("@PackingQty2", SqlDbType.NVarChar)
                param(65) = New SqlParameter("@PackingQty3", SqlDbType.NVarChar)
                param(66) = New SqlParameter("@PackingQty4", SqlDbType.NVarChar)
                param(67) = New SqlParameter("@PackingQty5", SqlDbType.NVarChar)
                param(68) = New SqlParameter("@Telephone", SqlDbType.NVarChar)
                param(69) = New SqlParameter("@ModuleCode", SqlDbType.NVarChar)
                param(70) = New SqlParameter("@OrderNoBarCode", SqlDbType.NVarChar)

                param(0).Value = prop.OrderDate
                param(1).Value = prop.CustomerName
                param(2).Value = prop.ContactName
                param(3).Value = prop.ShipperName
                param(4).Value = prop.ShipperAddress1
                param(5).Value = prop.ShipperAddress2
                param(6).Value = prop.ShipperAddress3
                param(7).Value = prop.ShipperAddress4
                param(8).Value = prop.ConsigneeName
                param(9).Value = prop.ConsigneeAddress1
                param(10).Value = prop.ConsigneeAddress2
                param(11).Value = prop.ConsigneeAddress3
                param(12).Value = prop.ConsigneeAddress4
                param(13).Value = prop.OriginCode
                param(14).Value = prop.DestCode
                param(15).Value = prop.PortOfLoadingCode
                param(16).Value = prop.EtdDate
                param(17).Value = prop.PortOfDischargeCode
                param(18).Value = prop.EtaDate
                param(19).Value = prop.VesselName
                param(20).Value = prop.CargoType
                param(21).Value = prop.DgFlag
                param(22).Value = prop.DeliveryType
                param(23).Value = prop.CommodityCode
                param(24).Value = prop.UomCode
                param(25).Value = prop.GrossWeight
                param(26).Value = prop.Volume
                param(27).Value = prop.PickupDateTime
                param(28).Value = prop.CollectFromAddress1
                param(29).Value = prop.CollectFromAddress2
                param(30).Value = prop.CollectFromAddress3
                param(31).Value = prop.CollectFromAddress4
                param(32).Value = prop.SpecialInstruction
                param(33).Value = prop.OrderNo
                param(34).Value = prop.TrxNo
                'add
                param(35).Value = prop.CustomerCode
                param(36).Value = prop.VoyageNo
                param(37).Value = prop.CommodityDescription
                param(38).Value = prop.Pcs
                param(39).Value = prop.NoOfContainer1
                param(40).Value = prop.NoOfContainer2
                param(41).Value = prop.NoOfContainer3
                param(42).Value = prop.ContainerType1
                param(43).Value = prop.ContainerType2
                param(44).Value = prop.ContainerType3
                param(45).Value = prop.MarkNo
                param(46).Value = prop.CollectFromName
                '090913
                param(47).Value = prop.AirportDeptCode
                param(48).Value = prop.AirportDestCode
                param(49).Value = prop.AirlineId
                param(50).Value = prop.FlightNo
                '090325.net836
                param(51).Value = prop.DeliverToName
                param(52).Value = prop.DeliverToAddress1
                param(53).Value = prop.DeliverToAddress2
                param(54).Value = prop.DeliverToAddress3
                param(55).Value = prop.DeliverToAddress4
                param(56).Value = prop.DeliverToDateTime
                param(57).Value = prop.DescriptionOfGoods1
                param(58).Value = prop.DescriptionOfGoods2
                param(59).Value = prop.DescriptionOfGoods3
                param(60).Value = prop.DescriptionOfGoods4
                param(61).Value = prop.OrderType
                param(62).Value = UserId

                param(63).Value = prop.PackingQty1
                param(64).Value = prop.PackingQty2
                param(65).Value = prop.PackingQty3
                param(66).Value = prop.PackingQty4
                param(67).Value = prop.PackingQty5
                param(68).Value = prop.Telephone
                param(69).Value = prop.ModuleCode
                param(70).Value = prop.OrderNoBarCode

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_omtx1", param)
                If intResult > 0 Then
                    masterId = prop.TrxNo
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function DeleteBooking(ByVal prop As clsPropBooking, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = prop.TrxNo

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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_omtx1_List", param)
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
            Catch err As Exception
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_omtx1_Detail", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_omtx1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 76 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropBooking
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
                'tmpProp.BookingDate = GeneralFun.StringToDate(strRow(1))
                tmpProp.OrderDate = GeneralFun.StringToDate(strRow(1))
                tmpProp.CustomerName = strRow(2)
                tmpProp.ContactName = strRow(3)
                tmpProp.ShipperName = strRow(4)
                tmpProp.ShipperAddress1 = strRow(5)
                tmpProp.ShipperAddress2 = strRow(6)
                tmpProp.ShipperAddress3 = strRow(7)
                tmpProp.ShipperAddress4 = strRow(8)
                tmpProp.ConsigneeName = strRow(9)
                tmpProp.ConsigneeAddress1 = strRow(10)
                tmpProp.ConsigneeAddress2 = strRow(11)
                tmpProp.ConsigneeAddress3 = strRow(12)
                tmpProp.ConsigneeAddress4 = strRow(13)
                tmpProp.OriginCode = strRow(14)
                tmpProp.DestCode = strRow(15)
                tmpProp.PortOfLoadingCode = strRow(16)
                tmpProp.EtdDate = GeneralFun.StringToDate(strRow(17))
                tmpProp.PortOfDischargeCode = strRow(18)
                tmpProp.EtaDate = GeneralFun.StringToDate(strRow(19))
                tmpProp.VesselName = strRow(20)
                tmpProp.CargoType = strRow(21)
                tmpProp.DgFlag = strRow(22)
                tmpProp.DeliveryType = strRow(23)
                tmpProp.CommodityCode = strRow(24)
                tmpProp.UomCode = strRow(25)
                tmpProp.GrossWeight = GeneralFun.StringToDecimal(strRow(26))
                tmpProp.Volume = GeneralFun.StringToDecimal(strRow(27))
                tmpProp.NoOfContainer1 = GeneralFun.StringToInt(strRow(28))
                tmpProp.ContainerType1 = strRow(29)
                tmpProp.NoOfContainer2 = GeneralFun.StringToInt(strRow(30))
                tmpProp.ContainerType2 = strRow(31)
                tmpProp.NoOfContainer3 = GeneralFun.StringToInt(strRow(32))
                tmpProp.ContainerType3 = strRow(33)
                tmpProp.PickupDateTime = GeneralFun.StringToDate(strRow(34))
                tmpProp.CollectFromName = strRow(35)
                tmpProp.CollectFromAddress1 = strRow(36)
                tmpProp.CollectFromAddress2 = strRow(37)
                tmpProp.CollectFromAddress3 = strRow(38)
                tmpProp.CollectFromAddress4 = strRow(39)
                tmpProp.SpecialInstruction = strRow(40)
                tmpProp.OrderNo = strRow(41)
                'add
                tmpProp.CustomerCode = strRow(42)
                tmpProp.VoyageNo = strRow(43)
                tmpProp.CommodityDescription = strRow(44)
                tmpProp.Pcs = GeneralFun.StringToInt(strRow(45))
                tmpProp.MarkNo = strRow(46)
                '090312
                tmpProp.AirportDeptCode = strRow(47)
                tmpProp.AirportDestCode = strRow(48)
                tmpProp.AirlineId = strRow(49)
                tmpProp.FlightNo = strRow(50)
                tmpProp.ModuleCode = strRow(51)
                '090325 ForLocal TransPort

                If tmpProp.ModuleCode = "TP" Then
                    tmpProp.CollectFromName = strRow(52)
                    tmpProp.PickupDateTime = GeneralFun.StringToDate(strRow(54))
                End If
                tmpProp.DeliverToName = strRow(53)
                tmpProp.DeliverToDateTime = GeneralFun.StringToDate(strRow(55))
                'adress
                tmpProp.DeliverToAddress1 = strRow(56)
                tmpProp.DeliverToAddress2 = strRow(57)
                tmpProp.DeliverToAddress3 = strRow(58)
                tmpProp.DeliverToAddress4 = strRow(59)
                tmpProp.DescriptionOfGoods1 = strRow(60)
                tmpProp.DescriptionOfGoods2 = strRow(61)
                tmpProp.DescriptionOfGoods3 = strRow(62)
                tmpProp.DescriptionOfGoods4 = strRow(63)
                tmpProp.OrderType = strRow(64)
                tmpProp.Telephone = strRow(65)
                tmpProp.PackingQty1 = GeneralFun.StringToInt(strRow(66))
                tmpProp.PackingQty2 = GeneralFun.StringToInt(strRow(67))
                tmpProp.PackingQty3 = GeneralFun.StringToInt(strRow(68))
                tmpProp.PackingQty4 = GeneralFun.StringToInt(strRow(69))
                tmpProp.PackingQty5 = GeneralFun.StringToInt(strRow(70))
                If strRow(71).Trim = "" Then
                    tmpProp.ModuleCode = strRow(51)
                Else
                    tmpProp.ModuleCode = strRow(71)
                End If
                tmpProp.OrderNoBarCode = strRow(72)
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropBooking = CType(CurrentProp, clsPropBooking)
            blnReturn = InsertBooking(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropBooking = CType(CurrentProp, clsPropBooking)
            blnReturn = UpdateBooking(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropBooking = CType(CurrentProp, clsPropBooking)
            blnReturn = DeleteBooking(tmpProp, conn, trans, 1, strMsg)
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
        'Get Email Set
        Private Function GetEmailAddress(ByVal intTrxNo As Int64, ByRef strFrom As String, ByRef strTo As String, ByRef strSmtpServer As String, ByRef intSmtpPort As Integer, ByRef strSmtpUser As String, ByRef strSmtpPassword As String) As Boolean
            If intTrxNo >= 0 Then
                Try
                    Dim param(6) As SqlParameter

                    param(0) = New SqlParameter("@intTrxNo", SqlDbType.BigInt)
                    param(0).Value = intTrxNo

                    param(1) = New SqlParameter("@strEmail", SqlDbType.NVarChar, 3000)
                    param(1).Direction = ParameterDirection.Output

                    param(2) = New SqlParameter("@strFrom", SqlDbType.NVarChar, 1000)
                    param(2).Direction = ParameterDirection.Output

                    param(3) = New SqlParameter("@strSmtpServer", SqlDbType.NVarChar, 1000)
                    param(3).Direction = ParameterDirection.Output

                    param(4) = New SqlParameter("@intSmtpPort", SqlDbType.Int)
                    param(4).Direction = ParameterDirection.Output

                    param(5) = New SqlParameter("@strSmtpUser", SqlDbType.NVarChar, 1000)
                    param(5).Direction = ParameterDirection.Output

                    param(6) = New SqlParameter("@strSmtpPassword", SqlDbType.NVarChar, 1000)
                    param(6).Direction = ParameterDirection.Output

                    SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "sps_BookingEmailAddress", param)
                    strFrom = CStr(param(2).Value)
                    strTo = CStr(param(1).Value)
                    strSmtpServer = CStr(param(3).Value)
                    intSmtpPort = CInt(param(4).Value)
                    strSmtpUser = CStr(param(5).Value)
                    strSmtpPassword = CStr(param(6).Value)
                    Return True
                Catch ex As Exception
                    Return False
                End Try
            Else
                Return False
            End If
        End Function
        Public Function SendEmail(ByVal prop As clsPropBooking, ByVal strUserName As String, Optional ByVal m_blnConfirm As Boolean = False, Optional ByVal m_blnSend As Boolean = False, Optional ByVal intType As Integer = 0, Optional ByVal strFunNo As String = "") As Boolean
            Dim objMail As New MailMessage
            Dim client As New SmtpClient
            Try
                Dim strHost = "mail.sysfreight.com"
                Dim strFrom As String = ""
                Dim strSmtpServer As String = ""
                Dim intSmtpPort As Integer = 25
                Dim strSmtpUser As String = ""
                Dim strSmtpPassword As String = ""
                Dim strTo As String = ""
                Dim strSubject As String = ""
                Dim strBody As String = ""
                Dim i As Integer
                '+++++++++++++++++++ 081212 Net678 +++++++++++++++++++++++
                Dim strSubOfTitle As String = "Booking"
                Dim TrxNo As String = "TrxNo"
                '+++++++++++++++++++++++ End +++++++++++++++++++++++++++++
                If Not GetEmailAddress(prop.TrxNo, strFrom, strTo, strSmtpServer, intSmtpPort, strSmtpUser, strSmtpPassword) Then
                    Return False
                End If
                Dim strModule As String = ""

                If strModule <> "" Then
                    strModule = strModule.Substring(0, strModule.Length - 2)
                End If
                If intType = 0 Then  '' intType=0 just for the first Tab "Booking" to send button
                    'strSubject = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.BookingMailTitle, strUserName)
                    '+++++++++++++++++++++++ 081212 Net678 ++++++++++++++++++++++++++++++
                    'strBody = ZZMessage.clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, mailInfo) '' note: this RestoreAction just put the emailbody...
                    strBody = "Booking Summary" & vbCrLf & vbCrLf

                    Dim strAttach = System.Web.HttpContext.Current.Server.MapPath("../Attach/")
                    Dim arrAttachFileName() As String = clsAttachFileDirectory.GetAllFileName(strAttach + prop.TrxNo.ToString())
                    If Not arrAttachFileName Is Nothing Then
                        For i = 0 To arrAttachFileName.Length - 1
                            objMail.Attachments.Add(New Attachment(arrAttachFileName(i)))
                        Next
                    End If
                    Dim tmpARR() As String
                    objMail.From = New MailAddress(strFrom) 'strFrom
                    'testbyzhiwei
                    strTo = "zhiwei@sysfreight.com,"
                    'test
                    ' 081023 zhiwei
                    If strTo.Trim <> "" Then
                        'add email to 
                        tmpARR = strTo.Split(",")
                        For i = 0 To UBound(tmpARR)
                            If tmpARR(i).Trim <> "" Then
                                objMail.To.Add(New MailAddress(tmpARR(i).Trim))
                            End If
                        Next
                    End If
                End If
                '++++++++++++++++++++++++++ End ++++++++++++++++++++++++++++++++
                objMail.Subject = strSubject
                objMail.Body = strBody

                client.Host = strSmtpServer
                client.Port = intSmtpPort
                If strSmtpServer <> "" Then
                    '.byzhiwei090106
                    client.UseDefaultCredentials = True '
                    client.EnableSsl = False '
                    client.Credentials = New System.Net.NetworkCredential(strSmtpUser, strSmtpPassword)
                    client.DeliveryMethod = SmtpDeliveryMethod.Network
                End If
                Try
                    client.Send(objMail)
                    Return True
                Catch ex As Exception
                    ''MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class

#End Region

#Region " Class of Dimension Server "

    <Serializable()> _
    Public Class clsDimension
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
            colProp = New colDimension()
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
            colProp = New colDimension()
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
        Public Function DeleteOmtx3(ByVal strTrxNo As String, ByVal strLineItemNo As String, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.NVarChar, 4)
                param(0).Value = strTrxNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.BigInt)
                param(1).Value = strLineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(ConDbConn.ConnectionString, CommandType.StoredProcedure, "spd_Track_omtx3", param)
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
        Private Function InsertDimension(ByVal propDimension As clsPropDimension, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(6) As SqlParameter


                param(0) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
                param(0).Value = propDimension.LineItemNo

                param(1) = New SqlParameter("@GrossWeight", SqlDbType.Decimal, 9)
                param(1).Value = propDimension.Weight

                param(2) = New SqlParameter("@Height", SqlDbType.Decimal, 9)
                param(2).Value = propDimension.Height

                param(3) = New SqlParameter("@Length", SqlDbType.Decimal, 9)
                param(3).Value = propDimension.Length

                param(4) = New SqlParameter("@Pcs", SqlDbType.Decimal, 9)
                param(4).Value = propDimension.Pcs

                param(5) = New SqlParameter("@Width", SqlDbType.Decimal, 9)
                param(5).Value = propDimension.Width

                param(6) = New SqlParameter("@TrxNo", SqlDbType.SmallInt)
                param(6).Value = propDimension.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_omtx3", param)
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

        Private Function UpdateDimension(ByVal propDimension As clsPropDimension, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(6) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.NVarChar, 20)
                param(0).Value = propDimension.TrxNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
                param(1).Value = propDimension.LineItemNo

                param(2) = New SqlParameter("@Dimension", SqlDbType.NVarChar, 255)
                param(2).Value = propDimension.Dimension

                param(3) = New SqlParameter("@Height", SqlDbType.NVarChar, 255)
                param(3).Value = propDimension.Height

                param(4) = New SqlParameter("@Length", SqlDbType.NVarChar, 50)
                param(4).Value = propDimension.Length

                param(5) = New SqlParameter("@Pcs", SqlDbType.NVarChar, 50)
                param(5).Value = propDimension.Pcs

                param(6) = New SqlParameter("@Width", SqlDbType.NVarChar, 50)
                param(6).Value = propDimension.Width

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_omtx3", param)
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

        Private Function DeleteDimension(ByVal propDimension As clsPropDimension, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(1) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.NVarChar, 20)
                param(0).Value = propDimension.TrxNo

                param(1) = New SqlParameter("@LineItemNo", SqlDbType.SmallInt)
                param(1).Value = propDimension.LineItemNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_omtx3", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_omtx3_List", param)
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
                Dim tmpProp As clsPropDimension
                CurrentProp = colProp.NewOneProp()
                tmpProp = CType(CurrentProp, clsPropDimension)
                tmpProp.TrxNo = _MasterId
                State = EditState.Insert
                If strRow(0) = "New" Then
                    strsql = "select max(LineItemNo) from Omtx3 where TrxNo='" & _MasterId & "'"
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
                tmpProp.Pcs = strRow(1)
                tmpProp.Weight = strRow(2)
                tmpProp.Length = strRow(3)
                tmpProp.Width = strRow(4)
                tmpProp.Height = strRow(5)
                'Set tmpProp to CurrentProp
                CurrentProp = tmpProp
                Return True
            End If
        End Function

        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            blnReturn = InsertDimension(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            blnReturn = UpdateDimension(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            blnReturn = DeleteDimension(tmpProp, conn, trans, 1, strMsg)
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
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            blnReturn = DeleteDimension(tmpProp, conn, trans, 0, strMsg)
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
            '        Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            Return True
        End Function

        Protected Overrides Sub InsertSuccess()
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            '    clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.InsertAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub UpdateSuccess()
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            '   clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.UpdateAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub DeleteSuccess()
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            '  clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.DeleteAction, Title, tmpProp.S_No))
        End Sub

        Protected Overrides Sub RestoreSuccess()
            Dim tmpProp As clsPropDimension = CType(CurrentProp, clsPropDimension)
            ' clsLog.InsertLog(UserId, DateTime.Now, clsMessage.GetFormatMessage(ConMsgInfo.RestoreAction, Title, tmpProp.S_No))
        End Sub

    End Class

#End Region

#Region " Class of Property Dimension "

    <Serializable()> _
    Public Class clsPropDimension
        Inherits clsProp
        'From Omtx3
        Private _TrxNo As String = ""
        Private _LineItemNo As String = ""
        Private _Dimension As String = ""
        Private _Height As String = ""
        Private _Length As String = ""
        Private _Pcs As String = ""
        Private _Width As String = ""
        Private _Weight As String = ""
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
        Public Property Dimension() As String
            Set(ByVal value As String)
                If _Dimension <> value Then
                    _Dimension = value
                End If
            End Set
            Get
                Return _Dimension
            End Get
        End Property
        ' 
        Public Property Height() As String
            Set(ByVal value As String)
                If _Height <> value Then
                    _Height = value
                End If
            End Set
            Get
                Return _Height
            End Get
        End Property
        ' 
        Public Property Length() As String
            Set(ByVal value As String)
                If _Length <> value Then
                    _Length = value
                End If
            End Set
            Get
                Return _Length
            End Get
        End Property
        ' 
        Public Property Pcs() As String
            Set(ByVal value As String)
                If _Pcs <> value Then
                    _Pcs = value
                End If
            End Set
            Get
                Return _Pcs
            End Get
        End Property
        ' 
        Public Property Width() As String
            Set(ByVal value As String)
                If _Width <> value Then
                    _Width = value
                End If
            End Set
            Get
                Return _Width
            End Get
        End Property
        Public Property Weight() As String
            Set(ByVal value As String)
                If _Weight <> value Then
                    _Weight = value
                End If
            End Set
            Get
                Return _Weight
            End Get
        End Property
        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = ""
            _LineItemNo = ""
            _Dimension = ""
            _Height = ""
            _Length = ""
            _Pcs = ""
            _Width = ""
            _Weight = ""
        End Sub
    End Class

#End Region

#Region " Class of Collection of Property Dimension "

    <Serializable()> _
    Public Class colDimension
        Inherits colclsProp
        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropDimension(ConClass.NewIdValue)
        End Function

    End Class

#End Region
End Namespace
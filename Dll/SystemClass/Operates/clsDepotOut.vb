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

#Region " Class Collection of DepotOut Info "

    <Serializable()> _
    Public Class colDepotOut
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropDepotOut(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of DepotOut Info "

    <Serializable()> _
    Public Class clsDepotOut
        Inherits clsBaseSrv
        Private _ConfirmExternal As Boolean
        Private _masterId As String
        Public Overrides Function GetDetail(ByVal intId As String) As clsProp
            Dim dt As DataTable = Nothing
            Try
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
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
            colProp = New colDepotOut()
            Title = "Depot Out"
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
            colProp = New colDepotOut()
            Title = "Depot Out"
        End Sub
        Private Function InsertDepotOut(ByRef propDepotOut As clsPropDepotOut, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(61) As SqlParameter
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

                param(0).Value = propDepotOut.OrderDate
                param(1).Value = propDepotOut.CustomerName
                param(2).Value = propDepotOut.ContactName
                param(3).Value = propDepotOut.ShipperName
                param(4).Value = propDepotOut.ShipperAddress1
                param(5).Value = propDepotOut.ShipperAddress2
                param(6).Value = propDepotOut.ShipperAddress3
                param(7).Value = propDepotOut.ShipperAddress4
                param(8).Value = propDepotOut.ConsigneeName
                param(9).Value = propDepotOut.ConsigneeAddress1
                param(10).Value = propDepotOut.ConsigneeAddress2
                param(11).Value = propDepotOut.ConsigneeAddress3
                param(12).Value = propDepotOut.ConsigneeAddress4
                param(13).Value = propDepotOut.OriginCode
                param(14).Value = propDepotOut.DestCode
                param(15).Value = propDepotOut.PortOfLoadingCode
                param(16).Value = propDepotOut.EtdDate
                param(17).Value = propDepotOut.PortOfDischargeCode
                param(18).Value = propDepotOut.EtaDate
                param(19).Value = propDepotOut.VesselName
                param(20).Value = propDepotOut.CargoType
                param(21).Value = propDepotOut.DgFlag
                param(22).Value = propDepotOut.DeliveryType
                param(23).Value = propDepotOut.CommodityCode
                param(24).Value = propDepotOut.UomCode
                param(25).Value = propDepotOut.GrossWeight
                param(26).Value = propDepotOut.Volume
                param(27).Value = propDepotOut.PickupDateTime
                param(28).Value = propDepotOut.CollectFromAddress1
                param(29).Value = propDepotOut.CollectFromAddress2
                param(30).Value = propDepotOut.CollectFromAddress3
                param(31).Value = propDepotOut.CollectFromAddress4
                param(32).Value = propDepotOut.SpecialInstruction
                param(33).Value = propDepotOut.OrderNo
                param(34).Value = propDepotOut.TrxNo
                'add
                param(35).Value = propDepotOut.CustomerCode
                param(36).Value = propDepotOut.VoyageNo
                param(37).Value = propDepotOut.CommodityDescription
                param(38).Value = propDepotOut.Pcs
                param(39).Value = propDepotOut.NoOfContainer1
                param(40).Value = propDepotOut.NoOfContainer2
                param(41).Value = propDepotOut.NoOfContainer3
                param(42).Value = propDepotOut.ContainerType1
                param(43).Value = propDepotOut.ContainerType2
                param(44).Value = propDepotOut.ContainerType3
                param(45).Value = propDepotOut.MarkNo
                param(46).Value = propDepotOut.CollectFromName

                '090913
                param(47).Value = propDepotOut.AirportDeptCode
                param(48).Value = propDepotOut.CommodityDescription
                param(49).Value = propDepotOut.AirlineId
                param(50).Value = propDepotOut.FlightNo
                param(51).Value = propDepotOut.ModuleCode
                '090325
                param(52).Value = propDepotOut.DeliverToName
                param(53).Value = propDepotOut.DeliverToAddress1
                param(54).Value = propDepotOut.DeliverToAddress2
                param(55).Value = propDepotOut.DeliverToAddress3
                param(56).Value = propDepotOut.DeliverToAddress4
                param(57).Value = propDepotOut.DeliverToDateTime
                param(58).Value = propDepotOut.DescriptionOfGoods1
                param(59).Value = propDepotOut.DescriptionOfGoods2
                param(60).Value = propDepotOut.DescriptionOfGoods3
                param(61).Value = propDepotOut.DescriptionOfGoods4

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_omtx1", param)
                If intResult > 0 Then
                    propDepotOut.TrxNo = Int64.Parse(param(34).Value.ToString())
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
        Private Function UpdateDepotOut(ByVal propDepotOut As clsPropDepotOut, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(60) As SqlParameter
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



                param(0).Value = propDepotOut.OrderDate
                param(1).Value = propDepotOut.CustomerName
                param(2).Value = propDepotOut.ContactName
                param(3).Value = propDepotOut.ShipperName
                param(4).Value = propDepotOut.ShipperAddress1
                param(5).Value = propDepotOut.ShipperAddress2
                param(6).Value = propDepotOut.ShipperAddress3
                param(7).Value = propDepotOut.ShipperAddress4
                param(8).Value = propDepotOut.ConsigneeName
                param(9).Value = propDepotOut.ConsigneeAddress1
                param(10).Value = propDepotOut.ConsigneeAddress2
                param(11).Value = propDepotOut.ConsigneeAddress3
                param(12).Value = propDepotOut.ConsigneeAddress4
                param(13).Value = propDepotOut.OriginCode
                param(14).Value = propDepotOut.DestCode
                param(15).Value = propDepotOut.PortOfLoadingCode
                param(16).Value = propDepotOut.EtdDate
                param(17).Value = propDepotOut.PortOfDischargeCode
                param(18).Value = propDepotOut.EtaDate
                param(19).Value = propDepotOut.VesselName
                param(20).Value = propDepotOut.CargoType
                param(21).Value = propDepotOut.DgFlag
                param(22).Value = propDepotOut.DeliveryType
                param(23).Value = propDepotOut.CommodityCode
                param(24).Value = propDepotOut.UomCode
                param(25).Value = propDepotOut.GrossWeight
                param(26).Value = propDepotOut.Volume
                param(27).Value = propDepotOut.PickupDateTime
                param(28).Value = propDepotOut.CollectFromAddress1
                param(29).Value = propDepotOut.CollectFromAddress2
                param(30).Value = propDepotOut.CollectFromAddress3
                param(31).Value = propDepotOut.CollectFromAddress4
                param(32).Value = propDepotOut.SpecialInstruction
                param(33).Value = propDepotOut.OrderNo
                param(34).Value = propDepotOut.TrxNo
                'add
                param(35).Value = propDepotOut.CustomerCode
                param(36).Value = propDepotOut.VoyageNo
                param(37).Value = propDepotOut.CommodityDescription
                param(38).Value = propDepotOut.Pcs
                param(39).Value = propDepotOut.NoOfContainer1
                param(40).Value = propDepotOut.NoOfContainer2
                param(41).Value = propDepotOut.NoOfContainer3
                param(42).Value = propDepotOut.ContainerType1
                param(43).Value = propDepotOut.ContainerType2
                param(44).Value = propDepotOut.ContainerType3
                param(45).Value = propDepotOut.MarkNo
                param(46).Value = propDepotOut.CollectFromName
                '090913
                param(47).Value = propDepotOut.AirportDeptCode
                param(48).Value = propDepotOut.AirportDestCode
                param(49).Value = propDepotOut.AirlineId
                param(50).Value = propDepotOut.FlightNo
                '090325.net836
                param(51).Value = propDepotOut.DeliverToName
                param(52).Value = propDepotOut.DeliverToAddress1
                param(53).Value = propDepotOut.DeliverToAddress2
                param(54).Value = propDepotOut.DeliverToAddress3
                param(55).Value = propDepotOut.DeliverToAddress4
                param(56).Value = propDepotOut.DeliverToDateTime
                param(57).Value = propDepotOut.DescriptionOfGoods1
                param(58).Value = propDepotOut.DescriptionOfGoods2
                param(59).Value = propDepotOut.DescriptionOfGoods3
                param(60).Value = propDepotOut.DescriptionOfGoods4

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_omtx1", param)
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
        Private Function DeleteDepotOut(ByVal propDepotOut As clsPropDepotOut, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propDepotOut.TrxNo

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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_omtx1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 65 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropDepotOut
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
                'tmpProp.DepotOutDate = GeneralFun.StringToDate(strRow(1))
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
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropDepotOut = CType(CurrentProp, clsPropDepotOut)
            blnReturn = InsertDepotOut(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropDepotOut = CType(CurrentProp, clsPropDepotOut)
            blnReturn = UpdateDepotOut(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropDepotOut = CType(CurrentProp, clsPropDepotOut)
            blnReturn = DeleteDepotOut(tmpProp, conn, trans, 1, strMsg)
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

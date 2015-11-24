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

#Region " Class Collection of Qua Info "

    <Serializable()> _
    Public Class colQua
        Inherits colclsProp

        Public Sub New()
            Me.HavePrefix = False
        End Sub

        Public Overrides Function NewOneProp() As clsProp
            Return New clsPropQua(ConClass.NewIdValue)
        End Function
    End Class
#End Region
#Region " Class Server of Qua Info "

    <Serializable()> _
    Public Class clsQua
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
            colProp = New colQua()
            Title = "B/L Entry"
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
            colProp = New colQua()
            Title = "B/L Entry"
        End Sub
        Private Function InsertQua(ByRef prop As clsPropQua, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(58) As SqlParameter
                param(0) = New SqlParameter("@BookingNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@BlNo", SqlDbType.NVarChar)
                param(2) = New SqlParameter("@ShipmentType", SqlDbType.NVarChar)
                param(3) = New SqlParameter("@OBlNo", SqlDbType.NVarChar)
                param(4) = New SqlParameter("@CustomerCode", SqlDbType.NVarChar)
                param(5) = New SqlParameter("@CustomerName", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@ShipperName", SqlDbType.NVarChar)
                param(7) = New SqlParameter("@ShipperAddress1", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@ShipperAddress2", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ShipperAddress3", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@ShipperAddress4", SqlDbType.NVarChar)
                param(11) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar)
                param(12) = New SqlParameter("@ConsigneeAddress1", SqlDbType.NVarChar)
                param(13) = New SqlParameter("@ConsigneeAddress2", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@ConsigneeAddress3", SqlDbType.NVarChar)
                param(15) = New SqlParameter("@ConsigneeAddress4", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@NotifyName", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@NotifyAddress1", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@NotifyAddress2", SqlDbType.NVarChar)
                param(19) = New SqlParameter("@NotifyAddress3", SqlDbType.NVarChar)
                param(20) = New SqlParameter("@NotifyAddress4", SqlDbType.NVarChar)
                param(21) = New SqlParameter("@DeliveryAgentName", SqlDbType.NVarChar)
                param(22) = New SqlParameter("@DeliveryAgentAddress1", SqlDbType.NVarChar)
                param(23) = New SqlParameter("@DeliveryAgentAddress2", SqlDbType.NVarChar)
                param(24) = New SqlParameter("@DeliveryAgentAddress3", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@DeliveryAgentAddress4", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@CargoType", SqlDbType.NVarChar)
                param(27) = New SqlParameter("@DestCargoType", SqlDbType.NVarChar)
                param(28) = New SqlParameter("@CargoClass", SqlDbType.NVarChar)
                param(29) = New SqlParameter("@CommodityCode", SqlDbType.NVarChar)
                param(30) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar)
                param(31) = New SqlParameter("@OriginCode", SqlDbType.NVarChar)
                param(32) = New SqlParameter("@DestCode", SqlDbType.NVarChar)
                param(33) = New SqlParameter("@DestName", SqlDbType.NVarChar)
                param(34) = New SqlParameter("@PlaceOfReceipt", SqlDbType.NVarChar)
                param(35) = New SqlParameter("@PortOfLoadingName", SqlDbType.NVarChar)
                param(36) = New SqlParameter("@EtdDate", SqlDbType.NVarChar)
                param(37) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar)
                param(38) = New SqlParameter("@PortOfDischargeName", SqlDbType.NVarChar)
                param(39) = New SqlParameter("@EtaDate", SqlDbType.NVarChar)
                param(40) = New SqlParameter("@PlaceOfDelivery", SqlDbType.NVarChar)
                param(41) = New SqlParameter("@VesselName", SqlDbType.NVarChar)
                param(42) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar)
                param(43) = New SqlParameter("@ShippingLineCode", SqlDbType.NVarChar)
                param(44) = New SqlParameter("@ShippingDescription", SqlDbType.NVarChar)
                param(45) = New SqlParameter("@FrtPpCcFlag", SqlDbType.NVarChar)
                param(46) = New SqlParameter("@BlSurrenderFlag", SqlDbType.NVarChar)
                param(47) = New SqlParameter("@NoOfOriginBl", SqlDbType.NVarChar)
                param(48) = New SqlParameter("@BlIssuePlace", SqlDbType.NVarChar)
                param(49) = New SqlParameter("@BlIssueDate", SqlDbType.NVarChar)
                param(50) = New SqlParameter("@LadenDate", SqlDbType.NVarChar)
                param(51) = New SqlParameter("@SignBy", SqlDbType.NVarChar)
                param(52) = New SqlParameter("@TotalPcsInWord", SqlDbType.NVarChar)
                param(53) = New SqlParameter("@PpAt", SqlDbType.NVarChar)
                param(54) = New SqlParameter("@PayableAt", SqlDbType.NVarChar)
                param(55) = New SqlParameter("@JobNo", SqlDbType.NVarChar)
                param(56) = New SqlParameter("@CreateBy", SqlDbType.NVarChar)
                param(57) = New SqlParameter("@CreateDateTime", SqlDbType.NVarChar)
                param(58) = New SqlParameter("@TrxNo", SqlDbType.Int)
                param(58).Direction = ParameterDirection.Output

                param(0).Value = prop.BookingNo
                param(1).Value = prop.BlNo
                param(2).Value = prop.ShipmentType
                param(3).Value = prop.OBlNo
                param(4).Value = prop.CustomerCode
                param(5).Value = prop.CustomerName
                param(6).Value = prop.ShipperName
                param(7).Value = prop.ShipperAddress1
                param(8).Value = prop.ShipperAddress2
                param(9).Value = prop.ShipperAddress3
                param(10).Value = prop.ShipperAddress4
                param(11).Value = prop.ConsigneeName
                param(12).Value = prop.ConsigneeAddress1
                param(13).Value = prop.ConsigneeAddress2
                param(14).Value = prop.ConsigneeAddress3
                param(15).Value = prop.ConsigneeAddress4
                param(16).Value = prop.NotifyName
                param(17).Value = prop.NotifyAddress1
                param(18).Value = prop.NotifyAddress2
                param(19).Value = prop.NotifyAddress3
                param(20).Value = prop.NotifyAddress4
                param(21).Value = prop.DeliveryAgentName
                param(22).Value = prop.DeliveryAgentAddress1
                param(23).Value = prop.DeliveryAgentAddress2
                param(24).Value = prop.DeliveryAgentAddress3
                param(25).Value = prop.DeliveryAgentAddress4
                param(26).Value = prop.CargoType
                param(27).Value = prop.DestCargoType
                param(28).Value = prop.CargoClass
                param(29).Value = prop.CommodityCode
                param(30).Value = prop.CommodityDescription
                param(31).Value = prop.OriginCode
                param(32).Value = prop.DestCode
                param(33).Value = prop.DestName
                param(34).Value = prop.PlaceOfReceipt
                param(35).Value = prop.PortOfLoadingName
                param(36).Value = prop.EtdDate
                param(37).Value = prop.PortOfDischargeCode
                param(38).Value = prop.PortOfDischargeName
                param(39).Value = prop.EtaDate
                param(40).Value = prop.PlaceOfDelivery
                param(41).Value = prop.VesselName
                param(42).Value = prop.VoyageNo
                param(43).Value = prop.ShippinglineCode
                param(44).Value = prop.ShippingDescription
                param(45).Value = prop.FrtPpCcFlag
                param(46).Value = prop.BlSurrenderFlag
                param(47).Value = prop.NoOfOriginBl
                param(48).Value = prop.BlIssuePlace
                param(49).Value = prop.BlIssueDate
                param(50).Value = prop.LadenDate
                param(51).Value = prop.SignBy
                param(52).Value = prop.TotalPcsInWord
                param(53).Value = prop.PpAt
                param(54).Value = prop.PayableAt
                param(55).Value = prop.JobNo
                param(56).Value = prop.CreateBy
                param(57).Value = prop.CreateDateTime

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spi_Track_Sebl1", param)
                If intResult > 0 Then
                    prop.TrxNo = Int64.Parse(param(58).Value.ToString())
                    masterId = Int64.Parse(param(58).Value.ToString())
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                strMsg = ZZMessage.clsMessage.GetErrorMessage(ex)
                Return False
            End Try
        End Function
        Private Function UpdateQua(ByVal prop As clsPropQua, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Try
                Dim param(58) As SqlParameter
                param(0) = New SqlParameter("@BookingNo", SqlDbType.NVarChar)
                param(1) = New SqlParameter("@BlNo", SqlDbType.NVarChar)
                param(2) = New SqlParameter("@ShipmentType", SqlDbType.NVarChar)
                param(3) = New SqlParameter("@OBlNo", SqlDbType.NVarChar)
                param(4) = New SqlParameter("@CustomerCode", SqlDbType.NVarChar)
                param(5) = New SqlParameter("@CustomerName", SqlDbType.NVarChar)
                param(6) = New SqlParameter("@ShipperName", SqlDbType.NVarChar)
                param(7) = New SqlParameter("@ShipperAddress1", SqlDbType.NVarChar)
                param(8) = New SqlParameter("@ShipperAddress2", SqlDbType.NVarChar)
                param(9) = New SqlParameter("@ShipperAddress3", SqlDbType.NVarChar)
                param(10) = New SqlParameter("@ShipperAddress4", SqlDbType.NVarChar)
                param(11) = New SqlParameter("@ConsigneeName", SqlDbType.NVarChar)
                param(12) = New SqlParameter("@ConsigneeAddress1", SqlDbType.NVarChar)
                param(13) = New SqlParameter("@ConsigneeAddress2", SqlDbType.NVarChar)
                param(14) = New SqlParameter("@ConsigneeAddress3", SqlDbType.NVarChar)
                param(15) = New SqlParameter("@ConsigneeAddress4", SqlDbType.NVarChar)
                param(16) = New SqlParameter("@NotifyName", SqlDbType.NVarChar)
                param(17) = New SqlParameter("@NotifyAddress1", SqlDbType.NVarChar)
                param(18) = New SqlParameter("@NotifyAddress2", SqlDbType.NVarChar)
                param(19) = New SqlParameter("@NotifyAddress3", SqlDbType.NVarChar)
                param(20) = New SqlParameter("@NotifyAddress4", SqlDbType.NVarChar)
                param(21) = New SqlParameter("@DeliveryAgentName", SqlDbType.NVarChar)
                param(22) = New SqlParameter("@DeliveryAgentAddress1", SqlDbType.NVarChar)
                param(23) = New SqlParameter("@DeliveryAgentAddress2", SqlDbType.NVarChar)
                param(24) = New SqlParameter("@DeliveryAgentAddress3", SqlDbType.NVarChar)
                param(25) = New SqlParameter("@DeliveryAgentAddress4", SqlDbType.NVarChar)
                param(26) = New SqlParameter("@CargoType", SqlDbType.NVarChar)
                param(27) = New SqlParameter("@DestCargoType", SqlDbType.NVarChar)
                param(28) = New SqlParameter("@CargoClass", SqlDbType.NVarChar)
                param(29) = New SqlParameter("@CommodityCode", SqlDbType.NVarChar)
                param(30) = New SqlParameter("@CommodityDescription", SqlDbType.NVarChar)
                param(31) = New SqlParameter("@OriginCode", SqlDbType.NVarChar)
                param(32) = New SqlParameter("@DestCode", SqlDbType.NVarChar)
                param(33) = New SqlParameter("@DestName", SqlDbType.NVarChar)
                param(34) = New SqlParameter("@PlaceOfReceipt", SqlDbType.NVarChar)
                param(35) = New SqlParameter("@PortOfLoadingName", SqlDbType.NVarChar)
                param(36) = New SqlParameter("@EtdDate", SqlDbType.NVarChar)
                param(37) = New SqlParameter("@PortOfDischargeCode", SqlDbType.NVarChar)
                param(38) = New SqlParameter("@PortOfDischargeName", SqlDbType.NVarChar)
                param(39) = New SqlParameter("@EtaDate", SqlDbType.NVarChar)
                param(40) = New SqlParameter("@PlaceOfDelivery", SqlDbType.NVarChar)
                param(41) = New SqlParameter("@VesselName", SqlDbType.NVarChar)
                param(42) = New SqlParameter("@VoyageNo", SqlDbType.NVarChar)
                param(43) = New SqlParameter("@ShippingLineCode", SqlDbType.NVarChar)
                param(44) = New SqlParameter("@ShippingDescription", SqlDbType.NVarChar)
                param(45) = New SqlParameter("@FrtPpCcFlag", SqlDbType.NVarChar)
                param(46) = New SqlParameter("@BlSurrenderFlag", SqlDbType.NVarChar)
                param(47) = New SqlParameter("@NoOfOriginBl", SqlDbType.NVarChar)
                param(48) = New SqlParameter("@BlIssuePlace", SqlDbType.NVarChar)
                param(49) = New SqlParameter("@BlIssueDate", SqlDbType.NVarChar)
                param(50) = New SqlParameter("@LadenDate", SqlDbType.NVarChar)
                param(51) = New SqlParameter("@SignBy", SqlDbType.NVarChar)
                param(52) = New SqlParameter("@TotalPcsInWord", SqlDbType.NVarChar)
                param(53) = New SqlParameter("@PpAt", SqlDbType.NVarChar)
                param(54) = New SqlParameter("@PayableAt", SqlDbType.NVarChar)
                param(55) = New SqlParameter("@JobNo", SqlDbType.NVarChar)
                param(56) = New SqlParameter("@CreateBy", SqlDbType.NVarChar)
                param(57) = New SqlParameter("@CreateDateTime", SqlDbType.NVarChar)
                param(58) = New SqlParameter("@TrxNo", SqlDbType.Int)

                param(0).Value = prop.BookingNo
                param(1).Value = prop.BlNo
                param(2).Value = prop.ShipmentType
                param(3).Value = prop.OBlNo
                param(4).Value = prop.CustomerCode
                param(5).Value = prop.CustomerName
                param(6).Value = prop.ShipperName
                param(7).Value = prop.ShipperAddress1
                param(8).Value = prop.ShipperAddress2
                param(9).Value = prop.ShipperAddress3
                param(10).Value = prop.ShipperAddress4
                param(11).Value = prop.ConsigneeName
                param(12).Value = prop.ConsigneeAddress1
                param(13).Value = prop.ConsigneeAddress2
                param(14).Value = prop.ConsigneeAddress3
                param(15).Value = prop.ConsigneeAddress4
                param(16).Value = prop.NotifyName
                param(17).Value = prop.NotifyAddress1
                param(18).Value = prop.NotifyAddress2
                param(19).Value = prop.NotifyAddress3
                param(20).Value = prop.NotifyAddress4
                param(21).Value = prop.DeliveryAgentName
                param(22).Value = prop.DeliveryAgentAddress1
                param(23).Value = prop.DeliveryAgentAddress2
                param(24).Value = prop.DeliveryAgentAddress3
                param(25).Value = prop.DeliveryAgentAddress4
                param(26).Value = prop.CargoType
                param(27).Value = prop.DestCargoType
                param(28).Value = prop.CargoClass
                param(29).Value = prop.CommodityCode
                param(30).Value = prop.CommodityDescription
                param(31).Value = prop.OriginCode
                param(32).Value = prop.DestCode
                param(33).Value = prop.DestName
                param(34).Value = prop.PlaceOfReceipt
                param(35).Value = prop.PortOfLoadingName
                param(36).Value = prop.EtdDate
                param(37).Value = prop.PortOfDischargeCode
                param(38).Value = prop.PortOfDischargeName
                param(39).Value = prop.EtaDate
                param(40).Value = prop.PlaceOfDelivery
                param(41).Value = prop.VesselName
                param(42).Value = prop.VoyageNo
                param(43).Value = prop.ShippinglineCode
                param(44).Value = prop.ShippingDescription
                param(45).Value = prop.FrtPpCcFlag
                param(46).Value = prop.BlSurrenderFlag
                param(47).Value = prop.NoOfOriginBl
                param(48).Value = prop.BlIssuePlace
                param(49).Value = prop.BlIssueDate
                param(50).Value = prop.LadenDate
                param(51).Value = prop.SignBy
                param(52).Value = prop.TotalPcsInWord
                param(53).Value = prop.PpAt
                param(54).Value = prop.PayableAt
                param(55).Value = prop.JobNo
                param(56).Value = prop.CreateBy
                param(57).Value = prop.CreateDateTime
                param(58).Value = prop.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spu_Track_sebl1", param)
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
        Private Function DeleteQua(ByVal propQua As clsPropQua, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal intDeleteType As Integer, ByRef strMsg As String) As Boolean
            Try
                Dim param(0) As SqlParameter

                param(0) = New SqlParameter("@TrxNo", SqlDbType.BigInt)
                param(0).Value = propQua.TrxNo

                Dim intResult As Integer
                intResult = SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "spd_Track_Sebl1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Sebl1", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Sebl1_Detail", param)
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

                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "sps_Track_Sebl1_Detail", param)
                dt = ds.Tables(0)
                Return colProp.RecordToProp(dt, 0, 0)
            Catch
                Return colProp.NewOneProp()
            End Try
        End Function
        Public Overrides Function ModifyCurrent(ByVal strValue As String) As Boolean
            Dim strRow As String() = GeneralFun.GetCol(strValue)
            If strRow.Length <> 63 Then
                Return False
            Else
                Dim tmpId As Int64 = Int64.Parse(strRow(0))
                Dim tmpProp As clsPropQua
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
                tmpProp.BookingNo = strRow(1)
                tmpProp.BlNo = strRow(2)
                tmpProp.ShipmentType = strRow(3)
                tmpProp.OBlNo = strRow(4)
                tmpProp.CustomerCode = strRow(5)
                tmpProp.CustomerName = strRow(6)
                tmpProp.ShipperName = strRow(7)
                tmpProp.ShipperAddress1 = strRow(8)
                tmpProp.ShipperAddress2 = strRow(9)
                tmpProp.ShipperAddress3 = strRow(10)
                tmpProp.ShipperAddress4 = strRow(11)
                tmpProp.ConsigneeName = strRow(12)
                tmpProp.ConsigneeAddress1 = strRow(13)
                tmpProp.ConsigneeAddress2 = strRow(14)
                tmpProp.ConsigneeAddress3 = strRow(15)
                tmpProp.ConsigneeAddress4 = strRow(16)
                tmpProp.NotifyName = strRow(17)
                tmpProp.NotifyAddress1 = strRow(18)
                tmpProp.NotifyAddress2 = strRow(19)
                tmpProp.NotifyAddress3 = strRow(20)
                tmpProp.NotifyAddress4 = strRow(21)
                tmpProp.DeliveryAgentName = strRow(22)
                tmpProp.DeliveryAgentAddress1 = strRow(23)
                tmpProp.DeliveryAgentAddress2 = strRow(24)
                tmpProp.DeliveryAgentAddress3 = strRow(25)
                tmpProp.DeliveryAgentAddress4 = strRow(26)
                tmpProp.CargoType = strRow(27)
                tmpProp.DestCargoType = strRow(28)
                tmpProp.CargoClass = strRow(29)
                tmpProp.CommodityCode = strRow(30)
                tmpProp.CommodityDescription = strRow(31)
                tmpProp.OriginCode = strRow(32)
                tmpProp.DestCode = strRow(33)
                tmpProp.DestName = strRow(34)
                tmpProp.PlaceOfReceipt = strRow(35)
                tmpProp.PortOfLoadingName = strRow(36)
                tmpProp.EtdDate = GeneralFun.StringToDate(strRow(37))
                tmpProp.PortOfDischargeCode = strRow(38)
                tmpProp.PortOfDischargeName = strRow(39)
                tmpProp.EtaDate = GeneralFun.StringToDate(strRow(40))
                tmpProp.PlaceOfDelivery = strRow(41)
                tmpProp.VesselName = strRow(42)
                tmpProp.VoyageNo = strRow(43)
                tmpProp.ShippinglineCode = strRow(44)
                tmpProp.ShippingDescription = strRow(45)
                tmpProp.FrtPpCcFlag = strRow(46)
                tmpProp.BlSurrenderFlag = strRow(47)
                tmpProp.NoOfOriginBl = GeneralFun.StringToInt(strRow(48))
                tmpProp.BlIssuePlace = strRow(49)
                tmpProp.BlIssueDate = GeneralFun.StringToDate(strRow(50))
                tmpProp.LadenDate = GeneralFun.StringToDate(strRow(51))
                tmpProp.SignBy = strRow(52)
                tmpProp.TotalPcsInWord = strRow(53)
                tmpProp.PpAt = strRow(54)
                tmpProp.PayableAt = strRow(55)
                tmpProp.JobNo = strRow(56)
                tmpProp.CreateBy = strRow(57)
                tmpProp.CreateDateTime = GeneralFun.StringToDate(strRow(58))
                CurrentProp = tmpProp
                Return True
            End If
        End Function
        Protected Overrides Function InsertData(ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByRef strMsg As String) As Boolean
            Dim blnReturn As Boolean
            Dim tmpProp As clsPropQua = CType(CurrentProp, clsPropQua)
            blnReturn = InsertQua(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropQua = CType(CurrentProp, clsPropQua)
            blnReturn = UpdateQua(tmpProp, conn, trans, strMsg)
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
            Dim tmpProp As clsPropQua = CType(CurrentProp, clsPropQua)
            blnReturn = DeleteQua(tmpProp, conn, trans, 1, strMsg)
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

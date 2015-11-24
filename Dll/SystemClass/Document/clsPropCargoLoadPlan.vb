Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of CargoLoadPlan "

    <Serializable()> _
    Public Class clsPropCargoLoadPlan
        Inherits clsProp
#Region "dim"
        Private _TrxNo As String
        Private _BookingNo As String = ""
        Private _JobNo As String = ""
        Private _ImportJobNo As String = ""
        Private _MasterJobNo As String = ""
        Private _ActualPickupDateTime As DateTime
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _Address3 As String = ""
        Private _Address4 As String = ""
        Private _AlsoNotifyAddress1 As String = ""
        Private _AlsoNotifyAddress2 As String = ""
        Private _AlsoNotifyAddress3 As String = ""
        Private _AlsoNotifyAddress4 As String = ""
        Private _AlsoNotifyCode As String = ""
        Private _AlsoNotifyName As String = ""
        Private _AtaDate As DateTime
        Private _BarCode As String = ""
        Private _BookingDateTime As DateTime
        Private _BookingCustomerCode As String = ""
        Private _BookingCustomerName As String = ""
        Private _BookingSeqNo As String = ""
        Private _CargoClass As String = ""
        Private _CargoType As String = ""
        Private _CloseDateTime As DateTime
        Private _CollectFromAddress1 As String = ""
        Private _CollectFromAddress2 As String = ""
        Private _CollectFromAddress3 As String = ""
        Private _CollectFromAddress4 As String = ""
        Private _CollectFromCode As String = ""
        Private _CollectFromName As String = ""
        Private _ColoaderCode As String = ""
        Private _ColoaderName As String = ""
        Private _ColoaderRefNo As String = ""
        Private _CommodityCode As String = ""
        Private _CommodityDescription As String = ""
        Private _ConsigneeAddress1 As String = ""
        Private _ConsigneeAddress2 As String = ""
        Private _ConsigneeAddress3 As String = ""
        Private _ConsigneeAddress4 As String = ""
        Private _ConsigneeCode As String = ""
        Private _ConsigneeName As String = ""
        Private _ContactEmail As String = ""
        Private _ContactFax As String = ""
        Private _ContactName As String = ""
        Private _ContactTelephone As String = ""
        Private _DeliveryAgentAddress1 As String = ""
        Private _DeliveryAgentAddress2 As String = ""
        Private _DeliveryAgentAddress3 As String = ""
        Private _DeliveryAgentAddress4 As String = ""
        Private _DeliveryAgentCode As String = ""
        Private _DeliveryAgentName As String = ""
        Private _DeliveryInstruction1 As String = ""
        Private _DeliveryInstruction2 As String = ""
        Private _DeliveryInstruction3 As String = ""
        Private _DeliveryInstruction4 As String = ""
        Private _DeliveryInstruction5 As String = ""
        Private _DeliveryToAddress1 As String = ""
        Private _DeliveryToAddress2 As String = ""
        Private _DeliveryToAddress3 As String = ""
        Private _DeliveryToAddress4 As String = ""
        Private _DeliveryToCode As String = ""
        Private _DeliveryToName As String = ""
        Private _DeliveryType As String = ""
        Private _DestCode As String = ""
        Private _DestCargoType As String = ""
        Private _DestEta As DateTime
        Private _DgFlag As String = ""
        Private _DriverCode As String = ""
        Private _DriverContactNo1 As String = ""
        Private _DriverContactNo2 As String = ""
        Private _DivisionCode As String = ""
        Private _EtaDate As DateTime
        Private _EtdDate As DateTime
        Private _FeederVesselName As String = ""
        Private _FeederVoyage As String = ""
        Private _FifthViaPortCode As String = ""
        Private _FirstViaPortCode As String = ""
        Private _FirstViaEtaDate As DateTime
        Private _FlashPoint As String = ""
        Private _Footer1 As String = ""
        Private _Footer2 As String = ""
        Private _Footer3 As String = ""
        Private _Footer4 As String = ""
        Private _Footer5 As String = ""
        Private _ForwardAgentCode As String = ""
        Private _FourthViaPortCode As String = ""
        Private _FrtPpCcFlag As String = ""
        Private _HouseJobNo As String = ""
        Private _Imco As String = ""
        Private _JobDate As DateTime
        Private _JobMth As String = ""
        Private _JobType As String = ""
        Private _LetterOfCreditNo As String = ""
        Private _MotherVesselName As String = ""
        Private _MotherVoyage As String = ""
        Private _NominationFlag As String = ""
        Private _NominationRemark As String = ""
        Private _NoOf20ftContainer As Integer
        Private _NoOf40ftContainer As Integer
        Private _NoOf45ftContainer As Integer
        Private _NotifyAddress1 As String = ""
        Private _NotifyAddress2 As String = ""
        Private _NotifyAddress3 As String = ""
        Private _NotifyAddress4 As String = ""
        Private _NotifyCode As String = ""
        Private _NotifyName As String = ""
        Private _OriginCode As String = ""
        Private _OtherPpCcFlag As String = ""
        Private _PermitNo As String = ""
        Private _PickupDateTime As DateTime
        Private _PickupNo As String = ""
        Private _PlaceOfDelivery As String = ""
        Private _PlaceOfReceipt As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _PrincipleAgentCode As String = ""
        Private _QuotationNo As String = ""
        Private _Remark As String = ""
        Private _RequestTransportNo As String = ""
        Private _SalesmanCode As String = ""
        Private _ScnCode As String = ""
        Private _SecondVesselCode As String = ""
        Private _SecondViaPortCode As String = ""
        Private _SecondVoyageNo As String = ""
        Private _ShipmentType As String = ""
        Private _ShipperAddress1 As String = ""
        Private _ShipperAddress2 As String = ""
        Private _ShipperAddress3 As String = ""
        Private _ShipperAddress4 As String = ""
        Private _ShipperCode As String = ""
        Private _ShipperName As String = ""
        Private _ShippinglineCode As String = ""
        Private _SiteCode As String = ""
        Private _SmkShipAgentCode As String = ""
        Private _SourceCompanyCode As String = ""
        Private _SourceJobNo As String = ""
        Private _SourceSiteCode As String = ""
        Private _StuffAgentAddress1 As String = ""
        Private _StuffAgentAddress2 As String = ""
        Private _StuffAgentAddress3 As String = ""
        Private _StuffAgentAddress4 As String = ""
        Private _StuffAgentCode As String = ""
        Private _StuffAgentName As String = ""
        Private _StuffDate As DateTime
        Private _SubMasterFlag As String = ""
        Private _ThirdViaPortCode As String = ""
        Private _TotalChargeWeight As Decimal
        Private _TotalFIataAmt As Decimal
        Private _TotalGrossWeight As Decimal
        Private _TotalPcs As Integer
        Private _TotalVolume As Decimal
        Private _TransportAddress1 As String = ""
        Private _TransportAddress2 As String = ""
        Private _TransportAddress3 As String = ""
        Private _TransportAddress4 As String = ""
        Private _TransportCompanyCode As String = ""
        Private _TransportCompanyName As String = ""
        Private _UcrNo As String = ""
        Private _UnNo As String = ""
        Private _UserDefine01 As String = ""
        Private _UserDefine02 As String = ""
        Private _UserDefine03 As String = ""
        Private _UserDefine04 As String = ""
        Private _UserDefine05 As String = ""
        Private _UserDefine06 As String = ""
        Private _UserDefine07 As String = ""
        Private _UserDefine08 As String = ""
        Private _UserDefine09 As String = ""
        Private _UserDefine10 As String = ""
        Private _VehicleNo As String = ""
        Private _VesselCode As String = ""
        Private _VesselName As String = ""
        Private _VoyageId As String = ""
        Private _VoyageNo As String = ""
        Private _YardCode As String = ""
        Private _YardName As String = ""
        Private _YardAddress1 As String = ""
        Private _YardAddress2 As String = ""
        Private _YardAddress3 As String = ""
        Private _YardAddress4 As String = ""
        Private _EdiCount As Integer
        Private _EmailCount As Integer
        Private _ExportCount As Integer
        Private _FaxCount As Integer
        Private _PrintCount As Integer
        Private _DeliveryStatusCode As String = ""
        Private _WorkStation As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _StatusCode As String = ""
        Private _DepotCode As String = ""
        Private _DepotName As String = ""
        Private _DepotAddress1 As String = ""
        Private _DepotAddress2 As String = ""
        Private _DepotAddress3 As String = ""
        Private _DepotAddress4 As String = ""
        Private _CustomerRefNo As String = ""
        Private _RailingFlag As String = ""
        Private _ContainerType1 As String = ""
        Private _DeliveryInstruction6 As String = ""
        Private _DeliveryInstruction7 As String = ""
        Private _DeliveryInstruction8 As String = ""
        Private _ContainerType2 As String = ""
        Private _ContainerType3 As String = ""
        Private _ContainerType4 As String = ""
        Private _NoOfContainer1 As Integer
        Private _NoOfContainer2 As Integer
        Private _NoOfContainer3 As Integer
        Private _NoOfContainer4 As Integer
        Private _AttachmentFlag As String = ""
        Private _Driver2Code As String = ""
        Private _Driver2Name As String = ""
        Private _Driver2ContactNo1 As String = ""
        Private _Driver2ContactNo2 As String = ""
        Private _CountryOfOrigin As String = ""
        Private _RailingRemark As String = ""
#End Region
#Region "Property"

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

        Public Property BookingNo() As String
            Set(ByVal value As String)
                If _BookingNo <> value Then
                    _BookingNo = value
                End If
            End Set
            Get
                Return _BookingNo
            End Get
        End Property

        Public Property JobNo() As String
            Set(ByVal value As String)
                If _JobNo <> value Then
                    _JobNo = value
                End If
            End Set
            Get
                Return _JobNo
            End Get
        End Property

        Public Property ImportJobNo() As String
            Set(ByVal value As String)
                If _ImportJobNo <> value Then
                    _ImportJobNo = value
                End If
            End Set
            Get
                Return _ImportJobNo
            End Get
        End Property

        Public Property MasterJobNo() As String
            Set(ByVal value As String)
                If _MasterJobNo <> value Then
                    _MasterJobNo = value
                End If
            End Set
            Get
                Return _MasterJobNo
            End Get
        End Property

        Public Property ActualPickupDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _ActualPickupDateTime <> value Then
                    _ActualPickupDateTime = value
                End If
            End Set
            Get
                Return _ActualPickupDateTime
            End Get
        End Property

        Public Property Address1() As String
            Set(ByVal value As String)
                If _Address1 <> value Then
                    _Address1 = value
                End If
            End Set
            Get
                Return _Address1
            End Get
        End Property

        Public Property Address2() As String
            Set(ByVal value As String)
                If _Address2 <> value Then
                    _Address2 = value
                End If
            End Set
            Get
                Return _Address2
            End Get
        End Property

        Public Property Address3() As String
            Set(ByVal value As String)
                If _Address3 <> value Then
                    _Address3 = value
                End If
            End Set
            Get
                Return _Address3
            End Get
        End Property

        Public Property Address4() As String
            Set(ByVal value As String)
                If _Address4 <> value Then
                    _Address4 = value
                End If
            End Set
            Get
                Return _Address4
            End Get
        End Property

        Public Property AlsoNotifyAddress1() As String
            Set(ByVal value As String)
                If _AlsoNotifyAddress1 <> value Then
                    _AlsoNotifyAddress1 = value
                End If
            End Set
            Get
                Return _AlsoNotifyAddress1
            End Get
        End Property

        Public Property AlsoNotifyAddress2() As String
            Set(ByVal value As String)
                If _AlsoNotifyAddress2 <> value Then
                    _AlsoNotifyAddress2 = value
                End If
            End Set
            Get
                Return _AlsoNotifyAddress2
            End Get
        End Property

        Public Property AlsoNotifyAddress3() As String
            Set(ByVal value As String)
                If _AlsoNotifyAddress3 <> value Then
                    _AlsoNotifyAddress3 = value
                End If
            End Set
            Get
                Return _AlsoNotifyAddress3
            End Get
        End Property

        Public Property AlsoNotifyAddress4() As String
            Set(ByVal value As String)
                If _AlsoNotifyAddress4 <> value Then
                    _AlsoNotifyAddress4 = value
                End If
            End Set
            Get
                Return _AlsoNotifyAddress4
            End Get
        End Property

        Public Property AlsoNotifyCode() As String
            Set(ByVal value As String)
                If _AlsoNotifyCode <> value Then
                    _AlsoNotifyCode = value
                End If
            End Set
            Get
                Return _AlsoNotifyCode
            End Get
        End Property

        Public Property AlsoNotifyName() As String
            Set(ByVal value As String)
                If _AlsoNotifyName <> value Then
                    _AlsoNotifyName = value
                End If
            End Set
            Get
                Return _AlsoNotifyName
            End Get
        End Property

        Public Property AtaDate() As DateTime
            Set(ByVal value As DateTime)
                If _AtaDate <> value Then
                    _AtaDate = value
                End If
            End Set
            Get
                Return _AtaDate
            End Get
        End Property

        Public Property BarCode() As String
            Set(ByVal value As String)
                If _BarCode <> value Then
                    _BarCode = value
                End If
            End Set
            Get
                Return _BarCode
            End Get
        End Property

        Public Property BookingDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _BookingDateTime <> value Then
                    _BookingDateTime = value
                End If
            End Set
            Get
                Return _BookingDateTime
            End Get
        End Property

        Public Property BookingCustomerCode() As String
            Set(ByVal value As String)
                If _BookingCustomerCode <> value Then
                    _BookingCustomerCode = value
                End If
            End Set
            Get
                Return _BookingCustomerCode
            End Get
        End Property

        Public Property BookingCustomerName() As String
            Set(ByVal value As String)
                If _BookingCustomerName <> value Then
                    _BookingCustomerName = value
                End If
            End Set
            Get
                Return _BookingCustomerName
            End Get
        End Property

        Public Property BookingSeqNo() As String
            Set(ByVal value As String)
                If _BookingSeqNo <> value Then
                    _BookingSeqNo = value
                End If
            End Set
            Get
                Return _BookingSeqNo
            End Get
        End Property

        Public Property CargoClass() As String
            Set(ByVal value As String)
                If _CargoClass <> value Then
                    _CargoClass = value
                End If
            End Set
            Get
                Return _CargoClass
            End Get
        End Property

        Public Property CargoType() As String
            Set(ByVal value As String)
                If _CargoType <> value Then
                    _CargoType = value
                End If
            End Set
            Get
                Return _CargoType
            End Get
        End Property

        Public Property CloseDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _CloseDateTime <> value Then
                    _CloseDateTime = value
                End If
            End Set
            Get
                Return _CloseDateTime
            End Get
        End Property

        Public Property CollectFromAddress1() As String
            Set(ByVal value As String)
                If _CollectFromAddress1 <> value Then
                    _CollectFromAddress1 = value
                End If
            End Set
            Get
                Return _CollectFromAddress1
            End Get
        End Property

        Public Property CollectFromAddress2() As String
            Set(ByVal value As String)
                If _CollectFromAddress2 <> value Then
                    _CollectFromAddress2 = value
                End If
            End Set
            Get
                Return _CollectFromAddress2
            End Get
        End Property

        Public Property CollectFromAddress3() As String
            Set(ByVal value As String)
                If _CollectFromAddress3 <> value Then
                    _CollectFromAddress3 = value
                End If
            End Set
            Get
                Return _CollectFromAddress3
            End Get
        End Property

        Public Property CollectFromAddress4() As String
            Set(ByVal value As String)
                If _CollectFromAddress4 <> value Then
                    _CollectFromAddress4 = value
                End If
            End Set
            Get
                Return _CollectFromAddress4
            End Get
        End Property

        Public Property CollectFromCode() As String
            Set(ByVal value As String)
                If _CollectFromCode <> value Then
                    _CollectFromCode = value
                End If
            End Set
            Get
                Return _CollectFromCode
            End Get
        End Property

        Public Property CollectFromName() As String
            Set(ByVal value As String)
                If _CollectFromName <> value Then
                    _CollectFromName = value
                End If
            End Set
            Get
                Return _CollectFromName
            End Get
        End Property

        Public Property ColoaderCode() As String
            Set(ByVal value As String)
                If _ColoaderCode <> value Then
                    _ColoaderCode = value
                End If
            End Set
            Get
                Return _ColoaderCode
            End Get
        End Property

        Public Property ColoaderName() As String
            Set(ByVal value As String)
                If _ColoaderName <> value Then
                    _ColoaderName = value
                End If
            End Set
            Get
                Return _ColoaderName
            End Get
        End Property

        Public Property ColoaderRefNo() As String
            Set(ByVal value As String)
                If _ColoaderRefNo <> value Then
                    _ColoaderRefNo = value
                End If
            End Set
            Get
                Return _ColoaderRefNo
            End Get
        End Property

        Public Property CommodityCode() As String
            Set(ByVal value As String)
                If _CommodityCode <> value Then
                    _CommodityCode = value
                End If
            End Set
            Get
                Return _CommodityCode
            End Get
        End Property

        Public Property CommodityDescription() As String
            Set(ByVal value As String)
                If _CommodityDescription <> value Then
                    _CommodityDescription = value
                End If
            End Set
            Get
                Return _CommodityDescription
            End Get
        End Property

        Public Property ConsigneeAddress1() As String
            Set(ByVal value As String)
                If _ConsigneeAddress1 <> value Then
                    _ConsigneeAddress1 = value
                End If
            End Set
            Get
                Return _ConsigneeAddress1
            End Get
        End Property

        Public Property ConsigneeAddress2() As String
            Set(ByVal value As String)
                If _ConsigneeAddress2 <> value Then
                    _ConsigneeAddress2 = value
                End If
            End Set
            Get
                Return _ConsigneeAddress2
            End Get
        End Property

        Public Property ConsigneeAddress3() As String
            Set(ByVal value As String)
                If _ConsigneeAddress3 <> value Then
                    _ConsigneeAddress3 = value
                End If
            End Set
            Get
                Return _ConsigneeAddress3
            End Get
        End Property

        Public Property ConsigneeAddress4() As String
            Set(ByVal value As String)
                If _ConsigneeAddress4 <> value Then
                    _ConsigneeAddress4 = value
                End If
            End Set
            Get
                Return _ConsigneeAddress4
            End Get
        End Property

        Public Property ConsigneeCode() As String
            Set(ByVal value As String)
                If _ConsigneeCode <> value Then
                    _ConsigneeCode = value
                End If
            End Set
            Get
                Return _ConsigneeCode
            End Get
        End Property

        Public Property ConsigneeName() As String
            Set(ByVal value As String)
                If _ConsigneeName <> value Then
                    _ConsigneeName = value
                End If
            End Set
            Get
                Return _ConsigneeName
            End Get
        End Property

        Public Property ContactEmail() As String
            Set(ByVal value As String)
                If _ContactEmail <> value Then
                    _ContactEmail = value
                End If
            End Set
            Get
                Return _ContactEmail
            End Get
        End Property

        Public Property ContactFax() As String
            Set(ByVal value As String)
                If _ContactFax <> value Then
                    _ContactFax = value
                End If
            End Set
            Get
                Return _ContactFax
            End Get
        End Property

        Public Property ContactName() As String
            Set(ByVal value As String)
                If _ContactName <> value Then
                    _ContactName = value
                End If
            End Set
            Get
                Return _ContactName
            End Get
        End Property

        Public Property ContactTelephone() As String
            Set(ByVal value As String)
                If _ContactTelephone <> value Then
                    _ContactTelephone = value
                End If
            End Set
            Get
                Return _ContactTelephone
            End Get
        End Property

        Public Property DeliveryAgentAddress1() As String
            Set(ByVal value As String)
                If _DeliveryAgentAddress1 <> value Then
                    _DeliveryAgentAddress1 = value
                End If
            End Set
            Get
                Return _DeliveryAgentAddress1
            End Get
        End Property

        Public Property DeliveryAgentAddress2() As String
            Set(ByVal value As String)
                If _DeliveryAgentAddress2 <> value Then
                    _DeliveryAgentAddress2 = value
                End If
            End Set
            Get
                Return _DeliveryAgentAddress2
            End Get
        End Property

        Public Property DeliveryAgentAddress3() As String
            Set(ByVal value As String)
                If _DeliveryAgentAddress3 <> value Then
                    _DeliveryAgentAddress3 = value
                End If
            End Set
            Get
                Return _DeliveryAgentAddress3
            End Get
        End Property

        Public Property DeliveryAgentAddress4() As String
            Set(ByVal value As String)
                If _DeliveryAgentAddress4 <> value Then
                    _DeliveryAgentAddress4 = value
                End If
            End Set
            Get
                Return _DeliveryAgentAddress4
            End Get
        End Property

        Public Property DeliveryAgentCode() As String
            Set(ByVal value As String)
                If _DeliveryAgentCode <> value Then
                    _DeliveryAgentCode = value
                End If
            End Set
            Get
                Return _DeliveryAgentCode
            End Get
        End Property

        Public Property DeliveryAgentName() As String
            Set(ByVal value As String)
                If _DeliveryAgentName <> value Then
                    _DeliveryAgentName = value
                End If
            End Set
            Get
                Return _DeliveryAgentName
            End Get
        End Property

        Public Property DeliveryInstruction1() As String
            Set(ByVal value As String)
                If _DeliveryInstruction1 <> value Then
                    _DeliveryInstruction1 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction1
            End Get
        End Property

        Public Property DeliveryInstruction2() As String
            Set(ByVal value As String)
                If _DeliveryInstruction2 <> value Then
                    _DeliveryInstruction2 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction2
            End Get
        End Property

        Public Property DeliveryInstruction3() As String
            Set(ByVal value As String)
                If _DeliveryInstruction3 <> value Then
                    _DeliveryInstruction3 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction3
            End Get
        End Property

        Public Property DeliveryInstruction4() As String
            Set(ByVal value As String)
                If _DeliveryInstruction4 <> value Then
                    _DeliveryInstruction4 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction4
            End Get
        End Property

        Public Property DeliveryInstruction5() As String
            Set(ByVal value As String)
                If _DeliveryInstruction5 <> value Then
                    _DeliveryInstruction5 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction5
            End Get
        End Property

        Public Property DeliveryToAddress1() As String
            Set(ByVal value As String)
                If _DeliveryToAddress1 <> value Then
                    _DeliveryToAddress1 = value
                End If
            End Set
            Get
                Return _DeliveryToAddress1
            End Get
        End Property

        Public Property DeliveryToAddress2() As String
            Set(ByVal value As String)
                If _DeliveryToAddress2 <> value Then
                    _DeliveryToAddress2 = value
                End If
            End Set
            Get
                Return _DeliveryToAddress2
            End Get
        End Property

        Public Property DeliveryToAddress3() As String
            Set(ByVal value As String)
                If _DeliveryToAddress3 <> value Then
                    _DeliveryToAddress3 = value
                End If
            End Set
            Get
                Return _DeliveryToAddress3
            End Get
        End Property

        Public Property DeliveryToAddress4() As String
            Set(ByVal value As String)
                If _DeliveryToAddress4 <> value Then
                    _DeliveryToAddress4 = value
                End If
            End Set
            Get
                Return _DeliveryToAddress4
            End Get
        End Property

        Public Property DeliveryToCode() As String
            Set(ByVal value As String)
                If _DeliveryToCode <> value Then
                    _DeliveryToCode = value
                End If
            End Set
            Get
                Return _DeliveryToCode
            End Get
        End Property

        Public Property DeliveryToName() As String
            Set(ByVal value As String)
                If _DeliveryToName <> value Then
                    _DeliveryToName = value
                End If
            End Set
            Get
                Return _DeliveryToName
            End Get
        End Property

        Public Property DeliveryType() As String
            Set(ByVal value As String)
                If _DeliveryType <> value Then
                    _DeliveryType = value
                End If
            End Set
            Get
                Return _DeliveryType
            End Get
        End Property

        Public Property DestCode() As String
            Set(ByVal value As String)
                If _DestCode <> value Then
                    _DestCode = value
                End If
            End Set
            Get
                Return _DestCode
            End Get
        End Property

        Public Property DestCargoType() As String
            Set(ByVal value As String)
                If _DestCargoType <> value Then
                    _DestCargoType = value
                End If
            End Set
            Get
                Return _DestCargoType
            End Get
        End Property

        Public Property DestEta() As DateTime
            Set(ByVal value As DateTime)
                If _DestEta <> value Then
                    _DestEta = value
                End If
            End Set
            Get
                Return _DestEta
            End Get
        End Property

        Public Property DgFlag() As String
            Set(ByVal value As String)
                If _DgFlag <> value Then
                    _DgFlag = value
                End If
            End Set
            Get
                Return _DgFlag
            End Get
        End Property

        Public Property DriverCode() As String
            Set(ByVal value As String)
                If _DriverCode <> value Then
                    _DriverCode = value
                End If
            End Set
            Get
                Return _DriverCode
            End Get
        End Property

        Public Property DriverContactNo1() As String
            Set(ByVal value As String)
                If _DriverContactNo1 <> value Then
                    _DriverContactNo1 = value
                End If
            End Set
            Get
                Return _DriverContactNo1
            End Get
        End Property

        Public Property DriverContactNo2() As String
            Set(ByVal value As String)
                If _DriverContactNo2 <> value Then
                    _DriverContactNo2 = value
                End If
            End Set
            Get
                Return _DriverContactNo2
            End Get
        End Property

        Public Property DivisionCode() As String
            Set(ByVal value As String)
                If _DivisionCode <> value Then
                    _DivisionCode = value
                End If
            End Set
            Get
                Return _DivisionCode
            End Get
        End Property

        Public Property EtaDate() As DateTime
            Set(ByVal value As DateTime)
                If _EtaDate <> value Then
                    _EtaDate = value
                End If
            End Set
            Get
                Return _EtaDate
            End Get
        End Property

        Public Property EtdDate() As DateTime
            Set(ByVal value As DateTime)
                If _EtdDate <> value Then
                    _EtdDate = value
                End If
            End Set
            Get
                Return _EtdDate
            End Get
        End Property

        Public Property FeederVesselName() As String
            Set(ByVal value As String)
                If _FeederVesselName <> value Then
                    _FeederVesselName = value
                End If
            End Set
            Get
                Return _FeederVesselName
            End Get
        End Property

        Public Property FeederVoyage() As String
            Set(ByVal value As String)
                If _FeederVoyage <> value Then
                    _FeederVoyage = value
                End If
            End Set
            Get
                Return _FeederVoyage
            End Get
        End Property

        Public Property FifthViaPortCode() As String
            Set(ByVal value As String)
                If _FifthViaPortCode <> value Then
                    _FifthViaPortCode = value
                End If
            End Set
            Get
                Return _FifthViaPortCode
            End Get
        End Property

        Public Property FirstViaPortCode() As String
            Set(ByVal value As String)
                If _FirstViaPortCode <> value Then
                    _FirstViaPortCode = value
                End If
            End Set
            Get
                Return _FirstViaPortCode
            End Get
        End Property

        Public Property FirstViaEtaDate() As DateTime
            Set(ByVal value As DateTime)
                If _FirstViaEtaDate <> value Then
                    _FirstViaEtaDate = value
                End If
            End Set
            Get
                Return _FirstViaEtaDate
            End Get
        End Property

        Public Property FlashPoint() As String
            Set(ByVal value As String)
                If _FlashPoint <> value Then
                    _FlashPoint = value
                End If
            End Set
            Get
                Return _FlashPoint
            End Get
        End Property

        Public Property Footer1() As String
            Set(ByVal value As String)
                If _Footer1 <> value Then
                    _Footer1 = value
                End If
            End Set
            Get
                Return _Footer1
            End Get
        End Property

        Public Property Footer2() As String
            Set(ByVal value As String)
                If _Footer2 <> value Then
                    _Footer2 = value
                End If
            End Set
            Get
                Return _Footer2
            End Get
        End Property

        Public Property Footer3() As String
            Set(ByVal value As String)
                If _Footer3 <> value Then
                    _Footer3 = value
                End If
            End Set
            Get
                Return _Footer3
            End Get
        End Property

        Public Property Footer4() As String
            Set(ByVal value As String)
                If _Footer4 <> value Then
                    _Footer4 = value
                End If
            End Set
            Get
                Return _Footer4
            End Get
        End Property

        Public Property Footer5() As String
            Set(ByVal value As String)
                If _Footer5 <> value Then
                    _Footer5 = value
                End If
            End Set
            Get
                Return _Footer5
            End Get
        End Property

        Public Property ForwardAgentCode() As String
            Set(ByVal value As String)
                If _ForwardAgentCode <> value Then
                    _ForwardAgentCode = value
                End If
            End Set
            Get
                Return _ForwardAgentCode
            End Get
        End Property

        Public Property FourthViaPortCode() As String
            Set(ByVal value As String)
                If _FourthViaPortCode <> value Then
                    _FourthViaPortCode = value
                End If
            End Set
            Get
                Return _FourthViaPortCode
            End Get
        End Property

        Public Property FrtPpCcFlag() As String
            Set(ByVal value As String)
                If _FrtPpCcFlag <> value Then
                    _FrtPpCcFlag = value
                End If
            End Set
            Get
                Return _FrtPpCcFlag
            End Get
        End Property

        Public Property HouseJobNo() As String
            Set(ByVal value As String)
                If _HouseJobNo <> value Then
                    _HouseJobNo = value
                End If
            End Set
            Get
                Return _HouseJobNo
            End Get
        End Property

        Public Property Imco() As String
            Set(ByVal value As String)
                If _Imco <> value Then
                    _Imco = value
                End If
            End Set
            Get
                Return _Imco
            End Get
        End Property

        Public Property JobDate() As DateTime
            Set(ByVal value As DateTime)
                If _JobDate <> value Then
                    _JobDate = value
                End If
            End Set
            Get
                Return _JobDate
            End Get
        End Property

        Public Property JobMth() As String
            Set(ByVal value As String)
                If _JobMth <> value Then
                    _JobMth = value
                End If
            End Set
            Get
                Return _JobMth
            End Get
        End Property

        Public Property JobType() As String
            Set(ByVal value As String)
                If _JobType <> value Then
                    _JobType = value
                End If
            End Set
            Get
                Return _JobType
            End Get
        End Property

        Public Property LetterOfCreditNo() As String
            Set(ByVal value As String)
                If _LetterOfCreditNo <> value Then
                    _LetterOfCreditNo = value
                End If
            End Set
            Get
                Return _LetterOfCreditNo
            End Get
        End Property

        Public Property MotherVesselName() As String
            Set(ByVal value As String)
                If _MotherVesselName <> value Then
                    _MotherVesselName = value
                End If
            End Set
            Get
                Return _MotherVesselName
            End Get
        End Property

        Public Property MotherVoyage() As String
            Set(ByVal value As String)
                If _MotherVoyage <> value Then
                    _MotherVoyage = value
                End If
            End Set
            Get
                Return _MotherVoyage
            End Get
        End Property

        Public Property NominationFlag() As String
            Set(ByVal value As String)
                If _NominationFlag <> value Then
                    _NominationFlag = value
                End If
            End Set
            Get
                Return _NominationFlag
            End Get
        End Property

        Public Property NominationRemark() As String
            Set(ByVal value As String)
                If _NominationRemark <> value Then
                    _NominationRemark = value
                End If
            End Set
            Get
                Return _NominationRemark
            End Get
        End Property

        Public Property NoOf20ftContainer() As Integer
            Set(ByVal value As Integer)
                If _NoOf20ftContainer <> value Then
                    _NoOf20ftContainer = value
                End If
            End Set
            Get
                Return _NoOf20ftContainer
            End Get
        End Property

        Public Property NoOf40ftContainer() As Integer
            Set(ByVal value As Integer)
                If _NoOf40ftContainer <> value Then
                    _NoOf40ftContainer = value
                End If
            End Set
            Get
                Return _NoOf40ftContainer
            End Get
        End Property

        Public Property NoOf45ftContainer() As Integer
            Set(ByVal value As Integer)
                If _NoOf45ftContainer <> value Then
                    _NoOf45ftContainer = value
                End If
            End Set
            Get
                Return _NoOf45ftContainer
            End Get
        End Property

        Public Property NotifyAddress1() As String
            Set(ByVal value As String)
                If _NotifyAddress1 <> value Then
                    _NotifyAddress1 = value
                End If
            End Set
            Get
                Return _NotifyAddress1
            End Get
        End Property

        Public Property NotifyAddress2() As String
            Set(ByVal value As String)
                If _NotifyAddress2 <> value Then
                    _NotifyAddress2 = value
                End If
            End Set
            Get
                Return _NotifyAddress2
            End Get
        End Property

        Public Property NotifyAddress3() As String
            Set(ByVal value As String)
                If _NotifyAddress3 <> value Then
                    _NotifyAddress3 = value
                End If
            End Set
            Get
                Return _NotifyAddress3
            End Get
        End Property

        Public Property NotifyAddress4() As String
            Set(ByVal value As String)
                If _NotifyAddress4 <> value Then
                    _NotifyAddress4 = value
                End If
            End Set
            Get
                Return _NotifyAddress4
            End Get
        End Property

        Public Property NotifyCode() As String
            Set(ByVal value As String)
                If _NotifyCode <> value Then
                    _NotifyCode = value
                End If
            End Set
            Get
                Return _NotifyCode
            End Get
        End Property

        Public Property NotifyName() As String
            Set(ByVal value As String)
                If _NotifyName <> value Then
                    _NotifyName = value
                End If
            End Set
            Get
                Return _NotifyName
            End Get
        End Property

        Public Property OriginCode() As String
            Set(ByVal value As String)
                If _OriginCode <> value Then
                    _OriginCode = value
                End If
            End Set
            Get
                Return _OriginCode
            End Get
        End Property

        Public Property OtherPpCcFlag() As String
            Set(ByVal value As String)
                If _OtherPpCcFlag <> value Then
                    _OtherPpCcFlag = value
                End If
            End Set
            Get
                Return _OtherPpCcFlag
            End Get
        End Property

        Public Property PermitNo() As String
            Set(ByVal value As String)
                If _PermitNo <> value Then
                    _PermitNo = value
                End If
            End Set
            Get
                Return _PermitNo
            End Get
        End Property

        Public Property PickupDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _PickupDateTime <> value Then
                    _PickupDateTime = value
                End If
            End Set
            Get
                Return _PickupDateTime
            End Get
        End Property

        Public Property PickupNo() As String
            Set(ByVal value As String)
                If _PickupNo <> value Then
                    _PickupNo = value
                End If
            End Set
            Get
                Return _PickupNo
            End Get
        End Property

        Public Property PlaceOfDelivery() As String
            Set(ByVal value As String)
                If _PlaceOfDelivery <> value Then
                    _PlaceOfDelivery = value
                End If
            End Set
            Get
                Return _PlaceOfDelivery
            End Get
        End Property

        Public Property PlaceOfReceipt() As String
            Set(ByVal value As String)
                If _PlaceOfReceipt <> value Then
                    _PlaceOfReceipt = value
                End If
            End Set
            Get
                Return _PlaceOfReceipt
            End Get
        End Property

        Public Property PortOfDischargeCode() As String
            Set(ByVal value As String)
                If _PortOfDischargeCode <> value Then
                    _PortOfDischargeCode = value
                End If
            End Set
            Get
                Return _PortOfDischargeCode
            End Get
        End Property

        Public Property PortOfLoadingCode() As String
            Set(ByVal value As String)
                If _PortOfLoadingCode <> value Then
                    _PortOfLoadingCode = value
                End If
            End Set
            Get
                Return _PortOfLoadingCode
            End Get
        End Property

        Public Property PrincipleAgentCode() As String
            Set(ByVal value As String)
                If _PrincipleAgentCode <> value Then
                    _PrincipleAgentCode = value
                End If
            End Set
            Get
                Return _PrincipleAgentCode
            End Get
        End Property

        Public Property QuotationNo() As String
            Set(ByVal value As String)
                If _QuotationNo <> value Then
                    _QuotationNo = value
                End If
            End Set
            Get
                Return _QuotationNo
            End Get
        End Property

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

        Public Property RequestTransportNo() As String
            Set(ByVal value As String)
                If _RequestTransportNo <> value Then
                    _RequestTransportNo = value
                End If
            End Set
            Get
                Return _RequestTransportNo
            End Get
        End Property

        Public Property SalesmanCode() As String
            Set(ByVal value As String)
                If _SalesmanCode <> value Then
                    _SalesmanCode = value
                End If
            End Set
            Get
                Return _SalesmanCode
            End Get
        End Property

        Public Property ScnCode() As String
            Set(ByVal value As String)
                If _ScnCode <> value Then
                    _ScnCode = value
                End If
            End Set
            Get
                Return _ScnCode
            End Get
        End Property

        Public Property SecondVesselCode() As String
            Set(ByVal value As String)
                If _SecondVesselCode <> value Then
                    _SecondVesselCode = value
                End If
            End Set
            Get
                Return _SecondVesselCode
            End Get
        End Property

        Public Property SecondViaPortCode() As String
            Set(ByVal value As String)
                If _SecondViaPortCode <> value Then
                    _SecondViaPortCode = value
                End If
            End Set
            Get
                Return _SecondViaPortCode
            End Get
        End Property

        Public Property SecondVoyageNo() As String
            Set(ByVal value As String)
                If _SecondVoyageNo <> value Then
                    _SecondVoyageNo = value
                End If
            End Set
            Get
                Return _SecondVoyageNo
            End Get
        End Property

        Public Property ShipmentType() As String
            Set(ByVal value As String)
                If _ShipmentType <> value Then
                    _ShipmentType = value
                End If
            End Set
            Get
                Return _ShipmentType
            End Get
        End Property

        Public Property ShipperAddress1() As String
            Set(ByVal value As String)
                If _ShipperAddress1 <> value Then
                    _ShipperAddress1 = value
                End If
            End Set
            Get
                Return _ShipperAddress1
            End Get
        End Property

        Public Property ShipperAddress2() As String
            Set(ByVal value As String)
                If _ShipperAddress2 <> value Then
                    _ShipperAddress2 = value
                End If
            End Set
            Get
                Return _ShipperAddress2
            End Get
        End Property

        Public Property ShipperAddress3() As String
            Set(ByVal value As String)
                If _ShipperAddress3 <> value Then
                    _ShipperAddress3 = value
                End If
            End Set
            Get
                Return _ShipperAddress3
            End Get
        End Property

        Public Property ShipperAddress4() As String
            Set(ByVal value As String)
                If _ShipperAddress4 <> value Then
                    _ShipperAddress4 = value
                End If
            End Set
            Get
                Return _ShipperAddress4
            End Get
        End Property

        Public Property ShipperCode() As String
            Set(ByVal value As String)
                If _ShipperCode <> value Then
                    _ShipperCode = value
                End If
            End Set
            Get
                Return _ShipperCode
            End Get
        End Property

        Public Property ShipperName() As String
            Set(ByVal value As String)
                If _ShipperName <> value Then
                    _ShipperName = value
                End If
            End Set
            Get
                Return _ShipperName
            End Get
        End Property

        Public Property ShippinglineCode() As String
            Set(ByVal value As String)
                If _ShippinglineCode <> value Then
                    _ShippinglineCode = value
                End If
            End Set
            Get
                Return _ShippinglineCode
            End Get
        End Property

        Public Property SiteCode() As String
            Set(ByVal value As String)
                If _SiteCode <> value Then
                    _SiteCode = value
                End If
            End Set
            Get
                Return _SiteCode
            End Get
        End Property

        Public Property SmkShipAgentCode() As String
            Set(ByVal value As String)
                If _SmkShipAgentCode <> value Then
                    _SmkShipAgentCode = value
                End If
            End Set
            Get
                Return _SmkShipAgentCode
            End Get
        End Property

        Public Property SourceCompanyCode() As String
            Set(ByVal value As String)
                If _SourceCompanyCode <> value Then
                    _SourceCompanyCode = value
                End If
            End Set
            Get
                Return _SourceCompanyCode
            End Get
        End Property

        Public Property SourceJobNo() As String
            Set(ByVal value As String)
                If _SourceJobNo <> value Then
                    _SourceJobNo = value
                End If
            End Set
            Get
                Return _SourceJobNo
            End Get
        End Property

        Public Property SourceSiteCode() As String
            Set(ByVal value As String)
                If _SourceSiteCode <> value Then
                    _SourceSiteCode = value
                End If
            End Set
            Get
                Return _SourceSiteCode
            End Get
        End Property

        Public Property StuffAgentAddress1() As String
            Set(ByVal value As String)
                If _StuffAgentAddress1 <> value Then
                    _StuffAgentAddress1 = value
                End If
            End Set
            Get
                Return _StuffAgentAddress1
            End Get
        End Property

        Public Property StuffAgentAddress2() As String
            Set(ByVal value As String)
                If _StuffAgentAddress2 <> value Then
                    _StuffAgentAddress2 = value
                End If
            End Set
            Get
                Return _StuffAgentAddress2
            End Get
        End Property

        Public Property StuffAgentAddress3() As String
            Set(ByVal value As String)
                If _StuffAgentAddress3 <> value Then
                    _StuffAgentAddress3 = value
                End If
            End Set
            Get
                Return _StuffAgentAddress3
            End Get
        End Property

        Public Property StuffAgentAddress4() As String
            Set(ByVal value As String)
                If _StuffAgentAddress4 <> value Then
                    _StuffAgentAddress4 = value
                End If
            End Set
            Get
                Return _StuffAgentAddress4
            End Get
        End Property

        Public Property StuffAgentCode() As String
            Set(ByVal value As String)
                If _StuffAgentCode <> value Then
                    _StuffAgentCode = value
                End If
            End Set
            Get
                Return _StuffAgentCode
            End Get
        End Property

        Public Property StuffAgentName() As String
            Set(ByVal value As String)
                If _StuffAgentName <> value Then
                    _StuffAgentName = value
                End If
            End Set
            Get
                Return _StuffAgentName
            End Get
        End Property

        Public Property StuffDate() As DateTime
            Set(ByVal value As DateTime)
                If _StuffDate <> value Then
                    _StuffDate = value
                End If
            End Set
            Get
                Return _StuffDate
            End Get
        End Property

        Public Property SubMasterFlag() As String
            Set(ByVal value As String)
                If _SubMasterFlag <> value Then
                    _SubMasterFlag = value
                End If
            End Set
            Get
                Return _SubMasterFlag
            End Get
        End Property

        Public Property ThirdViaPortCode() As String
            Set(ByVal value As String)
                If _ThirdViaPortCode <> value Then
                    _ThirdViaPortCode = value
                End If
            End Set
            Get
                Return _ThirdViaPortCode
            End Get
        End Property

        Public Property TotalChargeWeight() As Decimal
            Set(ByVal value As Decimal)
                If _TotalChargeWeight <> value Then
                    _TotalChargeWeight = value
                End If
            End Set
            Get
                Return _TotalChargeWeight
            End Get
        End Property

        Public Property TotalFIataAmt() As Decimal
            Set(ByVal value As Decimal)
                If _TotalFIataAmt <> value Then
                    _TotalFIataAmt = value
                End If
            End Set
            Get
                Return _TotalFIataAmt
            End Get
        End Property

        Public Property TotalGrossWeight() As Decimal
            Set(ByVal value As Decimal)
                If _TotalGrossWeight <> value Then
                    _TotalGrossWeight = value
                End If
            End Set
            Get
                Return _TotalGrossWeight
            End Get
        End Property

        Public Property TotalPcs() As Integer
            Set(ByVal value As Integer)
                If _TotalPcs <> value Then
                    _TotalPcs = value
                End If
            End Set
            Get
                Return _TotalPcs
            End Get
        End Property

        Public Property TotalVolume() As Decimal
            Set(ByVal value As Decimal)
                If _TotalVolume <> value Then
                    _TotalVolume = value
                End If
            End Set
            Get
                Return _TotalVolume
            End Get
        End Property

        Public Property TransportAddress1() As String
            Set(ByVal value As String)
                If _TransportAddress1 <> value Then
                    _TransportAddress1 = value
                End If
            End Set
            Get
                Return _TransportAddress1
            End Get
        End Property

        Public Property TransportAddress2() As String
            Set(ByVal value As String)
                If _TransportAddress2 <> value Then
                    _TransportAddress2 = value
                End If
            End Set
            Get
                Return _TransportAddress2
            End Get
        End Property

        Public Property TransportAddress3() As String
            Set(ByVal value As String)
                If _TransportAddress3 <> value Then
                    _TransportAddress3 = value
                End If
            End Set
            Get
                Return _TransportAddress3
            End Get
        End Property

        Public Property TransportAddress4() As String
            Set(ByVal value As String)
                If _TransportAddress4 <> value Then
                    _TransportAddress4 = value
                End If
            End Set
            Get
                Return _TransportAddress4
            End Get
        End Property

        Public Property TransportCompanyCode() As String
            Set(ByVal value As String)
                If _TransportCompanyCode <> value Then
                    _TransportCompanyCode = value
                End If
            End Set
            Get
                Return _TransportCompanyCode
            End Get
        End Property

        Public Property TransportCompanyName() As String
            Set(ByVal value As String)
                If _TransportCompanyName <> value Then
                    _TransportCompanyName = value
                End If
            End Set
            Get
                Return _TransportCompanyName
            End Get
        End Property

        Public Property UcrNo() As String
            Set(ByVal value As String)
                If _UcrNo <> value Then
                    _UcrNo = value
                End If
            End Set
            Get
                Return _UcrNo
            End Get
        End Property

        Public Property UnNo() As String
            Set(ByVal value As String)
                If _UnNo <> value Then
                    _UnNo = value
                End If
            End Set
            Get
                Return _UnNo
            End Get
        End Property

        Public Property UserDefine01() As String
            Set(ByVal value As String)
                If _UserDefine01 <> value Then
                    _UserDefine01 = value
                End If
            End Set
            Get
                Return _UserDefine01
            End Get
        End Property

        Public Property UserDefine02() As String
            Set(ByVal value As String)
                If _UserDefine02 <> value Then
                    _UserDefine02 = value
                End If
            End Set
            Get
                Return _UserDefine02
            End Get
        End Property

        Public Property UserDefine03() As String
            Set(ByVal value As String)
                If _UserDefine03 <> value Then
                    _UserDefine03 = value
                End If
            End Set
            Get
                Return _UserDefine03
            End Get
        End Property

        Public Property UserDefine04() As String
            Set(ByVal value As String)
                If _UserDefine04 <> value Then
                    _UserDefine04 = value
                End If
            End Set
            Get
                Return _UserDefine04
            End Get
        End Property

        Public Property UserDefine05() As String
            Set(ByVal value As String)
                If _UserDefine05 <> value Then
                    _UserDefine05 = value
                End If
            End Set
            Get
                Return _UserDefine05
            End Get
        End Property

        Public Property UserDefine06() As String
            Set(ByVal value As String)
                If _UserDefine06 <> value Then
                    _UserDefine06 = value
                End If
            End Set
            Get
                Return _UserDefine06
            End Get
        End Property

        Public Property UserDefine07() As String
            Set(ByVal value As String)
                If _UserDefine07 <> value Then
                    _UserDefine07 = value
                End If
            End Set
            Get
                Return _UserDefine07
            End Get
        End Property

        Public Property UserDefine08() As String
            Set(ByVal value As String)
                If _UserDefine08 <> value Then
                    _UserDefine08 = value
                End If
            End Set
            Get
                Return _UserDefine08
            End Get
        End Property

        Public Property UserDefine09() As String
            Set(ByVal value As String)
                If _UserDefine09 <> value Then
                    _UserDefine09 = value
                End If
            End Set
            Get
                Return _UserDefine09
            End Get
        End Property

        Public Property UserDefine10() As String
            Set(ByVal value As String)
                If _UserDefine10 <> value Then
                    _UserDefine10 = value
                End If
            End Set
            Get
                Return _UserDefine10
            End Get
        End Property

        Public Property VehicleNo() As String
            Set(ByVal value As String)
                If _VehicleNo <> value Then
                    _VehicleNo = value
                End If
            End Set
            Get
                Return _VehicleNo
            End Get
        End Property

        Public Property VesselCode() As String
            Set(ByVal value As String)
                If _VesselCode <> value Then
                    _VesselCode = value
                End If
            End Set
            Get
                Return _VesselCode
            End Get
        End Property

        Public Property VesselName() As String
            Set(ByVal value As String)
                If _VesselName <> value Then
                    _VesselName = value
                End If
            End Set
            Get
                Return _VesselName
            End Get
        End Property

        Public Property VoyageId() As String
            Set(ByVal value As String)
                If _VoyageId <> value Then
                    _VoyageId = value
                End If
            End Set
            Get
                Return _VoyageId
            End Get
        End Property

        Public Property VoyageNo() As String
            Set(ByVal value As String)
                If _VoyageNo <> value Then
                    _VoyageNo = value
                End If
            End Set
            Get
                Return _VoyageNo
            End Get
        End Property

        Public Property YardCode() As String
            Set(ByVal value As String)
                If _YardCode <> value Then
                    _YardCode = value
                End If
            End Set
            Get
                Return _YardCode
            End Get
        End Property

        Public Property YardName() As String
            Set(ByVal value As String)
                If _YardName <> value Then
                    _YardName = value
                End If
            End Set
            Get
                Return _YardName
            End Get
        End Property

        Public Property YardAddress1() As String
            Set(ByVal value As String)
                If _YardAddress1 <> value Then
                    _YardAddress1 = value
                End If
            End Set
            Get
                Return _YardAddress1
            End Get
        End Property

        Public Property YardAddress2() As String
            Set(ByVal value As String)
                If _YardAddress2 <> value Then
                    _YardAddress2 = value
                End If
            End Set
            Get
                Return _YardAddress2
            End Get
        End Property

        Public Property YardAddress3() As String
            Set(ByVal value As String)
                If _YardAddress3 <> value Then
                    _YardAddress3 = value
                End If
            End Set
            Get
                Return _YardAddress3
            End Get
        End Property

        Public Property YardAddress4() As String
            Set(ByVal value As String)
                If _YardAddress4 <> value Then
                    _YardAddress4 = value
                End If
            End Set
            Get
                Return _YardAddress4
            End Get
        End Property

        Public Property EdiCount() As Integer
            Set(ByVal value As Integer)
                If _EdiCount <> value Then
                    _EdiCount = value
                End If
            End Set
            Get
                Return _EdiCount
            End Get
        End Property

        Public Property EmailCount() As Integer
            Set(ByVal value As Integer)
                If _EmailCount <> value Then
                    _EmailCount = value
                End If
            End Set
            Get
                Return _EmailCount
            End Get
        End Property

        Public Property ExportCount() As Integer
            Set(ByVal value As Integer)
                If _ExportCount <> value Then
                    _ExportCount = value
                End If
            End Set
            Get
                Return _ExportCount
            End Get
        End Property

        Public Property FaxCount() As Integer
            Set(ByVal value As Integer)
                If _FaxCount <> value Then
                    _FaxCount = value
                End If
            End Set
            Get
                Return _FaxCount
            End Get
        End Property

        Public Property PrintCount() As Integer
            Set(ByVal value As Integer)
                If _PrintCount <> value Then
                    _PrintCount = value
                End If
            End Set
            Get
                Return _PrintCount
            End Get
        End Property

        Public Property DeliveryStatusCode() As String
            Set(ByVal value As String)
                If _DeliveryStatusCode <> value Then
                    _DeliveryStatusCode = value
                End If
            End Set
            Get
                Return _DeliveryStatusCode
            End Get
        End Property

        Public Property WorkStation() As String
            Set(ByVal value As String)
                If _WorkStation <> value Then
                    _WorkStation = value
                End If
            End Set
            Get
                Return _WorkStation
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

        Public Property UpdateBy() As String
            Set(ByVal value As String)
                If _UpdateBy <> value Then
                    _UpdateBy = value
                End If
            End Set
            Get
                Return _UpdateBy
            End Get
        End Property

        Public Property UpdateDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _UpdateDateTime <> value Then
                    _UpdateDateTime = value
                End If
            End Set
            Get
                Return _UpdateDateTime
            End Get
        End Property

        Public Property StatusCode() As String
            Set(ByVal value As String)
                If _StatusCode <> value Then
                    _StatusCode = value
                End If
            End Set
            Get
                Return _StatusCode
            End Get
        End Property

        Public Property DepotCode() As String
            Set(ByVal value As String)
                If _DepotCode <> value Then
                    _DepotCode = value
                End If
            End Set
            Get
                Return _DepotCode
            End Get
        End Property

        Public Property DepotName() As String
            Set(ByVal value As String)
                If _DepotName <> value Then
                    _DepotName = value
                End If
            End Set
            Get
                Return _DepotName
            End Get
        End Property

        Public Property DepotAddress1() As String
            Set(ByVal value As String)
                If _DepotAddress1 <> value Then
                    _DepotAddress1 = value
                End If
            End Set
            Get
                Return _DepotAddress1
            End Get
        End Property

        Public Property DepotAddress2() As String
            Set(ByVal value As String)
                If _DepotAddress2 <> value Then
                    _DepotAddress2 = value
                End If
            End Set
            Get
                Return _DepotAddress2
            End Get
        End Property

        Public Property DepotAddress3() As String
            Set(ByVal value As String)
                If _DepotAddress3 <> value Then
                    _DepotAddress3 = value
                End If
            End Set
            Get
                Return _DepotAddress3
            End Get
        End Property

        Public Property DepotAddress4() As String
            Set(ByVal value As String)
                If _DepotAddress4 <> value Then
                    _DepotAddress4 = value
                End If
            End Set
            Get
                Return _DepotAddress4
            End Get
        End Property

        Public Property CustomerRefNo() As String
            Set(ByVal value As String)
                If _CustomerRefNo <> value Then
                    _CustomerRefNo = value
                End If
            End Set
            Get
                Return _CustomerRefNo
            End Get
        End Property

        Public Property RailingFlag() As String
            Set(ByVal value As String)
                If _RailingFlag <> value Then
                    _RailingFlag = value
                End If
            End Set
            Get
                Return _RailingFlag
            End Get
        End Property

        Public Property ContainerType1() As String
            Set(ByVal value As String)
                If _ContainerType1 <> value Then
                    _ContainerType1 = value
                End If
            End Set
            Get
                Return _ContainerType1
            End Get
        End Property

        Public Property DeliveryInstruction6() As String
            Set(ByVal value As String)
                If _DeliveryInstruction6 <> value Then
                    _DeliveryInstruction6 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction6
            End Get
        End Property

        Public Property DeliveryInstruction7() As String
            Set(ByVal value As String)
                If _DeliveryInstruction7 <> value Then
                    _DeliveryInstruction7 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction7
            End Get
        End Property

        Public Property DeliveryInstruction8() As String
            Set(ByVal value As String)
                If _DeliveryInstruction8 <> value Then
                    _DeliveryInstruction8 = value
                End If
            End Set
            Get
                Return _DeliveryInstruction8
            End Get
        End Property

        Public Property ContainerType2() As String
            Set(ByVal value As String)
                If _ContainerType2 <> value Then
                    _ContainerType2 = value
                End If
            End Set
            Get
                Return _ContainerType2
            End Get
        End Property

        Public Property ContainerType3() As String
            Set(ByVal value As String)
                If _ContainerType3 <> value Then
                    _ContainerType3 = value
                End If
            End Set
            Get
                Return _ContainerType3
            End Get
        End Property

        Public Property ContainerType4() As String
            Set(ByVal value As String)
                If _ContainerType4 <> value Then
                    _ContainerType4 = value
                End If
            End Set
            Get
                Return _ContainerType4
            End Get
        End Property

        Public Property NoOfContainer1() As Integer
            Set(ByVal value As Integer)
                If _NoOfContainer1 <> value Then
                    _NoOfContainer1 = value
                End If
            End Set
            Get
                Return _NoOfContainer1
            End Get
        End Property

        Public Property NoOfContainer2() As Integer
            Set(ByVal value As Integer)
                If _NoOfContainer2 <> value Then
                    _NoOfContainer2 = value
                End If
            End Set
            Get
                Return _NoOfContainer2
            End Get
        End Property

        Public Property NoOfContainer3() As Integer
            Set(ByVal value As Integer)
                If _NoOfContainer3 <> value Then
                    _NoOfContainer3 = value
                End If
            End Set
            Get
                Return _NoOfContainer3
            End Get
        End Property

        Public Property NoOfContainer4() As Integer
            Set(ByVal value As Integer)
                If _NoOfContainer4 <> value Then
                    _NoOfContainer4 = value
                End If
            End Set
            Get
                Return _NoOfContainer4
            End Get
        End Property

        Public Property AttachmentFlag() As String
            Set(ByVal value As String)
                If _AttachmentFlag <> value Then
                    _AttachmentFlag = value
                End If
            End Set
            Get
                Return _AttachmentFlag
            End Get
        End Property

        Public Property Driver2Code() As String
            Set(ByVal value As String)
                If _Driver2Code <> value Then
                    _Driver2Code = value
                End If
            End Set
            Get
                Return _Driver2Code
            End Get
        End Property

        Public Property Driver2Name() As String
            Set(ByVal value As String)
                If _Driver2Name <> value Then
                    _Driver2Name = value
                End If
            End Set
            Get
                Return _Driver2Name
            End Get
        End Property

        Public Property Driver2ContactNo1() As String
            Set(ByVal value As String)
                If _Driver2ContactNo1 <> value Then
                    _Driver2ContactNo1 = value
                End If
            End Set
            Get
                Return _Driver2ContactNo1
            End Get
        End Property

        Public Property Driver2ContactNo2() As String
            Set(ByVal value As String)
                If _Driver2ContactNo2 <> value Then
                    _Driver2ContactNo2 = value
                End If
            End Set
            Get
                Return _Driver2ContactNo2
            End Get
        End Property

        Public Property CountryOfOrigin() As String
            Set(ByVal value As String)
                If _CountryOfOrigin <> value Then
                    _CountryOfOrigin = value
                End If
            End Set
            Get
                Return _CountryOfOrigin
            End Get
        End Property

        Public Property RailingRemark() As String
            Set(ByVal value As String)
                If _RailingRemark <> value Then
                    _RailingRemark = value
                End If
            End Set
            Get
                Return _RailingRemark
            End Get
        End Property


#End Region


#Region "New"
        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _TrxNo = strId
            _BookingNo = ""
            _JobNo = ""
            _ImportJobNo = ""
            _MasterJobNo = ""
            _ActualPickupDateTime = ConDateTime.MinDate
            _Address1 = ""
            _Address2 = ""
            _Address3 = ""
            _Address4 = ""
            _AlsoNotifyAddress1 = ""
            _AlsoNotifyAddress2 = ""
            _AlsoNotifyAddress3 = ""
            _AlsoNotifyAddress4 = ""
            _AlsoNotifyCode = ""
            _AlsoNotifyName = ""
            _AtaDate = ConDateTime.MinDate
            _BarCode = ""
            _BookingDateTime = ConDateTime.MinDate
            _BookingCustomerCode = ""
            _BookingCustomerName = ""
            _BookingSeqNo = ""
            _CargoClass = ""
            _CargoType = ""
            _CloseDateTime = ConDateTime.MinDate
            _CollectFromAddress1 = ""
            _CollectFromAddress2 = ""
            _CollectFromAddress3 = ""
            _CollectFromAddress4 = ""
            _CollectFromCode = ""
            _CollectFromName = ""
            _ColoaderCode = ""
            _ColoaderName = ""
            _ColoaderRefNo = ""
            _CommodityCode = ""
            _CommodityDescription = ""
            _ConsigneeAddress1 = ""
            _ConsigneeAddress2 = ""
            _ConsigneeAddress3 = ""
            _ConsigneeAddress4 = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _ContactEmail = ""
            _ContactFax = ""
            _ContactName = ""
            _ContactTelephone = ""
            _DeliveryAgentAddress1 = ""
            _DeliveryAgentAddress2 = ""
            _DeliveryAgentAddress3 = ""
            _DeliveryAgentAddress4 = ""
            _DeliveryAgentCode = ""
            _DeliveryAgentName = ""
            _DeliveryInstruction1 = ""
            _DeliveryInstruction2 = ""
            _DeliveryInstruction3 = ""
            _DeliveryInstruction4 = ""
            _DeliveryInstruction5 = ""
            _DeliveryToAddress1 = ""
            _DeliveryToAddress2 = ""
            _DeliveryToAddress3 = ""
            _DeliveryToAddress4 = ""
            _DeliveryToCode = ""
            _DeliveryToName = ""
            _DeliveryType = ""
            _DestCode = ""
            _DestCargoType = ""
            _DestEta = ConDateTime.MinDate
            _DgFlag = ""
            _DriverCode = ""
            _DriverContactNo1 = ""
            _DriverContactNo2 = ""
            _DivisionCode = ""
            _EtaDate = ConDateTime.MinDate
            _EtdDate = ConDateTime.MinDate
            _FeederVesselName = ""
            _FeederVoyage = ""
            _FifthViaPortCode = ""
            _FirstViaPortCode = ""
            _FirstViaEtaDate = ConDateTime.MinDate
            _FlashPoint = ""
            _Footer1 = ""
            _Footer2 = ""
            _Footer3 = ""
            _Footer4 = ""
            _Footer5 = ""
            _ForwardAgentCode = ""
            _FourthViaPortCode = ""
            _FrtPpCcFlag = ""
            _HouseJobNo = ""
            _Imco = ""
            _JobDate = ConDateTime.MinDate
            _JobMth = ""
            _JobType = ""
            _LetterOfCreditNo = ""
            _MotherVesselName = ""
            _MotherVoyage = ""
            _NominationFlag = ""
            _NominationRemark = ""
            _NoOf20ftContainer = 0
            _NoOf40ftContainer = 0
            _NoOf45ftContainer = 0
            _NotifyAddress1 = ""
            _NotifyAddress2 = ""
            _NotifyAddress3 = ""
            _NotifyAddress4 = ""
            _NotifyCode = ""
            _NotifyName = ""
            _OriginCode = ""
            _OtherPpCcFlag = ""
            _PermitNo = ""
            _PickupDateTime = ConDateTime.MinDate
            _PickupNo = ""
            _PlaceOfDelivery = ""
            _PlaceOfReceipt = ""
            _PortOfDischargeCode = ""
            _PortOfLoadingCode = ""
            _PrincipleAgentCode = ""
            _QuotationNo = ""
            _Remark = ""
            _RequestTransportNo = ""
            _SalesmanCode = ""
            _ScnCode = ""
            _SecondVesselCode = ""
            _SecondViaPortCode = ""
            _SecondVoyageNo = ""
            _ShipmentType = ""
            _ShipperAddress1 = ""
            _ShipperAddress2 = ""
            _ShipperAddress3 = ""
            _ShipperAddress4 = ""
            _ShipperCode = ""
            _ShipperName = ""
            _ShippinglineCode = ""
            _SiteCode = ""
            _SmkShipAgentCode = ""
            _SourceCompanyCode = ""
            _SourceJobNo = ""
            _SourceSiteCode = ""
            _StuffAgentAddress1 = ""
            _StuffAgentAddress2 = ""
            _StuffAgentAddress3 = ""
            _StuffAgentAddress4 = ""
            _StuffAgentCode = ""
            _StuffAgentName = ""
            _StuffDate = ConDateTime.MinDate
            _SubMasterFlag = ""
            _ThirdViaPortCode = ""
            _TotalChargeWeight = 0
            _TotalFIataAmt = 0
            _TotalGrossWeight = 0
            _TotalPcs = 0
            _TotalVolume = 0
            _TransportAddress1 = ""
            _TransportAddress2 = ""
            _TransportAddress3 = ""
            _TransportAddress4 = ""
            _TransportCompanyCode = ""
            _TransportCompanyName = ""
            _UcrNo = ""
            _UnNo = ""
            _UserDefine01 = ""
            _UserDefine02 = ""
            _UserDefine03 = ""
            _UserDefine04 = ""
            _UserDefine05 = ""
            _UserDefine06 = ""
            _UserDefine07 = ""
            _UserDefine08 = ""
            _UserDefine09 = ""
            _UserDefine10 = ""
            _VehicleNo = ""
            _VesselCode = ""
            _VesselName = ""
            _VoyageId = ""
            _VoyageNo = ""
            _YardCode = ""
            _YardName = ""
            _YardAddress1 = ""
            _YardAddress2 = ""
            _YardAddress3 = ""
            _YardAddress4 = ""
            _EdiCount = 0
            _EmailCount = 0
            _ExportCount = 0
            _FaxCount = 0
            _PrintCount = 0
            _DeliveryStatusCode = ""
            _WorkStation = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _StatusCode = ""
            _DepotCode = ""
            _DepotName = ""
            _DepotAddress1 = ""
            _DepotAddress2 = ""
            _DepotAddress3 = ""
            _DepotAddress4 = ""
            _CustomerRefNo = ""
            _RailingFlag = ""
            _ContainerType1 = ""
            _DeliveryInstruction6 = ""
            _DeliveryInstruction7 = ""
            _DeliveryInstruction8 = ""
            _ContainerType2 = ""
            _ContainerType3 = ""
            _ContainerType4 = ""
            _NoOfContainer1 = 0
            _NoOfContainer2 = 0
            _NoOfContainer3 = 0
            _NoOfContainer4 = 0
            _AttachmentFlag = ""
            _Driver2Code = ""
            _Driver2Name = ""
            _Driver2ContactNo1 = ""
            _Driver2ContactNo2 = ""
            _CountryOfOrigin = ""
            _RailingRemark = ""

        End Sub
#End Region




    End Class

#End Region
End Namespace
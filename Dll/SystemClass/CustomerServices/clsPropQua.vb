Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Qua Info "

    <Serializable()> _
    Public Class clsPropQua
        Inherits clsProp
        Private _TrxNo As Integer
        Private _BlNo As String = ""
        Private _OBlNo As String = ""
        Private _BookingNo As String = ""
        Private _JobNo As String = ""
        Private _MasterJobNo As String = ""
        Private _AgentCcAmt As Decimal
        Private _AgentCode As String = ""
        Private _AgentPpAmt As Decimal
        Private _AlsoNotifyAcctCode As String = ""
        Private _AlsoNotifyAddress1 As String = ""
        Private _AlsoNotifyAddress2 As String = ""
        Private _AlsoNotifyAddress3 As String = ""
        Private _AlsoNotifyAddress4 As String = ""
        Private _AlsoNotifyCode As String = ""
        Private _AlsoNotifyName As String = ""
        Private _AtaDate As DateTime
        Private _AttachmentFlag As String = ""
        Private _BillingDate As DateTime
        Private _BillingInstruction As String = ""
        Private _BlAttachFlag As String = ""
        Private _BlIssueDate As DateTime
        Private _BlIssuePlace As String = ""
        Private _BlSurrenderFlag As String = ""
        Private _CargoType As String = ""
        Private _CargoClass As String = ""
        Private _CarMarking As String = ""
        Private _CarrierCcAmt As Decimal
        Private _CarrierPpAmt As Decimal
        Private _CloseDateTime As DateTime
        Private _CloseConsol As String = ""
        Private _ColoaderCode As String = ""
        Private _ColoaderName As String = ""
        Private _ColoaderRefNo As String = ""
        Private _CommodityCode As String = ""
        Private _CommodityDescription As String = ""
        Private _ConsigneeAccCode As String = ""
        Private _ConsigneeAddress1 As String = ""
        Private _ConsigneeAddress2 As String = ""
        Private _ConsigneeAddress3 As String = ""
        Private _ConsigneeAddress4 As String = ""
        Private _ConsigneeCode As String = ""
        Private _ConsigneeName As String = ""
        Private _ContainerNo As String = ""
        Private _ContainerSealNo As String = ""
        Private _ContainerSealNoType As String = ""
        Private _ContainerType1 As String = ""
        Private _ContainerType2 As String = ""
        Private _ContainerType3 As String = ""
        Private _ContainerType4 As String = ""
        Private _CurrCode As String = ""
        Private _CurrRate As Decimal
        Private _CustomerCode As String = ""
        Private _CustomerName As String = ""
        Private _DeliveryAgentAddress1 As String = ""
        Private _DeliveryAgentAddress2 As String = ""
        Private _DeliveryAgentAddress3 As String = ""
        Private _DeliveryAgentAddress4 As String = ""
        Private _DeliveryAgentCode As String = ""
        Private _DeliveryAgentName As String = ""
        Private _DeliveryPcs As Integer
        Private _DeliveryType As String = ""
        Private _DepotAddress1 As String = ""
        Private _DepotAddress2 As String = ""
        Private _DepotAddress3 As String = ""
        Private _DepotAddress4 As String = ""
        Private _DepotCode As String = ""
        Private _DepotName As String = ""
        Private _DestCargoType As String = ""
        Private _DestCode As String = ""
        Private _DestName As String = ""
        Private _DestEta As DateTime
        Private _Difference As Decimal
        Private _DivisionCode As String = ""
        Private _EtaDate As DateTime
        Private _EtdDate As DateTime
        Private _FeederVesselName As String = ""
        Private _FeederVoyage As String = ""
        Private _FifthViaPortCode As String = ""
        Private _FirstViaPortCode As String = ""
        Private _FirstViaEtaDate As DateTime
        Private _Footer1 As String = ""
        Private _Footer2 As String = ""
        Private _Footer3 As String = ""
        Private _Footer4 As String = ""
        Private _Footer5 As String = ""
        Private _FourthViaPortCode As String = ""
        Private _FrtBillPartyCode As String = ""
        Private _FrtCollectFromConsignee As Decimal
        Private _FrtPayableDest As Decimal
        Private _FrtPpCcFlag As String = ""
        Private _FrtPrepaidByShipper As Decimal
        Private _FrtPrepaidToShippingCo As Decimal
        Private _GrossWeight As Decimal
        Private _HandlingFee As Decimal
        Private _HouseJobNo As String = ""
        Private _ImportJobNo As String = ""
        Private _InsuranceAmt As Decimal
        Private _JobDate As DateTime
        Private _JobMth As String = ""
        Private _JobType As String = ""
        Private _LadenDate As DateTime
        Private _LetterOfCreditNo As String = ""
        Private _LotNo As String = ""
        Private _MaxGrossWeight As Decimal
        Private _MaxVolume As Decimal
        Private _NoOf20ftContainer As Integer
        Private _NoOf40ftContainer As Integer
        Private _NoOf45ftContainer As Integer
        Private _NoOfContainer1 As Integer
        Private _NoOfContainer2 As Integer
        Private _NoOfContainer3 As Integer
        Private _NoOfContainer4 As Integer
        Private _NoOfOriginBl As Integer
        Private _NotifyAcctCode As String = ""
        Private _NotifyAddress1 As String = ""
        Private _NotifyAddress2 As String = ""
        Private _NotifyAddress3 As String = ""
        Private _NotifyAddress4 As String = ""
        Private _NotifyCode As String = ""
        Private _NotifyName As String = ""
        Private _OriginCode As String = ""
        Private _OtherBillPartyCode As String = ""
        Private _OtherPpCcFlag As String = ""
        Private _PayableAt As String = ""
        Private _PermitNo As String = ""
        Private _PlaceOfDelivery As String = ""
        Private _PlaceOfReceipt As String = ""
        Private _Pcs As Integer
        Private _PrincipleAgentCode As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _PortOfDischargeName As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _PortOfLoadingName As String = ""
        Private _PpAt As String = ""
        Private _PpAmt As Decimal
        Private _ProfitShare As Decimal
        Private _QuotationNo As String = ""
        Private _Remark As String = ""
        Private _SalesCoordinator1 As String = ""
        Private _SalesCoordinator2 As String = ""
        Private _SalesDescription1 As String = ""
        Private _SalesDescription2 As String = ""
        Private _SalesmanCode As String = ""
        Private _ScnCode As String = ""
        Private _SecondViaPortCode As String = ""
        Private _ShipmentType As String = ""
        Private _ShipperAccCode As String = ""
        Private _ShipperAddress1 As String = ""
        Private _ShipperAddress2 As String = ""
        Private _ShipperAddress3 As String = ""
        Private _ShipperAddress4 As String = ""
        Private _ShipperCode As String = ""
        Private _ShipperCountFlag As String = ""
        Private _ShipperName As String = ""
        Private _ShippingDescription As String = ""
        Private _ShippinglineCode As String = ""
        Private _ShippingMarkNo As String = ""
        Private _ShippingPkg As String = ""
        Private _SignBy As String = ""
        Private _SmkShipAgentCode As String = ""
        Private _SourceJobNo As String = ""
        Private _SourceCompanyCode As String = ""
        Private _SourceSiteCode As String = ""
        Private _StuffAgentAddress1 As String = ""
        Private _StuffAgentAddress2 As String = ""
        Private _StuffAgentAddress3 As String = ""
        Private _StuffAgentAddress4 As String = ""
        Private _StuffAgentCode As String = ""
        Private _StuffAgentName As String = ""
        Private _StuffDate As DateTime
        Private _SubMasterFlag As String = ""
        Private _TargetJobNo As String = ""
        Private _TargetCompanyCode As String = ""
        Private _TargetSiteCode As String = ""
        Private _TaxCcAmt As Decimal
        Private _TaxPpAmt As Decimal
        Private _TaxRefundCompanyCode As String = ""
        Private _TaxRefundCompanyName As String = ""
        Private _TaxRefundNo As String = ""
        Private _TaxRefundIssueDate As DateTime
        Private _TaxRefundReturnDate As DateTime
        Private _TelexReleaseFlag As String = ""
        Private _TemplateName As String = ""
        Private _ThirdViaPortCode As String = ""
        Private _TnMindefFlag As String = ""
        Private _TnAgentFlag As String = ""
        Private _TotalChargeWeight As Decimal
        Private _TotalGrossWeight As Decimal
        Private _TotalPcs As Integer
        Private _TotalPcsInWord As String = ""
        Private _TotalVolume As Decimal
        Private _TradenetVersion As String = ""
        Private _UcrNo As String = ""
        Private _UserDefine10 As String = ""
        Private _UserDefine09 As String = ""
        Private _UserDefine08 As String = ""
        Private _UserDefine07 As String = ""
        Private _UserDefine06 As String = ""
        Private _UserDefine05 As String = ""
        Private _UserDefine04 As String = ""
        Private _UserDefine03 As String = ""
        Private _UserDefine02 As String = ""
        Private _UserDefine01 As String = ""
        Private _VesselCode As String = ""
        Private _VesselName As String = ""
        Private _Volume As Decimal
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
        Private _SiteCode As String = ""
        Private _WorkStation As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _StatusCode As String = ""
        Private _OriginDescription As String = ""


        Public Property TrxNo() As Integer
            Set(ByVal value As Integer)
                If _TrxNo <> value Then
                    _TrxNo = value
                End If
            End Set
            Get
                Return _TrxNo
            End Get
        End Property

        Public Property BlNo() As String
            Set(ByVal value As String)
                If _BlNo <> value Then
                    _BlNo = value
                End If
            End Set
            Get
                Return _BlNo
            End Get
        End Property

        Public Property OBlNo() As String
            Set(ByVal value As String)
                If _OBlNo <> value Then
                    _OBlNo = value
                End If
            End Set
            Get
                Return _OBlNo
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

        Public Property AgentCcAmt() As Decimal
            Set(ByVal value As Decimal)
                If _AgentCcAmt <> value Then
                    _AgentCcAmt = value
                End If
            End Set
            Get
                Return _AgentCcAmt
            End Get
        End Property

        Public Property AgentCode() As String
            Set(ByVal value As String)
                If _AgentCode <> value Then
                    _AgentCode = value
                End If
            End Set
            Get
                Return _AgentCode
            End Get
        End Property

        Public Property AgentPpAmt() As Decimal
            Set(ByVal value As Decimal)
                If _AgentPpAmt <> value Then
                    _AgentPpAmt = value
                End If
            End Set
            Get
                Return _AgentPpAmt
            End Get
        End Property

        Public Property AlsoNotifyAcctCode() As String
            Set(ByVal value As String)
                If _AlsoNotifyAcctCode <> value Then
                    _AlsoNotifyAcctCode = value
                End If
            End Set
            Get
                Return _AlsoNotifyAcctCode
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

        Public Property BillingDate() As DateTime
            Set(ByVal value As DateTime)
                If _BillingDate <> value Then
                    _BillingDate = value
                End If
            End Set
            Get
                Return _BillingDate
            End Get
        End Property

        Public Property BillingInstruction() As String
            Set(ByVal value As String)
                If _BillingInstruction <> value Then
                    _BillingInstruction = value
                End If
            End Set
            Get
                Return _BillingInstruction
            End Get
        End Property

        Public Property BlAttachFlag() As String
            Set(ByVal value As String)
                If _BlAttachFlag <> value Then
                    _BlAttachFlag = value
                End If
            End Set
            Get
                Return _BlAttachFlag
            End Get
        End Property

        Public Property BlIssueDate() As DateTime
            Set(ByVal value As DateTime)
                If _BlIssueDate <> value Then
                    _BlIssueDate = value
                End If
            End Set
            Get
                Return _BlIssueDate
            End Get
        End Property

        Public Property BlIssuePlace() As String
            Set(ByVal value As String)
                If _BlIssuePlace <> value Then
                    _BlIssuePlace = value
                End If
            End Set
            Get
                Return _BlIssuePlace
            End Get
        End Property

        Public Property BlSurrenderFlag() As String
            Set(ByVal value As String)
                If _BlSurrenderFlag <> value Then
                    _BlSurrenderFlag = value
                End If
            End Set
            Get
                Return _BlSurrenderFlag
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

        Public Property CarMarking() As String
            Set(ByVal value As String)
                If _CarMarking <> value Then
                    _CarMarking = value
                End If
            End Set
            Get
                Return _CarMarking
            End Get
        End Property

        Public Property CarrierCcAmt() As Decimal
            Set(ByVal value As Decimal)
                If _CarrierCcAmt <> value Then
                    _CarrierCcAmt = value
                End If
            End Set
            Get
                Return _CarrierCcAmt
            End Get
        End Property

        Public Property CarrierPpAmt() As Decimal
            Set(ByVal value As Decimal)
                If _CarrierPpAmt <> value Then
                    _CarrierPpAmt = value
                End If
            End Set
            Get
                Return _CarrierPpAmt
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

        Public Property CloseConsol() As String
            Set(ByVal value As String)
                If _CloseConsol <> value Then
                    _CloseConsol = value
                End If
            End Set
            Get
                Return _CloseConsol
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

        Public Property ConsigneeAccCode() As String
            Set(ByVal value As String)
                If _ConsigneeAccCode <> value Then
                    _ConsigneeAccCode = value
                End If
            End Set
            Get
                Return _ConsigneeAccCode
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

        Public Property ContainerSealNo() As String
            Set(ByVal value As String)
                If _ContainerSealNo <> value Then
                    _ContainerSealNo = value
                End If
            End Set
            Get
                Return _ContainerSealNo
            End Get
        End Property

        Public Property ContainerSealNoType() As String
            Set(ByVal value As String)
                If _ContainerSealNoType <> value Then
                    _ContainerSealNoType = value
                End If
            End Set
            Get
                Return _ContainerSealNoType
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

        Public Property CurrCode() As String
            Set(ByVal value As String)
                If _CurrCode <> value Then
                    _CurrCode = value
                End If
            End Set
            Get
                Return _CurrCode
            End Get
        End Property

        Public Property CurrRate() As Decimal
            Set(ByVal value As Decimal)
                If _CurrRate <> value Then
                    _CurrRate = value
                End If
            End Set
            Get
                Return _CurrRate
            End Get
        End Property

        Public Property CustomerCode() As String
            Set(ByVal value As String)
                If _CustomerCode <> value Then
                    _CustomerCode = value
                End If
            End Set
            Get
                Return _CustomerCode
            End Get
        End Property

        Public Property CustomerName() As String
            Set(ByVal value As String)
                If _CustomerName <> value Then
                    _CustomerName = value
                End If
            End Set
            Get
                Return _CustomerName
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

        Public Property DeliveryPcs() As Integer
            Set(ByVal value As Integer)
                If _DeliveryPcs <> value Then
                    _DeliveryPcs = value
                End If
            End Set
            Get
                Return _DeliveryPcs
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

        Public Property DestName() As String
            Set(ByVal value As String)
                If _DestName <> value Then
                    _DestName = value
                End If
            End Set
            Get
                Return _DestName
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

        Public Property Difference() As Decimal
            Set(ByVal value As Decimal)
                If _Difference <> value Then
                    _Difference = value
                End If
            End Set
            Get
                Return _Difference
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

        Public Property FrtBillPartyCode() As String
            Set(ByVal value As String)
                If _FrtBillPartyCode <> value Then
                    _FrtBillPartyCode = value
                End If
            End Set
            Get
                Return _FrtBillPartyCode
            End Get
        End Property

        Public Property FrtCollectFromConsignee() As Decimal
            Set(ByVal value As Decimal)
                If _FrtCollectFromConsignee <> value Then
                    _FrtCollectFromConsignee = value
                End If
            End Set
            Get
                Return _FrtCollectFromConsignee
            End Get
        End Property

        Public Property FrtPayableDest() As Decimal
            Set(ByVal value As Decimal)
                If _FrtPayableDest <> value Then
                    _FrtPayableDest = value
                End If
            End Set
            Get
                Return _FrtPayableDest
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

        Public Property FrtPrepaidByShipper() As Decimal
            Set(ByVal value As Decimal)
                If _FrtPrepaidByShipper <> value Then
                    _FrtPrepaidByShipper = value
                End If
            End Set
            Get
                Return _FrtPrepaidByShipper
            End Get
        End Property

        Public Property FrtPrepaidToShippingCo() As Decimal
            Set(ByVal value As Decimal)
                If _FrtPrepaidToShippingCo <> value Then
                    _FrtPrepaidToShippingCo = value
                End If
            End Set
            Get
                Return _FrtPrepaidToShippingCo
            End Get
        End Property

        Public Property GrossWeight() As Decimal
            Set(ByVal value As Decimal)
                If _GrossWeight <> value Then
                    _GrossWeight = value
                End If
            End Set
            Get
                Return _GrossWeight
            End Get
        End Property

        Public Property HandlingFee() As Decimal
            Set(ByVal value As Decimal)
                If _HandlingFee <> value Then
                    _HandlingFee = value
                End If
            End Set
            Get
                Return _HandlingFee
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

        Public Property InsuranceAmt() As Decimal
            Set(ByVal value As Decimal)
                If _InsuranceAmt <> value Then
                    _InsuranceAmt = value
                End If
            End Set
            Get
                Return _InsuranceAmt
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

        Public Property LadenDate() As DateTime
            Set(ByVal value As DateTime)
                If _LadenDate <> value Then
                    _LadenDate = value
                End If
            End Set
            Get
                Return _LadenDate
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

        Public Property LotNo() As String
            Set(ByVal value As String)
                If _LotNo <> value Then
                    _LotNo = value
                End If
            End Set
            Get
                Return _LotNo
            End Get
        End Property

        Public Property MaxGrossWeight() As Decimal
            Set(ByVal value As Decimal)
                If _MaxGrossWeight <> value Then
                    _MaxGrossWeight = value
                End If
            End Set
            Get
                Return _MaxGrossWeight
            End Get
        End Property

        Public Property MaxVolume() As Decimal
            Set(ByVal value As Decimal)
                If _MaxVolume <> value Then
                    _MaxVolume = value
                End If
            End Set
            Get
                Return _MaxVolume
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

        Public Property NoOfOriginBl() As Integer
            Set(ByVal value As Integer)
                If _NoOfOriginBl <> value Then
                    _NoOfOriginBl = value
                End If
            End Set
            Get
                Return _NoOfOriginBl
            End Get
        End Property

        Public Property NotifyAcctCode() As String
            Set(ByVal value As String)
                If _NotifyAcctCode <> value Then
                    _NotifyAcctCode = value
                End If
            End Set
            Get
                Return _NotifyAcctCode
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

        Public Property OtherBillPartyCode() As String
            Set(ByVal value As String)
                If _OtherBillPartyCode <> value Then
                    _OtherBillPartyCode = value
                End If
            End Set
            Get
                Return _OtherBillPartyCode
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

        Public Property PayableAt() As String
            Set(ByVal value As String)
                If _PayableAt <> value Then
                    _PayableAt = value
                End If
            End Set
            Get
                Return _PayableAt
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

        Public Property Pcs() As Integer
            Set(ByVal value As Integer)
                If _Pcs <> value Then
                    _Pcs = value
                End If
            End Set
            Get
                Return _Pcs
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

        Public Property PortOfDischargeName() As String
            Set(ByVal value As String)
                If _PortOfDischargeName <> value Then
                    _PortOfDischargeName = value
                End If
            End Set
            Get
                Return _PortOfDischargeName
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

        Public Property PortOfLoadingName() As String
            Set(ByVal value As String)
                If _PortOfLoadingName <> value Then
                    _PortOfLoadingName = value
                End If
            End Set
            Get
                Return _PortOfLoadingName
            End Get
        End Property

        Public Property PpAt() As String
            Set(ByVal value As String)
                If _PpAt <> value Then
                    _PpAt = value
                End If
            End Set
            Get
                Return _PpAt
            End Get
        End Property

        Public Property PpAmt() As Decimal
            Set(ByVal value As Decimal)
                If _PpAmt <> value Then
                    _PpAmt = value
                End If
            End Set
            Get
                Return _PpAmt
            End Get
        End Property

        Public Property ProfitShare() As Decimal
            Set(ByVal value As Decimal)
                If _ProfitShare <> value Then
                    _ProfitShare = value
                End If
            End Set
            Get
                Return _ProfitShare
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

        Public Property SalesCoordinator1() As String
            Set(ByVal value As String)
                If _SalesCoordinator1 <> value Then
                    _SalesCoordinator1 = value
                End If
            End Set
            Get
                Return _SalesCoordinator1
            End Get
        End Property

        Public Property SalesCoordinator2() As String
            Set(ByVal value As String)
                If _SalesCoordinator2 <> value Then
                    _SalesCoordinator2 = value
                End If
            End Set
            Get
                Return _SalesCoordinator2
            End Get
        End Property

        Public Property SalesDescription1() As String
            Set(ByVal value As String)
                If _SalesDescription1 <> value Then
                    _SalesDescription1 = value
                End If
            End Set
            Get
                Return _SalesDescription1
            End Get
        End Property

        Public Property SalesDescription2() As String
            Set(ByVal value As String)
                If _SalesDescription2 <> value Then
                    _SalesDescription2 = value
                End If
            End Set
            Get
                Return _SalesDescription2
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

        Public Property ShipperAccCode() As String
            Set(ByVal value As String)
                If _ShipperAccCode <> value Then
                    _ShipperAccCode = value
                End If
            End Set
            Get
                Return _ShipperAccCode
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

        Public Property ShipperCountFlag() As String
            Set(ByVal value As String)
                If _ShipperCountFlag <> value Then
                    _ShipperCountFlag = value
                End If
            End Set
            Get
                Return _ShipperCountFlag
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

        Public Property ShippingDescription() As String
            Set(ByVal value As String)
                If _ShippingDescription <> value Then
                    _ShippingDescription = value
                End If
            End Set
            Get
                Return _ShippingDescription
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

        Public Property ShippingMarkNo() As String
            Set(ByVal value As String)
                If _ShippingMarkNo <> value Then
                    _ShippingMarkNo = value
                End If
            End Set
            Get
                Return _ShippingMarkNo
            End Get
        End Property

        Public Property ShippingPkg() As String
            Set(ByVal value As String)
                If _ShippingPkg <> value Then
                    _ShippingPkg = value
                End If
            End Set
            Get
                Return _ShippingPkg
            End Get
        End Property

        Public Property SignBy() As String
            Set(ByVal value As String)
                If _SignBy <> value Then
                    _SignBy = value
                End If
            End Set
            Get
                Return _SignBy
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

        Public Property TargetJobNo() As String
            Set(ByVal value As String)
                If _TargetJobNo <> value Then
                    _TargetJobNo = value
                End If
            End Set
            Get
                Return _TargetJobNo
            End Get
        End Property

        Public Property TargetCompanyCode() As String
            Set(ByVal value As String)
                If _TargetCompanyCode <> value Then
                    _TargetCompanyCode = value
                End If
            End Set
            Get
                Return _TargetCompanyCode
            End Get
        End Property

        Public Property TargetSiteCode() As String
            Set(ByVal value As String)
                If _TargetSiteCode <> value Then
                    _TargetSiteCode = value
                End If
            End Set
            Get
                Return _TargetSiteCode
            End Get
        End Property

        Public Property TaxCcAmt() As Decimal
            Set(ByVal value As Decimal)
                If _TaxCcAmt <> value Then
                    _TaxCcAmt = value
                End If
            End Set
            Get
                Return _TaxCcAmt
            End Get
        End Property

        Public Property TaxPpAmt() As Decimal
            Set(ByVal value As Decimal)
                If _TaxPpAmt <> value Then
                    _TaxPpAmt = value
                End If
            End Set
            Get
                Return _TaxPpAmt
            End Get
        End Property

        Public Property TaxRefundCompanyCode() As String
            Set(ByVal value As String)
                If _TaxRefundCompanyCode <> value Then
                    _TaxRefundCompanyCode = value
                End If
            End Set
            Get
                Return _TaxRefundCompanyCode
            End Get
        End Property

        Public Property TaxRefundCompanyName() As String
            Set(ByVal value As String)
                If _TaxRefundCompanyName <> value Then
                    _TaxRefundCompanyName = value
                End If
            End Set
            Get
                Return _TaxRefundCompanyName
            End Get
        End Property

        Public Property TaxRefundNo() As String
            Set(ByVal value As String)
                If _TaxRefundNo <> value Then
                    _TaxRefundNo = value
                End If
            End Set
            Get
                Return _TaxRefundNo
            End Get
        End Property

        Public Property TaxRefundIssueDate() As DateTime
            Set(ByVal value As DateTime)
                If _TaxRefundIssueDate <> value Then
                    _TaxRefundIssueDate = value
                End If
            End Set
            Get
                Return _TaxRefundIssueDate
            End Get
        End Property

        Public Property TaxRefundReturnDate() As DateTime
            Set(ByVal value As DateTime)
                If _TaxRefundReturnDate <> value Then
                    _TaxRefundReturnDate = value
                End If
            End Set
            Get
                Return _TaxRefundReturnDate
            End Get
        End Property

        Public Property TelexReleaseFlag() As String
            Set(ByVal value As String)
                If _TelexReleaseFlag <> value Then
                    _TelexReleaseFlag = value
                End If
            End Set
            Get
                Return _TelexReleaseFlag
            End Get
        End Property

        Public Property TemplateName() As String
            Set(ByVal value As String)
                If _TemplateName <> value Then
                    _TemplateName = value
                End If
            End Set
            Get
                Return _TemplateName
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

        Public Property TnMindefFlag() As String
            Set(ByVal value As String)
                If _TnMindefFlag <> value Then
                    _TnMindefFlag = value
                End If
            End Set
            Get
                Return _TnMindefFlag
            End Get
        End Property

        Public Property TnAgentFlag() As String
            Set(ByVal value As String)
                If _TnAgentFlag <> value Then
                    _TnAgentFlag = value
                End If
            End Set
            Get
                Return _TnAgentFlag
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

        Public Property TotalPcsInWord() As String
            Set(ByVal value As String)
                If _TotalPcsInWord <> value Then
                    _TotalPcsInWord = value
                End If
            End Set
            Get
                Return _TotalPcsInWord
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

        Public Property TradenetVersion() As String
            Set(ByVal value As String)
                If _TradenetVersion <> value Then
                    _TradenetVersion = value
                End If
            End Set
            Get
                Return _TradenetVersion
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

        Public Property Volume() As Decimal
            Set(ByVal value As Decimal)
                If _Volume <> value Then
                    _Volume = value
                End If
            End Set
            Get
                Return _Volume
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

        Public Property OriginDescription() As String
            Set(ByVal value As String)
                If _OriginDescription <> value Then
                    _OriginDescription = value
                End If
            End Set
            Get
                Return _OriginDescription
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _BlNo = ""
            _OBlNo = ""
            _BookingNo = ""
            _JobNo = ""
            _MasterJobNo = ""
            _AgentCcAmt = 0
            _AgentCode = ""
            _AgentPpAmt = 0
            _AlsoNotifyAcctCode = ""
            _AlsoNotifyAddress1 = ""
            _AlsoNotifyAddress2 = ""
            _AlsoNotifyAddress3 = ""
            _AlsoNotifyAddress4 = ""
            _AlsoNotifyCode = ""
            _AlsoNotifyName = ""
            _AtaDate = ConDateTime.MinDate
            _AttachmentFlag = ""
            _BillingDate = ConDateTime.MinDate
            _BillingInstruction = ""
            _BlAttachFlag = ""
            _BlIssueDate = ConDateTime.MinDate
            _BlIssuePlace = ""
            _BlSurrenderFlag = ""
            _CargoType = ""
            _CargoClass = ""
            _CarMarking = ""
            _CarrierCcAmt = 0
            _CarrierPpAmt = 0
            _CloseDateTime = ConDateTime.MinDate
            _CloseConsol = ""
            _ColoaderCode = ""
            _ColoaderName = ""
            _ColoaderRefNo = ""
            _CommodityCode = ""
            _CommodityDescription = ""
            _ConsigneeAccCode = ""
            _ConsigneeAddress1 = ""
            _ConsigneeAddress2 = ""
            _ConsigneeAddress3 = ""
            _ConsigneeAddress4 = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _ContainerNo = ""
            _ContainerSealNo = ""
            _ContainerSealNoType = ""
            _ContainerType1 = ""
            _ContainerType2 = ""
            _ContainerType3 = ""
            _ContainerType4 = ""
            _CurrCode = ""
            _CurrRate = 0
            _CustomerCode = ""
            _CustomerName = ""
            _DeliveryAgentAddress1 = ""
            _DeliveryAgentAddress2 = ""
            _DeliveryAgentAddress3 = ""
            _DeliveryAgentAddress4 = ""
            _DeliveryAgentCode = ""
            _DeliveryAgentName = ""
            _DeliveryPcs = 0
            _DeliveryType = ""
            _DepotAddress1 = ""
            _DepotAddress2 = ""
            _DepotAddress3 = ""
            _DepotAddress4 = ""
            _DepotCode = ""
            _DepotName = ""
            _DestCargoType = ""
            _DestCode = ""
            _DestName = ""
            _DestEta = ConDateTime.MinDate
            _Difference = 0
            _DivisionCode = ""
            _EtaDate = ConDateTime.MinDate
            _EtdDate = ConDateTime.MinDate
            _FeederVesselName = ""
            _FeederVoyage = ""
            _FifthViaPortCode = ""
            _FirstViaPortCode = ""
            _FirstViaEtaDate = ConDateTime.MinDate
            _Footer1 = ""
            _Footer2 = ""
            _Footer3 = ""
            _Footer4 = ""
            _Footer5 = ""
            _FourthViaPortCode = ""
            _FrtBillPartyCode = ""
            _FrtCollectFromConsignee = 0
            _FrtPayableDest = 0
            _FrtPpCcFlag = ""
            _FrtPrepaidByShipper = 0
            _FrtPrepaidToShippingCo = 0
            _GrossWeight = 0
            _HandlingFee = 0
            _HouseJobNo = ""
            _ImportJobNo = ""
            _InsuranceAmt = 0
            _JobDate = ConDateTime.MinDate
            _JobMth = ""
            _JobType = ""
            _LadenDate = ConDateTime.MinDate
            _LetterOfCreditNo = ""
            _LotNo = ""
            _MaxGrossWeight = 0
            _MaxVolume = 0
            _NoOf20ftContainer = 0
            _NoOf40ftContainer = 0
            _NoOf45ftContainer = 0
            _NoOfContainer1 = 0
            _NoOfContainer2 = 0
            _NoOfContainer3 = 0
            _NoOfContainer4 = 0
            _NoOfOriginBl = 0
            _NotifyAcctCode = ""
            _NotifyAddress1 = ""
            _NotifyAddress2 = ""
            _NotifyAddress3 = ""
            _NotifyAddress4 = ""
            _NotifyCode = ""
            _NotifyName = ""
            _OriginCode = ""
            _OtherBillPartyCode = ""
            _OtherPpCcFlag = ""
            _PayableAt = ""
            _PermitNo = ""
            _PlaceOfDelivery = ""
            _PlaceOfReceipt = ""
            _Pcs = 0
            _PrincipleAgentCode = ""
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _PortOfLoadingCode = ""
            _PortOfLoadingName = ""
            _PpAt = ""
            _PpAmt = 0
            _ProfitShare = 0
            _QuotationNo = ""
            _Remark = ""
            _SalesCoordinator1 = ""
            _SalesCoordinator2 = ""
            _SalesDescription1 = ""
            _SalesDescription2 = ""
            _SalesmanCode = ""
            _ScnCode = ""
            _SecondViaPortCode = ""
            _ShipmentType = ""
            _ShipperAccCode = ""
            _ShipperAddress1 = ""
            _ShipperAddress2 = ""
            _ShipperAddress3 = ""
            _ShipperAddress4 = ""
            _ShipperCode = ""
            _ShipperCountFlag = ""
            _ShipperName = ""
            _ShippingDescription = ""
            _ShippinglineCode = ""
            _ShippingMarkNo = ""
            _ShippingPkg = ""
            _SignBy = ""
            _SmkShipAgentCode = ""
            _SourceJobNo = ""
            _SourceCompanyCode = ""
            _SourceSiteCode = ""
            _StuffAgentAddress1 = ""
            _StuffAgentAddress2 = ""
            _StuffAgentAddress3 = ""
            _StuffAgentAddress4 = ""
            _StuffAgentCode = ""
            _StuffAgentName = ""
            _StuffDate = ConDateTime.MinDate
            _SubMasterFlag = ""
            _TargetJobNo = ""
            _TargetCompanyCode = ""
            _TargetSiteCode = ""
            _TaxCcAmt = 0
            _TaxPpAmt = 0
            _TaxRefundCompanyCode = ""
            _TaxRefundCompanyName = ""
            _TaxRefundNo = ""
            _TaxRefundIssueDate = ConDateTime.MinDate
            _TaxRefundReturnDate = ConDateTime.MinDate
            _TelexReleaseFlag = ""
            _TemplateName = ""
            _ThirdViaPortCode = ""
            _TnMindefFlag = ""
            _TnAgentFlag = ""
            _TotalChargeWeight = 0
            _TotalGrossWeight = 0
            _TotalPcs = 0
            _TotalPcsInWord = ""
            _TotalVolume = 0
            _TradenetVersion = ""
            _UcrNo = ""
            _UserDefine10 = ""
            _UserDefine09 = ""
            _UserDefine08 = ""
            _UserDefine07 = ""
            _UserDefine06 = ""
            _UserDefine05 = ""
            _UserDefine04 = ""
            _UserDefine03 = ""
            _UserDefine02 = ""
            _UserDefine01 = ""
            _VesselCode = ""
            _VesselName = ""
            _Volume = 0
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
            _SiteCode = ""
            _WorkStation = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _StatusCode = ""
            _OriginDescription = ""
        End Sub

    End Class

#End Region
End Namespace
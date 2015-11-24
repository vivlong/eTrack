Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of BillofLading Info "

    <Serializable()> _
    Public Class clsPropBillofLading
        Inherits clsProp
#Region "dim"
        Private _TrxNo As String = ""
        Private _BlNo As String = ""
        Private _OBlNo As String = ""
        Private _BookingNo As String = ""
        Private _JobNo As String = ""
        Private _MasterJobNo As String = ""
        Private _AgentCcAmt As String = ""
        Private _AgentCode As String = ""
        Private _AgentPpAmt As String = ""
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
        Private _CarrierCcAmt As String = ""
        Private _CarrierPpAmt As String = ""
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
        Private _CurrCode As String = ""
        Private _CurrRate As String = ""
        Private _CustomerCode As String = ""
        Private _CustomerName As String = ""
        Private _DeliveryAgentAddress1 As String = ""
        Private _DeliveryAgentAddress2 As String = ""
        Private _DeliveryAgentAddress3 As String = ""
        Private _DeliveryAgentAddress4 As String = ""
        Private _DeliveryAgentCode As String = ""
        Private _DeliveryAgentName As String = ""
        Private _DeliveryPcs As String = ""
        Private _DeliveryType As String = ""
        Private _DepotAddress1 As String = ""
        Private _DepotAddress2 As String = ""
        Private _DepotAddress3 As String = ""
        Private _DepotAddress4 As String = ""
        Private _DepotCode As String = ""
        Private _DepotName As String = ""
        Private _DestCargoType As String = ""
        Private _DestCode As String = ""
        Private _DestEta As String = ""
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
        Private _FrtPpCcFlag As String = ""
        Private _FrtPrepaidByShipper As String = ""
        Private _FrtCollectFromConsignee As String = ""
        Private _FrtPrepaidToShippingCo As String = ""
        Private _FrtPayableDest As String = ""
        Private _HandlingFee As String = ""
        Private _ProfitShare As String = ""
        Private _Difference As String = ""
        Private _GrossWeight As String = ""
        Private _HouseJobNo As String = ""
        Private _ImportJobNo As String = ""
        Private _InsuranceAmt As String = ""
        Private _JobDate As DateTime
        Private _JobMth As String = ""
        Private _JobType As String = ""
        Private _LadenDate As DateTime
        Private _LetterOfCreditNo As String = ""
        Private _LotNo As String = ""
        Private _MaxGrossWeight As String = ""
        Private _MaxVolume As String = ""
        Private _NoOf20ftContainer As String = ""
        Private _NoOf40ftContainer As String = ""
        Private _NoOf45ftContainer As String = ""
        Private _NoOfOriginBl As String = ""
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
        Private _Pcs As String = ""
        Private _PrincipleAgentCode As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _PortOfDischargeName As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _PortOfLoadingName As String = ""
        Private _PpAt As String = ""
        Private _PpAmt As String = ""
        Private _QuotationNo As String = ""
        Private _Remark As String = ""
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
        Private _TaxCcAmt As String = ""
        Private _TaxPpAmt As String = ""
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
        Private _TotalChargeWeight As String = ""
        Private _TotalGrossWeight As String = ""
        Private _TotalPcs As String = ""
        Private _TotalPcsInWord As String = ""
        Private _TotalVolume As String = ""
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
        Private _Volume As String = ""
        Private _VoyageId As String = ""
        Private _VoyageNo As String = ""
        Private _YardCode As String = ""
        Private _YardName As String = ""
        Private _YardAddress1 As String = ""
        Private _YardAddress2 As String = ""
        Private _YardAddress3 As String = ""
        Private _YardAddress4 As String = ""
        Private _EdiCount As String = ""
        Private _EmailCount As String = ""
        Private _ExportCount As String = ""
        Private _FaxCount As String = ""
        Private _PrintCount As String = ""
        Private _SiteCode As String = ""
        Private _WorkStation As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _StatusCode As String = ""
        'from sibl 
        Private _AirExportFlag As String = ""
        Private _AppointAgentCode As String = ""
        Private _AppointAgentName As String = ""
        Private _AppointAgentAddress1 As String = ""
        Private _AppointAgentAddress2 As String = ""
        Private _AppointAgentAddress3 As String = ""
        Private _AppointAgentAddress4 As String = ""
        Private _AppointAgentContactName As String = ""
        Private _AppointAgentFax As String = ""
        Private _AppointAgentTelephone As String = ""
        Private _ArrivalDateTime As DateTime
        Private _BarCode As String = ""
        Private _BillMode As String = ""
        Private _BillToCode As String = ""
        Private _BreakBulkAgentCode As String = ""
        Private _BreakBulkAgentName As String = ""
        Private _BreakBulkAgentAddress1 As String = ""
        Private _BreakBulkAgentAddress2 As String = ""
        Private _BreakBulkAgentAddress3 As String = ""
        Private _BreakBulkAgentAddress4 As String = ""
        Private _ByWhom As String = ""
        Private _CargoRcvDate As DateTime
        Private _CargoReadyDate As DateTime
        Private _CargoReceiptDate As DateTime
        Private _ClearBy As String = ""
        Private _ClearDateTime As DateTime
        Private _ClearingRemark As String = ""
        Private _ClientCode As String = ""
        Private _CollectFromCode As String = ""
        Private _CollectFromName As String = ""
        Private _CollectFromAddress1 As String = ""
        Private _CollectFromAddress2 As String = ""
        Private _CollectFromAddress3 As String = ""
        Private _CollectFromAddress4 As String = ""
        Private _ContainerSealNoType As String = ""
        Private _ContrFlag As String = ""
        Private _CrNo As String = ""
        Private _CustomerContactName As String = ""
        Private _CustomerRefNo As String = ""
        Private _DeliveryDate As DateTime
        Private _DeliveryInstruction1 As String = ""
        Private _DeliveryInstruction2 As String = ""
        Private _DeliveryInstruction3 As String = ""
        Private _DeliveryInstruction4 As String = ""
        Private _DeliveryInstruction5 As String = ""
        Private _DeliveryInstruction6 As String = ""
        Private _DeliveryInstruction7 As String = ""
        Private _DeliveryInstruction8 As String = ""
        Private _DeliveryOrderNo As String = ""
        Private _DeliveryOrderReadyFlag As String = ""
        Private _DeliveryOrderReleaseDate As DateTime
        Private _DeliveryOrderReleaseTo As String = ""
        Private _DeliveryToCode As String = ""
        Private _DeliveryToName As String = ""
        Private _DeliveryToAddress1 As String = ""
        Private _DeliveryToAddress2 As String = ""
        Private _DeliveryToAddress3 As String = ""
        Private _DeliveryToAddress4 As String = ""
        Private _DgFlag As String = ""
        Private _DocRcvDate As DateTime
        Private _ExportBookingNo As String = ""
        Private _ExportColoaderCode As String = ""
        Private _ExportColoaderName As String = ""
        Private _ExportColoaderRefNo As String = ""
        Private _ExportEta As DateTime
        Private _ExportEtd As DateTime
        Private _ExportJobNo As String = ""
        Private _ExportNote As String = ""
        Private _ExportPortOfDischargeCode As String = ""
        Private _ExportVesselCode As String = ""
        Private _ExportVesselName As String = ""
        Private _ExportVoyage As String = ""
        Private _FlashPoint As String = ""
        Private _HaulierRemark As String = ""
        Private _HBlNo As String = ""
        Private _Imco As String = ""
        Private _ImportCurrCode As String = ""
        Private _ImportRate As Decimal
        Private _MotherVesselName As String = ""
        Private _MotherVoyage As String = ""
        Private _NBlNo As String = ""
        Private _NominationFlag As String = ""
        Private _NominationRemark As String = ""
        Private _Note As String = ""
        Private _NvoccCode As String = ""
        Private _OriginBlNo As String = ""
        Private _PayableAmt As String = ""
        Private _PhoneNo As String = ""
        Private _Rebate As Decimal
        Private _RecStatus As String = ""
        Private _SBlNo As String = ""
        Private _SeaExportFlag As String = ""
        Private _ShipDate As DateTime
        Private _ShipmentId As String = ""
        Private _ShipMode As String = ""
        Private _SupplierCurrCode As String = ""
        Private _SwitchConsigneeCode As String = ""
        Private _SwitchConsigneeName As String = ""
        Private _SwitchConsigneeAddress1 As String = ""
        Private _SwitchConsigneeAddress2 As String = ""
        Private _SwitchConsigneeAddress3 As String = ""
        Private _SwitchConsigneeAddress4 As String = ""
        Private _SwitchDeliveryAgentCode As String = ""
        Private _SwitchDeliveryAgentName As String = ""
        Private _SwitchDeliveryAgentAddress1 As String = ""
        Private _SwitchDeliveryAgentAddress2 As String = ""
        Private _SwitchDeliveryAgentAddress3 As String = ""
        Private _SwitchDeliveryAgentAddress4 As String = ""
        Private _SwitchNotifyCode As String = ""
        Private _SwitchNotifyName As String = ""
        Private _SwitchNotifyAddress1 As String = ""
        Private _SwitchNotifyAddress2 As String = ""
        Private _SwitchNotifyAddress3 As String = ""
        Private _SwitchNotifyAddress4 As String = ""
        Private _SwitchShipperCode As String = ""
        Private _SwitchShipperName As String = ""
        Private _SwitchShipperAddress1 As String = ""
        Private _SwitchShipperAddress2 As String = ""
        Private _SwitchShipperAddress3 As String = ""
        Private _SwitchShipperAddress4 As String = ""
        Private _TotalContainer As String = ""
        Private _TranshipmentCurrCode As String = ""
        Private _TranshipmentFlag As String = ""
        Private _TranshipmentRate As Decimal
        Private _TranshipmentRateRemark As String = ""
        Private _TransportCompanyCode As String = ""
        Private _TransportCompanyName As String = ""
        Private _TransportCompanyAddress1 As String = ""
        Private _TransportCompanyAddress2 As String = ""
        Private _TransportCompanyAddress3 As String = ""
        Private _TransportCompanyAddress4 As String = ""
        Private _TransportCompanyContactName As String = ""
        Private _TransportCompanyFax As String = ""
        Private _TransportCompanyTelephone As String = ""
        Private _TrkReceiptDate As DateTime
        Private _TrkRcvDate As DateTime
        Private _TruckerCode As String = ""
        Private _TruckerName As String = ""
        Private _TruckingDate As DateTime
        Private _UnNo As String = ""
        Private _UnstuffDate As DateTime
        Private _UomCode As String = ""
        Private _WarehouseChargeTemplateName As String = ""
#End Region
#Region "Property"
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property FrtPrepaidByShipper() As String
            Set(ByVal value As String)
                If _FrtPrepaidByShipper <> value Then
                    _FrtPrepaidByShipper = value
                End If
            End Set
            Get
                Return _FrtPrepaidByShipper
            End Get
        End Property
        ' 
        Public Property FrtCollectFromConsignee() As String
            Set(ByVal value As String)
                If _FrtCollectFromConsignee <> value Then
                    _FrtCollectFromConsignee = value
                End If
            End Set
            Get
                Return _FrtCollectFromConsignee
            End Get
        End Property
        ' 
        Public Property FrtPrepaidToShippingCo() As String
            Set(ByVal value As String)
                If _FrtPrepaidToShippingCo <> value Then
                    _FrtPrepaidToShippingCo = value
                End If
            End Set
            Get
                Return _FrtPrepaidToShippingCo
            End Get
        End Property
        ' 
        Public Property FrtPayableDest() As String
            Set(ByVal value As String)
                If _FrtPayableDest <> value Then
                    _FrtPayableDest = value
                End If
            End Set
            Get
                Return _FrtPayableDest
            End Get
        End Property
        ' 
        Public Property HandlingFee() As String
            Set(ByVal value As String)
                If _HandlingFee <> value Then
                    _HandlingFee = value
                End If
            End Set
            Get
                Return _HandlingFee
            End Get
        End Property
        ' 
        Public Property ProfitShare() As String
            Set(ByVal value As String)
                If _ProfitShare <> value Then
                    _ProfitShare = value
                End If
            End Set
            Get
                Return _ProfitShare
            End Get
        End Property
        ' 
        Public Property Difference() As String
            Set(ByVal value As String)
                If _Difference <> value Then
                    _Difference = value
                End If
            End Set
            Get
                Return _Difference
            End Get
        End Property
        ' 
        Public Property GrossWeight() As String
            Set(ByVal value As String)
                If _GrossWeight <> value Then
                    _GrossWeight = value
                End If
            End Set
            Get
                Return _GrossWeight
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
        Public Property MaxGrossWeight() As String
            Set(ByVal value As String)
                If _MaxGrossWeight <> value Then
                    _MaxGrossWeight = value
                End If
            End Set
            Get
                Return _MaxGrossWeight
            End Get
        End Property
        ' 
        Public Property MaxVolume() As String
            Set(ByVal value As String)
                If _MaxVolume <> value Then
                    _MaxVolume = value
                End If
            End Set
            Get
                Return _MaxVolume
            End Get
        End Property

        ' 
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
        Public Property PpAmt() As String
            Set(ByVal value As String)
                If _PpAmt <> value Then
                    _PpAmt = value
                End If
            End Set
            Get
                Return _PpAmt
            End Get
        End Property

        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property Volume() As String
            Set(ByVal value As String)
                If _Volume <> value Then
                    _Volume = value
                End If
            End Set
            Get
                Return _Volume
            End Get
        End Property
        ' 
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

        Public Property AirExportFlag() As String
            Set(ByVal value As String)
                If _AirExportFlag <> value Then
                    _AirExportFlag = value
                End If
            End Set
            Get
                Return _AirExportFlag
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

        Public Property AppointAgentCode() As String
            Set(ByVal value As String)
                If _AppointAgentCode <> value Then
                    _AppointAgentCode = value
                End If
            End Set
            Get
                Return _AppointAgentCode
            End Get
        End Property

        Public Property AppointAgentName() As String
            Set(ByVal value As String)
                If _AppointAgentName <> value Then
                    _AppointAgentName = value
                End If
            End Set
            Get
                Return _AppointAgentName
            End Get
        End Property

        Public Property AppointAgentAddress1() As String
            Set(ByVal value As String)
                If _AppointAgentAddress1 <> value Then
                    _AppointAgentAddress1 = value
                End If
            End Set
            Get
                Return _AppointAgentAddress1
            End Get
        End Property

        Public Property AppointAgentAddress2() As String
            Set(ByVal value As String)
                If _AppointAgentAddress2 <> value Then
                    _AppointAgentAddress2 = value
                End If
            End Set
            Get
                Return _AppointAgentAddress2
            End Get
        End Property

        Public Property AppointAgentAddress3() As String
            Set(ByVal value As String)
                If _AppointAgentAddress3 <> value Then
                    _AppointAgentAddress3 = value
                End If
            End Set
            Get
                Return _AppointAgentAddress3
            End Get
        End Property

        Public Property AppointAgentAddress4() As String
            Set(ByVal value As String)
                If _AppointAgentAddress4 <> value Then
                    _AppointAgentAddress4 = value
                End If
            End Set
            Get
                Return _AppointAgentAddress4
            End Get
        End Property

        Public Property AppointAgentContactName() As String
            Set(ByVal value As String)
                If _AppointAgentContactName <> value Then
                    _AppointAgentContactName = value
                End If
            End Set
            Get
                Return _AppointAgentContactName
            End Get
        End Property

        Public Property AppointAgentFax() As String
            Set(ByVal value As String)
                If _AppointAgentFax <> value Then
                    _AppointAgentFax = value
                End If
            End Set
            Get
                Return _AppointAgentFax
            End Get
        End Property

        Public Property AppointAgentTelephone() As String
            Set(ByVal value As String)
                If _AppointAgentTelephone <> value Then
                    _AppointAgentTelephone = value
                End If
            End Set
            Get
                Return _AppointAgentTelephone
            End Get
        End Property

        Public Property ArrivalDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _ArrivalDateTime <> value Then
                    _ArrivalDateTime = value
                End If
            End Set
            Get
                Return _ArrivalDateTime
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

        Public Property BillMode() As String
            Set(ByVal value As String)
                If _BillMode <> value Then
                    _BillMode = value
                End If
            End Set
            Get
                Return _BillMode
            End Get
        End Property

        Public Property BillToCode() As String
            Set(ByVal value As String)
                If _BillToCode <> value Then
                    _BillToCode = value
                End If
            End Set
            Get
                Return _BillToCode
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

        Public Property BreakBulkAgentCode() As String
            Set(ByVal value As String)
                If _BreakBulkAgentCode <> value Then
                    _BreakBulkAgentCode = value
                End If
            End Set
            Get
                Return _BreakBulkAgentCode
            End Get
        End Property

        Public Property BreakBulkAgentName() As String
            Set(ByVal value As String)
                If _BreakBulkAgentName <> value Then
                    _BreakBulkAgentName = value
                End If
            End Set
            Get
                Return _BreakBulkAgentName
            End Get
        End Property

        Public Property BreakBulkAgentAddress1() As String
            Set(ByVal value As String)
                If _BreakBulkAgentAddress1 <> value Then
                    _BreakBulkAgentAddress1 = value
                End If
            End Set
            Get
                Return _BreakBulkAgentAddress1
            End Get
        End Property

        Public Property BreakBulkAgentAddress2() As String
            Set(ByVal value As String)
                If _BreakBulkAgentAddress2 <> value Then
                    _BreakBulkAgentAddress2 = value
                End If
            End Set
            Get
                Return _BreakBulkAgentAddress2
            End Get
        End Property

        Public Property BreakBulkAgentAddress3() As String
            Set(ByVal value As String)
                If _BreakBulkAgentAddress3 <> value Then
                    _BreakBulkAgentAddress3 = value
                End If
            End Set
            Get
                Return _BreakBulkAgentAddress3
            End Get
        End Property

        Public Property BreakBulkAgentAddress4() As String
            Set(ByVal value As String)
                If _BreakBulkAgentAddress4 <> value Then
                    _BreakBulkAgentAddress4 = value
                End If
            End Set
            Get
                Return _BreakBulkAgentAddress4
            End Get
        End Property

        Public Property ByWhom() As String
            Set(ByVal value As String)
                If _ByWhom <> value Then
                    _ByWhom = value
                End If
            End Set
            Get
                Return _ByWhom
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

        Public Property CargoRcvDate() As DateTime
            Set(ByVal value As DateTime)
                If _CargoRcvDate <> value Then
                    _CargoRcvDate = value
                End If
            End Set
            Get
                Return _CargoRcvDate
            End Get
        End Property

        Public Property CargoReadyDate() As DateTime
            Set(ByVal value As DateTime)
                If _CargoReadyDate <> value Then
                    _CargoReadyDate = value
                End If
            End Set
            Get
                Return _CargoReadyDate
            End Get
        End Property

        Public Property CargoReceiptDate() As DateTime
            Set(ByVal value As DateTime)
                If _CargoReceiptDate <> value Then
                    _CargoReceiptDate = value
                End If
            End Set
            Get
                Return _CargoReceiptDate
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

        Public Property ClearBy() As String
            Set(ByVal value As String)
                If _ClearBy <> value Then
                    _ClearBy = value
                End If
            End Set
            Get
                Return _ClearBy
            End Get
        End Property

        Public Property ClearDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _ClearDateTime <> value Then
                    _ClearDateTime = value
                End If
            End Set
            Get
                Return _ClearDateTime
            End Get
        End Property

        Public Property ClearingRemark() As String
            Set(ByVal value As String)
                If _ClearingRemark <> value Then
                    _ClearingRemark = value
                End If
            End Set
            Get
                Return _ClearingRemark
            End Get
        End Property

        Public Property ClientCode() As String
            Set(ByVal value As String)
                If _ClientCode <> value Then
                    _ClientCode = value
                End If
            End Set
            Get
                Return _ClientCode
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

        Public Property ContrFlag() As String
            Set(ByVal value As String)
                If _ContrFlag <> value Then
                    _ContrFlag = value
                End If
            End Set
            Get
                Return _ContrFlag
            End Get
        End Property

        Public Property CrNo() As String
            Set(ByVal value As String)
                If _CrNo <> value Then
                    _CrNo = value
                End If
            End Set
            Get
                Return _CrNo
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

        Public Property CustomerContactName() As String
            Set(ByVal value As String)
                If _CustomerContactName <> value Then
                    _CustomerContactName = value
                End If
            End Set
            Get
                Return _CustomerContactName
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

        Public Property DeliveryDate() As DateTime
            Set(ByVal value As DateTime)
                If _DeliveryDate <> value Then
                    _DeliveryDate = value
                End If
            End Set
            Get
                Return _DeliveryDate
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

        Public Property DeliveryOrderNo() As String
            Set(ByVal value As String)
                If _DeliveryOrderNo <> value Then
                    _DeliveryOrderNo = value
                End If
            End Set
            Get
                Return _DeliveryOrderNo
            End Get
        End Property

        Public Property DeliveryOrderReadyFlag() As String
            Set(ByVal value As String)
                If _DeliveryOrderReadyFlag <> value Then
                    _DeliveryOrderReadyFlag = value
                End If
            End Set
            Get
                Return _DeliveryOrderReadyFlag
            End Get
        End Property

        Public Property DeliveryOrderReleaseDate() As DateTime
            Set(ByVal value As DateTime)
                If _DeliveryOrderReleaseDate <> value Then
                    _DeliveryOrderReleaseDate = value
                End If
            End Set
            Get
                Return _DeliveryOrderReleaseDate
            End Get
        End Property

        Public Property DeliveryOrderReleaseTo() As String
            Set(ByVal value As String)
                If _DeliveryOrderReleaseTo <> value Then
                    _DeliveryOrderReleaseTo = value
                End If
            End Set
            Get
                Return _DeliveryOrderReleaseTo
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

        Public Property DocRcvDate() As DateTime
            Set(ByVal value As DateTime)
                If _DocRcvDate <> value Then
                    _DocRcvDate = value
                End If
            End Set
            Get
                Return _DocRcvDate
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

        Public Property ExportBookingNo() As String
            Set(ByVal value As String)
                If _ExportBookingNo <> value Then
                    _ExportBookingNo = value
                End If
            End Set
            Get
                Return _ExportBookingNo
            End Get
        End Property

        Public Property ExportColoaderCode() As String
            Set(ByVal value As String)
                If _ExportColoaderCode <> value Then
                    _ExportColoaderCode = value
                End If
            End Set
            Get
                Return _ExportColoaderCode
            End Get
        End Property

        Public Property ExportColoaderName() As String
            Set(ByVal value As String)
                If _ExportColoaderName <> value Then
                    _ExportColoaderName = value
                End If
            End Set
            Get
                Return _ExportColoaderName
            End Get
        End Property

        Public Property ExportColoaderRefNo() As String
            Set(ByVal value As String)
                If _ExportColoaderRefNo <> value Then
                    _ExportColoaderRefNo = value
                End If
            End Set
            Get
                Return _ExportColoaderRefNo
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

        Public Property ExportEta() As DateTime
            Set(ByVal value As DateTime)
                If _ExportEta <> value Then
                    _ExportEta = value
                End If
            End Set
            Get
                Return _ExportEta
            End Get
        End Property

        Public Property ExportEtd() As DateTime
            Set(ByVal value As DateTime)
                If _ExportEtd <> value Then
                    _ExportEtd = value
                End If
            End Set
            Get
                Return _ExportEtd
            End Get
        End Property

        Public Property ExportJobNo() As String
            Set(ByVal value As String)
                If _ExportJobNo <> value Then
                    _ExportJobNo = value
                End If
            End Set
            Get
                Return _ExportJobNo
            End Get
        End Property

        Public Property ExportNote() As String
            Set(ByVal value As String)
                If _ExportNote <> value Then
                    _ExportNote = value
                End If
            End Set
            Get
                Return _ExportNote
            End Get
        End Property

        Public Property ExportPortOfDischargeCode() As String
            Set(ByVal value As String)
                If _ExportPortOfDischargeCode <> value Then
                    _ExportPortOfDischargeCode = value
                End If
            End Set
            Get
                Return _ExportPortOfDischargeCode
            End Get
        End Property

        Public Property ExportVesselCode() As String
            Set(ByVal value As String)
                If _ExportVesselCode <> value Then
                    _ExportVesselCode = value
                End If
            End Set
            Get
                Return _ExportVesselCode
            End Get
        End Property

        Public Property ExportVesselName() As String
            Set(ByVal value As String)
                If _ExportVesselName <> value Then
                    _ExportVesselName = value
                End If
            End Set
            Get
                Return _ExportVesselName
            End Get
        End Property

        Public Property ExportVoyage() As String
            Set(ByVal value As String)
                If _ExportVoyage <> value Then
                    _ExportVoyage = value
                End If
            End Set
            Get
                Return _ExportVoyage
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

        Public Property HaulierRemark() As String
            Set(ByVal value As String)
                If _HaulierRemark <> value Then
                    _HaulierRemark = value
                End If
            End Set
            Get
                Return _HaulierRemark
            End Get
        End Property

        Public Property HBlNo() As String
            Set(ByVal value As String)
                If _HBlNo <> value Then
                    _HBlNo = value
                End If
            End Set
            Get
                Return _HBlNo
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

        Public Property ImportCurrCode() As String
            Set(ByVal value As String)
                If _ImportCurrCode <> value Then
                    _ImportCurrCode = value
                End If
            End Set
            Get
                Return _ImportCurrCode
            End Get
        End Property

        Public Property ImportRate() As Decimal
            Set(ByVal value As Decimal)
                If _ImportRate <> value Then
                    _ImportRate = value
                End If
            End Set
            Get
                Return _ImportRate
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

        Public Property NBlNo() As String
            Set(ByVal value As String)
                If _NBlNo <> value Then
                    _NBlNo = value
                End If
            End Set
            Get
                Return _NBlNo
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

        Public Property Note() As String
            Set(ByVal value As String)
                If _Note <> value Then
                    _Note = value
                End If
            End Set
            Get
                Return _Note
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

        Public Property NvoccCode() As String
            Set(ByVal value As String)
                If _NvoccCode <> value Then
                    _NvoccCode = value
                End If
            End Set
            Get
                Return _NvoccCode
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

        Public Property OriginBlNo() As String
            Set(ByVal value As String)
                If _OriginBlNo <> value Then
                    _OriginBlNo = value
                End If
            End Set
            Get
                Return _OriginBlNo
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

        Public Property PayableAmt() As String
            Set(ByVal value As String)
                If _PayableAmt <> value Then
                    _PayableAmt = value
                End If
            End Set
            Get
                Return _PayableAmt
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

        Public Property PhoneNo() As String
            Set(ByVal value As String)
                If _PhoneNo <> value Then
                    _PhoneNo = value
                End If
            End Set
            Get
                Return _PhoneNo
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

        Public Property Rebate() As Decimal
            Set(ByVal value As Decimal)
                If _Rebate <> value Then
                    _Rebate = value
                End If
            End Set
            Get
                Return _Rebate
            End Get
        End Property

        Public Property RecStatus() As String
            Set(ByVal value As String)
                If _RecStatus <> value Then
                    _RecStatus = value
                End If
            End Set
            Get
                Return _RecStatus
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

        Public Property SBlNo() As String
            Set(ByVal value As String)
                If _SBlNo <> value Then
                    _SBlNo = value
                End If
            End Set
            Get
                Return _SBlNo
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

        Public Property SeaExportFlag() As String
            Set(ByVal value As String)
                If _SeaExportFlag <> value Then
                    _SeaExportFlag = value
                End If
            End Set
            Get
                Return _SeaExportFlag
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

        Public Property ShipDate() As DateTime
            Set(ByVal value As DateTime)
                If _ShipDate <> value Then
                    _ShipDate = value
                End If
            End Set
            Get
                Return _ShipDate
            End Get
        End Property

        Public Property ShipmentId() As String
            Set(ByVal value As String)
                If _ShipmentId <> value Then
                    _ShipmentId = value
                End If
            End Set
            Get
                Return _ShipmentId
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

        Public Property ShipMode() As String
            Set(ByVal value As String)
                If _ShipMode <> value Then
                    _ShipMode = value
                End If
            End Set
            Get
                Return _ShipMode
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

        Public Property SupplierCurrCode() As String
            Set(ByVal value As String)
                If _SupplierCurrCode <> value Then
                    _SupplierCurrCode = value
                End If
            End Set
            Get
                Return _SupplierCurrCode
            End Get
        End Property

        Public Property SwitchConsigneeCode() As String
            Set(ByVal value As String)
                If _SwitchConsigneeCode <> value Then
                    _SwitchConsigneeCode = value
                End If
            End Set
            Get
                Return _SwitchConsigneeCode
            End Get
        End Property

        Public Property SwitchConsigneeName() As String
            Set(ByVal value As String)
                If _SwitchConsigneeName <> value Then
                    _SwitchConsigneeName = value
                End If
            End Set
            Get
                Return _SwitchConsigneeName
            End Get
        End Property

        Public Property SwitchConsigneeAddress1() As String
            Set(ByVal value As String)
                If _SwitchConsigneeAddress1 <> value Then
                    _SwitchConsigneeAddress1 = value
                End If
            End Set
            Get
                Return _SwitchConsigneeAddress1
            End Get
        End Property

        Public Property SwitchConsigneeAddress2() As String
            Set(ByVal value As String)
                If _SwitchConsigneeAddress2 <> value Then
                    _SwitchConsigneeAddress2 = value
                End If
            End Set
            Get
                Return _SwitchConsigneeAddress2
            End Get
        End Property

        Public Property SwitchConsigneeAddress3() As String
            Set(ByVal value As String)
                If _SwitchConsigneeAddress3 <> value Then
                    _SwitchConsigneeAddress3 = value
                End If
            End Set
            Get
                Return _SwitchConsigneeAddress3
            End Get
        End Property

        Public Property SwitchConsigneeAddress4() As String
            Set(ByVal value As String)
                If _SwitchConsigneeAddress4 <> value Then
                    _SwitchConsigneeAddress4 = value
                End If
            End Set
            Get
                Return _SwitchConsigneeAddress4
            End Get
        End Property

        Public Property SwitchDeliveryAgentCode() As String
            Set(ByVal value As String)
                If _SwitchDeliveryAgentCode <> value Then
                    _SwitchDeliveryAgentCode = value
                End If
            End Set
            Get
                Return _SwitchDeliveryAgentCode
            End Get
        End Property

        Public Property SwitchDeliveryAgentName() As String
            Set(ByVal value As String)
                If _SwitchDeliveryAgentName <> value Then
                    _SwitchDeliveryAgentName = value
                End If
            End Set
            Get
                Return _SwitchDeliveryAgentName
            End Get
        End Property

        Public Property SwitchDeliveryAgentAddress1() As String
            Set(ByVal value As String)
                If _SwitchDeliveryAgentAddress1 <> value Then
                    _SwitchDeliveryAgentAddress1 = value
                End If
            End Set
            Get
                Return _SwitchDeliveryAgentAddress1
            End Get
        End Property

        Public Property SwitchDeliveryAgentAddress2() As String
            Set(ByVal value As String)
                If _SwitchDeliveryAgentAddress2 <> value Then
                    _SwitchDeliveryAgentAddress2 = value
                End If
            End Set
            Get
                Return _SwitchDeliveryAgentAddress2
            End Get
        End Property

        Public Property SwitchDeliveryAgentAddress3() As String
            Set(ByVal value As String)
                If _SwitchDeliveryAgentAddress3 <> value Then
                    _SwitchDeliveryAgentAddress3 = value
                End If
            End Set
            Get
                Return _SwitchDeliveryAgentAddress3
            End Get
        End Property

        Public Property SwitchDeliveryAgentAddress4() As String
            Set(ByVal value As String)
                If _SwitchDeliveryAgentAddress4 <> value Then
                    _SwitchDeliveryAgentAddress4 = value
                End If
            End Set
            Get
                Return _SwitchDeliveryAgentAddress4
            End Get
        End Property

        Public Property SwitchNotifyCode() As String
            Set(ByVal value As String)
                If _SwitchNotifyCode <> value Then
                    _SwitchNotifyCode = value
                End If
            End Set
            Get
                Return _SwitchNotifyCode
            End Get
        End Property

        Public Property SwitchNotifyName() As String
            Set(ByVal value As String)
                If _SwitchNotifyName <> value Then
                    _SwitchNotifyName = value
                End If
            End Set
            Get
                Return _SwitchNotifyName
            End Get
        End Property

        Public Property SwitchNotifyAddress1() As String
            Set(ByVal value As String)
                If _SwitchNotifyAddress1 <> value Then
                    _SwitchNotifyAddress1 = value
                End If
            End Set
            Get
                Return _SwitchNotifyAddress1
            End Get
        End Property

        Public Property SwitchNotifyAddress2() As String
            Set(ByVal value As String)
                If _SwitchNotifyAddress2 <> value Then
                    _SwitchNotifyAddress2 = value
                End If
            End Set
            Get
                Return _SwitchNotifyAddress2
            End Get
        End Property

        Public Property SwitchNotifyAddress3() As String
            Set(ByVal value As String)
                If _SwitchNotifyAddress3 <> value Then
                    _SwitchNotifyAddress3 = value
                End If
            End Set
            Get
                Return _SwitchNotifyAddress3
            End Get
        End Property

        Public Property SwitchNotifyAddress4() As String
            Set(ByVal value As String)
                If _SwitchNotifyAddress4 <> value Then
                    _SwitchNotifyAddress4 = value
                End If
            End Set
            Get
                Return _SwitchNotifyAddress4
            End Get
        End Property

        Public Property SwitchShipperCode() As String
            Set(ByVal value As String)
                If _SwitchShipperCode <> value Then
                    _SwitchShipperCode = value
                End If
            End Set
            Get
                Return _SwitchShipperCode
            End Get
        End Property

        Public Property SwitchShipperName() As String
            Set(ByVal value As String)
                If _SwitchShipperName <> value Then
                    _SwitchShipperName = value
                End If
            End Set
            Get
                Return _SwitchShipperName
            End Get
        End Property

        Public Property SwitchShipperAddress1() As String
            Set(ByVal value As String)
                If _SwitchShipperAddress1 <> value Then
                    _SwitchShipperAddress1 = value
                End If
            End Set
            Get
                Return _SwitchShipperAddress1
            End Get
        End Property

        Public Property SwitchShipperAddress2() As String
            Set(ByVal value As String)
                If _SwitchShipperAddress2 <> value Then
                    _SwitchShipperAddress2 = value
                End If
            End Set
            Get
                Return _SwitchShipperAddress2
            End Get
        End Property

        Public Property SwitchShipperAddress3() As String
            Set(ByVal value As String)
                If _SwitchShipperAddress3 <> value Then
                    _SwitchShipperAddress3 = value
                End If
            End Set
            Get
                Return _SwitchShipperAddress3
            End Get
        End Property

        Public Property SwitchShipperAddress4() As String
            Set(ByVal value As String)
                If _SwitchShipperAddress4 <> value Then
                    _SwitchShipperAddress4 = value
                End If
            End Set
            Get
                Return _SwitchShipperAddress4
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

        Public Property TotalContainer() As String
            Set(ByVal value As String)
                If _TotalContainer <> value Then
                    _TotalContainer = value
                End If
            End Set
            Get
                Return _TotalContainer
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

        Public Property TranshipmentCurrCode() As String
            Set(ByVal value As String)
                If _TranshipmentCurrCode <> value Then
                    _TranshipmentCurrCode = value
                End If
            End Set
            Get
                Return _TranshipmentCurrCode
            End Get
        End Property

        Public Property TranshipmentFlag() As String
            Set(ByVal value As String)
                If _TranshipmentFlag <> value Then
                    _TranshipmentFlag = value
                End If
            End Set
            Get
                Return _TranshipmentFlag
            End Get
        End Property

        Public Property TranshipmentRate() As Decimal
            Set(ByVal value As Decimal)
                If _TranshipmentRate <> value Then
                    _TranshipmentRate = value
                End If
            End Set
            Get
                Return _TranshipmentRate
            End Get
        End Property

        Public Property TranshipmentRateRemark() As String
            Set(ByVal value As String)
                If _TranshipmentRateRemark <> value Then
                    _TranshipmentRateRemark = value
                End If
            End Set
            Get
                Return _TranshipmentRateRemark
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

        Public Property TransportCompanyAddress1() As String
            Set(ByVal value As String)
                If _TransportCompanyAddress1 <> value Then
                    _TransportCompanyAddress1 = value
                End If
            End Set
            Get
                Return _TransportCompanyAddress1
            End Get
        End Property

        Public Property TransportCompanyAddress2() As String
            Set(ByVal value As String)
                If _TransportCompanyAddress2 <> value Then
                    _TransportCompanyAddress2 = value
                End If
            End Set
            Get
                Return _TransportCompanyAddress2
            End Get
        End Property

        Public Property TransportCompanyAddress3() As String
            Set(ByVal value As String)
                If _TransportCompanyAddress3 <> value Then
                    _TransportCompanyAddress3 = value
                End If
            End Set
            Get
                Return _TransportCompanyAddress3
            End Get
        End Property

        Public Property TransportCompanyAddress4() As String
            Set(ByVal value As String)
                If _TransportCompanyAddress4 <> value Then
                    _TransportCompanyAddress4 = value
                End If
            End Set
            Get
                Return _TransportCompanyAddress4
            End Get
        End Property

        Public Property TransportCompanyContactName() As String
            Set(ByVal value As String)
                If _TransportCompanyContactName <> value Then
                    _TransportCompanyContactName = value
                End If
            End Set
            Get
                Return _TransportCompanyContactName
            End Get
        End Property

        Public Property TransportCompanyFax() As String
            Set(ByVal value As String)
                If _TransportCompanyFax <> value Then
                    _TransportCompanyFax = value
                End If
            End Set
            Get
                Return _TransportCompanyFax
            End Get
        End Property

        Public Property TransportCompanyTelephone() As String
            Set(ByVal value As String)
                If _TransportCompanyTelephone <> value Then
                    _TransportCompanyTelephone = value
                End If
            End Set
            Get
                Return _TransportCompanyTelephone
            End Get
        End Property

        Public Property TrkReceiptDate() As DateTime
            Set(ByVal value As DateTime)
                If _TrkReceiptDate <> value Then
                    _TrkReceiptDate = value
                End If
            End Set
            Get
                Return _TrkReceiptDate
            End Get
        End Property

        Public Property TrkRcvDate() As DateTime
            Set(ByVal value As DateTime)
                If _TrkRcvDate <> value Then
                    _TrkRcvDate = value
                End If
            End Set
            Get
                Return _TrkRcvDate
            End Get
        End Property

        Public Property TruckerCode() As String
            Set(ByVal value As String)
                If _TruckerCode <> value Then
                    _TruckerCode = value
                End If
            End Set
            Get
                Return _TruckerCode
            End Get
        End Property

        Public Property TruckerName() As String
            Set(ByVal value As String)
                If _TruckerName <> value Then
                    _TruckerName = value
                End If
            End Set
            Get
                Return _TruckerName
            End Get
        End Property

        Public Property TruckingDate() As DateTime
            Set(ByVal value As DateTime)
                If _TruckingDate <> value Then
                    _TruckingDate = value
                End If
            End Set
            Get
                Return _TruckingDate
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

        Public Property UnstuffDate() As DateTime
            Set(ByVal value As DateTime)
                If _UnstuffDate <> value Then
                    _UnstuffDate = value
                End If
            End Set
            Get
                Return _UnstuffDate
            End Get
        End Property

        Public Property UomCode() As String
            Set(ByVal value As String)
                If _UomCode <> value Then
                    _UomCode = value
                End If
            End Set
            Get
                Return _UomCode
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

        Public Property WarehouseChargeTemplateName() As String
            Set(ByVal value As String)
                If _WarehouseChargeTemplateName <> value Then
                    _WarehouseChargeTemplateName = value
                End If
            End Set
            Get
                Return _WarehouseChargeTemplateName
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
#End Region


#Region "New"
        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _TrxNo = ""
            _BlNo = ""
            _OBlNo = ""
            _BookingNo = ""
            _JobNo = ""
            _MasterJobNo = ""
            _AgentCcAmt = ""
            _AgentCode = ""
            _AgentPpAmt = ""
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
            _CarrierCcAmt = ""
            _CarrierPpAmt = ""
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
            _CurrCode = ""
            _CurrRate = ""
            _CustomerCode = ""
            _CustomerName = ""
            _DeliveryAgentAddress1 = ""
            _DeliveryAgentAddress2 = ""
            _DeliveryAgentAddress3 = ""
            _DeliveryAgentAddress4 = ""
            _DeliveryAgentCode = ""
            _DeliveryAgentName = ""
            _DeliveryPcs = ""
            _DeliveryType = ""
            _DepotAddress1 = ""
            _DepotAddress2 = ""
            _DepotAddress3 = ""
            _DepotAddress4 = ""
            _DepotCode = ""
            _DepotName = ""
            _DestCargoType = ""
            _DestCode = ""
            _DestEta = ""
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
            _FrtPpCcFlag = ""
            _FrtPrepaidByShipper = ""
            _FrtCollectFromConsignee = ""
            _FrtPrepaidToShippingCo = ""
            _FrtPayableDest = ""
            _HandlingFee = ""
            _ProfitShare = ""
            _Difference = ""
            _GrossWeight = ""
            _HouseJobNo = ""
            _ImportJobNo = ""
            _InsuranceAmt = ""
            _JobDate = ConDateTime.MinDate
            _JobMth = ""
            _JobType = ""
            _LadenDate = ConDateTime.MinDate
            _LetterOfCreditNo = ""
            _LotNo = ""
            _MaxGrossWeight = ""
            _MaxVolume = ""
            _NoOf20ftContainer = ""
            _NoOf40ftContainer = ""
            _NoOf45ftContainer = ""
            _NoOfOriginBl = ""
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
            _Pcs = ""
            _PrincipleAgentCode = ""
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _PortOfLoadingCode = ""
            _PortOfLoadingName = ""
            _PpAt = ""
            _PpAmt = ""
            _QuotationNo = ""
            _Remark = ""
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
            _TaxCcAmt = ""
            _TaxPpAmt = ""
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
            _TotalChargeWeight = ""
            _TotalGrossWeight = ""
            _TotalPcs = ""
            _TotalPcsInWord = ""
            _TotalVolume = ""
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
            _Volume = ""
            _VoyageId = ""
            _VoyageNo = ""
            _YardCode = ""
            _YardName = ""
            _YardAddress1 = ""
            _YardAddress2 = ""
            _YardAddress3 = ""
            _YardAddress4 = ""
            _EdiCount = ""
            _EmailCount = ""
            _ExportCount = ""
            _FaxCount = ""
            _PrintCount = ""
            _SiteCode = ""
            _WorkStation = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _StatusCode = ""
            'sibl
            _AgentCcAmt = 0
            _AgentCode = ""
            _AgentPpAmt = 0
            _AirExportFlag = ""
            _AlsoNotifyCode = ""
            _AlsoNotifyName = ""
            _AlsoNotifyAcctCode = ""
            _AlsoNotifyAddress1 = ""
            _AlsoNotifyAddress2 = ""
            _AlsoNotifyAddress3 = ""
            _AlsoNotifyAddress4 = ""
            _AppointAgentCode = ""
            _AppointAgentName = ""
            _AppointAgentAddress1 = ""
            _AppointAgentAddress2 = ""
            _AppointAgentAddress3 = ""
            _AppointAgentAddress4 = ""
            _AppointAgentContactName = ""
            _AppointAgentFax = ""
            _AppointAgentTelephone = ""
            _ArrivalDateTime = ConDateTime.MinDate
            _BarCode = ""
            _BillingDate = ConDateTime.MinDate
            _BillingInstruction = ""
            _BillMode = ""
            _BillToCode = ""
            _BlIssueDate = ConDateTime.MinDate
            _BlIssuePlace = ""
            _BlNo = ""
            _BreakBulkAgentCode = ""
            _BreakBulkAgentName = ""
            _BreakBulkAgentAddress1 = ""
            _BreakBulkAgentAddress2 = ""
            _BreakBulkAgentAddress3 = ""
            _BreakBulkAgentAddress4 = ""
            _ByWhom = ""
            _CargoClass = ""
            _CargoRcvDate = ConDateTime.MinDate
            _CargoReadyDate = ConDateTime.MinDate
            _CargoReceiptDate = ConDateTime.MinDate
            _CargoType = ""
            _CarrierCcAmt = 0
            _CarrierPpAmt = 0
            _ClearBy = ""
            _ClearDateTime = ConDateTime.MinDate
            _ClearingRemark = ""
            _ClientCode = ""
            _CollectFromCode = ""
            _CollectFromName = ""
            _CollectFromAddress1 = ""
            _CollectFromAddress2 = ""
            _CollectFromAddress3 = ""
            _CollectFromAddress4 = ""
            _ColoaderCode = ""
            _ColoaderName = ""
            _ColoaderRefNo = ""
            _CommodityCode = ""
            _CommodityDescription = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _ConsigneeAccCode = ""
            _ConsigneeAddress1 = ""
            _ConsigneeAddress2 = ""
            _ConsigneeAddress3 = ""
            _ConsigneeAddress4 = ""
            _ContainerNo = ""
            _ContainerSealNo = ""
            _ContainerSealNoType = ""
            _ContrFlag = ""
            _CrNo = ""
            _CurrCode = ""
            _CurrRate = 0
            _CustomerCode = ""
            _CustomerName = ""
            _CustomerContactName = ""
            _CustomerRefNo = ""
            _DeliveryAgentCode = ""
            _DeliveryAgentName = ""
            _DeliveryAgentAddress1 = ""
            _DeliveryAgentAddress2 = ""
            _DeliveryAgentAddress3 = ""
            _DeliveryAgentAddress4 = ""
            _DeliveryDate = ConDateTime.MinDate
            _DeliveryInstruction1 = ""
            _DeliveryInstruction2 = ""
            _DeliveryInstruction3 = ""
            _DeliveryInstruction4 = ""
            _DeliveryInstruction5 = ""
            _DeliveryInstruction6 = ""
            _DeliveryInstruction7 = ""
            _DeliveryInstruction8 = ""
            _DeliveryOrderNo = ""
            _DeliveryOrderReadyFlag = ""
            _DeliveryOrderReleaseDate = ConDateTime.MinDate
            _DeliveryOrderReleaseTo = ""
            _DeliveryPcs = 0
            _DeliveryToCode = ""
            _DeliveryToName = ""
            _DeliveryToAddress1 = ""
            _DeliveryToAddress2 = ""
            _DeliveryToAddress3 = ""
            _DeliveryToAddress4 = ""
            _DeliveryType = ""
            _DepotCode = ""
            _DepotName = ""
            _DepotAddress1 = ""
            _DepotAddress2 = ""
            _DepotAddress3 = ""
            _DepotAddress4 = ""
            _DestCargoType = ""
            _DestCode = ""
            _DestEta = ConDateTime.MinDate
            _DgFlag = ""
            _DivisionCode = ""
            _DocRcvDate = ConDateTime.MinDate
            _EdiCount = 0
            _EmailCount = 0
            _EtaDate = ConDateTime.MinDate
            _EtdDate = ConDateTime.MinDate
            _ExportBookingNo = ""
            _ExportColoaderCode = ""
            _ExportColoaderName = ""
            _ExportColoaderRefNo = ""
            _ExportCount = 0
            _ExportEta = ConDateTime.MinDate
            _ExportEtd = ConDateTime.MinDate
            _ExportJobNo = ""
            _ExportNote = ""
            _ExportPortOfDischargeCode = ""
            _ExportVesselCode = ""
            _ExportVesselName = ""
            _ExportVoyage = ""
            _FaxCount = 0
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
            _FourthViaPortCode = ""
            _FrtBillPartyCode = ""
            _FrtPpCcFlag = ""
            _HaulierRemark = ""
            _HBlNo = ""
            _HouseJobNo = ""
            _Imco = ""
            _ImportCurrCode = ""
            _ImportRate = 0
            _InsuranceAmt = 0
            _JobDate = ConDateTime.MinDate
            _JobMth = ""
            _JobNo = ""
            _JobType = ""
            _LadenDate = ConDateTime.MinDate
            _LetterOfCreditNo = ""
            _MasterJobNo = ""
            _MotherVesselName = ""
            _MotherVoyage = ""
            _NBlNo = ""
            _NominationFlag = ""
            _NominationRemark = ""
            _NoOf20ftContainer = 0
            _NoOf40ftContainer = 0
            _NoOf45ftContainer = 0
            _NoOfOriginBl = 0
            _Note = ""
            _NotifyCode = ""
            _NotifyName = ""
            _NotifyAcctCode = ""
            _NotifyAddress1 = ""
            _NotifyAddress2 = ""
            _NotifyAddress3 = ""
            _NotifyAddress4 = ""
            _NvoccCode = ""
            _OBlNo = ""
            _OriginBlNo = ""
            _OriginCode = ""
            _OtherBillPartyCode = ""
            _OtherPpCcFlag = ""
            _PayableAmt = ""
            _PermitNo = ""
            _PhoneNo = ""
            _PlaceOfDelivery = ""
            _PlaceOfReceipt = ""
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _PortOfLoadingCode = ""
            _PortOfLoadingName = ""
            _PpAt = ""
            _PrincipleAgentCode = ""
            _PrintCount = 0
            _QuotationNo = ""
            _Rebate = 0
            _RecStatus = ""
            _Remark = ""
            _SalesmanCode = ""
            _SBlNo = ""
            _ScnCode = ""
            _SeaExportFlag = ""
            _SecondViaPortCode = ""
            _ShipDate = ConDateTime.MinDate
            _ShipmentId = ""
            _ShipmentType = ""
            _ShipMode = ""
            _ShipperCode = ""
            _ShipperName = ""
            _ShipperAccCode = ""
            _ShipperAddress1 = ""
            _ShipperAddress2 = ""
            _ShipperAddress3 = ""
            _ShipperAddress4 = ""
            _ShippinglineCode = ""
            _SiteCode = ""
            _SmkShipAgentCode = ""
            _SourceCompanyCode = ""
            _SourceJobNo = ""
            _SourceSiteCode = ""
            _SubMasterFlag = ""
            _SupplierCurrCode = ""
            _SwitchConsigneeCode = ""
            _SwitchConsigneeName = ""
            _SwitchConsigneeAddress1 = ""
            _SwitchConsigneeAddress2 = ""
            _SwitchConsigneeAddress3 = ""
            _SwitchConsigneeAddress4 = ""
            _SwitchDeliveryAgentCode = ""
            _SwitchDeliveryAgentName = ""
            _SwitchDeliveryAgentAddress1 = ""
            _SwitchDeliveryAgentAddress2 = ""
            _SwitchDeliveryAgentAddress3 = ""
            _SwitchDeliveryAgentAddress4 = ""
            _SwitchNotifyCode = ""
            _SwitchNotifyName = ""
            _SwitchNotifyAddress1 = ""
            _SwitchNotifyAddress2 = ""
            _SwitchNotifyAddress3 = ""
            _SwitchNotifyAddress4 = ""
            _SwitchShipperCode = ""
            _SwitchShipperName = ""
            _SwitchShipperAddress1 = ""
            _SwitchShipperAddress2 = ""
            _SwitchShipperAddress3 = ""
            _SwitchShipperAddress4 = ""
            _TargetCompanyCode = ""
            _TargetJobNo = ""
            _TargetSiteCode = ""
            _TaxCcAmt = 0
            _TaxPpAmt = 0
            _TelexReleaseFlag = ""
            _TemplateName = ""
            _ThirdViaPortCode = ""
            _TotalChargeWeight = 0
            _TotalContainer = ""
            _TotalGrossWeight = 0
            _TotalPcs = 0
            _TotalVolume = 0
            _TranshipmentCurrCode = ""
            _TranshipmentFlag = ""
            _TranshipmentRate = 0
            _TranshipmentRateRemark = ""
            _TransportCompanyCode = ""
            _TransportCompanyName = ""
            _TransportCompanyAddress1 = ""
            _TransportCompanyAddress2 = ""
            _TransportCompanyAddress3 = ""
            _TransportCompanyAddress4 = ""
            _TransportCompanyContactName = ""
            _TransportCompanyFax = ""
            _TransportCompanyTelephone = ""
            _TrkReceiptDate = ConDateTime.MinDate
            _TrkRcvDate = ConDateTime.MinDate
            _TruckerCode = ""
            _TruckerName = ""
            _TruckingDate = ConDateTime.MinDate
            _UcrNo = ""
            _UnNo = ""
            _UnstuffDate = ConDateTime.MinDate
            _UomCode = ""
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
            _VesselCode = ""
            _VesselName = ""
            _VoyageNo = ""
            _WarehouseChargeTemplateName = ""
            _YardCode = ""
            _YardName = ""
            _YardAddress1 = ""
            _YardAddress2 = ""
            _YardAddress3 = ""
            _YardAddress4 = ""
            _WorkStation = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _AttachmentFlag = ""

        End Sub
#End Region




    End Class

#End Region
End Namespace
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of JobAnalysis Info "

    <Serializable()> _
    Public Class clsPropJobAnalysis
        Inherits clsProp
        Private _AwbNo As String = ""
        Private _SMAwbNo As String = ""
        Private _MAwbNo As String = ""
        Private _JobNo As String = ""
        Private _BookingNo As String = ""
        Private _AccountInfo1 As String = ""
        Private _AccountInfo2 As String = ""
        Private _AccountInfo3 As String = ""
        Private _AccountInfo4 As String = ""
        Private _AccountInfo5 As String = ""
        Private _AccountInfo6 As String = ""
        Private _ActualShipperCode As String = ""
        Private _ActualShipperName As String = ""
        Private _AgentAccCode As String = ""
        Private _AgentCcAmt As String = ""
        Private _AgentCode As String = ""
        Private _AgentIataCode As String = ""
        Private _AgentPpAmt As String = ""
        Private _AirportDeptCode As String = ""
        Private _AirportDeptName As String = ""
        Private _AirportDestCode As String = ""
        Private _AirportDestName As String = ""
        Private _ArrivalDateTime As String = ""
        Private _AsArrangeFlag As String = ""
        Private _AttachmentFlag As String = ""
        Private _AwbPrintFlag As String = ""
        Private _BuyChargeWeight As String = ""
        Private _BuyRate As String = ""
        Private _BuyTotalAmt As String = ""
        Private _CarriageDeclareValue As String = ""
        Private _CarrierCcAmt As String = ""
        Private _CarrierPpAmt As String = ""
        Private _ChargeAmt As String = ""
        Private _ChargeTableNo As String = ""
        Private _CloseConsol As String = ""
        Private _ColoaderCode As String = ""
        Private _CommodityCode As String = ""
        Private _CommodityDescription As String = ""
        Private _CommodityDescription01 As String = ""
        Private _CommodityDescription02 As String = ""
        Private _CommodityDescription03 As String = ""
        Private _CommodityDescription04 As String = ""
        Private _CommodityDescription05 As String = ""
        Private _CommodityDescription06 As String = ""
        Private _CommodityDescription07 As String = ""
        Private _CommodityDescription08 As String = ""
        Private _CommodityDescription09 As String = ""
        Private _CommodityDescription10 As String = ""
        Private _CommodityDescription11 As String = ""
        Private _CommodityDescription12 As String = ""
        Private _CommodityDescription13 As String = ""
        Private _CommodityDescription14 As String = ""
        Private _ComputeFlag As String = ""
        Private _ConsigneeAccCode As String = ""
        Private _ConsigneeAddress1 As String = ""
        Private _ConsigneeAddress2 As String = ""
        Private _ConsigneeAddress3 As String = ""
        Private _ConsigneeAddress4 As String = ""
        Private _ConsigneeCode As String = ""
        Private _ConsigneeName As String = ""
        Private _CurrCode As String = ""
        Private _CustomDeclareValue As String = ""
        Private _CustomerName As String = ""
        Private _DeliveryAgentCode As String = ""
        Private _DeliveryAgentName As String = ""
        Private _Description01 As String = ""
        Private _Description02 As String = ""
        Private _Description03 As String = ""
        Private _Description04 As String = ""
        Private _Description05 As String = ""
        Private _Description06 As String = ""
        Private _Description07 As String = ""
        Private _Description08 As String = ""
        Private _Description09 As String = ""
        Private _Description10 As String = ""
        Private _Description11 As String = ""
        Private _Description12 As String = ""
        Private _DestCcAmt As String = ""
        Private _DestCode As String = ""
        Private _DestCurrCode As String = ""
        Private _DestCurrRate As String = ""
        Private _Dimension As String = ""
        Private _DimType As String = ""
        Private _DivisionCode As String = ""
        Private _DocChargeWeight As String = ""
        Private _DocRate As String = ""
        Private _DocTotalAmt As String = ""
        Private _DueAgentAwbFlag01 As String = ""
        Private _DueAgentAwbFlag02 As String = ""
        Private _DueAgentAwbFlag03 As String = ""
        Private _DueAgentAwbFlag04 As String = ""
        Private _DueAgentAwbFlag05 As String = ""
        Private _DueAgentAwbFlag06 As String = ""
        Private _DueAgentAwbFlag07 As String = ""
        Private _DueAgentAwbFlag08 As String = ""
        Private _DueAgentAwbFlag09 As String = ""
        Private _DueAgentAwbFlag10 As String = ""
        Private _DueAgentAwbFlag11 As String = ""
        Private _DueAgentAwbFlag12 As String = ""
        Private _DueAgentChargeCode01 As String = ""
        Private _DueAgentChargeCode02 As String = ""
        Private _DueAgentChargeCode03 As String = ""
        Private _DueAgentChargeCode04 As String = ""
        Private _DueAgentChargeCode05 As String = ""
        Private _DueAgentChargeCode06 As String = ""
        Private _DueAgentChargeCode07 As String = ""
        Private _DueAgentChargeCode08 As String = ""
        Private _DueAgentChargeCode09 As String = ""
        Private _DueAgentChargeCode10 As String = ""
        Private _DueAgentChargeCode11 As String = ""
        Private _DueAgentChargeCode12 As String = ""
        Private _DueAgentTotalAmt As String = ""
        Private _DueAgentPpCcFlag01 As String = ""
        Private _DueAgentPpCcFlag02 As String = ""
        Private _DueAgentPpCcFlag03 As String = ""
        Private _DueAgentPpCcFlag04 As String = ""
        Private _DueAgentPpCcFlag05 As String = ""
        Private _DueAgentPpCcFlag06 As String = ""
        Private _DueAgentPpCcFlag07 As String = ""
        Private _DueAgentPpCcFlag08 As String = ""
        Private _DueAgentPpCcFlag09 As String = ""
        Private _DueAgentPpCcFlag10 As String = ""
        Private _DueAgentPpCcFlag11 As String = ""
        Private _DueAgentPpCcFlag12 As String = ""
        Private _DueAgentRate01 As String = ""
        Private _DueAgentRate02 As String = ""
        Private _DueAgentRate03 As String = ""
        Private _DueAgentRate04 As String = ""
        Private _DueAgentRate05 As String = ""
        Private _DueAgentRate06 As String = ""
        Private _DueAgentRate07 As String = ""
        Private _DueAgentRate08 As String = ""
        Private _DueAgentRate09 As String = ""
        Private _DueAgentRate10 As String = ""
        Private _DueAgentRate11 As String = ""
        Private _DueAgentRate12 As String = ""
        Private _DueCarrierAwbFlag01 As String = ""
        Private _DueCarrierAwbFlag02 As String = ""
        Private _DueCarrierAwbFlag03 As String = ""
        Private _DueCarrierAwbFlag04 As String = ""
        Private _DueCarrierAwbFlag05 As String = ""
        Private _DueCarrierAwbFlag06 As String = ""
        Private _DueCarrierAwbFlag07 As String = ""
        Private _DueCarrierAwbFlag08 As String = ""
        Private _DueCarrierAwbFlag09 As String = ""
        Private _DueCarrierAwbFlag10 As String = ""
        Private _DueCarrierAwbFlag11 As String = ""
        Private _DueCarrierAwbFlag12 As String = ""
        Private _DueCarrierChargeCode01 As String = ""
        Private _DueCarrierChargeCode02 As String = ""
        Private _DueCarrierChargeCode03 As String = ""
        Private _DueCarrierChargeCode04 As String = ""
        Private _DueCarrierChargeCode05 As String = ""
        Private _DueCarrierChargeCode06 As String = ""
        Private _DueCarrierChargeCode07 As String = ""
        Private _DueCarrierChargeCode08 As String = ""
        Private _DueCarrierChargeCode09 As String = ""
        Private _DueCarrierChargeCode10 As String = ""
        Private _DueCarrierChargeCode11 As String = ""
        Private _DueCarrierChargeCode12 As String = ""
        Private _DueCarrierPpCcFlag01 As String = ""
        Private _DueCarrierPpCcFlag02 As String = ""
        Private _DueCarrierPpCcFlag03 As String = ""
        Private _DueCarrierPpCcFlag04 As String = ""
        Private _DueCarrierPpCcFlag05 As String = ""
        Private _DueCarrierPpCcFlag06 As String = ""
        Private _DueCarrierPpCcFlag07 As String = ""
        Private _DueCarrierPpCcFlag08 As String = ""
        Private _DueCarrierPpCcFlag09 As String = ""
        Private _DueCarrierPpCcFlag10 As String = ""
        Private _DueCarrierPpCcFlag11 As String = ""
        Private _DueCarrierPpCcFlag12 As String = ""
        Private _DueCarrierRate01 As String = ""
        Private _DueCarrierRate02 As String = ""
        Private _DueCarrierRate03 As String = ""
        Private _DueCarrierRate04 As String = ""
        Private _DueCarrierRate05 As String = ""
        Private _DueCarrierRate06 As String = ""
        Private _DueCarrierRate07 As String = ""
        Private _DueCarrierRate08 As String = ""
        Private _DueCarrierRate09 As String = ""
        Private _DueCarrierRate10 As String = ""
        Private _DueCarrierRate11 As String = ""
        Private _DueCarrierRate12 As String = ""
        Private _DueCarrierTotalAmt As String = ""
        Private _ExecuteBy As String = ""
        Private _ExecuteDate As String = ""
        Private _FirstByAirlineID As String = ""
        Private _FirstFlightDate As String = ""
        Private _FirstFlightNo As String = ""
        Private _FirstToDestCode As String = ""
        Private _FlightID As String = ""
        Private _FrtBillPartyCode As String = ""
        Private _GrossWeight As String = ""
        Private _HandlingInfo1 As String = ""
        Private _HandlingInfo2 As String = ""
        Private _HandlingInfo3 As String = ""
        Private _HAwbNo01 As String = ""
        Private _HAwbNo02 As String = ""
        Private _HAwbNo03 As String = ""
        Private _HAwbNo04 As String = ""
        Private _HAwbNo05 As String = ""
        Private _HAwbNo06 As String = ""
        Private _HAwbNo07 As String = ""
        Private _HAwbNo08 As String = ""
        Private _HAwbNo09 As String = ""
        Private _HAwbNo10 As String = ""
        Private _HAwbNo11 As String = ""
        Private _HAwbNo12 As String = ""
        Private _HAwbNo13 As String = ""
        Private _HAwbNo14 As String = ""
        Private _HAwbNo15 As String = ""
        Private _HAwbNo16 As String = ""
        Private _HAwbNo17 As String = ""
        Private _HAwbNo18 As String = ""
        Private _HAwbNo19 As String = ""
        Private _HAwbNo20 As String = ""
        Private _HAwbNo21 As String = ""
        Private _HAwbNo22 As String = ""
        Private _HAwbNo23 As String = ""
        Private _HAwbNo24 As String = ""
        Private _HAwbNo25 As String = ""
        Private _HAwbNo26 As String = ""
        Private _HAwbNo27 As String = ""
        Private _HAwbNo28 As String = ""
        Private _HAwbNo29 As String = ""
        Private _HAwbNo30 As String = ""
        Private _InsuranceAmt As String = ""
        Private _JobDate As String = ""
        Private _JobMth As String = ""
        Private _JobType As String = ""
        Private _KgLbFlag As String = ""
        Private _NotifyAcctCode As String = ""
        Private _NotifyAddress1 As String = ""
        Private _NotifyAddress2 As String = ""
        Private _NotifyAddress3 As String = ""
        Private _NotifyAddress4 As String = ""
        Private _NotifyCode As String = ""
        Private _NotifyName As String = ""
        Private _OriginCode As String = ""
        Private _OtherAmt As String = ""
        Private _OtherBillPartyCode As String = ""
        Private _OtherCharge1 As String = ""
        Private _OtherCharge2 As String = ""
        Private _OtherCharge3 As String = ""
        Private _OtherChargePpCcFlag As String = ""
        Private _OtherFlag As String = ""
        Private _Pcs As String = ""
        Private _PermitNo As String = ""
        Private _PrintDimFlag As String = ""
        Private _QuoteNo As String = ""
        Private _RateClassCode As String = ""
        Private _RatePercent As String = ""
        Private _Remark As String = ""
        Private _RoundingFlag As String = ""
        Private _SalesmanCode As String = ""
        Private _SecondByAirlineID As String = ""
        Private _SecondFlightDate As String = ""
        Private _SecondFlightNo As String = ""
        Private _SecondToDestCode As String = ""
        Private _SellChargeWeight As String = ""
        Private _SellRate As String = ""
        Private _SellTotalAmt As String = ""
        Private _ShipmentType As String = ""
        Private _ShipperAccCode As String = ""
        Private _ShipperAddress1 As String = ""
        Private _ShipperAddress2 As String = ""
        Private _ShipperAddress3 As String = ""
        Private _ShipperAddress4 As String = ""
        Private _ShipperCode As String = ""
        Private _ShipperName As String = ""
        Private _SummaryDescription As String = ""
        Private _TactChargeWeight As String = ""
        Private _TactRate As String = ""
        Private _TactTotalAmt As String = ""
        Private _TaxChargeCcAmt As String = ""
        Private _TaxChargePpAmt As String = ""
        Private _TerminalCode As String = ""
        Private _ThirdByAirlineID As String = ""
        Private _ThirdFlightDate As String = ""
        Private _ThirdFlightNo As String = ""
        Private _ThirdToDestCode As String = ""
        Private _TnMindefFlag As String = ""
        Private _TnAgentFlag As String = ""
        Private _TotalCcAmt As String = ""
        Private _TotalPpAmt As String = ""
        Private _TradenetVersion As String = ""
        Private _TransferFlag As String = ""
        Private _TrfDate As String = ""
        Private _TrfFormNo As String = ""
        Private _UomCode As String = ""
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
        Private _ValueChargeCcAmt As String = ""
        Private _ValueChargePpAmt As String = ""
        Private _VolumetricWeight As String = ""
        Private _VolumetricWeightRatio As String = ""
        Private _WeightChargeCcAmt As String = ""
        Private _WeightChargePpAmt As String = ""
        Private _WeightValueFlag As String = ""
        Private _EdiCount As String = ""
        Private _EmailCount As String = ""
        Private _ExportCount As String = ""
        Private _FaxCount As String = ""
        Private _PrintCount As String = ""
        Private _PostFlag As String = ""
        Private _SiteCode As String = ""
        Private _TrfFlag As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _StatusCode As String = ""
        Private _TrxNo As String = ""
        ' 
        Public Property AwbNo() As String
            Set(ByVal value As String)
                If _AwbNo <> value Then
                    _AwbNo = value
                End If
            End Set
            Get
                Return _AwbNo
            End Get
        End Property
        ' 
        Public Property SMAwbNo() As String
            Set(ByVal value As String)
                If _SMAwbNo <> value Then
                    _SMAwbNo = value
                End If
            End Set
            Get
                Return _SMAwbNo
            End Get
        End Property
        ' 
        Public Property MAwbNo() As String
            Set(ByVal value As String)
                If _MAwbNo <> value Then
                    _MAwbNo = value
                End If
            End Set
            Get
                Return _MAwbNo
            End Get
        End Property
        ' 
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
        Public Property AccountInfo1() As String
            Set(ByVal value As String)
                If _AccountInfo1 <> value Then
                    _AccountInfo1 = value
                End If
            End Set
            Get
                Return _AccountInfo1
            End Get
        End Property
        ' 
        Public Property AccountInfo2() As String
            Set(ByVal value As String)
                If _AccountInfo2 <> value Then
                    _AccountInfo2 = value
                End If
            End Set
            Get
                Return _AccountInfo2
            End Get
        End Property
        ' 
        Public Property AccountInfo3() As String
            Set(ByVal value As String)
                If _AccountInfo3 <> value Then
                    _AccountInfo3 = value
                End If
            End Set
            Get
                Return _AccountInfo3
            End Get
        End Property
        ' 
        Public Property AccountInfo4() As String
            Set(ByVal value As String)
                If _AccountInfo4 <> value Then
                    _AccountInfo4 = value
                End If
            End Set
            Get
                Return _AccountInfo4
            End Get
        End Property
        ' 
        Public Property AccountInfo5() As String
            Set(ByVal value As String)
                If _AccountInfo5 <> value Then
                    _AccountInfo5 = value
                End If
            End Set
            Get
                Return _AccountInfo5
            End Get
        End Property
        ' 
        Public Property AccountInfo6() As String
            Set(ByVal value As String)
                If _AccountInfo6 <> value Then
                    _AccountInfo6 = value
                End If
            End Set
            Get
                Return _AccountInfo6
            End Get
        End Property
        ' 
        Public Property ActualShipperCode() As String
            Set(ByVal value As String)
                If _ActualShipperCode <> value Then
                    _ActualShipperCode = value
                End If
            End Set
            Get
                Return _ActualShipperCode
            End Get
        End Property
        ' 
        Public Property ActualShipperName() As String
            Set(ByVal value As String)
                If _ActualShipperName <> value Then
                    _ActualShipperName = value
                End If
            End Set
            Get
                Return _ActualShipperName
            End Get
        End Property
        ' 
        Public Property AgentAccCode() As String
            Set(ByVal value As String)
                If _AgentAccCode <> value Then
                    _AgentAccCode = value
                End If
            End Set
            Get
                Return _AgentAccCode
            End Get
        End Property
        ' 
        Public Property AgentCcAmt() As String
            Set(ByVal value As String)
                If _AgentCcAmt <> value Then
                    _AgentCcAmt = value
                End If
            End Set
            Get
                Return _AgentCcAmt
            End Get
        End Property
        ' 
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
        ' 
        Public Property AgentIataCode() As String
            Set(ByVal value As String)
                If _AgentIataCode <> value Then
                    _AgentIataCode = value
                End If
            End Set
            Get
                Return _AgentIataCode
            End Get
        End Property
        ' 
        Public Property AgentPpAmt() As String
            Set(ByVal value As String)
                If _AgentPpAmt <> value Then
                    _AgentPpAmt = value
                End If
            End Set
            Get
                Return _AgentPpAmt
            End Get
        End Property
        ' 
        Public Property AirportDeptCode() As String
            Set(ByVal value As String)
                If _AirportDeptCode <> value Then
                    _AirportDeptCode = value
                End If
            End Set
            Get
                Return _AirportDeptCode
            End Get
        End Property
        ' 
        Public Property AirportDeptName() As String
            Set(ByVal value As String)
                If _AirportDeptName <> value Then
                    _AirportDeptName = value
                End If
            End Set
            Get
                Return _AirportDeptName
            End Get
        End Property
        ' 
        Public Property AirportDestCode() As String
            Set(ByVal value As String)
                If _AirportDestCode <> value Then
                    _AirportDestCode = value
                End If
            End Set
            Get
                Return _AirportDestCode
            End Get
        End Property
        ' 
        Public Property AirportDestName() As String
            Set(ByVal value As String)
                If _AirportDestName <> value Then
                    _AirportDestName = value
                End If
            End Set
            Get
                Return _AirportDestName
            End Get
        End Property
        ' 
        Public Property ArrivalDateTime() As String
            Set(ByVal value As String)
                If _ArrivalDateTime <> value Then
                    _ArrivalDateTime = value
                End If
            End Set
            Get
                Return _ArrivalDateTime
            End Get
        End Property
        ' 
        Public Property AsArrangeFlag() As String
            Set(ByVal value As String)
                If _AsArrangeFlag <> value Then
                    _AsArrangeFlag = value
                End If
            End Set
            Get
                Return _AsArrangeFlag
            End Get
        End Property
        ' 
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
        ' 
        Public Property AwbPrintFlag() As String
            Set(ByVal value As String)
                If _AwbPrintFlag <> value Then
                    _AwbPrintFlag = value
                End If
            End Set
            Get
                Return _AwbPrintFlag
            End Get
        End Property
        ' 
        Public Property BuyChargeWeight() As String
            Set(ByVal value As String)
                If _BuyChargeWeight <> value Then
                    _BuyChargeWeight = value
                End If
            End Set
            Get
                Return _BuyChargeWeight
            End Get
        End Property
        ' 
        Public Property BuyRate() As String
            Set(ByVal value As String)
                If _BuyRate <> value Then
                    _BuyRate = value
                End If
            End Set
            Get
                Return _BuyRate
            End Get
        End Property
        ' 
        Public Property BuyTotalAmt() As String
            Set(ByVal value As String)
                If _BuyTotalAmt <> value Then
                    _BuyTotalAmt = value
                End If
            End Set
            Get
                Return _BuyTotalAmt
            End Get
        End Property
        ' 
        Public Property CarriageDeclareValue() As String
            Set(ByVal value As String)
                If _CarriageDeclareValue <> value Then
                    _CarriageDeclareValue = value
                End If
            End Set
            Get
                Return _CarriageDeclareValue
            End Get
        End Property
        ' 
        Public Property CarrierCcAmt() As String
            Set(ByVal value As String)
                If _CarrierCcAmt <> value Then
                    _CarrierCcAmt = value
                End If
            End Set
            Get
                Return _CarrierCcAmt
            End Get
        End Property
        ' 
        Public Property CarrierPpAmt() As String
            Set(ByVal value As String)
                If _CarrierPpAmt <> value Then
                    _CarrierPpAmt = value
                End If
            End Set
            Get
                Return _CarrierPpAmt
            End Get
        End Property
        ' 
        Public Property ChargeAmt() As String
            Set(ByVal value As String)
                If _ChargeAmt <> value Then
                    _ChargeAmt = value
                End If
            End Set
            Get
                Return _ChargeAmt
            End Get
        End Property
        ' 
        Public Property ChargeTableNo() As String
            Set(ByVal value As String)
                If _ChargeTableNo <> value Then
                    _ChargeTableNo = value
                End If
            End Set
            Get
                Return _ChargeTableNo
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
        ' 
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
        ' 
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
        ' 
        Public Property CommodityDescription01() As String
            Set(ByVal value As String)
                If _CommodityDescription01 <> value Then
                    _CommodityDescription01 = value
                End If
            End Set
            Get
                Return _CommodityDescription01
            End Get
        End Property
        ' 
        Public Property CommodityDescription02() As String
            Set(ByVal value As String)
                If _CommodityDescription02 <> value Then
                    _CommodityDescription02 = value
                End If
            End Set
            Get
                Return _CommodityDescription02
            End Get
        End Property
        ' 
        Public Property CommodityDescription03() As String
            Set(ByVal value As String)
                If _CommodityDescription03 <> value Then
                    _CommodityDescription03 = value
                End If
            End Set
            Get
                Return _CommodityDescription03
            End Get
        End Property
        ' 
        Public Property CommodityDescription04() As String
            Set(ByVal value As String)
                If _CommodityDescription04 <> value Then
                    _CommodityDescription04 = value
                End If
            End Set
            Get
                Return _CommodityDescription04
            End Get
        End Property
        ' 
        Public Property CommodityDescription05() As String
            Set(ByVal value As String)
                If _CommodityDescription05 <> value Then
                    _CommodityDescription05 = value
                End If
            End Set
            Get
                Return _CommodityDescription05
            End Get
        End Property
        ' 
        Public Property CommodityDescription06() As String
            Set(ByVal value As String)
                If _CommodityDescription06 <> value Then
                    _CommodityDescription06 = value
                End If
            End Set
            Get
                Return _CommodityDescription06
            End Get
        End Property
        ' 
        Public Property CommodityDescription07() As String
            Set(ByVal value As String)
                If _CommodityDescription07 <> value Then
                    _CommodityDescription07 = value
                End If
            End Set
            Get
                Return _CommodityDescription07
            End Get
        End Property
        ' 
        Public Property CommodityDescription08() As String
            Set(ByVal value As String)
                If _CommodityDescription08 <> value Then
                    _CommodityDescription08 = value
                End If
            End Set
            Get
                Return _CommodityDescription08
            End Get
        End Property
        ' 
        Public Property CommodityDescription09() As String
            Set(ByVal value As String)
                If _CommodityDescription09 <> value Then
                    _CommodityDescription09 = value
                End If
            End Set
            Get
                Return _CommodityDescription09
            End Get
        End Property
        ' 
        Public Property CommodityDescription10() As String
            Set(ByVal value As String)
                If _CommodityDescription10 <> value Then
                    _CommodityDescription10 = value
                End If
            End Set
            Get
                Return _CommodityDescription10
            End Get
        End Property
        ' 
        Public Property CommodityDescription11() As String
            Set(ByVal value As String)
                If _CommodityDescription11 <> value Then
                    _CommodityDescription11 = value
                End If
            End Set
            Get
                Return _CommodityDescription11
            End Get
        End Property
        ' 
        Public Property CommodityDescription12() As String
            Set(ByVal value As String)
                If _CommodityDescription12 <> value Then
                    _CommodityDescription12 = value
                End If
            End Set
            Get
                Return _CommodityDescription12
            End Get
        End Property
        ' 
        Public Property CommodityDescription13() As String
            Set(ByVal value As String)
                If _CommodityDescription13 <> value Then
                    _CommodityDescription13 = value
                End If
            End Set
            Get
                Return _CommodityDescription13
            End Get
        End Property
        ' 
        Public Property CommodityDescription14() As String
            Set(ByVal value As String)
                If _CommodityDescription14 <> value Then
                    _CommodityDescription14 = value
                End If
            End Set
            Get
                Return _CommodityDescription14
            End Get
        End Property
        ' 
        Public Property ComputeFlag() As String
            Set(ByVal value As String)
                If _ComputeFlag <> value Then
                    _ComputeFlag = value
                End If
            End Set
            Get
                Return _ComputeFlag
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property CustomDeclareValue() As String
            Set(ByVal value As String)
                If _CustomDeclareValue <> value Then
                    _CustomDeclareValue = value
                End If
            End Set
            Get
                Return _CustomDeclareValue
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property Description01() As String
            Set(ByVal value As String)
                If _Description01 <> value Then
                    _Description01 = value
                End If
            End Set
            Get
                Return _Description01
            End Get
        End Property
        ' 
        Public Property Description02() As String
            Set(ByVal value As String)
                If _Description02 <> value Then
                    _Description02 = value
                End If
            End Set
            Get
                Return _Description02
            End Get
        End Property
        ' 
        Public Property Description03() As String
            Set(ByVal value As String)
                If _Description03 <> value Then
                    _Description03 = value
                End If
            End Set
            Get
                Return _Description03
            End Get
        End Property
        ' 
        Public Property Description04() As String
            Set(ByVal value As String)
                If _Description04 <> value Then
                    _Description04 = value
                End If
            End Set
            Get
                Return _Description04
            End Get
        End Property
        ' 
        Public Property Description05() As String
            Set(ByVal value As String)
                If _Description05 <> value Then
                    _Description05 = value
                End If
            End Set
            Get
                Return _Description05
            End Get
        End Property
        ' 
        Public Property Description06() As String
            Set(ByVal value As String)
                If _Description06 <> value Then
                    _Description06 = value
                End If
            End Set
            Get
                Return _Description06
            End Get
        End Property
        ' 
        Public Property Description07() As String
            Set(ByVal value As String)
                If _Description07 <> value Then
                    _Description07 = value
                End If
            End Set
            Get
                Return _Description07
            End Get
        End Property
        ' 
        Public Property Description08() As String
            Set(ByVal value As String)
                If _Description08 <> value Then
                    _Description08 = value
                End If
            End Set
            Get
                Return _Description08
            End Get
        End Property
        ' 
        Public Property Description09() As String
            Set(ByVal value As String)
                If _Description09 <> value Then
                    _Description09 = value
                End If
            End Set
            Get
                Return _Description09
            End Get
        End Property
        ' 
        Public Property Description10() As String
            Set(ByVal value As String)
                If _Description10 <> value Then
                    _Description10 = value
                End If
            End Set
            Get
                Return _Description10
            End Get
        End Property
        ' 
        Public Property Description11() As String
            Set(ByVal value As String)
                If _Description11 <> value Then
                    _Description11 = value
                End If
            End Set
            Get
                Return _Description11
            End Get
        End Property
        ' 
        Public Property Description12() As String
            Set(ByVal value As String)
                If _Description12 <> value Then
                    _Description12 = value
                End If
            End Set
            Get
                Return _Description12
            End Get
        End Property
        ' 
        Public Property DestCcAmt() As String
            Set(ByVal value As String)
                If _DestCcAmt <> value Then
                    _DestCcAmt = value
                End If
            End Set
            Get
                Return _DestCcAmt
            End Get
        End Property
        ' 
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
        ' 
        Public Property DestCurrCode() As String
            Set(ByVal value As String)
                If _DestCurrCode <> value Then
                    _DestCurrCode = value
                End If
            End Set
            Get
                Return _DestCurrCode
            End Get
        End Property
        ' 
        Public Property DestCurrRate() As String
            Set(ByVal value As String)
                If _DestCurrRate <> value Then
                    _DestCurrRate = value
                End If
            End Set
            Get
                Return _DestCurrRate
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
        Public Property DimType() As String
            Set(ByVal value As String)
                If _DimType <> value Then
                    _DimType = value
                End If
            End Set
            Get
                Return _DimType
            End Get
        End Property
        ' 
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
        ' 
        Public Property DocChargeWeight() As String
            Set(ByVal value As String)
                If _DocChargeWeight <> value Then
                    _DocChargeWeight = value
                End If
            End Set
            Get
                Return _DocChargeWeight
            End Get
        End Property
        ' 
        Public Property DocRate() As String
            Set(ByVal value As String)
                If _DocRate <> value Then
                    _DocRate = value
                End If
            End Set
            Get
                Return _DocRate
            End Get
        End Property
        ' 
        Public Property DocTotalAmt() As String
            Set(ByVal value As String)
                If _DocTotalAmt <> value Then
                    _DocTotalAmt = value
                End If
            End Set
            Get
                Return _DocTotalAmt
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag01() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag01 <> value Then
                    _DueAgentAwbFlag01 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag01
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag02() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag02 <> value Then
                    _DueAgentAwbFlag02 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag02
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag03() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag03 <> value Then
                    _DueAgentAwbFlag03 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag03
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag04() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag04 <> value Then
                    _DueAgentAwbFlag04 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag04
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag05() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag05 <> value Then
                    _DueAgentAwbFlag05 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag05
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag06() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag06 <> value Then
                    _DueAgentAwbFlag06 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag06
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag07() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag07 <> value Then
                    _DueAgentAwbFlag07 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag07
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag08() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag08 <> value Then
                    _DueAgentAwbFlag08 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag08
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag09() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag09 <> value Then
                    _DueAgentAwbFlag09 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag09
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag10() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag10 <> value Then
                    _DueAgentAwbFlag10 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag10
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag11() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag11 <> value Then
                    _DueAgentAwbFlag11 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag11
            End Get
        End Property
        ' 
        Public Property DueAgentAwbFlag12() As String
            Set(ByVal value As String)
                If _DueAgentAwbFlag12 <> value Then
                    _DueAgentAwbFlag12 = value
                End If
            End Set
            Get
                Return _DueAgentAwbFlag12
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode01() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode01 <> value Then
                    _DueAgentChargeCode01 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode01
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode02() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode02 <> value Then
                    _DueAgentChargeCode02 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode02
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode03() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode03 <> value Then
                    _DueAgentChargeCode03 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode03
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode04() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode04 <> value Then
                    _DueAgentChargeCode04 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode04
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode05() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode05 <> value Then
                    _DueAgentChargeCode05 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode05
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode06() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode06 <> value Then
                    _DueAgentChargeCode06 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode06
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode07() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode07 <> value Then
                    _DueAgentChargeCode07 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode07
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode08() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode08 <> value Then
                    _DueAgentChargeCode08 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode08
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode09() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode09 <> value Then
                    _DueAgentChargeCode09 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode09
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode10() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode10 <> value Then
                    _DueAgentChargeCode10 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode10
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode11() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode11 <> value Then
                    _DueAgentChargeCode11 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode11
            End Get
        End Property
        ' 
        Public Property DueAgentChargeCode12() As String
            Set(ByVal value As String)
                If _DueAgentChargeCode12 <> value Then
                    _DueAgentChargeCode12 = value
                End If
            End Set
            Get
                Return _DueAgentChargeCode12
            End Get
        End Property
        ' 
        Public Property DueAgentTotalAmt() As String
            Set(ByVal value As String)
                If _DueAgentTotalAmt <> value Then
                    _DueAgentTotalAmt = value
                End If
            End Set
            Get
                Return _DueAgentTotalAmt
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag01() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag01 <> value Then
                    _DueAgentPpCcFlag01 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag01
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag02() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag02 <> value Then
                    _DueAgentPpCcFlag02 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag02
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag03() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag03 <> value Then
                    _DueAgentPpCcFlag03 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag03
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag04() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag04 <> value Then
                    _DueAgentPpCcFlag04 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag04
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag05() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag05 <> value Then
                    _DueAgentPpCcFlag05 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag05
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag06() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag06 <> value Then
                    _DueAgentPpCcFlag06 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag06
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag07() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag07 <> value Then
                    _DueAgentPpCcFlag07 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag07
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag08() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag08 <> value Then
                    _DueAgentPpCcFlag08 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag08
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag09() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag09 <> value Then
                    _DueAgentPpCcFlag09 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag09
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag10() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag10 <> value Then
                    _DueAgentPpCcFlag10 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag10
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag11() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag11 <> value Then
                    _DueAgentPpCcFlag11 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag11
            End Get
        End Property
        ' 
        Public Property DueAgentPpCcFlag12() As String
            Set(ByVal value As String)
                If _DueAgentPpCcFlag12 <> value Then
                    _DueAgentPpCcFlag12 = value
                End If
            End Set
            Get
                Return _DueAgentPpCcFlag12
            End Get
        End Property
        ' 
        Public Property DueAgentRate01() As String
            Set(ByVal value As String)
                If _DueAgentRate01 <> value Then
                    _DueAgentRate01 = value
                End If
            End Set
            Get
                Return _DueAgentRate01
            End Get
        End Property
        ' 
        Public Property DueAgentRate02() As String
            Set(ByVal value As String)
                If _DueAgentRate02 <> value Then
                    _DueAgentRate02 = value
                End If
            End Set
            Get
                Return _DueAgentRate02
            End Get
        End Property
        ' 
        Public Property DueAgentRate03() As String
            Set(ByVal value As String)
                If _DueAgentRate03 <> value Then
                    _DueAgentRate03 = value
                End If
            End Set
            Get
                Return _DueAgentRate03
            End Get
        End Property
        ' 
        Public Property DueAgentRate04() As String
            Set(ByVal value As String)
                If _DueAgentRate04 <> value Then
                    _DueAgentRate04 = value
                End If
            End Set
            Get
                Return _DueAgentRate04
            End Get
        End Property
        ' 
        Public Property DueAgentRate05() As String
            Set(ByVal value As String)
                If _DueAgentRate05 <> value Then
                    _DueAgentRate05 = value
                End If
            End Set
            Get
                Return _DueAgentRate05
            End Get
        End Property
        ' 
        Public Property DueAgentRate06() As String
            Set(ByVal value As String)
                If _DueAgentRate06 <> value Then
                    _DueAgentRate06 = value
                End If
            End Set
            Get
                Return _DueAgentRate06
            End Get
        End Property
        ' 
        Public Property DueAgentRate07() As String
            Set(ByVal value As String)
                If _DueAgentRate07 <> value Then
                    _DueAgentRate07 = value
                End If
            End Set
            Get
                Return _DueAgentRate07
            End Get
        End Property
        ' 
        Public Property DueAgentRate08() As String
            Set(ByVal value As String)
                If _DueAgentRate08 <> value Then
                    _DueAgentRate08 = value
                End If
            End Set
            Get
                Return _DueAgentRate08
            End Get
        End Property
        ' 
        Public Property DueAgentRate09() As String
            Set(ByVal value As String)
                If _DueAgentRate09 <> value Then
                    _DueAgentRate09 = value
                End If
            End Set
            Get
                Return _DueAgentRate09
            End Get
        End Property
        ' 
        Public Property DueAgentRate10() As String
            Set(ByVal value As String)
                If _DueAgentRate10 <> value Then
                    _DueAgentRate10 = value
                End If
            End Set
            Get
                Return _DueAgentRate10
            End Get
        End Property
        ' 
        Public Property DueAgentRate11() As String
            Set(ByVal value As String)
                If _DueAgentRate11 <> value Then
                    _DueAgentRate11 = value
                End If
            End Set
            Get
                Return _DueAgentRate11
            End Get
        End Property
        ' 
        Public Property DueAgentRate12() As String
            Set(ByVal value As String)
                If _DueAgentRate12 <> value Then
                    _DueAgentRate12 = value
                End If
            End Set
            Get
                Return _DueAgentRate12
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag01() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag01 <> value Then
                    _DueCarrierAwbFlag01 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag01
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag02() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag02 <> value Then
                    _DueCarrierAwbFlag02 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag02
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag03() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag03 <> value Then
                    _DueCarrierAwbFlag03 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag03
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag04() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag04 <> value Then
                    _DueCarrierAwbFlag04 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag04
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag05() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag05 <> value Then
                    _DueCarrierAwbFlag05 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag05
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag06() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag06 <> value Then
                    _DueCarrierAwbFlag06 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag06
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag07() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag07 <> value Then
                    _DueCarrierAwbFlag07 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag07
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag08() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag08 <> value Then
                    _DueCarrierAwbFlag08 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag08
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag09() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag09 <> value Then
                    _DueCarrierAwbFlag09 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag09
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag10() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag10 <> value Then
                    _DueCarrierAwbFlag10 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag10
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag11() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag11 <> value Then
                    _DueCarrierAwbFlag11 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag11
            End Get
        End Property
        ' 
        Public Property DueCarrierAwbFlag12() As String
            Set(ByVal value As String)
                If _DueCarrierAwbFlag12 <> value Then
                    _DueCarrierAwbFlag12 = value
                End If
            End Set
            Get
                Return _DueCarrierAwbFlag12
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode01() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode01 <> value Then
                    _DueCarrierChargeCode01 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode01
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode02() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode02 <> value Then
                    _DueCarrierChargeCode02 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode02
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode03() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode03 <> value Then
                    _DueCarrierChargeCode03 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode03
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode04() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode04 <> value Then
                    _DueCarrierChargeCode04 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode04
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode05() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode05 <> value Then
                    _DueCarrierChargeCode05 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode05
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode06() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode06 <> value Then
                    _DueCarrierChargeCode06 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode06
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode07() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode07 <> value Then
                    _DueCarrierChargeCode07 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode07
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode08() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode08 <> value Then
                    _DueCarrierChargeCode08 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode08
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode09() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode09 <> value Then
                    _DueCarrierChargeCode09 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode09
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode10() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode10 <> value Then
                    _DueCarrierChargeCode10 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode10
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode11() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode11 <> value Then
                    _DueCarrierChargeCode11 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode11
            End Get
        End Property
        ' 
        Public Property DueCarrierChargeCode12() As String
            Set(ByVal value As String)
                If _DueCarrierChargeCode12 <> value Then
                    _DueCarrierChargeCode12 = value
                End If
            End Set
            Get
                Return _DueCarrierChargeCode12
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag01() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag01 <> value Then
                    _DueCarrierPpCcFlag01 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag01
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag02() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag02 <> value Then
                    _DueCarrierPpCcFlag02 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag02
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag03() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag03 <> value Then
                    _DueCarrierPpCcFlag03 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag03
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag04() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag04 <> value Then
                    _DueCarrierPpCcFlag04 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag04
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag05() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag05 <> value Then
                    _DueCarrierPpCcFlag05 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag05
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag06() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag06 <> value Then
                    _DueCarrierPpCcFlag06 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag06
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag07() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag07 <> value Then
                    _DueCarrierPpCcFlag07 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag07
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag08() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag08 <> value Then
                    _DueCarrierPpCcFlag08 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag08
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag09() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag09 <> value Then
                    _DueCarrierPpCcFlag09 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag09
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag10() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag10 <> value Then
                    _DueCarrierPpCcFlag10 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag10
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag11() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag11 <> value Then
                    _DueCarrierPpCcFlag11 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag11
            End Get
        End Property
        ' 
        Public Property DueCarrierPpCcFlag12() As String
            Set(ByVal value As String)
                If _DueCarrierPpCcFlag12 <> value Then
                    _DueCarrierPpCcFlag12 = value
                End If
            End Set
            Get
                Return _DueCarrierPpCcFlag12
            End Get
        End Property
        ' 
        Public Property DueCarrierRate01() As String
            Set(ByVal value As String)
                If _DueCarrierRate01 <> value Then
                    _DueCarrierRate01 = value
                End If
            End Set
            Get
                Return _DueCarrierRate01
            End Get
        End Property
        ' 
        Public Property DueCarrierRate02() As String
            Set(ByVal value As String)
                If _DueCarrierRate02 <> value Then
                    _DueCarrierRate02 = value
                End If
            End Set
            Get
                Return _DueCarrierRate02
            End Get
        End Property
        ' 
        Public Property DueCarrierRate03() As String
            Set(ByVal value As String)
                If _DueCarrierRate03 <> value Then
                    _DueCarrierRate03 = value
                End If
            End Set
            Get
                Return _DueCarrierRate03
            End Get
        End Property
        ' 
        Public Property DueCarrierRate04() As String
            Set(ByVal value As String)
                If _DueCarrierRate04 <> value Then
                    _DueCarrierRate04 = value
                End If
            End Set
            Get
                Return _DueCarrierRate04
            End Get
        End Property
        ' 
        Public Property DueCarrierRate05() As String
            Set(ByVal value As String)
                If _DueCarrierRate05 <> value Then
                    _DueCarrierRate05 = value
                End If
            End Set
            Get
                Return _DueCarrierRate05
            End Get
        End Property
        ' 
        Public Property DueCarrierRate06() As String
            Set(ByVal value As String)
                If _DueCarrierRate06 <> value Then
                    _DueCarrierRate06 = value
                End If
            End Set
            Get
                Return _DueCarrierRate06
            End Get
        End Property
        ' 
        Public Property DueCarrierRate07() As String
            Set(ByVal value As String)
                If _DueCarrierRate07 <> value Then
                    _DueCarrierRate07 = value
                End If
            End Set
            Get
                Return _DueCarrierRate07
            End Get
        End Property
        ' 
        Public Property DueCarrierRate08() As String
            Set(ByVal value As String)
                If _DueCarrierRate08 <> value Then
                    _DueCarrierRate08 = value
                End If
            End Set
            Get
                Return _DueCarrierRate08
            End Get
        End Property
        ' 
        Public Property DueCarrierRate09() As String
            Set(ByVal value As String)
                If _DueCarrierRate09 <> value Then
                    _DueCarrierRate09 = value
                End If
            End Set
            Get
                Return _DueCarrierRate09
            End Get
        End Property
        ' 
        Public Property DueCarrierRate10() As String
            Set(ByVal value As String)
                If _DueCarrierRate10 <> value Then
                    _DueCarrierRate10 = value
                End If
            End Set
            Get
                Return _DueCarrierRate10
            End Get
        End Property
        ' 
        Public Property DueCarrierRate11() As String
            Set(ByVal value As String)
                If _DueCarrierRate11 <> value Then
                    _DueCarrierRate11 = value
                End If
            End Set
            Get
                Return _DueCarrierRate11
            End Get
        End Property
        ' 
        Public Property DueCarrierRate12() As String
            Set(ByVal value As String)
                If _DueCarrierRate12 <> value Then
                    _DueCarrierRate12 = value
                End If
            End Set
            Get
                Return _DueCarrierRate12
            End Get
        End Property
        ' 
        Public Property DueCarrierTotalAmt() As String
            Set(ByVal value As String)
                If _DueCarrierTotalAmt <> value Then
                    _DueCarrierTotalAmt = value
                End If
            End Set
            Get
                Return _DueCarrierTotalAmt
            End Get
        End Property
        ' 
        Public Property ExecuteBy() As String
            Set(ByVal value As String)
                If _ExecuteBy <> value Then
                    _ExecuteBy = value
                End If
            End Set
            Get
                Return _ExecuteBy
            End Get
        End Property
        ' 
        Public Property ExecuteDate() As String
            Set(ByVal value As String)
                If _ExecuteDate <> value Then
                    _ExecuteDate = value
                End If
            End Set
            Get
                Return _ExecuteDate
            End Get
        End Property
        ' 
        Public Property FirstByAirlineID() As String
            Set(ByVal value As String)
                If _FirstByAirlineID <> value Then
                    _FirstByAirlineID = value
                End If
            End Set
            Get
                Return _FirstByAirlineID
            End Get
        End Property
        ' 
        Public Property FirstFlightDate() As String
            Set(ByVal value As String)
                If _FirstFlightDate <> value Then
                    _FirstFlightDate = value
                End If
            End Set
            Get
                Return _FirstFlightDate
            End Get
        End Property
        ' 
        Public Property FirstFlightNo() As String
            Set(ByVal value As String)
                If _FirstFlightNo <> value Then
                    _FirstFlightNo = value
                End If
            End Set
            Get
                Return _FirstFlightNo
            End Get
        End Property
        ' 
        Public Property FirstToDestCode() As String
            Set(ByVal value As String)
                If _FirstToDestCode <> value Then
                    _FirstToDestCode = value
                End If
            End Set
            Get
                Return _FirstToDestCode
            End Get
        End Property
        ' 
        Public Property FlightID() As String
            Set(ByVal value As String)
                If _FlightID <> value Then
                    _FlightID = value
                End If
            End Set
            Get
                Return _FlightID
            End Get
        End Property
        ' 
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
        Public Property HandlingInfo1() As String
            Set(ByVal value As String)
                If _HandlingInfo1 <> value Then
                    _HandlingInfo1 = value
                End If
            End Set
            Get
                Return _HandlingInfo1
            End Get
        End Property
        ' 
        Public Property HandlingInfo2() As String
            Set(ByVal value As String)
                If _HandlingInfo2 <> value Then
                    _HandlingInfo2 = value
                End If
            End Set
            Get
                Return _HandlingInfo2
            End Get
        End Property
        ' 
        Public Property HandlingInfo3() As String
            Set(ByVal value As String)
                If _HandlingInfo3 <> value Then
                    _HandlingInfo3 = value
                End If
            End Set
            Get
                Return _HandlingInfo3
            End Get
        End Property
        ' 
        Public Property HAwbNo01() As String
            Set(ByVal value As String)
                If _HAwbNo01 <> value Then
                    _HAwbNo01 = value
                End If
            End Set
            Get
                Return _HAwbNo01
            End Get
        End Property
        ' 
        Public Property HAwbNo02() As String
            Set(ByVal value As String)
                If _HAwbNo02 <> value Then
                    _HAwbNo02 = value
                End If
            End Set
            Get
                Return _HAwbNo02
            End Get
        End Property
        ' 
        Public Property HAwbNo03() As String
            Set(ByVal value As String)
                If _HAwbNo03 <> value Then
                    _HAwbNo03 = value
                End If
            End Set
            Get
                Return _HAwbNo03
            End Get
        End Property
        ' 
        Public Property HAwbNo04() As String
            Set(ByVal value As String)
                If _HAwbNo04 <> value Then
                    _HAwbNo04 = value
                End If
            End Set
            Get
                Return _HAwbNo04
            End Get
        End Property
        ' 
        Public Property HAwbNo05() As String
            Set(ByVal value As String)
                If _HAwbNo05 <> value Then
                    _HAwbNo05 = value
                End If
            End Set
            Get
                Return _HAwbNo05
            End Get
        End Property
        ' 
        Public Property HAwbNo06() As String
            Set(ByVal value As String)
                If _HAwbNo06 <> value Then
                    _HAwbNo06 = value
                End If
            End Set
            Get
                Return _HAwbNo06
            End Get
        End Property
        ' 
        Public Property HAwbNo07() As String
            Set(ByVal value As String)
                If _HAwbNo07 <> value Then
                    _HAwbNo07 = value
                End If
            End Set
            Get
                Return _HAwbNo07
            End Get
        End Property
        ' 
        Public Property HAwbNo08() As String
            Set(ByVal value As String)
                If _HAwbNo08 <> value Then
                    _HAwbNo08 = value
                End If
            End Set
            Get
                Return _HAwbNo08
            End Get
        End Property
        ' 
        Public Property HAwbNo09() As String
            Set(ByVal value As String)
                If _HAwbNo09 <> value Then
                    _HAwbNo09 = value
                End If
            End Set
            Get
                Return _HAwbNo09
            End Get
        End Property
        ' 
        Public Property HAwbNo10() As String
            Set(ByVal value As String)
                If _HAwbNo10 <> value Then
                    _HAwbNo10 = value
                End If
            End Set
            Get
                Return _HAwbNo10
            End Get
        End Property
        ' 
        Public Property HAwbNo11() As String
            Set(ByVal value As String)
                If _HAwbNo11 <> value Then
                    _HAwbNo11 = value
                End If
            End Set
            Get
                Return _HAwbNo11
            End Get
        End Property
        ' 
        Public Property HAwbNo12() As String
            Set(ByVal value As String)
                If _HAwbNo12 <> value Then
                    _HAwbNo12 = value
                End If
            End Set
            Get
                Return _HAwbNo12
            End Get
        End Property
        ' 
        Public Property HAwbNo13() As String
            Set(ByVal value As String)
                If _HAwbNo13 <> value Then
                    _HAwbNo13 = value
                End If
            End Set
            Get
                Return _HAwbNo13
            End Get
        End Property
        ' 
        Public Property HAwbNo14() As String
            Set(ByVal value As String)
                If _HAwbNo14 <> value Then
                    _HAwbNo14 = value
                End If
            End Set
            Get
                Return _HAwbNo14
            End Get
        End Property
        ' 
        Public Property HAwbNo15() As String
            Set(ByVal value As String)
                If _HAwbNo15 <> value Then
                    _HAwbNo15 = value
                End If
            End Set
            Get
                Return _HAwbNo15
            End Get
        End Property
        ' 
        Public Property HAwbNo16() As String
            Set(ByVal value As String)
                If _HAwbNo16 <> value Then
                    _HAwbNo16 = value
                End If
            End Set
            Get
                Return _HAwbNo16
            End Get
        End Property
        ' 
        Public Property HAwbNo17() As String
            Set(ByVal value As String)
                If _HAwbNo17 <> value Then
                    _HAwbNo17 = value
                End If
            End Set
            Get
                Return _HAwbNo17
            End Get
        End Property
        ' 
        Public Property HAwbNo18() As String
            Set(ByVal value As String)
                If _HAwbNo18 <> value Then
                    _HAwbNo18 = value
                End If
            End Set
            Get
                Return _HAwbNo18
            End Get
        End Property
        ' 
        Public Property HAwbNo19() As String
            Set(ByVal value As String)
                If _HAwbNo19 <> value Then
                    _HAwbNo19 = value
                End If
            End Set
            Get
                Return _HAwbNo19
            End Get
        End Property
        ' 
        Public Property HAwbNo20() As String
            Set(ByVal value As String)
                If _HAwbNo20 <> value Then
                    _HAwbNo20 = value
                End If
            End Set
            Get
                Return _HAwbNo20
            End Get
        End Property
        ' 
        Public Property HAwbNo21() As String
            Set(ByVal value As String)
                If _HAwbNo21 <> value Then
                    _HAwbNo21 = value
                End If
            End Set
            Get
                Return _HAwbNo21
            End Get
        End Property
        ' 
        Public Property HAwbNo22() As String
            Set(ByVal value As String)
                If _HAwbNo22 <> value Then
                    _HAwbNo22 = value
                End If
            End Set
            Get
                Return _HAwbNo22
            End Get
        End Property
        ' 
        Public Property HAwbNo23() As String
            Set(ByVal value As String)
                If _HAwbNo23 <> value Then
                    _HAwbNo23 = value
                End If
            End Set
            Get
                Return _HAwbNo23
            End Get
        End Property
        ' 
        Public Property HAwbNo24() As String
            Set(ByVal value As String)
                If _HAwbNo24 <> value Then
                    _HAwbNo24 = value
                End If
            End Set
            Get
                Return _HAwbNo24
            End Get
        End Property
        ' 
        Public Property HAwbNo25() As String
            Set(ByVal value As String)
                If _HAwbNo25 <> value Then
                    _HAwbNo25 = value
                End If
            End Set
            Get
                Return _HAwbNo25
            End Get
        End Property
        ' 
        Public Property HAwbNo26() As String
            Set(ByVal value As String)
                If _HAwbNo26 <> value Then
                    _HAwbNo26 = value
                End If
            End Set
            Get
                Return _HAwbNo26
            End Get
        End Property
        ' 
        Public Property HAwbNo27() As String
            Set(ByVal value As String)
                If _HAwbNo27 <> value Then
                    _HAwbNo27 = value
                End If
            End Set
            Get
                Return _HAwbNo27
            End Get
        End Property
        ' 
        Public Property HAwbNo28() As String
            Set(ByVal value As String)
                If _HAwbNo28 <> value Then
                    _HAwbNo28 = value
                End If
            End Set
            Get
                Return _HAwbNo28
            End Get
        End Property
        ' 
        Public Property HAwbNo29() As String
            Set(ByVal value As String)
                If _HAwbNo29 <> value Then
                    _HAwbNo29 = value
                End If
            End Set
            Get
                Return _HAwbNo29
            End Get
        End Property
        ' 
        Public Property HAwbNo30() As String
            Set(ByVal value As String)
                If _HAwbNo30 <> value Then
                    _HAwbNo30 = value
                End If
            End Set
            Get
                Return _HAwbNo30
            End Get
        End Property
        ' 
        Public Property InsuranceAmt() As String
            Set(ByVal value As String)
                If _InsuranceAmt <> value Then
                    _InsuranceAmt = value
                End If
            End Set
            Get
                Return _InsuranceAmt
            End Get
        End Property
        ' 
        Public Property JobDate() As String
            Set(ByVal value As String)
                If _JobDate <> value Then
                    _JobDate = value
                End If
            End Set
            Get
                Return _JobDate
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
        Public Property KgLbFlag() As String
            Set(ByVal value As String)
                If _KgLbFlag <> value Then
                    _KgLbFlag = value
                End If
            End Set
            Get
                Return _KgLbFlag
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property OtherAmt() As String
            Set(ByVal value As String)
                If _OtherAmt <> value Then
                    _OtherAmt = value
                End If
            End Set
            Get
                Return _OtherAmt
            End Get
        End Property
        ' 
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
        ' 
        Public Property OtherCharge1() As String
            Set(ByVal value As String)
                If _OtherCharge1 <> value Then
                    _OtherCharge1 = value
                End If
            End Set
            Get
                Return _OtherCharge1
            End Get
        End Property
        ' 
        Public Property OtherCharge2() As String
            Set(ByVal value As String)
                If _OtherCharge2 <> value Then
                    _OtherCharge2 = value
                End If
            End Set
            Get
                Return _OtherCharge2
            End Get
        End Property
        ' 
        Public Property OtherCharge3() As String
            Set(ByVal value As String)
                If _OtherCharge3 <> value Then
                    _OtherCharge3 = value
                End If
            End Set
            Get
                Return _OtherCharge3
            End Get
        End Property
        ' 
        Public Property OtherChargePpCcFlag() As String
            Set(ByVal value As String)
                If _OtherChargePpCcFlag <> value Then
                    _OtherChargePpCcFlag = value
                End If
            End Set
            Get
                Return _OtherChargePpCcFlag
            End Get
        End Property
        ' 
        Public Property OtherFlag() As String
            Set(ByVal value As String)
                If _OtherFlag <> value Then
                    _OtherFlag = value
                End If
            End Set
            Get
                Return _OtherFlag
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
        ' 
        Public Property PrintDimFlag() As String
            Set(ByVal value As String)
                If _PrintDimFlag <> value Then
                    _PrintDimFlag = value
                End If
            End Set
            Get
                Return _PrintDimFlag
            End Get
        End Property
        ' 
        Public Property QuoteNo() As String
            Set(ByVal value As String)
                If _QuoteNo <> value Then
                    _QuoteNo = value
                End If
            End Set
            Get
                Return _QuoteNo
            End Get
        End Property
        ' 
        Public Property RateClassCode() As String
            Set(ByVal value As String)
                If _RateClassCode <> value Then
                    _RateClassCode = value
                End If
            End Set
            Get
                Return _RateClassCode
            End Get
        End Property
        ' 
        Public Property RatePercent() As String
            Set(ByVal value As String)
                If _RatePercent <> value Then
                    _RatePercent = value
                End If
            End Set
            Get
                Return _RatePercent
            End Get
        End Property
        ' 
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
        ' 
        Public Property RoundingFlag() As String
            Set(ByVal value As String)
                If _RoundingFlag <> value Then
                    _RoundingFlag = value
                End If
            End Set
            Get
                Return _RoundingFlag
            End Get
        End Property
        ' 
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
        ' 
        Public Property SecondByAirlineID() As String
            Set(ByVal value As String)
                If _SecondByAirlineID <> value Then
                    _SecondByAirlineID = value
                End If
            End Set
            Get
                Return _SecondByAirlineID
            End Get
        End Property
        ' 
        Public Property SecondFlightDate() As String
            Set(ByVal value As String)
                If _SecondFlightDate <> value Then
                    _SecondFlightDate = value
                End If
            End Set
            Get
                Return _SecondFlightDate
            End Get
        End Property
        ' 
        Public Property SecondFlightNo() As String
            Set(ByVal value As String)
                If _SecondFlightNo <> value Then
                    _SecondFlightNo = value
                End If
            End Set
            Get
                Return _SecondFlightNo
            End Get
        End Property
        ' 
        Public Property SecondToDestCode() As String
            Set(ByVal value As String)
                If _SecondToDestCode <> value Then
                    _SecondToDestCode = value
                End If
            End Set
            Get
                Return _SecondToDestCode
            End Get
        End Property
        ' 
        Public Property SellChargeWeight() As String
            Set(ByVal value As String)
                If _SellChargeWeight <> value Then
                    _SellChargeWeight = value
                End If
            End Set
            Get
                Return _SellChargeWeight
            End Get
        End Property
        ' 
        Public Property SellRate() As String
            Set(ByVal value As String)
                If _SellRate <> value Then
                    _SellRate = value
                End If
            End Set
            Get
                Return _SellRate
            End Get
        End Property
        ' 
        Public Property SellTotalAmt() As String
            Set(ByVal value As String)
                If _SellTotalAmt <> value Then
                    _SellTotalAmt = value
                End If
            End Set
            Get
                Return _SellTotalAmt
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property SummaryDescription() As String
            Set(ByVal value As String)
                If _SummaryDescription <> value Then
                    _SummaryDescription = value
                End If
            End Set
            Get
                Return _SummaryDescription
            End Get
        End Property
        ' 
        Public Property TactChargeWeight() As String
            Set(ByVal value As String)
                If _TactChargeWeight <> value Then
                    _TactChargeWeight = value
                End If
            End Set
            Get
                Return _TactChargeWeight
            End Get
        End Property
        ' 
        Public Property TactRate() As String
            Set(ByVal value As String)
                If _TactRate <> value Then
                    _TactRate = value
                End If
            End Set
            Get
                Return _TactRate
            End Get
        End Property
        ' 
        Public Property TactTotalAmt() As String
            Set(ByVal value As String)
                If _TactTotalAmt <> value Then
                    _TactTotalAmt = value
                End If
            End Set
            Get
                Return _TactTotalAmt
            End Get
        End Property
        ' 
        Public Property TaxChargeCcAmt() As String
            Set(ByVal value As String)
                If _TaxChargeCcAmt <> value Then
                    _TaxChargeCcAmt = value
                End If
            End Set
            Get
                Return _TaxChargeCcAmt
            End Get
        End Property
        ' 
        Public Property TaxChargePpAmt() As String
            Set(ByVal value As String)
                If _TaxChargePpAmt <> value Then
                    _TaxChargePpAmt = value
                End If
            End Set
            Get
                Return _TaxChargePpAmt
            End Get
        End Property
        ' 
        Public Property TerminalCode() As String
            Set(ByVal value As String)
                If _TerminalCode <> value Then
                    _TerminalCode = value
                End If
            End Set
            Get
                Return _TerminalCode
            End Get
        End Property
        ' 
        Public Property ThirdByAirlineID() As String
            Set(ByVal value As String)
                If _ThirdByAirlineID <> value Then
                    _ThirdByAirlineID = value
                End If
            End Set
            Get
                Return _ThirdByAirlineID
            End Get
        End Property
        ' 
        Public Property ThirdFlightDate() As String
            Set(ByVal value As String)
                If _ThirdFlightDate <> value Then
                    _ThirdFlightDate = value
                End If
            End Set
            Get
                Return _ThirdFlightDate
            End Get
        End Property
        ' 
        Public Property ThirdFlightNo() As String
            Set(ByVal value As String)
                If _ThirdFlightNo <> value Then
                    _ThirdFlightNo = value
                End If
            End Set
            Get
                Return _ThirdFlightNo
            End Get
        End Property
        ' 
        Public Property ThirdToDestCode() As String
            Set(ByVal value As String)
                If _ThirdToDestCode <> value Then
                    _ThirdToDestCode = value
                End If
            End Set
            Get
                Return _ThirdToDestCode
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
        Public Property TotalCcAmt() As String
            Set(ByVal value As String)
                If _TotalCcAmt <> value Then
                    _TotalCcAmt = value
                End If
            End Set
            Get
                Return _TotalCcAmt
            End Get
        End Property
        ' 
        Public Property TotalPpAmt() As String
            Set(ByVal value As String)
                If _TotalPpAmt <> value Then
                    _TotalPpAmt = value
                End If
            End Set
            Get
                Return _TotalPpAmt
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
        Public Property TransferFlag() As String
            Set(ByVal value As String)
                If _TransferFlag <> value Then
                    _TransferFlag = value
                End If
            End Set
            Get
                Return _TransferFlag
            End Get
        End Property
        ' 
        Public Property TrfDate() As String
            Set(ByVal value As String)
                If _TrfDate <> value Then
                    _TrfDate = value
                End If
            End Set
            Get
                Return _TrfDate
            End Get
        End Property
        ' 
        Public Property TrfFormNo() As String
            Set(ByVal value As String)
                If _TrfFormNo <> value Then
                    _TrfFormNo = value
                End If
            End Set
            Get
                Return _TrfFormNo
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property ValueChargeCcAmt() As String
            Set(ByVal value As String)
                If _ValueChargeCcAmt <> value Then
                    _ValueChargeCcAmt = value
                End If
            End Set
            Get
                Return _ValueChargeCcAmt
            End Get
        End Property
        ' 
        Public Property ValueChargePpAmt() As String
            Set(ByVal value As String)
                If _ValueChargePpAmt <> value Then
                    _ValueChargePpAmt = value
                End If
            End Set
            Get
                Return _ValueChargePpAmt
            End Get
        End Property
        ' 
        Public Property VolumetricWeight() As String
            Set(ByVal value As String)
                If _VolumetricWeight <> value Then
                    _VolumetricWeight = value
                End If
            End Set
            Get
                Return _VolumetricWeight
            End Get
        End Property
        ' 
        Public Property VolumetricWeightRatio() As String
            Set(ByVal value As String)
                If _VolumetricWeightRatio <> value Then
                    _VolumetricWeightRatio = value
                End If
            End Set
            Get
                Return _VolumetricWeightRatio
            End Get
        End Property
        ' 
        Public Property WeightChargeCcAmt() As String
            Set(ByVal value As String)
                If _WeightChargeCcAmt <> value Then
                    _WeightChargeCcAmt = value
                End If
            End Set
            Get
                Return _WeightChargeCcAmt
            End Get
        End Property
        ' 
        Public Property WeightChargePpAmt() As String
            Set(ByVal value As String)
                If _WeightChargePpAmt <> value Then
                    _WeightChargePpAmt = value
                End If
            End Set
            Get
                Return _WeightChargePpAmt
            End Get
        End Property
        ' 
        Public Property WeightValueFlag() As String
            Set(ByVal value As String)
                If _WeightValueFlag <> value Then
                    _WeightValueFlag = value
                End If
            End Set
            Get
                Return _WeightValueFlag
            End Get
        End Property
        ' 
        Public Property EdiCount() As String
            Set(ByVal value As String)
                If _EdiCount <> value Then
                    _EdiCount = value
                End If
            End Set
            Get
                Return _EdiCount
            End Get
        End Property
        ' 
        Public Property EmailCount() As String
            Set(ByVal value As String)
                If _EmailCount <> value Then
                    _EmailCount = value
                End If
            End Set
            Get
                Return _EmailCount
            End Get
        End Property
        ' 
        Public Property ExportCount() As String
            Set(ByVal value As String)
                If _ExportCount <> value Then
                    _ExportCount = value
                End If
            End Set
            Get
                Return _ExportCount
            End Get
        End Property
        ' 
        Public Property FaxCount() As String
            Set(ByVal value As String)
                If _FaxCount <> value Then
                    _FaxCount = value
                End If
            End Set
            Get
                Return _FaxCount
            End Get
        End Property
        ' 
        Public Property PrintCount() As String
            Set(ByVal value As String)
                If _PrintCount <> value Then
                    _PrintCount = value
                End If
            End Set
            Get
                Return _PrintCount
            End Get
        End Property
        ' 
        Public Property PostFlag() As String
            Set(ByVal value As String)
                If _PostFlag <> value Then
                    _PostFlag = value
                End If
            End Set
            Get
                Return _PostFlag
            End Get
        End Property
        ' 
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
        ' 
        Public Property TrfFlag() As String
            Set(ByVal value As String)
                If _TrfFlag <> value Then
                    _TrfFlag = value
                End If
            End Set
            Get
                Return _TrfFlag
            End Get
        End Property
        ' 
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
        ' 
        Public Property CreateDateTime() As String
            Set(ByVal value As String)
                If _CreateDateTime <> value Then
                    _CreateDateTime = value
                End If
            End Set
            Get
                Return _CreateDateTime
            End Get
        End Property
        ' 
        Public Property UpdateDateTime() As String
            Set(ByVal value As String)
                If _UpdateDateTime <> value Then
                    _UpdateDateTime = value
                End If
            End Set
            Get
                Return _UpdateDateTime
            End Get
        End Property
        ' 
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
        ' 
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


        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _AwbNo = ""
            _SMAwbNo = ""
            _MAwbNo = ""
            _JobNo = ""
            _BookingNo = ""
            _AccountInfo1 = ""
            _AccountInfo2 = ""
            _AccountInfo3 = ""
            _AccountInfo4 = ""
            _AccountInfo5 = ""
            _AccountInfo6 = ""
            _ActualShipperCode = ""
            _ActualShipperName = ""
            _AgentAccCode = ""
            _AgentCcAmt = ""
            _AgentCode = ""
            _AgentIataCode = ""
            _AgentPpAmt = ""
            _AirportDeptCode = ""
            _AirportDeptName = ""
            _AirportDestCode = ""
            _AirportDestName = ""
            _ArrivalDateTime = ""
            _AsArrangeFlag = ""
            _AttachmentFlag = ""
            _AwbPrintFlag = ""
            _BuyChargeWeight = ""
            _BuyRate = ""
            _BuyTotalAmt = ""
            _CarriageDeclareValue = ""
            _CarrierCcAmt = ""
            _CarrierPpAmt = ""
            _ChargeAmt = ""
            _ChargeTableNo = ""
            _CloseConsol = ""
            _ColoaderCode = ""
            _CommodityCode = ""
            _CommodityDescription = ""
            _CommodityDescription01 = ""
            _CommodityDescription02 = ""
            _CommodityDescription03 = ""
            _CommodityDescription04 = ""
            _CommodityDescription05 = ""
            _CommodityDescription06 = ""
            _CommodityDescription07 = ""
            _CommodityDescription08 = ""
            _CommodityDescription09 = ""
            _CommodityDescription10 = ""
            _CommodityDescription11 = ""
            _CommodityDescription12 = ""
            _CommodityDescription13 = ""
            _CommodityDescription14 = ""
            _ComputeFlag = ""
            _ConsigneeAccCode = ""
            _ConsigneeAddress1 = ""
            _ConsigneeAddress2 = ""
            _ConsigneeAddress3 = ""
            _ConsigneeAddress4 = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _CurrCode = ""
            _CustomDeclareValue = ""
            _CustomerName = ""
            _DeliveryAgentCode = ""
            _DeliveryAgentName = ""
            _Description01 = ""
            _Description02 = ""
            _Description03 = ""
            _Description04 = ""
            _Description05 = ""
            _Description06 = ""
            _Description07 = ""
            _Description08 = ""
            _Description09 = ""
            _Description10 = ""
            _Description11 = ""
            _Description12 = ""
            _DestCcAmt = ""
            _DestCode = ""
            _DestCurrCode = ""
            _DestCurrRate = ""
            _Dimension = ""
            _DimType = ""
            _DivisionCode = ""
            _DocChargeWeight = ""
            _DocRate = ""
            _DocTotalAmt = ""
            _DueAgentAwbFlag01 = ""
            _DueAgentAwbFlag02 = ""
            _DueAgentAwbFlag03 = ""
            _DueAgentAwbFlag04 = ""
            _DueAgentAwbFlag05 = ""
            _DueAgentAwbFlag06 = ""
            _DueAgentAwbFlag07 = ""
            _DueAgentAwbFlag08 = ""
            _DueAgentAwbFlag09 = ""
            _DueAgentAwbFlag10 = ""
            _DueAgentAwbFlag11 = ""
            _DueAgentAwbFlag12 = ""
            _DueAgentChargeCode01 = ""
            _DueAgentChargeCode02 = ""
            _DueAgentChargeCode03 = ""
            _DueAgentChargeCode04 = ""
            _DueAgentChargeCode05 = ""
            _DueAgentChargeCode06 = ""
            _DueAgentChargeCode07 = ""
            _DueAgentChargeCode08 = ""
            _DueAgentChargeCode09 = ""
            _DueAgentChargeCode10 = ""
            _DueAgentChargeCode11 = ""
            _DueAgentChargeCode12 = ""
            _DueAgentTotalAmt = ""
            _DueAgentPpCcFlag01 = ""
            _DueAgentPpCcFlag02 = ""
            _DueAgentPpCcFlag03 = ""
            _DueAgentPpCcFlag04 = ""
            _DueAgentPpCcFlag05 = ""
            _DueAgentPpCcFlag06 = ""
            _DueAgentPpCcFlag07 = ""
            _DueAgentPpCcFlag08 = ""
            _DueAgentPpCcFlag09 = ""
            _DueAgentPpCcFlag10 = ""
            _DueAgentPpCcFlag11 = ""
            _DueAgentPpCcFlag12 = ""
            _DueAgentRate01 = ""
            _DueAgentRate02 = ""
            _DueAgentRate03 = ""
            _DueAgentRate04 = ""
            _DueAgentRate05 = ""
            _DueAgentRate06 = ""
            _DueAgentRate07 = ""
            _DueAgentRate08 = ""
            _DueAgentRate09 = ""
            _DueAgentRate10 = ""
            _DueAgentRate11 = ""
            _DueAgentRate12 = ""
            _DueCarrierAwbFlag01 = ""
            _DueCarrierAwbFlag02 = ""
            _DueCarrierAwbFlag03 = ""
            _DueCarrierAwbFlag04 = ""
            _DueCarrierAwbFlag05 = ""
            _DueCarrierAwbFlag06 = ""
            _DueCarrierAwbFlag07 = ""
            _DueCarrierAwbFlag08 = ""
            _DueCarrierAwbFlag09 = ""
            _DueCarrierAwbFlag10 = ""
            _DueCarrierAwbFlag11 = ""
            _DueCarrierAwbFlag12 = ""
            _DueCarrierChargeCode01 = ""
            _DueCarrierChargeCode02 = ""
            _DueCarrierChargeCode03 = ""
            _DueCarrierChargeCode04 = ""
            _DueCarrierChargeCode05 = ""
            _DueCarrierChargeCode06 = ""
            _DueCarrierChargeCode07 = ""
            _DueCarrierChargeCode08 = ""
            _DueCarrierChargeCode09 = ""
            _DueCarrierChargeCode10 = ""
            _DueCarrierChargeCode11 = ""
            _DueCarrierChargeCode12 = ""
            _DueCarrierPpCcFlag01 = ""
            _DueCarrierPpCcFlag02 = ""
            _DueCarrierPpCcFlag03 = ""
            _DueCarrierPpCcFlag04 = ""
            _DueCarrierPpCcFlag05 = ""
            _DueCarrierPpCcFlag06 = ""
            _DueCarrierPpCcFlag07 = ""
            _DueCarrierPpCcFlag08 = ""
            _DueCarrierPpCcFlag09 = ""
            _DueCarrierPpCcFlag10 = ""
            _DueCarrierPpCcFlag11 = ""
            _DueCarrierPpCcFlag12 = ""
            _DueCarrierRate01 = ""
            _DueCarrierRate02 = ""
            _DueCarrierRate03 = ""
            _DueCarrierRate04 = ""
            _DueCarrierRate05 = ""
            _DueCarrierRate06 = ""
            _DueCarrierRate07 = ""
            _DueCarrierRate08 = ""
            _DueCarrierRate09 = ""
            _DueCarrierRate10 = ""
            _DueCarrierRate11 = ""
            _DueCarrierRate12 = ""
            _DueCarrierTotalAmt = ""
            _ExecuteBy = ""
            _ExecuteDate = ""
            _FirstByAirlineID = ""
            _FirstFlightDate = ""
            _FirstFlightNo = ""
            _FirstToDestCode = ""
            _FlightID = ""
            _FrtBillPartyCode = ""
            _GrossWeight = ""
            _HandlingInfo1 = ""
            _HandlingInfo2 = ""
            _HandlingInfo3 = ""
            _HAwbNo01 = ""
            _HAwbNo02 = ""
            _HAwbNo03 = ""
            _HAwbNo04 = ""
            _HAwbNo05 = ""
            _HAwbNo06 = ""
            _HAwbNo07 = ""
            _HAwbNo08 = ""
            _HAwbNo09 = ""
            _HAwbNo10 = ""
            _HAwbNo11 = ""
            _HAwbNo12 = ""
            _HAwbNo13 = ""
            _HAwbNo14 = ""
            _HAwbNo15 = ""
            _HAwbNo16 = ""
            _HAwbNo17 = ""
            _HAwbNo18 = ""
            _HAwbNo19 = ""
            _HAwbNo20 = ""
            _HAwbNo21 = ""
            _HAwbNo22 = ""
            _HAwbNo23 = ""
            _HAwbNo24 = ""
            _HAwbNo25 = ""
            _HAwbNo26 = ""
            _HAwbNo27 = ""
            _HAwbNo28 = ""
            _HAwbNo29 = ""
            _HAwbNo30 = ""
            _InsuranceAmt = ""
            _JobDate = ""
            _JobMth = ""
            _JobType = ""
            _KgLbFlag = ""
            _NotifyAcctCode = ""
            _NotifyAddress1 = ""
            _NotifyAddress2 = ""
            _NotifyAddress3 = ""
            _NotifyAddress4 = ""
            _NotifyCode = ""
            _NotifyName = ""
            _OriginCode = ""
            _OtherAmt = ""
            _OtherBillPartyCode = ""
            _OtherCharge1 = ""
            _OtherCharge2 = ""
            _OtherCharge3 = ""
            _OtherChargePpCcFlag = ""
            _OtherFlag = ""
            _Pcs = ""
            _PermitNo = ""
            _PrintDimFlag = ""
            _QuoteNo = ""
            _RateClassCode = ""
            _RatePercent = ""
            _Remark = ""
            _RoundingFlag = ""
            _SalesmanCode = ""
            _SecondByAirlineID = ""
            _SecondFlightDate = ""
            _SecondFlightNo = ""
            _SecondToDestCode = ""
            _SellChargeWeight = ""
            _SellRate = ""
            _SellTotalAmt = ""
            _ShipmentType = ""
            _ShipperAccCode = ""
            _ShipperAddress1 = ""
            _ShipperAddress2 = ""
            _ShipperAddress3 = ""
            _ShipperAddress4 = ""
            _ShipperCode = ""
            _ShipperName = ""
            _SummaryDescription = ""
            _TactChargeWeight = ""
            _TactRate = ""
            _TactTotalAmt = ""
            _TaxChargeCcAmt = ""
            _TaxChargePpAmt = ""
            _TerminalCode = ""
            _ThirdByAirlineID = ""
            _ThirdFlightDate = ""
            _ThirdFlightNo = ""
            _ThirdToDestCode = ""
            _TnMindefFlag = ""
            _TnAgentFlag = ""
            _TotalCcAmt = ""
            _TotalPpAmt = ""
            _TradenetVersion = ""
            _TransferFlag = ""
            _TrfDate = ""
            _TrfFormNo = ""
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
            _ValueChargeCcAmt = ""
            _ValueChargePpAmt = ""
            _VolumetricWeight = ""
            _VolumetricWeightRatio = ""
            _WeightChargeCcAmt = ""
            _WeightChargePpAmt = ""
            _WeightValueFlag = ""
            _EdiCount = ""
            _EmailCount = ""
            _ExportCount = ""
            _FaxCount = ""
            _PrintCount = ""
            _PostFlag = ""
            _SiteCode = ""
            _TrfFlag = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateDateTime = ""
            _UpdateBy = ""
            _StatusCode = ""
            _TrxNo = ""
        End Sub

    End Class

#End Region
End Namespace
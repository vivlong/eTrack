Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Invoice Info "

    <Serializable()> _
    Public Class clsPropInvoice
        Inherits clsProp
        Private _TrxNo As String = ""
        Private _RefNo As String = ""
        Private _InvoiceNo As String = ""
        Private _ApplyToInvoice As String = ""
        Private _AwbOrBlNo As String = ""
        Private _MAwbOrOBlNo As String = ""
        Private _HAwbOrHBlNo As String = ""
        Private _JobNo As String = ""
        Private _BillingPartyCode As String = ""
        Private _TrxType As String = ""
        Private _PpCcFlag As String = ""
        Private _BarCode As String = ""
        Private _BarCode1 As String = ""
        Private _CustomerCode As String = ""
        Private _CustomerName As String = ""
        Private _AccCode As String = ""
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _Address3 As String = ""
        Private _Address4 As String = ""
        Private _AttnName As String = ""
        Private _CommodityCode As String = ""
        Private _GoodsDescription1 As String = ""
        Private _GoodsDescription2 As String = ""
        Private _GoodsDescription3 As String = ""
        Private _GoodsDescription4 As String = ""
        Private _CashAmt As String = ""
        Private _CashLocalAmt As String = ""
        Private _ChargeRate As String = ""
        Private _ChargeWeight As String = ""
        Private _ChequeAmt As String = ""
        Private _ChequeLocalAmt As String = ""
        Private _ChequeNo As String = ""
        Private _CollectBy As String = ""
        Private _ConsoleFlag As String = ""
        Private _CurrCode As String = ""
        Private _CurrRate As String = ""
        Private _DestCode As String = ""
        Private _DistrictCode As String = ""
        Private _DivisionCode As String = ""
        Private _DueDate As String = ""
        Private _EtaDate As String = ""
        Private _EtdDate As String = ""
        Private _FeederVesselName As String = ""
        Private _FeederVoyage As String = ""
        Private _FirstViaPortCode As String = ""
        Private _FlightOrVoyageNo As String = ""
        Private _Footer1 As String = ""
        Private _Footer2 As String = ""
        Private _Footer3 As String = ""
        Private _Footer4 As String = ""
        Private _Footer5 As String = ""
        Private _GrossProfit As String = ""
        Private _GrossWeight As String = ""
        Private _InvoiceAndVatAmt As String = ""
        Private _InvoiceAndVatLocalAmt As String = ""
        Private _InvoiceCostAmt As String = ""
        Private _InvoiceDate As String = ""
        Private _InvoiceAmt As String = ""
        Private _InvoiceLocalAmt As String = ""
        Private _InvoiceType As String = ""
        Private _JobType As String = ""
        Private _LetterOfCreditNo As String = ""
        Private _ModuleCode As String = ""
        Private _NoOf20ftContainer As String = ""
        Private _NoOf40ftContainer As String = ""
        Private _NoOf45ftContainer As String = ""
        Private _OriginCode As String = ""
        Private _OurRef As String = ""
        Private _Pcs As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _PortOfDischargeName As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _PortOfLoadingName As String = ""
        Private _PostDate As String = ""
        Private _PostMth As String = ""
        Private _PostalCode As String = ""
        Private _Remark As String = ""
        Private _SalesmanCode As String = ""
        Private _SiteCode As String = ""
        Private _Telephone As String = ""
        Private _TermCode As String = ""
        Private _TotalExmAmt As String = ""
        Private _TotalStdAmt As String = ""
        Private _TotalZeroAmt As String = ""
        Private _TotalVatAmt As String = ""
        Private _TotalLocalVatAmt As String = ""
        Private _VesselCode As String = ""
        Private _VesselName As String = ""
        Private _Volume As String = ""
        Private _WithHoldingTaxAmt As String = ""
        Private _WithHoldingTaxNo As String = ""
        Private _YourRef As String = ""
        Private _EdiCount As String = ""
        Private _EmailCount As String = ""
        Private _ExportCount As String = ""
        Private _FaxCount As String = ""
        Private _PrintCount As String = ""
        Private _PostFlag As String = ""
        Private _TransferFlag As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _WorkStation As String = ""
        Private _StatusCode As String = ""
        Private _TemplateName As String = ""
        Private _OpInvoiceTrxNo As String = ""
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
        Public Property RefNo() As String
            Set(ByVal value As String)
                If _RefNo <> value Then
                    _RefNo = value
                End If
            End Set
            Get
                Return _RefNo
            End Get
        End Property
        ' 
        Public Property InvoiceNo() As String
            Set(ByVal value As String)
                If _InvoiceNo <> value Then
                    _InvoiceNo = value
                End If
            End Set
            Get
                Return _InvoiceNo
            End Get
        End Property
        ' 
        Public Property ApplyToInvoice() As String
            Set(ByVal value As String)
                If _ApplyToInvoice <> value Then
                    _ApplyToInvoice = value
                End If
            End Set
            Get
                Return _ApplyToInvoice
            End Get
        End Property
        ' 
        Public Property AwbOrBlNo() As String
            Set(ByVal value As String)
                If _AwbOrBlNo <> value Then
                    _AwbOrBlNo = value
                End If
            End Set
            Get
                Return _AwbOrBlNo
            End Get
        End Property
        ' 
        Public Property MAwbOrOBlNo() As String
            Set(ByVal value As String)
                If _MAwbOrOBlNo <> value Then
                    _MAwbOrOBlNo = value
                End If
            End Set
            Get
                Return _MAwbOrOBlNo
            End Get
        End Property
        ' 
        Public Property HAwbOrHBlNo() As String
            Set(ByVal value As String)
                If _HAwbOrHBlNo <> value Then
                    _HAwbOrHBlNo = value
                End If
            End Set
            Get
                Return _HAwbOrHBlNo
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
        Public Property BillingPartyCode() As String
            Set(ByVal value As String)
                If _BillingPartyCode <> value Then
                    _BillingPartyCode = value
                End If
            End Set
            Get
                Return _BillingPartyCode
            End Get
        End Property
        ' 
        Public Property TrxType() As String
            Set(ByVal value As String)
                If _TrxType <> value Then
                    _TrxType = value
                End If
            End Set
            Get
                Return _TrxType
            End Get
        End Property
        ' 
        Public Property PpCcFlag() As String
            Set(ByVal value As String)
                If _PpCcFlag <> value Then
                    _PpCcFlag = value
                End If
            End Set
            Get
                Return _PpCcFlag
            End Get
        End Property
        ' 
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
        ' 
        Public Property BarCode1() As String
            Set(ByVal value As String)
                If _BarCode1 <> value Then
                    _BarCode1 = value
                End If
            End Set
            Get
                Return _BarCode1
            End Get
        End Property
        ' 
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
        Public Property AccCode() As String
            Set(ByVal value As String)
                If _AccCode <> value Then
                    _AccCode = value
                End If
            End Set
            Get
                Return _AccCode
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property AttnName() As String
            Set(ByVal value As String)
                If _AttnName <> value Then
                    _AttnName = value
                End If
            End Set
            Get
                Return _AttnName
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
        Public Property GoodsDescription1() As String
            Set(ByVal value As String)
                If _GoodsDescription1 <> value Then
                    _GoodsDescription1 = value
                End If
            End Set
            Get
                Return _GoodsDescription1
            End Get
        End Property
        ' 
        Public Property GoodsDescription2() As String
            Set(ByVal value As String)
                If _GoodsDescription2 <> value Then
                    _GoodsDescription2 = value
                End If
            End Set
            Get
                Return _GoodsDescription2
            End Get
        End Property
        ' 
        Public Property GoodsDescription3() As String
            Set(ByVal value As String)
                If _GoodsDescription3 <> value Then
                    _GoodsDescription3 = value
                End If
            End Set
            Get
                Return _GoodsDescription3
            End Get
        End Property
        ' 
        Public Property GoodsDescription4() As String
            Set(ByVal value As String)
                If _GoodsDescription4 <> value Then
                    _GoodsDescription4 = value
                End If
            End Set
            Get
                Return _GoodsDescription4
            End Get
        End Property
        ' 
        Public Property CashAmt() As String
            Set(ByVal value As String)
                If _CashAmt <> value Then
                    _CashAmt = value
                End If
            End Set
            Get
                Return _CashAmt
            End Get
        End Property
        ' 
        Public Property CashLocalAmt() As String
            Set(ByVal value As String)
                If _CashLocalAmt <> value Then
                    _CashLocalAmt = value
                End If
            End Set
            Get
                Return _CashLocalAmt
            End Get
        End Property
        ' 
        Public Property ChargeRate() As String
            Set(ByVal value As String)
                If _ChargeRate <> value Then
                    _ChargeRate = value
                End If
            End Set
            Get
                Return _ChargeRate
            End Get
        End Property
        ' 
        Public Property ChargeWeight() As String
            Set(ByVal value As String)
                If _ChargeWeight <> value Then
                    _ChargeWeight = value
                End If
            End Set
            Get
                Return _ChargeWeight
            End Get
        End Property
        ' 
        Public Property ChequeAmt() As String
            Set(ByVal value As String)
                If _ChequeAmt <> value Then
                    _ChequeAmt = value
                End If
            End Set
            Get
                Return _ChequeAmt
            End Get
        End Property
        ' 
        Public Property ChequeLocalAmt() As String
            Set(ByVal value As String)
                If _ChequeLocalAmt <> value Then
                    _ChequeLocalAmt = value
                End If
            End Set
            Get
                Return _ChequeLocalAmt
            End Get
        End Property
        ' 
        Public Property ChequeNo() As String
            Set(ByVal value As String)
                If _ChequeNo <> value Then
                    _ChequeNo = value
                End If
            End Set
            Get
                Return _ChequeNo
            End Get
        End Property
        ' 
        Public Property CollectBy() As String
            Set(ByVal value As String)
                If _CollectBy <> value Then
                    _CollectBy = value
                End If
            End Set
            Get
                Return _CollectBy
            End Get
        End Property
        ' 
        Public Property ConsoleFlag() As String
            Set(ByVal value As String)
                If _ConsoleFlag <> value Then
                    _ConsoleFlag = value
                End If
            End Set
            Get
                Return _ConsoleFlag
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
        Public Property CurrRate() As String
            Set(ByVal value As String)
                If _CurrRate <> value Then
                    _CurrRate = value
                End If
            End Set
            Get
                Return _CurrRate
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
        Public Property DistrictCode() As String
            Set(ByVal value As String)
                If _DistrictCode <> value Then
                    _DistrictCode = value
                End If
            End Set
            Get
                Return _DistrictCode
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
        Public Property DueDate() As String
            Set(ByVal value As String)
                If _DueDate <> value Then
                    _DueDate = value
                End If
            End Set
            Get
                Return _DueDate
            End Get
        End Property
        ' 
        Public Property EtaDate() As String
            Set(ByVal value As String)
                If _EtaDate <> value Then
                    _EtaDate = value
                End If
            End Set
            Get
                Return _EtaDate
            End Get
        End Property
        ' 
        Public Property EtdDate() As String
            Set(ByVal value As String)
                If _EtdDate <> value Then
                    _EtdDate = value
                End If
            End Set
            Get
                Return _EtdDate
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property FlightOrVoyageNo() As String
            Set(ByVal value As String)
                If _FlightOrVoyageNo <> value Then
                    _FlightOrVoyageNo = value
                End If
            End Set
            Get
                Return _FlightOrVoyageNo
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property GrossProfit() As String
            Set(ByVal value As String)
                If _GrossProfit <> value Then
                    _GrossProfit = value
                End If
            End Set
            Get
                Return _GrossProfit
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
        Public Property InvoiceAndVatAmt() As String
            Set(ByVal value As String)
                If _InvoiceAndVatAmt <> value Then
                    _InvoiceAndVatAmt = value
                End If
            End Set
            Get
                Return _InvoiceAndVatAmt
            End Get
        End Property
        ' 
        Public Property InvoiceAndVatLocalAmt() As String
            Set(ByVal value As String)
                If _InvoiceAndVatLocalAmt <> value Then
                    _InvoiceAndVatLocalAmt = value
                End If
            End Set
            Get
                Return _InvoiceAndVatLocalAmt
            End Get
        End Property
        ' 
        Public Property InvoiceCostAmt() As String
            Set(ByVal value As String)
                If _InvoiceCostAmt <> value Then
                    _InvoiceCostAmt = value
                End If
            End Set
            Get
                Return _InvoiceCostAmt
            End Get
        End Property
        ' 
        Public Property InvoiceDate() As String
            Set(ByVal value As String)
                If _InvoiceDate <> value Then
                    _InvoiceDate = value
                End If
            End Set
            Get
                Return _InvoiceDate
            End Get
        End Property
        ' 
        Public Property InvoiceAmt() As String
            Set(ByVal value As String)
                If _InvoiceAmt <> value Then
                    _InvoiceAmt = value
                End If
            End Set
            Get
                Return _InvoiceAmt
            End Get
        End Property
        ' 
        Public Property InvoiceLocalAmt() As String
            Set(ByVal value As String)
                If _InvoiceLocalAmt <> value Then
                    _InvoiceLocalAmt = value
                End If
            End Set
            Get
                Return _InvoiceLocalAmt
            End Get
        End Property
        ' 
        Public Property InvoiceType() As String
            Set(ByVal value As String)
                If _InvoiceType <> value Then
                    _InvoiceType = value
                End If
            End Set
            Get
                Return _InvoiceType
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
        ' 
        Public Property ModuleCode() As String
            Set(ByVal value As String)
                If _ModuleCode <> value Then
                    _ModuleCode = value
                End If
            End Set
            Get
                Return _ModuleCode
            End Get
        End Property
        ' 
        Public Property NoOf20ftContainer() As String
            Set(ByVal value As String)
                If _NoOf20ftContainer <> value Then
                    _NoOf20ftContainer = value
                End If
            End Set
            Get
                Return _NoOf20ftContainer
            End Get
        End Property
        ' 
        Public Property NoOf40ftContainer() As String
            Set(ByVal value As String)
                If _NoOf40ftContainer <> value Then
                    _NoOf40ftContainer = value
                End If
            End Set
            Get
                Return _NoOf40ftContainer
            End Get
        End Property
        ' 
        Public Property NoOf45ftContainer() As String
            Set(ByVal value As String)
                If _NoOf45ftContainer <> value Then
                    _NoOf45ftContainer = value
                End If
            End Set
            Get
                Return _NoOf45ftContainer
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
        Public Property OurRef() As String
            Set(ByVal value As String)
                If _OurRef <> value Then
                    _OurRef = value
                End If
            End Set
            Get
                Return _OurRef
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property PostDate() As String
            Set(ByVal value As String)
                If _PostDate <> value Then
                    _PostDate = value
                End If
            End Set
            Get
                Return _PostDate
            End Get
        End Property
        ' 
        Public Property PostMth() As String
            Set(ByVal value As String)
                If _PostMth <> value Then
                    _PostMth = value
                End If
            End Set
            Get
                Return _PostMth
            End Get
        End Property
        ' 
        Public Property PostalCode() As String
            Set(ByVal value As String)
                If _PostalCode <> value Then
                    _PostalCode = value
                End If
            End Set
            Get
                Return _PostalCode
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
        Public Property Telephone() As String
            Set(ByVal value As String)
                If _Telephone <> value Then
                    _Telephone = value
                End If
            End Set
            Get
                Return _Telephone
            End Get
        End Property
        ' 
        Public Property TermCode() As String
            Set(ByVal value As String)
                If _TermCode <> value Then
                    _TermCode = value
                End If
            End Set
            Get
                Return _TermCode
            End Get
        End Property
        ' 
        Public Property TotalExmAmt() As String
            Set(ByVal value As String)
                If _TotalExmAmt <> value Then
                    _TotalExmAmt = value
                End If
            End Set
            Get
                Return _TotalExmAmt
            End Get
        End Property
        ' 
        Public Property TotalStdAmt() As String
            Set(ByVal value As String)
                If _TotalStdAmt <> value Then
                    _TotalStdAmt = value
                End If
            End Set
            Get
                Return _TotalStdAmt
            End Get
        End Property
        ' 
        Public Property TotalZeroAmt() As String
            Set(ByVal value As String)
                If _TotalZeroAmt <> value Then
                    _TotalZeroAmt = value
                End If
            End Set
            Get
                Return _TotalZeroAmt
            End Get
        End Property
        ' 
        Public Property TotalVatAmt() As String
            Set(ByVal value As String)
                If _TotalVatAmt <> value Then
                    _TotalVatAmt = value
                End If
            End Set
            Get
                Return _TotalVatAmt
            End Get
        End Property
        ' 
        Public Property TotalLocalVatAmt() As String
            Set(ByVal value As String)
                If _TotalLocalVatAmt <> value Then
                    _TotalLocalVatAmt = value
                End If
            End Set
            Get
                Return _TotalLocalVatAmt
            End Get
        End Property
        ' 
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
        ' 
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
        Public Property WithHoldingTaxAmt() As String
            Set(ByVal value As String)
                If _WithHoldingTaxAmt <> value Then
                    _WithHoldingTaxAmt = value
                End If
            End Set
            Get
                Return _WithHoldingTaxAmt
            End Get
        End Property
        ' 
        Public Property WithHoldingTaxNo() As String
            Set(ByVal value As String)
                If _WithHoldingTaxNo <> value Then
                    _WithHoldingTaxNo = value
                End If
            End Set
            Get
                Return _WithHoldingTaxNo
            End Get
        End Property
        ' 
        Public Property YourRef() As String
            Set(ByVal value As String)
                If _YourRef <> value Then
                    _YourRef = value
                End If
            End Set
            Get
                Return _YourRef
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
        ' 
        Public Property OpInvoiceTrxNo() As String
            Set(ByVal value As String)
                If _OpInvoiceTrxNo <> value Then
                    _OpInvoiceTrxNo = value
                End If
            End Set
            Get
                Return _OpInvoiceTrxNo
            End Get
        End Property


        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _TrxNo = strId
            _RefNo = ""
            _InvoiceNo = ""
            _ApplyToInvoice = ""
            _AwbOrBlNo = ""
            _MAwbOrOBlNo = ""
            _HAwbOrHBlNo = ""
            _JobNo = ""
            _BillingPartyCode = ""
            _TrxType = ""
            _PpCcFlag = ""
            _BarCode = ""
            _BarCode1 = ""
            _CustomerCode = ""
            _CustomerName = ""
            _AccCode = ""
            _Address1 = ""
            _Address2 = ""
            _Address3 = ""
            _Address4 = ""
            _AttnName = ""
            _CommodityCode = ""
            _GoodsDescription1 = ""
            _GoodsDescription2 = ""
            _GoodsDescription3 = ""
            _GoodsDescription4 = ""
            _CashAmt = ""
            _CashLocalAmt = ""
            _ChargeRate = ""
            _ChargeWeight = ""
            _ChequeAmt = ""
            _ChequeLocalAmt = ""
            _ChequeNo = ""
            _CollectBy = ""
            _ConsoleFlag = ""
            _CurrCode = ""
            _CurrRate = ""
            _DestCode = ""
            _DistrictCode = ""
            _DivisionCode = ""
            _DueDate = ""
            _EtaDate = ""
            _EtdDate = ""
            _FeederVesselName = ""
            _FeederVoyage = ""
            _FirstViaPortCode = ""
            _FlightOrVoyageNo = ""
            _Footer1 = ""
            _Footer2 = ""
            _Footer3 = ""
            _Footer4 = ""
            _Footer5 = ""
            _GrossProfit = ""
            _GrossWeight = ""
            _InvoiceAndVatAmt = ""
            _InvoiceAndVatLocalAmt = ""
            _InvoiceCostAmt = ""
            _InvoiceDate = ""
            _InvoiceAmt = ""
            _InvoiceLocalAmt = ""
            _InvoiceType = ""
            _JobType = ""
            _LetterOfCreditNo = ""
            _ModuleCode = ""
            _NoOf20ftContainer = ""
            _NoOf40ftContainer = ""
            _NoOf45ftContainer = ""
            _OriginCode = ""
            _OurRef = ""
            _Pcs = ""
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _PortOfLoadingCode = ""
            _PortOfLoadingName = ""
            _PostDate = ""
            _PostMth = ""
            _PostalCode = ""
            _Remark = ""
            _SalesmanCode = ""
            _SiteCode = ""
            _Telephone = ""
            _TermCode = ""
            _TotalExmAmt = ""
            _TotalStdAmt = ""
            _TotalZeroAmt = ""
            _TotalVatAmt = ""
            _TotalLocalVatAmt = ""
            _VesselCode = ""
            _VesselName = ""
            _Volume = ""
            _WithHoldingTaxAmt = ""
            _WithHoldingTaxNo = ""
            _YourRef = ""
            _EdiCount = ""
            _EmailCount = ""
            _ExportCount = ""
            _FaxCount = ""
            _PrintCount = ""
            _PostFlag = ""
            _TransferFlag = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _WorkStation = ""
            _StatusCode = ""
            _TemplateName = ""
            _OpInvoiceTrxNo = ""
        End Sub

    End Class

#End Region
End Namespace
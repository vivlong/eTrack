Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Tracking "
    Public Class clsPropTracking
        Inherits clsProp
        Private _JobNo As String = ""
        Private _AwbBlNo As String = ""
        Private _JobType As String = ""
        Private _MasterJobNo As String = ""
        Private _ShipmentType As String = ""
        Private _Etd As DateTime
        Private _PortOfDischargeCode As String = ""
        Private _PortOfDischargeName As String = ""
        Private _VesselCode As String = ""
        Private _FeederVesselName As String = ""
        Private _AttachmentFlag As String = ""
        Private _AirlineCode As String = ""
        Private _AwbBlStatus As String = ""
        Private _AwbBlType As String = ""
        Private _CargoType As String = ""
        Private _CloseDateTime As DateTime
        Private _ColoaderCode As String = ""
        Private _CommodityCode As String = ""
        Private _CommodityDescription As String = ""
        Private _ConsigneeCode As String = ""
        Private _ConsigneeName As String = ""
        Private _ContainerNo As String = ""
        Private _CostAmt As Decimal
        Private _CostingApproveFlag As String = ""
        Private _CustomerCode As String = ""
        Private _CustomerRefNo As String = ""
        Private _CustomerName As String = ""
        Private _DeliveryAgentCode As String = ""
        Private _DeliveryAgentName As String = ""
        Private _DeliveryTerm As String = ""
        Private _DeliveryType As String = ""
        Private _DestCode As String = ""
        Private _Eta As DateTime
        Private _FrtPpCcFlag As String = ""
        Private _GrossProfit As Decimal
        Private _HouseSeqNo As String = ""
        Private _InvoiceLocalAmt As Decimal
        Private _JobDate As DateTime
        Private _JobMth As String = ""
        Private _HAwbHblNo As String = ""
        Private _FirstViaPortCode As String = ""
        Private _MAwbOblNo As String = ""
        Private _ModuleCode As String = ""
        Private _MultiModalJobNo As String = ""
        Private _NoOf20ftContainer As Integer
        Private _NoOf40ftContainer As Integer
        Private _NoOf45ftContainer As Integer
        Private _OriginCode As String = ""
        Private _OtherPpCcFlag As String = ""
        Private _Payment As Decimal
        Private _PortOfLoading As String = ""
        Private _PortOfLoadingName As String = ""
        Private _PpCcFlag As String = ""
        Private _ProvisionCostAmt As Decimal
        Private _PurchaseAmt As Decimal
        Private _ReceiptAmt As Decimal
        Private _ChargeRate As Decimal
        Private _SalesAmt As Decimal
        Private _SalesmanCode As String = ""
        Private _ShipperCode As String = ""
        Private _ShipperName As String = ""
        Private _ShippinglineCode As String = ""
        Private _SubMasterFlag As String = ""
        Private _ChargeWeight As Decimal
        Private _GrossWeight As Decimal
        Private _VoyageNo As String = ""
        Private _FeederVoyage As String = ""
        Private _VesselName As String = ""
        Private _Volume As Decimal
        Private _Pcs As Integer
        Private _TemplateName As String = ""
        Private _UomCode As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _PostFlag As String = ""
        Private _DBName As String = ""
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
        Public Property AwbBlNo() As String
            Set(ByVal value As String)
                If _AwbBlNo <> value Then
                    _AwbBlNo = value
                End If
            End Set
            Get
                Return _AwbBlNo
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
        Public Property Etd() As DateTime
            Set(ByVal value As DateTime)
                If _Etd <> value Then
                    _Etd = value
                End If
            End Set
            Get
                Return _Etd
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
        Public Property AirlineCode() As String
            Set(ByVal value As String)
                If _AirlineCode <> value Then
                    _AirlineCode = value
                End If
            End Set
            Get
                Return _AirlineCode
            End Get
        End Property
        ' 
        Public Property AwbBlStatus() As String
            Set(ByVal value As String)
                If _AwbBlStatus <> value Then
                    _AwbBlStatus = value
                End If
            End Set
            Get
                Return _AwbBlStatus
            End Get
        End Property
        ' 
        Public Property AwbBlType() As String
            Set(ByVal value As String)
                If _AwbBlType <> value Then
                    _AwbBlType = value
                End If
            End Set
            Get
                Return _AwbBlType
            End Get
        End Property
        ' 
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
        ' 
        Public Property CostAmt() As Decimal
            Set(ByVal value As Decimal)
                If _CostAmt <> value Then
                    _CostAmt = value
                End If
            End Set
            Get
                Return _CostAmt
            End Get
        End Property
        ' 
        Public Property CostingApproveFlag() As String
            Set(ByVal value As String)
                If _CostingApproveFlag <> value Then
                    _CostingApproveFlag = value
                End If
            End Set
            Get
                Return _CostingApproveFlag
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
        Public Property DeliveryTerm() As String
            Set(ByVal value As String)
                If _DeliveryTerm <> value Then
                    _DeliveryTerm = value
                End If
            End Set
            Get
                Return _DeliveryTerm
            End Get
        End Property
        ' 
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
        Public Property Eta() As DateTime
            Set(ByVal value As DateTime)
                If _Eta <> value Then
                    _Eta = value
                End If
            End Set
            Get
                Return _Eta
            End Get
        End Property
        ' 
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
        ' 
        Public Property GrossProfit() As Decimal
            Set(ByVal value As Decimal)
                If _GrossProfit <> value Then
                    _GrossProfit = value
                End If
            End Set
            Get
                Return _GrossProfit
            End Get
        End Property
        ' 
        Public Property HouseSeqNo() As String
            Set(ByVal value As String)
                If _HouseSeqNo <> value Then
                    _HouseSeqNo = value
                End If
            End Set
            Get
                Return _HouseSeqNo
            End Get
        End Property
        ' 
        Public Property InvoiceLocalAmt() As Decimal
            Set(ByVal value As Decimal)
                If _InvoiceLocalAmt <> value Then
                    _InvoiceLocalAmt = value
                End If
            End Set
            Get
                Return _InvoiceLocalAmt
            End Get
        End Property
        ' 
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
        Public Property HAwbHblNo() As String
            Set(ByVal value As String)
                If _HAwbHblNo <> value Then
                    _HAwbHblNo = value
                End If
            End Set
            Get
                Return _HAwbHblNo
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
        Public Property MAwbOblNo() As String
            Set(ByVal value As String)
                If _MAwbOblNo <> value Then
                    _MAwbOblNo = value
                End If
            End Set
            Get
                Return _MAwbOblNo
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
        Public Property MultiModalJobNo() As String
            Set(ByVal value As String)
                If _MultiModalJobNo <> value Then
                    _MultiModalJobNo = value
                End If
            End Set
            Get
                Return _MultiModalJobNo
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property Payment() As Decimal
            Set(ByVal value As Decimal)
                If _Payment <> value Then
                    _Payment = value
                End If
            End Set
            Get
                Return _Payment
            End Get
        End Property
        ' 
        Public Property PortOfLoading() As String
            Set(ByVal value As String)
                If _PortOfLoading <> value Then
                    _PortOfLoading = value
                End If
            End Set
            Get
                Return _PortOfLoading
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
        Public Property ProvisionCostAmt() As Decimal
            Set(ByVal value As Decimal)
                If _ProvisionCostAmt <> value Then
                    _ProvisionCostAmt = value
                End If
            End Set
            Get
                Return _ProvisionCostAmt
            End Get
        End Property
        ' 
        Public Property PurchaseAmt() As Decimal
            Set(ByVal value As Decimal)
                If _PurchaseAmt <> value Then
                    _PurchaseAmt = value
                End If
            End Set
            Get
                Return _PurchaseAmt
            End Get
        End Property
        ' 
        Public Property ReceiptAmt() As Decimal
            Set(ByVal value As Decimal)
                If _ReceiptAmt <> value Then
                    _ReceiptAmt = value
                End If
            End Set
            Get
                Return _ReceiptAmt
            End Get
        End Property
        ' 
        Public Property ChargeRate() As Decimal
            Set(ByVal value As Decimal)
                If _ChargeRate <> value Then
                    _ChargeRate = value
                End If
            End Set
            Get
                Return _ChargeRate
            End Get
        End Property
        ' 
        Public Property SalesAmt() As Decimal
            Set(ByVal value As Decimal)
                If _SalesAmt <> value Then
                    _SalesAmt = value
                End If
            End Set
            Get
                Return _SalesAmt
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
        ' 
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
        ' 
        Public Property ChargeWeight() As Decimal
            Set(ByVal value As Decimal)
                If _ChargeWeight <> value Then
                    _ChargeWeight = value
                End If
            End Set
            Get
                Return _ChargeWeight
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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

        Public Property DBName() As String
            Set(ByVal value As String)
                If _DBName <> value Then
                    _DBName = value
                End If
            End Set
            Get
                Return _DBName
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _JobNo = ""
            _AwbBlNo = ""
            _JobType = ""
            _MasterJobNo = ""
            _ShipmentType = ""
            _Etd = ConDateTime.MinDate
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _VesselCode = ""
            _FeederVesselName = ""
            _AttachmentFlag = ""
            _AirlineCode = ""
            _AwbBlStatus = ""
            _AwbBlType = ""
            _CargoType = ""
            _CloseDateTime = ConDateTime.MinDate
            _ColoaderCode = ""
            _CommodityCode = ""
            _CommodityDescription = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _ContainerNo = ""
            _CostAmt = 0
            _CostingApproveFlag = ""
            _CustomerCode = ""
            _CustomerRefNo = ""
            _CustomerName = ""
            _DeliveryAgentCode = ""
            _DeliveryAgentName = ""
            _DeliveryTerm = ""
            _DeliveryType = ""
            _DestCode = ""
            _Eta = ConDateTime.MinDate
            _FrtPpCcFlag = ""
            _GrossProfit = 0
            _HouseSeqNo = ""
            _InvoiceLocalAmt = 0
            _JobDate = ConDateTime.MinDate
            _JobMth = ""
            _HAwbHblNo = ""
            _FirstViaPortCode = ""
            _MAwbOblNo = ""
            _ModuleCode = ""
            _MultiModalJobNo = ""
            _NoOf20ftContainer = 0
            _NoOf40ftContainer = 0
            _NoOf45ftContainer = 0
            _OriginCode = ""
            _OtherPpCcFlag = ""
            _Payment = 0
            _PortOfLoading = ""
            _PortOfLoadingName = ""
            _PpCcFlag = ""
            _ProvisionCostAmt = 0
            _PurchaseAmt = 0
            _ReceiptAmt = 0
            _ChargeRate = 0
            _SalesAmt = 0
            _SalesmanCode = ""
            _ShipperCode = ""
            _ShipperName = ""
            _ShippinglineCode = ""
            _SubMasterFlag = ""
            _ChargeWeight = 0
            _GrossWeight = 0
            _VoyageNo = ""
            _FeederVoyage = ""
            _VesselName = ""
            _Volume = 0
            _Pcs = 0
            _TemplateName = ""
            _UomCode = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _PostFlag = ""
            _DBName = ""
        End Sub
    End Class
#End Region
End Namespace

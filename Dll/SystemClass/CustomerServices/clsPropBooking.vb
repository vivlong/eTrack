Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Booking Info "

    <Serializable()> _
    Public Class clsPropBooking
        Inherits clsProp
        Private _TrxNo As Int64
        Private _OrderNo As String = ""
        Private _LineItemNo As String = ""
        Private _AirlineId As String = ""
        Private _AirportDeptCode As String = ""
        Private _AirportDestCode As String = ""
        Private _AwbNo As String = ""
        Private _JobType As String = ""
        Private _BalanceGrossWeight As String = ""
        Private _BalancePcs As String = ""
        Private _BlNo As String = ""
        Private _CargoReadyDate As String = ""
        Private _CargoStatusCode As String = ""
        Private _CommodityDescription As String = ""
        Private _ConsigneeName As String = ""
        Private _CustomerCode As String = ""
        Private _EtaDate As DateTime
        Private _EtdDate As DateTime
        Private _FlightNo As String = ""
        Private _InvoiceNo As String = ""
        Private _MarkNo As String = ""
        Private _Note As String = ""
        Private _OrderDate As DateTime
        Private _OrderType As String = ""
        Private _PackingQty As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _PortOfLoadingName As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _PortOfDischargeName As String = ""
        Private _Qty As String = ""
        Private _ShipperCode As String = ""
        Private _ShipperName As String = ""
        Private _Wt As String = ""
        Private _VesselName As String = ""
        Private _VoyageNo As String = ""
        Private _WarehouseName As String = ""
        Private _ConsigneeCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _WorkStation As String = ""
        Private _StatusCode As String = ""
        Private _CommodityCode As String = ""
        Private _GrossWeight As String = ""
        Private _JobDate As DateTime
        Private _Pcs As String = ""
        Private _VesselCode As String = ""
        Private _Volume As String = ""
        Private _CustomerName As String = ""
        Private _ModuleCode As String = ""
        Private _ContactName As String = ""
        Private _ShipperAddress1 As String = ""
        Private _ShipperAddress2 As String = ""
        Private _ShipperAddress3 As String = ""
        Private _ShipperAddress4 As String = ""
        Private _ConsigneeAddress1 As String = ""
        Private _ConsigneeAddress2 As String = ""
        Private _ConsigneeAddress3 As String = ""
        Private _ConsigneeAddress4 As String = ""
        Private _ContainerType1 As String = ""
        Private _CollectFromAddress1 As String = ""
        Private _CollectFromAddress2 As String = ""
        Private _CollectFromAddress3 As String = ""
        Private _CollectFromAddress4 As String = ""
        Private _CollectFromName As String = ""
        Private _UomCode As String = ""
        Private _AttachmentFlag As String = ""
        Private _SpecialInstruction As String = ""
        Private _DgFlag As String = ""
        Private _DeliveryType As String = ""
        Private _DeliveryTypeName As String = ""
        Private _DestCode As String = ""
        Private _DestName As String = ""
        Private _OriginCode As String = ""
        Private _OriginName As String = ""
        Private _CargoType As String = ""
        Private _NoOfContainer3 As String = ""
        Private _ContainerType3 As String = ""
        Private _NoOfContainer2 As String = ""
        Private _ContainerType2 As String = ""
        Private _NoOfContainer1 As String = ""
        Private _PickupDateTime As DateTime
        'from sebk1
        Private _JobNo As String = ""
        Private _BookingNo As String = ""
        '090313
        Private _AirportDeptName As String = ""
        Private _AirportDestName As String = ""
        '090325 for TP .net 836
        Private _DeliverToName As String = ""
        Private _DeliverToAddress1 As String = ""
        Private _DeliverToAddress2 As String = ""
        Private _DeliverToAddress3 As String = ""
        Private _DeliverToAddress4 As String = ""
        Private _DeliverToDateTime As DateTime
        Private _DescriptionOfGoods1 As String = ""
        Private _DescriptionOfGoods2 As String = ""
        Private _DescriptionOfGoods3 As String = ""
        Private _DescriptionOfGoods4 As String = ""
        'NET 1786
        Private _PackingQty1 As String = ""
        Private _PackingQty2 As String = ""
        Private _PackingQty3 As String = ""
        Private _PackingQty4 As String = ""
        Private _PackingQty5 As String = ""
        Private _Telephone As String = ""
        Private _OrderNoBarCode As String = ""
        Private _BalancePcsTotal As String = ""



        Public Property TrxNo() As Int64
            Set(ByVal value As Int64)
                If _TrxNo <> value Then
                    _TrxNo = value
                End If
            End Set
            Get
                Return _TrxNo
            End Get
        End Property

        Public Property OrderNo() As String
            Set(ByVal value As String)
                If _OrderNo <> value Then
                    _OrderNo = value
                End If
            End Set
            Get
                Return _OrderNo
            End Get
        End Property

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

        Public Property AirlineId() As String
            Set(ByVal value As String)
                If _AirlineId <> value Then
                    _AirlineId = value
                End If
            End Set
            Get
                Return _AirlineId
            End Get
        End Property

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

        Public Property BalanceGrossWeight() As String
            Set(ByVal value As String)
                If _BalanceGrossWeight <> value Then
                    _BalanceGrossWeight = value
                End If
            End Set
            Get
                Return _BalanceGrossWeight
            End Get
        End Property

        Public Property BalancePcs() As String
            Set(ByVal value As String)
                If _BalancePcs <> value Then
                    _BalancePcs = value
                End If
            End Set
            Get
                Return _BalancePcs
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

        Public Property CargoReadyDate() As String
            Set(ByVal value As String)
                If _CargoReadyDate <> value Then
                    _CargoReadyDate = value
                End If
            End Set
            Get
                Return _CargoReadyDate
            End Get
        End Property

        Public Property CargoStatusCode() As String
            Set(ByVal value As String)
                If _CargoStatusCode <> value Then
                    _CargoStatusCode = value
                End If
            End Set
            Get
                Return _CargoStatusCode
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

        Public Property FlightNo() As String
            Set(ByVal value As String)
                If _FlightNo <> value Then
                    _FlightNo = value
                End If
            End Set
            Get
                Return _FlightNo
            End Get
        End Property

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

        Public Property MarkNo() As String
            Set(ByVal value As String)
                If _MarkNo <> value Then
                    _MarkNo = value
                End If
            End Set
            Get
                Return _MarkNo
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

        Public Property OrderDate() As DateTime
            Set(ByVal value As DateTime)
                If _OrderDate <> value Then
                    _OrderDate = value
                End If
            End Set
            Get
                Return _OrderDate
            End Get
        End Property

        Public Property OrderType() As String
            Set(ByVal value As String)
                If _OrderType <> value Then
                    _OrderType = value
                End If
            End Set
            Get
                Return _OrderType
            End Get
        End Property

        Public Property PackingQty() As String
            Set(ByVal value As String)
                If _PackingQty <> value Then
                    _PackingQty = value
                End If
            End Set
            Get
                Return _PackingQty
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

        Public Property Qty() As String
            Set(ByVal value As String)
                If _Qty <> value Then
                    _Qty = value
                End If
            End Set
            Get
                Return _Qty
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

        Public Property Wt() As String
            Set(ByVal value As String)
                If _Wt <> value Then
                    _Wt = value
                End If
            End Set
            Get
                Return _Wt
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

        Public Property WarehouseName() As String
            Set(ByVal value As String)
                If _WarehouseName <> value Then
                    _WarehouseName = value
                End If
            End Set
            Get
                Return _WarehouseName
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

        Public Property JobDate() As DateTime
            Set(ByVal value As DateTime)
                _JobDate = value
            End Set
            Get
                Return _JobDate
            End Get
        End Property

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

        Public Property SpecialInstruction() As String
            Set(ByVal value As String)
                If _SpecialInstruction <> value Then
                    _SpecialInstruction = value
                End If
            End Set
            Get
                Return _SpecialInstruction
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

        Public Property DeliveryTypeName() As String
            Set(ByVal value As String)
                If _DeliveryTypeName <> value Then
                    _DeliveryTypeName = value
                End If
            End Set
            Get
                Return _DeliveryTypeName
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

        Public Property OriginName() As String
            Set(ByVal value As String)
                If _OriginName <> value Then
                    _OriginName = value
                End If
            End Set
            Get
                Return _OriginName
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

        Public Property NoOfContainer3() As String
            Set(ByVal value As String)
                If _NoOfContainer3 <> value Then
                    _NoOfContainer3 = value
                End If
            End Set
            Get
                Return _NoOfContainer3
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

        Public Property NoOfContainer2() As String
            Set(ByVal value As String)
                If _NoOfContainer2 <> value Then
                    _NoOfContainer2 = value
                End If
            End Set
            Get
                Return _NoOfContainer2
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

        Public Property NoOfContainer1() As String
            Set(ByVal value As String)
                If _NoOfContainer1 <> value Then
                    _NoOfContainer1 = value
                End If
            End Set
            Get
                Return _NoOfContainer1
            End Get
        End Property

        Public Property PickupDateTime() As DateTime
            Set(ByVal value As DateTime)
                _PickupDateTime = value
            End Set
            Get
                Return _PickupDateTime
            End Get
        End Property
        'from sebk1
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


        Public Property DeliverToName() As String
            Set(ByVal value As String)
                If _DeliverToName <> value Then
                    _DeliverToName = value
                End If
            End Set
            Get
                Return _DeliverToName
            End Get
        End Property

        Public Property DeliverToAddress1() As String
            Set(ByVal value As String)
                If _DeliverToAddress1 <> value Then
                    _DeliverToAddress1 = value
                End If
            End Set
            Get
                Return _DeliverToAddress1
            End Get
        End Property

        Public Property DeliverToAddress2() As String
            Set(ByVal value As String)
                If _DeliverToAddress2 <> value Then
                    _DeliverToAddress2 = value
                End If
            End Set
            Get
                Return _DeliverToAddress2
            End Get
        End Property

        Public Property DeliverToAddress3() As String
            Set(ByVal value As String)
                If _DeliverToAddress3 <> value Then
                    _DeliverToAddress3 = value
                End If
            End Set
            Get
                Return _DeliverToAddress3
            End Get
        End Property

        Public Property DeliverToAddress4() As String
            Set(ByVal value As String)
                If _DeliverToAddress4 <> value Then
                    _DeliverToAddress4 = value
                End If
            End Set
            Get
                Return _DeliverToAddress4
            End Get
        End Property

        Public Property DeliverToDateTime() As DateTime
            Set(ByVal value As DateTime)
                _DeliverToDateTime = value
            End Set
            Get
                Return _DeliverToDateTime
            End Get
        End Property

        Public Property DescriptionOfGoods1() As String
            Set(ByVal value As String)
                If _DescriptionOfGoods1 <> value Then
                    _DescriptionOfGoods1 = value
                End If
            End Set
            Get
                Return _DescriptionOfGoods1
            End Get
        End Property


        Public Property DescriptionOfGoods2() As String
            Set(ByVal value As String)
                If _DescriptionOfGoods2 <> value Then
                    _DescriptionOfGoods2 = value
                End If
            End Set
            Get
                Return _DescriptionOfGoods2
            End Get
        End Property

        Public Property DescriptionOfGoods3() As String
            Set(ByVal value As String)
                If _DescriptionOfGoods3 <> value Then
                    _DescriptionOfGoods3 = value
                End If
            End Set
            Get
                Return _DescriptionOfGoods3
            End Get
        End Property

        Public Property DescriptionOfGoods4() As String
            Set(ByVal value As String)
                If _DescriptionOfGoods4 <> value Then
                    _DescriptionOfGoods4 = value
                End If
            End Set
            Get
                Return _DescriptionOfGoods4
            End Get
        End Property

        Public Property PackingQty1() As String
            Set(ByVal value As String)
                If _PackingQty1 <> value Then
                    _PackingQty1 = value
                End If
            End Set
            Get
                Return _PackingQty1
            End Get
        End Property
        Public Property PackingQty2() As String
            Set(ByVal value As String)
                If _PackingQty2 <> value Then
                    _PackingQty2 = value
                End If
            End Set
            Get
                Return _PackingQty2
            End Get
        End Property
        Public Property PackingQty3() As String
            Set(ByVal value As String)
                If _PackingQty3 <> value Then
                    _PackingQty3 = value
                End If
            End Set
            Get
                Return _PackingQty3
            End Get
        End Property
        Public Property PackingQty4() As String
            Set(ByVal value As String)
                If _PackingQty4 <> value Then
                    _PackingQty4 = value
                End If
            End Set
            Get
                Return _PackingQty4
            End Get
        End Property
        Public Property PackingQty5() As String
            Set(ByVal value As String)
                If _PackingQty5 <> value Then
                    _PackingQty5 = value
                End If
            End Set
            Get
                Return _PackingQty5
            End Get
        End Property
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
        Public Property OrderNoBarCode() As String
            Set(ByVal value As String)
                If _OrderNoBarCode <> value Then
                    _OrderNoBarCode = value
                End If
            End Set
            Get
                Return _OrderNoBarCode
            End Get
        End Property
        Public Property BalancePcsTotal() As String
            Set(ByVal value As String)
                If _BalancePcsTotal <> value Then
                    _BalancePcsTotal = value
                End If
            End Set
            Get
                Return _BalancePcsTotal
            End Get
        End Property
        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _OrderNo = ""
            _LineItemNo = 0
            _AirlineId = ""
            _AirportDeptCode = ""
            _AirportDestCode = ""
            _AwbNo = ""
            _JobType = ""
            _BalanceGrossWeight = 0
            _BalancePcs = 0
            _BlNo = ""
            _CargoReadyDate = ""
            _CargoStatusCode = ""
            _CommodityDescription = ""
            _ConsigneeName = ""
            _CustomerCode = ""
            _EtaDate = ConDateTime.MinDate
            _EtdDate = ConDateTime.MinDate
            _FlightNo = ""
            _InvoiceNo = ""
            _MarkNo = ""
            _Note = ""
            _OrderDate = ConDateTime.MinDate
            _OrderType = ""
            _PackingQty = 0
            _PortOfLoadingCode = ""
            _PortOfLoadingName = ""
            _PortOfDischargeCode = ""
            _PortOfDischargeName = ""
            _Qty = ""
            _ShipperCode = ""
            _ShipperName = ""
            _Wt = ""
            _VesselName = ""
            _VoyageNo = ""
            _WarehouseName = ""
            _ConsigneeCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _WorkStation = ""
            _StatusCode = ""
            _CommodityCode = ""
            _GrossWeight = 0
            _JobDate = ConDateTime.MinDate
            _Pcs = -1
            _VesselCode = ""
            _Volume = 0
            _CustomerName = ""
            _ModuleCode = ""
            _ContactName = ""
            _ShipperAddress1 = ""
            _ShipperAddress2 = ""
            _ShipperAddress3 = ""
            _ShipperAddress4 = ""
            _ConsigneeAddress1 = ""
            _ConsigneeAddress2 = ""
            _ConsigneeAddress3 = ""
            _ConsigneeAddress4 = ""
            _ContainerType1 = ""
            _CollectFromAddress1 = ""
            _CollectFromAddress2 = ""
            _CollectFromAddress3 = ""
            _CollectFromAddress4 = ""
            _CollectFromName = ""
            _UomCode = ""
            _AttachmentFlag = ""
            _SpecialInstruction = ""
            _DgFlag = ""
            _DeliveryType = ""
            _DeliveryTypeName = ""
            _DestCode = ""
            _DestName = ""
            _OriginCode = ""
            _OriginName = ""
            _CargoType = ""
            _NoOfContainer3 = -1
            _ContainerType3 = ""
            _NoOfContainer2 = -1
            _ContainerType2 = ""
            _NoOfContainer1 = -1
            _PickupDateTime = ConDateTime.MinDate
            _ContainerType2 = ""
            'from sebk1
            _BookingNo = ""
            _JobNo = ""
            _AirportDeptName = ""
            _AirportDestName = ""
            '090325 for TP .net 836
            _DeliverToName = ""
            _DeliverToAddress1 = ""
            _DeliverToAddress2 = ""
            _DeliverToAddress3 = ""
            _DeliverToAddress4 = ""
            _DeliverToDateTime = ConDateTime.MinDate
            _DescriptionOfGoods1 = ""
            _DescriptionOfGoods2 = ""
            _DescriptionOfGoods3 = ""
            _DescriptionOfGoods4 = ""
            _PackingQty1 = -1
            _PackingQty2 = -1
            _PackingQty3 = -1
            _PackingQty4 = -1
            _PackingQty5 = -1
            _Telephone = ""
            _OrderNoBarCode = ""
            _BalancePcsTotal = ""
            '_TestDate = ConDateTime.MinDate
            '_CreateDateTime = ConDateTime.Today
        End Sub

    End Class

#End Region
End Namespace
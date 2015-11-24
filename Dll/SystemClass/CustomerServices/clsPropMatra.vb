Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Matra Info "

    <Serializable()> _
    Public Class clsPropMatra
        Inherits clsProp
        Private _ChargeWeight As String = ""
        Private _CommodityDescription As String = ""
        Private _ConsignNoteRefNo As String = ""
        Private _DestName As String = ""
        Private _Eta As DateTime
        Private _Etd As DateTime
        Private _FlightOrVoyageNo As String = ""
        Private _GrossWeight As String = ""
        Private _HawbHblNo As String = ""
        Private _LocalMtoCode As String = ""
        Private _MawbOblNo As String = ""
        Private _Mro As String = ""
        Private _MtoNotificationDate As DateTime
        Private _MtoRep As String = ""
        Private _OriginName As String = ""
        Private _PartNo As String = ""
        Private _PickupDate As DateTime
        Private _PickupFrom As String = ""
        Private _PlaceOfDelivery As String = ""
        Private _PlaceOfDeliveryEta As DateTime
        Private _Qty As Int64
        Private _RfqNo As String = ""
        Private _SerialNo As String = ""
        Private _ShipDate As DateTime
        Private _ShipTo As String = ""
        Private _Status As String = ""
        Private _UomCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime

        Private _ConsignmentDate As DateTime
        Private _DateDeliveredToMro As DateTime
        Private _DateDeliveredToMtoRep As DateTime
        Private _DateReceivedFromMto As DateTime
        Private _DateReceivedFromMtoRep As DateTime
        Private _Driveric1 As String = ""
        Private _Driveric2 As String = ""
        Private _Driveric3 As String = ""
        Private _DriverName1 As String = ""
        Private _DriverName2 As String = ""
        Private _DriverName3 As String = ""
        Private _QuotationRefNo As String = ""
        Private _TearDownInspectionDate As DateTime

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
        Public Property ConsignNoteRefNo() As String
            Set(ByVal value As String)
                If _ConsignNoteRefNo <> value Then
                    _ConsignNoteRefNo = value
                End If
            End Set
            Get
                Return _ConsignNoteRefNo
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
        Public Property HawbHblNo() As String
            Set(ByVal value As String)
                If _HawbHblNo <> value Then
                    _HawbHblNo = value
                End If
            End Set
            Get
                Return _HawbHblNo
            End Get
        End Property
        Public Property LocalMtoCode() As String
            Set(ByVal value As String)
                If _LocalMtoCode <> value Then
                    _LocalMtoCode = value
                End If
            End Set
            Get
                Return _LocalMtoCode
            End Get
        End Property
        Public Property MawbOblNo() As String
            Set(ByVal value As String)
                If _MawbOblNo <> value Then
                    _MawbOblNo = value
                End If
            End Set
            Get
                Return _MawbOblNo
            End Get
        End Property
        Public Property Mro() As String
            Set(ByVal value As String)
                If _Mro <> value Then
                    _Mro = value
                End If
            End Set
            Get
                Return _Mro
            End Get
        End Property
        Public Property MtoNotificationDate() As DateTime
            Set(ByVal value As DateTime)
                If _MtoNotificationDate <> value Then
                    _MtoNotificationDate = value
                End If
            End Set
            Get
                Return _MtoNotificationDate
            End Get
        End Property
        Public Property MtoRep() As String
            Set(ByVal value As String)
                If _MtoRep <> value Then
                    _MtoRep = value
                End If
            End Set
            Get
                Return _MtoRep
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
        Public Property PartNo() As String
            Set(ByVal value As String)
                If _PartNo <> value Then
                    _PartNo = value
                End If
            End Set
            Get
                Return _PartNo
            End Get
        End Property
        Public Property PickupDate() As DateTime
            Set(ByVal value As DateTime)
                If _PickupDate <> value Then
                    _PickupDate = value
                End If
            End Set
            Get
                Return _PickupDate
            End Get
        End Property
        Public Property PickupFrom() As String
            Set(ByVal value As String)
                If _PickupFrom <> value Then
                    _PickupFrom = value
                End If
            End Set
            Get
                Return _PickupFrom
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
        Public Property PlaceOfDeliveryEta() As DateTime
            Set(ByVal value As DateTime)
                If _PlaceOfDeliveryEta <> value Then
                    _PlaceOfDeliveryEta = value
                End If
            End Set
            Get
                Return _PlaceOfDeliveryEta
            End Get
        End Property
        Public Property Qty() As Int64
            Set(ByVal value As Int64)
                If _Qty <> value Then
                    _Qty = value
                End If
            End Set
            Get
                Return _Qty
            End Get
        End Property
        Public Property RfqNo() As String
            Set(ByVal value As String)
                If _RfqNo <> value Then
                    _RfqNo = value
                End If
            End Set
            Get
                Return _RfqNo
            End Get
        End Property
        Public Property SerialNo() As String
            Set(ByVal value As String)
                If _SerialNo <> value Then
                    _SerialNo = value
                End If
            End Set
            Get
                Return _SerialNo
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
        Public Property ShipTo() As String
            Set(ByVal value As String)
                If _ShipTo <> value Then
                    _ShipTo = value
                End If
            End Set
            Get
                Return _ShipTo
            End Get
        End Property
        Public Property Status() As String
            Set(ByVal value As String)
                If _Status <> value Then
                    _Status = value
                End If
            End Set
            Get
                Return _Status
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

        Public Property ConsignmentDate() As DateTime
            Set(ByVal value As DateTime)
                If _ConsignmentDate <> value Then
                    _ConsignmentDate = value
                End If
            End Set
            Get
                Return _ConsignmentDate
            End Get
        End Property
        Public Property DateDeliveredToMro() As DateTime
            Set(ByVal value As DateTime)
                If _DateDeliveredToMro <> value Then
                    _DateDeliveredToMro = value
                End If
            End Set
            Get
                Return _DateDeliveredToMro
            End Get
        End Property
        Public Property DateDeliveredToMtoRep() As DateTime
            Set(ByVal value As DateTime)
                If _DateDeliveredToMtoRep <> value Then
                    _DateDeliveredToMtoRep = value
                End If
            End Set
            Get
                Return _DateDeliveredToMtoRep
            End Get
        End Property
        Public Property DateReceivedFromMto() As DateTime
            Set(ByVal value As DateTime)
                If _DateReceivedFromMto <> value Then
                    _DateReceivedFromMto = value
                End If
            End Set
            Get
                Return _DateReceivedFromMto
            End Get
        End Property
        Public Property DateReceivedFromMtoRep() As DateTime
            Set(ByVal value As DateTime)
                If _DateReceivedFromMtoRep <> value Then
                    _DateReceivedFromMtoRep = value
                End If
            End Set
            Get
                Return _DateReceivedFromMtoRep
            End Get
        End Property
        Public Property Driveric1() As String
            Set(ByVal value As String)
                If _Driveric1 <> value Then
                    _Driveric1 = value
                End If
            End Set
            Get
                Return _Driveric1
            End Get
        End Property
        Public Property Driveric2() As String
            Set(ByVal value As String)
                If _Driveric2 <> value Then
                    _Driveric2 = value
                End If
            End Set
            Get
                Return _Driveric2
            End Get
        End Property
        Public Property Driveric3() As String
            Set(ByVal value As String)
                If _Driveric3 <> value Then
                    _Driveric3 = value
                End If
            End Set
            Get
                Return _Driveric3
            End Get
        End Property
        Public Property DriverName1() As String
            Set(ByVal value As String)
                If _DriverName1 <> value Then
                    _DriverName1 = value
                End If
            End Set
            Get
                Return _DriverName1
            End Get
        End Property
        Public Property DriverName2() As String
            Set(ByVal value As String)
                If _DriverName2 <> value Then
                    _DriverName2 = value
                End If
            End Set
            Get
                Return _DriverName2
            End Get
        End Property
        Public Property DriverName3() As String
            Set(ByVal value As String)
                If _DriverName3 <> value Then
                    _DriverName3 = value
                End If
            End Set
            Get
                Return _DriverName3
            End Get
        End Property
        Public Property QuotationRefNo() As String
            Set(ByVal value As String)
                If _QuotationRefNo <> value Then
                    _QuotationRefNo = value
                End If
            End Set
            Get
                Return _QuotationRefNo
            End Get
        End Property
        Public Property TearDownInspectionDate() As DateTime
            Set(ByVal value As DateTime)
                If _TearDownInspectionDate <> value Then
                    _TearDownInspectionDate = value
                End If
            End Set
            Get
                Return _TearDownInspectionDate
            End Get
        End Property


        Public Sub New(ByVal intId As String)
            MyBase.New(intId)
            _ChargeWeight = ""
            _CommodityDescription = ""
            _ConsignNoteRefNo = ""
            _DestName = ""
            _Eta = ConDateTime.MinDate
            _Etd = ConDateTime.MinDate
            _FlightOrVoyageNo = ""
            _GrossWeight = ""
            _HawbHblNo = ""
            _LocalMtoCode = ""
            _MawbOblNo = ""
            _Mro = ""
            _MtoNotificationDate = ConDateTime.MinDate
            _MtoRep = ""
            _OriginName = ""
            _PartNo = ""
            _PickupDate = ConDateTime.MinDate
            _PickupFrom = ""
            _PlaceOfDelivery = ""
            _PlaceOfDeliveryEta = ConDateTime.MinDate
            _Qty = 0
            _RfqNo = intId
            _SerialNo = ""
            _ShipDate = ConDateTime.MinDate
            _ShipTo = ""
            _Status = ""
            _UomCode = ""
            _CreateBy = ""
            _CreateBy = ConDateTime.MinDate

            _ConsignmentDate = ConDateTime.MinDate
            _DateDeliveredToMro = ConDateTime.MinDate
            _DateDeliveredToMtoRep = ConDateTime.MinDate
            _DateReceivedFromMto = ConDateTime.MinDate
            _DateReceivedFromMtoRep = ConDateTime.MinDate
            _Driveric1 = ""
            _Driveric2 = ""
            _Driveric3 = ""
            _DriverName1 = ""
            _DriverName2 = ""
            _DriverName3 = ""
            _QuotationRefNo = ""
            _TearDownInspectionDate = ConDateTime.MinDate
        End Sub
    End Class
#End Region
End Namespace

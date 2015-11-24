Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of DeliveryOrder Info "

    <Serializable()> _
    Public Class clsPropDeliveryOrder
        Inherits clsProp
        Private _DeliveryOrderNo As String = ""
        Private _JobNo As String = ""
        Private _AwbNo As String = ""
        Private _HAwbNo As String = ""
        Private _MAwbNo As String = ""
        Private _SMAwbNo As String = ""
        Private _ActualDeliveryDateTime As String = ""
        Private _AvailablePcs As String = ""
        Private _CaseMark1 As String = ""
        Private _CaseMark2 As String = ""
        Private _CaseMark3 As String = ""
        Private _CaseMark4 As String = ""
        Private _CaseMark5 As String = ""
        Private _ChargeWeight As String = ""
        Private _ConsigneeAddress1 As String = ""
        Private _ConsigneeAddress2 As String = ""
        Private _ConsigneeAddress3 As String = ""
        Private _ConsigneeAddress4 As String = ""
        Private _ConsigneeCode As String = ""
        Private _ConsigneeName As String = ""
        Private _DeliveryBy As String = ""
        Private _DeliveryDate As String = ""
        Private _DeliveryPcs As String = ""
        Private _DeliveryToAddress1 As String = ""
        Private _DeliveryToAddress2 As String = ""
        Private _DeliveryToAddress3 As String = ""
        Private _DeliveryToAddress4 As String = ""
        Private _DeliveryToCode As String = ""
        Private _DeliveryToName As String = ""
        Private _Description As String = ""
        Private _DivisionCode As String = ""
        Private _DocAttachFlag1 As String = ""
        Private _DocAttachFlag2 As String = ""
        Private _DocAttachFlag3 As String = ""
        Private _DocAttachFlag4 As String = ""
        Private _DocAttachFlag5 As String = ""
        Private _DocAttachFlag6 As String = ""
        Private _FlightDate As String = ""
        Private _FlightNo As String = ""
        Private _OriginalPcs As String = ""
        Private _OriginCode As String = ""
        Private _PreparedBy As String = ""
        Private _Remark As String = ""
        Private _Remark1 As String = ""
        Private _Remark2 As String = ""
        Private _Remark3 As String = ""
        Private _Remark4 As String = ""
        Private _Remark5 As String = ""
        Private _SignBy As String = ""
        Private _SignDateTime As String = ""
        Private _SignId As String = ""
        Private _SiteCode As String = ""
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
        Private _Weight As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _StatusCode As String = ""
        Private _TrxNo As String = ""
        Private _BlNo As String = ""
        Private _DeliveryInstructionNo As String = ""
        Private _BlTrxNo As String = ""
        Private _CollectDateTime As String = ""
        Private _CollectFromAddress1 As String = ""
        Private _CollectFromAddress2 As String = ""
        Private _CollectFromAddress3 As String = ""
        Private _CollectFromAddress4 As String = ""
        Private _CollectFromCode As String = ""
        Private _CollectFromName As String = ""
        Private _CommodityCode As String = ""
        Private _CommodityDescription As String = ""
        Private _DeliveryTerm As String = ""
        Private _DeliveryInstruction1 As String = ""
        Private _DeliveryInstruction2 As String = ""
        Private _DeliveryInstruction3 As String = ""
        Private _DeliverToAddress1 As String = ""
        Private _DeliverToAddress2 As String = ""
        Private _DeliverToAddress3 As String = ""
        Private _DeliverToAddress4 As String = ""
        Private _DeliverToName As String = ""
        Private _Diesel As String = ""
        Private _Driver2Code As String = ""
        Private _Driver2ContactNo1 As String = ""
        Private _Driver2ContactNo2 As String = ""
        Private _Driver2Name As String = ""
        Private _DriverCode As String = ""
        Private _DriverContactNo1 As String = ""
        Private _DriverContactNo2 As String = ""
        Private _FeederVesselName As String = ""
        Private _FeederVoyage As String = ""
        Private _LetterOfCreditNo As String = ""
        Private _Mileage As String = ""
        Private _MeterReading As String = ""
        Private _ModuleCode As String = ""
        Private _NoOf20ftContainer As String = ""
        Private _NoOf40ftContainer As String = ""
        Private _NoOf45ftContainer As String = ""
        Private _TransportCompanyAddress1 As String = ""
        Private _TransportCompanyAddress2 As String = ""
        Private _TransportCompanyAddress3 As String = ""
        Private _TransportCompanyAddress4 As String = ""
        Private _TransportCompanyName As String = ""
        Private _TransportCompanyCode As String = ""
        Private _TotalGrossWeight As String = ""
        Private _TotalPcs As String = ""
        Private _TotalVolume As String = ""
        Private _Wages As String = ""
        Private _Wages2 As String = ""
        Private _EdiCount As String = ""
        Private _EmailCount As String = ""
        Private _ExportCount As String = ""
        Private _FaxCount As String = ""
        Private _PrintCount As String = ""

        ' 
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
        Public Property HAwbNo() As String
            Set(ByVal value As String)
                If _HAwbNo <> value Then
                    _HAwbNo = value
                End If
            End Set
            Get
                Return _HAwbNo
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
        Public Property ActualDeliveryDateTime() As String
            Set(ByVal value As String)
                If _ActualDeliveryDateTime <> value Then
                    _ActualDeliveryDateTime = value
                End If
            End Set
            Get
                Return _ActualDeliveryDateTime
            End Get
        End Property
        ' 
        Public Property AvailablePcs() As String
            Set(ByVal value As String)
                If _AvailablePcs <> value Then
                    _AvailablePcs = value
                End If
            End Set
            Get
                Return _AvailablePcs
            End Get
        End Property
        ' 
        Public Property CaseMark1() As String
            Set(ByVal value As String)
                If _CaseMark1 <> value Then
                    _CaseMark1 = value
                End If
            End Set
            Get
                Return _CaseMark1
            End Get
        End Property
        ' 
        Public Property CaseMark2() As String
            Set(ByVal value As String)
                If _CaseMark2 <> value Then
                    _CaseMark2 = value
                End If
            End Set
            Get
                Return _CaseMark2
            End Get
        End Property
        ' 
        Public Property CaseMark3() As String
            Set(ByVal value As String)
                If _CaseMark3 <> value Then
                    _CaseMark3 = value
                End If
            End Set
            Get
                Return _CaseMark3
            End Get
        End Property
        ' 
        Public Property CaseMark4() As String
            Set(ByVal value As String)
                If _CaseMark4 <> value Then
                    _CaseMark4 = value
                End If
            End Set
            Get
                Return _CaseMark4
            End Get
        End Property
        ' 
        Public Property CaseMark5() As String
            Set(ByVal value As String)
                If _CaseMark5 <> value Then
                    _CaseMark5 = value
                End If
            End Set
            Get
                Return _CaseMark5
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
        Public Property DeliveryBy() As String
            Set(ByVal value As String)
                If _DeliveryBy <> value Then
                    _DeliveryBy = value
                End If
            End Set
            Get
                Return _DeliveryBy
            End Get
        End Property
        ' 
        Public Property DeliveryDate() As String
            Set(ByVal value As String)
                If _DeliveryDate <> value Then
                    _DeliveryDate = value
                End If
            End Set
            Get
                Return _DeliveryDate
            End Get
        End Property
        ' 
        Public Property DeliveryPcs() As String
            Set(ByVal value As String)
                If _DeliveryPcs <> value Then
                    _DeliveryPcs = value
                End If
            End Set
            Get
                Return _DeliveryPcs
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property Description() As String
            Set(ByVal value As String)
                If _Description <> value Then
                    _Description = value
                End If
            End Set
            Get
                Return _Description
            End Get
        End Property

        ' 
        Public Property DocAttachFlag1() As String
            Set(ByVal value As String)
                If _DocAttachFlag1 <> value Then
                    _DocAttachFlag1 = value
                End If
            End Set
            Get
                Return _DocAttachFlag1
            End Get
        End Property
        ' 
        Public Property DocAttachFlag2() As String
            Set(ByVal value As String)
                If _DocAttachFlag2 <> value Then
                    _DocAttachFlag2 = value
                End If
            End Set
            Get
                Return _DocAttachFlag2
            End Get
        End Property
        ' 
        Public Property DocAttachFlag3() As String
            Set(ByVal value As String)
                If _DocAttachFlag3 <> value Then
                    _DocAttachFlag3 = value
                End If
            End Set
            Get
                Return _DocAttachFlag3
            End Get
        End Property
        ' 
        Public Property DocAttachFlag4() As String
            Set(ByVal value As String)
                If _DocAttachFlag4 <> value Then
                    _DocAttachFlag4 = value
                End If
            End Set
            Get
                Return _DocAttachFlag4
            End Get
        End Property
        ' 
        Public Property DocAttachFlag5() As String
            Set(ByVal value As String)
                If _DocAttachFlag5 <> value Then
                    _DocAttachFlag5 = value
                End If
            End Set
            Get
                Return _DocAttachFlag5
            End Get
        End Property
        ' 
        Public Property DocAttachFlag6() As String
            Set(ByVal value As String)
                If _DocAttachFlag6 <> value Then
                    _DocAttachFlag6 = value
                End If
            End Set
            Get
                Return _DocAttachFlag6
            End Get
        End Property
        ' 
        Public Property FlightDate() As String
            Set(ByVal value As String)
                If _FlightDate <> value Then
                    _FlightDate = value
                End If
            End Set
            Get
                Return _FlightDate
            End Get
        End Property
        ' 
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
        ' 
        Public Property OriginalPcs() As String
            Set(ByVal value As String)
                If _OriginalPcs <> value Then
                    _OriginalPcs = value
                End If
            End Set
            Get
                Return _OriginalPcs
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
        Public Property PreparedBy() As String
            Set(ByVal value As String)
                If _PreparedBy <> value Then
                    _PreparedBy = value
                End If
            End Set
            Get
                Return _PreparedBy
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
        Public Property Weight() As String
            Set(ByVal value As String)
                If _Weight <> value Then
                    _Weight = value
                End If
            End Set
            Get
                Return _Weight
            End Get
        End Property

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
        ' 
        Public Property DeliveryInstructionNo() As String
            Set(ByVal value As String)
                If _DeliveryInstructionNo <> value Then
                    _DeliveryInstructionNo = value
                End If
            End Set
            Get
                Return _DeliveryInstructionNo
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
        Public Property BlTrxNo() As String
            Set(ByVal value As String)
                If _BlTrxNo <> value Then
                    _BlTrxNo = value
                End If
            End Set
            Get
                Return _BlTrxNo
            End Get
        End Property
        ' 
        Public Property CollectDateTime() As String
            Set(ByVal value As String)
                If _CollectDateTime <> value Then
                    _CollectDateTime = value
                End If
            End Set
            Get
                Return _CollectDateTime
            End Get
        End Property
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property Diesel() As String
            Set(ByVal value As String)
                If _Diesel <> value Then
                    _Diesel = value
                End If
            End Set
            Get
                Return _Diesel
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        Public Property Mileage() As String
            Set(ByVal value As String)
                If _Mileage <> value Then
                    _Mileage = value
                End If
            End Set
            Get
                Return _Mileage
            End Get
        End Property
        ' 
        Public Property MeterReading() As String
            Set(ByVal value As String)
                If _MeterReading <> value Then
                    _MeterReading = value
                End If
            End Set
            Get
                Return _MeterReading
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
        Public Property Remark1() As String
            Set(ByVal value As String)
                If _Remark1 <> value Then
                    _Remark1 = value
                End If
            End Set
            Get
                Return _Remark1
            End Get
        End Property
        ' 
        Public Property Remark2() As String
            Set(ByVal value As String)
                If _Remark2 <> value Then
                    _Remark2 = value
                End If
            End Set
            Get
                Return _Remark2
            End Get
        End Property
        ' 
        Public Property Remark3() As String
            Set(ByVal value As String)
                If _Remark3 <> value Then
                    _Remark3 = value
                End If
            End Set
            Get
                Return _Remark3
            End Get
        End Property
        ' 
        Public Property Remark4() As String
            Set(ByVal value As String)
                If _Remark4 <> value Then
                    _Remark4 = value
                End If
            End Set
            Get
                Return _Remark4
            End Get
        End Property
        ' 
        Public Property Remark5() As String
            Set(ByVal value As String)
                If _Remark5 <> value Then
                    _Remark5 = value
                End If
            End Set
            Get
                Return _Remark5
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
        Public Property SignDateTime() As String
            Set(ByVal value As String)
                If _SignDateTime <> value Then
                    _SignDateTime = value
                End If
            End Set
            Get
                Return _SignDateTime
            End Get
        End Property
        ' 
        Public Property SignId() As String
            Set(ByVal value As String)
                If _SignId <> value Then
                    _SignId = value
                End If
            End Set
            Get
                Return _SignId
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property TotalGrossWeight() As String
            Set(ByVal value As String)
                If _TotalGrossWeight <> value Then
                    _TotalGrossWeight = value
                End If
            End Set
            Get
                Return _TotalGrossWeight
            End Get
        End Property
        ' 
        Public Property TotalPcs() As String
            Set(ByVal value As String)
                If _TotalPcs <> value Then
                    _TotalPcs = value
                End If
            End Set
            Get
                Return _TotalPcs
            End Get
        End Property
        ' 
        Public Property TotalVolume() As String
            Set(ByVal value As String)
                If _TotalVolume <> value Then
                    _TotalVolume = value
                End If
            End Set
            Get
                Return _TotalVolume
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
        ' 
        Public Property Wages() As String
            Set(ByVal value As String)
                If _Wages <> value Then
                    _Wages = value
                End If
            End Set
            Get
                Return _Wages
            End Get
        End Property
        ' 
        Public Property Wages2() As String
            Set(ByVal value As String)
                If _Wages2 <> value Then
                    _Wages2 = value
                End If
            End Set
            Get
                Return _Wages2
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
        Public Property CreateDatetime() As String
            Set(ByVal value As String)
                If _CreateDatetime <> value Then
                    _CreateDatetime = value
                End If
            End Set
            Get
                Return _CreateDatetime
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

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _DeliveryOrderNo = ""
            _JobNo = ""
            _AwbNo = ""
            _HAwbNo = ""
            _MAwbNo = ""
            _SMAwbNo = ""
            _ActualDeliveryDateTime = ""
            _AvailablePcs = ""
            _CaseMark1 = ""
            _CaseMark2 = ""
            _CaseMark3 = ""
            _CaseMark4 = ""
            _CaseMark5 = ""
            _ChargeWeight = ""
            _ConsigneeAddress1 = ""
            _ConsigneeAddress2 = ""
            _ConsigneeAddress3 = ""
            _ConsigneeAddress4 = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _DeliveryBy = ""
            _DeliveryDate = ""
            _DeliveryPcs = ""
            _DeliveryToAddress1 = ""
            _DeliveryToAddress2 = ""
            _DeliveryToAddress3 = ""
            _DeliveryToAddress4 = ""
            _DeliveryToCode = ""
            _DeliveryToName = ""
            _Description = ""
            _DivisionCode = ""
            _DocAttachFlag1 = ""
            _DocAttachFlag2 = ""
            _DocAttachFlag3 = ""
            _DocAttachFlag4 = ""
            _DocAttachFlag5 = ""
            _DocAttachFlag6 = ""
            _FlightDate = ""
            _FlightNo = ""
            _OriginalPcs = ""
            _OriginCode = ""
            _PreparedBy = ""
            _Remark = ""
            _Remark1 = ""
            _Remark2 = ""
            _Remark3 = ""
            _Remark4 = ""
            _Remark5 = ""
            _SignBy = ""
            _SignDateTime = ""
            _SignId = ""
            _SiteCode = ""
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
            _Weight = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _StatusCode = ""
            'sido1
            _TrxNo = ""
            _BlNo = ""
            _DeliveryInstructionNo = ""
            _DeliveryOrderNo = ""
            _JobNo = ""
            _BlTrxNo = ""
            _CollectDateTime = ""
            _CollectFromAddress1 = ""
            _CollectFromAddress2 = ""
            _CollectFromAddress3 = ""
            _CollectFromAddress4 = ""
            _CollectFromCode = ""
            _CollectFromName = ""
            _CommodityCode = ""
            _CommodityDescription = ""
            _DeliveryTerm = ""
            _DeliveryInstruction1 = ""
            _DeliveryInstruction2 = ""
            _DeliveryInstruction3 = ""
            _DeliverToAddress1 = ""
            _DeliverToAddress2 = ""
            _DeliverToAddress3 = ""
            _DeliverToAddress4 = ""
            _DeliveryToCode = ""
            _DeliverToName = ""
            _Diesel = ""
            _DivisionCode = ""
            _Driver2Code = ""
            _Driver2ContactNo1 = ""
            _Driver2ContactNo2 = ""
            _Driver2Name = ""
            _DriverCode = ""
            _DriverContactNo1 = ""
            _DriverContactNo2 = ""
            _FeederVesselName = ""
            _FeederVoyage = ""
            _LetterOfCreditNo = ""
            _Mileage = ""
            _MeterReading = ""
            _ModuleCode = ""
            _NoOf20ftContainer = ""
            _NoOf40ftContainer = ""
            _NoOf45ftContainer = ""
            _Remark1 = ""
            _Remark2 = ""
            _Remark3 = ""
            _Remark4 = ""
            _Remark5 = ""
            _SignBy = ""
            _SignDateTime = ""
            _SignId = ""
            _SiteCode = ""
            _TransportCompanyAddress1 = ""
            _TransportCompanyAddress2 = ""
            _TransportCompanyAddress3 = ""
            _TransportCompanyAddress4 = ""
            _TransportCompanyName = ""
            _TransportCompanyCode = ""
            _TotalGrossWeight = ""
            _TotalPcs = ""
            _TotalVolume = ""
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
            _VehicleNo = ""
            _Wages = ""
            _Wages2 = ""
            _EdiCount = ""
            _EmailCount = ""
            _ExportCount = ""
            _FaxCount = ""
            _PrintCount = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateDateTime = ""
            _UpdateBy = ""
            _StatusCode = ""
        End Sub

    End Class

#End Region
End Namespace
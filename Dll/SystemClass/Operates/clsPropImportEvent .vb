Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of ImportEvent Info "

    <Serializable()> _
    Public Class clsPropImportEvent
        Inherits clsProp
        Private _TrxNo As Int64
        Private _ContainerNo As String = ""
        Private _EventCode As String = ""
        Private _EventPortCode As String = ""
        Private _EventDate As DateTime
        Private _EquipmentType As String = ""
        Private _JobNo As String = ""
        Private _RITrxNo As Integer
        Private _ROLineItemNo As Integer
        Private _SOTrxNo As Integer
        Private _SOLineItemNo As Integer
        Private _VesselName As String = ""
        Private _VoyageNo As String = ""
        Private _ShipperCode As String = ""
        Private _ShipperName As String = ""
        Private _ConsigneeCode As String = ""
        Private _ConsigneeName As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _PortOfDischargeCode As String = ""
        Private _DepotCode As String = ""
        Private _TruckerName As String = ""
        Private _VehicleNo As String = ""
        Private _SealNo As String = ""
        Private _DGFlag As String = ""
        Private _DriverPassNo As String = ""
        Private _SurveyRemarks As String = ""
        Private _ActualDetentionCharge As Decimal
        Private _ComputedDetentionCharge As Decimal
        Private _State As String = ""
        Private _Remarks As String = ""
        Private _SiteCode As String = ""
        ' 
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
        Public Property EventCode() As String
            Set(ByVal value As String)
                If _EventCode <> value Then
                    _EventCode = value
                End If
            End Set
            Get
                Return _EventCode
            End Get
        End Property
        ' 
        Public Property EventPortCode() As String
            Set(ByVal value As String)
                If _EventPortCode <> value Then
                    _EventPortCode = value
                End If
            End Set
            Get
                Return _EventPortCode
            End Get
        End Property
        ' 
        Public Property EventDate() As DateTime
            Set(ByVal value As DateTime)
                If _EventDate <> value Then
                    _EventDate = value
                End If
            End Set
            Get
                Return _EventDate
            End Get
        End Property
        ' 
        Public Property EquipmentType() As String
            Set(ByVal value As String)
                If _EquipmentType <> value Then
                    _EquipmentType = value
                End If
            End Set
            Get
                Return _EquipmentType
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
        Public Property RITrxNo() As Integer
            Set(ByVal value As Integer)
                If _RITrxNo <> value Then
                    _RITrxNo = value
                End If
            End Set
            Get
                Return _RITrxNo
            End Get
        End Property
        ' 
        Public Property ROLineItemNo() As Integer
            Set(ByVal value As Integer)
                If _ROLineItemNo <> value Then
                    _ROLineItemNo = value
                End If
            End Set
            Get
                Return _ROLineItemNo
            End Get
        End Property
        ' 
        Public Property SOTrxNo() As Integer
            Set(ByVal value As Integer)
                If _SOTrxNo <> value Then
                    _SOTrxNo = value
                End If
            End Set
            Get
                Return _SOTrxNo
            End Get
        End Property
        ' 
        Public Property SOLineItemNo() As Integer
            Set(ByVal value As Integer)
                If _SOLineItemNo <> value Then
                    _SOLineItemNo = value
                End If
            End Set
            Get
                Return _SOLineItemNo
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
        ' 
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
        Public Property SealNo() As String
            Set(ByVal value As String)
                If _SealNo <> value Then
                    _SealNo = value
                End If
            End Set
            Get
                Return _SealNo
            End Get
        End Property
        ' 
        Public Property DGFlag() As String
            Set(ByVal value As String)
                If _DGFlag <> value Then
                    _DGFlag = value
                End If
            End Set
            Get
                Return _DGFlag
            End Get
        End Property
        ' 
        Public Property DriverPassNo() As String
            Set(ByVal value As String)
                If _DriverPassNo <> value Then
                    _DriverPassNo = value
                End If
            End Set
            Get
                Return _DriverPassNo
            End Get
        End Property
        ' 
        Public Property SurveyRemarks() As String
            Set(ByVal value As String)
                If _SurveyRemarks <> value Then
                    _SurveyRemarks = value
                End If
            End Set
            Get
                Return _SurveyRemarks
            End Get
        End Property
        ' 
        Public Property ActualDetentionCharge() As Decimal
            Set(ByVal value As Decimal)
                If _ActualDetentionCharge <> value Then
                    _ActualDetentionCharge = value
                End If
            End Set
            Get
                Return _ActualDetentionCharge
            End Get
        End Property
        ' 
        Public Property ComputedDetentionCharge() As Decimal
            Set(ByVal value As Decimal)
                If _ComputedDetentionCharge <> value Then
                    _ComputedDetentionCharge = value
                End If
            End Set
            Get
                Return _ComputedDetentionCharge
            End Get
        End Property
        ' 
        Public Property State() As String
            Set(ByVal value As String)
                If _State <> value Then
                    _State = value
                End If
            End Set
            Get
                Return _State
            End Get
        End Property
        ' 
        Public Property Remarks() As String
            Set(ByVal value As String)
                If _Remarks <> value Then
                    _Remarks = value
                End If
            End Set
            Get
                Return _Remarks
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

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _ContainerNo = ""
            _EventCode = ""
            _EventPortCode = ""
            _EventDate = ConDateTime.MinDate
            _EquipmentType = ""
            _JobNo = ""
            _RITrxNo = 0
            _ROLineItemNo = 0
            _SOTrxNo = 0
            _SOLineItemNo = 0
            _VesselName = ""
            _VoyageNo = ""
            _ShipperCode = ""
            _ShipperName = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _PortOfLoadingCode = ""
            _PortOfDischargeCode = ""
            _DepotCode = ""
            _TruckerName = ""
            _VehicleNo = ""
            _SealNo = ""
            _DGFlag = ""
            _DriverPassNo = ""
            _SurveyRemarks = ""
            _ActualDetentionCharge = 0
            _ComputedDetentionCharge = 0
            _State = ""
            _Remarks = ""
            _SiteCode = ""

        End Sub
    End Class



#End Region
End Namespace
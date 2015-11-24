Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of RI Info "

    <Serializable()> _
    Public Class clsPropSO
        Inherits clsProp
        Private _TrxNo As Int64
        Private _StoringOrderNo As String = ""
        Private _OrganisationCode As String = ""
        Private _JobNo As String = ""
        Private _VesselName As String = ""
        Private _VoyageNo As String = ""
        Private _EtaDate As DateTime
        Private _ReturnType As String = ""
        Private _ReturnOriginCode As String = ""
        Private _ConsigneeCode As String = ""
        Private _ConsigneeName As String = ""
        Private _ConsigneeAddress1 As String = ""
        Private _ConsigneeAddress2 As String = ""
        Private _ConsigneeAddress3 As String = ""
        Private _ConsigneeAddress4 As String = ""
        Private _ConsigneeContactPerson As String = ""
        Private _ConsigneeContactNo As String = ""
        Private _DepotCode As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _DetentionCode As String = ""
        Private _DetentionStartDate As DateTime
        Private _DetentionFreeDay As Integer
        Private _DemurrageStartDate As DateTime
        Private _DemurrageFreeDay As Integer
        Private _InstructionToDepot As String = ""
        Private _TruckerCode As String = ""
        Private _TruckerName As String = ""
        Private _CompleteDate As DateTime
        Private _TruckerRefNo As String = ""
        Private _DemurrageCode As String = ""
        Private _SiteCode As String = ""
        Private _UserNo As String = ""
        Private _RefNo As String = ""
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
        ' 
        Public Property StoringOrderNo() As String
            Set(ByVal value As String)
                If _StoringOrderNo <> value Then
                    _StoringOrderNo = value
                End If
            End Set
            Get
                Return _StoringOrderNo
            End Get
        End Property
        ' 
        Public Property OrganisationCode() As String
            Set(ByVal value As String)
                If _OrganisationCode <> value Then
                    _OrganisationCode = value
                End If
            End Set
            Get
                Return _OrganisationCode
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
        ' 
        Public Property ReturnType() As String
            Set(ByVal value As String)
                If _ReturnType <> value Then
                    _ReturnType = value
                End If
            End Set
            Get
                Return _ReturnType
            End Get
        End Property
        ' 
        Public Property ReturnOriginCode() As String
            Set(ByVal value As String)
                If _ReturnOriginCode <> value Then
                    _ReturnOriginCode = value
                End If
            End Set
            Get
                Return _ReturnOriginCode
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
        Public Property ConsigneeContactPerson() As String
            Set(ByVal value As String)
                If _ConsigneeContactPerson <> value Then
                    _ConsigneeContactPerson = value
                End If
            End Set
            Get
                Return _ConsigneeContactPerson
            End Get
        End Property
        ' 
        Public Property ConsigneeContactNo() As String
            Set(ByVal value As String)
                If _ConsigneeContactNo <> value Then
                    _ConsigneeContactNo = value
                End If
            End Set
            Get
                Return _ConsigneeContactNo
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
        Public Property DetentionCode() As String
            Set(ByVal value As String)
                If _DetentionCode <> value Then
                    _DetentionCode = value
                End If
            End Set
            Get
                Return _DetentionCode
            End Get
        End Property
        ' 
        Public Property DetentionStartDate() As DateTime
            Set(ByVal value As DateTime)
                If _DetentionStartDate <> value Then
                    _DetentionStartDate = value
                End If
            End Set
            Get
                Return _DetentionStartDate
            End Get
        End Property
        ' 
        Public Property DetentionFreeDay() As Integer
            Set(ByVal value As Integer)
                If _DetentionFreeDay <> value Then
                    _DetentionFreeDay = value
                End If
            End Set
            Get
                Return _DetentionFreeDay
            End Get
        End Property
        ' 
        Public Property DemurrageStartDate() As DateTime
            Set(ByVal value As DateTime)
                If _DemurrageStartDate <> value Then
                    _DemurrageStartDate = value
                End If
            End Set
            Get
                Return _DemurrageStartDate
            End Get
        End Property
        ' 
        Public Property DemurrageFreeDay() As Integer
            Set(ByVal value As Integer)
                If _DemurrageFreeDay <> value Then
                    _DemurrageFreeDay = value
                End If
            End Set
            Get
                Return _DemurrageFreeDay
            End Get
        End Property
        ' 
        Public Property InstructionToDepot() As String
            Set(ByVal value As String)
                If _InstructionToDepot <> value Then
                    _InstructionToDepot = value
                End If
            End Set
            Get
                Return _InstructionToDepot
            End Get
        End Property
        ' 
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
        Public Property CompleteDate() As DateTime
            Set(ByVal value As DateTime)
                If _CompleteDate <> value Then
                    _CompleteDate = value
                End If
            End Set
            Get
                Return _CompleteDate
            End Get
        End Property
        ' 
        Public Property TruckerRefNo() As String
            Set(ByVal value As String)
                If _TruckerRefNo <> value Then
                    _TruckerRefNo = value
                End If
            End Set
            Get
                Return _TruckerRefNo
            End Get
        End Property
        Public Property DemurrageCode() As String
            Set(ByVal value As String)
                If _DemurrageCode <> value Then
                    _DemurrageCode = value
                End If
            End Set
            Get
                Return _DemurrageCode
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

        Public Property UserNo() As String
            Set(ByVal value As String)
                If _UserNo <> value Then
                    _UserNo = value
                End If
            End Set
            Get
                Return _UserNo
            End Get
        End Property
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

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _StoringOrderNo = ""
            _OrganisationCode = ""
            _JobNo = ""
            _VesselName = ""
            _VoyageNo = ""
            _EtaDate = ConDateTime.MinDate
            _ReturnType = ""
            _ReturnOriginCode = ""
            _ConsigneeCode = ""
            _ConsigneeName = ""
            _ConsigneeAddress1 = ""
            _ConsigneeAddress2 = ""
            _ConsigneeAddress3 = ""
            _ConsigneeAddress4 = ""
            _ConsigneeContactPerson = ""
            _ConsigneeContactNo = ""
            _DepotCode = ""
            _PortOfLoadingCode = ""
            _DetentionCode = ""
            _DetentionStartDate = ConDateTime.MinDate
            _DetentionFreeDay = -1
            _DemurrageStartDate = ConDateTime.MinDate
            _DemurrageFreeDay = -1
            _InstructionToDepot = ""
            _TruckerCode = ""
            _TruckerName = ""
            _CompleteDate = ConDateTime.MinDate
            _TruckerRefNo = ""
            _DemurrageCode = ""
            _SiteCode = ""
            _UserNo = ""
            _RefNo = ""
        End Sub
    End Class



#End Region
End Namespace
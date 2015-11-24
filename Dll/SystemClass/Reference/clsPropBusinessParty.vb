Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of BusinessParty Info "

    <Serializable()> _
    Public Class clsPropBusinessParty
        Inherits clsProp
        Private _TrxNo As Int64
        Private _BusinessPartyCode As String = ""
        Private _BusinessPartyName As String = ""
        Private _BusinessType As String = ""
        Private _CityCode As String = ""
        Private _CountryCode As String = ""
        Private _CurrCode As String = ""
        Private _CustomerCode As String = ""
        Private _DistrictCode As String = ""
        Private _DivisionCode As String = ""
        Private _SalesmanCode As String = ""
        Private _VendorCode As String = ""
        Private _AirAgentCode As String = ""
        Private _AnalysisCode1 As String = ""
        Private _AnalysisCode2 As String = ""
        Private _AnalysisCode3 As String = ""
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _Address3 As String = ""
        Private _Address4 As String = ""
        Private _AgentAccCode As String = ""
        Private _AgentCityName As String = ""
        Private _AgentIataCode As String = ""
        Private _AgentName As String = ""
        Private _AppointAgentCode As String = ""
        Private _BreakBulkFlag As String = ""
        Private _CompanyProfile As String = ""
        Private _ContactName1 As String = ""
        Private _ContactName2 As String = ""
        Private _ContactName3 As String = ""
        Private _CreditStatusCode As String = ""
        Private _CrNo As String = ""
        Private _DeliveryToAddress1 As String = ""
        Private _DeliveryToAddress2 As String = ""
        Private _DeliveryToAddress3 As String = ""
        Private _DeliveryToAddress4 As String = ""
        Private _DeliveryToName As String = ""
        Private _Email As String = ""
        Private _Email1 As String = ""
        Private _Email2 As String = ""
        Private _Email3 As String = ""
        Private _Fax As String = ""
        Private _Fax1 As String = ""
        Private _Fax2 As String = ""
        Private _Fax3 As String = ""
        Private _FwbAccCode As String = ""
        Private _FwbAddress As String = ""
        Private _FwbName As String = ""
        Private _FwbPlace As String = ""
        Private _FwbState As String = ""
        Private _Handphone1 As String = ""
        Private _Handphone2 As String = ""
        Private _Handphone3 As String = ""
        Private _JtcAccCode As String = ""
        Private _LocalName As String = ""
        Private _Pager1 As String = ""
        Private _Pager2 As String = ""
        Private _Pager3 As String = ""
        Private _PartyShortCode As String = ""
        Private _PartyType As String = ""
        Private _PayType As String = ""
        Private _PostalCode As String = ""
        Private _PsaAccCode As String = ""
        Private _Remark As String = ""
        Private _SatLunchFromTime As DateTime
        Private _SatLunchToTime As DateTime
        Private _SatWorkFromTime As DateTime
        Private _SatWorkToTime As DateTime
        Private _SiteCode As String = ""
        Private _SpecialInstruction As String = ""
        Private _SunLunchFromTime As DateTime
        Private _SunLunchToTime As DateTime
        Private _SunWorkFromTime As DateTime
        Private _SunWorkToTime As DateTime
        Private _Telephone As String = ""
        Private _Telephone1 As String = ""
        Private _Telephone2 As String = ""
        Private _Telephone3 As String = ""
        Private _Telex As String = ""
        Private _TermCode As String = ""
        Private _Title1 As String = ""
        Private _Title2 As String = ""
        Private _Title3 As String = ""
        Private _WebSite As String = ""
        Private _WeekLunchFromTime As DateTime
        Private _WeekLunchToTime As DateTime
        Private _WeekWorkFromTime As DateTime
        Private _WeekWorkToTime As DateTime
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _StatusCode As String = ""
        Private _Password As String = ""
        Private _AttachmentFlag As String = ""
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

        Public Property BusinessPartyCode() As String
            Set(ByVal value As String)
                If _BusinessPartyCode <> value Then
                    _BusinessPartyCode = value
                End If
            End Set
            Get
                Return _BusinessPartyCode
            End Get
        End Property
        ' 
        Public Property BusinessPartyName() As String
            Set(ByVal value As String)
                If _BusinessPartyName <> value Then
                    _BusinessPartyName = value
                End If
            End Set
            Get
                Return _BusinessPartyName
            End Get
        End Property
        ' 
        Public Property BusinessType() As String
            Set(ByVal value As String)
                If _BusinessType <> value Then
                    _BusinessType = value
                End If
            End Set
            Get
                Return _BusinessType
            End Get
        End Property
        ' 
        Public Property CityCode() As String
            Set(ByVal value As String)
                If _CityCode <> value Then
                    _CityCode = value
                End If
            End Set
            Get
                Return _CityCode
            End Get
        End Property
        ' 
        Public Property CountryCode() As String
            Set(ByVal value As String)
                If _CountryCode <> value Then
                    _CountryCode = value
                End If
            End Set
            Get
                Return _CountryCode
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
        Public Property VendorCode() As String
            Set(ByVal value As String)
                If _VendorCode <> value Then
                    _VendorCode = value
                End If
            End Set
            Get
                Return _VendorCode
            End Get
        End Property
        ' 
        Public Property AirAgentCode() As String
            Set(ByVal value As String)
                If _AirAgentCode <> value Then
                    _AirAgentCode = value
                End If
            End Set
            Get
                Return _AirAgentCode
            End Get
        End Property
        ' 
        Public Property AnalysisCode1() As String
            Set(ByVal value As String)
                If _AnalysisCode1 <> value Then
                    _AnalysisCode1 = value
                End If
            End Set
            Get
                Return _AnalysisCode1
            End Get
        End Property
        ' 
        Public Property AnalysisCode2() As String
            Set(ByVal value As String)
                If _AnalysisCode2 <> value Then
                    _AnalysisCode2 = value
                End If
            End Set
            Get
                Return _AnalysisCode2
            End Get
        End Property
        ' 
        Public Property AnalysisCode3() As String
            Set(ByVal value As String)
                If _AnalysisCode3 <> value Then
                    _AnalysisCode3 = value
                End If
            End Set
            Get
                Return _AnalysisCode3
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
        Public Property AgentCityName() As String
            Set(ByVal value As String)
                If _AgentCityName <> value Then
                    _AgentCityName = value
                End If
            End Set
            Get
                Return _AgentCityName
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
        Public Property AgentName() As String
            Set(ByVal value As String)
                If _AgentName <> value Then
                    _AgentName = value
                End If
            End Set
            Get
                Return _AgentName
            End Get
        End Property
        ' 
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
        ' 
        Public Property BreakBulkFlag() As String
            Set(ByVal value As String)
                If _BreakBulkFlag <> value Then
                    _BreakBulkFlag = value
                End If
            End Set
            Get
                Return _BreakBulkFlag
            End Get
        End Property
        ' 
        Public Property CompanyProfile() As String
            Set(ByVal value As String)
                If _CompanyProfile <> value Then
                    _CompanyProfile = value
                End If
            End Set
            Get
                Return _CompanyProfile
            End Get
        End Property
        ' 
        Public Property ContactName1() As String
            Set(ByVal value As String)
                If _ContactName1 <> value Then
                    _ContactName1 = value
                End If
            End Set
            Get
                Return _ContactName1
            End Get
        End Property
        ' 
        Public Property ContactName2() As String
            Set(ByVal value As String)
                If _ContactName2 <> value Then
                    _ContactName2 = value
                End If
            End Set
            Get
                Return _ContactName2
            End Get
        End Property
        ' 
        Public Property ContactName3() As String
            Set(ByVal value As String)
                If _ContactName3 <> value Then
                    _ContactName3 = value
                End If
            End Set
            Get
                Return _ContactName3
            End Get
        End Property
        ' 
        Public Property CreditStatusCode() As String
            Set(ByVal value As String)
                If _CreditStatusCode <> value Then
                    _CreditStatusCode = value
                End If
            End Set
            Get
                Return _CreditStatusCode
            End Get
        End Property
        ' 
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
        Public Property Email() As String
            Set(ByVal value As String)
                If _Email <> value Then
                    _Email = value
                End If
            End Set
            Get
                Return _Email
            End Get
        End Property
        ' 
        Public Property Email1() As String
            Set(ByVal value As String)
                If _Email1 <> value Then
                    _Email1 = value
                End If
            End Set
            Get
                Return _Email1
            End Get
        End Property
        ' 
        Public Property Email2() As String
            Set(ByVal value As String)
                If _Email2 <> value Then
                    _Email2 = value
                End If
            End Set
            Get
                Return _Email2
            End Get
        End Property
        ' 
        Public Property Email3() As String
            Set(ByVal value As String)
                If _Email3 <> value Then
                    _Email3 = value
                End If
            End Set
            Get
                Return _Email3
            End Get
        End Property
        ' 
        Public Property Fax() As String
            Set(ByVal value As String)
                If _Fax <> value Then
                    _Fax = value
                End If
            End Set
            Get
                Return _Fax
            End Get
        End Property
        ' 
        Public Property Fax1() As String
            Set(ByVal value As String)
                If _Fax1 <> value Then
                    _Fax1 = value
                End If
            End Set
            Get
                Return _Fax1
            End Get
        End Property
        ' 
        Public Property Fax2() As String
            Set(ByVal value As String)
                If _Fax2 <> value Then
                    _Fax2 = value
                End If
            End Set
            Get
                Return _Fax2
            End Get
        End Property
        ' 
        Public Property Fax3() As String
            Set(ByVal value As String)
                If _Fax3 <> value Then
                    _Fax3 = value
                End If
            End Set
            Get
                Return _Fax3
            End Get
        End Property
        ' 
        Public Property FwbAccCode() As String
            Set(ByVal value As String)
                If _FwbAccCode <> value Then
                    _FwbAccCode = value
                End If
            End Set
            Get
                Return _FwbAccCode
            End Get
        End Property
        ' 
        Public Property FwbAddress() As String
            Set(ByVal value As String)
                If _FwbAddress <> value Then
                    _FwbAddress = value
                End If
            End Set
            Get
                Return _FwbAddress
            End Get
        End Property
        ' 
        Public Property FwbName() As String
            Set(ByVal value As String)
                If _FwbName <> value Then
                    _FwbName = value
                End If
            End Set
            Get
                Return _FwbName
            End Get
        End Property
        ' 
        Public Property FwbPlace() As String
            Set(ByVal value As String)
                If _FwbPlace <> value Then
                    _FwbPlace = value
                End If
            End Set
            Get
                Return _FwbPlace
            End Get
        End Property
        ' 
        Public Property FwbState() As String
            Set(ByVal value As String)
                If _FwbState <> value Then
                    _FwbState = value
                End If
            End Set
            Get
                Return _FwbState
            End Get
        End Property
        ' 
        Public Property Handphone1() As String
            Set(ByVal value As String)
                If _Handphone1 <> value Then
                    _Handphone1 = value
                End If
            End Set
            Get
                Return _Handphone1
            End Get
        End Property
        ' 
        Public Property Handphone2() As String
            Set(ByVal value As String)
                If _Handphone2 <> value Then
                    _Handphone2 = value
                End If
            End Set
            Get
                Return _Handphone2
            End Get
        End Property
        ' 
        Public Property Handphone3() As String
            Set(ByVal value As String)
                If _Handphone3 <> value Then
                    _Handphone3 = value
                End If
            End Set
            Get
                Return _Handphone3
            End Get
        End Property
        ' 
        Public Property JtcAccCode() As String
            Set(ByVal value As String)
                If _JtcAccCode <> value Then
                    _JtcAccCode = value
                End If
            End Set
            Get
                Return _JtcAccCode
            End Get
        End Property
        ' 
        Public Property LocalName() As String
            Set(ByVal value As String)
                If _LocalName <> value Then
                    _LocalName = value
                End If
            End Set
            Get
                Return _LocalName
            End Get
        End Property
        ' 
        Public Property Pager1() As String
            Set(ByVal value As String)
                If _Pager1 <> value Then
                    _Pager1 = value
                End If
            End Set
            Get
                Return _Pager1
            End Get
        End Property
        ' 
        Public Property Pager2() As String
            Set(ByVal value As String)
                If _Pager2 <> value Then
                    _Pager2 = value
                End If
            End Set
            Get
                Return _Pager2
            End Get
        End Property
        ' 
        Public Property Pager3() As String
            Set(ByVal value As String)
                If _Pager3 <> value Then
                    _Pager3 = value
                End If
            End Set
            Get
                Return _Pager3
            End Get
        End Property
        ' 
        Public Property PartyShortCode() As String
            Set(ByVal value As String)
                If _PartyShortCode <> value Then
                    _PartyShortCode = value
                End If
            End Set
            Get
                Return _PartyShortCode
            End Get
        End Property
        ' 
        Public Property PartyType() As String
            Set(ByVal value As String)
                If _PartyType <> value Then
                    _PartyType = value
                End If
            End Set
            Get
                Return _PartyType
            End Get
        End Property
        ' 
        Public Property PayType() As String
            Set(ByVal value As String)
                If _PayType <> value Then
                    _PayType = value
                End If
            End Set
            Get
                Return _PayType
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
        Public Property PsaAccCode() As String
            Set(ByVal value As String)
                If _PsaAccCode <> value Then
                    _PsaAccCode = value
                End If
            End Set
            Get
                Return _PsaAccCode
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
        Public Property SatLunchFromTime() As DateTime
            Set(ByVal value As DateTime)
                If _SatLunchFromTime <> value Then
                    _SatLunchFromTime = value
                End If
            End Set
            Get
                Return _SatLunchFromTime
            End Get
        End Property
        ' 
        Public Property SatLunchToTime() As DateTime
            Set(ByVal value As DateTime)
                If _SatLunchToTime <> value Then
                    _SatLunchToTime = value
                End If
            End Set
            Get
                Return _SatLunchToTime
            End Get
        End Property
        ' 
        Public Property SatWorkFromTime() As DateTime
            Set(ByVal value As DateTime)
                If _SatWorkFromTime <> value Then
                    _SatWorkFromTime = value
                End If
            End Set
            Get
                Return _SatWorkFromTime
            End Get
        End Property
        ' 
        Public Property SatWorkToTime() As DateTime
            Set(ByVal value As DateTime)
                If _SatWorkToTime <> value Then
                    _SatWorkToTime = value
                End If
            End Set
            Get
                Return _SatWorkToTime
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
        ' 
        Public Property SunLunchFromTime() As DateTime
            Set(ByVal value As DateTime)
                If _SunLunchFromTime <> value Then
                    _SunLunchFromTime = value
                End If
            End Set
            Get
                Return _SunLunchFromTime
            End Get
        End Property
        ' 
        Public Property SunLunchToTime() As DateTime
            Set(ByVal value As DateTime)
                If _SunLunchToTime <> value Then
                    _SunLunchToTime = value
                End If
            End Set
            Get
                Return _SunLunchToTime
            End Get
        End Property
        ' 
        Public Property SunWorkFromTime() As DateTime
            Set(ByVal value As DateTime)
                If _SunWorkFromTime <> value Then
                    _SunWorkFromTime = value
                End If
            End Set
            Get
                Return _SunWorkFromTime
            End Get
        End Property
        ' 
        Public Property SunWorkToTime() As DateTime
            Set(ByVal value As DateTime)
                If _SunWorkToTime <> value Then
                    _SunWorkToTime = value
                End If
            End Set
            Get
                Return _SunWorkToTime
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
        Public Property Telephone1() As String
            Set(ByVal value As String)
                If _Telephone1 <> value Then
                    _Telephone1 = value
                End If
            End Set
            Get
                Return _Telephone1
            End Get
        End Property
        ' 
        Public Property Telephone2() As String
            Set(ByVal value As String)
                If _Telephone2 <> value Then
                    _Telephone2 = value
                End If
            End Set
            Get
                Return _Telephone2
            End Get
        End Property
        ' 
        Public Property Telephone3() As String
            Set(ByVal value As String)
                If _Telephone3 <> value Then
                    _Telephone3 = value
                End If
            End Set
            Get
                Return _Telephone3
            End Get
        End Property
        ' 
        Public Property Telex() As String
            Set(ByVal value As String)
                If _Telex <> value Then
                    _Telex = value
                End If
            End Set
            Get
                Return _Telex
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
        Public Property Title1() As String
            Set(ByVal value As String)
                If _Title1 <> value Then
                    _Title1 = value
                End If
            End Set
            Get
                Return _Title1
            End Get
        End Property
        ' 
        Public Property Title2() As String
            Set(ByVal value As String)
                If _Title2 <> value Then
                    _Title2 = value
                End If
            End Set
            Get
                Return _Title2
            End Get
        End Property
        ' 
        Public Property Title3() As String
            Set(ByVal value As String)
                If _Title3 <> value Then
                    _Title3 = value
                End If
            End Set
            Get
                Return _Title3
            End Get
        End Property
        ' 
        Public Property WebSite() As String
            Set(ByVal value As String)
                If _WebSite <> value Then
                    _WebSite = value
                End If
            End Set
            Get
                Return _WebSite
            End Get
        End Property
        ' 
        Public Property WeekLunchFromTime() As DateTime
            Set(ByVal value As DateTime)
                If _WeekLunchFromTime <> value Then
                    _WeekLunchFromTime = value
                End If
            End Set
            Get
                Return _WeekLunchFromTime
            End Get
        End Property
        ' 
        Public Property WeekLunchToTime() As DateTime
            Set(ByVal value As DateTime)
                If _WeekLunchToTime <> value Then
                    _WeekLunchToTime = value
                End If
            End Set
            Get
                Return _WeekLunchToTime
            End Get
        End Property
        ' 
        Public Property WeekWorkFromTime() As DateTime
            Set(ByVal value As DateTime)
                If _WeekWorkFromTime <> value Then
                    _WeekWorkFromTime = value
                End If
            End Set
            Get
                Return _WeekWorkFromTime
            End Get
        End Property
        ' 
        Public Property WeekWorkToTime() As DateTime
            Set(ByVal value As DateTime)
                If _WeekWorkToTime <> value Then
                    _WeekWorkToTime = value
                End If
            End Set
            Get
                Return _WeekWorkToTime
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
        Public Property Password() As String
            Set(ByVal value As String)
                If _Password <> value Then
                    _Password = value
                End If
            End Set
            Get
                Return _Password
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

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _BusinessPartyCode = ""
            _BusinessPartyName = ""
            _BusinessType = ""
            _CityCode = ""
            _CountryCode = ""
            _CurrCode = ""
            _CustomerCode = ""
            _DistrictCode = ""
            _DivisionCode = ""
            _SalesmanCode = ""
            _VendorCode = ""
            _AirAgentCode = ""
            _AnalysisCode1 = ""
            _AnalysisCode2 = ""
            _AnalysisCode3 = ""
            _Address1 = ""
            _Address2 = ""
            _Address3 = ""
            _Address4 = ""
            _AgentAccCode = ""
            _AgentCityName = ""
            _AgentIataCode = ""
            _AgentName = ""
            _AppointAgentCode = ""
            _BreakBulkFlag = ""
            _CompanyProfile = ""
            _ContactName1 = ""
            _ContactName2 = ""
            _ContactName3 = ""
            _CreditStatusCode = ""
            _CrNo = ""
            _DeliveryToAddress1 = ""
            _DeliveryToAddress2 = ""
            _DeliveryToAddress3 = ""
            _DeliveryToAddress4 = ""
            _DeliveryToName = ""
            _Email = ""
            _Email1 = ""
            _Email2 = ""
            _Email3 = ""
            _Fax = ""
            _Fax1 = ""
            _Fax2 = ""
            _Fax3 = ""
            _FwbAccCode = ""
            _FwbAddress = ""
            _FwbName = ""
            _FwbPlace = ""
            _FwbState = ""
            _Handphone1 = ""
            _Handphone2 = ""
            _Handphone3 = ""
            _JtcAccCode = ""
            _LocalName = ""
            _Pager1 = ""
            _Pager2 = ""
            _Pager3 = ""
            _PartyShortCode = ""
            _PartyType = ""
            _PayType = ""
            _PostalCode = ""
            _PsaAccCode = ""
            _Remark = ""
            _SatLunchFromTime = ConDateTime.MinDate
            _SatLunchToTime = ConDateTime.MinDate
            _SatWorkFromTime = ConDateTime.MinDate
            _SatWorkToTime = ConDateTime.MinDate
            _SiteCode = ""
            _SpecialInstruction = ""
            _SunLunchFromTime = ConDateTime.MinDate
            _SunLunchToTime = ConDateTime.MinDate
            _SunWorkFromTime = ConDateTime.MinDate
            _SunWorkToTime = ConDateTime.MinDate
            _Telephone = ""
            _Telephone1 = ""
            _Telephone2 = ""
            _Telephone3 = ""
            _Telex = ""
            _TermCode = ""
            _Title1 = ""
            _Title2 = ""
            _Title3 = ""
            _WebSite = ""
            _WeekLunchFromTime = ConDateTime.MinDate
            _WeekLunchToTime = ConDateTime.MinDate
            _WeekWorkFromTime = ConDateTime.MinDate
            _WeekWorkToTime = ConDateTime.MinDate
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _StatusCode = ""
            _Password = ""
            _AttachmentFlag = ""
        End Sub

    End Class

#End Region
End Namespace
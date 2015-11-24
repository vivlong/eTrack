Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Statement Info "

    <Serializable()> _
    Public Class clsPropStatement
        Inherits clsProp
        Private _CustomerCode As String = ""
        Private _CustomerName As String = ""
        Private _CustomerType As String = ""
        Private _AccCode As String = ""
        Private _AreaCode As String = ""
        Private _CityCode As String = ""
        Private _ContraVendorCode As String = ""
        Private _CountryCode As String = ""
        Private _CurrCode As String = ""
        Private _DivisionCode As String = ""
        Private _SalesmanCode As String = ""
        Private _AnalysisCode As String = ""
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _Address3 As String = ""
        Private _Address4 As String = ""
        Private _BudgetAmt As String = ""
        Private _ConsolInvFlag As String = ""
        Private _ContactName1 As String = ""
        Private _ContactName2 As String = ""
        Private _ContactName3 As String = ""
        Private _CreditDate As String = ""
        Private _CreditLimit As String = ""
        Private _CreditLimitByDay As String = ""
        Private _CreditStatusCode As String = ""
        Private _CustomerHoldFlag As String = ""
        Private _CustomerShortCode As String = ""
        Private _Email As String = ""
        Private _Email1 As String = ""
        Private _Email2 As String = ""
        Private _Email3 As String = ""
        Private _Fax As String = ""
        Private _Fax1 As String = ""
        Private _Fax2 As String = ""
        Private _Fax3 As String = ""
        Private _ForeignBalanceAmt As String = ""
        Private _Handphone1 As String = ""
        Private _Handphone2 As String = ""
        Private _Handphone3 As String = ""
        Private _LastYrAverageMargin As String = ""
        Private _LastYrMth01CostAmt As String = ""
        Private _LastYrMth01Receipt As String = ""
        Private _LastYrMth01SalesAmt As String = ""
        Private _LastYrMth02CostAmt As String = ""
        Private _LastYrMth02Receipt As String = ""
        Private _LastYrMth02SalesAmt As String = ""
        Private _LastYrMth03CostAmt As String = ""
        Private _LastYrMth03Receipt As String = ""
        Private _LastYrMth03SalesAmt As String = ""
        Private _LastYrMth04CostAmt As String = ""
        Private _LastYrMth04Receipt As String = ""
        Private _LastYrMth04SalesAmt As String = ""
        Private _LastYrMth05CostAmt As String = ""
        Private _LastYrMth05Receipt As String = ""
        Private _LastYrMth05SalesAmt As String = ""
        Private _LastYrMth06CostAmt As String = ""
        Private _LastYrMth06Receipt As String = ""
        Private _LastYrMth06SalesAmt As String = ""
        Private _LastYrMth07CostAmt As String = ""
        Private _LastYrMth07Receipt As String = ""
        Private _LastYrMth07SalesAmt As String = ""
        Private _LastYrMth08CostAmt As String = ""
        Private _LastYrMth08Receipt As String = ""
        Private _LastYrMth08SalesAmt As String = ""
        Private _LastYrMth09CostAmt As String = ""
        Private _LastYrMth09Receipt As String = ""
        Private _LastYrMth09SalesAmt As String = ""
        Private _LastYrMth10CostAmt As String = ""
        Private _LastYrMth10Receipt As String = ""
        Private _LastYrMth10SalesAmt As String = ""
        Private _LastYrMth11CostAmt As String = ""
        Private _LastYrMth11Receipt As String = ""
        Private _LastYrMth11SalesAmt As String = ""
        Private _LastYrMth12CostAmt As String = ""
        Private _LastYrMth12Receipt As String = ""
        Private _LastYrMth12SalesAmt As String = ""
        Private _LastYrTotalSalesAmt As String = ""
        Private _LocalBalanceAmt As String = ""
        Private _LocalName As String = ""
        Private _MinAmtByDay As String = ""
        Private _MiscCustomerFlag As String = ""
        Private _OpenItemFlag As String = ""
        Private _Pager1 As String = ""
        Private _Pager2 As String = ""
        Private _Pager3 As String = ""
        Private _Password As String = ""
        Private _PostalCode As String = ""
        Private _PostArFlag As String = ""
        Private _PrintStatementFlag As String = ""
        Private _Remark As String = ""
        Private _SalesType As String = ""
        Private _ServiceChargeFlag As String = ""
        Private _TaxCode As String = ""
        Private _Telephone As String = ""
        Private _Telephone1 As String = ""
        Private _Telephone2 As String = ""
        Private _Telephone3 As String = ""
        Private _Telex As String = ""
        Private _TermCode As String = ""
        Private _ThisYrMtdAverageMargin As String = ""
        Private _ThisYrMtdSalesAmt As String = ""
        Private _ThisYrMth01CostAmt As String = ""
        Private _ThisYrMth01Receipt As String = ""
        Private _ThisYrMth01SalesAmt As String = ""
        Private _ThisYrMth02CostAmt As String = ""
        Private _ThisYrMth02Receipt As String = ""
        Private _ThisYrMth02SalesAmt As String = ""
        Private _ThisYrMth03CostAmt As String = ""
        Private _ThisYrMth03Receipt As String = ""
        Private _ThisYrMth03SalesAmt As String = ""
        Private _ThisYrMth04CostAmt As String = ""
        Private _ThisYrMth04Receipt As String = ""
        Private _ThisYrMth04SalesAmt As String = ""
        Private _ThisYrMth05CostAmt As String = ""
        Private _ThisYrMth05Receipt As String = ""
        Private _ThisYrMth05SalesAmt As String = ""
        Private _ThisYrMth06CostAmt As String = ""
        Private _ThisYrMth06Receipt As String = ""
        Private _ThisYrMth06SalesAmt As String = ""
        Private _ThisYrMth07CostAmt As String = ""
        Private _ThisYrMth07Receipt As String = ""
        Private _ThisYrMth07SalesAmt As String = ""
        Private _ThisYrMth08CostAmt As String = ""
        Private _ThisYrMth08Receipt As String = ""
        Private _ThisYrMth08SalesAmt As String = ""
        Private _ThisYrMth09CostAmt As String = ""
        Private _ThisYrMth09Receipt As String = ""
        Private _ThisYrMth09SalesAmt As String = ""
        Private _ThisYrMth10CostAmt As String = ""
        Private _ThisYrMth10Receipt As String = ""
        Private _ThisYrMth10SalesAmt As String = ""
        Private _ThisYrMth11CostAmt As String = ""
        Private _ThisYrMth11Receipt As String = ""
        Private _ThisYrMth11SalesAmt As String = ""
        Private _ThisYrMth12CostAmt As String = ""
        Private _ThisYrMth12Receipt As String = ""
        Private _ThisYrMth12SalesAmt As String = ""
        Private _ThisYrYtdSalesAmt As String = ""
        Private _Title1 As String = ""
        Private _Title2 As String = ""
        Private _Title3 As String = ""
        Private _UpdateFlag As String = ""
        Private _VatCode As String = ""
        Private _WebSite As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _StatusCode As String = ""
        Private _DistrictCode As String = ""
        Private _TrxNo As String = ""
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
        Public Property CustomerType() As String
            Set(ByVal value As String)
                If _CustomerType <> value Then
                    _CustomerType = value
                End If
            End Set
            Get
                Return _CustomerType
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
        Public Property AreaCode() As String
            Set(ByVal value As String)
                If _AreaCode <> value Then
                    _AreaCode = value
                End If
            End Set
            Get
                Return _AreaCode
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
        Public Property ContraVendorCode() As String
            Set(ByVal value As String)
                If _ContraVendorCode <> value Then
                    _ContraVendorCode = value
                End If
            End Set
            Get
                Return _ContraVendorCode
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
        Public Property AnalysisCode() As String
            Set(ByVal value As String)
                If _AnalysisCode <> value Then
                    _AnalysisCode = value
                End If
            End Set
            Get
                Return _AnalysisCode
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
        Public Property BudgetAmt() As String
            Set(ByVal value As String)
                If _BudgetAmt <> value Then
                    _BudgetAmt = value
                End If
            End Set
            Get
                Return _BudgetAmt
            End Get
        End Property
        ' 
        Public Property ConsolInvFlag() As String
            Set(ByVal value As String)
                If _ConsolInvFlag <> value Then
                    _ConsolInvFlag = value
                End If
            End Set
            Get
                Return _ConsolInvFlag
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
        Public Property CreditDate() As String
            Set(ByVal value As String)
                If _CreditDate <> value Then
                    _CreditDate = value
                End If
            End Set
            Get
                Return _CreditDate
            End Get
        End Property
        ' 
        Public Property CreditLimit() As String
            Set(ByVal value As String)
                If _CreditLimit <> value Then
                    _CreditLimit = value
                End If
            End Set
            Get
                Return _CreditLimit
            End Get
        End Property
        ' 
        Public Property CreditLimitByDay() As String
            Set(ByVal value As String)
                If _CreditLimitByDay <> value Then
                    _CreditLimitByDay = value
                End If
            End Set
            Get
                Return _CreditLimitByDay
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
        Public Property CustomerHoldFlag() As String
            Set(ByVal value As String)
                If _CustomerHoldFlag <> value Then
                    _CustomerHoldFlag = value
                End If
            End Set
            Get
                Return _CustomerHoldFlag
            End Get
        End Property
        ' 
        Public Property CustomerShortCode() As String
            Set(ByVal value As String)
                If _CustomerShortCode <> value Then
                    _CustomerShortCode = value
                End If
            End Set
            Get
                Return _CustomerShortCode
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
        Public Property ForeignBalanceAmt() As String
            Set(ByVal value As String)
                If _ForeignBalanceAmt <> value Then
                    _ForeignBalanceAmt = value
                End If
            End Set
            Get
                Return _ForeignBalanceAmt
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
        Public Property LastYrAverageMargin() As String
            Set(ByVal value As String)
                If _LastYrAverageMargin <> value Then
                    _LastYrAverageMargin = value
                End If
            End Set
            Get
                Return _LastYrAverageMargin
            End Get
        End Property
        ' 
        Public Property LastYrMth01CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth01CostAmt <> value Then
                    _LastYrMth01CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth01CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth01Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth01Receipt <> value Then
                    _LastYrMth01Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth01Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth01SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth01SalesAmt <> value Then
                    _LastYrMth01SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth01SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth02CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth02CostAmt <> value Then
                    _LastYrMth02CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth02CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth02Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth02Receipt <> value Then
                    _LastYrMth02Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth02Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth02SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth02SalesAmt <> value Then
                    _LastYrMth02SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth02SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth03CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth03CostAmt <> value Then
                    _LastYrMth03CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth03CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth03Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth03Receipt <> value Then
                    _LastYrMth03Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth03Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth03SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth03SalesAmt <> value Then
                    _LastYrMth03SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth03SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth04CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth04CostAmt <> value Then
                    _LastYrMth04CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth04CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth04Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth04Receipt <> value Then
                    _LastYrMth04Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth04Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth04SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth04SalesAmt <> value Then
                    _LastYrMth04SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth04SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth05CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth05CostAmt <> value Then
                    _LastYrMth05CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth05CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth05Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth05Receipt <> value Then
                    _LastYrMth05Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth05Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth05SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth05SalesAmt <> value Then
                    _LastYrMth05SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth05SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth06CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth06CostAmt <> value Then
                    _LastYrMth06CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth06CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth06Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth06Receipt <> value Then
                    _LastYrMth06Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth06Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth06SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth06SalesAmt <> value Then
                    _LastYrMth06SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth06SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth07CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth07CostAmt <> value Then
                    _LastYrMth07CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth07CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth07Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth07Receipt <> value Then
                    _LastYrMth07Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth07Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth07SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth07SalesAmt <> value Then
                    _LastYrMth07SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth07SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth08CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth08CostAmt <> value Then
                    _LastYrMth08CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth08CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth08Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth08Receipt <> value Then
                    _LastYrMth08Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth08Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth08SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth08SalesAmt <> value Then
                    _LastYrMth08SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth08SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth09CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth09CostAmt <> value Then
                    _LastYrMth09CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth09CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth09Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth09Receipt <> value Then
                    _LastYrMth09Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth09Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth09SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth09SalesAmt <> value Then
                    _LastYrMth09SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth09SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth10CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth10CostAmt <> value Then
                    _LastYrMth10CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth10CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth10Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth10Receipt <> value Then
                    _LastYrMth10Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth10Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth10SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth10SalesAmt <> value Then
                    _LastYrMth10SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth10SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth11CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth11CostAmt <> value Then
                    _LastYrMth11CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth11CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth11Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth11Receipt <> value Then
                    _LastYrMth11Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth11Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth11SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth11SalesAmt <> value Then
                    _LastYrMth11SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth11SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth12CostAmt() As String
            Set(ByVal value As String)
                If _LastYrMth12CostAmt <> value Then
                    _LastYrMth12CostAmt = value
                End If
            End Set
            Get
                Return _LastYrMth12CostAmt
            End Get
        End Property
        ' 
        Public Property LastYrMth12Receipt() As String
            Set(ByVal value As String)
                If _LastYrMth12Receipt <> value Then
                    _LastYrMth12Receipt = value
                End If
            End Set
            Get
                Return _LastYrMth12Receipt
            End Get
        End Property
        ' 
        Public Property LastYrMth12SalesAmt() As String
            Set(ByVal value As String)
                If _LastYrMth12SalesAmt <> value Then
                    _LastYrMth12SalesAmt = value
                End If
            End Set
            Get
                Return _LastYrMth12SalesAmt
            End Get
        End Property
        ' 
        Public Property LastYrTotalSalesAmt() As String
            Set(ByVal value As String)
                If _LastYrTotalSalesAmt <> value Then
                    _LastYrTotalSalesAmt = value
                End If
            End Set
            Get
                Return _LastYrTotalSalesAmt
            End Get
        End Property
        ' 
        Public Property LocalBalanceAmt() As String
            Set(ByVal value As String)
                If _LocalBalanceAmt <> value Then
                    _LocalBalanceAmt = value
                End If
            End Set
            Get
                Return _LocalBalanceAmt
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
        Public Property MinAmtByDay() As String
            Set(ByVal value As String)
                If _MinAmtByDay <> value Then
                    _MinAmtByDay = value
                End If
            End Set
            Get
                Return _MinAmtByDay
            End Get
        End Property
        ' 
        Public Property MiscCustomerFlag() As String
            Set(ByVal value As String)
                If _MiscCustomerFlag <> value Then
                    _MiscCustomerFlag = value
                End If
            End Set
            Get
                Return _MiscCustomerFlag
            End Get
        End Property
        ' 
        Public Property OpenItemFlag() As String
            Set(ByVal value As String)
                If _OpenItemFlag <> value Then
                    _OpenItemFlag = value
                End If
            End Set
            Get
                Return _OpenItemFlag
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
        Public Property PostArFlag() As String
            Set(ByVal value As String)
                If _PostArFlag <> value Then
                    _PostArFlag = value
                End If
            End Set
            Get
                Return _PostArFlag
            End Get
        End Property
        ' 
        Public Property PrintStatementFlag() As String
            Set(ByVal value As String)
                If _PrintStatementFlag <> value Then
                    _PrintStatementFlag = value
                End If
            End Set
            Get
                Return _PrintStatementFlag
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
        Public Property SalesType() As String
            Set(ByVal value As String)
                If _SalesType <> value Then
                    _SalesType = value
                End If
            End Set
            Get
                Return _SalesType
            End Get
        End Property
        ' 
        Public Property ServiceChargeFlag() As String
            Set(ByVal value As String)
                If _ServiceChargeFlag <> value Then
                    _ServiceChargeFlag = value
                End If
            End Set
            Get
                Return _ServiceChargeFlag
            End Get
        End Property
        ' 
        Public Property TaxCode() As String
            Set(ByVal value As String)
                If _TaxCode <> value Then
                    _TaxCode = value
                End If
            End Set
            Get
                Return _TaxCode
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
        Public Property ThisYrMtdAverageMargin() As String
            Set(ByVal value As String)
                If _ThisYrMtdAverageMargin <> value Then
                    _ThisYrMtdAverageMargin = value
                End If
            End Set
            Get
                Return _ThisYrMtdAverageMargin
            End Get
        End Property
        ' 
        Public Property ThisYrMtdSalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMtdSalesAmt <> value Then
                    _ThisYrMtdSalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMtdSalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth01CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth01CostAmt <> value Then
                    _ThisYrMth01CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth01CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth01Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth01Receipt <> value Then
                    _ThisYrMth01Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth01Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth01SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth01SalesAmt <> value Then
                    _ThisYrMth01SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth01SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth02CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth02CostAmt <> value Then
                    _ThisYrMth02CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth02CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth02Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth02Receipt <> value Then
                    _ThisYrMth02Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth02Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth02SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth02SalesAmt <> value Then
                    _ThisYrMth02SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth02SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth03CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth03CostAmt <> value Then
                    _ThisYrMth03CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth03CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth03Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth03Receipt <> value Then
                    _ThisYrMth03Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth03Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth03SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth03SalesAmt <> value Then
                    _ThisYrMth03SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth03SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth04CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth04CostAmt <> value Then
                    _ThisYrMth04CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth04CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth04Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth04Receipt <> value Then
                    _ThisYrMth04Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth04Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth04SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth04SalesAmt <> value Then
                    _ThisYrMth04SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth04SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth05CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth05CostAmt <> value Then
                    _ThisYrMth05CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth05CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth05Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth05Receipt <> value Then
                    _ThisYrMth05Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth05Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth05SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth05SalesAmt <> value Then
                    _ThisYrMth05SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth05SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth06CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth06CostAmt <> value Then
                    _ThisYrMth06CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth06CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth06Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth06Receipt <> value Then
                    _ThisYrMth06Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth06Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth06SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth06SalesAmt <> value Then
                    _ThisYrMth06SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth06SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth07CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth07CostAmt <> value Then
                    _ThisYrMth07CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth07CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth07Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth07Receipt <> value Then
                    _ThisYrMth07Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth07Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth07SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth07SalesAmt <> value Then
                    _ThisYrMth07SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth07SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth08CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth08CostAmt <> value Then
                    _ThisYrMth08CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth08CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth08Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth08Receipt <> value Then
                    _ThisYrMth08Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth08Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth08SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth08SalesAmt <> value Then
                    _ThisYrMth08SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth08SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth09CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth09CostAmt <> value Then
                    _ThisYrMth09CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth09CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth09Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth09Receipt <> value Then
                    _ThisYrMth09Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth09Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth09SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth09SalesAmt <> value Then
                    _ThisYrMth09SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth09SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth10CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth10CostAmt <> value Then
                    _ThisYrMth10CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth10CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth10Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth10Receipt <> value Then
                    _ThisYrMth10Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth10Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth10SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth10SalesAmt <> value Then
                    _ThisYrMth10SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth10SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth11CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth11CostAmt <> value Then
                    _ThisYrMth11CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth11CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth11Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth11Receipt <> value Then
                    _ThisYrMth11Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth11Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth11SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth11SalesAmt <> value Then
                    _ThisYrMth11SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth11SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth12CostAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth12CostAmt <> value Then
                    _ThisYrMth12CostAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth12CostAmt
            End Get
        End Property
        ' 
        Public Property ThisYrMth12Receipt() As String
            Set(ByVal value As String)
                If _ThisYrMth12Receipt <> value Then
                    _ThisYrMth12Receipt = value
                End If
            End Set
            Get
                Return _ThisYrMth12Receipt
            End Get
        End Property
        ' 
        Public Property ThisYrMth12SalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrMth12SalesAmt <> value Then
                    _ThisYrMth12SalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrMth12SalesAmt
            End Get
        End Property
        ' 
        Public Property ThisYrYtdSalesAmt() As String
            Set(ByVal value As String)
                If _ThisYrYtdSalesAmt <> value Then
                    _ThisYrYtdSalesAmt = value
                End If
            End Set
            Get
                Return _ThisYrYtdSalesAmt
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
        Public Property UpdateFlag() As String
            Set(ByVal value As String)
                If _UpdateFlag <> value Then
                    _UpdateFlag = value
                End If
            End Set
            Get
                Return _UpdateFlag
            End Get
        End Property
        ' 
        Public Property VatCode() As String
            Set(ByVal value As String)
                If _VatCode <> value Then
                    _VatCode = value
                End If
            End Set
            Get
                Return _VatCode
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
            _CustomerCode = ""
            _CustomerName = ""
            _CustomerType = ""
            _AccCode = ""
            _AreaCode = ""
            _CityCode = ""
            _ContraVendorCode = ""
            _CountryCode = ""
            _CurrCode = ""
            _DivisionCode = ""
            _SalesmanCode = ""
            _AnalysisCode = ""
            _Address1 = ""
            _Address2 = ""
            _Address3 = ""
            _Address4 = ""
            _BudgetAmt = ""
            _ConsolInvFlag = ""
            _ContactName1 = ""
            _ContactName2 = ""
            _ContactName3 = ""
            _CreditDate = ""
            _CreditLimit = ""
            _CreditLimitByDay = ""
            _CreditStatusCode = ""
            _CustomerHoldFlag = ""
            _CustomerShortCode = ""
            _Email = ""
            _Email1 = ""
            _Email2 = ""
            _Email3 = ""
            _Fax = ""
            _Fax1 = ""
            _Fax2 = ""
            _Fax3 = ""
            _ForeignBalanceAmt = ""
            _Handphone1 = ""
            _Handphone2 = ""
            _Handphone3 = ""
            _LastYrAverageMargin = ""
            _LastYrMth01CostAmt = ""
            _LastYrMth01Receipt = ""
            _LastYrMth01SalesAmt = ""
            _LastYrMth02CostAmt = ""
            _LastYrMth02Receipt = ""
            _LastYrMth02SalesAmt = ""
            _LastYrMth03CostAmt = ""
            _LastYrMth03Receipt = ""
            _LastYrMth03SalesAmt = ""
            _LastYrMth04CostAmt = ""
            _LastYrMth04Receipt = ""
            _LastYrMth04SalesAmt = ""
            _LastYrMth05CostAmt = ""
            _LastYrMth05Receipt = ""
            _LastYrMth05SalesAmt = ""
            _LastYrMth06CostAmt = ""
            _LastYrMth06Receipt = ""
            _LastYrMth06SalesAmt = ""
            _LastYrMth07CostAmt = ""
            _LastYrMth07Receipt = ""
            _LastYrMth07SalesAmt = ""
            _LastYrMth08CostAmt = ""
            _LastYrMth08Receipt = ""
            _LastYrMth08SalesAmt = ""
            _LastYrMth09CostAmt = ""
            _LastYrMth09Receipt = ""
            _LastYrMth09SalesAmt = ""
            _LastYrMth10CostAmt = ""
            _LastYrMth10Receipt = ""
            _LastYrMth10SalesAmt = ""
            _LastYrMth11CostAmt = ""
            _LastYrMth11Receipt = ""
            _LastYrMth11SalesAmt = ""
            _LastYrMth12CostAmt = ""
            _LastYrMth12Receipt = ""
            _LastYrMth12SalesAmt = ""
            _LastYrTotalSalesAmt = ""
            _LocalBalanceAmt = ""
            _LocalName = ""
            _MinAmtByDay = ""
            _MiscCustomerFlag = ""
            _OpenItemFlag = ""
            _Pager1 = ""
            _Pager2 = ""
            _Pager3 = ""
            _Password = ""
            _PostalCode = ""
            _PostArFlag = ""
            _PrintStatementFlag = ""
            _Remark = ""
            _SalesType = ""
            _ServiceChargeFlag = ""
            _TaxCode = ""
            _Telephone = ""
            _Telephone1 = ""
            _Telephone2 = ""
            _Telephone3 = ""
            _Telex = ""
            _TermCode = ""
            _ThisYrMtdAverageMargin = ""
            _ThisYrMtdSalesAmt = ""
            _ThisYrMth01CostAmt = ""
            _ThisYrMth01Receipt = ""
            _ThisYrMth01SalesAmt = ""
            _ThisYrMth02CostAmt = ""
            _ThisYrMth02Receipt = ""
            _ThisYrMth02SalesAmt = ""
            _ThisYrMth03CostAmt = ""
            _ThisYrMth03Receipt = ""
            _ThisYrMth03SalesAmt = ""
            _ThisYrMth04CostAmt = ""
            _ThisYrMth04Receipt = ""
            _ThisYrMth04SalesAmt = ""
            _ThisYrMth05CostAmt = ""
            _ThisYrMth05Receipt = ""
            _ThisYrMth05SalesAmt = ""
            _ThisYrMth06CostAmt = ""
            _ThisYrMth06Receipt = ""
            _ThisYrMth06SalesAmt = ""
            _ThisYrMth07CostAmt = ""
            _ThisYrMth07Receipt = ""
            _ThisYrMth07SalesAmt = ""
            _ThisYrMth08CostAmt = ""
            _ThisYrMth08Receipt = ""
            _ThisYrMth08SalesAmt = ""
            _ThisYrMth09CostAmt = ""
            _ThisYrMth09Receipt = ""
            _ThisYrMth09SalesAmt = ""
            _ThisYrMth10CostAmt = ""
            _ThisYrMth10Receipt = ""
            _ThisYrMth10SalesAmt = ""
            _ThisYrMth11CostAmt = ""
            _ThisYrMth11Receipt = ""
            _ThisYrMth11SalesAmt = ""
            _ThisYrMth12CostAmt = ""
            _ThisYrMth12Receipt = ""
            _ThisYrMth12SalesAmt = ""
            _ThisYrYtdSalesAmt = ""
            _Title1 = ""
            _Title2 = ""
            _Title3 = ""
            _UpdateFlag = ""
            _VatCode = ""
            _WebSite = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _StatusCode = ""
            _DistrictCode = ""
            _TrxNo = ""
        End Sub

    End Class

#End Region
End Namespace
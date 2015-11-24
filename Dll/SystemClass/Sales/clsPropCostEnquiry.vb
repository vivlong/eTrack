Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass
#Region " Class Property of CostEnquiry Info "

    <Serializable()> _
    Public Class clsPropCostEnquiry
        Inherits clsProp
        Private _CostEnquiryCode As String = ""
        Private _CostEnquiryName As String = ""
        Private _AnalysisCode As String = ""
        Private _CityCode As String = ""
        Private _CountryCode As String = ""
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _Address3 As String = ""
        Private _Address4 As String = ""
        Private _CommissionPercent As String = ""
        Private _ContactName As String = ""
        Private _DeliveryToCode As String = ""
        Private _Email As String = ""
        Private _Fax As String = ""
        Private _FIataCode As String = ""
        Private _PrincipleAccCode As String = ""
        Private _Remark As String = ""
        Private _ShipAgentCode As String = ""
        Private _Telephone As String = ""
        Private _Telex As String = ""
        Private _WebSite As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        ' 
        Public Property CostEnquiryCode() As String
            Set(ByVal value As String)
                If _CostEnquiryCode <> value Then
                    _CostEnquiryCode = value
                End If
            End Set
            Get
                Return _CostEnquiryCode
            End Get
        End Property
        ' 
        Public Property CostEnquiryName() As String
            Set(ByVal value As String)
                If _CostEnquiryName <> value Then
                    _CostEnquiryName = value
                End If
            End Set
            Get
                Return _CostEnquiryName
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
        Public Property CommissionPercent() As String
            Set(ByVal value As String)
                If _CommissionPercent <> value Then
                    _CommissionPercent = value
                End If
            End Set
            Get
                Return _CommissionPercent
            End Get
        End Property
        ' 
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
        Public Property FIataCode() As String
            Set(ByVal value As String)
                If _FIataCode <> value Then
                    _FIataCode = value
                End If
            End Set
            Get
                Return _FIataCode
            End Get
        End Property
        ' 
        Public Property PrincipleAccCode() As String
            Set(ByVal value As String)
                If _PrincipleAccCode <> value Then
                    _PrincipleAccCode = value
                End If
            End Set
            Get
                Return _PrincipleAccCode
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
        Public Property ShipAgentCode() As String
            Set(ByVal value As String)
                If _ShipAgentCode <> value Then
                    _ShipAgentCode = value
                End If
            End Set
            Get
                Return _ShipAgentCode
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

        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _CostEnquiryCode = ""
            _CostEnquiryName = ""
            _AnalysisCode = ""
            _CityCode = ""
            _CountryCode = ""
            _Address1 = ""
            _Address2 = ""
            _Address3 = ""
            _Address4 = ""
            _CommissionPercent = ""
            _ContactName = ""
            _DeliveryToCode = ""
            _Email = ""
            _Fax = ""
            _FIataCode = ""
            _PrincipleAccCode = ""
            _Remark = ""
            _ShipAgentCode = ""
            _Telephone = ""
            _Telex = ""
            _WebSite = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
        End Sub

    End Class

#End Region
End Namespace
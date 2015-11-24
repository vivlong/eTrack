Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Airline Info "

    <Serializable()> _
    Public Class clsPropAirline
        Inherits clsProp
        Private _AirlineCode As String = ""
        Private _AirlineID As String = ""
        Private _AirlineName As String = ""
        Private _AnalysisCode As String = ""
        Private _CityCode As String = ""
        Private _CountryCode As String = ""
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _Address3 As String = ""
        Private _Address4 As String = ""
        Private _CiasSatsFlag As String = ""
        Private _CommissionPercent As String = ""
        Private _ContactName As String = ""
        Private _Email As String = ""
        Private _Fax As String = ""
        Private _IataCode As String = ""
        Private _LeftMargin As String = ""
        Private _NeutralAwbFlag As String = ""
        Private _NoOfColumn As String = ""
        Private _NoOfRow As String = ""
        Private _PimaAddress As String = ""
        Private _PimaAddressOther As String = ""
        Private _PrincipalAccCode As String = ""
        Private _Remark As String = ""
        Private _SendToCcnAutoFlag As String = ""
        Private _Telephone As String = ""
        Private _Telex As String = ""
        Private _TopMargin As String = ""
        Private _TtyAddressAwb As String = ""
        Private _TtyAddressOther As String = ""
        Private _WebSite As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
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
        Public Property AirlineID() As String
            Set(ByVal value As String)
                If _AirlineID <> value Then
                    _AirlineID = value
                End If
            End Set
            Get
                Return _AirlineID
            End Get
        End Property
        ' 
        Public Property AirlineName() As String
            Set(ByVal value As String)
                If _AirlineName <> value Then
                    _AirlineName = value
                End If
            End Set
            Get
                Return _AirlineName
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
        Public Property CiasSatsFlag() As String
            Set(ByVal value As String)
                If _CiasSatsFlag <> value Then
                    _CiasSatsFlag = value
                End If
            End Set
            Get
                Return _CiasSatsFlag
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
        Public Property IataCode() As String
            Set(ByVal value As String)
                If _IataCode <> value Then
                    _IataCode = value
                End If
            End Set
            Get
                Return _IataCode
            End Get
        End Property
        ' 
        Public Property LeftMargin() As String
            Set(ByVal value As String)
                If _LeftMargin <> value Then
                    _LeftMargin = value
                End If
            End Set
            Get
                Return _LeftMargin
            End Get
        End Property
        ' 
        Public Property NeutralAwbFlag() As String
            Set(ByVal value As String)
                If _NeutralAwbFlag <> value Then
                    _NeutralAwbFlag = value
                End If
            End Set
            Get
                Return _NeutralAwbFlag
            End Get
        End Property
        ' 
        Public Property NoOfColumn() As String
            Set(ByVal value As String)
                If _NoOfColumn <> value Then
                    _NoOfColumn = value
                End If
            End Set
            Get
                Return _NoOfColumn
            End Get
        End Property
        ' 
        Public Property NoOfRow() As String
            Set(ByVal value As String)
                If _NoOfRow <> value Then
                    _NoOfRow = value
                End If
            End Set
            Get
                Return _NoOfRow
            End Get
        End Property
        ' 
        Public Property PimaAddress() As String
            Set(ByVal value As String)
                If _PimaAddress <> value Then
                    _PimaAddress = value
                End If
            End Set
            Get
                Return _PimaAddress
            End Get
        End Property
        ' 
        Public Property PimaAddressOther() As String
            Set(ByVal value As String)
                If _PimaAddressOther <> value Then
                    _PimaAddressOther = value
                End If
            End Set
            Get
                Return _PimaAddressOther
            End Get
        End Property
        ' 
        Public Property PrincipalAccCode() As String
            Set(ByVal value As String)
                If _PrincipalAccCode <> value Then
                    _PrincipalAccCode = value
                End If
            End Set
            Get
                Return _PrincipalAccCode
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
        Public Property SendToCcnAutoFlag() As String
            Set(ByVal value As String)
                If _SendToCcnAutoFlag <> value Then
                    _SendToCcnAutoFlag = value
                End If
            End Set
            Get
                Return _SendToCcnAutoFlag
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
        Public Property TopMargin() As String
            Set(ByVal value As String)
                If _TopMargin <> value Then
                    _TopMargin = value
                End If
            End Set
            Get
                Return _TopMargin
            End Get
        End Property
        ' 
        Public Property TtyAddressAwb() As String
            Set(ByVal value As String)
                If _TtyAddressAwb <> value Then
                    _TtyAddressAwb = value
                End If
            End Set
            Get
                Return _TtyAddressAwb
            End Get
        End Property
        ' 
        Public Property TtyAddressOther() As String
            Set(ByVal value As String)
                If _TtyAddressOther <> value Then
                    _TtyAddressOther = value
                End If
            End Set
            Get
                Return _TtyAddressOther
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
            _AirlineCode = ""
            _AirlineID = ""
            _AirlineName = ""
            _AnalysisCode = ""
            _CityCode = ""
            _CountryCode = ""
            _Address1 = ""
            _Address2 = ""
            _Address3 = ""
            _Address4 = ""
            _CiasSatsFlag = ""
            _CommissionPercent = ""
            _ContactName = ""
            _Email = ""
            _Fax = ""
            _IataCode = ""
            _LeftMargin = ""
            _NeutralAwbFlag = ""
            _NoOfColumn = ""
            _NoOfRow = ""
            _PimaAddress = ""
            _PimaAddressOther = ""
            _PrincipalAccCode = ""
            _Remark = ""
            _SendToCcnAutoFlag = ""
            _Telephone = ""
            _Telex = ""
            _TopMargin = ""
            _TtyAddressAwb = ""
            _TtyAddressOther = ""
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
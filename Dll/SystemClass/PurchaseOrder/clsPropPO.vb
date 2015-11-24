Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of PO Info "

    <Serializable()> _
    Public Class clsPropPO
        Inherits clsProp
        Private _TrxNo As Integer
        Private _POLine As String = ""
        Private _PONo As String = ""
        Private _PartialPOFlag As String = ""
        Private _POCurrCode As String = ""
        Private _POAmt As Decimal = 0
        Private _POIssueDate As DateTime
        Private _POStatus As String = ""
        Private _PODescription As String = ""
        Private _IncoTerm As String = ""
        Private _IncoTermCity As String = ""
        Private _ModeOfTransport As String = ""
        Private _InvoiceNo As String = ""
        Private _SupplierName As String = ""
        Private _SupplierAddr1 As String = ""
        Private _SupplierAddr2 As String = ""
        Private _SupplierAddr3 As String = ""
        Private _SupplierAddr4 As String = ""
        Private _SupplierPhone As String = ""
        Private _SupplierFax As String = ""
        Private _SupplierCity As String = ""
        Private _SupplierCountry As String = ""
        Private _SupplierFirstName As String = ""
        Private _SupplierLastName As String = ""
        Private _CompanyName As String = ""
        Private _Address1 As String = ""
        Private _Address2 As String = ""
        Private _Address3 As String = ""
        Private _Address4 As String = ""
        Private _Phone As String = ""
        Private _Fax As String = ""
        Private _Email As String = ""
        Private _City As String = ""
        Private _Country As String = ""
        Private _ContactFirstName As String = ""
        Private _ContactLastName As String = ""
        ' 
        Private _PoAmount As String
        Private _SupplierPostalCode As String = ""
        Private _PostalCode As String = ""

        Private _FirstName As String = ""
        Private _LastName As String = ""
        Private _SupplierState As String = ""
        Private _State As String = ""
        Private _SupplierEmail As String = ""
        Private _deliveryDate As DateTime
        Private _BusinessPartyCode As String
        Private _ContactPerson As String
        Private _PortOfLoadingCode As String
        Private _PortOfDischargeCode As String
        Private _ShipToName As String
        Private _ShipToAddress1 As String
        Private _ShipToAddress2 As String
        Private _ShipToAddress3 As String
        Private _ShipToAddress4 As String
        Private _ShipToEmail As String
        Private _ShipToPhone As String
        Private _ShipToFax As String
        Private _deliveryETD As DateTime
        Private _ETD As DateTime
        Private _ETA As DateTime
        Private _RequiredDate As DateTime
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
        Public Property POLine() As String
            Set(ByVal value As String)
                If _POLine <> value Then
                    _POLine = value
                End If
            End Set
            Get
                Return _POLine
            End Get
        End Property
        ' 
        Public Property PONo() As String
            Set(ByVal value As String)
                If _PONo <> value Then
                    _PONo = value
                End If
            End Set
            Get
                Return _PONo
            End Get
        End Property
        ' 
        Public Property PartialPOFlag() As String
            Set(ByVal value As String)
                If _PartialPOFlag <> value Then
                    _PartialPOFlag = value
                End If
            End Set
            Get
                Return _PartialPOFlag
            End Get
        End Property
        ' 
        Public Property POCurrCode() As String
            Set(ByVal value As String)
                If _POCurrCode <> value Then
                    _POCurrCode = value
                End If
            End Set
            Get
                Return _POCurrCode
            End Get
        End Property
        ' 
        Public Property POAmt() As Decimal
            Set(ByVal value As Decimal)
                If _POAmt <> value Then
                    _POAmt = value
                End If
            End Set
            Get
                Return _POAmt
            End Get
        End Property
        ' 
        Public Property POIssueDate() As DateTime
            Set(ByVal value As DateTime)
                If _POIssueDate <> value Then
                    _POIssueDate = value
                End If
            End Set
            Get
                Return _POIssueDate
            End Get
        End Property
        ' 
        Public Property POStatus() As String
            Set(ByVal value As String)
                If _POStatus <> value Then
                    _POStatus = value
                End If
            End Set
            Get
                Return _POStatus
            End Get
        End Property
        ' 
        Public Property PODescription() As String
            Set(ByVal value As String)
                If _PODescription <> value Then
                    _PODescription = value
                End If
            End Set
            Get
                Return _PODescription
            End Get
        End Property
        ' 
        Public Property IncoTerm() As String
            Set(ByVal value As String)
                If _IncoTerm <> value Then
                    _IncoTerm = value
                End If
            End Set
            Get
                Return _IncoTerm
            End Get
        End Property
        ' 
        Public Property IncoTermCity() As String
            Set(ByVal value As String)
                If _IncoTermCity <> value Then
                    _IncoTermCity = value
                End If
            End Set
            Get
                Return _IncoTermCity
            End Get
        End Property
        ' 
        Public Property ModeOfTransport() As String
            Set(ByVal value As String)
                If _ModeOfTransport <> value Then
                    _ModeOfTransport = value
                End If
            End Set
            Get
                Return _ModeOfTransport
            End Get
        End Property
        ' 
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
        ' 
        Public Property SupplierName() As String
            Set(ByVal value As String)
                If _SupplierName <> value Then
                    _SupplierName = value
                End If
            End Set
            Get
                Return _SupplierName
            End Get
        End Property
        ' 
        Public Property SupplierAddr1() As String
            Set(ByVal value As String)
                If _SupplierAddr1 <> value Then
                    _SupplierAddr1 = value
                End If
            End Set
            Get
                Return _SupplierAddr1
            End Get
        End Property
        ' 
        Public Property SupplierAddr2() As String
            Set(ByVal value As String)
                If _SupplierAddr2 <> value Then
                    _SupplierAddr2 = value
                End If
            End Set
            Get
                Return _SupplierAddr2
            End Get
        End Property
        ' 
        Public Property SupplierAddr3() As String
            Set(ByVal value As String)
                If _SupplierAddr3 <> value Then
                    _SupplierAddr3 = value
                End If
            End Set
            Get
                Return _SupplierAddr3
            End Get
        End Property
        ' 
        Public Property SupplierAddr4() As String
            Set(ByVal value As String)
                If _SupplierAddr4 <> value Then
                    _SupplierAddr4 = value
                End If
            End Set
            Get
                Return _SupplierAddr4
            End Get
        End Property
        ' 
        Public Property SupplierPhone() As String
            Set(ByVal value As String)
                If _SupplierPhone <> value Then
                    _SupplierPhone = value
                End If
            End Set
            Get
                Return _SupplierPhone
            End Get
        End Property
        ' 
        Public Property SupplierFax() As String
            Set(ByVal value As String)
                If _SupplierFax <> value Then
                    _SupplierFax = value
                End If
            End Set
            Get
                Return _SupplierFax
            End Get
        End Property
        ' 
        Public Property SupplierCity() As String
            Set(ByVal value As String)
                If _SupplierCity <> value Then
                    _SupplierCity = value
                End If
            End Set
            Get
                Return _SupplierCity
            End Get
        End Property
        ' 
        Public Property SupplierCountry() As String
            Set(ByVal value As String)
                If _SupplierCountry <> value Then
                    _SupplierCountry = value
                End If
            End Set
            Get
                Return _SupplierCountry
            End Get
        End Property
        ' 
        Public Property SupplierFirstName() As String
            Set(ByVal value As String)
                If _SupplierFirstName <> value Then
                    _SupplierFirstName = value
                End If
            End Set
            Get
                Return _SupplierFirstName
            End Get
        End Property
        ' 
        Public Property SupplierLastName() As String
            Set(ByVal value As String)
                If _SupplierLastName <> value Then
                    _SupplierLastName = value
                End If
            End Set
            Get
                Return _SupplierLastName
            End Get
        End Property
        ' 
        Public Property CompanyName() As String
            Set(ByVal value As String)
                If _CompanyName <> value Then
                    _CompanyName = value
                End If
            End Set
            Get
                Return _CompanyName
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
        Public Property Phone() As String
            Set(ByVal value As String)
                If _Phone <> value Then
                    _Phone = value
                End If
            End Set
            Get
                Return _Phone
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
        Public Property City() As String
            Set(ByVal value As String)
                If _City <> value Then
                    _City = value
                End If
            End Set
            Get
                Return _City
            End Get
        End Property
        ' 
        Public Property Country() As String
            Set(ByVal value As String)
                If _Country <> value Then
                    _Country = value
                End If
            End Set
            Get
                Return _Country
            End Get
        End Property
        ' 
        Public Property ContactFirstName() As String
            Set(ByVal value As String)
                If _ContactFirstName <> value Then
                    _ContactFirstName = value
                End If
            End Set
            Get
                Return _ContactFirstName
            End Get
        End Property
        ' 
        Public Property ContactLastName() As String
            Set(ByVal value As String)
                If _ContactLastName <> value Then
                    _ContactLastName = value
                End If
            End Set
            Get
                Return _ContactLastName
            End Get
        End Property

        Public Property PoAmount() As String
            Set(ByVal value As String)
                If _PoAmount <> value Then
                    _PoAmount = value
                End If
            End Set
            Get
                Return _PoAmount
            End Get
        End Property

        Public Property SupplierPostalCode() As String
            Set(ByVal value As String)
                If _SupplierPostalCode <> value Then
                    _SupplierPostalCode = value
                End If
            End Set
            Get
                Return _SupplierPostalCode
            End Get
        End Property

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

        Public Property FirstName() As String
            Set(ByVal value As String)
                If _FirstName <> value Then
                    _FirstName = value
                End If
            End Set
            Get
                Return _FirstName
            End Get
        End Property

        Public Property LastName() As String
            Set(ByVal value As String)
                If _LastName <> value Then
                    _LastName = value
                End If
            End Set
            Get
                Return _LastName
            End Get
        End Property

        Public Property SupplierState() As String
            Set(ByVal value As String)
                If _SupplierState <> value Then
                    _SupplierState = value
                End If
            End Set
            Get
                Return _SupplierState
            End Get
        End Property

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

        Public Property SupplierEmail() As String
            Set(ByVal value As String)
                If _SupplierEmail <> value Then
                    _SupplierEmail = value
                End If
            End Set
            Get
                Return _SupplierEmail
            End Get
        End Property

        Public Property DeliveryDate() As DateTime
            Set(ByVal value As DateTime)
                If _deliveryDate <> value Then
                    _deliveryDate = value
                End If
            End Set
            Get
                Return _deliveryDate
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
        Public Property ContactPerson() As String
            Set(ByVal value As String)
                If _ContactPerson <> value Then
                    _ContactPerson = value
                End If
            End Set
            Get
                Return _ContactPerson
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
        Public Property ShipToName() As String
            Set(ByVal value As String)
                If _ShipToName <> value Then
                    _ShipToName = value
                End If
            End Set
            Get
                Return _ShipToName
            End Get
        End Property
        Public Property ShipToAddress() As String
            Set(ByVal value As String)
                Dim arrValue() As String = value.Split(Chr(13) + Chr(10))
                If arrValue.Length > 0 Then
                    _ShipToAddress1 = arrValue(0)
                End If
                If arrValue.Length > 1 Then
                    _ShipToAddress2 = arrValue(1)
                End If
                If arrValue.Length > 2 Then
                    _ShipToAddress3 = arrValue(2)
                End If
                If arrValue.Length > 3 Then
                    _ShipToAddress4 = arrValue(3)
                End If
            End Set
            Get
                Return _ShipToAddress1 + Chr(13) + Chr(10) + _ShipToAddress2 + Chr(13) + Chr(10) + _ShipToAddress3 + Chr(13) + Chr(10) + _ShipToAddress4 + Chr(13) + Chr(10)
            End Get
        End Property
        Public Property ShipToAddress1() As String
            Set(ByVal value As String)
                If _ShipToAddress1 <> value Then
                    _ShipToAddress1 = value
                End If
            End Set
            Get
                Return _ShipToAddress1
            End Get
        End Property
        Public Property ShipToAddress2() As String
            Set(ByVal value As String)
                If _ShipToAddress2 <> value Then
                    _ShipToAddress2 = value
                End If
            End Set
            Get
                Return _ShipToAddress2
            End Get
        End Property
        Public Property ShipToAddress3() As String
            Set(ByVal value As String)
                If _ShipToAddress3 <> value Then
                    _ShipToAddress3 = value
                End If
            End Set
            Get
                Return _ShipToAddress3
            End Get
        End Property
        Public Property ShipToAddress4() As String
            Set(ByVal value As String)
                If _ShipToAddress4 <> value Then
                    _ShipToAddress4 = value
                End If
            End Set
            Get
                Return _ShipToAddress4
            End Get
        End Property
        Public Property ShipToEmail() As String
            Set(ByVal value As String)
                If _ShipToEmail <> value Then
                    _ShipToEmail = value
                End If
            End Set
            Get
                Return _ShipToEmail
            End Get
        End Property
        Public Property ShipToPhone() As String
            Set(ByVal value As String)
                If _ShipToPhone <> value Then
                    _ShipToPhone = value
                End If
            End Set
            Get
                Return _ShipToPhone
            End Get
        End Property
        Public Property ShipToFax() As String
            Set(ByVal value As String)
                If _ShipToFax <> value Then
                    _ShipToFax = value
                End If
            End Set
            Get
                Return _ShipToFax
            End Get
        End Property
        Public Property ETD() As DateTime
            Set(ByVal value As DateTime)
                If _ETD <> value Then
                    _ETD = value
                End If
            End Set
            Get
                Return _ETD
            End Get
        End Property
        Public Property ETA() As DateTime
            Set(ByVal value As DateTime)
                If _ETA <> value Then
                    _ETA = value
                End If
            End Set
            Get
                Return _ETA
            End Get
        End Property
        Public Property RequiredDate() As DateTime
            Set(ByVal value As DateTime)
                If _RequiredDate <> value Then
                    _RequiredDate = value
                End If
            End Set
            Get
                Return _RequiredDate
            End Get
        End Property
        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _POLine = ""
            _PONo = ""
            _PartialPOFlag = ""
            _POCurrCode = ""
            _POAmt = 0
            _POIssueDate = ConDateTime.MinDate
            _POStatus = ""
            _PODescription = ""
            _IncoTerm = ""
            _IncoTermCity = ""
            _ModeOfTransport = ""
            _InvoiceNo = ""
            _SupplierName = ""
            _SupplierAddr1 = ""
            _SupplierAddr2 = ""
            _SupplierAddr3 = ""
            _SupplierAddr4 = ""
            _SupplierPhone = ""
            _SupplierFax = ""
            _SupplierCity = ""
            _SupplierCountry = ""
            _SupplierFirstName = ""
            _SupplierLastName = ""
            _CompanyName = ""
            _Address1 = ""
            _Address2 = ""
            _Address3 = ""
            _Address4 = ""
            _Phone = ""
            _Fax = ""
            _Email = ""
            _City = ""
            _Country = ""
            _ContactFirstName = ""
            _ContactLastName = ""
            _PoAmount = ""
            _SupplierPostalCode = ""
            _PostalCode = ""
            _FirstName = ""
            _LastName = ""
            _SupplierState = ""
            _State = ""
            _SupplierEmail = ""
            _deliveryDate = ConDateTime.MinDate
            _BusinessPartyCode = ""
            _ContactPerson = ""
            _PortOfLoadingCode = ""
            _PortOfDischargeCode = ""
            _ShipToName = ""
            _ShipToAddress1 = ""
            _ShipToAddress2 = ""
            _ShipToAddress3 = ""
            _ShipToAddress4 = ""
            _ShipToEmail = ""
            _ShipToPhone = ""
            _ShipToFax = ""
            _ETA = ConDateTime.MinDate
            _ETD = ConDateTime.MinDate
            _RequiredDate = ConDateTime.MinDate
        End Sub

    End Class

#End Region
End Namespace
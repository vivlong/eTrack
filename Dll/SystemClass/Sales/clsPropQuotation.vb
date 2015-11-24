Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of Quotation Info "

    <Serializable()> _
    Public Class clsPropQuotation
        Inherits clsProp
        Private _TrxNo As String = ""
        Private _AttachmentFlag As String = ""
        Private _CustomerCode As String = ""
        Private _QuoteNo As String = ""
        Private _CustomerAddress1 As String = ""
        Private _CustomerAddress2 As String = ""
        Private _CustomerAddress3 As String = ""
        Private _CustomerAddress4 As String = ""
        Private _CustomerContactName As String = ""
        Private _CustomerFax As String = ""
        Private _CustomerName As String = ""
        Private _CustomerTelephone As String = ""
        Private _DeliveryType As String = ""
        Private _EffectiveDate As String = ""
        Private _Email As String = ""
        Private _ExpiryDate As String = ""
        Private _Footer1 As String = ""
        Private _Footer2 As String = ""
        Private _Footer3 As String = ""
        Private _Footer4 As String = ""
        Private _Footer5 As String = ""
        Private _Header1 As String = ""
        Private _Header2 As String = ""
        Private _Header3 As String = ""
        Private _Header4 As String = ""
        Private _Header5 As String = ""
        Private _JobType As String = ""
        Private _LastQuoteDate As String = ""
        Private _LastQuoteNo As String = ""
        Private _QuoteApproveCode As String = ""
        Private _QuoteDate As String = ""
        Private _QuoteTitle As String = ""
        Private _QuoteType As String = ""
        Private _RefNo As String = ""
        Private _Remark As String = ""
        Private _RevisionDate As String = ""
        Private _RevisionNo As String = ""
        Private _SalesmanCode As String = ""
        Private _ShipmentType As String = ""
        Private _SpecialInstruction As String = ""
        Private _TermAndCondition As String = ""
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
        Private _ValidateDate As String = ""
        Private _ValidityDay As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _StatusCode As String = ""
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
        ' 
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
        Public Property QuoteNo() As String
            Set(ByVal value As String)
                If _QuoteNo <> value Then
                    _QuoteNo = value
                End If
            End Set
            Get
                Return _QuoteNo
            End Get
        End Property
        ' 
        Public Property CustomerAddress1() As String
            Set(ByVal value As String)
                If _CustomerAddress1 <> value Then
                    _CustomerAddress1 = value
                End If
            End Set
            Get
                Return _CustomerAddress1
            End Get
        End Property
        ' 
        Public Property CustomerAddress2() As String
            Set(ByVal value As String)
                If _CustomerAddress2 <> value Then
                    _CustomerAddress2 = value
                End If
            End Set
            Get
                Return _CustomerAddress2
            End Get
        End Property
        ' 
        Public Property CustomerAddress3() As String
            Set(ByVal value As String)
                If _CustomerAddress3 <> value Then
                    _CustomerAddress3 = value
                End If
            End Set
            Get
                Return _CustomerAddress3
            End Get
        End Property
        ' 
        Public Property CustomerAddress4() As String
            Set(ByVal value As String)
                If _CustomerAddress4 <> value Then
                    _CustomerAddress4 = value
                End If
            End Set
            Get
                Return _CustomerAddress4
            End Get
        End Property
        ' 
        Public Property CustomerContactName() As String
            Set(ByVal value As String)
                If _CustomerContactName <> value Then
                    _CustomerContactName = value
                End If
            End Set
            Get
                Return _CustomerContactName
            End Get
        End Property
        ' 
        Public Property CustomerFax() As String
            Set(ByVal value As String)
                If _CustomerFax <> value Then
                    _CustomerFax = value
                End If
            End Set
            Get
                Return _CustomerFax
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
        Public Property CustomerTelephone() As String
            Set(ByVal value As String)
                If _CustomerTelephone <> value Then
                    _CustomerTelephone = value
                End If
            End Set
            Get
                Return _CustomerTelephone
            End Get
        End Property
        ' 
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
        ' 
        Public Property EffectiveDate() As String
            Set(ByVal value As String)
                If _EffectiveDate <> value Then
                    _EffectiveDate = value
                End If
            End Set
            Get
                Return _EffectiveDate
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
        Public Property ExpiryDate() As String
            Set(ByVal value As String)
                If _ExpiryDate <> value Then
                    _ExpiryDate = value
                End If
            End Set
            Get
                Return _ExpiryDate
            End Get
        End Property
        ' 
        Public Property Footer1() As String
            Set(ByVal value As String)
                If _Footer1 <> value Then
                    _Footer1 = value
                End If
            End Set
            Get
                Return _Footer1
            End Get
        End Property
        ' 
        Public Property Footer2() As String
            Set(ByVal value As String)
                If _Footer2 <> value Then
                    _Footer2 = value
                End If
            End Set
            Get
                Return _Footer2
            End Get
        End Property
        ' 
        Public Property Footer3() As String
            Set(ByVal value As String)
                If _Footer3 <> value Then
                    _Footer3 = value
                End If
            End Set
            Get
                Return _Footer3
            End Get
        End Property
        ' 
        Public Property Footer4() As String
            Set(ByVal value As String)
                If _Footer4 <> value Then
                    _Footer4 = value
                End If
            End Set
            Get
                Return _Footer4
            End Get
        End Property
        ' 
        Public Property Footer5() As String
            Set(ByVal value As String)
                If _Footer5 <> value Then
                    _Footer5 = value
                End If
            End Set
            Get
                Return _Footer5
            End Get
        End Property
        ' 
        Public Property Header1() As String
            Set(ByVal value As String)
                If _Header1 <> value Then
                    _Header1 = value
                End If
            End Set
            Get
                Return _Header1
            End Get
        End Property
        ' 
        Public Property Header2() As String
            Set(ByVal value As String)
                If _Header2 <> value Then
                    _Header2 = value
                End If
            End Set
            Get
                Return _Header2
            End Get
        End Property
        ' 
        Public Property Header3() As String
            Set(ByVal value As String)
                If _Header3 <> value Then
                    _Header3 = value
                End If
            End Set
            Get
                Return _Header3
            End Get
        End Property
        ' 
        Public Property Header4() As String
            Set(ByVal value As String)
                If _Header4 <> value Then
                    _Header4 = value
                End If
            End Set
            Get
                Return _Header4
            End Get
        End Property
        ' 
        Public Property Header5() As String
            Set(ByVal value As String)
                If _Header5 <> value Then
                    _Header5 = value
                End If
            End Set
            Get
                Return _Header5
            End Get
        End Property
        ' 
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
        ' 
        Public Property LastQuoteDate() As String
            Set(ByVal value As String)
                If _LastQuoteDate <> value Then
                    _LastQuoteDate = value
                End If
            End Set
            Get
                Return _LastQuoteDate
            End Get
        End Property
        ' 
        Public Property LastQuoteNo() As String
            Set(ByVal value As String)
                If _LastQuoteNo <> value Then
                    _LastQuoteNo = value
                End If
            End Set
            Get
                Return _LastQuoteNo
            End Get
        End Property
        ' 
        Public Property QuoteApproveCode() As String
            Set(ByVal value As String)
                If _QuoteApproveCode <> value Then
                    _QuoteApproveCode = value
                End If
            End Set
            Get
                Return _QuoteApproveCode
            End Get
        End Property
        ' 
        Public Property QuoteDate() As String
            Set(ByVal value As String)
                If _QuoteDate <> value Then
                    _QuoteDate = value
                End If
            End Set
            Get
                Return _QuoteDate
            End Get
        End Property
        ' 
        Public Property QuoteTitle() As String
            Set(ByVal value As String)
                If _QuoteTitle <> value Then
                    _QuoteTitle = value
                End If
            End Set
            Get
                Return _QuoteTitle
            End Get
        End Property
        ' 
        Public Property QuoteType() As String
            Set(ByVal value As String)
                If _QuoteType <> value Then
                    _QuoteType = value
                End If
            End Set
            Get
                Return _QuoteType
            End Get
        End Property
        ' 
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
        Public Property RevisionDate() As String
            Set(ByVal value As String)
                If _RevisionDate <> value Then
                    _RevisionDate = value
                End If
            End Set
            Get
                Return _RevisionDate
            End Get
        End Property
        ' 
        Public Property RevisionNo() As String
            Set(ByVal value As String)
                If _RevisionNo <> value Then
                    _RevisionNo = value
                End If
            End Set
            Get
                Return _RevisionNo
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
        Public Property ShipmentType() As String
            Set(ByVal value As String)
                If _ShipmentType <> value Then
                    _ShipmentType = value
                End If
            End Set
            Get
                Return _ShipmentType
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
        Public Property TermAndCondition() As String
            Set(ByVal value As String)
                If _TermAndCondition <> value Then
                    _TermAndCondition = value
                End If
            End Set
            Get
                Return _TermAndCondition
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
        Public Property ValidateDate() As String
            Set(ByVal value As String)
                If _ValidateDate <> value Then
                    _ValidateDate = value
                End If
            End Set
            Get
                Return _ValidateDate
            End Get
        End Property
        ' 
        Public Property ValidityDay() As String
            Set(ByVal value As String)
                If _ValidityDay <> value Then
                    _ValidityDay = value
                End If
            End Set
            Get
                Return _ValidityDay
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


        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _TrxNo = ""
            _AttachmentFlag = ""
            _CustomerCode = ""
            _QuoteNo = ""
            _CustomerAddress1 = ""
            _CustomerAddress2 = ""
            _CustomerAddress3 = ""
            _CustomerAddress4 = ""
            _CustomerContactName = ""
            _CustomerFax = ""
            _CustomerName = ""
            _CustomerTelephone = ""
            _DeliveryType = ""
            _EffectiveDate = ""
            _Email = ""
            _ExpiryDate = ""
            _Footer1 = ""
            _Footer2 = ""
            _Footer3 = ""
            _Footer4 = ""
            _Footer5 = ""
            _Header1 = ""
            _Header2 = ""
            _Header3 = ""
            _Header4 = ""
            _Header5 = ""
            _JobType = ""
            _LastQuoteDate = ""
            _LastQuoteNo = ""
            _QuoteApproveCode = ""
            _QuoteDate = ""
            _QuoteTitle = ""
            _QuoteType = ""
            _RefNo = ""
            _Remark = ""
            _RevisionDate = ""
            _RevisionNo = ""
            _SalesmanCode = ""
            _ShipmentType = ""
            _SpecialInstruction = ""
            _TermAndCondition = ""
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
            _ValidateDate = ""
            _ValidityDay = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _StatusCode = ""
        End Sub

    End Class

#End Region
End Namespace
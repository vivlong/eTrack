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
    Public Class clsPropLineItemPO
        Inherits clsProp
        Private _TrxNo As Integer
        Private _POLine As String = ""
        Private _LineItemNo As String = ""
        Private _HazardousFlag As String = ""
        Private _PartNo As String = ""
        Private _PartDesc As String = ""
        Private _HarmonizeCode As String = ""
        Private _HarmonizeDesc As String = ""
        Private _UnitPrice As Decimal
        Private _CurrCode As String = ""
        Private _SupplierPartNo As String = ""
        Private _QtyOrdered As String = ""
        Private _QtyUOM As String = ""
        Private _QtyShipped As String = ""
        Private _NetWeight As Decimal
        Private _GrossWeight As Decimal
        Private _TagNo As String = ""
        Private _InsuranceValue As Decimal
        Private _DateRequested As DateTime
        Private _LatestDeliveryDate As DateTime
        Private _DateRequestedAtSite As DateTime
        Private _TimeOfArrival As DateTime
        Private _ShippingStatus As String = ""
        Private _ModeofTransport As String = ""
        Private _UOM As String = ""
        Private _Length As Decimal
        Private _Width As Decimal
        Private _Height As Decimal
        Private _Weight As Decimal
        Private _WeightMeasurement As String = ""
        Private _LineItemComments As String = ""
        Private _ItemTotalAmt As Decimal
        Private _ItemTotalAmtToStr As String = ""
        Private _Multiplications As Decimal
        Private _Sum As Decimal

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
        Public Property LineItemNo() As String
            Set(ByVal value As String)
                If _LineItemNo <> value Then
                    _LineItemNo = value
                End If
            End Set
            Get
                Return _LineItemNo
            End Get
        End Property
        ' 
        Public Property HazardousFlag() As String
            Set(ByVal value As String)
                If _HazardousFlag <> value Then
                    _HazardousFlag = value
                End If
            End Set
            Get
                Return _HazardousFlag
            End Get
        End Property
        ' 
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
        ' 
        Public Property PartDesc() As String
            Set(ByVal value As String)
                If _PartDesc <> value Then
                    _PartDesc = value
                End If
            End Set
            Get
                Return _PartDesc
            End Get
        End Property
        ' 
        Public Property HarmonizeCode() As String
            Set(ByVal value As String)
                If _HarmonizeCode <> value Then
                    _HarmonizeCode = value
                End If
            End Set
            Get
                Return _HarmonizeCode
            End Get
        End Property
        ' 
        Public Property HarmonizeDesc() As String
            Set(ByVal value As String)
                If _HarmonizeDesc <> value Then
                    _HarmonizeDesc = value
                End If
            End Set
            Get
                Return _HarmonizeDesc
            End Get
        End Property
        ' 
        Public Property UnitPrice() As Decimal
            Set(ByVal value As Decimal)
                If _UnitPrice <> value Then
                    _UnitPrice = value
                End If
            End Set
            Get
                Return _UnitPrice
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
        Public Property SupplierPartNo() As String
            Set(ByVal value As String)
                If _SupplierPartNo <> value Then
                    _SupplierPartNo = value
                End If
            End Set
            Get
                Return _SupplierPartNo
            End Get
        End Property
        ' 
        Public Property QtyOrdered() As String
            Set(ByVal value As String)
                If _QtyOrdered <> value Then
                    _QtyOrdered = value
                End If
            End Set
            Get
                Return _QtyOrdered
            End Get
        End Property
        ' 
        Public Property QtyUOM() As String
            Set(ByVal value As String)
                If _QtyUOM <> value Then
                    _QtyUOM = value
                End If
            End Set
            Get
                Return _QtyUOM
            End Get
        End Property
        ' 
        Public Property NetWeight() As Decimal
            Set(ByVal value As Decimal)
                If _NetWeight <> value Then
                    _NetWeight = value
                End If
            End Set
            Get
                Return _NetWeight
            End Get
        End Property
        ' 
        Public Property GrossWeight() As Decimal
            Set(ByVal value As Decimal)
                If _GrossWeight <> value Then
                    _GrossWeight = value
                End If
            End Set
            Get
                Return _GrossWeight
            End Get
        End Property
        ' 
        Public Property TagNo() As String
            Set(ByVal value As String)
                If _TagNo <> value Then
                    _TagNo = value
                End If
            End Set
            Get
                Return _TagNo
            End Get
        End Property
        ' 
        Public Property InsuranceValue() As Decimal
            Set(ByVal value As Decimal)
                If _InsuranceValue <> value Then
                    _InsuranceValue = value
                End If
            End Set
            Get
                Return _InsuranceValue
            End Get
        End Property
        ' 
        Public Property DateRequested() As DateTime
            Set(ByVal value As DateTime)
                If _DateRequested <> value Then
                    _DateRequested = value
                End If
            End Set
            Get
                Return _DateRequested
            End Get
        End Property
        ' 
        Public Property DateRequestedAtSite() As DateTime
            Set(ByVal value As DateTime)
                If _DateRequestedAtSite <> value Then
                    _DateRequestedAtSite = value
                End If
            End Set
            Get
                Return _DateRequestedAtSite
            End Get
        End Property

        Public Property TimeOfArrival() As DateTime
            Set(ByVal value As DateTime)
                If _TimeOfArrival <> value Then
                    _TimeOfArrival = value
                End If
            End Set
            Get
                Return _TimeOfArrival
            End Get
        End Property

        Public Property LatestDeliveryDate() As DateTime
            Set(ByVal value As DateTime)
                If _LatestDeliveryDate <> value Then
                    _LatestDeliveryDate = value
                End If
            End Set
            Get
                Return _LatestDeliveryDate
            End Get
        End Property

        ' 
        Public Property ShippingStatus() As String
            Set(ByVal value As String)
                If _ShippingStatus <> value Then
                    _ShippingStatus = value
                End If
            End Set
            Get
                Return _ShippingStatus
            End Get
        End Property
        ' 
        Public Property ModeofTransport() As String
            Set(ByVal value As String)
                If _ModeofTransport <> value Then
                    _ModeofTransport = value
                End If
            End Set
            Get
                Return _ModeofTransport
            End Get
        End Property
        ' 
        Public Property UOM() As String
            Set(ByVal value As String)
                If _UOM <> value Then
                    _UOM = value
                End If
            End Set
            Get
                Return _UOM
            End Get
        End Property
        ' 
        Public Property Length() As Decimal
            Set(ByVal value As Decimal)
                If _Length <> value Then
                    _Length = value
                End If
            End Set
            Get
                Return _Length
            End Get
        End Property
        ' 
        Public Property Width() As Decimal
            Set(ByVal value As Decimal)
                If _Width <> value Then
                    _Width = value
                End If
            End Set
            Get
                Return _Width
            End Get
        End Property
        ' 
        Public Property Height() As Decimal
            Set(ByVal value As Decimal)
                If _Height <> value Then
                    _Height = value
                End If
            End Set
            Get
                Return _Height
            End Get
        End Property
        ' 
        Public Property Weight() As Decimal
            Set(ByVal value As Decimal)
                If _Weight <> value Then
                    _Weight = value
                End If
            End Set
            Get
                Return _Weight
            End Get
        End Property
        ' 
        Public Property WeightMeasurement() As String
            Set(ByVal value As String)
                If _WeightMeasurement <> value Then
                    _WeightMeasurement = value
                End If
            End Set
            Get
                Return _WeightMeasurement
            End Get
        End Property
        ' 
        Public Property LineItemComments() As String
            Set(ByVal value As String)
                If _LineItemComments <> value Then
                    _LineItemComments = value
                End If
            End Set
            Get
                Return _LineItemComments
            End Get
        End Property
        ' 
        Public Property ItemTotalAmt() As Decimal
            Set(ByVal value As Decimal)
                If _ItemTotalAmt <> value Then
                    _ItemTotalAmt = value
                End If
            End Set
            Get
                Return _ItemTotalAmt
            End Get
        End Property

        Public Property ItemTotalAmtToStr() As String
            Set(ByVal value As String)
                If _ItemTotalAmtToStr <> value Then
                    _ItemTotalAmtToStr = value
                End If
            End Set
            Get
                Return _ItemTotalAmtToStr
            End Get
        End Property

        Public Property QtyShipped() As String
            Set(ByVal value As String)
                If _QtyShipped <> value Then
                    _QtyShipped = value
                End If
            End Set
            Get
                Return _QtyShipped
            End Get
        End Property
        Public Property Multiplications() As Decimal
            Set(ByVal value As Decimal)
                If _Multiplications <> value Then
                    _Multiplications = value
                End If
            End Set
            Get
                Return _Multiplications
            End Get
        End Property
        Public Property Sum() As Decimal
            Set(ByVal value As Decimal)
                If _Sum <> value Then
                    _Sum = value
                End If
            End Set
            Get
                Return _Sum
            End Get
        End Property
        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = 0
            _POLine = ""
            _LineItemNo = ""
            _HazardousFlag = ""
            _PartNo = ""
            _PartDesc = ""
            _HarmonizeCode = ""
            _HarmonizeDesc = ""
            _UnitPrice = 0
            _CurrCode = ""
            _SupplierPartNo = ""
            _QtyOrdered = ""
            _QtyUOM = ""
            _NetWeight = 0
            _GrossWeight = 0
            _TagNo = ""
            _InsuranceValue = 0
            _DateRequested = ConDateTime.MinDate
            _LatestDeliveryDate = ConDateTime.MinDate
            _DateRequestedAtSite = ConDateTime.MinDate
            _TimeOfArrival = ConDateTime.MinDate
            _ShippingStatus = ""
            _ModeofTransport = ""
            _UOM = ""
            _Length = 0
            _Width = 0
            _Height = 0
            _Weight = 0
            _WeightMeasurement = ""
            _LineItemComments = ""
            _ItemTotalAmt = 0
            _ItemTotalAmtToStr = ""
            _QtyShipped = ""
            _Multiplications = 0
            _Sum = 0
        End Sub

    End Class

#End Region
End Namespace
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class of Property WMS "

    <Serializable()> _
    Public Class clsPropWMS
        Inherits clsProp
        Private _TrxNo As String = ""
        Private _TrxType As String = ""
        Private _MovementDate As DateTime
        Private _CustomerCode As String = ""
        Private _CustomerName As String = ""
        Private _GoodsReceiveorIssueNo As String = ""
        Private _ProductCode As String = ""
        Private _BatchNo As String = ""
        Private _BatchLineItemNo As String = ""
        Private _LotNo As String = ""
        Private _WarehouseCode As String = ""
        Private _FromToWarehouseCode As String = ""
        Private _StoreNo As String = ""
        Private _FromToStoreNo As String = ""
        Private _Location As String = ""
        Private _FromToLocation As String = ""
        Private _UomCode As String = ""
        Private _PackingQty As String = ""
        Private _WholeQty As String = ""
        Private _LooseQty As String = ""
        Private _BalanceLooseQty As String = ""
        Private _BalancePackingQty As String = ""
        Private _BalanceWholeQty As String = ""
        Private _BalanceSpaceArea As String = ""
        Private _BalanceVolume As String = ""
        Private _BalanceWeight As String = ""
        Private _BillingStartDate As String = ""
        Private _Volume As String = ""
        Private _Weight As String = ""
        Private _SpaceArea As String = ""
        Private _NoteLineItemNo As String = ""
        Private _PermitNo As String = ""
        Private _RateClassCode As String = ""
        Private _ReceiptDate As String = ""
        Private _PartNoTrxNo As String = ""
        Private _BrandName As String = ""
        Private _ProductTrxNo As String = ""
        Private _RefNo As String = ""
        Private _UserDefine1 As String = ""
        Private _UserDefine2 As String = ""
        Private _UserDefine3 As String = ""
        Private _UserDefine4 As String = ""
        Private _Description As String = ""
        Private _GoodsDescription As String = ""
        Private _MarkNo As String = ""
        Private _ProductName As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _StatusCode As String = ""
        Private _WorkStation As String = ""
        Private _LastBillDate As String = ""
        Private _UnitPrice As String = ""
        Private _UnitVol As String = ""
        Private _UnitWt As String = ""
        Private _SerialNo As String = ""
        Private _BillableFlag As String = ""
        Private _PackQty As String = ""
        Private _StockIn As String = ""
        Private _StockOut As String = ""
        Private _Balance As String = ""
        ' 090422
        Private _Opening As String = ""
        Private _MawbOblNo As String = ""
        Private _UserDefine01 As String = ""

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
        Public Property TrxType() As String
            Set(ByVal value As String)
                If _TrxType <> value Then
                    _TrxType = value
                End If
            End Set
            Get
                Return _TrxType
            End Get
        End Property
        ' 
        Public Property MovementDate() As DateTime
            Set(ByVal value As DateTime)
                _MovementDate = value
            End Set
            Get
                Return _MovementDate
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
        Public Property GoodsReceiveorIssueNo() As String
            Set(ByVal value As String)
                If _GoodsReceiveorIssueNo <> value Then
                    _GoodsReceiveorIssueNo = value
                End If
            End Set
            Get
                Return _GoodsReceiveorIssueNo
            End Get
        End Property
        ' 
        Public Property ProductCode() As String
            Set(ByVal value As String)
                If _ProductCode <> value Then
                    _ProductCode = value
                End If
            End Set
            Get
                Return _ProductCode
            End Get
        End Property
        ' 
        Public Property BatchNo() As String
            Set(ByVal value As String)
                If _BatchNo <> value Then
                    _BatchNo = value
                End If
            End Set
            Get
                Return _BatchNo
            End Get
        End Property
        ' 
        Public Property BatchLineItemNo() As String
            Set(ByVal value As String)
                If _BatchLineItemNo <> value Then
                    _BatchLineItemNo = value
                End If
            End Set
            Get
                Return _BatchLineItemNo
            End Get
        End Property
        ' 
        Public Property LotNo() As String
            Set(ByVal value As String)
                If _LotNo <> value Then
                    _LotNo = value
                End If
            End Set
            Get
                Return _LotNo
            End Get
        End Property
        ' 
        Public Property WarehouseCode() As String
            Set(ByVal value As String)
                If _WarehouseCode <> value Then
                    _WarehouseCode = value
                End If
            End Set
            Get
                Return _WarehouseCode
            End Get
        End Property
        ' 
        Public Property FromToWarehouseCode() As String
            Set(ByVal value As String)
                If _FromToWarehouseCode <> value Then
                    _FromToWarehouseCode = value
                End If
            End Set
            Get
                Return _FromToWarehouseCode
            End Get
        End Property
        ' 
        Public Property StoreNo() As String
            Set(ByVal value As String)
                If _StoreNo <> value Then
                    _StoreNo = value
                End If
            End Set
            Get
                Return _StoreNo
            End Get
        End Property
        ' 
        Public Property FromToStoreNo() As String
            Set(ByVal value As String)
                If _FromToStoreNo <> value Then
                    _FromToStoreNo = value
                End If
            End Set
            Get
                Return _FromToStoreNo
            End Get
        End Property
        ' 
        Public Property Location() As String
            Set(ByVal value As String)
                If _Location <> value Then
                    _Location = value
                End If
            End Set
            Get
                Return _Location
            End Get
        End Property
        ' 
        Public Property FromToLocation() As String
            Set(ByVal value As String)
                If _FromToLocation <> value Then
                    _FromToLocation = value
                End If
            End Set
            Get
                Return _FromToLocation
            End Get
        End Property
        ' 
        Public Property UomCode() As String
            Set(ByVal value As String)
                If _UomCode <> value Then
                    _UomCode = value
                End If
            End Set
            Get
                Return _UomCode
            End Get
        End Property
        ' 
        Public Property PackingQty() As String
            Set(ByVal value As String)
                If _PackingQty <> value Then
                    _PackingQty = value
                End If
            End Set
            Get
                Return _PackingQty
            End Get
        End Property
        ' 
        Public Property WholeQty() As String
            Set(ByVal value As String)
                If _WholeQty <> value Then
                    _WholeQty = value
                End If
            End Set
            Get
                Return _WholeQty
            End Get
        End Property
        ' 
        Public Property LooseQty() As String
            Set(ByVal value As String)
                If _LooseQty <> value Then
                    _LooseQty = value
                End If
            End Set
            Get
                Return _LooseQty
            End Get
        End Property
        ' 
        Public Property BalanceLooseQty() As String
            Set(ByVal value As String)
                If _BalanceLooseQty <> value Then
                    _BalanceLooseQty = value
                End If
            End Set
            Get
                Return _BalanceLooseQty
            End Get
        End Property
        ' 
        Public Property BalancePackingQty() As String
            Set(ByVal value As String)
                If _BalancePackingQty <> value Then
                    _BalancePackingQty = value
                End If
            End Set
            Get
                Return _BalancePackingQty
            End Get
        End Property
        ' 
        Public Property BalanceWholeQty() As String
            Set(ByVal value As String)
                If _BalanceWholeQty <> value Then
                    _BalanceWholeQty = value
                End If
            End Set
            Get
                Return _BalanceWholeQty
            End Get
        End Property
        ' 
        Public Property BalanceSpaceArea() As String
            Set(ByVal value As String)
                If _BalanceSpaceArea <> value Then
                    _BalanceSpaceArea = value
                End If
            End Set
            Get
                Return _BalanceSpaceArea
            End Get
        End Property
        ' 
        Public Property BalanceVolume() As String
            Set(ByVal value As String)
                If _BalanceVolume <> value Then
                    _BalanceVolume = value
                End If
            End Set
            Get
                Return _BalanceVolume
            End Get
        End Property
        ' 
        Public Property BalanceWeight() As String
            Set(ByVal value As String)
                If _BalanceWeight <> value Then
                    _BalanceWeight = value
                End If
            End Set
            Get
                Return _BalanceWeight
            End Get
        End Property
        ' 
        Public Property BillingStartDate() As String
            Set(ByVal value As String)
                If _BillingStartDate <> value Then
                    _BillingStartDate = value
                End If
            End Set
            Get
                Return _BillingStartDate
            End Get
        End Property
        ' 
        Public Property Volume() As String
            Set(ByVal value As String)
                If _Volume <> value Then
                    _Volume = value
                End If
            End Set
            Get
                Return _Volume
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
        ' 
        Public Property SpaceArea() As String
            Set(ByVal value As String)
                If _SpaceArea <> value Then
                    _SpaceArea = value
                End If
            End Set
            Get
                Return _SpaceArea
            End Get
        End Property
        ' 
        Public Property NoteLineItemNo() As String
            Set(ByVal value As String)
                If _NoteLineItemNo <> value Then
                    _NoteLineItemNo = value
                End If
            End Set
            Get
                Return _NoteLineItemNo
            End Get
        End Property
        ' 
        Public Property PermitNo() As String
            Set(ByVal value As String)
                If _PermitNo <> value Then
                    _PermitNo = value
                End If
            End Set
            Get
                Return _PermitNo
            End Get
        End Property
        ' 
        Public Property RateClassCode() As String
            Set(ByVal value As String)
                If _RateClassCode <> value Then
                    _RateClassCode = value
                End If
            End Set
            Get
                Return _RateClassCode
            End Get
        End Property
        ' 
        Public Property ReceiptDate() As String
            Set(ByVal value As String)
                If _ReceiptDate <> value Then
                    _ReceiptDate = value
                End If
            End Set
            Get
                Return _ReceiptDate
            End Get
        End Property
        ' 
        Public Property PartNoTrxNo() As String
            Set(ByVal value As String)
                If _PartNoTrxNo <> value Then
                    _PartNoTrxNo = value
                End If
            End Set
            Get
                Return _PartNoTrxNo
            End Get
        End Property
        ' 
        Public Property BrandName() As String
            Set(ByVal value As String)
                If _BrandName <> value Then
                    _BrandName = value
                End If
            End Set
            Get
                Return _BrandName
            End Get
        End Property
        ' 
        Public Property ProductTrxNo() As String
            Set(ByVal value As String)
                If _ProductTrxNo <> value Then
                    _ProductTrxNo = value
                End If
            End Set
            Get
                Return _ProductTrxNo
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
        Public Property UserDefine1() As String
            Set(ByVal value As String)
                If _UserDefine1 <> value Then
                    _UserDefine1 = value
                End If
            End Set
            Get
                Return _UserDefine1
            End Get
        End Property
        ' 
        Public Property UserDefine2() As String
            Set(ByVal value As String)
                If _UserDefine2 <> value Then
                    _UserDefine2 = value
                End If
            End Set
            Get
                Return _UserDefine2
            End Get
        End Property
        ' 
        Public Property UserDefine3() As String
            Set(ByVal value As String)
                If _UserDefine3 <> value Then
                    _UserDefine3 = value
                End If
            End Set
            Get
                Return _UserDefine3
            End Get
        End Property
        ' 
        Public Property UserDefine4() As String
            Set(ByVal value As String)
                If _UserDefine4 <> value Then
                    _UserDefine4 = value
                End If
            End Set
            Get
                Return _UserDefine4
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
        Public Property GoodsDescription() As String
            Set(ByVal value As String)
                If _GoodsDescription <> value Then
                    _GoodsDescription = value
                End If
            End Set
            Get
                Return _GoodsDescription
            End Get
        End Property
        ' 
        Public Property MarkNo() As String
            Set(ByVal value As String)
                If _MarkNo <> value Then
                    _MarkNo = value
                End If
            End Set
            Get
                Return _MarkNo
            End Get
        End Property
        ' 
        Public Property ProductName() As String
            Set(ByVal value As String)
                If _ProductName <> value Then
                    _ProductName = value
                End If
            End Set
            Get
                Return _ProductName
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
        Public Property WorkStation() As String
            Set(ByVal value As String)
                If _WorkStation <> value Then
                    _WorkStation = value
                End If
            End Set
            Get
                Return _WorkStation
            End Get
        End Property
        ' 
        Public Property LastBillDate() As String
            Set(ByVal value As String)
                If _LastBillDate <> value Then
                    _LastBillDate = value
                End If
            End Set
            Get
                Return _LastBillDate
            End Get
        End Property
        ' 
        Public Property UnitPrice() As String
            Set(ByVal value As String)
                If _UnitPrice <> value Then
                    _UnitPrice = value
                End If
            End Set
            Get
                Return _UnitPrice
            End Get
        End Property
        ' 
        Public Property UnitVol() As String
            Set(ByVal value As String)
                If _UnitVol <> value Then
                    _UnitVol = value
                End If
            End Set
            Get
                Return _UnitVol
            End Get
        End Property
        ' 
        Public Property UnitWt() As String
            Set(ByVal value As String)
                If _UnitWt <> value Then
                    _UnitWt = value
                End If
            End Set
            Get
                Return _UnitWt
            End Get
        End Property
        ' 
        Public Property SerialNo() As String
            Set(ByVal value As String)
                If _SerialNo <> value Then
                    _SerialNo = value
                End If
            End Set
            Get
                Return _SerialNo
            End Get
        End Property
        Public Property BillableFlag() As String
            Set(ByVal value As String)
                If _BillableFlag <> value Then
                    _BillableFlag = value
                End If
            End Set
            Get
                Return _BillableFlag
            End Get
        End Property
        Public Property PackQty() As String
            Set(ByVal value As String)
                If _PackQty <> value Then
                    _PackQty = value
                End If
            End Set
            Get
                Return _PackQty
            End Get
        End Property



        Public Property StockIn() As String
            Set(ByVal value As String)
                If _StockIn <> value Then
                    _StockIn = value
                End If
            End Set
            Get
                Return _StockIn
            End Get
        End Property

        Public Property StockOut() As String
            Set(ByVal value As String)
                If _StockOut <> value Then
                    _StockOut = value
                End If
            End Set
            Get
                Return _StockOut
            End Get
        End Property


        Public Property Balance() As String
            Set(ByVal value As String)
                If _Balance <> value Then
                    _Balance = value
                End If
            End Set
            Get
                Return _Balance
            End Get
        End Property

        Public Property Opening() As String
            Set(ByVal value As String)
                If _Opening <> value Then
                    _Opening = value
                End If
            End Set
            Get
                Return _Opening
            End Get
        End Property

        Public Property MawbOblNo() As String
            Set(ByVal value As String)
                If _MawbOblNo <> value Then
                    _MawbOblNo = value
                End If
            End Set
            Get
                Return _MawbOblNo
            End Get
        End Property

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

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = ""
            _TrxType = ""
            _MovementDate = ConDateTime.MinDate
            _CustomerCode = ""
            _CustomerName = ""
            _GoodsReceiveorIssueNo = ""
            _ProductCode = ""
            _BatchNo = ""
            _BatchLineItemNo = ""
            _LotNo = ""
            _WarehouseCode = ""
            _FromToWarehouseCode = ""
            _StoreNo = ""
            _FromToStoreNo = ""
            _Location = ""
            _FromToLocation = ""
            _UomCode = ""
            _PackingQty = ""
            _WholeQty = ""
            _LooseQty = ""
            _BalanceLooseQty = ""
            _BalancePackingQty = ""
            _BalanceWholeQty = ""
            _BalanceSpaceArea = ""
            _BalanceVolume = ""
            _BalanceWeight = ""
            _BillingStartDate = ""
            _Volume = ""
            _Weight = ""
            _SpaceArea = ""
            _NoteLineItemNo = ""
            _PermitNo = ""
            _RateClassCode = ""
            _ReceiptDate = ""
            _PartNoTrxNo = ""
            _BrandName = ""
            _ProductTrxNo = ""
            _RefNo = ""
            _UserDefine1 = ""
            _UserDefine2 = ""
            _UserDefine3 = ""
            _UserDefine4 = ""
            _Description = ""
            _GoodsDescription = ""
            _MarkNo = ""
            _ProductName = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _StatusCode = ""
            _WorkStation = ""
            _LastBillDate = ""
            _UnitPrice = ""
            _UnitVol = ""
            _UnitWt = ""
            _SerialNo = ""
            _BillableFlag = ""
            _StockIn = ""
            _StockOut = ""
            _Balance = ""
            '090422
            _Opening = ""
            _MawbOblNo = ""
            _UserDefine01 = ""
        End Sub

    End Class

#End Region
End Namespace

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports SysMagic.ZZSystem

'Author£ºZhiWei
'ModuleName£ºsebl2
'DateTime£º2010-5-13 17:24:28
Namespace SystemClass

    Public Class clsPropSebl2_BL
        Inherits clsProp
        Private _TrxNo As Integer
        Private _LineItemNo As Integer
        Private _BlNo As String = ""
        Private _ContainerNo As String = ""
        Private _ContainerType As String = ""
        Private _ChargeWeight As Decimal
        Private _GoodsDescription01 As String = ""
        Private _GoodsDescription02 As String = ""
        Private _GoodsDescription03 As String = ""
        Private _GoodsDescription04 As String = ""
        Private _GoodsDescription05 As String = ""
        Private _GoodsDescription06 As String = ""
        Private _GoodsDescription07 As String = ""
        Private _GoodsDescription08 As String = ""
        Private _GoodsDescription09 As String = ""
        Private _GoodsDescription10 As String = ""
        Private _GoodsDescription11 As String = ""
        Private _GoodsDescription12 As String = ""
        Private _GoodsDescription13 As String = ""
        Private _GoodsDescription14 As String = ""
        Private _GoodsDescription15 As String = ""
        Private _GoodsDescription16 As String = ""
        Private _GoodsDescription17 As String = ""
        Private _GoodsDescription18 As String = ""
        Private _GoodsDescription19 As String = ""
        Private _GoodsDescription20 As String = ""
        Private _GrossWeight As Decimal
        Private _MarkNo01 As String = ""
        Private _MarkNo02 As String = ""
        Private _MarkNo03 As String = ""
        Private _MarkNo04 As String = ""
        Private _MarkNo05 As String = ""
        Private _MarkNo06 As String = ""
        Private _MarkNo07 As String = ""
        Private _MarkNo08 As String = ""
        Private _MarkNo09 As String = ""
        Private _MarkNo10 As String = ""
        Private _MarkNo11 As String = ""
        Private _MarkNo12 As String = ""
        Private _MarkNo13 As String = ""
        Private _MarkNo14 As String = ""
        Private _MarkNo15 As String = ""
        Private _MarkNo16 As String = ""
        Private _MarkNo17 As String = ""
        Private _MarkNo18 As String = ""
        Private _MarkNo19 As String = ""
        Private _MarkNo20 As String = ""
        Private _MeasurementType As String = ""
        Private _NetWeight As Decimal
        Private _Pcs As Integer
        Private _Remark As String = ""
        Private _RequiredDateTime As DateTime
        Private _SealNo As String = ""
        Private _TrxDate As DateTime
        Private _UomCode As String = ""
        Private _Volume As Decimal
        Private _NumberPlate As String = ""
        Private _Make As String = ""
        Private _Model As String = ""
        Private _Colour As String = ""
        Private _ChassisNo As String = ""
        Private _EngineNo As String = ""
        Private _FOBNo As String = ""
        Private _TowDate As DateTime
        Private _Location As String = ""
        Private _Submitter As String = ""
        Private _NricNo As String = ""
        Private _CargoStatusCode As String = ""
#Region " Class Property of CargoStatusCode"

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

        Public Property LineItemNo() As Integer
            Set(ByVal value As Integer)
                If _LineItemNo <> value Then
                    _LineItemNo = value
                End If
            End Set
            Get
                Return _LineItemNo
            End Get
        End Property

        Public Property BlNo() As String
            Set(ByVal value As String)
                If _BlNo <> value Then
                    _BlNo = value
                End If
            End Set
            Get
                Return _BlNo
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

        Public Property ContainerType() As String
            Set(ByVal value As String)
                If _ContainerType <> value Then
                    _ContainerType = value
                End If
            End Set
            Get
                Return _ContainerType
            End Get
        End Property

        Public Property ChargeWeight() As Decimal
            Set(ByVal value As Decimal)
                If _ChargeWeight <> value Then
                    _ChargeWeight = value
                End If
            End Set
            Get
                Return _ChargeWeight
            End Get
        End Property

        Public Property GoodsDescription01() As String
            Set(ByVal value As String)
                If _GoodsDescription01 <> value Then
                    _GoodsDescription01 = value
                End If
            End Set
            Get
                Return _GoodsDescription01
            End Get
        End Property

        Public Property GoodsDescription02() As String
            Set(ByVal value As String)
                If _GoodsDescription02 <> value Then
                    _GoodsDescription02 = value
                End If
            End Set
            Get
                Return _GoodsDescription02
            End Get
        End Property

        Public Property GoodsDescription03() As String
            Set(ByVal value As String)
                If _GoodsDescription03 <> value Then
                    _GoodsDescription03 = value
                End If
            End Set
            Get
                Return _GoodsDescription03
            End Get
        End Property

        Public Property GoodsDescription04() As String
            Set(ByVal value As String)
                If _GoodsDescription04 <> value Then
                    _GoodsDescription04 = value
                End If
            End Set
            Get
                Return _GoodsDescription04
            End Get
        End Property

        Public Property GoodsDescription05() As String
            Set(ByVal value As String)
                If _GoodsDescription05 <> value Then
                    _GoodsDescription05 = value
                End If
            End Set
            Get
                Return _GoodsDescription05
            End Get
        End Property

        Public Property GoodsDescription06() As String
            Set(ByVal value As String)
                If _GoodsDescription06 <> value Then
                    _GoodsDescription06 = value
                End If
            End Set
            Get
                Return _GoodsDescription06
            End Get
        End Property

        Public Property GoodsDescription07() As String
            Set(ByVal value As String)
                If _GoodsDescription07 <> value Then
                    _GoodsDescription07 = value
                End If
            End Set
            Get
                Return _GoodsDescription07
            End Get
        End Property

        Public Property GoodsDescription08() As String
            Set(ByVal value As String)
                If _GoodsDescription08 <> value Then
                    _GoodsDescription08 = value
                End If
            End Set
            Get
                Return _GoodsDescription08
            End Get
        End Property

        Public Property GoodsDescription09() As String
            Set(ByVal value As String)
                If _GoodsDescription09 <> value Then
                    _GoodsDescription09 = value
                End If
            End Set
            Get
                Return _GoodsDescription09
            End Get
        End Property

        Public Property GoodsDescription10() As String
            Set(ByVal value As String)
                If _GoodsDescription10 <> value Then
                    _GoodsDescription10 = value
                End If
            End Set
            Get
                Return _GoodsDescription10
            End Get
        End Property

        Public Property GoodsDescription11() As String
            Set(ByVal value As String)
                If _GoodsDescription11 <> value Then
                    _GoodsDescription11 = value
                End If
            End Set
            Get
                Return _GoodsDescription11
            End Get
        End Property

        Public Property GoodsDescription12() As String
            Set(ByVal value As String)
                If _GoodsDescription12 <> value Then
                    _GoodsDescription12 = value
                End If
            End Set
            Get
                Return _GoodsDescription12
            End Get
        End Property

        Public Property GoodsDescription13() As String
            Set(ByVal value As String)
                If _GoodsDescription13 <> value Then
                    _GoodsDescription13 = value
                End If
            End Set
            Get
                Return _GoodsDescription13
            End Get
        End Property

        Public Property GoodsDescription14() As String
            Set(ByVal value As String)
                If _GoodsDescription14 <> value Then
                    _GoodsDescription14 = value
                End If
            End Set
            Get
                Return _GoodsDescription14
            End Get
        End Property

        Public Property GoodsDescription15() As String
            Set(ByVal value As String)
                If _GoodsDescription15 <> value Then
                    _GoodsDescription15 = value
                End If
            End Set
            Get
                Return _GoodsDescription15
            End Get
        End Property

        Public Property GoodsDescription16() As String
            Set(ByVal value As String)
                If _GoodsDescription16 <> value Then
                    _GoodsDescription16 = value
                End If
            End Set
            Get
                Return _GoodsDescription16
            End Get
        End Property

        Public Property GoodsDescription17() As String
            Set(ByVal value As String)
                If _GoodsDescription17 <> value Then
                    _GoodsDescription17 = value
                End If
            End Set
            Get
                Return _GoodsDescription17
            End Get
        End Property

        Public Property GoodsDescription18() As String
            Set(ByVal value As String)
                If _GoodsDescription18 <> value Then
                    _GoodsDescription18 = value
                End If
            End Set
            Get
                Return _GoodsDescription18
            End Get
        End Property

        Public Property GoodsDescription19() As String
            Set(ByVal value As String)
                If _GoodsDescription19 <> value Then
                    _GoodsDescription19 = value
                End If
            End Set
            Get
                Return _GoodsDescription19
            End Get
        End Property

        Public Property GoodsDescription20() As String
            Set(ByVal value As String)
                If _GoodsDescription20 <> value Then
                    _GoodsDescription20 = value
                End If
            End Set
            Get
                Return _GoodsDescription20
            End Get
        End Property

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

        Public Property MarkNo01() As String
            Set(ByVal value As String)
                If _MarkNo01 <> value Then
                    _MarkNo01 = value
                End If
            End Set
            Get
                Return _MarkNo01
            End Get
        End Property

        Public Property MarkNo02() As String
            Set(ByVal value As String)
                If _MarkNo02 <> value Then
                    _MarkNo02 = value
                End If
            End Set
            Get
                Return _MarkNo02
            End Get
        End Property

        Public Property MarkNo03() As String
            Set(ByVal value As String)
                If _MarkNo03 <> value Then
                    _MarkNo03 = value
                End If
            End Set
            Get
                Return _MarkNo03
            End Get
        End Property

        Public Property MarkNo04() As String
            Set(ByVal value As String)
                If _MarkNo04 <> value Then
                    _MarkNo04 = value
                End If
            End Set
            Get
                Return _MarkNo04
            End Get
        End Property

        Public Property MarkNo05() As String
            Set(ByVal value As String)
                If _MarkNo05 <> value Then
                    _MarkNo05 = value
                End If
            End Set
            Get
                Return _MarkNo05
            End Get
        End Property

        Public Property MarkNo06() As String
            Set(ByVal value As String)
                If _MarkNo06 <> value Then
                    _MarkNo06 = value
                End If
            End Set
            Get
                Return _MarkNo06
            End Get
        End Property

        Public Property MarkNo07() As String
            Set(ByVal value As String)
                If _MarkNo07 <> value Then
                    _MarkNo07 = value
                End If
            End Set
            Get
                Return _MarkNo07
            End Get
        End Property

        Public Property MarkNo08() As String
            Set(ByVal value As String)
                If _MarkNo08 <> value Then
                    _MarkNo08 = value
                End If
            End Set
            Get
                Return _MarkNo08
            End Get
        End Property

        Public Property MarkNo09() As String
            Set(ByVal value As String)
                If _MarkNo09 <> value Then
                    _MarkNo09 = value
                End If
            End Set
            Get
                Return _MarkNo09
            End Get
        End Property

        Public Property MarkNo10() As String
            Set(ByVal value As String)
                If _MarkNo10 <> value Then
                    _MarkNo10 = value
                End If
            End Set
            Get
                Return _MarkNo10
            End Get
        End Property

        Public Property MarkNo11() As String
            Set(ByVal value As String)
                If _MarkNo11 <> value Then
                    _MarkNo11 = value
                End If
            End Set
            Get
                Return _MarkNo11
            End Get
        End Property

        Public Property MarkNo12() As String
            Set(ByVal value As String)
                If _MarkNo12 <> value Then
                    _MarkNo12 = value
                End If
            End Set
            Get
                Return _MarkNo12
            End Get
        End Property

        Public Property MarkNo13() As String
            Set(ByVal value As String)
                If _MarkNo13 <> value Then
                    _MarkNo13 = value
                End If
            End Set
            Get
                Return _MarkNo13
            End Get
        End Property

        Public Property MarkNo14() As String
            Set(ByVal value As String)
                If _MarkNo14 <> value Then
                    _MarkNo14 = value
                End If
            End Set
            Get
                Return _MarkNo14
            End Get
        End Property

        Public Property MarkNo15() As String
            Set(ByVal value As String)
                If _MarkNo15 <> value Then
                    _MarkNo15 = value
                End If
            End Set
            Get
                Return _MarkNo15
            End Get
        End Property

        Public Property MarkNo16() As String
            Set(ByVal value As String)
                If _MarkNo16 <> value Then
                    _MarkNo16 = value
                End If
            End Set
            Get
                Return _MarkNo16
            End Get
        End Property

        Public Property MarkNo17() As String
            Set(ByVal value As String)
                If _MarkNo17 <> value Then
                    _MarkNo17 = value
                End If
            End Set
            Get
                Return _MarkNo17
            End Get
        End Property

        Public Property MarkNo18() As String
            Set(ByVal value As String)
                If _MarkNo18 <> value Then
                    _MarkNo18 = value
                End If
            End Set
            Get
                Return _MarkNo18
            End Get
        End Property

        Public Property MarkNo19() As String
            Set(ByVal value As String)
                If _MarkNo19 <> value Then
                    _MarkNo19 = value
                End If
            End Set
            Get
                Return _MarkNo19
            End Get
        End Property

        Public Property MarkNo20() As String
            Set(ByVal value As String)
                If _MarkNo20 <> value Then
                    _MarkNo20 = value
                End If
            End Set
            Get
                Return _MarkNo20
            End Get
        End Property

        Public Property MeasurementType() As String
            Set(ByVal value As String)
                If _MeasurementType <> value Then
                    _MeasurementType = value
                End If
            End Set
            Get
                Return _MeasurementType
            End Get
        End Property

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

        Public Property Pcs() As Integer
            Set(ByVal value As Integer)
                If _Pcs <> value Then
                    _Pcs = value
                End If
            End Set
            Get
                Return _Pcs
            End Get
        End Property

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

        Public Property RequiredDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _RequiredDateTime <> value Then
                    _RequiredDateTime = value
                End If
            End Set
            Get
                Return _RequiredDateTime
            End Get
        End Property

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

        Public Property TrxDate() As DateTime
            Set(ByVal value As DateTime)
                If _TrxDate <> value Then
                    _TrxDate = value
                End If
            End Set
            Get
                Return _TrxDate
            End Get
        End Property

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

        Public Property Volume() As Decimal
            Set(ByVal value As Decimal)
                If _Volume <> value Then
                    _Volume = value
                End If
            End Set
            Get
                Return _Volume
            End Get
        End Property

        Public Property NumberPlate() As String
            Set(ByVal value As String)
                If _NumberPlate <> value Then
                    _NumberPlate = value
                End If
            End Set
            Get
                Return _NumberPlate
            End Get
        End Property

        Public Property Make() As String
            Set(ByVal value As String)
                If _Make <> value Then
                    _Make = value
                End If
            End Set
            Get
                Return _Make
            End Get
        End Property

        Public Property Model() As String
            Set(ByVal value As String)
                If _Model <> value Then
                    _Model = value
                End If
            End Set
            Get
                Return _Model
            End Get
        End Property

        Public Property Colour() As String
            Set(ByVal value As String)
                If _Colour <> value Then
                    _Colour = value
                End If
            End Set
            Get
                Return _Colour
            End Get
        End Property

        Public Property ChassisNo() As String
            Set(ByVal value As String)
                If _ChassisNo <> value Then
                    _ChassisNo = value
                End If
            End Set
            Get
                Return _ChassisNo
            End Get
        End Property

        Public Property EngineNo() As String
            Set(ByVal value As String)
                If _EngineNo <> value Then
                    _EngineNo = value
                End If
            End Set
            Get
                Return _EngineNo
            End Get
        End Property

        Public Property FOBNo() As String
            Set(ByVal value As String)
                If _FOBNo <> value Then
                    _FOBNo = value
                End If
            End Set
            Get
                Return _FOBNo
            End Get
        End Property

        Public Property TowDate() As DateTime
            Set(ByVal value As DateTime)
                If _TowDate <> value Then
                    _TowDate = value
                End If
            End Set
            Get
                Return _TowDate
            End Get
        End Property

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

        Public Property Submitter() As String
            Set(ByVal value As String)
                If _Submitter <> value Then
                    _Submitter = value
                End If
            End Set
            Get
                Return _Submitter
            End Get
        End Property

        Public Property NricNo() As String
            Set(ByVal value As String)
                If _NricNo <> value Then
                    _NricNo = value
                End If
            End Set
            Get
                Return _NricNo
            End Get
        End Property

        Public Property CargoStatusCode() As String
            Set(ByVal value As String)
                If _CargoStatusCode <> value Then
                    _CargoStatusCode = value
                End If
            End Set
            Get
                Return _CargoStatusCode
            End Get
        End Property
#End Region

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _LineItemNo = intId
            _BlNo = ""
            _ContainerNo = ""
            _ContainerType = ""
            _ChargeWeight = 0
            _GoodsDescription01 = ""
            _GoodsDescription02 = ""
            _GoodsDescription03 = ""
            _GoodsDescription04 = ""
            _GoodsDescription05 = ""
            _GoodsDescription06 = ""
            _GoodsDescription07 = ""
            _GoodsDescription08 = ""
            _GoodsDescription09 = ""
            _GoodsDescription10 = ""
            _GoodsDescription11 = ""
            _GoodsDescription12 = ""
            _GoodsDescription13 = ""
            _GoodsDescription14 = ""
            _GoodsDescription15 = ""
            _GoodsDescription16 = ""
            _GoodsDescription17 = ""
            _GoodsDescription18 = ""
            _GoodsDescription19 = ""
            _GoodsDescription20 = ""
            _GrossWeight = 0
            _MarkNo01 = ""
            _MarkNo02 = ""
            _MarkNo03 = ""
            _MarkNo04 = ""
            _MarkNo05 = ""
            _MarkNo06 = ""
            _MarkNo07 = ""
            _MarkNo08 = ""
            _MarkNo09 = ""
            _MarkNo10 = ""
            _MarkNo11 = ""
            _MarkNo12 = ""
            _MarkNo13 = ""
            _MarkNo14 = ""
            _MarkNo15 = ""
            _MarkNo16 = ""
            _MarkNo17 = ""
            _MarkNo18 = ""
            _MarkNo19 = ""
            _MarkNo20 = ""
            _MeasurementType = ""
            _NetWeight = 0
            _Pcs = 0
            _Remark = ""
            _RequiredDateTime = ConDateTime.MinDate
            _SealNo = ""
            _TrxDate = ConDateTime.MinDate
            _UomCode = ""
            _Volume = 0
            _NumberPlate = ""
            _Make = ""
            _Model = ""
            _Colour = ""
            _ChassisNo = ""
            _EngineNo = ""
            _FOBNo = ""
            _TowDate = ConDateTime.MinDate
            _Location = ""
            _Submitter = ""
            _NricNo = ""
            _CargoStatusCode = ""
        End Sub
    End Class
End Namespace

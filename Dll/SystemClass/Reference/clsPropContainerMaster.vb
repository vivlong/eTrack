Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI
'Author£ºZhiWei
'ModuleName£ºrccf1
'DateTime£º17/12/2009 13:57:33
Namespace SystemClass

#Region " Class Property of ContainerMaster "
    <Serializable()> _
    Public Class clsPropContainerMaster
        Inherits clsProp
        Private _TrxNo As Integer
        Private _ContainerNo As String = ""
        Private _Comm_Date As DateTime
        Private _Tank_Cat As Int64
        Private _Lessor As String = ""
        Private _Date_Manu As DateTime
        Private _Manufacturer As String = ""
        Private _Plate As String = ""
        Private _ContainerType As String = ""
        Private _ExternalLength As Decimal
        Private _ExternalBreadth As Decimal
        Private _ExternalHeight As Decimal
        Private _InternalLength As Decimal
        Private _InternalBreadth As Decimal
        Private _InternalHeight As Decimal
        Private _Material As String = ""
        Private _Ext_Coat As String = ""
        Private _Capacity As Decimal
        Private _Max_g_Weight As Decimal
        Private _Tare_Weight As Decimal
        Private _MaxPayload As Decimal
        Private _Test_press As Decimal
        Private _Thickness As Decimal
        Private _Approvals As String = ""
        Private _Name_of_file As String = ""
        Private _OnHireDateTime As DateTime
        Private _OffHireDateTime As DateTime
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _StatusCode As String = ""
        Private _AttachmentFlag As String = ""
        Private _UseFlag As String = ""
#Region " Class Property of UseFlag"

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

        Public Property Comm_Date() As DateTime
            Set(ByVal value As DateTime)
                If _Comm_Date <> value Then
                    _Comm_Date = value
                End If
            End Set
            Get
                Return _Comm_Date
            End Get
        End Property

        Public Property Tank_Cat() As Int64
            Set(ByVal value As Int64)
                If _Tank_Cat <> value Then
                    _Tank_Cat = value
                End If
            End Set
            Get
                Return _Tank_Cat
            End Get
        End Property

        Public Property Lessor() As String
            Set(ByVal value As String)
                If _Lessor <> value Then
                    _Lessor = value
                End If
            End Set
            Get
                Return _Lessor
            End Get
        End Property

        Public Property Date_Manu() As DateTime
            Set(ByVal value As DateTime)
                If _Date_Manu <> value Then
                    _Date_Manu = value
                End If
            End Set
            Get
                Return _Date_Manu
            End Get
        End Property

        Public Property Manufacturer() As String
            Set(ByVal value As String)
                If _Manufacturer <> value Then
                    _Manufacturer = value
                End If
            End Set
            Get
                Return _Manufacturer
            End Get
        End Property

        Public Property Plate() As String
            Set(ByVal value As String)
                If _Plate <> value Then
                    _Plate = value
                End If
            End Set
            Get
                Return _Plate
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

        Public Property ExternalLength() As Decimal
            Set(ByVal value As Decimal)
                If _ExternalLength <> value Then
                    _ExternalLength = value
                End If
            End Set
            Get
                Return _ExternalLength
            End Get
        End Property

        Public Property ExternalBreadth() As Decimal
            Set(ByVal value As Decimal)
                If _ExternalBreadth <> value Then
                    _ExternalBreadth = value
                End If
            End Set
            Get
                Return _ExternalBreadth
            End Get
        End Property

        Public Property ExternalHeight() As Decimal
            Set(ByVal value As Decimal)
                If _ExternalHeight <> value Then
                    _ExternalHeight = value
                End If
            End Set
            Get
                Return _ExternalHeight
            End Get
        End Property

        Public Property InternalLength() As Decimal
            Set(ByVal value As Decimal)
                If _InternalLength <> value Then
                    _InternalLength = value
                End If
            End Set
            Get
                Return _InternalLength
            End Get
        End Property

        Public Property InternalBreadth() As Decimal
            Set(ByVal value As Decimal)
                If _InternalBreadth <> value Then
                    _InternalBreadth = value
                End If
            End Set
            Get
                Return _InternalBreadth
            End Get
        End Property

        Public Property InternalHeight() As Decimal
            Set(ByVal value As Decimal)
                If _InternalHeight <> value Then
                    _InternalHeight = value
                End If
            End Set
            Get
                Return _InternalHeight
            End Get
        End Property

        Public Property Material() As String
            Set(ByVal value As String)
                If _Material <> value Then
                    _Material = value
                End If
            End Set
            Get
                Return _Material
            End Get
        End Property

        Public Property Ext_Coat() As String
            Set(ByVal value As String)
                If _Ext_Coat <> value Then
                    _Ext_Coat = value
                End If
            End Set
            Get
                Return _Ext_Coat
            End Get
        End Property

        Public Property Capacity() As Decimal
            Set(ByVal value As Decimal)
                If _Capacity <> value Then
                    _Capacity = value
                End If
            End Set
            Get
                Return _Capacity
            End Get
        End Property

        Public Property Max_g_Weight() As Decimal
            Set(ByVal value As Decimal)
                If _Max_g_Weight <> value Then
                    _Max_g_Weight = value
                End If
            End Set
            Get
                Return _Max_g_Weight
            End Get
        End Property

        Public Property Tare_Weight() As Decimal
            Set(ByVal value As Decimal)
                If _Tare_Weight <> value Then
                    _Tare_Weight = value
                End If
            End Set
            Get
                Return _Tare_Weight
            End Get
        End Property

        Public Property MaxPayload() As Decimal
            Set(ByVal value As Decimal)
                If _MaxPayload <> value Then
                    _MaxPayload = value
                End If
            End Set
            Get
                Return _MaxPayload
            End Get
        End Property

        Public Property Test_press() As Decimal
            Set(ByVal value As Decimal)
                If _Test_press <> value Then
                    _Test_press = value
                End If
            End Set
            Get
                Return _Test_press
            End Get
        End Property
        Public Property Thickness() As Decimal
            Set(ByVal value As Decimal)
                If _Thickness <> value Then
                    _Thickness = value
                End If
            End Set
            Get
                Return _Thickness
            End Get
        End Property

        Public Property Approvals() As String
            Set(ByVal value As String)
                If _Approvals <> value Then
                    _Approvals = value
                End If
            End Set
            Get
                Return _Approvals
            End Get
        End Property

        Public Property Name_of_file() As String
            Set(ByVal value As String)
                If _Name_of_file <> value Then
                    _Name_of_file = value
                End If
            End Set
            Get
                Return _Name_of_file
            End Get
        End Property

        Public Property OnHireDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _OnHireDateTime <> value Then
                    _OnHireDateTime = value
                End If
            End Set
            Get
                Return _OnHireDateTime
            End Get
        End Property

        Public Property OffHireDateTime() As DateTime
            Set(ByVal value As DateTime)
                If _OffHireDateTime <> value Then
                    _OffHireDateTime = value
                End If
            End Set
            Get
                Return _OffHireDateTime
            End Get
        End Property

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

        Public Property UseFlag() As String
            Set(ByVal value As String)
                If _UseFlag <> value Then
                    _UseFlag = value
                End If
            End Set
            Get
                Return _UseFlag
            End Get
        End Property
#End Region
        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _ContainerNo = ""
            _Comm_Date = ConDateTime.MinDate
            _Tank_Cat = 0
            _Lessor = ""
            _Date_Manu = ConDateTime.MinDate
            _Manufacturer = ""
            _Plate = ""
            _ContainerType = ""
            _ExternalLength = 0
            _ExternalBreadth = 0
            _ExternalHeight = 0
            _InternalLength = 0
            _InternalBreadth = 0
            _InternalHeight = 0
            _Material = ""
            _Ext_Coat = ""
            _Capacity = 0
            _Max_g_Weight = 0
            _Tare_Weight = 0
            _MaxPayload = 0
            _Test_press = 0
            _Thickness = 0
            _Approvals = ""
            _Name_of_file = ""
            _OnHireDateTime = ConDateTime.MinDate
            _OffHireDateTime = ConDateTime.MinDate
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _StatusCode = ""
            _AttachmentFlag = ""
            _UseFlag = ""
        End Sub
    End Class


#End Region
End Namespace
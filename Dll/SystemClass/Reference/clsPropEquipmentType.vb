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

    <Serializable()> _
    Public Class clsPropEquipmentType
        Inherits clsProp
        Private _ContainerType As String = ""
        Private _ContainerDescription As String = ""
        Private _ContainerSize As String = ""
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
        Private _Stacking As String = ""
        Private _Work_press As Decimal
        Private _Approvals As String = ""
        Private _NoOfTeu As Decimal
        Private _MaxCubicFt As Decimal
        Private _MaxVolume As Decimal
        Private _MaxWeight As Decimal
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As DateTime
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As DateTime
        Private _Deletable As Boolean

#Region " Class Property of UpdateDateTime"

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

        Public Property ContainerDescription() As String
            Set(ByVal value As String)
                If _ContainerDescription <> value Then
                    _ContainerDescription = value
                End If
            End Set
            Get
                Return _ContainerDescription
            End Get
        End Property

        Public Property ContainerSize() As String
            Set(ByVal value As String)
                If _ContainerSize <> value Then
                    _ContainerSize = value
                End If
            End Set
            Get
                Return _ContainerSize
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

        Public Property Stacking() As String
            Set(ByVal value As String)
                If _Stacking <> value Then
                    _Stacking = value
                End If
            End Set
            Get
                Return _Stacking
            End Get
        End Property

        Public Property Work_press() As Decimal
            Set(ByVal value As Decimal)
                If _Work_press <> value Then
                    _Work_press = value
                End If
            End Set
            Get
                Return _Work_press
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

        Public Property NoOfTeu() As Decimal
            Set(ByVal value As Decimal)
                If _NoOfTeu <> value Then
                    _NoOfTeu = value
                End If
            End Set
            Get
                Return _NoOfTeu
            End Get
        End Property

        Public Property MaxCubicFt() As Decimal
            Set(ByVal value As Decimal)
                If _MaxCubicFt <> value Then
                    _MaxCubicFt = value
                End If
            End Set
            Get
                Return _MaxCubicFt
            End Get
        End Property

        Public Property MaxVolume() As Decimal
            Set(ByVal value As Decimal)
                If _MaxVolume <> value Then
                    _MaxVolume = value
                End If
            End Set
            Get
                Return _MaxVolume
            End Get
        End Property

        Public Property MaxWeight() As Decimal
            Set(ByVal value As Decimal)
                If _MaxWeight <> value Then
                    _MaxWeight = value
                End If
            End Set
            Get
                Return _MaxWeight
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

        Public Property Deletable() As Boolean
            Set(ByVal value As Boolean)
                If _Deletable <> value Then
                    _Deletable = value
                End If
            End Set
            Get
                Return _Deletable
            End Get
        End Property
#End Region
        Public Sub New(ByVal intId As Decimal)
            MyBase.New(intId)
            _ContainerType = intId
            _ContainerDescription = ""
            _ContainerSize = ""
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
            _Stacking = ""
            _Work_press = 0
            _Approvals = ""
            _NoOfTeu = 0
            _MaxCubicFt = 0
            _MaxVolume = 0
            _MaxWeight = 0
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ConDateTime.MinDate
            _UpdateBy = ""
            _UpdateDateTime = ConDateTime.MinDate
            _Deletable = False
        End Sub
    End Class
End Namespace

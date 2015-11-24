Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region "Del Class Property of ContainerType Info "

    <Serializable()> _
    Public Class clsPropContainerType_Old 'hide by danny 2010.7.21
        Inherits clsProp
        Private _ContainerType As String = ""
        Private _ContainerDescription As String = ""
        Private _ContainerSize As String = ""
        Private _NoOfTeu As String = ""
        Private _MaxCubicFt As String = ""
        Private _MaxVolume As String = ""
        Private _MaxWeight As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        ' 
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
        ' 
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
        ' 
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
        ' 
        Public Property NoOfTeu() As String
            Set(ByVal value As String)
                If _NoOfTeu <> value Then
                    _NoOfTeu = value
                End If
            End Set
            Get
                Return _NoOfTeu
            End Get
        End Property
        ' 
        Public Property MaxCubicFt() As String
            Set(ByVal value As String)
                If _MaxCubicFt <> value Then
                    _MaxCubicFt = value
                End If
            End Set
            Get
                Return _MaxCubicFt
            End Get
        End Property
        ' 
        Public Property MaxVolume() As String
            Set(ByVal value As String)
                If _MaxVolume <> value Then
                    _MaxVolume = value
                End If
            End Set
            Get
                Return _MaxVolume
            End Get
        End Property
        ' 
        Public Property MaxWeight() As String
            Set(ByVal value As String)
                If _MaxWeight <> value Then
                    _MaxWeight = value
                End If
            End Set
            Get
                Return _MaxWeight
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
            _ContainerType = ""
            _ContainerDescription = ""
            _ContainerSize = ""
            _NoOfTeu = ""
            _MaxCubicFt = ""
            _MaxVolume = ""
            _MaxWeight = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
        End Sub

    End Class

#End Region
#Region " Class Property of ContainerType Info "

    <Serializable()> _
    Public Class clsPropContainerType
        Inherits clsProp
        Private _ContainerType As String = ""
        Private _ContainerDescription As String = ""
        Private _ContainerSize As String = ""
        Private _ExternalLength As String = ""
        Private _ExternalBreadth As String = ""
        Private _ExternalHeight As String = ""
        Private _InternalLength As String = ""
        Private _InternalBreadth As String = ""
        Private _InternalHeight As String = ""
        Private _Material As String = ""
        Private _Ext_Coat As String = ""
        Private _Capacity As String = ""
        Private _Max_g_Weight As String = ""
        Private _Tare_Weight As String = ""
        Private _MaxPayload As String = ""
        Private _Stacking As String = ""
        Private _Work_press As String = ""
        Private _Approvals As String = ""
        Private _NoOfTeu As String = ""
        Private _MaxCubicFt As String = ""
        Private _MaxVolume As String = ""
        Private _MaxWeight As String = ""
        Private _StatusCode As String = ""
        Private _CreateBy As String = ""
        Private _CreateDateTime As String = ""
        Private _UpdateBy As String = ""
        Private _UpdateDateTime As String = ""
        Private _AttachmentFlag As String = ""

        ' 
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
        Public Property ExternalLength() As String
            Set(ByVal value As String)
                If _ExternalLength <> value Then
                    _ExternalLength = value
                End If
            End Set
            Get
                Return _ExternalLength
            End Get
        End Property
        Public Property ExternalBreadth() As String
            Set(ByVal value As String)
                If _ExternalBreadth <> value Then
                    _ExternalBreadth = value
                End If
            End Set
            Get
                Return _ExternalBreadth
            End Get
        End Property
        Public Property ExternalHeight() As String
            Set(ByVal value As String)
                If _ExternalHeight <> value Then
                    _ExternalHeight = value
                End If
            End Set
            Get
                Return _ExternalHeight
            End Get
        End Property
        Public Property InternalLength() As String
            Set(ByVal value As String)
                If _InternalLength <> value Then
                    _InternalLength = value
                End If
            End Set
            Get
                Return _InternalLength
            End Get
        End Property
        Public Property InternalBreadth() As String
            Set(ByVal value As String)
                If _InternalBreadth <> value Then
                    _InternalBreadth = value
                End If
            End Set
            Get
                Return _InternalBreadth
            End Get
        End Property
        Public Property InternalHeight() As String
            Set(ByVal value As String)
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
        Public Property Capacity() As String
            Set(ByVal value As String)
                If _Capacity <> value Then
                    _Capacity = value
                End If
            End Set
            Get
                Return _Capacity
            End Get
        End Property
        Public Property Max_g_Weight() As String
            Set(ByVal value As String)
                If _Max_g_Weight <> value Then
                    _Max_g_Weight = value
                End If
            End Set
            Get
                Return _Max_g_Weight
            End Get
        End Property
        Public Property Tare_Weight() As String
            Set(ByVal value As String)
                If _Tare_Weight <> value Then
                    _Tare_Weight = value
                End If
            End Set
            Get
                Return _Tare_Weight
            End Get
        End Property
        Public Property MaxPayload() As String
            Set(ByVal value As String)
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
        Public Property Work_press() As String
            Set(ByVal value As String)
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
        Public Property NoOfTeu() As String
            Set(ByVal value As String)
                If _NoOfTeu <> value Then
                    _NoOfTeu = value
                End If
            End Set
            Get
                Return _NoOfTeu
            End Get
        End Property
        Public Property MaxCubicFt() As String
            Set(ByVal value As String)
                If _MaxCubicFt <> value Then
                    _MaxCubicFt = value
                End If
            End Set
            Get
                Return _MaxCubicFt
            End Get
        End Property
        Public Property MaxVolume() As String
            Set(ByVal value As String)
                If _MaxVolume <> value Then
                    _MaxVolume = value
                End If
            End Set
            Get
                Return _MaxVolume
            End Get
        End Property
        Public Property MaxWeight() As String
            Set(ByVal value As String)
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


        Public Sub New(ByVal strId As String)
            MyBase.New(strId)
            _ContainerType = ""
            _ContainerDescription = ""
            _ContainerSize = ""
            _ExternalLength = ""
            _ExternalBreadth = ""
            _ExternalHeight = ""
            _InternalLength = ""
            _InternalBreadth = ""
            _InternalHeight = ""
            _Material = ""
            _Ext_Coat = ""
            _Capacity = ""
            _Max_g_Weight = ""
            _Tare_Weight = ""
            _MaxPayload = ""
            _Stacking = ""
            _Work_press = ""
            _Approvals = ""
            _NoOfTeu = ""
            _MaxCubicFt = ""
            _MaxVolume = ""
            _MaxWeight = ""
            _StatusCode = ""
            _CreateBy = ""
            _CreateDateTime = ""
            _UpdateBy = ""
            _UpdateDateTime = ""
            _AttachmentFlag = ""

        End Sub

    End Class

#End Region
End Namespace
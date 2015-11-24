Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of RO2 Info "

    <Serializable()> _
    Public Class clsPropRO2
        Inherits clsProp
        Private _TrxNo As Int64
        Private _LineItemNo As Int64
        Private _ContainerNo As String = ""
        Private _ReleaseDate As DateTime
        Private _TruckerName As String = ""
        Private _VehicleNo As String = ""
        Private _SealNo As String = ""
        Private _DGFlag As String = ""
        Private _DriverPassNo As String = ""
        Private _EquipmentType As String = ""
        Private _ReleaseRemarks As String = ""
        Private _ReleaseFlag As Int64
        Private _Qty As Int64
        ' 
        Public Property TrxNo() As Int64
            Set(ByVal value As Int64)
                If _TrxNo <> value Then
                    _TrxNo = value
                End If
            End Set
            Get
                Return _TrxNo
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
        ' 
        Public Property ReleaseDate() As DateTime
            Set(ByVal value As DateTime)
                If _ReleaseDate <> value Then
                    _ReleaseDate = value
                End If
            End Set
            Get
                Return _ReleaseDate
            End Get
        End Property
        ' 
        Public Property TruckerName() As String
            Set(ByVal value As String)
                If _TruckerName <> value Then
                    _TruckerName = value
                End If
            End Set
            Get
                Return _TruckerName
            End Get
        End Property
        ' 
        Public Property VehicleNo() As String
            Set(ByVal value As String)
                If _VehicleNo <> value Then
                    _VehicleNo = value
                End If
            End Set
            Get
                Return _VehicleNo
            End Get
        End Property
        ' 
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
        ' 
        Public Property DGFlag() As String
            Set(ByVal value As String)
                If _DGFlag <> value Then
                    _DGFlag = value
                End If
            End Set
            Get
                Return _DGFlag
            End Get
        End Property
        ' 
        Public Property DriverPassNo() As String
            Set(ByVal value As String)
                If _DriverPassNo <> value Then
                    _DriverPassNo = value
                End If
            End Set
            Get
                Return _DriverPassNo
            End Get
        End Property
        ' 
        Public Property EquipmentType() As String
            Set(ByVal value As String)
                If _EquipmentType <> value Then
                    _EquipmentType = value
                End If
            End Set
            Get
                Return _EquipmentType
            End Get
        End Property
        ' 
        Public Property ReleaseRemarks() As String
            Set(ByVal value As String)
                If _ReleaseRemarks <> value Then
                    _ReleaseRemarks = value
                End If
            End Set
            Get
                Return _ReleaseRemarks
            End Get
        End Property

        Public Property ReleaseFlag() As Int64
            Set(ByVal value As Int64)
                If _ReleaseFlag <> value Then
                    _ReleaseFlag = value
                End If
            End Set
            Get
                Return _ReleaseFlag
            End Get
        End Property

        Public Property Qty() As Int64
            Set(ByVal value As Int64)
                If _Qty <> value Then
                    _Qty = value
                End If
            End Set
            Get
                Return _Qty
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _LineItemNo = -1
            _ContainerNo = ""
            _ReleaseDate = ConDateTime.MinDate
            _TruckerName = ""
            _VehicleNo = ""
            _SealNo = ""
            _DGFlag = ""
            _DriverPassNo = ""
            _EquipmentType = ""
            _ReleaseRemarks = ""
            _ReleaseFlag = 0
            _Qty = -1
        End Sub
    End Class



#End Region
End Namespace
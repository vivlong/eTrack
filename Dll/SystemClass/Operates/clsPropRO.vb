Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of RO Info "

    <Serializable()> _
    Public Class clsPropRO
        Inherits clsProp
        Private _TrxNo As Int64
        Private _LineItemNo As Int64
        Private _ReleasingOrderNo As String = ""
        Private _ShipperCode As String = ""
        Private _ShipperName As String = ""
        Private _EquipmentType As String = ""
        Private _Qty As String = ""
        Private _DepotCode As String = ""
        Private _InstructionToDepot As String = ""
        Private _TruckerCode As String = ""
        Private _TruckerName As String = ""
        Private _PreCoolFlag As String = ""
        Private _PreSetSign As String = ""
        Private _PreSetTemperature As String = ""
        Private _PreSetType As String = ""
        Private _Commodity As String = ""
        Private _VoltageCode As String = ""
        Private _CollectionDate As DateTime
        Private _ContainerList As String = ""
        Private _ROReleaseDate As DateTime
        Private _EtaDate As DateTime
        Private _intContainerNo As Int64
        Private _DetentionCode As String = ""
        Private _DetentionFreeDay As Int64
        Private _ReleasingInstructionNo As String = ""
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
        Public Property LineItemNo() As Int64
            Set(ByVal value As Int64)
                If _LineItemNo <> value Then
                    _LineItemNo = value
                End If
            End Set
            Get
                Return _LineItemNo
            End Get
        End Property
        ' 
        Public Property ReleasingOrderNo() As String
            Set(ByVal value As String)
                If _ReleasingOrderNo <> value Then
                    _ReleasingOrderNo = value
                End If
            End Set
            Get
                Return _ReleasingOrderNo
            End Get
        End Property
        ' 
        Public Property ShipperCode() As String
            Set(ByVal value As String)
                If _ShipperCode <> value Then
                    _ShipperCode = value
                End If
            End Set
            Get
                Return _ShipperCode
            End Get
        End Property
        ' 
        Public Property ShipperName() As String
            Set(ByVal value As String)
                If _ShipperName <> value Then
                    _ShipperName = value
                End If
            End Set
            Get
                Return _ShipperName
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
        ' 
        Public Property DepotCode() As String
            Set(ByVal value As String)
                If _DepotCode <> value Then
                    _DepotCode = value
                End If
            End Set
            Get
                Return _DepotCode
            End Get
        End Property
        ' 
        Public Property InstructionToDepot() As String
            Set(ByVal value As String)
                If _InstructionToDepot <> value Then
                    _InstructionToDepot = value
                End If
            End Set
            Get
                Return _InstructionToDepot
            End Get
        End Property
        ' 
        Public Property TruckerCode() As String
            Set(ByVal value As String)
                If _TruckerCode <> value Then
                    _TruckerCode = value
                End If
            End Set
            Get
                Return _TruckerCode
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
        Public Property PreCoolFlag() As String
            Set(ByVal value As String)
                If _PreCoolFlag <> value Then
                    _PreCoolFlag = value
                End If
            End Set
            Get
                Return _PreCoolFlag
            End Get
        End Property
        ' 
        Public Property PreSetSign() As String
            Set(ByVal value As String)
                If _PreSetSign <> value Then
                    _PreSetSign = value
                End If
            End Set
            Get
                Return _PreSetSign
            End Get
        End Property
        ' 
        Public Property PreSetTemperature() As Decimal
            Set(ByVal value As Decimal)
                If _PreSetTemperature <> value Then
                    _PreSetTemperature = value
                End If
            End Set
            Get
                Return _PreSetTemperature
            End Get
        End Property
        ' 
        Public Property PreSetType() As String
            Set(ByVal value As String)
                If _PreSetType <> value Then
                    _PreSetType = value
                End If
            End Set
            Get
                Return _PreSetType
            End Get
        End Property
        ' 
        Public Property Commodity() As String
            Set(ByVal value As String)
                If _Commodity <> value Then
                    _Commodity = value
                End If
            End Set
            Get
                Return _Commodity
            End Get
        End Property
        ' 
        Public Property VoltageCode() As String
            Set(ByVal value As String)
                If _VoltageCode <> value Then
                    _VoltageCode = value
                End If
            End Set
            Get
                Return _VoltageCode
            End Get
        End Property
        ' 
        Public Property CollectionDate() As DateTime
            Set(ByVal value As DateTime)
                If _CollectionDate <> value Then
                    _CollectionDate = value
                End If
            End Set
            Get
                Return _CollectionDate
            End Get
        End Property
        Public Property ContainerList() As String
            Set(ByVal value As String)
                If _ContainerList <> value Then
                    _ContainerList = value
                End If
            End Set
            Get
                Return _ContainerList
            End Get
        End Property
        Public Property ROReleaseDate() As DateTime
            Set(ByVal value As DateTime)
                If _ROReleaseDate <> value Then
                    _ROReleaseDate = value
                End If
            End Set
            Get
                Return _ROReleaseDate
            End Get
        End Property

        Public Property EtaDate() As DateTime
            Set(ByVal value As DateTime)
                If _EtaDate <> value Then
                    _EtaDate = value
                End If
            End Set
            Get
                Return _EtaDate
            End Get
        End Property
        Public Property intContainerNo() As Int64
            Set(ByVal value As Int64)
                If _intContainerNo <> value Then
                    _intContainerNo = value
                End If
            End Set
            Get
                Return _intContainerNo
            End Get
        End Property
        Public Property DetentionCode() As String
            Set(ByVal value As String)
                If _DetentionCode <> value Then
                    _DetentionCode = value
                End If
            End Set
            Get
                Return _DetentionCode
            End Get
        End Property
        Public Property DetentionFreeDay() As Int64
            Set(ByVal value As Int64)
                If _DetentionFreeDay <> value Then
                    _DetentionFreeDay = value
                End If
            End Set
            Get
                Return _DetentionFreeDay
            End Get
        End Property
        Public Property ReleasingInstructionNo() As String
            Set(ByVal value As String)
                If _ReleasingInstructionNo <> value Then
                    _ReleasingInstructionNo = value
                End If
            End Set
            Get
                Return _ReleasingInstructionNo
            End Get
        End Property



        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _LineItemNo = -1
            _ReleasingOrderNo = ""
            _ShipperCode = ""
            _ShipperName = ""
            _EquipmentType = ""
            _Qty = -1
            _DepotCode = ""
            _InstructionToDepot = ""
            _TruckerCode = ""
            _TruckerName = ""
            _PreCoolFlag = ""
            _PreSetSign = ""
            _PreSetTemperature = -1
            _PreSetType = ""
            _Commodity = ""
            _VoltageCode = ""
            _CollectionDate = ConDateTime.MinDate
            _ContainerList = ""
            _ROReleaseDate = ConDateTime.MinDate
            _EtaDate = ConDateTime.MinDate
            _intContainerNo = 0
            _DetentionCode = ""
            _DetentionFreeDay = 0
            _ReleasingInstructionNo = ""
        End Sub
    End Class



#End Region
End Namespace
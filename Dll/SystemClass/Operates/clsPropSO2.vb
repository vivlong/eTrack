Imports System
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports SysMagic.ZZMessage
Imports SysMagic.ZZSystem
Imports System.Web.UI

Namespace SystemClass

#Region " Class Property of RI Info "

    <Serializable()> _
    Public Class clsPropSO2
        Inherits clsProp
        Private _TrxNo As Int64
        Private _LineItemNo As Int64
        Private _ContainerNo As String = ""
        Private _ReceiveDate As String = ""
        Private _TruckerName As String = ""
        Private _VehicleNo As String = ""
        Private _CollectionRemarks As String = ""
        Private _SurveyRemarks As String = ""
        Private _ActualDetentionCharge As Decimal
        Private _ComputedDetentionCharge As Decimal
        Private _State As String = ""
        Private _ContainerType As String = ""
        Private _PortOfLoadingCode As String = ""
        Private _EquipmentType As String = ""
        Private _ReceiveBatchNo As String = ""
        Private _ReceiveFlag As Int64
        Private _ReturnDate As String = ""
        Private _RvFlag As String = ""

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
        Public Property ReceiveDate() As String
            Set(ByVal value As String)
                If _ReceiveDate <> value Then
                    _ReceiveDate = value
                End If
            End Set
            Get
                Return _ReceiveDate
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
        Public Property CollectionRemarks() As String
            Set(ByVal value As String)
                If _CollectionRemarks <> value Then
                    _CollectionRemarks = value
                End If
            End Set
            Get
                Return _CollectionRemarks
            End Get
        End Property
        ' 
        Public Property SurveyRemarks() As String
            Set(ByVal value As String)
                If _SurveyRemarks <> value Then
                    _SurveyRemarks = value
                End If
            End Set
            Get
                Return _SurveyRemarks
            End Get
        End Property
        ' 
        Public Property ActualDetentionCharge() As Decimal
            Set(ByVal value As Decimal)
                If _ActualDetentionCharge <> value Then
                    _ActualDetentionCharge = value
                End If
            End Set
            Get
                Return _ActualDetentionCharge
            End Get
        End Property
        ' 
        Public Property ComputedDetentionCharge() As Decimal
            Set(ByVal value As Decimal)
                If _ComputedDetentionCharge <> value Then
                    _ComputedDetentionCharge = value
                End If
            End Set
            Get
                Return _ComputedDetentionCharge
            End Get
        End Property
        ' 
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

        Public Property ReceiveBatchNo() As String
            Set(ByVal value As String)
                If _ReceiveBatchNo <> value Then
                    _ReceiveBatchNo = value
                End If
            End Set
            Get
                Return _ReceiveBatchNo
            End Get
        End Property

        Public Property ReceiveFlag() As Int64
            Set(ByVal value As Int64)
                If _ReceiveFlag <> value Then
                    _ReceiveFlag = value
                End If
            End Set
            Get
                Return _ReceiveFlag
            End Get
        End Property

        Public Property ReturnDate() As String
            Set(ByVal value As String)
                If _ReturnDate <> value Then
                    _ReturnDate = value
                End If
            End Set
            Get
                Return _ReturnDate
            End Get
        End Property

        Public Property RvFlag() As String
            Set(ByVal value As String)
                If _RvFlag <> value Then
                    _RvFlag = value
                End If
            End Set
            Get
                Return _RvFlag
            End Get
        End Property

        Public Sub New(ByVal intId As Integer)
            MyBase.New(intId)
            _TrxNo = intId
            _LineItemNo = -1
            _ContainerNo = ""
            _ReceiveDate = ConDateTime.MinDate
            _TruckerName = ""
            _VehicleNo = ""
            _CollectionRemarks = ""
            _SurveyRemarks = ""
            _ActualDetentionCharge = 0
            _ComputedDetentionCharge = 0
            _State = ""
            _ContainerType = ""
            _PortOfLoadingCode = ""
            _EquipmentType = ""
            _ReceiveBatchNo = ""
            _ReceiveFlag = -1
            _ReturnDate = ""
            _RvFlag = ""
        End Sub
    End Class



#End Region
End Namespace